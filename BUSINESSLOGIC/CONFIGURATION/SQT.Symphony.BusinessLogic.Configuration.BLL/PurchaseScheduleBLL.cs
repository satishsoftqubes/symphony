using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.Symphony.BusinessLogic.Configuration.DAL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class PurchaseScheduleBLL
    {
        #region Constructor

        static PurchaseScheduleBLL()
        {

        }

        #endregion

        #region Public Methods

        public static bool Save(PurchaseSchedule objSavePurchaseSchedule)
        {
            bool flag = false;
            PurchaseScheduleDAL _objPurchaseSchedule = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objPurchaseSchedule = new PurchaseScheduleDAL(lt.Transaction);

                if (objSavePurchaseSchedule != null)
                {
                    objSavePurchaseSchedule.PurchaseScheduleID = Guid.NewGuid();
                    objSavePurchaseSchedule.PurchasePartnerScheduleID = Guid.NewGuid();

                    if (!objSavePurchaseSchedule.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSavePurchaseSchedule.BrokenRulesList.ToString());
                    }
                    flag = _objPurchaseSchedule.Insert(objSavePurchaseSchedule);


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

        public static bool Update(PurchaseSchedule objUpdatePurchaseSchedule)
        {
            bool flag = false;
            PurchaseScheduleDAL _objPurchaseSchedule = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objPurchaseSchedule = new PurchaseScheduleDAL(lt.Transaction);

                if (objUpdatePurchaseSchedule != null)
                {
                    //objUpdatePurchaseSchedule.PurchaseScheduleID = Guid.NewGuid();

                    if (!objUpdatePurchaseSchedule.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdatePurchaseSchedule.BrokenRulesList.ToString());
                    }
                    flag = _objPurchaseSchedule.Update(objUpdatePurchaseSchedule);


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

        public static DataSet GetPurchaseScheduleData(Guid? PropertyID, Guid? CompanyID, string PropertyName)
        {
            PurchaseScheduleDAL _dataObject = new PurchaseScheduleDAL();
            DataSet ds = _dataObject.SelectPurchaseScheduleData(PropertyID, CompanyID, PropertyName);
            return ds;
        }

        public static DataSet GetPropertyListForPurchaseSchedule(Guid? PropertyID, Guid? CompanyID, string PropertyName)
        {
            PurchaseScheduleDAL _dataObject = new PurchaseScheduleDAL();
            DataSet ds = _dataObject.GetPropertyListForPurchaseSchedule(PropertyID, CompanyID, PropertyName);
            return ds;
        }

        public static DataSet GetPurchaseSchedulePropertyInstallmentData(Guid? PropertyID, Guid? CompanyID, string PropertyName)
        {
            PurchaseScheduleDAL _dataObject = new PurchaseScheduleDAL();
            DataSet ds = _dataObject.SelectPurchaseSchedulePropertyInstallmentData(PropertyID, CompanyID, PropertyName);
            return ds;
        }

        public static bool Delete(Guid keys)
        {
            PurchaseScheduleDAL _dataObject = new PurchaseScheduleDAL();
            return _dataObject.Delete(keys);
        }

        #endregion
    }
}
