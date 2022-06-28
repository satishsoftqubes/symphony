using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Property
{
    public partial class CtrlCompanySetup : System.Web.UI.UserControl
    {
        #region Property and Variables
        //Property to save CompanyID
        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }
        public Guid UserID
        {
            get
            {
                return ViewState["UserID"] != null ? new Guid(Convert.ToString(ViewState["UserID"])) : Guid.Empty;
            }
            set
            {
                ViewState["UserID"] = value;
            }
        }
        public bool IsMessage = false;
        #endregion Property and Variables

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                //    Response.Redirect("~/GUI/AccessDenied.aspx");
                try
                {
                    BindData();

                    //If CompanyID in session, then Load company data.
                    if (Convert.ToString(clsSession.ToEditItemType) == "COMPANY" && clsSession.ToEditItemID != Guid.Empty)
                    {
                        LoadCompanyInfo();
                    }
                    else
                    {
                        gvDocument.DataSource = null;
                        gvDocument.DataBind();
                    }

                    BindBreadCrumb();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion Form Load

        #region Private Method

        //To Change after access is given.
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("CompanySetup.aspx", clsSession.UserID);
            if (DV.Count > 0)
            {
                if (Convert.ToBoolean(DV[0]["IsDelete"]) == true)
                    btnSave.Enabled = true;
                else if (Convert.ToBoolean(DV[0]["IsUpdate"]) == true)
                    btnSave.Enabled = true;
                else if (Convert.ToBoolean(DV[0]["IsCreate"]) == true)
                    btnSave.Enabled = true;
                else if (Convert.ToBoolean(DV[0]["IsView"]) == true)
                    btnSave.Enabled = false;
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        //Method to Bind default data.
        private void BindData()
        {
            try
            {
                SetPageLables();
                SetAddressControlValidation();
                BindDDL();
                //BindCompanyDocumentGrid();                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetAddressControlValidation()
        {
            List<PropertyConfiguration> lstProConfigs = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, clsSession.PropertyID.ToString());
            if (lstProConfigs != null && lstProConfigs.Count > 0)
            {
                ucOfficeAddress.rfvAddress.Enabled = ucOfficeAddress.rfvCity.Enabled = ucOfficeAddress.rfvState.Enabled = ucOfficeAddress.rfvCountry.Enabled = false;
                ucOfficeAddress.rfvZipCode.Enabled = false;

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipAddress))
                {
                    ucRegisteredAddress.tcAddress.Attributes.Add("class", "isrequire");
                    ucRegisteredAddress.tcCity.Attributes.Add("class", "isrequire");
                    ucRegisteredAddress.tcState.Attributes.Add("class", "isrequire");
                    ucRegisteredAddress.tcCountry.Attributes.Add("class", "isrequire");
                }

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipPostCode))
                {
                    ucRegisteredAddress.tcZipcode.Attributes.Add("class", "isrequire");
                }

                ucRegisteredAddress.rfvAddress.Enabled = ucRegisteredAddress.rfvCity.Enabled = ucRegisteredAddress.rfvState.Enabled = ucRegisteredAddress.rfvCountry.Enabled = !Convert.ToBoolean(lstProConfigs[0].IsSkipAddress);
                ucRegisteredAddress.rfvZipCode.Enabled = !Convert.ToBoolean(lstProConfigs[0].IsSkipPostCode);
            }
            else
            {
                ucOfficeAddress.rfvAddress.Enabled = ucOfficeAddress.rfvCity.Enabled = ucOfficeAddress.rfvState.Enabled = ucOfficeAddress.rfvCountry.Enabled = false;
                ucOfficeAddress.rfvZipCode.Enabled = false;

                ucRegisteredAddress.tcAddress.Attributes.Add("class", "isrequire");
                ucRegisteredAddress.tcCity.Attributes.Add("class", "isrequire");
                ucRegisteredAddress.tcState.Attributes.Add("class", "isrequire");
                ucRegisteredAddress.tcCountry.Attributes.Add("class", "isrequire");
                ucRegisteredAddress.tcZipcode.Attributes.Add("class", "isrequire");
            }
        }

        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblMainHeader", "COMPANY SETUP");
            ltrCompanyName.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblCompanyName", "Company Name");
            ltrDisplayName.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblDisplayName", "Display Name");
            ltrCompanyCode.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblCompanyCode", "Company Code");
            ltrCompanyType.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblCompanyType", "Company Type");
            ltrBusinessDomain.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblBusinessDomain", "Business Domain");
            ltrContactNo.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblContactNo", "Contact No");
            ltrEmail.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblEmail", "Email");
            ltrFax.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblFax", "Fax");
            ltrURL.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblURL", "URL");
            ltrHeaderAddressInfo.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblHeaderAddressInformation", "Address");
            ltrHeaderStatutoryRegistration.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblHeaderStatutoryRegistration", "Statutory Registration");
            ltrStatutoryList.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblStatutoryList", "Statutory List");
            ltrHeaderCompanyLogo.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblHeaderCompanyLogo", "Image / Company Logo");
            ltrSelectLogo.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblCompanyLogo", "Select Logo");
            lnkRemoveLogo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnRemove", "Remove");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            fuCompanyLogo.ToolTip = clsCommon.GetGlobalResourceText("CompanySetup", "lblPhotoUploadTooltip", ".jpg|.JPG|.jpeg|.JPEG|.png|.PNG|gif|GIF|.bmp|.BMP");
            litHeaderBillingDetails.Text = clsCommon.GetGlobalResourceText("CompanySetup", "litHeaderBillingDetails", "Billing details");
            ucRegisteredAddress.strLtrAddress = clsCommon.GetGlobalResourceText("CompanySetup", "lblRegisteredAddress", "Registered Office");
            ucOfficeAddress.strLtrAddress = clsCommon.GetGlobalResourceText("CompanySetup", "lblOfficeAddress", "Admin Office");
            litCreditlimit.Text = clsCommon.GetGlobalResourceText("CompanySetup", "litCreditlimit", "Credit Limit");
            litBillSettlementDays.Text = clsCommon.GetGlobalResourceText("CompanySetup", "litBillSettlementDays", "Bill Settlement Days");
            litBillingFrequencyDays.Text = clsCommon.GetGlobalResourceText("CompanySetup", "litBillingFrequencyDays", "Billing Frequency Days");

            chkAsPermanenetAddress.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblAsPermanenetAddress", "Same as Registered Address");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }

        //Method to bind Dropdownlist
        private void BindDDL()
        {
            //Bind Business domain ddl.
            List<ProjectTerm> lstProjectTermBD = null;
            ProjectTerm objProjectTermBD = new ProjectTerm();
            objProjectTermBD.IsActive = true;
            objProjectTermBD.Category = "BUSDOM";

            lstProjectTermBD = ProjectTermBLL.GetAll(objProjectTermBD);

            if (lstProjectTermBD != null && lstProjectTermBD.Count != 0)
            {
                ddlBusinessDomain.DataSource = lstProjectTermBD;
                ddlBusinessDomain.DataTextField = "DisplayTerm";
                ddlBusinessDomain.DataValueField = "DisplayTerm";
                ddlBusinessDomain.DataBind();
                ddlBusinessDomain.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlBusinessDomain.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


            //Bind Company type ddl.
            List<ProjectTerm> lstProjectTermCT = null;
            ProjectTerm objProjectTermCT = new ProjectTerm();
            objProjectTermCT.IsActive = true;
            objProjectTermCT.Category = "CompanyType";

            lstProjectTermCT = ProjectTermBLL.GetAll(objProjectTermCT);

            if (lstProjectTermCT != null && lstProjectTermCT.Count != 0)
            {
                ddlTypeOfCompany.DataSource = lstProjectTermCT;
                ddlTypeOfCompany.DataTextField = "DisplayTerm";
                ddlTypeOfCompany.DataValueField = "TermID";
                ddlTypeOfCompany.DataBind();
                ddlTypeOfCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlTypeOfCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        //Method to bind Company Document Grid.
        private void BindCompanyDocumentGrid()
        {
            DataSet dsDocumentList = DocumentsBLL.GetDocumentGrid(null, null, clsSession.CompanyID, "COMPANY DOCUMENT", null);

            if (dsDocumentList != null && dsDocumentList.Tables[0].Rows.Count != 0)
            {
                gvDocument.DataSource = dsDocumentList;
                gvDocument.DataBind();
            }
            else
            {
                gvDocument.DataSource = null;
                gvDocument.DataBind();
            }
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblGeneralSettings", "General Settings");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = "Company List";
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);

                if (txtCompanyName.Text.Trim() != string.Empty)
                    clsSession.CompanyName = txtCompanyName.Text.Trim();

                DataRow dr1 = dt.NewRow();
                dr1["NameColumn"] = txtCompanyName.Text.Trim() == string.Empty ? "Company" : txtCompanyName.Text.Trim();
                dr1["Link"] = "";
                dt.Rows.Add(dr1);
            }
            else if (clsSession.UserType.ToUpper() == "ADMINISTRATOR")
            {

                DataRow dr1 = dt.NewRow();
                dr1["NameColumn"] = txtCompanyName.Text.Trim();
                dr1["Link"] = "";
                dt.Rows.Add(dr1);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        //Method to load company Information.
        private void LoadCompanyInfo()
        {
            this.CompanyID = clsSession.ToEditItemID;

            Company objToLoadData = CompanyBLL.GetByPrimaryKey(this.CompanyID);

            if (objToLoadData != null)
            {
                List<User> lstUsers = UserBLL.GetAllBy(User.UserFields.UserName, Convert.ToString(objToLoadData.PrimoryEmailAddress));
                if (lstUsers != null && lstUsers.Count > 0)
                    this.UserID = lstUsers[0].UsearID;

                txtCompanyName.Text = Convert.ToString(objToLoadData.CompanyName);
                txtDisplayName.Text = Convert.ToString(objToLoadData.DisplayName);
                txtCompanyCode.Text = Convert.ToString(objToLoadData.CompanyCode);

                ddlBusinessDomain.SelectedIndex = ddlBusinessDomain.Items.FindByValue(Convert.ToString(objToLoadData.BusinessDomain)) != null ? ddlBusinessDomain.Items.IndexOf(ddlBusinessDomain.Items.FindByValue(Convert.ToString(objToLoadData.BusinessDomain))) : 0;
                ddlTypeOfCompany.SelectedIndex = ddlTypeOfCompany.Items.FindByValue(Convert.ToString(objToLoadData.CompanyType)) != null ? ddlTypeOfCompany.Items.IndexOf(ddlTypeOfCompany.Items.FindByValue(Convert.ToString(objToLoadData.CompanyType))) : 0;

                txtPhoneNo.Text = Convert.ToString(objToLoadData.PrimoryContactNo);
                txtEmail.Text = Convert.ToString(objToLoadData.PrimoryEmailAddress);
                txtFax.Text = Convert.ToString(objToLoadData.PrimaryFax);
                txtURL.Text = Convert.ToString(objToLoadData.PrimaryUrl);

                ucRegisteredAddress.strAddress = Convert.ToString(objToLoadData.PrimaryAdd1);
                ucRegisteredAddress.strCity = Convert.ToString(objToLoadData.PrimaryCity);
                ucRegisteredAddress.strState = Convert.ToString(objToLoadData.PrimaryState);
                ucRegisteredAddress.strCountry = Convert.ToString(objToLoadData.PrimaryCountry);
                ucRegisteredAddress.strZipCode = Convert.ToString(objToLoadData.PrimaryZipCode);

                //To Get record in DataSet with city,state,country name.
                Address objAdrsToGetList = new Address();
                objAdrsToGetList.AddressID = (Guid)objToLoadData.PrimaryAddID;
                objAdrsToGetList.IsActive = true;
                DataSet dsOfficeAddress = AddressBLL.GetAllWithDataSet(objAdrsToGetList);

                if (dsOfficeAddress != null && dsOfficeAddress.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsOfficeAddress.Tables[0].Rows[0];
                    ucOfficeAddress.strAddress = Convert.ToString(dr["Add1"]);
                    ucOfficeAddress.strCity = Convert.ToString(dr["CityName"]);
                    ucOfficeAddress.strState = Convert.ToString(dr["StateName"]);
                    ucOfficeAddress.strCountry = Convert.ToString(dr["CountryName"]);
                    ucOfficeAddress.strZipCode = Convert.ToString(dr["ZipCode"]);
                }

                if (objToLoadData.Thumb.ToUpper().Trim() == "BLANKPHOTO.JPG")
                {
                    imgCompany.ImageUrl = "~/images/BlankPhoto.jpg";
                    lnkRemoveLogo.Visible = false;
                }
                else
                {
                    imgCompany.ImageUrl = "~/CompanyDocuments/" + objToLoadData.CompanyID.ToString() + "/Logo/" + Convert.ToString(objToLoadData.Thumb);
                    lnkRemoveLogo.Visible = true;
                }

                DataSet dsDocumentList = DocumentsBLL.GetDocumentGrid(null, null, objToLoadData.CompanyID, "COMPANY DOCUMENT", objToLoadData.CompanyID);
                if (dsDocumentList != null && dsDocumentList.Tables[0].Rows.Count != 0)
                {
                    gvDocument.DataSource = dsDocumentList.Tables[0];
                    gvDocument.DataBind();
                }
            }
            else
            {
                imgCompany.ImageUrl = "~/images/BlankPhoto.jpg";
                lnkRemoveLogo.Visible = false;
            }
        }

        /// <summary>
        /// Send Email To Company Admin
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void SendEmail(string FullName, string UserName, string Password)
        {
            try
            {
                DataSet dsSearchEmailTemplate = SQT.Symphony.BusinessLogic.Configuration.BLL.EMailTemplatesBLL.GetDataByProperty(new Guid("BBB0707B-AB26-4B6D-A5B5-C33B4A774ABC"), new Guid("AAA0707A-2C6A-4C39-896C-B3025CF8BD16"), "Company Administrator Email Notification");

                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(new Guid("AAA0707A-2C6A-4C39-896C-B3025CF8BD16"), new Guid("BBB0707B-AB26-4B6D-A5B5-C33B4A774ABC"));

                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        string strHTML = Convert.ToString(dsSearchEmailTemplate.Tables[0].Rows[0]["Body"]);
                        strHTML = strHTML.Replace("$FULLNAME$", FullName);
                        strHTML = strHTML.Replace("$USERNAME$", UserName);
                        strHTML = strHTML.Replace("$PASSWORD$", Password);
                        strHTML = strHTML.Replace("$HOTELCODE$", "NA");

                        SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, UserName, clsCommon.GetGlobalResourceText("CommonMessage", "lblEmailChangeEmailSubject", "Email Change Notification"), strHTML);
                    }
                    else
                        MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
                }
                else
                    MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
            }
        }
        #endregion Private Method

        #region Control Event

        //Click event of Cancel button.
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSession.UserType.ToUpper() == "SUPERADMIN")
                    Response.Redirect("~/GUI/Property/CompanyList.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Click event of Save button.
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<User> lstUsers = UserBLL.GetAllBy(User.UserFields.UserName, Convert.ToString(txtEmail.Text.Trim()));
                    if (lstUsers != null && lstUsers.Count > 0)
                    {
                        if (this.CompanyID != Guid.Empty)
                        {
                            if (lstUsers[0].UsearID != this.UserID)
                            {
                                //Duplicate User Exists.
                                IsMessage = true;
                                litSuccessfully.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblMsgDuplicateEmail", "Record with same email already exists.");
                                return;
                            }
                        }
                        else
                        {
                            //Duplicate User Exists.
                            IsMessage = true;
                            litSuccessfully.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblMsgDuplicateEmail", "Record with same email already exists.");
                            return;
                        }
                    }

                    List<Documents> lstDocuments = new List<Documents>();
                    if (this.CompanyID != Guid.Empty)
                    {
                        //Edit mode.

                        //Object declaration
                        Company objToUpdate = CompanyBLL.GetByPrimaryKey(clsSession.CompanyID);
                        Company objOldToUpdate = CompanyBLL.GetByPrimaryKey(clsSession.CompanyID);
                        Address objOfficeAddressToUpdate = null;
                        Address objOldOfficeAddressToUpdate = null;

                        objToUpdate.CompanyName = txtCompanyName.Text.Trim();
                        objToUpdate.DisplayName = txtDisplayName.Text.Trim();
                        objToUpdate.CompanyCode = txtCompanyCode.Text.Trim();

                        if (ddlBusinessDomain.SelectedIndex != 0)
                            objToUpdate.BusinessDomain = ddlBusinessDomain.SelectedValue;
                        else
                            objToUpdate.BusinessDomain = null;

                        if (ddlTypeOfCompany.SelectedIndex != 0)
                            objToUpdate.CompanyType = new Guid(ddlTypeOfCompany.SelectedValue);
                        else
                            objToUpdate.CompanyType = null;

                        objToUpdate.PrimoryContactNo = txtPhoneNo.Text.Trim();
                        objToUpdate.PrimoryEmailAddress = txtEmail.Text.Trim();
                        objToUpdate.PrimaryFax = txtFax.Text.Trim();
                        objToUpdate.PrimaryUrl = txtURL.Text.Trim();

                        objToUpdate.PrimaryAdd1 = ucRegisteredAddress.strAddress.Trim();
                        objToUpdate.PrimaryCity = ucRegisteredAddress.strCity.Trim();
                        objToUpdate.PrimaryState = ucRegisteredAddress.strState.Trim();
                        objToUpdate.PrimaryCountry = ucRegisteredAddress.strCountry.Trim();
                        objToUpdate.PrimaryZipCode = ucRegisteredAddress.strZipCode.Trim();

                        objOfficeAddressToUpdate = AddressBLL.GetByPrimaryKey((Guid)objToUpdate.PrimaryAddID);
                        objOldOfficeAddressToUpdate = AddressBLL.GetByPrimaryKey((Guid)objToUpdate.PrimaryAddID);

                        objOfficeAddressToUpdate.Add1 = ucOfficeAddress.strAddress;
                        objOfficeAddressToUpdate.CityID = clsCommon.City(ucOfficeAddress.strCity);
                        objOfficeAddressToUpdate.StateID = clsCommon.State(ucOfficeAddress.strState);
                        objOfficeAddressToUpdate.CountryID = clsCommon.Country(ucOfficeAddress.strCountry);
                        objOfficeAddressToUpdate.ZipCode = ucOfficeAddress.strZipCode;

                        //Path to create directory for document and logo based on company.
                        string strCompDocsDirPath = Server.MapPath("~/CompanyDocuments");
                        string strCompDirPath = Server.MapPath("~/CompanyDocuments/" + objToUpdate.CompanyID.ToString());
                        string strCompDocsPath = Server.MapPath("~/CompanyDocuments/" + objToUpdate.CompanyID.ToString() + "/Documents");
                        string strCompLogoDirPath = Server.MapPath("~/CompanyDocuments/" + objToUpdate.CompanyID.ToString() + "/Logo");

                        if (!Directory.Exists(strCompDocsDirPath))
                            Directory.CreateDirectory(strCompDocsDirPath);

                        if (!Directory.Exists(strCompDirPath))
                            Directory.CreateDirectory(strCompDirPath);

                        if (!Directory.Exists(strCompDocsPath))
                            Directory.CreateDirectory(strCompDocsPath);

                        if (!Directory.Exists(strCompLogoDirPath))
                            Directory.CreateDirectory(strCompLogoDirPath);

                        //Add document in list object.
                        bool blAnyChangeInCompanyDocs = false;
                        for (int i = 0; i < gvDocument.Rows.Count; i++)
                        {
                            TextBox txtStatutoryName = (TextBox)gvDocument.Rows[i].FindControl("txtStatutoryName");
                            FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");
                            HiddenField hdnDocumentName = (HiddenField)gvDocument.Rows[i].FindControl("hdnDocumentName");

                            //If file selected in file uploader, then upload it....
                            if (fuDocument.FileName != "")
                            {
                                blAnyChangeInCompanyDocs = true;
                                Documents d1 = new Documents();
                                string FileInCorporatonNo = "CD$" + Guid.NewGuid().ToString().Substring(0, 7) + "$" + fuDocument.FileName.Replace(" ", "_");
                                string path1 = Server.MapPath("~/CompanyDocuments/" + objToUpdate.CompanyID.ToString() + "/Documents/" + FileInCorporatonNo);
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Company";
                                d1.CreatedBy = clsSession.UserID;
                                d1.Notes = txtStatutoryName.Text.Trim();
                                d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                lstDocuments.Add(d1);
                            }
                            else if (Convert.ToString(hdnDocumentName.Value) != "")
                            {
                                //file not selected but to maintain previous uploaded file.
                                Documents d5 = new Documents();
                                d5.DocumentName = hdnDocumentName.Value;
                                d5.Extension = System.IO.Path.GetExtension(hdnDocumentName.Value);
                                d5.DateOfSubmission = DateTime.Now;
                                d5.CreatedOn = DateTime.Now;
                                d5.IsActive = true;
                                d5.AssociationType = "Company";
                                d5.CreatedBy = clsSession.UserID;
                                d5.Notes = txtStatutoryName.Text.Trim();
                                d5.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                lstDocuments.Add(d5);
                            }
                        }

                        if (blAnyChangeInCompanyDocs)
                            BindCompanyDocumentGrid();

                        //If logo is selected....
                        if (fuCompanyLogo.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "$" + fuCompanyLogo.FileName.Replace(" ", "_");
                            string path = Server.MapPath("~/CompanyDocuments/" + objToUpdate.CompanyID.ToString() + "/Logo/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuCompanyLogo.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();

                            objToUpdate.Thumb = cmpPhoto;

                            imgCompany.ImageUrl = "~/CompanyDocuments/" + objToUpdate.CompanyID.ToString() + "/Logo/" + Convert.ToString(objToUpdate.Thumb);
                            lnkRemoveLogo.Visible = true;
                        }

                        CompanyBLL.Update(objToUpdate, objOfficeAddressToUpdate, lstDocuments);
                        if (Convert.ToString(objToUpdate.PrimoryEmailAddress) != Convert.ToString(objOldToUpdate.PrimoryEmailAddress))
                        {
                            List<User> lstEmailUser = UserBLL.GetAllBy(User.UserFields.UserName, Convert.ToString(objToUpdate.PrimoryEmailAddress));

                            if (lstEmailUser.Count != 0)
                            {
                                SendEmail(Convert.ToString(lstEmailUser[0].UserDisplayName), Convert.ToString(lstEmailUser[0].UserName), Convert.ToString(lstEmailUser[0].Password));
                                mpeCustomePopup.Show();
                            }
                        }

                        //Save action log.
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldToUpdate.ToString() + "<br/><br/>" + objOldOfficeAddressToUpdate.ToString(), objToUpdate.ToString() + "<br/><br/>" + objOldOfficeAddressToUpdate.ToString(), "mst_Company");
                        IsMessage = true;
                        litSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        //Insert mode.
                        Company objToInsert = new Company();
                        Address objOfficeAddrToInsert = new Address();

                        objToInsert.CompanyID = Guid.NewGuid();
                        objToInsert.CompanyName = txtCompanyName.Text.Trim();
                        objToInsert.DisplayName = txtDisplayName.Text.Trim();
                        objToInsert.CompanyCode = txtCompanyCode.Text.Trim();

                        if (ddlBusinessDomain.SelectedIndex != 0)
                            objToInsert.BusinessDomain = ddlBusinessDomain.SelectedValue;
                        else
                            objToInsert.BusinessDomain = null;

                        if (ddlTypeOfCompany.SelectedIndex != 0)
                            objToInsert.CompanyType = new Guid(ddlTypeOfCompany.SelectedValue);
                        else
                            objToInsert.CompanyType = null;

                        objToInsert.PrimoryContactNo = txtPhoneNo.Text.Trim();
                        objToInsert.PrimoryEmailAddress = txtEmail.Text.Trim();
                        objToInsert.PrimaryFax = txtFax.Text.Trim();
                        objToInsert.PrimaryUrl = txtURL.Text.Trim();

                        objToInsert.PrimaryAdd1 = ucRegisteredAddress.strAddress.Trim();
                        objToInsert.PrimaryCity = ucRegisteredAddress.strCity.Trim();
                        objToInsert.PrimaryState = ucRegisteredAddress.strState.Trim();
                        objToInsert.PrimaryCountry = ucRegisteredAddress.strCountry.Trim();
                        objToInsert.PrimaryZipCode = ucRegisteredAddress.strZipCode.Trim();

                        objToInsert.IsActive = true;

                        objOfficeAddrToInsert.Add1 = ucOfficeAddress.strAddress;
                        objOfficeAddrToInsert.CityID = clsCommon.City(ucOfficeAddress.strCity);
                        objOfficeAddrToInsert.StateID = clsCommon.State(ucOfficeAddress.strState);
                        objOfficeAddrToInsert.CountryID = clsCommon.Country(ucOfficeAddress.strCountry);
                        objOfficeAddrToInsert.ZipCode = ucOfficeAddress.strZipCode;
                        objOfficeAddrToInsert.IsActive = true;

                        //Path to create directory for document and logo based on company.
                        string strCompDocsDirPath = Server.MapPath("~/CompanyDocuments");
                        string strCompDirPath = Server.MapPath("~/CompanyDocuments/" + objToInsert.CompanyID.ToString());
                        string strCompDocsPath = Server.MapPath("~/CompanyDocuments/" + objToInsert.CompanyID.ToString() + "/Documents");
                        string strCompLogoDirPath = Server.MapPath("~/CompanyDocuments/" + objToInsert.CompanyID.ToString() + "/Logo");

                        if (!Directory.Exists(strCompDocsDirPath))
                            Directory.CreateDirectory(strCompDocsDirPath);

                        if (!Directory.Exists(strCompDirPath))
                            Directory.CreateDirectory(strCompDirPath);

                        if (!Directory.Exists(strCompDocsPath))
                            Directory.CreateDirectory(strCompDocsPath);

                        if (!Directory.Exists(strCompLogoDirPath))
                            Directory.CreateDirectory(strCompLogoDirPath);

                        //// No documents available for newly creating company. But if logic changed, then to use this code.
                        //bool blAnyChangeInCompanyDocs = false;
                        //for (int i = 0; i < gvDocument.Rows.Count; i++)
                        //{
                        //    TextBox txtStatutoryName = (TextBox)gvDocument.Rows[i].FindControl("txtStatutoryName");
                        //    FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");

                        //    if (txtStatutoryName.Text.Trim() != "" && fuDocument.FileName != "")
                        //    {
                        //        blAnyChangeInCompanyDocs = true;
                        //        Documents d1 = new Documents();
                        //        string FileInCorporatonNo = "CD$" + Guid.NewGuid().ToString().Substring(0, 7) + "$" + fuDocument.FileName.Replace(" ", "_");
                        //        string path1 = Server.MapPath("~/CompanyDocuments/" + objToInsert.CompanyID.ToString() + "/Documents/" + FileInCorporatonNo);
                        //        fuDocument.SaveAs(path1);
                        //        d1.DocumentName = FileInCorporatonNo;
                        //        d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                        //        d1.DateOfSubmission = DateTime.Now;
                        //        d1.CreatedOn = DateTime.Now;
                        //        d1.IsActive = true;
                        //        d1.AssociationType = "Company";
                        //        d1.CreatedBy = clsSession.UserID;
                        //        d1.Notes = txtStatutoryName.Text.Trim();
                        //        d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                        //        lstDocuments.Add(d1);
                        //    }
                        //}

                        //if (blAnyChangeInCompanyDocs)
                        //    BindCompanyDocumentGrid();

                        //If logo is selected....
                        if (fuCompanyLogo.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "$" + fuCompanyLogo.FileName.Replace(" ", "_");
                            string path = Server.MapPath("~/CompanyDocuments/" + objToInsert.CompanyID.ToString() + "/Logo/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuCompanyLogo.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();

                            objToInsert.Thumb = cmpPhoto;

                            imgCompany.ImageUrl = "~/CompanyDocuments/" + objToInsert.CompanyID.ToString() + "/Logo/" + Convert.ToString(objToInsert.Thumb);
                            lnkRemoveLogo.Visible = true;
                        }
                        else
                            objToInsert.Thumb = "BlankPhoto.jpg";

                        CompanyBLL.Save(objToInsert, objOfficeAddrToInsert, lstDocuments);
                        clsSession.ToEditItemID = clsSession.CompanyID = objToInsert.CompanyID;
                        //Save action log.
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString() + "<br/><br/>" + objOfficeAddrToInsert.ToString(), objToInsert.ToString() + "<br/><br/>" + objOfficeAddrToInsert.ToString(), "mst_Company");

                        clsSession.CompanyName = txtCompanyName.Text.Trim();
                        if (clsSession.UserType.ToUpper() == "SUPERADMIN")
                        {
                            clsSession.PropertyID = Guid.Empty;
                            clsSession.PropertyName = String.Empty;
                            Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                        }
                        else
                        {
                            BindCompanyDocumentGrid();
                            IsMessage = true;
                            litSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        }
                    }
                    clsSession.CompanyName = txtCompanyName.Text.Trim();
                    LoadCompanyInfo();
                    BindBreadCrumb();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //Click event of Remove logo button.
        protected void lnkRemoveLogo_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.CompanyID != Guid.Empty)
                {
                    Company objCompany = CompanyBLL.GetByPrimaryKey(this.CompanyID);

                    string deletepath = Server.MapPath("~/CompanyDocuments/" + this.CompanyID.ToString() + "/Logo/") + Convert.ToString(objCompany.Thumb);

                    if (File.Exists(deletepath))
                        File.Delete(deletepath);

                    objCompany.Thumb = "BlankPhoto.jpg";
                    CompanyBLL.Update(objCompany);

                    imgCompany.ImageUrl = "~/images/BlankPhoto.jpg";
                    lnkRemoveLogo.Visible = false;

                    IsMessage = true;
                    litSuccessfully.Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblMsgLogoRemoved", "Logo removed successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnOKCustomeMsgPopup_Click(object sender, EventArgs e)
        {
            mpeCustomePopup.Hide();
            Session.Clear();
            Response.Redirect("~/Index.aspx");
        }

        #endregion Control Event

        #region Grid Event

        //Row databound event of gvDocument.
        protected void gvDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    string documentname = string.Empty;
                    documentname = DataBinder.Eval(e.Row.DataItem, "DocumentName").ToString();
                    string str = "~/CompanyDocuments/" + clsSession.CompanyID + "/Documents/" + documentname;

                    HtmlAnchor aDocumentLink = (HtmlAnchor)e.Row.FindControl("aDocumentLink");
                    ImageButton bnt = (ImageButton)e.Row.FindControl("btnDelete");


                    ((FileUpload)e.Row.FindControl("fuDocument")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblFileUploadTooltip", ".pdf|.PDF|.doc|.DOC|.jpg|.JPG|.jpeg|.JPEG|.gif|.GIF|.png|.PNG|.bmp|.BMP|.tif|.TIF|.docx|.DOCX|xlsx|XLSX");
                    if (documentname != string.Empty && documentname != null)
                    {
                        aDocumentLink.Visible = true;
                        bnt.Visible = true;
                        aDocumentLink.HRef = str;
                    }
                    else
                    {
                        aDocumentLink.Visible = false;
                        bnt.Visible = false;
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblHdrDocumentName")).Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblGvHdrDocumentName", "Document Name");
                    ((Label)e.Row.FindControl("lblHdrNumber")).Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblGvHdrNumber", "Number");
                    ((Label)e.Row.FindControl("lblHdrFile")).Text = clsCommon.GetGlobalResourceText("CompanySetup", "lblGvHdrFile", "File");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Row Command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));

                DataSet dsDocumentList = DocumentsBLL.GetDocumentGrid(null, null, this.CompanyID, "COMPANY DOCUMENT", this.CompanyID);
                if (dsDocumentList != null && dsDocumentList.Tables[0].Rows.Count != 0)
                {
                    gvDocument.DataSource = dsDocumentList.Tables[0];
                    gvDocument.DataBind();
                }
            }
        }

        #endregion
    }
}