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
    public partial class CtrlCommonFolioTransactionDetails : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditTransactionDetails
        {
            get { return this.mpeTransactionDetail; }
        }

        public event EventHandler btnFolioTransactionDetailsCallParent_Click;

        public Literal uclitDisplayTransactionDetailReservationNo
        {
            get { return this.litDisplayTransactionDetailReservationNo; }
        }

        public Literal uclitDisplayTransactionDetailName
        {
            get { return this.litDisplayTransactionDetailName; }
        }

        public Literal uclitDisplayTransactionDetailFolioNo
        {
            get { return this.litDisplayTransactionDetailFolioNo; }
        }

        public Literal uclitDisplayTransactionDetailGroupName
        {
            get { return this.litDisplayTransactionDetailGroupName; }
        }

        public Literal uclitDisplayTransactionDetailUnitNo
        {
            get { return this.litDisplayTransactionDetailUnitNo; }
        }

        public Literal uclitDisplayTransactionNo
        {
            get { return this.litDisplayTransactionNo; }
        }

        public Literal uclitDisplayTransactionAmount
        {
            get { return this.litDisplayTransactionAmount; }
        }

        public Literal uclitDisplayTransactionVoid
        {
            get { return this.litDisplayTransactionVoid; }
        }

        public Literal uclitDisplayTransactionDescription
        {
            get { return this.litDisplayTransactionDescription; }
        }

        public Literal uclitDisplayTransactionAuditDate
        {
            get { return this.litDisplayTransactionAuditDate; }
        }

        public CheckBox ucchkChangeDescription
        {
            get { return this.chkChangeDescription; }
        }

        public TextBox uctxtChangeDescription
        {
            get { return this.txtChangeDescription; }
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

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtChangeDescription.Enabled = rfvChangeDescription.Enabled = false;
            }
        }

        #endregion Page Load
        
        #region Button Event
        
        protected void btnTransactionDetailSave_Click(object sender, EventArgs e)
        {
            try
            {
                mpeTransactionDetail.Show();
                if (this.Page.IsValid)
                {
                    BookKeeping objBookKeeping = new BookKeeping();
                    objBookKeeping = BookKeepingBLL.GetByPrimaryKey(this.BookID);

                    objBookKeeping.Narration = Convert.ToString(txtChangeDescription.Text.Trim());

                    BookKeepingBLL.Update(objBookKeeping);

                    string strDescription = "Change Description of Book No.:- " + Convert.ToString(objBookKeeping.BookNo) + " on " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + "";
                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Change Description", objBookKeeping.ToString(), null, "tra_BookKeeping", strDescription);

                    mpeTransactionDetail.Hide();

                    EventHandler temp = btnFolioTransactionDetailsCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event
    }
}