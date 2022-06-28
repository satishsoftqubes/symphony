using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using SQT.FRAMEWORK.DAL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.ReportFiles.GDI
{
    public class ReportFunctions : DBManager
    {
        public ReportFunctions() : base()
        {}       

        #region Send Mail
        public string SendEmailMessage(string strFrom, string strTo, string strCc, string strSubject, string strMessage, string fileList)
        {
            try
            {
                //For each to address create a mail message
                MailMessage MailMsg = new MailMessage(new MailAddress(strFrom.Trim()), new MailAddress(strTo));
                if (strCc != "")
                    MailMsg.CC.Add(new MailAddress(strCc));
                MailMsg.BodyEncoding = Encoding.Default;
                MailMsg.Subject = strSubject.Trim();
                MailMsg.Body = strMessage;
                MailMsg.Priority = MailPriority.High;
                MailMsg.IsBodyHtml = true;

                //attach each file attachment
                if (fileList != "")
                {
                    Attachment MsgAttach = new Attachment(fileList);
                    MailMsg.Attachments.Add(MsgAttach);
                }
                fileList = null;
                List<PropertyConfiguration> objProperty = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, clsSession.PropertyID);

                //Smtpclient to send the mail message
                SmtpClient SmtpMail = new SmtpClient();
                SmtpMail.Host = objProperty[0].SmtpAddress;
                SmtpMail.UseDefaultCredentials = false;
                SmtpMail.Credentials = new NetworkCredential(objProperty[0].UserName, objProperty[0].Password);
                SmtpMail.EnableSsl = false;
                SmtpMail.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                SmtpMail.Port = 587;
                SmtpMail.Send(MailMsg);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string SendEmailMessage(string strFrom, string strTo, string strCc, string strSubject, string strMessage, FileInfo[] fileList)
        {
            try
            {
                //For each to address create a mail message
                MailMessage MailMsg = new MailMessage(new MailAddress(strFrom.Trim()), new MailAddress(strTo));
                if (strCc != "")
                    MailMsg.CC.Add(new MailAddress(strCc));
                MailMsg.BodyEncoding = Encoding.Default;
                MailMsg.Subject = strSubject.Trim();
                MailMsg.Body = strMessage;
                MailMsg.Priority = MailPriority.High;
                MailMsg.IsBodyHtml = true;

                //attach each file attachment
                if (fileList != null)
                {
                    foreach (FileInfo fl in fileList)
                    {
                        Attachment MsgAttach = new Attachment(fl.FullName);
                        MailMsg.Attachments.Add(MsgAttach);
                    }
                }
                List<PropertyConfiguration> objProperty = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, clsSession.PropertyID);
                fileList = null;
                //Smtpclient to send the mail message
                SmtpClient SmtpMail = new SmtpClient();
                SmtpMail.Host = objProperty[0].SmtpAddress;
                SmtpMail.UseDefaultCredentials = false;
                SmtpMail.Credentials = new NetworkCredential(objProperty[0].UserName, objProperty[0].Password);
                SmtpMail.EnableSsl = false;
                SmtpMail.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                SmtpMail.Port = 587;
                SmtpMail.Send(MailMsg);
                MailMsg.Dispose();

                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
