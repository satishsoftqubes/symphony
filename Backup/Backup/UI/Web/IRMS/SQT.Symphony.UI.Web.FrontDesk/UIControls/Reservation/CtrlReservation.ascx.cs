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
using System.Globalization;
using System.Configuration;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlReservation : System.Web.UI.UserControl
    {
        #region Property and Variables
        /// <summary>
        /// Flag to maintain status whether Rate is calcuated or not
        /// </summary>
        public bool IsRateCalculated
        {
            get
            {
                return ViewState["IsRateCalculated"] != null ? Convert.ToBoolean(ViewState["IsRateCalculated"]) : false;
            }
            set
            {
                ViewState["IsRateCalculated"] = value;
            }
        }

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
        public Int32 DaysOfRateCard
        {
            get
            {
                return ViewState["DaysOfRateCard"] != null ? Convert.ToInt32(ViewState["DaysOfRateCard"]) : 0;
            }
            set
            {
                ViewState["DaysOfRateCard"] = value;
            }
        }

        public Guid ExistingGuestID
        {
            get
            {
                return ViewState["ExistingGuestID"] != null ? new Guid(Convert.ToString(ViewState["ExistingGuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ExistingGuestID"] = value;
            }
        }

        public Guid ExistingGuestAddressID
        {
            get
            {
                return ViewState["ExistingGuestAddressID"] != null ? new Guid(Convert.ToString(ViewState["ExistingGuestAddressID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ExistingGuestAddressID"] = value;
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

        public Guid ReservationTypeTermID
        {
            get
            {
                return ViewState["ReservationTypeTermID"] != null ? new Guid(Convert.ToString(ViewState["ReservationTypeTermID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationTypeTermID"] = value;
            }
        }

        public Guid RoomIDfromAVBLTchart
        {
            get
            {
                return ViewState["RoomIDfromAVBLTchart"] != null ? new Guid(Convert.ToString(ViewState["RoomIDfromAVBLTchart"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomIDfromAVBLTchart"] = value;
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
                if (Request.QueryString["InqID"] != null && Convert.ToString(Request.QueryString["InqID"]) != "")
                {
                    BindInquiryData(new Guid(Convert.ToString(Request.QueryString["InqID"])));
                }
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
        #endregion

        #region Control Event - Button event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsRateCalculated)
                {
                    MessageBox.Show("Please calculate rate of reservation.");
                    return;
                }
                else
                {
                    if (ReCalculateRateRequired())
                    {
                        MessageBox.Show("Please calculate rate of reservation.");
                        return;
                    }
                }

                if (txtPaymentAmount.Text.Trim() != string.Empty && Convert.ToInt32(txtPaymentAmount.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Amount should be greater than 0.");
                    return;
                }

                if (txtPaymentAmount.Text.Trim() != string.Empty && ddlModeOfPayment.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Mode of Payment.");
                    return;
                }

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                //// if payment mode is Credit card, then check Credit Card's Expiretion date Start
                String strPaymentMode = string.Empty;//// It will use to save Credit Card info. in ResPyamentGuest object
                ResGuestPaymentInfo objPaymentInfo = null;
                if (ddlModeOfPayment.SelectedIndex != 0)
                {
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
                    }
                }
                //// if payment mode is Credit card, then check Credit Card's Expiretion date End

                ////If complementory reservation by Investor, then check voucher's days and Reservaiton Days Start
                if (trInvestors.Visible == true && ddlInvestor.SelectedIndex != 0 && ddlInvestorVoucher.SelectedIndex != 0)
                {

                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();
                    DataSet dsInvestorDetail = clnt.GetVoucherDetailByVoucherID(new Guid(ddlInvestorVoucher.SelectedValue.ToString()));
                    if (dsInvestorDetail != null && dsInvestorDetail.Tables.Count > 0 && dsInvestorDetail.Tables[0].Rows.Count > 0)
                    {
                        int reservationDays = (Convert.ToInt32(((DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo)) - (DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo))).TotalDays));
                        if (reservationDays > Convert.ToInt32(dsInvestorDetail.Tables[0].Rows[0]["TotalNights"]))
                        {
                            MessageBox.Show("Reservation days should not be greater than allowed complementary days in voucher, you can't proceed.");
                            return;
                        }
                        if (dsInvestorDetail.Tables[0].Rows[0]["CheckInDate"] != null && (DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo).Equals(dsInvestorDetail.Tables[0].Rows[0]["CheckInDate"]) != true))
                        {
                            MessageBox.Show("Reservation Voucher checkin date does not match with selected checkin date, you can't proceed.");
                            return;
                        }
                        else if (dsInvestorDetail.Tables[0].Rows[0]["CheckOutDate"] != null && (DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo).Equals(dsInvestorDetail.Tables[0].Rows[0]["CheckOutDate"]) != true))
                        {
                            MessageBox.Show("Reservation Voucher checkout date does not match with selected checkout date, you can't proceed.");
                            return;
                        }
                        //if((DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo)).Equals(

                    }
                    else
                    {
                        MessageBox.Show("Voucher detail not found, please try again later.");
                        return;
                    }
                }
                ////If complementory reservation by Investor, then check voucher's days and Reservaiton Days Start

                //// If guest is not selected as Existing Guest, then check in db whether he/she exist or not Start
                if (this.ExistingGuestID == Guid.Empty)
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuestToCheckDPLKT = new BusinessLogic.FrontDesk.DTO.Guest();
                    objGuestToCheckDPLKT.PropertyID = clsSession.PropertyID;
                    objGuestToCheckDPLKT.CompanyID = clsSession.CompanyID;
                    objGuestToCheckDPLKT.FName = txtFirstName.Text.Trim();
                    objGuestToCheckDPLKT.LName = txtLastName.Text.Trim();
                    List<SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest> lstGuestWithSameName = GuestBLL.GetAll(objGuestToCheckDPLKT);

                    for (int i = 0; i < lstGuestWithSameName.Count; i++)
                    {
                        string[] strArrayPhone = Convert.ToString(lstGuestWithSameName[i].Phone1).Split('-');
                        if (strArrayPhone.Length > 1)
                        {
                            if (txtMobile.Text.Trim() == Convert.ToString(strArrayPhone[1]))
                            {
                                this.ExistingGuestID = lstGuestWithSameName[i].GuestID;
                                this.ExistingGuestAddressID = (Guid)lstGuestWithSameName[i].AddressID;
                                break;
                            }
                        }
                    }
                }
                //// If guest is not selected as Existing Guest, then check in db whether he/she exist or not End


                List<ProjectTerm> lstGenders = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GENDER");
                //// Object of Reservation Start
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objResToInsert = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();

                objResToInsert.PropertyID = clsSession.PropertyID;
                objResToInsert.CompanyID = clsSession.CompanyID;
                objResToInsert.ReservationType_TermID = this.ReservationTypeTermID;

                DateTime dtToSetCheckInOutDate = new DateTime();
                DateTime dtToSetStdCheckInOutTime = new DateTime();

                if (txtCheckInDate.Text.Trim() != string.Empty)
                {
                    //// Set standard check in time in Check in date.
                    if (this.StandardCheckInTime != string.Empty)
                    {
                        dtToSetCheckInOutDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckInTime);
                        objResToInsert.CheckInDate = new DateTime(dtToSetCheckInOutDate.Year, dtToSetCheckInOutDate.Month, Convert.ToInt32(dtToSetCheckInOutDate.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                    }
                    else
                    {
                        objResToInsert.CheckInDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    }
                }
                else
                    objResToInsert.CheckInDate = null;

                if (txtCheckOutDate.Text.Trim() != string.Empty)
                {
                    //// Set standard check out time in Check out date.
                    if (this.StandardCheckOutTime != string.Empty)
                    {
                        dtToSetCheckInOutDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckOutTime);
                        objResToInsert.CheckOutDate = new DateTime(dtToSetCheckInOutDate.Year, dtToSetCheckInOutDate.Month, Convert.ToInt32(dtToSetCheckInOutDate.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                    }
                    else
                    {
                        objResToInsert.CheckOutDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    }
                }
                else
                    objResToInsert.CheckOutDate = null;


                if (ddlRoomType.SelectedIndex != 0)
                    objResToInsert.RoomTypeID = new Guid(ddlRoomType.SelectedValue.ToString());
                else
                    objResToInsert.RoomTypeID = null;

                if (ddlRoomNumber.SelectedIndex != 0)
                    objResToInsert.RoomID = new Guid(ddlRoomNumber.SelectedValue.ToString());
                else
                    objResToInsert.RoomID = null;

                if (ddlCompany.SelectedIndex != 0)
                    objResToInsert.AgentID = new Guid(ddlCompany.SelectedValue.ToString());
                else
                    objResToInsert.AgentID = null;

                if (ddlRateCard.SelectedIndex != 0)
                    objResToInsert.RateID = new Guid(ddlRateCard.SelectedValue.ToString());
                else
                    objResToInsert.RateID = null;

                //// To Set Discount


                if (txtAdult.Text.Trim() != string.Empty)
                    objResToInsert.Adults = Convert.ToInt32(txtAdult.Text.Trim());
                else
                    objResToInsert.Adults = null;

                if (txtChild.Text.Trim() != string.Empty)
                    objResToInsert.Children = Convert.ToInt32(txtChild.Text.Trim());
                else
                    objResToInsert.Children = null;

                if (txtInfant.Text.Trim() != string.Empty)
                    objResToInsert.Infant = Convert.ToInt32(txtInfant.Text.Trim());
                else
                    objResToInsert.Infant = null;

                if (ddlSourceOfBusiness.SelectedIndex != 0)
                    objResToInsert.SourceOfBusiness_TermID = new Guid(ddlSourceOfBusiness.SelectedValue.ToString());
                else
                    objResToInsert.SourceOfBusiness_TermID = null;

                objResToInsert.IsToPickup = (rdbIsPicup.SelectedValue.ToString().ToUpper() == "YES");

                if (txtSpecificInstruction.Text.Trim() != string.Empty)
                    objResToInsert.SpecificNote = clsCommon.GetUpperCaseText(txtSpecificInstruction.Text.Trim());
                else
                    objResToInsert.SpecificNote = null;

                if (Request["WalkIn"] != null && Convert.ToString(Request["WalkIn"]).ToUpper() == "WALKIN")
                    objResToInsert.RestStatus_TermID = 27;
                else
                {
                    if (ddlBookingStatus.SelectedIndex != 0)
                        objResToInsert.RestStatus_TermID = Convert.ToInt32(ddlBookingStatus.SelectedValue);
                    else
                        objResToInsert.RestStatus_TermID = null;
                }

                if (ddlModeOfPayment.SelectedIndex != 0)
                    objResToInsert.MOP_TermID = new Guid(ddlModeOfPayment.SelectedValue.ToString());
                else
                    objResToInsert.MOP_TermID = null;

                if (ddlBillingInstruction.SelectedIndex != 0)
                    objResToInsert.BillingInstruction_TermID = new Guid(ddlBillingInstruction.SelectedValue.ToString());
                else
                    objResToInsert.BillingInstruction_TermID = null;

                objResToInsert.BookedBy = clsCommon.GetUpperCaseText(txtBookedBy.Text.Trim() != string.Empty ? txtBookedBy.Text.Trim() : null);

                if (trComplementoryResRefBy.Visible == true && ddlComplementoryRefBy.SelectedIndex != 0)
                {
                    objResToInsert.ComplimentoryReferenceBy = new Guid(ddlComplementoryRefBy.SelectedValue);
                    objResToInsert.IsComplimentoryReservation = true;
                }

                if (trInvestors.Visible == true && ddlInvestor.SelectedIndex != 0)
                {
                    objResToInsert.RefInvestorID = new Guid(ddlInvestor.SelectedValue);
                }

                objResToInsert.IsActive = true;
                objResToInsert.ReservationDate = DateTime.Now;
                objResToInsert.CreatedBy = clsSession.UserID;
                //// Object of Reservation End

                //// Object of Guest Start
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuestToInsert = new BusinessLogic.FrontDesk.DTO.Guest();

                if (this.ExistingGuestID != Guid.Empty)
                {
                    objGuestToInsert = GuestBLL.GetByPrimaryKey(this.ExistingGuestID);
                }

                ReservationGuest objResGuestToInsert = new ReservationGuest();

                objGuestToInsert.CompanyID = clsSession.CompanyID;
                objGuestToInsert.PropertyID = clsSession.PropertyID;

                if (ddlNationality.SelectedIndex != 0)
                    objGuestToInsert.Nationality = ddlNationality.SelectedValue.ToString();
                else
                    objGuestToInsert.Nationality = null;

                if (ddlTitle.SelectedIndex != 0)
                    objGuestToInsert.Title = Convert.ToString(ddlTitle.SelectedItem.Text);
                else
                    objGuestToInsert.Title = null;

                objGuestToInsert.FName = clsCommon.GetUpperCaseText(txtFirstName.Text.Trim());
                objGuestToInsert.LName = clsCommon.GetUpperCaseText(txtLastName.Text.Trim());
                objGuestToInsert.GuestFullName = clsCommon.GetUpperCaseText(Convert.ToString(ddlTitle.SelectedItem.Text) + " " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());

                if (ddlGuestType.SelectedIndex != 0)
                    objGuestToInsert.Guest_TypeID = new Guid(ddlGuestType.SelectedValue);
                else
                    objGuestToInsert.Guest_TypeID = null;

                //if (txtCountryMobileCode.Text.Trim() != string.Empty)
                //    objGuestToInsert.Phone1 = txtCountryMobileCode.Text.Trim() + "|";
                //else
                //    objGuestToInsert.Phone1 = objGuestToInsert.Phone1 + txtMobile.Text.Trim();

                if (txtCountryMobileCode.Text.Trim() == "")
                    objGuestToInsert.Phone1 = "-" + txtMobile.Text.Trim();
                else
                    objGuestToInsert.Phone1 = txtCountryMobileCode.Text.Trim() + "-" + txtMobile.Text.Trim();

                objGuestToInsert.Email = clsCommon.GetUpperCaseText(txtGuestEmail.Text.Trim());
                objGuestToInsert.CompanyName = clsCommon.GetUpperCaseText(txtCompanyName.Text.Trim());
                objGuestToInsert.IsActive = true;
                objGuestToInsert.IsBlocked = false;
                objGuestToInsert.IsMainGuest = true;
                objGuestToInsert.TotalNight = Convert.ToInt32(lblReservationDays.Text.Trim());
                objGuestToInsert.IsSmoking = (rdbLIsSmoking.SelectedValue.ToString().ToUpper() == "YES");

                Address GuestAddress = new Address();
                if (this.ExistingGuestAddressID != Guid.Empty)
                {
                    GuestAddress = AddressBLL.GetByPrimaryKey(this.ExistingGuestAddressID);
                }

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
                        if (lstGenders[1].DisplayTerm.ToUpper() == "MALE")
                        {
                            objResToInsert.Gender_TermID = lstGenders[1].TermID;
                            objGuestToInsert.Gender_TermID = lstGenders[1].TermID;
                        }
                        else
                        {
                            objResToInsert.Gender_TermID = lstGenders[0].TermID;
                            objGuestToInsert.Gender_TermID = lstGenders[0].TermID;
                        }
                    }
                    else
                    {
                        objResToInsert.Gender_TermID = lstGenders[0].TermID;
                        objGuestToInsert.Gender_TermID = lstGenders[0].TermID;
                    }
                }

                //// Object of Guest End

                objResGuestToInsert.CheckInDate = objResToInsert.CheckInDate;
                objResGuestToInsert.CheckOutDate = objResToInsert.CheckOutDate;
                objResGuestToInsert.PropertyID = objResToInsert.PropertyID;
                objResGuestToInsert.CompanyID = objResToInsert.CompanyID;
                objResGuestToInsert.IsActive = true;
                objResGuestToInsert.Status = clsCommon.GetUpperCaseText("Comming");
                objResGuestToInsert.CheckOutNote = txtCheckOutNote.Text.Trim();

                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolioToInsert = new BusinessLogic.FrontDesk.DTO.Folio();
                objFolioToInsert.CreationDate = DateTime.Now;
                objFolioToInsert.IsSubFolio = false;

                //objFolioToInsert.IsSourceFolio = false;
                //objFolioToInsert.IsDestinationFolio = false;
                //objFolioToInsert.IsDirectBill = false;
                //objFolioToInsert.IsLocked = false;
                //objFolioToInsert.IsSplitFolio = false;

                objFolioToInsert.PropertyID = clsSession.PropertyID;
                objFolioToInsert.CompanyID = clsSession.CompanyID;
                objFolioToInsert.IsActive = true;
                objFolioToInsert.FolioStatus = "IDEAL";

                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objAgentFolioToInsert = null;
                if (ddlCompany.SelectedIndex != 0)
                {
                    objAgentFolioToInsert = new BusinessLogic.FrontDesk.DTO.Folio();
                    objAgentFolioToInsert.CreationDate = DateTime.Now;
                    objAgentFolioToInsert.IsSubFolio = true;
                    objAgentFolioToInsert.AgentID = new Guid(ddlCompany.SelectedValue);

                    //objAgentFolioToInsert.IsSourceFolio = false;
                    //objAgentFolioToInsert.IsDestinationFolio = false;
                    //objAgentFolioToInsert.IsDirectBill = false;
                    //objAgentFolioToInsert.IsLocked = false;
                    //objAgentFolioToInsert.IsSplitFolio = false;

                    objAgentFolioToInsert.PropertyID = clsSession.PropertyID;
                    objAgentFolioToInsert.CompanyID = clsSession.CompanyID;
                    objAgentFolioToInsert.IsActive = true;
                }

                //// If Payment is done throubh creditcard, then save its information Start
                if (strPaymentMode == "CREDIT CARD")
                {
                    objPaymentInfo = new ResGuestPaymentInfo();
                    objPaymentInfo.MOP_TermID = new Guid(ddlModeOfPayment.SelectedValue);
                    objPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                    objPaymentInfo.CardNo = clsCommon.GetUpperCaseText(txtCardNumber.Text.Trim());
                    objPaymentInfo.CardHolderName = clsCommon.GetUpperCaseText(txtNameOnCard.Text.Trim());
                    objPaymentInfo.DateOfExpiry = new DateTime(Convert.ToInt32(ddlCardExpirationYear.SelectedValue), Convert.ToInt32(ddlCardExpirationMonth.SelectedValue), 1);

                    if (rdbPaymentOrBlock.SelectedValue.ToUpper() == "CHARGE")
                        objPaymentInfo.IsCreditCardCharged = true;
                    else
                        objPaymentInfo.IsCreditCardCharged = false;

                    objPaymentInfo.CVVNo = clsCommon.GetUpperCaseText(txtCVVNo.Text.Trim());
                    objPaymentInfo.PropertyID = clsSession.PropertyID;
                    objPaymentInfo.CompanyID = clsSession.CompanyID;
                    objPaymentInfo.IsActive = true;
                }
                //// If Payment is done throubh creditcard, then save its information End

                List<BlockDateRate> lstBlockDateRate = new List<BlockDateRate>();
                if (Session["lstNewReservationBlockDateRates"] != null)
                {
                    lstBlockDateRate = (List<BlockDateRate>)Session["lstNewReservationBlockDateRates"];
                }

                List<ResServiceList> lstResServiceList = new List<ResServiceList>();
                if (Session["lstNewReservationRoomServices"] != null)
                {
                    lstResServiceList = (List<ResServiceList>)Session["lstNewReservationRoomServices"];
                }

                bool IsExistingGuest = this.ExistingGuestID != Guid.Empty;

                if (lstBlockDateRate.Count > 0)
                {
                    ReservationBLL.Save(objResToInsert, objGuestToInsert, IsExistingGuest, GuestAddress, objResGuestToInsert, objFolioToInsert, objAgentFolioToInsert, lstBlockDateRate, lstResServiceList, objPaymentInfo);

                    if (trInvestors.Visible == true && ddlInvestor.SelectedIndex != 0)
                    {
                        ////To update IR's Voucher table by ReservationID
                        SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();
                        clnt.Update_ReservationAndAllocatedRoomID(new Guid(ddlInvestorVoucher.SelectedValue.ToString()), (Guid)objResToInsert.ReservationID, null, "RESERVATIONID");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(Convert.ToString("Session is terminated, please try again."));
                    return;
                }

                ReservationHistory objResHistory = new ReservationHistory();
                objResHistory.ReservationID = objResToInsert.ReservationID;
                objResHistory.Operation = "INSERT";
                objResHistory.OperationDate = DateTime.Now;
                objResHistory.OperationBy = clsSession.UserID;
                objResHistory.OldStatus_TermID = objResToInsert.RestStatus_TermID;
                objResHistory.NewStatus_TermID = objResToInsert.RestStatus_TermID;
                objResHistory.CompanyID = clsSession.CompanyID;
                objResHistory.PropertyID = clsSession.PropertyID;
                objResHistory.OldRecord = objResToInsert.ToString();
                ReservationHistoryBLL.Save(objResHistory);

                //// Save Paid Amount
                if (txtPaymentAmount.Text.Trim() != string.Empty && Convert.ToInt32(txtPaymentAmount.Text.Trim()) > 0)
                {
                    int Zone_TermID = 0;
                    Guid? PaymentAcctID = null;
                    Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                    Guid? CounterID = clsSession.DefaultCounterID; // new Guid("acadee48-26ec-4a92-8aae-bc2f8c4e8037"); //null;
                    Guid? ResPayID = null;
                    Guid? AssignedRoomID = null;

                    DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                    if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                        Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                    if (ddlLedgerAccount.Items.Count > 0)
                        PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                    if (objPaymentInfo != null)
                        ResPayID = objPaymentInfo.ResPayID;

                    if (ddlRoomNumber.Items.Count > 0)
                    {
                        if (ddlRoomNumber.SelectedIndex != 0)
                            AssignedRoomID = new Guid(ddlRoomNumber.SelectedValue);
                    }

                    TransactionBLL.InsertDeposit(Zone_TermID, Convert.ToDecimal(txtPaymentAmount.Text.Trim()), PaymentAcctID, DepositAcctID, objResToInsert.ReservationID, objFolioToInsert.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", AssignedRoomID, "ROOM DEPOSIT", clsSession.CompanyID, ResPayID);

                }

                if (Request["WalkIn"] != null && Convert.ToString(Request["WalkIn"]).ToUpper() == "WALKIN")
                {
                    clsSession.ToEditItemID = objResToInsert.ReservationID;
                    clsSession.ToEditItemType = "GUESTDETAILS";
                    Response.Redirect("~/GUI/Reservation/CheckIn.aspx");
                }

                ClearControl();
                ctrlReservationVoucher.ReservationID = objResToInsert.ReservationID;
                ctrlReservationVoucher.BindReservationVoucherData();
                mpeReservatinoVoucher.Show();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void chkIsPerRoomRateCard_CheckChanged(object sender, EventArgs e)
        {
            BindAvailableRateCards();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/RoomReservationList.aspx");
        }

        protected void lnkCheckRateCardAvailability_OnClick(object sender, EventArgs e)
        {
            BindAvailableRateCards();
        }

        protected void btnCalculateRate_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Session["lstNewReservationBlockDateRates"] != null)
                {
                    Session["lstNewReservationBlockDateRates"] = null;
                }

                if (Session["lstNewReservationRoomServices"] != null)
                {
                    Session["lstNewReservationRoomServices"] = null;
                }

                //// If calculation happen once Room No. is assigned, then re set Booking Status and Room List's dropdown; so that we have to select them again...
                string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
                ddlBookingStatus.SelectedIndex = 0;
                ddlRoomNumber.Items.Clear();
                ddlRoomNumber.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                rfvRoomNumber.Enabled = false;
                trAssignRoom.Visible = false;

                ////Check if User has changed check In-Check Out date when fill available rate cards...
                if ((txtCheckInDate.Text.Trim() != hdnRateCardAVBLTCheckInDate.Value) || (txtCheckOutDate.Text.Trim() != hdnRateCardAVBLTCheckOutDate.Value))
                {
                    MessageBox.Show("Reservation period has been updated, please check rate card's availability.");
                    return;
                }
                ////

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                Int32 ReservationDays = 0;
                bool isEarly = false; bool isLate = false;

                clsCommon.Reservation_GetTotalDays(null, DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), ref ReservationDays, ref isEarly, ref isLate);

                if (ReservationDays < this.DaysOfRateCard)
                {
                    MessageBox.Show("Selected rate card can't apply on selected reservation period.");
                    return;
                }

                List<BlockDateRate> lstBlockDateRate = new List<BlockDateRate>();
                List<ResServiceList> lstResServiceList = new List<ResServiceList>();
                string strStandardCheckInTime = string.Empty;
                string strStandardCheckOutTime = string.Empty;

                int intAdult = txtAdult.Text.Trim() != "" ? Convert.ToInt32(txtAdult.Text.Trim()) : 0;
                int intChild = txtChild.Text.Trim() != "" ? Convert.ToInt32(txtChild.Text.Trim()) : 0;

                lstBlockDateRate = clsBlockDateRate.GetCal_RoomWorksheet(DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), new Guid(ddlRoomType.SelectedValue), new Guid(ddlRateCard.SelectedValue), null, intAdult, intChild, string.Empty, ref lstResServiceList, ref strStandardCheckInTime, ref strStandardCheckOutTime, null, "NEW");

                this.StandardCheckInTime = strStandardCheckInTime;
                this.StandardCheckOutTime = strStandardCheckOutTime;

                decimal dcmlTotalRackRate = 0;
                decimal dcmlRoundoffTotalCharges = 0;
                decimal dcmlUpdateLastBlockdaterateamt = 0;
                decimal dcmlTotalTaxes = 0;
                decimal dcmlTotalInfraServiceCharges = Convert.ToDecimal("0.000000");
                decimal dcmlTotalFoodCharges = Convert.ToDecimal("0.000000");
                decimal dcmlTotalElectricityCharges = Convert.ToDecimal("0.000000");
                for (int i = 0; i < lstBlockDateRate.Count; i++)
                {

                    dcmlTotalRackRate += Convert.ToDecimal((lstBlockDateRate[i].RoomRate - lstBlockDateRate[i].AppliedTax));
                    dcmlTotalTaxes += Convert.ToDecimal(lstBlockDateRate[i].AppliedTax);
                    dcmlTotalInfraServiceCharges += Convert.ToDecimal(lstBlockDateRate[i].InfraServiceCharge);
                    dcmlTotalFoodCharges += Convert.ToDecimal(lstBlockDateRate[i].FoodCharge);
                    dcmlTotalElectricityCharges += Convert.ToDecimal(lstBlockDateRate[i].ElectricityCharge);
                }

                lblRackRate.Text = dcmlTotalRackRate.ToString().Substring(0, dcmlTotalRackRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                if (dcmlTotalTaxes == 0)
                    dcmlTotalTaxes = Convert.ToDecimal("0.000000");
                //string strMinAmount = txtMinAmount.Text.Trim().IndexOf('.') > -1 ? txtMinAmount.Text.Trim() + "000000" : txtMinAmount.Text.Trim() + ".000000";
                lblTotalTax.Text = dcmlTotalTaxes.ToString().Substring(0, dcmlTotalTaxes.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                dcmlTotalInfraServiceCharges = Math.Round(dcmlTotalInfraServiceCharges);
                dcmlTotalFoodCharges = Math.Round(dcmlTotalFoodCharges);
                dcmlTotalElectricityCharges = Math.Round(dcmlTotalElectricityCharges);
                lblInfraServiceCharges.Text = Convert.ToString(dcmlTotalInfraServiceCharges);
                lblFoodCharges.Text = Convert.ToString(dcmlTotalFoodCharges);
                lblElectricityCharges.Text = Convert.ToString(dcmlTotalElectricityCharges);

                decimal dcmlTotalCharges = dcmlTotalRackRate + dcmlTotalTaxes;
                
                dcmlRoundoffTotalCharges = Math.Round(dcmlTotalCharges);
                List<BlockDateRate> query = lstBlockDateRate.Distinct().ToList();
                List<BlockDateRate> lastRecord = query.Skip(query.Count - 1).ToList();
                if (dcmlRoundoffTotalCharges > dcmlTotalCharges)
                {
                    dcmlUpdateLastBlockdaterateamt = dcmlRoundoffTotalCharges - dcmlTotalCharges;
                    lastRecord[0].RoomRate = Convert.ToDecimal(lastRecord[0].RoomRate) + dcmlUpdateLastBlockdaterateamt;
                    lastRecord[0].RateCardRate = Convert.ToDecimal(lastRecord[0].RateCardRate) + dcmlUpdateLastBlockdaterateamt;
                }
                else
                {
                    dcmlUpdateLastBlockdaterateamt = dcmlTotalCharges - dcmlRoundoffTotalCharges;
                    lastRecord[0].RoomRate = Convert.ToDecimal(lastRecord[0].RoomRate) - dcmlUpdateLastBlockdaterateamt;
                    lastRecord[0].RateCardRate = Convert.ToDecimal(lastRecord[0].RateCardRate) - dcmlUpdateLastBlockdaterateamt;
                }

                lstBlockDateRate.RemoveAt(lstBlockDateRate.Count - 1);
                lstBlockDateRate.Add(lastRecord[lastRecord.Count - 1]);

                dcmlRoundoffTotalCharges = dcmlRoundoffTotalCharges + dcmlTotalInfraServiceCharges + dcmlTotalFoodCharges + dcmlTotalElectricityCharges;

                //lblTotalCharges.Text = dcmlTotalCharges.ToString().Substring(0, dcmlTotalCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                lblTotalCharges.Text = dcmlRoundoffTotalCharges.ToString() + ".00";

                lblDeposit.Text = lblMinAmountForConfirmReservation.Text;
                decimal dcmlTotalAmount = dcmlRoundoffTotalCharges + Convert.ToDecimal(lblDeposit.Text);
                //decimal dcmlTotalAmount = dcmlTotalRackRate + dcmlTotalTaxes + Convert.ToDecimal(lblDeposit.Text);
                lblTotalAmount.Text = dcmlTotalAmount.ToString().Substring(0, dcmlTotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                lblReservationDays.Text = Convert.ToString(ReservationDays);

                Session["lstNewReservationBlockDateRates"] = lstBlockDateRate;
                Session["lstNewReservationRoomServices"] = lstResServiceList;

                hdnCalRateCheckInDate.Value = Convert.ToString(txtCheckInDate.Text.Trim());
                hdnCalRateCheckOutDate.Value = Convert.ToString(txtCheckOutDate.Text.Trim());
                hdnCalRateRoomType.Value = Convert.ToString(ddlRoomType.SelectedValue);
                hdnCalRateRateCard.Value = Convert.ToString(ddlRateCard.SelectedValue);

                hdnCalRateAdult.Value = Convert.ToString(txtAdult.Text.Trim());
                hdnCalRateChild.Value = Convert.ToString(txtChild.Text.Trim());
                hdnCalRateInfant.Value = Convert.ToString(txtInfant.Text.Trim());

                tblRateCalculation.Visible = true;
                this.IsRateCalculated = true;
                //}
                //else
                //{
                //    MessageBox.Show("No rate card found for selected room type.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void lnkComplementaryReservation_OnClick(object sender, EventArgs e)
        {
            ddlRateCard.Items.Clear();
            ddlRateCard.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            txtGuestEmail.Text = "";
            txtMobile.Text = "";
            txtCheckOutDate.Text = "";
            txtCheckInDate.Text = "";
            //Bind Complementory Reservation Reference by.
            ddlComplementoryRefBy.Items.Clear();
            List<ProjectTerm> lstCompResRefBy = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "RES_COMPLEMENTARY_REFBY");
            if (lstCompResRefBy.Count != 0)
            {
                ddlComplementoryRefBy.DataSource = lstCompResRefBy;
                ddlComplementoryRefBy.DataTextField = "DisplayTerm";
                ddlComplementoryRefBy.DataValueField = "TermID";
                ddlComplementoryRefBy.DataBind();
                ddlComplementoryRefBy.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlComplementoryRefBy.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


            if (trComplementoryResRefBy.Visible == false)
            {
                trComplementoryResRefBy.Visible = rfvComplementoryRefBy.Enabled = true;
                ddlBillingInstruction.SelectedIndex = 3;
                ddlBillingInstruction.Enabled = false;

            }
            else
            {
                ddlComplementoryRefBy.SelectedIndex = 0;
                trComplementoryResRefBy.Visible = trInvestors.Visible = rfvComplementoryRefBy.Enabled = rfvInvestor.Enabled = trInvestorVoucher.Visible = rfvInvestorVoucher.Enabled = false;
                ddlBillingInstruction.SelectedIndex = 0;
                ddlBillingInstruction.Enabled = true;
            }
        }

        protected void btnSearchGuestInfo_Click(object sender, EventArgs e)
        {
            mpeSearchGuestInfo.Show();
            txtSearchGuestName.Text = "";
            gvSearchGuestList.DataSource = null;
            gvSearchGuestList.DataBind();
        }

        protected void btnSearchGuest_Click(object sender, EventArgs e)
        {
            DataTable dtGuests = null;
            if (txtSearchGuestName.Text != string.Empty || txtSearchMobileNo.Text.Trim() != string.Empty)
            {
                string strMobileNo = null;
                if (txtSearchMobileNo.Text.Trim() != string.Empty)
                    strMobileNo = txtSearchMobileNo.Text.Trim();

                DataSet dstGuest = GuestBLL.GetExistingGuest(txtSearchGuestName.Text.Trim(), strMobileNo, clsSession.PropertyID, clsSession.CompanyID);
                if (dstGuest != null && dstGuest.Tables[0].Rows.Count > 0)
                    dtGuests = dstGuest.Tables[0];
            }

            gvSearchGuestList.DataSource = dtGuests;
            gvSearchGuestList.DataBind();
            mpeSearchGuestInfo.Show();
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
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void btnRateCardSuggestionYes_OnClick(object sender, EventArgs e)
        {
            lblMinAmountForConfirmReservation.Text = "0.00";
            ddlRateCard.SelectedIndex = 0;
        }

        #endregion Control Event

        #region Control Event - Dropdown event
        protected void ddlInvestor_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlInvestor.SelectedIndex != 0)
                {
                    trInvestorVoucher.Visible = rfvInvestorVoucher.Enabled = true;
                    ddlInvestorVoucher.Items.Clear();

                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();

                    DataSet ds = clnt.GetVoucherListByInvestorIDInDataSet(new Guid(ddlInvestor.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = new DataView(ds.Tables[0]);
                        dv.Sort = "VoucherNo asc";
                        ddlInvestorVoucher.DataSource = dv;
                        ddlInvestorVoucher.DataTextField = "VoucherNo";
                        ddlInvestorVoucher.DataValueField = "ResVoucherID";
                        ddlInvestorVoucher.DataBind();
                        ddlInvestorVoucher.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlInvestorVoucher.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    trInvestorVoucher.Visible = rfvInvestorVoucher.Enabled = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void ddlInvestorVoucher_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlInvestorVoucher.SelectedIndex != 0)
                {
                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();
                    DataSet dsInvestorDetail = clnt.GetVoucherDetailByVoucherID(new Guid(ddlInvestorVoucher.SelectedValue.ToString()));
                    if (dsInvestorDetail != null && dsInvestorDetail.Tables.Count > 0 && dsInvestorDetail.Tables[0].Rows.Count > 0)
                    {
                        DataRow drForVouNo = dsInvestorDetail.Tables[0].Rows[0];
                        if (drForVouNo["Email"] != null && Convert.ToString(drForVouNo["Email"]) != string.Empty)
                            txtGuestEmail.Text = Convert.ToString(drForVouNo["Email"]);
                        else
                            txtGuestEmail.Text = "";

                        if (drForVouNo["Phone"] != null && Convert.ToString(drForVouNo["Phone"]) != string.Empty)
                            txtMobile.Text = Convert.ToString(drForVouNo["Phone"]);
                        else
                            txtMobile.Text = "";

                        if (drForVouNo["CheckInDate"] != null && Convert.ToString(drForVouNo["CheckInDate"]) != string.Empty)
                            txtCheckInDate.Text = Convert.ToDateTime(drForVouNo["CheckInDate"]).ToString(clsSession.DateFormat);
                        else
                            txtCheckInDate.Text = "";


                        if (drForVouNo["CheckOutDate"] != null && Convert.ToString(drForVouNo["CheckOutDate"]) != string.Empty)
                            txtCheckOutDate.Text = Convert.ToDateTime(drForVouNo["CheckOutDate"]).ToString(clsSession.DateFormat);
                        else
                            txtCheckOutDate.Text = "";

                    }
                    else
                    {
                        txtGuestEmail.Text = "";
                        txtMobile.Text = "";
                        txtCheckOutDate.Text = "";
                        txtCheckInDate.Text = "";
                        MessageBox.Show("Voucher detail not found, please try again later.");
                        return;
                    }
                }
                else
                {
                    txtGuestEmail.Text = "";
                    txtMobile.Text = "";
                    txtCheckOutDate.Text = "";
                    txtCheckInDate.Text = "";
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlComplementoryRefBy_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlComplementoryRefBy.SelectedItem.Text.ToUpper() == "INVESTOR")
                {
                    trInvestors.Visible = rfvInvestor.Enabled = true;
                    ddlInvestor.Items.Clear();

                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();

                    DataSet ds = clnt.GetInvestorListInDataSet(null);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = new DataView(ds.Tables[0]);
                        dv.Sort = "InvestorFullName asc";
                        ddlInvestor.DataSource = dv;
                        ddlInvestor.DataTextField = "InvestorFullName";
                        ddlInvestor.DataValueField = "InvestorID";
                        ddlInvestor.DataBind();
                        ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    trInvestors.Visible = rfvInvestor.Enabled = trInvestorVoucher.Visible = rfvInvestorVoucher.Enabled = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
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
            trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = false;
            if (ddlModeOfPayment.SelectedIndex != 0)
            {
                ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlModeOfPayment.SelectedValue));

                if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = false;
                    trChequeDD1.Visible = trChequeDD2.Visible = true;
                }
                else if (objProjectTerm.Term.Trim().ToUpper() == "CREDIT CARD")
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = false;
                    trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = true;

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

        protected void ddlBookingStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            ddlRoomNumber.Items.Clear();
            ddlRoomNumber.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            rfvRoomNumber.Enabled = false;

            if (ddlBookingStatus.SelectedValue == "28")
            {
                if (lblMinAmountForConfirmReservation.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please select any rate card before selecting booking status.");
                    ddlBookingStatus.SelectedIndex = 0;
                    return;
                }

                if (!IsRateCalculated)
                {
                    MessageBox.Show("Please calculate rate before selecting Confirm booking status.");
                    ddlBookingStatus.SelectedIndex = 0;
                    return;
                }

                if (txtPaymentAmount.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Payment is not done, you can't give confirm reservation.");
                    ddlBookingStatus.SelectedIndex = 0;
                    return;
                }

                if (txtPaymentAmount.Text.Trim() != string.Empty && Convert.ToDecimal(txtPaymentAmount.Text.Trim()) < Convert.ToDecimal(lblMinAmountForConfirmReservation.Text.Trim()))
                {
                    MessageBox.Show("Paid amout is less than Min. Amount for Confirm Reservation, you can't give confirm reservation.");
                    ddlBookingStatus.SelectedIndex = 0;
                    return;
                }

                DateTime? checkInDate = null;
                DateTime? checkOutDate = null;
                Guid? roomTypeID = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (txtCheckInDate.Text.Trim() != string.Empty)
                {
                    if (this.StandardCheckInTime != string.Empty)
                    {
                        DateTime checkInDateTemp = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        DateTime dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckInTime);
                        checkInDate = new DateTime(checkInDateTemp.Year, checkInDateTemp.Month, Convert.ToInt32(checkInDateTemp.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                    }
                    else
                        checkInDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                }

                if (txtCheckOutDate.Text.Trim() != string.Empty)
                {
                    if (this.StandardCheckOutTime != string.Empty)
                    {
                        DateTime CheckOutDateTemp = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        DateTime dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckOutTime);
                        checkOutDate = new DateTime(CheckOutDateTemp.Year, CheckOutDateTemp.Month, Convert.ToInt32(CheckOutDateTemp.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                    }
                    else
                        checkOutDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                }

                if (ddlRoomType.SelectedIndex != 0)
                    roomTypeID = new Guid(ddlRoomType.SelectedValue);

                DataSet dsAvailableRooms = ReservationBLL.GetAllVacantRoom(checkInDate, checkOutDate, roomTypeID, false, null, clsSession.PropertyID, clsSession.CompanyID);

                ////Check whether Room Is Available or not Start
                if (ddlBookingStatus.SelectedValue == "28")
                {
                    // Get room to sell.
                    DataSet dsRoomsToSell = ReservationBLL.ReservationSelectRoomsToSell(new Guid(ddlRoomType.SelectedValue), checkInDate, checkOutDate, null, null, clsSession.PropertyID, clsSession.CompanyID);
                    DataView rs = new DataView(dsRoomsToSell.Tables[0]);
                    rs.RowFilter = "RestStatus_TermID = 28 and RoomID is null";

                    int intAvailableRooms = dsAvailableRooms.Tables[0].Rows.Count - rs.Count;

                    if (!(intAvailableRooms > 0))
                    {
                        MessageBox.Show("Room is not available, you can't give confirm reservation.");
                        ddlBookingStatus.SelectedIndex = 0;
                        return;
                    }
                }
                ////Check whether Room Is Available or not End

                if (dsAvailableRooms != null && dsAvailableRooms.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsAvailableRooms.Tables[0].Rows.Count; i++)
                    {
                        ddlRoomNumber.Items.Insert(i + 1, new ListItem(clsCommon.GetFormatedRoomNumber(Convert.ToString(dsAvailableRooms.Tables[0].Rows[i]["RoomNo"])), Convert.ToString(dsAvailableRooms.Tables[0].Rows[i]["RoomID"])));
                    }

                    //// User come to this page by selecting room from room availability chart.
                    if (this.RoomIDfromAVBLTchart != Guid.Empty)
                    {
                        ddlRoomNumber.SelectedIndex = ddlRoomNumber.Items.FindByValue(Convert.ToString(this.RoomIDfromAVBLTchart)) != null ? ddlRoomNumber.Items.IndexOf(ddlRoomNumber.Items.FindByValue(Convert.ToString(this.RoomIDfromAVBLTchart))) : 0;
                    }
                }
                else
                    ddlRoomNumber.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                //// ddlRoomNumber is required
                rfvRoomNumber.Enabled = true;
                trAssignRoom.Visible = true;
            }
            else
            {
                ddlRoomNumber.SelectedIndex = 0;
                trAssignRoom.Visible = false;
            }
        }

        protected void ddlBookingReference_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            txtCompanyName.Enabled = true;
            txtCompanyName.Text = "";

            ddlCompany.Items.Clear();
            if (ddlBookingReference.SelectedIndex != 0)
            {
                if (ddlBookingReference.SelectedValue.ToUpper() == "COMPANY")
                {

                    DataSet dsCompany = CorporateBLL.GetCompanyData(clsSession.CompanyID, clsSession.PropertyID, true);
                    if (dsCompany != null && dsCompany.Tables.Count > 0 && dsCompany.Tables[0].Rows.Count > 0)
                    {
                        ddlCompany.DataSource = dsCompany.Tables[0];
                        ddlCompany.DataTextField = "CompanyName";
                        ddlCompany.DataValueField = "CorporateID";
                        ddlCompany.DataBind();
                        ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    }
                    else
                    {
                        ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    }

                    //Bind Companies
                    //Corporate objToGetList = new Corporate();

                    //objToGetList.IsDirectBill = true;
                    //objToGetList.IsActive = true;
                    //objToGetList.CompanyID = clsSession.CompanyID;
                    //objToGetList.PropertyID = clsSession.PropertyID;
                    //objToGetList.IsDirectBill = true;
                    //List<Corporate> lstCorporates = CorporateBLL.GetAllSearchData(objToGetList);

                    //if (lstCorporates.Count != 0)
                    //{
                    //    ddlCompany.DataSource = lstCorporates;
                    //    ddlCompany.DataTextField = "CompanyName";
                    //    ddlCompany.DataValueField = "CorporateID";
                    //    ddlCompany.DataBind();
                    //    ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    //}
                    //else
                    //    ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else if (ddlBookingReference.SelectedValue.ToUpper() == "AGENT")
                {

                    DataSet dsCompany = CorporateBLL.GetCompanyData(clsSession.CompanyID, clsSession.PropertyID, false);
                    if (dsCompany != null && dsCompany.Tables.Count > 0 && dsCompany.Tables[0].Rows.Count > 0)
                    {
                        ddlCompany.DataSource = dsCompany.Tables[0];
                        ddlCompany.DataTextField = "CompanyName";
                        ddlCompany.DataValueField = "CorporateID";
                        ddlCompany.DataBind();
                        ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    }
                    else
                    {
                        ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                    }



                    ////Bind Agent
                    //Corporate objToGetList = new Corporate();

                    //objToGetList.IsActive = true;
                    //objToGetList.CompanyID = clsSession.CompanyID;
                    //objToGetList.PropertyID = clsSession.PropertyID;
                    //objToGetList.IsDirectBill = false;
                    //List<Corporate> lstCorporates = CorporateBLL.GetAllSearchData(objToGetList);

                    //if (lstCorporates.Count != 0)
                    //{
                    //    ddlCompany.DataSource = lstCorporates;
                    //    ddlCompany.DataTextField = "CompanyName";
                    //    ddlCompany.DataValueField = "CorporateID";
                    //    ddlCompany.DataBind();
                    //    ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    //}
                    //else
                    //    ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
            }
            else
            {
                ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
        }

        protected void ddlRoomType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoomType.SelectedIndex != 0 && ddlRateCard.SelectedIndex != 0)
            {
                RateCardDetails objToGet = new RateCardDetails();
                objToGet.RateID = new Guid(ddlRateCard.SelectedValue);
                objToGet.RoomTypeID = new Guid(ddlRoomType.SelectedValue);
                objToGet.IsActive = true;

                List<RateCardDetails> lstRateCardDetails = RateCardDetailsBLL.GetAll(objToGet);
                if (lstRateCardDetails != null && lstRateCardDetails.Count > 0)
                {
                    if (lstRateCardDetails[0].DepositAmount != null && Convert.ToString(lstRateCardDetails[0].DepositAmount) != string.Empty)
                    {
                        string strDeposit = Convert.ToString(lstRateCardDetails[0].DepositAmount);
                        lblMinAmountForConfirmReservation.Text = strDeposit.Substring(0, strDeposit.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblMinAmountForConfirmReservation.Text = "";
                }
                else
                    lblMinAmountForConfirmReservation.Text = "";
            }

            //// Update RateCard ddl
            if (ddlRoomType.SelectedIndex != 0)
            {
                BindAvailableRateCards();
            }
            else
            {
                ddlRateCard.Items.Clear();
                string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
                ddlRateCard.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
        }

        protected void ddlCompany_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //// Update RateCard ddl
            if (ddlBookingReference.SelectedValue.ToUpper() == "COMPANY")
            {
                if (ddlCompany.SelectedIndex != 0)
                {
                    txtCompanyName.Enabled = false;
                    txtCompanyName.Text = ddlCompany.SelectedItem.Text.ToString();
                }
                else
                {
                    txtCompanyName.Enabled = true;
                    txtCompanyName.Text = "";
                }
            }
            else
            {
                txtCompanyName.Enabled = true;
                txtCompanyName.Text = "";
            }

            BindAvailableRateCards();
        }

        protected void ddlRateCard_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRateCard.SelectedIndex != 0)
            {
                RateCard objRateCard = RateCardBLL.GetByPrimaryKey(new Guid(ddlRateCard.SelectedValue));

                if (objRateCard.MinimumDaysRequired != null && Convert.ToString(objRateCard.MinimumDaysRequired) != "")
                {
                    this.DaysOfRateCard = Convert.ToInt32(objRateCard.MinimumDaysRequired);
                }

                if (ddlRoomType.SelectedIndex != 0)
                {
                    RateCardDetails objToGet = new RateCardDetails();
                    objToGet.RateID = new Guid(ddlRateCard.SelectedValue);
                    objToGet.RoomTypeID = new Guid(ddlRoomType.SelectedValue);
                    objToGet.IsActive = true;

                    List<RateCardDetails> lstRateCardDetails = RateCardDetailsBLL.GetAll(objToGet);
                    if (lstRateCardDetails != null && lstRateCardDetails.Count > 0)
                    {
                        if (lstRateCardDetails[0].DepositAmount != null && Convert.ToString(lstRateCardDetails[0].DepositAmount) != string.Empty)
                        {
                            string strDeposit = Convert.ToString(lstRateCardDetails[0].DepositAmount);
                            lblMinAmountForConfirmReservation.Text = strDeposit.Substring(0, strDeposit.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else
                            lblMinAmountForConfirmReservation.Text = "";
                    }
                    else
                        lblMinAmountForConfirmReservation.Text = "";
                }

                //Check Ratecard's selection is OK or not
                string strRateCardIDs = string.Empty;
                for (int i = 1; i < ddlRateCard.Items.Count; i++)
                {
                    strRateCardIDs = strRateCardIDs + ddlRateCard.Items[i].Value + ",";
                }

                DataSet dsRateCardsWithMinDays = RateCardBLL.GetRateCardsReqMinDaysByRateCardIDs(strRateCardIDs.TrimEnd(','));
                if (dsRateCardsWithMinDays != null && dsRateCardsWithMinDays.Tables[0].Rows.Count > 0)
                {
                    Guid suggestedRateCardID = Guid.Empty;
                    int intSuggestedRateCardsMinDays = 0;
                    string strSuggestedRateCardName = string.Empty;
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    Int32 ReservationDays = 0;
                    bool isEarly = false; bool isLate = false;
                    clsCommon.Reservation_GetTotalDays(null, DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), ref ReservationDays, ref isEarly, ref isLate);

                    for (int i = 0; i < dsRateCardsWithMinDays.Tables[0].Rows.Count; i++)
                    {
                        if (ReservationDays >= Convert.ToInt32(dsRateCardsWithMinDays.Tables[0].Rows[i]["MinimumDaysRequired"]))
                        {
                            suggestedRateCardID = new Guid(dsRateCardsWithMinDays.Tables[0].Rows[i]["RateID"].ToString());
                            intSuggestedRateCardsMinDays = Convert.ToInt32(dsRateCardsWithMinDays.Tables[0].Rows[i]["MinimumDaysRequired"].ToString());
                            strSuggestedRateCardName = Convert.ToString(dsRateCardsWithMinDays.Tables[0].Rows[i]["RateCardName"]);
                            break;
                        }
                    }

                    //To check that selected RateCard is same as suggested or selected RateCard is other than suggested but same Min. days as suggested Ratecard's min days.
                    if (new Guid(ddlRateCard.SelectedValue) != suggestedRateCardID)
                    {
                        DataRow[] drSelectedRateCard = dsRateCardsWithMinDays.Tables[0].Select("RateID = '" + Convert.ToString(ddlRateCard.SelectedValue) + "'");
                        if (drSelectedRateCard != null && drSelectedRateCard.Length > 0)
                        {
                            if (intSuggestedRateCardsMinDays != Convert.ToInt32(drSelectedRateCard[0]["MinimumDaysRequired"].ToString()))
                            {
                                lblRateCardSuggestion.Text = "Best rate card suggestion for this reservation period is <b>" + strSuggestedRateCardName + "</b>.";
                                mpeRateCardSuggestion.Show();
                            }
                        }
                    }
                }
            }
        }

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
            {
                txtStandardInstruction.Text = "";
            }
        }
        #endregion

        #region Private Method
        private void BindInquiryData(Guid InquiryID)
        {
            Inquiry objInquiryToLoad = new Inquiry();
            objInquiryToLoad = InquiryBLL.GetByPrimaryKey(InquiryID);
            if (objInquiryToLoad != null)
            {
                if (objInquiryToLoad.ArrivalDate != null && Convert.ToString(objInquiryToLoad.ArrivalDate) != "")
                {
                    txtCheckInDate.Text = Convert.ToDateTime(objInquiryToLoad.ArrivalDate).ToString(clsSession.DateFormat);
                }
                if (objInquiryToLoad.DepartureDate != null && Convert.ToString(objInquiryToLoad.DepartureDate) != "")
                {
                    txtCheckOutDate.Text = Convert.ToDateTime(objInquiryToLoad.DepartureDate).ToString(clsSession.DateFormat);
                }
                txtGuestEmail.Text = Convert.ToString(objInquiryToLoad.Email);

                if (Convert.ToString(objInquiryToLoad.Phone) != "")
                {
                    string[] mobileCode = Convert.ToString(objInquiryToLoad.Phone).Split('-');
                    txtCountryMobileCode.Text = mobileCode[0];
                    txtMobile.Text = mobileCode[1];
                }
                ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(objInquiryToLoad.Title)) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(objInquiryToLoad.Title))) : 0;
                txtFirstName.Text = Convert.ToString(objInquiryToLoad.FName);
                txtLastName.Text = Convert.ToString(objInquiryToLoad.LName);
                txtCompanyName.Text = Convert.ToString(objInquiryToLoad.Company_Name);
            }
        }
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "Reservation.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void LoadDataOnPageLoadEvent()
        {
            try
            {
                BindDDLs();

                if (Request["WalkIn"] != null && Convert.ToString(Request["WalkIn"]).ToUpper() == "WALKIN")
                {
                    txtCheckInDate.Text = txtCheckInDateWalkIn.Text = DateTime.Today.ToString(clsSession.DateFormat);
                    txtCheckInDateWalkIn.Enabled = txtCheckInDate.Visible = ddlFrequency.Visible = txtNight.Visible = false;
                    txtPaymentAmount.Enabled = ddlModeOfPayment.Enabled = rfvBookingStatus.Enabled = false;
                    ddlBookingStatus.Visible = false;
                    ltrWalkInReservationText.Text = "Walk In";
                }
                else
                {
                    txtCheckInDateWalkIn.Visible = false;
                }

                if (Session["RoomIDfromAVBLTchart"] != null)
                {
                    BindDataPassedFromAVBLTchart();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
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
            dr3["NameColumn"] = "New Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        public void BindDDLs()
        {
            string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            //Bind Room Types
            RoomType Rm = new RoomType();
            Rm.PropertyID = clsSession.PropertyID;
            Rm.IsActive = true;
            List<RoomType> LstRm = RoomTypeBLL.GetAll(Rm);
            if (LstRm.Count > 0)
            {
                LstRm.Sort((RoomType rm1, RoomType rm2) => rm1.RoomTypeName.CompareTo(rm2.RoomTypeName));
                ddlRoomType.DataSource = LstRm;
                ddlRoomType.DataTextField = "RoomTypeName";
                ddlRoomType.DataValueField = "RoomTypeID";
                ddlRoomType.DataBind();
                ddlRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            //Bind Companies
            ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            //Bind Standard Ratecards with index 0. It's data will bind at roomtype ddl selection changed.
            ddlRateCard.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            //Bind SourceOfBusiness
            List<ProjectTerm> lstSourceOfBusiness = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "SOURCEOFBUSINESS");
            if (lstSourceOfBusiness.Count != 0)
            {
                ddlSourceOfBusiness.DataSource = lstSourceOfBusiness;
                ddlSourceOfBusiness.DataTextField = "DisplayTerm";
                ddlSourceOfBusiness.DataValueField = "TermID";
                ddlSourceOfBusiness.DataBind();
                ddlSourceOfBusiness.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlSourceOfBusiness.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));


            //Bind BILLINGINSTRUCTION
            List<ProjectTerm> lstBillingInstructions = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "BILLINGINSTRUCTION");
            if (lstBillingInstructions.Count != 0)
            {
                ddlBillingInstruction.DataSource = lstBillingInstructions;
                ddlBillingInstruction.DataTextField = "DisplayTerm";
                ddlBillingInstruction.DataValueField = "TermID";
                ddlBillingInstruction.DataBind();
                ddlBillingInstruction.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlBillingInstruction.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));


            //Bind ModeOfPayment
            List<ProjectTerm> lstModeOfPayment = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
            if (lstModeOfPayment.Count != 0)
            {
                ddlModeOfPayment.DataSource = lstModeOfPayment;
                ddlModeOfPayment.DataTextField = "DisplayTerm";
                ddlModeOfPayment.DataValueField = "TermID";
                ddlModeOfPayment.DataBind();
                ddlModeOfPayment.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlModeOfPayment.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));


            //Bind ModeOfPayment
            DataSet dstBookingStatus = ProjectTermBLL.SelectAllResStatusByPageType("NEWRESERVATION", clsSession.CompanyID, clsSession.PropertyID);
            if (dstBookingStatus != null && dstBookingStatus.Tables[0].Rows.Count > 0)
            {
                ddlBookingStatus.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                int i = 1;
                foreach (DataRow dr in dstBookingStatus.Tables[0].Rows)
                {
                    if (Convert.ToString(dr["Term"]).ToUpper() == "UNCONFIRMED" || Convert.ToString(dr["Term"]).ToUpper() == "WAITING LIST")
                    {
                        ddlBookingStatus.Items.Insert(i, new ListItem(Convert.ToString(dr["DisplayTerm"]), Convert.ToString(dr["SymphonyValue"])));
                        i++;
                    }
                }
            }
            else
                ddlBookingStatus.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));


            //Bind Guest Name Title
            List<ProjectTerm> lstTitles = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "TITLE");
            if (lstTitles.Count != 0)
            {
                ddlTitle.DataSource = lstTitles;
                ddlTitle.DataTextField = "DisplayTerm";
                ddlTitle.DataValueField = "DisplayTerm";
                ddlTitle.DataBind();
                ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            //Bind Guest Name Title
            List<ProjectTerm> lstGuestType = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GUESTTYPE");
            if (lstGuestType.Count != 0)
            {
                ddlGuestType.DataSource = lstGuestType;
                ddlGuestType.DataTextField = "DisplayTerm";
                ddlGuestType.DataValueField = "TermID";
                ddlGuestType.DataBind();
                ddlGuestType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlGuestType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            //// add first index.
            ddlCreditCardType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            DataSet dsResTypeTerm = new DataSet();
            if (Request["WalkIn"] != null && Convert.ToString(Request["WalkIn"]).ToUpper() == "WALKIN")
                dsResTypeTerm = ProjectTermBLL.SelectReservationTypeTermID("WALK IN", clsSession.CompanyID, clsSession.PropertyID);
            else
                dsResTypeTerm = ProjectTermBLL.SelectReservationTypeTermID("ROOM RESERVATION", clsSession.CompanyID, clsSession.PropertyID);

            if (dsResTypeTerm.Tables.Count > 0 && dsResTypeTerm.Tables[0].Rows.Count > 0)
                this.ReservationTypeTermID = new Guid(Convert.ToString(dsResTypeTerm.Tables[0].Rows[0]["TermID"]));

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

            ddlNationality.SelectedIndex = ddlNationality.Items.FindByValue("Indian") != null ? ddlNationality.Items.IndexOf(ddlNationality.Items.FindByValue("Indian")) : 0;
        }

        public void BindDataPassedFromAVBLTchart()
        {
            this.RoomIDfromAVBLTchart = new Guid(Convert.ToString(Session["RoomIDfromAVBLTchart"]));
            txtCheckInDate.Text = Convert.ToString(Session["CheckInDatefromAVBLTchart"]);
            txtCheckOutDate.Text = Convert.ToString(Session["CheckOutDatefromAVBLTchart"]);

            ddlRoomType.SelectedIndex = ddlRoomType.Items.FindByValue(Convert.ToString(Session["RoomTypeIDfromAVBLTchart"])) != null ? ddlRoomType.Items.IndexOf(ddlRoomType.Items.FindByValue(Convert.ToString(Session["RoomTypeIDfromAVBLTchart"]))) : 0;
            ddlRoomType_OnSelectedIndexChanged(null, null);

            Session["RoomIDfromAVBLTchart"] = Session["CheckInDatefromAVBLTchart"] = Session["CheckOutDatefromAVBLTchart"] = Session["RoomTypeIDfromAVBLTchart"] = null;
        }

        /// <summary>
        /// If controls are changed after calculate rate button pressed and direct try to save without
        /// recalculate rate, return true to indicate that Re calculation is required.
        /// if controls are not changed, then it will return false to indicate that Re calculation is not required.
        /// </summary>
        /// <returns></returns>
        private bool ReCalculateRateRequired()
        {

            if (hdnCalRateCheckInDate.Value.ToUpper() != Convert.ToString(txtCheckInDate.Text.Trim().ToUpper()))
            {
                return true;
            }

            if (hdnCalRateCheckOutDate.Value.ToUpper() != Convert.ToString(txtCheckOutDate.Text.Trim().ToUpper()))
            {
                return true;
            }

            if (hdnCalRateRoomType.Value.ToUpper() != Convert.ToString(ddlRoomType.SelectedValue.ToUpper()))
            {
                return true;
            }

            if (hdnCalRateRateCard.Value.ToUpper() != Convert.ToString(ddlRateCard.SelectedValue.ToUpper()))
            {
                return true;
            }

            if (hdnCalRateAdult.Value.ToUpper() != Convert.ToString(txtAdult.Text.Trim().ToUpper()))
            {
                return true;
            }

            if (hdnCalRateChild.Value.ToUpper() != Convert.ToString(txtChild.Text.Trim().ToUpper()))
            {
                return true;
            }

            if (hdnCalRateInfant.Value.ToUpper() != Convert.ToString(txtInfant.Text.Trim().ToUpper()))
            {
                return true;
            }

            return false;
        }

        private void BindAvailableRateCards()
        {
            if (txtCheckInDate.Text.Trim() == string.Empty || txtCheckOutDate.Text.Trim() == string.Empty)
            {
                return;
            }

            hdnRateCardAVBLTCheckInDate.Value = txtCheckInDate.Text.Trim();
            hdnRateCardAVBLTCheckOutDate.Value = txtCheckOutDate.Text.Trim();

            DateTime? startDate = null;
            DateTime? endDate = null;
            Guid? roomTypeID = null;
            Guid? companyAgentID = null;
            Guid? travelAgentID = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            if (txtCheckInDate.Text.Trim() != string.Empty)
                startDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            if (txtCheckOutDate.Text.Trim() != string.Empty)
                endDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            if (ddlRoomType.SelectedIndex != 0)
                roomTypeID = new Guid(ddlRoomType.SelectedValue);

            if (ddlBookingReference.SelectedValue.ToUpper() == "COMPANY" && ddlCompany.SelectedIndex != 0)
                companyAgentID = new Guid(ddlCompany.SelectedValue);

            //// travelAgentID not to set, b'cas Rate card is not conntecte with travel Agent.

            DataSet dsAvailableRateCards = RateCardBLL.GetAllAvailableRateCards(startDate, endDate, roomTypeID, companyAgentID, travelAgentID, null, clsSession.PropertyID, clsSession.CompanyID);
            string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            ddlRateCard.Items.Clear();

            for (int i = 0; i < dsAvailableRateCards.Tables[0].Rows.Count; i++)
            {
                if (trComplementoryResRefBy.Visible)
                {
                    if (Convert.ToString(dsAvailableRateCards.Tables[0].Rows[i]["RateCardName"]) != "COMPLEMENTARY RATECARD")
                    {
                        dsAvailableRateCards.Tables[0].Rows.RemoveAt(i);
                        i--;
                    }
                }
                else
                {
                    if (Convert.ToString(dsAvailableRateCards.Tables[0].Rows[i]["RateCardName"]) == "COMPLEMENTARY RATECARD")
                    {
                        dsAvailableRateCards.Tables[0].Rows.RemoveAt(i);
                        i--;
                    }
                }
            }

            if (dsAvailableRateCards != null && dsAvailableRateCards.Tables[0].Rows.Count > 0)
            {

                DataView dvForAvailableRateCard;
                if (chkIsPerRoomRateCard.Checked)
                {
                    dvForAvailableRateCard = new DataView(dsAvailableRateCards.Tables[0]);
                    dvForAvailableRateCard.RowFilter = "IsPerRoom = 1";
                }
                else
                {
                    dvForAvailableRateCard = new DataView(dsAvailableRateCards.Tables[0]);
                    dvForAvailableRateCard.RowFilter = "(IsPerRoom = 0 Or IsPerRoom IS NULL)";
                }
                ddlRateCard.DataSource = dvForAvailableRateCard;
                ddlRateCard.DataTextField = "RateCardName";
                ddlRateCard.DataValueField = "RateID";
                ddlRateCard.DataBind();
                ddlRateCard.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlRateCard.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

        }

        public string GetMobileNo(string strPhoneNo)
        {
            string strReturn = "";
            string[] strArray = strPhoneNo.Split('-');
            if (strArray.Length > 1)
            {
                if (strArray[0] != "" && strArray[1] != "")
                    strReturn = strPhoneNo;
                else if (strArray[0] != "" && strArray[1] == "")
                    strReturn = Convert.ToString(strArray[0]);
                else
                    strReturn = Convert.ToString(strArray[1]);
            }
            else
                strReturn = "";
            return strReturn;
        }

        private void ClearControl()
        {
            txtCheckInDate.Text = txtNight.Text = txtCheckOutDate.Text = txtAdult.Text = txtChild.Text = txtInfant.Text = txtStandardInstruction.Text = txtSpecificInstruction.Text = "";
            txtFirstName.Text = txtLastName.Text = txtBookedBy.Text = txtMobile.Text = txtGuestEmail.Text = txtAddressLine1.Text = txtAddressLine2.Text = txtCityName.Text = txtZipCode.Text = txtStateName.Text = txtCountryName.Text = txtCompanyName.Text = txtPaymentAmount.Text = txtBankName.Text = txtChequeDDNo.Text = txtNameOnCard.Text = txtCardNumber.Text = txtCVVNo.Text = "";
            ddlFrequency.SelectedIndex = ddlRoomType.SelectedIndex = ddlBookingReference.SelectedIndex = ddlCompany.SelectedIndex = ddlRateCard.SelectedIndex = ddlGuestType.SelectedIndex = ddlSourceOfBusiness.SelectedIndex = ddlTitle.SelectedIndex = ddlBillingInstruction.SelectedIndex = ddlModeOfPayment.SelectedIndex = ddlBookingStatus.SelectedIndex = 0;

            //ddlComplementoryRefBy.SelectedIndex = ddlInvestor.SelectedIndex = 0;

            if (ddlCreditCardType.Items.Count > 0)
                ddlCreditCardType.SelectedIndex = 0;
            if (ddlCardExpirationMonth.Items.Count > 0)
                ddlCardExpirationMonth.SelectedIndex = 0;
            if (ddlRoomNumber.Items.Count > 0)
                ddlRoomNumber.SelectedIndex = 0;
            if (ddlCardExpirationYear.Items.Count > 0)
                ddlCardExpirationYear.SelectedIndex = 0;

            rdbLIsSmoking.SelectedIndex = rdbIsPicup.SelectedIndex = 1;
            rdbPaymentOrBlock.SelectedIndex = 0;

            Session["lstNewReservationBlockDateRates"] = Session["lstNewReservationRoomServices"] = null;
            hdnCalRateCheckInDate.Value = hdnCalRateCheckOutDate.Value = hdnCalRateRoomType.Value = hdnCalRateRateCard.Value = hdnCalRateAdult.Value = hdnCalRateChild.Value = hdnCalRateInfant.Value = hdnRateCardAVBLTCheckInDate.Value = hdnRateCardAVBLTCheckOutDate.Value = hdnIsBlackList.Value = lblReservationDays.Text = lblRackRate.Text = lblTotalTax.Text = lblTotalCharges.Text = lblDeposit.Text = lblTotalAmount.Text = lblMinAmountForConfirmReservation.Text = "";
            ddlModeOfPayment_OnSelectedIndexChanged(null, null);
            ////ddlBookingStatus_OnSelectedIndexChanged(null, null);

            this.IsRateCalculated = false;
            this.DaysOfRateCard = 0;
            this.ExistingGuestID = this.ExistingGuestAddressID = Guid.Empty;
            this.StandardCheckInTime = this.StandardCheckOutTime = string.Empty;

            ddlNationality.SelectedIndex = ddlNationality.Items.FindByValue("Indian") != null ? ddlNationality.Items.IndexOf(ddlNationality.Items.FindByValue("Indian")) : 0;
            txtCountryMobileCode.Text = "+91";
        }

        #endregion

        #region Grid Event
        protected void gvSearchGuestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((Label)e.Row.FindControl("lblMobileNo")).Text = GetMobileNo(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo")));
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
            if (e.CommandName.ToUpper().Equals("GETGUESTINFO"))
            {
                DataSet dsGeustInfo = GuestBLL.GetGuestInfoByGuestID(new Guid(e.CommandArgument.ToString()));
                if (dsGeustInfo != null && dsGeustInfo.Tables.Count > 0)
                {
                    DataRow drGuest = dsGeustInfo.Tables[0].Rows[0];

                    this.ExistingGuestID = new Guid(Convert.ToString(drGuest["GuestID"]));
                    this.ExistingGuestAddressID = new Guid(Convert.ToString(drGuest["AddressID"]));

                    //txtNationality.Text = Convert.ToString(drGuest["Nationality"]);
                    ddlNationality.SelectedIndex = ddlNationality.Items.FindByValue(Convert.ToString(drGuest["Nationality"])) != null ? ddlNationality.Items.IndexOf(ddlNationality.Items.FindByValue(Convert.ToString(drGuest["Nationality"]))) : 0;
                    txtFirstName.Text = Convert.ToString(drGuest["FName"]);
                    txtLastName.Text = Convert.ToString(drGuest["LName"]);
                    txtGuestEmail.Text = Convert.ToString(drGuest["Email"]);
                    txtAddressLine1.Text = Convert.ToString(drGuest["Add1"]);
                    txtAddressLine2.Text = Convert.ToString(drGuest["Add2"]);
                    txtCityName.Text = Convert.ToString(drGuest["CityName"]);
                    txtStateName.Text = Convert.ToString(drGuest["StateName"]);
                    txtCompanyName.Text = Convert.ToString(drGuest["CountryName"]);
                    txtZipCode.Text = Convert.ToString(drGuest["ZipCode"]);
                    txtCompanyName.Text = Convert.ToString(drGuest["CompanyName"]);
                    txtStandardInstruction.Text = Convert.ToString(drGuest["StandardInstruction"]);


                    string[] strArray = Convert.ToString(drGuest["MobileNo"]).Split('-');
                    if (strArray.Length > 1)
                    {
                        txtCountryMobileCode.Text = Convert.ToString(strArray[0]);
                        txtMobile.Text = Convert.ToString(strArray[1]);
                    }

                    ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(drGuest["Title"])) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(drGuest["Title"]))) : 0;
                    ddlGuestType.SelectedIndex = ddlGuestType.Items.FindByValue(Convert.ToString(drGuest["Guest_TypeID"])) != null ? ddlGuestType.Items.IndexOf(ddlGuestType.Items.FindByValue(Convert.ToString(drGuest["Guest_TypeID"]))) : 0;

                    for (int i = 0; i < rdbLIsSmoking.Items.Count; i++)
                    {
                        if (rdbLIsSmoking.Items[i].Text.ToUpper() == "YES" && Convert.ToBoolean(drGuest["IsSmoking"]) == true)
                            rdbLIsSmoking.Items[i].Selected = true;
                        else if (rdbLIsSmoking.Items[i].Text.ToUpper() == "NO" && Convert.ToBoolean(drGuest["IsSmoking"]) == false)
                            rdbLIsSmoking.Items[i].Selected = true;
                    }
                }

                mpeSearchGuestInfo.Hide();
            }
        }

        #endregion Grid Event
    }
}