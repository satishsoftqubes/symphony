using System;
using System.Collections.Generic;
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

        #endregion
    }
}
