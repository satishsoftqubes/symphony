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
    public static class DocumentsBLL
    {

        //#region data Members

        //private static DocumentsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static DocumentsBLL()
        {
            //_dataObject = new DocumentsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Documents
        /// </summary>
        /// <param name="businessObject">Documents object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Documents businessObject)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.DocumentID = Guid.NewGuid();
                    
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
        /// Update existing Documents
        /// </summary>
        /// <param name="businessObject">Documents object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Documents businessObject)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
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

        /// <summary>
        /// get Documents by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Documents GetByPrimaryKey(Guid keys)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Documentss
        /// </summary>
        /// <returns>list</returns>
        public static List<Documents> GetAll(Documents obj)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Documentss
        /// </summary>
        /// <returns>list</returns>
        public static List<Documents> GetAll()
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Documents by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Documents> GetAllBy(Documents.DocumentsFields fieldName, object value)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Documentss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Documents obj)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Documentss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Documents by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Documents.DocumentsFields fieldName, object value)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Documents obj)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Documents by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Documents.DocumentsFields fieldName, object value)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchDocumentByCritearea(Guid? InvestorID, Guid? AssociationID, Guid? CompanyID)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SearchDocumentByCritearea(InvestorID, AssociationID, @CompanyID);
        }

        public static DataSet GetAllDocument(Guid? DocumentID, Guid? AssociationID, Guid? CreatedBy, Guid? CompanyID, string DocumentName, string AssociationType)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectAllDocument(DocumentID, AssociationID, CreatedBy, CompanyID, DocumentName, AssociationType);
        }

        public static DataSet GetDocumentGrid(Guid? DocumentID, Guid? CategoryID, Guid? CompanyID, string Category, Guid? AssociationID)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectDocumentGrid(DocumentID,CategoryID, CompanyID, Category, AssociationID);
        }

        public static DataSet GetDocumentByPropertyID(Guid? CompanyID, Guid? PropertyID)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectDocumentByPropertyID(CompanyID, PropertyID);
        }

        public static DataSet SelectDocumentByCriteria(string AssociationType, Guid? CreatedBy, Guid? CompanyID, DateTime? StartDate, DateTime? EndDate, string PropertyName, Guid? DocumentTypeID, string InvestorName, string RoomNo)
        {
            DocumentsDAL _dataObject = new DocumentsDAL();
            return _dataObject.SelectDocumentByCriteria(AssociationType, CreatedBy, CompanyID, StartDate,  EndDate, PropertyName,  DocumentTypeID, InvestorName, RoomNo);
        }

        #endregion

    }
}
