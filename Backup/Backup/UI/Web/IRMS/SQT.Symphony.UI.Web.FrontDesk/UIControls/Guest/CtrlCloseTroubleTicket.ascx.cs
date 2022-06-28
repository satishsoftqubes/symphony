using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlCloseTroubleTicket : System.Web.UI.UserControl
    {

        #region Variable and Property
        public Guid TicketID
        {
            get
            {
                return ViewState["TicketID"] != null ? new Guid(Convert.ToString(ViewState["TicketID"])) : Guid.Empty;
            }
            set
            {
                ViewState["TicketID"] = value;
            }
        }
        public bool IsMessage = false;
        #endregion Variable and Property

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultData();
            }
        }
        #endregion Page Load

        #region Private Method
        private void BindDDLDepartment()
        {
            try
            {
                ddlDepartment.Items.Clear();
                DataSet dsData = DepartmentBLL.GetSearcahDepartmentData(clsSession.PropertyID, null, null, clsSession.CompanyID);
                if (dsData.Tables.Count != 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    ddlDepartment.DataSource = dsData.Tables[0];
                    ddlDepartment.DataTextField = "DepartmentName";
                    ddlDepartment.DataValueField = "DepartmentID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlDepartment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadDefaultData()
        {
            try
            {
                BindPriorityDDL();
                BindTicketGrid();
                BindDDLDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindPriorityDDL()
        {
            try
            {
                ddlPriority.Items.Clear();
                List<ProjectTerm> lstPriority = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PRIORITY");
                if (lstPriority.Count != 0)
                {
                    ddlPriority.DataSource = lstPriority;
                    ddlPriority.DataTextField = "DisplayTerm";
                    ddlPriority.DataValueField = "TermID";
                    ddlPriority.DataBind();
                    ddlPriority.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlPriority.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindTicketGrid()
        {
            try
            {
                //DataTable dtForTicket = new DataTable();

                //DataColumn dc1 = new DataColumn("TicketID");
                //DataColumn dc2 = new DataColumn("Title");
                //DataColumn dc3 = new DataColumn("Description");
                //DataColumn dc4 = new DataColumn("ReservationNo");
                //DataColumn dc5 = new DataColumn("GuestFullName");
                //DataColumn dc6 = new DataColumn("Department");


                //dtForTicket.Columns.Add(dc1);
                //dtForTicket.Columns.Add(dc2);
                //dtForTicket.Columns.Add(dc3);
                //dtForTicket.Columns.Add(dc4);
                //dtForTicket.Columns.Add(dc5);
                //dtForTicket.Columns.Add(dc6);

                //DataRow dr1 = dtForTicket.NewRow();
                //dr1["TicketID"] = "1";
                //dr1["Title"] = "AC";
                //dr1["Description"] = "Ac not working in Room A3-022";
                //dr1["ReservationNo"] = "RES#301";
                //dr1["GuestFullName"] = "Mr Ricky Ponting";
                //dr1["Department"] = "House keeping";


                //dtForTicket.Rows.Add(dr1);

                //DataRow dr2 = dtForTicket.NewRow();
                //dr2["TicketID"] = "2";
                //dr2["Title"] = "House Keeping";
                //dr2["Description"] = "House keeping issue in Room B1-013";
                //dr2["ReservationNo"] = "RES#302";
                //dr2["GuestFullName"] = "Mr Michel Clerk";
                //dr2["Department"] = "CE";

                //dtForTicket.Rows.Add(dr2);

                //gvTicketList.DataSource = dtForTicket;
                //gvTicketList.DataBind();

                string strTitle = null;
                string strName = null;
                string strReservationNo = null;
                bool? IsClosed = false;
                Guid? Priority = null;
                Guid? DepartmentID = null;

                if (txtSearchName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchName.Text.Trim());

                if (ddlDepartment.SelectedIndex > 0)
                    DepartmentID = new Guid(ddlDepartment.SelectedValue);
                else
                    DepartmentID = null;


                if (txtSearcReservationNo.Text.Trim() != "")
                    strReservationNo = "RES#" + Convert.ToString(txtSearcReservationNo.Text.Trim());

                if (txtSearchTitle.Text.Trim() != "")
                    strTitle = txtSearchTitle.Text.Trim();

                if (ddlPriority.SelectedIndex > 0)
                    Priority = new Guid(ddlPriority.SelectedValue);
                else
                    Priority = null;

                if (rblList.SelectedItem.Value == "Open")
                    IsClosed = false;
                else if (rblList.SelectedItem.Value == "Close")
                    IsClosed = true;
                else
                    IsClosed = null;

                DataSet dsTicketList = TroubleTicketBLL.GetTroubleTicketList(clsSession.CompanyID, clsSession.PropertyID, Priority, strTitle, IsClosed, strName, DepartmentID, strReservationNo);

                if (dsTicketList != null && dsTicketList.Tables.Count > 0 && dsTicketList.Tables[0].Rows.Count > 0)
                {
                    gvTicketList.DataSource = dsTicketList;
                    gvTicketList.DataBind();
                }
                else
                {
                    gvTicketList.DataSource = null;
                    gvTicketList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearControl()
        {
            this.TicketID = Guid.Empty;
            txtCloseDate.Text = "";
            txtRemarks.Text = "";
            ClearSearch();
        }
        private void ClearSearch()
        {
            txtSearchTitle.Text = "";
            rblList.SelectedIndex = 0;
            ddlPriority.SelectedIndex = 0;
            ddlDepartment.SelectedIndex = 0;
            txtSearchName.Text = "";
            txtSearcReservationNo.Text = "";
        }
        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }
        #endregion Private Method

        #region Control Event
        protected void rblList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvTicketList.PageIndex = 0;
                BindTicketGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearch();
                gvTicketList.PageIndex = 0;
                BindTicketGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnCloseTicketSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid && this.TicketID != null && this.TicketID != Guid.Empty)
                {
                    TroubleTicket objNewCloseTroubleTicket = new TroubleTicket();
                    objNewCloseTroubleTicket = TroubleTicketBLL.GetByPrimaryKey(this.TicketID);

                    TroubleTicket objoldCloseTroubleTicket = new TroubleTicket();
                    objoldCloseTroubleTicket = TroubleTicketBLL.GetByPrimaryKey(this.TicketID);


                    objNewCloseTroubleTicket.IsClosed = true;
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (txtRemarks.Text.Trim() != null && txtRemarks.Text.Trim() != "")
                        objNewCloseTroubleTicket.CloseRemarks = clsCommon.GetUpperCaseText(txtRemarks.Text.Trim());
                    else
                        objNewCloseTroubleTicket.CloseRemarks = null;

                    //if (txtCloseDate.Text.Trim() != null && txtCloseDate.Text.Trim() != "")
                    //{
                    //    DateTime dtCloseDate = DateTime.ParseExact(Convert.ToString(txtCloseDate.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    //    objNewCloseTroubleTicket.CloseDate = dtCloseDate;
                    //}
                    //else
                    //{
                    //    objNewCloseTroubleTicket.CloseDate = null;
                    //}

                    objNewCloseTroubleTicket.CloseDate = DateTime.Now;

                    objNewCloseTroubleTicket.CloseBy = clsSession.UserID;

                    TroubleTicketBLL.Update(objNewCloseTroubleTicket);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objoldCloseTroubleTicket.ToString(), objNewCloseTroubleTicket.ToString(), "res_TroubleTicket");
                    IsMessage = true;
                    lblTicketMsg.Text = "Ticket has been closed successfully.";
                    ClearControl();
                    BindTicketGrid();

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event

        #region Grid Event
        protected void gvTicketList_RowDataBound(object sender, GridViewRowEventArgs  e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //lblGvClosedDate
                    Label lblCLosedate = (Label)e.Row.FindControl("lblGvClosedDate");
                    //Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)

                    if (DataBinder.Eval(e.Row.DataItem, "CloseDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CloseDate")) != "")
                    {
                        lblCLosedate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CloseDate")).ToString(clsSession.DateFormat);

                    }
                    else
                    {
                        lblCLosedate.Text = "";
                    }

                    if (DataBinder.Eval(e.Row.DataItem, "IsClosed") != null && Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsClosed")) == true)
                    {
                        LinkButton lnkAction = (LinkButton)e.Row.FindControl("lnkAction");
                        lnkAction.CommandName = "REOPENICKET";
                        lnkAction.CommandArgument = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TicketID"));
                        lnkAction.ToolTip = "Reopen Ticket";
                    }
                    else
                    {
                        LinkButton lnkAction = (LinkButton)e.Row.FindControl("lnkAction");
                        lnkAction.CommandName = "CLOSETICKET";
                        lnkAction.CommandArgument = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TicketID"));
                        lnkAction.ToolTip = "Close Ticket";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvTicketList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("CLOSETICKET"))
                {
                    this.TicketID = new Guid(Convert.ToString(e.CommandArgument));
                    txtCloseDate.Text = "";
                    txtRemarks.Text = "";
                    mpeCloseTicket.Show();
                }
                else if (e.CommandName.ToUpper().Equals("TICKET"))
                {

                    string strName = Convert.ToString(e.CommandArgument);
                    string[] strSplit = strName.Split(',');

                    if (strSplit[1] != null && strSplit[1] != "")
                    {
                        litViewTicketCreatedDate.Text = Convert.ToDateTime(strSplit[1]).ToString(clsSession.DateFormat);
                    }
                    else
                    {
                        litViewTicketCreatedDate.Text = "-";

                    }
                    if (strSplit[2] != null && strSplit[2] != "")
                    {
                        txtViewDesc.Text = Convert.ToString(strSplit[2]);

                    }
                    else
                    {
                        txtViewDesc.Text = "-";

                    }
                    if (strSplit[0] != null && strSplit[0] != "")
                    {
                        litViewTicketreqBy.Text = Convert.ToString(strSplit[0]);
                    }
                    else
                    {
                        litViewTicketreqBy.Text = "-";
                    }
                    mpeTicketInfo.Show();

                }
                else if (e.CommandName.ToUpper().Equals("REOPENICKET"))
                {
                    this.TicketID = new Guid(Convert.ToString(e.CommandArgument));
                    TroubleTicket objreopenTicket = new TroubleTicket();

                    TroubleTicket objoldCloseTroubleTicket = new TroubleTicket();
                    objoldCloseTroubleTicket = TroubleTicketBLL.GetByPrimaryKey(this.TicketID);

                    objreopenTicket = TroubleTicketBLL.GetByPrimaryKey(this.TicketID);
                    objreopenTicket.CloseBy = null;
                    objreopenTicket.CloseDate = null;
                    objreopenTicket.CloseRemarks = null;
                    objreopenTicket.IsClosed = false;
                    TroubleTicketBLL.Update(objreopenTicket);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objoldCloseTroubleTicket.ToString(), objreopenTicket.ToString(), "res_TroubleTicket");
                    IsMessage = true;
                    lblTicketMsg.Text = "Ticket has been reopened successfully.";
                    ClearControl();
                    BindTicketGrid();
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