using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet
{
    public partial class CtrlBanquetProposal : System.Web.UI.UserControl
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvLabourInfo.DataSource = null;
                gvLabourInfo.DataBind();
                gvLabourTask.DataSource = null;
                gvLabourTask.DataBind();
                gvRoomReservation.DataSource = null;
                gvRoomReservation.DataBind();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Control Event
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtLabourTask = new DataTable();

                DataColumn dc1 = new DataColumn("ServiceArea");
                DataColumn dc2 = new DataColumn("Manager");
                DataColumn dc3 = new DataColumn("Labours");
                DataColumn dc4 = new DataColumn("Start");
                DataColumn dc5 = new DataColumn("End");
                DataColumn dc6 = new DataColumn("Charge");

                dtLabourTask.Columns.Add(dc1);
                dtLabourTask.Columns.Add(dc2);
                dtLabourTask.Columns.Add(dc3);
                dtLabourTask.Columns.Add(dc4);
                dtLabourTask.Columns.Add(dc5);
                dtLabourTask.Columns.Add(dc6);


                DataRow dr1 = dtLabourTask.NewRow();
                dr1["ServiceArea"] = ddlServiceArea.SelectedValue;
                dr1["Manager"] = ddlManager.SelectedValue;
                dr1["Labours"] = txtLabours.Text;
                dr1["Start"] = txtStartTime.Text;
                dr1["End"] = txtEndTime1.Text;
                dr1["Charge"] = txtCharge.Text;
                dtLabourTask.Rows.Add(dr1);

                gvLabourTask.DataSource = dtLabourTask;
                gvLabourTask.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnLabourInfoAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtLabourInfo = new DataTable();

                DataColumn dc1 = new DataColumn("LabourName");
                DataColumn dc2 = new DataColumn("Contacts");
                DataColumn dc3 = new DataColumn("JobDetail");
                DataColumn dc4 = new DataColumn("Start");
                DataColumn dc5 = new DataColumn("End");
                DataColumn dc6 = new DataColumn("Present");

                dtLabourInfo.Columns.Add(dc1);
                dtLabourInfo.Columns.Add(dc2);
                dtLabourInfo.Columns.Add(dc3);
                dtLabourInfo.Columns.Add(dc4);
                dtLabourInfo.Columns.Add(dc5);
                dtLabourInfo.Columns.Add(dc6);

                string present = string.Empty;
                if (chkPresent.Checked == true)
                    present = "YES";
                else
                    present = "No";

                DataRow dr1 = dtLabourInfo.NewRow();
                dr1["LabourName"] = txtLabourInfoLabourName.Text;
                dr1["Contacts"] = txtLabourInfoContacts.Text;
                dr1["JobDetail"] = txtLabourInfoJobDetail.Text;
                dr1["Start"] = txtLabourInfoStartTime.Text;
                dr1["End"] = txtLabourInfoEndTime.Text;
                dr1["Present"] = present;
                dtLabourInfo.Rows.Add(dr1);

                gvLabourInfo.DataSource = dtLabourInfo;
                gvLabourInfo.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCalRate_Click(object sender, EventArgs e)
        {
            BindGridRoomReservation();
        }

        protected void ddlBanquet_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindDDLArrange();
        }

        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            ddlServiceArea.SelectedIndex = 0;
            ddlManager.SelectedIndex = 0;
            txtStartTime.Text = "";
            txtEndTime1.Text = "";
            txtCharge.Text = "";
            txtLabours.Text = "1";
            txtNotes.Text = "";
        }

        protected void btnLabourInfoClear_OnClick(object sender, EventArgs e)
        {
            txtLabourInfoLabourName.Text= txtLabourInfoContacts.Text=txtLabourInfoEndTime.Text=txtLabourInfoJobDetail.Text=txtLabourInfoStartTime.Text= "";
            chkPresent.Checked = false;
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            //ClearControlBookingDetail();
            Response.Redirect("~/GUI/Banquet/BanquetManagement.aspx#tabs-2");
        }
       
        #endregion

        #region private Mathod
        private void BindDDLArrange()
        {
            try
            {
                DataTable ListArrange = new DataTable();

                DataColumn dc1 = new DataColumn("Arrange");

                ListArrange.Columns.Add(dc1);

                if (ddlBanquet.SelectedIndex == 0)
                {
                    ddlArrange.SelectedIndex = 0;
                }
                else if (ddlBanquet.SelectedIndex == 1)
                {
                    DataRow dr1 = ListArrange.NewRow();
                    dr1["Arrange"] = "Banquet";
                    ListArrange.Rows.Add(dr1);

                    DataRow dr2 = ListArrange.NewRow();
                    dr2["Arrange"] = "Ushape";
                    ListArrange.Rows.Add(dr2);

                }
                else if (ddlBanquet.SelectedIndex == 2)
                {
                    DataRow dr3 = ListArrange.NewRow();
                    dr3["Arrange"] = "Boardroom";
                    ListArrange.Rows.Add(dr3);
                }
                else if (ddlBanquet.SelectedIndex == 3)
                {
                    DataRow dr4 = ListArrange.NewRow();
                    dr4["Arrange"] = "Boardroom";
                    ListArrange.Rows.Add(dr4);

                    DataRow dr5 = ListArrange.NewRow();
                    dr5["Arrange"] = "Theatre";
                    ListArrange.Rows.Add(dr5);
                }

                ddlArrange.DataSource = ListArrange;
                ddlArrange.DataTextField = ListArrange.Columns[0].ToString();
                ddlArrange.DataValueField = ListArrange.Columns[0].ToString();
                ddlArrange.DataBind();
                ddlArrange.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGridRoomReservation()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Date");
                DataColumn dc2 = new DataColumn("Rate");
                DataColumn dc3 = new DataColumn("RoomRate");
                DataColumn dc4 = new DataColumn("Services");
                DataColumn dc5 = new DataColumn("UnitTaxes");
                DataColumn dc6 = new DataColumn("Extra");
                DataColumn dc7 = new DataColumn("Discount");
                DataColumn dc8 = new DataColumn("Total");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);

                DataRow dr1 = dtTable.NewRow();
                dr1["Date"] = "27-Apr-2012";
                dr1["Rate"] = "58.80";
                dr1["RoomRate"] = "53.80";
                dr1["Services"] = "5.50";
                dr1["UnitTaxes"] = "8.80";
                dr1["Extra"] = "0.00";
                dr1["Discount"] = "0.00";
                dr1["Total"] = "58.80";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Date"] = "28-Apr-2012";
                dr2["Rate"] = "100";
                dr2["RoomRate"] = "100";
                dr2["Services"] = "10";
                dr2["UnitTaxes"] = "5";
                dr2["Extra"] = "0.00";
                dr2["Discount"] = "0.00";
                dr2["Total"] = "110";

                dtTable.Rows.Add(dr2);

                DataRow dr3 = dtTable.NewRow();
                dr3["Date"] = "29-Apr-2012";
                dr3["Rate"] = "150";
                dr3["RoomRate"] = "150";
                dr3["Services"] = "20";
                dr3["UnitTaxes"] = "10";
                dr3["Extra"] = "0.00";
                dr3["Discount"] = "0.00";
                dr3["Total"] = "170";

                dtTable.Rows.Add(dr3);

                gvRoomReservation.DataSource = dtTable;
                gvRoomReservation.DataBind();
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

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Banquet";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Banquet Proposal";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearControlBookingDetail()
        {
            ////Stay Information
            txtArrivalDate.Text = txtNight.Text = txtDepatureDate.Text = txtEvent.Text = "";
            ddlFrequency.SelectedIndex = ddlBanquet.SelectedIndex = ddlArrange.SelectedIndex = ddlAgent.SelectedIndex = ddlRateCard.SelectedIndex = ddlTheam.SelectedIndex = 0;
            txtAdult.Text = "1";
            txtChild.Text = txtInfo.Text = "0";


            ////Guest Information
            ddlTitle.SelectedIndex = 0;
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtZipCode.Text = txtCityName.Text = txtStateName.Text = txtCountryName.Text = txtEmail.Text = txtFaxNo.Text = "";
        }

        #endregion

        #region Grid Event
        protected void gvLabourTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("MANAGER"))
                {
                    Label lblStart = (Label)gvLabourTask.Rows[0].FindControl("lblStart");
                    Label lblEnd = (Label)gvLabourTask.Rows[0].FindControl("lblEnd");

                    txtLabourInfoLabourName.Text = "Raj Rao";
                    txtLabourInfoContacts.Text = "99999999999";
                    txtLabourInfoJobDetail.Text = "Programmar";
                    txtLabourInfoStartTime.Text = lblStart.Text;
                    txtLabourInfoEndTime.Text = lblEnd.Text;
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