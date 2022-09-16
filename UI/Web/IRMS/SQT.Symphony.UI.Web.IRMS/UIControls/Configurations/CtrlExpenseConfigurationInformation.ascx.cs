using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlExpenseConfigurationInformation : System.Web.UI.UserControl
    {
        public bool IsMessage = false;

        public Guid ExpenseID
        {
            get
            {
                return ViewState["ExpenseID"] != null ? new Guid(Convert.ToString(ViewState["ExpenseID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ExpenseID"] = value;
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

        public Guid PropertyExpenseDetailID
        {
            get
            {
                return ViewState["PropertyExpenseDetailID"] != null ? new Guid(Convert.ToString(ViewState["PropertyExpenseDetailID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationExpense.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                    if (Session["ExpenseID"] != null)
                    {
                        this.ExpenseID = new Guid(Convert.ToString(Session["ExpenseID"]));
                        LoadData();
                        Session["ExpenseID"] = null;
                    }
                    else
                        btnSave.Visible = true;
                }
            }
        }
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationExpense.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        private void LoadDefaultValue()
        {
            try
            {
                LoadLandIssueGrid();
                BindPropertyName();
                BindExpenseType();
                BindAssociation();
                BindPaymentMode();
                //BindVendorName();
                //BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadLandIssueGrid()
        {
            Guid? ExpenseID;
            if (this.ExpenseID != Guid.Empty)
                ExpenseID = this.ExpenseID;
            else
                ExpenseID = null;

            DataTable dt = new DataTable();
            DataRow dr = null;

            DataSet dsExpenseDocumentList = DocumentsBLL.GetDocumentGrid(null, null, this.CompanyID, "EXPENSEGRID", ExpenseID);
            if (dsExpenseDocumentList.Tables[0].Rows.Count != 0)
            {
                Guid landIssueTypeID = (Guid)dsExpenseDocumentList.Tables[0].Rows[0]["TermID"];
                ViewState["LandIssueTypeID"] = landIssueTypeID;
            }

            dt = dsExpenseDocumentList.Tables[0];

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));


            ViewState["CurrentTable"] = dt;
            dsExpenseDocumentList.Tables.Clear();

            // DataTable to DataSet
            dsExpenseDocumentList.Tables.Add(dt);
            gvExpenseModification.DataSource = dsExpenseDocumentList;
            gvExpenseModification.DataBind();

        }
        private void BindPropertyName()
        {
            try
            {
                List<Expense> lstExpense = null;
                Expense objExpense = new Expense();
                lstExpense = ExpenseBLL.GetAllPropertyName(objExpense);

                if (lstExpense.Count != 0)
                {
                    lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                    ddlPropertyID.DataSource = lstExpense;
                    ddlPropertyID.DataTextField = "DisplayTerm";
                    ddlPropertyID.DataValueField = "TermID";
                    ddlPropertyID.DataBind();
                    ddlPropertyID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlPropertyID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlPropertyID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindExpenseType()
        {
            List<Expense> lstExpense = null;
            Expense objExpense = new Expense();
            objExpense.Category = "EXPENSETYPE";

            lstExpense = ExpenseBLL.GetAll(objExpense);

            if (lstExpense.Count != 0)
            {
                lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlExpenseTypeTerm.DataSource = lstExpense;
                ddlExpenseTypeTerm.DataTextField = "DisplayTerm";
                ddlExpenseTypeTerm.DataValueField = "TermID";
                ddlExpenseTypeTerm.DataBind();
                ddlExpenseTypeTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlExpenseTypeTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlExpenseTypeTerm.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
        }
        private void BindAssociation()
        {
            List<Expense> lstExpense = null;
            Expense objExpense = new Expense();
            objExpense.Category = "ASSOCIATIONTYPE";

            lstExpense = ExpenseBLL.GetAll(objExpense);

            if (lstExpense.Count != 0)
            {
                lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlAssociationTypeTerm.DataSource = lstExpense;
                ddlAssociationTypeTerm.DataTextField = "DisplayTerm";
                ddlAssociationTypeTerm.DataValueField = "TermID";
                ddlAssociationTypeTerm.DataBind();
                ddlAssociationTypeTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlAssociationTypeTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlAssociationTypeTerm.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
        }
        private void BindPaymentMode()
        {
            List<Expense> lstExpense = null;
            Expense objExpense = new Expense();
            objExpense.Category = "PAYMENTMODE";

            lstExpense = ExpenseBLL.GetAll(objExpense);

            if (lstExpense.Count != 0)
            {
                lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlModeOfPaymentTerm.DataSource = lstExpense;
                ddlModeOfPaymentTerm.DataTextField = "DisplayTerm";
                ddlModeOfPaymentTerm.DataValueField = "TermID";
                ddlModeOfPaymentTerm.DataBind();
                ddlModeOfPaymentTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlModeOfPaymentTerm.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlModeOfPaymentTerm.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
        }
        //private void BindVendorName()
        //{
        //    List<Expense> lstExpense = null;
        //    Expense objExpense = new Expense();

        //    lstExpense = ExpenseBLL.GetAllVendorName(objExpense);
        //    DropDownList ddl = (DropDownList)gvExpenseModification.FindControl("ddlvendorID");
        //    //DropDownList ddl = (DropDownList)FindControl("ddlvendorID");
        //    if (lstExpense.Count != 0)
        //    {
        //        lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

        //        ddl.DataSource = lstExpense;
        //        ddl.DataTextField = "DisplayTerm";
        //        ddl.DataValueField = "VendorID";
        //        ddl.DataBind();

        //        // ddl.Items.Add(new ListItem(lstExpense));

        //        //ddlVendorID.DataSource = lstExpense;
        //        //ddlVendorID.DataTextField = "DisplayTerm";
        //        //ddlVendorID.DataValueField = "VendorID";
        //        //ddlVendorID.DataBind();
        //        //ddlVendorID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //    {
        //        ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //        ddl.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //    }
        //}

        protected void fnAddNewExpenseDetail(object sender, EventArgs e)
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
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;

                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {
                        //extract the TextBox values   
                        HiddenField h1 = (HiddenField)gvExpenseModification.Rows[i].Cells[1].FindControl("txtExpenseDetaileID");
                        if (h1.Value != "")
                        {
                            dtCurrentTable.Rows[i]["PropertyExpenseDetailID"] = new Guid(h1.Value);
                        }
                        DropDownList drop = (gvExpenseModification.Rows[i].FindControl("ddlVendorID") as DropDownList);
                        dtCurrentTable.Rows[i]["VendorID"] = drop.Text;

                        DropDownList drop1 = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlPurchaseID");
                        dtCurrentTable.Rows[i]["PurchaseTypeTerm"] = drop1.Text;

                        DropDownList drop2 = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlItemID");
                        dtCurrentTable.Rows[i]["ItemTypeTerm"] = drop2.Text;

                        TextBox box1 = (TextBox)gvExpenseModification.Rows[i].FindControl("txtAmountID");
                        dtCurrentTable.Rows[i]["TotalAmount"] = Convert.ToDecimal(box1.Text);

                        TextBox box2 = (TextBox)gvExpenseModification.Rows[i].FindControl("txtPurchaseNoteID");
                        dtCurrentTable.Rows[i]["PurchaseNote"] = box2.Text;

                        FileUpload UploadImg = (FileUpload)gvExpenseModification.Rows[i].Cells[6].FindControl("fileExpenseDocumentUpload");

                        HiddenField hidexpenseDocument = (HiddenField)gvExpenseModification.Rows[i].FindControl("expenseDocumentName");
                        dtCurrentTable.Rows[i]["DocumentName"] = hidexpenseDocument.Value;

                    }
                    gvExpenseModification.DataSource = dtCurrentTable;
                    gvExpenseModification.DataBind();

                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            SetPreviousData();
        }
        protected void gvExpense_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    string DocumentName = string.Empty;
                    DocumentName = DataBinder.Eval(e.Row.DataItem, "DocumentName").ToString();
                    string str = "~/Document/" + DocumentName;

                    HtmlAnchor aLandIssueDocumentLink = (HtmlAnchor)e.Row.FindControl("aLandIssueDocumentLink");
                    ImageButton imgbtn = (ImageButton)e.Row.FindControl("btnRemoveRow");

                    if (DocumentName != string.Empty && DocumentName != null)
                    {
                        imgbtn.Visible = Convert.ToBoolean(ViewState["Delete"]);
                        aLandIssueDocumentLink.Visible = true;
                        aLandIssueDocumentLink.HRef = str;
                    }
                    else
                    {
                        imgbtn.Visible = false;
                    }

                    List<Expense> lstExpense = null;
                    Expense objExpense = new Expense();

                    lstExpense = ExpenseBLL.GetAllVendorName(objExpense);
                    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlvendorID");

                    if (lstExpense.Count != 0)
                    {
                        lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                        ddl.DataSource = lstExpense;
                        ddl.DataTextField = "DisplayTerm";
                        ddl.DataValueField = "TermID";
                        ddl.DataBind();
                        ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                    {
                        ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                        ddl.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }

                    objExpense.Category = "PURCHASETYPE_TERM";
                    lstExpense = ExpenseBLL.GetAll(objExpense);
                    DropDownList ddl1 = (DropDownList)e.Row.FindControl("ddlPurchaseID");
                    if (lstExpense.Count != 0)
                    {
                        lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                        ddl1.DataSource = lstExpense;
                        ddl1.DataTextField = "DisplayTerm";
                        ddl1.DataValueField = "TermID";
                        ddl1.DataBind();
                        ddl1.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                    {
                        ddl1.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                        ddl1.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }

                    objExpense.Category = "ITEMTYPE_TERM";
                    lstExpense = ExpenseBLL.GetAll(objExpense);
                    DropDownList ddl2 = (DropDownList)e.Row.FindControl("ddlItemID");
                    if (lstExpense.Count != 0)
                    {
                        lstExpense.Sort((Expense p1, Expense p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                        ddl2.DataSource = lstExpense;
                        ddl2.DataTextField = "DisplayTerm";
                        ddl2.DataValueField = "TermID";
                        ddl2.DataBind();
                        ddl2.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                    {
                        ddl2.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                        ddl2.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvExpense_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                this.ExpenseID = this.ExpenseID;
                Session.Add("Expense", this.ExpenseID);
                LoadLandIssueGrid();
            }
        }
        protected void gvExpense_RowCreated(object sender, GridViewRowEventArgs e)
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
                        DropDownList drop = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlVendorID");
                        DropDownList drop1 = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlPurchaseID");
                        DropDownList drop2 = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlItemID");
                        HiddenField h1 = (HiddenField)gvExpenseModification.Rows[i].FindControl("txtExpenseDetaileID");
                        TextBox box2 = (TextBox)gvExpenseModification.Rows[i].FindControl("txtPurchaseNoteID");

                        TextBox box1 = (TextBox)gvExpenseModification.Rows[i].FindControl("txtAmountID");
                        if (i < dt.Rows.Count - 1)
                        {
                            drop.Text = dt.Rows[i]["VendorID"].ToString();
                            drop1.Text = dt.Rows[i]["PurchaseTypeTerm"].ToString();
                            drop2.Text = dt.Rows[i]["ItemTypeTerm"].ToString();
                            box1.Text = dt.Rows[i]["TotalAmount"].ToString();
                            box2.Text = dt.Rows[i]["PurchaseNote"].ToString();
                            h1.Value = dt.Rows[i]["PropertyExpenseDetailID"].ToString();
                            //file.PostedFile = dt.Rows[i]["DocumentName"];
                        }
                        rowIndex++;
                    }
                }
            }
        }
        protected void SaveExpense(object senser, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<Documents> ExpenseModificationDocuments = new List<Documents>();
                List<Documents> UpdateExpenseModificationDocuments = new List<Documents>();
                List<Expense> ExpenseDetail = new List<Expense>();
                try
                {

                    if (this.ExpenseID != Guid.Empty)
                    {
                        Expense objExpense = new Expense();
                        objExpense.DateOfExpense = txtDateOfExpense.Text.Trim();
                        objExpense.ExpenseAmount = Convert.ToDecimal(txtExpenseAmt.Text.Trim());
                        objExpense.ExpenseDetail = txtExpenseDetail.Text.Trim();
                        objExpense.PropertyID = new Guid(ddlPropertyID.SelectedValue);
                        objExpense.AssociationTypeTerm = ddlAssociationTypeTerm.SelectedValue;
                        objExpense.ExpenseTypeTerm = ddlExpenseTypeTerm.SelectedValue;
                        objExpense.ModeOfPaymentTerm = ddlModeOfPaymentTerm.SelectedValue;
                        objExpense.ExpenseID = this.ExpenseID;

                        for (int i = 0; i < gvExpenseModification.Rows.Count; i++)
                        {
                            TextBox txtAmount = (TextBox)gvExpenseModification.Rows[i].FindControl("txtAmountID");
                            TextBox txtNote = (TextBox)gvExpenseModification.Rows[i].FindControl("txtPurchaseNoteID");
                            DropDownList ddlVenodrName = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlvendorID");
                            DropDownList ddlPurchase = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlPurchaseID");
                            DropDownList ddlItem = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlItemID");
                            HiddenField h1 = (HiddenField)gvExpenseModification.Rows[i].FindControl("txtExpenseDetaileID");
                            if (gvExpenseModification.Rows.Count != 0)
                            {
                                Expense ED = new Expense();
                                ED.TotalAmount = Convert.ToDecimal(txtAmount.Text.Trim());
                                ED.PurchaseNote = txtNote.Text.Trim();
                                ED.VendorID = new Guid(ddlVenodrName.Text.Trim());
                                ED.PurchaseTypeTerm = ddlPurchase.Text.Trim();
                                ED.ItemTypeTerm = ddlItem.Text.Trim();
                                ED.PropertyID = new Guid(ddlPropertyID.SelectedValue);
                                ED.ExpenseID = this.ExpenseID;
                                if (h1.Value != "")
                                {
                                    ED.PropertyExpenseDetailID = new Guid(h1.Value);

                                }
                                if (h1.Value == "")
                                {
                                    ED.PropertyExpenseDetailID = Guid.NewGuid();
                                }
                                ExpenseDetail.Add(ED);
                                FileUpload fuDocument = (FileUpload)gvExpenseModification.Rows[i].FindControl("fileExpenseDocumentUpload");
                                HiddenField expenseDocumentName = (HiddenField)gvExpenseModification.Rows[i].FindControl("expenseDocumentName");
                                if (fuDocument.FileName != "")
                                {
                                    Documents d1 = new Documents();
                                    string FileInCorporatonNo = "PD$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");
                                    string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                    fuDocument.SaveAs(path1);
                                    d1.DocumentName = FileInCorporatonNo;
                                    d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                    d1.DateOfSubmission = DateTime.Now;
                                    d1.CreatedOn = DateTime.Now;
                                    d1.IsActive = true;
                                    d1.AssociationType = "Expense";
                                    d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                    d1.TypeID = (Guid)ViewState["LandIssueTypeID"];
                                    d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                    d1.AssociationID = ED.PropertyExpenseDetailID;

                                    ExpenseModificationDocuments.Add(d1);
                                }
                                else if (expenseDocumentName.Value != "")
                                {
                                    Documents d5 = new Documents();
                                    d5.DocumentName = expenseDocumentName.Value;
                                    d5.Extension = System.IO.Path.GetExtension(expenseDocumentName.Value);
                                    d5.DateOfSubmission = DateTime.Now;
                                    d5.UpdatedOn = DateTime.Now;
                                    d5.IsActive = true;
                                    d5.AssociationType = "Property";
                                    d5.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                    d5.TypeID = (Guid)ViewState["LandIssueTypeID"];
                                    d5.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                    d5.AssociationID = new Guid(h1.Value);
                                    ExpenseModificationDocuments.Add(d5);

                                }
                            }

                        }
                        ExpenseBLL.Update(objExpense, ExpenseModificationDocuments, ExpenseDetail);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objExpense.ToString(), objExpense.ToString(), "mst_PropertyExpenses");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.ExpenseID = objExpense.ExpenseID;
                    }
                    else
                    {
                        Expense objExpense = new Expense();
                        objExpense.DateOfExpense = txtDateOfExpense.Text.Trim();
                        objExpense.ExpenseAmount = Convert.ToDecimal(txtExpenseAmt.Text.Trim());
                        objExpense.ExpenseDetail = txtExpenseDetail.Text.Trim();
                        objExpense.PropertyID = new Guid(ddlPropertyID.SelectedValue);
                        objExpense.AssociationTypeTerm = ddlAssociationTypeTerm.SelectedValue;
                        objExpense.ExpenseTypeTerm = ddlExpenseTypeTerm.SelectedValue;
                        objExpense.ModeOfPaymentTerm = ddlModeOfPaymentTerm.SelectedValue;

                        for (int i = 0; i < gvExpenseModification.Rows.Count; i++)
                        {
                            TextBox txtAmount = (TextBox)gvExpenseModification.Rows[i].FindControl("txtAmountID");
                            TextBox txtNote = (TextBox)gvExpenseModification.Rows[i].FindControl("txtPurchaseNoteID");
                            DropDownList ddlVenodrName = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlvendorID");
                            DropDownList ddlPurchase = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlPurchaseID");
                            DropDownList ddlItem = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlItemID");
                            HiddenField h1 = (HiddenField)gvExpenseModification.Rows[i].FindControl("txtExpenseDetaileID");
                            if (gvExpenseModification.Rows.Count != 0)
                            {
                                Expense ED = new Expense();
                                ED.TotalAmount = Convert.ToDecimal(txtAmount.Text.Trim());
                                ED.PurchaseNote = txtNote.Text.Trim();
                                ED.VendorID = new Guid(ddlVenodrName.Text.Trim());
                                ED.PurchaseTypeTerm = ddlPurchase.Text.Trim();
                                ED.ItemTypeTerm = ddlItem.Text.Trim();
                                ED.PropertyID = new Guid(ddlPropertyID.SelectedValue);
                                ED.PropertyExpenseDetailID = Guid.NewGuid();
                                //ED.PropertyExpenseDetailID = new Guid(h1.Value);
                                ExpenseDetail.Add(ED);

                                FileUpload fuDocument = (FileUpload)gvExpenseModification.Rows[i].FindControl("fileExpenseDocumentUpload");

                                if (fuDocument.FileName != "")
                                {
                                    Documents d1 = new Documents();
                                    string FileInCorporatonNo = "EXPENSE$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");
                                    string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                    fuDocument.SaveAs(path1);
                                    d1.DocumentName = FileInCorporatonNo;
                                    d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                    d1.DateOfSubmission = DateTime.Now;
                                    d1.CreatedOn = DateTime.Now;
                                    d1.IsActive = true;
                                    d1.AssociationType = "Expense";
                                    d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                    d1.TypeID = (Guid)ViewState["LandIssueTypeID"];
                                    d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                    d1.AssociationID = ED.PropertyExpenseDetailID;
                                    ExpenseModificationDocuments.Add(d1);
                                }
                            }

                        }
                        ExpenseBLL.Save(objExpense, ExpenseModificationDocuments, ExpenseDetail);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objExpense.ToString(), objExpense.ToString(), "mst_PropertyExpenses");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.ExpenseID = objExpense.ExpenseID;
                    }

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            Response.Redirect("~/Applications/SetUp/Expense.aspx");
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session.Remove("Expense");
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        private void ClearControl()
        {
            txtDateOfExpense.Text = "";
            txtExpenseAmt.Text = "";
            txtExpenseDetail.Text = "";
            txtTotalAmountID.Text = "";
            ddlAssociationTypeTerm.SelectedValue = Guid.Empty.ToString();
            ddlExpenseTypeTerm.SelectedValue = Guid.Empty.ToString();
            ddlModeOfPaymentTerm.SelectedValue = Guid.Empty.ToString();
            ddlPropertyID.SelectedValue = Guid.Empty.ToString();
            LoadLandIssueGrid();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("Expense");
                Response.Redirect("~/Applications/SetUp/Expense.aspx");

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadData()
        {
            DataSet ds = new DataSet();
            ds = ExpenseBLL.GetByIdWise_ExpenseData(this.ExpenseID);

            if (ds.Tables[0].Rows.Count != 0)
            {

                txtDateOfExpense.Text = Convert.ToString(ds.Tables[0].Rows[0]["DateOfExpense"]);
                txtExpenseAmt.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExpenseAmount"]);
                txtExpenseDetail.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExpenseDetail"]);
                ddlPropertyID.Text = Convert.ToString(ds.Tables[0].Rows[0]["TermID"]);
                ddlAssociationTypeTerm.Text = Convert.ToString(ds.Tables[0].Rows[0]["AssociationTypeTerm"]);
                ddlExpenseTypeTerm.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExpenseTypeTerm"]);
                ddlModeOfPaymentTerm.Text = Convert.ToString(ds.Tables[0].Rows[0]["ModeOfPaymentTerm"]);
            }
            if (ds.Tables[1].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    if (i != 0)
                    {
                        AddNewRowToGrid();
                    }
                    DropDownList ddlVenodrName = (DropDownList)gvExpenseModification.Rows[i].Cells[1].FindControl("ddlvendorID");
                    ddlVenodrName.Text = Convert.ToString(ds.Tables[1].Rows[i]["VendorID"]);

                    DropDownList ddlPurchase = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlPurchaseID");
                    ddlPurchase.Text = Convert.ToString(ds.Tables[1].Rows[i]["PurchaseTypeTerm"]);

                    DropDownList ddlItem = (DropDownList)gvExpenseModification.Rows[i].FindControl("ddlItemID");
                    ddlItem.Text = Convert.ToString(ds.Tables[1].Rows[i]["ItemTypeTerm"]);

                    TextBox txtAmount = (TextBox)gvExpenseModification.Rows[i].FindControl("txtAmountID");
                    txtAmount.Text = Convert.ToString(ds.Tables[1].Rows[i]["TotalAmount"]);

                    TextBox txtNote = (TextBox)gvExpenseModification.Rows[i].FindControl("txtPurchaseNoteID");
                    txtNote.Text = Convert.ToString(ds.Tables[1].Rows[i]["PurchaseNote"]);

                    HiddenField ExpenseDetaileID = (HiddenField)gvExpenseModification.Rows[i].FindControl("txtExpenseDetaileID");
                    ExpenseDetaileID.Value = Convert.ToString(ds.Tables[1].Rows[i]["PropertyExpenseDetailID"]).Trim();

                    HiddenField hidFileUpload = (HiddenField)gvExpenseModification.Rows[i].FindControl("expenseDocumentName");
                    hidFileUpload.Value = Convert.ToString(ds.Tables[1].Rows[i]["DocumentName"]);

                    HtmlAnchor aLandIssueDocumentLink = (HtmlAnchor)gvExpenseModification.Rows[i].FindControl("aLandIssueDocumentLink");
                    ImageButton imgbtn = (ImageButton)gvExpenseModification.Rows[i].FindControl("btnRemoveRow");
                    imgbtn.CommandArgument = Convert.ToString(ds.Tables[1].Rows[i]["PropertyExpenseDetailID"]).Trim();

                    string str = "~/Document/" + hidFileUpload.Value;
                    if (hidFileUpload.Value != string.Empty && hidFileUpload.Value != null)
                    {
                        imgbtn.Visible = Convert.ToBoolean(ViewState["Delete"]);
                        aLandIssueDocumentLink.Visible = true;
                        aLandIssueDocumentLink.HRef = str;
                    }
                    else
                    {
                        imgbtn.Visible = false;
                    }
                }
                if (ds.Tables[2].Rows.Count != 0)
                {
                    txtTotalAmountID.Text = Convert.ToString(ds.Tables[2].Rows[0]["TotalAmount"]);
                }
            }

        }

    }
}