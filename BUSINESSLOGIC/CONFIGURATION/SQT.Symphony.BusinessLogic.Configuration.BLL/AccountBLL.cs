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
    public static class AccountBLL
    {

        //#region data Members

        //private static AccountDAL _dataObject = null;

        //#endregion

        #region Constructor

        static AccountBLL()
        {
            //_dataObject = new AccountDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Account
        /// </summary>
        /// <param name="businessObject">Account object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Account businessObject)
        {
            AccountDAL _dataObject = new AccountDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AcctID = Guid.NewGuid();

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
        /// Update existing Account
        /// </summary>
        /// <param name="businessObject">Account object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Account businessObject)
        {
            AccountDAL _dataObject = new AccountDAL();
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
        /// get Account by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Account GetByPrimaryKey(Guid keys)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static List<Account> GetAll(Account obj)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static List<Account> GetAll()
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Account by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Account> GetAllBy(Account.AccountFields fieldName, object value)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Account obj)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Account by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Account.AccountFields fieldName, object value)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        public static DataSet GetRPTAccountRevenue(Guid? CompanyID, Guid? PropertyID, int? AcctGrpID, Guid? AcctID, string Frequency, DateTime? StartDate, DateTime? EndDate)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectRPTAccountRevenue(CompanyID, PropertyID, AcctGrpID, AcctID, Frequency, StartDate, EndDate);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Account obj)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Account by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Account.AccountFields fieldName, object value)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet SearchAccountData(Guid? AcctID, Guid? PropertyID, Guid? CompanyID, string AcctNo, string AcctName)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SearchAccountData(AcctID, PropertyID, CompanyID, AcctNo, AcctName);
        }
        public static bool SaveTaxData(Account objSaveAccount, List<TaxSlabe> lstSaveTaxSlabe, List<TaxRate> lstSaveDateSlabe)
        {
            bool flag = false;
            AccountDAL _objSaveAccount = null;
            TaxSlabeDAL _objTaxSlabe = null;
            TaxRateDAL _objTaxRateDal = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objSaveAccount = new AccountDAL(lt.Transaction);

                if (_objSaveAccount != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveAccount.AcctID = Guid.NewGuid();

                    if (!objSaveAccount.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveAccount.BrokenRulesList.ToString());
                    }
                    flag = _objSaveAccount.Insert(objSaveAccount);
                    // }
                    if (lstSaveDateSlabe != null && lstSaveDateSlabe.Count != 0)
                    {
                        _objTaxRateDal = new TaxRateDAL(lt.Transaction);
                        foreach (TaxRate itemForDateSlabe in lstSaveDateSlabe)
                        {
                            itemForDateSlabe.TaxID = objSaveAccount.AcctID;
                            if (!itemForDateSlabe.IsValid)
                            {
                                throw new InvalidBusinessObjectException(itemForDateSlabe.BrokenRulesList.ToString());
                            }
                            flag = _objTaxRateDal.Insert(itemForDateSlabe);
                        }
                    }





                    if (lstSaveTaxSlabe != null && lstSaveTaxSlabe.Count != 0)
                    {
                        _objTaxSlabe = new TaxSlabeDAL(lt.Transaction);
                        foreach (TaxSlabe item in lstSaveTaxSlabe)
                        {
                            item.TaxID = objSaveAccount.AcctID;

                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objTaxSlabe.Insert(item);
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



        public static bool UpdateTaxData(Account objUpdateAccount, List<TaxSlabe> lstSaveTaxSlabe, List<TaxRate> lstTaxRate)
        {
            bool flag = false;
            AccountDAL _objUpdateAccount = null;
            TaxRateDAL _objTaxRate = null;
            TaxSlabeDAL _objTaxSlabe = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objUpdateAccount = new AccountDAL(lt.Transaction);

                if (objUpdateAccount != null)
                {
                    if (!objUpdateAccount.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateAccount.BrokenRulesList.ToString());
                    }
                    flag = _objUpdateAccount.Update(objUpdateAccount);
                  

                    _objTaxRate = new TaxRateDAL(lt.Transaction);
                    _objTaxRate.DeleteByTaxID(objUpdateAccount.AcctID);
                    if (lstTaxRate != null && lstTaxRate.Count != 0)
                    {
                        _objTaxRate = new TaxRateDAL(lt.Transaction);
                        foreach (TaxRate itemForDateSlabe in lstTaxRate)
                        {
                            itemForDateSlabe.TaxID = objUpdateAccount.AcctID;
                            if (!itemForDateSlabe.IsValid)
                            {
                                throw new InvalidBusinessObjectException(itemForDateSlabe.BrokenRulesList.ToString());
                            }
                            flag = _objTaxRate.Insert(itemForDateSlabe);
                        }
                    }
                    _objTaxSlabe = new TaxSlabeDAL (lt.Transaction);
                    _objTaxSlabe.DeleteByField("TaxID", Convert.ToString(objUpdateAccount.AcctID));
                    if (lstSaveTaxSlabe != null && lstSaveTaxSlabe.Count != 0)
                    {
                        _objTaxSlabe = new TaxSlabeDAL(lt.Transaction);
                        foreach (TaxSlabe item in lstSaveTaxSlabe)
                        {
                            item.TaxID = objUpdateAccount.AcctID;

                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objTaxSlabe.Insert(item);
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

















        public static bool Save(Account objSaveAccount, List<TaxSlabe> lstSaveTaxSlabe)
        {
            bool flag = false;
            AccountDAL _objSaveAccount = null;
            TaxSlabeDAL _objTaxSlabe = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objSaveAccount = new AccountDAL(lt.Transaction);

                if (_objSaveAccount != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveAccount.AcctID = Guid.NewGuid();

                    if (!objSaveAccount.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveAccount.BrokenRulesList.ToString());
                    }
                    flag = _objSaveAccount.Insert(objSaveAccount);
                    // }

                    if (lstSaveTaxSlabe != null && lstSaveTaxSlabe.Count != 0)
                    {
                        _objTaxSlabe = new TaxSlabeDAL(lt.Transaction);
                        foreach (TaxSlabe item in lstSaveTaxSlabe)
                        {   
                            item.TaxID = objSaveAccount.AcctID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objTaxSlabe.Insert(item);
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

        public static bool Update(Account objUpdateAccount, List<TaxRate> lstTaxRate)
        {
            bool flag = false;
            AccountDAL _objUpdateAccount = null;
            TaxRateDAL _objTaxRate = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objUpdateAccount = new AccountDAL(lt.Transaction);

                if (objUpdateAccount != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!objUpdateAccount.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateAccount.BrokenRulesList.ToString());
                    }
                    flag = _objUpdateAccount.Update(objUpdateAccount);
                    // }

                    _objTaxRate = new TaxRateDAL(lt.Transaction);
                    _objTaxRate.DeleteByTaxID(objUpdateAccount.AcctID);
                    if (lstTaxRate.Count != 0 && lstTaxRate != null)
                    {
                        foreach (TaxRate item in lstTaxRate)
                        {
                            item.TaxRateID = Guid.NewGuid();
                            item.TaxID = objUpdateAccount.AcctID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objTaxRate.Insert(item);
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

        public static DataSet SelectAllTaxesForRateCard(Guid PropertyID, Guid CompanyID, Guid RateCardID)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAllTaxesForRateCard(PropertyID, CompanyID, RateCardID);
        }

        public static DataSet SelectTaxData(Guid PropertyID, Guid CompanyID, DateTime? Date)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectTaxData(PropertyID, CompanyID, Date);
        }

        public static DataSet GetPaymentAcctsByMOPTermID(Guid MOP_ProjectTermID, Guid PropertyID, Guid CompanyID)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.GetPaymentAcctsByMOPTermID(MOP_ProjectTermID, PropertyID, CompanyID);
        }

        #endregion

    }
}
