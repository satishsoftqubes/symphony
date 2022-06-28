using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlRefundDeposit : System.Web.UI.UserControl
    {
        #region Property and Variable

        //public ModalPopupExtender ucMpeAddEditRefundDeposit
        //{
        //    get { return this.mpeRefundDeposit; }
        //}

        public MultiView mvOpenRefundDeposit
        {
            get { return this.mvRefundDeposit; }
        }

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

        public event EventHandler btnRefundDepositCallParent_Click;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvRefundDeposit.ActiveViewIndex = 0;
                BindRefundDepositGrid();
            }
        }

        #endregion

        #region Private Method

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
                dr1["Deposit"] = "Unit Deposit";
                dr1["Date"] = "08-May-2012";
                dr1["PayBy"] = "BACS";
                dr1["Balance"] = "100.00";
                dr1["Refund"] = "100.00";
                dr1["Forfeited"] = "0.00";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Deposit"] = "Conf. Deposit";
                dr2["Date"] = "09-May-2012";
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
                dr1["ExpiryDate"] = "25-May-2012";
                dr1["SecurityCode"] = "951753";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Type"] = "Solo";
                dr2["CardNo"] = "654123";
                dr2["Name"] = "Mr. Hari Patel";
                dr2["ExpiryDate"] = "25-Jan-2014";
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

        #region Control Event

        protected void btnRefundDepositCardInfo_Click(object sender, EventArgs e)
        {
            //mpeRefundDeposit.Show();
            litDisplayCardHolderName.Text = txtCardHolderName.Text = "Mr. Prakash Patel";
            ClearControlCardInfo();
            BindCardListGrid();
            strMode = "1";
            EventHandler temp = btnRefundDepositCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        protected void btnCancelCardDetails_Click(object sender, EventArgs e)
        {
            //mpeRefundDeposit.Show();
            mvRefundDeposit.ActiveViewIndex = 0;
            strMode = "0";
            EventHandler temp = btnRefundDepositCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }
        #endregion
    }
}