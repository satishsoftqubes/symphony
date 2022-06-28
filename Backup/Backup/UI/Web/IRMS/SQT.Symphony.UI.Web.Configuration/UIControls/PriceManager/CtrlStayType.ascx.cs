using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlStayType : System.Web.UI.UserControl
    {
        #region Property and Variables
        // Property to save StayTypeID;
        public Guid StayTypeID
        {
            get
            {
                return ViewState["StayTypeID"] != null ? new Guid(Convert.ToString(ViewState["StayTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["StayTypeID"] = value;
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
        // Property to save UpdateLog
        public byte[] UpdateLog
        {
            get
            {
                return ViewState["UpdateLog"] != null ? (byte[])ViewState["UpdateLog"] : null;
            }
            set
            {
                ViewState["UpdateLog"] = value;
            }
        }

        // To Give Message.
        public bool IsListMessage = false;

        #endregion Property and Variables

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

                CheckUserAuthorization();
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                ucAddEditStayType.UserRights = this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "STAYTYPE.ASPX");
            else
                ucAddEditStayType.UserRights = this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottom.Visible = btnAddTop.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            StayType objToGetList = new StayType();
            if (txtSrchStayCode.Text.Trim() != string.Empty)
                objToGetList.Code = txtSrchStayCode.Text.Trim();

            if (txtSrchStayName.Text.Trim() != string.Empty)
                objToGetList.StayTypeName = txtSrchStayName.Text.Trim();

            objToGetList.IsActive = true;
            objToGetList.CompanyID = clsSession.CompanyID;
            objToGetList.PropertyID = clsSession.PropertyID;

            List<StayType> lstRecords = StayTypeBLL.GetAll(objToGetList);

            gvStayList.DataSource = lstRecords;
            gvStayList.DataBind();
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblStayType", "Stay Type") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("StayType", "lblMainHeader", "Stay Type Setup");
            litSearchStayCode.Text = clsCommon.GetGlobalResourceText("StayType", "lblSearchStayCode", "Stay Code");
            litSearchStayName.Text = clsCommon.GetGlobalResourceText("StayType", "lblSearchStayName", "Stay Name");
            btnAddTop.Text = btnAddBottom.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litStayList.Text = clsCommon.GetGlobalResourceText("StayType", "lblStayList", "Stay List");
            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("StayType", "lblHeaderConfirmDeletePopup", "Stay Type");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litHeaderCustomePopupMessage.Text = clsCommon.GetGlobalResourceText("Common", "lblHeaderCustomeMessage", "Sure you want to delete?");
            litCustomePopupMsg.Text = clsCommon.GetGlobalResourceText("StayType", "lblMsgMinShouldLessThanMaxDays", "Min Days should be less than or equal to Max Days.");
            btnOKCustomeMsgPopup.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnOK", "OK");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        private void ClearControl()
        {
            ucAddEditStayType.ucStayTypeID = this.StayTypeID = Guid.Empty;
            ucAddEditStayType.ucTxtName = ucAddEditStayType.ucTxtCode = ucAddEditStayType.ucTxtMinDays = ucAddEditStayType.ucTxtMaxDays = ucAddEditStayType.ucTxtDetails = "";
        }

        private void ClearSearchControl()
        {
            txtSrchStayCode.Text = txtSrchStayName.Text = string.Empty;
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Command Evnet
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvStayList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                ClearControl();
                
                ucAddEditStayType.ucStayTypeID = this.StayTypeID = new Guid(Convert.ToString(e.CommandArgument));
                StayType objToLoad = StayTypeBLL.GetByPrimaryKey(this.StayTypeID);
                if (objToLoad != null)
                {
                    //this.UpdateLog = objDepartment.Updatelog;
                    ucAddEditStayType.ucTxtName = objToLoad.StayTypeName;
                    ucAddEditStayType.ucTxtCode = objToLoad.Code;
                    ucAddEditStayType.ucTxtMinDays = Convert.ToString(objToLoad.MinDays);
                    ucAddEditStayType.ucTxtMaxDays = Convert.ToString(objToLoad.MaxDays);
                    ucAddEditStayType.ucTxtDetails = objToLoad.Details;

                    ucAddEditStayType.ucMpeAddEditRecord.Show();
                    ucAddEditStayType.CheckUserAuthentication();
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.StayTypeID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        /// <summary>
        /// Grid Row Data Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvStayList_RowDataBound(object sender, GridViewRowEventArgs e)
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
                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StayTypeID")));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Literal)e.Row.FindControl("litGvHdrCode")).Text = clsCommon.GetGlobalResourceText("StayType", "lblGvHdrCode", "Code");
                ((Literal)e.Row.FindControl("litGvHdrName")).Text = clsCommon.GetGlobalResourceText("StayType", "lblGvHdrName", "Name");
                ((Literal)e.Row.FindControl("litGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found");
            }
        }

        /// <summary>
        /// Paging Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvStayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStayList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add New Department
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTop_Click(object sender, EventArgs e)
        {
            ClearControl();            
            ucAddEditStayType.ucMpeAddEditRecord.Show();
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
                gvStayList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
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

        //Event which is called from AddEditRecord's userControl Opened in ModalPopup.
        protected void btnCallParent_Click(object sender, EventArgs e)
        {
            //Based on UserControl's strPopupAction condition, Take action in this(Parent) page.
            if (ucAddEditStayType.strPopupAction.ToUpper() == "SAVE")
            {
                BindGrid();
                ucAddEditStayType.ucMpeAddEditRecord.Show();
            }
            else if (ucAddEditStayType.strPopupAction.ToUpper() == "LBLMSGRECORDUPDATEDSUCCESSFULLY")
            {
                BindGrid();
                IsListMessage = true;
                litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else if (ucAddEditStayType.strPopupAction.ToUpper() == "LBLMSGRECORDSAVEDSUCCESSFULLY")
            {
                BindGrid();
                IsListMessage = true;
                litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            else if (ucAddEditStayType.strPopupAction.ToUpper() == "EXCEPTION")
            {
                MessageBox.Show(ucAddEditStayType.strExceptionMessage);
            }
        }
        #endregion Button Event

        #region Popup Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    StayType objToDelete = StayTypeBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    objToDelete.IsActive = false;

                    StayTypeBLL.Update(objToDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objToDelete.ToString(), null, "mst_StayType");
                    IsListMessage = true;
                    litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
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