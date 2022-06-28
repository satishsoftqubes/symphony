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

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlProspectsList : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsInsert = false;
        private DataSet Dst = null;
        public bool IsPreview = false;

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

        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("ProspectsSetup.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            if (!IsPostBack)
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ProspectsSetup.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Create"] = btnAdd.Visible = btnAddTop.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = imgbtnDOC.Visible = imgbtnXLSX.Visible = imgbtnPDF.Visible =  btnPrint.Visible = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                BindProspectStatus();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            Guid? CompanyID = this.CompanyID;
            Guid? ContactedBy;
            Guid? RegionID;
            string FName, ProspectName, Location, Reference = null;
            Guid? ProspectStatus;
            if (!txtsLocation.SelectedValue.Equals(Guid.Empty.ToString()))
                Location = txtsLocation.SelectedValue.ToString();
            else
                Location = null;

            //if (Request.QueryString["Param"] != null && Request.QueryString["Param"].ToUpper() != "ALL")
            //    FName = Request.QueryString["Param"].ToString();
            //else
            //    FName = null;

            if (hfSelectedAlphabet.Value.ToString() != string.Empty)
            {
                if (hfSelectedAlphabet.Value.ToString() != "ALL")
                    ProspectName = hfSelectedAlphabet.Value.ToString();
                else
                    ProspectName = null;

                hfSelectedAlphabet.Value = string.Empty;
            }
            else
            {
                if (txtSProspectName.Text.Trim() != "")
                    ProspectName = txtSProspectName.Text.Trim();
                else
                    ProspectName = null;
            }

            if (!txtRefernce.SelectedValue.Equals(Guid.Empty.ToString()))
                Reference = txtRefernce.Text.Trim();
            else
                Reference = null;

            //if (txtSProspectName.Text.Trim() != "")
            //    ProspectName = Convert.ToString(txtSProspectName.Text.Trim());
            //else
            //    ProspectName = null;

            if (ddlProspectStatus.SelectedValue != Guid.Empty.ToString())
                ProspectStatus = new Guid(ddlProspectStatus.SelectedValue);
            else
                ProspectStatus = null;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN")
                ContactedBy = null;
            else
                ContactedBy = new Guid(Convert.ToString(Session["UserID"]));

            if (!ddlRegion.SelectedValue.Equals(Guid.Empty.ToString()))
                RegionID = new Guid(ddlRegion.SelectedValue.ToString());
            else
                RegionID = null;

            Dst = ProspectsBLL.SearchInfo(null, null, null, null, ProspectName, ProspectStatus, CompanyID, null, ContactedBy, Location, Reference, RegionID, null);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv.Sort = "FName Asc";
            grdProspect.DataSource = Dv;
            grdProspect.DataBind();

            litProspectsCount.Text = "(" + Convert.ToString(Dv.Table.Rows.Count) + ")";

        }

        /// <summary>
        /// Load Prospect Status
        /// </summary>
        private void BindProspectStatus()
        {
            Guid? ContactedBy;
            ddlProspectStatus.Items.Clear();
            ProjectTerm objProjectTermPS = new ProjectTerm();
            List<ProjectTerm> lstProjectTermPS = new List<ProjectTerm>();
            objProjectTermPS.IsActive = true;
            objProjectTermPS.Category = "PROSPECTSTATUS";
            objProjectTermPS.CompanyID = this.CompanyID;
            lstProjectTermPS = ProjectTermBLL.GetAll(objProjectTermPS);
            if (lstProjectTermPS.Count != 0)
            {
                lstProjectTermPS.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlProspectStatus.DataSource = lstProjectTermPS;
                ddlProspectStatus.DataTextField = "DisplayTerm";
                ddlProspectStatus.DataValueField = "TermID";
                ddlProspectStatus.DataBind();
                ddlProspectStatus.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlProspectStatus.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            string UserType = Convert.ToString(Session["UserType"]);

            //string ProspectNameQuery = "";

            //if (UserType.ToUpper() == "ADMIN")
            //    ProspectNameQuery = "Select Title + ' ' + FName + ' ' + LName As FullName, FName From irm_Prospects Where IsActive = 1 Order By FName ASC";
            //else
            //    ProspectNameQuery = "Select Title + ' ' + FName + ' ' + LName As FullName, FName From irm_Prospects Where IsActive = 1 And ContactedBy like '" + Convert.ToString(Session["UserID"]) + "' Order By FName ASC";

            //DataSet ProspectDst = InvestorBLL.GetSearchData(ProspectNameQuery);
            //DataView ProspectDv = new DataView(ProspectDst.Tables[0]);
            //if (ProspectDv.Count > 0)
            //{
            //    txtSProspectName.DataSource = ProspectDv;
            //    txtSProspectName.DataTextField = "FullName";
            //    txtSProspectName.DataValueField = "FName";
            //    txtSProspectName.DataBind();
            //    txtSProspectName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            //}
            //else
            //    txtSProspectName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            //Bind Reference
            txtRefernce.Items.Clear();
            DataSet Dst = InvestorBLL.GetSearchData("Select Distinct(Reference) from irm_Prospects");
            if (Dst.Tables[0].Rows.Count > 0)
            {
                DataView Dv = new DataView(Dst.Tables[0]);
                Dv.Sort = "Reference ASC";
                txtRefernce.DataSource = Dv;
                txtRefernce.DataTextField = "Reference";
                txtRefernce.DataValueField = "Reference";
                txtRefernce.DataBind();
                txtRefernce.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtRefernce.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            //Bind Locaton

            txtsLocation.Items.Clear();
            DataSet CityDst = InvestorBLL.GetSearchData("Select CityName, CityName as Name From mst_City");
            if (CityDst.Tables[0].Rows.Count > 0)
            {
                DataView Dv = new DataView(CityDst.Tables[0]);
                Dv.Sort = "Name ASC";
                txtsLocation.DataSource = Dv;
                txtsLocation.DataTextField = "Name";
                txtsLocation.DataValueField = "CityName";
                txtsLocation.DataBind();
                txtsLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtsLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            //Bind Region

            ddlRegion.Items.Clear();
            ProjectTerm Region = new ProjectTerm();
            List<ProjectTerm> LstRegion = new List<ProjectTerm>();
            Region.IsActive = true;
            Region.Category = "Region";
            Region.CompanyID = this.CompanyID;
            LstRegion = ProjectTermBLL.GetAll(Region);
            if (LstRegion.Count != 0)
            {
                LstRegion.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlRegion.DataSource = LstRegion;
                ddlRegion.DataTextField = "DisplayTerm";
                ddlRegion.DataValueField = "TermID";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlRegion.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));


        }

        /// <summary>
        /// Load Report
        /// </summary>
        private void LoadReport()
        {
            try
            {
                Guid? CompanyID = this.CompanyID;
                Guid? ContactedBy;
                Guid? RegionID;
                string FName = null, ProspectName = null, Location = null, Reference = null;
                Guid? ProspectStatus;
                if (!txtsLocation.SelectedValue.Equals(Guid.Empty.ToString()))
                    Location = txtsLocation.SelectedValue.ToString();
                else
                    Location = null;
                if (Request.QueryString["Param"] != null && Request.QueryString["Param"].ToUpper() != "ALL")
                    FName = Request.QueryString["Param"].ToString();
                else
                    FName = null;
                if (!txtRefernce.SelectedValue.Equals(Guid.Empty.ToString()))
                    Reference = txtRefernce.Text.Trim();
                else
                    Reference = null;
                if (txtSProspectName.Text != "")
                    ProspectName = Convert.ToString(txtSProspectName.Text);
                else
                    ProspectName = null;
                if (ddlProspectStatus.SelectedValue != Guid.Empty.ToString())
                    ProspectStatus = new Guid(ddlProspectStatus.SelectedValue);
                else
                    ProspectStatus = null;
                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.ToUpper() == "ADMIN")
                    ContactedBy = null;
                else
                    ContactedBy = new Guid(Convert.ToString(Session["UserID"]));

                if (!ddlRegion.SelectedValue.Equals(Guid.Empty.ToString()))
                    RegionID = new Guid(ddlRegion.SelectedValue.ToString());
                else
                    RegionID = null;
                if (txtSProspectName.Text.Trim() != "")
                    Session.Add("Name", Convert.ToString(txtSProspectName.Text.Trim()));
                if (txtsLocation.SelectedValue != Guid.Empty.ToString())
                    Session.Add("City", txtsLocation.SelectedItem.Text);
                if (ddlProspectStatus.SelectedValue != Guid.Empty.ToString())
                    Session.Add("Status", Convert.ToString(ddlProspectStatus.SelectedItem.Text));
                if (!txtRefernce.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Reference", txtRefernce.SelectedItem.Text);
                if (ddlRegion.SelectedValue != Guid.Empty.ToString())
                    Session.Add("Region", Convert.ToString(ddlRegion.SelectedItem.Text));
                Dst = ProspectsBLL.SearchInfo(FName, null, null, null, ProspectName, ProspectStatus, CompanyID, null, ContactedBy, Location, Reference, RegionID, null);
                Session["DataSource"] = Dst;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string MobileNo(string strMobileNo)
        {
            string strPhNo = "";

            string[] words = strMobileNo.Split('-');

            if (words.Length > 1)
            {
                if (words[0] != "")
                    strPhNo = Convert.ToString(words[0]);

                if (words[1] != "")
                {
                    if (strPhNo != "")
                        strPhNo = strPhNo + "-" + words[1];
                    else
                        strPhNo = words[1];
                }
            }

            return strPhNo;
        }

        #endregion Private Method

        #region Add New
        /// <summary>
        /// AddNew Prospectors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Investors/ProspectsSetup.aspx");
        }
        /// <summary>
        /// Search Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        protected void lnkAlphabet_OnClick(object sender, EventArgs e)
        {
            try
            {
                txtSProspectName.Text = string.Empty;
                ddlProspectStatus.SelectedIndex = txtsLocation.SelectedIndex = ddlRegion.SelectedIndex = ddlProspectStatus.SelectedIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Add New

        #region Grid Event
        /// <summary>
        /// Data Grid Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdProspect_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    Session["ProsPectID"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Applications/Investors/ProspectsSetup.aspx");
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    ViewState["ProsPectID"] = e.CommandArgument.ToString();
                    msgbx.Show();
                }
                else if (e.CommandName.Equals("INVESTOR"))
                {
                    Session.Add("ProspectID", e.CommandArgument.ToString());
                    Response.Redirect("~/Applications/Investors/InvestorSetUp.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdProspect_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));

                    if (Convert.ToBoolean(ViewState["Delete"]) == true)
                        e.Row.Cells[5].Text = "View/ Edit/ Delete";
                    else if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[5].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[5].Text = "View";
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[6].Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblGvMobileNo = (Label)e.Row.FindControl("lblGvMobileNo");
                    string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                    if (litMobileNo != null)
                    {
                        if (Convert.ToString(strMobileNo) != "")
                            lblGvMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                        else
                            lblGvMobileNo.Text = "";
                    }

                    DataView DV1 = RoleRightJoinBLL.GetIUDVAccess("ProspectsSetup.aspx", new Guid(Convert.ToString(Session["UserID"])));

                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DeleteImg = (ImageButton)e.Row.FindControl("btnDelete");

                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
                    DeleteImg.Visible = Convert.ToBoolean(ViewState["Delete"]);
                    e.Row.Cells[6].Visible = Convert.ToBoolean(DV1[0]["IsUpdate"]);

                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        EditImg.ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        EditImg.ToolTip = "View";
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DataView DV2 = RoleRightJoinBLL.GetIUDVAccess("ProspectsSetup.aspx", new Guid(Convert.ToString(Session["UserID"])));

                    if (Convert.ToBoolean(ViewState["Delete"]) == true)
                        e.Row.Cells[5].Text = "View/Edit/Delete";
                    else if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[5].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[5].Text = "View";
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[6].Visible = Convert.ToBoolean(DV2[0]["IsUpdate"]);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdProspect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdProspect.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Popup Button Event
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["ProsPectID"] = null;
                msgbx.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ProsPectID"] != null)
                {
                    Prospects DelePros = ProspectsBLL.GetByPrimaryKey(new Guid(ViewState["ProsPectID"].ToString()));
                    ProspectsBLL.Delete(new Guid(ViewState["ProsPectID"].ToString()));
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", DelePros.ToString(), null, "irm_Prospects");
                    IsInsert = true;
                    lblProspctLstMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ViewState["ProsPectID"] = null;
                    msgbx.Hide();
                }
                LoadDefaultValue();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Popup Button Event

        #region Button Event
        /// <summary>
        /// Print Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Prospects List");
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        /// <summary>
        /// Preview Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Prospects List");
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Prospects List");
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Prospects List");
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Prospects List");
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion
    }
}