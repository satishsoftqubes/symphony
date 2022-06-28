using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlConferenceReservation : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindGrid();
            }
        }

        #endregion

        #region Control Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Private Method

        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindGrid()
        {
            try
            {
                gvConferenceReservation.Visible = true;

                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Date");
                DataColumn dc2 = new DataColumn("Rate");
                DataColumn dc3 = new DataColumn("RoomRate");
                DataColumn dc4 = new DataColumn("Services");
                DataColumn dc5 = new DataColumn("UnitTaxes");
                DataColumn dc6 = new DataColumn("Extra");
                DataColumn dc7 = new DataColumn("Discount");
                DataColumn dc8 = new DataColumn("Total");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);

                DataRow dr1 = dtTable.NewRow();
                dr1["Date"] = "27-Apr-2012";
                dr1["Rate"] = "58.80";
                dr1["RoomRate"] = "53.80";
                dr1["Services"] = "5.50";
                dr1["UnitTaxes"] = "8.80";
                dr1["Extra"] = "0.00";
                dr1["Discount"] = "0.00";
                dr1["Total"] = "58.80";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Date"] = "28-Apr-2012";
                dr2["Rate"] = "100";
                dr2["RoomRate"] = "100";
                dr2["Services"] = "10";
                dr2["UnitTaxes"] = "5";
                dr2["Extra"] = "0.00";
                dr2["Discount"] = "0.00";
                dr2["Total"] = "110";

                dtTable.Rows.Add(dr2);

                DataRow dr3 = dtTable.NewRow();
                dr3["Date"] = "29-Apr-2012";
                dr3["Rate"] = "150";
                dr3["RoomRate"] = "150";
                dr3["Services"] = "20";
                dr3["UnitTaxes"] = "10";
                dr3["Extra"] = "0.00";
                dr3["Discount"] = "0.00";
                dr3["Total"] = "170";

                dtTable.Rows.Add(dr3);

                gvConferenceReservation.DataSource = dtTable;
                gvConferenceReservation.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

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
            dr4["NameColumn"] = "Reservation";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Conference Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        //private void BindServiceList()
        //{
        //    DataTable dtService = new DataTable();

        //    DataColumn dc1 = new DataColumn("Service");
        //    DataColumn dc2 = new DataColumn("Date");
        //    DataColumn dc3 = new DataColumn("Time");
        //    DataColumn dc4 = new DataColumn("Notes");
        //    DataColumn dc5 = new DataColumn("Amount");
        //    DataColumn dc6 = new DataColumn("Qty");
        //    DataColumn dc7 = new DataColumn("ServiceRate");
        //    DataColumn dc8 = new DataColumn("Tax");
        //    DataColumn dc9 = new DataColumn("SrvTax");
        //    DataColumn dc10 = new DataColumn("Total");

        //    dtService.Columns.Add(dc1);
        //    dtService.Columns.Add(dc2);
        //    dtService.Columns.Add(dc3);
        //    dtService.Columns.Add(dc4);
        //    dtService.Columns.Add(dc5);
        //    dtService.Columns.Add(dc6);
        //    dtService.Columns.Add(dc7);
        //    dtService.Columns.Add(dc8);
        //    dtService.Columns.Add(dc9);
        //    dtService.Columns.Add(dc10);

        //    DataRow dr1 = dtService.NewRow();
        //    dr1["Service"] = "Tea";
        //    dr1["Date"] = "31/May/2012";
        //    dr1["Time"] = "15:15";
        //    dr1["Notes"] = "";
        //    dr1["Amount"] = "10.00";
        //    dr1["Qty"] = "1";
        //    dr1["ServiceRate"] = "0.00";
        //    dr1["Tax"] = "5.00";
        //    dr1["SrvTax"] = "0.00";
        //    dr1["Total"] = "10.00";

        //    dtService.Rows.Add(dr1);

        //    DataRow dr2 = dtService.NewRow();
        //    dr2["Service"] = "Cold Drink";
        //    dr2["Date"] = "01/June/2012";
        //    dr2["Time"] = "16:00";
        //    dr2["Notes"] = "";
        //    dr2["Amount"] = "25.00";
        //    dr2["Qty"] = "2";
        //    dr2["ServiceRate"] = "0.00";
        //    dr2["Tax"] = "10.00";
        //    dr2["SrvTax"] = "0.80";
        //    dr2["Total"] = "50.00";

        //    dtService.Rows.Add(dr2);

        //    gvServiceList.DataSource = dtService;
        //    gvServiceList.DataBind();
        //}

        private void BindCardListGrid()
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
        #endregion

        #region Control Event

        protected void btnAddGuest_Click(object sender, EventArgs e)
        {
            ddlIDType.SelectedIndex = ddlGuestTitle.SelectedIndex = ddlMaritalStatus.SelectedIndex = ddlNationality.SelectedIndex = 0;
            txtGuestFirstName.Text = txtGuestLastName.Text = txtGuestDOB.Text = txtIDDetail.Text = "";

            mpeAddGuest.Show();
        }

        protected void btnAddCardDetails_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    if (ddlPMT.SelectedValue == "Card")
                    {
                        ddlCardType.SelectedIndex = 0;
                        txtCardNo.Text = txtCardHolderName.Text = txtIssueDate.Text = txtExpiryDate.Text = txtIssueNo.Text = txtSecurityCode.Text = txtAuthorizationCode.Text = txtAuthorizedAmount.Text = "";
                        mpeAddCardDetails.Show();

                        litDisplayCardHolderName.Text = txtCardHolderName.Text = Convert.ToString(ddlTitle.SelectedValue + " " + txtFirstName.Text.Trim());
                        BindCardListGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void lnkRoomReservationServices_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
            ctrlCommonAddServices.ClearServiceControl();
            ////ctrlCommonAddServices.BindServiceList();
        }

        #endregion

        protected void btnAddServicesCallParent_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
        }
    }
}