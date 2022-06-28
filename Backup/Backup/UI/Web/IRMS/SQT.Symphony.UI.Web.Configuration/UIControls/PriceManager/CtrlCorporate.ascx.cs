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
    public partial class CtrlCorporate : System.Web.UI.UserControl
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

                if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CORPORATE")
                {
                    btnSave.Visible = lnkRemoveVoucher.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.CorporateID = clsSession.ToEditItemID;
                    //To use this.CorporateID in binding of Default RateCard...
                    BindDDLDefaultRateCard();
                    LoadCorporateData();
                }
                else
                    BindDDLDefaultRateCard();

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
                    Corporate objToCheckDuplicate = new Corporate();
                    objToCheckDuplicate.IsActive = true;
                    objToCheckDuplicate.CompanyID = clsSession.CompanyID;
                    objToCheckDuplicate.PropertyID = clsSession.PropertyID;
                    objToCheckDuplicate.CompanyName = txtCompanyName.Text.Trim();
                    objToCheckDuplicate.IsDirectBill = true;

                    List<Corporate> lstCorporates = CorporateBLL.GetAll(objToCheckDuplicate);
                    if (lstCorporates.Count > 0)
                    {
                        if (this.CorporateID != Guid.Empty)
                        {
                            //Edit Mode
                            if (lstCorporates[0].CorporateID != this.CorporateID)
                            {
                                IsFeedbackMessage = true;
                                litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("Corporate", "lblMsgRecordWithSameCodeExists", "Corporate with same code already exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsFeedbackMessage = true;
                            litFeedbackMessage.Text = clsCommon.GetGlobalResourceText("Corporate", "lblMsgRecordWithSameCodeExists", "Corporate with same code already exist.");
                            return;
                        }
                    }

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

                        objToUpdate.Code = txtCode.Text.Trim();
                        objToUpdate.CompanyName = txtCompanyName.Text.Trim();
                        objToUpdate.Title = Convert.ToString(ddlTitle.SelectedValue);
                        objToUpdate.FName = txtFName.Text.Trim();
                        objToUpdate.LName = txtLName.Text.Trim();
                        objToUpdate.DisplayName = txtDisplayName.Text.Trim();
                        objToUpdate.Email = txtEmail.Text.Trim();
                        objToUpdate.ContactNo = txtContactNo.Text.Trim();
                        objToUpdate.Fax = txtFax.Text.Trim();

                        if (ddlLedgerAccount.SelectedIndex != 0)
                            objToUpdate.DBAcctID = new Guid(ddlLedgerAccount.SelectedValue);
                        else
                            objToUpdate.DBAcctID = null;

                        if (txtTurnOver.Text.Trim() != string.Empty)
                            objToUpdate.Turnover = Convert.ToDecimal(txtTurnOver.Text.Trim());
                        else
                            objToUpdate.Turnover = null;

                        //// Don't update this value in Company's Edit mode, b'cas this ddl not come in UI now.
                        //if (ddlCorporateType.SelectedIndex != 0)
                        //    objToUpdate.CorporateType_TermID = new Guid(ddlCorporateType.SelectedValue);
                        //else
                        //    objToUpdate.CorporateType_TermID = null;

                        if (ddlDefaultReservationStatus.SelectedIndex != 0)
                            objToUpdate.DefaultResStatus_TermID = new Guid(ddlDefaultReservationStatus.SelectedValue);
                        else
                            objToUpdate.DefaultResStatus_TermID = null;

                        if (ddlDefaultRateCard.SelectedIndex != 0)
                            objToUpdate.DefaultRateID = new Guid(ddlDefaultRateCard.SelectedValue);
                        else
                            objToUpdate.DefaultRateID = null;

                        //objToUpdate.IsDirectBill = chkIsDirectBill.Checked;
                        objToUpdate.IsComission = chkIsCommission.Checked;

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

                        if (fuVoucher.FileName != "")
                        {
                            string strDirPath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "CompanyMaster");

                            if (!Directory.Exists(strDirPath))
                                Directory.CreateDirectory(strDirPath);

                            string VoucherPhoto = Guid.NewGuid() + "$" + fuVoucher.FileName.Replace(" ", "_");
                            string path = strDirPath + "/" + VoucherPhoto;

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuVoucher.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();
                            objToUpdate.VoucherImage = VoucherPhoto;
                        }

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

                        objToUpdate.VoucherTitle = Convert.ToString(txtVoucherTitle.Text.Trim());
                        ////objToUpdate.MobileNo = Convert.ToString(txtMobileNo.Text.Trim());

                        if (txtMobileCntNo.Text.Trim() == "")
                            objToUpdate.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            objToUpdate.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();


                        objToUpdate.Department = Convert.ToString(txtDepartment.Text.Trim());
                        objToUpdate.Designation = Convert.ToString(txtDesignation.Text.Trim());

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

                        objToInsert.Code = txtCode.Text.Trim();
                        objToInsert.CompanyName = txtCompanyName.Text.Trim();
                        objToInsert.Title = Convert.ToString(ddlTitle.SelectedValue);
                        objToInsert.FName = txtFName.Text.Trim();
                        objToInsert.LName = txtLName.Text.Trim();
                        objToInsert.DisplayName = txtDisplayName.Text.Trim();
                        objToInsert.Email = txtEmail.Text.Trim();
                        objToInsert.ContactNo = txtContactNo.Text.Trim();
                        objToInsert.Fax = txtFax.Text.Trim();
                        objToInsert.VoucherTitle = Convert.ToString(txtVoucherTitle.Text.Trim());

                        if (ddlLedgerAccount.SelectedIndex != 0)
                            objToInsert.DBAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        //objToInsert.MobileNo = Convert.ToString(txtMobileNo.Text.Trim());

                        if (txtMobileCntNo.Text.Trim() == "")
                            objToInsert.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            objToInsert.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();


                        objToInsert.Department = Convert.ToString(txtDepartment.Text.Trim());
                        objToInsert.Designation = Convert.ToString(txtDesignation.Text.Trim());

                        if (txtTurnOver.Text.Trim() != string.Empty)
                            objToInsert.Turnover = Convert.ToDecimal(txtTurnOver.Text.Trim());

                        //if (ddlCorporateType.SelectedIndex != 0)
                        //    objToInsert.CorporateType_TermID = new Guid(ddlCorporateType.SelectedValue);
                        for (int i = 0; i < ddlCorporateType.Items.Count; i++)
                        {
                            if (ddlCorporateType.Items[i].Text.ToUpper() == "DIRECT BIL")
                                objToInsert.CorporateType_TermID = new Guid(Convert.ToString(ddlCorporateType.Items[i].Value));
                        }

                            if (ddlDefaultReservationStatus.SelectedIndex != 0)
                                objToInsert.DefaultResStatus_TermID = new Guid(ddlDefaultReservationStatus.SelectedValue);

                        if (ddlDefaultRateCard.SelectedIndex != 0)
                            objToInsert.DefaultRateID = new Guid(ddlDefaultRateCard.SelectedValue);

                        objToInsert.IsDirectBill = true;
                        objToInsert.IsComission = null;

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

                        if (fuVoucher.FileName != "")
                        {
                            string strDirPath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "CompanyMaster");

                            if (!Directory.Exists(strDirPath))
                                Directory.CreateDirectory(strDirPath);

                            string VoucherPhoto = Guid.NewGuid() + "$" + fuVoucher.FileName.Replace(" ", "_");
                            string path = strDirPath + "/" + VoucherPhoto;

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuVoucher.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();
                            objToInsert.VoucherImage = VoucherPhoto;
                        }
                        else
                            objToInsert.VoucherImage = "BusinessCard.png";

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
            Response.Redirect("~/GUI/PriceManager/CorporateList.aspx");
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

        protected void lnkRemoveVoucher_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.CorporateID != Guid.Empty)
                {
                    Corporate objCorporate = CorporateBLL.GetByPrimaryKey(this.CorporateID);

                    string deletepath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "CompanyMaster/" + Convert.ToString(objCorporate.VoucherImage));

                    if (File.Exists(deletepath))
                        File.Delete(deletepath);

                    CorporateBLL.UpdateVoucherImage(clsSession.CompanyID, clsSession.PropertyID, this.CorporateID, "BusinessCard.png");

                    imgVoucher.ImageUrl = "~/images/BusinessCard.png";
                    lnkRemoveVoucher.Visible = false;

                    IsFeedbackMessage = true;
                    litFeedbackMessage.Text = "Voucher Removed Successfully.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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
                regExpCommission.ValidationExpression = regTurnOver.ValidationExpression = "\\d{0,24}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regTurnOver.ErrorMessage = regExpCommission.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
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
            litMainHeader.Text = "Company Information"; ////clsCommon.GetGlobalResourceText("Corporate", "lblMainHeader", "Corporate Information");
            litCode.Text = clsCommon.GetGlobalResourceText("Corporate", "lblCode", "Code");
            litCompanyName.Text = clsCommon.GetGlobalResourceText("Corporate", "lblCompanyName", "Company Name");
            litTitleFnameLname.Text = "Contact Person Name"; //clsCommon.GetGlobalResourceText("Corporate", "lblTitleFnameLname", "Title/Fname/Lname");
            litDisplayName.Text = clsCommon.GetGlobalResourceText("Corporate", "lblDisplayName", "Dispaly Name");
            litCorporateType.Text = clsCommon.GetGlobalResourceText("Corporate", "lblCorporateType", "Corporate Type");
            litTurnOver.Text = clsCommon.GetGlobalResourceText("Corporate", "lblTurnOver", "Turn Over");
            litDefaultReservationStatus.Text = clsCommon.GetGlobalResourceText("Corporate", "lblDefaultReservationStatus", "Default Reservation Status");
            litDefaultRateCard.Text = clsCommon.GetGlobalResourceText("Corporate", "litDefaultRateCard", "Default RateCard");
            litHeaderAddress.Text = "Address";//// clsCommon.GetGlobalResourceText("Corporate", "lblHeaderAddress", "Address Information");
            chkIsCommission.Text = clsCommon.GetGlobalResourceText("Corporate", "lblIsCommission", "Is Commission");
            chkDisableAgent.Text = clsCommon.GetGlobalResourceText("Corporate", "lblDisableAgentWithReason", "Disable Agent With Reason");
            litEmail.Text = clsCommon.GetGlobalResourceText("Corporate", "lblEmail", "Email");
            litContactNo.Text = clsCommon.GetGlobalResourceText("Corporate", "lblContactNo", "Contact No");
            litFax.Text = clsCommon.GetGlobalResourceText("Corporate", "lblFax", "Fax");
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCorporateList", "Corporate List");
            dr3["Link"] = "~/GUI/PriceManager/CorporateList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = txtDisplayName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblCorporate", "Corporate") : txtDisplayName.Text.Trim();
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
                rfvContactNo.Enabled = !(Convert.ToBoolean(lstProConfigs[0].IsSkipContactNo));


                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipEmail))
                    tdEmail.Attributes.Add("class", "isrequire");

                if (!Convert.ToBoolean(lstProConfigs[0].IsSkipContactNo))
                    tdContactNo.Attributes.Add("class", "isrequire");
            }
        }

        private void BindDDLs()
        {
            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "TITLE");
            if (lstProjectTermTitle.Count != 0)
            {
                ddlTitle.DataSource = lstProjectTermTitle;
                ddlTitle.DataTextField = "DisplayTerm";
                ddlTitle.DataValueField = "Term";
                ddlTitle.DataBind();
                ddlTitle.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlTitle.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

            List<ProjectTerm> lstCorporateType = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "CORPORATETYPE");
            if (lstCorporateType.Count != 0)
            {
                ddlCorporateType.DataSource = lstCorporateType;
                //ddlCorporateType.DataTextField = "DisplayTerm";
                ddlCorporateType.DataTextField = "Term";// This ddl not visible in UI and to use it's value at time of save.
                ddlCorporateType.DataValueField = "TermID";
                ddlCorporateType.DataBind();
                ddlCorporateType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlCorporateType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

            List<ProjectTerm> lstReservationStatus = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "RESERVATIONSTATUS");
            if (lstReservationStatus.Count != 0)
            {
                ddlDefaultReservationStatus.DataSource = lstReservationStatus;
                ddlDefaultReservationStatus.DataTextField = "DisplayTerm";
                ddlDefaultReservationStatus.DataValueField = "TermID";
                ddlDefaultReservationStatus.DataBind();
                ddlDefaultReservationStatus.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

                ProjectTerm pTermToSelectStatus = new ProjectTerm();
                pTermToSelectStatus.CompanyID = clsSession.CompanyID;
                pTermToSelectStatus.PropertyID = clsSession.PropertyID;
                pTermToSelectStatus.IsActive = pTermToSelectStatus.IsDefault = true;
                pTermToSelectStatus.Term = "Guaranteed";
                pTermToSelectStatus.Category = "RESERVATIONSTATUS";
                List<ProjectTerm> lstToSelect = ProjectTermBLL.GetAll(pTermToSelectStatus);
                if (lstToSelect != null && lstToSelect.Count > 0)
                {
                    ddlDefaultReservationStatus.SelectedIndex = ddlDefaultReservationStatus.Items.FindByValue(Convert.ToString(lstToSelect[0].TermID)) != null ? ddlDefaultReservationStatus.Items.IndexOf(ddlDefaultReservationStatus.Items.FindByValue(Convert.ToString(lstToSelect[0].TermID))) : 0;
                }

            }
            else
                ddlDefaultReservationStatus.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

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

        private void BindDDLDefaultRateCard()
        {
            try
            {
                if (this.CorporateID != Guid.Empty)
                {
                    ////trDefaultRateCard.Visible = true;
                    DataSet dsRateCards = RateCardBLL.GetAllForCorporate(clsSession.PropertyID, clsSession.CompanyID, this.CorporateID, "CORPORATE");
                    if (dsRateCards != null && dsRateCards.Tables[0].Rows.Count > 0)
                    {
                        ddlDefaultRateCard.DataSource = dsRateCards.Tables[0];
                        ddlDefaultRateCard.DataTextField = "RateCardName";
                        ddlDefaultRateCard.DataValueField = "RateID";
                        ddlDefaultRateCard.DataBind();
                        ddlDefaultRateCard.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                    }
                    else
                        ddlDefaultRateCard.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
                else
                {
                    ////trDefaultRateCard.Visible = false;
                    ddlDefaultRateCard.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadCorporateData()
        {
            try
            {
                this.CorporateID = clsSession.ToEditItemID;

                Corporate objToLoadData = CorporateBLL.GetByPrimaryKey(this.CorporateID);

                if (objToLoadData != null)
                {
                    txtCode.Text = Convert.ToString(objToLoadData.Code);
                    txtCompanyName.Text = Convert.ToString(objToLoadData.CompanyName);
                    ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(objToLoadData.Title)) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(objToLoadData.Title))) : 0;
                    txtFName.Text = Convert.ToString(objToLoadData.FName);
                    txtLName.Text = Convert.ToString(objToLoadData.LName);
                    txtDisplayName.Text = Convert.ToString(objToLoadData.DisplayName);
                    txtEmail.Text = Convert.ToString(objToLoadData.Email);
                    txtContactNo.Text = Convert.ToString(objToLoadData.ContactNo);
                    txtFax.Text = Convert.ToString(objToLoadData.Fax);

                    txtVoucherTitle.Text = Convert.ToString(objToLoadData.VoucherTitle);

                    ddlLedgerAccount.SelectedIndex = ddlLedgerAccount.Items.FindByValue(Convert.ToString(objToLoadData.DBAcctID)) != null ? ddlLedgerAccount.Items.IndexOf(ddlLedgerAccount.Items.FindByValue(Convert.ToString(objToLoadData.DBAcctID))) : 0;

                    ////txtMobileNo.Text = Convert.ToString(objToLoadData.MobileNo);
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

                    txtDepartment.Text = Convert.ToString(objToLoadData.Department);
                    txtDesignation.Text = Convert.ToString(objToLoadData.Designation);

                    if (Convert.ToString(objToLoadData.VoucherImage) != "" && Convert.ToString(objToLoadData.VoucherImage) != null)
                    {
                        if (objToLoadData.VoucherImage.ToUpper().Trim() == "BUSINESSCARD.PNG")
                        {
                            imgVoucher.ImageUrl = "~/images/BusinessCard.png";
                            lnkRemoveVoucher.Visible = false;
                        }
                        else
                        {
                            string str = "~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "CompanyMaster/" + Convert.ToString(objToLoadData.VoucherImage);
                            string mappath = Server.MapPath(str);
                            FileInfo f = new FileInfo(mappath);
                            if (f.Exists)
                            {
                                lnkRemoveVoucher.Visible = true;
                                imgVoucher.ImageUrl = str;
                            }
                            else
                            {
                                lnkRemoveVoucher.Visible = false;
                                imgVoucher.ImageUrl = "~/images/BusinessCard.png";
                            }
                        }
                    }
                    else
                    {
                        lnkRemoveVoucher.Visible = false;
                        imgVoucher.ImageUrl = "~/images/BusinessCard.png";
                    }

                    if (Convert.ToString(objToLoadData.Turnover) != string.Empty)
                        txtTurnOver.Text = objToLoadData.Turnover.ToString().Substring(0, objToLoadData.Turnover.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                    ddlCorporateType.SelectedIndex = ddlCorporateType.Items.FindByValue(Convert.ToString(objToLoadData.CorporateType_TermID)) != null ? ddlCorporateType.Items.IndexOf(ddlCorporateType.Items.FindByValue(Convert.ToString(objToLoadData.CorporateType_TermID))) : 0;
                    ddlDefaultReservationStatus.SelectedIndex = ddlDefaultReservationStatus.Items.FindByValue(Convert.ToString(objToLoadData.DefaultResStatus_TermID)) != null ? ddlDefaultReservationStatus.Items.IndexOf(ddlDefaultReservationStatus.Items.FindByValue(Convert.ToString(objToLoadData.DefaultResStatus_TermID))) : 0;
                    ddlDefaultRateCard.SelectedIndex = ddlDefaultRateCard.Items.FindByValue(Convert.ToString(objToLoadData.DefaultRateID)) != null ? ddlDefaultRateCard.Items.IndexOf(ddlDefaultRateCard.Items.FindByValue(Convert.ToString(objToLoadData.DefaultRateID))) : 0;

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
            txtCode.Text = txtCompanyName.Text = txtFName.Text = txtLName.Text = txtDisplayName.Text = txtTurnOver.Text = txtEmail.Text = txtContactNo.Text = txtFax.Text = string.Empty;
            ddlCorporateType.SelectedIndex = ddlDefaultReservationStatus.SelectedIndex = ddlDefaultRateCard.SelectedIndex = 0;
            //chkIsDirectBill.Checked = false;
            chkIsCommission.Checked = chkDisableAgent.Checked = chkIsCommission.Font.Bold = chkDisableAgent.Font.Bold = false;
            rdbLstComissionFlag.SelectedIndex = 0;
            txtCommission.Enabled = rvfCommission.Enabled = rdbLstComissionFlag.Enabled = ddlCommissionType.Enabled = txtDisableReason.Enabled = false;
            rngvCommission.MaximumValue = "100";
            txtCommission.Text = txtDisableReason.Text = string.Empty;
            ddlCommissionType.SelectedIndex = 0;
            ucCtrlAddress.strAddress = ucCtrlAddress.strCity = ucCtrlAddress.strState = ucCtrlAddress.strCountry = ucCtrlAddress.strZipCode = string.Empty;
            txtMobileCntNo.Text = txtMobileNo.Text = txtDepartment.Text = txtDesignation.Text = txtVoucherTitle.Text = "";
            lnkRemoveVoucher.Visible = false;
            ddlTitle.SelectedIndex = ddlLedgerAccount.SelectedIndex = 0;
        }

        private void BindLedgerAccount()
        {
            ddlLedgerAccount.Items.Clear();
            string strQuery = "select AcctID,AcctName from acc_Account where SymphonyAcctGroupID  = 3 and IsEnable = 1 and IsActive = 1 and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' order by AcctName";
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