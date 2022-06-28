using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Inventory
{
    public partial class CtrlCategory : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;

        public Guid CategoryID
        {
            get
            {
                return ViewState["CategoryID"] != null ? new Guid(Convert.ToString(ViewState["CategoryID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CategoryID"] = value;
            }
        }

        DataTable dtDynamic;
        DataTable dtCategories;

        List<Category> listDeleteCategory = null;
        string strDelete = string.Empty;
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

        #endregion Property and Variables

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                mvCategory.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Methods

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CATEGORY.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddTopCategory.Visible = btnAddBottomCategory.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLables();
                BindTreeviewGrid();
                BindCategoryAndSubCategory();
                BindPosPoints();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Grid Method Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                trTreeGrid.Visible = false;
                trNormalGrid.Visible = true;

                string CategoryName = null;
                string CategoryCode = null;

                if (!(txtSearchCategoryName.Text.Trim().Equals("")))
                    CategoryName = txtSearchCategoryName.Text.Trim();

                if (!(txtSearceCategoryCode.Text.Trim().Equals("")))
                    CategoryCode = txtSearceCategoryCode.Text.Trim();

                DataSet dsSearchCategory = CategoryBLL.SearchCategory(null, clsSession.PropertyID, clsSession.CompanyID, CategoryCode, CategoryName);

                gvCategoryList.DataSource = dsSearchCategory.Tables[0];
                gvCategoryList.DataBind();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindTreeviewGrid()
        {
            try
            {
                DataSet dsCategory = CategoryBLL.GetCategoryData(null, clsSession.PropertyID, clsSession.CompanyID, null, null, null);
                trTreeGrid.Visible = true;
                trNormalGrid.Visible = false;
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblMaterialManagementSetup", "Item Master Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.CategoryID != Guid.Empty || mvCategory.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCategoryList", "Category List");
                dr3["Link"] = "~/GUI/Inventory/Category.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = txtCategoryName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewCategory", "New Category") : txtCategoryName.Text.Trim();
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCategoryList", "Category List");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("Category", "lblMainHeader", "CATEGORY SETUP");
            litSearchCategoryName.Text = clsCommon.GetGlobalResourceText("Category", "lblSearchCategoryName", "Category Name");
            ltrSearchCategoryCode.Text = clsCommon.GetGlobalResourceText("Category", "lblSearchCategoryCode", "Category Code");
            ltrCategoryCode.Text = clsCommon.GetGlobalResourceText("Category", "lblCategoryCode", "Category Code");
            ltrCategoryName.Text = clsCommon.GetGlobalResourceText("Category", "lblCategoryName", "Category Name");
            ltrCategoryDescription.Text = clsCommon.GetGlobalResourceText("Category", "lblCategoryDescription", "Description");
            ltrCategoryList.Text = clsCommon.GetGlobalResourceText("Category", "lblCategoryList", "Category List");
            btnAddTopCategory.Text = btnAddBottomCategory.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancel.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Category", "lblHdrConfirmDeletePopup", "Category");
            btnSearchCategory.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            ltrReferenceCategory.Text = clsCommon.GetGlobalResourceText("Category", "lblReferenceCategory", "Reference Category");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");

            litPosPointList.Text = clsCommon.GetGlobalResourceText("POSPoints", "lblPOSPoints", "POS Points List");
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            BindTreeviewGrid();
            txtCategoryCode.Text = txtCategoryName.Text = txtCategoryDescription.Text = "";
            BindCategoryAndSubCategory();
            BindPosPoints();
            this.CategoryID = Guid.Empty;
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearceCategoryCode.Text = txtSearchCategoryName.Text = "";
        }

        private void BindCategoryAndSubCategory()
        {
            ddlReferenceCategory.Items.Clear();
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            if (dtDynamic != null && dtDynamic.Rows.Count > 0)
            {
                for (int i = 0; i < dtDynamic.Rows.Count; i++)
                {
                    System.Text.StringBuilder appender = new System.Text.StringBuilder();
                    int level = Convert.ToInt32(dtDynamic.Rows[i]["Level"]);
                    if (level == 0)
                    {
                        ddlReferenceCategory.Items.Add(new ListItem(dtDynamic.Rows[i]["CategoryName"].ToString(), dtDynamic.Rows[i]["CategoryID"].ToString()));
                    }
                    else
                    {
                        for (int j = 0; j < level; j++)
                        {
                            appender.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                        }

                        appender.Append("|__");
                        ddlReferenceCategory.Items.Add(new ListItem(Server.HtmlDecode(appender.ToString() + dtDynamic.Rows[i]["CategoryName"].ToString()), dtDynamic.Rows[i]["CategoryID"].ToString()));
                    }
                }
                ddlReferenceCategory.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlReferenceCategory.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
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

        private string RecursiveDeleteData(string parentCategoryID)
        {
            var nodes = listDeleteCategory.Where(x => parentCategoryID == null ? x.RefCategoryID == null : x.RefCategoryID == new Guid(parentCategoryID));

            foreach (var node in nodes)
            {
                //TreeNode newNode = new TreeNode(node.CategoryName, node.CategoryID.ToString());
                strDelete += "'" + Convert.ToString(node.CategoryID) + "',";
                RecursiveDeleteData(Convert.ToString(node.CategoryID));
            }

            return strDelete;
        }

        //private void DeleteCategory(string MainCategoryID)
        //{
        //    Category objCategory = new Category();
        //    objCategory.PropertyID = clsSession.PropertyID;
        //    objCategory.CompanyID = clsSession.CompanyID;
        //    objCategory.IsActive = true;
        //    listDeleteCategory = CategoryBLL.GetAll(objCategory);

        //    string strDel = RecursiveDeleteData();
        //}
        private void LoadCategoryData()
        {
            if (this.CategoryID != Guid.Empty)
            {
                btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                mvCategory.ActiveViewIndex = 1;
                Category objCategory = new Category();
                objCategory = CategoryBLL.GetByPrimaryKey(this.CategoryID);
                if (objCategory != null)
                {
                    this.CategoryID = objCategory.CategoryID;
                    txtCategoryCode.Text = objCategory.CategoryCode;
                    txtCategoryName.Text = objCategory.CategoryName;
                    txtCategoryDescription.Text = objCategory.Details;
                    ddlReferenceCategory.SelectedIndex = ddlReferenceCategory.Items.FindByValue(Convert.ToString(objCategory.RefCategoryID)) != null ? ddlReferenceCategory.Items.IndexOf(ddlReferenceCategory.Items.FindByValue(Convert.ToString(objCategory.RefCategoryID))) : 0;


                    BindPosPoints();

                    CategoryPOSPoints objLoadCategoryPOSPoints = new CategoryPOSPoints();
                    objLoadCategoryPOSPoints.CategoryID = this.CategoryID;
                    objLoadCategoryPOSPoints.IsActive = true;

                    DataSet dsCategoryPosPoints = new DataSet();
                    dsCategoryPosPoints = CategoryPOSPointsBLL.GetAllWithDataSet(objLoadCategoryPOSPoints);

                    if (dsCategoryPosPoints.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < gvPosPoints.Rows.Count; i++)
                        {
                            GridViewRow row = gvPosPoints.Rows[i];

                            DataRow[] rows = dsCategoryPosPoints.Tables[0].Select("POSPointID = '" + gvPosPoints.DataKeys[i]["POSPointID"].ToString() + "'");

                            if (rows.Length > 0)
                            {
                                ((CheckBox)row.FindControl("chkSelectPosPoints")).Checked = true;
                            }

                        }
                    }

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
            }
        }

        //BindTree(lstCategory, null);
        //private void BindTree(IEnumerable<Category> list, TreeNode parentNode)
        //{
        //    var nodes = list.Where(x => parentNode == null ? x.RefCategoryID == null : x.RefCategoryID == new Guid(parentNode.Value));

        //    foreach (var node in nodes)
        //    {
        //        TreeNode newNode = new TreeNode(node.CategoryName, node.CategoryID.ToString());
        //        if (parentNode == null)
        //        {
        //            treeview1.Nodes.Add(newNode);                    
        //        }
        //        else
        //        {
        //            parentNode.ChildNodes.Add(newNode);
        //        }
        //        BindTree(list, newNode);
        //    }
        //}

        private void BindPosPoints()
        {
            try
            {
                string strQueryPosPoints = "select POSPointID,PointDisplayName,POSLocation_TermID,POSPointName from pos_POSPoints where IsActive = 1 and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' order by PointDisplayName asc";

                DataSet dsPosPoints = POSPointsBLL.SelectPosPoints(strQueryPosPoints);

                if (dsPosPoints.Tables[0] != null && dsPosPoints.Tables[0].Rows.Count != 0)
                {
                    gvPosPoints.DataSource = dsPosPoints.Tables[0];
                    gvPosPoints.DataBind();
                }
                else
                {
                    gvPosPoints.DataSource = null;
                    gvPosPoints.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Method

        #region Button Event

        /// <summary>
        /// Save and Update Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    Category IsDupCategory = new Category();
                    IsDupCategory.CategoryName = txtCategoryName.Text.Trim();
                    IsDupCategory.IsActive = true;
                    IsDupCategory.PropertyID = clsSession.PropertyID;

                    List<Category> LstDupCategory = CategoryBLL.GetAll(IsDupCategory);

                    if (LstDupCategory.Count > 0)
                    {
                        if (this.CategoryID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupCategory[0].CategoryID)) != Convert.ToString(this.CategoryID))
                            {
                                IsListMessage = true;
                                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                mvCategory.ActiveViewIndex = 1;
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            mvCategory.ActiveViewIndex = 1;
                            return;
                        }
                    }

                    List<CategoryPOSPoints> lstCategoryPOSPoints = new List<CategoryPOSPoints>();

                    if (this.CategoryID != Guid.Empty)
                    {
                        Category objUpdateCategory = new Category();
                        Category objOldRoleData = new Category();
                        objUpdateCategory = CategoryBLL.GetByPrimaryKey(this.CategoryID);
                        objOldRoleData = CategoryBLL.GetByPrimaryKey(this.CategoryID);

                        objUpdateCategory.CategoryName = txtCategoryName.Text.Trim();
                        objUpdateCategory.CategoryCode = txtCategoryCode.Text.Trim();
                        objUpdateCategory.Details = Convert.ToString(txtCategoryDescription.Text.Trim());
                        if (ddlReferenceCategory.SelectedIndex != 0)
                            objUpdateCategory.RefCategoryID = new Guid(ddlReferenceCategory.SelectedValue);
                        else
                            objUpdateCategory.RefCategoryID = null;

                        for (int i = 0; i < gvPosPoints.Rows.Count; i++)
                        {
                            if (((CheckBox)gvPosPoints.Rows[i].FindControl("chkSelectPosPoints")).Checked)
                            {
                                CategoryPOSPoints objCategoryPOSPoints = new CategoryPOSPoints();
                                objCategoryPOSPoints.POSPointID = new Guid(Convert.ToString(gvPosPoints.DataKeys[i]["POSPointID"]));
                                objCategoryPOSPoints.Location_TermID = new Guid(Convert.ToString(gvPosPoints.DataKeys[i]["POSLocation_TermID"]));
                                objCategoryPOSPoints.IsActive = true;

                                lstCategoryPOSPoints.Add(objCategoryPOSPoints);
                            }
                        }

                        //CategoryBLL.Update(objUpdateCategory);
                        CategoryBLL.UpdateWithData(objUpdateCategory, lstCategoryPOSPoints);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldRoleData.ToString(), objUpdateCategory.ToString(), "mst_Category");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Category objSaveCategory = new Category();
                        objSaveCategory.PropertyID = clsSession.PropertyID;
                        objSaveCategory.CompanyID = clsSession.CompanyID;
                        objSaveCategory.CategoryName = txtCategoryName.Text.Trim();
                        objSaveCategory.CategoryCode = txtCategoryCode.Text.Trim();
                        if (ddlReferenceCategory.SelectedIndex != 0)
                            objSaveCategory.RefCategoryID = new Guid(ddlReferenceCategory.SelectedValue);
                        objSaveCategory.IsActive = true;
                        objSaveCategory.UpdatedOn = DateTime.Now;
                        objSaveCategory.IsSynch = false;
                        objSaveCategory.UpdatedBy = clsSession.UserID;
                        objSaveCategory.Details = Convert.ToString(txtCategoryDescription.Text.Trim());

                        for (int i = 0; i < gvPosPoints.Rows.Count; i++)
                        {
                            if (((CheckBox)gvPosPoints.Rows[i].FindControl("chkSelectPosPoints")).Checked)
                            {
                                CategoryPOSPoints objCategoryPOSPoints = new CategoryPOSPoints();
                                objCategoryPOSPoints.POSPointID = new Guid(Convert.ToString(gvPosPoints.DataKeys[i]["POSPointID"]));
                                objCategoryPOSPoints.Location_TermID = new Guid(Convert.ToString(gvPosPoints.DataKeys[i]["POSLocation_TermID"]));
                                objCategoryPOSPoints.IsActive = true;

                                lstCategoryPOSPoints.Add(objCategoryPOSPoints);
                            }
                        }

                        //CategoryBLL.Save(objSaveCategory);
                        CategoryBLL.SaveWithData(objSaveCategory, lstCategoryPOSPoints);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objSaveCategory.ToString(), objSaveCategory.ToString(), "mst_Category");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }
                    ClearControl();
                    mvCategory.ActiveViewIndex = 1;

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

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                txtSearceCategoryCode.Text = txtSearchCategoryName.Text = "";
                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            ClearControl();
            txtSearceCategoryCode.Text = txtSearchCategoryName.Text = "";
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
            mvCategory.ActiveViewIndex = 0;
        }

        /// <summary>
        /// Add new Role Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddTopCategory_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControl();
                mvCategory.ActiveViewIndex = 1;

                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchCategory_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvCategoryList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindTreeviewGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Button Event

        #region Grid Event

        protected void gvCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearControl();
                    this.CategoryID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadCategoryData();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.CategoryID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCategories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");

                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CategoryID")));

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
                    ((Label)e.Row.FindControl("lblGvHdrCategoryCode")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryCode", "Category Code");
                    ((Label)e.Row.FindControl("lblGvHdrCategoryName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryName", "Category Name");
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

        protected void gvCategoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategoryList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearControl();
                    this.CategoryID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadCategoryData();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.CategoryID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCategoryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");

                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CategoryID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrCategoryCode")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryCode", "Category Code");
                    ((Label)e.Row.FindControl("lblGvHdrCategoryName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCategoryName", "Category Name");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                    ((Label)e.Row.FindControl("lblGvHdrReferenceCategoryName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrReferenceCategoryName", "Reference Category");
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

        protected void gvPosPoints_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrSelect", "Select");
                    ((Label)e.Row.FindControl("lblGvHdrPOSPointName")).Text = clsCommon.GetGlobalResourceText("POSPoints", "lblGvHdrPointName", "Point Name");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblPosPointsNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion Grid Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    Category objCategory = new Category();
                    objCategory.PropertyID = clsSession.PropertyID;
                    objCategory.CompanyID = clsSession.CompanyID;
                    objCategory.IsActive = true;
                    listDeleteCategory = CategoryBLL.GetAll(objCategory);

                    string strDel = RecursiveDeleteData(Convert.ToString(hdnConfirmDelete.Value)) + "'" + Convert.ToString(hdnConfirmDelete.Value) + "'";

                    mpeConfirmDelete.Hide();
                    Category objDelete = new Category();
                    objDelete = CategoryBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    if (strDel.Length != 0)
                    {

                        string strDeleteID = "delete from mst_Category where CategoryID in (" + strDel + ")";
                        CategoryBLL.DeleteCategoryData(strDeleteID);
                    }

                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Category");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

    }
}