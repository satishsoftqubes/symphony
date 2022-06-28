using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonCheckIn : System.Web.UI.UserControl
    {
        #region Property and Variable

        public MultiView ucmvCheckIn
        {
            get { return this.mvCheckIn; }
        }

        public event EventHandler btnCheckInCallParent_Click;

        public string strMode
        {
            get
            {
                return ViewState["strMode"] != null ? Convert.ToString(ViewState["strMode"]) : string.Empty;
            }
            set
            {
                ViewState["strMode"] = value;
            }
        }
        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageName = this.Page.ToString().Substring(4, this.Page.ToString().Substring(4).Length - 5) + ".aspx";
                mvCheckIn.ActiveViewIndex = 0;
                BindGuestGrid();
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindGuestGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("GuestName");
                DataColumn dc2 = new DataColumn("ArrivalDate");
                DataColumn dc3 = new DataColumn("DepatureDate");
                DataColumn dc4 = new DataColumn("GuestNotes");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["GuestName"] = "Glenton";
                dr1["ArrivalDate"] = "09-07-2012";
                dr1["DepatureDate"] = "13-07-2012";
                dr1["GuestNotes"] = "";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["GuestName"] = "John";
                dr2["ArrivalDate"] = "09-07-2012";
                dr2["DepatureDate"] = "13-07-2012";
                dr2["GuestNotes"] = "";

                dtTable.Rows.Add(dr2);

                gvGuestList.DataSource = dtTable;
                gvGuestList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindServiceList()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("Service");
                DataColumn dc2 = new DataColumn("Date");
                DataColumn dc3 = new DataColumn("Time");
                DataColumn dc4 = new DataColumn("Notes");
                DataColumn dc5 = new DataColumn("Amount");
                DataColumn dc6 = new DataColumn("Qty");
                DataColumn dc7 = new DataColumn("ServiceRate");
                DataColumn dc8 = new DataColumn("Tax");
                DataColumn dc9 = new DataColumn("SrvTax");
                DataColumn dc10 = new DataColumn("Total");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);
                dtService.Columns.Add(dc6);
                dtService.Columns.Add(dc7);
                dtService.Columns.Add(dc8);
                dtService.Columns.Add(dc9);
                dtService.Columns.Add(dc10);

                DataRow dr1 = dtService.NewRow();
                dr1["Service"] = "Tea";
                dr1["Date"] = "31-05-2012";
                dr1["Time"] = "15:15";
                dr1["Notes"] = "";
                dr1["Amount"] = "10.00";
                dr1["Qty"] = "1";
                dr1["ServiceRate"] = "0.00";
                dr1["Tax"] = "5.00";
                dr1["SrvTax"] = "0.00";
                dr1["Total"] = "10.00";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["Service"] = "Cold Drink";
                dr2["Date"] = "01-06-2012";
                dr2["Time"] = "16:00";
                dr2["Notes"] = "";
                dr2["Amount"] = "25.00";
                dr2["Qty"] = "2";
                dr2["ServiceRate"] = "0.00";
                dr2["Tax"] = "10.00";
                dr2["SrvTax"] = "0.80";
                dr2["Total"] = "50.00";

                dtService.Rows.Add(dr2);

                gvServiceList.DataSource = dtService;
                gvServiceList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ClearServiceControl()
        {
            txtServiceDate.Text = txtServiceTime.Text = txtQty.Text = txtAmount.Text = "";
            ddlServiceFrequency.SelectedIndex = ddlServicesAndPackages.SelectedIndex = 0;
            litCheckInTotalServiceRate.Text = "0.00";
            gvServiceList.DataSource = null;
            gvServiceList.DataBind();
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

        #region Control Event

        protected void btnCheckInAddService_Click(object sender, EventArgs e)
        {
            try
            {
                string strPageName = GetPageName();

                ClearServiceControl();
                ////BindServiceList();

                if (strPageName.ToUpper() == "CHECKIN.ASPX")
                {
                    mvCheckIn.ActiveViewIndex = 1;
                }
                else
                {
                    //mpeCheckIn.Show();
                    strMode = "OPENADDSERVICEPOPUP";

                    mvCheckIn.ActiveViewIndex = 1;

                    EventHandler temp = btnCheckInCallParent_Click;
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

        protected void btnServiceCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string strPageName = GetPageName();
                if (strPageName.ToUpper() == "CHECKIN.ASPX")
                {
                    mvCheckIn.ActiveViewIndex = 0;
                }
                else
                {
                    //mpeCheckIn.Show();
                    strMode = "CLOSEADDSERVICEPOPUP";
                    mvCheckIn.ActiveViewIndex = 0;

                    EventHandler temp = btnCheckInCallParent_Click;
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

        protected void btnCheckInReRoute_Click(object sender, EventArgs e)
        {
            string strPageName = GetPageName();
            if (strPageName.ToUpper() == "ROOMRESERVATION.ASPX")
                Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?RoomReservation=true");
            else if (strPageName.ToUpper() == "INVESTORBOOKING.ASPX")
                Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?Investor=true");
            else if (strPageName.ToUpper() == "ARRIVALANDDEPARTURE.ASPX")
                Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?AD=true");
            else if (strPageName.ToUpper() == "CHECKIN.ASPX")
                Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?CheckIn=true");
            else if (strPageName.ToUpper() == "GROUPRESERVATION.ASPX")
                Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?GroupReservation=true");                
        }

        #endregion Control Event

        #region RadioButton Event

        protected void rdblServicePackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //mpeCheckIn.Show();
                mvCheckIn.ActiveViewIndex = 1;
                ddlServicesAndPackages.Items.Clear();

                if (rdblServicePackage.SelectedValue == "1")
                {
                    ddlServicesAndPackages.Items.Add(new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                    ddlServicesAndPackages.Items.Add(new ListItem("Tea", "Tea"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Coffe", "Coffe"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Cold Drink", "Cold Drink"));
                }
                else
                {
                    ddlServicesAndPackages.Items.Add(new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                    ddlServicesAndPackages.Items.Add(new ListItem("Special Package", "Special Package"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Regular Package", "Regular Package"));
                }

                strMode = "OPENADDSERVICEPOPUP";

                mvCheckIn.ActiveViewIndex = 1;

                EventHandler temp = btnCheckInCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        protected void btnCheckInAddServices_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Page.IsValid)
                {
                    BindServiceList();
                    litCheckInTotalServiceRate.Text = "60.00";

                    strMode = "OPENADDSERVICEPOPUP";

                    mvCheckIn.ActiveViewIndex = 1;

                    EventHandler temp = btnCheckInCallParent_Click;
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
    }
}