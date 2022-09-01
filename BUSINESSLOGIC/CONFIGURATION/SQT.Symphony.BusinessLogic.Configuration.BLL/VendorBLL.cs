using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.FRAMEWORK.LOGGER;
using SQT.Symphony.BusinessLogic.Configuration.DAL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public class VendorBLL
    {
       
        public static bool Insert(Vendor objVender)
        {
            VendorDAL _dataObject = new VendorDAL();
            try
            {
                if (_dataObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        objVender.VendorID = Guid.NewGuid();

                        if (!objVender.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objVender.BrokenRulesList.ToString());
                        }
                        return _dataObject.Insert(objVender);
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

        public static DataSet GetVenderData(string VendorName, string MobileNo)
        {
            VendorDAL _dataObject = new VendorDAL();
            DataSet ds = _dataObject.GetVendorData(VendorName, MobileNo);
            return ds;
        }

        public static DataSet GetByIdWise_VendorData(Guid vendorID)
        {
            VendorDAL _dataObject = new VendorDAL();
            DataSet ds = _dataObject.GetByIdWise_VendorData(vendorID);
            return ds;
        }

        public static bool Delete(Guid keys)
        {
            VendorDAL _dataObject = new VendorDAL();
            return _dataObject.Delete(keys);
        }

        public static bool Update(Vendor objVender)
        {
            VendorDAL _dataObject = new VendorDAL();
            try
            {
                if (_dataObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!objVender.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objVender.BrokenRulesList.ToString());
                        }
                        return _dataObject.Update(objVender);
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
