using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;
using System.Text;
using System.IO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlCheckIn : System.Web.UI.UserControl
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
        public bool IsVoucherMessage = false;
        public bool IsGuestDocMessage = false;
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
        public int ReservationStatusValue
        {
            get
            {
                return ViewState["ReservationStatusValue"] != null ? Convert.ToInt32(ViewState["ReservationStatusValue"]) : 0;
            }
            set
            {
                ViewState["ReservationStatusValue"] = value;
            }
        }
        public Guid GuestID
        {
            get
            {
                return ViewState["GuestID"] != null ? new Guid(Convert.ToString(ViewState["GuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestID"] = value;
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
        public Guid RoomID
        {
            get
            {
                return ViewState["RoomID"] != null ? new Guid(Convert.ToString(ViewState["RoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomID"] = value;
            }
        }
        public Guid ReservationFolioID
        {
            get
            {
                return ViewState["ReservationFolioID"] != null ? new Guid(Convert.ToString(ViewState["ReservationFolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationFolioID"] = value;
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
        public int ResInfraServiceChargeAmount
        {
            get
            {
                return ViewState["ResInfraServiceChargeAmount"] != null ? Convert.ToInt32(ViewState["ResInfraServiceChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ResInfraServiceChargeAmount"] = value;
            }
        }
        public int PaidInfraServiceChargeAmount
        {
            get
            {
                return ViewState["PaidInfraServiceChargeAmount"] != null ? Convert.ToInt32(ViewState["PaidInfraServiceChargeAmount"]) : 0;
            }
            set
            {
                ViewState["PaidInfraServiceChargeAmount"] = value;
            }
        }
        public int FoodChargeAmount
        {
            get
            {
                return ViewState["FoodChargeAmount"] != null ? Convert.ToInt32(ViewState["FoodChargeAmount"]) : 0;
            }
            set
            {
                ViewState["FoodChargeAmount"] = value;
            }
        }
        public int PaidFoodChargeAmount
        {
            get
            {
                return ViewState["PaidFoodChargeAmount"] != null ? Convert.ToInt32(ViewState["PaidFoodChargeAmount"]) : 0;
            }
            set
            {
                ViewState["PaidFoodChargeAmount"] = value;
            }
        }
        public int ElectricityChargeAmount
        {
            get
            {
                return ViewState["ElectricityChargeAmount"] != null ? Convert.ToInt32(ViewState["ElectricityChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ElectricityChargeAmount"] = value;
            }
        }
        public int PaidElectricityChargeAmount
        {
            get
            {
                return ViewState["PaidElectricityChargeAmount"] != null ? Convert.ToInt32(ViewState["PaidElectricityChargeAmount"]) : 0;
            }
            set
            {
                ViewState["PaidElectricityChargeAmount"] = value;
            }
        }
        public Guid RoomChargePostTimeReservationID
        {
            get
            {
                return ViewState["RoomChargePostTimeReservationID"] != null ? new Guid(Convert.ToString(ViewState["RoomChargePostTimeReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomChargePostTimeReservationID"] = value;
            }
        }
        public string CheckInStartTime
        {
            get
            {
                return ViewState["CheckInStartTime"] != null ? Convert.ToString(ViewState["CheckInStartTime"]) : string.Empty;
            }
            set
            {
                ViewState["CheckInStartTime"] = value;
            }
        }
        public string strIsCounterValidate
        {
            get
            {
                return ViewState["strIsCounterValidate"] != null ? Convert.ToString(ViewState["strIsCounterValidate"]) : string.Empty;
            }
            set
            {
                ViewState["strIsCounterValidate"] = value;
            }
        }
        public string strFolioNo
        {
            get
            {
                return ViewState["strFolioNo"] != null ? Convert.ToString(ViewState["strFolioNo"]) : string.Empty;
            }
            set
            {
                ViewState["strFolioNo"] = value;
            }
        }
        public string strBillingInstruction
        {
            get
            {
                return ViewState["strBillingInstruction"] != null ? Convert.ToString(ViewState["strBillingInstruction"]) : string.Empty;
            }
            set
            {
                ViewState["strBillingInstruction"] = value;
            }
        }
        public DateTime dtCheckInDate
        {
            get
            {
                return ViewState["dtCheckInDate"] != null ? Convert.ToDateTime(ViewState["dtCheckInDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["dtCheckInDate"] = value;
            }
        }
        public DateTime dtCheckOutDate
        {
            get
            {
                return ViewState["dtCheckOutDate"] != null ? Convert.ToDateTime(ViewState["dtCheckOutDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["dtCheckOutDate"] = value;
            }
        }
        public Guid VoucherDetailID
        {
            get
            {
                return ViewState["VoucherDetailID"] != null ? new Guid(Convert.ToString(ViewState["VoucherDetailID"])) : Guid.Empty;
            }
            set
            {
                ViewState["VoucherDetailID"] = value;
            }
        }
        public bool IsForeignNationalInfoSaved
        {
            get
            {
                return ViewState["IsForeignNationalInfoSaved"] != null ? Convert.ToBoolean(ViewState["IsForeignNationalInfoSaved"]) : false;
            }
            set
            {
                ViewState["IsForeignNationalInfoSaved"] = value;
            }
        }
        public Decimal AmountSuggestedToPay
        {
            get
            {
                return ViewState["AmountSuggestedToPay"] != null ? Convert.ToDecimal(ViewState["AmountSuggestedToPay"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["AmountSuggestedToPay"] = value;
            }
        }
        public string strPaidAmt2AvoidDoubleEntry
        {
            get
            {
                return ViewState["strPaidAmt2AvoidDoubleEntry"] != null ? Convert.ToString(ViewState["strPaidAmt2AvoidDoubleEntry"]) : string.Empty;
            }
            set
            {
                ViewState["strPaidAmt2AvoidDoubleEntry"] = value;
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


                BindNationality();
                BindIDDocumentType();
                BindBreadCrumb();
                if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                {
                    ucCommonCounterLogin.CounterLoginLogID = ucCommonCounterLogin.DefaultCounterID = Guid.Empty;
                    ucCommonCounterLogin.CounterName = string.Empty;

                    ucCommonCounterLogin.CheckAuthentication();

                    if (ucCommonCounterLogin.strRights == "ALLOWOPEN")
                    {
                        mpeOpenCounter.Show();
                    }
                    else
                    {
                        lblCounterErrorMessage.Text = "You have not permission to do this operation.";
                        mpeCounterErrorMessage.Show();
                        return;
                    }

                    this.strIsCounterValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                    return;
                }

                LoadDataOnPageLoadEvent();

            }
        }
        #endregion Page Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
            {
                if (Request["Mode"] != null && (Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT"))
                {
                    this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "Rentreceipt.aspx");
                    ChekAuthorizationForVoidRole();
                }
                else if (Request["Mode"] != null && (Convert.ToString(Request["Mode"]).ToUpper() == "DEPOSIT"))
                {
                    this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "SecurityDeposit.aspx");
                    ChekAuthorizationForVoidRole();
                }
                else
                {
                    this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CheckIn.aspx");
                }
            }
            else
            {
                this.UserRights = "1111";
            }


            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");


            //btnCheckInSave.Visible =  this.UserRights.Substring(1, 1) == "1";
        }
        private void ChekAuthorizationForVoidRole()
        {
            // Check For Authorization of user to void transaction or Not
            if (clsSession.UserID != Guid.Empty && clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
            {
                DataSet dsUserRole = RoleBLL.GetUserRole(clsSession.UserID, clsSession.CompanyID, clsSession.PropertyID, "Void");
                if (dsUserRole.Tables[0].Rows.Count != 0)
                {
                    gvPaymentList.Columns[4].Visible = true;
                }
                else
                {
                    gvPaymentList.Columns[4].Visible = false;
                }
            }
        }
        private void ClearForeignNationalInfo()
        {
            txtPassportDateOfExpiry.Text = txtPassportDateOfIssue.Text = txtPassportNumber.Text = txtPassportPlaceOfIssue.Text = txtVisaDateofExpiry.Text = txtVisaDateofIssue.Text = txtVisaNo.Text = txtVisaplaceofissue.Text = txtVisaPurpose.Text = txtVisatype.Text = "";
            ddlIdtypeForeignNatinal.SelectedIndex = 0;
            if (ddlIdtypeForeignNatinal.Items.Count > 2)
            {
                ddlIdtypeForeignNatinal.SelectedIndex = 3;
            }
        }

        private void BindNationality()
        {
            ddlNationality.Items.Clear();
            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "NATIONALITY");
            if (lstProjectTermTitle.Count != 0)
            {
                ddlNationality.DataSource = lstProjectTermTitle;
                ddlNationality.DataTextField = "DisplayTerm";
                ddlNationality.DataValueField = "DisplayTerm";
                ddlNationality.DataBind();
                ddlNationality.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlNationality.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
        }

        private void BindIDDocumentType()
        {
            ddlIdtypeForeignNatinal.Items.Clear();
            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "ID DOCUMENT TYPE");
            if (lstProjectTermTitle.Count != 0)
            {
                ddlIdtypeForeignNatinal.DataSource = lstProjectTermTitle;
                ddlIdtypeForeignNatinal.DataTextField = "DisplayTerm";
                ddlIdtypeForeignNatinal.DataValueField = "TermID";
                ddlIdtypeForeignNatinal.DataBind();
                ddlIdtypeForeignNatinal.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlIdtypeForeignNatinal.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
        }

        private void LoadDataOnPageLoadEvent()
        {
            if (Request["Mode"] != null && (Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT" || Convert.ToString(Request["Mode"]).ToUpper() == "DEPOSIT"))
            {
                mpeCheckInPayment.Show();
            }
            else if (Request["Walkin"] != null)
                mvCheckInForm.ActiveViewIndex = 1;
            else
            {
                if (!(clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "GUESTDETAILS"))
                {
                    Response.Redirect("~/GUI/Dashboard.aspx");
                }
            }


            LoadDefaultValue();
            this.CheckInStartTime = DateTime.Now.ToString();
            lblCheckinStartTime.Text = DateTime.Now.ToString(clsSession.DateFormat) + " " + DateTime.Now.ToString(clsSession.TimeFormat);
            lblCheckinEndTime.Text = "-";

            if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "GUESTDETAILS")
            {
                mvCheckInForm.ActiveViewIndex = 0;
                this.ReservationID = clsSession.ToEditItemID;
                hdnResID.Value = Convert.ToString(this.ReservationID);
                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = string.Empty;
                BindGuestBasicDetails();
                BindPaymentDetails();
                BindGuestStayHistory();
                BindGuestNote();
                BindGuestPreferences();
            }
        }

        private void LoadDefaultValue()
        {
            try
            {
                calValidity.Format = clsSession.DateFormat;
                calPassportDateOfExpiry.Format = clsSession.DateFormat;
                calPassportDateOfIssue.Format = clsSession.DateFormat;
                calVisaDateofExpiry.Format = clsSession.DateFormat;
                calVisaDateofIssue.Format = clsSession.DateFormat;
                BindBreadCrumb();
                //hfDateFormat.Value = clsSession.DateFormat;
                BindRoomType();
                BindProjectTermData();
                BindCompany();

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
            dr4["NameColumn"] = "Arrival List";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Check In";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGuestStayHistory()
        {
            if (this.GuestID != Guid.Empty)
            {
                DataSet dtGuestFeedback = ReservationGuestBLL.GetAllGuestStayHistory(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                gvGuestHistory.DataSource = dtGuestFeedback;
                gvGuestHistory.DataBind();
            }
        }

        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }

        public int Reservation_GetTotalDays(Object CheckInDate, Object CheckOutDate)
        {
            int Day = (Convert.ToInt32(((Convert.ToDateTime(CheckOutDate.ToString())) - (Convert.ToDateTime(CheckInDate.ToString()))).TotalDays));
            return Day;
        }

        private void BindProjectTermData()
        {
            ddlTitle.Items.Clear();
            DataSet dsData = ProjectTermBLL.SelectTitleCSWTGT(clsSession.CompanyID, clsSession.PropertyID, "TITLE", "COMPANYSECTOR", "WORKINGTIME", "GUESTTYPE", "ID DOCUMENT TYPE", "BLOOD GROUP", "MEAL PREFERENCE", "PAYMENTMODE");
            if (dsData.Tables.Count != 0 && dsData.Tables[0].Rows.Count > 0)
            {
                ddlTitle.DataSource = dsData.Tables[0];
                ddlTitle.DataTextField = "DisplayTerm";
                ddlTitle.DataValueField = "Term";
                ddlTitle.DataBind();
                ddlTitle.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlTitle.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

            ddlCompanySector.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[1].Rows.Count > 0)
            {
                ddlCompanySector.DataSource = dsData.Tables[1];
                ddlCompanySector.DataTextField = "DisplayTerm";
                ddlCompanySector.DataValueField = "TermID";
                ddlCompanySector.DataBind();
                ddlCompanySector.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlCompanySector.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

            ddlWorkTiming.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[2].Rows.Count > 0)
            {
                ddlWorkTiming.DataSource = dsData.Tables[2];
                ddlWorkTiming.DataTextField = "DisplayTerm";
                ddlWorkTiming.DataValueField = "TermID";
                ddlWorkTiming.DataBind();
                ddlWorkTiming.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlWorkTiming.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

            ddlGuestType.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[3].Rows.Count > 0)
            {
                ddlGuestType.DataSource = dsData.Tables[3];
                ddlGuestType.DataTextField = "DisplayTerm";
                ddlGuestType.DataValueField = "TermID";
                ddlGuestType.DataBind();
                ddlGuestType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlGuestType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));


            ddlDocument1.Items.Clear();
            ddlDocument2.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[4].Rows.Count > 0)
            {
                ddlDocument1.DataSource = dsData.Tables[4];
                ddlDocument1.DataTextField = "DisplayTerm";
                ddlDocument1.DataValueField = "TermID";
                ddlDocument1.DataBind();
                ddlDocument1.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

                ddlDocument2.DataSource = dsData.Tables[4];
                ddlDocument2.DataTextField = "DisplayTerm";
                ddlDocument2.DataValueField = "TermID";
                ddlDocument2.DataBind();
                ddlDocument2.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlDocument1.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                ddlDocument2.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }


            ddlBloodGroup.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[5].Rows.Count > 0)
            {
                ddlBloodGroup.DataSource = dsData.Tables[5];
                ddlBloodGroup.DataTextField = "DisplayTerm";
                ddlBloodGroup.DataValueField = "Term";
                ddlBloodGroup.DataBind();
                ddlBloodGroup.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlBloodGroup.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

            ddlMealPreference.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[6].Rows.Count > 0)
            {
                ddlMealPreference.DataSource = dsData.Tables[6];
                ddlMealPreference.DataTextField = "DisplayTerm";
                ddlMealPreference.DataValueField = "TermID";
                ddlMealPreference.DataBind();
                ddlMealPreference.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlMealPreference.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

            ddlModeOfPayment.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[7].Rows.Count > 0)
            {
                ddlModeOfPayment.DataSource = dsData.Tables[7];
                ddlModeOfPayment.DataTextField = "DisplayTerm";
                ddlModeOfPayment.DataValueField = "TermID";
                ddlModeOfPayment.DataBind();
                ddlModeOfPayment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlModeOfPayment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

            ddlDOBDate.Items.Clear();
            ddlDOBYear.Items.Clear();

            ddlDOBDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int i = 1; i < 32; i++)
            {
                if (i < 10)
                    ddlDOBDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                else
                    ddlDOBDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
            }

            int l = 1;
            ddlDOBYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = DateTime.Now.Year; i >= 1940; i--)
            {
                ddlDOBYear.Items.Insert(l, new ListItem(i.ToString(), i.ToString()));
                l++;
            }
        }

        private void BindGuestBasicDetails()
        {
            if (this.ReservationID != Guid.Empty)
            {
                DataSet dsReservationData = ReservationBLL.GetArrivalListData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, null, null, null, null, null, "DETAILS", null);

                if (dsReservationData.Tables.Count > 0 && dsReservationData.Tables[0].Rows.Count > 0)
                {
                    DataRow drResData = dsReservationData.Tables[0].Rows[0];

                    this.GuestID = new Guid(Convert.ToString(drResData["GuestID"]));
                    this.dtCheckInDate = Convert.ToDateTime(Convert.ToString(drResData["CheckInDate"]));
                    this.dtCheckOutDate = Convert.ToDateTime(Convert.ToString(drResData["CheckOutDate"]));

                    DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(drResData["CheckInDate"]));
                    DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(drResData["CheckOutDate"]));
                    DateTime dtReservationDate = Convert.ToDateTime(Convert.ToString(drResData["ReservationDate"]));

                    ltrChkPmtReservationNo.Text = litDisplayReservationNo.Text = Convert.ToString(drResData["ReservationNo"]);
                    litDisplayBookingDate.Text = Convert.ToString(dtReservationDate.ToString(clsSession.DateFormat));
                    litDisplayBookedBy.Text = Convert.ToString(drResData["BookedBy"]);
                    ltrChkPmtCheckInDate.Text = litDisplayCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    ltrChkPmtCheckOutDate.Text = litDisplayCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                    ltrChkPmtRoomType.Text = litDisplayRoomType.Text = Convert.ToString(drResData["RoomTypeName"]);

                    ddlSearchRoomType.SelectedIndex = ddlSearchRoomType.Items.FindByValue(Convert.ToString(drResData["RoomTypeID"])) != null ? ddlSearchRoomType.Items.IndexOf(ddlSearchRoomType.Items.FindByValue(Convert.ToString(drResData["RoomTypeID"]))) : 0;
                    this.RoomTypeID = new Guid(Convert.ToString(drResData["RoomTypeID"]));
                    this.ReservationFolioID = new Guid(Convert.ToString(drResData["FolioID"]));

                    ltrChkPmtRateCard.Text = litDisplayRateCard.Text = Convert.ToString(drResData["RateCardName"]);
                    litDisplayAdult.Text = Convert.ToString(drResData["Adults"]);

                    if (Convert.ToString(drResData["Children"]) != null && Convert.ToString(drResData["Children"]) != "")
                        litDisplayChild.Text = Convert.ToString(drResData["Children"]);
                    else
                        litDisplayChild.Text = "-";

                    if (Convert.ToString(drResData["Infant"]) != null && Convert.ToString(drResData["Infant"]) != "")
                        litDisplayInf.Text = Convert.ToString(drResData["Infant"]);
                    else
                        litDisplayInf.Text = "-";

                    if (Convert.ToString(drResData["IsToPickUp"]) != null && Convert.ToString(drResData["IsToPickUp"]) != "")
                    {
                        bool IsToPickUp = Convert.ToBoolean(Convert.ToString(drResData["IsToPickUp"]));
                        if (IsToPickUp)
                            rdbIsPicup.SelectedIndex = 0;
                        else
                            rdbIsPicup.SelectedIndex = 1;
                    }
                    else
                        rdbIsPicup.SelectedIndex = 1;

                    if (Convert.ToString(drResData["IsSmoking"]) != null && Convert.ToString(drResData["IsSmoking"]) != "")
                    {
                        bool IsSmoking = Convert.ToBoolean(Convert.ToString(drResData["IsSmoking"]));
                        if (IsSmoking)
                        {
                            litDisplaySmoking.Text = "Yes";
                            rdbLIsSmoking.SelectedIndex = 0;
                        }
                        else
                        {
                            litDisplaySmoking.Text = "No";
                            rdbLIsSmoking.SelectedIndex = 1;
                        }
                    }
                    else
                    {
                        litDisplaySmoking.Text = "No";
                        rdbLIsSmoking.SelectedIndex = 1;
                    }

                    ltrChkPmtRoomNo.Text = lblDisplayRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(drResData["RoomNo"]));

                    if (Convert.ToString(drResData["RoomID"]) != string.Empty && Convert.ToString(drResData["RoomID"]) != Guid.Empty.ToString())
                    {
                        this.RoomID = new Guid(Convert.ToString(drResData["RoomID"]));
                    }

                    txtCompanyName.Text = Convert.ToString(drResData["CompanyName"]);
                    txtCompanyDepartment.Text = Convert.ToString(drResData["Department"]);
                    txtEmployeeID.Text = Convert.ToString(drResData["EmployeeID"]);

                    //litDisplayMobile.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(drResData["Phone1"])));
                    txtGuestEmail.Text = Convert.ToString(drResData["Email"]);
                    txtAddressLine1.Text = Convert.ToString(drResData["Add1"]);
                    txtAddressLine2.Text = Convert.ToString(drResData["Add2"]);
                    txtCityName.Text = Convert.ToString(drResData["CityName"]);
                    txtZipCode.Text = Convert.ToString(drResData["ZipCode"]);
                    txtStateName.Text = Convert.ToString(drResData["StateName"]);
                    txtCountryName.Text = Convert.ToString(drResData["CountryName"]);
                    txtStandardInstruction.Text = Convert.ToString(drResData["StandardInstruction"]);
                    txtSpecificInstruction.Text = Convert.ToString(drResData["SpecificNote"]);

                    txtFirstName.Text = Convert.ToString(drResData["FName"]);
                    txtLastName.Text = Convert.ToString(drResData["LName"]);

                    ddlNationality.SelectedIndex = ddlNationality.Items.FindByValue(Convert.ToString(drResData["Nationality"])) != null ? ddlNationality.Items.IndexOf(ddlNationality.Items.FindByValue(Convert.ToString(drResData["Nationality"]))) : 0;
                    if (ddlNationality.SelectedIndex != 0 && ddlNationality.SelectedValue.ToUpper() != "INDIAN")
                        linkForeignNationalpopup.Visible = true;
                    else
                        linkForeignNationalpopup.Visible = false;

                    ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(drResData["Title"])) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(drResData["Title"]))) : 0;
                    ddlCompanySector.SelectedIndex = ddlCompanySector.Items.FindByValue(Convert.ToString(drResData["CompanySector"])) != null ? ddlCompanySector.Items.IndexOf(ddlCompanySector.Items.FindByValue(Convert.ToString(drResData["CompanySector"]))) : 0;
                    ddlWorkTiming.SelectedIndex = ddlWorkTiming.Items.FindByValue(Convert.ToString(drResData["WorkTiming"])) != null ? ddlWorkTiming.Items.IndexOf(ddlWorkTiming.Items.FindByValue(Convert.ToString(drResData["WorkTiming"]))) : 0;
                    ddlGuestType.SelectedIndex = ddlGuestType.Items.FindByValue(Convert.ToString(drResData["Guest_TypeID"])) != null ? ddlGuestType.Items.IndexOf(ddlGuestType.Items.FindByValue(Convert.ToString(drResData["Guest_TypeID"]))) : 0;

                    if (Convert.ToString(drResData["ExpectedCheckOutDate"]) != null && Convert.ToString(drResData["ExpectedCheckOutDate"]) != "")
                    {
                        DateTime dtExpectedCheckOutDate = Convert.ToDateTime(Convert.ToString(drResData["ExpectedCheckOutDate"]));
                        // lblExpectedCheckOutDate.Text = "Expected Check out date : " + Convert.ToString(this.dtCheckInDate.AddMonths(Convert.ToInt32(ddlExpectedStay.SelectedValue)).ToString(clsSession.DateFormat));
                        //lblExpectedCheckOutDate.Visible = true;
                        //lblExpectedCheckOutDate.Text = "Expected Check out date : " + Convert.ToString(dtExpectedCheckOutDate.ToString(clsSession.DateFormat));
                        ddlExpectedStay.SelectedIndex = ddlExpectedStay.Items.FindByValue(Convert.ToString(drResData["ExpectedMonthValue"])) != null ? ddlExpectedStay.Items.IndexOf(ddlExpectedStay.Items.FindByValue(Convert.ToString(drResData["ExpectedMonthValue"]))) : 0;
                        ddlExpectedStay_SlectedIndexChanged(null, null);
                    }
                    else
                    {
                        lblExpectedCheckOutDate.Text = "";
                        lblExpectedCheckOutDate.Visible = false;
                    }
                    ltrChkPmtGuestName.Text = lblGuestNameInRegistrationTab.Text = Convert.ToString(ddlTitle.SelectedItem.Text) + " " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();

                    if (Convert.ToString(drResData["Phone1"]) != "" && Convert.ToString(drResData["Phone1"]) != null)
                    {
                        string[] words = Convert.ToString(drResData["Phone1"]).Split('-');
                        if (words.Length > 1)
                        {
                            txtCountryMobileCode.Text = Convert.ToString(words[0]);
                            txtMobile.Text = Convert.ToString(words[1]);
                        }
                        else
                        {
                            txtCountryMobileCode.Text = Convert.ToString(words[0]);
                            txtMobile.Text = "";
                        }
                    }
                    else
                    {
                        txtCountryMobileCode.Text = "";
                        txtMobile.Text = "";
                    }
                }
                else
                {
                    litDisplayCheckInDate.Text = litDisplayCheckOutDate.Text = litDisplayRoomType.Text = litDisplayRateCard.Text = litDisplayAdult.Text = litDisplayChild.Text = litDisplayInf.Text = "";
                    ddlTitle.SelectedIndex = ddlCompanySector.SelectedIndex = ddlWorkTiming.SelectedIndex = ddlGuestType.SelectedIndex = 0;
                    txtFirstName.Text = txtLastName.Text = txtCountryMobileCode.Text = txtMobile.Text = txtAddressLine1.Text = txtAddressLine2.Text = txtCityName.Text = txtZipCode.Text = txtStateName.Text = txtCountryName.Text = txtSpecificInstruction.Text = txtStandardInstruction.Text = "";
                    rdbIsPicup.SelectedIndex = 1;
                    ddlNationality.SelectedIndex = 0;
                }
            }
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
            this.ResInfraServiceChargeAmount = InfraServiceCharge;
            this.PaidInfraServiceChargeAmount = PaidInfraServiceCharge;
            this.FoodChargeAmount = FoodCharges;
            this.PaidFoodChargeAmount = PaidFoodCharges;
            this.ElectricityChargeAmount = ElectricityCharges;
            this.PaidElectricityChargeAmount = PaidElectricityCharges;

            lblDisplayNoOfDaysPmtTab.Text = lblDisplayNoOfDays.Text = Convert.ToString(NoofDays);
            lblResTimeRoomRentPmtTab.Text = lblResTimeRoomRent.Text = Convert.ToString(strRoomRent);
            lblResTimeTaxPmtTab.Text = lblResTimeTax.Text = Convert.ToString(strTax);
            lblResTimeInfraServiceChargesPmtTab.Text = lblResTimeInfraServiceCharges.Text = Convert.ToString(InfraServiceCharge);
            lblResTimeFoodChargesPmtTab.Text = lblResTimeFoodCharges.Text = Convert.ToString(FoodCharges);
            lblResTimeElectricityChargesPmtTab.Text = lblResTimeElectricityCharges.Text = Convert.ToString(ElectricityCharges);

            //Reservation time total charges(Room Rent)
            lblResTimeTotalChargesPmtTab.Text = lblResTimeTotalCharges.Text = Convert.ToString(strTotalAmount);
            //Reservation time total Deposit
            lblResTimeDepositAmountPmtTab.Text = lblResTimeDepositAmount.Text = Convert.ToString(strDepositAmount);

            //Reservation time total Amount payable(Room Rent + Deposit)
            TotalAmountPayable = TotalAmount + DepositAmount;
            lblResTimeTotalPayableAmountPmtTab.Text = lblResTimeTotalPayableAmount.Text = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            //Total Deposit received
            lblResTimePaidAmountPmtTab.Text = PaidDeposit.ToString().Substring(0, PaidDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            if (TotalAmountPayable >= PaidDeposit)
            {
                NetAmountToPay = TotalAmountPayable - PaidDeposit;
                lblResTimeAmountToPayPmtTab.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            //Total payment received (Deposit + other payment)
            lblTotalPaymentReceived.Text = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            //Compare total payable amount and Total received amount for Net amount is Balance or Due.
            if (TotalAmountPayable >= TotalPaymentReceived)
            {
                NetAmountToPay = TotalAmountPayable - TotalPaymentReceived;
                lblAmountBalanceOrDueText.Text = "Balance Amount (Due)";
                txtPaymentAmount.Text = lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text);

                if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "DEPOSIT")
                {
                    Decimal dcmlNetDepositToPay = DepositAmount - TotalPaymentReceived;
                    if (dcmlNetDepositToPay >= 0)
                        txtPaymentAmount.Text = dcmlNetDepositToPay.ToString().Substring(0, dcmlNetDepositToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    else
                        txtPaymentAmount.Text = "0";

                    this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text);
                }
            }
            else
            {
                NetAmountToPay = TotalPaymentReceived - TotalAmountPayable;
                lblAmountBalanceOrDueText.Text = "Balance Amount";
                lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            btnPrintReceipt.Visible = true;
            if (dtPaidAmountInfo != null && dtPaidAmountInfo.Rows.Count > 0)
            {
                gvPaymentList.DataSource = dtPaidAmountInfo;
                gvPaymentList.DataBind();
            }
            else
            {
                btnPrintReceipt.Visible = false;
                gvPaymentList.DataSource = null;
                gvPaymentList.DataBind();
            }

            if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT")
            {
                if ((Convert.ToDecimal(lblTotalPaymentReceived.Text.Trim()) + (Convert.ToDecimal(hdnAmtPayByCmp.Value)) >= Convert.ToDecimal(lblResTimeTotalPayableAmount.Text.Trim())))
                {
                    ////If reservation already checked in, then don't make btnCheckInReservatin button visible.
                    if (this.ReservationStatusValue == 32)
                    {
                        btnCheckInReservatin.Visible = false;
                        btnBackToListFromPmtView.Visible = true;
                    }
                    else
                    {
                        btnCheckInReservatin.Visible = true;
                        btnBackToListFromPmtView.Visible = false;
                    }
                }
                else
                    btnCheckInReservatin.Visible = false;
            }
            else
                ltrMinAmtForConfirmReservation.Text = "Min. amount for confirm reservation: <b>" + strDepositAmount + "</b>";

            if (Convert.ToDecimal(hdnAmtPayByCmp.Value) > 0)
            {
                if (txtPaymentAmount.Text.Trim() == string.Empty)
                    txtPaymentAmount.Text = "0";

                lblAmountBalanceOrDueText.Text = "Balance Amount (Bill to Company)";
                decimal dcmlTemp = Convert.ToDecimal(txtPaymentAmount.Text) - Convert.ToDecimal(hdnAmtPayByCmp.Value);
                txtPaymentAmount.Text = dcmlTemp.ToString().Substring(0, dcmlTemp.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT" && this.ReservationStatusValue == 32)
            {
                txtPaymentAmount.Text = "0";
                this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text);
            }
        }

        private void BindRoomReservationChart()
        {
            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            DateTime dtToSetCheckInDate = new DateTime();
            DateTime dtToSetCheckOutDate = new DateTime();

            DateTime? dtCheckInDate = null;
            DateTime? dtCheckoutDate = null;
            Guid? RoomTypeID = null;

            if (txtSearchFromDate.Text.Trim() != "")
                dtToSetCheckInDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            if (txtSearchToDate.Text.Trim() != "")
                dtToSetCheckOutDate = DateTime.ParseExact(txtSearchToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            if (ddlSearchRoomType.SelectedIndex != 0)
                RoomTypeID = new Guid(ddlSearchRoomType.SelectedValue);

            List<ReservationConfig> lstReservation = null;
            ReservationConfig objReservationConfig = new ReservationConfig();
            objReservationConfig.IsActive = true;
            objReservationConfig.CompanyID = clsSession.CompanyID;
            objReservationConfig.PropertyID = clsSession.PropertyID;
            lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

            DateTime dtStandardCheckInTime;
            DateTime dtStandardCheckOutTime;

            if (lstReservation.Count != 0)
            {
                dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);

                dtCheckInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                dtCheckoutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
            }

            StringBuilder strBldr = new StringBuilder();

            DataSet dsRoomData = ReservationBLL.GetRoomResrvationChartData(dtCheckInDate, dtCheckoutDate, RoomTypeID, clsSession.PropertyID, clsSession.CompanyID, 24);

            if (dsRoomData.Tables.Count > 0 && dsRoomData.Tables[0].Rows.Count > 0)
            {
                strBldr.Append("<table id='tblchart' name='tblchart' cellpadding='0' cellspacing='1' class='maintable' width='100%'>");

                for (int i = 0; i < dsRoomData.Tables[0].Rows.Count + 1; i++)
                {
                    strBldr.Append("<tr>");
                    for (int j = 0; j < dsRoomData.Tables[0].Columns.Count - 2; j++)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                                strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
                            else
                            {
                                DateTime dtDate = Convert.ToDateTime(Convert.ToString(dsRoomData.Tables[0].Columns[j + 2].ColumnName));
                                strBldr.Append("<td class='cellheader'>" + (dtDate.ToString("dd-MM")) + "<br />" + Convert.ToString(dtDate.ToString("ddd")) + "</td>");
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                strBldr.Append("<td class='roomname' style=\"cursor:pointer;\" onclick=\"fnClick('" + Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomID"]) + "','" + Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]) + "');\">" + (clsCommon.GetFormatedRoomNumber(Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]))) + "</td>");
                            }
                            else
                            {
                                string strData = Convert.ToString(dsRoomData.Tables[0].Rows[i - 1][j + 2]);
                                if (strData != string.Empty)
                                {
                                    string[] strResult = strData.Split('~');
                                    if (strResult.Length != 0)
                                    {
                                        string strSymphonyValue = Convert.ToString(strResult[0]);
                                        string strCompanyName = Convert.ToString(strResult[2]);
                                        string strGuestName = Convert.ToString(strResult[3]);
                                        string strCalss = "availableroom";

                                        switch (Convert.ToInt32(strSymphonyValue))
                                        {
                                            case 27:
                                                strCalss = "";
                                                break;
                                            case (28):
                                                strCalss = "bookedroom";
                                                break;
                                            case (29):
                                                strCalss = "";
                                                break;
                                            case (32):
                                                strCalss = "checkinroom";
                                                break;
                                            case (33):
                                                strCalss = "";
                                                break;
                                            case (34):
                                                strCalss = "";
                                                break;
                                        }
                                        strCompanyName = strCompanyName != "" ? " | " + strCompanyName : "";
                                        string srtTitle = strGuestName + strCompanyName;
                                        strBldr.Append("<td class='" + strCalss + "' title='" + srtTitle + "'></td>");
                                    }
                                    else
                                        strBldr.Append("<td class='availableroom'></td>");
                                }
                                else
                                    strBldr.Append("<td class='availableroom'></td>");
                            }
                        }
                    }
                    strBldr.Append("</tr>");
                }
                strBldr.Append("</table>");

                dvChart.Visible = true;
                dvChart.InnerHtml = strBldr.ToString();
            }
        }

        private void BindRoomType()
        {
            string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";
            DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);

            ddlSearchRoomType.Items.Clear();
            if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
            {
                ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
                ddlSearchRoomType.DataTextField = "RoomTypeName";
                ddlSearchRoomType.DataValueField = "RoomTypeID";
                ddlSearchRoomType.DataBind();

                ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
        }

        private void ClearControl()
        {
            ddlPreference.SelectedIndex = 0;
            txtPreferenceDetails.Text = txtPreferenceDescription.Text = txtManagementNote.Text = "";
        }

        public string TruncateString(string TruncString, int NumberOfCharacter)
        {
            string NewStr;
            if (TruncString.Length > NumberOfCharacter + 1)
            {
                NewStr = TruncString.Substring(0, NumberOfCharacter) + "...";
            }
            else
            {
                NewStr = TruncString;
            }

            return NewStr;
        }

        private void BindDDLPreference()
        {
            ddlPreference.Items.Clear();
            DataSet dsData = SQT.Symphony.BusinessLogic.FrontDesk.BLL.PreferenceMasterBLL.GetAllForList(clsSession.PropertyID, clsSession.CompanyID);
            if (dsData.Tables.Count != 0 && dsData.Tables[0].Rows.Count > 0)
            {
                ddlPreference.DataSource = dsData.Tables[0];
                ddlPreference.DataTextField = "PreferenceName";
                ddlPreference.DataValueField = "PreferenceID";
                ddlPreference.DataBind();
                ddlPreference.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlPreference.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
        }

        private void BindGuestPreferences()
        {
            if (this.GuestID != Guid.Empty)
            {
                DataSet dsGuestPref = GuestPreferenceBLL.GetAllForGuestPreferenceList(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                gvGuestPreferences.DataSource = dsGuestPref;
                gvGuestPreferences.DataBind();
            }
        }

        private void BindGuestNote()
        {
            if (this.GuestID != Guid.Empty)
            {
                DataSet dtGuestManNote = GuestManagementNoteBLL.GetAllForGuestManagementNoteList(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                gvFrontDesksNote.DataSource = dtGuestManNote;
                gvFrontDesksNote.DataBind();
            }
        }

        private string BindPropertyAddress()
        {
            DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
            if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(dsPropertyAddress.Tables[0].Rows[0]["FullAddress"]);
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion Private Method

        #region Control Event
        protected void ddlExpectedStay_SlectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlExpectedStay.SelectedIndex > 0)
            {
                lblExpectedCheckOutDate.Text = "Expected Check out date : " + Convert.ToString(this.dtCheckInDate.AddMonths(Convert.ToInt32(ddlExpectedStay.SelectedValue)).ToString(clsSession.DateFormat));
                lblExpectedCheckOutDate.Visible = true;
            }
            else
            {
                lblExpectedCheckOutDate.Text = "";
                lblExpectedCheckOutDate.Visible = false;

            }

        }
        protected void ddlNationality_selectedindexchanged(object sender, EventArgs e)
        {
            if (ddlNationality.SelectedIndex != 0 && ddlNationality.SelectedValue.ToUpper() != "INDIAN")
                linkForeignNationalpopup.Visible = true;
            else
                linkForeignNationalpopup.Visible = false;
        }

        protected void btnSaveForeignNationalInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //if (Convert.ToString(txtPassportDateOfExpiry.Text.Trim()) != "")
                    //    objForeignNational.PassportDateOfExpiry = DateTime.ParseExact(Convert.ToString(txtPassportDateOfExpiry.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    //else
                    //    objForeignNational.PassportDateOfExpiry = null;

                    CultureInfo objCultureInfoForValidation = CultureInfo.CurrentCulture;

                    DateTime PassportDateOfIssue = DateTime.ParseExact(Convert.ToString(txtPassportDateOfIssue.Text.Trim()), clsSession.DateFormat, objCultureInfoForValidation);
                    DateTime VisaDateOfIssue = DateTime.ParseExact(Convert.ToString(txtVisaDateofIssue.Text.Trim()), clsSession.DateFormat, objCultureInfoForValidation);
                    DateTime PassportDateOfExpiry = DateTime.ParseExact(Convert.ToString(txtPassportDateOfExpiry.Text.Trim()), clsSession.DateFormat, objCultureInfoForValidation);
                    DateTime VisaDateOfExpiry = DateTime.ParseExact(Convert.ToString(txtVisaDateofExpiry.Text.Trim()), clsSession.DateFormat, objCultureInfoForValidation);

                    bool IsToShowmsg = false;
                    string msgToShow = string.Empty;
                    if (PassportDateOfIssue > DateTime.Now)
                    {
                        IsToShowmsg = true;
                        msgToShow = "Passport issue date should be less than or equal to today's date";
                    }
                    else if (VisaDateOfIssue > DateTime.Now)
                    {
                        IsToShowmsg = true;
                        msgToShow = "Visa issue date should be less than or equal to today's date";
                    }
                    else if (PassportDateOfExpiry < DateTime.Now)
                    {
                        IsToShowmsg = true;
                        msgToShow = "Passport Expiry date should be greater than or equal to today's date";
                    }
                    else if (VisaDateOfExpiry < DateTime.Now)
                    {
                        IsToShowmsg = true;
                        msgToShow = "Visa Expiry date should be greater than or equal to today's date";
                    }
                    else if (PassportDateOfIssue >= PassportDateOfExpiry)
                    {
                        IsToShowmsg = true;
                        msgToShow = "Passport expiery date should be greater than passport issue date";
                    }
                    else if (VisaDateOfIssue >= VisaDateOfExpiry)
                    {
                        IsToShowmsg = true;
                        msgToShow = "Visa expiery date should be greater than visa issue date";
                    }
                    else
                    {
                        IsToShowmsg = false;
                        msgToShow = string.Empty;
                    }


                    if (IsToShowmsg == true && msgToShow != string.Empty)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show(msgToShow);
                        mpeForeignNationalInfo.Show();
                        return;
                    }

                    ForeignNationalInfo objForeignNational = new ForeignNationalInfo();
                    objForeignNational.CompanyID = clsSession.CompanyID;
                    objForeignNational.CreatedBy = clsSession.UserID;
                    objForeignNational.CreatedOn = DateTime.Now;

                    if (ddlIdtypeForeignNatinal.SelectedIndex != 0)
                        objForeignNational.IDType = new Guid(ddlIdtypeForeignNatinal.SelectedValue);


                    if (ddlNationality.SelectedIndex != 0)
                        objForeignNational.Nationality = ddlNationality.SelectedValue;
                    else
                        objForeignNational.Nationality = null;
                    objForeignNational.GuestID = this.GuestID;
                    objForeignNational.PropertyID = clsSession.PropertyID;
                    objForeignNational.ReservationID = this.ReservationID;
                    if (Convert.ToString(txtPassportNumber.Text).Trim() != string.Empty)
                        objForeignNational.PassportNumber = clsCommon.GetUpperCaseText(txtPassportNumber.Text.Trim());
                    else
                        objForeignNational.PassportNumber = null;

                    if (Convert.ToString(txtPassportPlaceOfIssue.Text).Trim() != string.Empty)
                        objForeignNational.PassportPlaceOfIssue = clsCommon.GetUpperCaseText(txtPassportPlaceOfIssue.Text.Trim());
                    else
                        objForeignNational.PassportPlaceOfIssue = null;

                    if (Convert.ToString(txtVisaNo.Text).Trim() != string.Empty)
                        objForeignNational.VisaNumber = clsCommon.GetUpperCaseText(txtVisaNo.Text.Trim());
                    else
                        objForeignNational.VisaNumber = null;

                    if (Convert.ToString(txtVisaplaceofissue.Text).Trim() != string.Empty)
                        objForeignNational.VisaPlaceOfIssue = clsCommon.GetUpperCaseText(txtVisaplaceofissue.Text.Trim());
                    else
                        objForeignNational.VisaPlaceOfIssue = null;

                    if (Convert.ToString(txtVisatype.Text).Trim() != string.Empty)
                        objForeignNational.VisaType = clsCommon.GetUpperCaseText(txtVisatype.Text.Trim());
                    else
                        objForeignNational.VisaType = null;

                    if (Convert.ToString(txtVisaPurpose.Text).Trim() != string.Empty)
                        objForeignNational.PurposeOfVisa = clsCommon.GetUpperCaseText(txtVisaPurpose.Text.Trim());
                    else
                        objForeignNational.PurposeOfVisa = null;

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (Convert.ToString(txtPassportDateOfExpiry.Text.Trim()) != "")
                        objForeignNational.PassportDateOfExpiry = DateTime.ParseExact(Convert.ToString(txtPassportDateOfExpiry.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    else
                        objForeignNational.PassportDateOfExpiry = null;

                    if (Convert.ToString(txtPassportDateOfIssue.Text.Trim()) != "")
                        objForeignNational.PassportDateOfIssue = DateTime.ParseExact(Convert.ToString(txtPassportDateOfIssue.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    else
                        objForeignNational.PassportDateOfIssue = null;

                    if (Convert.ToString(txtVisaDateofExpiry.Text.Trim()) != "")
                        objForeignNational.VisaDateOfExpiry = DateTime.ParseExact(Convert.ToString(txtVisaDateofExpiry.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    else
                        objForeignNational.VisaDateOfExpiry = null;

                    if (Convert.ToString(txtVisaDateofIssue.Text.Trim()) != "")
                        objForeignNational.VisaDateOfIssue = DateTime.ParseExact(Convert.ToString(txtVisaDateofIssue.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    else
                        objForeignNational.VisaDateOfIssue = null;

                    if (!Directory.Exists(Server.MapPath("~/PassportScan")))
                        Directory.CreateDirectory(Server.MapPath("~/PassportScan"));

                    if (!Directory.Exists(Server.MapPath("~/Visascan")))
                        Directory.CreateDirectory(Server.MapPath("~/Visascan"));


                    if (ddlNationality.SelectedIndex != 0)
                        objForeignNational.Nationality = ddlNationality.SelectedValue;
                    else
                        objForeignNational.Nationality = null;

                    string strDocumentNameTemp = "";
                    if (fuPassportscan1.FileName != "")
                    {
                        strDocumentNameTemp = "";
                        strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fuPassportscan1.FileName.Replace(" ", "_");
                        fuPassportscan1.SaveAs(Server.MapPath("~/PassportScan/" + strDocumentNameTemp));
                        objForeignNational.ScannedPassport1 = strDocumentNameTemp;
                    }

                    if (fupPassportscan2.FileName != "")
                    {
                        strDocumentNameTemp = "";
                        strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fupPassportscan2.FileName.Replace(" ", "_");
                        fuPassportscan1.SaveAs(Server.MapPath("~/PassportScan/" + strDocumentNameTemp));
                        objForeignNational.ScannedPassport2 = strDocumentNameTemp;
                    }

                    if (fupVisaScan.FileName != "")
                    {
                        strDocumentNameTemp = "";
                        strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fupVisaScan.FileName.Replace(" ", "_");
                        fuPassportscan1.SaveAs(Server.MapPath("~/Visascan/" + strDocumentNameTemp));
                        objForeignNational.ScannedVisa = strDocumentNameTemp;
                    }

                    int intDurationofStay = 0;
                    intDurationofStay = Reservation_GetTotalDays(dtCheckInDate, dtCheckOutDate);
                    if (intDurationofStay > 0)
                        objForeignNational.DurationOfStay = intDurationofStay;

                    ForeignNationalInfoBLL.Save(objForeignNational);
                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objForeignNational.ToString(), objForeignNational.ToString(), "res_ForeignNationalInfo", null);

                    this.IsForeignNationalInfoSaved = true;
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCheckInSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {


                    /* Do not delete thiese commented lines b'cas it will use in future requirement.
                    if (ancViewGuestPhoto.Visible == false)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Please upload guest photo.");
                        return;
                    }
                    */

                    if (ddlNationality.SelectedValue.ToString().ToUpper() != "INDIAN")
                    {
                        if (!this.IsForeignNationalInfoSaved)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Please save foreign national information.");
                            return;
                        }
                    }
                    else if (ancViewIDDocument1.Visible == false)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Please upload guest document-1.");
                        return;
                    }

                    ////Check Birth date is valid or not?
                    try
                    {
                        DateTime dtToCheck = new DateTime(Convert.ToInt32(ddlDOBYear.SelectedValue), Convert.ToInt32(ddlDOBMonth.SelectedValue), Convert.ToInt32(ddlDOBDate.SelectedValue));
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Invalid Date of Birth.");
                        return;
                    }
                    ////Check Birth date is valid or not?


                    ////SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuestToCheckDPLKT = new BusinessLogic.FrontDesk.DTO.Guest();
                    ////objGuestToCheckDPLKT.PropertyID = clsSession.PropertyID;
                    ////objGuestToCheckDPLKT.CompanyID = clsSession.CompanyID;
                    ////objGuestToCheckDPLKT.FName = txtFirstName.Text.Trim();
                    ////objGuestToCheckDPLKT.LName = txtLastName.Text.Trim();
                    ////List<SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest> lstGuestWithSameName = GuestBLL.GetAll(objGuestToCheckDPLKT);

                    ////for (int i = 0; i < lstGuestWithSameName.Count; i++)
                    ////{
                    ////    string[] strArrayPhone = Convert.ToString(lstGuestWithSameName[i].Phone1).Split('-');
                    ////    if (strArrayPhone.Length > 1)
                    ////    {
                    ////        if (txtMobile.Text.Trim() == Convert.ToString(strArrayPhone[1]) && Convert.ToString(this.GuestID) != Convert.ToString(lstGuestWithSameName[i].GuestID))
                    ////        {
                    ////            return;
                    ////            //this.ExistingGuestID = lstGuestWithSameName[i].GuestID;
                    ////            //this.ExistingGuestAddressID = (Guid)lstGuestWithSameName[i].AddressID;
                    ////            //break;
                    ////        }
                    ////    }
                    ////}


                    ////// This will not to check, b'cas Room will assign after payment is done.
                    ////// Assign Room to this Reservation. 
                    //if ((hdnRoomID.Value == string.Empty || hdnRoomID.Value == Guid.Empty.ToString()) && this.RoomID == Guid.Empty)
                    //{
                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    //    MessageBox.Show("Room is not assign to this reservation, please assign room.");
                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                    //    return;
                    //}

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                    objReservation.UpdatedBy = clsSession.UserID;
                    objReservation.UpdatedOn = DateTime.Now;
                    //If Select from room assign grid, then check it's availability
                    if (hdnRoomID.Value != string.Empty && hdnRoomID.Value != Guid.Empty.ToString())
                    {
                        DateTime? checkInDate = null;
                        DateTime? checkOutDate = null;

                        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                        DateTime dtToSetCheckInDate = new DateTime();
                        DateTime dtToSetCheckOutDate = new DateTime();

                        dtToSetCheckInDate = DateTime.ParseExact(litDisplayCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        dtToSetCheckOutDate = DateTime.ParseExact(litDisplayCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                        //// Get Standard check in/check out time
                        List<ReservationConfig> lstReservation = null;
                        ReservationConfig objReservationConfig = new ReservationConfig();
                        objReservationConfig.IsActive = true;
                        objReservationConfig.CompanyID = clsSession.CompanyID;
                        objReservationConfig.PropertyID = clsSession.PropertyID;
                        lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

                        DateTime dtStandardCheckInTime;
                        DateTime dtStandardCheckOutTime;

                        if (lstReservation.Count != 0)
                        {
                            dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                            dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);

                            checkInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                            checkOutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                        }

                        DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, this.RoomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);

                        DataRow[] drRoomAvbl = dsIsRoomAvbl.Tables[0].Select("RoomID = '" + Convert.ToString(hdnRoomID.Value) + "'");

                        if (drRoomAvbl.Length == 0)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Selected room is not available, please select other room.");
                            return;
                        }

                        objReservation.RoomID = new Guid(hdnRoomID.Value);
                    }

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuest = GuestBLL.GetByPrimaryKey(this.GuestID);
                    List<ProjectTerm> lstGenders = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GENDER");

                    objGuest.CompanyName = clsCommon.GetUpperCaseText(txtCompanyName.Text.Trim());
                    objGuest.Department = clsCommon.GetUpperCaseText(txtCompanyDepartment.Text.Trim());
                    objGuest.EmployeeID = txtEmployeeID.Text.Trim();
                    objGuest.JobTitle = clsCommon.GetUpperCaseText(txtJobTitle.Text.Trim());
                    objGuest.WorkLocation = clsCommon.GetUpperCaseText(txtWorkLocation.Text.Trim());

                    if (ddlCompanySector.SelectedIndex != 0)
                        objGuest.CompanySector = new Guid(ddlCompanySector.SelectedValue);

                    if (ddlWorkTiming.SelectedIndex != 0)
                        objGuest.WorkTiming = new Guid(ddlWorkTiming.SelectedValue);


                    if (ddlExpectedStay.SelectedIndex != 0)
                        objReservation.ExpectedCheckOutDate = dtCheckInDate.AddMonths(Convert.ToInt32(ddlExpectedStay.SelectedValue));

                    if (ddlNationality.SelectedIndex != 0)
                        objGuest.Nationality = ddlNationality.SelectedValue;
                    else
                        objGuest.Nationality = null;

                    if (ddlTitle.SelectedIndex != 0)
                        objGuest.Title = Convert.ToString(ddlTitle.SelectedItem.Text);
                    else
                        objGuest.Title = null;

                    objGuest.FName = clsCommon.GetUpperCaseText(txtFirstName.Text.Trim());
                    objGuest.LName = clsCommon.GetUpperCaseText(txtLastName.Text.Trim());
                    objGuest.GuestFullName = clsCommon.GetUpperCaseText(Convert.ToString(ddlTitle.SelectedItem.Text) + " " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());

                    if (ddlGuestType.SelectedIndex != 0)
                        objGuest.Guest_TypeID = new Guid(ddlGuestType.SelectedValue);
                    else
                        objGuest.Guest_TypeID = null;

                    if (txtCountryMobileCode.Text.Trim() == "")
                        objGuest.Phone1 = "-" + txtMobile.Text.Trim();
                    else
                        objGuest.Phone1 = txtCountryMobileCode.Text.Trim() + "-" + txtMobile.Text.Trim();

                    objGuest.Email = clsCommon.GetUpperCaseText(txtGuestEmail.Text.Trim());

                    Address GuestAddress = new Address();
                    GuestAddress = AddressBLL.GetByPrimaryKey((Guid)objGuest.AddressID);

                    GuestAddress.Add1 = clsCommon.GetUpperCaseText(txtAddressLine1.Text.Trim());
                    GuestAddress.Add2 = clsCommon.GetUpperCaseText(txtAddressLine2.Text.Trim());
                    GuestAddress.ZipCode = clsCommon.GetUpperCaseText(txtZipCode.Text.Trim());
                    GuestAddress.IsActive = true;
                    GuestAddress.CompanyID = clsSession.CompanyID;
                    GuestAddress.IsSynch = false;
                    GuestAddress.CountryID = clsCommon.Country(txtCountryName.Text.Trim());
                    GuestAddress.StateID = clsCommon.State(txtStateName.Text.Trim());
                    GuestAddress.CityID = clsCommon.City(txtCityName.Text.Trim());

                    if (ddlTitle.SelectedIndex != 0)
                    {
                        if (Convert.ToString(ddlTitle.SelectedValue).ToUpper() == "MR.")
                        {
                            if (lstGenders[0].DisplayTerm.ToUpper() == "MALE")
                                objGuest.Gender_TermID = lstGenders[0].TermID;
                            else
                                objGuest.Gender_TermID = lstGenders[1].TermID;
                        }
                        else
                            objGuest.Gender_TermID = lstGenders[1].TermID;
                    }

                    if (ddlGuestType.SelectedIndex != 0)
                        objGuest.Guest_TypeID = new Guid(ddlGuestType.SelectedValue);
                    else
                        objGuest.Guest_TypeID = null;
                    //// Object of Guest End

                    if (txtStandardInstruction.Text.Trim() != string.Empty)
                        objReservation.SpecificNote = clsCommon.GetUpperCaseText(txtSpecificInstruction.Text.Trim());
                    else
                        objReservation.SpecificNote = null;

                    objReservation.IsToPickup = (rdbIsPicup.SelectedValue.ToString().ToUpper() == "YES");
                    objReservation.ActualCheckInDate = DateTime.Now;



                    objGuest.IsSmoking = (rdbLIsSmoking.SelectedValue.ToString().ToUpper() == "YES");

                    objGuest.DOB = new DateTime(Convert.ToInt32(ddlDOBYear.SelectedValue), Convert.ToInt32(ddlDOBMonth.SelectedValue), Convert.ToInt32(ddlDOBDate.SelectedValue));

                    if (ddlBloodGroup.SelectedIndex != 0)
                        objGuest.BloodGroup = ddlBloodGroup.SelectedValue;

                    if (ddlMealPreference.SelectedIndex != 0)
                        objGuest.MealPreference = new Guid(ddlMealPreference.SelectedValue);

                    objGuest.ParentName = clsCommon.GetUpperCaseText(txtParentName.Text.Trim());
                    objGuest.ParentContactNo = clsCommon.GetUpperCaseText(txtParentCntcNumber.Text.Trim());
                    objGuest.LocalContactPerson = clsCommon.GetUpperCaseText(txtLocalContactPerson.Text.Trim());
                    objGuest.LocalContactNo = clsCommon.GetUpperCaseText(txtLocalContactNumber.Text.Trim());

                    CheckinTimeLog objCheckInLog = new CheckinTimeLog();
                    objCheckInLog.CheckInBy = clsSession.UserID;
                    objCheckInLog.CheckInStartTime = Convert.ToDateTime(this.CheckInStartTime);
                    objCheckInLog.CheckInEndTime = DateTime.Now;
                    objCheckInLog.CompanyID = clsSession.CompanyID;
                    objCheckInLog.CreatedOn = DateTime.Now;
                    objCheckInLog.PropertyID = clsSession.PropertyID;

                    //// Don't update reservation status with Check in here, b'cas it will done at the time of taking payment.
                    //objReservation.RestStatus_TermID = 32;
                    objReservation.UpdateMode = "RESERVATION CHECKIN";
                    ReservationBLL.Update(objReservation, objGuest, GuestAddress, objCheckInLog);
                    btnCheckinVoucher.Visible = true;
                    lblCheckinEndTime.Text = DateTime.Now.ToString(clsSession.DateFormat) + " " + DateTime.Now.ToString(clsSession.TimeFormat);

                    /*
                    //If room charge is posted for this.ReservationID, then no need to post it again.
                    if (this.RoomChargePostTimeReservationID != this.ReservationID)
                    {
                        //Post check in date's accomodatio charge Start
                        BlockDateRate objToGet = new BlockDateRate();
                        objToGet.ReservationID = this.ReservationID;
                        objToGet.BlockDate = DateTime.Today;
                        List<BlockDateRate> lstBlockDates = BlockDateRateBLL.GetAll(objToGet);
                        if (lstBlockDates != null && lstBlockDates.Count > 0)
                        {
                            if (lstBlockDates[0].RoomRate != null)
                            {
                                decimal dcmlBaseRate = Convert.ToDecimal(lstBlockDates[0].RoomRate);

                                TransactionBLL.PostRoomCharge(DateTime.Today, this.ReservationID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlBaseRate, clsSession.CompanyID);
                            }
                        }

                        //Set this.RoomChargePostTimeReservationID's value as this.ReservationID when roomcharge is posted for one reservation.
                        this.RoomChargePostTimeReservationID = this.ReservationID;
                        //Post check in date's accomodatio charge End
                    }
                     * */


                    //If Room is assigned during This check in process, then set its value to this.RoomID
                    if (Convert.ToString(hdnRoomID.Value) != string.Empty && Convert.ToString(hdnRoomID.Value) != Guid.Empty.ToString())
                    {
                        this.RoomID = new Guid(hdnRoomID.Value);
                    }

                    //Hide Assign Room after reservation checked in.
                    btnAssignRoom.Visible = false;

                    //DON'T Make payment proceed's button enable after checking in reservation.
                    //DISCUSSED IN MEETING 8 DEC 2012.
                    //btnProceedForPayment.Visible = true;

                    IsMessage = true;
                    lblFeedbackMsg.Text = "Reservation Checked In successfully.";

                    IsGuestDocMessage = true;
                    lblDocMessage.Text = "You can proceed for Check in Voucher.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnUploadDocument_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {

                    if (!Directory.Exists(Server.MapPath("~/GuestPhoto")))
                        Directory.CreateDirectory(Server.MapPath("~/GuestPhoto"));

                    if (!Directory.Exists(Server.MapPath("~/GuestDocument")))
                        Directory.CreateDirectory(Server.MapPath("~/GuestDocument"));

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuest = GuestBLL.GetByPrimaryKey(this.GuestID);

                    string strDocumentNameTemp = "";
                    if (fuGuestPhoto.FileName != "")
                    {
                        strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fuGuestPhoto.FileName.Replace(" ", "_");
                        fuGuestPhoto.SaveAs(Server.MapPath("~/GuestPhoto/" + strDocumentNameTemp));
                        objGuest.GuestPhoto = strDocumentNameTemp;
                        ////rfvGuestPhoto.Enabled = false; //Don't delete this line, will use once documents are required.
                        ancViewGuestPhoto.HRef = "~/GuestPhoto/" + strDocumentNameTemp;
                        ancViewGuestPhoto.Visible = imgBtnDeleteGuestPhoto.Visible = true;
                    }

                    if (ddlDocument1.SelectedIndex != 0)
                        objGuest.IDType1_TermID = new Guid(ddlDocument1.SelectedValue);

                    objGuest.IDType1 = txtDocRefNo1.Text.Trim();
                    if (fuIDDocument1.FileName != "")
                    {
                        strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fuIDDocument1.FileName.Replace(" ", "_");
                        fuIDDocument1.SaveAs(Server.MapPath("~/GuestDocument/" + strDocumentNameTemp));
                        objGuest.ScanID1 = strDocumentNameTemp;
                        ////rfvIDDocument1.Enabled = false; //Don't delete this line, will use once documents are required.
                        ancViewIDDocument1.HRef = "~/GuestDocument/" + strDocumentNameTemp;
                        ancViewIDDocument1.Visible = imgBtnDeleteIDDocument1.Visible = true;
                    }

                    if (ddlDocument2.SelectedIndex != 0)
                        objGuest.IDType2_TermID = new Guid(ddlDocument2.SelectedValue);

                    objGuest.IDType2 = txtDocRefNo2.Text.Trim();
                    if (fuIDDocument2.FileName != "")
                    {
                        strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fuIDDocument2.FileName.Replace(" ", "_");
                        fuIDDocument2.SaveAs(Server.MapPath("~/GuestDocument/" + strDocumentNameTemp));
                        objGuest.ScanID2 = strDocumentNameTemp;
                        ancViewIDDocument2.HRef = "~/GuestDocument/" + strDocumentNameTemp;
                        ancViewIDDocument2.Visible = imgBtnDeleteIDDocument2.Visible = true;
                    }

                    GuestBLL.Update(objGuest);

                    IsGuestDocMessage = true;
                    lblDocMessage.Text = "Documents uploaded successfully.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCheckinVoucher_OnClick(object sender, EventArgs e)
        {
            if (this.ReservationID != Guid.Empty)
            {
                DataSet dsVoucherData = ReservationBLL.GetCheckInVoucherData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);

                //litCurrentDate.Text = Convert.ToString(DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat));

                if (dsVoucherData.Tables.Count > 0 && dsVoucherData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsVoucherData.Tables[0].Rows[0];

                    litChVchrGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    ltrChVchrReservationNo.Text = Convert.ToString(dr["ReservationNo"]);
                    litChVchrMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    litChVchrEmail.Text = Convert.ToString(dr["Email"]);
                    ltrChVchrFolioNo.Text = Convert.ToString(dr["FolioNo"]);
                    ltrChVchrRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    ltrChVchrRoomType.Text = Convert.ToString(dr["RoomTypeName"]);
                    ltrChVchrRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));
                    ltrChVchrAdultChild.Text = Convert.ToString(dr["Adults"]) + "/" + Convert.ToString(dr["Children"]);

                    DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));

                    ltrChVchrCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    ltrChVchrCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));


                    //int day = 0;//bool b1 = false;//bool b2 = false;
                    //clsCommon.Reservation_GetTotalDays(null, dtCheckInDate, dtCheckOutDate, ref day, ref b1, ref b2);
                    //litReservationVoucherNoofNights.Text = Convert.ToString(day);

                    if (dsVoucherData.Tables.Count > 1 && dsVoucherData.Tables[1].Rows.Count > 0)
                        lblChVchrHousingRules.Text = Convert.ToString(dsVoucherData.Tables[1].Rows[0]["HousingRules"]);
                    else
                        lblChVchrHousingRules.Text = "";

                    //Reservation Payment Calculaltion
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

                    ltrChVchrNoOfDays.Text = Convert.ToString(NoofDays);
                    ltrChVchrRoomRent.Text = Convert.ToString(strRoomRent);
                    ltrChVchrTaxes.Text = Convert.ToString(strTax);

                    //Reservation time total charges(Room Rent)
                    ltrChVchrTotalCharges.Text = Convert.ToString(strTotalAmount);
                    //Reservation time total Deposit
                    ltrChVchrDeposit.Text = Convert.ToString(strDepositAmount);

                    //Reservation time total Amount payable(Room Rent + Deposit)
                    TotalAmountPayable = TotalAmount + DepositAmount;
                    ltrChVchrTotalAmount.Text = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //Total Deposit received
                    ltrChVchrPaidAmount.Text = PaidDeposit.ToString().Substring(0, PaidDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (TotalAmountPayable >= PaidDeposit)
                    {
                        NetAmountToPay = TotalAmountPayable - PaidDeposit;
                        ltrChVchrAmountToPay.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                }
                else
                {
                    //litReservationVoucherGuestName.Text = litReservationVoucherBookingNo.Text = litReservationVoucherMobileNo.Text = litReservationVoucherEmail.Text = litReservationVoucherCheckinDate.Text = litReservationVoucherCheckoutDate.Text = litReservationVoucherNoofNights.Text = litReservationVoucherNoofGuests.Text = litReservationVoucherRateCard.Text = litReservationVoucherRoomType.Text = litReservationVoucherBookingStatus.Text = litReservationVoucherValidUpto.Text = "";
                    //litDisplayReservationVoucherCheckInTime.Text = litDisplayReservationVoucherCheckOutTime.Text = "";
                    //lblDisplayCancellationPolicy.Text = "";
                }
            }

            mpeCheckInVoucher.Show();
        }

        protected void btnProceedForPayment_OnClick(object sender, EventArgs e)
        {
            mvCheckInForm.ActiveViewIndex = 1;
        }

        protected void btnSavePayment_OnClick(object sender, EventArgs e)
        {
            try
            {
                //To give success message.111111111111111

                String strPaymentMode = string.Empty;//// It will use to save Credit Card info.
                if (this.ReservationID != Guid.Empty && ddlModeOfPayment.SelectedIndex != 0)
                {
                    if (txtPaymentAmount.Text.Trim() == string.Empty || !(Convert.ToDecimal(txtPaymentAmount.Text.Trim()) > 0))
                    {
                        MessageBox.Show("Invalid receipt amount, it must be greater than 0.");
                        return;
                    }

                    if (Convert.ToDecimal(txtPaymentAmount.Text.Trim()) > this.AmountSuggestedToPay)
                    {
                        mpeAmoutIsLargerThanSuggestedAlert.Show();
                        return;
                    }

                    ResGuestPaymentInfo objPaymentInfo = null;
                    ProjectTerm pTermPaymentInfo = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlModeOfPayment.SelectedValue));
                    if (pTermPaymentInfo != null)
                    {
                        strPaymentMode = Convert.ToString(pTermPaymentInfo.Term).ToUpper();
                        if (strPaymentMode == "CREDIT CARD")
                        {
                            ////Check Credit Card's Expiration Date
                            bool isCreditCardValid = true;
                            if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) < DateTime.Today.Year)
                            {
                                isCreditCardValid = false;
                            }
                            else if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) == DateTime.Today.Year)
                            {
                                if (Convert.ToInt32(ddlCardExpirationMonth.SelectedValue) < DateTime.Today.Month)
                                {
                                    isCreditCardValid = false;
                                }
                            }

                            if (!isCreditCardValid)
                            {
                                MessageBox.Show("Please enter valid Expiration Date of Credit Card.");
                                return;
                            }

                            if (txtCardNumber.Text.Trim().Length < 16)
                            {
                                MessageBox.Show("Invalid card number, it must be 16 digits.");
                                return;
                            }

                            if (txtCVVNo.Text.Trim().Length < 3)
                            {
                                MessageBox.Show("Invalid CVV No., it must have atleast 3 digit.");
                                return;
                            }
                        }
                        //// if payment mode is Credit card, then check Credit Card's Expiretion date End
                    }

                    //Save Payment Start

                    if (strPaidAmt2AvoidDoubleEntry != string.Empty)
                    {
                        if (txtPaymentAmount.Text.Trim() == strPaidAmt2AvoidDoubleEntry)
                        {                            
                            MessageBox.Show("This is 2nd entry for same amount. Go to 'Reprint Payment' to print Payment receipt.");
                            return;
                        }
                    }

                    //Bind Guest payment info if payment is done using Creditcard
                    if (strPaymentMode == "CREDIT CARD")
                    {
                        objPaymentInfo = new ResGuestPaymentInfo();
                        objPaymentInfo.GuestID = this.GuestID;
                        objPaymentInfo.MOP_TermID = new Guid(ddlModeOfPayment.SelectedValue);
                        objPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                        objPaymentInfo.CardNo = clsCommon.GetUpperCaseText(txtCardNumber.Text.Trim());
                        objPaymentInfo.CardHolderName = clsCommon.GetUpperCaseText(txtNameOnCard.Text.Trim());
                        objPaymentInfo.DateOfExpiry = new DateTime(Convert.ToInt32(ddlCardExpirationYear.SelectedValue), Convert.ToInt32(ddlCardExpirationMonth.SelectedValue), 1);
                        objPaymentInfo.IsCreditCardCharged = true;
                        objPaymentInfo.CVVNo = clsCommon.GetUpperCaseText(txtCVVNo.Text.Trim());
                        objPaymentInfo.PropertyID = clsSession.PropertyID;
                        objPaymentInfo.CompanyID = clsSession.CompanyID;
                        objPaymentInfo.IsActive = true;

                        ResGuestPaymentInfoBLL.Save(objPaymentInfo);
                    }

                    decimal CurrentPayingAmount = Convert.ToDecimal("0.000000");
                    CurrentPayingAmount = Convert.ToDecimal(txtPaymentAmount.Text.Trim());
                    strPaidAmt2AvoidDoubleEntry = txtPaymentAmount.Text.Trim();

                    Guid? PaymentAcctID = null;
                    Guid? CounterID = clsSession.DefaultCounterID; // new Guid("acadee48-26ec-4a92-8aae-bc2f8c4e8037"); //null;


                    string strReturnBookID = string.Empty;

                    //If paid deposit amount is not same as Reservation deposit, then save deposit first.
                    if (this.PaidDepositAmount < this.ResDepositAmount)
                    {
                        decimal RemainingDepositToPay = Convert.ToDecimal("0.000000");
                        RemainingDepositToPay = this.ResDepositAmount - this.PaidDepositAmount;
                        decimal DepositGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingDepositToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            DepositGoingToPay = RemainingDepositToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - DepositGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            DepositGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, DepositGoingToPay, PaymentAcctID, DepositAcctID, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "ROOM DEPOSIT", clsSession.CompanyID, ResPayID);

                        if (strReturnBookID == string.Empty)
                            strReturnBookID = Convert.ToString(tempBookID);
                        else
                            strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                    }

                    /*
                    ////To not consider Infra. Service Charges as Infra. is removed from all rate card.
                    ////if current paying amount is larger than deposit to pay, then save Infra. Service Charges
                    if (CurrentPayingAmount > 0 && this.ResInfraServiceChargeAmount > 0 && this.PaidInfraServiceChargeAmount < this.ResInfraServiceChargeAmount)
                    {
                        decimal RemainingInfraServiceChargeToPay = Convert.ToDecimal("0.000000");
                        RemainingInfraServiceChargeToPay = this.ResInfraServiceChargeAmount - this.PaidInfraServiceChargeAmount;
                        decimal InfraServiceChargeGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingInfraServiceChargeToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            InfraServiceChargeGoingToPay = RemainingInfraServiceChargeToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - InfraServiceChargeGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            InfraServiceChargeGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? InfraServiceChargeAcctID = new Guid("A24EC56C-7586-4517-8659-12D84B62541C"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, InfraServiceChargeGoingToPay, PaymentAcctID, InfraServiceChargeAcctID, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "INFRA SERVICE CHARGE", clsSession.CompanyID, ResPayID);

                        if (strReturnBookID == string.Empty)
                            strReturnBookID = Convert.ToString(tempBookID);
                        else
                            strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                    }
                    */

                    ////if current paying amount is larger than deposit to pay, then save Food Charges
                    if (CurrentPayingAmount > 0 && this.FoodChargeAmount > 0 && this.PaidFoodChargeAmount < this.FoodChargeAmount)
                    {
                        decimal RemainingFoodChargeToPay = Convert.ToDecimal("0.000000");
                        RemainingFoodChargeToPay = this.FoodChargeAmount - this.PaidFoodChargeAmount;
                        decimal FoodChargeGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingFoodChargeToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            FoodChargeGoingToPay = RemainingFoodChargeToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - FoodChargeGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            FoodChargeGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? FoodChargeAcctID = new Guid("9B544844-4BE7-418D-AC93-E37A0101751A"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, FoodChargeGoingToPay, PaymentAcctID, FoodChargeAcctID, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "FOOD CHARGE", clsSession.CompanyID, ResPayID);

                        if (strReturnBookID == string.Empty)
                            strReturnBookID = Convert.ToString(tempBookID);
                        else
                            strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                    }

                    ////if current paying amount is larger than deposit to pay, then save Electricity and Water Charges
                    if (CurrentPayingAmount > 0 && this.ElectricityChargeAmount > 0 && this.PaidElectricityChargeAmount < this.ElectricityChargeAmount)
                    {
                        decimal RemainingElectricityChargeToPay = Convert.ToDecimal("0.000000");
                        RemainingElectricityChargeToPay = this.ElectricityChargeAmount - this.PaidElectricityChargeAmount;
                        decimal ElectricityChargeGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingElectricityChargeToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            ElectricityChargeGoingToPay = RemainingElectricityChargeToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - ElectricityChargeGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            ElectricityChargeGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? ElectricityChargeAcctID = new Guid("6A578844-2CE7-414D-AC56-B37A0675754B"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, ElectricityChargeGoingToPay, PaymentAcctID, ElectricityChargeAcctID, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "ELECTRICITY CHARGE", clsSession.CompanyID, ResPayID);

                        if (strReturnBookID == string.Empty)
                            strReturnBookID = Convert.ToString(tempBookID);
                        else
                            strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                    }

                    //If after checking or paying whole deposit, if Current payment is greater than 0, then save it as reservation Payment.
                    if (CurrentPayingAmount > 0)
                    {
                        ////If Request mode is Deposit, then save remaining amount as Deposit
                        if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "DEPOSIT")
                        {
                            int Zone_TermID = 0;
                            Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                            Guid? ResPayID = null;

                            DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                            if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                                Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                            if (ddlLedgerAccount.Items.Count > 0)
                                PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                            if (objPaymentInfo != null)
                                ResPayID = objPaymentInfo.ResPayID;

                            Guid tempBookID = Guid.Empty;

                            tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, CurrentPayingAmount, PaymentAcctID, DepositAcctID, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "ROOM DEPOSIT", clsSession.CompanyID, ResPayID);

                            string str34 = strReturnBookID;
                            if (strReturnBookID == string.Empty)
                                strReturnBookID = Convert.ToString(tempBookID);
                            else
                                strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                        }
                        else//// it is in payment mode and then save remaining amount as payment.
                        {
                            Guid? ResPayID = null;

                            if (ddlLedgerAccount.Items.Count > 0)
                                PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                            if (objPaymentInfo != null)
                                ResPayID = objPaymentInfo.ResPayID;

                            Guid tempID = Guid.Empty;

                            tempID = BookKeepingBLL.ReceivePayment(PaymentAcctID, CurrentPayingAmount, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, clsSession.CompanyID, "FRONT DESK", ResPayID, false);

                            if (strReturnBookID == string.Empty)
                                strReturnBookID = Convert.ToString(tempID);
                            else
                                strReturnBookID += "," + Convert.ToString(tempID);
                        }
                    }
                    //Save Payment End

                    //After saving payment, update it's value.
                    if (strReturnBookID == "")
                        strReturnBookID = null;

                    //After saving payment, update it's value.
                    hdnBookingID.Value = strReturnBookID;
                    ucPaymentReceipt.BindSinglePaymentDetails(this.ReservationID, this.GuestID, ltrChkPmtGuestName.Text, txtPaymentAmount.Text.Trim(), ddlModeOfPayment.SelectedItem.Text, strReturnBookID);

                    txtPaymentTimeEmail.Text = hfOldGuestEmail.Value = Convert.ToString(ucPaymentReceipt.gstGuestEmail);

                    txtPaymentAmount.Text = "";
                    ddlModeOfPayment.SelectedIndex = 0;
                    ddlModeOfPayment_OnSelectedIndexChanged(null, null);
                    BindPaymentDetails();
                    mpePrintReceipt.Show();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnEmailPaymentReceipt_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (hfOldGuestEmail.Value.ToString() != txtPaymentTimeEmail.Text.Trim())
                {
                    GuestBLL.UpdateGuestEmail(this.GuestID, txtPaymentTimeEmail.Text.Trim());
                }

                //Get Email Template info. First table contains Email template and second table contains it's Email Configuration info.
                DataSet dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(clsSession.PropertyID, clsSession.CompanyID, "Payment Receipt");
                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(clsSession.CompanyID, clsSession.PropertyID);
                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        if (dsSearchEmailTemplate.Tables[0] != null && dsSearchEmailTemplate.Tables[0].Rows.Count != 0)
                        {
                            string strHTML = "";
                            if (File.Exists(Server.MapPath("~/EmailTemplate/PaymentReceipt.htm")))
                            {
                                strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/PaymentReceipt.htm"));
                                strHTML = strHTML.Replace("$PROPERTYADDRESS$", BindPropertyAddress());

                                DataSet dsPayment = BookKeepingBLL.GetPaymentForCheckInVoucher(ReservationID, clsSession.PropertyID, clsSession.CompanyID, Convert.ToString(hdnBookingID.Value));

                                decimal dcTotalAmount = Convert.ToDecimal("0.00");
                                string strFolioNo = "";
                                string strGuestName = "";

                                if (dsPayment.Tables.Count > 0 && dsPayment.Tables[0].Rows.Count > 0)
                                {
                                    strFolioNo = Convert.ToString(dsPayment.Tables[0].Rows[0]["FolioNo"]);
                                    strGuestName = Convert.ToString(dsPayment.Tables[0].Rows[0]["GuestFullName"]);

                                    if (dsPayment.Tables.Count > 1 && dsPayment.Tables[1].Rows.Count > 0)
                                    {
                                        dcTotalAmount = Convert.ToDecimal(Convert.ToString(dsPayment.Tables[1].Rows[0]["TotalAmount"]));
                                    }

                                    string strTransTRs = string.Empty;
                                    for (int i = 0; i < dsPayment.Tables[0].Rows.Count; i++)
                                    {
                                        DateTime paymentEntryDate = Convert.ToDateTime(Convert.ToString(dsPayment.Tables[0].Rows[i]["EntryDate"]));
                                        strTransTRs += "<tr><td>" + (i + 1).ToString() + "</td><td>" + Convert.ToString(dsPayment.Tables[0].Rows[i]["BookNo"]) + "</td><td>" + paymentEntryDate.ToString(clsSession.DateFormat) + " " + paymentEntryDate.ToString(clsSession.TimeFormat) + "</td><td align='right'>" + Convert.ToString(dsPayment.Tables[0].Rows[i]["Amount"]) + "</td><td>&nbsp;" + Convert.ToString(dsPayment.Tables[0].Rows[i]["MOP"]) + "</td></tr>";
                                    }

                                    strHTML = strHTML.Replace("$TRPAYMENTTRANSACTIONS$", strTransTRs);

                                    
                                    //strHTML = strHTML.Replace("$TRANSACTIONNUMBER$", Convert.ToString(dsPayment.Tables[0].Rows[0]["BookNo"]));
                                    //strHTML = strHTML.Replace("$PAYMENTDATETIME$", paymentEntryDate.ToString(clsSession.DateFormat) + " " + paymentEntryDate.ToString(clsSession.TimeFormat));
                                    //strHTML = strHTML.Replace("$AMOUNT$", Convert.ToString(dsPayment.Tables[0].Rows[0]["Amount"]));
                                    //strHTML = strHTML.Replace("$MOP$", Convert.ToString(dsPayment.Tables[0].Rows[0]["MOP"]));
                                    
                                    strHTML = strHTML.Replace("$TOTALAMOUNT$", Convert.ToString(dcTotalAmount));
                                }

                                strHTML = strHTML.Replace("$GUESTNAME$", strGuestName);
                                strHTML = strHTML.Replace("$FOLIONUMBER$", strFolioNo);
                                strHTML = strHTML.Replace("$RECEIVEDBY$", Convert.ToString(clsSession.DisplayName));
                                strHTML = strHTML.Replace("$CURRENTDATE$", DateTime.Today.ToString(clsSession.DateFormat));
                                strHTML = strHTML.Replace("$CURRENTTIME$", DateTime.Now.ToString(clsSession.TimeFormat));
                            }
                            else
                            {
                                strHTML = string.Empty;
                            }

                            if (strHTML != "" && strHTML != string.Empty)
                            {
                                SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, txtPaymentTimeEmail.Text, "Payment Receipt from Uniworld", strHTML);
                                //SentMail.SendMail(strPrimoryDomainName, "frontdesk.uniworld@gmail.com", "lenovo@123", strSmtpAddress, txtGuestEmail.Text, "Payment Receipt from Uniworld", strHTML);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                                return;
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnCheckInReservatin_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty)
                {
                    //  Reservation is not allow to check in whose check in date is greater then today 's date 

                    if (Convert.ToInt32(this.dtCheckInDate.ToString("yyyyMMdd")) > Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Check in date should not grater than today's date");
                        return;
                    }

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                    objReservation.UpdatedBy = clsSession.UserID;
                    objReservation.UpdatedOn = DateTime.Now;
                    if (objReservation.RoomID == null || objReservation.RoomID == Guid.Empty || Convert.ToString(objReservation.RoomID) == string.Empty)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Room is not assigned to this reservation, you can't proceed for check in it.");
                        return;
                    }

                    ////Transfer Extra deposit as a payment Start
                    DataSet dsDeposits = TransactionBLL.TransactionGetAllDeposit(this.ReservationID, false, clsSession.PropertyID, clsSession.CompanyID);

                    if (dsDeposits.Tables.Count > 0 && dsDeposits.Tables[0].Rows.Count > 0)
                    {
                        decimal dcmlDepositToKeepAsDeposit = Convert.ToDecimal("0.000000");
                        int Zone_TermID = 0;

                        if (lblResTimeDepositAmount.Text != string.Empty)
                            dcmlDepositToKeepAsDeposit = Convert.ToDecimal(lblResTimeDepositAmount.Text);

                        foreach (DataRow dtRow in dsDeposits.Tables[0].Rows)
                        {
                            if (dtRow["DUE AMOUNT"] != null)
                            {
                                if (Convert.ToDecimal(dtRow["DUE AMOUNT"].ToString()) > 0 && Convert.ToString(dtRow["GeneralIDType_Term"]) == "RESERVATION DEPOSIT")
                                {
                                    decimal dcmlRowDepositAmount = Convert.ToDecimal("0.000000");
                                    decimal dcmlToTransferAsPayment = Convert.ToDecimal("0.000000");

                                    if (Convert.ToString(dtRow["Amount"]) != string.Empty && Convert.ToDecimal(dtRow["Amount"].ToString()) > 0)
                                    {
                                        dcmlToTransferAsPayment = dcmlRowDepositAmount = Convert.ToDecimal(dtRow["Amount"].ToString());

                                        if (dcmlDepositToKeepAsDeposit > 0)
                                        {
                                            if (dcmlRowDepositAmount < dcmlDepositToKeepAsDeposit)
                                            {
                                                dcmlDepositToKeepAsDeposit = dcmlDepositToKeepAsDeposit - dcmlRowDepositAmount;
                                                dcmlToTransferAsPayment = Convert.ToDecimal("0.000000");
                                            }
                                            else
                                            {
                                                dcmlToTransferAsPayment = dcmlRowDepositAmount - dcmlDepositToKeepAsDeposit;
                                                dcmlDepositToKeepAsDeposit = Convert.ToDecimal("0.00");
                                            }
                                        }

                                        ////Transfer amount as Payment Start.
                                        if (dcmlToTransferAsPayment > 0)
                                        {
                                            Guid depositBookID = new Guid(Convert.ToString(dtRow["BookID"]));

                                            Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                                            Guid? CounterID = clsSession.DefaultCounterID;//// null;

                                            if (Zone_TermID == 0)
                                            {
                                                DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                                                if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                                                    Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);
                                            }

                                            TransactionBLL.TransferDeposit(depositBookID, Zone_TermID, dcmlToTransferAsPayment, DepositAcctID, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "TRANSFER ROOM DEPOSIT", clsSession.CompanyID);
                                        }
                                        ////Transfer amount as Payment End.
                                    }
                                }
                            }
                        }
                    }
                    ////Transfer Extra deposit as a payment End

                    objReservation.RestStatus_TermID = 32;
                    objReservation.ActualCheckInDate = DateTime.Now;
                    objReservation.UpdateMode = "RESERVATION CHECKIN";
                    objReservation.ActualCheckInDate = DateTime.Now;
                    ReservationBLL.Update(objReservation);

                    if (this.RoomChargePostTimeReservationID != this.ReservationID)
                    {
                        //Post check in date's accomodatio charge Start
                        BlockDateRate objToGet = new BlockDateRate();
                        objToGet.ReservationID = this.ReservationID;
                        objToGet.BlockDate = DateTime.Today;
                        List<BlockDateRate> lstBlockDates = BlockDateRateBLL.GetAll(objToGet);
                        if (lstBlockDates != null && lstBlockDates.Count > 0)
                        {
                            if (lstBlockDates[0].RoomRate != null)
                            {
                                decimal dcmlBaseRate = Convert.ToDecimal(lstBlockDates[0].RoomRate);

                                TransactionBLL.PostRoomCharge(DateTime.Today, this.ReservationID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlBaseRate, clsSession.CompanyID);
                            }
                        }

                        //Set this.RoomChargePostTimeReservationID's value as this.ReservationID when roomcharge is posted for one reservation.
                        this.RoomChargePostTimeReservationID = this.ReservationID;
                        //Post check in date's accomodatio charge End
                    }

                    //POSChargePerDay objPOSCharge = new POSChargePerDay();
                    //objPOSCharge.ReservationID = this.ReservationID;
                    //objPOSCharge.ChargeAmount = txtPOSChargeAmount.Text.Trim() != string.Empty ? Convert.ToDecimal(txtPOSChargeAmount.Text.Trim()) : 0;
                    //objPOSCharge.CreatedBy = clsSession.UserID;
                    //objPOSCharge.CreatedOn = DateTime.Now;
                    //objPOSCharge.CompanyID = clsSession.CompanyID;
                    //objPOSCharge.PropertyID = clsSession.PropertyID;
                    //POSChargePerDayBLL.Save(objPOSCharge);

                    this.strIsCounterValidate = "RESERVATION MESSAGE";
                    lblCounterErrorMessage.Text = "Reservation checked in successfully.";
                    mpeCounterErrorMessage.Show();

                    btnCheckInReservatin.Visible = false;
                    btnBackToListFromPmtView.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddPreferences_Click(object sender, EventArgs e)
        {
            ClearControl();
            BindDDLPreference();
            mpePreference.Show();
        }

        protected void btnAddMgmtNote_Click(object sender, EventArgs e)
        {
            ClearControl();
            mpeManagementNote.Show();
        }

        protected void btnSearchGuestInfo_Click(object sender, EventArgs e)
        {
            mpeSearchGuestInfo.Show();
            txtSearchGuestName.Text = "";
            gvSearchGuestList.DataSource = null;
            gvSearchGuestList.DataBind();
        }
        protected void linkForeignNationalpopup_Click(object sender, EventArgs e)
        {
            ClearForeignNationalInfo();
            mpeForeignNationalInfo.Show();
        }
        protected void btnAssignRoom_OnClick(object sender, EventArgs e)
        {
            try
            {
                txtSearchFromDate.Text = litDisplayCheckInDate.Text.Trim();
                txtSearchToDate.Text = litDisplayCheckOutDate.Text.Trim();

                btnSearch_Click(sender, e);
                mvCheckInForm.ActiveViewIndex = 2;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnProceed_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (hdnRoomID.Value != string.Empty && hdnRoomNo.Value != string.Empty)
                {
                    ltrChkPmtRoomNo.Text = lblDisplayRoomNo.Text = clsCommon.GetFormatedRoomNumber(hdnRoomNo.Value);
                    mpeReservationProceed.Hide();
                    mvCheckInForm.ActiveViewIndex = 0;
                }
            }
            catch (Exception ex)
            {
                mpeReservationProceed.Hide();
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackFromRoomChart_OnClick(object sender, EventArgs e)
        {
            mvCheckInForm.ActiveViewIndex = 0;
        }

        protected void btnSearchGuest_Click(object sender, EventArgs e)
        {
            DataTable dtService = new DataTable();

            DataColumn dc1 = new DataColumn("Name");
            DataColumn dc2 = new DataColumn("Email");
            DataColumn dc3 = new DataColumn("DOB");
            DataColumn dc4 = new DataColumn("MobileNo");
            DataColumn dc5 = new DataColumn("Country");
            DataColumn dc6 = new DataColumn("State");
            DataColumn dc7 = new DataColumn("City");


            dtService.Columns.Add(dc1);
            dtService.Columns.Add(dc2);
            dtService.Columns.Add(dc3);
            dtService.Columns.Add(dc4);
            dtService.Columns.Add(dc5);
            dtService.Columns.Add(dc6);
            dtService.Columns.Add(dc7);

            DataRow dr1 = dtService.NewRow();
            dr1["Name"] = "Mr. Jayesh Rathod";
            dr1["Email"] = "jayesh@gmail.com";
            dr1["MobileNo"] = "7589321545";
            dr1["DOB"] = "01/01/1990";
            dr1["Country"] = "India";
            dr1["State"] = "Gujarat";
            dr1["City"] = "Ahmedabad";

            dtService.Rows.Add(dr1);

            DataRow dr2 = dtService.NewRow();
            dr2["Name"] = "Miss. Palak Jain";
            dr2["Email"] = "palak@sqt.in";
            dr2["MobileNo"] = "9825674123";
            dr2["DOB"] = "12/10/1980";
            dr2["Country"] = "India";
            dr2["State"] = "Gujarat";
            dr2["City"] = "Ahmedabad";

            dtService.Rows.Add(dr2);

            gvSearchGuestList.DataSource = dtService;
            gvSearchGuestList.DataBind();

            mpeSearchGuestInfo.Show();
        }

        protected void btnCheckInReRoute_Click(object sender, EventArgs e)
        {
            mvCheckInForm.ActiveViewIndex = 3;

            litDisplayReRouteSetupBookingNo.Text = Convert.ToString(ltrChkPmtReservationNo.Text.Trim());
            litDisplayReRouteSetupSourceFolio.Text = this.strFolioNo;
            litDisplayReRouteSetupUnitNo.Text = Convert.ToString(ltrChkPmtRoomNo.Text.Trim() + " - " + ltrChkPmtRoomType.Text.Trim());
            litDisplayReRouteSetupGuestName.Text = Convert.ToString(ltrChkPmtGuestName.Text.Trim());

            //lblDisplayNoOfDaysPmtTab.Text = lblDisplayNoOfDaysPmtTab.Text =lblResTimeTaxPmtTab.Text =lblResTimeTotalCharges.Text(Total Charges) = lblResTimeDepositAmount.Text = lblResTimeTotalPayableAmount.Text(Total Amount) =
            //lblResTimeRoomRentPmtTab.Text =
            lblSplBillDisplayNoOfDays.Text = Convert.ToString(lblDisplayNoOfDaysPmtTab.Text.Trim());
            lblSplBillDisplayRoomRent.Text = Convert.ToString(lblResTimeRoomRentPmtTab.Text.Trim());
            lblSplBillDisplayTax.Text = Convert.ToString(lblResTimeTaxPmtTab.Text.Trim());
            lblSplBillDisplayDepositAmount.Text = Convert.ToString(lblResTimeDepositAmount.Text.Trim());
            lblSplBillTotalPayableAmount.Text = lblPayableByGuest.Text = Convert.ToString(lblResTimeTotalPayableAmount.Text.Trim());
            lblSplBillDisplayTotalAmount.Text = Convert.ToString(lblResTimeTotalCharges.Text.Trim());
            lblSplBillTotalAmountReceived.Text = Convert.ToString(lblTotalPaymentReceived.Text.Trim());

            lblSplBillAmountToPay.Text = Convert.ToString(Convert.ToDecimal(lblPayableByGuest.Text.Trim()) - Convert.ToDecimal(lblPayableByCompany.Text.Trim()) - Convert.ToDecimal(lblSplBillTotalAmountReceived.Text.Trim()));

            //string strPageName = GetPageName();

            //if (strPageName.ToUpper() == "CHECKIN.ASPX")
            //    Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?CheckIn=true");
        }

        protected void btnCheckInCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void ddlModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModeOfPayment.SelectedIndex != 0)
            {
                ddlLedgerAccount.Items.Clear();

                DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlModeOfPayment.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
                if (dstLedgerAccounts != null && dstLedgerAccounts.Tables[0].Rows.Count > 0)
                {
                    ddlLedgerAccount.DataSource = dstLedgerAccounts.Tables[0];
                    ddlLedgerAccount.DataTextField = "AcctName";
                    ddlLedgerAccount.DataValueField = "AcctID";
                    ddlLedgerAccount.DataBind();
                }

                trLedgerAccount.Visible = true;
            }
            else
            {
                ddlLedgerAccount.Items.Clear();
                trLedgerAccount.Visible = false;
            }


            rfvCreditCardType.Enabled = rfvNameOnCreditCard.Enabled = rfvCreditCardNumber.Enabled = rfvCVVNumber.Enabled = rfvCardExpirationMonth.Enabled = rfvCardExpirationYear.Enabled = false;
            trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
            if (ddlModeOfPayment.SelectedIndex != 0)
            {
                ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlModeOfPayment.SelectedValue));

                if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
                    trChequeDD1.Visible = trChequeDD2.Visible = true;
                }
                else if (objProjectTerm.Term.Trim().ToUpper() == "CREDIT CARD")
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
                    trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = true;

                    ////Bind Credit Card Type Start
                    string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
                    ddlCreditCardType.Items.Clear();
                    List<ProjectTerm> lstSourceOfBusiness = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "CREDITCARDTYPE");
                    if (lstSourceOfBusiness.Count != 0)
                    {
                        ddlCreditCardType.DataSource = lstSourceOfBusiness;
                        ddlCreditCardType.DataTextField = "DisplayTerm";
                        ddlCreditCardType.DataValueField = "TermID";
                        ddlCreditCardType.DataBind();
                        ddlCreditCardType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    }
                    else
                        ddlCreditCardType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ////Bind Credit Card Type Start

                    ////Bind Year Start

                    ddlCardExpirationYear.Items.Clear();
                    int j = 1;
                    ddlCardExpirationYear.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
                    {
                        ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                        j++;
                    }
                    ////Bind Year Start

                    rfvCreditCardType.Enabled = rfvNameOnCreditCard.Enabled = rfvCreditCardNumber.Enabled = rfvCVVNumber.Enabled = rfvCardExpirationMonth.Enabled = rfvCardExpirationYear.Enabled = true;
                }
            }
        }

        protected void btnCloseAssignRoom_Click(object sender, EventArgs e)
        {
            mvCheckInForm.ActiveViewIndex = 0;
        }

        protected void btnProceedCheckInPayment_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet dsReservation = ReservationBLL.SelectReservationDetailByReservationNo("RES#" + txtForPaymentBookingNo.Text.Trim(), txtForPaymentGuestName.Text.Trim());
                if (dsReservation != null && dsReservation.Tables[0].Rows.Count > 0)
                {
                    DataRow drResData = dsReservation.Tables[0].Rows[0];

                    int intReservationStatusTermID = Convert.ToInt32(drResData["RestStatus_TermID"]);
                    if (!(intReservationStatusTermID == 27 || intReservationStatusTermID == 28 || intReservationStatusTermID == 32))
                    {
                        if (intReservationStatusTermID == 33)
                            MessageBox.Show("This reservation is already checked out, you can't proceed for payment.");
                        else if (intReservationStatusTermID == 34)
                            MessageBox.Show("This reservation is already cancelled, you can't proceed for payment.");
                        else if (intReservationStatusTermID == 29)
                            MessageBox.Show("This reservation is in waiting list, you can't proceed for payment.");
                        else if (intReservationStatusTermID == 35 || intReservationStatusTermID == 36)
                            MessageBox.Show("This reservation is in no show list, you can't proceed for payment.");

                        return;
                    }

                    if (intReservationStatusTermID == 32)
                    {
                        ////In Extend stay, reservation will come here to make payment in checked in status also, so allow it for payment.
                        if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT")
                        {
                            this.ReservationStatusValue = 32;
                            trPaymentHistory.Visible = false;
                        }
                        else// else don't allow to make payment.
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("This reservation is already checked in, you can't proceed for payment.");
                            return;
                        }
                    }
                    else
                    {
                        trPaymentHistory.Visible = true;

                        string strQuery = "select ISNULL(SUM(ReRouteCharge),0) 'ReRouteCharge' from res_BlockDateRate where ReservationID = '" + Convert.ToString(drResData["ReservationID"]) + "'";

                        DataSet ds = RoomBLL.GetUnitNo(strQuery);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            hdnAmtPayByCmp.Value = Convert.ToString(ds.Tables[0].Rows[0]["ReRouteCharge"]);
                        }
                    }

                    hdnResID.Value = Convert.ToString(drResData["ReservationID"]);
                    this.ReservationID = new Guid(Convert.ToString(drResData["ReservationID"]));
                    this.GuestID = new Guid(Convert.ToString(drResData["GuestID"]));
                    this.ReservationFolioID = new Guid(Convert.ToString(drResData["FolioID"]));
                    ltrChkPmtReservationNo.Text = Convert.ToString(drResData["ReservationNo"]);
                    ltrChkPmtGuestName.Text = Convert.ToString(drResData["GuestFullName"]);
                    this.strFolioNo = Convert.ToString(drResData["FolioNo"]);
                    this.strBillingInstruction = Convert.ToString(drResData["BillingInstruction"]);

                    DateTime dtCheckInDate = this.dtCheckInDate = Convert.ToDateTime(Convert.ToString(drResData["CheckInDate"]));
                    DateTime dtCheckOutDate = this.dtCheckOutDate = Convert.ToDateTime(Convert.ToString(drResData["CheckOutDate"]));

                    ltrChkPmtCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    ltrChkPmtCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                    ltrChkPmtRoomType.Text = Convert.ToString(drResData["RoomTypeName"]);
                    ltrChkPmtRateCard.Text = Convert.ToString(drResData["RateCardName"]);
                    ltrChkPmtRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(drResData["RoomNo"]));

                    if (Convert.ToString(drResData["SpecificNote"]).Trim() != string.Empty)
                        ltrSpecNote.Text = "** " + Convert.ToString(drResData["SpecificNote"]);

                    lblDisplayVoucherEmployeeID.Text = Convert.ToString(drResData["EmployeeID"]);
                    lblDisplayVoucherDepartment.Text = Convert.ToString(drResData["Department"]);
                    lblDisplayJobTitle.Text = Convert.ToString(drResData["JobTitle"]);
                    ddlCompany.SelectedIndex = ddlCompany.Items.FindByValue(Convert.ToString(drResData["AgentID"])) != null ? ddlCompany.Items.IndexOf(ddlCompany.Items.FindByValue(Convert.ToString(drResData["AgentID"]))) : 0;

                    BindPaymentDetails();

                    if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT")
                    {
                        if (this.strBillingInstruction.ToUpper() == "PART BILLING TO COMPANY" || this.strBillingInstruction.ToUpper() == "FULL BILLING TO COMPANY")
                        {
                            ////If reservation already checked in, then don't make part billing button visible.
                            if (this.ReservationStatusValue == 32)
                                btnCheckInReRoute.Visible = false;
                            else
                                btnCheckInReRoute.Visible = true;
                        }
                        else
                            btnCheckInReRoute.Visible = false;
                    }
                    else
                        btnCheckInReRoute.Visible = false;

                    mvCheckInForm.ActiveViewIndex = 1;
                }
                else
                {
                    MessageBox.Show("No reservation found with given Booking #");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancelCheckInPayment_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void iBtnCacelCheckInPayment_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void btnCancelSplitBilling_OnClick(object sender, EventArgs e)
        {
            //mvCheckInForm.ActiveViewIndex = 3;
            mvCheckInForm.ActiveViewIndex = 1;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    litDisplayRoomType.Text = Convert.ToString(ddlSearchRoomType.SelectedItem.Text);
                    BindRoomReservationChart();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSaveCounterData_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strIsCounterValidate == "YES")
                {
                    mpeOpenCounter.Show();

                    if (ucCommonCounterLogin.ucddlCounter.SelectedIndex != 0)
                        ucCommonCounterLogin.SaveDataInCounter();
                    else
                    {
                        lblCounterErrorMessage.Text = "Please Select Counter.";
                        mpeCounterErrorMessage.Show();
                        return;
                    }
                }

                mpeOpenCounter.Hide();

                if (ucCommonCounterLogin.DefaultCounterID != Guid.Empty && ucCommonCounterLogin.CounterLoginLogID != Guid.Empty)
                {
                    clsSession.DefaultCounterID = ucCommonCounterLogin.DefaultCounterID;
                    clsSession.CounterLoginLogID = ucCommonCounterLogin.CounterLoginLogID;
                    clsSession.CounterName = Convert.ToString(ucCommonCounterLogin.CounterName);
                }

                LoadDataOnPageLoadEvent();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void iBtnCloseCounter_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void btnCounterErrorMessageOK_OnClick(object sender, EventArgs e)
        {
            if (this.strIsCounterValidate == "RESERVATION MESSAGE")
                Response.Redirect("~/GUI/Dashboard.aspx");
            else
                Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void btnManagementNoteSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                GuestManagementNote objIns = new GuestManagementNote();
                objIns.Notes = clsCommon.GetUpperCaseText(txtManagementNote.Text.Trim());
                objIns.NoteBy = clsSession.UserID;
                objIns.NoteOn = DateTime.Now.Date;
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.IsActive = true;
                objIns.GuestID = this.GuestID;
                GuestManagementNoteBLL.Save(objIns);
                IsMessage = true;
                lblFeedbackMsg.Text = "Recode Saved successfully.";

                BindGuestNote();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPreferenceSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                GuestPreference objInsPref = new GuestPreference();

                objInsPref.CompanyID = clsSession.CompanyID;
                objInsPref.PropertyID = clsSession.PropertyID;
                objInsPref.IsActive = true;
                objInsPref.GuestID = this.GuestID;
                objInsPref.Preference = ddlPreference.SelectedItem.ToString();
                objInsPref.PreferenceDetail = txtPreferenceDetails.Text.Trim();
                objInsPref.PreferenceID = new Guid(ddlPreference.SelectedValue);
                objInsPref.DateToSet = DateTime.Now.Date;

                GuestPreferenceBLL.Save(objInsPref);
                IsMessage = true;
                lblFeedbackMsg.Text = "Recode Saved successfully.";

                BindGuestPreferences();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnOKAmoutIsLargerThanSuggestedAlert_OnClick(object sender, EventArgs e)
        {
            this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text.Trim());
            btnSavePayment_OnClick(sender, e);
        }

        #endregion Control Event

        #region Delete Document Event
        protected void imgBtnDeleteGuestPhoto_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuest = GuestBLL.GetByPrimaryKey(this.GuestID);
                    objGuest.GuestPhoto = string.Empty;
                    GuestBLL.Update(objGuest);

                    ////rfvGuestPhoto.Enabled = true; //Don't delete this line, will use once documents are required.
                    ancViewGuestPhoto.Visible = imgBtnDeleteGuestPhoto.Visible = false;

                    IsGuestDocMessage = true;
                    lblDocMessage.Text = "Photo deleted successfully.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgBtnDeleteIDDocument1_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuest = GuestBLL.GetByPrimaryKey(this.GuestID);
                    objGuest.ScanID1 = string.Empty;
                    GuestBLL.Update(objGuest);

                    ////rfvIDDocument1.Enabled = true; //Don't delete this line, will use once documents are required.
                    ancViewIDDocument1.Visible = imgBtnDeleteIDDocument1.Visible = false;

                    IsGuestDocMessage = true;
                    lblDocMessage.Text = "Document deleted successfully.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgBtnDeleteIDDocument2_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuest = GuestBLL.GetByPrimaryKey(this.GuestID);
                    objGuest.ScanID2 = string.Empty;
                    GuestBLL.Update(objGuest);

                    ancViewIDDocument2.Visible = imgBtnDeleteIDDocument2.Visible = false;
                    IsGuestDocMessage = true;
                    lblDocMessage.Text = "Document deleted successfully.";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Dropdown List event
        protected void ddlGuestType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGuestType.SelectedIndex != 0)
            {
                ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlGuestType.SelectedValue));
                if (objProjectTerm != null && objProjectTerm.Description != null)
                    txtStandardInstruction.Text = Convert.ToString(objProjectTerm.Description);
                else
                    txtStandardInstruction.Text = "";
            }
            else
                txtStandardInstruction.Text = "";
        }
        #endregion

        #region Grid Event
        protected void gvGuestHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlInvoiceAmt = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Display_Charges"));
                    ((Label)e.Row.FindControl("lblGvInvoiceAmount")).Text = dcmlInvoiceAmt.ToString().Substring(0, dcmlInvoiceAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvFolioDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("VOID"))
                {
                    ctrlCommonVoidTransaction.ucMpeAddEditVoidTransaction.Show();
                    ctrlCommonVoidTransaction.uctxtVoidReason.Text = "";
                    ctrlCommonVoidTransaction.BookID = new Guid(Convert.ToString(e.CommandArgument));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnVoidTransactionCallParent_Click(object sender, EventArgs e)
        {
            BindPaymentDetails();
        }

        protected void gvPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaymentMode")) == string.Empty)
                    {
                        //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")).ToUpper() == "DEPOSIT TRANSFER")
                        //    ((Label)e.Row.FindControl("lblPaymentMode")).Text = "Transferred from Deposit";
                    }
                    else
                        ((Label)e.Row.FindControl("lblPaymentMode")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaymentMode"));

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

        protected void gvSearchGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("SEARCHGUEST"))
            {
                string strGuestName = Convert.ToString(e.CommandArgument);
                if (strGuestName == "Mr. Jayesh Rathod")
                {
                    ddlTitle.SelectedIndex = 2;
                    txtFirstName.Text = "Jayesh";
                    txtLastName.Text = "Rathod";
                    txtMobile.Text = "7589321545";
                    txtGuestEmail.Text = "jayesh@gmail.com";
                    txtCountryName.Text = "India";
                    txtStateName.Text = "Gujarat";
                    txtCityName.Text = "Ahmedabad";
                    txtZipCode.Text = "382345";
                    //txtAddress.Text = "a-7 Meghmalhar soc. nr. niklol road";

                }
                else if (strGuestName == "Miss. Palak Jain")
                {
                    ddlTitle.SelectedIndex = 1;
                    txtFirstName.Text = "Palak";
                    txtLastName.Text = "Jain";
                    txtMobile.Text = "9825674123";
                    txtGuestEmail.Text = "palak@sqt.in";
                    txtCountryName.Text = "India";
                    txtStateName.Text = "Gujarat";
                    txtCityName.Text = "Ahmedabad";
                    txtZipCode.Text = "382346";
                    //txtAddress.Text = "15 Rajdhani soc. new india colony";
                }
                mpeSearchGuestInfo.Hide();
            }
        }

        #endregion

        protected void lnkBilltoCompanySettlement_Click(object sender, EventArgs e)
        {
            //// Whether company rate card is applied or not, update AgentID in reservation once it goes to Set Company Settlement.
            ////Update AgentID in Reservation Start
            if (ddlCompany.SelectedIndex != 0)
            {
                ReservationBLL.UpdateAgentID(this.ReservationID, new Guid(ddlCompany.SelectedValue.ToString()), clsSession.PropertyID, clsSession.CompanyID, DateTime.Now, clsSession.UserID);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show("Please select Company.");
                return;
            }
            ////////Update AgentID in Reservation End



            //ctrlBillToCompany.uctxtCompnayWillBare.Text = "";
            //ctrlBillToCompany.ucddlDiscountType.SelectedIndex = 0;
            ctrlBillToCompany.setRow();
            //ctrlBillToCompany.SetRateMaxValue();            
            ctrlBillToCompany.uclitDisplayBillingMode.Text = strBillingInstruction;

            ctrlBillToCompany.uccalBillToCmpStartDate.StartDate = dtCheckInDate;
            ctrlBillToCompany.uccalBillToCmpStartDate.EndDate = dtCheckOutDate;
            ctrlBillToCompany.uccalBillToCmpEndDate.StartDate = dtCheckInDate;
            ctrlBillToCompany.uccalBillToCmpEndDate.EndDate = dtCheckOutDate;

            ctrlBillToCompany.Reservation_ID = this.ReservationID;
            ctrlBillToCompany.BindRateGrid();

            ctrlBillToCompany.uctxtBillToCmpStartDate.Text = ctrlBillToCompany.uctxtBillToCmpEndDate.Text = "";
            ctrlBillToCompany.uctxtBillToCmpStartDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
            ctrlBillToCompany.uctxtBillToCmpEndDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));

            if (this.strBillingInstruction.ToUpper() == "PART BILLING TO COMPANY")
            {
                ctrlBillToCompany.uccalBillToCmpStartDate.Enabled = true;
                ctrlBillToCompany.uccalBillToCmpEndDate.Enabled = true;
            }
            else if (this.strBillingInstruction.ToUpper() == "FULL BILLING TO COMPANY")
            {
                ctrlBillToCompany.uccalBillToCmpStartDate.Enabled = false;
                ctrlBillToCompany.uccalBillToCmpEndDate.Enabled = false;
            }

            ctrlBillToCompany.ucMpeBillToCompany.Show();
        }

        protected void btnCommonBillToCompanyCallParent_Click(object sender, EventArgs e)
        {
            hdnAmtPayByCmp.Value = Convert.ToString(ctrlBillToCompany.dcmlAmtPayByCmp);
            decimal dcmlAmt = Convert.ToDecimal(hdnAmtPayByCmp.Value);

            lblPayableByCompany.Text = dcmlAmt.ToString().Substring(0, dcmlAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            txtPaymentAmount.Text = lblSplBillAmountToPay.Text = Convert.ToString(Convert.ToDecimal(lblPayableByGuest.Text.Trim()) - Convert.ToDecimal(lblPayableByCompany.Text.Trim()) - Convert.ToDecimal(lblSplBillTotalAmountReceived.Text.Trim()));

            if (txtPaymentAmount.Text != string.Empty && Convert.ToDecimal(txtPaymentAmount.Text) >= 0)
                this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text);

            if (Convert.ToDecimal(txtPaymentAmount.Text) == 0)
            {
                BindPaymentDetails();
            }
        }

        protected void btnPopupVoucherProceed_OnClick(object sender, EventArgs e)
        {
            lnkBilltoCompanySettlement.Visible = true;
            mpeCompareVoucher.Hide();
        }

        protected void btnUploadAndCompareVoucher_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    VoucherDetail IsVoucherDetailDup = new VoucherDetail();
                    IsVoucherDetailDup.VoucherNo = txtVoucherNo.Text.Trim();
                    IsVoucherDetailDup.IsActive = true;
                    IsVoucherDetailDup.PropertyID = clsSession.PropertyID;
                    IsVoucherDetailDup.AgentID = new Guid(ddlCompany.SelectedValue);

                    List<VoucherDetail> LstDupVoucherDetail = null;
                    LstDupVoucherDetail = VoucherDetailBLL.GetAll(IsVoucherDetailDup);

                    if (LstDupVoucherDetail.Count > 0)
                    {
                        if (this.VoucherDetailID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupVoucherDetail[0].VoucherDetailID)) != Convert.ToString(this.VoucherDetailID))
                            {
                                IsVoucherMessage = true;
                                lblVoucherMessage.Text = "Voucher no. for selected company already exist.";
                                return;
                            }
                        }
                        else
                        {
                            IsVoucherMessage = true;
                            lblVoucherMessage.Text = "Voucher no. for selected company already exist.";
                            return;
                        }
                    }

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    string path = "";
                    string cmpPhoto = "";

                    imgGuestVoucher.ImageUrl = "";

                    if (this.VoucherDetailID != Guid.Empty)
                    {
                        VoucherDetail objToUpdate = new VoucherDetail();
                        VoucherDetail objOldData = new VoucherDetail();

                        objOldData = VoucherDetailBLL.GetByPrimaryKey(this.VoucherDetailID);
                        objToUpdate = VoucherDetailBLL.GetByPrimaryKey(this.VoucherDetailID);

                        objToUpdate.AgentID = new Guid(ddlCompany.SelectedValue);
                        objToUpdate.VoucherNo = Convert.ToString(txtVoucherNo.Text.Trim());
                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.UpdatedOn = DateTime.Now;
                        objToUpdate.VoucherAuthorisedBy = Convert.ToString(txtVoucherAuthorisedBy.Text.Trim());
                        if (Convert.ToString(txtValidity.Text.Trim()) != "")
                            objToUpdate.Validity = DateTime.ParseExact(Convert.ToString(txtValidity.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                        else
                            objToUpdate.Validity = null;

                        if (fuVoucher.FileName != "")
                        {
                            cmpPhoto = Guid.NewGuid() + "$" + fuVoucher.FileName.Replace(" ", "_");
                            path = Server.MapPath("~/CompanyVoucher/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuVoucher.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();

                            objToUpdate.Voucher = cmpPhoto;
                        }
                        else
                            objToUpdate.Voucher = null;

                        VoucherDetailBLL.Update(objToUpdate);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objOldData.ToString(), objToUpdate.ToString(), "res_VoucherDetail", null);
                    }
                    else
                    {
                        VoucherDetail objToInsert = new VoucherDetail();

                        objToInsert.AgentID = new Guid(ddlCompany.SelectedValue);
                        objToInsert.ReservationID = this.ReservationID;
                        objToInsert.VoucherNo = Convert.ToString(txtVoucherNo.Text.Trim());
                        objToInsert.IsDirectBill = true;
                        objToInsert.IsActive = true;
                        objToInsert.UpdatedBy = clsSession.UserID;
                        objToInsert.UpdatedOn = DateTime.Now;
                        objToInsert.VoucherAuthorisedBy = Convert.ToString(txtVoucherAuthorisedBy.Text.Trim());
                        if (Convert.ToString(txtValidity.Text.Trim()) != "")
                            objToInsert.Validity = DateTime.ParseExact(Convert.ToString(txtValidity.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.PropertyID = clsSession.PropertyID;


                        if (fuVoucher.FileName != "")
                        {
                            cmpPhoto = Guid.NewGuid() + "$" + fuVoucher.FileName.Replace(" ", "_");
                            path = Server.MapPath("~/CompanyVoucher/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuVoucher.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();

                            objToInsert.Voucher = cmpPhoto;
                        }
                        else
                            objToInsert.Voucher = null;

                        VoucherDetailBLL.Save(objToInsert);
                        this.VoucherDetailID = objToInsert.VoucherDetailID;
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "res_VoucherDetail", null);
                    }

                    mpeCompareVoucher.Show();

                    if (File.Exists(path))
                    {
                        litGuestVoucherMsg.Visible = false;
                        imgGuestVoucher.ImageUrl = "~/CompanyVoucher/" + cmpPhoto;
                    }
                    else
                        litGuestVoucherMsg.Visible = true;

                    Corporate objCorporate = new Corporate();
                    objCorporate = CorporateBLL.GetByPrimaryKey(new Guid(ddlCompany.SelectedValue));
                    if (objCorporate != null)
                    {
                        if (Convert.ToString(objCorporate.VoucherImage) != "" && objCorporate.VoucherImage != null)
                        {
                            string strCmpVoucherPath = "http://pms.uniworldindia.com/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "CompanyMaster/" + objCorporate.VoucherImage;
                            iFrmTest.Attributes.Add("src", strCmpVoucherPath);

                            //////if (File.Exists(strCmpVoucherPath))
                            //////{
                            //////    imgCompanyVoucher.ImageUrl = strCmpVoucherPath;
                            //////    litCompanyVoucherMsg.Visible = false;
                            //////}
                            //////else
                            //////    litCompanyVoucherMsg.Visible = true;
                        }
                    }
                    else
                        litCompanyVoucherMsg.Visible = true;
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnVoucherProceed_Click(object sender, EventArgs e)
        {
            lnkBilltoCompanySettlement.Visible = true;
        }

        protected void btnAssignRoomNo_OnClick(object sender, EventArgs e)
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
                    RoomBlockBLL.InsertForComplementoryReservation((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID, false);
                }
                else if (objRateCardForCheckIsPerRoom.IsPerRoom == true)
                {
                    RoomBlockBLL.InsertForComplementoryReservation((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID, true);
                }
                if (objReservation.IsComplimentoryReservation == true && objReservation.RefInvestorID != null && Convert.ToString(objReservation.RefInvestorID) != string.Empty && Convert.ToString(objReservation.RefInvestorID) != Guid.Empty.ToString())
                {
                    ////To update IR's Voucher table by AllocatedRoomID
                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();
                    clnt.Update_ReservationAndAllocatedRoomID(Guid.NewGuid(), objReservation.ReservationID, objReservation.RoomID, "ALLOCATEDROOMID");
                }

                ddlRoomNumber.Enabled = false;
                btnAssignRoomNo.Visible = false;

                ////ctrlReservationVoucher.ReservationID = objReservation.ReservationID;
                ////ctrlReservationVoucher.BindReservationVoucherData();

                ////string strFDEEmailID = ConfigurationManager.AppSettings["IREmailAddress"].ToString();
                ////if (objReservation.IsComplimentoryReservation != null && objReservation.IsComplimentoryReservation == true && objReservation.RefInvestorID != null && Convert.ToString(objReservation.RefInvestorID) != string.Empty && Convert.ToString(objReservation.RefInvestorID) != Guid.Empty.ToString())
                ////{
                ////    ctrlReservationVoucher.SendMailTo(strFDEEmailID, "Complementory Reservation Voucher", "ComplementoryReservationVoucher", "COMPLEMENTORYRESERVATION");
                ////}
                ////mpeReservatinoVoucher.Show();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancelAssignRoom_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        private void BindCompany()
        {
            // string strCompany = "SELECT CorporateID,CompanyName FROM [dbo].[mst_Corporate]  WHERE ISNULL(IsActive,0) = 1 and ISNULL(IsDirectBill,1) = 1  and PropertyID ='" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID= '" + Convert.ToString(clsSession.CompanyID) + "' Order by [CompanyName] asc";

            DataSet dsCompany = CorporateBLL.GetCompanyData(clsSession.CompanyID, clsSession.PropertyID, true);
            ddlCompany.Items.Clear();
            if (dsCompany != null && dsCompany.Tables.Count > 0 && dsCompany.Tables[0].Rows.Count > 0)
            {
                ddlCompany.DataSource = dsCompany.Tables[0];
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CorporateID";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlCompany.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
        }

        private bool IsWholeRoomIsAvailable(DateTime? checkInDate, DateTime? checkOutDate)
        {
            bool isWholeRommAvailable = true;

            DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, this.RoomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
            DataSet dsRoomIDs = RoomBLL.GetAllRoomIDOfRoomByAnyRoomID(new Guid(ddlRoomNumber.SelectedValue), clsSession.PropertyID);

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
    }
}