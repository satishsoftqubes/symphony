using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlRoomStatus : System.Web.UI.UserControl
    {
        #region Variable and Property
        public bool IsListMessage = false;
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
        public Guid BlockRoomID
        {
            get
            {
                return ViewState["BlockRoomID"] != null ? new Guid(Convert.ToString(ViewState["BlockRoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["BlockRoomID"] = value;
            }
        }

        public int cntRoomType
        {
            get
            {
                return ViewState["cntRoomType"] != null ? Convert.ToInt32(ViewState["cntRoomType"]) : 0;
            }
            set
            {
                ViewState["cntRoomType"] = value;
            }
        }

        public string strClearDateTooltip
        {
            get
            {
                return ViewState["strClearDateTooltip"] != null ? Convert.ToString(ViewState["strClearDateTooltip"]) : string.Empty;
            }
            set
            {
                ViewState["strClearDateTooltip"] = value;
            }
        }

        #endregion Variable and Property

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string path = Server.MapPath("~/App_GlobalResources");
                //int fCount = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;

                //string[] files = System.IO.Directory.GetFiles(path, "*1003_*.*", System.IO.SearchOption.AllDirectories);
                //string[] files = System.IO.Directory.GetFiles(path, "1003_*.*", System.IO.SearchOption.AllDirectories);


                //string strPropertyCode = Convert.ToString(clsSession.HotelCode) + "_*.*";
                //string[] files = System.IO.Directory.GetFiles(path, strPropertyCode, System.IO.SearchOption.AllDirectories);

                //for (int i = 0; i < files.Length; i++)
                //{
                //    File.Delete(files[i]);
                //}

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                hfDateFormat.Value = clsSession.DateFormat;
                mvBlockRoom.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }
        #endregion Page Load

        #region Private Method


        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RoomStatus.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

            btnAddBottomBlockRoom.Visible = btnAddTopBlockRoom.Visible = btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindData()
        {
            try
            {
                SetPageLabels();
                calStartDate.Format = calEndDate.Format = calSSD.Format = calSED.Format = clsSession.DateFormat;
                txtSearchSD.Attributes.Add("autocomplete", "off");
                txtSearchED.Attributes.Add("autocomplete", "off");
                txtStartDate.Attributes.Add("autocomplete", "off");
                txtEndDate.Attributes.Add("autocomplete", "off");
                BindBlockRoomStatus();
                BindUnitType();
                BindGridForBlockRoom();
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblBlockRoom", "Disabled Rooms");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetPageLabels()
        {
            ltrMainHeader.Text = "DISABLED ROOMS";
            ltrHeaderConfirmDeletePopup.Text = "Disabled Rooms";
            btnYes.Text = "Yes";
            litSearchBlockBy.Text = "Disable By";
            litDate.Text = "Date";
            litBlockRoomList.Text = "Disabled Room List";
            btnAddTopBlockRoom.Text = btnAddBottomBlockRoom.Text = "Add New";
            //ltrHeaderPopupBlockRoom.Text = clsCommon.GetGlobalResourceText("BlockRoom", "lblHeaderPopupBlockRoom");
            ltrConfirmDeleteMsg.Text = "Sure you want to delete?";
            litStartDate.Text = "Start Date";
            litEndDate.Text = "End Date";
            litBlockReason.Text = "Disable Reason";
            btnSave.Text = "Save";
            btnNo.Text = btnCancel.Text = "Cancel";
            litRooms.Text = "Rooms";
            ltrHeaderConfirmDeletePopup.Text = "Disabled Rooms";
            litGvRoomsPopupHeader.Text = "Rooms";
            imtbtnSearchBlockRoom.ToolTip = "Search";
            imtbtnSearchClearBlockRoom.ToolTip = "Reset";
            this.strClearDateTooltip = "Clear Date";
            imdSSD.ToolTip = imgSED.ToolTip = imgCalStartDate.ToolTip = imgCalEndDate.ToolTip = "Choose Date";
            ltrHeaderDateValidate.Text = litHeaderCustomePopupMessage.Text = "Message";
            ltrMsgDateValidate.Text = "Date from should be less than or equal to Date to.";
            btnDateMessageOK.Text = "OK";
            lblBRDateMsg.Text = "Start Date should be less than or equal to End Date.";
            litCustomePopupMsg.Text = "Please Select atleast one Room";
            litGeneralMandartoryFiledMessage.Text = "All Bold Fields are Mandatory";
            btnBackToList.Text = "Back to List";
            litBlockFor.Text = "Block For";
            btnEnableBlockRoom.Text = "Enable Room";
        }

        /// <summary>
        /// Bind Unit Type
        /// </summary>
        private void BindUnitType()
        {
            try
            {
                DataSet dsRoomType = RoomTypeBLL.GetDistinctRoomTypeOnRoom(clsSession.PropertyID);
                gvRoomTypes.DataSource = dsRoomType.Tables[0];
                gvRoomTypes.DataBind();

                if (dsRoomType.Tables[0].Rows.Count > 0)
                    hdncnt.Value = Convert.ToString(dsRoomType.Tables[0].Rows.Count);
                else
                    hdncnt.Value = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGridForBlockRoom()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                DateTime? StartDate = null;
                DateTime? EndDate = null;
                string BlockBy = null;

                if (txtSearchSD.Text.Trim() != "")
                    StartDate = DateTime.ParseExact(txtSearchSD.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                else
                    StartDate = null;
                if (txtSearchED.Text.Trim() != "")
                    EndDate = DateTime.ParseExact(txtSearchED.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                else
                    EndDate = null;

                if (txtSearchBlockBy.Text.Trim() != "")
                    BlockBy = txtSearchBlockBy.Text.Trim();
                else
                    BlockBy = null;

                DataSet dsBlockRoom = RoomBlockBLL.RoomBlockSelectAllRoomBlockData(StartDate, EndDate, BlockBy, clsSession.PropertyID, clsSession.CompanyID);

                if (dsBlockRoom.Tables.Count > 0 && dsBlockRoom.Tables[0].Rows.Count > 0)
                {
                    gvBlockRoomList.DataSource = dsBlockRoom;
                    gvBlockRoomList.DataBind();
                }
                else
                {
                    gvBlockRoomList.DataSource = null;
                    gvBlockRoomList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Control Method
        /// </summary>
        private void ClearControl()
        {
            //IsListMessage = false;
            this.BlockRoomID = Guid.Empty;
            calStartDate.Format = calEndDate.Format = calSSD.Format = calSED.Format = clsSession.DateFormat;
            txtStartDate.Attributes.Add("autocomplete", "off");
            txtEndDate.Attributes.Add("autocomplete", "off");
            txtStartDate.Text = txtEndDate.Text = txtBlockReason.Text = "";
            //mvBlockRoom.ActiveViewIndex = 0;
            BindUnitType();
             rbtBlockFor.SelectedIndex = 0;
        }

        /// <summary>
        /// Bind RoomBlock Data
        /// </summary>
        private void BindRoomBlockData()
        {
            try
            {
                RoomBlock objRoomBlock = new RoomBlock();
                objRoomBlock = RoomBlockBLL.GetByPrimaryKey(this.BlockRoomID);
                if (objRoomBlock != null)
                {
                    if (Convert.ToString(objRoomBlock.StartDate) != "")
                        txtStartDate.Text = objRoomBlock.StartDate.Value.ToString(clsSession.DateFormat);
                    if (Convert.ToString(objRoomBlock.EndDate) != "")
                        txtEndDate.Text = objRoomBlock.EndDate.Value.ToString(clsSession.DateFormat);
                    txtBlockReason.Text = Convert.ToString(objRoomBlock.BlockReason);

                    if (Convert.ToString(objRoomBlock.BlockForTermID) != "" && objRoomBlock.BlockForTermID != null)
                        rbtBlockFor.SelectedValue = Convert.ToString(objRoomBlock.BlockForTermID);

                    DataSet dsRoomBlockDetails = new DataSet();
                    RoomBlockDetails objLoadRoomBlockDetails = new RoomBlockDetails();
                    objLoadRoomBlockDetails.BlockRoomID = objRoomBlock.BlockRoomID;
                    dsRoomBlockDetails = RoomBlockDetailsBLL.GetAllWithDataSet(objLoadRoomBlockDetails);

                    if (dsRoomBlockDetails.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < gvRoomTypes.Rows.Count; i++)
                        {
                            DataList dtlstRoom = (DataList)gvRoomTypes.Rows[i].FindControl("dtlstRoom");

                            if (dtlstRoom != null)
                            {
                                for (int j = 0; j < dtlstRoom.Items.Count; j++)
                                {
                                    DataListItem row = dtlstRoom.Items[j];
                                    DataRow[] rows = dsRoomBlockDetails.Tables[0].Select("RoomID = '" + dtlstRoom.DataKeys[j].ToString() + "'");
                                    if (rows.Length > 0)
                                    {
                                        ((CheckBox)row.FindControl("chkRptRoomNo")).Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            calSSD.Format = calSED.Format = clsSession.DateFormat;
            txtSearchSD.Text = txtSearchED.Text = txtSearchBlockBy.Text = "";
            txtSearchSD.Attributes.Add("autocomplete", "off");
            txtSearchED.Attributes.Add("autocomplete", "off");
        }

        public string TruncateString(string TruncString, int NumberOfCharacter)
        {
            string NewStr;
            if (TruncString.Length > NumberOfCharacter + 1)
            {
                NewStr = TruncString.Substring(0, NumberOfCharacter) + "...";
            }
            else
            {
                NewStr = TruncString;
            }

            return NewStr;
        }

        private void BindBlockRoomStatus()
        {
            try
            {
                rbtBlockFor.Items.Clear();
                //Find(item => item.ProductId == ProductID && item.ProductName == "ABS001");
                List<ProjectTerm> lstProjectTermBRS = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "BLOCK ROOM STATUS");
                if (lstProjectTermBRS.Count != 0)
                {
                    List<ProjectTerm> lstFilterProjectTermBRS = lstProjectTermBRS.Where(x => x.Term != "Full Room Reservation" && x.Term != "Investor Occupied").ToList();
                    rbtBlockFor.DataSource = lstFilterProjectTermBRS;
                    rbtBlockFor.DataTextField = "DisplayTerm";
                    rbtBlockFor.DataValueField = "TermID";
                    rbtBlockFor.DataBind();
                    rbtBlockFor.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public static string GetFormatedRoomNumber(string strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber != "")
            {
                string[] str = strRoomNumber.Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }

        #endregion Private Method

        #region GridEvent

        protected void gvBlockRoomList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkBRDelete");

                    ////if (this.UserRights.Substring(2, 1) == "1")
                    ////    ((LinkButton)e.Row.FindControl("lnkBREdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    ////else
                    ////    ((LinkButton)e.Row.FindControl("lnkBREdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    ////lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    ////lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");


                    ////((LinkButton)e.Row.FindControl("lnkView")).Text = clsCommon.GetGlobalResourceText("BlockRoom", "lblGvView", "View");                
                    ////((Label)e.Row.FindControl("lnkView")).Text = clsCommon.GetGlobalResourceText("BlockRoom", "lblGvView", "View");

                    ////lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BlockRoomID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = "No.";
                    ((Label)e.Row.FindControl("lblGvHdrDate")).Text = "Date";
                    ////((Label)e.Row.FindControl("lblGvHdrNoOfRooms")).Text = clsCommon.GetGlobalResourceText("BlockRoom", "lblGvHdrNoOfRooms", "No. Of Rooms");
                    ////((Label)e.Row.FindControl("lblGvHdrReason")).Text = clsCommon.GetGlobalResourceText("BlockRoom", "lblGvHdrReason", "Cause / Reason");
                    ((Label)e.Row.FindControl("lblGvHdrBlockBy")).Text = "Block By";
                    ////((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                    ((Label)e.Row.FindControl("lblGvHdrRoomNo")).Text = "Room No.";
                    ((Label)e.Row.FindControl("lblGvHdrSelect")).Text = "Select";
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = "No record found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomTypes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Guid RoomTypeID = new Guid(gvRoomTypes.DataKeys[e.Row.RowIndex].Value.ToString());
                    string strRoomNoQuery = "select RoomID, RoomTypeID,(SELECT LEFT(mst_Room.RoomNo, ISNULL(NULLIF(CHARINDEX('|', mst_Room.RoomNo) - 1, -1), LEN(mst_Room.RoomNo)))) 'RoomNo' from mst_Room where IsActive = 1 and PropertyID='" + Convert.ToString(clsSession.PropertyID) + "' and RoomTypeID = '" + RoomTypeID + "' and ReferenceRoomID is null order by RoomNo Asc";
                    DataSet dsRoom = RoomBLL.GetUnitNo(strRoomNoQuery);

                    DataList dtlstRoom = (DataList)(e.Row.FindControl("dtlstRoom"));

                    if (dsRoom.Tables[0].Rows.Count > 0)
                    {
                        dtlstRoom.DataSource = dsRoom.Tables[0];
                        dtlstRoom.DataBind();
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    //((Label)e.Row.FindControl("lblGvHdrRooms")).Text = clsCommon.GetGlobalResourceText("BlockRoom", "lblGvHdrRooms");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblGVNoRecordFound")).Text = "No record found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvBlockRoomList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearControl();
                    this.BlockRoomID = new Guid(Convert.ToString(e.CommandArgument));
                    mvBlockRoom.ActiveViewIndex = 1;
                    BindRoomBlockData();
                }
                else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.BlockRoomID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvBlockRoomList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBlockRoomList.PageIndex = e.NewPageIndex;
            BindGridForBlockRoom();
        }
        #endregion GridEvent

        #region Control Event
        /// <summary>
        /// Add New Block Room
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTopBlockRoom_Click(object sender, EventArgs e)
        {
            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();
            mvBlockRoom.ActiveViewIndex = 1;
        }

        /// <summary>
        /// Save And Update Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    List<RoomBlockDetails> lstRoomBlockDetails = new List<RoomBlockDetails>();

                    if (this.BlockRoomID != Guid.Empty)
                    {
                        RoomBlock objToUpdate = new RoomBlock();
                        RoomBlock objOldData = new RoomBlock();
                        objToUpdate = RoomBlockBLL.GetByPrimaryKey(this.BlockRoomID);
                        objOldData = RoomBlockBLL.GetByPrimaryKey(this.BlockRoomID);


                        if (txtStartDate.Text.Trim() != "")
                            objToUpdate.StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        if (txtEndDate.Text.Trim() != "")
                            objToUpdate.EndDate = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objToUpdate.BlockReason = txtBlockReason.Text.Trim();
                        objToUpdate.UpdatedOn = DateTime.Now;
                        objToUpdate.DateOfBlock = DateTime.Now;
                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.BlockBy = clsSession.UserName;

                        if (rbtBlockFor.Items.Count > 0)
                            objToUpdate.BlockForTermID = new Guid(rbtBlockFor.SelectedValue);

                        for (int i = 0; i < gvRoomTypes.Rows.Count; i++)
                        {
                            DataList dtlstRoom = (DataList)gvRoomTypes.Rows[i].FindControl("dtlstRoom");

                            if (dtlstRoom != null)
                            {
                                for (int j = 0; j < dtlstRoom.Items.Count; j++)
                                {
                                    CheckBox chkRptRoomNo = (CheckBox)dtlstRoom.Items[j].FindControl("chkRptRoomNo");
                                    if (chkRptRoomNo != null && chkRptRoomNo.Checked)
                                    {
                                        RoomBlockDetails objTemp = new RoomBlockDetails();
                                        objTemp.RoomID = new Guid(dtlstRoom.DataKeys[j].ToString());
                                        objTemp.RoomTypeID = new Guid(gvRoomTypes.DataKeys[i]["RoomTypeID"].ToString());
                                        lstRoomBlockDetails.Add(objTemp);
                                    }
                                }
                            }
                        }

                        RoomBlockBLL.Update(objToUpdate, lstRoomBlockDetails);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldData.ToString(), objToUpdate.ToString(), "mst_RoomBlock");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        RoomBlock objToInsert = new RoomBlock();

                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.CompanyID = clsSession.CompanyID;
                        if (txtStartDate.Text.Trim() != "")
                            objToInsert.StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        if (txtEndDate.Text.Trim() != "")
                            objToInsert.EndDate = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objToInsert.BlockReason = txtBlockReason.Text.Trim();
                        objToInsert.BlockBy = clsSession.UserName;
                        objToInsert.IsActive = true;
                        objToInsert.UpdatedOn = DateTime.Now;
                        objToInsert.DateOfBlock = DateTime.Now;
                        objToInsert.UpdatedBy = clsSession.UserID;
                        objToInsert.IsSynch = false;

                        if (rbtBlockFor.Items.Count > 0)
                            objToInsert.BlockForTermID = new Guid(rbtBlockFor.SelectedValue);

                        for (int i = 0; i < gvRoomTypes.Rows.Count; i++)
                        {
                            DataList dtlstRoom = (DataList)gvRoomTypes.Rows[i].FindControl("dtlstRoom");

                            if (dtlstRoom != null)
                            {
                                for (int j = 0; j < dtlstRoom.Items.Count; j++)
                                {
                                    CheckBox chkRptRoomNo = (CheckBox)dtlstRoom.Items[j].FindControl("chkRptRoomNo");
                                    if (chkRptRoomNo != null && chkRptRoomNo.Checked)
                                    {
                                        RoomBlockDetails objTemp = new RoomBlockDetails();
                                        objTemp.RoomID = new Guid(dtlstRoom.DataKeys[j].ToString());
                                        objTemp.RoomTypeID = new Guid(gvRoomTypes.DataKeys[i]["RoomTypeID"].ToString());
                                        lstRoomBlockDetails.Add(objTemp);
                                    }
                                }
                            }
                        }

                        RoomBlockBLL.Save(objToInsert, lstRoomBlockDetails);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_RoomBlock");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }
                    ClearControl();
                    BindGridForBlockRoom();
                    mvBlockRoom.ActiveViewIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Save And Update Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindGridForBlockRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = string.Empty;
            mvBlockRoom.ActiveViewIndex = 0;
        }

        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imtbtnSearchBlockRoom_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvBlockRoomList.PageIndex = 0;
                BindGridForBlockRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event For Block Room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imtbtnSearchClearBlockRoom_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGridForBlockRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnEnableBlockRoom_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < gvBlockRoomList.Rows.Count; i++)
                {
                    CheckBox chkSelect = (CheckBox)gvBlockRoomList.Rows[i].FindControl("chkSelect");

                    if (chkSelect.Checked)
                    {
                        Guid BlockRoomDetailID = new Guid(gvBlockRoomList.DataKeys[i]["BlockRoomDetailID"].ToString());
                        Guid BlockRoomID = new Guid(gvBlockRoomList.DataKeys[i]["BlockRoomID"].ToString());
                        Guid RoomID = new Guid(gvBlockRoomList.DataKeys[i]["RoomID"].ToString());

                        RoomBlockDetails objDelete = new RoomBlockDetails();
                        objDelete = RoomBlockDetailsBLL.GetByPrimaryKey(BlockRoomDetailID);

                        RoomBlockBLL.DeleteBlockRoomDetailsRoomData(BlockRoomDetailID, BlockRoomID, RoomID);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_RoomBlockDetails");
                    }
                }

                IsListMessage = true;
                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");

                calStartDate.Format = calEndDate.Format = calSSD.Format = calSED.Format = clsSession.DateFormat;
                txtStartDate.Attributes.Add("autocomplete", "off");
                txtEndDate.Attributes.Add("autocomplete", "off");
                txtStartDate.Text = txtEndDate.Text = txtBlockReason.Text = "";
                BindGridForBlockRoom();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    RoomBlock objDelete = new RoomBlock();
                    objDelete = RoomBlockBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    RoomBlockBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_RoomBlock");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGridForBlockRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}