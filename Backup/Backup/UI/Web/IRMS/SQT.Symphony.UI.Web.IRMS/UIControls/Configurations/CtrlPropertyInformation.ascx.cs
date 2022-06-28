using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlPropertyInformation : System.Web.UI.UserControl
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
            if (RoleRightJoinBLL.GetAccessString("PropertyConfiruation.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            if (!IsPostBack)
                LoadDefaultValue();
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("PropertyConfiruation.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
                btnSave.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);     
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
                //BindDateFormat();
                //BindTimeFormat();
                BindSystemSetupData();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //private void BindDateFormat()
        //{
        //    List<ProjectTerm> lstProjectTermDF = null;
        //    ProjectTerm objProjectTermDF = new ProjectTerm();
        //    objProjectTermDF.IsActive = true;
        //    objProjectTermDF.Category = "DATEFORMAT";
        //    objProjectTermDF.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

        //    lstProjectTermDF = ProjectTermBLL.GetAll(objProjectTermDF);

        //    if (lstProjectTermDF.Count != 0)
        //    {
        //        ddlDateFormat.DataSource = lstProjectTermDF;
        //        ddlDateFormat.DataTextField = "Term";
        //        ddlDateFormat.DataValueField = "TermID";
        //        ddlDateFormat.DataBind();
        //        ddlDateFormat.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlDateFormat.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //}

        //private void BindTimeFormat()
        //{
        //    List<ProjectTerm> lstProjectTermTF = null;
        //    ProjectTerm objProjectTermTF = new ProjectTerm();
        //    objProjectTermTF.IsActive = true;
        //    objProjectTermTF.Category = "TIMEFORMAT";
        //    objProjectTermTF.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

        //    lstProjectTermTF = ProjectTermBLL.GetAll(objProjectTermTF);

        //    if (lstProjectTermTF.Count != 0)
        //    {
        //        ddlTimerFormat.DataSource = lstProjectTermTF;
        //        ddlTimerFormat.DataTextField = "Term";
        //        ddlTimerFormat.DataValueField = "TermID";
        //        ddlTimerFormat.DataBind();
        //        ddlTimerFormat.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlTimerFormat.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //}

        private void BindSystemSetupData()
        {
            List<PropertyConfiguration> lstLoadPropertyConfigurationData = null;
            PropertyConfiguration objPropertyConfiguration = new PropertyConfiguration();
            if (Session["CompanyID"] != null)
                objPropertyConfiguration.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
            else
                objPropertyConfiguration.CompanyID = null;

            lstLoadPropertyConfigurationData = PropertyConfigurationBLL.GetAll(objPropertyConfiguration);

            if (lstLoadPropertyConfigurationData.Count != 0)
            {
                PropertyConfiguration objLoadPCData = new PropertyConfiguration();
                objLoadPCData = lstLoadPropertyConfigurationData[0];

                //if (Convert.ToString(objLoadPCData.DateFormatID) != null && Convert.ToString(objLoadPCData.DateFormatID) != "")
                //    ddlDateFormat.SelectedValue = Convert.ToString(objLoadPCData.DateFormatID);

                //if (Convert.ToString(objLoadPCData.TimeFormatID) != null && Convert.ToString(objLoadPCData.TimeFormatID) != "")
                //    ddlTimerFormat.SelectedValue = Convert.ToString(objLoadPCData.TimeFormatID);

                txtSMTPAddress.Text = Convert.ToString(objLoadPCData.SmtpAddress);
                txtPOP3Server.Text = Convert.ToString(objLoadPCData.POP3InServer);
                txtPOP3OutGoingServer.Text = Convert.ToString(objLoadPCData.POP3OutGoingServer);
                txtUserName.Text = Convert.ToString(objLoadPCData.UserName);
                txtPassword.Attributes.Add("value", objLoadPCData.Password);
                txtPrimoryDomainName.Text = Convert.ToString(objLoadPCData.PrimoryDomainName);
                txtPrimoryEmail.Text = Convert.ToString(objLoadPCData.PrimoryEmail);
                txtDNSName.Text = Convert.ToString(objLoadPCData.DNSName);
                if (objLoadPCData.IsSkipAddress == true)
                {
                    rbtAddressMandatory.Checked = false;
                    rbtAddressOption.Checked = true;
                }
                else
                {
                    rbtAddressMandatory.Checked = true;
                    rbtAddressOption.Checked = false;
                }

                if (objLoadPCData.IsSkipPostCode == true)
                {
                    rbtPostCodeMandatory.Checked = false;
                    rbtPostCodeOption.Checked = true;
                }
                else
                {
                    rbtPostCodeMandatory.Checked = true;
                    rbtPostCodeOption.Checked = false;
                }

                //if (objLoadPCData.IsSkipEmail == true)
                //{
                //    rbtEmailMandatory.Checked = false;
                //    rbtEmailOption.Checked = true;
                //}
                //else
                //{
                //    rbtEmailMandatory.Checked = true;
                //    rbtEmailOption.Checked = false;
                //}

                //if (objLoadPCData.IsSkipContactNo == true)
                //{
                //    rbtContactMandatory.Checked = false;
                //    rbtContactOption.Checked = true;
                //}
                //else
                //{
                //    rbtContactMandatory.Checked = true;
                //    rbtContactOption.Checked = false;
                //}
            }
        }

        #endregion Private Method

        #region Control Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<PropertyConfiguration> lstPropertyConfigurationData = null;
                    PropertyConfiguration objPropertyConfiguration = new PropertyConfiguration();
                    if (Session["CompanyID"] != null)
                        objPropertyConfiguration.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    else
                        objPropertyConfiguration.CompanyID = null;

                    lstPropertyConfigurationData = PropertyConfigurationBLL.GetAll(objPropertyConfiguration);

                    if (lstPropertyConfigurationData.Count != 0)
                    {
                        PropertyConfiguration objUpd = new PropertyConfiguration();
                        PropertyConfiguration objOldUpdData = new PropertyConfiguration();
                        objUpd = lstPropertyConfigurationData[0];
                        objOldUpdData = lstPropertyConfigurationData[0];

                        //if (ddlDateFormat.SelectedValue != Guid.Empty.ToString())
                        //    objUpd.DateFormatID = new Guid(ddlDateFormat.SelectedValue);
                        //else
                        //    objUpd.DateFormatID = null;
                        //if (ddlTimerFormat.SelectedValue != Guid.Empty.ToString())
                        //    objUpd.TimeFormatID = new Guid(ddlTimerFormat.SelectedValue);
                        //else
                        //    objUpd.TimeFormatID = null;
                        objUpd.SmtpAddress = txtSMTPAddress.Text.Trim();
                        objUpd.POP3InServer = txtPOP3Server.Text.Trim();
                        objUpd.POP3OutGoingServer = txtPOP3OutGoingServer.Text.Trim();
                        objUpd.UserName = txtUserName.Text.Trim();
                        objUpd.Password = txtPassword.Text.Trim();
                        objUpd.PrimoryDomainName = txtPrimoryDomainName.Text.Trim();
                        objUpd.PrimoryEmail = txtPrimoryEmail.Text.Trim();
                        objUpd.DNSName = txtDNSName.Text.Trim();
                        objUpd.LastUpdateOn = DateTime.Now;
                        objUpd.DNSName = txtDNSName.Text.Trim();

                        if (rbtAddressMandatory.Checked)
                            objUpd.IsSkipAddress = false;
                        else
                            objUpd.IsSkipAddress = true;

                        if (rbtPostCodeMandatory.Checked)
                            objUpd.IsSkipPostCode = false;
                        else
                            objUpd.IsSkipPostCode = true;

                        //if (rbtEmailMandatory.Checked)
                        //    objUpd.IsSkipEmail = false;
                        //else
                        //    objUpd.IsSkipEmail = true;

                        //if (rbtContactMandatory.Checked)
                        //    objUpd.IsSkipContactNo = false;
                        //else
                        //    objUpd.IsSkipContactNo = true;

                        PropertyConfigurationBLL.Update(objUpd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldUpdData.ToString(), objUpd.ToString(), "mst_PropertyConfiguration");
                        IsUpdate = true;
                        lblUpdate.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        Session["PropertyConfigurationInfo"] = objUpd;

                    }
                    else
                    {
                        PropertyConfiguration objIns = new PropertyConfiguration();
                        if (Session["CompanyID"] != null)
                            objIns.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                        //if (ddlDateFormat.SelectedValue != Guid.Empty.ToString())
                        //    objIns.DateFormatID = new Guid(ddlDateFormat.SelectedValue);
                        //else
                        //    objIns.DateFormatID = null;
                        //if (ddlTimerFormat.SelectedValue != Guid.Empty.ToString())
                        //    objIns.TimeFormatID = new Guid(ddlTimerFormat.SelectedValue);
                        //else
                        //    objIns.TimeFormatID = null;
                        objIns.SmtpAddress = txtSMTPAddress.Text.Trim();
                        objIns.POP3InServer = txtPOP3Server.Text.Trim();
                        objIns.POP3OutGoingServer = txtPOP3OutGoingServer.Text.Trim();
                        objIns.UserName = txtUserName.Text.Trim();
                        objIns.Password = txtPassword.Text.Trim();
                        objIns.PrimoryDomainName = txtPrimoryDomainName.Text.Trim();
                        objIns.PrimoryEmail = txtPrimoryEmail.Text.Trim();
                        objIns.DNSName = txtDNSName.Text.Trim();
                        if (rbtAddressMandatory.Checked)
                            objIns.IsSkipAddress = false;
                        else
                            objIns.IsSkipAddress = true;

                        if (rbtPostCodeMandatory.Checked)
                            objIns.IsSkipPostCode = false;
                        else
                            objIns.IsSkipAddress = true;

                        //if (rbtEmailMandatory.Checked)
                        //    objIns.IsSkipEmail = false;
                        //else
                        //    objIns.IsSkipEmail = true;

                        //if (rbtContactMandatory.Checked)
                        //    objIns.IsSkipContactNo = false;
                        //else
                        //    objIns.IsSkipContactNo = true;

                        objIns.IsActive = true;
                        objIns.LastUpdateOn = DateTime.Now;

                        PropertyConfigurationBLL.Save(objIns);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "mst_PropertyConfiguration");

                        IsInsert = true;
                        lblInsert.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();

                        Session["PropertyConfigurationInfo"] = objIns;
                    }
                    BindSystemSetupData();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

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

        #endregion Control Event
    }
}