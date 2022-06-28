using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlLoginLog : System.Web.UI.UserControl
    {
        #region Variable and Property

        public string strClearDateTooltip
        {
            get
            {
                return ViewState["strClearDateTooltip"] != null ? Convert.ToString(ViewState["strClearDateTooltip"]) : string.Empty;
            }
            set
            {
                ViewState["strClearDateTooltip"] = value;
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

                CheckUserAuthorization();
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "LOGINLOG.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");
        }

        private void BindData()
        {
            try
            {
                SetPageLabels();
                ajxCalendarLogInLog.Format = clsSession.DateFormat;
                txtSearchDate.Attributes.Add("autocomplete", "off");
                BindUserName();
                BindGrid();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSettiongs", "User Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblLoginLog", "LoginLog");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("LoginLog", "lblMainHeader", "LOGIN LOG");
            litSearchUserName.Text = clsCommon.GetGlobalResourceText("LoginLog", "lblSearchUserName", "UserName");
            litSearchDate.Text = clsCommon.GetGlobalResourceText("LoginLog", "lblSearchDate", "Date");
            litLoginLogList.Text = clsCommon.GetGlobalResourceText("LoginLog", "lblLoginLogList", "LogIn Log List");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            this.strClearDateTooltip = clsCommon.GetGlobalResourceText("Common", "lblTltpClearDate", "Clear Date");
            imgCalendarActionLog.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpChooseDate", "Choose Date");
        }

        /// <summary>
        /// Bind Grid Method
        /// </summary>
        private void BindGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                Guid? UserID;
                DateTime? Date;
                if (ddlSearchUserName.SelectedValue != Guid.Empty.ToString())
                    UserID = new Guid(Convert.ToString(ddlSearchUserName.SelectedValue));
                else
                    UserID = null;

                if (txtSearchDate.Text.Trim() != "")
                    Date = DateTime.ParseExact(txtSearchDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                else
                    Date = null;

                DataSet dsLogInLog = LoginLogBLL.SearchLogInLogDataForSymphony(null, UserID, Date, clsSession.CompanyID, clsSession.PropertyID, clsSession.UserType);
                gvLogInLogList.DataSource = dsLogInLog.Tables[0];
                gvLogInLogList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind UserName
        /// </summary>
        private void BindUserName()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-");

            DataSet dsUsers = UserBLL.UserGetAllByRoleTypeHierarchy(clsSession.UserType.ToUpper(), clsSession.CompanyID, clsSession.PropertyID);
            if (dsUsers != null && dsUsers.Tables[0].Rows.Count > 0)
            {
                ddlSearchUserName.DataSource = dsUsers.Tables[0];
                ddlSearchUserName.DataTextField = "UserName";
                ddlSearchUserName.DataValueField = "UsearID";
                ddlSearchUserName.DataBind();
                ddlSearchUserName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlSearchUserName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            ddlSearchUserName.SelectedIndex = 0;
            txtSearchDate.Text = "";
        }
        #endregion Method

        #region  Grid Event
        protected void gvLogInLogList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrUserName")).Text = clsCommon.GetGlobalResourceText("LoginLog", "lblGvHdrUserName", "User Name");
                    ((Label)e.Row.FindControl("lblGvHdrLogIn")).Text = clsCommon.GetGlobalResourceText("LoginLog", "lblGvHdrLogIn", "LogIn Date");
                    ((Label)e.Row.FindControl("lblGvHdrLogout")).Text = clsCommon.GetGlobalResourceText("LoginLog", "lblGvHdrLogout", "Logout Date");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvLogInLogList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvLogInLogList.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Control Event

        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvLogInLogList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event
    }
}