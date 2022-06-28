using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        #region Property and Variables

        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }
        #endregion Property and Variables


        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.UserID == Guid.Empty)
            {
                Session.Clear();
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                BindHousingRulesData();
                BindPropertyAddress();
            }
        }

        #endregion Page Load
        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RegistrationForm.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void BindHousingRulesData()
        {
            try
            {
                string strHousingRules = "select TermnCondition from res_FolioConfig where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and IsActive = 1";
                DataSet dsHousingRules = RoomBLL.GetUnitNo(strHousingRules);

                if (dsHousingRules.Tables.Count > 0 && dsHousingRules.Tables[0].Rows.Count > 0)
                    lblHousingRules.Text = Convert.ToString(dsHousingRules.Tables[0].Rows[0]["TermnCondition"]);
                else
                    lblHousingRules.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindPropertyAddress()
        {
            try
            {
                DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
                lblPropertyaddress.Text = "";
                if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
                {
                    lblPropertyaddress.Text = dsPropertyAddress.Tables[0].Rows[0]["FullAddress"].ToString();
                }
                else
                {
                    lblPropertyaddress.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method
    }
}