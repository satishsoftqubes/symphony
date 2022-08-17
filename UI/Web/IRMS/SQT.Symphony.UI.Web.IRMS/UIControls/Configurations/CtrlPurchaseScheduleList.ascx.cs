using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlPurchaseScheduleList : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid PurchaseScheduleID
        {
            get
            {
                return ViewState["PurchaseScheduleID"] != null ? new Guid(Convert.ToString(ViewState["PurchaseScheduleID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PurchaseScheduleID"] = value;
            }
        }

        public Guid PropertyID
        {
            get
            {
                return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID"] = value;
            }
        }

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

        #endregion Property and Variables


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPurchaseScheduleInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    //this.PurchaseScheduleID = new Guid(Convert.ToString(Session["PurchaseScheduleID"]));
                    LoadDefaultValue();
                }

                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                {
                    btnAddPurchaseSchedule.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                BindDDL();
                LoadPropertyInstallmentGrid();
                BindPurchaseOption();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDDL()
        {
            string PropertyNameQuery = "Select Distinct(PropertyName) From mst_Property Where IsActive = 1";
            DataSet Dst = InvestorBLL.GetSearchData(PropertyNameQuery);
            DataView Dv = new DataView(Dst.Tables[0]);
            if (Dv.Count > 0)
            {
                ddlPropertyName.DataSource = Dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyName";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        private void BindPurchaseOption()
        {
            List<ProjectTerm> lstProjectTermPO = null;
            ProjectTerm objProjectTermPT = new ProjectTerm();
            objProjectTermPT.IsActive = true;
            objProjectTermPT.Category = "PURCHASEOPTION";
            objProjectTermPT.CompanyID = this.CompanyID;

            lstProjectTermPO = ProjectTermBLL.GetAll(objProjectTermPT);

            if (lstProjectTermPO.Count != 0)
            {
                lstProjectTermPO.Sort((ProjectTerm p1, ProjectTerm p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlPurchaseOption.DataSource = lstProjectTermPO;
                ddlPurchaseOption.DataTextField = "DisplayTerm";
                ddlPurchaseOption.DataValueField = "TermID";
                ddlPurchaseOption.DataBind();
                ddlPurchaseOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlPurchaseOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        public void btnCalculateTotalCost_Click(object sender, EventArgs e)
        {
            float price = Convert.ToInt32(txtPrice.Text);
            int purchaseArea = Convert.ToInt32(txtPurchaseArea.Text);
            decimal totalCost = Convert.ToDecimal(price * purchaseArea);
            txtTotalCost.Text = Convert.ToString(totalCost);
        }

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                btnAddPurchaseSchedule.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/SetUp/ConfigurationPurchaseScheduleInfo.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void fnAddNewInstallment(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void AddNewRowToGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = "Installment " + Convert.ToInt32(dtCurrentTable.Rows.Count + 1);

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   
                    ViewState["CurrentTable"] = dtCurrentTable;

                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {
                        // select installment type
                        DropDownList ddlInstallmentType = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlInstallmentType") as DropDownList);
                        dtCurrentTable.Rows[i]["InstallmentTypeTerm"] = ddlInstallmentType.Text;

                        //extract the TextBox values   
                        TextBox percentage = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentPercent");
                        dtCurrentTable.Rows[i]["InstallmentInPercentage"] = percentage.Text;

                        // select payment mode
                        DropDownList ddlPaymentMode = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentMode") as DropDownList);
                        dtCurrentTable.Rows[i]["MOPTerm"] = ddlPaymentMode.Text;

                        TextBox amount = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentAmount");
                        dtCurrentTable.Rows[i]["InstallmentAmount"] = amount.Text;
                    }
                    //Rebind the Grid with the current data to reflect changes   
                    gvPropertyInstallments.DataSource = dtCurrentTable;
                    gvPropertyInstallments.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList ddlInstallmentType = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlInstallmentType") as DropDownList);
                        TextBox percentage = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentPercent");
                        DropDownList ddlPaymentMode = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentMode") as DropDownList);
                        TextBox amount = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentAmount");
                        if (i < dt.Rows.Count - 1)
                        {
                            ddlInstallmentType.SelectedValue = dt.Rows[i]["InstallmentTypeTerm"].ToString();
                            percentage.Text = dt.Rows[i]["InstallmentInPercentage"].ToString();
                            ddlPaymentMode.SelectedValue = dt.Rows[i]["MOPTerm"].ToString();
                            amount.Text = dt.Rows[i]["InstallmentAmount"].ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }

        protected void gvPropertyInstallments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    #region Payment Mode
                    
                    DropDownList ddlPaymentMode = (e.Row.FindControl("ddlPaymentMode") as DropDownList);
                    ProjectTerm PaymentTerm = new ProjectTerm();
                    PaymentTerm.CompanyID = this.CompanyID;
                    PaymentTerm.Category = "PAYMENTMODE";
                    PaymentTerm.IsActive = true;
                    
                    List<ProjectTerm> LstPaymentTerm = ProjectTermBLL.GetAll(PaymentTerm);
                    if (LstPaymentTerm.Count > 0)
                    {
                        ddlPaymentMode.DataSource = LstPaymentTerm;
                        ddlPaymentMode.DataTextField = "DisplayTerm";
                        ddlPaymentMode.DataValueField = "TermID";
                        ddlPaymentMode.DataBind();
                        ddlPaymentMode.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlPaymentMode.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    #endregion

                    #region Installment Type

                    DropDownList ddlInstallmentType = (e.Row.FindControl("ddlInstallmentType") as DropDownList);
                    ProjectTerm InstallmentType = new ProjectTerm();
                    InstallmentType.CompanyID = this.CompanyID;
                    InstallmentType.Category = "PAYMENTPERIOD";
                    InstallmentType.IsActive = true;

                    List<ProjectTerm> LstInstallmentType = ProjectTermBLL.GetAll(InstallmentType);
                    if (LstInstallmentType.Count > 0)
                    {
                        ddlInstallmentType.DataSource = LstInstallmentType;
                        ddlInstallmentType.DataTextField = "DisplayTerm";
                        ddlInstallmentType.DataValueField = "TermID";
                        ddlInstallmentType.DataBind();
                        ddlInstallmentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlInstallmentType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPropertyInstallmentRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                ImageButton lb = (ImageButton)e.Row.FindControl("btnRemoveRow");
                if (lb != null && dt != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void gvPropertyInstallments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                this.PropertyID = this.PropertyID;
                Session.Add("Property", this.PropertyID);
                LoadPropertyInstallmentGrid();
            }
        }

        private void LoadPropertyInstallmentGrid()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            DataSet dsPropertyInstallmentDocumentList = DocumentsBLL.GetDocumentGrid(null, null, this.CompanyID, "PROPERTYINSTALLMENTS", PropertyID);
            if (dsPropertyInstallmentDocumentList.Tables[0].Rows.Count != 0)
            {
                Guid landIssueTypeID = (Guid)dsPropertyInstallmentDocumentList.Tables[0].Rows[0]["TermID"];
                ViewState["PropertyInstallmentID"] = landIssueTypeID;
            }

            dt = dsPropertyInstallmentDocumentList.Tables[0];
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("InstallmentTypeTerm", typeof(string))); //Installment type
            dt.Columns.Add(new DataColumn("InstallmentInPercentage", typeof(string))); //installment percentage
            dt.Columns.Add(new DataColumn("MOPTerm", typeof(string))); //Payment mode
            dt.Columns.Add(new DataColumn("InstallmentAmount", typeof(string))); //installment amount

            ViewState["CurrentTable"] = dt;
            dsPropertyInstallmentDocumentList.Tables.Clear();

            // DataTable to DataSet
            dsPropertyInstallmentDocumentList.Tables.Add(dt);
            gvPropertyInstallments.DataSource = dsPropertyInstallmentDocumentList;
            gvPropertyInstallments.DataBind();

        }
        /// <summary>
        /// Save purchase schedule data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    PurchaseSchedule IsDupPurchaseSchedule = new PurchaseSchedule();
                    //List<Documents> lstLandIssueModificationDocuments = new List<Documents>();


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

    }
}