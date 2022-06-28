using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.Applications.Investors
{
    /// <summary>
    /// Summary description for ChannelPartnerAutoComplete
    /// </summary>
    public class ChannelPartnerAutoComplete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection())
            {                
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct Title + ' ' + FName + ' ' + LName as FullName  from irm_ChannelPartner where IsActive = 1 and (Title like '%" + prefixText + "%' OR FName like '%" + prefixText + "%' OR LName like '%" + prefixText + "%') Order By FullName ASC";
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["FullName"])
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