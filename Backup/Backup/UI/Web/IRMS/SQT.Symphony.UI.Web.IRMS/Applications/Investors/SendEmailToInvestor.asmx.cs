using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;


namespace SQT.Symphony.UI.Web.IRMS.Applications.Investors
{
    /// <summary>
    /// Summary description for SendEmailToInvestor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SendEmailToInvestor : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string SendMailTo(string EmailAddress, string subjectForEmail, string CompanyIDToPass)
        {
            try
            {
                string EmailSendSucess = "";
                if (EmailAddress != null && EmailAddress != "")
                {
                    Guid? companyID = null;
                    if (Convert.ToString(CompanyIDToPass) != string.Empty && Convert.ToString(CompanyIDToPass) != Guid.Empty.ToString())
                    {
                        companyID = new Guid(CompanyIDToPass);
                    }
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;
                    List<PropertyConfiguration> LstPrtConfig = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.CompanyID, Convert.ToString(companyID));
                    if (LstPrtConfig.Count > 0)
                    {
                        string[] strEmailAddress = EmailAddress.Trim().Split('|');
                        if (strEmailAddress.Length > 0)
                        {
                            foreach (string strEmailAddToEmail in strEmailAddress)
                            {
                                if (strEmailAddToEmail.Trim() != "" && strEmailAddToEmail.Trim() != "|")
                                {
                                    PropertyConfiguration Prj = (PropertyConfiguration)(LstPrtConfig[0]);
                                    //SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), strEmailAddToEmail, "Email To Investor", "<b>Hi Investor This is Test Email<b>");
                                    SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), strEmailAddToEmail, subjectForEmail, "<b>Hi Investor This is Test Email<b>");
                                }

                            }
                            EmailSendSucess = "Email send to selected Investor Successfully.";
                            return EmailSendSucess;
                        }
                        else
                        {
                            EmailSendSucess = "Sorry for inconvenience.";
                            return EmailSendSucess;
                        }
                    }
                    else
                    {
                        EmailSendSucess = "Sorry for inconvenience.";
                        return EmailSendSucess;
                    }
                }
                else
                {
                    EmailSendSucess = "Sorry for inconvenience.";
                    return EmailSendSucess;
                }
            }
            catch (Exception ex)
            {
                string EmailSendSucessForCatch = "Sorry for inconvenience.";
                return EmailSendSucessForCatch;
            }
        }
    }
}
