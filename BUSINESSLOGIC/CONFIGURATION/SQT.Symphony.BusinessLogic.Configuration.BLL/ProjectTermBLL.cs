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
    public static class ProjectTermBLL
    {

        //#region data Members

        //private static ProjectTermDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ProjectTermBLL()
        {
            //_dataObject = new ProjectTermDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ProjectTerm
        /// </summary>
        /// <param name="businessObject">ProjectTerm object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ProjectTerm businessObject)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TermID = Guid.NewGuid();

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
        /// Update existing ProjectTerm
        /// </summary>
        /// <param name="businessObject">ProjectTerm object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ProjectTerm businessObject)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
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
        /// get ProjectTerm by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ProjectTerm GetByPrimaryKey(Guid keys)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all ProjectTerms
        /// </summary>
        /// <returns>list</returns>
        public static List<ProjectTerm> GetAll(ProjectTerm obj)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectAll(obj);
        }

        public static List<ProjectTerm> SelectAllByCategory(Guid companyID, Guid propertyID, string termCategory)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectAllByCategory(companyID, propertyID, termCategory);
        }
        /// <summary>
        /// get list of all ProjectTerms
        /// </summary>
        /// <returns>list</returns>
        public static List<ProjectTerm> GetAll()
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of ProjectTerm by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ProjectTerm> GetAllBy(ProjectTerm.ProjectTermFields fieldName, object value)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all ProjectTerms
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ProjectTerm obj)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all ProjectTerms
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of ProjectTerm by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ProjectTerm.ProjectTermFields fieldName, object value)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ProjectTerm obj)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete ProjectTerm by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ProjectTerm.ProjectTermFields fieldName, object value)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetDistinctCategory(Guid? CompanyID)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectDistinctCategory(CompanyID);
            return ds;
        }
        public static DataSet GetDistinctCategory(Guid? CompanyID, Guid? PropertyID)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectDistinctCategory(CompanyID, PropertyID);
            return ds;
        }
        public static DataSet SelectData(string ProjectTermQuery)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectData(ProjectTermQuery);
            return ds;
        }
        public static bool UpdateSeqNo(Guid TermID, string UpDown)
        {
            ProjectTermDAL _Obj = new ProjectTermDAL();
            return _Obj.UpdateSeqNo(TermID, UpDown);
        }

        public static List<ProjectTerm> SelectAllByCategoryAndTerm(Guid companyID, Guid propertyID, string termCategory, string term)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            return _dataObject.SelectAllByCategoryAndTerm(companyID, propertyID, termCategory, term);
        }

        public static DataSet SelectAllResStatusByPageType(string PageType, Guid? CompanyID, Guid? PropertyID)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectAllResStatusByPageType(PageType, CompanyID, PropertyID);
            return ds;
        }

        public static DataSet SelectTitleCSWTGT(Guid? CompanyID, Guid? PropertyID, string CategoryTitle, string CategoryCompanySector, string CategoryWorkingTime, string CategoryGuestType, string CategoryIDDocument, string CategoryBloodGroup, string CategoryMealPreference, string CategoryModeofPayment)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectTitleCSWTGT(CompanyID, PropertyID, CategoryTitle, CategoryCompanySector, CategoryWorkingTime, CategoryGuestType, CategoryIDDocument, CategoryBloodGroup, CategoryMealPreference, CategoryModeofPayment);
            return ds;
        }

        public static DataSet SelectTranzactionZoneIDByTransZone(string TransactionZone, Guid? CompanyID, Guid? PropertyID)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectTranzactionZoneIDByTransZone(TransactionZone, CompanyID, PropertyID);
            return ds;
        }

        public static DataSet SelectReservationTypeTermID(string ReservationType, Guid? CompanyID, Guid? PropertyID)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectReservationTypeTermID(ReservationType, CompanyID, PropertyID);
            return ds;
        }

        public static DataSet SelectPaymentAcctIDByMOP(string ModeOfPayment, Guid? CompanyID, Guid? PropertyID)
        {
            ProjectTermDAL _dataObject = new ProjectTermDAL();
            DataSet ds = _dataObject.SelectPaymentAcctIDByMOP(ModeOfPayment, CompanyID, PropertyID);
            return ds;
        }
        #endregion

    }
}
