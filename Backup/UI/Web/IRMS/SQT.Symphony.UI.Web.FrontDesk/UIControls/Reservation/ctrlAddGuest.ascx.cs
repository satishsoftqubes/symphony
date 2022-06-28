using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class ctrlAddGuest : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindReservationList();
                BindGuestList();
                gvTempGuestList.DataSource = null;
                gvTempGuestList.DataBind();
            }
        }

        private void BindReservationList()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Status");
                DataColumn dc2 = new DataColumn("ReservationNo");
                DataColumn dc3 = new DataColumn("RoomType");
                DataColumn dc4 = new DataColumn("RoomNo");
                DataColumn dc5 = new DataColumn("Guest");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);

                DataRow dr1 = dtTable.NewRow();
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dr1["ReservationNo"] = "123456";
                dr1["RoomNo"] = "1";
                dr1["RoomType"] = "Delux";
                dr1["Guest"] = "2/1";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Status"] = "<img src='../../images/Confirmed22x22.png' alt='UnConfirmed' title='Confirmed' />";
                dr2["ReservationNo"] = "654321";
                dr2["RoomNo"] = "2";
                dr2["RoomType"] = "Family";
                dr2["Guest"] = "2/1";


                dtTable.Rows.Add(dr2);

                gvReservationList.DataSource = dtTable;
                gvReservationList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGuestList()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Status");
                DataColumn dc2 = new DataColumn("Guest");
                //DataColumn dc3 = new DataColumn("Legend");
                DataColumn dc4 = new DataColumn("ID");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                //dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                // dr1["Legend"] = "L";            
                dr1["Guest"] = "Mr. Jayesh Rathod";
                dr1["ID"] = "1";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Status"] = "<img src='../../images/Confirmed22x22.png' alt='UnConfirmed' title='Confirmed' />";
                //dr2["Legend"] = "L";            
                dr2["Guest"] = "Miss. Palak Jain";
                dr2["ID"] = "2";

                dtTable.Rows.Add(dr2);

                DataRow dr3 = dtTable.NewRow();
                dr3["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                // dr3["Legend"] = "L";
                dr3["Guest"] = "Mrs. Shreya Patel";
                dr3["ID"] = "3";

                dtTable.Rows.Add(dr3);

                DataRow dr4 = dtTable.NewRow();
                dr4["Status"] = "<img src='../../images/Confirmed22x22.png' alt='UnConfirmed' title='Confirmed' />";
                //dr4["Legend"] = "L";
                dr4["Guest"] = "Mr. Chetan Shah";
                dr4["ID"] = "4";

                dtTable.Rows.Add(dr4);

                DataRow dr5 = dtTable.NewRow();
                dr5["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                //dr5["Legend"] = "L";
                dr5["Guest"] = "Mrs. Kokila Patel";
                dr5["ID"] = "5";

                dtTable.Rows.Add(dr5);

                gvGuestList.DataSource = dtTable;
                gvGuestList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTemp = new DataTable();
                DataColumn dc1 = new DataColumn("Status");
                DataColumn dc2 = new DataColumn("Guest");
                //DataColumn dc3 = new DataColumn("Legend");
                DataColumn dc4 = new DataColumn("ID");

                dtTemp.Columns.Add(dc1);
                dtTemp.Columns.Add(dc2);
                //dtTemp.Columns.Add(dc3);
                dtTemp.Columns.Add(dc4);

                DataTable dtGuestTemp = new DataTable();
                DataColumn dc11 = new DataColumn("Status");
                DataColumn dc22 = new DataColumn("Guest");
                DataColumn dc44 = new DataColumn("ID");

                dtGuestTemp.Columns.Add(dc11);
                dtGuestTemp.Columns.Add(dc22);
                dtGuestTemp.Columns.Add(dc44);

                for (int i = 0; i < gvTempGuestList.Rows.Count; i++)
                {
                    CheckBox chkTempGuestListSelect = (CheckBox)gvTempGuestList.Rows[i].FindControl("chkTempGuestListSelect");

                    Label lblGuest = (Label)gvTempGuestList.Rows[i].FindControl("lblTempGuest");
                    string strID = Convert.ToString(gvTempGuestList.DataKeys[i]["ID"]);

                    DataRow drRow = dtTemp.NewRow();
                    drRow["ID"] = strID;
                    drRow["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                    drRow["Guest"] = Convert.ToString(lblGuest.Text.Trim());
                    dtTemp.Rows.Add(drRow);
                }

                for (int i = 0; i < gvGuestList.Rows.Count; i++)
                {
                    CheckBox chkGuestListSelect = (CheckBox)gvGuestList.Rows[i].FindControl("chkGuestListSelect");

                    Label lblGuest = (Label)gvGuestList.Rows[i].FindControl("lblGuest");
                    string strID = Convert.ToString(gvGuestList.DataKeys[i]["ID"]);

                    if (chkGuestListSelect.Checked)
                    {
                        DataRow drRow = dtTemp.NewRow();

                        drRow["ID"] = strID;
                        drRow["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                        drRow["Guest"] = Convert.ToString(lblGuest.Text.Trim());
                        dtTemp.Rows.Add(drRow);
                    }
                    else
                    {
                        DataRow drRow = dtGuestTemp.NewRow();
                        drRow["ID"] = strID;
                        drRow["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                        drRow["Guest"] = Convert.ToString(lblGuest.Text.Trim());
                        dtGuestTemp.Rows.Add(drRow);
                    }
                }

                gvTempGuestList.DataSource = dtTemp;
                gvTempGuestList.DataBind();

                gvGuestList.DataSource = dtGuestTemp;
                gvGuestList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnReverseTranser_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTemp = new DataTable();
                DataColumn dc1 = new DataColumn("Status");
                DataColumn dc2 = new DataColumn("Guest");
                DataColumn dc4 = new DataColumn("ID");

                dtTemp.Columns.Add(dc1);
                dtTemp.Columns.Add(dc2);
                dtTemp.Columns.Add(dc4);

                DataTable dtGuestTemp = new DataTable();
                DataColumn dc11 = new DataColumn("Status");
                DataColumn dc22 = new DataColumn("Guest");
                DataColumn dc44 = new DataColumn("ID");

                dtGuestTemp.Columns.Add(dc11);
                dtGuestTemp.Columns.Add(dc22);
                dtGuestTemp.Columns.Add(dc44);

                for (int i = 0; i < gvGuestList.Rows.Count; i++)
                {
                    Label lblGuest = (Label)gvGuestList.Rows[i].FindControl("lblGuest");
                    string strID = Convert.ToString(gvGuestList.DataKeys[i]["ID"]);

                    DataRow drRow = dtGuestTemp.NewRow();

                    drRow["ID"] = strID;
                    drRow["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                    drRow["Guest"] = Convert.ToString(lblGuest.Text.Trim());
                    dtGuestTemp.Rows.Add(drRow);
                }

                for (int i = 0; i < gvTempGuestList.Rows.Count; i++)
                {
                    CheckBox chkTempGuestListSelect = (CheckBox)gvTempGuestList.Rows[i].FindControl("chkTempGuestListSelect");

                    Label lblGuest = (Label)gvTempGuestList.Rows[i].FindControl("lblTempGuest");
                    string strID = Convert.ToString(gvTempGuestList.DataKeys[i]["ID"]);

                    if (chkTempGuestListSelect.Checked)
                    {
                        DataRow drRow = dtGuestTemp.NewRow();
                        drRow["ID"] = strID;
                        drRow["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                        drRow["Guest"] = Convert.ToString(lblGuest.Text.Trim());
                        dtGuestTemp.Rows.Add(drRow);
                    }
                    else
                    {
                        DataRow drRow = dtTemp.NewRow();
                        drRow["ID"] = strID;
                        drRow["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                        drRow["Guest"] = Convert.ToString(lblGuest.Text.Trim());
                        dtTemp.Rows.Add(drRow);
                    }
                }

                gvTempGuestList.DataSource = dtTemp;
                gvTempGuestList.DataBind();

                gvGuestList.DataSource = dtGuestTemp;
                gvGuestList.DataBind();
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
            dr4["NameColumn"] = "Group Reservation";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Guest";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
    }
}