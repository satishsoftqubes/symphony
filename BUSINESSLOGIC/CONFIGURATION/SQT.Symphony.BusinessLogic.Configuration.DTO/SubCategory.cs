using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    public class SubCategory : BusinessObjectBase
    {
        public class Category : BusinessObjectBase
        {

            #region InnerClass
            public enum CategoryFields
            {
                CategoryID,                
                CategoryName,                
                RefCategoryID
            }
            #endregion

            #region Data Members

            Guid _categoryID;            
            string _categoryName;            
            Guid? _refCategoryID;

            #endregion

            #region Properties

            [DataMember]
            public Guid CategoryID
            {
                get { return _categoryID; }
                set
                {
                    if (_categoryID != value)
                    {
                        _categoryID = value;
                        PropertyHasChanged("CategoryID");
                    }
                }
            }

            [DataMember]
            public string CategoryName
            {
                get { return _categoryName; }
                set
                {
                    if (_categoryName != value)
                    {
                        _categoryName = value;
                        PropertyHasChanged("CategoryName");
                    }
                }
            }

            [DataMember]
            public Guid? RefCategoryID
            {
                get { return _refCategoryID; }
                set
                {
                    if (_refCategoryID != value)
                    {
                        _refCategoryID = value;
                        PropertyHasChanged("RefCategoryID");
                    }
                }
            }

            #endregion
        }
    }
}
