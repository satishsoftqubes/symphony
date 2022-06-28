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
using SQT.Symphony.BusinessLogic.IRMS.DAL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class CompanyBLL
    {

        //#region data Members

        //private static CompanyDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CompanyBLL()
        {
            //_dataObject = new CompanyDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Company
        /// </summary>
        /// <param name="businessObject">Company object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Company businessObject)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CompanyID = Guid.NewGuid();

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

        public static bool Save(Company objSaveCompany, Address objSaveAddress, List<Documents> lstSaveDocuments)
        {
            bool flag = false;
            CompanyDAL _objCompany = null;
            AddressDAL _objAddress = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objCompany = new CompanyDAL(lt.Transaction);

                if (objSaveCompany != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    //It is assigned from Front end.
                    //objSaveCompany.CompanyID = Guid.NewGuid();

                    if (!objSaveCompany.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveCompany.BrokenRulesList.ToString());
                    }
                    flag = _objCompany.Insert(objSaveCompany);
                    // }
                    if (objSaveAddress != null)
                    {
                        _objAddress = new AddressDAL(lt.Transaction);
                        objSaveAddress.AddressID = Guid.NewGuid();
                        objSaveAddress.CompanyID = objSaveCompany.CompanyID;
                        // item.CategoryID =    
                        if (!objSaveAddress.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objSaveAddress.BrokenRulesList.ToString());
                        }
                        flag = _objAddress.Insert(objSaveAddress);
                        objSaveCompany.PrimaryAddID = objSaveAddress.AddressID;
                        flag = _objCompany.Update(objSaveCompany);
                    }

                    if (lstSaveDocuments.Count != 0)
                    {
                        _objDocuments = new DocumentsDAL(lt.Transaction);
                        foreach (Documents item in lstSaveDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.AssociationID = objSaveCompany.CompanyID;
                            item.CompanyID = objSaveCompany.CompanyID;
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
        /// Update existing Company
        /// </summary>
        /// <param name="businessObject">Company object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Company businessObject)
        {
            CompanyDAL _dataObject = new CompanyDAL();
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

        public static bool Update(Company objUpdateCompany, Address objUpdateAddress, List<Documents> lstUpdateDocuments)
        {
            bool flag = false;
            CompanyDAL _objCompany = null;
            AddressDAL _objAddress = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objCompany = new CompanyDAL(lt.Transaction);

                if (objUpdateCompany != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!objUpdateCompany.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateCompany.BrokenRulesList.ToString());
                    }
                    flag = _objCompany.Update(objUpdateCompany);
                    // }
                    if (objUpdateAddress != null)
                    {
                        
                        _objAddress = new AddressDAL(lt.Transaction);
                        // item.CategoryID =    
                        if (!objUpdateAddress.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objUpdateAddress.BrokenRulesList.ToString());
                        }
                        if (objUpdateAddress.AddressID == Guid.Empty)
                        {
                            objUpdateAddress.AddressID = Guid.NewGuid();
                            objUpdateAddress.CompanyID = objUpdateCompany.CompanyID;
                            flag = _objAddress.Insert(objUpdateAddress);
                            objUpdateCompany.PrimaryAddID = objUpdateAddress.AddressID;
                            _objCompany.Update(objUpdateCompany);
                        }
                        else
                            flag = _objAddress.Update(objUpdateAddress);
                    }

                    _objDocuments = new DocumentsDAL(lt.Transaction);
                    _objDocuments.DeleteByAssociationID(objUpdateCompany.CompanyID);

                    if (lstUpdateDocuments.Count != 0)
                    {
                        foreach (Documents item in lstUpdateDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.AssociationID = objUpdateCompany.CompanyID;
                            item.CompanyID = objUpdateCompany.CompanyID;
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
        /// get Company by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Company GetByPrimaryKey(Guid keys)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Companys
        /// </summary>
        /// <returns>list</returns>
        public static List<Company> GetAll(Company obj)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Companys
        /// </summary>
        /// <returns>list</returns>
        public static List<Company> GetAll()
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Company by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Company> GetAllBy(Company.CompanyFields fieldName, object value)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Companys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Company obj)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Companys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Company by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Company.CompanyFields fieldName, object value)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Company obj)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Company by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Company.CompanyFields fieldName, object value)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetCompanyData(Guid? CompanyID)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            DataSet ds = _dataObject.SelectCompanyData(CompanyID);
            return ds;
        }

        public static DataSet GetAllCompanyData(Guid? CompanyID, string CompanyName, string DisplayName, string CompanyCode, Guid? CompanyType)
        {
            CompanyDAL _dataObject = new CompanyDAL();
            DataSet ds = _dataObject.SelectAllCompanyData(CompanyID, CompanyName, DisplayName, CompanyCode, CompanyType);
            return ds;

        }
        #endregion

    }
}
