using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;
using System.Configuration;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing
{
    public partial class CtrlCheckOutNew : System.Web.UI.UserControl
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
        public bool IsGstFeedBackMessage = false;
        public bool? IsPreview = false;

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

        public Decimal dcmlTotalAmountRefundOrPayment
        {
            get
            {
                return ViewState["dcmlTotalAmountRefundOrPayment"] != null ? Convert.ToDecimal(ViewState["dcmlTotalAmountRefundOrPayment"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["dcmlTotalAmountRefundOrPayment"] = value;
            }
        }
        public string strRefundOrPayment
        {
            get
            {
                return ViewState["strRefundOrPayment"] != null ? Convert.ToString(ViewState["strRefundOrPayment"]) : "";
            }
            set
            {
                ViewState["strRefundOrPayment"] = value;
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
        public bool IsTodaysChargePost
        {
            get
            {
                return ViewState["IsTodaysChargePost"] != null ? Convert.ToBoolean(ViewState["IsTodaysChargePost"]) : false;
            }
            set
            {
                ViewState["IsTodaysChargePost"] = value;
            }
        }
        public Guid AgentID
        {
            get
            {
                return ViewState["AgentID"] != null ? new Guid(Convert.ToString(ViewState["AgentID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AgentID"] = value;
            }
        }
        public Decimal BillingAmount
        {
            get
            {
                return ViewState["BillingAmount"] != null ? Convert.ToDecimal(ViewState["BillingAmount"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["BillingAmount"] = value;
            }
        }
        public string strBillingFromDate
        {
            get
            {
                return ViewState["strBillingFromDate"] != null ? Convert.ToString(ViewState["strBillingFromDate"]) : string.Empty;
            }
            set
            {
                ViewState["strBillingFromDate"] = value;
            }
        }
        public string strBillingToDate
        {
            get
            {
                return ViewState["strBillingToDate"] != null ? Convert.ToString(ViewState["strBillingToDate"]) : string.Empty;
            }
            set
            {
                ViewState["strBillingToDate"] = value;
            }
        }
        public decimal dcmlTotalUnpostedCharge = Convert.ToDecimal("0.000000");
        public decimal dcmlTotalDepositToProcess = Convert.ToDecimal("0.000000");



        decimal dcmlftCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftPayment = Convert.ToDecimal("0.000000");
        decimal dcmlftAccomodationCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftMISCCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftTotalPayment = Convert.ToDecimal("0.000000");
        decimal dcmlftTotalDueAmount = Convert.ToDecimal("0.000000");
        decimal dcmlBalanceAmount = Convert.ToDecimal("0.000000");
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                rdoSummary.Checked = true;
                rdoDetail.Checked = false;
                rdoDetail_CheckedChanged(null, null);

                LoadDataOnPageLoadEvent();
            }
        }
        #endregion  Page Load

        #region Control Event

        protected void btnPaymentCancel_Click(object sender, EventArgs e)
        {
            mvCheckOut.ActiveViewIndex = 0;
        }

        protected void btnTransferCheckedDeposits_OnClick(object sender, EventArgs e)
        {
            try
            {
                int Zone_TermID = 0;
                for (int i = 0; i < gvDeposits.Rows.Count; i++)
                {
                    if ((((CheckBox)gvDeposits.Rows[i].FindControl("chkGvSelect"))).Checked)
                    {
                        Guid depositBookID = new Guid(Convert.ToString(gvDeposits.DataKeys[i]["BookID"]));
                        decimal dcmlAmount = Convert.ToDecimal(((Label)gvDeposits.Rows[i].FindControl("lblAmount")).Text);

                        Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                        Guid? CounterID = clsSession.DefaultCounterID;//// null;

                        if (Zone_TermID == 0)
                        {
                            DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                            if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                                Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);
                        }

                        TransactionBLL.TransferDeposit(depositBookID, Zone_TermID, dcmlAmount, DepositAcctID, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "TRANSFER ROOM DEPOSIT", clsSession.CompanyID);
                    }
                }

                BindDepostsToProcess();
                BindAmountSummary();

                
                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkViewUnpostedTransDetail_OnClick(object sender, EventArgs e)
        {
            if (mvUnpostedTransactions.ActiveViewIndex == 0)
            {
                lnkViewUnpostedTransDetail.Text = "Back";
                mvUnpostedTransactions.ActiveViewIndex = 1;
            }
            else
            {
                lnkViewUnpostedTransDetail.Text = "View Detail";
                mvUnpostedTransactions.ActiveViewIndex = 0;
            }
        }

        protected void btnPostCheckedUnpostedCharges_Click(object sender, EventArgs e)
        {
            try
            {
                int Zone_TermID = 0;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                for (int i = 0; i < gvPostChargesGrid.Rows.Count; i++)
                {
                    if ((((CheckBox)gvPostChargesGrid.Rows[i].FindControl("chkGvSelect"))).Checked)
                    {
                        Guid? ResBlockDateRateID = null;
                        Guid? ResServiceID = null;

                        if (gvPostChargesGrid.DataKeys[i]["ResBlockDateRateID"] != null && Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResBlockDateRateID"]) != string.Empty)
                            ResBlockDateRateID = new Guid(Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResBlockDateRateID"]));

                        if (gvPostChargesGrid.DataKeys[i]["ResServiceID"] != null && Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResServiceID"]) != string.Empty)
                            ResServiceID = new Guid(Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResServiceID"]));


                        DateTime dtPostDate = DateTime.ParseExact(((Label)gvPostChargesGrid.Rows[i].FindControl("lblServiceDate")).Text.Trim(), clsSession.DateFormat, objCultureInfo);

                        Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                        Guid? CounterID = clsSession.DefaultCounterID;//// null;

                        if (Zone_TermID == 0)
                        {
                            DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                            if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                                Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);
                        }

                        decimal dcmlAmount = Convert.ToDecimal("0.000000");
                        if (ResBlockDateRateID != null && Convert.ToString(ResBlockDateRateID) != Guid.Empty.ToString())
                        {
                            if (Convert.ToString(gvPostChargesGrid.DataKeys[i]["RateCardRate"]) != string.Empty)
                                dcmlAmount = Convert.ToDecimal(Convert.ToString(gvPostChargesGrid.DataKeys[i]["RateCardRate"]));

                            TransactionBLL.PostRoomCharge(dtPostDate, this.ReservationID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlAmount, clsSession.CompanyID);
                        }
                        else
                        {
                            dcmlAmount = Convert.ToDecimal(((Label)gvPostChargesGrid.Rows[i].FindControl("lblAmount")).Text);
                            ResServiceList bojResService = ResServiceListBLL.GetByPrimaryKey((Guid)ResServiceID);
                            TransactionBLL.ItemPosting(bojResService.ItemID, bojResService.Amount, Convert.ToInt32(bojResService.Qty), this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", Zone_TermID, null, null, ResServiceID, null, dcmlAmount, clsSession.CompanyID);
                        }
                    }
                }

                BindUnPostedChargesGird();
                BindAmountSummary();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPostTodaysCharge_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet dsUnPostedCharges = ReservationBLL.GetAllUnpostedCharges(this.ReservationID, null, false);
                if (dsUnPostedCharges != null && dsUnPostedCharges.Tables[0].Rows.Count > 0)
                {
                    DataView dvUnPostedCharges = new DataView(dsUnPostedCharges.Tables[0]);
                    dvUnPostedCharges.RowFilter = "ServiceDate = '" + DateTime.Today.ToString("MM-dd-yyyy") + "'";

                    if (dvUnPostedCharges.Count > 0)
                    {
                        int Zone_TermID = 0;
                        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                        for (int i = 0; i < dvUnPostedCharges.Count; i++)
                        {
                            Guid? ResBlockDateRateID = null;
                            Guid? ResServiceID = null;

                            if (dvUnPostedCharges[i]["ResBlockDateRateID"] != null && Convert.ToString(dvUnPostedCharges[i]["ResBlockDateRateID"]) != string.Empty)
                                ResBlockDateRateID = new Guid(Convert.ToString(dvUnPostedCharges[i]["ResBlockDateRateID"]));

                            if (dvUnPostedCharges[i]["ResServiceID"] != null && Convert.ToString(dvUnPostedCharges[i]["ResServiceID"]) != string.Empty)
                                ResServiceID = new Guid(Convert.ToString(dvUnPostedCharges[i]["ResServiceID"]));

                            DateTime dtPostDate = DateTime.Today; //DateTime.ParseExact(Convert.ToString(dvUnPostedCharges[i]["ServiceDate"]), "MM-dd-yyyy", objCultureInfo);

                            Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                            Guid? CounterID = clsSession.DefaultCounterID;//// null;

                            decimal dcmlAmount = Convert.ToDecimal("0.000000");
                            if (ResBlockDateRateID != null && Convert.ToString(ResBlockDateRateID) != Guid.Empty.ToString())
                            {
                                if (Convert.ToString(dvUnPostedCharges[i]["Amount"]) != string.Empty)
                                    dcmlAmount = Convert.ToDecimal(Convert.ToString(dvUnPostedCharges[i]["Amount"]));

                                TransactionBLL.PostRoomCharge(dtPostDate, this.ReservationID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlAmount, clsSession.CompanyID);
                            }
                            else
                            {
                                if (Zone_TermID == 0)
                                {
                                    DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                                    if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                                        Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);
                                }

                                dcmlAmount = Convert.ToDecimal(dvUnPostedCharges[i]["Amount"]);
                                ResServiceList bojResService = ResServiceListBLL.GetByPrimaryKey((Guid)ResServiceID);
                                TransactionBLL.ItemPosting(bojResService.ItemID, bojResService.Amount, Convert.ToInt32(bojResService.Qty), this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", Zone_TermID, null, null, ResServiceID, null, dcmlAmount, clsSession.CompanyID);
                            }
                        }
                    }
                }

                this.IsTodaysChargePost = true;
                BindUnPostedChargesGird();
                //BindAllFolioChargesGrid();
                BindAmountSummary();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancelPostTodaysCharge_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.IsTodaysChargePost = true;
                BindUnPostedChargesGird();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnApplyEarlyCheckOutCharge_OnClick(object sender, EventArgs e)
        {
            try
            {
                Guid? ChargeAccountID = null; //new Guid("591FA4FD-C3D5-4480-A63C-412D42E6421A");

                DataSet dsRetentionAcctID = ReservationConfigBLL.SelectRetentionAccountID(clsSession.PropertyID);
                if (dsRetentionAcctID != null && dsRetentionAcctID.Tables[0].Rows.Count > 0 && dsRetentionAcctID.Tables[0].Rows[0]["RetentionChargeAccountID"] != null)
                {
                    ChargeAccountID = new Guid(Convert.ToString(dsRetentionAcctID.Tables[0].Rows[0]["RetentionChargeAccountID"]));

                    FolioBLL.FolioQuickPostInAccount(ChargeAccountID, null, Convert.ToDecimal(ltrUnpostedChargesEarlyCheckOutCharge.Text.Trim()), 40, this.ReservationID, this.ReservationFolioID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, null, null, Convert.ToDecimal(ltrUnpostedChargesEarlyCheckOutCharge.Text.Trim()), clsSession.CompanyID);

                    BlockDateRateBLL.DeleteUnPostedTransByReservationID(this.ReservationID);

                    BindUnPostedChargesGird();
                    BindAmountSummary();
                    //BindAllFolioChargesGrid();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Retention Charge AccountID is not configured. please try again after configuring it.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnDeleteCheckedUnpostedCharges_Click(object sender, EventArgs e)
        {
            try
            {
                //CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                for (int i = 0; i < gvPostChargesGrid.Rows.Count; i++)
                {
                    if ((((CheckBox)gvPostChargesGrid.Rows[i].FindControl("chkGvSelect"))).Checked)
                    {
                        Guid? ResBlockDateRateID = null;
                        Guid? ResServiceID = null;

                        if (gvPostChargesGrid.DataKeys[i]["ResBlockDateRateID"] != null && Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResBlockDateRateID"]) != string.Empty)
                            ResBlockDateRateID = new Guid(Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResBlockDateRateID"]));

                        if (gvPostChargesGrid.DataKeys[i]["ResServiceID"] != null && Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResServiceID"]) != string.Empty)
                            ResServiceID = new Guid(Convert.ToString(gvPostChargesGrid.DataKeys[i]["ResServiceID"]));

                        if (ResBlockDateRateID != null && Convert.ToString(ResBlockDateRateID) != Guid.Empty.ToString())
                        {
                            BlockDateRateBLL.Delete((Guid)ResBlockDateRateID);
                        }
                        else
                        {
                            ResServiceListBLL.Delete((Guid)ResServiceID);
                        }
                    }
                }

                BindUnPostedChargesGird();
                BindAmountSummary();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnRefundAmount_OnClick(object sender, EventArgs e)
        {
            this.strRefundOrPayment = "REFUND";
            txtAmountToRefund.Text = lblAmountRefundOrPayment.Text;
            trRefund.Visible = true;
            trCheckoutVoucher.Visible = true;
            btnRefundAmount.Visible = false;

            ddlRefundPaymentMOP.Items.Clear();
            List<ProjectTerm> lstModeOfPayment = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
            if (lstModeOfPayment.Count != 0)
            {
                ddlRefundPaymentMOP.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                int i = 1;
                foreach (ProjectTerm pTerm in lstModeOfPayment)
                {
                    if (pTerm.Term.ToString().ToUpper() == "CASH" || pTerm.Term.ToString().ToUpper() == "CHEQUE")
                    {
                        ddlRefundPaymentMOP.Items.Insert(i, new ListItem(pTerm.Term.ToString(), pTerm.TermID.ToString()));
                        i++;
                    }
                }
            }
            else
                ddlRefundPaymentMOP.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
        }

        protected void btnProceedRefund_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtAmountToRefund.Text.Trim() != string.Empty && Convert.ToDecimal(txtAmountToRefund.Text.Trim()) > 0)
                {
                    DataSet dsMaxCashLimit = ReservationConfigBLL.GetMaxCashLimitForRefund(clsSession.CompanyID, clsSession.PropertyID);
                    if (dsMaxCashLimit != null && dsMaxCashLimit.Tables.Count > 0)
                    {
                        if (ddlRefundPaymentMOP.SelectedValue == Convert.ToString(dsMaxCashLimit.Tables[0].Rows[0]["TermID"]))
                        {
                            if (dsMaxCashLimit.Tables.Count > 1)
                            {
                                decimal dcmlMaxCashLimitForRefund = Convert.ToDecimal(dsMaxCashLimit.Tables[1].Rows[0]["MaxCashLimitForRefund"].ToString());
                                if (txtAmountToRefund.Text.Trim() != string.Empty && Convert.ToDecimal(txtAmountToRefund.Text.Trim()) > dcmlMaxCashLimitForRefund)
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                    MessageBox.Show("Refund amount by cash should be less than or equal to Rs. " + dcmlMaxCashLimitForRefund.ToString());
                                    return;
                                }
                            }
                        }
                    }

                    Guid? PaymentAcctID = null;
                    Guid? RefBookID = null;

                    if (ddlRefundPaymentLedger.Items.Count > 0)
                        PaymentAcctID = new Guid(ddlRefundPaymentLedger.SelectedValue);

                    Guid? CounterID = clsSession.DefaultCounterID;//// null;

                    decimal dcmlRefundAmount = Convert.ToDecimal(txtAmountToRefund.Text.Trim());
                    TransactionBLL.TransactionRefundPayment(PaymentAcctID, dcmlRefundAmount, this.ReservationID, this.ReservationFolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", null, RefBookID, clsSession.CompanyID);

                    ltrRefundedAmount.Text = Convert.ToString(Convert.ToDecimal(ltrRefundedAmount.Text) + dcmlRefundAmount);

                    txtAmountToRefund.Text = "0.00";
                    lblAmountRefundOrPayment.Text = "0.00";
                    btnProceedRefund.Visible = false;

                    ddlRefundPaymentMOP.SelectedIndex = 0;
                    trRefundPaymentLedger.Visible = trRefundPaymentBankName.Visible = trRefundPaymentChequeDDNo.Visible = ddlRefundPaymentMOP.Enabled = false;

                    btnCheckOutComplete.Visible = true;
                    //BindAllFolioChargesGrid();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Invalid refund amount, it must be greater than 0.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        } 

        protected void ddlRefundPaymentMOP_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRefundPaymentMOP.SelectedIndex != 0)
                {
                    ddlRefundPaymentLedger.Items.Clear();

                    DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlRefundPaymentMOP.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
                    if (dstLedgerAccounts != null && dstLedgerAccounts.Tables[0].Rows.Count > 0)
                    {
                        ddlRefundPaymentLedger.DataSource = dstLedgerAccounts.Tables[0];
                        ddlRefundPaymentLedger.DataTextField = "AcctName";
                        ddlRefundPaymentLedger.DataValueField = "AcctID";
                        ddlRefundPaymentLedger.DataBind();
                    }

                    trRefundPaymentLedger.Visible = true;
                }
                else
                {
                    ddlRefundPaymentLedger.Items.Clear();
                    trRefundPaymentLedger.Visible = false;
                }

                rfvRefundPaymentBankName.Enabled = rfvRefundPaymentChequeDDNo.Enabled = trRefundPaymentBankName.Visible = trRefundPaymentChequeDDNo.Visible = false;
                if (ddlRefundPaymentMOP.SelectedIndex != 0)
                {
                    ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlRefundPaymentMOP.SelectedValue));

                    if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
                    {
                        trRefundPaymentBankName.Visible = trRefundPaymentChequeDDNo.Visible = true;
                        rfvRefundPaymentBankName.Enabled = rfvRefundPaymentChequeDDNo.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlRefundDepositMOP_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ddlRefundDepositMOP.SelectedIndex != 0)
            //    {
            //        ddlRefundDepositLedgerAcct.Items.Clear();

            //        DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlRefundDepositMOP.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
            //        if (dstLedgerAccounts != null && dstLedgerAccounts.Tables[0].Rows.Count > 0)
            //        {
            //            ddlRefundDepositLedgerAcct.DataSource = dstLedgerAccounts.Tables[0];
            //            ddlRefundDepositLedgerAcct.DataTextField = "AcctName";
            //            ddlRefundDepositLedgerAcct.DataValueField = "AcctID";
            //            ddlRefundDepositLedgerAcct.DataBind();
            //        }

            //        trRefundDepoistLedgerAccount.Visible = true;
            //    }
            //    else
            //    {
            //        ddlRefundDepositLedgerAcct.Items.Clear();
            //        trRefundDepoistLedgerAccount.Visible = false;
            //    }

            //    rfvRefundDepositBankName.Enabled = rfvRefundDepositChequeDDno.Enabled = trRefundDepositBankName.Visible = trRefundDepositChequeDDNo.Visible = false;
            //    if (ddlRefundDepositMOP.SelectedIndex != 0)
            //    {
            //        ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlRefundDepositMOP.SelectedValue));

            //        if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
            //        {
            //            trRefundDepositBankName.Visible = trRefundDepositChequeDDNo.Visible = true;
            //            rfvRefundDepositBankName.Enabled = rfvRefundDepositChequeDDno.Enabled = true;
            //        }
            //    }

            //    mpeMOPforRefundDeposit.Show();
            //}
            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }


        protected void btnCheckOutBack_OnClick(object sender, EventArgs e)
        {
            //mvCheckOut.ActiveViewIndex = 0;
            Response.Redirect("~/GUI/Billing/DepartureList.aspx");
        }

        protected void btnCheckOutComplete_OnClick(object sender, EventArgs e)
        {
            try
            {
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationToUpdate = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                objReservationToUpdate.RestStatus_TermID = 33;
                objReservationToUpdate.ActualCheckOutDate = DateTime.Now;
                objReservationToUpdate.UpdatedBy = clsSession.UserID;
                objReservationToUpdate.UpdatedOn = DateTime.Now;
                objReservationToUpdate.UpdateMode = "RESERVATION CHECKOUT";
                ReservationBLL.Update(objReservationToUpdate);

                //Start  Un Block Room For Complementory reservation and Premature check out


                ////If Complementory reservation is there and it's ref. type is Investor
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                if (Convert.ToDateTime(objReservation.CheckOutDate).Date > Convert.ToDateTime(objReservation.ActualCheckOutDate).Date && objReservation.IsComplimentoryReservation != null && objReservation.IsComplimentoryReservation == true)
                {
                    RoomBlockBLL.DeleteForComplementoryReservation((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID);
                }

                if (objReservation.IsComplimentoryReservation == true && objReservation.RefInvestorID != null && Convert.ToString(objReservation.RefInvestorID) != string.Empty && Convert.ToString(objReservation.RefInvestorID) != Guid.Empty.ToString())
                {
                    ////To update IR's Voucher and change its status
                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();
                    clnt.Update_ReservationAndAllocatedRoomID(Guid.NewGuid(), objReservation.ReservationID, objReservation.RoomID, "CHECKOUTCOMPLETE");
                }


                // End  Un Block Room For Complementory reservation and Premature check out
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolio = FolioBLL.GetByPrimaryKey(this.ReservationFolioID);
                objFolio.FolioStatus = "CHECK_OUT";
                objFolio.UpdatedOn = DateTime.Now;

                FolioBLL.Update(objFolio);

                //ucCheckOutVoucher.BindVoucherData(this.ReservationID, this.ReservationFolioID, this.dcmlTotalAmountRefundOrPayment, this.strRefundOrPayment, "Cash");
                //mpeCheckOutVoucher.Show();
                btnCheckOutComplete.Visible = false;
                btnPrintBill.Visible = rdoDetail.Visible = rdoSummary.Visible = true;
                //btnPrintBill_OnClick(sender, e);

                // To Check Billing Instruction status 

                DataSet dsForCheckBillingInstruction = ReservationBLL.GetBillingInstructionTermStatus(this.ReservationID, clsSession.CompanyID, clsSession.PropertyID, false);
                if (dsForCheckBillingInstruction != null && dsForCheckBillingInstruction.Tables.Count > 0 && dsForCheckBillingInstruction.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsForCheckBillingInstruction.Tables[0].Rows[0]["NoOfRecord"]) > 0)
                {
                    trCompBillPrint.Visible = true;
                    btnCmpBillPrint.Visible = true;
                    btnPrintBill.Visible = false;

                }
                else
                {
                    trCompBillPrint.Visible = false;
                    btnCmpBillPrint.Visible = false;
                }


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPrintBill_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.IsPreview = false;
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolio = FolioBLL.GetByPrimaryKey(this.ReservationFolioID);
                btnCheckOutComplete.Visible = false;
                DataSet ds = new DataSet();
                if (rdoDetail.Checked)
                    ds = InvoiceBLL.GetRPTInvoiceBillDetail(this.ReservationID, objFolio.FolioID);
                else if (rdoSummary.Checked)
                {
                    DataSet dsMain = InvoiceBLL.GetRPTInvoiceReservationDetail(null, this.ReservationID, objFolio.FolioID);
                    DataSet dsDetail = InvoiceBLL.GetRPTInvoiceBillSummary(this.ReservationID, objFolio.FolioID);
                    DataTable MainDS = dsMain.Tables[0].Copy();
                    MainDS.Merge(dsDetail.Tables[0], true);
                    ds.Tables.Add(MainDS);
                }

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[i]["GeneralIDType_Term"]).ToUpper() == "RETENTION CHARGE" && Convert.ToString(ds.Tables[0].Rows[i]["Charge"]) == "0.00" && Convert.ToString(ds.Tables[0].Rows[i]["Credit"]) == "0.00")
                        {
                            ds.Tables[0].Rows.RemoveAt(i);
                        }
                    }
                }

                Session["RptResID"] = this.ReservationID;
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }


        protected void iBtnCloseCounter_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Billing/DepartureList.aspx");
        }

        protected void btnCounterErrorMessageOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Billing/DepartureList.aspx");
        }

        protected void btnPrintInvoice_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.strBillingFromDate != string.Empty && this.strBillingToDate != string.Empty)
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Invoice objToInsert = new BusinessLogic.FrontDesk.DTO.Invoice();
                    objToInsert.ReservationID = this.ReservationID;
                    objToInsert.FolioID = this.ReservationFolioID;
                    objToInsert.CustomerID = objToInsert.GuestID = this.GuestID;
                    objToInsert.AgentID = this.AgentID;
                    objToInsert.InvoiceDate = DateTime.Now;
                    objToInsert.Amt = this.BillingAmount;
                    objToInsert.IsPaid = false;

                    objToInsert.TransactionOrigin_TermID = 40;
                    objToInsert.CompanyID = clsSession.CompanyID;
                    objToInsert.PropertyID = clsSession.PropertyID;
                    objToInsert.IsPrinted = true;
                    objToInsert.PrintedOn = DateTime.Now;
                    objToInsert.IsLocked = false;
                    objToInsert.IsVoid = false;
                    objToInsert.IsActive = true;
                    objToInsert.IsDiscInPercentage = objToInsert.IsSynch = objToInsert.IsDiscount = false;

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime dtFromDate = DateTime.Today;
                    DateTime dtToDate = DateTime.Today;

                    if (this.strBillingFromDate != "")
                        dtFromDate = Convert.ToDateTime(this.strBillingFromDate); //DateTime.ParseExact(this.strBillingFromDate, clsSession.DateFormat, objCultureInfo);
                    if (this.strBillingToDate != "")
                        dtToDate = Convert.ToDateTime(this.strBillingToDate); //DateTime.ParseExact(this.strBillingToDate, clsSession.DateFormat, objCultureInfo);

                    InvoiceBLL.Save(objToInsert, dtFromDate, dtToDate);

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Invoice objToselect = new BusinessLogic.FrontDesk.DTO.Invoice();
                    objToselect = InvoiceBLL.GetByPrimaryKey(objToInsert.InvoiceID);


                    Session["InvoiceNoToPrint"] = Convert.ToString(objToselect.InvoiceNo);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnCompanyInvoicePrint();", true);



                }
                else
                {
                    MessageBox.Show("Invalide Date period.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnCmpBillPrint_Click(object sender, EventArgs e)
        {
            DateTime dtFromDate = DateTime.Today;
            DateTime dtToDate = DateTime.Today;
            Guid? BillingInstrID = null;
            hdnReservationID.Value = Convert.ToString(this.ReservationID);
            DataSet dsForInvoiceRecord = ReservationBLL.GetReservation4CompanyInvoice(dtFromDate, dtToDate, this.ReservationID, null, clsSession.PropertyID, clsSession.CompanyID, BillingInstrID);
            if (dsForInvoiceRecord != null && dsForInvoiceRecord.Tables.Count > 0 && dsForInvoiceRecord.Tables[0].Rows.Count > 0)
            {

                hdnReservationID.Value = this.ReservationID.ToString();
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnCompanyInvoicePrint();", true);
                
            }
        }


        #endregion  Control Event

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CheckOut.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }

        private void BindPropertyAddress()
        {
            DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
            ltrUniworldAddress.Text = "";
            if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
            {
                ltrUniworldAddress.Text = dsPropertyAddress.Tables[0].Rows[0]["FullAddress"].ToString();
            }
            else
            {
                ltrUniworldAddress.Text = "";
            }
        }

        private void LoadDataOnPageLoadEvent()
        {
            if (Request.QueryString["PostCharges"] != null)
            {
                mvCheckOut.ActiveViewIndex = 0;
                BindUnPostedChargesGird();
            }

            if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "CHECKOUT RESERVATION")
            {
                this.ReservationID = clsSession.ToEditItemID;
                hdnReservationID.Value = Convert.ToString(this.ReservationID);
                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = string.Empty;
                BindCheckOutData();
            }


        }

        public void BindAllFolioChargesGrid()
        {
            try
            {

                DataSet dsTransaction = TransactionBLL.GetAllTransaction(this.ReservationID, this.ReservationFolioID, null, null, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransaction != null && dsTransaction.Tables.Count > 0 && dsTransaction.Tables[0].Rows.Count > 0)
                {
                    DataView dvTransaction = new DataView(dsTransaction.Tables[0]);

                    bool isvoid = false;
                    dvTransaction.RowFilter = "IsVoid = '" + isvoid + "' and IsOverride = 0";


                    if (dvTransaction.Count > 0)
                    {
                        dcmlftCharge = (decimal)dsTransaction.Tables[0].Compute("sum(CR_AMOUNT)", "IsVoid = '" + isvoid + "' and IsOverride = 0");
                        dcmlftPayment = (decimal)dsTransaction.Tables[0].Compute("sum(DB_AMOUNT)", "IsVoid = '" + isvoid + "' and IsOverride = 0");

                        decimal dcAllCharges = Convert.ToDecimal("0.000000");
                        dcAllCharges = dcmlftPayment - dcmlftCharge;

                        //dvTransaction.Sort = "EntryDate desc";
                        //gvFolioDetails.DataSource = dvTransaction;
                        //gvFolioDetails.DataBind();
                    }
                    else
                    {
                        //gvFolioDetails.DataSource = null;
                        //gvFolioDetails.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindCheckOutData()
        {
            try
            {
                mvCheckOut.ActiveViewIndex = 0;
                GetReservationInfo();
                BindUnPostedChargesGird();
                //BindAllFolioChargesGrid();
                BindDepostsToProcess();

                BindAmountSummary();
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
                decimal DueBalanceAmount = Convert.ToDecimal("0.000000");
                decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                DataTable dtPaidAmountInfo = null;

                clsCommon.GetReservationPaymentInfo(this.ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                string strRoomRent, strTax, strTotalAmount, strDepositAmount, strTotalAmountPayable, strTotalAmountReceived = "";

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

                lblTotalAmountPayable.Text = lblDisplayAmount.Text = Convert.ToString(strTotalAmountPayable);

                strTotalAmountReceived = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                lblDisplayTotalAmountReceived.Text = Convert.ToString(strTotalAmountReceived);

                if (TotalAmountPayable > TotalPaymentReceived)
                {
                    DueBalanceAmount = TotalAmountPayable - TotalPaymentReceived;
                    lblDisplayBalanceAmountDueOrCredit.Text = "Due";
                }
                else
                {
                    DueBalanceAmount = TotalPaymentReceived - TotalAmountPayable;
                    lblDisplayBalanceAmountDueOrCredit.Text = "Credit";
                }
                lblDisplayBalanceAmount.Text = DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GetReservationInfo()
        {
            //// Todo --> To get Guest's Detail also.
            DataSet dsCheckOutInfo = ReservationBLL.GetCheckOutVoucherData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
            if (dsCheckOutInfo != null && dsCheckOutInfo.Tables.Count > 0)
            {
                this.ReservationFolioID = new Guid(dsCheckOutInfo.Tables[0].Rows[0]["FolioID"].ToString());
                this.RoomID = new Guid(dsCheckOutInfo.Tables[0].Rows[0]["RoomID"].ToString());
                this.GuestID = new Guid(dsCheckOutInfo.Tables[0].Rows[0]["GuestID"].ToString());
                ltrChkPmtGuestName.Text = Convert.ToString(dsCheckOutInfo.Tables[0].Rows[0]["GuestFullName"]);

                if (Convert.ToString(dsCheckOutInfo.Tables[0].Rows[0]["CheckOutNote"]).Trim() != string.Empty)
                {
                    trCheckOutNote.Visible = true;
                    lblCheckOutNote.Text = Convert.ToString(dsCheckOutInfo.Tables[0].Rows[0]["CheckOutNote"]);
                }
            }

            DataSet dsRservationData = ReservationBLL.GetResrvationViewData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);
            if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsRservationData.Tables[0].Rows[0];

                litDisplayFolioNo.Text = Convert.ToString(dr["ReservationNo"]);
                DateTime CheckinDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                litDisplayArrivalDate.Text = Convert.ToString(CheckinDate.ToString(clsSession.DateFormat));
                DateTime CheckoutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));
                litDisplayDepatureDate.Text = Convert.ToString(CheckoutDate.ToString(clsSession.DateFormat));

                litDisplayUnitNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));
                lblFolioDetailsDisplayGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                lblFolioDetailsDisplayMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                lblFolioDetailsDisplayEmail.Text = Convert.ToString(dr["Email"]);
                litDisplayRoomType.Text = Convert.ToString(dr["RoomTypeName"]);

                litDisplayRateCard.Text = Convert.ToString(dr["RateCardName"]);
            }
        }

        private void BindAmountSummary()
        {
            DataSet dsSummary = FolioBLL.GetCheckOutTimeSummary(this.ReservationID, this.ReservationFolioID, clsSession.PropertyID, clsSession.CompanyID);
            if (dsSummary != null && dsSummary.Tables.Count > 0 && dsSummary.Tables[0].Rows.Count > 0)
            {
                decimal dcmlPayment = Convert.ToDecimal("0.000000");
                decimal dcmlRefundedPayment = Convert.ToDecimal("0.000000");
                decimal dcmlRefundedDeposit = Convert.ToDecimal("0.000000");
                decimal dcmlTransferedDeposit = Convert.ToDecimal("0.000000");
                for (int i = 0; i < dsSummary.Tables[0].Rows.Count; i++)
                {
                    decimal dcmlTemp = Convert.ToDecimal("0.000000");
                    DataRow dr = dsSummary.Tables[0].Rows[i];
                    if (Convert.ToString(dr["Description1"]).ToUpper() == "ROOM RENT")
                    {
                        if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                        {
                            dcmlTemp = Convert.ToDecimal(dr["Debit"].ToString());
                            lblSmryRoomRentDebit.Text = dcmlTemp.ToString().Substring(0, dcmlTemp.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else
                            lblSmryRoomRentDebit.Text = "0.00";
                    }
                    else if (Convert.ToString(dr["Description1"]).ToUpper() == "SERVICE CHARGE")
                    {
                        if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                        {
                            dcmlTemp = Convert.ToDecimal(dr["Debit"].ToString());
                            lblSmryServicesChargeDebit.Text = dcmlTemp.ToString().Substring(0, dcmlTemp.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else
                            lblSmryServicesChargeDebit.Text = "0.00";
                    }
                    else if (Convert.ToString(dr["Description1"]).ToUpper() == "PAYMENT")
                    {
                        if (dr["Credit"] != null && Convert.ToString(dr["Credit"]) != "")
                            dcmlPayment = Convert.ToDecimal(dr["Credit"].ToString());
                    }
                    else if (Convert.ToString(dr["Description1"]).ToUpper() == "DEPOSIT")
                    {
                        if (dr["Credit"] != null && Convert.ToString(dr["Credit"]) != "")
                        {
                            decimal dcmlDebitDeposit = Convert.ToDecimal("0.000000");
                            if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                            {
                                dcmlDebitDeposit = Convert.ToDecimal(Convert.ToString(dr["Debit"]));
                            }

                            dcmlTemp = Convert.ToDecimal(dr["Credit"].ToString()) - dcmlDebitDeposit;
                            lblSmryDepositCredit.Text = dcmlTemp.ToString().Substring(0, dcmlTemp.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else
                            lblSmryDepositCredit.Text = "0.00";
                    }
                    else if (Convert.ToString(dr["Description1"]).ToUpper() == "REFUND PAYMENT")
                    {
                        if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                            dcmlRefundedPayment = Convert.ToDecimal(dr["Debit"].ToString());
                    }
                    else if (Convert.ToString(dr["Description1"]).ToUpper() == "REFUND DEPOSIT")
                    {
                        if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                            dcmlRefundedDeposit = Convert.ToDecimal(dr["Debit"].ToString());
                    }
                    else if (Convert.ToString(dr["Description1"]).ToUpper() == "DEPOSIT TRANSFER")
                    {
                        if (dr["Credit"] != null && Convert.ToString(dr["Credit"]) != "")
                            dcmlTransferedDeposit = Convert.ToDecimal(dr["Credit"].ToString());
                    }
                }

                //// Actual Payment = Paymend Amount + Transferred Amount ==> Transferred Amount = Total transfered Amount - Refunded Amount; b'cas Reunded Amount also make entry as transfered amount.
                decimal dcmlActualPayment = dcmlPayment + (dcmlTransferedDeposit - dcmlRefundedDeposit);
                lblSmryPaymentCredit.Text = dcmlActualPayment.ToString().Substring(0, dcmlActualPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                lblSmryTotalDebit.Text = Convert.ToString(Convert.ToDecimal(lblSmryRoomRentDebit.Text) + Convert.ToDecimal(lblSmryServicesChargeDebit.Text));
                lblSmryTotalCredit.Text = Convert.ToString(Convert.ToDecimal(lblSmryPaymentCredit.Text) + Convert.ToDecimal(lblSmryDepositCredit.Text));

                if (Convert.ToDecimal(lblSmryTotalDebit.Text) > Convert.ToDecimal(lblSmryTotalCredit.Text))
                {
                    lblAmountRefundOrPayment.Text = lblSmryNetBalanceAmount.Text = Convert.ToString(Convert.ToDecimal(lblSmryTotalDebit.Text) - Convert.ToDecimal(lblSmryTotalCredit.Text));
                    lblCreditOrDebitFinal.Text = lblSmryTotalDebitOrCredit.Text = "Due";
                }
                else
                {
                    lblAmountRefundOrPayment.Text = lblSmryNetBalanceAmount.Text = Convert.ToString(Convert.ToDecimal(lblSmryTotalCredit.Text) - Convert.ToDecimal(lblSmryTotalDebit.Text));
                    lblCreditOrDebitFinal.Text = lblSmryTotalDebitOrCredit.Text = "Credit";
                }

                if (gvDeposits.Rows.Count == 0 && gvPostChargesGrid.Rows.Count == 0)
                {
                    if (Convert.ToDecimal(lblAmountRefundOrPayment.Text) > 0)
                    {
                        if (lblCreditOrDebitFinal.Text == "Credit")
                            btnRefundAmount.Visible = true;
                        //else
                        //    btnTakePayment.Visible = true;
                    }
                    else
                    {
                        btnRefundAmount.Visible = false;
                        trCheckoutVoucher.Visible = btnCheckOutComplete.Visible = true;

                        //// If lblAmountRefundOrPayment is 0, then deposit must be refunded.
                        this.strRefundOrPayment = "REFUND";
                    }
                }


                //// Set Unprocessed Dposits button visibility based on Unposted Charges and Unposted Recovery.
                if (gvDeposits.Rows.Count > 0)// if Deposit grid has any record to process
                {
                    if (gvPostChargesGrid.Rows.Count == 0)// After UnpostedCharge Grid and Recovery Grid is empty, means both grids record are proceesed
                    {
                        // And Total Debit Amount is greater than Payment(excluding Deposits) then Deposit can be Transferred Only.
                        if (Convert.ToDecimal(lblSmryTotalDebit.Text) > dcmlActualPayment)
                        {
                            btnTransferCheckedDeposits.Visible = true;
                            //btnRefundCheckedDeposits.Visible = false;
                        }
                        else//Deposits can be Refund Only.
                        {
                            btnTransferCheckedDeposits.Visible = true;
                            //btnTransferCheckedDeposits.Visible = false;
                            //btnRefundCheckedDeposits.Visible = true;
                        }
                    }
                    else
                        btnTransferCheckedDeposits.Visible = false; // btnRefundCheckedDeposits.Visible = false;
                }
                else
                    btnTransferCheckedDeposits.Visible = false;// btnRefundCheckedDeposits.Visible = false;
            }
            else
            {
                lblAmountRefundOrPayment.Text = lblSmryRoomRentDebit.Text = lblSmryServicesChargeDebit.Text = lblSmryPaymentCredit.Text = lblSmryDepositCredit.Text = lblSmryNetBalanceAmount.Text = "0.00";
                lblSmryTotalDebitOrCredit.Text = "Credit";
            }
        }

        private void BindUnPostedChargesGird()
        {
            DataSet dsUnPostedCharges = ReservationBLL.GetAllUnpostedCharges(this.ReservationID, null, false);

            if (!IsTodaysChargePost)
            {
                if (dsUnPostedCharges != null && dsUnPostedCharges.Tables[0].Rows.Count > 0)
                {
                    DataView dvUnPostedCharges = new DataView(dsUnPostedCharges.Tables[0]);
                    dvUnPostedCharges.RowFilter = "ServiceDate = '" + DateTime.Today.ToString("MM-dd-yyyy") + "'";

                    if (dvUnPostedCharges.Count > 0)
                    {
                        mvUnpostedTransactions.ActiveViewIndex = 2;
                        lnkViewUnpostedTransDetail.Visible = btnApplyEarlyCheckOutCharge.Visible = false;
                        return;
                    }
                }
            }

            lnkViewUnpostedTransDetail.Visible = btnApplyEarlyCheckOutCharge.Visible = true;

            if (dsUnPostedCharges.Tables.Count > 0 && dsUnPostedCharges.Tables[0].Rows.Count > 0)
            {
                gvPostChargesGrid.DataSource = dsUnPostedCharges.Tables[0];
                gvPostChargesGrid.DataBind();
                //btnPostCheckedUnpostedCharges.Visible = btnDeleteCheckedUnpostedCharges.Visible = true;
                ltrUnPostedChargesSummary.Text = lblTotalUnpostedCharge.Text = dcmlTotalUnpostedCharge.ToString().Substring(0, dcmlTotalUnpostedCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                DataSet dsRetentionPercentage = ReservationBLL.SelectRetentionChargePercent(this.ReservationID);

                decimal dcmlRetentionCharge = Convert.ToDecimal("0.000000");
                if (dsRetentionPercentage != null && dsRetentionPercentage.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(dsRetentionPercentage.Tables[0].Rows[0]["retentionChargePercent"]) != string.Empty)
                        dcmlRetentionCharge = Convert.ToDecimal(dsRetentionPercentage.Tables[0].Rows[0]["retentionChargePercent"].ToString());
                }

                ltrUnPostedChargesToApplyInPercentage.Text = dcmlRetentionCharge.ToString();//.Substring(0, dcmlRetentionCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                decimal dcmlEarlyCheckOutCharge = Convert.ToDecimal("0.000000");
                dcmlEarlyCheckOutCharge = (dcmlTotalUnpostedCharge * dcmlRetentionCharge) / 100;

                if (Convert.ToString(dcmlEarlyCheckOutCharge) == "0")
                    ltrUnpostedChargesEarlyCheckOutCharge.Text = "0";
                else
                    ltrUnpostedChargesEarlyCheckOutCharge.Text = dcmlEarlyCheckOutCharge.ToString().Substring(0, dcmlEarlyCheckOutCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                mvUnpostedTransactions.ActiveViewIndex = 0;
            }
            else
            {
                gvPostChargesGrid.DataSource = null;
                gvPostChargesGrid.DataBind();
                //btnPostCheckedUnpostedCharges.Visible = btnDeleteCheckedUnpostedCharges.Visible = false;
                ltrUnpostedChargesEarlyCheckOutCharge.Text = ltrUnPostedChargesSummary.Text = lblTotalUnpostedCharge.Text = "0.00";
                lnkViewUnpostedTransDetail.Visible = btnApplyEarlyCheckOutCharge.Visible = false;
                mvUnpostedTransactions.ActiveViewIndex = 1;
            }

            //if (mvUnpostedTransactions.ActiveViewIndex != 1)
            //    mvUnpostedTransactions.ActiveViewIndex = 0;
        }

        private void BindDepostsToProcess()
        {
            DataSet dsDeposits = TransactionBLL.TransactionGetAllDeposit(this.ReservationID, false, clsSession.PropertyID, clsSession.CompanyID);

            DataTable tblDeposits = dsDeposits.Tables[0].Clone();
            if (dsDeposits.Tables.Count > 0 && dsDeposits.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dtRow in dsDeposits.Tables[0].Rows)
                {
                    if (dtRow["DUE AMOUNT"] != null)
                    {
                        if (Convert.ToDecimal(dtRow["DUE AMOUNT"].ToString()) > 0 && Convert.ToString(dtRow["GeneralIDType_Term"]) == "RESERVATION DEPOSIT")
                            tblDeposits.ImportRow(dtRow);
                    }
                }
            }

            if (tblDeposits.Rows.Count > 0)
            {
                gvDeposits.DataSource = tblDeposits;
                gvDeposits.DataBind();
                lblTotalDepositToProcess.Text = dcmlTotalDepositToProcess.ToString().Substring(0, dcmlTotalDepositToProcess.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }
            else
            {
                gvDeposits.DataSource = null;
                gvDeposits.DataBind();
                btnTransferCheckedDeposits.Visible = false;// btnRefundCheckedDeposits.Visible = false;
                lblTotalDepositToProcess.Text = "0.00";
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
            dr4["NameColumn"] = "Departure List";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Check Out";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
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

        protected void rdoDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDetail.Checked)
                Session.Add("ReportName", "Bill Format");
            else if (rdoSummary.Checked)
                Session.Add("ReportName", "Bill Summary");
        }
        #endregion  Private Method

        #region Grid Event
        protected void gvPostChargesGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    ((Label)e.Row.FindControl("lblServiceDate")).Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ServiceDate"))).ToString(clsSession.DateFormat);

                    string strAmount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount"));
                    ((Label)e.Row.FindControl("lblAmount")).Text = strAmount.Substring(0, strAmount.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    dcmlTotalUnpostedCharge = dcmlTotalUnpostedCharge + Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDeposits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    ((Label)e.Row.FindControl("lblEntryDate")).Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EntryDate"))).ToString(clsSession.DateFormat);

                    string strAmount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DUE AMOUNT"));
                    ((Label)e.Row.FindControl("lblAmount")).Text = strAmount.Substring(0, strAmount.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    dcmlTotalDepositToProcess = dcmlTotalDepositToProcess + Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    //((CheckBox)e.Row.FindControl("chkGvHdrSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkGvHdrSelectAll")).ClientID + "')");
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