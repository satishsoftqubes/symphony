using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.BLL;
using config = SQT.Symphony.BusinessLogic.Configuration.DTO;
using configbl = SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Collections;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup
{
    public partial class CtrlAccountSetup : System.Web.UI.UserControl
    {
        #region Variable
        public bool IsListMessage = false;
        private ArrayList arlAcctID, arlAcctName, arlAcctNoName, arlDepositID;
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

        public Guid AcctID
        {
            get
            {
                return ViewState["AcctID"] != null ? new Guid(Convert.ToString(ViewState["AcctID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AcctID"] = value;
            }
        }

        public Guid UserID
        {
            get
            {
                return ViewState["UserID"] != null ? new Guid(Convert.ToString(ViewState["UserID"])) : Guid.Empty;
            }
            set
            {
                ViewState["UserID"] = value;
            }
        }
        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");

                CheckUserAuthorization();

                ClearControl();
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "ACCOUNT")
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.AcctID = clsSession.ToEditItemID;
                    clsSession.ToEditItemID = Guid.Empty;
                    BindAccountData();
                }

                BindBreadCrumb();
            }
        }

        #endregion

        #region Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "AccountSetUp.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLabels();
                BindDDL();
                ////BindTreeView();
                BindTreeView_New();
                BindTaxList();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        DataView dv = null;
        private void BindTreeView()
        {
            tvAccount.Nodes.Clear();
            List<AccountGroup> lstActGrp = AccountGroupBLL.GetAll();

            for (int j = 0; j < lstActGrp.Count; j++)
            {
                DataSet ds = new DataSet();
                ds = AccountBLL.GetAllAccountsInGroup(lstActGrp[j].AcctGrpID);
                dv = new DataView(ds.Tables[0]);

                dv.RowFilter = "RefAcctID is null";

                dv.Sort = "AcctName";
                TreeNode NewNode = new TreeNode();
                NewNode.Text = lstActGrp[j].GroupName;
                NewNode.Value = Convert.ToString(lstActGrp[j].AcctGrpID);
                tvAccount.Nodes.Add(NewNode);
                for (int i = 0; i < dv.Count; i++)
                {
                    tvAccount.Nodes[j].ChildNodes.Add(BindTree(new Guid(dv[i]["AcctID"].ToString())));
                }
                dv = null;
            }
            tvAccount.ExpandAll();
        }

        public TreeNode BindTree(Guid strFindData)
        {
            DataView dvDemo = new DataView(dv.Table);
            TreeNode NewNode = new TreeNode();

            if (strFindData != Guid.Empty)
            {
                dvDemo.Sort = "AcctID";
                int rNo = dvDemo.Find(strFindData);
                //NewNode.Text = dvDemo[rNo]["AcctNo"].ToString() + ": " + dvDemo[rNo]["AcctName"].ToString();
                NewNode.Text = dvDemo[rNo]["AcctName"].ToString();
                NewNode.Value = dvDemo[rNo]["AcctID"].ToString();
            }

            dvDemo.RowFilter = "RefAcctID = '" + strFindData + "'";

            if (dvDemo.Count != 0)
            {
                for (int i = 0; i < dvDemo.Count; i++)
                {
                    NewNode.ChildNodes.Add(BindTree(new Guid(dvDemo[i]["AcctID"].ToString())));
                }
            }

            return (NewNode);
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            dr2["Link"] = "~/GUI/AccountsHome.aspx";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Ledger Acct. Setup";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccountGroupSetup", "Account Group");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = "LEDGER ACCOUNT SETUP"; //clsCommon.GetGlobalResourceText("AccountSetup", "lblMainHeader", "LEDGER ACCOUNT SETUP");
            //litAccountNo.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblAccountNo", "Account No");
            litAccountName.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblAccountName", "Account Name");
            litAccountGroup.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblAccountGroup", "Account Group");
            litSubAccount.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblSubAccount", "Sub Account");
            litDefaultAmt.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblDefaultAmt", "Default Amount");
            litOpeningBalance.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblOpeningBalance", "Opening Balance");
            litCurrentBalance.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblCurrentBalance", "Current Balance");
            litReRouteGroup.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblReRoute", "Re-Route Group");
            chkPaidOut.Text = "Is Paid Out"; //clsCommon.GetGlobalResourceText("AccountSetup", "lblPaidOut", "Paid Out");
            chkOverride.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblOverride", "Override");
            chkShowInStatement.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblShowInStatement", "Show In Statement");
            //chkIsActive.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblIsActive", "Active");
            chkIsEnable.Text = "Is Enable";
            litHeaderAccountType.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblHeaderAccountType", "Account Type");
            chkIsDefault.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblDefault", "Default");
            chkServiceAccount.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblServiceAccount", "Service Account");
            chkItemAccount.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblItemNo", "Item Account");
            chkMOPAccount.Text = "Is Payment Received"; //clsCommon.GetGlobalResourceText("AccountSetup", "lblMOP", "MOP Account");
            chkRoomRevenueAccount.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblRoomRevenueCode", "Room Revenue");
            litDefaultAccount.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblDefaultAccount", "Default Account");
            litBalanceType.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblBalanceType", "Balance Type");
            litTaxes.Text = clsCommon.GetGlobalResourceText("AccountSetup", "lblTaxes", "Taxes");
            rdoCredit.Text = clsCommon.GetGlobalResourceText("AccountSetup", "rdoCr", "Credit");
            rdoDebit.Text = clsCommon.GetGlobalResourceText("AccountSetup", "rdoDr", "Debit");

            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }

        /// <summary>
        /// Load All DDL
        /// </summary>
        private void BindDDL()
        {
            try
            {
                string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

                List<AccountGroup> lstAccountGroup = AccountGroupBLL.GetAll();
                if (lstAccountGroup.Count != 0)
                {
                    ddlAccountGroup.DataSource = lstAccountGroup;
                    ddlAccountGroup.DataTextField = "GroupName";
                    ddlAccountGroup.DataValueField = "AcctGrpID";
                    ddlAccountGroup.DataBind();
                    ddlAccountGroup.SelectedIndex = 0;
                    ddlAccountGroup_SelectedIndexChanged(null, null);
                }

                ////Don't bind here, b'cas ddlAccountGroup_SelectedIndexChanged(null, null); on upper line will bind this dropdown list.
                //Account objSubAccount = new Account();
                //objSubAccount.IsActive = true;
                //objSubAccount.CompanyID = clsSession.CompanyID;
                //objSubAccount.PropertyID = clsSession.PropertyID;

                //List<Account> lstSubAccount = AccountBLL.GetAll(objSubAccount);
                //if (lstSubAccount.Count > 0)
                //{
                //    lstSubAccount.Sort((Account a1, Account a2) => a1.AcctName.CompareTo(a2.AcctName));
                //    ddlSubAccount.DataSource = lstSubAccount;
                //    ddlSubAccount.DataTextField = "AcctName";
                //    ddlSubAccount.DataValueField = "AcctID";
                //    ddlSubAccount.DataBind();
                //    ddlSubAccount.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                //}
                //else
                //    ddlSubAccount.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                ddlReRouteGroup.Items.Clear();
                List<config.ProjectTerm> lstProjectTermMS = configbl.ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "TRANSACTION ZONE");
                if (lstProjectTermMS.Count != 0)
                {
                    ddlReRouteGroup.Items.Insert(0, new ListItem(strSelect, "-1"));
                    int k = 1;
                    for (int i = 0; i < lstProjectTermMS.Count; i++)
                    {
                        if ((lstProjectTermMS[i].Term.ToUpper() == "ACCOMODATION" || lstProjectTermMS[i].Term.ToUpper() == "CALL LOGGER" || lstProjectTermMS[i].Term.ToUpper() == "RESTAURENT" || lstProjectTermMS[i].Term.ToUpper() == "POS" || lstProjectTermMS[i].Term.ToUpper() == "MISCELLANEOUS"))
                        {
                            ddlReRouteGroup.Items.Insert(k, new ListItem(lstProjectTermMS[i].DisplayTerm, Convert.ToString(lstProjectTermMS[i].SymphonyValue)));
                            k++;
                        }
                    }
                }
                else
                    ddlReRouteGroup.Items.Insert(0, new ListItem(strSelect, "-1"));

                List<config.ProjectTerm> lstProjectTermMP = configbl.ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
                if (lstProjectTermMP.Count != 0)
                {
                    ddlMOPAccount.DataSource = lstProjectTermMP;
                    ddlMOPAccount.DataTextField = "DisplayTerm";
                    ddlMOPAccount.DataValueField = "SymphonyValue";
                    ddlMOPAccount.DataBind();
                    ddlMOPAccount.Items.Insert(0, new ListItem(strSelect, "-1"));
                }
                else
                    ddlMOPAccount.Items.Insert(0, new ListItem(strSelect, "-1"));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Display all existing Taxes in List.
        /// </summary>
        private void BindTaxList()
        {
            try
            {
                DataSet dsTax = new DataSet();
                Account objAccount = new Account();
                objAccount.IsActive = true;
                objAccount.IsEnable = true;
                objAccount.IsTaxAcct = true;
                objAccount.CompanyID = clsSession.CompanyID;
                objAccount.PropertyID = clsSession.PropertyID;

                dsTax = AccountBLL.GetAllWithDataSet(objAccount);

                chklstTax.Items.Clear();
                if (dsTax.Tables.Count > 0 && dsTax.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsTax.Tables[0]);
                    dv.Sort = "AcctName asc";
                    chklstTax.DataValueField = "AcctID";
                    chklstTax.DataTextField = "AcctName";
                    chklstTax.DataSource = dv;
                    chklstTax.DataBind();
                }

                //List<AccountGroup> lstAcctGrp = AccountGroupBLL.GetAllBy(AccountGroup.AccountGroupFields.SymphonyGroupID, 4);
                //DataView dv = new DataView(AccountBLL.GetAllAccountsInGroup(lstAcctGrp[0].AcctGrpID).Tables[0]);
                //dv.RowFilter = "TaxRate is not null and IsTaxFlat is not null and IsEnable = true";
                //dv.Sort = "AcctName";
                //chklstTax.DataValueField = "AcctID";
                //chklstTax.DataTextField = "AcctName";
                //chklstTax.DataSource = dv;
                //chklstTax.DataBind();

                string strQuery = "select AcctID,AcctName from acc_Account where IsActive = 1 and IsTaxacct = 1 and IsEnable = 1 and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' order by AcctName";

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            this.AcctID = Guid.Empty;
            BindData();
            //txtAccountNo.Text = "";
            txtAccountName.Text = "";
            litOpeningBalance.Text = "Opening Balance [ " + clsSession.CurrentCurrency + " ]";
            litCurrentBalance.Text = "Current Balance [ " + clsSession.CurrentCurrency + " ]";
            litDefaultAccount.Text = "Amount [ " + clsSession.CurrentCurrency + " ]";
            txtDefaultAmt.Text = txtCurrentBalance.Text = txtOpeningBalance.Text = "0.00";
            chkPaidOut.Checked = chkOverride.Checked = chkShowInStatement.Checked = chkIsEnable.Checked = false; //chkIsActive.Checked = false;
            chkIsDefault.Checked = chkServiceAccount.Checked = chkItemAccount.Checked = chkMOPAccount.Checked = chkRoomRevenueAccount.Checked = false;
            rdoCredit.Checked = true;
            rdoDebit.Checked = false;
            chklstTax.Visible = true;
            chklstTax.ClearSelection();
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
        }

        private void ClearControl_Bank()
        {
            txtBankName.Text = txtContactName.Text = txtContactNo.Text = txtSortCode.Text = ""; // txtAccountNo.Text = "";
            txtBalance.Text = "0.00";
            txtAddress1.Text = txtAddress2.Text = txtCity.Text = txtZipCode.Text = txtState.Text = txtCountry.Text = "";

        }
        /// <summary>
        /// Load Account Data
        /// </summary>
        private void BindAccountData()
        {
            try
            {
                if (this.AcctID != Guid.Empty)
                {
                    Account objLoadAcctData = AccountBLL.GetByPrimaryKey(this.AcctID);

                    if (objLoadAcctData != null)
                    {
                        //txtAccountNo.Text = Convert.ToString(objLoadAcctData.AcctNo);
                        txtAccountName.Text = Convert.ToString(objLoadAcctData.AcctName);
                        ddlAccountGroup.SelectedIndex = ddlAccountGroup.Items.FindByValue(Convert.ToString(objLoadAcctData.AcctGroupID)) != null ? ddlAccountGroup.Items.IndexOf(ddlAccountGroup.Items.FindByValue(Convert.ToString(objLoadAcctData.AcctGroupID))) : 0;
                        ddlAccountGroup_SelectedIndexChanged(null, null);
                        ddlSubAccount.SelectedIndex = ddlSubAccount.Items.FindByValue(Convert.ToString(objLoadAcctData.RefAcctID)) != null ? ddlSubAccount.Items.IndexOf(ddlSubAccount.Items.FindByValue(Convert.ToString(objLoadAcctData.RefAcctID))) : 0;
                        ddlReRouteGroup.SelectedIndex = ddlReRouteGroup.Items.FindByValue(Convert.ToString(objLoadAcctData.TransactionZone_TermID)) != null ? ddlReRouteGroup.Items.IndexOf(ddlReRouteGroup.Items.FindByValue(Convert.ToString(objLoadAcctData.TransactionZone_TermID))) : 0;
                        txtCurrentBalance.Text = Convert.ToDecimal(objLoadAcctData.CurrentBalance).ToString("N");
                        txtDefaultAmt.Text = Convert.ToDecimal(objLoadAcctData.DefaultAmt).ToString("N");
                        txtOpeningBalance.Text = Convert.ToDecimal(objLoadAcctData.OpeningBalance).ToString("N");
                        chkPaidOut.Checked = Convert.ToBoolean(objLoadAcctData.IsPaidOut);
                        chkOverride.Checked = Convert.ToBoolean(objLoadAcctData.IsOverride);
                        chkShowInStatement.Checked = Convert.ToBoolean(objLoadAcctData.IsShowInStatement);
                        //chkIsActive.Checked = Convert.ToBoolean(objLoadAcctData.IsActive);
                        chkIsEnable.Checked = Convert.ToBoolean(objLoadAcctData.IsEnable);
                        chkIsDefault.Checked = Convert.ToBoolean(objLoadAcctData.IsDefaultAccount);
                        chkServiceAccount.Checked = Convert.ToBoolean(objLoadAcctData.IsServiceAccount);
                        chkItemAccount.Checked = Convert.ToBoolean(objLoadAcctData.IsItemAccount);
                        chkMOPAccount.Checked = Convert.ToBoolean(objLoadAcctData.IsMOPAccount);
                        chkRoomRevenueAccount.Checked = Convert.ToBoolean(objLoadAcctData.IsRoomRevenueAccount);
                        if (objLoadAcctData.BalancyType_Term != null)
                        {
                            if (Convert.ToString(objLoadAcctData.BalancyType_Term).Equals("CR"))
                                rdoCredit.Checked = true;
                            else if (Convert.ToString(objLoadAcctData.BalancyType_Term).Equals("DR"))
                                rdoDebit.Checked = true;
                        }

                        if (objLoadAcctData.SymphonyAcctGroupID == 3)
                            chklstTax.Visible = litTaxes.Visible = false;
                        else if ((objLoadAcctData.SymphonyAcctGroupID == 4 && objLoadAcctData.SymphonyAcctID == 8) || (objLoadAcctData.SymphonyAcctGroupID == 4 && objLoadAcctData.SymphonyAcctID == 8))
                            chklstTax.Visible = litTaxes.Visible = true;
                        else if (objLoadAcctData.SymphonyAcctGroupID == 1 || objLoadAcctData.SymphonyAcctGroupID == 2)
                            chklstTax.Visible = litTaxes.Visible = true;
                        else
                            chklstTax.Visible = litTaxes.Visible = false;

                        if (objLoadAcctData.SymphonyAcctGroupID == 1 || objLoadAcctData.SymphonyAcctGroupID == 2 || (objLoadAcctData.SymphonyAcctGroupID == 4 && objLoadAcctData.SymphonyAcctID == 8) || (objLoadAcctData.SymphonyAcctGroupID == 4 && objLoadAcctData.SymphonyAcctID == 8))
                        {
                            chklstTax.Visible = litTaxes.Visible = true;
                            DataView dv = new DataView(AcctTaxJoinBLL.GetAllWithDataSet(null, objLoadAcctData.AcctID, null).Tables[0]);
                            for (int i = 0; i < chklstTax.Items.Count; i++)
                                chklstTax.Items[i].Selected = false;

                            for (int i = 0; i < dv.Count; i++)
                            {
                                for (int j = 0; j < chklstTax.Items.Count; j++)
                                {
                                    if (Convert.ToString(dv[i]["AcctTaxID"]).Equals(Convert.ToString(chklstTax.Items[j].Value)))
                                    {
                                        chklstTax.Items[j].Selected = true;
                                    }
                                }
                            }
                        }

                        if (Convert.ToInt32(objLoadAcctData.SymphonyAcctGroupID) == 3 && (chkMOPAccount.Checked || chkPaidOut.Checked))
                        {
                            lblMOPAcct.Visible = true;
                            ddlMOPAccount.Visible = true;
                            if (objLoadAcctData.MOP_TermID != null)
                                ddlMOPAccount.SelectedValue = Convert.ToString(objLoadAcctData.MOP_TermID);
                            else
                                ddlMOPAccount.SelectedValue = "-1";
                        }
                        else
                        {
                            lblMOPAcct.Visible = ddlMOPAccount.Visible = false;
                            ddlMOPAccount.SelectedValue = "-1";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Update Account Data
        /// </summary>
        private void InsertUpdateAccountData()
        {
            Account objToCheckDuplicate = new Account();
            objToCheckDuplicate.IsActive = true;
            objToCheckDuplicate.CompanyID = clsSession.CompanyID;
            objToCheckDuplicate.PropertyID = clsSession.PropertyID;
            objToCheckDuplicate.AcctName = txtAccountName.Text.Trim();

            List<Account> lstAccounts = AccountBLL.GetAll(objToCheckDuplicate);
            if (lstAccounts.Count > 0)
            {
                if (this.AcctID != Guid.Empty)
                {
                    //Edit Mode
                    if (lstAccounts[0].AcctID != this.AcctID)
                    {
                        IsListMessage = true;
                        litListMessage.Text = "Record with same account name already exist."; //clsCommon.GetGlobalResourceText("RateCard", "lblMsgRatecardWithSameNameExists", "Ratecard with same name already exist.");
                        return;
                    }
                }
                else
                {
                    IsListMessage = true;
                    litListMessage.Text = "Record with same account name already exist."; //clsCommon.GetGlobalResourceText("RateCard", "lblMsgRatecardWithSameNameExists", "Ratecard with same name already exist.");
                    return;
                }
            }

            if (this.AcctID != Guid.Empty)
            {
                Account objToUpdate = AccountBLL.GetByPrimaryKey(this.AcctID);
                Account AcctOldData = AccountBLL.GetByPrimaryKey(this.AcctID);

                objToUpdate.PropertyID = clsSession.PropertyID;
                objToUpdate.CompanyID = clsSession.CompanyID;
                //objToUpdate.AcctNo = txtAccountNo.Text.Trim();
                objToUpdate.AcctName = txtAccountName.Text.Trim();
                if (ddlAccountGroup.SelectedValue != Guid.Empty.ToString())
                    objToUpdate.AcctGroupID = new Guid(ddlAccountGroup.SelectedValue);
                else
                    objToUpdate.AcctGroupID = null;
                if (ddlSubAccount.SelectedValue != Guid.Empty.ToString())
                    objToUpdate.RefAcctID = new Guid(ddlSubAccount.SelectedValue);
                else
                    objToUpdate.RefAcctID = null;
                if (Convert.ToString(ddlReRouteGroup.SelectedValue) != "" && ddlReRouteGroup.SelectedValue != "-1")
                    objToUpdate.TransactionZone_TermID = Convert.ToInt32(ddlReRouteGroup.SelectedValue);
                else
                    objToUpdate.TransactionZone_TermID = null;
                if (Convert.ToDouble(txtOpeningBalance.Text.Trim()) > 0)
                    objToUpdate.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text.Trim());
                else
                    objToUpdate.OpeningBalance = 0;
                if (Convert.ToDouble(txtCurrentBalance.Text.Trim()) > 0)
                    objToUpdate.CurrentBalance = Convert.ToDecimal(txtCurrentBalance.Text.Trim());
                else
                    objToUpdate.CurrentBalance = 0;
                if (Convert.ToDouble(txtDefaultAmt.Text.Trim()) > 0)
                    objToUpdate.DefaultAmt = Convert.ToDecimal(txtDefaultAmt.Text.Trim());
                else
                    objToUpdate.DefaultAmt = 0;
                if (rdoCredit.Checked)
                    objToUpdate.BalancyType_Term = "CR";
                else if (rdoDebit.Checked)
                    objToUpdate.BalancyType_Term = "DR";

                if (txtAccountName.Text.ToUpper().Equals("ACCOUNT PAYABLE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 17;
                }
                else if (txtAccountName.Text.ToUpper().Equals("RESTAURENT"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 23;
                }
                else if (txtAccountName.Text.ToUpper().Equals("PAYMENT TYPE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 31;
                }
                else if (txtAccountName.Text.ToUpper().Equals("VISA"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 4;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ADJUSTMENT"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 15;
                }
                else if (txtAccountName.Text.ToUpper().Equals("COGS"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 27;
                }
                else if (txtAccountName.Text.ToUpper().Equals("DISCOUNT"))
                {
                    objToUpdate.SymphonyAcctGroupID = 2;
                    objToUpdate.SymphonyAcctID = 29;
                }
                else if (txtAccountName.Text.ToUpper().Equals("STOCK ASSET"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 28;
                }
                else if (txtAccountName.Text.ToUpper().Equals("LAUNDRY SERVICE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 2;
                    objToUpdate.SymphonyAcctID = 44;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CITY LEDGER/DIRECT BILL"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 1;
                }
                else if (txtAccountName.Text.ToUpper().Equals("DEPOSIT"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 8;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CREDIT CARD"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 35;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CONFERENCE REVENUE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 6;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CARD"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 3;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CUSTOMERS"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 30;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CANCELLATION FEES"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 7;
                }
                else if (txtAccountName.Text.ToUpper().Equals("MISC"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 24;
                }
                else if (txtAccountName.Text.ToUpper().Equals("TRANSFERRED"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 25;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ADVANCE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 9;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CASH"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 2;
                }
                else if (txtAccountName.Text.ToUpper().Equals("OPENING BAL EQUITY"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 32;
                }
                else if (txtAccountName.Text.ToUpper().Equals("MASTER CARD"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 26;
                }
                else if (txtAccountName.Text.ToUpper().Equals("TAX"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 10;
                }
                else if (txtAccountName.Text.ToUpper().Equals("UNCATEGORIZED INCOME"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 36;
                }
                else if (txtAccountName.Text.ToUpper().Equals("PROFIT & LOSS"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 34;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CHEQUE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 22;
                }
                else if (txtAccountName.Text.ToUpper().Equals("Z VAT"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 12;
                }
                else if (txtAccountName.Text.ToUpper().Equals("S VAT"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 11;
                }
                else if (txtAccountName.Text.ToUpper().Equals("UNCATEGORIZED EXPENSE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 4;
                    objToUpdate.SymphonyAcctID = 37;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ACCOUNT RECEIVABLE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 16;
                }
                else if (txtAccountName.Text.ToUpper().Equals("PHONE CALL"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 18;
                }
                else if (txtAccountName.Text.ToUpper().Equals("SHARES & CAPITALS"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 33;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ROOM REVENUE"))
                {
                    objToUpdate.SymphonyAcctGroupID = 1;
                    objToUpdate.SymphonyAcctID = 5;
                }
                else if (txtAccountName.Text.ToUpper().Equals("COMMISSION"))
                {
                    objToUpdate.SymphonyAcctGroupID = 2;
                    objToUpdate.SymphonyAcctID = 14;
                }
                else if (txtAccountName.Text.ToUpper().Equals("BANK"))
                {
                    objToUpdate.SymphonyAcctGroupID = 3;
                    objToUpdate.SymphonyAcctID = 19;
                }

                AccountGroup accGrp = AccountGroupBLL.GetByPrimaryKey(new Guid(ddlAccountGroup.SelectedValue));
                objToUpdate.SymphonyAcctGroupID = accGrp.SymphonyGroupID;

                objToUpdate.IsPaidOut = chkPaidOut.Checked;
                objToUpdate.IsOverride = chkOverride.Checked;
                objToUpdate.IsShowInStatement = chkShowInStatement.Checked;
                objToUpdate.IsEnable = chkIsEnable.Checked;
                objToUpdate.IsDefaultAccount = chkIsDefault.Checked;
                objToUpdate.IsServiceAccount = chkServiceAccount.Checked;
                objToUpdate.IsItemAccount = chkItemAccount.Checked;
                objToUpdate.IsMOPAccount = chkMOPAccount.Checked;
                objToUpdate.IsRoomRevenueAccount = chkRoomRevenueAccount.Checked;
                if (objToUpdate.SymphonyAcctGroupID == 3 && (chkMOPAccount.Checked || chkPaidOut.Checked))
                {
                    objToUpdate.MOP_TermID = Convert.ToInt32(ddlMOPAccount.SelectedValue);
                }
                objToUpdate.UpdatedBy = clsSession.UserID;
                objToUpdate.UpdatedOn = System.DateTime.Now;
                AccountBLL.Update(objToUpdate);

                configbl.ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", AcctOldData.ToString(), objToUpdate.ToString(), "acc_Account");
                litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                if (objToUpdate.SymphonyAcctGroupID == 1 || objToUpdate.SymphonyAcctGroupID == 2 || (objToUpdate.SymphonyAcctGroupID == 4 && objToUpdate.SymphonyAcctID == 8) || (objToUpdate.SymphonyAcctGroupID == 4 && objToUpdate.SymphonyAcctID == 8))
                {
                    //Wrong
                    ////AcctTaxJoinBLL.Delete(objToUpdate.AcctID); // Delete Existing Tax related to Account.
                    AcctTaxJoinBLL.Delete(AcctTaxJoin.AcctTaxJoinFields.AcctID, Convert.ToString(objToUpdate.AcctID));
                    configbl.ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Delete", null, null, "Account -> Tax", "Delete Tax of Account -> " + txtAccountName.Text.Trim());

                    //Insert Account's Tax Information.                            
                    for (int i = 0; i < chklstTax.Items.Count; i++)
                    {
                        if (chklstTax.Items[i].Selected)
                        {
                            AcctTaxJoin objAcctTax = new AcctTaxJoin();
                            objAcctTax.AcctID = objToUpdate.AcctID;

                            ////objAcctTax.AcctTaxID = new Guid(chklstTax.SelectedValue);
                            objAcctTax.AcctTaxID = new Guid(chklstTax.Items[i].Value);
                            AcctTaxJoinBLL.Save(objAcctTax);
                        }
                    }
                    configbl.ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Insert", null, objToUpdate.ToString(), "Account -> Tax", "Insert Taxes of Account -> " + txtAccountName.Text.Trim());
                }
            }
            else
            {
                Account objIns = new Account();
                objIns.PropertyID = clsSession.PropertyID;
                objIns.CompanyID = clsSession.CompanyID;
                //objIns.AcctNo = txtAccountNo.Text.Trim();
                objIns.AcctName = txtAccountName.Text.Trim();
                if (Convert.ToString(ddlAccountGroup.SelectedValue) != "" && ddlAccountGroup.SelectedValue != "-1")
                    objIns.AcctGroupID = new Guid(ddlAccountGroup.SelectedValue);
                else
                    objIns.AcctGroupID = null;
                if (ddlSubAccount.SelectedValue != Guid.Empty.ToString())
                    objIns.RefAcctID = new Guid(ddlSubAccount.SelectedValue);
                else
                    objIns.RefAcctID = null;
                if (Convert.ToString(ddlReRouteGroup.SelectedValue) != "" && ddlReRouteGroup.SelectedValue != "-1")
                    objIns.TransactionZone_TermID = Convert.ToInt32(ddlReRouteGroup.SelectedValue);
                else
                    objIns.TransactionZone_TermID = null;
                if (Convert.ToDouble(txtOpeningBalance.Text.Trim()) > 0)
                    objIns.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text.Trim());
                else
                    objIns.OpeningBalance = 0;
                if (Convert.ToDouble(txtCurrentBalance.Text.Trim()) > 0)
                    objIns.CurrentBalance = Convert.ToDecimal(txtCurrentBalance.Text.Trim());
                else
                    objIns.CurrentBalance = 0;
                if (Convert.ToDouble(txtDefaultAmt.Text.Trim()) > 0)
                    objIns.DefaultAmt = Convert.ToDecimal(txtDefaultAmt.Text.Trim());
                else
                    objIns.DefaultAmt = 0;
                if (rdoCredit.Checked)
                    objIns.BalancyType_Term = "CR";
                else if (rdoDebit.Checked)
                    objIns.BalancyType_Term = "DR";
                if (txtAccountName.Text.ToUpper().Equals("ACCOUNT PAYABLE"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 17;
                }
                else if (txtAccountName.Text.ToUpper().Equals("RESTAURENT"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 23;
                }
                else if (txtAccountName.Text.ToUpper().Equals("PAYMENT TYPE"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 31;
                }
                else if (txtAccountName.Text.ToUpper().Equals("VISA"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 4;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ADJUSTMENT"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 15;
                }
                else if (txtAccountName.Text.ToUpper().Equals("COGS"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 27;
                }
                else if (txtAccountName.Text.ToUpper().Equals("DISCOUNT"))
                {
                    objIns.SymphonyAcctGroupID = 2;
                    objIns.SymphonyAcctID = 29;
                }
                else if (txtAccountName.Text.ToUpper().Equals("STOCK ASSET"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 28;
                }
                else if (txtAccountName.Text.ToUpper().Equals("LAUNDRY SERVICE"))
                {
                    objIns.SymphonyAcctGroupID = 2;
                    objIns.SymphonyAcctID = 44;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CITY LEDGER/DIRECT BILL"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 1;
                }
                else if (txtAccountName.Text.ToUpper().Equals("DEPOSIT"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 8;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CREDIT CARD"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 35;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CONFERENCE REVENUE"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 6;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CARD"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 3;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CUSTOMERS"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 30;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CANCELLATION FEES"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 7;
                }
                else if (txtAccountName.Text.ToUpper().Equals("MISC"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 24;
                }
                else if (txtAccountName.Text.ToUpper().Equals("TRANSFERRED"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 25;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ADVANCE"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 9;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CASH"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 2;
                }
                else if (txtAccountName.Text.ToUpper().Equals("OPENING BAL EQUITY"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 32;
                }
                else if (txtAccountName.Text.ToUpper().Equals("MASTER CARD"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 26;
                }
                else if (txtAccountName.Text.ToUpper().Equals("TAX"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 10;
                }
                else if (txtAccountName.Text.ToUpper().Equals("UNCATEGORIZED INCOME"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 36;
                }
                else if (txtAccountName.Text.ToUpper().Equals("PROFIT & LOSS"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 34;
                }
                else if (txtAccountName.Text.ToUpper().Equals("CHEQUE"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 22;
                }
                else if (txtAccountName.Text.ToUpper().Equals("Z VAT"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 12;
                }
                else if (txtAccountName.Text.ToUpper().Equals("S VAT"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 11;
                }
                else if (txtAccountName.Text.ToUpper().Equals("UNCATEGORIZED EXPENSE"))
                {
                    objIns.SymphonyAcctGroupID = 4;
                    objIns.SymphonyAcctID = 37;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ACCOUNT RECEIVABLE"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 16;
                }
                else if (txtAccountName.Text.ToUpper().Equals("PHONE CALL"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 18;
                }
                else if (txtAccountName.Text.ToUpper().Equals("SHARES & CAPITALS"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 33;
                }
                else if (txtAccountName.Text.ToUpper().Equals("ROOM REVENUE"))
                {
                    objIns.SymphonyAcctGroupID = 1;
                    objIns.SymphonyAcctID = 5;
                }
                else if (txtAccountName.Text.ToUpper().Equals("COMMISSION"))
                {
                    objIns.SymphonyAcctGroupID = 2;
                    objIns.SymphonyAcctID = 14;
                }
                else if (txtAccountName.Text.ToUpper().Equals("BANK"))
                {
                    objIns.SymphonyAcctGroupID = 3;
                    objIns.SymphonyAcctID = 19;
                }

                AccountGroup accGrp = AccountGroupBLL.GetByPrimaryKey(new Guid(ddlAccountGroup.SelectedValue));
                objIns.SymphonyAcctGroupID = accGrp.SymphonyGroupID;

                objIns.IsPaidOut = chkPaidOut.Checked;
                objIns.IsOverride = chkOverride.Checked;
                objIns.IsShowInStatement = chkShowInStatement.Checked;
                objIns.IsActive = true; //chkIsActive.Checked;
                objIns.IsEnable = chkIsEnable.Checked;
                objIns.IsDefaultAccount = chkIsDefault.Checked;
                objIns.IsServiceAccount = chkServiceAccount.Checked;
                objIns.IsItemAccount = chkItemAccount.Checked;
                objIns.IsMOPAccount = chkMOPAccount.Checked;
                objIns.IsRoomRevenueAccount = chkRoomRevenueAccount.Checked;
                if (objIns.SymphonyAcctGroupID == 3 && (chkMOPAccount.Checked || chkPaidOut.Checked))
                {
                    objIns.MOP_TermID = Convert.ToInt32(ddlMOPAccount.SelectedValue);
                }
                objIns.IsSynch = false;

                AccountBLL.Save(objIns);
                configbl.ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Insert", objIns.ToString(), objIns.ToString(), "acc_Account");
                litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordInsertedSuccessfully", "Record Inserted successfully.");

                //List<Account> lstAccount = AccountBLL.GetAllBy(Account.AccountFields.AcctNo, txtAccountNo.Text.Trim());
                List<Account> lstAccount = AccountBLL.GetAllBy(Account.AccountFields.AcctID, objIns.AcctID.ToString());
                if (lstAccount.Count > 0)
                {
                    if (lstAccount[0].SymphonyAcctGroupID == 1 || lstAccount[0].SymphonyAcctGroupID == 2 || (lstAccount[0].SymphonyAcctGroupID == 4 && lstAccount[0].SymphonyAcctID == 8) || (lstAccount[0].SymphonyAcctGroupID == 4 && lstAccount[0].SymphonyAcctID == 8))
                    {
                        //Insert Account's Tax Information.                            
                        for (int i = 0; i < chklstTax.Items.Count; i++)
                        {
                            if (chklstTax.Items[i].Selected)
                            {
                                AcctTaxJoin objAcctTax = new AcctTaxJoin();
                                objAcctTax.AcctID = lstAccount[0].AcctID;
                                objAcctTax.AcctTaxID = new Guid(chklstTax.Items[i].Value);
                                ////objAcctTax.AcctTaxID = new Guid(chklstTax.SelectedValue);
                                AcctTaxJoinBLL.Save(objAcctTax);
                            }
                        }
                        configbl.ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Insert", null, null, "Account -> Tax", "Insert Taxes of Account -> " + txtAccountName.Text.Trim());
                    }
                }
            }
            IsListMessage = true;

            ClearControl();
        }
        #endregion Method

        #region Button Click Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    InsertUpdateAccountData();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (this.AcctID != Guid.Empty)
                    {
                        Account objAcct = AccountBLL.GetByPrimaryKey(this.AcctID);
                        if (!Convert.ToBoolean(objAcct.IsDefaultAccount))
                        {
                            AccountBLL.Delete(this.AcctID);
                            configbl.ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objAcct.ToString(), objAcct.ToString(), "acc_Account");
                            ClearControl();
                            IsListMessage = true;
                            litListMessage.Text = "Record deleted successfully."; //clsCommon.GetGlobalResourceText("RateCard", "lblMsgRatecardWithSameNameExists", "Ratecard with same name already exist.");
                        }
                        else
                            MessageBox.Show("Can't Delete Default Account");
                    }
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
            ClearControl();
            this.AcctID = Guid.Empty;
        }

        #endregion Click Event

        protected void tvAccount_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                tvAccount.ExpandAll();
                TreeNode node = tvAccount.SelectedNode;

                string NodeID = node.Text;
                string NodeRNo = node.Value;
                if (NodeRNo != "11")
                {
                    this.AcctID = new Guid(node.Value);
                    BindAccountData();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlSubAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubAccount.SelectedIndex != -1)
            {
                Account objSympAcc = AccountBLL.GetByPrimaryKey(new Guid(Convert.ToString(ddlSubAccount.SelectedValue)));
                if (objSympAcc != null)
                {
                    if (objSympAcc.SymphonyAcctID == 19) // For Bank AccID
                    {
                        try
                        {
                            ClearControl_Bank();
                            mpeBankDetail.Show();
                        }
                        catch (Exception ex)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
            }
        }

        protected void ddlAccountGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAccountGroup.SelectedIndex != -1)
                {
                    AccountGroup accSymp = AccountGroupBLL.GetByPrimaryKey(new Guid(ddlAccountGroup.SelectedValue));
                    List<Account> grpAct = new List<Account>();

                    arlAcctID = new ArrayList();
                    arlAcctName = new ArrayList();
                    arlAcctNoName = new ArrayList();

                    ddlSubAccount.Items.Clear();
                    grpAct = AccountBLL.GetAllBy(Account.AccountFields.AcctGroupID, ddlAccountGroup.SelectedValue);
                    if (grpAct.Count > 0)
                    {
                        var filteredOutLets = from c in grpAct
                                              orderby c.AcctName
                                              where c.AcctID != this.AcctID && c.IsActive == true
                                              select c;

                        //grpAct.Sort((Account a1, Account a2) => a1.AcctName.CompareTo(a2.AcctName));
                        ddlSubAccount.DataSource = filteredOutLets;
                        ddlSubAccount.DataTextField = "AcctName";
                        ddlSubAccount.DataValueField = "AcctID";
                        ddlSubAccount.DataBind();
                        ddlSubAccount.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlSubAccount.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    chklstTax.ClearSelection();
                    if (Convert.ToInt32(accSymp.SymphonyGroupID) == 1)
                    {
                        chkServiceAccount.Visible = true;
                        chkItemAccount.Visible = true;
                        chkRoomRevenueAccount.Visible = true;
                        chkMOPAccount.Visible = false;
                        chkPaidOut.Visible = false;
                        chklstTax.Enabled = true;
                    }
                    else if (accSymp.SymphonyGroupID == 3)
                    {
                        chkServiceAccount.Visible = false;
                        chkItemAccount.Visible = false;
                        chkRoomRevenueAccount.Visible = false;
                        chkMOPAccount.Visible = true;
                        chkPaidOut.Visible = true;
                        chklstTax.Enabled = false;
                        chklstTax.ClearSelection();
                    }
                    else
                    {
                        chkServiceAccount.Visible = false;
                        chkItemAccount.Visible = false;
                        chkRoomRevenueAccount.Visible = false;
                        chkMOPAccount.Visible = false;
                        chkPaidOut.Visible = false;
                        chklstTax.Enabled = true;
                    }
                    if (accSymp.SymphonyGroupID == 4)
                        chklstTax.Enabled = false;

                    if (accSymp.SymphonyGroupID == 1 || accSymp.SymphonyGroupID == 4)
                    {
                        rdoCredit.Checked = true;
                        rdoDebit.Checked = false;
                    }
                    else if (accSymp.SymphonyGroupID == 2 || accSymp.SymphonyGroupID == 3)
                    {
                        rdoDebit.Checked = true;
                        rdoCredit.Checked = false;
                    }
                    SetMOP(null, null);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetMOP(object sender, EventArgs e)
        {
            if (ddlAccountGroup.SelectedIndex != -1)
            {
                AccountGroup accGrpSymp = AccountGroupBLL.GetByPrimaryKey(new Guid(ddlAccountGroup.SelectedValue));
                if (accGrpSymp.SymphonyGroupID == 3 && (chkMOPAccount.Checked || chkPaidOut.Checked))
                {
                    ddlMOPAccount.Visible = true;
                    lblMOPAcct.Visible = true;
                    ddlMOPAccount.SelectedIndex = -1;
                }
                else
                {
                    ddlMOPAccount.Visible = false;
                    lblMOPAcct.Visible = false;
                    ddlMOPAccount.SelectedIndex = -1;
                }
            }
        }

        protected void btnSaveBankDetail_OnClick(object sender, EventArgs e)
        {
            try
            {
                Bank bank = new Bank();
                bank.BankName = txtBankName.Text.Trim();
                bank.ContactName = txtContactName.Text.Trim();
                bank.ContactNO = txtContactNo.Text.Trim();
                //bank.AccountNo = txtAccountNo.Text.Trim();
                bank.SortCode = txtSortCode.Text.Trim();
                bank.Balance = Convert.ToDecimal(txtBalance.Text.Trim());
                bank.AcctID = new Guid(Convert.ToString(ddlSubAccount.SelectedValue));
                bank.Address = txtAddress1.Text.Trim();
                bank.Address1 = txtAddress2.Text.Trim();
                bank.City = clsCommon.City(txtCity.Text.Trim());
                bank.PostCode = txtZipCode.Text.Trim();
                bank.StateID = clsCommon.State(txtState.Text.Trim());
                bank.CountyID = clsCommon.Country(txtCountry.Text.Trim());
                bank.UserID = clsSession.UserID;
                BankBLL.Save(bank);
                mpeBankDetail.Hide();
                IsListMessage = true;
                litListMessage.Text = "Bank Detail Saved Successfully.";
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void chkMOPAccount_CheckedChanged(object sender, EventArgs e)
        {
            SetMOP(null, null);
        }

        private void BindTreeView_New()
        {
            tvAccount.Nodes.Clear();
            DataSet dsAcctGrp = new DataSet();
            dsAcctGrp = AccountGroupBLL.GetAllWithDataSet();

            if (dsAcctGrp.Tables.Count > 0 && dsAcctGrp.Tables[0].Rows.Count > 0)
            {
                DataView dv1 = new DataView(dsAcctGrp.Tables[0]);
                dv1.RowFilter = "IsActive = 1 and RefAcctGrpID is null";

                for (int k = 0; k < dv1.Count; k++)
                {
                    TreeNode NewNode = new TreeNode();
                    NewNode.Text = Convert.ToString(dv1[k]["GroupName"]);
                    NewNode.Value = Convert.ToString(dv1[k]["AcctGrpID"]);
                    NewNode.SelectAction = TreeNodeSelectAction.None;
                    tvAccount.Nodes.Add(NewNode);



                    DataSet ds = new DataSet();
                    ds = AccountBLL.GetAllAccountsInGroup(new Guid(dv1[k]["AcctGrpID"].ToString()));
                    dv = new DataView(ds.Tables[0]);
                    dv.RowFilter = "RefAcctID is null";
                    dv.Sort = "AcctName";

                    for (int i = 0; i < dv.Count; i++)
                    {
                        tvAccount.Nodes[k].ChildNodes.Add(BindTree(new Guid(dv[i]["AcctID"].ToString())));
                    }
                    dv = null;

                    DataView dv2 = new DataView(dsAcctGrp.Tables[0]);
                    dv2.RowFilter = "(AcctGrpID = '" + Convert.ToString(dv1[k]["AcctGrpID"]) + "' or RefAcctGrpID = '" + Convert.ToString(dv1[k]["AcctGrpID"]) + "') and RefAcctGrpID is not null and IsActive = 1";
                    dv2.Sort = "Seqno asc";

                    for (int l = 0; l < dv2.Count; l++)
                    {
                        TreeNode NewNode1 = new TreeNode();
                        NewNode1.Text = dv2[l]["GroupName"].ToString();
                        NewNode1.Value = dv2[l]["AcctGrpID"].ToString();
                        NewNode1.SelectAction = TreeNodeSelectAction.None;
                        tvAccount.Nodes[k].ChildNodes.Add(NewNode1);

                        ds = AccountBLL.GetAllAccountsInGroup(new Guid(dv2[l]["AcctGrpID"].ToString()));
                        dv = new DataView(ds.Tables[0]);
                        dv.RowFilter = "RefAcctID is null";
                        dv.Sort = "AcctName";

                        for (int m = 0; m < dv.Count; m++)
                        {
                            NewNode1.ChildNodes.Add(BindChildTree(new Guid(dv[m]["AcctID"].ToString())));
                        }
                        dv = null;
                    }
                }

                tvAccount.ExpandAll();
            }
        }

        private TreeNode BindChildTree(Guid strFindData)
        {
            DataView dvDemo = new DataView(dv.Table);
            TreeNode NewNode = new TreeNode();

            if (strFindData != Guid.Empty)
            {
                dvDemo.Sort = "AcctID";
                int rNo = dvDemo.Find(strFindData);
                NewNode.Text = dvDemo[rNo]["AcctName"].ToString();
                NewNode.Value = dvDemo[rNo]["AcctID"].ToString();
            }

            dvDemo.RowFilter = "RefAcctID = '" + strFindData + "'";

            if (dvDemo.Count != 0)
            {
                for (int i = 0; i < dvDemo.Count; i++)
                {
                    NewNode.ChildNodes.Add(BindChildTree(new Guid(dvDemo[i]["AcctID"].ToString())));
                }
            }

            return (NewNode);
        }
    }
}