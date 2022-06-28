using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Timers;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
//using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SrvcGuestOverstay
{
    public partial class SrvcOverStay : ServiceBase
    {
        Timer timer = new Timer();
        public SrvcOverStay()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);

            //This statement is used to set interval to 1 minute (= 60,000 milliseconds)

            timer.Interval = 3600000; // 1 hour
            //timer.Interval = 300000; // 5 minutes

            //enabling the timer
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {
                int srvcRunTimeHour = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["ServiceRunTimeinHour"].ToString());
                int srvc2ndRunTimeHour = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["2ndServiceRunTimeinHour"].ToString());
                if (Convert.ToInt32(DateTime.Now.Hour) == srvcRunTimeHour || Convert.ToInt32(DateTime.Now.Hour) == srvc2ndRunTimeHour)
                {
                    //string oConnString = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["ConnString"]);
                    //SqlConnection oConn = new SqlConnection(oConnString);
                    //SqlCommand oCmd = new SqlCommand("Exec res_Reservation_Select4OverstayNotification", oConn);
                    //SqlDataAdapter oAdptr = new SqlDataAdapter(oCmd);
                    DataSet dsGuestEmails = new DataSet();
                    //oConn.Open();
                    //oCmd.ExecuteNonQuery();
                    //oCmd.CommandTimeout = 600;
                    //oAdptr.Fill(dsGuestEmails);
                    //oConn.Close();

                    string strEmailFrom = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailFrom"]);
                    string strEmailPwd = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailFromPwd"]);
                    string strEmailSubject = "";
                    string strPrimoryDomainName = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["PrimoryDomainName"]);
                    string strSMTPAddress = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["SMTPAddress"]);

                    srvcCeckInGuestList.CheckInGuestListSoapClient objClient = new srvcCeckInGuestList.CheckInGuestListSoapClient();
                    dsGuestEmails = objClient.GetReservationsToSendOverstayNotification();

                    if (Convert.ToInt32(DateTime.Now.Hour) == srvcRunTimeHour)
                    {
                        if (dsGuestEmails != null && dsGuestEmails.Tables[0].Rows.Count > 0)
                        {
                            strEmailSubject = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailSubject"]);
                            StringBuilder strTemplate = new StringBuilder();

                            for (int i = 0; i < dsGuestEmails.Tables[0].Rows.Count; i++)
                            {
                                strTemplate.Clear();
                                strTemplate.Append("<table width='800px' cellpadding='2' cellspacing='2' style='border: 1px Solid Black;'><tr><td><table width='100%'><tr><td align='right' style='padding: 5px;'>Date: ");
                                strTemplate.Append(DateTime.Today.ToString("dd-MM-yyyy"));
                                strTemplate.Append("</td></tr><tr><td>Dear Guest,</td></tr><tr><td>This is to remind you that your check-out date is on " + Convert.ToString(dsGuestEmails.Tables[0].Rows[i]["CheckOutDate"]) + ". In case if you wish to extend your stay, please make your payment immediately at the front desk failing which 'late payment' charges of Rs. 50/- per day will be applicable as per our policy.");
                                strTemplate.Append("</td></tr><tr><td>&nbsp;</td></tr><tr><td>Thanking You</td></tr><tr><td>&nbsp;</td></tr><tr><td>Team Uniworld</td></tr></table></td></tr></table>");

                                //SendMail("relay-hosting.secureserver.net", "frontdesk.uniworld@gmail.com", "lenovo@123", "smtp.gmail.com", "vijaymulani22@gmail.com", "Mail from Uniworld to remind you that tomorrow is your check out date", strTemplate.ToString());
                                SendMail(strPrimoryDomainName, strEmailFrom, strEmailPwd, strSMTPAddress, Convert.ToString(dsGuestEmails.Tables[0].Rows[i]["Email"]), strEmailSubject, strTemplate.ToString());
                            }
                        }
                    }


                    if (Convert.ToInt32(DateTime.Now.Hour) == srvc2ndRunTimeHour)
                    {
                        if (dsGuestEmails != null && dsGuestEmails.Tables[1].Rows.Count > 0)
                        {
                            StringBuilder strTemplate = new StringBuilder();

                            for (int i = 0; i < dsGuestEmails.Tables[1].Rows.Count; i++)
                            {
                                strTemplate.Clear();
                                if (Convert.ToInt32(dsGuestEmails.Tables[1].Rows[i]["TotalOverStayDays"].ToString()) == Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["NumOfDaysToSend2ndMail"]))
                                {
                                    strEmailSubject = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailSubjectFor2ndMail"]);

                                    strTemplate.Append("<table width='800px' cellpadding='2' cellspacing='2' style='border: 1px Solid Black;'><tr><td><table width='100%'><tr><td align='right' style='padding: 5px;'>Date: ");
                                    strTemplate.Append(DateTime.Today.ToString("dd-MM-yyyy"));
                                    strTemplate.Append("</td></tr><tr><td>Dear Guest,</td></tr><tr><td>This is to remind you that you have not still made payment for extending your stay. As per our policy, a late payment charge of " + Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["FirstTimeCharges"]) + " will be applicable effective today which will be adjusted from your Deposit. If your payment is still not received within " + Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["FirstTimeChargesApplyTillDays"]) + ", the late payment charge will be increased to " + Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["SecondTimeCharges"]) + ".</td></tr>");
                                    strTemplate.Append("<tr><td>&nbsp;</td></tr><tr><td>Please ignore this mail if payment is already made or contact Front Desk for any clarifications.</td></tr>");
                                    strTemplate.Append("<tr><td>&nbsp;</td></tr><tr><td>Thanking You</td></tr><tr><td>&nbsp;</td></tr><tr><td>Team Uniworld</td></tr></table></td></tr></table>");

                                    //SendMail("relay-hosting.secureserver.net", "frontdesk.uniworld@gmail.com", "lenovo@123", "smtp.gmail.com", "vijaymulani22@gmail.com", "Mail from Uniworld to remind you that tomorrow is your check out date", strTemplate.ToString());
                                    SendMail(strPrimoryDomainName, strEmailFrom, strEmailPwd, strSMTPAddress, Convert.ToString(dsGuestEmails.Tables[1].Rows[i]["Email"]), strEmailSubject, strTemplate.ToString());
                                }
                                else if (Convert.ToInt32(dsGuestEmails.Tables[1].Rows[i]["TotalOverStayDays"].ToString()) == Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["NumOfDaysToSend3rdMail"]))
                                {
                                    strEmailSubject = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailSubjectFor3rdMail"]);

                                    strTemplate.Append("<table width='800px' cellpadding='2' cellspacing='2' style='border: 1px Solid Black;'><tr><td><table width='100%'><tr><td align='right' style='padding: 5px;'>Date: ");
                                    strTemplate.Append(DateTime.Today.ToString("dd-MM-yyyy"));
                                    strTemplate.Append("</td></tr><tr><td>Dear Guest,</td></tr><tr><td>Despite reminders sent to you, your room rent still remains unpaid. Therefore as per our policy, a late payment charge " + Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["SecondTimeCharges"]) + " will be applicable to you effective today which will adjusted from your deposit.</td></tr>");
                                    strTemplate.Append("<tr><td>&nbsp;</td></tr><tr><td>If your deposit is completely consumed, you will be required to vacate your room. To prevent this, please settle your overdue amount immediately.</td></tr>");
                                    strTemplate.Append("<tr><td>&nbsp;</td></tr><tr><td>Thanking You</td></tr><tr><td>&nbsp;</td></tr><tr><td>Team Uniworld</td></tr></table></td></tr></table>");

                                    //SendMail("relay-hosting.secureserver.net", "frontdesk.uniworld@gmail.com", "lenovo@123", "smtp.gmail.com", "vijaymulani22@gmail.com", "Mail from Uniworld to remind you that tomorrow is your check out date", strTemplate.ToString());
                                    SendMail(strPrimoryDomainName, strEmailFrom, strEmailPwd, strSMTPAddress, Convert.ToString(dsGuestEmails.Tables[1].Rows[i]["Email"]), strEmailSubject, strTemplate.ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error", ex.Message, EventLogEntryType.Warning);
            }
        }


        public static bool SendMail(string PrimaryDomainName, string UserName, string Password, string SMTP, string To, string Subject, string Body)
        {
            try
            {
                SmtpClient sc = new SmtpClient(SMTP, 587);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(UserName, Password);
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(To));
                mail.From = new MailAddress(UserName);
                mail.Subject = Subject;
                mail.IsBodyHtml = true;
                mail.ReplyTo = new MailAddress(UserName);
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.Priority = MailPriority.High;
                mail.Body = Body;
                sc.Send(mail);
                return true;
            }
            catch (SmtpException s)
            {
                return false;
            }
        }

    }
}
