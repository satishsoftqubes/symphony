using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorProfile : System.Web.UI.UserControl
    {
        public bool IsInsert = false;
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

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("InvestorProfile.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            if (!IsPostBack)
            {
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    ProjectTerm objProjectTerm = new ProjectTerm();
                    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                    if (objProjectTerm != null)
                        this.DateFormat = objProjectTerm.Term;
                    else
                        this.DateFormat = "dd/MM/yyyy";
                }
                else
                    this.DateFormat = "dd/MM/yyyy";

                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Title Here
        /// </summary>
        /// <param name="ddl">ddl as DropDownList</param>
        private void LoadOccupation()
        {
            litInvOccupation.Items.Clear();
            ProjectTerm TitleTerm = new ProjectTerm();
            TitleTerm.Category = "OCCUPATION";
            TitleTerm.IsActive = true;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(TitleTerm);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                litInvOccupation.DataSource = Lst;
                litInvOccupation.DataTextField = "DisplayTerm";
                litInvOccupation.DataValueField = "TermID";
                litInvOccupation.DataBind();
                litInvOccupation.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                litInvOccupation.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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
                     */
                    #endregion
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
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorProfile.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Save"] = Convert.ToBoolean(DV[0]["IsCreate"]);
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
            if (Session["CompanyID"] != null)
            {
                BindBirthDateDDLs();
                LoadOccupation();
                LoadInvestorValue();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        /// <summary>
        /// Load Investor Value
        /// </summary>
        private void LoadInvestorValue()
        {
            Investor GetData = InvestorBLL.GetByPrimaryKey(new Guid(Session["InvID"].ToString()));
            if (GetData != null)
            {
                litInvFullName.Text = GetData.Title + " " + GetData.FName + " " + GetData.LName;
                txtInvEmail.Text = hfOldEmial.Value = Convert.ToString(GetData.EMail);
                litInvMobileNo.Text = Convert.ToString(GetData.MobileNo);

                if (Convert.ToString(GetData.MobileNo) != "" && GetData.MobileNo != null)
                {
                    string[] words = GetData.MobileNo.Split('-');
                    if (words.Length > 1)
                    {
                        txtInvMobileCntNo.Text = Convert.ToString(words[0]);
                        litInvMobileNo.Text = Convert.ToString(words[1]);
                    }
                    else
                    {
                        txtInvMobileCntNo.Text = Convert.ToString(words[0]);
                        litInvMobileNo.Text = "";
                    }
                }
                else
                {
                    txtInvMobileCntNo.Text = "";
                    litInvMobileNo.Text = "";
                }

                //litInvLandlineNo.Text = GetData.LandLineNo;
                //if (Convert.ToString(GetData.Age) != "" && GetData.Age != null)
                //    LitInvAge.Text = Convert.ToString(GetData.Age);
                //else
                //    LitInvAge.Text = "-";

                ////if (GetData.DateOfBirth != null && Convert.ToString(GetData.DateOfBirth) != "")
                ////{
                ////    DateTime dt = Convert.ToDateTime(GetData.DateOfBirth);
                ////    LitInvDateOfBirth.Text = dt.ToString(this.DateFormat); 
                ////}
                ////else
                ////    LitInvDateOfBirth.Text = "-";
                ddlDay.SelectedValue = GetData.DateOfBirth == null ? Guid.Empty.ToString() : GetData.DateOfBirth.Value.Day.ToString().Length == 2 ? GetData.DateOfBirth.Value.Day.ToString() : "0" + GetData.DateOfBirth.Value.Day.ToString();
                ddlMonth.SelectedValue = GetData.DateOfBirth == null ? Guid.Empty.ToString() : GetData.DateOfBirth.Value.Month.ToString();
                ddlYear.SelectedValue = GetData.DateOfBirth == null ? Guid.Empty.ToString() : GetData.DateOfBirth.Value.Year.ToString();

                txtPANNo.Text = GetData.PanNo == null ? "" : GetData.PanNo;
                txtPOAHolder.Text = GetData.POAHolder == null ? "" : GetData.POAHolder;
                txtBankName.Text = GetData.BankName == null ? "" : GetData.BankName;
                txtBankAccNo.Text = GetData.AccountNo == null ? "" : GetData.AccountNo;
                txtBankAcctHolderName.Text = GetData.BankAcctName == null ? "" : GetData.BankAcctName;
                txtIFSCCode.Text = Convert.ToString(GetData.IFSCCode);

                //litInvPANNO.Text = GetData.PanNo == null ? "-" : Convert.ToString(GetData.PanNo);
                //litInvPOAHolder.Text = GetData.POAHolder == null ? "-" : Convert.ToString(GetData.POAHolder);
                //litInvBankName.Text = GetData.BankName == null ? "-" : Convert.ToString(GetData.BankName);
                //litInvAccountNo.Text = GetData.AccountNo == null ? "-" : Convert.ToString(GetData.AccountNo);
                //litInvIFSCCode.Text = GetData.IFSCCode == null ? "-" : Convert.ToString(GetData.IFSCCode);
                if (GetData.OccupationTermID == null)
                    litInvOccupation.Text = "-";
                else
                {
                    litInvOccupation.SelectedIndex = litInvOccupation.Items.FindByValue(Convert.ToString(GetData.OccupationTermID)) != null ? litInvOccupation.Items.IndexOf(litInvOccupation.Items.FindByValue(Convert.ToString(GetData.OccupationTermID))) : 0;
                }

                litInvCompanyName.Text = Convert.ToString(GetData.CompanyName);
                litInvDesignation.Text = Convert.ToString(GetData.Designation);

                txtContactPersonName.Text = Convert.ToString(GetData.ContactPersonName) != "" ? Convert.ToString(GetData.ContactPersonName) : "-";
                txtRelationalName.Text = Convert.ToString(GetData.RelationalName) != "" ? Convert.ToString(GetData.RelationalName) : "-";
                txtContactPersonEmail.Text = Convert.ToString(GetData.ContactPersonEmail) != "" ? Convert.ToString(GetData.ContactPersonEmail) : "-";
                txtContactPersonMobile.Text = Convert.ToString(GetData.ContactPersonMobile) != "" ? Convert.ToString(GetData.ContactPersonMobile) : "-";


                ///// litINvManagerType.Text = GetData.ManagerType;

                if (GetData.ManagerType.ToUpper().Equals("SALES"))
                {
                    //List<SalesTeam> Mana = SalesTeamBLL.GetAllBy(SalesTeam.SalesTeamFields.UserID, Convert.ToString(GetData.RelationShipManagerID));
                    //if (Mana.Count == 1)
                    //    litInvRelationManagerID.Text = Mana[0].DisplayName;
                    //else
                    //    litInvRelationManagerID.Text = "NA";

                    litInvRelationManagerID.Text = "-";
                    litInvNoOfFirm.Text = "-";
                    litInvManagerContactNo.Text = "-";
                    litInvMangerEmail.Text = "-";
                }
                else
                {
                    List<ChannelPartner> Mana = ChannelPartnerBLL.GetAllBy(ChannelPartner.ChannelPartnerFields.UserID, Convert.ToString(GetData.RelationShipManagerID));
                    if (Mana.Count == 1)
                        litInvRelationManagerID.Text = Mana[0].DisplayName;
                    else
                        litInvRelationManagerID.Text = "-";

                    litInvNoOfFirm.Text = GetData.NameOfFirm == null ? "-" : Convert.ToString(GetData.NameOfFirm);
                    litInvManagerContactNo.Text = GetData.ManagerContactNo == null ? "-" : Convert.ToString(GetData.ManagerContactNo);
                    litInvMangerEmail.Text = GetData.ManagerEmail == null ? "-" : Convert.ToString(GetData.ManagerEmail);
                }

                //litInvNoOfFirm.Text = GetData.NameOfFirm == null ? "NA" : GetData.NameOfFirm;
                //litInvManagerContactNo.Text = GetData.ManagerContactNo == null ? "NA" : GetData.ManagerContactNo;
                //litInvMangerEmail.Text = GetData.ManagerEmail == null ? "NA" : GetData.ManagerEmail;

                if (Convert.ToString(GetData.UniworldPrime) == string.Empty || GetData.UniworldPrime == null || Convert.ToString(GetData.UniworldPrime) == Guid.Empty.ToString())
                    litInvUniWorldPrime.Text = "-";
                else
                {
                    Employee Emp = EmployeeBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetData.UniworldPrime)));
                    if (Emp != null)
                        litInvUniWorldPrime.Text = Emp.FullName;
                    else
                        litInvUniWorldPrime.Text = "-";
                }
                litInvPrimaryMobileNo.Text = GetData.PrimeMobileNo == null ? "-" : Convert.ToString(GetData.PrimeMobileNo);
                litInvPrimeEmail.Text = GetData.PrimeEmail == null ? "-" : Convert.ToString(GetData.PrimeEmail);
                if (GetData.Thumb.ToUpper().ToString().Trim() != "BUSINESSCARD.PNG")
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/" + GetData.Thumb;
                    HypRemove.Visible = true;
                }
                else
                {
                    imgInvPhoto.ImageUrl = "~/UploadPhoto/BusinessCard.png";
                    HypRemove.Visible = false;
                }


                Address GetAddC = AddressBLL.GetByPrimaryKey(new Guid(GetData.AgreementAddressID.Value.ToString()));
                if (Convert.ToString(GetAddC.Add1) != "" && GetAddC.Add1 != null)
                    LitInvAddressLine1.Text = GetAddC.Add1;
                else
                    LitInvAddressLine1.Text = "-";

                //LitInvAddressLine2.Text = GetAddC.Add2;
                if (GetAddC.CityID != null)
                {
                    City GetCt = CityBLL.GetByPrimaryKey(new Guid(GetAddC.CityID.Value.ToString()));
                    if (GetCt != null)
                        LitInvCity.Text = Convert.ToString(GetCt.CityName);
                    else
                        LitInvCity.Text = "-";
                }
                else
                    LitInvCity.Text = "-";
                if (GetAddC.StateID != null)
                {
                    State GetSt = StateBLL.GetByPrimaryKey(new Guid(GetAddC.StateID.Value.ToString()));
                    if (GetSt != null)
                        LitInvState.Text = Convert.ToString(GetSt.StateName);
                    else
                        LitInvState.Text = "-";
                }
                else
                    LitInvState.Text = "-";
                if (GetAddC.CountryID != null)
                {
                    Country Cnt = CountryBLL.GetByPrimaryKey(new Guid(GetAddC.CountryID.Value.ToString()));
                    if (Cnt != null)
                        LitInvCountry.Text = Convert.ToString(Cnt.CountryName);
                    else
                        LitInvCountry.Text = "-";
                }
                else
                    LitInvCountry.Text = "-";

                if (Convert.ToString(GetAddC.ZipCode) != "" && GetAddC.ZipCode != null)
                    LitInvPostCode.Text = Convert.ToString(GetAddC.ZipCode);
                else
                    LitInvPostCode.Text = "-";


                Address GetAddP = AddressBLL.GetByPrimaryKey(new Guid(GetData.PostalAddressID.Value.ToString()));
                LitInvStreet.Text = GetAddP.Add1;
                //litCAddressLine2.Text = GetAddP.Add2;
                if (GetAddP.CityID != null)
                {
                    City GetPCt = CityBLL.GetByPrimaryKey(new Guid(GetAddP.CityID.Value.ToString()));
                    if (GetPCt != null)
                        LitInvCCity.Text = Convert.ToString(GetPCt.CityName);
                    else
                        LitInvCCity.Text = "";
                }
                else
                    LitInvCCity.Text = "";
                if (GetAddP.StateID != null)
                {
                    State GetPSt = StateBLL.GetByPrimaryKey(new Guid(GetAddP.StateID.Value.ToString()));
                    if (GetPSt != null)
                        LitCState.Text = Convert.ToString(GetPSt.StateName);
                    else
                        LitCState.Text = "";
                }
                else
                    LitCState.Text = "";
                if (GetAddP.CountryID != null)
                {
                    Country PCnt = CountryBLL.GetByPrimaryKey(new Guid(GetAddP.CountryID.Value.ToString()));
                    if (PCnt != null)
                        LitInvCCounty.Text = Convert.ToString(PCnt.CountryName);
                    else
                        LitInvCCounty.Text = "";
                }
                else
                    LitInvCCounty.Text = "";

                LitInvCPostCode.Text = Convert.ToString(GetAddP.ZipCode);

                List<Investor> LstRefGetData = InvestorBLL.GetAllBy(Investor.InvestorFields.RefInverstorID, Session["InvID"].ToString());
                LstRefGetData.Sort((Investor inv1, Investor inv2) => inv1.SeqNo.CompareTo(inv2.SeqNo));

                Investor RefGetData = (Investor)(LstRefGetData[0]);

                if (Convert.ToString(RefGetData.Title) != "" && RefGetData.Title != null)
                    litRefFullName.Text = Convert.ToString(RefGetData.Title) + " " + Convert.ToString(RefGetData.FName) + " " + Convert.ToString(RefGetData.LName);
                else
                    litRefFullName.Text = "-";
                if (Convert.ToString(RefGetData.EMail) != "" && RefGetData.EMail != null)
                    litRefEmail.Text = Convert.ToString(RefGetData.EMail);
                else
                    litRefEmail.Text = "-";

                if (Convert.ToString(RefGetData.MobileNo) != "" && RefGetData.MobileNo != null)
                    litRefMobileNo.Text = Convert.ToString(MobileNo(RefGetData.MobileNo));
                else
                    litRefMobileNo.Text = "-";

                txtRefIFSCCode.Text = Convert.ToString(RefGetData.IFSCCode);

                ddlRefDay.SelectedValue = RefGetData.DateOfBirth == null ? Guid.Empty.ToString() : RefGetData.DateOfBirth.Value.Day.ToString().Length == 2 ? RefGetData.DateOfBirth.Value.Day.ToString() : "0" + RefGetData.DateOfBirth.Value.Day.ToString();
                ddlRefMonth.SelectedValue = RefGetData.DateOfBirth == null ? Guid.Empty.ToString() : RefGetData.DateOfBirth.Value.Month.ToString();
                ddlRefYear.SelectedValue = RefGetData.DateOfBirth == null ? Guid.Empty.ToString() : RefGetData.DateOfBirth.Value.Year.ToString();

                txtRefPANNo.Text = RefGetData.PanNo == null ? "" : RefGetData.PanNo;
                txtRefPOAHolder.Text = RefGetData.POAHolder == null ? "" : RefGetData.POAHolder;
                txtRefBankNo.Text = RefGetData.BankName == null ? "" : RefGetData.BankName;
                txtRefBankAccNo.Text = RefGetData.AccountNo == null ? "" : RefGetData.AccountNo;
                txtRefBankAcctHolderName.Text = RefGetData.BankAcctName == null ? "" : RefGetData.BankAcctName;

                if (RefGetData.OccupationTermID == null)
                    litRefOccupation.Text = "-";
                else
                {
                    ProjectTerm RefGet = ProjectTermBLL.GetByPrimaryKey(new Guid(RefGetData.OccupationTermID.Value.ToString()));
                    if (RefGet != null)
                        litRefOccupation.Text = RefGet.Term;
                    else
                        litRefOccupation.Text = "-";
                }

                if (Convert.ToString(RefGetData.CompanyName) != "" && RefGetData.CompanyName != null)
                    litRefCompanyName.Text = Convert.ToString(RefGetData.CompanyName);
                else
                    litRefCompanyName.Text = "-";

                if (Convert.ToString(RefGetData.Designation) != "" && RefGetData.Designation != null)
                    litRefDesignation.Text = Convert.ToString(RefGetData.Designation);
                else
                    litRefDesignation.Text = "-";

                Address RefGetAddC = AddressBLL.GetByPrimaryKey(new Guid(RefGetData.AgreementAddressID.Value.ToString()));

                if (Convert.ToString(RefGetAddC.Add1) != "" && RefGetAddC.Add1 != null)
                    litRefAddressLine1.Text = Convert.ToString(RefGetAddC.Add1);
                else
                    litRefAddressLine1.Text = "-";
                //litRefAddressLine2.Text = RefGetAddC.Add2;
                if (Convert.ToString(RefGetAddC.CityID) != "" && RefGetAddC.CityID != null)
                {
                    City RefGetCt = CityBLL.GetByPrimaryKey(new Guid(RefGetAddC.CityID.Value.ToString()));
                    if (RefGetCt != null)
                        litRefCity.Text = Convert.ToString(RefGetCt.CityName);
                    else
                        litRefCity.Text = "-";
                }
                else
                    litRefCity.Text = "-";
                if (Convert.ToString(RefGetAddC.StateID) != "" && RefGetAddC.StateID != null)
                {
                    State RefGetSt = StateBLL.GetByPrimaryKey(new Guid(RefGetAddC.StateID.Value.ToString()));
                    if (RefGetSt != null)
                        litRefState.Text = Convert.ToString(RefGetSt.StateName);
                    else
                        litRefState.Text = "-";
                }
                else
                    litRefState.Text = "-";
                if (Convert.ToString(RefGetAddC.CountryID) != "" && RefGetAddC.CountryID != null)
                {
                    Country RefCnt = CountryBLL.GetByPrimaryKey(new Guid(RefGetAddC.CountryID.Value.ToString()));
                    if (RefCnt != null)
                        litRefCountry.Text = Convert.ToString(RefCnt.CountryName);
                    else
                        litRefCountry.Text = "-";
                }
                else litRefCountry.Text = "-";

                if (Convert.ToString(RefGetAddC.ZipCode) != "" && RefGetAddC.ZipCode != null)
                    litRefPostCode.Text = Convert.ToString(RefGetAddC.ZipCode);
                else
                    litRefPostCode.Text = "-";

                Address RefGetAddP = AddressBLL.GetByPrimaryKey(new Guid(RefGetData.PostalAddressID.Value.ToString()));

                if (Convert.ToString(RefGetAddP.Add1) != "" && RefGetAddP.Add1 != null)
                    litRefCAddressLine1.Text = Convert.ToString(RefGetAddP.Add1);
                else
                    litRefCAddressLine1.Text = "-";
                //litRefCAddressLine2.Text = RefGetAddP.Add2;
                if (Convert.ToString(RefGetAddP.CityID) != "" && RefGetAddP.CityID != null)
                {
                    City GetCCt = CityBLL.GetByPrimaryKey(new Guid(RefGetAddP.CityID.Value.ToString()));
                    if (GetCCt != null)
                        litRefCCity.Text = Convert.ToString(GetCCt.CityName);
                    else
                        litRefCCity.Text = "-";
                }
                else
                    litRefCCity.Text = "-";
                if (Convert.ToString(RefGetAddP.StateID) != "" && RefGetAddP.StateID != null)
                {
                    State GetCSt = StateBLL.GetByPrimaryKey(new Guid(RefGetAddP.StateID.Value.ToString()));
                    if (GetCSt != null)
                        litRefCState.Text = Convert.ToString(GetCSt.StateName);
                    else
                        litRefCState.Text = "-";
                }
                else
                    litRefCState.Text = "-";
                if (Convert.ToString(RefGetAddP.CountryID) != "" && RefGetAddP.CountryID != null)
                {
                    Country RefPCnt = CountryBLL.GetByPrimaryKey(new Guid(RefGetAddP.CountryID.Value.ToString()));
                    if (RefPCnt != null)
                        litRefCCountry.Text = Convert.ToString(RefPCnt.CountryName);
                    else
                        litRefCCountry.Text = "-";
                }
                else
                    litRefCCountry.Text = "-";

                if (Convert.ToString(RefGetAddP.ZipCode) != "" && RefGetAddP.ZipCode != null)
                    litRefCPostCode.Text = Convert.ToString(RefGetAddP.ZipCode);
                else
                    litRefCPostCode.Text = "-";

                if (LstRefGetData.Count > 1 && LstRefGetData[1] != null)
                {
                    Investor SecRefInvData = (Investor)(LstRefGetData[1]);

                    if (Convert.ToString(SecRefInvData.Title) != "" && SecRefInvData.Title != null)
                        litDisplay2JOName.Text = Convert.ToString(SecRefInvData.Title) + " " + Convert.ToString(SecRefInvData.FName) + " " + Convert.ToString(SecRefInvData.LName);
                    else
                        litDisplay2JOName.Text = "-";
                    if (Convert.ToString(SecRefInvData.EMail) != "" && SecRefInvData.EMail != null)
                        litDisplay2JOEMail.Text = Convert.ToString(SecRefInvData.EMail);
                    else
                        litDisplay2JOEMail.Text = "-";
                    if (Convert.ToString(SecRefInvData.MobileNo) != "" && SecRefInvData.MobileNo != null)
                        litDisplay2JOMobileNo.Text = Convert.ToString(MobileNo(SecRefInvData.MobileNo));
                    else
                        litDisplay2JOMobileNo.Text = "-";


                    Address Get2JOAA = AddressBLL.GetByPrimaryKey(new Guid(SecRefInvData.AgreementAddressID.Value.ToString()));

                    if (Convert.ToString(Get2JOAA.Add1) != "" && Get2JOAA.Add1 != null)
                        litDisplay2JOAAAddress.Text = Convert.ToString(Get2JOAA.Add1);
                    else
                        litDisplay2JOAAAddress.Text = "-";

                    if (Convert.ToString(Get2JOAA.CityID) != "" && Get2JOAA.CityID != null)
                    {
                        City Get2JOAACt = CityBLL.GetByPrimaryKey(new Guid(Get2JOAA.CityID.Value.ToString()));
                        if (Get2JOAACt != null)
                            litDisplay2JOAACity.Text = Convert.ToString(Get2JOAACt.CityName);
                        else
                            litDisplay2JOAACity.Text = "-";
                    }
                    else
                        litDisplay2JOAACity.Text = "-";

                    if (Convert.ToString(Get2JOAA.StateID) != "" && Get2JOAA.StateID != null)
                    {
                        State Get2JOAASt = StateBLL.GetByPrimaryKey(new Guid(Get2JOAA.StateID.Value.ToString()));
                        if (Get2JOAASt != null)
                            litDisplay2JOAAState.Text = Convert.ToString(Get2JOAASt.StateName);
                        else
                            litDisplay2JOAAState.Text = "-";
                    }
                    else
                        litDisplay2JOAAState.Text = "-";

                    if (Convert.ToString(Get2JOAA.CountryID) != "" && Get2JOAA.CountryID != null)
                    {
                        Country Get2JOAACnt = CountryBLL.GetByPrimaryKey(new Guid(Get2JOAA.CountryID.Value.ToString()));
                        if (Get2JOAACnt != null)
                            litDisplay2JOAACountry.Text = Convert.ToString(Get2JOAACnt.CountryName);
                        else
                            litDisplay2JOAACountry.Text = "-";
                    }
                    else
                        litDisplay2JOAACountry.Text = "-";

                    if (Convert.ToString(Get2JOAA.ZipCode) != "" && Get2JOAA.ZipCode != null)
                        litDisplay2JOAAZipCode.Text = Convert.ToString(Get2JOAA.ZipCode);
                    else
                        litDisplay2JOAAZipCode.Text = "-";


                    Address Get2JOPA = AddressBLL.GetByPrimaryKey(new Guid(SecRefInvData.PostalAddressID.Value.ToString()));

                    if (Convert.ToString(Get2JOPA.Add1) != "" && Get2JOPA.Add1 != null)
                        litDisplay2JOPAAddress.Text = Convert.ToString(Get2JOPA.Add1);
                    else
                        litDisplay2JOPAAddress.Text = "-";

                    if (Convert.ToString(Get2JOPA.CityID) != "" && Get2JOPA.CityID != null)
                    {
                        City Get2JOPACt = CityBLL.GetByPrimaryKey(new Guid(Get2JOPA.CityID.Value.ToString()));
                        if (Get2JOPACt != null)
                            litDisplay2JOPACity.Text = Convert.ToString(Get2JOPACt.CityName);
                        else
                            litDisplay2JOPACity.Text = "-";
                    }
                    else
                        litDisplay2JOPACity.Text = "-";

                    if (Convert.ToString(Get2JOPA.StateID) != "" && Get2JOPA.StateID != null)
                    {
                        State Get2JOPASt = StateBLL.GetByPrimaryKey(new Guid(Get2JOPA.StateID.Value.ToString()));
                        if (Get2JOPASt != null)
                            litDisplay2JOPAState.Text = Convert.ToString(Get2JOPASt.StateName);
                        else
                            litDisplay2JOPAState.Text = "-";
                    }
                    else
                        litDisplay2JOPAState.Text = "-";

                    if (Convert.ToString(Get2JOPA.CountryID) != "" && Get2JOPA.CountryID != null)
                    {
                        Country Get2JOPACnt = CountryBLL.GetByPrimaryKey(new Guid(Get2JOPA.CountryID.Value.ToString()));
                        if (Get2JOPACnt != null)
                            litDisplay2JOPACountry.Text = Convert.ToString(Get2JOPACnt.CountryName);
                        else
                            litDisplay2JOPACountry.Text = "-";
                    }
                    else
                        litDisplay2JOPACountry.Text = "-";

                    if (Convert.ToString(Get2JOPA.ZipCode) != "" && Get2JOPA.ZipCode != null)
                        litDisplay2JOPAZipCode.Text = Convert.ToString(Get2JOPA.ZipCode);
                    else
                        litDisplay2JOPAZipCode.Text = "-";

                    //if (SecRefInvData.DateOfBirth != null && Convert.ToString(SecRefInvData.DateOfBirth) != "")
                    //{
                    //    DateTime dt = Convert.ToDateTime(SecRefInvData.DateOfBirth);
                    //    lit2JODateOfBirth.Text = dt.ToString(this.DateFormat);
                    //}
                    //else
                    //    lit2JODateOfBirth.Text = "-";
                    ddl2JODay.SelectedValue = SecRefInvData.DateOfBirth == null ? Guid.Empty.ToString() : SecRefInvData.DateOfBirth.Value.Day.ToString().Length == 2 ? SecRefInvData.DateOfBirth.Value.Day.ToString() : "0" + SecRefInvData.DateOfBirth.Value.Day.ToString();
                    ddl2JOMonth.SelectedValue = SecRefInvData.DateOfBirth == null ? Guid.Empty.ToString() : SecRefInvData.DateOfBirth.Value.Month.ToString();
                    ddl2JOYear.SelectedValue = SecRefInvData.DateOfBirth == null ? Guid.Empty.ToString() : SecRefInvData.DateOfBirth.Value.Year.ToString();

                    txt2JOPanNo.Text = SecRefInvData.PanNo == null ? "" : SecRefInvData.PanNo;
                    txt2JOPOAHolder.Text = SecRefInvData.POAHolder == null ? "" : SecRefInvData.POAHolder;
                    txt2JOBankName.Text = SecRefInvData.BankName == null ? "" : SecRefInvData.BankName;
                    txt2JOBankAccountNo.Text = SecRefInvData.AccountNo == null ? "" : SecRefInvData.AccountNo;
                    txt2JOBankAcctHolderName.Text = SecRefInvData.BankAcctName == null ? "" : SecRefInvData.BankAcctName;

                    txt2JOIFSCCode.Text = Convert.ToString(SecRefInvData.IFSCCode);

                    if (SecRefInvData.OccupationTermID == null)
                        litDisplay2JOOccupation.Text = "-";
                    else
                    {
                        ProjectTerm Ref2JOGet = ProjectTermBLL.GetByPrimaryKey(new Guid(SecRefInvData.OccupationTermID.Value.ToString()));
                        if (Ref2JOGet != null)
                            litDisplay2JOOccupation.Text = Ref2JOGet.Term;
                        else
                            litDisplay2JOOccupation.Text = "-";
                    }

                    if (Convert.ToString(SecRefInvData.CompanyName) != "" && SecRefInvData.CompanyName != null)
                        litDisplay2JOCompanyName.Text = Convert.ToString(SecRefInvData.CompanyName);
                    else
                        litDisplay2JOCompanyName.Text = "-";

                    if (Convert.ToString(SecRefInvData.Designation) != "" && SecRefInvData.Designation != null)
                        litDisplay2JODesignation.Text = Convert.ToString(SecRefInvData.Designation);
                    else
                        litDisplay2JODesignation.Text = "-";
                }
                else
                {
                    litDisplay2JOName.Text = litDisplay2JOEMail.Text = litDisplay2JOMobileNo.Text = "-";
                    litDisplay2JOAAAddress.Text = litDisplay2JOAACity.Text = litDisplay2JOAAState.Text = litDisplay2JOAACountry.Text = litDisplay2JOAAZipCode.Text = litDisplay2JOPAAddress.Text = litDisplay2JOPACity.Text = litDisplay2JOPAState.Text = litDisplay2JOPACountry.Text = litDisplay2JOPAZipCode.Text = "-";
                    litDisplay2JOOccupation.Text = litDisplay2JOCompanyName.Text = litDisplay2JODesignation.Text = "-";
                    ddl2JODay.Enabled = ddl2JOMonth.Enabled = ddl2JOYear.Enabled = txt2JOPanNo.Enabled = txt2JOPOAHolder.Enabled = txt2JOBankName.Enabled = txt2JOBankAccountNo.Enabled = txt2JOBankAcctHolderName.Enabled = txt2JOIFSCCode.Enabled = false;
                }

            }
        }

        private string MobileNo(string strMobileNo)
        {
            string strPhNo = "-";

            string[] words = strMobileNo.Split('-');

            if (words.Length > 1)
            {
                if (words[0] != "")
                    strPhNo = Convert.ToString(words[0]);

                if (words[1] != "")
                {
                    if (strPhNo != "-")
                        strPhNo = strPhNo + "-" + words[1];
                    else
                        strPhNo = words[1];
                }
            }

            return strPhNo;
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

        //private void UpdateInvestorIndicationData()
        //{
        //    HtmlTable tblUpdateIndication = (HtmlTable)this.Page.Master.FindControl("tblUpdateIndication");

        //    HtmlTableRow trUpdtFristOwnerTitle = (HtmlTableRow)this.Page.Master.FindControl("trUpdtFristOwnerTitle");
        //    HtmlTableRow trUpdateOwnerDOB = (HtmlTableRow)this.Page.Master.FindControl("trUpdateOwnerDOB");
        //    HtmlTableRow trUpdateOwnerPANNo = (HtmlTableRow)this.Page.Master.FindControl("trUpdateOwnerPANNo");
        //    HtmlTableRow trUpdateOwnerBankName = (HtmlTableRow)this.Page.Master.FindControl("trUpdateOwnerBankName");
        //    HtmlTableRow trUpdateOwnerBankAcctNo = (HtmlTableRow)this.Page.Master.FindControl("trUpdateOwnerBankAcctNo");
        //    HtmlTableRow trUpdateOwnerIFSCCode = (HtmlTableRow)this.Page.Master.FindControl("trUpdateOwnerIFSCCode");

        //    HtmlTableRow trUpdtJointOwnerTitle = (HtmlTableRow)this.Page.Master.FindControl("trUpdtJointOwnerTitle");
        //    HtmlTableRow trUpdtJointOwnerDOB = (HtmlTableRow)this.Page.Master.FindControl("trUpdtJointOwnerDOB");
        //    HtmlTableRow trUpdtJointOwnerPANNo = (HtmlTableRow)this.Page.Master.FindControl("trUpdtJointOwnerPANNo");
        //    HtmlTableRow trUpdtJointOwnerBankName = (HtmlTableRow)this.Page.Master.FindControl("trUpdtJointOwnerBankName");
        //    HtmlTableRow trUpdtJointOwnerBankAcctNo = (HtmlTableRow)this.Page.Master.FindControl("trUpdtJointOwnerBankAcctNo");
        //    HtmlTableRow trUpdtJointOwnerIFSCCode = (HtmlTableRow)this.Page.Master.FindControl("trUpdtJointOwnerIFSCCode");

        //    HtmlTableRow trUpdt2ndJointOwnerTitle = (HtmlTableRow)this.Page.Master.FindControl("trUpdt2ndJointOwnerTitle");
        //    HtmlTableRow trUpdt2ndJointOwnerDOB = (HtmlTableRow)this.Page.Master.FindControl("trUpdt2ndJointOwnerDOB");
        //    HtmlTableRow trUpdt2ndJointOwnerPANNo = (HtmlTableRow)this.Page.Master.FindControl("trUpdt2ndJointOwnerPANNo");
        //    HtmlTableRow trUpdt2ndJointOwnerBankName = (HtmlTableRow)this.Page.Master.FindControl("trUpdt2ndJointOwnerBankName");
        //    HtmlTableRow trUpdt2ndJointOwnerBankAcctNo = (HtmlTableRow)this.Page.Master.FindControl("trUpdt2ndJointOwnerBankAcctNo");
        //    HtmlTableRow trUpdt2ndJointOwnerIFSCCode = (HtmlTableRow)this.Page.Master.FindControl("trUpdt2ndJointOwnerIFSCCode");

        //    string strInvestorIndicationInfo = "";
        //    if (Session["InvID"] != null)
        //    {
        //        //// Don't change ROWS OPERATION ORDER and 5 CONTROL'S VISIBILITY SETTING ORDER
        //        //// Don't change ROWS OPERATION ORDER and 5 CONTROL'S VISIBILITY SETTING ORDER
        //        //// Don't change ROWS OPERATION ORDER and 5 CONTROL'S VISIBILITY SETTING ORDER
        //        DataSet dsInvInfo = InvestorBLL.SelectForInvestorUpdateIndication(new Guid(Convert.ToString(Session["InvID"])));
        //        DataRow dr = null;
        //        if (dsInvInfo != null && dsInvInfo.Tables.Count > 0)
        //        {
        //            if (dsInvInfo.Tables[0].Rows.Count > 0)
        //            {
        //                dr = dsInvInfo.Tables[0].Rows[0];
        //                if (Convert.ToString(dr["InvestorFullName"]) != string.Empty)
        //                {
        //                    trUpdateOwnerDOB.Visible = Convert.ToString(dr["DateOfBirth"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdateOwnerDOB.Visible ? "1|" : "0|";
        //                    trUpdateOwnerPANNo.Visible = Convert.ToString(dr["PanNo"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdateOwnerPANNo.Visible ? "1|" : "0|";
        //                    trUpdateOwnerBankName.Visible = Convert.ToString(dr["BankName"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdateOwnerBankName.Visible ? "1|" : "0|";
        //                    trUpdateOwnerBankAcctNo.Visible = Convert.ToString(dr["AccountNo"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdateOwnerBankAcctNo.Visible ? "1|" : "0|";
        //                    trUpdateOwnerIFSCCode.Visible = Convert.ToString(dr["IFSCCode"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdateOwnerIFSCCode.Visible ? "1|" : "0|";
        //                    trUpdtFristOwnerTitle.Visible = (trUpdateOwnerDOB.Visible || trUpdateOwnerPANNo.Visible || trUpdateOwnerBankName.Visible || trUpdateOwnerBankAcctNo.Visible || trUpdateOwnerIFSCCode.Visible);
        //                }
        //                else
        //                {
        //                    strInvestorIndicationInfo += "0|0|0|0|0|";
        //                    trUpdtFristOwnerTitle.Visible = trUpdateOwnerDOB.Visible = trUpdateOwnerPANNo.Visible = trUpdateOwnerBankName.Visible = trUpdateOwnerBankAcctNo.Visible = trUpdateOwnerIFSCCode.Visible = false;
        //                }
        //            }

        //            if (dsInvInfo.Tables[0].Rows.Count > 1)
        //            {
        //                dr = dsInvInfo.Tables[0].Rows[1];
        //                if (Convert.ToString(dr["InvestorFullName"]) != string.Empty)
        //                {
        //                    trUpdtJointOwnerDOB.Visible = Convert.ToString(dr["DateOfBirth"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdtJointOwnerDOB.Visible ? "1|" : "0|";
        //                    trUpdtJointOwnerPANNo.Visible = Convert.ToString(dr["PanNo"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdtJointOwnerPANNo.Visible ? "1|" : "0|";
        //                    trUpdtJointOwnerBankName.Visible = Convert.ToString(dr["BankName"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdtJointOwnerBankName.Visible ? "1|" : "0|";
        //                    trUpdtJointOwnerBankAcctNo.Visible = Convert.ToString(dr["AccountNo"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdtJointOwnerBankAcctNo.Visible ? "1|" : "0|";
        //                    trUpdtJointOwnerIFSCCode.Visible = Convert.ToString(dr["IFSCCode"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdtJointOwnerIFSCCode.Visible ? "1|" : "0|";
        //                    trUpdtJointOwnerTitle.Visible = (trUpdtJointOwnerDOB.Visible || trUpdtJointOwnerPANNo.Visible || trUpdtJointOwnerBankName.Visible || trUpdtJointOwnerBankAcctNo.Visible || trUpdtJointOwnerIFSCCode.Visible);
        //                }
        //                else
        //                {
        //                    strInvestorIndicationInfo += "0|0|0|0|0|";
        //                    trUpdtJointOwnerTitle.Visible = trUpdtJointOwnerDOB.Visible = trUpdtJointOwnerPANNo.Visible = trUpdtJointOwnerBankName.Visible = trUpdtJointOwnerBankAcctNo.Visible = trUpdtJointOwnerIFSCCode.Visible = false;
        //                }
        //            }

        //            if (dsInvInfo.Tables[0].Rows.Count > 2)
        //            {
        //                dr = dsInvInfo.Tables[0].Rows[2];
        //                if (Convert.ToString(dr["InvestorFullName"]) != string.Empty)
        //                {
        //                    trUpdt2ndJointOwnerDOB.Visible = Convert.ToString(dr["DateOfBirth"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdt2ndJointOwnerDOB.Visible ? "1|" : "0|";
        //                    trUpdt2ndJointOwnerPANNo.Visible = Convert.ToString(dr["PanNo"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdt2ndJointOwnerPANNo.Visible ? "1|" : "0|";
        //                    trUpdt2ndJointOwnerBankName.Visible = Convert.ToString(dr["BankName"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdt2ndJointOwnerBankName.Visible ? "1|" : "0|";
        //                    trUpdt2ndJointOwnerBankAcctNo.Visible = Convert.ToString(dr["AccountNo"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdt2ndJointOwnerBankAcctNo.Visible ? "1|" : "0|";
        //                    trUpdt2ndJointOwnerIFSCCode.Visible = Convert.ToString(dr["IFSCCode"]) == string.Empty;
        //                    strInvestorIndicationInfo += trUpdt2ndJointOwnerIFSCCode.Visible ? "1|" : "0|";
        //                    trUpdt2ndJointOwnerTitle.Visible = (trUpdt2ndJointOwnerDOB.Visible || trUpdt2ndJointOwnerPANNo.Visible || trUpdt2ndJointOwnerBankName.Visible || trUpdt2ndJointOwnerBankAcctNo.Visible || trUpdt2ndJointOwnerIFSCCode.Visible);
        //                }
        //                else
        //                {
        //                    strInvestorIndicationInfo += "0|0|0|0|0|";
        //                    trUpdt2ndJointOwnerTitle.Visible = trUpdt2ndJointOwnerDOB.Visible = trUpdt2ndJointOwnerPANNo.Visible = trUpdt2ndJointOwnerBankName.Visible = trUpdt2ndJointOwnerBankAcctNo.Visible = trUpdt2ndJointOwnerIFSCCode.Visible = false;
        //                }
        //            }

        //            tblUpdateIndication.Visible = (trUpdtFristOwnerTitle.Visible || trUpdtJointOwnerTitle.Visible || trUpdt2ndJointOwnerTitle.Visible);
        //            Session["InvestorIndicationInfo"] = strInvestorIndicationInfo;
        //        }
        //        else
        //        {
        //            //// No record found with session's investorID, so set 0000 value.
        //            Session["InvestorIndicationInfo"] = "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|";
        //            tblUpdateIndication.Visible = false;
        //            trUpdtFristOwnerTitle.Visible = trUpdateOwnerDOB.Visible = trUpdateOwnerPANNo.Visible = trUpdateOwnerBankName.Visible = trUpdateOwnerBankAcctNo.Visible = trUpdateOwnerIFSCCode.Visible = false;
        //            trUpdtJointOwnerTitle.Visible = trUpdtJointOwnerDOB.Visible = trUpdtJointOwnerPANNo.Visible = trUpdtJointOwnerBankName.Visible = trUpdtJointOwnerBankAcctNo.Visible = trUpdtJointOwnerIFSCCode.Visible = false;
        //            trUpdt2ndJointOwnerTitle.Visible = trUpdt2ndJointOwnerDOB.Visible = trUpdt2ndJointOwnerPANNo.Visible = trUpdt2ndJointOwnerBankName.Visible = trUpdt2ndJointOwnerBankAcctNo.Visible = trUpdt2ndJointOwnerIFSCCode.Visible = false;
        //        }

        //    }
        //    else
        //    {
        //        Session["InvestorIndicationInfo"] = "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|";
        //        tblUpdateIndication.Visible = false;
        //        trUpdtFristOwnerTitle.Visible = trUpdateOwnerDOB.Visible = trUpdateOwnerPANNo.Visible = trUpdateOwnerBankName.Visible = trUpdateOwnerBankAcctNo.Visible = trUpdateOwnerIFSCCode.Visible = false;
        //        trUpdtJointOwnerTitle.Visible = trUpdtJointOwnerDOB.Visible = trUpdtJointOwnerPANNo.Visible = trUpdtJointOwnerBankName.Visible = trUpdtJointOwnerBankAcctNo.Visible = trUpdtJointOwnerIFSCCode.Visible = false;
        //        trUpdt2ndJointOwnerTitle.Visible = trUpdt2ndJointOwnerDOB.Visible = trUpdt2ndJointOwnerPANNo.Visible = trUpdt2ndJointOwnerBankName.Visible = trUpdt2ndJointOwnerBankAcctNo.Visible = trUpdt2ndJointOwnerIFSCCode.Visible = false;
        //    }
        //}
        #endregion Private Method

        #region Update Investor Information
        /// <summary>
        /// Update Investor Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strInvalidDateOf = CheckDateOfBirthsValidation();
            if (strInvalidDateOf != "")
            {
                IsInsert = true;
                if (strInvalidDateOf.ToUpper() == "FIRSTOWNER")
                    lblInvestorMsg.Text = "Invalid Date of Birth of First Owner.";
                else if (strInvalidDateOf.ToUpper() == "JOINTOWNER")
                    lblInvestorMsg.Text = "Invalid Date of Birth of Joint Owner.";
                else if (strInvalidDateOf.ToUpper() == "2NDJOINTOWNER")
                    lblInvestorMsg.Text = "Invalid Date of Birth of 2nd Joint Owner.";

                return;
            }

            Investor OldGetData = InvestorBLL.GetByPrimaryKey(new Guid(Session["InvID"].ToString()));

            if (!txtInvEmail.Text.Trim().Equals(""))
            {
                User IsDup = new User();
                IsDup.UserName = txtInvEmail.Text.Trim();
                List<User> LstDupWing = UserBLL.GetAll(IsDup);
                if (LstDupWing.Count > 0)
                {
                    if (Session["InvID"] != null)
                    {
                        if (LstDupWing[0].UsearID != OldGetData.UserID)
                        {
                            IsInsert = true;
                            lblInvestorMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }
                }

                // If Currently changed email is different than old email, then ask confirmation first.
                if (OldGetData.EMail != txtInvEmail.Text.Trim())
                {
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

                    EmailNotification.Show();
                    return;
                }
            }

            Investor GetData = InvestorBLL.GetByPrimaryKey(new Guid(Session["InvID"].ToString()));
            if (GetData != null)
            {
                GetData.EMail = txtInvEmail.Text.Trim();

                if (txtInvMobileCntNo.Text.Equals(""))
                    GetData.MobileNo = litInvMobileNo.Text.Trim();
                else
                    GetData.MobileNo = txtInvMobileCntNo.Text.Trim() + "-" + litInvMobileNo.Text.Trim();

                Address InvCAddress = AddressBLL.GetByPrimaryKey(new Guid(GetData.PostalAddressID.ToString()));
                InvCAddress.Add1 = LitInvStreet.Text.Trim();
                InvCAddress.ZipCode = LitInvCPostCode.Text.Trim();
                InvCAddress.IsActive = true;
                InvCAddress.CountryID = clsCommon.Country(LitInvCCounty.Text.Trim());
                InvCAddress.StateID = clsCommon.State(LitCState.Text.Trim());
                InvCAddress.CityID = clsCommon.City(LitInvCCity.Text.Trim());

                LitInvPostCode.Text = LitInvCPostCode.Text.Trim();

                GetData.OccupationTermID = new Guid(Convert.ToString(litInvOccupation.SelectedValue));
                GetData.CompanyName = litInvCompanyName.Text.Trim();
                GetData.Designation = litInvDesignation.Text.Trim();

                GetData.RelationalName = txtRelationalName.Text.Trim();
                GetData.ContactPersonName = txtContactPersonName.Text.Trim();
                GetData.ContactPersonEmail = txtContactPersonEmail.Text.Trim();
                GetData.ContactPersonMobile = txtContactPersonMobile.Text.Trim();

                GetData.PanNo = txtPANNo.Text.Trim().Equals("") ? null : txtPANNo.Text.Trim();
                GetData.POAHolder = txtPOAHolder.Text.Trim().Equals("") ? null : txtPOAHolder.Text.Trim();
                GetData.BankName = txtBankName.Text.Trim().Equals("") ? null : txtBankName.Text.Trim();
                GetData.AccountNo = txtBankAccNo.Text.Trim().Equals("") ? null : txtBankAccNo.Text.Trim();
                GetData.BankAcctName = txtBankAcctHolderName.Text.Trim().Equals("") ? null : txtBankAcctHolderName.Text.Trim();
                GetData.IFSCCode = Convert.ToString(txtIFSCCode.Text.Trim());

                if (ddlDay.SelectedIndex != 0 || ddlMonth.SelectedIndex != 0 || ddlYear.SelectedIndex != 0)
                {
                    string DateOfBirth = Convert.ToString(ddlDay.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
                    GetData.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                }
                else
                    GetData.DateOfBirth = null;

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
                    GetData.Thumb = cmpPhoto;
                }

                IsInsert = true;
                lblInvestorMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                Session["InvID"] = Session["InvID"];
                InvestorBLL.Update(GetData, InvCAddress, null);

                ////Joint owner and 2nd joint owner's bank detail editable done by vijay b'cas told by Kush sir on 15 Dec 2012 meeting with Fedrick and Deshpande sir.
                //Ref Investor
                List<Investor> LstIns = InvestorBLL.GetAllBy(Investor.InvestorFields.RefInverstorID, Convert.ToString(Session["InvID"])); //ViewState["InvestorID"].ToString());
                LstIns.Sort((Investor inv1, Investor inv2) => inv1.SeqNo.CompareTo(inv2.SeqNo));
                Investor RefIns = (Investor)(LstIns[0]);

                RefIns.PanNo = txtRefPANNo.Text.Trim().Equals("") ? null : txtRefPANNo.Text.Trim();
                RefIns.POAHolder = txtRefPOAHolder.Text.Trim().Equals("") ? null : txtRefPOAHolder.Text.Trim();
                RefIns.BankName = txtRefBankNo.Text.Trim().Equals("") ? null : txtRefBankNo.Text.Trim();
                RefIns.AccountNo = txtRefBankAccNo.Text.Trim().Equals("") ? null : txtRefBankAccNo.Text.Trim();
                RefIns.BankAcctName = txtRefBankAcctHolderName.Text.Trim().Equals("") ? null : txtRefBankAcctHolderName.Text.Trim();
                RefIns.IFSCCode = Convert.ToString(txtRefIFSCCode.Text.Trim());

                RefIns.UpdatedOn = DateTime.Now.Date;
                RefIns.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));

                if (ddlRefDay.SelectedIndex != 0 || ddlRefMonth.SelectedIndex != 0 || ddlRefYear.SelectedIndex != 0)
                {
                    string DateOfBirth = Convert.ToString(ddlRefDay.SelectedValue.ToString().Trim() + "-" + ddlRefMonth.SelectedItem.Text.Trim() + "-" + ddlRefYear.SelectedValue.ToString().Trim());
                    RefIns.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                }
                else
                    RefIns.DateOfBirth = null;

                //Ref Investor Current Adderss Investor
                Address RefInvCAddress = AddressBLL.GetByPrimaryKey(new Guid(RefIns.AgreementAddressID.ToString()));
                //Present Address Investor
                Address RefInvPAddress = AddressBLL.GetByPrimaryKey(new Guid(RefIns.PostalAddressID.ToString()));
                InvestorBLL.Update(RefIns, RefInvCAddress, RefInvPAddress);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", RefIns.ToString(), RefIns.ToString(), "irm_Investor");

                //Second Joint Owner Investor

                if (LstIns.Count > 1 && LstIns[1] != null)
                {
                    //Update 

                    Investor SecondRefIns = (Investor)(LstIns[1]);

                    SecondRefIns.PanNo = txt2JOPanNo.Text.Trim().Equals("") ? null : txt2JOPanNo.Text.Trim();
                    SecondRefIns.POAHolder = txt2JOPOAHolder.Text.Trim().Equals("") ? null : txt2JOPOAHolder.Text.Trim();
                    SecondRefIns.BankName = txt2JOBankName.Text.Trim().Equals("") ? null : txt2JOBankName.Text.Trim();
                    SecondRefIns.AccountNo = txt2JOBankAccountNo.Text.Trim().Equals("") ? null : txt2JOBankAccountNo.Text.Trim();
                    SecondRefIns.BankAcctName = txt2JOBankAcctHolderName.Text.Trim().Equals("") ? null : txt2JOBankAcctHolderName.Text.Trim();
                    SecondRefIns.IFSCCode = Convert.ToString(txt2JOIFSCCode.Text.Trim());

                    SecondRefIns.UpdatedOn = DateTime.Now.Date;
                    SecondRefIns.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));

                    if (ddl2JODay.SelectedIndex != 0 || ddl2JOMonth.SelectedIndex != 0 || ddl2JOYear.SelectedIndex != 0)
                    {
                        string DateOfBirth = Convert.ToString(ddl2JODay.SelectedValue.ToString().Trim() + "-" + ddl2JOMonth.SelectedItem.Text.Trim() + "-" + ddl2JOYear.SelectedValue.ToString().Trim());
                        SecondRefIns.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                    }
                    else
                        SecondRefIns.DateOfBirth = null;

                    //Ref Investor Current Adderss Investor

                    Address SecondRefInvCAddress = AddressBLL.GetByPrimaryKey(new Guid(SecondRefIns.AgreementAddressID.ToString()));
                    //Present Address Investor
                    Address SecondRefInvPAddress = AddressBLL.GetByPrimaryKey(new Guid(SecondRefIns.PostalAddressID.ToString()));

                    InvestorBLL.Update(SecondRefIns, SecondRefInvCAddress, SecondRefInvPAddress);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", SecondRefIns.ToString(), SecondRefIns.ToString(), "irm_Investor");
                }
                ////Join owner and 2nd joint owner's bank detail editable end


                LoadInvestorValue();

                if (GetData.EMail.Equals(""))
                {
                    User Usr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetData.UserID)));
                    if (Usr != null)
                    {
                        Usr.UserName = GetData.EMail.Trim();
                        Usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        Usr.IsActive = false;
                        UserBLL.Update(Usr);
                    }
                    
                    // Don't logout user b'cas now Child/Parent investor implementation done and
                    // this make user sign out if child user is selected for login.
                    //Session.Clear();
                    //Session.Abandon();
                    //Response.Redirect("~/Default.aspx");
                    
                }

                ////Update Investor Indicatoin info in masterpage.
                //UpdateInvestorIndicationData();
            }
        }

        protected void btnSendEmailNotification_Click(object sender, EventArgs e)
        {
            Investor GetData = InvestorBLL.GetByPrimaryKey(new Guid(Session["InvID"].ToString()));
            if (GetData != null)
            {
                GetData.EMail = txtInvEmail.Text.Trim();

                if (txtInvMobileCntNo.Text.Equals(""))
                    GetData.MobileNo = litInvMobileNo.Text.Trim();
                else
                    GetData.MobileNo = txtInvMobileCntNo.Text.Trim() + "-" + litInvMobileNo.Text.Trim();

                Address InvCAddress = AddressBLL.GetByPrimaryKey(new Guid(GetData.PostalAddressID.ToString()));
                InvCAddress.Add1 = LitInvStreet.Text.Trim();
                InvCAddress.ZipCode = LitInvCPostCode.Text.Trim();
                InvCAddress.IsActive = true;
                InvCAddress.CountryID = clsCommon.Country(LitInvCCounty.Text.Trim());
                InvCAddress.StateID = clsCommon.State(LitCState.Text.Trim());
                InvCAddress.CityID = clsCommon.City(LitInvCCity.Text.Trim());

                LitInvPostCode.Text = LitInvCPostCode.Text.Trim();

                GetData.OccupationTermID = new Guid(Convert.ToString(litInvOccupation.SelectedValue));
                GetData.CompanyName = litInvCompanyName.Text.Trim();
                GetData.Designation = litInvDesignation.Text.Trim();

                if (Convert.ToString(hdnUploadPhoto.Value) != "")
                {
                    GetData.Thumb = Convert.ToString(hdnUploadPhoto.Value);
                }

                IsInsert = true;
                lblInvestorMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                Session["InvID"] = Session["InvID"];
                InvestorBLL.Update(GetData, InvCAddress, null);
                LoadInvestorValue();
                if (GetData.EMail.Equals(""))
                {
                    User Usr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetData.UserID)));
                    if (Usr != null)
                    {
                        Usr.UserName = GetData.EMail.Trim();
                        Usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        Usr.IsActive = false;
                        UserBLL.Update(Usr);
                    }
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx");
                }
                else if (!txtInvEmail.Text.Trim().Equals(""))
                {
                    User Usr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(GetData.UserID)));
                    if (Usr != null)
                    {
                        Usr.UserName = GetData.EMail.Trim();
                        Usr.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        //Usr.IsActive = true  email is not to sent and thats why not deactive user.
                        Usr.IsActive = true;
                        UserBLL.Update(Usr);
                    }
                    //SendEmail(GetData.InvestorID, Usr.Password, Usr.UserDisplayName, Usr.UsearID, Usr.PasswordKey);
                    //Response.Redirect("~/InvChangeEmail.aspx");
                }

                ////Update Investor Indicatoin info in masterpage.
                //UpdateInvestorIndicationData();
            }
        }

        protected void btnCancelEmailNotification_Click(object sender, EventArgs e)
        {
            txtInvEmail.Text = hfOldEmial.Value;
            EmailNotification.Hide();
        }

        #endregion Update Investor Information

        #region Remove Button Event
        /// <summary>
        /// Remove Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void HypRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["InvID"] != null)
                {
                    Investor GetImg = InvestorBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["InvID"])));
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

        #endregion Remove Button Event
    }
}