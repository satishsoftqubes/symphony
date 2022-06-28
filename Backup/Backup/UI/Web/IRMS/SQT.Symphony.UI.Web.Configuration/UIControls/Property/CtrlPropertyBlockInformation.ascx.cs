using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Property
{
    public partial class CtrlPropertyBlockInformation : System.Web.UI.UserControl
    {
        #region Property And Variables
        public Guid WingID4Unit
        {
            get
            {
                return ViewState["WingID4Unit"] != null ? new Guid(Convert.ToString(ViewState["WingID4Unit"])) : Guid.Empty;
            }
            set
            {
                ViewState["WingID4Unit"] = value;
            }
        }
        #endregion

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (Session["WingID4Unit"] != null)
                this.WingID4Unit = new Guid(Session["WingID4Unit"].ToString());
            
            if (!IsPostBack)
            {
                LoadDefaultValue();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                if (clsSession.PropertyID != Guid.Empty && this.WingID4Unit != Guid.Empty)
                {
                    BindPageLables();
                    BindBlockInfo();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindPageLables()
        {
            litBlockInformation.Text = clsCommon.GetGlobalResourceText("BlockInformation", "lblMainBlockInformation", "BLOCK INFORMATION");
            litBlock.Text = clsCommon.GetGlobalResourceText("BlockInformation", "lblBlock", "Block");
            litProperty.Text = clsCommon.GetGlobalResourceText("BlockInformation", "lblProperty", "Property");
            litNoOfFloors.Text = clsCommon.GetGlobalResourceText("BlockInformation", "lblNoOfFloors", "No. of Floors");
            litUnitInformation.Text = clsCommon.GetGlobalResourceText("BlockInformation", "lblUnitInformation ", "Unit Information");
            litFloor.Text = clsCommon.GetGlobalResourceText("BlockInformation", "lblFloor", "FLOOR");
            btnBack.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnBack", "Back");
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

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblGeneralSettings", "General Settings");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyList", "Property List");
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyInformation", "Property Information");
            dr5["Link"] = "~/GUI/Property/PropertyInformation.aspx";
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblBlockInformation", "Block Information"); 
            dr6["Link"] = "";
            dt.Rows.Add(dr6);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            DataSet dsUnitInfo = null;
            try
            {
                dsUnitInfo = PropertyBLL.GetPropertyBlockUnitView(clsSession.PropertyID, this.WingID4Unit);
                DataView dv = new DataView(dsUnitInfo.Tables[0]);
                grdUnitInfo.DataSource = dv;
                grdUnitInfo.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                grdUnitInfo.DataSource = null;
                grdUnitInfo.DataBind();
            }
        }

        private void BindBlockInfo()
        {
            Wing objWing = WingBLL.GetByPrimaryKey(this.WingID4Unit);
            lblBlockName.Text = objWing.WingName;

            Room objRoom = new Room();
            objRoom.WingID = this.WingID4Unit;
            objRoom.IsActive = true;
            List<Room> lstRooms = RoomBLL.GetAll(objRoom);

            if (lstRooms != null)
                lblNoOfFloors.Text = Convert.ToString(lstRooms.Count.ToString());

            SQT.Symphony.BusinessLogic.Configuration.DTO.Property objProperty = PropertyBLL.GetByPrimaryKey(clsSession.PropertyID);
            lblPropertyName.Text = objProperty.PropertyName;
        }
        #endregion Private Method

        #region Control Events
        protected void lnkToRedirect_OnClick(object sender, EventArgs e)
        {
            if (clsSession.PropertyID != Guid.Empty && this.WingID4Unit != Guid.Empty)
            {
                Room objRoom = new Room();
                objRoom.PropertyID = clsSession.PropertyID;
                objRoom.WingID = this.WingID4Unit;
                objRoom.RoomNo = hfUnitValue.Value;
                objRoom.IsActive = true;

                List<Room> lstRoom = RoomBLL.GetAll(objRoom);
                if (lstRoom != null && lstRoom.Count > 0)
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(lstRoom[0].RoomID));
                    clsSession.ToEditItemType = "ROOM";
                    Response.Redirect("~/GUI/Configurations/Room.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Property/PropertyInformation.aspx");
        }
        #endregion

        #region Grid Event
        protected void grdUnitInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strBlockValue = "";
                    if (e.Row.Cells.Count > 0)
                        strBlockValue = Convert.ToString(e.Row.Cells[0].Text);

                    if (e.Row.Cells.Count > 0)
                    {
                        e.Row.Cells[0].Width = 60;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#f3f3f5");
                    }

                    for (int i = 1; i < e.Row.Cells.Count; i++)
                    {
                        if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                            e.Row.Cells[i].Text = Convert.ToString(e.Row.Cells[i].Text);
                        else
                            e.Row.Cells[i].Text = "<a style='cursor:pointer;' onclick=\"fnRowCommand('" + Convert.ToString(e.Row.Cells[i].Text) + "');\">" + Convert.ToString(e.Row.Cells[i].Text) + "</a>";

                    }
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoUnitFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdUnitInfo_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUnitInfo.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event
    }
}