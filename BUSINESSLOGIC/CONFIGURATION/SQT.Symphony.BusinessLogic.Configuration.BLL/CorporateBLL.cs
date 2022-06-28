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
    public static class CorporateBLL
    {

        //#region data Members

        //private static CorporateDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CorporateBLL()
        {
            //_dataObject = new CorporateDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Corporate
        /// </summary>
        /// <param name="businessObject">Corporate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Corporate businessObject)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CorporateID = Guid.NewGuid();

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

        public static bool Save(Corporate businessObject, Address objAddress)
        {
            bool flag = false;
            CorporateDAL _dataObject = null;
            AddressDAL _objAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new CorporateDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CorporateID = Guid.NewGuid();

                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        flag = _dataObject.Insert(businessObject);

                        if (objAddress != null)
                        {
                            _objAddress = new AddressDAL(lt.Transaction);
                            objAddress.AddressID = Guid.NewGuid();

                            if (!objAddress.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objAddress.BrokenRulesList.ToString());
                            }
                            flag = _objAddress.Insert(objAddress);
                            businessObject.AddressID = objAddress.AddressID;
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
            return flag;
        }

        /// <summary>
        /// Update existing Corporate
        /// </summary>
        /// <param name="businessObject">Corporate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Corporate businessObject)
        {
            CorporateDAL _dataObject = new CorporateDAL();
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

        public static bool Update(Corporate businessObject, Address objAddress)
        {
            bool flag = false;
            CorporateDAL _dataObject = null;
            AddressDAL _objAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new CorporateDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        flag = _dataObject.Update(businessObject);

                        if (objAddress != null)
                        {
                            _objAddress = new AddressDAL(lt.Transaction);

                            if (!objAddress.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objAddress.BrokenRulesList.ToString());
                            }
                            flag = _objAddress.Update(objAddress);
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
        /// get Corporate by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Corporate GetByPrimaryKey(Guid keys)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        public static DataSet GetDataSetByPrimaryKey(Guid keys)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectDataSetByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Corporates
        /// </summary>
        /// <returns>list</returns>
        public static List<Corporate> GetAll(Corporate obj)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectAll(obj);
        }

        public static List<Corporate> GetAllSearchData(Corporate obj)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectAllWithSearchData(obj);
        }

        /// <summary>
        /// get list of all Corporates
        /// </summary>
        /// <returns>list</returns>
        public static List<Corporate> GetAll()
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Corporate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Corporate> GetAllBy(Corporate.CorporateFields fieldName, object value)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Corporates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Corporate obj)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Corporates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Corporate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Corporate.CorporateFields fieldName, object value)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Corporate obj)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Corporate by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Corporate.CorporateFields fieldName, object value)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllForRateCard(Guid companyID, Guid propertyID, Guid rateCardID)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectAllForRateCard(companyID, propertyID, rateCardID);
        }

        public static bool UpdateVoucherImage(Guid? CompanyID, Guid? PropertyID, Guid? CorporateID, string VoucherImage)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            try
            {
                return _dataObject.UpdateVoucherImage(CompanyID, PropertyID, CorporateID, VoucherImage);        
            }
            catch
            {
                throw;
            }
        }

        public static DataSet SearchAgentData(Guid? PropertyID, Guid? CompanyID, string Name, string CompanyName, bool? IsDirectBill)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SearchAgentData(PropertyID, CompanyID, Name, CompanyName, IsDirectBill);
        }
        public static DataSet GetAgentWithReceipt(Guid? CompanyID, Guid? PropertyID)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectAgentWithReceipt(CompanyID, PropertyID);
        }
        public static DataSet GetCompanyData(Guid? CompanyID, Guid? PropertyID, bool? IsDirectBill)
        {
            CorporateDAL _dataObject = new CorporateDAL();
            return _dataObject.SelectCompanyData (CompanyID, PropertyID,IsDirectBill);
        }



        #endregion

    }
}
