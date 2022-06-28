using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlLogInLogList : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }

        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] != null)
            {
                if (RoleRightJoinBLL.GetAccessString("RPTLogInLogList.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");

                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                if (!IsPostBack)
                    LoadControlValue();
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Load Control Value
        /// </summary>
        private void LoadControlValue()
        {
            try
            {
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    ProjectTerm objProjectTerm = new ProjectTerm();
                    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                    if (objProjectTerm != null)
                    {
                        calStartDate.Format = calEndDate.Format = objProjectTerm.Term;
                        this.DateFormat = objProjectTerm.Term;
                    }
                    else
                    {
                        calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                        this.DateFormat = "dd/MM/yyyy";
                    }
                }
                else
                {
                    calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                    this.DateFormat = "dd/MM/yyyy";
                }
                BindRole();
                chkStartDate.Checked = chkEndDate.Checked = false;
                chkStartDate_CheckedChanged(null, null);
                chkEndDate_CheckedChanged(null, null);
                txtName.Text = "";
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Role
        /// </summary>
        private void BindRole()
        {
            List<Role> lstRole = null;
            Role objRole = new Role();
            objRole.IsActive = true;
            objRole.CompanyID = this.CompanyID;
            lstRole = RoleBLL.GetAll(objRole);
            if (lstRole.Count != 0)
            {
                lstRole.Sort((Role r1, Role r2) => r1.RoleName.CompareTo(r2.RoleName));
                ddlRole.DataSource = lstRole;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleID";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlRole.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "LogIn Log List");
                DataSet ds = new DataSet();
                string strName = null;
                Guid? idRole = null;
                DateTime? startdt = null;
                DateTime? enddt = null;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (!txtName.Text.Equals(""))
                    strName = '%' + txtName.Text.Trim() + '%';
                if (!ddlRole.SelectedValue.Equals(Guid.Empty.ToString()))
                    idRole = new Guid(Convert.ToString(ddlRole.SelectedValue));
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (!txtName.Text.Equals(""))
                    Session.Add("Name", txtName.Text.Trim());
                if (!ddlRole.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Role", ddlRole.SelectedItem.Text);                
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);

                ds = LoginLogBLL.GetRptLogInLog(strName, startdt, enddt, idRole);
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Click Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion

        #region CheckBox Event
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
            txtStartDate.Text = "";
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        #endregion
    }
}