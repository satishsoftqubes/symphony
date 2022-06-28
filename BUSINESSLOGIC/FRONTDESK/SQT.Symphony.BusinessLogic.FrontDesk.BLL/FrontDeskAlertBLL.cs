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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.DAL;

namespace SQT.Symphony.BusinessLogic.FrontDesk.BLL
{
    public static class FrontDeskAlertBLL
    {

        //#region data Members

        //private static FrontDeskAlertDAL _dataObject = null;

        //#endregion

        #region Constructor

        static FrontDeskAlertBLL()
        {
            //_dataObject = new FrontDeskAlertDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new FrontDeskAlert
        /// </summary>
        /// <param name="businessObject">FrontDeskAlert object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(FrontDeskAlert businessObject)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.FrontDeskAlertID = Guid.NewGuid();
                    
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
        /// Update existing FrontDeskAlert
        /// </summary>
        /// <param name="businessObject">FrontDeskAlert object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(FrontDeskAlert businessObject)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
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
        /// get FrontDeskAlert by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static FrontDeskAlert GetByPrimaryKey(Guid keys)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all FrontDeskAlerts
        /// </summary>
        /// <returns>list</returns>
        public static List<FrontDeskAlert> GetAll(FrontDeskAlert obj)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all FrontDeskAlerts
        /// </summary>
        /// <returns>list</returns>
        public static List<FrontDeskAlert> GetAll()
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of FrontDeskAlert by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<FrontDeskAlert> GetAllBy(FrontDeskAlert.FrontDeskAlertFields fieldName, object value)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all FrontDeskAlerts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(FrontDeskAlert obj)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all FrontDeskAlerts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of FrontDeskAlert by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(FrontDeskAlert.FrontDeskAlertFields fieldName, object value)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(FrontDeskAlert obj)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete FrontDeskAlert by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(FrontDeskAlert.FrontDeskAlertFields fieldName, object value)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        // Method added to retrieve All User List For Specific Company and Property and also UserType = "Employee"
        public static DataSet GetAllUserWhoEmpBLL(string strQueryForAllUserBLL)
        {
            FrontDeskAlertDAL _dataObject = new FrontDeskAlertDAL();
            return _dataObject.GetAllUserWhoEmp(strQueryForAllUserBLL);
        }

        public static bool SaveWithDetails(FrontDeskAlertMaster objFrontDeskAlertMaster, List<FrontDeskAlert> lstSaveFrontDeskAlert)
        {
            bool flag = false;
            FrontDeskAlertMasterDAL _objFrontDeskAlertMasterDAL = null;
            FrontDeskAlertDAL _objFrontDeskAlertDAL = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objFrontDeskAlertMasterDAL = new FrontDeskAlertMasterDAL(lt.Transaction);

                if (objFrontDeskAlertMaster != null)
                {

                    objFrontDeskAlertMaster.FrontDeskAlertMsgID  = Guid.NewGuid();

                    if (!objFrontDeskAlertMaster.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objFrontDeskAlertMaster.BrokenRulesList.ToString());
                    }
                    flag = _objFrontDeskAlertMasterDAL.Insert(objFrontDeskAlertMaster);
                    // }

                    if (lstSaveFrontDeskAlert != null && lstSaveFrontDeskAlert.Count != 0 )
                    {
                        _objFrontDeskAlertDAL = new FrontDeskAlertDAL(lt.Transaction);
                        foreach (FrontDeskAlert item in lstSaveFrontDeskAlert)
                        {
                            item.FrontDeskAlertID  = Guid.NewGuid();
                            item.FrontDeskAlertMsgID = objFrontDeskAlertMaster.FrontDeskAlertMsgID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objFrontDeskAlertDAL.Insert(item);
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


        public static bool UpdateWithDetails(FrontDeskAlertMaster objFrontDeskAlertMaster, List<FrontDeskAlert> lstSaveFrontDeskAlert)
        {
            bool flag = false;
            FrontDeskAlertMasterDAL _objFrontDeskAlertMasterDAL = null;
            FrontDeskAlertDAL _objFrontDeskAlertDAL = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objFrontDeskAlertMasterDAL = new FrontDeskAlertMasterDAL(lt.Transaction);

                if (objFrontDeskAlertMaster != null)
                {

                   

                    if (!objFrontDeskAlertMaster.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objFrontDeskAlertMaster.BrokenRulesList.ToString());
                    }
                    flag = _objFrontDeskAlertMasterDAL.Update(objFrontDeskAlertMaster);
                    _objFrontDeskAlertDAL = new FrontDeskAlertDAL (lt.Transaction);
                    //new Guid(Convert.ToString
                    _objFrontDeskAlertDAL.DeleteByField("FrontDeskAlertMsgID", Convert.ToString(objFrontDeskAlertMaster.FrontDeskAlertMsgID));
                    if (lstSaveFrontDeskAlert != null && lstSaveFrontDeskAlert.Count != 0)
                    {
                        _objFrontDeskAlertDAL = new FrontDeskAlertDAL(lt.Transaction);
                        foreach (FrontDeskAlert item in lstSaveFrontDeskAlert)
                        {
                            item.FrontDeskAlertID = Guid.NewGuid();
                            item.FrontDeskAlertMsgID = objFrontDeskAlertMaster.FrontDeskAlertMsgID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objFrontDeskAlertDAL.Insert(item);
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

        



        #endregion

    }
}
