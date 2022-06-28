﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlConversionReport_RefThrough : System.Web.UI.UserControl
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

        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("RPTConversionReport_RefThrough.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");

            if (!IsPostBack)
            {
                LoadControlValue();
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
                if (Session["CompanyID"] != null)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
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
                    BindReferenceTerm();
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Refernce Term 
        /// </summary>
        private void BindReferenceTerm()
        {
            ddlReferenceThrough.Items.Clear();
            ProjectTerm RefThrow = new ProjectTerm();
            RefThrow.Category = "REF-PROSPECT";
            RefThrow.IsActive = true;
            List<ProjectTerm> LstRefThrow = ProjectTermBLL.GetAll(RefThrow);
            if (LstRefThrow.Count > 0)
            {
                LstRefThrow.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlReferenceThrough.DataSource = LstRefThrow;
                ddlReferenceThrough.DataTextField = "DisplayTerm";
                ddlReferenceThrough.DataValueField = "TermID";
                ddlReferenceThrough.DataBind();
                ddlReferenceThrough.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlReferenceThrough.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }


        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Conversion Executive_RefThrough");
                DataSet ds = new DataSet();
                string RefName = null;
                Guid? refThrough = null;
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!ddlReferenceThrough.SelectedValue.Equals(Guid.Empty.ToString()))
                {
                    refThrough = new Guid(Convert.ToString(ddlReferenceThrough.SelectedValue));
                    Session.Add("ReferenceThrough", ddlReferenceThrough.SelectedItem.Text);
                }
                if (!txtReferenceName.Text.Equals(""))
                {
                    RefName = txtReferenceName.Text.Trim();
                    Session.Add("ReferenceName", RefName);
                }
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);

                ds = ProspectsBLL.GetRptConversionExecutive_RefThrough(refThrough, RefName, startdt, enddt);
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
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