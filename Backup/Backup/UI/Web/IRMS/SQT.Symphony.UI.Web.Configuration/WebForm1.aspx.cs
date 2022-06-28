using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.Configuration
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkTest_OnClick(object sender, EventArgs e)
        {
            lblTest.Text = "Model popup closed and parent page is refereshed.";
        }
    }
}