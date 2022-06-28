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
    /// Summary description for PropertyAutoComplete
    /// </summary>
    public class PropertyAutoComplete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection())
            {
                Guid CompanyID = new Guid(Convert.ToString(HttpContext.Current.Session["CompanyID"]));

                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select Distinct(PropertyName) From mst_Property Where IsActive = 1 and PropertyName like '%" + prefixText + "%' and CompanyID = '" + CompanyID + "'  order by PropertyName asc";
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["PropertyName"])
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