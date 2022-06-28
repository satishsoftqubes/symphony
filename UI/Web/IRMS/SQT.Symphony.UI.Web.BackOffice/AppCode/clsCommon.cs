using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

public class clsCommon
{
    #region Constructor
    public clsCommon()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    #region Enums
    /// <summary>
    /// Message Type ENum
    /// </summary>
    public enum MessageType
    {
        Error = 1,
        Info = 2,
        Success = 3,
        Warning = 4
    }

    #endregion Enum Declaraction

    #region Constants
    //public const string DefaultUserImage = "User.png";
    //public const string DefaultTeamImage = "User.png";
    //public const string DefaultClientLogoImage = "defaultclientlogo.png";
    //public const string DefaultMachineLogoImage = "defaultmachinelogo.png";
    #endregion

    #region Methods

    public static bool CheckSession()
    {
        if (clsSession.UserID == Guid.Empty || clsSession.UserID == null)
            return true;
        else
            return false;
    }

    public static string GetUserAuthorization(Guid userID, string formName)
    {
        DataSet dsRights = UserBLL.GetUserAuthorization(clsSession.UserID, formName.ToUpper());
        if (dsRights != null && dsRights.Tables.Count > 0)
            return Convert.ToString(dsRights.Tables[0].Rows[0]["UserRights"]).Length != 4 ? "0000" : Convert.ToString(dsRights.Tables[0].Rows[0]["UserRights"]);
        else
            return "0000";
    }

    ////Method to get lable value from resource file based on Hotelcode.
    //public static string GetGlobalResourceText(string resourceFileName, string lblName)
    //{
    //    string strToReturn = string.Empty;

    //    try
    //    {
    //        //Get lable value from resource file based on hotelcode.
    //        strToReturn = Convert.ToString(HttpContext.GetGlobalResourceObject("_" + clsSession.HotelCode + "_" + resourceFileName, lblName));
    //    }
    //    catch
    //    {
    //        try
    //        {
    //            //In case, if resource file of hotelcode not exist, then get lable value from page's main resource file.
    //            strToReturn = Convert.ToString(HttpContext.GetGlobalResourceObject(resourceFileName, lblName));
    //        }
    //        catch
    //        {
    //            //In exceptional case, if Page's main resource file also not exist, then return lblName.
    //            strToReturn = lblName;
    //        }
    //    }

    //    if (strToReturn == string.Empty)
    //        strToReturn = lblName;

    //    return strToReturn;
    //}

    //Method to get lable value from resource file based on Hotelcode.
    public static string GetGlobalResourceText(string resourceFileName, string lblName, string defaultTextToReturn)
    {
        string strToReturn = string.Empty;

        try
        {
            //Get lable value from resource file based on hotelcode.
            strToReturn = Convert.ToString(HttpContext.GetGlobalResourceObject("_" + clsSession.HotelCode + "_" + resourceFileName, lblName));
        }
        catch
        {
            try
            {
                //In case, if resource file of hotelcode not exist, then get lable value from page's main resource file.
                strToReturn = Convert.ToString(HttpContext.GetGlobalResourceObject(resourceFileName, lblName));
            }
            catch
            {
                //In exceptional case, if Page's main resource file also not exist, then return lblName.
                //strToReturn = lblName;
            }
        }

        if (strToReturn == string.Empty)
            strToReturn = defaultTextToReturn;

        return strToReturn;
    }

    public static Guid? Country(string CountryName)
    {
        if (CountryName.Trim() == string.Empty)
            return null;

        List<Country> lstCountry = null;
        Country objCountry = new Country();
        objCountry.CountryName = CountryName;
        objCountry.IsActive = true;
        lstCountry = CountryBLL.GetAll(objCountry);
        if (lstCountry.Count != 0)
            return lstCountry[0].CountryID;
        else
        {
            CountryBLL.Save(objCountry);
            return objCountry.CountryID;
        }
    }

    public static Guid? State(string StateName)
    {
        if (StateName.Trim() == string.Empty)
            return null;

        List<State> lstState = null;
        State objState = new State();
        objState.StateName = StateName;
        objState.IsActive = true;
        lstState = StateBLL.GetAll(objState);
        if (lstState.Count != 0)
            return lstState[0].StateID;
        else
        {
            StateBLL.Save(objState);
            return objState.StateID;
        }
    }

    public static Guid? City(string CityName)
    {
        if (CityName.Trim() == string.Empty)
            return null;

        List<City> lstCity = null;
        City objCity = new City();
        objCity.CityName = CityName;
        objCity.IsActive = true;
        lstCity = CityBLL.GetAll(objCity);
        if (lstCity.Count != 0)
            return lstCity[0].CityID;
        else
        {
            CityBLL.Save(objCity);
            return objCity.CityID;
        }
    }

