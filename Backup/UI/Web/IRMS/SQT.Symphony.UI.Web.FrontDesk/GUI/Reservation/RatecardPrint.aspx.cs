using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class RatecardPrint : System.Web.UI.Page
    {
        DataSet dsRatecardData = null;
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyAddress();
                BindRateCardList();

            }
        }
        #endregion

        #region Private Method
        private void BindPropertyAddress()
        {
            try
            {
                DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
                lblPropertyaddress.Text = "";
                if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
                {
                    lblPropertyaddress.Text = dsPropertyAddress.Tables[0].Rows[0]["FullAddress"].ToString();
                }
                else
                {
                    lblPropertyaddress.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private DataTable PrepareDataTableForRateCard(DataTable dsToPrepareRateCard, Guid? RateID)
        {
            //try
            //{
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
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
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
        #endregion Private Method

        #region Grid Event

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
        #endregion
        #region Control Event
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/RateCardList.aspx");
        }
        #endregion Control Event
    }
}