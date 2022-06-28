using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;
using System.Text;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlRentPayoutInvestorList : System.Web.UI.UserControl
    {
        #region Property and Variable
        decimal dblTotalSqft = 0;
        decimal dblTotalYieldAmount = 0;
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
        public Guid InvestorID
        {
            get
            {
                return ViewState["InvestorID"] != null ? new Guid(Convert.ToString(ViewState["InvestorID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InvestorID"] = value;
            }
        }
        public Guid QuarterID
        {
            get
            {
                return ViewState["QuarterID"] != null ? new Guid(Convert.ToString(ViewState["QuarterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["QuarterID"] = value;
            }
        }
        public bool IsInsert = false;
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DateFormat = "dd/MM/yyyy";
                ddlQuarterList.Attributes.Add("onchange", "javascript:GetSelectedQuarterID()");
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                LoadQuarter();
                mvRentPayout.ActiveViewIndex = 0;
            }
        }

        #endregion Page Load

        #region Private Method
        protected void LoadReport()
        {
            try
            {
                if (ddlQuarterList.SelectedIndex > 0)
                {
                    this.QuarterID = new Guid(ddlQuarterList.SelectedValue);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Please select any Quarter");
                    return;
                }
                Session.Add("ReportName", "Investor Rent Payout");
                Session.Add("QuarterTitleToPrint", ddlQuarterList.SelectedItem.Text);

                string CityName, FirmName, ExecutiveName = null;
                string InvestorName = null;

                if (txtSInvestorName.Text.Trim() != "")
                    InvestorName = txtSInvestorName.Text.Trim();
                else
                    InvestorName = null;

                if (!txtSLocation.Text.Trim().Equals(""))
                    CityName = txtSLocation.Text.Trim();
                else
                    CityName = null;

                if (!txtSearchChannelPartnerFirm.Text.Trim().Equals(""))
                    FirmName = txtSearchChannelPartnerFirm.Text.Trim();
                else
                    FirmName = null;

                if (!txtSearchExecutiveName.Text.Trim().Equals(""))
                {
                    string[] strExecutiveName = txtSearchExecutiveName.Text.Trim().Split('-');

                    if (strExecutiveName.Length > 0)
                        ExecutiveName = Convert.ToString(strExecutiveName[0]).Trim();
                    else
                        ExecutiveName = "";
                }
                else
                    ExecutiveName = null;

                DataSet ds = new DataSet();
                ds = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, null, this.QuarterID, true, InvestorName, CityName, FirmName, ExecutiveName);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (i < ds.Tables[0].Rows.Count - 1)
                    {
                        DataRow dr0 = ds.Tables[0].Rows[i];
                        DataRow dr1 = ds.Tables[0].Rows[i + 1];
                        if (Convert.ToString(dr0["FullName"]).ToUpper() == Convert.ToString(dr1["FullName"]).ToUpper() && Convert.ToString(dr0["BankAcctName"]).ToUpper() == Convert.ToString(dr1["BankAcctName"]).ToUpper()
                            && Convert.ToString(dr0["TotalUnit"]).ToUpper() == Convert.ToString(dr1["TotalUnit"]).ToUpper() && Convert.ToString(dr0["TotalSqftForInvestor"]).ToUpper() == Convert.ToString(dr1["TotalSqftForInvestor"]).ToUpper()
                            && Convert.ToString(dr0["TotalRentPayoutByInvestor"]).ToUpper() == Convert.ToString(dr1["TotalRentPayoutByInvestor"]).ToUpper() && Convert.ToString(dr0["AccountNo"]).ToUpper() == Convert.ToString(dr1["AccountNo"]).ToUpper())
                        {
                            ds.Tables[0].Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0]["StartDateOfQtr"] != null && Convert.ToString(ds.Tables[0].Rows[0]["StartDateOfQtr"]) != "" && ds.Tables[0].Rows[0]["EndDate"] != null && Convert.ToString(ds.Tables[0].Rows[0]["EndDate"]) != "")
                    Session.Add("QuarterPeriodToPrint", Convert.ToString(ds.Tables[0].Rows[0]["StartDateOfQtr"]) + " to " + Convert.ToString(ds.Tables[0].Rows[0]["EndDate"]));
                else
                    Session.Add("QuarterPeriodToPrint", "");

                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private string MobileNo(string strMobileNo)
        {
            string strPhNo = "";

            string[] words = strMobileNo.Split('-');

            if (words.Length > 1)
            {
                if (words[0] != "")
                    strPhNo = Convert.ToString(words[0]);

                if (words[1] != "")
                {
                    if (strPhNo != "")
                        strPhNo = strPhNo + "-" + words[1];
                    else
                        strPhNo = words[1];
                }
            }

            return strPhNo;
        }
        private void LoadQuarter()
        {
            ddlQuarterList.Items.Clear();

            DataSet dsForRentPayoutInfo = RentPayoutQuarterSetupBLL.GetAllWithDataSet();
            if (dsForRentPayoutInfo != null && dsForRentPayoutInfo.Tables.Count > 0 && dsForRentPayoutInfo.Tables[0].Rows.Count > 0)
            {
                DataView dvForRentPayout = new DataView(dsForRentPayoutInfo.Tables[0]);
                dvForRentPayout.Sort = "StartDate asc";
                ddlQuarterList.DataSource = dvForRentPayout;
                ddlQuarterList.DataTextField = "Title";
                ddlQuarterList.DataValueField = "QuarterID";
                ddlQuarterList.DataBind();
                ddlQuarterList.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlQuarterList.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


        }
        private void BindGrid()
        {
            string CityName, FirmName, ExecutiveName = null;
            string InvestorName = null;

            if (txtSInvestorName.Text.Trim() != "")
                InvestorName = txtSInvestorName.Text.Trim();
            else
                InvestorName = null;

            if (!txtSLocation.Text.Trim().Equals(""))
                CityName = txtSLocation.Text.Trim();
            else
                CityName = null;

            if (!txtSearchChannelPartnerFirm.Text.Trim().Equals(""))
                FirmName = txtSearchChannelPartnerFirm.Text.Trim();
            else
                FirmName = null;

            if (!txtSearchExecutiveName.Text.Trim().Equals(""))
            {
                string[] strExecutiveName = txtSearchExecutiveName.Text.Trim().Split('-');

                if (strExecutiveName.Length > 0)
                    ExecutiveName = Convert.ToString(strExecutiveName[0]).Trim();
                else
                    ExecutiveName = "";
            }
            else
                ExecutiveName = null;

            DataSet dsInvListForRentPayout = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, null, this.QuarterID, true, InvestorName,CityName,FirmName,ExecutiveName);
            if (dsInvListForRentPayout != null && dsInvListForRentPayout.Tables.Count > 0 && dsInvListForRentPayout.Tables[0] != null && dsInvListForRentPayout.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsInvListForRentPayout.Tables[0].Rows.Count; i++)
                {
                    if (i < dsInvListForRentPayout.Tables[0].Rows.Count - 1)
                    {
                        DataRow dr0 = dsInvListForRentPayout.Tables[0].Rows[i];
                        DataRow dr1 = dsInvListForRentPayout.Tables[0].Rows[i + 1];
                        if (Convert.ToString(dr0["FullName"]).ToUpper() == Convert.ToString(dr1["FullName"]).ToUpper() && Convert.ToString(dr0["BankAcctName"]).ToUpper() == Convert.ToString(dr1["BankAcctName"]).ToUpper()
                            && Convert.ToString(dr0["TotalUnit"]).ToUpper() == Convert.ToString(dr1["TotalUnit"]).ToUpper() && Convert.ToString(dr0["TotalSqftForInvestor"]).ToUpper() == Convert.ToString(dr1["TotalSqftForInvestor"]).ToUpper()
                            && Convert.ToString(dr0["TotalRentPayoutByInvestor"]).ToUpper() == Convert.ToString(dr1["TotalRentPayoutByInvestor"]).ToUpper() && Convert.ToString(dr0["AccountNo"]).ToUpper() == Convert.ToString(dr1["AccountNo"]).ToUpper())
                        {
                            dsInvListForRentPayout.Tables[0].Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }

                grdInvestorList.DataSource = dsInvListForRentPayout.Tables[0];
                grdInvestorList.DataBind();
            }
            else
            {
                grdInvestorList.DataSource = dsInvListForRentPayout;
                grdInvestorList.DataBind();
            }
            //DataSet dsInvestorList = InvestorBLL.NewSearchInfo(null, null, null, null, this.CompanyID);
            //if (dsInvestorList != null && dsInvestorList.Tables.Count > 0)
            //{
            //    grdInvestorList.DataSource = dsInvestorList.Tables[0];
            //    grdInvestorList.DataBind();
            //}
            //else
            //{
            //    grdInvestorList.DataSource = dsInvestorList;
            //    grdInvestorList.DataBind();
            //}

        }
        private void ClearDetailControl()
        {
            this.QuarterID = Guid.Empty;
            this.InvestorID = Guid.Empty;
        }
        public void BindRentPayoutGrid()
        {
            DataSet dsForRentPayout = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, this.InvestorID, this.QuarterID, false,null,null,null,null);
            if (dsForRentPayout != null && dsForRentPayout.Tables.Count > 0 && dsForRentPayout.Tables[0] != null && dsForRentPayout.Tables[0].Rows.Count > 0)
            {

                if (dsForRentPayout.Tables[0].Rows[0]["StartDateOfQtr"] != null && Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["StartDateOfQtr"]) != "" && dsForRentPayout.Tables[0].Rows[0]["EndDate"] != null && Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["EndDate"]) != "")
                    litQuarterPeriod.Text = Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["StartDateOfQtr"]) + " to " + Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["EndDate"]);
                else
                    litQuarterPeriod.Text = "";

                if (dsForRentPayout.Tables[0].Rows[0]["QuarterTitle"] != null)
                    litDispQuarterTitle.Text = Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["QuarterTitle"]);
                else
                    litDispQuarterTitle.Text = "";

                decimal TotalSFT = 0;
                decimal TotalYieldAmount = 0;

                TotalSFT = (decimal)dsForRentPayout.Tables[0].Compute("sum(TotalSqft)", "InvName IS NOT NULL");
                TotalYieldAmount = (decimal)dsForRentPayout.Tables[0].Compute("sum(YieldAmount)", "InvName IS NOT NULL");
                dblTotalSqft = TotalSFT;
                dblTotalYieldAmount = TotalYieldAmount;
            }
            gvAdminRendPayoutDetails.DataSource = dsForRentPayout;
            gvAdminRendPayoutDetails.DataBind();

        }

        #endregion Private Method

        #region Control Event
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }
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
            string CityName, FirmName, ExecutiveName = null;
            string InvestorName = null;

            if (txtSInvestorName.Text.Trim() != "")
                InvestorName = txtSInvestorName.Text.Trim();
            else
                InvestorName = null;

            if (!txtSLocation.Text.Trim().Equals(""))
                CityName = txtSLocation.Text.Trim();
            else
                CityName = null;

            if (!txtSearchChannelPartnerFirm.Text.Trim().Equals(""))
                FirmName = txtSearchChannelPartnerFirm.Text.Trim();
            else
                FirmName = null;

            if (!txtSearchExecutiveName.Text.Trim().Equals(""))
            {
                string[] strExecutiveName = txtSearchExecutiveName.Text.Trim().Split('-');

                if (strExecutiveName.Length > 0)
                    ExecutiveName = Convert.ToString(strExecutiveName[0]).Trim();
                else
                    ExecutiveName = "";
            }
            else
                ExecutiveName = null;

            DataSet dsInvListForRentPayout = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, null, this.QuarterID, true,InvestorName,CityName,FirmName,ExecutiveName);

            if (dsInvListForRentPayout.Tables[0].Rows.Count > 0)
            {
                DataTable dt = dsInvListForRentPayout.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["AccountNo"]) != string.Empty)
                    {
                        if (Convert.ToString(dt.Rows[i]["AccountNo"]).Substring(0, 1) == "0" || Convert.ToString(dt.Rows[i]["AccountNo"]).Length > 11)
                        {
                            dt.Rows[i]["AccountNo"] = "#" + Convert.ToString(dt.Rows[i]["AccountNo"]);
                        }
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i < dt.Rows.Count - 1)
                    { 
                        DataRow dr0 = dt.Rows[i];
                        DataRow dr1 = dt.Rows[i+1];
                        if (Convert.ToString(dr0["FullName"]).ToUpper() == Convert.ToString(dr1["FullName"]).ToUpper() && Convert.ToString(dr0["BankAcctName"]).ToUpper() == Convert.ToString(dr1["BankAcctName"]).ToUpper()
                            && Convert.ToString(dr0["TotalUnit"]).ToUpper() == Convert.ToString(dr1["TotalUnit"]).ToUpper() && Convert.ToString(dr0["TotalSqftForInvestor"]).ToUpper() == Convert.ToString(dr1["TotalSqftForInvestor"]).ToUpper()
                            && Convert.ToString(dr0["TotalRentPayoutByInvestor"]).ToUpper() == Convert.ToString(dr1["TotalRentPayoutByInvestor"]).ToUpper() && Convert.ToString(dr0["AccountNo"]).ToUpper() == Convert.ToString(dr1["AccountNo"]).ToUpper())
                        {
                            dt.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }

                string filename = "InvestorRentPayout_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }


            //this.IsPreview = false;
            //Session.Add("ExportMode", "XLSX");
            //LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlQuarterList.SelectedIndex > 0)
                {
                    this.QuarterID = new Guid(ddlQuarterList.SelectedValue);
                    BindGrid();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Please select any Quarter");
                    return;
                }
                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnBackToList_Click(object sender, EventArgs e)
        {

            BindGrid();
            ClearDetailControl();
            mvRentPayout.ActiveViewIndex = 0;
        }
        #endregion Control Event

        #region Grid Event
        protected void gvAdminRendPayoutDetails_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Literal litTotalSFT = (Literal)e.Row.FindControl("litTotalSFT");
                Literal litTotalYieldAmount = (Literal)e.Row.FindControl("litTotalYieldAmount");

                if (litTotalSFT != null)
                {
                    litTotalSFT.Text = Convert.ToString(dblTotalSqft.ToString().Substring(0, dblTotalSqft.ToString().LastIndexOf(".") + 1 + 2));
                }
                if (litTotalYieldAmount != null)
                {
                    litTotalYieldAmount.Text = Convert.ToString(dblTotalYieldAmount.ToString().Substring(0, dblTotalYieldAmount.ToString().LastIndexOf(".") + 1 + 2));
                }

            }
        }
        protected void grdInvestorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("GETRENTPAYOUTDETAILS") && e.CommandArgument != null)
                {
                    if (ddlQuarterList.SelectedIndex > 0)
                    {
                        ClearDetailControl();
                        this.QuarterID = new Guid(ddlQuarterList.SelectedValue);
                        this.InvestorID = new Guid(e.CommandArgument.ToString());
                        BindRentPayoutGrid();

                        mvRentPayout.ActiveViewIndex = 1;
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Please select any Quarter");
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //LinkButton lnkBtn = (LinkButton)e.Row.FindControl("lnkBtn");
                    //lnkBtn.OnClientClick = "fnDisplayCatchErrorMessage()";
                    Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));


                    if (litMobileNo != null)
                    {
                        if (Convert.ToString(strMobileNo) != "")
                            litMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                        else
                            litMobileNo.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdInvestorList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInvestorList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event
    }
}