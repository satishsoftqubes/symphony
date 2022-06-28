using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Property
{
    public partial class CtrlCompanyConfiguration : System.Web.UI.UserControl
    {
        #region Variable Declaration
        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }
        public bool IsMessage = false;
        //Property to save CompanyID
        public Guid PropertyConfigurationID
        {
            get
            {
                return ViewState["PropertyConfigurationID"] != null ? new Guid(Convert.ToString(ViewState["PropertyConfigurationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyConfigurationID"] = value;
            }
        }
        #endregion Variable Declaration

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                BindData();

                if (this.UserRights.Substring(2, 1) != "1")
                    lnkbtnDefaultSetup.Text = lnkbtnTransportationView.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnView", "View");
                    //lnkbtnSMTPEmail.Text = lnkbtnDefaultSetup.Text = lnkbtnTransportationView.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnView", "View");

                BindBreadCrumb();
            }
        }

        #endregion Variable Declaraction

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "SYSTEMSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            // btnSMTPOK.Visible = btnDefaultSetupOK.Visible = btnTransOK.Visible = this.UserRights.Substring(2, 1) == "1";            
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

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName ;

            if (clsSession.UserType.ToUpper() == "SUPERADMIN" || clsSession.UserType.ToUpper() == "ADMINISTRATOR")
                dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            else if (clsSession.UserType.ToUpper() == "ADMIN")
                dr1["Link"] = "~/GUI/Property/PropertySetup.aspx";
            
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblGeneralSettings", "General Settings");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblSystemSetup", "System Setup");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Default Data
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLables();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrSystemSetup.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrSystemSetup", "SYSTEM SETUP");
            //ltrSMTPEmailSetup.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrSMTPEmailSetup", "SMTP EMail Setup");
            //ltrSMTPEmailDescription.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrSMTPEmailDescription", "Sending Email require you to setup SMTP Email information");
            ltrDefaultSetup.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrDefaultSetup", "Default Setup ");
            ltrDefaultSetupDescription.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrDefaultSetupDescription", "Default Setup allowed to set optional input & Default Format for System");
            ltrTransportationView.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrTransportationView", "Transportation View");
            ltrTransportationViewDescription.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrTransportationViewDescription", "Road Description, Tube Description, Air Description, Public Transportation and Map View");
            //lnkbtnTransportationView.Text = lnkbtnDefaultSetup.Text = lnkbtnSMTPEmail.Text = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
            lnkbtnTransportationView.Text = lnkbtnDefaultSetup.Text = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
            //ltrSMTPSetpHeading.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrSMTPSetupHeading", "SMTP Setup");
            //ltrSMTPAddress.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrSMTPAddress", "SMTP Address");
            //ltrDNSName.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrDNSName", "DNS Name");
            //ltrPOP3Server.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrPOP3Server", "POP3 Server");
            //ltrPOP3OutGoingServer.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrPOP3OutGoingServer", "Outgoing Server");
            //ltrUserName.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrUserName", "User Name");
            //ltrPassword.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrPassword", "Password");
            //ltrPrimaryEmail.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrPrimaryEmail", "Primary Email");
            //ltrPrimaryDomain.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrPrimaryDomain", "Primary Domain");

            //btnSMTPOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            //btnSMTPCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");


            //Default Setup Model Popup

            litDefaultSetupHeading.Text = clsCommon.GetGlobalResourceText("SystemSetup", "litDefaultSetupHeading", "Default Setup");
            ltrMandatory.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrMandatory", "Mandatory");
            ltrOptional.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrOptional", "Optional");
            ltrAddress.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrAddress", "Address");
            ltrPostCode.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrPostCode", "PostCode");
            ltrContactNo.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrContactNo", "Contact No.");
            ltrEmail.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrEmail", "Email");
            ltrGuestIdentification.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrGuestIdentification", "Guest Identification");
            ltrDefaultSystemSetup.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrDefaultSystemSetup", "Default System Setup");
            //ltrDefaultCurrency.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrDefaultCurrency", "Default Currency");
            ltrDateFormat.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrDateFormat", "Date Format");
            ltrTimeForamt.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrTimeFormat", "Time Format");

            btnDefaultSetupOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnDefaultSetupCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            litTransportationViewHeading.Text = clsCommon.GetGlobalResourceText("SystemSetup", "litTransportationViewHeading", "Transportation View Details");
            ltrRoodDescription.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrRoodDescription", "Road Description");
            ltrTubeDescription.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrTubeDescription", "Tube Description");
            ltrByAirDescription.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrByAirDescription", "Air Description");
            ltrByPublicTranspertation.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrByPublicTranspertation", "Public Transportation");
            ltrMapView.Text = clsCommon.GetGlobalResourceText("SystemSetup", "ltrMapView", "Map View");

            btnTransOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnTransCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
           // litGeneralMandartoryFiledMessageForDefaultSetup.Text = litGeneralMandartoryFiledMessageForSMTP.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            litGeneralMandartoryFiledMessageForDefaultSetup.Text =  clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");

        }
        #endregion Private Methd

        //#region SMTP Email Setup Click Event
        ///// <summary>
        ///// Configure Email Option Here
        ///// </summary>
        ///// <param name="sender">sender as object</param>
        ///// <param name="e">e as EventArgs</param>
        //protected void lnkbtnSMTPEmail_Click(object sender, EventArgs e)
        //{
        //    SMTPSetup.Show();
        //    if (clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
        //    {
        //        PropertyConfiguration GetData = new PropertyConfiguration();
        //        GetData.CompanyID = clsSession.CompanyID;
        //        GetData.PropertyID = clsSession.PropertyID;
        //        GetData.IsActive = true;
        //        List<PropertyConfiguration> LstData = PropertyConfigurationBLL.GetAll(GetData);
        //        if (LstData.Count == 1)
        //        {
        //            this.PropertyConfigurationID = LstData[0].PropertyConfigurationID;
        //            txtSMTPAddress.Text = LstData[0].SmtpAddress;
        //            txtDNSName.Text = LstData[0].DNSName;
        //            txtPOP3Server.Text = LstData[0].POP3InServer;
        //            txtPOP3OutGoingServer.Text = LstData[0].POP3OutGoingServer;
        //            txtUserName.Text = LstData[0].UserName;
        //            txtPassword.Text = LstData[0].Password;
        //            txtPassword.Attributes.Add("value", LstData[0].Password);
        //            txtPrimaryEmail.Text = LstData[0].PrimoryEmail;
        //            txtPrimaryDomain.Text = LstData[0].PrimoryDomainName;
        //        }
        //    }
        //}
        // //<summary>
        // //Save Button Event
        // //</summary>
        // //<param name="sender">sender as Object</param>
        // //<param name="e">e as EventArgs</param>
        //protected void btnSMTPOK_Click(object sender, EventArgs e)
        //{
        //    if (this.PropertyConfigurationID != Guid.Empty)
        //    {
        //        //Update Record
        //        PropertyConfiguration Updt = PropertyConfigurationBLL.GetByPrimaryKey(this.PropertyConfigurationID);
        //        Updt.SmtpAddress = txtSMTPAddress.Text.Trim();
        //        Updt.DNSName = txtDNSName.Text.Trim();
        //        Updt.POP3InServer = txtPOP3Server.Text.Trim();
        //        Updt.POP3OutGoingServer = txtPOP3OutGoingServer.Text.Trim();
        //        Updt.UserName = txtUserName.Text.Trim();
        //        Updt.Password = txtPassword.Text.Trim();
        //        Updt.PrimoryEmail = txtPrimaryEmail.Text.Trim();
        //        Updt.PrimoryDomainName = txtPrimaryDomain.Text.Trim();
        //        PropertyConfigurationBLL.Update(Updt);
        //    }
        //    IsMessage = true;
        //    ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
        //    SMTPSetup.Hide();
        //}
        // //<summary>
        // //Cancel Button Event
        // //</summary>
        // //<param name="sender"></param>
        // //<param name="e"></param>
        //protected void btnSMTPCancel_Click(object sender, EventArgs e)
        //{
        //    SMTPSetup.Hide();
        //}
        //#endregion SMTP Email Setup Click Event

        #region Default Setup Button Click Event
        /// <summary>
        /// Configure Default setup
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void lnkbtnDefaultSetup_Click(object sender, EventArgs e)
        {
            DefaultSetup.Show();
            LoadCurrency();
            LoadTimeFormat();
            LoadDataFormat();
            if (clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
            {
                PropertyConfiguration GetData = new PropertyConfiguration();
                GetData.CompanyID = clsSession.CompanyID;
                GetData.PropertyID = clsSession.PropertyID;
                GetData.IsActive = true;
                List<PropertyConfiguration> LstData = PropertyConfigurationBLL.GetAll(GetData);
                if (LstData.Count == 1)
                {
                    this.PropertyConfigurationID = LstData[0].PropertyConfigurationID;
                    //ddlCurrency.SelectedValue = LstData[0].BaseCurrencyCode == null ? Guid.Empty.ToString() : Convert.ToString(LstData[0].BaseCurrencyCode);
                    ddlDateFormat.SelectedValue = LstData[0].DateFormatID == null ? Guid.Empty.ToString() : Convert.ToString(LstData[0].DateFormatID);
                    ddlTimeFormat.SelectedValue = LstData[0].TimeFormatID == null ? Guid.Empty.ToString() : Convert.ToString(LstData[0].TimeFormatID);
                    
                    if (Convert.ToBoolean(LstData[0].IsIdenticationReg) == true)
                        rdoGuestIdentificationNo.Checked = Convert.ToBoolean(LstData[0].IsIdenticationReg);
                    else
                        rdoGuestIdentificationYes.Checked = true;

                    if (Convert.ToBoolean(LstData[0].IsSkipEmail) == true)
                        rdoEmailNo.Checked = Convert.ToBoolean(LstData[0].IsSkipEmail);
                    else
                        rdoEmailYes.Checked = true;

                    if (Convert.ToBoolean(LstData[0].IsSkipContactNo) == true)
                        rdoContactNoNo.Checked = Convert.ToBoolean(LstData[0].IsSkipContactNo);
                    else
                        rdoContactNoYes.Checked = true;

                    if (Convert.ToBoolean(LstData[0].IsSkipPostCode) == true)
                        rdoPostCodeNo.Checked = Convert.ToBoolean(LstData[0].IsSkipPostCode);
                    else
                        rdoPostCodeYes.Checked = true;

                    if (Convert.ToBoolean(LstData[0].IsSkipAddress) == true)
                        rbtAddressNo.Checked = Convert.ToBoolean(LstData[0].IsSkipAddress);
                    else
                        rbtAddressYes.Checked = true;
                }
            }
        }
        /// <summary>
        /// Save Defautl Setup Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDefaultSetupOK_Click(object sender, EventArgs e)
        {
            if (this.PropertyConfigurationID != Guid.Empty)
            {
                //Update Record
                PropertyConfiguration Updt = PropertyConfigurationBLL.GetByPrimaryKey(this.PropertyConfigurationID);
                //if (ddlCurrency.SelectedIndex != 0)
                //{
                //    Updt.BaseCurrencyCode = Convert.ToString(ddlCurrency.SelectedValue);
                //    clsSession.CurrentCurrency = Convert.ToString(ddlDateFormat.SelectedValue);                    
                //}
                //else
                //    Updt.BaseCurrencyCode = null;

                if (ddlTimeFormat.SelectedIndex != 0)
                {
                    Updt.TimeFormatID = new Guid(Convert.ToString(ddlTimeFormat.SelectedValue));
                    clsSession.TimeFormat = Convert.ToString(ddlTimeFormat.SelectedItem.Text);
                }
                else
                    Updt.TimeFormatID = null;
                if (ddlDateFormat.SelectedIndex != 0)
                {
                    Updt.DateFormatID = new Guid(Convert.ToString(ddlDateFormat.SelectedValue));
                    clsSession.DateFormat = Convert.ToString(ddlDateFormat.SelectedItem.Text);
                }
                else
                    Updt.DateFormatID = null;
                
                if (rbtAddressNo.Checked)
                    Updt.IsSkipAddress = rbtAddressNo.Checked;
                if (rbtAddressYes.Checked)
                    Updt.IsSkipAddress = false;

                if (rdoPostCodeNo.Checked)
                    Updt.IsSkipPostCode = rdoPostCodeNo.Checked;
                if (rdoPostCodeYes.Checked)
                    Updt.IsSkipPostCode = false;

                if (rdoGuestIdentificationNo.Checked)
                    Updt.IsIdenticationReg = rdoGuestIdentificationNo.Checked;
                if (rdoGuestIdentificationYes.Checked)
                    Updt.IsIdenticationReg = false;

                if (rdoEmailNo.Checked)
                    Updt.IsSkipEmail = rdoEmailNo.Checked;
                if (rdoEmailYes.Checked)
                    Updt.IsSkipEmail = false;

                if (rdoContactNoNo.Checked)
                    Updt.IsSkipContactNo = rdoContactNoNo.Checked;
                if (rdoContactNoYes.Checked)
                    Updt.IsSkipContactNo = false;
                PropertyConfigurationBLL.Update(Updt);
            }
            IsMessage = true;
            ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            DefaultSetup.Hide();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnDefaultSetupCancel_Click(object sender, EventArgs e)
        {
            DefaultSetup.Hide();
        }
        #endregion Default Setup Button Click Event

        #region Default Setup Private Method
        /// <summary>
        /// Load Currency
        /// </summary>
        private void LoadCurrency()
        {
            //string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            //Currency GetCur = new Currency();
            //ddlCurrency.Items.Clear();
            //GetCur.PropertyID = clsSession.PropertyID;
            //GetCur.CompanyID = clsSession.CompanyID;
            //GetCur.IsActive = true;
            //List<Currency> lstCur = CurrencyBLL.GetAll(GetCur);
            //if (lstCur.Count > 0)
            //{
            //    ddlCurrency.DataSource = lstCur;
            //    ddlCurrency.DataTextField = "Name";
            //    ddlCurrency.DataValueField = "CurrencyCode";
            //    ddlCurrency.DataBind();
            //    ddlCurrency.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            //}
            //else
            //    ddlCurrency.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }
        /// <summary>
        /// Load Date Format
        /// </summary>
        private void LoadDataFormat()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "DATEFORMAT");
            ddlDateFormat.Items.Clear();
            if (lstProjectTermTitle.Count != 0)
            {
                ddlDateFormat.DataSource = lstProjectTermTitle;
                ddlDateFormat.DataTextField = "DisplayTerm";
                ddlDateFormat.DataValueField = "TermID";
                ddlDateFormat.DataBind();
                ddlDateFormat.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlDateFormat.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                
        }
        /// <summary>
        /// Load TimeFormat
        /// </summary>
        private void LoadTimeFormat()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "TIMEFORMAT");
            ddlTimeFormat.Items.Clear();
            if (lstProjectTermTitle.Count != 0)
            {
                ddlTimeFormat.DataSource = lstProjectTermTitle;
                ddlTimeFormat.DataTextField = "DisplayTerm";
                ddlTimeFormat.DataValueField = "TermID";
                ddlTimeFormat.DataBind();
                ddlTimeFormat.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlTimeFormat.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                
        }
        #endregion Default Setup Private Method

        #region Transportation Button Click Event
        /// <summary>
        /// Configure Transportation Details
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void lnkbtnTransportationView_Click(object sender, EventArgs e)
        {
            TransportationView.Show();
            if (clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
            {
                PropertyConfiguration GetData = new PropertyConfiguration();
                GetData.CompanyID = clsSession.CompanyID;
                GetData.PropertyID = clsSession.PropertyID;
                GetData.IsActive = true;
                List<PropertyConfiguration> LstData = PropertyConfigurationBLL.GetAll(GetData);
                if (LstData.Count == 1)
                {
                    this.PropertyConfigurationID = LstData[0].PropertyConfigurationID;
                    txtRoadDescription.Text = LstData[0].RoodDescription;
                    txtTubeDescription.Text = LstData[0].TubeDescription;
                    txtByAirDescription.Text = LstData[0].ByAirDescription;
                    txtByPublicTranspertation.Text = LstData[0].ByPublicTranspertation;
                    txtMapView.Text = LstData[0].MapView;
                }
            }
        }
        /// <summary>
        /// Save Transportation Details
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnTransOK_Click(object sender, EventArgs e)
        {
            if (this.PropertyConfigurationID != Guid.Empty)
            {
                //Update Record
                PropertyConfiguration Updt = PropertyConfigurationBLL.GetByPrimaryKey(this.PropertyConfigurationID);
                Updt.RoodDescription = txtRoadDescription.Text.Trim();
                Updt.TubeDescription = txtTubeDescription.Text.Trim();
                Updt.ByAirDescription = txtByAirDescription.Text.Trim();
                Updt.ByPublicTranspertation = txtByPublicTranspertation.Text.Trim();
                Updt.MapView = txtMapView.Text.Trim();
                PropertyConfigurationBLL.Update(Updt);
            }
            IsMessage = true;
            ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            TransportationView.Hide();
        }
        /// <summary>
        /// Transportation Details Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnTransCancel_Click(object sender, EventArgs e)
        {
            TransportationView.Hide();
        }
        #endregion Transportation Button Click Event
    }
}