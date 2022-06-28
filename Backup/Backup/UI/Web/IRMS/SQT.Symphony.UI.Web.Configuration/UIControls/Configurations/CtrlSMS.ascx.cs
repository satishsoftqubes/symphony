using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlSMS : System.Web.UI.UserControl
    {
        #region Property and Variables
        // property to save companyid;
        public Guid UserID
        {
            get
            {
                return ViewState["UserID"] != null ? new Guid(Convert.ToString(ViewState["UserID"])) : Guid.Empty;
            }
            set
            {
                ViewState["UserID"] = value;
            }
        }

        public bool IsMessage = false;
        #endregion Property and Variables

        #region Private Method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            BindData();
        }

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
            dr3["NameColumn"] = "SMS&nbsp;";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn();
            col1.ColumnName = "TitleList";
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "Details";
            dt.Columns.Add(col2);

            DataRow dr1 = dt.NewRow();
            dr1["TitleList"] = "Unit Booking";
            dr1["Details"] = "You have Book UnitNo";

            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["TitleList"] = "Investor Creation";
            dr2["Details"] = "Investor Creation";

            dt.Rows.Add(dr2);

            gvSMSList.DataSource = dt;
            gvSMSList.DataBind();
        }

        private void SetPageLables()
        {

            ltrSearchArea.Text = clsCommon.GetGlobalResourceText("SMS", "ltrSearchArea", "Search Area");
            btnCancel.Text = clsCommon.GetGlobalResourceText("SMS", "btnCancel", "Cancel");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnAddTopSMS.Text = clsCommon.GetGlobalResourceText("SMS", "btnAddTopSMS", "Add New");
            btnAddBottomSMS.Text = clsCommon.GetGlobalResourceText("SMS", "btnAddBottomSMS", "Add New");
            btnSaveAndExit.Text = clsCommon.GetGlobalResourceText("SMS", "btnSaveAndExit", "Save & Exit");
            btnSave.Text = clsCommon.GetGlobalResourceText("SMS", "btnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("SMS", "btnCancel", "Cancel");
            ltrMainHeading.Text = clsCommon.GetGlobalResourceText("SMS", "ltrMainHeading", "SMS");
            ltrSMSHeading.Text = clsCommon.GetGlobalResourceText("SMS", "ltrSMSHeading", "SMS");
            ltrSMSList.Text = clsCommon.GetGlobalResourceText("SMS", "ltrSMSList", "SMS List");
            ltrSearchTitle.Text = clsCommon.GetGlobalResourceText("SMS", "ltrSearchTitle", "Title");
            ltrTitle.Text = clsCommon.GetGlobalResourceText("SMS", "ltrTitle", "Title");
            ltrDetail.Text = clsCommon.GetGlobalResourceText("SMS", "ltrDetail", "Details");
            rdoIsOnUnitBooking.Text = clsCommon.GetGlobalResourceText("SMS", "rdoIsOnUnitBooking", "Unit Booking");
            rdoIsOnInvestorCreation.Text = clsCommon.GetGlobalResourceText("SMS", "rdoIsOnInvestorCreation", "Investor Creation");
            rdoIsOnUnitPaymentReceived.Text = clsCommon.GetGlobalResourceText("SMS", "rdoIsOnUnitPaymentReceived", "Unit Payment Receive");
            rdoIsOnUnitTaxReceived.Text = clsCommon.GetGlobalResourceText("SMS", "rdoIsOnUnitTaxReceived", "Unit Tax Receive");
            rdoIsOnUnitInsuranceReceived.Text = clsCommon.GetGlobalResourceText("SMS", "rdoIsOnUnitInsuranceReceived", "Unit Insurance Receive");
        }

        #endregion Private Method

        protected void gvSMSList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                SMSData.Show();
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {

                mpeConfirmDelete.Show();
            }
        }

        protected void btnAddTopSMS_Click(object sender, EventArgs e)
        {
            SMSData.Show();
        }

        protected void gvSMSList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                ((Literal)e.Row.FindControl("ltrGvHdrTitle")).Text = clsCommon.GetGlobalResourceText("SMS", "ltrGvHdrTitle", "Title");
                ((Literal)e.Row.FindControl("ltrGvHdrDetails")).Text = clsCommon.GetGlobalResourceText("SMS", "ltrGvHdrDetails", "Details");
                
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("SMS", "lblNoRecordFound", "No any record found.");
            }
        }

    }
}