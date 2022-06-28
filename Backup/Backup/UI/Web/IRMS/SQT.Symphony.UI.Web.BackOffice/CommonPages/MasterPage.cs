using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;


namespace SQT.Symphony.UI.Web.Configuration.CommonPages
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
            string masterfile = "~/Master/admin.Master";
            if (!masterfile.Equals(string.Empty))
            {
                base.MasterPageFile = masterfile;
            }
            base.OnPreInit(e);
        }

        #endregion OverRide Method

        #region Default Initialize Information
        /// <summary>
        /// Select Default Language For Every Page
        /// </summary>
        protected override void InitializeCulture()
        {
            if (Session["LanguageName"] != null)
            {   
                string selectedValue = Session["LanguageName"].ToString();
                switch (selectedValue)
                {
                    case "Dutch": SetCulture("nl-NL", "nl-NL");
                        break;
                    case "English": SetCulture("en-US", "en-US");
                        break;
                    default: break;
                }                
            }
            else
            {
              
                SetCulture("en-US", "en-US");
            }
            if (Session["MyUICulture"] != null && Session["MyCulture"] != null)
            {
                Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session["MyUICulture"];
                Thread.CurrentThread.CurrentCulture = (CultureInfo)Session["MyCulture"];
            }
            base.InitializeCulture();
        }


        #endregion Default Initialize Information

        #region Private Method

        /// <summary>
        /// Set Culture Information To All Information
        /// </summary>
        /// <param name="name"></param>
        /// <param name="locale"></param>
        protected void SetCulture(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            Session["MyUICulture"] = Thread.CurrentThread.CurrentUICulture;
            Session["MyCulture"] = Thread.CurrentThread.CurrentCulture;
        }

        #endregion Private Method
    }
}