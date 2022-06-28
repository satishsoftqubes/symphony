using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Inventory
{
    public partial class CtrlItem : System.Web.UI.UserControl
    {
        #region Property and Variables
        public Guid ItemID
        {
            get
            {
                return ViewState["ItemID"] != null ? new Guid(Convert.ToString(ViewState["ItemID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ItemID"] = value;
            }
        }

        public Guid ItemUOMID
        {
            get
            {
                return ViewState["ItemUOMID"] != null ? new Guid(Convert.ToString(ViewState["ItemUOMID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ItemUOMID"] = value;
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
        public bool IsFeedbackMessage = false;
        public bool IsUOMPopupMessage = false;

        DataTable dtDynamic;
        DataTable dtCategories;

        DataView dvTempItem;
        public string strPOSPointID
        {
            get
            {
                return ViewState["strPOSPointID"] != null ? Convert.ToString(ViewState["strPOSPointID"]) : string.Empty;
            }
            set
            {
                ViewState["strPOSPointID"] = value;
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

        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                if (!IsPostBack)
                {
                    CheckUserAuthorization();

                    BindData();

                    if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty)
                    {
                        if (clsSession.ToEditItemType.ToUpper() == "ADDEDITITEM")
                        {
                            btnSave.Visible = btnStockHandlerSave.Visible = btnAddItemUOM.Visible = this.UserRights.Substring(2, 1) == "1";
                            this.ItemID = clsSession.ToEditItemID;
                            tdHeaderOtherInfo.Visible = lnkBtnStockHandler.Visible = lnkBtnUOMConversion.Visible = true;
                            BindDDLUOM();
                            LoadItemData();
                        }
                    }

                    BindBreadCrumb();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        #endregion

        #region Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ITEMMANAGEMENT.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = btnAddItemUOM.Visible = btnStockHandlerSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLables();

                regMinStock.ValidationExpression = regMaxStock.ValidationExpression = regStockOnHand.ValidationExpression = regReOrderLevel.ValidationExpression = regFactor.ValidationExpression = "\\d{0,24}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regSalePrice.ValidationExpression = regPurchasePrice.ValidationExpression = "\\d{0,24}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regMinStock.ErrorMessage = regMaxStock.ErrorMessage = regStockOnHand.ErrorMessage = regReOrderLevel.ErrorMessage = regFactor.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
                regSalePrice.ErrorMessage = regPurchasePrice.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

                BindDDLs();
                BindGrids();
                BindCategory();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Item", "lblMainHeader", "Item Setup");
            litItemType.Text = clsCommon.GetGlobalResourceText("Item", "lblItemType", "Type");
            ltrHeaderOtherInformation.Text = clsCommon.GetGlobalResourceText("Item", "lblHeaderOtherInformation", "Other Information");
            ////litCategory.Text = clsCommon.GetGlobalResourceText("Item", "lblItemCategory", "Category");
            lnkBtnStockHandler.Text = clsCommon.GetGlobalResourceText("Item", "lblBtnStockHandler", "Stock Handler");
            litItemCodeItemName.Text = clsCommon.GetGlobalResourceText("Item", "lblItemCodeItemName", "Code / Item Name");
            lnkBtnUOMConversion.Text = clsCommon.GetGlobalResourceText("Item", "lblBtnUOMConversion", "UOM Conversion");
            litSalePrice.Text = clsCommon.GetGlobalResourceText("Item", "lblDefaultSalePrice", "Def. Sale Price");
            litPurchasePrice.Text = clsCommon.GetGlobalResourceText("Item", "lblDefaultPurchasePrice", "Def. Pur. Price");
            ltrUnitOfMeasure.Text = clsCommon.GetGlobalResourceText("Item", "lblUnitOfMeasure", "Unit Of Measure");
            chkIsConsumable.Text = clsCommon.GetGlobalResourceText("Item", "lblIsConsumableItem", "Consumable Item");
            litHeaderTaxes.Text = clsCommon.GetGlobalResourceText("Item", "lblHeaderTaxes", "Taxes");
            litHeaderAvailability.Text = clsCommon.GetGlobalResourceText("Item", "lblHeaderAvailability", "Availability");
            litHeaderPopupStockHandler.Text = clsCommon.GetGlobalResourceText("Item", "lblHeaderPopupStockHandler", "Stock Handler");
            litPreferredSupplier.Text = clsCommon.GetGlobalResourceText("Item", "lblPreferredSupplier", "Preferred Supplier");
            litMinMaxStock.Text = clsCommon.GetGlobalResourceText("Item", "lblMinMaxStock", "Min / Max Stock");
            cmpvMinMaxStock.Text = clsCommon.GetGlobalResourceText("Item", "lblMsgMinStocMaxStock", "Min. Stock should be less than or equal to Max. Stock.");
            litStockOnHand.Text = clsCommon.GetGlobalResourceText("Item", "lblStockOnHand", "Stock on Hand");
            litReOrderLevel.Text = clsCommon.GetGlobalResourceText("Item", "lblReOrderLevel", "Re-Order Level");
            litUOMStockHandler.Text = clsCommon.GetGlobalResourceText("Item", "lblStockHandlerUOM", "UOM");
            litHeaderPopupUOM.Text = clsCommon.GetGlobalResourceText("Item", "lblHeaderPopupUOM", "UOM");
            litFactor.Text = clsCommon.GetGlobalResourceText("Item", "lblFactor", "Factor");
            litUOM.Text = clsCommon.GetGlobalResourceText("Item", "lblUOM", "UOM");

            btnAddItemUOM.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAdd", "Add");

            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Item", "lblHeaderConfirmDeletePopup", "Item UOM");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancel.Text = btnCancelDelete.Text = btnStockHandlerCancel.Text = btnUOMCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = btnStockHandlerSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litGeneralMandartoryFiledMessage.Text = litGeneralMandartoryFiledMessageForStockHandler.Text = litGeneralMandartoryFiledMessageForUOM.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");

            litCategoryList.Text = clsCommon.GetGlobalResourceText("Category", "lblCategoryList", "Category List");

            litCustomePopupMsg.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblCustomePopupMsg", "Please Insert Rate");
        }

        private void BindDDLs()
        {
            //Bind ddlItemType
            List<ProjectTerm> lstItemType = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "ITEMTYPE");
            if (lstItemType.Count != 0)
            {
                ddlItemType.DataSource = lstItemType;
                ddlItemType.DataTextField = "DisplayTerm";
                ddlItemType.DataValueField = "TermID";
                ddlItemType.DataBind();
                ddlItemType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlItemType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

            // Bind UOM ddl
            UOM objToGet = new UOM();
            objToGet.IsActive = true;
            objToGet.PropertyID = clsSession.PropertyID;
            objToGet.CompanyID = clsSession.CompanyID;
            List<UOM> lstUOM = UOMBLL.GetAll(objToGet);

            if (lstUOM != null && lstUOM.Count != 0)
            {
                ddlUnitOfMeasure.DataSource = lstUOM;
                ddlUnitOfMeasure.DataTextField = "UOMName";
                ddlUnitOfMeasure.DataValueField = "UOMID";
                ddlUnitOfMeasure.DataBind();
                ddlUnitOfMeasure.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlUnitOfMeasure.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));


            //Bind Category DDL
            ////Category objToGetList = new Category();
            ////objToGetList.IsActive = true;
            ////objToGetList.CompanyID = clsSession.CompanyID;
            ////objToGetList.PropertyID = clsSession.PropertyID;

            ////List<Category> lstCategories = CategoryBLL.GetAll(objToGetList);
            ////if (lstCategories.Count != 0)
            ////{
            ////    ddlCategory.DataSource = lstCategories;
            ////    ddlCategory.DataTextField = "CategoryName";
            ////    ddlCategory.DataValueField = "CategoryID";
            ////    ddlCategory.DataBind();
            ////    ddlCategory.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            ////}
            ////else
            ////    ddlCategory.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
        }

        private void BindDDLUOM()
        {
            try
            {
                //Bind Category DDL
                UOM objToGetList = new UOM();
                objToGetList.IsActive = true;
                objToGetList.CompanyID = clsSession.CompanyID;
                objToGetList.PropertyID = clsSession.PropertyID;

                List<UOM> lstUOMs = UOMBLL.GetAll(objToGetList);
                if (lstUOMs.Count != 0)
                {
                    ddlUOM.DataSource = lstUOMs;
                    ddlUOM.DataTextField = "UOMName";
                    ddlUOM.DataValueField = "UOMID";
                    ddlUOM.DataBind();
                    ddlUOM.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

                    ddlUOMStockHandler.DataSource = lstUOMs;
                    ddlUOMStockHandler.DataTextField = "UOMName";
                    ddlUOMStockHandler.DataValueField = "UOMID";
                    ddlUOMStockHandler.DataBind();
                    ddlUOMStockHandler.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
                else
                {
                    ddlUOM.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                    ddlUOMStockHandler.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGrids()
        {
            Account objToGetAccoutns = new Account();
            objToGetAccoutns.IsActive = true;
            objToGetAccoutns.CompanyID = clsSession.CompanyID;
            objToGetAccoutns.PropertyID = clsSession.PropertyID;
            objToGetAccoutns.IsTaxAcct = true;
            objToGetAccoutns.IsEnable = true;

            List<Account> lstAccounts = AccountBLL.GetAll(objToGetAccoutns);
            gvTaxes.DataSource = lstAccounts;
            gvTaxes.DataBind();

            ////DataSet dsPOSPoints = POSPointsBLL.POSPointsGetAllForItem(clsSession.CompanyID, clsSession.PropertyID);

            ////gvAvailability.DataSource = dsPOSPoints;
            ////gvAvailability.DataBind();

            gvAvailability.DataSource = null;
            gvAvailability.DataBind();
        }

        private void BindUOMGrid()
        {
            ItemUOM objToGetUOMs = new ItemUOM();
            objToGetUOMs.IsActive = true;
            objToGetUOMs.ItemID = this.ItemID;

            DataSet dsUOMs = ItemUOMBLL.GetAllWithDataSet(objToGetUOMs);
            gvUOM.DataSource = dsUOMs;
            gvUOM.DataBind();
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

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblMaterialManagementSetup", "Item Master Setup");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblItemList", "Item List");
            dr3["Link"] = "~/GUI/Inventory/ItemList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = txtItemName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblItem", "Item") : txtItemName.Text.Trim();
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void LoadItemData()
        {
            try
            {
                strPOSPointID = strCategoryID = string.Empty;

                DataSet dsItemData = ItemBLL.GetItemDataByPrimaryKey(this.ItemID);
                {
                    if (dsItemData.Tables.Count > 0)
                    {
                        DataRow drItem = dsItemData.Tables[0].Rows[0];

                        txtCode.Text = Convert.ToString(drItem["ItemCode"]);
                        txtItemName.Text = Convert.ToString(drItem["ItemName"]);

                        if (Convert.ToString(drItem["DefPurPrice"]) != string.Empty)
                            txtPurchasePrice.Text = Convert.ToString(drItem["DefPurPrice"]).Substring(0, Convert.ToString(drItem["DefPurPrice"]).LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                        if (Convert.ToString(drItem["DefSalesPrice"]) != string.Empty)
                            txtSalePrice.Text = Convert.ToString(drItem["DefSalesPrice"]).Substring(0, Convert.ToString(drItem["DefSalesPrice"]).LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                        chkIsConsumable.Checked = Convert.ToString(drItem["IsConsumable"]) != string.Empty ? Convert.ToBoolean(drItem["IsConsumable"]) : false;

                        ddlItemType.SelectedIndex = ddlItemType.Items.FindByValue(Convert.ToString(drItem["ItemType_TermID"])) != null ? ddlItemType.Items.IndexOf(ddlItemType.Items.FindByValue(Convert.ToString(drItem["ItemType_TermID"]))) : 0;
                        ////ddlCategory.SelectedIndex = ddlCategory.Items.FindByValue(Convert.ToString(drItem["ItemCategoryID"])) != null ? ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(Convert.ToString(drItem["ItemCategoryID"]))) : 0;
                        ddlUnitOfMeasure.SelectedIndex = ddlUnitOfMeasure.Items.FindByValue(Convert.ToString(drItem["UOMID"])) != null ? ddlUnitOfMeasure.Items.IndexOf(ddlUnitOfMeasure.Items.FindByValue(Convert.ToString(drItem["UOMID"]))) : 0;

                        if (Convert.ToString(drItem["MinStock"]) != string.Empty)
                            txtMinStock.Text = Convert.ToString(drItem["MinStock"]).Substring(0, Convert.ToString(drItem["MinStock"]).LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                        if (Convert.ToString(drItem["MaxStock"]) != string.Empty)
                            txtMaxStock.Text = Convert.ToString(drItem["MaxStock"]).Substring(0, Convert.ToString(drItem["MaxStock"]).LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                        if (Convert.ToString(drItem["StockInHand"]) != string.Empty)
                            txtStockOnHand.Text = Convert.ToString(drItem["StockInHand"]).Substring(0, Convert.ToString(drItem["StockInHand"]).LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                        if (Convert.ToString(drItem["ReOrderLevel"]) != string.Empty)
                            txtReOrderLevel.Text = Convert.ToString(drItem["ReOrderLevel"]).Substring(0, Convert.ToString(drItem["ReOrderLevel"]).LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                        ddlPreferredSupplier.SelectedIndex = ddlPreferredSupplier.Items.FindByValue(Convert.ToString(drItem["PreferredSupplierID"])) != null ? ddlPreferredSupplier.Items.IndexOf(ddlPreferredSupplier.Items.FindByValue(Convert.ToString(drItem["PreferredSupplierID"]))) : 0;
                        ddlUOMStockHandler.SelectedIndex = ddlUOMStockHandler.Items.FindByValue(Convert.ToString(drItem["UOMID"])) != null ? ddlUOMStockHandler.Items.IndexOf(ddlUOMStockHandler.Items.FindByValue(Convert.ToString(drItem["UOMID"]))) : 0;

                        if (dsItemData.Tables.Count > 1 && dsItemData.Tables[1].Rows.Count > 0)
                        {
                            DataTable dtTaxes = dsItemData.Tables[1];

                            for (int i = 0; i < gvTaxes.Rows.Count; i++)
                            {
                                DataRow[] rows = dtTaxes.Select("TaxID = '" + Convert.ToString(gvTaxes.DataKeys[i]["AcctID"]) + "'");
                                if (rows.Length > 0)
                                {
                                    ((CheckBox)gvTaxes.Rows[i].FindControl("chkSelect")).Checked = true;
                                }
                            }
                        }

                        DataSet dsItemCategory = new DataSet();
                        ItemCategory objLoadItemCategory = new ItemCategory();
                        objLoadItemCategory.ItemID = this.ItemID;
                        dsItemCategory = ItemCategoryBLL.GetAllWithDataSet(objLoadItemCategory);

                        if (dsItemCategory.Tables[0].Rows.Count != 0)
                        {
                            for (int k = 0; k < gvCategories.Rows.Count; k++)
                            {
                                GridViewRow row = gvCategories.Rows[k];
                                DataRow[] rows = dsItemCategory.Tables[0].Select("CategoryID = '" + gvCategories.DataKeys[k]["CategoryID"].ToString() + "'");
                                if (rows.Length > 0)
                                {
                                    ((CheckBox)row.FindControl("chkSelectCategory")).Checked = true;

                                    if (this.strCategoryID != string.Empty)
                                        this.strCategoryID += "," + Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]);
                                    else
                                        this.strCategoryID = Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]);

                                    ////if (this.strCategoryID != string.Empty)
                                    ////    this.strCategoryID += ",'" + Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]) + "'";
                                    ////else
                                    ////    this.strCategoryID = "'" + Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]) + "'";
                                }
                            }
                        }

                        BindItemAvailability();

                        ////string strItemAvailabilityQuery = "select ItemAvailabilityID,ItemID,POSPointID,CategoryID from mst_ItemAvailability where ItemID = '" + Convert.ToString(this.ItemID) + "'";
                        ////DataSet dsItemAvailability = ItemAvailabilityBLL.SelectItemAvailabilityData(strItemAvailabilityQuery);

                        ////if (dsItemAvailability.Tables.Count > 0 && dsItemAvailability.Tables[0].Rows.Count > 0)
                        ////{
                        ////    DataTable dtAvailability = dsItemAvailability.Tables[0];

                        ////    for (int i = 0; i < gvAvailability.Rows.Count; i++)
                        ////    {
                        ////        DataRow[] rows = dtAvailability.Select("POSPointID = '" + Convert.ToString(gvAvailability.DataKeys[i]["POSPointID"]) + "' and ItemID = '" + Convert.ToString(this.ItemID) + "' and CategoryID = '" + Convert.ToString(gvAvailability.DataKeys[i]["CategoryID"]) + "'");

                        ////        CheckBox chkItemAvailSelect = (CheckBox)gvAvailability.Rows[i].FindControl("chkSelect");
                                
                        ////        if (rows.Length > 0)
                        ////        {
                        ////            chkItemAvailSelect.Checked = true;
                                    
                        ////        }
                        ////        else
                        ////        {
                        ////            chkItemAvailSelect.Checked = false;
                                    
                        ////        }
                        ////    }
                        ////}

                        ////else
                        ////{
                        ////    gvAvailability.DataSource = null;
                        ////    gvAvailability.DataBind();
                        ////}


                        if (dsItemData.Tables.Count > 3 && dsItemData.Tables[3].Rows.Count > 0)
                        {
                            gvUOM.DataSource = dsItemData.Tables[3];
                            gvUOM.DataBind();
                        }
                        else
                        {
                            gvUOM.DataSource = null;
                            gvUOM.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindCategory()
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

                        RecursiveBindCategory(Convert.ToString(drDynamic["CategoryID"]));
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

        private void RecursiveBindCategory(string parentCategoryID)
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


                    RecursiveBindCategory(Convert.ToString(drDynamic["CategoryID"]));
                }
            }
        }

        private void BindItemAvailability()
        {
            if (this.strCategoryID != string.Empty)
            {
                ////string strCategoryPOSPointsQuery = "Select distinct pos.POSPointID, pos.PointDisplayName, pos.POSLocation_TermID, pTerm.DisplayTerm 'POSLocation' from mst_CategoryPOSPoints catPOS INNER JOIN pos_POSPoints pos on catPOS.POSPointID = pos.POSPointID INNER JOIN mst_ProjectTerm pTerm on pos.POSLocation_TermID = pTerm.TermID Where cast(catPOS.CategoryID as nvarchar(36)) in (" + strCategoryID + ") Order by PointDisplayName asc";

                string strCategoryPOSPointsQuery = string.Empty;
                Guid? ItemID = null;

                if (this.ItemID != Guid.Empty)
                    ItemID = this.ItemID;

                //if(this.ItemID !=Guid.Empty)
                //    strCategoryPOSPointsQuery = "Select pos.POSPointID, pos.PointDisplayName, pos.POSLocation_TermID, cat.CategoryID, cat.CategoryName, '0.00' as ServiceRate from mst_CategoryPOSPoints catPOS INNER JOIN pos_POSPoints pos on catPOS.POSPointID = pos.POSPointID INNER JOIN mst_Category cat on catPOS.CategoryID = cat.CategoryID Where cast(catPOS.CategoryID as nvarchar(36)) in (" + strCategoryID + ") Order by PointDisplayName asc";
                //else
                //    strCategoryPOSPointsQuery = "Select pos.POSPointID, pos.PointDisplayName, pos.POSLocation_TermID, cat.CategoryID, cat.CategoryName, '0.00' as ServiceRate from mst_CategoryPOSPoints catPOS INNER JOIN pos_POSPoints pos on catPOS.POSPointID = pos.POSPointID INNER JOIN mst_Category cat on catPOS.CategoryID = cat.CategoryID Where cast(catPOS.CategoryID as nvarchar(36)) in (" + strCategoryID + ") Order by PointDisplayName asc";

                DataSet dsCategoryPOSPoints = new DataSet();

                dsCategoryPOSPoints = ItemBLL.GetItemAvailabilityDataByItemIDAndCategoryIDs(ItemID,strCategoryID);

                if (dsCategoryPOSPoints.Tables.Count > 0 && dsCategoryPOSPoints.Tables[0] != null)
                {
                    gvAvailability.DataSource = dsCategoryPOSPoints.Tables[0];
                    gvAvailability.DataBind();

                    //if (dvTempItem != null)
                    //{
                        for (int k = 0; k < gvAvailability.Rows.Count; k++)
                        {
                            TextBox txtGvServiceRate = (TextBox)gvAvailability.Rows[k].FindControl("txtGvServiceRate");
                            string strRate = string.Empty;

                            if (dvTempItem != null)
                            {
                                DataRow[] dr = dvTempItem.Table.Select("POSPointID = '" + Convert.ToString(gvAvailability.DataKeys[k]["POSPointID"]) + "' and CategoryID = '" + Convert.ToString(gvAvailability.DataKeys[k]["CategoryID"]) + "' ");

                                if (dr.Length > 0)
                                {
                                    strRate = Convert.ToString(dr[0]["ServiceRate"]);

                                    ((CheckBox)gvAvailability.Rows[k].FindControl("chkSelect")).Checked = true;

                                    if (strRate != string.Empty && strRate != null)
                                    {
                                        if (strRate.IndexOf(".") != -1)
                                            txtGvServiceRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                                        else
                                            txtGvServiceRate.Text = Convert.ToString(strRate);
                                    }
                                    else
                                        txtGvServiceRate.Text = "0.00";
                                }
                                else
                                {
                                    strRate = Convert.ToString(dsCategoryPOSPoints.Tables[0].Rows[k]["ServiceRate"]);

                                    if (strRate.IndexOf(".") != -1)
                                        txtGvServiceRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                                    else
                                        txtGvServiceRate.Text = Convert.ToString(strRate);
                                }
                            }
                            else
                            {
                                strRate = Convert.ToString(dsCategoryPOSPoints.Tables[0].Rows[k]["ServiceRate"]);
                                if(Convert.ToDecimal(strRate) > 0)
                                    ((CheckBox)gvAvailability.Rows[k].FindControl("chkSelect")).Checked = true;
                                else
                                    ((CheckBox)gvAvailability.Rows[k].FindControl("chkSelect")).Checked = false;

                                if (strRate.IndexOf(".") != -1)
                                    txtGvServiceRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                                else
                                    txtGvServiceRate.Text = Convert.ToString(strRate);
                            }
                        }
                   // }

                }
                else
                {
                    gvAvailability.DataSource = null;
                    gvAvailability.DataBind();
                }
            }
            else
            {
                gvAvailability.DataSource = null;
                gvAvailability.DataBind();
            }
        }

        #endregion

        #region Control Events
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Item objToCheckDuplicate = new Item();
                    objToCheckDuplicate.IsActive = true;
                    objToCheckDuplicate.CompanyID = clsSession.CompanyID;
                    objToCheckDuplicate.PropertyID = clsSession.PropertyID;
                    objToCheckDuplicate.ItemCode = txtCode.Text.Trim();

                    List<Item> lstItems = ItemBLL.GetAll(objToCheckDuplicate);
                    if (lstItems.Count > 0)
                    {
                        if (this.ItemID != Guid.Empty)
                        {
                            //Edit Mode
                            if (lstItems[0].ItemID != this.ItemID)
                            {
                                IsFeedbackMessage = true;
                                litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("Item", "lblMsgItemWithSameCodeExists", "Item with same code already exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsFeedbackMessage = true;
                            litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("Item", "lblMsgItemWithSameCodeExists", "Item with same code already exist.");
                            return;
                        }
                    }

                    List<ItemCategory> lstItemCategory = new List<ItemCategory>();
                    List<ItemAvailability> lstItemAvailability = new List<ItemAvailability>();

                    ////DataSet dsCategoryPOSPoints = new DataSet();

                    ////if (strCategoryID != string.Empty)
                    ////{
                    ////    string strCategoryPOSPointsQuery = "select * from mst_CategoryPOSPoints where cast(CategoryID as nvarchar(36)) in (" + strCategoryID + ") ";

                    ////    dsCategoryPOSPoints = POSPointsBLL.SelectPosPoints(strCategoryPOSPointsQuery);
                    ////}

                    if (this.ItemID != Guid.Empty)
                    {
                        //Edit mode.
                        //Object declaration
                        Item objToUpdate = ItemBLL.GetByPrimaryKey(this.ItemID);
                        Item objOldToUpdate = ItemBLL.GetByPrimaryKey(this.ItemID);

                        objToUpdate.CompanyID = clsSession.CompanyID;
                        objToUpdate.PropertyID = clsSession.PropertyID;
                        objToUpdate.IsActive = true;
                        objToUpdate.ItemName = txtItemName.Text.Trim();
                        objToUpdate.ItemCode = txtCode.Text.Trim();
                        objToUpdate.PostingAcctID = new Guid("9D4ADA1C-89C6-4F23-8480-153D0D250FA7");

                        if (txtSalePrice.Text.Trim() != string.Empty)
                            objToUpdate.DefSalesPrice = Convert.ToDecimal(txtSalePrice.Text.Trim());
                        else
                            objToUpdate.DefSalesPrice = null;

                        if (txtPurchasePrice.Text.Trim() != string.Empty)
                            objToUpdate.DefPurPrice = Convert.ToDecimal(txtPurchasePrice.Text.Trim());
                        else
                            objToUpdate.DefPurPrice = null;

                        if (ddlItemType.SelectedIndex != 0)
                            objToUpdate.ItemType_TermID = new Guid(ddlItemType.SelectedValue);
                        else
                            objToUpdate.ItemType_TermID = null;

                        ////if (ddlCategory.SelectedIndex != 0)
                        ////    objToUpdate.ItemCategoryID = new Guid(ddlCategory.SelectedValue);
                        ////else
                        ////    objToUpdate.ItemCategoryID = null;

                        if (ddlUnitOfMeasure.SelectedIndex != 0)
                            objToUpdate.UOMID = new Guid(ddlUnitOfMeasure.SelectedValue);
                        else
                            objToUpdate.UOMID = null;

                        objToUpdate.IsConsumable = chkIsConsumable.Checked;

                        List<ItemTax> lstItemTaxes = new List<ItemTax>();
                        for (int i = 0; i < gvTaxes.Rows.Count; i++)
                        {
                            if (((CheckBox)gvTaxes.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                ItemTax objToAdd = new ItemTax();
                                objToAdd.TaxID = new Guid(Convert.ToString(gvTaxes.DataKeys[i]["AcctID"]));
                                lstItemTaxes.Add(objToAdd);
                            }
                        }

                        //List<ItemAvailability> lstItemAvailabilitys = new List<ItemAvailability>();
                        //for (int i = 0; i < gvAvailability.Rows.Count; i++)
                        //{
                        //    if (((CheckBox)gvAvailability.Rows[i].FindControl("chkSelect")).Checked)
                        //    {
                        //        ItemAvailability objToAdd = new ItemAvailability();
                        //        objToAdd.POSPointID = new Guid(Convert.ToString(gvAvailability.DataKeys[i]["POSPointID"]));
                        //        objToAdd.Location_TermID = new Guid(Convert.ToString(gvAvailability.DataKeys[i]["POSLocation_TermID"]));
                        //        lstItemAvailabilitys.Add(objToAdd);
                        //    }
                        //}

                        //for (int k = 0; k < gvCategories.Rows.Count; k++)
                        //{
                        //    if (((CheckBox)gvCategories.Rows[k].FindControl("chkSelectCategory")).Checked)
                        //    {
                        //        ItemCategory objItemCategory = new ItemCategory();

                        //        objItemCategory.CategoryID = new Guid(Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]));
                        //        lstItemCategory.Add(objItemCategory);
                        //    }
                        //}


                        for (int k = 0; k < gvCategories.Rows.Count; k++)
                        {
                            if (((CheckBox)gvCategories.Rows[k].FindControl("chkSelectCategory")).Checked)
                            {
                                ItemCategory objItemCategory = new ItemCategory();

                                objItemCategory.CategoryID = new Guid(Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]));
                                lstItemCategory.Add(objItemCategory);

                                ////if (dsCategoryPOSPoints.Tables.Count > 0 && dsCategoryPOSPoints.Tables[0] != null)
                                ////{
                                ////    for (int j = 0; j < gvAvailability.Rows.Count; j++)
                                ////    {
                                ////        if (((CheckBox)gvAvailability.Rows[j].FindControl("chkSelect")).Checked)
                                ////        {
                                ////            DataRow[] dr = dsCategoryPOSPoints.Tables[0].Select("CategoryID = '" + Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]) + "' and POSPointID = '" + Convert.ToString(gvAvailability.DataKeys[j]["POSPointID"]) + "'");
                                ////            if (dr.Length > 0)
                                ////            {
                                ////                ItemAvailability objItemAvailability = new ItemAvailability();
                                ////                objItemAvailability.POSPointID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["POSPointID"]));
                                ////                objItemAvailability.CategoryID = new Guid(Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]));
                                ////                objItemAvailability.Location_TermID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["POSLocation_TermID"]));
                                ////                ////objItemAvailability.ServiceRate

                                ////                lstItemAvailability.Add(objItemAvailability);
                                ////            }
                                ////        }
                                ////    }
                                ////}
                            }
                        }

                        for (int j = 0; j < gvAvailability.Rows.Count; j++)
                        {
                            if (((CheckBox)gvAvailability.Rows[j].FindControl("chkSelect")).Checked)
                            {

                                TextBox txtGvServiceRate = (TextBox)gvAvailability.Rows[j].FindControl("txtGvServiceRate");

                                ItemAvailability objItemAvailability = new ItemAvailability();
                                objItemAvailability.POSPointID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["POSPointID"]));
                                objItemAvailability.CategoryID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["CategoryID"]));
                                objItemAvailability.Location_TermID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["POSLocation_TermID"]));
                                objItemAvailability.ServiceRate = Convert.ToDecimal(txtGvServiceRate.Text.Trim());

                                lstItemAvailability.Add(objItemAvailability);
                            }
                        }

                        ItemTax objToGetItemTaxs = new ItemTax();
                        objToGetItemTaxs.ItemID = this.ItemID;
                        List<ItemTax> lstItemTaxesFromDB = ItemTaxBLL.GetAll(objToGetItemTaxs);

                        ItemAvailability objToGetItemAvailability = new ItemAvailability();
                        objToGetItemAvailability.ItemID = this.ItemID;
                        List<ItemAvailability> lstItemAvailabilityFromDB = ItemAvailabilityBLL.GetAll(objToGetItemAvailability);

                        ////ItemBLL.UpdateWithData(objToUpdate, lstItemTaxes, lstItemTaxesFromDB, lstItemAvailabilitys, lstItemAvailabilityFromDB,lstItemCategory);
                        ItemBLL.UpdateData(objToUpdate, lstItemTaxes, lstItemTaxesFromDB, lstItemAvailability, lstItemCategory);

                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldToUpdate.ToString(), objToUpdate.ToString(), "mst_Item");
                        IsFeedbackMessage = true;
                        litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        //Insert Mode
                        Item objToInsert = new Item();

                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.IsActive = true;
                        objToInsert.ItemName = txtItemName.Text.Trim();
                        objToInsert.ItemCode = txtCode.Text.Trim();
                        objToInsert.PostingAcctID = new Guid("9D4ADA1C-89C6-4F23-8480-153D0D250FA7");

                        if (txtSalePrice.Text.Trim() != string.Empty)
                            objToInsert.DefSalesPrice = Convert.ToDecimal(txtSalePrice.Text.Trim());

                        if (txtPurchasePrice.Text.Trim() != string.Empty)
                            objToInsert.DefPurPrice = Convert.ToDecimal(txtPurchasePrice.Text.Trim());

                        if (ddlItemType.SelectedIndex != 0)
                            objToInsert.ItemType_TermID = new Guid(ddlItemType.SelectedValue);

                        ////if (ddlCategory.SelectedIndex != 0)
                        ////    objToInsert.ItemCategoryID = new Guid(ddlCategory.SelectedValue);

                        if (ddlUnitOfMeasure.SelectedIndex != 0)
                            objToInsert.UOMID = new Guid(ddlUnitOfMeasure.SelectedValue);

                        objToInsert.IsConsumable = chkIsConsumable.Checked;

                        List<ItemTax> lstItemTaxes = new List<ItemTax>();
                        for (int i = 0; i < gvTaxes.Rows.Count; i++)
                        {
                            if (((CheckBox)gvTaxes.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                ItemTax objToAdd = new ItemTax();
                                objToAdd.TaxID = new Guid(Convert.ToString(gvTaxes.DataKeys[i]["AcctID"]));
                                lstItemTaxes.Add(objToAdd);
                            }
                        }

                        //List<ItemAvailability> lstItemAvailabilitys = new List<ItemAvailability>();
                        //for (int i = 0; i < gvAvailability.Rows.Count; i++)
                        //{
                        //    if (((CheckBox)gvAvailability.Rows[i].FindControl("chkSelect")).Checked)
                        //    {
                        //        ItemAvailability objToAdd = new ItemAvailability();
                        //        objToAdd.POSPointID = new Guid(Convert.ToString(gvAvailability.DataKeys[i]["POSPointID"]));
                        //        objToAdd.Location_TermID = new Guid(Convert.ToString(gvAvailability.DataKeys[i]["POSLocation_TermID"]));
                        //        lstItemAvailabilitys.Add(objToAdd);
                        //    }
                        //}

                        //for (int k = 0; k < gvCategories.Rows.Count; k++)
                        //{
                        //    if (((CheckBox)gvCategories.Rows[k].FindControl("chkSelectCategory")).Checked)
                        //    {
                        //        ItemCategory objItemCategory = new ItemCategory();

                        //        objItemCategory.CategoryID = new Guid(Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]));
                        //        lstItemCategory.Add(objItemCategory);
                        //    }
                        //}

                        for (int k = 0; k < gvCategories.Rows.Count; k++)
                        {
                            if (((CheckBox)gvCategories.Rows[k].FindControl("chkSelectCategory")).Checked)
                            {
                                ItemCategory objItemCategory = new ItemCategory();

                                objItemCategory.CategoryID = new Guid(Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]));
                                lstItemCategory.Add(objItemCategory);
                            }
                        }


                        for (int j = 0; j < gvAvailability.Rows.Count; j++)
                        {
                            if (((CheckBox)gvAvailability.Rows[j].FindControl("chkSelect")).Checked)
                            {
                                ////DataRow[] dr = dsCategoryPOSPoints.Tables[0].Select("CategoryID = '" + Convert.ToString(gvCategories.DataKeys[k]["CategoryID"]) + "' and POSPointID = '" + Convert.ToString(gvAvailability.DataKeys[j]["POSPointID"]) + "'");
                                ////if (dr.Length > 0)
                                ////{
                                TextBox txtGvServiceRate = (TextBox)gvAvailability.Rows[j].FindControl("txtGvServiceRate");

                                ItemAvailability objItemAvailability = new ItemAvailability();
                                objItemAvailability.POSPointID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["POSPointID"]));
                                objItemAvailability.CategoryID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["CategoryID"]));
                                objItemAvailability.Location_TermID = new Guid(Convert.ToString(gvAvailability.DataKeys[j]["POSLocation_TermID"]));
                                objItemAvailability.ServiceRate = Convert.ToDecimal(txtGvServiceRate.Text.Trim());

                                lstItemAvailability.Add(objItemAvailability);

                                ////}
                            }
                        }


                        ////ItemBLL.SaveWithData(objToInsert, lstItemTaxes, lstItemAvailabilitys,lstItemCategory);
                        ItemBLL.SaveWithData(objToInsert, lstItemTaxes, lstItemAvailability, lstItemCategory);
                        this.ItemID = objToInsert.ItemID;
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_Item");
                        IsFeedbackMessage = true;
                        litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        btnSave.Visible = btnStockHandlerSave.Visible = btnAddItemUOM.Visible = this.UserRights.Substring(2, 1) == "1";
                    }

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = strCategoryID = strPOSPointID = string.Empty;
            Response.Redirect("~/GUI/Inventory/Item.aspx");
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = strCategoryID = strPOSPointID = string.Empty;
            Response.Redirect("~/GUI/Inventory/ItemList.aspx");
        }

        protected void lnkBtnStockHandler_OnClick(object sender, EventArgs e)
        {
            mpeStockHandler.Show();
        }

        protected void btnAddItemUOM_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ItemUOMID != Guid.Empty)
                {
                    //UOM Edit mode
                    ItemUOM objToUpdate = ItemUOMBLL.GetByPrimaryKey(this.ItemUOMID);

                    if (ddlUOM.SelectedIndex != 0)
                        objToUpdate.UOMID1 = new Guid(ddlUOM.SelectedValue);
                    else
                        objToUpdate.UOMID1 = null;

                    if (txtFactor.Text.Trim() != string.Empty)
                        objToUpdate.Factor1 = Convert.ToDecimal(txtFactor.Text.Trim());
                    else
                        objToUpdate.Factor1 = null;

                    ItemUOMBLL.Update(objToUpdate);
                    IsUOMPopupMessage = true;
                    litMsgUOMPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    BindUOMGrid();
                }
                else
                {
                    //UOM Insert mode
                    ItemUOM objToInsert = new ItemUOM();
                    objToInsert.IsActive = true;
                    objToInsert.ItemID = this.ItemID;

                    if (ddlUOM.SelectedIndex != 0)
                        objToInsert.UOMID1 = new Guid(ddlUOM.SelectedValue);

                    if (txtFactor.Text.Trim() != string.Empty)
                        objToInsert.Factor1 = Convert.ToDecimal(txtFactor.Text.Trim());

                    ItemUOMBLL.Save(objToInsert);
                    IsUOMPopupMessage = true;
                    litMsgUOMPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    BindUOMGrid();
                }

                txtFactor.Text = string.Empty; ddlUOM.SelectedIndex = 0;
                this.ItemUOMID = Guid.Empty;
                mpeUOM.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void lnkBtnUOMConversion_OnClick(object sender, EventArgs e)
        {
            this.ItemUOMID = Guid.Empty;
            txtFactor.Text = "";
            ddlUOM.SelectedIndex = 0;
            mpeUOM.Show();
        }

        protected void btnStockHandlerSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Object declaration
                Item objToUpdate = ItemBLL.GetByPrimaryKey(this.ItemID);
                Item objOldToUpdate = ItemBLL.GetByPrimaryKey(this.ItemID);

                if (ddlPreferredSupplier.SelectedIndex != 0)
                    objToUpdate.PreferredSupplierID = new Guid(ddlPreferredSupplier.SelectedValue);
                else
                    objToUpdate.PreferredSupplierID = null;

                if (txtMinStock.Text.Trim() != string.Empty)
                    objToUpdate.MinStock = Convert.ToDecimal(txtMinStock.Text.Trim());
                else
                    objToUpdate.MinStock = null;

                if (txtMaxStock.Text.Trim() != string.Empty)
                    objToUpdate.MaxStock = Convert.ToDecimal(txtMaxStock.Text.Trim());
                else
                    objToUpdate.MaxStock = null;

                if (txtStockOnHand.Text.Trim() != string.Empty)
                    objToUpdate.StockInHand = Convert.ToDecimal(txtStockOnHand.Text.Trim());
                else
                    objToUpdate.StockInHand = null;

                if (txtReOrderLevel.Text.Trim() != string.Empty)
                    objToUpdate.ReOrderLevel = Convert.ToDecimal(txtReOrderLevel.Text.Trim());
                else
                    objToUpdate.ReOrderLevel = null;

                if (ddlUOMStockHandler.SelectedIndex != 0)
                    objToUpdate.UOMID = new Guid(ddlUOMStockHandler.SelectedValue);
                else
                    objToUpdate.UOMID = null;

                ItemBLL.Update(objToUpdate);

                IsFeedbackMessage = true;
                litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    ItemUOMBLL.Delete(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    IsUOMPopupMessage = true;
                    litMsgUOMPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    this.ItemUOMID = Guid.Empty;
                    BindUOMGrid();
                    mpeUOM.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            mpeConfirmDelete.Hide();
            mpeUOM.Show();
        }

        #endregion

        #region Grid Event
        protected void gvTaxes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Literal)e.Row.FindControl("litGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrSelect", "Select");
                    ((Literal)e.Row.FindControl("litGvHdrTax")).Text = clsCommon.GetGlobalResourceText("Item", "lblGvHdrTax", "Tax");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvAvailability_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtGvServiceRate = (TextBox)e.Row.FindControl("txtGvServiceRate");

                    RegularExpressionValidator revServiceRate = (RegularExpressionValidator)e.Row.FindControl("revServiceRate");
                    revServiceRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                    revServiceRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

                    if (this.ItemID != Guid.Empty)
                    {

                    }
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Literal)e.Row.FindControl("litGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrSelect", "Select");
                    ((Literal)e.Row.FindControl("litGvHdrCategoryName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryName", "Category Name");
                    ((Literal)e.Row.FindControl("litGvHdrServiceRate")).Text = clsCommon.GetGlobalResourceText("Item", "lblGvHdrServiceRate", "Service Rate");
                    ((Literal)e.Row.FindControl("litGvHdrPointDisplayName")).Text = clsCommon.GetGlobalResourceText("Item", "lblGvHdrPointDisplayName", "Service Rate");

                    ////((Literal)e.Row.FindControl("litGvHdrPOSPoints")).Text = clsCommon.GetGlobalResourceText("Item", "lblGvHdrPOSPoints", "POS Points");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUOM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    string strFactor1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Factor1"));
                    if (strFactor1 != string.Empty)
                    {
                        ((Label)e.Row.FindControl("lblFactor")).Text = strFactor1.Substring(0, strFactor1.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemUOMID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Literal)e.Row.FindControl("litGvHdrUOMName")).Text = clsCommon.GetGlobalResourceText("Item", "lblGvHdrUOMName", "UOM Name");
                    ((Literal)e.Row.FindControl("litGvHdrUOMFactor")).Text = clsCommon.GetGlobalResourceText("Item", "lblGvHdrFactor", "Factor");
                    ((Literal)e.Row.FindControl("litGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUOM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    this.ItemUOMID = new Guid(e.CommandArgument.ToString());
                    ItemUOM objToLoad = ItemUOMBLL.GetByPrimaryKey(this.ItemUOMID);
                    if (Convert.ToString(objToLoad.Factor1) != string.Empty)
                        txtFactor.Text = Convert.ToString(objToLoad.Factor1).Substring(0, Convert.ToString(objToLoad.Factor1).LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                    ddlUOM.SelectedIndex = ddlUOM.Items.FindByValue(Convert.ToString(objToLoad.UOMID1)) != null ? ddlUOM.Items.IndexOf(ddlUOM.Items.FindByValue(Convert.ToString(objToLoad.UOMID1))) : 0;
                    mpeUOM.Show();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    txtFactor.Text = string.Empty; ddlUOM.SelectedIndex = 0;
                    this.ItemUOMID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeUOM.Show();
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUOM_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUOM.PageIndex = e.NewPageIndex;
            BindUOMGrid();
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
                    ((Label)e.Row.FindControl("lblGvHdrCategoryCode")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryCode", "Category Code");
                    ((Label)e.Row.FindControl("lblGvHdrCategoryName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryName", "Category Name");
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

        #endregion Grid Event

        #region CheckBox Event

        protected void chkSelectCategory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //CheckBox chkSelectCategory = (CheckBox)sender;
                //GridViewRow gr = (GridViewRow)chkSelectCategory.Parent.Parent;

                //string CategoryID = gvCategories.DataKeys[gr.RowIndex].Value.ToString();

                strCategoryID = string.Empty;

                DataTable dtSessionItemList = new System.Data.DataTable();

                DataColumn clPOSPointID = new DataColumn("POSPointID");
                dtSessionItemList.Columns.Add(clPOSPointID);

                DataColumn clCategoryID = new DataColumn("CategoryID");
                dtSessionItemList.Columns.Add(clCategoryID);

                DataColumn clServiceRate = new DataColumn("ServiceRate");
                dtSessionItemList.Columns.Add(clServiceRate);

                DataColumn clSelect = new DataColumn("Select");
                dtSessionItemList.Columns.Add(clSelect);

                for (int i = 0; i < gvAvailability.Rows.Count; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvAvailability.Rows[i].FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        TextBox txtGvServiceRate = (TextBox)gvAvailability.Rows[i].FindControl("txtGvServiceRate");

                        string strServiceRate = string.Empty;
                        if (txtGvServiceRate.Text.Trim() != "")
                            strServiceRate = Convert.ToString(txtGvServiceRate.Text.Trim());
                        else
                            strServiceRate = "0.00";

                        DataRow drRow = dtSessionItemList.NewRow();

                        drRow["POSPointID"] = Convert.ToString(gvAvailability.DataKeys[i]["POSPointID"]);
                        drRow["CategoryID"] = Convert.ToString(gvAvailability.DataKeys[i]["CategoryID"]);
                        drRow["ServiceRate"] = Convert.ToString(strServiceRate);
                        drRow["Select"] = Convert.ToString(1);
                        dtSessionItemList.Rows.Add(drRow);

                        ////if (this.strPOSPointID != string.Empty)
                        ////    this.strPOSPointID += ",'" + Convert.ToString(gvAvailability.DataKeys[i]["POSPointID"]) + "'";
                        ////else
                        ////    this.strPOSPointID = "'" + Convert.ToString(gvAvailability.DataKeys[i]["POSPointID"]) + "'";
                    }
                }

                dvTempItem = new DataView(dtSessionItemList);

                for (int i = 0; i < gvCategories.Rows.Count; i++)
                {
                    CheckBox chkSelectCategory = (CheckBox)gvCategories.Rows[i].FindControl("chkSelectCategory");
                    if (chkSelectCategory.Checked)
                    {
                        if (this.strCategoryID != string.Empty)
                            this.strCategoryID += "," + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]);
                        else
                            this.strCategoryID = Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]);

                        ////if (this.strCategoryID != string.Empty)
                        ////    this.strCategoryID += ",'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                        ////else
                        ////    this.strCategoryID = "'" + Convert.ToString(gvCategories.DataKeys[i]["CategoryID"]) + "'";
                    }
                }

                //if (strCategoryID != string.Empty)
                //    this.strCategoryID +=  "'";

                BindItemAvailability();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion CheckBox Event
    }
}