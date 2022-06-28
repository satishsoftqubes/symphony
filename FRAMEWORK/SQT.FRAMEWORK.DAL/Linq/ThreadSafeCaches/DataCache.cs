using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQT.FRAMEWORK.DAL.Linq.Interfaces;

namespace SQT.FRAMEWORK.DAL.Linq.ThreadSafeCaches
{
    public class DataCache<TKey, TValue> 
    {

        Object syncRoot = new Object();
        Dictionary<TKey, LazyInit<TValue>> cacheDictionary = new Dictionary<TKey, LazyInit<TValue>>();

        
        public TValue Fetch(TKey key, Func<TValue> producer)
        {

            LazyInit<TValue> cacheItem;

            lock (syncRoot)
            {
                if (!cacheDictionary.TryGetValue(key, out cacheItem))
                {
                    cacheItem = new LazyInit<TValue>(producer);
                    cacheDictionary.Add(key, cacheItem);
                }
            }
            return cacheItem.Value;

        }

    }
}