using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlPropertyInsuranceView : System.Web.UI.UserControl
    {
        #region Property and Variable
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
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DateFormat = "dd-MM-yyyy";
                BindInsuranceGrid();
            }
        }
        #endregion Page Load

        #region Private Method
        private void BindInsuranceGrid()
        {
            //DataTable dtTable = new DataTable();
            //DataColumn dc1 = new DataColumn("InsuranceID");
            //DataColumn dc2 = new DataColumn("DocumentName");
            //DataColumn dc3 = new DataColumn("StartDate");
            //DataColumn dc4 = new DataColumn("EndDate");
            //dtTable.Columns.Add(dc1);
            //dtTable.Columns.Add(dc2);
            //dtTable.Columns.Add(dc3);
            //dtTable.Columns.Add(dc4);


            //DataRow dr1 = dtTable.NewRow();
            //dr1["InsuranceID"] = Guid.NewGuid();
            //dr1["DocumentName"] = "Document1";
            //dr1["StartDate"] = "12-09-2012";
            //dr1["EndDate"] = "12-09-2013";
            //dtTable.Rows.Add(dr1);


            //DataRow dr2 = dtTable.NewRow();
            //dr2["InsuranceID"] = Guid.NewGuid();
            //dr2["DocumentName"] = "Document2";
            //dr2["StartDate"] = "10-09-2014";
            //dr2["EndDate"] = "11-09-2016";
            //dtTable.Rows.Add(dr2);


            //gvPropertyInsuranceView.DataSource = dtTable;
            //gvPropertyInsuranceView.DataBind();

            DataSet dsForinsuranceDetails = InsuranceDetailsBLL.GetInsuranceDetailsData(null);
            if (dsForinsuranceDetails != null && dsForinsuranceDetails.Tables.Count > 0 && dsForinsuranceDetails.Tables[0].Rows.Count > 0)
            {
                gvPropertyInsuranceView.DataSource = dsForinsuranceDetails.Tables[0];
                gvPropertyInsuranceView.DataBind();
            }
            else
            {
                gvPropertyInsuranceView.DataSource = null;
                gvPropertyInsuranceView.DataBind();
            }

        }
        #endregion Private Method

        #region Grid Event
        protected void gvPropertyInsuranceView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal litStartDate = (Literal)e.Row.FindControl("litStartDate");
                    Literal litValidUpto = (Literal)e.Row.FindControl("litValidUpto");
                    if (DataBinder.Eval(e.Row.DataItem, "FromDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FromDate")) != "")
                    {
                        litStartDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FromDate")).ToString(this.DateFormat);
                    }
                    else
                    {
                        litStartDate.Text = "";
                    }

                    if (DataBinder.Eval(e.Row.DataItem, "ToDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ToDate")) != "")
                    {
                        litValidUpto.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ToDate")).ToString(this.DateFormat);
                    }
                    else
                    {
                        litValidUpto.Text = "";
                    }
                    //

                    Image AttImg = (Image)e.Row.FindControl("btnAttachment");

                    //AttImg.Visible = Convert.ToBoolean(ViewState["View"]);

                    string DocumentName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DocumentName"));
                    if (!DocumentName.Equals("") && DocumentName != null)
                        AttImg.Visible = true;
                    else
                        AttImg.Visible = false;
                }


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void gvPropertyInsuranceView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("INSURANCEDETAILS") && Convert.ToString(e.CommandArgument) != "")
            {
                mpeInsuranceDetails.Show();
                DataSet dsForinsuranceDetails = InsuranceDetailsBLL.GetInsuranceDetailsData(null);
                if (dsForinsuranceDetails != null && dsForinsuranceDetails.Tables.Count > 0 && dsForinsuranceDetails.Tables[0].Rows.Count > 0)
                {
                    DataRow drForinsDetails = dsForinsuranceDetails.Tables[0].Rows[0];

                    if (drForinsDetails["PropertyName"] != null && Convert.ToString(drForinsDetails["PropertyName"]) != "")
                        litDispPropertyName.Text = Convert.ToString(drForinsDetails["PropertyName"]);
                    else
                        litDispPropertyName.Text = "-";

                    if (drForinsDetails["FromDate"] != null && Convert.ToString(drForinsDetails["FromDate"]) != "")
                        litDispInsuranceperiod.Text = Convert.ToDateTime(drForinsDetails["FromDate"]).ToString(this.DateFormat) + " to " + Convert.ToDateTime(drForinsDetails["Todate"]).ToString(this.DateFormat);
                    else
                        litDispInsuranceperiod.Text = "-";

                    if (drForinsDetails["CompanyName"] != null && Convert.ToString(drForinsDetails["CompanyName"]) != "")
                        lblDispCompanyName.Text = Convert.ToString(drForinsDetails["CompanyName"]);
                    else
                        lblDispCompanyName.Text = "-";

                    if (drForinsDetails["PolicyNo"] != null && Convert.ToString(drForinsDetails["PolicyNo"]) != "")
                        lblDispPolicyNo.Text = Convert.ToString(drForinsDetails["PolicyNo"]);
                    else
                        lblDispPolicyNo.Text = "-";


                }

            }
        }
        protected void gvPropertyInsuranceView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPropertyInsuranceView.PageIndex = e.NewPageIndex;
            BindInsuranceGrid();
        }
        #endregion Grid Event

    }
}