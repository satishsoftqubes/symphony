using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonMessage : System.Web.UI.UserControl
    {
        ////public ModalPopupExtender ucMpeMessage
        ////{
        ////    get { return this.mpeMessage; }
        ////}

        #region Variable

        public MultiView mvOpenMessage
        {
            get { return this.mvMessage; }
        }

        public string strPageName
        {
            get
            {
                return ViewState["strPageName"] != null ? Convert.ToString(ViewState["strPageName"]) : string.Empty;
            }
            set
            {
                ViewState["strPageName"] = value;
            }
        }

        public string strView
        {
            get
            {
                return ViewState["strView"] != null ? Convert.ToString(ViewState["strView"]) : string.Empty;
            }
            set
            {
                ViewState["strView"] = value;
            }
        }

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

        public Guid GuestID
        {
            get
            {
                return ViewState["GuestID"] != null ? new Guid(Convert.ToString(ViewState["GuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestID"] = value;
            }
        }

        public bool IsMessage = false;

        public event EventHandler btnMessageCallParent_Click;

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvMessage.ActiveViewIndex = 0;
                DateTime dtDateTime = DateTime.Now;
                // litDisplayMessageDate.Text = Convert.ToString(dtDateTime.ToString("dd/MMM/yyyy hh:mm:tt"));
                //BindReservatonGird();
                //BindGuestListGrid();
                BindProjectTerm();
                BindGuestAndReservationGrid();

                this.strPageName = GetPageName();

                if (strPageName.ToUpper() == "MESSAGE.ASPX")
                    trCancel.Visible = false;
                else
                    trCancel.Visible = true;
            }
        }

        #endregion  Page Load

        #region Grid Event

        protected void gvReservationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("MESSAGE"))
                {
                    mvMessage.ActiveViewIndex = 1;
                    string strName = Convert.ToString(e.CommandArgument);
                    string[] strSplit = strName.Split(',');

                    litDisplayGuestName.Text = Convert.ToString(strSplit[1]);
                    litDisplayBookingNo.Text = Convert.ToString(strSplit[0]);
                    this.ReservationID = new Guid(Convert.ToString(strSplit[2]));
                    this.GuestID = new Guid(Convert.ToString(strSplit[3]));
                    BindMessages();

                    if (strPageName.ToUpper() != "MESSAGE.ASPX")
                    {
                        strView = "1";
                        EventHandler temp = btnMessageCallParent_Click;
                        if (temp != null)
                        {
                            temp(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvReservationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReservationList.PageIndex = e.NewPageIndex;
            BindGuestAndReservationGrid();
        }

        protected void gvGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("MESSAGE"))
                {
                    mvMessage.ActiveViewIndex = 1;
                    string strName = Convert.ToString(e.CommandArgument);
                    string[] strSplit = strName.Split(',');

                    litDisplayGuestName.Text = Convert.ToString(strSplit[1]);
                    litDisplayBookingNo.Text = Convert.ToString(strSplit[0]);
                    this.ReservationID = new Guid(Convert.ToString(strSplit[2]));
                    this.GuestID = new Guid(Convert.ToString(strSplit[3]));
                    BindMessages();
                    if (strPageName.ToUpper() != "MESSAGE.ASPX")
                    {
                        strView = "1";
                        EventHandler temp = btnMessageCallParent_Click;
                        if (temp != null)
                        {
                            temp(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvGuestList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestList.PageIndex = e.NewPageIndex;
            BindGuestAndReservationGrid();
        }

        #endregion  Grid Event

        #region Private Method

        //private void BindReservatonGird()
        //{

        //    DataSet dsReservation = ReservationBLL.GetResrvationList(null, null, null, null, null, clsSession.PropertyID, clsSession.CompanyID, null, null);

        //    gvReservationList.DataSource = dsReservation;
        //    gvReservationList.DataBind();

        //    //DataTable dtService = new DataTable();

        //    //DataColumn dc1 = new DataColumn("ResNo");
        //    //DataColumn dc2 = new DataColumn("GuestName");
        //    //DataColumn dc3 = new DataColumn("MobileNo");
        //    //DataColumn dc5 = new DataColumn("ReservationStatus");

        //    //dtService.Columns.Add(dc1);
        //    //dtService.Columns.Add(dc2);
        //    //dtService.Columns.Add(dc3);
        //    //dtService.Columns.Add(dc5);

        //    //DataRow dr1 = dtService.NewRow();
        //    //dr1["ResNo"] = "123456";
        //    //dr1["GuestName"] = "Mr. Jayesh Rathod";
        //    //dr1["MobileNo"] = "9958648101";
        //    //dr1["ReservationStatus"] = "Confirmed";

        //    //dtService.Rows.Add(dr1);

        //    //DataRow dr2 = dtService.NewRow();
        //    //dr2["ResNo"] = "951753";
        //    //dr2["GuestName"] = "Miss. Palak Jain";
        //    //dr2["MobileNo"] = "8758962102";
        //    //dr2["ReservationStatus"] = "Provisional";

        //    //dtService.Rows.Add(dr2);

        //    //gvReservationList.DataSource = dtService;
        //    //gvReservationList.DataBind();



        //}

        //private void BindGuestListGrid()
        //{


        //    DataSet dsGuest = GuestBLL.GetExistingGuest(null, null, clsSession.PropertyID, clsSession.CompanyID);

        //    gvGuestList.DataSource = dsGuest;
        //    gvGuestList.DataBind();

        //    //DataTable dtService = new DataTable();


        //    //DataColumn dc1 = new DataColumn("ResNo");
        //    //DataColumn dc2 = new DataColumn("GuestName");
        //    //DataColumn dc3 = new DataColumn("RoomNo");
        //    //DataColumn dc5 = new DataColumn("MobileNo");

        //    //dtService.Columns.Add(dc1);
        //    //dtService.Columns.Add(dc2);
        //    //dtService.Columns.Add(dc3);
        //    //dtService.Columns.Add(dc5);

        //    //DataRow dr1 = dtService.NewRow();
        //    //dr1["ResNo"] = "123456";
        //    //dr1["GuestName"] = "Mr. Jayesh Rathod";
        //    //dr1["RoomNo"] = "A0-011";
        //    //dr1["MobileNo"] = "9825464858";

        //    //dtService.Rows.Add(dr1);

        //    //DataRow dr2 = dtService.NewRow();
        //    //dr2["ResNo"] = "951753";
        //    //dr2["GuestName"] = "Miss. Palak Jain";
        //    //dr2["RoomNo"] = "B1-008";
        //    //dr2["MobileNo"] = "7623345856";

        //    //dtService.Rows.Add(dr2);

        //    //gvGuestList.DataSource = dtService;
        //    //gvGuestList.DataBind();
        //}

        private void BindGuestAndReservationGrid()
        {
            try
            {
                string strGuestName = null;
                string strRoomNo = null;

                if (txtSearchGuestName.Text.Trim() != "")
                    strGuestName = txtSearchGuestName.Text.Trim();

                if (txtSearchRoomNo.Text.Trim() != "")
                    strRoomNo = txtSearchRoomNo.Text.Trim();


                DataSet dsGuestAndResrList = GuestBLL.GetGuestAndReserForGuestMsglist(clsSession.PropertyID, clsSession.CompanyID, strGuestName, strRoomNo);

                gvReservationList.DataSource = gvGuestList.DataSource = dsGuestAndResrList;
                gvReservationList.DataBind();
                gvGuestList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindMessages()
        {
            try
            {

                DataSet dsGuestMsg = GuestMsgJoinBLL.GetGuestMsgJoinSelectForList(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);
                gvMessages.DataSource = dsGuestMsg;
                gvMessages.DataBind();

                //DataTable dtService = new DataTable();


                //DataColumn dc1 = new DataColumn("Name");
                //DataColumn dc2 = new DataColumn("Date");
                //DataColumn dc3 = new DataColumn("Message");



                //dtService.Columns.Add(dc1);
                //dtService.Columns.Add(dc2);
                //dtService.Columns.Add(dc3);


                //DataRow dr1 = dtService.NewRow();
                //dr1["Name"] = "Mr. Pradip Patel";
                //dr1["Date"] = "13-08-2012";
                //dr1["Message"] = "hello...";


                //dtService.Rows.Add(dr1);

                //DataRow dr2 = dtService.NewRow();
                //dr2["Name"] = "Miss. Joya Khan";
                //dr2["Date"] = "7-08-2012";
                //dr2["Message"] = "Hi.....";


                //dtService.Rows.Add(dr2);

                //gvMessages.DataSource = dtService;
                //gvMessages.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetPageName()
        {
            var uri = new Uri(Convert.ToString(Request.Url));
            string path = uri.GetLeftPart(UriPartial.Path);
            string[] strArray = path.Split('/');
            string strPageName = "";
            return strPageName = Convert.ToString(strArray[strArray.Length - 1]);
        }

        private void ClearControl()
        {
            txtSearchRoomNo.Text = txtSearchGuestName.Text = "";

            // Message Controls
            txtMessageSubject.Text = txtMessageBy.Text = txtMessage.Text = "";
            ddlMessageOption.SelectedIndex = ddlMessagePriority.SelectedIndex = 0;
        }

        private void BindProjectTerm()
        {
            try
            {
                ddlMessageOption.Items.Clear();
                List<ProjectTerm> litMessegeOption = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "RESERVATION CANCEL REQUEST MODE");
                if (litMessegeOption.Count != 0 && litMessegeOption.Count > 0)
                {
                    ddlMessageOption.DataSource = litMessegeOption;
                    ddlMessageOption.DataTextField = "DisplayTerm";
                    ddlMessageOption.DataValueField = "TermID";
                    ddlMessageOption.DataBind();
                    ddlMessageOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlMessageOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }

                ddlMessagePriority.Items.Clear();
                List<ProjectTerm> litPriority = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PRIORITY");
                if (litPriority.Count != 0 && litPriority.Count > 0)
                {
                    ddlMessagePriority.DataSource = litPriority;
                    ddlMessagePriority.DataTextField = "DisplayTerm";
                    ddlMessagePriority.DataValueField = "TermID";
                    ddlMessagePriority.DataBind();
                    ddlMessagePriority.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlMessagePriority.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion  Private Method

        #region Button Event

        protected void btnMessageCancel_Click(object sender, EventArgs e)
        {
            mvMessage.ActiveViewIndex = 0;
            if (strPageName.ToUpper() != "MESSAGE.ASPX")
            {
                strView = "0";

                EventHandler temp = btnMessageCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            BindGuestAndReservationGrid();
        }

        protected void imgbtnClearSearch_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            BindGuestAndReservationGrid();
        }

        protected void btnMessageSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuestData = GuestBLL.GetByPrimaryKey(this.GuestID);

                    GuestMsgJoin objGuestMsgSave = new GuestMsgJoin();

                    objGuestMsgSave.Subject = txtMessageSubject.Text.Trim();
                    objGuestMsgSave.MessageFrom = txtMessageBy.Text.Trim();
                    if (ddlMessageOption.SelectedIndex != 0)
                    {
                        objGuestMsgSave.MessageOption_TermID = new Guid(ddlMessageOption.SelectedValue.ToString());
                    }
                    objGuestMsgSave.Msg_PriorityTermID = new Guid(ddlMessagePriority.SelectedValue.ToString());
                    objGuestMsgSave.Message = txtMessage.Text.Trim();
                    objGuestMsgSave.Msg_DateTime = DateTime.Now.Date;
                    objGuestMsgSave.CompanyID = clsSession.CompanyID;
                    objGuestMsgSave.PropertyID = clsSession.PropertyID;
                    objGuestMsgSave.IsActive = true;
                    objGuestMsgSave.IsInformed = false;
                    objGuestMsgSave.GuestID = this.GuestID;
                    objGuestMsgSave.ReservationID = this.ReservationID;
                    objGuestMsgSave.CompanyName = objGuestData.CompanyName.ToString();
                    objGuestMsgSave.ContactName = objGuestData.GuestFullName.ToString();

                    GuestMsgJoinBLL.Save(objGuestMsgSave);
                    IsMessage = true;
                    lblGuestMsg.Text = "Record Save successfully.";

                    ClearControl();
                    BindMessages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion  Button Event

        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }
    }
}