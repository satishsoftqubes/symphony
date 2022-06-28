using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQT.Symphony.UI.Web.Configuration.GUI.Configurations
{
    [Serializable]
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemOrder { get; set; }
    }
}