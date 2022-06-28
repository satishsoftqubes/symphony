using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlPOSPoints : System.Web.UI.UserControl
    {
        #region Variable & Property

        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        public Guid POSPointID
        {
            get
            {
                return ViewState["POSPointID"] != null ? new Guid(Convert.ToString(ViewState["POSPointID"])) : Guid.Empty;
            }
            set
            {
                ViewState["POSPointID"] = value;
            }

        }

        public string VCategoryID
        {
            get
            {
                return ViewState["VCategoryID"] != null ? Convert.ToString(ViewState["VCategoryID"]) : string.Empty;
            }
            set
            {
                ViewState["VCategoryID"] = value;
            }

        }

        public int RowIndex
        {
            get
            {
                return ViewState["RowIndex"] != null ? Convert.ToInt32(ViewState["RowIndex"]) : 0;
            }
            set
            {
                ViewState["RowIndex"] = value;
            }

        }

        public string strCategoryID
        {
            get
            {
                return ViewState["strCategoryID"] != null ? Convert.ToString(ViewState["strCategoryID"]) : string.Empty;
            }
            set
            {
                ViewState["strCategoryID"] = value;
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

        DataTable dtDynamic;
        DataTable dtCategories;

        public DataView dvExistingDetails = null;

        #endregion Variable & Property

        #region Form Load
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                Session["objItemList"] = null;
                CheckUserAuthorization();
                LoadDefaultValue();
            }

        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "POSPOINTS.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddTopPOSPoints.Visible = btnAddBottomPOSPoints.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        /// <summary>
        /// Set Form Header
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblMainHeader", "POS Points");
            litSearchPOSPointsName.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblSearchPOSPointsName", "POS Points Name");
            litSearchPOSLocation.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblSearchPOSLocation", "POS Group");
            btnAddTopPOSPoints.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnAddBottomPOSPoints.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litPOSPoints.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblPOSPoints", "POS Points List");

            chkIsTouchScreenEnable.Text = clsCommon.GetGlobalResourceText("POSPoints", "chkIsTouchScreenEnable", "Touch Screen Enable");
            chkIsActivityPOS.Text = clsCommon.GetGlobalResourceText("POSPoints", "chkIsActivityPOS", "Active POS");
            ////chkConsumablePOS.Text = clsCommon.GetGlobalResourceText("POSPoints", "chkConsumablePOS", "Consumable POS");

            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            //btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblConfirmDeleteMsg", "Sure Want To Delete?");
            litPOSPointsName.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblPOSPointsName", "Point Name");
            litDisplayName.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblDisplayName", "Display Name");
            litLocation.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblLocation", "POS Group");
            litDefaultCounter.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblDefaultCounter", "Default Counter");
            litDefaultUser.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblDefaultUser", "Default User");
            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("POsPoints", "lblHeaderConfirmDeletePopup", "POS Points");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");

            litVendor.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblVendorName", "Vendor Name");

            litHeaderCustomePopupMessage.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblHeaderCustomePopupMsg", "Item Setup");
            litCustomePopupMsg.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblCustomePopupMsg", "Please Insert Rate");

            litItemList.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblItemList", "Item List");
            btnmpeSubmit.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblBtnSubmit", "Submit");
            btnmpeClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnClose", "Close");

        }

        private void LoadDefaultValue()
        {
            mvPosPoints.ActiveViewIndex = 0;
            SetPageLabels();
            //BindVendor();
            LoadUser();
            LoadCounter();
            LoadTerm();
            BindGrid();
            BindVendor();
            //BindCategoryTreeviewGrid();            
            BindBreadCrumb();
        }
        /// <summary>
        /// Bind POS Point Grid
        /// </summary>
        private void BindGrid()
        {
            string PointName = null;
            Guid? LocationTermID = null;
            if (!txtSPOSPointsName.Text.Equals(""))
                PointName = txtSPOSPointsName.Text.Trim();
            else
                PointName = null;
            if (!ddlSPOSLocation.SelectedValue.Equals(Guid.Empty.ToString()))
                LocationTermID = new Guid(ddlSPOSLocation.SelectedValue.ToString());
            else
                LocationTermID = null;

            DataSet Dst = POSPointsBLL.SearchData(clsSession.CompanyID, clsSession.PropertyID, PointName, LocationTermID);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv.Sort = "POSPointName ASC";
            gvPOSPoints.DataSource = Dv;
            gvPOSPoints.DataBind();
        }
        /// <summary>
        /// Bind User From User Master
        /// </summary>
        private void LoadUser()
        {
            User Usr = new User();
            Usr.CompanyID = clsSession.CompanyID;
            Usr.PropertyID = clsSession.PropertyID;
            Usr.IsActive = true;
            List<User> lstUser = UserBLL.GetAll(Usr);
            if (lstUser.Count > 0)
            {
                lstUser.Sort((User r1, User r2) => r1.UserName.CompareTo(r2.UserName));
                ddlDefaultUser.DataSource = lstUser;
                ddlDefaultUser.DataTextField = "UserName";
                ddlDefaultUser.DataValueField = "UsearID";
                ddlDefaultUser.DataBind();
                ddlDefaultUser.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlDefaultUser.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Load Counter Information
        /// </summary>
        private void LoadCounter()
        {
            Counters Cnt = new Counters();
            Cnt.CompanyID = clsSession.CompanyID;
            Cnt.PropertyID = clsSession.PropertyID;
            Cnt.IsActive = true;

            List<Counters> LstCounter = CountersBLL.GetAll(Cnt);
            if (LstCounter.Count > 0)
            {
                LstCounter.Sort((Counters r1, Counters r2) => r1.CounterNo.CompareTo(r2.CounterNo));
                ddlDefaultCounter.DataSource = LstCounter;
                ddlDefaultCounter.DataTextField = "CounterNo";
                ddlDefaultCounter.DataValueField = "CounterID";
                ddlDefaultCounter.DataBind();
                ddlDefaultCounter.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlDefaultCounter.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Load Term
        /// </summary>
        private void LoadTerm()
        {
            ProjectTerm objProjTerm = new ProjectTerm();
            objProjTerm.Category = "TRANSACTION ZONE";
            objProjTerm.PropertyID = clsSession.PropertyID;
            objProjTerm.CompanyID = clsSession.CompanyID;
            objProjTerm.IsActive = true;

            List<ProjectTerm> lstCurrency = ProjectTermBLL.GetAll(objProjTerm);
            if (lstCurrency.Count > 0)
            {
                lstCurrency.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlLocation.DataSource = lstCurrency;
                ddlLocation.DataTextField = "DisplayTerm";
                ddlLocation.DataValueField = "TermID";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                ddlSPOSLocation.DataSource = lstCurrency;
                ddlSPOSLocation.DataTextField = "DisplayTerm";
                ddlSPOSLocation.DataValueField = "TermID";
                ddlSPOSLocation.DataBind();
                ddlSPOSLocation.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));

            }
            else
            {
                ddlLocation.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSPOSLocation.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }
        /// <summary>
        /// Clear Control Information
        /// </summary>
        private void ClearControl()
        {
            txtDisplayName.Text = txtPOSPointsName.Text = "";
            ddlDefaultCounter.SelectedValue = ddlDefaultUser.SelectedValue = ddlLocation.SelectedValue = Guid.Empty.ToString();
            ////chkConsumablePOS.Checked = chkIsActivityPOS.Checked = chkIsTouchScreenEnable.Checked = false;
            chkIsActivityPOS.Checked = chkIsTouchScreenEnable.Checked = false;
            ddlVendor.SelectedIndex = 0;
            this.POSPointID = Guid.Empty;
            this.strCategoryID = string.Empty;
            BindCategoryTreeviewGrid();
            gvItem.DataSource = null;
            gvItem.DataBind();
            Session["objItemList"] = null;
            this.RowIndex = 0;
        }

        private void ClearSearchControl()
        {
            txtSPOSPointsName.Text = "";
            ddlSPOSLocation.SelectedIndex = 0;
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
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPOSSetup", "POS Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPOSPoints", "POS Points");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Save and UPdate Information
        /// </summary>
        private void SaveAndUpdateCurrency()
        {
            POSPoints IsPOSPoint = new POSPoints();
            IsPOSPoint.IsActive = true;
            IsPOSPoint.POSPointName = txtPOSPointsName.Text.Trim();
            IsPOSPoint.PropertyID = clsSession.PropertyID;
            IsPOSPoint.CompanyID = clsSession.CompanyID;
            List<POSPoints> LstPoint = null;
            LstPoint = POSPointsBLL.GetAll(IsPOSPoint);

            if (LstPoint.Count > 0)
            {
                if (this.POSPointID != Guid.Empty)
                {
                    if (LstPoint[0].POSPointID != this.POSPointID)
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    return;
                }
            }

            if (this.POSPointID != Guid.Empty)
            {
                POSPoints objUpd = new POSPoints();
                POSPoints objOldCurr = new POSPoints();
                objUpd = POSPointsBLL.GetByPrimaryKey(this.POSPointID);
                objOldCurr = POSPointsBLL.GetByPrimaryKey(this.POSPointID);

                objUpd.POSPointName = txtPOSPointsName.Text.Trim();
                objUpd.PointDisplayName = txtDisplayName.Text.Trim();

                if (ddlLocation.SelectedIndex != 0)
                    objUpd.POSLocation_TermID = new Guid(Convert.ToString(ddlLocation.SelectedValue));
                else
                    objUpd.POSLocation_TermID = null;

                if (ddlDefaultUser.SelectedIndex != 0)
                    objUpd.DefaultUserID = new Guid(Convert.ToString(ddlDefaultUser.SelectedValue));
                else
                    objUpd.DefaultUserID = null;

                if (ddlDefaultCounter.SelectedIndex != 0)
                    objUpd.DefaultCounterID = new Guid(Convert.ToString(ddlDefaultCounter.SelectedValue));
                else
                    objUpd.DefaultCounterID = null;

                objUpd.PointDisplayName = txtDisplayName.Text.Trim();

                objUpd.IsTouchScreenEnable = chkIsTouchScreenEnable.Checked;
                objUpd.IsActivityPOS = chkIsActivityPOS.Checked;
                ////objUpd.IsConsumablePOS = chkConsumablePOS.Checked;

                objUpd.CompanyID = clsSession.CompanyID;
                objUpd.PropertyID = clsSession.PropertyID;
                objUpd.IsSynch = false;
                objUpd.IsActive = true;
                objUpd.UpdatedOn = DateTime.Now;
                objUpd.UpdatedBy = clsSession.UserID;

                POSPointsBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_POSPoint");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            }
            else
            {
                POSPoints objIns = new POSPoints();
                objIns.POSPointName = txtPOSPointsName.Text.Trim();
                objIns.PointDisplayName = txtDisplayName.Text.Trim();

                if (ddlLocation.SelectedIndex != 0)
                    objIns.POSLocation_TermID = new Guid(Convert.ToString(ddlLocation.SelectedValue));

                if (ddlDefaultUser.SelectedIndex != 0)
                    objIns.DefaultUserID = new Guid(Convert.ToString(ddlDefaultUser.SelectedValue));

                if (ddlDefaultCounter.SelectedIndex != 0)
                    objIns.DefaultCounterID = new Guid(Convert.ToString(ddlDefaultCounter.SelectedValue));

                ////objIns.POSLocation_TermID = new Guid(Convert.ToString(ddlLocation.SelectedValue));

                if (ddlDefaultUser.SelectedIndex != 0)
                    objIns.DefaultUserID = new Guid(ddlDefaultUser.SelectedValue);
                if (ddlDefaultCounter.SelectedIndex != 0)
                    objIns.DefaultCounterID = new Guid(ddlDefaultCounter.SelectedValue);
                objIns.PointDisplayName = txtDisplayName.Text.Trim();
                objIns.IsTouchScreenEnable = chkIsTouchScreenEnable.Checked;
                objIns.IsActivityPOS = chkIsActivityPOS.Checked;
                ////objIns.IsConsumablePOS = chkConsumablePOS.Checked;

                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.IsSynch = false;
                objIns.IsActive = true;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;
                POSPointsBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_POSPoint");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

            }
            BindGrid();
        }

        private void BindVendor()
        {
            ServiceVendorMaster objServiceVendorMaster = new ServiceVendorMaster();
            objServiceVendorMaster.CompanyID = clsSession.CompanyID;
            objServiceVendorMaster.PropertyID = clsSession.PropertyID;
            objServiceVendorMaster.IsActive = true;

            List<ServiceVendorMaster> LstCounter = ServiceVendorMasterBLL.GetAll(objServiceVendorMaster);
            if (LstCounter.Count > 0)
            {
                LstCounter.Sort((ServiceVendorMaster r1, ServiceVendorMaster r2) => r1.ContactPersonName.CompareTo(r2.ContactPersonName));
                ddlVendor.DataSource = LstCounter;
                ddlVendor.DataTextField = "ContactPersonName";
                ddlVendor.DataValueField = "VendorID";
                ddlVendor.DataBind();
                ddlVendor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlVendor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void BindCategoryTreeviewGrid()
        {
            try
            {
                DataSet dsCategory = CategoryBLL.GetCategoryData(null, clsSession.PropertyID, clsSession.CompanyID, null, null, null);
                if (dsCategory.Tables[0] != null && dsCategory.Tables[0].Rows.Count > 0)
                {
                    DataTable dtTopParents = dsCategory.Tables[0];

                    if (dsCategory.Tables[1] != null && dsCategory.Tables[1].Rows.Count > 0)
                    {
                        dtCategories = dsCategory.Tables[1];
                    }

                    dtDynamic = new DataTable();

                    DataColumn dc1 = new DataColumn("CategoryID");
                    DataColumn dc2 = new DataColumn("CategoryCode");
                    DataColumn dc3 = new DataColumn("CategoryName");
                    DataColumn dc4 = new DataColumn("ParentCategory");
                    DataColumn dc5 = new DataColumn("Level");

                    dtDynamic.Columns.Add(dc1);
                    dtDynamic.Columns.Add(dc2);
                    dtDynamic.Columns.Add(dc3);
                    dtDynamic.Columns.Add(dc4);
                    dtDynamic.Columns.Add(dc5);

                    foreach (DataRow dr in dtTopParents.Rows)
                    {
                        DataRow drDynamic = dtDynamic.NewRow();
                        drDynamic["CategoryID"] = Convert.ToString(dr["CategoryID"]);
                        drDynamic["CategoryCode"] = Convert.ToString(dr["CategoryCode"]);
                        drDynamic["CategoryName"] = Convert.ToString(dr["CategoryName"]);
                        drDynamic["ParentCategory"] = "";
                        drDynamic["Level"] = "0";

                        dtDynamic.Rows.Add(drDynamic);

                        RecursiveBindDynamicTable(Convert.ToString(drDynamic["CategoryID"]));
                    }

                    gvCategories.DataSource = dtDynamic;
                    gvCategories.DataBind();


                }
                else
                {
                    gvCategories.DataSource = null;
                    gvCategories.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void RecursiveBindDynamicTable(string parentCategoryID)
        {
            if (dtCategories != null && dtCategories.Rows.Count > 0)
            {
                DataRow[] rows = dtCategories.Select("RefCategoryID = '" + parentCategoryID + "'");

                foreach (DataRow dr in rows)
                {
                    DataRow drDynamic = dtDynamic.NewRow();
                    drDynamic["CategoryID"] = Convert.ToString(dr["CategoryID"]);
                    drDynamic["CategoryCode"] = Convert.ToString(dr["CategoryCode"]);
                    drDynamic["CategoryName"] = Convert.ToString(dr["CategoryName"]);
                    drDynamic["ParentCategory"] = parentCategoryID;

                    DataRow[] rowsLevel = dtDynamic.Select("CategoryID = '" + parentCategoryID + "'");

                    int intParentLevel = 0;
                    if (rowsLevel != null && rowsLevel.Length != 0)
                    {
                        intParentLevel = Convert.ToInt32(rowsLevel[0]["Level"].ToString());
                    }

                    drDynamic["Level"] = Convert.ToString(intParentLevel + 1);

                    dtDynamic.Rows.Add(drDynamic);


                    RecursiveBindDynamicTable(Convert.ToString(drDynamic["CategoryID"]));
                }
            }
        }

        private void BindSelectedItemandRate()
        {
            ItemAvailability objLoadItemAvailability = new ItemAvailability();
            objLoadItemAvailability.POSPointID = this.POSPointID;

            DataSet dsItemAvailability = new DataSet();

            if (this.strCategoryID != string.Empty && this.POSPointID != Guid.Empty)
            {
                string strGetItemData = "select ItemID,CategoryID,ItemAvailabilityID,ServiceRate,POSPointID from mst_ItemAvailability where POSPointID = '" + Convert.ToString(this.POSPointID) + "' and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";
                dsItemAvailability = POSPointsBLL.SelectPosPoints(strGetItemData);
            }

            //dsItemAvailability = ItemAvailabilityBLL.GetAllWithDataSet(objLoadItemAvailability);

            if (dsItemAvailability != null)
            {
                if (dsItemAvailability.Tables[0].Rows.Count != 0)
                {
                    dvExistingDetails = new DataView();
                    dvExistingDetails = dsItemAvailability.Tables[0].DefaultView;
                }
            }

            if (dsItemAvailability.Tables[0] != null && dsItemAvailability.Tables[0].Rows.Count != 0)
            {

                for (int j = 0; j < gvItem.Rows.Count; j++)
                {
                    GridViewRow row = gvItem.Rows[j];

                    DataRow[] rows = dsItemAvailability.Tables[0].Select("ItemID = '" + gvItem.DataKeys[j]["ItemID"].ToString() + "'");

                    if (rows.Length > 0)
                    {
                        ((CheckBox)row.FindControl("chkSelectItem")).Checked = true;
                    }
                }
            }
        }
        #endregion Private Method

        #region Add New Button Event
        /// <summary>
        /// Add New Click For Top Button
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTopPOSPoints_Click(object sender, EventArgs e)
        {
            //btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";            
            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();
            mvPosPoints.ActiveViewIndex = 1;
        }

        #endregion Add Nwe Button Event

        #region Grid Event
        /// <summary>
        /// Grid Data Bound Event 
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvPOSPoints_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                ((LinkButton)e.Row.FindControl("lnkDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "POSPointID")));

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");


            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Label)e.Row.FindControl("lblGvHdrPointName")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrPointName", "Point Name");
                ((Label)e.Row.FindControl("lblGvHdrDispalyName")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrDispalyName", "Display Name");
                ((Label)e.Row.FindControl("lblGvHdrLocation")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrLocation", "POS Group");
                ((Label)e.Row.FindControl("lblGvHdrViewDelete")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Label)e.Row.FindControl("lblGvHdrCounter")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrCounter", "Counter Name");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }
        /// <summary>
        /// Grid Page INdex Change Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewPageEventArgs</param>
        protected void gvPOSPoints_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPOSPoints.PageIndex = e.NewPageIndex;
        }
        /// <summary>
        /// Row Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewCommandEevntArgs</param>
        protected void gvPOSPoints_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    //btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
                    mvPosPoints.ActiveViewIndex = 1;
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.POSPointID = new Guid(Convert.ToString(e.CommandArgument));
                    POSPoints Get = POSPointsBLL.GetByPrimaryKey(this.POSPointID);
                    if (Get != null)
                    {
                        txtDisplayName.Text = Convert.ToString(Get.PointDisplayName);
                        txtPOSPointsName.Text = Convert.ToString(Get.POSPointName);

                        ddlDefaultCounter.SelectedIndex = ddlDefaultCounter.Items.FindByValue(Convert.ToString(Get.DefaultCounterID)) != null ? ddlDefaultCounter.Items.IndexOf(ddlDefaultCounter.Items.FindByValue(Convert.ToString(Get.DefaultCounterID))) : 0;
                        ddlLocation.SelectedIndex = ddlLocation.Items.FindByValue(Convert.ToString(Get.POSLocation_TermID)) != null ? ddlLocation.Items.IndexOf(ddlLocation.Items.FindByValue(Convert.ToString(Get.POSLocation_TermID))) : 0;
                        ddlDefaultUser.SelectedIndex = ddlDefaultUser.Items.FindByValue(Convert.ToString(Get.DefaultUserID)) != null ? ddlDefaultUser.Items.IndexOf(ddlDefaultUser.Items.FindByValue(Convert.ToString(Get.DefaultUserID))) : 0;
                        ddlVendor.SelectedIndex = ddlVendor.Items.FindByValue(Convert.ToString(Get.VendorID)) != null ? ddlVendor.Items.IndexOf(ddlVendor.Items.FindByValue(Convert.ToString(Get.VendorID))) : 0;

                        ////chkConsumablePOS.Checked = Convert.ToBoolean(Get.IsConsumablePOS);
                        chkIsActivityPOS.Checked = Convert.ToBoolean(Get.IsActivityPOS);
                        chkIsTouchScreenEnable.Checked = Convert.ToBoolean(Get.IsTouchScreenEnable);

                        BindCategoryTreeviewGrid();

                        DataSet dsGetData = ItemAvailabilityBLL.SelectDataByPosPointsID(this.POSPointID);

                        if (dsGetData.Tables.Count > 0)
                        {
                            if (dsGetData.Tables[0] != null && dsGetData.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < gvCategories.Rows.Count; i++)
                                {
                                    GridViewRow row = gvCategories.Rows[i];

                                    DataRow[] rows = dsGetData.Tables[0].Select("CategoryID = '" + gvCategories.DataKeys[i]["CategoryID"].ToString() + "'");
                                    HiddenField hdnFromDB = (HiddenField)gvCategories.Rows[i].FindControl("hdnFromDB");

                                    if (rows.Length > 0)
                                    {
                                        ((CheckBox)row.FindControl("chkSelectCategory")).Checked = true;
                                        hdnFromDB.Value = "TRUE";
                                        gvCategories.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ECECEC");
                                    }
                                    else
                                        hdnFromDB.Value = "FALSE";
                                }
                            }

                            if (dsGetData.Tables[1] != null && dsGetData.Tables[1].Rows.Count > 0)
                            {
                                gvItem.DataSource = Session["objItemList"] = new DataView(dsGetData.Tables[1]);
                                gvItem.DataBind();
                            }
                            else
                            {
                                gvItem.DataSource = Session["objItemList"] = null;
                                gvItem.DataBind();
                            }

                        }


                        //CategoryPOSPoints objLoadCategoryPOSPoints = new CategoryPOSPoints();
                        //objLoadCategoryPOSPoints.POSPointID = this.POSPointID;
                        //objLoadCategoryPOSPoints.IsActive = true;

                        //DataSet dsCategoryPosPoints = new DataSet();
                        //dsCategoryPosPoints = CategoryPOSPointsBLL.GetAllWithDataSet(objLoadCategoryPOSPoints);

                        //if (dsCategoryPosPoints.Tables[0].Rows.Count != 0)
                        //{
                        //    for (int i = 0; i < gvCategories.Rows.Count; i++)
                        //    {
                        //        GridViewRow row = gvCategories.Rows[i];

                        //        DataRow[] rows = dsCategoryPosPoints.Tables[0].Select("CategoryID = '" + gvCategories.DataKeys[i]["CategoryID"].ToString() + "'");

                        //        if (rows.Length > 0)
                        //        {
                        //            ((CheckBox)row.FindControl("chkSelectCategory")).Checked = true;

                        //            //if (this.strCategoryID != string.Empty)
                        //            //    this.strCategoryID += ",'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                        //            //else
                        //            //    this.strCategoryID = "'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                        //        }
                        //    }
                        //}



                        //ItemAvailability objLoadItemAvailability = new ItemAvailability();
                        //objLoadItemAvailability.POSPointID = this.POSPointID;

                        //DataSet dsItemAvailability = new DataSet();

                        //if (this.strCategoryID != string.Empty && this.POSPointID != Guid.Empty)
                        //{
                        //    string strGetItemData = "select ItemID,CategoryID,ItemAvailabilityID,ServiceRate,POSPointID from mst_ItemAvailability where POSPointID = '" + Convert.ToString(this.POSPointID) + "' and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";
                        //    dsItemAvailability = POSPointsBLL.SelectPosPoints(strGetItemData);
                        //}

                        //if (dsItemAvailability.Tables.Count != 0)
                        //{
                        //    if (dsItemAvailability.Tables[0].Rows.Count != 0)
                        //    {
                        //        dvExistingDetails = new DataView();
                        //        dvExistingDetails = dsItemAvailability.Tables[0].DefaultView;
                        //    }
                        //}

                        //if (this.strCategoryID != string.Empty)
                        //{
                        //    string strItemQuery = "select mst_ItemCategory.ItemCategoryID,mst_ItemCategory.ItemID,mst_ItemCategory.CategoryID,mst_Item.ItemName,mst_Item.DefSalesPrice from mst_ItemCategory left outer join mst_Item on mst_Item.ItemID = mst_ItemCategory.ItemID where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and IsActive = 1 and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";
                        //    DataSet dsLoadItem = POSPointsBLL.SelectPosPoints(strItemQuery);

                        //    if (dsLoadItem.Tables.Count > 0)
                        //    {
                        //        if (dsLoadItem.Tables[0].Rows.Count > 0)
                        //        {
                        //            DataTable dtLoadItemList = new System.Data.DataTable();

                        //            DataColumn clItemID = new DataColumn("ItemID");
                        //            dtLoadItemList.Columns.Add(clItemID);

                        //            DataColumn clCategoryID = new DataColumn("CategoryID");
                        //            dtLoadItemList.Columns.Add(clCategoryID);

                        //            DataColumn clItemName = new DataColumn("ItemName");
                        //            dtLoadItemList.Columns.Add(clItemName);

                        //            DataColumn clItemPrice = new DataColumn("ItemPrice");
                        //            dtLoadItemList.Columns.Add(clItemPrice);

                        //            DataColumn clSelect = new DataColumn("Select");
                        //            dtLoadItemList.Columns.Add(clSelect);

                        //            for (int j = 0; j < dsLoadItem.Tables[0].Rows.Count; j++)
                        //            {
                        //                string strSelection = "0";

                        //                DataRow[] rows = dsItemAvailability.Tables[0].Select("ItemID = '" + dsLoadItem.Tables[0].Rows[j]["ItemID"].ToString() + "' And CategoryID = '" + dsLoadItem.Tables[0].Rows[j]["CategoryID"].ToString() + "' And POSPointID = '" + this.POSPointID + "'");

                        //                if (rows.Length > 0)
                        //                    strSelection = "1";

                        //                DataRow drRow = dtLoadItemList.NewRow();

                        //                drRow["ItemID"] = Convert.ToString(dsLoadItem.Tables[0].Rows[j]["ItemID"]);
                        //                drRow["CategoryID"] = Convert.ToString(dsLoadItem.Tables[0].Rows[j]["CategoryID"]);
                        //                drRow["ItemName"] = Convert.ToString(dsLoadItem.Tables[0].Rows[j]["ItemName"]);
                        //                drRow["ItemPrice"] = Convert.ToString(dsLoadItem.Tables[0].Rows[j]["DefSalesPrice"]);
                        //                drRow["Select"] = Convert.ToString(strSelection);
                        //                dtLoadItemList.Rows.Add(drRow);
                        //            }

                        //            gvItem.DataSource = dtLoadItemList;
                        //            gvItem.DataBind();
                        //        }
                        //    }
                        //}

                        ////BindItemByCategoryWise();

                        ////if (dsItemAvailability.Tables.Count != 0)
                        ////{
                        ////    if (dsItemAvailability.Tables[0] != null && dsItemAvailability.Tables[0].Rows.Count != 0)
                        ////    {

                        ////        for (int j = 0; j < gvItem.Rows.Count; j++)
                        ////        {
                        ////            GridViewRow row = gvItem.Rows[j];

                        ////            DataRow[] rows = dsItemAvailability.Tables[0].Select("ItemID = '" + gvItem.DataKeys[j]["ItemID"].ToString() + "' And CategoryID = '" + gvItem.DataKeys[j]["CategoryID"].ToString() + "' And POSPointID = '" + this.POSPointID + "'");

                        ////            if (rows.Length > 0)
                        ////            {
                        ////                ((CheckBox)row.FindControl("chkSelectItem")).Checked = true;
                        ////            }
                        ////        }
                        ////    }
                        ////}
                    }
                }
                else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
                {
                    this.POSPointID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCategories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblCategoryName = (Label)e.Row.FindControl("lblCategoryName");

                    string strSpace = string.Empty;
                    int level = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Level").ToString());
                    for (int i = 0; i < level * 8; i++)
                    {
                        strSpace += "&nbsp;";
                    }

                    if (level == 0)
                        lblCategoryName.Text = strSpace + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CategoryName"));
                    else
                        lblCategoryName.Text = strSpace + "<img src='../../images/arrow_03.png' alt='' />" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CategoryName"));

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrSelect", "Select");
                    //((Label)e.Row.FindControl("lblGvHdrCategoryCode")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryCode", "Category Code");
                    ((Label)e.Row.FindControl("lblGvHdrCategoryName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryName", "Category Name");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblItemRate = (Label)e.Row.FindControl("lblItemRate");
                    CheckBox chkSelectItem = (CheckBox)e.Row.FindControl("chkSelectItem");

                    string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemPrice"));

                    if (strRate != string.Empty)
                    {
                        if (strRate.IndexOf(".") != -1)
                            lblItemRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                        else
                            lblItemRate.Text = Convert.ToString(strRate);
                    }
                    else
                        lblItemRate.Text = "";

                    //if (this.POSPointID != Guid.Empty)
                    //{
                    //    Guid idItemID = new Guid(gvItem.DataKeys[e.Row.RowIndex]["ItemID"].ToString());
                    //    Guid idCategoryID = new Guid(gvItem.DataKeys[e.Row.RowIndex]["CategoryID"].ToString());

                    //    if (dvExistingDetails != null)
                    //    {
                    //        dvExistingDetails.RowFilter = "ItemID = '" + idItemID + "'AND POSPointID ='" + this.POSPointID + "' AND CategoryID = '" + idCategoryID + "' ";

                    //        if (dvExistingDetails.Count > 0)
                    //        {
                    //            string strServiceRate = Convert.ToString(dvExistingDetails[0]["ServiceRate"]);


                    //            string strcheck = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Select"));

                    //            if (strcheck == "0")
                    //                chkSelectItem.Checked = false;
                    //            else
                    //                chkSelectItem.Checked = true;

                    //            if (strServiceRate != string.Empty)
                    //                lblItemRate.Text = Convert.ToString(strServiceRate.ToString().Substring(0, strServiceRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                    //            else
                    //                lblItemRate.Text = "";
                    //        }
                    //        else
                    //        {
                    //            ////string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefSalesPrice"));

                    //            string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemPrice"));
                    //            string strcheck = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Select"));

                    //            if (strcheck == "0")
                    //                chkSelectItem.Checked = false;
                    //            else
                    //                chkSelectItem.Checked = true;

                    //            if (strRate != string.Empty)
                    //                lblItemRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                    //            else
                    //                lblItemRate.Text = "";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        ////string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefSalesPrice"));

                    //        string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemPrice"));
                    //        string strcheck = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Select"));

                    //        if (strcheck == "0")
                    //            chkSelectItem.Checked = false;
                    //        else
                    //            chkSelectItem.Checked = true;

                    //        if (strRate != string.Empty)
                    //            lblItemRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                    //        else
                    //            lblItemRate.Text = "";
                    //    }
                    //}
                    //else
                    //{
                    //    ////string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefSalesPrice"));

                    //   // string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemPrice"));
                    //    //string strcheck = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Select"));

                    //    //if (strcheck == "0")
                    //    //    chkSelectItem.Checked = false;
                    //    //else
                    //    //    chkSelectItem.Checked = true;

                    //    if (strRate != string.Empty)
                    //        lblItemRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                    //    else
                    //        lblItemRate.Text = "";
                    //}
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    //((Label)e.Row.FindControl("lblGvHdrSelectItem")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrSelect", "Select");                    
                    ((Label)e.Row.FindControl("lblGvHdrCategoryName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryName", "Category Name");
                    ((Label)e.Row.FindControl("lblGvHdrItemName")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrItemName", "Item Name");
                    ((Label)e.Row.FindControl("lblGvHdrItemRate")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrItemRate", "Rate");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblItemNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event

        #region CheckBox Event

        private void BindItemByCategoryWise()
        {
            this.strCategoryID = string.Empty;

            for (int i = 0; i < gvCategories.Rows.Count; i++)
            {
                CheckBox chkSelectCategory = (CheckBox)gvCategories.Rows[i].FindControl("chkSelectCategory");
                if (chkSelectCategory.Checked)
                {
                    if (this.strCategoryID != string.Empty)
                        this.strCategoryID += ",'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                    else
                        this.strCategoryID = "'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                }
            }

            if (this.strCategoryID == string.Empty)
            {
                gvItem.DataSource = null;
                gvItem.DataBind();
            }
            else
            {
                string strItemQuery = "select mst_ItemCategory.ItemCategoryID,mst_ItemCategory.ItemID,mst_ItemCategory.CategoryID,mst_Item.ItemName,mst_Item.DefSalesPrice from mst_ItemCategory left outer join mst_Item on mst_Item.ItemID = mst_ItemCategory.ItemID where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and IsActive = 1 and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";

                if (this.strCategoryID != string.Empty && this.POSPointID != Guid.Empty)
                {
                    string strGetItemData = "select ItemID,CategoryID,ItemAvailabilityID,ServiceRate,POSPointID from mst_ItemAvailability where POSPointID = '" + Convert.ToString(this.POSPointID) + "' and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";
                    DataSet dsData = POSPointsBLL.SelectPosPoints(strGetItemData);

                    if (dsData != null)
                    {
                        if (dsData.Tables[0].Rows.Count != 0)
                        {
                            dvExistingDetails = new DataView();
                            dvExistingDetails = dsData.Tables[0].DefaultView;
                        }
                    }
                }

                DataSet dsItem = POSPointsBLL.SelectPosPoints(strItemQuery);

                if (dsItem.Tables[0] != null && dsItem.Tables[0].Rows.Count > 0)
                {
                    gvItem.DataSource = dsItem.Tables[0];
                    gvItem.DataBind();
                }
                else
                {
                    gvItem.DataSource = null;
                    gvItem.DataBind();
                }
            }
        }

        protected void chkSelectCategory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.POSPointID != Guid.Empty)
                {
                    this.strCategoryID = string.Empty;

                    for (int i = 0; i < gvCategories.Rows.Count; i++)
                    {
                        CheckBox chkCheckSelectCategory = (CheckBox)gvCategories.Rows[i].FindControl("chkSelectCategory");
                        if (chkCheckSelectCategory.Checked)
                        {
                            if (this.strCategoryID != string.Empty)
                                this.strCategoryID += ",'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                            else
                                this.strCategoryID = "'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                        }
                    }

                    if (this.strCategoryID != string.Empty)
                    {
                        string strGetItemData = "select ItemID,CategoryID,ItemAvailabilityID,ServiceRate,POSPointID from mst_ItemAvailability where POSPointID = '" + Convert.ToString(this.POSPointID) + "' and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";
                        DataSet dsData = POSPointsBLL.SelectPosPoints(strGetItemData);

                        if (dsData != null)
                        {
                            if (dsData.Tables[0].Rows.Count != 0)
                            {
                                dvExistingDetails = new DataView();
                                dvExistingDetails = dsData.Tables[0].DefaultView;
                            }
                        }
                    }
                }

                CheckBox chkSelectCategory = (CheckBox)sender;
                GridViewRow gr = (GridViewRow)chkSelectCategory.Parent.Parent;

                string CategoryID = gvCategories.DataKeys[gr.RowIndex].Value.ToString();

                DataTable dtSessionItemList = new System.Data.DataTable();

                DataColumn clItemID = new DataColumn("ItemID");
                dtSessionItemList.Columns.Add(clItemID);

                DataColumn clCategoryID = new DataColumn("CategoryID");
                dtSessionItemList.Columns.Add(clCategoryID);

                DataColumn clItemName = new DataColumn("ItemName");
                dtSessionItemList.Columns.Add(clItemName);

                DataColumn clItemPrice = new DataColumn("ItemPrice");
                dtSessionItemList.Columns.Add(clItemPrice);

                DataColumn clSelect = new DataColumn("Select");
                dtSessionItemList.Columns.Add(clSelect);

                for (int i = 0; i < gvItem.Rows.Count; i++)
                {
                    Label lblGvItemName = (Label)gvItem.Rows[i].FindControl("lblGvItemName");
                    TextBox txtItemRate = (TextBox)gvItem.Rows[i].FindControl("txtItemRate");
                    CheckBox chkSelectItem = (CheckBox)gvItem.Rows[i].FindControl("chkSelectItem");

                    string strItemRate = string.Empty;
                    if (txtItemRate.Text.Trim() != "")
                        strItemRate = Convert.ToString(txtItemRate.Text.Trim());
                    else
                        strItemRate = "0.00";

                    string strSelection = "0";
                    if (chkSelectItem.Checked)
                        strSelection = "1";
                    else
                        strSelection = "0";

                    DataRow drRow = dtSessionItemList.NewRow();

                    drRow["ItemID"] = Convert.ToString(gvItem.DataKeys[i]["ItemID"]);
                    drRow["CategoryID"] = Convert.ToString(gvItem.DataKeys[i]["CategoryID"]);
                    drRow["ItemName"] = Convert.ToString(lblGvItemName.Text);
                    drRow["ItemPrice"] = Convert.ToString(strItemRate);
                    drRow["Select"] = Convert.ToString(strSelection);
                    dtSessionItemList.Rows.Add(drRow);
                }

                string strItemQuery = "select mst_ItemCategory.ItemCategoryID,mst_ItemCategory.ItemID,mst_ItemCategory.CategoryID,mst_Item.ItemName,mst_Item.DefSalesPrice from mst_ItemCategory left outer join mst_Item on mst_Item.ItemID = mst_ItemCategory.ItemID where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and IsActive = 1 and cast(CategoryID as nvarchar(max)) in ('" + CategoryID + "')";

                DataSet dsItem = POSPointsBLL.SelectPosPoints(strItemQuery);

                if (chkSelectCategory.Checked)
                {
                    if (dsItem.Tables.Count > 0 && dsItem.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < dsItem.Tables[0].Rows.Count; j++)
                        {
                            DataRow drRow = dtSessionItemList.NewRow();

                            drRow["ItemID"] = Convert.ToString(dsItem.Tables[0].Rows[j]["ItemID"]);
                            drRow["CategoryID"] = Convert.ToString(dsItem.Tables[0].Rows[j]["CategoryID"]);
                            drRow["ItemName"] = Convert.ToString(dsItem.Tables[0].Rows[j]["ItemName"]);
                            drRow["ItemPrice"] = Convert.ToString(dsItem.Tables[0].Rows[j]["DefSalesPrice"]);
                            drRow["Select"] = Convert.ToString(0);
                            dtSessionItemList.Rows.Add(drRow);
                        }

                        gvItem.DataSource = Session["objItemList"] = dtSessionItemList;
                        gvItem.DataBind();
                    }
                    else
                    {
                        gvItem.DataSource = dtSessionItemList;
                        gvItem.DataBind();
                    }
                }
                else
                {
                    if (dsItem.Tables.Count > 0)
                    {
                        if (dsItem.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                            {
                                string strDeleteCategoryID = Convert.ToString(dsItem.Tables[0].Rows[i]["CategoryID"]);

                                for (int j = 0; j < dtSessionItemList.Rows.Count; j++)
                                {
                                    string strNewDeleteCategoryID = Convert.ToString(dtSessionItemList.Rows[j]["CategoryID"]);

                                    if (strDeleteCategoryID == strNewDeleteCategoryID)
                                    {
                                        dtSessionItemList.Rows.RemoveAt(j);
                                    }
                                }
                            }
                        }
                    }

                    gvItem.DataSource = dtSessionItemList;
                    gvItem.DataBind();
                }

                //BindItemByCategoryWise();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion CheckBox Event

        #region Form Button Event
        /// <summary>
        /// Save And Close POS Point Information
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateCurrency();
                    if (!IsDuplicateRecord)
                    {
                        IsListMessage = true;

                        if (this.POSPointID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Save POS Point Information
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    POSPoints IsPOSPoint = new POSPoints();
                    IsPOSPoint.IsActive = true;
                    IsPOSPoint.POSPointName = txtPOSPointsName.Text.Trim();
                    IsPOSPoint.PropertyID = clsSession.PropertyID;
                    IsPOSPoint.CompanyID = clsSession.CompanyID;
                    List<POSPoints> LstPoint = null;
                    LstPoint = POSPointsBLL.GetAll(IsPOSPoint);

                    if (LstPoint.Count > 0)
                    {
                        if (this.POSPointID != Guid.Empty)
                        {
                            if (LstPoint[0].POSPointID != this.POSPointID)
                            {
                                IsPopupMessage = true;
                                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsPopupMessage = true;
                            litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }

                    List<CategoryPOSPoints> lstCategoryPOSPoints = new List<CategoryPOSPoints>();
                    List<ItemAvailability> lstItemAvailability = new List<ItemAvailability>();

                    if (this.POSPointID != Guid.Empty)
                    {
                        POSPoints objUpd = new POSPoints();
                        POSPoints objOldCurr = new POSPoints();
                        objUpd = POSPointsBLL.GetByPrimaryKey(this.POSPointID);
                        objOldCurr = POSPointsBLL.GetByPrimaryKey(this.POSPointID);

                        objUpd.POSPointName = txtPOSPointsName.Text.Trim();
                        objUpd.PointDisplayName = txtDisplayName.Text.Trim();

                        if (ddlLocation.SelectedIndex != 0)
                            objUpd.POSLocation_TermID = new Guid(Convert.ToString(ddlLocation.SelectedValue));
                        else
                            objUpd.POSLocation_TermID = null;

                        if (ddlDefaultUser.SelectedIndex != 0)
                            objUpd.DefaultUserID = new Guid(Convert.ToString(ddlDefaultUser.SelectedValue));
                        else
                            objUpd.DefaultUserID = null;

                        if (ddlDefaultCounter.SelectedIndex != 0)
                            objUpd.DefaultCounterID = new Guid(Convert.ToString(ddlDefaultCounter.SelectedValue));
                        else
                            objUpd.DefaultCounterID = null;

                        if (ddlVendor.SelectedIndex != 0)
                            objUpd.VendorID = new Guid(ddlVendor.SelectedValue);
                        else
                            objUpd.VendorID = null;

                        objUpd.PointDisplayName = txtDisplayName.Text.Trim();

                        objUpd.IsTouchScreenEnable = chkIsTouchScreenEnable.Checked;
                        objUpd.IsActivityPOS = chkIsActivityPOS.Checked;
                        ////objUpd.IsConsumablePOS = chkConsumablePOS.Checked;

                        objUpd.CompanyID = clsSession.CompanyID;
                        objUpd.PropertyID = clsSession.PropertyID;
                        objUpd.IsSynch = false;
                        objUpd.IsActive = true;
                        objUpd.UpdatedOn = DateTime.Now;
                        objUpd.UpdatedBy = clsSession.UserID;

                        //if (strCategoryID != string.Empty)
                        //{
                        //    string strCategoryDelete = "delete from mst_CategoryPOSPoints where POSPointID = '" + Convert.ToString(this.POSPointID) + "' and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";
                        //    POSPointsBLL.SelectPosPoints(strCategoryDelete);
                        //}
                        //else
                        //{
                        ////string strCategoryDelete = "delete from mst_CategoryPOSPoints where POSPointID = '" + Convert.ToString(this.POSPointID) + "'";
                        ////POSPointsBLL.SelectPosPoints(strCategoryDelete);
                        //}

                        for (int i = 0; i < gvCategories.Rows.Count; i++)
                        {
                            CheckBox chkSelectCategory = (CheckBox)gvCategories.Rows[i].FindControl("chkSelectCategory");
                            if (chkSelectCategory.Checked)
                            {
                                CategoryPOSPoints objCategoryPOSPoints = new CategoryPOSPoints();
                                if (ddlLocation.SelectedIndex != 0)
                                    objCategoryPOSPoints.Location_TermID = new Guid(ddlLocation.SelectedValue);
                                objCategoryPOSPoints.CategoryID = new Guid(Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]));
                                objCategoryPOSPoints.IsActive = true;

                                lstCategoryPOSPoints.Add(objCategoryPOSPoints);

                            }
                        }

                        //if (strCategoryID != string.Empty)
                        //{
                        //    string strItemDelete = "delete from mst_ItemAvailability where POSPointID = '" + Convert.ToString(this.POSPointID) + "' and cast(CategoryID as nvarchar(max)) in (" + this.strCategoryID + ")";
                        //    POSPointsBLL.SelectPosPoints(strItemDelete);
                        //}
                        //else
                        //{
                        ////string strItemDelete = "delete from mst_ItemAvailability where POSPointID = '" + Convert.ToString(this.POSPointID) + "'";
                        ////POSPointsBLL.SelectPosPoints(strItemDelete);
                        //}

                        for (int j = 0; j < gvItem.Rows.Count; j++)
                        {
                            Label lblItemRate = (Label)gvItem.Rows[j].FindControl("lblItemRate");

                            ItemAvailability objItemAvailability = new ItemAvailability();

                            if (ddlLocation.SelectedIndex != 0)
                                objItemAvailability.Location_TermID = new Guid(ddlLocation.SelectedValue);
                            objItemAvailability.ItemID = new Guid(Convert.ToString(gvItem.DataKeys[j]["ItemID"]));
                            objItemAvailability.CategoryID = new Guid(Convert.ToString(gvItem.DataKeys[j]["CategoryID"]));

                            if (lblItemRate != null && lblItemRate.Text.Trim() != "")
                            {
                                objItemAvailability.ServiceRate = Convert.ToDecimal(lblItemRate.Text.Trim());
                            }

                            lstItemAvailability.Add(objItemAvailability);
                        }

                        //POSPointsBLL.Update(objUpd);

                        POSPointsBLL.UpdateWithData(objUpd, lstCategoryPOSPoints, lstItemAvailability);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_POSPoint");
                        IsPopupMessage = true;
                        litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                    }
                    else
                    {
                        POSPoints objIns = new POSPoints();
                        objIns.POSPointName = txtPOSPointsName.Text.Trim();
                        objIns.PointDisplayName = txtDisplayName.Text.Trim();

                        if (ddlLocation.SelectedIndex != 0)
                            objIns.POSLocation_TermID = new Guid(Convert.ToString(ddlLocation.SelectedValue));

                        if (ddlDefaultUser.SelectedIndex != 0)
                            objIns.DefaultUserID = new Guid(Convert.ToString(ddlDefaultUser.SelectedValue));

                        if (ddlDefaultCounter.SelectedIndex != 0)
                            objIns.DefaultCounterID = new Guid(Convert.ToString(ddlDefaultCounter.SelectedValue));

                        ////objIns.POSLocation_TermID = new Guid(Convert.ToString(ddlLocation.SelectedValue));

                        if (ddlDefaultUser.SelectedIndex != 0)
                            objIns.DefaultUserID = new Guid(ddlDefaultUser.SelectedValue);
                        if (ddlDefaultCounter.SelectedIndex != 0)
                            objIns.DefaultCounterID = new Guid(ddlDefaultCounter.SelectedValue);

                        if (ddlVendor.SelectedIndex != 0)
                            objIns.VendorID = new Guid(ddlVendor.SelectedValue);

                        objIns.PointDisplayName = txtDisplayName.Text.Trim();
                        objIns.IsTouchScreenEnable = chkIsTouchScreenEnable.Checked;
                        objIns.IsActivityPOS = chkIsActivityPOS.Checked;
                        ////objIns.IsConsumablePOS = chkConsumablePOS.Checked;

                        objIns.CompanyID = clsSession.CompanyID;
                        objIns.PropertyID = clsSession.PropertyID;
                        objIns.IsSynch = false;
                        objIns.IsActive = true;
                        objIns.UpdatedOn = DateTime.Now;
                        objIns.UpdatedBy = clsSession.UserID;

                        for (int i = 0; i < gvCategories.Rows.Count; i++)
                        {
                            CheckBox chkSelectCategory = (CheckBox)gvCategories.Rows[i].FindControl("chkSelectCategory");
                            if (chkSelectCategory.Checked)
                            {
                                CategoryPOSPoints objCategoryPOSPoints = new CategoryPOSPoints();
                                if (ddlLocation.SelectedIndex != 0)
                                    objCategoryPOSPoints.Location_TermID = new Guid(ddlLocation.SelectedValue);
                                objCategoryPOSPoints.CategoryID = new Guid(Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]));
                                objCategoryPOSPoints.IsActive = true;

                                lstCategoryPOSPoints.Add(objCategoryPOSPoints);

                            }
                        }

                        for (int j = 0; j < gvItem.Rows.Count; j++)
                        {
                            Label lblItemRate = (Label)gvItem.Rows[j].FindControl("lblItemRate");

                            ItemAvailability objItemAvailability = new ItemAvailability();

                            if (ddlLocation.SelectedIndex != 0)
                                objItemAvailability.Location_TermID = new Guid(ddlLocation.SelectedValue);
                            objItemAvailability.ItemID = new Guid(Convert.ToString(gvItem.DataKeys[j]["ItemID"]));
                            objItemAvailability.CategoryID = new Guid(Convert.ToString(gvItem.DataKeys[j]["CategoryID"]));

                            if (lblItemRate != null && lblItemRate.Text.Trim() != "")
                            {
                                objItemAvailability.ServiceRate = Convert.ToDecimal(lblItemRate.Text.Trim());
                            }

                            lstItemAvailability.Add(objItemAvailability);
                        }



                        //POSPointsBLL.Save(objIns);
                        POSPointsBLL.SaveWithData(objIns, lstCategoryPOSPoints, lstItemAvailability);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_POSPoint");
                        IsPopupMessage = true;
                        litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                    }

                    BindGrid();
                    ClearControl();
                    //SaveAndUpdateCurrency();
                    //if (!IsDuplicateRecord)
                    //    ClearControl();
                    //mpeAddEditPOSPoints.Show();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Cancel POS Point Information
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EvenArgs</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvPosPoints.ActiveViewIndex = 0;
            Session["objItemList"] = null;
            this.RowIndex = 0;
        }

        #endregion Form Button Event

        #region Popup Button Event
        /// <summary>
        /// Delete Popup Yes Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    POSPoints objDelete = new POSPoints();
                    objDelete = POSPointsBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    POSPointsBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_POSPoints");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Popup Button Event

        #region Search Button Event
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Search Button Event

        protected void gvCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ADDITEM"))
            {
                mpeItemList.Show();

                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                this.RowIndex = row.RowIndex;

                this.VCategoryID = Convert.ToString(e.CommandArgument);

                DataSet dsGetItem = ItemCategoryBLL.GetItemByCategoryID(clsSession.PropertyID, clsSession.CompanyID, new Guid(Convert.ToString(e.CommandArgument)));

                if (dsGetItem.Tables.Count > 0 && dsGetItem.Tables[0].Rows.Count > 0)
                {
                    gvmpeItemList.DataSource = dsGetItem;
                    gvmpeItemList.DataBind();

                    DataView dtData = new DataView();
                    for (int i = 0; i < dsGetItem.Tables[0].Rows.Count; i++)
                    {
                        TextBox txtmpeItemRate = (TextBox)gvmpeItemList.Rows[i].FindControl("txtmpeItemRate");
                        CheckBox chkmpeSelectItem = (CheckBox)gvmpeItemList.Rows[i].FindControl("chkmpeSelectItem");

                        string strRate = Convert.ToString(dsGetItem.Tables[0].Rows[i]["DefSalesPrice"]);

                        chkmpeSelectItem.Checked = false;

                        if (Session["objItemList"] != null)
                        {
                            dtData = (DataView)(Session["objItemList"]);

                            Guid ItemCategoryID = new Guid(dsGetItem.Tables[0].Rows[i]["ItemCategoryID"].ToString());

                            dtData.RowFilter = "ItemCategoryID='" + ItemCategoryID + "' And CategoryID = '" + Convert.ToString(VCategoryID) + "' ";

                            if (dtData.Count > 0)
                            {
                                strRate = Convert.ToString(dtData[0]["ItemPrice"]);
                                chkmpeSelectItem.Checked = true;
                            }
                        }

                        if (strRate != string.Empty)
                        {
                            if (strRate.IndexOf(".") != -1)
                                txtmpeItemRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                            else
                                txtmpeItemRate.Text = Convert.ToString(strRate);
                        }
                        else
                            txtmpeItemRate.Text = "";
                    }
                }
                else
                {
                    gvmpeItemList.DataSource = null;
                    gvmpeItemList.DataBind();
                }
            }
        }

        protected void gvmpeItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtmpeItemRate = (TextBox)e.Row.FindControl("txtmpeItemRate");
                    CheckBox chkmpeSelectItem = (CheckBox)e.Row.FindControl("chkmpeSelectItem");

                    RegularExpressionValidator revmpeItemRate = (RegularExpressionValidator)e.Row.FindControl("revmpeItemRate");
                    revmpeItemRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                    revmpeItemRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrmpedSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrmpeSelectItem")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrSelect", "Select");
                    ((Label)e.Row.FindControl("lblGvHdrmpeItemName")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrItemName", "Item Name");
                    ((Label)e.Row.FindControl("lblGvHdrmpeItemRate")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrItemRate", "Rate");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblGvmpeNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnmpeSubmit_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    DataTable dtTempItemList = new System.Data.DataTable();

                    DataColumn clItemCategoryID = new DataColumn("ItemCategoryID");
                    dtTempItemList.Columns.Add(clItemCategoryID);

                    DataColumn clItemID = new DataColumn("ItemID");
                    dtTempItemList.Columns.Add(clItemID);

                    DataColumn clCategoryID = new DataColumn("CategoryID");
                    dtTempItemList.Columns.Add(clCategoryID);

                    DataColumn clItemName = new DataColumn("ItemName");
                    dtTempItemList.Columns.Add(clItemName);

                    DataColumn clCategoryName = new DataColumn("CategoryName");
                    dtTempItemList.Columns.Add(clCategoryName);

                    DataColumn clItemPrice = new DataColumn("ItemPrice");
                    dtTempItemList.Columns.Add(clItemPrice);

                    DataColumn clSelect = new DataColumn("Select");
                    dtTempItemList.Columns.Add(clSelect);

                    string strCategoryName = "";
                    bool isCheck = false;

                    if (gvmpeItemList.Rows.Count > 0)
                    {
                        DataSet dsGetCategoryName = ItemCategoryBLL.GetItemByCategoryID(clsSession.PropertyID, clsSession.CompanyID, new Guid(VCategoryID));

                        if (dsGetCategoryName.Tables.Count > 0 && dsGetCategoryName.Tables[1].Rows.Count > 0)
                            strCategoryName = Convert.ToString(dsGetCategoryName.Tables[1].Rows[0]["CategoryName"]);

                        for (int i = 0; i < gvmpeItemList.Rows.Count; i++)
                        {
                            CheckBox chkmpeSelectItem = (CheckBox)gvmpeItemList.Rows[i].FindControl("chkmpeSelectItem");

                            if (chkmpeSelectItem.Checked)
                            {
                                Label lblGvmpeItemName = (Label)gvmpeItemList.Rows[i].FindControl("lblGvmpeItemName");
                                TextBox txtmpeItemRate = (TextBox)gvmpeItemList.Rows[i].FindControl("txtmpeItemRate");

                                string strItemRate = string.Empty;
                                if (txtmpeItemRate.Text.Trim() != "")
                                    strItemRate = Convert.ToString(txtmpeItemRate.Text.Trim());
                                else
                                    strItemRate = "0.00";

                                DataRow drRow = dtTempItemList.NewRow();

                                drRow["ItemCategoryID"] = Convert.ToString(gvmpeItemList.DataKeys[i]["ItemCategoryID"]);
                                drRow["ItemID"] = Convert.ToString(gvmpeItemList.DataKeys[i]["ItemID"]);
                                drRow["CategoryID"] = Convert.ToString(gvmpeItemList.DataKeys[i]["CategoryID"]);
                                drRow["ItemName"] = Convert.ToString(lblGvmpeItemName.Text.Trim());
                                drRow["CategoryName"] = Convert.ToString(strCategoryName);
                                drRow["ItemPrice"] = Convert.ToString(strItemRate);
                                drRow["Select"] = Convert.ToString(1);
                                dtTempItemList.Rows.Add(drRow);
                                isCheck = true;
                            }
                        }
                    }

                    ((CheckBox)gvCategories.Rows[this.RowIndex].FindControl("chkSelectCategory")).Checked = isCheck;

                    if (isCheck)
                        gvCategories.Rows[this.RowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#ECECEC");
                    else
                        gvCategories.Rows[this.RowIndex].BackColor = System.Drawing.Color.White;

                    HiddenField hdnFromDB = (HiddenField)gvCategories.Rows[this.RowIndex].FindControl("hdnFromDB");
                    if (hdnFromDB != null && Convert.ToString(hdnFromDB.Value) != "")
                    {
                        if (Convert.ToString(hdnFromDB.Value).ToUpper() == "TRUE")
                        {
                            ((CheckBox)gvCategories.Rows[this.RowIndex].FindControl("chkSelectCategory")).Checked = true;
                            gvCategories.Rows[this.RowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#ECECEC");
                        }
                    }
                    
                    for (int j = 0; j < gvItem.Rows.Count; j++)
                    {
                        string CategoryID = Convert.ToString(gvItem.DataKeys[j]["CategoryID"]);

                        if (CategoryID != VCategoryID)
                        {
                            DataRow drRow = dtTempItemList.NewRow();

                            Label lblGvItemName = (Label)gvItem.Rows[j].FindControl("lblGvItemName");
                            Label lblGvCategoryName = (Label)gvItem.Rows[j].FindControl("lblGvCategoryName");
                            Label lblItemRate = (Label)gvItem.Rows[j].FindControl("lblItemRate");

                            string strItemRate = string.Empty;
                            if (lblItemRate.Text.Trim() != "")
                                strItemRate = Convert.ToString(lblItemRate.Text.Trim());
                            else
                                strItemRate = "0.00";

                            drRow["ItemCategoryID"] = Convert.ToString(gvItem.DataKeys[j]["ItemCategoryID"]);
                            drRow["ItemID"] = Convert.ToString(gvItem.DataKeys[j]["ItemID"]);
                            drRow["CategoryID"] = Convert.ToString(gvItem.DataKeys[j]["CategoryID"]);
                            drRow["ItemName"] = Convert.ToString(lblGvItemName.Text.Trim());
                            drRow["CategoryName"] = Convert.ToString(lblGvCategoryName.Text.Trim());
                            drRow["ItemPrice"] = Convert.ToString(strItemRate);
                            drRow["Select"] = Convert.ToString(1);
                            dtTempItemList.Rows.Add(drRow);
                        }
                    }

                    DataView dvTempItem = new DataView(dtTempItemList);
                    dvTempItem.Sort = "ItemName asc";

                    gvItem.DataSource = Session["objItemList"] = dvTempItem;
                    gvItem.DataBind();

                    mpeItemList.Hide();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
    }
}