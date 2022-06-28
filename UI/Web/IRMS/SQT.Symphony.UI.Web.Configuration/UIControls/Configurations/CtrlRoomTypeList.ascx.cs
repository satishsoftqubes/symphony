using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlRoomTypeList : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsListMessage = false;

        public Guid RoomTypeID
        {
            get
            {
                return ViewState["RoomTypeID"] != null ? new Guid(Convert.ToString(ViewState["RoomTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomTypeID"] = value;
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
        #endregion Variable and Property

        #region Form Load
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();
                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = string.Empty;
                LoadDefaultData();
                BindBreadCrumb();
            }

        }

        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITTYPESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");
            
            btnAddBottomRoomType.Visible = btnAddTopRoomType.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Load Default Data
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                SetPageLabels();
                BindDDL();
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
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName ;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnitTypesList", "Room Type List");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Method
        /// </summary>
        private void BindGrid()
        {
            try
            {
                string RoomTypeName = null;
                if (txtSRoomTypeListName.Text.Trim() != string.Empty)
                    RoomTypeName = Convert.ToString(txtSRoomTypeListName.Text.Trim());
                else
                    RoomTypeName = null;

                List<RoomType> lstRoomType = null;
                lstRoomType = RoomTypeBLL.SearchRoomTypeData(null, clsSession.PropertyID, null, null, RoomTypeName);
                lstRoomType.Sort((RoomType r1, RoomType r2) => r1.RoomTypeName.CompareTo(r2.RoomTypeName));
                gvRoomTypeList.DataSource = lstRoomType;
                gvRoomTypeList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Set Page Labels 
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblMainHeader", "ROOM TYPE SETUP");
            litSearchRoomTypeListName.Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblSearchRoomTypeListName", "Room Type");
            litRoomTypeList.Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblRoomTypeList", "Room Type List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblMsgDeleteConfirmation", "Room Type");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnAddTopRoomType.Text = btnAddBottomRoomType.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblHeaderConfirmDeletePopup", "Room Type");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {                              
            this.RoomTypeID = Guid.Empty;
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSRoomTypeListName.Text = "";
        }

        /// <summary>
        /// Bind DDL
        /// </summary>
        private void BindDDL()
        {
            //string strWindQuery = "select * from mst_Wing where IsActive = 1 And PropertyID = ";
            //DataSet dsWing = WingBLL.GetWing(strWindQuery);

            //List<Floor> lstFloor = null;
            //Floor objFloor = new Floor();
            //objFloor.IsActive = true;
            //objFloor.PropertyID = clsSession.PropertyID;
            //lstFloor = FloorBLL.GetAll(objFloor);
            
        }

        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Data Row Bound Eent
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvRoomTypeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomTypeID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrTypeName")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrTypeName", "Room Type");
                    ((Label)e.Row.FindControl("lblGvHdrUnitType")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrUnitType", "Code");
                    //((Label)e.Row.FindControl("lblGvHdrRackRate")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrRackRate", "Rack Rate");
                    //((Label)e.Row.FindControl("lblGvHdrMaxStay")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrMaxStay", "Max Stay");
                    //((Label)e.Row.FindControl("lblGvHdrMinStay")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrMinStay", "Min Stay");
                    ((Label)e.Row.FindControl("lblGvHdrNoOfBed")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrNoOfBed", "No. of Beds");
                    ((Label)e.Row.FindControl("lblGvHdrBedSize")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrBedSize", "Bed Size");
                    ((Label)e.Row.FindControl("lblGvHdrMaxAdult")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrMaxAdult", "Max Adult");
                    ((Label)e.Row.FindControl("lblGvHdrMaxChild")).Text = clsCommon.GetGlobalResourceText("RoomTypeList", "lblGvHdrMaxChild", "Max Child");
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
        /// Row Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvRoomTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "ROOMTYPE";                    
                    Response.Redirect("~/GUI/Configurations/RoomType.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    mpeConfirmDelete.Show();
                    this.RoomTypeID = new Guid(Convert.ToString(e.CommandArgument));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Page Index Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvRoomTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomTypeList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Control Event

        /// <summary>
        /// Add New Room Type
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTopRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/GUI/Configurations/RoomType.aspx");
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
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvRoomTypeList.PageIndex = 0;
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
                BindGrid();
            }
            catch (Exception ex)
            {
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
                    SQT.Symphony.BusinessLogic.Configuration.DTO.RoomType objDelete = new SQT.Symphony.BusinessLogic.Configuration.DTO.RoomType();
                    objDelete = RoomTypeBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    RoomTypeBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_RoomType");
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

        #endregion        
    }
}