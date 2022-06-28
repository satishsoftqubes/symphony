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
    public static class ChannelPartnerBLL
    {

        //#region data Members

        //private static ChannelPartnerDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ChannelPartnerBLL()
        {
            //_dataObject = new ChannelPartnerDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Search Information
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        public static DataSet SearchInfo(string DisplayName, string MobileNo, string Email, string CompanyName, string Name, Guid? CompanyID, Guid? CreatedBy, string Location)
        {
            ChannelPartnerDAL _Obj = new ChannelPartnerDAL();
            return _Obj.SearchInfo(DisplayName, MobileNo, Email, CompanyName, Name, CompanyID, CreatedBy, Location);
        }


        public static DataSet SelectAllForUserStatus(string FName, string MobileNo, string Email, string CompanyName, string Name, Guid? CompanyID, Guid? CreatedBy, string Location, string Status)
        {
            ChannelPartnerDAL _Obj = new ChannelPartnerDAL();
            return _Obj.SelectAllForUserStatus(FName, MobileNo, Email, CompanyName, Name, CompanyID, CreatedBy, Location, Status);
        }

        /// <summary>
        ///  Report Channel Partner List
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="MobileNo"></param>
        /// <param name="Email"></param>
        /// <param name="CompanyName"></param>
        /// <param name="Country"></param>
        /// <param name="State"></param>
        /// <param name="City"></param>
        /// <returns></returns>
        public static DataSet GetRptChannelPartnerList(string FName, string MobileNo, string Email, string CompanyName, string Country, string State, string City, Guid? CreatedBy)
        {
            ChannelPartnerDAL _Obj = new ChannelPartnerDAL();
            return _Obj.rptChannelPartnerList(FName, MobileNo, Email, CompanyName, Country, State, City, CreatedBy);
        }
        /// <summary>
        /// Insert new ChannelPartner
        /// </summary>
        /// <param name="businessObject">ChannelPartner object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ChannelPartner businessObject)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ChannelPartnerID = Guid.NewGuid();

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
        public static bool Save(ChannelPartner businessObject, Address InvPAdd)
        {
            bool flag = false;
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            AddressDAL _objPAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ChannelPartnerDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ChannelPartnerID = Guid.NewGuid();

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

        public static bool SaveWithUserID(ChannelPartner businessObject, Address InvPAdd, User objSaveUser)
        {
            bool flag = false;
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            AddressDAL _objPAddress = null;
            UserDAL _objUser = null;
            UserRoleDAL _objUserRole = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ChannelPartnerDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ChannelPartnerID = Guid.NewGuid();

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
                    if (objSaveUser != null)
                    {
                        _objUser = new UserDAL(lt.Transaction);
                        objSaveUser.UserTypeID = objSaveUser.UsearID;
                        flag = _objUser.Insert(objSaveUser);

                        _objUserRole = new UserRoleDAL(lt.Transaction);
                        UserRole objSaveUserRole = new UserRole();
                        objSaveUserRole.UserRoleID = Guid.NewGuid();
                        objSaveUserRole.UserID = objSaveUser.UsearID;
                        objSaveUserRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["ChannelPartnerRole"]);
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
        /// Update existing ChannelPartner
        /// </summary>
        /// <param name="businessObject">ChannelPartner object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ChannelPartner businessObject)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
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
        /// Insert new Investor
        /// </summary>
        /// <param name="businessObject">Investor object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ChannelPartner businessObject, Address InvPAdd)
        {
            bool flag = false;
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            AddressDAL _objPAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ChannelPartnerDAL(lt.Transaction);
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
        /// get ChannelPartner by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ChannelPartner GetByPrimaryKey(Guid keys)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all ChannelPartners
        /// </summary>
        /// <returns>list</returns>
        public static List<ChannelPartner> GetAll(ChannelPartner obj)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all ChannelPartners
        /// </summary>
        /// <returns>list</returns>
        public static List<ChannelPartner> GetAll()
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of ChannelPartner by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ChannelPartner> GetAllBy(ChannelPartner.ChannelPartnerFields fieldName, object value)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all ChannelPartners
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ChannelPartner obj)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all ChannelPartners
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of ChannelPartner by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ChannelPartner.ChannelPartnerFields fieldName, object value)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ChannelPartner obj)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete ChannelPartner by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ChannelPartner.ChannelPartnerFields fieldName, object value)
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllChannelPartnerForEmailSubscription()
        {
            ChannelPartnerDAL _dataObject = new ChannelPartnerDAL();
            return _dataObject.GetAllChannelPartnerForEmailSubscription();
        }

        public static DataSet SelectDeletePermission(Guid? UserID)
        {
            ChannelPartnerDAL _Obj = new ChannelPartnerDAL();
            return _Obj.SelectDeletePermission(UserID);
        }

        #endregion

    }
}
