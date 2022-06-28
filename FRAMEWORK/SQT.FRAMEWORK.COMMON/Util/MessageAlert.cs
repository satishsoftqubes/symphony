using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SQT.FRAMEWORK.COMMON.Util
{
    public class MessageAlert
    {
        public static void CreateMessageAlert(System.Web.UI.Page aspxPage, string strMessage, string strKey)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "alert('" + strMessage + "');";
            strScript += "</script>";

            if (!aspxPage.ClientScript.IsStartupScriptRegistered("strKey"))
            {
                //aspxPage.ClientScript.RegisterStartupScript(Type.GetType(aspxPage.ToString()),"strKey", strScript);
            }
        }
        public static bool checkFileExists(string strFilePath)
        {
            FileInfo genFileInfo = new FileInfo(strFilePath);

            if (genFileInfo.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void MsgAlert(System.Web.UI.Page aspxPage, string Message)
        {
            aspxPage.Cache["Msg"] = Message;
            string Str = "<Script>parent.frames(3).location.href='../Webforms/Footer.aspx';</Script>";
            if (!aspxPage.IsStartupScriptRegistered("K1"))
            {
                aspxPage.RegisterStartupScript("K1", Str);
            }
        }
        public static void SignOut(System.Web.UI.Page aspxPage, int Count)
        {
            if (Count == 0)
            {
                string Str = "<Script>parent.location.href='../Webforms/LoginPage.aspx';</Script>";
                if (!aspxPage.IsStartupScriptRegistered("Key5"))
                {
                    aspxPage.RegisterStartupScript("Key5", Str);
                }
            }
        }
    }
}
