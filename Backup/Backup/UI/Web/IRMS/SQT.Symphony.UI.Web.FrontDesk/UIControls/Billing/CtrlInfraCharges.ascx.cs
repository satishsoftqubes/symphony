using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing
{
    public partial class CtrlInfraCharges : System.Web.UI.UserControl
    {
        #region Property and Variables
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
        #endregion

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        #endregion

        #region Methods
        public void LoadData()
        {
            try
            {
                if (clsSession.ToEditItemID != null && Session["ReservationNo"] != null)
                {
                    this.ReservationID = clsSession.ToEditItemID;
                    hdnResID.Value = Convert.ToString(this.ReservationID);
                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                    

                    BindDDL();

                    DataSet dsReservation = ReservationBLL.SelectReservationDetailByReservationNo(Convert.ToString(Session["ReservationNo"]), "");
                    if (dsReservation != null && dsReservation.Tables[0].Rows.Count > 0)
                    {
                        DataRow drResData = dsReservation.Tables[0].Rows[0];
                        ltrChkPmtReservationNo.Text = Convert.ToString(drResData["ReservationNo"]);
                        ltrChkPmtGuestName.Text = Convert.ToString(drResData["GuestFullName"]);
                        ltrChkPmtCheckInDate.Text = Convert.ToDateTime(Convert.ToString(drResData["CheckInDate"])).ToString("dd-MM-yyyy");
                        ltrChkPmtCheckOutDate.Text = Convert.ToDateTime(Convert.ToString(drResData["CheckOutDate"])).ToString("dd-MM-yyyy");
                        ltrChkPmtRateCard.Text = Convert.ToString(drResData["RateCardName"]);
                        ltrChkPmtRoomType.Text = Convert.ToString(drResData["RoomTypeName"]);
                        ltrChkPmtRoomNo.Text = Convert.ToString(drResData["RoomNo"]);
                        this.RoomID = new Guid(Convert.ToString(drResData["RoomID"]));
                        this.GuestID = new Guid(Convert.ToString(drResData["GuestID"]));
                        this.ReservationFolioID = new Guid(Convert.ToString(drResData["FolioID"]));

                        if (dsReservation.Tables.Count > 1)
                        {
                            if (Convert.ToInt32(dsReservation.Tables[1].Rows[0]["INFRASERVICECHARGE"]) > 0)
                            {
                                txtPaymentAmount.Text = Convert.ToString(dsReservation.Tables[1].Rows[0]["INFRASERVICECHARGE"]);
                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("No reservation found.");
                    }

                    Session["ReservationNo"] = null;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindDDL()
        {
            DataSet dsData = ProjectTermBLL.SelectTitleCSWTGT(clsSession.CompanyID, clsSession.PropertyID, "TITLE", "COMPANYSECTOR", "WORKINGTIME", "GUESTTYPE", "ID DOCUMENT TYPE", "BLOOD GROUP", "MEAL PREFERENCE", "PAYMENTMODE");
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
        }
        #endregion

        #region Control Events
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

                    //if (Convert.ToDecimal(txtPaymentAmount.Text.Trim()) > this.AmountSuggestedToPay)
                    //{
                    //    mpeAmoutIsLargerThanSuggestedAlert.Show();
                    //    return;
                    //}

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

                    decimal InfraServiceChargeGoingToPay = Convert.ToDecimal("0.000000");
                    InfraServiceChargeGoingToPay = Convert.ToDecimal(txtPaymentAmount.Text.Trim());

                    Guid? PaymentAcctID = null;
                    Guid? CounterID = clsSession.DefaultCounterID; // new Guid("acadee48-26ec-4a92-8aae-bc2f8c4e8037"); //null;

                    string strReturnBookID = string.Empty;

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
                    
                    //Save Payment End

                    ReservationBLL.UpdateOverStayStatusAfterPayment(this.ReservationID);

                    //After saving payment, update it's value.
                    if (strReturnBookID == "")
                        strReturnBookID = null;

                    //After saving payment, update it's value.
                    hdnBookingID.Value = strReturnBookID;
                    ucPaymentReceipt.BindSinglePaymentDetails(this.ReservationID, this.GuestID, ltrChkPmtGuestName.Text, txtPaymentAmount.Text.Trim(), ddlModeOfPayment.SelectedItem.Text, strReturnBookID);

                    //txtPaymentTimeEmail.Text = hfOldGuestEmail.Value = Convert.ToString(ucPaymentReceipt.gstGuestEmail);

                    txtPaymentAmount.Text = "";
                    ddlModeOfPayment.SelectedIndex = 0;
                    ddlModeOfPayment_OnSelectedIndexChanged(null, null);
                    mpePrintReceipt.Show();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnCheckInCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }
        #endregion
    }
}