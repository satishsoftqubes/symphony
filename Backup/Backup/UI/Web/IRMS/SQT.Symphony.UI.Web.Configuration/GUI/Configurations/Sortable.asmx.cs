using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Collections.ObjectModel;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.GUI.Configurations
{
    /// <summary>
    /// Summary description for Sortable
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Sortable : System.Web.Services.WebService
    {

        [WebMethod]
        public bool UpdateItemsOrder(string itemOrder)
        {
            Collection<SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Item> items = new Collection<SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Item>();
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UpdateItemsOrder";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramUserName = new SqlParameter("@ItemOrder", SqlDbType.VarChar, 255);
                    paramUserName.Value = itemOrder;
                    command.Parameters.Add(paramUserName);


                    connection.Open();
                    return (command.ExecuteNonQuery() > 0);
                }
            }

        }

        [WebMethod(EnableSession = true)]
        public bool UpdateRoomSellOrder(string itemOrder)
        {            
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    Guid RoomTypeID = new Guid(Convert.ToString(Session["RoomTypeID"]));

                    command.Connection = connection;
                    command.CommandText = "UpdateRoomSellOrder";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramUserName = new SqlParameter("@RoomTypeWiseOrder", SqlDbType.VarChar, 255);
                    paramUserName.Value = itemOrder;
                    command.Parameters.Add(paramUserName);

                    SqlParameter paramRoomTypeID = new SqlParameter("@RoomTypeID", SqlDbType.UniqueIdentifier, 40);
                    paramRoomTypeID.Value = RoomTypeID;
                    command.Parameters.Add(paramRoomTypeID);


                    connection.Open();
                    return (command.ExecuteNonQuery() > 0);
                }
            }

        }
    }
}
