using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Card
{
    public partial class CtrlPrintStatement : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();                
                BindCreditList();
                BindDebitList();
                if (Request.QueryString["Statement"] != null)
                    mvPrintStatement.ActiveViewIndex = 1;
                else
                    mvPrintStatement.ActiveViewIndex = 0;
            }
        }

        #endregion  Page Load

        #region Button Event

        protected void btnPrintStatementCancel_Click(object sender, EventArgs e)
        {
            mvPrintStatement.ActiveViewIndex = 0;
        }

        protected void btnSearchGuestCallParent_Click(object sender, EventArgs e)
        {            
            mvPrintStatement.ActiveViewIndex = 1;
        }

        #endregion  Button Event

        #region Private Method

        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "CashCard";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Print Statement";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindCreditList()
        {
            try
            {
                DataTable dtService = new DataTable();


                DataColumn dc1 = new DataColumn("TransactionNo");
                DataColumn dc2 = new DataColumn("Date");
                DataColumn dc3 = new DataColumn("Perticulars");
                DataColumn dc4 = new DataColumn("Credit");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);

                DataRow dr1 = dtService.NewRow();
                dr1["TransactionNo"] = "123456";
                dr1["Date"] = "07-08-2012";
                dr1["Perticulars"] = "";
                dr1["Credit"] = "5500.00";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["TransactionNo"] = "123555";
                dr2["Date"] = "08-08-2012";
                dr2["Perticulars"] = "";
                dr2["Credit"] = "0.00";

                dtService.Rows.Add(dr2);

                DataRow dr3 = dtService.NewRow();
                dr3["TransactionNo"] = "123789";
                dr3["Date"] = "09-08-2012";
                dr3["Perticulars"] = "";
                dr3["Credit"] = "7000.00";

                dtService.Rows.Add(dr3);

                DataRow dr4 = dtService.NewRow();
                dr4["TransactionNo"] = "124567";
                dr4["Date"] = "10-08-2012";
                dr4["Perticulars"] = "";
                dr4["Credit"] = "0.00";

                dtService.Rows.Add(dr4);

                gvCreditList.DataSource = dtService;
                gvCreditList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDebitList()
        {
            try
            {
                DataTable dtService = new DataTable();


                DataColumn dc1 = new DataColumn("Debit");

                dtService.Columns.Add(dc1);

                DataRow dr1 = dtService.NewRow();
                dr1["Debit"] = "0.00";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["Debit"] = "4500.00";

                dtService.Rows.Add(dr2);

                DataRow dr3 = dtService.NewRow();
                dr3["Debit"] = "0.00";

                dtService.Rows.Add(dr3);

                DataRow dr4 = dtService.NewRow();
                dr4["Debit"] = "5000.00";

                dtService.Rows.Add(dr4);


                gvDebitList.DataSource = dtService;
                gvDebitList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion  Private Method

        #region Grid Event

        protected void gvCreditList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    ((Literal)e.Row.FindControl("litTotalCredit")).Text = "12500.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDebitList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    ((Literal)e.Row.FindControl("litTotalDebit")).Text = "9500.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion  Grid Event
    }
}