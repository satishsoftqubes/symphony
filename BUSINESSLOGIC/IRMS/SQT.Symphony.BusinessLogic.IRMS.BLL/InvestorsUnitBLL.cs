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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.DAL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DAL;

namespace SQT.Symphony.BusinessLogic.IRMS.BLL
{
    public static class InvestorsUnitBLL
    {

        //#region data Members

        //private static InvestorsUnitDAL _dataObject = null;

        //#endregion

        #region Constructor

        static InvestorsUnitBLL()
        {
            //_dataObject = new InvestorsUnitDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new InvestorsUnit
        /// </summary>
        /// <param name="businessObject">InvestorsUnit object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(InvestorsUnit businessObject)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.InvestorRoomID = Guid.NewGuid();

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

        public static bool Save(InvestorsUnit objSaveInvestorsUnit, Room objUpdateRoom, List<Documents> lstSaveDocuments)
        {
            bool flag = false;
            InvestorsUnitDAL _objInvestorsUnit = null;
            RoomDAL _objRoom = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objInvestorsUnit = new InvestorsUnitDAL(lt.Transaction);

                if (objSaveInvestorsUnit != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveInvestorsUnit.InvestorRoomID = Guid.NewGuid();

                    if (!objSaveInvestorsUnit.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveInvestorsUnit.BrokenRulesList.ToString());
                    }
                    flag = _objInvestorsUnit.Insert(objSaveInvestorsUnit);
                    // }

                    if (objUpdateRoom != null)
                    {
                        _objRoom = new RoomDAL(lt.Transaction);
                        flag = _objRoom.Update(objUpdateRoom);
                    }
                    if (lstSaveDocuments.Count != 0)
                    {
                        _objDocuments = new DocumentsDAL(lt.Transaction);
                        foreach (Documents item in lstSaveDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.AssociationID = objSaveInvestorsUnit.InvestorRoomID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objDocuments.Insert(item);
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
            return flag;
        }

        /// <summary>
        /// Update existing InvestorsUnit
        /// </summary>
        /// <param name="businessObject">InvestorsUnit object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(InvestorsUnit businessObject)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
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

        public static bool Update(InvestorsUnit objUpdateInvestorsUnit, Room objUpdateRoom, List<Documents> lstUpdateDocuments)
        {
            bool flag = false;
            InvestorsUnitDAL _objInvestorsUnit = null;
            RoomDAL _objRoom = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objInvestorsUnit = new InvestorsUnitDAL(lt.Transaction);

                if (objUpdateInvestorsUnit != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{


                    if (!objUpdateInvestorsUnit.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateInvestorsUnit.BrokenRulesList.ToString());
                    }
                    flag = _objInvestorsUnit.Update(objUpdateInvestorsUnit);
                    // }

                    if (objUpdateRoom != null)
                    {
                        _objRoom = new RoomDAL(lt.Transaction);
                        flag = _objRoom.Update(objUpdateRoom);
                    }

                    _objDocuments = new DocumentsDAL(lt.Transaction);
                    _objDocuments.DeleteByAssociationID(objUpdateInvestorsUnit.InvestorRoomID);
                    if (lstUpdateDocuments.Count != 0)
                    {
                        foreach (Documents item in lstUpdateDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.AssociationID = objUpdateInvestorsUnit.InvestorRoomID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objDocuments.Insert(item);
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
            return flag;
        }
        /// <summary>
        /// get InvestorsUnit by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static InvestorsUnit GetByPrimaryKey(Guid keys)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all InvestorsUnits
        /// </summary>
        /// <returns>list</returns>
        public static List<InvestorsUnit> GetAll(InvestorsUnit obj)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all InvestorsUnits
        /// </summary>
        /// <returns>list</returns>
        public static List<InvestorsUnit> GetAll()
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of InvestorsUnit by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<InvestorsUnit> GetAllBy(InvestorsUnit.InvestorsUnitFields fieldName, object value)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all InvestorsUnits
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(InvestorsUnit obj)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all InvestorsUnits
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of InvestorsUnit by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(InvestorsUnit.InvestorsUnitFields fieldName, object value)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(InvestorsUnit obj)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete InvestorsUnit by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(InvestorsUnit.InvestorsUnitFields fieldName, object value)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetInvestorData(string InvestorQuery)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SelectInvestorData(InvestorQuery);
        }

        public static DataSet SearchInvestorsUnitData(Guid? InvestorRoomID, string RoomNo, Guid? InvesterID, Guid? PropertyID, Guid? RoomTypeID, string RoomTypeName)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.SearchInvestorsUnitData(InvestorRoomID, RoomNo, InvesterID, PropertyID, RoomTypeID, RoomTypeName);
        }
        public static DataSet CheckDuplicateInInvestorUnit(Guid? InvestorID, Guid? RoomID, Guid? RoomTypeID, Guid? PropertyID)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            return _dataObject.CheckDuplicateInInvestorUnit(InvestorID, RoomID, RoomTypeID, PropertyID);
        }
        public static DataSet GetInvestorUnitInfo(Guid? InvestorID, Guid? CompanyID)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.GetInvestorUnitInfo(InvestorID, CompanyID);
        }

        public static DataSet SelectInvestorUnitDetails(Guid? InvestorRoomID, Guid? InvestorID)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.SelectInvestorUnitDetails(InvestorRoomID, InvestorID);
        }

        public static bool CreateStandardSchedule(Guid investorRoomID, Guid createdBy)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            try
            {
                using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                {
                    return _dataObject.CreateStandardSchedule(investorRoomID, createdBy);
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataSet SelectPropertyName(Guid? InvestorID, Guid? CompanyID)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.SelectPropertyName(InvestorID, CompanyID);
        }

        public static DataSet GetPaymentDueReport(Guid? InvestorID, Guid? PropertyID, Guid? RelationshipManagerID, DateTime? StartDate, DateTime? EndDate)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.PaymentDueReport(InvestorID, PropertyID, RelationshipManagerID, StartDate, EndDate);
        }

        public static DataSet GetInvestorTermReport(Guid? InvestorID, Guid? UnitTypeID, Guid? UnitID, DateTime? StartDate, DateTime? EndDate)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.ReportInvestorTerm(InvestorID, UnitTypeID, UnitID, StartDate, EndDate);
        }

