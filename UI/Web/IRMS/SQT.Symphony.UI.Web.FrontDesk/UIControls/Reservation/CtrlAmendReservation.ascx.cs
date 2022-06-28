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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlAmendReservation : System.Web.UI.UserControl
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

        public Guid OperationRequestModeID
        {
            get
            {
                return ViewState["OperationRequestModeID"] != null ? new Guid(Convert.ToString(ViewState["OperationRequestModeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["OperationRequestModeID"] = value;
            }
        }

        public string OperationRequestBy
        {
            get
            {
                return ViewState["OperationRequestBy"] != null ? Convert.ToString(ViewState["OperationRequestBy"]) : string.Empty;
            }
            set
            {
                ViewState["OperationRequestBy"] = value;
            }
        }

        public int SymphonyValue
        {
            get
            {
                return ViewState["SymphonyValue"] != null ? Convert.ToInt32(ViewState["SymphonyValue"]) : 0;
            }
            set
            {
                ViewState["SymphonyValue"] = value;
            }
        }

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

        /// <summary>
        /// To save Reservation's Current Status Term id. It will user to ask 'Room will be deallocate' if Reservation status go from Confirm to other status.
        /// </summary>
        public Int32 ReservationsCurrentStatusTermID
        {
            get
            {
                return ViewState["ReservationsCurrentStatusTermID"] != null ? Convert.ToInt32(ViewState["ReservationsCurrentStatusTermID"]) : 0;
            }
            set
            {
                ViewState["ReservationsCurrentStatusTermID"] = value;
            }
        }

        #endregion

        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "AMENDMENTRESERVATION")
                {
                    this.ReservationID = clsSession.ToEditItemID;

                    if (!((Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "REINSTATE")))
                    {
                        this.OperationRequestModeID = new Guid(Convert.ToString(Session["CancelOperationRequestModeID"]));
                        this.OperationRequestBy = Convert.ToString(Session["CancelOperationRequestBy"]);
                        this.SymphonyValue = Convert.ToInt32(Convert.ToString(Session["CancelSymphonyValue"]));

                        Session.Remove("CancelOperationRequestModeID");
                        Session.Remove("CancelOperationRequestBy");
                        Session.Remove("CancelSymphonyValue");
                    }

                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                }
                LoadDefaultValue();
            }
        }

        #endregion

        #region Control Events

        //protected void chkAmendSelection_Change(object sender, EventArgs e)
        //{
        //    if (chkAmend.Items[0].Selected)
        //    {
        //        txtCheckInDate.Enabled = calCheckInDate.Enabled = ddlFrequency.Enabled = txtNight.Enabled = txtCheckOutDate.Enabled = calCheckOutDate.Enabled = ddlRoomType.Enabled = ddlCorporate.Enabled = ddlRateCard.Enabled = ddlDiscount.Enabled = txtAdult.Enabled = txtChild.Enabled = txtInfo.Enabled = ddlInfoGuest.Enabled = ddlSourceOfBussiness.Enabled = ftChild.Enabled = ftAdult.Enabled = ftInfo.Enabled = ddlAgent.Enabled = rdbIsPicup.Enabled = rdbLIsSmoking.Enabled = txtSpecificInstruction.Enabled = txtNote.Enabled = btnCalRate.Enabled = true;
        //    }
        //    else
        //    {
        //        txtCheckInDate.Enabled = calCheckInDate.Enabled = ddlFrequency.Enabled = txtNight.Enabled = txtCheckOutDate.Enabled = calCheckOutDate.Enabled = ddlRoomType.Enabled = ddlCorporate.Enabled = ddlRateCard.Enabled = ddlDiscount.Enabled = txtAdult.Enabled = txtChild.Enabled = txtInfo.Enabled = ddlInfoGuest.Enabled = ddlSourceOfBussiness.Enabled = ftChild.Enabled = ftAdult.Enabled = ftInfo.Enabled = ddlAgent.Enabled = rdbIsPicup.Enabled = rdbLIsSmoking.Enabled = txtSpecificInstruction.Enabled = txtNote.Enabled = btnCalRate.Enabled = false;
        //    }

        //    if (chkAmend.Items[1].Selected)
        //    {

        //        ddlNationality.Enabled = ddlTitle.Enabled = txtFirstName.Enabled = txtLastName.Enabled = txtBookedBy.Enabled = txtMobile.Enabled = txtCode.Enabled = txtGuestEmail.Enabled = txtAddress.Enabled = txtAddressLine2.Enabled = txtCityName.Enabled = txtZipCode.Enabled = txtStateName.Enabled = txtCountryName.Enabled = txtCompanyName.Enabled = txtPaymentAmount.Enabled = lnkComplementaryReservation.Enabled = ddlInvestor.Enabled = ddlGuestIDType.Enabled = ddlCardType.Enabled = txtNameOnCard.Enabled = txtCardNumber.Enabled = txtCVVNo.Enabled = ddlCardExpirationMonth.Enabled = ddlCardExpirationYear.Enabled = ddlModeOfPayment.Enabled = ddlStatus.Enabled = txtBankName.Enabled = txtChequeDDNo.Enabled = ddlComplementoryRefBy.Enabled = true;
        //    }

        //    else
        //    {
        //        ddlNationality.Enabled = ddlTitle.Enabled = txtFirstName.Enabled = txtLastName.Enabled = txtBookedBy.Enabled = txtMobile.Enabled = txtCode.Enabled = txtGuestEmail.Enabled = txtAddress.Enabled = txtAddressLine2.Enabled = txtCityName.Enabled = txtZipCode.Enabled = txtStateName.Enabled = txtCountryName.Enabled = txtCompanyName.Enabled = txtPaymentAmount.Enabled = lnkComplementaryReservation.Enabled = ddlInvestor.Enabled = ddlGuestIDType.Enabled = ddlCardType.Enabled = txtNameOnCard.Enabled = txtCardNumber.Enabled = txtCVVNo.Enabled = ddlCardExpirationMonth.Enabled = ddlCardExpirationYear.Enabled = ddlModeOfPayment.Enabled = ddlStatus.Enabled = txtBankName.Enabled = txtChequeDDNo.Enabled = ddlComplementoryRefBy.Enabled = false;
        //    }


        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                //// This case happen in Reinstate reservation.
                if (DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo) < DateTime.Today)
                {
                    MessageBox.Show("Check in date should not be less than today's date.");
                    return;
                }

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

                if (Convert.ToString(ddlBookingStatus.SelectedValue) == "28")
                {
                    decimal dcmlPaymentAmount = Convert.ToDecimal("0.00");
                    decimal dcmlPaidAmount = Convert.ToDecimal("0.00");
                    decimal dcmlMinAmountForRes = Convert.ToDecimal("0.00");

                    if (txtPaymentAmount.Text.Trim() != string.Empty)
                        dcmlPaymentAmount = Convert.ToDecimal(txtPaymentAmount.Text.Trim());

                    if (lblDispalyPaidAmount.Text.Trim() != "")
                        dcmlPaidAmount = Convert.ToDecimal(lblDispalyPaidAmount.Text.Trim());

                    if (lblMinAmountForConfirmReservation.Text.Trim() != "")
                        dcmlMinAmountForRes = Convert.ToDecimal(lblMinAmountForConfirmReservation.Text.Trim());

                    if (dcmlMinAmountForRes > (dcmlPaymentAmount + dcmlPaidAmount))
                    {
                        MessageBox.Show("You can't give confirm Booking status. Because paid amount is less than Min. Amount of Confirm Reservation.");
                        return;
                    }

                }
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
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationForCheck = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                RateCard objRateCardForCheckIsPerRoom = new RateCard();
                objRateCardForCheckIsPerRoom = RateCardBLL.GetByPrimaryKey(new Guid(Convert.ToString(objReservationForCheck.RateID)));
                if (ddlRoomNumber.SelectedIndex != 0)
                {
                    if (objRateCardForCheckIsPerRoom != null && objRateCardForCheckIsPerRoom.IsPerRoom == true)
                    {
                        if (!IsWholeRoomIsAvailable(objReservationForCheck.CheckInDate, objReservationForCheck.CheckOutDate, new Guid(ddlRoomNumber.SelectedValue)))
                        {

                            if (objRateCardForCheckIsPerRoom.IsPerRoom == true)
                            {
                                string strMessageToShow = "This reservation is full room reservation, you can't give partially occupied room to guest";
                                MessageBox.Show(strMessageToShow);
                                return;
                            }
                        }
                    }
                }
                //// if payment mode is Credit card, then check Credit Card's Expiretion date End

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
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objResToUpdate = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objOldResData = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();
                objResToUpdate = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                objOldResData = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                DateTime dtToSetCheckInOutDate = new DateTime();
                DateTime dtToSetStdCheckInOutTime = new DateTime();

                if (txtCheckInDate.Text.Trim() != string.Empty)
                {
                    //// Set standard check in time in Check in date.
                    if (this.StandardCheckInTime != string.Empty)
                    {
                        dtToSetCheckInOutDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckInTime);
                        objResToUpdate.CheckInDate = new DateTime(dtToSetCheckInOutDate.Year, dtToSetCheckInOutDate.Month, Convert.ToInt32(dtToSetCheckInOutDate.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                    }
                    else
                    {
                        objResToUpdate.CheckInDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    }
                }
                else
                    objResToUpdate.CheckInDate = null;

                if (txtCheckOutDate.Text.Trim() != string.Empty)
                {
                    //// Set standard check out time in Check out date.
                    if (this.StandardCheckOutTime != string.Empty)
                    {
                        dtToSetCheckInOutDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckOutTime);
                        objResToUpdate.CheckOutDate = new DateTime(dtToSetCheckInOutDate.Year, dtToSetCheckInOutDate.Month, Convert.ToInt32(dtToSetCheckInOutDate.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                    }
                    else
                    {
                        objResToUpdate.CheckOutDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    }
                }
                else
                    objResToUpdate.CheckOutDate = null;


                if (ddlRoomType.SelectedIndex != 0)
                    objResToUpdate.RoomTypeID = new Guid(ddlRoomType.SelectedValue.ToString());
                else
                    objResToUpdate.RoomTypeID = null;

                if (ddlRoomNumber.Items.Count > 0)
                {
                    if (ddlRoomNumber.SelectedIndex != 0)
                        objResToUpdate.RoomID = new Guid(ddlRoomNumber.SelectedValue.ToString());
                    else
                        objResToUpdate.RoomID = null;
                }
                else
                    objResToUpdate.RoomID = null;

                if (ddlCompany.SelectedIndex != 0)
                    objResToUpdate.AgentID = new Guid(ddlCompany.SelectedValue.ToString());
                else
                    objResToUpdate.AgentID = null;

                if (ddlRateCard.SelectedIndex != 0)
                    objResToUpdate.RateID = new Guid(ddlRateCard.SelectedValue.ToString());
                else
                    objResToUpdate.RateID = null;

                //// To Set Discount


                if (txtAdult.Text.Trim() != string.Empty)
                    objResToUpdate.Adults = Convert.ToInt32(txtAdult.Text.Trim());
                else
                    objResToUpdate.Adults = null;

                if (txtChild.Text.Trim() != string.Empty)
                    objResToUpdate.Children = Convert.ToInt32(txtChild.Text.Trim());
                else
                    objResToUpdate.Children = null;

                if (txtInfant.Text.Trim() != string.Empty)
                    objResToUpdate.Infant = Convert.ToInt32(txtInfant.Text.Trim());
                else
                    objResToUpdate.Infant = null;

                if (ddlSourceOfBusiness.SelectedIndex != 0)
                    objResToUpdate.SourceOfBusiness_TermID = new Guid(ddlSourceOfBusiness.SelectedValue.ToString());
                else
                    objResToUpdate.SourceOfBusiness_TermID = null;

                objResToUpdate.IsToPickup = (rdbIsPicup.SelectedValue.ToString().ToUpper() == "YES");

                if (txtSpecificInstruction.Text.Trim() != string.Empty)
                    objResToUpdate.SpecificNote = clsCommon.GetUpperCaseText(txtSpecificInstruction.Text.Trim());
                else
                    objResToUpdate.SpecificNote = null;

                if (ddlBookingStatus.SelectedIndex != 0)
                    objResToUpdate.RestStatus_TermID = Convert.ToInt32(ddlBookingStatus.SelectedValue);
                else
                    objResToUpdate.RestStatus_TermID = null;

                if (ddlModeOfPayment.SelectedIndex != 0)
                    objResToUpdate.MOP_TermID = new Guid(ddlModeOfPayment.SelectedValue.ToString());
                else
                    objResToUpdate.MOP_TermID = null;

                if (ddlBillingInstruction.SelectedIndex != 0)
                    objResToUpdate.BillingInstruction_TermID = new Guid(ddlBillingInstruction.SelectedValue.ToString());
                else
                    objResToUpdate.BillingInstruction_TermID = null;

                objResToUpdate.BookedBy = txtBookedBy.Text.Trim() != string.Empty ? txtBookedBy.Text.Trim() : null;

                //// Object of Reservation End

                //// Object of Guest Start
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuestToUpdate = new BusinessLogic.FrontDesk.DTO.Guest();

                if (this.ExistingGuestID != Guid.Empty)
                {
                    objGuestToUpdate = GuestBLL.GetByPrimaryKey(this.ExistingGuestID);
                    objResToUpdate.GuestID = objGuestToUpdate.GuestID;
                }
                else
                {
                    objGuestToUpdate = GuestBLL.GetByPrimaryKey((Guid)(objResToUpdate.GuestID));
                }


                if (ddlNationality.SelectedIndex != 0)
                    objGuestToUpdate.Nationality = ddlNationality.SelectedValue.ToString();
                else
                    objGuestToUpdate.Nationality = null;



                if (ddlTitle.SelectedIndex != 0)
                    objGuestToUpdate.Title = Convert.ToString(ddlTitle.SelectedItem.Text);
                else
                    objGuestToUpdate.Title = null;

                objGuestToUpdate.FName = clsCommon.GetUpperCaseText(txtFirstName.Text.Trim());
                objGuestToUpdate.LName = clsCommon.GetUpperCaseText(txtLastName.Text.Trim());
                objGuestToUpdate.GuestFullName = clsCommon.GetUpperCaseText(Convert.ToString(ddlTitle.SelectedItem.Text) + " " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim());

                if (ddlGuestType.SelectedIndex != 0)
                    objGuestToUpdate.Guest_TypeID = new Guid(ddlGuestType.SelectedValue);
                else
                    objGuestToUpdate.Guest_TypeID = null;

                //if (txtCountryMobileCode.Text.Trim() != string.Empty)
                //    objGuestToInsert.Phone1 = txtCountryMobileCode.Text.Trim() + "|";
                //else
                //    objGuestToInsert.Phone1 = objGuestToInsert.Phone1 + txtMobile.Text.Trim();

                if (txtCountryMobileCode.Text.Trim() == "")
                    objGuestToUpdate.Phone1 = "-" + txtMobile.Text.Trim();
                else
                    objGuestToUpdate.Phone1 = txtCountryMobileCode.Text.Trim() + "-" + txtMobile.Text.Trim();

                objGuestToUpdate.Email = clsCommon.GetUpperCaseText(txtGuestEmail.Text.Trim());
                objGuestToUpdate.CompanyName = clsCommon.GetUpperCaseText(txtCompanyName.Text.Trim());
                objGuestToUpdate.TotalNight = Convert.ToInt32(lblReservationDays.Text.Trim());
                objGuestToUpdate.IsSmoking = (rdbLIsSmoking.SelectedValue.ToString().ToUpper() == "YES");

                Address GuestAddress = new Address();
                GuestAddress = AddressBLL.GetByPrimaryKey((Guid)(objGuestToUpdate.AddressID));

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
                        {
                            objResToUpdate.Gender_TermID = lstGenders[0].TermID;
                            objGuestToUpdate.Gender_TermID = lstGenders[0].TermID;
                        }
                        else
                        {
                            objResToUpdate.Gender_TermID = lstGenders[1].TermID;
                            objGuestToUpdate.Gender_TermID = lstGenders[1].TermID;
                        }
                    }
                    else
                    {
                        objResToUpdate.Gender_TermID = lstGenders[1].TermID;
                        objGuestToUpdate.Gender_TermID = lstGenders[1].TermID;
                    }
                }

                //// Object of Guest End

                ReservationGuest objResGuestToInsert = new ReservationGuest();

                objResGuestToInsert.CheckInDate = objResToUpdate.CheckInDate;
                objResGuestToInsert.CheckOutDate = objResToUpdate.CheckOutDate;
                objResGuestToInsert.PropertyID = objResToUpdate.PropertyID;
                objResGuestToInsert.CompanyID = objResToUpdate.CompanyID;
                objResGuestToInsert.IsActive = true;
                objResGuestToInsert.Status = "Comming";

                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolioToUpdate = new BusinessLogic.FrontDesk.DTO.Folio();
                objFolioToUpdate = FolioBLL.GetByPrimaryKey((Guid)objResToUpdate.FolioID);

                objFolioToUpdate.GuestID = objGuestToUpdate.GuestID;

                List<SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio> lstAgentFolio = new List<BusinessLogic.FrontDesk.DTO.Folio>();
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objGetAgentFolio = new BusinessLogic.FrontDesk.DTO.Folio();

                objGetAgentFolio.ReservationID = objResToUpdate.ReservationID;
                objGetAgentFolio.GuestID = objGuestToUpdate.GuestID;
                objGetAgentFolio.ParentFolioID = objFolioToUpdate.FolioID;
                objGetAgentFolio.IsSubFolio = true;
                objGetAgentFolio.IsActive = true;
                objGetAgentFolio.PropertyID = clsSession.PropertyID;
                objGetAgentFolio.CompanyID = clsSession.CompanyID;

                lstAgentFolio = FolioBLL.GetAll(objGetAgentFolio);

                int agentcount = 0;
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objAgentFolio = null;

                if (ddlCompany.SelectedIndex != 0)
                {
                    objAgentFolio = new BusinessLogic.FrontDesk.DTO.Folio();

                    if (lstAgentFolio.Count > 0)
                    {
                        objAgentFolio = lstAgentFolio[0];
                        agentcount = 1;
                    }
                    else
                    {
                        objAgentFolio.CreationDate = DateTime.Now;
                        objAgentFolio.IsSubFolio = true;
                        objAgentFolio.PropertyID = clsSession.PropertyID;
                        objAgentFolio.CompanyID = clsSession.CompanyID;
                        objAgentFolio.IsActive = true;
                        agentcount = 0;
                    }

                    objAgentFolio.AgentID = new Guid(ddlCompany.SelectedValue);
                }
                else
                {
                    if (lstAgentFolio.Count > 0)
                    {
                        // Agent Folio is available and if they not select agent
                        agentcount = 2;
                    }
                }

                //// If Payment is done throubh creditcard, then save its information Start
                if (strPaymentMode == "CREDIT CARD")
                {
                    objPaymentInfo = new ResGuestPaymentInfo();
                    objPaymentInfo.MOP_TermID = new Guid(ddlModeOfPayment.SelectedValue);
                    objPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                    objPaymentInfo.CardNo = txtCardNumber.Text.Trim();
                    objPaymentInfo.CardHolderName = txtNameOnCard.Text.Trim();
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

                ReservationBLL.AmendReservation(objResToUpdate, objGuestToUpdate, IsExistingGuest, GuestAddress, objResGuestToInsert, lstBlockDateRate, lstResServiceList, objPaymentInfo, objFolioToUpdate, objAgentFolio, agentcount);

                if (!((Session["Mode"] != null && Convert.ToString(Session["Mode"]).ToUpper() == "REINSTATE")))
                {
                    ReservationHistory objResHistory = new ReservationHistory();
                    objResHistory.ReservationID = objResToUpdate.ReservationID;
                    objResHistory.Operation = "UPDATE";
                    objResHistory.OperationDate = DateTime.Now;
                    objResHistory.OperationBy = clsSession.UserID;
                    objResHistory.OldStatus_TermID = objOldResData.RestStatus_TermID;
                    objResHistory.NewStatus_TermID = Convert.ToInt32(ddlBookingStatus.SelectedValue);
                    objResHistory.CompanyID = clsSession.CompanyID;
                    objResHistory.PropertyID = clsSession.PropertyID;
                    objResHistory.OldRecord = objOldResData.ToString();
                    objResHistory.OperationRequestBy = Convert.ToString(this.OperationRequestBy);
                    objResHistory.OperationRequestMode_TermID = this.OperationRequestModeID;

                    ReservationHistoryBLL.Save(objResHistory);
                }

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

                    TransactionBLL.InsertDeposit(Zone_TermID, Convert.ToDecimal(txtPaymentAmount.Text.Trim()), PaymentAcctID, DepositAcctID, objResToUpdate.ReservationID, objFolioToUpdate.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", AssignedRoomID, "ROOM DEPOSIT", clsSession.CompanyID, ResPayID);

                }
                if (objRateCardForCheckIsPerRoom != null && objRateCardForCheckIsPerRoom.IsPerRoom == true)
                {
                    RoomBlockBLL.DeleteForOldandInsertForNewRoomBlockDetails((DateTime)objResToUpdate.CheckInDate, (DateTime)objResToUpdate.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objResToUpdate.RoomID, (Guid)objResToUpdate.RoomTypeID, (Guid)objResToUpdate.ReservationID, true);
                }
                ClearControl();
                ctrlReservationVoucher.ReservationID = objResToUpdate.ReservationID;
                ctrlReservationVoucher.BindReservationVoucherData();
                mpeReservatinoVoucher.Show();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/GUI/Reservation/AmendmentList.aspx");
        }

        protected void lnkComplementaryReservation_OnClick(object sender, EventArgs e)
        {
            if (trComplementoryReservationType.Visible == false)
            {
                trComplementoryReservationType.Visible = true;
            }
            else
            {
                ddlComplementoryRefBy.SelectedIndex = ddlInvestor.SelectedIndex = 0;
                trComplementoryReservationType.Visible = trInvestors.Visible = false;
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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

                SetBookingStatusDDL();

                List<BlockDateRate> lstBlockDateRate = new List<BlockDateRate>();
                List<ResServiceList> lstResServiceList = new List<ResServiceList>();
                string strStandardCheckInTime = string.Empty;
                string strStandardCheckOutTime = string.Empty;

                int intAdult = txtAdult.Text.Trim() != "" ? Convert.ToInt32(txtAdult.Text.Trim()) : 0;
                int intChild = txtChild.Text.Trim() != "" ? Convert.ToInt32(txtChild.Text.Trim()) : 0;

                lstBlockDateRate = clsBlockDateRate.GetCal_RoomWorksheet(DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo), new Guid(ddlRoomType.SelectedValue), new Guid(ddlRateCard.SelectedValue), null, intAdult, intChild, string.Empty, ref lstResServiceList, ref strStandardCheckInTime, ref strStandardCheckOutTime, this.ReservationID, "EDIT");

                this.StandardCheckInTime = strStandardCheckInTime;
                this.StandardCheckOutTime = strStandardCheckOutTime;

                decimal dcmlTotalRackRate = Convert.ToDecimal("0.000000");
                decimal dcmlTotalTaxes = Convert.ToDecimal("0.000000");
                decimal dcmlRoundoffTotalCharges = 0;
                decimal dcmlUpdateLastBlockdaterateamt = 0;
                for (int i = 0; i < lstBlockDateRate.Count; i++)
                {
                    dcmlTotalRackRate += Convert.ToDecimal((lstBlockDateRate[i].RoomRate - lstBlockDateRate[i].AppliedTax));
                    dcmlTotalTaxes += Convert.ToDecimal(lstBlockDateRate[i].AppliedTax);
                }

                lblRackRate.Text = dcmlTotalRackRate.ToString().Substring(0, dcmlTotalRackRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                if (dcmlTotalTaxes == 0)
                    dcmlTotalTaxes = Convert.ToDecimal("0.000000");
                //string strMinAmount = txtMinAmount.Text.Trim().IndexOf('.') > -1 ? txtMinAmount.Text.Trim() + "000000" : txtMinAmount.Text.Trim() + ".000000";
                lblTotalTax.Text = dcmlTotalTaxes.ToString().Substring(0, dcmlTotalTaxes.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

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




                //lblTotalCharges.Text = dcmlTotalCharges.ToString().Substring(0, dcmlTotalCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                lblTotalCharges.Text = dcmlRoundoffTotalCharges.ToString() + ".00";

                lblDeposit.Text = lblMinAmountForConfirmReservation.Text;

                // decimal dcmlTotalAmount = dcmlTotalRackRate + dcmlTotalTaxes + Convert.ToDecimal(lblDeposit.Text);
                decimal dcmlTotalAmount = dcmlRoundoffTotalCharges + Convert.ToDecimal(lblDeposit.Text);
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

        protected void lnkCheckRateCardAvailability_OnClick(object sender, EventArgs e)
        {
            BindAvailableRateCards();
        }

        //protected void ddlModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlModeOfPayment.SelectedIndex == 0 || ddlModeOfPayment.SelectedIndex == 1)
        //    {
        //        trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
        //    }
        //    else if (ddlModeOfPayment.SelectedIndex == 2 || ddlModeOfPayment.SelectedIndex == 3)
        //    {
        //        trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
        //        trChequeDD1.Visible = trChequeDD2.Visible = true;
        //    }
        //    else if (ddlModeOfPayment.SelectedIndex == 4)
        //    {
        //        trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
        //        trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = true;
        //    }
        //}
        #endregion

        #region Private Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "AmendReservation.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private bool IsWholeRoomIsAvailable(DateTime? checkInDate, DateTime? checkOutDate, Guid RoomID)
        {
            bool isWholeRommAvailable = true;

            DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, new Guid(ddlRoomType.SelectedValue), this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
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
            dr3["NameColumn"] = "Amend Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void LoadReservationData()
        {
            try
            {
                if (this.ReservationID != Guid.Empty)
                {
                    DataSet dsRservationData = ReservationBLL.GetArrivalListData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, null, null, null, null, null, "DETAILS", null);

                    if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                    {
                        DataRow drData = dsRservationData.Tables[0].Rows[0];

                        txtAddressLine1.Text = Convert.ToString(drData["Add1"]);
                        txtAddressLine2.Text = Convert.ToString(drData["Add2"]);
                        txtAdult.Text = Convert.ToString(drData["Adults"]);
                        txtBookedBy.Text = Convert.ToString(drData["BookedBy"]);
                        txtCardNumber.Text = Convert.ToString(GetCardNo(Convert.ToString(drData["CardNo"])));

                        DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(drData["CheckInDate"]));
                        DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(drData["CheckOutDate"]));
                        txtCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                        txtCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                        txtChild.Text = Convert.ToString(drData["DisplayChildren"]);
                        txtCityName.Text = Convert.ToString(drData["CityName"]);
                        txtCompanyName.Text = Convert.ToString(drData["CompanyName"]);
                        txtCountryName.Text = Convert.ToString(drData["CountryName"]);
                        txtFirstName.Text = Convert.ToString(drData["FName"]);
                        ddlNationality.SelectedIndex = ddlNationality.Items.FindByValue(Convert.ToString(drData["Nationality"])) != null ? ddlNationality.Items.IndexOf(ddlNationality.Items.FindByValue(Convert.ToString(drData["Nationality"]))) : 0;
                        txtGuestEmail.Text = Convert.ToString(drData["Email"]);
                        txtInfant.Text = Convert.ToString(drData["DisplayInfant"]);
                        txtLastName.Text = Convert.ToString(drData["LName"]);

                        if (Convert.ToString(drData["Phone1"]) != "")
                        {
                            string[] strArray = Convert.ToString(drData["Phone1"]).Split('-');
                            if (strArray.Length > 1)
                            {
                                txtCountryMobileCode.Text = Convert.ToString(strArray[0]);
                                txtMobile.Text = Convert.ToString(strArray[1]);
                            }
                        }
                        else
                        {
                            txtCountryMobileCode.Text = "";
                            txtMobile.Text = "";
                        }

                        txtSpecificInstruction.Text = Convert.ToString(drData["SpecificNote"]);
                        txtStandardInstruction.Text = Convert.ToString(drData["StandardInstruction"]);
                        txtStateName.Text = Convert.ToString(drData["StateName"]);
                        txtZipCode.Text = Convert.ToString(drData["ZipCode"]);

                        ddlRoomType.SelectedIndex = ddlRoomType.Items.FindByValue(Convert.ToString(drData["RoomTypeID"])) != null ? ddlRoomType.Items.IndexOf(ddlRoomType.Items.FindByValue(Convert.ToString(drData["RoomTypeID"]))) : 0;

                        if (Convert.ToString(drData["BookingReference"]).ToUpper() == "COMPANY")
                            ddlBookingReference.SelectedIndex = 1;
                        else if (Convert.ToString(drData["BookingReference"]).ToUpper() == "AGENT")
                            ddlBookingReference.SelectedIndex = 2;
                        else if (Convert.ToString(drData["BookingReference"]).ToUpper() == "NOTHING")
                            ddlBookingReference.SelectedIndex = 0;

                        ddlBookingReference_OnSelectedIndexChanged(null, null);
                        ddlCompany.SelectedIndex = ddlCompany.Items.FindByValue(Convert.ToString(drData["AgentID"])) != null ? ddlCompany.Items.IndexOf(ddlCompany.Items.FindByValue(Convert.ToString(drData["AgentID"]))) : 0;

                        BindAvailableRateCards();

                        ddlGuestType.SelectedIndex = ddlGuestType.Items.FindByValue(Convert.ToString(drData["Guest_TypeID"])) != null ? ddlGuestType.Items.IndexOf(ddlGuestType.Items.FindByValue(Convert.ToString(drData["Guest_TypeID"]))) : 0;
                        ddlSourceOfBusiness.SelectedIndex = ddlSourceOfBusiness.Items.FindByValue(Convert.ToString(drData["SourceOfBusiness_TermID"])) != null ? ddlSourceOfBusiness.Items.IndexOf(ddlSourceOfBusiness.Items.FindByValue(Convert.ToString(drData["SourceOfBusiness_TermID"]))) : 0;
                        ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(drData["Title"])) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(drData["Title"]))) : 0;
                        ddlBillingInstruction.SelectedIndex = ddlBillingInstruction.Items.FindByValue(Convert.ToString(drData["BillingInstruction_TermID"])) != null ? ddlBillingInstruction.Items.IndexOf(ddlBillingInstruction.Items.FindByValue(Convert.ToString(drData["BillingInstruction_TermID"]))) : 0;
                        ////ddlModeOfPayment.SelectedIndex = ddlModeOfPayment.Items.FindByValue(Convert.ToString(drData["MOP_TermID"])) != null ? ddlModeOfPayment.Items.IndexOf(ddlModeOfPayment.Items.FindByValue(Convert.ToString(drData["MOP_TermID"]))) : 0;

                        hdnRoomID.Value = Convert.ToString(drData["RoomID"]);

                        ddlModeOfPayment.SelectedIndex = 0;

                        if (Convert.ToString(drData["RestStatus_TermID"]) == "28")
                            lblDisplayRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(Convert.ToString(drData["RoomNo"])));
                        else
                            lblDisplayRoomNo.Text = "";

                        ddlRateCard.SelectedIndex = ddlRateCard.Items.FindByValue(Convert.ToString(drData["RateID"])) != null ? ddlRateCard.Items.IndexOf(ddlRateCard.Items.FindByValue(Convert.ToString(drData["RateID"]))) : 0;

                        ddlRateCard_OnSelectedIndexChanged(null, null);

                        for (int i = 0; i < rdbLIsSmoking.Items.Count; i++)
                        {
                            if (Convert.ToString(drData["IsSmoking"]) != "")
                            {
                                if (rdbLIsSmoking.Items[i].Text.ToUpper() == "YES" && Convert.ToBoolean(drData["IsSmoking"]) == true)
                                    rdbLIsSmoking.Items[i].Selected = true;
                                else if (rdbLIsSmoking.Items[i].Text.ToUpper() == "NO" && Convert.ToBoolean(drData["IsSmoking"]) == false)
                                    rdbLIsSmoking.Items[i].Selected = true;
                            }
                        }

                        for (int i = 0; i < rdbIsPicup.Items.Count; i++)
                        {
                            if (Convert.ToString(drData["IsToPickUp"]) != "")
                            {
                                if (rdbIsPicup.Items[i].Text.ToUpper() == "YES" && Convert.ToBoolean(drData["IsToPickUp"]) == true)
                                    rdbLIsSmoking.Items[i].Selected = true;
                                else if (rdbIsPicup.Items[i].Text.ToUpper() == "NO" && Convert.ToBoolean(drData["IsToPickUp"]) == false)
                                    rdbLIsSmoking.Items[i].Selected = true;
                            }
                        }

                        btnCalculateRate_OnClick(null, null);
                        txtPaymentAmount.Text = "";

                        DataSet dsGetAmount = ReservationBLL.GetReservationPaymentInfo(clsSession.PropertyID, clsSession.CompanyID, this.ReservationID);

                        if (dsGetAmount.Tables.Count > 0 && dsGetAmount.Tables.Count > 3 && dsGetAmount.Tables[3].Rows.Count > 0)
                        {
                            decimal dcmlPaidAmount = Convert.ToDecimal(Convert.ToString(dsGetAmount.Tables[3].Rows[0]["TotalPaidAmount"]));
                            lblDispalyPaidAmount.Text = dcmlPaidAmount.ToString().Substring(0, dcmlPaidAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else
                            lblDispalyPaidAmount.Text = "0.00";

                        ddlBookingStatus.SelectedIndex = ddlBookingStatus.Items.FindByValue(Convert.ToString(drData["RestStatus_TermID"])) != null ? ddlBookingStatus.Items.IndexOf(ddlBookingStatus.Items.FindByValue(Convert.ToString(drData["RestStatus_TermID"]))) : 0;

                        ////In Reinstant reservation, it's selected index is 0, so set with Provisional
                        if (ddlBookingStatus.SelectedIndex == 0)
                            ddlBookingStatus.SelectedIndex = ddlBookingStatus.Items.FindByValue("27") != null ? ddlBookingStatus.Items.IndexOf(ddlBookingStatus.Items.FindByValue("27")) : 0;

                        ddlBookingStatus_OnSelectedIndexChanged(null, null);

                        this.ReservationsCurrentStatusTermID = Convert.ToInt32(drData["RestStatus_TermID"].ToString());
                        lblDisplayBookingStatus.Text = Convert.ToString(drData["Status"]);


                        //Status
                        //txtNameOnCard.Text = "";
                        //txtGuestIDDetail.Text = "XYZ";
                        //txtCVVNo.Text = "12356";
                        //txtPaymentAmount.Text = "12000";
                        //txtChequeDDNo.Text = "23156456145";
                        //txtBankName.Text = Convert.ToString(drData["Add1"]);
                    }
                    else
                    {
                        txtAddressLine1.Text = txtAddressLine2.Text = txtAdult.Text = txtBankName.Text = txtBookedBy.Text = txtCardNumber.Text = txtCheckInDate.Text = txtCheckOutDate.Text = txtChequeDDNo.Text = txtChild.Text = txtCityName.Text = txtCountryMobileCode.Text = txtCompanyName.Text = txtCountryName.Text = txtCVVNo.Text = txtDOB.Text = txtFirstName.Text = txtGuestEmail.Text = txtGuestIDDetail.Text = txtInfant.Text = txtLastName.Text = txtMobile.Text = txtNameOnCard.Text = txtSpecificInstruction.Text = txtPaymentAmount.Text = txtStandardInstruction.Text = txtStateName.Text = txtZipCode.Text = "";
                        lblDispalyPaidAmount.Text = "0.00";
                        lblDisplayBookingStatus.Text = lblDisplayRoomNo.Text = "";
                    }

                    //ddlCardExpirationMonth.SelectedIndex = ddlCardExpirationYear.SelectedIndex = ddlCardType.SelectedIndex = ddlComplementoryRefBy.SelectedIndex = ddlCorporate.SelectedIndex = ddlDiscount.SelectedIndex = ddlFrequency.SelectedIndex = ddlGuestIDType.SelectedIndex = ddlInfoGuest.SelectedIndex = ddlInvestor.SelectedIndex = ddlModeOfPayment.SelectedIndex = ddlNationality.SelectedIndex = ddlRateCard.SelectedIndex = ddlRoomType.SelectedIndex = ddlSourceOfBussiness.SelectedIndex = ddlStatus.SelectedIndex = ddlStayType.SelectedIndex = ddlTitle.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadDefaultValue()
        {
            try
            {
                BindBreadCrumb();
                BindProjectTermData();
                LoadReservationData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindAvailableRateCards()
        {
            try
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
                if (dsAvailableRateCards != null && dsAvailableRateCards.Tables[0].Rows.Count > 0)
                {
                    ddlRateCard.DataSource = dsAvailableRateCards.Tables[0];
                    ddlRateCard.DataTextField = "RateCardName";
                    ddlRateCard.DataValueField = "RateID";
                    ddlRateCard.DataBind();
                    ddlRateCard.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlRateCard.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindProjectTermData()
        {
            try
            {
                DataSet dsProjectTermData = ReservationBLL.GetReservationProjectTermData(clsSession.PropertyID, clsSession.CompanyID, "GUESTTYPE", "SOURCEOFBUSINESS", "TITLE", "BILLINGINSTRUCTION", "PAYMENTMODE");
                string strSelect = clsCommon.GetUpperCaseText("-Select-");

                ddlRoomType.Items.Clear();
                ddlGuestType.Items.Clear();
                ddlSourceOfBusiness.Items.Clear();
                ddlBillingInstruction.Items.Clear();
                ddlModeOfPayment.Items.Clear();
                ddlTitle.Items.Clear();
                ddlBookingStatus.Items.Clear();

                if (dsProjectTermData != null && dsProjectTermData.Tables.Count > 0)
                {
                    ddlRoomType.DataSource = dsProjectTermData.Tables[0];
                    ddlRoomType.DataTextField = "RoomTypeName";
                    ddlRoomType.DataValueField = "RoomTypeID";
                    ddlRoomType.DataBind();
                    ddlRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                    ddlGuestType.DataSource = dsProjectTermData.Tables[1];
                    ddlGuestType.DataTextField = "DisplayTerm";
                    ddlGuestType.DataValueField = "TermID";
                    ddlGuestType.DataBind();
                    ddlGuestType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                    ddlSourceOfBusiness.DataSource = dsProjectTermData.Tables[2];
                    ddlSourceOfBusiness.DataTextField = "DisplayTerm";
                    ddlSourceOfBusiness.DataValueField = "TermID";
                    ddlSourceOfBusiness.DataBind();
                    ddlSourceOfBusiness.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));


                    ddlTitle.DataSource = dsProjectTermData.Tables[3];
                    ddlTitle.DataTextField = "DisplayTerm";
                    ddlTitle.DataValueField = "DisplayTerm";
                    ddlTitle.DataBind();
                    ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                    ddlBillingInstruction.DataSource = dsProjectTermData.Tables[4];
                    ddlBillingInstruction.DataTextField = "DisplayTerm";
                    ddlBillingInstruction.DataValueField = "TermID";
                    ddlBillingInstruction.DataBind();
                    ddlBillingInstruction.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                    ddlModeOfPayment.DataSource = dsProjectTermData.Tables[5];
                    ddlModeOfPayment.DataTextField = "DisplayTerm";
                    ddlModeOfPayment.DataValueField = "TermID";
                    ddlModeOfPayment.DataBind();
                    ddlModeOfPayment.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                    ddlBookingStatus.DataSource = dsProjectTermData.Tables[6];
                    ddlBookingStatus.DataTextField = "DisplayTerm";
                    ddlBookingStatus.DataValueField = "SymphonyValue";
                    ddlBookingStatus.DataBind();
                    ddlBookingStatus.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                {
                    ddlRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlGuestType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlSourceOfBusiness.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlBillingInstruction.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlModeOfPayment.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ddlBookingStatus.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }


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
                {
                    ddlNationality.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetCardNo(string strCardNo)
        {
            string strReturn = "";
            if (strCardNo.Length == 16)
            {
                strReturn = "************" + strCardNo.Substring(12, 4);
            }
            return strReturn;
        }

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

        private void ClearControl()
        {
            txtCheckInDate.Text = txtCheckOutDate.Text = txtAdult.Text = txtChild.Text = txtInfant.Text = txtStandardInstruction.Text = txtSpecificInstruction.Text = "";
            txtFirstName.Text = txtLastName.Text = txtBookedBy.Text = txtCountryMobileCode.Text = txtMobile.Text = txtGuestEmail.Text = txtAddressLine1.Text = txtAddressLine2.Text = txtCityName.Text = txtZipCode.Text = txtStateName.Text = txtCountryName.Text = txtCompanyName.Text = txtPaymentAmount.Text = txtBankName.Text = txtChequeDDNo.Text = txtNameOnCard.Text = txtCardNumber.Text = txtCVVNo.Text = "";
            ddlRoomType.SelectedIndex = ddlBookingReference.SelectedIndex = ddlCompany.SelectedIndex = ddlRateCard.SelectedIndex = ddlGuestType.SelectedIndex = ddlSourceOfBusiness.SelectedIndex = ddlTitle.SelectedIndex = ddlBillingInstruction.SelectedIndex = ddlModeOfPayment.SelectedIndex = ddlBookingStatus.SelectedIndex = 0;

            ddlNationality.SelectedIndex = 0;
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
            ddlBookingStatus_OnSelectedIndexChanged(null, null);

            this.IsRateCalculated = false;
            this.DaysOfRateCard = 0;
            this.ExistingGuestID = this.ExistingGuestAddressID = this.ReservationTypeTermID = Guid.Empty;
            this.StandardCheckInTime = this.StandardCheckOutTime = string.Empty;

            lblDisplayBookingStatus.Text = lblDisplayRoomNo.Text = "";
            lblDispalyPaidAmount.Text = "0.00";
        }

        private void SetBookingStatusDDL()
        {
            if (IsPostBack)
            {
                ddlRoomNumber.SelectedIndex = 0;
                trAssignRoom.Visible = false;
                rfvRoomNumberForAmend.Enabled = false;
                ddlBookingStatus.Enabled = true;
                ddlBookingStatus.SelectedIndex = 0;

                if (!(Convert.ToDecimal(lblDispalyPaidAmount.Text) >= Convert.ToDecimal(lblMinAmountForConfirmReservation.Text)))
                {
                    for (int i = 0; i < ddlBookingStatus.Items.Count; i++)
                    {
                        if (Convert.ToString(ddlBookingStatus.Items[i].Value) == "28")
                        {
                            ddlBookingStatus.Items.RemoveAt(i);
                        }
                    }
                }
            }
        }

        #endregion

        #region Control Event - Dropdown event

        protected void ddlInvestor_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlInvestor.SelectedIndex != 0)
                {
                    ddlTitle.SelectedIndex = 2;

                    if (ddlInvestor.SelectedIndex == 1)
                    {
                        txtFirstName.Text = "Pradeep";
                        txtLastName.Text = "Patel";
                    }
                    else
                    {
                        txtFirstName.Text = "Shyam";
                        txtLastName.Text = "Benegal";
                    }
                }
                else
                {
                    ddlTitle.SelectedIndex = 0;
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlComplementoryRefBy_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlComplementoryRefBy.SelectedValue.ToUpper() == "INVESTOR")
                {
                    trInvestors.Visible = true;
                }
                else
                {
                    trInvestors.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlBookingStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
                ddlRoomNumber.Items.Clear();
                ddlRoomNumber.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                if (ddlBookingStatus.SelectedValue == "28")
                {
                    if (lblMinAmountForConfirmReservation.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please select any rate card before selecting booking status.");
                        ddlBookingStatus.SelectedIndex = 0;
                        return;
                    }

                    ////if (txtPaymentAmount.Text.Trim() == string.Empty)
                    ////{
                    ////    MessageBox.Show("Payment is not done, you can't give confirm reservation.");
                    ////    ddlBookingStatus.SelectedIndex = 0;
                    ////    return;
                    ////}

                    ////if (txtPaymentAmount.Text.Trim() != string.Empty && Convert.ToDecimal(txtPaymentAmount.Text.Trim()) < Convert.ToDecimal(lblMinAmountForConfirmReservation.Text.Trim()))
                    ////{
                    ////    MessageBox.Show("Paid amout is less than Min. Amount for Confirm Reservation, you can't give confirm reservation.");
                    ////    ddlBookingStatus.SelectedIndex = 0;
                    ////    return;
                    ////}

                    decimal dcmlPaymentAmount = Convert.ToDecimal("0.00");
                    decimal dcmlPaidAmount = Convert.ToDecimal("0.00");
                    decimal dcmlMinAmountForRes = Convert.ToDecimal("0.00");

                    if (txtPaymentAmount.Text.Trim() != string.Empty)
                        dcmlPaymentAmount = Convert.ToDecimal(txtPaymentAmount.Text.Trim());

                    if (lblDispalyPaidAmount.Text.Trim() != "")
                        dcmlPaidAmount = Convert.ToDecimal(lblDispalyPaidAmount.Text.Trim());

                    if (lblMinAmountForConfirmReservation.Text.Trim() != "")
                        dcmlMinAmountForRes = Convert.ToDecimal(lblMinAmountForConfirmReservation.Text.Trim());

                    if (dcmlMinAmountForRes > (dcmlPaymentAmount + dcmlPaidAmount))
                    {
                        MessageBox.Show("Paid amout is less than Min. Amount for Confirm Reservation, you can't give confirm reservation.");
                        ddlBookingStatus.SelectedIndex = 0;
                        return;
                    }

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime? checkInDate = null;
                    DateTime? checkOutDate = null;
                    Guid? roomTypeID = null;

                    DateTime dtToSetCheckInDate = new DateTime();
                    DateTime dtToSetCheckOutDate = new DateTime();

                    if (ddlRoomType.SelectedIndex != 0)
                        roomTypeID = new Guid(ddlRoomType.SelectedValue);

                    if (txtCheckInDate.Text.Trim() != "")
                        dtToSetCheckInDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    if (txtCheckOutDate.Text.Trim() != "")
                        dtToSetCheckOutDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

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

                    DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, roomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);

                    if (dsIsRoomAvbl.Tables.Count > 0 && dsIsRoomAvbl.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsIsRoomAvbl.Tables[0].Rows.Count; i++)
                        {
                            ddlRoomNumber.Items.Insert(i + 1, new ListItem(clsCommon.GetFormatedRoomNumber(Convert.ToString(dsIsRoomAvbl.Tables[0].Rows[i]["RoomNo"])), Convert.ToString(dsIsRoomAvbl.Tables[0].Rows[i]["RoomID"])));
                        }
                    }

                    if (hdnRoomID.Value != "")
                        ddlRoomNumber.SelectedIndex = ddlRoomNumber.Items.FindByValue(Convert.ToString(hdnRoomID.Value)) != null ? ddlRoomNumber.Items.IndexOf(ddlRoomNumber.Items.FindByValue(Convert.ToString(hdnRoomID.Value))) : 0;

                    trAssignRoom.Visible = true;
                    ddlRoomNumber.Enabled = ddlBookingStatus.Enabled;
                    rfvRoomNumberForAmend.Enabled = ddlBookingStatus.Enabled;
                    tdAssignRoomNo.Attributes.Add("class", "isrequire");
                }
                else
                {
                    ddlRoomNumber.SelectedIndex = 0;
                    trAssignRoom.Visible = false;
                    rfvRoomNumberForAmend.Enabled = false;
                    tdAssignRoomNo.Attributes.Remove("class");
                }

                //// Reservation's Current status is Confirmed    New selected status is not confirmed      if room is assigned                      new selected stauts is not zero.
                if (this.ReservationsCurrentStatusTermID == 28 && ddlBookingStatus.SelectedValue != "28" && lblDisplayRoomNo.Text != string.Empty && ddlBookingStatus.SelectedIndex != 0)
                {
                    MessageBox.Show("If you set Reservation's status other than confirmed, assigned room will be deallocated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlBookingReference_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

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
                    }
                }
                else
                {
                    ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }




                //ddlCompany.Items.Clear();
                //if (ddlBookingReference.SelectedIndex != 0)
                //{
                //    if (ddlBookingReference.SelectedValue.ToUpper() == "COMPANY")
                //    {

                //        //Bind Companies
                //        Corporate objToGetList = new Corporate();

                //        objToGetList.IsDirectBill = true;
                //        objToGetList.IsActive = true;
                //        objToGetList.CompanyID = clsSession.CompanyID;
                //        objToGetList.PropertyID = clsSession.PropertyID;
                //        objToGetList.IsDirectBill = true;
                //        List<Corporate> lstCorporates = CorporateBLL.GetAllSearchData(objToGetList);

                //        if (lstCorporates.Count != 0)
                //        {
                //            ddlCompany.DataSource = lstCorporates;
                //            ddlCompany.DataTextField = "CompanyName";
                //            ddlCompany.DataValueField = "CorporateID";
                //            ddlCompany.DataBind();
                //            ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                //        }
                //        else
                //            ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                //    }
                //    else if (ddlBookingReference.SelectedValue.ToUpper() == "AGENT")
                //    {
                //        ////Bind Agent
                //        Corporate objToGetList = new Corporate();

                //        objToGetList.IsActive = true;
                //        objToGetList.CompanyID = clsSession.CompanyID;
                //        objToGetList.PropertyID = clsSession.PropertyID;
                //        objToGetList.IsDirectBill = false;
                //        List<Corporate> lstCorporates = CorporateBLL.GetAllSearchData(objToGetList);

                //        if (lstCorporates.Count != 0)
                //        {
                //            ddlCompany.DataSource = lstCorporates;
                //            ddlCompany.DataTextField = "CompanyName";
                //            ddlCompany.DataValueField = "CorporateID";
                //            ddlCompany.DataBind();
                //            ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                //        }
                //        else
                //            ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                //    }
                //}
                //else
                //{
                //    ddlCompany.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlRoomType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlCompany_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //// Update RateCard ddl
            BindAvailableRateCards();
        }

        protected void ddlRateCard_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlGuestType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Grid Event

        protected void gvSearchGuestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((Label)e.Row.FindControl("lblMobileNo")).Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"))));
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
            try
            {
                if (e.CommandName.ToUpper().Equals("GETGUESTINFO"))
                {
                    DataSet dsGeustInfo = GuestBLL.GetGuestInfoByGuestID(new Guid(e.CommandArgument.ToString()));
                    if (dsGeustInfo != null && dsGeustInfo.Tables.Count > 0)
                    {
                        DataRow drGuest = dsGeustInfo.Tables[0].Rows[0];

                        this.ExistingGuestID = new Guid(Convert.ToString(drGuest["GuestID"]));
                        this.ExistingGuestAddressID = new Guid(Convert.ToString(drGuest["AddressID"]));
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}