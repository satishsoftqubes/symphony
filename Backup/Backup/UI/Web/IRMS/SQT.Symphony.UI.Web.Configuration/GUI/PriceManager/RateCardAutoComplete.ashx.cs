using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Web.SessionState;

namespace SQT.Symphony.UI.Web.Configuration.GUI.PriceManager
{
    /// <summary>
    /// Summary description for RateCardAutoComplete
    /// </summary>
    public class RateCardAutoComplete : IHttpHandler, IReadOnlySessionState
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
                    cmd.CommandText = "select distinct RateCardName from mst_RateCard where PropertyID like '" + PropertyID + "' and CompanyID like '" + CompanyID + "' and IsActive = 1 and RateCardName like '%" + prefixText + "%' order by RateCardName asc";
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["RateCardName"])
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