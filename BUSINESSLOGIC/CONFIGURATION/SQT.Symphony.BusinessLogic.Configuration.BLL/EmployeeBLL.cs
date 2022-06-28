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
    public static class EmployeeBLL
    {

        //#region data Members

        //private static EmployeeDAL _dataObject = null;

        //#endregion

        #region Constructor

        static EmployeeBLL()
        {
            //_dataObject = new EmployeeDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Employee
        /// </summary>
        /// <param name="businessObject">Employee object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Employee businessObject)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.EmployeeID = Guid.NewGuid();

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
        /// Update existing Employee
        /// </summary>
        /// <param name="businessObject">Employee object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Employee businessObject)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
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
        /// get Employee by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Employee GetByPrimaryKey(Guid keys)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Employees
        /// </summary>
        /// <returns>list</returns>
        public static List<Employee> GetAll(Employee obj)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Employees
        /// </summary>
        /// <returns>list</returns>
        public static List<Employee> GetAll()
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Employee by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Employee> GetAllBy(Employee.EmployeeFields fieldName, object value)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Employees
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Employee obj)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Employees
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Employee by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Employee.EmployeeFields fieldName, object value)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Employee obj)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Employee by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Employee.EmployeeFields fieldName, object value)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// Insert new Investor
        /// </summary>
        /// <param name="businessObject">Employee object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Employee businessObject, Address EmpPAdd, Address EmpCAdd, User objUser)
        {
            bool flag = false;
            EmployeeDAL _dataObject = new EmployeeDAL();
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            UserDAL _objUser = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new EmployeeDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.EmployeeID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(businessObject);
                    // }
                    if (EmpPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        EmpPAdd.AddressID = Guid.NewGuid();
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpPAdd.BrokenRulesList.ToString());
                        }
                        flag = _objPAddress.Insert(EmpPAdd);
                        businessObject.PAddressID = EmpPAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (EmpCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        EmpCAdd.AddressID = Guid.NewGuid();
                        if (!EmpCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpCAdd.BrokenRulesList.ToString());
                        }
                        flag = _objCAddress.Insert(EmpCAdd);
                        businessObject.CAddressID = EmpCAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (objUser != null)
                    {
                        _objUser = new UserDAL(lt.Transaction);
                        objUser.UsearID = Guid.NewGuid();
                        objUser.UserTypeID = businessObject.EmployeeID;
                        objUser.UserType = "Employee";
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objUser.BrokenRulesList.ToString());
                        }
                        flag = _objUser.Insert(objUser);
                        businessObject.UserID = objUser.UsearID;
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

        public static bool SaveWithUserID(Employee businessObject, Address EmpPAdd, Address EmpCAdd, User objUser)
        {
            bool flag = false;
            EmployeeDAL _dataObject = new EmployeeDAL();
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            UserDAL _objUser = null;
            UserRoleDAL _objUserRole = null;

            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new EmployeeDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.EmployeeID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(businessObject);
                    // }
                    if (EmpPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        EmpPAdd.AddressID = Guid.NewGuid();
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpPAdd.BrokenRulesList.ToString());
                        }
                        flag = _objPAddress.Insert(EmpPAdd);
                        businessObject.PAddressID = EmpPAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (EmpCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        EmpCAdd.AddressID = Guid.NewGuid();
                        if (!EmpCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpCAdd.BrokenRulesList.ToString());
                        }
                        flag = _objCAddress.Insert(EmpCAdd);
                        businessObject.CAddressID = EmpCAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (objUser != null)
                    {
                        if (!businessObject.Email.Equals(""))
                        {
                            _objUser = new UserDAL(lt.Transaction);
                            objUser.UserTypeID = objUser.UsearID;
                            objUser.UserType = "Admin";
                            if (!EmpPAdd.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objUser.BrokenRulesList.ToString());
                            }
                            flag = _objUser.Insert(objUser);

                            _objUserRole = new UserRoleDAL(lt.Transaction);
                            UserRole objSaveUserRole = new UserRole();
                            objSaveUserRole.UserRoleID = Guid.NewGuid();
                            objSaveUserRole.UserID = objUser.UsearID;
                            objSaveUserRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["AdminRole"].ToString());
                            objSaveUserRole.AssignedBy = objUser.CreatedBy;
                            objSaveUserRole.AssignedOn = DateTime.Now;
                            objSaveUserRole.IsSynch = false;
                            objSaveUserRole.SynchOn = DateTime.Now;
                            flag = _objUserRole.Insert(objSaveUserRole);
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
        public static bool SaveWithUserID(Employee businessObject, Address EmpPAdd, Address EmpCAdd, User objUser, Guid? RoleID)
        {
            bool flag = false;
            EmployeeDAL _dataObject = new EmployeeDAL();
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            UserDAL _objUser = null;
            UserRoleDAL _objUserRole = null;

            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new EmployeeDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.EmployeeID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(businessObject);
                    // }
                    if (EmpPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        EmpPAdd.AddressID = Guid.NewGuid();
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpPAdd.BrokenRulesList.ToString());
                        }
                        flag = _objPAddress.Insert(EmpPAdd);
                        businessObject.PAddressID = EmpPAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (EmpCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        EmpCAdd.AddressID = Guid.NewGuid();
                        if (!EmpCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpCAdd.BrokenRulesList.ToString());
                        }
                        flag = _objCAddress.Insert(EmpCAdd);
                        businessObject.CAddressID = EmpCAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (objUser != null)
                    {
                        _objUser = new UserDAL(lt.Transaction);
                        objUser.UserTypeID = objUser.UsearID;
                        objUser.UserType = "Employee";
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objUser.BrokenRulesList.ToString());
                        }
                        flag = _objUser.Insert(objUser);

                        _objUserRole = new UserRoleDAL(lt.Transaction);
                        UserRole objSaveUserRole = new UserRole();
                        objSaveUserRole.UserRoleID = Guid.NewGuid();
                        objSaveUserRole.UserID = objUser.UsearID;
                        objSaveUserRole.RoleID = RoleID;
                        objSaveUserRole.AssignedBy = objUser.CreatedBy;
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


        public static bool SaveWithUserID(Employee businessObject, Address EmpPAdd, Address EmpCAdd, User objUser, SalesTeam SlTeam, Guid? RoleID,bool IsSales)
        {
            bool flag = false;
            EmployeeDAL _dataObject = new EmployeeDAL();
            SalesTeamDAL _SlDalObject = null;
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            UserDAL _objUser = null;
            UserRoleDAL _objUserRole = null;

            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new EmployeeDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.EmployeeID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(businessObject);
                    // }
                    if (EmpPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        EmpPAdd.AddressID = Guid.NewGuid();
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpPAdd.BrokenRulesList.ToString());
                        }
                        flag = _objPAddress.Insert(EmpPAdd);
                        businessObject.PAddressID = EmpPAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (EmpCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        EmpCAdd.AddressID = Guid.NewGuid();
                        if (!EmpCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpCAdd.BrokenRulesList.ToString());
                        }
                        flag = _objCAddress.Insert(EmpCAdd);
                        businessObject.CAddressID = EmpCAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (SlTeam != null)
                    {
                        _SlDalObject = new SalesTeamDAL();
                        SlTeam.UserID = objUser.UsearID; 
                        SlTeam.SalesTeamID = Guid.NewGuid();
                        SlTeam.AddressID = EmpPAdd.AddressID;
                        if (!SlTeam.IsValid)
                        {
                            throw new InvalidBusinessObjectException(SlTeam.BrokenRulesList.ToString());
                        }
                        flag = _SlDalObject.Insert(SlTeam);
                    }
                    
                    if (objUser != null)
                    {
                        _objUser = new UserDAL(lt.Transaction);
                        objUser.UserTypeID = objUser.UsearID;
                        if (IsSales)
                            objUser.UserType = "Sales";
                        else objUser.UserType = "Employee";
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objUser.BrokenRulesList.ToString());
                        }
                        flag = _objUser.Insert(objUser);

                        _objUserRole = new UserRoleDAL(lt.Transaction);
                        UserRole objSaveUserRole = new UserRole();
                        objSaveUserRole.UserRoleID = Guid.NewGuid();
                        objSaveUserRole.UserID = objUser.UsearID;
                        objSaveUserRole.RoleID = RoleID;
                        objSaveUserRole.AssignedBy = objUser.CreatedBy;
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
        /// Insert new Employee
        /// </summary>
        /// <param name="businessObject">Employee object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Employee businessObject, Address EmpPAdd, Address EmpCAdd)
        {
            bool flag = false;
            EmployeeDAL _dataObject = new EmployeeDAL();
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new EmployeeDAL(lt.Transaction);
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
                    if (EmpPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpPAdd.BrokenRulesList.ToString());
                        }
                        if (EmpPAdd.AddressID == Guid.Empty)
                        {
                            EmpPAdd.AddressID = Guid.NewGuid();
                            EmpPAdd.CompanyID = businessObject.CompanyID;
                            flag = _objPAddress.Insert(EmpPAdd);
                            businessObject.PAddressID = EmpPAdd.AddressID;
                            _dataObject.Update(businessObject);
                        }
                        else
                            flag = _objPAddress.Update(EmpPAdd);
                    }
                    if (EmpCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        if (!EmpCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpCAdd.BrokenRulesList.ToString());
                        }
                        if (EmpCAdd.AddressID == Guid.Empty)
                        {
                            EmpCAdd.AddressID = Guid.NewGuid();
                            EmpCAdd.CompanyID = businessObject.CompanyID;
                            flag = _objCAddress.Insert(EmpCAdd);
                            businessObject.CAddressID = EmpCAdd.AddressID;
                            flag = _dataObject.Update(businessObject);
                        }
                        else
                            flag = _objCAddress.Update(EmpCAdd);
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
        /// Insert new Employee
        /// </summary>
        /// <param name="businessObject">Employee object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Employee businessObject, Address EmpPAdd, Address EmpCAdd, SalesTeam SlsTeam)
        {
            bool flag = false;
            EmployeeDAL _dataObject = new EmployeeDAL();
            SalesTeamDAL _objSalesTeam = null;

            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new EmployeeDAL(lt.Transaction);
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
                    if (EmpPAdd != null)
                    {
                        _objPAddress = new AddressDAL(lt.Transaction);
                        if (!EmpPAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpPAdd.BrokenRulesList.ToString());
                        }
                        if (EmpPAdd.AddressID == Guid.Empty)
                        {
                            EmpPAdd.AddressID = Guid.NewGuid();
                            EmpPAdd.CompanyID = businessObject.CompanyID;
                            flag = _objPAddress.Insert(EmpPAdd);
                            businessObject.PAddressID = EmpPAdd.AddressID;
                            _dataObject.Update(businessObject);
                        }
                        else
                            flag = _objPAddress.Update(EmpPAdd);
                    }
                    if (EmpCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        if (!EmpCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(EmpCAdd.BrokenRulesList.ToString());
                        }
                        if (EmpCAdd.AddressID == Guid.Empty)
                        {
                            EmpCAdd.AddressID = Guid.NewGuid();
                            EmpCAdd.CompanyID = businessObject.CompanyID;
                            flag = _objCAddress.Insert(EmpCAdd);
                            businessObject.CAddressID = EmpCAdd.AddressID;
                            flag = _dataObject.Update(businessObject);
                        }
                        else
                            flag = _objCAddress.Update(EmpCAdd);
                    }
                    if (SlsTeam != null)
                    {
                        _objSalesTeam = new SalesTeamDAL();
                        SlsTeam.SalesTeamID = Guid.NewGuid();
                        SlsTeam.AddressID = EmpPAdd.AddressID;
                        if (!SlsTeam.IsValid)
                        {
                            throw new InvalidBusinessObjectException(SlsTeam.BrokenRulesList.ToString());
                        }
                        flag = _objSalesTeam.Insert(SlsTeam);
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
        public static DataSet GetAllSearch(Guid? EmployeeID, Guid? PropertyID, Guid? CompanyID, Guid? DepartmentID, string EmployeeNo, string FullName, string CityName)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectAllSearch(EmployeeID, PropertyID, CompanyID, DepartmentID, EmployeeNo, FullName, CityName);
        }

        public static DataSet SelectEmployeeForUser(Guid? PropertyID, Guid? CompanyID)
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectEmployeeForUser(PropertyID, CompanyID);
        }

        /// <summary>
        /// get list of Employee by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>        

        public static DataSet GetAllEmployeeForEmailSubscription()
        {
            EmployeeDAL _dataObject = new EmployeeDAL();
            return _dataObject.SelectAllEmployeeForEmailSubscription();
        }
        #endregion

    }
}
