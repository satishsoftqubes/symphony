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
    public static class SalesTeamBLL
    {

        //#region data Members

        //private static SalesTeamDAL _dataObject = null;

        //#endregion

        #region Constructor

        static SalesTeamBLL()
        {
            //_dataObject = new SalesTeamDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get Search Data Here
        /// </summary>
        /// <param name="DisplayName"></param>
        /// <returns></returns>
        public static DataSet GetSearchData(string DisplayName)
        {
            SalesTeamDAL _Obj = new SalesTeamDAL();
            return _Obj.GetSearchData(DisplayName);
        }
        /// <summary>
        /// Report Sales List
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="MobileNo"></param>
        /// <param name="Email"></param>
        /// <param name="DisplayName"></param>
        /// <param name="Country"></param>
        /// <param name="State"></param>
        /// <param name="City"></param>
        /// <returns></returns>
        public static DataSet GetRptSalesList(Guid? SalesTeamID, string FName, string MobileNo, string Email, string DisplayName, string Country, string State, string City)
        {
            SalesTeamDAL _Obj = new SalesTeamDAL();
            return _Obj.rptSalesList(SalesTeamID, FName, MobileNo, Email, DisplayName, Country, State, City);
        }

        /// <summary>
        /// Insert new SalesTeam
        /// </summary>
        /// <param name="businessObject">SalesTeam object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(SalesTeam businessObject)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.SalesTeamID = Guid.NewGuid();

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
        /// Save Sales Team Memeber
        /// </summary>
        /// <param name="BusinessObject"></param>
        /// <param name="AddressObj"></param>
        /// <returns></returns>
        public static bool Save(SalesTeam BusinessObject, Address objSaveAddress)
        {
            bool flag = false;
            SalesTeamDAL _objSalesTeam = null;
            AddressDAL _objAddress = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objSalesTeam = new SalesTeamDAL(lt.Transaction);

                if (BusinessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    BusinessObject.SalesTeamID = Guid.NewGuid();

                    if (!BusinessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(BusinessObject.BrokenRulesList.ToString());
                    }
                    flag = _objSalesTeam.Insert(BusinessObject);
                    // }
                    if (objSaveAddress != null)
                    {
                        _objAddress = new AddressDAL(lt.Transaction);
                        objSaveAddress.AddressID = Guid.NewGuid();
                        // item.CategoryID =    
                        if (!objSaveAddress.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objSaveAddress.BrokenRulesList.ToString());
                        }
                        flag = _objAddress.Insert(objSaveAddress);
                        BusinessObject.AddressID = objSaveAddress.AddressID;
                        flag = _objSalesTeam.Update(BusinessObject);
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

        public static bool SaveWithUserID(SalesTeam BusinessObject, Address objSaveAddress, User objSaveUser)
        {
            bool flag = false;
            SalesTeamDAL _objSalesTeam = null;
            AddressDAL _objAddress = null;
            UserDAL _objUserDAL = null;
            LinqTransaction lt = null;
            UserRoleDAL _objUserRole = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objSalesTeam = new SalesTeamDAL(lt.Transaction);

                if (BusinessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    BusinessObject.SalesTeamID = Guid.NewGuid();

                    if (!BusinessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(BusinessObject.BrokenRulesList.ToString());
                    }
                    flag = _objSalesTeam.Insert(BusinessObject);
                    // }
                    if (objSaveAddress != null)
                    {
                        _objAddress = new AddressDAL(lt.Transaction);
                        objSaveAddress.AddressID = Guid.NewGuid();
                        // item.CategoryID =    
                        if (!objSaveAddress.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objSaveAddress.BrokenRulesList.ToString());
                        }
                        flag = _objAddress.Insert(objSaveAddress);
                        BusinessObject.AddressID = objSaveAddress.AddressID;
                        flag = _objSalesTeam.Update(BusinessObject);
                    }

                    if (objSaveUser != null)
                    {
                        _objUserDAL = new UserDAL(lt.Transaction);
                        objSaveUser.UserTypeID = objSaveUser.UsearID;
                        flag = _objUserDAL.Insert(objSaveUser);

                        _objUserRole = new UserRoleDAL(lt.Transaction);
                        UserRole objSaveUserRole = new UserRole();
                        objSaveUserRole.UserRoleID = Guid.NewGuid();
                        objSaveUserRole.UserID = objSaveUser.UsearID;
                        objSaveUserRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["SalesRole"]);
                        objSaveUserRole.AssignedBy = objSaveUser.CreatedBy;
                        objSaveUserRole.AssignedOn = DateTime.Now;
                        objSaveUserRole.IsSynch = false;
                        objSaveUserRole.SynchOn = DateTime.Now;
                        flag = _objUserRole.Insert(objSaveUserRole);
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
        /// Update existing SalesTeam
        /// </summary>
        /// <param name="businessObject">SalesTeam object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(SalesTeam businessObject)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
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
        /// Save Sales Team Memeber
        /// </summary>
        /// <param name="BusinessObject"></param>
        /// <param name="AddressObj"></param>
        /// <returns></returns>
        public static bool Update(SalesTeam BusinessObject, Address objSaveAddress)
        {
            bool flag = false;
            SalesTeamDAL _objSalesTeam = null;
            AddressDAL _objAddress = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objSalesTeam = new SalesTeamDAL(lt.Transaction);

                if (BusinessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!BusinessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(BusinessObject.BrokenRulesList.ToString());
                    }
                    flag = _objSalesTeam.Update(BusinessObject);
                    // }
                    if (objSaveAddress != null)
                    {
                        _objAddress = new AddressDAL(lt.Transaction);
                        // item.CategoryID =    
                        if (!objSaveAddress.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objSaveAddress.BrokenRulesList.ToString());
                        }
                        flag = _objAddress.Update(objSaveAddress);
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
        /// get SalesTeam by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static SalesTeam GetByPrimaryKey(Guid keys)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all SalesTeams
        /// </summary>
        /// <returns>list</returns>
        public static List<SalesTeam> GetAll(SalesTeam obj)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all SalesTeams
        /// </summary>
        /// <returns>list</returns>
        public static List<SalesTeam> GetAll()
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of SalesTeam by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<SalesTeam> GetAllBy(SalesTeam.SalesTeamFields fieldName, object value)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all SalesTeams
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(SalesTeam obj)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all SalesTeams
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of SalesTeam by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(SalesTeam.SalesTeamFields fieldName, object value)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(SalesTeam obj)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete SalesTeam by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(SalesTeam.SalesTeamFields fieldName, object value)
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllSalesForEmailSubscription()
        {
            SalesTeamDAL _dataObject = new SalesTeamDAL();
            return _dataObject.GetAllSalesTeamForEmailSubscription();
        }
        #endregion

    }
}
