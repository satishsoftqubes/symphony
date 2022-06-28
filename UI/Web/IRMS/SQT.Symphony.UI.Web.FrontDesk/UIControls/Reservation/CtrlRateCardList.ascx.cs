using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlRateCardList : System.Web.UI.UserControl
    {
        DataSet dsRatecardData = null;
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindRateCardList();

            }
        }
        #endregion

        #region Private Method
        private DataTable PrepareDataTableForRateCard(DataTable dsToPrepareRateCard, Guid? RateID)
        {
            DataTable dtData = new DataTable();

            DataColumn dc1 = new DataColumn("RoomType");
            DataColumn dc2 = new DataColumn("Deposit");
            DataColumn dc3 = new DataColumn("RackRate");
            DataColumn dc4 = new DataColumn("Taxes");
            DataColumn dc6 = new DataColumn("TotalRackRate");
            DataColumn dc7 = new DataColumn("RoomTypeID");


            dtData.Columns.Add(dc1);
            dtData.Columns.Add(dc2);
            dtData.Columns.Add(dc3);
            dtData.Columns.Add(dc4);
            dtData.Columns.Add("Total", typeof(decimal));
            dtData.Columns.Add(dc6);
            dtData.Columns.Add(dc7);

            foreach (DataRow drtoprepare in dsToPrepareRateCard.Rows)
            {

                decimal dcTax = Convert.ToDecimal("0.000000");
                decimal dcRackRate = Convert.ToDecimal("0.000000");
                decimal dcDeposit = Convert.ToDecimal("0.000000");
                decimal dcTotalRackrate = Convert.ToDecimal("0.000000");

                dcRackRate = Convert.ToDecimal(Convert.ToString(drtoprepare["RackRate"]));
                dcDeposit = Convert.ToDecimal(Convert.ToString(drtoprepare["DepositAmount"]));
                dcTotalRackrate = Convert.ToDecimal(Convert.ToString(drtoprepare["TotalRackRate"]));

                decimal taxesOfRackRate = Convert.ToDecimal("0.000000");
                string str_RackRate = dcRackRate.ToString().IndexOf('.') > -1 ? dcRackRate.ToString() + "000000" : dcRackRate.ToString() + ".000000";
                decimal dcml_RackRate = Convert.ToDecimal(str_RackRate);

                Guid? acctid = new Guid("AC77361D-6E87-4A59-8866-F479299B4A8A");



                int mindays = 0;

                if (dsRatecardData != null && dsRatecardData.Tables.Count > 0 && dsRatecardData.Tables[0].Rows.Count > 0)
                {
                    DataRow[] dr = dsRatecardData.Tables[0].Select("RateID = '" + Convert.ToString(RateID) + "'");
                    if (dr.Length > 0)
                    {
                        acctid = new Guid(Convert.ToString(dr[0]["AcctID"]));
                        mindays = Convert.ToInt32(Convert.ToString(dr[0]["MinimumDaysRequired"]));
                    }
                }

                taxesOfRackRate += BlockDateRateBLL.CalculateTax(acctid, dcml_RackRate, "CR", null, RateID, 3, null, null, clsSession.PropertyID, clsSession.CompanyID);

                string strDspTax = taxesOfRackRate.ToString().IndexOf('.') > -1 ? taxesOfRackRate.ToString() + "000000" : taxesOfRackRate.ToString() + ".000000";
                decimal dcmlOriginalTax = Convert.ToDecimal(strDspTax) * mindays;
                string strdcmlOriginalTax = dcmlOriginalTax.ToString().IndexOf('.') > -1 ? dcmlOriginalTax.ToString() + "000000" : dcmlOriginalTax.ToString() + ".000000";
                dcmlOriginalTax = Convert.ToDecimal(strdcmlOriginalTax);

                decimal dcDisplayTotal = Convert.ToDecimal("0.000000");
                dcDisplayTotal = Convert.ToDecimal(dcDeposit + dcTotalRackrate + dcmlOriginalTax);
                string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";



                DataRow drToadd = dtData.NewRow();
                drToadd["RoomTypeID"] = Convert.ToString(drtoprepare["RoomTypeID"]);
                drToadd["TotalRackRate"] = Convert.ToString(drtoprepare["TotalRackRate"]);
                drToadd["RoomType"] = Convert.ToString(drtoprepare["RoomTypeName"]);
                drToadd["RackRate"] = Convert.ToString(dcTotalRackrate.ToString().Substring(0, dcTotalRackrate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                drToadd["Deposit"] = Convert.ToString(dcDeposit.ToString().Substring(0, dcDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                drToadd["Taxes"] = Convert.ToString(dcmlOriginalTax.ToString().Substring(0, dcmlOriginalTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                drToadd["Total"] = Convert.ToDecimal(strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                dtData.Rows.Add(drToadd);
            }
            return dtData;
        }

        private void BindRateCardList()
        {
            try
            {
                dsRatecardData = new DataSet();
                bool IsPerRoomRateCardList = false;
                if (Session["IsPerRoomInfoForPrint"] != null)
                {
                    IsPerRoomRateCardList = Convert.ToBoolean(Session["IsPerRoomInfoForPrint"]);
                }
                dsRatecardData = RateCardBLL.GetDashboardRatecardData(clsSession.PropertyID, clsSession.CompanyID, null, IsPerRoomRateCardList);
                if (dsRatecardData.Tables.Count > 0 && dsRatecardData.Tables[0].Rows.Count > 0)
                {
                    dlRateCardList.DataSource = dsRatecardData.Tables[0];
                    dlRateCardList.DataBind();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindRateToPrint()
        {
            try
            {

                dsRatecardData = new DataSet();
                bool IsPerRoomRateCard = false;
                if (Session["IsPerRoomInfoForPrint"] != null)
                {
                    IsPerRoomRateCard = Convert.ToBoolean(Session["IsPerRoomInfoForPrint"]);
                }
                dsRatecardData = RateCardBLL.GetDashboardRatecardData(clsSession.PropertyID, clsSession.CompanyID, null, IsPerRoomRateCard);
                if (dsRatecardData.Tables.Count > 0 && dsRatecardData.Tables[0].Rows.Count > 0)
                {
                    dlToPrint.DataSource = dsRatecardData.Tables[0];
                    dlToPrint.DataBind();

                }
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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Rate Card List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        //private void BindGrid()
        //{
        //    DataTable dtArrival = new DataTable();

        //    DataColumn dc1 = new DataColumn("RateCard");
        //    DataColumn dc2 = new DataColumn("Type");
        //    DataColumn dc3 = new DataColumn("StartDate");
        //    DataColumn dc4 = new DataColumn("EndDate");

        //    dtArrival.Columns.Add(dc1);
        //    dtArrival.Columns.Add(dc2);
        //    dtArrival.Columns.Add(dc3);
        //    dtArrival.Columns.Add(dc4);

        //    DataRow dr1 = dtArrival.NewRow();
        //    dr1["RateCard"] = "VIP Corporate Rate card";
        //    dr1["Type"] = "Weekly";
        //    dr1["StartDate"] = "25-7-2012";
        //    dr1["EndDate"] = "31-7-2012";
        //    dtArrival.Rows.Add(dr1);

        //    DataRow dr2 = dtArrival.NewRow();
        //    dr2["RateCard"] = "Special Room Rate card";
        //    dr2["Type"] = "Daily";
        //    dr2["StartDate"] = "25-7-2012";
        //    dr2["EndDate"] = "25-8-2012";
        //    dtArrival.Rows.Add(dr2);

        //    gvRateCardList.DataSource = dtArrival;
        //    gvRateCardList.DataBind();

        //    BindChildGrid();
        //}

        //public void BindChildGrid()
        //{
        //    foreach (GridViewRow gvi in gvRateCardList.Rows)
        //    {
        //        GridView gvRoomTypeList = (GridView)(gvi.FindControl("gvRoomTypeList"));

        //        DataTable dtData = new DataTable();

        //        DataColumn dc1 = new DataColumn("RoomType");
        //        DataColumn dc2 = new DataColumn("RackRate");
        //        DataColumn dc3 = new DataColumn("Tax");
        //        DataColumn dc4 = new DataColumn("Services");
        //        DataColumn dc5 = new DataColumn("Total");

        //        dtData.Columns.Add(dc1);
        //        dtData.Columns.Add(dc2);
        //        dtData.Columns.Add(dc3);
        //        dtData.Columns.Add(dc4);
        //        dtData.Columns.Add(dc5);

        //        DataRow dr1 = dtData.NewRow();
        //        dr1["RoomType"] = "Standard Non A/c - Double Share";
        //        dr1["RackRate"] = "1500.00";
        //        dr1["Tax"] = "200.00";
        //        dr1["Services"] = "0.00";
        //        dr1["Total"] = "1700.00";
        //        dtData.Rows.Add(dr1);

        //        DataRow dr2 = dtData.NewRow();
        //        dr2["RoomType"] = "Superior A/c - Queen Bed";
        //        dr2["RackRate"] = "1200.00";
        //        dr2["Tax"] = "150.00";
        //        dr2["Services"] = "0.00";
        //        dr2["Total"] = "1350.00";
        //        dtData.Rows.Add(dr2);

        //        DataRow dr3 = dtData.NewRow();
        //        dr3["RoomType"] = "Superior Non A/c - Double Share";
        //        dr3["RackRate"] = "1000.00";
        //        dr3["Tax"] = "100.00";
        //        dr3["Services"] = "0.00";
        //        dr3["Total"] = "1100.00";
        //        dtData.Rows.Add(dr3);

        //        DataRow dr4 = dtData.NewRow();
        //        dr4["RoomType"] = "Suite A/c - King Bed";
        //        dr4["RackRate"] = "1700.00";
        //        dr4["Tax"] = "100.00";
        //        dr4["Services"] = "0.00";
        //        dr4["Total"] = "1800.00";
        //        dtData.Rows.Add(dr4);

        //        gvRoomTypeList.DataSource = dtData;
        //        gvRoomTypeList.DataBind();
        //    }
        //}

        #endregion Private Method

        #region Grid Event

        protected void dlToPrint_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (dsRatecardData.Tables.Count > 1 && dsRatecardData.Tables[4] != null && dsRatecardData.Tables[4].Rows.Count > 0)
                    {

                        Label lblRateIDToFilter = (Label)e.Item.FindControl("lblRateId");
                        GridView gvRateCardList = (GridView)e.Item.FindControl("gvRoomTypeList");
                        DataView dvForRateCardList = new DataView(dsRatecardData.Tables[4]);
                        dvForRateCardList.RowFilter = "RateID = '" + lblRateIDToFilter.Text + "'";
                        DataView dvForGrid = new DataView(PrepareDataTableForRateCard(dvForRateCardList.ToTable(), new Guid(lblRateIDToFilter.Text)));
                        dvForGrid.Sort = "Total";
                        gvRateCardList.DataSource = dvForGrid;
                        gvRateCardList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void dlRateCardList_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (dsRatecardData.Tables.Count > 1 && dsRatecardData.Tables[4] != null && dsRatecardData.Tables[4].Rows.Count > 0)
                    {

                        Label lblRateIDToFilter = (Label)e.Item.FindControl("lblRateId");
                        GridView gvRateCardList = (GridView)e.Item.FindControl("gvRoomTypeList");
                        DataView dvForRateCardList = new DataView(dsRatecardData.Tables[4]);
                        dvForRateCardList.RowFilter = "RateID = '" + lblRateIDToFilter.Text + "'";
                        DataView dvForGrid = new DataView(PrepareDataTableForRateCard(dvForRateCardList.ToTable(), new Guid(lblRateIDToFilter.Text)));
                        dvForGrid.Sort = "Total";
                        gvRateCardList.DataSource = dvForGrid;
                        gvRateCardList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //protected void gvAvailability_OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        GridView gvInnerGrid = (GridView)e.Row.FindControl("gvInnerGridGRList");

        //        DataTable dtTableInnderGrid = new DataTable();

        //        DataColumn dc1 = new DataColumn("RoomType");
        //        DataColumn dc2 = new DataColumn("AVL");
        //        DataColumn dc3 = new DataColumn("ENQ");
        //        DataColumn dc4 = new DataColumn("BLK");


        //        dtTableInnderGrid.Columns.Add(dc1);
        //        dtTableInnderGrid.Columns.Add(dc2);
        //        dtTableInnderGrid.Columns.Add(dc3);
        //        dtTableInnderGrid.Columns.Add(dc4);

        //        int i = Convert.ToInt32(e.Row.RowIndex);

        //        if (i == 0)
        //        {
        //            DataRow dr1 = dtTableInnderGrid.NewRow();
        //            dr1["RoomType"] = "Superior A/c - Queen Bed";
        //            dr1["AVL"] = "2";
        //            dr1["ENQ"] = "0";
        //            dr1["BLK"] = "0";
        //            dtTableInnderGrid.Rows.Add(dr1);
        //        }
        //        else
        //        {

        //            DataRow dr2 = dtTableInnderGrid.NewRow();
        //            dr2["RoomType"] = "Standard Non A/c - Double Share";
        //            dr2["AVL"] = "4";
        //            dr2["ENQ"] = "0";
        //            dr2["BLK"] = "1";
        //            dtTableInnderGrid.Rows.Add(dr2);
        //        }
        //        gvInnerGrid.DataSource = dtTableInnderGrid;
        //        gvInnerGrid.DataBind();
        //    }
        //}
        #endregion
        #region Control Event
        protected void btnPritnRatecardlist_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/Reservation/RatecardPrint.aspx");
            //BindRateToPrint();
            //mpeRateCardPrint.Show();
        }
        #endregion Control Event
    }
}