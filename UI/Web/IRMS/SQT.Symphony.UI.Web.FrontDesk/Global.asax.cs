using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

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

    }
}
