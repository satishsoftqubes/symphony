using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.IRMSCofiguration
{
    public partial class CtrlPaymentSlabe : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid PaymentSlabeID
        {
            get
            {
                return ViewState["PaymentSlabeID"] != null ? new Guid(Convert.ToString(ViewState["PaymentSlabeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PaymentSlabeID"] = value;
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

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventARgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("PaymentSlabeSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            txtDateOfCompletion.Attributes.Add("autocomplete", "off");
            if (Session["CompanyID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadDefaultData();
                }
            }            
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("PaymentSlabeSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.PaymentSlabeID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }


        /// <summary>
        /// Load Default Data
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    string ProjectTermQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And CompanyID= '" + this.CompanyID + "' And TermID= '" + objPropertyConfiguration.DateFormatID + "'";
                    DataSet ds = ProjectTermBLL.SelectData(ProjectTermQuery);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtDateOfCompletion_ColorPickerExtender.Format = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
                        this.DateFormat = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
                    }
                    else
                    {
                        txtDateOfCompletion_ColorPickerExtender.Format = "dd/MM/yyyy";
                        this.DateFormat = "dd/MM/yyyy";
                    }
                }
                else
                {
                    txtDateOfCompletion_ColorPickerExtender.Format = "dd/MM/yyyy";
                    this.DateFormat = "dd/MM/yyyy";
                }

                BindPropertyName();
                ddlBlock.Items.Clear();            
                ddlBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSrchBlock.Items.Clear();
                ddlSrchBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                BindGrid();
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
            Guid? PropertyID;
            Guid? WingID;
            string SlabTitle = null;

            if (ddlSearchPropertyName.SelectedValue != Guid.Empty.ToString())
                PropertyID = new Guid(ddlSearchPropertyName.SelectedValue);
            else
                PropertyID = null;

            if (ddlSrchBlock.SelectedIndex != 0)
                WingID = new Guid(ddlSrchBlock.SelectedValue);
            else
                WingID = null;

            if (!(txtSTitle.Text.Trim().Equals("")))
                SlabTitle = txtSTitle.Text.Trim();
            else
                SlabTitle = null;

            DataSet dsPS = PaymentSlabeBLL.SearchData(null, PropertyID, SlabTitle, WingID);
            DataView dvPS = new DataView(dsPS.Tables[0]);
            dvPS.Sort = "SlabTitle Asc";
            grdSlabeList.DataSource = dvPS;
            grdSlabeList.DataBind();
        }

        /// <summary>
        /// Load Property Name
        /// </summary>
        private void BindPropertyName()
        {
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

                ddlSearchPropertyName.DataSource = dv;
                ddlSearchPropertyName.DataTextField = "PropertyName";
                ddlSearchPropertyName.DataValueField = "PropertyID";
                ddlSearchPropertyName.DataBind();
                ddlSearchPropertyName.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
            else
            {
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSearchPropertyName.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            BindPropertyName();
            ddlPropertyName.SelectedValue = Guid.Empty.ToString();
            ddlSearchPropertyName.SelectedValue = Guid.Empty.ToString();
            ddlBlock.Items.Clear();
            ddlBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ddlSrchBlock.Items.Clear();
            ddlSrchBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            txtSlabNo.Text = "";
            txtSlabTitle.Text = "";
            txtDateOfCompletion.Text = "";
            txtInstallment.Text = "";
            txtDescription.Text = "";
            this.PaymentSlabeID = Guid.Empty;
            lblInstallmentInPercentage.Text = "";
            hdnTotalInstallment.Value = "";
            BindGrid();
            ddlPropertyName.Enabled = true;
            ddlBlock.Enabled = true;
            validInstallment.Visible = false;            
        }

        /// <summary>
        /// Load Wing Information
        /// </summary>
        private void BindBlock()
        {
            ddlBlock.Items.Clear();
            Wing objLoadWing = new Wing();
            objLoadWing.IsActive = true;
            objLoadWing.PropertyID = new Guid(ddlPropertyName.SelectedValue);
            List<Wing> LstWin = WingBLL.GetAll(objLoadWing);
            if (LstWin.Count > 0)
            {
                LstWin.Sort((Wing win1, Wing win2) => win1.WingName.CompareTo(win2.WingName));
                ddlBlock.DataSource = LstWin;
                ddlBlock.DataTextField = "WingName";
                ddlBlock.DataValueField = "WingID";
                ddlBlock.DataBind();
                ddlBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        #endregion Private Method

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPaymentSlabeYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PaymentSlabeID != Guid.Empty)
                {
                    msgbx.Hide();
                    PaymentSlabe objDelete = PaymentSlabeBLL.GetByPrimaryKey(this.PaymentSlabeID);
                    PaymentSlabeBLL.Delete(this.PaymentSlabeID);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "mst_PaymentSlabe");

                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPaymentSlabeNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event

        #region Control Event
        /// <summary>
        /// New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    if (Convert.ToDouble(txtInstallment.Text) <= 0)
                    {
                        validInstallment.Visible = true;
                        return;
                    }
                    else
                        validInstallment.Visible = false;

                    PaymentSlabe IsDupPaymentSlabe = new PaymentSlabe();
                    IsDupPaymentSlabe.PropertyID = new Guid(Convert.ToString(ddlPropertyName.SelectedValue));
                    IsDupPaymentSlabe.WingID = new Guid(Convert.ToString(ddlBlock.SelectedValue));
                    IsDupPaymentSlabe.SlabTitle = txtSlabTitle.Text.Trim();
                    IsDupPaymentSlabe.IsActive = true;

                    List<PaymentSlabe> LstDupPaymentSlabe = PaymentSlabeBLL.GetAll(IsDupPaymentSlabe);

                    if (LstDupPaymentSlabe.Count > 0)
                    {
                        if (this.PaymentSlabeID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupPaymentSlabe[0].PaymentSlabeID)) != Convert.ToString(this.PaymentSlabeID.ToString()))
                            {
                                IsMessage = true;
                                lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsMessage = true;
                            lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (this.PaymentSlabeID != Guid.Empty)
                    {
                        //Update Data

                        PaymentSlabe objUpd = new PaymentSlabe();
                        PaymentSlabe objOldPSData = new PaymentSlabe();

                        objUpd = PaymentSlabeBLL.GetByPrimaryKey(this.PaymentSlabeID);
                        objOldPSData = PaymentSlabeBLL.GetByPrimaryKey(this.PaymentSlabeID);

                        objUpd.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        objUpd.WingID = new Guid(ddlBlock.SelectedValue);
                        objUpd.SlabNo = txtSlabNo.Text.Trim();
                        objUpd.SlabTitle = txtSlabTitle.Text.Trim();
                        if (!(txtInstallment.Text.Trim().Equals("")))
                            objUpd.Installment = Convert.ToDecimal(txtInstallment.Text.Trim());
                        else
                            objUpd.Installment = null;
                        objUpd.SlabDescription = txtDescription.Text.Trim();
                        if (!(txtDateOfCompletion.Text.Trim().Equals("")))
                            objUpd.DateOfCompletion = DateTime.ParseExact(txtDateOfCompletion.Text.Trim(), this.DateFormat, objCultureInfo);
                        else
                            objUpd.DateOfCompletion = null;

                        PaymentSlabeBLL.Update(objUpd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldPSData.ToString(), objUpd.ToString(), "mst_PaymentSlabe");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        //Insert Data
                        PaymentSlabe objIns = new PaymentSlabe();
                        objIns.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        objIns.WingID = new Guid(ddlBlock.SelectedValue);
                        objIns.SlabNo = txtSlabNo.Text.Trim();
                        objIns.SlabTitle = txtSlabTitle.Text.Trim();
                        if (!(txtInstallment.Text.Trim().Equals("")))
                            objIns.Installment = Convert.ToDecimal(txtInstallment.Text.Trim());
                        else
                            objIns.Installment = null;
                        objIns.SlabDescription = txtDescription.Text.Trim();
                        if (!(txtDateOfCompletion.Text.Trim().Equals("")))
                            objIns.DateOfCompletion = DateTime.ParseExact(txtDateOfCompletion.Text.Trim(), this.DateFormat, objCultureInfo);
                        else
                            objIns.DateOfCompletion = null;
                        objIns.IsActive = true;

                        PaymentSlabeBLL.Save(objIns);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "mst_PaymentSlabe");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControl();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControl();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

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

        #endregion Control Event

        #region Grid Event

        protected void grdSlabeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    
                    PaymentSlabe objLoadData = new PaymentSlabe();
                    objLoadData = PaymentSlabeBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    if (objLoadData != null)
                    {
                        this.PaymentSlabeID = objLoadData.PaymentSlabeID;                        
                        ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(objLoadData.PropertyID)) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(objLoadData.PropertyID))) : 0;
                        //Add Code By Piyush Once Update Mode Property Cann't Be able To Change
                        ddlPropertyName.Enabled = false;

                        if (ddlPropertyName.SelectedIndex != 0)
                        {
                            BindBlock();
                            ddlBlock.SelectedIndex = ddlBlock.Items.FindByValue(Convert.ToString(objLoadData.WingID)) != null ? ddlBlock.Items.IndexOf(ddlBlock.Items.FindByValue(Convert.ToString(objLoadData.WingID))) : 0;
                            ddlBlock.Enabled = false;
                        }

                        txtSlabNo.Text = Convert.ToString(objLoadData.SlabNo);
                        txtSlabTitle.Text = Convert.ToString(objLoadData.SlabTitle);
                        if (objLoadData.Installment != null)
                            txtInstallment.Text = Convert.ToString(Convert.ToInt32(objLoadData.Installment));
                        else
                            txtInstallment.Text = "";
                        if (objLoadData.DateOfCompletion != null)
                        {
                            DateTime dtDOC = Convert.ToDateTime(objLoadData.DateOfCompletion);
                            txtDateOfCompletion.Text = dtDOC.ToString(this.DateFormat);
                        }
                        else
                            txtDateOfCompletion.Text = "";
                        txtDescription.Text = Convert.ToString(objLoadData.SlabDescription);
                        this.PaymentSlabeID = new Guid(Convert.ToString(e.CommandArgument));

                        //string strInstallmentQuery = "select sum(Installment)'TotaoInstallment' from mst_PaymentSlabe where IsActive = 1 and PropertyID = '" + Convert.ToString(objLoadData.PropertyID) + "' group by PropertyID";
                        string strInstallmentQuery = "select sum(Installment)'TotaoInstallment' from mst_PaymentSlabe where IsActive = 1 and PropertyID = '" + Convert.ToString(objLoadData.PropertyID) + "' and WingID = '" + Convert.ToString(objLoadData.WingID) + "'";
                        DataSet dsInstallment = PaymentSlabeBLL.GetPaymentSlab(strInstallmentQuery);
                        if (dsInstallment.Tables[0].Rows.Count != 0)
                        {
                            lblInstallmentInPercentage.Text = "(" + Convert.ToString(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]) + " %)";
                            int maxvalue = Convert.ToInt32((100 - Convert.ToDouble(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"])) + Convert.ToDouble(txtInstallment.Text.Trim()));
                            if (Convert.ToString(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]) == "100.00")
                            {
                                rvInstallment.ErrorMessage = "100% installment value reached";
                                rvInstallment.MinimumValue = "0";
                                rvInstallment.MaximumValue = Convert.ToString(maxvalue);
                            }
                            else
                            {
                                rvInstallment.MinimumValue = "0";
                                rvInstallment.MaximumValue = Convert.ToString(maxvalue);
                                rvInstallment.ErrorMessage = "Installment value overdue !";
                            }
                            hdnTotalInstallment.Value = Convert.ToString(maxvalue);
                        }
                        else
                        {
                            lblInstallmentInPercentage.Text = "(100 %)";
                            rvInstallment.MinimumValue = "0";
                            rvInstallment.MaximumValue = "100";
                            hdnTotalInstallment.Value = "100";
                            rvInstallment.ErrorMessage = "Installment value overdue !";
                        }
                        LoadAccess();
                    }
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PaymentSlabeID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdSlabeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";
            }
        }

        #endregion Grid Event

        #region DropDown Event
        protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInstallment.Text = "";
            ddlBlock.Items.Clear();

            if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
            {
                BindBlock();
                lblInstallmentInPercentage.Text = "";
                rvInstallment.MinimumValue = "0";
                rvInstallment.MaximumValue = "100";
                txtInstallment.Text = txtSlabTitle.Text = txtSlabNo.Text = txtDateOfCompletion.Text = txtDescription.Text = "";
                hdnTotalInstallment.Value = "";
                rvInstallment.ErrorMessage = "Installment value overdue !";

                //string strInstallmentQuery = "select sum(Installment)'TotaoInstallment' from mst_PaymentSlabe where IsActive = 1 and PropertyID = '" + Convert.ToString(ddlPropertyName.SelectedValue) + "' group by PropertyID";
                //DataSet dsInstallment = PaymentSlabeBLL.GetPaymentSlab(strInstallmentQuery);
                //if (dsInstallment.Tables[0].Rows.Count != 0)
                //{
                //    lblInstallmentInPercentage.Text = "(" + Convert.ToString(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]) + " %)";
                //    double maxvalue = 100 - (Convert.ToDouble(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]));
                    
                //    hdnTotalInstallment.Value = Convert.ToString(maxvalue);
                //    if (Convert.ToString(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]) == "100.00")
                //    {
                //        rvInstallment.ErrorMessage = "100% installment value reached";
                //        rvInstallment.MinimumValue = "-2";
                //        rvInstallment.MaximumValue = "-1";
                //    }
                //    else
                //    {
                //        rvInstallment.MinimumValue = "0";
                //        rvInstallment.MaximumValue = Convert.ToString(maxvalue);
                //        rvInstallment.ErrorMessage = "Installment value overdue !";
                //    }
                //    txtInstallment.Text = Convert.ToString(maxvalue);
                //}
                //else
                //{
                //    lblInstallmentInPercentage.Text = "(0 %)";
                //    rvInstallment.MinimumValue = "0";
                //    rvInstallment.MaximumValue = "100";
                //    txtInstallment.Text = "100";
                //    hdnTotalInstallment.Value = "100";
                //    rvInstallment.ErrorMessage = "Installment value overdue !";
                //}
            }
            else
            {
                lblInstallmentInPercentage.Text = "";
                rvInstallment.MinimumValue = "0";
                rvInstallment.MaximumValue = "100";
                txtInstallment.Text = txtSlabTitle.Text = txtSlabNo.Text = txtDateOfCompletion.Text = txtDescription.Text = "";
                hdnTotalInstallment.Value = "";
                rvInstallment.ErrorMessage = "Installment value overdue !";
                ddlBlock.Items.Clear();
                ddlBlock.Items.Insert(0, new ListItem("-Select-",Guid.Empty.ToString()));
            }
        }

        protected void ddlSearchPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSrchBlock.Items.Clear();

            if (ddlSearchPropertyName.SelectedIndex != 0)
            {
                Wing objLoadWing = new Wing();
                objLoadWing.IsActive = true;
                objLoadWing.PropertyID = new Guid(ddlSearchPropertyName.SelectedValue);
                List<Wing> LstWin = WingBLL.GetAll(objLoadWing);
                if (LstWin.Count > 0)
                {
                    LstWin.Sort((Wing win1, Wing win2) => win1.WingName.CompareTo(win2.WingName));
                    ddlSrchBlock.DataSource = LstWin;
                    ddlSrchBlock.DataTextField = "WingName";
                    ddlSrchBlock.DataValueField = "WingID";
                    ddlSrchBlock.DataBind();
                    ddlSrchBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSrchBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlSrchBlock.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBlock.SelectedIndex != 0)
            {
                string strInstallmentQuery = "select sum(Installment)'TotaoInstallment' from mst_PaymentSlabe where IsActive = 1 and PropertyID = '" + Convert.ToString(ddlPropertyName.SelectedValue) + "' and WingID = '" + Convert.ToString(ddlBlock.SelectedValue) + "'";
                DataSet dsInstallment = PaymentSlabeBLL.GetPaymentSlab(strInstallmentQuery);
                if (dsInstallment.Tables[0].Rows.Count != 0 && Convert.ToString(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]) != string.Empty)
                {
                    lblInstallmentInPercentage.Text = "(" + Convert.ToString(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]) + " %)";
                    double maxvalue = 100 - (Convert.ToDouble(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]));

                    hdnTotalInstallment.Value = Convert.ToString(maxvalue);
                    if (Convert.ToString(dsInstallment.Tables[0].Rows[0]["TotaoInstallment"]) == "100.00")
                    {
                        rvInstallment.ErrorMessage = "100% installment value reached";
                        rvInstallment.MinimumValue = "-2";
                        rvInstallment.MaximumValue = "-1";
                    }
                    else
                    {
                        rvInstallment.MinimumValue = "0";
                        rvInstallment.MaximumValue = Convert.ToString(maxvalue);
                        rvInstallment.ErrorMessage = "Installment value overdue !";
                    }
                    txtInstallment.Text = Convert.ToString(maxvalue);
                    txtDateOfCompletion.Text = txtDescription.Text = txtSlabNo.Text = txtSlabTitle.Text = "";
                }
                else
                {
                    lblInstallmentInPercentage.Text = "(0 %)";
                    rvInstallment.MinimumValue = "0";
                    rvInstallment.MaximumValue = "100";
                    txtInstallment.Text = "100";
                    hdnTotalInstallment.Value = "100";
                    rvInstallment.ErrorMessage = "Installment value overdue !";
                    txtDateOfCompletion.Text = txtDescription.Text = txtSlabNo.Text = txtSlabTitle.Text = "";
                }
            }
            else
            {
                lblInstallmentInPercentage.Text = "(0 %)";
                rvInstallment.MinimumValue = "0";
                rvInstallment.MaximumValue = "100";
                //txtInstallment.Text = "100";
                txtInstallment.Text = txtSlabTitle.Text = txtSlabNo.Text = txtDateOfCompletion.Text = txtDescription.Text = "";
                hdnTotalInstallment.Value = "100";
                rvInstallment.ErrorMessage = "Installment value overdue !";
            }
        }
        #endregion DropDown Event
    }
}