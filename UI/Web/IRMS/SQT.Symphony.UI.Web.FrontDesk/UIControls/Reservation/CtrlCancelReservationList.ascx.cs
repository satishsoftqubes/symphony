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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlCancelReservationList : System.Web.UI.UserControl
    {
        #region Property and Variables
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

        public int SymphonyValue
        {
            get
            {
                return ViewState["SymphonyValue"] != null ? Convert.ToInt32(ViewState["SymphonyValue"]) : 0;
            }
            set
            {
                ViewState["SymphonyValue"] = value;
            }
        }

        public int CurrentSelectedIndex
        {
            get
            {
                return ViewState["CurrentSelectedIndex"] != null ? Convert.ToInt32(ViewState["CurrentSelectedIndex"]) : -1;
            }
            set
            {
                ViewState["CurrentSelectedIndex"] = value;
            }
        }

        public string strIsCounterValidate
        {
            get
            {
                return ViewState["strIsCounterValidate"] != null ? Convert.ToString(ViewState["strIsCounterValidate"]) : string.Empty;
            }
            set
            {
                ViewState["strIsCounterValidate"] = value;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                LoadDefaultValue();

            }
        }

        #endregion #region Page Load

        #region Control Events

        protected void btnVerificationComplete_OnClick(object sender, EventArgs e)
        {
            mpeOpenAmendment.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    if (this.ReservationID != Guid.Empty)
                    {
                        clsSession.ToEditItemID = this.ReservationID;
                        clsSession.ToEditItemType = "CANCELRESERVATION";
                        Session["CancelOperationRequestModeID"] = Convert.ToString(ddlChangeRequestMode.SelectedValue);
                        Session["CancelOperationRequestBy"] = Convert.ToString(txtChangeRequestBy.Text.Trim());
                        Session["CancelSymphonyValue"] = Convert.ToString(this.SymphonyValue);

                        Response.Redirect("~/GUI/Reservation/CancelReservation.aspx");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvAmendmentList.PageIndex = 0;
                BindReservationGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearch();
                gvAmendmentList.PageIndex = 0;
                BindReservationGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSaveCounterData_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strIsCounterValidate == "YES")
                {
                    mpeOpenCounter.Show();

                    if (ucCommonCounterLogin.ucddlCounter.SelectedIndex != 0)
                        ucCommonCounterLogin.SaveDataInCounter();
                    else
                    {
                        lblCounterErrorMessage.Text = "Please Select Counter.";
                        mpeCounterErrorMessage.Show();
                        return;
                    }
                }

                mpeOpenCounter.Hide();

                if (ucCommonCounterLogin.DefaultCounterID != Guid.Empty && ucCommonCounterLogin.CounterLoginLogID != Guid.Empty)
                {
                    clsSession.DefaultCounterID = ucCommonCounterLogin.DefaultCounterID;
                    clsSession.CounterLoginLogID = ucCommonCounterLogin.CounterLoginLogID;
                    clsSession.CounterName = Convert.ToString(ucCommonCounterLogin.CounterName);
                }

                BindCancelAuthorizationData(this.CurrentSelectedIndex);

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void iBtnCloseCounter_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/AmendmentList.aspx");
        }

        protected void btnCounterErrorMessageOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/AmendmentList.aspx");
        }

        #endregion Control Events

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CancelReservationList.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void LoadDefaultValue()
        {
            try
            {
                litAmendment.Text = "Cancellation";
                litChangeRequestBy.Text = "Cancel Request By";
                litChangeRequestMode.Text = "Cancel Request Mode";
                BindReservationGrid();
                BindResCancelRequestMode();
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
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
            dr4["NameColumn"] = "Cashier";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Cancel Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindReservationGrid()
        {
            try
            {
                string strName = null;
                string strMobileNo = null;
                string strReservationNo = null;

                if (txtSearchName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchName.Text.Trim());

                if (txtSearchMobileNo.Text.Trim() != "")
                    strMobileNo = Convert.ToString(txtSearchMobileNo.Text.Trim());

                if (txtSearcReservationNo.Text.Trim() != "")
                    strReservationNo = "RES#" + Convert.ToString(txtSearcReservationNo.Text.Trim());

                DataSet dsReservationList = ReservationBLL.GetCancelReservationData(clsSession.PropertyID, clsSession.CompanyID, null, strName, strMobileNo,  strReservationNo);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvAmendmentList.DataSource = dsReservationList.Tables[0];
                    gvAmendmentList.DataBind();

                    if (dsReservationList.Tables[1] != null && dsReservationList.Tables[1].Rows.Count > 0)
                        hdnNoOfAmendmentCriteria.Value = Convert.ToString(dsReservationList.Tables[1].Rows[0]["NoOfAmendmentCriteria"]);
                    else
                        hdnNoOfAmendmentCriteria.Value = "";
                }
                else
                {
                    gvAmendmentList.DataSource = null;
                    gvAmendmentList.DataBind();
                    hdnNoOfAmendmentCriteria.Value = "";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearSearch()
        {
            txtSearchName.Text = txtSearchMobileNo.Text = txtSearcReservationNo.Text = "";
        }

        private void BindResCancelRequestMode()
        {
            try
            {
                ddlChangeRequestMode.Items.Clear();
                List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "RESERVATION CANCEL REQUEST MODE");
                if (lstProjectTermTitle.Count != 0)
                {
                    ddlChangeRequestMode.DataSource = lstProjectTermTitle;
                    ddlChangeRequestMode.DataTextField = "DisplayTerm";
                    ddlChangeRequestMode.DataValueField = "TermID";
                    ddlChangeRequestMode.DataBind();
                    ddlChangeRequestMode.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlChangeRequestMode.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetCardNo(string strCardNo)
        {
            string strReturn = "";
            if (strCardNo.Length == 16)
            {
                strReturn = "************" + strCardNo.Substring(12, 4);
            }
            return strReturn;
        }

        private string GetMobileNo(string strPhoneNo)
        {
            string strReturn = "";
            if (Convert.ToString(strPhoneNo) != "")
            {
                string[] str = strPhoneNo.Split('-');
                if (str.Length > 0)
                {
                    if (str.Length > 0 && str[1] != "")
                        strReturn = strPhoneNo;
                    else
                        strReturn = "";
                }
                else
                    strReturn = "";
            }
            return strReturn;
        }

        private void BindCancelAuthorizationData(int index)
        {
            try
            {
                this.ReservationID = new Guid(Convert.ToString(gvAmendmentList.DataKeys[index]["ReservationID"]));

                GridViewRow row = gvAmendmentList.Rows[index]; //(GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                LinkButton lnkGuestName = (LinkButton)row.FindControl("lnkGuestName");
                Label lblGvPhone = (Label)row.FindControl("lblGvPhone");
                Label lblGvCompanyName = (Label)row.FindControl("lblGvCompanyName");
                LinkButton lnkReservationNo = (LinkButton)row.FindControl("lnkReservationNo");

                string strCardNo = Convert.ToString(gvAmendmentList.DataKeys[row.RowIndex]["CardNo"]);
                this.SymphonyValue = Convert.ToInt32(Convert.ToString(gvAmendmentList.DataKeys[row.RowIndex]["SymphonyValue"]));

                litDisplayGuestName.Text = Convert.ToString(lnkGuestName.Text);
                litDisplayResNo.Text = Convert.ToString(lnkReservationNo.Text);
                litDisplayMobileNo.Text = Convert.ToString(lblGvPhone.Text);
                litDisplayEmail.Text = Convert.ToString(gvAmendmentList.DataKeys[row.RowIndex]["Email"]);

                if (strCardNo != "" && strCardNo != null)
                {
                    litDispayCreditCard.Text = Convert.ToString(GetCardNo(strCardNo));
                }
                else
                    litDispayCreditCard.Text = "";
                litDispayCompany.Text = Convert.ToString(lblGvCompanyName.Text);

                mpeOpenAmendment.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Grid Event

        protected void gvAmendmentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("CANCELLATION"))
                {
                    chkMobileNo.Checked = chkEmail.Checked = chkCreditCard.Checked = chkCompanyName.Checked = false;

                    this.CurrentSelectedIndex = Convert.ToInt32(e.CommandArgument);
                    this.CurrentSelectedIndex = this.CurrentSelectedIndex - (gvAmendmentList.PageIndex * gvAmendmentList.PageSize);

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        ucCommonCounterLogin.CounterLoginLogID = ucCommonCounterLogin.DefaultCounterID = Guid.Empty;
                        ucCommonCounterLogin.CounterName = string.Empty;

                        ucCommonCounterLogin.CheckAuthentication();

                        if (ucCommonCounterLogin.strRights == "ALLOWOPEN")
                        {
                            mpeOpenCounter.Show();
                        }
                        else
                        {
                            lblCounterErrorMessage.Text = "You have not permission to do this operation.";
                            mpeCounterErrorMessage.Show();
                            //return;
                        }

                        this.strIsCounterValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        //return;
                    }

                    BindCancelAuthorizationData(this.CurrentSelectedIndex);                    
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvAmendmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAmendmentList.PageIndex = e.NewPageIndex;
            BindReservationGrid();
        }

        protected void gvAmendmentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //System.Web.UI.HtmlControls.HtmlImage
                    int SymphonyValue = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SymphonyValue")));
                    Image imgReservationStatus = (Image)e.Row.FindControl("imgReservationStatus");

                    Label lblGvPhone = (Label)e.Row.FindControl("lblGvPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));

                    lblGvPhone.Text = Convert.ToString(GetMobileNo(strPhoneNo));

                    string strimagesrc = "";
                    string strAltTag = "";

                    switch (SymphonyValue)
                    {
                        case 27:
                            strimagesrc = "~/images/UnConfirmed22x22.png";
                            strAltTag = " Provisional";
                            break;
                        case (28):
                            strimagesrc = "~/images/Confirmed22x22.png";
                            strAltTag = "Confirmed";
                            break;
                        case (29):
                            strimagesrc = "~/images/WaitingList22x22.png";
                            strAltTag = "Waiting List";
                            break;
                        case (32):
                            strimagesrc = "~/images/CheckIn22x22.png";
                            strAltTag = "Check In";
                            break;
                        case (33):
                            strimagesrc = "~/images/CheckOut22x22.png";
                            strAltTag = "Check Out";
                            break;
                        case (34):
                            strimagesrc = "~/images/Cancelled22x22.png";
                            strAltTag = "Cancelled";
                            break;
                    }

                    imgReservationStatus.ImageUrl = strimagesrc;
                    imgReservationStatus.ToolTip = strAltTag;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}