using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardTermsAndConditions : System.Web.UI.UserControl
    {
        #region Proeprty and Variables
        public string ucTxtDetails
        {
            get { return txtDetails.Text.Trim(); }
            set { txtDetails.Text = value; }
        }

        public string ucTxtTermsAndConditions
        {
            get { return edtrDetail.Text.Trim(); }
            set { edtrDetail.Text = value; }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                litRateCardDetail.Text = clsCommon.GetGlobalResourceText("RateCard", "lblRateCardDetail", "Detail");
                litTermsAndConditions.Text = clsCommon.GetGlobalResourceText("RateCard", "lblTermsAndConditions", "Terms & Conditions");
            }
        }
        #endregion
    }
}