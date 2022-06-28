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
    public static class ProspectsBLL
    {

        //#region data Members

        //private static ProspectsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ProspectsBLL()
        {
            //_dataObject = new ProspectsDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Search Information
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        public static DataSet SearchInfo(string FName, string MobileNo, string Email, string CompanyName, string ProspectName, Guid? ProspectStatus, Guid? CompanyID, Guid? ProspectID, Guid? ContactedBy, string Location, string Reference,Guid? RegionID,Guid? ReferenceTermID)
        {
            ProspectsDAL _Obj = new ProspectsDAL();
            return _Obj.SearchInfo(FName, MobileNo, Email, CompanyName, ProspectName, ProspectStatus, CompanyID, ProspectID, ContactedBy, Location, Reference, RegionID, ReferenceTermID);
        }
        /// <summary>
        /// Report Prospects List
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="MobileNo"></param>
        /// <param name="Email"></param>
        /// <param name="StatusID"></param>
        /// <param name="Country"></param>
        /// <param name="State"></param>
        /// <param name="City"></param>
        /// <returns></returns>
        public static DataSet GetRptProspectList(string FName, string MobileNo, string Email, Guid? StatusID, string Country, string State, string City)
        {
            ProspectsDAL _Obj = new ProspectsDAL();
            return _Obj.rptProspectsList(FName, MobileNo, Email, StatusID, Country, State, City);
        }
        /// <summary>
        /// Insert new Prospects
        /// </summary>
        /// <param name="businessObject">Prospects object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Prospects businessObject)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ProspectID = Guid.NewGuid();
                    
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
        /// <summary>
        /// Insert new Investor
        /// </summary>
        /// <param name="businessObject">Investor object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Prospects businessObject, Address InvPAdd)
        {
            bool flag = false;
            ProspectsDAL _dataObject = new ProspectsDAL();
            AddressDAL _objPAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ProspectsDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ProspectID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(businessObject);
                    // }
                    if (InvPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        InvPAdd.AddressID = Guid.NewGuid();
                        // item.CategoryID =    
                        if (!InvPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(InvPAdd.BrokenRulesList.ToString());
                        }
                        flag = _objPAddress.Insert(InvPAdd);
                        businessObject.AddressID = InvPAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
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
        /// Update existing Prospects
        /// </summary>
        /// <param name="businessObject">Prospects object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Prospects businessObject)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            try
            {
                if(businessObject != null)
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
        /// Insert new Investor
        /// </summary>
        /// <param name="businessObject">Investor object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Prospects businessObject, Address InvPAdd)
        {
            bool flag = false;
            ProspectsDAL _dataObject = new ProspectsDAL();
            AddressDAL _objPAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ProspectsDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Update(businessObject);
                    // }
                    if (InvPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        // item.CategoryID =    
                        if (!InvPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(InvPAdd.BrokenRulesList.ToString());
                        }
                        flag = _objPAddress.Update(InvPAdd);
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
        /// get Prospects by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Prospects GetByPrimaryKey(Guid keys)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Prospectss
        /// </summary>
        /// <returns>list</returns>
        public static List<Prospects> GetAll(Prospects obj)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Prospectss
        /// </summary>
        /// <returns>list</returns>
        public static List<Prospects> GetAll()
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Prospects by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Prospects> GetAllBy(Prospects.ProspectsFields fieldName, object value)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Prospectss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Prospects obj)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Prospectss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Prospects by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Prospects.ProspectsFields fieldName, object value)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Prospects obj)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Prospects by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Prospects.ProspectsFields fieldName, object value)
        {
            ProspectsDAL _dataObject = new ProspectsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        /// <summary>
        /// Get Prospect Email Subscription List
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllProspectsForEmailSubscription()
        {
            ProspectsDAL _Obj = new ProspectsDAL();
            return _Obj.GetAllProspectsForEmailSubscription();
        }

        public static DataSet GetRptConversionExecutive(string ChannelParnerFirm, string ExecutiveName, DateTime? StartDate, DateTime? EndDate)
        {
            ProspectsDAL _Obj = new ProspectsDAL();
            return _Obj.rptConversionExecutive(ChannelParnerFirm, ExecutiveName, StartDate, EndDate);
        }

        public static DataSet GetRptConversionExecutive_CP(string ChannelParnerFirm, Guid? ChannelPartnerID, DateTime? StartDate, DateTime? EndDate)
        {
            ProspectsDAL _Obj = new ProspectsDAL();
            return _Obj.rptConversionExecutive_CP(ChannelParnerFirm, ChannelPartnerID, StartDate, EndDate);
        }

        public static DataSet GetRptConversionExecutive_RefThrough(Guid? ReferenceThrough, string ReferenceName, DateTime? StartDate, DateTime? EndDate)
        {
            ProspectsDAL _Obj = new ProspectsDAL();
            return _Obj.rptConversionExecutive_RefThrough(ReferenceThrough, ReferenceName, StartDate, EndDate);
        }
        #endregion

    }
}
