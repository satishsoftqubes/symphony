using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlResourceFileAssignment : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Control Events
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            string[] FileName = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "MasterResourceFiles/" + ddlLanguage.SelectedValue.ToString());

            for (int i = 0; i < FileName.Length; i++)
            {
                string str = FileName[i].ToString();
                string strDesPath = AppDomain.CurrentDomain.BaseDirectory + @"App_GlobalResources\" + Convert.ToString("2020").Replace("-", "_") + "_" + FileName[i].Substring(FileName[i].ToString().LastIndexOf(@"\") + 1);
                //System.IO.File.Copy(FileName[i].ToString(), strDesPath);
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {

        }
        #endregion
    }
}