using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Web.SessionState;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SQT.Symphony.UI.Web.IRMS.Applications.Investors
{
    /// <summary>
    /// Summary description for InvestorCascadingAutocomplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [System.Web.Script.Services.ScriptService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InvestorCascadingAutocomplete : System.Web.Services.WebService
    {

        [System.Web.Services.WebMethod]
        public string[] GetChannelPartnerFirm(string prefixText, int count)
        {
            StringBuilder sb = new StringBuilder();
            
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["SQLConStr"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText = "select distinct CompanyName from irm_ChannelPartner where IsActive = 1 and ISNULL(CompanyName, '') <> '' and CompanyName like '%" + prefixText + "%' order by CompanyName asc";
                    cmd.CommandText = "select distinct CompanyName from irm_ChannelPartner where IsActive = 1 and ISNULL(CompanyName, '') <> '' and CompanyName like '" + prefixText + "%' order by CompanyName asc";
                    cmd.Connection = conn;
                    
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["CompanyName"])
                            .Append("~");
                        }
                    }
                    
                    conn.Close();                    
                }
            }

            return sb.ToString().Trim('~').Split('~') ;
            
        }

        [System.Web.Services.WebMethod]
        public string[] GetExecutiveName(string prefixText, int count, string contextKey)
        {

            StringBuilder sb = new StringBuilder();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                       .ConnectionStrings["SQLConStr"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    //if (contextKey == string.Empty)
                    //{
                    //    //cmd.CommandText = "select distinct DisplayName from irm_ChannelPartner where IsActive = 1 and DisplayName like '%" + prefixText + "%' union select distinct DisplayName from irm_SalesTeam where IsActive = 1 and DisplayName like '%" + prefixText + "%' order by DisplayName asc";
                    //    cmd.CommandText = "select distinct DisplayName = CASE WHEN ISNULL(CompanyName, '') <> '' THEN  DisplayName + ' - ' + CompanyName else DisplayName END from irm_ChannelPartner where IsActive = 1 and DisplayName like '" + prefixText + "%' union select distinct DisplayName + ' - Sales' as DisplayName from irm_SalesTeam where IsActive = 1 and DisplayName like '" + prefixText + "%' order by DisplayName asc";
                    //}
                    //else
                    //{
                        //cmd.CommandText = "select distinct DisplayName = CASE WHEN ISNULL(CompanyName, '') <> '' THEN  DisplayName + ' - ' + CompanyName else DisplayName END from irm_ChannelPartner where IsActive = 1 and CompanyName like '%" + contextKey + "%' and DisplayName like '%" + prefixText + "%' order by DisplayName asc";
                        cmd.CommandText = "select distinct DisplayName = CASE WHEN ISNULL(CompanyName, '') <> '' THEN  DisplayName + ' - ' + CompanyName else DisplayName END from irm_ChannelPartner where IsActive = 1 and DisplayName like '%" + prefixText + "%' order by DisplayName asc";
                    //}
                    
                    cmd.Connection = conn;

                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            sb.Append(sdr["DisplayName"])
                            .Append("~");
                        }
                    }

                    conn.Close();
                }
            }

            return sb.ToString().Trim('~').Split('~');
        }
    }
}
