using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using System.Web.UI.HtmlControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Property
{
    public partial class CtrlPropertySetup : System.Web.UI.UserControl
    {
        #region Property and Variables
        //Property to save CompanyID
        public Guid PropertyID
        {
            get
            {
                return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID"] = value;
            }
        }
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

        public bool IsInsert = false;
        public bool IsUpdate = false;
        public bool IsDuplicateRecord = false;

        public Guid AssociationID
        {
            get
            {
                return ViewState["AssociationID"] != null ? new Guid(Convert.ToString(ViewState["AssociationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AssociationID"] = value;
            }
        }
        #endregion Property and Variables

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                BindData();

                if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty)
                {
                    if (clsSession.ToEditItemType.ToUpper() == "PROPERTYSETUP")
                    {
                        btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                        // Save clsSession.ToEditItemID in ViewState (this.PropertyID)
                        this.PropertyID = this.AssociationID = clsSession.ToEditItemID;
                        //Call Method to load PropertyData.
                        LoadPropertyData();
                    }
                }
                else
                {
                    gvDocumentList.DataSource = null;
                    gvDocumentList.DataBind();

                    ucAddress.rfvAddress.Enabled = ucAddress.rfvCity.Enabled = ucAddress.rfvState.Enabled = ucAddress.rfvCountry.Enabled = true;
                    ucAddress.rfvZipCode.Enabled = true;
                    rfvtxtContactNo.Enabled = true;

                    ucAddress.tcAddress.Attributes.Add("class", "isrequire");
                    ucAddress.tcCity.Attributes.Add("class", "isrequire");
                    ucAddress.tcState.Attributes.Add("class", "isrequire");
                    ucAddress.tcCountry.Attributes.Add("class", "isrequire");
                    ucAddress.tcZipcode.Attributes.Add("class", "isrequire");
                    tdContactNo.Attributes.Add("class", "isrequire");
                }

                BindBreadCrumb();
            }
        }
        #endregion

        #region Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "PROPERTYSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Bind Default Data Here
        /// </summary>
        private void BindData()
        {
            try
            {

                SetPageLables();
                SetAddressControlValidation();
                BindDDL();                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Drop Down Information
        /// </summary>
        private void BindDDL()
        {
            List<ProjectTerm> lstProjectTermPT = null;
            ProjectTerm objProjectTermPT = new ProjectTerm();
            objProjectTermPT.IsActive = true;
            objProjectTermPT.Category = "PROPERTYTYPE";
            objProjectTermPT.CompanyID = clsSession.CompanyID;
            lstProjectTermPT = ProjectTermBLL.GetAll(objProjectTermPT);
            if (lstProjectTermPT.Count != 0)
            {
                ddlPropertyType.DataSource = lstProjectTermPT;
                ddlPropertyType.DataTextField = "DisplayTerm";
                ddlPropertyType.DataValueField = "TermID";
                ddlPropertyType.DataBind();
                ddlPropertyType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Set Page Label Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblMainHeader", "PROPERTY SETUP");
            ltrLicenceNumber.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblHotelLicenceNo", "Hotel Licence No.");
            ltrPropertyName.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblPropertyName", "Property Name");
            ltrPropertyCode.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblPropertyCode", "Property Code");
            ltrPropertyType.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblPropertyType", "Property Type");
            ltrSBAreaResidential.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblSBAreaResidential", "SB Area (Sqft) (Residential)");
            ltrSBAreaCommercial.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblSBAreaCommercial", "SB Area (Sqft) (Commercial)");
            ltrTotalBuiltUpArea.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblTotalBuiltUpArea", "Total Built Up Area");
            ltrHeaderContactInformation.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblHeaderContactInformation", "Contact Information");
            ltrContactName.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblContactName", "Name");
            ltrContactNumber.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblContactNumber", "Contact No.");
            ltrEmail.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblEmail", "Email");
            ltrHeaderAddress.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblHeaderAddress", "Address & Location");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litStatutoryList.Text = clsCommon.GetGlobalResourceText("PropertySetup", "lblStatutoryList", "Statutory List");
            regSBAreaResidential.ValidationExpression = regSBAreaCommercial.ValidationExpression = regTotalBuiltUpArea.ValidationExpression = "\\d{0,18}.\\d{0,2}";
            regSBAreaResidential.ErrorMessage = regSBAreaCommercial.ErrorMessage = regTotalBuiltUpArea.ErrorMessage = "2 " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }

        private void SetAddressControlValidation()
        {
            List<PropertyConfiguration> lstProConfigs = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, clsSession.PropertyID.ToString());
            if (lstProConfigs != null && lstProConfigs.Count > 0)
            {
                ucAddress.rfvAddress.Enabled = ucAddress.rfvCity.Enabled = ucAddress.rfvState.Enabled = ucAddress.rfvCountry.Enabled = !Convert.ToBoolean(lstProConfigs[0].IsSkipAddress);
                ucAddress.rfvZipCode.Enabled = !Convert.ToBoolean(lstProConfigs[0].IsSkipPostCode);
                rfvtxtContactNo.Enabled = !Convert.ToBoolean(lstProConfigs[0].IsSkipContactNo);

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipAddress))
                {
                    ucAddress.tcAddress.Attributes.Add("class", "isrequire");
                    ucAddress.tcCity.Attributes.Add("class", "isrequire");
                    ucAddress.tcState.Attributes.Add("class", "isrequire");
                    ucAddress.tcCountry.Attributes.Add("class", "isrequire");
                }

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipPostCode))
                {
                    ucAddress.tcZipcode.Attributes.Add("class", "isrequire");
                }

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipContactNo))
                {
                    tdContactNo.Attributes.Add("class", "isrequire");
                }
                
            }
            else
            {
                ucAddress.tcAddress.Attributes.Add("class", "isrequire");
                ucAddress.tcCity.Attributes.Add("class", "isrequire");
                ucAddress.tcState.Attributes.Add("class", "isrequire");
                ucAddress.tcCountry.Attributes.Add("class", "isrequire");
                ucAddress.tcZipcode.Attributes.Add("class", "isrequire");
                tdContactNo.Attributes.Add("class", "isrequire");
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
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }


            if (txtPropertyName.Text.Trim() != string.Empty)
                clsSession.PropertyName = txtPropertyName.Text.Trim();

            DataRow dr1 = dt.NewRow();
            if (clsSession.UserType.ToUpper() == "SUPERADMIN" || clsSession.UserType.ToUpper() == "ADMINISTRATOR")
            {
                dr1["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyList", "Property List");
                dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
                dt.Rows.Add(dr1);

                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = txtPropertyName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblProperty", "Property") : txtPropertyName.Text.Trim();
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }
            else if (clsSession.UserType.ToUpper() == "ADMIN")
            {
                dr1["NameColumn"] = txtPropertyName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblProperty", "Property") : txtPropertyName.Text.Trim();
                dr1["Link"] = "";
                dt.Rows.Add(dr1);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Load Property Data Here
        /// </summary>
        private void LoadPropertyData()
        {
            try
            {
                trLicenceNumber.Visible = true;
                DataSet dsPropertyData = PropertyBLL.GetAllDataByPrimaryKey(this.PropertyID);

                if (dsPropertyData != null && dsPropertyData.Tables[0].Rows.Count > 0)
                {
                    //Load Property Basic Information
                    DataRow drPrpt = dsPropertyData.Tables[0].Rows[0];
                    txtPropertyName.Text = Convert.ToString(drPrpt["PropertyName"]);

                    Label lblPropertyName = (Label)this.Page.Master.FindControl("lblPropertyName");
                    lblPropertyName.Text = Convert.ToString(drPrpt["PropertyName"]);

                    txtPropertyCode.Text = Convert.ToString(drPrpt["PropertyCode"]);

                    //if (Convert.ToString(drPrpt["ProperyType"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["ProperyType"]) != null)
                    //    ddlPropertyType.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PropertyTypeID"]));

                    ddlPropertyType.SelectedIndex = ddlPropertyType.Items.FindByValue(Convert.ToString(drPrpt["PropertyTypeID"])) != null ? ddlPropertyType.Items.IndexOf(ddlPropertyType.Items.FindByValue(Convert.ToString(drPrpt["PropertyTypeID"]))) : 0;

                    if (Convert.ToString(drPrpt["SBArea"]) != "")
                        txtSBAreaResidential.Text = Convert.ToString(drPrpt["SBArea"]);

                    if (Convert.ToString(drPrpt["SBAreaCommercial"]) != "")
                        txtSbAreaCommercial.Text = Convert.ToString(drPrpt["SBAreaCommercial"]);

                    if (Convert.ToString(drPrpt["CarpetArea"]) != "")
                        txtTotalBuiltUpArea.Text = Convert.ToString(drPrpt["CarpetArea"]);

                    //Load Contact Information
                    txtContactName.Text = Convert.ToString(drPrpt["PropManagerName"]);
                    txtContactNo.Text = Convert.ToString(drPrpt["PrimaryContactNo"]);
                    txtContactEmail.Text = Convert.ToString(drPrpt["PrimaryEmail"]);
                    lblLicenceNumber.Text = Convert.ToString(drPrpt["LicenceNo"]);
                    clsSession.HotelCode = lblLicenceNumber.Text.Trim();

                    if (dsPropertyData.Tables.Count > 1)
                    {
                        //Load Address Information
                        DataRow drAdd = dsPropertyData.Tables[1].Rows[0];
                        ucAddress.strAddress = Convert.ToString(drAdd["Add1"]);
                        ucAddress.strZipCode = Convert.ToString(drAdd["ZipCode"]);
                        ucAddress.strCountry = Convert.ToString(drAdd["CountryName"]);
                        ucAddress.strState = Convert.ToString(drAdd["StateName"]);
                        ucAddress.strCity = Convert.ToString(drAdd["CityName"]);
                    }

                    if (dsPropertyData.Tables.Count > 2)
                    {
                        DataRow dr = dsPropertyData.Tables[2].Rows[0];
                        if (Convert.ToString(dr["DateFormat"]) != string.Empty && Convert.ToString(dr["DateFormat"]) != Guid.Empty.ToString())
                            clsSession.DateFormat = Convert.ToString(dr["DateFormat"]);
                        else
                            clsSession.DateFormat = "dd-MMM-yyyy";

                        if (Convert.ToString(dr["CurrencyCode"]) != string.Empty && Convert.ToString(dr["CurrencyCode"]) != Guid.Empty.ToString())
                            clsSession.CurrentCurrency = Convert.ToString(dr["CurrencyCode"]);
                        else
                            clsSession.CurrentCurrency = "INR";

                        if (Convert.ToString(dr["TimeFormat"]) != string.Empty && Convert.ToString(dr["TimeFormat"]) != Guid.Empty.ToString())
                            clsSession.TimeFormat = Convert.ToString(dr["TimeFormat"]);
                        else
                            clsSession.TimeFormat = "hh:mm tt";
                    }
                    else
                    {
                        clsSession.DateFormat = "dd-MMM-yyyy";
                        clsSession.CurrentCurrency = "INR";
                        clsSession.TimeFormat = "hh:mm tt";
                    }

                    BindDocumentGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.PropertyID = Guid.Empty;
            txtPropertyName.Text = txtPropertyCode.Text = txtSBAreaResidential.Text = txtSbAreaCommercial.Text = txtTotalBuiltUpArea.Text = txtContactName.Text = txtContactNo.Text = txtContactEmail.Text = "";
            ucAddress.strAddress = ucAddress.strZipCode = ucAddress.strCountry = ucAddress.strState = ucAddress.strCity = "";
            ddlPropertyType.SelectedIndex = 0;
            BindDocumentGrid();
        }

        private void CreateResourceFiles(string hotelLicenceNumber)
        {
            string[] FileName = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "MasterResourceFiles/English");// + ddlLanguage.SelectedValue.ToString());

            for (int i = 0; i < FileName.Length; i++)
            {
                string str = FileName[i].ToString();
                string strDesPath = AppDomain.CurrentDomain.BaseDirectory + @"App_GlobalResources\" + hotelLicenceNumber.Replace("-", "_") + "_" + FileName[i].Substring(FileName[i].ToString().LastIndexOf(@"\") + 1);
                System.IO.File.Copy(FileName[i].ToString(), strDesPath);
            }
        }

        /// <summary>
        /// Load Document Grid
        /// </summary>
        private void BindDocumentGrid()
        {
            DataSet dsDocumentList = DocumentsBLL.GetDocumentByPropertyID(clsSession.CompanyID, clsSession.PropertyID);

            gvDocumentList.DataSource = dsDocumentList.Tables[0];
            gvDocumentList.DataBind();
        }
        #endregion

        #region Save Data
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (clsSession.UserType != "ADMIN")
                Response.Redirect("~/GUI/Property/PropertyList.aspx");
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<SQT.Symphony.BusinessLogic.IRMS.DTO.Documents> lstDocuments = new List<SQT.Symphony.BusinessLogic.IRMS.DTO.Documents>();

                    SQT.Symphony.BusinessLogic.Configuration.DTO.Property IsDupProperty = new BusinessLogic.Configuration.DTO.Property();

                    IsDupProperty.PropertyName = txtPropertyName.Text.Trim();
                    IsDupProperty.CompanyID = clsSession.CompanyID;
                    IsDupProperty.IsActive = true;
                    List<SQT.Symphony.BusinessLogic.Configuration.DTO.Property> LstDupProperty = PropertyBLL.GetAll(IsDupProperty);
                    if (LstDupProperty.Count > 0)
                    {
                        if (this.PropertyID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupProperty[0].PropertyID)) != Convert.ToString(this.PropertyID.ToString()))
                            {
                                IsInsert = true;
                                litSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsInsert = true;
                            litSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }

                    if (this.PropertyID != Guid.Empty)
                    {
                        //Update Current Data
                        SQT.Symphony.BusinessLogic.Configuration.DTO.Property UpdtProperty = PropertyBLL.GetByPrimaryKey(this.PropertyID);
                        SQT.Symphony.BusinessLogic.Configuration.DTO.Property OldProperty = PropertyBLL.GetByPrimaryKey(this.PropertyID);
                        SQT.Symphony.BusinessLogic.Configuration.DTO.Address UpdtAdres = new Address();

                        UpdtProperty.PropertyName = txtPropertyName.Text.Trim();
                        UpdtProperty.PropertyCode = txtPropertyCode.Text.Trim();

                        if (ddlPropertyType.SelectedIndex != 0)
                            UpdtProperty.PropertyTypeID = new Guid(ddlPropertyType.SelectedValue.ToString());
                        else
                            UpdtProperty.PropertyTypeID = null;

                        if (txtSbAreaCommercial.Text.Trim() != string.Empty)
                            UpdtProperty.SBAreaCommercial = Convert.ToDecimal(txtSbAreaCommercial.Text.Trim());
                        else
                            UpdtProperty.SBAreaCommercial = null;

                        if (txtSBAreaResidential.Text.Trim() != string.Empty)
                            UpdtProperty.SBArea = Convert.ToDecimal(txtSBAreaResidential.Text.Trim());
                        else
                            UpdtProperty.SBArea = null;

                        if (txtTotalBuiltUpArea.Text.Trim() != string.Empty)
                            UpdtProperty.CarpetArea = Convert.ToDecimal(txtTotalBuiltUpArea.Text.Trim());
                        else
                            UpdtProperty.CarpetArea = null;

                        UpdtProperty.PropManagerName = txtContactName.Text.Trim();
                        UpdtProperty.PrimaryContactNo = txtContactNo.Text.Trim();
                        UpdtProperty.PrimaryEmail = txtContactEmail.Text;

                        //Assign Address Information

                        UpdtAdres.Add1 = ucAddress.strAddress;
                        UpdtAdres.CityID = clsCommon.City(ucAddress.strCity);
                        UpdtAdres.StateID = clsCommon.State(ucAddress.strState);
                        UpdtAdres.CountryID = clsCommon.Country(ucAddress.strCountry);
                        UpdtAdres.ZipCode = ucAddress.strZipCode;

                        string strPropertyDocsDirPath = Server.MapPath("~/PropertyDocuments");
                        string strPropertyDirPath = Server.MapPath("~/PropertyDocuments/" + UpdtProperty.PropertyID.ToString());
                        string strPropertypDocsPath = Server.MapPath("~/PropertyDocuments/" + UpdtProperty.PropertyID.ToString() + "/Documents");

                        if (!Directory.Exists(strPropertyDocsDirPath))
                            Directory.CreateDirectory(strPropertyDocsDirPath);

                        if (!Directory.Exists(strPropertyDirPath))
                            Directory.CreateDirectory(strPropertyDirPath);

                        if (!Directory.Exists(strPropertypDocsPath))
                            Directory.CreateDirectory(strPropertypDocsPath);

                        for (int i = 0; i < gvDocumentList.Rows.Count; i++)
                        {
                            TextBox txtStatutoryName = (TextBox)gvDocumentList.Rows[i].FindControl("txtStatutoryName");
                            FileUpload fuDocument = (FileUpload)gvDocumentList.Rows[i].FindControl("fuDocument");
                            HiddenField hdnDocumentName = (HiddenField)gvDocumentList.Rows[i].FindControl("hdnDocumentName");

                            if (fuDocument.FileName != "")
                            {
                                SQT.Symphony.BusinessLogic.IRMS.DTO.Documents d1 = new SQT.Symphony.BusinessLogic.IRMS.DTO.Documents();
                                string FileInCorporatonNo = "PD$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");

                                string path1 = strPropertypDocsPath + "/" + FileInCorporatonNo;

                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Property";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtStatutoryName.Text.Trim();
                                d1.TypeID = new Guid(gvDocumentList.DataKeys[i].Value.ToString());
                                d1.CompanyID = clsSession.CompanyID;
                                lstDocuments.Add(d1);
                            }
                            else if (hdnDocumentName.Value != "")
                            {
                                SQT.Symphony.BusinessLogic.IRMS.DTO.Documents d5 = new SQT.Symphony.BusinessLogic.IRMS.DTO.Documents();
                                d5.DocumentName = hdnDocumentName.Value;
                                d5.Extension = System.IO.Path.GetExtension(hdnDocumentName.Value);
                                d5.DateOfSubmission = DateTime.Now;
                                d5.CreatedOn = DateTime.Now;
                                d5.IsActive = true;
                                d5.AssociationType = "Property";
                                d5.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d5.Notes = txtStatutoryName.Text.Trim();
                                d5.TypeID = new Guid(gvDocumentList.DataKeys[i].Value.ToString());
                                d5.CompanyID = clsSession.CompanyID;
                                lstDocuments.Add(d5);
                            }
                        }

                        PropertyBLL.Update(UpdtProperty, UpdtAdres, lstDocuments);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldProperty.ToString(), UpdtProperty.ToString(), "mst_Property");
                        IsInsert = true;
                        litSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                    }
                    else
                    {
                        //Insert New Data
                        SQT.Symphony.BusinessLogic.Configuration.DTO.Property Ins = new BusinessLogic.Configuration.DTO.Property();
                        SQT.Symphony.BusinessLogic.Configuration.DTO.Address InsAdd = new Address();

                        Ins.PropertyID = Guid.NewGuid();
                        Ins.IsActive = true;
                        Ins.CompanyID = clsSession.CompanyID;

                        Ins.PropertyName = txtPropertyName.Text.Trim();
                        Ins.PropertyCode = txtPropertyCode.Text.Trim();

                        if (ddlPropertyType.SelectedIndex != 0)
                            Ins.PropertyTypeID = new Guid(ddlPropertyType.SelectedValue.ToString());

                        if (txtSbAreaCommercial.Text.Trim() != string.Empty)
                            Ins.SBAreaCommercial = Convert.ToDecimal(txtSbAreaCommercial.Text.Trim());

                        if (txtSBAreaResidential.Text.Trim() != string.Empty)
                            Ins.SBArea = Convert.ToDecimal(txtSBAreaResidential.Text.Trim());

                        if (txtTotalBuiltUpArea.Text.Trim() != string.Empty)
                            Ins.CarpetArea = Convert.ToDecimal(txtTotalBuiltUpArea.Text.Trim());

                        Ins.PropManagerName = txtContactName.Text.Trim();
                        Ins.PrimaryContactNo = txtContactNo.Text.Trim();
                        Ins.PrimaryEmail = txtContactEmail.Text;

                        InsAdd.IsActive = true;
                        InsAdd.CompanyID = clsSession.CompanyID;
                        InsAdd.Add1 = ucAddress.strAddress;
                        InsAdd.CityID = clsCommon.City(ucAddress.strCity);
                        InsAdd.StateID = clsCommon.State(ucAddress.strState);
                        InsAdd.CountryID = clsCommon.Country(ucAddress.strCountry);
                        InsAdd.ZipCode = ucAddress.strZipCode;

                        string strPropertyDocsDirPath = Server.MapPath("~/PropertyDocuments");
                        string strPropertyDirPath = Server.MapPath("~/PropertyDocuments/" + Ins.PropertyID.ToString());
                        string strPropertypDocsPath = Server.MapPath("~/PropertyDocuments/" + Ins.PropertyID.ToString() + "/Documents");

                        if (!Directory.Exists(strPropertyDocsDirPath))
                            Directory.CreateDirectory(strPropertyDocsDirPath);

                        if (!Directory.Exists(strPropertyDirPath))
                            Directory.CreateDirectory(strPropertyDirPath);

                        if (!Directory.Exists(strPropertypDocsPath))
                            Directory.CreateDirectory(strPropertypDocsPath);

                        for (int i = 0; i < gvDocumentList.Rows.Count; i++)
                        {
                            TextBox txtStatutoryName = (TextBox)gvDocumentList.Rows[i].FindControl("txtStatutoryName");
                            FileUpload fuDocument = (FileUpload)gvDocumentList.Rows[i].FindControl("fuDocument");
                            if (fuDocument.FileName != "")
                            {
                                SQT.Symphony.BusinessLogic.IRMS.DTO.Documents d1 = new SQT.Symphony.BusinessLogic.IRMS.DTO.Documents();
                                string FileInCorporatonNo = "PD$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");

                                string path1 = strPropertypDocsPath + "/" + FileInCorporatonNo;
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Property";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtStatutoryName.Text.Trim();
                                d1.TypeID = new Guid(gvDocumentList.DataKeys[i].Value.ToString());
                                d1.CompanyID = clsSession.CompanyID;
                                //d1.PropertyID = clsSession.PropertyID;
                                lstDocuments.Add(d1);
                            }
                        }

                        PropertyBLL.Save(Ins, InsAdd, lstDocuments);
                        SQT.Symphony.BusinessLogic.Configuration.DTO.Property ojbProperty4Hotelcode = PropertyBLL.GetByPrimaryKey(Ins.PropertyID);
                        clsSession.PropertyID = this.PropertyID = Ins.PropertyID;
                        CreateResourceFiles(Convert.ToString(ojbProperty4Hotelcode.LicenceNo));
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", Ins.ToString(), Ins.ToString(), "mst_Property");
                        IsInsert = true;
                        litSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }

                    BindBreadCrumb();
                    BindDocumentGrid();
                    Label lblPropertyName = (Label)this.Page.Master.FindControl("lblPropertyName");
                    lblPropertyName.Text = txtPropertyName.Text;
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                    UpdatePanel uPnlMasterPropertyName = (UpdatePanel)this.Page.Master.FindControl("uPnlMasterPropertyName");
                    uPnlMasterPropertyName.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Save Data

        #region Grid Event

        protected void gvDocumentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                BindDocumentGrid();
            }
        }

        protected void gvDocumentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    string DocumentName = string.Empty;
                    DocumentName = DataBinder.Eval(e.Row.DataItem, "DocumentName").ToString();
                    string str = "~/PropertyDocuments/" + clsSession.PropertyID.ToString() + "/Documents/" + DocumentName;

                    HtmlAnchor aDocumentLink = (HtmlAnchor)e.Row.FindControl("aDocumentLink");
                    ImageButton imgbtn = (ImageButton)e.Row.FindControl("btnDelete");

                    imgbtn.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    aDocumentLink.Title = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");
                    ((FileUpload)e.Row.FindControl("fuDocument")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblFileUploadTooltip", ".pdf|.PDF|.doc|.DOC|.jpg|.JPG|.jpeg|.JPEG|.gif|.GIF|.png|.PNG|.bmp|.BMP|.tif|.TIF|.docx|.DOCX|xlsx|XLSX");

                    if (DocumentName != string.Empty && DocumentName != null)
                    {
                        imgbtn.Visible = this.UserRights.Substring(3, 1) == "1";
                        aDocumentLink.Visible = true;
                        aDocumentLink.HRef = str;
                    }
                    else
                    {
                        imgbtn.Visible = false;
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Literal)e.Row.FindControl("litGvHrdDocumentName")).Text = clsCommon.GetGlobalResourceText("PropertySetup", "litGvHrdDocumentName", "Document Name");
                    ((Literal)e.Row.FindControl("litGvHrdNumber")).Text = clsCommon.GetGlobalResourceText("PropertySetup", "litGvHrdNumber", "Number");
                    ((Literal)e.Row.FindControl("litGvHrdFile")).Text = clsCommon.GetGlobalResourceText("PropertySetup", "litGvHrdFile", "File");
                    ((Literal)e.Row.FindControl("lblGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblDocumentNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event
    }
}