        public static DataSet GetInvestorDocumentationReport(Guid? InvestorID, Guid? UnitTypeID, Guid? UnitID)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.ReportInvestorDocumentation(InvestorID, UnitTypeID, UnitID);
        }

        public static DataSet GetLocationAnalysisReport(Guid? PropertyID, Guid? CountryID, Guid? RegionID, Guid? CityID, DateTime? StartDate, DateTime? EndDate)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.ReportLocationAnalysis(PropertyID, CountryID, RegionID, CityID, StartDate, EndDate);
        }
        public static DataSet GetLocationAnalysisReport(Guid? PropertyID, string LocationType, DateTime? StartDate, DateTime? EndDate)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.ReportLocationAnalysis(PropertyID, LocationType, StartDate, EndDate);
        }

        public static DataSet SelectInvestorsUnitForResell(Guid investorID)
        {
            InvestorsUnitDAL _Obj = new InvestorsUnitDAL();
            return _Obj.SelectInvestorsUnitForResell(investorID);
        }

        public static bool SaveResell(string SellToMode, Guid InvestorRoomID, Guid? BuyerInvestorID, DateTime UpdateOn, Guid UpdatedBy, DateTime SellDate)
        {
            InvestorsUnitDAL _dataObject = new InvestorsUnitDAL();
            try
            {
                using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                {

                    return _dataObject.Insert4Resell(SellToMode, InvestorRoomID, BuyerInvestorID, UpdateOn, UpdatedBy, SellDate);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}
