using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class BlockDetail : System.Web.UI.UserControl
    {
        #region Property And Variables
        public Guid PropertyID4Unit
        {
            get
            {
                return ViewState["PropertyID4Unit"] != null ? new Guid(Convert.ToString(ViewState["PropertyID4Unit"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID4Unit"] = value;
            }
        }

        public Guid WingID4Unit
        {
            get
            {
                return ViewState["WingID4Unit"] != null ? new Guid(Convert.ToString(ViewState["WingID4Unit"])) : Guid.Empty;
            }
            set
            {
                ViewState["WingID4Unit"] = value;
            }
        }
        #endregion

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PropertyID4Unit"] != null)
                this.PropertyID4Unit = new Guid(Session["PropertyID4Unit"].ToString());
            if (Session["WingID4Unit"] != null)
                this.WingID4Unit = new Guid(Session["WingID4Unit"].ToString());
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            
            else
            {
                //if (RoleRightJoinBLL.GetAccessString("PropertyConfiruation.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                //    Response.Redirect("~/Applications/AccessDenied.aspx");
                if (!IsPostBack)
                {
                    LoadDefaultValue();
                }
            }


        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                if (this.PropertyID4Unit != Guid.Empty && this.WingID4Unit != Guid.Empty)
                {
                    BindBlockInfo();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            DataSet dsUnitInfo = null;
            try
            {
                dsUnitInfo = PropertyBLL.GetPropertyBlockUnitView(this.PropertyID4Unit, this.WingID4Unit);
                DataView dv = new DataView(dsUnitInfo.Tables[0]);
                grdUnitInfo.DataSource = dv;
                grdUnitInfo.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                grdUnitInfo.DataSource = null;
                grdUnitInfo.DataBind();
            }
        }

        private void BindBlockInfo()
        {
            Wing objWing = WingBLL.GetByPrimaryKey(this.WingID4Unit);
            lblBlockName.Text = objWing.WingName;

            Room objRoom = new Room();
            objRoom.WingID = this.WingID4Unit;
            objRoom.IsActive = true;
            List<Room> lstRooms = RoomBLL.GetAll(objRoom);
            
            if (lstRooms != null)
                lblNoOfFloors.Text = Convert.ToString(lstRooms.Count.ToString());

            Property objProperty = PropertyBLL.GetByPrimaryKey(this.PropertyID4Unit);
            lblPropertyName.Text = objProperty.PropertyName;
        }
        #endregion Private Method

        #region Control Events
        protected void lnkToRedirect_OnClick(object sender, EventArgs e)
        {
            if (this.PropertyID4Unit != Guid.Empty && this.WingID4Unit != Guid.Empty )
            {
                Room objRoom = new Room();
                objRoom.PropertyID = this.PropertyID4Unit;
                objRoom.WingID = this.WingID4Unit;
                objRoom.RoomNo = hfUnitValue.Value;
                objRoom.IsActive = true;

                List<Room> lstRoom = RoomBLL.GetAll(objRoom);
                if (lstRoom != null && lstRoom.Count > 0)
                {
                    Session["RoomID4Unit"] = Convert.ToString(lstRoom[0].RoomID);
                    Response.Redirect("~/Applications/SetUp/RoomSetup.aspx");
                }                
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //if (Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
            //{
            //    Response.Redirect("~/Applications/Index.aspx");
            //}
            //if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
            //{
            //    Response.Redirect("~/Applications/investordashboard.aspx");
            //}
            //if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
            //{
            //    Response.Redirect("~/Applications/SalesDashBoard.aspx");
            //} 
            Response.Redirect("~/Applications/SetUp/PropertyUnits.aspx");
        }
        #endregion

        #region Grid Event
        protected void grdUnitInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strBlockValue = "";
                    if (e.Row.Cells.Count > 0)
                        strBlockValue = Convert.ToString(e.Row.Cells[0].Text);

                    if (e.Row.Cells.Count > 0)
                    {
                        e.Row.Cells[0].Width = 60;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#f3f3f5");
                    }

                    for (int i = 1; i < e.Row.Cells.Count; i++)
                    {
                        if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                            e.Row.Cells[i].Text = Convert.ToString(e.Row.Cells[i].Text);
                        else
                            e.Row.Cells[i].Text = "<a style='cursor:pointer;' onclick=\"fnRowCommand('" + Convert.ToString(e.Row.Cells[i].Text) + "');\">" + Convert.ToString(e.Row.Cells[i].Text) + "</a>";

                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdUnitInfo_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUnitInfo.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event
    }
}