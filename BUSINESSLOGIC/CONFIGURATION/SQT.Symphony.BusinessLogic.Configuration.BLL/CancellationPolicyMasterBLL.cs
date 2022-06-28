using System;
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
    public static class CancellationPolicyMasterBLL
    {

        //#region data Members

        //private static CancellationPolicyMasterDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CancellationPolicyMasterBLL()
        {
            //_dataObject = new CancellationPolicyMasterDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new CancellationPolicyMaster
        /// </summary>
        /// <param name="businessObject">CancellationPolicyMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(CancellationPolicyMaster businessObject)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            try
            {
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ResPolicyID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    return _dataObject.Insert(businessObject);
                    //}
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



        public static bool Save(CancellationPolicyMaster objSaveCancellationPolicyMaster, List<CancellationPolicy> lstSaveCancellationPolicy)
        {
            bool flag = false;
            CancellationPolicyMasterDAL _objCancellationPolicyMaster = null;
            CancellationPolicyDAL _objCancellationPolicy = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objCancellationPolicyMaster = new CancellationPolicyMasterDAL(lt.Transaction);

                if (objSaveCancellationPolicyMaster != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveCancellationPolicyMaster.ResPolicyID = Guid.NewGuid();

                    if (!objSaveCancellationPolicyMaster.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveCancellationPolicyMaster.BrokenRulesList.ToString());
                    }
                    flag = _objCancellationPolicyMaster.Insert(objSaveCancellationPolicyMaster);
                    // }

                    if (lstSaveCancellationPolicy.Count != 0 && lstSaveCancellationPolicy != null)
                    {
                        _objCancellationPolicy = new CancellationPolicyDAL(lt.Transaction);
                        foreach (CancellationPolicy item in lstSaveCancellationPolicy)
                        {
                            item.PolicyID = Guid.NewGuid();
                            item.ResPolicyID = objSaveCancellationPolicyMaster.ResPolicyID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objCancellationPolicy.Insert(item);
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


        public static bool Update(CancellationPolicyMaster objUpdateCancellationPolicyMaster, List<CancellationPolicy> lstSaveCancellationPolicy)
        {
            bool flag = false;
            CancellationPolicyMasterDAL _objCancellationPolicyMaster = null;
            CancellationPolicyDAL _objCancellationPolicy = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objCancellationPolicyMaster = new CancellationPolicyMasterDAL(lt.Transaction);

                if (objUpdateCancellationPolicyMaster != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!objUpdateCancellationPolicyMaster.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateCancellationPolicyMaster.BrokenRulesList.ToString());
                    }
                    flag = _objCancellationPolicyMaster.Update(objUpdateCancellationPolicyMaster);
                    // }

                    _objCancellationPolicy = new CancellationPolicyDAL(lt.Transaction);
                    _objCancellationPolicy.DeleteByResPolicyID(objUpdateCancellationPolicyMaster.ResPolicyID);
                    if (lstSaveCancellationPolicy.Count != 0 && lstSaveCancellationPolicy != null)
                    {
                        foreach (CancellationPolicy item in lstSaveCancellationPolicy)
                        {
                            item.PolicyID = Guid.NewGuid();
                            item.ResPolicyID = objUpdateCancellationPolicyMaster.ResPolicyID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objCancellationPolicy.Insert(item);
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
        /// Update existing CancellationPolicyMaster
        /// </summary>
        /// <param name="businessObject">CancellationPolicyMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(CancellationPolicyMaster businessObject)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            try
            {
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    return _dataObject.Update(businessObject);
                    //}
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
        /// get CancellationPolicyMaster by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static CancellationPolicyMaster GetByPrimaryKey(Guid keys)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all CancellationPolicyMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<CancellationPolicyMaster> GetAll(CancellationPolicyMaster obj)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all CancellationPolicyMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<CancellationPolicyMaster> GetAll()
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of CancellationPolicyMaster by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<CancellationPolicyMaster> GetAllBy(CancellationPolicyMaster.CancellationPolicyMasterFields fieldName, object value)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(CancellationPolicyMaster obj)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete CancellationPolicyMaster by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(CancellationPolicyMaster.CancellationPolicyMasterFields fieldName, object value)
        {
            CancellationPolicyMasterDAL _dataObject = new CancellationPolicyMasterDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        #endregion

    }
}
