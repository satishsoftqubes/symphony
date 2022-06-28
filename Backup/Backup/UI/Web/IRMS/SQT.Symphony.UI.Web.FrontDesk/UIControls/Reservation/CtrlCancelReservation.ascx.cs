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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlCancelReservation : System.Web.UI.UserControl
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

        public Guid ResPolicyID
        {
            get
            {
                return ViewState["ResPolicyID"] != null ? new Guid(Convert.ToString(ViewState["ResPolicyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResPolicyID"] = value;
            }
        }

        public Guid PaymentAcctID
        {
            get
            {
                return ViewState["PaymentAcctID"] != null ? new Guid(Convert.ToString(ViewState["PaymentAcctID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PaymentAcctID"] = value;
            }
        }

        //public bool IsApplyCancelCharge
        //{
        //    get
        //    {
        //        return ViewState["IsApplyCancelCharge"] != null ? Convert.ToBoolean(ViewState["IsApplyCancelCharge"]) : false;
        //    }
        //    set
        //    {
        //        ViewState["IsApplyCancelCharge"] = value;
        //    }
        //}

        #endregion

        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "CANCELRESERVATION")
                {
                    this.ReservationID = clsSession.ToEditItemID;
                    this.OperationRequestModeID = new Guid(Convert.ToString(Session["CancelOperationRequestModeID"]));
                    this.OperationRequestBy = Convert.ToString(Session["CancelOperationRequestBy"]);
                    this.SymphonyValue = Convert.ToInt32(Convert.ToString(Session["CancelSymphonyValue"]));

                    Session.Remove("CancelOperationRequestModeID");
                    Session.Remove("CancelOperationRequestBy");
                    Session.Remove("CancelSymphonyValue");

                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                }
                LoadDefaultValue();

            }
        }

        #endregion

        #region Control Events
        protected void btnCalculateCancellationCharge_OnClick(object sender, EventArgs e)
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                litDisplayCanCalCharCheckInDate.Text = Convert.ToString(litDisplayCheckInDate.Text.Trim());
                DateTime dtCurrentDate = DateTime.Today;
                DateTime dtCheckInDate = DateTime.ParseExact(litDisplayCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                litDisplayCanCalCharCancellationDate.Text = Convert.ToString(dtCurrentDate.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat));
                trCalculateCancellationCharge.Visible = true;
                litDisplayCanCalCharDaysbeforeCheckIn.Text = "";

                // Set Deposit amout which is required for confrim reservation.
                ltrDisplayChargeAppliedOnAmt.Text = lblDisplayDepositAmount.Text;

                decimal dcCancellationCharge = Convert.ToDecimal("0.000000");
                decimal dcNetBalance = Convert.ToDecimal("0.000000");

                ////decimal dcAmountPaid = Convert.ToDecimal(lblDisplayAmountPaid.Text.Trim());

                string str_AmountPaid = lblDisplayAmountPaid.Text.Trim().IndexOf('.') > -1 ? lblDisplayAmountPaid.Text.Trim() + "000000" : lblDisplayAmountPaid.Text.Trim() + ".000000";
                decimal dcAmountPaid = Convert.ToDecimal(str_AmountPaid);

                string str_DepositAmount = lblDisplayDepositAmount.Text.Trim().IndexOf('.') > -1 ? lblDisplayDepositAmount.Text.Trim() + "000000" : lblDisplayDepositAmount.Text.Trim() + ".000000";
                decimal dcDepositAmount = Convert.ToDecimal(str_DepositAmount);

                if (this.ResPolicyID != Guid.Empty)
                {
                    DataSet dsCancellationPolicy = ReservationBLL.GetCancellationPolicyAndGuestPayment(clsSession.PropertyID, clsSession.CompanyID, this.ReservationID, this.ResPolicyID);

                    if (dsCancellationPolicy.Tables.Count > 0 && dsCancellationPolicy.Tables[0].Rows.Count > 0)
                    {
                        int daysDiff = ((TimeSpan)(dtCheckInDate - dtCurrentDate)).Days;
                        //int daysDiff = (Convert.ToInt32(((dtCheckInDate) - (dtCurrentDate)).TotalDays));
                        litDisplayCanCalCharDaysbeforeCheckIn.Text = Convert.ToString(daysDiff);

                        if (this.SymphonyValue == 28)
                        {
                            if (daysDiff >= 0)
                            {
                                DataRow[] dr = dsCancellationPolicy.Tables[0].Select("ResPolicyID = '" + Convert.ToString(this.ResPolicyID) + "' and '" + daysDiff + "' >= MinDays and '" + daysDiff + "' <= MaxDays");
                                if (dr.Length > 0)
                                {
                                    string strCancellationCharges = Convert.ToString(dr[0]["CancellationCharges"]);
                                    string strIsFlatCharge = Convert.ToString(dr[0]["IsFlatCharge"]);

                                    if (strCancellationCharges != "" && strIsFlatCharge != "")
                                    {
                                        if (Convert.ToBoolean(strIsFlatCharge) == true)
                                        {
                                            dcCancellationCharge = Convert.ToDecimal(strCancellationCharges);
                                        }
                                        else if (Convert.ToBoolean(strIsFlatCharge) == false)
                                        {
                                            decimal dcmlAmoutToApplyCharge = Convert.ToDecimal("0.000000");
                                            if (dsCancellationPolicy.Tables[1] != null && dsCancellationPolicy.Tables[1].Rows.Count > 0)
                                            {
                                                //dcmlAmoutToApplyCharge = Convert.ToDecimal(Convert.ToString(dsCancellationPolicy.Tables[1].Rows[0]["GuestBalance"]));
                                                if (ltrDisplayChargeAppliedOnAmt.Text != string.Empty)
                                                    dcmlAmoutToApplyCharge = Convert.ToDecimal(ltrDisplayChargeAppliedOnAmt.Text);
                                            }

                                            decimal dcpercentage = Convert.ToDecimal(strCancellationCharges);
                                            dcCancellationCharge = Convert.ToDecimal((dcmlAmoutToApplyCharge * dcpercentage) / 100);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dcCancellationCharge = dcAmountPaid;
                            }

                            if (dsCancellationPolicy.Tables.Count > 2 && dsCancellationPolicy.Tables[2] != null && dsCancellationPolicy.Tables[2].Rows.Count > 0)
                            {
                                gvRefundDepositList.DataSource = dsCancellationPolicy.Tables[2];
                                gvRefundDepositList.DataBind();

                                decimal dcGvCancellationCharges = Convert.ToDecimal("0.000000");
                                dcGvCancellationCharges = Convert.ToDecimal(dcCancellationCharge);

                                for (int j = 0; j < dsCancellationPolicy.Tables[2].Rows.Count; j++)
                                {
                                    decimal dcDepositAmt = Convert.ToDecimal(Convert.ToString(dsCancellationPolicy.Tables[2].Rows[j]["Amount"]));
                                    decimal dcDispalyAmount = Convert.ToDecimal(Convert.ToString(dsCancellationPolicy.Tables[2].Rows[j]["Amount"]));
                                    decimal dcRefundAmount = Convert.ToDecimal("0.000000");

                                    Label lblGvAmount = (Label)gvRefundDepositList.Rows[j].FindControl("lblGvAmount");
                                    Label lblGvRefund = (Label)gvRefundDepositList.Rows[j].FindControl("lblGvRefund");

                                    if (dcGvCancellationCharges > 0)
                                    {
                                        if (dcDepositAmt >= dcGvCancellationCharges)
                                        {
                                            dcRefundAmount = Convert.ToDecimal(dcDepositAmt - dcGvCancellationCharges);
                                            dcGvCancellationCharges = Convert.ToDecimal("0.000000");
                                        }
                                        else
                                        {
                                            dcRefundAmount = Convert.ToDecimal("0.000000");
                                            dcGvCancellationCharges = dcGvCancellationCharges - dcDepositAmt;
                                        }
                                    }
                                    else
                                    {
                                        dcRefundAmount = dcDepositAmt;
                                    }

                                    lblGvAmount.Text = dcDispalyAmount.ToString().Substring(0, dcDispalyAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                                    lblGvRefund.Text = dcRefundAmount.ToString().Substring(0, dcRefundAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                                }
                            }
                            else
                            {
                                gvRefundDepositList.DataSource = null;
                                gvRefundDepositList.DataBind();
                            }
                        }
                        else
                        {
                            if (dsCancellationPolicy.Tables.Count > 2 && dsCancellationPolicy.Tables[2] != null && dsCancellationPolicy.Tables[2].Rows.Count > 0)
                            {
                                if (daysDiff < 0)
                                    dcCancellationCharge = dcAmountPaid;

                                gvRefundDepositList.DataSource = dsCancellationPolicy.Tables[2];
                                gvRefundDepositList.DataBind();

                                for (int k = 0; k < dsCancellationPolicy.Tables[2].Rows.Count; k++)
                                {
                                    Label lblGvAmount = (Label)gvRefundDepositList.Rows[k].FindControl("lblGvAmount");
                                    Label lblGvRefund = (Label)gvRefundDepositList.Rows[k].FindControl("lblGvRefund");

                                    decimal dcDispalyAmount = Convert.ToDecimal(Convert.ToString(dsCancellationPolicy.Tables[2].Rows[k]["Amount"]));

                                    lblGvAmount.Text = dcDispalyAmount.ToString().Substring(0, dcDispalyAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                                    ////if cancel request date is after check in date, then take whole payment as cancellation charge and refund amount to 0
                                    if (daysDiff < 0)
                                        lblGvRefund.Text = "0.00";
                                    else //// this is not confirm reservation and reservation cancel before or on check in date, so refund whole payment.
                                        lblGvRefund.Text = lblGvAmount.Text;
                                }
                            }
                            else
                            {
                                gvRefundDepositList.DataSource = null;
                                gvRefundDepositList.DataBind();
                            }
                        }

                        if (dsCancellationPolicy.Tables.Count > 3 && dsCancellationPolicy.Tables[3] != null && dsCancellationPolicy.Tables[3].Rows.Count > 0)
                        {
                            this.PaymentAcctID = new Guid(Convert.ToString(dsCancellationPolicy.Tables[3].Rows[0]["AcctID"]));
                        }
                    }
                }

                if (gvRefundDepositList.Rows.Count > 0)
                {
                    if (dcAmountPaid > dcCancellationCharge)
                    {
                        ddlRefundDepositLedgerAcct.Items.Clear();
                        trRefundDepoistLedgerAccount.Visible = trRefundDepositBankName.Visible = trRefundDepositChequeDDNo.Visible = false;
                        trModeOfRefund.Visible = true;
                        BindModeOfRefundDDL();
                        rfvRefundDepositMOP.Enabled = true;
                    }
                }

                litDisplayCancellationCharge.Text = Convert.ToString(dcCancellationCharge.ToString().Substring(0, dcCancellationCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                dcNetBalance = dcAmountPaid - dcCancellationCharge;
                litDisplayNetBalance.Text = Convert.ToString(dcNetBalance.ToString().Substring(0, dcNetBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                trRefund.Visible = true;
                btnCancelReservation.Visible = true;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/CancelReservationList.aspx");
        }

        protected void btnCancelReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty)
                {

                    if (trModeOfRefund.Visible)
                    {
                        DataSet dsMaxCashLimit = ReservationConfigBLL.GetMaxCashLimitForRefund(clsSession.CompanyID, clsSession.PropertyID);
                        if (dsMaxCashLimit != null && dsMaxCashLimit.Tables.Count > 0)
                        {
                            if (ddlRefundDepositMOP.SelectedValue == Convert.ToString(dsMaxCashLimit.Tables[0].Rows[0]["TermID"]))
                            {
                                if (dsMaxCashLimit.Tables.Count > 1)
                                {
                                    decimal dcmlMaxCashLimitForRefund = Convert.ToDecimal(dsMaxCashLimit.Tables[1].Rows[0]["MaxCashLimitForRefund"].ToString());
                                    if (litDisplayNetBalance.Text.Trim() != string.Empty && Convert.ToDecimal(litDisplayNetBalance.Text.Trim()) > dcmlMaxCashLimitForRefund)
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                        MessageBox.Show("Refund amount by cash should be less than or equal to Rs. " + dcmlMaxCashLimitForRefund.ToString());
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();
                    objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                    objReservation.UpdatedBy = clsSession.UserID;
                    objReservation.UpdatedOn = DateTime.Now;
                    objReservation.RestStatus_TermID = 34;
                    objReservation.RoomID = null;
                    objReservation.UpdateMode = "RESERVATION CANCEL";
                    ReservationHistory objToInsert = new ReservationHistory();
                    objToInsert.ReservationID = this.ReservationID;
                    objToInsert.Operation = clsCommon.GetUpperCaseText("Cancel");
                    objToInsert.OperationDate = DateTime.Now;
                    objToInsert.OperationBy = clsSession.UserID;
                    objToInsert.UserName = clsCommon.GetUpperCaseText(clsSession.UserName);
                    objToInsert.OldStatus_TermID = this.SymphonyValue;
                    objToInsert.NewStatus_TermID = 34;
                    objToInsert.CompanyID = clsSession.CompanyID;
                    objToInsert.PropertyID = clsSession.PropertyID;
                    objToInsert.OldRecord = objReservation.ToString();
                    objToInsert.OperationRequestBy = Convert.ToString(this.OperationRequestBy);
                    objToInsert.OperationRequestMode_TermID = this.OperationRequestModeID;

                    DataTable dt = new DataTable();

                    DataColumn dc1 = new DataColumn("DepositBookID");
                    DataColumn dc2 = new DataColumn("Zone_TermID");
                    DataColumn dc3 = new DataColumn("Amt");
                    DataColumn dc4 = new DataColumn("PaymentAcctID");
                    DataColumn dc5 = new DataColumn("DepositAcctID");
                    DataColumn dc6 = new DataColumn("ReservationID");
                    DataColumn dc7 = new DataColumn("FolioID");
                    DataColumn dc8 = new DataColumn("UserID");
                    DataColumn dc9 = new DataColumn("CounterID");
                    DataColumn dc10 = new DataColumn("PropertyID");
                    //DataColumn dc11 = new DataColumn("EntryOrigin");
                    DataColumn dc12 = new DataColumn("UnitID");
                    DataColumn dc13 = new DataColumn("UnitType");
                    DataColumn dc14 = new DataColumn("IsApplyCancellationFees");
                    //DataColumn dc15 = new DataColumn("DefaultCounterID");
                    DataColumn dc16 = new DataColumn("CompanyID");

                    dt.Columns.Add(dc1);
                    dt.Columns.Add(dc2);
                    dt.Columns.Add(dc3);
                    dt.Columns.Add(dc4);
                    dt.Columns.Add(dc5);
                    dt.Columns.Add(dc6);
                    dt.Columns.Add(dc7);
                    dt.Columns.Add(dc8);
                    dt.Columns.Add(dc9);
                    dt.Columns.Add(dc10);
                    //dt.Columns.Add(dc11);
                    dt.Columns.Add(dc12);
                    dt.Columns.Add(dc13);
                    dt.Columns.Add(dc14);
                    //dt.Columns.Add(dc15);
                    dt.Columns.Add(dc16);

                    if (gvRefundDepositList.Rows.Count > 0)
                    {
                        int? Zone_TermID = null;
                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        for (int i = 0; i < gvRefundDepositList.Rows.Count; i++)
                        {
                            Label lblGvAmount = (Label)gvRefundDepositList.Rows[i].FindControl("lblGvAmount");
                            Label lblGvRefund = (Label)gvRefundDepositList.Rows[i].FindControl("lblGvRefund");

                            decimal dcmlAmount = Convert.ToDecimal(lblGvAmount.Text.Trim());
                            decimal dcmlRefundAmt = Convert.ToDecimal(lblGvRefund.Text.Trim());

                            bool isapplycancelcharge = true;

                            if (dcmlRefundAmt > 0)
                            {
                                if (Convert.ToDecimal(dcmlAmount) == Convert.ToDecimal(dcmlRefundAmt))
                                    isapplycancelcharge = false;
                                else
                                    isapplycancelcharge = true;
                            }

                            Guid? RoomID;
                            if (Convert.ToString(gvRefundDepositList.DataKeys[i]["RoomID"]) != "" && Convert.ToString(gvRefundDepositList.DataKeys[i]["RoomID"]) != null)
                                RoomID = new Guid(Convert.ToString(gvRefundDepositList.DataKeys[i]["RoomID"]));
                            else
                                RoomID = null;

                            DataRow dr = dt.NewRow();

                            if (ddlRefundDepositLedgerAcct.Items.Count > 0)
                                this.PaymentAcctID = new Guid(ddlRefundDepositLedgerAcct.SelectedValue.ToString());

                            dr["DepositBookID"] = Convert.ToString(gvRefundDepositList.DataKeys[i]["BookID"]);
                            dr["Zone_TermID"] = Convert.ToString(Zone_TermID);
                            dr["Amt"] = Convert.ToString(lblGvRefund.Text.Trim());
                            dr["PaymentAcctID"] = Convert.ToString(this.PaymentAcctID);
                            dr["DepositAcctID"] = Convert.ToString(clsSession.DefaultDepositAcctID);
                            dr["ReservationID"] = Convert.ToString(this.ReservationID);
                            dr["FolioID"] = Convert.ToString(gvRefundDepositList.DataKeys[i]["FolioID"]);
                            dr["UserID"] = Convert.ToString(clsSession.UserID);
                            dr["CounterID"] = Convert.ToString(clsSession.DefaultCounterID);
                            dr["PropertyID"] = Convert.ToString(clsSession.PropertyID);
                            //dc11["EntryOrigin"] = Convert.ToString("");
                            dr["UnitID"] = Convert.ToString(RoomID);
                            dr["UnitType"] = Convert.ToString("REFUND DEPOSIT");
                            dr["IsApplyCancellationFees"] = Convert.ToString(isapplycancelcharge);
                            //dc15["DefaultCounterID"] = Convert.ToString("");
                            dr["CompanyID"] = Convert.ToString(clsSession.CompanyID);

                            dt.Rows.Add(dr);
                        }
                    }

                    ReservationBLL.UpdateWithReservationHistory(objReservation, objToInsert, dt);

                    ////If Complementory reservation is there and it's ref. type is Investor
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objCompReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                    if (objCompReservation.IsComplimentoryReservation == true)
                    {
                        RoomBlockBLL.DeleteForComplementoryReservation((DateTime)objCompReservation.CheckInDate, (DateTime)objCompReservation.CheckOutDate, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, (Guid)objCompReservation.RoomTypeID, (Guid)objCompReservation.ReservationID);
                    }

                    ucCancellationVoucher.BindCancellationVoucherData(this.ReservationID, litDisplayGuestName.Text, litDisplayReservationNo.Text, litDisplayCheckInDate.Text, litDisplayCheckOutDate.Text, lblDisplayAmountPaid.Text, "Cash", litDisplayCancellationCharge.Text, litDisplayNetBalance.Text, "Cash");
                    mpeCancellationVoucher.Show();
                    ClearControls();

                    //IsMessage = true;
                    //litMessage.Text = "Record Cancelled Successfully...";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnRefund_OnClick(object sender, EventArgs e)
        {
            trRefund.Visible = true;
            btnRefund.Visible = false;
        }

        protected void ddlRefundDepositMOP_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRefundDepositMOP.SelectedIndex != 0)
                {
                    ddlRefundDepositLedgerAcct.Items.Clear();

                    DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlRefundDepositMOP.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
                    if (dstLedgerAccounts != null && dstLedgerAccounts.Tables[0].Rows.Count > 0)
                    {
                        ddlRefundDepositLedgerAcct.DataSource = dstLedgerAccounts.Tables[0];
                        ddlRefundDepositLedgerAcct.DataTextField = "AcctName";
                        ddlRefundDepositLedgerAcct.DataValueField = "AcctID";
                        ddlRefundDepositLedgerAcct.DataBind();
                    }

                    trRefundDepoistLedgerAccount.Visible = true;
                }
                else
                {
                    ddlRefundDepositLedgerAcct.Items.Clear();
                    trRefundDepoistLedgerAccount.Visible = false;
                }

                rfvRefundDepositBankName.Enabled = rfvRefundDepositChequeDDno.Enabled = trRefundDepositBankName.Visible = trRefundDepositChequeDDNo.Visible = false;
                if (ddlRefundDepositMOP.SelectedIndex != 0)
                {
                    ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlRefundDepositMOP.SelectedValue));

                    if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
                    {
                        trRefundDepositBankName.Visible = trRefundDepositChequeDDNo.Visible = true;
                        rfvRefundDepositBankName.Enabled = rfvRefundDepositChequeDDno.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnMessageOK_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/CancelReservationList.aspx");
        }
        #endregion

        #region Private Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CancelReservation.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

            btnCalculateCancellationCharge.Visible = btnCancelReservation.Visible = this.UserRights.Substring(1, 1) == "1";

        }
        private void LoadDefaultValue()
        {
            try
            {
                if (this.ReservationID != Guid.Empty)
                {
                    BindCancelReservationData();
                }
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
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
            dr3["NameColumn"] = "Cancel Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindCancelReservationData()
        {
            try
            {
                DataSet dsRservationData = ReservationBLL.GetResrvationViewData(new Guid(Convert.ToString(this.ReservationID)), clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);

                if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsRservationData.Tables[0].Rows[0];

                    this.ResPolicyID = new Guid(Convert.ToString(dr["CancellationPolicyID"]));

                    DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));

                    litDisplayReservationNo.Text = Convert.ToString(dr["ReservationNo"]);
                    litDisplayCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    litDisplayCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                    litDisplayRoomType.Text = Convert.ToString(dr["RoomTypeName"]);
                    litDisplayRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    litDisplayAdult.Text = Convert.ToString(dr["Adults"]);

                    if (Convert.ToString(dr["Children"]) != null && Convert.ToString(dr["Children"]) != "")
                        litDisplayChild.Text = Convert.ToString(dr["Children"]);
                    else
                        litDisplayChild.Text = "-";

                    if (Convert.ToString(dr["Infant"]) != null && Convert.ToString(dr["Infant"]) != "")
                        litDisplayInf.Text = Convert.ToString(dr["Infant"]);
                    else
                        litDisplayInf.Text = "-";


                    litDisplayGuestName.Text = Convert.ToString(dr["GuestFullName"]);

                    //litDisplayMobile.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Phone1"]);

                    litDisplayMobile.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    litDisplayEmail.Text = Convert.ToString(dr["Email"]);
                    litDisplayAddress.Text = Convert.ToString(dr["Add1"]);
                    litDisplayCityName.Text = Convert.ToString(dr["CityName"]);
                    litDisplayStatus.Text = Convert.ToString(dr["Status"]);
                    litDisplayRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"])));

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

                    string strRoomRent, strTax, strTotalAmount, strDepositAmount, strTotalAmountPayable, strPaidDeposit = "";

                    strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strPaidDeposit = PaidDeposit.ToString().Substring(0, PaidDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (DepositAmount == 0)
                    {
                        strDepositAmount = strPaidDeposit;
                    }

                    TotalAmountPayable = TotalAmount + DepositAmount;
                    strTotalAmountPayable = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    lblDisplayNoOfDays.Text = Convert.ToString(NoofDays);
                    lblDisplayRoomRent.Text = Convert.ToString(strRoomRent);
                    lblDisplayTax.Text = Convert.ToString(strTax);

                    lblDisplayTotalAmount.Text = Convert.ToString(strTotalAmount);
                    lblDisplayDepositAmount.Text = Convert.ToString(strDepositAmount);

                    lblTotalAmountPayable.Text = Convert.ToString(strTotalAmountPayable);
                    lblDisplayAmountPaid.Text = txtReturnAmount.Text = Convert.ToString(strPaidDeposit);

                    if (Convert.ToDecimal(PaidDeposit) > 0)
                    {
                        btnCalculateCancellationCharge.Visible = true;
                        btnCancelReservation.Visible = false;
                    }
                    else
                    {
                        btnCalculateCancellationCharge.Visible = false;
                        btnCancelReservation.Visible = true;
                    }
                }
                else
                {
                    litDisplayCheckInDate.Text = litDisplayCheckOutDate.Text = litDisplayRoomType.Text = litDisplayRateCard.Text = litDisplayAdult.Text = litDisplayChild.Text = litDisplayInf.Text = lblDisplayAmountPaid.Text = litDisplayStatus.Text = "";
                    litDisplayGuestName.Text = litDisplayMobile.Text = litDisplayEmail.Text = litDisplayAddress.Text = litDisplayCityName.Text = "";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetMobileNo(string strPhoneNo)
        {
            string strReturn = "";
            if (Convert.ToString(strPhoneNo) != "")
            {
                string[] str = strPhoneNo.Split('-');
                if (str.Length > 0)
                {
                    if (str.Length > 0 && str[1] != "")
                        strReturn = strPhoneNo;
                    else
                        strReturn = "";
                }
                else
                    strReturn = "";
            }
            return strReturn;
        }

        private string GetRoomNumber(string strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (Convert.ToString(strRoomNumber) != string.Empty)
            {
                string[] str = strRoomNumber.Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }
            return strRoomNo;
        }

        private void BindModeOfRefundDDL()
        {
            try
            {
                ddlRefundDepositMOP.Items.Clear();
                List<ProjectTerm> lstModeOfPayment = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
                if (lstModeOfPayment.Count != 0)
                {
                    ddlRefundDepositMOP.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                    int i = 1;
                    foreach (ProjectTerm pTerm in lstModeOfPayment)
                    {
                        if (pTerm.Term.ToString().ToUpper() == "CASH" || pTerm.Term.ToString().ToUpper() == "CHEQUE")
                        {
                            ddlRefundDepositMOP.Items.Insert(i, new ListItem(pTerm.Term.ToString(), pTerm.TermID.ToString()));
                            i++;
                        }
                    }
                }
                else
                    ddlRefundDepositMOP.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControls()
        {
            litDisplayReservationNo.Text = litDisplayCheckInDate.Text = litDisplayCheckOutDate.Text = litDisplayRoomType.Text = litDisplayRateCard.Text = "";
            litDisplayAdult.Text = litDisplayChild.Text = litDisplayInf.Text = "";
            litDisplayStatus.Text = litDisplayRoomNo.Text = litDisplayGuestName.Text = litDisplayMobile.Text = litDisplayEmail.Text = litDisplayAddress.Text = litDisplayCityName.Text = "";
            lblDisplayNoOfDays.Text = lblDisplayRoomRent.Text = lblDisplayTax.Text = lblDisplayTotalAmount.Text = lblDisplayDepositAmount.Text = lblTotalAmountPayable.Text = "";
            lblTotalAmountPayable.Text = lblDisplayAmountPaid.Text = "";

            btnCancelReservation.Visible = trCalculateCancellationCharge.Visible = btnCalculateCancellationCharge.Visible = false;
        }
        #endregion
    }
}