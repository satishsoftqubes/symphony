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
using System.Configuration;
using System.Web.UI.HtmlControls;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Globalization;
using System.Configuration;
using System.Text;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlGeneralDocumentList : System.Web.UI.UserControl
    {
        #region Variable
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

        public string DocumentName
        {
            get
            {
                return ViewState["DocumentName"] != null ? Convert.ToString(ViewState["DocumentName"]) : null;
            }
            set
            {
                ViewState["DocumentName"] = value;
            }
        }
        #endregion Variable

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("GeneralDocumentList.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            tblDocument.Visible = false;
            lblMessage.Text = "";
            lblDateErrorMsg.Visible = false;
            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }
        #endregion PageLoad

        #region Private Method

        private void BindGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                tblDocument.Visible = false;
                Guid? CreatedBy = null;
                DateTime? StartDate = null;
                DateTime? EndDate = null;
                string PropertyName = null;
                Guid? DocumentTypeID = null;
                string InvestorName = null;
                string RoomNo = null;

                //if (!txtSearchDocument.Text.Trim().Equals(""))
                //    DocumentName = txtSearchDocument.Text.Trim();

                //if (ddlCategory.SelectedValue != Guid.Empty.ToString())
                //    Category = ddlCategory.SelectedValue;

                string UserType = Convert.ToString(Session["UserType"]);

                if (UserType.ToUpper() == "ADMIN")
                    CreatedBy = null;
                else
                    CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                if (txtSearchFromDate.Text.Trim() != "")
                    StartDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (txtSearchToDate.Text.Trim() != "")
                    EndDate = DateTime.ParseExact(txtSearchToDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (ddlSearchPropertyName.SelectedValue != Guid.Empty.ToString())
                    PropertyName = Convert.ToString(ddlSearchPropertyName.SelectedItem.Text);

                if (ddlSearchDocumentType.SelectedValue != Guid.Empty.ToString())
                    DocumentTypeID = new Guid(ddlSearchDocumentType.SelectedValue);

                if (ddlInvestor.SelectedValue != Guid.Empty.ToString())
                    InvestorName = Convert.ToString(ddlInvestor.SelectedItem.Text);

                if (txtSearchUnitNo.Text.Trim() != "")
                    RoomNo = Convert.ToString(txtSearchUnitNo.Text.Trim());


                // DataSet dsDocument = DocumentsBLL.GetAllDocument(null, null, CreatedBy, this.CompanyID, DocumentName, Category);


                DataSet dsSearchDocument = DocumentsBLL.SelectDocumentByCriteria(Convert.ToString(ddlCategory.SelectedValue), CreatedBy, this.CompanyID, StartDate, EndDate, PropertyName, DocumentTypeID, InvestorName, RoomNo);

                gvDocumentList.DataSource = dsSearchDocument.Tables[0];
                gvDocumentList.DataBind();
                mvDocument.Visible = dsSearchDocument.Tables[0].Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadInvestor()
        {
            Guid? RelationShipManagerID = null;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN" || UserType.ToUpper() == "INVESTOR")
                RelationShipManagerID = null;
            else
                RelationShipManagerID = new Guid(Convert.ToString(Session["UserTypeID"]));
            DataSet ds = InvestorBLL.SearchInfo(null, null, null, null, null, null, RelationShipManagerID, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlInvestor.DataSource = ds;
                ddlInvestor.DataTextField = "InvestorName";
                ddlInvestor.DataValueField = "InvestorName";
                ddlInvestor.DataBind();
            }
            ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            if (Convert.ToString(Session["InvID"]) != Guid.Empty.ToString() && Session["InvID"] != null)
                ddlInvestor.SelectedValue = Convert.ToString(Session["InvID"]);
        }


        public string GetName(object path)
        {
            string str = Convert.ToString(path);
            string[] DocumentType = str.Split(new char[] { '$' });

            if (DocumentType.Length != 0)
                return DocumentType[2];
            else
                return "NA";
        }

        private void LoadDocument()
        {
            string strDocName = Convert.ToString(this.DocumentName);
            string strExt = strDocName.Substring(strDocName.LastIndexOf(".") + 1);
            string str = "~/Document/" + strDocName;
            string mappath = Server.MapPath(str);
            FileInfo f = new FileInfo(mappath);
            if (f.Exists)
            {
                lblMessage.Text = "";
                if (strExt.ToUpper() == "PDF")
                {
                    tblDocument.Visible = true;
                    string strPDFPath = Convert.ToString(ConfigurationSettings.AppSettings["forPDFpath"]) + strDocName;
                    fileview.Attributes["src"] = strPDFPath;
                    mvDocument.ActiveViewIndex = 0;
                }
                else if (strExt.ToUpper() == "JPG" || strExt.ToUpper() == "JPEG" || strExt.ToUpper() == "BMP" || strExt.ToUpper() == "PNG" || strExt.ToUpper() == "GIF")
                {
                    tblDocument.Visible = true;
                    imgImageDoc.ImageUrl = str;
                    // imgImageDoc.ImageUrl = mappath;
                    mvDocument.ActiveViewIndex = 1;
                }
                else
                {
                    tblDocument.Visible = false;
                    //string filepath = Server.MapPath("~") + strDocName;
                    //mvDocument.ActiveViewIndex = 0;
                    // Create New instance of FileInfo class to get the properties of the file being downloaded
                    FileInfo file = new FileInfo(mappath);

                    // Checking if file exists
                    if (file.Exists)
                    {
                        Response.ClearContent();

                        // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

                        // Add the file size into the response header
                        Response.AddHeader("Content-Length", file.Length.ToString());

                        // Set the ContentType
                        Response.ContentType = ReturnExtension(file.Extension.ToLower());

                        // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                        //Response.TransmitFile(file.FullName);
                        Response.TransmitFile(mappath);
                        // End the response
                        Response.End();

                    }
                }
            }
            else
                lblMessage.Text = "No any record found";
        }

        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        private void ClearSearch()
        {
            txtSearchFromDate.Text = txtSearchToDate.Text =  txtSearchUnitNo.Text = "";
            ddlSearchPropertyName.SelectedIndex = 0;
            ddlInvestor.SelectedIndex = 0;
            ddlSearchDocumentType.Items.Clear();
            //ddlSearchPropertyName.Items.Clear();

            ddlSearchDocumentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            // ddlSearchPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            //gvDocumentList.DataSource = null;
            //gvDocumentList.DataBind();
        }

        private void BindProperty()
        {
            ddlSearchPropertyName.Items.Clear();
            List<Property> lstProperty = null;
            Property objProperty = new Property();
            objProperty.CompanyID = this.CompanyID;
            lstProperty = PropertyBLL.GetAll(objProperty);

            if (lstProperty.Count != 0)
            {
                lstProperty.Sort((Property p1, Property p2) => p1.PropertyName.CompareTo(p2.PropertyName));
                ddlSearchPropertyName.DataSource = lstProperty;
                ddlSearchPropertyName.DataTextField = "PropertyName";
                ddlSearchPropertyName.DataValueField = "PropertyID";
                ddlSearchPropertyName.DataBind();
                ddlSearchPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlSearchPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }


        }

        private void LoadDefaultValue()
        {
            try
            {
                if (Session["CompanyID"] != null)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    if (Session["PropertyConfigurationInfo"] != null)
                    {
                        PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];

                        string ProjectTermQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And CompanyID= '" + this.CompanyID + "' And TermID= '" + objPropertyConfiguration.DateFormatID + "'";
                        DataSet ds = ProjectTermBLL.SelectData(ProjectTermQuery);

                        if (ds.Tables[0].Rows.Count != 0)
                            this.DateFormat = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
                        else
                            this.DateFormat = "dd/MM/yyyy";
                    }
                    else
                        this.DateFormat = "dd/MM/yyyy";

                    BindProperty();
                    LoadInvestor();
                    calFromDate.Format = calToDate.Format = this.DateFormat;
                    ClearSearch();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDocumentType()
        {
            ddlSearchDocumentType.Items.Clear();

            if (ddlCategory.SelectedValue != Guid.Empty.ToString())
            {
                if (ddlCategory.SelectedValue == "Property")
                {
                    List<ProjectTerm> lstProjectTerm = null;
                    ProjectTerm objProjectTerm = new ProjectTerm();
                    objProjectTerm.CompanyID = this.CompanyID;
                    objProjectTerm.Category = "PROPERTY DOCUMENT";
                    objProjectTerm.IsActive = true;

                    lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);

                    if (lstProjectTerm.Count != 0)
                    {
                        lstProjectTerm.Sort((ProjectTerm p1, ProjectTerm p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));
                        ddlSearchDocumentType.DataSource = lstProjectTerm;
                        ddlSearchDocumentType.DataTextField = "DisplayTerm";
                        ddlSearchDocumentType.DataValueField = "TermID";
                        ddlSearchDocumentType.DataBind();

                        ddlSearchDocumentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlSearchDocumentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else if (ddlCategory.SelectedValue == "Investor")
                {
                    string strProjectTerm = "select TermID,Term,DisplayTerm,CompanyID from mst_ProjectTerm where Category in ('INVESTOR UNIT DOCUMENT','Investor Document') and IsActive = 1 and CompanyID = '14F1A0DC-3A5B-4E7E-9869-96979A03EA3A' order by DisplayTerm asc";
                    DataSet dsProjectTerm = ProjectTermBLL.SelectData(strProjectTerm);
                    if (dsProjectTerm.Tables.Count > 0 && dsProjectTerm.Tables[0].Rows.Count > 0)
                    {
                        ddlSearchDocumentType.DataSource = dsProjectTerm.Tables[0];
                        ddlSearchDocumentType.DataTextField = "DisplayTerm";
                        ddlSearchDocumentType.DataValueField = "TermID";
                        ddlSearchDocumentType.DataBind();

                        ddlSearchDocumentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlSearchDocumentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            else
                ddlSearchDocumentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        } 

        #endregion Private Method

        #region Button Event
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtSearchFromDate.Text.Trim() != string.Empty && txtSearchToDate.Text.Trim() != string.Empty)
                {
                    if (Convert.ToDateTime(txtSearchFromDate.Text.Trim()) > Convert.ToDateTime(txtSearchToDate.Text.Trim()))
                    {
                        lblDateErrorMsg.Visible = true;
                        lblDateErrorMsg.Text = "*";
                        return;
                    }
                    else
                    {
                        lblDateErrorMsg.Visible = false;
                        lblDateErrorMsg.Text = "";
                    }
                }
                else
                {
                    lblDateErrorMsg.Visible = false;
                    lblDateErrorMsg.Text = "";
                }

                gvDocumentList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPDFCancel_Click(object sender, EventArgs e)
        {
            try
            {
                tblDocument.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnImageCancel_Click(object sender, EventArgs e)
        {
            try
            {
                tblDocument.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Grid Method

        protected void gvDocumentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("View"))
                {
                    //this.DocumentName = Convert.ToString(e.CommandArgument);

                    string fName = Server.MapPath("~/Document") + "\\" + Convert.ToString(e.CommandArgument);
                    FileInfo fi = new FileInfo(fName);
                    long sz = fi.Length;
                    Response.ClearContent();
                    Response.ContentType = MimeType(Path.GetExtension(fName));
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fName)));
                    Response.AddHeader("Content-Length", sz.ToString("F0"));
                    Response.TransmitFile(fName);
                    Response.End();

                    //LoadDocument();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDocumentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDocumentList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Dropdown Event

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearSearch();
            gvDocumentList.DataSource = null;
            gvDocumentList.DataBind();
            if (ddlCategory.SelectedValue != Guid.Empty.ToString())
            {
                if (ddlCategory.SelectedValue == "Company")
                {
                    trPropandDoc.Visible = trInvandUnit.Visible = trDate.Visible = false;
                    btnPropertySearch.Visible = btnInvestorSearch.Visible = false;
                    btnSearch.Visible = true;
                }
                else if (ddlCategory.SelectedValue == "Property")
                {
                    trPropandDoc.Visible = trDate.Visible = true;
                    trInvandUnit.Visible = false;
                    BindDocumentType();
                    btnSearch.Visible = btnInvestorSearch.Visible = false;
                    btnPropertySearch.Visible = true;
                }
                else if (ddlCategory.SelectedValue == "Investor")
                {
                    trPropandDoc.Visible = trInvandUnit.Visible = trDate.Visible = true;
                    BindDocumentType();
                    btnSearch.Visible = btnPropertySearch.Visible = false;
                    btnInvestorSearch.Visible = true;
                }
            }
            else
            {
                gvDocumentList.DataSource = null;
                gvDocumentList.DataBind();
                btnSearch.Visible = btnPropertySearch.Visible = btnInvestorSearch.Visible = false;
                trPropandDoc.Visible = trInvandUnit.Visible = trDate.Visible = false;
            }
        }

        #endregion  Dropdown Event
    }
}