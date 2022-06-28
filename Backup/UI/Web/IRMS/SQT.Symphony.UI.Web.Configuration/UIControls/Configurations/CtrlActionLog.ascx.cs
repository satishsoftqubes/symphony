using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlActionLog : System.Web.UI.UserControl
    {

        #region Variable and Property

        public bool IsListMessage = false;

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

        #region Form Load

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

        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ACTIONLOG.ASPX");
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
                ajxCalendarActionLog.Format = clsSession.DateFormat;
                txtSearchActionDate.Attributes.Add("autocomplete", "off");
                BindUserName();
                BindGrid();
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblActionLog", "ActionLog");
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
            litMainHeader.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblMainHeader", "ACTION LOG");
            litSearchActionDate.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblSearchActionDate", "Date");
            litSearchActionType.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblSearchActionType", "Action Type");
            litActionLogList.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblActionLogList", "Action Log List");
            litHeaderGvMsg.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblHeaderGvMsg", "Action Log");
            btnClose.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblClose", "Close");
            //lblActionLog.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblActionLog", "Action Log");
            litSearchActionObject.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblSearchActionObject", "Action Object");
            litSearchUserName.Text = clsCommon.GetGlobalResourceText("ActionLog", "lblSearchUserName", "UserName");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            this.strClearDateTooltip = clsCommon.GetGlobalResourceText("Common", "lblTltpClearDate", "Clear Date");
            imgCalendarActionLog.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpChooseDate", "Choose Date");
        }

        /// <summary>
        /// Bind Grid Method Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                this.DateFormat = Convert.ToString(clsSession.DateFormat) + ' ' + Convert.ToString(clsSession.TimeFormat);
                DateTime? Date;
                string ActionType, ActionObject = null;
                Guid? ActionPerformedBy;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (txtSearchActionDate.Text.Trim() != "")
                    Date = DateTime.ParseExact(txtSearchActionDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                else
                    Date = null;
                if (ddlSearchActionType.SelectedValue != Guid.Empty.ToString())
                    ActionType = Convert.ToString(ddlSearchActionType.SelectedValue);
                else
                    ActionType = null;
                if (txtSearchActionObject.Text.Trim() != "")
                    ActionObject = txtSearchActionObject.Text.Trim();
                else
                    ActionObject = null;
                if (ddlSearchUserName.SelectedValue != Guid.Empty.ToString())
                    ActionPerformedBy = new Guid(ddlSearchUserName.SelectedValue);
                else
                    ActionPerformedBy = null;

                //DataSet dsActionLogData = ActionLogBLL.ActionLogSearchData(null, ActionPerformedBy, Date, ActionObject, ActionType);
                DataSet dsActionLogData = ActionLogBLL.ActionLogSymphonySearchData(null, ActionPerformedBy, Date, ActionObject, ActionType, clsSession.UserType, clsSession.CompanyID, clsSession.PropertyID, clsSession.UserID);
                gvActionLogList.DataSource = dsActionLogData;
                gvActionLogList.DataBind();
            }
            catch (Exception ex)
            {
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
            txtSearchActionDate.Text = txtSearchActionObject.Text = "";
            ddlSearchActionType.SelectedIndex = ddlSearchUserName.SelectedIndex = 0;
        }
        #endregion Private Method

        #region Grid Event

        protected void gvActionLogList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrActionType")).Text = clsCommon.GetGlobalResourceText("ActionLog", "lblGvHdrActionType", "Action Type");
                    ((Label)e.Row.FindControl("lblGvHdrActionObject")).Text = clsCommon.GetGlobalResourceText("ActionLog", "lblGvHdrActionObject", "Action Object");
                    ((Label)e.Row.FindControl("lblGvHdrActionPerformedOn")).Text = clsCommon.GetGlobalResourceText("ActionLog", "lblGvHdrActionPerformedOn", "Date");
                    ((Label)e.Row.FindControl("lblGvHdrUser")).Text = clsCommon.GetGlobalResourceText("ActionLog", "lblGvHdrUser", "UserName");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
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

        protected void gvActionLogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("VIEWDATA"))
                {
                    mpeConfirmDelete.Show();

                    string strID = Convert.ToString(e.CommandArgument);
                    string[] strDataID = Convert.ToString(strID).Split(new char[] { '|' });


                    string strColumnQuery = "SELECT column_name 'ColumnName',data_type 'DataType'FROM information_schema.columns WHERE table_name = '" + Convert.ToString(strDataID[1]) + "'";
                    DataSet dsColumn = RoomBLL.GetUnitNo(strColumnQuery);

                    DataSet dsLoadData = ActionLogBLL.GetAllByWithDataSet(ActionLog.ActionLogFields.ActionLogID, Convert.ToString(strDataID[0]));

                    string strOldValue = Convert.ToString(dsLoadData.Tables[0].Rows[0]["ObjectOldValue"]);
                    string strNewValue = Convert.ToString(dsLoadData.Tables[0].Rows[0]["ObjectNewValue"]);

                    string[] strOld = Convert.ToString(strOldValue.Trim('~')).Split(new char[] { '~' });
                    string[] strNew = Convert.ToString(strNewValue.Trim('~')).Split(new char[] { '~' });

                    DataTable dtData = new DataTable();

                    DataColumn dc1 = new DataColumn("ColumnName");
                    DataColumn dc2 = new DataColumn("OldValue");
                    DataColumn dc3 = new DataColumn("NewValue");

                    dtData.Columns.Add(dc1);
                    dtData.Columns.Add(dc2);
                    dtData.Columns.Add(dc3);

                    for (int i = 0; i < dsColumn.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = dtData.NewRow();

                        dr["ColumnName"] = Convert.ToString(dsColumn.Tables[0].Rows[i]["ColumnName"]);
                        string strDataType = Convert.ToString(dsColumn.Tables[0].Rows[i]["DataType"]);

                        if (strDataType != "uniqueidentifier" && Convert.ToString(dr["ColumnName"]).ToUpper() != "UPDATELOG")
                        {
                            if (strOld.Length > 0)
                            {
                                try
                                {
                                    string strCheckOldValue = Convert.ToString(strOld.GetValue(i));

                                    if (strCheckOldValue != string.Empty)
                                    {
                                        string[] strDisplayOldValue = Convert.ToString(strOld[i].Trim()).Split(new char[] { '=' });

                                        if (strDisplayOldValue.Length > 1)
                                            dr["OldValue"] = Convert.ToString(strDisplayOldValue[1]);
                                        else
                                            dr["OldValue"] = "";
                                    }
                                    else
                                        dr["OldValue"] = "";
                                }
                                catch
                                {
                                    dr["OldValue"] = "";
                                }
                            }
                            else
                                dr["OldValue"] = "";

                            if (strNew.Length > 0)
                            {
                                try
                                {
                                    string strCheckNewValue = Convert.ToString(strNew.GetValue(i));

                                    if (strCheckNewValue != string.Empty)
                                    {
                                        string[] strDisplayNewValue = Convert.ToString(strNew[i].Trim()).Split(new char[] { '=' });

                                        if (strDisplayNewValue.Length > 1)
                                            dr["NewValue"] = Convert.ToString(strDisplayNewValue[1]);
                                        else
                                            dr["NewValue"] = "";
                                    }
                                    else
                                        dr["NewValue"] = "";
                                }
                                catch
                                {
                                    dr["NewValue"] = "";
                                }
                            }
                            else
                                dr["NewValue"] = "";

                            dtData.Rows.Add(dr);
                        }
                        else
                        {
                            if (Convert.ToString(dr["ColumnName"]).ToUpper() == "CREATEDBY" || Convert.ToString(dr["ColumnName"]).ToUpper() == "UPDATEDBY")
                            {
                                if (strOld.Length > 0)
                                {
                                    try
                                    {
                                        string strCheckOldValue = Convert.ToString(strOld.GetValue(i));

                                        if (strCheckOldValue != string.Empty)
                                        {
                                            string[] strDisplayOldValue = Convert.ToString(strOld[i].Trim()).Split(new char[] { '=' });

                                            if (strDisplayOldValue.Length > 1 && Convert.ToString(strDisplayOldValue[1]) != string.Empty)
                                            {
                                                User objGetUserData = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(strDisplayOldValue[1])));
                                                if (objGetUserData != null)
                                                    dr["OldValue"] = Convert.ToString(objGetUserData.UserName);
                                                else
                                                    dr["OldValue"] = "";
                                            }
                                            else
                                                dr["OldValue"] = "";
                                        }
                                        else
                                            dr["OldValue"] = "";
                                    }
                                    catch
                                    {
                                        dr["OldValue"] = "";
                                    }
                                }
                                else
                                    dr["OldValue"] = "";


                                if (strNew.Length > 0)
                                {
                                    try
                                    {
                                        string strCheckNewValue = Convert.ToString(strNew.GetValue(i));

                                        if (strCheckNewValue != string.Empty)
                                        {
                                            string[] strDisplayNewValue = Convert.ToString(strNew[i].Trim()).Split(new char[] { '=' });

                                            if (strDisplayNewValue.Length > 1 && Convert.ToString(strDisplayNewValue[1]) != string.Empty)
                                            {
                                                User objGetUserName = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(strDisplayNewValue[1])));

                                                if (objGetUserName != null)
                                                    dr["NewValue"] = Convert.ToString(objGetUserName.UserName);
                                                else
                                                    dr["NewValue"] = "";
                                            }
                                            else
                                                dr["NewValue"] = "";
                                        }
                                        else
                                            dr["NewValue"] = "";
                                    }
                                    catch
                                    {
                                        dr["NewValue"] = "";
                                    }
                                }
                                else
                                    dr["NewValue"] = "";

                                dtData.Rows.Add(dr);

                            }
                        }
                    }

                    gvActionLogData.DataSource = dtData;
                    gvActionLogData.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvActionLogList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvActionLogList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvActionLogData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrColumnName")).Text = clsCommon.GetGlobalResourceText("ActionLog", "lblGvHdrColumnName", "Column Name");
                    ((Label)e.Row.FindControl("lblGvHdrOldValue")).Text = clsCommon.GetGlobalResourceText("ActionLog", "lblGvHdrOldValue", "Old Value");
                    ((Label)e.Row.FindControl("lblGvHdrNewValue")).Text = clsCommon.GetGlobalResourceText("ActionLog", "litGvHdrNewData", "New Value");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblGvNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
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
                gvActionLogList.PageIndex = 0;
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