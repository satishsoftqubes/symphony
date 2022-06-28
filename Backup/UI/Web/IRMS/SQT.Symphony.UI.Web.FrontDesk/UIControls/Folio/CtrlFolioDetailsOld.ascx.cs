using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlFolioDetailsOld : System.Web.UI.UserControl
    {
        #region Variable

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

        public Guid SplitBillingFolioID
        {
            get
            {
                return ViewState["SplitBillingFolioID"] != null ? new Guid(Convert.ToString(ViewState["SplitBillingFolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["SplitBillingFolioID"] = value;
            }
        }

        public Guid SplitBillingGuestID
        {
            get
            {
                return ViewState["SplitBillingGuestID"] != null ? new Guid(Convert.ToString(ViewState["SplitBillingGuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["SplitBillingGuestID"] = value;
            }
        }

        public bool blIsSubFolio
        {
            get
            {
                return ViewState["blIsSubFolio"] != null ? Convert.ToBoolean(ViewState["blIsSubFolio"]) : false;
            }
            set
            {
                ViewState["blIsSubFolio"] = value;
            }
        }

        public string SubFolioStatus
        {
            get
            {
                return ViewState["SubFolioStatus"] != null ? Convert.ToString(ViewState["SubFolioStatus"]) : string.Empty;
            }
            set
            {
                ViewState["SubFolioStatus"] = value;
            }
        }

        public Guid SubFolio_FolioID
        {
            get
            {
                return ViewState["SubFolio_FolioID"] != null ? new Guid(Convert.ToString(ViewState["SubFolio_FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["SubFolio_FolioID"] = value;
            }
        }

        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }
        public bool IsMessage = false;

        decimal dcmlftCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftPayment = Convert.ToDecimal("0.000000");
        decimal dcmlftAccomodationCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftMISCCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftTotalPayment = Convert.ToDecimal("0.000000");
        decimal dcmlftTotalDueAmount = Convert.ToDecimal("0.000000");
        decimal dcmlBalanceAmount = Convert.ToDecimal("0.000000");
        public bool IsDepositMessage = false;

        public int RowIndex
        {
            get
            {
                return ViewState["RowIndex"] != null ? Convert.ToInt32(ViewState["RowIndex"]) : 0;
            }
            set
            {
                ViewState["RowIndex"] = value;
            }
        }

        public string strIsValidate
        {
            get
            {
                return ViewState["strIsValidate"] != null ? Convert.ToString(ViewState["strIsValidate"]) : string.Empty;
            }
            set
            {
                ViewState["strIsValidate"] = value;
            }
        }

        public string strOpenModalDialog
        {
            get
            {
                return ViewState["strOpenModalDialog"] != null ? Convert.ToString(ViewState["strOpenModalDialog"]) : string.Empty;
            }
            set
            {
                ViewState["strOpenModalDialog"] = value;
            }
        }

        public bool IsPreview = false;
        public bool IsSplitBilling = false;
        public bool IsMessageForSubFolioCheckOut = false;

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ////if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "FOLIODETAILS")
                ////{
                ////    this.ReservationID = clsSession.ToEditItemID;
                ////    this.FolioID = new Guid(Convert.ToString(Session["GuestFolioID"]));

                ////    //clsSession.ToEditItemID = Guid.Empty;
                ////    //clsSession.ToEditItemType = string.Empty;
                ////    //Session.Remove("GuestFolioID");

                ////    mvFolio.ActiveViewIndex = 0;
                ////    // BindFolioDetail();
                ////    BindBreadCrumb();
                ////    BindGrid();
                ////}



                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "FOLIODETAILS")
                {
                    LoadDefaultValue();
                }
                //this.ReservationID = new Guid("5A4F7464-138D-4812-A152-6B0795063D90");
                //this.FolioID = new Guid("AFCF79F6-0133-4EE5-85F5-1AC3503F57CB");
            }
        }

        #endregion

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
            {
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "FolioDetailsOld.aspx");
                ChekAuthorizationForVoidRole();
            } 
            else
            {
                this.UserRights = "1111";
            }
               
            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void ChekAuthorizationForVoidRole()
        {
            // Check For Authorization of user to void transaction or Not
            if (clsSession.UserID != Guid.Empty && clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
            {
                DataSet dsUserRole = RoleBLL.GetUserRole(clsSession.UserID, clsSession.CompanyID, clsSession.PropertyID, "Void");
                if (dsUserRole.Tables[0].Rows.Count != 0)
                {
                    gvFolioDetails.Columns[7].Visible = true;
                }
                else
                {
                    gvFolioDetails.Columns[7].Visible = false;
                }
            }
        }
        private void LoadDefaultValue()
        {
            try
            {
                calPostChargeFrom.Format = calPostChargeTo.Format = clsSession.DateFormat;
                this.ReservationID = clsSession.ToEditItemID;
                this.FolioID = new Guid(Convert.ToString(Session["FolioListFolioID"]));
                hdn_MasterFolioID.Value = Convert.ToString(Session["FolioListFolioID"]);

                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = string.Empty;
                Session.Remove("FolioListFolioID");

                mvFolio.ActiveViewIndex = 0; 

                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    ProjectTerm objProjectTerm = new ProjectTerm();
                    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                    if (objProjectTerm != null)
                    {
                        calStartDate.Format = calEndDate.Format = objProjectTerm.Term;
                        this.DateFormat = objProjectTerm.Term;
                    }
                    else
                    {
                        calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                        this.DateFormat = "dd/MM/yyyy";
                    }
                }
                else
                {
                    calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                    this.DateFormat = "dd/MM/yyyy";
                }
                txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                chkEndDate.Checked = false;
                chkEndDate_CheckedChanged(null, null);
                chkStartDate.Checked = false;
                chkStartDate_CheckedChanged(null, null);                
                rdoDetail.Checked = true;
                rdoDetail_CheckedChanged(null, null);
                BindFolioDetail();
                BindAllFolioChargesGrid();
                BindAllFolioDepositGrid();
                BindBreadCrumb();
                BindSubFolio();

                Session.Remove("FolioListFolioBalance");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindFolioDetail()
        {
            try
            {
                //DataSet dsFolioList = FolioBLL.GetAllFolios(this.FolioID, null, null, null, null, clsSession.CompanyID, clsSession.PropertyID);

                //if (dsFolioList.Tables[0].Rows.Count != 0)
                //{
                //    litDspGuestName.Text = dsFolioList.Tables[0].Rows[0]["GuestFullName"].ToString();
                //    litDspReservationNo.Text = dsFolioList.Tables[0].Rows[0]["ReservationNo"].ToString();
                //    //litDspCheckin.Text = dsFolioList.Tables[0].Rows[0]["CheckInDate"].ToString();
                //    litDspRoomNo.Text = dsFolioList.Tables[0].Rows[0]["RoomNo"].ToString();
                //    //litDspCheckoutDate.Text = dsFolioList.Tables[0].Rows[0]["CheckOutDate"].ToString();

                //    if (dsFolioList.Tables[0].Rows[0]["CheckOutDate"].ToString() != "")
                //    {
                //        DateTime CheckoutDate = Convert.ToDateTime(Convert.ToString(dsFolioList.Tables[0].Rows[0]["CheckOutDate"]));
                //        litDspCheckoutDate.Text = Convert.ToString(CheckoutDate.ToString(clsSession.DateFormat));
                //        calPostChargeFrom.EndDate = CheckoutDate;
                //        calPostChargeTo.EndDate = CheckoutDate;
                //    }

                //    if (dsFolioList.Tables[0].Rows[0]["CheckInDate"].ToString() != "")
                //    {
                //        DateTime CheckinDate = Convert.ToDateTime(Convert.ToString(dsFolioList.Tables[0].Rows[0]["CheckInDate"]));
                //        litDspCheckin.Text = Convert.ToString(CheckinDate.ToString(clsSession.DateFormat));
                //        calPostChargeFrom.StartDate = CheckinDate;
                //        calPostChargeTo.StartDate = CheckinDate;
                //    }
                //}

                DataSet dsRservationData = ReservationBLL.GetResrvationViewData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);
                if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsRservationData.Tables[0].Rows[0];

                    litDspGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    litDisplayFolioNo.Text = litDspReservationNo.Text = Convert.ToString(dr["FolioNo"]);
                    litDspRoomNo.Text = Convert.ToString(dr["RoomNo"]);

                    DateTime CheckinDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    litDisplayArrivalDate.Text = litDspCheckin.Text = Convert.ToString(CheckinDate.ToString(clsSession.DateFormat));

                    DateTime CheckoutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));
                    litDisplayDepatureDate.Text = litDspCheckoutDate.Text = Convert.ToString(CheckoutDate.ToString(clsSession.DateFormat));

                    calPostChargeFrom.EndDate = CheckoutDate;
                    calPostChargeTo.EndDate = CheckoutDate;
                    calPostChargeTo.SelectedDate = CheckoutDate;

                    calPostChargeFrom.StartDate = CheckinDate;
                    calPostChargeTo.StartDate = CheckinDate;
                    calPostChargeFrom.SelectedDate = CheckinDate;

                    litDisplayUnitNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));
                    lblFolioDetailsDisplayGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    lblFolioDetailsDisplayMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    lblFolioDetailsDisplayEmail.Text = Convert.ToString(dr["Email"]);
                    litDisplayRoomType.Text = Convert.ToString(dr["RoomTypeName"]);

                    //litDisplayAdult.Text = Convert.ToString(dr["Adults"]);

                    //if (Convert.ToString(dr["Children"]) != null && Convert.ToString(dr["Children"]) != "")
                    //    litDisplayChild.Text = Convert.ToString(dr["Children"]);
                    //else
                    //    litDisplayChild.Text = "-";

                    litDisplayRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    litDisplayCreditLimit.Text = Convert.ToString(Session["FolioListFolioBalance"]);

                    this.SplitBillingGuestID = new Guid(Convert.ToString(dr["GuestID"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            txtPostChargeFrom.Text = "";
            txtPostChargeTo.Text = "";
        }

        //private void BindGridForRestaurant()
        //{
        //    DataTable dtTableRestaurant = new DataTable();

        //    DataColumn dc1 = new DataColumn("Transaction");
        //    DataColumn dc2 = new DataColumn("Conference");
        //    DataColumn dc3 = new DataColumn("Account");
        //    DataColumn dc4 = new DataColumn("Description");
        //    DataColumn dc5 = new DataColumn("Charges");
        //    DataColumn dc6 = new DataColumn("Payment");


        //    dtTableRestaurant.Columns.Add(dc1);
        //    dtTableRestaurant.Columns.Add(dc2);
        //    dtTableRestaurant.Columns.Add(dc3);
        //    dtTableRestaurant.Columns.Add(dc4);
        //    dtTableRestaurant.Columns.Add(dc5);
        //    dtTableRestaurant.Columns.Add(dc6);

        //    DataRow dr1 = dtTableRestaurant.NewRow();
        //    dr1["Transaction"] = "140412-143";
        //    dr1["Conference"] = "Church Chill";
        //    dr1["Account"] = "Restaurant - 4007";
        //    dr1["Description"] = "Breakfast";
        //    dr1["Charges"] = "10.00";

        //    dtTableRestaurant.Rows.Add(dr1);

        //    DataRow dr2 = dtTableRestaurant.NewRow();
        //    dr2["Transaction"] = "140412-144";
        //    dr2["Conference"] = "Church Chill";
        //    dr2["Account"] = "Restaurant - 4007";
        //    dr2["Description"] = "Tea";
        //    dr2["Charges"] = "5.00";


        //    dtTableRestaurant.Rows.Add(dr2);

        //    gvRestaurantDetails.DataSource = dtTableRestaurant;
        //    gvRestaurantDetails.DataBind();
        //}


        //private void BindGridForPOS()
        //{
        //    gvPOSDetails.DataSource = null;
        //    gvPOSDetails.DataBind();
        //}


        //private void BindGridForPhone()
        //{
        //    gvPhoneDetails.DataSource = null;
        //    gvPhoneDetails.DataBind();
        //}


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
            dr4["NameColumn"] = "Billing";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Folio Details";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        public void BindAllFolioChargesGrid()
        {
            try
            {
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }
                DataSet dsTransaction = TransactionBLL.GetAllTransaction(this.ReservationID, this.FolioID, startdt,enddt, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransaction != null && dsTransaction.Tables.Count > 0 && dsTransaction.Tables[0].Rows.Count > 0)
                {
                    DataView dvTransaction = new DataView(dsTransaction.Tables[0]);

                    bool isvoid = Convert.ToBoolean(chkShowVoidTransaction.Checked);
                    dvTransaction.RowFilter = "IsVoid = '" + isvoid + "' and IsOverride = 0";


                    if (dvTransaction.Count > 0)
                    {
                        dcmlftCharge = (decimal)dsTransaction.Tables[0].Compute("sum(CR_AMOUNT)", "IsVoid = '" + isvoid + "' and IsOverride = 0");
                        dcmlftPayment = (decimal)dsTransaction.Tables[0].Compute("sum(DB_AMOUNT)", "IsVoid = '" + isvoid + "' and IsOverride = 0");

                        decimal dcAllCharges = Convert.ToDecimal("0.000000");
                        dcAllCharges = dcmlftPayment - dcmlftCharge;
                        lbltabAllCharges.Text = "Folio Balance : " + dcAllCharges.ToString().Substring(0, dcAllCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        hdnAllCharges.Value = lblDisplayAmount.Text = dcAllCharges.ToString().Substring(0, dcAllCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        //dvTransaction.Sort = "EntryDate desc";
                        gvFolioDetails.DataSource = dvTransaction;
                        gvFolioDetails.DataBind();
                    }
                    else
                    {
                        lblDisplayAmount.Text = hdnAllCharges.Value = "0.00";
                        lbltabAllCharges.Text = "Folio Balance : 0.00";
                        gvFolioDetails.DataSource = null;
                        gvFolioDetails.DataBind();
                    }

                    DataView dvRentCharges = new DataView(dsTransaction.Tables[0]);
                    dvRentCharges.RowFilter = "EntryOrigin_TermID = 40 and IsVoid = '" + isvoid + "' and IsOverride = 0";
                    if (dvRentCharges.Count > 0)
                    {
                        dvRentCharges.Sort = "EntryDate desc";

                        ////decimal dcmlftTotalRoomRentAmt = (decimal)dsTransaction.Tables[0].Compute("sum(CR_AMOUNT)", "EntryOrigin_TermID = 40 and IsVoid = '" + isvoid + "' and IsOverride = 0");


                        //error occurs.
                        //string strOpe = "DISCOUNT ACCOMODATION CHARGE";
                        //dcmlDiscAmt = (decimal)dsTransaction.Tables[0].Compute("sum(DB_AMOUNT)", "EntryOrigin_TermID = 40 and IsVoid = '" + isvoid + "' and IsOverride = 0 and GeneralIDType_Term = '" + strOpe + "' ");

                        gvAccommodationList.DataSource = dvRentCharges;
                        gvAccommodationList.DataBind();

                        hdnRentCharges.Value = dcmlftAccomodationCharge.ToString().Substring(0, dcmlftAccomodationCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        littabRentCharge.Text = "Room Rent: " + hdnRentCharges.Value;
                    }
                    else
                    {
                        hdnRentCharges.Value = "0.00";
                        gvAccommodationList.DataSource = null;
                        gvAccommodationList.DataBind();
                        littabRentCharge.Text = "Room Rent: 0.00";
                    }

                    DataView dvMISC = new DataView(dsTransaction.Tables[0]);
                    dvMISC.RowFilter = "EntryOrigin_TermID in (41,44)  and IsVoid = '" + isvoid + "' and IsOverride = 0 and GeneralIDType_Term not in ('DISCOUNT ACCOMODATION CHARGE')";
                    if (dvMISC.Count > 0)
                    {
                        //dcmlftMISCCharge = (decimal)dsTransaction.Tables[0].Compute("sum(CR_AMOUNT)", "EntryOrigin_TermID in (41,44)  and IsVoid = '" + isvoid + "' and IsOverride = 0 and GeneralIDType_Term not in ('DISCOUNT ACCOMODATION CHARGE')");
                        dvMISC.Sort = "EntryDate desc";
                        gvMISCDetails.DataSource = dvMISC;
                        gvMISCDetails.DataBind();

                        hdnMISC.Value = dcmlftMISCCharge.ToString().Substring(0, dcmlftMISCCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        littabMISC.Text = "Other Charge: " + hdnMISC.Value;
                    }
                    else
                    {
                        hdnMISC.Value = "0.00";
                        gvMISCDetails.DataSource = null;
                        gvMISCDetails.DataBind();
                        littabMISC.Text = "Other Charge: 0.00";
                    }

                    DataView dvPayment = new DataView(dsTransaction.Tables[0]);
                    dvPayment.RowFilter = "GeneralIDType_Term like '%PAYMENT%' and IsVoid = '" + isvoid + "' and IsOverride = 0 and IsCharge = 0";
                    if (dvPayment.Count > 0)
                    {
                        dcmlftTotalPayment = (decimal)dsTransaction.Tables[0].Compute("sum(DB_AMOUNT)", "GeneralIDType_Term like '%PAYMENT%' and IsVoid = '" + isvoid + "' and IsOverride = 0 and IsCharge = 0");
                        dvPayment.Sort = "EntryDate desc";
                        gvPaymentDetails.DataSource = dvPayment;
                        gvPaymentDetails.DataBind();
                        hdnPayment.Value = dcmlftTotalPayment.ToString().Substring(0, dcmlftTotalPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        littabPayment.Text = "Credit: " + hdnPayment.Value;
                    }
                    else
                    {
                        hdnPayment.Value = "0.00";
                        gvPaymentDetails.DataSource = null;
                        gvPaymentDetails.DataBind();
                        littabPayment.Text = "Credit: 0.00";
                    }
                }
                else
                {
                    hdnAllCharges.Value = hdnRentCharges.Value = hdnMISC.Value = hdnPayment.Value = lblDisplayAmount.Text = "0.00";
                    lbltabAllCharges.Text = "Folio Balance : 0.00";
                    littabRentCharge.Text = "Room Rent: 0.00";
                    littabMISC.Text = "Other Charge: 0.00";
                    littabPayment.Text = "Credit: 0.00";

                    gvFolioDetails.DataSource = null;
                    gvFolioDetails.DataBind();

                    gvAccommodationList.DataSource = null;
                    gvAccommodationList.DataBind();

                    gvMISCDetails.DataSource = null;
                    gvMISCDetails.DataBind();

                    gvPaymentDetails.DataSource = null;
                    gvPaymentDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindAllFolioDepositGrid()
        {
            try
            {
                DataSet dsTransactionDeposit = TransactionBLL.TransactionGetAllDeposit(this.ReservationID, false, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransactionDeposit != null && dsTransactionDeposit.Tables.Count > 0 && dsTransactionDeposit.Tables[0].Rows.Count > 0)
                {
                    DataView dvDeposit = new DataView(dsTransactionDeposit.Tables[0]);
                    dvDeposit.RowFilter = "[DUE AMOUNT] <> 0";

                    if (dvDeposit.Count > 0)
                    {
                        dcmlftTotalDueAmount = (decimal)dsTransactionDeposit.Tables[0].Compute("sum([DUE AMOUNT])", "[DUE AMOUNT] <> 0");
                        lblTabDeposit.Text = "Deposit : " + dcmlftTotalDueAmount.ToString().Substring(0, dcmlftTotalDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        dvDeposit.Sort = "EntryDate desc";
                        gvDepositDetails.DataSource = dvDeposit;
                        gvDepositDetails.DataBind();
                        hdnDeposit.Value = dcmlftTotalDueAmount.ToString().Substring(0, dcmlftTotalDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                    {
                        lblTabDeposit.Text = "Deposit : 0.00";
                        gvDepositDetails.DataSource = null;
                        gvDepositDetails.DataBind();
                        hdnDeposit.Value = "0.00";
                    }
                }
                else
                {
                    lblTabDeposit.Text = "Deposit : 0.00";
                    gvDepositDetails.DataSource = null;
                    gvDepositDetails.DataBind();
                    hdnDeposit.Value = "0.00";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GetCurrentFolioBalance()
        {
            try
            {
                string strFolioBalanceQuery = "Select SUM(ISNULL(CurrentBalace,0.000000)) 'BALANCE' from res_Folio where res_Folio.ReservationID = '" + Convert.ToString(this.ReservationID) + "' and FolioID = '" + Convert.ToString(this.FolioID) + "' and FolioStatus in ('CHECK_IN','CHECK_OUT_OPEN')";
                DataSet dsData = RoomBLL.GetUnitNo(strFolioBalanceQuery);

                if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    decimal dcmlDispalyBalance = Convert.ToDecimal("0.000000");
                    dcmlDispalyBalance = Convert.ToDecimal(Convert.ToString(dsData.Tables[0].Rows[0]["BALANCE"]));

                    litDisplayCreditLimit.Text = dcmlDispalyBalance.ToString().Substring(0, dcmlDispalyBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else
                    litDisplayCreditLimit.Text = "0.00";

                litDisplayFolioNo.Text = Convert.ToString(ddlDisplaySubFolios.SelectedItem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindSubFolio()
        {
            try
            {
                string strSubFolioQuery = "select FolioNo,FolioID,IsSubFolio from res_Folio  where (FolioID = '" + Convert.ToString(hdn_MasterFolioID.Value) + "' or ParentFolioID = '" + Convert.ToString(hdn_MasterFolioID.Value) + "') and FolioStatus = 'CHECK_IN' and IsActive= 1  order by SeqNo";

                DataSet dsSubFolio = RoomBLL.GetUnitNo(strSubFolioQuery);

                ddlDisplaySubFolios.Items.Clear();
                if (dsSubFolio.Tables.Count > 0 && dsSubFolio.Tables[0].Rows.Count > 0)
                {
                    ddlDisplaySubFolios.DataSource = dsSubFolio;
                    ddlDisplaySubFolios.DataTextField = "FolioNo";
                    ddlDisplaySubFolios.DataValueField = "FolioID";
                    ddlDisplaySubFolios.DataBind();

                    ddlDisplaySubFolios.SelectedIndex = ddlDisplaySubFolios.Items.FindByValue(Convert.ToString(this.FolioID)) != null ? ddlDisplaySubFolios.Items.IndexOf(ddlDisplaySubFolios.Items.FindByValue(Convert.ToString(this.FolioID))) : 0;

                    this.blIsSubFolio = btnSubFolioCheckOut.Visible = false;
                }
                else
                    this.blIsSubFolio = btnSubFolioCheckOut.Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Control Event

        protected void btnQuickPostCallParent_Click(object sender, EventArgs e)
        {
            if (ctrlCommonQuickPost.Mode == "REFRESHFOLIOLIST")
            {
                BindAllFolioChargesGrid();
                GetCurrentFolioBalance();
            }
            else
            {
                ctrlCommonQuickPost.mvOpenQuickPost.ActiveViewIndex = 1;
                ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
            }
        }

        protected void btnDiscountOnTransactionCallParent_Click(object sender, EventArgs e)
        {
            if (ctrlCommonTransactionDiscount.strMode != null && ctrlCommonTransactionDiscount.strMode == "REFRESHFOLIOGIRDFORDISCONTRANS")
            {
                BindAllFolioChargesGrid();
                GetCurrentFolioBalance();
            }
            else
            {
                ctrlCommonTransactionDiscount.mvOpenDiscountOnTransaction.ActiveViewIndex = 1;
                ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
            }
        }

        protected void btnRefundDepositCallParent_Click(object sender, EventArgs e)
        {
            mpeRefundDeposit.Show();
            if (ctrlCommonRefundDeposit.strMode == "0")
                ctrlCommonRefundDeposit.mvOpenRefundDeposit.ActiveViewIndex = 0;
            else
                ctrlCommonRefundDeposit.mvOpenRefundDeposit.ActiveViewIndex = 1;
            //ctrlCommonRefundDeposit.ucMpeAddEditRefundDeposit.Show();
        }

        protected void btnOverrideTransactionCallParent_Click(object sender, EventArgs e)
        {
            if (ctrlCommoFolioOverrideTransaction.strMode != null && Convert.ToString(ctrlCommoFolioOverrideTransaction.strMode) == "REFRESHFOLIOGIRDFOROVERRIDE")
            {
                BindAllFolioChargesGrid();
                GetCurrentFolioBalance();
            }
            else
            {
                ctrlCommoFolioOverrideTransaction.mvOpenOverrideTransaction.ActiveViewIndex = 1;
                ctrlCommoFolioOverrideTransaction.ucMpeAddEditOverrideTransaction.Show();
            }
        }

        protected void lnkOperationAddService_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
            ctrlCommonAddServices.ClearServiceControl();
            //// ctrlCommonAddServices.BindServiceList();
        }

        protected void lnkOperationDiscount_Click(object sender, EventArgs e)
        {
            ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
        }

        protected void lnkOperationPaymentInformation_Click(object sender, EventArgs e)
        {
            ctrlCommonCommonCardInfo.uctxtCardHolderName.Text = ctrlCommonCommonCardInfo.uclitDisplayCardHolderName.Text = "Mr. Prakash Patel";
            ctrlCommonCommonCardInfo.ucMpeAddEditCardInfo.Show();
        }

        protected void lnkOperationMoveUnit_Click(object sender, EventArgs e)
        {
            ctrlCommonMoveUnitSetup.BindMoveUnitGrid();
            ////ctrlCommonMoveUnitSetup.ucMpeAddEditMoveUnit.Show();
            mpeMoveUnit.Show();
        }

        protected void btnMoveUnitCallParent_Click(object sender, EventArgs e)
        {
            string strOpenView = ctrlCommonMoveUnitSetup.strMode;

            if (strOpenView.ToUpper() == "OPENCHANGEROOMHISTORY")
                ctrlCommonMoveUnitSetup.mvOpenMoveUnitHistory.ActiveViewIndex = 1;
            else
                ctrlCommonMoveUnitSetup.mvOpenMoveUnitHistory.ActiveViewIndex = 0;

            ////ctrlCommonMoveUnitSetup.ucMpeAddEditMoveUnit.Show();
            mpeMoveUnit.Show();

        }

        protected void lnkFolioDetailsQuickPost_Click(object sender, EventArgs e)
        {
            ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
        }

        protected void lnkFolioDetailsSubFolio_Click(object sender, EventArgs e)
        {
            mpeOpenSubFolio.Show();
        }

        protected void lnkInvoiceBillingName_Click(object sender, EventArgs e)
        {
            ctrlCommonInvoiceBillingName.ucMpeAddEditInvoiceBillingName.Show();
        }

        protected void lnkOperationAssingPackage_Click(object sender, EventArgs e)
        {

            ctrlFolioAssingPackage.ucCtrlFolioAssingPackage.Show();

        }

        protected void btnSubFolioConfigurationCallParent_Click(object sender, EventArgs e)
        {
            string strOperation = ctrlCommonSubFolioConfiguration.strMode;

            if (strOperation == "OPENPOPUP")
            {
                mpeOpenSubFolio.Show();
                ctrlCommonSubFolioConfiguration.mvOpenSubFolio.ActiveViewIndex = 1;
            }
            else if (strOperation == "SHOWVIEWWITHPOPUP0")
            {
                mpeOpenSubFolio.Show();
                ctrlCommonSubFolioConfiguration.mvOpenSubFolio.ActiveViewIndex = 0;
            }
            else if (strOperation == "CLOSEPOPUP")
            {
                mpeOpenSubFolio.Hide();
            }
        }

        protected void btnCommonCardInfoCallParent_Click(object sender, EventArgs e)
        {
            ctrlCommonCommonCardInfo.ucMpeAddEditCardInfo.Show();
        }

        protected void lnkOperationOverrideTransaction_Click(object sender, EventArgs e)
        {
            ctrlCommoFolioOverrideTransaction.ucMpeAddEditOverrideTransaction.Show();
        }

        protected void lnkOperationHouseKeeping_Click(object sender, EventArgs e)
        {
            ctrlCommonHouseKeeping.ucMpeAddEditHouseKeeping.Show();
        }

        protected void lnkOperationGuestProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Folio/GuestProfile.aspx?FolioDetails=true");
        }

        protected void lnkOperationGuestHistory_Click(object sender, EventArgs e)
        {
            ctrlCommonGuestHistory.uclitGuestHistoryContactNo.Text = "-";
            ctrlCommonGuestHistory.uclitGuestHistoryName.Text = "Mr. Prakash Patel";
            ctrlCommonGuestHistory.BindGrid();
            mpeGuestHistory.Show();

        }

        protected void lnkFolioDetailsConfCharges_Click(object sender, EventArgs e)
        {
            CtrlCommonPostUnitCharges.ucMpeAddEditPostUnitCharges.Show();
        }

        protected void lnkTransfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Folio/TransferTransactionFolio.aspx");
        }

        protected void btnAddServicesCallParent_Click(object sender, EventArgs e)
        {
            ctrlCommonAddServices.ucMpeAddEditAddService.Show();
        }

        protected void lnkPostRoomCharge_OnClick(object sender, EventArgs e)
        {
            BindFolioDetail();
            mvFolio.ActiveViewIndex = 1;
        }

        protected void btnPostRoomChargeCancel_OnClick(object sender, EventArgs e)
        {
            BindAllFolioDepositGrid();
            GetCurrentFolioBalance();
            BindAllFolioChargesGrid();

            mvFolio.ActiveViewIndex = 0;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
        }

        protected void btnPostRoomChargePost_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Satish
                //if (Convert.ToDateTime(txtPostChargeTo.Text) > Convert.ToDateTime(txtPostChargeFrom.Text))
                //{
                //    DataSet dsUnPostedCharges = ReservationBLL.GetAllUnpostedCharges(this.ReservationID, null, false);

                //    if (dsUnPostedCharges.Tables.Count > 0 && dsUnPostedCharges.Tables[0].Rows.Count > 0)
                //    {
                //        DataView dvUnPostedCharges = dsUnPostedCharges.Tables[0].DefaultView;
                //        dvUnPostedCharges.RowFilter = "ServiceDate>='" + Convert.ToDateTime(txtPostChargeFrom.Text) + "' and ServiceDate<='" + Convert.ToDateTime(txtPostChargeTo.Text) + "'";

                //        if (dvUnPostedCharges.Count != 0)
                //        {
                //            for (int i = 0; i < dvUnPostedCharges.Count; i++)
                //            {
                //                Guid? ResBlockDateRateID = null;

                //                if (dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"] != null && Convert.ToString(dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"]) != string.Empty)
                //                    ResBlockDateRateID = new Guid(Convert.ToString(dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"]));

                //                decimal dcmlAmount = Convert.ToDecimal(dvUnPostedCharges.Table.Rows[i]["Amount"]);
                //                DateTime dtPostDate = Convert.ToDateTime(dvUnPostedCharges.Table.Rows[i]["ServiceDate"]);

                //                if (ResBlockDateRateID != null && Convert.ToString(ResBlockDateRateID) != Guid.Empty.ToString())
                //                {
                //                    TransactionBLL.PostRoomCharge(dtPostDate, this.ReservationID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlAmount, clsSession.CompanyID);
                //                }
                //            }
                //            IsMessage = true;
                //            lblCommonMsg.Text = "Room Charge Post successfully.";

                //        }

                //    }

                //}
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime dtStartDate = DateTime.ParseExact(txtPostChargeFrom.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                DateTime dtEndDate = DateTime.ParseExact(txtPostChargeTo.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                //if (Convert.ToDateTime(txtPostUnitChargesEndDate.Text.Trim()) > Convert.ToDateTime(txtPostUnitChargesStartDate.Text.Trim()))
                //{
                DataSet dsUnPostedCharges = ReservationBLL.GetAllUnpostedCharges(this.ReservationID, null, false);

                if (dsUnPostedCharges.Tables.Count > 0 && dsUnPostedCharges.Tables[0].Rows.Count > 0)
                {
                    DataView dvUnPostedCharges = dsUnPostedCharges.Tables[0].DefaultView;
                    dvUnPostedCharges.RowFilter = "ServiceDate>='" + dtStartDate + "' and ServiceDate<='" + dtEndDate + "'";

                    if (dvUnPostedCharges.Count != 0)
                    {
                        for (int i = 0; i < dvUnPostedCharges.Count; i++)
                        {
                            Guid? ResBlockDateRateID = null;

                            if (dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"] != null && Convert.ToString(dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"]) != string.Empty)
                                ResBlockDateRateID = new Guid(Convert.ToString(dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"]));

                            decimal dcmlAmount = Convert.ToDecimal(dvUnPostedCharges.Table.Rows[i]["Amount"]);
                            DateTime dtPostDate = Convert.ToDateTime(dvUnPostedCharges.Table.Rows[i]["ServiceDate"]);

                            if (ResBlockDateRateID != null && Convert.ToString(ResBlockDateRateID) != Guid.Empty.ToString())
                            {
                                TransactionBLL.PostRoomCharge(dtPostDate, this.ReservationID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlAmount, clsSession.CompanyID);
                            }
                        }
                        IsMessage = true;
                        lblCommonMsg.Text = "Room Charge Post successfully.";

                    }
                }
                else
                {
                    mpeDateErrorMsg.Show();
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnFolioTransactionDetailsCallParent_Click(object sender, EventArgs e)
        {
            BindAllFolioChargesGrid();
            BindAllFolioDepositGrid();
        }

        protected void btnVoidTransactionCallParent_Click(object sender, EventArgs e)
        {
            BindAllFolioChargesGrid();
            GetCurrentFolioBalance();
        }

        protected void lnkRefreshFolio_Click(object sender, EventArgs e)
        {
            try
            {
                BindAllFolioChargesGrid();
                BindAllFolioDepositGrid();
                BindSubFolio();
                GetCurrentFolioBalance();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Grid RowCommand Event

        protected void gvFolioDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RowIndex = 0;
                this.strIsValidate = this.strOpenModalDialog = string.Empty;

                if (e.CommandName.ToUpper().Equals("QUICKPOST"))
                {
                    ctrlCommonQuickPost.ReservationID = this.ReservationID;
                    ctrlCommonQuickPost.FolioID = this.FolioID;
                    ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
                }
                else if (e.CommandName.Equals("CHANGEDESCRIPTION"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvFolioDetailsBookNo = (Label)row.FindControl("lblGvFolioDetailsBookNo");
                    //Label lblGvRoomNo = (Label)row.FindControl("lblGvRoomNo");
                    Label lblGvFolioDetailsDescription = (Label)row.FindControl("lblGvFolioDetailsDescription");


                    ctrlCommonFolioTransactionDetails.ucMpeAddEditTransactionDetails.Show();

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailReservationNo.Text = Convert.ToString(gvFolioDetails.DataKeys[row.RowIndex]["ReservationNo"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailName.Text = Convert.ToString(gvFolioDetails.DataKeys[row.RowIndex]["GuestName"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailFolioNo.Text = Convert.ToString(gvFolioDetails.DataKeys[row.RowIndex]["FolioNo"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionNo.Text = Convert.ToString(lblGvFolioDetailsBookNo.Text.Trim());

                    bool blIsVoid = Convert.ToBoolean(gvFolioDetails.DataKeys[row.RowIndex]["IsVoid"]);
                    if (blIsVoid)
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "YES";
                    else
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "NO";

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDescription.Text = Convert.ToString(lblGvFolioDetailsDescription.Text.Trim());

                    decimal dcmlAmount = Convert.ToDecimal(gvFolioDetails.DataKeys[row.RowIndex]["DisplayAmount"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    DateTime dtEntryDate = Convert.ToDateTime(gvFolioDetails.DataKeys[row.RowIndex]["EntryDate"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAuditDate.Text = Convert.ToString(dtEntryDate.ToString(clsSession.DateFormat));

                    ctrlCommonFolioTransactionDetails.BookID = new Guid(Convert.ToString(e.CommandArgument));
                    ctrlCommonFolioTransactionDetails.uctxtChangeDescription.Text = "";
                    ctrlCommonFolioTransactionDetails.ucchkChangeDescription.Checked = false;

                }
                else if (e.CommandName.Equals("DISCOUNT"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "FOLIODETAILS_DISCOUNT";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");
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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    ////Label lblGvRoomNo = (Label)gvFolioDetails.Rows[row].FindControl("lblGvRoomNo");

                    LoadFolioDetailsDiscountData();
                }
                else if (e.CommandName.Equals("VOID"))
                {
                    ctrlCommonVoidTransaction.ucMpeAddEditVoidTransaction.Show();
                    ctrlCommonVoidTransaction.uctxtVoidReason.Text = "";
                    ctrlCommonVoidTransaction.BookID = new Guid(Convert.ToString(e.CommandArgument));
                }
                else if (e.CommandName.Equals("OVERRIDE"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "FOLIODETAILS_OVERRIDE";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");
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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    ////Label lblGvRoomNo = (Label)gvFolioDetails.Rows[row].FindControl("lblGvRoomNo");

                    LoadFolioDetailsOverrideData();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvAccommodationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RowIndex = 0;
                this.strIsValidate = this.strOpenModalDialog = string.Empty;

                if (e.CommandName.ToUpper().Equals("QUICKPOST"))
                {
                    ctrlCommonQuickPost.ReservationID = this.ReservationID;
                    ctrlCommonQuickPost.FolioID = this.FolioID;
                    ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
                }
                else if (e.CommandName.Equals("CHANGEDESCRIPTION"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvAccommodationBookNo = (Label)row.FindControl("lblGvAccommodationBookNo");
                    //Label lblGvAccommodationRoomNo = (Label)row.FindControl("lblGvAccommodationRoomNo");
                    Label lblGvAccommodationDescription = (Label)row.FindControl("lblGvAccommodationDescription");


                    ctrlCommonFolioTransactionDetails.ucMpeAddEditTransactionDetails.Show();

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailReservationNo.Text = Convert.ToString(gvAccommodationList.DataKeys[row.RowIndex]["ReservationNo"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailName.Text = Convert.ToString(gvAccommodationList.DataKeys[row.RowIndex]["GuestName"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailFolioNo.Text = Convert.ToString(gvAccommodationList.DataKeys[row.RowIndex]["FolioNo"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionNo.Text = Convert.ToString(lblGvAccommodationBookNo.Text.Trim());

                    bool blIsVoid = Convert.ToBoolean(gvAccommodationList.DataKeys[row.RowIndex]["IsVoid"]);
                    if (blIsVoid)
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "YES";
                    else
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "NO";

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDescription.Text = Convert.ToString(lblGvAccommodationDescription.Text.Trim());

                    decimal dcmlAmount = Convert.ToDecimal(gvAccommodationList.DataKeys[row.RowIndex]["DisplayAmount"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    DateTime dtEntryDate = Convert.ToDateTime(gvAccommodationList.DataKeys[row.RowIndex]["EntryDate"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAuditDate.Text = Convert.ToString(dtEntryDate.ToString(clsSession.DateFormat));

                    ctrlCommonFolioTransactionDetails.BookID = new Guid(Convert.ToString(e.CommandArgument));
                    ctrlCommonFolioTransactionDetails.uctxtChangeDescription.Text = "";
                    ctrlCommonFolioTransactionDetails.ucchkChangeDescription.Checked = false;

                }
                else if (e.CommandName.Equals("DISCOUNT"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "ROOMRENT_DISCOUNT";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        // Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");

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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;

                    }

                    //Label lblGvAccommodationRoomNo = (Label)row.FindControl("lblGvAccommodationRoomNo");

                    LoadRoomRentDiscountData();

                }
                else if (e.CommandName.Equals("VOID"))
                {
                    ctrlCommonVoidTransaction.ucMpeAddEditVoidTransaction.Show();
                    ctrlCommonVoidTransaction.uctxtVoidReason.Text = "";
                    ctrlCommonVoidTransaction.BookID = new Guid(Convert.ToString(e.CommandArgument));
                }
                else if (e.CommandName.Equals("OVERRIDE"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "ROOMRENT_OVERRIDE";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");
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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;

                    }

                    //Label lblGvAccommodationRoomNo = (Label)row.FindControl("lblGvAccommodationRoomNo");

                    LoadRoomRentOverrideData();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvMISCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RowIndex = 0;
                this.strIsValidate = this.strOpenModalDialog = string.Empty;

                if (e.CommandName.ToUpper().Equals("QUICKPOST"))
                {
                    ctrlCommonQuickPost.ReservationID = this.ReservationID;
                    ctrlCommonQuickPost.FolioID = this.FolioID;
                    ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
                }
                else if (e.CommandName.Equals("CHANGEDESCRIPTION"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvMISCBookNo = (Label)row.FindControl("lblGvMISCBookNo");
                    //Label lblGvMISCRoomNo = (Label)row.FindControl("lblGvMISCRoomNo");
                    Label lblGvMISCDescription = (Label)row.FindControl("lblGvMISCDescription");


                    ctrlCommonFolioTransactionDetails.ucMpeAddEditTransactionDetails.Show();

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailReservationNo.Text = Convert.ToString(gvMISCDetails.DataKeys[row.RowIndex]["ReservationNo"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailName.Text = Convert.ToString(gvMISCDetails.DataKeys[row.RowIndex]["GuestName"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailFolioNo.Text = Convert.ToString(gvMISCDetails.DataKeys[row.RowIndex]["FolioNo"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionNo.Text = Convert.ToString(lblGvMISCBookNo.Text.Trim());

                    bool blIsVoid = Convert.ToBoolean(gvMISCDetails.DataKeys[row.RowIndex]["IsVoid"]);
                    if (blIsVoid)
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "YES";
                    else
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "NO";

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDescription.Text = Convert.ToString(lblGvMISCDescription.Text.Trim());

                    decimal dcmlAmount = Convert.ToDecimal(gvMISCDetails.DataKeys[row.RowIndex]["DisplayAmount"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    DateTime dtEntryDate = Convert.ToDateTime(gvMISCDetails.DataKeys[row.RowIndex]["EntryDate"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAuditDate.Text = Convert.ToString(dtEntryDate.ToString(clsSession.DateFormat));

                    ctrlCommonFolioTransactionDetails.BookID = new Guid(Convert.ToString(e.CommandArgument));
                    ctrlCommonFolioTransactionDetails.uctxtChangeDescription.Text = "";
                    ctrlCommonFolioTransactionDetails.ucchkChangeDescription.Checked = false;

                }
                else if (e.CommandName.Equals("DISCOUNT"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "MISC_DISCOUNT";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");
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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    //Label lblGvMISCRoomNo = (Label)row.FindControl("lblGvMISCRoomNo");

                    LoadMISCDiscountData();
                }
                else if (e.CommandName.Equals("VOID"))
                {
                    ctrlCommonVoidTransaction.ucMpeAddEditVoidTransaction.Show();
                    ctrlCommonVoidTransaction.uctxtVoidReason.Text = "";
                    ctrlCommonVoidTransaction.BookID = new Guid(Convert.ToString(e.CommandArgument));
                }
                else if (e.CommandName.Equals("OVERRIDE"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "MISC_OVERRIDE";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");
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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }


                    //Label lblGvMISCRoomNo = (Label)row.FindControl("lblGvMISCRoomNo");

                    LoadMISCOverrideData();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDepositDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RowIndex = 0;
                this.strIsValidate = this.strOpenModalDialog = string.Empty;
                hdnConfirmDeleteFolioDetails.Value = "";

                if (e.CommandName.ToUpper().Equals("REFUND"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "REFUND";
                    lblConfirmDeleteMsg.Text = "Sure you want to Refund Balance?";
                    hdnConfirmDeleteFolioDetails.Value = "REFUNDBALANCE";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");

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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    mpeConfirmDeleteFolioDetails.Show();
                    ////mpeRefundDeposit.Show();
                    //ctrlCommonRefundDeposit.ucMpeAddEditRefundDeposit.Show();
                }
                else if (e.CommandName.Equals("TRANSFER"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "TRANSFER";
                    lblConfirmDeleteMsg.Text = "Sure you want to Transfer Balance?";
                    hdnConfirmDeleteFolioDetails.Value = "TRANSFERBALANCE";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");

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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    mpeConfirmDeleteFolioDetails.Show();

                    ////mpeTransferDeposit.Show();
                }
                else if (e.CommandName.Equals("CHANGEDESCRIPTION"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvFolioDetailsBookNo = (Label)row.FindControl("lblGvFolioDetailsBookNo");
                    //Label lblGvRoomNo = (Label)row.FindControl("lblGvRoomNo");
                    Label lblGvFolioDetailsDescription = (Label)row.FindControl("lblGvFolioDetailsDescription");


                    ctrlCommonFolioTransactionDetails.ucMpeAddEditTransactionDetails.Show();

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailReservationNo.Text = Convert.ToString(gvDepositDetails.DataKeys[row.RowIndex]["ReservationNo"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailName.Text = Convert.ToString(lblFolioDetailsDisplayGuestName.Text.Trim());
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailFolioNo.Text = Convert.ToString(litDisplayFolioNo.Text.Trim());
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDetailUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionNo.Text = Convert.ToString(lblGvFolioDetailsBookNo.Text.Trim());

                    bool blIsVoid = Convert.ToBoolean(gvDepositDetails.DataKeys[row.RowIndex]["IsVoid"]);
                    if (blIsVoid)
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "YES";
                    else
                        ctrlCommonFolioTransactionDetails.uclitDisplayTransactionVoid.Text = "NO";

                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionDescription.Text = Convert.ToString(lblGvFolioDetailsDescription.Text.Trim());

                    decimal dcmlAmount = Convert.ToDecimal(gvDepositDetails.DataKeys[row.RowIndex]["DisplayAmount"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    DateTime dtEntryDate = Convert.ToDateTime(gvDepositDetails.DataKeys[row.RowIndex]["EntryDate"]);
                    ctrlCommonFolioTransactionDetails.uclitDisplayTransactionAuditDate.Text = Convert.ToString(dtEntryDate.ToString(clsSession.DateFormat));

                    ctrlCommonFolioTransactionDetails.BookID = new Guid(Convert.ToString(e.CommandArgument));
                    ctrlCommonFolioTransactionDetails.uctxtChangeDescription.Text = "";
                    ctrlCommonFolioTransactionDetails.ucchkChangeDescription.Checked = false;

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRestaurantDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("QUICKPOST"))
                {
                    ctrlCommonQuickPost.ReservationID = this.ReservationID;
                    ctrlCommonQuickPost.FolioID = this.FolioID;
                    ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
                }
                else if (e.CommandName.Equals("DETAILS"))
                {
                    ctrlCommonFolioTransactionDetails.ucMpeAddEditTransactionDetails.Show();
                }
                else if (e.CommandName.Equals("DISCOUNT"))
                {
                    ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPOSDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("QUICKPOST"))
                {
                    ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
                }
                else if (e.CommandName.Equals("DETAILS"))
                {
                    ctrlCommonFolioTransactionDetails.ucMpeAddEditTransactionDetails.Show();
                }
                else if (e.CommandName.Equals("DISCOUNT"))
                {
                    ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPhoneDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("QUICKPOST"))
                {
                    ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
                }
                else if (e.CommandName.Equals("DETAILS"))
                {
                    ctrlCommonFolioTransactionDetails.ucMpeAddEditTransactionDetails.Show();
                }
                else if (e.CommandName.Equals("DISCOUNT"))
                {
                    ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid RowCommand Event

        #region Grid RowDatabound Event

        protected void gvFolioDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvCharges = (Label)e.Row.FindControl("lblGvCharges");
                    decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CR_AMOUNT"));
                    if (dcmlCharges > 0)
                    {
                        dcmlBalanceAmount = dcmlBalanceAmount - dcmlCharges;
                    }
                    lblGvCharges.Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvPayment = (Label)e.Row.FindControl("lblGvPayment");
                    decimal dcmlPayment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));
                    if (dcmlPayment > 0)
                    {
                        dcmlBalanceAmount = dcmlBalanceAmount + dcmlPayment;
                    }
                    lblGvPayment.Text = dcmlPayment.ToString().Substring(0, dcmlPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //// Set Banalce Amount.
                    ((Label)e.Row.FindControl("lblBalance")).Text = dcmlBalanceAmount.ToString().Substring(0, dcmlBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (DataBinder.Eval(e.Row.DataItem, "BILL_TO_COMPANY") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BILL_TO_COMPANY")) != string.Empty)
                        ((Literal)e.Row.FindControl("ltrLedgerAccount")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Account")) + " ( " + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BILL_TO_COMPANY")) + " )";
                    else
                        ((Literal)e.Row.FindControl("ltrLedgerAccount")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Account"));


                    //// Comment b'cas not to display any action in Folio
                    //if (chkShowVoidTransaction.Checked)
                    //    gvFolioDetails.Columns[7].Visible = false;
                    //else
                    //    gvFolioDetails.Columns[7].Visible = true;

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtTotalCharge = (Label)e.Row.FindControl("lblGvFtTotalCharge");
                    Label lblGvFtTotalPayment = (Label)e.Row.FindControl("lblGvFtTotalPayment");
                    Label lblGvFtFinalBalance = (Label)e.Row.FindControl("lblGvFtFinalBalance");

                    lblGvFtTotalCharge.Text = dcmlftCharge.ToString().Substring(0, dcmlftCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    lblGvFtTotalPayment.Text = dcmlftPayment.ToString().Substring(0, dcmlftPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvAccommodationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Label lblGvAccommodationRoomNo = (Label)e.Row.FindControl("lblGvAccommodationRoomNo");
                    ////string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    ////lblGvAccommodationRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CR_AMOUNT"));

                    string strGeneralIDType_Term = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term"));

                    if (Convert.ToString(strGeneralIDType_Term.Substring(0, 8)) == "DISCOUNT")
                        dcmlCharges = (-1) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));

                    //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")) == "DISCOUNT ACCOMODATION CHARGE")
                    //    dcmlCharges = (-1) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));

                    ((Label)e.Row.FindControl("lblGvAccommodationCharges")).Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //// Don't to display any actions in this page.
                    //if (chkShowVoidTransaction.Checked)
                    //    gvAccommodationList.Columns[5].Visible = false;
                    //else
                    //    gvAccommodationList.Columns[5].Visible = true;

                    dcmlftAccomodationCharge += dcmlCharges;

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblFtTotalAccommodationCharges = (Label)e.Row.FindControl("lblFtTotalAccommodationCharges");
                    lblFtTotalAccommodationCharges.Text = dcmlftAccomodationCharge.ToString().Substring(0, dcmlftAccomodationCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvMISCDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Label lblGvMISCRoomNo = (Label)e.Row.FindControl("lblGvMISCRoomNo");
                    ////string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    ////lblGvMISCRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));


                    decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CR_AMOUNT"));

                    string strGeneralIDType_Term = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term"));

                    if (Convert.ToString(strGeneralIDType_Term.Substring(0, 8)) == "DISCOUNT")
                        dcmlCharges = (-1) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));

                    //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")) == "DISCOUNT ACCOMODATION CHARGE" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")) == "DISCOUNT QUICK POST")
                    //    dcmlCharges = (-1) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));

                    Label lblGvMISCCharges = (Label)e.Row.FindControl("lblGvMISCCharges");
                    lblGvMISCCharges.Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ////Don't display any action in this page.
                    //if (chkShowVoidTransaction.Checked)
                    //    gvMISCDetails.Columns[5].Visible = false;
                    //else
                    //    gvMISCDetails.Columns[5].Visible = true;

                    dcmlftMISCCharge += dcmlCharges;

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblFtTotalMISCCharges = (Label)e.Row.FindControl("lblFtTotalMISCCharges");
                    lblFtTotalMISCCharges.Text = dcmlftMISCCharge.ToString().Substring(0, dcmlftMISCCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPaymentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Label lblGvPaymentRoomNo = (Label)e.Row.FindControl("lblGvPaymentRoomNo");
                    ////string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    ////lblGvPaymentRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    Label lblGvPayment = (Label)e.Row.FindControl("lblGvPayment");
                    decimal dcmlPayment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));
                    lblGvPayment.Text = dcmlPayment.ToString().Substring(0, dcmlPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtTotalPayment = (Label)e.Row.FindControl("lblGvFtTotalPayment");
                    lblGvFtTotalPayment.Text = dcmlftTotalPayment.ToString().Substring(0, dcmlftTotalPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDepositDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Label lblGvDepositRoomNo = (Label)e.Row.FindControl("lblGvDepositRoomNo");
                    ////string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    ////lblGvDepositRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    Label lblGvDepositDueAmount = (Label)e.Row.FindControl("lblGvDepositDueAmount");
                    decimal dcmlDueAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DUE AMOUNT"));
                    lblGvDepositDueAmount.Text = dcmlDueAmount.ToString().Substring(0, dcmlDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //((LinkButton)e.Row.FindControl("lnkDepositDetailsRefund")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "REFUND")));
                    //((LinkButton)e.Row.FindControl("lnkDepositDetailsTransfer")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TRANSFER")));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtTotalDepositDueAmount = (Label)e.Row.FindControl("lblGvFtTotalDepositDueAmount");
                    lblGvFtTotalDepositDueAmount.Text = dcmlftTotalDueAmount.ToString().Substring(0, dcmlftTotalDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid RowDatabound Event

        #region Grid Paging Event

        protected void gvFolioDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFolioDetails.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            lblDisplayAmount.Text = Convert.ToString(hdnAllCharges.Value);
        }

        protected void gvAccommodationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAccommodationList.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            lblDisplayAmount.Text = Convert.ToString(hdnRentCharges.Value);
        }

        protected void gvMISCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMISCDetails.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            lblDisplayAmount.Text = Convert.ToString(hdnMISC.Value);
        }

        protected void gvPaymentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentDetails.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            lblDisplayAmount.Text = Convert.ToString(hdnPayment.Value);
        }

        protected void gvDepositDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepositDetails.PageIndex = e.NewPageIndex;
            BindAllFolioDepositGrid();
            lblDisplayAmount.Text = Convert.ToString(hdnDeposit.Value);
        }

        #endregion Grid Paging Event

        #region Checkbox Event

        protected void chkShowVoidTransaction_CheckedChanged(object sender, EventArgs e)
        {
            BindAllFolioChargesGrid();
        }

        #endregion Checkbox Event

        #region Counter Login Event

        protected void btnSaveCounterData_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strIsValidate == "YES")
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

                    if (this.strOpenModalDialog == "REFUND" || this.strOpenModalDialog == "TRANSFER" || this.strOpenModalDialog == "CHECKOUT_PAYMENT")
                        mpeConfirmDeleteFolioDetails.Show();
                    //if (this.strOpenModalDialog == "REFUND")
                    //    LoadDepositRefundData();
                    //else if (this.strOpenModalDialog == "TRANSFER")
                    //    LoadDepositTransferData();
                    else if (this.strOpenModalDialog == "FOLIODETAILS_DISCOUNT")
                        LoadFolioDetailsDiscountData();
                    else if (this.strOpenModalDialog == "FOLIODETAILS_OVERRIDE")
                        LoadFolioDetailsOverrideData();
                    else if (this.strOpenModalDialog == "ROOMRENT_DISCOUNT")
                        LoadMISCDiscountData();
                    else if (this.strOpenModalDialog == "ROOMRENT_OVERRIDE")
                        LoadRoomRentOverrideData();
                    else if (this.strOpenModalDialog == "MISC_DISCOUNT")
                        LoadMISCDiscountData();
                    else if (this.strOpenModalDialog == "MISC_OVERRIDE")
                        LoadMISCOverrideData();
                    else if (this.strOpenModalDialog == "QUICKPOST")
                        LoadQuickPostData();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Counter Login Event

        #region Gridview's Row Command Load Event

        private void LoadDepositRefundData()
        {
            try
            {
                int row = this.RowIndex;

                int Zone_TermID = 0;
                Guid? PaymentAcctID = null;
                Guid depositBookID = new Guid(gvDepositDetails.DataKeys[row]["BookID"].ToString());

                Label lblGvDepositDueAmount = (Label)gvDepositDetails.Rows[row].FindControl("lblGvDepositDueAmount");
                Label lblGvDepositDetailsBookNo = (Label)gvDepositDetails.Rows[row].FindControl("lblGvDepositDetailsBookNo");

                Guid? roomID = new Guid(gvDepositDetails.DataKeys[row]["RoomID"].ToString());
                Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                Guid? CounterID = clsSession.DefaultCounterID;//// null;

                if (Zone_TermID == 0)
                {
                    DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                    if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                        Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);
                }

                if (PaymentAcctID == null)
                {
                    DataSet dsAccts = ProjectTermBLL.SelectPaymentAcctIDByMOP("CASH", clsSession.CompanyID, clsSession.PropertyID);
                    if (dsAccts != null && dsAccts.Tables[0].Rows.Count > 0)
                        PaymentAcctID = new Guid(dsAccts.Tables[0].Rows[0]["AcctID"].ToString());
                }

                TransactionBLL.TransactionRefundDeposit(depositBookID, Zone_TermID, Convert.ToDecimal(lblGvDepositDueAmount.Text.Trim()), PaymentAcctID, DepositAcctID, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", roomID, "REFUND DEPOSIT", false, null, clsSession.CompanyID);

                string strDescription = "Refund Deposit on Book No.:- " + Convert.ToString(lblGvDepositDetailsBookNo.Text.Trim()) + " and at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + " of " + Convert.ToString(lblGvDepositDueAmount.Text.Trim()) + " Rs.";
                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Refund Deposit", null, null, "tra_BookKeeping", strDescription);

                BindAllFolioDepositGrid();
                GetCurrentFolioBalance();
                BindAllFolioChargesGrid();

                IsDepositMessage = true;
                ltrDepositMessage.Text = "Payment Refund Successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadDepositTransferData()
        {
            try
            {
                int row = this.RowIndex;

                int Zone_TermID = 0;

                Guid depositBookID = new Guid(gvDepositDetails.DataKeys[row]["BookID"].ToString());

                Label lblGvDepositDueAmount = (Label)gvDepositDetails.Rows[row].FindControl("lblGvDepositDueAmount");
                Label lblGvDepositDetailsBookNo = (Label)gvDepositDetails.Rows[row].FindControl("lblGvDepositDetailsBookNo");

                Guid? roomID = new Guid(gvDepositDetails.DataKeys[row]["RoomID"].ToString());
                Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;


                if (Zone_TermID == 0)
                {
                    DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                    if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                        Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);
                }

                TransactionBLL.TransferDeposit(depositBookID, Zone_TermID, Convert.ToDecimal(lblGvDepositDueAmount.Text.Trim()), DepositAcctID, this.ReservationID, this.FolioID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", roomID, "TRANSFER ROOM DEPOSIT", clsSession.CompanyID);
                string strDescription = "Transfer Deposit on Book No.:- " + Convert.ToString(lblGvDepositDetailsBookNo.Text.Trim()) + " and at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + " of " + Convert.ToString(lblGvDepositDueAmount.Text.Trim()) + " Rs.";
                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Transfer Deposit", null, null, "tra_BookKeeping", strDescription);


                BindAllFolioDepositGrid();
                GetCurrentFolioBalance();
                BindAllFolioChargesGrid();

                IsDepositMessage = true;
                ltrDepositMessage.Text = "Payment Transfer Successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadFolioDetailsDiscountData()
        {
            try
            {
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountReservationNo.Text = Convert.ToString(gvFolioDetails.DataKeys[this.RowIndex]["ReservationNo"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountName.Text = Convert.ToString(gvFolioDetails.DataKeys[this.RowIndex]["GuestName"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountFolioNo.Text = Convert.ToString(gvFolioDetails.DataKeys[this.RowIndex]["FolioNo"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                ctrlCommonTransactionDiscount.uclitDisplayDiscountAmount.Text = "0.00";

                ctrlCommonTransactionDiscount.ReservationID = this.ReservationID;
                ctrlCommonTransactionDiscount.FolioID = this.FolioID;
                ctrlCommonTransactionDiscount.BookID = new Guid(gvFolioDetails.DataKeys[this.RowIndex]["BookID"].ToString());

                ctrlCommonTransactionDiscount.BindDiscountTransactionGrid();
                ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadFolioDetailsOverrideData()
        {
            try
            {
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionReservationNo.Text = Convert.ToString(gvFolioDetails.DataKeys[this.RowIndex]["ReservationNo"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionName.Text = Convert.ToString(gvFolioDetails.DataKeys[this.RowIndex]["GuestName"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionFolioNo.Text = Convert.ToString(gvFolioDetails.DataKeys[this.RowIndex]["FolioNo"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionAmount.Text = ctrlCommoFolioOverrideTransaction.uclitDisplayViewOverridedTransactionAmount.Text = "0.00";

                ctrlCommoFolioOverrideTransaction.ReservationID = this.ReservationID;
                ctrlCommoFolioOverrideTransaction.FolioID = this.FolioID;
                ctrlCommoFolioOverrideTransaction.BookID = new Guid(gvFolioDetails.DataKeys[this.RowIndex]["BookID"].ToString());

                ctrlCommoFolioOverrideTransaction.BindOverrideTransactionGrid();

                ctrlCommoFolioOverrideTransaction.ucMpeAddEditOverrideTransaction.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadRoomRentDiscountData()
        {
            try
            {
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountReservationNo.Text = Convert.ToString(gvAccommodationList.DataKeys[this.RowIndex]["ReservationNo"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountName.Text = Convert.ToString(gvAccommodationList.DataKeys[this.RowIndex]["GuestName"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountFolioNo.Text = Convert.ToString(gvAccommodationList.DataKeys[this.RowIndex]["FolioNo"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                ctrlCommonTransactionDiscount.uclitDisplayDiscountAmount.Text = "0.00";

                ctrlCommonTransactionDiscount.ReservationID = this.ReservationID;
                ctrlCommonTransactionDiscount.FolioID = this.FolioID;
                ctrlCommonTransactionDiscount.BookID = new Guid(gvAccommodationList.DataKeys[this.RowIndex]["BookID"].ToString());

                ctrlCommonTransactionDiscount.BindDiscountTransactionGrid();

                ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadRoomRentOverrideData()
        {
            try
            {
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionReservationNo.Text = Convert.ToString(gvAccommodationList.DataKeys[this.RowIndex]["ReservationNo"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionName.Text = Convert.ToString(gvAccommodationList.DataKeys[this.RowIndex]["GuestName"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionFolioNo.Text = Convert.ToString(gvAccommodationList.DataKeys[this.RowIndex]["FolioNo"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionAmount.Text = ctrlCommoFolioOverrideTransaction.uclitDisplayViewOverridedTransactionAmount.Text = "0.00";

                ctrlCommoFolioOverrideTransaction.ReservationID = this.ReservationID;
                ctrlCommoFolioOverrideTransaction.FolioID = this.FolioID;
                ctrlCommoFolioOverrideTransaction.BookID = new Guid(gvAccommodationList.DataKeys[this.RowIndex]["BookID"].ToString());

                ctrlCommoFolioOverrideTransaction.BindOverrideTransactionGrid();
                ctrlCommoFolioOverrideTransaction.ucMpeAddEditOverrideTransaction.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadMISCDiscountData()
        {
            try
            {
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountReservationNo.Text = Convert.ToString(gvMISCDetails.DataKeys[this.RowIndex]["ReservationNo"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountName.Text = Convert.ToString(gvMISCDetails.DataKeys[this.RowIndex]["GuestName"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountFolioNo.Text = Convert.ToString(gvMISCDetails.DataKeys[this.RowIndex]["FolioNo"]);
                ctrlCommonTransactionDiscount.uclitDisplayTransactionDiscountUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                ctrlCommonTransactionDiscount.uclitDisplayDiscountAmount.Text = "0.00";

                ctrlCommonTransactionDiscount.ReservationID = this.ReservationID;
                ctrlCommonTransactionDiscount.FolioID = this.FolioID;
                ctrlCommonTransactionDiscount.BookID = new Guid(gvMISCDetails.DataKeys[this.RowIndex]["BookID"].ToString());

                ctrlCommonTransactionDiscount.BindDiscountTransactionGrid();

                ctrlCommonTransactionDiscount.ucMpeAddEditTransactionDiscount.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadMISCOverrideData()
        {
            try
            {
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionReservationNo.Text = Convert.ToString(gvMISCDetails.DataKeys[this.RowIndex]["ReservationNo"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionName.Text = Convert.ToString(gvMISCDetails.DataKeys[this.RowIndex]["GuestName"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionFolioNo.Text = Convert.ToString(gvMISCDetails.DataKeys[this.RowIndex]["FolioNo"]);
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionUnitNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                ctrlCommoFolioOverrideTransaction.uclitDisplayOverrideTransactionAmount.Text = ctrlCommoFolioOverrideTransaction.uclitDisplayViewOverridedTransactionAmount.Text = "0.00";

                ctrlCommoFolioOverrideTransaction.ReservationID = this.ReservationID;
                ctrlCommoFolioOverrideTransaction.FolioID = this.FolioID;
                ctrlCommoFolioOverrideTransaction.BookID = new Guid(gvMISCDetails.DataKeys[this.RowIndex]["BookID"].ToString());

                ctrlCommoFolioOverrideTransaction.BindOverrideTransactionGrid();
                ctrlCommoFolioOverrideTransaction.ucMpeAddEditOverrideTransaction.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Gridview's Row Command Load Event

        #region Popup Event

        protected void btnYesFolioDetails_Click(object sender, EventArgs e)
        {
            try
            {
                mpeConfirmDeleteFolioDetails.Hide();

                if (Convert.ToString(hdnConfirmDeleteFolioDetails.Value) != string.Empty && Convert.ToString(hdnConfirmDeleteFolioDetails.Value) == "REFUNDBALANCE")
                {
                    LoadDepositRefundData();
                }
                else if (Convert.ToString(hdnConfirmDeleteFolioDetails.Value) != string.Empty && Convert.ToString(hdnConfirmDeleteFolioDetails.Value) == "TRANSFERBALANCE")
                {
                    LoadDepositTransferData();
                }
                else if (Convert.ToString(hdnConfirmDeleteFolioDetails.Value) != string.Empty && Convert.ToString(hdnConfirmDeleteFolioDetails.Value) == "SUBFOLIOCHECKOUT")
                {
                    if (this.SubFolioStatus == "CHECK_IN" && Convert.ToDecimal(litDisplayCreditLimit.Text.Trim()) > 0)
                    {
                        LoadPaymentData();
                    }
                    else if (this.SubFolioStatus == "CHECK_IN" && (Convert.ToString(litDisplayCreditLimit.Text.Trim()) == "0.00" || Convert.ToString(litDisplayCreditLimit.Text.Trim()) == "0"))
                    {
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objUpdate = new BusinessLogic.FrontDesk.DTO.Folio();
                        objUpdate = FolioBLL.GetByPrimaryKey(this.FolioID);
                        if (objUpdate != null)
                        {
                            if (objUpdate.GuestID != null && Convert.ToString(objUpdate.GuestID) != "")
                            {
                                objUpdate.FolioStatus = "CHECK_OUT";
                                FolioBLL.Update(objUpdate);
                                btnSubFolioPaymentCallParent_Click(null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region CheckBox Event
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
            txtStartDate.Text = "";
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        #endregion                      

        protected void btnPrintStatement_Click(object sender, EventArgs e)
        {            
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void LoadReport()
        {
            try
            {
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);
                Symphony.BusinessLogic.FrontDesk.DTO.Folio folio = FolioBLL.GetByPrimaryKey(this.FolioID);
                Session.Add("FolioNo", folio.FolioNo);
                Session.Add("GuestName", litDspGuestName.Text);
                DataSet Dst = FolioBLL.GetRptFolioStatement(this.ReservationID, this.FolioID, startdt, enddt, true);                               
               
                Session["DataSource"] = Dst;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }


        protected void gvSplitBillingFolioList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSplitBillingFolioList.PageIndex = e.NewPageIndex;
            BindSplitBillingFolioGrid();
        }

        protected void gvSplitBillingFolioList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlCurrentBalace = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CurrentBalace"));
                    ((Label)e.Row.FindControl("lblGvSBBalance")).Text = dcmlCurrentBalace.ToString().Substring(0, dcmlCurrentBalace.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvSBCreatedOn = (Label)e.Row.FindControl("lblGvSBCreatedOn");
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CurrentBalace")) != "" && DataBinder.Eval(e.Row.DataItem, "CurrentBalace") != null)
                    {
                        DateTime dtCreationDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CreationDate"));
                        lblGvSBCreatedOn.Text = Convert.ToString(dtCreationDate.ToString(clsSession.DateFormat));
                    }
                    else
                    {
                        lblGvSBCreatedOn.Text = "";
                    }

                    string strFolioStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FolioStatus"));
                    Panel pnlSplitBilling = (Panel)e.Row.FindControl("pnlSplitBilling");
                    AjaxControlToolkit.HoverMenuExtender hmeSplitBilling = (AjaxControlToolkit.HoverMenuExtender)e.Row.FindControl("hmeSplitBilling");
                    Label lblSplitBillingPopUp = (Label)e.Row.FindControl("lblSplitBillingPopUp");

                    if (strFolioStatus != "" && strFolioStatus != null && strFolioStatus == "CHECK_OUT")                    
                    {
                        pnlSplitBilling.Visible =hmeSplitBilling.Enabled = lblSplitBillingPopUp.Visible= false;
                    }
                    else
                    {
                        pnlSplitBilling.Visible =hmeSplitBilling.Enabled = lblSplitBillingPopUp.Visible = true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvSplitBillingFolioList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearSplitBillingControl();

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolio = new BusinessLogic.FrontDesk.DTO.Folio();
                    objFolio = FolioBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    if (objFolio != null)
                    {
                        txtSBBillTo.Text = Convert.ToString(objFolio.BilledTo);
                        txtSBBillingAddress.Text = Convert.ToString(objFolio.BillingAddress);
                        this.SplitBillingFolioID = objFolio.FolioID;

                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.FolioReRoute objFolioReRoute = new BusinessLogic.FrontDesk.DTO.FolioReRoute();
                        objFolioReRoute.SourceFolioID = this.FolioID;
                        objFolioReRoute.IsActive = true;

                        DataSet dsFolioReRoute = new DataSet();
                        dsFolioReRoute = FolioReRouteBLL.GetAllWithDataSet(objFolioReRoute);

                        if (dsFolioReRoute.Tables.Count > 0 && dsFolioReRoute.Tables[0].Rows.Count > 0)
                        {
                            DataView dvFolioReRoute = new DataView(dsFolioReRoute.Tables[0]);
                            dvFolioReRoute.RowFilter = "DestinationFolioID = '" + Convert.ToString(this.SplitBillingFolioID) + "'";

                            for (int i = 0; i < dvFolioReRoute.Count; i++)
                            {
                                int TransactionZone_TermID = Convert.ToInt32(Convert.ToString(dvFolioReRoute[i]["TransactionZone_TermID"]));

                                if (Convert.ToString(TransactionZone_TermID) == "40")
                                {
                                    chkSBAccommodationCharges.Checked = true;
                                }
                                else if (Convert.ToString(TransactionZone_TermID) == "41")
                                {
                                    chkSBRestaurantCharges.Checked = true;
                                }
                                else if (Convert.ToString(TransactionZone_TermID) == "42")
                                {
                                    chkSBPhoneCharges.Checked = true;
                                }
                                else if (Convert.ToString(TransactionZone_TermID) == "43")
                                {
                                    chkSBMiscellaneousCharges.Checked = true;
                                }
                                else if (Convert.ToString(TransactionZone_TermID) == "44")
                                {
                                    chkSBPOS.Checked = true;
                                }
                            }

                            DataRow[] drAccomodation = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '40' and DestinationFolioID <> '" + Convert.ToString(this.SplitBillingFolioID) + "'");
                            DataRow[] drRestaurant = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '41' and DestinationFolioID <> '" + Convert.ToString(this.SplitBillingFolioID) + "'");
                            DataRow[] drPhone = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '42' and DestinationFolioID <> '" + Convert.ToString(this.SplitBillingFolioID) + "'");
                            DataRow[] drMiscellaneous = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '43' and DestinationFolioID <> '" + Convert.ToString(this.SplitBillingFolioID) + "'");
                            DataRow[] drPOS = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '44' and DestinationFolioID <>  '" + Convert.ToString(this.SplitBillingFolioID) + "'");

                            if (drAccomodation.Length > 0)
                                chkSBAccommodationCharges.Enabled = false;

                            if (drRestaurant.Length > 0)
                                chkSBRestaurantCharges.Enabled = false;

                            if (drPhone.Length > 0)
                                chkSBPhoneCharges.Enabled = false;

                            if (drMiscellaneous.Length > 0)
                                chkSBMiscellaneousCharges.Enabled = false;

                            if (drPOS.Length > 0)
                                chkSBPOS.Enabled = false;

                        }
                        else
                            chkSBAccommodationCharges.Enabled = chkSBRestaurantCharges.Enabled = chkSBPhoneCharges.Enabled = chkSBMiscellaneousCharges.Enabled = chkSBPOS.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkSplitBilling_Click(object sender, EventArgs e)
        {
            mvFolio.ActiveViewIndex = 2;
            ClearSplitBillingControl();
            BindSplitBillingFolioGrid();
            CheckFolioReRouteValue();
        }

        protected void btnSplitBillingSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    if (this.SplitBillingFolioID != Guid.Empty)
                    {
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objToUpdate = new BusinessLogic.FrontDesk.DTO.Folio();
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objOldUpdateData = new BusinessLogic.FrontDesk.DTO.Folio();

                        objToUpdate = FolioBLL.GetByPrimaryKey(this.SplitBillingFolioID);
                        objOldUpdateData = FolioBLL.GetByPrimaryKey(this.SplitBillingFolioID);

                        objToUpdate.BilledTo = Convert.ToString(txtSBBillTo.Text.Trim());
                        objToUpdate.BillingAddress = Convert.ToString(txtSBBillingAddress.Text.Trim());
                        objToUpdate.UpdatedOn = DateTime.Now;
                        objToUpdate.UpdatedBy = clsSession.UserID;

                        FolioBLL.Update(objToUpdate);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objOldUpdateData.ToString(), objToUpdate.ToString(), "res_Folio", null);

                        FolioReRouteBLL.DeleteBySourceAndDestinationFolioID(this.FolioID, objToUpdate.FolioID);

                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.FolioReRoute objToInsertFolioReRoute = new BusinessLogic.FrontDesk.DTO.FolioReRoute();
                        objToInsertFolioReRoute.SourceFolioID = this.FolioID;
                        objToInsertFolioReRoute.DestinationFolioID = objToUpdate.FolioID;
                        objToInsertFolioReRoute.IsSameFolio = true;
                        objToInsertFolioReRoute.SearchType = "S";
                        objToInsertFolioReRoute.PropertyID = clsSession.PropertyID;
                        objToInsertFolioReRoute.CompanyID = clsSession.CompanyID;
                        objToInsertFolioReRoute.IsActive = true;

                        if (chkSBAccommodationCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 40;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBRestaurantCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 41;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBPhoneCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 42;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBMiscellaneousCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 43;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBPOS.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 44;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        IsSplitBilling = true;
                        lblSplitBillingMsg.Text = "Folio Update Successfully.";
                    }
                    else
                    {
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objToInsert = new BusinessLogic.FrontDesk.DTO.Folio();

                        objToInsert.ReservationID = this.ReservationID;
                        objToInsert.GuestID = this.SplitBillingGuestID;
                        objToInsert.CreationDate = DateTime.Now;
                        objToInsert.IsSourceFolio = objToInsert.IsSplitFolio = objToInsert.IsActive = objToInsert.IsSubFolio = true;
                        objToInsert.ParentFolioID = this.FolioID;
                        objToInsert.BilledTo = Convert.ToString(txtSBBillTo.Text.Trim());
                        objToInsert.BillingAddress = Convert.ToString(txtSBBillingAddress.Text.Trim());
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.UpdatedOn = DateTime.Now;
                        objToInsert.UpdatedBy = clsSession.UserID;
                        objToInsert.IsLocked = false;
                        objToInsert.Charges = objToInsert.Payment = objToInsert.CurrentBalace = objToInsert.Adjustment = Convert.ToDecimal("0.00");
                        objToInsert.IsDirectBill = false;

                        FolioBLL.Save(objToInsert);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "res_Folio", null);

                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.FolioReRoute objToInsertFolioReRoute = new BusinessLogic.FrontDesk.DTO.FolioReRoute();
                        objToInsertFolioReRoute.SourceFolioID = this.FolioID;
                        objToInsertFolioReRoute.DestinationFolioID = objToInsert.FolioID;
                        objToInsertFolioReRoute.IsSameFolio = true;
                        objToInsertFolioReRoute.SearchType = "S";
                        objToInsertFolioReRoute.PropertyID = clsSession.PropertyID;
                        objToInsertFolioReRoute.CompanyID = clsSession.CompanyID;
                        objToInsertFolioReRoute.IsActive = true;

                        if (chkSBAccommodationCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 40;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBRestaurantCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 41;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBPhoneCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 42;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBMiscellaneousCharges.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 43;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }

                        if (chkSBPOS.Checked)
                        {
                            objToInsertFolioReRoute.TransactionZone_TermID = 44;
                            FolioReRouteBLL.Save(objToInsertFolioReRoute);
                        }


                        IsSplitBilling = true;
                        lblSplitBillingMsg.Text = "Folio Save Successfully.";
                    }

                    ClearSplitBillingControl();
                    BindSplitBillingFolioGrid();
                    CheckFolioReRouteValue();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSplitBillingCancel_Click(object sender, EventArgs e)
        {
            ClearSplitBillingControl();
            CheckFolioReRouteValue();
        }

        protected void btnSplitBillingBack_Click(object sender, EventArgs e)
        {
            mvFolio.ActiveViewIndex = 0;
            BindSubFolio();
        }

        private void BindSplitBillingFolioGrid()
        {
            try
            {
                DataSet dsSplitBilling = FolioBLL.GetFolioSplitBilling(clsSession.PropertyID, clsSession.CompanyID, new Guid(hdn_MasterFolioID.Value), this.ReservationID);
                if (dsSplitBilling.Tables.Count > 0 && dsSplitBilling.Tables[0].Rows.Count > 0)
                {
                    gvSplitBillingFolioList.DataSource = dsSplitBilling.Tables[0];
                    gvSplitBillingFolioList.DataBind();

                }
                else
                {
                    gvSplitBillingFolioList.DataSource = null;
                    gvSplitBillingFolioList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearSplitBillingControl()
        {
            chkSBAccommodationCharges.Checked = chkSBMiscellaneousCharges.Checked = chkSBPhoneCharges.Checked = chkSBPOS.Checked = chkSBRestaurantCharges.Checked = false;
            chkSBAccommodationCharges.Enabled = chkSBMiscellaneousCharges.Enabled = chkSBPhoneCharges.Enabled = chkSBPOS.Enabled = chkSBRestaurantCharges.Enabled = true;
            this.SplitBillingFolioID = Guid.Empty;
            txtSBBillingAddress.Text = txtSBBillTo.Text = "";
        }

        private void CheckFolioReRouteValue()
        {
            try
            {
                DataSet dsFolioReRoute = new DataSet();

                SQT.Symphony.BusinessLogic.FrontDesk.DTO.FolioReRoute objFolioReRoute = new BusinessLogic.FrontDesk.DTO.FolioReRoute();
                objFolioReRoute.SourceFolioID = new Guid(hdn_MasterFolioID.Value);
                objFolioReRoute.IsActive = true;

                dsFolioReRoute = FolioReRouteBLL.GetAllWithDataSet(objFolioReRoute);

                if (dsFolioReRoute.Tables.Count > 0 && dsFolioReRoute.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drAccomodation = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '40'");
                    DataRow[] drRestaurant = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '41'");
                    DataRow[] drPhone = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '42'");
                    DataRow[] drMiscellaneous = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '43'");
                    DataRow[] drPOS = dsFolioReRoute.Tables[0].Select("TransactionZone_TermID = '44'");

                    if (drAccomodation.Length > 0)
                        chkSBAccommodationCharges.Enabled = false;
                    else
                        chkSBAccommodationCharges.Enabled = true;

                    if (drRestaurant.Length > 0)
                        chkSBRestaurantCharges.Enabled = false;
                    else
                        chkSBRestaurantCharges.Enabled = true;

                    if (drPhone.Length > 0)
                        chkSBPhoneCharges.Enabled = false;
                    else
                        chkSBPhoneCharges.Enabled = true;

                    if (drMiscellaneous.Length > 0)
                        chkSBMiscellaneousCharges.Enabled = false;
                    else
                        chkSBMiscellaneousCharges.Enabled = true;

                    if (drPOS.Length > 0)
                        chkSBPOS.Enabled = false;
                    else
                        chkSBPOS.Enabled = true;
                }
                else
                    chkSBAccommodationCharges.Enabled = chkSBRestaurantCharges.Enabled = chkSBPhoneCharges.Enabled = chkSBMiscellaneousCharges.Enabled = chkSBPOS.Enabled = true;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlDisplaySubFolios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.FolioID = new Guid(ddlDisplaySubFolios.SelectedValue);
                BindAllFolioChargesGrid();
                BindAllFolioDepositGrid();
                GetCurrentFolioBalance();

                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolio = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio();
                objFolio = FolioBLL.GetByPrimaryKey(this.FolioID);
                if (objFolio != null)
                {
                    if (objFolio.IsSubFolio != null && Convert.ToString(objFolio.IsSubFolio) != "")
                        this.blIsSubFolio = btnSubFolioCheckOut.Visible = Convert.ToBoolean(objFolio.IsSubFolio);
                    else
                        this.blIsSubFolio = btnSubFolioCheckOut.Visible = false;

                    this.SubFolioStatus = Convert.ToString(objFolio.FolioStatus);
                }
                else
                {
                    this.blIsSubFolio = btnSubFolioCheckOut.Visible = false;
                    this.SubFolioStatus = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkQuickPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.strOpenModalDialog = "QUICKPOST";

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

                    this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                    return;
                }

                LoadQuickPostData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadQuickPostData()
        {
            try
            {
                ctrlCommonQuickPost.BindModeOfPayment();
                ctrlCommonQuickPost.ClearControl();
                ctrlCommonQuickPost.BindQuickPostGrid();

                ctrlCommonQuickPost.litFolioNo.Text = Convert.ToString(litDisplayFolioNo.Text.Trim());
                ctrlCommonQuickPost.litGuestName.Text = Convert.ToString(lblFolioDetailsDisplayGuestName.Text.Trim());
                ctrlCommonQuickPost.litRoomNo.Text = Convert.ToString(litDisplayUnitNo.Text.Trim());
                ctrlCommonQuickPost.litBalance.Text = Convert.ToString(litDisplayCreditLimit.Text.Trim());

                ctrlCommonQuickPost.FolioID = this.FolioID;
                ctrlCommonQuickPost.ReservationID = this.ReservationID;
                ctrlCommonQuickPost.GuestID = this.SplitBillingGuestID;

                ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSubFolioCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.strOpenModalDialog = "CHECKOUT_PAYMENT";
                hdnConfirmDeleteFolioDetails.Value = "SUBFOLIOCHECKOUT";
                lblConfirmDeleteMsg.Text = "Sure you want to Check Out?";

                if (this.SubFolioStatus == "CHECK_IN" && Convert.ToDecimal(litDisplayCreditLimit.Text.Trim()) > 0)
                {
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

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    mpeConfirmDeleteFolioDetails.Show();
                }
                else if (this.SubFolioStatus == "CHECK_IN" && Convert.ToDecimal(litDisplayCreditLimit.Text.Trim()) < 0)
                {
                }
                else if (this.SubFolioStatus == "CHECK_IN" && (Convert.ToString(litDisplayCreditLimit.Text.Trim()) == "0.00" || Convert.ToString(litDisplayCreditLimit.Text.Trim()) == "0"))
                {
                    mpeConfirmDeleteFolioDetails.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadPaymentData()
        {
            try
            {
                ctrlSubFolioPayment.ucMpeAddEditPayment.Show();
                ctrlSubFolioPayment.strProcess = "CHECKOUTPROCESS";

                ctrlSubFolioPayment.IsMessage = false;
                ctrlSubFolioPayment.uclitDisplayPaymentFolioNo.Text = Convert.ToString(litDisplayFolioNo.Text.Trim());
                ctrlSubFolioPayment.uclitDisplayPaymentGuestName.Text = Convert.ToString(lblFolioDetailsDisplayGuestName.Text.Trim());
                ctrlSubFolioPayment.uclitDisplayRoomNoAndRoomType.Text = Convert.ToString(litDisplayUnitNo.Text.Trim() + " - " + litDisplayRoomType.Text.Trim());

                ctrlSubFolioPayment.uctxtPaymentAmount.Enabled = false;

                ctrlSubFolioPayment.ReservationID = this.ReservationID;
                ctrlSubFolioPayment.FolioID = this.FolioID;
                ctrlSubFolioPayment.GuestID = this.SplitBillingGuestID;

                ctrlSubFolioPayment.BindPaymentMode();
                ctrlSubFolioPayment.ClearPaymentControl();
                ctrlSubFolioPayment.uclitDisplayPaymentBalance.Text = ctrlSubFolioPayment.uctxtPaymentAmount.Text = Convert.ToString(litDisplayCreditLimit.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSubFolioPaymentCallParent_Click(object sender, EventArgs e)
        {
            try
            {
                this.FolioID = new Guid(hdn_MasterFolioID.Value);
                BindSubFolio();
                BindAllFolioChargesGrid();
                BindAllFolioDepositGrid();
                GetCurrentFolioBalance();
                IsMessageForSubFolioCheckOut = true;
                litSubFolioCheckOutMsg.Text = "Folio Check Out Successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void rdoDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDetail.Checked)
                Session.Add("ReportName", "Folio Statement");
            else if (rdoSummary.Checked)
                Session.Add("ReportName", "Folio Summary");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAllFolioChargesGrid();
        }
    }
}