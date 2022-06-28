using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.BackOffice.Master
{
    public partial class master : System.Web.UI.MasterPage
    {
        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.UserID == Guid.Empty || clsSession.UserID == null)
            {
                Session.Clear();
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                SetLabel();
                SetMenuItemsVisibility();
                SetLeftMenusSelection();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Set Page Label
        /// </summary>
        private void SetLabel()
        {
            lblUserDisplayName.Text = clsSession.DisplayName;
            //lblUserRoleType.Text = clsSession.UserType;
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
            ltrModuleTitle.Text = "Accounts Setup"; //clsCommon.GetGlobalResourceText("AdminMaster", "lblModuleTitle", "BackOffice Setup");
            ltrSetting.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblUserSetting", "Setting");
            //litLSettings.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litLSettings", "Account Configuration");
            litAcctGroup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litAcctGroup", "Account Group");
            litAccountSetup.Text = "Ledger Acct. Setup"; //clsCommon.GetGlobalResourceText("AdminMaster", "lblAccountSetup", "Chart Of Account");
            litTaxSetup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litTaxSetup", "Tax SetUp");
            //litMAcctConfig.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litMAcctConfig", "Account Configuration");
            litMAccGroup.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litMAccGroup", "Account Group");
            litMAccount.Text = "Ledger Acct. Setup";// clsCommon.GetGlobalResourceText("AdminMaster", "litMAccount", "Chart Of Account");
            litMTax.Text = clsCommon.GetGlobalResourceText("AdminMaster", "litMTax", "Tax SetUp");
            
        }

        private void SetLeftMenusSelection()
        {
            try
            {
                var uri = new Uri(Convert.ToString(Request.Url));
                string path = uri.GetLeftPart(UriPartial.Path);
                string[] strArray = path.Split('/');
                string strToSelectPane = clsCommon.GetAccordionIndex(Convert.ToString(strArray[strArray.Length - 2]) + "/" + Convert.ToString(strArray[strArray.Length - 1]));

                int Index = 0;
                foreach (AjaxControlToolkit.AccordionPane pane in MyAccordion.Panes)
                {
                    if (pane.Visible == true)
                    {
                        if (pane.ID.ToUpper() == strToSelectPane.ToUpper())
                        {
                            MyAccordion.SelectedIndex = Index;
                            break;
                        }
                        Index++;
                    }
                }
            }
            catch
            {
                MyAccordion.SelectedIndex = 0;
            }
        }

        private void SetMenuItemsVisibility()
        {           
            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                return;
            }

            if (clsSession.UserRights == string.Empty)
            {
                ////DataSet dsUserAuthorization = UserBLL.GetUserAllAuthorization(clsSession.UserID);
                Guid? PropertyID = null;
                Guid? CompanyID = null;

                if (clsSession.PropertyID != null && clsSession.PropertyID != Guid.Empty)
                    PropertyID = new Guid(Convert.ToString(Session["PropertyID"]));

                if (clsSession.CompanyID != null && clsSession.CompanyID != Guid.Empty)
                    CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                DataSet dsUserAuthorization = UserBLL.GetUserAllAuthorization(clsSession.UserID, null, PropertyID, CompanyID);
                if (dsUserAuthorization.Tables.Count > 0 && dsUserAuthorization != null && dsUserAuthorization.Tables[0].Rows.Count > 0)
                {
                    clsSession.UserRights = Convert.ToString(dsUserAuthorization.Tables[0].Rows[0]["UserRights"]);
                }
            }

            liLAcctGroup.Visible = liMAcctGroup.Visible = clsSession.UserRights.IndexOf("ACCOUNTGROUP.ASPX") > -1;
            liMAccount.Visible = liLAccountSetUp.Visible = clsSession.UserRights.IndexOf("CHARTOFACCOUNT.ASPX") > -1;
            liMTax.Visible = liLTaxList.Visible = clsSession.UserRights.IndexOf("TAXSETUP1.ASPX") > -1;
            liLCompanyinvoice.Visible = liMCompanyInvoicing.Visible = clsSession.UserRights.IndexOf("COMPANYINVOICING.ASPX") > -1;
            //liMReprintCompanyInvoice.Visible = liReprintCompanyInvoice.Visible = clsSession.UserRights.IndexOf("REPRINTCOMPANYINVOICE.ASPX") > -1;

            liMInvoiceSettlement.Visible = liInvoiceSettlement.Visible = clsSession.UserRights.IndexOf("INVOICESETTLEMENT.ASPX") > -1;
            

                   
            //else if (clsSession.SelectedModule.ToUpper() == "Back Office")
            //{
              
            //}
        }
        #endregion Private Method

        #region Control Event
        /// <summary>
        /// Log Out Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            if (clsSession.LogInLogID != Guid.Empty)
            {
                LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                objToUpdate.Logout = DateTime.Now;
                LoginLogBLL.Update(objToUpdate);
            }

            string strUserType = clsSession.UserType.ToUpper();

            Session.Clear();
            Response.Redirect("http://pms.uniworldindia.com");
            //if (strUserType == "SUPERADMIN" || strUserType == "ADMINISTRATOR")
            //{
            //    ////Response.Redirect("~/CompanyLogin.aspx");
            //    Response.Redirect("~/Index.aspx");
            //}
            //else
            //    Response.Redirect("~/Index.aspx");
        }

        protected void lnkUserSettings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/CommonControls/UserSetting.aspx");
        }

        protected void lnkChangeModule_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Module.aspx");
        }


        #endregion
    }
}