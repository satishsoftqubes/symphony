using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Configuration;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlAssignRoom : System.Web.UI.UserControl
    {
        #region Property and Variables

        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }
        public bool IsMessage = false;

        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public Guid RoomTypeID
        {
            get
            {
                return ViewState["RoomTypeID"] != null ? new Guid(Convert.ToString(ViewState["RoomTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomTypeID"] = value;
            }
        }

        public Decimal ResDepositAmount
        {
            get
            {
                return ViewState["ResDepositAmount"] != null ? Convert.ToDecimal(ViewState["ResDepositAmount"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["ResDepositAmount"] = value;
            }
        }

        public Decimal PaidDepositAmount
        {
            get
            {
                return ViewState["PaidDepositAmount"] != null ? Convert.ToDecimal(ViewState["PaidDepositAmount"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["PaidDepositAmount"] = value;
            }
        }
        #endregion  

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                
                BindBreadCrumb();

                mpeAssignRoom.Show();
            }
        }
        #endregion Page Load

        #region Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "AssignRoom.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
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

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Reservation";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Assign Room";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindPaymentDetails()
        {
            try
            {
                decimal RoomRent = Convert.ToDecimal("0.000000");
                decimal Tax = Convert.ToDecimal("0.000000");
                decimal TotalAmount = Convert.ToDecimal("0.000000");
                int NoofDays = 0;
                decimal DepositAmount = Convert.ToDecimal("0.000000");
                decimal PaidDeposit = Convert.ToDecimal("0.000000");
                int InfraServiceCharge = 0;
                int PaidInfraServiceCharge = 0;
                int FoodCharges = 0;
                int PaidFoodCharges = 0;
                int ElectricityCharges = 0;
                int PaidElectricityCharges = 0;
                decimal TotalAmountPayable = Convert.ToDecimal("0.000000");
                decimal AmountToPayCheckInTime = Convert.ToDecimal("0.000000");
                decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                decimal NetAmountToPay = Convert.ToDecimal("0.000000");
                DataTable dtPaidAmountInfo = null;

                //Common function to get payment related all details.
                clsCommon.GetReservationPaymentInfo(this.ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                string strRoomRent, strTax, strTotalAmount, strDepositAmount = "";

                strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                this.ResDepositAmount = DepositAmount;
                this.PaidDepositAmount = PaidDeposit;

                lblDisplayNoOfDays.Text = Convert.ToString(NoofDays);
                lblResTimeRoomRent.Text = Convert.ToString(strRoomRent);
                lblResTimeTax.Text = Convert.ToString(strTax);
                lblInfraServiceCharges.Text = Convert.ToString(InfraServiceCharge) + ".00";

                //Reservation time total charges(Room Rent)
                lblResTimeTotalCharges.Text = Convert.ToString(strTotalAmount);
                //Reservation time total Deposit
                lblResTimeDepositAmount.Text = Convert.ToString(strDepositAmount);

                //Reservation time total Amount payable(Room Rent + Deposit)
                TotalAmountPayable = TotalAmount + DepositAmount;
                lblResTimeTotalPayableAmount.Text = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                //Total Deposit received
                PaidDeposit.ToString().Substring(0, PaidDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                if (TotalAmountPayable >= PaidDeposit)
                {
                    NetAmountToPay = TotalAmountPayable - PaidDeposit;
                    NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }

                //Total payment received (Deposit + other payment)
                lblTotalPaymentReceived.Text = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                //Compare total payable amount and Total received amount for Net amount is Balance or Due.
                if (TotalAmountPayable >= TotalPaymentReceived)
                {
                    NetAmountToPay = TotalAmountPayable - TotalPaymentReceived;
                    lblAmountBalanceOrDueText.Text = "Balance Amount (Due)";
                    lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else
                {
                    NetAmountToPay = TotalPaymentReceived - TotalAmountPayable;
                    lblAmountBalanceOrDueText.Text = "Balance Amount";
                    lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }

                if (dtPaidAmountInfo != null && dtPaidAmountInfo.Rows.Count > 0)
                {
                    gvPaymentList.DataSource = dtPaidAmountInfo;
                    gvPaymentList.DataBind();
                }
                else
                {
                    gvPaymentList.DataSource = null;
                    gvPaymentList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindAvailableRooms()
        {
            DateTime? checkInDate = null;
            DateTime? checkOutDate = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            string dtStandardCheckInTime = "";
            string dtStandardCheckOutTime = "";

            List<ReservationConfig> lstReservation = null;
            ReservationConfig objReservationConfig = new ReservationConfig();
            objReservationConfig.IsActive = true;
            objReservationConfig.CompanyID = clsSession.CompanyID;
            objReservationConfig.PropertyID = clsSession.PropertyID;
            lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);


            if (lstReservation.Count != 0)
            {
                dtStandardCheckInTime = Convert.ToString(lstReservation[0].CheckInTime);
                dtStandardCheckOutTime = Convert.ToString(lstReservation[0].CheckOutTime);
            }

            if (ltrChkPmtCheckInDate.Text.Trim() != string.Empty)
            {
                if (dtStandardCheckInTime != string.Empty)
                {
                    DateTime checkInDateTemp = DateTime.ParseExact(ltrChkPmtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    DateTime dtToSetStdCheckInOutTime = Convert.ToDateTime(dtStandardCheckInTime);
                    checkInDate = new DateTime(checkInDateTemp.Year, checkInDateTemp.Month, Convert.ToInt32(checkInDateTemp.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                }
                else
                    checkInDate = DateTime.ParseExact(ltrChkPmtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            }

            if (ltrChkPmtCheckOutDate.Text.Trim() != string.Empty)
            {
                if (dtStandardCheckOutTime != string.Empty)
                {
                    DateTime CheckOutDateTemp = DateTime.ParseExact(ltrChkPmtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    DateTime dtToSetStdCheckInOutTime = Convert.ToDateTime(dtStandardCheckOutTime);
                    checkOutDate = new DateTime(CheckOutDateTemp.Year, CheckOutDateTemp.Month, Convert.ToInt32(CheckOutDateTemp.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                }
                else
                    checkOutDate = DateTime.ParseExact(ltrChkPmtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            }

            DataSet dsAvailableRooms = ReservationBLL.GetAllVacantRoom(checkInDate, checkOutDate, this.RoomTypeID, false, null, clsSession.PropertyID, clsSession.CompanyID);

            ////Check whether Room Is Available or not Start
            // Get room to sell.
            DataSet dsRoomsToSell = ReservationBLL.ReservationSelectRoomsToSell(this.RoomTypeID, checkInDate, checkOutDate, null, null, clsSession.PropertyID, clsSession.CompanyID);
            DataView rs = new DataView(dsRoomsToSell.Tables[0]);
            rs.RowFilter = "RestStatus_TermID = 28 and RoomID is null";

            int intAvailableRooms = dsAvailableRooms.Tables[0].Rows.Count - rs.Count;

            if (!(intAvailableRooms > 0))
            {
                MessageBox.Show("Room is not available, you can't give confirm reservation.");
                return;
            }
            ////Check whether Room Is Available or not End

            if (dsAvailableRooms != null && dsAvailableRooms.Tables[0].Rows.Count > 0)
            {
                ddlRoomNumber.Items.Clear();
                ddlRoomNumber.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                DataTable dtAvblRooms = dsAvailableRooms.Tables[0];
                for (int i = 0; i < dtAvblRooms.Rows.Count; i++)
                {
                    ddlRoomNumber.Items.Insert(i + 1, new ListItem(clsCommon.GetFormatedRoomNumber(Convert.ToString(dtAvblRooms.Rows[i]["RoomNo"])), Convert.ToString(dtAvblRooms.Rows[i]["RoomID"])));
                }
            }
            else
                ddlRoomNumber.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

        }

        private bool IsWholeRoomIsAvailable(DateTime? checkInDate, DateTime? checkOutDate)
        {
            bool isWholeRommAvailable = true;

            DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, this.RoomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
            DataSet dsRoomIDs = RoomBLL.GetAllRoomIDOfRoomByAnyRoomID(new Guid(ddlRoomNumber.SelectedValue),clsSession.PropertyID);

            if (dsRoomIDs.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsRoomIDs.Tables[0].Rows.Count; i++)
                {
                    DataRow[] drRoomAvbl = dsIsRoomAvbl.Tables[0].Select("RoomID = '" + Convert.ToString(dsRoomIDs.Tables[0].Rows[i]["RoomID"]) + "'");
                    if (drRoomAvbl.Length == 0)
                    {
                        isWholeRommAvailable = false;
                        break;
                    }
                }
            }

            return isWholeRommAvailable;
        }
        #endregion

        #region Control Events

        protected void btnProceedAssignRoom_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet dsReservation = ReservationBLL.SelectReservationDetailByReservationNo("RES#" + txtForPaymentBookingNo.Text.Trim(), txtForPaymentGuestName.Text.Trim());
                if (dsReservation != null && dsReservation.Tables[0].Rows.Count > 0)
                {
                    DataRow drResData = dsReservation.Tables[0].Rows[0];

                    int intReservationStatusTermID = Convert.ToInt32(drResData["RestStatus_TermID"]);
                    if (!(intReservationStatusTermID == 27))
                    {
                        if (intReservationStatusTermID == 28)
                            lblSuccessMessage.Text = "This reservation is already confirmed, you can't proceed for assign room.";
                        if (intReservationStatusTermID == 32)
                            lblSuccessMessage.Text = "This reservation is already checked in, you can't proceed for assign room.";
                        else if (intReservationStatusTermID == 33)
                            lblSuccessMessage.Text = "This reservation is already checked out, you can't proceed for assign room.";
                        else if (intReservationStatusTermID == 34)
                            lblSuccessMessage.Text = "This reservation is already cancelled, you can't proceed for assign room.";
                        else if (intReservationStatusTermID == 29)
                            lblSuccessMessage.Text = "This reservation is in waiting list, you can't proceed for assign room.";
                        else if (intReservationStatusTermID == 35 || intReservationStatusTermID == 36)
                            lblSuccessMessage.Text = "This reservation is in no show list, you can't proceed for assign room.";

                        mpeSuccessMessage.Show();
                        return;
                    }

                    this.ReservationID = new Guid(Convert.ToString(drResData["ReservationID"]));
                    ltrChkPmtReservationNo.Text = Convert.ToString(drResData["ReservationNo"]);
                    ltrChkPmtGuestName.Text = Convert.ToString(drResData["GuestFullName"]);
                    this.RoomTypeID = new Guid(Convert.ToString(drResData["RoomTypeID"]));

                    ltrChkPmtCheckInDate.Text = Convert.ToDateTime(Convert.ToString(drResData["CheckInDate"])).ToString(clsSession.DateFormat);
                    ltrChkPmtCheckOutDate.Text = Convert.ToDateTime(Convert.ToString(drResData["CheckOutDate"])).ToString(clsSession.DateFormat);
                    ltrChkPmtRoomType.Text = Convert.ToString(drResData["RoomTypeName"]);
                    ltrChkPmtRateCard.Text = Convert.ToString(drResData["RateCardName"]);

                    BindPaymentDetails();
                    BindAvailableRooms();

                    mvAssignRoom.ActiveViewIndex = 0;
                }
                else
                {
                    lblSuccessMessage.Text = "No reservation found with given Booking #";
                    mpeSuccessMessage.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void iBtnCacelAssignRoom_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (lblTotalPaymentReceived.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Payment is not done, you can't give confirm reservation.");
                    return;
                }

                if (lblTotalPaymentReceived.Text.Trim() != string.Empty && Convert.ToDecimal(lblTotalPaymentReceived.Text.Trim()) < Convert.ToDecimal(lblResTimeDepositAmount.Text.Trim()))
                {
                    MessageBox.Show("Paid amout is less than Min. Amount for Confirm Reservation, you can't give confirm reservation.");
                    return;
                }

                ////If Complementory reservation is there and it's ref. type is Investor, then give whole room to guest instead of any bed.
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);


                // Check For Rate Card If Rate Card Is Is per Room Type than Do not allow partially occupied room to guest.
                RateCard objRateCardForCheckIsPerRoom = new RateCard();
                objRateCardForCheckIsPerRoom = RateCardBLL.GetByPrimaryKey(new Guid(Convert.ToString(objReservation.RateID)));
                if ((objReservation.IsComplimentoryReservation == true && objReservation.RefInvestorID != null && Convert.ToString(objReservation.RefInvestorID) != string.Empty && Convert.ToString(objReservation.RefInvestorID) != Guid.Empty.ToString()) || (objRateCardForCheckIsPerRoom != null && objRateCardForCheckIsPerRoom.IsPerRoom == true))
                {
                    if (!IsWholeRoomIsAvailable(objReservation.CheckInDate, objReservation.CheckOutDate))
                    {
                         string strMessageToShow = "";
                         if (objRateCardForCheckIsPerRoom.IsPerRoom == true)
                         {
                             strMessageToShow = "This rate card is per room, You can't give partially occupied room to guest.";
                         }
                         else
                         {
                             strMessageToShow = "This reservation is complementory reservation, You can't give partially occupied room to guest.";
                         }
                        ddlRoomNumber.SelectedIndex = 0;
                        MessageBox.Show(strMessageToShow);
                        return; 
                    }
                }
                ////End this is the end of the line

                DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(objReservation.CheckInDate, objReservation.CheckOutDate, this.RoomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);

                DataRow[] drRoomAvbl = dsIsRoomAvbl.Tables[0].Select("RoomID = '" + Convert.ToString(ddlRoomNumber.SelectedValue) + "'");

                if (drRoomAvbl.Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Selected room is not available, please select other room.");
                    return;
                }

                
                objReservation.RestStatus_TermID = 28;
                objReservation.RoomID = new Guid(ddlRoomNumber.SelectedValue);
                objReservation.UpdatedBy = clsSession.UserID;
                objReservation.UpdatedOn = DateTime.Now;
                objReservation.UpdateMode = "ROOM ASSIGNMENT";
                ReservationBLL.UpdateReservationRoomID(objReservation);

                if (objReservation.IsComplimentoryReservation == true)
                {
                    RoomBlockBLL.InsertForComplementoryReservation((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID,false);
                }
                else if(objRateCardForCheckIsPerRoom.IsPerRoom == true)
                {
                    RoomBlockBLL.InsertForComplementoryReservation((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID,true);
                }
                if (objReservation.IsComplimentoryReservation == true && objReservation.RefInvestorID != null && Convert.ToString(objReservation.RefInvestorID) != string.Empty && Convert.ToString(objReservation.RefInvestorID) != Guid.Empty.ToString())
                {
                    ////To update IR's Voucher table by AllocatedRoomID
                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();
                    clnt.Update_ReservationAndAllocatedRoomID(Guid.NewGuid(), objReservation.ReservationID , objReservation.RoomID, "ALLOCATEDROOMID");
                }

                ddlRoomNumber.Enabled = false;
                btnSave.Visible = false;

                ctrlReservationVoucher.ReservationID = objReservation.ReservationID;
                ctrlReservationVoucher.BindReservationVoucherData();

                string strFDEEmailID = ConfigurationManager.AppSettings["IREmailAddress"].ToString();
                if (objReservation.IsComplimentoryReservation != null && objReservation.IsComplimentoryReservation == true && objReservation.RefInvestorID != null && Convert.ToString(objReservation.RefInvestorID) != string.Empty && Convert.ToString(objReservation.RefInvestorID) != Guid.Empty.ToString())
                {
                    ctrlReservationVoucher.SendMailTo(strFDEEmailID, "Complementory Reservation Voucher", "ComplementoryReservationVoucher","COMPLEMENTORYRESERVATION");
                }
                mpeReservatinoVoucher.Show();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void btnSuccessMessageOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }
        #endregion

        #region Grid Event
        protected void gvPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    ((Label)e.Row.FindControl("lblDateOfPayment")).Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DateOfPayment"))).ToString(clsSession.DateFormat);

                    string strAmount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount"));
                    ((Label)e.Row.FindControl("lblAmount")).Text = strAmount.Substring(0, strAmount.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}