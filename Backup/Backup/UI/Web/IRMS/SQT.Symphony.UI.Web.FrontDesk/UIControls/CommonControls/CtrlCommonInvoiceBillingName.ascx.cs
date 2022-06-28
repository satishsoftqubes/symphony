using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrInvoiceBillingName : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditInvoiceBillingName
        {
            get { return this.mpeInvoiceBillingName; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}