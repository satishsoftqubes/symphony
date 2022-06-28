using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class ctrlNewCheckInList : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindGrid();
                mvCheckInForm.ActiveViewIndex = 0;
            }
        }

        #endregion Page Load

        #region Private Method

        //private void BindGuestGrid()
        //{
        //    DataTable dtTable = new DataTable();

        //    DataColumn dc1 = new DataColumn("GuestName");
        //    DataColumn dc2 = new DataColumn("ArrivalDate");
        //    DataColumn dc3 = new DataColumn("DepatureDate");
        //    DataColumn dc4 = new DataColumn("GuestNotes");

        //    dtTable.Columns.Add(dc1);
        //    dtTable.Columns.Add(dc2);
        //    dtTable.Columns.Add(dc3);
        //    dtTable.Columns.Add(dc4);

        //    DataRow dr1 = dtTable.NewRow();
        //    dr1["GuestName"] = "Glenton";
        //    dr1["ArrivalDate"] = "09-7-2012";
        //    dr1["DepatureDate"] = "13-7-2012";
        //    dr1["GuestNotes"] = "";

        //    dtTable.Rows.Add(dr1);

        //    DataRow dr2 = dtTable.NewRow();
        //    dr2["GuestName"] = "John";
        //    dr2["ArrivalDate"] = "09-7-2012";
        //    dr2["DepatureDate"] = "13-7-2012";
        //    dr2["GuestNotes"] = "";

        //    dtTable.Rows.Add(dr2);

        //    gvGuestList.DataSource = dtTable;
        //    gvGuestList.DataBind();
        //}

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

            //DataRow dr4 = dt.NewRow();
            //dr4["NameColumn"] = "Reservation";
            //dr4["Link"] = "";
            //dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Check In";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc2 = new DataColumn("ReservationNo");
                DataColumn dc3 = new DataColumn("GuestName");
                DataColumn dc4 = new DataColumn("MobileNo");
                DataColumn dc5 = new DataColumn("RoomNo");
                DataColumn dc6 = new DataColumn("RoomType");
                DataColumn dc7 = new DataColumn("Company");
                DataColumn dc8 = new DataColumn("Status");
                DataColumn dc9 = new DataColumn("RateCardType");
                DataColumn dc10 = new DataColumn("CheckIn");
                DataColumn dc11 = new DataColumn("CheckOut");

                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);
                dtTable.Columns.Add(dc9);
                dtTable.Columns.Add(dc10);
                dtTable.Columns.Add(dc11);

                DataRow dr1 = dtTable.NewRow();
                dr1["ReservationNo"] = "123456";
                dr1["GuestName"] = "Mr. Jayesh Patel";
                dr1["MobileNo"] = "9856321470";
                dr1["RoomNo"] = "1";
                dr1["RoomType"] = "Delux";
                dr1["Company"] = "Uniworld India";
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dr1["RateCardType"] = "Corporate RateCard";
                dr1["CheckIn"] = "10-08-2012";
                dr1["CheckOut"] = "13-08-2012";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["ReservationNo"] = "654321";
                dr2["GuestName"] = "Miss Palak Jain";
                dr2["MobileNo"] = "8546230145";
                dr2["RoomNo"] = "2";
                dr2["RoomType"] = "Family";
                dr2["Company"] = "SQT";
                dr2["Status"] = "<img src='../../images/WaitingList22x22.png' alt='Provisional' title='Waiting List' />";
                dr2["RateCardType"] = "Room RateCard";
                dr2["CheckIn"] = "07-08-2012";
                dr2["CheckOut"] = "09-08-2012";

                dtTable.Rows.Add(dr2);

                gvRoomReservationList.DataSource = dtTable;
                gvRoomReservationList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindGuestHistoryGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("BookingNo");
                DataColumn dc2 = new DataColumn("CheckInDate");
                DataColumn dc3 = new DataColumn("CheckOutDate");
                DataColumn dc4 = new DataColumn("Nights");
                DataColumn dc5 = new DataColumn("RateCard");
                DataColumn dc6 = new DataColumn("RoomType");
                DataColumn dc7 = new DataColumn("RoomNo");
                DataColumn dc8 = new DataColumn("InvAmt");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);

                DataRow dr1 = dtTable.NewRow();
                dr1["BookingNo"] = "30421";
                dr1["CheckInDate"] = "03-04-2011";
                dr1["CheckOutDate"] = "06-06-2011";
                dr1["Nights"] = "63";
                dr1["RateCard"] = "Monthly Ratecard";
                dr1["RoomType"] = "Standard";
                dr1["RoomNo"] = "F105";
                dr1["InvAmt"] = "12000.00";
                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["BookingNo"] = "33466";
                dr2["CheckInDate"] = "11-09-2011";
                dr2["CheckOutDate"] = "25-12-2011";
                dr2["Nights"] = "101";
                dr2["RateCard"] = "3 Month Ratecard";
                dr2["RoomType"] = "Standard";
                dr2["RoomNo"] = "F310";
                dr2["InvAmt"] = "18500.00";
                dtTable.Rows.Add(dr2);

                gvGuestHistory.DataSource = dtTable;
                gvGuestHistory.DataBind();


                DataTable dtTablePreference = new DataTable();
                DataColumn dcP1 = new DataColumn("Preference");
                dtTablePreference.Columns.Add(dcP1);

                DataRow drP1 = dtTablePreference.NewRow();
                drP1["Preference"] = "Omelette and tea in breakfast";
                dtTablePreference.Rows.Add(drP1);

                DataRow drP2 = dtTablePreference.NewRow();
                drP2["Preference"] = "Special tea at 10:00 PM";
                dtTablePreference.Rows.Add(drP2);

                DataRow drP3 = dtTablePreference.NewRow();
                drP3["Preference"] = "House Keeping should be done in early morning.";
                dtTablePreference.Rows.Add(drP3);

                gvGuestPreferences.DataSource = dtTablePreference;
                gvGuestPreferences.DataBind();


                DataTable dtTableNote = new DataTable();
                DataColumn dcN1 = new DataColumn("Note");
                dtTableNote.Columns.Add(dcN1);

                DataRow drN1 = dtTableNote.NewRow();
                drN1["Note"] = "Fight with one guest.";
                dtTableNote.Rows.Add(drN1);

                DataRow drN2 = dtTableNote.NewRow();
                drN2["Note"] = "Complain by House keeping person.";
                dtTableNote.Rows.Add(drN2);

                gvFrontDesksNote.DataSource = dtTableNote;
                gvFrontDesksNote.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Private Method

        #region Control Event

        protected void btnCheckInAddService_Click(object sender, EventArgs e)
        {
            ClearServiceControl();
            mvCheckInForm.ActiveViewIndex = 2;
        }

        protected void btnEditGuestInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEditGuestInfo.Text.ToUpper() == "EDIT")
                {
                    btnEditGuestInfo.Text = "Save";
                    ddlNationality.Enabled = ddlTitle.Enabled = txtFirstName.Enabled = txtLastName.Enabled = txtMobile.Enabled = txtGuestEmail.Enabled = txtAddress.Enabled = true;
                    txtAddressLine2.Enabled = txtCityName.Enabled = txtZipCode.Enabled = txtStateName.Enabled = txtCountryName.Enabled = rdbIsPicup.Enabled = txtSpecificInstruction.Enabled = true;
                    txtNote.Enabled = true;
                }
                else
                {
                    btnEditGuestInfo.Text = "Edit";
                    ddlNationality.Enabled = ddlTitle.Enabled = txtFirstName.Enabled = txtLastName.Enabled = txtMobile.Enabled = txtGuestEmail.Enabled = txtAddress.Enabled = false;
                    txtAddressLine2.Enabled = txtCityName.Enabled = txtZipCode.Enabled = txtStateName.Enabled = txtCountryName.Enabled = rdbIsPicup.Enabled = txtSpecificInstruction.Enabled = false;
                    txtNote.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnServiceCancel_Click(object sender, EventArgs e)
        {
            mvCheckInForm.ActiveViewIndex = 1;
        }

        protected void btnCheckInReRoute_Click(object sender, EventArgs e)
        {
            try
            {
                string strPageName = GetPageName();

                if (strPageName.ToUpper() == "CHECKIN.ASPX")
                    Response.Redirect("~/GUI/Folio/RerouteFolioSetup.aspx?CheckIn=true");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCheckInAddServices_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    BindServiceList();
                    litCheckInTotalServiceRate.Text = "60.00";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCheckInCancel_Click(object sender, EventArgs e)
        {
            mvCheckInForm.ActiveViewIndex = 0;

        }

        protected void ddlModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlModeOfPayment.SelectedIndex == 0 || ddlModeOfPayment.SelectedIndex == 1)
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCreditCard4.Visible = false;
                }
                else if (ddlModeOfPayment.SelectedIndex == 2 || ddlModeOfPayment.SelectedIndex == 3)
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCreditCard4.Visible = false;
                    trChequeDD1.Visible = trChequeDD2.Visible = true;
                }
                else if (ddlModeOfPayment.SelectedIndex == 4)
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCreditCard4.Visible = false;
                    trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCreditCard4.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event

        #region RadioButton Event

        protected void rdblServicePackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddlServicesAndPackages.Items.Clear();

                if (rdblServicePackage.SelectedValue == "1")
                {
                    ddlServicesAndPackages.Items.Add(new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlServicesAndPackages.Items.Add(new ListItem("Tea", "Tea"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Coffe", "Coffe"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Cold Drink", "Cold Drink"));

                }
                else
                {
                    ddlServicesAndPackages.Items.Add(new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlServicesAndPackages.Items.Add(new ListItem("Special Package", "Special Package"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Regular Package", "Regular Package"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Grid Event

        protected void gvRoomReservationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("CHECKIN"))
                {
                    mvCheckInForm.ActiveViewIndex = 1;
                    //BindGuestGrid();
                    BindGuestHistoryGrid();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        protected void lnkSelectRoom_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                string strCalendar = "<table class='checkinselection' cellpadding='0' border='1' cellspacing='3'><tr><td style='padding:0px; margin:0px; width:60px !important; float:left; border:1px solid #ccc;'>RM #</td>";
                DateTime dtSD = DateTime.Now.Date;
                DateTime dtED = DateTime.Now.Date.AddDays(19);

                for (DateTime j = dtSD; (dtED.Subtract(j)).TotalDays >= 0; )
                {
                    strCalendar += "<td>" + Convert.ToString(j.ToString("dd/MM")) + "</td>";
                    j = j.AddDays(1);
                }

                strCalendar += "</tr></table>";
                divCalendar.InnerHtml = strCalendar;


                for (int i = 1; i < 6; i++)
                {
                    str += "<table class='checkinselection' cellpadding='0' border='1' cellspacing='3' id='table_" + i + "'><tr><td style='padding:0px; margin:0px; width:60px !important; float:left; border:1px solid #ccc;'><a href='#' onClick='fnCalculateDayForDailyBooking(" + i + ")'>" + i + "</a></td>";
                    int id = 0;
                    for (DateTime j = dtSD; (dtED.Subtract(j)).TotalDays >= 0; )
                    {
                        id++;
                        int sd = Convert.ToInt32(j.ToString("dd"));

                        if (i % 2 == 0)
                        {
                            if (sd > 15 && sd < 20)
                            {
                                str += "<td class='selected_block' ommouseover=\"tooltip.show('Dipen\');\" onmouseout='tooltip.hide();' id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                            }
                            else
                            {
                                str += "<td id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                            }
                        }
                        else
                        {
                            if (sd > 25 && sd < 30)
                            {
                                str += "<td class='selected_block' ommouseover=\"tooltip.show('Neha Patel');\" onmouseout='tooltip.hide();' id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                            }
                            else
                            {
                                str += "<td id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                            }
                        }

                        j = j.AddDays(1);
                    }
                    str += "</tr></table>";
                }

                divBooking.InnerHtml = str;
                mpeAssignRoom.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkNew_Click(object sender, EventArgs e)
        {
            mvCheckInForm.ActiveViewIndex = 3;
            BindTreeView();
        }

        protected void ddlFrequency_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFrequency.SelectedValue == "Daily")
                {
                    string str = "";
                    string strCalendar = "<table class='checkinselection' cellpadding='0' border='1' cellspacing='3'><tr><td style='padding:0px; margin:0px; width:60px !important; float:left; border:1px solid #ccc;'>RM #</td>";
                    DateTime dtSD = DateTime.Now.Date;
                    DateTime dtED = DateTime.Now.Date.AddDays(19);

                    for (DateTime j = dtSD; (dtED.Subtract(j)).TotalDays >= 0; )
                    {
                        strCalendar += "<td>" + Convert.ToString(j.ToString("dd/MM")) + "</td>";
                        j = j.AddDays(1);
                    }

                    strCalendar += "</tr></table>";
                    divCalendar.InnerHtml = strCalendar;


                    for (int i = 1; i < 6; i++)
                    {
                        str += "<table class='checkinselection' cellpadding='0' border='1' cellspacing='3' id='table_" + i + "'><tr><td style='padding:0px; margin:0px; width:60px !important; float:left; border:1px solid #ccc;'><a href='#' onClick='fnCalculateDayForDailyBooking(" + i + ")'>" + i + "</a></td>";
                        int id = 0;
                        for (DateTime j = dtSD; (dtED.Subtract(j)).TotalDays >= 0; )
                        {
                            id++;
                            int sd = Convert.ToInt32(j.ToString("dd"));

                            if (i % 2 == 0)
                            {
                                if (sd > 15 && sd < 20)
                                {
                                    str += "<td class='selected_block' ommouseover=\"tooltip.show('Dipen\');\" onmouseout='tooltip.hide();' id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                                }
                                else
                                {
                                    str += "<td id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                                }
                            }
                            else
                            {
                                if (sd > 25 && sd < 30)
                                {
                                    str += "<td class='selected_block' ommouseover=\"tooltip.show('Neha Patel');\" onmouseout='tooltip.hide();' id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                                }
                                else
                                {
                                    str += "<td id='" + Convert.ToString(i + "-" + id) + "'>&nbsp;</td>";
                                }
                            }

                            j = j.AddDays(1);
                        }
                        str += "</tr></table>";
                    }

                    divBooking.InnerHtml = str;
                    mpeAssignRoom.Show();
                }
                else if (ddlFrequency.SelectedValue == "Weekly")
                {
                }
                else if (ddlFrequency.SelectedValue == "Monthly")
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindTreeView()
        {
            try
            {

                TreeNode root1 = new TreeNode("Block A", "1");
                root1.SelectAction = TreeNodeSelectAction.Expand;
                CreateNode(root1);
                treeviwExample.Nodes.Add(root1);

                TreeNode root2 = new TreeNode("Block B", "2");
                root2.SelectAction = TreeNodeSelectAction.Expand;
                CreateNode(root2);
                treeviwExample.Nodes.Add(root2);

                TreeNode root3 = new TreeNode("Block C", "3");
                root3.SelectAction = TreeNodeSelectAction.Expand;
                CreateNode(root3);
                treeviwExample.Nodes.Add(root3);

                TreeNode root4 = new TreeNode("Block D", "4");
                root4.SelectAction = TreeNodeSelectAction.Expand;
                CreateNode(root4);
                treeviwExample.Nodes.Add(root4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void CreateNode(TreeNode node)
        {
            for (int i = 0; i < 3; i++)
            {
                string strFloorName = "";
                if (i == 0)
                    strFloorName = "1st";
                else if (i == 1)
                    strFloorName = "2nd";
                else if (i == 2)
                    strFloorName = "3rd";

                TreeNode Childnode = new TreeNode(strFloorName, i.ToString());
                Childnode.SelectAction = TreeNodeSelectAction.Expand;
                node.ChildNodes.Add(Childnode);

            }
        }

        protected void treeviwExample_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void treeviwExample_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {

        }
    }
}