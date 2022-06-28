using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Web.SessionState;

namespace SQT.Symphony.UI.Web.IRMS.Applications.SetUp
{
    /// <summary>
    /// Summary description for EmployeeAutoComplete
    /// </summary>
    public class EmployeeAutoComplete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection())
            {
                Guid CompanyID = new Guid(Convert.ToString(HttpContext.Current.Session["CompanyID"]));
                Guid PropertyID = new Guid(Convert.ToString(HttpContext.Current.Session["PropertyID"]));

                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select distinct FullName from hrm_Employee where IsActive = 1 and PropertyID = '" + PropertyID + "' and CompanyID = '" + CompanyID + "' and FullName like '%" + prefixText + "%' order by FullName asc";
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