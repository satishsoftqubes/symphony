using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.IO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlPropertyConfigurationInformation : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

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

        public Guid AddressID
        {
            get
            {
                return ViewState["AddressID"] != null ? new Guid(Convert.ToString(ViewState["AddressID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AddressID"] = value;
            }
        }

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

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EvnetArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                    if (Session["Property"] != null)
                    {
                        this.PropertyID = new Guid(Convert.ToString(Session["Property"]));
                        LoadData();
                        Session["Property"] = null;
                    }
                    else
                        btnSave.Visible = true;
                }
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Load Defalutl Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                LoadDocumentGrid();
                LoadLandIssueGrid();
                BindPropertyType();
                BindPurchaseOption();
                BindPaymentTerm();
                LoadValidation();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadValidation()
        {
            if (Session["PropertyConfigurationInfo"] != null)
            {
                PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                rfvZipCode.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipPostCode));
                rfvAdd1.Enabled = rfvCityName.Enabled = rvfState.Enabled = rvfCountry.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipAddress));                

                if (!Convert.ToBoolean(objPropertyConfiguration.IsSkipAddress))
                {                    
                    tdAddress.Attributes.Add("class", "RequireFile");
                    tdCity.Attributes.Add("class", "RequireFile");
                    tdState.Attributes.Add("class", "RequireFile");
                    tdCountry.Attributes.Add("class", "RequireFile");
                }

                if (!Convert.ToBoolean(objPropertyConfiguration.IsSkipPostCode))
                    tdZipCode.Attributes.Add("class", "RequireFile");                
            }
        }

        /// <summary>
        /// Load Purchase Option
        /// </summary>
        private void BindPurchaseOption()
        {
            List<ProjectTerm> lstProjectTermPO = null;
            ProjectTerm objProjectTermPT = new ProjectTerm();
            objProjectTermPT.IsActive = true;
            objProjectTermPT.Category = "PURCHASEOPTION";
            objProjectTermPT.CompanyID = this.CompanyID;

            lstProjectTermPO = ProjectTermBLL.GetAll(objProjectTermPT);

            if (lstProjectTermPO.Count != 0)
            {
                lstProjectTermPO.Sort((ProjectTerm p1, ProjectTerm p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlPurchaseOption.DataSource = lstProjectTermPO;
                ddlPurchaseOption.DataTextField = "DisplayTerm";
                ddlPurchaseOption.DataValueField = "TermID";
                ddlPurchaseOption.DataBind();
                ddlPurchaseOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlPurchaseOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        /// <summary>
        /// Load Payment Term
        /// </summary>
        private void BindPaymentTerm()
        {
            List<ProjectTerm> lstProjectTermPayTerm = null;
            ProjectTerm objProjectTermPayTerm = new ProjectTerm();
            objProjectTermPayTerm.IsActive = true;
            objProjectTermPayTerm.Category = "PAYMENTTERM";
            objProjectTermPayTerm.CompanyID = this.CompanyID;

            lstProjectTermPayTerm = ProjectTermBLL.GetAll(objProjectTermPayTerm);

            if (lstProjectTermPayTerm.Count != 0)
            {
                lstProjectTermPayTerm.Sort((ProjectTerm p1, ProjectTerm p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlPaymentTerm.DataSource = lstProjectTermPayTerm;
                ddlPaymentTerm.DataTextField = "DisplayTerm";
                ddlPaymentTerm.DataValueField = "TermID";
                ddlPaymentTerm.DataBind();
                ddlPaymentTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlPaymentTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        /// <summary>
        /// Load Property Type
        /// </summary>
        private void BindPropertyType()
        {
            List<ProjectTerm> lstProjectTermPT = null;
            ProjectTerm objProjectTermPT = new ProjectTerm();
            objProjectTermPT.IsActive = true;
            objProjectTermPT.Category = "PROPERTYTYPE";
            objProjectTermPT.CompanyID = this.CompanyID;

            lstProjectTermPT = ProjectTermBLL.GetAll(objProjectTermPT);

            if (lstProjectTermPT.Count != 0)
            {
                lstProjectTermPT.Sort((ProjectTerm p1, ProjectTerm p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlPropertyType.DataSource = lstProjectTermPT;
                ddlPropertyType.DataTextField = "DisplayTerm";
                ddlPropertyType.DataValueField = "TermID";
                ddlPropertyType.DataBind();
                ddlPropertyType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                drpQSPropertyType.DataSource = lstProjectTermPT;
                drpQSPropertyType.DataTextField = "DisplayTerm";
                drpQSPropertyType.DataValueField = "TermID";
                drpQSPropertyType.DataBind();
                drpQSPropertyType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
            {
                ddlPropertyType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                drpQSPropertyType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }

            txtQSLocation.Items.Clear();
            List<City> LstCt = CityBLL.GetAll();
            if (LstCt.Count > 0)
            {
                LstCt.Sort((City p1, City p2) => p1.CityName.CompareTo(p2.CityName));
                txtQSLocation.DataSource = LstCt;
                txtQSLocation.DataTextField = "CityName";
                txtQSLocation.DataValueField = "CityName";
                txtQSLocation.DataBind();
                txtQSLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtQSLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            Guid? CompanyID;
            Guid? PropertyType;
            string PropertyName, Location = null;
            CompanyID = this.CompanyID;
            if (!(txtSPropertyName.Text.Trim().Equals("")))
                PropertyName = txtSPropertyName.Text.Trim();
            else
                PropertyName = null;
            if (!(txtQSLocation.SelectedValue.Equals(Guid.Empty.ToString())))
                Location = txtQSLocation.SelectedValue.ToString();
            else
                Location = null;
            if (drpQSPropertyType.SelectedValue != Guid.Empty.ToString())
                PropertyType = new Guid(drpQSPropertyType.SelectedValue);
            else
                PropertyType = null;

            DataSet ds = PropertyBLL.GetPropertyData(null, CompanyID, PropertyName, Location, PropertyType);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "PropertyName Asc";
            grdPropertyList.DataSource = dv;
            grdPropertyList.DataBind();
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            txtPropertyName.Text = "";
            //txtPropertyDisplayName.Text = "";
            txtPropertyCode.Text = "";
            txtPropertyManagerName.Text = "";
            txtPrimaryContactNo.Text = "";
            txtPrimaryEmail.Text = "";
            //txtPrimaryFax.Text = "";
            txtSBAreaResidential.Text = "";
            txtSbAreaCommercial.Text = "";
            txtCarpetArea.Text = "";
            txtAddressLine1.Text = "";
            //txtAddressLine2.Text = "";
            txtZipCode.Text = "";
            txtCountryName.Text = "";
            txtStateName.Text = "";
            txtCityName.Text = "";
            //BindAddressType();
            //ddlAddressType.SelectedValue = Guid.Empty.ToString();
            BindPropertyType();
            BindPurchaseOption();
            BindPaymentTerm();
            txtSurveyNo.Text = "";
            ddlPropertyType.SelectedValue = Guid.Empty.ToString();
            txtJantri.Text = "";
            BindGrid();
            this.PropertyID = Guid.Empty;
            this.AddressID = Guid.Empty;
            LoadDocumentGrid();
            LoadLandIssueGrid();
        }

        /// <summary>
        /// Load Edit Data
        /// </summary>
        private void LoadData()
        {
            DataSet ds = new DataSet();
            ds = PropertyBLL.GetPropertyData(this.PropertyID, this.CompanyID, null, null, null);

            if (ds.Tables[0].Rows.Count != 0)
            {
                BindPropertyType();
                BindPurchaseOption();
                BindPaymentTerm();
                //BindAddressType();
                txtPropertyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]);
                //txtPropertyDisplayName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PropertyDisplayName"]);
                txtPropertyCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PropertyCode"]);
                txtSurveyNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SurveyNo"]);
                txtPropertyManagerName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PropManagerName"]);
                txtPrimaryContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PrimaryContactNo"]);
                txtPrimaryEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["PrimaryEmail"]);
                //txtPrimaryFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["PrimaryFax"]);

                if (Convert.ToString(ds.Tables[0].Rows[0]["Jantri"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["Jantri"]) != null)
                    txtJantri.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Jantri"]).ToString("0");
                else
                    txtJantri.Text = "";

                if (Convert.ToString(ds.Tables[0].Rows[0]["SBArea"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["SBArea"]) != null)
                    txtSBAreaResidential.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SBArea"]).ToString("0");
                else
                    txtSBAreaResidential.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["SBAreaCommercial"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["SBAreaCommercial"]) != null)
                    txtSbAreaCommercial.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SBAreaCommercial"]).ToString("0");
                else
                    txtSbAreaCommercial.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["CarpetArea"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["CarpetArea"]) != null)
                    txtCarpetArea.Text = Convert.ToDecimal((ds.Tables[0].Rows[0]["CarpetArea"])).ToString("0");
                else
                    txtCarpetArea.Text = "";
                txtAddressLine1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Add1"]);
                //txtAddressLine2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Add2"]);
                txtZipCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZipCode"]);
                txtCountryName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CountryName"]);
                txtStateName.Text = Convert.ToString(ds.Tables[0].Rows[0]["StateName"]);
                txtCityName.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);

                if (Convert.ToString(ds.Tables[0].Rows[0]["ProperyType"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["ProperyType"]) != null)
                    ddlPropertyType.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PropertyTypeID"]));

                if (Convert.ToString(ds.Tables[0].Rows[0]["PurchaseOption"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PurchaseOption"]) != null)
                    ddlPurchaseOption.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PurchaseOptionID"]));

                if (Convert.ToString(ds.Tables[0].Rows[0]["PaymentTerm"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PaymentTerm"]) != null)
                    ddlPaymentTerm.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PaymentTermID"]));

                //if (Convert.ToString(ds.Tables[0].Rows[0]["AddressTypeTermID"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["AddressTypeTermID"]) != null)
                //    ddlAddressType.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["AddressTypeTermID"]));

                this.AddressID = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["AddressID"]));
                LoadDocumentGrid();
                LoadLandIssueGrid();
            }
        }

        /// <summary>
        /// Load Document Grid
        /// </summary>
        private void LoadDocumentGrid()
        {
            Guid? PropertyID;
            if (this.PropertyID != Guid.Empty)
                PropertyID = this.PropertyID;
            else
                PropertyID = null;

            DataSet dsDocumentList = DocumentsBLL.GetDocumentGrid(null, null, this.CompanyID, "PROPERTY DOCUMENT", PropertyID);
            if (dsDocumentList.Tables[0].Rows.Count != 0)
            {
                gvDocument.DataSource = dsDocumentList.Tables[0];
                gvDocument.DataBind();
            }
        }

        /// <summary>
        /// Load Land Issue Grid
        /// </summary>
        private void LoadLandIssueGrid()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for Label
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for file selection   
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for view and delete   
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));//for add new row

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column2"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvLandIssueModification.DataSource = dt;
            gvLandIssueModification.DataBind();  
  
        }

        protected void fnAddNewLandIssueDocument(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void AddNewRowToGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   
                    ViewState["CurrentTable"] = dtCurrentTable;

                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {
                        TextBox box1 = (TextBox)gvLandIssueModification.Rows[i].Cells[1].FindControl("txtLandIssueModification");
                        dtCurrentTable.Rows[i]["Column2"] = box1.Text;
                    }
                    gvLandIssueModification.DataSource = dtCurrentTable;
                    gvLandIssueModification.DataBind();  
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //Set Previous Data on Postbacks   
            SetPreviousData();  
        }

        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }  

        protected void fnRemoveRow_Click(object sender, EventArgs e)
        {
            ImageButton lb = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                gvLandIssueModification.DataSource = dt;
                gvLandIssueModification.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData();
        }  

        private void SetPreviousData()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)gvLandIssueModification.Rows[i].Cells[1].FindControl("txtLandIssueModification");

                        if (i < dt.Rows.Count - 1)
                        {
                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Column2"].ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }  

        protected void gvLandIssueRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                ImageButton lb = (ImageButton)e.Row.FindControl("btnRemoveRow");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }  
        }

        #endregion Private Method

        #region Control Event
        /// <summary>
        /// Add New Property Into the System
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session.Remove("Property");
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        /// <summary>
        /// Button Save And Update Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Property IsDupProperty = new Property();
                    IsDupProperty.PropertyName = txtPropertyName.Text.Trim();
                    IsDupProperty.IsActive = true;
                    List<Property> LstDupProperty = PropertyBLL.GetAll(IsDupProperty);
                    if (LstDupProperty.Count > 0)
                    {
                        if (this.PropertyID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupProperty[0].PropertyID)) != Convert.ToString(this.PropertyID.ToString()))
                            {
                                IsMessage = true;
                                lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsMessage = true;
                            lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }


                    List<Documents> lstDocuments = new List<Documents>();

                    if (this.PropertyID != Guid.Empty)
                    {
                        Property objUpdProperty = new Property();
                        Property objOldPropertyData = new Property();

                        objUpdProperty = PropertyBLL.GetByPrimaryKey(this.PropertyID);
                        objOldPropertyData = PropertyBLL.GetByPrimaryKey(this.PropertyID);

                        objUpdProperty.PropertyName = txtPropertyName.Text.Trim();
                        //objUpdProperty.PropertyDisplayName = txtPropertyDisplayName.Text.Trim();
                        objUpdProperty.PropertyCode = txtPropertyCode.Text.Trim();
                        if (ddlPropertyType.SelectedValue != Guid.Empty.ToString())
                            objUpdProperty.PropertyTypeID = new Guid(ddlPropertyType.SelectedValue);
                        else
                            objUpdProperty.PropertyTypeID = null;

                        if (ddlPurchaseOption.SelectedValue != Guid.Empty.ToString())
                            objUpdProperty.PurchaseOptionID = new Guid(ddlPurchaseOption.SelectedValue);
                        else
                            objUpdProperty.PurchaseOptionID = null;

                        objUpdProperty.SurveyNo = txtSurveyNo.Text.Trim();

                        if (ddlPaymentTerm.SelectedValue != Guid.Empty.ToString())
                            objUpdProperty.PaymentTermID = new Guid(ddlPaymentTerm.SelectedValue);
                        else
                            objUpdProperty.PaymentTermID = null;

                        objUpdProperty.PropManagerName = txtPropertyManagerName.Text.Trim();
                        objUpdProperty.PrimaryContactNo = txtPrimaryContactNo.Text.Trim();
                        objUpdProperty.PrimaryEmail = txtPrimaryEmail.Text.Trim();
                        //objUpdProperty.PrimaryFax = txtPrimaryFax.Text.Trim();

                        if (!(txtJantri.Text.Trim().Equals("")))
                            objUpdProperty.Jantri = Convert.ToDecimal(txtJantri.Text.Trim());
                        else
                            objUpdProperty.Jantri = null;

                        if (!(txtSBAreaResidential.Text.Trim().Equals("")))
                            objUpdProperty.SBArea = Convert.ToDecimal(txtSBAreaResidential.Text.Trim());
                        else
                            objUpdProperty.SBArea = null;
                        if (!(txtSbAreaCommercial.Text.Trim().Equals("")))
                            objUpdProperty.SBAreaCommercial = Convert.ToDecimal(txtSbAreaCommercial.Text.Trim());
                        else
                            objUpdProperty.SBAreaCommercial = null;
                        if (!(txtCarpetArea.Text.Trim().Equals("")))
                            objUpdProperty.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text.Trim());
                        else
                            objUpdProperty.CarpetArea = null;
                        objUpdProperty.LastUpdateOn = DateTime.Now;
                        //objUpdProperty.KhataNo = txtKhataNo.Text.Trim();
                        //objUpdProperty.BuldingPlanApprovalNo = txtBuldingPlanApprovalNo.Text.Trim();
                        //objUpdProperty.KPSBNoc = txtKPSBNoc.Text.Trim();
                        //objUpdProperty.SEACNOC = txtSEACNOC.Text.Trim();
                        //objUpdProperty.CertificationNo = txtCertificationNo.Text.Trim();
                        //objUpdProperty.LicenceNo = txtLicenseNo.Text.Trim();
                        objUpdProperty.LastUpdateBy = new Guid(Convert.ToString(Session["UserID"]));

                        Address objUpdAddres = new Address();
                        objUpdAddres = AddressBLL.GetByPrimaryKey(this.AddressID);
                        if (objUpdAddres == null)
                            objUpdAddres = new Address();

                        objUpdAddres.Add1 = txtAddressLine1.Text.Trim();
                        //objUpdAddres.Add2 = txtAddressLine2.Text.Trim();                        
                        objUpdAddres.ZipCode = txtZipCode.Text.Trim();

                        objUpdAddres.CountryID = clsCommon.Country(txtCountryName.Text.Trim());
                        objUpdAddres.StateID = clsCommon.State(txtStateName.Text.Trim());
                        objUpdAddres.CityID = clsCommon.City(txtCityName.Text.Trim());
                        objUpdAddres.City = txtCityName.Text.Trim();

                        //if (ddlAddressType.SelectedValue != Guid.Empty.ToString())
                        //    objUpdAddres.AddressTypeTermID = new Guid(ddlAddressType.SelectedValue);
                        //else
                        //    objUpdAddres.AddressTypeTermID = null;

                        for (int i = 0; i < gvDocument.Rows.Count; i++)
                        {
                            TextBox txtStatutoryName = (TextBox)gvDocument.Rows[i].FindControl("txtStatutoryName");
                            FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");
                            HiddenField hdnDocumentName = (HiddenField)gvDocument.Rows[i].FindControl("hdnDocumentName");
                           
                            if (fuDocument.FileName != "")
                            {
                                Documents d1 = new Documents();
                                string FileInCorporatonNo = "PD$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");
                                string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Property";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtStatutoryName.Text.Trim();
                                d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                lstDocuments.Add(d1);
                            }
                            else if (hdnDocumentName.Value != "")
                            {
                                Documents d5 = new Documents();
                                d5.DocumentName = hdnDocumentName.Value;
                                d5.Extension = System.IO.Path.GetExtension(hdnDocumentName.Value);
                                d5.DateOfSubmission = DateTime.Now;
                                d5.CreatedOn = DateTime.Now;
                                d5.IsActive = true;
                                d5.AssociationType = "Property";
                                d5.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d5.Notes = txtStatutoryName.Text.Trim();
                                d5.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                d5.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                lstDocuments.Add(d5);
                            }
                        }

                        // Land Issue/Modification
                        int rowIndex = 0;
                        StringCollection sc = new StringCollection();
                        if (ViewState["CurrentTable"] != null)
                        {
                            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                            if (dtCurrentTable.Rows.Count > 0)
                            {
                                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                                {
                                    //extract the TextBox values  
                                    TextBox box2 = (TextBox)gvLandIssueModification.Rows[rowIndex].Cells[1].FindControl("txtLandIssueModification");
                                    //then add it to the collections with a comma "," as the delimited values  
                                    sc.Add(string.Format("{0}", box2.Text));
                                    rowIndex++;
                                }
                                
                                //InsertRecords(sc);
                            }
                        }


                        PropertyBLL.Update(objUpdProperty, objUpdAddres, lstDocuments);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldPropertyData.ToString(), objUpdProperty.ToString(), "mst_Property");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.PropertyID = objUpdProperty.PropertyID;
                    }
                    else
                    {
                        Property objInsProperty = new Property();
                        Address objInsAddres = new Address();

                        objInsProperty.CompanyID = this.CompanyID;
                        objInsProperty.PropertyName = txtPropertyName.Text.Trim();
                        //objInsProperty.PropertyDisplayName = txtPropertyDisplayName.Text.Trim();
                        objInsProperty.PropertyCode = txtPropertyCode.Text.Trim();
                        if (ddlPropertyType.SelectedValue != Guid.Empty.ToString())
                            objInsProperty.PropertyTypeID = new Guid(ddlPropertyType.SelectedValue);
                        else
                            objInsProperty.PropertyTypeID = null;

                        if (ddlPurchaseOption.SelectedValue != Guid.Empty.ToString())
                            objInsProperty.PurchaseOptionID = new Guid(ddlPurchaseOption.SelectedValue);
                        else
                            objInsProperty.PurchaseOptionID = null;
                        
                        objInsProperty.SurveyNo = txtSurveyNo.Text.Trim();

                        if (ddlPaymentTerm.SelectedValue != Guid.Empty.ToString())
                            objInsProperty.PaymentTermID = new Guid(ddlPaymentTerm.SelectedValue);
                        else
                            objInsProperty.PaymentTermID = null;

                        objInsProperty.PropManagerName = txtPropertyManagerName.Text.Trim();
                        objInsProperty.PrimaryContactNo = txtPrimaryContactNo.Text.Trim();
                        objInsProperty.PrimaryEmail = txtPrimaryEmail.Text.Trim();
                        //objInsProperty.PrimaryFax = txtPrimaryFax.Text.Trim();
                        
                        if (!(txtJantri.Text.Trim().Equals("")))
                            objInsProperty.Jantri = Convert.ToDecimal(txtJantri.Text.Trim());
                        else
                            objInsProperty.Jantri = null;

                        if (!(txtSBAreaResidential.Text.Trim().Equals("")))
                            objInsProperty.SBArea = Convert.ToDecimal(txtSBAreaResidential.Text.Trim());
                        else
                            objInsProperty.SBArea = null;
                        if (!(txtSbAreaCommercial.Text.Trim().Equals("")))
                            objInsProperty.SBAreaCommercial = Convert.ToDecimal(txtSbAreaCommercial.Text.Trim());
                        else
                            objInsProperty.SBAreaCommercial = null;
                        if (!(txtCarpetArea.Text.Trim().Equals("")))
                            objInsProperty.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text.Trim());
                        else
                            objInsProperty.CarpetArea = null;
                        objInsProperty.IsActive = true;
                        objInsProperty.LastUpdateOn = DateTime.Now;
                        objInsProperty.PropertyCreatedOn = DateTime.Now;
                        //objInsProperty.KhataNo = txtKhataNo.Text.Trim();
                        //objInsProperty.BuldingPlanApprovalNo = txtBuldingPlanApprovalNo.Text.Trim();
                        //objInsProperty.KPSBNoc = txtKPSBNoc.Text.Trim();
                        //objInsProperty.SEACNOC = txtSEACNOC.Text.Trim();
                        //objInsProperty.CertificationNo = txtCertificationNo.Text.Trim();
                        //objInsProperty.LicenceNo = txtLicenseNo.Text.Trim();
                        objInsProperty.IsSynch = false;
                        objInsProperty.LastUpdateBy = new Guid(Convert.ToString(Session["UserID"]));

                        objInsAddres.CompanyID = this.CompanyID;
                        objInsAddres.Add1 = txtAddressLine1.Text.Trim();
                        //objInsAddres.Add2 = txtAddressLine2.Text.Trim();
                        objInsAddres.ZipCode = txtZipCode.Text.Trim();

                        objInsAddres.CountryID = clsCommon.Country(txtCountryName.Text.Trim());
                        objInsAddres.StateID = clsCommon.State(txtStateName.Text.Trim());
                        objInsAddres.CityID = clsCommon.City(txtCityName.Text.Trim());
                        objInsAddres.City = txtCityName.Text.Trim();


                        for (int i = 0; i < gvDocument.Rows.Count; i++)
                        {
                            TextBox txtStatutoryName = (TextBox)gvDocument.Rows[i].FindControl("txtStatutoryName");
                            FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");
                            if (fuDocument.FileName != "")
                            {
                                Documents d1 = new Documents();
                                string FileInCorporatonNo = "PD$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");
                                string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Property";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtStatutoryName.Text.Trim();
                                d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                lstDocuments.Add(d1);
                            }
                        }

                        //if (ddlAddressType.SelectedValue != Guid.Empty.ToString())
                        //    objInsAddres.AddressTypeTermID = new Guid(ddlAddressType.SelectedValue);
                        //else
                        //    objInsAddres.AddressTypeTermID = null;
                        objInsAddres.IsActive = true;

                        PropertyBLL.Save(objInsProperty, objInsAddres, lstDocuments);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objInsProperty.ToString(), objInsProperty.ToString(), "mst_Property");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.PropertyID = objInsProperty.PropertyID;
                    }
                    LoadData();
                    BindGrid();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("Property");
                Response.Redirect("~/Applications/SetUp/PropertyList.aspx");
                //ClearControl();
                //btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }
        #endregion Control Event

        #region Grid Event
        protected void grdPropertyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPropertyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";
            }
        }

        protected void gvDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    string DocumentName = string.Empty;
                    DocumentName = DataBinder.Eval(e.Row.DataItem, "DocumentName").ToString();
                    string str = "~/Document/" + DocumentName;

                    HtmlAnchor aDocumentLink = (HtmlAnchor)e.Row.FindControl("aDocumentLink");
                    ImageButton imgbtn = (ImageButton)e.Row.FindControl("btnDelete");



                    if (DocumentName != string.Empty && DocumentName != null)
                    {
                        imgbtn.Visible = Convert.ToBoolean(ViewState["Delete"]);
                        aDocumentLink.Visible = true;
                        aDocumentLink.HRef = str;
                    }
                    else
                    {
                        imgbtn.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvLandIssueDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    string DocumentName = string.Empty;
                    DocumentName = DataBinder.Eval(e.Row.DataItem, "DocumentName").ToString();
                    string str = "~/Document/" + DocumentName;

                    HtmlAnchor aDocumentLink = (HtmlAnchor)e.Row.FindControl("aDocumentLink");
                    ImageButton imgbtn = (ImageButton)e.Row.FindControl("btnDelete");



                    if (DocumentName != string.Empty && DocumentName != null)
                    {
                        imgbtn.Visible = Convert.ToBoolean(ViewState["Delete"]);
                        aDocumentLink.Visible = true;
                        aDocumentLink.HRef = str;
                    }
                    else
                    {
                        imgbtn.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPropertyYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PropertyID != Guid.Empty)
                {
                    msgbx.Hide();
                    List<Documents> lstDocuments = new List<Documents>();
                    Property objDelete = PropertyBLL.GetByPrimaryKey(this.PropertyID);
                    Property objOldPropertyDeleteData = PropertyBLL.GetByPrimaryKey(this.PropertyID);

                    objDelete.IsActive = false;

                    Guid AddressID = (Guid)(objDelete.AddressID);
                    Address objDelAddress = new Address();
                    objDelAddress = AddressBLL.GetByPrimaryKey(AddressID);
                    objDelAddress.IsActive = false;

                    //PropertyBLL.Update(objDelete, objDelAddress, lstDocuments);
                    PropertyBLL.Delete(objDelete);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objOldPropertyDeleteData.ToString(), null, "mst_Property");

                    IsMessage = true;
                    lblErrorMessage.Text = "Delete Success.";
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPropertyNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event

        protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                this.PropertyID = this.PropertyID;
                Session.Add("Property", this.PropertyID);
                //LoadData();
                LoadDocumentGrid();
            }
        }

        protected void gvLandIssueDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                this.PropertyID = this.PropertyID;
                Session.Add("Property", this.PropertyID);
                //LoadData();
                LoadDocumentGrid();
            }
        }

    }
}