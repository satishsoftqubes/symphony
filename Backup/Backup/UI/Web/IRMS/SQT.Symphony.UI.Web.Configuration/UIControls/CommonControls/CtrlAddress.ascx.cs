using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.CommonControls
{
    public partial class CtrlAddress : System.Web.UI.UserControl
    {
        #region Property Definition

        /// <summary>
        /// Get or Set Address
        /// </summary>
        public string strAddress
        {
            get { return txtAddress.Text.Trim(); }
            set { txtAddress.Text = value; }
        }
        /// <summary>
        /// Get or Set City
        /// </summary>
        public string strCity
        {
            get { return txtCity.Text.Trim(); }
            set { txtCity.Text = value; }
        }
        /// <summary>
        /// Get or Set State
        /// </summary>
        public string strState
        {
            get { return txtState.Text.Trim(); }
            set { txtState.Text = value; }
        }
        /// <summary>
        /// Get or Set Country
        /// </summary>
        public string strCountry
        {
            get { return txtCountry.Text.Trim(); }
            set { txtCountry.Text = value; }
        }
        /// <summary>
        /// Get or Set ZipCode
        /// </summary>
        public string strZipCode
        {
            get { return txtZipCode.Text.Trim(); }
            set { txtZipCode.Text = value; }
        }

        /// <summary>
        /// Get or Set Address lable
        /// </summary>
        public string strLtrAddress
        {
            get { return ltrAddress.Text.Trim(); }
            set { ltrAddress.Text = value; }
        }
        /// <summary>
        /// Get or Set City lable
        /// </summary>
        public string strLtrCity
        {
            get { return ltrCity.Text.Trim(); }
            set { ltrCity.Text = value; }
        }
        /// <summary>
        /// Get or Set State lable
        /// </summary>
        public string strLtrState
        {
            get { return ltrState.Text.Trim(); }
            set { ltrState.Text = value; }
        }
        /// <summary>
        /// Get or Set Country lable
        /// </summary>
        public string strLtrCountry
        {
            get { return ltrCountry.Text.Trim(); }
            set { ltrCountry.Text = value; }
        }
        /// <summary>
        /// Get or Set ZipCode lable
        /// </summary>
        public string strLtrZipCode
        {
            get { return ltrZipCode.Text.Trim(); }
            set { ltrZipCode.Text = value; }
        }

        /// <summary>
        /// Get or Set Address Requrefield Validator
        /// </summary>
        public RequiredFieldValidator rfvAddress
        {
            get { return this.rvfAddress; }
        }
        /// <summary>
        /// Get or Set City Requrefield Validator
        /// </summary>
        public RequiredFieldValidator rfvCity
        {
            get { return this.rvfCity; }
        }
        /// <summary>
        /// Get or Set State Requrefield Validator
        /// </summary>
        public RequiredFieldValidator rfvState
        {
            get { return this.rvfState; }
        }
        /// <summary>
        /// Get or Set Country Requrefield Validator
        /// </summary>
        public RequiredFieldValidator rfvCountry
        {
            get { return this.rvfCountry; }
        }
        /// <summary>
        /// Get or Set ZipCode Requrefield Validator
        /// </summary>
        public RequiredFieldValidator rfvZipCode
        {
            get { return this.rvfZipCode; }
        }

        public System.Web.UI.HtmlControls.HtmlTableCell tcAddress
        {
            get { return this.tdAddress; }
        }

        public System.Web.UI.HtmlControls.HtmlTableCell tcCity
        {
            get { return this.tdCity; }
        }

        public System.Web.UI.HtmlControls.HtmlTableCell tcState
        {
            get { return this.tdState; }
        }

        public System.Web.UI.HtmlControls.HtmlTableCell tcCountry
        {
            get { return this.tdCountry; }
        }

        public System.Web.UI.HtmlControls.HtmlTableCell tcZipcode
        {
            get { return this.tdZipcode; }
        }

        #endregion Property Definition

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
            }
        }

        #endregion Form Load

        #region Methods
        private void SetPageLables()
        {
            string strPageUrl = Request.RawUrl.ToString();

            if (!(strPageUrl.ToUpper().Contains("COMPANYSETUP.ASPX") || strPageUrl.ToUpper().Contains("EMPLOYEESETUP.ASPX")))
                ltrAddress.Text = clsCommon.GetGlobalResourceText("Address", "lblAddress", "Address");

            ltrCity.Text = clsCommon.GetGlobalResourceText("Address", "lblCity", "City");
            ltrState.Text = clsCommon.GetGlobalResourceText("Address", "lblState", "State");
            ltrCountry.Text = clsCommon.GetGlobalResourceText("Address", "lblCountry", "Country");
            ltrZipCode.Text = clsCommon.GetGlobalResourceText("Address", "lblZipCode", "Zipcode");
        }
        #endregion
    }
}