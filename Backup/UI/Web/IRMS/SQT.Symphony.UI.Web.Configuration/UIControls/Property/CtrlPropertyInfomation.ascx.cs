using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Property
{
    public partial class CtrlPropertyInfomation : System.Web.UI.UserControl
    {
        #region Property and Variables
        decimal grandTotalSoldUnits = 0;
        decimal grandTotalUnits = 0;
        #endregion

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                LoadDefaultValue();
                BindBreadCrumb();
                if (!(clsSession.UserType == "SUPERADMIN" || clsSession.UserType == "ADMINISTRATOR" || clsSession.UserType == "ADMIN"))
                    gvBlockInfo.Columns[gvBlockInfo.Columns.Count - 1].Visible = false;
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
                if (clsSession.PropertyID != Guid.Empty)
                {
                    BindPageLables();
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

        private void BindPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblMainPropertyInformatino", "PROPERTY INFORMATION");
            litProperty.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblProperty","Property");
            litCode.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblCode", "Code");
            litAddress.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblAddress","Address");
            litLocation.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblLocation", "Location");
            litPropertyType.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblPropertyType", "Property Type");
            litSbaSftResidential.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblSbaSftResidential", "SBA (Sft) Residential");
            litSbaSftCommercial.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblSbaSftCommercial", "SBA (Sft) Commercial");
            litSbaSftTotal.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblSbaSftTotal", "SBA (Sft) Total");
            litMainBlockInformation.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblMainBlockInformation", "Block Information");
            litMainUnitTypeInformation.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblMainUnitTypeInformation", "Unit Type Information");
            litAmenities.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblAmenities", "Amenities");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnBack","Back");
            lblMsgUnitTypeAmenities.Text = lblAmenitiesMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            btnClose.Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblClose", "Close");
        }

        private void BindAmenities()
        {
            string strAmenitiesQuery = "select AmenitiesID,AmenitiesName from mst_Amenities where AmenitiesTypeTermID in (select TermID from mst_ProjectTerm where Term in ('Both','Unit') and IsActive = 1 and PropertyID = '" + clsSession.PropertyID + "' and CompanyID = '" + clsSession.CompanyID + "') And PropertyID='" + clsSession.PropertyID + "' And IsActive = 1 order by AmenitiesName Asc";
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

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblGeneralSettings", "General Settings");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyList", "Property List");
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyInformation", "Property Information");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            DataSet dsUnitInfo = null;
            try
            {
                dsUnitInfo = PropertyBLL.GetPropertyUnitView(clsSession.PropertyID);
                DataView dv = new DataView(dsUnitInfo.Tables[0]);
                //dv.Sort = "PropertyName Asc";
                grdPropertyList.DataSource = dv;
                grdPropertyList.DataBind();
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
            DataSet dsRoomTypes = PropertyBLL.GetPropertyRoomTypeView(clsSession.PropertyID);
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
            SQT.Symphony.BusinessLogic.Configuration.DTO.Property objProperty = PropertyBLL.GetByPrimaryKey(clsSession.PropertyID);
            lblPropertyName.Text = objProperty.PropertyName;
            lblPropertyCode.Text = objProperty.PropertyCode;

            if (objProperty.AddressID != null)
            {
                Address objAddress = AddressBLL.GetByPrimaryKey((Guid)objProperty.AddressID);
                if (objAddress != null)
                {
                    lblAddress.Text = Convert.ToString(objAddress.Add1);

                    if (Convert.ToString(objAddress.City) != string.Empty)
                    {
                        City objCity = CityBLL.GetByPrimaryKey((Guid)(objAddress.CityID));
                        lblLocation.Text = Convert.ToString(objCity.CityName);
                    }
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

            if (clsSession.PropertyID != Guid.Empty)
            {
                Wing objWing = new Wing();
                objWing.WingName = hfBlockValue.Value;
                objWing.PropertyID = clsSession.PropertyID;
                objWing.IsActive = true;
                List<Wing> lstWing = WingBLL.GetAll(objWing);
                if (lstWing != null && lstWing.Count > 0)
                {
                    string wingCode = lstWing[0].WingCode;
                    wingID = lstWing[0].WingID;
                }

                if (hfIsBlock.Value == "1")
                {
                    Session["WingID4Unit"] = wingID.ToString();
                    Response.Redirect("~/GUI/Property/PropertyBlockDetails.aspx");
                }

                RoomType objRoomType = new RoomType();
                objRoomType.IsActive = true;
                objRoomType.PropertyID = clsSession.PropertyID;
                objRoomType.RoomTypeName = hfUnitValue.Value;

                List<RoomType> lstRoomType = RoomTypeBLL.GetAll(objRoomType);
                if (lstRoomType != null && lstRoomType.Count > 0)
                {
                    string wingCode = lstRoomType[0].RoomTypeCode;
                    roomTypeID = lstRoomType[0].RoomTypeID;
                }

                if (clsSession.PropertyID != Guid.Empty && wingID != Guid.Empty && roomTypeID != Guid.Empty)
                {
                    Session["WingID4Unit"] = wingID.ToString();
                    Session["RoomTypeID4Unit"] = roomTypeID.ToString();
                    Response.Redirect("~/GUI/Configurations/RoomList.aspx");
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

            Response.Redirect("~/GUI/Property/PropertyList.aspx");
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
                                if (clsSession.UserType == "SUPERADMIN" || clsSession.UserType == "ADMINISTRATOR" || clsSession.UserType == "ADMIN")
                                    e.Row.Cells[i].Text = "<a style='cursor:pointer;' onclick=\"fnRowCommand('" + headerText.ToString().ToUpper() + "','" + strBlockValue + "','" + headerText + "');\"><b>" + Convert.ToString(e.Row.Cells[i].Text) + "</b></a>";
                                else
                                    e.Row.Cells[i].Text = Convert.ToString(e.Row.Cells[i].Text);
                                
                                e.Row.Cells[i].BackColor = System.Drawing.Color.FromName("#f3f3f5");
                            }
                            else
                            {
                                if (clsSession.UserType == "SUPERADMIN" || clsSession.UserType == "ADMINISTRATOR" || clsSession.UserType == "ADMIN")
                                    e.Row.Cells[i].Text = "<a style='cursor:pointer;' onclick=\"fnRowCommand('" + headerText.ToString().ToUpper() + "','" + strBlockValue + "','" + headerText + "');\">" + Convert.ToString(e.Row.Cells[i].Text) + "</a>";
                                else
                                    e.Row.Cells[i].Text = Convert.ToString(e.Row.Cells[i].Text);
                            }
                        }
                    }
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoPropertyFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
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
                if (e.CommandName.Equals("ViewData"))
                {
                    //if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    //{
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
                    //}
                    //else
                    //{
                    //    Session["RoomTypeID4Unit"] = e.CommandArgument.ToString();
                    //    Response.Redirect("~/Applications/SetUp/RoomTypeSetup.aspx");
                    //}
                }
                else if (e.CommandName.Equals("EditData"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "ROOMTYPE";
                    Response.Redirect("~/GUI/Configurations/RoomType.aspx");
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
                    ((Label)e.Row.FindControl("lblGvHdrSoldUnit")).Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblGvHdrSoldUnits", "Sold Units");
                    ((Literal)e.Row.FindControl("litGvHdrUnitType")).Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblGvHdrTypeOfUnit", "Type of Unit");
                    ((Literal)e.Row.FindControl("litGvHdrNoOfUnits")).Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblGvHdrNoOfUnits", "No. of Units");
                    ((Label)e.Row.FindControl("lblGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    ((Label)e.Row.FindControl("litGvFtrTotal")).Text = clsCommon.GetGlobalResourceText("PropertyInformation", "lblGvFtrTotal", "Total");

                    if ((Label)e.Row.FindControl("lblTotalUnits") != null)
                        ((Label)e.Row.FindControl("lblTotalUnits")).Text = grandTotalUnits.ToString();

                    if ((Label)e.Row.FindControl("lblTotalSoldUnits") != null)
                        ((Label)e.Row.FindControl("lblTotalSoldUnits")).Text = grandTotalSoldUnits.ToString();
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("litNoBlockFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
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