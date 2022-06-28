using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Dashboard
{
    public partial class CtrlCommonRatecardDashboard : System.Web.UI.UserControl
    {
        DataSet dsRatecardData = null;

        public bool IsPerRoomForFilter
        {
            get
            {
                return ViewState["IsPerRoomForFilter"] != null ? Convert.ToBoolean(ViewState["IsPerRoomForFilter"]) : false;
            }
            set
            {
                ViewState["IsPerRoomForFilter"] = value;
            }
        }

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRateCardData();
            }
        }

        #endregion Page Load

        #region Private Method
        private DataTable PrepareDataTableForRateCard(DataTable dsToPrepareRateCard)
        {
            DataTable dtData = new DataTable();

            DataColumn dc1 = new DataColumn("RoomType");
            DataColumn dc2 = new DataColumn("Deposit");
            DataColumn dc3 = new DataColumn("RackRate");
            DataColumn dc4 = new DataColumn("Taxes");
            DataColumn dc6 = new DataColumn("TotalRackRate");
            DataColumn dc7 = new DataColumn("RoomTypeID");
            DataColumn dc8 = new DataColumn("IsPerRoom");


            dtData.Columns.Add(dc1);
            dtData.Columns.Add(dc2);
            dtData.Columns.Add(dc3);
            dtData.Columns.Add(dc4);
            dtData.Columns.Add("Total", typeof(decimal));
            dtData.Columns.Add(dc6);
            dtData.Columns.Add(dc7);
            dtData.Columns.Add(dc8);

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

                Guid? RateID = null;
                if (rblRatecardTyep.Items.Count > 0)
                    RateID = new Guid(rblRatecardTyep.SelectedValue);

                if (RateID == null)
                {
                    rblRatecardTyep.SelectedIndex = 0;
                    RateID = new Guid(rblRatecardTyep.SelectedValue);
                }

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
                if (Convert.ToBoolean(drtoprepare["IsPerRoom"]) == true)
                {
                    drToadd["IsPerRoom"] = 1;
                }
                else
                {
                    drToadd["IsPerRoom"] = 0;
                }

                dtData.Rows.Add(drToadd);
            }
            //EnumerableRowCollection<DataRow> query = from order in dtData.AsEnumerable()
            //                             orderby order.Field<string>("Total")
            //                             select order;

            //DataView view = query.AsDataView();


            //DataTable dtSortedTable = dtData.AsEnumerable()
            //    .OrderBy(row => row.Field<decimal>("Total"))
            //     .CopyToDataTable();
            return dtData;
        }
        public void BindRateCardData()
        {
            try
            {
                Guid? RateID = null;
                if (rblRatecardTyep.Items.Count > 0)
                {
                    RateID = new Guid(rblRatecardTyep.SelectedValue);
                }
                dsRatecardData = new DataSet();
                dsRatecardData = RateCardBLL.GetDashboardRatecardData(clsSession.PropertyID, clsSession.CompanyID, RateID, chkIsFullRoom.Checked);
                if (dsRatecardData.Tables.Count > 0 && dsRatecardData.Tables[0].Rows.Count > 0)
                {

                    //DataView dvForIsPerRoomRateCard;
                    //if (chkIsFullRoom.Checked)
                    //{
                    //    dvForIsPerRoomRateCard = new DataView(dsRatecardData.Tables[0]);
                    //    dvForIsPerRoomRateCard.RowFilter = "IsPerRoom = 1";
                    //}
                    //else
                    //{
                    //    dvForIsPerRoomRateCard = new DataView(dsRatecardData.Tables[0]);
                    //    dvForIsPerRoomRateCard.RowFilter = "(IsPerRoom = 0 Or IsPerRoom IS NULL)";
                    //}
                    rblRatecardTyep.DataSource = dsRatecardData.Tables[0];
                    rblRatecardTyep.DataTextField = "DisplayMinimumDays";
                    rblRatecardTyep.DataValueField = "RateID";
                    rblRatecardTyep.DataBind();

                    if (RateID == null)
                    {
                        rblRatecardTyep.SelectedIndex = 0;
                    }
                    else
                    {
                        rblRatecardTyep.SelectedValue = Convert.ToString(RateID);
                    }
                    if (dsRatecardData.Tables.Count > 1 && dsRatecardData.Tables[1] != null && dsRatecardData.Tables[1].Rows.Count > 0)
                    {
                        //gvRoomTypeList.DataSource = dsRatecardData.Tables[1];
                        DataView dvForGrid = new DataView(PrepareDataTableForRateCard(dsRatecardData.Tables[1]));
                        //if (chkIsFullRoom.Checked)
                        //{
                        //    dvForGrid.RowFilter = "IsPerRoom = 1";
                        //}
                        //else
                        //{
                        //    dvForGrid.RowFilter = "(IsPerRoom = 0 Or IsPerRoom IS NULL)";
                        //}
                        dvForGrid.Sort = "Total";
                        gvRoomTypeList.DataSource = dvForGrid;
                        gvRoomTypeList.DataBind();
                    }
                    else
                    {
                        gvRoomTypeList.DataSource = null;
                        gvRoomTypeList.DataBind();
                    }
                }
                else
                {
                    rblRatecardTyep.DataSource = null;
                    rblRatecardTyep.DataBind();

                    gvRoomTypeList.DataSource = null;
                    gvRoomTypeList.DataBind();

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Private Method

        #region Control Event


        #endregion

        #region Grid Event

        protected void gvRateCardList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("RATECARD"))
                {
                    //mpeRateCard.Show();

                    if (Convert.ToString(e.CommandArgument) == "Corporate")
                    {
                        DataTable dtData = new DataTable();

                        DataColumn dc1 = new DataColumn("RoomType");
                        DataColumn dc2 = new DataColumn("RackRate");
                        DataColumn dc3 = new DataColumn("Tax");
                        DataColumn dc4 = new DataColumn("Services");
                        DataColumn dc5 = new DataColumn("Total");

                        dtData.Columns.Add(dc1);
                        dtData.Columns.Add(dc2);
                        dtData.Columns.Add(dc3);
                        dtData.Columns.Add(dc4);
                        dtData.Columns.Add(dc5);


                        DataRow dr1 = dtData.NewRow();
                        dr1["RoomType"] = "Standard Non A/c - Double Share";
                        dr1["RackRate"] = "2500.00";
                        dr1["Tax"] = "250.00";
                        dr1["Services"] = "0.00";
                        dr1["Total"] = "2750.00";
                        dtData.Rows.Add(dr1);

                        DataRow dr2 = dtData.NewRow();
                        dr2["RoomType"] = "Superior A/c - Queen Bed";
                        dr2["RackRate"] = "2000.00";
                        dr2["Tax"] = "200.00";
                        dr2["Services"] = "0.00";
                        dr2["Total"] = "2200.00";
                        dtData.Rows.Add(dr2);

                        DataRow dr3 = dtData.NewRow();
                        dr3["RoomType"] = "Superior Non A/c - Double Share";
                        dr3["RackRate"] = "1500.00";
                        dr3["Tax"] = "150.00";
                        dr3["Services"] = "0.00";
                        dr3["Total"] = "1650.00";
                        dtData.Rows.Add(dr3);

                        DataRow dr4 = dtData.NewRow();
                        dr4["RoomType"] = "Suite A/c - King Bed";
                        dr4["RackRate"] = "1500.00";
                        dr4["Tax"] = "150.00";
                        dr4["Services"] = "0.00";
                        dr4["Total"] = "1650.00";
                        dtData.Rows.Add(dr4);

                        gvRoomTypeList.DataSource = dtData;
                        gvRoomTypeList.DataBind();
                    }
                    else if (Convert.ToString(e.CommandArgument) == "Room")
                    {
                        DataTable dtData = new DataTable();

                        DataColumn dc1 = new DataColumn("RoomType");
                        DataColumn dc2 = new DataColumn("RackRate");
                        DataColumn dc3 = new DataColumn("Tax");
                        DataColumn dc4 = new DataColumn("Services");
                        DataColumn dc5 = new DataColumn("Total");

                        dtData.Columns.Add(dc1);
                        dtData.Columns.Add(dc2);
                        dtData.Columns.Add(dc3);
                        dtData.Columns.Add(dc4);
                        dtData.Columns.Add(dc5);

                        DataRow dr1 = dtData.NewRow();
                        dr1["RoomType"] = "Suite - King Bed";
                        dr1["RackRate"] = "2500.00";
                        dr1["Tax"] = "250.00";
                        dr1["Services"] = "0.00";
                        dr1["Total"] = "2750.00";
                        dtData.Rows.Add(dr1);

                        DataRow dr2 = dtData.NewRow();
                        dr2["RoomType"] = "Standard";
                        dr2["RackRate"] = "2000.00";
                        dr2["Tax"] = "200.00";
                        dr2["Services"] = "0.00";
                        dr2["Total"] = "2200.00";
                        dtData.Rows.Add(dr2);

                        DataRow dr3 = dtData.NewRow();
                        dr3["RoomType"] = "Suite - King Bed";
                        dr3["RackRate"] = "1500.00";
                        dr3["Tax"] = "150.00";
                        dr3["Services"] = "0.00";
                        dr3["Total"] = "1650.00";
                        dtData.Rows.Add(dr3);

                        gvRoomTypeList.DataSource = dtData;
                        gvRoomTypeList.DataBind();
                    }
                    else if (Convert.ToString(e.CommandArgument) == "RateCardRoomType")
                    {
                        mpeRoomTypeDetail.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomTypeList_OnCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("ROOMTYPE"))
                {
                    mpeRoomTypeDetail.Show();

                    string strArge = Convert.ToString(e.CommandArgument);
                    string[] strData = strArge.Split(',');

                    litPopupHrdRoomType.Text = Convert.ToString(strData[1]);

                    DataSet dsServicesData = RateCardBLL.GetDashboardServicesData(new Guid(rblRatecardTyep.SelectedValue), new Guid(Convert.ToString(strData[0])));

                    if (dsServicesData.Tables.Count > 0 && dsServicesData.Tables[0].Rows.Count > 0)
                    {
                        gvComplimentoryServices.DataSource = dsServicesData.Tables[0];
                        gvComplimentoryServices.DataBind();
                    }
                    else
                    {
                        gvComplimentoryServices.DataSource = null;
                        gvComplimentoryServices.DataBind();
                    }

                    if (dsServicesData.Tables.Count > 0 && dsServicesData.Tables[1].Rows.Count > 0)
                    {
                        gvRoomAmenities.DataSource = dsServicesData.Tables[1];
                        gvRoomAmenities.DataBind();
                    }
                    else
                    {
                        gvRoomAmenities.DataSource = null;
                        gvRoomAmenities.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomTypeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    Label lblGvTax = (Label)e.Row.FindControl("lblGvTax");
                //    Label lblGvTotal = (Label)e.Row.FindControl("lblGvTotal");
                //    Label lblGvDepositAmount = (Label)e.Row.FindControl("lblGvDepositAmount");
                //    Label lblGvTotalRackRate = (Label)e.Row.FindControl("lblGvTotalRackRate");

                //    decimal dcTax = Convert.ToDecimal("0.000000");
                //    decimal dcRackRate = Convert.ToDecimal("0.000000");
                //    decimal dcDeposit = Convert.ToDecimal("0.000000");
                //    decimal dcTotalRackrate = Convert.ToDecimal("0.000000");

                //    dcRackRate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["RackRate"]));
                //    dcDeposit = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["DepositAmount"]));
                //    dcTotalRackrate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["TotalRackRate"]));

                //    decimal taxesOfRackRate = Convert.ToDecimal("0.000000");
                //    string str_RackRate = dcRackRate.ToString().IndexOf('.') > -1 ? dcRackRate.ToString() + "000000" : dcRackRate.ToString() + ".000000";
                //    decimal dcml_RackRate = Convert.ToDecimal(str_RackRate);

                //    Guid? acctid = new Guid("AC77361D-6E87-4A59-8866-F479299B4A8A");

                //    Guid? RateID = null;
                //    if (rblRatecardTyep.Items.Count > 0)
                //        RateID = new Guid(rblRatecardTyep.SelectedValue);

                //    if (RateID == null)
                //    {
                //        rblRatecardTyep.SelectedIndex = 0;
                //        RateID = new Guid(rblRatecardTyep.SelectedValue);
                //    }

                //    int mindays = 0;

                //    if (dsRatecardData != null && dsRatecardData.Tables.Count > 0 && dsRatecardData.Tables[0].Rows.Count > 0)
                //    {
                //        DataRow[] dr = dsRatecardData.Tables[0].Select("RateID = '" + Convert.ToString(RateID) + "'");
                //        if (dr.Length > 0)
                //        {
                //            acctid = new Guid(Convert.ToString(dr[0]["AcctID"]));
                //            mindays = Convert.ToInt32(Convert.ToString(dr[0]["MinimumDaysRequired"]));
                //        }
                //    }

                //    taxesOfRackRate += BlockDateRateBLL.CalculateTax(acctid, dcml_RackRate, "CR", null, RateID, 3, null, null, clsSession.PropertyID, clsSession.CompanyID);

                //    string strDspTax = taxesOfRackRate.ToString().IndexOf('.') > -1 ? taxesOfRackRate.ToString() + "000000" : taxesOfRackRate.ToString() + ".000000";
                //    decimal dcmlOriginalTax = Convert.ToDecimal(strDspTax) * mindays;
                //    string strdcmlOriginalTax = dcmlOriginalTax.ToString().IndexOf('.') > -1 ? dcmlOriginalTax.ToString() + "000000" : dcmlOriginalTax.ToString() + ".000000";
                //    dcmlOriginalTax = Convert.ToDecimal(strdcmlOriginalTax);
                //    //if (dsRatecardData != null && dsRatecardData.Tables.Count > 2 && dsRatecardData.Tables[2] != null && dsRatecardData.Tables[2].Rows.Count > 0)
                //    //{

                //    //    for (int i = 0; i < dsRatecardData.Tables[2].Rows.Count; i++)
                //    //    {
                //    //        //decimal dcTax = Convert.ToDecimal("0.000000");
                //    //        //decimal dcRackRate = Convert.ToDecimal("0.000000");
                //    //        //decimal dcDeposit = Convert.ToDecimal("0.000000");
                //    //        //decimal dcTotalRackrate = Convert.ToDecimal("0.000000");

                //    //        if (dsRatecardData.Tables.Count > 3 && dsRatecardData.Tables[3] != null && dsRatecardData.Tables[3].Rows.Count > 0)
                //    //        {
                //    //            //dcRackRate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["RackRate"]));
                //    //            //dcDeposit = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["DepositAmount"]));
                //    //            //dcTotalRackrate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["TotalRackRate"]));

                //    //            DataRow[] drSelectTax = dsRatecardData.Tables[3].Select("TaxID = '" + Convert.ToString(dsRatecardData.Tables[2].Rows[i]["TaxID"]) + "' and '" + dcRackRate + "' >= MinAmount and '" + dcRackRate + "' <= MaxAmount");

                //    //            if (drSelectTax.Length > 0)
                //    //            {
                //    //                string strRate = Convert.ToString(drSelectTax[0]["TaxRate"]);
                //    //                string strIsFlat = Convert.ToString(drSelectTax[0]["IsTaxFlat"]);

                //    //                if (strRate != "" && strIsFlat != "")
                //    //                {
                //    //                    if (Convert.ToBoolean(strIsFlat) == true)
                //    //                    {
                //    //                        dcTax += Convert.ToDecimal(strRate);
                //    //                    }
                //    //                    else if (Convert.ToBoolean(strIsFlat) == false)
                //    //                    {
                //    //                        decimal dcpercentage = Convert.ToDecimal(strRate);
                //    //                        ////dcTax += Convert.ToDecimal((dcRackRate * dcpercentage) / 100);
                //    //                        dcTax += Convert.ToDecimal((dcTotalRackrate * dcpercentage) / 100);
                //    //                    }
                //    //                }
                //    //            }
                //    //            else
                //    //                dcTax = Convert.ToDecimal("0.000000");
                //    //        }
                //    //        else
                //    //            dcTax = Convert.ToDecimal("0.000000");
                //    //    }
                //    //}

                //    lblGvTotalRackRate.Text = Convert.ToString(dcTotalRackrate.ToString().Substring(0, dcTotalRackrate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                //    lblGvDepositAmount.Text = Convert.ToString(dcDeposit.ToString().Substring(0, dcDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                //    ////lblGvTax.Text = Convert.ToString(dcTax.ToString().Substring(0, dcTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                //    lblGvTax.Text = Convert.ToString(dcmlOriginalTax.ToString().Substring(0, dcmlOriginalTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                //    decimal dcDisplayTotal = Convert.ToDecimal("0.000000");
                //    dcDisplayTotal = Convert.ToDecimal(dcDeposit + dcTotalRackrate + dcmlOriginalTax);
                //    string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";
                //    lblGvTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                //}
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Radio Button Event

        protected void rblRatecardTyep_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRateCardData();
        }
        protected void chkIsFullRoom_CheckChanged(object sender, EventArgs e)
        {
            rblRatecardTyep.Items.Clear();
            Session["IsPerRoomInfoForPrint"] = chkIsFullRoom.Checked;
            BindRateCardData();
        }
        #endregion Radio Button Event
    }
}