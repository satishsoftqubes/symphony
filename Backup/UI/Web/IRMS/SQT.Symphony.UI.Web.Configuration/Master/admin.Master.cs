using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.Master
{
    public partial class admin : System.Web.UI.MasterPage
    {
        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.UserID == Guid.Empty || clsSession.UserID == null)
            {
                Session.Clear();
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                SetLabel();
                SetMenuItemsVisibility();
                SetLeftMenusSelection();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Set Page Label
        /// </summary>
        private void SetLabel()
        {
            lblUserDisplayName.Text = clsSession.DisplayName;
            //lblUserRoleType.Text = clsSession.UserType;
            lblPropertyName.Text = clsSession.PropertyName != string.Empty ? clsSession.PropertyName : "";
            if (clsSession.DateFormat != string.Empty)
                litDate.Text = DateTime.Now.Date.ToString(Convert.ToString(clsSession.DateFormat));
            else
                litDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

            if (clsSession.TimeFormat != string.Empty)
                litTime.Text = DateTime.Now.ToString(clsSession.TimeFormat);
            else
                litTime.Text = DateTime.Now.ToString("hh:mm tt");

            lblDate.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblDate", "Date");
            lblTime.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblTime", "Time");
            lnkLogout.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblBtnLogOut", "Log Out");
            
            ltrSetting.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblUserSetting", "Setting");

            litMReport.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litReports", "Reports");
            litMActionLogView.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLActionLogView", "Action Log");
            LitMLoginLog.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLLoginLogView", "Login Log");
            litLAmenities.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLAmenities", "Amenities Setup");
            litRoomTypeServices.Text = "Room Services";
            litLBlocks.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLBlocks", "Block / Floor");
            litLUnitTypes.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLUnitTypes", "Room Type Setup");
            //litLBlockRoom.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLBlockRoom", "Disabled Rooms");
            litLUnit.Text = "Room Setup"; ////clsCommon.GetGlobalResourceText("AdminMaster", "litLUnit", "Rooms Setup");
            litLConferenceBanquetTypes.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLConferenceBanquetTypes", "Conference Sitting Arrangement");
            litLConferenceBanquet.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLConferenceBanquet", "Conference hall Name");
            litLCategorySetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLCategorySetup", "Category Setup");
            litLItemsManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLItemsManagement", "Item Management");
            litLPriceManager.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblTariffSetup", "Tariff Setup");
            litLHouseKeepingSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblHouseKeeping", "House Keeping");
            ltrLMaterialManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblMaterialManagementSetup", "Item Master Setup");
            ////litLStayTypeSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLStayTypeSetup", "Stay Type Setup");
            litLUserManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLUserManagement", "User Setup");
            litLLanguageSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLLanguageSetup", "Language Setup");
            litLExchangeRate.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblLExchangeRate", "Exchange Rate");
            litLEmployeeSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litEmployeeSetup", "Employee Setup");
            litLDepositeManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLDepositeManagement", "Deposit");
            litLDiscountManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLDiscountManagement", "Discount Setup");
            litLCorporateSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLCorporateSetup", "Company Master");
            litLRateCardList.Text = "Rate Card Setup"; //clsCommon.GetGlobalResourceText("AdminMaster", "litLRateCardList", "Ratecard Setup");
            litLServices.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLServices", "Add On Services");
            litLGuestManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblGuestSetup", "Guest Setup");
            litLGuestTypes.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLGuestTypes", "Guest Types");
            litLPreferences.Text = "Guest Preference"; //clsCommon.GetGlobalResourceText("AdminMaster", "litLPreferences", "Preferences");
            //litLListofGuests.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLListofGuests", "List Of Guests");
            //litLBlackListGuest.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLBlackListGuest", "Blacklist Guest");
            //litLGuestPreferences.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLGuestPreferences", "Guest Preferences");
            litLVIPType.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLVIPType", "VIP Types");
            litLWebManager.Text = "Room Inventory Setup"; ////clsCommon.GetGlobalResourceText("AdminMaster", "lblRoomInventorySetup", "Room Inventory Setup(Web)");
            litLGDSMaster.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLGDSMaster", "GDS Master");
            litLGDSRoomInventoryMang.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLGDSRoomInventoryMang", "GDS Room Inventory Mgmt.");
            litLGDSRoomInventoryDetails.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLGDSRoomInventoryDetails", "GDS Room Inventory Details");
            litLWebSettings.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLWebSettings", "Web Settings");
            lblLPropertyConfiguration.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblPropertySetup", "Property Setup");
            litLCompanySetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLCompanySetup", "Company Setup");
            litPropertySetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblPropertiesSetup", "Properties Setup");
            litSystemSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litSystemSetup", "System Setup");
            litLGeneralSettings.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLGeneralSettings", "General Settings");
            litLCurrencyManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLCurrencyManagement", "Currency Setup");
            litLDenominationsManagment.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLDenominationsManagment", "Denomination Setup");
            litLInfillSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLInfillSetup", "Infill Setup");
            litLEmailConfiguration.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLEmailConfiguration", "Email Configuration");
            litLEmailTemplates.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLEmailTemplates", "Email Notification Template");
            litLUnitOfMeasureManagement.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLUnitOfMeasureManagement", "Unit Of Measure");

            litLReservationSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLReservationSetup", "Reservation");
            ////litLBilling.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLBilling", "Billing");
            litLCancellation.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLCancellation", "Cancellation");
            litLFolioConfiguration.Text = clsCommon.GetGlobalResourceText("AdminMaster", "LitLFolioConfiguration", "Folio");
            litTranscriptAndSOP.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litTranscriptAndSOP", "SOP");
            litRecovery.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litRecovery", "Recovery");

            litLHouseKeepingSectionSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLHouseKeepingSectionSetup", "HouseKeeping Section Setup");
            //litLReservationPolicy.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litReservationPolicy", "Reservation Policy");
            litLPOSConfiguration.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLPOSConfiguration", "POS Configuration");
            litPOSPoints.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litPOSPoints", "POS Points");
            litLUserSettings.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblUserSetup", "User Setup");
            litLDepartment.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLDepartment", "Department");
            litLRoleSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLRoleSetup", "Role Setup");
            litLCounters.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLCounters", "Counter Setup");
            litTaxSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblTaxSetup", "Tax Setup");
            ltrFrontOfficeSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblFrontOfficeSetup", "Policy & Configuration");
            ltrPOSSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblPOSSetup", "POS Setup");
            lblLSystemSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblCommunicationSetup", "Communication Setup");
            litLVendorMaster.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLVendorMaster", "Vendor Master");

            //litChangeModule.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litChangeModule", "Change Module"); ;

            litLAmendment.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblAmendment", "Amendment");
            litLBookingAgent.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblBookingAgent", "Booking Agent");

            ltrModuleTitle.Text = clsSession.SelectedModule; //clsCommon.GetGlobalResourceText("AdminMaster", "lblModuleTitle", "BackOffice Setup");
        }

        private void SetLeftMenusSelection()
        {
            try
            {
                var uri = new Uri(Convert.ToString(Request.Url));
                string path = uri.GetLeftPart(UriPartial.Path);
                string[] strArray = path.Split('/');
                string strToSelectPane = clsCommon.GetAccordionIndex(Convert.ToString(strArray[strArray.Length - 2]) + "/" + Convert.ToString(strArray[strArray.Length - 1]));

                int Index = 0;
                foreach (AjaxControlToolkit.AccordionPane pane in MyAccordion.Panes)
                {
                    if (pane.Visible == true)
                    {
                        if (pane.ID.ToUpper() == strToSelectPane.ToUpper())
                        {
                            MyAccordion.SelectedIndex = Index;
                            break;
                        }
                        Index++;
                    }
                }
            }
            catch
            {
                MyAccordion.SelectedIndex = 0;
            }
        }

        private void SetMenuItemsVisibility()
        {
            if (!(clsSession.UserType.ToUpper() == "ADMINISTRATOR" || clsSession.UserType.ToUpper() == "SUPERADMIN"))
                liLCompanyList.Visible = false;

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                return;
            }

            if (clsSession.UserRights == string.Empty)
            {
                //RTest
                ////DataSet dsUserAuthorization = UserBLL.GetUserAllAuthorization(clsSession.UserID);
                Guid? PropertyID = null;
                Guid? CompanyID = null;

                if (clsSession.PropertyID != null && clsSession.PropertyID != Guid.Empty)
                    PropertyID = new Guid(Convert.ToString(Session["PropertyID"]));

                if (clsSession.CompanyID != null && clsSession.CompanyID != Guid.Empty)
                    CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                DataSet dsUserAuthorization = UserBLL.GetUserAllAuthorization(clsSession.UserID, clsSession.SelectedModule, PropertyID, CompanyID);
                if (dsUserAuthorization.Tables.Count > 0 && dsUserAuthorization != null && dsUserAuthorization.Tables[0].Rows.Count > 0)
                {
                    clsSession.UserRights = Convert.ToString(dsUserAuthorization.Tables[0].Rows[0]["UserRights"]);
                }
            }

            //liMPropertySetup.Visible = liLPropertyList.Visible = clsSession.UserRights.IndexOf("PROPERTYSETUP.ASPX") > -1;
            liLSystemSetup.Visible = clsSession.UserRights.IndexOf("SYSTEMSETUP.ASPX") > -1;
            liInfillSetup.Visible = clsSession.UserRights.IndexOf("INFILLSETUP.ASPX") > -1;
            liLPropertyList.Visible = clsSession.UserRights.IndexOf("PROPERTYSETUP.ASPX") > -1;
            AcPnGeneralSetting.Visible = (liLPropertyList.Visible || liLSystemSetup.Visible || liInfillSetup.Visible);

            liLBlockFloorSetup.Visible = clsSession.UserRights.IndexOf("BLOCKFLOORSETUP.ASPX") > -1;
            liLRoomTypeList.Visible = clsSession.UserRights.IndexOf("UNITTYPESETUP.ASPX") > -1;
            liLRoomList.Visible = clsSession.UserRights.IndexOf("UNITSETUP.ASPX") > -1;
            //liLBlockRoom.Visible = clsSession.UserRights.IndexOf("BLOCKROOM.ASPX") > -1;
            liLAmenitiesSetup.Visible = clsSession.UserRights.IndexOf("AMENITIESSETUP.ASPX") > -1;
            liLConferenceType.Visible = clsSession.UserRights.IndexOf("CONFERENCEBANQUETTYPES.ASPX") > -1;
            liLConference.Visible = clsSession.UserRights.IndexOf("CONFERENCEBANQUET.ASPX") > -1;
            //liLReservationPolicy.Visible = clsSession.UserRights.IndexOf("RESERVATIONPOLICY.ASPX") > -1;
            liLCounterName.Visible = clsSession.UserRights.IndexOf("COUNTERSETUP.ASPX") > -1;

            AcPnPropertySetup.Visible = (liLBlockFloorSetup.Visible || liLRoomTypeList.Visible || liLRoomList.Visible || liLAmenitiesSetup.Visible || liLConferenceType.Visible || liLConference.Visible || liLCounterName.Visible);

            liLPOSConfiguration.Visible = clsSession.UserRights.IndexOf("POSCONFIGURATION.ASPX") > -1;
            liLPOSPoints.Visible = clsSession.UserRights.IndexOf("POSPOINTS.ASPX") > -1;
            liLVendorMaster.Visible = clsSession.UserRights.IndexOf("VENDORMASTER.ASPX") > -1;

            acPnPOSSetup.Visible = (liLPOSConfiguration.Visible || liLPOSPoints.Visible || liLVendorMaster.Visible);

            liLEmailConfiguration.Visible = clsSession.UserRights.IndexOf("EMAILCONFIGURATION.ASPX") > -1;
            liLEmailTemplates.Visible = clsSession.UserRights.IndexOf("EMAILTEMPALTESETUP.ASPX") > -1;

            acpnSystemSetup.Visible = (liLEmailConfiguration.Visible || liLEmailTemplates.Visible);

            liLReservationConfig.Visible = clsSession.UserRights.IndexOf("RESERVATIONCONFIG.ASPX") > -1;
            liLCancellation.Visible = clsSession.UserRights.IndexOf("CANCELLATIONPOLICY.ASPX") > -1;
            liLGuestTypes.Visible = true; //clsSession.UserRights.IndexOf("GUESTTYPES.ASPX") > -1;
            ////liLBilling.Visible = clsSession.UserRights.IndexOf("BILLING.ASPX") > -1;
            liLFolioConfiguration.Visible = clsSession.UserRights.IndexOf("FOLIOCONFIGURATION.ASPX") > -1;

            acPnFrontOfficeSetup.Visible = (liLReservationConfig.Visible || liLCancellation.Visible || liLFolioConfiguration.Visible);

            liLWebSetting.Visible = clsSession.UserRights.IndexOf("WEBSETTINGS.ASPX") > -1;
            liLGDSMaster.Visible = clsSession.UserRights.IndexOf("GDSMASTER.ASPX") > -1;
            liLGDSRoomInventory.Visible = clsSession.UserRights.IndexOf("GDSROOMINVENTORYMGMT.ASPX") > -1;
            liLGDSRoomInventoryDetail.Visible = clsSession.UserRights.IndexOf("GDSROOMINVENTORYDETAIL.ASPX") > -1;
            AcPnRoomInventoryWEBSetup.Visible = (liLWebSetting.Visible || liLGDSMaster.Visible || liLGDSRoomInventory.Visible || liLGDSRoomInventoryDetail.Visible);

            liLUnitOfMeasure.Visible = clsSession.UserRights.IndexOf("UNITOFMEASURE.ASPX") > -1;
            liMCategories.Visible = liLCategory.Visible = clsSession.UserRights.IndexOf("CATEGORY.ASPX") > -1;
            liMItemManagement.Visible = liLItem.Visible = clsSession.UserRights.IndexOf("ITEMMANAGEMENT.ASPX") > -1;
            AcPnMaterialManagement.Visible = (liLCategory.Visible || liLItem.Visible || liLUnitOfMeasure.Visible);

            ////liLStayType.Visible = clsSession.UserRights.IndexOf("STAYTYPE.ASPX") > -1;
            //liLDeposits.Visible = clsSession.UserRights.IndexOf("DEPOSIT.ASPX") > -1;
            liLDiscount.Visible = false; //liMDiscountSetup.Visible = clsSession.UserRights.IndexOf("DISCOUNT.ASPX") > -1;
            liLCorporateList.Visible = clsSession.UserRights.IndexOf("CORPORATESETUP.ASPX") > -1;

            liMRateCards.Visible = liLRateCardList.Visible = clsSession.UserRights.IndexOf("RATECARDLIST.ASPX") > -1;
            liLAddOnsServices.Visible = liAddOnsServices.Visible = clsSession.UserRights.IndexOf("ADDONSSERVICES.ASPX") > -1;
            liLAccount.Visible = clsSession.UserRights.IndexOf("ACCOUNT.ASPX") > -1;

            AcPnPriceManager.Visible = (liLDiscount.Visible || liLCorporateList.Visible || liLRateCardList.Visible || liLAddOnsServices.Visible || liLAccount.Visible);

            ////liLVIPType.Visible = clsSession.UserRights.IndexOf("VIPTYPE.ASPX") > -1;
            //liLGuestTypes.Visible = clsSession.UserRights.IndexOf("GUESTTYPES.ASPX") > -1;
            //liLPreferences.Visible = clsSession.UserRights.IndexOf("PREFERENCES.ASPX") > -1;
            //liMListOfGuests.Visible = liLListofGuests.Visible = clsSession.UserRights.IndexOf("GUESTSLIST.ASPX") > -1;
            //liLBlackListGuest.Visible = clsSession.UserRights.IndexOf("BACKLISTGUEST.ASPX") > -1;
            //liLGuestPreferences.Visible = clsSession.UserRights.IndexOf("GUESTPREFERENCES.ASPX") > -1;
            //AcPnGuestManagement.Visible = (liLGuestTypes.Visible || liLPreferences.Visible || liLListofGuests.Visible || liLVIPType.Visible || liLBlackListGuest.Visible || liLGuestPreferences.Visible);
            //AcPnGuestManagement.Visible = (liLVIPType.Visible);

            liLDepartment.Visible = clsSession.UserRights.IndexOf("DEPARTMENT.ASPX") > -1;
            liLRole.Visible = clsSession.UserRights.IndexOf("ROLE.ASPX") > -1;
            liLEmployeeList.Visible = clsSession.UserRights.IndexOf("EMPLOYEESETUP.ASPX") > -1;
            liLUsers.Visible = clsSession.UserRights.IndexOf("USERS.ASPX") > -1;
            //liLActionLog.Visible = liMActionLog.Visible = clsSession.UserRights.IndexOf("ACTIONLOG.ASPX") > -1;
            //liLLogInLog.Visible = liMLoginLog.Visible = clsSession.UserRights.IndexOf("LOGINLOG.ASPX") > -1;
            AcPnlUserSettings.Visible = (liLDepartment.Visible || liLRole.Visible || liLEmployeeList.Visible || liLUsers.Visible); //|| liLActionLog.Visible || liLLogInLog.Visible);
            liMReport.Visible = (liMLoginLog.Visible || liMActionLog.Visible);

            liLHouseKeeping.Visible = clsSession.UserRights.IndexOf("HOUSEKEEPING.ASPX") > -1;
            AcPnHouseKeeping.Visible = (liLHouseKeeping.Visible);

            //This code is temporory
            if (clsSession.SelectedModule.ToUpper() == "PMS ADMIN SETUP")
            {
                //liCompanyMasterTemp.Visible = false;

                AcPnPropertySetup.Visible = false;
                acPnFrontOfficeSetup.Visible = false;
                //liLRateCardList.Visible = liLDiscount.Visible = liLDeposits.Visible = liLAddOnsServices.Visible = liLCorporateList.Visible = liLBookingAgent.Visible = false;
                AcPnPriceManager.Visible = AcPnGuestManagement.Visible = acPnPOSSetup.Visible = AcPnMaterialManagement.Visible = AcPnHouseKeeping.Visible = false;
                AcPnRoomInventoryWEBSetup.Visible = false;
            }
            else if (clsSession.SelectedModule.ToUpper() == "FRONT DESK SETUP")
            {
                liLAccount.Visible = false;
                AcPnGuestManagement.Visible = acPnPOSSetup.Visible = AcPnMaterialManagement.Visible = AcPnHouseKeeping.Visible = false;
            }
            //
        }
        #endregion Private Method

        #region Control Event
        /// <summary>
        /// Log Out Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            if (clsSession.LogInLogID != Guid.Empty)
            {
                LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                objToUpdate.Logout = DateTime.Now;
                LoginLogBLL.Update(objToUpdate);
            }

            string strUserType = clsSession.UserType.ToUpper();

            Session.Clear();
            if (strUserType == "SUPERADMIN" || strUserType == "ADMINISTRATOR")
            {
                ////Response.Redirect("~/CompanyLogin.aspx");
                Response.Redirect("~/Index.aspx");
            }
            else
                Response.Redirect("~/Index.aspx");
        }

        protected void lnkUserSettings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/UserSetup/UserSetting.aspx");
        }


        protected void lnkChangeModule_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Module.aspx");
        }


        #endregion
    }
}