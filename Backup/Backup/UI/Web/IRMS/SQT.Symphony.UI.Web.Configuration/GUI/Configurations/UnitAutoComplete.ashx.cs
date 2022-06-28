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
    /// Summary description for UnitAutoComplete
    /// </summary>
    public class UnitAutoComplete : IHttpHandler, IRequiresSessionState
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
                    cmd.CommandText = "select distinct (SELECT LEFT(mst_Room.RoomNo, ISNULL(NULLIF(CHARINDEX('|', mst_Room.RoomNo) - 1, -1), LEN(mst_Room.RoomNo)))) 'RoomNo' from mst_Room where PropertyID like '" + PropertyID + "' and RoomNo like '%" + prefixText + "%' and ReferenceRoomID is null and IsActive = 1 order by RoomNo asc";
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