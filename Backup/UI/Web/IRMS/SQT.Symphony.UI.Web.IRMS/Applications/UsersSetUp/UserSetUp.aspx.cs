using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.IRMS.Applications.UsersSetUp
{
    public partial class UserSetUp : SQT.Symphony.UI.Web.IRMS.CommonPages.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetUser(string name, string userID)
        {
            string strToReturn = "0";
            DataSet dsUser = new DataSet();
            if (userID == Guid.Empty.ToString())
            {
                string UserNameQuery = "select UserName from usr_User where UserName = '" + name + "' And IsActive = 1";
                dsUser = UserBLL.GetUserName(UserNameQuery);
                if (dsUser != null && dsUser.Tables[0].Rows.Count > 0)
                    strToReturn = "1";
            }
            else
            {
                string UserNameQuery = "select UserName,UsearID from usr_User where UserName = '" + name + "' And IsActive = 1";
                dsUser = UserBLL.GetUserName(UserNameQuery);
                if (dsUser != null && dsUser.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(dsUser.Tables[0].Rows[0]["UsearID"]).ToUpper() != userID.ToUpper())
                        strToReturn = "1";
                }
            }
            return strToReturn;
        }
    }
}