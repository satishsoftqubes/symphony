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
    public partial class CtrlDiscountOnTransaction : System.Web.UI.UserControl
    {
        #region Property and Variable

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

        public ModalPopupExtender ucMpeAddEditTransactionDiscount
        {
            get { return this.mpeTransactionDiscount; }
        }

        public MultiView mvOpenDiscountOnTransaction
        {
            get { return this.mvTransactionDiscount; }
        }

        public event EventHandler btnDiscountOnTransactionCallParent_Click;

        public Literal uclitDisplayTransactionDiscountReservationNo
        {
            get { return this.litDisplayTransactionDiscountReservationNo; }
        }

        public Literal uclitDisplayTransactionDiscountName
        {
            get { return this.litDisplayTransactionDiscountName; }
        }

        public Literal uclitDisplayTransactionDiscountFolioNo
        {
            get { return this.litDisplayTransactionDiscountFolioNo; }
        }

        public Literal uclitDisplayTransactionDiscountGroupName
        {
            get { return this.litDisplayTransactionDiscountGroupName; }
        }

        public Literal uclitDisplayTransactionDiscountUnitNo
        {
            get { return this.litDisplayTransactionDiscountUnitNo; }
        }

        public Literal uclitDisplayDiscountAmount
        {
            get { return this.litDisplayDiscountAmount; }
        }

        public string strMode = null;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvTransactionDiscount.ActiveViewIndex = 0;
                BindDiscountTransactionGrid();
            }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Bind Grid
        /// </summary>
        public void BindDiscountTransactionGrid()
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
                        btnTransactionDiscountSave.Visible = true;
                        gvTransactionDiscountList.DataSource = dvTransaction;
                        gvTransactionDiscountList.DataBind();
                    }
                    else
                    {
                        btnTransactionDiscountSave.Visible = false;
                        gvTransactionDiscountList.DataSource = null;
                        gvTransactionDiscountList.DataBind();
                    }

                }
                else
                {
                    btnTransactionDiscountSave.Visible = false;
                    gvTransactionDiscountList.DataSource = null;
                    gvTransactionDiscountList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindViewDiscountGrid()
        {
            try
            {
                DataSet dsDiscount = BookKeepingBLL.GetAllFolioDiscount(this.ReservationID, this.FolioID);

                if (dsDiscount.Tables.Count > 0 && dsDiscount.Tables[0].Rows.Count > 0)
                {
                    DataView dvDisc = new DataView(dsDiscount.Tables[0]);
                    //dvDisc.RowFilter = "BookID = '" + Convert.ToString(this.BookID) + "'";

                    decimal dcmlDisc = Convert.ToDecimal("0.000000");

                    if (dvDisc.Count > 0)
                    {
                        dcmlDisc = (decimal)dsDiscount.Tables[0].Compute("sum(NewAmt)", "");

                        gvViewDiscountList.DataSource = dvDisc;
                        gvViewDiscountList.DataBind();
                    }
                    else
                    {
                        gvViewDiscountList.DataSource = null;
                        gvViewDiscountList.DataBind();
                    }

                    litDisplayViewDiscountAmount.Text = dcmlDisc.ToString().Substring(0, dcmlDisc.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)); ;
                }
                else
                {
                    litDisplayViewDiscountAmount.Text = "0.00";
                    gvViewDiscountList.DataSource = null;
                    gvViewDiscountList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Textbox Event

        protected void txtTransactionDiscount_TextChanged(object sender, EventArgs e)
        {
            mpeTransactionDiscount.Show();
            try
            {
                decimal total = Convert.ToDecimal("0.00");

                for (int i = 0; i < gvTransactionDiscountList.Rows.Count; i++)
                {
                    TextBox txtTransactionDiscount = (TextBox)gvTransactionDiscountList.Rows[i].FindControl("txtTransactionDiscount");
                    //DropDownList ddlDiscountType = (DropDownList)gvTransactionDiscountList.Rows[i].FindControl("ddlDiscountType");
                    Label lblGvTransactionDiscountAmount = (Label)gvTransactionDiscountList.Rows[i].FindControl("lblGvTransactionDiscountAmount");

                    //if (ddlDiscountType.SelectedIndex != 0)
                    //{
                    if (txtTransactionDiscount.Text.Trim() != string.Empty)
                    {
                        //if (ddlDiscountType.SelectedIndex == 1)
                        //{
                        decimal discount = (Convert.ToDecimal(lblGvTransactionDiscountAmount.Text.Trim()) * Convert.ToDecimal(txtTransactionDiscount.Text.Trim())) / 100;
                        total += discount;
                        //}
                        //else if (ddlDiscountType.SelectedIndex == 2)
                        //{
                        //    total += total + Convert.ToDecimal(txtTransactionDiscount.Text.Trim());
                        //}
                    }
                    // }
                }

                litDisplayDiscountAmount.Text = total.ToString().Substring(0, total.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Control Event

        protected void btnTransactionDiscountViewDiscount_Click(object sender, EventArgs e)
        {
            mpeTransactionDiscount.Show();
            try
            {
                litDisplayViewDiscountReservationNo.Text = Convert.ToString(litDisplayTransactionDiscountReservationNo.Text.Trim());
                litDisplayViewDiscountFolioNo.Text = Convert.ToString(litDisplayTransactionDiscountFolioNo.Text.Trim());
                litDisplayViewDiscountName.Text = Convert.ToString(litDisplayTransactionDiscountName.Text.Trim());

                BindViewDiscountGrid();

                EventHandler temp = btnDiscountOnTransactionCallParent_Click;
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

        protected void btnViewDiscoutnCancel_Click(object sender, EventArgs e)
        {
            mpeTransactionDiscount.Show();
            mvTransactionDiscount.ActiveViewIndex = 0;
        }

        protected void btnTransactionDiscountSave_Click(object sender, EventArgs e)
        {
            mpeTransactionDiscount.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    for (int i = 0; i < gvTransactionDiscountList.Rows.Count; i++)
                    {
                        TextBox txtTransactionDiscount = (TextBox)gvTransactionDiscountList.Rows[i].FindControl("txtTransactionDiscount");
                        TextBox txtGvReason = (TextBox)gvTransactionDiscountList.Rows[i].FindControl("txtGvReason");

                        Guid bookid = new Guid(gvTransactionDiscountList.DataKeys[i]["BookID"].ToString());

                        BookKeepingBLL.TransactionDiscount(bookid, Convert.ToDecimal(txtTransactionDiscount.Text.Trim()), clsSession.UserID, clsSession.DefaultCounterID, txtGvReason.Text.Trim());

                        string strDescription = "Discount on FolioNo:- " + Convert.ToString(litDisplayTransactionDiscountFolioNo.Text.Trim()) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + " of " + Convert.ToString(txtTransactionDiscount.Text.Trim()) + " Rs.";
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Discount", null, null, "tra_BookKeeping", strDescription);
                    }

                    mpeTransactionDiscount.Hide();
                    strMode = "REFRESHFOLIOGIRDFORDISCONTRANS";
                    EventHandler temp = btnDiscountOnTransactionCallParent_Click;
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

        protected void gvTransactionDiscountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvTransactionDiscountAmount = (Label)e.Row.FindControl("lblGvTransactionDiscountAmount");
                    decimal dcmlDisplayAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DisplayAmount"));
                    lblGvTransactionDiscountAmount.Text = dcmlDisplayAmount.ToString().Substring(0, dcmlDisplayAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvTransactionDiscountTotalDiscount = (Label)e.Row.FindControl("lblGvTransactionDiscountTotalDiscount");
                    decimal dcmlTotalDiscount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DISCOUNT_AMT"));
                    lblGvTransactionDiscountTotalDiscount.Text = dcmlTotalDiscount.ToString().Substring(0, dcmlTotalDiscount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ////DropDownList ddlDiscountType = (DropDownList)e.Row.FindControl("ddlDiscountType");
                    ////RangeValidator rvTransactionDiscount = (RangeValidator)e.Row.FindControl("rvTransactionDiscount");

                    ////if (ddlDiscountType.SelectedIndex == 0)
                    ////{
                    ////    rvTransactionDiscount.Enabled = true;
                    ////    rvTransactionDiscount.MaximumValue = "100";
                    ////}
                    ////else
                    ////{
                    ////    rvTransactionDiscount.Enabled = false;
                    ////    rvTransactionDiscount.MaximumValue = "999999999999999999";// 18 chars
                    ////}
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvViewDiscountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvViewDiscountAmount = (Label)e.Row.FindControl("lblGvViewDiscountAmount");
                    decimal dcmlAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "OldAmt"));
                    lblGvViewDiscountAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvViewDiscount = (Label)e.Row.FindControl("lblGvViewDiscount");
                    decimal dcmlDiscount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NewAmt"));
                    lblGvViewDiscount.Text = dcmlDiscount.ToString().Substring(0, dcmlDiscount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Grid Event

        #region Dropdown Event

        protected void ddlDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mpeTransactionDiscount.Show();

                GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
                DropDownList ddlDiscountType = (DropDownList)row.FindControl("ddlDiscountType");
                RangeValidator rvTransactionDiscount = (RangeValidator)row.FindControl("rvTransactionDiscount");

                if (ddlDiscountType.SelectedIndex == 0)
                {
                    rvTransactionDiscount.Enabled = true;
                    rvTransactionDiscount.MaximumValue = "100";
                }
                else
                {
                    rvTransactionDiscount.Enabled = false;
                    rvTransactionDiscount.MaximumValue = "999999999999999999";// 18 chars
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Dropdown Event
    }
}