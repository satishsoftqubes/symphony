using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlReservationPolicy : System.Web.UI.UserControl
    {
        #region Variable & Property

        public bool IsMessage = false;
        // property to save companyid;
        public Guid ResPolicyID
        {
            get
            {
                return ViewState["ResPolicyID"] != null ? new Guid(Convert.ToString(ViewState["ResPolicyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResPolicyID"] = value;
            }
        }
        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }
        #endregion Variable & Property

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());
                CheckUserAuthorization();
                LoadDefaultValue();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RESERVATIONPOLICY.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                SetPageLabel();
                LoadReservationType();
                GetReservationPolicyData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void GetReservationPolicyData()
        {
            ReservationPolicies GetPolicyData = new ReservationPolicies();
            GetPolicyData.CompanyID = clsSession.CompanyID;
            GetPolicyData.PropertyID = clsSession.PropertyID;
            GetPolicyData.IsActive = true;
            List<ReservationPolicies> LstPolicy = ReservationPoliciesBLL.GetAll(GetPolicyData);
            if (LstPolicy.Count == 1)
            {
                this.ResPolicyID = LstPolicy[0].ResPolicyID;
                txtBeforeCheckInHR.Text = Convert.ToString(Convert.ToInt32(LstPolicy[0].BfrCheckInHrs));
                string strRate = Convert.ToString(Convert.ToDecimal(LstPolicy[0].BfrCharges));
                if (!strRate.Equals(string.Empty) && !strRate.Equals("0"))
                    txtBeforeCharge.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                else
                    txtBeforeCharge.Text = "";

                if (Convert.ToBoolean(LstPolicy[0].IsBfrChargesInPercentage) == true)
                    ddlBeforeCharge.SelectedIndex = 0;
                else
                    ddlBeforeCharge.SelectedIndex = 1;
                

                string strAfter = Convert.ToString(Convert.ToDecimal(LstPolicy[0].AftCharges));
                if (!strAfter.Equals(string.Empty) && !strAfter.Equals("0"))
                    txtAfterCharge.Text = strAfter.Substring(0, strAfter.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                else
                    txtAfterCharge.Text = "";
                txtAfterCheckInHR.Text = Convert.ToString(Convert.ToInt32(LstPolicy[0].AftCheckInHrs));

                if (Convert.ToBoolean(LstPolicy[0].IsAftChargesInPercentage) == true)
                    ddlAfterCharge.SelectedIndex = 0;
                else
                    ddlAfterCharge.SelectedIndex = 1;
                //ddlReservationType.SelectedIndex = ddlReservationType.Items.FindByValue(Convert.ToString(LstPolicy[0].DefaultReservationType_TermID)) != null ? ddlReservationType.Items.IndexOf(ddlReservationType.Items.FindByValue(Convert.ToString(LstPolicy[0].DefaultReservationType_TermID))) : 0;
                ChkIsReasonRequired.Checked = Convert.ToBoolean(LstPolicy[0].IsReasonRequired);
                ChkIsFirstNightChargeCompForCashPayers.Checked = Convert.ToBoolean(LstPolicy[0].IsFirstNightChargeCompForCashPayers);
                ChkIsAssignRoomToUnConfirmRes.Checked = Convert.ToBoolean(LstPolicy[0].IsAssignRoomToUnConfirmRes);
                ChkIsAssignRoomOnReservation.Checked = Convert.ToBoolean(LstPolicy[0].IsAssignRoomOnReservation);
                ChkIsUserCanApplyDiscount.Checked = Convert.ToBoolean(LstPolicy[0].IsUserCanApplyDiscount);
                ChkIsUserCanOverrideRackRate.Checked = Convert.ToBoolean(LstPolicy[0].IsUserCanOverrideRackRate);
                ChkIsUserCanSetTaxExempt.Checked = Convert.ToBoolean(LstPolicy[0].IsUserCanSetTaxExempt);

                //ddlAfterCharge_SelectedIndexChanged(null, null);
                //ddlBeforeCharge_SelectedIndexChanged(null, null);
            }
        }
        /// <summary>
        /// Load Reservation Type
        /// </summary>
        private void LoadReservationType()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            
            //List<ProjectTerm> lstProjectTerm = null;
            //ProjectTerm objProjectTerm = new ProjectTerm();
            //objProjectTerm.IsActive = true;
            //objProjectTerm.CompanyID = clsSession.CompanyID;
            //objProjectTerm.PropertyID = clsSession.PropertyID;
            //objProjectTerm.Category = "RESERVATIONTYPE";
            //lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
            //if (lstProjectTerm.Count != 0)
            //{
            //    ddlReservationType.DataSource = lstProjectTerm;
            //    ddlReservationType.DataTextField = "DisplayTerm";
            //    ddlReservationType.DataValueField = "TermID";
            //    ddlReservationType.DataBind();
            //    ddlReservationType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            //}
            //else
            //    ddlReservationType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            ddlBeforeCharge.Items.Clear();
            ddlBeforeCharge.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlBeforeCharge.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));

            ddlAfterCharge.Items.Clear();
            ddlAfterCharge.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlAfterCharge.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));

        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName ;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblFrontOfficeSetup", "Front Office Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblReservationPolicy", "Reservation Policy") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Label Information
        /// </summary>
        private void SetPageLabel()
        {
            refBeforeCharge.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            refBeforeCharge.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            regAfterCharge.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regAfterCharge.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            litMainHeader.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litMainHeader","Reservation Policy");
            litBeforeCheckInHR.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litBeforeCheckInHR", "Early Check In (Hour)");
            litBeforeCharge.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litBeforeCharge", "Early Check In Charge") + " (" + Convert.ToString(clsSession.CurrentCurrency) + ")";
            //chkBeforeChargeInPercentate.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "chkBeforeChargeInPercentate");
            litAfterCheckInHR.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litAfterCheckInHR", "Late Check Out (Hour)");
            litAfterCharge.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litAfterCharge", "Late Check Out Charge") + " (" + Convert.ToString(clsSession.CurrentCurrency) + ")";
            //chkAfterChargeInPercentate.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "chkAfterChargeInPercentate");
            //litReservationType.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litReservationType","Reservation Type");
            ChkIsReasonRequired.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsReasonRequired","Require Reason");
            ChkIsFirstNightChargeCompForCashPayers.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsFirstNightChargeCompForCashPayers","First Night Charge For Cash Payers");
            ChkIsAssignRoomToUnConfirmRes.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsAssignRoomToUnConfirmRes", "Assign Room To Unconfirmed Res.");
            ChkIsAssignRoomOnReservation.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsAssignRoomOnReservation","Assign Room On Reservation");
            ChkIsUserCanOverrideRackRate.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsUserCanOverrideRackRate","User Can Override Rack Rate");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave","Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel","Cancel");

            ChkIsUserCanApplyDiscount.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsUserCanApplyDiscount","User Can Apply Discount");
            ChkIsUserCanSetTaxExempt.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsUserCanSetTaxExempt", "User Can Set Tax Exempt");

            rbgBeforeCharge.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationPolicy", "rbgBeforeCharge", "Early Check In Charge not more than 100%");
            rgvAfterCharge.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationPolicy", "rgvAfterCharge", "Late Check In Charge not more than 100%");
            
        }
        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GetReservationPolicyData();
        }
        #endregion Button Event

        
    }
}