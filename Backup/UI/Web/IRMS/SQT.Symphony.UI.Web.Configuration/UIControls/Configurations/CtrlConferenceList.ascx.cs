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
    public partial class CtrlConferenceList : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsListMessage = false;

        public Guid ConferenceID
        {
            get
            {
                return ViewState["ConferenceID"] != null ? new Guid(Convert.ToString(ViewState["ConferenceID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ConferenceID"] = value;
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
        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load Evnet
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
                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = String.Empty;
                LoadDefaultData();
                BindBreadCrumb();
            }
        }
        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CONFERENCEBANQUET.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomConference.Visible = btnAddTopConference.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Bind Grid Data
        /// </summary>
        private void LoadDefaultData()
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblConferenceBanquet", "Conference hall Name");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Data
        /// </summary>
        private void BindGrid()
        {
            try
            {
                string ConferenceName = null;
                
                if (txtSearchConferenceName.Text.Trim() != "")
                    ConferenceName = txtSearchConferenceName.Text.Trim();

                DataSet dsSearchConferenceData = ConferenceBLL.SearchConferenceData(null, ConferenceName, clsSession.PropertyID, clsSession.CompanyID);

                gvConferenceList.DataSource = dsSearchConferenceData.Tables[0];
                gvConferenceList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        /// <summary>
        /// Set Page Label
        /// </summary>
        private void SetPageLables()
        {
            litMainHeading.Text = clsCommon.GetGlobalResourceText("ConferenceList", "lblMainHeading", "Conference hall Name");
            litSearchConferenceName.Text = clsCommon.GetGlobalResourceText("ConferenceList", "lblSearchConferenceName", "Conference hall Name");
            btnAddBottomConference.Text = btnAddTopConference.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litConferenceList.Text = clsCommon.GetGlobalResourceText("ConferenceList", "lblConferenceList", "Conference hall List");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("ConferenceList", "lblHeaderConfirmDeletePopup", "Conference hall");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            this.ConferenceID = Guid.Empty;             
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearchConferenceName.Text = "";
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Data Row Bound
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvConferenceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblgvHeight = (Label)e.Row.FindControl("lblgvHeight");
                    Label lblgvWidth = (Label)e.Row.FindControl("lblgvWidth");
                    Label lblgvLength = (Label)e.Row.FindControl("lblgvLength");
                    Label lblgvRackRate = (Label)e.Row.FindControl("lblgvRackRate");

                    if (lblgvHeight != null)
                        lblgvHeight.Text = lblgvHeight.Text.Substring(0, lblgvHeight.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
                    if (lblgvWidth != null)
                        lblgvWidth.Text = lblgvWidth.Text.Substring(0, lblgvWidth.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
                    if (lblgvLength != null)
                        lblgvLength.Text = lblgvLength.Text.Substring(0, lblgvLength.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
                    if (lblgvRackRate != null)
                        lblgvRackRate.Text = lblgvRackRate.Text.Substring(0, lblgvRackRate.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ConferenceID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Literal)e.Row.FindControl("litGvHdrConferenceCode")).Text = clsCommon.GetGlobalResourceText("ConferenceList", "lblGvHdrConferenceCode", "Conference Code");
                    ((Literal)e.Row.FindControl("litGvHdrConferenceName")).Text = clsCommon.GetGlobalResourceText("ConferenceList", "lblGvHdrConferenceName", "Conference hall Name");
                    ((Literal)e.Row.FindControl("litGvHdrHeight")).Text = clsCommon.GetGlobalResourceText("ConferenceList", "litGvHdrHeight", "Height");
                    ((Literal)e.Row.FindControl("litGvHdrWidth")).Text = clsCommon.GetGlobalResourceText("ConferenceList", "litGvHdrWidth", "Width");
                    ((Literal)e.Row.FindControl("litGvHdrLength")).Text = clsCommon.GetGlobalResourceText("ConferenceList", "litGvHdrLength", "Length");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                    ((Literal)e.Row.FindControl("litGvHdrRackRate")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrRackRate", "Rack Rate");
                    ((Literal)e.Row.FindControl("litGvHdrExtNo")).Text = clsCommon.GetGlobalResourceText("ConferenceList", "lblGvHdrExtNo", "Rack Rate");
                    
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
        /// Grid Row Command Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e a GridViewCommandEventArgs</param>
        protected void gvConferenceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "CONFERENCE";                    
                    Response.Redirect("~/GUI/Configurations/Conference.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.ConferenceID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvConferenceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvConferenceList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Control Event
        /// <summary>
        /// Add Top 
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e a Button Event Args</param>
        protected void btnAddTopConference_Click(object sender, EventArgs e)
        {
            try
            {                
                ClearControl();
                Response.Redirect("~/GUI/Configurations/Conference.aspx");
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
                gvConferenceList.PageIndex = 0;
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
                if (Convert.ToString(hdnConference.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    SQT.Symphony.BusinessLogic.Configuration.DTO.Conference objDelete = new SQT.Symphony.BusinessLogic.Configuration.DTO.Conference();
                    objDelete = ConferenceBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConference.Value)));

                    ConferenceBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Conference");
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