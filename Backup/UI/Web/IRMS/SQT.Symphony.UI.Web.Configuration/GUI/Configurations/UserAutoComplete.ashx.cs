
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
    /// Summary description for UserAutoComplete
    /// </summary>
    public class UserAutoComplete : IHttpHandler,IReadOnlySessionState
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
                    Guid CompanyID = clsSession.CompanyID;
                    Guid PropertyID = clsSession.PropertyID;

                    //cmd.CommandText = "select UserName from usr_User where IsActive = 1 And CompanyID like '" + CompanyID + "' And PropertyID like '" + PropertyID + "' And UserName like '" + prefixText + "%'";
                    cmd.CommandText = "select UserName from usr_User where IsActive = 1 And CompanyID like '" + CompanyID + "' And (PropertyID like '" + PropertyID + "' OR PropertyID IS NULL) And UserName like '" + prefixText + "%'";
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["UserName"])
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