using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlCashCardList : System.Web.UI.UserControl
    {
        #region Property and Variable

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

        #endregion Property and Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindGrid();
            }
        }

        #endregion Page Load

        #region Private Method
        private void ClearControl()
        {
            txtCashCard.Text = "";
            txtSearchName.Text = "";
            txtSearchUnitNo.Text = "";
            txtSearcReservationNo.Text = "";
            txtSearchMobileNo.Text = "";
        }
        
        private void BindGrid()
        {
            try
            {
                string strName = null;
                string strCashCardNo = null;
                string strMobileNo = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? BillingInstructionID = null;
                if (txtCashCard.Text.Trim() != "")
                    strCashCardNo = txtCashCard.Text.Trim();

                if (txtSearchName.Text.Trim() != "")
                    strName = txtSearchName.Text.Trim();

                if (txtSearchMobileNo.Text.Trim() != "")
                    strMobileNo = txtSearchMobileNo.Text.Trim();

                if (txtSearcReservationNo.Text.Trim() != "")
                    strReservationNo = "RES#" + txtSearcReservationNo.Text.Trim();


                if (txtSearchUnitNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchUnitNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }
                DataSet dsReservationData = ResAddOnServiceListBLL.GetCurrentGuestListDataAddOnServices(null, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, strRoomNo, BillingInstructionID, strCashCardNo);

                gvGuestListAddOnServices.DataSource = dsReservationData.Tables[0];
                gvGuestListAddOnServices.DataBind();
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
            dr4["NameColumn"] = "Cashier";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "AddOn Services";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion Private Method

        #region Control Event
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void imgbtnClearSearch_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            BindGrid();
        }
        protected void btnSaveCashcardNo_OnClick(object sender, EventArgs e)
        {
            try
            {
                ReservationGuestBLL.Update_CashcardNumber(this.ReservationID, this.GuestID, txtCashcardNumber.Text, clsSession.PropertyID, clsSession.CompanyID, clsSession.UserID);

                txtCashcardNumber.Text = "";

                MessageBox.Show("Cashcard assigned successfully.");
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imbCloseCashcardAssignmentPopup_OnClick(object sender, EventArgs e)
        {
            txtCashcardNumber.Text = "";
        }
        #endregion

        #region Grid Event

        protected void gvGuestListAddOnServices_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestListAddOnServices.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvGuestListAddOnServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvPhone = (Label)e.Row.FindControl("lblGvPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvGuestListAddOnServices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("CASHCARD"))
                {
                    string[] strAddonserviceinfo = Convert.ToString(e.CommandArgument).Split(',');
                    this.ReservationID = new Guid(strAddonserviceinfo[0].ToString());
                    this.GuestID = new Guid(strAddonserviceinfo[1].ToString());

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    lblBookingNo.Text = ((Label)row.FindControl("lblReservationNo")).Text;
                    lblGuestName.Text = ((Label)row.FindControl("lblGuestName")).Text;

                    ReservationGuest objResGuest = new ReservationGuest();
                    objResGuest.ReservationID = this.ReservationID;
                    objResGuest.GuestID = this.GuestID;
                    objResGuest.IsActive = true;
                    List<ReservationGuest> lstGuest = ReservationGuestBLL.GetAll(objResGuest);
                    if (lstGuest != null && lstGuest.Count > 0)
                    {
                        if (lstGuest[0].Cashcard_Number != null && Convert.ToString(lstGuest[0].Cashcard_Number) != string.Empty)
                        {
                            txtCashcardNumber.Text = Convert.ToString(lstGuest[0].Cashcard_Number);
                        }
                    }

                    mpeCashcardAssignment.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}