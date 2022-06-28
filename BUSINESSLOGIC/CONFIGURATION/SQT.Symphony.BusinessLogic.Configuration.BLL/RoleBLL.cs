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
    public static class RoleBLL
    {

        //#region data Members

        //private static RoleDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoleBLL()
        {
            //_dataObject = new RoleDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Role
        /// </summary>
        /// <param name="businessObject">Role object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Role businessObject)
        {
            RoleDAL _dataObject = new RoleDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoleID = Guid.NewGuid();
                    
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

        public static bool Save(Role objSaveRole, List<RoleRightJoin> lstSaveRoleRightJoin)
        {
            bool flag = false;
            RoleDAL _objRole = null;
            RoleRightJoinDAL _objRoleRightJoin = null;            
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRole = new RoleDAL(lt.Transaction);

                if (objSaveRole != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveRole.RoleID = Guid.NewGuid();

                    if (!objSaveRole.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveRole.BrokenRulesList.ToString());
                    }
                    flag = _objRole.Insert(objSaveRole);
                    // }
                    if (lstSaveRoleRightJoin.Count != 0)
                    {
                        _objRoleRightJoin = new RoleRightJoinDAL(lt.Transaction);
                        foreach (RoleRightJoin item in lstSaveRoleRightJoin)
                        {
                            item.RoleRightJoinID = Guid.NewGuid();
                            item.RoleID = objSaveRole.RoleID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoleRightJoin.Insert(item);
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
        /// Update existing Role
        /// </summary>
        /// <param name="businessObject">Role object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Role businessObject)
        {
            RoleDAL _dataObject = new RoleDAL();
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

        public static bool Update(Role objUpdateRole, List<RoleRightJoin> lstUpdateRoleRightJoin)
        {
            bool flag = false;
            RoleDAL _objRole = null;
            RoleRightJoinDAL _objRoleRightJoin = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRole = new RoleDAL(lt.Transaction);

                if (objUpdateRole != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!objUpdateRole.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateRole.BrokenRulesList.ToString());
                    }
                    flag = _objRole.Update(objUpdateRole);
                    // }

                    _objRoleRightJoin = new RoleRightJoinDAL(lt.Transaction);
                    _objRoleRightJoin.DeleteByRoleID(objUpdateRole.RoleID);

                    if (lstUpdateRoleRightJoin.Count != 0)
                    {   
                        foreach (RoleRightJoin item in lstUpdateRoleRightJoin)
                        {
                            item.RoleRightJoinID = Guid.NewGuid();
                            item.RoleID = objUpdateRole.RoleID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoleRightJoin.Insert(item);
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
        /// get Role by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Role GetByPrimaryKey(Guid keys)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Roles
        /// </summary>
        /// <returns>list</returns>
        public static List<Role> GetAll(Role obj)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Roles
        /// </summary>
        /// <returns>list</returns>
        public static List<Role> GetAll()
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Role by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Role> GetAllBy(Role.RoleFields fieldName, object value)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Roles
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Role obj)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Roles
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Role by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Role.RoleFields fieldName, object value)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Role obj)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Role by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Role.RoleFields fieldName, object value)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchRoleData(Guid? RoleID, Guid? CompanyID, Guid? PropertyID, string RoleName)
        {
            RoleDAL _dataObject = new RoleDAL();
            DataSet ds = _dataObject.SearchRoleData(RoleID, CompanyID, PropertyID, RoleName);
            return ds;
        }

        public static DataSet SelectData(Guid? CompanyID)
        {
            RoleDAL _dataObject = new RoleDAL();
            DataSet ds = _dataObject.SelectData(CompanyID);
            return ds;
        }

        public static DataSet GetRole(string RoleNameQuery)
        {
            RoleDAL _dataObject = new RoleDAL();
            return _dataObject.SelectRole(RoleNameQuery);
        }

        public static DataSet GetUserRole(Guid? UserID, Guid? CompanyID, Guid? PropertyID, string RoleName)
        {
            RoleDAL _dataObject = new RoleDAL();
            DataSet ds = _dataObject.SelectUserRole(UserID, CompanyID, PropertyID, RoleName);
            return ds;
        }
        #endregion

    }
}
