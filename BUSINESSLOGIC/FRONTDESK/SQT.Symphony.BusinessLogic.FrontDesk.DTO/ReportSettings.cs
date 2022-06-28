using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQT.FRAMEWORK.DAL;
using System.Data;

namespace SQT.Symphony.BusinessLogic.FrontDesk.DTO
{
    public class ReportSettings
    {
        #region Entity Definition
        private bool isDisplayLogo;
        private string logoAlignment;
        private bool isDisplayAddress;
        private string addressAlignment;
        private bool isPageNo;
        private string pageNoAlignment;
        private bool prePrintedFlag;
        private string sizeOfPaper;
        private string orientation;
        private double? marginLeft;
        private double? marginRight;
        private double? marginTop;
        private double? marginBottom;
        private byte[] logo;

        private static List<ReportSettings> ls;
        #endregion Entity Definition

        #region Property Definition
        /// <summary>
        /// IsDisplayLogo property is used to get the integer value of field IsDisplayLogo. 
        /// </summary> 
        public bool IsDisplayLogo
        {
            get { return this.isDisplayLogo; }
            set { this.isDisplayLogo = value; }
        }

        /// <summary>
        /// LogoAlignment property is used to get the integer value of field LogoAlignment. 
        /// </summary> 
        public string LogoAlignment
        {
            get { return this.logoAlignment; }
            set
            {
                if (value != null && !value.Equals(""))
                {
                    if (value.Length <= 20)
                        this.logoAlignment = value;
                    else
                        throw new Exception("LogoAlignment length must be less or equal to 20...");
                }
                else
                {
                    if (value != null)
                        this.logoAlignment = null;
                    else
                        this.logoAlignment = value;
                }
            }
        }

        /// <summary>
        /// IsDisplayAddress property is used to get the integer value of field IsDisplayAddress. 
        /// </summary> 
        public bool IsDisplayAddress
        {
            get { return this.isDisplayAddress; }
            set { this.isDisplayAddress = value; }
        }

        /// <summary>
        /// AddressAlignment property is used to get the integer value of field AddressAlignment. 
        /// </summary> 
        public string AddressAlignment
        {
            get { return this.addressAlignment; }
            set
            {
                if (value != null && !value.Equals(""))
                {
                    if (value.Length <= 20)
                        this.addressAlignment = value;
                    else
                        throw new Exception("AddressAlignment length must be less or equal to 20...");
                }
                else
                {
                    if (value != null)
                        this.addressAlignment = null;
                    else
                        this.addressAlignment = value;
                }
            }
        }

        /// <summary>
        /// IsPageNo property is used to get the integer value of field IsPageNo. 
        /// </summary> 
        public bool IsPageNo
        {
            get { return this.isPageNo; }
            set { this.isPageNo = value; }
        }

        /// <summary>
        /// PageNoAlignment property is used to get the integer value of field PageNoAlignment. 
        /// </summary> 
        public string PageNoAlignment
        {
            get { return this.pageNoAlignment; }
            set
            {
                if (value != null && !value.Equals(""))
                {
                    if (value.Length <= 50)
                        this.pageNoAlignment = value;
                    else
                        throw new Exception("PageNoAlignment length must be less or equal to 50...");
                }
                else
                {
                    if (value != null)
                        this.pageNoAlignment = null;
                    else
                        this.pageNoAlignment = value;
                }
            }
        }

        /// <summary>
        /// PrePrintedFlag property is used to get the integer value of field PrePrintedFlag. 
        /// </summary> 
        public bool PrePrintedFlag
        {
            get { return this.prePrintedFlag; }
            set { this.prePrintedFlag = value; }
        }

        /// <summary>
        /// SizeOfPaper property is used to get the integer value of field SizeOfPaper. 
        /// </summary> 
        public string SizeOfPaper
        {
            get { return this.sizeOfPaper; }
            set
            {
                if (value != null && !value.Equals(""))
                {
                    if (value.Length <= 50)
                        this.sizeOfPaper = value;
                    else
                        throw new Exception("SizeOfPaper length must be less or equal to 50...");
                }
                else
                {
                    if (value != null)
                        this.sizeOfPaper = null;
                    else
                        this.sizeOfPaper = value;
                }
            }
        }

        /// <summary>
        /// Orientation property is used to get the integer value of field Orientation. 
        /// </summary> 
        public string Orientation
        {
            get { return this.orientation; }
            set
            {
                if (value != null && !value.Equals(""))
                {
                    if (value.Length <= 50)
                        this.orientation = value;
                    else
                        throw new Exception("Orientation length must be less or equal to 50...");
                }
                else
                {
                    if (value != null)
                        this.orientation = null;
                    else
                        this.orientation = value;
                }
            }
        }

        /// <summary>
        /// MarginLeft property is used to get the integer value of field MarginLeft. 
        /// </summary> 
        public double? MarginLeft
        {
            get { return this.marginLeft; }
            set { this.marginLeft = value; }
        }

        /// <summary>
        /// MarginRight property is used to get the integer value of field MarginRight. 
        /// </summary> 
        public double? MarginRight
        {
            get { return this.marginRight; }
            set { this.marginRight = value; }
        }

        /// <summary>
        /// MarginTop property is used to get the integer value of field MarginTop. 
        /// </summary> 
        public double? MarginTop
        {
            get { return this.marginTop; }
            set { this.marginTop = value; }
        }

        /// <summary>
        /// MarginBottom property is used to get the integer value of field MarginBottom. 
        /// </summary> 
        public double? MarginBottom
        {
            get { return this.marginBottom; }
            set { this.marginBottom = value; }
        }

        /// <summary>
        /// Logo property is used to get the integer value of field Logo. 
        /// </summary> 
        public byte[] Logo
        {
            get { return this.logo; }
            set { this.logo = value; }
        }
        #endregion Property Definition

        #region Constructor Definition        

        /// <summary>
        /// Constructor with transaction scope which initialize all fields values with its repective
        /// default value.
        /// </summary>
        /// <param name="dbm">
        /// Parameter dbm is the object of DBManager Class.
        /// </param>
        public ReportSettings()
        {
            DefaultInitialization();
        }
        #endregion
        #region Private Methods Definition
        /// <summary>
        /// This method initilize respective default value to all entity fields.
        /// </summary>
        private void DefaultInitialization()
        {
            isDisplayLogo = false;
            logoAlignment = "Center";
            isDisplayAddress = false;
            addressAlignment = "Center";
            isPageNo = true;
            pageNoAlignment = "Right";
            prePrintedFlag = false;
            sizeOfPaper = "A4";
            orientation = null;
            marginLeft = 0.10;
            marginRight = 0.10;
            marginTop = 0.5;
            marginBottom = 0.5;

            ls = new List<ReportSettings>();
        }
        #endregion Private Methods Definition
    }
            
}
