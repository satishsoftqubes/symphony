using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DAL;
using System.Configuration;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

//namespace SQT.Symphony.UI.Web.PosServices.Services
//{
/// <summary>
/// Summary description for CheckInGuestList
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class CheckInGuestList : System.Web.Services.WebService
{

    [WebMethod]
    public System.Xml.XmlDocument GetCheckInGuestListWihtXML()
    {
        string strXmlData = string.Empty;
        XmlDocument xmlData = new XmlDocument();

        Guid PropertyID = new Guid(Convert.ToString(ConfigurationSettings.AppSettings["POS_PropertyID"]));

        if (PropertyID != null && Convert.ToString(PropertyID) != "" && Convert.ToString(PropertyID) != Guid.Empty.ToString())
        {
            DataSet dsCheckInGuestList = new DataSet("GuestList");

            dsCheckInGuestList = GuestBLL.POS_SelectCheckInGuestList(PropertyID);

            if (dsCheckInGuestList != null && dsCheckInGuestList.Tables.Count > 0 && dsCheckInGuestList.Tables[0].Rows.Count > 0)
            {
                dsCheckInGuestList.Tables[0].TableName = "Guest";
                strXmlData = dsCheckInGuestList.GetXml();
                xmlData.LoadXml(strXmlData);

                //DataSet ds = new DataSet();
                //XmlNodeReader xnr = new XmlNodeReader(xmlData);
                //ds.ReadXml(xnr);
                //xnr.Close();
            }
        }

        return xmlData;
    }

    [WebMethod]
    public DataSet GetDataForOccupancyReport(string startDate, string endDate)
    {


        string CompanyID = ConfigurationManager.AppSettings["POS_CompanyID"].ToString();
        string PropertyID = ConfigurationManager.AppSettings["POS_PropertyID"].ToString();

        DataSet dsCheckInGuestList = new DataSet("dsOccupancy");
        //if (PropertyID != null && Convert.ToString(PropertyID) != "" && Convert.ToString(PropertyID) != Guid.Empty.ToString())
        //{
        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

        DateTime startdt = DateTime.ParseExact(startDate, "dd-MM-yyyy", objCultureInfo);// Convert.ToDateTime(startDate);
        DateTime enddt = DateTime.ParseExact(endDate, "dd-MM-yyyy", objCultureInfo); //Convert.ToDateTime(endDate);

        dsCheckInGuestList = BlockDateRateBLL.GetRPTOccupancyChartByBlockType(new Guid(CompanyID), new Guid(PropertyID), startdt, enddt);

        if (dsCheckInGuestList != null && dsCheckInGuestList.Tables.Count > 0 && dsCheckInGuestList.Tables[0].Rows.Count > 0)
        {
            dsCheckInGuestList.Tables[0].TableName = "dtOccupancy";
        }
        //}

        return dsCheckInGuestList;
    }
    [WebMethod]
    public DataSet GetDataForRoomAvailabilityChart(string StartDate, string EndDate, Guid? RoomTypeID, int Hrs)
    {

        string CompanyID = ConfigurationManager.AppSettings["POS_CompanyID"].ToString();
        string PropertyID = ConfigurationManager.AppSettings["POS_PropertyID"].ToString();


        DataSet dsForRoomAvailabilitydata = new DataSet("dsRoomData");
        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

        DateTime startdt = DateTime.ParseExact(StartDate, "dd-MM-yyyy", objCultureInfo);
        DateTime enddt = DateTime.ParseExact(EndDate, "dd-MM-yyyy", objCultureInfo);

        dsForRoomAvailabilitydata = ReservationBLL.GetRoomResrvationChartData(startdt, enddt, RoomTypeID, new Guid(PropertyID), new Guid(CompanyID), 24);

        if (dsForRoomAvailabilitydata != null && dsForRoomAvailabilitydata.Tables.Count > 0 && dsForRoomAvailabilitydata.Tables[0].Rows.Count > 0)
        {
            dsForRoomAvailabilitydata.Tables[0].TableName = "dtRoomAvailabilityData";
        }
        return dsForRoomAvailabilitydata;
    }

    [WebMethod]
    public DataSet GetDataForRoomType()
    {

        string CompanyID = ConfigurationManager.AppSettings["POS_CompanyID"].ToString();
        string PropertyID = ConfigurationManager.AppSettings["POS_PropertyID"].ToString();


        DataSet dsForRoomType = new DataSet("dsRoomTypeData");
        string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";
        dsForRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);

        if (dsForRoomType != null && dsForRoomType.Tables.Count > 0 && dsForRoomType.Tables[0].Rows.Count > 0)
        {
            dsForRoomType.Tables[0].TableName = "dtRoomTypeData";
        }
        return dsForRoomType;
    }
    [WebMethod]
    public DataSet GetRentPayOutPerQuarterData(DateTime? StartDate, DateTime? EndDate)
    {

        string CompanyID = ConfigurationManager.AppSettings["POS_CompanyID"].ToString();
        string PropertyID = ConfigurationManager.AppSettings["POS_PropertyID"].ToString();
        DataSet dsForRentPayOutPerQuarterData = new DataSet("dsForRentPayOutPerQuarterData");
        dsForRentPayOutPerQuarterData = BlockDateRateBLL.GetRPTYieldCalculation(new Guid(CompanyID), new Guid(PropertyID), StartDate, EndDate);

        if (dsForRentPayOutPerQuarterData != null && dsForRentPayOutPerQuarterData.Tables.Count > 0 && dsForRentPayOutPerQuarterData.Tables[0].Rows.Count > 0)
        {
            dsForRentPayOutPerQuarterData.Tables[0].TableName = "dtForRentPayOutPerQuarterData";
        }
        return dsForRentPayOutPerQuarterData;
    }

    [WebMethod]
    public DataSet GetTotalRevenueForQuarterForIR(DateTime StartDate, DateTime EndDate)
    {

        string CompanyID = ConfigurationManager.AppSettings["POS_CompanyID"].ToString();
        string PropertyID = ConfigurationManager.AppSettings["POS_PropertyID"].ToString();
        DataSet dsTotalRevenueOfQuarterForIR = new DataSet("dsTotalRevenueOfQuarterForIR");
        dsTotalRevenueOfQuarterForIR = CollectionBLL.GetTotalRevenueForQuarterForIR(StartDate, EndDate,new Guid(CompanyID), new Guid(PropertyID));

        if (dsTotalRevenueOfQuarterForIR != null && dsTotalRevenueOfQuarterForIR.Tables.Count > 0 && dsTotalRevenueOfQuarterForIR.Tables[0].Rows.Count > 0)
        {
            dsTotalRevenueOfQuarterForIR.Tables[0].TableName = "dtTotalRevenueOfQuarterForIR";
        }
        return dsTotalRevenueOfQuarterForIR;
    }

    [WebMethod]
    public DataSet GetNoOfBedsAndNoOfOccupiedBeds()
    {
        string CompanyID = ConfigurationManager.AppSettings["POS_CompanyID"].ToString();
        string PropertyID = ConfigurationManager.AppSettings["POS_PropertyID"].ToString();

        DataSet dsCheckInGuestList = new DataSet("dsNoOfBedsandNoOfOccupiedBeds");
        dsCheckInGuestList = ReservationBLL.GetOccupiedRoomAndTotalNoOfRoom(new Guid(CompanyID), new Guid(PropertyID));
        if (dsCheckInGuestList != null && dsCheckInGuestList.Tables.Count == 2)
        {
            dsCheckInGuestList.Tables[0].TableName = "dtNoOfOccupiedBeds";
            dsCheckInGuestList.Tables[1].TableName = "dtNoOfBeds";
        }
        return dsCheckInGuestList;
    }

    [WebMethod]
    public DataSet GetReservationsToSendOverstayNotification()
    {
        DataSet dsOverStayNotification = new DataSet("dsOverStayNotification");
        
        dsOverStayNotification = ReservationBLL.GetGuestEmail4OverstayNotification();

        return dsOverStayNotification;
    }
}

