using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class clsSession
{
    /// <summary>
    /// Current loggedin user's UserID
    /// </summary>
    public static Guid UserID
    {
        get
        {
            return HttpContext.Current.Session["UserID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["UserID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["UserID"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's LogInLogID
    /// </summary>
    public static Guid LogInLogID
    {
        get
        {
            return HttpContext.Current.Session["LogInLogID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["LogInLogID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["LogInLogID"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's User type
    /// </summary>
    public static string UserType
    {
        get
        {
            return HttpContext.Current.Session["UserType"] != null ? Convert.ToString(HttpContext.Current.Session["UserType"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["UserType"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's CompanyID
    /// </summary>
    public static Guid CompanyID
    {
        get
        {
            return HttpContext.Current.Session["CompanyID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["CompanyID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["CompanyID"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's DisplayName
    /// </summary>
    public static string DisplayName
    {
        get
        {
            return HttpContext.Current.Session["DisplayName"] != null ? Convert.ToString(HttpContext.Current.Session["DisplayName"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["DisplayName"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's UserName
    /// </summary>
    public static string UserName
    {
        get
        {
            return HttpContext.Current.Session["UserName"] != null ? Convert.ToString(HttpContext.Current.Session["UserName"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["UserName"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's DisplayName
    /// </summary>
    public static string HotelCode
    {
        get
        {
            return HttpContext.Current.Session["HotelCode"] != null ? Convert.ToString(HttpContext.Current.Session["HotelCode"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["HotelCode"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's PropertyID
    /// </summary>
    public static Guid PropertyID
    {
        get
        {
            return HttpContext.Current.Session["PropertyID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["PropertyID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["PropertyID"] = value;
        }
    }

    /// <summary>
    /// To save Type of item which is to Open in Edit Mode.
    /// </summary>
    public static string ToEditItemType
    {
        get
        {
            return HttpContext.Current.Session["ToEditItemType"] != null ? Convert.ToString(HttpContext.Current.Session["ToEditItemType"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["ToEditItemType"] = value;
        }
    }

    /// <summary>
    /// To save ID of item which is to Open in Edit Mode.
    /// </summary>
    public static Guid ToEditItemID
    {
        get
        {
            return HttpContext.Current.Session["ToEditItemID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["ToEditItemID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["ToEditItemID"] = value;
        }
    }

    /// <summary>
    /// Allowed decimal value after Decimal Point
    /// </summary>
    public static Int16 DigitsAfterDecimalPoint
    {
        get
        {
            return HttpContext.Current.Session["DigitsAfterDecimalPoint"] != null ? Convert.ToInt16(HttpContext.Current.Session["DigitsAfterDecimalPoint"]) : Convert.ToInt16(2);
        }
        set
        {
            HttpContext.Current.Session["DigitsAfterDecimalPoint"] = value;
        }
    }

    public static string DateFormat
    {
        get
        {
            return HttpContext.Current.Session["DateFormat"] != null ? Convert.ToString(HttpContext.Current.Session["DateFormat"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["DateFormat"] = value;
        }
    }

    public static string TimeFormat
    {
        get
        {
            return HttpContext.Current.Session["TimeFormat"] != null ? Convert.ToString(HttpContext.Current.Session["TimeFormat"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["TimeFormat"] = value;
        }
    }

    public static string CompanyName
    {
        get
        {
            return HttpContext.Current.Session["CompanyName"] != null ? Convert.ToString(HttpContext.Current.Session["CompanyName"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["CompanyName"] = value;
        }
    }

    public static string PropertyName
    {
        get
        {
            return HttpContext.Current.Session["PropertyName"] != null ? Convert.ToString(HttpContext.Current.Session["PropertyName"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["PropertyName"] = value;
        }
    }
    public static string CurrentCurrency
    {
        get
        {
            return HttpContext.Current.Session["CurrentCurrency"] != null ? Convert.ToString(HttpContext.Current.Session["CurrentCurrency"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["CurrentCurrency"] = value;
        }
    }

    public static string UserRights
    {
        get
        {
            return HttpContext.Current.Session["UserRights"] != null ? Convert.ToString(HttpContext.Current.Session["UserRights"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["UserRights"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's RoleType
    /// </summary>
    public static string RoleType
    {
        get
        {
            return HttpContext.Current.Session["RoleType"] != null ? Convert.ToString(HttpContext.Current.Session["RoleType"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["RoleType"] = value;
        }
    }

    /// <summary>
    /// Current loggedin user's Selected Module
    /// </summary>
    public static string SelectedModule
    {
        get
        {
            return HttpContext.Current.Session["SelectedModule"] != null ? Convert.ToString(HttpContext.Current.Session["SelectedModule"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["SelectedModule"] = value;
        }
    }

    public static Guid DefaultDepositAcctID
    {
        get
        {
            return HttpContext.Current.Session["DefaultDepositAcctID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["DefaultDepositAcctID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["DefaultDepositAcctID"] = value;
        }
    }

    public static Guid DefaultCounterID
    {
        get
        {
            return HttpContext.Current.Session["DefaultCounterID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["DefaultCounterID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["DefaultCounterID"] = value;
        }
    }

    public static string StandardCheckInTime
    {
        get
        {
            return HttpContext.Current.Session["StandardCheckInTime"] != null ? Convert.ToString(HttpContext.Current.Session["StandardCheckInTime"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["StandardCheckInTime"] = value;
        }
    }

    public static string StandardCheckOutTime
    {
        get
        {
            return HttpContext.Current.Session["StandardCheckOutTime"] != null ? Convert.ToString(HttpContext.Current.Session["StandardCheckOutTime"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["StandardCheckOutTime"] = value;
        }
    }

    public static Guid Location_TermID
    {
        get
        {
            return HttpContext.Current.Session["Location_TermID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["Location_TermID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["Location_TermID"] = value;
        }
    }

    public static Guid CounterID
    {
        get
        {
            return HttpContext.Current.Session["CounterID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["CounterID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["CounterID"] = value;
        }
    }

    public static Guid CounterLoginLogID
    {
        get
        {
            return HttpContext.Current.Session["CounterLoginLogID"] != null ? new Guid(Convert.ToString(HttpContext.Current.Session["CounterLoginLogID"])) : Guid.Empty;
        }
        set
        {
            HttpContext.Current.Session["CounterLoginLogID"] = value;
        }
    }

    public static string CounterName
    {
        get
        {
            return HttpContext.Current.Session["CounterName"] != null ? Convert.ToString(HttpContext.Current.Session["CounterName"]) : string.Empty;
        }
        set
        {
            HttpContext.Current.Session["CounterName"] = value;
        }
    }
}
