using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrCommonGuestInfo : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Control Events
        protected void btnAddGuest_Click(object sender, EventArgs e)
        {
            ddlIDType.SelectedIndex = ddlGuestTitle.SelectedIndex = 0;
            txtGuestFirstName.Text = txtGuestLastName.Text = txtGuestDOB.Text = txtIDDetail.Text = txtEmail.Text = txtMobileNo.Text = "";

            mpeAddGuest.Show();
            BindGuestList();
        }

        //protected void btnAddCardDetails_Click(object sender, EventArgs e)
        //{
        //    if (this.Page.IsValid)
        //    {
        //        if (ddlPMT.SelectedValue == "Card")
        //        {
        //            CtrlCommonCardInfo.ucMpeAddEditCardInfo.Show();

        //            CtrlCommonCardInfo.uclitDisplayCardHolderName.Text = CtrlCommonCardInfo.uctxtCardHolderName.Text = Convert.ToString(ddlTitle.SelectedValue + " " + txtFirstName.Text.Trim());
        //            CtrlCommonCardInfo.ClearControlCardInfo();
        //            CtrlCommonCardInfo.BindCardListGrid();
        //        }
        //    }
        //}

        protected void lnkComplementaryReservation_OnClick(object sender, EventArgs e)
        {
            if (trComplementoryReservationType.Visible == false)
            {
                trComplementoryReservationType.Visible = true;
            }
            else
            {
                ddlComplementoryRefBy.SelectedIndex = ddlInvestor.SelectedIndex = 0;
                trComplementoryReservationType.Visible = trInvestors.Visible = false;
            }
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Folio/GuestProfile.aspx?RoomReservation=true");
        }

        protected void btnSearchGuestInfo_Click(object sender, EventArgs e)
        {
            mpeSearchGuestInfo.Show();
            txtSearchGuestName.Text = "";
            gvSearchGuestList.DataSource = null;
            gvSearchGuestList.DataBind();
        }

        protected void btnSearchGuest_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("Name");
                DataColumn dc2 = new DataColumn("Email");
                DataColumn dc3 = new DataColumn("DOB");
                DataColumn dc4 = new DataColumn("MobileNo");
                DataColumn dc5 = new DataColumn("Country");
                DataColumn dc6 = new DataColumn("State");
                DataColumn dc7 = new DataColumn("City");


                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);
                dtService.Columns.Add(dc6);
                dtService.Columns.Add(dc7);

                DataRow dr1 = dtService.NewRow();
                dr1["Name"] = "Mr. Jayesh Rathod";
                dr1["Email"] = "jayesh@gmail.com";
                dr1["MobileNo"] = "7589321545";
                dr1["DOB"] = "01/01/1990";
                dr1["Country"] = "India";
                dr1["State"] = "Gujarat";
                dr1["City"] = "Ahmedabad";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["Name"] = "Miss. Palak Jain";
                dr2["Email"] = "palak@sqt.in";
                dr2["MobileNo"] = "9825674123";
                dr2["DOB"] = "12/10/1980";
                dr2["Country"] = "India";
                dr2["State"] = "Gujarat";
                dr2["City"] = "Ahmedabad";

                dtService.Rows.Add(dr2);

                gvSearchGuestList.DataSource = dtService;
                gvSearchGuestList.DataBind();

                mpeSearchGuestInfo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlInvestor_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlInvestor.SelectedIndex != 0)
                {
                    ddlTitle.SelectedIndex = 2;

                    if (ddlInvestor.SelectedIndex == 1)
                    {
                        txtFirstName.Text = "Pradeep";
                        txtLastName.Text = "Patel";
                    }
                    else
                    {
                        txtFirstName.Text = "Shyam";
                        txtLastName.Text = "Benegal";
                    }
                }
                else
                {
                    ddlTitle.SelectedIndex = 0;
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlComplementoryRefBy_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlComplementoryRefBy.SelectedValue.ToUpper() == "INVESTOR")
                {
                    trInvestors.Visible = true;
                }
                else
                {
                    trInvestors.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddDeposit_Click(object sender, EventArgs e)
        {
            CtrlCommonAddDeposit1.ucMvDeposit.ActiveViewIndex = 1;
            mpeDeposit.Show();
        }

        protected void btnAddDepositCallParent_Click(object sender, EventArgs e)
        {
            CtrlCommonAddDeposit1.ucMvDeposit.ActiveViewIndex = 1;
            mpeDeposit.Show();
        }
        #endregion 

        protected void ddlModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlModeOfPayment.SelectedIndex == 0 || ddlModeOfPayment.SelectedIndex == 1)
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = false;
                }
                else if (ddlModeOfPayment.SelectedIndex == 2 || ddlModeOfPayment.SelectedIndex == 3)
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = false;
                    trChequeDD1.Visible = trChequeDD2.Visible = true;
                }
                else if (ddlModeOfPayment.SelectedIndex == 4)
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = false;
                    trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = trCreditCard5.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue.ToString().ToUpper() == "CONFIRMED")
                {
                    trAssignRoom.Visible = trAssignedRoomNo.Visible = true;
                }
                else
                {
                    trAssignRoom.Visible = trAssignedRoomNo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #region Private Method

        private void BindGuestList()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("Name");
                DataColumn dc2 = new DataColumn("Email");
                DataColumn dc3 = new DataColumn("IDType");
                DataColumn dc4 = new DataColumn("MobileNo");
                DataColumn dc5 = new DataColumn("DOB");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);

                DataRow dr1 = dtService.NewRow();
                dr1["Name"] = "Mr. Jayesh Rathod";
                dr1["Email"] = "jayesh@gmail.com";
                dr1["IDType"] = "Licence No.";
                dr1["MobileNo"] = "7589321545";
                dr1["DOB"] = "01-01-1990";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["Name"] = "Miss. Palak Jain";
                dr2["Email"] = "palak@sqt.in";
                dr2["IDType"] = "Passport";
                dr2["MobileNo"] = "9825674123";
                dr2["DOB"] = "10-10-1980";

                dtService.Rows.Add(dr2);

                gvGuestList.DataSource = dtService;
                gvGuestList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion  Private Method

        #region Grid Event

        protected void gvSearchGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("SEARCHGUEST"))
                {
                    string strGuestName = Convert.ToString(e.CommandArgument);
                    if (strGuestName == "Mr. Jayesh Rathod")
                    {
                        ddlTitle.SelectedIndex = 2;
                        txtFirstName.Text = "Jayesh";
                        txtLastName.Text = "Rathod";
                        txtMobile.Text = "7589321545";
                        txtGuestEmail.Text = "jayesh@gmail.com";
                        txtCountryName.Text = "India";
                        txtStateName.Text = "Gujarat";
                        txtCityName.Text = "Ahmedabad";
                        txtZipCode.Text = "382345";
                        txtAddress.Text = "a-7 Meghmalhar soc. nr. niklol road";

                    }
                    else if (strGuestName == "Miss. Palak Jain")
                    {
                        ddlTitle.SelectedIndex = 1;
                        txtFirstName.Text = "Palak";
                        txtLastName.Text = "Jain";
                        txtMobile.Text = "9825674123";
                        txtGuestEmail.Text = "palak@sqt.in";
                        txtCountryName.Text = "India";
                        txtStateName.Text = "Gujarat";
                        txtCityName.Text = "Ahmedabad";
                        txtZipCode.Text = "382346";
                        txtAddress.Text = "15 Rajdhani soc. new india colony";
                    }
                    mpeSearchGuestInfo.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}