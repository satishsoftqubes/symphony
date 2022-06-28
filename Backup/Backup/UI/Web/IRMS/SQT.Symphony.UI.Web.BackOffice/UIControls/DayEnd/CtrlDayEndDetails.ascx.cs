using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.DayEnd
{
    public partial class CtrlDayEndDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindGridBillInvoice();
                BindGridCounter();
                BindTreeView();
                BindGridHistory();
                BindBreadCrumb();
            }
        }

        #region Private Method

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Day End Details";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGrid()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("BookID");
            DataColumn dc2 = new DataColumn("EntryDate");
            DataColumn dc3 = new DataColumn("Res");
            DataColumn dc4 = new DataColumn("RoomNo");
            DataColumn dc5 = new DataColumn("Guest");
            DataColumn dc6 = new DataColumn("Amount");


            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);
            dtTable.Columns.Add(dc6);

            DataRow dr1 = dtTable.NewRow();
            dr1["BookID"] = "101";
            dr1["EntryDate"] = "11-11-2012";
            dr1["Res"] = "Res-1";
            dr1["RoomNo"] = "1";
            dr1["Guest"] = "Mr. Chintan Gajera";
            dr1["Amount"] = "10000.00";
            dtTable.Rows.Add(dr1);

            DataRow dr2 = dtTable.NewRow();
            dr2["BookID"] = "102";
            dr2["EntryDate"] = "12-10-2012";
            dr2["Res"] = "Res-2";
            dr2["RoomNo"] = "2";
            dr2["Guest"] = "Mr. Satish Thummar";
            dr2["Amount"] = "20000.00";
            dtTable.Rows.Add(dr2);


            DataRow dr3 = dtTable.NewRow();
            dr3["BookID"] = "103";
            dr3["EntryDate"] = "13-09-2012";
            dr3["Res"] = "Res-3";
            dr3["RoomNo"] = "3";
            dr3["Guest"] = "Mr. Vimal Bhatt";
            dr3["Amount"] = "30000.00";
            dtTable.Rows.Add(dr3);


            gvBookKeeping.DataSource = gvCollection.DataSource = gvTax.DataSource = gvCountersDetails.DataSource = dtTable;
            gvBookKeeping.DataBind();
            gvCollection.DataBind();
            gvTax.DataBind();
            gvCountersDetails.DataBind();
        }

        private void BindGridBillInvoice()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("BillNo");
            DataColumn dc2 = new DataColumn("Date");
            DataColumn dc3 = new DataColumn("Res");
            DataColumn dc4 = new DataColumn("RoomNo");
            DataColumn dc5 = new DataColumn("Name");
            DataColumn dc6 = new DataColumn("Amount");


            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);
            dtTable.Columns.Add(dc6);

            DataRow dr1 = dtTable.NewRow();
            dr1["BillNo"] = "1000";
            dr1["Date"] = "11-11-2011";
            dr1["Res"] = "Res-1";
            dr1["RoomNo"] = "1";
            dr1["Name"] = "Mr. Pradip Patel";
            dr1["Amount"] = "10000.00";
            dtTable.Rows.Add(dr1);

            DataRow dr2 = dtTable.NewRow();
            dr2["BillNo"] = "102";
            dr2["Date"] = "12-10-2012";
            dr2["Res"] = "Res-2";
            dr2["RoomNo"] = "2";
            dr2["Name"] = "Mr. Raj Thummar";
            dr2["Amount"] = "20000.00";
            dtTable.Rows.Add(dr2);


            DataRow dr3 = dtTable.NewRow();
            dr3["BillNo"] = "103";
            dr3["Date"] = "13-09-2012";
            dr3["Res"] = "Res-3";
            dr3["RoomNo"] = "3";
            dr3["Name"] = "Mr. Sudhir Rao";
            dr3["Amount"] = "30000.00";
            dtTable.Rows.Add(dr3);

            gvBillInvoice.DataSource = dtTable;
            gvBillInvoice.DataBind();

        }


        private void BindGridHistory()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("BookID");
            DataColumn dc2 = new DataColumn("EntryDate");
            DataColumn dc3 = new DataColumn("Operation");
            DataColumn dc4 = new DataColumn("Res");
            DataColumn dc5 = new DataColumn("RoomNo");
            DataColumn dc6 = new DataColumn("Guest");
            DataColumn dc7 = new DataColumn("Amount");


            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);
            dtTable.Columns.Add(dc6);
            dtTable.Columns.Add(dc7);

            DataRow dr1 = dtTable.NewRow();
            dr1["BookID"] = "B-001";
            dr1["EntryDate"] = "11-11-2011";
            dr1["Operation"] = "";
            dr1["Res"] = "Res-101";
            dr1["RoomNo"] = "101";
            dr1["Guest"] = "Mr. Sanjay Patel";
            dr1["Amount"] = "10000.00";
            dtTable.Rows.Add(dr1);

            DataRow dr2 = dtTable.NewRow();
            dr2["BookID"] = "B-002";
            dr2["EntryDate"] = "12-12-2012";
            dr2["Operation"] = "";
            dr2["Res"] = "Res-12";
            dr2["RoomNo"] = "12";
            dr2["Guest"] = "Mr. Rajan Varma";
            dr2["Amount"] = "20000.00";
            dtTable.Rows.Add(dr2);


            gvHistory.DataSource = dtTable;
            gvHistory.DataBind();

        }

        private void BindGridCounter()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("Counters");

            dtTable.Columns.Add(dc1);

            DataRow dr1 = dtTable.NewRow();
            dr1["Counters"] = "C1";
            dtTable.Rows.Add(dr1);

            DataRow dr2 = dtTable.NewRow();
            dr2["Counters"] = "C1";
            dtTable.Rows.Add(dr2);

            gvCounters.DataSource = dtTable;
            gvCounters.DataBind();
        }

        private void BindTreeView()
        {

            for (int i = DateTime.Now.Year; i >= 2010; i--)
            {
                TreeNode root1 = new TreeNode(i.ToString(), i.ToString());
                root1.SelectAction = TreeNodeSelectAction.Expand;
                CreateMonth(root1);
                tvDate.Nodes.Add(root1);
            }

        }

        public void CreateMonth(TreeNode node)
        {
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {

                DateTime dtDate = new DateTime(Convert.ToInt32(node.Value.ToString()), i, 1);
                string sMonthFullName = dtDate.ToString("MMMM");
                TreeNode Childnode = new TreeNode(sMonthFullName, dtDate.ToString());
                Childnode.SelectAction = TreeNodeSelectAction.Expand;
                CreateDay(Childnode);
                node.ChildNodes.Add(Childnode);

            }
        }

        public void CreateDay(TreeNode node)
        {

            DateTime dtDate = Convert.ToDateTime(node.Value.ToString());
            int day = DateTime.DaysInMonth(dtDate.Year, dtDate.Month);
            for (int i = 1; i <= day; i++)
            {
                DateTime FullDate = new DateTime(dtDate.Year, dtDate.Month, i);
                TreeNode Childnode = new TreeNode(FullDate.ToString("dd-MMMM-yyyy"), FullDate.ToString("dd-MMMM-yyyy"));
                Childnode.SelectAction = TreeNodeSelectAction.Expand;
                node.ChildNodes.Add(Childnode);

            }

        }

        #endregion

        #region Control Event

        protected void lnkCheckOut_OnClick(object sender, EventArgs e)
        {
            litPreCheckGvHdr.Text = "Checkout Detail List";

            //DataTable dtTable = new DataTable();

            //DataColumn dc1 = new DataColumn("Description");
            //DataColumn dc2 = new DataColumn("Status");

            //dtTable.Columns.Add(dc1);
            //dtTable.Columns.Add(dc2);

            //DataRow dr1 = dtTable.NewRow();
            //dr1["Description"] = "Room No. A(III).";
            //dr1["Status"] = "1";
            //dtTable.Rows.Add(dr1);

            //DataRow dr2 = dtTable.NewRow();
            //dr2["Description"] = "Room No. B(III).";
            //dr2["Status"] = "1";
            //dtTable.Rows.Add(dr2);


            //DataRow dr3 = dtTable.NewRow();
            //dr3["Description"] = "Room No. C(II).";
            //dr3["Status"] = "1";
            //dtTable.Rows.Add(dr3);

            gvPreCheckDetails.DataSource = null;
            gvPreCheckDetails.DataBind();

        }

        protected void lnkCheckIn_OnClick(object sender, EventArgs e)
        {
            litPreCheckGvHdr.Text = "Checkin Detail List";

            DataTable dtCheckIn = new DataTable();

            DataColumn dc1 = new DataColumn("Description");
            DataColumn dc2 = new DataColumn("Status");

            dtCheckIn.Columns.Add(dc1);
            dtCheckIn.Columns.Add(dc2);

            DataRow dr1 = dtCheckIn.NewRow();
            dr1["Description"] = "Room No. A(III) Non Ac.";
            dr1["Status"] = "1";
            dtCheckIn.Rows.Add(dr1);

            DataRow dr2 = dtCheckIn.NewRow();
            dr2["Description"] = "Room No. B(III) Ac.";
            dr2["Status"] = "0";
            dtCheckIn.Rows.Add(dr2);


            DataRow dr3 = dtCheckIn.NewRow();
            dr3["Description"] = "Room No. C(II) Non Ac.";
            dr3["Status"] = "1";
            dtCheckIn.Rows.Add(dr3);

            gvPreCheckDetails.DataSource = dtCheckIn;
            gvPreCheckDetails.DataBind();


        }

        protected void lnkDepositTranferred_OnClick(object sender, EventArgs e)
        {
            litPreCheckGvHdr.Text = "Deposit Tranferred Detail List";
            DataTable dtDepositTrans = new DataTable();

            DataColumn dc1 = new DataColumn("Description");
            DataColumn dc2 = new DataColumn("Status");

            dtDepositTrans.Columns.Add(dc1);
            dtDepositTrans.Columns.Add(dc2);

            DataRow dr1 = dtDepositTrans.NewRow();
            dr1["Description"] = "Mr. Raj Patel Deposit.";
            dr1["Status"] = "0";
            dtDepositTrans.Rows.Add(dr1);

            DataRow dr2 = dtDepositTrans.NewRow();
            dr2["Description"] = "Miss. Ravi Ahuja Deposit.";
            dr2["Status"] = "0";
            dtDepositTrans.Rows.Add(dr2);


            DataRow dr3 = dtDepositTrans.NewRow();
            dr3["Description"] = "Mr. Chintan Patel Deposit.";
            dr3["Status"] = "0";
            dtDepositTrans.Rows.Add(dr3);

            gvPreCheckDetails.DataSource = dtDepositTrans;
            gvPreCheckDetails.DataBind();

        }

        protected void lnkPOSTAccomodationCharges_OnClick(object sender, EventArgs e)
        {
            litPreCheckGvHdr.Text = "POST Accomodation Charges Detail List";

            //DataTable dtTable = new DataTable();

            //DataColumn dc1 = new DataColumn("Description");
            //DataColumn dc2 = new DataColumn("Status");

            //dtTable.Columns.Add(dc1);
            //dtTable.Columns.Add(dc2);

            //DataRow dr1 = dtTable.NewRow();
            //dr1["Description"] = "Mr. Raj Patel Deposit.";
            //dr1["Status"] = "1";
            //dtTable.Rows.Add(dr1);

            //DataRow dr2 = dtTable.NewRow();
            //dr2["Description"] = "Miss. Ravi Ahuja Deposit.";
            //dr2["Status"] = "1";
            //dtTable.Rows.Add(dr2);


            //DataRow dr3 = dtTable.NewRow();
            //dr3["Description"] = "Mr. Chintan Patel Deposit.";
            //dr3["Status"] = "1";
            //dtTable.Rows.Add(dr3);

            gvPreCheckDetails.DataSource = null;
            gvPreCheckDetails.DataBind();

        }

        protected void lnkPOSTServiceCharges_OnClick(object sender, EventArgs e)
        {
            litPreCheckGvHdr.Text = "POST Service Charges Detail List";
            DataTable dtPOSTService = new DataTable();

            DataColumn dc1 = new DataColumn("Description");
            DataColumn dc2 = new DataColumn("Status");

            dtPOSTService.Columns.Add(dc1);
            dtPOSTService.Columns.Add(dc2);

            DataRow dr1 = dtPOSTService.NewRow();
            dr1["Description"] = "Rs. 3000 not Paid By chintan.";
            dr1["Status"] = "0";
            dtPOSTService.Rows.Add(dr1);

            DataRow dr2 = dtPOSTService.NewRow();
            dr2["Description"] = "Rajan patel paid all POST Service Charge.";
            dr2["Status"] = "1";
            dtPOSTService.Rows.Add(dr2);


            DataRow dr3 = dtPOSTService.NewRow();
            dr3["Description"] = "Omi patel paid all POST Service Charge.";
            dr3["Status"] = "1";
            dtPOSTService.Rows.Add(dr3);

            gvPreCheckDetails.DataSource = dtPOSTService;
            gvPreCheckDetails.DataBind();

        }

        protected void lnkACBalanceSheet_OnClick(object sender, EventArgs e)
        {
            litPreCheckGvHdr.Text = "A/C Balance Sheet Detail List";
            DataTable dtACBalanceSheet = new DataTable();

            DataColumn dc1 = new DataColumn("Description");
            DataColumn dc2 = new DataColumn("Status");

            dtACBalanceSheet.Columns.Add(dc1);
            dtACBalanceSheet.Columns.Add(dc2);

            DataRow dr1 = dtACBalanceSheet.NewRow();
            dr1["Description"] = "Account No. C3 Sheet is Done.";
            dr1["Status"] = "1";
            dtACBalanceSheet.Rows.Add(dr1);

            DataRow dr2 = dtACBalanceSheet.NewRow();
            dr2["Description"] = "Account No. C43 Sheet is Not Done.";
            dr2["Status"] = "0";
            dtACBalanceSheet.Rows.Add(dr2);


            DataRow dr3 = dtACBalanceSheet.NewRow();
            dr3["Description"] = "Account No. AC123 Sheet is Done.";
            dr3["Status"] = "1";
            dtACBalanceSheet.Rows.Add(dr3);

            gvPreCheckDetails.DataSource = dtACBalanceSheet;
            gvPreCheckDetails.DataBind();


        }

        protected void lnkCloseCounter_OnClick(object sender, EventArgs e)
        {
            litPreCheckGvHdr.Text = "Close Counter Detail List";

            //DataTable dtTable = new DataTable();

            //DataColumn dc1 = new DataColumn("Description");
            //DataColumn dc2 = new DataColumn("Status");

            //dtTable.Columns.Add(dc1);
            //dtTable.Columns.Add(dc2);

            //DataRow dr1 = dtTable.NewRow();
            //dr1["Description"] = "Account No. C3 is Close by Chintan.";
            //dr1["Status"] = "1";
            //dtTable.Rows.Add(dr1);

            //DataRow dr2 = dtTable.NewRow();
            //dr2["Description"] = "Account No. C123 is not Logout.";
            //dr2["Status"] = "1";
            //dtTable.Rows.Add(dr2);


            //DataRow dr3 = dtTable.NewRow();
            //dr3["Description"] = "Account No. AC123 Close.";
            //dr3["Status"] = "1";
            //dtTable.Rows.Add(dr3);

            gvPreCheckDetails.DataSource = null;
            gvPreCheckDetails.DataBind();

        }


        #endregion
    }
}