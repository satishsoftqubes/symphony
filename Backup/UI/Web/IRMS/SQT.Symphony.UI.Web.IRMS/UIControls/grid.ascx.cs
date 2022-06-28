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

namespace SQT.Symphony.UI.Web.IRMS.UIControls
{
    public partial class grid : System.Web.UI.UserControl
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
            if (!IsPostBack)
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

                BindGrid();
            }
        }
        #endregion PageLoad

        #region Private Method

        private void BindGrid()
        {
            try
            {
                tblDocument.Visible = false;
                string DocumentName = null;
                string Category = null;
                Guid? CreatedBy = null;

                if (!txtSearchDocument.Text.Trim().Equals(""))
                    DocumentName = txtSearchDocument.Text.Trim();

                if (ddlCategory.SelectedValue != Guid.Empty.ToString())
                    Category = ddlCategory.SelectedValue;

                string UserType = Convert.ToString(Session["UserType"]);

                if (UserType.ToUpper() == "ADMIN")
                    CreatedBy = null;
                else
                    CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                DataSet dsDocument = DocumentsBLL.GetAllDocument(null, null, CreatedBy, this.CompanyID, DocumentName, Category);
                gvDocumentList.DataSource = dsDocument.Tables[0];
                gvDocumentList.DataBind();
                mvDocument.Visible = dsDocument.Tables[0].Rows.Count > 0;
                gvDocumentList.HeaderRow.Attributes["style"] = "display:none";
                gvDocumentList.UseAccessibleHeader = true;
                gvDocumentList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
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


        #endregion Private Method

        #region Button Event
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
                    this.DocumentName = Convert.ToString(e.CommandArgument);
                    LoadDocument();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}