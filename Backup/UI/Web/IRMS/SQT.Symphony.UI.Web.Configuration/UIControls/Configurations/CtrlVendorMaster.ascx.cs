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
namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlVendorMaster : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;

        public Guid VendorID
        {
            get
            {
                return ViewState["VendorID"] != null ? new Guid(Convert.ToString(ViewState["VendorID"])) : Guid.Empty;
            }
            set
            {
                ViewState["VendorID"] = value;
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

        #endregion Property and Variables

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                mvVendor.ActiveViewIndex = 0;
                BindGrid();
                BindBreadCrumb();
                ClearControl();
                SetPageLables();
            }
        }
        #endregion

        #region Control Event

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvVendorList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGrid();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnTopAddVendor_Click(object sender, EventArgs e)
        {
            mvVendor.ActiveViewIndex = 1;
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
            ClearControl();
        }
        
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    ServiceVendorMaster IsDupVendor = new ServiceVendorMaster();
                    IsDupVendor.PropertyID = clsSession.PropertyID;
                    IsDupVendor.CompanyID = clsSession.CompanyID;
                    IsDupVendor.IsActive = true;
                    IsDupVendor.Email = txtEmail.Text.Trim();
                    List<ServiceVendorMaster> lstIsDupVendor = ServiceVendorMasterBLL.GetAll(IsDupVendor);
                    if (lstIsDupVendor.Count > 0)
                    {
                        if (this.VendorID != Guid.Empty)
                        {
                            if (Convert.ToString((lstIsDupVendor[0].VendorID)) != Convert.ToString(this.VendorID.ToString()))
                            {
                                IsListMessage = true;
                                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                mvVendor.ActiveViewIndex = 1;
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            mvVendor.ActiveViewIndex = 1;
                            return;
                        }
                    }

                    if (this.VendorID != Guid.Empty)
                    {
                        ServiceVendorMaster objUpdate = new ServiceVendorMaster();
                        ServiceVendorMaster objOldUpdateData = new ServiceVendorMaster();

                        objUpdate = ServiceVendorMasterBLL.GetByPrimaryKey(this.VendorID);
                        objOldUpdateData = ServiceVendorMasterBLL.GetByPrimaryKey(this.VendorID);

                        //objUpdate.AmenitiesCode = txtAmenitiesCode.Text.Trim();
                        objUpdate.CompanyName = txtCompanyName.Text.Trim();
                        objUpdate.RegistrationNo = txtRegistrationNo.Text.Trim();
                        if (txtRegistrationDate.Text.Trim() != "")
                            objUpdate.RegistrationDate = DateTime.ParseExact(txtRegistrationDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objUpdate.VATRegNo = txtVatRegNo.Text.Trim();
                        if (txtVatRegDate.Text.Trim() != "")
                            objUpdate.VATRegistrationDate = DateTime.ParseExact(txtVatRegDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objUpdate.ContactPersonName = txtContactPersonName.Text.Trim();
                        objUpdate.ContactNo = txtContactNo.Text.Trim();
                        objUpdate.Email = txtEmail.Text.Trim();
                        objUpdate.URL = txtUrl.Text.Trim();
                        objUpdate.BillingAddress = txtBillingAddress.Text.Trim();
                        objUpdate.POSDetails = txtPosDetails.Text.Trim();
                        objUpdate.IsActive = true;
                        objUpdate.UpdatedOn = DateTime.Now;
                        objUpdate.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        ServiceVendorMasterBLL.Update(objUpdate);

                        //clsSession.DateFormat
                        ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldUpdateData.ToString(), objUpdate.ToString(), "pos_ServiceVendorMaster");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        ServiceVendorMaster objSave = new ServiceVendorMaster();
                        objSave.PropertyID = clsSession.PropertyID;
                        objSave.CompanyID = clsSession.CompanyID;
                        objSave.CompanyName = txtCompanyName.Text.Trim();
                        objSave.RegistrationNo = txtRegistrationNo.Text.Trim();
                        if (txtRegistrationDate.Text.Trim() != "")
                            objSave.RegistrationDate = DateTime.ParseExact(txtRegistrationDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objSave.VATRegNo = txtVatRegNo.Text.Trim();
                        if (txtVatRegDate.Text.Trim() != "")
                            objSave.VATRegistrationDate = DateTime.ParseExact(txtVatRegDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objSave.ContactPersonName = txtContactPersonName.Text.Trim();
                        objSave.ContactNo = txtContactNo.Text.Trim();
                        objSave.Email = txtEmail.Text.Trim();
                        objSave.URL = txtUrl.Text.Trim();
                        objSave.BillingAddress = txtBillingAddress.Text.Trim();
                        objSave.POSDetails = txtPosDetails.Text.Trim();
                        objSave.IsActive = true;

                        objSave.CreatedOn = DateTime.Now;
                        objSave.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                        ServiceVendorMasterBLL.Save(objSave);
                        ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Save", objSave.ToString(), objSave.ToString(), "pos_ServiceVendorMaster");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }

                    mvVendor.ActiveViewIndex = 1;
                    ClearControl();
                    BindGrid();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            mvVendor.ActiveViewIndex = 0;
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
        }


        #endregion

        #region Methods

        private void BindGrid()
        {
            try
            {
                string VendorName = null;
                string CompanyName = null;

                if (txtSearchVendorName.Text.Trim() != "")
                {
                    VendorName = txtSearchVendorName.Text.Trim();
                }
                else
                {
                    VendorName = null;
                }

                if (txtSearchCompanyName.Text.Trim() != "")
                {
                    CompanyName = txtSearchCompanyName.Text.Trim();
                }
                else
                {
                    CompanyName = null;
                }

                DataSet lstVendorMaster = ServiceVendorMasterBLL.SearchVendorData(CompanyName, VendorName, clsSession.CompanyID, clsSession.PropertyID);
                gvVendorList.DataSource = lstVendorMaster.Tables[0];
                gvVendorList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearSearchControl()
        {
            txtSearchCompanyName.Text = txtSearchVendorName.Text="";
            
        
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "VENDORMASTER.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomVendor.Visible = btnTopAddVendor.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void ClearControl()
        {
            txtBillingAddress.Text = txtCompanyName.Text = txtContactNo.Text = txtContactPersonName.Text = txtEmail.Text = txtPosDetails.Text = txtRegistrationDate.Text = txtRegistrationNo.Text = txtSearchVendorName.Text = txtUrl.Text = txtVatRegDate.Text = txtVatRegNo.Text = "";
            calVatRegDate.Format = calRegistrationDate.Format = clsSession.DateFormat;
            this.VendorID = Guid.Empty;
        }


        private void SetPageLables()
        {
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnSearchVendor.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            btnAddBottomVendor.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel"); 
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnTopAddVendor.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            ltrGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            ltrBillingAddress.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblBillingAddress", "Billing Address");
            ltrCompanyName.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblCompanyName", "Company Name");
            ltrContactNo.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblContactNo", "Contact No");
            ltrContactPersonName.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblContactPersonName", "Contact Person Name");
            ltrEmail.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblEmail", "Email");
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblMainHeader", "VENDOR MASTER");
            ltrContactPersonName.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblContactPersonName", "Contact Person Name");
            ltrPosDetails.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblPosDetails", "POS Details");
            ltrRegistrationDate.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblRegistrationDate", "Registration Date");
            ltrRegistrationNo.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblRegistrationNo", "Registration No.");
            ltrSearchVendorName.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblSearchVendorName", "Vendor Name");
            ltrVatRegNo.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblVatRegNo", "Vat Reg. No.");
            ltrUrl.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblUrl", "URL");
            ltrVatRegDate.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblVatRegDate", "Vat Reg. Date");
            ltrVendorList.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblVendorList", "Vendor List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblMainHeader", "VENDOR MASTER");
            ltrSearchCompanyName.Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblSearchCompanyName", "Company Name");
            rgvtxtURL.ErrorMessage = clsCommon.GetGlobalResourceText("VendorMaster", "lblErrorMassage", "URL is not valide");
            
        }


        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

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

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPOSSetup", "POS Setup");
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            if (this.VendorID != Guid.Empty || mvVendor.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblVendorMaster", "Vendor Master");
                dr3["Link"] = "~/GUI/Configurations/VendorMaster.aspx";
                dt.Rows.Add(dr3);

                DataRow dr4 = dt.NewRow();
                dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewVendor", "New Vendor");
                dr4["Link"] = "";
                dt.Rows.Add(dr4);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblVendorMaster", "Vendor");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }



        #endregion

        #region Grid Control Event


        protected void gvVendor_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVendorList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvVendor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearControl();
                    mvVendor.ActiveViewIndex = 1;
                    ServiceVendorMaster objVendor = new ServiceVendorMaster();
                    objVendor = ServiceVendorMasterBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    if (objVendor != null)
                    {
                        this.VendorID = objVendor.VendorID;
                        // txtAmenitiesCode.Text = objAmenities.AmenitiesCode;
                        txtBillingAddress.Text =objVendor.BillingAddress;
                        txtCompanyName.Text =objVendor.CompanyName;
                        txtContactNo.Text =objVendor.ContactNo;
                        txtContactPersonName.Text =objVendor.ContactPersonName;
                        txtEmail.Text =objVendor.Email;
                        txtPosDetails.Text =objVendor.POSDetails;
                        //txtRegistrationDate.Text = objVendor.RegistrationDate;
                        txtRegistrationDate.Text = Convert.ToDateTime(objVendor.RegistrationDate).ToString(clsSession.DateFormat);
                        txtRegistrationNo.Text = objVendor.RegistrationNo;
                        txtUrl.Text = objVendor.URL;
                        //txtVatRegDate.Text = objVendor.VATRegistrationDate;
                        txtVatRegDate.Text = Convert.ToDateTime(objVendor.VATRegistrationDate).ToString(clsSession.DateFormat);
                        txtVatRegNo.Text = objVendor.VATRegNo;

                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.VendorID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    ServiceVendorMaster objDelete = new ServiceVendorMaster();
                    objDelete = ServiceVendorMasterBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    ServiceVendorMasterBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "pos_ServiceVendorMaster");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvVendor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VendorID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrCompanyName")).Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblGvHdrCompanyName", "Company Name");
                    ((Label)e.Row.FindControl("lblGvHdrRegistrationNo")).Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblGvHdrRegistrationNo", "Registration No.");
                    ((Label)e.Row.FindControl("lblGvHdrVatRegNo")).Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblGvHdrVatRegNo", "Vat Reg. No.");
                    ((Label)e.Row.FindControl("lblGvHdrContactPersonName")).Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblGvHdrContactPersonName", "Vendor Name");
                    ((Label)e.Row.FindControl("lblGvHdrContact")).Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblGvHdrContact", "Contact");
                    ((Label)e.Row.FindControl("lblGvHdrEmail")).Text = clsCommon.GetGlobalResourceText("VendorMaster", "lblGvHdrEmail", "Email");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
               
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}