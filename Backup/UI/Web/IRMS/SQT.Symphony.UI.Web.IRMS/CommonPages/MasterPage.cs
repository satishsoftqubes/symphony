using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQT.Symphony.UI.Web.IRMS.CommonPages
{
    public class MasterPage : System.Web.UI.Page
    {

        #region OverRide Method
        /// <summary>
        /// On PreInit Method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            string masterfile = getMasterPageFromDatabase();
            if (!masterfile.Equals(string.Empty))
            {
                base.MasterPageFile = masterfile;
            }
            base.OnPreInit(e);
        }

        #endregion OverRide Method

        #region Private Method
        /// <summary>
        /// Load Master Page
        /// </summary>
        private string getMasterPageFromDatabase()
        {
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString().ToUpper() == "ADMIN")
                {
                    return "~/Master/admin.Master";
                }
                else if (Session["UserType"].ToString().ToUpper() == "INVESTOR")
                {
                    return "~/Master/investor.Master";
                }
                else if (Session["UserType"].ToString().ToUpper() == "SALES")
                {
                    return "~/Master/sales.Master";
                }
                else if (Session["UserType"].ToString().ToUpper() == "CHANNELPARTNER")
                {
                    return "~/Master/sales.Master";
                }
                else
                    return "~/Master/admin.Master";
            }
            else
                return "~/Master/admin.Master";
        }

        #endregion Private Method
    }
}