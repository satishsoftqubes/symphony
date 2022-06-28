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
    public static class POSPointsBLL
    {

        //#region data Members

        //private static POSPointsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static POSPointsBLL()
        {
            //_dataObject = new POSPointsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new POSPoints
        /// </summary>
        /// <param name="businessObject">POSPoints object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(POSPoints businessObject)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.POSPointID = Guid.NewGuid();
                    
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

        public static bool SaveWithData(POSPoints objSavePOSPoints, List<CategoryPOSPoints> lstCategoryPOSPoints, List<ItemAvailability> lstItemAvailability)
        {
            bool flag = false;
            POSPointsDAL _objSavePOSPoints = null;
            CategoryPOSPointsDAL _objCategoryPOSPoints = null;
            ItemAvailabilityDAL _objItemAvailability = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objSavePOSPoints = new POSPointsDAL(lt.Transaction);

                if (objSavePOSPoints != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSavePOSPoints.POSPointID = Guid.NewGuid();

                    if (!objSavePOSPoints.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSavePOSPoints.BrokenRulesList.ToString());
                    }
                    flag = _objSavePOSPoints.Insert(objSavePOSPoints);
                    // }

                    if (lstCategoryPOSPoints.Count != 0)
                    {
                        _objCategoryPOSPoints = new CategoryPOSPointsDAL(lt.Transaction);
                        foreach (CategoryPOSPoints item in lstCategoryPOSPoints)
                        {
                            item.CategoryPOSPointID = Guid.NewGuid();
                            item.POSPointID = objSavePOSPoints.POSPointID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objCategoryPOSPoints.Insert(item);
                        }
                    }

                    if (lstItemAvailability.Count != 0)
                    {
                        _objItemAvailability = new ItemAvailabilityDAL(lt.Transaction);

                        foreach (ItemAvailability item in lstItemAvailability)
                        {
                            item.ItemAvailabilityID = Guid.NewGuid();
                            item.POSPointID = objSavePOSPoints.POSPointID;

                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objItemAvailability.Insert(item);
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
        /// Update existing POSPoints
        /// </summary>
        /// <param name="businessObject">POSPoints object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(POSPoints businessObject)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
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

        public static bool UpdateWithData(POSPoints objUpdatePOSPoints, List<CategoryPOSPoints> lstCategoryPOSPoints, List<ItemAvailability> lstItemAvailability)
        {
            bool flag = false;
            POSPointsDAL _objSavePOSPoints = null;
            CategoryPOSPointsDAL _objCategoryPOSPoints = null;
            ItemAvailabilityDAL _objItemAvailability = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objSavePOSPoints = new POSPointsDAL(lt.Transaction);

                if (objUpdatePOSPoints != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!objUpdatePOSPoints.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdatePOSPoints.BrokenRulesList.ToString());
                    }
                    flag = _objSavePOSPoints.Update(objUpdatePOSPoints);
                    // }

                    _objCategoryPOSPoints = new CategoryPOSPointsDAL(lt.Transaction);
                    _objCategoryPOSPoints.DeleteByField(CategoryPOSPoints.CategoryPOSPointsFields.POSPointID.ToString(), Convert.ToString(objUpdatePOSPoints.POSPointID));

                    if (lstCategoryPOSPoints.Count != 0)
                    {                        
                        foreach (CategoryPOSPoints item in lstCategoryPOSPoints)
                        {
                            item.CategoryPOSPointID = Guid.NewGuid();
                            item.POSPointID = objUpdatePOSPoints.POSPointID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objCategoryPOSPoints.Insert(item);
                        }
                    }

                    _objItemAvailability = new ItemAvailabilityDAL(lt.Transaction);
                    _objItemAvailability.DeleteByField(ItemAvailability.ItemAvailabilityFields.POSPointID.ToString(), Convert.ToString(objUpdatePOSPoints.POSPointID));

                    if (lstItemAvailability.Count != 0)
                    {
                        foreach (ItemAvailability item in lstItemAvailability)
                        {
                            item.ItemAvailabilityID = Guid.NewGuid();
                            item.POSPointID = objUpdatePOSPoints.POSPointID;

                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objItemAvailability.Insert(item);
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
        /// get POSPoints by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static POSPoints GetByPrimaryKey(Guid keys)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all POSPointss
        /// </summary>
        /// <returns>list</returns>
        public static List<POSPoints> GetAll(POSPoints obj)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all POSPointss
        /// </summary>
        /// <returns>list</returns>
        public static List<POSPoints> GetAll()
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of POSPoints by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<POSPoints> GetAllBy(POSPoints.POSPointsFields fieldName, object value)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all POSPointss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(POSPoints obj)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all POSPointss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of POSPoints by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(POSPoints.POSPointsFields fieldName, object value)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(POSPoints obj)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete POSPoints by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(POSPoints.POSPointsFields fieldName, object value)
        {
            POSPointsDAL _dataObject = new POSPointsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        /// <summary>
        /// Get Search Information 
        /// </summary>
        /// <param name="CompanyID">CompanyID as Guid</param>
        /// <param name="PropertyID">PropertyID as Guid</param>
        /// <param name="PointName">PointName as string</param>
        /// <param name="LocationTermID">LocationTermID as Guid</param>
        /// <returns></returns>
        public static DataSet SearchData(Guid? CompanyID, Guid? PropertyID, string PointName, Guid? LocationTermID)
        {
            POSPointsDAL _Obj = new POSPointsDAL();
            return _Obj.SearchPOSPoint(CompanyID, PropertyID, PointName, LocationTermID);
        }

        public static DataSet POSPointsGetAllForItem(Guid? CompanyID, Guid? PropertyID)
        {
            POSPointsDAL _Obj = new POSPointsDAL();
            return _Obj.POSPointsGetAllForItem(CompanyID, PropertyID);
        }

        public static DataSet SelectPosPoints(string strPosPoints)
        {
            POSPointsDAL _Obj = new POSPointsDAL();
            return _Obj.SelectPosPoints(strPosPoints);
        }
        #endregion

    }
}
