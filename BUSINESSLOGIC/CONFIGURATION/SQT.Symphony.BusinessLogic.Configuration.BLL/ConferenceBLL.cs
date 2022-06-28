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

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class ConferenceBLL
    {

        //#region data Members

        //private static ConferenceDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ConferenceBLL()
        {
            //_dataObject = new ConferenceDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Conference
        /// </summary>
        /// <param name="businessObject">Conference object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Conference businessObject)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ConferenceID = Guid.NewGuid();

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
        /// Insert new Conference
        /// </summary>
        /// <param name="businessObject">Conference object</param>
        /// <returns>true for successfully saved</returns>
        

        public static bool Save(Conference businessObject, List<ConfConferenceType> lstConfConferenceType)
        {
            bool flag = false;
            ConferenceDAL _dataObject = null;
            ConfConferenceTypeDAL _objConfConferenceType = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ConferenceDAL(lt.Transaction);

                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ConferenceID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(businessObject);
                    // }

                    if (lstConfConferenceType.Count != 0)
                    {
                        _objConfConferenceType = new ConfConferenceTypeDAL(lt.Transaction);
                        foreach (ConfConferenceType item in lstConfConferenceType)
                        {
                            item.ConfConferenceTypeID = Guid.NewGuid();
                            item.ConferenceID = businessObject.ConferenceID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objConfConferenceType.Insert(item);
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
        /// Update existing Conference
        /// </summary>
        /// <param name="businessObject">Conference object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Conference businessObject)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
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


        public static bool Update(Conference businessObject, List<ConfConferenceType> lstConfConferenceType)
        {
            bool flag = false;
            ConferenceDAL _dataObject = null;
            ConfConferenceTypeDAL _objConfConferenceType = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ConferenceDAL(lt.Transaction);

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

                    _objConfConferenceType = new ConfConferenceTypeDAL(lt.Transaction);
                    _objConfConferenceType.DeleteByConferenceID(businessObject.ConferenceID);
                    if (lstConfConferenceType.Count != 0)
                    {   
                        foreach (ConfConferenceType item in lstConfConferenceType)
                        {
                            item.ConfConferenceTypeID = Guid.NewGuid();
                            item.ConferenceID = businessObject.ConferenceID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objConfConferenceType.Insert(item);
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
        /// get Conference by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Conference GetByPrimaryKey(Guid keys)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Conferences
        /// </summary>
        /// <returns>list</returns>
        public static List<Conference> GetAll(Conference obj)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Conferences
        /// </summary>
        /// <returns>list</returns>
        public static List<Conference> GetAll()
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Conference by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Conference> GetAllBy(Conference.ConferenceFields fieldName, object value)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Conferences
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Conference obj)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Conferences
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Conference by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Conference.ConferenceFields fieldName, object value)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Conference obj)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Conference by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Conference.ConferenceFields fieldName, object value)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllForRateCard(Guid companyID, Guid propertyID, Guid ratecardID)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SelectAllForRateCard(companyID, propertyID, ratecardID);
        }

        public static DataSet SearchConferenceData(Guid? ConferenceID, string ConferenceName, Guid? PropertyID, Guid? CompanyID)
        {
            ConferenceDAL _dataObject = new ConferenceDAL();
            return _dataObject.SearchConferenceData(ConferenceID, ConferenceName, PropertyID, CompanyID);
        }
        #endregion

    }
}
