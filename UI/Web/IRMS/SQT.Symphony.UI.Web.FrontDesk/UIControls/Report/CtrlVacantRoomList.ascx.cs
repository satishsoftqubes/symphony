using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlVacantRoomList : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;

        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LoadControlValue();
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Load Control Value
        /// </summary>
        private void LoadControlValue()
        {
            try
            {              
                calStartDate.Format = "dd-MM-yyyy";
                this.DateFormat = "dd-MM-yyyy";             
                chkStartDate.Checked = true;
                chkStartDate_CheckedChanged(null, null);
                txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);               
                BindRoomType();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load RoomType
        /// </summary>
        private void BindRoomType()
        {
            RoomType Rm = new RoomType();
            Rm.PropertyID = clsSession.PropertyID;
            Rm.IsActive = true;
            List<RoomType> LstRm = RoomTypeBLL.GetAll(Rm);
            if (LstRm.Count > 0)
            {
                LstRm.Sort((RoomType rm1, RoomType rm2) => rm1.RoomTypeName.CompareTo(rm2.RoomTypeName));
                ddlRoomType.DataSource = LstRm;
                ddlRoomType.DataTextField = "RoomTypeName";
                ddlRoomType.DataValueField = "RoomTypeID";
                ddlRoomType.DataBind();
                ddlRoomType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlRoomType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Vacant Room List");
                DataSet ds = new DataSet();
                Guid? iRmTypID = null;
                DateTime? startdt = null;              

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!ddlRoomType.SelectedValue.Equals(Guid.Empty.ToString()))
                    iRmTypID = (Guid?)new Guid(Convert.ToString(ddlRoomType.SelectedValue));

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                
                if (!ddlRoomType.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("RptRmType", ddlRoomType.SelectedItem.Text);
                Session.Add("StartDate", startdt);                   

                ds = RoomBLL.RPTVacantRoomList(clsSession.PropertyID,iRmTypID, startdt, startdt);                
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Click Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion

        #region CheckBox Event
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
        }      
        #endregion          
    }
}