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
    public static class CategoryBLL
    {

        //#region data Members

        //private static CategoryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CategoryBLL()
        {
            //_dataObject = new CategoryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Category
        /// </summary>
        /// <param name="businessObject">Category object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Category businessObject)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CategoryID = Guid.NewGuid();
                    
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


        public static bool SaveWithData(Category objSaveCategory, List<CategoryPOSPoints> lstCategoryPOSPoints)
        {
            bool flag = false;
            CategoryDAL _objCategory = null;
            CategoryPOSPointsDAL _objCategoryPOSPoints = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objCategory = new CategoryDAL(lt.Transaction);

                if (objSaveCategory != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveCategory.CategoryID = Guid.NewGuid();

                    if (!objSaveCategory.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveCategory.BrokenRulesList.ToString());
                    }
                    flag = _objCategory.Insert(objSaveCategory);
                    // }

                    if (lstCategoryPOSPoints.Count != 0)
                    {
                        _objCategoryPOSPoints = new CategoryPOSPointsDAL(lt.Transaction);
                        foreach (CategoryPOSPoints item in lstCategoryPOSPoints)
                        {
                            item.CategoryPOSPointID = Guid.NewGuid();
                            item.CategoryID = objSaveCategory.CategoryID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objCategoryPOSPoints.Insert(item);
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
        /// Update existing Category
        /// </summary>
        /// <param name="businessObject">Category object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Category businessObject)
        {
            CategoryDAL _dataObject = new CategoryDAL();
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

        public static bool UpdateWithData(Category objUpdateCategory, List<CategoryPOSPoints> lstCategoryPOSPoints)
        {
            bool flag = false;
            CategoryDAL _objCategory = null;
            CategoryPOSPointsDAL _objCategoryPOSPoints = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objCategory = new CategoryDAL(lt.Transaction);

                if (objUpdateCategory != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!objUpdateCategory.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateCategory.BrokenRulesList.ToString());
                    }
                    flag = _objCategory.Update(objUpdateCategory);
                    // }

                    _objCategoryPOSPoints = new CategoryPOSPointsDAL(lt.Transaction);
                    _objCategoryPOSPoints.DeleteByField(CategoryPOSPoints.CategoryPOSPointsFields.CategoryID.ToString(), Convert.ToString(objUpdateCategory.CategoryID));
                    
                    if (lstCategoryPOSPoints.Count != 0)
                    {
                        foreach (CategoryPOSPoints item in lstCategoryPOSPoints)
                        {
                            item.CategoryPOSPointID = Guid.NewGuid();
                            item.CategoryID = objUpdateCategory.CategoryID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objCategoryPOSPoints.Insert(item);
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
        /// get Category by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Category GetByPrimaryKey(Guid keys)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Categorys
        /// </summary>
        /// <returns>list</returns>
        public static List<Category> GetAll(Category obj)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Categorys
        /// </summary>
        /// <returns>list</returns>
        public static List<Category> GetAll()
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Category by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Category> GetAllBy(Category.CategoryFields fieldName, object value)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Categorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Category obj)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Categorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Category by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Category.CategoryFields fieldName, object value)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Category obj)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Category by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Category.CategoryFields fieldName, object value)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetCategoryData(Guid? CategoryID, Guid? PropertyID, Guid? CompanyID, string CategoryCode, string CategoryName, Guid? RefCategoryID)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SelectCategoryData(CategoryID,PropertyID,CompanyID,CategoryCode,CategoryName,RefCategoryID);
        }

        public static DataSet SearchCategory(Guid? CategoryID, Guid? PropertyID, Guid? CompanyID, string CategoryCode, string CategoryName)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.SearchCategory(CategoryID, PropertyID, CompanyID, CategoryCode, CategoryName);
        }

        public static bool DeleteCategoryData(string strDeleteID)
        {
            CategoryDAL _dataObject = new CategoryDAL();
            return _dataObject.DeleteCategoryData(strDeleteID);
        }

        #endregion

    }
}
