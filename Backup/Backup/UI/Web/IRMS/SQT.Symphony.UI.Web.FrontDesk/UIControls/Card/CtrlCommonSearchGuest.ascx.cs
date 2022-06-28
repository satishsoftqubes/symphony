using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Card
{
    public partial class CtrlCommonSearchGuest : System.Web.UI.UserControl
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

        public event EventHandler btnSearchGuestCallParent_Click;

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.strPageName = GetPageName();
                BindGuestList();
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
                dr1["Arrival"] = "07-08-2012";
                dr1["Depature"] = "09-08-2012";
                dr1["Balance"] = "7000.00";
                dr1["MobileNo"] = "7589321545";
                dr1["Email"] = "jayesh@gmail.com";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["GuestName"] = "Miss. Palak Jain";
                dr2["CardNo"] = "************4816";
                dr2["ResNo"] = "4645646";
                dr2["RoomNo"] = "102";
                dr2["Arrival"] = "10-08-2012";
                dr2["Depature"] = "13-08-2012";
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

        private string GetPageName()
        {
            var uri = new Uri(Convert.ToString(Request.Url));
            string path = uri.GetLeftPart(UriPartial.Path);
            string[] strArray = path.Split('/');
            string strPageName = "";
            return strPageName = Convert.ToString(strArray[strArray.Length - 1]);
        }

        #endregion Private Method

        #region Grid Event

        protected void gvGuestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkRecharge = (LinkButton)e.Row.FindControl("lnkRecharge");
                    LinkButton lnkPrintStatement = (LinkButton)e.Row.FindControl("lnkPrintStatement");
                    LinkButton lnkLostCard = (LinkButton)e.Row.FindControl("lnkLostCard");

                    if (this.strPageName.ToUpper() == "CARDRECHARGE.ASPX")
                    {
                        lnkRecharge.Visible = true;
                        lnkPrintStatement.Visible = lnkLostCard.Visible = false;
                    }
                    else if (this.strPageName.ToUpper() == "PRINTSTATEMENT.ASPX")
                    {
                        lnkPrintStatement.Visible = true;
                        lnkRecharge.Visible = lnkLostCard.Visible = false;
                    }
                    else if (this.strPageName.ToUpper() == "LOSTCARD.ASPX")
                    {
                        lnkLostCard.Visible = true;
                        lnkPrintStatement.Visible = lnkRecharge.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("RECHARGE"))
                {
                    EventHandler temp = btnSearchGuestCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                else if (e.CommandName.Equals("PRINTSTATEMENT"))
                {
                    EventHandler temp = btnSearchGuestCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                else if (e.CommandName.Equals("LOSTCARD"))
                {
                    EventHandler temp = btnSearchGuestCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion  Grid Event
    }
}