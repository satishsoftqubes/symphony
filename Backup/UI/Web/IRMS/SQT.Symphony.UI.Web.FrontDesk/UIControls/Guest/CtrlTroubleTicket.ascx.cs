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
namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlTroubleTicket : System.Web.UI.UserControl
    {

        #region Variable
        public string strPageName
        {
            get
            {
                return ViewState["strPageName"] != null ? Convert.ToString(ViewState["strPageName"]) : string.Empty;
            }
            set
            {
                ViewState["strPageName"] = value;
            }
        }
        public string strView
        {
            get
            {
                return ViewState["strView"] != null ? Convert.ToString(ViewState["strView"]) : string.Empty;
            }
            set
            {
                ViewState["strView"] = value;
            }
        }
        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }
        public Guid GuestID
        {
            get
            {
                return ViewState["GuestID"] != null ? new Guid(Convert.ToString(ViewState["GuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestID"] = value;
            }
        }
        public Guid RoomID
        {
            get
            {
                return ViewState["RoomID"] != null ? new Guid(Convert.ToString(ViewState["RoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomID"] = value;
            }
        }
        public bool IsMessage = false;

        #endregion Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvTicket.ActiveViewIndex = 0;
                LoadDefaultData();
            }
        }
        #endregion Page Load

        #region Private Method
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
            dr4["NameColumn"] = "Trouble Ticket";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);


            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
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
        private void LoadDefaultData()
        {
            try
            {
                BindGuestandReservationGrid();
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindGuestandReservationGrid()
        {
            try
            {
                //DataTable dtForGuest = new DataTable();

                //DataColumn dc1 = new DataColumn("ReservationNo");
                //DataColumn dc2 = new DataColumn("GuestFullName");
                //DataColumn dc3 = new DataColumn("RoomNo");
                //DataColumn dc4 = new DataColumn("Phone1");

                //dtForGuest.Columns.Add(dc1);
                //dtForGuest.Columns.Add(dc2);
                //dtForGuest.Columns.Add(dc3);
                //dtForGuest.Columns.Add(dc4);


                //DataRow dr1 = dtForGuest.NewRow();
                //dr1["ReservationNo"] = "RES#101";
                //dr1["GuestFullName"] = "Mr Michel Clerk";
                //dr1["RoomNo"] = "A-001(i)";
                //dr1["Phone1"] = "9998708967";


                //dtForGuest.Rows.Add(dr1);

                //DataRow dr2 = dtForGuest.NewRow();
                //dr2["ReservationNo"] = "RES#102";
                //dr2["GuestFullName"] = "Mr Ricky Ponting";
                //dr2["RoomNo"] = "A-002(i)";
                //dr2["Phone1"] = "8878675456";


                //dtForGuest.Rows.Add(dr2);

                //gvReservationList.DataSource = dtForGuest;
                //gvReservationList.DataBind();

                string strGuestName = null;
                string strRoomNo = null;

                if (txtSearchGuestName.Text.Trim() != "")
                    strGuestName = txtSearchGuestName.Text.Trim();

                if (txtSearchRoomNo.Text.Trim() != "")
                    strRoomNo = txtSearchRoomNo.Text.Trim();


                DataSet dsGuestAndResrList = GuestBLL.GetGuestAndReserForTroubleTicket(clsSession.PropertyID, clsSession.CompanyID, strGuestName, strRoomNo);

                if (dsGuestAndResrList != null && dsGuestAndResrList.Tables.Count > 0 && dsGuestAndResrList.Tables[0].Rows.Count > 0)
                {
                    gvReservationList.DataSource = dsGuestAndResrList;
                    gvReservationList.DataBind();
                }
                else
                {
                    gvReservationList.DataSource = null;
                    gvReservationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearSearch()
        {
            txtSearchGuestName.Text = "";
            txtSearchRoomNo.Text = "";
        }
        private void ClearControl()
        {
            txtTicketComplain.Text = "";
            txtTicketTitle.Text = "";
            ddlDepartment.SelectedIndex = 0;
            ddlPriority.SelectedIndex = 0;
            ddlTicketType.SelectedIndex = 0;
            txtTicketRequestBy.Text = "";
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
        #endregion Private Method

        #region Control Event
        protected void btnCloseTicketCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            ClearSearch();
            IsMessage = false;
            this.ReservationID = Guid.Empty;
            this.GuestID = Guid.Empty;
            this.RoomID = Guid.Empty;
            mvTicket.ActiveViewIndex = 0;

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvReservationList.PageIndex = 0;
                BindGuestandReservationGrid();
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
                gvReservationList.PageIndex = 0;
                BindGuestandReservationGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnTicketSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                    {
                        TroubleTicket objTroubleTicketIns = new TroubleTicket();
                        objTroubleTicketIns.ReservationID = this.ReservationID;
                        if (this.RoomID != null && this.RoomID != Guid.Empty)
                            objTroubleTicketIns.RoomID = this.RoomID;
                        else
                            objTroubleTicketIns.RoomID = null;

                        objTroubleTicketIns.PropertyID = clsSession.PropertyID;
                        objTroubleTicketIns.CompanyID = clsSession.CompanyID;

                        if (txtTicketComplain.Text.Trim() != null && txtTicketComplain.Text.Trim() != "")
                            objTroubleTicketIns.Description = clsCommon.GetUpperCaseText(txtTicketComplain.Text.Trim());
                        else
                            objTroubleTicketIns.Description = null;

                        if (txtTicketTitle.Text.Trim() != null && txtTicketTitle.Text.Trim() != "")
                            objTroubleTicketIns.Title = clsCommon.GetUpperCaseText(txtTicketTitle.Text.Trim());
                        else
                            objTroubleTicketIns.Title = null;

                        if (txtTicketRequestBy.Text.Trim() != null && txtTicketRequestBy.Text.Trim() != "")
                            objTroubleTicketIns.TicketRequestBy = clsCommon.GetUpperCaseText(txtTicketRequestBy.Text.Trim());
                        else
                            objTroubleTicketIns.TicketRequestBy = null;


                        if (ddlDepartment.SelectedIndex > 0)
                        {
                            objTroubleTicketIns.DepartmentID = new Guid(Convert.ToString(ddlDepartment.SelectedValue));
                        }

                        if (ddlPriority.SelectedIndex > 0)
                        {
                            objTroubleTicketIns.Priority_TermID = new Guid(Convert.ToString(ddlPriority.SelectedValue));
                        }
                        objTroubleTicketIns.IsClosed = false;
                        objTroubleTicketIns.CreatedOn = DateTime.Now;
                        objTroubleTicketIns.CreatedBy = clsSession.UserID;

                        TroubleTicketBLL.Save(objTroubleTicketIns);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objTroubleTicketIns.ToString(), objTroubleTicketIns.ToString(), "res_TroubleTicket", null);
                        IsMessage = true;
                        lblTicketMsg.Text = "Record Save Successfully.";
                        ClearControl();

                    }
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
        protected void gvReservationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("TICKET"))
                {
                    BindDDLDepartment();
                    BindPriorityDDL();
                    string[] resInfo = Convert.ToString(e.CommandArgument).Split(',');

                    DataSet dsReservation = ReservationBLL.SelectReservationDetailByReservationNo(resInfo[0], resInfo[1]);
                    if (dsReservation != null && dsReservation.Tables[0].Rows.Count > 0)
                    {
                        DataRow drResData = dsReservation.Tables[0].Rows[0];
                        this.ReservationID = new Guid(Convert.ToString(drResData["ReservationID"]));
                        this.GuestID = new Guid(Convert.ToString(drResData["GuestID"]));

                        if (resInfo[4] != null && resInfo[4] != "")
                        {
                            this.RoomID = new Guid(resInfo[4]);
                        }
                        ltrChkPmtReservationNo.Text = Convert.ToString(drResData["ReservationNo"]);
                        ltrChkPmtGuestName.Text = Convert.ToString(drResData["GuestFullName"]);
                        ltrChkPmtCheckInDate.Text = Convert.ToDateTime(Convert.ToString(drResData["CheckInDate"])).ToString(clsSession.DateFormat);
                        ltrChkPmtCheckOutDate.Text = Convert.ToDateTime(Convert.ToString(drResData["CheckOutDate"])).ToString(clsSession.DateFormat);
                        ltrChkPmtRoomType.Text = Convert.ToString(drResData["RoomTypeName"]);
                        ltrChkPmtRateCard.Text = Convert.ToString(drResData["RateCardName"]);
                        ltrChkPmtRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(drResData["RoomNo"]));
                    }

                    mvTicket.ActiveViewIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvReservationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReservationList.PageIndex = e.NewPageIndex;
            BindGuestandReservationGrid();
        }
        #endregion Grid Event
    }
}