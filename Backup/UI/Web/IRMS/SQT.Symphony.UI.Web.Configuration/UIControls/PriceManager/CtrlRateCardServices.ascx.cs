using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardServices : System.Web.UI.UserControl
    {
        #region Property And Variables
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
        public Guid RateID
        {
            get
            {
                return ViewState["RateID"] != null ? new Guid(Convert.ToString(ViewState["RateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateID"] = value;
            }
        }

        public Guid RateServiceID
        {
            get
            {
                return ViewState["RateServiceID"] != null ? new Guid(Convert.ToString(ViewState["RateServiceID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateServiceID"] = value;
            }
        }

        public Int32 RowIndex
        {
            get
            {
                return ViewState["RowIndex"] != null ? Convert.ToInt32(ViewState["RowIndex"]) : -1;
            }
            set
            {
                ViewState["RowIndex"] = value;
            }
        }

        public DropDownList ddlucServices
        {
            get { return this.ddlServices; }
        }

        public DropDownList ddlucPostingFrequency
        {
            get { return this.ddlPostingFrequency; }
        }

        public DataTable dtRateServices = null;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                regExpServiceRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regExpServiceRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

                btnAddService.Visible = this.UserRights.Substring(1, 1) == "1";
                if (this.RateID != Guid.Empty)
                    btnAddService.Visible = this.UserRights.Substring(2, 1) == "1";

                Session["RateServiceJoin"] = null;
                SetPageLables();
                BindServiceGrid();
            }
        }

        #endregion

        #region Methods
        private void SetPageLables()
        {
            litHeaderServices.Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblHeaderServices", "Services");
            btnAddNewService.Text = clsCommon.GetGlobalResourceText("common", "lblBtnAddNew", "Add New");
            btnAddService.Text = clsCommon.GetGlobalResourceText("common", "lblBtnAdd", "Add");

            ltrHeaderAddEditService.Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblHeaderAddEditService", "Add/Edit Service");
            ltrService.Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblService", "Service");
            lblRate.Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblRate", "Rate");
            ltrPostingFrequency.Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblPostingFrequency", "Posting Frequency");
            chkIsChargePerPerson.Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblIsChargePerPerson", "Is Charge Per Person");

            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblHeaderConfirmDeletePopup", "Rate Card Service");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
        }

        public void BindServiceGrid()
        {
            if (this.RateID != Guid.Empty)
            {
                //Bind Grid From DB
                if (dtRateServices != null)
                {
                    //Page Open in Edit mode and dtRateServices set from Parent page, So no need to get data from DB when page load first time in edit mode.
                    gvServices.DataSource = dtRateServices;
                    gvServices.DataBind();
                }
                else
                {
                    //Page is open in Edit mode and reach here after once postbak, so get data from DB and Bind Grid.
                    RateServiceJoin objToGetList = new RateServiceJoin();
                    objToGetList.RateID = this.RateID;
                    objToGetList.IsActive = true;

                    DataSet dsRateServices = RateServiceJoinBLL.GetAllWithDataSet(objToGetList);

                    gvServices.DataSource = dsRateServices;
                    gvServices.DataBind();
                }
            }
            else
            {
                //Bind Grid From SessionList.
                List<RateServiceJoin> lstRateServiceJoin = null;
                if (Session["RateServiceJoin"] != null)
                    lstRateServiceJoin = (List<RateServiceJoin>)Session["RateServiceJoin"];

                gvServices.DataSource = lstRateServiceJoin;
                gvServices.DataBind();
            }

            if (gvServices.Rows.Count > 0)
            {
                if (this.UserRights.Substring(2, 1) == "0" && this.UserRights.Substring(3, 1) == "0")
                    gvServices.Columns[3].Visible = false;
            }
        }
        #endregion

        #region Control Events
        protected void btnAddNewService_OnClick(object sender, EventArgs e)
        {
            this.RowIndex = -1;
            this.RateServiceID = Guid.Empty;
            ddlServices.SelectedIndex = ddlPostingFrequency.SelectedIndex = 0;
            txtRate.Text = string.Empty;
            chkIsChargePerPerson.Checked = false;
            mpeAddEditService.Show();
        }

        protected void ddlServices_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtRate.Text = string.Empty;
                if (ddlServices.SelectedIndex != 0)
                {
                    Item objItem = ItemBLL.GetByPrimaryKey(new Guid(ddlServices.SelectedValue.ToString()));
                    if (objItem != null && Convert.ToString(objItem.DefSalesPrice) != string.Empty)
                    {
                        string strRate = Convert.ToString(objItem.DefSalesPrice);
                        if (strRate != string.Empty)
                            txtRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        else
                            txtRate.Text = string.Empty;
                    }
                }
                mpeAddEditService.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }

        protected void btnAddService_OnClick(object sender, EventArgs e)
        {
            try
            {
                List<RateServiceJoin> lstRateServiceJoin = null;
                if (Session["RateServiceJoin"] != null)
                    lstRateServiceJoin = (List<RateServiceJoin>)Session["RateServiceJoin"];
                else
                    lstRateServiceJoin = new List<RateServiceJoin>();

                if (this.RateID != Guid.Empty)
                {
                    //To Update DB here if page is Open in Edit mode.
                    if (this.RateServiceID != Guid.Empty)
                    {
                        RateServiceJoin objToUpdate = RateServiceJoinBLL.GetByPrimaryKey(this.RateServiceID);
                        objToUpdate.ItemID = new Guid(ddlServices.SelectedValue.ToString());
                        objToUpdate.PostingFreq_TermID = new Guid(ddlPostingFrequency.SelectedValue.ToString());
                        objToUpdate.IsPerPerson = chkIsChargePerPerson.Checked;
                        if (txtRate.Text.Trim() != string.Empty)
                            objToUpdate.ServiceRate = Convert.ToDecimal(txtRate.Text.Trim());
                        else
                            objToUpdate.ServiceRate = null;
                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.UpdatedOn = DateTime.Now;
                        RateServiceJoinBLL.Update(objToUpdate);
                    }
                    else
                    {
                        RateServiceJoin objToInsert = new RateServiceJoin();
                        objToInsert.IsActive = true;

                        if (ddlServices.SelectedIndex != 0)
                            objToInsert.ItemID = new Guid(ddlServices.SelectedValue);

                        if (ddlPostingFrequency.SelectedIndex != 0)
                            objToInsert.PostingFreq_TermID = new Guid(ddlPostingFrequency.SelectedValue);

                        objToInsert.IsPerPerson = chkIsChargePerPerson.Checked;
                        if (txtRate.Text.Trim() != string.Empty)
                            objToInsert.ServiceRate = Convert.ToDecimal(txtRate.Text.Trim());
                        else
                            objToInsert.ServiceRate = null;

                        objToInsert.RateID = this.RateID;

                        RateServiceJoinBLL.Save(objToInsert);
                    }
                }
                else
                {
                    if (this.RowIndex != -1)
                    {
                        //Eidt Mode
                        if (ddlServices.SelectedIndex != 0)
                        {
                            lstRateServiceJoin[this.RowIndex].ItemID = new Guid(ddlServices.SelectedValue);
                            lstRateServiceJoin[this.RowIndex].ItemName = Convert.ToString(ddlServices.SelectedItem.Text);

                            //Item objItem = ItemBLL.GetByPrimaryKey(new Guid(ddlServices.SelectedValue.ToString()));
                            //if (objItem != null && Convert.ToString(objItem.DefSalesPrice) != string.Empty)
                            //    lstRateServiceJoin[this.RowIndex].ItemRate = Convert.ToDecimal(objItem.DefSalesPrice);
                            if (txtRate.Text.Trim() != string.Empty)
                                lstRateServiceJoin[this.RowIndex].ServiceRate = Convert.ToDecimal(txtRate.Text.Trim());
                            else
                                lstRateServiceJoin[this.RowIndex].ServiceRate = null;
                        }
                        else
                        {
                            lstRateServiceJoin[this.RowIndex].ItemID = null;
                            lstRateServiceJoin[this.RowIndex].ItemName = string.Empty;
                        }

                        if (ddlPostingFrequency.SelectedIndex != 0)
                        {
                            lstRateServiceJoin[this.RowIndex].PostingFreq_TermID = new Guid(ddlPostingFrequency.SelectedValue);
                            lstRateServiceJoin[this.RowIndex].PostingFrequencyName = Convert.ToString(ddlPostingFrequency.SelectedItem.Text);
                        }
                        else
                        {
                            lstRateServiceJoin[this.RowIndex].PostingFreq_TermID = null;
                            lstRateServiceJoin[this.RowIndex].PostingFrequencyName = string.Empty;
                        }

                        lstRateServiceJoin[this.RowIndex].IsPerPerson = chkIsChargePerPerson.Checked;
                    }
                    else
                    {
                        //Insert Mode
                        RateServiceJoin objToAdd = new RateServiceJoin();
                        objToAdd.IsActive = true;

                        if (ddlServices.SelectedIndex != 0)
                        {
                            objToAdd.ItemID = new Guid(ddlServices.SelectedValue);
                            objToAdd.ItemName = Convert.ToString(ddlServices.SelectedItem.Text);

                            //Item objItem = ItemBLL.GetByPrimaryKey(new Guid(ddlServices.SelectedValue.ToString()));
                            //if (objItem != null && Convert.ToString(objItem.DefSalesPrice) != string.Empty)
                            //    objToAdd.ItemRate = Convert.ToDecimal(objItem.DefSalesPrice);
                            if (txtRate.Text.Trim() != string.Empty)
                                objToAdd.ServiceRate = Convert.ToDecimal(txtRate.Text.Trim());
                            else
                                objToAdd.ServiceRate = null;
                        }

                        if (ddlPostingFrequency.SelectedIndex != 0)
                        {
                            objToAdd.PostingFreq_TermID = new Guid(ddlPostingFrequency.SelectedValue);
                            objToAdd.PostingFrequencyName = Convert.ToString(ddlPostingFrequency.SelectedItem.Text);
                        }

                        objToAdd.IsPerPerson = chkIsChargePerPerson.Checked;
                        lstRateServiceJoin.Add(objToAdd);
                        //If To Give Message, then Process Here...                    
                    }

                    Session["RateServiceJoin"] = lstRateServiceJoin;
                }

                this.RowIndex = -1; this.RateServiceID = Guid.Empty;
                ddlServices.SelectedIndex = ddlPostingFrequency.SelectedIndex = 0;
                BindServiceGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (this.RateID != Guid.Empty && this.RateServiceID != Guid.Empty)
            {
                //Process for delete record from DB.
                RateServiceJoinBLL.Delete(this.RateServiceID);
            }
            else
            {
                //Remove from session.
                List<RateServiceJoin> lstRateServiceJoin = null;
                if (Session["RateServiceJoin"] != null && this.RowIndex != -1)
                {
                    lstRateServiceJoin = (List<RateServiceJoin>)Session["RateServiceJoin"];
                    lstRateServiceJoin.RemoveAt(this.RowIndex);

                    Session["RateServiceJoin"] = lstRateServiceJoin;
                }
            }

            this.RowIndex = -1;
            this.RateServiceID = Guid.Empty;
            BindServiceGrid();
        }

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            this.RowIndex = -1;
            this.RateServiceID = Guid.Empty;
        }
        #endregion

        #region Grid Events
        protected void gvServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvHdrServiceName")).Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblGvHdrServiceName", "Service Name");
                ((Literal)e.Row.FindControl("litGvHdrPostingFrequency")).Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblGvHdrPostingFrequency", "Posting Freq.");
                ((Literal)e.Row.FindControl("litGvHdrRate")).Text = clsCommon.GetGlobalResourceText("RateCardServices", "lblGvHdrRate", "Rate");
                ((Literal)e.Row.FindControl("litGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkDelete")).Visible = this.UserRights.Substring(3, 1) == "1";
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                Label lblRate = (Label)e.Row.FindControl("lblRate");
                string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ServiceRate"));
                if (strRate != string.Empty)
                    lblRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        protected void gvServices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ddlServices.SelectedIndex = ddlPostingFrequency.SelectedIndex = 0;
                    txtRate.Text = string.Empty;
                    chkIsChargePerPerson.Checked = false;

                    if (this.RateID != Guid.Empty)
                    {
                        this.RateServiceID = new Guid(Convert.ToString(gvServices.DataKeys[Convert.ToInt32(e.CommandArgument)]["RateServiceID"]));
                        RateServiceJoin objToLoad = RateServiceJoinBLL.GetByPrimaryKey(this.RateServiceID);
                        if (objToLoad != null)
                        {
                            ddlServices.SelectedIndex = ddlServices.Items.FindByValue(Convert.ToString(objToLoad.ItemID)) != null ? ddlServices.Items.IndexOf(ddlServices.Items.FindByValue(Convert.ToString(objToLoad.ItemID))) : 0;
                            ddlPostingFrequency.SelectedIndex = ddlPostingFrequency.Items.FindByValue(Convert.ToString(objToLoad.PostingFreq_TermID)) != null ? ddlPostingFrequency.Items.IndexOf(ddlPostingFrequency.Items.FindByValue(Convert.ToString(objToLoad.PostingFreq_TermID))) : 0;
                            string strRate = Convert.ToString(objToLoad.ServiceRate);
                            if (strRate != string.Empty)
                                txtRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            else
                                txtRate.Text = string.Empty;
                            chkIsChargePerPerson.Checked = Convert.ToBoolean(objToLoad.IsPerPerson);
                        }
                    }
                    else
                    {
                        List<RateServiceJoin> lstRateServiceJoin = null;
                        if (Session["RateServiceJoin"] != null)
                        {
                            lstRateServiceJoin = (List<RateServiceJoin>)Session["RateServiceJoin"];

                            this.RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                            RateServiceJoin objServiceJoin = lstRateServiceJoin[this.RowIndex];
                            ddlServices.SelectedIndex = ddlServices.Items.FindByValue(Convert.ToString(objServiceJoin.ItemID)) != null ? ddlServices.Items.IndexOf(ddlServices.Items.FindByValue(Convert.ToString(objServiceJoin.ItemID))) : 0;
                            ddlPostingFrequency.SelectedIndex = ddlPostingFrequency.Items.FindByValue(Convert.ToString(objServiceJoin.PostingFreq_TermID)) != null ? ddlPostingFrequency.Items.IndexOf(ddlPostingFrequency.Items.FindByValue(Convert.ToString(objServiceJoin.PostingFreq_TermID))) : 0;
                            string strRate = Convert.ToString(objServiceJoin.ServiceRate);
                            if (strRate != string.Empty)
                                txtRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            else
                                txtRate.Text = string.Empty;
                            chkIsChargePerPerson.Checked = Convert.ToBoolean(objServiceJoin.IsPerPerson);
                        }
                    }

                    mpeAddEditService.Show();
                }
                else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
                {
                    if (this.RateID != Guid.Empty)
                    {
                        this.RateServiceID = new Guid(Convert.ToString(gvServices.DataKeys[Convert.ToInt32(e.CommandArgument)]["RateServiceID"]));
                    }
                    else
                    {
                        this.RowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    }

                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }
        #endregion
    }
}