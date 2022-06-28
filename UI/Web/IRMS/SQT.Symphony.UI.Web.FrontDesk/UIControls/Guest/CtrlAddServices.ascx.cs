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
using System.Globalization;
using System.Drawing;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlAddServices : System.Web.UI.UserControl
    { 
        #region Property and Variable

        public bool IsInsert = false;
        public bool IsListMessage = false;

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

        public int RowIndex
        {
            get
            {
                return ViewState["RowIndex"] != null ? Convert.ToInt32(ViewState["RowIndex"]) : 0;
            }
            set
            {
                ViewState["RowIndex"] = value;
            }
        }

        public string strIsValidate
        {
            get
            {
                return ViewState["strIsValidate"] != null ? Convert.ToString(ViewState["strIsValidate"]) : string.Empty;
            }
            set
            {
                ViewState["strIsValidate"] = value;
            }
        }

        public string strOpenModalDialog
        {
            get
            {
                return ViewState["strOpenModalDialog"] != null ? Convert.ToString(ViewState["strOpenModalDialog"]) : string.Empty;
            }
            set
            {
                ViewState["strOpenModalDialog"] = value;
            }
        }

        public Guid ResAddOnServiceID
        {
            get
            {
                return ViewState["ResAddOnServiceID"] != null ? new Guid(Convert.ToString(ViewState["ResAddOnServiceID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResAddOnServiceID"] = value;
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

        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
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

        public DateTime StartDate
        {
            get
            {
                return ViewState["StartDate"] != null ? Convert.ToDateTime(ViewState["StartDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["StartDate"] = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return ViewState["ExpiryDate"] != null ? Convert.ToDateTime(ViewState["ExpiryDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["ExpiryDate"] = value;
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
                if (Session["ReservationIdForAddOnService"] != null)
                {
                    this.ReservationID = new Guid(Session["ReservationIdForAddOnService"].ToString());
                    this.GuestID = new Guid(Session["GuestIDForAddOnService"].ToString());
                    this.FolioID = new Guid(Session["FolioIDForAddOnService"].ToString());

                    Session.Remove("ReservationIdForAddOnService");
                    Session.Remove("GuestIDForAddOnService");
                    Session.Remove("FolioIDForAddOnService");
                }
                else
                    Response.Redirect("~/GUI/Guest/AddOnServices.aspx");

                BindddlServices();
                BindGrid();
                BindBreadCrumb();
                BindGuestBasicDetails();
            }
        }

        #endregion Page Load

        #region Button Event

        protected void btnAddTop_Click(object sender, EventArgs e)
        {
            ClearControl();
            ddlServices.Enabled = true;
            mpeOpenAddServices.Show();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Guest/AddOnServices.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Page.IsValid)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (this.ResAddOnServiceID != Guid.Empty)
                    {
                        ResAddOnServiceList objResOnServiceListUpd = new ResAddOnServiceList();
                        objResOnServiceListUpd = ResAddOnServiceListBLL.GetByPrimaryKey(this.ResAddOnServiceID);
                        objResOnServiceListUpd.GuestID = this.GuestID;
                        objResOnServiceListUpd.ItemID = new Guid(ddlServices.SelectedValue);
                        objResOnServiceListUpd.FolioID = this.FolioID;
                        objResOnServiceListUpd.StatusRemark = "Active";
                        objResOnServiceListUpd.Amount = Convert.ToDecimal("0");
                        objResOnServiceListUpd.Qty = Convert.ToDecimal("1");
                        objResOnServiceListUpd.Total = Convert.ToDecimal("0");
                        objResOnServiceListUpd.ServiceDate = DateTime.Now;
                        objResOnServiceListUpd.StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objResOnServiceListUpd.ExpiryDate = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objResOnServiceListUpd.Notes = clsCommon.GetUpperCaseText(txtNotes.Text.Trim());
                        objResOnServiceListUpd.PropertyID = clsSession.PropertyID;
                        objResOnServiceListUpd.CompanyID = clsSession.CompanyID;
                        objResOnServiceListUpd.UpdatedOn = DateTime.Now;
                        objResOnServiceListUpd.UpdatedBy = clsSession.UserID;
                        objResOnServiceListUpd.IsActive = true;
                        objResOnServiceListUpd.ServiceStatus_Term = "Active";

                        ResAddOnServiceListBLL.Update(objResOnServiceListUpd);
                        BindGrid();
                        MessageBox.Show("Services Updated Successfully.");
                        ClearControl();
                    }
                    else
                    {
                        ResAddOnServiceList objResAddOnServiceListIns = new ResAddOnServiceList();
                        objResAddOnServiceListIns.ReservationID = this.ReservationID;
                        objResAddOnServiceListIns.GuestID = this.GuestID;
                        objResAddOnServiceListIns.ItemID = new Guid(ddlServices.SelectedValue);
                        objResAddOnServiceListIns.FolioID = this.FolioID;
                        objResAddOnServiceListIns.StatusRemark = "Active";
                        objResAddOnServiceListIns.Amount = Convert.ToDecimal("0");
                        objResAddOnServiceListIns.Qty = Convert.ToDecimal("1");
                        objResAddOnServiceListIns.Total = Convert.ToDecimal("0");
                        objResAddOnServiceListIns.ServiceDate = DateTime.Now;
                        objResAddOnServiceListIns.StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objResAddOnServiceListIns.ExpiryDate = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objResAddOnServiceListIns.Notes = clsCommon.GetUpperCaseText(txtNotes.Text.Trim());
                        objResAddOnServiceListIns.PropertyID = clsSession.PropertyID;
                        objResAddOnServiceListIns.CompanyID = clsSession.CompanyID;
                        objResAddOnServiceListIns.IsActive = true;
                        objResAddOnServiceListIns.ServiceStatus_Term = "Active";

                        ResAddOnServiceListBLL.Save(objResAddOnServiceListIns);
                        BindGrid();
                        MessageBox.Show("Services addes Successfully.");
                        ClearControl();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Pop Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    ResAddOnServiceList objDelete = new ResAddOnServiceList();
                    objDelete = ResAddOnServiceListBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    objDelete.IsDelete = true;
                    objDelete.UpdatedBy = clsSession.UserID;
                    objDelete.UpdatedOn = DateTime.Now;

                    ResAddOnServiceListBLL.Update(objDelete);

                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "res_ResAddOnServiceList");
                    IsListMessage = true;
                    MessageBox.Show("Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Pop Button Event

        #region Private Method

        public void BindddlServices()
        {
            try
            {
                DataSet dstItemTypeTermID = ResAddOnServiceListBLL.GetResAddOnServiceListItemTypeTermIDServiceName(clsSession.CompanyID, clsSession.PropertyID);

                if (dstItemTypeTermID != null && dstItemTypeTermID.Tables[0].Rows.Count > 0)
                {
                    ddlServices.DataSource = dstItemTypeTermID.Tables[0];
                    ddlServices.DataTextField = "ItemName";
                    ddlServices.DataValueField = "ItemID";
                    ddlServices.DataBind();
                    ddlServices.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                {
                    ddlServices.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
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

        private void ClearControl()
        {
            txtStartDate.Text = txtEndDate.Text = txtNotes.Text = "";
            ddlServices.SelectedIndex = 0;
        }

        private void BindGrid()
        {
            try
            {
                if (this.ReservationID == Guid.Empty || this.GuestID == Guid.Empty)
                {
                    Response.Redirect("~/GUI/Guest/AddOnServices.aspx");
                }

                DataSet dsServices = ResAddOnServiceListBLL.GetResAddOnServiceListWithServiceName(this.ReservationID, this.GuestID, null, clsSession.CompanyID, clsSession.PropertyID);

                if (dsServices != null && dsServices.Tables.Count > 0 && dsServices.Tables[0].Rows.Count > 0)
                {
                    gvGuestListAddOnServicesList.DataSource = dsServices.Tables[0];
                    gvGuestListAddOnServicesList.DataBind();
                }
                else
                {
                    gvGuestListAddOnServicesList.DataSource = null;
                    gvGuestListAddOnServicesList.DataBind();
                }
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

        private void BindGuestBasicDetails()
        {
            if (this.ReservationID != Guid.Empty)
            {
                DataSet dsGuestReservationData = ResAddOnServiceListBLL.GetCurrentGuestListDataAddOnServices(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, null, null, null, null, null, null);

                if (dsGuestReservationData.Tables.Count > 0 && dsGuestReservationData.Tables[0].Rows.Count > 0)
                {
                    DataRow drGuestResData = dsGuestReservationData.Tables[0].Rows[0];

                    this.GuestID = new Guid(Convert.ToString(drGuestResData["GuestID"]));
                    this.StartDate = Convert.ToDateTime(Convert.ToString(drGuestResData["CheckInDate"]));
                    this.ExpiryDate = Convert.ToDateTime(Convert.ToString(drGuestResData["CheckOutDate"]));

                    DateTime dtStartDate = Convert.ToDateTime(Convert.ToString(drGuestResData["CheckInDate"]));
                    DateTime dtExpiryDate = Convert.ToDateTime(Convert.ToString(drGuestResData["CheckOutDate"]));

                    ltrAddServicesGuestNameReservationNo.Text = Convert.ToString(drGuestResData["GuestFullName"]);
                    ltrAddServicesReservationNo.Text = Convert.ToString(drGuestResData["ReservationNo"]);
                    ltrAddServicesCheckInDate.Text = dtStartDate.ToString("dd-MM-yyyy");
                    ltrAddServicesCheckOutDate.Text = dtExpiryDate.ToString("dd-MM-yyyy");
                    ltrAddServicesRateCard.Text = Convert.ToString(drGuestResData["RateCardName"]);
                    ltrAddServicesRoomType.Text = Convert.ToString(drGuestResData["RoomTypeName"]);
                    ltrAddServicesRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(drGuestResData["RoomNo"]));
                }
                else
                {
                    ltrAddServicesGuestNameReservationNo.Text = "";
                    ltrAddServicesReservationNo.Text = "";
                    ltrAddServicesCheckInDate.Text = "";
                    ltrAddServicesCheckOutDate.Text = "";
                    ltrAddServicesRateCard.Text = "";
                    ltrAddServicesRoomType.Text = "";
                    ltrAddServicesRoomNo.Text = "";
                }
            }
        }

        #endregion Private Method

        #region Grid Event

        protected void gvGuestListAddOnServicesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestListAddOnServicesList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvGuestListAddOnServicesList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((Label)e.Row.FindControl("lblGvStartDate")).Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StartDate"))).ToString(clsSession.DateFormat);
                    ((Label)e.Row.FindControl("lblGvEndDate")).Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ExpiryDate"))).ToString(clsSession.DateFormat);
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ResAddOnServiceID")));
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvStatus = (Label)e.Row.FindControl("lblGvStatus");
                    if (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExpiryDate")).Date < System.DateTime.Now.Date)
                    {
                        lblGvStatus.Text = "Expired";
                    }
                    else
                    {
                        lblGvStatus.Text = "Active";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }

        protected void gvGuestListAddOnServicesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    mpeOpenAddServices.Show();
                    this.ResAddOnServiceID = new Guid(Convert.ToString(e.CommandArgument));
                    ResAddOnServiceList objResAddOnServiceListEdit = new ResAddOnServiceList();
                    objResAddOnServiceListEdit = ResAddOnServiceListBLL.GetByPrimaryKey(this.ResAddOnServiceID);
                    if (objResAddOnServiceListEdit != null)
                    {
                        ddlServices.Enabled = false;
                        ddlServices.SelectedValue = objResAddOnServiceListEdit.ItemID.ToString();
                        txtStartDate.Text = Convert.ToDateTime(Convert.ToString(objResAddOnServiceListEdit.StartDate)).ToString(clsSession.DateFormat);
                        txtEndDate.Text = Convert.ToDateTime(Convert.ToString(objResAddOnServiceListEdit.ExpiryDate)).ToString(clsSession.DateFormat);
                        txtNotes.Text = objResAddOnServiceListEdit.Notes.Trim();
                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.ResAddOnServiceID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
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