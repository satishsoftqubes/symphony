using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class NewsLatter : System.Web.UI.UserControl
    {

        #region Variable

        public bool IsInsert = false;
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
            if (RoleRightJoinBLL.GetAccessString("NewLattersSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");

            LoadAccess();
            if (!IsPostBack)
            {
                LoadDefaultData();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("NewLattersSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = btnPublish.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (ViewState["NewLatterID"] == null)
                    btnSave.Visible = btnPublish.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                ClearControlValue();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Clear Control Value
        /// </summary>
        private void ClearControlValue()
        {
            LoadNewsFor();
            ddlNewsFor.SelectedValue = Guid.Empty.ToString();
            txtTitle.Text = "";
            txtSTitle.Text = "";
            edtrDetail.Text = "";
            ViewState["NewLatterID"] = null;
            txtTitle.Focus();
            BindGrid();
            BindInvestor();
            BindPropspects();
            BindChannelPartner();
            BindSales();
            //btnPublish.Visible = true;
        }
        /// <summary>
        /// Bind Investor Information
        /// </summary>
        private void BindInvestor()
        {
            chkInvestorList.Items.Clear();
            DataSet Dst = InvestorBLL.GetAllInvestorForEmailSubscription();

            if (Dst.Tables.Count > 0 && Dst.Tables[0].Rows.Count > 0)
            {
                chkInvestorList.DataSource = Dst;
                chkInvestorList.DataTextField = "FullName";
                chkInvestorList.DataValueField = "Email";
                chkInvestorList.DataBind();
            }
        }
        /// <summary>
        /// Bind Prospects Information
        /// </summary>
        public void BindPropspects()
        {
            chkProspectList.Items.Clear();
            DataSet Dst = ProspectsBLL.GetAllProspectsForEmailSubscription();

            if (Dst.Tables.Count > 0 && Dst.Tables[0].Rows.Count > 0)
            {
                chkProspectList.DataSource = Dst;
                chkProspectList.DataTextField = "FullName";
                chkProspectList.DataValueField = "Email";
                chkProspectList.DataBind();
            }
        }

        public void BindChannelPartner()
        {
            chkChannelPartnerList.Items.Clear();
            DataSet DstChannelPartner = ChannelPartnerBLL.GetAllChannelPartnerForEmailSubscription();

            if (DstChannelPartner.Tables.Count > 0 && DstChannelPartner.Tables[0].Rows.Count > 0)
            {
                chkChannelPartnerList.DataSource = DstChannelPartner;
                chkChannelPartnerList.DataTextField = "FullName";
                chkChannelPartnerList.DataValueField = "Email";
                chkChannelPartnerList.DataBind();
            }
        }

        public void BindSales()
        {
            chkSalesList.Items.Clear();
            DataSet DstSales = SalesTeamBLL.GetAllSalesForEmailSubscription();

            if (DstSales.Tables.Count > 0 && DstSales.Tables[0].Rows.Count > 0)
            {
                chkSalesList.DataSource = DstSales;
                chkSalesList.DataTextField = "FullName";
                chkSalesList.DataValueField = "Email";
                chkSalesList.DataBind();
            }
        }
        /// <summary>
        /// Load News Publisher Information
        /// </summary>
        private void LoadNewsFor()
        {
            ddlNewsFor.Items.Clear();
            ProjectTerm GetUserType = new ProjectTerm();
            GetUserType.Category = "USERTYPE";
            GetUserType.IsActive = true;
            List<ProjectTerm> LstUserType = ProjectTermBLL.GetAll(GetUserType);
            if (LstUserType.Count > 0)
            {
                LstUserType.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlNewsFor.DataSource = LstUserType;
                ddlNewsFor.DataTextField = "DisplayTerm";
                ddlNewsFor.DataValueField = "TermID";
                ddlNewsFor.DataBind();
                ddlNewsFor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlNewsFor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            string Title = null;
            if (!txtSTitle.Text.Equals(""))
                Title = txtSTitle.Text;
            DataSet Dst = NewsLettersBLL.SearchData(Title);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv.Sort = "Title ASC";
            grdNewList.DataSource = Dv;
            grdNewList.DataBind();

        }
        /// <summary>
        /// Publish Information
        /// </summary>
        public void PublishNewsLatter()
        {
            for (int i = 0; i < chkInvestorList.Items.Count; i++)
            {
                if (chkInvestorList.Items[i].Selected)
                {
                   SendEmail(chkInvestorList.Items[i].Text, chkInvestorList.Items[i].Value, Convert.ToString(edtrDetail.Text.Trim()));
                }
            }
            for (int j = 0; j < chkProspectList.Items.Count; j++)
            {
                if (chkProspectList.Items[j].Selected)
                {
                    SendEmail(chkProspectList.Items[j].Text, chkProspectList.Items[j].Value, Convert.ToString(edtrDetail.Text.Trim()));
                }
            }
            for (int k = 0; k < chkChannelPartnerList.Items.Count; k++)
            {
                if (chkChannelPartnerList.Items[k].Selected)
                {
                    SendEmail(chkChannelPartnerList.Items[k].Text, chkChannelPartnerList.Items[k].Value, Convert.ToString(edtrDetail.Text.Trim()));
                }
            }
            for (int l = 0; l < chkSalesList.Items.Count; l++)
            {
                if (chkSalesList.Items[l].Selected)
                {
                    SendEmail(chkSalesList.Items[l].Text, chkSalesList.Items[l].Value, Convert.ToString(edtrDetail.Text.Trim()));
                }
            }

            if (chkSelectAllDatabase.Checked)
            {
                DataSet DsEmployee = EmployeeBLL.GetAllEmployeeForEmailSubscription();

                if (DsEmployee.Tables.Count > 0 && DsEmployee.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DsEmployee.Tables[0].Rows.Count; i++)
                    {
                        SendEmail(Convert.ToString(DsEmployee.Tables[0].Rows[i]["FullName"]), Convert.ToString(DsEmployee.Tables[0].Rows[i]["Email"]), Convert.ToString(edtrDetail.Text.Trim()));
                    }
                }

                string strUserName = "select UserName,UserDisplayName from usr_User where UserType = 'Admin' and IsActive = 1 and CompanyID = '" + Convert.ToString(Session["CompanyID"]) + "'";
                DataSet dsUser = UserBLL.GetUserName(strUserName);

                if (dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0)
                {
                    for (int m = 0; m < dsUser.Tables[0].Rows.Count; m++)
                    {
                        SendEmail(Convert.ToString(dsUser.Tables[0].Rows[m]["UserDisplayName"]), Convert.ToString(dsUser.Tables[0].Rows[m]["UserName"]), Convert.ToString(edtrDetail.Text.Trim()));
                    }
                }
            }
        }
        /// <summary>
        /// Send Email To Investor Creation
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void SendEmail(string FullName, string UserName, string BodyText)
        {

            ////if (Session["PropertyConfigurationInfo"] != null)
            ////{
            ////    PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
            ////    SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), UserName, "News Update", BodyText);
            ////}
            ////else
            ////    MessageBox.Show("Please set Company email configuration");
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Add New News Latter Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControlValue();
            btnSave.Visible = btnPublish.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    NewsLetters Dup = new NewsLetters();
                    Dup.Title = txtTitle.Text.Trim();
                    Dup.IsActive = true;
                    List<NewsLetters> DupLst = NewsLettersBLL.GetAll(Dup);
                    if (DupLst.Count > 0)
                    {
                        if (ViewState["NewLatterID"] != null)
                        {
                            if (Convert.ToString((DupLst[0].NewsLetterID)) != Convert.ToString(ViewState["NewLatterID"]))
                            {
                                IsInsert = true;
                                lblNewsMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsInsert = true;
                            lblNewsMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    if (ViewState["NewLatterID"] != null)
                    {
                        //Update News Latter Information
                        NewsLetters Updt = NewsLettersBLL.GetByPrimaryKey(new Guid(ViewState["NewLatterID"].ToString()));
                        NewsLetters OldUpdt = NewsLettersBLL.GetByPrimaryKey(new Guid(ViewState["NewLatterID"].ToString()));
                        Updt.Title = txtTitle.Text.Trim();
                        Updt.Details = edtrDetail.Text;
                        if (ddlNewsFor.SelectedValue != Guid.Empty.ToString())
                            Updt.NewsLetterFor_TermID = new Guid(ddlNewsFor.SelectedValue.ToString());
                        Updt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Updt.UpdatedOn = DateTime.Now.Date;
                        Updt.IsActive = true;
                        Updt.CompanyID = this.CompanyID;
                        NewsLettersBLL.Update(Updt);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldUpdt.ToString(), Updt.ToString(), "mst_NewsLetters");
                        IsInsert = true;
                        lblNewsMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        //Insert News Latter Information
                        NewsLetters Ins = new NewsLetters();
                        Ins.Title = txtTitle.Text.Trim();
                        Ins.Details = edtrDetail.Text;
                        Ins.IsPublished = false;
                        if (ddlNewsFor.SelectedValue != Guid.Empty.ToString())
                            Ins.NewsLetterFor_TermID = new Guid(ddlNewsFor.SelectedValue.ToString());
                        Ins.UpdatedOn = DateTime.Now;
                        Ins.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.IsActive = true;
                        Ins.CompanyID = this.CompanyID;
                        NewsLettersBLL.Save(Ins);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", null, Ins.ToString(), "mst_NewsLetters");
                        IsInsert = true;
                        lblNewsMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControlValue();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ClearControlValue();
        //    LoadAccess();
        //}
        /// <summary>
        /// Publish And Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BindInvestor();
                BindPropspects();
                BindChannelPartner();
                BindSales();

                if (chkInvestorList.Items.Count == 0 && chkProspectList.Items.Count == 0 && chkChannelPartnerList.Items.Count == 0 && chkSalesList.Items.Count == 0)
                {
                    btnInvProsSend.Visible = false;
                }
                MailMsg.Show();

            }
        }
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        #endregion Button Event

        #region Grid Row Command Event
        /// <summary>
        /// Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdNewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITDATA"))
            {
                try
                {
                    ViewState["NewLatterID"] = e.CommandArgument.ToString();
                    NewsLetters GetForUpdt = NewsLettersBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["NewLatterID"])));
                    txtTitle.Text = GetForUpdt.Title;
                    edtrDetail.Text = GetForUpdt.Details;
                    if (GetForUpdt.NewsLetterFor_TermID != null)
                        ddlNewsFor.SelectedIndex = ddlNewsFor.Items.FindByValue(Convert.ToString(GetForUpdt.NewsLetterFor_TermID)) != null ? ddlNewsFor.Items.IndexOf(ddlNewsFor.Items.FindByValue(Convert.ToString(GetForUpdt.NewsLetterFor_TermID))) : 0;
                    else
                        ddlNewsFor.SelectedValue = Guid.Empty.ToString();
                    LoadAccess();
                    if (Convert.ToBoolean(GetForUpdt.IsPublished))
                        btnPublish.Visible = false;
                    else
                        btnPublish.Visible = true;
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (e.CommandName.Equals("DELETEDATA"))
            {
                ViewState["NewLatterID"] = e.CommandArgument.ToString();
                msgbx.Show();
            }
        }

        #endregion Grid Row Command Event

        #region Popup Button Event
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            if (ViewState["NewLatterID"] != null)
            {
                NewsLetters NewsDel = NewsLettersBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["NewLatterID"])));
                NewsLettersBLL.Delete(new Guid(Convert.ToString(ViewState["NewLatterID"].ToString())));
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", NewsDel.ToString(), null, "mst_NewsLetters");
                IsInsert = true;
                lblNewsMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                ClearControlValue();
            }
            ViewState["NewLatterID"] = null;
            msgbx.Hide();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            ViewState["NewLatterID"] = null;
            msgbx.Hide();
        }
        #endregion Popup Button Event

        #region Grid Row DataBound
        /// <summary>
        /// Grid Row DataBound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdNewList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";
            }
        }

        #endregion Grid Row DataBound

        #region Send Email Popup Button Event
        /// <summary>
        /// Investor Mail Send Option Here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInvProsSend_Click(object sender, EventArgs e)
        {
            try
            {
                NewsLetters Dup = new NewsLetters();
                Dup.Title = txtTitle.Text.Trim();
                Dup.IsActive = true;
                List<NewsLetters> DupLst = NewsLettersBLL.GetAll(Dup);
                if (DupLst.Count > 0)
                {
                    if (ViewState["NewLatterID"] != null)
                    {
                        if (Convert.ToString((DupLst[0].NewsLetterID)) != Convert.ToString(ViewState["NewLatterID"]))
                        {
                            IsInsert = true;
                            lblNewsMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }
                    else
                    {
                        IsInsert = true;
                        lblNewsMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                        return;
                    }
                }

                if (ViewState["NewLatterID"] != null)
                {
                    //Update News Latter Information
                    NewsLetters Updt = NewsLettersBLL.GetByPrimaryKey(new Guid(ViewState["NewLatterID"].ToString()));
                    NewsLetters OldUpdt = NewsLettersBLL.GetByPrimaryKey(new Guid(ViewState["NewLatterID"].ToString()));
                    Updt.Title = txtTitle.Text.Trim();
                    Updt.Details = edtrDetail.Text;
                    if (ddlNewsFor.SelectedValue != Guid.Empty.ToString())
                        Updt.NewsLetterFor_TermID = new Guid(ddlNewsFor.SelectedValue.ToString());
                    Updt.IsPublished = true;
                    Updt.PublishedOn = DateTime.Now.Date;
                    Updt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    Updt.UpdatedOn = DateTime.Now.Date;
                    Updt.IsActive = true;
                    Updt.CompanyID = this.CompanyID;
                    NewsLettersBLL.Update(Updt);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldUpdt.ToString(), Updt.ToString(), "mst_NewsLetters");
                    IsInsert = true;
                    lblNewsMsg.Text = global::Resources.IRMSMsg.UpdatePubMsg.ToString().Trim();
                }
                else
                {
                    //Insert News Latter Information
                    NewsLetters Ins = new NewsLetters();
                    Ins.Title = txtTitle.Text.Trim();
                    Ins.Details = edtrDetail.Text;
                    if (ddlNewsFor.SelectedValue != Guid.Empty.ToString())
                        Ins.NewsLetterFor_TermID = new Guid(ddlNewsFor.SelectedValue.ToString());
                    Ins.IsPublished = true;
                    Ins.PublishedOn = DateTime.Now.Date;
                    Ins.UpdatedOn = DateTime.Now;
                    Ins.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    Ins.CreatedOn = DateTime.Now.Date;
                    Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    Ins.IsActive = true;
                    Ins.CompanyID = this.CompanyID;
                    NewsLettersBLL.Save(Ins);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", null, Ins.ToString(), "mst_NewsLetters");
                    IsInsert = true;
                    lblNewsMsg.Text = global::Resources.IRMSMsg.SavePubMsg.ToString().Trim();
                }
                PublishNewsLatter();
                ClearControlValue();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
            MailMsg.Hide();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnInvProsCancel_Click(object sender, EventArgs e)
        {
            MailMsg.Hide();
        }
        #endregion Send Email Popup Button Event
    }
}