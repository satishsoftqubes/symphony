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
    public static class PartnerPaymentBLL
    {
        #region Constructor

        static PartnerPaymentBLL()
        {

        }

        #endregion

        #region Public Methods

        public static bool Save(PartnerPayment objSavePartnerPayment)
        {
            bool flag = false;
            PartnerPaymentDAL _objPartnerPayment = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objPartnerPayment = new PartnerPaymentDAL(lt.Transaction);

                if (objSavePartnerPayment != null)
                {
                    objSavePartnerPayment.PartnerPaymentID = Guid.NewGuid();

                    if (!objSavePartnerPayment.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSavePartnerPayment.BrokenRulesList.ToString());
                    }
                    flag = _objPartnerPayment.Insert(objSavePartnerPayment);


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

        //public static bool Update(PurchaseSchedule objUpdatePurchaseSchedule)
        //{
        //    bool flag = false;
        //    PurchaseScheduleDAL _objPurchaseSchedule = null;
        //    LinqTransaction lt = null;

        //    try
        //    {
        //        lt = LinqSql.CreateTransaction("SQLConStr");
        //        _objPurchaseSchedule = new PurchaseScheduleDAL(lt.Transaction);

        //        if (objUpdatePurchaseSchedule != null)
        //        {
        //            //objUpdatePurchaseSchedule.PurchaseScheduleID = Guid.NewGuid();

        //            if (!objUpdatePurchaseSchedule.IsValid)
        //            {
        //                throw new InvalidBusinessObjectException(objUpdatePurchaseSchedule.BrokenRulesList.ToString());
        //            }
        //            flag = _objPurchaseSchedule.Update(objUpdatePurchaseSchedule);


        //            if (flag)
        //            {
        //                lt.Commit();
        //                return flag;
        //            }
        //            else
        //            {
        //                lt.Rollback();
        //            }
        //        }
        //        else
        //        {
        //            lt.Rollback();
        //            throw new InvalidBusinessObjectException("Object Is NULL");
        //        }
        //    }
        //    catch
        //    {
        //        lt.Rollback();
        //        throw;
        //    }
        //    return flag;
        //}

        public static DataSet GetPartnerPaymentData(Guid? PropertyID, Guid? PartnerID, Guid? PropertyPurchaseScheduleID, string PropertyName)
        {
            PartnerPaymentDAL _dataObject = new PartnerPaymentDAL();
            DataSet ds = _dataObject.SelectPartnerPaymentData(PropertyID, PartnerID, PropertyPurchaseScheduleID, PropertyName);
            return ds;
        }

        public static PartnerPayment GetByPrimaryKey(Guid keys)
        {
            PartnerPaymentDAL _dataObject = new PartnerPaymentDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        public static bool Delete(Guid PartnerPaymentID, decimal? PaymentAmount, Guid PropertyPurchaseScheduleID, Guid PropertyID, Guid PartnerID)
        {
            PartnerPaymentDAL _dataObject = new PartnerPaymentDAL();
            return _dataObject.Delete(PartnerPaymentID, PaymentAmount, PropertyPurchaseScheduleID, PropertyID, PartnerID);
        }

        #endregion

    }
}
