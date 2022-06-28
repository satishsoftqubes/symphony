using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;

public class clsBlockDateRate
{
    #region Variable Declaration
    #endregion

    #region Public Methods
    public static List<BlockDateRate> GetCal_RoomWorksheet(DateTime CheckInDate, DateTime CheckOutDate, Guid RoomTypeID, Guid RateID, Guid? DiscountID, int NoOfAdult, int Child, string Tax_Exempt_IDs, ref List<ResServiceList> lstResServiceList, ref string strStandardCheckInTime, ref string strStandardCheckOutTime, Guid? reservationID, string strMode)
    {
        List<BlockDateRate> lstBlockDateRate = new List<BlockDateRate>();
        List<ResServiceList> lstReservationSrvcList = new List<ResServiceList>();

        RateCardDetails objRateCardToGetData = new RateCardDetails();
        objRateCardToGetData.RateID = RateID;
        objRateCardToGetData.RoomTypeID = RoomTypeID;
        List<RateCardDetails> lstRateCards = RateCardDetailsBLL.GetAll(objRateCardToGetData);

        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

        if (lstRateCards.Count > 0)
        {
            RateCardDetails objRateCard = lstRateCards[0];
            DateTime dtStandardCheckInTime = new DateTime();
            DateTime dtStandardCheckOutTime = new DateTime();
            int intReservationDays = 0;
            bool IsEarly = false;
            bool IsLate = false;

            clsCommon.Reservation_GetTotalDays(null, CheckInDate, CheckOutDate, ref intReservationDays, ref IsEarly, ref IsLate);
            //DataTable dtRateCardTaxes = new DataTable();
            //DataTable dtTaxeSlabs = new DataTable();
            //DataSet dsRateCardTaxes = AccountBLL.SelectAllTaxesForRateCard(clsSession.PropertyID, clsSession.CompanyID, RateID);
            //if (dsRateCardTaxes != null && dsRateCardTaxes.Tables[0].Rows.Count > 0)
            //{
            //    dtRateCardTaxes = dsRateCardTaxes.Tables[0];

            //    if (dsRateCardTaxes.Tables.Count > 1 && dsRateCardTaxes.Tables[1].Rows.Count > 0)
            //    {
            //        dtTaxeSlabs = dsRateCardTaxes.Tables[1];
            //    }
            //}

            List<ReservationConfig> lstReservation = null;
            ReservationConfig objReservationConfig = new ReservationConfig();
            objReservationConfig.IsActive = true;
            objReservationConfig.CompanyID = clsSession.CompanyID;
            objReservationConfig.PropertyID = clsSession.PropertyID;
            lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

            if (lstReservation.Count != 0)
            {

                dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);
                strStandardCheckInTime = Convert.ToString(dtStandardCheckInTime);
                strStandardCheckOutTime = Convert.ToString(dtStandardCheckOutTime);
            }

            DataTable dtRateServices = new DataTable();
            DataSet dsRateServices = RateServiceJoinBLL.SelectAllDataByRateIDnRoomTypeID(RateID, RoomTypeID);
            if (dsRateServices != null && dsRateServices.Tables[0].Rows.Count > 0)
            {
                dtRateServices = dsRateServices.Tables[0];
            }

            // Get Special Days
            CalenderEvent objToGetList = new CalenderEvent();
            objToGetList.IsActive = true;
            objToGetList.PropertyID = clsSession.PropertyID;
            objToGetList.RateID = RateID;
            objToGetList.RoomTypeID = RoomTypeID;
            DataTable dtSpecialDays = new DataTable();
            DataSet dsSpecialDays = CalenderEventBLL.GetAllWithDataSet(objToGetList);
            if (dsSpecialDays != null && dsSpecialDays.Tables[0].Rows.Count > 0)
            {
                dtSpecialDays = dsSpecialDays.Tables[0];
            }


            decimal dcmlRackRate = 0;
            DateTime dtBlockDate = new DateTime();

            //// for loop for number of days of reservation period.
            decimal? dcmlPreviousDaysRate = null;
            decimal? dcmlPreviousDaysTaxRate = Convert.ToDecimal("0.00");
            BlockDateRate objBlockDateRateToAdd = null;
            for (int i = 0; i < intReservationDays; i++)
            {
                //// start with checkin date
                if (i == 0)
                {
                    dtBlockDate = CheckInDate;
                }

                objBlockDateRateToAdd = new BlockDateRate();
                objBlockDateRateToAdd.ResBlockDateRateID = Guid.NewGuid();
                objBlockDateRateToAdd.RateID = RateID;
                objBlockDateRateToAdd.PropertyID = clsSession.PropertyID;
                objBlockDateRateToAdd.CompanyID = clsSession.CompanyID;
                objBlockDateRateToAdd.IsActive = true;
                objBlockDateRateToAdd.RoomTypeID = RoomTypeID;
                objBlockDateRateToAdd.DiscountAmt = 0;

                objBlockDateRateToAdd.BlockDate = dtBlockDate;
                objBlockDateRateToAdd.InfraServiceCharge = objRateCard.ExtarbedCharge;//ExtarbedCharge is considered as InfraServiceCharge
                objBlockDateRateToAdd.FoodCharge = objRateCard.ExtraAdultRate;//ExtraAdultRate is considered as FoodCharges
                objBlockDateRateToAdd.ElectricityCharge = objRateCard.ChildRate;//ChildRate is considered as Electricity and Water Charges

                objBlockDateRateToAdd.IsFerEarly = false;
                objBlockDateRateToAdd.IsFerLate = false;

                DateTime dtdtBlockDatesNextDate = dtBlockDate.AddDays(1);
                objBlockDateRateToAdd.StartDate = new DateTime(dtBlockDate.Year, dtBlockDate.Month, Convert.ToInt32(dtBlockDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                objBlockDateRateToAdd.EndDate = new DateTime(dtdtBlockDatesNextDate.Year, dtdtBlockDatesNextDate.Month, dtdtBlockDatesNextDate.Day, dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);

                //// Assign ratecard's Rackrate.
                dcmlRackRate = Convert.ToDecimal(objRateCard.RackRate);


                //// Check if extra rate to take on individual Week Day or not....
                decimal dcmlWeekDayRate = 0;
                switch (dtBlockDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        dcmlWeekDayRate = Convert.ToDecimal(objRateCard.MondayRate);
                        break;
                    case DayOfWeek.Tuesday:
                        dcmlWeekDayRate = Convert.ToDecimal(objRateCard.TuesdayRate);
                        break;
                    case DayOfWeek.Wednesday:
                        dcmlWeekDayRate = Convert.ToDecimal(objRateCard.WednesdayRate);
                        break;
                    case DayOfWeek.Thursday:
                        dcmlWeekDayRate = Convert.ToDecimal(objRateCard.ThursdayRate);
                        break;
                    case DayOfWeek.Friday:
                        dcmlWeekDayRate = Convert.ToDecimal(objRateCard.FridayRate);
                        break;
                    case DayOfWeek.Saturday:
                        dcmlWeekDayRate = Convert.ToDecimal(objRateCard.SaturdayRate);
                        break;
                    case DayOfWeek.Sunday:
                        dcmlWeekDayRate = Convert.ToDecimal(objRateCard.SundayRate);
                        break;
                }

                dcmlRackRate = dcmlRackRate + dcmlWeekDayRate;


                //// Check If Day is in Special Days - Start
                if (dtSpecialDays != null && dtSpecialDays.Rows.Count > 0)
                {
                    DataRow[] drWeekDayRate = dtSpecialDays.Select("EventDate = '" + Convert.ToString(dtBlockDate) + "'");
                    if (drWeekDayRate.Length > 0)
                    {
                        if (Convert.ToBoolean(drWeekDayRate[0]["IsFlat"]))
                        {
                            dcmlRackRate = dcmlRackRate + Convert.ToDecimal(drWeekDayRate[0]["Rate"]);
                        }
                        else
                        {
                            decimal dcmlPrcntSpclRate = (dcmlRackRate * (Convert.ToDecimal(drWeekDayRate[0]["Rate"]))) / 100;
                            dcmlRackRate = dcmlRackRate + dcmlPrcntSpclRate;
                        }
                    }
                }
                //// Check If Day is in Special Days - End

                //// To add Extra Days Charge in RateCardRate. //Don't change this line's Location.
                bool flagGo = false;
                if (dcmlPreviousDaysRate == null || Convert.ToString(dcmlRackRate) != Convert.ToString(dcmlPreviousDaysRate))
                    flagGo = true;

                objBlockDateRateToAdd.RateCardRate = dcmlPreviousDaysRate = Convert.ToDecimal(dcmlRackRate);

                //// Apply Taxes on Days - Start
                decimal taxesOfRackRate = 0;
                if (reservationID != null && Convert.ToString(reservationID) != Convert.ToString(Guid.Empty) && strMode == "EDIT")
                {
                    //reservationID = reservationID;
                }
                else
                    reservationID = RateID;

                Guid? acctid = null;
                RateCard objRateCardData = new RateCard();
                objRateCardData = RateCardBLL.GetByPrimaryKey(RateID);
                if (objRateCardData != null)
                    acctid = objRateCardData.AcctID;

                //for (int j = 0; j < dtRateCardTaxes.Rows.Count; j++)
                //{
                if (flagGo)
                {
                    taxesOfRackRate += BlockDateRateBLL.CalculateTax(acctid, dcmlRackRate, "CR", null, reservationID, 3, null, null, clsSession.PropertyID, clsSession.CompanyID);
                    dcmlPreviousDaysTaxRate = taxesOfRackRate;
                }
                else
                    taxesOfRackRate += (decimal)dcmlPreviousDaysTaxRate;
                //}

                ////for (int j = 0; j < dtRateCardTaxes.Rows.Count; j++)
                ////{
                ////    DataRow[] drTaxSlab = dtTaxeSlabs.Select("TaxID = '" + Convert.ToString(dtRateCardTaxes.Rows[j]["AcctID"]) + "' and '" + dcmlRackRate + "' >= MinAmount and '" + dcmlRackRate + "' <= MaxAmount");

                ////    if (drTaxSlab.Length > 0)
                ////    {
                ////        if (Convert.ToBoolean(drTaxSlab[0]["IsTaxFlat"]))
                ////        {
                ////            taxesOfRackRate = taxesOfRackRate + Convert.ToDecimal(drTaxSlab[0]["TaxRate"]);
                ////        }
                ////        else
                ////        {
                ////            decimal taxRate = Convert.ToDecimal(drTaxSlab[0]["TaxRate"]);

                ////            taxesOfRackRate = taxesOfRackRate + Convert.ToDecimal((dcmlRackRate * taxRate) / 100);
                ////        }
                ////    }
                ////}

                objBlockDateRateToAdd.AppliedTax = taxesOfRackRate;
                dcmlRackRate = dcmlRackRate + taxesOfRackRate;

                objBlockDateRateToAdd.RoomRate = dcmlRackRate;

                //// Apply Taxes on Days - End

                objBlockDateRateToAdd.IsOverBook = false;

                //// Add new object in list
                lstBlockDateRate.Add(objBlockDateRateToAdd);


                ////Add Room Service in list Start
                if (dtRateServices.Rows.Count > 0) //// If any Room Services is there, then only proceed.
                {
                    if (dtBlockDate == CheckInDate) ////if blockdate is same as Checkin Date, add all room services with posting frequency daily and Once
                    {
                        for (int j = 0; j < dtRateServices.Rows.Count; j++)
                        {
                            ResServiceList objToAddSrvc = new ResServiceList();
                            objToAddSrvc.ResServiceID = Guid.NewGuid();
                            objToAddSrvc.ItemID = new Guid(Convert.ToString(dtRateServices.Rows[j]["ItemID"]));
                            objToAddSrvc.RateID = RateID;
                            objToAddSrvc.ResBlockDateRateID = objBlockDateRateToAdd.ResBlockDateRateID;
                            objToAddSrvc.Amount = Convert.ToDecimal(Convert.ToString(dtRateServices.Rows[j]["ServiceRate"]));
                            objToAddSrvc.Qty = 1;
                            objToAddSrvc.Total = objToAddSrvc.Amount * objToAddSrvc.Qty;
                            objToAddSrvc.ServiceDate = dtBlockDate;
                            objToAddSrvc.PostingDate = dtBlockDate;
                            //objToAddSrvc.StatusRemark
                            objToAddSrvc.PropertyID = clsSession.PropertyID;
                            objToAddSrvc.CompanyID = clsSession.CompanyID;
                            objToAddSrvc.IsActive = true;

                            lstReservationSrvcList.Add(objToAddSrvc);
                        }
                    }
                    else ////add all room services with posting frequency is only daily
                    {
                        for (int j = 0; j < dtRateServices.Rows.Count; j++)
                        {
                            if (Convert.ToString(dtRateServices.Rows[j]["Term"]).ToUpper() == "DAILY") //// Only add those room services who's posting frequency is Daily.
                            {
                                ResServiceList objToAddSrvc = new ResServiceList();
                                objToAddSrvc.ResServiceID = Guid.NewGuid();
                                objToAddSrvc.ItemID = new Guid(Convert.ToString(dtRateServices.Rows[j]["ItemID"]));
                                objToAddSrvc.RateID = RateID;
                                objToAddSrvc.ResBlockDateRateID = objBlockDateRateToAdd.ResBlockDateRateID;
                                objToAddSrvc.Amount = Convert.ToDecimal(Convert.ToString(dtRateServices.Rows[j]["ServiceRate"]));
                                objToAddSrvc.Qty = 1;
                                objToAddSrvc.Total = objToAddSrvc.Amount * objToAddSrvc.Qty;
                                objToAddSrvc.ServiceDate = dtBlockDate;
                                objToAddSrvc.PostingDate = dtBlockDate;
                                objToAddSrvc.PropertyID = clsSession.PropertyID;
                                objToAddSrvc.CompanyID = clsSession.CompanyID;
                                objToAddSrvc.IsActive = true;

                                lstReservationSrvcList.Add(objToAddSrvc);
                            }
                        }
                    }
                }
                ////Add Room Service in list End


                //// Add one day in date.
                dtBlockDate = dtBlockDate.AddDays(1);
            }

        }

        lstResServiceList = lstReservationSrvcList;
        return lstBlockDateRate;
    }
    #endregion
}
