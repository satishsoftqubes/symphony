using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlPropertyInsuranceNew : System.Web.UI.UserControl
    {
        #region Property and Variable
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
        public Guid InsuranceID
        {
            get
            {
                return ViewState["InsuranceID"] != null ? new Guid(Convert.ToString(ViewState["InsuranceID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InsuranceID"] = value;
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
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DateFormat = "dd-MM-yyyy";
                BindInsuranceDetails();
                mvInsuranceDetails.ActiveViewIndex = 0;
            }
        }
        #endregion Page Load

        #region Private Method
        private void BindProperty()
        {
            if (Convert.ToString(Session["CompanyID"]) != "")
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));


            DataSet ds = PropertyBLL.SelectData(this.CompanyID);

            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";

                ddlPropertyName.DataSource = dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyID";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        private void LoadFinancialYearDate()
        {
            ddlDate.Items.Clear();
            ddlYear.Items.Clear();
            ddlToDate.Items.Clear();
            ddlToYear.Items.Clear();
            //Load Date Based On Month
            ddlDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int i = 1; i < 32; i++)
            {
                if (i < 10)
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }
            }

            //Load To Date
            ddlToDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int k = 1; k < 32; k++)
            {
                if (k < 10)
                {
                    ddlToDate.Items.Insert(k, new ListItem(k.ToString(), "0" + k.ToString()));
                }
                else
                {
                    ddlToDate.Items.Insert(k, new ListItem(k.ToString(), k.ToString()));
                }
            }

            //Load Year
            int j = 1;
            ddlYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = Convert.ToInt32(DateTime.Now.Year) + 15; i >= 1970; i--)
            {
                ddlYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                j++;
            }

            int l = 1;
            ddlToYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = Convert.ToInt32(DateTime.Now.Year) + 15; i >= 1970; i--)
            {
                ddlToYear.Items.Insert(l, new ListItem(i.ToString(), i.ToString()));
                l++;
            }

        }
        private void ClearControl()
        {
            txtCompanyName.Text = "";
            txtPolicyNo.Text = "";
            ddlPropertyName.SelectedValue = Guid.Empty.ToString();
            ddlDate.SelectedValue = Guid.Empty.ToString();
            ddlMonth.SelectedValue = Guid.Empty.ToString();
            ddlYear.SelectedValue = Guid.Empty.ToString();
            ddlToDate.SelectedValue = Guid.Empty.ToString();
            ddlToYear.SelectedValue = Guid.Empty.ToString();
            ddlToMonth.SelectedValue = Guid.Empty.ToString();
            ToValidDate.Visible = false;
            this.InsuranceID = Guid.Empty;

        }
        private void BindInsuranceDetails()
        {
            DataSet dsForinsuranceDetails = InsuranceDetailsBLL.GetInsuranceDetailsData(null);
            if (dsForinsuranceDetails != null && dsForinsuranceDetails.Tables.Count > 0 && dsForinsuranceDetails.Tables[0].Rows.Count > 0)
            {
                gvInsuranceDetails.DataSource = dsForinsuranceDetails.Tables[0];
                gvInsuranceDetails.DataBind();
            }
            else
            {
                gvInsuranceDetails.DataSource = null;
                gvInsuranceDetails.DataBind();
            }
        }
        #endregion Private Method

        #region Control Event
        protected void btnNo_Click(object sender, EventArgs e)
        {
            msgbxDelete.Hide();
            this.InsuranceID = Guid.Empty;
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hfMessageDelete.Value) != string.Empty)
                {
                    msgbxDelete.Hide();
                    InsuranceDetails objDelete = new InsuranceDetails();
                    objDelete = InsuranceDetailsBLL.GetByPrimaryKey(new Guid(Convert.ToString(hfMessageDelete.Value)));
                    objDelete.IsActive = false;

                    InsuranceDetailsBLL.Update(objDelete);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), objDelete.ToString(), "irm_InsuranceDetails");
                    IsInsert = true;
                    lblInsurnaceReceiptMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ClearControl();
                }
                BindInsuranceDetails();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnAddTopInsurance_Click(object sender, EventArgs e)
        {
            try
            {
                BindProperty();
                LoadFinancialYearDate();
                mvInsuranceDetails.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void btnCancelInsuranceDetail_Click(object sender, EventArgs e)
        {
            ClearControl();
            BindInsuranceDetails();
            mvInsuranceDetails.ActiveViewIndex = 0;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string FromDate = Convert.ToString(ddlDate.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
                    string ToDate = Convert.ToString(ddlToDate.SelectedValue.ToString().Trim() + "-" + ddlToMonth.SelectedItem.Text.Trim() + "-" + ddlToYear.SelectedValue.ToString().Trim());
                    try
                    {
                        FromValidDate.Visible = false;
                        DateTime FrmDate = Convert.ToDateTime(FromDate);
                    }
                    catch
                    {
                        litFromValidDate.Text = "Enter Valid From Date";
                        FromValidDate.Visible = true;
                        return;
                    }

                    try
                    {
                        ToValidDate.Visible = false;
                        DateTime UpToDate = Convert.ToDateTime(ToDate);
                    }
                    catch
                    {
                        litToValidDate.Text = "Enter Valid To Date";
                        ToValidDate.Visible = true;
                        return;
                    }
                    if (Convert.ToDateTime(FromDate) >= Convert.ToDateTime(ToDate))
                    {
                        litToValidDate.Text = "From Date greate than To date";
                        ToValidDate.Visible = true;
                        return;
                    }
                    else
                    {
                        ToValidDate.Visible = false;
                    }
                    if (this.InsuranceID != null && this.InsuranceID != Guid.Empty)
                    {
                        InsuranceDetails objUpdateInsurance = new InsuranceDetails();
                        InsuranceDetails objoldUpdateInsurance = new InsuranceDetails();
                        objUpdateInsurance = InsuranceDetailsBLL.GetByPrimaryKey(this.InsuranceID);
                        objoldUpdateInsurance = InsuranceDetailsBLL.GetByPrimaryKey(this.InsuranceID);
                        if (ddlPropertyName.SelectedValue != null)
                            objUpdateInsurance.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                        objUpdateInsurance.IsActive = true;
                        objUpdateInsurance.CompanyName = txtCompanyName.Text.Trim();
                        objUpdateInsurance.FromDate = Convert.ToDateTime(FromDate);
                        objUpdateInsurance.ToDate = Convert.ToDateTime(ToDate);
                        objUpdateInsurance.PolicyNo = txtPolicyNo.Text.Trim();
                        InsuranceDetailsBLL.Update(objUpdateInsurance);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objoldUpdateInsurance.ToString(), objUpdateInsurance.ToString(), "irm_InsuranceDetails");
                        IsInsert = true;
                        lblInsurnaceReceiptMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        ClearControl();
                    }
                    else
                    {
                        InsuranceDetails objInsertInsurance = new InsuranceDetails();
                        objInsertInsurance.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objInsertInsurance.CreatedOn = DateTime.Now;

                        if (ddlPropertyName.SelectedValue != null)
                            objInsertInsurance.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                        objInsertInsurance.IsActive = true;
                        objInsertInsurance.CompanyName = txtCompanyName.Text.Trim();
                        objInsertInsurance.FromDate = Convert.ToDateTime(FromDate);
                        objInsertInsurance.ToDate = Convert.ToDateTime(ToDate);
                        objInsertInsurance.PolicyNo = txtPolicyNo.Text.Trim();
                        InsuranceDetailsBLL.Save(objInsertInsurance);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objInsertInsurance.ToString(), objInsertInsurance.ToString(), "irm_InsuranceDetails");
                        IsInsert = true;
                        lblInsurnaceReceiptMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.InsuranceID = objInsertInsurance.InsuranceID;
                        string path1 = string.Empty;
                        if (fuLicenseNo.FileName != "")
                        {
                            string FileConstructionAgreement = "Insurance$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuLicenseNo.FileName.Replace(" ", "_");
                            path1 = Server.MapPath("~/Document/" + FileConstructionAgreement);
                            fuLicenseNo.SaveAs(path1);
                            Documents d1 = new Documents();
                            d1.DocumentName = FileConstructionAgreement;
                            d1.Extension = System.IO.Path.GetExtension(fuLicenseNo.FileName);
                            d1.DateOfSubmission = DateTime.Now;
                            d1.CreatedOn = DateTime.Now;
                            d1.IsActive = true;
                            d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                            ProjectTerm objProjectTerm = new ProjectTerm();
                            objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid("DF3876FD-6AA1-45BD-A815-1A6F015A7E2D"));
                            d1.TypeID = new Guid("DF3876FD-6AA1-45BD-A815-1A6F015A7E2D");
                            if (objProjectTerm != null)
                                d1.AssociationType = Convert.ToString(objProjectTerm.Term);
                            else
                                d1.AssociationType = "Property Insurance";

                            d1.AssociationID = objInsertInsurance.InsuranceID;
                            d1.IsSynch = false;
                            d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                            d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                            DocumentsBLL.Save(d1);
                           
                        }
                        ClearControl();
                    }



                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion Control Event


        #region Grid Event

        protected void gvInsuranceDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal litStartDate = (Literal)e.Row.FindControl("litStartDate");
                    Literal litValidUpto = (Literal)e.Row.FindControl("litValidUpto");
                    if (DataBinder.Eval(e.Row.DataItem, "FromDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FromDate")) != "")
                    {
                        litStartDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FromDate")).ToString(this.DateFormat);
                    }
                    else
                    {
                        litStartDate.Text = "";
                    }

                    if (DataBinder.Eval(e.Row.DataItem, "ToDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ToDate")) != "")
                    {
                        litValidUpto.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ToDate")).ToString(this.DateFormat);
                    }
                    else
                    {
                        litValidUpto.Text = "";
                    }
                    //
                    ImageButton imgDelete = (ImageButton)e.Row.FindControl("btnDelete");
                    imgDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "InsuranceID")));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvInsuranceDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITISNURANCE"))
                {
                    BindProperty();
                    LoadFinancialYearDate();
                    ClearControl();
                    mvInsuranceDetails.ActiveViewIndex = 1;
                    InsuranceDetails objInsuranceDetails = new InsuranceDetails();
                    objInsuranceDetails = InsuranceDetailsBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    if (objInsuranceDetails != null)
                    {
                        this.InsuranceID = objInsuranceDetails.InsuranceID;
                        if (Convert.ToString(objInsuranceDetails.FromDate) != null && Convert.ToString(objInsuranceDetails.FromDate) != "")
                        {
                            DateTime dtStartDate = Convert.ToDateTime(Convert.ToString(objInsuranceDetails.FromDate));
                            ddlDate.SelectedValue = dtStartDate == null ? Guid.Empty.ToString() : dtStartDate.Day.ToString().Length == 2 ? dtStartDate.Day.ToString() : "0" + dtStartDate.Day.ToString();
                            ddlMonth.SelectedValue = objInsuranceDetails.FromDate == null ? Guid.Empty.ToString() : objInsuranceDetails.FromDate.Value.Month.ToString();
                            // ddlMonth.SelectedValue = dtStartDate == null ? Guid.Empty.ToString() : dtStartDate.Month.ToString().Length == 2 ? dtStartDate.Month.ToString() : "0" + dtStartDate.Month.ToString();
                            ddlYear.SelectedValue = dtStartDate == null ? Guid.Empty.ToString() : dtStartDate.Year.ToString();
                        }
                        else
                            ddlDate.SelectedValue = ddlMonth.SelectedValue = ddlYear.SelectedValue = Guid.Empty.ToString();


                        if (Convert.ToString(objInsuranceDetails.ToDate) != null && Convert.ToString(objInsuranceDetails.ToDate) != "")
                        {
                            DateTime dtEndDate = Convert.ToDateTime(Convert.ToString(objInsuranceDetails.ToDate));
                            ddlToDate.SelectedValue = dtEndDate == null ? Guid.Empty.ToString() : dtEndDate.Day.ToString().Length == 2 ? dtEndDate.Day.ToString() : "0" + dtEndDate.Day.ToString();
                            ddlToMonth.SelectedValue = objInsuranceDetails.ToDate == null ? Guid.Empty.ToString() : objInsuranceDetails.ToDate.Value.Month.ToString();
                            // ddlToMonth.SelectedValue = dtEndDate == null ? Guid.Empty.ToString() : dtEndDate.Month.ToString().Length == 2 ? dtEndDate.Month.ToString() : "0" + dtEndDate.Month.ToString();
                            ddlToYear.SelectedValue = dtEndDate == null ? Guid.Empty.ToString() : dtEndDate.Year.ToString();
                        }
                        else
                            ddlToDate.SelectedValue = ddlToMonth.SelectedValue = ddlToYear.SelectedValue = Guid.Empty.ToString();


                        txtCompanyName.Text = Convert.ToString(objInsuranceDetails.CompanyName);
                        txtPolicyNo.Text = Convert.ToString(objInsuranceDetails.PolicyNo);
                        ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(objInsuranceDetails.PropertyID)) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(objInsuranceDetails.PropertyID))) : 0;

                    }
                }
                else if (e.CommandName.Equals("VIEWISNURANCE") && e.CommandArgument != null)
                {
                    mpeInsuranceDetails.Show();
                    DataSet dsForinsuranceDetails = InsuranceDetailsBLL.GetInsuranceDetailsData(new Guid(Convert.ToString(e.CommandArgument)));
                    if (dsForinsuranceDetails != null && dsForinsuranceDetails.Tables.Count > 0 && dsForinsuranceDetails.Tables[0].Rows.Count > 0)
                    {
                        DataRow drForinsDetails = dsForinsuranceDetails.Tables[0].Rows[0];

                        if (drForinsDetails["PropertyName"] != null && Convert.ToString(drForinsDetails["PropertyName"]) != "")
                            litDispPropertyName.Text = Convert.ToString(drForinsDetails["PropertyName"]);
                        else
                            litDispPropertyName.Text = "-";

                        if (drForinsDetails["FromDate"] != null && Convert.ToString(drForinsDetails["FromDate"]) != "")
                            litDispInsuranceperiod.Text = Convert.ToDateTime(drForinsDetails["FromDate"]).ToString(this.DateFormat) + " to " + Convert.ToDateTime(drForinsDetails["Todate"]).ToString(this.DateFormat);
                        else
                            litDispInsuranceperiod.Text = "-";

                        if (drForinsDetails["CompanyName"] != null && Convert.ToString(drForinsDetails["CompanyName"]) != "")
                            lblDispCompanyName.Text = Convert.ToString(drForinsDetails["CompanyName"]);
                        else
                            lblDispCompanyName.Text = "-";

                        if (drForinsDetails["PolicyNo"] != null && Convert.ToString(drForinsDetails["PolicyNo"]) != "")
                            lblDispPolicyNo.Text = Convert.ToString(drForinsDetails["PolicyNo"]);
                        else
                            lblDispPolicyNo.Text = "-";


                    }
                }
                else if (e.CommandName.Equals("DELETEINSURANCE"))
                {
                    this.InsuranceID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbxDelete.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvInsuranceDetails_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsuranceDetails.PageIndex = e.NewPageIndex;
            BindInsuranceDetails();
        }
        #endregion Grid Event

    }
}