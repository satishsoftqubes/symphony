using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;
using System.Collections;
using System.Resources;

namespace SQT.Symphony.UI.Web.Configuration.GUI.Configurations
{
    public partial class TestResource : System.Web.UI.Page
    {
        #region Property and Variables
        public string ResourceFileName
        {
            get
            {
                return ViewState["ResourceFileName"] != null ? Convert.ToString(ViewState["ResourceFileName"]) : string.Empty;
            }
            set
            {
                ViewState["ResourceFileName"] = value;
            }
        }
        public string HotelCode
        {
            get
            {
                return ViewState["HotelCode"] != null ? Convert.ToString(ViewState["HotelCode"]) : string.Empty;
            }
            set
            {
                ViewState["HotelCode"] = value;
            }
        }

        public bool IsMessage = false;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Control Events
        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSession.UserType.ToUpper() == "SUPERADMIN" || clsSession.UserType.ToUpper() == "ADMINISTRATOR")
                    this.HotelCode = ddlProperty.SelectedValue;

                this.ResourceFileName = ddlResourceFile.SelectedValue.ToString();

                string str = Convert.ToString(this.HotelCode);
                XmlDocument xmlResource = new XmlDocument();
                xmlResource.Load(Server.MapPath("/App_GlobalResources/" + this.HotelCode.Replace("-", "_") + "_" + this.ResourceFileName));
                DataSet dsResourceElements = new DataSet();
                dsResourceElements.ReadXml(new XmlNodeReader(xmlResource));

                gvResourceElements.DataSource = dsResourceElements.Tables["data"];
                gvResourceElements.DataBind();
                btnSave.Visible = btnCancel.Visible = gvResourceElements.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                //------ Save Code
                XmlDocument xmlResource = new XmlDocument();
                xmlResource.Load(Server.MapPath("/App_GlobalResources/" + this.HotelCode.Replace("-", "_") + "_" + this.ResourceFileName));

                for (int i = 0; i < gvResourceElements.Rows.Count; i++)
                {
                    Label lblElement = (Label)gvResourceElements.Rows[i].FindControl("lblResourceElementName");

                    XmlNode loRoot = xmlResource.SelectSingleNode("root/data[@name='" + lblElement.Text + "']/value");
                    if (loRoot != null)
                    {
                        loRoot.InnerText = ((TextBox)gvResourceElements.Rows[i].FindControl("txtValue")).Text.Trim();
                        xmlResource.Save(Server.MapPath("/App_GlobalResources/" + this.HotelCode.Replace("-", "_") + "_" + this.ResourceFileName));
                    }
                }
                //------ Save Code End

