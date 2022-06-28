using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlActionLogList : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
       
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
            if (RoleRightJoinBLL.GetAccessString("RPTActionLogList.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");

            if (!IsPostBack)
                LoadControlValue();           
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
                chkStartDate.Checked = chkEndDate.Checked = false;
                chkStartDate_CheckedChanged(null, null);
                chkEndDate_CheckedChanged(null, null);
                txtName.Text = "";
                txtActionObject.Text = "";
                BindActionType();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Action Type
        /// </summary>
        private void BindActionType()
        {
            string ActionTypeQuery = "select distinct(ActionType) from usr_ActionLog";
            DataSet dsActionType = ActionLogBLL.GetActionLog(ActionTypeQuery);

            if (dsActionType.Tables[0].Rows.Count != 0)
            {
                DataView dvActionType = new DataView(dsActionType.Tables[0]);
                dvActionType.Sort = "ActionType Asc";
                ddlActionType.DataSource = dvActionType;
                ddlActionType.DataTextField = "ActionType";
                ddlActionType.DataValueField = "ActionType";
                ddlActionType.DataBind();
                ddlActionType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlActionType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Action Log List");
                DataSet ds = new DataSet();
                string strName = null;
                string strActionType = null;
                string strActionObject = null;
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtName.Text.Equals(""))
                    strName = '%' + txtName.Text.Trim() + '%';
                if (!ddlActionType.SelectedValue.Equals(Guid.Empty.ToString()))
                    strActionType = Convert.ToString(ddlActionType.SelectedValue);
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtActionObject.Text.Equals(""))
                    strActionObject = '%' + txtActionObject.Text.Trim() + '%';

                if (!txtName.Text.Equals(""))
                    Session.Add("Name", txtName.Text.Trim());
                if (!txtActionObject.Text.Equals(""))
                    Session.Add("ActionObject", txtActionObject.Text.Trim());
                if (!ddlActionType.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("ActionType", ddlActionType.SelectedItem.Text);
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);

                ds = ActionLogBLL.GetRptActionLog(strName, startdt, enddt, strActionType, strActionObject);
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