using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonVoidTransaction : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditVoidTransaction
        {
            get { return this.mpeVoidTransaction; }
        }

        public TextBox uctxtVoidReason
        {
            get { return this.txtVoidReason; }
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

        public event EventHandler btnVoidTransactionCallParent_Click;

        #endregion Property and Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Page Load

        #region Button Event

        protected void btnVoidTransactionSave_Click(object sender, EventArgs e)
        {
            mpeVoidTransaction.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    BookKeeping objBookKeeping = new BookKeeping();
                    objBookKeeping = BookKeepingBLL.GetByPrimaryKey(this.BookID);
                    // Commented on 1st May 2013 as per allow void transaction while depostit and payment receipt.

                    //if (objBookKeeping.GeneralIDType_Term == "DEPOSIT TRANSFER" || objBookKeeping.GeneralIDType_Term == "QUICK POST PAYMENT" || objBookKeeping.GeneralIDType_Term == "REFUND" || objBookKeeping.GeneralIDType_Term == "REFUND DEPOSIT" || objBookKeeping.GeneralIDType_Term == "RESERVATION DEPOSIT" || objBookKeeping.GeneralIDType_Term == "ROOM PAYMENT RECEIVED")
                    //{
                    //    mpeVoidTransactionErrMsg.Show();
                    //    return;
                    //}

                    BookKeepingBLL.VoidTransaction(this.BookID, txtVoidReason.Text.Trim(), clsSession.UserID);

                    string strDescription = "Void Transaction on Book No.:- " + Convert.ToString(objBookKeeping.BookNo) + " on " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + "";
                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Void", objBookKeeping.ToString(), null, "tra_BookKeeping", strDescription);

                    EventHandler temp = btnVoidTransactionCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                mpeVoidTransaction.Hide();
            }
        }

        #endregion Button Event
    }
}