                IsMessage = true;
                lblMessage.Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblMsgResourceFieldUpdatedSuccessfully", "Resource field values updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            gvResourceElements.DataSource = null;
            gvResourceElements.DataBind();
            btnSave.Visible = btnCancel.Visible = gvResourceElements.Rows.Count > 0;
            ddlResourceFile.SelectedIndex = 0;
        }

        protected void ddlCompany_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProperty.Items.Clear();
            if (ddlCompany.SelectedIndex != 0)
            {
                SQT.Symphony.BusinessLogic.Configuration.DTO.Property objToGet = new BusinessLogic.Configuration.DTO.Property();
                objToGet.IsActive = true;
                objToGet.CompanyID = new Guid(ddlCompany.SelectedValue.ToString());
                List<SQT.Symphony.BusinessLogic.Configuration.DTO.Property> lstProperties = PropertyBLL.GetAll(objToGet);
                if (lstProperties != null && lstProperties.Count > 0)
                {
                    ddlProperty.DataSource = lstProperties;
                    ddlProperty.DataTextField = "PropertyName";
                    ddlProperty.DataValueField = "LicenceNo";
                    ddlProperty.DataBind();
                    ddlProperty.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlProperty.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlProperty.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
        }
        #endregion

        #region Methods
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindDDLs();
                gvResourceElements.DataSource = null;
                gvResourceElements.DataBind();
                btnSave.Visible = btnCancel.Visible = gvResourceElements.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblMainHeader", "MANAGE RESOURCE FILES");
            ltrProperty.Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblProperty", "Property");
            ltrResourceFile.Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblResourceFile", "Resource File");
            btnGo.Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblBtnGo", "Go");
            ltrResourceFieldListHeader.Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblResourceFieldListHeader", "Resource field list");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
        }

        private void BindDDLs()
        {
            List<ResourceFiles> lstResourceFiles = ResourceFilesBLL.GetAll();
            if (lstResourceFiles != null && lstResourceFiles.Count > 0)
            {
                ddlResourceFile.DataSource = lstResourceFiles;
                ddlResourceFile.DataTextField = "DisplayName";
                ddlResourceFile.DataValueField = "Name";
                ddlResourceFile.DataBind();
                ddlResourceFile.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlResourceFile.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));


            if (clsSession.UserType.ToUpper() == "ADMINISTRATOR")
            {
                tdlblProperty.Visible = tdddlProperty.Visible = rfvProperty.Enabled = true;
                SQT.Symphony.BusinessLogic.Configuration.DTO.Property objToGet = new BusinessLogic.Configuration.DTO.Property();
                objToGet.IsActive = true;
                objToGet.CompanyID = clsSession.CompanyID;
                List<SQT.Symphony.BusinessLogic.Configuration.DTO.Property> lstProperties = PropertyBLL.GetAll(objToGet);
                if (lstProperties != null && lstProperties.Count > 0)
                {
                    ddlProperty.DataSource = lstProperties;
                    ddlProperty.DataTextField = "PropertyName";
                    ddlProperty.DataValueField = "LicenceNo";
                    ddlProperty.DataBind();
                    ddlProperty.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlProperty.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                tdlblCompany.Visible = tdddlCompany.Visible = rfvCompany.Enabled = true;
                SQT.Symphony.BusinessLogic.Configuration.DTO.Company objToGet = new BusinessLogic.Configuration.DTO.Company();
                objToGet.IsActive = true;
                List<SQT.Symphony.BusinessLogic.Configuration.DTO.Company> lstCompanies = CompanyBLL.GetAll(objToGet);
                if (lstCompanies != null && lstCompanies.Count > 0)
                {
                    ddlCompany.DataSource = lstCompanies;
                    ddlCompany.DataTextField = "CompanyName";
                    ddlCompany.DataValueField = "CompanyID";
                    ddlCompany.DataBind();
                    ddlCompany.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlCompany.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

                ddlProperty.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                tdlblProperty.Visible = tdddlProperty.Visible = rfvProperty.Enabled = true;
            }
            else
            {
                this.HotelCode = clsSession.HotelCode;
            }

        }

        private void BindBreadCrumb()
        {
            //DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            //DataTable dt = new DataTable();
            //DataColumn cl = new DataColumn("NameColumn");
            //dt.Columns.Add(cl);

            //DataColumn cl1 = new DataColumn("Link");
            //dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            //if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["NameColumn"] = clsSession.CompanyName;
            //    dr["Link"] = "~/GUI/Property/CompanyList.aspx";
            //    dt.Rows.Add(dr);
            //}

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSetting", "User Setting");
            //dr1["Link"] = "~/GUI/UserSetup/UserSetting.aspx";
            //dt.Rows.Add(dr1);

            //DataRow dr3 = dt.NewRow();
            //dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblManageResourceFiles", "Manage Resource files");
            //dr3["Link"] = "";
            //dt.Rows.Add(dr3);

            //dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            //dlBreadCrumb.DataSource = dt;
            //dlBreadCrumb.DataBind();
        }
        #endregion

        #region Grid Events

        protected void gvResourceElements_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((TextBox)e.Row.FindControl("txtValue")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "value"));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Label)e.Row.FindControl("lblGvHdrFieldName")).Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblGvHdrFieldName", "Field Name");
                ((Label)e.Row.FindControl("lblGvHdrFieldValue")).Text = clsCommon.GetGlobalResourceText("ResourceFileManagement", "lblGvHdrFieldValue", "Values");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }
        #endregion
    }
}