using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlNewsLatterSetup : System.Web.UI.UserControl
    {
        #region Variable Property

        public bool IsMessage = false;
        public bool IsMessageLst = false;

        #endregion Variable Property

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                mvNewLatter.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "NewsLatter Setup&nbsp;";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();

            DataColumn col0 = new DataColumn();
            col0.ColumnName = "NewsLetterID";
            dt.Columns.Add(col0);

            DataColumn col1 = new DataColumn();
            col1.ColumnName = "Title";
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "NewsFor";
            dt.Columns.Add(col2);

         
            DataRow dr1 = dt.NewRow();
            dr1["NewsLetterID"] = "DBC06FD8-60D9-4008-BE1B-D24976EF7627";
            dr1["Title"] = "Sport's News";
            dr1["NewsFor"] = "Sales";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["NewsLetterID"] = "DBC06FD8-60D9-4008-BE1B-D24976EF7627";
            dr2["Title"] = "Latest News";
            dr2["NewsFor"] = "Investor";
            dt.Rows.Add(dr2);

            gvNewsLatterList.DataSource = dt;
            gvNewsLatterList.DataBind();

        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrNewsLatterHeading.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrNewsLatterHeading", "News Latter Setup");
            ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrListMessage", "Success! record delete successfully.");
            litSTitle.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "litSTitle", "Title");
            btnAddTopBlock.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "btnAddTopBlock", "Add New");
            btnAddBlocks.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "btnAddBlocks", "Add New");
            ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrSuccessfully", "Success! record save successfully.");
            ltrTitle.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrTitle", "Title");
            ltrNewsFor.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrNewsFor", "News For");
            ltrDetails.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrDetails", "Details");
            btnOk.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "btnOk", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "btnCancel", "Cancel");
            btnSaveAndPublish.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "btnSaveAndPublish", "Save & Publish");
            ltrNewsLatterList.Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrNewsLatterList", "News List");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
        }
        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Add New Template 
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTopBlock_Click(object sender, EventArgs e)
        {
            mvNewLatter.ActiveViewIndex = 1;
        }
        /// <summary>
        /// Cancel To Fill Template Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvNewLatter.ActiveViewIndex = 0;
        }
        /// <summary>
        /// Only Save New Information
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnOk_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Save and Publish News
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveAndPublish_Click(object sender, EventArgs e)
        {

        }
        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// DataGrid Row Bound Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvNewsLatterList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("ltrGvHdrTitleInti")).Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrGvHdrTitleInti", "Title");
                ((Literal)e.Row.FindControl("ltrGvHdrNewsForInit")).Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "ltrGvHdrNewsForInit", "News For");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("NewsLatterSetup", "lblNoRecordFound", "No any record found");
            }
        }
        /// <summary>
        /// Grid Row Commnad Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvNewsLatterList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                mvNewLatter.ActiveViewIndex = 1;
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                mpeConfirmDelete.Show();
            }
        }

        #endregion Grid Event

        
    }
}