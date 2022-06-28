using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet
{
    public partial class ctrlBanquetManagement : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPlannerListGrid();
                BindToDoTaskListGrid();
                BindNotesListGrid();
                BindProposalListGrid();
                BindContactListGrid();
                BindBreadCrumb();
                mvContact.ActiveViewIndex = 0;
                mvPlanner.ActiveViewIndex = 0;
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindPlannerListGrid()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("ReservationNo");
                DataColumn dc2 = new DataColumn("AdultChild");
                DataColumn dc3 = new DataColumn("Status");
                DataColumn dc4 = new DataColumn("StartDate");
                DataColumn dc5 = new DataColumn("EndDate");
                DataColumn dc6 = new DataColumn("Banquet");
                DataColumn dc7 = new DataColumn("Arrange");
                DataColumn dc8 = new DataColumn("Event");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);
                dtService.Columns.Add(dc6);
                dtService.Columns.Add(dc7);
                dtService.Columns.Add(dc8);

                DataRow dr1 = dtService.NewRow();
                dr1["ReservationNo"] = "123456";
                dr1["AdultChild"] = "2/1";
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dr1["StartDate"] = "05-Aug-2012";
                dr1["EndDate"] = "08-Aug-2012";
                dr1["Banquet"] = "Barton";
                dr1["Arrange"] = "UShape";
                dr1["Event"] = "Event 1";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["ReservationNo"] = "123458";
                dr2["AdultChild"] = "2/0";
                dr2["Status"] = "<img src='../../images/UnConfirmed22x22.png' alt='UnConfirmed' title='UnConfirmed' />";
                dr2["StartDate"] = "01-Aug-2012";
                dr2["EndDate"] = "03-Aug-2012";
                dr2["Banquet"] = "Hempton";
                dr2["Arrange"] = "BoardRoom";
                dr2["Event"] = "Event 2";

                dtService.Rows.Add(dr2);

                gvPlannerList.DataSource = dtService;
                gvPlannerList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindToDoTaskListGrid()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("ToDoTask");
                DataColumn dc2 = new DataColumn("ReservationNo");
                DataColumn dc3 = new DataColumn("Status");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);

                DataRow dr1 = dtService.NewRow();
                dr1["ToDoTask"] = "Task 1";
                dr1["ReservationNo"] = "123456";
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["ToDoTask"] = "Task 2";
                dr2["ReservationNo"] = "123458";
                dr2["Status"] = "<img src='../../images/UnConfirmed22x22.png' alt='UnConfirmed' title='UnConfirmed' />";

                dtService.Rows.Add(dr2);

                gvToDoTaskList.DataSource = dtService;
                gvToDoTaskList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindNotesListGrid()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("ReservationNo");
                DataColumn dc2 = new DataColumn("Notes");
                DataColumn dc3 = new DataColumn("Status");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);

                DataRow dr1 = dtService.NewRow();
                dr1["ReservationNo"] = "123456";
                dr1["Notes"] = "Hello...";
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["ReservationNo"] = "123458";
                dr2["Notes"] = "Hi...";
                dr2["Status"] = "<img src='../../images/UnConfirmed22x22.png' alt='UnConfirmed' title='UnConfirmed' />";

                dtService.Rows.Add(dr2);

                gvNotesList.DataSource = dtService;
                gvNotesList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindProposalListGrid()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("ReservationNo");
                DataColumn dc2 = new DataColumn("AdultChild");
                DataColumn dc3 = new DataColumn("Status");
                DataColumn dc4 = new DataColumn("StartDate");
                DataColumn dc5 = new DataColumn("EndDate");
                DataColumn dc6 = new DataColumn("Banquet");
                DataColumn dc7 = new DataColumn("Arrange");
                DataColumn dc8 = new DataColumn("Event");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);
                dtService.Columns.Add(dc6);
                dtService.Columns.Add(dc7);
                dtService.Columns.Add(dc8);

                DataRow dr1 = dtService.NewRow();
                dr1["ReservationNo"] = "123456";
                dr1["AdultChild"] = "2/1";
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dr1["StartDate"] = "05-Aug-2012";
                dr1["EndDate"] = "08-Aug-2012";
                dr1["Banquet"] = "Barton";
                dr1["Arrange"] = "UShape";
                dr1["Event"] = "Event 3";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["ReservationNo"] = "123458";
                dr2["AdultChild"] = "2/0";
                dr2["Status"] = "<img src='../../images/UnConfirmed22x22.png' alt='UnConfirmed' title='UnConfirmed' />";
                dr2["StartDate"] = "01-Aug-2012";
                dr2["EndDate"] = "03-Aug-2012";
                dr2["Banquet"] = "Rousham";
                dr2["Arrange"] = "Theatre";
                dr2["Event"] = "Event 4";

                dtService.Rows.Add(dr2);

                gvProposalList.DataSource = dtService;
                gvProposalList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindContactListGrid()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("GuestName");
                DataColumn dc2 = new DataColumn("Country");
                DataColumn dc3 = new DataColumn("State");
                DataColumn dc4 = new DataColumn("City");
                DataColumn dc5 = new DataColumn("Email");
                DataColumn dc6 = new DataColumn("IDDetails");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);
                dtService.Columns.Add(dc6);

                DataRow dr1 = dtService.NewRow();
                dr1["GuestName"] = "Mr. Jayesh Rathod";
                dr1["Country"] = "India";
                dr1["State"] = "Gujarat";
                dr1["City"] = "Ahmedabad";
                dr1["Email"] = "jayesh@gmail.com";
                dr1["IDDetails"] = "36521478";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["GuestName"] = "Miss. Palak Jain";
                dr2["Country"] = "India";
                dr2["State"] = "Maharashtra";
                dr2["City"] = "Pathardi";
                dr2["Email"] = "palak@sqt.in";
                dr2["IDDetails"] = "95175468";

                dtService.Rows.Add(dr2);

                gvContactsList.DataSource = dtService;
                gvContactsList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
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

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Banquets";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Banquet Management";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion  Private Method

        #region Control Event

        protected void btnTopAddProposal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Banquet/BanquetProposal.aspx");
        }

        protected void btnGuestHistoryCallParent_Click(object sender, EventArgs e)
        {
            mvContact.ActiveViewIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvPlanner.ActiveViewIndex = 0;
        }
        protected void btnControlNotesCallParent_Click(object sender, EventArgs e)
        {
            mvPlanner.ActiveViewIndex = 0;
        }

        #endregion Control Event

        #region Grid Event

        protected void gvContactsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("PROFILE"))
                {
                    Response.Redirect("~/GUI/Folio/GuestProfile.aspx?BanquetMgmt=true");
                }
                else if (e.CommandName.Equals("HISTORY"))
                {
                    mvContact.ActiveViewIndex = 1;
                    ctrlCommonGuestHistory.uclitGuestHistoryName.Text = Convert.ToString(e.CommandArgument);
                    ctrlCommonGuestHistory.uclitGuestHistoryContactNo.Text = "7894560123";
                    ctrlCommonGuestHistory.BindGrid();
                }
                else if (e.CommandName.Equals("MESSAGE"))
                {
                    Response.Redirect("~/GUI/Guest/Message.aspx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPlannerList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("TODOTASK"))
                {
                    mvPlanner.ActiveViewIndex = 1;
                }
                else if (e.CommandName.Equals("CONTROLNOTES"))
                {
                    mvPlanner.ActiveViewIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}