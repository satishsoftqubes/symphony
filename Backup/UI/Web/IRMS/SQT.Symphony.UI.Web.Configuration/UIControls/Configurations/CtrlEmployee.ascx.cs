using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;
using System.Globalization;
using System.IO;
using System.Configuration;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlEmployee : System.Web.UI.UserControl
    {
        #region Variable
        public bool IsListMessage = false;
        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
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

        public string strClearDateTooltip
        {
            get
            {
                return ViewState["strClearDateTooltip"] != null ? Convert.ToString(ViewState["strClearDateTooltip"]) : string.Empty;
            }
            set
            {
                ViewState["strClearDateTooltip"] = value;
            }
        }

        public string strChooseDateTooltip
        {
            get
            {
                return ViewState["strChooseDateTooltip"] != null ? Convert.ToString(ViewState["strChooseDateTooltip"]) : string.Empty;
            }
            set
            {
                ViewState["strChooseDateTooltip"] = value;
            }
        }

        #endregion Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            divJoiningDate.Visible = ValidDate.Visible = false;

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                BindData();
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "EMPLOYEE")
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.EmployeeID = clsSession.ToEditItemID;
                    BindEmployeeData();
                }

                BindBreadCrumb();
            }
        }
        #endregion Page Load

        #region Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "EMPLOYEESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindData()
        {
            try
            {
                SetPageLabels();
                //txtDateOfBirth.Attributes.Add("autocomplete", "off");
                //txtDateOfJoin.Attributes.Add("autocomplete", "off");
                //calDOB.Format = calDOJ.Format =clsSession.DateFormat;                 
                //calDOJ.Format = clsSession.DateFormat;
                LoadValidation();
                BindDDL();
                LoadDate();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSettiongs", "User Setup");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblEmployeeList", "Employee List");
            dr3["Link"] = "~/GUI/Configurations/EmployeeList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            string strNameTitle = ddlTitle.SelectedIndex != 0 ? ddlTitle.SelectedItem.Text.ToString() : string.Empty;
            dr4["NameColumn"] = "Employee"; //strNameTitle + txtFirstName.Text.Trim() + txtLastName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblEmployee", "Employee") : strNameTitle + "&nbsp;" + txtFirstName.Text.Trim() + "&nbsp;" + txtLastName.Text.Trim();
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Employee", "lblMainHeader", "EMPLOYEE");
            litDepartmentName.Text = clsCommon.GetGlobalResourceText("Employee", "lblDepartmentName", "Department Name");
            litDateOfBirth.Text = clsCommon.GetGlobalResourceText("Employee", "lblDateOfBirth", "Date Of Birth");
            litEmployeeNo.Text = clsCommon.GetGlobalResourceText("Employee", "lblEmployeeNo", "Employee No");
            litGender.Text = clsCommon.GetGlobalResourceText("Employee", "lblGender", "Gender");
            litLandlineNo.Text = clsCommon.GetGlobalResourceText("Employee", "lblLandlineNo", "LandlineNo");
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Employee", "lblMainHeader", "EMPLOYEE");
            litMaritalStatus.Text = clsCommon.GetGlobalResourceText("Employee", "lblMaritalStatus", "Marital Status");
            litMobileNo.Text = clsCommon.GetGlobalResourceText("Employee", "lblMobileNo", "Mobile No.");
            litName.Text = clsCommon.GetGlobalResourceText("Employee", "lblName", "Name");
            litNationality.Text = clsCommon.GetGlobalResourceText("Employee", "lblNationality", "Nationality");
            litOtherInformation.Text = clsCommon.GetGlobalResourceText("Employee", "lblOtherInformation", "Other Information");
            litEmail.Text = clsCommon.GetGlobalResourceText("Employee", "lblEmail", "Email");
            litDateOfJoin.Text = clsCommon.GetGlobalResourceText("Employee", "lblDateOfJoin", "Date Of Join");
            litStatus.Text = clsCommon.GetGlobalResourceText("Employee", "lblStatus", "Status");
            litHeaderAddressInfo.Text = clsCommon.GetGlobalResourceText("Employee", "lblHeaderAddressInfo", "Address Info");
            litHeaderVisitingCard.Text = clsCommon.GetGlobalResourceText("Employee", "lblHeaderVisitingCard", "Visiting Card");
            litSelectLogo.Text = clsCommon.GetGlobalResourceText("Employee", "lblSelectLogo", "Upload Visiting Card");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            lnkRemoveLogo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnRemove", "Remove");
            this.strClearDateTooltip = clsCommon.GetGlobalResourceText("Common", "lblTltpClearDate", "Clear Date");

            //imgDOJDate.ToolTip = this.strChooseDateTooltip = clsCommon.GetGlobalResourceText("Common", "lblTltpChooseDate", "Choose Date");

            ltrHeaderEmailNotificationPopup.Text = clsCommon.GetGlobalResourceText("Employee", "ltrHeaderEmailNotificationPopupMessage", "Email Notification");
            lblEmailNotification.Text = clsCommon.GetGlobalResourceText("Employee", "lblEmailNotificationMessage", "You have changed your Mail Id .A new Id and Password will be generated for your  login  and will be sent on new  Mail Id");

            ucPermanentAddress.strLtrAddress = clsCommon.GetGlobalResourceText("Employee", "lblPermanentAddress", "Permanent Address");
            ucCurrentAddress.strLtrAddress = clsCommon.GetGlobalResourceText("Employee", "lblCurrentAddress", "Current Address");

            ddlMonth.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblSelectDDLMonth", "-Month-"), "00000000-0000-0000-0000-000000000000"));
            ddlMonth.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthJan", "Jan"), "1"));
            ddlMonth.Items.Insert(2, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthFeb", "Feb"), "2"));
            ddlMonth.Items.Insert(3, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthMar", "Mar"), "3"));
            ddlMonth.Items.Insert(4, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthApr", "Apr"), "4"));
            ddlMonth.Items.Insert(5, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthMay", "May"), "5"));
            ddlMonth.Items.Insert(6, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthJun", "Jun"), "6"));
            ddlMonth.Items.Insert(7, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthJul", "Jul"), "7"));
            ddlMonth.Items.Insert(8, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthAug", "Aug"), "8"));
            ddlMonth.Items.Insert(9, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthSep", "Sep"), "9"));
            ddlMonth.Items.Insert(10, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthOct", "Oct"), "10"));
            ddlMonth.Items.Insert(11, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthNov", "Nov"), "11"));
            ddlMonth.Items.Insert(12, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthDec", "Dec"), "12"));

            ddlJoiningMonth.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblSelectDDLMonth", "-Month-"), "00000000-0000-0000-0000-000000000000"));
            ddlJoiningMonth.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthJan", "Jan"), "1"));
            ddlJoiningMonth.Items.Insert(2, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthFeb", "Feb"), "2"));
            ddlJoiningMonth.Items.Insert(3, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthMar", "Mar"), "3"));
            ddlJoiningMonth.Items.Insert(4, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthApr", "Apr"), "4"));
            ddlJoiningMonth.Items.Insert(5, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthMay", "May"), "5"));
            ddlJoiningMonth.Items.Insert(6, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthJun", "Jun"), "6"));
            ddlJoiningMonth.Items.Insert(7, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthJul", "Jul"), "7"));
            ddlJoiningMonth.Items.Insert(8, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthAug", "Aug"), "8"));
            ddlJoiningMonth.Items.Insert(9, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthSep", "Sep"), "9"));
            ddlJoiningMonth.Items.Insert(10, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthOct", "Oct"), "10"));
            ddlJoiningMonth.Items.Insert(11, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthNov", "Nov"), "11"));
            ddlJoiningMonth.Items.Insert(12, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblMonthDec", "Dec"), "12"));


            ValidDate.InnerHtml = divJoiningDate.InnerHtml = clsCommon.GetGlobalResourceText("Employee", "lblDateOfBirthErrorMessage", "Enter Valid Date");
            chkAsPermanenetAddress.Text = clsCommon.GetGlobalResourceText("Employee", "lblAsPermanenetAddress", "As Permanenet Address");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
        }

        /// <summary>
        /// Load All DDL
        /// </summary>
        private void BindDDL()
        {
            try
            {
                string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

                List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "TITLE");
                if (lstProjectTermTitle.Count != 0)
                {
                    ddlTitle.DataSource = lstProjectTermTitle;
                    ddlTitle.DataTextField = "DisplayTerm";
                    ddlTitle.DataValueField = "Term";
                    ddlTitle.DataBind();
                    ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlTitle.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                Department objDepartment = new Department();
                objDepartment.IsActive = true;
                objDepartment.CompanyID = clsSession.CompanyID;
                objDepartment.PropertyID = clsSession.PropertyID;

                List<Department> lstDepartment = DepartmentBLL.GetAll(objDepartment);
                if (lstDepartment.Count > 0)
                {
                    lstDepartment.Sort((Department d1, Department d2) => d1.DepartmentName.CompareTo(d2.DepartmentName));
                    ddlDepartmentName.DataSource = lstDepartment;
                    ddlDepartmentName.DataTextField = "DepartmentName";
                    ddlDepartmentName.DataValueField = "DepartmentID";
                    ddlDepartmentName.DataBind();
                    ddlDepartmentName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlDepartmentName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                List<ProjectTerm> lstProjectTermMS = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "MARITALSTATUS");
                if (lstProjectTermMS.Count != 0)
                {
                    ddlMaritalStatus.DataSource = lstProjectTermMS;
                    ddlMaritalStatus.DataTextField = "DisplayTerm";
                    ddlMaritalStatus.DataValueField = "TermID";
                    ddlMaritalStatus.DataBind();
                    ddlMaritalStatus.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlMaritalStatus.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                List<ProjectTerm> lstProjectTermGender = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GENDER");
                if (lstProjectTermGender.Count != 0)
                {
                    ddlGender.DataSource = lstProjectTermGender;
                    ddlGender.DataTextField = "DisplayTerm";
                    ddlGender.DataValueField = "DisplayTerm";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlGender.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                List<ProjectTerm> lstProjectTermStatus = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "EMPLOYEESTATUS");
                if (lstProjectTermStatus.Count != 0)
                {
                    ddlStatus.DataSource = lstProjectTermStatus;
                    ddlStatus.DataTextField = "DisplayTerm";
                    ddlStatus.DataValueField = "TermID";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlStatus.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            ddlTitle.SelectedIndex = ddlDepartmentName.SelectedIndex = ddlGender.SelectedIndex = ddlStatus.SelectedIndex = ddlMaritalStatus.SelectedIndex = 0;
            txtNationality.Text = txtEmployeeNo.Text = txtLandlineNo.Text = txtEmployeeNo.Text = txtFirstName.Text = txtEmail.Text = hfOldEmial.Value = "";
            txtLandlineNo.Text = txtMobileNo.Text = txtMobileNo.Text = txtLandlineNo.Text = txtLastName.Text = "";
            ucPermanentAddress.strAddress = ucPermanentAddress.strZipCode = ucPermanentAddress.strCountry = ucPermanentAddress.strState = ucPermanentAddress.strCity = "";
            ucCurrentAddress.strAddress = ucCurrentAddress.strZipCode = ucCurrentAddress.strCountry = ucCurrentAddress.strState = ucCurrentAddress.strCity = "";
            this.UserID = this.EmployeeID = Guid.Empty;
            imgEmployee.ImageUrl = "~/images/BusinessCard.png";
            //txtDateOfBirth.Attributes.Add("autocomplete", "off");
            //txtDateOfJoin.Attributes.Add("autocomplete", "off");
            lnkRemoveLogo.Visible = false;
            ddlDate.SelectedIndex = ddlMonth.SelectedIndex = ddlYear.SelectedIndex = ddlJoiningDate.SelectedIndex = ddlJoiningMonth.SelectedIndex = ddlJoiningYear.SelectedIndex = 0;

            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
        }


        /// <summary>
        /// Load Date Information
        /// </summary>
        private void LoadDate()
        {
            ddlDate.Items.Clear();
            ddlYear.Items.Clear();
            ddlJoiningDate.Items.Clear();
            ddlJoiningYear.Items.Clear();
            //Load Date Based On Month

            string strDDLSelectDate = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectDate", "-Date-");
            string strDDLSelectYear = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectYear", "-Year-");

            ddlDate.Items.Insert(0, new ListItem(strDDLSelectDate, Guid.Empty.ToString()));
            ddlJoiningDate.Items.Insert(0, new ListItem(strDDLSelectDate, Guid.Empty.ToString()));

            for (int i = 1; i < 32; i++)
            {
                if (i < 10)
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                    ddlJoiningDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                    ddlJoiningDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }
            }


            //ddlJDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            //for (int k = 1; k < 32; k++)
            //{
            //    if (k < 10)
            //    {
            //        ddlJDate.Items.Insert(k, new ListItem(k.ToString(), "0" + k.ToString()));
            //    }
            //    else
            //    {
            //        ddlJDate.Items.Insert(k, new ListItem(k.ToString(), k.ToString()));
            //    }
            //}


            //Load Year
            int j = 1;
            ddlYear.Items.Insert(0, new ListItem(strDDLSelectYear, Guid.Empty.ToString()));
            for (int i = DateTime.Now.Year - 18; i >= 1940; i--)
            {
                ddlYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                j++;
            }


            //Load Year
            int l = 1;
            ddlJoiningYear.Items.Insert(0, new ListItem(strDDLSelectYear, Guid.Empty.ToString()));
            for (int i = DateTime.Now.Year; i >= 1970; i--)
            {
                ddlJoiningYear.Items.Insert(l, new ListItem(i.ToString(), i.ToString()));
                l++;
            }

        }

        /// <summary>
        /// Load Employee Data
        /// </summary>
        private void BindEmployeeData()
        {
            try
            {
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "EMPLOYEE")
                {
                    Employee objLoadEmployeeData = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);

                    ddlDepartmentName.SelectedIndex = ddlDepartmentName.Items.FindByValue(Convert.ToString(objLoadEmployeeData.DepartmentID)) != null ? ddlDepartmentName.Items.IndexOf(ddlDepartmentName.Items.FindByValue(Convert.ToString(objLoadEmployeeData.DepartmentID))) : 0;
                    txtEmployeeNo.Text = Convert.ToString(objLoadEmployeeData.EmployeeNo);
                    ddlTitle.SelectedIndex = ddlTitle.Items.FindByValue(Convert.ToString(objLoadEmployeeData.Surname)) != null ? ddlTitle.Items.IndexOf(ddlTitle.Items.FindByValue(Convert.ToString(objLoadEmployeeData.Surname))) : 0;
                    txtFirstName.Text = Convert.ToString(objLoadEmployeeData.FirstName);
                    txtLastName.Text = Convert.ToString(objLoadEmployeeData.LastName);
                    txtEmail.Text = hfOldEmial.Value = Convert.ToString(objLoadEmployeeData.Email);
                    //txtDateOfBirth.Text = objLoadEmployeeData.BirthDate == null ? "" : objLoadEmployeeData.BirthDate.Value.ToString(clsSession.DateFormat);
                    //txtDateOfBirth.Text = objLoadEmployeeData.BirthDate == null ? "" : objLoadEmployeeData.BirthDate.Value.ToString("dd/MMM/yyyy");

                    ddlDate.SelectedValue = Convert.ToString(objLoadEmployeeData.BirthDate) == "" ? Guid.Empty.ToString() : objLoadEmployeeData.BirthDate.Value.Day.ToString().Length == 2 ? objLoadEmployeeData.BirthDate.Value.Day.ToString() : "0" + objLoadEmployeeData.BirthDate.Value.Day.ToString();
                    ddlMonth.SelectedValue = Convert.ToString(objLoadEmployeeData.BirthDate) == "" ? Guid.Empty.ToString() : objLoadEmployeeData.BirthDate.Value.Month.ToString();
                    ddlYear.SelectedValue = Convert.ToString(objLoadEmployeeData.BirthDate) == "" ? Guid.Empty.ToString() : objLoadEmployeeData.BirthDate.Value.Year.ToString();

                    txtNationality.Text = Convert.ToString(objLoadEmployeeData.NationalityAtBirth);
                    ddlGender.SelectedIndex = ddlGender.Items.FindByValue(Convert.ToString(objLoadEmployeeData.Gender)) != null ? ddlGender.Items.IndexOf(ddlGender.Items.FindByValue(Convert.ToString(objLoadEmployeeData.Gender))) : 0;
                    ddlMaritalStatus.SelectedIndex = ddlMaritalStatus.Items.FindByValue(Convert.ToString(objLoadEmployeeData.MaritalStatus)) != null ? ddlMaritalStatus.Items.IndexOf(ddlMaritalStatus.Items.FindByValue(Convert.ToString(objLoadEmployeeData.MaritalStatus))) : 0;
                    txtMobileNo.Text = Convert.ToString(objLoadEmployeeData.MobileNo);
                    txtLandlineNo.Text = Convert.ToString(objLoadEmployeeData.LandlineNo);

                    //txtDateOfJoin.Text = objLoadEmployeeData.DOJ == null ? "" : objLoadEmployeeData.DOJ.Value.ToString(clsSession.DateFormat);
                    ddlJoiningDate.SelectedValue = Convert.ToString(objLoadEmployeeData.DOJ) == "" ? Guid.Empty.ToString() : objLoadEmployeeData.DOJ.Value.Day.ToString().Length == 2 ? objLoadEmployeeData.DOJ.Value.Day.ToString() : "0" + objLoadEmployeeData.DOJ.Value.Day.ToString();
                    ddlJoiningMonth.SelectedValue = Convert.ToString(objLoadEmployeeData.DOJ) == "" ? Guid.Empty.ToString() : objLoadEmployeeData.DOJ.Value.Month.ToString();
                    ddlJoiningYear.SelectedValue = Convert.ToString(objLoadEmployeeData.DOJ) == "" ? Guid.Empty.ToString() : objLoadEmployeeData.DOJ.Value.Year.ToString();

                    ddlStatus.SelectedIndex = ddlStatus.Items.FindByValue(Convert.ToString(objLoadEmployeeData.StatusID)) != null ? ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(Convert.ToString(objLoadEmployeeData.StatusID))) : 0;

                    //To Get record in DataSet with city,state,country name.
                    Address objAdrsToGetListPA = new Address();
                    objAdrsToGetListPA.AddressID = (Guid)objLoadEmployeeData.PAddressID;
                    objAdrsToGetListPA.IsActive = true;
                    DataSet dsRegisteredAddress = AddressBLL.GetAllWithDataSet(objAdrsToGetListPA);

                    if (dsRegisteredAddress != null && dsRegisteredAddress.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsRegisteredAddress.Tables[0].Rows[0];
                        ucPermanentAddress.strAddress = Convert.ToString(dr["Add1"]);
                        ucPermanentAddress.strCity = Convert.ToString(dr["CityName"]);
                        ucPermanentAddress.strState = Convert.ToString(dr["StateName"]);
                        ucPermanentAddress.strCountry = Convert.ToString(dr["CountryName"]);
                        ucPermanentAddress.strZipCode = Convert.ToString(dr["ZipCode"]);
                    }


                    //To Get record in DataSet with city,state,country name.
                    Address objAdrsToGetList = new Address();
                    objAdrsToGetList.AddressID = (Guid)objLoadEmployeeData.CAddressID;
                    objAdrsToGetList.IsActive = true;
                    DataSet dsOfficeAddress = AddressBLL.GetAllWithDataSet(objAdrsToGetList);

                    if (dsOfficeAddress != null && dsOfficeAddress.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr1 = dsOfficeAddress.Tables[0].Rows[0];
                        ucCurrentAddress.strAddress = Convert.ToString(dr1["Add1"]);
                        ucCurrentAddress.strCity = Convert.ToString(dr1["CityName"]);
                        ucCurrentAddress.strState = Convert.ToString(dr1["StateName"]);
                        ucCurrentAddress.strCountry = Convert.ToString(dr1["CountryName"]);
                        ucCurrentAddress.strZipCode = Convert.ToString(dr1["ZipCode"]);
                    }

                    if (Convert.ToString(objLoadEmployeeData.Photo) != "" && Convert.ToString(objLoadEmployeeData.Photo) != null)
                    {
                        if (objLoadEmployeeData.Photo.ToUpper().Trim() == "BUSINESSCARD.PNG")
                        {
                            imgEmployee.ImageUrl = "~/images/BusinessCard.png";
                            lnkRemoveLogo.Visible = false;
                        }
                        else
                        {
                            string str = "~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "Employee/" + Convert.ToString(objLoadEmployeeData.Photo);
                            string mappath = Server.MapPath(str);
                            FileInfo f = new FileInfo(mappath);
                            if (f.Exists)
                            {
                                lnkRemoveLogo.Visible = true;
                                imgEmployee.ImageUrl = str;
                            }
                            else
                            {
                                lnkRemoveLogo.Visible = false;
                                imgEmployee.ImageUrl = "~/images/BusinessCard.png";
                            }
                        }
                    }
                    else
                    {
                        lnkRemoveLogo.Visible = false;
                        imgEmployee.ImageUrl = "~/images/BusinessCard.png";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Validation
        /// </summary>
        private void LoadValidation()
        {

            List<PropertyConfiguration> lstPropertyConfiguration = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, Convert.ToString(clsSession.PropertyID));

            if (lstPropertyConfiguration.Count != 0)
            {
                PropertyConfiguration objPropertyConfiguration = lstPropertyConfiguration[0];
                ucPermanentAddress.rfvZipCode.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipPostCode));
                ucPermanentAddress.rfvAddress.Enabled = ucPermanentAddress.rfvCity.Enabled = ucPermanentAddress.rfvState.Enabled = ucPermanentAddress.rfvCountry.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipAddress));
                rfvMobileNo.Enabled = !(Convert.ToBoolean(objPropertyConfiguration.IsSkipContactNo));

                ucCurrentAddress.rfvZipCode.Enabled = ucCurrentAddress.rfvAddress.Enabled = ucCurrentAddress.rfvCity.Enabled = ucCurrentAddress.rfvState.Enabled = ucCurrentAddress.rfvCountry.Enabled = false;

                if (!Convert.ToBoolean(lstPropertyConfiguration[0].IsSkipAddress))
                {
                    ucPermanentAddress.tcAddress.Attributes.Add("class", "isrequire");
                    ucPermanentAddress.tcCity.Attributes.Add("class", "isrequire");
                    ucPermanentAddress.tcState.Attributes.Add("class", "isrequire");
                    ucPermanentAddress.tcCountry.Attributes.Add("class", "isrequire");
                }

                if (!Convert.ToBoolean(lstPropertyConfiguration[0].IsSkipContactNo))
                {
                    tdMobileNo.Attributes.Add("class", "isrequire");
                }

                if (!Convert.ToBoolean(lstPropertyConfiguration[0].IsSkipPostCode))
                {
                    ucPermanentAddress.tcZipcode.Attributes.Add("class", "isrequire");
                }
            }
        }

        /// <summary>
        /// Send Email With Password Key
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="UserID"></param>
        /// <param name="PasswordKey"></param>
        private void SendEmailWithPasswordKey(string UserDisplayName, string UserName, string Password, Guid UserID, string PasswordKey)
        {
            try
            {
                Guid? companyID = null;
                Guid? propertyID = null;
                if (Convert.ToString(clsSession.PropertyID) != string.Empty)
                    propertyID = clsSession.PropertyID;

                if (Convert.ToString(clsSession.CompanyID) != string.Empty)
                    companyID = clsSession.CompanyID;

                DataSet dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(propertyID, companyID, "User Activation");

                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);

                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        string strLink = Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "UserActivation.aspx?UserID=" + UserID.ToString() + "&key=" + PasswordKey;
                        string strActivationLink = "<a href='" + strLink + "'>" + strLink + "</a>";

                        string strHTML = Convert.ToString(dsSearchEmailTemplate.Tables[0].Rows[0]["Body"]);
                        strHTML = strHTML.Replace("$DISPLAYNAME$", UserDisplayName.Trim());
                        strHTML = strHTML.Replace("$USERNAME$", UserName.Trim());
                        strHTML = strHTML.Replace("$PASSWORD$", Password.Trim());
                        strHTML = strHTML.Replace("$HOTELCODE$", Convert.ToString(clsSession.HotelCode.Trim()));
                        strHTML = strHTML.Replace("$ACTIVATIONLINK$", strActivationLink);

                        SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, UserName, clsCommon.GetGlobalResourceText("CommonMessage", "lblUserActivationEmailSubject", "Activate your account on UniworldIndia.com"), strHTML);
                    }
                    else
                        MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
                }
                else
                    MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Update Employee Data
        /// </summary>
        private void UpdateEmployeeData()
        {
            string strDateOfBirth = Convert.ToString(ddlDate.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
            string strDateOfJoin = Convert.ToString(ddlJoiningDate.SelectedValue.ToString().Trim() + "-" + ddlJoiningMonth.SelectedItem.Text.Trim() + "-" + ddlJoiningYear.SelectedValue.ToString().Trim());

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            Employee objToUpdate = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);
            Employee EmpOldData = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);

            objToUpdate.PropertyID = clsSession.PropertyID;
            if (ddlDepartmentName.SelectedValue != Guid.Empty.ToString())
                objToUpdate.DepartmentID = new Guid(ddlDepartmentName.SelectedValue);
            else
                objToUpdate.DepartmentID = null;

            if (ddlTitle.SelectedValue != Guid.Empty.ToString())
                objToUpdate.Surname = Convert.ToString(ddlTitle.SelectedValue);
            else
                objToUpdate.Surname = null;

            objToUpdate.EmployeeNo = txtEmployeeNo.Text.Trim();
            objToUpdate.FirstName = txtFirstName.Text.Trim();
            objToUpdate.LastName = Convert.ToString(txtLastName.Text.Trim());
            objToUpdate.FullName = objToUpdate.Surname + " " + objToUpdate.FirstName + " " + Convert.ToString(objToUpdate.LastName);

            //if (!(txtDateOfBirth.Text.Trim().Equals("")))
            //    objToUpdate.BirthDate = DateTime.ParseExact(txtDateOfBirth.Text.Trim(), "dd/MMM/yyyy", objCultureInfo);
            //else
            //    objToUpdate.BirthDate = null;

            objToUpdate.BirthDate = Convert.ToDateTime(strDateOfBirth);
            objToUpdate.NationalityAtBirth = txtNationality.Text.Trim();
            if (ddlGender.SelectedValue != Guid.Empty.ToString())
                objToUpdate.Gender = Convert.ToString(ddlGender.SelectedValue);
            else
                objToUpdate.Gender = null;

            if (ddlMaritalStatus.SelectedValue != Guid.Empty.ToString())
                objToUpdate.MaritalStatus = Convert.ToString(ddlMaritalStatus.SelectedValue);
            else
                objToUpdate.MaritalStatus = null;

            objToUpdate.Email = txtEmail.Text;

            //if (!(txtDateOfJoin.Text.Trim().Equals("")))
            //    objToUpdate.DOJ = DateTime.ParseExact(txtDateOfJoin.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            //else
            //    objToUpdate.DOJ = null;

            objToUpdate.DOJ = Convert.ToDateTime(strDateOfJoin);
            if (ddlStatus.SelectedValue != Guid.Empty.ToString())
                objToUpdate.StatusID = new Guid(ddlStatus.SelectedValue);
            else
                objToUpdate.StatusID = null;
            objToUpdate.MobileNo = txtMobileNo.Text.Trim();
            objToUpdate.LandlineNo = txtLandlineNo.Text.Trim();

            if (Convert.ToString(hdnUploadPhoto.Value) != "")
                objToUpdate.Photo = Convert.ToString(hdnUploadPhoto.Value);

            //Permanent Adderss Employee

            Address EmpPAddress = new Address();
            EmpPAddress = AddressBLL.GetByPrimaryKey(new Guid(Convert.ToString(objToUpdate.PAddressID)));
            if (EmpPAddress == null)
                EmpPAddress = new Address();

            EmpPAddress.Add1 = ucPermanentAddress.strAddress.Trim();
            EmpPAddress.ZipCode = ucPermanentAddress.strZipCode.Trim();
            EmpPAddress.IsActive = true;
            EmpPAddress.IsSynch = false;
            EmpPAddress.CountryID = clsCommon.Country(ucPermanentAddress.strCountry.Trim());
            EmpPAddress.StateID = clsCommon.State(ucPermanentAddress.strState.Trim());
            EmpPAddress.CityID = clsCommon.City(ucPermanentAddress.strCity.Trim());

            Address EmpCAddress = new Address();
            EmpCAddress = AddressBLL.GetByPrimaryKey(new Guid(Convert.ToString(objToUpdate.CAddressID)));
            if (EmpCAddress == null)
                EmpCAddress = new Address();

            EmpCAddress.Add1 = ucCurrentAddress.strAddress.Trim();
            EmpCAddress.ZipCode = ucCurrentAddress.strZipCode.Trim();
            EmpCAddress.IsActive = true;
            EmpCAddress.IsSynch = false;
            EmpCAddress.CountryID = clsCommon.Country(ucCurrentAddress.strCountry.Trim());
            EmpCAddress.StateID = clsCommon.State(ucCurrentAddress.strState.Trim());
            EmpCAddress.CityID = clsCommon.City(ucCurrentAddress.strCity.Trim());

            EmployeeBLL.Update(objToUpdate, EmpPAddress, EmpCAddress);

            ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", EmpOldData.ToString(), objToUpdate.ToString(), "hrm_Employee");

            if (Convert.ToString(EmpOldData.Email) != Convert.ToString(objToUpdate.Email))
            {
                List<User> lstGetUserData = UserBLL.GetAllBy(User.UserFields.UserTypeID, Convert.ToString(this.EmployeeID));

                if (lstGetUserData.Count == 1)
                {
                    User objGetUserData = lstGetUserData[0];

                    objGetUserData.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    objGetUserData.IsActive = false;

                    SendEmailWithPasswordKey(Convert.ToString(lstGetUserData[0].UserDisplayName), Convert.ToString(lstGetUserData[0].UserName), Convert.ToString(lstGetUserData[0].Password), lstGetUserData[0].UsearID, objGetUserData.PasswordKey);

                    UserBLL.Update(objGetUserData);

                    if (Convert.ToString(lstGetUserData[0].UsearID) == Convert.ToString(clsSession.UserID))
                    {
                        Session.Clear();
                        Response.Redirect("~/Index.aspx");
                    }
                }
            }

            IsListMessage = true;
            litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            ClearControl();
        }
        #endregion Method

        #region Control Event

        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Configurations/EmployeeList.aspx");
        }

        /// <summary>
        /// Button Save And Update Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
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

                    string DateOfJoin = Convert.ToString(ddlJoiningDate.SelectedValue.ToString().Trim() + "-" + ddlJoiningMonth.SelectedItem.Text.Trim() + "-" + ddlJoiningYear.SelectedValue.ToString().Trim());
                    try
                    {

                        if (Convert.ToDateTime(DateOfJoin) > DateTime.Now.Date)
                        {
                            divJoiningDate.Visible = true;
                            return;
                        }
                        else
                            divJoiningDate.Visible = false;

                    }
                    catch
                    {
                        divJoiningDate.Visible = true;
                        return;
                    }

                    Employee IsDupEmp = new Employee();
                    IsDupEmp.Email = txtEmail.Text.Trim();
                    IsDupEmp.PropertyID = clsSession.PropertyID;

                    List<Employee> LstDupEmp = EmployeeBLL.GetAll(IsDupEmp);
                    if (LstDupEmp.Count > 0)
                    {
                        if (this.EmployeeID != Guid.Empty)
                        {
                            if (Convert.ToString(LstDupEmp[0].EmployeeID) != Convert.ToString(this.EmployeeID))
                            {
                                IsListMessage = true;
                                litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (this.EmployeeID != Guid.Empty)
                    {
                        //Update Employee    
                        if (fuEmployeeLogo.FileName != "")
                        {
                            string strDirPath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "Employee");

                            if (!Directory.Exists(strDirPath))
                                Directory.CreateDirectory(strDirPath);

                            hdnUploadPhoto.Value = Guid.NewGuid() + "$" + fuEmployeeLogo.FileName.Replace(" ", "_");

                            string path = strDirPath + "/" + Convert.ToString(hdnUploadPhoto.Value);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuEmployeeLogo.FileContent);
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
                        List<User> lstLoadUserData = UserBLL.GetAllBy(User.UserFields.UserTypeID, Convert.ToString(this.EmployeeID));
                        if (lstLoadUserData.Count != 0)
                        {
                            if (!Emp.Email.Equals(txtEmail.Text.Trim()) && !(txtEmail.Text.Trim().Equals("")))
                                EmailNotification.Show();
                            else
                                UpdateEmployeeData();
                        }
                        else
                            UpdateEmployeeData();
                    }
                    else
                    {
                        //Insert Employee
                        Employee objToInsert = new Employee();

                        objToInsert.PropertyID = clsSession.PropertyID;
                        if (ddlDepartmentName.SelectedValue != Guid.Empty.ToString())
                            objToInsert.DepartmentID = new Guid(ddlDepartmentName.SelectedValue);
                        if (ddlTitle.SelectedValue != Guid.Empty.ToString())
                            objToInsert.Surname = Convert.ToString(ddlTitle.SelectedValue);
                        objToInsert.EmployeeNo = txtEmployeeNo.Text.Trim();
                        objToInsert.FirstName = txtFirstName.Text.Trim();
                        objToInsert.LastName = Convert.ToString(txtLastName.Text.Trim());
                        objToInsert.FullName = objToInsert.Surname + " " + objToInsert.FirstName + " " + Convert.ToString(objToInsert.LastName);

                        //if (!(txtDateOfBirth.Text.Trim().Equals("")))
                        //    objToInsert.BirthDate = DateTime.ParseExact(txtDateOfBirth.Text.Trim(), "dd/MMM/yyyy", objCultureInfo);

                        objToInsert.BirthDate = Convert.ToDateTime(DateOfBirth);
                        objToInsert.NationalityAtBirth = txtNationality.Text.Trim();
                        if (ddlGender.SelectedValue != Guid.Empty.ToString())
                            objToInsert.Gender = Convert.ToString(ddlGender.SelectedValue);
                        if (ddlMaritalStatus.SelectedValue != Guid.Empty.ToString())
                            objToInsert.MaritalStatus = Convert.ToString(ddlMaritalStatus.SelectedValue);
                        objToInsert.Email = txtEmail.Text;

                        //if (!(txtDateOfJoin.Text.Trim().Equals("")))
                        //    objToInsert.DOJ = DateTime.ParseExact(txtDateOfJoin.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                        objToInsert.DOJ = Convert.ToDateTime(DateOfJoin);
                        if (ddlStatus.SelectedValue != Guid.Empty.ToString())
                            objToInsert.StatusID = new Guid(ddlStatus.SelectedValue);
                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.IsActive = true;
                        objToInsert.CreatedOn = DateTime.Now;
                        objToInsert.MobileNo = txtMobileNo.Text.Trim();
                        objToInsert.LandlineNo = txtLandlineNo.Text.Trim();
                        objToInsert.IsSynch = false;
                        objToInsert.CreatedBy = clsSession.UserID;

                        if (fuEmployeeLogo.FileName != "")
                        {
                            string strDirPath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "Employee");

                            if (!Directory.Exists(strDirPath))
                                Directory.CreateDirectory(strDirPath);

                            string EmpPhoto = Guid.NewGuid() + "$" + fuEmployeeLogo.FileName.Replace(" ", "_");
                            string path = strDirPath + "/" + EmpPhoto;

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(fuEmployeeLogo.FileContent);
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
                            objToInsert.Photo = EmpPhoto;
                        }
                        else
                            objToInsert.Photo = "BusinessCard.png";

                        Address EmpPAddress = new Address();

                        EmpPAddress.Add1 = ucPermanentAddress.strAddress.Trim();
                        EmpPAddress.ZipCode = ucPermanentAddress.strZipCode.Trim();
                        EmpPAddress.IsActive = true;
                        EmpPAddress.CompanyID = clsSession.CompanyID;
                        EmpPAddress.IsSynch = false;
                        EmpPAddress.CountryID = clsCommon.Country(ucPermanentAddress.strCountry.Trim());
                        EmpPAddress.StateID = clsCommon.State(ucPermanentAddress.strState.Trim());
                        EmpPAddress.CityID = clsCommon.City(ucPermanentAddress.strCity.Trim());

                        Address EmpCAddress = new Address();

                        EmpCAddress.Add1 = ucCurrentAddress.strAddress.Trim();
                        EmpCAddress.ZipCode = ucCurrentAddress.strZipCode.Trim();
                        EmpCAddress.IsActive = true;
                        EmpCAddress.IsSynch = false;
                        EmpCAddress.CompanyID = clsSession.CompanyID;
                        EmpCAddress.CountryID = clsCommon.Country(ucCurrentAddress.strCountry.Trim());
                        EmpCAddress.StateID = clsCommon.State(ucCurrentAddress.strState.Trim());
                        EmpCAddress.CityID = clsCommon.City(ucCurrentAddress.strCity.Trim());

                        EmployeeBLL.SaveWithUserID(objToInsert, EmpPAddress, EmpCAddress, null);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "hrm_Employee");

                        IsListMessage = true;
                        litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //Click event of Remove logo button.
        protected void lnkRemoveLogo_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.EmployeeID != Guid.Empty)
                {
                    Employee objEmp = EmployeeBLL.GetByPrimaryKey(this.EmployeeID);

                    string deletepath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode + "/" + "Employee/" + Convert.ToString(objEmp.Photo));

                    if (File.Exists(deletepath))
                        File.Delete(deletepath);

                    objEmp.Thumb = "BusinessCard.png";
                    EmployeeBLL.Update(objEmp);

                    imgEmployee.ImageUrl = "~/images/BusinessCard.png";
                    lnkRemoveLogo.Visible = false;

                    IsListMessage = true;
                    litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRemovePhote", "Photo Removed Successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region BirthDate Validation
        protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1900/12/01");
            //year/month/date
            //DateTime maxDate = DateTime.Parse(DateTime.Now.ToString(clsSession.DateFormat));
            DateTime maxDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
        #endregion BirthDate Validation

        #region Email Change Notification
        /// <summary>
        /// Email Notification Save Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveEmailNotification_Click(object sender, EventArgs e)
        {
            UpdateEmployeeData();
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