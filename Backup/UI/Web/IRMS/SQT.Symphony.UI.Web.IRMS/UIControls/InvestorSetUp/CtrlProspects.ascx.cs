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

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlProspects : System.Web.UI.UserControl
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
        public Guid ProspectID
        {
            get
            {
                return ViewState["ProspectID"] != null ? new Guid(Convert.ToString(ViewState["ProspectID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ProspectID"] = value;
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
                LoadValidationControl();
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
                ViewState["Edit"] = btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Add"] = btnNew.Visible = btnNewUp.Visible = btnCancel.Visible = btnCancelUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                //if (this.ProspectID == Guid.Empty)
                //    btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);                    
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
                //Add By Piyush Once Change From the client Date on 11-April-2012
                ddlManagerType.Enabled = ddlRelationManagementID.Enabled = txtNameOfFirm.Enabled = txtManagerContactNo.Enabled = txtManagerEmail.Enabled = Convert.ToBoolean(DV[0]["IsCreate"]);

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
                //ClearControlValue();
                LoadValidation();
                BindDDL();
                
                //as per discussion with vijay.
                ////BindGrid();
                grdProspectesList.Visible = false;

                imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                HypRemove.Visible = false;
                btnConvertToInvestor.Visible = btnConvertToInvestorUp.Visible = false;
                //chkIsEmail.Checked = true;
                //chkIsSMS.Checked = true;
                LoadRelationShipInformation();

                if (Session["ProsPectID"] != null)
                {
                    LoadProspectedData(new Guid(Session["ProspectID"].ToString()));
                    this.ProspectID = new Guid(Session["ProspectID"].ToString());
                    Session["ProsPectID"] = null;
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

        private void LoadValidation()
        {
            if (Session["PropertyConfigurationInfo"] != null)
            {
                PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                rvftxtPostCode.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipPostCode));
                rvfAddressLine1.Enabled = rvfCity.Enabled = rvfState.Enabled = rvfCountry.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipAddress));

                if (!Convert.ToBoolean(objPropertyConfiguration.IsSkipAddress))
                {
                    tdAddress1.Attributes.Add("class", "RequireFile");
                    tdCity.Attributes.Add("class", "RequireFile");
                    tdState.Attributes.Add("class", "RequireFile");
                    tdCountry.Attributes.Add("class", "RequireFile");
                }

                if (!Convert.ToBoolean(objPropertyConfiguration.IsSkipPostCode))
                    tdPostCode.Attributes.Add("class", "RequireFile");
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
                //rvftxtEmail.Enabled = !(Convert.ToBoolean(objPropertyConfigurationData.IsSkipEmail));
                //rvftxtMobileNo.Enabled = !(Convert.ToBoolean(objPropertyConfigurationData.IsSkipContactNo));
            }
        }

        private void LoadRelationShipInformation()
        {
            if (Session["UserType"].ToString().ToUpper().Equals("SALES"))
            {
                ddlManagerType.SelectedIndex = ddlRelationManagementID.SelectedIndex = 0;
                ddlManagerType.Enabled = ddlRelationManagementID.Enabled = txtNameOfFirm.Enabled = txtManagerContactNo.Enabled = txtManagerEmail.Enabled = false;

                if (Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                    ddlManagerType.SelectedValue = Convert.ToString("Channel Partner");
                else
                    ddlManagerType.SelectedValue = Convert.ToString(Session["UserType"]);
                ddlManagerType_SelectedIndexChanged(null, null);
                ddlRelationManagementID.SelectedIndex = ddlRelationManagementID.Items.FindByValue(Convert.ToString(Session["UserID"])) != null ? ddlRelationManagementID.Items.IndexOf(ddlRelationManagementID.Items.FindByValue(Convert.ToString(Session["UserID"]))) : 0;
                ddlRelationManagementID_SelectedIndexChanged(null, null);

            }
            else
            {
                ddlManagerType.Enabled = ddlRelationManagementID.Enabled = txtNameOfFirm.Enabled = txtManagerContactNo.Enabled = txtManagerEmail.Enabled = true;
                txtNameOfFirm.Text = txtManagerEmail.Text = txtManagerContactNo.Text = "";
            }
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void ClearControlValue()
        {
            LoadValidationControl();
            BindDDL();
            this.ProspectID = Guid.Empty;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtRefrence.Text = "";
            txtEmail.Text = "";
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
            
            //as per discussion with vijay.
            ////BindGrid();
            grdProspectesList.Visible = false;

            btnConvertToInvestor.Visible = btnConvertToInvestorUp.Visible = false;
            //chkIsEmail.Checked = true;
            //chkIsSMS.Checked = true;
            LoadRelationShipInformation();

        }

        private void BindDDL()
        {
            LoadTitle(ddlTitle);
            ddlTitle.SelectedValue = Guid.Empty.ToString();
            LoadOccupation(ddlOccupationTerm);
            ddlOccupationTerm.SelectedValue = Guid.Empty.ToString();
            LoadProsStatus(ddlStatus, true);
            ddlStatus.SelectedValue = Guid.Empty.ToString();
            LoadProsStatus(ddlSStatus, false);
            OtherDLL();
            LoadRelationshipThrow();
            LoadRelationManagerName();
            LoadReferenceTerm();
        }
        /// <summary>
        /// Load Refernce Term 
        /// </summary>
        private void LoadReferenceTerm()
        {
            ddlReferenceThrow.Items.Clear();
            ProjectTerm RefThrow = new ProjectTerm();
            RefThrow.Category = "REF-PROSPECT";
            RefThrow.IsActive = true;
            List<ProjectTerm> LstRefThrow = ProjectTermBLL.GetAll(RefThrow);
            if (LstRefThrow.Count > 0)
            {
                LstRefThrow.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlReferenceThrow.DataSource = LstRefThrow;
                ddlReferenceThrow.DataTextField = "DisplayTerm";
                ddlReferenceThrow.DataValueField = "TermID";
                ddlReferenceThrow.DataBind();
                ddlReferenceThrow.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlReferenceThrow.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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
        private void OtherDLL()
        {
            //Bind Reference
            txtSReference.Items.Clear();
            DataSet Dst = InvestorBLL.GetSearchData("Select Distinct(Reference) from irm_Prospects");
            if (Dst.Tables[0].Rows.Count > 0)
            {
                DataView Dv = new DataView(Dst.Tables[0]);
                txtSReference.DataSource = Dv;
                txtSReference.DataTextField = "Reference";
                txtSReference.DataValueField = "Reference";
                txtSReference.DataBind();
                txtSReference.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtSReference.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            //Bind Locaton

            txtSLocation.Items.Clear();
            DataSet CityDst = InvestorBLL.GetSearchData("Select CityName From mst_City");
            if (CityDst.Tables[0].Rows.Count > 0)
            {
                DataView Dv = new DataView(CityDst.Tables[0]);
                Dv.Sort = "CityName ASC";
                txtSLocation.DataSource = Dv;
                txtSLocation.DataTextField = "CityName";
                txtSLocation.DataValueField = "CityName";
                txtSLocation.DataBind();
                txtSLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtSLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

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



            ddlEnteryRegion.Items.Clear();
            ProjectTerm RegionEnetry = new ProjectTerm();
            List<ProjectTerm> LstRegionEnetry = new List<ProjectTerm>();
            RegionEnetry.IsActive = true;
            RegionEnetry.Category = "Region";
            RegionEnetry.CompanyID = this.CompanyID;
            LstRegionEnetry = ProjectTermBLL.GetAll(RegionEnetry);
            if (LstRegionEnetry.Count != 0)
            {
                LstRegionEnetry.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlEnteryRegion.DataSource = LstRegionEnetry;
                ddlEnteryRegion.DataTextField = "DisplayTerm";
                ddlEnteryRegion.DataValueField = "TermID";
                ddlEnteryRegion.DataBind();
                ddlEnteryRegion.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlEnteryRegion.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


        }
        /// <summary>
        /// Load ReltionShip Throw Sales/Channelpartner
        /// </summary>
        private void LoadRelationshipThrow()
        {
            ddlManagerType.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "MANAGERTYPE";
            TitleTerm.IsActive = true;
            TitleTerm.CompanyID = this.CompanyID;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlManagerType.DataSource = Lst;
                ddlManagerType.DataTextField = "DisplayTerm";
                ddlManagerType.DataValueField = "Term";
                ddlManagerType.DataBind();
                ddlManagerType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlManagerType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void LoadRelationManagerName()
        {
            ddlRelationManagementID.Items.Clear();
            if (ddlManagerType.SelectedValue != Guid.Empty.ToString())
            {
                if (ddlManagerType.Text.Equals("Channel Partner"))
                {
                    trFirmName.Visible = true;
                    DataView dv = new DataView(PaymentSlabeBLL.GetPaymentSlab("select UserID,DisplayName from irm_ChannelPartner Where IsActive = 1").Tables[0]);
                    if (dv.Count > 0)
                    {
                        dv.Sort = "DisplayName Asc";
                        ddlRelationManagementID.DataSource = dv;
                        ddlRelationManagementID.DataTextField = "DisplayName";
                        ddlRelationManagementID.DataValueField = "UserID";
                        ddlRelationManagementID.DataBind();
                        ddlRelationManagementID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlRelationManagementID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else if (ddlManagerType.Text.Equals("Sales"))
                {
                    trFirmName.Visible = false;
                    DataView dv = new DataView(PaymentSlabeBLL.GetPaymentSlab("select UserID,DisplayName from irm_SalesTeam Where IsActive = 1").Tables[0]);
                    if (dv.Count > 0)
                    {
                        dv.Sort = "DisplayName Asc";
                        ddlRelationManagementID.DataSource = dv;
                        ddlRelationManagementID.DataTextField = "DisplayName";
                        ddlRelationManagementID.DataValueField = "UserID";
                        ddlRelationManagementID.DataBind();
                        ddlRelationManagementID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlRelationManagementID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
            }
            else
            {
                ddlRelationManagementID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
            }
        }
        /// <summary>
        /// Load RelationShip Data Here
        /// </summary>
        private void LoadRelationShipManagerInformation()
        {
            if (ddlRelationManagementID.SelectedValue != Guid.Empty.ToString())
            {
                if (ddlManagerType.Text.Equals("Channel Partner"))
                {
                    List<ChannelPartner> lstcp = ChannelPartnerBLL.GetAllBy(ChannelPartner.ChannelPartnerFields.UserID, Convert.ToString(ddlRelationManagementID.SelectedValue));
                    if (lstcp.Count > 0)
                    {
                        ChannelPartner cp = lstcp[0];
                        txtNameOfFirm.Text = cp.CompanyName;

                        if (Convert.ToString(cp.MobileNo) != "" && cp.MobileNo != null)
                        {
                            string[] words = cp.MobileNo.Split('-');
                            if (words.Length > 1)
                            {
                                if (Convert.ToString(words[0]) != "")
                                    txtManagerContactNo.Text = Convert.ToString(cp.MobileNo);
                                else
                                    txtManagerContactNo.Text = Convert.ToString(words[1]).Replace("-", "");
                            }
                            else
                                txtManagerContactNo.Text = Convert.ToString(cp.MobileNo.ToString().Replace("-", ""));
                        }
                        else
                            txtManagerContactNo.Text = "";

                        //txtManagerContactNo.Text = cp.MobileNo;
                        txtManagerEmail.Text = cp.Email;
                    }
                    else
                        txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
                }
                else if (ddlManagerType.Text.Equals("Sales"))
                {
                    List<SalesTeam> lstst = SalesTeamBLL.GetAllBy(SalesTeam.SalesTeamFields.UserID, Convert.ToString(ddlRelationManagementID.SelectedValue));
                    if (lstst.Count > 0)
                    {
                        SalesTeam st = lstst[0];
                        txtNameOfFirm.Text = "";
                        if (Convert.ToString(st.MobileNo) != "" && st.MobileNo != null)
                        {
                            string[] words = st.MobileNo.Split('-');
                            if (words.Length > 1)
                            {
                                if (Convert.ToString(words[0]) != "")
                                    txtManagerContactNo.Text = Convert.ToString(st.MobileNo);
                                else
                                    txtManagerContactNo.Text = Convert.ToString(words[1]).Replace("-", "");
                            }
                            else
                                txtManagerContactNo.Text = Convert.ToString(st.MobileNo.ToString().Replace("-", ""));
                        }
                        else
                            txtManagerContactNo.Text = "";
                        //txtManagerContactNo.Text = st.MobileNo;
                        txtManagerEmail.Text = st.Email;
                    }
                    else
                        txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
                }
                else
                    txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
            }
            else
            {
                txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
            }
        }
        /// <summary>
        /// Load Status Here
        /// </summary>
        /// <param name="ddl">ddl as DropDownList</param>
        private void LoadProsStatus(DropDownList ddl, bool IsEntry)
        {
            ddl.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "PROSPECTSTATUS";
            TitleTerm.IsActive = true;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddl.DataSource = Lst;
                ddl.DataTextField = "DisplayTerm";
                ddl.DataValueField = "TermID";
                ddl.DataBind();
                if (IsEntry)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
            {
                if (IsEntry)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
        }
        /// <summary>
        /// Load Title Here
        /// </summary>
        /// <param name="ddl">ddl as DropDownList</param>
        private void LoadOccupation(DropDownList ddl)
        {
            ddl.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "OCCUPATION";
            TitleTerm.IsActive = true;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddl.DataSource = Lst;
                ddl.DataTextField = "DisplayTerm";
                ddl.DataValueField = "TermID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Grid Information 
        /// </summary>
        private void BindGrid()
        {
            grdProspectesList.Visible = true;

            Guid? CompanyID = this.CompanyID;
            Guid? ContactedBy;
            string Location = null;
            string Reference = null;
            Guid? RegionID = null;
            Guid? StatusID = null;

            string ProspectName = null;
            if (!txtSTermName.Text.Trim().Equals(""))
                ProspectName = txtSTermName.Text.Trim();
            else
                ProspectName = null;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN")
                ContactedBy = null;
            else
                ContactedBy = new Guid(Convert.ToString(Session["UserTypeID"]));

            if (!txtSLocation.SelectedValue.Equals(Guid.Empty.ToString()))
                Location = txtSLocation.Text.Trim();
            else
                Location = null;
            if (!txtSReference.SelectedValue.Equals(Guid.Empty.ToString()))
                Reference = txtSReference.Text.Trim();
            else
                Reference = null;

            if (!ddlSStatus.SelectedValue.Equals(Guid.Empty.ToString()))
                StatusID = new Guid(ddlSStatus.SelectedValue.ToString());
            else
                StatusID = null;
            if (!ddlRegion.SelectedValue.Equals(Guid.Empty.ToString()))
                RegionID = new Guid(ddlRegion.SelectedValue.ToString());
            else
                RegionID = null;

            DataSet dsProspects = ProspectsBLL.SearchInfo(null, null, null, null, ProspectName, StatusID, CompanyID, null, ContactedBy, Location, Reference, RegionID, null);
            DataView Dv = new DataView(dsProspects.Tables[0]);
            grdProspectesList.DataSource = Dv;
            grdProspectesList.DataBind();

            if (Session["UserType"].ToString().ToUpper().Equals("SALES"))
            {
                ddlManagerType.Enabled = ddlRelationManagementID.Enabled = txtNameOfFirm.Enabled = txtManagerContactNo.Enabled = txtManagerEmail.Enabled = false;
            }
            else
            {
                ddlManagerType.Enabled = ddlRelationManagementID.Enabled = txtNameOfFirm.Enabled = txtManagerContactNo.Enabled = txtManagerEmail.Enabled = true;
            }

        }
        /// <summary>
        /// Load Prospected Data Information
        /// </summary>
        /// <param name="ProspectedID"></param>
        private void LoadProspectedData(Guid ProspectedID)
        {
            try
            {
                Prospects GetData = ProspectsBLL.GetByPrimaryKey(ProspectedID);
                DataView DV1 = RoleRightJoinBLL.GetIUDVAccess("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
                LoadAccess();
                if (Convert.ToString(GetData.InvestorID) != "")
                    btnConvertToInvestor.Visible = btnConvertToInvestorUp.Visible = false;
                else
                    btnConvertToInvestor.Visible = btnConvertToInvestorUp.Visible = Convert.ToBoolean(DV1[0]["IsUpdate"]);

                //if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                //{
                //    btnConvertToInvestor.Visible = false;
                //}

                this.ProspectID = GetData.ProspectID;
                ddlTitle.SelectedValue = GetData.Title;
                txtFirstName.Text = GetData.FName;
                txtLastName.Text = GetData.LName;
                txtEmail.Text = GetData.EMail;

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


                txtLandLineNo.Text = GetData.LandlineNo;
                txtRefrence.Text = GetData.Reference;
                //chkIsSMS.Checked = Convert.ToBoolean(GetData.IsSMS);
                //chkIsEmail.Checked = Convert.ToBoolean(GetData.IsEmail);
                //LoadOccupation(ddlOccupationTerm);
                if (Convert.ToString(GetData.OccupationTermID) != "")
                    ddlOccupationTerm.SelectedValue = Convert.ToString(GetData.OccupationTermID);
                else
                    ddlOccupationTerm.SelectedValue = Convert.ToString(Guid.Empty);
                if (Convert.ToString(GetData.StatusID) != "")
                    ddlStatus.SelectedValue = Convert.ToString(GetData.StatusID);
                else
                    ddlStatus.SelectedValue = Convert.ToString(Guid.Empty);
                txtCompanyName.Text = GetData.CompanyName;
                if (GetData.Thumb.ToUpper().ToString().Trim() != "BUSINESSCARD.PNG")
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/" + GetData.Thumb;
                    if (Convert.ToBoolean(ViewState["Edit"]))
                        HypRemove.Visible = true;
                    else
                        HypRemove.Visible = false;
                }
                else
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    HypRemove.Visible = false;
                }

                if (GetData.ManagerType != null)
                {
                    ddlManagerType.SelectedIndex = ddlManagerType.Items.FindByValue(Convert.ToString(GetData.ManagerType)) != null ? ddlManagerType.Items.IndexOf(ddlManagerType.Items.FindByValue(Convert.ToString(GetData.ManagerType))) : 0;
                    ddlManagerType_SelectedIndexChanged(null, null);
                }
                if (GetData.RelationShipManagerID != null)
                {
                    ddlRelationManagementID.SelectedIndex = ddlRelationManagementID.Items.FindByValue(Convert.ToString(GetData.RelationShipManagerID)) != null ? ddlRelationManagementID.Items.IndexOf(ddlRelationManagementID.Items.FindByValue(Convert.ToString(GetData.RelationShipManagerID))) : 0;
                    ddlRelationManagementID_SelectedIndexChanged(null, null);
                }
                if (GetData.RegionTermID != null)
                    ddlEnteryRegion.SelectedIndex = ddlEnteryRegion.Items.FindByValue(Convert.ToString(GetData.RegionTermID)) != null ? ddlEnteryRegion.Items.IndexOf(ddlEnteryRegion.Items.FindByValue(Convert.ToString(GetData.RegionTermID))) : 0;
                else
                    ddlEnteryRegion.SelectedIndex = 0;

                if (GetData.ReferenceTermID != null)
                    ddlReferenceThrow.SelectedIndex = ddlReferenceThrow.Items.FindByValue(Convert.ToString(GetData.ReferenceTermID)) != null ? ddlReferenceThrow.Items.IndexOf(ddlReferenceThrow.Items.FindByValue(Convert.ToString(GetData.ReferenceTermID))) : 0;
                else
                    ddlReferenceThrow.SelectedIndex = 0;
                Address GetAddC = AddressBLL.GetByPrimaryKey(new Guid(GetData.AddressID.Value.ToString()));
                if (GetAddC != null)
                {
                    txtAddressLine1.Text = Convert.ToString(GetAddC.Add1);
                    if (GetAddC.CityID != null)
                    {
                        City GetCt = CityBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddC.CityID)));
                        if (GetCt != null)
                            txtCity.Text = GetCt.CityName;
                        else
                            txtCity.Text = "";
                    }
                    else
                        txtCity.Text = "";
                    if (GetAddC.StateID != null)
                    {
                        State GetSt = StateBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddC.StateID)));
                        if (GetSt != null)
                            txtState.Text = GetSt.StateName;
                        else
                            txtState.Text = "";
                    }
                    else
                        txtState.Text = "";
                    if (GetAddC.CountryID != null)
                    {
                        Country Cnt = CountryBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddC.CountryID)));
                        if (Cnt != null)
                            txtCountry.Text = Cnt.CountryName;
                        else
                            txtCountry.Text = "";
                    }
                    else
                        txtCountry.Text = "";
                    txtPostCode.Text = Convert.ToString(GetAddC.ZipCode);
                }
                else
                {
                    txtAddressLine1.Text = txtCity.Text = txtState.Text = txtCountry.Text = txtPostCode.Text = "";
                }

                if (Session["UserType"].ToString().ToUpper().Equals("SALES"))
                {                    
                    ddlManagerType.Enabled = ddlRelationManagementID.Enabled = txtNameOfFirm.Enabled = txtManagerContactNo.Enabled = txtManagerEmail.Enabled = false;
                }
                else
                {
                    ddlManagerType.Enabled = ddlRelationManagementID.Enabled = txtNameOfFirm.Enabled = txtManagerContactNo.Enabled = txtManagerEmail.Enabled = true;                    
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

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
                this.ProspectID = Guid.Empty;
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
                if (this.ProspectID != Guid.Empty)
                {
                    Prospects DelePros = ProspectsBLL.GetByPrimaryKey(this.ProspectID);
                    ProspectsBLL.Delete(this.ProspectID);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", DelePros.ToString(), null, "irm_Prospects");
                    IsInsert = true;
                    lblProsMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                }
                this.ProspectID = Guid.Empty;
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
        protected void btnNewUp_Click(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        protected void btnCancelUp_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }
        protected void btnSaveUp_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
        /// <summary>
        /// Add New Prospect
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
                Session["ProsPectID"] = null;
                Response.Redirect("~/Applications/Investors/ProspectsList.aspx");
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
        /// Convert Prospects To Investor Ivent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConvertToInvestor_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Add("ProspectID", this.ProspectID);
                Response.Redirect("~/Applications/Investors/InvestorSetUp.aspx");
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
                    if (txtEmail.Text.Equals("") && txtMobileNo.Text.Equals("") && txtLandLineNo.Text.Equals(""))
                    {
                        return;
                    }
                    Prospects IsProspectsDup = new Prospects();
                    IsProspectsDup.Title = ddlTitle.SelectedValue.ToString();
                    IsProspectsDup.FName = txtFirstName.Text.Trim();
                    IsProspectsDup.LName = txtLastName.Text.Trim();
                    ////IsProspectsDup.Reference = txtRefrence.Text.Trim();
                    ////IsProspectsDup.StatusID = new Guid(ddlStatus.SelectedValue.ToString());
                    IsProspectsDup.IsActive = true;
                    List<Prospects> LstDupProspects = ProspectsBLL.GetAll(IsProspectsDup);
                    if (LstDupProspects.Count > 0)
                    {
                        if (this.ProspectID != null)
                        {
                            if (Convert.ToString((LstDupProspects[0].ProspectID)) != Convert.ToString(this.ProspectID))
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

                    if (this.ProspectID != Guid.Empty)
                    {
                        //Update Prospect Information
                        Prospects Updt = ProspectsBLL.GetByPrimaryKey(this.ProspectID);
                        Updt.Title = ddlTitle.SelectedValue.ToString();
                        Updt.FName = txtFirstName.Text;
                        Updt.LName = txtLastName.Text;
                        Updt.EMail = txtEmail.Text;

                        if (txtMobileCntNo.Text.Trim().Equals(""))
                            Updt.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            Updt.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();

                        Updt.LandlineNo = txtLandLineNo.Text;
                        Updt.Reference = txtRefrence.Text;
                        Updt.ReferenceTermID = new Guid(Convert.ToString(ddlReferenceThrow.SelectedValue));
                        Updt.StatusID = new Guid(ddlStatus.SelectedValue.ToString());
                        Updt.CompanyName = txtCompanyName.Text;
                        if (ddlOccupationTerm.SelectedValue != Guid.Empty.ToString())
                            Updt.OccupationTermID = new Guid(ddlOccupationTerm.SelectedValue);
                        else
                            Updt.OccupationTermID = null;
                        Updt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Updt.UpdatedOn = DateTime.Now.Date;
                        Updt.IsEmail = true;
                        Updt.IsSMS = true;
                        Updt.ManagerType = ddlManagerType.SelectedValue.ToString();
                        Updt.RelationShipManagerID = new Guid(Convert.ToString(ddlRelationManagementID.SelectedValue));
                        Updt.NameOfFirm = txtFirstName.Text;
                        Updt.ManagerContactNo = txtManagerContactNo.Text.Trim();
                        Updt.ManagerEmail = txtManagerEmail.Text.Trim();
                        if (ddlEnteryRegion.SelectedValue != Guid.Empty.ToString())
                            Updt.RegionTermID = new Guid(ddlEnteryRegion.SelectedValue.ToString());
                        else
                            Updt.RegionTermID = null;
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

                        //Current Adderss Investor

                        Address UpdtCAddress = AddressBLL.GetByPrimaryKey(new Guid(Updt.AddressID.ToString()));
                        UpdtCAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
                        UpdtCAddress.StateID = clsCommon.State(txtState.Text.Trim());
                        UpdtCAddress.CityID = clsCommon.City(txtCity.Text.Trim());
                        UpdtCAddress.Add1 = txtAddressLine1.Text;
                        UpdtCAddress.ZipCode = txtPostCode.Text;

                        ProspectsBLL.Update(Updt, UpdtCAddress);
                        this.ProspectID = Updt.ProspectID;
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", Updt.ToString(), Updt.ToString(), "irm_Prospects");
                        IsInsert = true;
                        lblProsMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        string FullName;
                        //Insert Prospect Information
                        Prospects Ins = new Prospects();
                        Ins.Title = ddlTitle.SelectedValue.ToString();
                        Ins.FName = txtFirstName.Text;
                        Ins.LName = txtLastName.Text;
                        FullName = ddlTitle.SelectedValue.ToString() + " " + txtFirstName.Text.Trim() + " " + txtLastName.Text;
                        Ins.EMail = txtEmail.Text;

                        if (txtMobileCntNo.Text.Trim().Equals(""))
                            Ins.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            Ins.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();


                        Ins.LandlineNo = txtLandLineNo.Text;
                        Ins.Reference = txtRefrence.Text;
                        Ins.ReferenceTermID = new Guid(Convert.ToString(ddlReferenceThrow.SelectedValue));
                        Ins.StatusID = new Guid(ddlStatus.SelectedValue.ToString());
                        Ins.CompanyName = txtCompanyName.Text;
                        if (ddlOccupationTerm.SelectedValue != Guid.Empty.ToString())
                            Ins.OccupationTermID = new Guid(ddlOccupationTerm.SelectedValue);
                        else
                            Ins.OccupationTermID = null;
                        Ins.CompanyID = this.CompanyID;
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.IsActive = true;
                        Ins.IsSynch = false;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.ContactedPersonType = Convert.ToString(Session["UserType"]);
                        Ins.ContactedBy = new Guid(Convert.ToString(Session["UserTypeID"]));
                        Ins.IsEmail = true;
                        Ins.IsSMS = true;
                        Ins.ManagerType = ddlManagerType.SelectedValue.ToString();
                        Ins.RelationShipManagerID = new Guid(Convert.ToString(ddlRelationManagementID.SelectedValue));
                        Ins.NameOfFirm = txtFirstName.Text;
                        Ins.ManagerContactNo = txtManagerContactNo.Text.Trim();
                        Ins.ManagerEmail = txtManagerEmail.Text.Trim();
                        if (ddlEnteryRegion.SelectedValue != Guid.Empty.ToString())
                            Ins.RegionTermID = new Guid(ddlEnteryRegion.SelectedValue.ToString());
                        else
                            Ins.RegionTermID = null;
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

                        ProspectsBLL.Save(Ins, InvCAddress);
                        this.ProspectID = Ins.ProspectID;
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "irm_Prospects");
                        IsInsert = true;
                        lblProsMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    //ClearControlValue();
                    
                    ////BindGrid();

                    LoadProspectedData(this.ProspectID);
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
                if (this.ProspectID != Guid.Empty)
                {
                    Prospects GetImg = ProspectsBLL.GetByPrimaryKey(this.ProspectID);
                    if (GetImg != null && GetImg.Thumb.ToString().ToUpper() != "BUSINESSCARD.PNG")
                    {
                        string DeletePath = Server.MapPath("~/UploadPhoto/") + Convert.ToString(GetImg.Thumb);
                        File.Delete(DeletePath);
                        GetImg.Thumb = "BusinessCard.png";
                        ProspectsBLL.Update(GetImg);
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

        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Data Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdProspectesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    this.ProspectID = new Guid(e.CommandArgument.ToString());

                    LoadProspectedData(this.ProspectID);
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.ProspectID = new Guid(e.CommandArgument.ToString());
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdProspectesList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
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

        #region MangerType DropDown List
        /// <summary>
        /// Manager Type Select Based On Manager Information Has To Come
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void ddlManagerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRelationManagerName();
            if (this.ProspectID == Guid.Empty)
                btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        #endregion ManagerType Dropdown List

        #region View RelationShip Data
        /// <summary>
        /// View RelationShip Manager Data Here
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void ddlRelationManagementID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRelationShipManagerInformation();
            if (this.ProspectID == Guid.Empty)
                btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);

        }

        #endregion View RelationShip Data
    }
}