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
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestor : System.Web.UI.UserControl
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
            if (RoleRightJoinBLL.GetAccessString("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            lblMsgDateValidate.Text = "";
            if (!IsPostBack)
            {
                if (Request["IsConvert"] != null && Convert.ToString(Request["IsConvert"]) == "1")
                {
                    IsInsert = true;
                    lblInvestorMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                }

                if (Session["UserType"] != null)
                {
                    string strUserType = Convert.ToString(Session["UserType"]);

                    if (Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
                    {
                        ddlSManagerType.Enabled = true;
                        ddlSManager.Enabled = true;


                        ddlManagerType.Enabled = true;
                        ddlRelationManagementID.Enabled = true;
                        txtNameOfFirm.Enabled = true;
                        txtManagerContactNo.Enabled = true;
                        txtManagerEmail.Enabled = true;
                    }
                    else
                    {
                        ddlSManagerType.Enabled = false;
                        ddlSManager.Enabled = false;

                        ddlManagerType.Enabled = false;
                        ddlRelationManagementID.Enabled = false;
                        txtNameOfFirm.Enabled = false;
                        txtManagerContactNo.Enabled = false;
                        txtManagerEmail.Enabled = false;
                    }
                }

                BindBirthDateDDLs();
                LoadDefaultValue();
                if (Session["ProspectID"] != null)
                {
                    this.ProspectID = new Guid(Convert.ToString(Session["ProspectID"]));
                    Session.Remove("ProspectID");
                    BindInvestorData();
                }

                ////Don't move location of calling BindCoOrdinator(), b'cas to Bind CoOrdinator dll after Prospect's session is Checked.
                BindCoOrdinator();

                if (Session["InvID"] != null)
                    LoadInvData();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSaveUp.Visible = btnSave.Visible = btnCancel.Visible = btnCancelUp.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
                txtPrimeMobileNo.Enabled = txtPrimeEmail.Enabled = ddlEmployee.Enabled = Convert.ToBoolean(DV[0]["IsCreate"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
         
        private string CheckDateOfBirthsValidation()
        {
            if (ddlDay.SelectedIndex != 0 || ddlMonth.SelectedIndex != 0 || ddlYear.SelectedIndex != 0)
            {
                string DateOfBirth = Convert.ToString(ddlDay.SelectedValue.ToString() + "-" + ddlMonth.SelectedItem.Text + "-" + ddlYear.SelectedValue.ToString());
                try
                {
                    DateTime dtTemp = Convert.ToDateTime(DateOfBirth);
                }
                catch
                {
                    return "FIRSTOWNER";
                }
            }

            if (ddlRefDay.SelectedIndex != 0 || ddlRefMonth.SelectedIndex != 0 || ddlRefYear.SelectedIndex != 0)
            {
                string DateOfBirth = Convert.ToString(ddlRefDay.SelectedValue.ToString() + "-" + ddlRefMonth.SelectedItem.Text + "-" + ddlRefYear.SelectedValue.ToString());
                try
                {
                    DateTime dtTemp = Convert.ToDateTime(DateOfBirth);
                }
                catch
                {
                    return "JOINTOWNER";
                }
            }

            if (ddl2JODay.SelectedIndex != 0 || ddl2JOMonth.SelectedIndex != 0 || ddl2JOYear.SelectedIndex != 0)
            {
                string DateOfBirth = Convert.ToString(ddl2JODay.SelectedValue.ToString() + "-" + ddl2JOMonth.SelectedItem.Text + "-" + ddl2JOYear.SelectedValue.ToString());
                try
                {
                    DateTime dtTemp = Convert.ToDateTime(DateOfBirth);
                }
                catch
                {
                    return "2NDJOINTOWNER";
                }
            }

            return "";
        }

        /// <summary>
        /// Send Email To Investor Creation
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void SendEmail(Guid InvestorID, string Password, string FullName, Guid UserID, string PasswordKey)
        {
            try
            {
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    string strLink = Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "UserActivation.aspx?UserID=" + UserID.ToString() + "&key=" + PasswordKey;
                    string strActivationLink = "<a href='" + strLink + "'>" + strLink + "</a>";

                    PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                    DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Investor Registration");
                    if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                    {
                        string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); //File.ReadAllText(Server.MapPath("~/EmailTemplates/InvestorRegistration.htm"));

                        strHTML = strHTML.Replace("$FULLNAME$", FullName);
                        strHTML = strHTML.Replace("$PASSWORD$", Password);
                        strHTML = strHTML.Replace("$ACTIVATIONLINK$", strActivationLink);

                        Investor GetData = InvestorBLL.GetByPrimaryKey(InvestorID);
                        strHTML = strHTML.Replace("$USERNAME$", GetData.EMail);
                        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        //SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), GetData.EMail, "Investor Registration", strHTML);
                    }
                    #region Old Code
                    /*
                     string strLink = Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "UserActivation.aspx?UserID=" + UserID.ToString() + "&key=" + PasswordKey;
                    string strActivationLink = "<a href='" + strLink + "'>" + strLink + "</a>";

                    PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                    string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/InvestorRegistration.htm"));

                    strHTML = strHTML.Replace("$FULLNAME$", FullName);
                    strHTML = strHTML.Replace("$PASSWORD$", Password);
                    strHTML = strHTML.Replace("$ACTIVATIONLINK$", strActivationLink);

                    Investor GetData = InvestorBLL.GetByPrimaryKey(InvestorID);
                    strHTML = strHTML.Replace("$USERNAME$", GetData.EMail);

                    strHTML = strHTML.Replace("$LITINVFULLNAME$", GetData.Title + " " + GetData.FName + " " + GetData.LName);
                    strHTML = strHTML.Replace("$INVEMAIL$", GetData.EMail);

                    if (Convert.ToString(GetData.MobileNo) != "" && GetData.MobileNo != null)
                    {
                        string[] words = GetData.MobileNo.Split('-');
                        if (words.Length > 1)
                        {
                            if (Convert.ToString(words[0]) != "")
                                strHTML = strHTML.Replace("$INVMOBILENO$", Convert.ToString(GetData.MobileNo.Trim()));
                            else
                                strHTML = strHTML.Replace("$INVMOBILENO$", Convert.ToString(words[1]).Replace("-", ""));
                        }
                        else
                            strHTML = Convert.ToString(GetData.MobileNo.Replace("-", ""));
                    }
                    else
                        strHTML = strHTML.Replace("$INVMOBILENO$", "NA");

                    //strHTML = strHTML.Replace("$INVMOBILENO$", Convert.ToString(GetData.MobileNo) == "" ? "NA" : GetData.MobileNo.Trim());

                    Address GetAddC = AddressBLL.GetByPrimaryKey(new Guid(GetData.AgreementAddressID.Value.ToString()));
                    strHTML = strHTML.Replace("$INVADDRESS$", Convert.ToString(GetAddC.Add1) == "" ? "NA" : GetAddC.Add1.Trim());

                    if (GetAddC.CityID != null)
                    {
                        City GetCt = CityBLL.GetByPrimaryKey(new Guid(GetAddC.CityID.Value.ToString()));
                        if (GetCt != null)
                            strHTML = strHTML.Replace("$INVCITY$", GetCt.CityName);
                        else
                            strHTML = strHTML.Replace("$INVCITY$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$INVCITY$", "NA");
                    if (GetAddC.StateID != null)
                    {
                        State GetSt = StateBLL.GetByPrimaryKey(new Guid(GetAddC.StateID.Value.ToString()));
                        if (GetSt != null)
                            strHTML = strHTML.Replace("$INVSTATE$", GetSt.StateName);
                        else
                            strHTML = strHTML.Replace("$INVSTATE$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$INVSTATE$", "NA");
                    if (GetAddC.CountryID != null)
                    {
                        Country Cnt = CountryBLL.GetByPrimaryKey(new Guid(GetAddC.CountryID.Value.ToString()));
                        if (Cnt != null)
                            strHTML = strHTML.Replace("$INVCOUNTRY$", Cnt.CountryName);
                        else
                            strHTML = strHTML.Replace("$INVCOUNTRY$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$INVCOUNTRY$", "NA");

                    strHTML = strHTML.Replace("$INVZIPCODE$", Convert.ToString(GetAddC.ZipCode) == "" ? "NA" : GetAddC.ZipCode.Trim());

                    Address GetAddP = AddressBLL.GetByPrimaryKey(new Guid(GetData.PostalAddressID.Value.ToString()));
                    strHTML = strHTML.Replace("$INVPADDRESS$", Convert.ToString(GetAddP.Add1) == "" ? "NA" : GetAddP.Add1.Trim());

                    if (GetAddP.CityID != null)
                    {
                        City GetPCt = CityBLL.GetByPrimaryKey(new Guid(GetAddP.CityID.Value.ToString()));
                        if (GetPCt != null)
                            strHTML = strHTML.Replace("$INVPCITY$", GetPCt.CityName);
                        else
                            strHTML = strHTML.Replace("$INVPCITY$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$INVPCITY$", "NA");
                    if (GetAddP.StateID != null)
                    {
                        State GetPSt = StateBLL.GetByPrimaryKey(new Guid(GetAddP.StateID.Value.ToString()));
                        if (GetPSt != null)
                            strHTML = strHTML.Replace("$INVPSTATE$", GetPSt.StateName);
                        else
                            strHTML = strHTML.Replace("$INVPSTATE$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$INVPSTATE$", "NA");
                    if (GetAddP.CountryID != null)
                    {
                        Country PCnt = CountryBLL.GetByPrimaryKey(new Guid(GetAddP.CountryID.Value.ToString()));
                        if (PCnt != null)
                            strHTML = strHTML.Replace("$INVPCOUNTRY$", PCnt.CountryName);
                        else
                            strHTML = strHTML.Replace("$INVPCOUNTRY$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$INVPCOUNTRY$", "NA");

                    strHTML = strHTML.Replace("$INVPZIPCODE$", Convert.ToString(GetAddP.ZipCode) == "" ? "NA" : GetAddP.ZipCode.Trim());

                    strHTML = strHTML.Replace("$INVAGE$", Convert.ToString(GetData.Age) == "" ? "NA" : Convert.ToString(GetData.Age));
                    strHTML = strHTML.Replace("$INVPANNO$", GetData.PanNo == null ? "NA" : GetData.PanNo);
                    strHTML = strHTML.Replace("$INVPOAHOLDER$", GetData.POAHolder == null ? "NA" : GetData.POAHolder);
                    strHTML = strHTML.Replace("$INVBANKNAME$", GetData.BankName == null ? "NA" : GetData.BankName);
                    strHTML = strHTML.Replace("$INVBANKACCOUNTNO$", GetData.AccountNo == null ? "NA" : GetData.AccountNo);



                    if (GetData.OccupationTermID == null)
                        strHTML = strHTML.Replace("$INVOCCUPATION$", "NA");
                    else
                    {
                        ProjectTerm Get = ProjectTermBLL.GetByPrimaryKey(new Guid(GetData.OccupationTermID.Value.ToString()));
                        if (Get != null)
                            strHTML = strHTML.Replace("$INVOCCUPATION$", Get.Term);
                        else
                            strHTML = strHTML.Replace("$INVOCCUPATION$", "NA");
                    }
                    strHTML = strHTML.Replace("$INVCOMPANYNAME$", GetData.CompanyName == null ? "NA" : GetData.CompanyName);
                    strHTML = strHTML.Replace("$INVDESIGNATION$", GetData.Designation == null ? "NA" : GetData.Designation);

                    if (GetData.RelationShipManagerID == null)
                        strHTML = strHTML.Replace("$RELATIONMANAGERNAME$", "NA");
                    else
                    {
                        ProjectTerm ManagereInv = ProjectTermBLL.GetByPrimaryKey(new Guid(GetData.RelationShipManagerID.Value.ToString()));
                        if (ManagereInv != null)
                            strHTML = strHTML.Replace("$RELATIONMANAGERNAME$", ManagereInv.Term);
                        else
                            strHTML = strHTML.Replace("$RELATIONMANAGERNAME$", "NA");
                    }
                    strHTML = strHTML.Replace("$MANAGERTYPE$", GetData.ManagerType);

                    strHTML = strHTML.Replace("$NAMEOFFIRM$", GetData.NameOfFirm == null ? "NA" : GetData.NameOfFirm);
                    strHTML = strHTML.Replace("$MANAGEREMAIL$", GetData.ManagerEmail == null ? "NA" : GetData.ManagerEmail);
                    strHTML = strHTML.Replace("$PRIMEMOBILENO$", GetData.PrimeMobileNo == null ? "NA" : GetData.PrimeMobileNo);
                    strHTML = strHTML.Replace("$PRIMEEMAIL$", GetData.PrimeEmail == null ? "NA" : GetData.PrimeEmail);
                    strHTML = strHTML.Replace("$MANAGERCONTACTNO$", GetData.ManagerContactNo == null ? "NA" : GetData.ManagerContactNo);

                    if (Convert.ToString(GetData.UniworldPrime) != "" && Convert.ToString(GetData.UniworldPrime) != null && Convert.ToString(GetData.UniworldPrime) != Guid.Empty.ToString())
                    {
                        Employee objGetEmpData = EmployeeBLL.GetByPrimaryKey(new Guid(GetData.UniworldPrime));
                        strHTML = strHTML.Replace("$UNIWORLDPRIME$", Convert.ToString(objGetEmpData.FullName) == "" ? "NA" : Convert.ToString(objGetEmpData.FullName));
                    }
                    else
                        strHTML = strHTML.Replace("$UNIWORLDPRIME$", "NA");

                    //Add Reference Information In Email

                    List<Investor> LstRefGetData = InvestorBLL.GetAllBy(Investor.InvestorFields.RefInverstorID, InvestorID.ToString());
                    Investor RefInv = (Investor)(LstRefGetData[0]);

                    string strJointInvName = string.Empty;
                    strJointInvName = RefInv.Title + " " + RefInv.FName + " " + RefInv.LName;

                    strHTML = strHTML.Replace("$LITREFFULLNAME$", strJointInvName.Trim() == string.Empty ? "NA" : strJointInvName.Trim());
                    strHTML = strHTML.Replace("$REFEMAIL$", Convert.ToString(RefInv.EMail) == "" ? "NA" : RefInv.EMail);

                    if (Convert.ToString(RefInv.MobileNo) != "" && RefInv.MobileNo != null)
                    {
                        string[] words = RefInv.MobileNo.Split('-');
                        if (words.Length > 1)
                        {
                            if (Convert.ToString(words[0]) != "")
                                strHTML = strHTML.Replace("$REFMOBILENO$", Convert.ToString(RefInv.MobileNo.Trim()));
                            else
                                strHTML = strHTML.Replace("$REFMOBILENO$", Convert.ToString(words[1]).Replace("-", ""));
                        }
                        else
                            strHTML = Convert.ToString(RefInv.MobileNo.Replace("-", ""));
                    }
                    else
                        strHTML = strHTML.Replace("$REFMOBILENO$", "NA");

                    //strHTML = strHTML.Replace("$REFMOBILENO$", Convert.ToString(RefInv.MobileNo) == "" ? "NA" : RefInv.MobileNo);

                    Address RefGetAddC = AddressBLL.GetByPrimaryKey(new Guid(RefInv.AgreementAddressID.Value.ToString()));
                    strHTML = strHTML.Replace("$REFADDRESS$", Convert.ToString(RefGetAddC.Add1) == "" ? "NA" : RefGetAddC.Add1);

                    if (RefGetAddC.CityID != null)
                    {
                        City RefGetCt = CityBLL.GetByPrimaryKey(new Guid(RefGetAddC.CityID.Value.ToString()));
                        if (RefGetCt != null)
                            strHTML = strHTML.Replace("$REFCITY$", RefGetCt.CityName);
                        else
                            strHTML = strHTML.Replace("$REFCITY$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$REFCITY$", "NA");
                    if (RefGetAddC.StateID != null)
                    {
                        State RefGetSt = StateBLL.GetByPrimaryKey(new Guid(RefGetAddC.StateID.Value.ToString()));
                        if (RefGetSt != null)
                            strHTML = strHTML.Replace("$REFSTATE$", RefGetSt.StateName);
                        else
                            strHTML = strHTML.Replace("$REFSTATE$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$REFSTATE$", "NA");
                    if (RefGetAddC.CountryID != null)
                    {
                        Country RefCnt = CountryBLL.GetByPrimaryKey(new Guid(RefGetAddC.CountryID.Value.ToString()));
                        if (RefCnt != null)
                            strHTML = strHTML.Replace("$REFCOUNTRY$", RefCnt.CountryName);
                        else
                            strHTML = strHTML.Replace("$REFCOUNTRY$", "NA");
                    }
                    else strHTML = strHTML.Replace("$REFCOUNTRY$", "NA");

                    strHTML = strHTML.Replace("$REFZIPCODE$", Convert.ToString(RefGetAddC.ZipCode) == "" ? "NA" : RefGetAddC.ZipCode);


                    Address RefGetAddP = AddressBLL.GetByPrimaryKey(new Guid(RefInv.PostalAddressID.Value.ToString()));
                    strHTML = strHTML.Replace("$REFPADDRESS$", Convert.ToString(RefGetAddP.Add1) == "" ? "NA" : RefGetAddP.Add1);

                    if (RefGetAddP.CityID != null)
                    {
                        City GetCCt = CityBLL.GetByPrimaryKey(new Guid(RefGetAddP.CityID.Value.ToString()));
                        if (GetCCt != null)
                            strHTML = strHTML.Replace("$REFPCITY$", GetCCt.CityName);
                        else
                            strHTML = strHTML.Replace("$REFPCITY$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$REFPCITY$", "NA");
                    if (RefGetAddP.StateID != null)
                    {
                        State GetCSt = StateBLL.GetByPrimaryKey(new Guid(RefGetAddP.StateID.Value.ToString()));
                        if (GetCSt != null)
                            strHTML = strHTML.Replace("$REFPSTATE$", GetCSt.StateName);
                        else
                            strHTML = strHTML.Replace("$REFPSTATE$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$REFPSTATE$", "NA");
                    if (RefGetAddP.CountryID != null)
                    {
                        Country RefPCnt = CountryBLL.GetByPrimaryKey(new Guid(RefGetAddP.CountryID.Value.ToString()));
                        if (RefPCnt != null)
                            strHTML = strHTML.Replace("$REFPCOUNTRY$", RefPCnt.CountryName);
                        else
                            strHTML = strHTML.Replace("$REFPCOUNTRY$", "NA");
                    }
                    else
                        strHTML = strHTML.Replace("$REFPCOUNTRY$", "NA");
                    strHTML = strHTML.Replace("$REFPZIPCODE$", Convert.ToString(RefGetAddP.ZipCode) == "" ? "NA" : RefGetAddP.ZipCode);


                    strHTML = strHTML.Replace("$REFAGE$", Convert.ToString(RefInv.Age) == "" ? "NA" : Convert.ToString(RefInv.Age));
                    strHTML = strHTML.Replace("$REFPANNO$", RefInv.PanNo == null ? "NA" : RefInv.PanNo);
                    strHTML = strHTML.Replace("$REFPOAHOLDER$", RefInv.POAHolder == null ? "NA" : RefInv.POAHolder);
                    strHTML = strHTML.Replace("$REFBANKNAME$", RefInv.BankName == null ? "NA" : RefInv.BankName);
                    strHTML = strHTML.Replace("$REFBANKACCOUNTNO$", RefInv.AccountNo == null ? "NA" : RefInv.AccountNo);


                    if (RefInv.OccupationTermID == null)
                        strHTML = strHTML.Replace("$REFOCCUPATION$", "NA");
                    else
                    {
                        ProjectTerm RefGet = ProjectTermBLL.GetByPrimaryKey(new Guid(RefInv.OccupationTermID.Value.ToString()));
                        if (RefGet != null)
                            strHTML = strHTML.Replace("$REFOCCUPATION$", RefGet.Term);
                        else
                            strHTML = strHTML.Replace("$REFOCCUPATION$", "NA");
                    }
                    strHTML = strHTML.Replace("$REFCOMPANYNAME$", RefInv.CompanyName == null ? "NA" : RefInv.CompanyName);
                    strHTML = strHTML.Replace("$REFDESIGNATION$", RefInv.Designation == null ? "NA" : RefInv.Designation);
                    strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                    SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), GetData.EMail, "Investor Registration", strHTML); 
                   
                     * */
                    #endregion OldCode
                }
                else
                    MessageBox.Show("Please set Company email configuration");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString() + " Once Send Email");
            }
        }

        /// <summary>
        /// Get Image Path
        /// </summary>
        /// <param name="path">Path as Object</param>
        /// <returns></returns>
        public string GetPath(object path)
        {
            if (path.ToString() != "")
                return "~/UploadPhoto/" + path;
            else
                return "~/UploadPhoto/BusinessCard.png";
        }

        private void BindInvestorData()
        {
            try
            {
                DataSet ds = ProspectsBLL.SearchInfo(null, null, null, null, null, null, this.CompanyID, this.ProspectID, null, null, null, null, null);
                ddlTitle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FName"]);
                txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LName"]);
                txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMail"]);

                if (Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]) != "")
                {
                    string mobileno = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);

                    string[] words = mobileno.Split('-');
                    if (words.Length > 1)
                    {
                        txtMobileCntCode.Text = Convert.ToString(words[0]);
                        txtMobileNo.Text = Convert.ToString(words[1]);
                    }
                    else
                    {
                        txtMobileCntCode.Text = Convert.ToString(words[0]);
                        txtMobileNo.Text = "";
                    }
                }
                else
                {
                    txtMobileCntCode.Text = "";
                    txtMobileNo.Text = "";
                }

                //txtMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);

                txtLandLineNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["LandlineNo"]);
                txtAddressLine1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Add1"]);
                txtCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
                txtPostCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["ZipCode"]);
                txtState.Text = Convert.ToString(ds.Tables[0].Rows[0]["StateName"]);
                txtCountry.Text = Convert.ToString(ds.Tables[0].Rows[0]["CountryName"]);

                //ddlManagerType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ManagerType"]);
                ddlManagerType.SelectedIndex = ddlManagerType.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["ManagerType"])) != null ? ddlManagerType.Items.IndexOf(ddlManagerType.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["ManagerType"]))) : 0;
                ddlManagerType_SelectedIndexChanged(null, null);
                //ddlRelationManagementID.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RelationShipManagerID"]);
                ddlRelationManagementID.SelectedIndex = ddlRelationManagementID.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["RelationShipManagerID"])) != null ? ddlRelationManagementID.Items.IndexOf(ddlRelationManagementID.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["RelationShipManagerID"]))) : 0;
                ddlRelationManagementID_SelectedIndexChanged(null, null);

                ddlManagerType.SelectedIndex = ddlManagerType.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["ManagerType"])) != null ? ddlManagerType.Items.IndexOf(ddlManagerType.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["ManagerType"]))) : 0;

                //ddlOccupationTermID.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OccupationTermID"]);

                ddlEnteryRegion.SelectedIndex = ddlEnteryRegion.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["RegionTermID"])) != null ? ddlEnteryRegion.Items.IndexOf(ddlEnteryRegion.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["RegionTermID"]))) : 0;
                ddlReferenceThrow.SelectedIndex = ddlReferenceThrow.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["ReferenceTermID"])) != null ? ddlReferenceThrow.Items.IndexOf(ddlReferenceThrow.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["ReferenceTermID"]))) : 0;
                txtRefrence.Text = Convert.ToString(ds.Tables[0].Rows[0]["Reference"]);

                ddlOccupationTermID.SelectedIndex = ddlOccupationTermID.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["OccupationTermID"])) != null ? ddlOccupationTermID.Items.IndexOf(ddlOccupationTermID.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["OccupationTermID"]))) : 0;
                txtCompanyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);

                if (ds.Tables[0].Rows[0]["Thumb"].ToString().ToUpper().ToString().Trim() != "BUSINESSCARD.PNG")
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/" + Convert.ToString(ds.Tables[0].Rows[0]["Thumb"]);
                    //HypRemove.Visible = Convert.ToBoolean(ViewState["Edit"]);
                    HypRemove.Visible = false;
                }
                else
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    HypRemove.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Investor Data
        /// </summary>
        private void LoadInvData()
        {
            ViewState["InvestorID"] = Session["InvID"];
            LoadInvestorData();
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                BindDDL();

                //as per discussion with vijay.
                ////BindInverstorGrid();
                grdInvestorList.Visible = false;

                HypRemove.Visible = false;                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Validation Information Here
        /// </summary>
        private void LoadValidationInfo()
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
        /// Clear Control Value
        /// </summary>
        private void ClearControlValue()
        {
            txtNameOfFirm.Text = "";
            txtManagerEmail.Text = "";
            txtManagerContactNo.Text = "";
            txtPrimeEmail.Text = txtRefrence.Text = "";
            trFirmName.Visible = true;
            txtFirstName.Text = txtLastName.Text = txtEmail.Text = hfOldEmial.Value = txtMobileNo.Text = txtLandLineNo.Text = txtAddressLine1.Text = txtMobileCntCode.Text = "";

            txtCity.Text = txtState.Text = txtCountry.Text = txtPostCode.Text = txtCAddress1.Text = txtRelationalName.Text = txtContactPersonName.Text = txtContactPersonEmail.Text = txtContactPersonMobile.Text = txtCCity.Text = txtCState.Text = txtCCountry.Text = txtCPostCode.Text = txtPANNo.Text = txtPOAHolder.Text = txtBankName.Text = txtBankAccNo.Text = txtBankAcctHolderName.Text = txtCompanyName.Text = txtDesignation.Text = "";

            //chkIsSMS.Checked = true;
            //chkIsEmail.Checked = true;

            txtPrimeMobileNo.Text = txtRefFirstName.Text = txtRefLastName.Text = txtRefEmail.Text = txtRefMobileNO.Text = txtRefMobileCntNo.Text = txtRefLandLineNo.Text = txtRefAddress1.Text = "";

            txtRefCity.Text = txtRefState.Text = txtRefCountry.Text = txtRefPostCode.Text = txtRefCAddress1.Text = "";

            txtRefCCity.Text = txtRefCState.Text = txtRefCCountry.Text = txtRefCPostCode.Text = txtRefPANNo.Text = txtRefPOAHolder.Text = txtRefBankNo.Text = txtRefBankAccNo.Text = txtRefBankAcctHolderName.Text = txtRefCompanyName.Text = txtRefDesignation.Text = "";

            txt2JOAddress.Text = txt2JOBankAccountNo.Text = txt2JOBanckAcctHolderName.Text = txt2JOBankName.Text = txt2JOCity.Text = txt2JOCompanyName.Text = txt2JOCountry.Text = txt2JODesignation.Text = txt2JOEmail.Text = txt2JOFirstName.Text = txt2JOIFSCCode.Text = txt2JOLandlineNo.Text = txt2JOLastName.Text = txt2JOMobilecode.Text = txt2JOMobileNo.Text = txt2JOPanNo.Text = txt2JOPOAHolder.Text = txt2JOPostalAddress.Text = txt2JOPostalCity.Text = txt2JOPostalCountry.Text = txt2JOPostalState.Text = txt2JOPostalZipCode.Text = txt2JOState.Text = txt2JOZipCode.Text = "";
            ddl2JOOccupation.SelectedIndex = ddl2JOTitle.SelectedIndex = 0;
            ddlDay.SelectedIndex = ddlMonth.SelectedIndex = ddlYear.SelectedIndex = 0;
            ddlRefDay.SelectedIndex = ddlRefMonth.SelectedIndex = ddlRefYear.SelectedIndex = 0;
            ddl2JODay.SelectedIndex = ddl2JOMonth.SelectedIndex = ddl2JOYear.SelectedIndex = 0;

            ddlTitle.Focus();

            ddlReferenceThrow.SelectedIndex = ddlEnteryRegion.SelectedIndex = 0;
            chkRefAsAbove.Checked = chkSameasFirstOwner.Checked = chk.Checked = false;
            //tbWingFloor.ActiveTabIndex = 0;
            BindDDL();

            //as per discussion with vijay.
            ////BindInverstorGrid();
            grdInvestorList.Visible = false;

            ViewState["InvestorID"] = null;
            this.UserID = Guid.Empty;

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
        private void LoadRegion()
        {
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
        private void BindDDL()
        {            
            LoadValidationInfo();
            LoadTitle(ddlTitle);
            ddlTitle.SelectedValue = Guid.Empty.ToString();
            LoadTitle(dllRefTitle);
            dllRefTitle.SelectedValue = Guid.Empty.ToString();
            LoadTitle(ddl2JOTitle);
            ddl2JOTitle.SelectedValue = Guid.Empty.ToString();

            LoadOccupation(ddlOccupationTermID);
            ddlOccupationTermID.SelectedValue = Guid.Empty.ToString();
            LoadOccupation(ddlRefOccupation);
            ddlRefOccupation.SelectedValue = Guid.Empty.ToString();
            LoadOccupation(ddl2JOOccupation);
            ddl2JOOccupation.SelectedValue = Guid.Empty.ToString();

            LoadManagerType(ddlManagerType, true);
            LoadEmployee();
            LoadSManagerType();
            LoadRegion();
            LoadReferenceTerm();
            string strManagerType = Convert.ToString(Session["InvUserType"]);
            if (strManagerType.ToUpper() != "ADMIN")
            {
                ddlManagerType.SelectedIndex = ddlManagerType.Items.FindByValue(Convert.ToString(Session["InvUserType"])) != null ? ddlManagerType.Items.IndexOf(ddlManagerType.Items.FindByValue(Convert.ToString(Session["InvUserType"]))) : 0;
            }

            ddlManagerType_SelectedIndexChanged(null, null);
            
            if (strManagerType.ToUpper() != "ADMIN")
            {
                ddlSManagerType.SelectedIndex = ddlSManagerType.Items.FindByValue(Convert.ToString(Session["InvUserType"])) != null ? ddlSManagerType.Items.IndexOf(ddlSManagerType.Items.FindByValue(Convert.ToString(Session["InvUserType"]))) : 0;
            }

            ddlSManagerType_SelectedIndexChanged(null, null);
            if (strManagerType.ToUpper() != "ADMIN")
            {
                ddlSManager.SelectedIndex = ddlSManager.Items.FindByValue(Convert.ToString(Session["UserTypeID"])) != null ? ddlSManager.Items.IndexOf(ddlSManager.Items.FindByValue(Convert.ToString(Session["UserTypeID"]))) : 0;
            }
        }

        private void BindCoOrdinator()
        {
            Guid? investorID = null;

            //this.ProspectID == Guid.Empty means prospect is not going to convert into investor
            if (this.ProspectID == Guid.Empty)
            {
                // Investor is in edit mode, so don't bind current investor as CoOrdinator.
                investorID = new Guid(Convert.ToString(Session["InvID"]));
            }

            DataSet dsCoOrdinators = InvestorBLL.GetCoOrdinators("ALLCOORDINATORS", investorID);
            if (dsCoOrdinators != null && dsCoOrdinators.Tables.Count > 0 && dsCoOrdinators.Tables[0].Rows.Count > 0)
            {
                ddlCoOrdinatorInvestor.DataSource = dsCoOrdinators.Tables[0];
                ddlCoOrdinatorInvestor.DataTextField = "InvestorName";
                ddlCoOrdinatorInvestor.DataValueField = "InvestorID";
                ddlCoOrdinatorInvestor.DataBind();
                ddlCoOrdinatorInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlCoOrdinatorInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        private void BindBirthDateDDLs()
        {
            ddlDay.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            ddlRefDay.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            ddl2JODay.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));

            for (int i = 1; i < 32; i++)
            {
                if (i < 10)
                {
                    ddlDay.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                    ddlRefDay.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                    ddl2JODay.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlDay.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                    ddlRefDay.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                    ddl2JODay.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }
            }

            ddlYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            ddlRefYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            ddl2JOYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            int j = 1;
            for (int i = DateTime.Now.Year; i >= 1940; i--)
            {
                ddlYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                ddlRefYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                ddl2JOYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                j++;
            }
        }

        private void LoadSManagerType()
        {
            ddlSManagerType.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "MANAGERTYPE";
            TitleTerm.IsActive = true;
            TitleTerm.CompanyID = this.CompanyID;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlSManagerType.DataSource = Lst;
                ddlSManagerType.DataTextField = "DisplayTerm";
                ddlSManagerType.DataValueField = "Term";
                ddlSManagerType.DataBind();
                ddlSManagerType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlSManagerType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            ddlSManager.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Load Title Here
        /// </summary>
        /// <param name="ddl">ddl as DropDownList</param>
        private void LoadManagerType(DropDownList ddl, bool IsEntry)
        {
            ddl.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "MANAGERTYPE";
            TitleTerm.IsActive = true;
            TitleTerm.CompanyID = this.CompanyID;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddl.DataSource = Lst;
                ddl.DataTextField = "DisplayTerm";
                ddl.DataValueField = "Term";
                ddl.DataBind();
                if (IsEntry == true)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
            else
            {
                if (IsEntry == true)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
            ddlRelationManagementID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Load Employee Here
        /// </summary>
        private void LoadEmployee()
        {
            ddlEmployee.Items.Clear();
            Employee Emp = new Employee();
            Emp.IsActive = true;
            Emp.CompanyID = this.CompanyID;
            //Emp.IsSales = false;
            List<Employee> LstEmp = EmployeeBLL.GetAll(Emp);
            if (LstEmp.Count > 0)
            {
                LstEmp.Sort((Employee r1, Employee r2) => r1.FullName.CompareTo(r2.FullName));
                ddlEmployee.DataSource = LstEmp;
                ddlEmployee.DataTextField = "FullName";
                ddlEmployee.DataValueField = "EmployeeID";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlEmployee.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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
            TitleTerm.CompanyID = this.CompanyID;
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
        private void BindInverstorGrid()
        {
            grdInvestorList.Visible = true;
            string FullName = null;
            Guid? RelationShipManagerID;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN")
            {
                if (ddlSManager.SelectedValue != Guid.Empty.ToString())
                    RelationShipManagerID = new Guid(ddlSManager.SelectedValue.ToString());
                else
                    RelationShipManagerID = null;
            }
            else
            {
                RelationShipManagerID = new Guid(Convert.ToString(Session["UserTypeID"]));

            }
            if (!txtSTermName.Text.Trim().Equals(""))
                FullName = txtSTermName.Text;
            else
                FullName = null;

            DataSet Dst = InvestorBLL.SearchInfo(null, null, null, FullName, null, this.CompanyID, RelationShipManagerID, null);
            DataView Dv = new DataView(Dst.Tables[0]);
            grdInvestorList.DataSource = Dv;
            grdInvestorList.DataBind();
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
        /// Save Up Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveUp_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }
        /// <summary>
        /// Add New Investor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControlValue();
            hdnUploadPhoto.Value = "";
            imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
            HypRemove.Visible = false;
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("InvID");
            Session.Remove("ProspectID");
            Response.Redirect("~/Applications/Investors/InvestorList.aspx");
            //ClearControlValue();
            ////ddlManagerType.SelectedIndex = 0;

            //Session["InvID"] = null;
            //Response.Redirect("~/Applications/Investors/InvestorList.aspx");
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
                    //Check Date of Brith's Validation
                    string strInvalidDateOf = CheckDateOfBirthsValidation();
                    if (strInvalidDateOf != "")
                    {
                        if (strInvalidDateOf.ToUpper() == "FIRSTOWNER")
                            lblMsgDateValidate.Text = "Invalid Date of Birth of First Owner.";
                        else if (strInvalidDateOf.ToUpper() == "JOINTOWNER")
                            lblMsgDateValidate.Text = "Invalid Date of Birth of Joint Owner.";
                        else if (strInvalidDateOf.ToUpper() == "2NDJOINTOWNER")
                            lblMsgDateValidate.Text = "Invalid Date of Birth of 2nd Joint Owner.";

                        return;
                    }

                    if (!txtEmail.Text.Trim().Equals(""))
                    {
                        User IsDup = new User();
                        IsDup.UserName = txtEmail.Text.Trim();

                        List<User> LstDupWing = UserBLL.GetAll(IsDup);
                        if (LstDupWing.Count > 0)
                        {
                            if (ViewState["InvestorID"] != null)
                            {
                                if (LstDupWing[0].UsearID != new Guid(Convert.ToString(this.UserID)))
                                {
                                    IsInsert = true;
                                    lblInvestorMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                    return;
                                }
                            }
                            else
                            {
                                IsInsert = true;
                                lblInvestorMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                    }

                    if (ViewState["InvestorID"] != null)
                    {
                        //Update Investor
                        Investor ChkIns = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvestorID"].ToString()));

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

                        if (!ChkIns.EMail.Equals(txtEmail.Text.Trim()) && !(txtEmail.Text.Trim().Equals("")))
                        {
                            EmailNotification.Show();
                        }
                        else
                        {
                            UpdateInvestor();
                        }
                    }
                    else
                    {
                        //Insert Inversor
                        string FullName = "";
                        FullName = ddlTitle.SelectedValue.ToString() + " " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
                        Investor Ins = new Investor();
                        SQT.Symphony.BusinessLogic.Configuration.DTO.User Usr = new User();
                        Usr.UsearID = Guid.NewGuid();
                        Ins.IsSMS = true;
                        Ins.IsEmail = true;
                        Ins.Title = ddlTitle.SelectedValue.ToString();
                        Ins.FName = txtFirstName.Text.Trim();
                        Ins.LName = txtLastName.Text.Trim();
                        Ins.EMail = txtEmail.Text.Trim();

                        if (ddlCoOrdinatorInvestor.SelectedIndex != 0)
                            Ins.CoOrdinatorInvestorID = new Guid(ddlCoOrdinatorInvestor.SelectedValue);
                        else
                            Ins.CoOrdinatorInvestorID = null;

                        if (txtMobileCntCode.Text.Trim().Equals(""))
                            Ins.MobileNo = "-" + txtMobileNo.Text.Trim();
                        else
                            Ins.MobileNo = txtMobileCntCode.Text.Trim() + "-" + txtMobileNo.Text.Trim();

                        Ins.LandLineNo = txtLandLineNo.Text.Trim();

                        //if (txtAge.Text.Trim() != "")
                        //    Ins.Age = Convert.ToInt32(txtAge.Text.Trim());

                        Ins.PanNo = txtPANNo.Text.Equals("") ? null : txtPANNo.Text.Trim();
                        Ins.POAHolder = txtPOAHolder.Text.Trim().Equals("") ? null : txtPOAHolder.Text.Trim();
                        Ins.BankName = txtBankName.Text.Trim().Equals("") ? null : txtBankName.Text.Trim();
                        Ins.AccountNo = txtBankAccNo.Text.Trim().Equals("") ? null : txtBankAccNo.Text.Trim();
                        Ins.BankAcctName = txtBankAcctHolderName.Text.Trim().Equals("") ? null : txtBankAcctHolderName.Text.Trim();
                        if (ddlOccupationTermID.SelectedValue != Guid.Empty.ToString())
                            Ins.OccupationTermID = new Guid(ddlOccupationTermID.SelectedValue);
                        else
                            Ins.OccupationTermID = null;
                        Ins.CompanyName = txtCompanyName.Text.Equals("") ? null : txtCompanyName.Text.Trim();
                        Ins.Designation = txtDesignation.Text.Equals("") ? null : txtDesignation.Text.Trim();
                        if (ddlRelationManagementID.SelectedValue != Guid.Empty.ToString())
                            Ins.RelationShipManagerID = new Guid(ddlRelationManagementID.SelectedValue);
                        else
                            Ins.RelationShipManagerID = null;
                        if (ddlManagerType.SelectedValue != Guid.Empty.ToString())
                            Ins.ManagerType = ddlManagerType.SelectedValue;
                        else
                            Ins.ManagerType = null;
                        Ins.NameOfFirm = txtNameOfFirm.Text.Trim().Equals("") ? null : txtNameOfFirm.Text.Trim();
                        Ins.ManagerContactNo = txtManagerContactNo.Text.Trim().Equals("") ? null : txtManagerContactNo.Text.Trim();
                        Ins.ManagerEmail = txtManagerEmail.Text.Trim().Equals("") ? null : txtManagerEmail.Text.Trim();
                        Ins.PrimeMobileNo = txtPrimeMobileNo.Text.Trim().Equals("") ? null : txtPrimeMobileNo.Text.Trim();
                        Ins.PrimeEmail = txtPrimeEmail.Text.Trim().Equals("") ? null : txtPrimeEmail.Text.Trim();
                        Ins.UniworldPrime = ddlEmployee.SelectedValue.Equals(Guid.Empty.ToString()) ? null : ddlEmployee.SelectedValue.ToString();
                        Ins.CompanyID = this.CompanyID;
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.IsActive = true;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.RelationalName = txtRelationalName.Text.Trim();
                        Ins.ContactPersonName = txtContactPersonName.Text.Trim();
                        Ins.ContactPersonEmail = txtContactPersonEmail.Text.Trim();
                        Ins.ContactPersonMobile = txtContactPersonMobile.Text.Trim();

                        Ins.Reference = txtRefrence.Text.Equals("") ? null : txtRefrence.Text.Trim();
                        if (ddlReferenceThrow.SelectedValue != Guid.Empty.ToString())
                            Ins.ReferenceTermID = new Guid(Convert.ToString(ddlReferenceThrow.SelectedValue));
                        else
                            Ins.ReferenceTermID = null;

                        if (ddlEnteryRegion.SelectedValue != Guid.Empty.ToString())
                            Ins.RegionTermID = new Guid(Convert.ToString(ddlEnteryRegion.SelectedValue));
                        else
                            Ins.RegionTermID = null;

                        Ins.UserID = Usr.UsearID;

                        Ins.IFSCCode = Convert.ToString(txtIFSCCode.Text.Trim());

                        if (ddlDay.SelectedIndex != 0 || ddlMonth.SelectedIndex != 0 || ddlYear.SelectedIndex != 0)
                        {
                            string DateOfBirth = Convert.ToString(ddlDay.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
                            Ins.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                        }
                        else
                            Ins.DateOfBirth = null;

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
                        {
                            if (this.ProspectID != Guid.Empty)
                            {
                                Prospects GetProspectDate = ProspectsBLL.GetByPrimaryKey(this.ProspectID);
                                if (GetProspectDate != null)
                                    Ins.Thumb = GetProspectDate.Thumb;
                                else
                                    Ins.Thumb = "BusinessCard.png";
                            }
                            else
                                Ins.Thumb = "BusinessCard.png";
                        }

                        //Current Adderss Investor

                        Address InvCAddress = new Address();

                        InvCAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
                        InvCAddress.StateID = clsCommon.State(txtState.Text.Trim());
                        InvCAddress.CityID = clsCommon.City(txtCity.Text.Trim());

                        InvCAddress.Add1 = txtAddressLine1.Text.Trim();
                        //InvCAddress.Add2 = txtAddressLine2.Text;
                        InvCAddress.ZipCode = txtPostCode.Text.Trim();
                        InvCAddress.IsActive = true;
                        InvCAddress.CompanyID = this.CompanyID;

                        //Present Address Investor
                        Address InvPAddress = new Address();
                        InvPAddress.CountryID = clsCommon.Country(txtCCountry.Text.Trim());
                        InvPAddress.StateID = clsCommon.State(txtCState.Text.Trim());
                        InvPAddress.CityID = clsCommon.City(txtCCity.Text.Trim());

                        InvPAddress.Add1 = txtCAddress1.Text.Trim();
                        //InvPAddress.Add2 = txtCAddress2.Text;
                        InvPAddress.ZipCode = txtCPostCode.Text.Trim();
                        InvPAddress.IsActive = true;
                        InvPAddress.CompanyID = this.CompanyID;

                        Usr.UserName = Ins.EMail;
                        Usr.UserDisplayName = Ins.FName + " " + Ins.LName;
                        Usr.Password = Guid.NewGuid().ToString().Substring(0, 8).ToString();
                        Usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        Usr.CraetedOn = DateTime.Now.Date;
                        Usr.IsActive = false;
                        Usr.CompanyID = this.CompanyID;
                        Usr.UserType = "Investor";
                        Usr.IsBlock = false;
                        Usr.DisplayAvtar = Ins.Thumb;
                        Usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                        InvestorBLL.SaveWithUserID(Ins, InvCAddress, InvPAddress, Usr);


                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "irm_Investor");

                        //Update Prospect
                        if (this.ProspectID != Guid.Empty)
                        {
                            Prospects objUpdateProspect = new Prospects();
                            objUpdateProspect = ProspectsBLL.GetByPrimaryKey(this.ProspectID);
                            objUpdateProspect.InvestorID = Ins.InvestorID;
                            objUpdateProspect.IsActive = false;
                            ProspectsBLL.Update(objUpdateProspect);
                        }
                        //Ref Investor
                        Investor RefIns = new Investor();
                        RefIns.Title = dllRefTitle.SelectedValue.ToString() == Guid.Empty.ToString() ? null : dllRefTitle.SelectedValue.ToString();
                        RefIns.FName = txtRefFirstName.Text.Trim();
                        RefIns.LName = txtRefLastName.Text.Trim();
                        RefIns.EMail = txtRefEmail.Text;
                        RefIns.CompanyID = this.CompanyID;

                        if (txtRefMobileCntNo.Text.Trim().Equals(""))
                            RefIns.MobileNo = "-" + txtRefMobileNO.Text.Trim();
                        else
                            RefIns.MobileNo = txtRefMobileCntNo.Text.Trim() + "-" + txtRefMobileNO.Text.Trim();


                        RefIns.LandLineNo = txtRefMobileNO.Text.Trim();

                        //if (txtRefAge.Text.Trim() != "")
                        //    RefIns.Age = Convert.ToInt32(txtRefAge.Text.Trim());
                        RefIns.PanNo = txtRefPANNo.Text.Trim().Equals("") ? null : txtRefPANNo.Text.Trim();
                        RefIns.POAHolder = txtRefPOAHolder.Text.Trim().Equals("") ? null : txtRefPOAHolder.Text.Trim();
                        RefIns.BankName = txtRefBankNo.Text.Trim().Trim().Equals("") ? null : txtRefBankNo.Text.Trim();
                        RefIns.AccountNo = txtRefBankAccNo.Text.Trim().Equals("") ? null : txtRefBankAccNo.Text.Trim();
                        RefIns.BankAcctName = txtRefBankAcctHolderName.Text.Trim().Equals("") ? null : txtRefBankAcctHolderName.Text.Trim();
                        if (ddlRefOccupation.SelectedValue != Guid.Empty.ToString())
                            RefIns.OccupationTermID = new Guid(ddlRefOccupation.SelectedValue);
                        else
                            RefIns.OccupationTermID = null;
                        RefIns.CompanyName = txtRefCompanyName.Text.Trim().Equals("") ? null : txtRefCompanyName.Text.Trim();
                        RefIns.Designation = txtRefDesignation.Text.Trim().Equals("") ? null : txtRefDesignation.Text.Trim();
                        RefIns.CreatedOn = DateTime.Now.Date;
                        RefIns.IsActive = true;
                        RefIns.UpdatedOn = DateTime.Now.Date;
                        RefIns.RefInverstorID = Ins.InvestorID;

                        RefIns.IFSCCode = Convert.ToString(txtRefIFSCCode.Text.Trim());

                        if (ddlRefDay.SelectedIndex != 0 || ddlRefMonth.SelectedIndex != 0 || ddlRefYear.SelectedIndex != 0)
                        {
                            string DateOfBirth = Convert.ToString(ddlRefDay.SelectedValue.ToString().Trim() + "-" + ddlRefMonth.SelectedItem.Text.Trim() + "-" + ddlRefYear.SelectedValue.ToString().Trim());
                            RefIns.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                        }
                        else
                            RefIns.DateOfBirth = null;

                        //Ref Investor Current Adderss Investor
                        Address RefInvCAddress = new Address();

                        RefInvCAddress.Add1 = txtRefAddress1.Text.Trim();
                        //RefInvCAddress.Add2 = txtRefAddress2.Text;
                        RefInvCAddress.ZipCode = txtRefPostCode.Text.Trim();
                        RefInvCAddress.IsActive = true;
                        RefInvCAddress.CompanyID = this.CompanyID;
                        RefInvCAddress.CountryID = clsCommon.Country(txtRefCountry.Text.Trim());
                        RefInvCAddress.StateID = clsCommon.State(txtRefState.Text.Trim());
                        RefInvCAddress.CityID = clsCommon.City(txtRefCity.Text.Trim());

                        //Present Address Investor
                        Address RefInvPAddress = new Address();
                        RefInvPAddress.CountryID = clsCommon.Country(txtRefCCountry.Text.Trim());
                        RefInvPAddress.StateID = clsCommon.State(txtRefCState.Text.Trim());
                        RefInvPAddress.CityID = clsCommon.City(txtRefCCity.Text.Trim());


                        RefInvPAddress.Add1 = txtRefCAddress1.Text.Trim();
                        //RefInvPAddress.Add2 = txtRefAddress2.Text;
                        RefInvPAddress.ZipCode = txtRefCPostCode.Text.Trim();
                        RefInvPAddress.IsActive = true;
                        RefInvPAddress.CompanyID = this.CompanyID;

                        InvestorBLL.Save(RefIns, RefInvCAddress, RefInvPAddress);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", RefIns.ToString(), RefIns.ToString(), "irm_Investor");


                        // 2nd Joint Owner
                        Investor secondRefInv = new Investor();

                        secondRefInv.Title = ddl2JOTitle.SelectedValue.ToString() == Guid.Empty.ToString() ? null : ddl2JOTitle.SelectedValue.ToString();
                        secondRefInv.FName = txt2JOFirstName.Text.Trim();
                        secondRefInv.LName = txt2JOLastName.Text.Trim();
                        secondRefInv.EMail = txt2JOEmail.Text;
                        secondRefInv.CompanyID = this.CompanyID;

                        if (txt2JOMobilecode.Text.Trim().Equals(""))
                            secondRefInv.MobileNo = "-" + txt2JOMobileNo.Text.Trim();
                        else
                            secondRefInv.MobileNo = txt2JOMobilecode.Text.Trim() + "-" + txt2JOMobileNo.Text.Trim();

                        secondRefInv.LandLineNo = txt2JOLandlineNo.Text.Trim();

                        //if (txt2JOAge.Text.Trim() != "")
                        //    secondRefInv.Age = Convert.ToInt32(txt2JOAge.Text.Trim());

                        secondRefInv.PanNo = txt2JOPanNo.Text.Trim().Equals("") ? null : txt2JOPanNo.Text.Trim();
                        secondRefInv.POAHolder = txt2JOPOAHolder.Text.Trim().Equals("") ? null : txt2JOPOAHolder.Text.Trim();
                        secondRefInv.BankName = txt2JOBankName.Text.Trim().Trim().Equals("") ? null : txt2JOBankName.Text.Trim();
                        secondRefInv.AccountNo = txt2JOBankAccountNo.Text.Trim().Equals("") ? null : txt2JOBankAccountNo.Text.Trim();
                        secondRefInv.AccountNo = txt2JOBanckAcctHolderName.Text.Trim().Equals("") ? null : txt2JOBanckAcctHolderName.Text.Trim();
                        
                        if (ddl2JOOccupation.SelectedValue != Guid.Empty.ToString())
                            secondRefInv.OccupationTermID = new Guid(ddl2JOOccupation.SelectedValue);
                        else
                            secondRefInv.OccupationTermID = null;

                        secondRefInv.CompanyName = txt2JOCompanyName.Text.Trim().Equals("") ? null : txt2JOCompanyName.Text.Trim();
                        secondRefInv.Designation = txt2JODesignation.Text.Trim().Equals("") ? null : txt2JODesignation.Text.Trim();
                        secondRefInv.CreatedOn = DateTime.Now.Date;
                        secondRefInv.IsActive = true;
                        secondRefInv.UpdatedOn = DateTime.Now.Date;
                        secondRefInv.RefInverstorID = Ins.InvestorID;

                        secondRefInv.IFSCCode = Convert.ToString(txt2JOIFSCCode.Text.Trim());

                        if (ddl2JODay.SelectedIndex != 0 || ddl2JOMonth.SelectedIndex != 0 || ddl2JOYear.SelectedIndex != 0)
                        {
                            string DateOfBirth = Convert.ToString(ddl2JODay.SelectedValue.ToString().Trim() + "-" + ddl2JOMonth.SelectedItem.Text.Trim() + "-" + ddl2JOYear.SelectedValue.ToString().Trim());
                            secondRefInv.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                        }
                        else
                            secondRefInv.DateOfBirth = null;

                        // Agreement Address

                        Address SecRefInvAgreAdd = new Address();

                        SecRefInvAgreAdd.Add1 = txt2JOAddress.Text.Trim();
                        SecRefInvAgreAdd.ZipCode = txt2JOZipCode.Text.Trim();
                        SecRefInvAgreAdd.IsActive = true;
                        SecRefInvAgreAdd.CompanyID = this.CompanyID;
                        SecRefInvAgreAdd.CountryID = clsCommon.Country(txt2JOCountry.Text.Trim());
                        SecRefInvAgreAdd.StateID = clsCommon.State(txt2JOState.Text.Trim());
                        SecRefInvAgreAdd.CityID = clsCommon.City(txt2JOCity.Text.Trim());

                        // Postal Address

                        Address SecRefInvPosAdd = new Address();
                        SecRefInvPosAdd.CountryID = clsCommon.Country(txt2JOPostalCountry.Text.Trim());
                        SecRefInvPosAdd.StateID = clsCommon.State(txt2JOPostalState.Text.Trim());
                        SecRefInvPosAdd.CityID = clsCommon.City(txt2JOPostalCity.Text.Trim());
                        SecRefInvPosAdd.Add1 = txt2JOPostalAddress.Text.Trim();
                        SecRefInvPosAdd.ZipCode = txt2JOPostalZipCode.Text.Trim();
                        SecRefInvPosAdd.IsActive = true;
                        SecRefInvPosAdd.CompanyID = this.CompanyID;

                        InvestorBLL.Save(secondRefInv, SecRefInvAgreAdd, SecRefInvPosAdd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", secondRefInv.ToString(), secondRefInv.ToString(), "irm_Investor");

                        ////Don't send email to investor because investor will be activated by Admin once his/her information will be filled up on server.
                        //if (!txtEmail.Text.Equals(""))
                        //{
                        //    //Temp
                        //    ////SendEmail(Ins.InvestorID, Usr.Password, FullName, Usr.UsearID, Usr.PasswordKey);
                        //}

                        IsInsert = true;
                        lblInvestorMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();

                        Session.Add("InvID", Ins.InvestorID.ToString());
                        Response.Redirect("~/Applications/Investors/InvestorSetUp.aspx?Val=True&IsConvert=1");
                        //LoadInvData();
                        //BindInverstorGrid();
                    }

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Remove Image Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HypRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["InvestorID"] != null)
                {
                    Investor GetImg = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvestorID"].ToString()));
                    if (GetImg != null && GetImg.Thumb.ToString().ToUpper() != "BUSINESSCARD.PNG")
                    {
                        string DeletePath = Server.MapPath("~/UploadPhoto/") + Convert.ToString(GetImg.Thumb);
                        File.Delete(DeletePath);
                        GetImg.Thumb = "BusinessCard.png";
                        InvestorBLL.Update(GetImg);
                        IsInsert = true;
                        lblInvestorMsg.Text = global::Resources.IRMSMsg.RemovePhotoMsg.ToString().Trim();
                        imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    }
                    else
                        imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    HypRemove.Visible = false;
                }
                else
                {
                    MessageBox.Show("Select Investor Team Information From The List");
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
                //IsEmail = true;
                BindInverstorGrid();
                if (Session["InvID"] != null)
                {
                    LoadInvData();
                    LoadAccess();
                }
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
            ////try
            ////{
            ////    if (this.UserID != Guid.Empty && ViewState["InvestorID"] != null)
            ////    {
            ////        User objUser = new User();
            ////        objUser = UserBLL.GetByPrimaryKey(this.UserID);
            ////        if (objUser != null)
            ////        {
            ////            if (objUser.UserName != null)
            ////            {
            ////                if (!objUser.UserName.Equals(""))
            ////                {
            ////                    lnkReSendEmail.Visible = true;
            ////                    IsEmail = true;
            ////                    IsInsert = true;
            ////                    lblInvestorMsg.Text = global::Resources.IRMSMsg.lblEmailSendMsg.ToString().Trim();
            ////                    lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
            ////                    SendEmail(new Guid(Convert.ToString(ViewState["InvestorID"])), objUser.Password, objUser.UserDisplayName, objUser.UsearID, objUser.PasswordKey);
            ////                }
            ////                else
            ////                    IsEmail = true;
            ////            }
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

        #region Popup Button
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            if (ViewState["InvestorID"] != null)
            {
                Investor GetData = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvestorID"].ToString()));
                InvestorBLL.Delete(new Guid(Convert.ToString(ViewState["InvestorID"])));
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetData.ToString(), null, "irm_Investor");
                IsInsert = true;
                this.UserID = Guid.Empty;
                lblInvestorMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                if (Convert.ToString(ViewState["InvestorID"]) == Convert.ToString(Session["InvID"]))
                {
                    ViewState["InvestorID"] = null;
                    Session["InvID"] = null;
                    Response.Redirect("~/Applications/Investors/InvestorList.aspx");
                }
                ViewState["InvestorID"] = null;
                ClearControlValue();
                BindInverstorGrid();
                hdnUploadPhoto.Value = "";
                imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                HypRemove.Visible = false;
            }
            msgbx.Hide();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            ViewState["InvestorID"] = null;
            this.UserID = Guid.Empty;
            msgbx.Hide();
        }
        #endregion Popup Button

        #region Grid Event
        /// <summary>
        /// Data Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        protected void ddlManagerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManagerData();
        }
        private void LoadManagerData()
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
        protected void ddlRelationManagementID_SelectedIndexChanged(object sender, EventArgs e)
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
                                    txtManagerContactNo.Text = Convert.ToString(cp.MobileNo.Replace("-", ""));
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
                }
                else if (ddlManagerType.Text.Equals("Employee"))
                {
                    Employee emp = EmployeeBLL.GetByPrimaryKey(new Guid(ddlRelationManagementID.SelectedValue));
                    txtNameOfFirm.Text = "";
                    txtManagerContactNo.Text = "";
                    txtManagerEmail.Text = emp.Email;
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
                                    txtManagerContactNo.Text = Convert.ToString(st.MobileNo.Replace("-", ""));
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
                }
                else
                    txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
            }
            else
            {
                txtNameOfFirm.Text = txtManagerContactNo.Text = txtManagerEmail.Text = "";
            }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployee.SelectedValue != Guid.Empty.ToString())
            {
                Employee emp = EmployeeBLL.GetByPrimaryKey(new Guid(ddlEmployee.SelectedValue.ToString()));
                if (emp != null)
                {
                    if (Convert.ToString(emp.MobileNo) != "" && emp.MobileNo != null)
                    {
                        string[] words = emp.MobileNo.Split('-');
                        if (words.Length > 1)
                        {
                            if (Convert.ToString(words[0]) != "")
                                txtPrimeMobileNo.Text = Convert.ToString(emp.MobileNo);
                            else
                                txtPrimeMobileNo.Text = Convert.ToString(words[1]).Replace("-", "");
                        }
                        else
                            txtPrimeMobileNo.Text = Convert.ToString(emp.MobileNo.ToString().Replace("-", ""));
                    }
                    else
                        txtPrimeMobileNo.Text = "";

                    //txtPrimeMobileNo.Text = emp.MobileNo;
                    txtPrimeEmail.Text = emp.Email;
                }
            }
            else
            {
                txtPrimeMobileNo.Text = txtPrimeEmail.Text = "";
            }
        }

        protected void grdInvestorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITCMD"))
                {
                    ViewState["InvestorID"] = e.CommandArgument.ToString();
                    Session["InvID"] = e.CommandArgument.ToString();
                    LoadInvestorData();
                    LoadAccess();
                }
                else if (e.CommandName.Equals("DELETECMD"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    ViewState["InvestorID"] = e.CommandArgument.ToString();
                    msgbx.Show();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadInvestorData()
        {
            try
            {
                Investor GetData = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvestorID"].ToString()));
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
                        {
                            ////Don't make visible resend email button, b'cas Investor can Activate/Decativate by Admin from other page.
                            lnkReSendEmail.Visible = Convert.ToBoolean(ViewState["Edit"]);
                        }

                        lblActivationMsg.Text = global::Resources.IRMSMsg.lblEmailMsg.ToString().Trim();
                    }
                }

                ddlTitle.SelectedValue = GetData.Title;
                txtFirstName.Text = GetData.FName;
                txtLastName.Text = GetData.LName;

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "scr", "<script language='javascript'>investors('" + ddlTitle.SelectedValue + " " + txtFirstName.Text + " " + txtLastName.Text + "');</script>", false);

                txtRelationalName.Text = GetData.RelationalName;
                txtContactPersonName.Text = GetData.ContactPersonName;
                txtContactPersonEmail.Text = GetData.ContactPersonEmail;
                txtContactPersonMobile.Text = GetData.ContactPersonMobile;
                //chkIsSMS.Checked = Convert.ToBoolean(GetData.IsSMS);
                //chkIsEmail.Checked = Convert.ToBoolean(GetData.IsEmail);
                hfOldEmial.Value = txtEmail.Text = GetData.EMail;
                ddlCoOrdinatorInvestor.SelectedIndex = ddlCoOrdinatorInvestor.Items.FindByValue(Convert.ToString(GetData.CoOrdinatorInvestorID)) != null ? ddlCoOrdinatorInvestor.Items.IndexOf(ddlCoOrdinatorInvestor.Items.FindByValue(Convert.ToString(GetData.CoOrdinatorInvestorID))) : 0;

                if (Convert.ToString(GetData.MobileNo) != "" && GetData.MobileNo != null)
                {
                    string[] words = GetData.MobileNo.Split('-');
                    if (words.Length > 1)
                    {
                        txtMobileCntCode.Text = Convert.ToString(words[0]);
                        txtMobileNo.Text = Convert.ToString(words[1]);
                    }
                    else
                    {
                        txtMobileCntCode.Text = Convert.ToString(words[0]);
                        txtMobileNo.Text = "";
                    }
                }
                else
                {
                    txtMobileCntCode.Text = "";
                    txtMobileNo.Text = "";
                }

                txtLandLineNo.Text = GetData.LandLineNo;

                //if (Convert.ToString(GetData.Age) != "" && GetData.Age != null)
                //    txtAge.Text = Convert.ToString(GetData.Age.Value);
                //else
                //    txtAge.Text = "";

                txtPANNo.Text = GetData.PanNo == null ? "" : GetData.PanNo;
                txtPOAHolder.Text = GetData.POAHolder == null ? "" : GetData.POAHolder;
                txtBankName.Text = GetData.BankName == null ? "" : GetData.BankName;
                txtBankAccNo.Text = GetData.AccountNo == null ? "" : GetData.AccountNo;
                txtBankAcctHolderName.Text = GetData.BankAcctName == null ? "" : GetData.BankAcctName;
                ddlOccupationTermID.SelectedIndex = ddlOccupationTermID.Items.FindByValue(Convert.ToString(GetData.OccupationTermID)) != null ? ddlOccupationTermID.Items.IndexOf(ddlOccupationTermID.Items.FindByValue(Convert.ToString(GetData.OccupationTermID))) : 0;
                txtCompanyName.Text = GetData.CompanyName;
                txtDesignation.Text = GetData.Designation;


                //txtPrimeMobileNo.Text = GetData.PrimeMobileNo == null ? "" : GetData.PrimeMobileNo;

                //if (Convert.ToString(GetData.ManagerType) != "")
                //    ddlManagerType.SelectedValue = GetData.ManagerType;

                ddlManagerType.SelectedIndex = ddlManagerType.Items.FindByValue(Convert.ToString(GetData.ManagerType)) != null ? ddlManagerType.Items.IndexOf(ddlManagerType.Items.FindByValue(Convert.ToString(GetData.ManagerType))) : 0;

                ddlManagerType_SelectedIndexChanged(null, null);


                ddlEnteryRegion.SelectedIndex = ddlEnteryRegion.Items.FindByValue(Convert.ToString(GetData.RegionTermID)) != null ? ddlEnteryRegion.Items.IndexOf(ddlEnteryRegion.Items.FindByValue(Convert.ToString(GetData.RegionTermID))) : 0;
                ddlReferenceThrow.SelectedIndex = ddlReferenceThrow.Items.FindByValue(Convert.ToString(GetData.ReferenceTermID)) != null ? ddlReferenceThrow.Items.IndexOf(ddlReferenceThrow.Items.FindByValue(Convert.ToString(GetData.ReferenceTermID))) : 0;
                txtRefrence.Text = Convert.ToString(GetData.Reference);


                //if (Convert.ToString(GetData.RelationShipManagerID) != "")
                //    ddlRelationManagementID.SelectedValue = Convert.ToString(GetData.RelationShipManagerID);

                ddlRelationManagementID.SelectedIndex = ddlRelationManagementID.Items.FindByValue(Convert.ToString(GetData.RelationShipManagerID)) != null ? ddlRelationManagementID.Items.IndexOf(ddlRelationManagementID.Items.FindByValue(Convert.ToString(GetData.RelationShipManagerID))) : 0;
                ddlRelationManagementID_SelectedIndexChanged(null, null);
                //txtNameOfFirm.Text = GetData.NameOfFirm == null ? "" : GetData.NameOfFirm;
                //txtManagerContactNo.Text = GetData.ManagerContactNo == null ? "" : GetData.ManagerContactNo;
                //txtManagerEmail.Text = GetData.ManagerEmail == null ? "" : GetData.ManagerEmail;

                txtIFSCCode.Text = Convert.ToString(GetData.IFSCCode);

                ddlDay.SelectedValue = GetData.DateOfBirth == null ? Guid.Empty.ToString() : GetData.DateOfBirth.Value.Day.ToString().Length == 2 ? GetData.DateOfBirth.Value.Day.ToString() : "0" + GetData.DateOfBirth.Value.Day.ToString();
                ddlMonth.SelectedValue = GetData.DateOfBirth == null ? Guid.Empty.ToString() : GetData.DateOfBirth.Value.Month.ToString();
                ddlYear.SelectedValue = GetData.DateOfBirth == null ? Guid.Empty.ToString() : GetData.DateOfBirth.Value.Year.ToString();

                ddlEmployee.SelectedIndex = ddlEmployee.Items.FindByValue(Convert.ToString(GetData.UniworldPrime)) != null ? ddlEmployee.Items.IndexOf(ddlEmployee.Items.FindByValue(Convert.ToString(GetData.UniworldPrime))) : 0;
                ddlEmployee_SelectedIndexChanged(null, null);
                if (GetData.UserID != null)
                    this.UserID = new Guid(Convert.ToString(GetData.UserID));
                //if (Convert.ToString(GetData.UniworldPrime) != "")
                //    ddlEmployee.SelectedValue = Convert.ToString(GetData.UniworldPrime);
                //else
                //    ddlEmployee.SelectedValue = Convert.ToString(Guid.Empty);
                //txtPrimeMobileNo.Text = GetData.PrimeMobileNo == null ? "" : GetData.PrimeMobileNo;
                //txtPrimeEmail.Text = GetData.PrimeEmail == null ? "" : GetData.PrimeEmail;
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


                Address GetAddC = AddressBLL.GetByPrimaryKey(new Guid(GetData.AgreementAddressID.Value.ToString()));
                if (GetAddC != null)
                {
                    txtAddressLine1.Text = Convert.ToString(GetAddC.Add1);
                    //txtAddressLine2.Text = GetAddC.Add2;
                    if (GetAddC.CityID != null)
                    {
                        City GetCt = CityBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddC.CityID)));
                        if (GetCt != null)
                            txtCity.Text = GetCt.CityName;
                        else
                            txtCity.Text = "";
                    }
                    else txtCity.Text = "";
                    if (GetAddC.StateID != null)
                    {
                        State GetSt = StateBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddC.StateID)));
                        if (GetSt != null)
                            txtState.Text = GetSt.StateName;
                        else
                            txtState.Text = "";
                    }
                    else txtState.Text = "";
                    if (GetAddC.CountryID != null)
                    {
                        Country Cnt = CountryBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddC.CountryID)));
                        if (Cnt != null)
                            txtCountry.Text = Cnt.CountryName;
                        else
                            txtCountry.Text = "";
                    }
                    else txtCountry.Text = "";

                    txtPostCode.Text = Convert.ToString(GetAddC.ZipCode);
                }
                else
                {
                    txtAddressLine1.Text = txtCity.Text = txtState.Text = txtCountry.Text = txtPostCode.Text = string.Empty;
                }

                Address GetAddP = AddressBLL.GetByPrimaryKey(new Guid(GetData.PostalAddressID.Value.ToString()));
                if (GetAddP != null)
                {
                    txtCAddress1.Text = Convert.ToString(GetAddP.Add1);
                    //txtCAddress2.Text = GetAddP.Add2;
                    if (GetAddP.CityID != null)
                    {
                        City GetPCt = CityBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddP.CityID)));
                        if (GetPCt != null)
                            txtCCity.Text = GetPCt.CityName;
                        else
                            txtCCity.Text = "";
                    }
                    else txtCCity.Text = "";
                    if (GetAddP.StateID != null)
                    {
                        State GetPSt = StateBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddP.StateID)));
                        if (GetPSt != null)
                            txtCState.Text = GetPSt.StateName;
                        else
                            txtCState.Text = "";
                    }
                    else txtCState.Text = "";
                    if (GetAddP.CountryID != null)
                    {
                        Country PCnt = CountryBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetAddP.CountryID)));
                        if (PCnt != null)
                            txtCCountry.Text = PCnt.CountryName;
                        else
                            txtCCountry.Text = "";
                    }
                    else txtCCountry.Text = "";

                    txtCPostCode.Text = Convert.ToString(GetAddP.ZipCode);
                }
                else
                {
                    txtCAddress1.Text = txtCCity.Text = txtCState.Text = txtCCountry.Text = txtCPostCode.Text = string.Empty;
                }

                List<Investor> LstRefGetData = InvestorBLL.GetAllBy(Investor.InvestorFields.RefInverstorID, ViewState["InvestorID"].ToString());
                //LstRefGetData.Sort((Investor i1, Investor i2) => i1.SeqNo.CompareTo(i2.SeqNo));
                LstRefGetData.Sort((Investor inv1, Investor inv2) => inv1.SeqNo.CompareTo(inv2.SeqNo));

                Investor RefGetData = (Investor)(LstRefGetData[0]);
                dllRefTitle.SelectedValue = RefGetData.Title;
                txtRefFirstName.Text = RefGetData.FName;
                txtRefLastName.Text = RefGetData.LName;
                txtRefEmail.Text = RefGetData.EMail;

                if (Convert.ToString(RefGetData.MobileNo) != "" && RefGetData.MobileNo != null)
                {
                    string[] Refwords = RefGetData.MobileNo.Split('-');
                    if (Refwords.Length > 1)
                    {
                        txtRefMobileCntNo.Text = Convert.ToString(Refwords[0]);
                        txtRefMobileNO.Text = Convert.ToString(Refwords[1]);
                    }
                    else
                    {
                        txtRefMobileCntNo.Text = Convert.ToString(Refwords[0]);
                        txtRefMobileNO.Text = "";
                    }
                }
                else
                {
                    txtRefMobileCntNo.Text = "";
                    txtRefMobileNO.Text = "";
                }

                txtRefLandLineNo.Text = RefGetData.LandLineNo;
                //if (Convert.ToString(RefGetData.Age) != "" && RefGetData.Age != null)
                //    txtRefAge.Text = Convert.ToString(RefGetData.Age);
                //else
                //    txtRefAge.Text = "";
                txtRefPANNo.Text = RefGetData.PanNo == null ? "" : RefGetData.PanNo;
                txtRefPOAHolder.Text = RefGetData.POAHolder == null ? "" : RefGetData.POAHolder;
                txtRefBankNo.Text = RefGetData.BankName == null ? "" : RefGetData.BankName;
                txtRefBankAccNo.Text = RefGetData.AccountNo == null ? "" : RefGetData.AccountNo;
                txtRefBankAcctHolderName.Text = RefGetData.BankAcctName == null ? "" : Convert.ToString(RefGetData.BankAcctName);
                if (Convert.ToString(RefGetData.OccupationTermID) != "")
                    ddlRefOccupation.SelectedValue = Convert.ToString(RefGetData.OccupationTermID);
                else
                    ddlRefOccupation.SelectedValue = Convert.ToString(Guid.Empty);
                txtRefCompanyName.Text = RefGetData.CompanyName;
                txtRefDesignation.Text = RefGetData.Designation;

                txtRefIFSCCode.Text = Convert.ToString(RefGetData.IFSCCode);

                ddlRefDay.SelectedValue = RefGetData.DateOfBirth == null ? Guid.Empty.ToString() : RefGetData.DateOfBirth.Value.Day.ToString().Length == 2 ? RefGetData.DateOfBirth.Value.Day.ToString() : "0" + RefGetData.DateOfBirth.Value.Day.ToString();
                ddlRefMonth.SelectedValue = RefGetData.DateOfBirth == null ? Guid.Empty.ToString() : RefGetData.DateOfBirth.Value.Month.ToString();
                ddlRefYear.SelectedValue = RefGetData.DateOfBirth == null ? Guid.Empty.ToString() : RefGetData.DateOfBirth.Value.Year.ToString();

                Address RefGetAddC = AddressBLL.GetByPrimaryKey(new Guid(RefGetData.AgreementAddressID.Value.ToString()));

                if (RefGetAddC != null)
                {
                    txtRefAddress1.Text = Convert.ToString(RefGetAddC.Add1);

                    if (RefGetAddC.CityID != null)
                    {
                        City RefGetCt = CityBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddC.CityID)));
                        if (RefGetCt != null)
                            txtRefCity.Text = RefGetCt.CityName;
                        else
                            txtRefCity.Text = "";
                    }
                    else txtRefCity.Text = "";
                    if (RefGetAddC.StateID != null)
                    {
                        State RefGetSt = StateBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddC.StateID)));
                        if (RefGetSt != null)
                            txtRefState.Text = RefGetSt.StateName;
                        else
                            txtRefState.Text = "";
                    }
                    else txtRefState.Text = "";
                    if (RefGetAddC.CountryID != null)
                    {
                        Country RefCnt = CountryBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddC.CountryID)));
                        if (RefCnt != null)
                            txtRefCountry.Text = RefCnt.CountryName;
                        else
                            txtRefCountry.Text = "";
                    }
                    else txtRefCountry.Text = "";

                    txtRefPostCode.Text = Convert.ToString(RefGetAddC.ZipCode);
                }
                else
                    txtRefAddress1.Text = txtRefCity.Text = txtRefState.Text = txtRefCountry.Text = txtRefPostCode.Text = string.Empty;

                Address RefGetAddP = AddressBLL.GetByPrimaryKey(new Guid(RefGetData.PostalAddressID.Value.ToString()));
                if (RefGetAddP != null)
                {
                    txtRefCAddress1.Text = Convert.ToString(RefGetAddP.Add1);
                    if (RefGetAddP.CityID != null)
                    {
                        City GetCCt = CityBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddP.CityID)));
                        if (GetCCt != null)
                            txtRefCCity.Text = GetCCt.CityName;
                        else
                            txtRefCCity.Text = "";
                    }
                    else txtRefCCity.Text = "";
                    if (RefGetAddP.StateID != null)
                    {
                        State GetCSt = StateBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddP.StateID)));
                        if (GetCSt != null)
                            txtRefCState.Text = GetCSt.StateName;
                        else
                            txtRefCState.Text = "";
                    }
                    else txtRefCState.Text = "";
                    if (RefGetAddP.CountryID != null)
                    {
                        Country RefPCnt = CountryBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddP.CountryID)));
                        if (RefPCnt != null)
                            txtRefCCountry.Text = RefPCnt.CountryName;
                        else
                            txtRefCCountry.Text = "";
                    }
                    else txtRefCCountry.Text = "";

                    txtRefCPostCode.Text = Convert.ToString(RefGetAddP.ZipCode);
                }
                else
                    txtRefCAddress1.Text = txtRefCCity.Text = txtRefCState.Text = txtRefCountry.Text = txtRefCPostCode.Text = string.Empty;

                //List<Investor> LstSecRefInvData = InvestorBLL.GetAllBy(Investor.InvestorFields.RefInverstorID, ViewState["InvestorID"].ToString());

                if (LstRefGetData.Count > 1 && LstRefGetData[1] != null)
                {
                    Investor SecRefInvData = (Investor)(LstRefGetData[1]);
                    ddl2JOTitle.SelectedValue = SecRefInvData.Title;
                    txt2JOFirstName.Text = SecRefInvData.FName;
                    txt2JOLastName.Text = SecRefInvData.LName;
                    txt2JOEmail.Text = SecRefInvData.EMail;

                    if (Convert.ToString(SecRefInvData.MobileNo) != "" && SecRefInvData.MobileNo != null)
                    {
                        string[] Refwords = SecRefInvData.MobileNo.Split('-');
                        if (Refwords.Length > 1)
                        {
                            txt2JOMobilecode.Text = Convert.ToString(Refwords[0]);
                            txt2JOMobileNo.Text = Convert.ToString(Refwords[1]);
                        }
                        else
                        {
                            txt2JOMobilecode.Text = Convert.ToString(Refwords[0]);
                            txt2JOMobileNo.Text = "";
                        }
                    }
                    else
                    {
                        txt2JOMobilecode.Text = "";
                        txt2JOMobileNo.Text = "";
                    }

                    txt2JOLandlineNo.Text = SecRefInvData.LandLineNo;
                    //if (Convert.ToString(SecRefInvData.Age) != "" && SecRefInvData.Age != null)
                    //    txt2JOAge.Text = Convert.ToString(SecRefInvData.Age);
                    //else
                    //    txtRefAge.Text = "";
                    txt2JOPanNo.Text = SecRefInvData.PanNo == null ? "" : SecRefInvData.PanNo;
                    txt2JOPOAHolder.Text = SecRefInvData.POAHolder == null ? "" : SecRefInvData.POAHolder;
                    txt2JOBankName.Text = SecRefInvData.BankName == null ? "" : SecRefInvData.BankName;
                    txt2JOBankAccountNo.Text = SecRefInvData.AccountNo == null ? "" : SecRefInvData.AccountNo;
                    txt2JOBanckAcctHolderName.Text = SecRefInvData.BankAcctName == null ? "" : SecRefInvData.BankAcctName.ToString();
                    if (Convert.ToString(SecRefInvData.OccupationTermID) != "")
                        ddl2JOOccupation.SelectedValue = Convert.ToString(SecRefInvData.OccupationTermID);
                    else
                        ddl2JOOccupation.SelectedValue = Convert.ToString(Guid.Empty);

                    txt2JOCompanyName.Text = SecRefInvData.CompanyName;
                    txt2JODesignation.Text = SecRefInvData.Designation;

                    txt2JOIFSCCode.Text = Convert.ToString(SecRefInvData.IFSCCode);

                    ddl2JODay.SelectedValue = SecRefInvData.DateOfBirth == null ? Guid.Empty.ToString() : SecRefInvData.DateOfBirth.Value.Day.ToString().Length == 2 ? SecRefInvData.DateOfBirth.Value.Day.ToString() : "0" + SecRefInvData.DateOfBirth.Value.Day.ToString();
                    ddl2JOMonth.SelectedValue = SecRefInvData.DateOfBirth == null ? Guid.Empty.ToString() : SecRefInvData.DateOfBirth.Value.Month.ToString();
                    ddl2JOYear.SelectedValue = SecRefInvData.DateOfBirth == null ? Guid.Empty.ToString() : SecRefInvData.DateOfBirth.Value.Year.ToString();

                    Address RefGetAddC1 = AddressBLL.GetByPrimaryKey(new Guid(SecRefInvData.AgreementAddressID.Value.ToString()));

                    if (RefGetAddC1 != null)
                    {
                        txt2JOAddress.Text = Convert.ToString(RefGetAddC1.Add1);

                        if (RefGetAddC1.CityID != null)
                        {
                            City RefGetCt = CityBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddC1.CityID)));
                            if (RefGetCt != null)
                                txt2JOCity.Text = RefGetCt.CityName;
                            else
                                txt2JOCity.Text = "";
                        }
                        else txt2JOCity.Text = "";

                        if (RefGetAddC1.StateID != null)
                        {
                            State RefGetSt = StateBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddC1.StateID)));
                            if (RefGetSt != null)
                                txt2JOState.Text = RefGetSt.StateName;
                            else
                                txt2JOState.Text = "";
                        }
                        else txt2JOState.Text = "";
                        if (RefGetAddC1.CountryID != null)
                        {
                            Country RefCnt = CountryBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddC1.CountryID)));
                            if (RefCnt != null)
                                txt2JOCountry.Text = RefCnt.CountryName;
                            else
                                txt2JOCountry.Text = "";
                        }
                        else txt2JOCountry.Text = "";

                        txt2JOZipCode.Text = Convert.ToString(RefGetAddC1.ZipCode);
                    }
                    else
                        txt2JOAddress.Text = txt2JOCity.Text = txt2JOState.Text = txt2JOCountry.Text = txt2JOZipCode.Text = string.Empty;

                    Address RefGetAddP1 = AddressBLL.GetByPrimaryKey(new Guid(SecRefInvData.PostalAddressID.Value.ToString()));
                    if (RefGetAddP1 != null)
                    {
                        txt2JOPostalAddress.Text = Convert.ToString(RefGetAddP1.Add1);
                        if (RefGetAddP1.CityID != null)
                        {
                            City GetCCt = CityBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddP1.CityID)));
                            if (GetCCt != null)
                                txt2JOPostalCity.Text = GetCCt.CityName;
                            else
                                txt2JOPostalCity.Text = "";
                        }
                        else txt2JOPostalCity.Text = "";
                        if (RefGetAddP1.StateID != null)
                        {
                            State GetCSt = StateBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddP1.StateID)));
                            if (GetCSt != null)
                                txt2JOPostalState.Text = GetCSt.StateName;
                            else
                                txt2JOPostalState.Text = "";
                        }
                        else txt2JOPostalState.Text = "";
                        if (RefGetAddP1.CountryID != null)
                        {
                            Country RefPCnt = CountryBLL.GetByPrimaryKey(new Guid(Convert.ToString(RefGetAddP1.CountryID)));
                            if (RefPCnt != null)
                                txt2JOPostalCountry.Text = RefPCnt.CountryName;
                            else
                                txt2JOPostalCountry.Text = "";
                        }
                        else txt2JOPostalCountry.Text = "";

                        txt2JOPostalZipCode.Text = Convert.ToString(RefGetAddP1.ZipCode);
                    }
                    else
                        txt2JOPostalAddress.Text = txt2JOPostalCity.Text = txt2JOPostalState.Text = txt2JOPostalCountry.Text = txt2JOPostalZipCode.Text = string.Empty;
                }
                else
                {
                    txt2JOAddress.Text = txt2JOBankAccountNo.Text = txt2JOBanckAcctHolderName.Text = txt2JOBankName.Text = txt2JOCity.Text = txt2JOCompanyName.Text = txt2JOCountry.Text = txt2JODesignation.Text = txt2JOEmail.Text = txt2JOFirstName.Text = txt2JOIFSCCode.Text = txt2JOLandlineNo.Text = txt2JOLastName.Text = txt2JOMobilecode.Text = txt2JOMobileNo.Text = txt2JOPanNo.Text = txt2JOPOAHolder.Text = txt2JOPostalAddress.Text = txt2JOPostalCity.Text = txt2JOPostalCountry.Text = txt2JOPostalState.Text = txt2JOPostalZipCode.Text = txt2JOState.Text = txt2JOZipCode.Text = "";
                    ddl2JOOccupation.SelectedIndex = ddl2JOTitle.SelectedIndex = 0;
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
                        ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event

        #region Search Manager Type Selection Change Event

        protected void ddlSManagerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSManager.Items.Clear();
            if (ddlSManagerType.SelectedValue != Guid.Empty.ToString())
            {
                if (ddlSManagerType.Text.Equals("Channel Partner"))
                {
                    DataView dv = new DataView(PaymentSlabeBLL.GetPaymentSlab("select UserID,DisplayName from irm_ChannelPartner Where IsActive = 1").Tables[0]);
                    if (dv.Count > 0)
                    {
                        dv.Sort = "DisplayName Asc";
                        ddlSManager.DataSource = dv;
                        ddlSManager.DataTextField = "DisplayName";
                        ddlSManager.DataValueField = "UserID";
                        ddlSManager.DataBind();
                        ddlSManager.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlSManager.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
                else if (ddlSManagerType.Text.Equals("Sales"))
                {
                    DataView dv = new DataView(PaymentSlabeBLL.GetPaymentSlab("select UserID,DisplayName from irm_SalesTeam Where IsActive = 1").Tables[0]);
                    if (dv.Count > 0)
                    {
                        dv.Sort = "DisplayName Asc";
                        ddlSManager.DataSource = dv;
                        ddlSManager.DataTextField = "DisplayName";
                        ddlSManager.DataValueField = "UserID";
                        ddlSManager.DataBind();
                        ddlSManager.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlSManager.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
            }
            else
            {
                ddlSManager.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }

            if (Session["InvID"] != null)
            {
                LoadInvData();
                LoadAccess();
            }
        }
        #endregion Search Manager Type Selection Change Event

        #region Email Notification Mail
        /// <summary>
        /// Save Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveEmailNotification_Click(object sender, EventArgs e)
        {
            UpdateInvestor();
            EmailNotification.Hide();
        }

        private void UpdateInvestor()
        {
            bool blIsSelfEmailChange = false;

            Investor Ins = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvestorID"].ToString()));
            Investor InsOld = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvestorID"].ToString()));
            Ins.Title = ddlTitle.SelectedValue.ToString();
            Ins.FName = txtFirstName.Text.Trim();
            Ins.LName = txtLastName.Text.Trim();
            Ins.EMail = txtEmail.Text.Trim();
            
            if (ddlCoOrdinatorInvestor.SelectedIndex != 0)
                Ins.CoOrdinatorInvestorID = new Guid(ddlCoOrdinatorInvestor.SelectedValue);
            else
                Ins.CoOrdinatorInvestorID = null;

            if (txtMobileCntCode.Text.Trim().Equals(""))
                Ins.MobileNo = "-" + txtMobileNo.Text.Trim();
            else
                Ins.MobileNo = txtMobileCntCode.Text.Trim() + "-" + txtMobileNo.Text.Trim();

            Ins.LandLineNo = txtLandLineNo.Text.Trim();
            //if (txtAge.Text.Trim() != "")
            //    Ins.Age = Convert.ToInt32(txtAge.Text.Trim());
            //else
            //    Ins.Age = null;

            Ins.PanNo = txtPANNo.Text.Trim().Equals("") ? null : txtPANNo.Text.Trim();
            Ins.POAHolder = txtPOAHolder.Text.Trim().Equals("") ? null : txtPOAHolder.Text.Trim();
            Ins.BankName = txtBankName.Text.Trim().Equals("") ? null : txtBankName.Text.Trim();
            Ins.AccountNo = txtBankAccNo.Text.Trim().Equals("") ? null : txtBankAccNo.Text.Trim();
            Ins.BankAcctName = txtBankAcctHolderName.Text.Trim().Equals("") ? null : txtBankAcctHolderName.Text.Trim();
            Ins.IsSMS = true;
            Ins.IsEmail = true;
            if (ddlOccupationTermID.SelectedValue != Guid.Empty.ToString())
                Ins.OccupationTermID = new Guid(ddlOccupationTermID.SelectedValue);
            else
                Ins.OccupationTermID = null;
            Ins.CompanyName = txtCompanyName.Text.Trim().Equals("") ? null : txtCompanyName.Text.Trim();
            Ins.Designation = txtDesignation.Text.Trim().Equals("") ? null : txtDesignation.Text.Trim();
            if (ddlRelationManagementID.SelectedValue != Guid.Empty.ToString())
                Ins.RelationShipManagerID = new Guid(ddlRelationManagementID.SelectedValue);
            else
                Ins.RelationShipManagerID = null;
            if (ddlManagerType.SelectedValue != Guid.Empty.ToString())
                Ins.ManagerType = ddlManagerType.SelectedValue;
            else
                Ins.ManagerType = null;
            Ins.NameOfFirm = txtNameOfFirm.Text.Trim().Equals("") ? null : txtNameOfFirm.Text.Trim();
            Ins.ManagerContactNo = txtManagerContactNo.Text.Trim().Equals("") ? null : txtManagerContactNo.Text.Trim();
            Ins.ManagerEmail = txtManagerEmail.Text.Trim().Equals("") ? null : txtManagerEmail.Text.Trim();
            Ins.PrimeMobileNo = txtPrimeMobileNo.Text.Trim().Equals("") ? null : txtPrimeMobileNo.Text.Trim();
            Ins.PrimeEmail = txtPrimeEmail.Text.Trim().Equals("") ? null : txtPrimeEmail.Text.Trim();
            Ins.UniworldPrime = ddlEmployee.SelectedValue.Equals(Guid.Empty.ToString()) ? null : ddlEmployee.SelectedValue.ToString();
            Ins.CompanyID = this.CompanyID;
            Ins.CreatedOn = DateTime.Now.Date;
            Ins.IsActive = true;
            Ins.UpdatedOn = DateTime.Now.Date;
            Ins.RelationalName = txtRelationalName.Text.Trim();
            Ins.ContactPersonName = txtContactPersonName.Text.Trim();
            Ins.ContactPersonEmail = txtContactPersonEmail.Text.Trim();
            Ins.ContactPersonMobile = txtContactPersonMobile.Text.Trim();

            Ins.Reference = txtRefrence.Text.Equals("") ? null : txtRefrence.Text.Trim();
            if (ddlReferenceThrow.SelectedValue != Guid.Empty.ToString())
                Ins.ReferenceTermID = new Guid(Convert.ToString(ddlReferenceThrow.SelectedValue));
            else
                Ins.ReferenceTermID = null;

            if (ddlEnteryRegion.SelectedValue != Guid.Empty.ToString())
                Ins.RegionTermID = new Guid(Convert.ToString(ddlEnteryRegion.SelectedValue));
            else
                Ins.RegionTermID = null;

            Ins.IFSCCode = Convert.ToString(txtIFSCCode.Text.Trim());

            if (ddlDay.SelectedIndex != 0 || ddlMonth.SelectedIndex != 0 || ddlYear.SelectedIndex != 0)
            {
                string DateOfBirth = Convert.ToString(ddlDay.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
                Ins.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            }
            else
                Ins.DateOfBirth = null;

            if (Convert.ToString(hdnUploadPhoto.Value) != "")
            {
                Ins.Thumb = Convert.ToString(hdnUploadPhoto.Value);
            }

            //Current Adderss Investor

            Address InvCAddress = AddressBLL.GetByPrimaryKey(new Guid(Ins.AgreementAddressID.ToString()));
            InvCAddress.Add1 = txtAddressLine1.Text.Trim();
            InvCAddress.ZipCode = txtPostCode.Text.Trim();
            InvCAddress.IsActive = true;
            InvCAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
            InvCAddress.StateID = clsCommon.State(txtState.Text.Trim());
            InvCAddress.CityID = clsCommon.City(txtCity.Text.Trim());

            InvCAddress.CompanyID = this.CompanyID;
            //Present Address Investor
            Address InvPAddress = AddressBLL.GetByPrimaryKey(new Guid(Ins.PostalAddressID.ToString()));
            InvPAddress.Add1 = txtCAddress1.Text.Trim();
            //InvPAddress.Add2 = txtCAddress2.Text;
            InvPAddress.ZipCode = txtCPostCode.Text.Trim();
            InvPAddress.IsActive = true;
            InvPAddress.CountryID = clsCommon.Country(txtCCountry.Text.Trim());
            InvPAddress.StateID = clsCommon.State(txtCState.Text.Trim());
            InvPAddress.CityID = clsCommon.City(txtCCity.Text.Trim());
            InvPAddress.CompanyID = this.CompanyID;



            string UPassword, UPasswordKey, DisName;
            if (!Ins.EMail.Trim().Equals(""))
            {
                User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(InsOld.UserID)));
                if (UpdtUsr != null)
                {
                    UpdtUsr.UserName = Ins.EMail.Trim();
                    UPasswordKey = UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    UPassword = UpdtUsr.Password;
                    DisName = UpdtUsr.UserDisplayName;

                    if (InsOld.EMail != Ins.EMail)
                    {
                        UpdtUsr.IsActive = false;

                        if (Convert.ToString(Session["UserID"]) == Convert.ToString(UpdtUsr.UsearID))
                            blIsSelfEmailChange = true;
                    }
                    else
                        UpdtUsr.IsActive = UpdtUsr.IsActive;
                    UserBLL.Update(UpdtUsr);
                }
                else
                {
                    User usr = new User();
                    usr.UsearID = Guid.NewGuid();
                    usr.UserTypeID = usr.UsearID;
                    usr.UserType = "Investor";
                    usr.CompanyID = this.CompanyID;
                    usr.UserName = Ins.EMail;
                    DisName = usr.UserDisplayName = Ins.FName + " " + Ins.LName;
                    UPassword = usr.Password = Guid.NewGuid().ToString().Substring(0, 8);
                    UPasswordKey = usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    usr.IsActive = false;
                    usr.CraetedOn = System.DateTime.Now.Date;
                    usr.IsBlock = false;
                    usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    usr.IsSynch = false;

                    List<UserRole> LstRl = new List<UserRole>();

                    UserRole UsrRole = new UserRole();
                    UsrRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["InvestorRole"]);
                    UsrRole.AssignedBy = usr.CreatedBy;
                    UsrRole.AssignedOn = DateTime.Now;
                    UsrRole.IsSynch = false;
                    UsrRole.SynchOn = DateTime.Now;
                    LstRl.Add(UsrRole);
                    UserBLL.Save(usr, LstRl);
                    Ins.UserID = usr.UsearID;
                }
            }
            else
            {
                User UpdtUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(InsOld.UserID)));
                if (UpdtUsr != null)
                {
                    UpdtUsr.UserName = Ins.EMail.Trim();
                    UPasswordKey = UpdtUsr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    DisName = UpdtUsr.UserDisplayName;
                    UPassword = UpdtUsr.Password;
                    UpdtUsr.IsActive = false;
                    UserBLL.Update(UpdtUsr);

                    if (Convert.ToString(Session["UserID"]) == Convert.ToString(UpdtUsr.UsearID))
                        blIsSelfEmailChange = true;
                }
                else
                {
                    User usr = new User();
                    usr.UsearID = Guid.NewGuid();
                    usr.UserTypeID = usr.UsearID;
                    usr.UserType = "Investor";
                    usr.CompanyID = this.CompanyID;
                    usr.UserName = Ins.EMail;
                    DisName = usr.UserDisplayName = Ins.FName + " " + Ins.LName;
                    UPassword = usr.Password = Guid.NewGuid().ToString().Substring(0, 8);
                    UPasswordKey = usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                    usr.IsActive = false;
                    usr.CraetedOn = System.DateTime.Now.Date;
                    usr.IsBlock = false;
                    usr.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                    usr.IsSynch = false;

                    List<UserRole> LstRl = new List<UserRole>();

                    UserRole UsrRole = new UserRole();
                    UsrRole.RoleID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["InvestorRole"]);
                    UsrRole.AssignedBy = usr.CreatedBy;
                    UsrRole.AssignedOn = DateTime.Now;
                    UsrRole.IsSynch = false;
                    UsrRole.SynchOn = DateTime.Now;
                    LstRl.Add(UsrRole);
                    UserBLL.Save(usr, LstRl);
                    Ins.UserID = usr.UsearID;
                }
            }

            InvestorBLL.Update(Ins, InvCAddress, InvPAddress);
            ActionLogBLL.Save(null, "Update", Ins.ToString(), Ins.ToString(), "irm_Investor");
            //Send Email
            if (InsOld.EMail != Ins.EMail && !(Ins.EMail.Equals("")))
            {
                ////To Uncomment later
                ////SendEmail(Ins.InvestorID, UPassword, DisName, new Guid(Convert.ToString(Ins.UserID)), UPasswordKey);
            }
            else if (InsOld.UserID != Ins.UserID && !(Ins.EMail.Equals("")))
            {
                ////To Uncomment later
                ////SendEmail(Ins.InvestorID, UPassword, DisName, new Guid(Convert.ToString(Ins.UserID)), UPasswordKey);
            }


            //Ref Investor
            List<Investor> LstIns = InvestorBLL.GetAllBy(Investor.InvestorFields.RefInverstorID, ViewState["InvestorID"].ToString());
            LstIns.Sort((Investor inv1, Investor inv2) => inv1.SeqNo.CompareTo(inv2.SeqNo));
            Investor RefIns = (Investor)(LstIns[0]);

            RefIns.Title = dllRefTitle.SelectedValue.ToString() == Guid.Empty.ToString() ? null : dllRefTitle.SelectedValue.ToString();
            RefIns.FName = txtRefFirstName.Text.Trim();
            RefIns.LName = txtRefLastName.Text.Trim();
            RefIns.EMail = txtRefEmail.Text.Trim();
            RefIns.CompanyID = this.CompanyID;

            if (txtRefMobileCntNo.Text.Trim().Equals(""))
                RefIns.MobileNo = "-" + txtRefMobileNO.Text.Trim();
            else
                RefIns.MobileNo = txtRefMobileCntNo.Text.Trim() + "-" + txtRefMobileNO.Text.Trim();

            RefIns.LandLineNo = txtRefMobileNO.Text.Trim();

            //if (txtRefAge.Text.Trim() != "")
            //    RefIns.Age = Convert.ToInt32(txtRefAge.Text.Trim());
            //else
            //    RefIns.Age = null;

            RefIns.PanNo = txtRefPANNo.Text.Trim().Equals("") ? null : txtRefPANNo.Text.Trim();
            RefIns.POAHolder = txtRefPOAHolder.Text.Trim().Equals("") ? null : txtRefPOAHolder.Text.Trim();
            RefIns.BankName = txtRefBankNo.Text.Trim().Equals("") ? null : txtRefBankNo.Text.Trim();
            RefIns.AccountNo = txtRefBankAccNo.Text.Trim().Equals("") ? null : txtRefBankAccNo.Text.Trim();
            RefIns.BankAcctName = txtRefBankAcctHolderName.Text.Trim().Equals("") ? null : txtRefBankAcctHolderName.Text.Trim();
            if (ddlRefOccupation.SelectedValue != Guid.Empty.ToString())
                RefIns.OccupationTermID = new Guid(ddlRefOccupation.SelectedValue);
            else
                RefIns.OccupationTermID = null;
            RefIns.CompanyName = txtRefCompanyName.Text.Equals("") ? null : txtRefCompanyName.Text.Trim();
            RefIns.Designation = txtRefDesignation.Text.Equals("") ? null : txtRefDesignation.Text.Trim();
            RefIns.UpdatedOn = DateTime.Now.Date;
            RefIns.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));

            RefIns.IFSCCode = Convert.ToString(txtRefIFSCCode.Text.Trim());

            if (ddlRefDay.SelectedIndex != 0 || ddlRefMonth.SelectedIndex != 0 || ddlRefYear.SelectedIndex != 0)
            {
                string DateOfBirth = Convert.ToString(ddlRefDay.SelectedValue.ToString().Trim() + "-" + ddlRefMonth.SelectedItem.Text.Trim() + "-" + ddlRefYear.SelectedValue.ToString().Trim());
                RefIns.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            }
            else
                RefIns.DateOfBirth = null;

            //Ref Investor Current Adderss Investor

            Address RefInvCAddress = AddressBLL.GetByPrimaryKey(new Guid(RefIns.AgreementAddressID.ToString()));
            RefInvCAddress.Add1 = txtRefAddress1.Text;
            //RefInvCAddress.Add2 = txtRefAddress2.Text;
            RefInvCAddress.ZipCode = txtRefPostCode.Text.Trim();
            RefInvCAddress.IsActive = true;
            RefInvCAddress.CountryID = clsCommon.Country(txtRefCountry.Text.Trim());
            RefInvCAddress.StateID = clsCommon.State(txtRefState.Text.Trim());
            RefInvCAddress.CityID = clsCommon.City(txtRefCity.Text.Trim());

            RefInvCAddress.CompanyID = this.CompanyID;


            //Present Address Investor


            Address RefInvPAddress = AddressBLL.GetByPrimaryKey(new Guid(RefIns.PostalAddressID.ToString()));
            RefInvPAddress.Add1 = txtRefCAddress1.Text;
            //RefInvPAddress.Add2 = txtRefCAddress2.Text;
            RefInvPAddress.ZipCode = txtRefCPostCode.Text;
            RefInvPAddress.CountryID = clsCommon.Country(txtRefCCountry.Text.Trim());
            RefInvPAddress.StateID = clsCommon.State(txtRefCState.Text.Trim());
            RefInvPAddress.CityID = clsCommon.City(txtRefCCity.Text.Trim());


            InvestorBLL.Update(RefIns, RefInvCAddress, RefInvPAddress);
            ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", RefIns.ToString(), RefIns.ToString(), "irm_Investor");



            //Second Joint Owner Investor

            if (LstIns.Count > 1 && LstIns[1] != null)
            {
                //Update 

                Investor SecondRefIns = (Investor)(LstIns[1]);

                SecondRefIns.Title = ddl2JOTitle.SelectedValue.ToString() == Guid.Empty.ToString() ? null : ddl2JOTitle.SelectedValue.ToString();
                SecondRefIns.FName = txt2JOFirstName.Text.Trim();
                SecondRefIns.LName = txt2JOLastName.Text.Trim();
                SecondRefIns.EMail = txt2JOEmail.Text.Trim();
                SecondRefIns.CompanyID = this.CompanyID;

                if (txt2JOMobilecode.Text.Trim().Equals(""))
                    SecondRefIns.MobileNo = "-" + txt2JOMobileNo.Text.Trim();
                else
                    SecondRefIns.MobileNo = txt2JOMobilecode.Text.Trim() + "-" + txt2JOMobileNo.Text.Trim();

                SecondRefIns.LandLineNo = txt2JOLandlineNo.Text.Trim();

                //if (txt2JOAge.Text.Trim() != "")
                //    SecondRefIns.Age = Convert.ToInt32(txt2JOAge.Text.Trim());
                //else
                //    SecondRefIns.Age = null;

                SecondRefIns.PanNo = txt2JOPanNo.Text.Trim().Equals("") ? null : txt2JOPanNo.Text.Trim();
                SecondRefIns.POAHolder = txt2JOPOAHolder.Text.Trim().Equals("") ? null : txt2JOPOAHolder.Text.Trim();
                SecondRefIns.BankName = txt2JOBankName.Text.Trim().Equals("") ? null : txt2JOBankName.Text.Trim();
                SecondRefIns.AccountNo = txt2JOBankAccountNo.Text.Trim().Equals("") ? null : txt2JOBankAccountNo.Text.Trim();
                SecondRefIns.BankAcctName = txt2JOBanckAcctHolderName.Text.Trim().Equals("") ? null : txt2JOBanckAcctHolderName.Text.Trim();
                if (ddl2JOOccupation.SelectedValue != Guid.Empty.ToString())
                    SecondRefIns.OccupationTermID = new Guid(ddl2JOOccupation.SelectedValue);
                else
                    SecondRefIns.OccupationTermID = null;
                SecondRefIns.CompanyName = txt2JOCompanyName.Text.Equals("") ? null : txt2JOCompanyName.Text.Trim();
                SecondRefIns.Designation = txt2JODesignation.Text.Equals("") ? null : txt2JODesignation.Text.Trim();
                SecondRefIns.UpdatedOn = DateTime.Now.Date;
                SecondRefIns.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));

                SecondRefIns.IFSCCode = Convert.ToString(txt2JOIFSCCode.Text.Trim());

                if (ddl2JODay.SelectedIndex != 0 || ddl2JOMonth.SelectedIndex != 0 || ddl2JOYear.SelectedIndex != 0)
                {
                    string DateOfBirth = Convert.ToString(ddl2JODay.SelectedValue.ToString().Trim() + "-" + ddl2JOMonth.SelectedItem.Text.Trim() + "-" + ddl2JOYear.SelectedValue.ToString().Trim());
                    SecondRefIns.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                }
                else
                    SecondRefIns.DateOfBirth = null;

                //Ref Investor Current Adderss Investor

                Address SecondRefInvCAddress = AddressBLL.GetByPrimaryKey(new Guid(SecondRefIns.AgreementAddressID.ToString()));
                SecondRefInvCAddress.Add1 = txt2JOAddress.Text;
                SecondRefInvCAddress.ZipCode = txt2JOZipCode.Text.Trim();
                SecondRefInvCAddress.IsActive = true;
                SecondRefInvCAddress.CountryID = clsCommon.Country(txt2JOCountry.Text.Trim());
                SecondRefInvCAddress.StateID = clsCommon.State(txt2JOState.Text.Trim());
                SecondRefInvCAddress.CityID = clsCommon.City(txt2JOCity.Text.Trim());
                SecondRefInvCAddress.CompanyID = this.CompanyID;


                //Present Address Investor


                Address SecondRefInvPAddress = AddressBLL.GetByPrimaryKey(new Guid(SecondRefIns.PostalAddressID.ToString()));
                SecondRefInvPAddress.Add1 = txt2JOPostalAddress.Text;
                SecondRefInvPAddress.ZipCode = txt2JOPostalZipCode.Text;
                SecondRefInvPAddress.CountryID = clsCommon.Country(txt2JOPostalCountry.Text.Trim());
                SecondRefInvPAddress.StateID = clsCommon.State(txt2JOPostalState.Text.Trim());
                SecondRefInvPAddress.CityID = clsCommon.City(txt2JOPostalCity.Text.Trim());


                InvestorBLL.Update(SecondRefIns, SecondRefInvCAddress, SecondRefInvPAddress);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", SecondRefIns.ToString(), SecondRefIns.ToString(), "irm_Investor");
            }
            else
            {
                //Save
                Investor ChkIns = InvestorBLL.GetByPrimaryKey(new Guid(ViewState["InvestorID"].ToString()));
                Investor objAdd2Owner = new Investor();
                objAdd2Owner.Title = ddl2JOTitle.SelectedValue.ToString() == Guid.Empty.ToString() ? null : ddl2JOTitle.SelectedValue.ToString();
                objAdd2Owner.FName = txt2JOFirstName.Text.Trim();
                objAdd2Owner.LName = txt2JOLastName.Text.Trim();
                objAdd2Owner.EMail = txt2JOEmail.Text.Trim();
                objAdd2Owner.CompanyID = this.CompanyID;
                objAdd2Owner.IsActive = true;
                if (txt2JOMobilecode.Text.Trim().Equals(""))
                    objAdd2Owner.MobileNo = "-" + txt2JOMobileNo.Text.Trim();
                else
                    objAdd2Owner.MobileNo = txt2JOMobilecode.Text.Trim() + "-" + txt2JOMobileNo.Text.Trim();

                RefIns.LandLineNo = txt2JOLandlineNo.Text.Trim();

                //if (txt2JOAge.Text.Trim() != "")
                //    objAdd2Owner.Age = Convert.ToInt32(txt2JOAge.Text.Trim());
                //else
                //    objAdd2Owner.Age = null;

                objAdd2Owner.PanNo = txt2JOPanNo.Text.Trim().Equals("") ? null : txt2JOPanNo.Text.Trim();
                objAdd2Owner.POAHolder = txt2JOPOAHolder.Text.Trim().Equals("") ? null : txt2JOPOAHolder.Text.Trim();
                objAdd2Owner.BankName = txt2JOBankName.Text.Trim().Equals("") ? null : txt2JOBankName.Text.Trim();
                objAdd2Owner.AccountNo = txt2JOBankAccountNo.Text.Trim().Equals("") ? null : txt2JOBankAccountNo.Text.Trim();
                objAdd2Owner.BankAcctName = txt2JOBanckAcctHolderName.Text.Trim().Equals("") ? null : txt2JOBanckAcctHolderName.Text.Trim();
                if (ddl2JOOccupation.SelectedValue != Guid.Empty.ToString())
                    objAdd2Owner.OccupationTermID = new Guid(ddl2JOOccupation.SelectedValue);
                else
                    objAdd2Owner.OccupationTermID = null;
                objAdd2Owner.CompanyName = txt2JOCompanyName.Text.Equals("") ? null : txt2JOCompanyName.Text.Trim();
                objAdd2Owner.Designation = txt2JODesignation.Text.Equals("") ? null : txt2JODesignation.Text.Trim();
                objAdd2Owner.UpdatedOn = DateTime.Now.Date;
                objAdd2Owner.RefInverstorID = ChkIns.InvestorID;
                objAdd2Owner.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));

                objAdd2Owner.IFSCCode = Convert.ToString(txt2JOIFSCCode.Text.Trim());

                if (ddl2JODay.SelectedIndex != 0 || ddl2JOMonth.SelectedIndex != 0 || ddl2JOYear.SelectedIndex != 0)
                {
                    string DateOfBirth = Convert.ToString(ddl2JODay.SelectedValue.ToString().Trim() + "-" + ddl2JOMonth.SelectedItem.Text.Trim() + "-" + ddl2JOYear.SelectedValue.ToString().Trim());
                    objAdd2Owner.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                }
                else
                    objAdd2Owner.DateOfBirth = null;

                //Ref Investor Current Adderss Investor

                Address SecondRefInvCAddress = new Address();
                SecondRefInvCAddress.Add1 = txt2JOAddress.Text;
                SecondRefInvCAddress.ZipCode = txt2JOZipCode.Text.Trim();
                SecondRefInvCAddress.IsActive = true;
                SecondRefInvCAddress.CountryID = clsCommon.Country(txt2JOCountry.Text.Trim());
                SecondRefInvCAddress.StateID = clsCommon.State(txt2JOState.Text.Trim());
                SecondRefInvCAddress.CityID = clsCommon.City(txt2JOCity.Text.Trim());
                SecondRefInvCAddress.CompanyID = this.CompanyID;


                //Present Address Investor


                Address SecondRefInvPAddress = new Address();
                SecondRefInvPAddress.Add1 = txt2JOPostalAddress.Text;
                SecondRefInvPAddress.ZipCode = txt2JOPostalZipCode.Text;
                SecondRefInvPAddress.CountryID = clsCommon.Country(txt2JOPostalCountry.Text.Trim());
                SecondRefInvPAddress.StateID = clsCommon.State(txt2JOPostalState.Text.Trim());
                SecondRefInvPAddress.CityID = clsCommon.City(txt2JOPostalCity.Text.Trim());


                InvestorBLL.Save(objAdd2Owner, SecondRefInvCAddress, SecondRefInvPAddress);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objAdd2Owner.ToString(), objAdd2Owner.ToString(), "irm_Investor");

            }

            if (blIsSelfEmailChange)
            {
                Session.Clear();
                Response.Redirect("~/InvChangeEmail.aspx");
            }

            IsInsert = true;
            lblInvestorMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
            Session.Add("InvID", Convert.ToString(ViewState["InvestorID"]));
            ViewState["InvestorID"] = null;
            hdnUploadPhoto.Value = "";

            LoadInvData();
            BindInverstorGrid();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelEmailNotification_Click(object sender, EventArgs e)
        {
            txtEmail.Text = hfOldEmial.Value;
            EmailNotification.Hide();
        }
        #endregion Email Notification Mail
    }
}