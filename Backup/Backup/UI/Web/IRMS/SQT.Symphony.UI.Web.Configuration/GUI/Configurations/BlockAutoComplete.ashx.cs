using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Web.SessionState;

namespace SQT.Symphony.UI.Web.Configuration.GUI.Configurations
{
    /// <summary>
    /// Summary description for BlockAutoComplete
    /// </summary>
    public class BlockAutoComplete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection())
            {
                Guid PropertyID = new Guid(Convert.ToString(HttpContext.Current.Session["PropertyID"]));

                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct WingName from mst_Wing where PropertyID like '" + PropertyID + "' and IsActive = 1 and WingName like '%" + prefixText + "%' order by WingName asc";
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["WingName"])
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