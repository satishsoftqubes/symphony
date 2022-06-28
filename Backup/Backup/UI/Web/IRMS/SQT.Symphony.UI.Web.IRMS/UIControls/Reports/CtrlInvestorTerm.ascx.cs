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
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlInvestorTerm : System.Web.UI.UserControl
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
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] != null)
            {

                if (RoleRightJoinBLL.GetAccessString("RPTInvestorTerms.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");

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
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    ProjectTerm objProjectTerm = new ProjectTerm();
                    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                    if (objProjectTerm != null)
                    {
                        calStartDate.Format = calEndDate.Format = objProjectTerm.Term;
                        this.DateFormat = objProjectTerm.Term;
                    }
                    else
                    {
                        calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                        this.DateFormat = "dd/MM/yyyy";
                    }
                }
                else
                {
                    calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                    this.DateFormat = "dd/MM/yyyy";
                }
                chkStartDate.Checked = chkEndDate.Checked = false;
                chkStartDate_CheckedChanged(null, null);
                chkEndDate_CheckedChanged(null, null);
                ddlInvestor.Enabled = true;               
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
            string InvestorQuery;
            if (user.UserType.Equals("Admin"))
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
                Session.Add("ReportName", "Investor Terms");
                DataSet ds = new DataSet();             
                Guid? idUnitType = null;
                Guid? idInvestor = null;
                Guid? idUnit = null;
                DateTime? dtStart = null;
                DateTime? dtEnd = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!ddlUnitType.SelectedValue.Equals(Guid.Empty.ToString()))
                    idUnitType = new Guid(Convert.ToString(ddlUnitType.SelectedValue));
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                    idInvestor = new Guid(Convert.ToString(ddlInvestor.SelectedValue));
                if (!ddlUnit.SelectedValue.Equals(Guid.Empty.ToString()))
                    idUnit = new Guid(Convert.ToString(ddlUnit.SelectedValue));
                if (!txtStartDate.Text.Equals(""))
                    dtStart = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    dtEnd = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (!ddlUnitType.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("UnitType", ddlUnitType.SelectedItem.Text);
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Investor", ddlInvestor.SelectedItem.Text);
                if (!ddlUnit.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Unit", ddlUnit.SelectedItem.Text);
                Session.Add("StartDate", dtStart);
                Session.Add("EndDate", dtEnd);

                ds = InvestorsUnitBLL.GetInvestorTermReport(idInvestor, idUnitType, idUnit, dtStart, dtEnd);
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
      
        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                {
                    ddlUnit.Items.Clear();
                    DataSet dsUnit = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, new Guid(Convert.ToString(ddlInvestor.SelectedValue)), null, null, null);
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
                    if (LstRoom.Count > 0)
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


        #region CheckBox Event
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
            txtStartDate.Text = "";
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        #endregion                      
    }
}