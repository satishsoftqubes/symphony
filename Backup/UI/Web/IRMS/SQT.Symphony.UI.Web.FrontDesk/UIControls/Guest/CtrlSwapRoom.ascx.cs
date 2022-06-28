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
    public partial class CtrlSwapRoom : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }

        #endregion

        #region DropDown Event

        //protected void ddlSwapUnitUnitType_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (ddlSwapUnitUnitType.SelectedIndex != 0)
        //    {
        //        btnSwapUnitHistory.Visible = btnSwapUnitSave.Visible = true;
        //        BindSwapUnitGrid();
        //    }
        //    else
        //    {
        //        btnSwapUnitHistory.Visible = btnSwapUnitSave.Visible = false;
        //        gvSwapUnitList.DataSource = null;
        //        gvSwapUnitList.DataBind();
        //    }
        //}

        #endregion DropDown Event

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                gvSwapUnitList.DataSource = null;
                gvSwapUnitList.DataBind();
                mvSwapUnit.ActiveViewIndex = 0;
                BindRoomType();
                BindGrid();
                BindBreadCrumb();                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRoomType()
        {
            try
            {
                string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";

                ddlSearchSwapUnitUnitType.Items.Clear();
                ddlSearchRoomType.Items.Clear();

                DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);
                if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
                {
                    ddlSearchSwapUnitUnitType.DataSource = dsRoomType.Tables[0];
                    ddlSearchSwapUnitUnitType.DataTextField = "RoomTypeName";
                    ddlSearchSwapUnitUnitType.DataValueField = "RoomTypeID";
                    ddlSearchSwapUnitUnitType.DataBind();

                    ddlSearchSwapUnitUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
                    ddlSearchRoomType.DataTextField = "RoomTypeName";
                    ddlSearchRoomType.DataValueField = "RoomTypeID";
                    ddlSearchRoomType.DataBind();

                    ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlSearchSwapUnitUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindSwapUnitGrid()
        {
            try
            {
                string strName = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? RoomTypeID = null;

                if (txtSearchSwapUnitGuestName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchSwapUnitGuestName.Text.Trim());

                if (txtSearchSwapUnitBookingNo.Text.Trim() != "")
                    strReservationNo = Convert.ToString(txtSearchSwapUnitBookingNo.Text.Trim());


                if (txtSearchSwapUnitRoomNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchSwapUnitRoomNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }

                if (ddlSearchSwapUnitUnitType.SelectedIndex != 0)
                    RoomTypeID = new Guid(ddlSearchSwapUnitUnitType.SelectedValue);

                DataSet dsReservationList = ReservationBLL.GetSwapRoomList(clsSession.PropertyID, clsSession.CompanyID, strName, strReservationNo, strRoomNo, RoomTypeID);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvSwapUnitList.DataSource = dsReservationList.Tables[0];
                    gvSwapUnitList.DataBind();
                }
                else
                {
                    gvSwapUnitList.DataSource = null;
                    gvSwapUnitList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindSwapUnitHistoryGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("OldUnitNo");
                DataColumn dc2 = new DataColumn("NewUnitNo");
                DataColumn dc3 = new DataColumn("DateOfSwap");
                DataColumn dc4 = new DataColumn("Reason");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["OldUnitNo"] = "101";
                dr1["NewUnitNo"] = "102";
                dr1["DateOfSwap"] = "10-08-2012";
                dr1["Reason"] = "";

                dtTable.Rows.Add(dr1);

                gvSwapUnitHistoryList.DataSource = dtTable;
                gvSwapUnitHistoryList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
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
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Swap Room";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        
        private void ClearListData()
        {
            txtSearchBookingNo.Text = txtSearchGuestName.Text = txtSearchRoomNo.Text = "";
            ddlSearchRoomType.SelectedIndex = 0;
        }

        private void ClearSearchData()
        {
            txtSearchSwapUnitBookingNo.Text = txtSearchSwapUnitGuestName.Text = txtSearchSwapUnitRoomNo.Text = "";
            ddlSearchSwapUnitUnitType.SelectedIndex = 0;
        }

        private void BindGrid()
        {
            try
            {
                string strName = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? RoomTypeID = null;

                if (txtSearchGuestName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchGuestName.Text.Trim());

                if (txtSearchBookingNo.Text.Trim() != "")
                    strReservationNo = Convert.ToString(txtSearchBookingNo.Text.Trim());


                if (txtSearchRoomNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchRoomNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }

                if (ddlSearchRoomType.SelectedIndex != 0)
                    RoomTypeID = new Guid(ddlSearchRoomType.SelectedValue);

                DataSet dsReservationList = ReservationBLL.GetSwapRoomList(clsSession.PropertyID, clsSession.CompanyID, strName, strReservationNo, strRoomNo, RoomTypeID);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvResevationList.DataSource = dsReservationList.Tables[0];
                    gvResevationList.DataBind();
                }
                else
                {
                    gvResevationList.DataSource = null;
                    gvResevationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Control Event

        protected void btnSwapUnitHistory_Click(object sender, EventArgs e)
        {
            BindSwapUnitHistoryGrid();
            mvSwapUnit.ActiveViewIndex = 1;
        }

        protected void btnSwapUnitHistoryCancel_Click(object sender, EventArgs e)
        {
            mvSwapUnit.ActiveViewIndex = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSwapUnitGrid();
        }

        protected void imgbtnSearchListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            BindGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            gvSwapUnitList.PageIndex = 0;
            ClearSearchData();
            BindSwapUnitGrid();
        }

        protected void imgbtnClearListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            ClearListData();
            BindGrid();
        }

        protected void btnSwapUnitCancel_Click(object sender, EventArgs e)
        {
            mvSwapUnit.ActiveViewIndex = 0;
        }

        #endregion

        #region Grid Event

        protected void gvSwapUnitList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvPhone = (Label)e.Row.FindControl("lblGvPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));

                    Label lblGvRoomNo = (Label)e.Row.FindControl("lblGvRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    //Label lblGvBalance = (Label)e.Row.FindControl("lblGvBalance");
                    //decimal dcmlBalance = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Balance"));
                    //lblGvBalance.Text = dcmlBalance.ToString().Substring(0, dcmlBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvListPhone = (Label)e.Row.FindControl("lblGvListPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvListPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));

                    Label lblGvListRoomNo = (Label)e.Row.FindControl("lblGvListRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvListRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("SWAPROOM"))
                {
                    mvSwapUnit.ActiveViewIndex = 1;

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvListReservationNo = (Label)row.FindControl("lblGvListReservationNo");
                    Label lblGvListRoomTypeName = (Label)row.FindControl("lblGvListRoomTypeName");
                    Label lblGvListRoomNo = (Label)row.FindControl("lblGvListRoomNo");
                    Label lblGvListName = (Label)row.FindControl("lblGvListName");
                    Label lblGvListCheckInDate = (Label)row.FindControl("lblGvListCheckInDate");
                    Label lblGvListCheckOutDate = (Label)row.FindControl("lblGvListCheckOutDate");


                    litDisplaySwapUnitRoomType.Text = Convert.ToString(lblGvListRoomTypeName.Text.Trim());
                    litDisplaySwapUnitBookingNo.Text = Convert.ToString(lblGvListReservationNo.Text.Trim());
                    litDisplaySwapUnitName.Text = Convert.ToString(lblGvListName.Text.Trim());

                    decimal dcBalance = Convert.ToDecimal(gvResevationList.DataKeys[row.RowIndex]["Balance"].ToString());

                    litDisplaySwapUnitCheckInDate.Text = Convert.ToString(lblGvListCheckInDate.Text.Trim());
                    litDisplaySwapUnitCheckOutDate.Text = Convert.ToString(lblGvListCheckOutDate.Text.Trim());
                    litDisplaySwapUnitFolioBalance.Text = dcBalance.ToString().Substring(0, dcBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    litDisplaySwapUnitRoomNumber.Text = Convert.ToString(lblGvListRoomNo.Text.Trim());

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResevationList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event
    }
}