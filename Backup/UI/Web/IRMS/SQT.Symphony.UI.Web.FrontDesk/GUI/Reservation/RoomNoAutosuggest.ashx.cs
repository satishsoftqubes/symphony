using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    /// <summary>
    /// Summary description for RoomNoAutosuggest
    /// </summary>
    public class RoomNoAutosuggest : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                    cmd.CommandText = "select DISTINCT SUBSTRING(RoomNo,0,CHARINDEX('|', RoomNo)) as RoomNo FROM mst_Room where PropertyID= '" + clsSession.PropertyID + "' and (SUBSTRING(RoomNo,0,CHARINDEX('|', RoomNo)) like '" + prefixText + "%') Order By SUBSTRING(RoomNo,0,CHARINDEX('|', RoomNo)) asc";

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