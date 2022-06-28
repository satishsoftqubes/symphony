using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.GUI.Configurations
{
    public partial class rndOfDrag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ItemsListView.DataSource = FindItems();
            //ItemsListView.DataBind();
            if (!IsPostBack)
            {
                BindUnitType();
                BindRoomSellOrderGrid();
            }
        }

        public static IEnumerable<SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Item> FindItems()
        {
            Collection<SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Item> items = new Collection<SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Item>();
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SelectItems";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Item item;
                        while (dataReader.Read())
                        {
                            item = new SQT.Symphony.UI.Web.Configuration.GUI.Configurations.Item();
                            item.ItemID = (int)dataReader["ItemID"];
                            item.ItemName = Convert.ToString(dataReader["ItemName"]);
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        private void BindUnitType()
        {
            ddlSellOrderRoomType.Items.Clear();

            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            SQT.Symphony.BusinessLogic.Configuration.DTO.RoomType Rm = new BusinessLogic.Configuration.DTO.RoomType();            
            
            Rm.PropertyID = clsSession.PropertyID;
            Rm.IsActive = true;
            List<SQT.Symphony.BusinessLogic.Configuration.DTO.RoomType> LstRm = RoomTypeBLL.GetAll(Rm);
            if (LstRm.Count > 0)
            {
                LstRm.Sort((SQT.Symphony.BusinessLogic.Configuration.DTO.RoomType rm1, SQT.Symphony.BusinessLogic.Configuration.DTO.RoomType rm2) => rm1.RoomTypeName.CompareTo(rm2.RoomTypeName));

                ddlSellOrderRoomType.DataSource = LstRm;
                ddlSellOrderRoomType.DataTextField = "RoomTypeName";
                ddlSellOrderRoomType.DataValueField = "RoomTypeID";
                ddlSellOrderRoomType.DataBind();
            }
            else
                ddlSellOrderRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        protected void ddlSellOrderRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ItemsListView.DataSource = FindItems();
                //ItemsListView.DataBind();
                BindRoomSellOrderGrid();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Bind Room Sell Order Grid
        /// </summary>
        private void BindRoomSellOrderGrid()
        {
            try
            {
                if (ddlSellOrderRoomType.SelectedValue != Guid.Empty.ToString())
                {
                    DataSet dsRoomSellOrder = RoomSellOrderBLL.RoomSellOrderSelectAllData(new Guid(ddlSellOrderRoomType.SelectedValue));
                    if (dsRoomSellOrder.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.Visible = false;
                        Session["RoomTypeID"] = Convert.ToString(ddlSellOrderRoomType.SelectedValue);
                        ItemsListView.DataSource = dsRoomSellOrder.Tables[0];
                        ItemsListView.DataBind();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        Session["RoomTypeID"] = null;
                        ItemsListView.DataSource = null;
                        ItemsListView.DataBind();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    Session["RoomTypeID"] = null;
                    ItemsListView.DataSource = null;
                    ItemsListView.DataBind();
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}