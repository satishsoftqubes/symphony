using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlUpgradeDowngradeRoom : System.Web.UI.UserControl
    {
        #region Property and Variable
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
        public MultiView mvOpenMoveUnitHistory
        {
            get { return this.mvMoveUnit; }
        }
        public event EventHandler btnMoveUnitCallParent_Click;

        public string strMode
        {
            get
            {
                return ViewState["strMode"] != null ? Convert.ToString(ViewState["strMode"]) : string.Empty;
            }
            set
            {
                ViewState["strMode"] = value;
            }
        }
        public string strRoomTypeToPrint
        {
            get
            {
                return ViewState["strRoomTypeToPrint"] != null ? Convert.ToString(ViewState["strRoomTypeToPrint"]) : string.Empty;
            }
            set
            {
                ViewState["strRoomTypeToPrint"] = value;
            }
        }

        public string strRoomNoToPrint
        {
            get
            {
                return ViewState["strRoomNoToPrint"] != null ? Convert.ToString(ViewState["strRoomNoToPrint"]) : string.Empty;
            }
            set
            {
                ViewState["strRoomNoToPrint"] = value;
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
        public Guid NewRoomID
        {
            get
            {
                return ViewState["NewRoomID"] != null ? new Guid(Convert.ToString(ViewState["NewRoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["NewRoomID"] = value;
            }
        }

        public Guid OldRoomID
        {
            get
            {
                return ViewState["OldRoomID"] != null ? new Guid(Convert.ToString(ViewState["OldRoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["OldRoomID"] = value;
            }
        }

        public Guid RateID
        {
            get
            {
                return ViewState["RateID"] != null ? new Guid(Convert.ToString(ViewState["RateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateID"] = value;
            }
        }

        public string IsOpenPopUp
        {
            get
            {
                return ViewState["IsOpenPopUp"] != null ? Convert.ToString(ViewState["IsOpenPopUp"]) : string.Empty;
            }
            set
            {
                ViewState["IsOpenPopUp"] = value;
            }
        }

        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
            }
        }

        public bool IsListMessage = false;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                //    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                //CheckUserAuthorization();

                Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
                LoadDefaultValue();
            }
        }

        #endregion

        #region DropDown Event

        protected void ddlMoveUnitUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////mpeMoveUnit.Show();

            this.IsOpenPopUp = string.Empty;

            strMode = "OPENCHANGEROOM";

            if (ddlMoveUnitUnitType.SelectedIndex != 0)
            {
                btnMoveUnitSave.Visible = true;
                BindRoomNoDropDown();
            }
            else
            {
                ddlRoomNumber.Items.Clear();
                ddlRoomNumber.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                btnMoveUnitSave.Visible = false;

            }

            string strPageName = GetPageName();
            mvMoveUnit.ActiveViewIndex = 1;

            if (strPageName.ToUpper() != "CHANGEROOM.ASPX")
            {
                EventHandler temp = btnMoveUnitCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }

        }

        #endregion DropDown Event

        #region Private Method
        private bool IsWholeRoomIsAvailable(DateTime? checkInDate, DateTime? checkOutDate, Guid RoomID)
        {
            bool isWholeRommAvailable = true;

            DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, new Guid(ddlMoveUnitUnitType.SelectedValue), this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
            DataSet dsRoomIDs = RoomBLL.GetAllRoomIDOfRoomByAnyRoomID(RoomID, clsSession.PropertyID);

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
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UpgradeDowngradeRoom.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void BindPaymentDetails()
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
            //lblTotalPaymentReceived.Text = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            //Compare total payable amount and Total received amount for Net amount is Balance or Due.
            if (TotalAmountPayable >= TotalPaymentReceived)
            {
                NetAmountToPay = TotalAmountPayable - TotalPaymentReceived;
                //lblAmountBalanceOrDueText.Text = "Balance Amount (Due)";
                //lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }
            else
            {
                NetAmountToPay = TotalPaymentReceived - TotalAmountPayable;
                //  lblAmountBalanceOrDueText.Text = "Balance Amount";
                //lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            if (dtPaidAmountInfo != null && dtPaidAmountInfo.Rows.Count > 0)
            {
                //gvPaymentList.DataSource = dtPaidAmountInfo;
                // gvPaymentList.DataBind();
            }
            else
            {
                // gvPaymentList.DataSource = null;
                // gvPaymentList.DataBind();
            }
        }

        private void LoadDefaultValue()
        {
            try
            {
                mvMoveUnit.ActiveViewIndex = 0;
                BindSearchRoomType();
                BindGrid();
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindRoomNoDropDown()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                List<ReservationConfig> lstReservation = null;
                ReservationConfig objReservationConfig = new ReservationConfig();
                objReservationConfig.IsActive = true;
                objReservationConfig.CompanyID = clsSession.CompanyID;
                objReservationConfig.PropertyID = clsSession.PropertyID;
                lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

                DateTime dtToSetCheckInDate = new DateTime();
                DateTime dtToSetCheckOutDate = new DateTime();

                DateTime? dtCheckInDate = null;
                DateTime? dtCheckoutDate = null;

                DateTime dtStandardCheckInTime;
                DateTime dtStandardCheckOutTime;


                //Error occurs
                //dtToSetCheckInDate = Convert.ToDateTime(DateTime.Now.ToString(clsSession.DateFormat));

                dtToSetCheckInDate = DateTime.Now;
                dtToSetCheckOutDate = DateTime.ParseExact(litDisplayCheckout.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (lstReservation.Count != 0)
                {
                    dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                    dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);

                    dtCheckInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                    dtCheckoutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                }

                DataSet dsAvailableRooms = ReservationBLL.GetAllVacantRoom(dtCheckInDate, dtCheckoutDate, new Guid(ddlMoveUnitUnitType.SelectedValue), false, null, clsSession.PropertyID, clsSession.CompanyID);
                ddlRoomNumber.Items.Clear();

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



                //if (dsAvailableRooms.Tables.Count > 0 && dsAvailableRooms.Tables[0].Rows.Count > 0)
                //{
                //    ddlRoomNumber.DataSource = dsAvailableRooms.Tables[0];
                //    ddlRoomNumber.DataTextField = "RoomNo";
                //    ddlRoomNumber.DataValueField = "RoomID";
                //    ddlRoomNumber.DataBind();
                //    ddlRoomNumber.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                //}
                //else
                //{
                //    ddlRoomNumber.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                //}
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindMoveUnitHistoryGrid()
        {
            try
            {
                DataSet dsHistory = MoveRoomBLL.GetMoveRoomHistory(null, this.ReservationID, null, null);

                if (dsHistory.Tables.Count > 0 && dsHistory.Tables[0].Rows.Count > 0)
                {
                    gvMoveUnitHistoryList.DataSource = dsHistory.Tables[0];
                    gvMoveUnitHistoryList.DataBind();
                }
                else
                {
                    gvMoveUnitHistoryList.DataSource = null;
                    gvMoveUnitHistoryList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetPageName()
        {
            var uri = new Uri(Convert.ToString(Request.Url));
            string path = uri.GetLeftPart(UriPartial.Path);
            string[] strArray = path.Split('/');
            string strPageName = "";
            return strPageName = Convert.ToString(strArray[strArray.Length - 1]);
        }

        private void BindSearchRoomType()
        {
            string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";

            ddlSearchRoomType.Items.Clear();

            DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);
            if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
            {
                ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
                ddlSearchRoomType.DataTextField = "RoomTypeName";
                ddlSearchRoomType.DataValueField = "RoomTypeID";
                ddlSearchRoomType.DataBind();

                ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
        }

        private void BindRoomTypeByRateID()
        {
            try
            {
                ddlMoveUnitUnitType.Items.Clear();

                DataSet ds = RateCardDetailsBLL.SelectRoomTypeByRateID(this.RateID, clsSession.PropertyID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlMoveUnitUnitType.DataSource = ds.Tables[0];
                    ddlMoveUnitUnitType.DataTextField = "RoomTypeName";
                    ddlMoveUnitUnitType.DataValueField = "RoomTypeID";
                    ddlMoveUnitUnitType.DataBind();

                    ddlMoveUnitUnitType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                    ddlMoveUnitUnitType.SelectedIndex = 0;
                }
                else
                {
                    ddlMoveUnitUnitType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                    ddlMoveUnitUnitType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindGrid()
        {
            try
            {
                string strName = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? RoomTypeID = null;

                if (txtSearchGuestName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchGuestName.Text.Trim());

                if (txtSearchBookingNo.Text.Trim() != "")
                    strReservationNo = "RES#" + Convert.ToString(txtSearchBookingNo.Text.Trim());


                if (txtSearchRoomNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchRoomNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }

                if (ddlSearchRoomType.SelectedIndex != 0)
                    RoomTypeID = new Guid(ddlSearchRoomType.SelectedValue);

                DataSet dsReservationList = ReservationBLL.GetSwapRoomList(clsSession.PropertyID, clsSession.CompanyID, strName, strReservationNo, strRoomNo, RoomTypeID);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvResevationList.DataSource = dsReservationList.Tables[0];
                    gvResevationList.DataBind();
                }
                else
                {
                    gvResevationList.DataSource = null;
                    gvResevationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearListData()
        {
            txtSearchBookingNo.Text = txtSearchGuestName.Text = txtSearchRoomNo.Text = "";
            ddlSearchRoomType.SelectedIndex = 0;
        }

        private void ClearFormData()
        {
            this.NewRoomID = this.OldRoomID = this.ReservationID = Guid.Empty;
            ddlMoveUnitUnitType.SelectedIndex = 0;
            Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
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
            dr4["NameColumn"] = "Guest Mgmt";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);



            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Up/Down-grade Room";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion

        #region Control Event

        protected void btnMoveUnitHistory_Click(object sender, EventArgs e)
        {
            ////mpeMoveUnit.Show();

            string strPageName = GetPageName();
            BindMoveUnitHistoryGrid();

            if (strPageName.ToUpper() != "CHANGEROOM.ASPX")
            {
                strMode = "OPENCHANGEROOMHISTORY";

                EventHandler temp = btnMoveUnitCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }

                mvMoveUnit.ActiveViewIndex = 1;
            }
            else
            {
                mvMoveUnit.ActiveViewIndex = 2;
            }
        }

        protected void btnMoveUnitHistoryCancel_Click(object sender, EventArgs e)
        {
            ////mpeMoveUnit.Show();
            strMode = "OPENCHANGEROOM";
            mvMoveUnit.ActiveViewIndex = 0;

            string strPageName = GetPageName();

            if (strPageName.ToUpper() != "CHANGEROOM.ASPX")
            {
                EventHandler temp = btnMoveUnitCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
        }

        protected void imgbtnClearListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            ClearListData();
            BindGrid();
        }

        protected void imgbtnSearchListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            BindGrid();
        }

        protected void btnMoveUnitCancel_Click(object sender, EventArgs e)
        {
            mvMoveUnit.ActiveViewIndex = 0;
        }

        protected void btnMoveUnitSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {

                    if (this.RoomTypeID == new Guid(ddlMoveUnitUnitType.SelectedValue))
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("New room type is same as previous room type, you cant proceed");
                        return;
                    }

                    this.IsOpenPopUp = ctrlUpdatesRate.strOpenMode;

                    if (this.RoomTypeID != new Guid(ddlMoveUnitUnitType.SelectedValue))
                    {
                        if (this.IsOpenPopUp == string.Empty)
                        {
                            //this.IsOpenPopUp = "NOTOPEN";
                            ctrlUpdatesRate.ucmpeRate.Show();
                            ctrlUpdatesRate.uclitDspReservationNo.Text = Convert.ToString(litDisplayMoveUnitReservationNo.Text.Trim());
                            ctrlUpdatesRate.uclitDspRoomType.Text = Convert.ToString(litDisplayMoveUnitRoomNoAndRoomType.Text.Trim());
                            ctrlUpdatesRate.OldRoomType = strRoomTypeToPrint;
                            ctrlUpdatesRate.OldRoomTypeNo = strRoomNoToPrint;
                            ctrlUpdatesRate.New_RateID = this.RateID;
                            ctrlUpdatesRate.ResID = this.ReservationID;
                            //ctrlUpdatesRate.New_CheckOutDate = Convert.ToDateTime(litDisplayMoveUnitCheckOutDate.Text.Trim());
                            ctrlUpdatesRate.New_RoomTypeID = new Guid(ddlMoveUnitUnitType.SelectedValue);
                            ctrlUpdatesRate.GuestNameToPrint = Convert.ToString(litDisplayMoveUnitGuestName.Text);
                            ctrlUpdatesRate.NewRoomTypeName = Convert.ToString(ddlMoveUnitUnitType.SelectedItem);
                            ctrlUpdatesRate.NewRoomTypeNo = Convert.ToString(ddlRoomNumber.SelectedItem);
                            ctrlUpdatesRate.BindBlockDateRateGrid();
                            return;
                        }
                    }
                    this.NewRoomID = new Guid(ddlRoomNumber.SelectedValue);

                    if (this.NewRoomID != Guid.Empty)
                    {


                        ////If Complementory reservation is there and it's ref. type is Investor, then give whole room to guest instead of any bed.
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationForCheck = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                        RateCard objRateCardForCheckIsPerRoom = new RateCard();
                        objRateCardForCheckIsPerRoom = RateCardBLL.GetByPrimaryKey(new Guid(Convert.ToString(objReservationForCheck.RateID)));
                        //(objRateCardForCheckIsPerRoom != null && objRateCardForCheckIsPerRoom.IsPerRoom == true)
                        if ((objReservationForCheck.IsComplimentoryReservation == true && objReservationForCheck.RefInvestorID != null && Convert.ToString(objReservationForCheck.RefInvestorID) != string.Empty && Convert.ToString(objReservationForCheck.RefInvestorID) != Guid.Empty.ToString()) || (objRateCardForCheckIsPerRoom != null && objRateCardForCheckIsPerRoom.IsPerRoom == true))
                        {
                            if (!IsWholeRoomIsAvailable(objReservationForCheck.CheckInDate, objReservationForCheck.CheckOutDate, this.NewRoomID))
                            {
                                string strMessageToShow = "";
                                if (objRateCardForCheckIsPerRoom.IsPerRoom == true)
                                {
                                    strMessageToShow = "This reservation is full room reservation, you can't give partially occupied room to guest";
                                }
                                else
                                {
                                    strMessageToShow = "This reservation is complementory reservation, You can't give partially occupied room to guest.";
                                }
                                MessageBox.Show(strMessageToShow);
                                return;
                            }
                        }
                        DataSet dsResTemp = ReservationBLL.Reservation_SymphonySelectReservation(null, null, null, null, null, null, null, null, null, null, null, this.NewRoomID, null, null, 32);
                        if (dsResTemp.Tables[0].Rows.Count == 0)
                        {
                            SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objOldReservationData = new BusinessLogic.FrontDesk.DTO.Reservation();
                            SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = new BusinessLogic.FrontDesk.DTO.Reservation();

                            objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                            objReservation.UpdatedBy = clsSession.UserID;
                            objReservation.UpdatedOn = DateTime.Now;
                            objOldReservationData = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                            SQT.Symphony.BusinessLogic.FrontDesk.DTO.MoveRoom objToInsert = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.MoveRoom();
                            objToInsert.OldRoomID = this.OldRoomID;
                            objToInsert.NewRoomID = this.NewRoomID;
                            objToInsert.Reasom = clsCommon.GetUpperCaseText(Convert.ToString(txtReasontoMoveRoom.Text.Trim()));
                            objToInsert.ConfirmedBy = clsSession.UserID;
                            objToInsert.DateOfMove = DateTime.Now;
                            objToInsert.PropertyID = clsSession.PropertyID;
                            objToInsert.CompanyID = clsSession.CompanyID;
                            objToInsert.IsActive = true;
                            objToInsert.ReservationID = this.ReservationID;
                            objToInsert.DateUpTo = objOldReservationData.CheckOutDate;

                            MoveRoomBLL.Save(objToInsert);
                            ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "res_MoveRoom", null);


                            objReservation.RoomTypeID = new Guid(ddlMoveUnitUnitType.SelectedValue);
                            objReservation.RoomID = this.NewRoomID;
                            objReservation.UpdateMode = "ROOM UPGRADE";
                            ReservationBLL.Update(objReservation);
                            ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objOldReservationData.ToString(), objReservation.ToString(), "res_Reservation", null);

                            //this.IsOpenPopUp = ctrlUpdatesRate.strOpenMode;

                            if (this.RoomTypeID != new Guid(ddlMoveUnitUnitType.SelectedValue) && this.IsOpenPopUp == "CONTINEWWITHRATEUPDATE" && this.IsOpenPopUp != string.Empty)
                            {
                                BlockDateRateBLL.DeleteByReservationID(this.ReservationID);
                                List<BlockDateRate> lstBlockDateRate_Insert = new List<BlockDateRate>();
                                List<ResServiceList> lstResServiceList_Insert = new List<ResServiceList>();

                                if (Session["lstMoveRoomBlockDateRate"] != null)
                                {
                                    lstBlockDateRate_Insert = (List<BlockDateRate>)Session["lstMoveRoomBlockDateRate"];
                                }

                                if (Session["lstMoveRoomResService"] != null)
                                {
                                    lstResServiceList_Insert = (List<ResServiceList>)Session["lstMoveRoomResService"];
                                }

                                BlockDateRateBLL.SaveBlockDateEntry(lstBlockDateRate_Insert, lstResServiceList_Insert, this.ReservationID, this.NewRoomID, new Guid(ddlMoveUnitUnitType.SelectedValue), objReservation.RestStatus_TermID, this.FolioID);
                            }

                            if (this.IsOpenPopUp == string.Empty || this.IsOpenPopUp == "CONTINEWWITHOUTRATEUPDATE")
                            {
                                List<BlockDateRate> lstBlockDateRate = null;
                                BlockDateRate objBlockDateRate = new BlockDateRate();
                                objBlockDateRate.ReservationID = this.ReservationID;

                                lstBlockDateRate = BlockDateRateBLL.GetAll(objBlockDateRate);

                                for (int i = 0; i < lstBlockDateRate.Count; i++)
                                {
                                    if (lstBlockDateRate[i].BookID == null || Convert.ToString(lstBlockDateRate[i].BookID) == "")
                                    {
                                        DateTime dtBlockDateRate = Convert.ToDateTime(lstBlockDateRate[i].BlockDate);
                                        TimeSpan tCheck = DateTime.Now.Date.Subtract(dtBlockDateRate.Date);

                                        if (tCheck.TotalDays <= 0)
                                        {
                                            BlockDateRate bd = new BlockDateRate();
                                            bd = BlockDateRateBLL.GetByPrimaryKey(lstBlockDateRate[i].ResBlockDateRateID);

                                            if (bd != null)
                                            {
                                                if (this.NewRoomID != Guid.Empty)
                                                {
                                                    bd.RoomID = this.NewRoomID;
                                                    BlockDateRateBLL.Update(bd);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            // Logic to Block Room

                            if (objReservation.IsComplimentoryReservation == true)
                            {
                                RoomBlockBLL.DeleteForOldandInsertForNewRoomBlockDetails((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID,false);
                            }
                            else if (objRateCardForCheckIsPerRoom.IsPerRoom == true)
                            {
                                RoomBlockBLL.DeleteForOldandInsertForNewRoomBlockDetails((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID, true);
                            }


                            ClearFormData();
                            gvResevationList.PageIndex = 0;
                            BindGrid();
                            mvMoveUnit.ActiveViewIndex = 0;
                            IsListMessage = true;
                            ltrListMessage.Text = "Room Upgrade Successfully.";
                        }
                        else
                        {
                            lblCustomePopupMsg.Text = "Guest is already checked-in to this room, Complete check-out process.";
                            mpeCustomePopup.Show();
                            return;

                        }
                    }
                    else
                    {
                        lblCustomePopupMsg.Text = "Select Room from the list.";
                        mpeCustomePopup.Show();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnUpdatesRateCallParent_Click(object sender, EventArgs e)
        {
            this.IsOpenPopUp = "YES";
        }

        #endregion

        #region Grid Event

        protected void gvResevationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvListPhone = (Label)e.Row.FindControl("lblGvListPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvListPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));

                    Label lblGvListRoomNo = (Label)e.Row.FindControl("lblGvListRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvListRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("MOVEROOM"))
                {
                    // To Check Billing Instruction status 

                    DataSet dsForCheckBillingInstruction = ReservationBLL.GetBillingInstructionTermStatus(new Guid(Convert.ToString(e.CommandArgument)), clsSession.CompanyID, clsSession.PropertyID, true);
                    if (dsForCheckBillingInstruction != null && dsForCheckBillingInstruction.Tables.Count > 0 && dsForCheckBillingInstruction.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsForCheckBillingInstruction.Tables[0].Rows[0]["NoOfRecord"]) <= 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Only Full bill to guest allow to Up/Down-grade Room ");
                        return;
                    }

                    mvMoveUnit.ActiveViewIndex = 1;

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvListReservationNo = (Label)row.FindControl("lblGvListReservationNo");
                    Label lblGvListRoomTypeName = (Label)row.FindControl("lblGvListRoomTypeName");
                    Label lblGvListRoomNo = (Label)row.FindControl("lblGvListRoomNo");
                    Label lblGvListName = (Label)row.FindControl("lblGvListName");
                    Label lblGvListCheckInDate = (Label)row.FindControl("lblGvListCheckInDate");
                    Label lblGvListCheckOutDate = (Label)row.FindControl("lblGvListCheckOutDate");


                    litDisplayMoveUnitReservationNo.Text = Convert.ToString(lblGvListReservationNo.Text.Trim());
                    litDisplayMoveUnitGuestName.Text = Convert.ToString(lblGvListName.Text.Trim());

                    decimal dcBalance = Convert.ToDecimal(gvResevationList.DataKeys[row.RowIndex]["Balance"].ToString());
                    this.RoomTypeID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomTypeID"].ToString());
                    this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));
                    this.OldRoomID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomID"].ToString());
                    this.RateID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RateID"].ToString());
                    this.FolioID = new Guid(gvResevationList.DataKeys[row.RowIndex]["FolioID"].ToString());
                    ctrlUpdatesRate.New_CheckOutDate = Convert.ToDateTime(gvResevationList.DataKeys[row.RowIndex]["CheckOutDate"].ToString());
                    ctrlUpdatesRate.New_CheckInDate = Convert.ToDateTime(gvResevationList.DataKeys[row.RowIndex]["CheckInDate"].ToString());
                    litDisplayCheckIn.Text = Convert.ToString(lblGvListCheckInDate.Text.Trim());
                    litDisplayCheckout.Text = Convert.ToString(lblGvListCheckOutDate.Text.Trim());
                    litDisplayFolioBalance.Text = dcBalance.ToString().Substring(0, dcBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    litDisplayMoveUnitRoomNoAndRoomType.Text = Convert.ToString(lblGvListRoomNo.Text.Trim()) + " - " + Convert.ToString(lblGvListRoomTypeName.Text.Trim());
                    strRoomNoToPrint = Convert.ToString(lblGvListRoomNo.Text.Trim());
                    strRoomTypeToPrint = Convert.ToString(lblGvListRoomTypeName.Text.Trim());
                    ltrChkPmtRateCard.Text = Convert.ToString(gvResevationList.DataKeys[row.RowIndex]["RateCardName"]);
                    BindRoomTypeByRateID();
                    BindPaymentDetails();



                    ddlRoomNumber.Items.Clear();
                    ddlMoveUnitUnitType.SelectedIndex = ddlMoveUnitUnitType.Items.FindByText(Convert.ToString(lblGvListRoomTypeName.Text.Trim())) != null ? ddlMoveUnitUnitType.Items.IndexOf(ddlMoveUnitUnitType.Items.FindByText(Convert.ToString(lblGvListRoomTypeName.Text.Trim()))) : 0;

                    if (ddlMoveUnitUnitType.SelectedIndex != 0)
                    {
                        btnMoveUnitSave.Visible = true;
                        BindRoomNoDropDown();

                    }
                    else
                    {
                        ddlRoomNumber.Items.Clear();
                        ddlRoomNumber.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                        btnMoveUnitSave.Visible = false;

                    }
                    this.IsOpenPopUp = ctrlUpdatesRate.strOpenMode = string.Empty;
                    Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResevationList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void gvMoveUnitHistoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMoveUnitHistoryList.PageIndex = e.NewPageIndex;
            BindMoveUnitHistoryGrid();
        }
        protected void gvMoveUnitHistoryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvOldRoomNo = (Label)e.Row.FindControl("lblGvOldRoomNo");
                    string strOldRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OldRoomNo"));
                    lblGvOldRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strOldRoomNo));

                    Label lblGvNewRoomNo = (Label)e.Row.FindControl("lblGvNewRoomNo");
                    string strNewRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NewRoomNo"));
                    lblGvNewRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strNewRoomNo));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}