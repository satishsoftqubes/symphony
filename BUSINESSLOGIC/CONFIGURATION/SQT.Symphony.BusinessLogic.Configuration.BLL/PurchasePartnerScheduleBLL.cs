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
    public class PurchasePartnerScheduleBLL
    {
        public PurchasePartnerScheduleBLL()
        {

        }

        #region Public Methods

        public static bool Save(PurchasePartnerSchedule objSavePurchasePartnerSchedule)
        {
            bool flag = false;
            PurchasePartnerScheduleDAL _objPurchasePartnerSchedule = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objPurchasePartnerSchedule = new PurchasePartnerScheduleDAL(lt.Transaction);

                objSavePurchasePartnerSchedule.PurchasePartnerScheduleID = Guid.NewGuid();

                if (objSavePurchasePartnerSchedule != null)
                {
                    if (!objSavePurchasePartnerSchedule.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSavePurchasePartnerSchedule.BrokenRulesList.ToString());
                    }
                    flag = _objPurchasePartnerSchedule.Insert(objSavePurchasePartnerSchedule);


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
