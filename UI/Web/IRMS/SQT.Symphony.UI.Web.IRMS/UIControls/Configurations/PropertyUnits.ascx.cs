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
    public partial class PropertyUnits : System.Web.UI.UserControl
    {
        #region Property and Variables
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
        decimal grandTotalSoldUnits = 0;
        decimal grandTotalUnits = 0;
        int totalBlockGridsRowCount = 0;
        #endregion

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PropertyID4UnitInfo"] != null)
                this.PropertyID4Unit = new Guid(Convert.ToString(Session["PropertyID4UnitInfo"]));
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //if (RoleRightJoinBLL.GetAccessString("PropertyUnits.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                //    Response.Redirect("~/Applications/AccessDenied.aspx");

                //LoadAccess();

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
                if (this.PropertyID4Unit != Guid.Empty)
                {
                    BindPropertyInfo();
                    BindAmenities();
                    BindGrid();
                    BindBlockInfoGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindAmenities()
        {
            string strAmenitiesQuery = "select * from mst_Amenities where PropertyID = '" + this.PropertyID4Unit + "' and IsActive = 1 and AmenitiesTypeTermID in ('04D8D376-687B-45A9-9682-6E3CFE35318C','9435ED89-A452-4DE4-9D8C-1CF1E9BD7B46') order by AmenitiesName asc";
            DataSet dsAmenities = AmenitiesBLL.GetAmenities(strAmenitiesQuery);

            if (dsAmenities.Tables[0].Rows.Count > 0)
            {
                lblAmenitiesMsg.Visible = false;
                dtlstAmenities.DataSource = dsAmenities.Tables[0];
                dtlstAmenities.DataBind();
            }
            else
            {
                lblAmenitiesMsg.Visible = true;
                dtlstAmenities.DataSource = null;
                dtlstAmenities.DataBind();
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
                dsUnitInfo = PropertyBLL.GetPropertyUnitView(this.PropertyID4Unit);

                if (dsUnitInfo != null && dsUnitInfo.Tables[0].Rows.Count > 0)
                {
                    DataTable dtBlockInfo = dsUnitInfo.Tables[0];

                    DataRow drTotal = dtBlockInfo.NewRow();

                    for (int i = 0; i < dtBlockInfo.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            drTotal[i] = "Total :";
                        }
                        else
                        {
                            int colCount = 0;

                            for (int j = 0; j < dtBlockInfo.Rows.Count; j++)
                            {
                                colCount += Convert.ToInt32(dtBlockInfo.Rows[j][i]);
                            }

                            drTotal[i] = colCount.ToString();
                        }
                    }

                    dtBlockInfo.Rows.Add(drTotal);

                    // totalBlockGridsRowCount will use to identify last row of Grid. 
                    totalBlockGridsRowCount = dtBlockInfo.Rows.Count;

                    grdPropertyList.DataSource = dtBlockInfo;
                    grdPropertyList.DataBind();
                }
                else
                {
                    DataView dv = null;
                    grdPropertyList.DataSource = dv;
                    grdPropertyList.DataBind();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                grdPropertyList.DataSource = null;
                grdPropertyList.DataBind();
            }
        }

        private void BindBlockInfoGrid()
        {
            DataSet dsRoomTypes = PropertyBLL.GetPropertyRoomTypeView(this.PropertyID4Unit);
            if (dsRoomTypes != null && dsRoomTypes.Tables.Count > 0)
            {
                DataTable dtTypes = dsRoomTypes.Tables[0];
                if (dtTypes.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTypes.Rows.Count; i++)
                    {
                        grandTotalUnits += Convert.ToDecimal(dtTypes.Rows[i]["Units"]);
                        grandTotalSoldUnits += Convert.ToDecimal(dtTypes.Rows[i]["SoldUnits"]);
                    }
                }
            }

            gvBlockInfo.DataSource = dsRoomTypes;
            gvBlockInfo.DataBind();
        }

        private void BindPropertyInfo()
        {
            Property objProperty = PropertyBLL.GetByPrimaryKey(this.PropertyID4Unit);
            lblPropertyName.Text = objProperty.PropertyName;
            lblPropertyCode.Text = objProperty.PropertyCode;

            if (objProperty.AddressID != null)
            {
                Address objAddress = AddressBLL.GetByPrimaryKey((Guid)objProperty.AddressID);
                if (objAddress != null)
                {
                    lblAddress.Text = Convert.ToString(objAddress.Add1);
                    lblLocation.Text = Convert.ToString(objAddress.City);
                }
            }

            if (objProperty.PropertyTypeID != null)
            {
                ProjectTerm objTerm = ProjectTermBLL.GetByPrimaryKey((Guid)(objProperty.PropertyTypeID));
                if (objTerm != null)
                    lblPropertyType.Text = Convert.ToString(objTerm.Term);
            }


            lblSBACommercial.Text = Convert.ToString(Convert.ToDouble(objProperty.SBAreaCommercial));
            lblSBAResidential.Text = Convert.ToString(Convert.ToDouble(objProperty.SBArea));

            Double dblSBAComm = objProperty.SBAreaCommercial != null ? Convert.ToDouble(objProperty.SBAreaCommercial) : 0;
            Double dblSBAArea = objProperty.SBArea != null ? Convert.ToDouble(objProperty.SBArea) : 0;
            lblSBATotal.Text = (dblSBAArea + dblSBAComm) == 0 ? "-" : Convert.ToString(Convert.ToDecimal(dblSBAArea + dblSBAComm));
        }
        #endregion Private Method

        #region Control Events
        protected void lnkToRedirect_OnClick(object sender, EventArgs e)
        {
            Guid wingID = Guid.Empty;
            Guid roomTypeID = Guid.Empty;

            if (this.PropertyID4Unit != Guid.Empty)
            {
                Wing objWing = new Wing();
                objWing.WingName = hfBlockValue.Value;
                objWing.PropertyID = this.PropertyID4Unit;
                objWing.IsActive = true;
                List<Wing> lstWing = WingBLL.GetAll(objWing);
                if (lstWing != null && lstWing.Count > 0)
                {
                    string wingCode = lstWing[0].WingCode;
                    wingID = lstWing[0].WingID;
                }
                else
                {
                    // No wing found.
                }

                if (hfIsBlock.Value == "1")
                {
                    Session["PropertyID4Unit"] = this.PropertyID4Unit.ToString();
                    Session["WingID4Unit"] = wingID.ToString();
                    Response.Redirect("~/Applications/SetUp/BlockDetail.aspx");
                }

                RoomType objRoomType = new RoomType();
                objRoomType.IsActive = true;
                objRoomType.PropertyID = this.PropertyID4Unit;
                objRoomType.RoomTypeName = hfUnitValue.Value;

                List<RoomType> lstRoomType = RoomTypeBLL.GetAll(objRoomType);
                if (lstRoomType != null && lstRoomType.Count > 0)
                {
                    string wingCode = lstRoomType[0].RoomTypeCode;
                    roomTypeID = lstRoomType[0].RoomTypeID;
                }
                else
                {
                    // No Unit found.
                }

                if (this.PropertyID4Unit != Guid.Empty && wingID != Guid.Empty && roomTypeID != Guid.Empty)
                {
                    Session["PropertyID4Unit"] = this.PropertyID4Unit.ToString();
                    Session["WingID4Unit"] = wingID.ToString();
                    Session["RoomTypeID4Unit"] = roomTypeID.ToString();
                    Response.Redirect("~/Applications/SetUp/RoomSetup.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
            {
                Response.Redirect("~/Applications/Index.aspx");
            }
            if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
            {
                Response.Redirect("~/Applications/investordashboard.aspx");
            }
            if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
            {
                Response.Redirect("~/Applications/SalesDashBoard.aspx");
            }
            //Response.Redirect("~/Applications/SalesDashBoard.aspx");
        }
        #endregion

        #region Grid Event
        protected void grdPropertyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strBlockValue = "";
                    if (e.Row.Cells.Count > 0)
                        strBlockValue = Convert.ToString(e.Row.Cells[0].Text);
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        string headerText = Convert.ToString(grdPropertyList.HeaderRow.Cells[i].Text);
                        if ((grdPropertyList.HeaderRow.Cells.Count - 1) != i)
                        {
                            if (i == 0)
                            {
                                if (e.Row.DataItemIndex + 1 == totalBlockGridsRowCount)
                                {
                                    e.Row.Cells[i].Text = Convert.ToString(e.Row.Cells[i].Text);
                                }
                                else
                                {
                                    e.Row.Cells[i].Text = "<a style='cursor:pointer;' onclick=\"fnRowCommand('" + headerText.ToString().ToUpper() + "','" + strBlockValue + "','" + headerText + "');\"><b>" + Convert.ToString(e.Row.Cells[i].Text) + "</b></a>";
                                    e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#f3f3f5");
                                }
                            }
                            else
                            {
                                if (e.Row.DataItemIndex + 1 == totalBlockGridsRowCount)
                                {
                                    e.Row.Cells[i].Text = Convert.ToString(e.Row.Cells[i].Text);
                                }
                                else
                                {
                                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                                        e.Row.Cells[i].Text = Convert.ToString(e.Row.Cells[i].Text);
                                    else
                                        e.Row.Cells[i].Text = "<a style='cursor:pointer;' onclick=\"fnRowCommand('" + headerText.ToString().ToUpper() + "','" + strBlockValue + "','" + headerText + "');\">" + Convert.ToString(e.Row.Cells[i].Text) + "</a>";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPropertyList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPropertyList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvBlockInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        //MOdel Popup Open
                        msgbx.Show();
                        DataSet dsUnitTypeAmenities = RoomTypeAmenitiesBLL.GetAmenitiesByRoomTypeID(new Guid(Convert.ToString(e.CommandArgument)), null, null);
                        if (dsUnitTypeAmenities.Tables[0].Rows.Count > 0)
                        {
                            lblMsgUnitTypeAmenities.Visible = false;
                            dtlstUnitTypeAmenities.DataSource = dsUnitTypeAmenities.Tables[0];
                            dtlstUnitTypeAmenities.DataBind();
                        }
                        else
                        {
                            lblMsgUnitTypeAmenities.Visible = true;
                            dtlstUnitTypeAmenities.DataSource = null;
                            dtlstUnitTypeAmenities.DataBind();
                        }
                    }
                    else
                    {
                        Session["RoomTypeID4Unit"] = e.CommandArgument.ToString();
                        Response.Redirect("~/Applications/SetUp/RoomTypeSetup.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvBlockInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        //e.Row.Cells[4].Visible = e.Row.Cells[0].Enabled = false;
                        //e.Row.Cells[5].Visible = e.Row.Cells[0].Enabled = false;
                        e.Row.Cells[4].Visible = false;
                        e.Row.Cells[5].Visible = false;
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strSBArea = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SBArea"));
                    string strCarpetArea = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CarpetArea"));

                    if (strSBArea.IndexOf(".") > 0)
                        strSBArea = strSBArea.Substring(0, strSBArea.LastIndexOf("."));

                    if (strCarpetArea.IndexOf(".") > 0)
                        strCarpetArea = strCarpetArea.Substring(0, strCarpetArea.LastIndexOf("."));

                    ((Label)e.Row.FindControl("lblSBArea")).Text = strSBArea;
                    ((Label)e.Row.FindControl("lblCorpArea")).Text = strCarpetArea;
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        //e.Row.Cells[4].Visible = e.Row.Cells[0].Enabled = false;
                        //e.Row.Cells[5].Visible = e.Row.Cells[0].Enabled = false;
                        e.Row.Cells[4].Visible = false;
                        e.Row.Cells[5].Visible = false;
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if ((Label)e.Row.FindControl("lblTotalUnits") != null)
                        ((Label)e.Row.FindControl("lblTotalUnits")).Text = grandTotalUnits.ToString();

                    if ((Label)e.Row.FindControl("lblTotalSoldUnits") != null)
                        ((Label)e.Row.FindControl("lblTotalSoldUnits")).Text = grandTotalSoldUnits.ToString();

                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        //e.Row.Cells[4].Visible = e.Row.Cells[0].Enabled = false;
                        //e.Row.Cells[5].Visible = e.Row.Cells[0].Enabled = false;
                        e.Row.Cells[4].Visible = false;
                        e.Row.Cells[5].Visible = false;
                    }
                }
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event

    }
}