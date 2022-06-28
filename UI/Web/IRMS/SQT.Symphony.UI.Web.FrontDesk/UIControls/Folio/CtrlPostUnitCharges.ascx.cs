using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlPostUnitCharges : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditPostUnitCharges
        {
            get { return this.mpePostUnitCharges; }
        }

        public event EventHandler btnPostUnitChargesCallParent_Click;

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

        public string strMode = null;

        public bool IsMessage = false;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CalPostUnitChargesStartDate.Format = CalPostUnitChargesEndDate.Format = clsSession.DateFormat;
            }
        }

        #endregion Page Load

        #region Control Event

        protected void btnPostUnitChargesSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Convert.ToDateTime(txtGuestAnniversary.Text.Trim());

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime dtStartDate = DateTime.ParseExact(txtPostUnitChargesStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                DateTime dtEndDate = DateTime.ParseExact(txtPostUnitChargesEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                //if (Convert.ToDateTime(txtPostUnitChargesEndDate.Text.Trim()) > Convert.ToDateTime(txtPostUnitChargesStartDate.Text.Trim()))
                //{
                DataSet dsUnPostedCharges = ReservationBLL.GetAllUnpostedCharges(this.ReservationID, null, false);

                if (dsUnPostedCharges.Tables.Count > 0 && dsUnPostedCharges.Tables[0].Rows.Count > 0)
                {
                    DataView dvUnPostedCharges = dsUnPostedCharges.Tables[0].DefaultView;
                    dvUnPostedCharges.RowFilter = "ServiceDate>='" + dtStartDate + "' and ServiceDate<='" + dtEndDate + "'";

                    if (dvUnPostedCharges.Count != 0)
                    {
                        for (int i = 0; i < dvUnPostedCharges.Count; i++)
                        {
                            Guid? ResBlockDateRateID = null;

                            if (dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"] != null && Convert.ToString(dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"]) != string.Empty)
                                ResBlockDateRateID = new Guid(Convert.ToString(dvUnPostedCharges.Table.Rows[i]["ResBlockDateRateID"]));

                            decimal dcmlAmount = Convert.ToDecimal(dvUnPostedCharges.Table.Rows[i]["Amount"]);
                            DateTime dtPostDate = Convert.ToDateTime(dvUnPostedCharges.Table.Rows[i]["ServiceDate"]);

                            if (ResBlockDateRateID != null && Convert.ToString(ResBlockDateRateID) != Guid.Empty.ToString())
                            {
                                TransactionBLL.PostRoomCharge(dtPostDate, this.ReservationID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlAmount, clsSession.CompanyID);
                            }
                        }
                        IsMessage = true;
                        lblCommonMsg.Text = "Room Charge Post successfully.";

                    }

                }

                //}
                //else
                //{
                //    //mpeDateErrorMsg.Show();
                //}

                ClearControl();
                EventHandler temp = btnPostUnitChargesCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Private Method

        private void ClearControl()
        {
            txtPostUnitChargesEndDate.Text = "";
            txtPostUnitChargesStartDate.Text = "";
            this.ReservationID = this.FolioID = Guid.Empty;

        }

        #endregion

        #region Public Method

        public void BindFolioDetail()
        {
            try
            {
                //DataSet dsFolioList = FolioBLL.GetAllFolios(this.FolioID, null, null, null, null, clsSession.CompanyID, clsSession.PropertyID);

                //if (dsFolioList.Tables[0].Rows.Count != 0)
                //{
                //    litDisplayPostUnitChargesGuestName.Text = dsFolioList.Tables[0].Rows[0]["GuestFullName"].ToString();
                //    litDisplayPostRoomChargesReservationNo.Text = dsFolioList.Tables[0].Rows[0]["ReservationNo"].ToString();
                //    //litDspCheckin.Text = dsFolioList.Tables[0].Rows[0]["CheckInDate"].ToString();
                //    litDisplayPostUnitChargesUnitNo.Text = dsFolioList.Tables[0].Rows[0]["RoomNo"].ToString();
                //    //litDspCheckoutDate.Text = dsFolioList.Tables[0].Rows[0]["CheckOutDate"].ToString();

                //    if (dsFolioList.Tables[0].Rows[0]["CheckOutDate"].ToString() != "")
                //    {
                //        DateTime CheckoutDate = Convert.ToDateTime(Convert.ToString(dsFolioList.Tables[0].Rows[0]["CheckOutDate"]));
                //        //litDspCheckoutDate.Text = Convert.ToString(CheckoutDate.ToString(clsSession.DateFormat));
                //        CalPostUnitChargesStartDate.EndDate = CheckoutDate;
                //        CalPostUnitChargesEndDate.EndDate = CheckoutDate;
                //        CalPostUnitChargesEndDate.SelectedDate = CheckoutDate;
                //    }

                //    if (dsFolioList.Tables[0].Rows[0]["CheckInDate"].ToString() != "")
                //    {
                //        DateTime CheckinDate = Convert.ToDateTime(Convert.ToString(dsFolioList.Tables[0].Rows[0]["CheckInDate"]));
                //        //litDspCheckin.Text = Convert.ToString(CheckinDate.ToString(clsSession.DateFormat));
                //        CalPostUnitChargesStartDate.StartDate = CheckinDate;
                //        CalPostUnitChargesEndDate.StartDate = CheckinDate;
                //        CalPostUnitChargesStartDate.SelectedDate = CheckinDate;
                //    }
                //}

                DataSet dsRservationData = ReservationBLL.GetResrvationViewData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);
                if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsRservationData.Tables[0].Rows[0];

                    litDisplayPostUnitChargesGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    litDisplayPostRoomChargesReservationNo.Text = Convert.ToString(dr["ReservationNo"]);
                    litDisplayPostUnitChargesUnitNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));


                    DataSet dsUnPostedChargesForDate = ReservationBLL.GetAllUnpostedCharges(this.ReservationID, null, false);

                    if (dsUnPostedChargesForDate.Tables[0].Rows.Count != 0)
                    {
                        DateTime StartTime = Convert.ToDateTime((dsUnPostedChargesForDate.Tables[0].Compute("min(ServiceDate)", string.Empty)));
                        DateTime EndTime = Convert.ToDateTime((dsUnPostedChargesForDate.Tables[0].Compute("max(ServiceDate)", string.Empty)));


                        CalPostUnitChargesStartDate.StartDate = StartTime;
                        CalPostUnitChargesEndDate.StartDate = StartTime;
                        CalPostUnitChargesStartDate.SelectedDate = StartTime;

                        CalPostUnitChargesStartDate.EndDate = EndTime;
                        CalPostUnitChargesEndDate.EndDate = EndTime;
                        CalPostUnitChargesEndDate.SelectedDate = EndTime;
                    }

                    //DateTime CheckinDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    ////litDisplayArrivalDate.Text = litDspCheckin.Text = Convert.ToString(CheckinDate.ToString(clsSession.DateFormat));


                    //DateTime CheckoutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));
                    ////litDisplayDepatureDate.Text = litDspCheckoutDate.Text = Convert.ToString(CheckoutDate.ToString(clsSession.DateFormat));

                    //CalPostUnitChargesStartDate.EndDate = CheckoutDate;
                    //CalPostUnitChargesEndDate.EndDate = CheckoutDate;
                    //CalPostUnitChargesEndDate.SelectedDate = CheckoutDate;

                    //CalPostUnitChargesStartDate.StartDate = CheckinDate;
                    //CalPostUnitChargesEndDate.StartDate = CheckinDate;
                    //CalPostUnitChargesStartDate.SelectedDate = CheckinDate;

                    litDisplayPostUnitChargesUnitNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}