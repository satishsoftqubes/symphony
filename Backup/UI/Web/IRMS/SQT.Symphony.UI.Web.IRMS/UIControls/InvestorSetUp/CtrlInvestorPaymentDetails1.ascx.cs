using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorPaymentDetails1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridScheduleType();
           
            mvInvestorPaymentDetails.ActiveViewIndex = 0;
        }

        protected void lnkInvestorPaymentDetailsView_OnClick(object sender, EventArgs e)
        {
            BindGridReceiptDetails();
            mvInvestorPaymentDetails.ActiveViewIndex = 1;
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            mvInvestorPaymentDetails.ActiveViewIndex = 0;
        }
        
        #region Grid Event
        private void BindGridScheduleType()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("MilestoneTitle");
            DataColumn dc2 = new DataColumn("Due");
            DataColumn dc3 = new DataColumn("TotalMilestoneAmountPayable");
            DataColumn dc4 = new DataColumn("Date");
            DataColumn dc5 = new DataColumn("AmountPaid");
            DataColumn dc6 = new DataColumn("BalanceAmount");
           

            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);
            dtTable.Columns.Add(dc6);
            

            DataRow dr1 = dtTable.NewRow();
            dr1["MilestoneTitle"] = "On Booking";
            dr1["Due"] = "25";
            dr1["TotalMilestoneAmountPayable"] = "50000";
            dr1["Date"] = "25/05/2012";
            dr1["AmountPaid"] = "30000";
            dr1["BalanceAmount"] = "20000";
            dtTable.Rows.Add(dr1);
            grdInvestorPaymentDetails.DataSource = dtTable;
            grdInvestorPaymentDetails.DataBind();
           
            
            
        }

        private void BindGridReceiptDetails()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("ReceiptNo");
            DataColumn dc2 = new DataColumn("Date");
            DataColumn dc3 = new DataColumn("Amount");
            


            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            


            DataRow dr1 = dtTable.NewRow();
            dr1["ReceiptNo"] = "12345";
            dr1["Date"] = "25/03/2012";
            dr1["Amount"] = "20000";
            dtTable.Rows.Add(dr1);

            DataRow dr2 = dtTable.NewRow();
            dr2["ReceiptNo"] = "54321";
            dr2["Date"] = "25/02/2012";
            dr2["Amount"] = "10000";
            dtTable.Rows.Add(dr2);
            grdInvestorPaymentReceipt.DataSource = dtTable;
            grdInvestorPaymentReceipt.DataBind();
        }

        #endregion

       
    }
}