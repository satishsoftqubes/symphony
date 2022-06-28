﻿using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.Applications.SetUp
{
    /// <summary>
    /// Summary description for UnitTypeAutoComplete
    /// </summary>
    public class UnitTypeAutoComplete : IHttpHandler
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
                    cmd.CommandText = "select distinct RoomTypeName from mst_RoomType where IsActive = 1 and RoomTypeName like '%" + prefixText + "%' order by RoomTypeName asc";
                    cmd.Connection = conn;
                    StringBuilder sb = new StringBuilder();
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["RoomTypeName"])
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