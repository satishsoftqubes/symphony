using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlSendEmailToGuest : System.Web.UI.UserControl
    {
        #region Property and Variable
        public bool IsMessage = false;
        public bool IsToShowMarketingStatus = false;
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvSendEmailCategory.ActiveViewIndex = 0;
                IsToShowMarketingStatus = false;
                chkAllGuest_CheckChanged(null, null);
            }

        }
        #endregion Page Load

        #region Control Event
        protected void btnBackToListEmail_Click(object sender, EventArgs e)
        {
            mvSendEmailCategory.ActiveViewIndex = 0;
        }
        protected void lnkSendEmailTomarketing_Click(object sender, EventArgs e)
        {
            BindMarketingStatusTerm();
            mvSendEmailCategory.ActiveViewIndex = 1;
        }
        protected void btnSendEmailToMarketing_Click(object sender, EventArgs e)
        {
            if (ddlMarketingValueStatus.SelectedIndex != 0 && txtEmailSubjectForMarketing.Text != "" && CKEMarketingPeoplebody.Text != "")
            {
                DataSet dsForSendEmailToMarketingPeople = InquiryBLL.GetAllByWithDataSet(BusinessLogic.FrontDesk.DTO.Inquiry.InquiryFields.EmailDatabase_TermID, Convert.ToString(ddlMarketingValueStatus.SelectedValue));
                if (dsForSendEmailToMarketingPeople != null && dsForSendEmailToMarketingPeople.Tables.Count > 0 && dsForSendEmailToMarketingPeople.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drsendEmaiLToGuestList in dsForSendEmailToMarketingPeople.Tables[0].Rows)
                    {
                        SendMailTo(Convert.ToString(drsendEmaiLToGuestList["Email"]).Trim().ToLower(), txtEmailSubjectForMarketing.Text.Trim(), true);
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    IsMessage = true;
                    lblInquiryListMsg.Text = "Email sent successfully.";
                }
                else
                {
                    MessageBox.Show("No Record Found to send Email");
                    return;
                }
            }
        }
        protected void btnSendEmailToGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid && txtEmailSubject.Text != "" && ckEmailSendToGuest.Text != null && ckEmailSendToGuest.Text != "")
                {
                    string strInquiryStatusForEmailDB = "";
                    string strInquiryStatusForwaitlist = "";
                    string strInquiryStatusForInquiry = "";
                    bool IsToTakeCheckInGuestOnly = false;
                    bool IsToTakeCheckOutGuestOnly = false;
                    bool IsToTakeAllGuest = false;

                    if (chkAllGuest.Checked)
                        IsToTakeAllGuest = true;
                    else
                        IsToTakeAllGuest = true;

                    if (chkCheckInGuest.Checked)
                        IsToTakeCheckInGuestOnly = true;
                    else
                        IsToTakeCheckInGuestOnly = false;

                    if (chkCheckOutGuest.Checked)
                        IsToTakeCheckOutGuestOnly = true;
                    else
                        IsToTakeCheckOutGuestOnly = false;

                    if (chkEmailDbList.Checked)
                        strInquiryStatusForEmailDB = "Email Database";
                    else
                        strInquiryStatusForEmailDB = null;

                    if (chkInquiryOnly.Checked)
                        strInquiryStatusForInquiry = "Inquiry";
                    else
                        strInquiryStatusForInquiry = null;

                    if (chkInvestorOnly.Checked)
                    {
                        SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();
                        DataSet ds = clnt.GetInvestorEmailAddress();
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drsendEmaiLToInvList in ds.Tables[0].Rows)
                            {
                                SendMailTo(Convert.ToString(drsendEmaiLToInvList["Email"]).Trim().ToLower(), "Email send To Investors", false);
                            }
                        }
                    }
                    if (chkWaitListGuest.Checked)
                        strInquiryStatusForwaitlist = "Wait List";
                    else
                        strInquiryStatusForwaitlist = null;

                    DataSet dsForsendEmaiLToGuestList = GuestBLL.GetGuestEmailAddressForSendEmail(clsSession.CompanyID, clsSession.PropertyID, strInquiryStatusForEmailDB, strInquiryStatusForwaitlist, strInquiryStatusForInquiry, IsToTakeCheckInGuestOnly, IsToTakeCheckOutGuestOnly, IsToTakeAllGuest);
                    if (dsForsendEmaiLToGuestList != null && dsForsendEmaiLToGuestList.Tables.Count > 0 && dsForsendEmaiLToGuestList.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drsendEmaiLToGuestList in dsForsendEmaiLToGuestList.Tables[0].Rows)
                        {
                            SendMailTo(Convert.ToString(drsendEmaiLToGuestList["Email"]).Trim().ToLower(), txtEmailSubject.Text.Trim(), false);
                        }
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    IsMessage = true;
                    lblInquiryListMsg.Text = "Email sent successfully.";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void chkAllGuest_CheckChanged(object sender, EventArgs e)
        {
            if (chkAllGuest.Checked)
            {
                chkCheckInGuest.Checked = true;
                chkCheckOutGuest.Checked = true;
                chkEmailDbList.Checked = true;
                chkInquiryOnly.Checked = true;
                chkInvestorOnly.Checked = true;
                chkWaitListGuest.Checked = true;
            }
            else
            {
                chkCheckInGuest.Checked = false;
                chkCheckOutGuest.Checked = false;
                chkEmailDbList.Checked = false;
                chkInquiryOnly.Checked = false;
                chkInvestorOnly.Checked = false;
                chkWaitListGuest.Checked = false;
            }

        }
        #endregion Control Event

        #region Private Method
        private void BindMarketingStatusTerm()
        {
            List<ProjectTerm> lstMarketingStatusTerm = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "Email Database Type");
            ddlMarketingValueStatus.Items.Clear();
            if (lstMarketingStatusTerm.Count != 0)
            {
                ddlMarketingValueStatus.DataSource = lstMarketingStatusTerm;
                ddlMarketingValueStatus.DataTextField = "DisplayTerm";
                ddlMarketingValueStatus.DataValueField = "TermID";
                ddlMarketingValueStatus.DataBind();
                ddlMarketingValueStatus.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlMarketingValueStatus.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }
        public void SendMailTo(string EmailAddress, string subjectForEmail, bool IsForMarketingpeople)
        {
            if (EmailAddress != null && EmailAddress != "")
            {
                Guid? companyID = null;
                Guid? propertyID = null;
                if (Convert.ToString(clsSession.CompanyID) != string.Empty && clsSession.CompanyID != Guid.Empty)
                {
                    companyID = clsSession.CompanyID;
                }
                if (Convert.ToString(clsSession.PropertyID) != string.Empty && Convert.ToString(clsSession.PropertyID) != Guid.Empty.ToString())
                {
                    propertyID = clsSession.PropertyID;
                }
                else
                {
                    //Company Administrator has no PropertyID, So to use default property's ids.
                    propertyID = new Guid("BBB0707B-AB26-4B6D-A5B5-C33B4A774ABC");
                    companyID = new Guid("AAA0707A-2C6A-4C39-896C-B3025CF8BD16");
                }
                string strPrimoryDomainName = string.Empty;
                string strUserName = string.Empty;
                string strPassword = string.Empty;
                string strSmtpAddress = string.Empty;

                if (IsForMarketingpeople)
                {
                    DataSet dsForMarketingPeopleEmailConfig = InquiryBLL.GetEmailConfigSelectForMarketingEmail();
                    if (dsForMarketingPeopleEmailConfig != null && dsForMarketingPeopleEmailConfig.Tables.Count > 0 && dsForMarketingPeopleEmailConfig.Tables[0].Rows.Count > 0)
                    {
                        DataRow drForEmailConfig = dsForMarketingPeopleEmailConfig.Tables[0].Rows[0];
                        strPrimoryDomainName = Convert.ToString(drForEmailConfig["PrimoryDomainName"]);
                        strUserName = Convert.ToString(drForEmailConfig["UserName"]);
                        strPassword = Convert.ToString(drForEmailConfig["Password"]);
                        strSmtpAddress = Convert.ToString(drForEmailConfig["SMTPHost"]);
                        SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, EmailAddress.ToLower(), subjectForEmail, CKEMarketingPeoplebody.Text.Trim());

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                        return;
                    }
                }
                else
                {
                    PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);
                    if (ObjPrtConfig != null)
                    {
                        strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                        strUserName = Convert.ToString(ObjPrtConfig.UserName);
                        strPassword = Convert.ToString(ObjPrtConfig.Password);
                        strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, EmailAddress.ToLower(), subjectForEmail, ckEmailSendToGuest.Text.Trim());
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                        return;
                    }
                }
            }
            else
            {
                IsMessage = true;
                lblInquiryListMsg.Text = "This guest has no email, you can't send mail to him";
            }
        }
        #endregion Private Method
    }
}