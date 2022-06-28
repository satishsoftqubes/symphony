using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlRoomReservation : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                //gvRoomReservation.DataSource = null;
                //gvRoomReservation.DataBind();
            }
        }

        #endregion

        #region Textbox Event

        protected void btnCalRate_Click(object sender, EventArgs e)
        {
            //if (ddlFrequency.SelectedIndex != 0 && txtNight.Text.Trim() != string.Empty)
            //{
            BindGrid();
            //}
            //else
            //{
            //    gvRoomReservation.DataSource = null;
            //    gvRoomReservation.DataBind();
            //}
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

                // gvRoomReservation.DataSource = dtTable;
                // gvRoomReservation.DataBind();
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
            dr3["NameColumn"] = "Room Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion

        #region Control Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString.Count != 0)
                {
                    if (Convert.ToBoolean(Request.QueryString["Walkin"]) == true)
                    {
                        Response.Redirect("~/GUI/Reservation/CheckIn.aspx?Walkin=True");
                    }
                }
                else
                {
                    mpeReservatinoVoucher.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/RoomReservationList.aspx");
        }

        protected void lnkRoomReservationServices_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
            ctrlCommonAddServices.ClearServiceControl();
            ////ctrlCommonAddServices.BindServiceList();
        }

        protected void lnkHouseKeeping_Click(object sender, EventArgs e)
        {
            ctrlCommonHouseKeeping.ucMpeAddEditHouseKeeping.Show();
            ctrlCommonHouseKeeping.BindHouseKeepingGrid();
        }

        protected void lnkDeposit_OnClick(object sender, EventArgs e)
        {
            //CtrlCommonAddDeposit1.ucMvDeposit.ActiveViewIndex = 1;
            //mpeDeposit.Show();
            mpeDepositList.Show();
        }

        protected void lnkOtherInfo_OnClick(object sender, EventArgs e)
        {
            mpeOtherInfo.Show();
        }

        protected void lnkVoucherDetail_OnClick(object sender, EventArgs e)
        {
            mpeVoucherDetails.Show();
        }

        protected void lnkCheckiIn_OnClick(object sender, EventArgs e)
        {
            //ctrlCommonCheckIn.ucMpeCheckIn.Show();
            mpeCheckIn.Show();
            ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 0;

        }

        protected void lnkReRoute_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?RoomReservation=true");
        }

        protected void lnkFolio_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Folio/FolioList.aspx");
        }

        protected void btnCheckInCallParent_Click(object sender, EventArgs e)
        {
            string strOperation = ctrlCommonCheckIn.strMode;

            if (strOperation == "OPENADDSERVICEPOPUP")
            {
                mpeCheckIn.Show();
                ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 1;
            }
            else if (strOperation == "CLOSEADDSERVICEPOPUP")
            {
                mpeCheckIn.Show();
                ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 0;
            }
        }

        protected void btnAddServicesCallParent_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
        }

        protected void btnDepositListCallParent_Click(object sender, EventArgs e)
        {
            mpeDepositList.Show();
            if (CtrlDepositList.strMode == "0")
                CtrlDepositList.mvucDepositList.ActiveViewIndex = 0;
            if (CtrlDepositList.strMode == "1")
                CtrlDepositList.mvucDepositList.ActiveViewIndex = 1;
            if (CtrlDepositList.strMode == "2")
                CtrlDepositList.mvucDepositList.ActiveViewIndex = 2;
            if (CtrlDepositList.strMode == "3")
                CtrlDepositList.mvucDepositList.ActiveViewIndex = 3;
            if (CtrlDepositList.strMode == "4")
                CtrlDepositList.mvucDepositList.ActiveViewIndex = 4;
        }
        #endregion
    }
}