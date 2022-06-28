using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Net.Mail;
namespace SQT.FRAMEWORK.LOGGER
{
    /// <summary>
    /// Provides methods/properties for common functionalities.
    /// </summary>
    public static class Common
    {
       
        /// <summary>
        /// Gets the name of the method which calls this method.
        /// </summary>
        /// <returns>The method name.</returns>
        public static string GetMethodName
        {
            get
            {
                MethodBase methodName = new StackFrame(1).GetMethod();
                return methodName.DeclaringType.FullName;
            }
        }

        /// <summary>
        /// Gets the name of the method which calls this method.
        /// </summary>
        /// <returns>The property name.</returns>
        public static string GetPropertyName
        {
            get
            {
                MethodBase methodName = new StackFrame(1).GetMethod();
                return methodName.Name.Substring(4);
            }
        }
        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="to">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static void SendMail(string to, string from, string cc, string bcc, string subject, string body)
        {
            // Instantiate a new instance of MailMessage
            MailMessage mMailMessage = new MailMessage();

            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(from);
            // Set the recepient address of the mail message
            mMailMessage.To.Add(new MailAddress(to));


            // Check if the bcc value is null or an empty string
            if ((bcc != null) && (bcc != string.Empty))
            {
                // Set the Bcc address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(bcc));
            }

            // Check if the cc value is null or an empty value
            if ((cc != null) && (cc != string.Empty))
            {
                // Set the CC address of the mail message
                mMailMessage.CC.Add(new MailAddress(cc));
            }

            // Set the subject of the mail message
            mMailMessage.Subject = subject;
            // Set the body of the mail message
            mMailMessage.Body = body;

            // Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = true;
            // Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal;
            // Instantiate a new instance of SmtpClient
            SmtpClient mSmtpClient = new SmtpClient();
            // Send the mail message
            mSmtpClient.Send(mMailMessage);


        }
    }
}
