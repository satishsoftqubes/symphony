﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;
using System.Globalization;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlAccount : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;

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

        public Guid TaxSlabID
        {
            get
            {
                return ViewState["TaxSlabID"] != null ? new Guid(Convert.ToString(ViewState["TaxSlabID"])) : Guid.Empty;
            }
            set
            {
                ViewState["TaxSlabID"] = value;
            }
        }

        public int indexofGRid
        {
            get
            {
                return ViewState["indexofGRid"] != null ? Convert.ToInt32(ViewState["indexofGRid"]) : -1;
            }
            set
            {
                ViewState["indexofGRid"] = value;
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

        public string Mode
        {
            get
            {
                return ViewState["Mode"] != null ? Convert.ToString(ViewState["Mode"]) : string.Empty;
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }

        #endregion Property and Variables

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            lblDateValidateMsg.Text = "";
            if (!IsPostBack)
            {
                CheckUserAuthorization();
                Session["SaveTaxData"] = null;
                mvAccount.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
                //BindGridTaxRate();
            }
        }
        #endregion

        #region Control Events

        protected void btnAddTopTax_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControl();
                mvAccount.ActiveViewIndex = 1;
                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvTaxList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void fnDisplayCatchErrorMessage(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControl();
                mvAccount.ActiveViewIndex = 1;
                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    Account IsDupAccount = new Account();

                    IsDupAccount.PropertyID = clsSession.PropertyID;
                    IsDupAccount.CompanyID = clsSession.CompanyID;
                    IsDupAccount.AcctName = txtTaxName.Text.Trim();
                    IsDupAccount.IsActive = true;
                    IsDupAccount.IsTaxAcct = true;

                    List<Account> lstIsDupAccount = AccountBLL.GetAll(IsDupAccount);
                    if (lstIsDupAccount.Count > 0)
                    {
                        if (this.AcctID != Guid.Empty)
                        {
                            if (Convert.ToString((lstIsDupAccount[0].AcctID)) != Convert.ToString(this.AcctID))
                            {
                                IsListMessage = true;
                                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                mvAccount.ActiveViewIndex = 1;
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            mvAccount.ActiveViewIndex = 1;
                            return;
                        }
                    }


                    if (Session["SaveTaxData"] != null)
                    {
                        DataTable dtValidationTax = (DataTable)Session["SaveTaxData"];

                        if (dtValidationTax.Rows.Count == 0)
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = "Please create atleast one slabe.";
                            mvAccount.ActiveViewIndex = 1;
                            return;
                        }
                    }
                    else
                    {
                        IsListMessage = true;
                        ltrListMessage.Text = "Please create atleast one slabe.";
                        mvAccount.ActiveViewIndex = 1;
                        return;
                    }

                    if (this.AcctID != Guid.Empty)
                    {
                        Account objUpdate = new Account();
                        Account objOldUpdateData = new Account();

                        objUpdate = AccountBLL.GetByPrimaryKey(this.AcctID);
                        objOldUpdateData = AccountBLL.GetByPrimaryKey(this.AcctID);

                        objUpdate.AcctName = txtTaxName.Text.Trim();
                        objUpdate.AcctNo = txtTaxCode.Text.Trim();

                        if (ddlRefrenceTax.SelectedIndex != 0)
                            objUpdate.RefAcctID = new Guid(Convert.ToString(ddlRefrenceTax.SelectedValue));
                        else
                            objUpdate.RefAcctID = null;

                        objUpdate.UpdatedOn = DateTime.Now;
                        objUpdate.UpdatedBy = clsSession.UserID;
                        objUpdate.IsTaxAcct = true;
                        objUpdate.SymphonyAcctGroupID = 4;

                        objUpdate.IsRefundable = Convert.ToBoolean(chkIsRefundable.Checked);
                        objUpdate.TaxRate = Convert.ToDecimal(txtAccountTaxRate.Text.Trim());
                        if (ddlAccountTaxType.SelectedIndex == 0)
                            objUpdate.IsTaxFlat = false;
                        else
                            objUpdate.IsTaxFlat = true;

                        AccountBLL.Update(objUpdate);

                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldUpdateData.ToString(), objUpdate.ToString(), "acc_Account");

                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Account objSave = new Account();
                        List<TaxSlabe> lstinsTaxSlabe = new List<TaxSlabe>();

                        objSave.PropertyID = clsSession.PropertyID;
                        objSave.CompanyID = clsSession.CompanyID;
                        objSave.AcctName = txtTaxName.Text.Trim();
                        objSave.AcctNo = txtTaxCode.Text.Trim();

                        if (ddlRefrenceTax.SelectedIndex != 0)
                            objSave.RefAcctID = new Guid(Convert.ToString(ddlRefrenceTax.SelectedValue));
                        else
                            objSave.RefAcctID = null;

                        objSave.IsActive = true;
                        objSave.IsSynch = false;
                        objSave.UpdatedOn = DateTime.Now;
                        objSave.UpdatedBy = clsSession.UserID;
                        objSave.IsEnable = true;

                        objSave.IsTaxAcct = true;
                        objSave.SymphonyAcctGroupID = 4;
                        objSave.IsRefundable = Convert.ToBoolean(chkIsRefundable.Checked);
                        objSave.TaxRate = Convert.ToDecimal(txtAccountTaxRate.Text.Trim());
                        if (ddlAccountTaxType.SelectedIndex == 0)
                            objSave.IsTaxFlat = false;
                        else
                            objSave.IsTaxFlat = true;


                        if (Session["SaveTaxData"] != null)
                        {
                            DataTable dtInsertData = (DataTable)Session["SaveTaxData"];

                            if (dtInsertData.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtInsertData.Rows.Count; i++)
                                {
                                    bool strFlat = Convert.ToBoolean(dtInsertData.Rows[i]["IsTaxFlat"]);

                                    TaxSlabe objTemp = new TaxSlabe();

                                    objTemp.TaxSlabID = new Guid(Convert.ToString(dtInsertData.Rows[i]["TaxSlabID"]));
                                    objTemp.TaxRate = Convert.ToDecimal(Convert.ToString(dtInsertData.Rows[i]["TaxRate"]));
                                    objTemp.IsTaxFlat = Convert.ToBoolean(strFlat);
                                    objTemp.MinAmount = Convert.ToDecimal(Convert.ToString(dtInsertData.Rows[i]["MinAmount"]));

                                    if (Convert.ToString(dtInsertData.Rows[i]["MaxAmount"]) != null && Convert.ToString(dtInsertData.Rows[i]["MaxAmount"]) != "")
                                        objTemp.MaxAmount = Convert.ToDecimal(Convert.ToString(dtInsertData.Rows[i]["MaxAmount"]));
                                    else
                                        objTemp.MaxAmount = null;

                                    objTemp.PropertyID = clsSession.PropertyID;
                                    objTemp.CompanyID = clsSession.CompanyID;

                                    lstinsTaxSlabe.Add(objTemp);
                                }
                            }
                        }

                        AccountBLL.Save(objSave, lstinsTaxSlabe);
                        ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Save", objSave.ToString(), objSave.ToString(), "acc_Account");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }

                    ClearControl();
                    BindGrid();
                    mvAccount.ActiveViewIndex = 1;
                    BindBreadCrumb();
                    //BindGridTaxRate();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindBreadCrumb();
                BindGrid();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindBreadCrumb();
                BindGrid();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
                mvAccount.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Methods

        private void BindddlRefrenceTax()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            string strReferenceTaxQuery = "select AcctID,Acctname from acc_Account where CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 and RefAcctID is null and IsTaxAcct = 1 order by AcctName asc";
            DataSet dsReferenceTax = RoomTypeBLL.GetUnitType(strReferenceTaxQuery);

            ddlRefrenceTax.Items.Clear();
            if (dsReferenceTax.Tables.Count > 0 && dsReferenceTax.Tables[0].Rows.Count > 0)
            {
                ddlRefrenceTax.DataSource = dsReferenceTax.Tables[0];
                ddlRefrenceTax.DataTextField = "AcctName";
                ddlRefrenceTax.DataValueField = "AcctID";
                ddlRefrenceTax.DataBind();
                ddlRefrenceTax.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlRefrenceTax.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            ////List<Account> litRefTax = AccountBLL.GetAllBy(Account.AccountFields.RefAcctID, null);

        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ACCOUNT.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomTax.Visible = btnAddTopTax.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLables();
                BindGrid();
                BindddlRefrenceTax();
                SetRateMaxValue();
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.AcctID != Guid.Empty || mvAccount.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblTaxList", "Tax List");
                dr3["Link"] = "~/GUI/Configurations/Account.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = txtTaxName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewTax", "New Tax") : txtTaxName.Text.Trim();
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblTaxList", "Tax List");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Method Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                string TaxName = null;
                string TaxCode = null;

                if (txtSearchTaxName.Text.Trim() != "")
                    TaxName = txtSearchTaxName.Text.Trim();

                if (txtSearchTaxCode.Text.Trim() != "")
                    TaxCode = txtSearchTaxCode.Text.Trim();

                DataSet dsAccount = AccountBLL.SearchAccountData(null, clsSession.PropertyID, clsSession.CompanyID, TaxCode, TaxName);

                gvTaxList.DataSource = dsAccount.Tables[0];
                gvTaxList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("Tax", "lblMainHeader", "TAX SETUP");
            litSearchTaxName.Text = clsCommon.GetGlobalResourceText("Tax", "lblSearchTaxName", "Tax Name");
            litSearchTaxCode.Text = clsCommon.GetGlobalResourceText("Tax", "lblSearchTaxCode", "Tax Code");
            litTaxName.Text = clsCommon.GetGlobalResourceText("Tax", "lblTaxName", "Tax Name");
            litTaxCode.Text = clsCommon.GetGlobalResourceText("Tax", "lblTaxCode", "Tax Code");
            //litTaxRate.Text = clsCommon.GetGlobalResourceText("Tax", "lblTaxRate", "Tax Rate");
            btnAddTopTax.Text = btnAddBottomTax.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancel.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = btnSaveTaxRate.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litTaxList.Text = clsCommon.GetGlobalResourceText("Tax", "lblTaxList", "Tax List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Tax", "lblHdrConfirmDeletePopup", "Tax");
            btnSearchAmenities.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            // lblMinimumAmount.Text = clsCommon.GetGlobalResourceText("Tax", "lblMinimumAmount", "Min");
            //lblMaximumAmount.Text = clsCommon.GetGlobalResourceText("Tax", "lblMaximumAmount", "Max");
            //litAmountRange.Text = clsCommon.GetGlobalResourceText("Tax", "lblAmountRange", "Amount Range");

            //ddlTaxRate.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), "00000000-0000-0000-0000-000000000000"));
            // ddlTaxRate.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Tax", "lblDiscountRateTypeInPercentage", "%"), "0"));
            // ddlTaxRate.Items.Insert(2, new ListItem(clsCommon.GetGlobalResourceText("Tax", "lblDiscountRateTypeFlat", "Flat"), "1"));

            //revMinAmountRange.ValidationExpression = revMaxAmountRange.ValidationExpression = revTaxRate.ValidationExpression = "\\d{0,17}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            //revMinAmountRange.ErrorMessage = revMaxAmountRange.ErrorMessage = revTaxRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            // lblTaxRate.Text = clsCommon.GetGlobalResourceText("Tax", "lblMsgDiscountLimitInPercentage", "% should be less than or equal to 100.");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
            // chkIsRateCard.Text = clsCommon.GetGlobalResourceText("Tax", "lblIsRateCard", "Is RateCard");
            RefrenceTax.Text = "Reference Tax";//clsCommon.GetGlobalResourceText("Tax", "lblRefrenceTax", "Refrence Tax");

            btnAddNewTaxRateCol.Text = "Add";
            litGvhdrTaxService.Text = "Tax Slabe";

            litDeleteRow.Text = clsCommon.GetGlobalResourceText("Tax", "litDeleteRow", "Sure you want to delete Row?");
            litRowDeleteMsg.Text = clsCommon.GetGlobalResourceText("Tax", "lblHdrConfirmDeletePopup", "Tax");
            btnDeleteRow.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCalncel.Text = btnCalncelTaxRate.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            //revGvTaxRate.ValidationExpression = "\\d{0,17}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revGvTaxRate.ErrorMessage = "2 " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            litAccountTaxRate.Text = litAddTaxRate.Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxRate1", "Tax Rate");
            litAccountTaxType.Text = litAddTaxType.Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxType", "Type");
            litAddMinAmount.Text = "Min. Amount";//clsCommon.GetGlobalResourceText("Tax", "lblGvHdrStartDate", "Start Date");
            litAddmaxAmount.Text = "Max. Amount";//clsCommon.GetGlobalResourceText("Tax", "lblGvHdrEndDate", "End Date");

            rvGvTaxRate.ErrorMessage = clsCommon.GetGlobalResourceText("Tax", "lblMsgForTaxAmountRange", "Tax Rate in % should be less than or equal to 100.");
            ltrMsgDateValidate.Text = "Start Date should be less than or equal to End Date";
            ltrHeaderDateValidate.Text = clsCommon.GetGlobalResourceText("Common", "lblHeaderCustomeMessage", "Message");
            btnDateMessageOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnOK", "OK");


            revMinAmount.ErrorMessage = "2 " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            revMaxAmount.ErrorMessage = "2 " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            litIsRefundable.Text = "Is Refundable";
            revAccountTaxRate.ErrorMessage = "2 " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            rvAccountTaxRate.ErrorMessage = clsCommon.GetGlobalResourceText("Tax", "lblMsgForTaxAmountRange", "Tax Rate in % should be less than or equal to 100.");
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            txtTaxName.Text = txtTaxCode.Text = "";
            this.TaxSlabID = this.AcctID = Guid.Empty;
            txtMinAmount.Text = txtMaxAmount.Text = txtGvTaxRate.Text = txtAccountTaxRate.Text = "";
            ddlGvTaxRate.SelectedIndex = ddlAccountTaxType.SelectedIndex = 0;
            gvTaxRateList.DataSource = null;
            gvTaxRateList.DataBind();
            Session["SaveTaxData"] = null;
            BindddlRefrenceTax();
            SetAccountTaxRateMaxValue();
            this.Mode = string.Empty;
            chkIsRefundable.Checked = false;
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearchTaxName.Text = txtSearchTaxCode.Text = "";
        }

        public void SetRateMaxValue()
        {
            if (ddlGvTaxRate.SelectedIndex == 0)
            {
                rvGvTaxRate.Enabled = true;
                rvGvTaxRate.MaximumValue = "100";
            }
            else
            {
                rvGvTaxRate.Enabled = false;
                rvGvTaxRate.MaximumValue = "999999999999999999";// 18 chars
            }
        }

        public void SetAccountTaxRateMaxValue()
        {
            if (ddlAccountTaxType.SelectedIndex == 0)
            {
                rvAccountTaxRate.Enabled = true;
                rvAccountTaxRate.MaximumValue = "100";
            }
            else
            {
                rvAccountTaxRate.Enabled = false;
                rvAccountTaxRate.MaximumValue = "999999999999999999";// 18 chars
            }
        }

        #endregion

        #region Grid Event
        protected void gvTaxList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Label lblGvTaxRate = (Label)e.Row.FindControl("lblGvTaxRate");
                    //Label lblGvMinValue = (Label)e.Row.FindControl("lblGvMinValue");
                    //Label lblGvMaxValue = (Label)e.Row.FindControl("lblGvMaxValue");

                    //if (lblGvTaxRate != null)
                    //    lblGvTaxRate.Text = lblGvTaxRate.Text.Substring(0, lblGvTaxRate.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                    //if (lblGvMinValue != null && Convert.ToString(lblGvMinValue.Text) != "")
                    //{
                    //    lblGvMinValue.Text = lblGvMinValue.Text.Substring(0, lblGvMinValue.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
                    //}

                    //if (lblGvMaxValue != null && Convert.ToString(lblGvMaxValue.Text) != "")
                    //    lblGvMaxValue.Text = lblGvMaxValue.Text.Substring(0, lblGvMaxValue.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AcctID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrTaxCode")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxCode", "Tax Code");
                    ((Label)e.Row.FindControl("lblGvHdrTaxName")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxName", "Tax Name");
                    //((Label)e.Row.FindControl("lblGvHdrTaxRate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxRate", "Tax Rate");
                    // ((Label)e.Row.FindControl("lblGvHdrTaxType")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxType", "Type");
                    // ((Label)e.Row.FindControl("lblGvHdrMinRate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrMinRate", "Min Rate");
                    //  ((Label)e.Row.FindControl("lblGvHdrMaxRate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrMaxRate", "Max Rate");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");

                    //((RegularExpressionValidator)e.Row.FindControl("revGvTaxRate")).Text.ValidationExpression = "\\d{0,17}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvTaxList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    ClearControl();
                    mvAccount.ActiveViewIndex = 1;
                    Account objAccount = new Account();
                    objAccount = AccountBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    if (objAccount != null)
                    {
                        this.AcctID = objAccount.AcctID;
                        txtTaxName.Text = objAccount.AcctName;
                        txtTaxCode.Text = objAccount.AcctNo;

                        if (objAccount.TaxRate != null && Convert.ToString(objAccount.TaxRate) != "")
                        {
                            decimal dcmlTaxRate = Convert.ToDecimal(Convert.ToString(objAccount.TaxRate));
                            txtAccountTaxRate.Text = Convert.ToString(dcmlTaxRate.ToString().Substring(0, dcmlTaxRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                        }

                        if (objAccount.IsTaxFlat != null && Convert.ToString(objAccount.IsTaxFlat) != "")
                        {
                            bool strFlat = Convert.ToBoolean(objAccount.IsTaxFlat);

                            if (strFlat == false)
                                ddlAccountTaxType.SelectedIndex = 0;
                            else
                                ddlAccountTaxType.SelectedIndex = 1;

                        }
                        else
                            ddlAccountTaxType.SelectedIndex = 0;

                        SetAccountTaxRateMaxValue();

                        if (objAccount.IsRefundable != null && Convert.ToString(objAccount.IsRefundable) != "")
                        {
                            bool blIsRefundable = Convert.ToBoolean(objAccount.IsRefundable);

                            if (blIsRefundable == false)
                                chkIsRefundable.Checked = false;
                            else
                                chkIsRefundable.Checked = true;
                        }
                        else
                            chkIsRefundable.Checked = false;

                        ddlRefrenceTax.SelectedIndex = ddlRefrenceTax.Items.FindByValue(Convert.ToString(objAccount.RefAcctID)) != null ? ddlRefrenceTax.Items.IndexOf(ddlRefrenceTax.Items.FindByValue(Convert.ToString(objAccount.RefAcctID))) : 0;

                        DataSet dsTaxData = TaxSlabeBLL.SelectAllDataByTaxID(this.AcctID);
                        if (dsTaxData.Tables.Count > 0 && dsTaxData.Tables[0].Rows.Count > 0)
                        {
                            gvTaxRateList.DataSource = dsTaxData.Tables[0];
                            DataTable dtLoadSessionData = dsTaxData.Tables[0];
                            Session["SaveTaxData"] = dtLoadSessionData;
                            gvTaxRateList.DataBind();
                        }
                    }

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.AcctID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvTaxList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTaxList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();

                    TaxRateBLL.Delete(TaxRate.TaxRateFields.TaxID, Convert.ToString(hdnConfirmDelete.Value));

                    Account objDelete = new Account();
                    objDelete = AccountBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    AccountBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "acc_Account");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        //protected void btnAddNewTaxRateCol_OnClick(object sender, EventArgs e)
        //{
        //    AddNewColumnInGrid();

        //}

        //private void BindGridTaxRate()
        //{
        //    if (this.AcctID != Guid.Empty)
        //    {
        //        List<TaxRate> lisTaxRate = TaxRateBLL.GetAllBy(TaxRate.TaxRateFields.TaxID, this.AcctID.ToString());

        //        if (lisTaxRate.Count != 0)
        //        {


        //            gvTaxRateList.DataSource = lisTaxRate;
        //            gvTaxRateList.DataBind();

        //            for (int i = 0; i < gvTaxRateList.Rows.Count; i++)
        //            {
        //                DropDownList ddlGvTaxRate = (DropDownList)gvTaxRateList.Rows[i].FindControl("ddlGvTaxRate");
        //                if (Convert.ToBoolean(lisTaxRate[i].IsTaxFlat))
        //                    ddlGvTaxRate.SelectedIndex = 2;
        //                else
        //                    ddlGvTaxRate.SelectedIndex = 1;

        //                TextBox txtGvTaxRate = (TextBox)gvTaxRateList.Rows[i].FindControl("txtGvTaxRate");
        //                txtGvTaxRate.Text = Convert.ToString(lisTaxRate[i].TaxRateAmount.ToString().Substring(0, lisTaxRate[i].TaxRateAmount.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));

        //            }
        //        }
        //        else
        //        {
        //            DataTable dtTaxRate = new DataTable();

        //            DataColumn dc2 = new DataColumn("TaxRateAmount");
        //            DataColumn dc3 = new DataColumn("IsTaxFlat");
        //            DataColumn dc4 = new DataColumn("StartDate");
        //            DataColumn dc5 = new DataColumn("EndDate");

        //            dtTaxRate.Columns.Add(dc2);
        //            dtTaxRate.Columns.Add(dc3);
        //            dtTaxRate.Columns.Add(dc4);
        //            dtTaxRate.Columns.Add(dc5);

        //            DataRow dr1 = dtTaxRate.NewRow();
        //            dr1["TaxRateAmount"] = "";
        //            dr1["IsTaxFlat"] = "00000000-0000-0000-0000-000000000000";
        //            dr1["StartDate"] = "";
        //            dr1["EndDate"] = "";
        //            dtTaxRate.Rows.Add(dr1);

        //            gvTaxRateList.DataSource = dtTaxRate;
        //            gvTaxRateList.DataBind();

        //        }
        //    }
        //    else
        //    {
        //        DataTable dtTaxRate = new DataTable();

        //        DataColumn dc2 = new DataColumn("TaxRateAmount");
        //        DataColumn dc3 = new DataColumn("IsTaxFlat");
        //        DataColumn dc4 = new DataColumn("StartDate");
        //        DataColumn dc5 = new DataColumn("EndDate");

        //        dtTaxRate.Columns.Add(dc2);
        //        dtTaxRate.Columns.Add(dc3);
        //        dtTaxRate.Columns.Add(dc4);
        //        dtTaxRate.Columns.Add(dc5);

        //        DataRow dr1 = dtTaxRate.NewRow();
        //        dr1["TaxRateAmount"] = "";
        //        dr1["IsTaxFlat"] = "00000000-0000-0000-0000-000000000000";
        //        dr1["StartDate"] = "";
        //        dr1["EndDate"] = "";
        //        dtTaxRate.Rows.Add(dr1);

        //        gvTaxRateList.DataSource = dtTaxRate;
        //        gvTaxRateList.DataBind();
        //    }

        //}

        //private void AddNewColumnInGrid()
        //{

        //    int RowCount = gvTaxRateList.Rows.Count - 1;

        //    TextBox txtGvTaxRateForCon = (TextBox)gvTaxRateList.Rows[RowCount].FindControl("txtGvTaxRate");
        //    DropDownList ddlGvTaxRateForCon = (DropDownList)gvTaxRateList.Rows[RowCount].FindControl("ddlGvTaxRate");
        //    TextBox txtGvStartDateForCon = (TextBox)gvTaxRateList.Rows[RowCount].FindControl("txtGvStartDate");
        //    TextBox txtGvEndDateForCon = (TextBox)gvTaxRateList.Rows[RowCount].FindControl("txtGvEndDate");

        //    if (txtGvTaxRateForCon.Text != "" && ddlGvTaxRateForCon.SelectedIndex != 0 && txtGvStartDateForCon.Text != "" && txtGvEndDateForCon.Text != "")
        //    {



        //        DataColumn dc2 = new DataColumn("TaxRateAmount");
        //        DataColumn dc3 = new DataColumn("IsTaxFlat");
        //        DataColumn dc4 = new DataColumn("StartDate");
        //        DataColumn dc5 = new DataColumn("EndDate");

        //        dtTaxRate.Columns.Add(dc2);
        //        dtTaxRate.Columns.Add(dc3);
        //        dtTaxRate.Columns.Add(dc4);
        //        dtTaxRate.Columns.Add(dc5);


        //        for (int i = 0; i < gvTaxRateList.Rows.Count; i++)
        //        {
        //            TextBox txtGvTaxRate = (TextBox)gvTaxRateList.Rows[i].FindControl("txtGvTaxRate");
        //            DropDownList ddlGvTaxRate1 = (DropDownList)gvTaxRateList.Rows[i].FindControl("ddlGvTaxRate");
        //            TextBox txtGvStartDate = (TextBox)gvTaxRateList.Rows[i].FindControl("txtGvStartDate");
        //            TextBox txtGvEndDate = (TextBox)gvTaxRateList.Rows[i].FindControl("txtGvEndDate");


        //            DataRow dr1 = dtTaxRate.NewRow();
        //            dr1["TaxRateAmount"] = txtGvTaxRate.Text;
        //            dr1["IsTaxFlat"] = ddlGvTaxRate1.SelectedValue.ToString();
        //            dr1["StartDate"] = txtGvStartDate.Text;
        //            dr1["EndDate"] = txtGvEndDate.Text;
        //            dtTaxRate.Rows.Add(dr1);

        //            ddlGvTaxRate1.SelectedValue = ddlGvTaxRate1.SelectedValue.ToString();
        //        }

        //        DataRow dr2 = dtTaxRate.NewRow();
        //        dtTaxRate.Rows.Add(dr2);

        //        gvTaxRateList.DataSource = dtTaxRate;
        //        gvTaxRateList.DataBind();

        //        for (int i = 0; i < gvTaxRateList.Rows.Count; i++)
        //        {
        //            DropDownList ddlGvTaxRate = (DropDownList)gvTaxRateList.Rows[i].FindControl("ddlGvTaxRate");
        //            ddlGvTaxRate.SelectedValue = dtTaxRate.Rows[i][1].ToString();

        //        }


        //    }
        //}

        //protected void gvTaxRateList_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {

        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {

        //            ((Label)e.Row.FindControl("lblGvHrdNo1")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
        //            ((Label)e.Row.FindControl("lblGvHdrTaxRate1")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxRate1", "Tax Rate"); ;
        //            ((Label)e.Row.FindControl("lblGvHdrTaxType")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxType", "Type");
        //            ((Label)e.Row.FindControl("lblGvHdrStartDate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrStartDate", "Start Date");
        //            ((Label)e.Row.FindControl("lblGvHdrEndDate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrEndDate", "End Date");
        //        }
        //        else if (e.Row.RowType == DataControlRowType.DataRow)
        //        {

        //            RegularExpressionValidator revGvTaxRate = (RegularExpressionValidator)e.Row.FindControl("revGvTaxRate");
        //            revGvTaxRate.ValidationExpression = "\\d{0,17}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
        //            revGvTaxRate.ErrorMessage = "*";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        //protected void btnRemoveRow_OnClick(object sender, EventArgs e)
        //{
        //    int lastRow = gvTaxRateList.Rows.Count - 1;

        //    if (lastRow != 0)
        //    {
        //        mpeDeleteRowOfDrid.Show();
        //    }

        //}

        //protected void btnDeleteRow_Click(object sender, EventArgs e)
        //{
        //    mpeDeleteRowOfDrid.Hide();
        //    int lastRow = gvTaxRateList.Rows.Count - 1;

        //    if (lastRow != 0)
        //    {
        //        DataColumn dc2 = new DataColumn("TaxRateAmount");
        //        DataColumn dc3 = new DataColumn("IsTaxFlat");
        //        DataColumn dc4 = new DataColumn("StartDate");
        //        DataColumn dc5 = new DataColumn("EndDate");

        //        dtTaxRate.Columns.Add(dc2);
        //        dtTaxRate.Columns.Add(dc3);
        //        dtTaxRate.Columns.Add(dc4);
        //        dtTaxRate.Columns.Add(dc5);


        //        for (int i = 0; i < lastRow; i++)
        //        {
        //            TextBox txtGvTaxRate = (TextBox)gvTaxRateList.Rows[i].FindControl("txtGvTaxRate");
        //            DropDownList ddlGvTaxRate1 = (DropDownList)gvTaxRateList.Rows[i].FindControl("ddlGvTaxRate");
        //            TextBox txtGvStartDate = (TextBox)gvTaxRateList.Rows[i].FindControl("txtGvStartDate");
        //            TextBox txtGvEndDate = (TextBox)gvTaxRateList.Rows[i].FindControl("txtGvEndDate");


        //            DataRow dr1 = dtTaxRate.NewRow();
        //            dr1["TaxRateAmount"] = txtGvTaxRate.Text;
        //            dr1["IsTaxFlat"] = ddlGvTaxRate1.SelectedValue.ToString();
        //            dr1["StartDate"] = txtGvStartDate.Text;
        //            dr1["EndDate"] = txtGvEndDate.Text;
        //            dtTaxRate.Rows.Add(dr1);

        //            ddlGvTaxRate1.SelectedValue = ddlGvTaxRate1.SelectedValue.ToString();
        //        }

        //        gvTaxRateList.DataSource = dtTaxRate;
        //        gvTaxRateList.DataBind();

        //        for (int i = 0; i < gvTaxRateList.Rows.Count; i++)
        //        {
        //            DropDownList ddlGvTaxRate = (DropDownList)gvTaxRateList.Rows[i].FindControl("ddlGvTaxRate");
        //            ddlGvTaxRate.SelectedValue = dtTaxRate.Rows[i][1].ToString();

        //        }
        //    }
        //}

        protected void btnAddNewTaxRateCol_OnClick(object sender, EventArgs e)
        {
            this.Mode = "NEWSLABE";
            mpeAddTaxRate.Show();
            txtGvTaxRate.Text = txtMinAmount.Text = txtMaxAmount.Text = "";
            ddlGvTaxRate.SelectedIndex = 0;
            this.indexofGRid = -1;
            lblDateValidateMsg.Text = "";
            SetRateMaxValue();
        }

        protected void btnSaveTaxRate_OnClick(object sender, EventArgs e)
        {
            try
            {
                mpeAddTaxRate.Show();
                if (this.Page.IsValid)
                {
                    decimal dcValidateMinAmount = 0;
                    decimal? dcValidateMaxAmount = null;

                    string strMinAmount = txtMinAmount.Text.Trim().IndexOf('.') > -1 ? txtMinAmount.Text.Trim() + "000000" : txtMinAmount.Text.Trim() + ".000000";
                    dcValidateMinAmount = Convert.ToDecimal(strMinAmount);

                    if (txtMaxAmount.Text.Trim() != "")
                    {
                        string strMaxAmount = txtMaxAmount.Text.Trim().IndexOf('.') > -1 ? txtMaxAmount.Text.Trim() + "000000" : txtMaxAmount.Text.Trim() + ".000000";
                        dcValidateMaxAmount = Convert.ToDecimal(strMaxAmount);

                        if (dcValidateMinAmount > dcValidateMaxAmount)
                        {
                            lblDateValidateMsg.Text = "Min amount should be less than or equal to Max amount.";
                            return;
                        }
                        else
                            lblDateValidateMsg.Text = "";
                    }
                    else
                        dcValidateMaxAmount = null;

                    DataTable dtTaxData = new DataTable();

                    DataColumn dc1 = new DataColumn("TaxSlabID");
                    DataColumn dc2 = new DataColumn("TaxRate");
                    DataColumn dc3 = new DataColumn("IsTaxFlat");
                    DataColumn dc4 = new DataColumn("MinAmount");
                    DataColumn dc5 = new DataColumn("MaxAmount");
                    DataColumn dc6 = new DataColumn("TaxType");

                    dtTaxData.Columns.Add(dc1);
                    dtTaxData.Columns.Add(dc2);
                    dtTaxData.Columns.Add(dc3);
                    dtTaxData.Columns.Add(dc4);
                    dtTaxData.Columns.Add(dc5);
                    dtTaxData.Columns.Add(dc6);

                    if (Session["SaveTaxData"] != null)
                    {
                        dtTaxData = (DataTable)Session["SaveTaxData"];

                        DataRow[] drCheck = dtTaxData.Select("MaxAmount = '' ");

                        if (drCheck.Length > 0)
                        {
                            string strTaxSlabID = Convert.ToString(drCheck[0]["TaxSlabID"]);

                            if (this.Mode != string.Empty && this.Mode == "NEWSLABE")
                            {
                                if (strTaxSlabID.ToUpper() != this.TaxSlabID.ToString().ToUpper())
                                {
                                    lblDateValidateMsg.Text = "Amount Range is not valid.";
                                    return;
                                }
                            }
                            else if (this.Mode != string.Empty && this.Mode == "EDITSLABE")
                            {
                                if (txtMaxAmount.Text.Trim() == "")
                                {
                                    if (strTaxSlabID.ToUpper() != this.TaxSlabID.ToString().ToUpper())
                                    {
                                        lblDateValidateMsg.Text = "Amount Range is not valid.";
                                        return;
                                    }
                                }
                            }
                        }

                        lblDateValidateMsg.Text = "";
                        for (int j = 0; j < dtTaxData.Rows.Count; j++)
                        {
                            string strOldMaxAmount = Convert.ToString(dtTaxData.Rows[j]["MaxAmount"]);
                            decimal? dtOldMaxAmount = null;

                            decimal dtOldMinAmount = Convert.ToDecimal(dtTaxData.Rows[j]["MinAmount"]);

                            if (strOldMaxAmount != null && strOldMaxAmount != "")
                                dtOldMaxAmount = Convert.ToDecimal(dtTaxData.Rows[j]["MaxAmount"]);

                            Guid taxSlabID = new Guid(Convert.ToString(dtTaxData.Rows[j]["TaxSlabID"]));

                            if (Convert.ToString(taxSlabID).ToUpper() != Convert.ToString(this.TaxSlabID).ToUpper())
                            {
                                if (dcValidateMinAmount >= dtOldMinAmount && dcValidateMinAmount <= dtOldMaxAmount)
                                {
                                    lblDateValidateMsg.Text = "Amount Range is Overlapping.";
                                    return;
                                }
                                else if (dtOldMaxAmount != null && Convert.ToString(dtOldMaxAmount) != "" && dcValidateMaxAmount >= dtOldMinAmount && dcValidateMaxAmount <= dtOldMaxAmount)
                                {
                                    lblDateValidateMsg.Text = "Amount Range is Overlapping.";
                                    return;
                                }
                                else
                                    lblDateValidateMsg.Text = "";
                            }
                        }

                        if (this.TaxSlabID != Guid.Empty)
                        {
                            DataRow[] drDelete = dtTaxData.Select("TaxSlabID = '" + Convert.ToString(this.TaxSlabID) + "'");

                            foreach (DataRow dr in drDelete)
                            {
                                dtTaxData.Rows.Remove(dr);
                            }

                            dtTaxData.AcceptChanges();

                            if (this.AcctID != Guid.Empty)
                            {
                                TaxSlabeBLL.Delete(this.TaxSlabID);
                            }
                        }
                    }

                    bool strIsFlat = false;
                    string strTaxType = "%";

                    if (ddlGvTaxRate.SelectedIndex == 0)
                    {
                        strIsFlat = false;
                        strTaxType = "%";
                    }
                    else
                    {
                        strIsFlat = true;
                        strTaxType = "Flat";
                    }

                    string strTaxRateAmount = txtGvTaxRate.Text.Trim().IndexOf('.') > -1 ? txtGvTaxRate.Text.Trim() + "000000" : txtGvTaxRate.Text.Trim() + ".000000";

                    DataRow drInsert = dtTaxData.NewRow();
                    drInsert["TaxSlabID"] = Guid.NewGuid();
                    drInsert["TaxRate"] = Convert.ToString(strTaxRateAmount);
                    drInsert["IsTaxFlat"] = Convert.ToBoolean(strIsFlat);

                    //DateTime dtStartDate = DateTime.ParseExact(txtGvStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    //DateTime dtEndDate = DateTime.ParseExact(txtGvEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    //drInsert["StartDate"] = Convert.ToString(dtStartDate);
                    //drInsert["EndDate"] = Convert.ToString(dtEndDate);

                    drInsert["MinAmount"] = Convert.ToString(dcValidateMinAmount);
                    drInsert["MaxAmount"] = Convert.ToString(dcValidateMaxAmount);
                    drInsert["TaxType"] = Convert.ToString(strTaxType);

                    dtTaxData.Rows.Add(drInsert);

                    dtTaxData.DefaultView.Sort = "MinAmount ASC";

                    Session["SaveTaxData"] = dtTaxData;

                    if (this.AcctID != Guid.Empty)
                    {
                        TaxSlabe objToInsert = new TaxSlabe();

                        objToInsert.TaxID = this.AcctID;
                        objToInsert.TaxSlabID = new Guid(Convert.ToString(drInsert["TaxSlabID"]));
                        objToInsert.TaxRate = Convert.ToDecimal(txtGvTaxRate.Text.Trim());
                        objToInsert.IsTaxFlat = Convert.ToBoolean(strIsFlat);
                        objToInsert.MinAmount = Convert.ToDecimal(dcValidateMinAmount);
                        if (dcValidateMaxAmount != null && Convert.ToString(dcValidateMaxAmount) != "")
                            objToInsert.MaxAmount = Convert.ToDecimal(dcValidateMaxAmount);
                        else
                            objToInsert.MaxAmount = null;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.CompanyID = clsSession.CompanyID;

                        TaxSlabeBLL.Save(objToInsert);
                    }

                    if (dtTaxData.Rows.Count > 0)
                    {
                        gvTaxRateList.DataSource = dtTaxData;
                        gvTaxRateList.DataBind();
                    }
                    else
                    {
                        gvTaxRateList.DataSource = null;
                        gvTaxRateList.DataBind();
                    }

                    mpeAddTaxRate.Hide();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void BindGridTaxRate()
        {
            List<TaxRate> lisTaxRate = TaxRateBLL.GetAllBy(TaxRate.TaxRateFields.TaxID, this.AcctID.ToString());

            gvTaxRateList.DataSource = lisTaxRate;
            gvTaxRateList.DataBind();

            for (int i = 0; i < gvTaxRateList.Rows.Count; i++)
            {
                Literal litGvTaxTypeDisplay = (Literal)gvTaxRateList.Rows[i].FindControl("litGvTaxTypeDisplay");
                if (Convert.ToBoolean(litGvTaxTypeDisplay.Text) == true)
                    litGvTaxTypeDisplay.Text = "%";
                else
                    litGvTaxTypeDisplay.Text = "Flat";

                Literal txtGvTaxRate = (Literal)gvTaxRateList.Rows[i].FindControl("litGvTaxRateDisplay");
                txtGvTaxRate.Text = Convert.ToString(txtGvTaxRate.Text.ToString().Substring(0, txtGvTaxRate.Text.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));

                Literal litGvStartDateDisplay = (Literal)gvTaxRateList.Rows[i].FindControl("litGvStartDateDisplay");
                litGvStartDateDisplay.Text = "";
            }
        }

        protected void gvTaxRateList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete1 = (LinkButton)e.Row.FindControl("lnkDelete1");
                    Label lblTaxRateAmount = (Label)e.Row.FindControl("lblTaxRateAmount");
                    Label lblGvDisplayMinAmt = (Label)e.Row.FindControl("lblGvDisplayMinAmt");
                    Label lblGvDisplayMaxAmt = (Label)e.Row.FindControl("lblGvDisplayMaxAmt");

                    decimal dcTaxRateAmount = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TaxRate")));
                    decimal dcminamt = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MinAmount")));

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit1")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit1")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete1.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete1.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete1.OnClientClick = string.Format("return fnConfirmDeleteRow('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TaxSlabID")));

                    lblTaxRateAmount.Text = Convert.ToString(dcTaxRateAmount.ToString().Substring(0, dcTaxRateAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    lblGvDisplayMinAmt.Text = Convert.ToString(dcminamt.ToString().Substring(0, dcminamt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaxAmount")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaxAmount")) != "")
                    {
                        decimal dcmaxamt = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaxAmount")));
                        lblGvDisplayMaxAmt.Text = Convert.ToString(dcmaxamt.ToString().Substring(0, dcmaxamt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    }
                    else
                        lblGvDisplayMaxAmt.Text = "";
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo1")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrTaxRate1")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxRate1", "Tax Rate");
                    ((Label)e.Row.FindControl("lblGvHdrTaxType")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxType", "Type");
                    //((Label)e.Row.FindControl("lblGvHdrStartDate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrStartDate", "Start Date");
                    //((Label)e.Row.FindControl("lblGvHdrEndDate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrEndDate", "End Date");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void gvTaxRateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    this.Mode = "EDITSLABE";
                    mpeAddTaxRate.Show();

                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.indexofGRid = gvr.RowIndex;

                    this.TaxSlabID = new Guid(Convert.ToString(e.CommandArgument));

                    if (Session["SaveTaxData"] != null)
                    {
                        DataTable dtLoadData = (DataTable)Session["SaveTaxData"];

                        DataRow[] dr = dtLoadData.Select("TaxSlabID = '" + Convert.ToString(this.TaxSlabID) + "'");

                        if (dr.Length > 0)
                        {
                            decimal dcTaxRateAmount = Convert.ToDecimal(dr[0]["TaxRate"]);
                            txtGvTaxRate.Text = Convert.ToString(dcTaxRateAmount.ToString().Substring(0, dcTaxRateAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                            bool strFlat = Convert.ToBoolean(dr[0]["IsTaxFlat"]);

                            if (strFlat == false)
                                ddlGvTaxRate.SelectedIndex = 0;
                            else
                                ddlGvTaxRate.SelectedIndex = 1;

                            SetRateMaxValue();

                            decimal dcMinAmt = Convert.ToDecimal(Convert.ToString(dr[0]["MinAmount"]));
                            txtMinAmount.Text = Convert.ToString(dcMinAmt.ToString().Substring(0, dcMinAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                            if (Convert.ToString(dr[0]["MaxAmount"]) != null && Convert.ToString(dr[0]["MaxAmount"]) != "")
                            {
                                decimal dcMaxAmt = Convert.ToDecimal(Convert.ToString(dr[0]["MaxAmount"]));
                                txtMaxAmount.Text = Convert.ToString(dcMaxAmt.ToString().Substring(0, dcMaxAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                            }
                            else
                                txtMaxAmount.Text = "";
                        }
                        else
                        {
                            ddlGvTaxRate.SelectedIndex = 0;
                            txtGvTaxRate.Text = txtMinAmount.Text = txtMaxAmount.Text = "";
                        }
                    }
                    else
                    {
                        ddlGvTaxRate.SelectedIndex = 0;
                        txtGvTaxRate.Text = txtMinAmount.Text = txtMaxAmount.Text = "";
                    }

                    //if (new Guid(Convert.ToString(e.CommandArgument)) != Guid.Empty)
                    //{
                    //    this.TaxRateID = new Guid(Convert.ToString(e.CommandArgument));
                    //    TaxRate taxRateData = new TaxRate();
                    //    taxRateData = TaxRateBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    //    txtGvEndDate.Text = taxRateData.EndDate.ToString();
                    //    txtGvStartDate.Text = taxRateData.StartDate.ToString();
                    //    txtGvTaxRate.Text = taxRateData.TaxRateAmount.ToString();

                    //    if (Convert.ToString(taxRateData.TaxRateAmount) != "")
                    //        txtGvTaxRate.Text = Convert.ToString(taxRateData.TaxRateAmount.ToString().Substring(0, taxRateData.TaxRateAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    //    else
                    //        txtGvTaxRate.Text = "";

                    //    if (taxRateData.IsTaxFlat == true)
                    //    {
                    //        ddlGvTaxRate.SelectedIndex = 1;
                    //    }
                    //    else
                    //    {
                    //        ddlGvTaxRate.SelectedIndex = 2;
                    //    }
                    //}
                    //else
                    //{
                    //    Literal litGvTaxRateDisplayEdit = (Literal)gvTaxRateList.Rows[this.indexofGRid].FindControl("litGvTaxRateDisplay");
                    //    Literal litGvTaxTypeDisplayEdit = (Literal)gvTaxRateList.Rows[this.indexofGRid].FindControl("litGvTaxTypeDisplay");
                    //    Literal litGvStartDateDisplayEdit = (Literal)gvTaxRateList.Rows[this.indexofGRid].FindControl("litGvStartDateDisplay");
                    //    Literal litGvHdrEndDateDisplayEdit = (Literal)gvTaxRateList.Rows[this.indexofGRid].FindControl("litGvHdrEndDateDisplay");

                    //    txtGvEndDate.Text = litGvHdrEndDateDisplayEdit.Text;
                    //    txtGvStartDate.Text = litGvStartDateDisplayEdit.Text;
                    //    txtGvTaxRate.Text = litGvTaxRateDisplayEdit.Text;
                    //    ddlGvTaxRate.SelectedValue = litGvTaxTypeDisplayEdit.Text;


                    //    ////DataColumn dc2 = new DataColumn("TaxRateAmount");
                    //    ////DataColumn dc3 = new DataColumn("IsTaxFlat");
                    //    ////DataColumn dc4 = new DataColumn("StartDate");
                    //    ////DataColumn dc5 = new DataColumn("EndDate");
                    //    ////DataColumn dc6 = new DataColumn("TaxRateID");

                    //    ////dtTaxRate.Columns.Add(dc2);
                    //    ////dtTaxRate.Columns.Add(dc3);
                    //    ////dtTaxRate.Columns.Add(dc4);
                    //    ////dtTaxRate.Columns.Add(dc5);
                    //    ////dtTaxRate.Columns.Add(dc6);

                    //    ////for (int i = 0; i < gvTaxRateList.Rows.Count; i++)
                    //    ////{
                    //    ////    Literal litGvTaxRateDisplay = (Literal)gvTaxRateList.Rows[i].FindControl("litGvTaxRateDisplay");
                    //    ////    Literal litGvTaxTypeDisplay = (Literal)gvTaxRateList.Rows[i].FindControl("litGvTaxTypeDisplay");
                    //    ////    Literal litGvStartDateDisplay = (Literal)gvTaxRateList.Rows[i].FindControl("litGvStartDateDisplay");
                    //    ////    Literal litGvHdrEndDateDisplay = (Literal)gvTaxRateList.Rows[i].FindControl("litGvHdrEndDateDisplay");


                    //    ////    DataRow dr1 = dtTaxRate.NewRow();
                    //    ////    dr1["TaxRateID"] = "00000000-0000-0000-0000-000000000000";
                    //    ////    dr1["TaxRateAmount"] = litGvTaxRateDisplay.Text;
                    //    ////    dr1["IsTaxFlat"] = litGvTaxRateDisplay.Text;
                    //    ////    //DateTime dtDisplaySD = Convert.ToDateTime(litGvStartDateDisplay.Text.ToString());
                    //    ////    //DateTime dtDisplayED = Convert.ToDateTime(litGvHdrEndDateDisplay.Text.ToString());
                    //    ////    dr1["StartDate"] = Convert.ToString(litGvStartDateDisplay.Text.ToString());
                    //    ////    dr1["EndDate"] = Convert.ToString(litGvHdrEndDateDisplay.Text.ToString());
                    //    ////    dtTaxRate.Rows.Add(dr1);

                    //    ////}

                    //    ////dtTaxRate.Rows.RemoveAt(indexofGRid);
                    //    ////dtTaxRate.AcceptChanges();

                    //    ////gvTaxRateList.DataSource = dtTaxRate;
                    //    ////gvTaxRateList.DataBind();
                    //}
                    //mpeAddTaxRate.Show();


                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.indexofGRid = gvr.RowIndex;

                    this.TaxSlabID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeDeleteRowOfDrid.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnDeleteRow_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnDeleteRowOfDrid.Value) != "")
                {
                    mpeDeleteRowOfDrid.Hide();

                    if (Session["SaveTaxData"] != null)
                    {
                        DataTable dtDeleteData = (DataTable)Session["SaveTaxData"];

                        DataRow[] drDelete = dtDeleteData.Select("TaxSlabID = '" + Convert.ToString(hdnDeleteRowOfDrid.Value) + "'");

                        foreach (DataRow dr in drDelete)
                        {
                            dtDeleteData.Rows.Remove(dr);
                        }

                        dtDeleteData.AcceptChanges();

                        dtDeleteData.DefaultView.Sort = "MinAmount ASC";

                        Session["SaveTaxData"] = dtDeleteData;

                        gvTaxRateList.DataSource = dtDeleteData;
                        gvTaxRateList.DataBind();
                    }

                    if (this.AcctID != Guid.Empty)
                    {
                        TaxSlabe objDelete = new TaxSlabe();
                        objDelete = TaxSlabeBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnDeleteRowOfDrid.Value)));

                        TaxSlabeBLL.Delete(objDelete);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "acc_TaxSlabe");
                    }

                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void ddlGvTaxRate_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlGvTaxRate.SelectedIndex == 0)
            //    rvGvTaxRate.Enabled = true;
            //else
            //    rvGvTaxRate.Enabled = false;

            SetRateMaxValue();
            mpeAddTaxRate.Show();
        }

        protected void ddlAccountTaxType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SetAccountTaxRateMaxValue();
        }
    }
}