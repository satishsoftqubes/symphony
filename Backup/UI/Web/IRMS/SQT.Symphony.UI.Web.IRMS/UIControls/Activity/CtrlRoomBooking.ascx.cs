using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlRoomBooking : System.Web.UI.UserControl
    {
        #region Variable
        public bool IsInsert = false;
        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }
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
        #endregion Variable

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("PropertyTaxReceipt.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            if (!IsPostBack)
            {
                LoadDefaultData();
                calCheckInDate.Format = calCheckOutDate.Format = this.DateFormat;
            }
        }
        #endregion Form Load 

        #region Private Method
        private void BindPropertyName()
        {
            ddlPropertyName.Items.Clear();
            DataSet ds = PropertyBLL.SelectData(this.CompanyID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";

                ddlPropertyName.DataSource = dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyID";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        private void LoadDefaultData()
        {
            try
            {
                this.DateFormat = "dd-MM-yyyy";
                if (Session["CompanyID"] != null)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                }
                LoadInvestor();
                BindPropertyName();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadInvestor()
        {
            ddlInvestor.Items.Clear();
            DataSet ds = InvestorBLL.GetAllInvestorsForFrontDesk(CompanyID,null);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataView Dv = new DataView(ds.Tables[0]);
                if (Dv.Count > 0)
                {
                    ddlInvestor.DataSource = Dv;
                    ddlInvestor.DataTextField = "InvestorFullName";
                    ddlInvestor.DataValueField = "InvestorID";
                    ddlInvestor.DataBind();
                    ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            else
            {
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }
        private void ClearControlValue()
        {
            LoadInvestor();
            ddlInvestor.SelectedIndex = 0;
            txtInvestorGuestName.Text = "";
            txtNoOfAdult.Text = "";
            txtNoOfChild.Text = "";
            txtTotalGuest.Text = "";
            txtCheckInDate.Text = "";
            txtCheckOutDate.Text = "";
            ddlPropertyName.SelectedIndex = 0;
            //txtComplementorydays.Text = "";
            lblComplementorydays.Text = "";
            lblStoreComplementorydays.Text = "";
            lblNoOfNightTodisp.Text = "";
            //txtNoOfNightTodisp.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtNotes.Text = "";
        }
        #endregion Private Method

        #region Control Event

        protected void ddlInvestor_selectedIndexchange(object sender, EventArgs e)
        {
            lblComplementorydays.Text = "";
            lblStoreComplementorydays.Text = "";
            if (ddlInvestor.SelectedIndex > 0 && ddlInvestor.SelectedValue != null && ddlInvestor.SelectedValue != string.Empty)
            {
                string Query = "Select ComplementaryDays FROM irm_investor Where CompanyID = '" + this.CompanyID + "' And InvestorID = '" + ddlInvestor.SelectedValue + "'";
                DataSet dsForComplementoryDats = InvestorBLL.GetSearchData(Query);
                if (dsForComplementoryDats != null && dsForComplementoryDats.Tables.Count > 0 && dsForComplementoryDats.Tables[0].Rows.Count > 0 && dsForComplementoryDats.Tables[0].Rows[0]["ComplementaryDays"] != null)
                {
                    //txtComplementorydays.Text = Convert.ToString(dsForComplementoryDats.Tables[0].Rows[0]["ComplementaryDays"]);
                    lblComplementorydays.Text = "<b>No of complementory days :</b>";
                    lblStoreComplementorydays.Text = Convert.ToString(dsForComplementoryDats.Tables[0].Rows[0]
["ComplementaryDays"]);
//                    lblStoreComplementorydays = Convert.ToString(dsForComplementoryDats.Tables[0].Rows[0]
//["ComplementaryDays"]);
                }
                else
                {
                    //txtComplementorydays.Text = "";
                    lblComplementorydays.Text = "";
                    lblStoreComplementorydays.Text = "";
                }
            }
            else
            {
                //txtComplementorydays.Text = "";
                lblComplementorydays.Text = "";
                lblStoreComplementorydays.Text = "";
            }
        }

        protected void txtCheckOutDate_TextChange(object sender, EventArgs e)
        {
            lblNoOfNightTodisp.Text = "";

            if (txtCheckInDate.Text == null || txtCheckInDate.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                litMessageBox.Text = "Please select checkin date first";
                ((TextBox)sender).Text = "";
                mpeMessageBox.Show();
                return;
            }
            else
            {
                string strCheckOutDate = ((TextBox)sender).Text;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                DateTime dtCheckInDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), this.DateFormat, objCultureInfo);
                DateTime dtCheckOutDate = DateTime.ParseExact(strCheckOutDate, this.DateFormat, objCultureInfo);

                if (dtCheckOutDate.Date <= dtCheckInDate.Date)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    litMessageBox.Text = "Checkout date must be greater than checkin date";
                    ((TextBox)sender).Text = "";
                    mpeMessageBox.Show();
                    return;
                }
                else
                {
                    TimeSpan totalNight = dtCheckOutDate.Date - dtCheckInDate.Date;
                    lblNoOfNightTodisp.Text = "<b>No of Days : </b>" + Convert.ToString(totalNight.TotalDays);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime dtCheckInDate = DateTime.ParseExact(txtCheckInDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    DateTime dtCheckOutDate = DateTime.ParseExact(txtCheckOutDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    int reservationDays = (Convert.ToInt32((dtCheckOutDate - dtCheckInDate).TotalDays));

                    if ((Convert.ToInt32(lblStoreComplementorydays.Text) - reservationDays) < 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        litMessageBox.Text = "No of night should be less than available days";
                        mpeMessageBox.Show();
                        return;
                    }
                    ReservationVoucher objResVoucher = new ReservationVoucher();

                    objResVoucher.InvestorID = new Guid(Convert.ToString(ddlInvestor.SelectedValue));
                    objResVoucher.GuestName = txtInvestorGuestName.Text.Trim();
                    objResVoucher.Adult = Convert.ToInt32(txtNoOfAdult.Text.Trim());
                    objResVoucher.Children = Convert.ToInt32(txtNoOfChild.Text.Trim());
                    objResVoucher.CheckInDate = dtCheckInDate;
                    objResVoucher.CheckOutDate = dtCheckOutDate;
                    objResVoucher.NoOfRoom = Convert.ToInt32(litViewNoOfRoom.Text);
                    objResVoucher.TotalGuest = Convert.ToInt32(txtTotalGuest.Text.Trim());
                    if (this.CompanyID != null && this.CompanyID != Guid.Empty)
                        objResVoucher.CompanyID = this.CompanyID;
                    else
                        objResVoucher.CompanyID = null;

                    if (ddlPropertyName.SelectedIndex > 0)
                    {
                        objResVoucher.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                    }
                    else
                    {
                        objResVoucher.PropertyID = null;
                    }

                    objResVoucher.Notes = Convert.ToString(txtNotes.Text.Trim());
                    objResVoucher.CreatedBy = objResVoucher.ApprovedBy  = new Guid(Convert.ToString(HttpContext.Current.Session["UserID"]));
                    objResVoucher.CreatedOn = objResVoucher.ApprovedOn  = DateTime.Now;
                    objResVoucher.CreatedBy_Term = "IR MANAGEMENT";

                    if(chkIsUtilizedVoucher.Checked)
                        objResVoucher.Status_Term = "UTILIZED";
                    else
                        objResVoucher.Status_Term = "APPROVED";
                    
                    objResVoucher.TotalNights = reservationDays;
                    objResVoucher.Email = txtEmail.Text.Trim();
                    objResVoucher.Phone = txtPhone.Text.Trim();
                    ReservationVoucherBLL.Save(objResVoucher);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objResVoucher.ToString(), objResVoucher.ToString(), "irs_ReservationVoucher");
                    IsInsert = true;
                    lblProsMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    ClearControlValue();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Activity/RoomBookingList.aspx");
        }

        protected void chkIsUtilizedVoucher_OnCheckedChanged(object sender, EventArgs e)
        {
            if (chkIsUtilizedVoucher.Checked)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show("This voucher will be considered as utilized voucher and Front desk executive can't maike reservation using this voucher.");
            }
        }

        #endregion Control Event
    }
}