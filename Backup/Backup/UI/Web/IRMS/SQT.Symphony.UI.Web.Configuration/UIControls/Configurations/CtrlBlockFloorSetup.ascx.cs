using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlBlockFloorSetup : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessageBlock = false;
        public bool IsMessageFloor = false;

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

        public Guid WingID
        {
            get
            {
                return ViewState["WingID"] != null ? new Guid(Convert.ToString(ViewState["WingID"])) : Guid.Empty;
            }
            set
            {
                ViewState["WingID"] = value;
            }
        }

        public Guid FloorID
        {
            get
            {
                return ViewState["FloorID"] != null ? new Guid(Convert.ToString(ViewState["FloorID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FloorID"] = value;
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

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                mvBlock.ActiveViewIndex = mvFloor.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "BLOCKFLOORSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBlocks.Visible = btnAddTopBlock.Visible = BtnAddFloor.Visible = btnAddTopFloor.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        //Method to Bind default data.
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindBlockCheckBox();
                BindGrid();
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblBlockFloor", "Block/Floor");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            ltrMainHeaderBlock.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblMainHeaderBlock", "Block");
            litSearchBlockName.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblSearchBlockName", "Block Name");
            ltrBlockName.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblBlockName", "Block Name");
            ltrBlockCode.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblBlockCode", "Block Code");
            ltrMainHeaderFloor.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblMainHeaderFloor", "Floor");
            litSearchFloorName.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblFloorNameSearch", "Floor Name");
            ltrFloor.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblFloor", "Floor Name");
            ltrFloorBlock.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblFloorBlock", "Block Name");
            btnAddTopBlock.Text = btnAddBlocks.Text = btnAddTopFloor.Text = BtnAddFloor.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = btnBlockCancel.Text = btnCancelFloor.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnBlockSave.Text = btnSaveFloor.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litBlockList.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblBlockList", "Block List");
            litFloorList.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblFloorList", "Floor List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "ltrHeaderConfirmDeletePopup", "Block / Floor");
            btnSearchFloor.ToolTip = btnSearchBlock.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearchFloor.ToolTip = imgbtnClearSearchBlock.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            btnBackToBlockList.Text = btnBackToFloorList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
            litGeneralMandartoryFiledMessageForFloor.Text = litGeneralMandartoryFiledMessageForBlock.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");             
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            try
            {
                BindBlockGrid();
                BindFloorGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Block Grid Information
        /// </summary>
        private void BindBlockGrid()
        {
            string BlockName = null;
            if (txtSearchBlockName.Text.Trim() != "")
                BlockName = txtSearchBlockName.Text.Trim();
            else
                BlockName = null;

            DataSet dsWing = WingBLL.SearchWingData(null, clsSession.PropertyID, BlockName);
            DataView dvWing = new DataView(dsWing.Tables[0]);
            dvWing.Sort = "WingName Asc";
            gvBlocks.DataSource = dvWing;
            gvBlocks.DataBind();
        }

        /// <summary>
        /// Bind Floor Grid Information
        /// </summary>
        private void BindFloorGrid()
        {
            string FloorName = null;

            Floor GetAllFloor = new Floor();
            if (txtSearchFloorName.Text.Trim() != "")
                FloorName = txtSearchFloorName.Text.Trim();

            DataSet dsSearchFloor = FloorBLL.SearchFloorData(null, clsSession.PropertyID, FloorName);

            gvFloors.DataSource = dsSearchFloor.Tables[0];
            gvFloors.DataBind();
        }

        /// <summary>
        /// ClearControl Block 
        /// </summary>
        private void ClearControlBlock()
        {
            txtBlockName.Text = txtBlockCode.Text = "";
            this.WingID = Guid.Empty;
            ////mvBlock.ActiveViewIndex = 0;
            BindBlockCheckBox();
            BindCheckBoxBlock();
            BindBlockGrid();
        }

        /// <summary>
        /// ClearControl Block 
        /// </summary>
        private void ClearControlFloor()
        {
            txtFloor.Text = "";
            chkLstBlocks.Items.Clear();
            this.FloorID = Guid.Empty;
            //mvFloor.ActiveViewIndex = 0;
            trBlockList.Visible = false;
            BindBlockCheckBox();
            BindFloorGrid();
            BindBlockGrid();
        }

        /// <summary>
        /// Save And Update Block Method
        /// </summary>
        private void SaveAndUpdateBlock()
        {
            Wing IsWingDup = new Wing();
            IsWingDup.WingName = txtBlockName.Text.Trim();
            IsWingDup.PropertyID = clsSession.PropertyID;
            IsWingDup.IsActive = true;
            List<Wing> LstDupWing = WingBLL.GetAll(IsWingDup);
            if (LstDupWing.Count > 0)
            {
                if (this.WingID != Guid.Empty)
                {
                    if (Convert.ToString((LstDupWing[0].WingID)) != Convert.ToString(this.WingID))
                    {
                        IsMessageBlock = true;
                        litMsgListBlock.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mvBlock.ActiveViewIndex = 1;
                        return;
                    }
                }
                else
                {
                    IsMessageBlock = true;
                    litMsgListBlock.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mvBlock.ActiveViewIndex = 1;
                    return;
                }
            }
            if (this.WingID != Guid.Empty)
            {
                //Update Wing Information
                Wing objOldWingData = WingBLL.GetByPrimaryKey(this.WingID);
                Wing objUpdateWing = WingBLL.GetByPrimaryKey(this.WingID);

                objUpdateWing.WingName = txtBlockName.Text;
                objUpdateWing.WingCode = txtBlockCode.Text;
                objUpdateWing.LastUpdateOn = DateTime.Now;
                objUpdateWing.LastUpdatedBy = clsSession.UserID;
                WingBLL.Update(objUpdateWing);
                ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldWingData.ToString(), objUpdateWing.ToString(), "mst_Wing");
                IsMessageBlock = true;
                litMsgListBlock.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                //Insert Wing Information
                Wing objSaveWing = new Wing();
                objSaveWing.PropertyID = clsSession.PropertyID;
                objSaveWing.WingName = txtBlockName.Text;
                objSaveWing.WingCode = txtBlockCode.Text;
                objSaveWing.IsActive = true;
                objSaveWing.CreatedOn = DateTime.Now;
                objSaveWing.IsSynch = false;
                objSaveWing.CreatedBy = clsSession.UserID;
                WingBLL.Save(objSaveWing);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objSaveWing.ToString(), null, "mst_Wing");
                IsMessageBlock = true;
                litMsgListBlock.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            ClearControlBlock();
        }

        /// <summary>
        /// Save And Update Floor Method
        /// </summary>
        private void SaveAndUpdateFloor()
        {
            Floor IsFloorDup = new Floor();
            IsFloorDup.FloorName = txtFloor.Text.Trim();
            IsFloorDup.PropertyID = clsSession.PropertyID;
            IsFloorDup.IsActive = true;
            List<Floor> LstDupFloor = FloorBLL.GetAll(IsFloorDup);
            if (LstDupFloor.Count > 0)
            {
                if (this.FloorID != Guid.Empty)
                {
                    if (Convert.ToString((LstDupFloor[0].FloorID)) != Convert.ToString(this.FloorID))
                    {
                        IsMessageFloor = true;
                        litMsgListFloor.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mvFloor.ActiveViewIndex = 1;
                        return;
                    }
                }
                else
                {
                    IsMessageFloor = true;
                    litMsgListFloor.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mvFloor.ActiveViewIndex = 1;
                    return;
                }
            }

            List<WingFloorJoin> lstWingFloorJoin = new List<WingFloorJoin>();
            if (this.FloorID != Guid.Empty)
            {
                //Update Wing Information
                Floor objOldFloorData = FloorBLL.GetByPrimaryKey(new Guid(ViewState["FloorID"].ToString()));
                Floor objToUpdate = FloorBLL.GetByPrimaryKey(new Guid(ViewState["FloorID"].ToString()));

                objToUpdate.FloorName = txtFloor.Text;
                objToUpdate.LastUpdateOn = DateTime.Now;
                objToUpdate.LastUpdatedBy = clsSession.UserID;

                for (int i = 0; i < chkLstBlocks.Items.Count; i++)
                {
                    if (chkLstBlocks.Items[i].Selected)
                    {
                        WingFloorJoin temp = new WingFloorJoin();
                        temp.IsSynch = false;
                        temp.WingID = new Guid(chkLstBlocks.Items[i].Value.ToString());
                        lstWingFloorJoin.Add(temp);
                    }
                }
                FloorBLL.Update(objToUpdate, lstWingFloorJoin);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldFloorData.ToString(), objToUpdate.ToString(), "mst_Floor");
                IsMessageFloor = true;
                litMsgListFloor.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                //Insert Wing Information
                Floor objToInsert = new Floor();
                objToInsert.PropertyID = clsSession.PropertyID;
                objToInsert.FloorName = txtFloor.Text;
                objToInsert.IsActive = true;
                objToInsert.CreatedOn = DateTime.Now.Date;
                objToInsert.CreatedBy = clsSession.UserID;

                for (int i = 0; i < chkLstBlocks.Items.Count; i++)
                {
                    if (chkLstBlocks.Items[i].Selected)
                    {
                        WingFloorJoin temp = new WingFloorJoin();
                        temp.WingID = new Guid(chkLstBlocks.Items[i].Value.ToString());
                        lstWingFloorJoin.Add(temp);
                    }
                }
                IsMessageFloor = true;
                litMsgListFloor.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                FloorBLL.Save(objToInsert, lstWingFloorJoin);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_Floor");
            }
            ClearControlFloor();
        }

        /// <summary>
        /// Bind Block Checkbox
        /// </summary>
        private void BindBlockCheckBox()
        {
            string WingQuery = "Select WingID, WingName From mst_Wing Where IsActive = 1 And PropertyID= '" + Convert.ToString(clsSession.PropertyID) + "'";
            DataSet dsWing = WingBLL.GetWing(WingQuery);

            chkLstBlocks.Items.Clear();
            if (dsWing.Tables[0].Rows.Count != 0)
            {
                DataView dvWing = new DataView(dsWing.Tables[0]);
                dvWing.Sort = "WingName Asc";
                trBlockList.Visible = true;
                for (int i = 0; i < dvWing.Count; i++)
                {
                    chkLstBlocks.Items.Add(new ListItem(Convert.ToString(dvWing[i]["WingName"]), Convert.ToString(dvWing[i]["WingID"])));
                    chkLstBlocks.Items[i].Selected = true;
                }
            }
            else
            {
                trBlockList.Visible = false;
                chkLstBlocks.DataSource = null;
                chkLstBlocks.DataBind();
            }
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControlForBlock()
        {
            txtSearchBlockName.Text = "";
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControlForFloor()
        {
            txtSearchFloorName.Text = "";
        }

        private void BindCheckBoxBlock()
        {
            if (this.FloorID != Guid.Empty)
            {
                DataSet dsWingFloorJoin = new DataSet();
                WingFloorJoin objWingFloorJoin = new WingFloorJoin();
                objWingFloorJoin.FloorID = this.FloorID;

                dsWingFloorJoin = WingFloorJoinBLL.GetAllWithDataSet(objWingFloorJoin);
                if (dsWingFloorJoin.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < chkLstBlocks.Items.Count; i++)
                    {
                        DataRow[] rows = dsWingFloorJoin.Tables[0].Select("WingID = '" + chkLstBlocks.Items[i].Value.ToString() + "'");
                        if (rows.Length > 0)
                            chkLstBlocks.Items[i].Selected = true;
                        else
                            chkLstBlocks.Items[i].Selected = false;
                    }
                }
                else
                {
                    for (int j = 0; j < chkLstBlocks.Items.Count; j++)
                    {
                        chkLstBlocks.Items[j].Selected = false;
                    }
                }
            }
        }

        #endregion Private Method

        #region Add New Block
        /// <summary>
        /// Add New Property List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddBlock_Click(object sender, EventArgs e)
        {
            try
            {
                btnBlockSave.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControlBlock();
                mvBlock.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void btnAddFloor_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveFloor.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControlFloor();
                mvFloor.ActiveViewIndex = 1;
                BindBlockCheckBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Add New Property

        #region Control Event

        /// <summary>
        /// Block Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchBlock_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvBlocks.PageIndex = 0;
                BindBlockGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Floor Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchFloor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvFloors.PageIndex = 0;
                BindFloorGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBlockSave_OnClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    SaveAndUpdateBlock();
                    mvBlock.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnBlockCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControlBlock();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToBlockList_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControlBlock();
                mvBlock.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSaveFloor_OnClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    SaveAndUpdateFloor();
                    mvFloor.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancelFloor_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControlFloor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToFloorList_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControlFloor();
                mvFloor.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event For Block
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnClearSearchBlock_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControlForBlock();
                BindBlockGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event For Floor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnClearSearchFloor_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControlForFloor();
                BindFloorGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event

        #region Grid Event
        protected void gvBlocks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmBlockDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "WingID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdWingNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrWingCode")).Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblGvHdrWingCode", "Block Code");
                    ((Label)e.Row.FindControl("lblGvHdrWingName")).Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblGvHdrWingName", "Block Name");
                    ((Label)e.Row.FindControl("lblGvHdrFloors")).Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblGvHdrFloors", "Floors");
                    ((Label)e.Row.FindControl("lblGvHdrUnits")).Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblGvHdrUnits", "Units");
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

        protected void gvBlocks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    btnBlockSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    ClearControlBlock();
                    mvBlock.ActiveViewIndex = 1;

                    Wing objWingData = WingBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    if (objWingData != null)
                    {
                        this.WingID = objWingData.WingID;
                        txtBlockCode.Text = objWingData.WingCode;
                        txtBlockName.Text = objWingData.WingName;
                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.WingID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvBlocks_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBlocks.PageIndex = e.NewPageIndex;
            BindBlockGrid();
        }

        protected void gvFloors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDeleteFloor");

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEditFloor")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEditFloor")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmFloorDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FloorID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdFloorNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrFloorName")).Text = clsCommon.GetGlobalResourceText("BlockFloorSetup", "lblGvHdrFloorName", "Floor Name");
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

        protected void gvFloors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    btnSaveFloor.Visible = this.UserRights.Substring(2, 1) == "1";
                    ClearControlFloor();
                    mvFloor.ActiveViewIndex = 1;

                    Floor objFloorData = FloorBLL.GetByPrimaryKey(new Guid(e.CommandArgument.ToString()));
                    if (objFloorData != null)
                    {
                        this.FloorID = objFloorData.FloorID;
                        txtFloor.Text = objFloorData.FloorName;

                        DataSet dsWingFloorJoin = new DataSet();
                        WingFloorJoin objWingFloorJoin = new WingFloorJoin();
                        objWingFloorJoin.FloorID = new Guid(e.CommandArgument.ToString());

                        dsWingFloorJoin = WingFloorJoinBLL.GetAllWithDataSet(objWingFloorJoin);
                        BindBlockCheckBox();
                        if (dsWingFloorJoin.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < chkLstBlocks.Items.Count; i++)
                            {
                                DataRow[] rows = dsWingFloorJoin.Tables[0].Select("WingID = '" + chkLstBlocks.Items[i].Value.ToString() + "'");
                                if (rows.Length > 0)
                                    chkLstBlocks.Items[i].Selected = true;
                                else
                                    chkLstBlocks.Items[i].Selected = false;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < chkLstBlocks.Items.Count; j++)
                            {
                                chkLstBlocks.Items[j].Selected = false;
                            }
                        }
                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControlFloor();
                    this.FloorID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvFloors_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBlocks.PageIndex = e.NewPageIndex;
            BindFloorGrid();
        }

        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty && Convert.ToString(hdnProcessType.Value) == "Block")
                {
                    Wing DeleteWingData = WingBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    WingBLL.Delete(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", DeleteWingData.ToString(), null, "mst_Wing");
                    IsMessageBlock = true;
                    litMsgListBlock.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControlBlock();
                }
                else if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty && Convert.ToString(hdnProcessType.Value) == "Floor")
                {
                    Floor DeleteFloorData = FloorBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    FloorBLL.Delete(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", DeleteFloorData.ToString(), null, "mst_Floor");
                    IsMessageFloor = true;
                    litMsgListFloor.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControlFloor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Popup Button Event

    }
}