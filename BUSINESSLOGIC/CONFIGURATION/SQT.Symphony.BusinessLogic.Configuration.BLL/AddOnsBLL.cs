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
    public static class AddOnsBLL
    {

        //#region data Members

        //private static AddOnsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static AddOnsBLL()
        {
            //_dataObject = new AddOnsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new AddOns
        /// </summary>
        /// <param name="businessObject">AddOns object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(AddOns businessObject)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AddOnID = Guid.NewGuid();
                    
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

        public static bool Save(AddOns businessObject, List<AddOnItems> lstAddOnItems)
        {
            bool flag = false;
            LinqTransaction lt = LinqSql.CreateTransaction("SQLConStr");
            
            try
            {
                AddOnsDAL _dataObject = new AddOnsDAL(lt.Transaction);
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AddOnID = Guid.NewGuid();

                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        
                        flag = _dataObject.Insert(businessObject);

                        if (lstAddOnItems != null && lstAddOnItems.Count > 0)
                        {
                            AddOnItemsDAL objAddOnItemDal = new AddOnItemsDAL(lt.Transaction);

                            foreach (AddOnItems addOnItem in lstAddOnItems)
                            {
                                addOnItem.AddOnItemID = Guid.NewGuid();
                                addOnItem.AddOnID = businessObject.AddOnID;

                                if (!addOnItem.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(addOnItem.BrokenRulesList.ToString());
                                }

                                flag = objAddOnItemDal.Insert(addOnItem);
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
                            return flag;
                        }
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
        /// Update existing AddOns
        /// </summary>
        /// <param name="businessObject">AddOns object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(AddOns businessObject)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
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

        public static bool Update(AddOns businessObject, List<AddOnItems> lstAddOnItems, List<AddOnItems> lstAddOnItemsFromDB, Guid UpdatedBy)
        {
            bool flag = false;
            LinqTransaction lt = LinqSql.CreateTransaction("SQLConStr");

            try
            {
                AddOnsDAL _dataObject = new AddOnsDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }

                        flag = _dataObject.Update(businessObject);

                        ////If lstRateTaxes contains record....
                        if (lstAddOnItems != null && lstAddOnItems.Count > 0)
                        {
                            AddOnItemsDAL objAddOnItemsDal = new AddOnItemsDAL(lt.Transaction);

                            ////If any RateTaxes exist in DB
                            if (lstAddOnItemsFromDB != null && lstAddOnItemsFromDB.Count > 0)
                            {
                                ////Check all records from DB one by one, if match with lstRateTaxes, then update it, o/w delete from DB.
                                for (int i = 0; i < lstAddOnItemsFromDB.Count; i++)
                                {
                                    bool blIsProcessed = false;
                                    ////To check if individual record from DB exist in lstRateTaxes or not,
                                    for (int j = 0; j < lstAddOnItems.Count; j++)
                                    {
                                        ////If match found,
                                        if (lstAddOnItemsFromDB[i].ItemID == lstAddOnItems[j].ItemID)
                                        {
                                            //// Nothing to do in this case, only remove from lstRateTaxes to avoid to new insert after for loop of j
                                            lstAddOnItemsFromDB[i].Qty = lstAddOnItems[j].Qty;
                                            lstAddOnItemsFromDB[i].UpdatedBy = UpdatedBy;
                                            lstAddOnItemsFromDB[i].UpdatedOn = DateTime.Now;
                                            objAddOnItemsDal.Update(lstAddOnItemsFromDB[i]);

                                            lstAddOnItems.RemoveAt(j);
                                            j--;
                                            blIsProcessed = true;
                                            break;
                                        }
                                    }

                                    ////After checking all record of lstRateTaxes, if blIsProcessed is remain false, that means to delete from DB.
                                    if (!blIsProcessed)
                                    {
                                        ////Delete From DB.
                                        flag = objAddOnItemsDal.Delete(lstAddOnItemsFromDB[i].AddOnItemID);
                                    }
                                }
                            }

                            ////After processign lstTaxesFromDB, lstRateTaxes contains only those records which are new to insert in DB
                            foreach (AddOnItems addOnItem in lstAddOnItems)
                            {
                                ////Insert new Record in DB.
                                addOnItem.AddOnItemID = Guid.NewGuid();
                                addOnItem.AddOnID = businessObject.AddOnID;

                                if (!addOnItem.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(addOnItem.BrokenRulesList.ToString());
                                }

                                flag = objAddOnItemsDal.Insert(addOnItem);
                            }
                        }
                        else
                        {
                            ////lstRateTaxes not contain any record, so Delete all RateTaxes from DB by RateID.
                            AddOnItemsDAL objAddOnItemsDal = new AddOnItemsDAL(lt.Transaction);
                            flag = objAddOnItemsDal.DeleteByField(AddOnItems.AddOnItemsFields.AddOnID.ToString(), businessObject.AddOnID.ToString());
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
        /// get AddOns by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static AddOns GetByPrimaryKey(Guid keys)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all AddOnss
        /// </summary>
        /// <returns>list</returns>
        public static List<AddOns> GetAll(AddOns obj)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all AddOnss
        /// </summary>
        /// <returns>list</returns>
        public static List<AddOns> GetAll()
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of AddOns by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<AddOns> GetAllBy(AddOns.AddOnsFields fieldName, object value)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all AddOnss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(AddOns obj)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }

        public static DataSet GetAllWithDataSetForSearch(AddOns obj)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectAllWithDataSetForSearch(obj);
        }

        /// <summary>
        /// get list of all AddOnss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of AddOns by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(AddOns.AddOnsFields fieldName, object value)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(AddOns obj)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete AddOns by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(AddOns.AddOnsFields fieldName, object value)
        {
            AddOnsDAL _dataObject = new AddOnsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
