using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlCheckInLog : System.Web.UI.UserControl
    {
        #region Property and variables

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
        int totalSeconds = 0;
        #endregion
         
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                BindFDExecutive();
                BindGrid();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CheckInLog.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void BindFDExecutive()
        {
            try
            {
                DataSet dsUsers = UserBLL.UserGetAllByRoleTypeHierarchy(clsSession.UserType.ToUpper(), clsSession.CompanyID, clsSession.PropertyID);
                if (dsUsers != null && dsUsers.Tables[0].Rows.Count > 0)
                {
                    ddlSearchFDExecutive.DataSource = dsUsers.Tables[0];
                    ddlSearchFDExecutive.DataTextField = "UserName";
                    ddlSearchFDExecutive.DataValueField = "UsearID";
                    ddlSearchFDExecutive.DataBind();
                    ddlSearchFDExecutive.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlSearchFDExecutive.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

                ddlSearchFDExecutive.SelectedIndex = ddlSearchFDExecutive.Items.FindByValue(Convert.ToString(clsSession.UserID)) != null ? ddlSearchFDExecutive.Items.IndexOf(ddlSearchFDExecutive.Items.FindByValue(Convert.ToString(clsSession.UserID))) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime? dtCheckInDate = null;
                DateTime? dtCheckoutDate = null;
                Guid? fdExecutiveID = null;

                if (txtSearchFromDate.Text.Trim() != "")
                    dtCheckInDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (txtSearchToDate.Text.Trim() != "")
                    dtCheckoutDate = DateTime.ParseExact(txtSearchToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (ddlSearchFDExecutive.SelectedIndex != 0)
                    fdExecutiveID = new Guid(ddlSearchFDExecutive.SelectedValue);

                DataSet dsCheckinTimeLog = CheckinTimeLogBLL.SelectCheckInLog(dtCheckInDate, dtCheckoutDate, fdExecutiveID, clsSession.PropertyID, clsSession.CompanyID);
                if (dsCheckinTimeLog != null && dsCheckinTimeLog.Tables.Count > 0 && dsCheckinTimeLog.Tables[0].Rows.Count > 0)
                {
                    gvCheckInLog.DataSource = dsCheckinTimeLog.Tables[0];
                    gvCheckInLog.DataBind();

                    int avgTimeTakenInSeconds = totalSeconds / gvCheckInLog.Rows.Count;
                    int actualMinutes = avgTimeTakenInSeconds / 60;
                    int actualSeconds = avgTimeTakenInSeconds - (actualMinutes * 60);

                    ltrAverageTimeTaken.Text = actualMinutes.ToString() + "m " + actualSeconds.ToString() + "s";
                }
                else
                {
                    gvCheckInLog.DataSource = null;
                    gvCheckInLog.DataBind();
                    ltrAverageTimeTaken.Text = "--";
                }
            }
            catch (Exception ex)
            {
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

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Check In";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);



            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Check In Log";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Control Events
        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime? dtCheckInDate = null;
                DateTime? dtCheckoutDate = null;
                Guid? fdExecutiveID = null;

                if (txtSearchFromDate.Text.Trim() != "")
                    dtCheckInDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (txtSearchToDate.Text.Trim() != "")
                    dtCheckoutDate = DateTime.ParseExact(txtSearchToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (ddlSearchFDExecutive.SelectedIndex != 0)
                    fdExecutiveID = new Guid(ddlSearchFDExecutive.SelectedValue);

                Session["CheckInDate"] = dtCheckInDate;
                Session["CheckoutDate"] = dtCheckoutDate;
                Session["ExecutiveID"] = fdExecutiveID;

                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnCheckinlogPrint();", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        #endregion

        #region Grid Event
        protected void gvCheckInLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int timeTakenInSeconds = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TotalSeconds")));

                    int actualMinutes = timeTakenInSeconds / 60;
                    int actualSeconds = timeTakenInSeconds - (actualMinutes * 60);

                    totalSeconds = totalSeconds + timeTakenInSeconds;

                    ((Literal)e.Row.FindControl("ltrTimetaken")).Text = actualMinutes.ToString() + "m " + actualSeconds.ToString() + "s";
                    
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //protected void gvCheckInLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvCheckInLog.PageIndex = e.NewPageIndex;
        //    BindGrid();
        //}
        
        #endregion
    }
}