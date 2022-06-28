using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.BackOffice
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                if (Session["LoginLogID"] != null)
                {
                    LoginLog objLogInfo = new LoginLog();
                    objLogInfo = LoginLogBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["LoginLogID"])));
                    objLogInfo.Logout = DateTime.Now;
                    LoginLogBLL.Update(objLogInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}