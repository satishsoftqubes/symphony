using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlUnitBookingList : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
        private User user;
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
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] != null)
            {
                
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                
                if (Session["UserID"] != null)
                    user = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"]))); 

                if (!IsPostBack)
                    LoadControlVlaue();
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
        }
        #endregion

        #region Private Method

        protected void LoadControlVlaue()
        {
            try
            {
                ddlInvestor.Enabled = true;
                BindWing();
                ddlBlock_SelectedIndexChanged(null, null);
                BindUnitType();
                BindInvestor();
                ddlInvestor_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Wing
        /// </summary>
        private void BindWing()
        {
            List<Wing> lstWing = WingBLL.GetAll();
            lstWing.Sort((Wing w1, Wing w2) => w1.WingName.CompareTo(w2.WingName));
            ddlBlock.DataSource = lstWing;
            ddlBlock.DataTextField = "WingName";
            ddlBlock.DataValueField = "WingID";
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Unit Type
        /// </summary>
        private void BindUnitType()
        {
            string RoomTypeQuery = "Select RoomTypeID, RoomTypeName From mst_RoomType Where IsActive = 1";
            DataSet dsRoomType = RoomTypeBLL.GetUnitType(RoomTypeQuery);

            if (dsRoomType.Tables[0].Rows.Count != 0)
            {
                DataView dvRoomType = new DataView(dsRoomType.Tables[0]);
                dvRoomType.Sort = "RoomTypeName Asc";
                ddlUnitType.DataSource = dvRoomType;
                ddlUnitType.DataTextField = "RoomTypeName";
                ddlUnitType.DataValueField = "RoomTypeID";
                ddlUnitType.DataBind();
                ddlUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Investor
        /// </summary>
        private void BindInvestor()
        {
            string InvestorQuery ;
            if(user.UserType.Equals("Admin"))
                InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");
            else
                InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1 And UserID like '" + user.UsearID + "'" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");
            DataSet dsInvestor = InvestorBLL.GetSearchData(InvestorQuery);

            if (dsInvestor.Tables[0].Rows.Count != 0)
            {
                DataView dvInvestor = new DataView(dsInvestor.Tables[0]);
                dvInvestor.Sort = "FullName Asc";
                ddlInvestor.DataSource = dvInvestor;
                ddlInvestor.DataTextField = "FullName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
                ddlInvestor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));                
            }
            else
                ddlInvestor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.Equals("Investor"))
            {
                ddlInvestor.SelectedValue = Convert.ToString(dsInvestor.Tables[0].Rows[0]["InvestorID"]);
                ddlInvestor.Enabled = false;
            }
        }
        
        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Unit Booking List");
                DataSet ds = new DataSet();
                Guid? idBlock = null;
                Guid? idFloor = null;
                Guid? idUnitType = null;
                Guid? idInvestor = null;
                Guid? idUnit = null;

                if (!ddlBlock.SelectedValue.Equals(Guid.Empty.ToString()))
                    idBlock = new Guid(Convert.ToString(ddlBlock.SelectedValue));
                if (!ddlFloor.SelectedValue.Equals(Guid.Empty.ToString()))
                    idFloor = new Guid(Convert.ToString(ddlFloor.SelectedValue));
                if (!ddlUnitType.SelectedValue.Equals(Guid.Empty.ToString()))
                    idUnitType = new Guid(Convert.ToString(ddlUnitType.SelectedValue));
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                    idInvestor = new Guid(Convert.ToString(ddlInvestor.SelectedValue));
                if (!ddlUnit.SelectedValue.Equals(Guid.Empty.ToString()))
                    idUnit = new Guid(Convert.ToString(ddlUnit.SelectedValue));

                if (!ddlBlock.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Block", ddlBlock.SelectedItem.Text);
                if (!ddlFloor.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Floor", ddlFloor.SelectedItem.Text);
                if (!ddlUnitType.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("UnitType", ddlUnitType.SelectedItem.Text);
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Investor", ddlInvestor.SelectedItem.Text);
                if (!ddlUnit.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Unit", ddlUnit.SelectedItem.Text);
                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.Equals("Admin") || UserType.Equals("Investor"))
                    ds = RoomBLL.GetRptUnitBooking(idBlock, idFloor, idUnitType, idInvestor, idUnit, null);
                else
                    ds = RoomBLL.GetRptUnitBooking(idBlock, idFloor, idUnitType, idInvestor, idUnit, user.UsearID);                 

                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Click Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion

        #region DropDown Event
        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ddlBlock.SelectedValue.Equals(Guid.Empty.ToString()))
                {
                    DataSet Dst = WingFloorJoinBLL.GetAllWithName(new Guid(Convert.ToString(ddlBlock.SelectedValue)), null);
                    DataView Lstflr = new DataView(Dst.Tables[0]);
                    if (Lstflr.Count > 0)
                    {
                        Lstflr.Sort = "FloorName Asc";
                        ddlFloor.DataSource = Lstflr;
                        ddlFloor.DataTextField = "FloorName";
                        ddlFloor.DataValueField = "FloorID";
                        ddlFloor.DataBind();
                        ddlFloor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlFloor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
                else
                {
                    List<Floor> LstFloor = FloorBLL.GetAll();
                    if (LstFloor.Count > 0)
                    {
                        LstFloor.Sort((Floor p1, Floor p2) => p1.FloorName.CompareTo(p2.FloorName));
                        ddlFloor.DataSource = LstFloor;
                        ddlFloor.DataTextField = "FloorName";
                        ddlFloor.DataValueField = "FloorID";
                        ddlFloor.DataBind();
                        ddlFloor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlFloor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }       

        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                {
                    ddlUnit.Items.Clear();
                    DataSet dsUnit = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, new Guid(Convert.ToString(ddlInvestor.SelectedValue)), null,null,null);
                    if (dsUnit.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = new DataView(dsUnit.Tables[0]);
                        dv.Sort = "RoomNo";
                        ddlUnit.DataSource = dv;
                        ddlUnit.DataTextField = "RoomNo";
                        ddlUnit.DataValueField = "RoomID";
                        ddlUnit.DataBind();
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlUnit.Items.Clear();
                    List<Room> LstRoom = RoomBLL.GetAll();
                    if (LstRoom .Count > 0)
                    {
                        LstRoom.Sort((Room r1, Room r2) => r1.RoomNo.CompareTo(r2.RoomNo));
                        ddlUnit.DataSource = LstRoom;
                        ddlUnit.DataTextField = "RoomNo";
                        ddlUnit.DataValueField = "RoomID";
                        ddlUnit.DataBind();
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
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