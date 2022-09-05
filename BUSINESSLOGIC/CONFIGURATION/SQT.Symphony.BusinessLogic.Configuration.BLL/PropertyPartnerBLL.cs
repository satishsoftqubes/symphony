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
    public static class PropertyPartnerBLL
    {

        #region Constructor

        static PropertyPartnerBLL()
        {
            //_dataObject = new PropertyPartnerBLL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get PropertyPartner
        /// </summary>
        /// <param name="businessObject">PropertyPartner object</param>
        /// <returns>true for successfully saved</returns>
        public static PropertyPartner GetByPrimaryKey(Guid keys)
        {
            PropertyPartnerDAL _dataObject = new PropertyPartnerDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// Insert new PropertyPartner
        /// </summary>
        /// <param name="businessObject">PropertyPartner object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(PropertyPartner businessObject)
        {
            PropertyPartnerDAL _dataObject = new PropertyPartnerDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.PropertyPartnerID = Guid.NewGuid();

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

        public static bool Update(PropertyPartner businessObject)
        {
            PropertyPartnerDAL _dataObject = new PropertyPartnerDAL();
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

        public static DataSet GetPropertyPartnerData(Guid? PropertyPartnerID, string PropertyName, Guid? CompanyID)
        {
            PropertyPartnerDAL _dataObject = new PropertyPartnerDAL();
            DataSet ds = _dataObject.SelectPropertyPartnerData(PropertyPartnerID, PropertyName, CompanyID);
            return ds;
        }

        public static bool Delete(PropertyPartner obj)
        {
            PropertyPartnerDAL _dataObject = new PropertyPartnerDAL();
            return _dataObject.Delete(obj);
        }

        #endregion
    }
}
