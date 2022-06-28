using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice
{
    public partial class CtrlCompanyInvoices : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                BindBreadCrumb();
                BindModeOfPayment();
                BindGrid();
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindGrid()
        {
            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("InvoiceNo");
            DataColumn dc2 = new DataColumn("Date");
            DataColumn dc3 = new DataColumn("ReservationNo");
            DataColumn dc4 = new DataColumn("Amount");
            DataColumn dc5 = new DataColumn("OSTD");
            DataColumn dc6 = new DataColumn("Payment");
            DataColumn dc7 = new DataColumn("Name");

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);

            DataRow dr1 = dt.NewRow();
            dr1["InvoiceNo"] = "101123";
            dr1["Date"] = "05-01-2013";
            dr1["ReservationNo"] = "Res#150";
            dr1["Amount"] = "500.00";
            dr1["OSTD"] = "1000.00";
            dr1["Payment"] = "0.00";
            dr1["Name"] = "Mr. Dev Patel";

            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["InvoiceNo"] = "101501";
            dr2["Date"] = "07-01-2013";
            dr2["ReservationNo"] = "Res#175";
            dr2["Amount"] = "1000.00";
            dr2["OSTD"] = "1500.00";
            dr2["Payment"] = "0.00";
            dr2["Name"] = "Mr. Krupen Vaghela";

            dt.Rows.Add(dr2);


            DataRow dr3 = dt.NewRow();
            dr3["InvoiceNo"] = "123456";
            dr3["Date"] = "10-01-2013";
            dr3["ReservationNo"] = "Res#201";
            dr3["Amount"] = "2500.00";
            dr3["OSTD"] = "2500.00";
            dr3["Payment"] = "2500.00";
            dr3["Name"] = "Mrs. Sweta Jain";

            dt.Rows.Add(dr3);

            gvInvoiceList.DataSource = dt;
            gvInvoiceList.DataBind();
        }

        private void BindModeOfPayment()
        {
            ddlMOP.Items.Clear();
            ddlPayAC.Items.Clear();
            List<ProjectTerm> lstModeOfPayment = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
            if (lstModeOfPayment.Count != 0)
            {
                ddlMOP.DataSource = lstModeOfPayment;
                ddlMOP.DataTextField = "DisplayTerm";
                ddlMOP.DataValueField = "TermID";
                ddlMOP.DataBind();
                ddlMOP.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlMOP.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ddlPayAC.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void ClearControl()
        {
            txtAmount.Text = txtDate.Text = txtNotes.Text = "";
            ddlMOP.SelectedIndex = 0;
            ddlMOP_OnSelectedIndexChanged(null, null);
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            dr2["Link"] = "~/GUI/AccountsHome.aspx";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Direct Bill & Settle Invoice";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccountGroupSetup", "Account Group");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion Private Method

        #region Button Event

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        protected void btnGoToInvoice_Click(object sender, EventArgs e)
        {

        }

        #endregion Button Event

        #region Dropdown Event

        protected void ddlMOP_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPayAC.Items.Clear();
            if (ddlMOP.SelectedIndex != 0)
            {
                DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlMOP.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
                if (dstLedgerAccounts != null && dstLedgerAccounts.Tables[0].Rows.Count > 0)
                {
                    ddlPayAC.DataSource = dstLedgerAccounts.Tables[0];
                    ddlPayAC.DataTextField = "AcctName";
                    ddlPayAC.DataValueField = "AcctID";
                    ddlPayAC.DataBind();
                    ddlPayAC.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlPayAC.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlPayAC.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        #endregion Dropdown Event

        #region Grid Event

        protected void gvInvoiceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    ((Label)e.Row.FindControl("lblGvFtAmount")).Text = "4000.00";
                    ((Label)e.Row.FindControl("lblGvFtOStd")).Text = "5000.00";
                    ((Label)e.Row.FindControl("lblGvFtPayment")).Text = "2500.00";
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Grid Event
    }
}