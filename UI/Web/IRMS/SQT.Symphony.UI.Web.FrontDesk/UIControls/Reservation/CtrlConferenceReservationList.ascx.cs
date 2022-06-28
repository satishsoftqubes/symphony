using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlConferenceReservationList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindGrid();
            }
        }

        #region Private Method

        /// <summary>
        /// Bind Grid
        /// </summary>
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
                DataColumn dc9 = new DataColumn("VIP");
                DataColumn dc10 = new DataColumn("Laundry");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);
                dtTable.Columns.Add(dc9);
                dtTable.Columns.Add(dc10);

                DataRow dr1 = dtTable.NewRow();
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dr1["ReservationNo"] = "R-1";
                dr1["GuestName"] = "Mihir Patel";
                dr1["Child"] = "2/2";
                dr1["RoomNo"] = "1";
                dr1["RoomType"] = "Delux";
                dr1["Date"] = "27-Mar-2012 - 28-Mar-2012";
                dr1["Payment"] = "BASC";
                dr1["VIP"] = "Mihir Patel";
                dr1["Laundry"] = "L";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Status"] = "<img src='../../images/UnConfirmed22x22.png' alt='UnConfirmed' title='UnConfirmed' />";
                dr2["ReservationNo"] = "R-2";
                dr2["GuestName"] = "Rakesh Shah";
                dr2["Child"] = "0/1";
                dr2["RoomNo"] = "2";
                dr2["RoomType"] = "Family";
                dr2["Date"] = "28-Mar-2012 - 29-Mar-2012";
                dr2["Payment"] = "BASC";
                dr2["VIP"] = "Rakesh Shah";
                dr2["Laundry"] = "";

                dtTable.Rows.Add(dr2);

                gvRoomReservationList.DataSource = dtTable;
                gvRoomReservationList.DataBind();
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
            dr3["NameColumn"] = "Room Reservation List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion

        #region Control Event

        protected void btnAddTopRoomReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/ConferenceReservation.aspx");
        }

        protected void lnkAutoAssignRoom_Click(object sender, EventArgs e)
        {
            CtrlAutoAssignUnit.ucMpeAddEditAutoAssignUnit.Show();
        }

        #endregion
    }
}