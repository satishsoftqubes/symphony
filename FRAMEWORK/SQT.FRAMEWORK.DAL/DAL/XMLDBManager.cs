using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Data.ProviderBase;
using System.Text;

namespace SQT.FRAMEWORK.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class XMLDBManager
    {
        protected string XMLFilePath;
        protected string XSDFilePath;
        public DataSet dst;
        public DataView dv;
   
        /// <summary>
        /// 
        /// </summary>
        public XMLDBManager()
        {
        }

        public XMLDBManager(string XMLFileLocation)
        {
            this.XMLFilePath = XMLFileLocation;
            dst = new DataSet();
            dst.ReadXml(this.XMLFilePath);
        }
        
        public XMLDBManager(string XSDFileLocation, string XMLFileLocation)
        {
            this.XSDFilePath = XSDFileLocation;
            this.XMLFilePath = XMLFileLocation;
            dst = new DataSet();
            dst.ReadXmlSchema(this.XSDFilePath);
            dst.ReadXml(this.XMLFilePath);
        }

    }
}
