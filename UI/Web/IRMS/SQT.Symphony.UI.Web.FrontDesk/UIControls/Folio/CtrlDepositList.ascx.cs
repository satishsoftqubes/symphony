using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlDepositList : System.Web.UI.UserControl
    {
        #region Property and Variable

        public event EventHandler btnDepositListCallParent_Click;

        public string strMode
        {
            get
            {
                return ViewState["strMode"] != null ? Convert.ToString(ViewState["strMode"]) : string.Empty;
            }
            set
            {
                ViewState["strMode"] = value;
            }
        }

        public MultiView mvucDepositList
        {
            get { return this.mvDepositList; }
        }

        #endregion  Property and Variable

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvDepositList.ActiveViewIndex = 0;
                BindGrid();
            }
        }
        #endregion

        #region Methods

        public void BindGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("TransDate");
                DataColumn dc2 = new DataColumn("AuditDate");
                DataColumn dc3 = new DataColumn("Description");
                DataColumn dc4 = new DataColumn("Deposit");
                DataColumn dc5 = new DataColumn("Balance");
                DataColumn dc6 = new DataColumn("Void");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);

                DataRow dr1 = dtTable.NewRow();
                dr1["TransDate"] = "10-08-2012";
                dr1["AuditDate"] = "11-08-2012";
                dr1["Description"] = "This is first Deposit.";
                dr1["Deposit"] = "5000";
                dr1["Balance"] = "5000";
                dr1["Void"] = "Yes";
                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["TransDate"] = "07-08-2012";
                dr2["AuditDate"] = "09-08-2012";
                dr2["Description"] = "New deposit to add.";
                dr2["Deposit"] = "2000";
                dr2["Balance"] = "6000";
                dr2["Void"] = "No";
                dtTable.Rows.Add(dr2);

                gvDepositList.DataSource = dtTable;
                gvDepositList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindTransferDepositGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Deposit");
                DataColumn dc2 = new DataColumn("TransferDate");
                DataColumn dc3 = new DataColumn("Balance");
                DataColumn dc4 = new DataColumn("TransferAmount");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["Deposit"] = "Room Deposit";
                dr1["TransferDate"] = "08-08-2012";
                dr1["Balance"] = "100.00";
                dr1["TransferAmount"] = "100.00";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Deposit"] = "Conf. Deposit";
                dr2["TransferDate"] = "09-May-2012";
                dr2["Balance"] = "200.00";
                dr2["TransferAmount"] = "200.00";

                dtTable.Rows.Add(dr2);

                gvTransferDepositList.DataSource = dtTable;
                gvTransferDepositList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindTempDeposit()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Receipt");
                DataColumn dc2 = new DataColumn("Date");
                DataColumn dc3 = new DataColumn("DepositAccount");
                DataColumn dc4 = new DataColumn("Amount");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["Receipt"] = "100133";
                dr1["Date"] = "13-08-2012";
                dr1["DepositAccount"] = "Room Deposit";
                dr1["Amount"] = "1000";
                dtTable.Rows.Add(dr1);

                gvTempDeposit.DataSource = dtTable;
                gvTempDeposit.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDeposit()
        {
            try
            {
                DataTable dtTable1 = new DataTable();

                DataColumn dc3 = new DataColumn("Deposit");
                DataColumn dc4 = new DataColumn("Amount");


                dtTable1.Columns.Add(dc3);
                dtTable1.Columns.Add(dc4);

                DataRow dr1 = dtTable1.NewRow();
                dr1["Deposit"] = "Advance deposit";
                dr1["Amount"] = "200";
                dtTable1.Rows.Add(dr1);

                gvDeposit.DataSource = dtTable1;
                gvDeposit.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRefundDepositGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Deposit");
                DataColumn dc2 = new DataColumn("Date");
                DataColumn dc3 = new DataColumn("PayBy");
                DataColumn dc4 = new DataColumn("Balance");
                DataColumn dc5 = new DataColumn("Refund");
                DataColumn dc6 = new DataColumn("Forfeited");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);

                DataRow dr1 = dtTable.NewRow();
                dr1["Deposit"] = "Room Deposit";
                dr1["Date"] = "08-08-2012";
                dr1["PayBy"] = "BACS";
                dr1["Balance"] = "100.00";
                dr1["Refund"] = "100.00";
                dr1["Forfeited"] = "0.00";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Deposit"] = "Conf. Deposit";
                dr2["Date"] = "09-08-2012";
                dr2["PayBy"] = "Mastercard";
                dr2["Balance"] = "500.00";
                dr2["Refund"] = "500.00";
                dr2["Forfeited"] = "0.00";

                dtTable.Rows.Add(dr2);

                gvRefundDepositList.DataSource = dtTable;
                gvRefundDepositList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindCardListGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Type");
                DataColumn dc2 = new DataColumn("CardNo");
                DataColumn dc3 = new DataColumn("Name");
                DataColumn dc4 = new DataColumn("ExpiryDate");
                DataColumn dc5 = new DataColumn("SecurityCode");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);

                DataRow dr1 = dtTable.NewRow();
                dr1["Type"] = "Mastercard";
                dr1["CardNo"] = "123456";
                dr1["Name"] = "Mr. Hari Patel";
                dr1["ExpiryDate"] = "12-08-2012";
                dr1["SecurityCode"] = "951753";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Type"] = "Solo";
                dr2["CardNo"] = "654123";
                dr2["Name"] = "Mr. Hari Patel";
                dr2["ExpiryDate"] = "13-08-2014";
                dr2["SecurityCode"] = "3571596";

                dtTable.Rows.Add(dr2);

                gvCardList.DataSource = dtTable;
                gvCardList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ClearControlCardInfo()
        {
            ddlCardType.SelectedIndex = 0;
            txtCardNo.Text = txtCardHolderName.Text = txtIssueDate.Text = txtExpiryDate.Text = txtIssueNo.Text = txtSecurityCode.Text = txtAuthorizationCode.Text = txtAuthorizedAmount.Text = "";
        }
        
        #endregion

        #region Control Events

        protected void btnNewDeposit_OnClick(object sender, EventArgs e)
        {            
            strMode = "1";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
            BindTempDeposit();
            BindDeposit();
        }

        protected void btnTransfer_OnClick(object sender, EventArgs e)
        {
            strMode = "2";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
            
            BindTransferDepositGrid();
        }

        protected void btnRefund_OnClick(object sender, EventArgs e)
        {
            strMode = "3";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
            BindRefundDepositGrid();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Receipt");
                DataColumn dc2 = new DataColumn("Date");
                DataColumn dc3 = new DataColumn("DepositAccount");
                DataColumn dc4 = new DataColumn("Amount");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["Receipt"] = "100133";
                dr1["Date"] = "13/July/2012";
                dr1["DepositAccount"] = "Room Deposit";
                dr1["Amount"] = "1000";
                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Receipt"] = "1230";
                dr2["Date"] = "14/July/2012";
                dr2["DepositAccount"] = ddlDeposit.SelectedValue;
                dr2["Amount"] = txtAmount.Text;
                dtTable.Rows.Add(dr2);

                gvTempDeposit.DataSource = dtTable;
                gvTempDeposit.DataBind();

                strMode = "1";
                EventHandler temp = btnDepositListCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddDepositCancel_OnClick(object sender, EventArgs e)
        {
            strMode = "0";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        protected void btnTransferDepositCancel_Click(object sender, EventArgs e)
        {
            strMode = "0";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        protected void btnRefundDepositCardInfo_Click(object sender, EventArgs e)
        {            
            litDisplayCardHolderName.Text = txtCardHolderName.Text = "Mr. Prakash Patel";
            ClearControlCardInfo();
            BindCardListGrid();
            strMode = "4";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        protected void btnCancelCardDetails_Click(object sender, EventArgs e)
        {
            strMode = "3";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        protected void btnRefundDepositCancel_Cancel(object sender, EventArgs e)
        {
            strMode = "0";
            EventHandler temp = btnDepositListCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }
        
        #endregion
    }
}