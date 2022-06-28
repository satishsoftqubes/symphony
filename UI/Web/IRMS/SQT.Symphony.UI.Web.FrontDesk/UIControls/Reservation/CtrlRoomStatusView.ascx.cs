using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using System.Text;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlRoomStatusView : System.Web.UI.UserControl
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
        PagedDataSource objPageDatasource;
        public int PageNoPos;
        public int PageNodll;
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                LoadDefaultData();
            }
            PageNoPos = (int)this.ViewState["PageNoPos"];
            // BindRoomStatusData();

        }
        #endregion Page Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RoomStatusView.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void ClearControl()
        {

            ddlFloorType.SelectedIndex = 0;
            ddlBlockType.SelectedIndex = 0;
            ddlRoomTypes.SelectedIndex = 0;
            ddlPage.SelectedIndex = 0;
        }
        private void LoadDefaultData()
        {
            try
            {
                this.ViewState["PageNoPos"] = 0;
                BindRoomType();
                BindBlockType();
                BindFloorType();
                //BindRoomStatusData();
                BindPageNo();
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindRoomStatusData()
        {
            try
            {
                Guid? RoomTypeID = null;
                Guid? FloorID = null;
                Guid? WingID = null;

                if (ddlRoomTypes.SelectedIndex != 0)
                    RoomTypeID = new Guid(ddlRoomTypes.SelectedValue);


                if (ddlBlockType.SelectedIndex != 0)
                    WingID = new Guid(ddlBlockType.SelectedValue);


                if (ddlFloorType.SelectedIndex != 0)
                    FloorID = new Guid(ddlFloorType.SelectedValue);

                /////DataSet dsForRoomStatus = ReservationBLL.GetReservation_GetRoomStatus(DateTime.Now, RoomTypeID, clsSession.PropertyID, clsSession.CompanyID, FloorID, WingID);
                DataSet dsForRoomStatus = ReservationBLL.GetReservation_GetRoomStatusNew(DateTime.Now, RoomTypeID, clsSession.PropertyID, clsSession.CompanyID, FloorID, WingID);

                if (dsForRoomStatus != null && dsForRoomStatus.Tables.Count > 0 && dsForRoomStatus.Tables[0].Rows.Count > 0)
                {
                    lblNoRecordFound.Text = "";
                    objPageDatasource = new PagedDataSource();
                    objPageDatasource.DataSource = dsForRoomStatus.Tables[0].DefaultView;
                    objPageDatasource.PageSize = 150;
                    objPageDatasource.AllowPaging = true;
                    objPageDatasource.CurrentPageIndex = PageNoPos;
                    btnfirst.Enabled = !objPageDatasource.IsFirstPage;
                    btnprevious.Enabled = !objPageDatasource.IsFirstPage;
                    btnlast.Enabled = !objPageDatasource.IsLastPage;
                    btnnext.Enabled = !objPageDatasource.IsLastPage;
                    dlRoomStatusView.DataSource = objPageDatasource;
                    dlRoomStatusView.DataBind();

                }
                else
                {
                    lblNoRecordFound.Text = "No record Found";
                    objPageDatasource = new PagedDataSource();
                    objPageDatasource.DataSource = null;
                    dlRoomStatusView.DataSource = null;
                    dlRoomStatusView.DataBind();
                }


                DataSet dsForRoomStatusCount = ReservationBLL.GetReservation_GetRoomStatusCount(DateTime.Now, RoomTypeID, clsSession.PropertyID, clsSession.CompanyID, FloorID, WingID);
                if (dsForRoomStatusCount != null && dsForRoomStatusCount.Tables.Count > 0 && dsForRoomStatusCount.Tables[0].Rows.Count > 0)
                {
                    ltrCountFullOccupied.Text = Convert.ToString(dsForRoomStatusCount.Tables[0].Rows[0]["FullOccupiedRoom"]);
                    ltrCountPartialOccupied.Text = Convert.ToString(dsForRoomStatusCount.Tables[0].Rows[0]["PartialOccupiedRoom"]);
                    ltrCountTotalOccupied.Text = Convert.ToString(dsForRoomStatusCount.Tables[0].Rows[0]["TotalOccupiedRoom"]);
                    ltrCountFullVaccant.Text = Convert.ToString(dsForRoomStatusCount.Tables[0].Rows[0]["FullVaccantRoom"]);
                    ltrCountTotalRooms.Text = Convert.ToString(dsForRoomStatusCount.Tables[0].Rows[0]["TotalRoom"]);
                }
                else
                {
                    ltrCountFullOccupied.Text = ltrCountPartialOccupied.Text = ltrCountTotalOccupied.Text = ltrCountFullVaccant.Text = ltrCountTotalRooms.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindPageNo()
        {
            try
            {
                if (objPageDatasource != null && objPageDatasource.PageCount > 0)
                {
                    ddlPage.Items.Clear();
                    ddlPage.Items.Insert(0, new ListItem("-Select-"));
                    for (int i = 0; i < objPageDatasource.PageCount; i++)
                    {
                        ddlPage.Items.Add(Convert.ToString(i + 1));
                    }
                }
                else
                {
                    ddlPage.Items.Clear();
                    ddlPage.Items.Insert(0, new ListItem("-Select-"));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindRoomType()
        {
            try
            {
                string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";
                DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);

                ddlRoomTypes.Items.Clear();
                if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
                {
                    ddlRoomTypes.DataSource = dsRoomType.Tables[0];
                    ddlRoomTypes.DataTextField = "RoomTypeName";
                    ddlRoomTypes.DataValueField = "RoomTypeID";
                    ddlRoomTypes.DataBind();

                    ddlRoomTypes.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlRoomTypes.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindFloorType()
        {
            try
            {
                string strFloorTypeQuery = "select FloorID,FloorName from mst_Floor where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by FloorName asc";
                DataSet dsFloorType = RoomTypeBLL.GetUnitType(strFloorTypeQuery);

                ddlFloorType.Items.Clear();
                if (dsFloorType.Tables.Count > 0 && dsFloorType.Tables[0].Rows.Count > 0)
                {
                    ddlFloorType.DataSource = dsFloorType.Tables[0];
                    ddlFloorType.DataTextField = "FloorName";
                    ddlFloorType.DataValueField = "FloorID";
                    ddlFloorType.DataBind();

                    ddlFloorType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlFloorType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindBlockType()
        {
            try
            {
                string strBlockTypeQuery = "select WingID,WingName from mst_Wing where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by WingName asc";
                DataSet dsForBlockType = RoomTypeBLL.GetUnitType(strBlockTypeQuery);

                ddlBlockType.Items.Clear();
                if (dsForBlockType.Tables.Count > 0 && dsForBlockType.Tables[0].Rows.Count > 0)
                {
                    ddlBlockType.DataSource = dsForBlockType.Tables[0];
                    ddlBlockType.DataTextField = "WingName";
                    ddlBlockType.DataValueField = "WingID";
                    ddlBlockType.DataBind();

                    ddlBlockType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlBlockType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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
            dr4["NameColumn"] = "Check In";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);



            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Room status Report";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion Private Method

        #region Datalist Event
        protected void dlRoomStatusView_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    System.Data.DataRowView drv2 = (System.Data.DataRowView)(e.Item.DataItem);
                    string RoomStatus = (string)drv2.Row["TYPE"].ToString();
                    string RestStatus_TermID = Convert.ToString(drv2.Row["RestStatus_TermID"]);
                    switch (RoomStatus)
                    {
                        case "BLOCK":
                            e.Item.BackColor = System.Drawing.Color.Brown;
                            break;
                        case "VACANT":
                            e.Item.BackColor = System.Drawing.Color.Green;
                            break;
                        case "STAY":
                            if (RestStatus_TermID != null && RestStatus_TermID == "28")
                            {
                                e.Item.BackColor = System.Drawing.Color.Blue;
                                break;
                            }
                            else
                            {
                                e.Item.BackColor = System.Drawing.Color.Red;
                                break;
                            }
                        case "HKP":
                            e.Item.BackColor = System.Drawing.Color.Yellow;
                            break;
                        default:
                            e.Item.BackColor = System.Drawing.Color.Black;
                            break;
                    }

                    //((Label)e.Item.FindControl("lblRooNo")).Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(drv2.Row["RoomNo"]));
                    ((Label)e.Item.FindControl("lblRooNo")).Text = Convert.ToString(drv2.Row["rmRoomNo"]);


                    if (drv2.Row["TYPE"] != null && Convert.ToString(drv2.Row["TYPE"]) == "STAY")
                    {
                        ((Panel)e.Item.FindControl("pnlRoomStatusView")).Visible = true;
                        StringBuilder strBldrForGuestInfo = new StringBuilder();
                        if (drv2.Row["GuestFullName"] != null && Convert.ToString(drv2.Row["GuestFullName"]) != string.Empty)
                            strBldrForGuestInfo.Append(Convert.ToString(drv2.Row["GuestFullName"]) + " | ");
                        else
                            strBldrForGuestInfo.Append("");

                        if (drv2.Row["CheckInDate"] != null && Convert.ToString(drv2.Row["CheckInDate"]) != string.Empty)
                            strBldrForGuestInfo.Append(Convert.ToDateTime(drv2.Row["CheckInDate"]).ToString(clsSession.DateFormat) + " to ");
                        else
                            strBldrForGuestInfo.Append(" | ");


                        if (drv2.Row["CheckOutDate"] != null && Convert.ToString(drv2.Row["CheckOutDate"]) != string.Empty)
                            strBldrForGuestInfo.Append(Convert.ToDateTime(drv2.Row["CheckOutDate"]).ToString(clsSession.DateFormat) + " | ");
                        else
                            strBldrForGuestInfo.Append(" | ");


                        ((Label)e.Item.FindControl("lblGuestInfo")).Text = strBldrForGuestInfo.ToString();
                    }
                    else
                    {
                        ((Panel)e.Item.FindControl("pnlRoomStatusView")).Visible = false;
                        ((Label)e.Item.FindControl("lblGuestInfo")).Text = "";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Datalist Event

        #region Control Event
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            try
            {
                PageNoPos = 0;
                this.ViewState["PageNoPos"] = PageNoPos;
                BindRoomStatusData();
                BindPageNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void imgbtnClearSearch_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindRoomStatusData();
                BindPageNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void ddlPage_SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                if (ddlPage.SelectedIndex != 0)
                {
                    PageNoPos = ddlPage.SelectedIndex - 1;
                    this.ViewState["PageNoPos"] = PageNoPos;
                    BindRoomStatusData();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnfirst_Click(object sender, EventArgs e)
        {
            try
            {
                PageNoPos = 0;
                this.ViewState["PageNoPos"] = PageNoPos;
                BindRoomStatusData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                PageNoPos = (int)this.ViewState["PageNoPos"];
                PageNoPos -= 1;
                this.ViewState["PageNoPos"] = PageNoPos;
                BindRoomStatusData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                PageNoPos = (int)this.ViewState["PageNoPos"];
                PageNoPos += 1;
                this.ViewState["PageNoPos"] = PageNoPos;
                BindRoomStatusData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnlast_Click(object sender, EventArgs e)
        {
            try
            {
                PageNoPos = objPageDatasource.PageCount - 1;
                this.ViewState["PageNoPos"] = PageNoPos;
                BindRoomStatusData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event
    }
}