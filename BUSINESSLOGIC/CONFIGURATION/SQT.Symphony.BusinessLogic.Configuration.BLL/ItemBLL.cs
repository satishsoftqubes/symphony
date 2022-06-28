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
    public static class ItemBLL
    {

        //#region data Members

        //private static ItemDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ItemBLL()
        {
            //_dataObject = new ItemDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Item
        /// </summary>
        /// <param name="businessObject">Item object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Item businessObject)
        {
            ItemDAL _dataObject = new ItemDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ItemID = Guid.NewGuid();

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

        public static bool SaveWithData(Item businessObject, List<ItemTax> lstItemTaxes, List<ItemAvailability> lstItemAvailabilitys, List<ItemCategory> lstItemCategory)
        {
            bool flag = false;
            ItemDAL _dataObject = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ItemDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ItemID = Guid.NewGuid();

                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        flag = _dataObject.Insert(businessObject);

                        ItemTaxDAL itemTaxDal = null;
                        foreach (ItemTax objItemTax in lstItemTaxes)
                        {
                            itemTaxDal = new ItemTaxDAL(lt.Transaction);
                            objItemTax.ItemTaxID = Guid.NewGuid();
                            objItemTax.ItemID = businessObject.ItemID;

                            if (!objItemTax.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objItemTax.BrokenRulesList.ToString());
                            }
                            flag = itemTaxDal.Insert(objItemTax);
                        }

                        ItemAvailabilityDAL itemAvailabilityDal = null;
                        foreach (ItemAvailability objItemAvailability in lstItemAvailabilitys)
                        {
                            itemAvailabilityDal = new ItemAvailabilityDAL(lt.Transaction);
                            objItemAvailability.ItemAvailabilityID = Guid.NewGuid();
                            objItemAvailability.ItemID = businessObject.ItemID;

                            if (!objItemAvailability.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objItemAvailability.BrokenRulesList.ToString());
                            }
                            flag = itemAvailabilityDal.Insert(objItemAvailability);
                        }

                        ItemCategoryDAL itemcategoryDAL = null;

                        if (lstItemCategory.Count != 0)
                        {
                            foreach (ItemCategory objItemCategory in lstItemCategory)
                            {
                                itemcategoryDAL = new ItemCategoryDAL(lt.Transaction);
                                objItemCategory.ItemCategoryID = Guid.NewGuid();
                                objItemCategory.ItemID = businessObject.ItemID;

                                if (!objItemCategory.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objItemCategory.BrokenRulesList.ToString());
                                }
                                flag = itemcategoryDAL.Insert(objItemCategory);
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
        /// Update existing Item
        /// </summary>
        /// <param name="businessObject">Item object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Item businessObject)
        {
            ItemDAL _dataObject = new ItemDAL();
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

        public static bool UpdateWithData(Item businessObject, List<ItemTax> lstItemTaxes, List<ItemTax> lstItemTaxesFromDB, List<ItemAvailability> lstItemAvailabilitys, List<ItemAvailability> lstItemAvailabilitysFromDB, List<ItemCategory> lstItemCategory)
        {
            bool flag = false;
            ItemDAL _dataObject = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ItemDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        flag = _dataObject.Update(businessObject);

                        ////If lstItemTaxes contains record....
                        if (lstItemTaxes != null && lstItemTaxes.Count > 0)
                        {
                            ItemTaxDAL objItemTaxDAL = new ItemTaxDAL(lt.Transaction);

                            ////If any ItemTaxes exist in DB
                            if (lstItemTaxesFromDB != null && lstItemTaxesFromDB.Count > 0)
                            {
                                ////Check all records from DB one by one, if match with lstItemTaxes, then update it, o/w delete from DB.
                                for (int i = 0; i < lstItemTaxesFromDB.Count; i++)
                                {
                                    bool blIsProcessed = false;
                                    ////To check if individual record from DB exist in lstItemTaxes or not,
                                    for (int j = 0; j < lstItemTaxes.Count; j++)
                                    {
                                        ////If match found,
                                        if (lstItemTaxesFromDB[i].TaxID == lstItemTaxes[j].TaxID)
                                        {
                                            lstItemTaxes.RemoveAt(j);
                                            j--;
                                            blIsProcessed = true;
                                            break;
                                        }
                                    }

                                    ////After checking all record of lstItemTaxes, if blIsProcessed is remain false, that means to delete from DB.
                                    if (!blIsProcessed)
                                    {
                                        ////Delete From DB.
                                        flag = objItemTaxDAL.Delete(lstItemTaxesFromDB[i].ItemTaxID);
                                    }
                                }
                            }

                            ////After processign lstItemTaxesFromDB, lstRateTaxes contains only those records which are new to insert in DB
                            foreach (ItemTax objItemTax in lstItemTaxes)
                            {
                                objItemTaxDAL = new ItemTaxDAL(lt.Transaction);
                                objItemTax.ItemTaxID = Guid.NewGuid();
                                objItemTax.ItemID = businessObject.ItemID;

                                if (!objItemTax.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objItemTax.BrokenRulesList.ToString());
                                }
                                flag = objItemTaxDAL.Insert(objItemTax);
                            }
                        }
                        else
                        {
                            ////lstItemTaxes not contain any record, so Delete all ItemTaxes from DB by ItemID.
                            ItemTaxDAL objItemTaxDal = new ItemTaxDAL(lt.Transaction);
                            flag = objItemTaxDal.DeleteByField(ItemTax.ItemTaxFields.ItemID.ToString(), businessObject.ItemID.ToString());
                        }

                        ////If lstItemAvailabilitys contains record....
                        if (lstItemAvailabilitys != null && lstItemAvailabilitys.Count > 0)
                        {
                            ItemAvailabilityDAL objItemAvailabilityDAL = new ItemAvailabilityDAL(lt.Transaction);

                            ////If any ItemAvailabilitys exist in DB
                            if (lstItemAvailabilitysFromDB != null && lstItemAvailabilitysFromDB.Count > 0)
                            {
                                ////Check all records from DB one by one, if match with lstItemAvailabilitys, then update it, o/w delete from DB.
                                for (int i = 0; i < lstItemAvailabilitysFromDB.Count; i++)
                                {
                                    bool blIsProcessed = false;
                                    ////To check if individual record from DB exist in lstItemAvailabilitys or not,
                                    for (int j = 0; j < lstItemAvailabilitys.Count; j++)
                                    {
                                        ////If match found,
                                        if (lstItemAvailabilitysFromDB[i].POSPointID == lstItemAvailabilitys[j].POSPointID)
                                        {
                                            lstItemAvailabilitys.RemoveAt(j);
                                            j--;
                                            blIsProcessed = true;
                                            break;
                                        }
                                    }

                                    ////After checking all record of lstItemAvailabilitys, if blIsProcessed is remain false, that means to delete from DB.
                                    if (!blIsProcessed)
                                    {
                                        ////Delete From DB.
                                        flag = objItemAvailabilityDAL.Delete(lstItemAvailabilitysFromDB[i].ItemAvailabilityID);
                                    }
                                }
                            }

                            ////After processign lstItemAvailabilitysFromDB, lstItemAvailabilitys contains only those records which are new to insert in DB
                            foreach (ItemAvailability objItemAvailability in lstItemAvailabilitys)
                            {
                                objItemAvailabilityDAL = new ItemAvailabilityDAL(lt.Transaction);
                                objItemAvailability.ItemAvailabilityID = Guid.NewGuid();
                                objItemAvailability.ItemID = businessObject.ItemID;

                                if (!objItemAvailability.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objItemAvailability.BrokenRulesList.ToString());
                                }
                                flag = objItemAvailabilityDAL.Insert(objItemAvailability);
                            }
                        }
                        else
                        {
                            ////lstItemAvailabilitys not contain any record, so Delete all ItemAvailabilitys from DB by ItemID.
                            ItemAvailabilityDAL objAvailabilityDal = new ItemAvailabilityDAL(lt.Transaction);
                            flag = objAvailabilityDal.DeleteByField(ItemAvailability.ItemAvailabilityFields.ItemID.ToString(), businessObject.ItemID.ToString());
                        }

                        ItemCategoryDAL objItemCategoryDAL = new ItemCategoryDAL(lt.Transaction);
                        objItemCategoryDAL.DeleteByField(ItemCategory.ItemCategoryFields.ItemID.ToString(), businessObject.ItemID.ToString());

                        if (lstItemCategory.Count != 0)
                        {
                            foreach (ItemCategory item in lstItemCategory)
                            {
                                item.ItemCategoryID = Guid.NewGuid();
                                item.ItemID = businessObject.ItemID;

                                if (!item.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                                }
                                flag = objItemCategoryDAL.Insert(item);
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

        public static bool UpdateData(Item businessObject, List<ItemTax> lstItemTaxes, List<ItemTax> lstItemTaxesFromDB, List<ItemAvailability> lstItemAvailability, List<ItemCategory> lstItemCategory)
        {
            bool flag = false;
            ItemDAL _dataObject = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ItemDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        flag = _dataObject.Update(businessObject);

                        ////If lstItemTaxes contains record....
                        if (lstItemTaxes != null && lstItemTaxes.Count > 0)
                        {
                            ItemTaxDAL objItemTaxDAL = new ItemTaxDAL(lt.Transaction);

                            ////If any ItemTaxes exist in DB
                            if (lstItemTaxesFromDB != null && lstItemTaxesFromDB.Count > 0)
                            {
                                ////Check all records from DB one by one, if match with lstItemTaxes, then update it, o/w delete from DB.
                                for (int i = 0; i < lstItemTaxesFromDB.Count; i++)
                                {
                                    bool blIsProcessed = false;
                                    ////To check if individual record from DB exist in lstItemTaxes or not,
                                    for (int j = 0; j < lstItemTaxes.Count; j++)
                                    {
                                        ////If match found,
                                        if (lstItemTaxesFromDB[i].TaxID == lstItemTaxes[j].TaxID)
                                        {
                                            lstItemTaxes.RemoveAt(j);
                                            j--;
                                            blIsProcessed = true;
                                            break;
                                        }
                                    }

                                    ////After checking all record of lstItemTaxes, if blIsProcessed is remain false, that means to delete from DB.
                                    if (!blIsProcessed)
                                    {
                                        ////Delete From DB.
                                        flag = objItemTaxDAL.Delete(lstItemTaxesFromDB[i].ItemTaxID);
                                    }
                                }
                            }

                            ////After processign lstItemTaxesFromDB, lstRateTaxes contains only those records which are new to insert in DB
                            foreach (ItemTax objItemTax in lstItemTaxes)
                            {
                                objItemTaxDAL = new ItemTaxDAL(lt.Transaction);
                                objItemTax.ItemTaxID = Guid.NewGuid();
                                objItemTax.ItemID = businessObject.ItemID;

                                if (!objItemTax.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objItemTax.BrokenRulesList.ToString());
                                }
                                flag = objItemTaxDAL.Insert(objItemTax);
                            }
                        }
                        else
                        {
                            ////lstItemTaxes not contain any record, so Delete all ItemTaxes from DB by ItemID.
                            ItemTaxDAL objItemTaxDal = new ItemTaxDAL(lt.Transaction);
                            flag = objItemTaxDal.DeleteByField(ItemTax.ItemTaxFields.ItemID.ToString(), businessObject.ItemID.ToString());
                        }


                        ItemCategoryDAL objItemCategoryDAL = new ItemCategoryDAL(lt.Transaction);
                        flag = objItemCategoryDAL.DeleteByField(ItemCategory.ItemCategoryFields.ItemID.ToString(), businessObject.ItemID.ToString());

                        if (lstItemCategory.Count != 0)
                        {
                            foreach (ItemCategory item in lstItemCategory)
                            {
                                item.ItemCategoryID = Guid.NewGuid();
                                item.ItemID = businessObject.ItemID;

                                if (!item.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                                }
                                flag = objItemCategoryDAL.Insert(item);
                            }
                        }

                        ////If lstItemAvailabilitys contains record....

                        ItemAvailabilityDAL objItemAvailabilityDAL = new ItemAvailabilityDAL(lt.Transaction);
                        flag = objItemAvailabilityDAL.DeleteByField(ItemAvailability.ItemAvailabilityFields.ItemID.ToString(), businessObject.ItemID.ToString());

                        if (lstItemAvailability.Count != 0)
                        {
                            foreach (ItemAvailability item in lstItemAvailability)
                            {
                                item.ItemAvailabilityID = Guid.NewGuid();
                                item.ItemID = businessObject.ItemID;

                                if (!item.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                                }
                                flag = objItemAvailabilityDAL.Insert(item);
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
        /// get Item by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Item GetByPrimaryKey(Guid keys)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Items
        /// </summary>
        /// <returns>list</returns>
        public static List<Item> GetAll(Item obj)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Items
        /// </summary>
        /// <returns>list</returns>
        public static List<Item> GetAll()
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Item by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Item> GetAllBy(Item.ItemFields fieldName, object value)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Items
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Item obj)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Items
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Item by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Item.ItemFields fieldName, object value)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Item obj)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Item by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Item.ItemFields fieldName, object value)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllAllForAddOns(Guid companyID, Guid propertyID, Guid addOnID)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectAllForAddOns(companyID, propertyID, addOnID);
        }

        public static DataSet GetAllWithRelatedData(Item obj)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectAllWithRelatedData(obj);
        }

        public static DataSet GetItemDataByPrimaryKey(Guid itemID)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectItemDataByPrimaryKey(itemID);
        }

        public static DataSet SelectAllForRateCard(Guid companyID, Guid propertyID)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectAllForRateCard(companyID, propertyID);
        }

        public static DataSet GetItemAvailabilityDataByItemIDAndCategoryIDs(Guid? ItemID, string strCategoryID)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SelectItemAvailabilityDataByItemIDAndCategoryIDs(ItemID, strCategoryID);
        }


        public static List<Item> SearchDataForRoomService(Guid? PropertyID, Guid? CompanyID, string Title)
        {
            ItemDAL _dataObject = new ItemDAL();
            return _dataObject.SearchDataForRoomService(PropertyID, CompanyID, Title);
        }

        #endregion

    }
}
