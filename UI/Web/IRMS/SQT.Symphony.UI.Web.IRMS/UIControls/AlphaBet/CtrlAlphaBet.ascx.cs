using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.AlphaBet
{
    public partial class CtrlAlphaBet : System.Web.UI.UserControl
    {
        #region Form Load
        /// <summary>
        /// FOrm Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultPage();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Page Insert
        /// </summary>
        private void LoadDefaultPage()
        {

        }
        #endregion Private Method
    }
}