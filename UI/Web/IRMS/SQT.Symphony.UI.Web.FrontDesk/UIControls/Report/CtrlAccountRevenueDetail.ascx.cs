using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.UI.Web.FrontDesk.ReportFiles.GDI;
using System.Drawing;
using System.Globalization;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Collections;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using bkof = SQT.Symphony.BusinessLogic.BackOffice.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlAccountRevenueDetail : System.Web.UI.UserControl
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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadControl();
            }
        }

        private void LoadControl()
        {
            try
            {
                //if (Session["PropertyConfigurationInfo"] != null)
                //{
                //    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                //    ProjectTerm objProjectTerm = new ProjectTerm();
                //    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                //    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                //    if (objProjectTerm != null)
                //    {
                //        calStartDate.Format = objProjectTerm.Term;
                //        this.DateFormat = objProjectTerm.Term;
                //    }
                //    else
                //    {
                //        calStartDate.Format = "dd/MM/yyyy";
                //        this.DateFormat = "dd/MM/yyyy";
                //    }
                //}
                //else
                //{
                    calStartDate.Format = "dd-MM-yyyy";
                    this.DateFormat = "dd-MM-yyyy";
                //}                
                txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                BindAccountGroup();
                ddlAcctGroup_SelectedIndexChanged(null, null);
                ddlPeriod.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindAccountGroup()
        {
            ddlAcctGroup.DataSource = bkof.AccountGroupBLL.GetAll();
            ddlAcctGroup.DataValueField = "SymphonyGroupID";
            ddlAcctGroup.DataTextField = "GroupName";
            ddlAcctGroup.DataBind();
            ddlAcctGroup.Items.Insert(0, new ListItem("-ALL-", "-1"));
        }
        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                int? iAcctGrpID = null;
                Guid? iAcctID = null;
                if (!ddlAcctGroup.SelectedValue.Equals("") && ddlAcctGroup.SelectedValue != "-1")                    
                    iAcctGrpID = Convert.ToInt32(ddlAcctGroup.SelectedValue);

                if (!ddlAccountName.SelectedValue.Equals("") && !ddlAccountName.SelectedValue.Equals("-1"))
                    iAcctID = new Guid(Convert.ToString(ddlAccountName.SelectedValue));

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                int StartDay = System.DateTime.Now.Day;
                int StartMonth = System.DateTime.Now.Month;
                int StartYear = System.DateTime.Now.Year;

                string STR = "", Title = "";
                ArrayList arlGroup = new ArrayList();
                DateTime StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo).AddDays(-1);
                DateTime EndDate = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (ddlPeriod.Text.Trim().Equals("DAILY"))
                {
                    StartDate = EndDate.AddDays(-7);
                    STR = StartDate.Day.ToString() + "/" + StartDate.Month.ToString() + "/" + StartDate.Year.ToString();
                }
                else if (ddlPeriod.Text.Trim().Equals("WEEKLY"))
                {
                    int DaysToSubtract;
                    if (EndDate.DayOfWeek == DayOfWeek.Sunday)
                        DaysToSubtract = 7;
                    else
                        DaysToSubtract = (int)EndDate.DayOfWeek;

                    DateTime dt = EndDate.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
                    StartDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                    STR = StartDate.Date.AddDays(-20).Day.ToString() + "/" + StartDate.Date.AddDays(-20).Month.ToString() + "/" + StartDate.Date.AddDays(-20).Year.ToString();
                }
                else if (ddlPeriod.Text.Trim().Equals("MONTHLY"))
                {
                    StartDate = EndDate.AddMonths(-11);
                    STR = "1" + "/" + StartDate.Month.ToString() + "/" + StartDate.Year.ToString();
                }
                else if (ddlPeriod.Text.Trim().Equals("YEARLY"))
                {
                    StartYear = EndDate.Year - 5;
                    STR = StartDay.ToString() + "/" + StartMonth.ToString() + "/" + StartYear.ToString();
                }
                StartDate = DateTime.ParseExact(STR, "d/M/yyyy", null);
                if (ddlPeriod.Text.Trim().Equals("WEEKLY"))
                    Title = "ACCOUNT REVENUE " + ddlPeriod.Text.Trim() + " CHART";// FOR LAST 4 WEEK";
                else if (ddlPeriod.Text.Trim().Equals("MONTHLY"))
                    Title = "ACCOUNT REVENUE " + ddlPeriod.Text.Trim() + " CHART";// FOR LAST 12 MONTH";
                else if (ddlPeriod.Text.Trim().Equals("YEARLY"))
                    Title = "ACCOUNT REVENUE " + ddlPeriod.Text.Trim() + " CHART";// FOR LAST 6 YEAR";
                else
                    Title = "ACCOUNT REVENUE " + ddlPeriod.Text.Trim() + " CHART : " + StartDate.Date.ToString(clsSession.DateFormat) + " TO " + EndDate.Date.ToString(clsSession.DateFormat);

                DataView dv = new DataView(AccountBLL.GetRPTAccountRevenue(clsSession.CompanyID, clsSession.PropertyID, iAcctGrpID, iAcctID, ddlPeriod.Text.Trim(),StartDate,EndDate).Tables[0]);
                dv.Sort = "AcctName";
                dv.RowFilter = "Total>0";
                if (dv.Count > 0)
                {
                    clsTableInfo.Clear();
                    clsTableInfo colrr0 = new clsTableInfo("AcctName", "Account", "string", 120, StringAlignment.Near);
                    clsTableInfo colrr1;
                    if (ddlPeriod.Text.Trim().Equals("DAILY"))
                        colrr1 = new clsTableInfo("Total", "Total", "Double", 50, StringAlignment.Far, true);
                    else
                        colrr1 = new clsTableInfo("Total", "Total", "Double", 50, StringAlignment.Far, true);

                    List<clsTableInfo> arr2 = new List<clsTableInfo>();
                    for (int i = 5; i < dv.Table.Columns.Count; i++)
                    {
                        string newstr = dv.Table.Columns[i].ToString();

                        clsTableInfo s;
                        clsTableInfo space;
                        if (ddlPeriod.Text.Trim().Equals("DAILY"))
                        {
                            string tmpst = newstr.Remove(newstr.LastIndexOf('/'), newstr.Length - newstr.LastIndexOf('/'));
                            s = new clsTableInfo(newstr, tmpst, "Double", 50, StringAlignment.Far, true);
                        }
                        else if (ddlPeriod.Text.Trim().Equals("MONTHLY"))
                        {
                            string strmntyer = newstr.Remove(newstr.LastIndexOf("To"), newstr.Length - newstr.LastIndexOf("To")).Trim();
                            DateTime dttmp = new DateTime(Convert.ToInt32(strmntyer.Substring(6, 4)), Convert.ToInt32(strmntyer.Substring(3, 2)), Convert.ToInt32(strmntyer.Substring(0, 2)));
                            s = new clsTableInfo(newstr, dttmp.ToString("MMM-yy"), "Double", 50, StringAlignment.Far, true, StringAlignment.Far);
                        }
                        else
                            s = new clsTableInfo(newstr, newstr, "Double", 60, StringAlignment.Far, true, StringAlignment.Center);

                        //if (ddlPeriod.Text.Trim().Equals("WEEKLY"))
                        //{
                        //    space = new clsTableInfo("", "", " ", 5, StringAlignment.Center);
                        //    arr2.Add(space);
                        //}
                        //else if (ddlPeriod.Text.Trim().Equals("YEARLY"))
                        //{
                        //    space = new clsTableInfo("", "", " ", 5, StringAlignment.Center);
                        //    arr2.Add(space);
                        //}
                        arr2.Add(s);
                    }
                    clsTableInfo.Add(colrr0);
                    for (int k = 0; k < arr2.Count; k++)
                        clsTableInfo.Add(arr2[k]);
                    clsTableInfo.Add(colrr1);
                    PrintReportGeneralDV objReportDV = null;
                    if (ddlPeriod.Text.Trim().Equals("MONTHLY"))
                        objReportDV = new PrintReportGeneralDV(dv, true, clsTableInfo.GetList(), arlGroup, Title);
                    else
                        objReportDV = new PrintReportGeneralDV(dv, false, clsTableInfo.GetList(), arlGroup, Title);
                    objReportDV.FontSize = 6F;
                    objReportDV.isForRoomRev = true;
                    objReportDV.PrintReport();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("There is No Records");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {          
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {         
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {            
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void ddlAcctGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAcctGroup.SelectedIndex != -1)
            {
                ddlAccountName.DataSource = bkof.AccountBLL.GetAllBy(BusinessLogic.BackOffice.DTO.Account.AccountFields.SymphonyAcctGroupID, Convert.ToString(ddlAcctGroup.SelectedValue));
                ddlAccountName.DataValueField = "AcctID";
                ddlAccountName.DataTextField = "AcctName";
                ddlAccountName.DataBind();
                ddlAccountName.Items.Insert(0, new ListItem("-ALL-", "-1"));
            }
            else
            {
                ddlAccountName.DataSource = bkof.AccountBLL.GetAllDataSet(null, clsSession.PropertyID, clsSession.CompanyID, null, null, null);
                ddlAccountName.DataValueField = "AcctID";
                ddlAccountName.DataTextField = "AcctName";
                ddlAccountName.DataBind();
                ddlAccountName.Items.Insert(0, new ListItem("-ALL-", "-1"));
            }
        }
    }
}