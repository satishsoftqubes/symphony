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
    /// Summary description for UnitAutoComplete
    /// </summary>
    public class UnitAutoComplete : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string prefixText = context.Request.QueryString["q"];
            using (SqlConnection conn = new SqlConnection())
            {
                Guid InvestorID = new Guid(Convert.ToString(HttpContext.Current.Session["InvID"]));
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.CommandText = "select distinct RoomNo from mst_Room INNER JOIN irm_InvestorsUnit ON mst_Room.RoomID = irm_InvestorsUnit.RoomID where mst_Room.IsActive = 1 and RoomNo like '%" + prefixText + "%' and InvesterID = '" + Convert.ToString(InvestorID) + "' order by RoomNo asc";                    
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["RoomNo"])
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