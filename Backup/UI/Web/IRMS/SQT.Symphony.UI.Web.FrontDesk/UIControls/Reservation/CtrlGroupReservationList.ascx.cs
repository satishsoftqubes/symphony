using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlGroupReservationList : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindGridForGroupReservationList();
                //BindGridForReservationList();
            }
        }

        #endregion 

        #region Private Method

        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindGridForGroupReservationList()
        {
            try
            {

                DataTable dtTable = new DataTable();

                DataColumn dc2 = new DataColumn("ReservationNo");
                DataColumn dc3 = new DataColumn("GuestName");
                DataColumn dc4 = new DataColumn("MobileNo");
                DataColumn dc5 = new DataColumn("Rooms");
                DataColumn dc6 = new DataColumn("RoomType");
                DataColumn dc7 = new DataColumn("Company");
                DataColumn dc8 = new DataColumn("Status");
                DataColumn dc9 = new DataColumn("RateCardType");
                DataColumn dc10 = new DataColumn("CheckIn");
                DataColumn dc11 = new DataColumn("CheckOut");

                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);
                dtTable.Columns.Add(dc9);
                dtTable.Columns.Add(dc10);
                dtTable.Columns.Add(dc11);

                DataRow dr1 = dtTable.NewRow();
                dr1["ReservationNo"] = "123456";
                dr1["GuestName"] = "Mr. Jayesh Patel";
                dr1["MobileNo"] = "9856321470";
                dr1["Rooms"] = "1";
                dr1["RoomType"] = "Delux";
                dr1["Company"] = "Uniworld India";
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dr1["RateCardType"] = "Corporate RateCard";
                dr1["CheckIn"] = "10-08-2012";
                dr1["CheckOut"] = "13-08-2012";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["ReservationNo"] = "654321";
                dr2["GuestName"] = "Miss Palak Jain";
                dr2["MobileNo"] = "8546230145";
                dr2["Rooms"] = "2";
                dr2["RoomType"] = "Family";
                dr2["Company"] = "SQT";
                dr2["Status"] = "<img src='../../images/WaitingList22x22.png' alt='Provisional' title='Waiting List' />";
                dr2["RateCardType"] = "Room RateCard";
                dr2["CheckIn"] = "07-08-2012";
                dr2["CheckOut"] = "09-08-2012";

                dtTable.Rows.Add(dr2);

                gvGroupReservationList.DataSource = dtTable;
                gvGroupReservationList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        /// <summary>
        /// Bind Grid
        /// </summary>
        //private void BindGridForReservationList()
        //{
        //    DataTable dtTableReservationList = new DataTable();

        //    DataColumn dc1 = new DataColumn("Status");
        //    DataColumn dc2 = new DataColumn("ReservationNo");
        //    DataColumn dc3 = new DataColumn("GuestName");
        //    DataColumn dc4 = new DataColumn("RoomConference");
        //    DataColumn dc5 = new DataColumn("UnitType");
        //    DataColumn dc6 = new DataColumn("Group");
        //    DataColumn dc7 = new DataColumn("Payment");
        //    DataColumn dc8 = new DataColumn("Date");
        //    DataColumn dc9 = new DataColumn("VIP");
        //    DataColumn dc10 = new DataColumn("Message");

        //    dtTableReservationList.Columns.Add(dc1);
        //    dtTableReservationList.Columns.Add(dc2);
        //    dtTableReservationList.Columns.Add(dc3);
        //    dtTableReservationList.Columns.Add(dc4);
        //    dtTableReservationList.Columns.Add(dc5);
        //    dtTableReservationList.Columns.Add(dc6);
        //    dtTableReservationList.Columns.Add(dc7);
        //    dtTableReservationList.Columns.Add(dc8);
        //    dtTableReservationList.Columns.Add(dc9);
        //    dtTableReservationList.Columns.Add(dc10);

        //    DataRow dr1 = dtTableReservationList.NewRow();
        //    dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
        //    dr1["ReservationNo"] = "R-1";
        //    dr1["GuestName"] = "Mihir Patel";
        //    dr1["RoomConference"] = "101";
        //    dr1["UnitType"] = "DBL";
        //    dr1["Group"] = "Uniworld";
        //    dr1["Payment"] = "BASC";
        //    dr1["Date"] = "1/May/2012 - 3/May/2012";
        //    dr1["VIP"] = "Mihir Patel";
        //    dr1["Message"] = "Hi...";

        //    dtTableReservationList.Rows.Add(dr1);

        //    DataRow dr3 = dtTableReservationList.NewRow();
        //    dr3["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
        //    dr3["ReservationNo"] = "R-3";
        //    dr3["GuestName"] = "Mihir Patel";
        //    dr3["RoomConference"] = "103";
        //    dr3["UnitType"] = "DBL";
        //    dr3["Group"] = "Uniworld";
        //    dr3["Payment"] = "BASC";
        //    dr3["Date"] = "1/May/2012 - 3/May/2012";
        //    dr3["VIP"] = "Mihir Patel";
        //    dr3["Message"] = "Hi...";

        //    dtTableReservationList.Rows.Add(dr3);

        //    DataRow dr2 = dtTableReservationList.NewRow();
        //    dr2["Status"] = "<img src='../../images/UnConfirmed22x22.png' alt='UnConfirmed' title='UnConfirmed' />";
        //    dr2["ReservationNo"] = "R-2";
        //    dr2["GuestName"] = "Rakesh Shah";
        //    dr2["RoomConference"] = "102";
        //    dr2["UnitType"] = "SUP";
        //    dr2["Group"] = "Softqube";
        //    dr2["Payment"] = "BASC";
        //    dr2["Date"] = "5/May/2012 - 8/May/2012";
        //    dr2["VIP"] = "Rakesh Shah";
        //    dr2["Message"] = "Hello...";

        //    dtTableReservationList.Rows.Add(dr2);

        //    gvReservationList.DataSource = dtTableReservationList;
        //    gvReservationList.DataBind();

        //}

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
            dr3["NameColumn"] = "Group Reservation List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion

        #region Control Event

        protected void btnAddTopGroupReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/GroupReservation.aspx");
        }

        protected void lnkAutoAssignUnit_Click(object sender, EventArgs e)
        {
            CtrlAutoAssignUnit.ucMpeAddEditAutoAssignUnit.Show();
        }
        #endregion
    }
}