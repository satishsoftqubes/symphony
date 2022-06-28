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
    public partial class CtrlChannelPartnerUserStatus : System.Web.UI.UserControl
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
        public int SelectedRowIndex
        {
            get
            {
                return ViewState["SelectedRowIndex"] != null ? Convert.ToInt32(ViewState["SelectedRowIndex"]) : -1;
            }
            set
            {
                ViewState["SelectedRowIndex"] = value;
            }
        }
        public string StatusAction
        {
            get
            {
                return ViewState["StatusAction"] != null ? Convert.ToString(ViewState["StatusAction"]) : "";
            }
            set
            {
                ViewState["StatusAction"] = value;
            }
        }
        public string CPFullName
        {
            get
            {
                return ViewState["CPFullName"] != null ? Convert.ToString(ViewState["CPFullName"]) : "";
            }
            set
            {
                ViewState["CPFullName"] = value;
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
                    //btnAdd.Visible = btnAddUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                    //ViewState["View"] = imgbtnDOC.Visible = imgbtnXLSX.Visible = imgbtnPDF.Visible = btnPrint.Visible = Convert.ToBoolean(DV[0]["IsView"]);
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
                Dst = ChannelPartnerBLL.SelectAllForUserStatus(null, null, null, CompanyName, DisplayName, CompanyID, null, Location, ddlSStatus.SelectedValue.ToString());
            else
                Dst = ChannelPartnerBLL.SelectAllForUserStatus(null, null, null, CompanyName, DisplayName, CompanyID, CreatedBy, Location, ddlSStatus.SelectedValue.ToString());

            //Dst = ChannelPartnerBLL.SearchInfo(FName, null, null, CompanyName, DisplayName, CompanyID, CreatedBy, Location);
            //DataView dv = new DataView(Dst.Tables[0]);
            //dv.Sort = "DisplayName ASC";
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

        private void SendActivateEmail(User objUser)
        {
            try
            {
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Channel Partner Activation");
                    if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                    {
                        PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                        string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/ActivateInvestor.htm"));

                        strHTML = strHTML.Replace("$FULLNAME$", this.CPFullName);
                        strHTML = strHTML.Replace("$PASSWORD$", objUser.Password);
                        strHTML = strHTML.Replace("$USERNAME$", objUser.UserName);
                        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        strHTML = strHTML.Replace("$COMPANYEMAIL$", Convert.ToString(Prj.PrimoryEmail));

                        /////SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), objUser.UserName, "Investor Log in activation", strHTML);
                        SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress),"vijay@softqube.co.in", "Channel Partner Log in activation", strHTML);
                    }
                }
                else
                {
                    MessageBox.Show("Please set Company email configuration");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString() + " Once Send Email");
            }
        }

        private void SendDeActivateEmail(User objUser)
        {
            try
            {
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Investor Deactivation");
                    if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                    {
                        PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                        string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/Deactivate.htm"));

                        strHTML = strHTML.Replace("$FULLNAME$", this.CPFullName);
                        strHTML = strHTML.Replace("$PASSWORD$", objUser.Password);
                        strHTML = strHTML.Replace("$USERNAME$", objUser.UserName);
                        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        strHTML = strHTML.Replace("$COMPANYEMAIL$", Convert.ToString(Prj.PrimoryEmail));

                        /////SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), objUser.UserName, "Investor Log in deactivation", strHTML);
                    }
                }
                else
                {
                    MessageBox.Show("Please set Company email configuration");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString() + " Once Send Email");
            }
        }

        #endregion Private Method

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
                if (e.CommandName.Equals("RESENDACTMAIL"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.SelectedRowIndex = Convert.ToInt32(row.RowIndex);

                    this.CPFullName = ((Label)row.FindControl("lblGvFullName")).Text;

                    lblAskConfirmation.ForeColor = System.Drawing.Color.Black;
                    lblAskConfirmation.Text = "Are you sure you want to resend activation mail to this Channel Partner?";
                    this.StatusAction = "REACTIVATE";

                    mpeAskConfirmation.Show();
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

                    RadioButtonList rdbl = (RadioButtonList)e.Row.FindControl("rdblInvestorStatus");

                    if (DataBinder.Eval(e.Row.DataItem, "UserName") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserName")) != string.Empty)
                    {
                        if (DataBinder.Eval(e.Row.DataItem, "IsActive") != null && Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsActive")))
                        {
                            rdbl.SelectedValue = "1";
                            ((LinkButton)e.Row.FindControl("lnkResendActivationMail")).Visible = true;
                        }
                        else
                            rdbl.SelectedValue = "0";
                    }
                    else
                        rdbl.Visible = false;

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

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

        protected void rdblInvestorStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rdblList = (RadioButtonList)sender;
            GridViewRow row = (GridViewRow)((rdblList).NamingContainer);
            this.SelectedRowIndex = Convert.ToInt32(row.RowIndex);

            this.CPFullName = ((Label)row.FindControl("lblGvFullName")).Text;
            if (rdblList.SelectedValue.ToString() == "0")
            {
                lblAskConfirmation.ForeColor = System.Drawing.Color.Red;
                lblAskConfirmation.Text = "Are you sure you want to <b>DEACTIVATE</b> this Channel Partner?";
                this.StatusAction = "DEACTIVATE";

            }
            else
            {
                lblAskConfirmation.ForeColor = System.Drawing.Color.Black;
                lblAskConfirmation.Text = "Are you sure you want to <b>ACTIVATE</b> this Channel Partner?";
                this.StatusAction = "ACTIVATE";
            }
            mpeAskConfirmation.Show();
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

        #region Popup Button Event
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedRowIndex != -1)
                {
                    Guid usrID = new Guid(Convert.ToString(grdChannerPartnerList.DataKeys[this.SelectedRowIndex]["UserID"]));
                    User invUser = UserBLL.GetByPrimaryKey(usrID);
                    User OldinvUser = UserBLL.GetByPrimaryKey(usrID);

                    if (this.StatusAction == "ACTIVATE" || this.StatusAction == "REACTIVATE")
                    {
                        invUser.IsActive = true;
                        UserBLL.Update(invUser);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldinvUser.ToString(), invUser.ToString(), "usr_User");

                        IsInsert = true;
                        if (this.StatusAction == "ACTIVATE")
                            lblCPMsg.Text = "Channel Partner activated successfully.";
                        else if (this.StatusAction == "REACTIVATE")
                            lblCPMsg.Text = "Channel Partner activation mail resent successfully.";

                        SendActivateEmail(invUser);
                    }
                    else
                    {
                        invUser.IsActive = false;
                        UserBLL.Update(invUser);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldinvUser.ToString(), invUser.ToString(), "usr_User");

                        IsInsert = true;
                        lblCPMsg.Text = "Channel Partner deactivated successfully.";

                        ////SendDeActivateEmail(invUser);  Not to send deactivation email, If to send in future, just uncomment this and make isActive=1 in emailTemplate table.
                    }

                    mpeAskConfirmation.Hide();
                }

                grdChannerPartnerList.PageIndex = 0;
                BindGrid();
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
        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButtonList rdbl = (RadioButtonList)grdChannerPartnerList.Rows[this.SelectedRowIndex].FindControl("rdblInvestorStatus");

                if (this.StatusAction.ToUpper() == "ACTIVATE")
                    rdbl.SelectedValue = "0";
                else if (this.StatusAction.ToUpper() == "DEACTIVATE")
                    rdbl.SelectedValue = "1";
                else if (this.StatusAction.ToUpper() == "REACTIVATE")
                    rdbl.SelectedValue = "1";

                mpeAskConfirmation.Hide();
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