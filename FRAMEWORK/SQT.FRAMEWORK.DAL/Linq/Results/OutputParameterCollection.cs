using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQT.FRAMEWORK.DAL.Linq.Interfaces;

namespace SQT.FRAMEWORK.DAL.Linq.Results
{
    public class OutputParameterCollection : IHideObjectMembers
    {
        private Dictionary<String, OutputParameter> outputParameters = null;        

        public OutputParameterCollection()
        {
            outputParameters = new Dictionary<String, OutputParameter>();
        }

        public void Add(String key, OutputParameter value)
        {
            outputParameters.Add(key, value);
        }

        public OutputParameter GetValue(int index)
        {
            OutputParameter param = null;
            KeyValuePair<String, OutputParameter> kvp = outputParameters.ElementAtOrDefault(index);
            if (null != kvp.Value) { param = kvp.Value; }
            return (param);
        }

        public OutputParameter GetValue(string parameterName)
        {
            return (outputParameters[parameterName]);
        }

        internal void SetValue(string parameterName, object value)
        {
            if (this.ContainsKey(parameterName))
            {
                outputParameters[parameterName].Value = value;
            }
        }

        public bool ContainsKey(String key)
        {
            return (outputParameters.ContainsKey(key));
        }

        public Dictionary<String, OutputParameter>.Enumerator GetEnumerator()
        {
            return (outputParameters.GetEnumerator());
        }

        public Dictionary<String, OutputParameter>.KeyCollection GetKeys()
        {
            return (outputParameters.Keys);
        }

        public Dictionary<String, OutputParameter>.ValueCollection GetValues()
        {
            return (outputParameters.Values);
        }
        
        public bool TryGetValue(String key, out OutputParameter value)
        {
            return outputParameters.TryGetValue(key, out value);            
        }        
                
        public int Count
        {
            get { return outputParameters.Count(); }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }              
    }
}
