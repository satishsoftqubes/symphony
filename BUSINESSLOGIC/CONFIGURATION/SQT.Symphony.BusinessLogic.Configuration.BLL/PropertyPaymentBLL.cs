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
    public class PropertyPaymentBLL
    {
        #region Constructor

        static PropertyPaymentBLL()
        {

        }

        #endregion

        #region Public Methods

        public static bool Save(PropertyPayment objSavePropertyPayment)
        {
            bool flag = false;
            PropertyPaymentDAL _objPropertyPayment = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objPropertyPayment = new PropertyPaymentDAL(lt.Transaction);

                if (objSavePropertyPayment != null)
                {
                    objSavePropertyPayment.PropertyPaymentID = Guid.NewGuid();

                    if (!objSavePropertyPayment.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSavePropertyPayment.BrokenRulesList.ToString());
                    }
                    flag = _objPropertyPayment.Insert(objSavePropertyPayment);


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

        public static DataSet GetPropertyPaymentData(Guid? PropertyPaymentID, Guid? PropertyID, Guid? PropertyScheduleID, string PropertyName)
        {
            PropertyPaymentDAL _dataObject = new PropertyPaymentDAL();
            DataSet ds = _dataObject.SelectPropertyPaymentData(PropertyPaymentID, PropertyID, PropertyScheduleID, PropertyName);
            return ds;
        }

        #endregion

    }
}
