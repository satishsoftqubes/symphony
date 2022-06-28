using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    /// <summary>
    /// Summary description for GuestCompanyAutoSuggest
    /// </summary>
    public class GuestCompanyAutoSuggest : IHttpHandler
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
                    cmd.CommandText = "select gst.GuestFullName + ' ~ ' + res.ReservationNo + ' ~ ' + rm.RoomNo as GuestFullName from mst_Guest gst Inner join res_Reservation res on gst.GuestID = res.GuestID Inner join mst_Room rm on rm.RoomID = res.RoomID where res.RestStatus_TermID = 32 and (gst.FName like '" + prefixText + "%' OR LName like '" + prefixText + "%')";

                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["GuestFullName"])
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