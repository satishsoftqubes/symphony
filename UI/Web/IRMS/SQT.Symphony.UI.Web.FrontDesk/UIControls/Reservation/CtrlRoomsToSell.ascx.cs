using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlRoomsToSell : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtTodayDate = DateTime.Now;
                DateTime dtNextDate = DateTime.Now.AddDays(1);

                txtSearchFromDate.Text = Convert.ToString(dtTodayDate.ToString("dd-MMM-yyyy"));
                txtSearchToDate.Text = Convert.ToString(dtNextDate.ToString("dd-MMM-yyyy"));

                Bind_Grid_RoomToSell();
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Private Method

        private void Bind_Grid_RoomToSell()
        {
            try
            {
                DataTable dtRoomToSell = new DataTable();

                DataColumn dc1 = new DataColumn("RoomType");
                DataColumn dc2 = new DataColumn("AVL");
                DataColumn dc3 = new DataColumn("ENQ");
                DataColumn dc4 = new DataColumn("OOS");
                DataColumn dc5 = new DataColumn("Total");


                dtRoomToSell.Columns.Add(dc1);
                dtRoomToSell.Columns.Add(dc2);
                dtRoomToSell.Columns.Add(dc3);
                dtRoomToSell.Columns.Add(dc4);
                dtRoomToSell.Columns.Add(dc5);


                DataRow dr1 = dtRoomToSell.NewRow();
                dr1["RoomType"] = "Standard Non A/c - Double Share";
                dr1["AVL"] = "2";
                dr1["ENQ"] = "0";
                dr1["OOS"] = "0";
                dr1["Total"] = "5";
                dtRoomToSell.Rows.Add(dr1);

                DataRow dr2 = dtRoomToSell.NewRow();
                dr2["RoomType"] = "Superior A/c - Queen Bed";
                dr2["AVL"] = "4";
                dr2["ENQ"] = "0";
                dr2["OOS"] = "1";
                dr2["Total"] = "6";
                dtRoomToSell.Rows.Add(dr2);

                DataRow dr3 = dtRoomToSell.NewRow();
                dr3["RoomType"] = "Superior Non A/c - Double Share";
                dr3["AVL"] = "1";
                dr3["ENQ"] = "1";
                dr3["OOS"] = "1";
                dr3["Total"] = "7";
                dtRoomToSell.Rows.Add(dr3);

                DataRow dr4 = dtRoomToSell.NewRow();
                dr4["RoomType"] = "Suite A/c - King Bed";
                dr4["AVL"] = "1";
                dr4["ENQ"] = "1";
                dr4["OOS"] = "1";
                dr4["Total"] = "7";
                dtRoomToSell.Rows.Add(dr4);

                gvRoomToSell.DataSource = dtRoomToSell;
                gvRoomToSell.DataBind();
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
            dr4["NameColumn"] = "Availability Chart";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "By Type";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion
    }
}