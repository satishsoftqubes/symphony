using System.Data;
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
using System.Globalization;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.IRMSCofiguration
{
    public partial class CtrlEmployee : System.Web.UI.UserControl
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

        public Guid EmployeeID
        {
            get
            {
                return ViewState["EmployeeID"] != null ? new Guid(Convert.ToString(ViewState["EmployeeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["EmployeeID"] = value;
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
        /// FOrm Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("EmployeeSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            JDate.Visible = false;

            if (!IsPostBack)
                LoadDefaultValue();

            //txtDateOfJoin.Attributes.Add("autocomplete", "off");

        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("EmployeeSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnNewUp.Visible = btnCancel.Visible = btnCancelUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = btnNewUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.EmployeeID == Guid.Empty)
                    btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
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
                if (Session["CompanyID"] != null)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    ClearControlValue();
                    LoadValidation();
                    BindGrid();
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Default.aspx");
                }
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
                //Both below commented by vijay as told by Piyushbhai b'cas no need to make required those fields.
                //rfvMobileNo.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipContactNo));
                //rvftxtEmail.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipEmail));

                if (!Convert.ToBoolean(objPropertyConfiguration.IsSkipAddress))
                {
                    tdAddress.Attributes.Add("class", "RequireFile");
                    tdCity.Attributes.Add("class", "RequireFile");
                    tdState.Attributes.Add("class", "RequireFile");
                    tdCountry.Attributes.Add("class", "RequireFile");
                }

                if (!Convert.ToBoolean(objPropertyConfiguration.IsSkipPostCode))
                    tdPostCode.Attributes.Add("class", "RequireFile");
                //if (!Convert.ToBoolean(objPropertyConfiguration.IsSkipContactNo))
                //    tdMobileNo.Attributes.Add("class", "RequireFile");
            }
        }

        /// <summary>
        /// Clear Control Value
        /// </summary>
        private void ClearControlValue()
        {
            LoadComboControl();
            LoadDLL();
            txtEmployeeNo.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = hfOldEmial.Value = "";
            txtBirthNationality.Text = "";
            txtAddressLine1.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            txtPostCode.Text = "";
            txtCAddress1.Text = "";
            txtCCity.Text = "";
            txtCState.Text = "";
            txtCCountry.Text = "";
            txtCPostCode.Text = "";
            chkAsAbove.Checked = false;
            chkIsSales.Checked = false;
            ValidDate.Visible = false;
            txtSEmployeeName.Text = "";
            this.EmployeeID = Guid.Empty;
            this.UserID = Guid.Empty;
            imgThumb.ImageUrl = "~/UploadPhoto/BusinessCard.png";
            //ddlDate.SelectedIndex = ddlMonth.SelectedIndex = ddlYear.SelectedIndex = 0;
            hypThumb.Visible = false;
            txtMobileNo.Text = txtMobileCntNo.Text = "";
            txtLandlineNo.Text = "";
            chkIsSales.Enabled = true;
            ddlRole.Enabled = true;
            ddlDepartment.Enabled = true;
            ddlDate.SelectedValue = ddlMonth.SelectedValue = ddlYear.SelectedValue = ddlJDate.SelectedValue = ddlJMonth.SelectedValue = ddlJYear.SelectedValue = Guid.Empty.ToString();
            hdnUploadPhoto.Value = "";
        }
        /// <summary>
        /// Load Date Information
        /// </summary>
        private void LoadDLL()
        {
            ddlDate.Items.Clear();
            ddlYear.Items.Clear();
            ddlJDate.Items.Clear();
            ddlJYear.Items.Clear();
            //Load Date Based On Month
            ddlDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int i = 1; i < 32; i++)
            {
                if (i < 10)
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }
            }


            ddlJDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int k = 1; k < 32; k++)
            {
                if (k < 10)
                {
                    ddlJDate.Items.Insert(k, new ListItem(k.ToString(), "0" + k.ToString()));
                }
                else
                {
                    ddlJDate.Items.Insert(k, new ListItem(k.ToString(), k.ToString()));
                }
            }


            //Load Year
            int j = 1;
            ddlYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = DateTime.Now.Year - 18; i >= 1940; i--)
            {
                ddlYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                j++;
            }


            //Load Year
            int l = 1;
            ddlJYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = DateTime.Now.Year; i >= 1970; i--)
            {
                ddlJYear.Items.Insert(l, new ListItem(i.ToString(), i.ToString()));
                l++;
            }
            //Bind Role

            ddlRole.Items.Clear();
            //string Query = "Select * From Usr_Role Where RoleID In ('" + System.Configuration.ConfigurationSettings.AppSettings["SalesRole"].ToString() + "','" + System.Configuration.ConfigurationSettings.AppSettings["AdminRole"].ToString() + "')";
            string Query = "Select * from usr_Role Where RoleType In ('Admin','Sales')";
            DataSet Dst = InvestorBLL.GetSearchData(Query);
            if (Dst.Tables[0].Rows.Count > 0)
            {
                DataView Dv = new DataView(Dst.Tables[0]);
                Dv.Sort = "RoleName ASC";
                ddlRole.DataSource = Dv;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleID";
                ddlRole.DataBind();
            }
        }
        /// <summary>
        /// Load Combo Control
        /// </summary>        
        private void LoadComboControl()
        {
            try
            {
                //LoadProperty(ddlPropertyName);
                LoadDepartment();
                ProjectTerm TitleTerm = new ProjectTerm();
                TitleTerm.CompanyID = this.CompanyID;
                TitleTerm.Category = "TITLE";
                TitleTerm.IsActive = true;
                LoadTermControl(TitleTerm, ddlTitle);

                ProjectTerm GenderTerm = new ProjectTerm();
                GenderTerm.CompanyID = this.CompanyID;
                GenderTerm.Category = "GENDER";
                GenderTerm.IsActive = true;
                LoadTermControl(GenderTerm, ddlGender);

                ProjectTerm MaritialStatusTerm = new ProjectTerm();
                MaritialStatusTerm.CompanyID = this.CompanyID;
                MaritialStatusTerm.Category = "MARITALSTATUS";
                MaritialStatusTerm.IsActive = true;
                LoadTermControl(MaritialStatusTerm, ddlMartialStatus);

                LoadStatus();

                //LoadProperty(ddlSProperty);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Term Control
        /// </summary>
        /// <param name="Term">Term as object of ProjectTerm</param>
        /// <param name="ddl">ddl as DropDownList</param>
        private void LoadTermControl(ProjectTerm Term, DropDownList ddl)
        {
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(Term);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm rm1, ProjectTerm rm2) => rm1.DisplayTerm.CompareTo(rm2.DisplayTerm));
                ddl.DataSource = Lst;
                ddl.DataTextField = "DisplayTerm";
                ddl.DataValueField = "Term";
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ddl.SelectedValue = Guid.Empty.ToString();
        }

        /// <summary>
        /// Load Employee Status
        /// </summary>       
        private void LoadStatus()
        {
            ProjectTerm EmpStatusTerm = new ProjectTerm();
            EmpStatusTerm.CompanyID = this.CompanyID;
            EmpStatusTerm.Category = "EMPLOYEESTATUS";
            EmpStatusTerm.IsActive = true;

            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(EmpStatusTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm rm1, ProjectTerm rm2) => rm1.DisplayTerm.CompareTo(rm2.DisplayTerm));
                ddlStatus.DataSource = Lst;
                ddlStatus.DataTextField = "DisplayTerm";
                ddlStatus.DataValueField = "TermID";
                ddlStatus.DataBind();
            }
            ddlStatus.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ddlStatus.SelectedValue = Guid.Empty.ToString();
        }
        /// <summary>
        /// Load Department
        /// </summary>        
        private void LoadDepartment()
        {
            Department objDept = new Department();
            objDept.IsActive = true;
            objDept.CompanyID = this.CompanyID;
            List<Department> lstDept = DepartmentBLL.GetAll(objDept);
            if (lstDept.Count > 0)
            {
                lstDept.Sort((Department d1, Department d2) => d1.DepartmentName.CompareTo(d2.DepartmentName));
                ddlDepartment.DataSource = lstDept;
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                ddlSearchDepartment.DataSource = lstDept;
                ddlSearchDepartment.DataTextField = "DepartmentName";
                ddlSearchDepartment.DataValueField = "DepartmentID";
                ddlSearchDepartment.DataBind();
                ddlSearchDepartment.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
            {
                ddlDepartment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSearchDepartment.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }


        }

        ///// <summary>
        ///// Load Property
        ///// </summary>
        ///// <param name="ddl">ddl as DropDownList</param>
        //private void LoadProperty(DropDownList ddl)
        //{
        //    Property objProperty = new Property();
        //    objProperty.CompanyID = this.CompanyID;
        //    objProperty.IsActive = true;
        //    List<Property> lstProperty = PropertyBLL.GetAll(objProperty);
        //    lstProperty.Sort((Property p1, Property p2) => p1.PropertyName.CompareTo(p2.PropertyName));
        //    if (lstProperty.Count > 0)
        //    {
        //        ddl.DataSource = lstProperty;
        //        ddl.DataTextField = "PropertyName";
        //        ddl.DataValueField = "PropertyID";
        //        ddl.DataBind();
        //    }
        //    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    ddl.SelectedValue = Guid.Empty.ToString();
        //}

        /// <summary>
        /// Load Emplooyee Data
        /// </summary>
        private void LoadEmpData()
        {
            try
            {
                Employee GetData = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);
                if (!Convert.ToString(GetData.UserID).Equals(""))
                    this.UserID = (Guid)GetData.UserID;
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

                LoadDepartment();
                if (GetData.DepartmentID != null)
                    ddlDepartment.SelectedValue = Convert.ToString(GetData.DepartmentID);
                ddlDepartment_SelectedIndexChanged(null, null);
                ddlDepartment.Enabled = false;
                txtEmployeeNo.Text = GetData.EmployeeNo;
                ddlTitle.SelectedValue = GetData.Surname;
                txtFirstName.Text = GetData.FirstName;
                txtLastName.Text = GetData.LastName;
                txtEmail.Text = hfOldEmial.Value = GetData.Email;

                ddlDate.SelectedValue = GetData.BirthDate == null ? Guid.Empty.ToString() : GetData.BirthDate.Value.Day.ToString().Length == 2 ? GetData.BirthDate.Value.Day.ToString() : "0" + GetData.BirthDate.Value.Day.ToString();
                ddlMonth.SelectedValue = GetData.BirthDate == null ? Guid.Empty.ToString() : GetData.BirthDate.Value.Month.ToString();
                ddlYear.SelectedValue = GetData.BirthDate == null ? Guid.Empty.ToString() : GetData.BirthDate.Value.Year.ToString();

                ddlJDate.SelectedValue = GetData.DOJ == null ? Guid.Empty.ToString() : GetData.DOJ.Value.Day.ToString().Length == 2 ? GetData.DOJ.Value.Day.ToString() : "0" + GetData.DOJ.Value.Day.ToString();
                ddlJMonth.SelectedValue = GetData.DOJ == null ? Guid.Empty.ToString() : GetData.DOJ.Value.Month.ToString();
                ddlJYear.SelectedValue = GetData.DOJ == null ? Guid.Empty.ToString() : GetData.DOJ.Value.Year.ToString();

                Session["IsSales"] = chkIsSales.Checked = Convert.ToBoolean(GetData.IsSales);
                ddlRole.Enabled = false;
                chkIsSales.Enabled = false;

                txtBirthNationality.Text = GetData.NationalityAtBirth;
                ddlGender.SelectedValue = GetData.Gender == null ? Guid.Empty.ToString() : GetData.Gender;
                ddlMartialStatus.SelectedValue = GetData.MaritalStatus == null ? Guid.Empty.ToString() : GetData.MaritalStatus;

                if (Convert.ToString(GetData.MobileNo) != "")
                {
                    string mobileno = Convert.ToString(GetData.MobileNo);


                    string[] words = mobileno.Split('-');
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

                txtLandlineNo.Text = Convert.ToString(GetData.LandlineNo);

                Address GetAddP = AddressBLL.GetByPrimaryKey(new Guid(GetData.PAddressID.Value.ToString()));
                txtAddressLine1.Text = GetAddP.Add1;
                if (GetAddP.CityID != null)
                {
                    City GetCt = CityBLL.GetByPrimaryKey(new Guid(GetAddP.CityID.Value.ToString()));
                    if (GetCt != null)
                        txtCity.Text = GetCt.CityName;
                    else
                        txtCity.Text = "";
                }
                if (GetAddP.StateID != null)
                {
                    State GetSt = StateBLL.GetByPrimaryKey(new Guid(GetAddP.StateID.Value.ToString()));
                    if (GetSt != null)
                        txtState.Text = GetSt.StateName;
                    else
                        txtState.Text = "";
                }
                if (GetAddP.CountryID != null)
                {
                    Country Cnt = CountryBLL.GetByPrimaryKey(new Guid(GetAddP.CountryID.Value.ToString()));
                    if (Cnt != null)
                        txtCountry.Text = Cnt.CountryName;
                    else
                        txtCountry.Text = "";
                }
                txtPostCode.Text = GetAddP.ZipCode;

                Address GetAddC = AddressBLL.GetByPrimaryKey(new Guid(GetData.CAddressID.Value.ToString()));
                txtCAddress1.Text = GetAddC.Add1;
                // txtCAddress2.Text = GetAddC.Add2;
                if (GetAddC.CityID != null)
                {
                    City GetCCt = CityBLL.GetByPrimaryKey(new Guid(GetAddC.CityID.Value.ToString()));
                    if (GetCCt != null)
                        txtCCity.Text = GetCCt.CityName;
                    else
                        txtCCity.Text = "";
                }
                if (GetAddC.StateID != null)
                {
                    State GetCSt = StateBLL.GetByPrimaryKey(new Guid(GetAddC.StateID.Value.ToString()));
                    if (GetCSt != null)
                        txtCState.Text = GetCSt.StateName;
                    else
                        txtCState.Text = "";
                }
                if (GetAddC.CountryID != null)
                {
                    Country CCnt = CountryBLL.GetByPrimaryKey(new Guid(GetAddC.CountryID.Value.ToString()));
                    if (CCnt != null)
                        txtCCountry.Text = CCnt.CountryName;
                    else
                        txtCCountry.Text = "";
                }
                txtCPostCode.Text = GetAddP.ZipCode;

                //txtMotherTongue.Text = GetData.MotherTongue;

                ddlStatus.SelectedValue = GetData.StatusID == null ? Guid.Empty.ToString() : Convert.ToString(GetData.StatusID.Value);
                if (GetData.Photo.ToUpper().ToString().Trim() != "BUSINESSCARD.PNG")
                {
                    imgThumb.ImageUrl = "~/UploadPhoto/" + GetData.Photo;
                    if (Convert.ToBoolean(ViewState["Edit"]))
                        hypThumb.Visible = true;
                    else
                        hypThumb.Visible = false;
                }
                else
                {
                    imgThumb.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    hypThumb.Visible = false;
                }

                string Query = "Select RoleID, RoleName From Usr_Role Where RoleID In (Select RoleID From usr_UserRole Where UserID In ('" + Convert.ToString(GetData.UserID) + "'))";
                DataSet dst = InvestorBLL.GetSearchData(Query);
                if (dst.Tables[0].Rows.Count > 0)
                {
                    ddlRole.SelectedIndex = ddlRole.Items.FindByValue(Convert.ToString(dst.Tables[0].Rows[0]["RoleID"])) != null ? ddlRole.Items.IndexOf(ddlRole.Items.FindByValue(Convert.ToString(dst.Tables[0].Rows[0]["RoleID"]))) : 0;
                }
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
            try
            {
                Guid? DepartmentID;
                string FullName, Location = null;
                if (ddlSearchDepartment.SelectedValue != Guid.Empty.ToString())
                    DepartmentID = new Guid(Convert.ToString(ddlSearchDepartment.SelectedValue));
                else
                    DepartmentID = null;
                if (txtSEmployeeName.Text.Trim() != "")
                    FullName = txtSEmployeeName.Text.Trim();
                else
                    FullName = null;


                DataSet dsEmp = EmployeeBLL.GetAllSearch(null, null, this.CompanyID, DepartmentID, null, FullName, null);
                grdEmployeeList.DataSource = dsEmp.Tables[0];
                grdEmployeeList.DataBind();



            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Private Method

        #region Popup Button
        /// <summary>
        /// Add New Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControlValue();
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
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
                if (this.EmployeeID != Guid.Empty)
                {
                    Employee GetData = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);

                    if (GetData.UserID != null && Convert.ToString(GetData.UserID) != "")
                    {

                        if (GetData.DepartmentID != null && Convert.ToString(GetData.DepartmentID) != "" && Convert.ToString(GetData.DepartmentID.ToString().ToUpper()) == "2DEF2942-58A8-408E-9A50-7D8BE1EBD298")
                        {
                            bool ISDeletePermission = false;

                            DataSet dsDeletePermission = ChannelPartnerBLL.SelectDeletePermission(GetData.UserID);
                            if (dsDeletePermission.Tables.Count > 0 && dsDeletePermission.Tables[0].Rows.Count > 0)
                            {
                                ISDeletePermission = true;
                                IsInsert = true;
                                lblEmployeeMsg.Text = "Can not be deleted ! Already Use.";
                                this.EmployeeID = Guid.Empty;
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
                                    lblEmployeeMsg.Text = "Can not be deleted ! Already Use.";
                                    this.EmployeeID = Guid.Empty;
                                    msgbx.Hide();
                                    ClearControlValue();
                                    return;
                                }
                            }
                        }
                    }

                    msgbx.Hide();                    
                    EmployeeBLL.Delete(this.EmployeeID);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetData.ToString(), null, "hrm_Employee");
                    IsInsert = true;
                    this.EmployeeID = Guid.Empty;
                    lblEmployeeMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ClearControlValue();
                    BindGrid();
                }
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
                if (this.EmployeeID != Guid.Empty)
                {
                    this.EmployeeID = Guid.Empty;
                    msgbx.Hide();
                    ClearControlValue();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Popup Button

        #region Button Event
        protected void btnSaveUp_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
        protected void btnNewUp_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlValue();
                btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //protected void btnCancelUp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControlValue();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControlValue();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }

        //}

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
                    /********* To remove Date of Birth and Date of Join as told by Kush sir on 27th Aug 2013
                    string DateOfBirth = Convert.ToString(ddlDate.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
                    try
                    {
                        if (Convert.ToDateTime(DateOfBirth) > DateTime.Now.Date)
                        {
                            ValidDate.Visible = true;
                            return;
                        }
                        else
                            ValidDate.Visible = false;
                    }
                    catch
                    {
                        ValidDate.Visible = true;
                        return;
                    }
                    string DateOfJoin = Convert.ToString(ddlJDate.SelectedValue.ToString().Trim() + "-" + ddlJMonth.SelectedItem.Text.Trim() + "-" + ddlJYear.SelectedValue.ToString().Trim());
                    try
                    {

                        if (Convert.ToDateTime(DateOfJoin) > DateTime.Now.Date)
                        {
                            JDate.Visible = true;
                            return;
                        }
                        else
                            JDate.Visible = false;
                    }
                    catch
                    {
                        JDate.Visible = true;
                        return;
                    }
                    */

                    if (!txtEmail.Text.Equals(""))
                    {
                        User IsDup = new User();
                        IsDup.UserName = txtEmail.Text.Trim();

                        List<User> LstDupUser = UserBLL.GetAll(IsDup);
                        if (LstDupUser.Count > 0)
                        {
                            if (this.EmployeeID != Guid.Empty)
                            {
                                if (Convert.ToString(LstDupUser[0].UsearID) != Convert.ToString(this.UserID))
                                {
                                    IsInsert = true;
                                    lblEmployeeMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                    return;
                                }
                            }
                            else
                            {
                                IsInsert = true;
                                lblEmployeeMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                    }
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (this.EmployeeID != Guid.Empty)
                    {
                        //Update Employee

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

                        Employee Emp = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);
                        if (!Emp.Email.Equals(txtEmail.Text.Trim()) && !(txtEmail.Text.Trim().Equals("")))
                        {
                            EmailNotification.Show();
                        }
                        else
                        {
                            //txtEmail.Text = Emp.Email;
                            UpdateEmployee();
                        }
                    }
                    else
                    {
                        //Insert Employee
                        Employee Emp = new Employee();
                        User objUser = new User();
                        objUser.UsearID = Guid.NewGuid();

                        //Emp.PropertyID = new Guid(Session["PropertyID"].ToString());
                        if (ddlDepartment.SelectedValue.Equals(Guid.Empty.ToString()))
                            Emp.DepartmentID = null;
                        else
                            Emp.DepartmentID = new Guid(ddlDepartment.SelectedValue.ToString());
                        Emp.Surname = ddlTitle.SelectedValue.Equals(Guid.Empty.ToString()) ? null : Convert.ToString(ddlTitle.SelectedValue);
                        Emp.EmployeeNo = Convert.ToString(txtEmployeeNo.Text.Trim());
                        Emp.FirstName = txtFirstName.Text.Trim();
                        Emp.LastName = txtLastName.Text.Trim();
                        Emp.FullName = Emp.Surname + " " + Emp.FirstName + " " + Emp.LastName;

                        //Add Birth Date Into The System
                        ////Emp.BirthDate = Convert.ToDateTime(DateOfBirth);
                        ////Emp.DOJ = Convert.ToDateTime(DateOfJoin);

                        //Emp.BirthPlace = txtBirthPlace.Text.Equals("") ? null : txtBirthPlace.Text;
                        Emp.NationalityAtBirth = txtBirthNationality.Text.Trim().Equals("") ? null : txtBirthNationality.Text.Trim();
                        //Emp.CurrentNationality = txtCurrentNationality.Text.Equals("") ? null : txtCurrentNationality.Text;
                        Emp.Gender = ddlGender.SelectedValue.Equals(Guid.Empty.ToString()) ? null : ddlGender.SelectedValue.ToString();
                        //Emp.Height = Convert.ToDecimal(txtHeight.Text);
                        //Emp.Weight = Convert.ToDecimal(txtWeight.Text);
                        Emp.MaritalStatus = ddlMartialStatus.SelectedValue.Equals(Guid.Empty.ToString()) ? null : Convert.ToString(ddlMartialStatus.SelectedValue);
                        Emp.Email = txtEmail.Text.Trim();
                        //Emp.MotherTongue = txtMotherTongue.Text.Equals("") ? null : txtMotherTongue.Text;
                        if (ddlStatus.SelectedValue.Equals(Guid.Empty.ToString()))
                            Emp.StatusID = null;
                        else
                            Emp.StatusID = new Guid(ddlStatus.SelectedValue);
                        Emp.CompanyID = this.CompanyID;
                        Emp.IsActive = true;
                        Emp.CreatedOn = System.DateTime.Now.Date;


                        if (txtMobileCntNo.Text.Trim().Equals(""))
                            Emp.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            Emp.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();

                        Emp.LandlineNo = txtLandlineNo.Text.Trim();
                        Emp.IsSynch = false;
                        Emp.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Emp.UserID = objUser.UsearID;
                        Emp.IsSales = chkIsSales.Checked;
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
                            Emp.Photo = cmpPhoto;
                        }
                        else
                            Emp.Photo = "BusinessCard.png";

                        //Permanent Adderss Employee

                        Address EmpPAddress = new Address();

                        #region City , State, Country Setting

                        EmpPAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
                        EmpPAddress.StateID = clsCommon.State(txtState.Text.Trim());
                        EmpPAddress.CityID = clsCommon.City(txtCity.Text.Trim());

                        #endregion City, State, Country Setting

                        EmpPAddress.Add1 = txtAddressLine1.Text.Trim();
                        //EmpPAddress.Add2 = txtAddressLine2.Text;
                        EmpPAddress.ZipCode = txtPostCode.Text.Trim();
                        EmpPAddress.IsActive = true;
                        EmpPAddress.CompanyID = this.CompanyID;
                        EmpPAddress.IsSynch = false;

                        //Current Address Employee
                        Address EmpCAddress = new Address();

                        #region City , State, Country Setting

                        EmpCAddress.CountryID = clsCommon.Country(txtCCountry.Text.Trim());
                        EmpCAddress.StateID = clsCommon.State(txtCState.Text.Trim());
                        EmpCAddress.CityID = clsCommon.City(txtCCity.Text.Trim());

                        #endregion City, State, Country Setting

                        EmpCAddress.Add1 = txtCAddress1.Text.Trim();
                        //EmpCAddress.Add2 = txtCAddress2.Text;
                        EmpCAddress.ZipCode = txtCPostCode.Text.Trim();
                        EmpCAddress.IsActive = true;
                        EmpCAddress.IsSynch = false;
                        EmpCAddress.CompanyID = this.CompanyID;

                        // User Employee                        
                        objUser.CompanyID = this.CompanyID;
                        objUser.UserName = Emp.Email;
                        objUser.UserDisplayName = Emp.FirstName + " " + Emp.LastName;
                        objUser.Password = Guid.NewGuid().ToString().Substring(0, 8);
                        objUser.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        objUser.IsActive = false;
                        objUser.CraetedOn = System.DateTime.Now.Date;
                        objUser.IsBlock = false;
                        objUser.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objUser.IsSynch = false;


                        SalesTeam sl = new SalesTeam();
                        if (chkIsSales.Checked)
                        {
                            sl.Title = ddlTitle.SelectedValue.Equals(Guid.Empty.ToString()) ? null : Convert.ToString(ddlTitle.SelectedValue);
                            sl.FName = txtFirstName.Text.Trim();
                            sl.LName = txtLastName.Text.Trim();
                            sl.DisplayName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
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
                                sl.Thumb = cmpPhoto;
                            }
                            else
                                sl.Thumb = "BusinessCard.png";

                            sl.Email = txtEmail.Text.Trim();
                            sl.MobileNo = txtMobileNo.Text.Trim();
                            sl.LandLineNo = txtLandlineNo.Text.Trim();
                            sl.IsActive = true;
                            sl.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                            sl.CreatedOn = DateTime.Now.Date;
                            sl.CompanyID = Emp.CompanyID;
                            sl.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                            sl.UpdatedOn = DateTime.Now.Date;
                        }
                        else
                            sl = null;
                        EmployeeBLL.SaveWithUserID(Emp, EmpPAddress, EmpCAddress, objUser, sl, new Guid(Convert.ToString(ddlRole.SelectedValue)), Convert.ToBoolean(chkIsSales.Checked));
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Emp.ToString(), Emp.ToString(), "hrm_Employee");
                        ////if (!objUser.UserName.Equals(""))
                        ////    SalesSendEmail(Emp.FullName, objUser.UserName, objUser.Password, objUser.UsearID, objUser.PasswordKey);
                        IsInsert = true;
                        lblEmployeeMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        ClearControlValue();
                        BindGrid();
                    }

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void UpdateEmployee()
        {
            bool blIsSelfEmailChange = false;

            ////string DateOfBirth = Convert.ToString(ddlDate.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
            ////string DateOfJoin = Convert.ToString(ddlJDate.SelectedValue.ToString().Trim() + "-" + ddlJMonth.SelectedItem.Text.Trim() + "-" + ddlJYear.SelectedValue.ToString().Trim());

            Employee Emp = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);
            Employee EmpOldData = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);
            if (ddlDepartment.SelectedValue.Equals(Guid.Empty.ToString()))
                Emp.DepartmentID = null;
            else
                Emp.DepartmentID = new Guid(ddlDepartment.SelectedValue.ToString());
            Emp.Surname = ddlTitle.SelectedValue.Equals(Guid.Empty.ToString()) ? null : Convert.ToString(ddlTitle.SelectedValue);
            Emp.EmployeeNo = Convert.ToString(txtEmployeeNo.Text.Trim());
            Emp.FirstName = txtFirstName.Text.Trim();
            Emp.LastName = txtLastName.Text.Trim();
            Emp.FullName = Emp.Surname + " " + Emp.FirstName + " " + Emp.LastName;

            //Change Date In Control
            ////Emp.BirthDate = Convert.ToDateTime(DateOfBirth);

            Emp.NationalityAtBirth = txtBirthNationality.Text.Trim().Equals("") ? null : txtBirthNationality.Text.Trim();
            Emp.Gender = ddlGender.SelectedValue.Equals(Guid.Empty.ToString()) ? null : ddlGender.SelectedValue.ToString();
            Emp.MaritalStatus = ddlMartialStatus.SelectedValue.Equals(Guid.Empty.ToString()) ? null : Convert.ToString(ddlMartialStatus.SelectedValue);
            Emp.Email = txtEmail.Text.Trim();

            ////Emp.DOJ = Convert.ToDateTime(DateOfJoin);
            if (ddlStatus.SelectedValue.Equals(Guid.Empty.ToString()))
                Emp.StatusID = null;
            else
                Emp.StatusID = new Guid(ddlStatus.SelectedValue);

            if (txtMobileCntNo.Text.Trim().Equals(""))
                Emp.MobileNo = "-" + txtMobileNo.Text.Trim();
            else
                Emp.MobileNo = txtMobileCntNo.Text.Trim() + "-" + txtMobileNo.Text.Trim();

            Emp.LandlineNo = txtLandlineNo.Text.Trim();
            Emp.IsSales = chkIsSales.Checked;

            if (Convert.ToString(hdnUploadPhoto.Value) != "")
            {
                Emp.Photo = Convert.ToString(hdnUploadPhoto.Value);
            }

            //Permanent Adderss Employee

            Address EmpPAddress = new Address();
            EmpPAddress = AddressBLL.GetByPrimaryKey(new Guid(Emp.PAddressID.ToString()));
            if (EmpPAddress == null)
                EmpPAddress = new Address();

            #region City , State, Country Setting

            EmpPAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
            EmpPAddress.StateID = clsCommon.State(txtState.Text.Trim());
            EmpPAddress.CityID = clsCommon.City(txtCity.Text.Trim());

            #endregion City, State, Country Setting

            EmpPAddress.Add1 = txtAddressLine1.Text.Trim();
            // EmpPAddress.Add2 = txtAddressLine2.Text;
            EmpPAddress.ZipCode = txtPostCode.Text.Trim();
            EmpPAddress.IsActive = true;
            EmpPAddress.CompanyID = this.CompanyID;

            //Current Address Employee
            Address EmpCAddress = new Address();
            EmpCAddress = AddressBLL.GetByPrimaryKey(new Guid(Emp.CAddressID.ToString()));
            if (EmpCAddress == null)
                EmpCAddress = new Address();

            #region City , State, Country Setting

            EmpCAddress.CountryID = clsCommon.Country(txtCCountry.Text.Trim());
            EmpCAddress.StateID = clsCommon.State(txtCState.Text.Trim());
            EmpCAddress.CityID = clsCommon.City(txtCCity.Text.Trim());

            #endregion City, State, Country Setting

            EmpCAddress.Add1 = txtCAddress1.Text.Trim();
            // EmpCAddress.Add2 = txtCAddress2.Text;
            EmpCAddress.ZipCode = txtCPostCode.Text.Trim();
            EmpCAddress.IsActive = true;
            EmpCAddress.CompanyID = this.CompanyID;

            if (!Emp.Email.Trim().Equals(""))
            {
                User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(EmpOldData.UserID)));
                if (UpdtUsr != null)
                {
                    UpdtUsr.UserName = Emp.Email.Trim();
                    UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);


                    List<UserRole> LstRl = UserRoleBLL.GetAllBy(UserRole.UserRoleFields.UserID, Convert.ToString(EmpOldData.UserID));
                    List<UserRole> LstUpdtRl = new List<UserRole>();
                    if (LstRl.Count > 0)
                    {
                        UserRole RlUpdt = (UserRole)LstRl[0];
                        RlUpdt.RoleID = new Guid(ddlRole.SelectedValue.ToString());
                        LstUpdtRl.Add(RlUpdt);
                    }

                    if (EmpOldData.Email != Emp.Email)
                    {
                        UpdtUsr.IsActive = false;
                        ////SalesSendEmail(UpdtUsr.UserDisplayName, UpdtUsr.UserName, UpdtUsr.Password, UpdtUsr.UsearID, UpdtUsr.PasswordKey);

                        if (Convert.ToString(Session["UserID"]) == Convert.ToString(UpdtUsr.UsearID))
                            blIsSelfEmailChange = true;
                    }
                    else
                        UpdtUsr.IsActive = UpdtUsr.IsActive;
                    UserBLL.Update(UpdtUsr, LstUpdtRl);
                }
                else
                {
                    User usr = new User();
                    usr.UsearID = Guid.NewGuid();
                    usr.UserTypeID = usr.UsearID;
                    usr.UserType = "Employee";
                    usr.CompanyID = this.CompanyID;
                    usr.UserName = Emp.Email;
                    usr.UserDisplayName = Emp.FirstName + " " + Emp.LastName;
                    usr.Password = Guid.NewGuid().ToString().Substring(0, 8);
                    usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    usr.IsActive = false;
                    usr.CraetedOn = System.DateTime.Now.Date;
                    usr.IsBlock = false;
                    usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    usr.IsSynch = false;

                    List<UserRole> LstRl = new List<UserRole>();

                    UserRole UsrRole = new UserRole();
                    UsrRole.RoleID = new Guid(Convert.ToString(ddlRole.SelectedValue.ToString()));
                    UsrRole.AssignedBy = usr.CreatedBy;
                    UsrRole.AssignedOn = DateTime.Now;
                    UsrRole.IsSynch = false;
                    UsrRole.SynchOn = DateTime.Now;
                    LstRl.Add(UsrRole);
                    UserBLL.Save(usr, LstRl);
                    Emp.UserID = usr.UsearID;
                    ////SalesSendEmail(usr.UserDisplayName, usr.UserName, usr.Password, usr.UsearID, usr.PasswordKey);
                }

            }
            else
            {
                User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(EmpOldData.UserID)));
                if (UpdtUsr != null)
                {
                    UpdtUsr.UserName = Emp.Email.Trim();
                    UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    List<UserRole> LstRl = UserRoleBLL.GetAllBy(UserRole.UserRoleFields.UserID, Convert.ToString(EmpOldData.UserID));
                    List<UserRole> LstUpdtRl = new List<UserRole>();
                    if (LstRl.Count > 0)
                    {
                        UserRole RlUpdt = (UserRole)LstRl[0];
                        RlUpdt.RoleID = new Guid(ddlRole.SelectedValue.ToString());
                        LstUpdtRl.Add(RlUpdt);
                    }

                    if (UpdtUsr.IsActive == true && EmpOldData.Email != Emp.Email)
                    {
                        UpdtUsr.IsActive = false;
                        if (Convert.ToString(Session["UserID"]) == Convert.ToString(UpdtUsr.UsearID))
                            blIsSelfEmailChange = true;
                    }
                    else
                        UpdtUsr.IsActive = UpdtUsr.IsActive;
                    UserBLL.Update(UpdtUsr, LstUpdtRl);
                }
                else
                {
                    User usr = new User();
                    usr.UsearID = Guid.NewGuid();
                    usr.UserTypeID = usr.UsearID;
                    usr.UserType = "Employee";
                    usr.CompanyID = this.CompanyID;
                    usr.UserName = Emp.Email;
                    usr.UserDisplayName = Emp.FirstName + " " + Emp.LastName;
                    usr.Password = Guid.NewGuid().ToString().Substring(0, 8);
                    usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    usr.IsActive = false;
                    usr.CraetedOn = System.DateTime.Now.Date;
                    usr.IsBlock = false;
                    usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    usr.IsSynch = false;

                    List<UserRole> LstRl = new List<UserRole>();

                    UserRole UsrRole = new UserRole();
                    UsrRole.RoleID = new Guid(Convert.ToString(ddlRole.SelectedValue.ToString()));
                    UsrRole.AssignedBy = usr.CreatedBy;
                    UsrRole.AssignedOn = DateTime.Now;
                    UsrRole.IsSynch = false;
                    UsrRole.SynchOn = DateTime.Now;
                    LstRl.Add(UsrRole);
                    UserBLL.Save(usr, LstRl);
                    Emp.UserID = usr.UsearID;
                }
            }

            SalesTeam SlTeam = new SalesTeam();
            if (chkIsSales.Checked && Convert.ToBoolean(Session["IsSales"]) == false)
            {

                SlTeam.Title = ddlTitle.SelectedValue.Equals(Guid.Empty.ToString()) ? null : Convert.ToString(ddlTitle.SelectedValue);
                SlTeam.FName = txtFirstName.Text.Trim();
                SlTeam.LName = txtLastName.Text.Trim();
                SlTeam.DisplayName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();

                if (Convert.ToString(hdnUploadPhoto.Value) != "")
                {
                    SlTeam.Thumb = Convert.ToString(hdnUploadPhoto.Value);
                }

                SlTeam.Email = txtEmail.Text.Trim();
                SlTeam.MobileNo = txtMobileNo.Text.Trim();
                SlTeam.LandLineNo = txtLandlineNo.Text.Trim();
                SlTeam.IsActive = true;
                SlTeam.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                SlTeam.CreatedOn = DateTime.Now.Date;
                SlTeam.CompanyID = Emp.CompanyID;
                SlTeam.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                SlTeam.UpdatedOn = DateTime.Now.Date;
                SlTeam.UserID = Emp.UserID;
            }
            else
                SlTeam = null;

            EmployeeBLL.Update(Emp, EmpPAddress, EmpCAddress, SlTeam);
            ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", EmpOldData.ToString(), Emp.ToString(), "hrm_Employee");
            IsInsert = true;

            if (blIsSelfEmailChange)
            {
                Session.Clear();
                Response.Redirect("~/InvChangeEmail.aspx");
            }

            lblEmployeeMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
            this.EmployeeID = Guid.Empty;
            this.UserID = Guid.Empty;
            ClearControlValue();
            BindGrid();
        }
        /// <summary>
        /// Remove Image Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hypThumb_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.EmployeeID != Guid.Empty)
                {
                    Employee GetImg = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);
                    if (GetImg != null && GetImg.Photo.ToString().ToUpper() != "BUSINESSCARD.PNG")
                    {
                        string DeletePath = Server.MapPath("~/UploadPhoto/") + Convert.ToString(GetImg.Photo);
                        File.Delete(DeletePath);
                        GetImg.Photo = "BusinessCard.png";
                        EmployeeBLL.Update(GetImg);
                        IsInsert = true;
                        lblEmployeeMsg.Text = global::Resources.IRMSMsg.RemovePhotoMsg.ToString().Trim();

                        imgThumb.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    }
                    else
                        imgThumb.ImageUrl = "~/UploadPhoto/BusinessCard.png";

                    hypThumb.Visible = false;
                }
                else
                    MessageBox.Show("Select Employee Information From The List");
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
            //ClearControlValue();
        }
        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Data Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    this.EmployeeID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadEmpData();
                    LoadAccess();
                    //lnkReSendEmail.Visible = Convert.ToBoolean(ViewState["Edit"]);
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.EmployeeID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        public void SalesSendEmail(string FullName, string UserName, string Password, Guid UserID, string PasswordKey)
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

        protected void chkIsSales_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSales.Checked)
                ddlRole.SelectedValue = System.Configuration.ConfigurationSettings.AppSettings["SalesRole"].ToString();
            else
                ddlRole.SelectedIndex = 0;
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EmployeeID == Guid.Empty)
            {
                if (ddlDepartment.SelectedItem.Text.Equals("Sales"))
                {
                    chkIsSales.Checked = true;
                    chkIsSales.Enabled = false;
                }
                else
                {
                    chkIsSales.Checked = false;
                    chkIsSales.Enabled = true;
                }
                chkIsSales_CheckedChanged(null, null);
                txtEmployeeNo.Focus();
            }
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
            ////            if (!objUser.UserName.Equals(""))
            ////            {

            ////                SalesSendEmail(objUser.UserDisplayName, objUser.UserName, objUser.Password, objUser.UsearID, objUser.PasswordKey);
            ////                IsEmail = true;
            ////                IsInsert = true;
            ////                lnkReSendEmail.Visible = true;
            ////                lblEmployeeMsg.Text = global::Resources.IRMSMsg.lblEmailSendMsg.ToString().Trim();
            ////                lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
            ////            }
            ////            else
            ////                IsEmail = true;
            ////        }
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            ////    MessageBox.Show(ex.Message.ToString());
            ////}
        }


        #region Email Change Notification
        /// <summary>
        /// Email Notification Save Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveEmailNotification_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
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