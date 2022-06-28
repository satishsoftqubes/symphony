using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonPayment : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditPayment
        {
            get { return this.mpePayment; }
        }

        public MultiView mvOpenPayment
        {
            get { return this.mvPayment; }
        }

        public event EventHandler btnPaymentCallParent_Click;

        public event EventHandler btnSubFolioPaymentCallParent_Click;

        public Literal uclitDisplayPaymentFolioNo
        {
            get { return this.litDisplayPaymentFolioNo; }
        }

        public Literal uclitDisplayRoomNoAndRoomType
        {
            get { return this.litDisplayRoomNoAndRoomType; }
        }

        public Literal uclitDisplayPaymentGuestName
        {
            get { return this.litDisplayPaymentGuestName; }
        }

        public Literal uclitDisplayPaymentBalance
        {
            get { return this.litDisplayPaymentBalance; }
        }

        public TextBox uctxtPaymentAmount
        {
            get { return this.txtPaymentAmount; }
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

        public Guid ResPayID
        {
            get
            {
                return ViewState["ResPayID"] != null ? new Guid(Convert.ToString(ViewState["ResPayID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResPayID"] = value;
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

        public bool IsMessage = false;

        public bool IsMessageForPayment = false;

        public string strMode = null;

        public string strProcess
        {
            get
            {
                return ViewState["strProcess"] != null ? Convert.ToString(ViewState["strProcess"]) : string.Empty;
            }
            set
            {
                ViewState["strProcess"] = value;
            }
        }

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvPayment.ActiveViewIndex = 0;
            }
        }

        #endregion

        #region Private Method
        public void BindCardListGrid()
        {
            try
            {
                DataSet dsData = ResGuestPaymentInfoBLL.GetCreditCardListData(this.GuestID, clsSession.PropertyID, clsSession.CompanyID, "CREDITCARDTYPE");

                if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    gvCardList.DataSource = dsData.Tables[0];
                    gvCardList.DataBind();
                }
                else
                {
                    gvCardList.DataSource = null;
                    gvCardList.DataBind();
                }

                ddlCreditCardType.Items.Clear();
                if (dsData.Tables.Count > 1 && dsData.Tables[1].Rows.Count > 0)
                {
                    ddlCreditCardType.DataSource = dsData.Tables[1];
                    ddlCreditCardType.DataTextField = "DisplayTerm";
                    ddlCreditCardType.DataValueField = "TermID";
                    ddlCreditCardType.DataBind();
                    ddlCreditCardType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlCreditCardType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ClearControlCardInfo()
        {
            txtCardNo.Text = txtCardHolderName.Text = txtSecurityCode.Text = "";
            ddlCreditCardType.SelectedIndex = rdbPaymentOrBlock.SelectedIndex = ddlCardExpirationYear.SelectedIndex = ddlCardExpirationMonth.SelectedIndex = 0;
            this.ResPayID = Guid.Empty;
        }

        public void BindPaymentMode()
        {
            try
            {
                //Bind ModeOfPayment
                List<ProjectTerm> lstModeOfPayment = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
                if (lstModeOfPayment.Count != 0)
                {
                    ddlPModeOfPayment.DataSource = lstModeOfPayment;
                    ddlPModeOfPayment.DataTextField = "DisplayTerm";
                    ddlPModeOfPayment.DataValueField = "TermID";
                    ddlPModeOfPayment.DataBind();
                    ddlPModeOfPayment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlPModeOfPayment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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

        private void BindAddModeExpiryDate()
        {
            try
            {
                ddlCardExpirationYear.Items.Clear();
                int j = 1;
                ddlCardExpirationYear.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
                {
                    ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                    j++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindEditModeExpiryDate()
        {
        }

        public void ClearPaymentControl()
        {
            ddlPModeOfPayment.SelectedIndex = 0;
            txtPaymentAmount.Text = txtBankName.Text = txtChequeDDNo.Text = txtPaymentNotes.Text = hdnPaymentType.Value = hdnResPayID.Value = "";
            string strRegExpression = "\\d{0,13}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revPaymentAmount.ValidationExpression = strRegExpression;
            revPaymentAmount.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            trLedgerAccount.Visible = trChequeDD1.Visible = btnPaymentCardInfo.Visible = false;
        }

        #endregion

        #region Control Event

        protected void btnPaymentCardInfo_Click(object sender, EventArgs e)
        {
            try
            {
                mvPayment.ActiveViewIndex = 1;
                mpePayment.Show();
                litDisplayCardHolderName.Text = txtCardHolderName.Text = Convert.ToString(litDisplayPaymentGuestName.Text.Trim());
                BindCardListGrid();
                BindAddModeExpiryDate();
                ClearControlCardInfo();

                EventHandler temp = btnPaymentCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void btnCancelCardDetailsForPayment_Click(object sender, EventArgs e)
        {
            mpePayment.Show();
            mvPayment.ActiveViewIndex = 0;
        }

        protected void btnPaymentSubFolio_Click(object sender, EventArgs e)
        {
            mpePayment.Show();
            mvPayment.ActiveViewIndex = 2;
        }

        protected void btnSubFolioConfigurationCallParent_Click(object sender, EventArgs e)
        {
            try
            {
                string strOperation = ctrlCommonSubFolioConfiguration.strMode;

                if (strOperation == "OPENPOPUP")
                {
                    mpePayment.Show();
                    ctrlCommonSubFolioConfiguration.mvOpenSubFolio.ActiveViewIndex = 1;
                }
                else if (strOperation == "SHOWVIEWWITHPOPUP0")
                {
                    mpePayment.Show();
                    ctrlCommonSubFolioConfiguration.mvOpenSubFolio.ActiveViewIndex = 0;
                }
                else if (strOperation == "CLOSEPOPUP")
                {
                    mpePayment.Show();
                }
                else if (strOperation == "SHOWVIEWWITHRRPOPUP0")
                {
                    mpePayment.Show();
                    mvOpenPayment.ActiveViewIndex = 0;
                }
                else if (strOperation == "CLOSESUBFOLIO")
                {
                    mpePayment.Show();
                    mvOpenPayment.ActiveViewIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSaveCardDetails_Click(object sender, EventArgs e)
        {
            mpePayment.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    ResGuestPaymentInfo IsCardInfo = new ResGuestPaymentInfo();
                    IsCardInfo.CompanyID = clsSession.CompanyID;
                    IsCardInfo.PropertyID = clsSession.PropertyID;
                    IsCardInfo.IsActive = true;
                    IsCardInfo.CardNo = Convert.ToString(txtCardNo.Text.Trim());

                    List<ResGuestPaymentInfo> LstDupCardInfo = null;
                    LstDupCardInfo = ResGuestPaymentInfoBLL.GetAll(IsCardInfo);

                    if (LstDupCardInfo.Count > 0)
                    {
                        if (this.ResPayID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupCardInfo[0].ResPayID)) != Convert.ToString(this.ResPayID.ToString()))
                            {
                                IsMessage = true;
                                ltrMsgList.Text = "Recored Already Exist.";
                                mpePayment.Show();
                                return;
                            }
                        }
                        else
                        {
                            IsMessage = true;
                            ltrMsgList.Text = "Recored Already Exist.";
                            mpePayment.Show();
                            return;
                        }
                    }


                    if (this.ResPayID != Guid.Empty)
                    {
                        //// if payment mode is Credit card, then check Credit Card's Expiretion date Start
                        String strPaymentMode = string.Empty;//// It will use to save Credit Card info. in ResPyamentGuest object
                        ResGuestPaymentInfo objUpdPaymentInfo = null;
                        if (ddlPModeOfPayment.SelectedIndex != 0)
                        {
                            ProjectTerm pTermPaymentInfo = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlPModeOfPayment.SelectedValue));
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

                                    if (txtCardNo.Text.Trim().Length < 16)
                                    {
                                        MessageBox.Show("Invalid card number, it must be 16 digits.");
                                        return;
                                    }

                                    if (txtSecurityCode.Text.Trim().Length < 3)
                                    {
                                        MessageBox.Show("Invalid CVV No., it must have atleast 3 digit.");
                                        return;
                                    }
                                }
                            }

                            //// If Payment is done throubh creditcard, then save its information Start
                            if (strPaymentMode == "CREDIT CARD")
                            {
                                ResGuestPaymentInfo objOldData = new ResGuestPaymentInfo();
                                objUpdPaymentInfo = new ResGuestPaymentInfo();
                                objUpdPaymentInfo = ResGuestPaymentInfoBLL.GetByPrimaryKey(this.ResPayID);
                                objOldData = ResGuestPaymentInfoBLL.GetByPrimaryKey(this.ResPayID);

                                objUpdPaymentInfo.MOP_TermID = new Guid(ddlPModeOfPayment.SelectedValue);
                                objUpdPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                                objUpdPaymentInfo.CardNo = txtCardNo.Text.Trim();
                                objUpdPaymentInfo.CardHolderName = txtCardHolderName.Text.Trim();
                                objUpdPaymentInfo.DateOfExpiry = new DateTime(Convert.ToInt32(ddlCardExpirationYear.SelectedValue), Convert.ToInt32(ddlCardExpirationMonth.SelectedValue), 1);

                                if (rdbPaymentOrBlock.SelectedValue.ToUpper() == "CHARGE")
                                    objUpdPaymentInfo.IsCreditCardCharged = true;
                                else
                                    objUpdPaymentInfo.IsCreditCardCharged = false;

                                objUpdPaymentInfo.CVVNo = txtSecurityCode.Text.Trim();
                                objUpdPaymentInfo.PropertyID = clsSession.PropertyID;
                                objUpdPaymentInfo.CompanyID = clsSession.CompanyID;
                                objUpdPaymentInfo.ReservationID = this.ReservationID;
                                objUpdPaymentInfo.FolioID = this.FolioID;
                                objUpdPaymentInfo.IsActive = true;
                                objUpdPaymentInfo.GuestID = this.GuestID;

                                ResGuestPaymentInfoBLL.Update(objUpdPaymentInfo);
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objOldData.ToString(), objUpdPaymentInfo.ToString(), "res_ResGuestPaymentInfo", null);
                                IsMessage = true;
                                ltrMsgList.Text = "Record Update Successfully.";
                            }
                            //// If Payment is done throubh creditcard, then save its information End
                        }
                    }
                    else
                    {
                        //// if payment mode is Credit card, then check Credit Card's Expiretion date Start
                        String strPaymentMode = string.Empty;//// It will use to save Credit Card info. in ResPyamentGuest object
                        ResGuestPaymentInfo objPaymentInfo = null;
                        if (ddlPModeOfPayment.SelectedIndex != 0)
                        {
                            ProjectTerm pTermPaymentInfo = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlPModeOfPayment.SelectedValue));
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

                                    if (txtCardNo.Text.Trim().Length < 16)
                                    {
                                        MessageBox.Show("Invalid card number, it must be 16 digits.");
                                        return;
                                    }

                                    if (txtSecurityCode.Text.Trim().Length < 3)
                                    {
                                        MessageBox.Show("Invalid CVV No., it must have atleast 3 digit.");
                                        return;
                                    }
                                }
                            }

                            //// If Payment is done throubh creditcard, then save its information Start
                            if (strPaymentMode == "CREDIT CARD")
                            {
                                objPaymentInfo = new ResGuestPaymentInfo();
                                objPaymentInfo.MOP_TermID = new Guid(ddlPModeOfPayment.SelectedValue);
                                objPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                                objPaymentInfo.CardNo = txtCardNo.Text.Trim();
                                objPaymentInfo.CardHolderName = txtCardHolderName.Text.Trim();
                                objPaymentInfo.DateOfExpiry = new DateTime(Convert.ToInt32(ddlCardExpirationYear.SelectedValue), Convert.ToInt32(ddlCardExpirationMonth.SelectedValue), 1);

                                if (rdbPaymentOrBlock.SelectedValue.ToUpper() == "CHARGE")
                                    objPaymentInfo.IsCreditCardCharged = true;
                                else
                                    objPaymentInfo.IsCreditCardCharged = false;

                                objPaymentInfo.CVVNo = txtSecurityCode.Text.Trim();
                                objPaymentInfo.PropertyID = clsSession.PropertyID;
                                objPaymentInfo.CompanyID = clsSession.CompanyID;
                                objPaymentInfo.ReservationID = this.ReservationID;
                                objPaymentInfo.FolioID = this.FolioID;
                                objPaymentInfo.IsActive = true;
                                objPaymentInfo.GuestID = this.GuestID;

                                ResGuestPaymentInfoBLL.Save(objPaymentInfo);
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objPaymentInfo.ToString(), objPaymentInfo.ToString(), "res_ResGuestPaymentInfo", null);
                                IsMessage = true;
                                ltrMsgList.Text = "Record Save Successfully.";
                            }
                            //// If Payment is done throubh creditcard, then save its information End
                        }
                    }

                    BindCardListGrid();
                    ClearControlCardInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected void btnPaymentSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    mpePayment.Show();

                    //Save Payment Start
                    if (Convert.ToString(txtPaymentAmount.Text.Trim()) == string.Empty || !(Convert.ToDecimal(txtPaymentAmount.Text.Trim()) > 0))
                    {
                        MessageBox.Show("Invalid payment amount, it must be greater than 0.");
                        return;
                    }

                    if (hdnPaymentType.Value != "" && Convert.ToString(hdnPaymentType.Value) == "CREDITCARD")
                    {
                        if (hdnResPayID.Value == "")
                        {
                            mpeCreditCardInfoMsg.Show();
                            return;
                        }
                    }

                    //if (strProcess != string.Empty && strProcess == "CHECKOUTPROCESS")
                    //{
                    //    DataTable dtSessionPayment = new DataTable();

                    //    DataColumn dc1 = new DataColumn("MOPID");
                    //    DataColumn dc2 = new DataColumn("Amount");
                    //    DataColumn dc3 = new DataColumn("Notes");
                    //    DataColumn dc4 = new DataColumn("ResPayID");

                    //    dtSessionPayment.Columns.Add(dc1);
                    //    dtSessionPayment.Columns.Add(dc2);
                    //    dtSessionPayment.Columns.Add(dc3);
                    //    dtSessionPayment.Columns.Add(dc4);

                    //    DataRow dr = dtSessionPayment.NewRow();
                    //    dr["MOPID"] = Convert.ToString(ddlLedgerAccount.SelectedValue);
                    //    dr["Amount"] = Convert.ToString(txtPaymentAmount.Text.Trim());
                    //    dr["Notes"] = Convert.ToString(txtPaymentNotes.Text.Trim());
                    //    if (hdnResPayID.Value != "")
                    //        dr["ResPayID"] = Convert.ToString(hdnResPayID.Value);
                    //    else
                    //        dr["ResPayID"] = "";

                    //    dtSessionPayment.Rows.Add(dr);

                    //    mpePayment.Hide();

                    //    Session["SessionPaymentData"] = dtSessionPayment;
                    //    this.strProcess = string.Empty;

                    //    EventHandler temp = btnSubFolioPaymentCallParent_Click;
                    //    if (temp != null)
                    //    {
                    //        temp(sender, e);
                    //    }
                    //}
                    //else
                    //{

                    if (strProcess != string.Empty && strProcess == "RESERVATIONPAYMENT")
                    {
                        decimal CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        CurrentPayingAmount = Convert.ToDecimal(txtPaymentAmount.Text.Trim());

                        Guid? PaymentAcctID = null;
                        Guid? CounterID = clsSession.DefaultCounterID;
                        
                        int Zone_TermID = 0;
                        Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (hdnPaymentType.Value != "" && Convert.ToString(hdnPaymentType.Value) == "CREDITCARD")
                            ResPayID = new Guid(hdnResPayID.Value);

                        Guid tempBookID = Guid.Empty;
                        Guid? resRoomID = null;

                        if (this.RoomID != Guid.Empty && this.RoomID != null)
                            resRoomID = this.RoomID;

                        tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, Convert.ToDecimal(txtPaymentAmount.Text.Trim()), PaymentAcctID, DepositAcctID, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", resRoomID, "ROOM DEPOSIT", clsSession.CompanyID, ResPayID);

                        this.strProcess = string.Empty;
                        this.RoomID = Guid.Empty;
                        mpePayment.Hide();
                    }
                    else
                    {
                        Guid returnBookID = Guid.Empty;

                        if (hdnResPayID.Value != "")
                        {
                            returnBookID = BookKeepingBLL.ReceivePayment(new Guid(ddlLedgerAccount.SelectedValue), Convert.ToDecimal(txtPaymentAmount.Text.Trim()), this.ReservationID, this.FolioID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.CompanyID, "FRONT DESK", new Guid(hdnResPayID.Value), false);
                        }
                        else
                        {
                            returnBookID = BookKeepingBLL.ReceivePayment(new Guid(ddlLedgerAccount.SelectedValue), Convert.ToDecimal(txtPaymentAmount.Text.Trim()), this.ReservationID, this.FolioID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.CompanyID, "FRONT DESK", null, false);
                        }

                        if (returnBookID != Guid.Empty)
                        {
                            BookKeeping objUpd = new BookKeeping();
                            objUpd = BookKeepingBLL.GetByPrimaryKey(returnBookID);

                            objUpd.Narration = txtPaymentNotes.Text.Trim();
                            BookKeepingBLL.Update(objUpd);

                            ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Receive Payment", objUpd.ToString(), objUpd.ToString(), "tra_BookKeeping", null);
                        }

                        ClearPaymentControl();
                        IsMessageForPayment = true;
                        litPaymentMsg.Text = "Record Save Successfully.";

                        if (strProcess != string.Empty && strProcess == "CHECKOUTPROCESS")
                        {
                            this.strProcess = string.Empty;
                            mpePayment.Hide();
                            SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objUpdate = new BusinessLogic.FrontDesk.DTO.Folio();
                            objUpdate = FolioBLL.GetByPrimaryKey(this.FolioID);
                            if (objUpdate != null)
                            {
                                if (objUpdate.GuestID != null && Convert.ToString(objUpdate.GuestID) != "")
                                {
                                    objUpdate.FolioStatus = "CHECK_OUT";
                                    FolioBLL.Update(objUpdate);
                                }
                            }

                            EventHandler temp = btnSubFolioPaymentCallParent_Click;
                            if (temp != null)
                            {
                                temp(sender, e);
                            }
                        }
                        else
                        {
                            strMode = "REFRESHFOLIOLISTGRID";
                            this.strProcess = string.Empty;

                            EventHandler temp = btnPaymentCallParent_Click;
                            if (temp != null)
                            {
                                temp(sender, e);
                            }
                        }
                    }
                }
                //}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion

        #region DropDown Event

        protected void ddlPModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnPaymentType.Value = "";
                mpePayment.Show();
                btnPaymentCardInfo.Visible = false;

                if (ddlPModeOfPayment.SelectedIndex != 0)
                {
                    ddlLedgerAccount.Items.Clear();

                    DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlPModeOfPayment.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
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
                    btnPaymentCardInfo.Visible = trLedgerAccount.Visible = false;
                }


                trChequeDD1.Visible = false;
                if (ddlPModeOfPayment.SelectedIndex != 0)
                {
                    ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlPModeOfPayment.SelectedValue));

                    if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
                    {
                        trChequeDD1.Visible = true;
                    }
                    else if (objProjectTerm.Term.Trim().ToUpper() == "CREDIT CARD")
                    {
                        btnPaymentCardInfo.Visible = true;
                        hdnPaymentType.Value = "CREDITCARD";
                        //trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = false;
                        //trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = true;

                        //////Bind Credit Card Type Start
                        //string strSelect = "-Select-"; //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
                        //ddlCreditCardType.Items.Clear();
                        //List<ProjectTerm> lstSourceOfBusiness = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "CREDITCARDTYPE");
                        //if (lstSourceOfBusiness.Count != 0)
                        //{
                        //    ddlCreditCardType.DataSource = lstSourceOfBusiness;
                        //    ddlCreditCardType.DataTextField = "DisplayTerm";
                        //    ddlCreditCardType.DataValueField = "TermID";
                        //    ddlCreditCardType.DataBind();
                        //    ddlCreditCardType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                        //}
                        //else
                        //    ddlCreditCardType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                        //////Bind Credit Card Type Start

                        //////Bind Year Start

                        //ddlCardExpirationYear.Items.Clear();
                        //int j = 1;
                        //ddlCardExpirationYear.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                        //for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
                        //{
                        //    ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                        //    j++;
                        //}
                        //////Bind Year Start
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion DropDown Event

        #region Grid Event

        protected void gvCardList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            mpePayment.Show();
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearControlCardInfo();

                    this.ResPayID = new Guid(Convert.ToString(e.CommandArgument));
                    ResGuestPaymentInfo objResGuestPaymentInfo = new ResGuestPaymentInfo();
                    objResGuestPaymentInfo = ResGuestPaymentInfoBLL.GetByPrimaryKey(this.ResPayID);

                    if (objResGuestPaymentInfo != null)
                    {
                        ddlCreditCardType.SelectedIndex = ddlCreditCardType.Items.FindByValue(Convert.ToString(objResGuestPaymentInfo.CardType_TermID)) != null ? ddlCreditCardType.Items.IndexOf(ddlCreditCardType.Items.FindByValue(Convert.ToString(objResGuestPaymentInfo.CardType_TermID))) : 0;
                        txtCardNo.Text = Convert.ToString(objResGuestPaymentInfo.CardNo);
                        txtCardHolderName.Text = Convert.ToString(objResGuestPaymentInfo.CardHolderName);

                        DateTime dtDBDateOfExpiry = Convert.ToDateTime(objResGuestPaymentInfo.DateOfExpiry);
                        ddlCardExpirationYear.Items.Clear();
                        int j = 1;
                        ddlCardExpirationYear.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                        if (dtDBDateOfExpiry.Year >= DateTime.Now.Year)
                        {
                            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
                            {
                                ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                                j++;
                            }
                        }
                        else
                        {
                            for (int i = dtDBDateOfExpiry.Year; i < DateTime.Now.Year + 20; i++)
                            {
                                ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                                j++;
                            }
                        }

                        ddlCardExpirationMonth.SelectedIndex = ddlCardExpirationMonth.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Month)) != null ? ddlCardExpirationMonth.Items.IndexOf(ddlCardExpirationMonth.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Month))) : 0;
                        ddlCardExpirationYear.SelectedIndex = ddlCardExpirationYear.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Year)) != null ? ddlCardExpirationYear.Items.IndexOf(ddlCardExpirationYear.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Year))) : 0;

                        txtSecurityCode.Text = Convert.ToString(objResGuestPaymentInfo.CVVNo);

                        if (objResGuestPaymentInfo.IsCreditCardCharged != null && Convert.ToString(objResGuestPaymentInfo.IsCreditCardCharged) != "")
                        {
                            bool isCreditCardCharge = Convert.ToBoolean(objResGuestPaymentInfo.IsCreditCardCharged);
                            if (isCreditCardCharge)
                                rdbPaymentOrBlock.SelectedIndex = 0;
                            else
                                rdbPaymentOrBlock.SelectedIndex = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvCardList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    Label lblGvCardNo = (Label)e.Row.FindControl("lblGvCardNo");
                    string strCardNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CardNo"));
                    lblGvCardNo.Text = Convert.ToString(GetCardNo(strCardNo));

                    lnkDelete.ToolTip = "Delete";
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ResPayID")));

                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Grid Event

        #region Checkbox Event

        protected void chkSelectCardDetails_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                mpePayment.Show();
                hdnResPayID.Value = "";

                CheckBox chkSelectCardDetails = (CheckBox)sender;
                GridViewRow row = (GridViewRow)chkSelectCardDetails.NamingContainer;

                Guid resPayID = new Guid(gvCardList.DataKeys[row.RowIndex]["ResPayID"].ToString());

                hdnResPayID.Value = Convert.ToString(resPayID);
                mvPayment.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Checkbox Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            mpePayment.Show();
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    ResGuestPaymentInfo objDelete = new ResGuestPaymentInfo();
                    objDelete = ResGuestPaymentInfoBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    mpeConfirmDelete.Hide();
                    //Employee objDelete = new Employee();
                    //objDelete = EmployeeBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    //EmployeeBLL.Delete(objDelete);                    
                    ResGuestPaymentInfoBLL.Delete(new Guid(hdnConfirmDelete.Value));
                    IsMessage = true;
                    ltrMsgList.Text = "Record deleted successfully.";
                    ClearControlCardInfo();

                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "res_ResGuestPaymentInfo", null);

                }
                BindCardListGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Popup Button Event
    }
}