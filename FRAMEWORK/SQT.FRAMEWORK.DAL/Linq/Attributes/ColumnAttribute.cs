using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQT.FRAMEWORK.DAL.Linq.Attributes
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]    
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string name)
        {
            Name = name;
        }

        public String Name { get; protected set; }
    }
}
