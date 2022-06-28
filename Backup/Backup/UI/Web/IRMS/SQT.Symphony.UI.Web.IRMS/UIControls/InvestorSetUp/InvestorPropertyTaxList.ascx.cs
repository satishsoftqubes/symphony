using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class InvestorPropertyTaxList : System.Web.UI.UserControl
    {
        #region Variable

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

        private DataSet ds = null;
        public bool IsPreview = false;

        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                if (Session["CompanyID"] != null)
                {
                    if (Session["PropertyConfigurationInfo"] != null)
                    {
                        PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                        ProjectTerm objProjectTerm = new ProjectTerm();
                        Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                        objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                        if (objProjectTerm != null)
                        {
                            this.DateFormat = objProjectTerm.Term;
                        }
                        else
                        {
                            this.DateFormat = "dd/MM/yyyy";
                        }
                    }
                    else
                    {
                        this.DateFormat = "dd/MM/yyyy";
                    }

                    calFromDate.Format = calToDate.Format = this.DateFormat;
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                if (txtFromDate.Text.Trim() != string.Empty && txtToDate.Text.Trim() != string.Empty)
                {
                    if (Convert.ToDateTime(txtFromDate.Text.Trim()) >= Convert.ToDateTime(txtToDate.Text.Trim()))
                    {
                        lblDateErrorMsg.Visible = true;
                        lblDateErrorMsg.Text = "*";
                        return;
                    }
                    else
                    {
                        lblDateErrorMsg.Visible = false;
                        lblDateErrorMsg.Text = "";
                    }
                }
                else
                {
                    lblDateErrorMsg.Visible = false;
                    lblDateErrorMsg.Text = "";
                }

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                string PropertyName = null;
                string UnitNo = null;
                DateTime? FromDate = null;
                DateTime? ToDate = null;

                if (!txtPropertyName.Text.Trim().Equals(""))
                    PropertyName = txtPropertyName.Text.Trim();

                if (!txtUnitNo.Text.Trim().Equals(""))
                    UnitNo = txtUnitNo.Text.Trim();

                if (!txtFromDate.Text.Trim().Equals(""))
                    FromDate = DateTime.ParseExact(txtFromDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (!txtToDate.Text.Trim().Equals(""))
                    ToDate = DateTime.ParseExact(txtToDate.Text.Trim(), this.DateFormat, objCultureInfo);

                //DataSet Dst = InvestorPaymentReceiptBLL.PrintTaxAndInsuranceReceipt(new Guid(Convert.ToString(Session["InvID"])), PropertyName, UnitNo);

                DataSet dsData = InvestorPaymentReceiptBLL.GetTaxAndInsuranceData(new Guid(Convert.ToString(Session["InvID"])), PropertyName, UnitNo, FromDate, ToDate);
                if (dsData.Tables[0] != null && dsData.Tables[0].Rows.Count > 0)
                {
                    gvPropertyTaxandList.DataSource = dsData.Tables[0];
                    gvPropertyTaxandList.DataBind();
                }
                else
                {
                    gvPropertyTaxandList.DataSource = null;
                    gvPropertyTaxandList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Report
        /// </summary>
        private void LoadReport()
        {
            try
            {
                string PropertyName = null;
                string UnitNo = null;
                DateTime? FromDate = null;
                DateTime? ToDate = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtPropertyName.Text.Trim().Equals(""))
                    PropertyName = txtPropertyName.Text.Trim();

                if (!txtUnitNo.Text.Trim().Equals(""))
                    UnitNo = txtUnitNo.Text.Trim();

                if (!txtFromDate.Text.Trim().Equals(""))
                    FromDate = DateTime.ParseExact(txtFromDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (!txtToDate.Text.Trim().Equals(""))
                    ToDate = DateTime.ParseExact(txtToDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (!txtPropertyName.Text.Trim().Equals(""))
                    Session.Add("Name", Convert.ToString(txtPropertyName.Text.Trim()));
                if (!txtUnitNo.Text.Trim().Equals(""))
                    Session.Add("Unit", Convert.ToString(txtUnitNo.Text.Trim()));
                if (!txtFromDate.Text.Trim().Equals(""))
                    Session.Add("StartDate", DateTime.ParseExact(txtFromDate.Text.Trim(), this.DateFormat, objCultureInfo));
                if (!txtToDate.Text.Trim().Equals(""))
                    Session.Add("EndDate", DateTime.ParseExact(txtToDate.Text.Trim(), this.DateFormat, objCultureInfo));

                ds = InvestorPaymentReceiptBLL.GetTaxAndInsuranceData(new Guid(Convert.ToString(Session["InvID"])), PropertyName, UnitNo, FromDate, ToDate);
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// Print Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Property Tax & Insurance");
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        /// <summary>
        /// Preview Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Property Tax & Insurance");
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Property Tax & Insurance");
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Property Tax & Insurance");
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Property Tax & Insurance");
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion Button Event

        #region Grid Event

        protected void gvPropertyTaxandList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Image AttImg = (Image)e.Row.FindControl("btnAttachment");

                    AttImg.Visible = Convert.ToBoolean(ViewState["View"]);

                    string DocumentName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DocumentName"));
                    if (!DocumentName.Equals("") && DocumentName != null)
                        AttImg.Visible = true;
                    else
                        AttImg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Grid Event
    }
}