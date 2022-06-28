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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCounterClose : System.Web.UI.UserControl
    {
        #region Property And Variable
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
        public bool IsPreview = false;
        decimal dcmlFtTotalSystem_Amt = Convert.ToDecimal("0.000000");
        decimal dcmlFtTotalAmountByPayType = Convert.ToDecimal("0.000000");

        public Guid AcctID
        {
            get
            {
                return ViewState["AcctID"] != null ? new Guid(Convert.ToString(ViewState["AcctID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AcctID"] = value;
            }
        }

        public string Code
        {
            get
            {
                return ViewState["Code"] != null ? Convert.ToString(ViewState["Code"]) : string.Empty;
            }
            set
            {
                ViewState["Code"] = value;
            }
        }

        public bool IsCounterCloseForDayEnd
        {
            get
            {
                return ViewState["IsCounterCloseForDayEnd"] != null ? Convert.ToBoolean(ViewState["IsCounterCloseForDayEnd"]) : false;
            }
            set
            {
                ViewState["IsCounterCloseForDayEnd"] = value;
            }
        }

        #endregion Property And Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                if (clsSession.DefaultCounterID != Guid.Empty && clsSession.DefaultCounterID != null)
                {
                    trButtonEvent.Visible = true;
                    LoadDefaultValue();

                    ////Session["IsCounterCloseForDayEnd"] = 1 means user come to close counter at time of Day end and set this.IsCounterCloseForDayEnd to true.
                    if (Session["IsCounterCloseForDayEnd"] != null && Convert.ToString(Session["IsCounterCloseForDayEnd"]) == "1")
                    {
                        this.IsCounterCloseForDayEnd = true;
                        Session.Remove("IsCounterCloseForDayEnd");
                    }
                }
                else
                {
                    Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx");
                    trButtonEvent.Visible = false;
                    gvCounterDetails.DataSource = null;
                    gvCounterDetails.DataBind();
                }
            }
        }

        #endregion Page Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CloseCounter.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void LoadDefaultValue()
        {
            try
            {
                mvCloseCounter.ActiveViewIndex = 0;
                BindBreadCrumb();
                BindCounterDetailsGrid();
                BindBeginingAmount();
                CalculateRate();
                litDisplayCounter.Text = Convert.ToString(clsSession.CounterName);
                BindDenominationList();
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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Close Counter";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindCounterDetailsGrid()
        {
            try
            {
                DataSet dsCounterData = CountersBLL.SelectCounterCloseReport(null, clsSession.DefaultCounterID);
                if (dsCounterData.Tables.Count > 0 && dsCounterData.Tables[0].Rows.Count > 0)
                {
                    DataView dvData = new DataView(dsCounterData.Tables[0]);
                    dvData.RowFilter = "PayType='****** TOTAL ******'";

                    gvCounterDetails.DataSource = dsCounterData.Tables[0];
                    gvCounterDetails.DataBind();

                    if (dvData.Count > 0)
                    {
                        litDspSuggestedAmount.Text = Convert.ToString(dvData[0]["System_Amount"]);
                        litDspActualAmount.Text = Convert.ToString(dvData[0]["System_Amount"]);
                    }
                    else
                        litDspSuggestedAmount.Text = litDspActualAmount.Text = "0.00";

                    txtGvNetAmount_TextChanged(null, null);
                }
                else
                {
                    litDspSuggestedAmount.Text = litDspActualAmount.Text = "0.00";
                    gvCounterDetails.DataSource = null;
                    gvCounterDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindBeginingAmount()
        {
            try
            {
                DataSet dsBeginingAmount = CountersBLL.SelectBeginingAmount(clsSession.DefaultCounterID, null, false);
                if (dsBeginingAmount.Tables.Count > 0 && dsBeginingAmount.Tables[0].Rows.Count > 0)
                {
                    decimal dcBeginingAmount = Convert.ToDecimal("0.000000");
                    dcBeginingAmount = Convert.ToDecimal(Convert.ToString(dsBeginingAmount.Tables[0].Rows[0]["AmountDropped"]));

                    litDspBeginingAmount.Text = dcBeginingAmount.ToString().Substring(0, dcBeginingAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else
                {
                    litDspBeginingAmount.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CalculateRate()
        {
            try
            {
                decimal dblShortAmount = Convert.ToDecimal("0.00");
                decimal dblDspActualAmount = Convert.ToDecimal("0.00");
                decimal dblDspBeginingAmount = Convert.ToDecimal("0.00");
                decimal dblDspSuggestedAmount = Convert.ToDecimal("0.00");

                if (Convert.ToString(litDspActualAmount.Text.Trim()) != "")
                    dblDspActualAmount = Convert.ToDecimal(litDspActualAmount.Text.Trim());

                if (Convert.ToString(litDspBeginingAmount.Text.Trim()) != "")
                    dblDspBeginingAmount = Convert.ToDecimal(litDspBeginingAmount.Text.Trim());

                if (Convert.ToString(litDspSuggestedAmount.Text.Trim()) != "")
                    dblDspSuggestedAmount = Convert.ToDecimal(litDspSuggestedAmount.Text.Trim());

                dblShortAmount = dblDspActualAmount - (dblDspBeginingAmount + dblDspSuggestedAmount);

                litDspShortOverAmount.Text = Convert.ToString(dblShortAmount);

                if (Convert.ToString(litDspShortOverAmount.Text.Trim()) != "0.00")
                    txtReason.Enabled = rvfReason.Enabled = true;
                else
                    txtReason.Enabled = rvfReason.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindCounterHistoryByPayType()
        {
            try
            {
                DataSet dsData = CountersBLL.GetGenerateLedgerReports(clsSession.DefaultCounterID, null, true, null, null, null, null, null, null, null, null, null, null);

                if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    DataView dvData = new DataView(dsData.Tables[0]);

                    string strRF = ((Convert.ToString(this.Code).Equals("MOP") ? "IsCharge = 0 and " : "IsCharge = 1 and ") + "AcctID = '" + Convert.ToString(this.AcctID) + "'");
                    dvData.RowFilter = strRF;

                    if (dvData.Count > 0)
                    {
                        dcmlFtTotalAmountByPayType = (decimal)dsData.Tables[0].Compute("sum(Amount)", strRF);

                        gvCounterHistoryByPayType.DataSource = dvData;
                        gvCounterHistoryByPayType.DataBind();
                    }
                    else
                    {
                        gvCounterHistoryByPayType.DataSource = null;
                        gvCounterHistoryByPayType.DataBind();
                    }
                }
                else
                {
                    gvCounterHistoryByPayType.DataSource = null;
                    gvCounterHistoryByPayType.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDenominationList()
        {
            try
            {
                DataSet dsCurrencyTypes = new DataSet();
                SQT.Symphony.BusinessLogic.Configuration.DTO.CurrencyTypes objCurrencyTypes = new SQT.Symphony.BusinessLogic.Configuration.DTO.CurrencyTypes();
                objCurrencyTypes.PropertyID = clsSession.PropertyID;
                objCurrencyTypes.CompanyID = clsSession.CompanyID;
                objCurrencyTypes.IsActive = true;

                dsCurrencyTypes = CurrencyTypeBLL.GetAllWithDataSet(objCurrencyTypes);

                if (dsCurrencyTypes != null && dsCurrencyTypes.Tables.Count > 0 && dsCurrencyTypes.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsCurrencyTypes.Tables[0]);
                    dv.Sort = "CurrencyValue desc";

                    gvDenominationList.DataSource = dv;
                    gvDenominationList.DataBind();
                }
                else
                {
                    gvDenominationList.DataSource = null;
                    gvDenominationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void UpdateCashAmount(decimal dcmlCashAmt)
        {
            try
            {
                decimal total = Convert.ToDecimal("0.000000");
                decimal dcmlPayments = Convert.ToDecimal("0.000000");
                decimal dcmlPaidOut = Convert.ToDecimal("0.000000");

                for (int i = 0; i < gvCounterDetails.Rows.Count; i++)
                {
                    TextBox txtGvNetAmount = (TextBox)gvCounterDetails.Rows[i].FindControl("txtGvNetAmount");
                    Label lblGvDifference = (Label)gvCounterDetails.Rows[i].FindControl("lblGvDifference");
                    string strCode = Convert.ToString(gvCounterDetails.DataKeys[i]["Code"]);
                    string strPayType = Convert.ToString(gvCounterDetails.DataKeys[i]["PayType"]);

                    Label lblGvSystemAmount = (Label)gvCounterDetails.Rows[i].FindControl("lblGvSystemAmount");
                    decimal dcmlSystemAmount = Convert.ToDecimal(lblGvSystemAmount.Text);

                    if (txtGvNetAmount != null)
                    {
                        if (strPayType.Equals("CASH") && strCode.Equals("MOP"))
                            txtGvNetAmount.Text = Convert.ToString(dcmlCashAmt);
                    }

                    if (txtGvNetAmount.Text.Trim() != string.Empty)
                    {
                        string strAmt = txtGvNetAmount.Text.Trim().IndexOf('.') > -1 ? txtGvNetAmount.Text.Trim() + "000000" : txtGvNetAmount.Text.Trim() + ".000000";

                        if (strCode.Equals("MOP"))
                        {
                            dcmlPayments += Convert.ToDecimal(strAmt);
                        }
                        else if (strCode.Equals("PAID_OUT"))
                        {
                            dcmlPaidOut += Convert.ToDecimal(strAmt);
                        }
                    }

                    if (strCode.Equals("TOTAL"))
                    {
                        //total = (dcmlPayments + Convert.ToDecimal(hdnPaidOutCash.Value)) - dcmlPaidOut;
                        total = (dcmlPayments) - dcmlPaidOut;
                        litDspActualAmount.Text = txtGvNetAmount.Text = total.ToString().Substring(0, total.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        CalculateRate();
                    }

                    if (txtGvNetAmount.Text.Trim() != string.Empty)
                    {
                        decimal difference = Convert.ToDecimal("0.000000");
                        difference = dcmlSystemAmount - Convert.ToDecimal(txtGvNetAmount.Text.Trim());
                        lblGvDifference.Text = difference.ToString().Substring(0, difference.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvDifference.Text = dcmlSystemAmount.ToString().Substring(0, dcmlSystemAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Grid Event

        protected void gvCounterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvSystemAmount = (Label)e.Row.FindControl("lblGvSystemAmount");
                    TextBox txtGvNetAmount = (TextBox)e.Row.FindControl("txtGvNetAmount");
                    Label lblGvDifference = (Label)e.Row.FindControl("lblGvDifference");
                    LinkButton lnkPayments = (LinkButton)e.Row.FindControl("lnkPayments");

                    decimal dcmlSystemAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "System_Amount"));
                    txtGvNetAmount.Text = lblGvSystemAmount.Text = dcmlSystemAmount.ToString().Substring(0, dcmlSystemAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (txtGvNetAmount.Text.Trim() != string.Empty)
                    {
                        decimal difference = Convert.ToDecimal("0.000000");
                        difference = dcmlSystemAmount - Convert.ToDecimal(txtGvNetAmount.Text.Trim());
                        lblGvDifference.Text = difference.ToString().Substring(0, difference.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvDifference.Text = lblGvSystemAmount.Text;

                    string strPayType = Convert.ToString(gvCounterDetails.DataKeys[e.Row.RowIndex]["PayType"]);
                    string strCode = Convert.ToString(gvCounterDetails.DataKeys[e.Row.RowIndex]["Code"]);

                    if (Convert.ToString(strPayType) == "****** PAYMENTS ******" || Convert.ToString(strPayType) == "****** PAID OUT ******" || Convert.ToString(strPayType) == "****** TOTAL ******" || Convert.ToString(strPayType) == "****** CITY LEDGER ******" || Convert.ToString(strPayType) == "****** DEPOSIT TAKEN ******")
                        lnkPayments.Enabled = txtGvNetAmount.Enabled = false;
                    else
                        lnkPayments.Enabled = txtGvNetAmount.Enabled = true;

                    if (Convert.ToString(strCode) == "MOP" && Convert.ToString(strPayType) == "CASH")
                    {
                        txtGvNetAmount.Enabled = false;
                        txtGvNetAmount.Text = "0.00";
                    }

                    if (Convert.ToString(strCode) == "PAID_OUT" && (Convert.ToString(strPayType) == "STOCK ASSET" || Convert.ToString(strPayType) == "CASH" || Convert.ToString(strPayType) == "MASTER CARD" || Convert.ToString(strPayType) == "CHAPS" || Convert.ToString(strPayType) == "CHEQUE" || Convert.ToString(strPayType) == "BACS"))
                    {
                        txtGvNetAmount.Enabled = false;
                        if (Convert.ToString(strPayType) == "CASH")
                            hdnPaidOutCash.Value = Convert.ToString(lblGvSystemAmount.Text.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCounterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("SHOWHISTORY"))
                {
                    mvCloseCounter.ActiveViewIndex = 1;

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    this.AcctID = new Guid(gvCounterDetails.DataKeys[row.RowIndex]["AcctID"].ToString());
                    this.Code = Convert.ToString(gvCounterDetails.DataKeys[row.RowIndex]["Code"]);

                    BindCounterHistoryByPayType();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCounterHistoryByPayType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvCounterHistoryByPayTypeAmount = (Label)e.Row.FindControl("lblGvCounterHistoryByPayTypeAmount");

                    decimal dcmlAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
                    lblGvCounterHistoryByPayTypeAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtTotalCounterHistoryByPayTypeAmount = (Label)e.Row.FindControl("lblGvFtTotalCounterHistoryByPayTypeAmount");
                    lblGvFtTotalCounterHistoryByPayTypeAmount.Text = dcmlFtTotalAmountByPayType.ToString().Substring(0, dcmlFtTotalAmountByPayType.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCounterHistoryByPayType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCounterHistoryByPayType.PageIndex = e.NewPageIndex;
            BindCounterHistoryByPayType();
        }

        protected void gvDenominationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Label lblGvTotal = (Label)e.Row.FindControl("lblGvTotal");

                    //decimal dcmlAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
                    //lblGvTotal.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    //Label lblGvFtrTotal = (Label)e.Row.FindControl("lblGvFtrTotal");
                    //lblGvFtrTotal.Text = dcmlFtTotalAmountByPayType.ToString().Substring(0, dcmlFtTotalAmountByPayType.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Textbox Event

        protected void txtGvNetAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal total = Convert.ToDecimal("0.000000");
                decimal dcmlPayments = Convert.ToDecimal("0.000000");
                decimal dcmlPaidOut = Convert.ToDecimal("0.000000");

                for (int i = 0; i < gvCounterDetails.Rows.Count; i++)
                {
                    TextBox txtGvNetAmount = (TextBox)gvCounterDetails.Rows[i].FindControl("txtGvNetAmount");
                    Label lblGvDifference = (Label)gvCounterDetails.Rows[i].FindControl("lblGvDifference");
                    string strCode = Convert.ToString(gvCounterDetails.DataKeys[i]["Code"]);

                    Label lblGvSystemAmount = (Label)gvCounterDetails.Rows[i].FindControl("lblGvSystemAmount");
                    decimal dcmlSystemAmount = Convert.ToDecimal(lblGvSystemAmount.Text);

                    if (txtGvNetAmount.Text.Trim() != string.Empty)
                    {
                        string strAmt = txtGvNetAmount.Text.Trim().IndexOf('.') > -1 ? txtGvNetAmount.Text.Trim() + "000000" : txtGvNetAmount.Text.Trim() + ".000000";

                        if (strCode.Equals("MOP"))
                        {
                            dcmlPayments += Convert.ToDecimal(strAmt);
                        }
                        else if (strCode.Equals("PAID_OUT"))
                        {
                            dcmlPaidOut += Convert.ToDecimal(strAmt);
                        }
                    }

                    if (strCode.Equals("TOTAL"))
                    {
                        //total = (dcmlPayments + Convert.ToDecimal(hdnPaidOutCash.Value)) - dcmlPaidOut;
                        total = (dcmlPayments) - dcmlPaidOut;
                        litDspActualAmount.Text = txtGvNetAmount.Text = total.ToString().Substring(0, total.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        decimal dcmlTotalDifference = Convert.ToDecimal("0.000000");
                        //dcmlTotalDifference = total - 

                        CalculateRate();
                    }

                    if (txtGvNetAmount.Text.Trim() != string.Empty)
                    {
                        decimal difference = Convert.ToDecimal("0.000000");
                        difference = dcmlSystemAmount - Convert.ToDecimal(txtGvNetAmount.Text.Trim());
                        lblGvDifference.Text = difference.ToString().Substring(0, difference.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvDifference.Text = dcmlSystemAmount.ToString().Substring(0, dcmlSystemAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void txtGvQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal dcmltotal = Convert.ToDecimal("0.000000");

                for (int i = 0; i < gvDenominationList.Rows.Count; i++)
                {
                    TextBox txtGvQty = (TextBox)gvDenominationList.Rows[i].FindControl("txtGvQty");
                    Label lblGvTotal = (Label)gvDenominationList.Rows[i].FindControl("lblGvTotal");

                    if (Convert.ToString(txtGvQty.Text.Trim()) != string.Empty)
                    {
                        decimal dcmlvalue = Convert.ToDecimal(gvDenominationList.DataKeys[i]["CurrencyValue"].ToString());
                        dcmltotal += (Convert.ToDecimal(txtGvQty.Text.Trim()) * dcmlvalue);
                        lblGvTotal.Text = Convert.ToString((Convert.ToDecimal(txtGvQty.Text.Trim()) * dcmlvalue));
                    }
                    else
                        lblGvTotal.Text = "";
                }

                string strTotalAmt = dcmltotal.ToString().IndexOf('.') > -1 ? dcmltotal.ToString() + "000000" : dcmltotal.ToString() + ".000000";
                Label lblGvFtrTotal = (Label)gvDenominationList.FooterRow.FindControl("lblGvFtrTotal");
                lblGvFtrTotal.Text = strTotalAmt.Substring(0, strTotalAmt.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                UpdateCashAmount(Convert.ToDecimal(lblGvFtrTotal.Text.Trim()));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Button Event

        protected void btnCloseCounter_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    mpeConfirmMessage.Show();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                ////Do not manage Sort-Over amount at the time of Day end.
                for (int i = 0; i < gvCounterDetails.Rows.Count; i++)
                {
                    string strCode = Convert.ToString(gvCounterDetails.DataKeys[i]["Code"]);

                    if (strCode.Equals("MOP") || strCode.Equals("PAID_OUT"))
                    {
                        Guid acctID = new Guid(gvCounterDetails.DataKeys[i]["AcctID"].ToString());

                        Label lblGvSystemAmount = (Label)gvCounterDetails.Rows[i].FindControl("lblGvSystemAmount");
                        TextBox txtGvNetAmount = (TextBox)gvCounterDetails.Rows[i].FindControl("txtGvNetAmount");

                        decimal dcmlAmt = Convert.ToDecimal(lblGvSystemAmount.Text.Trim()) - Convert.ToDecimal(txtGvNetAmount.Text.Trim());

                        if (dcmlAmt != 0)
                        {
                            bool isShort = dcmlAmt > 0 ? true : false;

                            if (dcmlAmt < 0)
                            {
                                dcmlAmt = dcmlAmt * -1;
                            }

                            CountersBLL.CounterAdjustment(acctID, strCode, dcmlAmt, null, isShort, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", txtReason.Text.Trim(), clsSession.CompanyID);
                        }
                    }
                }
                */

                decimal? dcDropAmt = Convert.ToDecimal("0.00");

                if (txtDroppedAmount.Text.Trim() != "")
                    dcDropAmt = Convert.ToDecimal(txtDroppedAmount.Text.Trim());

                Guid? returnCloseID = Guid.Empty;
                bool returnIsSuccessful = true;

                Guid? CounterLoginLogID = null;
                if (clsSession.CounterLoginLogID != Guid.Empty)
                    CounterLoginLogID = clsSession.CounterLoginLogID;

                bool blissort = Convert.ToDouble(litDspShortOverAmount.Text.Trim().Equals("") ? "0.00" : litDspShortOverAmount.Text.Trim()) != 0 ? true : false;
                CountersBLL.SaveCounterCloseData(clsSession.DefaultCounterID, clsSession.UserID, clsSession.LogInLogID, CounterLoginLogID, Convert.ToDecimal(litDspBeginingAmount.Text.Trim()), Convert.ToDecimal(litDspSuggestedAmount.Text.Trim()), dcDropAmt, Convert.ToDecimal(litDspActualAmount.Text.Trim()), blissort, Convert.ToString(txtReason.Text.Trim()), Convert.ToDecimal(litDspShortOverAmount.Text.Trim()), false, ref returnIsSuccessful, ref returnCloseID);

                if (returnIsSuccessful)
                {
                    //DataSet dsCounterData = CountersBLL.GetCounterCloseDetailRport(null, clsSession.DefaultCounterID);
                    //DataSet dsCounterData = CountersBLL.SelectCounterCloseReport(null, clsSession.DefaultCounterID);
                    //DataView dvData = new DataView(dsCounterData.Tables[0]);

                    //dvData.RowFilter = "PayType not in ('****** PAYMENTS ******','****** PAID OUT ******','****** TOTAL ******','****** CITY LEDGER ******','****** DEPOSIT TAKEN ******')";

                    //if (dvData.Count > 0)
                    //{
                    for (int i = 0; i < gvCounterDetails.Rows.Count; i++)
                    {
                        bool isFromDGVW = true;

                        string strPayType = Convert.ToString(gvCounterDetails.DataKeys[i]["PayType"]);
                        string strCode = Convert.ToString(gvCounterDetails.DataKeys[i]["Code"]);
                        string strAcctID = Convert.ToString(gvCounterDetails.DataKeys[i]["AcctID"]);
                        string strNewTransID = Convert.ToString(gvCounterDetails.DataKeys[i]["NewTransID"]);
                        string strOldTransID = Convert.ToString(gvCounterDetails.DataKeys[i]["OldTransID"]);
                        string strSystem_Amount = Convert.ToString(gvCounterDetails.DataKeys[i]["System_Amount"]);
                        string strAdjustedAmount = Convert.ToString(gvCounterDetails.DataKeys[i]["AdjustedAmount"]);
                        string strNet_Amount = Convert.ToString(gvCounterDetails.DataKeys[i]["Net_Amount"]);
                        string strisReadOnly = Convert.ToString(gvCounterDetails.DataKeys[i]["isReadOnly"]);

                        if (Convert.ToString(strPayType) == "****** OVERRIDE ******")
                            isFromDGVW = false;

                        CounterClose_Summary objToInsert = new CounterClose_Summary();
                        objToInsert.CloseID = (Guid)returnCloseID;
                        objToInsert.Code = Convert.ToString(strCode);

                        if (Convert.ToString(strAcctID) != "" && Convert.ToString(strAcctID) != null)
                            objToInsert.AcctID = new Guid(Convert.ToString(strAcctID));
                        else
                            objToInsert.AcctID = null;

                        objToInsert.NewTransID = Convert.ToString(strNewTransID);
                        objToInsert.OldTransID = Convert.ToString(strOldTransID);
                        objToInsert.PayType = Convert.ToString(strPayType);

                        Label lblGvSystemAmount = (Label)gvCounterDetails.Rows[i].FindControl("lblGvSystemAmount");

                        //if (Convert.ToString(strSystem_Amount) != "" && Convert.ToString(strSystem_Amount) != null)
                        //    objToInsert.System_Amount = Convert.ToDecimal(Convert.ToString(strSystem_Amount));
                        //else
                        //    objToInsert.System_Amount = null;

                        objToInsert.System_Amount = Convert.ToDecimal(lblGvSystemAmount.Text.Trim());

                        if (Convert.ToString(strAdjustedAmount) != "" && Convert.ToString(strAdjustedAmount) != null)
                            objToInsert.AdjustedAmount = Convert.ToDecimal(Convert.ToString(strAdjustedAmount));
                        else
                            objToInsert.AdjustedAmount = null;

                        //if (Convert.ToString(dvData[i]["Net_Amount"]) != "" && Convert.ToString(dvData[i]["Net_Amount"]) != null)
                        //    objToInsert.System_Amount = Convert.ToDecimal(Convert.ToString(dvData[i]["Net_Amount"]));
                        //else
                        //    objToInsert.System_Amount = null;

                        if (isFromDGVW)
                        {
                            //if (!(Convert.ToString(dvData[i]["Net_Amount"]).Equals("")))
                            //{
                            TextBox txtGvNetAmount = (TextBox)gvCounterDetails.Rows[i].FindControl("txtGvNetAmount");
                            objToInsert.Net_Amount = Convert.ToDecimal(txtGvNetAmount.Text.Trim());
                            //}
                        }
                        else
                            objToInsert.Net_Amount = Convert.ToDecimal("0.00");

                        if (Convert.ToString(strisReadOnly) != "" && Convert.ToString(strisReadOnly) != null)
                        {
                            if (strisReadOnly == "0")
                                objToInsert.IsReadOnly = false;
                            else
                                objToInsert.IsReadOnly = true;
                        }
                        else
                            objToInsert.IsReadOnly = null;

                        //if (Convert.ToString(dvData[i]["UserID"]) != "" && Convert.ToString(dvData[i]["UserID"]) != null)
                        objToInsert.UserID = clsSession.UserID;
                        //else
                        //    objToInsert.UserID = null;


                        CounterClose_SummaryBLL.Save(objToInsert);
                    }

                    for (int j = 0; j < gvDenominationList.Rows.Count; j++)
                    {
                        TextBox txtGvQty = (TextBox)gvDenominationList.Rows[j].FindControl("txtGvQty");
                        Label lblGvTotal = (Label)gvDenominationList.Rows[j].FindControl("lblGvTotal");
                        Label lblGvCurrencyType = (Label)gvDenominationList.Rows[j].FindControl("lblGvCurrencyType");
                        Label lblGvValue = (Label)gvDenominationList.Rows[j].FindControl("lblGvValue");

                        if (Convert.ToString(txtGvQty.Text.Trim()) != "" && Convert.ToString(lblGvTotal.Text.Trim()) != "")
                        {
                            Counter_Close_Detail objCounter_Close_Detail = new Counter_Close_Detail();

                            objCounter_Close_Detail.CounterID = clsSession.DefaultCounterID;
                            objCounter_Close_Detail.PropertyID = clsSession.PropertyID;
                            objCounter_Close_Detail.CounterID = clsSession.CompanyID;
                            objCounter_Close_Detail.UpdatedOn = DateTime.Now;
                            objCounter_Close_Detail.UpdatedBy = clsSession.UserID;
                            objCounter_Close_Detail.IsActive = true;
                            objCounter_Close_Detail.CloseID = (Guid)returnCloseID;
                            objCounter_Close_Detail.CurrencyCode = Convert.ToString(gvDenominationList.DataKeys[j]["CurrencyCode"]);
                            objCounter_Close_Detail.Field_Name = Convert.ToString(lblGvValue.Text.Trim());
                            objCounter_Close_Detail.TotalCount = Convert.ToInt32(txtGvQty.Text.Trim());
                            objCounter_Close_Detail.TotalAmount = Convert.ToDecimal(lblGvTotal.Text.Trim());

                            Counter_Close_DetailBLL.Save(objCounter_Close_Detail);
                        }
                    }

                    // }

                    if (clsSession.LogInLogID != Guid.Empty)
                    {
                        LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                        objToUpdate.Logout = DateTime.Now;
                        LoginLogBLL.Update(objToUpdate);
                    }

                    ////this.IsCounterCloseForDayEnd = true menas counter is closed for day end process, so don't Log out current session and redirect to day end process.
                    if (this.IsCounterCloseForDayEnd)
                    {
                        clsSession.DefaultCounterID = Guid.Empty;
                        Session["IsComeFromCounterClose"] = "1";
                        Response.Redirect("~/GUI/CommonControl/DayEnd.aspx");
                    }
                    else
                    {
                        Session.Clear();
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancelGridCounterHistory_Click(object sender, EventArgs e)
        {
            mvCloseCounter.ActiveViewIndex = 0;
        }

        protected void btnCounterHistory_Click(object sender, EventArgs e)
        {
            try
            {
                mvCloseCounter.ActiveViewIndex = 2;
                ctrlCommonCounterCloseHistoryOnThisMachine.uctxtRow.Text = "";
                ctrlCommonCounterCloseHistoryOnThisMachine.CloseID = Guid.Empty;
                ctrlCommonCounterCloseHistoryOnThisMachine.BindHostoryOfCounterCloseGridByRowFilter();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCounterCloseHistoryOnThisMachineCallParent_Click(object sender, EventArgs e)
        {
            mvCloseCounter.ActiveViewIndex = 0;
        }

        #endregion Button Event

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Add("ReportName", "Counter Close");
                this.IsPreview = false;
                Session.Add("ExportMode", null);
                DataTable dtAccounts = new DataTable();
                dtAccounts.Columns.Add("NO", typeof(int));
                dtAccounts.Columns.Add("Code");
                //dtAccounts.Columns.Add("AcctID");
                dtAccounts.Columns.Add("PayType");
                dtAccounts.Columns.Add("System_Amount", typeof(decimal));
                dtAccounts.Columns.Add("Net_Amount", typeof(decimal));
                dtAccounts.Columns.Add("Difference", typeof(decimal));
                for (int i = 0; i < gvCounterDetails.Rows.Count; i++)
                {
                    //dtAccounts.Rows.Add();
                    DataRow drAccounts = dtAccounts.NewRow();
                    drAccounts["NO"] = i + 1;
                    drAccounts["Code"] = Convert.ToString(gvCounterDetails.DataKeys[i]["Code"]);
                    drAccounts["PayType"] = Convert.ToString(gvCounterDetails.DataKeys[i]["PayType"]);
                    drAccounts["System_Amount"] = ((Label)(gvCounterDetails.Rows[i].FindControl("lblGvSystemAmount"))).Text.Equals("") ? 0 : Convert.ToDecimal(((Label)(gvCounterDetails.Rows[i].FindControl("lblGvSystemAmount"))).Text);
                    drAccounts["Net_Amount"] = ((TextBox)gvCounterDetails.Rows[i].FindControl("txtGvNetAmount")).Text.Equals("") ? 0 : Convert.ToDecimal(((TextBox)gvCounterDetails.Rows[i].FindControl("txtGvNetAmount")).Text);
                    drAccounts["Difference"] = ((Label)gvCounterDetails.Rows[i].FindControl("lblGvDifference")).Text.Equals("") ? 0 : Convert.ToDecimal(((Label)gvCounterDetails.Rows[i].FindControl("lblGvDifference")).Text);
                    dtAccounts.Rows.Add(drAccounts);
                }

                DataTable dtDenomination = new DataTable();
                dtDenomination.Columns.Add("SrNo", typeof(int));
                dtDenomination.Columns.Add("CurrencyName");
                dtDenomination.Columns.Add("TotalCount", typeof(int));
                dtDenomination.Columns.Add("TotalAmount", typeof(decimal));
                for (int j = 0; j < gvDenominationList.Rows.Count; j++)
                {
                    DataRow drDenomination = dtDenomination.NewRow();
                    drDenomination["SrNo"] = j + 1;
                    drDenomination["CurrencyName"] = Convert.ToString(gvDenominationList.DataKeys[j]["CurrencyName"]);
                    drDenomination["TotalCount"] = ((TextBox)gvDenominationList.Rows[j].FindControl("txtGvQty")).Text.Equals("") ? 0 : Convert.ToInt32(((TextBox)gvDenominationList.Rows[j].FindControl("txtGvQty")).Text);
                    drDenomination["TotalAmount"] = ((Label)gvDenominationList.Rows[j].FindControl("lblGvTotal")).Text.Equals("") ? 0 : Convert.ToDecimal(((Label)gvDenominationList.Rows[j].FindControl("lblGvTotal")).Text);
                    dtDenomination.Rows.Add(drDenomination);
                }

                Session.Add("RptCounter", litDisplayCounter.Text);
                Session.Add("RptOpening", litDspBeginingAmount.Text);
                Session.Add("RptSuggested", litDspSuggestedAmount.Text);
                Session.Add("RptShortOver", litDspShortOverAmount.Text);
                Session.Add("RptActual", litDspActualAmount.Text);
                Session.Add("RptReason", txtReason.Text);
                Session.Add("RptDropped", txtDroppedAmount.Text);
                Session.Add("RptNotes", txtNote.Text);
                Session.Add("Date", System.DateTime.Now);
                DataTable dt = dtAccounts.Copy();
                dt.Merge(dtDenomination, true);
                DataSet finalDS = new DataSet();
                finalDS.Tables.Add(dt);                
                //DataSet dsCounterData = CountersBLL.SelectCounterCloseReport(null, clsSession.DefaultCounterID);
                //DataSet dsDenomination = Counter_Close_DetailBLL.GetCloseCounter_Denomination(clsSession.PropertyID, clsSession.DefaultCounterID);
                //DataTable dt = dsCounterData.Tables[0].Copy();
                //dt.Merge(dsDenomination.Tables[0], true);
                //DataSet finalDS = new DataSet();
                //finalDS.Tables.Add(dt);                
                Session["DataSource"] = finalDS;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}