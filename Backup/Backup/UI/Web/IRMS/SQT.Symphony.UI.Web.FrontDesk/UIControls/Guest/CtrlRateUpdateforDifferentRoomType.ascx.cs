using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlRateUpdateforDifferentRoomType : System.Web.UI.UserControl
    {
        #region Property And Variable

        public Guid ResID
        {
            get
            {
                return ViewState["ResID"] != null ? new Guid(Convert.ToString(ViewState["ResID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResID"] = value;
            }
        }

        public string StandardCheckInTime
        {
            get
            {
                return ViewState["StandardCheckInTime"] != null ? Convert.ToString(ViewState["StandardCheckInTime"]) : string.Empty;
            }
            set
            {
                ViewState["StandardCheckInTime"] = value;
            }
        }

        public string StandardCheckOutTime
        {
            get
            {
                return ViewState["StandardCheckOutTime"] != null ? Convert.ToString(ViewState["StandardCheckOutTime"]) : string.Empty;
            }
            set
            {
                ViewState["StandardCheckOutTime"] = value;
            }
        }
        public string NewRoomTypeName
        {
            get
            {
                return ViewState["NewRoomTypeName"] != null ? Convert.ToString(ViewState["NewRoomTypeName"]) : string.Empty;
            }
            set
            {
                ViewState["NewRoomTypeName"] = value;
            }
        }
        public string GuestNameToPrint
        {
            get
            {
                return ViewState["GuestNameToPrint"] != null ? Convert.ToString(ViewState["GuestNameToPrint"]) : string.Empty;
            }
            set
            {
                ViewState["GuestNameToPrint"] = value;
            }
        }
        public string NewRoomTypeNo
        {
            get
            {
                return ViewState["NewRoomTypeNo"] != null ? Convert.ToString(ViewState["NewRoomTypeNo"]) : string.Empty;
            }
            set
            {
                ViewState["NewRoomTypeNo"] = value;
            }
        }

        public string OldRoomTypeNo
        {
            get
            {
                return ViewState["OldRoomTypeNo"] != null ? Convert.ToString(ViewState["OldRoomTypeNo"]) : string.Empty;
            }
            set
            {
                ViewState["OldRoomTypeNo"] = value;
            }
        }
        public string OldRoomType
        {
            get
            {
                return ViewState["OldRoomType"] != null ? Convert.ToString(ViewState["OldRoomType"]) : string.Empty;
            }
            set
            {
                ViewState["OldRoomType"] = value;
            }
        }


        public Guid New_RoomTypeID
        {
            get
            {
                return ViewState["New_RoomTypeID"] != null ? new Guid(Convert.ToString(ViewState["New_RoomTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["New_RoomTypeID"] = value;
            }
        }

        public Guid New_RateID
        {
            get
            {
                return ViewState["New_RateID"] != null ? new Guid(Convert.ToString(ViewState["New_RateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["New_RateID"] = value;
            }
        }

        public DateTime New_CheckOutDate
        {
            get
            {
                return ViewState["New_CheckOutDate"] != null ? Convert.ToDateTime(ViewState["New_CheckOutDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["New_CheckOutDate"] = value;
            }
        }
        public DateTime New_CheckInDate
        {
            get
            {
                return ViewState["New_CheckInDate"] != null ? Convert.ToDateTime(ViewState["New_CheckInDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["New_CheckInDate"] = value;
            }
        }
        public ModalPopupExtender ucmpeRate
        {
            get { return this.mpeRate; }
        }

        public event EventHandler btnUpdatesRateCallParent_Click;

        public decimal dcFtTotal = Convert.ToDecimal("0.000000");
        decimal dcmlOldAmountTotal = Convert.ToDecimal("0.00000");
        decimal dcmlPreviousTotal = Convert.ToDecimal("0.00000");
        decimal dcmlNewAmtToal = Convert.ToDecimal("0.00000");
        decimal dcmlBalanceDueRoomRent = Convert.ToDecimal("0.00000");
        decimal dcmlBalanceDueDeposit = Convert.ToDecimal("0.00000");
        decimal dcmlNetBalanceToDisplay = Convert.ToDecimal("0.00000");
        decimal dcmlDiffAmountTotal = Convert.ToDecimal("0.00000");

        public Literal uclitDspReservationNo
        {
            get { return this.litDspReservationNo; }
        }

        public Literal uclitDspRoomType
        {
            get { return this.litDspRoomType; }
        }

        public string strOpenMode
        {
            get
            {
                return ViewState["strOpenMode"] != null ? Convert.ToString(ViewState["strOpenMode"]) : string.Empty;
            }
            set
            {
                ViewState["strOpenMode"] = value;
            }
        }

        #endregion Property And Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBlockDateRateGrid();
            }
        }

        #endregion Page Load

        #region Private Method

        public void BindBlockDateRateGrid()
        {
            try
            {
                if (this.ResID != Guid.Empty)
                {
                    hdnReservationID.Value = Convert.ToString(this.ResID);
                    List<BlockDateRate> lstBlockDateRate_New = new List<BlockDateRate>();
                    List<ResServiceList> lstResServiceList = new List<ResServiceList>();
                    string strStandardCheckInTime = string.Empty;
                    string strStandardCheckOutTime = string.Empty;

                    DateTime dtCheckOutDate = New_CheckOutDate;
                    DateTime dtStartDateToGetOldAmout = DateTime.Now.Date;

                    lstBlockDateRate_New = clsBlockDateRate.GetCal_RoomWorksheet(DateTime.Now.Date, dtCheckOutDate.Date, New_RoomTypeID, New_RateID, null, 1, 0, string.Empty, ref lstResServiceList, ref strStandardCheckInTime, ref strStandardCheckOutTime, this.ResID, "EDIT");

                    if (lstBlockDateRate_New.Count > 0)
                    {
                        DataSet dsUnPostedCharges = ReservationBLL.GetAllUnpostedCharges(this.ResID, null, false);
                        if (dsUnPostedCharges != null && dsUnPostedCharges.Tables[0].Rows.Count > 0)
                        {
                            DataRow[] drSelected = dsUnPostedCharges.Tables[0].Select("ResBlockDateRateID IS NOT NULL and ServiceDate = '" + DateTime.Today.ToString("MM-dd-yyyy") + "'");

                            if (drSelected != null && drSelected.Length == 0)
                            {
                                for (int i = 0; i < lstBlockDateRate_New.Count; i++)
                                {
                                    if (Convert.ToDateTime(lstBlockDateRate_New[i].BlockDate).ToString("MM-dd-yyyy") == DateTime.Today.ToString("MM-dd-yyyy"))
                                    {
                                        lstBlockDateRate_New.RemoveAt(i);
                                        dtStartDateToGetOldAmout = dtStartDateToGetOldAmout.AddDays(1);
                                        break;
                                    }
                                }
                            }
                        }

                        btnUpdate.Visible = true;
                        gvRateUpdateForRoomType.DataSource = lstBlockDateRate_New;
                        gvRateUpdateForRoomType.DataBind();
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                        gvRateUpdateForRoomType.DataSource = null;
                        gvRateUpdateForRoomType.DataBind();
                    }

                    Session["lstMoveRoomBlockDateRate"] = lstBlockDateRate_New;
                    Session["lstMoveRoomResService"] = lstResServiceList;
                    dcmlOldAmountTotal = Convert.ToDecimal("0.00000");
                    dcmlDiffAmountTotal = Convert.ToDecimal("0.00000");
                    litINRRs.Text = "New Amount Rs. ";
                    litTotal.Text = dcFtTotal.ToString().Substring(0, dcFtTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    DataSet dsForUpgradeDowngradedata = BlockDateRateBLL.GetData4UpgradeDowngrade(this.ResID, this.New_RoomTypeID);
                    if (dsForUpgradeDowngradedata != null && dsForUpgradeDowngradedata.Tables.Count > 0 && dsForUpgradeDowngradedata.Tables[0].Rows.Count > 0)
                    {
                        dcmlPreviousTotal = Convert.ToDecimal("0.00");
                        //dcFtTotal.ToString().Substring(0, dcFtTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        litDispPreviousTotalDeposit.Text = Convert.ToString(dsForUpgradeDowngradedata.Tables[0].Rows[0]["OldDepositAmount"]).Substring(0, Convert.ToString(dsForUpgradeDowngradedata.Tables[0].Rows[0]["OldDepositAmount"]).LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        litDispNewTotalDeposit.Text = Convert.ToString(dsForUpgradeDowngradedata.Tables[0].Rows[0]["NewDepositAmount"]).Substring(0, Convert.ToString(dsForUpgradeDowngradedata.Tables[0].Rows[0]["NewDepositAmount"]).LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        dcmlPreviousTotal = Convert.ToDecimal(Convert.ToDecimal(dsForUpgradeDowngradedata.Tables[1].Rows[0]["Balance"]) + Convert.ToDecimal(dsForUpgradeDowngradedata.Tables[0].Rows[0]["OldDepositAmount"]));


                        //litDispLastTotalPrevious.Text = Convert.ToString(dcmlPreviousTotal).Substring(0, Convert.ToString(dcmlPreviousTotal).LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        litDispPreviousTotalRent.Text = Convert.ToString(dsForUpgradeDowngradedata.Tables[1].Rows[0]["Balance"]).Substring(0, Convert.ToString(dsForUpgradeDowngradedata.Tables[1].Rows[0]["Balance"]).LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        litDispNewTotalRent.Text = dcFtTotal.ToString().Substring(0, dcFtTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));


                        dcmlNewAmtToal = dcFtTotal + Convert.ToDecimal(dsForUpgradeDowngradedata.Tables[0].Rows[0]["NewDepositAmount"]);

                        if (Convert.ToDecimal(litDispPreviousTotalRent.Text) > Convert.ToDecimal(litDispNewTotalRent.Text) || Convert.ToDecimal(litDispPreviousTotalRent.Text) == Convert.ToDecimal(litDispNewTotalRent.Text))
                        {
                            litDispRoomBalanceDueCredit.Text = "";
                            litRoomBalanceDue.Text = "Balance(Credit)";
                            dcmlBalanceDueRoomRent = Convert.ToDecimal(litDispPreviousTotalRent.Text) - Convert.ToDecimal(litDispNewTotalRent.Text);
                            litDispRoomBalanceDueCredit.Text = dcmlBalanceDueRoomRent.ToString().Substring(0, dcmlBalanceDueRoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            litRoomRentDue.Text = "Room Rent(Credit)";
                            litDispRoomRentDue.Text = dcmlBalanceDueRoomRent.ToString().Substring(0, dcmlBalanceDueRoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            litNetBalance.Text = "Net Balance(Credit)";
                        }
                        else
                        {
                            litDispRoomBalanceDueCredit.Text = "";
                            dcmlBalanceDueRoomRent = Convert.ToDecimal(litDispNewTotalRent.Text) - Convert.ToDecimal(litDispPreviousTotalRent.Text);
                            litDispRoomBalanceDueCredit.Text = dcmlBalanceDueRoomRent.ToString().Substring(0, dcmlBalanceDueRoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            litRoomBalanceDue.Text = "Balance(Due)";
                            litRoomRentDue.Text = "Room Rent(Due)";
                            litDispRoomRentDue.Text = dcmlBalanceDueRoomRent.ToString().Substring(0, dcmlBalanceDueRoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            litNetBalance.Text = "Net Balance(Due)";
                        }


                        if (Convert.ToDecimal(litDispPreviousTotalDeposit.Text) > Convert.ToDecimal(litDispNewTotalDeposit.Text) || Convert.ToDecimal(litDispPreviousTotalDeposit.Text) == Convert.ToDecimal(litDispNewTotalDeposit.Text))
                        {
                            litDispDepositBalanceDueCredit.Text = "";
                            litDepositBalanceDue.Text = "Balance(Credit)";
                            dcmlBalanceDueDeposit = Convert.ToDecimal(litDispPreviousTotalDeposit.Text) - Convert.ToDecimal(litDispNewTotalDeposit.Text);
                            litDispDepositBalanceDueCredit.Text = dcmlBalanceDueDeposit.ToString().Substring(0, dcmlBalanceDueDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            litDepositDue.Text = "Deposit(Credit)";
                            litDispDepositDue.Text = dcmlBalanceDueDeposit.ToString().Substring(0, dcmlBalanceDueDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else
                        {
                            litDispDepositBalanceDueCredit.Text = "";
                            litDepositBalanceDue.Text = "Balance(Due)";
                            dcmlBalanceDueDeposit = Convert.ToDecimal(litDispNewTotalDeposit.Text) - Convert.ToDecimal(litDispPreviousTotalDeposit.Text);
                            litDispDepositBalanceDueCredit.Text = dcmlBalanceDueDeposit.ToString().Substring(0, dcmlBalanceDueDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            litDepositDue.Text = "Deposit(Due)";
                            litDispDepositDue.Text = dcmlBalanceDueDeposit.ToString().Substring(0, dcmlBalanceDueDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }

                        dcmlNetBalanceToDisplay = Convert.ToDecimal(litDispDepositDue.Text) + Convert.ToDecimal(litDispRoomRentDue.Text);
                        litDispNetBalance.Text = dcmlNetBalanceToDisplay.ToString().Substring(0, dcmlNetBalanceToDisplay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));



                        //litDispLastToalNew.Text = Convert.ToString(dcmlNewAmtToal).Substring(0, Convert.ToString(dcmlNewAmtToal).LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));


                        //if (dcmlPreviousTotal > dcmlNewAmtToal)
                        //{
                        //    litDispBalanceDueCredit.Text = "";
                        //    litBalanceDueCredit.Text = "Balance(Credit) Rs. ";
                        //    dcmlBalanceDueCreidt  = dcmlPreviousTotal - dcmlNewAmtToal;
                        //    litDispBalanceDueCredit.Text = dcmlBalanceDueCreidt.ToString().Substring(0, dcmlBalanceDueCreidt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        //}
                        //else
                        //{
                        //    litDispBalanceDueCredit.Text = "";
                        //    litBalanceDueCredit.Text = "Balance(Due) Rs. ";
                        //    dcmlBalanceDueCreidt = dcmlNewAmtToal - dcmlPreviousTotal;
                        //    litDispBalanceDueCredit.Text = dcmlBalanceDueCreidt.ToString().Substring(0, dcmlBalanceDueCreidt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        //}
                    }

                    DataSet dsForoldAmount = BlockDateRateBLL.GetTotalRoomRateByDatePeriod(this.ResID, dtStartDateToGetOldAmout, dtCheckOutDate.Date, clsSession.PropertyID, clsSession.CompanyID);
                    if (dsForoldAmount != null && dsForoldAmount.Tables.Count > 0 && dsForoldAmount.Tables[0].Rows.Count > 0)
                    {
                        litINROld.Text = "Old Amount Rs. ";
                        dcmlOldAmountTotal = Convert.ToDecimal(dsForoldAmount.Tables[0].Rows[0]["TotalRoomRate"]);
                        litOldTotal.Text = dcmlOldAmountTotal.ToString().Substring(0, dcmlOldAmountTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        //litOldTotal.Text = Convert.ToString(dsForoldAmount.Tables[0].Rows[0]["TotalRoomRate"]).Substring(0, Convert.ToString(dsForoldAmount.Tables[0].Rows[0]["TotalRoomRate"]).LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    if (dcmlOldAmountTotal > dcFtTotal)
                    {
                        litINRBalanceDiff.Text = "Balance(Credit) Rs. ";
                        dcmlDiffAmountTotal = dcmlOldAmountTotal - dcFtTotal;
                        litBalanceDiff.Text = dcmlDiffAmountTotal.ToString().Substring(0, dcmlDiffAmountTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                    {
                        litINRBalanceDiff.Text = "Balance(Due) Rs. ";
                        dcmlDiffAmountTotal = dcFtTotal - dcmlOldAmountTotal;
                        litBalanceDiff.Text = dcmlDiffAmountTotal.ToString().Substring(0, dcmlDiffAmountTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    }

                    //BlockDateRate objBlockDateRate = new BlockDateRate();
                    //objBlockDateRate.ReservationID = this.ResID;

                    //List<BlockDateRate> lstBlockDateRate = null;
                    //lstBlockDateRate = BlockDateRateBLL.GetAll(objBlockDateRate);

                    //if (lstBlockDateRate.Count > 0)
                    //{
                    //    btnUpdate.Visible = true;
                    //    gvRateUpdateForRoomType.DataSource = lstBlockDateRate;
                    //    gvRateUpdateForRoomType.DataBind();
                    //}
                    //else
                    //{
                    //    btnUpdate.Visible = false;
                    //    gvRateUpdateForRoomType.DataSource = null;
                    //    gvRateUpdateForRoomType.DataBind();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Grid Event

        protected void gvResevationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlRMRate = Convert.ToDecimal("0.00000");
                    decimal dcmlTax = Convert.ToDecimal("0.00000");
                    //decimal dcmlDiscount = Convert.ToDecimal("0.00000");
                    decimal dcmlTotal = Convert.ToDecimal("0.00000");

                    Label lblGvRMTypeRMRate = (Label)e.Row.FindControl("lblGvRMTypeRMRate");
                    dcmlRMRate = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RoomRate"));
                    lblGvRMTypeRMRate.Text = dcmlRMRate.ToString().Substring(0, dcmlRMRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvRMTypeTax = (Label)e.Row.FindControl("lblGvRMTypeTax");
                    dcmlTax = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AppliedTax"));

                    if (Convert.ToString(dcmlTax) != "" && dcmlTax > 0)
                        lblGvRMTypeTax.Text = dcmlTax.ToString().Substring(0, dcmlTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    else
                    {
                        lblGvRMTypeTax.Text = "0.00";
                        dcmlTax = Convert.ToDecimal("0.000000");
                    }

                    //Label lblGvRMTypeDiscount = (Label)e.Row.FindControl("lblGvRMTypeDiscount");
                    //dcmlDiscount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DiscountAmt"));

                    //if (Convert.ToString(dcmlDiscount) != "" && dcmlDiscount != null && dcmlDiscount > 0)
                    //    lblGvRMTypeDiscount.Text = dcmlDiscount.ToString().Substring(0, dcmlDiscount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    //else
                    //{
                    //    lblGvRMTypeDiscount.Text = "0.00";
                    //    dcmlDiscount = Convert.ToDecimal("0.000000");
                    //}

                    Label lblGvRMTypeTotal = (Label)e.Row.FindControl("lblGvRMTypeTotal");
                    dcmlTotal = dcmlRMRate + dcmlTax; // +dcmlDiscount;
                    lblGvRMTypeTotal.Text = dcmlTotal.ToString().Substring(0, dcmlTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    dcFtTotal += dcmlTotal;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Grid Event

        #region Control Event
        protected void btnUpgradeVoucherPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtupgradeVoucherToPrint = new DataTable();

                DataColumn dc1 = new DataColumn("GuestName");
                DataColumn dc2 = new DataColumn("BookingNo");
                DataColumn dc4 = new DataColumn("CheckOutDate");
                DataColumn dc5 = new DataColumn("OldRoomNo");
                DataColumn dc6 = new DataColumn("OldRoomType");
                DataColumn dc7 = new DataColumn("NewRoomNo");
                DataColumn dc8 = new DataColumn("NewRoomType");

                DataColumn dc9 = new DataColumn("AvailabelBalance");
                DataColumn dc10 = new DataColumn("PreviousDeposit");
                DataColumn dc11 = new DataColumn("NewRoomRent");
                DataColumn dc12 = new DataColumn("NewDeposit");
                DataColumn dc13 = new DataColumn("RoomRentBalance");
                DataColumn dc14 = new DataColumn("DepositBalance");
                DataColumn dc15 = new DataColumn("NetBalance");
                DataColumn dc16 = new DataColumn("NoofDaysAffected");
                DataColumn dc17 = new DataColumn("CheckInDate");


                dtupgradeVoucherToPrint.Columns.Add(dc1);
                dtupgradeVoucherToPrint.Columns.Add(dc2);
                dtupgradeVoucherToPrint.Columns.Add(dc4);
                dtupgradeVoucherToPrint.Columns.Add(dc5);
                dtupgradeVoucherToPrint.Columns.Add(dc6);
                dtupgradeVoucherToPrint.Columns.Add(dc7);
                dtupgradeVoucherToPrint.Columns.Add(dc9);
                dtupgradeVoucherToPrint.Columns.Add(dc8);
                dtupgradeVoucherToPrint.Columns.Add(dc10);
                dtupgradeVoucherToPrint.Columns.Add(dc11);
                dtupgradeVoucherToPrint.Columns.Add(dc12);
                dtupgradeVoucherToPrint.Columns.Add(dc13);
                dtupgradeVoucherToPrint.Columns.Add(dc14);
                dtupgradeVoucherToPrint.Columns.Add(dc15);
                dtupgradeVoucherToPrint.Columns.Add(dc16);
                dtupgradeVoucherToPrint.Columns.Add(dc17);

                DataRow dr1 = dtupgradeVoucherToPrint.NewRow();
                dr1["GuestName"] = GuestNameToPrint;
                dr1["BookingNo"] = Convert.ToString(litDspReservationNo.Text);
                dr1["CheckOutDate"] = New_CheckOutDate.ToString(clsSession.DateFormat);
                dr1["OldRoomNo"] = OldRoomTypeNo;
                dr1["OldRoomType"] = OldRoomType;
                dr1["NewRoomNo"] = NewRoomTypeNo;
                dr1["NewRoomType"] = NewRoomTypeName;


                dr1["AvailabelBalance"] = litDispPreviousTotalRent.Text;
                dr1["PreviousDeposit"] = litDispPreviousTotalDeposit.Text;
                dr1["NewRoomRent"] = litDispNewTotalRent.Text;
                dr1["NewDeposit"] = litDispNewTotalDeposit.Text;
                dr1["RoomRentBalance"] = litDispRoomBalanceDueCredit.Text;
                dr1["DepositBalance"] = litDispDepositBalanceDueCredit.Text;
                dr1["NetBalance"] = litDispNetBalance.Text;
                dr1["CheckInDate"] = New_CheckInDate.ToString(clsSession.DateFormat);
                dr1["NoofDaysAffected"] = gvRateUpdateForRoomType.Rows.Count;
                dtupgradeVoucherToPrint.Rows.Add(dr1);
                Session["UpgradeVoucherPrintData"] = null;
                Session["UpgradeVoucherPrintData"] = dtupgradeVoucherToPrint;
                mpeRate.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }            
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            strOpenMode = "CONTINEWWITHRATEUPDATE";
            mpeRate.Hide();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            strOpenMode = "CONTINEWWITHOUTRATEUPDATE";
            mpeRate.Hide();
        }

        protected void imgUpgradeCancel_Click(object sender, EventArgs e)
        {
            strOpenMode = "";
            mpeRate.Hide();
        }

        #endregion Control Event
    }
}