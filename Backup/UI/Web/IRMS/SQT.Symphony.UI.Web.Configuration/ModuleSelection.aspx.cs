using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration
{
    public partial class ModuleSelection : System.Web.UI.Page
    {
        #region Variable

        DataTable dtRole = new DataTable();

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.UserID == Guid.Empty || clsSession.UserID == null)
            {
                Session.Clear();
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                LoadDefaultValue();

            }
        }

        #endregion Page Load

        #region Button Event

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSession.LogInLogID != Guid.Empty)
                {
                    LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                    objToUpdate.Logout = DateTime.Now;
                    LoginLogBLL.Update(objToUpdate);
                }

                string strUserType = clsSession.UserType.ToUpper();

                Session.Clear();
                if (strUserType == "SUPERADMIN" || strUserType == "ADMINISTRATOR")
                {
                    ////Response.Redirect("~/CompanyLogin.aspx");
                    Response.Redirect("~/Index.aspx");
                }
                else
                    Response.Redirect("~/Index.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Datalist Event

        protected void dtlstModule_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("SELECTMODULE"))
                {
                    string strArgs = Convert.ToString(e.CommandArgument);
                    if (strArgs.ToUpper() == "ACCOUNTING")
                    {
                    }
                    else if (strArgs.ToUpper() == "BACKOFFICE")
                    {
                        clsSession.SelectedModule = "BACKOFFICE";

                        if (clsSession.RoleType.ToUpper() == "SUPERADMIN")
                            Response.Redirect("~/GUI/Property/CompanyList.aspx");
                        else if (clsSession.RoleType.ToUpper() == "ADMINISTRATOR")
                        {
                            ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                            Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                        }
                        else
                        {
                            ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                            Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                        }
                    }
                    else if (strArgs.ToUpper() == "FRONTDESK")
                    {
                    }
                    else if (strArgs.ToUpper() == "HOUSEKEEPING")
                    {
                    }
                    else if (strArgs.ToUpper() == "HOUSEKEEPING CONFIG")
                    {
                    }
                    else if (strArgs.ToUpper() == "PMS")
                    {
                    }
                    else if (strArgs.ToUpper() == "POS")
                    {
                    }
                    else if (strArgs.ToUpper() == "POS CONFIG")
                    {

                    }
                    else if (strArgs.ToUpper() == "PROPERTY ADMIN")
                    {
                        clsSession.SelectedModule = "PROPERTY ADMIN";
                        Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                    }
                }
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void dtlstModule_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item)
            //{
            try
            {
                string strRoleType = Convert.ToString(clsSession.RoleType);
                string strdtRoltType = Convert.ToString(dtlstModule.DataKeys[e.Item.ItemIndex]);

                Button btnModuleName = (Button)e.Item.FindControl("btnModuleName");

                string strCssClass = string.Empty;
                if (strdtRoltType.ToUpper() == "ACCOUNTING")
                    strCssClass = "home_accounting_button";
                else if (strdtRoltType.ToUpper() == "BACKOFFICE")
                    strCssClass = "home_backoffice_button";
                else if (strdtRoltType.ToUpper() == "FRONTDESK")
                    strCssClass = "home_frontdesk_button";
                else if (strdtRoltType.ToUpper() == "HOUSEKEEPING")
                    strCssClass = "home_housekeepingconfig_button";
                else if (strdtRoltType.ToUpper() == "HOUSEKEEPING CONFIG")
                    strCssClass = "home_housekeeping_button";
                else if (strdtRoltType.ToUpper() == "PMS")
                    strCssClass = "home_pms_button";
                else if (strdtRoltType.ToUpper() == "POS")
                    strCssClass = "home_pos_button";
                else if (strdtRoltType.ToUpper() == "POS CONFIG")
                    strCssClass = "home_posconfig_button";
                else if (strdtRoltType.ToUpper() == "PROPERTY ADMIN")
                    strCssClass = "home_propertyadministrator_button";
                else if (strdtRoltType.ToUpper() == "CORPORATE SETUP")
                    strCssClass = "home_corporate_button";
                else if (strdtRoltType.ToUpper() == "HR")
                    strCssClass = "home_hr_button";
                else if (strdtRoltType.ToUpper() == "MAINTENANCE")
                    strCssClass = "home_maintenance_button";
                else if (strdtRoltType.ToUpper() == "SECURITY")
                    strCssClass = "home_security_button";
                else if (strdtRoltType.ToUpper() == "STORES")
                    strCssClass = "home_store_button";

                if (strRoleType.ToUpper() == "SUPERADMIN")
                {
                    //if (strRoleType.ToUpper() == "ADMINISTRATOR" || strRoleType.ToUpper() == "ADMIN" || strRoleType.ToUpper() == "SUPERADMIN")
                    //{
                    btnModuleName.CommandName = "SELECTMODULE";
                    btnModuleName.Enabled = true;
                    //btnModuleName.Attributes["style"] = "background-color: #0067A4; width:175px;";
                    btnModuleName.CssClass = strCssClass;
                    //strRoleType != "" && strRoleType != null && 
                }
                else
                {
                    if (dtRole != null && dtRole.Rows.Count > 0)
                    {
                        DataRow[] dr = dtRole.Select("RoleType = '" + strdtRoltType + "'");
                        if (dr.Length > 0)
                        {
                            btnModuleName.CommandName = "SELECTMODULE";
                            btnModuleName.Enabled = true;
                            btnModuleName.CssClass = strCssClass;
                        }
                        else
                        {
                            btnModuleName.CommandName = "";
                            btnModuleName.Enabled = false;
                            btnModuleName.CssClass = strCssClass + " button_disable";
                        }
                    }
                    else
                    {
                        btnModuleName.CommandName = "";
                        btnModuleName.Enabled = false;
                        btnModuleName.CssClass = strCssClass + " button_disable";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
            // }
        }

        #endregion Datalist Event

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                SetLabel();
                BindModule();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetLabel()
        {
            lblUserDisplayName.Text = clsSession.DisplayName;
            lblUserRoleType.Text = clsSession.UserType;
            lblPropertyName.Text = clsSession.PropertyName != string.Empty ? clsSession.PropertyName : "";
            if (clsSession.DateFormat != string.Empty)
                litDate.Text = DateTime.Now.Date.ToString(Convert.ToString(clsSession.DateFormat));
            else
                litDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

            if (clsSession.TimeFormat != string.Empty)
                litTime.Text = DateTime.Now.ToString(clsSession.TimeFormat);
            else
                litTime.Text = DateTime.Now.ToString("hh:mm tt");

            lblDate.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblDate", "Date");
            lblTime.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblTime", "Time");
            lnkLogout.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblBtnLogOut", "Log Out");
        }

        private void BindModule()
        {
            Guid? PropertyID = null;
            Guid? CompanyID = null;

            if (clsSession.PropertyID != null && clsSession.PropertyID != Guid.Empty)
                PropertyID = new Guid(Convert.ToString(Session["PropertyID"]));

            if (clsSession.CompanyID != null && clsSession.CompanyID != Guid.Empty)
                CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

            DataSet dsModule = UserBLL.UserSelectModule(new Guid(Convert.ToString(Session["UserID"])), PropertyID, CompanyID);

            if (dsModule.Tables.Count > 0 && dsModule.Tables[0].Rows.Count > 0)
            {
                if (dsModule.Tables.Count > 0 && dsModule.Tables[1].Rows.Count > 0)
                {
                    dtRole = dsModule.Tables[1];
                }

                dtlstModule.DataSource = dsModule.Tables[0];
                dtlstModule.DataBind();


            }
            else
            {
                dtlstModule.DataSource = null;
                dtlstModule.DataBind();
            }
        }

        #endregion Private Method

    }
}