using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Web.Configuration;


public class clsCommon
{

    #region Methods
    public static string GetAccordionIndex(string strToCheck)
    {
        switch (strToCheck.ToUpper())
        {
            case "RESERVATION/ROOMTOSELL.ASPX": return "ACPNAVAILABILITYCHART";
            case "RESERVATION/AVAILABILITYBYBLOCK.ASPX": return "ACPNAVAILABILITYCHART";

            case "RESERVATION/ROOMRESERVATIONLIST.ASPX": return "ACPNRESERVATION";
            case "RESERVATION/ROOMRESERVATION.ASPX": return "ACPNRESERVATION";
            case "RESERVATION/INVESTORBOOKING.ASPX": return "ACPNRESERVATION";
            case "RESERVATION/CHECKIN.ASPX": return "ACPNRESERVATION";
            case "RESERVATION/DEPOSIT.ASPX": return "ACPNRESERVATION";

            case "GUEST/GUESTMASTER.ASPX": return "ACPNGUESTMANAGEMENT";
            case "FOLIO/GUESTPROFILE.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUEST/CHANGEROOM.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUEST/EXTENDSTAY.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUEST/SWAPROOM.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUEST/MESSAGE.ASPX": return "ACPNGUESTMANAGEMENT";
            case "GUEST/COMPLAIN.ASPX": return "ACPNGUESTMANAGEMENT";

            case "CARD/ISSUECARD.ASPX": return "ACPNPREPAIDCASHCARD";
            case "CARD/CARDRECHARGE.ASPX": return "ACPNPREPAIDCASHCARD";
            case "CARD/PRINTSTATEMENT.ASPX": return "ACPNPREPAIDCASHCARD";
            case "CARD/LOSTCARD.ASPX": return "ACPNPREPAIDCASHCARD";

            case "FOLIO/FOLIOLIST.ASPX": return "ACPNBILLING";
            case "FOLIO/FOLIODETAILS.ASPX": return "ACPNBILLING";
            case "BILLING/CHECKOUT.ASPX": return "ACPNBILLING";
            case "FOLIO/REROUTEFOLIOSETUP.ASPX": return "ACPNBILLING";

            default: return "";

        }
    }

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

    #endregion

    #region Frontdesk Method
    public static void Reservation_GetTotalDays(Guid? ResID, DateTime CheckInDate, DateTime CheckOutDate, ref int Day, ref bool IsEarly, ref bool IsLate)
    {
        Day = (Convert.ToInt32(((CheckOutDate) - (CheckInDate)).TotalDays));
        IsEarly = false;
        IsLate = false;
    }

    public static string GetFormatedRoomNumber(string strRoomNumber)
    {
        string strRoomNo = string.Empty;

        if (strRoomNumber != "")
        {
            string[] str = strRoomNumber.Split('|');
            if (str.Length > 0)
                strRoomNo = str[0] + "(" + str[1] + ")";
        }

        return strRoomNo;
    }

    public static string GetMobileNo(string strPhoneNo)
    {
        string strReturn = "";
        if (strPhoneNo != "")
        {
            string[] strArray = strPhoneNo.Split('-');
            if (strArray.Length > 1)
            {
                if (strArray[0] != "" && strArray[1] != "")
                    strReturn = strPhoneNo;
                else
                    strReturn = Convert.ToString(strArray[1]);
            }
            else
                strReturn = "";
        }
        return strReturn;
    }

    public static void GetReservationPaymentInfo(Guid ReservationID, ref decimal RoomRent, ref decimal Tax, ref decimal TotalAmount, ref int NoofDays, ref decimal DepositAmount, ref decimal PaidDeposit, ref decimal TotalPaymentReceived, ref DataTable dtPaymentIfno, ref int TotalInfraServiceCharge, ref int PaidInfraServiceCharge, ref int FoodCharges, ref int PaidFoodCharges, ref int ElectricityCharges, ref int PaidElectricityCharges)
    {
        DataSet dsPaymentInfo = ReservationBLL.GetReservationPaymentInfo(clsSession.PropertyID, clsSession.CompanyID, ReservationID);
        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 0 && dsPaymentInfo.Tables[0].Rows.Count > 0)
        {
            RoomRent = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[0].Rows[0]["RoomRent"]));
            Tax = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[0].Rows[0]["Tax"]));
            TotalAmount = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[0].Rows[0]["TotalAmount"]));
            NoofDays = Convert.ToInt32(Convert.ToString(dsPaymentInfo.Tables[0].Rows[0]["NoofDays"]));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 1 && dsPaymentInfo.Tables[1].Rows.Count > 0)
        {
            DepositAmount = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[1].Rows[0]["DepositAmount"]));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 2 && dsPaymentInfo.Tables[2].Rows.Count > 0)
        {
            PaidDeposit = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[2].Rows[0]["PaidDeposit"]));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 3 && dsPaymentInfo.Tables[3].Rows.Count > 0)
        {
            TotalPaymentReceived = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[3].Rows[0]["TotalPaidAmount"]));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 4 && dsPaymentInfo.Tables[4].Rows.Count > 0)
        {
            dtPaymentIfno = dsPaymentInfo.Tables[4];
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 5 && dsPaymentInfo.Tables[5].Rows.Count > 0)
        {
            TotalInfraServiceCharge = (int)(Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[5].Rows[0]["InfraServiceCharge"])));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 6 && dsPaymentInfo.Tables[6].Rows.Count > 0)
        {
            PaidInfraServiceCharge = (int)(Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[6].Rows[0]["PaidInfraServiceCharge"])));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 7 && dsPaymentInfo.Tables[7].Rows.Count > 0)
        {
            FoodCharges = (int)(Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[7].Rows[0]["FoodCharge"])));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 8 && dsPaymentInfo.Tables[8].Rows.Count > 0)
        {
            PaidFoodCharges = (int)(Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[8].Rows[0]["PaidFoodCharge"])));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 9 && dsPaymentInfo.Tables[9].Rows.Count > 0)
        {
            ElectricityCharges = (int)(Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[9].Rows[0]["ElectricityCharge"])));
        }

        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 10 && dsPaymentInfo.Tables[10].Rows.Count > 0)
        {
            PaidElectricityCharges = (int)(Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[10].Rows[0]["PaidElectricityCharge"])));
        }
    }

    public static string GetOriginalRoomNumber(string strRoomNumber)
    {
        string strRoomNo = string.Empty;

        if (strRoomNumber != "")
        {
            strRoomNo = strRoomNumber.Replace("(", "|").Replace(")", "");
        }

        return strRoomNo;
    }

    public static string GetUpperCaseText(string strInputString)
    {
        if (strInputString != null && Convert.ToString(WebConfigurationManager.AppSettings["IsUpperCase"]) == "1")
            return Convert.ToString(strInputString).ToUpper();
        else
            return strInputString;
    }
    #endregion
}
