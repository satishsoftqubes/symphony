using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Folio
{
    /// <summary>
    /// Summary description for Sortable
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TransferFolioTransaction : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public bool TransferTransaction(string Dest_ResID, string DestnationFolioID, string strID)
        {
            try
            {
                string[] strData = strID.Split(',');
                if (strData.Length > 0)
                {
                    for (int i = 0; i < strData.Length; i++)
                    {
                        Guid UserID = new Guid(Convert.ToString(Session["UserID"]));
                        Guid Source_ResID = new Guid(Convert.ToString(Session["FolioListReservationID"]));
                        Guid SourceFolioID = new Guid(Convert.ToString(Session["TransactionFolioID"]));

                        Guid bookid = new Guid(strData[i]);
                        FolioBLL.FolioTransferTransactionData(Source_ResID, SourceFolioID, new Guid(Dest_ResID), new Guid(DestnationFolioID), bookid, false, UserID);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                return false;
            }
        }
    }
}
