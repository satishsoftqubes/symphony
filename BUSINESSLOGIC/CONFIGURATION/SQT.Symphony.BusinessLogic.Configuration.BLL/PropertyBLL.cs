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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.DAL;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class PropertyBLL
    {

        //#region data Members

        //private static PropertyDAL _dataObject = null;

        //#endregion

        #region Constructor

        static PropertyBLL()
        {
            //_dataObject = new PropertyDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Property
        /// </summary>
        /// <param name="businessObject">Property object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Property businessObject)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.PropertyID = Guid.NewGuid();
                    
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

        public static bool Save(Property objSaveProperty, Address objSaveAddress, List<Documents> lstSaveDocuments, List<Documents> lstLandIssueModificationDocuments)
        {
            bool flag = false;
            PropertyDAL _objProperty = null;
            AddressDAL _objAddress = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objProperty = new PropertyDAL(lt.Transaction);

                if (objSaveProperty != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveProperty.PropertyID = Guid.NewGuid();

                    if (!objSaveProperty.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveProperty.BrokenRulesList.ToString());
                    }
                    flag = _objProperty.Insert(objSaveProperty);
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
                        objSaveProperty.AddressID = objSaveAddress.AddressID;
                        flag = _objProperty.Update(objSaveProperty);
                    }

                    if (lstSaveDocuments != null && lstSaveDocuments.Count != 0)
                    {
                        _objDocuments = new DocumentsDAL(lt.Transaction);
                        foreach (Documents item in lstSaveDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.PropertyID = objSaveProperty.PropertyID;
                            item.AssociationID = objSaveProperty.PropertyID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objDocuments.Insert(item);
                        }
                    }

                    if (lstLandIssueModificationDocuments != null && lstLandIssueModificationDocuments.Count != 0)
                    {
                        foreach (Documents item in lstLandIssueModificationDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.PropertyID = objSaveProperty.PropertyID;
                            item.AssociationID = objSaveProperty.PropertyID;
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

        public static bool SaveWithID(Property objSaveProperty, Address objSaveAddress, List<Documents> lstSaveDocuments)
        {
            bool flag = false;
            PropertyDAL _objProperty = null;
            AddressDAL _objAddress = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objProperty = new PropertyDAL(lt.Transaction);

                if (objSaveProperty != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    
                    if (!objSaveProperty.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveProperty.BrokenRulesList.ToString());
                    }
                    flag = _objProperty.Insert(objSaveProperty);
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
                        objSaveProperty.AddressID = objSaveAddress.AddressID;
                        flag = _objProperty.Update(objSaveProperty);
                    }

                    if (lstSaveDocuments != null && lstSaveDocuments.Count != 0)
                    {
                        _objDocuments = new DocumentsDAL(lt.Transaction);
                        foreach (Documents item in lstSaveDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.PropertyID = objSaveProperty.PropertyID;
                            item.AssociationID = objSaveProperty.PropertyID;
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
        /// Update existing Property
        /// </summary>
        /// <param name="businessObject">Property object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Property businessObject)
        {
            PropertyDAL _dataObject = new PropertyDAL();
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

        public static bool Update(Property objUpdateProperty, Address objUpdateAddress, List<Documents> lstUpdateDocuments, List<Documents> lstLandIssueModificationDocuments)
        {
            bool flag = false;
            PropertyDAL _objProperty = null;
            AddressDAL _objAddress = null;
            DocumentsDAL _objDocuments = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objProperty = new PropertyDAL(lt.Transaction);

                if (objUpdateProperty != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!objUpdateProperty.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateProperty.BrokenRulesList.ToString());
                    }
                    flag = _objProperty.Update(objUpdateProperty);
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
                            objUpdateAddress.CompanyID = objUpdateProperty.CompanyID;
                            flag = _objAddress.Insert(objUpdateAddress);
                            objUpdateProperty.AddressID = objUpdateAddress.AddressID;
                            _objProperty.Update(objUpdateProperty);
                        }
                        else                            
                            flag = _objAddress.Update(objUpdateAddress);
                    }

                    _objDocuments = new DocumentsDAL(lt.Transaction);
                    _objDocuments.DeleteByAssociationID(objUpdateProperty.PropertyID);

                    if (lstUpdateDocuments != null && lstUpdateDocuments.Count != 0)
                    {
                        foreach (Documents item in lstUpdateDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.PropertyID = objUpdateProperty.PropertyID;
                            item.AssociationID = objUpdateProperty.PropertyID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objDocuments.Insert(item);
                        }
                    }
                    if (lstLandIssueModificationDocuments != null && lstLandIssueModificationDocuments.Count != 0)
                    {
                        foreach (Documents item in lstLandIssueModificationDocuments)
                        {
                            item.DocumentID = Guid.NewGuid();
                            item.PropertyID = objUpdateProperty.PropertyID;
                            item.AssociationID = objUpdateProperty.PropertyID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objDocuments.InsertLandDocument(item);
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
        /// get Property by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Property GetByPrimaryKey(Guid keys)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Propertys
        /// </summary>
        /// <returns>list</returns>
        public static List<Property> GetAll(Property obj)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Propertys
        /// </summary>
        /// <returns>list</returns>
        public static List<Property> GetAll()
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Property by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Property> GetAllBy(Property.PropertyFields fieldName, object value)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Propertys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Property obj)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }

        public static DataSet GetAllDataByPrimaryKey(Guid propertyID)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectAllDataByPrimaryKey(propertyID);
        }

        /// <summary>
        /// get list of all Propertys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Property by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Property.PropertyFields fieldName, object value)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Property obj)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Property by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Property.PropertyFields fieldName, object value)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetPropertyData(Guid? PropertyID, Guid? CompanyID, string PropertyName, string location, Guid? propertyType)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            DataSet ds = _dataObject.SelectPropertyData(PropertyID, CompanyID, PropertyName, location, propertyType);
            return ds;
        }

        public static DataSet GetPropertyUnitView(Guid PropertyID)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            DataSet ds = _dataObject.SelectPropertyUnitView(PropertyID);
            return ds;
        }

        public static DataSet GetPropertyRoomTypeView(Guid PropertyID)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            DataSet ds = _dataObject.SelectPropertyRoomTypeView(PropertyID);
            return ds;
        }

        public static DataSet GetPropertyBlockUnitView(Guid PropertyID,Guid WingID)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            DataSet ds = _dataObject.SelectPropertyBlockUnitView(PropertyID, WingID);
            return ds;
        }

        public static DataSet SelectData(Guid? CompanyID)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            DataSet ds = _dataObject.SelectData(CompanyID);
            return ds;
        }

        public static DataSet GetIndexDashBoard(Guid CompanyID, Guid? UserID)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            return _dataObject.SelectIndexDashBoard(CompanyID, UserID);
        }

        public static DataSet GetPropertyAddressInfo(Guid? PropertyID, Guid? CompanyID)
        {
            PropertyDAL _dataObject = new PropertyDAL();
            DataSet ds = _dataObject.SelectPropertyAddressInfo(PropertyID,CompanyID);
            return ds;
        }
        #endregion

    }
}
