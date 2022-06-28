using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet
{
    public partial class CtrlControlNotes : System.Web.UI.UserControl
    {
        public event EventHandler btnControlNotesCallParent_Click;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandler temp = btnControlNotesCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }
    }
}