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
    public static class UserBLL
    {

        //#region data Members

        //private static UserDAL _dataObject = null;

        //#endregion

        #region Constructor

        static UserBLL()
        {
            //_dataObject = new UserDAL();
        }

        #endregion

        #region Public Methods
       
        /// <summary>
        /// User Credentails
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static DataSet UserCredential(string UserName, string Password)
        {
            UserDAL _Obj = new UserDAL();
            return _Obj.UserCredential(UserName, Password);
        }
        /// <summary>
        /// Insert new User
        /// </summary>
        /// <param name="businessObject">User object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(User businessObject)
        {
            UserDAL _dataObject = new UserDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.UsearID = Guid.NewGuid();
                        businessObject.UserTypeID = businessObject.UsearID;
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

        public static bool Save(User objSaveUser, List<UserRole> lstSaveUserRole)
        {
            bool flag = false;
            UserDAL _objUser = null;
            UserRoleDAL _objUserRole = null;            
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objUser = new UserDAL(lt.Transaction);

                if (objSaveUser != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{                    

                    if (!objSaveUser.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveUser.BrokenRulesList.ToString());
                    }
                    flag = _objUser.Insert(objSaveUser);
                    // }
                    if (lstSaveUserRole.Count != 0)
                    {
                        _objUserRole = new UserRoleDAL(lt.Transaction);
                        foreach (UserRole item in lstSaveUserRole)
                        {
                            item.UserRoleID = Guid.NewGuid();
                            item.UserID = objSaveUser.UsearID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objUserRole.Insert(item);
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
        /// Update existing User
        /// </summary>
        /// <param name="businessObject">User object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(User businessObject)
        {
            UserDAL _dataObject = new UserDAL();
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

        public static bool Update(User objUpdateUser, List<UserRole> lstUpdateUserRole)
        {
            bool flag = false;
            UserDAL _objUser = null;
            UserRoleDAL _objUserRole = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objUser = new UserDAL(lt.Transaction);

                if (objUpdateUser != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!objUpdateUser.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateUser.BrokenRulesList.ToString());
                    }
                    flag = _objUser.Update(objUpdateUser);
                    // }

                    _objUserRole = new UserRoleDAL(lt.Transaction);
                    _objUserRole.DeleteByUserID(objUpdateUser.UsearID);

                    if (lstUpdateUserRole.Count != 0)
                    {
                        foreach (UserRole item in lstUpdateUserRole)
                        {
                            item.UserRoleID = Guid.NewGuid();
                            item.UserID = objUpdateUser.UsearID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objUserRole.Insert(item);
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
        /// get User by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static User GetByPrimaryKey(Guid keys)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Users
        /// </summary>
        /// <returns>list</returns>
        public static List<User> GetAll(User obj)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Users
        /// </summary>
        /// <returns>list</returns>
        public static List<User> GetAll()
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of User by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<User> GetAllBy(User.UserFields fieldName, object value)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Users
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(User obj)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Users
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of User by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(User.UserFields fieldName, object value)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(User obj)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete User by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(User.UserFields fieldName, object value)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchData(Guid? UsearID, Guid? PropertyID, Guid? CompanyID, string UserName, Guid? DepartmentID)
        {
            UserDAL _dataObject = new UserDAL();
            DataSet ds = _dataObject.SearchData(UsearID, PropertyID, CompanyID, UserName, DepartmentID);
            return ds;
        }

        public static DataSet GetUserName(string UserNameQuery)
        {
            UserDAL _dataObject = new UserDAL();
            return _dataObject.SelectUserName(UserNameQuery);
        }

        public static bool SaveWithEmployeeID(User objSaveUser, List<UserRole> lstSaveUserRole, Employee objUpdateEmployee)
        {
            bool flag = false;
            UserDAL _objUser = null;
            UserRoleDAL _objUserRole = null;
            EmployeeDAL _objEmployee = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objUser = new UserDAL(lt.Transaction);

                if (objSaveUser != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{                    

                    if (!objSaveUser.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveUser.BrokenRulesList.ToString());
                    }
                    flag = _objUser.Insert(objSaveUser);
                    // }
                    if (lstSaveUserRole.Count != 0)
                    {
                        _objUserRole = new UserRoleDAL(lt.Transaction);
                        foreach (UserRole item in lstSaveUserRole)
                        {
                            item.UserRoleID = Guid.NewGuid();
                            item.UserID = objSaveUser.UsearID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objUserRole.Insert(item);
                        }
                    }

                    if (objUpdateEmployee != null)
                    {
                        _objEmployee = new EmployeeDAL(lt.Transaction);
                        objUpdateEmployee.UserID = objSaveUser.UsearID;
                        flag = _objEmployee.Update(objUpdateEmployee);
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

        public static DataSet UserAuthentication(string userName, string password)
        {
            UserDAL _Obj = new UserDAL();
            return _Obj.UserAuthentication(userName, password);
        }

        public static DataSet GetUserAuthorization(Guid userID, string formName)
        {
            UserDAL _Obj = new UserDAL();
            return _Obj.GetUserAuthorization(userID, formName);
        }

        public static DataSet GetUserAllAuthorization(Guid userID, string RoleType, Guid? PropertyID, Guid? CompanyID)
        {
            UserDAL _Obj = new UserDAL();
            return _Obj.GetUserAllAuthorization(userID, RoleType, PropertyID, CompanyID);
        }

        public static DataSet UserGetAllByRoleTypeHierarchy(string userRoleType, Guid companyID, Guid propertyID)
        {
            UserDAL _Obj = new UserDAL();
            return _Obj.UserGetAllByRoleTypeHierarchy(userRoleType,companyID,propertyID);
        }

        public static DataSet UserSelectModule(Guid? UserID, Guid? PropertyID, Guid? CompanyID)
        {
            UserDAL _Obj = new UserDAL();
            return _Obj.UserSelectModule(UserID, PropertyID, CompanyID);
        }

        #endregion

    }
}
