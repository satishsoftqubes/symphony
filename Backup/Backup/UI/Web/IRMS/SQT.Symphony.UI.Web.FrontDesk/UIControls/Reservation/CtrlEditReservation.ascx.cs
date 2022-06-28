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
    public partial class CtrlEditReservation : System.Web.UI.UserControl
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
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "EDITRESERVATION")
                {
                    this.ReservationID = clsSession.ToEditItemID;
                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                }
                LoadDefaultValue();
            }
        }

        #endregion

        #region Control Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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


                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                List<ProjectTerm> lstGenders = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GENDER");
                //// Object of Reservation Start
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objResToUpdate = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objOldResData = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();
                objResToUpdate = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                objOldResData = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                
                //if (ddlSourceOfBusiness.SelectedIndex != 0)
                //    objResToUpdate.SourceOfBusiness_TermID = new Guid(ddlSourceOfBusiness.SelectedValue.ToString());
                //else
                //    objResToUpdate.SourceOfBusiness_TermID = null;

                //objResToUpdate.IsToPickup = (rdbIsPicup.SelectedValue.ToString().ToUpper() == "YES");

                //if (txtSpecificInstruction.Text.Trim() != string.Empty)
                //    objResToUpdate.SpecificNote = txtSpecificInstruction.Text.Trim();
                //else
                //    objResToUpdate.SpecificNote = null;

                objResToUpdate.BookedBy = clsCommon.GetUpperCaseText(txtBookedBy.Text.Trim() != string.Empty ? txtBookedBy.Text.Trim() : null);

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
                objGuestToUpdate.TotalNight = Convert.ToInt32(lblDisplayNoOfDays.Text.Trim());
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
                ReservationBLL.EditReservation(objResToUpdate, objGuestToUpdate, GuestAddress);

                ReservationHistory objResHistory = new ReservationHistory();
                objResHistory.ReservationID = objResToUpdate.ReservationID;
                objResHistory.Operation = "EDIT";
                objResHistory.OperationDate = DateTime.Now;
                objResHistory.OperationBy = clsSession.UserID;
                objResHistory.OldStatus_TermID = objOldResData.RestStatus_TermID;
                ////objResHistory.NewStatus_TermID = Convert.ToInt32(ddlBookingStatus.SelectedValue);
                objResHistory.CompanyID = clsSession.CompanyID;
                objResHistory.PropertyID = clsSession.PropertyID;
                objResHistory.OldRecord = objOldResData.ToString();
                objResHistory.OperationRequestBy = clsCommon.GetUpperCaseText(Convert.ToString(this.OperationRequestBy));
                objResHistory.OperationRequestMode_TermID = this.OperationRequestModeID;

                ReservationHistoryBLL.Save(objResHistory);

                mpeSuccessMessage.Show();
                //ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/RoomReservationList.aspx");
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

        protected void lnkCheckRateCardAvailability_OnClick(object sender, EventArgs e)
        {
            BindAvailableRateCards();
        }

        protected void btnSuccessMsgOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/RoomReservationList.aspx");
        }

        protected void iBtnCloseSuccessMessage_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/RoomReservationList.aspx");
        }

        #endregion

        #region Private Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "EditReservation.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
            btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
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
            dr3["NameColumn"] = "Edit Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void LoadReservationData()
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

                    BindAvailableRateCards();

                    ddlGuestType.SelectedIndex = ddlGuestType.Items.FindByValue(Convert.ToString(drData["Guest_TypeID"])) != null ? ddlGuestType.Items.IndexOf(ddlGuestType.Items.FindByValue(Convert.ToString(drData["Guest_TypeID"]))) : 0;
                    ddlSourceOfBusiness.SelectedIndex = ddlSourceOfBusiness.Items.FindByValue(Convert.ToString(drData["SourceOfBusiness_TermID"])) != null ? ddlSourceOfBusiness.Items.IndexOf(ddlSourceOfBusiness.Items.FindByValue(Convert.ToString(drData["SourceOfBusiness_TermID"]))) : 0;
                    ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(drData["Title"])) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(drData["Title"]))) : 0;
                    ddlBillingInstruction.SelectedIndex = ddlBillingInstruction.Items.FindByValue(Convert.ToString(drData["BillingInstruction_TermID"])) != null ? ddlBillingInstruction.Items.IndexOf(ddlBillingInstruction.Items.FindByValue(Convert.ToString(drData["BillingInstruction_TermID"]))) : 0;
                    ////ddlModeOfPayment.SelectedIndex = ddlModeOfPayment.Items.FindByValue(Convert.ToString(drData["MOP_TermID"])) != null ? ddlModeOfPayment.Items.IndexOf(ddlModeOfPayment.Items.FindByValue(Convert.ToString(drData["MOP_TermID"]))) : 0;
                    ////ddlBookingStatus.SelectedIndex = ddlBookingStatus.Items.FindByValue(Convert.ToString(drData["RestStatus_TermID"])) != null ? ddlBookingStatus.Items.IndexOf(ddlBookingStatus.Items.FindByValue(Convert.ToString(drData["RestStatus_TermID"]))) : 0;

                    if (Convert.ToString(drData["RestStatus_TermID"]) == "28")
                        lblDisplayRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(Convert.ToString(drData["RoomNo"])));
                    else
                        lblDisplayRoomNo.Text = "";

                    ddlRateCard.SelectedIndex = ddlRateCard.Items.FindByValue(Convert.ToString(drData["RateID"])) != null ? ddlRateCard.Items.IndexOf(ddlRateCard.Items.FindByValue(Convert.ToString(drData["RateID"]))) : 0;

                    if (Convert.ToString(drData["BookingReference"]).ToUpper() == "COMPANY")
                        ddlBookingReference.SelectedIndex = 1;
                    else if (Convert.ToString(drData["BookingReference"]).ToUpper() == "AGENT")
                        ddlBookingReference.SelectedIndex = 2;
                    else if (Convert.ToString(drData["BookingReference"]).ToUpper() == "NOTHING")
                        ddlBookingReference.SelectedIndex = 0;

                    ddlBookingReference_OnSelectedIndexChanged(null, null);
                    ddlRateCard_OnSelectedIndexChanged(null, null);

                    ddlCompany.SelectedIndex = ddlCompany.Items.FindByValue(Convert.ToString(drData["AgentID"])) != null ? ddlCompany.Items.IndexOf(ddlCompany.Items.FindByValue(Convert.ToString(drData["AgentID"]))) : 0;

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
                                rdbIsPicup.Items[i].Selected = true;
                            else if (rdbIsPicup.Items[i].Text.ToUpper() == "NO" && Convert.ToBoolean(drData["IsToPickUp"]) == false)
                                rdbIsPicup.Items[i].Selected = true;
                        }
                    }

                    this.IsRateCalculated = false;

                    //string strGetAmountQuery = "select IsNull(Sum(Amount),0.000000)'Amount' from tra_BookKeeping where ReservationID ='" + Convert.ToString(this.ReservationID) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' ";
                    //DataSet dsGetAmount = RoomBLL.GetUnitNo(strGetAmountQuery);

                    //if (dsGetAmount.Tables.Count > 0 && dsGetAmount.Tables[0].Rows.Count > 0)
                    //{
                    //    decimal dcmlPaidAmount = Convert.ToDecimal(Convert.ToString(dsGetAmount.Tables[0].Rows[0]["Amount"]));
                    //    lblDispalyPaidAmount.Text = dcmlPaidAmount.ToString().Substring(0, dcmlPaidAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    //}
                    //else
                    //    lblDispalyPaidAmount.Text = "0.00";

                    this.ReservationsCurrentStatusTermID = Convert.ToInt32(drData["RestStatus_TermID"].ToString());
                    lblDisplayBookingStatus.Text = Convert.ToString(drData["Status"]);

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
                    decimal DueBalanceAmount = Convert.ToDecimal("0.000000");
                    decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                    DataTable dtPaidAmountInfo = null;

                    clsCommon.GetReservationPaymentInfo(this.ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                    string strRoomRent, strTax, strTotalAmount, strDepositAmount, strTotalAmountPayable, strTotalAmountReceived, strDueBalanceAmount = "";

                    strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    TotalAmountPayable = TotalAmount + DepositAmount;
                    strTotalAmountPayable = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    lblDisplayNoOfDays.Text = Convert.ToString(NoofDays);
                    lblDisplayRoomRent.Text = Convert.ToString(strRoomRent);
                    lblDisplayTax.Text = Convert.ToString(strTax);
                    lblDisplayTotalAmount.Text = Convert.ToString(strTotalAmount);
                    lblDisplayDepositAmount.Text = Convert.ToString(strDepositAmount);

                    lblTotalAmountPayable.Text = Convert.ToString(strTotalAmountPayable);

                    strTotalAmountReceived = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    lblDispalyPaidAmount.Text = Convert.ToString(strTotalAmountReceived);

                    DueBalanceAmount = TotalAmountPayable - PaidDeposit;
                    DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else
                {
                    txtAddressLine1.Text = txtAddressLine2.Text = txtAdult.Text = txtBookedBy.Text = txtCheckInDate.Text = txtCheckOutDate.Text = txtChild.Text = txtCityName.Text = txtCountryMobileCode.Text = txtCompanyName.Text = txtCountryName.Text = txtFirstName.Text = txtGuestEmail.Text = txtLastName.Text = txtMobile.Text = txtSpecificInstruction.Text = txtStandardInstruction.Text = txtStateName.Text = txtZipCode.Text =  "";
                    lblDispalyPaidAmount.Text = "0.00";
                    lblDisplayBookingStatus.Text = lblDisplayRoomNo.Text = "";
                }
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
            if (txtCheckInDate.Text.Trim() == string.Empty || txtCheckOutDate.Text.Trim() == string.Empty)
            {
                return;
            }           

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

        private void BindProjectTermData()
        {
            DataSet dsProjectTermData = ReservationBLL.GetReservationProjectTermData(clsSession.PropertyID, clsSession.CompanyID, "GUESTTYPE", "SOURCEOFBUSINESS", "TITLE", "BILLINGINSTRUCTION", "PAYMENTMODE");
            string strSelect = clsCommon.GetUpperCaseText("-Select-");

            ddlRoomType.Items.Clear();
            ddlGuestType.Items.Clear();
            ddlSourceOfBusiness.Items.Clear();
            ddlBillingInstruction.Items.Clear();
            ddlTitle.Items.Clear();

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
            }
            else
            {
                ddlRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                ddlGuestType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                ddlSourceOfBusiness.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                ddlBillingInstruction.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
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

        private string GetCardNo(string strCardNo)
        {
            string strReturn = "";
            if (strCardNo.Length == 16)
            {
                strReturn = "************" + strCardNo.Substring(12, 4);
            }
            return strReturn;
        }

        private void ClearControl()
        {
            txtCheckInDate.Text = txtCheckOutDate.Text = txtAdult.Text = txtChild.Text = txtInfant.Text = txtStandardInstruction.Text = txtSpecificInstruction.Text = "";
            txtFirstName.Text = txtLastName.Text = txtBookedBy.Text = txtCountryMobileCode.Text = txtMobile.Text = txtGuestEmail.Text = txtAddressLine1.Text = txtAddressLine2.Text = txtCityName.Text = txtZipCode.Text = txtStateName.Text = txtCountryName.Text = txtCompanyName.Text = "";
            ddlRoomType.SelectedIndex = ddlBookingReference.SelectedIndex = ddlCompany.SelectedIndex = ddlRateCard.SelectedIndex = ddlGuestType.SelectedIndex = ddlSourceOfBusiness.SelectedIndex = ddlTitle.SelectedIndex = ddlBillingInstruction.SelectedIndex = 0;

            ddlNationality.SelectedIndex = 0;
            //ddlComplementoryRefBy.SelectedIndex = ddlInvestor.SelectedIndex = 0;

            rdbLIsSmoking.SelectedIndex = rdbIsPicup.SelectedIndex = 1;

            hdnIsBlackList.Value = lblDisplayNoOfDays.Text = lblDisplayRoomRent.Text = lblDisplayTax.Text = lblDisplayTotalAmount.Text = lblDisplayDepositAmount.Text = lblTotalAmountPayable.Text = lblMinAmountForConfirmReservation.Text = "";

            this.IsRateCalculated = false;
            this.DaysOfRateCard = 0;
            this.ExistingGuestID = this.ExistingGuestAddressID = this.ReservationTypeTermID = Guid.Empty;
            this.StandardCheckInTime = this.StandardCheckOutTime = string.Empty;

            lblDisplayBookingStatus.Text = lblDisplayRoomNo.Text = "";
            lblDispalyPaidAmount.Text = "0.00";
        }

        #endregion

        #region Control Event - Dropdown event

        protected void ddlInvestor_OnSelectedIndexChanged(object sender, EventArgs e)
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

        protected void ddlComplementoryRefBy_OnSelectedIndexChanged(object sender, EventArgs e)
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

        protected void ddlBookingReference_OnSelectedIndexChanged(object sender, EventArgs e)
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
    }
}