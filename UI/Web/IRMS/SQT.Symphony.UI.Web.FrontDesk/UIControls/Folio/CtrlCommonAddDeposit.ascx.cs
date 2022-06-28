using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlCommonAddDeposit : System.Web.UI.UserControl
    {
        public event EventHandler btnAddDepositCallParent_Click;

        public MultiView ucMvDeposit
        {
            get { return this.mvDeposit; }
        }

        #region  Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvDeposit.ActiveViewIndex = 0;
                BindGrid();

                BindDeposit();
                BindTempDeposit();
            }

        }

        #endregion Page Load

        #region Private Method
        private void BindGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Status");
                DataColumn dc2 = new DataColumn("ReservationNo");
                DataColumn dc3 = new DataColumn("GuestName");
                DataColumn dc4 = new DataColumn("Child");
                DataColumn dc5 = new DataColumn("RoomNo");
                DataColumn dc6 = new DataColumn("RoomType");
                DataColumn dc7 = new DataColumn("Date");
                DataColumn dc8 = new DataColumn("Payment");
                DataColumn dc9 = new DataColumn("BlockName");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);
                dtTable.Columns.Add(dc9);

                DataRow dr1 = dtTable.NewRow();
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dr1["ReservationNo"] = "R-1";
                dr1["GuestName"] = "Mihir Patel";
                dr1["Child"] = "2/2";
                dr1["RoomNo"] = "1";
                dr1["RoomType"] = "Delux";
                dr1["Date"] = "07-08-2012 - 09-08-2012";
                dr1["Payment"] = "BASC";
                dr1["BlockName"] = "F1";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Status"] = "<img src='../../images/UnConfirmed22x22.png' alt='UnConfirmed' title='UnConfirmed' />";
                dr2["ReservationNo"] = "123456";
                dr2["GuestName"] = "Rakesh Shah";
                dr2["Child"] = "0/1";
                dr2["RoomNo"] = "2";
                dr2["RoomType"] = "Family";
                dr2["Date"] = "10-08-2012 - 13-08-2012";
                dr2["Payment"] = "BASC";
                dr2["BlockName"] = "B";

                dtTable.Rows.Add(dr2);

                gvRoomReservationList.DataSource = dtTable;
                gvRoomReservationList.DataBind();
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
                dr1["Date"] = "11-08-2012";
                dr1["DepositAccount"] = "Room Deposit";
                dr1["Amount"] = "1000.00";
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
                dr1["Deposit"] = "ABC";
                dr1["Amount"] = "200.00";
                dtTable1.Rows.Add(dr1);

                gvDeposit.DataSource = dtTable1;
                gvDeposit.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }        
        #endregion

        #region Button Event

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

                EventHandler temp = btnAddDepositCallParent_Click;
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

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {            
            mvDeposit.ActiveViewIndex = 0;
        }

        #endregion Button Event

        #region Grid Event

        protected void gvRoomReservationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("DEPOSIT"))
                {
                    mvDeposit.ActiveViewIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}