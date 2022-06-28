using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class FolioConfiguration : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsMessage = false;
        public bool IsInsert = false;
        //Property to save CompanyID
        public Guid FolioConfigID
        {
            get
            {
                return ViewState["FolioConfigID"] != null ? new Guid(Convert.ToString(ViewState["FolioConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioConfigID"] = value;
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
        #endregion Variable and Property

        #region Form Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                SetPageLabels();
                BindBreadCrumb();
                ////BindTermsAndConditionData();
                BindTermsAndConditionData();
                BindMoreOpetionData();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "FOLIOCONFIGURATION.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnMoreOptionSave.Visible = this.UserRights.Substring(2, 1) == "1";
        }
        /// <summary>
        /// Set Page Labels Information
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblMainHeader", "FOLIO");
            ////litTermsandCondition.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblTermsandCondition", "Terms and Condition");
            //litTCDescription.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblTCDescription", "Terms and Condition Description");
            //lnkbtnTCDescription.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lnkbtnTCDescription", "Edit");
            ////litMoreOption.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblMoreOption", "More Option");
            //litMoreOptionDescription.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblMoreOptionDescription", "More Option Description");
            //lnkbtnMoreOptionDescription.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lnkbtnMoreOptionDescription", "Edit");
            //litTermConditionHeading.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblTermConditionHeading");
            ////litFolioNotes.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblFolioNotes", "Foot Notes");
            ////litTermsCondition.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblTermsCondition", "Terms & Condition");
            //litMoreOptionHeading.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblMoreOptionHeading", "More Option");
            ////btnTermsConditionSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            //btnTermsConditionCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnMoreOptionSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            //btnMoreOptionCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");



            litReRountingEnable.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "litReRountingEnable", "Re Routing Enable");
            lblCreateSubFolio.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblCreateSubFolio", "Create sub folio by transaction");
            litApplicable.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblApplicable", "Applicable");

            chkSameReservation.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkSameReservation", "Same Reservation");
            chkGroupReservation.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkGroupReservation", "Group Reservation");
            chkAllReservation.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkAllReservation", "All Reservation");

            chkAccomodation.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkAccomodation", "Accommodation");
            chkRestaurant.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkRestaurant", "Restaurant");
            chkPOS.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkPOS", "POS");
            chkMiscellaneous.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkMiscellaneous", "Miscellaneous");
            chkCallLogger.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkCallLogger", "Call Logger");
            chkLoundry.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkLoundry", "Laundry");
            chkMiscServices.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkMiscServices", "Misc Services");

            chkTransferBalance.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkTransferBalance", "Transfer Balance");
            chkAdvanceChargePosting.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkAdvanceChargePosting", "Advance Charge Posting");
            chkTransferTransaction.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkTransferTransaction", "Transfer Transaction");
            chkBalanceTransfer.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkBalanceTransfer", "Balance Transfer");
            chkDepositTransfer.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkDepositTransfer", "Deposit Transfer");
            chkVoidTransaction.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkVoidTransaction", "Void Transaction");
            chkSplitFolio.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkSplitFolio", "Split Folio");
            chkAutoCheckinFolio.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "chkAutoCheckinFolio", "Auto Check in folio with reservation");

            litFolioNotes.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblFolioNotes", "Foot Notes");
            btnTermsConditionSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");

            litTabFolioConfiguration.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblTabFolioConfiguration", "Folio Configuration");
            litTabBilling.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblTabBilling", "Billing");
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblFrontOfficeSetup", "Policy & Configuration");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblFolioConfiguration", "Folio");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        ////private void BindTermsAndConditionData()
        ////{
        ////    FolioConfig FolioConf = new FolioConfig();
        ////    FolioConf.CompanyID = clsSession.CompanyID;
        ////    FolioConf.PropertyID = clsSession.PropertyID;
        ////    FolioConf.IsActive = true;
        ////    List<FolioConfig> LstConfig = FolioConfigBLL.GetAll(FolioConf);
        ////    if (LstConfig.Count == 1)
        ////    {
        ////        this.FolioConfigID = LstConfig[0].FolioConfigID;
        ////        txtFolioNotes.Text = Convert.ToString(LstConfig[0].FolioNotes);
        ////        ////txtTermsCondition.Text = Convert.ToString(LstConfig[0].TermnCondition);
        ////    }
        ////}


        private void BindTermsAndConditionData()
        {
            FolioConfig FolioConf = new FolioConfig();
            FolioConf.CompanyID = clsSession.CompanyID;
            FolioConf.PropertyID = clsSession.PropertyID;
            FolioConf.IsActive = true;
            List<FolioConfig> LstConfig = FolioConfigBLL.GetAll(FolioConf);
            if (LstConfig.Count == 1)
            {
                this.FolioConfigID = LstConfig[0].FolioConfigID;
                txtFolioNotes.Text = Convert.ToString(LstConfig[0].FolioNotes);
                ////txtTermsCondition.Text = Convert.ToString(LstConfig[0].TermnCondition);
            }
        }

        private void BindMoreOpetionData()
        {
            FolioConfig FolioConf = new FolioConfig();
            FolioConf.CompanyID = clsSession.CompanyID;
            FolioConf.PropertyID = clsSession.PropertyID;
            FolioConf.IsActive = true;
            List<FolioConfig> LstConfig = FolioConfigBLL.GetAll(FolioConf);
            if (LstConfig.Count == 1)
            {
                this.FolioConfigID = LstConfig[0].FolioConfigID;

                // Re Routing Enable
                chkSameReservation.Checked = Convert.ToBoolean(LstConfig[0].IsReRoutingInSameReservation);
                chkGroupReservation.Checked = Convert.ToBoolean(LstConfig[0].IsReRoutingInGroupReservation);
                chkAllReservation.Checked = Convert.ToBoolean(LstConfig[0].IsReRoutingInAllReservation);


                // Folio Sub Created
                chkAccomodation.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCreateFoliosForAccomodation);
                chkRestaurant.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCreateFoliosForRestaurent);
                chkPOS.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCreateFoliosForPOS);
                chkMiscellaneous.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCreateFoliosForMiscellaneous);
                chkCallLogger.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCreateFoliosForCallLogger);
                chkLoundry.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCreateFoliosForLaundry);
                chkMiscServices.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCreateFoliosForMiscServices);

                // Is Applicable 
                chkTransferBalance.Checked = Convert.ToBoolean(LstConfig[0].IsTransferBalanceApplicable);
                chkAdvanceChargePosting.Checked = Convert.ToBoolean(LstConfig[0].IsAdvancedChargePostingApplicable);
                chkTransferTransaction.Checked = Convert.ToBoolean(LstConfig[0].IsTransferTransactionApplicable);
                chkBalanceTransfer.Checked = Convert.ToBoolean(LstConfig[0].IsBalanceTransferApplicable);
                chkDepositTransfer.Checked = Convert.ToBoolean(LstConfig[0].IsDepositTransferApplicable);
                chkVoidTransaction.Checked = Convert.ToBoolean(LstConfig[0].IsVoidTransactionApplicable);
                chkSplitFolio.Checked = Convert.ToBoolean(LstConfig[0].IsSplitFolioApplicable);
                chkAutoCheckinFolio.Checked = Convert.ToBoolean(LstConfig[0].IsAutoCheckInFolioWithReservation);
            }
        }
        
        #endregion Private Method

        ////#region Term & Condition Button Event

        /////// <summary>
        /////// Save Button Event
        /////// </summary>
        /////// <param name="sender">sender as Object</param>
        /////// <param name="e">e as EventArgs</param>
        ////protected void btnTermsConditionSave_Click(object sender, EventArgs e)
        ////{
        ////    if (this.FolioConfigID != Guid.Empty)
        ////    {
        ////        FolioConfig Updt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
        ////        FolioConfig OldUpdt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
        ////        Updt.FolioNotes = txtFolioNotes.Text.Trim();
        ////        ////Updt.TermnCondition = txtTermsCondition.Text.Trim();
        ////        FolioConfigBLL.Update(Updt);
        ////        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldUpdt.ToString() + "<br/><br/>" + Updt.ToString(), Updt.ToString() + "<br/><br/>" + OldUpdt.ToString(), "res_FolioConfig");
        ////    }
        ////    IsMessage = true;
        ////    ltrSuccessfullyTerm.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");            
        ////}
        ////#endregion Term & Condition Button Event

        #region Folio More Button Check

        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnMoreOptionSave_Click(object sender, EventArgs e)
        {
            if (this.FolioConfigID != Guid.Empty)
            {
                FolioConfig Updt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
                FolioConfig OldUpdt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);

                // Re Routing Enable
                Updt.IsReRoutingInSameReservation = chkSameReservation.Checked;
                Updt.IsReRoutingInGroupReservation = chkGroupReservation.Checked;
                Updt.IsReRoutingInAllReservation = chkAllReservation.Checked;


                // Folio Sub Created
                Updt.IsAutoCreateFoliosForAccomodation = chkAccomodation.Checked;
                Updt.IsAutoCreateFoliosForRestaurent = chkRestaurant.Checked;
                Updt.IsAutoCreateFoliosForPOS = chkPOS.Checked;
                Updt.IsAutoCreateFoliosForMiscellaneous = chkMiscellaneous.Checked;
                Updt.IsAutoCreateFoliosForCallLogger = chkCallLogger.Checked;
                Updt.IsAutoCreateFoliosForLaundry = chkLoundry.Checked;
                Updt.IsAutoCreateFoliosForMiscServices = chkMiscServices.Checked;


                // Is Applicable 
                Updt.IsTransferBalanceApplicable = chkTransferBalance.Checked;
                Updt.IsAdvancedChargePostingApplicable = chkAdvanceChargePosting.Checked;
                Updt.IsTransferTransactionApplicable = chkTransferTransaction.Checked;
                Updt.IsBalanceTransferApplicable = chkBalanceTransfer.Checked;
                Updt.IsDepositTransferApplicable = chkDepositTransfer.Checked;
                Updt.IsVoidTransactionApplicable = chkVoidTransaction.Checked;
                Updt.IsSplitFolioApplicable = chkSplitFolio.Checked;
                Updt.IsAutoCheckInFolioWithReservation = chkAutoCheckinFolio.Checked;

                FolioConfigBLL.Update(Updt);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldUpdt.ToString() + "<br/><br/>" + Updt.ToString(), Updt.ToString() + "<br/><br/>" + OldUpdt.ToString(), "res_FolioConfig");
            }
            IsInsert = true;
            litMoreOptionMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);
        }

        protected void btnTermsConditionSave_Click(object sender, EventArgs e)
        {
            if (this.FolioConfigID != Guid.Empty)
            {
                FolioConfig Updt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
                FolioConfig OldUpdt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
                Updt.FolioNotes = txtFolioNotes.Text.Trim();
                FolioConfigBLL.Update(Updt);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldUpdt.ToString() + "<br/><br/>" + Updt.ToString(), Updt.ToString() + "<br/><br/>" + OldUpdt.ToString(), "res_FolioConfig");
            }
            IsMessage = true;
            ltrSuccessfullyTerm.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
        }

        #endregion Folio More Button Check
    }
}