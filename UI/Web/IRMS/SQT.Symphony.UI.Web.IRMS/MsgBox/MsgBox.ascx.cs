using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.IRMS.MsgBox
{
    public partial class MsgBox : System.Web.UI.UserControl
    {
        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion Form Load

        #region Private Method

        /// <summary>
        /// Show Message with Property Message Type
        /// </summary>
        /// <param name="MessageType">MessageType as Enum</param>
        /// <param name="Message">Message as String</param>
        /// <param name="Height">Height as Integer</param>
        /// <param name="Width">Width as Integer</param>
        public void Show(string Message)
        {
            lblErrorMessage.Text = Message.ToString();
            msgbx.Show();
            this.Visible = true;
            uPnlMessage.Update();
        }


        #endregion Private Method
    }

}