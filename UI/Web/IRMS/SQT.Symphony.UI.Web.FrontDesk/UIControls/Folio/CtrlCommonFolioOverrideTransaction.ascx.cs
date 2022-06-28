using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlCommonFolioOverrideTransaction : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditOverrideTransaction
        {
            get { return this.mpeOverrideTransaction; }
        }

        public MultiView mvOpenOverrideTransaction
        {
            get { return this.mvOverrideTransaction; }
        }

        public event EventHandler btnOverrideTransactionCallParent_Click;
        
        public Literal uclitDisplayOverrideTransactionReservationNo
        {
            get { return this.litDisplayOverrideTransactionReservationNo; }
        }

        public Literal uclitDisplayOverrideTransactionFolioNo
        {
            get { return this.litDisplayOverrideTransactionFolioNo; }
        }

        public Literal uclitDisplayOverrideTransactionUnitNo
        {
            get { return this.litDisplayOverrideTransactionUnitNo; }
        }

        public Literal uclitDisplayOverrideTransactionName
        {
            get { return this.litDisplayOverrideTransactionName; }
        }

        public Literal uclitDisplayOverrideTransactionAmount
        {
            get { return this.litDisplayOverrideTransactionAmount; }
        }

        public Literal uclitDisplayViewOverridedTransactionAmount
        {
            get { return this.litDisplayViewOverridedTransactionAmount; }
        }

        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
            }
        }

        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public Guid BookID
        {
            get
            {
                return ViewState["BookID"] != null ? new Guid(Convert.ToString(ViewState["BookID"])) : Guid.Empty;
            }
            set
            {
                ViewState["BookID"] = value;
            }
        }

        public string strMode = null;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvOverrideTransaction.ActiveViewIndex = 0;                
            }
        }

        #endregion

        #region Private Method

        public void BindOverrideTransactionGrid()
        {
            try
            {
                DataSet dsTransaction = TransactionBLL.GetAllTransaction(this.ReservationID, this.FolioID, null, null, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransaction != null && dsTransaction.Tables.Count > 0 && dsTransaction.Tables[0].Rows.Count > 0)
                {
                    DataView dvTransaction = new DataView(dsTransaction.Tables[0]);
                    dvTransaction.RowFilter = "BookID = '" + Convert.ToString(this.BookID) + "' and IsCharge = 1 and IsVoid = 0 and GeneralIDType_Term not in ('DEPOSIT TRANSFER','QUICK POST PAYMENT','REFUND','REFUND DEPOSIT','RESERVATION DEPOSIT','ROOM PAYMENT RECEIVED')";

                    if (dvTransaction.Count > 0)
                    {
                        dvTransaction.Sort = "EntryDate desc";
                        btnOverrideTransactionSave.Visible = true;
                        gvOverrideTransactionList.DataSource = dvTransaction;
                        gvOverrideTransactionList.DataBind();
                    }
                    else
                    {
                        btnOverrideTransactionSave.Visible = false;
                        gvOverrideTransactionList.DataSource = null;
                        gvOverrideTransactionList.DataBind();
                    }
                }
                else
                {
                    btnOverrideTransactionSave.Visible = false;
                    gvOverrideTransactionList.DataSource = null;
                    gvOverrideTransactionList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindViewOverrideTransactionGrid()
        {
            try
            {
                DataSet dsOverrideAmount = BookKeepingBLL.GetAllFolioAllOverridesTransaction(this.ReservationID, this.FolioID);

                if (dsOverrideAmount.Tables.Count > 0 && dsOverrideAmount.Tables[0].Rows.Count > 0)
                {
                    DataView dvOverrideAmount = new DataView(dsOverrideAmount.Tables[0]);

                    decimal dcmlAmt = Convert.ToDecimal("0.000000");

                    if (dvOverrideAmount.Count > 0)
                    {
                        dcmlAmt = (decimal)dsOverrideAmount.Tables[0].Compute("sum(NewAmt)", "");

                        dvOverrideAmount.Sort = "EntryDate desc";
                        gvViewOverrideTransactionList.DataSource = dvOverrideAmount;
                        gvViewOverrideTransactionList.DataBind();
                    }
                    else
                    {
                        gvViewOverrideTransactionList.DataSource = null;
                        gvViewOverrideTransactionList.DataBind();
                    }

                    litDisplayViewOverridedTransactionAmount.Text = dcmlAmt.ToString().Substring(0, dcmlAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)); ;
                }
                else
                {
                    litDisplayViewOverridedTransactionAmount.Text = "0.00";
                    gvViewOverrideTransactionList.DataSource = null;
                    gvViewOverrideTransactionList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Control Event

        protected void btnOverrideTransactionViewOverride_Click(object sender, EventArgs e)
        {
            mpeOverrideTransaction.Show();
            BindViewOverrideTransactionGrid();
            mvOverrideTransaction.ActiveViewIndex = 1;

            litDisplayViewOverridedTransactionReservationNo.Text = Convert.ToString(litDisplayOverrideTransactionReservationNo.Text.Trim());
            litDisplayViewOverridedTransactionFolioNo.Text = Convert.ToString(litDisplayOverrideTransactionFolioNo.Text.Trim());
            litDisplayViewOverridedTransactionName.Text = Convert.ToString(litDisplayOverrideTransactionName.Text.Trim());            
            //EventHandler temp = btnOverrideTransactionCallParent_Click;
            //if (temp != null)
            //{
            //    temp(sender, e);
            //}
        }

        protected void btnViewOverrideTransactioCancel_Click(object sender, EventArgs e)
        {
            mpeOverrideTransaction.Show();
            mvOverrideTransaction.ActiveViewIndex = 0;
        }

        protected void btnOverrideTransactionSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    for (int i = 0; i < gvOverrideTransactionList.Rows.Count; i++)
                    {
                        TextBox txtOverrideTransactionOVDAmount = (TextBox)gvOverrideTransactionList.Rows[i].FindControl("txtOverrideTransactionOVDAmount");
                        TextBox txtGvOverrideTransactionReason = (TextBox)gvOverrideTransactionList.Rows[i].FindControl("txtGvOverrideTransactionReason");

                        Guid bookid = new Guid(gvOverrideTransactionList.DataKeys[i]["BookID"].ToString());

                        BookKeepingBLL.TransactionOverride(bookid, Convert.ToDecimal(txtOverrideTransactionOVDAmount.Text.Trim()), clsSession.DefaultCounterID, Convert.ToString(txtGvOverrideTransactionReason.Text.Trim()), clsSession.UserID);

                        string strDescription = "Override on FolioNo:- " + Convert.ToString(litDisplayOverrideTransactionFolioNo.Text.Trim()) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + " of " + Convert.ToString(txtOverrideTransactionOVDAmount.Text.Trim()) + " Rs.";
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Override", null, null, "tra_BookKeeping", strDescription);
                    }

                    mpeOverrideTransaction.Hide();
                    strMode = "REFRESHFOLIOGIRDFOROVERRIDE";
                    EventHandler temp = btnOverrideTransactionCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion

        #region Grid Event

        protected void gvOverrideTransactionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvOverrideTransactionAmount = (Label)e.Row.FindControl("lblGvOverrideTransactionAmount");
                    decimal dcmlAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DisplayAmount"));
                    lblGvOverrideTransactionAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvViewOverrideTransactionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvViewOverridedTransactionAmount = (Label)e.Row.FindControl("lblGvViewOverridedTransactionAmount");
                    decimal dcmlActualAmt = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "OldAmt"));
                    lblGvViewOverridedTransactionAmount.Text = dcmlActualAmt.ToString().Substring(0, dcmlActualAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvViewOverridedTransactionOVDAmount = (Label)e.Row.FindControl("lblGvViewOverridedTransactionOVDAmount");
                    decimal dcmlOVRAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NewAmt"));
                    lblGvViewOverridedTransactionOVDAmount.Text = dcmlOVRAmount.ToString().Substring(0, dcmlOVRAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Grid Event

        #region Textbox Event

        protected void txtOverrideTransactionOVDAmount_TextChanged(object sender, EventArgs e)
        {
            mpeOverrideTransaction.Show();
            try
            {
                decimal total = Convert.ToDecimal("0.00");

                for (int i = 0; i < gvOverrideTransactionList.Rows.Count; i++)
                {
                    TextBox txtOverrideTransactionOVDAmount = (TextBox)gvOverrideTransactionList.Rows[i].FindControl("txtOverrideTransactionOVDAmount");
                    Label lblGvOverrideTransactionAmount = (Label)gvOverrideTransactionList.Rows[i].FindControl("lblGvOverrideTransactionAmount");

                    if (txtOverrideTransactionOVDAmount.Text.Trim() != string.Empty)
                    {
                        decimal discount = Convert.ToDecimal(txtOverrideTransactionOVDAmount.Text.Trim());
                        total += discount;
                    }
                }

                litDisplayOverrideTransactionAmount.Text = total.ToString().Substring(0, total.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}