using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class ctrlTransferTransactionFolio : System.Web.UI.UserControl
    {
        #region Variable

        Decimal dcmlTotalCharge = Convert.ToDecimal("0.000000");

        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
            }
        }

        public string Balance
        {
            get
            {
                return ViewState["Balance"] != null ? Convert.ToString(ViewState["Balance"]) : string.Empty;
            }
            set
            {
                ViewState["Balance"] = value;
            }
        }

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "TRANSFERTRANSACTION")
                {
                    this.FolioID = clsSession.ToEditItemID;
                    this.ReservationID = new Guid(Convert.ToString(Session["FolioListReservationID"]));
                    litDisplayCRLimit.Text = Convert.ToString(Session["FolioListBalance"]);
                    Session["TransactionFolioID"] = Convert.ToString(clsSession.ToEditItemID);
                    
                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                    //Session.Remove("FolioListReservationID");
                    //Session.Remove("FolioListBalance");
                    BindTransactionGrid();
                    BindBreadCrumb();
                }
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindTransactionGrid()
        {
            try
            {
                ////DataTable dtTable = new DataTable();

                ////DataColumn dc1 = new DataColumn("SeqNo");
                ////DataColumn dc2 = new DataColumn("Item");

                ////dtTable.Columns.Add(dc1);
                ////dtTable.Columns.Add(dc2);

                ////DataRow dr1 = dtTable.NewRow();
                ////dr1["SeqNo"] = "1-100.00";
                ////dr1["Item"] = "17052-96436&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accommodation 17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;100.00";

                ////dtTable.Rows.Add(dr1);

                ////DataRow dr2 = dtTable.NewRow();
                ////dr2["SeqNo"] = "2-200.00";
                ////dr2["Item"] = "17052-96436&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accommodation 17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;200.00";

                ////dtTable.Rows.Add(dr2);

                ////DataRow dr3 = dtTable.NewRow();
                ////dr3["SeqNo"] = "3-300.00";
                ////dr3["Item"] = "17052-96436&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accommodation 17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;300.00";

                ////dtTable.Rows.Add(dr3);

                ////DataRow dr4 = dtTable.NewRow();
                ////dr4["SeqNo"] = "4-400.00";
                ////dr4["Item"] = "17052-96436&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accommodation 17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;400.00";

                ////dtTable.Rows.Add(dr4);

                ////DataRow dr5 = dtTable.NewRow();
                ////dr5["SeqNo"] = "5-500.00";
                ////dr5["Item"] = "17052-96436&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Accommodation 17-05-2012&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;500.00";

                ////dtTable.Rows.Add(dr5);

                ////ItemsListView.DataSource = dtTable;
                ////ItemsListView.DataBind();

                DataSet dsData = TransactionBLL.GetAllTransaction(this.ReservationID, this.FolioID, null, null, clsSession.PropertyID, clsSession.CompanyID);

                DataTable tblCharge = new DataTable();


                if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    tblCharge = dsData.Tables[0].Clone();

                    tblCharge.Columns.Add("New_SeqNo");
                    tblCharge.Columns.Add("New_Date");
                    tblCharge.Columns.Add("New_Amount");

                    foreach (DataRow dtRow in dsData.Tables[0].Rows)
                    {
                        if (dtRow["IsCharge"] != null)
                        {
                            if (Convert.ToBoolean(dtRow["IsCharge"].ToString()) == true)
                            {
                                tblCharge.ImportRow(dtRow);

                                if (dtRow["CR_AMOUNT"] != null && Convert.ToString(dtRow["CR_AMOUNT"]) != string.Empty)
                                    dcmlTotalCharge = dcmlTotalCharge + Convert.ToDecimal(dtRow["CR_AMOUNT"]);
                            }
                        }
                    }

                    for (int i = 0; i < tblCharge.Rows.Count; i++)
                    {
                        decimal dcAmount = Convert.ToDecimal("0.000000");
                        dcAmount = Convert.ToDecimal(Convert.ToString(tblCharge.Rows[i]["CR_AMOUNT"]));
                        DateTime dtDate = Convert.ToDateTime(Convert.ToString(tblCharge.Rows[i]["EntryDate"]));

                        tblCharge.Rows[i]["New_SeqNo"] = Convert.ToString(i + 1) + "|" + Convert.ToString(dcAmount.ToString().Substring(0, dcAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint))) + "|" + Convert.ToString(tblCharge.Rows[i]["BookID"]);
                        tblCharge.Rows[i]["New_Date"] = Convert.ToString(dtDate.ToString(clsSession.DateFormat));
                        tblCharge.Rows[i]["New_Amount"] = Convert.ToString(dcAmount.ToString().Substring(0, dcAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                        tblCharge.AcceptChanges();
                    }

                    if (tblCharge.Rows.Count > 0)
                    {
                        tr1.Visible = true;
                        divMsg.Visible = false;

                        litName.Text = Convert.ToString(tblCharge.Rows[0]["GuestName"]);
                        litDisplayReservationNo.Text = Convert.ToString(tblCharge.Rows[0]["ReservationNo"]);
                        litDisplayFolioNo.Text = Convert.ToString(tblCharge.Rows[0]["FolioNo"]);
                        lblDisplayTotalBalanceFromDB.Text = Convert.ToString(dcmlTotalCharge.ToString().Substring(0, dcmlTotalCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                        lstTransactionData.DataSource = tblCharge;
                        lstTransactionData.DataBind();

                        string strReservationNo = null;
                        if (litDisplayReservationNo.Text.Trim() != "")
                            strReservationNo = Convert.ToString(litDisplayReservationNo.Text.Trim());
                        DataSet ds = ReservationBLL.GetCheckInRoomNoAndReservationNo(clsSession.PropertyID, clsSession.CompanyID, strReservationNo);

                        ddlSearchRoomNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                ddlSearchRoomNo.Items.Insert(i + 1, new ListItem(clsCommon.GetFormatedRoomNumber(Convert.ToString(ds.Tables[0].Rows[i]["RoomNo"])), Convert.ToString(ds.Tables[0].Rows[i]["RoomID"])));
                            }
                        }


                        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            ddlReservationNo.DataSource = ds.Tables[1];
                            ddlReservationNo.DataTextField = "ReservationNo";
                            ddlReservationNo.DataValueField = "ReservationID";
                            ddlReservationNo.DataBind();
                            ddlReservationNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                        }
                        else
                            ddlReservationNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                        ddlFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                }
                else
                {
                    tr1.Visible = false;
                    divMsg.Visible = true;
                    lstTransactionData.DataSource = null;
                    lstTransactionData.DataBind();

                    ddlFolioNo.Items.Clear();
                    ddlReservationNo.Items.Clear();
                    ddlSearchRoomNo.Items.Clear();
                    ddlSearchRoomNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlReservationNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            //DataTable dtTable = new DataTable();

            //DataColumn dc1 = new DataColumn("SeqNo");
            //DataColumn dc2 = new DataColumn("Item");

            //dtTable.Columns.Add(dc1);
            //dtTable.Columns.Add(dc2);

            //DataRow dr1 = dtTable.NewRow();
            //dr1["SeqNo"] = "1";
            //dr1["Item"] = "12345";

            //dtTable.Rows.Add(dr1);

            //DataRow dr2 = dtTable.NewRow();
            //dr2["SeqNo"] = "2";
            //dr2["Item"] = "23456";

            //dtTable.Rows.Add(dr2);

            //DataRow dr3 = dtTable.NewRow();
            //dr3["SeqNo"] = "3";
            //dr3["Item"] = "34567";

            //dtTable.Rows.Add(dr3);

            //DataRow dr4 = dtTable.NewRow();
            //dr4["SeqNo"] = "4";
            //dr4["Item"] = "45678";

            //dtTable.Rows.Add(dr4);

            //DataRow dr5 = dtTable.NewRow();
            //dr5["SeqNo"] = "5";
            //dr5["Item"] = "56789";

            //dtTable.Rows.Add(dr5);

            //ItemsListView.DataSource = dtTable;
            //ItemsListView.DataBind();

        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Billing";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = "Folio Details";
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Transfer Transaction Folio";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion Private Method

        #region Dropdown Event

        protected void ddlSearchRoomNo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSearchRoomNo.SelectedIndex != 0)
                {
                    ddlFolioNo.Items.Clear();
                    ddlFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    string strReservationNo = "select ReservationID,ReservationNo from res_Reservation where RoomID = '" + Convert.ToString(ddlSearchRoomNo.SelectedValue) + "'";

                    DataSet dsReservation = RoomBLL.GetUnitNo(strReservationNo);
                    if (dsReservation.Tables.Count > 0 && dsReservation.Tables[0].Rows.Count > 0)
                    {
                        ddlReservationNo.Items.Clear();
                        ddlReservationNo.DataSource = dsReservation.Tables[0];
                        ddlReservationNo.DataTextField = "ReservationNo";
                        ddlReservationNo.DataValueField = "ReservationID";
                        ddlReservationNo.DataBind();
                        ddlReservationNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlReservationNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlFolioNo.Items.Clear();
                    ddlReservationNo.Items.Clear();
                    ddlReservationNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlReservationNo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlReservationNo.SelectedIndex != 0)
                {
                    string strFolio = "select FolioNo,FolioID from res_Folio where ReservationID = '" + Convert.ToString(ddlReservationNo.SelectedValue) + "'";

                    DataSet dsFolio = RoomBLL.GetUnitNo(strFolio);
                    if (dsFolio.Tables.Count > 0 && dsFolio.Tables[0].Rows.Count > 0)
                    {
                        ddlFolioNo.Items.Clear();
                        ddlFolioNo.DataSource = dsFolio.Tables[0];
                        ddlFolioNo.DataTextField = "FolioNo";
                        ddlFolioNo.DataValueField = "FolioID";
                        ddlFolioNo.DataBind();
                        ddlFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlFolioNo.Items.Clear();
                    ddlFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Dropdown Event

        #region Control Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    int cnt = Convert.ToInt32(lstTransgerTransactionData.Items.Count);

                    if (cnt <= 0)
                    {
                        lblErrorMessage.Text = "";
                        mpeErrorMessage.Show();
                        return;
                    }

                    for (int i = 0; i < lstTransgerTransactionData.Items.Count; i++)
                    {
                        Guid BookID = new Guid(lstTransgerTransactionData.DataKeys[i]["BookID"].ToString());
                        FolioBLL.FolioTransferTransactionData(this.ReservationID, this.FolioID, new Guid(ddlReservationNo.SelectedValue), new Guid(ddlFolioNo.SelectedValue), BookID, false, clsSession.UserID);
                    }

                    mpeSuccessMsg.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            Session.Remove("FolioListReservationID");
            Session.Remove("FolioListBalance");
            Session.Remove("TransactionFolioID");
            Response.Redirect("~/GUI/Folio/FolioList.aspx");
        }

        #endregion Control Event

        //protected void ddlReservationNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindGrid();
        //}

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    string str = saveContent.InnerHtml;
        //}        
    }
}