using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.Common;
using SQT.FRAMEWORK.DAL.Linq.Reflection;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq.ThreadSafeCaches;

namespace SQT.FRAMEWORK.DAL.Linq.Adapters
{
    public static class ObjectSqlAdapter
    {
        private static DataCache<String, ConstructorInfo> constructorCache = new DataCache<string, ConstructorInfo>();
        private static DataCache<String, PropertyInfo[]> propertyCache = new DataCache<string, PropertyInfo[]>();
        private static DataCache<String, Func<DbDataReader, Object>> objectMappingCache = new DataCache<string, Func<DbDataReader, Object>>();

        private const string outputPrefix = "hydrate_";
        private const string inputPrefix = "dehydrate_";
        
        #region Public Methods

        public static T HydrateObject<T>(DbDataReader reader)
        {
            string key = GetObjectCachingKey<T>(outputPrefix); 
            return (T)objectMappingCache
                            .Fetch(key, () => MapObject<T>(reader))
                                .Invoke(reader);           
        }

        public static Action<DbCommand> DeHydrateObject<T>(Object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] properties = t.GetProperties();

            return ((cmd) =>
            {
                foreach (DbParameter parameter in cmd.Parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output) { continue; }
                    PropertyInfo currentProp = properties.FirstOrDefault(p =>
                    {
                        var paramName = StripParamPrefix(parameter.ParameterName);
                        if (p.Name.ToUpper() == paramName.ToUpper())
                        {
                            return true;
                        }
                        return false;
                    });
                    if (null != currentProp)
                    {
                        GetPropertyHandler handler = DynamicMethodCompiler.CreatePropertyGetHandler<T>(currentProp);
                        cmd.Parameters[parameter.ParameterName].Value = handler.Invoke(obj);
                    }
                }    
            });                   
        }

        #endregion

        private static String StripParamPrefix(string paramName)
        {
            return (paramName.Replace("@", "").Replace(":", "").Replace("?", ""));
        }


        private static String GetObjectCachingKey<T>(string prefix)
        {
            PropertyInfo[] properties = GetAllProperties<T>();
            StringBuilder objectKey = new StringBuilder(prefix);
            foreach (PropertyInfo property in properties)
            {
                objectKey.Append(property.Name);
            }
            return Convert.ToString(objectKey);
        }


        private static Func<DbDataReader, Object> MapObject<T>(DbDataReader reader)
        {
            List<Action<DbDataReader, Object>> mappedPropertyDelegates = MapProperties<T>(reader);
            return ((rdr) =>
            {
                Object obj = CreateInstance<T>();
                foreach (Action<DbDataReader, Object> propDelegate in mappedPropertyDelegates)
                {
                    propDelegate.Invoke(rdr, obj);
                }
                return obj;
            });            
        }


        private static T CreateInstance<T>()
        {           
            InstanceCreateHandler instance = DynamicMethodCompiler.CreateInstance<T>(GetDefaultConstructor<T>());
            return (T)instance.Invoke();
        }


        private static ConstructorInfo GetDefaultConstructor<T>()
        {
            Type t = typeof(T);
            return constructorCache.Fetch(t.FullName, (() =>
            {
                return t.GetConstructor(BindingFlags.Public |
                                                       BindingFlags.NonPublic |
                                                       BindingFlags.Instance
                                                       , null, new Type[0], null);
            }));           
        }


        private static List<Action<DbDataReader, Object>> MapProperties<T>(DbDataReader reader)
        {
            PropertyInfo[] properties = GetAllProperties<T>();
            List<Action<DbDataReader, Object>> propertyMappings = new List<Action<DbDataReader, Object>>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                PropertyInfo matchingProperty = properties.FirstOrDefault(p =>
                {
                    ColumnAttribute propColumnAttr = p.GetCustomAttributes(typeof(ColumnAttribute), false)
                                                        .FirstOrDefault() 
                                                            as ColumnAttribute;
                    string propertyName = (null != propColumnAttr) ?
                                                        propColumnAttr.Name.ToUpper() :
                                                        p.Name.ToUpper();

                    return (columnName.ToUpper() == propertyName);

                });
                if (null != matchingProperty) 
                {
                    Type columnType = reader.GetFieldType(i);
                    propertyMappings.Add(CreateValueSetter<T>(matchingProperty, columnType, columnName));
                }
            }
            return propertyMappings;

        }


        private static Action<DbDataReader, Object> CreateValueSetter<T>(PropertyInfo property, Type columnType, string columnName)
        {
            Type pType = property.PropertyType;
            SetPropertyHandler setHandle = DynamicMethodCompiler.CreateSetPropertyHandler<T>(property);
            Action<DbDataReader, Object> SetAction;

            if (pType.BaseType != null && pType.BaseType.Equals(typeof(Enum)))
            {
                SetAction = (DbDataReader reader, Object obj) =>
                {
                    if (isNaN(reader[columnName]))
                    {
                        setHandle.Invoke(obj, Enum.ToObject(pType, reader[columnName]));
                    }
                    else
                    {
                        setHandle.Invoke(obj, Enum.ToObject(pType, Convert.ChangeType(reader[columnName], pType)));
                    }
                }; 
            }
            else
            {
                SetAction = (DbDataReader reader, Object obj) =>
                {
                    if (pType.ToString().Equals("System.Nullable`1[System.Guid]"))
                        setHandle.Invoke(obj, (Guid?)(reader[columnName]));
                    else if (pType.ToString().Equals("System.Nullable`1[System.DateTime]"))
                        setHandle.Invoke(obj, (DateTime?)(reader[columnName]));
                    else if (pType.ToString().Equals("System.Nullable`1[System.Boolean]"))
                        setHandle.Invoke(obj, (bool?)(reader[columnName]));
                    else if (pType.ToString().Equals("System.Nullable`1[System.Int32]"))
                        setHandle.Invoke(obj, (int?)(reader[columnName]));
                    else if (pType.ToString().Equals("System.Nullable`1[System.Decimal]"))
                        setHandle.Invoke(obj, (decimal?)(reader[columnName]));
                    else
                        setHandle.Invoke(obj, Convert.ChangeType(reader[columnName], pType));
                };
            }

            return ((DbDataReader reader, Object obj) =>
                {
                    if (!Convert.IsDBNull(reader[columnName]))
                    {
                        SetAction.Invoke(reader, obj);
                    }
                });
        }


        private static PropertyInfo[] GetAllProperties<T>()
        {
            Type objType = typeof(T);
            return propertyCache.Fetch(objType.FullName, (() => objType.GetProperties()));
        }


        private static Boolean isNaN(object value)
        {
            double outNum;
            return (!Double.TryParse(
                                Convert.ToString(value)
                                , NumberStyles.Any
                                , NumberFormatInfo.InvariantInfo
                                , out outNum));           
        }


    }
}
