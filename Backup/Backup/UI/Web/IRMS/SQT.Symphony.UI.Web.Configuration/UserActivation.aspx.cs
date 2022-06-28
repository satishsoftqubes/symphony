using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.IRMS
{
    public partial class UserActivation : System.Web.UI.Page
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Update with SVN
                ActivateUser();
            }
        }
        #endregion

        #region Methods
        private void ActivateUser()
        {
            try
            {
                if (Request["UserID"] != null && Request["key"] != null)
                {
                    SQT.Symphony.BusinessLogic.Configuration.DTO.User objUser = null;
                    objUser = SQT.Symphony.BusinessLogic.Configuration.BLL.UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Request["UserID"])));

                    if (objUser != null)
                    {
                        if (objUser.PasswordKey == Convert.ToString(Request["key"]))
                        {
                            objUser.IsActive = true;
                            objUser.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                            SQT.Symphony.BusinessLogic.Configuration.BLL.UserBLL.Update(objUser);

                            dvSuccess.Visible = true;
                        }
                        else
                            dvError.Visible = true;
                    }
                    else
                        dvError.Visible = true;
                }
                else
                    dvError.Visible = true;
            }
            catch
            {
                dvError.Visible = true;
            }
        }
        #endregion
    }
}