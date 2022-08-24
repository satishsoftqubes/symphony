using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.FRAMEWORK.LOGGER;
using SQT.Symphony.BusinessLogic.Configuration.DAL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public class SalerPartnerBLL
    {
        public static bool Save(SalerPartner objSP)
        {

            SalerPartnerDAL _dataObject = new SalerPartnerDAL();
            try
            {
                if (_dataObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        objSP.PartnerID = Guid.NewGuid();

                        if (!objSP.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objSP.BrokenRulesList.ToString());
                        }
                        return _dataObject.Insert(objSP);
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

        public static List<SalerPartner>GetAll(SalerPartner objSalerConfiguration)
        {
            SalerPartnerDAL _dataObject = new SalerPartnerDAL();
            return _dataObject.SelectAll(objSalerConfiguration);
        }

        public static DataSet GetSalerPartnerData(string FirstName,string MobileNo)
        {
            SalerPartnerDAL _dataObject = new SalerPartnerDAL();
            DataSet ds = _dataObject.GetSalerPartnerData(FirstName,MobileNo);
            return ds;
        }

        public static DataSet GetByIdWise_SalePartnerData(Guid PartnerID)
        {
            SalerPartnerDAL _dataObject = new SalerPartnerDAL();
            DataSet ds = _dataObject.GetByIdWise_SalePartnerData(PartnerID);
            return ds;
        }

        public static bool Delete(Guid keys)
        {
            SalerPartnerDAL _dataObject = new SalerPartnerDAL();
            return _dataObject.Delete(keys);
        }

        public static bool Update(SalerPartner objSP)
        {
            SalerPartnerDAL _dataObject = new SalerPartnerDAL();
            try
            {
                if (_dataObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!objSP.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objSP.BrokenRulesList.ToString());
                        }
                        return _dataObject.Update(objSP);
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
    }
}
