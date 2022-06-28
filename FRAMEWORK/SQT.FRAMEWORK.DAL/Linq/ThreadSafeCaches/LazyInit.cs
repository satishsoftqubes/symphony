using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQT.FRAMEWORK.DAL.Linq.ThreadSafeCaches
{
    public class LazyInit<T>
    {

        Func<T> funcDelegate;
        object syncRoot = new object();
        T data;
        volatile bool isCreated;

        public LazyInit(Func<T> producer)
        {
            funcDelegate = producer;
        }

        public T Value
        {
            get
            {
                if (!isCreated)
                {
                    lock (syncRoot)
                    {
                        if (!isCreated)
                        {
                            data = funcDelegate.Invoke();
                            isCreated = true;
                            funcDelegate = null;
                        }
                    }
                }
                return data;
            }
        }

    }
}