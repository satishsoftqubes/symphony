using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.BLL;
using System.Data;
using System.Globalization;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice
{
    public partial class CtrlNewCompanyInvoices : System.Web.UI.UserControl
    {
        #region Property and Variables
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
        public decimal dcmlPendingAmount
        {
            get
            {
                return ViewState["dcmlPendingAmount"] != null ? Convert.ToDecimal(ViewState["dcmlPendingAmount"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["dcmlPendingAmount"] = value;
            }
        }
        public bool IsListMessage = false;
        decimal dcmlTotalAmount = Convert.ToDecimal("0.000000");
        decimal dcmlTotalOutStdAmount = Convert.ToDecimal("0.000000");
        decimal dcmlTotalPayment = Convert.ToDecimal("0.000000");
        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");

                CheckUserAuthorization();


                calDate.Format = clsSession.DateFormat;
                txtDate.Text = DateTime.Today.ToString(clsSession.DateFormat);

                if (clsSession.ToEditItemType.ToUpper() == "INVOICESETTLEMENT")
                {
                    this.AgentID = clsSession.ToEditItemID;
                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = "";
                }

                BindBreadCrumb();
                BindModeOfPayment();
                BindGrid();
            }
        }

        #endregion Page Load

        #region Private Method

        private void ClearControlaftersave()
        {
            txtAmount.Text = "";
            txtNameOnCard.Text = "";
            txtNotes.Text = "";
            txtCVVNo.Text = "";
            txtChequeDDNo.Text = "";
            txtCardNumber.Text = "";
           
            //ddlCardExpirationYear.SelectedIndex = 0;
            if (ddlCreditCardType.Items.Count > 0)
                ddlCreditCardType.SelectedIndex = 0;

            if (ddlLedgerAccount.Items.Count > 0)
                ddlLedgerAccount.SelectedIndex = 0;
            
            txtBankName.Text = "";
            txtDate.Text = "";

            if (ddlModeOfPayment.Items.Count > 0)
                ddlModeOfPayment.SelectedIndex = 0;

            if (ddlPayAC.Items.Count > 0)
                ddlPayAC.SelectedIndex = 0;

            BindGrid();
        }
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CompanyInvoices.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";

        }
        private void BindGrid()
        {
            try
            {
                DataSet dsCompanyInvoices = InvoiceBLL.SelectInvoicesOfCompany(null, null, null, this.AgentID, false, clsSession.PropertyID, clsSession.CompanyID);
                if (dsCompanyInvoices != null && dsCompanyInvoices.Tables.Count > 0 && dsCompanyInvoices.Tables[0].Rows.Count > 0)
                {
                    gvInvoiceList.DataSource = dsCompanyInvoices.Tables[0];
                    gvInvoiceList.DataBind();
                }
                else
                {
                    gvInvoiceList.DataSource = null;
                    gvInvoiceList.DataBind();
                }

                if (dsCompanyInvoices != null && dsCompanyInvoices.Tables.Count > 1 && dsCompanyInvoices.Tables[1].Rows.Count > 0)
                {
                    BindCompanyInfo(dsCompanyInvoices.Tables[1].Rows[0]);
                }

                if (dsCompanyInvoices != null && dsCompanyInvoices.Tables.Count > 2 && dsCompanyInvoices.Tables[2].Rows.Count > 0)
                {
                    ddlPayAC.DataSource = dsCompanyInvoices.Tables[2];
                    ddlPayAC.DataTextField = "AcctName";
                    ddlPayAC.DataValueField = "AcctID";
                    ddlPayAC.DataBind();
                    ddlPayAC.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlPayAC.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindModeOfPayment()
        {
            ddlModeOfPayment.Items.Clear();
            List<ProjectTerm> lstModeOfPayment = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
            if (lstModeOfPayment.Count != 0)
            {
                ddlModeOfPayment.DataSource = lstModeOfPayment;
                ddlModeOfPayment.DataTextField = "DisplayTerm";
                ddlModeOfPayment.DataValueField = "TermID";
                ddlModeOfPayment.DataBind();
                ddlModeOfPayment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlModeOfPayment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void BindCompanyInfo(DataRow dr)
        {
            lblDisplayCompanyName.Text = Convert.ToString(dr["CompanyName"]);
        }

        private void ClearControl()
        {
            txtAmount.Text = txtDate.Text = txtNotes.Text = "";
            ddlModeOfPayment.SelectedIndex = 0;
            ddlModeOfPayment_OnSelectedIndexChanged(null, null);
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
            dr2["NameColumn"] = "Dashboard";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            dr2["Link"] = "~/GUI/AccountsHome.aspx";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Direct Bill & Settle Invoice";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccountGroupSetup", "Account Group");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion Private Method

        #region Button Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ltrPendingAmount.Text.Trim() != "" && Convert.ToDecimal(ltrPendingAmount.Text.Trim()) > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Pending amount should not be greater than 0, please settle it against any invoice.");
                    return;
                }

                if (Convert.ToDecimal(txtAmount.Text.Trim()) <= 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Invalid paying amount, amount should be greater than 0.");
                    return;
                }

                /*
                ResGuestPaymentInfo objPaymentInfo = null;
                ProjectTerm pTermPaymentInfo = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlModeOfPayment.SelectedValue));
                if (pTermPaymentInfo != null)
                {
                    string strPaymentMode = Convert.ToString(pTermPaymentInfo.Term).ToUpper();
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
                */

                Guid ret_BookID = Guid.Empty;
                Guid ret_ReceiptID = Guid.Empty;
                InvoiceBLL.AgentReceivePayment(new Guid(ddlLedgerAccount.SelectedValue), Convert.ToDecimal(txtAmount.Text.Trim()), this.AgentID, DateTime.Now, txtNotes.Text.Trim(), clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "ACCOUNT", null, 100, clsSession.CompanyID, ref ret_BookID, ref ret_ReceiptID);

                if (ret_ReceiptID != Guid.Empty)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    for (int i = 0; i < gvInvoiceList.Rows.Count; i++)
                    {
                        if (((CheckBox)gvInvoiceList.Rows[i].FindControl("chkSelect")).Checked)
                        {
                            if (Convert.ToDecimal(((Label)gvInvoiceList.Rows[i].FindControl("lblGvAmount")).Text) == Convert.ToDecimal(((Label)gvInvoiceList.Rows[i].FindControl("lblGvPayment")).Text))
                            {
                                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Invoice objInvoice = InvoiceBLL.GetByPrimaryKey(new Guid(gvInvoiceList.DataKeys[i]["InvoiceID"].ToString()));
                                objInvoice.IsPaid = true;
                                decimal PendingAmountnew = Convert.ToDecimal(objInvoice.PendingAmount) - Convert.ToDecimal(((Label)gvInvoiceList.Rows[i].FindControl("lblGvPayment")).Text);
                                objInvoice.PendingAmount = PendingAmountnew;
                                InvoiceBLL.Update(objInvoice);
                            }

                            Agent_Payment objAgentPayment = new Agent_Payment();

                            objAgentPayment.InvoiceID = new Guid(gvInvoiceList.DataKeys[i]["InvoiceID"].ToString());
                            objAgentPayment.ReceiptID = ret_ReceiptID;
                            objAgentPayment.Amt = Convert.ToDecimal(((Label)gvInvoiceList.Rows[i].FindControl("lblGvPayment")).Text);
                            objAgentPayment.CompanyID = clsSession.CompanyID;
                            objAgentPayment.PaymentDate = DateTime.ParseExact(txtDate.Text.Trim(), clsSession.DateFormat, objCultureInfo); ;
                            objAgentPayment.PropertyID = clsSession.PropertyID;
                            objAgentPayment.Description = txtNotes.Text.Trim();

                            Agent_PaymentBLL.Save(objAgentPayment);
                            
                        }
                    }

                    IsListMessage = true;
                    ltrListMessage.Text = "Record saved successfully.";
                    ClearControlaftersave();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void txtAmount_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text.Trim() != string.Empty)
                {
                    if (txtAmount.Text.Trim().IndexOf('.') > -1)
                        this.dcmlPendingAmount = Convert.ToDecimal(txtAmount.Text.Trim() + "00");
                    else
                        this.dcmlPendingAmount = Convert.ToDecimal(txtAmount.Text.Trim() + ".00");
                }
                else
                    this.dcmlPendingAmount = Convert.ToDecimal("0.000000");

                ltrPendingAmount.Text = this.dcmlPendingAmount.ToString().Substring(0, this.dcmlPendingAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Invoice/InvoiceSettlement.aspx");
        }

        protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((CheckBox)sender).NamingContainer);
                int rowIndex = row.RowIndex;
                decimal dcmlOutStdAmount = Convert.ToDecimal("0.000000");
                decimal dcmlToSetPaymentAmt = Convert.ToDecimal("0.000000");

                if (((CheckBox)gvInvoiceList.Rows[rowIndex].FindControl("chkSelect")).Checked)
                {
                    if (this.dcmlPendingAmount > 0)
                    {
                        Label lblGvOStdAmount = (Label)gvInvoiceList.Rows[rowIndex].FindControl("lblGvOStdAmount");
                        if (lblGvOStdAmount.Text.Trim() != string.Empty)
                            dcmlOutStdAmount = Convert.ToDecimal(lblGvOStdAmount.Text.Trim());

                        if (this.dcmlPendingAmount >= dcmlOutStdAmount)
                        {
                            dcmlToSetPaymentAmt = dcmlOutStdAmount;
                            dcmlOutStdAmount = dcmlOutStdAmount - dcmlToSetPaymentAmt;

                            this.dcmlPendingAmount = this.dcmlPendingAmount - dcmlToSetPaymentAmt;
                        }
                        else
                        {
                            ((CheckBox)gvInvoiceList.Rows[rowIndex].FindControl("chkSelect")).Checked = false;

                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Pending amount is less than Out standing amount of selected invoice, you can't settle selected invoice.");
                            return;

                            //// Below 3 lines are commented temporary, to uncomment once actual implementation to do.
                            ////dcmlToSetPaymentAmt = this.dcmlPendingAmount;
                            ////dcmlOutStdAmount = dcmlOutStdAmount - dcmlToSetPaymentAmt;
                            ////this.dcmlPendingAmount = this.dcmlPendingAmount - dcmlToSetPaymentAmt;
                        }

                        lblGvOStdAmount.Text = dcmlOutStdAmount.ToString().Substring(0, dcmlOutStdAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        ((Label)gvInvoiceList.Rows[rowIndex].FindControl("lblGvPayment")).Text = dcmlToSetPaymentAmt.ToString().Substring(0, dcmlToSetPaymentAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        ltrPendingAmount.Text = this.dcmlPendingAmount.ToString().Substring(0, this.dcmlPendingAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                    {
                        ((CheckBox)gvInvoiceList.Rows[rowIndex].FindControl("chkSelect")).Checked = false;

                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Pending amount is 0, you can't settle selected invoice.");
                    }
                }
                else
                {
                    Label lblGvPayment = (Label)gvInvoiceList.Rows[rowIndex].FindControl("lblGvPayment");
                    if (lblGvPayment.Text.Trim() != string.Empty)
                    {
                        this.dcmlPendingAmount = this.dcmlPendingAmount + Convert.ToDecimal(lblGvPayment.Text.Trim());
                        decimal dcmlOstdAmountToSet = Convert.ToDecimal("0.000000");

                        if (gvInvoiceList.DataKeys[rowIndex]["PendingAmount"] != null && Convert.ToString(gvInvoiceList.DataKeys[rowIndex]["PendingAmount"]) != string.Empty)
                            dcmlOstdAmountToSet = Convert.ToDecimal(gvInvoiceList.DataKeys[rowIndex]["PendingAmount"]);

                        ((Label)gvInvoiceList.Rows[rowIndex].FindControl("lblGvOStdAmount")).Text = dcmlOstdAmountToSet.ToString().Substring(0, dcmlOstdAmountToSet.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        lblGvPayment.Text = "0.00";
                        ltrPendingAmount.Text = this.dcmlPendingAmount.ToString().Substring(0, this.dcmlPendingAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                }

                for (int i = 0; i < gvInvoiceList.Rows.Count; i++)
                {
                    dcmlTotalOutStdAmount = dcmlTotalOutStdAmount + Convert.ToDecimal(((Label)gvInvoiceList.Rows[i].FindControl("lblGvOStdAmount")).Text);
                    dcmlTotalPayment = dcmlTotalPayment + Convert.ToDecimal(((Label)gvInvoiceList.Rows[i].FindControl("lblGvPayment")).Text);
                }

                if (gvInvoiceList.Rows.Count > 0)
                {
                    ((Label)gvInvoiceList.FooterRow.FindControl("lblGvFtOStd")).Text = dcmlTotalOutStdAmount.ToString().Substring(0, dcmlTotalOutStdAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    ((Label)gvInvoiceList.FooterRow.FindControl("lblGvFtPayment")).Text = dcmlTotalPayment.ToString().Substring(0, dcmlTotalPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Dropdown Event

        protected void ddlModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModeOfPayment.SelectedIndex != 0)
            {
                ddlLedgerAccount.Items.Clear();

                DataSet dstLedgerAccounts = SQT.Symphony.BusinessLogic.Configuration.BLL.AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlModeOfPayment.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
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
                    string strSelect = "-Select-"; //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
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

        #endregion Dropdown Event

        #region Grid Event

        protected void gvInvoiceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //decimal dcminamt = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MinAmount")));
                    ((Label)e.Row.FindControl("lblGvDate")).Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "InvoiceDate").ToString()).ToString(clsSession.DateFormat);

                    dcmlTotalAmount = dcmlTotalOutStdAmount + Convert.ToDecimal(((Label)e.Row.FindControl("lblGvAmount")).Text);
                    dcmlTotalOutStdAmount = dcmlTotalOutStdAmount + Convert.ToDecimal(((Label)e.Row.FindControl("lblGvOStdAmount")).Text);
                    dcmlTotalPayment = dcmlTotalPayment + Convert.ToDecimal(((Label)e.Row.FindControl("lblGvPayment")).Text);
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    ((Label)e.Row.FindControl("lblGvFtAmount")).Text = dcmlTotalAmount.ToString().Substring(0, dcmlTotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    ((Label)e.Row.FindControl("lblGvFtOStd")).Text = dcmlTotalOutStdAmount.ToString().Substring(0, dcmlTotalOutStdAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    ((Label)e.Row.FindControl("lblGvFtPayment")).Text = dcmlTotalPayment.ToString().Substring(0, dcmlTotalPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
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