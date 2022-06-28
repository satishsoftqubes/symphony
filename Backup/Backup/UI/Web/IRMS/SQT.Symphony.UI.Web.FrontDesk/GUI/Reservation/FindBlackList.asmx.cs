using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    /// <summary>
    /// Summary description for Sortable
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FindBlackList : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public bool SelectBlackListData(string strTitle, string strFirstName, string strLastName, string strMobilNo,string strEmail)
        {
            string argsTitle = null;
            string argsFname = null;
            string argsLname = null;
            string argsemail = null;
            string argsmobileno = null;

            if (Convert.ToString(strTitle) != "" && strTitle != null)
                argsTitle = strTitle;

            if (Convert.ToString(strFirstName) != "" && strFirstName != null)
                argsFname = strFirstName;

            if (Convert.ToString(strLastName) != "" && strLastName != null)
                argsLname = strLastName;
           
            if (Convert.ToString(strMobilNo) != "" && strMobilNo != null)
                argsmobileno = strMobilNo;
           
            if (Convert.ToString(strEmail) != "" && strEmail != null)
                argsemail = strEmail;
           
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    Guid PropertyID = new Guid(Convert.ToString(Session["PropertyID"]));
                    Guid CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                    command.Connection = connection;
                    command.CommandText = "mst_Guest_SelectBlackListGuest";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramTitle = new SqlParameter("@Title", SqlDbType.NVarChar, 25);
                    paramTitle.Value = argsTitle;
                    command.Parameters.Add(paramTitle);

                    SqlParameter paramFName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 250);
                    paramFName.Value = argsFname;
                    command.Parameters.Add(paramFName);

                    SqlParameter paramLName = new SqlParameter("@LastName", SqlDbType.NVarChar, 250);
                    paramLName.Value = argsLname;
                    command.Parameters.Add(paramLName);

                    SqlParameter paramMobilNo = new SqlParameter("@Phone1", SqlDbType.NVarChar, 255);
                    paramMobilNo.Value = argsmobileno;
                    command.Parameters.Add(paramMobilNo);

                    SqlParameter paramEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 255);
                    paramEmail.Value = argsemail;
                    command.Parameters.Add(paramEmail);

                    SqlParameter paramPropertyID = new SqlParameter("@PropertyID", SqlDbType.UniqueIdentifier, 40);
                    paramPropertyID.Value = PropertyID;
                    command.Parameters.Add(paramPropertyID);

                    SqlParameter paramCompanyID = new SqlParameter("@CompanyID", SqlDbType.UniqueIdentifier, 40);
                    paramCompanyID.Value = CompanyID;
                    command.Parameters.Add(paramCompanyID);


                    connection.Open();
                    SqlDataReader objReader;
                    objReader = command.ExecuteReader();

                    if (objReader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    //return (command.ExecuteReader().RecordsAffected > 0);
                }
            }
        }


        [WebMethod(EnableSession = true)]
        public string GetCheckOutDate(string strCheckInDate, string strFrequency, string strAdd)
        {
            string strReturnDate = string.Empty;

            if (Convert.ToString(strCheckInDate) != "" && Convert.ToString(strFrequency) != "" && Convert.ToString(strAdd) != "")
            { 
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                int add = Convert.ToInt32(strAdd);

                string strdateformat = "dd-MM-yyyy";
                if(clsSession.DateFormat != string.Empty)
                    strdateformat = Convert.ToString(clsSession.DateFormat);

                DateTime dtCheckInDate = DateTime.ParseExact(Convert.ToString(strCheckInDate), strdateformat, objCultureInfo);

                if (Convert.ToString(strFrequency) == "DAILY")
                {
                    dtCheckInDate = dtCheckInDate.AddDays(add);
                }
                else if (Convert.ToString(strFrequency) == "WEEKLY")
                {
                    dtCheckInDate = dtCheckInDate.AddDays(7 * add);
                }
                else if (Convert.ToString(strFrequency) == "MONTHLY")
                {
                    dtCheckInDate = dtCheckInDate.AddMonths(add);
                }

                strReturnDate = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
            }
            return strReturnDate;
        }
    }
}
