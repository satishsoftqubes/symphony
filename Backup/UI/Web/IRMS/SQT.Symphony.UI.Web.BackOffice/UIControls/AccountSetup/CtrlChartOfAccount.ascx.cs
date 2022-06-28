using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.BackOffice.BLL;
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using System.Drawing;
using System.Globalization;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup
{
    public partial class CtrlChartOfAccount : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsInsert = false;

        public bool? IsPreview = false;
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
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");
                CheckUserAuthorization();
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                LoadDefaultValue();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ChartOfAccount.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddUp.Visible = btnAdd.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            dr2["Link"] = "~/GUI/AccountsHome.aspx";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Ledger Acct. Setup";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccountGroupSetup", "Account Group");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            try
            {
                DataView DV = SQT.Symphony.BusinessLogic.Configuration.BLL.RoleRightJoinBLL.GetIUDVAccess("ChartOfAccount.aspx", new Guid(Convert.ToString(Session["UserID"])));
                if (DV.Count > 0)
                {

                    ViewState["Delete"] = true; //Convert.ToBoolean(DV[0]["IsDelete"]);
                    ViewState["Edit"] = true; // Convert.ToBoolean(DV[0]["IsUpdate"]);
                    btnAdd.Visible = btnAddUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                }
                else
                    Response.Redirect("~/Applications/AccessDenied.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                LoadDDL();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadDDL()
        {
            ddlSGroup.DataSource = AccountGroupBLL.GetAll();
            ddlSGroup.DataValueField = "AcctGrpID";
            ddlSGroup.DataTextField = "GroupName";
            ddlSGroup.DataBind();
            ddlSGroup.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            string AccountName = null;
            Guid? GrpID = null;

            if (ddlSGroup.SelectedValue != Guid.Empty.ToString())
                GrpID = new Guid(Convert.ToString(ddlSGroup.SelectedValue));
            else
                GrpID = null;

            if (hfSelectedAlphabet.Value.ToString() != string.Empty)
            {
                if (hfSelectedAlphabet.Value.ToString() != "ALL")
                    AccountName = hfSelectedAlphabet.Value.ToString();
                else
                    AccountName = null;

                hfSelectedAlphabet.Value = string.Empty;
            }
            else
            {
                if (txtSearchAccountName.Text.Trim() != "")
                    AccountName = txtSearchAccountName.Text.Trim();
                else
                    AccountName = null;
            }

            if (txtSearchAccountName.Text.Trim() != "")
                AccountName = Convert.ToString(txtSearchAccountName.Text.Trim());
            else
                AccountName = null;

            DataSet Dst = new DataSet();

            Dst = AccountBLL.GetAllDataSet(null, null, CompanyID, GrpID, null, AccountName);
            DataView dv = new DataView(Dst.Tables[0]);
            dv.Sort = "AcctName ASC";
            grdAccountList.DataSource = dv;
            grdAccountList.DataBind();

            litAccountCount.Text = "(" + Convert.ToString(Dst.Tables[0].Rows.Count) + ")";
        }

        /// <summary>
        /// Load Report Control Value
        /// </summary>
        private void LoadReportControlValue()
        {
            try
            {
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    SQT.Symphony.BusinessLogic.Configuration.DTO.PropertyConfiguration objPropertyConfiguration = (SQT.Symphony.BusinessLogic.Configuration.DTO.PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    SQT.Symphony.BusinessLogic.Configuration.DTO.ProjectTerm objProjectTerm = new SQT.Symphony.BusinessLogic.Configuration.DTO.ProjectTerm();
                    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                    objProjectTerm = SQT.Symphony.BusinessLogic.Configuration.BLL.ProjectTermBLL.GetByPrimaryKey(TermID);

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
                txtEndDate.Text = txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                BindCounter();
                BindUser();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Counter
        /// </summary>
        private void BindCounter()
        {
            SQT.Symphony.BusinessLogic.Configuration.DTO.Counters objCnt = new SQT.Symphony.BusinessLogic.Configuration.DTO.Counters();
            objCnt.CompanyID = clsSession.CompanyID;
            objCnt.PropertyID = clsSession.PropertyID;
            objCnt.IsActive = true;

            List<SQT.Symphony.BusinessLogic.Configuration.DTO.Counters> LstCnt = SQT.Symphony.BusinessLogic.Configuration.BLL.CountersBLL.GetAll(objCnt);
            if (LstCnt.Count > 0)
            {
                LstCnt.Sort((SQT.Symphony.BusinessLogic.Configuration.DTO.Counters c1, SQT.Symphony.BusinessLogic.Configuration.DTO.Counters c2) => c1.CounterNo.CompareTo(c2.CounterNo));
                ddlCounter.DataSource = LstCnt;
                ddlCounter.DataTextField = "CounterNo";
                ddlCounter.DataValueField = "CounterID";
                ddlCounter.DataBind();
                ddlCounter.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlCounter.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Cashier
        /// </summary>
        private void BindUser()
        {
            SQT.Symphony.BusinessLogic.Configuration.DTO.User objUsr = new SQT.Symphony.BusinessLogic.Configuration.DTO.User();
            objUsr.CompanyID = clsSession.CompanyID;
            objUsr.PropertyID = clsSession.PropertyID;
            objUsr.IsActive = true;
            ddlUser.DataSource = SQT.Symphony.BusinessLogic.Configuration.BLL.UserBLL.GetAllWithDataSet(objUsr);
            ddlUser.DataTextField = "UserName";
            ddlUser.DataValueField = "UsearID";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport(Guid AcctID)
        {
            try
            {
                Session.Add("ReportName", "Account Statement");
                DataSet ds = new DataSet();
                Guid? iCntID = null;
                Guid? iUserID = null;
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;


                if (!ddlCounter.SelectedValue.Equals(Guid.Empty.ToString()))
                    iCntID = (Guid?)new Guid(Convert.ToString(ddlCounter.SelectedValue));
                if (!ddlUser.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlUser.SelectedValue.Equals("")))
                    iUserID = (Guid?)new Guid(Convert.ToString(ddlUser.SelectedValue));
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }
                if (!ddlCounter.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("RptCounter", ddlCounter.SelectedItem.Text);
                if (!ddlUser.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlUser.SelectedValue.Equals("")))
                    Session.Add("RptUser", ddlUser.SelectedItem.Text);
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);

                ds = AccountBLL.GetRPTLedgerStatement(AcctID, clsSession.PropertyID, clsSession.CompanyID, iUserID, iCntID, null, null, startdt, enddt);
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
                ViewState["AccountID"] = null;
                mpeStatement.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Add New
        /// <summary>
        /// Add New Channel Partner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/GUI/AccountSetup/AccountSetUp.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Add New

        #region Grid Event
        /// <summary>
        /// Row Data Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdAccountList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    Session["AccountID"] = e.CommandArgument.ToString();
                    clsSession.ToEditItemID = new Guid(e.CommandArgument.ToString());
                    clsSession.ToEditItemType = "ACCOUNT";
                    Response.Redirect("~/GUI/AccountSetup/AccountSetUp.aspx");
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {


                    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                    Label lblCurrBalance = (Label)row.FindControl("lblCurrBalance");
                    if (lblCurrBalance != null && Convert.ToString(lblCurrBalance.Text) != string.Empty)
                    {
                        if (Convert.ToDecimal(Convert.ToString(lblCurrBalance.Text)) > 0)
                            MessageBox.Show("This account's current balance is not 0, you can't delete this account.");
                        else
                        {
                            Account GetAcc = AccountBLL.GetByPrimaryKey(new Guid(e.CommandArgument.ToString()));
                            if (!Convert.ToBoolean(GetAcc.IsDefaultAccount))
                            {
                                lblErrorMessage.Text = "Are you sure you want to delete this record?"; //global::Resources.BackOfficeMsg.DeleteWarMsg.ToString().Trim();
                                ViewState["AccountID"] = e.CommandArgument.ToString();
                                mepConfirmDelete.Show();
                            }
                            else
                                MessageBox.Show("This is default account, you can't delete this account.");
                        }
                    }
                }
                else if (e.CommandName.Equals("RPTCMD"))
                {
                    ViewState["AccountID"] = e.CommandArgument.ToString();
                    Account acct = AccountBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["AccountID"])));
                    LoadReportControlValue();
                    litHeading.Text = "Statement Of " + acct.AcctNo + " - " + acct.AcctName;
                    Session.Add("AcctNm", acct.AcctNo + " - " + acct.AcctName);
                    mpeStatement.Show();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdAccountList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAccountList.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdAccountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    //if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    //    e.Row.Cells[7].Text = "View/Edit";
                    //else if (Convert.ToBoolean(ViewState["View"]) == true)
                    //    e.Row.Cells[7].Text = "View";
                    //e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["View"]);
                    //e.Row.Cells[8].Visible = Convert.ToBoolean(ViewState["Delete"]);

                    e.Row.Cells[7].Visible = true; // Convert.ToBoolean(ViewState["Delete"]);
                    e.Row.Cells[6].Visible = false;
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                    
                    //ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");
                    DelImg.Visible = this.UserRights.Substring(3, 1) == "1";
                    //EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    

                    //if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    //    EditImg.ToolTip = "View/Edit";
                    //else if (Convert.ToBoolean(ViewState["View"]) == true)
                    //    EditImg.ToolTip = "View";
                    //e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["View"]);
                    //e.Row.Cells[8].Visible = Convert.ToBoolean(ViewState["Delete"]);

                    e.Row.Cells[7].Visible = true; // Convert.ToBoolean(ViewState["Delete"]);

                    if (!e.Row.Cells[6].Text.Equals(""))
                    {
                        if (Convert.ToBoolean(e.Row.Cells[6].Text))
                            e.Row.ForeColor = Color.Blue;
                    }
                    e.Row.Cells[6].Visible = false;
                    //if(!e.Row.Cells[5].Text.Equals(""))
                    //{
                    //    if (Convert.ToDecimal(e.Row.Cells[5].Text) < 0)
                    //    {
                    //        e.Row.Cells[5].Text = e.Row.Cells[5].Text.ToString().Substring(0, e.Row.Cells[5].Text.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    //        e.Row.ForeColor = Color.Red;
                    //    }
                    //}

                    Label lblCurrBalance = (Label)e.Row.FindControl("lblCurrBalance");
                    decimal dcmlBalance = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CurrentBalance"));
                    lblCurrBalance.Text = dcmlBalance.ToString().Substring(0, dcmlBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));


                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    //if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    //    e.Row.Cells[7].Text = "View/Edit";
                    //else if (Convert.ToBoolean(ViewState["View"]) == true)
                    //    e.Row.Cells[8].Text = "View";
                    //e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["View"]);
                    //e.Row.Cells[8].Visible = Convert.ToBoolean(ViewState["Delete"]);
                    e.Row.Cells[7].Visible = true; // Convert.ToBoolean(ViewState["Delete"]);
                    e.Row.Cells[6].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Popup Button Event
        protected void btnDeleteCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                ViewState["AccountID"] = null;
                mepConfirmDelete.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnDeleteOK_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["AccountID"] != null)
                {
                    Account GetAcc = AccountBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["AccountID"])));
                    AccountBLL.Delete(new Guid(Convert.ToString(ViewState["AccountID"])));
                    IsInsert = true;
                    lblAccountMsg.Text = global::Resources.BackOfficeMsg.DeleteMsg.ToString().Trim();
                    ViewState["AccountID"] = null;
                    SQT.Symphony.BusinessLogic.Configuration.BLL.ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetAcc.ToString(), null, "acc_Account");
                    mepConfirmDelete.Hide();
                }
                LoadDefaultValue();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport(new Guid(Convert.ToString(ViewState["AccountID"])));
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport(new Guid(Convert.ToString(ViewState["AccountID"])));
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport(new Guid(Convert.ToString(ViewState["AccountID"])));
        }
        #endregion Popup Button Event

        #region Button Event
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkAlphabet_OnClick(object sender, EventArgs e)
        {
            try
            {
                txtSearchAccountName.Text = string.Empty;
                ddlSGroup.SelectedIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event
    }
}