using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DAL;
using System.Globalization;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class RateCardBLL
    {

        //#region data Members

        //private static RateCardDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RateCardBLL()
        {
            //_dataObject = new RateCardDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RateCard
        /// </summary>
        /// <param name="businessObject">RateCard object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RateCard businessObject)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RateID = Guid.NewGuid();

                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        return _dataObject.Insert(businessObject);
                    }
                }
                else
                {
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool SaveRateCard(RateCard businessObject, List<RateTaxes> lstRateTaxes, List<RateServiceJoin> lstRateServices, List<RateCardDetails> lstRateCardDetails, List<CorporateRates> lstCorporateRates, DataTable dtCompServices, DataTable dtCalenderEvent)
        {
            bool flag = false;
            LinqTransaction lt = LinqSql.CreateTransaction("SQLConStr");

            try
            {
                RateCardDAL _dataObject = new RateCardDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RateID = Guid.NewGuid();

                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }

                        flag = _dataObject.Insert(businessObject);

                        if (lstRateTaxes != null && lstRateTaxes.Count > 0)
                        {
                            RateTaxesDAL objRateTaxDal = new RateTaxesDAL(lt.Transaction);

                            foreach (RateTaxes rateTax in lstRateTaxes)
                            {
                                rateTax.RateTaxID = Guid.NewGuid();
                                rateTax.RateID = businessObject.RateID;

                                if (!rateTax.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(rateTax.BrokenRulesList.ToString());
                                }

                                flag = objRateTaxDal.Insert(rateTax);
                            }
                        }

                        if (lstRateServices != null && lstRateServices.Count > 0)
                        {
                            RateServiceJoinDAL objRateServiceJoinDal = new RateServiceJoinDAL(lt.Transaction);

                            foreach (RateServiceJoin rateServiceJoin in lstRateServices)
                            {
                                rateServiceJoin.RateServiceID = Guid.NewGuid();
                                rateServiceJoin.RateID = businessObject.RateID;

                                if (!rateServiceJoin.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(rateServiceJoin.BrokenRulesList.ToString());
                                }

                                flag = objRateServiceJoinDal.Insert(rateServiceJoin);
                            }
                        }

                        if (lstRateCardDetails != null && lstRateCardDetails.Count > 0)
                        {
                            RateCardDetailsDAL objRateCardDetailDAL = new RateCardDetailsDAL(lt.Transaction);

                            foreach (RateCardDetails rateCardDetail in lstRateCardDetails)
                            {
                                rateCardDetail.RateCardDetailID = Guid.NewGuid();
                                rateCardDetail.RateID = businessObject.RateID;

                                if (!rateCardDetail.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(rateCardDetail.BrokenRulesList.ToString());
                                }

                                flag = objRateCardDetailDAL.Insert(rateCardDetail);

                                if (dtCompServices != null && dtCompServices.Rows.Count > 0)
                                {
                                    RateServiceJoinDAL objSaveRateServiceJoinDal = new RateServiceJoinDAL(lt.Transaction);

                                    DataRow[] dr = dtCompServices.Select("RoomTypeID = '" + Convert.ToString(rateCardDetail.RoomTypeID) + "'");
                                    for (int i = 0; i < dr.Length; i++)
                                    {
                                        RateServiceJoin objSaveRateServiceJoin = new RateServiceJoin();
                                        objSaveRateServiceJoin.RateServiceID = Guid.NewGuid();
                                        objSaveRateServiceJoin.RateID = businessObject.RateID;
                                        objSaveRateServiceJoin.ItemID = new Guid(Convert.ToString(dr[i]["ItemID"]));
                                        objSaveRateServiceJoin.PostingFreq_TermID = new Guid(Convert.ToString(dr[i]["TermID"]));
                                        objSaveRateServiceJoin.IsActive = true;
                                        objSaveRateServiceJoin.RateCardDetailID = rateCardDetail.RateCardDetailID;
                                        objSaveRateServiceJoin.RoomTypeID = new Guid(Convert.ToString(dr[i]["RoomTypeID"]));

                                        flag = objSaveRateServiceJoinDal.Insert(objSaveRateServiceJoin);
                                    }

                                }
                            }
                        }

                        if (lstCorporateRates != null && lstCorporateRates.Count > 0)
                        {
                            CorporateRatesDAL objCorporateRatesDAL = new CorporateRatesDAL(lt.Transaction);
                            CorporateDAL objCorporateDAL = new CorporateDAL(lt.Transaction);

                            foreach (CorporateRates corporateRate in lstCorporateRates)
                            {
                                corporateRate.CorporateRateID = Guid.NewGuid();
                                corporateRate.RateID = businessObject.RateID;

                                if (!corporateRate.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(corporateRate.BrokenRulesList.ToString());
                                }

                                flag = objCorporateRatesDAL.Insert(corporateRate);

                                if (Convert.ToBoolean(corporateRate.IsDefaultThis))
                                {
                                    flag = objCorporateDAL.UpdateDefaultRateID("UPDATEONE", corporateRate.CorporateID, businessObject.RateID);
                                }
                            }
                        }

                        if (dtCalenderEvent != null && dtCalenderEvent.Rows.Count > 0)
                        {
                            CalenderEventDAL objCalenderEventDAL = new CalenderEventDAL(lt.Transaction);
                            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                            for (int i = 0; i < dtCalenderEvent.Rows.Count; i++)
                            {
                                CalenderEvent objSaveCalenderEvent = new CalenderEvent();

                                bool isflat = false;
                                if (Convert.ToString(dtCalenderEvent.Rows[i]["IsFlat"]) == "0")
                                    isflat = false;
                                else
                                    isflat = true;

                                objSaveCalenderEvent.EventID = Guid.NewGuid();
                                objSaveCalenderEvent.PropertyID = new Guid(Convert.ToString(HttpContext.Current.Session["PropertyID"]));
                                //objSaveCalenderEvent.EventDate = DateTime.ParseExact(Convert.ToString(dtCalenderEvent.Rows[i]["EventDate"]), Convert.ToString(HttpContext.Current.Session["DateFormat"]), objCultureInfo);
                                objSaveCalenderEvent.EventDate = Convert.ToDateTime(dtCalenderEvent.Rows[i]["EventDate"]); // DateTime.ParseExact(Convert.ToString(dtCalenderEvent.Rows[i]["EventDate"]), "MM/dd/yyyy", objCultureInfo);
                                objSaveCalenderEvent.EventName = Convert.ToString(dtCalenderEvent.Rows[i]["EventName"]);
                                objSaveCalenderEvent.Rate = Convert.ToDecimal(Convert.ToString(dtCalenderEvent.Rows[i]["Rate"]));
                                objSaveCalenderEvent.IsFlat = isflat;
                                objSaveCalenderEvent.IsActive = true;
                                objSaveCalenderEvent.RateID = businessObject.RateID;
                                objSaveCalenderEvent.RoomTypeID = new Guid(Convert.ToString(dtCalenderEvent.Rows[i]["RoomTypeID"]));

                                flag = objCalenderEventDAL.Insert(objSaveCalenderEvent);
                            }
                        }

                        if (flag)
                        {
                            lt.Commit();
                            return flag;
                        }
                        else
                        {
                            lt.Rollback();
                            return flag;
                        }
                    }
                }
                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
        }

        //Update Rate Card with Data.
        public static bool UpdateRateCard(RateCard businessObject, List<RateTaxes> lstRateTaxes, List<RateTaxes> lstTaxesFromDB, List<RateCardDetails> lstRateCardDetails, List<RateCardDetails> lstRateCardDetailsFromDB, List<CorporateRates> lstCorporateRates, List<CorporateRates> lstCorporateRatesFromDB, Guid UpdatedBy, string rateCardType, DataTable dtCompServices, DataTable dtCalenderEvent)
        {
            bool flag = false;
            LinqTransaction lt = LinqSql.CreateTransaction("SQLConStr");

            try
            {
                RateCardDAL _dataObject = new RateCardDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }

                        ////Update RateCard table.
                        flag = _dataObject.Update(businessObject);


                        ////If lstRateTaxes contains record....
                        if (lstRateTaxes != null && lstRateTaxes.Count > 0)
                        {
                            RateTaxesDAL objRateTaxDal = new RateTaxesDAL(lt.Transaction);

                            ////If any RateTaxes exist in DB
                            if (lstTaxesFromDB != null && lstTaxesFromDB.Count > 0)
                            {
                                ////Check all records from DB one by one, if match with lstRateTaxes, then update it, o/w delete from DB.
                                for (int i = 0; i < lstTaxesFromDB.Count; i++)
                                {
                                    bool blIsProcessed = false;
                                    ////To check if individual record from DB exist in lstRateTaxes or not,
                                    for (int j = 0; j < lstRateTaxes.Count; j++)
                                    {
                                        ////If match found,
                                        if (lstTaxesFromDB[i].TaxID == lstRateTaxes[j].TaxID)
                                        {
                                            //// Nothing to do in this case, only remove from lstRateTaxes to avoid to new insert after for loop of j
                                            lstTaxesFromDB[i].UpdatedBy = UpdatedBy;
                                            lstTaxesFromDB[i].UpdatedOn = DateTime.Now;
                                            objRateTaxDal.Update(lstTaxesFromDB[i]);

                                            lstRateTaxes.RemoveAt(j);
                                            j--;
                                            blIsProcessed = true;
                                            break;
                                        }
                                    }

                                    ////After checking all record of lstRateTaxes, if blIsProcessed is remain false, that means to delete from DB.
                                    if (!blIsProcessed)
                                    {
                                        ////Delete From DB.
                                        flag = objRateTaxDal.Delete(lstTaxesFromDB[i].RateTaxID);
                                    }
                                }
                            }

                            ////After processign lstTaxesFromDB, lstRateTaxes contains only those records which are new to insert in DB
                            foreach (RateTaxes rateTax in lstRateTaxes)
                            {
                                ////Insert new Record in DB.
                                rateTax.RateTaxID = Guid.NewGuid();
                                rateTax.RateID = businessObject.RateID;

                                if (!rateTax.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(rateTax.BrokenRulesList.ToString());
                                }

                                flag = objRateTaxDal.Insert(rateTax);
                            }
                        }
                        else
                        {
                            ////lstRateTaxes not contain any record, so Delete all RateTaxes from DB by RateID.
                            RateTaxesDAL objRateTaxDal = new RateTaxesDAL(lt.Transaction);
                            flag = objRateTaxDal.DeleteByField(RateTaxes.RateTaxesFields.RateID.ToString(), businessObject.RateID.ToString());
                        }

                        #region Commented Code of RateServices
                        ////////If lstRateServices contains record....
                        ////if (lstRateServices != null && lstRateServices.Count > 0)
                        ////{
                        ////    RateServiceJoinDAL objRateServiceJoinDal = new RateServiceJoinDAL(lt.Transaction);

                        ////    ////Object to get RateServiceJoin from DB.
                        ////    RateServiceJoin objToGetList = new RateServiceJoin();
                        ////    objToGetList.RateID = businessObject.RateID;
                        ////    objToGetList.IsActive = true;
                        ////    List<RateServiceJoin> lstRateServicesFromDB = objRateServiceJoinDal.SelectAll(objToGetList);

                        ////    ////If any RateServiceJoin exist in DB
                        ////    if (lstRateServicesFromDB != null && lstRateServicesFromDB.Count > 0)
                        ////    {
                        ////        ////Check all records from DB one by one, if match with lstRateServices, then update it, o/w delete from DB.
                        ////        for (int i = 0; i < lstRateServicesFromDB.Count; i++)
                        ////        {
                        ////            bool blIsProcessed = false;
                        ////            ////To check if individual record from DB exist in lstRateServices or not,
                        ////            for (int j = 0; j < lstRateServices.Count; j++)
                        ////            {
                        ////                ////If match found,
                        ////                if (lstRateServicesFromDB[i].RateServiceID == lstRateServices[j].RateServiceID)
                        ////                {
                        ////                    //// Update lstRateServicesFromDB record with related values of lstRateServices and Update in DB.
                        ////                    lstRateServicesFromDB[i].ItemID = lstRateServices[j].ItemID;
                        ////                    lstRateServicesFromDB[i].PostingFreq_TermID = lstRateServices[j].PostingFreq_TermID;
                        ////                    lstRateServicesFromDB[i].UpdatedBy = UpdatedBy;
                        ////                    lstRateServicesFromDB[i].UpdatedOn = DateTime.Now;

                        ////                    flag = objRateServiceJoinDal.Update(lstRateServicesFromDB[i]);

                        ////                    ////Remove from lstRateTaxes to avoid to new insert after for loop of j
                        ////                    lstRateServices.RemoveAt(j);
                        ////                    blIsProcessed = true;
                        ////                    break;
                        ////                }
                        ////            }

                        ////            ////After checking all record of lstRateServices, if blIsProcessed is remain false, that means to delete from DB.
                        ////            if (!blIsProcessed)
                        ////            {
                        ////                ////Delete From DB.
                        ////                flag = objRateServiceJoinDal.Delete(lstRateServicesFromDB[i].RateServiceID);
                        ////            }
                        ////        }
                        ////    }

                        ////    ////After processign lstRateServicesFromDB, lstRateServices contains only those records which are new to insert in DB
                        ////    foreach (RateServiceJoin rateServiceJoin in lstRateServices)
                        ////    {
                        ////        ////Insert new Record in DB.
                        ////        rateServiceJoin.RateServiceID = Guid.NewGuid();
                        ////        rateServiceJoin.RateID = businessObject.RateID;

                        ////        if (!rateServiceJoin.IsValid)
                        ////        {
                        ////            throw new InvalidBusinessObjectException(rateServiceJoin.BrokenRulesList.ToString());
                        ////        }

                        ////        flag = objRateServiceJoinDal.Insert(rateServiceJoin);
                        ////    }
                        ////}
                        ////else
                        ////{
                        ////    ////lstRateServices not contain any record, so Delete all RateServices from DB by RateID.
                        ////    RateServiceJoinDAL objRateServiceJoinDal = new RateServiceJoinDAL(lt.Transaction);
                        ////    flag = objRateServiceJoinDal.DeleteByField(RateServiceJoin.RateServiceJoinFields.RateID.ToString(), businessObject.RateID.ToString());
                        ////}
                        #endregion

                        RateServiceJoinDAL objRateServiceJoinDal = new RateServiceJoinDAL(lt.Transaction);
                        objRateServiceJoinDal.DeleteByRateID(businessObject.RateID);

                        ////If lstRateCardDetails contains record....
                        if (lstRateCardDetails != null && lstRateCardDetails.Count > 0)
                        {
                            RateCardDetailsDAL objRateCardDetailDAL = new RateCardDetailsDAL(lt.Transaction);

                            ////If any RateCardDetails exist in DB
                            if (lstRateCardDetailsFromDB != null && lstRateCardDetailsFromDB.Count > 0)
                            {
                                ////Check all records from DB one by one, if match with lstRateCardDetails, then update it, o/w delete from DB.
                                for (int i = 0; i < lstRateCardDetailsFromDB.Count; i++)
                                {
                                    bool blIsProcessed = false;
                                    ////To check if individual record from DB exist in lstRateCardDetails or not,
                                    for (int j = 0; j < lstRateCardDetails.Count; j++)
                                    {
                                        Guid? toCompareID = null;
                                        Guid? toCompareIDFromDB = null;

                                        if (rateCardType.ToUpper() != "CONFERENCE")
                                        {
                                            toCompareID = lstRateCardDetails[j].RoomTypeID;
                                            toCompareIDFromDB = lstRateCardDetailsFromDB[i].RoomTypeID;
                                        }
                                        else
                                        {
                                            toCompareID = lstRateCardDetails[j].ConferenceID;
                                            toCompareIDFromDB = lstRateCardDetailsFromDB[i].ConferenceID;
                                        }

                                        ////If match found,
                                        if (toCompareIDFromDB == toCompareID)
                                        {
                                            //// Update lstRateCardDetailsFromDB record with related values of lstRateCardDetails and Update in DB.
                                            lstRateCardDetailsFromDB[i].RackRate = lstRateCardDetails[j].RackRate;
                                            lstRateCardDetailsFromDB[i].DepositAmount = lstRateCardDetails[j].DepositAmount;
                                            lstRateCardDetailsFromDB[i].TotalRackRate = lstRateCardDetails[j].TotalRackRate;
                                            lstRateCardDetailsFromDB[i].ExtarbedCharge = lstRateCardDetails[j].ExtarbedCharge;
                                            lstRateCardDetailsFromDB[i].ExtraAdultRate = lstRateCardDetails[j].ExtraAdultRate;
                                            lstRateCardDetailsFromDB[i].ChildRate = lstRateCardDetails[j].ChildRate;
                                            lstRateCardDetailsFromDB[i].MondayRate = lstRateCardDetails[j].MondayRate;
                                            lstRateCardDetailsFromDB[i].TuesdayRate = lstRateCardDetails[j].TuesdayRate;
                                            lstRateCardDetailsFromDB[i].WednesdayRate = lstRateCardDetails[j].WednesdayRate;
                                            lstRateCardDetailsFromDB[i].ThursdayRate = lstRateCardDetails[j].ThursdayRate;
                                            lstRateCardDetailsFromDB[i].FridayRate = lstRateCardDetails[j].FridayRate;
                                            lstRateCardDetailsFromDB[i].SaturdayRate = lstRateCardDetails[j].SaturdayRate;
                                            lstRateCardDetailsFromDB[i].SundayRate = lstRateCardDetails[j].SundayRate;
                                            lstRateCardDetailsFromDB[i].UpdatedBy = UpdatedBy;
                                            lstRateCardDetailsFromDB[i].UpdatedOn = DateTime.Now;

                                            flag = objRateCardDetailDAL.Update(lstRateCardDetailsFromDB[i]);

                                            if (dtCompServices != null && dtCompServices.Rows.Count > 0)
                                            {
                                                DataRow[] dr = dtCompServices.Select("RoomTypeID = '" + Convert.ToString(lstRateCardDetailsFromDB[i].RoomTypeID) + "'");
                                                for (int l = 0; l < dr.Length; l++)
                                                {
                                                    RateServiceJoin objSaveRateServiceJoin = new RateServiceJoin();
                                                    objSaveRateServiceJoin.RateServiceID = Guid.NewGuid();
                                                    objSaveRateServiceJoin.RateID = businessObject.RateID;
                                                    objSaveRateServiceJoin.ItemID = new Guid(Convert.ToString(dr[l]["ItemID"]));
                                                    objSaveRateServiceJoin.PostingFreq_TermID = new Guid(Convert.ToString(dr[l]["TermID"]));
                                                    objSaveRateServiceJoin.IsActive = true;
                                                    objSaveRateServiceJoin.RateCardDetailID = lstRateCardDetailsFromDB[i].RateCardDetailID;
                                                    objSaveRateServiceJoin.RoomTypeID = new Guid(Convert.ToString(dr[l]["RoomTypeID"]));

                                                    flag = objRateServiceJoinDal.Insert(objSaveRateServiceJoin);
                                                }
                                            }

                                            ////Remove from lstRateTaxes to avoid to new insert after for loop of j
                                            lstRateCardDetails.RemoveAt(j);
                                            j--;
                                            blIsProcessed = true;
                                            break;
                                        }
                                    }

                                    ////After checking all record of lstRateCardDetails, if blIsProcessed is remain false, that means to delete from DB.
                                    if (!blIsProcessed)
                                    {
                                        ////Delete From DB.
                                        flag = objRateCardDetailDAL.Delete(lstRateCardDetailsFromDB[i].RateCardDetailID);
                                    }
                                }
                            }

                            ////After processign lstRateCardDetailsFromDB, lstRateCardDetails contains only those records which are new to insert in DB
                            foreach (RateCardDetails rateCardDetail in lstRateCardDetails)
                            {
                                ////Insert new Record in DB.
                                rateCardDetail.RateCardDetailID = Guid.NewGuid();
                                rateCardDetail.RateID = businessObject.RateID;

                                if (!rateCardDetail.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(rateCardDetail.BrokenRulesList.ToString());
                                }

                                flag = objRateCardDetailDAL.Insert(rateCardDetail);

                                if (dtCompServices != null && dtCompServices.Rows.Count > 0)
                                {
                                    DataRow[] dr = dtCompServices.Select("RoomTypeID = '" + Convert.ToString(rateCardDetail.RoomTypeID) + "'");
                                    for (int i = 0; i < dr.Length; i++)
                                    {
                                        RateServiceJoin objSaveRateServiceJoin = new RateServiceJoin();
                                        objSaveRateServiceJoin.RateServiceID = Guid.NewGuid();
                                        objSaveRateServiceJoin.RateID = businessObject.RateID;
                                        objSaveRateServiceJoin.ItemID = new Guid(Convert.ToString(dr[i]["ItemID"]));
                                        objSaveRateServiceJoin.PostingFreq_TermID = new Guid(Convert.ToString(dr[i]["TermID"]));
                                        objSaveRateServiceJoin.IsActive = true;
                                        objSaveRateServiceJoin.RateCardDetailID = rateCardDetail.RateCardDetailID;
                                        objSaveRateServiceJoin.RoomTypeID = new Guid(Convert.ToString(dr[i]["RoomTypeID"]));

                                        flag = objRateServiceJoinDal.Insert(objSaveRateServiceJoin);
                                    }
                                }
                            }
                        }
                        else
                        {
                            ////lstRateCardDetails not contain any record, so Delete all RateCardDetails from DB by RateID.
                            RateCardDetailsDAL objRateCardDetailDAL = new RateCardDetailsDAL(lt.Transaction);
                            flag = objRateCardDetailDAL.DeleteByField(RateCardDetails.RateCardDetailsFields.RateID.ToString(), businessObject.RateID.ToString());
                        }


                        ////If lstCorporateRates contains record....
                        if (lstCorporateRates != null && lstCorporateRates.Count > 0)
                        {
                            CorporateRatesDAL objCorporateRatesDAL = new CorporateRatesDAL(lt.Transaction);
                            CorporateDAL objCorporateDAL = new CorporateDAL(lt.Transaction);

                            ////Update Corporate's DefaultRateCardID with NULL initially....
                            flag = objCorporateDAL.UpdateDefaultRateID("UPDATEALL", null, businessObject.RateID);

                            ////If any CorporateRates exist in DB
                            if (lstCorporateRatesFromDB != null && lstCorporateRatesFromDB.Count > 0)
                            {
                                ////Check all records from DB one by one, if match with lstCorporateRates, then update it, o/w delete from DB.
                                for (int i = 0; i < lstCorporateRatesFromDB.Count; i++)
                                {
                                    bool blIsProcessed = false;
                                    ////To check if individual record from DB exist in lstCorporateRates or not,
                                    for (int j = 0; j < lstCorporateRates.Count; j++)
                                    {
                                        ////If match found,
                                        if (lstCorporateRatesFromDB[i].CorporateID == lstCorporateRates[j].CorporateID)
                                        {
                                            //// Update lstCorporateRatesFromDB record with related values of lstCorporateRates and Update in DB.

                                            lstCorporateRatesFromDB[i].UpdatedBy = UpdatedBy;
                                            lstCorporateRatesFromDB[i].UpdatedOn = DateTime.Now;

                                            flag = objCorporateRatesDAL.Update(lstCorporateRatesFromDB[i]);

                                            ////if lstCorporateRates[j]'s IsDefaultThis flag is true, then Update Corporate's DefaultRateCardID with this RateCardID
                                            if (Convert.ToBoolean(lstCorporateRates[j].IsDefaultThis))
                                            {
                                                flag = objCorporateDAL.UpdateDefaultRateID("UPDATEONE", lstCorporateRates[j].CorporateID, businessObject.RateID);
                                            }

                                            ////Remove from lstCorporateRates to avoid to new insert after for loop of j
                                            lstCorporateRates.RemoveAt(j);
                                            j--;
                                            blIsProcessed = true;
                                            break;
                                        }
                                    }

                                    ////After checking all record of lstCorporateRates, if blIsProcessed is remain false, that means to delete from DB.
                                    if (!blIsProcessed)
                                    {
                                        ////Delete From DB.
                                        flag = objCorporateRatesDAL.Delete(lstCorporateRatesFromDB[i].CorporateRateID);
                                    }
                                }
                            }

                            ////After processign lstCorporateRatesFromDB, lstCorporateRates contains only those records which are new to insert in DB
                            foreach (CorporateRates corporateRates in lstCorporateRates)
                            {
                                ////Insert new Record in DB.
                                corporateRates.CorporateRateID = Guid.NewGuid();
                                corporateRates.RateID = businessObject.RateID;

                                if (!corporateRates.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(corporateRates.BrokenRulesList.ToString());
                                }

                                flag = objCorporateRatesDAL.Insert(corporateRates);

                                ////if corporateRates's IsDefaultThis flag is true, then Update Corporate's DefaultRateCardID with this RateCardID
                                if (Convert.ToBoolean(corporateRates.IsDefaultThis))
                                {
                                    flag = objCorporateDAL.UpdateDefaultRateID("UPDATEONE", corporateRates.CorporateID, businessObject.RateID);
                                }
                            }
                        }
                        else
                        {
                            ////lstCorporateRates not contain any record, so Delete all RateCardCorporateRates from DB by RateID.
                            CorporateRatesDAL objCorporateRatesDAL = new CorporateRatesDAL(lt.Transaction);
                            CorporateDAL objCorporateDAL = new CorporateDAL(lt.Transaction);

                            ////Update Corporate's DefaultRateCardID with NULL if no record in lstCorporateRates.
                            flag = objCorporateDAL.UpdateDefaultRateID("UPDATEALL", null, businessObject.RateID);
                            flag = objCorporateRatesDAL.DeleteByField(CorporateRates.CorporateRatesFields.RateID.ToString(), businessObject.RateID.ToString());
                        }

                        if (dtCalenderEvent != null && dtCalenderEvent.Rows.Count > 0)
                        {
                            CalenderEventDAL objCalenderEventDAL = new CalenderEventDAL(lt.Transaction);
                            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                            for (int i = 0; i < dtCalenderEvent.Rows.Count; i++)
                            {
                                CalenderEvent objSaveCalenderEvent = new CalenderEvent();

                                bool isflat = false;
                                if (Convert.ToString(dtCalenderEvent.Rows[i]["IsFlat"]) == "0")
                                    isflat = false;
                                else
                                    isflat = true;

                                objSaveCalenderEvent.EventID = Guid.NewGuid();
                                objSaveCalenderEvent.PropertyID = new Guid(Convert.ToString(HttpContext.Current.Session["PropertyID"]));
                                objSaveCalenderEvent.EventDate = DateTime.ParseExact(Convert.ToString(dtCalenderEvent.Rows[i]["EventDate"]), Convert.ToString(HttpContext.Current.Session["DateFormat"]), objCultureInfo);
                                objSaveCalenderEvent.EventName = Convert.ToString(dtCalenderEvent.Rows[i]["EventName"]);
                                objSaveCalenderEvent.Rate = Convert.ToDecimal(Convert.ToString(dtCalenderEvent.Rows[i]["Rate"]));
                                objSaveCalenderEvent.IsFlat = isflat;
                                objSaveCalenderEvent.IsActive = true;
                                objSaveCalenderEvent.RateID = businessObject.RateID;
                                objSaveCalenderEvent.RoomTypeID = new Guid(Convert.ToString(dtCalenderEvent.Rows[i]["RoomTypeID"]));

                                flag = objCalenderEventDAL.Insert(objSaveCalenderEvent);
                            }
                        }

                        if (flag)
                        {
                            lt.Commit();
                            return flag;
                        }
                        else
                        {
                            lt.Rollback();
                            return flag;
                        }
                    }
                }
                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Update existing RateCard
        /// </summary>
        /// <param name="businessObject">RateCard object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RateCard businessObject)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        return _dataObject.Update(businessObject);
                    }
                }
                else
                {
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get RateCard by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RateCard GetByPrimaryKey(Guid keys)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all RateCards
        /// </summary>
        /// <returns>list</returns>
        public static List<RateCard> GetAll(RateCard obj)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all RateCards
        /// </summary>
        /// <returns>list</returns>
        public static List<RateCard> GetAll()
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of RateCard by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RateCard> GetAllBy(RateCard.RateCardFields fieldName, object value)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all RateCards
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RateCard obj)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all RateCards
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of RateCard by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RateCard.RateCardFields fieldName, object value)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RateCard obj)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete RateCard by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RateCard.RateCardFields fieldName, object value)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllByProperty(Guid? PropertyID, Guid? CompanyID, Guid? StayTypeID, Guid? RateType_TermID, string Code, string RateCardName, DateTime? StartDate, DateTime? EndDate)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAllByProperty(PropertyID, CompanyID, StayTypeID, RateType_TermID, Code, RateCardName, StartDate, EndDate);
        }

        public static DataSet GetDataByPrimaryKey(Guid rateCardID)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectDataByPrimaryKey(rateCardID);
        }

        public static DataSet GetAllByRateCardType(Guid propertyID, Guid companyID, string rateCardType)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAllByRateCardType(propertyID, companyID, rateCardType);
        }

        public static DataSet GetAllForCorporate(Guid propertyID, Guid companyID, Guid corporateID, string rateCardType)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAllForCorporate(propertyID, companyID, corporateID, rateCardType);
        }

        public static DataSet GetAllAvailableRateCards(DateTime? startDate, DateTime? endDate, Guid? roomTypeID, Guid? companyAgentID, Guid? travelAgentID, Guid? conferenceID, Guid propertyID, Guid companyID)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectAllAvailableRateCards(startDate, endDate, roomTypeID, companyAgentID, travelAgentID, conferenceID, propertyID, companyID);
        }
        public static DataSet GetRateCardForOverStay(DateTime? startDate, DateTime? endDate, Guid propertyID, Guid companyID)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectOverStayRateCard(startDate, endDate, propertyID, companyID);
        }

        public static DataSet GetDashboardRatecardData(Guid propertyID, Guid companyID, Guid? RateID, bool IsPerRoom)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectDashboardRatecardData(propertyID, companyID, RateID, IsPerRoom);
        }

        public static DataSet GetDashboardServicesData(Guid? RateID, Guid? RoomTypeID)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectDashboardServicesData(RateID, RoomTypeID);
        }

        public static DataSet GetForRoomRateCardResStatus(Guid propertyID, Guid companyID, Guid? RateID)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectForRoomRateCardResStatus(propertyID, companyID, RateID);
        }

        public static DataSet GetRateCardsReqMinDaysByRateCardIDs(string RateCardIDs)
        {
            RateCardDAL _dataObject = new RateCardDAL();
            return _dataObject.SelectRateCardsReqMinDaysByRateCardIDs(RateCardIDs);
        }

        #endregion

    }
}
