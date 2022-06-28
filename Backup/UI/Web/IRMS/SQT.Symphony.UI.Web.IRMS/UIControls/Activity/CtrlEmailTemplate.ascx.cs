using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlEmailTemplate : System.Web.UI.UserControl
    {
        #region Variable & Property

        public Guid EmailTemplateID
        {
            get
            {
                return ViewState["EmailTemplateID"] != null ? new Guid(Convert.ToString(ViewState["EmailTemplateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["EmailTemplateID"] = value;
            }

        }
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
        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;
        public bool IsAddNew = false;
        #endregion Variable & Property

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                //BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method

        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                BindGrid();
                mvEmailTemplate.ActiveViewIndex = 0;
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
            DataSet dsEmailTemplates = EMailTmpltsBLL.SearchData(null, new Guid(Convert.ToString(Session["CompanyID"])));
            if (dsEmailTemplates != null && dsEmailTemplates.Tables.Count > 0 && dsEmailTemplates.Tables[0].Rows.Count > 0)
            {
                gvEmailTemplateList.DataSource = dsEmailTemplates.Tables[0];
                gvEmailTemplateList.DataBind();
            }
            else
            {
                gvEmailTemplateList.DataSource = null;
                gvEmailTemplateList.DataBind();
            }

        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.EmailTemplateID = Guid.Empty;
            txtTitle.Text = txtSubject.Text = ckBody.Text = "";
        }

        #endregion Private Method

        #region Grid Event
        
        //protected void gvEmailTemplateList_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
                
        //    }
        //}
        
        protected void gvEmailTemplateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                mvEmailTemplate.ActiveViewIndex = 1;
                this.EmailTemplateID = new Guid(Convert.ToString(e.CommandArgument));
                EMailTmplts objEmla = EMailTmpltsBLL.GetByPrimaryKey(this.EmailTemplateID);
                if (objEmla != null)
                {
                    txtTitle.Text = objEmla.Title;
                    txtSubject.Text = objEmla.Header;                    
                    ckBody.Text = objEmla.Body;
                }
            }
        }
        #endregion Grid Event

        #region Button Event

        /// <summary>
        /// SAve Email Configuration
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (this.EmailTemplateID != Guid.Empty)
                    {
                        EMailTmplts objUpd = new EMailTmplts();
                        EMailTmplts objOldCurr = new EMailTmplts();
                        objUpd = EMailTmpltsBLL.GetByPrimaryKey(this.EmailTemplateID);
                        objOldCurr = EMailTmpltsBLL.GetByPrimaryKey(this.EmailTemplateID);
                        objUpd.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                        objUpd.Header = txtTitle.Text.Trim();
                        objUpd.Body = ckBody.Text;
                        objUpd.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objUpd.UpdatedOn = DateTime.Now.Date;
                        EMailTmpltsBLL.Update(objUpd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_EMailTemplates");
                        IsListMessage = true;
                        ltrListMessage.Text = "Record updated successfully.";
                        ClearControl();
                        mvEmailTemplate.ActiveViewIndex = 0;
                    }
                    BindGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            ClearControl();
            mvEmailTemplate.ActiveViewIndex = 0;
        }
        #endregion Button Event
    }
}