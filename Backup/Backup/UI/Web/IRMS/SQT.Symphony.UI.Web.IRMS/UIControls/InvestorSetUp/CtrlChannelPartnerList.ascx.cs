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
    public partial class CtrlChannelPartnerList : System.Web.UI.UserControl
    {

        #region Variable

        public bool IsInsert = false;
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
            if (RoleRightJoinBLL.GetAccessString("ChannelPartnerSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
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
            try
            {
                DataView DV = RoleRightJoinBLL.GetIUDVAccess("ChannelPartnerSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
                if (DV.Count > 0)
                {

                    ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                    ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                    btnAdd.Visible = btnAddUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                    ViewState["View"] = imgbtnDOC.Visible = imgbtnXLSX.Visible = imgbtnPDF.Visible = btnPrint.Visible = Convert.ToBoolean(DV[0]["IsView"]);
                }
                else
                    Response.Redirect("~/Applications/AccessDenied.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                LoadDDL();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadDDL()
        {
            //string ChannelPartnerName;
            string ChannelPartnerCompany;
            //ChannelPartnerName = "Select Title + ' ' + FName + ' ' + LName As FullName, FName From irm_ChannelPartner Where IsActive = 1 Order By FName";
            ChannelPartnerCompany = "Select Distinct(Case CompanyName When '' THEN 'NA' else CompanyName end) As CompanyName From irm_ChannelPartner Where IsActive = 1 Order By CompanyName";

            //DataSet Dst = InvestorBLL.GetSearchData(ChannelPartnerName);

            //DataView Dv = new DataView(Dst.Tables[0]);
            //if (Dv.Count > 0)
            //{
            //    txtSearchDisplayName.DataSource = Dv;
            //    txtSearchDisplayName.DataTextField = "FullName";
            //    txtSearchDisplayName.DataValueField = "FName";
            //    txtSearchDisplayName.DataBind();
            //    txtSearchDisplayName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            //}
            //else
            //    txtSearchDisplayName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            DataSet CmtDst = InvestorBLL.GetSearchData(ChannelPartnerCompany);
            DataView CmtDv = new DataView(CmtDst.Tables[0]);

            if (CmtDv.Count > 0)
            {
                txtSCompanyName.DataSource = CmtDv;
                txtSCompanyName.DataTextField = "CompanyName";
                txtSCompanyName.DataValueField = "CompanyName";
                txtSCompanyName.DataBind();
                txtSCompanyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtSCompanyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));


        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            string FName, CompanyName, DisplayName, Location = null;
            Guid? CreatedBy;

            //if (Request.QueryString["Param"] != null && Request.QueryString["Param"].ToUpper() != "ALL")
            //    FName = Request.QueryString["Param"].ToString();
            //else
            //    FName = null;

            if (txtSCompanyName.SelectedValue != Guid.Empty.ToString())
                CompanyName = Convert.ToString(txtSCompanyName.SelectedValue);
            else
                CompanyName = null;

            if (hfSelectedAlphabet.Value.ToString() != string.Empty)
            {
                if (hfSelectedAlphabet.Value.ToString() != "ALL")
                    DisplayName = hfSelectedAlphabet.Value.ToString();
                else
                    DisplayName = null;

                hfSelectedAlphabet.Value = string.Empty;
            }
            else
            {
                if (txtSearchDisplayName.Text.Trim() != "")
                    DisplayName = txtSearchDisplayName.Text.Trim();
                else
                    DisplayName = null;
            }

            //if (txtSearchDisplayName.Text.Trim() != "")
            //    DisplayName = Convert.ToString(txtSearchDisplayName.Text.Trim());
            //else
            //    DisplayName = null;

            Guid? CompanyID = this.CompanyID;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN")
                CreatedBy = null;
            else
                CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
            if (txtSearchLocation.Text.Trim() != "")
                Location = txtSearchLocation.Text.Trim();
            else
                Location = null;
            DataSet Dst = new DataSet();
            if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                Dst = ChannelPartnerBLL.SearchInfo(null, null, null, CompanyName, DisplayName, CompanyID, null, Location);
            else
                Dst = ChannelPartnerBLL.SearchInfo(null, null, null, CompanyName, DisplayName, CompanyID, CreatedBy, Location);

            //Dst = ChannelPartnerBLL.SearchInfo(FName, null, null, CompanyName, DisplayName, CompanyID, CreatedBy, Location);
            DataView dv = new DataView(Dst.Tables[0]);
            dv.Sort = "DisplayName ASC";
            grdChannerPartnerList.DataSource = Dst.Tables[0];
            grdChannerPartnerList.DataBind();

            litChannelPartnersCount.Text = "(" + Convert.ToString(Dst.Tables[0].Rows.Count) + ")";
        }

        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Channel Partner List");
                string FName = null, CompanyName = null, DisplayName = null, Location = null;
                Guid? CreatedBy;

                if (Request.QueryString["Param"] != null && Request.QueryString["Param"].ToUpper() != "ALL")
                    FName = Request.QueryString["Param"].ToString();
                else
                    FName = null;
                if (txtSCompanyName.SelectedValue != Guid.Empty.ToString())
                    CompanyName = Convert.ToString(txtSCompanyName.SelectedValue);
                else
                    CompanyName = null;

                if (txtSearchDisplayName.Text.Trim() != "")
                    DisplayName = txtSearchDisplayName.Text.Trim();
                else
                    DisplayName = null;
                Guid? CompanyID = this.CompanyID;
                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.ToUpper() == "ADMIN")
                    CreatedBy = null;
                else
                    CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                if (txtSearchLocation.Text.Trim() != "")
                    Location = txtSearchLocation.Text.Trim();
                else
                    Location = null;

                Session.Add("Name", DisplayName);
                Session.Add("City", Location);
                Session.Add("CompName", CompanyName);

                DataSet Dst = new DataSet();
                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                    Dst = ChannelPartnerBLL.SearchInfo(FName, null, null, CompanyName, DisplayName, CompanyID, null, Location);
                else
                    Dst = ChannelPartnerBLL.SearchInfo(FName, null, null, CompanyName, DisplayName, CompanyID, CreatedBy, Location);

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
        /// Add New Channel Partner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/Investors/ChannelPartnerSetUp.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Add New

        #region Grid Event
        /// <summary>
        /// Row Data Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdChannerPartnerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    Session["ChannelPartnerID"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Applications/Investors/ChannelPartnerSetUp.aspx");
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    ViewState["ChannelPartnerID"] = e.CommandArgument.ToString();
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdChannerPartnerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdChannerPartnerList.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdChannerPartnerList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[4].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[4].Text = "View";
                    e.Row.Cells[4].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["Delete"]);
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                    if (litMobileNo != null)
                    {
                        if (Convert.ToString(strMobileNo) != "")
                            litMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                        else
                            litMobileNo.Text = "";
                    }

                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        EditImg.ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        EditImg.ToolTip = "View";
                    e.Row.Cells[4].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["Delete"]);

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[4].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[4].Text = "View";
                    e.Row.Cells[4].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["Delete"]);
                }
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
                ViewState["ChannelPartnerID"] = null;
                msgbx.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Ok Buton Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ChannelPartnerID"] != null)
                {
                    ChannelPartner GetInv = ChannelPartnerBLL.GetByPrimaryKey(new Guid(ViewState["ChannelPartnerID"].ToString()));

                    if (GetInv.UserID != null && Convert.ToString(GetInv.UserID) != "")
                    {
                        bool ISDeletePermission = false;

                        DataSet dsDeletePermission = ChannelPartnerBLL.SelectDeletePermission(GetInv.UserID);
                        if (dsDeletePermission.Tables.Count > 0 && dsDeletePermission.Tables[0].Rows.Count > 0)
                        {
                            ISDeletePermission = true;
                            IsInsert = true;
                            lblProspctLstMsg.Text = "Can not be deleted ! Already Use.";
                            ViewState["ChannelPartnerID"] = null;
                            msgbx.Hide();
                            return;
                        }
                        if (ISDeletePermission == false)
                        {
                            if (dsDeletePermission.Tables.Count > 0 && dsDeletePermission.Tables[1].Rows.Count > 0)
                            {
                                ISDeletePermission = true;
                                IsInsert = true;
                                lblProspctLstMsg.Text = "Can not be deleted ! Already Use.";
                                ViewState["ChannelPartnerID"] = null;
                                msgbx.Hide();
                                return;
                            }
                        }
                    }

                    ChannelPartnerBLL.Delete(new Guid(Convert.ToString(ViewState["ChannelPartnerID"])));
                    IsInsert = true;
                    lblProspctLstMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ViewState["ChannelPartnerID"] = null;
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetInv.ToString(), null, "irm_ChannelPartner");
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
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

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

        protected void lnkAlphabet_OnClick(object sender, EventArgs e)
        {
            try
            {
                txtSearchDisplayName.Text = txtSearchLocation.Text = string.Empty;
                txtSCompanyName.SelectedIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event
    }
}