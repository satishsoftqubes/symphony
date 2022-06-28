﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SQT.FRAMEWORK.DAL.Linq.Interfaces
{

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHideObjectMembers
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(Object obj);
    }
}
