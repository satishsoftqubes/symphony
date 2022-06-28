using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlBookingAgent : System.Web.UI.UserControl
    {
        #region Property and Variables
        public Guid CorporateID
        {
            get
            {
                return ViewState["CorporateID"] != null ? new Guid(Convert.ToString(ViewState["CorporateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CorporateID"] = value;
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
        public bool IsFeedbackMessage = false;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                BindData();

                if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "AGENT")
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.CorporateID = clsSession.ToEditItemID;
                    //To use this.CorporateID in binding of Default RateCard...                    
                    LoadCorporateData();
                }
                BindBreadCrumb();
            }
        }
        #endregion

        #region Control Events

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ////Corporate objToCheckDuplicate = new Corporate();
                    ////objToCheckDuplicate.IsActive = true;
                    ////objToCheckDuplicate.CompanyID = clsSession.CompanyID;
                    ////objToCheckDuplicate.PropertyID = clsSession.PropertyID;
                    ////objToCheckDuplicate.CompanyName = txtCompanyName.Text.Trim();


                    ////List<Corporate> lstCorporates = CorporateBLL.GetAll(objToCheckDuplicate);
                    ////if (lstCorporates.Count > 0)
                    ////{
                    ////    if (this.CorporateID != Guid.Empty)
                    ////    {
                    ////        //Edit Mode
                    ////        if (lstCorporates[0].CorporateID != this.CorporateID)
                    ////        {
                    ////            IsFeedbackMessage = true;
                    ////            litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("Corporate", "lblMsgRecordWithSameCodeExists", "Corporate with same code already exist.");
                    ////            return;
                    ////        }
                    ////    }
                    ////    else
                    ////    {
                    ////        IsFeedbackMessage = true;
                    ////        litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("Corporate", "lblMsgRecordWithSameCodeExists", "Corporate with same code already exist.");
                    ////        return;
                    ////    }
                    ////}

                    if (this.CorporateID != Guid.Empty)
                    {
                        //Edit mode.
                        //Object declaration
                        Corporate objToUpdate = CorporateBLL.GetByPrimaryKey(this.CorporateID);
                        Corporate objOldToUpdate = CorporateBLL.GetByPrimaryKey(this.CorporateID);
                        Address objAddressToUpdate = null;
                        Address objOldAddressToUpdate = null;

                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.UpdatedOn = DateTime.Now;
                        objToUpdate.CompanyName = txtCompanyName.Text.Trim();
                        objToUpdate.Title = Convert.ToString(ddlTitle.SelectedValue);
                        objToUpdate.FName = txtFName.Text.Trim();
                        objToUpdate.LName = txtLName.Text.Trim();
                        objToUpdate.Email = txtEmail.Text.Trim();

                        //objToUpdate.IsDirectBill = chkIsDirectBill.Checked;
                        objToUpdate.IsComission = chkIsCommission.Checked;

                        if (ddlLedgerAccount.SelectedIndex != 0)
                            objToUpdate.DBAcctID = new Guid(ddlLedgerAccount.SelectedValue);
                        else
                            objToUpdate.DBAcctID = null;

                        if (Convert.ToBoolean(objToUpdate.IsComission))
                        {
                            if (txtCommission.Text.Trim() != null)
                                objToUpdate.ComissionValue = Convert.ToDecimal(txtCommission.Text.Trim());
                            else
                                objToUpdate.ComissionValue = null;

                            objToUpdate.IsComissionFlat = ddlCommissionType.SelectedIndex != 0;

                            for (int i = 0; i < rdbLstComissionFlag.Items.Count; i++)
                            {
                                if (rdbLstComissionFlag.Items[i].Selected)
                                {
                                    objToUpdate.ComissionFlag_TermID = new Guid(rdbLstComissionFlag.SelectedValue.ToString());
                                    break;
                                }
                            }
                        }
                        else
                        {
                            objToUpdate.ComissionValue = null;
                            objToUpdate.IsComissionFlat = null;
                            objToUpdate.ComissionFlag_TermID = null;
                        }

                        objToUpdate.IsBlock = chkDisableAgent.Checked;
                        objToUpdate.BlockReason = txtDisableReason.Text.Trim();

                        DataSet dsCorporate = CorporateBLL.GetDataSetByPrimaryKey(this.CorporateID);
                        if (dsCorporate != null && Convert.ToString(dsCorporate.Tables[0].Rows[0]["AddressID"]) != string.Empty)
                        {
                            objAddressToUpdate = AddressBLL.GetByPrimaryKey(new Guid(Convert.ToString(dsCorporate.Tables[0].Rows[0]["AddressID"])));
                            objOldAddressToUpdate = AddressBLL.GetByPrimaryKey(new Guid(Convert.ToString(dsCorporate.Tables[0].Rows[0]["AddressID"])));

                            objAddressToUpdate.Add1 = ucCtrlAddress.strAddress;
                            objAddressToUpdate.CityID = clsCommon.City(ucCtrlAddress.strCity);
                            objAddressToUpdate.StateID = clsCommon.State(ucCtrlAddress.strState);
                            objAddressToUpdate.CountryID = clsCommon.Country(ucCtrlAddress.strCountry);
                            objAddressToUpdate.ZipCode = ucCtrlAddress.strZipCode;

                            objToUpdate.AddressID = new Guid(Convert.ToString(dsCorporate.Tables[0].Rows[0]["AddressID"]));
                        }

                        ////objToUpdate.MobileNo = Convert.ToString(txtMobileNo.Text.Trim());
                        if (txtMobileCntNo.Text.Trim() == "")
                            objToUpdate.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            objToUpdate.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();


                        CorporateBLL.Update(objToUpdate, objAddressToUpdate);

                        //Save action log.
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldToUpdate.ToString() + "<br/><br/>" + objOldAddressToUpdate.ToString(), objToUpdate.ToString() + "<br/><br/>" + objOldAddressToUpdate.ToString(), "mst_Corporate");
                        IsFeedbackMessage = true;
                        litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        ClearControl();
                    }
                    else
                    {
                        //Insert Mode
                        //Object declaration
                        Corporate objToInsert = new Corporate();
                        Address objAddressToInsert = null;

                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.IsActive = true;
                        objToInsert.CompanyName = txtCompanyName.Text.Trim();
                        objToInsert.Title = Convert.ToString(ddlTitle.SelectedValue);
                        objToInsert.FName = txtFName.Text.Trim();
                        objToInsert.LName = txtLName.Text.Trim();
                        objToInsert.Email = txtEmail.Text.Trim();

                        ////objToInsert.MobileNo = Convert.ToString(txtMobileNo.Text.Trim());

                        if (txtMobileCntNo.Text.Trim() == "")
                            objToInsert.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            objToInsert.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();

                        objToInsert.IsDirectBill = false;
                        objToInsert.IsComission = chkIsCommission.Checked;

                        if (ddlLedgerAccount.SelectedIndex != 0)
                            objToInsert.DBAcctID = new Guid(ddlLedgerAccount.SelectedValue);


                        if (Convert.ToBoolean(objToInsert.IsComission))
                        {
                            if (txtCommission.Text.Trim() != null)
                                objToInsert.ComissionValue = Convert.ToDecimal(txtCommission.Text.Trim());

                            objToInsert.IsComissionFlat = ddlCommissionType.SelectedIndex != 0;

                            for (int i = 0; i < rdbLstComissionFlag.Items.Count; i++)
                            {
                                if (rdbLstComissionFlag.Items[i].Selected)
                                {
                                    objToInsert.ComissionFlag_TermID = new Guid(rdbLstComissionFlag.SelectedValue.ToString());
                                    break;
                                }
                            }
                        }

                        objToInsert.IsBlock = chkDisableAgent.Checked;
                        objToInsert.BlockReason = txtDisableReason.Text.Trim();

                        objAddressToInsert = new Address();

                        objAddressToInsert.Add1 = ucCtrlAddress.strAddress;
                        objAddressToInsert.CityID = clsCommon.City(ucCtrlAddress.strCity);
                        objAddressToInsert.StateID = clsCommon.State(ucCtrlAddress.strState);
                        objAddressToInsert.CountryID = clsCommon.Country(ucCtrlAddress.strCountry);
                        objAddressToInsert.ZipCode = ucCtrlAddress.strZipCode;
                        objAddressToInsert.CompanyID = clsSession.CompanyID;
                        objAddressToInsert.IsActive = true;

                        CorporateBLL.Save(objToInsert, objAddressToInsert);

                        //Save action log.
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString() + "<br/><br/>" + objAddressToInsert.ToString(), objToInsert.ToString() + "<br/><br/>" + objAddressToInsert.ToString(), "mst_Corporate");

                        IsFeedbackMessage = true;
                        litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        ClearControl();
                    }

                    BindBreadCrumb();
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
            clsSession.ToEditItemID = Guid.Empty;
            ClearControl();
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/BookingAgentList.aspx");
        }

        protected void chkIsCommission_OnCheckedChanged(object sender, EventArgs e)
        {
            txtCommission.Enabled = rvfCommission.Enabled = rdbLstComissionFlag.Enabled = ddlCommissionType.Enabled = chkIsCommission.Checked;
            chkIsCommission.Font.Bold = chkIsCommission.Checked;

            if (chkIsCommission.Checked == false)
            {
                txtCommission.Text = "";
                ddlCommissionType.SelectedIndex = 0;
            }
        }

        protected void chkDisableAgent_OnCheckedChanged(object sender, EventArgs e)
        {
            txtDisableReason.Enabled = rfvDisableReason.Enabled = chkDisableAgent.Checked;
            chkDisableAgent.Font.Bold = chkDisableAgent.Checked;
            if (chkDisableAgent.Checked == false)
                txtDisableReason.Text = "";

        }

        protected void ddlCommissionType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommissionMaxValue();
        }

        public void SetCommissionMaxValue()
        {
            if (ddlCommissionType.SelectedIndex == 0)
                rngvCommission.MaximumValue = "100";
            else
                rngvCommission.MaximumValue = "9999999999999";
        }

        #endregion

        #region Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CORPORATESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                regExpCommission.ValidationExpression = "\\d{0,24}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regExpCommission.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
                SetAddressControlValidation();
                SetPageLabels();
                BindDDLs();
                SetCommissionMaxValue();
                BindLedgerAccount();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = "BOOKING AGENT"; ////clsCommon.GetGlobalResourceText("Corporate", "lblMainHeader", "Corporate Information");
            litCompanyName.Text = "Company Name";
            litTitleFnameLname.Text = "Name"; //clsCommon.GetGlobalResourceText("Corporate", "lblTitleFnameLname", "Title/Fname/Lname");
            litHeaderAddress.Text = "Address";//// clsCommon.GetGlobalResourceText("Corporate", "lblHeaderAddress", "Address Information");
            chkIsCommission.Text = clsCommon.GetGlobalResourceText("Corporate", "lblIsCommission", "Is Commission");
            chkDisableAgent.Text = clsCommon.GetGlobalResourceText("Corporate", "lblDisableAgentWithReason", "Disable Agent With Reason");
            litEmail.Text = clsCommon.GetGlobalResourceText("Corporate", "lblEmail", "Email");
            //chkIsDirectBill.Text = clsCommon.GetGlobalResourceText("Corporate", "lblIsDirectBill");
            litLedgerAccount.Text = clsCommon.GetGlobalResourceText("Corporate", "lblLedgerAccount", "Ledger Account");

            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            rngvCommission.Text = clsCommon.GetGlobalResourceText("Discount", "lblMsgRateLimitInPercentage", "% should be less than or equal to 100.");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
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

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Booking Agent List";
            dr3["Link"] = "~/GUI/PriceManager/BookingAgentList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = txtCompanyName.Text.Trim() == string.Empty ? "Booking Agent" : txtCompanyName.Text.Trim();
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetAddressControlValidation()
        {
            List<PropertyConfiguration> lstProConfigs = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, clsSession.PropertyID.ToString());
            if (lstProConfigs != null && lstProConfigs.Count > 0)
            {
                ucCtrlAddress.rfvAddress.Enabled = ucCtrlAddress.rfvCity.Enabled = ucCtrlAddress.rfvState.Enabled = ucCtrlAddress.rfvCountry.Enabled = !Convert.ToBoolean(lstProConfigs[0].IsSkipAddress);
                ucCtrlAddress.rfvZipCode.Enabled = !Convert.ToBoolean(lstProConfigs[0].IsSkipPostCode);

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipAddress))
                {
                    ucCtrlAddress.tcAddress.Attributes.Add("class", "isrequire");
                    ucCtrlAddress.tcCity.Attributes.Add("class", "isrequire");
                    ucCtrlAddress.tcState.Attributes.Add("class", "isrequire");
                    ucCtrlAddress.tcCountry.Attributes.Add("class", "isrequire");
                }

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipPostCode))
                {
                    ucCtrlAddress.tcZipcode.Attributes.Add("class", "isrequire");
                }

                rfvEmail.Enabled = !(Convert.ToBoolean(lstProConfigs[0].IsSkipEmail));

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipEmail))
                    tdEmail.Attributes.Add("class", "isrequire");
            }
        }

        private void BindDDLs()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "TITLE");
            if (lstProjectTermTitle.Count != 0)
            {
                ddlTitle.DataSource = lstProjectTermTitle;
                ddlTitle.DataTextField = "DisplayTerm";
                ddlTitle.DataValueField = "Term";
                ddlTitle.DataBind();
                ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            List<ProjectTerm> lstCommissionFlag = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "DISCOUNTTYPE");
            if (lstCommissionFlag != null && lstCommissionFlag.Count > 0)
            {
                rdbLstComissionFlag.DataSource = lstCommissionFlag;
                rdbLstComissionFlag.DataTextField = "DisplayTerm";
                rdbLstComissionFlag.DataValueField = "TermID";
                rdbLstComissionFlag.DataBind();
                rdbLstComissionFlag.Items[0].Selected = true;
            }

            ddlCommissionType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlCommissionType.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));
        }

        private void LoadCorporateData()
        {
            try
            {
                this.CorporateID = clsSession.ToEditItemID;

                Corporate objToLoadData = CorporateBLL.GetByPrimaryKey(this.CorporateID);

                if (objToLoadData != null)
                {
                    txtCompanyName.Text = Convert.ToString(objToLoadData.CompanyName);
                    ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(objToLoadData.Title)) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(objToLoadData.Title))) : 0;
                    txtFName.Text = Convert.ToString(objToLoadData.FName);
                    txtLName.Text = Convert.ToString(objToLoadData.LName);
                    txtEmail.Text = Convert.ToString(objToLoadData.Email);

                    ddlLedgerAccount.SelectedIndex = ddlLedgerAccount.Items.FindByValue(Convert.ToString(objToLoadData.DBAcctID)) != null ? ddlLedgerAccount.Items.IndexOf(ddlLedgerAccount.Items.FindByValue(Convert.ToString(objToLoadData.DBAcctID))) : 0;

                    //txtMobileNo.Text = Convert.ToString(objToLoadData.MobileNo);
                    if (Convert.ToString(objToLoadData.MobileNo) != "" && objToLoadData.MobileNo != null)
                    {
                        string[] words = objToLoadData.MobileNo.Split('-');
                        if (words.Length > 1)
                        {
                            txtMobileCntNo.Text = Convert.ToString(words[0]);
                            txtMobileNo.Text = Convert.ToString(words[1]);
                        }
                        else
                        {
                            txtMobileCntNo.Text = Convert.ToString(words[0]);
                            txtMobileNo.Text = "";
                        }
                    }
                    else
                    {
                        txtMobileCntNo.Text = "";
                        txtMobileNo.Text = "";
                    }

                    //chkIsDirectBill.Checked = Convert.ToBoolean(objToLoadData.IsDirectBill);
                    chkIsCommission.Checked = Convert.ToBoolean(objToLoadData.IsComission);

                    if (chkIsCommission.Checked)
                    {
                        chkIsCommission.Font.Bold = true;
                        txtCommission.Enabled = rvfCommission.Enabled = rdbLstComissionFlag.Enabled = ddlCommissionType.Enabled = true;
                        if (Convert.ToString(objToLoadData.ComissionValue) != string.Empty)
                            txtCommission.Text = objToLoadData.ComissionValue.ToString().Substring(0, objToLoadData.ComissionValue.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                        if (Convert.ToBoolean(objToLoadData.IsComissionFlat))
                            ddlCommissionType.SelectedIndex = 1;
                        else
                            ddlCommissionType.SelectedIndex = 0;

                        SetCommissionMaxValue();

                        if (objToLoadData.ComissionFlag_TermID != null)
                            for (int i = 0; i < rdbLstComissionFlag.Items.Count; i++)
                            {
                                if (rdbLstComissionFlag.Items[i].Value.ToString() == Convert.ToString(objToLoadData.ComissionFlag_TermID))
                                {
                                    rdbLstComissionFlag.Items[i].Selected = true;
                                    break;
                                }
                            }
                    }
                    else
                        chkIsCommission.Font.Bold = false;

                    chkDisableAgent.Checked = rfvDisableReason.Enabled = Convert.ToBoolean(objToLoadData.IsBlock);
                    chkDisableAgent.Font.Bold = chkDisableAgent.Checked;
                    txtDisableReason.Text = Convert.ToString(objToLoadData.BlockReason);
                    txtDisableReason.Enabled = chkDisableAgent.Checked;

                    //To Get record in DataSet with city,state,country name.
                    DataSet dsCorporate = CorporateBLL.GetDataSetByPrimaryKey(this.CorporateID);

                    if (dsCorporate != null && Convert.ToString(dsCorporate.Tables[0].Rows[0]["AddressID"]) != string.Empty)
                    {
                        Address objAdrsToGetList = new Address();
                        objAdrsToGetList.AddressID = new Guid(Convert.ToString(dsCorporate.Tables[0].Rows[0]["AddressID"]));
                        objAdrsToGetList.IsActive = true;
                        DataSet dsAddress = AddressBLL.GetAllWithDataSet(objAdrsToGetList);

                        if (dsAddress != null && dsAddress.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = dsAddress.Tables[0].Rows[0];
                            ucCtrlAddress.strAddress = Convert.ToString(dr["Add1"]);
                            ucCtrlAddress.strCity = Convert.ToString(dr["CityName"]);
                            ucCtrlAddress.strState = Convert.ToString(dr["StateName"]);
                            ucCtrlAddress.strCountry = Convert.ToString(dr["CountryName"]);
                            ucCtrlAddress.strZipCode = Convert.ToString(dr["ZipCode"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            clsSession.ToEditItemID = this.CorporateID = Guid.Empty;
            txtMobileCntNo.Text = txtMobileNo.Text = txtCompanyName.Text = txtFName.Text = txtLName.Text = txtEmail.Text = string.Empty;
            //chkIsDirectBill.Checked = false;
            ddlTitle.SelectedIndex = ddlLedgerAccount.SelectedIndex = 0;
            chkIsCommission.Checked = chkDisableAgent.Checked = chkIsCommission.Font.Bold = chkDisableAgent.Font.Bold = false;
            rdbLstComissionFlag.SelectedIndex = 0;
            txtCommission.Enabled = rvfCommission.Enabled = rdbLstComissionFlag.Enabled = ddlCommissionType.Enabled = txtDisableReason.Enabled = false;
            rngvCommission.MaximumValue = "100";
            txtCommission.Text = txtDisableReason.Text = string.Empty;
            ddlCommissionType.SelectedIndex = 0;
            ucCtrlAddress.strAddress = ucCtrlAddress.strCity = ucCtrlAddress.strState = ucCtrlAddress.strCountry = ucCtrlAddress.strZipCode = string.Empty;
        }

        private void BindLedgerAccount()
        {
            ddlLedgerAccount.Items.Clear();
            string strQuery = "select AcctID,AcctName from acc_Account where SymphonyAcctGroupID = 2 and IsEnable = 1 and IsActive = 1 and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' order by AcctName";
            DataSet dsAccount = RoomBLL.GetUnitNo(strQuery);
            ddlLedgerAccount.Items.Clear();
            if (dsAccount != null && dsAccount.Tables.Count > 0 && dsAccount.Tables[0].Rows.Count > 0)
            {
                ddlLedgerAccount.DataSource = dsAccount.Tables[0];
                ddlLedgerAccount.DataTextField = "AcctName";
                ddlLedgerAccount.DataValueField = "AcctID";
                ddlLedgerAccount.DataBind();
                ddlLedgerAccount.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlLedgerAccount.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
        }

        #endregion
    }
}