using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlWalkIn : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSrchDepartureDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
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

                DataColumn dc1 = new DataColumn("RoomType");
                DataColumn dc2 = new DataColumn("Vacant");
                DataColumn dc3 = new DataColumn("Adult");
                DataColumn dc4 = new DataColumn("Child");
                DataColumn dc5 = new DataColumn("1stNight");
                DataColumn dc6 = new DataColumn("EstCost");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);

                DataRow dr1 = dtTable.NewRow();
                dr1["RoomType"] = "Double";
                dr1["Vacant"] = "5";
                dr1["Adult"] = "2";
                dr1["Child"] = "0";
                dr1["1stNight"] = "100.00";
                dr1["EstCost"] = "200.00";
                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["RoomType"] = "Superior";
                dr2["Vacant"] = "5";
                dr2["Adult"] = "3";
                dr2["Child"] = "1";
                dr2["1stNight"] = "250.00";
                dr2["EstCost"] = "500.00";
                dtTable.Rows.Add(dr2);

                DataRow dr3 = dtTable.NewRow();
                dr3["RoomType"] = "Family";
                dr3["Vacant"] = "8";
                dr3["Adult"] = "4";
                dr3["Child"] = "2";
                dr3["1stNight"] = "300.00";
                dr3["EstCost"] = "600.00";
                dtTable.Rows.Add(dr3);

                gvRoomTypes.DataSource = dtTable;
                gvRoomTypes.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BindRoomGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Room");
                DataColumn dc2 = new DataColumn("Bed");
                DataColumn dc3 = new DataColumn("WingFloor");
                DataColumn dc4 = new DataColumn("Adult");
                DataColumn dc5 = new DataColumn("Child");
                DataColumn dc6 = new DataColumn("EstCost");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);

                DataRow dr1 = dtTable.NewRow();
                dr1["Room"] = "DBL-101";
                dr1["Bed"] = "1";
                dr1["WingFloor"] = "";
                dr1["Adult"] = "2";
                dr1["Child"] = "0";
                dr1["EstCost"] = "200.00";
                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Room"] = "DBL-102";
                dr2["Bed"] = "1";
                dr2["WingFloor"] = "";
                dr2["Adult"] = "2";
                dr2["Child"] = "0";
                dr2["EstCost"] = "200.00";
                dtTable.Rows.Add(dr2);

                DataRow dr3 = dtTable.NewRow();
                dr3["Room"] = "DBL-102";
                dr3["Bed"] = "1";
                dr3["WingFloor"] = "";
                dr3["Adult"] = "2";
                dr3["Child"] = "0";
                dr3["EstCost"] = "200.00";
                dtTable.Rows.Add(dr3);

                DataRow dr4 = dtTable.NewRow();
                dr4["Room"] = "DBL-102";
                dr4["Bed"] = "1";
                dr4["WingFloor"] = "";
                dr4["Adult"] = "2";
                dr4["Child"] = "0";
                dr4["EstCost"] = "200.00";
                dtTable.Rows.Add(dr4);

                DataRow dr5 = dtTable.NewRow();
                dr5["Room"] = "DBL-102";
                dr5["Bed"] = "1";
                dr5["WingFloor"] = "";
                dr5["Adult"] = "2";
                dr5["Child"] = "0";
                dr5["EstCost"] = "200.00";
                dtTable.Rows.Add(dr5);

                gvRooms.DataSource = dtTable;
                gvRooms.DataBind();
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
            dr3["NameColumn"] = "Walk-In";
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
            Response.Redirect("");
        }

        #endregion

        #region Grid Events

        protected void gvRoomTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("ROOMTYPE"))
                {
                    lblDepartureDate.Text = txtSrchDepartureDate.Text.Trim();
                    lblAdult.Text = "2";
                    lblChild.Text = "2";
                    BindRoomGrid();
                    mpeRoomType.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRooms_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowIndex == 1 || e.Row.RowIndex == 3 || e.Row.RowIndex == 4)
                    {
                        ((Label)e.Row.FindControl("lblSrNo")).ForeColor = System.Drawing.Color.Red;
                        ((LinkButton)e.Row.FindControl("lnkbtnRoom")).ForeColor = System.Drawing.Color.Red;
                        ((Label)e.Row.FindControl("lblBed")).ForeColor = System.Drawing.Color.Red;
                        ((Label)e.Row.FindControl("lblWingFloor")).ForeColor = System.Drawing.Color.Red;
                        ((Label)e.Row.FindControl("lblAdult")).ForeColor = System.Drawing.Color.Red;
                        ((Label)e.Row.FindControl("lblChild")).ForeColor = System.Drawing.Color.Red;
                        ((Label)e.Row.FindControl("lblEstCost")).ForeColor = System.Drawing.Color.Red;
                    }
                    //((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    //((ImageButton)e.Row.FindControl("btnDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    //((ImageButton)e.Row.FindControl("btnDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PropertyID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    //((Literal)e.Row.FindControl("litGvfNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    //((Label)e.Row.FindControl("lblHdrPropertyName")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrPropertyName", "Property Name");
                    //((Label)e.Row.FindControl("lblHdrPropertyType")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrPropertyType", "Property Type");
                    //((Label)e.Row.FindControl("lblHdrLocation")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrLocation", "City");
                    //((Label)e.Row.FindControl("lblHdrSBA")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrSBA", "SBA");
                    //((Label)e.Row.FindControl("lblHdrBlocks")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrBlocks", "Blocks");
                    //((Label)e.Row.FindControl("lblHdrFloors")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrFloors", "Floors");
                    //((Label)e.Row.FindControl("lblHdrUnitTypes")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrUnitTypes", "Unit Types");
                    //((Label)e.Row.FindControl("lblHdrUnits")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrUnits", "Units");
                    //((Label)e.Row.FindControl("lblHdrHotelLicenceNumber")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrHotelLicenceNumber", "Licence No.");
                    //((Label)e.Row.FindControl("lblHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = "No record found.";// clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRooms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("ROOM"))
                {
                    if (e.CommandArgument.ToString() == "1" || e.CommandArgument.ToString() == "3" || e.CommandArgument.ToString() == "4")
                    {
                        mpeRoomType.Show();
                        MessageBox.Show("There is already checked-In guest in this room, first check-out them.");

                    }
                    else
                    {
                        Response.Redirect("~/GUI/Reservation/RoomReservation.aspx");
                    }
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