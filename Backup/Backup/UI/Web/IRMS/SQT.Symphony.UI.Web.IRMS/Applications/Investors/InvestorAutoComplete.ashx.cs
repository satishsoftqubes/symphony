using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Web.SessionState;


namespace SQT.Symphony.UI.Web.IRMS.Applications.Investors
{
    /// <summary>
    /// Summary description for InvestorAutoComplete
    /// </summary>
    public class InvestorAutoComplete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection())
            {
                string UserType = Convert.ToString(HttpContext.Current.Session["UserType"]);
                Guid UserID = new Guid(Convert.ToString(HttpContext.Current.Session["UserID"]));

                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (UserType.ToUpper() == "ADMIN")
                        cmd.CommandText = "select distinct Title + ' ' + FName + ' ' + LName as FullName  from irm_Investor where IsActive = 1 and (Title like '%" + prefixText + "%' OR FName like '%" + prefixText + "%' OR LName like '%" + prefixText + "%') And RefInverstorID is null Order By FullName ASC";
                    else
                        cmd.CommandText = "select distinct Title + ' ' + FName + ' ' + LName as FullName  from irm_Investor where IsActive = 1 and (Title like '%" + prefixText + "%' OR FName like '%" + prefixText + "%' OR LName like '%" + prefixText + "%') And RefInverstorID is null And RelationShipManagerID = '" + Convert.ToString(UserID) + "' Order By FullName ASC";

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