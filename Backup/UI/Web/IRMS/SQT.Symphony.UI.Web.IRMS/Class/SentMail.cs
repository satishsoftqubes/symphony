using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Linq;

namespace SQT.Symphony.UI.Web.IRMS
{
    public static class SentMail
    {
        public static bool SendMail(string PrimaryDomainName, string UserName, string Password, string SMTP, string To, string Subject, string Body)
        {
            try
            {
                /*
                MailMessage NetMail = new MailMessage();
                SmtpClient MailClient = new SmtpClient();

                string ThisHost = PrimaryDomainName;
                
                NetworkCredential TheseCredentials = new NetworkCredential(UserName, Password);
                
                string ThisSender = "UniWorld <  " + UserName + " >";

                NetMail.To.Add(To);
                //NetMail.From = new MailAddress(ThisSender);
                NetMail.From = new MailAddress("UniWorld <ir.uniworld@gmail.com>");
                NetMail.ReplyTo = new MailAddress("ir.uniworld@gmail.com");
                NetMail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                NetMail.IsBodyHtml = true;
                NetMail.Priority = MailPriority.High;
                NetMail.Subject = Subject;
                NetMail.Body = Body;

                MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailClient.Host = ThisHost;
                MailClient.UseDefaultCredentials = false;
                MailClient.Credentials = TheseCredentials;
                MailClient.Send(NetMail);
                return true;
                */

                SmtpClient sc = new SmtpClient(SMTP, 587);
                sc.EnableSsl = true;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(UserName, Password);
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;                
                
                
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
            catch (SmtpException se)
            {
                //try
                //{
                //    SmtpClient sc = new SmtpClient(SMTP, 587);
                //    sc.EnableSsl = true;
                //    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    sc.UseDefaultCredentials = false;
                //    sc.Credentials = new NetworkCredential(UserName, Password);
                //    MailMessage mail = new MailMessage();
                //    mail.To.Add(new MailAddress(To));
                //    mail.From = new MailAddress(UserName);
                //    mail.Subject = Subject;
                //    mail.IsBodyHtml = true;
                //    mail.ReplyTo = new MailAddress(UserName);
                //    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //    mail.Priority = MailPriority.High;
                //    mail.Body = Body;
                //    sc.Send(mail);
                //    return true;
                //}
                //catch (SmtpException s)
                //{
                //    return false;
                //}
                return false;
            }
        }

        public static bool SendMail(string PrimaryDomainName, string UserName, string Password, string SMTP, string To, string Subject, string Body, string AttachmentFileName)
        {
            try
            {
                MailMessage NetMail = new MailMessage();
                SmtpClient MailClient = new SmtpClient();

                string ThisHost = PrimaryDomainName;

                NetworkCredential TheseCredentials = new NetworkCredential(UserName, Password);

                string ThisSender = "UniWorld <  " + UserName + " >";

                NetMail.To.Add(To);
                NetMail.From = new MailAddress(ThisSender);
                NetMail.ReplyTo = new MailAddress(ThisSender);
                NetMail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                NetMail.IsBodyHtml = true;
                NetMail.Priority = MailPriority.High;
                NetMail.Subject = Subject;
                NetMail.Body = Body;

                string[] strarray;
                strarray = AttachmentFileName.Split(',');
                for (int i = 0; i < strarray.Length; i++)
                {
                    if (!AttachmentFileName.Equals(""))
                    {
                        NetMail.Attachments.Add(new Attachment(Convert.ToString(strarray[i])));
                    }
                }

                MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailClient.Host = ThisHost;
                MailClient.UseDefaultCredentials = false;
                MailClient.Credentials = TheseCredentials;
                MailClient.Send(NetMail);
                return true;
            }
            catch (SmtpException se)
            {
                try
                {
                    SmtpClient sc = new SmtpClient(SMTP, 25);
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
                    string[] strarray;
                    strarray = AttachmentFileName.Split(',');
                    for (int i = 0; i < strarray.Length; i++)
                    {
                        if (!AttachmentFileName.Equals(""))
                        {
                            mail.Attachments.Add(new Attachment(Convert.ToString(strarray[i])));
                        }
                    }

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
}
