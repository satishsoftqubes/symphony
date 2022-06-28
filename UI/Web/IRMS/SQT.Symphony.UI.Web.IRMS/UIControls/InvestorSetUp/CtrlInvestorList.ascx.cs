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
    public partial class CtrlInvestorList : System.Web.UI.UserControl
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
            if (RoleRightJoinBLL.GetAccessString("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            if (!IsPostBack)
            {
                if (Session["UserType"] != null)
                {
                    string strUserType = Convert.ToString(Session["UserType"]);
                    if (strUserType.ToUpper().Equals("ADMIN"))
                    {
                        txtSearchChannelPartnerFirm.Enabled = txtSearchExecutiveName.Enabled = true;
                        //ddlManagerType.Enabled = true;
                        //ddlRelationManagementID.Enabled = true;                        
                    }
                    else
                    {
                        //ddlManagerType.Enabled = false;
                        //ddlRelationManagementID.Enabled = false;
                        txtSearchChannelPartnerFirm.Enabled = txtSearchExecutiveName.Enabled = false;
                    }
                }
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Title Here
        /// </summary>
        /// <param name="ddl">ddl as DropDownList</param>
        //private void LoadManagerType()
        //{
        //    ddlManagerType.Items.Clear();
        //    ProjectTerm TitleTerm = new ProjectTerm();
        //    TitleTerm.Category = "MANAGERTYPE";
        //    TitleTerm.IsActive = true;
        //    TitleTerm.CompanyID = this.CompanyID;
        //    List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
        //    if (Lst.Count > 0)
        //    {
        //        Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
        //        ddlManagerType.DataSource = Lst;
        //        ddlManagerType.DataTextField = "DisplayTerm";
        //        ddlManagerType.DataValueField = "Term";
        //        ddlManagerType.DataBind();
        //        ddlManagerType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlManagerType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

        //    ddlRelationManagementID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //}
        /// <summary>
        /// Bind Investor Name
        /// </summary>
        //private void BindInvestorName()
        //{
        //    string UserType = Convert.ToString(Session["UserType"]);
        //    string InvestorNameQuery = string.Empty;
        //    if (UserType.ToUpper() == "ADMIN")
        //        InvestorNameQuery = "Select Title + ' ' + FName + ' ' + LName As FullName, FName From irm_Investor Where IsActive = 1 and RefInverstorID is null Order By FName ASC";
        //    else
        //        InvestorNameQuery = "Select Title + ' ' + FName + ' ' + LName As FullName, FName From irm_Investor Where IsActive = 1 and RefInverstorID is null And RelationShipManagerID like '" + Convert.ToString(Session["UserID"]) + "' Order By FName ASC";

        //    DataSet InvestorDst = InvestorBLL.GetSearchData(InvestorNameQuery);
        //    if (InvestorDst.Tables[0].Rows.Count > 0)
        //    {
        //        txtSInvestorName.DataSource = InvestorDst.Tables[0];
        //        txtSInvestorName.DataTextField = "FullName";
        //        txtSInvestorName.DataValueField = "FName";
        //        txtSInvestorName.DataBind();
        //        txtSInvestorName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //    }
        //    else
        //        txtSInvestorName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //}
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
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
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                //BindInvestorName();
                //LoadManagerType();
                string strManagerType = Convert.ToString(Session["InvUserType"]);

                ////if (strManagerType.ToUpper() != "ADMIN")
                ////    ddlManagerType.SelectedValue = Convert.ToString(Session["InvUserType"]);


                //else
                //    ddlManagerType.SelectedValue = Guid.Empty.ToString();

                ////ddlManagerType_SelectedIndexChanged(null, null);

                if (Convert.ToString(Session["UserType"]).ToUpper() != "ADMIN" && strManagerType.ToUpper() != "ADMIN")
                {
                    string strQuery = string.Empty;

                    if (strManagerType.ToUpper() == "SALES")
                    {
                        strQuery = "select UserID,DisplayName from irm_SalesTeam Where IsActive = 1 and UserID = '" + Convert.ToString(Session["UserTypeID"]) + "'";

                        DataSet dsResult = PaymentSlabeBLL.GetPaymentSlab(strQuery);

                        if (dsResult.Tables[0] != null && dsResult.Tables[0].Rows.Count > 0)
                            txtSearchExecutiveName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DisplayName"]);
                        else
                            txtSearchExecutiveName.Text = "";
                    }
                    else if (strManagerType.ToUpper() == "CHANNEL PARTNER")
                    {
                        strQuery = "select UserID,DisplayName from irm_ChannelPartner Where IsActive = 1 and UserID = '" + Convert.ToString(Session["UserTypeID"]) + "'";

                        DataSet dsResult = PaymentSlabeBLL.GetPaymentSlab(strQuery);

                        if (dsResult.Tables[0] != null && dsResult.Tables[0].Rows.Count > 0)
                            txtSearchExecutiveName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DisplayName"]);
                        else
                            txtSearchExecutiveName.Text = "";
                    }

                    ////ddlRelationManagementID.SelectedValue = Convert.ToString(Session["UserTypeID"]);
                }
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
            Investor GetInv = new Investor();
            string Location, FirmName, ExecutiveName = null;
            string InvestorName = null;
            string AlphabetValue = "ALL";

            //Guid? RelationShipManagerID;

            ////Old code of Alphabet click...
            //if (Request.QueryString["Param"] != null && Request.QueryString["Param"].ToUpper() != "ALL")
            //    FName = Request.QueryString["Param"].ToString();
            //else
            //    FName = null;

            if (hfSelectedAlphabet.Value.ToString() != string.Empty)
            {
                AlphabetValue = hfSelectedAlphabet.Value.ToString();
            }
            else
            {
                if (txtSInvestorName.Text.Trim() != "")
                    InvestorName = txtSInvestorName.Text.Trim();
                else
                    InvestorName = null;
            }

            if (!txtSLocation.Text.Trim().Equals(""))
                Location = txtSLocation.Text.Trim();
            else
                Location = null;

            if (!txtSearchChannelPartnerFirm.Text.Trim().Equals(""))
                FirmName = txtSearchChannelPartnerFirm.Text.Trim();
            else
                FirmName = null;

            if (!txtSearchExecutiveName.Text.Trim().Equals(""))
            {
                string[] strExecutiveName = txtSearchExecutiveName.Text.Trim().Split('-');

                if (strExecutiveName.Length > 0)
                    ExecutiveName = Convert.ToString(strExecutiveName[0]).Trim();
                else
                    ExecutiveName = "";
            }
            else
                ExecutiveName = null;

            string UserType = Convert.ToString(Session["UserType"]);

            ////if (UserType.ToUpper() == "ADMIN")
            ////{
            ////    if (ddlRelationManagementID.SelectedValue != Guid.Empty.ToString())
            ////        RelationShipManagerID = new Guid(ddlRelationManagementID.SelectedValue.ToString());
            ////    else
            ////        RelationShipManagerID = null;
            ////}
            ////else
            ////    RelationShipManagerID = new Guid(Convert.ToString(Session["UserTypeID"]));

            //DataSet Dst = InvestorBLL.SearchInfo(FName, null, null, InvestorName, null, this.CompanyID, RelationShipManagerID, Location);

            DataSet Dst = InvestorBLL.NewSearchInfo(InvestorName, Location, FirmName, ExecutiveName, this.CompanyID, AlphabetValue);
            grdInvestorList.DataSource = Dst.Tables[0];
            grdInvestorList.DataBind();

            litInvestorsCount.Text = "(" + Convert.ToString(Dst.Tables[0].Rows.Count) + ")";
        }

        protected void LoadReport()
        {
            try
            {
                string AlphabetValue = "ALL";
                string Location, FirmName, ExecutiveName = null;
                string InvestorName = null;

                if (hfSelectedAlphabet.Value.ToString() != string.Empty)
                {
                    AlphabetValue = hfSelectedAlphabet.Value.ToString();
                }
                else
                {
                    if (txtSInvestorName.Text.Trim() != "")
                        InvestorName = txtSInvestorName.Text.Trim();
                    else
                        InvestorName = null;
                }

                if (!txtSLocation.Text.Trim().Equals(""))
                    Location = txtSLocation.Text.Trim();
                else
                    Location = null;

                if (!txtSearchChannelPartnerFirm.Text.Trim().Equals(""))
                    FirmName = txtSearchChannelPartnerFirm.Text.Trim();
                else
                    FirmName = null;

                if (!txtSearchExecutiveName.Text.Trim().Equals(""))
                {
                    string[] strExecutiveName = txtSearchExecutiveName.Text.Trim().Split('-');

                    if (strExecutiveName.Length > 0)
                        ExecutiveName = Convert.ToString(strExecutiveName[0]).Trim();
                    else
                        ExecutiveName = "";
                }
                else
                    ExecutiveName = null;

                Session.Add("Name", InvestorName);
                Session.Add("City", Location);
                Session.Add("ChannelPartnerFirm", FirmName);
                Session.Add("ExecutiveName", ExecutiveName);
                string UserType = Convert.ToString(Session["UserType"]);

                ////if (UserType.ToUpper() == "ADMIN")
                ////{
                ////    if (ddlRelationManagementID.SelectedValue != Guid.Empty.ToString())
                ////        RelationShipManagerID = new Guid(ddlRelationManagementID.SelectedValue.ToString());
                ////    else
                ////        RelationShipManagerID = null;
                ////}
                ////else
                ////    RelationShipManagerID = new Guid(Convert.ToString(Session["UserTypeID"]));

                //DataSet Dst = InvestorBLL.SearchInfo(FName, null, null, InvestorName, null, this.CompanyID, RelationShipManagerID, Location);

                DataSet Dst = InvestorBLL.NewSearchInfo(InvestorName, Location, FirmName, ExecutiveName, this.CompanyID, AlphabetValue);

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
                hfSelectedAlphabet.Value = string.Empty;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkAlphabet_OnClick(object sender, EventArgs e)
        {
            try
            {
                txtSInvestorName.Text = txtSLocation.Text = string.Empty;
                if (Session["UserType"] != null && Convert.ToString(Session["UserType"]).ToUpper() == "ADMIN")
                    txtSearchChannelPartnerFirm.Text = txtSearchExecutiveName.Text = string.Empty;

                BindGrid();
            }
            catch (Exception ex)
            {
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
            Session.Add("ReportName", "Investor GridList");
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
            Session.Add("ReportName", "Investor GridList");
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Investor GridList");
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Investor GridList");
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Investor GridList");
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }

        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Grid Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdInvestorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    Session["InvID"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Applications/Investors/InvestorSetUp.aspx?Val=True");
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    ViewState["InvID"] = e.CommandArgument.ToString();
                    msgbx.Show();
                }
                else if (e.CommandName.Equals("GETUNIT"))
                {
                    Session["InvID"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Applications/Investors/InvestorUnitList.aspx?Val=True");

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[5].Text = "View/ Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[5].Text = "View";
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["Delete"]);
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["Delete"]);


                    Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                    if (litMobileNo != null)
                    {
                        if (Convert.ToString(strMobileNo) != "")
                            litMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                        else
                            litMobileNo.Text = "";
                    }

                    //ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    //ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    //EditImg.Enabled = Convert.ToBoolean(ViewState["View"]);
                    //DelImg.Enabled = Convert.ToBoolean(ViewState["Delete"]);

                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View";

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[5].Text = "View/ Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[5].Text = "View";
                    e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["Delete"]);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdInvestorList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInvestorList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event

        #region Load Manager Name
        /// <summary>
        /// Data Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        //protected void ddlManagerType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlRelationManagementID.Items.Clear();
        //    if (ddlManagerType.SelectedValue != Guid.Empty.ToString())
        //    {
        //        if (ddlManagerType.Text.Equals("Channel Partner"))
        //        {
        //            DataView dv = new DataView(PaymentSlabeBLL.GetPaymentSlab("select UserID,DisplayName from irm_ChannelPartner Where IsActive = 1").Tables[0]);
        //            if (dv.Count > 0)
        //            {
        //                dv.Sort = "DisplayName Asc";
        //                ddlRelationManagementID.DataSource = dv;
        //                ddlRelationManagementID.DataTextField = "DisplayName";
        //                ddlRelationManagementID.DataValueField = "UserID";
        //                ddlRelationManagementID.DataBind();
        //                ddlRelationManagementID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //            }
        //            else
        //                ddlRelationManagementID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //        }
        //        else if (ddlManagerType.Text.Equals("Sales"))
        //        {
        //            DataView dv = new DataView(PaymentSlabeBLL.GetPaymentSlab("select UserID,DisplayName from irm_SalesTeam Where IsActive = 1").Tables[0]);
        //            if (dv.Count > 0)
        //            {
        //                dv.Sort = "DisplayName Asc";
        //                ddlRelationManagementID.DataSource = dv;
        //                ddlRelationManagementID.DataTextField = "DisplayName";
        //                ddlRelationManagementID.DataValueField = "UserID";
        //                ddlRelationManagementID.DataBind();
        //                ddlRelationManagementID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //            }
        //            else
        //                ddlRelationManagementID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //        }
        //    }
        //    else
        //        ddlRelationManagementID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //}


        #endregion Load Manager Name

        #region Popup Button Event
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["InvID"] != null)
                {
                    Investor GetData = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvID"].ToString()));
                    InvestorBLL.Delete(new Guid(Convert.ToString(ViewState["InvID"])));
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetData.ToString(), null, "irm_Investor");
                    IsInsert = true;
                    lblInvestorMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ViewState["InvID"] = null;
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
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["InvID"] = null;
                msgbx.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Popup Button Event
    }
}