using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlTransferDeposit : System.Web.UI.UserControl
    {
        #region Property and Variable

        //public ModalPopupExtender ucMpeAddEditTransferDeposit
        //{
        //    get { return this.mpeTransferDeposit; }
        //}

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransferDepositGrid();
            }
        }

        #endregion

        #region Private Method

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
                dr1["Deposit"] = "Unit Deposit";
                dr1["TransferDate"] = "08-May-2012";
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

        #endregion
    }
}