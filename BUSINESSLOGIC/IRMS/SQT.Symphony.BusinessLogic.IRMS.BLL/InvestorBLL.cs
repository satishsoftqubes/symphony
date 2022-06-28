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
    public static class InvestorBLL
    {

        //#region data Members

        //private static InvestorDAL _dataObject = null;

        //#endregion

        #region Constructor

        static InvestorBLL()
        {
            //_dataObject = new InvestorDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Search Information
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="MobileNo"></param>
        /// <param name="Email"></param>
        /// <param name="BankName"></param>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataSet SearchInfo(string FName, string MobileNo, string Email, string InvestorName, string CompanyName, Guid? CompanyID, Guid? RelationShipManagerID, string Location)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.SearchInfo(FName, MobileNo, Email, InvestorName, CompanyName, CompanyID, RelationShipManagerID, Location);
        }

        public static DataSet NewSearchInfo(string investorName, string location, string firmName, string executiveName, Guid? companyID, string Alphabet)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.NewSearchInfo(investorName, location, firmName, executiveName, companyID, Alphabet);
        }

        //public static DataSet GetAllInvestors(string investorName, Guid? companyID)
        //{
        //    InvestorDAL _Obj = new InvestorDAL();
        //    return _Obj.GetAllInvestors(investorName, companyID);
        //}
        /// <summary>
        /// Report Investors List
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="MobileNo"></param>
        /// <param name="Email"></param>
        /// <param name="OccupationID"></param>
        /// <param name="Country"></param>
        /// <param name="State"></param>
        /// <param name="City"></param>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public static DataSet GetRptInvestorList(string FName, string MobileNo, string Email, Guid? OccupationID, string Country, string State, string City, string CompanyName, Guid? RelationShipManagerID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.rptInvestorList(FName, MobileNo, Email, OccupationID, Country, State, City, CompanyName, RelationShipManagerID);
        }
        /// <summary>
        /// Get Investor Payment List
        /// </summary>
        /// <param name="InvestorID"></param>
        /// <returns></returns>
        public static DataSet GetPaymentList(Guid? InvestorID, Guid? InvestorRoomID, string PropertyName, string RoomNo)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.InvestorGetPaymentList(InvestorID, InvestorRoomID, PropertyName, RoomNo);
        }
        /// <summary>
        /// Get Investor Payment Schedule Detail
        /// </summary>
        /// <param name="InvestorID"></param>
        /// <returns></returns>
        public static DataSet GetPaymentScheduleDetail(Guid? InvestorRoomID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.InvestorGetPaymentScheduleDetail(InvestorRoomID);
        }
        /// <summary>
        /// Get Search Data Here
        /// </summary>
        /// <param name="DisplayName"></param>
        /// <returns></returns>
        public static DataSet GetSearchData(string DisplayName)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.GetSearchData(DisplayName);
        }
        /// <summary>
        /// Insert new Investor
        /// </summary>
        /// <param name="businessObject">Investor object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Investor businessObject)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.InvestorID = Guid.NewGuid();

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
        public static bool Save(Investor businessObject, Address InvPAdd, Address InvCAdd)
        {
            bool flag = false;
            InvestorDAL _dataObject = new InvestorDAL();
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new InvestorDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.InvestorID = Guid.NewGuid();

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
                        businessObject.AgreementAddressID = InvPAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (InvCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        InvCAdd.AddressID = Guid.NewGuid();
                        // item.CategoryID =    
                        if (!InvCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(InvCAdd.BrokenRulesList.ToString());
                        }
                        flag = _objCAddress.Insert(InvCAdd);
                        businessObject.PostalAddressID = InvCAdd.AddressID;
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

        public static bool SaveWithUserID(Investor businessObject, Address InvPAdd, Address InvCAdd, User objSaveUser)
        {
            bool flag = false;
            InvestorDAL _dataObject = new InvestorDAL();
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            UserDAL _objUserDAL = null;
            LinqTransaction lt = null;
            UserRoleDAL _objUserRole = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new InvestorDAL(lt.Transaction);
                if (businessObject != null)
                {
                    businessObject.InvestorID = Guid.NewGuid();
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
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
                        businessObject.AgreementAddressID = InvPAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
                    }
                    if (InvCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        InvCAdd.AddressID = Guid.NewGuid();
                        // item.CategoryID =    
                        if (!InvCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(InvCAdd.BrokenRulesList.ToString());
                        }
                        flag = _objCAddress.Insert(InvCAdd);
                        businessObject.PostalAddressID = InvCAdd.AddressID;
                        flag = _dataObject.Update(businessObject);
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
                        objSaveUserRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["InvestorRole"]);
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
        /// Update existing Investor
        /// </summary>
        /// <param name="businessObject">Investor object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Investor businessObject)
        {
            InvestorDAL _dataObject = new InvestorDAL();
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
        public static bool Update(Investor businessObject, Address InvPAdd, Address InvCAdd)
        {
            bool flag = false;
            InvestorDAL _dataObject = new InvestorDAL();
            AddressDAL _objPAddress = null;
            AddressDAL _objCAddress = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new InvestorDAL(lt.Transaction);
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
                    if (InvCAdd != null)
                    {
                        _objCAddress = new AddressDAL(lt.Transaction);
                        // item.CategoryID =    
                        if (!InvCAdd.IsValid)
                        {
                            throw new InvalidBusinessObjectException(InvCAdd.BrokenRulesList.ToString());
                        }
                        flag = _objCAddress.Update(InvCAdd);
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
        /// get Investor by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Investor GetByPrimaryKey(Guid keys)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Investors
        /// </summary>
        /// <returns>list</returns>
        public static List<Investor> GetAll(Investor obj)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Investors
        /// </summary>
        /// <returns>list</returns>
        public static List<Investor> GetAll()
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Investor by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Investor> GetAllBy(Investor.InvestorFields fieldName, object value)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Investors
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Investor obj)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Investors
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Investor by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Investor.InvestorFields fieldName, object value)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Investor obj)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Investor by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Investor.InvestorFields fieldName, object value)
        {
            InvestorDAL _dataObject = new InvestorDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }
        public static DataSet GetAllInvestorForEmailSubscription()
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.GetAllInvestorForEmailSubscription();
        }

        public static DataSet GetRptTotalSales(Guid? PropertyID, Guid? ReferenceThrough, DateTime? StartDate, DateTime? EndDate)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.rptTotalSales(PropertyID, ReferenceThrough, StartDate, EndDate);
        }

        public static DataSet GetRptInvestorBankDetail(Guid? InvestorID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.rptInvestorBankDetail(InvestorID);
        }

        public static DataSet SelectAllInvestorsForActiveInActive(string investorName, string location, string firmName, string status, Guid? companyID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.SelectAllInvestorsForActiveInActive(investorName, location, firmName, status, companyID);
        }

        public static DataSet SelectForInvestorUpdateIndication(Guid investorID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.SelectForInvestorUpdateIndication(investorID);
        }

        public static DataSet GetCoOrdinators(string OperationType, Guid? investorID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.GetCoOrdinators(OperationType, investorID);
        }

        public static DataSet GetAllInvestorsForFrontDesk(Guid CompanyID, Guid? InvestorID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.GetAllInvestorsForFrontDesk(CompanyID, InvestorID);
        }
        public static DataSet GetInvestorEmailAddress(Guid CompanyID)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.SelectInvestorEmailAddress(CompanyID);
        }
        public static DataSet GetInvestorDetailReportData(Guid CompanyID, Guid? InvestorID, string BankName)
        {
            InvestorDAL _Obj = new InvestorDAL();
            return _Obj.SelectInvestorDetailReport(CompanyID, InvestorID, BankName);
        }
        //public static DataSet GetInvestorDetailReportWingWise(Guid CompanyID, Guid? WingID)
        //{
        //    InvestorDAL _Obj = new InvestorDAL();
        //    return _Obj.SelectInvestorDetailReportWingWise(CompanyID, WingID);
        //}
        #endregion

    }
}
