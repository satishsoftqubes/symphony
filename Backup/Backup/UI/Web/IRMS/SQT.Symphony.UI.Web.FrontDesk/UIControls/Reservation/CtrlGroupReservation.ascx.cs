using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlGroupReservation : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["GroupReservation"] != null)
                {
                    mvGroupReservation.ActiveViewIndex = 1;
                    BindGroupReservationGrid();
                    BindBreadCrumb();
                }
                else
                {
                    mvGroupReservation.ActiveViewIndex = 0;
                    BindBreadCrumb();
                    gvGroupReservation.DataSource = null;
                    gvGroupReservation.DataBind();

                }
            }
        }

        #endregion

        #region Control Event        

        protected void ddlBookingReference_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strSelect = clsCommon.GetUpperCaseText("-Select-");
                if (ddlBookingReference.SelectedValue.ToUpper() == "COMPANY")
                {
                    ddlCorporate.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlCorporate.Items.Insert(1, new ListItem("Cubic Systems", "Cubic Systems"));
                    ddlCorporate.Items.Insert(1, new ListItem("CGI group Inc.", "CGI group Inc."));
                }
                else if (ddlBookingReference.SelectedValue.ToUpper() == "AGENT")
                {
                    ddlCorporate.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlCorporate.Items.Insert(1, new ListItem("Thomas sam", "Thomas sam"));
                    ddlCorporate.Items.Insert(1, new ListItem("Vatshal shah", "Vatshal shah"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {

                    mvGroupReservation.ActiveViewIndex = 1;


                    //  litGRDisplayGroupCode.Text = Convert.ToString(txtGroupcode.Text.Trim()) == string.Empty ? "NA" : Convert.ToString(txtGroupcode.Text.Trim());
                    litGRDisplayArrivalDate.Text = Convert.ToString(txtArrivalDate.Text.Trim());
                    litGRDisplayDepatureDate.Text = Convert.ToString(txtDepatureDate.Text.Trim());
                    //litGRDisplayContactNo.Text = Convert.ToString(txtGroupcode.Text.Trim());
                    BindGroupReservationGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/GroupReservationList.aspx");
        }

        protected void btnAddUnit_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    //ddlRateCard.SelectedIndex = ddlRoomType.SelectedIndex = 0;
                    BindGrid();
                    litTotalAccoCharges.Text = "600.00";
                    litServiceTex.Text = "200.00";
                    litOtherTax.Text = "200.00";
                    litTotalCharges.Text = "1000.00";
                    litDeposit.Text = "0.00";
                    litAmountDue.Text = "1000.00";
                    litNoOfDays.Text = "30";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnGRSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnGRBack_Click(object sender, EventArgs e)
        {

            mvGroupReservation.ActiveViewIndex = 0;

        }

        protected void btnGRCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
            ctrlCommonAddServices.ClearServiceControl();
            ////ctrlCommonAddServices.BindServiceList();
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

        protected void btnCalRate_OnClick(object sender, EventArgs e)
        {
            //tblRateCalculation.Visible = true;
            //BindGrid();
        }

        protected void btnQthInfo_OnClick(object sender, EventArgs e)
        {
            mpeOtherInfo.Show();
        }

        protected void btnVoucher_OnClick(object sender, EventArgs e)
        {
            mpeVoucherDetails.Show();
        }

        protected void btnAddGroup_OnClick(object sender, EventArgs e)
        {
            mpeAddGroup.Show();
        }
        
        #endregion

        #region Textbox Event


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

                DataColumn dc1 = new DataColumn("RoomType");
                DataColumn dc2 = new DataColumn("Units");
                DataColumn dc3 = new DataColumn("Adult");
                DataColumn dc4 = new DataColumn("Child");
                DataColumn dc5 = new DataColumn("Inf");
                DataColumn dc6 = new DataColumn("VAT");
                DataColumn dc7 = new DataColumn("OtherTax");
                DataColumn dc8 = new DataColumn("AdvancedPayment");
                DataColumn dc9 = new DataColumn("Total");
                DataColumn dc10 = new DataColumn("Rate");

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
                dr1["RoomType"] = "Standard [04-06-2012 - 05-06-2012]";
                dr1["Units"] = "1";
                dr1["Adult"] = "1";
                dr1["Child"] = "1";
                dr1["Inf"] = "0";
                dr1["VAT"] = "100.00";
                dr1["OtherTax"] = "100.00";
                dr1["AdvancedPayment"] = "0.00";
                dr1["Total"] = "500.00";
                dr1["Rate"] = "300.00";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["RoomType"] = "Suite - King Bed [10-07-2012 - 11-07-2012]";
                dr2["Units"] = "1";
                dr2["Adult"] = "2";
                dr2["Child"] = "1";
                dr2["Inf"] = "0";
                dr2["VAT"] = "100.00";
                dr2["OtherTax"] = "100.00";
                dr2["AdvancedPayment"] = "0.00";
                dr2["Total"] = "500.00";
                dr2["Rate"] = "300.00";

                dtTable.Rows.Add(dr2);


                gvGroupReservation.DataSource = dtTable;
                gvGroupReservation.DataBind();
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
            dr3["NameColumn"] = "Group Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGroupReservationGrid()
        {
            try
            {
                DataTable dtTableGR = new DataTable();

                DataColumn dc1 = new DataColumn("ReservationNo");
                DataColumn dc2 = new DataColumn("GuestCode");
                DataColumn dc3 = new DataColumn("UnitType");
                DataColumn dc4 = new DataColumn("Unit");
                DataColumn dc5 = new DataColumn("Adult");
                DataColumn dc6 = new DataColumn("Child");
                DataColumn dc7 = new DataColumn("INF");
                DataColumn dc8 = new DataColumn("Status");
                DataColumn dc9 = new DataColumn("Rate");
                DataColumn dc10 = new DataColumn("Service");
                DataColumn dc11 = new DataColumn("Total");
                DataColumn dc12 = new DataColumn("CheckIn");
                DataColumn dc13 = new DataColumn("CheckOut");
                DataColumn dc14 = new DataColumn("GuestName");

                dtTableGR.Columns.Add(dc1);
                dtTableGR.Columns.Add(dc2);
                dtTableGR.Columns.Add(dc3);
                dtTableGR.Columns.Add(dc4);
                dtTableGR.Columns.Add(dc5);
                dtTableGR.Columns.Add(dc6);
                dtTableGR.Columns.Add(dc7);
                dtTableGR.Columns.Add(dc8);
                dtTableGR.Columns.Add(dc9);
                dtTableGR.Columns.Add(dc10);
                dtTableGR.Columns.Add(dc11);
                dtTableGR.Columns.Add(dc12);
                dtTableGR.Columns.Add(dc13);
                dtTableGR.Columns.Add(dc14);


                DataRow dr1 = dtTableGR.NewRow();
                dr1["ReservationNo"] = "1001";
                dr1["GuestCode"] = "30041";
                dr1["UnitType"] = "Standard Non A/c - Double Share";
                dr1["Unit"] = "1";
                dr1["Adult"] = "1";
                dr1["Child"] = "1";
                dr1["INF"] = "0";
                dr1["Status"] = "GTD";
                dr1["Rate"] = "100.00";
                dr1["Service"] = "0.00";
                dr1["Total"] = "100.00";
                dr1["CheckIn"] = "18-07-2012";
                dr1["CheckOut"] = "20-07-2012";
                dr1["GuestName"] = "Satish Thummar";
                dtTableGR.Rows.Add(dr1);

                DataRow dr2 = dtTableGR.NewRow();
                dr2["ReservationNo"] = "2002";
                dr2["GuestCode"] = "30041";
                dr2["UnitType"] = "Superior A/c - King Bed";
                dr2["Unit"] = "2";
                dr2["Adult"] = "2";
                dr2["Child"] = "1";
                dr2["INF"] = "0";
                dr2["Status"] = "GTD";
                dr2["Rate"] = "100.00";
                dr2["Service"] = "0.00";
                dr2["Total"] = "100.00";
                dr2["CheckIn"] = "12-07-2012";
                dr2["CheckOut"] = "15-07-2012";
                dr2["GuestName"] = "Raj Patel";
                dtTableGR.Rows.Add(dr2);

                DataRow dr3 = dtTableGR.NewRow();
                dr3["ReservationNo"] = "3003";
                dr3["GuestCode"] = "30041";
                dr3["UnitType"] = "Superior Non A/c - Double Share";
                dr3["Unit"] = "1";
                dr3["Adult"] = "1";
                dr3["Child"] = "1";
                dr3["INF"] = "0";
                dr3["Status"] = "GTD";
                dr3["Rate"] = "100.00";
                dr3["Service"] = "0.00";
                dr3["Total"] = "100.00";
                dr3["CheckIn"] = "18-07-2012";
                dr3["CheckOut"] = "20-07-2012";
                dr3["GuestName"] = "Dixit Thummar";
                dtTableGR.Rows.Add(dr3);

                DataRow dr4 = dtTableGR.NewRow();
                dr4["ReservationNo"] = "4004";
                dr4["GuestCode"] = "30041";
                dr4["UnitType"] = "Suite A/c - King Bed";
                dr4["Unit"] = "2";
                dr4["Adult"] = "2";
                dr4["Child"] = "1";
                dr4["INF"] = "0";
                dr4["Status"] = "GTD";
                dr4["Rate"] = "100.00";
                dr4["Service"] = "0.00";
                dr4["Total"] = "100.00";
                dr4["CheckIn"] = "12-07-2012";
                dr4["CheckOut"] = "15-07-2012";
                dr4["GuestName"] = "Om Patel";
                dtTableGR.Rows.Add(dr4);


                gvGroupReservationList.DataSource = dtTableGR;
                gvGroupReservationList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Grid Event

        protected void gvGroupReservation_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView gvInnerGrid = (GridView)e.Row.FindControl("InnerGrid");

                    DataTable dtTableInnderGrid = new DataTable();

                    DataColumn dc1 = new DataColumn("RoomType");
                    DataColumn dc2 = new DataColumn("Units");
                    DataColumn dc3 = new DataColumn("Adult");
                    DataColumn dc4 = new DataColumn("Child");
                    DataColumn dc5 = new DataColumn("Inf");
                    DataColumn dc6 = new DataColumn("Rate");
                    DataColumn dc7 = new DataColumn("UnitRate");
                    DataColumn dc8 = new DataColumn("Services");
                    DataColumn dc9 = new DataColumn("Total");

                    dtTableInnderGrid.Columns.Add(dc1);
                    dtTableInnderGrid.Columns.Add(dc2);
                    dtTableInnderGrid.Columns.Add(dc3);
                    dtTableInnderGrid.Columns.Add(dc4);
                    dtTableInnderGrid.Columns.Add(dc5);
                    dtTableInnderGrid.Columns.Add(dc6);
                    dtTableInnderGrid.Columns.Add(dc7);
                    dtTableInnderGrid.Columns.Add(dc8);
                    dtTableInnderGrid.Columns.Add(dc9);

                    int i = Convert.ToInt32(e.Row.RowIndex);

                    if (i == 0)
                    {
                        DataRow dr1 = dtTableInnderGrid.NewRow();
                        dr1["RoomType"] = "04-Jun-2012";
                        dr1["Units"] = "1";
                        dr1["Adult"] = "1";
                        dr1["Child"] = "1";
                        dr1["Inf"] = "0";
                        dr1["Rate"] = "100.00";
                        dr1["UnitRate"] = "100.00";
                        dr1["Services"] = "0.00";
                        dr1["Total"] = "100.00";

                        dtTableInnderGrid.Rows.Add(dr1);
                    }
                    else
                    {

                        DataRow dr2 = dtTableInnderGrid.NewRow();
                        dr2["RoomType"] = "10-Jun-2012";
                        dr2["Units"] = "2";
                        dr2["Adult"] = "2";
                        dr2["Child"] = "1";
                        dr2["Inf"] = "0";
                        dr2["Rate"] = "100.00";
                        dr2["UnitRate"] = "100.00";
                        dr2["Services"] = "0.00";
                        dr2["Total"] = "100.00";

                        dtTableInnderGrid.Rows.Add(dr2);
                    }


                    gvInnerGrid.DataSource = dtTableInnderGrid;
                    gvInnerGrid.DataBind();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //protected void gvGroupReservationList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //GridView InnerGridGRList = (GridView)e.Row.FindControl("InnerGridGRList");

        //        //DataTable dtTableGR = new DataTable();

        //        //DataColumn dc1 = new DataColumn("ReservationNo");
        //        //DataColumn dc2 = new DataColumn("GuestCode");
        //        //DataColumn dc3 = new DataColumn("UnitType");
        //        //DataColumn dc4 = new DataColumn("Unit");
        //        //DataColumn dc5 = new DataColumn("Adult");
        //        //DataColumn dc6 = new DataColumn("Child");
        //        //DataColumn dc7 = new DataColumn("INF");
        //        //DataColumn dc8 = new DataColumn("Status");
        //        //DataColumn dc9 = new DataColumn("Rate");
        //        //DataColumn dc10 = new DataColumn("Service");
        //        //DataColumn dc11 = new DataColumn("Total");

        //        //dtTableGR.Columns.Add(dc1);
        //        //dtTableGR.Columns.Add(dc2);
        //        //dtTableGR.Columns.Add(dc3);
        //        //dtTableGR.Columns.Add(dc4);
        //        //dtTableGR.Columns.Add(dc5);
        //        //dtTableGR.Columns.Add(dc6);
        //        //dtTableGR.Columns.Add(dc7);
        //        //dtTableGR.Columns.Add(dc8);
        //        //dtTableGR.Columns.Add(dc9);
        //        //dtTableGR.Columns.Add(dc10);
        //        //dtTableGR.Columns.Add(dc11);

        //        //int i = Convert.ToInt32(e.Row.RowIndex);

        //        //if (i == 0)
        //        //{
        //        //    DataRow dr1 = dtTableGR.NewRow();
        //        //    dr1["ReservationNo"] = "";
        //        //    dr1["GuestCode"] = "30041";
        //        //    dr1["UnitType"] = "04/Jun/2012";
        //        //    dr1["Unit"] = "";
        //        //    dr1["Adult"] = "1";
        //        //    dr1["Child"] = "1";
        //        //    dr1["INF"] = "0";
        //        //    dr1["Status"] = "";
        //        //    dr1["Rate"] = "100.00";
        //        //    dr1["Service"] = "0.00";
        //        //    dr1["Total"] = "100.00";

        //        //    dtTableGR.Rows.Add(dr1);

        //        //}
        //        //else
        //        //{
        //        //    DataRow dr2 = dtTableGR.NewRow();
        //        //    dr2["ReservationNo"] = "";
        //        //    dr2["GuestCode"] = "30041";
        //        //    dr2["UnitType"] = "10/Jun/2012";
        //        //    dr2["Unit"] = "";
        //        //    dr2["Adult"] = "2";
        //        //    dr2["Child"] = "1";
        //        //    dr2["INF"] = "0";
        //        //    dr2["Status"] = "";
        //        //    dr2["Rate"] = "100.00";
        //        //    dr2["Service"] = "0.00";
        //        //    dr2["Total"] = "100.00";

        //        //    dtTableGR.Rows.Add(dr2);
        //        //}

        //        //DataColumn dc1 = new DataColumn("RoomType");
        //        //DataColumn dc2 = new DataColumn("Units");
        //        //DataColumn dc3 = new DataColumn("Adult");
        //        //DataColumn dc4 = new DataColumn("Child");
        //        //DataColumn dc5 = new DataColumn("Inf");
        //        //DataColumn dc6 = new DataColumn("Rate");
        //        //DataColumn dc7 = new DataColumn("UnitRate");
        //        //DataColumn dc8 = new DataColumn("Services");
        //        //DataColumn dc9 = new DataColumn("Total");

        //        //dtTableInnderGrid.Columns.Add(dc1);
        //        //dtTableInnderGrid.Columns.Add(dc2);
        //        //dtTableInnderGrid.Columns.Add(dc3);
        //        //dtTableInnderGrid.Columns.Add(dc4);
        //        //dtTableInnderGrid.Columns.Add(dc5);
        //        //dtTableInnderGrid.Columns.Add(dc6);
        //        //dtTableInnderGrid.Columns.Add(dc7);
        //        //dtTableInnderGrid.Columns.Add(dc8);
        //        //dtTableInnderGrid.Columns.Add(dc9);

        //        //int i = Convert.ToInt32(e.Row.RowIndex);

        //        //if (i == 0)
        //        //{
        //        //    DataRow dr1 = dtTableInnderGrid.NewRow();
        //        //    dr1["RoomType"] = "04/Jun/2012";
        //        //    dr1["Units"] = "";
        //        //    dr1["Adult"] = "1";
        //        //    dr1["Child"] = "1";
        //        //    dr1["Inf"] = "0";
        //        //    dr1["Rate"] = "100.00";
        //        //    dr1["UnitRate"] = "100.00";
        //        //    dr1["Services"] = "0.00";
        //        //    dr1["Total"] = "100.00";

        //        //    dtTableInnderGrid.Rows.Add(dr1);
        //        //}
        //        //else
        //        //{

        //        //    DataRow dr2 = dtTableInnderGrid.NewRow();
        //        //    dr2["RoomType"] = "10/Jun/2012";
        //        //    dr2["Units"] = "";
        //        //    dr2["Adult"] = "2";
        //        //    dr2["Child"] = "1";
        //        //    dr2["Inf"] = "0";
        //        //    dr2["Rate"] = "100.00";
        //        //    dr2["UnitRate"] = "100.00";
        //        //    dr2["Services"] = "0.00";
        //        //    dr2["Total"] = "100.00";

        //        //    dtTableInnderGrid.Rows.Add(dr2);
        //        //}


        //       // InnerGridGRList.DataSource = dtTableGR;
        //        //InnerGridGRList.DataBind();
        //    }
        //}

        protected void gvGroupReservationList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("SETREROUTE"))
                {

                    Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?GroupReservation=true");
                }
                else if (e.CommandName.ToUpper().Equals("PAYINFO"))
                {
                    ctrlCommonPayment.ucMpeAddEditPayment.Show();
                }
                else if (e.CommandName.ToUpper().Equals("ADDSERVICE"))
                {
                    ctrlCommonAddServices.ucMpeAddEditAddService.Show();
                    ctrlCommonAddServices.ClearServiceControl();
                }
                else if (e.CommandName.ToUpper().Equals("UNITASG"))
                {

                }
                else if (e.CommandName.ToUpper().Equals("CHKIN"))
                {
                    mpeCheckIn.Show();
                    ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 0;
                }
                else if (e.CommandName.ToUpper().Equals("VIEWFOLIO"))
                {
                    Response.Redirect("~/GUI/Folio/FolioDetails.aspx");
                }
                else if (e.CommandName.ToUpper().Equals("EDIT"))
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        //protected void txtNight_TextChanged(object sender, EventArgs e)
        //{
        //    DateTime arvDate = Convert.ToDateTime(txtArrivalDate.Text.Trim());
        //    int i = Convert.ToInt32(txtNight.Text.Trim());
        //    DateTime depDate = arvDate.AddDays(i);

        //    txtDepatureDate.Text = Convert.ToString(depDate.ToString("dd/MMM/yyyy"));
        //}

        protected void btnAddServicesCallParent_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
        }

        protected void btnPaymentCallParent_Click(object sender, EventArgs e)
        {
            ctrlCommonPayment.mvOpenPayment.ActiveViewIndex = 1;
            ctrlCommonPayment.ucMpeAddEditPayment.Show();

        }

        protected void btnGuest_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/AddGroupGuest.aspx");
        }
    }
}