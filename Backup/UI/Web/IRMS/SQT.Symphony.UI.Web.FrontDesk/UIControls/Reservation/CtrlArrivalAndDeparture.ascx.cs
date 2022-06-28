using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlArrivalAndDeparture : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvArrivalAndDeparture.ActiveViewIndex = 0;
                Bind_Grid_Arrival();
                Bind_Grid_Departure();
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Private Method
        private void Bind_Grid_Arrival()
        {
            try
            {
                DataTable dtArrival = new DataTable();

                DataColumn dc1 = new DataColumn("ResNo");
                DataColumn dc2 = new DataColumn("Guest");
                DataColumn dc3 = new DataColumn("Ratecard");
                DataColumn dc4 = new DataColumn("Type");
                DataColumn dc5 = new DataColumn("Pickup");

                dtArrival.Columns.Add(dc1);
                dtArrival.Columns.Add(dc2);
                dtArrival.Columns.Add(dc3);
                dtArrival.Columns.Add(dc4);
                dtArrival.Columns.Add(dc5);


                DataRow dr1 = dtArrival.NewRow();
                dr1["ResNo"] = "156945";
                dr1["Guest"] = "Miss Juhi Patel";
                dr1["Ratecard"] = "Daily";
                dr1["Type"] = "Standard";
                dr1["Pickup"] = "";
                dtArrival.Rows.Add(dr1);

                gvArrival.DataSource = dtArrival;
                gvArrival.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Bind_Grid_Departure()
        {
            try
            {
                DataTable dtDeparture = new DataTable();

                DataColumn dc1 = new DataColumn("ResNo");
                DataColumn dc2 = new DataColumn("Guest");
                DataColumn dc3 = new DataColumn("Room");
                DataColumn dc4 = new DataColumn("Type");
                DataColumn dc5 = new DataColumn("Payment");
                DataColumn dc6 = new DataColumn("Drop");

                dtDeparture.Columns.Add(dc1);
                dtDeparture.Columns.Add(dc2);
                dtDeparture.Columns.Add(dc3);
                dtDeparture.Columns.Add(dc4);
                dtDeparture.Columns.Add(dc5);
                dtDeparture.Columns.Add(dc6);

                DataRow dr1 = dtDeparture.NewRow();
                dr1["ResNo"] = "456123";
                dr1["Guest"] = "Miss Palak Patel";
                dr1["Room"] = "101";
                dr1["Type"] = "Standard";
                dr1["Payment"] = "10000";
                dr1["Drop"] = "";
                dtDeparture.Rows.Add(dr1);

                gvDeparture.DataSource = dtDeparture;
                gvDeparture.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

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
            dr3["NameColumn"] = "Arrival And Departure";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Control Event

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            //ctrlCommonCheckIn.ucMpeCheckIn.Show();
            mpeCheckIn.Show();
            ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 0;
        }

        protected void btnAutoAssingRoom_Click(object sender, EventArgs e)
        {
            CtrlAutoAssignUnit.ucMpeAddEditAutoAssignUnit.Show();
        }

        ////protected void btnExtendReservation_Click(object sender, EventArgs e)
        ////{
        ////    CtrlCommonExtendReservation.ucMpeAddEditExtendReservation.Show();
        ////}

        protected void btnReservationGuestMgtCallParent_Click(object sender, EventArgs e)
        {
            try
            {
                string strView = Convert.ToString(ctrlidReservationGuestMgt.ToActivateView);

                if (strView == "1")
                    ctrlidReservationGuestMgt.mvOpenGuest.ActiveViewIndex = 1;
                else if (strView == "2")
                    ctrlidReservationGuestMgt.mvOpenGuest.ActiveViewIndex = 2;

                ctrlidReservationGuestMgt.ucMpeAddEditGuestMgt.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCheckInCallParent_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnExtendReservationCallParent_Click(object sender, EventArgs e)
        {
            mpeExtendReservation.Show();
        }
        #endregion Control Event

        #region Grid Event

        protected void gvDeparture_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {

                }
                else if (e.CommandName.Equals("VIEWFOLIO"))
                {
                    Response.Redirect("~/GUI/Folio/FolioDetails.aspx");
                }
                else if (e.CommandName.Equals("GUESTMGT"))
                {
                    ctrlidReservationGuestMgt.ucMpeAddEditGuestMgt.Show();
                }
                else if (e.CommandName.Equals("CHECKOUT"))
                {
                    Response.Redirect("~/GUI/Billing/CheckOut.aspx?PostCharges=true");
                }
                else if (e.CommandName.Equals("EXTENDRESERVATION"))
                {
                    ////CtrlCommonExtendReservation.ucMpeAddEditExtendReservation.Show();
                    mpeExtendReservation.Show();

                }
                //else if (e.CommandName.Equals("GUESTMGT"))
                //{
                //    ctrlidReservationGuestMgt.ucMpeAddEditGuestMgt.Show();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvArrival_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {

                }
                else if (e.CommandName.Equals("CHECKIN"))
                {
                    mpeCheckIn.Show();
                    ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 0;
                }
                else if (e.CommandName.Equals("CANCEL"))
                {

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