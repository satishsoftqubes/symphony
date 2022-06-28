using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.IO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Drawing.Imaging;
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlSalesTeam : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsInsert = false;
        public bool IsEmail = false;

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
        public Guid PropertyID
        {
            get
            {
                return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID"] = value;
            }
        }
        public Guid UserID
        {
            get
            {
                return ViewState["UserID"] != null ? new Guid(Convert.ToString(ViewState["UserID"])) : Guid.Empty;
            }
            set
            {
                ViewState["UserID"] = value;
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
            if (RoleRightJoinBLL.GetAccessString("SalesTeamSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
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
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("SalesTeamSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                btnSave.Enabled = btnSaveUP.Enabled = Convert.ToBoolean(DV[0]["IsCreate"]);
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
            try
            {
                LoadValidationControl();
                BindTitle();
                ddlTitle.SelectedValue = Guid.Empty.ToString();
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtDisplayName.Text = "";
                txtEmail.Text = "";
                txtMobileNo.Text = "";
                txtLandLineNo.Text = "";
                txtAddressLine1.Text = "";
                txtCountry.Text = "";
                txtState.Text = "";
                txtCity.Text = "";
                txtPostCode.Text = "";
                ddlTitle.Focus();
                BindGrid();
                imgSalesTeamPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                HypRemove.Visible = false;
                ViewState["SalesTeamID"] = null;
                this.UserID = Guid.Empty;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Validatio Control Here
        /// </summary>
        private void LoadValidationControl()
        {
            if (Session["PropertyConfigurationInfo"] != null)
            {
                PropertyConfiguration objPropertyConfigurationData = (PropertyConfiguration)Session["PropertyConfigurationInfo"];

                rvftxtPostCode.Enabled = !(Convert.ToBoolean(objPropertyConfigurationData.IsSkipPostCode));
                rvftxtAddressLine1.Enabled = rvfCity.Enabled = rvfState.Enabled = rvfCountry.Enabled = !(Convert.ToBoolean(objPropertyConfigurationData.IsSkipAddress));
                rvftxtLandLineNo.Enabled = !(Convert.ToBoolean(objPropertyConfigurationData.IsSkipContactNo));
                rvftxtEmail.Enabled = !(Convert.ToBoolean(objPropertyConfigurationData.IsSkipEmail));
            }
        }
        /// <summary>
        /// Bind Title Information
        /// </summary>
        private void BindTitle()
        {
            ddlTitle.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "TITLE";
            TitleTerm.IsActive = true;
            TitleTerm.CompanyID = this.CompanyID;

            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlTitle.DataSource = Lst;
                ddlTitle.DataTextField = "DisplayTerm";
                ddlTitle.DataValueField = "Term";
                ddlTitle.DataBind();
                ddlTitle.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlTitle.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Send Email To Investor Creation
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        public void SendEmail(string FullName, string UserName, string Password, Guid UserID, string PasswordKey)
        {
            try
            {
                //if (File.Exists(Server.MapPath("~/EmailTemplates/NewUserToActivate.htm")))
                DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("User Activation");
                if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                {
                    string strLink = Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "UserActivation.aspx?UserID=" + UserID.ToString() + "&key=" + PasswordKey;
                    string strActivationLink = "<a href='" + strLink + "'>" + strLink + "</a>";
                    List<PropertyConfiguration> LstPrtConfig = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.CompanyID, Convert.ToString(this.CompanyID));
                    if (LstPrtConfig.Count > 0)
                    {
                        PropertyConfiguration Prj = (PropertyConfiguration)(LstPrtConfig[0]);
                        string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/NewUserToActivate.htm"));
                        strHTML = strHTML.Replace("$DISPLAYNAME$", FullName.Trim());
                        strHTML = strHTML.Replace("$USERNAME$", UserName.Trim());
                        strHTML = strHTML.Replace("$PASSWORD$", Password.Trim());
                        strHTML = strHTML.Replace("$ACTIVATIONLINK$", strActivationLink);
                        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), txtEmail.Text.Trim(), "Activate your account on UniworldIndia.com", strHTML);
                    }
                    else
                        MessageBox.Show("Please set Company email configuration");
                }
                else
                    MessageBox.Show("Sorry for inconvenience, System can't send mail to your account.");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Inforamtion
        /// </summary>
        private void BindGrid()
        {
            string UserType = Session["UserType"].ToString().ToUpper();
            Guid? CreatedBy;
            if (UserType != "ADMIN")
                CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
            else
                CreatedBy = null;
            string FullName = "";
            if (!txtSTermName.Text.Equals(""))
                FullName = txtSTermName.Text.Trim();
            string strQuery = "Select SalesTeamID, DisplayName,Email, MobileNo,(select COUNT(*) from irm_Investor where RelationShipManagerID LIKE irm_SalesTeam.UserID and IsActive = 1) As 'TotalInvestor',(select COUNT(*) from irm_Prospects where ContactedBy like irm_SalesTeam.UserID and IsActive = 1) As 'TotalProspects' From irm_SalesTeam Where IsActive = 1" + (FullName.Trim().Equals("") ? "" : " And DisplayName Like '" + FullName + "%'") + (this.CompanyID == null ? null : " And CompanyID like '" + this.CompanyID.ToString() + "'") + (UserType == "ADMIN" ? null : " And CreatedBy Like '" + CreatedBy + "'");
            DataSet Dst = SalesTeamBLL.GetSearchData(strQuery);
            DataView Dv = new DataView(Dst.Tables[0]);
            grdSalesTeamList.DataSource = Dv;
            grdSalesTeamList.DataBind();
        }
        #endregion Private Method

        #region Button Event
        protected void btnCancelUp_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }
        protected void btnNewUp_Click(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveUP_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
        /// <summary>
        /// Add New Sale Team Member
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControlValue();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlValue();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public bool ThumbnailCallback() { return false; }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (!txtEmail.Text.Trim().Equals(""))
                    {
                        User IsDup = new User();
                        IsDup.UserName = txtEmail.Text.Trim();
                        List<User> LstDupWing = UserBLL.GetAll(IsDup);
                        if (LstDupWing.Count > 0)
                        {
                            if (ViewState["SalesTeamID"] != null)
                            {
                                if (LstDupWing[0].UsearID != new Guid(Convert.ToString(this.UserID)))
                                {
                                    IsInsert = true;
                                    lblSalesTeamMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                    return;
                                }
                            }
                            else
                            {
                                IsInsert = true;
                                lblSalesTeamMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                    }
                    if (ViewState["SalesTeamID"] != null)
                    {
                        //Update Data
                        SalesTeam objOldData = new SalesTeam();
                        SalesTeam Updt = SalesTeamBLL.GetByPrimaryKey(new Guid(ViewState["SalesTeamID"].ToString()));
                        objOldData = SalesTeamBLL.GetByPrimaryKey(new Guid(ViewState["SalesTeamID"].ToString()));

                        Updt.Title = ddlTitle.SelectedValue.ToString();
                        Updt.FName = txtFirstName.Text.Trim();
                        Updt.LName = txtLastName.Text.Trim();
                        Updt.DisplayName = txtDisplayName.Text.Trim();
                        Updt.MobileNo = txtMobileNo.Text.Trim();
                        Updt.LandLineNo = txtLandLineNo.Text.Trim();
                        Updt.Email = txtEmail.Text.Trim();

                        Updt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Updt.UpdatedOn = DateTime.Now.Date;
                        if (UplodFile.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "_" + UplodFile.FileName.Replace(" ", "_");
                            string path = Server.MapPath("~/UploadPhoto/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(UplodFile.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();
                            Updt.Thumb = cmpPhoto;
                        }

                        Address UpdtAddress = AddressBLL.GetByPrimaryKey(new Guid(Updt.AddressID.Value.ToString()));
                        UpdtAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
                        UpdtAddress.StateID = clsCommon.State(txtState.Text.Trim());
                        UpdtAddress.CityID = clsCommon.City(txtCity.Text.Trim());
                        UpdtAddress.Add1 = txtAddressLine1.Text.Trim();
                        UpdtAddress.ZipCode = txtPostCode.Text.Trim();


                        if (!Updt.Email.Trim().Equals(""))
                        {
                            User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(objOldData.UserID)));
                            if (UpdtUsr != null)
                            {
                                UpdtUsr.UserName = Updt.Email.Trim();
                                UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                                if (Updt.Email != objOldData.Email)
                                {
                                    UpdtUsr.IsActive = false;
                                    ////SendEmail(UpdtUsr.UserDisplayName, txtEmail.Text.Trim(), UpdtUsr.Password, UpdtUsr.UsearID, UpdtUsr.PasswordKey);
                                }
                                else
                                {
                                    UpdtUsr.IsActive = UpdtUsr.IsActive;
                                }
                                UserBLL.Update(UpdtUsr);
                            }
                        }
                        else
                        {
                            User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(objOldData.UserID)));
                            if (UpdtUsr != null)
                            {
                                UpdtUsr.UserName = Updt.Email.Trim();
                                UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                                UpdtUsr.IsActive = UpdtUsr.IsActive;
                                UserBLL.Update(UpdtUsr);
                            }
                        }
                        SalesTeamBLL.Update(Updt, UpdtAddress);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldData.ToString(), Updt.ToString(), "irm_SalesTeam");
                        IsInsert = true;
                        lblSalesTeamMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        ViewState["SalesTeamID"] = null;
                        this.UserID = Guid.Empty;

                    }
                    else
                    {
                        //Insert Data
                        SalesTeam Ins = new SalesTeam();
                        SQT.Symphony.BusinessLogic.Configuration.DTO.User Usr = new User();
                        Usr.UsearID = Guid.NewGuid();

                        Ins.Title = ddlTitle.SelectedValue.ToString();
                        Ins.FName = txtFirstName.Text.Trim();
                        Ins.LName = txtLastName.Text.Trim();
                        Ins.DisplayName = txtDisplayName.Text.Trim();
                        Ins.MobileNo = txtMobileNo.Text.Trim();
                        Ins.LandLineNo = txtLandLineNo.Text.Trim();
                        Ins.Email = txtEmail.Text.Trim();
                        Ins.IsActive = true;
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.CompanyID = this.CompanyID;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.UserID = Usr.UsearID;

                        if (UplodFile.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "_" + UplodFile.FileName.Replace(" ", "_");
                            string path = Server.MapPath("~/UploadPhoto/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(UplodFile.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)500;
                            double heightRatio = (double)origBMP.Height / (double)400;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();
                            Ins.Thumb = cmpPhoto;
                        }
                        else
                            Ins.Thumb = "BusinessCard.png";

                        Address SalesAddress = new Address();

                        SalesAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
                        SalesAddress.StateID = clsCommon.State(txtState.Text.Trim());
                        SalesAddress.CityID = clsCommon.City(txtCity.Text.Trim());
                        SalesAddress.Add1 = txtAddressLine1.Text.Trim();
                        SalesAddress.ZipCode = txtPostCode.Text.Trim();
                        SalesAddress.IsActive = true;
                        SalesAddress.CompanyID = this.CompanyID;

                        Usr.UserName = Ins.Email;
                        Usr.Password = Guid.NewGuid().ToString().Substring(0, 8).ToString();
                        Usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        Usr.CraetedOn = DateTime.Now.Date;
                        Usr.IsActive = false;
                        Usr.CompanyID = this.CompanyID;
                        Usr.UserType = "Sales";
                        Usr.IsBlock = false;
                        Usr.DisplayAvtar = Ins.Thumb;
                        Usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Usr.UserDisplayName = Ins.FName + " " + Ins.LName;


                        SalesTeamBLL.SaveWithUserID(Ins, SalesAddress, Usr);
                        if (!Usr.UserName.Equals(""))
                        {
                            ////SendEmail(txtDisplayName.Text.Trim(), Usr.UserName, Usr.Password, Usr.UsearID, Usr.PasswordKey);
                        }
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "irm_SalesTeam");
                        IsInsert = true;
                        lblSalesTeamMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
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
        /// Remove Avtar From Saleas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HypRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["SalesTeamID"] != null)
                {
                    SalesTeam GetImg = SalesTeamBLL.GetByPrimaryKey(new Guid(ViewState["SalesTeamID"].ToString()));
                    if (GetImg != null)
                    {
                        string DeletePath = Server.MapPath("~/UploadPhoto/") + Convert.ToString(GetImg.Thumb);
                        File.Delete(DeletePath);
                        GetImg.Thumb = "BusinessCard.png";
                        SalesTeamBLL.Update(GetImg);
                        HypRemove.Visible = false;
                        IsInsert = true;
                        lblSalesTeamMsg.Text = global::Resources.IRMSMsg.RemovePhotoMsg.ToString().Trim();
                        imgSalesTeamPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    }
                    else
                        imgSalesTeamPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                }
                else
                {
                    MessageBox.Show("Select Sales Team Information From The List");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Search Inforamtion
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
        /// Resend Activation Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkReSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UserID != Guid.Empty)
                {
                    User objUser = new User();
                    objUser = UserBLL.GetByPrimaryKey(this.UserID);
                    if (objUser != null)
                    {
                        lnkReSendEmail.Visible = false;
                        IsEmail = true;
                        IsInsert = true;
                        lblSalesTeamMsg.Text = global::Resources.IRMSMsg.lblEmailSendMsg.ToString().Trim();
                        lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
                        SendEmail(objUser.UserDisplayName, objUser.UserName, objUser.Password, objUser.UsearID, objUser.PasswordKey);
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdSalesTeamList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITDATA"))
            {
                try
                {
                    ViewState["SalesTeamID"] = e.CommandArgument.ToString();
                    SalesTeam Updt = SalesTeamBLL.GetByPrimaryKey(new Guid(ViewState["SalesTeamID"].ToString()));
                    if (!Convert.ToString(Updt.UserID).Equals(""))
                        this.UserID = (Guid)Updt.UserID;
                    User objLoadUserData = new User();
                    objLoadUserData = UserBLL.GetByPrimaryKey(this.UserID);
                    if (objLoadUserData == null)
                    {
                        IsEmail = true;
                        lnkReSendEmail.Visible = true;
                        lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
                    }
                    else if (objLoadUserData != null)
                    {
                        if (!Convert.ToBoolean(objLoadUserData.IsActive))
                        {
                            IsEmail = true;
                            lnkReSendEmail.Visible = true;
                            lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
                        }
                    }
                    ddlTitle.SelectedValue = Updt.Title;
                    txtFirstName.Text = Updt.FName;
                    txtLastName.Text = Updt.LName;
                    txtDisplayName.Text = Updt.DisplayName;
                    txtLandLineNo.Text = Updt.LName;
                    txtEmail.Text = Updt.Email;
                    txtMobileNo.Text = Updt.MobileNo;
                    txtLandLineNo.Text = Updt.LandLineNo;
                    if (Updt.Thumb.ToUpper().ToString().Trim() != "BUSINESSCARD.PNG")
                    {
                        imgSalesTeamPhoto.ImageUrl = "~/UploadPhoto/" + Updt.Thumb;
                        HypRemove.Visible = true;
                    }
                    else
                    {
                        imgSalesTeamPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                        HypRemove.Visible = false;
                    }

                    Address GetAdd = AddressBLL.GetByPrimaryKey(new Guid(Updt.AddressID.Value.ToString()));
                    txtAddressLine1.Text = GetAdd.Add1;
                    if (GetAdd.CityID != null)
                    {
                        City GetCt = CityBLL.GetByPrimaryKey(new Guid(GetAdd.CityID.Value.ToString()));
                        if (GetCt != null)
                            txtCity.Text = GetCt.CityName;
                        else
                            txtCity.Text = "";
                    }
                    else
                        txtCity.Text = "";
                    if (GetAdd.StateID != null)
                    {
                        State GetSt = StateBLL.GetByPrimaryKey(new Guid(GetAdd.StateID.Value.ToString()));
                        if (GetSt != null)
                            txtState.Text = GetSt.StateName;
                        else
                            txtState.Text = "";
                    }
                    else
                        txtState.Text = "";
                    if (GetAdd.CountryID != null)
                    {
                        Country Cnt = CountryBLL.GetByPrimaryKey(new Guid(GetAdd.CountryID.Value.ToString()));
                        if (Cnt != null)
                            txtCountry.Text = Cnt.CountryName;
                        else
                            txtCountry.Text = "";
                    }
                    else
                        txtCountry.Text = "";
                    txtPostCode.Text = GetAdd.ZipCode;
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (e.CommandName.Equals("DELETECOMMAND"))
            {
                lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                ViewState["SalesTeamID"] = e.CommandArgument.ToString();
                msgbx.Show();
            }
        }

        protected void grdSalesTeamList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    EditImg.Enabled = Convert.ToBoolean(ViewState["Edit"]);
                    DelImg.Enabled = Convert.ToBoolean(ViewState["Delete"]);

                    //string strUserType = Convert.ToString(Session["UserType"]);
                    //System.Web.UI.HtmlControls.HtmlTable tblTotal = (System.Web.UI.HtmlControls.HtmlTable)e.Row.FindControl("tblTotal");
                    //if (strUserType.ToUpper() == "ADMIN")
                    //    tblTotal.Visible = false;
                    //else
                    //    tblTotal.Visible = true;
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
        /// Cancel Button Evnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["SalesTeamID"] = null;
                this.UserID = Guid.Empty;
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
                msgbx.Hide();
                if (ViewState["SalesTeamID"] != null)
                {
                    SalesTeam GetData = SalesTeamBLL.GetByPrimaryKey(new Guid(ViewState["SalesTeamID"].ToString()));
                    SalesTeamBLL.Delete(new Guid(ViewState["SalesTeamID"].ToString()));
                    IsInsert = true;
                    ViewState["SalesTeamID"] = null;
                    this.UserID = Guid.Empty;
                    lblSalesTeamMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetData.ToString(), null, "irm_SalesTeam");

                }
                ClearControlValue();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Popup Button Evnet
    }
}