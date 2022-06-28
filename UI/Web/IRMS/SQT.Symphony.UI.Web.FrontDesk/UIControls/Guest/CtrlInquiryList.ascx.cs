using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using System.Globalization;
using System.IO;


namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlInquiryList : System.Web.UI.UserControl
    {
        #region Property and variable
        public bool IsMessage = false;
        public Guid InqID
        {
            get
            {
                return ViewState["InqID"] != null ? new Guid(Convert.ToString(ViewState["InqID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InqID"] = value;
            }
        }
        public string strGuestEmailAddress
        {
            get
            {
                return ViewState["strGuestEmailAddress"] != null ? Convert.ToString(ViewState["strGuestEmailAddress"]) : string.Empty;
            }
            set
            {
                ViewState["strGuestEmailAddress"] = value;
            }
        }
        #endregion Property and variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calInqGuestarrivalDate.Format = clsSession.DateFormat;
                calSearchInqGuestDeptDate.Format = clsSession.DateFormat;
                BindInquiryList();
            }
        }
        #endregion Page Load

        #region Control Event
        protected void btnUpdateInquiry_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid && this.InqID != null && this.InqID != Guid.Empty)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    DateTime? dtStartDate = null;
                    DateTime? dtEndDate = null;
                    if (!rblEditInquiryStatus.SelectedValue.Equals("Email Database") && rblEditInquiryStatus.SelectedIndex != 2)
                    {
                        dtEndDate = DateTime.ParseExact(txtEditInqDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo).Date;
                        dtStartDate = DateTime.ParseExact(txtEditInqArrivalDate.Text.Trim(), clsSession.DateFormat, objCultureInfo).Date;
                        if (dtEndDate <= dtStartDate)
                        {
                            litDateValidationmsg.Visible = true;
                            mpeEditInquiryData.Show();
                            return;
                        }
                        else
                        {
                            litDateValidationmsg.Visible = false;
                        }
                    }
                    else
                    {
                        dtStartDate = null;
                        dtEndDate = null;
                    }
                    Inquiry objInquiryToUpdate = new Inquiry();
                    objInquiryToUpdate = InquiryBLL.GetByPrimaryKey(this.InqID);

                    Inquiry objInquiryoldToUpdate = new Inquiry();
                    objInquiryoldToUpdate = InquiryBLL.GetByPrimaryKey(this.InqID);

                    objInquiryToUpdate.CompanyID = clsSession.CompanyID;
                    objInquiryToUpdate.PropertyID = clsSession.PropertyID;
                    objInquiryToUpdate.UpdatedOn = DateTime.Now;
                    objInquiryToUpdate.UpdatedBy = clsSession.UserID;

                    if (txtEditInqArrivalDate.Text != null && txtEditInqArrivalDate.Text != "")
                        objInquiryToUpdate.ArrivalDate = DateTime.ParseExact(txtEditInqArrivalDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    else
                        objInquiryToUpdate.ArrivalDate = null;


                    if (txtEditInqDeptDate.Text != null && txtEditInqDeptDate.Text != "")
                        objInquiryToUpdate.DepartureDate = DateTime.ParseExact(txtEditInqDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    else
                        objInquiryToUpdate.DepartureDate = null;


                    if (ddlEditInqGuestTitle.SelectedIndex != 0)
                        objInquiryToUpdate.Title = Convert.ToString(ddlEditInqGuestTitle.SelectedItem.Text);
                    else
                        objInquiryToUpdate.Title = null;

                    if (ddlMarketingValueStatus.SelectedIndex != 0)
                        objInquiryToUpdate.EmailDatabase_TermID = new Guid(ddlMarketingValueStatus.SelectedValue);
                    else
                        objInquiryToUpdate.EmailDatabase_TermID = null;

                    objInquiryToUpdate.FName = clsCommon.GetUpperCaseText(Convert.ToString(txtEditInqGuestFirstName.Text.Trim()));
                    objInquiryToUpdate.LName = clsCommon.GetUpperCaseText(Convert.ToString(txtEditInqGuestLastName.Text.Trim()));


                    if (txtEditInqGuestEmail.Text != null && txtEditInqGuestEmail.Text != "")
                        objInquiryToUpdate.Email = clsCommon.GetUpperCaseText(Convert.ToString(txtEditInqGuestEmail.Text.Trim()));
                    else
                        objInquiryToUpdate.Email = null;

                    objInquiryToUpdate.GuestFullName = clsCommon.GetUpperCaseText(Convert.ToString(ddlEditInqGuestTitle.SelectedItem.Text) + " " + txtEditInqGuestFirstName.Text.Trim() + " " + txtEditInqGuestLastName.Text.Trim());

                    if (txtEditInqGuestCompanyName.Text != null && txtEditInqGuestCompanyName.Text != "")
                        objInquiryToUpdate.Company_Name = clsCommon.GetUpperCaseText(Convert.ToString(txtEditInqGuestCompanyName.Text.Trim()));
                    else
                        objInquiryToUpdate.Company_Name = null;

                    if (txtEditInqGuestCode.Text.Trim() == "")
                        objInquiryToUpdate.Phone = "-" + txtEditInqGuestMobile.Text.Trim();
                    else
                        objInquiryToUpdate.Phone = txtEditInqGuestCode.Text.Trim() + "-" + txtEditInqGuestMobile.Text.Trim();


                    if (rblEditInqGuestGender.SelectedIndex >= 0)
                        objInquiryToUpdate.GenderTermID = new Guid(rblEditInqGuestGender.SelectedValue);
                    else
                        objInquiryToUpdate.GenderTermID = null;


                    if (rblEditInquiryStatus.SelectedValue != null)
                        objInquiryToUpdate.Inq_StatusTerm = rblEditInquiryStatus.SelectedValue;
                    else
                        objInquiryToUpdate.Inq_StatusTerm = null;


                    InquiryBLL.Update(objInquiryToUpdate);
                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objInquiryoldToUpdate.ToString(), objInquiryToUpdate.ToString(), "res_Inquiry", null);
                    ClearInquiryData();
                    mpeEditInquiryData.Hide();
                    ClearSearch();
                    BindInquiryList();
                    IsMessage = true;
                    lblInquiryListMsg.Text = "Data Update Successfully.";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void rblEditInquiryStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblEditInquiryStatus.SelectedIndex == 2 && rblEditInquiryStatus.SelectedValue.Equals("Email Database"))
            {
                trMarketingValue.Visible = true;
                BindMarketingStatusTerm();
                rfvEditInqArrivalDate.Enabled = false;
                rfvEditInqDeptDate.Enabled = false;
                tdArrivalDateEdit.Attributes.Remove("class");
                tdDeptDateEdit.Attributes.Remove("class");
                mpeEditInquiryData.Show();
            }
            else
            {
                ddlMarketingValueStatus.Items.Clear();
                trMarketingValue.Visible = false;
                rfvEditInqArrivalDate.Enabled = true;
                rfvEditInqDeptDate.Enabled = true;
                rfvEditInqDeptDate.Attributes.Add("class", "isrequire");
                tdArrivalDateEdit.Attributes.Add("class", "isrequire");
                mpeEditInquiryData.Show();
            }
        }
        protected void imtbtnSearchInquiry_Click(object sender, EventArgs e)
        {
            try
            {
                gvInquiryList.PageIndex = 0;
                BindInquiryList();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void btnSendEmailToGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strGuestEmailAddress != null && this.strGuestEmailAddress.Trim() != "" && this.strGuestEmailAddress.Trim() != string.Empty)
                {
                    //SendMailTo(this.strGuestEmailAddress, "Guest email");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void imtbtnSearchClearInquiry_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearch();
                gvInquiryList.PageIndex = 0;
                BindInquiryList();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
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

        private void EditViewData()
        {
            if (this.InqID != Guid.Empty)
            {
                DataSet dsInquiryList = InquiryBLL.GetInquiryList(clsSession.CompanyID, clsSession.PropertyID, null, null, null, null, null, null, this.InqID);
                if (dsInquiryList != null && dsInquiryList.Tables.Count > 0 && dsInquiryList.Tables[0].Rows.Count > 0)
                {
                    DataRow drForEditInqData = dsInquiryList.Tables[0].Rows[0];
                    if (drForEditInqData["ArrivalDate"] != null && Convert.ToString(drForEditInqData["ArrivalDate"]) != "")
                        txtEditInqArrivalDate.Text = Convert.ToDateTime(drForEditInqData["ArrivalDate"]).ToString(clsSession.DateFormat);
                    else
                        txtEditInqArrivalDate.Text = "";

                    if (drForEditInqData["DepartureDate"] != null && Convert.ToString(drForEditInqData["DepartureDate"]) != "")
                        txtEditInqDeptDate.Text = Convert.ToDateTime(drForEditInqData["DepartureDate"]).ToString(clsSession.DateFormat);
                    else
                        txtEditInqDeptDate.Text = "";

                    if (drForEditInqData["CreatedOn"] != null && Convert.ToString(drForEditInqData["CreatedOn"]) != "")
                        lblEditInqCurrentTime.Text = Convert.ToDateTime(drForEditInqData["CreatedOn"]).ToString(clsSession.DateFormat + " hh:mm tt");
                    else
                        lblEditInqCurrentTime.Text = "";

                    lblDispInqCreatedBy.Text = Convert.ToString(drForEditInqData["InqCreatedBy"]);

                   

                    ddlEditInqGuestTitle.SelectedIndex = ddlEditInqGuestTitle.Items.FindByValue(Convert.ToString(drForEditInqData["Title"])) != null ? ddlEditInqGuestTitle.Items.IndexOf(ddlEditInqGuestTitle.Items.FindByValue(Convert.ToString(drForEditInqData["Title"]))) : 0;
                    txtEditInqGuestFirstName.Text = Convert.ToString(drForEditInqData["FName"]);
                    txtEditInqGuestLastName.Text = Convert.ToString(drForEditInqData["LName"]);
                    txtEditInqGuestEmail.Text = Convert.ToString(drForEditInqData["Email"]);
                    txtEditInqGuestCompanyName.Text = Convert.ToString(drForEditInqData["Company_Name"]);
                    if (Convert.ToString(drForEditInqData["Phone"]) != "")
                    {
                        string[] mobileCode = Convert.ToString(drForEditInqData["Phone"]).Split('-');
                        txtEditInqGuestCode.Text = mobileCode[0];
                        txtEditInqGuestMobile.Text = mobileCode[1];
                    }
                    else
                    {
                        txtEditInqGuestCode.Text = "";
                        txtEditInqGuestMobile.Text = "";
                    }

                    if (rblEditInquiryStatus.Items.Count > 0 && Convert.ToString(drForEditInqData["Inq_StatusTerm"]) != "")
                    {
                        rblEditInquiryStatus.SelectedIndex = rblEditInquiryStatus.Items.IndexOf(rblEditInquiryStatus.Items.FindByValue(Convert.ToString(drForEditInqData["Inq_StatusTerm"])));
                        rblEditInquiryStatus_SelectedIndexChanged(null, null);
                    }
                    if (drForEditInqData["EmailDatabase_TermID"] != null && Convert.ToString(drForEditInqData["EmailDatabase_TermID"]) != "")
                    {
                        ddlMarketingValueStatus.SelectedIndex = ddlMarketingValueStatus.Items.FindByValue(Convert.ToString(drForEditInqData["EmailDatabase_TermID"])) != null ? ddlMarketingValueStatus.Items.IndexOf(ddlMarketingValueStatus.Items.FindByValue(Convert.ToString(drForEditInqData["EmailDatabase_TermID"]))) : 0;
                    }
                    if (rblEditInqGuestGender.Items.Count > 0 && Convert.ToString(drForEditInqData["GenderTermID"]) != "")
                    {
                        rblEditInqGuestGender.SelectedIndex = rblEditInqGuestGender.Items.IndexOf(rblEditInqGuestGender.Items.FindByValue(Convert.ToString(drForEditInqData["GenderTermID"])));
                    }
                    calEditEndDate.StartDate = DateTime.Now;
                    calEditInqArrivalDate.StartDate = DateTime.Now;
                }

            }
        }
        private void ClearInquiryData()
        {
            trMarketingValue.Visible = false;
            BindGenderList();
            if (rblEditInqGuestGender.Items.Count > 0 && rblEditInqGuestGender.Items.FindByText("Male") != null)
            {
                rblEditInqGuestGender.Items.FindByText("Male").Selected = true;
            }
            txtEditInqArrivalDate.Text = "";
            txtEditInqDeptDate.Text = "";
            txtEditInqGuestCompanyName.Text = "";
            txtEditInqGuestEmail.Text = "";
            txtEditInqGuestFirstName.Text = "";
            txtEditInqGuestLastName.Text = "";
            txtEditInqGuestMobile.Text = "";
        }
        private void BindGenderList()
        {
            List<ProjectTerm> lstGenders = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GENDER");
            rblEditInqGuestGender.Items.Clear();
            if (lstGenders.Count != 0)
            {
                rblEditInqGuestGender.DataSource = lstGenders;
                rblEditInqGuestGender.DataTextField = "DisplayTerm";
                rblEditInqGuestGender.DataValueField = "TermID";
                rblEditInqGuestGender.DataBind();
            }
        }

        private void ClearSearch()
        {
            ddlSearchInqGuestStatus.SelectedIndex = 0;
            txtSearchInqGuestDeptDate.Text = "";
            txtSearchInqGuestarrivalDate.Text = "";
            txtSearchInqGuestEmail.Text = "";
            txtSearchInqGuestName.Text = "";
            txtSearchInqMobileNo.Text = "";
        }
        private void BindInquiryList()
        {
            try
            {
                string strName = null;
                string strMobileNo = null;
                string strEmail = null;
                string strInqStatus = null;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                Guid? InqID = null;
                DateTime? ArrivalDate = null;
                DateTime? DepartureDate = null;


                if (txtSearchInqGuestarrivalDate.Text.Trim() != "")
                    ArrivalDate = DateTime.ParseExact(txtSearchInqGuestarrivalDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (txtSearchInqGuestDeptDate.Text.Trim() != "")
                    DepartureDate = DateTime.ParseExact(txtSearchInqGuestDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (txtSearchInqGuestName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchInqGuestName.Text.Trim());

                if (txtSearchInqMobileNo.Text.Trim() != "")
                    strMobileNo = Convert.ToString(txtSearchInqMobileNo.Text.Trim());


                if (txtSearchInqGuestEmail.Text.Trim() != "")
                    strEmail = Convert.ToString(txtSearchInqGuestEmail.Text.Trim());


                if (ddlSearchInqGuestStatus.SelectedIndex > 0)
                    strInqStatus = ddlSearchInqGuestStatus.SelectedValue.Trim();


                DataSet dsInquiryList = InquiryBLL.GetInquiryList(clsSession.CompanyID, clsSession.PropertyID, strName, strMobileNo, strEmail, ArrivalDate, DepartureDate, strInqStatus, InqID);

                if (dsInquiryList != null && dsInquiryList.Tables.Count > 0 && dsInquiryList.Tables[0].Rows.Count > 0)
                {
                    gvInquiryList.DataSource = dsInquiryList;
                    gvInquiryList.DataBind();
                }
                else
                {
                    gvInquiryList.DataSource = null;
                    gvInquiryList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void SendMailTo(string EmailAddress, string GuestName, string InqOn, string ArrivalDate, string DepartureDate, string subjectForEmail)
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

                PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);
                if (ObjPrtConfig != null)
                {
                    strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                    strUserName = Convert.ToString(ObjPrtConfig.UserName);
                    strPassword = Convert.ToString(ObjPrtConfig.Password);
                    strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                    return;
                }
                if (File.Exists(Server.MapPath("~/EmailTemplates/SendInquiryEmail.htm")) && strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                {
                    string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/SendInquiryEmail.htm"));
                    strHTML = strHTML.Replace("$GUESTNAME$", GuestName);
                    strHTML = strHTML.Replace("$INQDATE$", InqOn);
                    strHTML = strHTML.Replace("$ARRIVALDATE$", ArrivalDate);
                    strHTML = strHTML.Replace("$DEPARTUREDATE$", DepartureDate);
                    SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, EmailAddress.ToLower(), subjectForEmail, strHTML);
                    IsMessage = true;
                    lblInquiryListMsg.Text = "Email send successfully.";
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
                IsMessage = true;
                lblInquiryListMsg.Text = "This guest has no email, you can't send mail to him";
            }
        }
        #endregion Private Method

        #region Grid Event
        protected void gvInquiryList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("VIEWINQDATA") && e.CommandArgument != null)
                {
                    ClearInquiryData();
                    this.InqID = new Guid(Convert.ToString(e.CommandArgument));
                    trForInqCreatedBy.Visible = true;
                    EditViewData();
                    btnUpdateInquiry.Visible = false;
                    mpeEditInquiryData.Show();
                }
                else if (e.CommandName.ToUpper().Equals("EDITINQDATA") && e.CommandArgument != null)
                {
                    ClearInquiryData();
                    this.InqID = new Guid(Convert.ToString(e.CommandArgument));
                    EditViewData();
                    btnUpdateInquiry.Visible = true;
                    mpeEditInquiryData.Show();
                    trForInqCreatedBy.Visible = false;
                }
                else if (e.CommandName.ToUpper().Equals("MAKERESERVATION") && e.CommandArgument != null)
                {
                    Response.Redirect("~/GUI/Reservation/Reservation.aspx?InqID=" + Convert.ToString(e.CommandArgument));
                }
                else if (e.CommandName.ToUpper().Equals("SENDEMAILTOGUEST") && Convert.ToString(e.CommandArgument) != "")
                {
                    Inquiry objInqData = new Inquiry();
                    objInqData = InquiryBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    string InqOnToPass = string.Empty;
                    string ArrivalDateToPass = string.Empty;
                    string DepartureDateToPass = string.Empty;
                    if (objInqData != null)
                    {
                        if (objInqData.CreatedOn != null && Convert.ToString(objInqData.CreatedOn) != "")
                            InqOnToPass = Convert.ToDateTime(objInqData.CreatedOn).ToString(clsSession.DateFormat);

                        if (objInqData.ArrivalDate != null && Convert.ToString(objInqData.ArrivalDate) != "")
                            ArrivalDateToPass = Convert.ToDateTime(objInqData.ArrivalDate).ToString(clsSession.DateFormat);

                        if (objInqData.DepartureDate != null && Convert.ToString(objInqData.DepartureDate) != "")
                            DepartureDateToPass = Convert.ToDateTime(objInqData.DepartureDate).ToString(clsSession.DateFormat);

                    }

                    SendMailTo(Convert.ToString(objInqData.Email), Convert.ToString(objInqData.GuestFullName), InqOnToPass, ArrivalDateToPass, DepartureDateToPass, "Your Uniworld reservatoin inquiry");

                    // mpeSendEmailToGuest.Show();
                }
                else
                {
                    trForInqCreatedBy.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvInquiryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvInqArrivalDate = (Label)e.Row.FindControl("lblGvInqArrivalDate");
                    if (DataBinder.Eval(e.Row.DataItem, "ArrivalDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ArrivalDate")) != "")
                    {
                        lblGvInqArrivalDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ArrivalDate")).ToString(clsSession.DateFormat);
                    }
                    else
                    {
                        lblGvInqArrivalDate.Text = "";
                    }

                    Label lblGvInqDeptlDate = (Label)e.Row.FindControl("lblGvInqDeptlDate");
                    if (DataBinder.Eval(e.Row.DataItem, "DepartureDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DepartureDate")) != "")
                    {
                        lblGvInqDeptlDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DepartureDate")).ToString(clsSession.DateFormat);
                    }
                    else
                    {
                        lblGvInqDeptlDate.Text = "";
                    }
                    Label lblGvInqCreatedDate = (Label)e.Row.FindControl("lblGvInqCreatedDate");
                    if (DataBinder.Eval(e.Row.DataItem, "CreatedOn") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CreatedOn")) != "")
                    {
                        lblGvInqCreatedDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CreatedOn")).ToString(clsSession.DateFormat);
                    }
                    else
                    {
                        lblGvInqCreatedDate.Text = "";
                    }
                    LinkButton lnkMakeReservationFromInq = (LinkButton)e.Row.FindControl("lnkMakeReservationFromInq");
                    LinkButton lnkSendEmailToGuest = (LinkButton)e.Row.FindControl("lnkSendEmailToGuest");
                    DateTime? dtArrivalDate = null;
                    if (DataBinder.Eval(e.Row.DataItem, "Inq_StatusTerm") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Inq_StatusTerm")) != "" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Inq_StatusTerm")).ToUpper().Equals("EMAIL DATABASE"))
                    {
                        lnkMakeReservationFromInq.Visible = false;
                        lnkSendEmailToGuest.Visible = false;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "ArrivalDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ArrivalDate")) != "")
                    {
                        dtArrivalDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ArrivalDate")).Date;
                        DateTime dtCurrentTime = DateTime.Now.Date;
                        if (dtArrivalDate < dtCurrentTime)
                        {
                            lnkMakeReservationFromInq.Visible = false;
                        }
                        else
                        {
                            lnkMakeReservationFromInq.Visible = true;
                        }
                        if (dtArrivalDate >= dtCurrentTime && DataBinder.Eval(e.Row.DataItem, "Inq_StatusTerm") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Inq_StatusTerm")) != "" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Inq_StatusTerm")).ToUpper().Equals("WAIT LIST"))
                        {
                            lnkSendEmailToGuest.Visible = true;
                        }
                        else
                        {
                            lnkSendEmailToGuest.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvInquiryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInquiryList.PageIndex = e.NewPageIndex;
            BindInquiryList();
        }
        #endregion Grid Event


    }
}