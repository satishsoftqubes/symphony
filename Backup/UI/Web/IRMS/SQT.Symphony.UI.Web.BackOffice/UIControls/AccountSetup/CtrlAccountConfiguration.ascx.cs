using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup
{
    public partial class CtrlAccountConfiguration : System.Web.UI.UserControl
    {
        #region Property and Variables                

        public Guid AcctConfigID
        {
            get
            {
                return ViewState["AcctConfigID"] != null ? new Guid(Convert.ToString(ViewState["AcctConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AcctConfigID"] = value;
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

        public bool IsMessage = false;

        public bool IsInsert = false;
     
        #endregion Property and Variables

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");

                //CheckUserAuthorization();

                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                LoadDefaultValue();
            }
        }
        #endregion Form Load

        #region Private Methods

        private void LoadDefaultValue()
        {
            try
            {
                BindBreadCrumb();
                SetPageLabels();              
                LoadData();
                GetData();                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "AccountConfiguration.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblMainHeader", "ACCOUNT CONFIGURATION");
            litAccountMehod.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblAccountMethod", "Account Method");           
            litCurrency.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblCurrency", "Default Currency");
            litCurrencyRete.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblCurrencyRate", "Currency Rate");
            chkAutoConversion.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblAutoConversion", "Auto Conversion");
            litDecimalPlaces.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblDecimalPlaces", "Decimal Places");
            chkStockInHandCompulsory.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblStockInHandCompulsory", "Stock In Hand Compulsory Before Sold");
            chkBillRequiredBeforePayment.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblBillRequired", "Bill Required Before Payment");
            chkUpdateStockOnReceiveGoods.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblUpdateStockOnReceiveGoods", "Update Stock On Receive Goods");
            chkUpdateStockOnDeliveryChallan.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblUpdateStockOnDeliveryChallan", "Update Stock On Delivery Challan");
            chkPartialPaymentAllowed.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblPartialPaymentAllowed", "Partial Payment Allowed");
            chkPostingDoneAutomatic.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblPostingDoneAutomatically", "Posting Done Automatically");
            chkPostingRemainderAtNightAudit.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsPostingRemainderAtNightAudit", "Posting Remainder At Night Audit");
            litHeaderAutoGenrate.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblHeaderAutoGenrate", "Auto Generate");
            chkAutoGenAcctCode.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsAutoGenAcctCode", "Account Code");
            chkAutoGenItemCode.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsAutoGenItemCode", "Item Code");
            chkAutoGenAgentCode.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsAutoGenAgentCode", "Agent Code");
            chkAutoGenCustomerCode.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsAutoGenCustomerCode", "Customer Code");
            chkAutoGenGuestCode.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsAutoGenGuestCode", "Guest Code");
            chkAutoGenVendorCode.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsAutoGenVendorCode", "Vendor Code");
            chkTaxBreakUpInInvoice.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsTaxBreakUpInInvoice", "Tax Break-up in Invoice");
            chkAdjustmentAllowed.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsAdjustmentAllowed", "Adjustment Allowed");
            chkCounterCompulsoryOnPosting.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsCounterCompulsoryOnPosting", "Counter Compulsory On Posting");
            chkCounterLoginCoumpOnDayEnd.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsCounterLoginCoumpOnDayEnd", "Counter Login Compulsory On DayEnd");
            chkIsInclusiveTax.Text = clsCommon.GetGlobalResourceText("AccountConfiguration", "lblIsInclusiveTax", "Inclusive Tax");
                      
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");            
        }


        private void GetData()
        {
            List<AccountConfig> lstAcctConfig = null;
            AccountConfig objAccountConfig = new AccountConfig();
            objAccountConfig = new AccountConfig();
            objAccountConfig.IsActive = true;
            objAccountConfig.CompanyID = clsSession.CompanyID;
            objAccountConfig.PropertyID = clsSession.PropertyID;
            objAccountConfig.SeqNo = 1;
            lstAcctConfig = AccountConfigBLL.GetAll(objAccountConfig);

            if (lstAcctConfig.Count != 0)
            {
                this.AcctConfigID = lstAcctConfig[0].AcctConfigID;

                ddlAccountMethod.SelectedIndex = ddlAccountMethod.Items.FindByValue(Convert.ToString(lstAcctConfig[0].AccountingMethod_TermID)) != null ? ddlAccountMethod.Items.IndexOf(ddlAccountMethod.Items.FindByValue(Convert.ToString(lstAcctConfig[0].AccountingMethod_TermID))) : 0;
                ddlCurrency.SelectedIndex = ddlCurrency.Items.FindByValue(Convert.ToString(lstAcctConfig[0].DefaultCurrencyID)) != null ? ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByValue(Convert.ToString(lstAcctConfig[0].DefaultCurrencyID))) : 0;
                txtCurrencyRate.Text = Convert.ToString(lstAcctConfig[0].CurrencyConversionRate);                
                chkAutoConversion.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAutoConversion);
                txtDecimalPlaces.Text = Convert.ToString(lstAcctConfig[0].DecimalPlaces);
                chkStockInHandCompulsory.Checked = Convert.ToBoolean(lstAcctConfig[0].IsStockInHandCompulsoryBeforeSold);
                chkBillRequiredBeforePayment.Checked = Convert.ToBoolean(lstAcctConfig[0].IsBillRequiredBeforePayment);
                chkUpdateStockOnReceiveGoods.Checked = Convert.ToBoolean(lstAcctConfig[0].IsUpdateStockOnReceiveGoods);
                chkUpdateStockOnDeliveryChallan.Checked = Convert.ToBoolean(lstAcctConfig[0].IsUpdateStockOnDeliveryChallan);
                chkPartialPaymentAllowed.Checked = Convert.ToBoolean(lstAcctConfig[0].IsPartialPaymentAllowed);
                chkPostingDoneAutomatic.Checked = Convert.ToBoolean(lstAcctConfig[0].IsPostingDoneAutomatically);
                chkPostingRemainderAtNightAudit.Checked = Convert.ToBoolean(lstAcctConfig[0].IsPostingRemainderAtNightAudit);
                chkTaxBreakUpInInvoice.Checked = Convert.ToBoolean(lstAcctConfig[0].IsTaxBreakUpInInvoice);
                chkAdjustmentAllowed.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAdjustmentAllowed);
                chkCounterCompulsoryOnPosting.Checked = Convert.ToBoolean(lstAcctConfig[0].IsCounterCompulsoryOnPosting);
                chkCounterLoginCoumpOnDayEnd.Checked = Convert.ToBoolean(lstAcctConfig[0].IsCounterLoginCoumpOnDayEnd);
                chkIsInclusiveTax.Checked = Convert.ToBoolean(lstAcctConfig[0].IsInclusiveTax);
                chkAutoGenAcctCode.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAutoGenAcctCode);
                chkAutoGenAgentCode.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAutoGenAgentCode);
                chkAutoGenItemCode.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAutoGenItemCode);
                chkAutoGenCustomerCode.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAutoGenCustomerCode);
                chkAutoGenGuestCode.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAutoGenGuestCode);
                chkAutoGenVendorCode.Checked = Convert.ToBoolean(lstAcctConfig[0].IsAutoGenVendorCode);
            }
        }

        private void SaveAndUpdateAcctConfiguration()
        {
            try
            {
                if (this.AcctConfigID != Guid.Empty)
                {
                    AccountConfig objUpd = new AccountConfig();
                    AccountConfig objOldData = new AccountConfig();
                    objUpd = AccountConfigBLL.GetByPrimaryKey(this.AcctConfigID);
                    objOldData = AccountConfigBLL.GetByPrimaryKey(this.AcctConfigID);

                    if (ddlAccountMethod.SelectedValue != Guid.Empty.ToString())
                        objUpd.AccountingMethod_TermID = new Guid(ddlAccountMethod.SelectedValue);
                    else
                        objUpd.AccountingMethod_TermID = null;

                    if (ddlCurrency.SelectedValue != Guid.Empty.ToString())
                        objUpd.DefaultCurrencyID = new Guid(ddlCurrency.SelectedValue);
                    else
                        objUpd.DefaultCurrencyID = null;

                    if (txtCurrencyRate.Text.Trim() != string.Empty)
                        objUpd.CurrencyConversionRate = Convert.ToDecimal(txtCurrencyRate.Text.Trim());
                    else
                        objUpd.CurrencyConversionRate = 0;

                    if (txtDecimalPlaces.Text.Trim() != string.Empty)
                        objUpd.DecimalPlaces = Convert.ToInt32(txtDecimalPlaces.Text.Trim());
                    else
                        objUpd.DecimalPlaces = 0;

                    objUpd.IsStockInHandCompulsoryBeforeSold = chkStockInHandCompulsory.Checked;
                    objUpd.IsBillRequiredBeforePayment = chkBillRequiredBeforePayment.Checked;
                    objUpd.IsUpdateStockOnReceiveGoods = chkUpdateStockOnReceiveGoods.Checked;
                    objUpd.IsUpdateStockOnDeliveryChallan = chkUpdateStockOnDeliveryChallan.Checked;
                    objUpd.IsPartialPaymentAllowed = chkPartialPaymentAllowed.Checked;
                    objUpd.IsPostingDoneAutomatically = chkPostingDoneAutomatic.Checked;
                    objUpd.IsPostingRemainderAtNightAudit = chkPostingRemainderAtNightAudit.Checked;
                    objUpd.IsAutoGenAcctCode = chkAutoGenAcctCode.Checked;
                    objUpd.IsAutoGenItemCode = chkAutoGenItemCode.Checked;
                    objUpd.IsAutoGenAgentCode = chkAutoGenAgentCode.Checked;
                    objUpd.IsAutoGenCustomerCode = chkAutoGenCustomerCode.Checked;
                    objUpd.IsAutoGenGuestCode = chkAutoGenGuestCode.Checked;
                    objUpd.IsAutoGenVendorCode = chkAutoGenVendorCode.Checked;
                    objUpd.IsAutoConversion = chkAutoConversion.Checked;
                    objUpd.IsTaxBreakUpInInvoice = chkTaxBreakUpInInvoice.Checked;
                    objUpd.IsAdjustmentAllowed = chkAdjustmentAllowed.Checked;
                    objUpd.IsCounterCompulsoryOnPosting = chkCounterCompulsoryOnPosting.Checked;
                    objUpd.IsCounterLoginCoumpOnDayEnd = chkCounterLoginCoumpOnDayEnd.Checked;
                    objUpd.IsInclusiveTax = chkIsInclusiveTax.Checked;
                    objUpd.UpdatedBy = clsSession.UserID;
                    objUpd.UpdatedOn = System.DateTime.Now;

                    AccountConfigBLL.Update(objUpd);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldData.ToString(), objUpd.ToString(), "acc_AccountConfig");
                    IsMessage = true;
                    litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                    this.AcctConfigID = objUpd.AcctConfigID;
                }
                else
                {
                    AccountConfig objIns = new AccountConfig();

                    objIns.CompanyID = clsSession.CompanyID;
                    objIns.PropertyID = clsSession.PropertyID;

                    if (ddlAccountMethod.SelectedValue != Guid.Empty.ToString())
                        objIns.AccountingMethod_TermID = new Guid(ddlAccountMethod.SelectedValue);
                    else
                        objIns.AccountingMethod_TermID = null;

                    if (ddlCurrency.SelectedValue != Guid.Empty.ToString())
                        objIns.DefaultCurrencyID = new Guid(ddlCurrency.SelectedValue);
                    else
                        objIns.DefaultCurrencyID = null;

                    if (txtCurrencyRate.Text.Trim() != string.Empty)
                        objIns.CurrencyConversionRate = Convert.ToDecimal(txtCurrencyRate.Text.Trim());
                    else
                        objIns.CurrencyConversionRate = 0;

                    if (txtDecimalPlaces.Text.Trim() != string.Empty)
                        objIns.DecimalPlaces = Convert.ToInt32(txtDecimalPlaces.Text.Trim());
                    else
                        objIns.DecimalPlaces = 0;

                    objIns.IsStockInHandCompulsoryBeforeSold = chkStockInHandCompulsory.Checked;
                    objIns.IsBillRequiredBeforePayment = chkBillRequiredBeforePayment.Checked;
                    objIns.IsUpdateStockOnReceiveGoods = chkUpdateStockOnReceiveGoods.Checked;
                    objIns.IsUpdateStockOnDeliveryChallan = chkUpdateStockOnDeliveryChallan.Checked;
                    objIns.IsPartialPaymentAllowed = chkPartialPaymentAllowed.Checked;
                    objIns.IsPostingDoneAutomatically = chkPostingDoneAutomatic.Checked;
                    objIns.IsPostingRemainderAtNightAudit = chkPostingRemainderAtNightAudit.Checked;
                    objIns.IsAutoGenAcctCode = chkAutoGenAcctCode.Checked;
                    objIns.IsAutoGenItemCode = chkAutoGenItemCode.Checked;
                    objIns.IsAutoGenAgentCode = chkAutoGenAgentCode.Checked;
                    objIns.IsAutoGenCustomerCode = chkAutoGenCustomerCode.Checked;
                    objIns.IsAutoGenGuestCode = chkAutoGenGuestCode.Checked;
                    objIns.IsAutoGenVendorCode = chkAutoGenVendorCode.Checked;
                    objIns.IsAutoConversion = chkAutoConversion.Checked;
                    objIns.IsTaxBreakUpInInvoice = chkTaxBreakUpInInvoice.Checked;
                    objIns.IsAdjustmentAllowed = chkAdjustmentAllowed.Checked;
                    objIns.IsCounterCompulsoryOnPosting = chkCounterCompulsoryOnPosting.Checked;
                    objIns.IsCounterLoginCoumpOnDayEnd = chkCounterLoginCoumpOnDayEnd.Checked;
                    objIns.IsInclusiveTax = chkIsInclusiveTax.Checked;
                    objIns.IsSynch = false;
                    objIns.IsActive = true;
                    AccountConfigBLL.Save(objIns);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "acc_AccountConfig");
                    IsMessage = true;
                    litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                    this.AcctConfigID = objIns.AcctConfigID;
                }              
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

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblBackOfficeSetup", "BackOffice Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccountConfiguration", "Account Configuration");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void LoadData()
        {
            List<ProjectTerm> lstProjectTerm = null;
            ProjectTerm objProjectTerm = new ProjectTerm();
            objProjectTerm.IsActive = true;
            objProjectTerm.CompanyID = clsSession.CompanyID;
            objProjectTerm.PropertyID = clsSession.PropertyID;
            objProjectTerm.Category = "ACCOUNT METHOD";
            lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
            if (lstProjectTerm.Count != 0)
            {
                ddlAccountMethod.DataSource = lstProjectTerm;
                ddlAccountMethod.DataTextField = "DisplayTerm";
                ddlAccountMethod.DataValueField = "TermID";
                ddlAccountMethod.DataBind();
                ddlAccountMethod.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlAccountMethod.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));            

            List<Currency> lstCurrency = null;
            Currency objCurrency = new Currency();
            objCurrency.IsActive = true;
            objCurrency.CompanyID = clsSession.CompanyID;
            objCurrency.PropertyID = clsSession.PropertyID;
            lstCurrency = CurrencyBLL.GetAll(objCurrency);
            if (lstCurrency.Count != 0)
            {
                ddlCurrency.DataSource = lstCurrency;
                ddlCurrency.DataTextField = "DisplayLocale";
                ddlCurrency.DataValueField = "CurrencyID";
                ddlCurrency.DataBind();
                ddlCurrency.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlCurrency.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));       
        }

        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCurrency.SelectedIndex != 0)
            {
                Currency objCurrency = CurrencyBLL.GetByPrimaryKey(new Guid(ddlCurrency.SelectedValue));
                if (objCurrency != null)
                    txtCurrencyRate.Text = Convert.ToString(objCurrency.Rate);
            }
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateAcctConfiguration();
                }               
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}