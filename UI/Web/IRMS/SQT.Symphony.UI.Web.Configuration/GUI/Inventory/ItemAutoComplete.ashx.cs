using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Web.SessionState;

namespace SQT.Symphony.UI.Web.Configuration.GUI.Inventory
{
    /// <summary>
    /// Summary description for ItemAutoComplete
    /// </summary>
    public class ItemAutoComplete : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection())
            {
                Guid PropertyID = new Guid(Convert.ToString(HttpContext.Current.Session["PropertyID"]));
                Guid CompanyID = new Guid(Convert.ToString(HttpContext.Current.Session["CompanyID"]));

                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {                    
                    cmd.CommandText = "select distinct ItemName from mst_Item where PropertyID like '" + PropertyID + "' and CompanyID like '" + CompanyID + "' and IsActive = 1 and ItemName like '%" + prefixText + "%' order by ItemName asc";
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["ItemName"])
                                .Append(Environment.NewLine);
                        }
                    }
                    conn.Close();
                    context.Response.Write(sb.ToString());
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}