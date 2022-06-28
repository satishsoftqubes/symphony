using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlAvailabilityByFloor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtTodayDate = DateTime.Now;
                DateTime dtNextDate = DateTime.Now.AddDays(1);

                txtSearchFromDate.Text = Convert.ToString(dtTodayDate.ToString("dd-MMM-yyyy"));
                txtSearchToDate.Text = Convert.ToString(dtNextDate.ToString("dd-MMM-yyyy"));
                BindBreadCrumb();
                BindGrid();

            }

        }

        #region Private Method

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
            dr3["NameColumn"] = "By Floor";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGrid()
        {
            try
            {
                DataTable dtAvailability = new DataTable();

                DataColumn dc1 = new DataColumn("BlockName");
                DataColumn dc2 = new DataColumn("TotalAVL");
                DataColumn dc3 = new DataColumn("TotalOOS");
                DataColumn dc4 = new DataColumn("TotalArrival");
                DataColumn dc5 = new DataColumn("TotalDepature");
                DataColumn dc6 = new DataColumn("TotalCheckIn");
                DataColumn dc7 = new DataColumn("TotalNoShow");
                DataColumn dc8 = new DataColumn("TotalGuaranted");
                DataColumn dc9 = new DataColumn("TotalUnConfirmed");
                DataColumn dc10 = new DataColumn("TotalInHouse");
                DataColumn dc11 = new DataColumn("TotalNonArrival");
                DataColumn dc12 = new DataColumn("TotalConfirmed");
                DataColumn dc13 = new DataColumn("TotalWaightingList");
                DataColumn dc14 = new DataColumn("Total");


                dtAvailability.Columns.Add(dc1);
                dtAvailability.Columns.Add(dc2);
                dtAvailability.Columns.Add(dc3);
                dtAvailability.Columns.Add(dc4);
                dtAvailability.Columns.Add(dc5);
                dtAvailability.Columns.Add(dc6);
                dtAvailability.Columns.Add(dc7);
                dtAvailability.Columns.Add(dc8);
                dtAvailability.Columns.Add(dc9);
                dtAvailability.Columns.Add(dc10);
                dtAvailability.Columns.Add(dc11);
                dtAvailability.Columns.Add(dc12);
                dtAvailability.Columns.Add(dc13);
                dtAvailability.Columns.Add(dc14);


                DataRow dr1 = dtAvailability.NewRow();
                dr1["BlockName"] = "Block A (50)";
                dr1["TotalAVL"] = "1";
                dr1["TotalOOS"] = "1";
                dr1["TotalArrival"] = "1";
                dr1["TotalDepature"] = "1";
                dr1["TotalCheckIn"] = "1";
                dr1["TotalNoShow"] = "1";
                dr1["TotalGuaranted"] = "1";
                dr1["TotalUnConfirmed"] = "1";
                dr1["TotalInHouse"] = "1";
                dr1["TotalNonArrival"] = "1";
                dr1["TotalConfirmed"] = "1";
                dr1["TotalWaightingList"] = "1";
                dr1["Total"] = "1";

                dtAvailability.Rows.Add(dr1);

                DataRow dr2 = dtAvailability.NewRow();
                dr2["BlockName"] = "Block B (75)";
                dr2["TotalAVL"] = "2";
                dr2["TotalOOS"] = "2";
                dr2["TotalArrival"] = "2";
                dr2["TotalDepature"] = "2";
                dr2["TotalCheckIn"] = "2";
                dr2["TotalNoShow"] = "2";
                dr2["TotalGuaranted"] = "2";
                dr2["TotalUnConfirmed"] = "2";
                dr2["TotalInHouse"] = "2";
                dr2["TotalNonArrival"] = "2";
                dr2["TotalConfirmed"] = "2";
                dr2["TotalWaightingList"] = "2";
                dr2["Total"] = "2";
                dtAvailability.Rows.Add(dr2);

                DataRow dr3 = dtAvailability.NewRow();
                dr3["BlockName"] = "Block C (100)";
                dr3["TotalAVL"] = "3";
                dr3["TotalOOS"] = "3";
                dr3["TotalArrival"] = "3";
                dr3["TotalDepature"] = "3";
                dr3["TotalCheckIn"] = "3";
                dr3["TotalNoShow"] = "3";
                dr3["TotalGuaranted"] = "3";
                dr3["TotalUnConfirmed"] = "3";
                dr3["TotalInHouse"] = "3";
                dr3["TotalNonArrival"] = "3";
                dr3["TotalConfirmed"] = "3";
                dr3["TotalWaightingList"] = "3";
                dr3["Total"] = "3";
                dtAvailability.Rows.Add(dr3);

                DataRow dr4 = dtAvailability.NewRow();
                dr4["BlockName"] = "Block D (125)";
                dr4["TotalAVL"] = "4";
                dr4["TotalOOS"] = "4";
                dr4["TotalArrival"] = "4";
                dr4["TotalDepature"] = "4";
                dr4["TotalCheckIn"] = "4";
                dr4["TotalNoShow"] = "4";
                dr4["TotalGuaranted"] = "4";
                dr4["TotalUnConfirmed"] = "4";
                dr4["TotalInHouse"] = "4";
                dr4["TotalNonArrival"] = "4";
                dr4["TotalConfirmed"] = "4";
                dr4["TotalWaightingList"] = "4";
                dr4["Total"] = "4";
                dtAvailability.Rows.Add(dr4);

                gvAvailabilityByFloor.DataSource = dtAvailability;
                gvAvailabilityByFloor.DataBind();

                BindChildGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindChildGrid()
        {
            try
            {
                foreach (GridViewRow gvi in gvAvailabilityByFloor.Rows)
                {
                    GridView gvInnerGridAvaiByFloorList = (GridView)(gvi.FindControl("gvInnerGridAvaiByFloorList"));

                    DataTable dtTableInnderGrid = new DataTable();

                    DataColumn dc1 = new DataColumn("FloorNo");
                    DataColumn dc2 = new DataColumn("AVL");
                    DataColumn dc3 = new DataColumn("ENQ");
                    DataColumn dc4 = new DataColumn("OOS");
                    DataColumn dc5 = new DataColumn("Arrival");
                    DataColumn dc6 = new DataColumn("CheckIn");
                    DataColumn dc7 = new DataColumn("NoShow");
                    DataColumn dc8 = new DataColumn("Guarented");
                    DataColumn dc9 = new DataColumn("UnConfirmed");
                    DataColumn dc10 = new DataColumn("Departure");
                    DataColumn dc11 = new DataColumn("InHouse");
                    DataColumn dc12 = new DataColumn("NonArrival");
                    DataColumn dc13 = new DataColumn("Confirmed");
                    DataColumn dc14 = new DataColumn("WaitingList");
                    DataColumn dc15 = new DataColumn("Total");

                    dtTableInnderGrid.Columns.Add(dc1);
                    dtTableInnderGrid.Columns.Add(dc2);
                    dtTableInnderGrid.Columns.Add(dc3);
                    dtTableInnderGrid.Columns.Add(dc4);
                    dtTableInnderGrid.Columns.Add(dc5);
                    dtTableInnderGrid.Columns.Add(dc6);
                    dtTableInnderGrid.Columns.Add(dc7);
                    dtTableInnderGrid.Columns.Add(dc8);
                    dtTableInnderGrid.Columns.Add(dc9);
                    dtTableInnderGrid.Columns.Add(dc10);
                    dtTableInnderGrid.Columns.Add(dc11);
                    dtTableInnderGrid.Columns.Add(dc12);
                    dtTableInnderGrid.Columns.Add(dc13);
                    dtTableInnderGrid.Columns.Add(dc14);
                    dtTableInnderGrid.Columns.Add(dc15);

                    /*
                    int i = Convert.ToInt32(gvi.RowIndex);

                    if (i == 0)
                    {

                        DataRow dr1 = dtTableInnderGrid.NewRow();
                        dr1["FloorNo"] = "Floor 1";
                        dr1["AVL"] = "1";
                        dr1["ENQ"] = "1";
                        dr1["OOS"] = "1";
                        dr1["Arrival"] = "1";
                        dr1["CheckIn"] = "1";
                        dr1["NoShow"] = "1";
                        dr1["Guarented"] = "1";
                        dr1["UnConfirmed"] = "1";
                        dr1["Departure"] = "1";
                        dr1["InHouse"] = "1";
                        dr1["NonArrival"] = "1";
                        dr1["Confirmed"] = "1";
                        dr1["WaitingList"] = "1";
                        dr1["Total"] = "1";
                        dtTableInnderGrid.Rows.Add(dr1);

                        DataRow dr5 = dtTableInnderGrid.NewRow();
                        dr5["FloorNo"] = "Floor 2";
                        dr5["AVL"] = "1";
                        dr5["ENQ"] = "4";
                        dr5["OOS"] = "7";
                        dr5["Arrival"] = "2";
                        dr5["CheckIn"] = "5";
                        dr5["NoShow"] = "8";
                        dr5["Guarented"] = "3";
                        dr5["UnConfirmed"] = "6";
                        dr5["Departure"] = "9";
                        dr5["InHouse"] = "9";
                        dr5["NonArrival"] = "8";
                        dr5["Confirmed"] = "7";
                        dr5["WaitingList"] = "1";
                        dr5["Total"] = "80";
                        dtTableInnderGrid.Rows.Add(dr5);

                        DataRow dr6 = dtTableInnderGrid.NewRow();
                        dr6["FloorNo"] = "Floor 3";
                        dr6["AVL"] = "9";
                        dr6["ENQ"] = "4";
                        dr6["OOS"] = "2";
                        dr6["Arrival"] = "5";
                        dr6["CheckIn"] = "2";
                        dr6["NoShow"] = "7";
                        dr6["Guarented"] = "5";
                        dr6["UnConfirmed"] = "6";
                        dr6["Departure"] = "7";
                        dr6["InHouse"] = "1";
                        dr6["NonArrival"] = "5";
                        dr6["Confirmed"] = "2";
                        dr6["WaitingList"] = "5";
                        dr6["Total"] = "100";
                        dtTableInnderGrid.Rows.Add(dr6);

                        DataRow dr7 = dtTableInnderGrid.NewRow();
                        dr7["FloorNo"] = "Floor 4";
                        dr7["AVL"] = "1";
                        dr7["ENQ"] = "1";
                        dr7["OOS"] = "1";
                        dr7["Arrival"] = "1";
                        dr7["CheckIn"] = "1";
                        dr7["NoShow"] = "1";
                        dr7["Guarented"] = "1";
                        dr7["UnConfirmed"] = "1";
                        dr7["Departure"] = "1";
                        dr7["InHouse"] = "1";
                        dr7["NonArrival"] = "1";
                        dr7["Confirmed"] = "1";
                        dr7["WaitingList"] = "1";
                        dr7["Total"] = "1";
                        dtTableInnderGrid.Rows.Add(dr7);
                    }
                    else if (i == 1)
                    {

                        DataRow dr2 = dtTableInnderGrid.NewRow();
                        dr2["FloorNo"] = "Floor 2";
                        dr2["AVL"] = "2";
                        dr2["ENQ"] = "2";
                        dr2["OOS"] = "2";
                        dr2["Arrival"] = "2";
                        dr2["CheckIn"] = "2";
                        dr2["NoShow"] = "2";
                        dr2["Guarented"] = "2";
                        dr2["UnConfirmed"] = "2";
                        dr2["Departure"] = "2";
                        dr2["InHouse"] = "2";
                        dr2["NonArrival"] = "2";
                        dr2["Confirmed"] = "2";
                        dr2["WaitingList"] = "2";
                        dr2["Total"] = "2";
                        dtTableInnderGrid.Rows.Add(dr2);

                        DataRow dr8 = dtTableInnderGrid.NewRow();
                        dr8["FloorNo"] = "Floor 1";
                        dr8["AVL"] = "2";
                        dr8["ENQ"] = "54";
                        dr8["OOS"] = "78";
                        dr8["Arrival"] = "7";
                        dr8["CheckIn"] = "6";
                        dr8["NoShow"] = "4";
                        dr8["Guarented"] = "3";
                        dr8["UnConfirmed"] = "6";
                        dr8["Departure"] = "9";
                        dr8["InHouse"] = "0";
                        dr8["NonArrival"] = "5";
                        dr8["Confirmed"] = "32";
                        dr8["WaitingList"] = "4";
                        dr8["Total"] = "150";
                        dtTableInnderGrid.Rows.Add(dr8);

                        DataRow dr9 = dtTableInnderGrid.NewRow();
                        dr9["FloorNo"] = "Floor 3";
                        dr9["AVL"] = "6";
                        dr9["ENQ"] = "8";
                        dr9["OOS"] = "2";
                        dr9["Arrival"] = "4";
                        dr9["CheckIn"] = "7";
                        dr9["NoShow"] = "5";
                        dr9["Guarented"] = "2";
                        dr9["UnConfirmed"] = "0";
                        dr9["Departure"] = "0";
                        dr9["InHouse"] = "6";
                        dr9["NonArrival"] = "5";
                        dr9["Confirmed"] = "2";
                        dr9["WaitingList"] = "5";
                        dr9["Total"] = "80";
                        dtTableInnderGrid.Rows.Add(dr9);

                        DataRow dr10 = dtTableInnderGrid.NewRow();
                        dr10["FloorNo"] = "Floor 4";
                        dr10["AVL"] = "2";
                        dr10["ENQ"] = "4";
                        dr10["OOS"] = "2";
                        dr10["Arrival"] = "7";
                        dr10["CheckIn"] = "2";
                        dr10["NoShow"] = "4";
                        dr10["Guarented"] = "65";
                        dr10["UnConfirmed"] = "9";
                        dr10["Departure"] = "0";
                        dr10["InHouse"] = "7";
                        dr10["NonArrival"] = "5";
                        dr10["Confirmed"] = "2";
                        dr10["WaitingList"] = "5";
                        dr10["Total"] = "120";
                        dtTableInnderGrid.Rows.Add(dr10);
                    }

                    else if (i == 2)
                    {
                        DataRow dr3 = dtTableInnderGrid.NewRow();
                        dr3["FloorNo"] = "Floor 3";
                        dr3["AVL"] = "3";
                        dr3["ENQ"] = "3";
                        dr3["OOS"] = "3";
                        dr3["Arrival"] = "3";
                        dr3["CheckIn"] = "3";
                        dr3["NoShow"] = "3";
                        dr3["Guarented"] = "3";
                        dr3["UnConfirmed"] = "3";
                        dr3["Departure"] = "3";
                        dr3["InHouse"] = "3";
                        dr3["NonArrival"] = "3";
                        dr3["Confirmed"] = "3";
                        dr3["WaitingList"] = "3";
                        dr3["Total"] = "3";
                        dtTableInnderGrid.Rows.Add(dr3);

                        DataRow dr17 = dtTableInnderGrid.NewRow();
                        dr17["FloorNo"] = "Floor 3";
                        dr17["AVL"] = "3";
                        dr17["ENQ"] = "3";
                        dr17["OOS"] = "3";
                        dr17["Arrival"] = "3";
                        dr17["CheckIn"] = "3";
                        dr17["NoShow"] = "3";
                        dr17["Guarented"] = "3";
                        dr17["UnConfirmed"] = "3";
                        dr17["Departure"] = "3";
                        dr17["InHouse"] = "3";
                        dr17["NonArrival"] = "3";
                        dr17["Confirmed"] = "3";
                        dr17["WaitingList"] = "3";
                        dr17["Total"] = "3";
                        dtTableInnderGrid.Rows.Add(dr17);

                        DataRow dr11 = dtTableInnderGrid.NewRow();
                        dr11["FloorNo"] = "Floor 1";
                        dr11["AVL"] = "1";
                        dr11["ENQ"] = "9";
                        dr11["OOS"] = "1";
                        dr11["Arrival"] = "5";
                        dr11["CheckIn"] = "6";
                        dr11["NoShow"] = "3";
                        dr11["Guarented"] = "4";
                        dr11["UnConfirmed"] = "2";
                        dr11["Departure"] = "8";
                        dr11["InHouse"] = "9";
                        dr11["NonArrival"] = "0";
                        dr11["Confirmed"] = "3";
                        dr11["WaitingList"] = "5";
                        dr11["Total"] = "90";
                        dtTableInnderGrid.Rows.Add(dr11);

                        DataRow dr12 = dtTableInnderGrid.NewRow();
                        dr12["FloorNo"] = "Floor 2";
                        dr12["AVL"] = "8";
                        dr12["ENQ"] = "6";
                        dr12["OOS"] = "3";
                        dr12["Arrival"] = "2";
                        dr12["CheckIn"] = "7";
                        dr12["NoShow"] = "6";
                        dr12["Guarented"] = "1";
                        dr12["UnConfirmed"] = "2";
                        dr12["Departure"] = "5";
                        dr12["InHouse"] = "0";
                        dr12["NonArrival"] = "0";
                        dr12["Confirmed"] = "0";
                        dr12["WaitingList"] = "34";
                        dr12["Total"] = "30";
                        dtTableInnderGrid.Rows.Add(dr12);

                        DataRow dr13 = dtTableInnderGrid.NewRow();
                        dr13["FloorNo"] = "Floor 4";
                        dr13["AVL"] = "3";
                        dr13["ENQ"] = "3";
                        dr13["OOS"] = "3";
                        dr13["Arrival"] = "3";
                        dr13["CheckIn"] = "3";
                        dr13["NoShow"] = "3";
                        dr13["Guarented"] = "3";
                        dr13["UnConfirmed"] = "3";
                        dr13["Departure"] = "3";
                        dr13["InHouse"] = "3";
                        dr13["NonArrival"] = "3";
                        dr13["Confirmed"] = "3";
                        dr13["WaitingList"] = "3";
                        dr13["Total"] = "3";
                        dtTableInnderGrid.Rows.Add(dr13);
                    }
                    else
                    {
                        DataRow dr4 = dtTableInnderGrid.NewRow();
                        dr4["FloorNo"] = "Floor 4";
                        dr4["AVL"] = "4";
                        dr4["ENQ"] = "4";
                        dr4["OOS"] = "4";
                        dr4["Arrival"] = "4";
                        dr4["CheckIn"] = "4";
                        dr4["NoShow"] = "4";
                        dr4["Guarented"] = "4";
                        dr4["UnConfirmed"] = "4";
                        dr4["Departure"] = "4";
                        dr4["InHouse"] = "4";
                        dr4["NonArrival"] = "4";
                        dr4["Confirmed"] = "4";
                        dr4["WaitingList"] = "4";
                        dr4["Total"] = "40";
                        dtTableInnderGrid.Rows.Add(dr4);

                        DataRow dr14 = dtTableInnderGrid.NewRow();
                        dr14["FloorNo"] = "Floor 3";
                        dr14["AVL"] = "4";
                        dr14["ENQ"] = "4";
                        dr14["OOS"] = "4";
                        dr14["Arrival"] = "4";
                        dr14["CheckIn"] = "4";
                        dr14["NoShow"] = "4";
                        dr14["Guarented"] = "4";
                        dr14["UnConfirmed"] = "4";
                        dr14["Departure"] = "4";
                        dr14["InHouse"] = "4";
                        dr14["NonArrival"] = "4";
                        dr14["Confirmed"] = "4";
                        dr14["WaitingList"] = "4";
                        dr14["Total"] = "40";
                        dtTableInnderGrid.Rows.Add(dr14);

                        DataRow dr15 = dtTableInnderGrid.NewRow();
                        dr15["FloorNo"] = "Floor 2";
                        dr15["AVL"] = "4";
                        dr15["ENQ"] = "4";
                        dr15["OOS"] = "4";
                        dr15["Arrival"] = "4";
                        dr15["CheckIn"] = "4";
                        dr15["NoShow"] = "4";
                        dr15["Guarented"] = "4";
                        dr15["UnConfirmed"] = "4";
                        dr15["Departure"] = "4";
                        dr15["InHouse"] = "4";
                        dr15["NonArrival"] = "4";
                        dr15["Confirmed"] = "4";
                        dr15["WaitingList"] = "4";
                        dr15["Total"] = "40";
                        dtTableInnderGrid.Rows.Add(dr15);

                        DataRow dr16 = dtTableInnderGrid.NewRow();
                        dr16["FloorNo"] = "Floor 1";
                        dr16["AVL"] = "4";
                        dr16["ENQ"] = "4";
                        dr16["OOS"] = "4";
                        dr16["Arrival"] = "4";
                        dr16["CheckIn"] = "4";
                        dr16["NoShow"] = "4";
                        dr16["Guarented"] = "4";
                        dr16["UnConfirmed"] = "4";
                        dr16["Departure"] = "4";
                        dr16["InHouse"] = "4";
                        dr16["NonArrival"] = "4";
                        dr16["Confirmed"] = "4";
                        dr16["WaitingList"] = "4";
                        dr16["Total"] = "40";
                        dtTableInnderGrid.Rows.Add(dr16);
                    }
                     * */
                    DataRow dr8 = dtTableInnderGrid.NewRow();
                    dr8["FloorNo"] = "Ground";
                    dr8["AVL"] = "1";
                    dr8["ENQ"] = "1";
                    dr8["OOS"] = "1";
                    dr8["Arrival"] = "1";
                    dr8["CheckIn"] = "1";
                    dr8["NoShow"] = "1";
                    dr8["Guarented"] = "1";
                    dr8["UnConfirmed"] = "1";
                    dr8["Departure"] = "1";
                    dr8["InHouse"] = "1";
                    dr8["NonArrival"] = "1";
                    dr8["Confirmed"] = "1";
                    dr8["WaitingList"] = "1";
                    dr8["Total"] = "1";
                    dtTableInnderGrid.Rows.Add(dr8);

                    DataRow dr1 = dtTableInnderGrid.NewRow();
                    dr1["FloorNo"] = "1st";
                    dr1["AVL"] = "1";
                    dr1["ENQ"] = "1";
                    dr1["OOS"] = "1";
                    dr1["Arrival"] = "1";
                    dr1["CheckIn"] = "1";
                    dr1["NoShow"] = "1";
                    dr1["Guarented"] = "1";
                    dr1["UnConfirmed"] = "1";
                    dr1["Departure"] = "1";
                    dr1["InHouse"] = "1";
                    dr1["NonArrival"] = "1";
                    dr1["Confirmed"] = "1";
                    dr1["WaitingList"] = "1";
                    dr1["Total"] = "1";
                    dtTableInnderGrid.Rows.Add(dr1);

                    DataRow dr5 = dtTableInnderGrid.NewRow();
                    dr5["FloorNo"] = "2nd";
                    dr5["AVL"] = "1";
                    dr5["ENQ"] = "4";
                    dr5["OOS"] = "7";
                    dr5["Arrival"] = "2";
                    dr5["CheckIn"] = "5";
                    dr5["NoShow"] = "8";
                    dr5["Guarented"] = "3";
                    dr5["UnConfirmed"] = "6";
                    dr5["Departure"] = "9";
                    dr5["InHouse"] = "9";
                    dr5["NonArrival"] = "8";
                    dr5["Confirmed"] = "7";
                    dr5["WaitingList"] = "1";
                    dr5["Total"] = "80";
                    dtTableInnderGrid.Rows.Add(dr5);

                    DataRow dr6 = dtTableInnderGrid.NewRow();
                    dr6["FloorNo"] = "3rd";
                    dr6["AVL"] = "9";
                    dr6["ENQ"] = "4";
                    dr6["OOS"] = "2";
                    dr6["Arrival"] = "5";
                    dr6["CheckIn"] = "2";
                    dr6["NoShow"] = "7";
                    dr6["Guarented"] = "5";
                    dr6["UnConfirmed"] = "6";
                    dr6["Departure"] = "7";
                    dr6["InHouse"] = "1";
                    dr6["NonArrival"] = "5";
                    dr6["Confirmed"] = "2";
                    dr6["WaitingList"] = "5";
                    dr6["Total"] = "100";
                    dtTableInnderGrid.Rows.Add(dr6);

                    DataRow dr7 = dtTableInnderGrid.NewRow();
                    dr7["FloorNo"] = "4th";
                    dr7["AVL"] = "1";
                    dr7["ENQ"] = "1";
                    dr7["OOS"] = "1";
                    dr7["Arrival"] = "1";
                    dr7["CheckIn"] = "1";
                    dr7["NoShow"] = "1";
                    dr7["Guarented"] = "1";
                    dr7["UnConfirmed"] = "1";
                    dr7["Departure"] = "1";
                    dr7["InHouse"] = "1";
                    dr7["NonArrival"] = "1";
                    dr7["Confirmed"] = "1";
                    dr7["WaitingList"] = "1";
                    dr7["Total"] = "1";
                    dtTableInnderGrid.Rows.Add(dr7);



                    gvInnerGridAvaiByFloorList.DataSource = dtTableInnderGrid;
                    gvInnerGridAvaiByFloorList.DataBind();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method
    }
}