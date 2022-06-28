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
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlCompanyInfo : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsInsert = false;
        public bool IsUpdate = false;

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (RoleRightJoinBLL.GetAccessString("CompanySetup.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            if (!IsPostBack)
                LoadDefaultData();
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Data
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                //BindOrganizationType();
                BindCompanyType();
                BindBusinessDomain();
                BindCompanyData();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("CompanySetup.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Update"] = HypRemove.Visible = btnSave.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Company Data
        /// </summary>
        private void BindCompanyData()
        {
            List<Company> lstLoadCompanyData = null;
            Company objCompany = new Company();
            if (Session["CompanyID"] != null)
                objCompany.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
            lstLoadCompanyData = CompanyBLL.GetAll(objCompany);

            if (lstLoadCompanyData.Count != 0)
            {
                Company objLoadCompanyData = lstLoadCompanyData[0];

                txtCompanyName.Text = Convert.ToString(objLoadCompanyData.CompanyName);
                txtDisplayName.Text = Convert.ToString(objLoadCompanyData.DisplayName);
                txtCompanyCode.Text = Convert.ToString(objLoadCompanyData.CompanyCode);
                //txtPrimaryContactName.Text = Convert.ToString(objLoadCompanyData.PrimaryContactName);
                // txtPrimoryEmailAddress.Text = Convert.ToString(objLoadCompanyData.PrimoryEmailAddress);
                // txtPrimoryContactNo.Text = Convert.ToString(objLoadCompanyData.PrimoryContactNo);
                //if (Convert.ToString(objLoadCompanyData.OrganizationType) != null && Convert.ToString(objLoadCompanyData.OrganizationType) != "")
                //    ddlOrganizationType.SelectedValue = Convert.ToString(objLoadCompanyData.OrganizationType);
                //if (Convert.ToString(objLoadCompanyData.BusinessDomain) != null && Convert.ToString(objLoadCompanyData.BusinessDomain) != "")
                //    ddlBusinessDomain.SelectedValue = Convert.ToString(objLoadCompanyData.BusinessDomain);
                ddlBusinessDomain.SelectedIndex = ddlBusinessDomain.Items.FindByValue(Convert.ToString(objLoadCompanyData.BusinessDomain.Trim())) != null ? ddlBusinessDomain.Items.IndexOf(ddlBusinessDomain.Items.FindByValue(Convert.ToString(objLoadCompanyData.BusinessDomain.Trim()))) : 0;
                //txtApplicableRegNo.Text = Convert.ToString(objLoadCompanyData.ApplicableRegNo);
                //txtYearbyTurnover.Text = Convert.ToString(objLoadCompanyData.YearbyTurnover);
                txtAddressLine1.Text = Convert.ToString(objLoadCompanyData.PrimaryAdd1);
                txtAddressLine2.Text = Convert.ToString(objLoadCompanyData.PrimaryAdd2);
                txtCountryName.Text = Convert.ToString(objLoadCompanyData.PrimaryCountry);
                txtStateName.Text = Convert.ToString(objLoadCompanyData.PrimaryState);
                txtCityName.Text = Convert.ToString(objLoadCompanyData.PrimaryCity);
                txtPostCode.Text = Convert.ToString(objLoadCompanyData.PrimaryZipCode);
                txtPhoneNo.Text = Convert.ToString(objLoadCompanyData.PrimaryPhone);
                txtEmail.Text = Convert.ToString(objLoadCompanyData.PrimaryEmail);
                txtFax.Text = Convert.ToString(objLoadCompanyData.PrimaryFax);
                txtURL.Text = Convert.ToString(objLoadCompanyData.PrimaryUrl);
                imgCompany.ImageUrl = "~/UploadPhoto/" + Convert.ToString(objLoadCompanyData.Thumb);
                if (objLoadCompanyData.Thumb.ToUpper().ToString().Trim() == "BLANKPHOTO.JPG")
                    HypRemove.Visible = false;
                else
                    HypRemove.Visible = Convert.ToBoolean(ViewState["Update"]);


                if (Convert.ToString(objLoadCompanyData.CompanyType) != null && Convert.ToString(objLoadCompanyData.CompanyType) != "")
                    ddlTypeOfCompany.SelectedValue = Convert.ToString(objLoadCompanyData.CompanyType);

                BindDocumentGrid(objLoadCompanyData.CompanyID);

                //if (Convert.ToString(objLoadCompanyData.Thumb) == "BlankPhoto.jpg")
                //    HypRemove.Visible = false;
                //else
                //    HypRemove.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);

                Guid? CmpID = lstLoadCompanyData[0].CompanyID;
                DataSet ds = CompanyBLL.GetCompanyData(CmpID);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtAddressLine2.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdminAddress"]);
                    txtAdminCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdminCity"]);
                    txtAdminCountry.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdminCounty"]);
                    txtAdminState.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdminState"]);
                    txtAdminPostCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdminZipCode"]);
                }
            }
            else
            {
                imgCompany.ImageUrl = "~/UploadPhoto/BlankPhoto.jpg";
                HypRemove.Visible = false;
            }
        }
        private void BindDocumentGrid(Guid? CompanyID)
        {
            DataSet dsDocumentList = DocumentsBLL.GetDocumentGrid(null, null, CompanyID, "COMPANY DOCUMENT", CompanyID);
            if (dsDocumentList.Tables[0].Rows.Count != 0)
            {
                gvDocument.DataSource = dsDocumentList.Tables[0];
                gvDocument.DataBind();
            }
        }
        //private void BindOrganizationType()
        //{
        //    List<ProjectTerm> lstProjectTermBOT = null;
        //    ProjectTerm objProjectTermBOT = new ProjectTerm();
        //    objProjectTermBOT.IsActive = true;
        //    objProjectTermBOT.Category = "ORTYPE";

        //    lstProjectTermBOT = ProjectTermBLL.GetAll(objProjectTermBOT);

        //    if (lstProjectTermBOT.Count != 0)
        //    {
        //        ddlOrganizationType.DataSource = lstProjectTermBOT;
        //        ddlOrganizationType.DataTextField = "Term";
        //        ddlOrganizationType.DataValueField = "Term";
        //        ddlOrganizationType.DataBind();
        //        ddlOrganizationType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlOrganizationType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //}

        /// <summary>
        /// Load Business Domain
        /// </summary>
        private void BindBusinessDomain()
        {
            List<ProjectTerm> lstProjectTermBD = null;
            ProjectTerm objProjectTermBD = new ProjectTerm();
            objProjectTermBD.IsActive = true;
            objProjectTermBD.Category = "BUSDOM";
            objProjectTermBD.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

            lstProjectTermBD = ProjectTermBLL.GetAll(objProjectTermBD);

            if (lstProjectTermBD.Count != 0)
            {
                lstProjectTermBD.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlBusinessDomain.DataSource = lstProjectTermBD;
                ddlBusinessDomain.DataTextField = "DisplayTerm";
                ddlBusinessDomain.DataValueField = "Term";
                ddlBusinessDomain.DataBind();
                ddlBusinessDomain.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlBusinessDomain.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Company Type
        /// </summary>
        private void BindCompanyType()
        {
            List<ProjectTerm> lstProjectTermCT = null;
            ProjectTerm objProjectTermCT = new ProjectTerm();
            objProjectTermCT.IsActive = true;
            objProjectTermCT.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
            objProjectTermCT.Category = "CompanyType";

            lstProjectTermCT = ProjectTermBLL.GetAll(objProjectTermCT);

            if (lstProjectTermCT.Count != 0)
            {
                lstProjectTermCT.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlTypeOfCompany.DataSource = lstProjectTermCT;
                ddlTypeOfCompany.DataTextField = "DisplayTerm";
                ddlTypeOfCompany.DataValueField = "TermID";
                ddlTypeOfCompany.DataBind();
                ddlTypeOfCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlTypeOfCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        #endregion Private Method

        #region Control Event
        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/Index.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Button Save And Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<Country> lstInsCounty1 = null;
                    Country objInsCounty1 = new Country();
                    List<State> lstInsState1 = null;
                    State objInsState1 = new State();
                    List<City> lstInsCity1 = null;
                    City objInsCity1 = new City();

                    List<Company> lstCompanyData = null;
                    List<Company> lstOldCompanyData = null;
                    List<Documents> lstDocuments = new List<Documents>();

                    Company objCmp = new Company();
                    if (Session["CompanyID"] != null)
                        objCmp.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    lstCompanyData = CompanyBLL.GetAll(objCmp);

                    if (lstCompanyData.Count != 0)
                    {
                        Company objUpd = new Company();
                        Company objOldCmpData = new Company();

                        objUpd = lstCompanyData[0];

                        lstOldCompanyData = CompanyBLL.GetAll();
                        objOldCmpData = lstOldCompanyData[0];

                        objUpd.CompanyName = txtCompanyName.Text.Trim();
                        objUpd.DisplayName = txtDisplayName.Text.Trim();
                        objUpd.CompanyCode = txtCompanyCode.Text.Trim();

                        if (ddlBusinessDomain.SelectedValue != Guid.Empty.ToString())
                            objUpd.BusinessDomain = ddlBusinessDomain.SelectedValue.Trim();
                        else
                            objUpd.BusinessDomain = null;
                        objUpd.PrimaryAdd1 = txtAddressLine1.Text.Trim();
                        objUpd.PrimaryAdd2 = txtAddressLine2.Text.Trim();
                        if (ddlTypeOfCompany.SelectedValue != Guid.Empty.ToString())
                            objUpd.CompanyType = new Guid(ddlTypeOfCompany.SelectedValue);
                        else
                            objUpd.CompanyType = null;

                        List<Country> lstInsCounty = null;
                        Country objInsCounty = new Country();
                        List<State> lstInsState = null;
                        State objInsState = new State();
                        List<City> lstInsCity = null;
                        City objInsCity = new City();

                        if (txtCountryName.Text.Trim() != "")
                        {
                            objInsCounty.CountryName = txtCountryName.Text.Trim();
                            objInsCounty.IsActive = true;
                            lstInsCounty = CountryBLL.GetAll(objInsCounty);

                            if (lstInsCounty.Count == 0)
                                CountryBLL.Save(objInsCounty);
                            else
                                objInsCounty = (Country)(lstInsCounty[0]);

                            objUpd.PrimaryCountry = txtCountryName.Text.Trim();
                        }
                        else
                            objUpd.PrimaryCountry = null;

                        if (txtStateName.Text.Trim() != "")
                        {
                            objInsState.StateName = txtStateName.Text.Trim();
                            objInsState.IsActive = true;
                            lstInsState = StateBLL.GetAll(objInsState);

                            if (lstInsState.Count == 0)
                            {
                                StateBLL.Save(objInsState);
                            }
                            else
                                objInsState = (State)(lstInsState[0]);

                            objUpd.PrimaryState = txtStateName.Text.Trim();
                        }
                        else
                            objUpd.PrimaryState = null;

                        if (txtCityName.Text.Trim() != "")
                        {
                            objInsCity.CityName = txtCityName.Text.Trim();
                            objInsCity.IsActive = true;
                            lstInsCity = CityBLL.GetAll(objInsCity);

                            if (lstInsCity.Count == 0)
                            {
                                CityBLL.Save(objInsCity);
                            }
                            objUpd.PrimaryCity = txtCityName.Text.Trim();
                        }
                        else
                            objUpd.PrimaryCity = null;

                        objUpd.PrimaryZipCode = txtPostCode.Text.Trim();
                        objUpd.PrimaryPhone = txtPhoneNo.Text.Trim();
                        objUpd.PrimaryEmail = txtEmail.Text.Trim();
                        objUpd.PrimaryFax = txtFax.Text.Trim();
                        objUpd.PrimaryUrl = txtURL.Text.Trim();

                        Address objUpdateAddress = new Address();
                        objUpdateAddress = AddressBLL.GetByPrimaryKey((Guid)objUpd.PrimaryAddID);
                        if (objUpdateAddress == null)
                            objUpdateAddress = new Address();


                        objUpdateAddress.CountryID = clsCommon.Country(txtAdminCountry.Text.Trim());
                        objUpdateAddress.StateID = clsCommon.State(txtAdminState.Text.Trim()); 
                        objUpdateAddress.CityID = clsCommon.City(txtAdminCity.Text.Trim()); 

                        if (txtAdminCity.Text.Trim() != "")
                            objUpdateAddress.City = txtAdminCity.Text.Trim();
                        else
                            objUpdateAddress.City = null;

                        objUpdateAddress.Add1 = txtAddressLine2.Text.Trim();
                        objUpdateAddress.ZipCode = txtAdminPostCode.Text.Trim();

                        for (int i = 0; i < gvDocument.Rows.Count; i++)
                        {
                            TextBox txtStatutoryName = (TextBox)gvDocument.Rows[i].FindControl("txtStatutoryName");
                            FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");
                            HiddenField hdnDocumentName = (HiddenField)gvDocument.Rows[i].FindControl("hdnDocumentName");

                            if (fuDocument.FileName != "")
                            {
                                Documents d1 = new Documents();
                                string FileInCorporatonNo = "CD$" + Guid.NewGuid().ToString().Substring(0, 7) + "$" + fuDocument.FileName.Replace(" ", "_");
                                string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Company";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtStatutoryName.Text.Trim();
                                d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                lstDocuments.Add(d1);
                            }
                            else if (hdnDocumentName.Value != "")
                            {
                                Documents d5 = new Documents();
                                d5.DocumentName = hdnDocumentName.Value;
                                d5.Extension = System.IO.Path.GetExtension(hdnDocumentName.Value);
                                d5.DateOfSubmission = DateTime.Now;
                                d5.CreatedOn = DateTime.Now;
                                d5.IsActive = true;
                                d5.AssociationType = "Company";
                                d5.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d5.Notes = txtStatutoryName.Text.Trim();
                                d5.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                lstDocuments.Add(d5);
                            }
                        }

                        if (UplodFile.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "$" + UplodFile.FileName.Replace(" ", "_");
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

                            objUpd.Thumb = cmpPhoto;
                        }

                        // objUpd.PrimaryContactName = txtPrimaryContactName.Text.Trim();
                        //  objUpd.PrimoryEmailAddress = txtPrimoryEmailAddress.Text.Trim();
                        //  objUpd.PrimoryContactNo = txtPrimoryContactNo.Text.Trim();
                        //if (ddlOrganizationType.SelectedValue != Guid.Empty.ToString())
                        //    objUpd.OrganizationType = ddlOrganizationType.SelectedValue;
                        //else
                        //    objUpd.OrganizationType = null;
                        //objUpd.ApplicableRegNo = txtApplicableRegNo.Text.Trim();
                        //objUpd.YearbyTurnover = Convert.ToDecimal(txtYearbyTurnover.Text.Trim());

                        CompanyBLL.Update(objUpd, objUpdateAddress, lstDocuments);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldCmpData.ToString(), objUpd.ToString(), "mst_Company");
                        IsUpdate = true;
                        lblUpdate.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        Company objIns = new Company();

                        objIns.CompanyID = Guid.NewGuid();
                        objIns.CompanyName = txtCompanyName.Text.Trim();
                        objIns.DisplayName = txtDisplayName.Text.Trim();
                        objIns.CompanyCode = txtCompanyCode.Text.Trim();
                        if (ddlBusinessDomain.SelectedValue != Guid.Empty.ToString())
                            objIns.BusinessDomain = ddlBusinessDomain.SelectedValue;
                        else
                            objIns.BusinessDomain = null;
                        objIns.PrimaryAdd1 = txtAddressLine1.Text.Trim();
                        objIns.PrimaryAdd2 = txtAddressLine2.Text.Trim();
                        if (ddlTypeOfCompany.SelectedValue != Guid.Empty.ToString())
                            objIns.CompanyType = new Guid(ddlTypeOfCompany.SelectedValue.Trim());
                        else
                            objIns.CompanyType = null;
                        objIns.IsActive = true;
                        List<Country> lstInsCounty = null;
                        Country objInsCounty = new Country();
                        List<State> lstInsState = null;
                        State objInsState = new State();
                        List<City> lstInsCity = null;
                        City objInsCity = new City();


                        if (txtCountryName.Text.Trim() != "")
                        {
                            objInsCounty.CountryName = txtCountryName.Text.Trim();
                            objInsCounty.IsActive = true;
                            lstInsCounty = CountryBLL.GetAll(objInsCounty);

                            if (lstInsCounty.Count == 0)
                                CountryBLL.Save(objInsCounty);
                            else
                                objInsCounty = (Country)(lstInsCounty[0]);

                            objIns.PrimaryCountry = txtCountryName.Text.Trim();
                        }

                        if (txtStateName.Text.Trim() != "")
                        {
                            objInsState.StateName = txtStateName.Text.Trim();
                            objInsState.IsActive = true;
                            lstInsState = StateBLL.GetAll(objInsState);

                            if (lstInsState.Count == 0)
                            {                                
                                StateBLL.Save(objInsState);
                            }
                            else
                                objInsState = (State)(lstInsState[0]);

                            objIns.PrimaryState = txtStateName.Text.Trim();
                        }

                        if (txtCityName.Text.Trim() != "")
                        {
                            objInsCity.CityName = txtCityName.Text.Trim();
                            objInsCity.IsActive = true;
                            lstInsCity = CityBLL.GetAll(objInsCity);

                            if (lstInsCity.Count == 0)
                            {                                
                                CityBLL.Save(objInsCity);
                            }
                            objIns.PrimaryCity = txtCityName.Text.Trim();
                        }

                        objIns.PrimaryZipCode = txtPostCode.Text.Trim();
                        objIns.PrimaryPhone = txtPhoneNo.Text.Trim();
                        objIns.PrimaryEmail = txtEmail.Text.Trim();
                        objIns.PrimaryFax = txtFax.Text.Trim();
                        objIns.PrimaryUrl = txtURL.Text.Trim();

                        Address objSaveAddress = new Address();
                        objSaveAddress.CountryID = clsCommon.Country(txtAdminCountry.Text.Trim());
                        objSaveAddress.StateID = clsCommon.State(txtAdminState.Text.Trim());
                        objSaveAddress.CityID = clsCommon.City(txtAdminCity.Text.Trim());

                        if (txtAdminCity.Text.Trim() != "")
                            objSaveAddress.City = txtAdminCity.Text.Trim();
                        else
                            objSaveAddress.City = null;

                        objSaveAddress.Add1 = txtAddressLine2.Text.Trim();
                        objSaveAddress.ZipCode = txtAdminPostCode.Text.Trim();

                        for (int i = 0; i < gvDocument.Rows.Count; i++)
                        {
                            TextBox txtStatutoryName = (TextBox)gvDocument.Rows[i].FindControl("txtStatutoryName");
                            FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");
                            if (fuDocument.FileName != "")
                            {
                                Documents d1 = new Documents();
                                string FileInCorporatonNo = "CD$" + Guid.NewGuid().ToString().Substring(0, 7) + "$" + fuDocument.FileName.Replace(" ", "_");
                                string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Company";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtStatutoryName.Text.Trim();
                                d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                lstDocuments.Add(d1);
                            }
                        }

                        if (UplodFile.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "$" + UplodFile.FileName.Replace(" ", "_");
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

                            objIns.Thumb = cmpPhoto;
                        }
                        else
                            objIns.Thumb = "BlankPhoto.jpg";

                        // objIns.PrimaryContactName = txtPrimaryContactName.Text.Trim();
                        // objIns.PrimoryEmailAddress = txtPrimoryEmailAddress.Text.Trim();
                        // objIns.PrimoryContactNo = txtPrimoryContactNo.Text.Trim();
                        //if (ddlOrganizationType.SelectedValue != Guid.Empty.ToString())
                        //    objIns.OrganizationType = ddlOrganizationType.SelectedValue;
                        //else
                        //    objIns.OrganizationType = null;
                        //objIns.ApplicableRegNo = txtApplicableRegNo.Text.Trim();
                        //objIns.YearbyTurnover = Convert.ToDecimal(txtYearbyTurnover.Text.Trim());

                        CompanyBLL.Save(objIns, objSaveAddress, lstDocuments);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "mst_Company");
                        IsInsert = true;
                        lblInsert.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    BindCompanyData();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// HyperLink Photo Remove Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HypRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Company objCompany = new Company();
                if (Session["CompanyID"] != null)
                    objCompany.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                List<Company> lstBindCompanyData = null;
                lstBindCompanyData = CompanyBLL.GetAll(objCompany);
                if (lstBindCompanyData.Count != 0)
                {
                    Company objUpdImage = new Company();
                    objUpdImage = lstBindCompanyData[0];
                    string deletepath = Server.MapPath("~/UploadPhoto/") + Convert.ToString(objUpdImage.Thumb);
                    if (objUpdImage.Thumb.ToString().ToUpper() != "BLANKPHOTO.JPG")
                        File.Delete(deletepath);
                    objUpdImage.Thumb = "BlankPhoto.jpg";
                    CompanyBLL.Update(objUpdImage);
                    BindCompanyData();
                    IsUpdate = true;
                    lblUpdate.Text = global::Resources.IRMSMsg.RemovePhotoMsg.ToString().Trim();
                }
                else
                {
                    imgCompany.ImageUrl = "~/UploadPhoto/BlankPhoto.jpg";
                    HypRemove.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Grid Event

        protected void gvDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    string DocumentName = string.Empty;
                    DocumentName = DataBinder.Eval(e.Row.DataItem, "DocumentName").ToString();
                    string str = "~/Document/" + DocumentName;

                    HtmlAnchor aDocumentLink = (HtmlAnchor)e.Row.FindControl("aDocumentLink");
                    ImageButton btnDelete = (ImageButton)e.Row.FindControl("btnDelete");
                    if (DocumentName != string.Empty && DocumentName != null)
                    {
                        aDocumentLink.Visible = true;
                        //bnt.Visible = true;
                        aDocumentLink.HRef = str;
                        btnDelete.Visible = Convert.ToBoolean(ViewState["Delete"]);
                    }
                    else
                    {
                        aDocumentLink.Visible = false;
                        btnDelete.Visible = false;
                        //bnt.Visible = false;
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
        /// Row Command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                BindDocumentGrid(new Guid(Convert.ToString(Session["CompanyID"])));
            }
        }

        #endregion
    }
}