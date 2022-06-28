using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Card
{
    public partial class ctrlIssueCard : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindGuestList();
                mvIssueCard.ActiveViewIndex = 0;
            }
        }

        #endregion  Page Load

        #region Private Method

        private void BindGuestList()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("GuestName");
                DataColumn dc2 = new DataColumn("CardNo");
                DataColumn dc3 = new DataColumn("ResNo");
                DataColumn dc5 = new DataColumn("RoomNo");
                DataColumn dc4 = new DataColumn("Arrival");
                DataColumn dc6 = new DataColumn("Depature");
                DataColumn dc7 = new DataColumn("Balance");
                DataColumn dc8 = new DataColumn("MobileNo");
                DataColumn dc9 = new DataColumn("Email");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);
                dtService.Columns.Add(dc6);
                dtService.Columns.Add(dc7);
                dtService.Columns.Add(dc8);
                dtService.Columns.Add(dc9);

                DataRow dr1 = dtService.NewRow();
                dr1["GuestName"] = "Mr. Jayesh Rathod";
                dr1["CardNo"] = "************7469";
                dr1["ResNo"] = "123456";
                dr1["RoomNo"] = "101";
                dr1["Arrival"] = "10-08-2012";
                dr1["Depature"] = "13-08-2012";
                dr1["Balance"] = "7000.00";
                dr1["MobileNo"] = "7589321545";
                dr1["Email"] = "jayesh@gmail.com";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["GuestName"] = "Miss. Palak Jain";
                dr2["CardNo"] = "************4816";
                dr2["ResNo"] = "4645646";
                dr2["RoomNo"] = "102";
                dr2["Arrival"] = "07-08-2012";
                dr2["Depature"] = "09-08-2012";
                dr2["Balance"] = "5000.00";
                dr2["MobileNo"] = "9825674123";
                dr2["Email"] = "palak@sqt.in";

                dtService.Rows.Add(dr2);

                gvGuestList.DataSource = dtService;
                gvGuestList.DataBind();
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
            dr4["NameColumn"] = "CashCard";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Issue Card";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #endregion  Private Method

        #region Control Event

        protected void btnIssueCardCancel_Click(object sender, EventArgs e)
        {
            mvIssueCard.ActiveViewIndex = 0;
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            int ranid = RandomNumber(10000, 99999);// can pass minium and maximum number for random number generation.
            txtCardNo.Text = ranid.ToString();
        }

        #endregion Control Event

        #region Grid Event

        protected void gvGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("ISSUECARD"))
                {
                    txtCardNo.Text = txtAmount.Text = txtNotes.Text = "";
                    mvIssueCard.ActiveViewIndex = 1;
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