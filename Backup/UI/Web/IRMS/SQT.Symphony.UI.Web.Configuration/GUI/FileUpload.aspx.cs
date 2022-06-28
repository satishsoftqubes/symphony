using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SQT.Symphony.UI.Web.Configuration.GUI
{
    public partial class FileUpload : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();

            object fileName = Server.MapPath(@"~\requirements.doc");
            //@"F:\Satish Demo Application\Save Word Document\Data.docx";
            object objFalse = false;
            object objTrue = true;
            object missing = System.Reflection.Missing.Value;
            object emptyData = string.Empty;
            WordApp.Visible = true;
            Microsoft.Office.Interop.Word.Document aDoc = WordApp.Documents.Open(ref fileName, ref objFalse, ref objFalse,
                    ref objFalse, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref objTrue,
                    ref missing, ref missing, ref missing);
            aDoc.Activate();
        }
    }
}