    public static string GetAccordionIndex(string strToCheck)
    {
        switch (strToCheck.ToUpper())
        {
            case "PROPERTY/COMPANYSETUP.ASPX": return "ACPNGENERALSETTING";
            case "PROPERTY/PROPERTYLIST.ASPX": return "ACPNGENERALSETTING";
            case "PROPERTY/PROPERTYCONFIGURATION.ASPX": return "ACPNGENERALSETTING";
            case "PROPERTY/PROPERTYSETUP.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/INFILLSETUP.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/DEFAULTSETTING.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/CURRENCYSETUP.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/DENOMINATIONSETUP.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/EXCHANGERATE.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/LANGUAGESETUP.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/NEWSLATTERSETUP.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/EVENTMANAGEMENT.ASPX": return "ACPNGENERALSETTING";
            case "CONFIGURATIONS/AUTONUMBER.ASPX": return "ACPNGENERALSETTING";

            case "CONFIGURATIONS/BLOCKFLOORSETUP.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/ROOMTYPELIST.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/ROOMTYPE.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/ROOMLIST.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/BLOCKROOM.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/ROOM.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/AMENITIESSETUP.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/NOTIFICATION.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/CONFERENCETYPE.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/CONFERENCELIST.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/CONFERENCE.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/CONFBANQBANQUETMANAGEMENT.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/COUNTERNAME.ASPX": return "ACPNPROPERTYSETUP";
            //case "CONFIGURATIONS/ACCOUNT.ASPX": return "ACPNPROPERTYSETUP";
            case "CONFIGURATIONS/ACCOUNT.ASPX": return "ACPNPRICEMANAGER";

            case "CONFIGURATIONS/EMAILCONFIGURATION.ASPX": return "ACPNSYSTEMSETUP";
            case "CONFIGURATIONS/EMAILTEMPALTES.ASPX": return "ACPNSYSTEMSETUP";

            case "CONFIGURATIONS/POSCONFIGURATION.ASPX": return "ACPNPOSSETUP";
            case "CONFIGURATIONS/VENDORMASTER.ASPX": return "ACPNPOSSETUP";
            case "CONFIGURATIONS/POSPOINTS.ASPX": return "ACPNPOSSETUP";

            case "CONFIGURATIONS/FOLIOCONFIGURATION.ASPX": return "ACPNFRONTOFFICESETUP";
            case "CONFIGURATIONS/RESERVATIONCONFIG.ASPX": return "ACPNFRONTOFFICESETUP";
            case "CONFIGURATIONS/RESERVATIONPOLICY.ASPX": return "ACPNFRONTOFFICESETUP";
            case "CONFIGURATIONS/CANCELLATIONPOLICY.ASPX": return "ACPNFRONTOFFICESETUP";
            case "CONFIGURATIONS/BILLING.ASPX": return "ACPNFRONTOFFICESETUP";

            case "WEBMANAGER/BOOKINGRESTRICTIONS.ASPX": return "ACPNROOMINVENTORYWEBSETUP";
            case "WEBMANAGER/WEBSETTINGS.ASPX": return "ACPNROOMINVENTORYWEBSETUP";
            case "WEBMANAGER/GDSMASTER.ASPX": return "ACPNROOMINVENTORYWEBSETUP";
            case "WEBMANAGER/GDSROOMINVENTORYMANG.ASPX": return "ACPNROOMINVENTORYWEBSETUP";
            case "WEBMANAGER/GDSROOMINVENTORYDETAILS.ASPX": return "ACPNROOMINVENTORYWEBSETUP";

            case "CONFIGURATIONS/UNITOFMEASURE.ASPX": return "ACPNMATERIALMANAGEMENT";
            case "INVENTORY/CATEGORY.ASPX": return "ACPNMATERIALMANAGEMENT";
            case "INVENTORY/ITEMLIST.ASPX": return "ACPNMATERIALMANAGEMENT";
            case "INVENTORY/ITEM.ASPX": return "ACPNMATERIALMANAGEMENT";

            case "PRICEMANAGER/ADDONSSERVICES.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/CONFERENCERATECARD.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/CORPORATE.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/CORPORATELIST.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/BOOKINGAGENT.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/BOOKINGAGENTLIST.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/CORPORATERATECARD.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/DISCOUNT.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/GDSRATECARD.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/PACKAGERATECARD.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/RATECARDLIST.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/ROOMRATECARD.ASPX": return "ACPNPRICEMANAGER";
            case "PRICEMANAGER/STAYTYPE.ASPX": return "ACPNPRICEMANAGER";
            case "CONFIGURATIONS/DEPOSITS.ASPX": return "ACPNPRICEMANAGER";

            case "GUESTTYPES/GUESTTYPES.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUESTTYPES/PREFERENCES.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUESTTYPES/LISTOFGUESTS.ASPX": return "ACPNGUESTMANAGEMENT";
            case "PRICEMANAGER/VIPTYPE.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUESTTYPES/BLACKLISTGUEST.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUESTTYPES/GUESTPREFERENCES.ASPX": return "ACPNGUESTMANAGEMENT";

            case "CONFIGURATIONS/DEPARTMENT.ASPX": return "ACPNLUSERSETTINGS";
            case "USERSETUP/ROLE.ASPX": return "ACPNLUSERSETTINGS";
            case "CONFIGURATIONS/USERPERSONALIZATION.ASPX": return "ACPNLUSERSETTINGS";
            case "USERSETUP/USERS.ASPX": return "ACPNLUSERSETTINGS";
            case "CONFIGURATIONS/EMPLOYEELIST.ASPX": return "ACPNLUSERSETTINGS";
            case "CONFIGURATIONS/EMPLOYEESETUP.ASPX": return "ACPNLUSERSETTINGS";
            case "CONFIGURATIONS/ACTIONLOG.ASPX": return "ACPNLUSERSETTINGS";
            case "CONFIGURATIONS/LOGINLOG.ASPX": return "ACPNLUSERSETTINGS";
            case "CONFIGURATIONS/ERROLOGVIEW.ASPX": return "ACPNLUSERSETTINGS";

            case "CONFIGURATIONS/HOUSEKEEPING.ASPX": return "ACPNHOUSEKEEPING";

            default: return "";
        }
    }

    #endregion
}