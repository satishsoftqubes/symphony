using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlBilling : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsMessage = false;

        public Guid FolioConfigID
        {
            get
            {
                return ViewState["FolioConfigID"] != null ? new Guid(Convert.ToString(ViewState["FolioConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioConfigID"] = value;
            }
        }
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
        #endregion Variable and Property

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                LoadDefaultValue();
            }
        }

        #endregion Page Load

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                CheckUserAuthorization();
                SetPageLabels();
                BindBreadCrumb();
                BindTermsAndConditionData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "BILLING.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnTermsConditionSave.Visible = this.UserRights.Substring(2, 1) == "1";
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblBillingMainHeader", "Billing");
            litFolioNotes.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblFolioNotes", "Foot Notes");
            btnTermsConditionSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblFrontOfficeSetup", "Policy & Configuration");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblBilling", "Billing");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindTermsAndConditionData()
        {
            FolioConfig FolioConf = new FolioConfig();
            FolioConf.CompanyID = clsSession.CompanyID;
            FolioConf.PropertyID = clsSession.PropertyID;
            FolioConf.IsActive = true;
            List<FolioConfig> LstConfig = FolioConfigBLL.GetAll(FolioConf);
            if (LstConfig.Count == 1)
            {
                this.FolioConfigID = LstConfig[0].FolioConfigID;
                txtFolioNotes.Text = Convert.ToString(LstConfig[0].FolioNotes);
                ////txtTermsCondition.Text = Convert.ToString(LstConfig[0].TermnCondition);
            }
        }


        #endregion Private Method

        #region Button Event

        protected void btnTermsConditionSave_Click(object sender, EventArgs e)
        {
            if (this.FolioConfigID != Guid.Empty)
            {
                FolioConfig Updt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
                FolioConfig OldUpdt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
                Updt.FolioNotes = txtFolioNotes.Text.Trim();
                FolioConfigBLL.Update(Updt);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldUpdt.ToString() + "<br/><br/>" + Updt.ToString(), Updt.ToString() + "<br/><br/>" + OldUpdt.ToString(), "res_FolioConfig");
            }
            IsMessage = true;
            ltrSuccessfullyTerm.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
        }

        #endregion Button Event
    }
}