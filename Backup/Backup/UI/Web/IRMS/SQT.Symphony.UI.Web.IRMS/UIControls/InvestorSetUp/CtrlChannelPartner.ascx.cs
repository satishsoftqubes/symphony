using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlChannelPartner : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsEmail = false;
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
        public Guid ChannelPartnerID
        {
            get
            {
                return ViewState["ChannelPartnerID"] != null ? new Guid(Convert.ToString(ViewState["ChannelPartnerID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ChannelPartnerID"] = value;
            }
        }

        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
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
                    ViewState["Edit"] = btnSave.Visible = btnSaveUp.Visible = lnkReSendEmail.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                    ViewState["Add"] = btnNew.Visible = btnNewUp.Visible = btnCancel.Visible = btnCancelUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                    ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
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
        /// Send Email To Investor Creation
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void SendEmail(string FullName, string UserName, string Password, Guid UserID, string PasswordKey)
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
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                ClearControlValue();
                if (Session["ChannelPartnerID"] != null)
                {
                    LoadChannePartnerData(new Guid(Convert.ToString(Session["ChannelPartnerID"])));
                    this.ChannelPartnerID = new Guid(Convert.ToString(Session["ChannelPartnerID"]));
                    Session["ChannelPartnerID"] = null;
                }
                else
                    btnSave.Visible = btnSaveUp.Visible = true;
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
                rvfAddressLine1.Enabled = rvfCity.Enabled = rvfState.Enabled = rvfCountry.Enabled = !(Convert.ToBoolean(objPropertyConfigurationData.IsSkipAddress));

                if (!Convert.ToBoolean(objPropertyConfigurationData.IsSkipAddress))
                {
                    tdAddress1.Attributes.Add("class", "RequireFile");
                    tdCity.Attributes.Add("class", "RequireFile");
                    tdState.Attributes.Add("class", "RequireFile");
                    tdCountry.Attributes.Add("class", "RequireFile");
                }

                if (!Convert.ToBoolean(objPropertyConfigurationData.IsSkipPostCode))
                    tdPostCode.Attributes.Add("class", "RequireFile");
            }
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void ClearControlValue()
        {
            LoadValidationControl();
            LoadTitle(ddlTitle);
            ddlTitle.SelectedValue = Guid.Empty.ToString();
            this.ChannelPartnerID = Guid.Empty;
            this.UserID = Guid.Empty;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDisplayName.Text = "";
            txtEmail.Text = hfOldEmial.Value = "";
            txtMobileNo.Text = txtMobileCntNo.Text = "";
            txtLandLineNo.Text = "";
            txtAddressLine1.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            txtPostCode.Text = "";
            txtCompanyName.Text = "";
            imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
            HypRemove.Visible = false;
            hdnUploadPhoto.Value = "";
            txtDisplayNameoffirm.Text = "";

            //as per discussion with vijay.
            ////BindGrid();
            grdChannelPartnerList.Visible = false;
        }
        /// <summary>
        /// Load Prospected Data Information
        /// </summary>
        /// <param name="ProspectedID"></param>
        private void LoadChannePartnerData(Guid ChannelPartnerID)
        {
            try
            {
                ChannelPartner GetData = ChannelPartnerBLL.GetByPrimaryKey(ChannelPartnerID);
                if (!Convert.ToString(GetData.UserID).Equals(""))
                    this.UserID = (Guid)GetData.UserID;
                this.ChannelPartnerID = new Guid(Convert.ToString(GetData.ChannelPartnerID));

                User objLoadUserData = new User();
                objLoadUserData = UserBLL.GetByPrimaryKey(this.UserID);
                if (objLoadUserData == null)
                {
                    IsEmail = true;
                    lnkReSendEmail.Visible = false;
                    lblActivationMsg.Text = "User Not Found";
                }
                else if (objLoadUserData != null)
                {
                    if (!Convert.ToBoolean(objLoadUserData.IsActive))
                    {
                        IsEmail = true;
                        if (Convert.ToString(objLoadUserData.UserName).Equals(""))
                            lnkReSendEmail.Visible = false;
                        else
                            lnkReSendEmail.Visible = Convert.ToBoolean(ViewState["Edit"]);

                        lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
                    }
                }
                ddlTitle.SelectedValue = GetData.Title;
                txtFirstName.Text = GetData.FName;
                txtLastName.Text = GetData.LName;
                txtEmail.Text = hfOldEmial.Value = GetData.Email;

                if (Convert.ToString(GetData.MobileNo) != "" && GetData.MobileNo != null)
                {
                    string[] words = GetData.MobileNo.Split('-');
                    if (words.Length > 1)
                    {
                        txtMobileCntNo.Text = Convert.ToString(words[0]);
                        txtMobileNo.Text = Convert.ToString(words[1]);
                    }
                    else
                    {
                        txtMobileCntNo.Text = Convert.ToString(words[0]);
                        txtMobileNo.Text = "";
                    }
                }
                else
                {
                    txtMobileCntNo.Text = "";
                    txtMobileNo.Text = "";
                }

                //if (GetData.MobileNo.IndexOf("-") > 0)
                //{
                //    string[] words = GetData.MobileNo.Split('-');
                //    if (words.Length > 0)
                //    {
                //        txtMobileCntNo.Text = Convert.ToString(words[0]);
                //        txtMobileNo.Text = Convert.ToString(words[1]);
                //    }
                //}
                //else
                //{
                //    txtMobileCntNo.Text = "";
                //    txtMobileNo.Text = GetData.MobileNo;
                //}

                txtLandLineNo.Text = GetData.LandLineNo;
                txtDisplayName.Text = GetData.DisplayName;
                txtCompanyName.Text = GetData.CompanyName;
                txtDisplayNameoffirm.Text = Convert.ToString(GetData.DisplayNameOfFirm);

                if (GetData.Thumb.ToUpper().ToString().Trim() != "BUSINESSCARD.PNG")
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/" + GetData.Thumb;
                    HypRemove.Visible = Convert.ToBoolean(ViewState["Edit"]);
                }
                else
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    HypRemove.Visible = false;
                }


                Address GetAddC = AddressBLL.GetByPrimaryKey(new Guid(GetData.AddressID.Value.ToString()));
                txtAddressLine1.Text = GetAddC.Add1;
                if (GetAddC.CityID != null)
                {
                    City GetCt = CityBLL.GetByPrimaryKey(new Guid(GetAddC.CityID.Value.ToString()));
                    if (GetCt != null)
                        txtCity.Text = GetCt.CityName;
                    else
                        txtCity.Text = "";
                }
                else
                    txtCity.Text = "";
                if (GetAddC.StateID != null)
                {
                    State GetSt = StateBLL.GetByPrimaryKey(new Guid(GetAddC.StateID.Value.ToString()));
                    if (GetSt != null)
                        txtState.Text = GetSt.StateName;
                    else
                        txtState.Text = "";
                }
                else
                    txtState.Text = "";
                if (GetAddC.CountryID != null)
                {
                    Country Cnt = CountryBLL.GetByPrimaryKey(new Guid(GetAddC.CountryID.Value.ToString()));
                    if (Cnt != null)
                        txtCountry.Text = Cnt.CountryName;
                    else
                        txtCountry.Text = "";
                }
                else
                    txtCountry.Text = "";
                txtPostCode.Text = GetAddC.ZipCode;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        /// <summary>
        /// Bind Grid Information 
        /// </summary>
        private void BindGrid()
        {
            grdChannelPartnerList.Visible = true;

            Guid? CompanyID = this.CompanyID;
            Guid? CreatedBy;
            string CompanyName = null;
            string UserType = Convert.ToString(Session["UserType"]);
            string FullName = null;
            if (!txtSTermName.Text.Trim().Equals(""))
                FullName = txtSTermName.Text.Trim();
            else
                FullName = null;
            if (!txtSLocation.Text.Trim().Equals(""))
                CompanyName = txtSLocation.Text.Trim();
            else
                CompanyName = null;

            DataSet Dst = ChannelPartnerBLL.SearchInfo(null, null, null, CompanyName, FullName, CompanyID, null, null);
            //string Query = "Select ChannelPartnerID,DisplayName, EMail, MobileNo,(select COUNT(*) from irm_Investor where RelationShipManagerID LIKE irm_ChannelPartner.ChannelPartnerID and IsActive = 1) As 'TotalInvestor',(select COUNT(*) from irm_Prospects where ContactedBy like irm_ChannelPartner.ChannelPartnerID and IsActive = 1) As 'TotalProspects' From irm_ChannelPartner Where IsActive = 1" + (FullName.Trim().Equals("") ? "" : " And DisplayName Like '" + FullName + "%'") + (this.CompanyID == null ? null : " And CompanyID like '" + this.CompanyID.ToString() + "'");
            DataView dv = new DataView(Dst.Tables[0]);
            dv.Sort = "DisplayName ASC";
            grdChannelPartnerList.DataSource = Dst.Tables[0];
            grdChannelPartnerList.DataBind();
        }
        /// <summary>
        /// Load Title Here
        /// </summary>
        /// <param name="ddl">ddl as DropDownList</param>
        private void LoadTitle(DropDownList ddl)
        {
            ddl.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "TITLE";
            TitleTerm.IsActive = true;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddl.DataSource = Lst;
                ddl.DataTextField = "DisplayTerm";
                ddl.DataValueField = "Term";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Update Channel Partner Info
        /// </summary>
        private void UpdateChannelPartner()
        {
            bool blIsSelfEmailChange = false;

            ChannelPartner Updt = ChannelPartnerBLL.GetByPrimaryKey(this.ChannelPartnerID);
            ChannelPartner OlUpdt = ChannelPartnerBLL.GetByPrimaryKey(this.ChannelPartnerID);
            Updt.Title = ddlTitle.SelectedValue.ToString();
            Updt.FName = txtFirstName.Text.Trim();
            Updt.LName = txtLastName.Text.Trim();
            Updt.Email = txtEmail.Text.Trim();

            if (txtMobileCntNo.Text.Trim().Equals(""))
                Updt.MobileNo = "-" + txtMobileNo.Text.Trim();
            else
                Updt.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();


            Updt.LandLineNo = txtLandLineNo.Text.Trim();
            Updt.DisplayName = txtDisplayName.Text.Trim();
            Updt.CompanyName = txtCompanyName.Text.Trim();
            Updt.CompanyID = this.CompanyID;
            Updt.CreatedOn = DateTime.Now.Date;
            Updt.IsActive = true;
            Updt.UpdatedOn = DateTime.Now.Date;
            Updt.DisplayNameOfFirm = Convert.ToString(txtDisplayNameoffirm.Text.Trim());

            if (Convert.ToString(hdnUploadPhoto.Value) != "")
            {
                Updt.Thumb = Convert.ToString(hdnUploadPhoto.Value);
            }

            //Current Adderss Investor

            Address UpdtCAddress = AddressBLL.GetByPrimaryKey(new Guid(Updt.AddressID.ToString()));
            UpdtCAddress.Add1 = txtAddressLine1.Text;
            UpdtCAddress.ZipCode = txtPostCode.Text;
            UpdtCAddress.IsActive = true;
            UpdtCAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
            UpdtCAddress.StateID = clsCommon.State(txtState.Text.Trim());
            UpdtCAddress.CityID = clsCommon.City(txtCity.Text.Trim());

            UpdtCAddress.CompanyID = this.CompanyID;

            string UPasswordKey, DisName, UPassword;
            Guid DefaUserID;
            if (!Updt.Email.Trim().Equals(""))
            {
                User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(OlUpdt.UserID)));
                if (UpdtUsr != null)
                {
                    DefaUserID = UpdtUsr.UsearID;
                    UpdtUsr.UserName = Updt.Email.Trim();
                    UPasswordKey = UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);

                    DisName = UpdtUsr.UserDisplayName;
                    UPassword = UpdtUsr.Password;
                    if (OlUpdt.Email != Updt.Email)
                    {
                        UpdtUsr.IsActive = false;

                        if (Convert.ToString(Session["UserID"]) == Convert.ToString(UpdtUsr.UsearID))
                            blIsSelfEmailChange = true;

                    }
                    else
                    {
                        UpdtUsr.IsActive = UpdtUsr.IsActive;
                    }
                    UserBLL.Update(UpdtUsr);
                }
                else
                {
                    User usr = new User();
                    DefaUserID = usr.UsearID = Guid.NewGuid();
                    usr.UserTypeID = usr.UsearID;
                    usr.UserType = "Channel Partner";
                    usr.CompanyID = this.CompanyID;
                    usr.UserName = Updt.Email;
                    DisName = usr.UserDisplayName = Updt.FName + " " + Updt.LName;
                    UPassword = usr.Password = Guid.NewGuid().ToString().Substring(0, 8);
                    UPasswordKey = usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    usr.IsActive = false;
                    usr.CraetedOn = System.DateTime.Now.Date;
                    usr.IsBlock = false;
                    usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    usr.IsSynch = false;
                    List<UserRole> LstRl = new List<UserRole>();

                    UserRole UsrRole = new UserRole();
                    UsrRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["ChannelPartnerRole"]);
                    UsrRole.AssignedBy = usr.CreatedBy;
                    UsrRole.AssignedOn = DateTime.Now;
                    UsrRole.IsSynch = false;
                    UsrRole.SynchOn = DateTime.Now;
                    LstRl.Add(UsrRole);
                    UserBLL.Save(usr, LstRl);
                    Updt.UserID = usr.UsearID;
                }
            }
            else
            {
                User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(OlUpdt.UserID)));
                if (UpdtUsr != null)
                {
                    UpdtUsr.UserName = Updt.Email.Trim();
                    UPasswordKey = UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    DefaUserID = UpdtUsr.UsearID;
                    DisName = UpdtUsr.UserDisplayName;
                    UPassword = UpdtUsr.Password;
                    if (UpdtUsr.IsActive == true && OlUpdt.Email != Updt.Email)
                    {
                        UpdtUsr.IsActive = false;
                        if (Convert.ToString(Session["UserID"]) == Convert.ToString(UpdtUsr.UsearID))
                            blIsSelfEmailChange = true;
                    }
                    else
                    {
                        UpdtUsr.IsActive = UpdtUsr.IsActive;
                    }

                    UserBLL.Update(UpdtUsr);
                }
                else
                {
                    User usr = new User();
                    DefaUserID = usr.UsearID = Guid.NewGuid();
                    usr.UserTypeID = usr.UsearID;
                    usr.UserType = "Channel Partner";
                    usr.CompanyID = this.CompanyID;
                    usr.UserName = Updt.Email;
                    DisName = usr.UserDisplayName = Updt.FName + " " + Updt.LName;
                    UPassword = usr.Password = Guid.NewGuid().ToString().Substring(0, 8);
                    UPasswordKey = usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    usr.IsActive = false;
                    usr.CraetedOn = System.DateTime.Now.Date;
                    usr.IsBlock = false;
                    usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    usr.IsSynch = false;
                    List<UserRole> LstRl = new List<UserRole>();

                    UserRole UsrRole = new UserRole();
                    UsrRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["ChannelPartnerRole"]);
                    UsrRole.AssignedBy = usr.CreatedBy;
                    UsrRole.AssignedOn = DateTime.Now;
                    UsrRole.IsSynch = false;
                    UsrRole.SynchOn = DateTime.Now;
                    LstRl.Add(UsrRole);
                    UserBLL.Save(usr, LstRl);
                    Updt.UserID = usr.UsearID;
                }
            }

            ChannelPartnerBLL.Update(Updt, UpdtCAddress);
            if (OlUpdt.Email != Updt.Email && !(Updt.Email.Equals("")))
            {
                ////SendEmail(DisName, txtEmail.Text.Trim(), UPassword, DefaUserID, UPasswordKey);
            }
            else if (OlUpdt.UserID != Updt.UserID && !(Updt.Email.Equals("")))
            {
                ////SendEmail(DisName, txtEmail.Text.Trim(), UPassword, DefaUserID, UPasswordKey);
            }
            this.ChannelPartnerID = Updt.ChannelPartnerID;
            ActionLogBLL.Save(null, "Update", Updt.ToString(), Updt.ToString(), "Insert" + Updt.FName + Updt.LName + " Record");
            if (blIsSelfEmailChange)
            {
                Session.Clear();
                Response.Redirect("~/InvChangeEmail.aspx");
            }
            IsInsert = true;
            lblProsMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
            hdnUploadPhoto.Value = "";
            ////BindGrid();
            LoadChannePartnerData(this.ChannelPartnerID);
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
                this.ChannelPartnerID = Guid.Empty;
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
                if (this.ChannelPartnerID != Guid.Empty)
                {
                    ChannelPartner DelePros = ChannelPartnerBLL.GetByPrimaryKey(this.ChannelPartnerID);

                    if (DelePros.UserID != null && Convert.ToString(DelePros.UserID) != "")
                    {
                        bool ISDeletePermission = false;

                        DataSet dsDeletePermission = ChannelPartnerBLL.SelectDeletePermission(DelePros.UserID);
                        if (dsDeletePermission.Tables.Count > 0 && dsDeletePermission.Tables[0].Rows.Count > 0)
                        {
                            ISDeletePermission = true;
                            IsInsert = true;
                            lblProsMsg.Text = "Can not be deleted ! Already Use.";
                            this.ChannelPartnerID = Guid.Empty;
                            msgbx.Hide();
                            ClearControlValue();
                            return;
                        }
                        if (ISDeletePermission == false)
                        {
                            if (dsDeletePermission.Tables.Count > 0 && dsDeletePermission.Tables[1].Rows.Count > 0)
                            {
                                ISDeletePermission = true;
                                IsInsert = true;
                                lblProsMsg.Text = "Can not be deleted ! Already Use.";
                                this.ChannelPartnerID = Guid.Empty;
                                msgbx.Hide();
                                ClearControlValue();
                                return;
                            }
                        }
                    }

                    ChannelPartnerBLL.Delete(this.ChannelPartnerID);
                    IsInsert = true;
                    lblProsMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", DelePros.ToString(), null, "irm_ChannelPartner");
                }
                this.ChannelPartnerID = Guid.Empty;
                this.UserID = Guid.Empty;
                msgbx.Hide();
                ClearControlValue();
                BindGrid();
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewUp_Click(object sender, EventArgs e)
        {
            ClearControlValue();
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        protected void btnSaveUp_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
        protected void btnCancelUp_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }
        /// <summary>
        /// Add New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControlValue();
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
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
                Session["ChannelPartnerID"] = null;
                Response.Redirect("~/Applications/Investors/ChannerlPartnerList.aspx");
                //ClearControlValue();
                //btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
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
                            if (this.ChannelPartnerID != Guid.Empty)
                            {
                                if (LstDupWing[0].UsearID != this.UserID)
                                {
                                    IsInsert = true;
                                    lblProsMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                    return;
                                }
                            }
                            else
                            {
                                IsInsert = true;
                                lblProsMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                    }

                    if (this.ChannelPartnerID != Guid.Empty)
                    {
                        //Update Channel Partners Information
                        ChannelPartner Updt = ChannelPartnerBLL.GetByPrimaryKey(this.ChannelPartnerID);

                        if (UplodFile.FileName != "")
                        {
                            hdnUploadPhoto.Value = Guid.NewGuid() + "_" + UplodFile.FileName.Replace(" ", "_");

                            string path = Server.MapPath("~/UploadPhoto/" + hdnUploadPhoto.Value);

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
                        }

                        if (!Updt.Email.Equals(txtEmail.Text.Trim()) && !(txtEmail.Text.Trim().Equals("")))
                        {
                            EmailNotification.Show();
                        }
                        else
                        {
                            UpdateChannelPartner();
                        }
                    }
                    else
                    {
                        string FullName = "";
                        //Insert Channel Partners Information
                        ChannelPartner Ins = new ChannelPartner();
                        SQT.Symphony.BusinessLogic.Configuration.DTO.User Usr = new User();
                        Usr.UsearID = Guid.NewGuid();

                        FullName = ddlTitle.SelectedValue.ToString() + " " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
                        Ins.Title = ddlTitle.SelectedValue.ToString();
                        Ins.FName = txtFirstName.Text.Trim();
                        Ins.LName = txtLastName.Text.Trim();
                        Ins.Email = txtEmail.Text.Trim();

                        if (txtMobileCntNo.Text.Trim().Equals(""))
                            Ins.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            Ins.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();

                        Ins.LandLineNo = txtLandLineNo.Text.Trim();
                        Ins.DisplayName = txtDisplayName.Text.Trim();
                        Ins.CompanyName = txtCompanyName.Text.Trim();
                        Ins.CompanyID = this.CompanyID;
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.IsActive = true;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.UserID = Usr.UsearID;
                        Ins.DisplayNameOfFirm = Convert.ToString(txtDisplayNameoffirm.Text.Trim());

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

                        //Current Adderss Investor

                        Address InvCAddress = new Address();
                        InvCAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
                        InvCAddress.StateID = clsCommon.State(txtState.Text.Trim());
                        InvCAddress.CityID = clsCommon.City(txtCity.Text.Trim());
                        InvCAddress.Add1 = txtAddressLine1.Text;
                        InvCAddress.ZipCode = txtPostCode.Text;
                        InvCAddress.IsActive = true;
                        InvCAddress.CompanyID = this.CompanyID;

                        Usr.UserName = Ins.Email;
                        Usr.Password = Guid.NewGuid().ToString().Substring(0, 8).ToString();
                        Usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        Usr.CraetedOn = DateTime.Now.Date;
                        Usr.IsActive = false;
                        Usr.CompanyID = this.CompanyID;
                        Usr.UserType = "Channel Partner";
                        Usr.IsBlock = false;
                        Usr.DisplayAvtar = Ins.Thumb;
                        Usr.UserDisplayName = Ins.FName + " " + Ins.LName;
                        Usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                        ChannelPartnerBLL.SaveWithUserID(Ins, InvCAddress, Usr);
                        this.ChannelPartnerID = Ins.ChannelPartnerID;
                        if (!Usr.UserName.Equals(""))
                        {
                            ////SendEmail(txtDisplayName.Text.Trim(), Usr.UserName, Usr.Password, Usr.UsearID, Usr.PasswordKey);
                        }
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "irm_ChannelPartner");
                        IsInsert = true;
                        lblProsMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        ////BindGrid();
                        LoadChannePartnerData(this.ChannelPartnerID);
                    }
                    //ClearControlValue();


                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Image Remove Link Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HypRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ChannelPartnerID != Guid.Empty)
                {
                    ChannelPartner GetImg = ChannelPartnerBLL.GetByPrimaryKey(this.ChannelPartnerID);
                    if (GetImg != null && GetImg.Thumb.ToString().ToUpper() != "BUSINESSCARD.PNG")
                    {
                        string DeletePath = Server.MapPath("~/UploadPhoto/") + Convert.ToString(GetImg.Thumb);
                        File.Delete(DeletePath);
                        GetImg.Thumb = "BusinessCard.png";
                        ChannelPartnerBLL.Update(GetImg);
                        IsInsert = true;

                        lblProsMsg.Text = global::Resources.IRMSMsg.RemovePhotoMsg.ToString().Trim();
                        imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    }
                    else
                        imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    HypRemove.Visible = false;
                }
                else
                {
                    MessageBox.Show("Select Channel Partner From The List");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
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

            if (this.ChannelPartnerID != Guid.Empty)
                LoadChannePartnerData(this.ChannelPartnerID);
        }
        /// <summary>
        /// Resend Activation Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkReSendEmail_Click(object sender, EventArgs e)
        {
            ////try
            ////{
            ////    if (this.UserID != Guid.Empty)
            ////    {
            ////        User objUser = new User();
            ////        objUser = UserBLL.GetByPrimaryKey(this.UserID);
            ////        if (objUser != null)
            ////        {
            ////            lnkReSendEmail.Visible = true;
            ////            IsEmail = true;
            ////            IsInsert = true;
            ////            lblProsMsg.Text = global::Resources.IRMSMsg.lblEmailSendMsg.ToString().Trim();
            ////            lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
            ////            SendEmail(objUser.UserDisplayName, objUser.UserName, objUser.Password, objUser.UsearID, objUser.PasswordKey);
            ////        }
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            ////    MessageBox.Show(ex.Message.ToString());
            ////}
        }
        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Data Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdChannelPartnerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    this.ChannelPartnerID = new Guid(Convert.ToString(e.CommandArgument.ToString()));
                    LoadAccess();
                    LoadChannePartnerData(this.ChannelPartnerID);
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.ChannelPartnerID = new Guid(Convert.ToString(e.CommandArgument.ToString()));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdChannelPartnerList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    ////string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                    ////if (litMobileNo != null)
                    ////{
                    ////    if (Convert.ToString(strMobileNo) != "")
                    ////        litMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                    ////    else
                    ////        litMobileNo.Text = "";
                    ////}

                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        EditImg.ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        EditImg.ToolTip = "View";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Email Change Notification
        /// <summary>
        /// Email Notification Save Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveEmailNotification_Click(object sender, EventArgs e)
        {
            UpdateChannelPartner();
            EmailNotification.Hide();
        }
        /// <summary>
        /// Email Notification Cancel Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnCancelEmailNotification_Click(object sender, EventArgs e)
        {
            txtEmail.Text = hfOldEmial.Value;
            EmailNotification.Hide();
        }
        #endregion Email Change Notification
    }
}