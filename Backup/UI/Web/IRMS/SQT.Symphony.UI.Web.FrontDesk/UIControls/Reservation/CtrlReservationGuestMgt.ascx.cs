using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlReservationGuestMgt : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditGuestMgt
        {
            get { return this.mpeAddGuestName; }
        }

        public MultiView mvOpenGuest
        {
            get { return this.mvGuest; }
        }

        public event EventHandler btnReservationGuestMgtCallParent_Click;

        public bool IsOpen
        {
            get { return false; }
        }

        public string ToActivateView
        {
            get
            {
                return ViewState["ToActivateView"] != null ? Convert.ToString(ViewState["ToActivateView"]) : string.Empty;
            }
            set
            {
                ViewState["ToActivateView"] = value;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvGuest.ActiveViewIndex = 0;
                BindGuestGrid();
                BindReservationGrid();
            }
        }

        #endregion

        #region Private Method

        private void BindQuickPostGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Item");
                DataColumn dc2 = new DataColumn("Qty");
                DataColumn dc3 = new DataColumn("Amount");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);

                DataRow dr1 = dtTable.NewRow();
                dr1["Item"] = "Coffe";
                dr1["Qty"] = "1";
                dr1["Amount"] = "15.00";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Item"] = "Dinner";
                dr2["Qty"] = "1";
                dr2["Amount"] = "990.00";

                dtTable.Rows.Add(dr2);

                gvQuickPostList.DataSource = dtTable;
                gvQuickPostList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGuestGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("GuestName");
                DataColumn dc2 = new DataColumn("Arrival");
                DataColumn dc3 = new DataColumn("Depature");
                DataColumn dc6 = new DataColumn("Notes");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc6);

                DataRow dr1 = dtTable.NewRow();
                dr1["GuestName"] = "Mr. Prakash Patel";
                dr1["Arrival"] = "05-5-2012";
                dr1["Depature"] = "";
                dr1["Notes"] = "";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["GuestName"] = "Mr. Aniket Chaudhri";
                dr2["Arrival"] = "05-5-2012";
                dr2["Depature"] = "";
                dr2["Notes"] = "";

                dtTable.Rows.Add(dr2);

                gvGuestMgtGuestList.DataSource = dtTable;
                gvGuestMgtGuestList.DataBind();
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
                dr1["ExpiryDate"] = "25-05-2012";
                dr1["SecurityCode"] = "951753";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Type"] = "Solo";
                dr2["CardNo"] = "654123";
                dr2["Name"] = "Mr. Hari Patel";
                dr2["ExpiryDate"] = "25-06-2014";
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

        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindReservationGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Date");
                DataColumn dc2 = new DataColumn("Rate");
                DataColumn dc3 = new DataColumn("RoomRate");
                DataColumn dc4 = new DataColumn("Services");
                DataColumn dc8 = new DataColumn("Total");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc8);

                DataRow dr1 = dtTable.NewRow();
                dr1["Date"] = "27-04-2012";
                dr1["Rate"] = "150.00";
                dr1["RoomRate"] = "150.00";
                dr1["Services"] = "0.00";
                dr1["Total"] = "150.00";

                dtTable.Rows.Add(dr1);

                gvGuestMgtReservation.DataSource = dtTable;
                gvGuestMgtReservation.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion

        #region Control Events

        protected void btnGuestMgtQuickPost_Click(object sender, EventArgs e)
        {
            try
            {
                mpeAddGuestName.Show();
                litDisplayCardHolderName.Text = txtCardHolderName.Text = "Mr. Prakash Patel";
                BindQuickPostGrid();
                this.ToActivateView = "1";

                EventHandler temp = btnReservationGuestMgtCallParent_Click;
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
                
        protected void btnQuickPostCardInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.ToActivateView = "2";
                litDisplayCardHolderName.Text = txtCardHolderName.Text = "Mr. Prakash Patel";
                ClearControlCardInfo();
                BindCardListGrid();

                EventHandler temp = btnReservationGuestMgtCallParent_Click;
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

        protected void btnQuickPostCancel_Click(object sender, EventArgs e)
        {
            mpeAddGuestName.Show();
            mvGuest.ActiveViewIndex = 0;
        }

        protected void btnCancelCardDetails_Click(object sender, EventArgs e)
        {
            mpeAddGuestName.Show();
            mvGuest.ActiveViewIndex = 1;
        }
        #endregion

        #region Radio Button Event

        protected void rbtQuickPostAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlQuickPostCharge.Items.Clear();
                mpeAddGuestName.Show();
                mvGuest.ActiveViewIndex = 1;
                if (rbtQuickPostAccount.SelectedValue == "Account")
                {
                    ddlQuickPostCharge.Items.Insert(0, new ListItem("Conference Revenue", "Conference Revenue"));
                    ddlQuickPostCharge.Items.Insert(0, new ListItem("Room Revenue", "Room Revenue"));
                    ddlQuickPostCharge.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlQuickPostCharge.Items.Insert(0, new ListItem("Coffe", "Coffe"));
                    ddlQuickPostCharge.Items.Insert(0, new ListItem("Cold Drinks", "Cold Drinks"));
                    ddlQuickPostCharge.Items.Insert(0, new ListItem("Dinner", "Dinner"));
                    ddlQuickPostCharge.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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