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
    public static class TranscriptBLL
    {

        //#region data Members

        //private static TranscriptDAL _dataObject = null;

        //#endregion

        #region Constructor

        static TranscriptBLL()
        {
            //_dataObject = new TranscriptDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Transcript
        /// </summary>
        /// <param name="businessObject">Transcript object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Transcript businessObject)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TranscriptID = Guid.NewGuid();

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

        /// <summary>
        /// Update existing Transcript
        /// </summary>
        /// <param name="businessObject">Transcript object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Transcript businessObject)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
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

        /// <summary>
        /// get Transcript by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Transcript GetByPrimaryKey(Guid keys)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Transcripts
        /// </summary>
        /// <returns>list</returns>
        public static List<Transcript> GetAll(Transcript obj)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Transcripts
        /// </summary>
        /// <returns>list</returns>
        public static List<Transcript> GetAll()
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Transcript by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Transcript> GetAllBy(Transcript.TranscriptFields fieldName, object value)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Transcripts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Transcript obj)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Transcripts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Transcript by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Transcript.TranscriptFields fieldName, object value)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Transcript obj)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Transcript by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Transcript.TranscriptFields fieldName, object value)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static List<Transcript> TranscriptSearchData(Guid? PropertyID, string Title, string ModuleName, string TranscriptType)
        {
            TranscriptDAL _dataObject = new TranscriptDAL();
            return _dataObject.TranscriptSearchData(PropertyID, Title, ModuleName, TranscriptType);
        }

        #endregion

    }
}
