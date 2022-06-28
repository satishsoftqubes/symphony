using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Data;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using SQT.FRAMEWORK.COMMON.Util;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.ReportFiles.GDI
{
    /// <summary>
    /// 
    /// </summary>
    
    public abstract partial class clsReportMaster
    {
       
        //protected PrintPreviewDialog objppDialog = new PrintPreviewDialog();
        //protected PrintDialog objprintDialog = new PrintDialog();
        public PrintDocument ThePrintDocument = new PrintDocument();

        protected GridView TheDataGrid;
        protected DataView TheDataView;
        protected ReportSettings objRptSet;
        protected Rectangle Rectbounds = new Rectangle();        
        protected Font GlobalFont;
        protected Font GlobalFontBold;
        protected Font HeadingFont;
        protected SolidBrush GrayBrush;
        protected SolidBrush BlackBrush;
        protected SolidBrush WhiteBrush;
        protected Pen TheLinePen;
        protected Point pnt;
        protected Rectangle Rectbounds2 = new Rectangle();
        protected StringFormat cellformat = new StringFormat();
        protected SizeF tmpSize = new SizeF();
        protected SizeF DataSize = new SizeF();
        protected Point pntDetail;
        protected RectangleF recf = new RectangleF(0, 0, 0, 0);
        protected Rectangle rec = new Rectangle(0, 0, 0, 0);
        protected RectangleF cellbounds = new RectangleF();
        protected Rectangle logobounds = new Rectangle();
        protected RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);
        protected int RowCount = 0;
        protected int PageNumber = 1;
        protected int PageRows = 0;
        protected const int kVerticalCellLeeway = 10;
        protected string logoAlignment = null;
        protected string addressAlignment = null;
        protected string pageNoAlignment = null;
        protected byte[] logoimg;
        protected string ProName = null;
        protected string Address = null;
        protected string City = null;
        protected string State = null;
        protected string Country = null;
        protected string Phone = null;
        protected string Fax = null;
        protected string Email = null;
        protected string MyURL = null;

        protected string nextcolumn;
        protected string ReportTitle = null;
        protected int PageWidth;
        protected int PageHeight;
        protected int TopMargin;
        protected int BottomMargin;
        protected int LeftMargin;
        protected int RightMargin;
        protected bool IsPrePrinted = false;
        protected int DetailTop;
        protected Graphics gt;
        public abstract void DrawHeader(Graphics g);
      
        public abstract bool DrawRows(Graphics g);

        private PaperSize myPaper;
        private string fontName;
        public float _FontSize = 9;
        public bool isForCancellation = false, isForInv = false;
        public string FontName
        {
            get { return fontName; }
            set
            {
                fontName = value;
                GlobalFontBold = new Font(FontName, _FontSize, FontStyle.Bold);
                GlobalFont = new Font(FontName, _FontSize, FontStyle.Regular);
                HeadingFont = new Font(fontName, 15, FontStyle.Bold);     }
        }

        public float FontSize
        {
            get {return _FontSize;}
            set
            {
                _FontSize = value;
                GlobalFontBold = new Font(FontName, _FontSize, FontStyle.Bold);
                GlobalFont = new Font(FontName, _FontSize, FontStyle.Regular);
                HeadingFont = new Font(fontName, 15, FontStyle.Bold);
            }
        }

        Property objProperty = PropertyBLL.GetByPrimaryKey(clsSession.PropertyID);

        private void CommanCode(bool isLandscape)
        {
            try
            {
                this.ThePrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ThePrintDocument_PrintPage);
                DoReportSettings();
                FontName = "Arial";
                GlobalFontBold = new Font(FontName, 9, FontStyle.Bold);
                GlobalFont = new Font(FontName, 9, FontStyle.Bold);
                HeadingFont = new Font(fontName, 15, FontStyle.Bold);
                GrayBrush = new SolidBrush(Color.Gray);
                BlackBrush = new SolidBrush(Color.Black);
                WhiteBrush = new SolidBrush(Color.White);                
                TheLinePen = new Pen(Color.Black, 1);
                
                if (isLandscape)
                    ThePrintDocument.DefaultPageSettings.Landscape = true;
                else
                    ThePrintDocument.DefaultPageSettings.Landscape = false;

                DetailTop = TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
                BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;
                LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left;
                RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right;

                if (!ThePrintDocument.DefaultPageSettings.Landscape)
                {
                    if (ThePrintDocument.PrinterSettings.PrinterName == "Default printer is not set.")
                    {
                        //A4 size
                        PageWidth = 827;
                        PageHeight = 1169;
                    }
                    else
                    {
                        PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                        PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
                    }
                }
                else
                {
                    if (ThePrintDocument.PrinterSettings.PrinterName == "Default printer is not set.")
                    {
                        PageHeight = 1169;
                        PageWidth = 827;
                    }
                    else
                    {
                        PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
                        PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public clsReportMaster(bool isLandscape, bool IsPrePrinted)
        {
            this.IsPrePrinted = IsPrePrinted;
            CommanCode(isLandscape);
        }

        public clsReportMaster(bool isLandscape, bool IsPrePrinted,PaperSize mypaper)
        {
            this.myPaper = mypaper;
            this.IsPrePrinted = IsPrePrinted;
            CommanCode(isLandscape);
        }

        public clsReportMaster(bool isLandscape)
        {
            this.IsPrePrinted = false;
            CommanCode(isLandscape);
        }
      
        public int DrawHotelInfo(Graphics g, string title, string Report)
        {
            DrawTopLogo4(g);
            return DrawTopInfoWithoutLogo4(g, title);
        }

        //This will take the values from ReportSettings table.
        protected void DoReportSettings()
        {
            try
            {
                objRptSet = new ReportSettings();
                this.ThePrintDocument.PrinterSettings.DefaultPageSettings.Margins.Left = Convert.ToInt32(objRptSet.MarginLeft * 100);
                this.ThePrintDocument.PrinterSettings.DefaultPageSettings.Margins.Right =  Convert.ToInt32(objRptSet.MarginRight * 100);
                this.ThePrintDocument.PrinterSettings.DefaultPageSettings.Margins.Top = Convert.ToInt32(objRptSet.MarginTop * 100);
                this.ThePrintDocument.PrinterSettings.DefaultPageSettings.Margins.Bottom = Convert.ToInt32(objRptSet.MarginBottom * 100);

                this.ThePrintDocument.DefaultPageSettings.Margins.Left = Convert.ToInt32(objRptSet.MarginLeft * 100);
                this.ThePrintDocument.DefaultPageSettings.Margins.Right =  Convert.ToInt32(objRptSet.MarginRight * 100);
                this.ThePrintDocument.DefaultPageSettings.Margins.Top =  Convert.ToInt32(objRptSet.MarginTop * 100);
                this.ThePrintDocument.DefaultPageSettings.Margins.Bottom = Convert.ToInt32(objRptSet.MarginBottom * 100);

                if (myPaper != null)
                {
                    this.ThePrintDocument.DefaultPageSettings.PaperSize = myPaper;
                    this.ThePrintDocument.PrinterSettings.DefaultPageSettings.PaperSize = ThePrintDocument.PrinterSettings.PaperSizes[0];
                }
                if (objRptSet.Orientation == "Portrait")
                    this.ThePrintDocument.DefaultPageSettings.Landscape = false;
                else
                    this.ThePrintDocument.DefaultPageSettings.Landscape = true;
                if (objRptSet.IsPageNo)
                    pageNoAlignment = objRptSet.PageNoAlignment;
                if (!objRptSet.PrePrintedFlag)
                {
                    if (objRptSet.IsDisplayLogo)
                    {
                        logoAlignment = objRptSet.LogoAlignment;
                        if (objRptSet.Logo != null)
                            logoimg = objRptSet.Logo;
                        else
                            logoimg = null;
                    }
                    ProName = "";
                    Address = "";
                    City = "";
                    State = "";
                    Country = "";
                    Phone = "";
                    Fax = "";
                    Email = "";
                    MyURL = "";
                    if (objRptSet.IsDisplayAddress)
                    {
                        Company objCmpData = CompanyBLL.GetByPrimaryKey(clsSession.CompanyID);
                        addressAlignment = objRptSet.AddressAlignment;
                        ProName = clsSession.CompanyName;

                        if (!objCmpData.PrimaryAdd1.Trim().Equals(""))
                            Address = objCmpData.PrimaryAdd1.Trim() + " ";
                        if (!objCmpData.PrimaryAdd2.Trim().Equals(""))
                            Address = Address + objCmpData.PrimaryAdd2.Trim();

                        if (!objCmpData.PrimaryCity.Trim().Equals(""))
                            State = objCmpData.PrimaryCity.Trim();
                        if (State.Length > 0)
                            State = State + ", ";
                        if (!objCmpData.PrimaryState.Trim().Equals(""))
                            State = State + objCmpData.PrimaryState.Trim();

                        if (!objCmpData.PrimaryZipCode.Trim().Equals(""))
                            Country = objCmpData.PrimaryZipCode.Trim();
                        if (Country.Length > 0)
                            Country = Country + ". ";
                        if (!objCmpData.PrimaryCountry.Trim().Equals(""))
                            Country = Country + objCmpData.PrimaryCountry.Trim();

                        if (!objCmpData.PrimaryPhone.Trim().Equals(""))
                            Phone = objCmpData.PrimaryPhone.Trim();

                        if (!objCmpData.PrimaryFax.Trim().Equals(""))
                            Fax = objCmpData.PrimaryFax.Trim();

                        if (!objCmpData.PrimaryEmail.Trim().Equals(""))
                            Email = objCmpData.PrimaryEmail.Trim();

                        if (!objCmpData.PrimaryUrl.Trim().Equals(""))
                            MyURL = objCmpData.PrimaryUrl.Trim();

                    }
                    if (objRptSet.IsPageNo)
                        pageNoAlignment = objRptSet.PageNoAlignment;

                    cellformat.Trimming = StringTrimming.EllipsisCharacter;
                    cellformat.FormatFlags = StringFormatFlags.LineLimit;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void DrawCardTopLogo(Graphics g,int StartX,int StartY)
        {
            DetailTop = TopMargin + 25;

            logobounds.Width = 130;
            logobounds.Height = 75;
            logobounds.Y = StartY;
            logobounds.X = StartX;

            if (logoAlignment != null && logoimg != null)
            {
                System.Drawing.Image objimg = Miscellaneous.GetImageFromByte(logoimg);                
                MyDrawImage(g, objimg, logobounds);                
            }
        }
        public int DrawCardTopInfoWithoutLogo(Graphics g, string title,int StartX,int StartY)
        {
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);
            HeaderBounds.X = 25;

            Font TempHeaderFont = new Font(new FontFamily("Verdana"), 7, FontStyle.Regular);

            string[] Titles = new string[9];
            Titles[0] = ProName;
            Titles[1] = Address;
            Titles[2] = State;
            Titles[3] = Country;
            Titles[4] = "Telephone: " + Phone;
            Titles[5] = "Fax: " + Fax;
            Titles[6] = "Email: " + Email;
            Titles[7] = "URL: " + MyURL;
            Titles[8] = title;

            HeaderBounds.Y = StartY + 80;

            HeaderBounds.Height = TempHeaderFont.Height;
            HeaderBounds.Width = 300;

            cellformat.Alignment = StringAlignment.Center;
            string AddressLine = Address + ", " + State.Split(',')[0] + ", " + Country.Split('.')[0];
            string Information = "Telephone: " + Phone;
            string EmailLine = "Email: " + Email;


            MyDrawString(g, AddressLine, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
            HeaderBounds.Y = HeaderBounds.Y + GlobalFont.Height;
            MyDrawString(g, Information, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
            HeaderBounds.Y = HeaderBounds.Y + GlobalFont.Height;
            MyDrawString(g, EmailLine, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
            return DetailTop;
        }

        private void DrawTopLogo(Graphics g)
        {
            DetailTop = TopMargin + 25;

            logobounds.Width = 100;
            logobounds.Height = 100;
            logobounds.Y = DetailTop;

            if (logoAlignment == "Left")
                logobounds.X = LeftMargin;
            else if (logoAlignment == "Right")
                logobounds.X = PageWidth -RightMargin - 100;
            else
                logobounds.X = (PageWidth -100 )/ 2 + LeftMargin/2 - RightMargin/2;

            if (logoAlignment != null && logoimg != null)
            {
                System.Drawing.Image objimg = Miscellaneous.GetImageFromByte(logoimg);               
                MyDrawImage(g, objimg, logobounds);
                DetailTop = DetailTop + 110;
            }
        }
        public int DrawTopInfoWithoutLogo(Graphics g, string title)
        {
            string[] Titles = new string[5];
            int iDT;
            Titles[0] = ProName;
            Titles[1] = Address;
            Titles[2] = State;
            Titles[3] = Country;
            Titles[4] = title;
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);
            HeaderBounds.X = LeftMargin;
            if (this.isForInv && logoAlignment != null && logoimg != null)
            {
                HeaderBounds.Y = iDT = DetailTop - 110;
                HeaderBounds.Width = PageWidth - LeftMargin - RightMargin;
            }
            else
            {
                HeaderBounds.Y = iDT = DetailTop;
                HeaderBounds.Width = PageWidth - LeftMargin - RightMargin;
            }
            HeaderBounds.Height = GlobalFontBold.Height;
            
            if (addressAlignment != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.isForInv && logoAlignment != null && logoimg != null)
                        HeaderBounds.Y = iDT;
                    else
                        HeaderBounds.Y = DetailTop;
                    if (addressAlignment == "Left")
                        cellformat.Alignment = StringAlignment.Near;
                    else if (addressAlignment == "Right")
                        cellformat.Alignment = StringAlignment.Far;
                    else
                        cellformat.Alignment = StringAlignment.Center;

                    if (Titles[i].Trim() != "")
                    {
                        MyDrawString(g, Titles[i].Trim(), GlobalFontBold, BlackBrush, HeaderBounds, cellformat);
                        if (i == 3)
                        {
                            iDT = iDT + +GlobalFontBold.Height + 38;
                            DetailTop = DetailTop + GlobalFontBold.Height + 20;
                        }
                        else
                        {
                            iDT = iDT + +GlobalFontBold.Height + 4;
                            DetailTop = DetailTop + GlobalFontBold.Height + 4;
                        }
                    }
                }
            }
            if (this.isForInv && logoAlignment != null && logoimg != null)
                HeaderBounds.Y = iDT;
            else
                HeaderBounds.Y = DetailTop;
            cellformat.Alignment = StringAlignment.Center;
            MyDrawString(g, Titles[4].Trim(), GlobalFontBold, BlackBrush, HeaderBounds, cellformat);
            DetailTop = DetailTop + GlobalFontBold.Height + 4;
            DetailTop = DetailTop + 4;
            if (this.isForInv && logoAlignment != null && logoimg != null)
            {
                iDT = iDT + GlobalFontBold.Height + 4;
                iDT = iDT + 4;
                return iDT;
            }
            else
                return DetailTop;
        }
        private void DrawTopLogo4(Graphics g)
        {
            //DetailTop = TopMargin + 10;
            DetailTop = TopMargin + 4;

            logobounds.Width = 225;
            logobounds.Height = 150;
            logobounds.Y = DetailTop;

            if (logoAlignment == "Left")
                logobounds.X = LeftMargin;
            else if (logoAlignment == "Right")
                logobounds.X = PageWidth - RightMargin - 225;
            else
                logobounds.X = (PageWidth - 225) / 2 + LeftMargin / 2 - RightMargin / 2;

            if (logoAlignment != null && logoimg != null)
            {
                System.Drawing.Image objimg = Miscellaneous.GetImageFromByte(logoimg);                
                MyDrawImage(g, objimg, logobounds);
                DetailTop = DetailTop + 120;            
            }           
        }


        public int DrawTopInfoWithoutLogo4(Graphics g, string title)
        {
            DrawTopLogo4(g);

            Font TempHeaderFontURL = new Font(new FontFamily("Verdana"), 8, FontStyle.Bold);

            g.DrawRectangle(Pens.Black, 300, 170, 238, 20);
            g.FillRectangle(Brushes.Black, 300, 170, 238, 20);
            logobounds.Height = DetailTop + 10;
            logobounds.Y = 173;
            cellformat.Alignment = StringAlignment.Center;

            g.DrawString(objProperty.PrimaryEmail, TempHeaderFontURL, Brushes.White, logobounds, cellformat);

            Font TempHeaderFont = new Font(new FontFamily("Verdana"), 9, FontStyle.Regular);         

            string[] Titles = new string[9];
            Titles[0] = ProName;
            Titles[1] = Address;
            Titles[2] = State;
            Titles[3] = Country;
            Titles[4] = "Telephone: " + Phone;
            Titles[5] = "Fax: " + Fax;
            Titles[6] = "Email: " + Email;
            Titles[7] = "URL: " + MyURL;
            Titles[8] = title;
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);

            HeaderBounds.X = LeftMargin;

            HeaderBounds.Y = DetailTop + 53;

            HeaderBounds.Height = TempHeaderFont.Height;
            HeaderBounds.Width = PageWidth - LeftMargin - RightMargin;

            cellformat.Alignment = StringAlignment.Center;
            string AddressLine = Address + ", " + State.Split(',')[0] + ", " + Country.Split('.')[0];
            string Information = "Telephone: " + Phone + " Fax:" + Fax;
            string EmailLine = "Email: " + Email;

            HeaderBounds.Y = DetailTop + 53;

            MyDrawString(g, AddressLine, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
            HeaderBounds.Y = HeaderBounds.Y + GlobalFont.Height;
            MyDrawString(g, Information, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
            HeaderBounds.Y = HeaderBounds.Y + GlobalFont.Height;
            MyDrawString(g, EmailLine, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
        
            HeaderBounds.Y = HeaderBounds.Y + DetailTop - 100;
            cellformat.Alignment = StringAlignment.Center;
            MyDrawString(g, Titles[8].Trim(), GlobalFontBold, BlackBrush, HeaderBounds, cellformat);
            DetailTop = DetailTop + GlobalFontBold.Height + 4;
            DetailTop = DetailTop - 10;
            return DetailTop;            
        }
        public int DrawTopInfoWithoutLogo5(Graphics g, string title)
        {
            DrawTopLogo4(g);

            Font TempHeaderFontURL = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);

            g.DrawRectangle(Pens.Black, 300, 170, 238, 20);
            g.FillRectangle(Brushes.Black, 300, 170, 238, 20);
            logobounds.Height = DetailTop + 10;
            logobounds.Y = 173;
            cellformat.Alignment = StringAlignment.Center;

            g.DrawString("www.holthotel.uk", TempHeaderFontURL, Brushes.White, logobounds, cellformat);

            Font TempHeaderFont = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);

            string[] Titles = new string[9];
            Titles[0] = ProName;
            Titles[1] = Address;
            Titles[2] = State;
            Titles[3] = Country;
            Titles[4] = "Telephone: " + Phone;// +", " + "Fax: " + Fax;
            Titles[5] = "Fax: " + Fax;
            Titles[6] = "Email: " + Email;
            Titles[7] = "URL: " + MyURL;
            Titles[8] = title;
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);

            HeaderBounds.X = LeftMargin;
          
            HeaderBounds.Y = DetailTop + 53;

            HeaderBounds.Height = TempHeaderFont.Height;
            HeaderBounds.Width = PageWidth - LeftMargin - RightMargin;

            cellformat.Alignment = StringAlignment.Center;
            string AddressLine = Address + ", " + State.Split(',')[0] + ", " + Country.Split('.')[0];
            string Information = "Telephone: " + Phone + " Fax:" + Fax;
            string EmailLine = "Email: " + Email;
  
            HeaderBounds.Y = DetailTop + 53;

            MyDrawString(g, AddressLine, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
            HeaderBounds.Y = HeaderBounds.Y + GlobalFont.Height;
            MyDrawString(g, Information, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
            HeaderBounds.Y = HeaderBounds.Y + GlobalFont.Height;
            MyDrawString(g, EmailLine, TempHeaderFont, BlackBrush, HeaderBounds, cellformat);
           
            Font TempInvoiceHeaderFont = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);
            HeaderBounds.Y = HeaderBounds.Y + DetailTop - 105;
            HeaderBounds.Height = HeaderBounds.Height + 13;
            cellformat.Alignment = StringAlignment.Center;
            MyDrawString(g, Titles[8].Trim(), TempInvoiceHeaderFont, BlackBrush, HeaderBounds, cellformat);//GlobalFont
            DetailTop = DetailTop + TempInvoiceHeaderFont.Height + 4;
            DetailTop = DetailTop - 10;
            return DetailTop;
        }
        public int DrawTopInfoWithoutLogo2(Graphics g, string title)
        {
            string[] Titles = new string[9];
            Titles[0] = ProName;
            Titles[1] = Address;
            Titles[2] = State;
            Titles[3] = Country;
            Titles[4] = "Phone: " + Phone;
            Titles[5] = "Fax: " + Fax;
            Titles[6] = "Email: " + Email;
            Titles[7] = "URL: " + MyURL;
            Titles[8] = title;
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);
            HeaderBounds.X = LeftMargin;
            HeaderBounds.Y = DetailTop;
            HeaderBounds.Height = GlobalFontBold.Height;
            HeaderBounds.Width = PageWidth - LeftMargin-RightMargin;
            if (addressAlignment != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    HeaderBounds.Y = DetailTop;
                    if (addressAlignment == "Left")
                        cellformat.Alignment = StringAlignment.Near;
                    else if (addressAlignment == "Right")
                        cellformat.Alignment = StringAlignment.Far;
                    else
                        cellformat.Alignment = StringAlignment.Center;
                    if (Titles[i].Trim() != "")
                    {
                        if(i==0 || i==4)
                            MyDrawString(g, Titles[i].Trim(), GlobalFontBold, BlackBrush, HeaderBounds, cellformat);
                        else
                            MyDrawString(g, Titles[i].Trim(), GlobalFont, BlackBrush, HeaderBounds, cellformat);                       
                        if (i == 7)
                            DetailTop = DetailTop + GlobalFontBold.Height + 20;
                        else
                            DetailTop = DetailTop + GlobalFontBold.Height + 4;
                    }
                }
            }
            HeaderBounds.Y = DetailTop;
            cellformat.Alignment = StringAlignment.Center;
            MyDrawString(g, Titles[8].Trim(), GlobalFontBold, BlackBrush, HeaderBounds, cellformat);
            DetailTop = DetailTop + GlobalFontBold.Height + 4;
            DetailTop = DetailTop + 4;
            return DetailTop;
        }

        public int DrawTopInfoWithoutLogo3(Graphics g, string title)
        {
            cellformat = new StringFormat();
            cellformat.Trimming = StringTrimming.EllipsisCharacter;
            cellformat.FormatFlags = StringFormatFlags.LineLimit;
            DrawTopLogo(g);
            string[] Titles = new string[7];
            Titles[0] = ProName;
            Titles[1] = Address;
            Titles[2] = State;
            Titles[3] = Country;
            Titles[4] = "Phone: " + Phone;
            Titles[5] = "Email: " + Email;
            Titles[6] = title;
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);
            HeaderBounds.X = LeftMargin;
            HeaderBounds.Y = DetailTop;
            HeaderBounds.Height = GlobalFontBold.Height + 3;
            HeaderBounds.Width = PageWidth - 20;
            if (addressAlignment != null)
            {
                for (int i = 0; i < 6; i++)
                {
                    HeaderBounds.Y = DetailTop;
                    if (addressAlignment == "Left")
                        cellformat.Alignment = StringAlignment.Near;
                    else if (addressAlignment == "Right")
                        cellformat.Alignment = StringAlignment.Far;
                    else
                        cellformat.Alignment = StringAlignment.Center;
                    if (Titles[i].Trim() != "")
                    {
                        tmpSize = g.MeasureString(Titles[i].Trim(), GlobalFontBold);
                        if (tmpSize.Width > (PageWidth - 30))
                        {
                            int rmd = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tmpSize.Width / (PageWidth - 20))));
                            HeaderBounds.Height = GlobalFontBold.Height * rmd + 4;
                        }
                        else
                        {
                            HeaderBounds.Height = GlobalFontBold.Height + 4;
                        }
                        MyDrawString(g, Titles[i].Trim(), GlobalFontBold, BlackBrush, HeaderBounds, cellformat);
                        if (i == 5)
                            DetailTop = DetailTop + Convert.ToInt32(HeaderBounds.Height) + 6;
                        else
                            DetailTop = DetailTop + Convert.ToInt32(HeaderBounds.Height);
                    }
                }
            }
            HeaderBounds.X = 0;
            HeaderBounds.Y = DetailTop;
            HeaderBounds.Width = PageWidth;
            cellformat.Alignment = StringAlignment.Center;
            MyDrawString(g, Titles[6].Trim(), GlobalFontBold, BlackBrush, HeaderBounds, cellformat);
            DetailTop = DetailTop + GlobalFontBold.Height + 4;
            return DetailTop;
        }

        public int DrawTopInfo(Graphics g,string title)
        {
            DetailTop = 50;
            string[] Titles = new string[2];
            Titles[0] = clsSession.PropertyName;
            Titles[1] = title;
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);
            HeaderBounds.X = 50;
            HeaderBounds.Y = DetailTop;
            HeaderBounds.Height = HeadingFont.Height;
            HeaderBounds.Width = PageWidth - 110;

            if (Titles[0].Trim() != "")
            {
                Font titleFont = new Font(GlobalFontBold.FontFamily, 14, FontStyle.Bold);
                cellformat.Alignment = StringAlignment.Center;
                MyDrawString(g, Titles[0].Trim(), titleFont, BlackBrush, HeaderBounds, cellformat);
                DetailTop = DetailTop + HeadingFont.Height + 30;
            }

            Font newFont = new Font(GlobalFontBold.FontFamily, 10, FontStyle.Bold);
            HeaderBounds.Y = DetailTop;
            cellformat.Alignment = StringAlignment.Center;
            MyDrawString(g, Titles[1].Trim(), newFont, BlackBrush, HeaderBounds, cellformat);
            DetailTop = DetailTop + GlobalFontBold.Height + 50;
            return DetailTop;
        }

        public int DrawTopInfo(Graphics g, string title, bool forReceipt)
        {
            DetailTop = 50;
            string[] Titles = new string[2];
            Titles[0] = clsSession.PropertyName.Trim();
            Titles[1] = title;
            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);
            HeaderBounds.X = 50;
            HeaderBounds.Y = DetailTop;
            HeaderBounds.Height = HeadingFont.Height;
            HeaderBounds.Width = PageWidth - 110;

            if (Titles[0].Trim() != "")
            {
                cellformat.Alignment = StringAlignment.Near;
                MyDrawString(g, Titles[0].Trim(), HeadingFont, BlackBrush, HeaderBounds, cellformat);
                DetailTop = DetailTop + HeadingFont.Height + 15;
            }

            Font newFont = new Font(GlobalFontBold.FontFamily, 9, FontStyle.Bold);
            HeaderBounds.Y = DetailTop;
            cellformat.Alignment = StringAlignment.Center;
            MyDrawString(g, Titles[1], newFont, BlackBrush, HeaderBounds, cellformat);
            DetailTop = DetailTop + GlobalFontBold.Height + 14;
            return DetailTop;
        }
       
        public int DrawCardHotelInfo(Graphics g, string title,int StartX,int StartY)
        {
            DrawCardTopLogo(g,StartX,StartY);
            return DrawCardTopInfoWithoutLogo(g, title,StartX,StartY);
        }
        public int DrawHotelInfo(Graphics g, string title)
        {
            DrawTopLogo(g);
            return DrawTopInfoWithoutLogo(g, title);
        }

        public int DrawHotelInfo(Graphics g, string title, bool isInv)
        {
            this.isForInv = isInv; 
            DrawTopLogo(g);
            return DrawTopInfoWithoutLogo(g, title);
        }
        public int DrawHotelInfo4(Graphics g, string title, bool isInv)
        {
            this.isForInv = isInv;
            DrawTopLogo(g);
            return DrawTopInfoWithoutLogo2(g, title);
        }

        public int DrawHotelInfo2(Graphics g, string title)
        {
            DrawTopLogo(g);
            return DrawTopInfoWithoutLogo2(g, title);
        }
        public int DrawHotelInfo3(Graphics g, string title)
        {
            DrawTopLogo(g);
            return DrawTopInfoWithoutLogo3(g, title);
        }

        public void MyDrawImage(Graphics myg, System.Drawing.Image img, Rectangle reclogo)
        {
            if (!IsPrePrinted)
                myg.DrawImage(img, reclogo);
        }

        public void MyDrawString(Graphics myg, string mystr, Font myFont, SolidBrush myBlackBrush, Rectangle myrec, StringFormat mycellformat)
        {
            if (!IsPrePrinted)
                myg.DrawString(mystr.ToString(), myFont, myBlackBrush, myrec, mycellformat);
        }

        public void MyDrawString(Graphics myg, string mystr, Font myFont, SolidBrush myBlackBrush, Point mypoint, StringFormat mycellformat)
        {
            if (!IsPrePrinted)
                myg.DrawString(mystr.ToString(), myFont, myBlackBrush, mypoint, mycellformat);
        }
        public void MyDrawString(Graphics myg, string mystr, Font myFont, SolidBrush myBlackBrush, RectangleF myrecf, StringFormat mycellformat)
        {
            if (!IsPrePrinted)
                myg.DrawString(mystr.ToString(), myFont, myBlackBrush, myrecf, mycellformat);
        }

        //Signature
        public void DrawSignature(Graphics g, int leftmargin, int detailtop)
        {
            cellbounds.X = leftmargin;
            cellbounds.Y = detailtop;
            cellbounds.Width = 100;
            cellbounds.Height = GlobalFontBold.Height + 4;
            cellformat.Alignment = StringAlignment.Near;
            g.DrawString("Signature : ", GlobalFontBold, BlackBrush, cellbounds, cellformat);
            g.DrawLine(TheLinePen, cellbounds.X + cellbounds.Width - 15, cellbounds.Y + GlobalFontBold.Height - 3, cellbounds.X + cellbounds.Width + 130, cellbounds.Y + GlobalFontBold.Height - 3);
        }

        public void DrawSignature(Graphics g)
        {
            cellbounds.X = LeftMargin;
            cellbounds.Y = PageHeight - BottomMargin - 85;
            cellbounds.Width = 100;
            cellbounds.Height = GlobalFontBold.Height + 4;
            cellformat.Alignment = StringAlignment.Near;
            g.DrawString("Signature : ", GlobalFontBold, BlackBrush, cellbounds, cellformat);
            g.DrawLine(TheLinePen, cellbounds.X + cellbounds.Width - 15, cellbounds.Y + GlobalFontBold.Height - 3, cellbounds.X + cellbounds.Width + 150, cellbounds.Y + GlobalFontBold.Height - 3);
        }       

        public void DrawPrinted(Graphics g)
        {
            cellbounds.X = this.LeftMargin;           
            cellbounds.Width = PageWidth-LeftMargin - RightMargin ;
            cellbounds.Y = PageHeight - BottomMargin - 35;
            cellbounds.Height = GlobalFontBold.Height + 4;
           
            cellformat.Alignment = StringAlignment.Near;
            g.DrawString("Printed : " + DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat), GlobalFont, BlackBrush, cellbounds, cellformat);
            
            cellformat.Alignment = StringAlignment.Far;
            string nam = clsSession.UserName;
            g.DrawString("Desk Clerk : " + nam, GlobalFont, BlackBrush, cellbounds, cellformat);
        }
     
        public void DrawAbbrevations(Graphics g)
        {
            cellbounds.X = this.LeftMargin;
            cellbounds.Width = PageWidth - LeftMargin - RightMargin-50;
            cellbounds.Y = PageHeight - BottomMargin - 60;
            cellbounds.Height = GlobalFontBold.Height + 4;

            string Abbrevations = "RESD = Reserved    VCT = Vacant    BLKD = Blocked    Occ = Occupancy    ARR = Average Room Revenue    ENQ = Enquiry    UnConf = Unconfirmed";           
            cellformat.Alignment = StringAlignment.Near;
            g.DrawString(Abbrevations, GlobalFont, BlackBrush, cellbounds, cellformat);
        }

        public void DrawPrinted(Graphics g, int ID)
        {
            cellbounds.X = this.LeftMargin;
            cellbounds.Width = PageWidth - LeftMargin - RightMargin;
            cellbounds.Y = PageHeight - BottomMargin - 35;
            cellbounds.Height = GlobalFontBold.Height + 4;
            
            cellformat.Alignment = StringAlignment.Near;
            g.DrawString(DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat), GlobalFont, BlackBrush, cellbounds, cellformat);          
        }

        public void DrawPrinted(Graphics g, bool RemoveDeskClerk)
        {
            cellbounds.X = this.LeftMargin;
            cellbounds.Width = PageWidth - LeftMargin - RightMargin;
            cellbounds.Y = PageHeight - BottomMargin - 35;
            cellbounds.Height = GlobalFontBold.Height + 4;
            
            cellformat.Alignment = StringAlignment.Near;
            g.DrawString("Printed : " + DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat), GlobalFont, BlackBrush, cellbounds, cellformat);
        }

        public void DrawPageNumberAuto(Graphics g, int leftmargin, int detailtop, int width)
        {
            cellbounds.X = leftmargin;
            cellbounds.Width = width;
            cellbounds.Y = detailtop+30;
            cellbounds.Height = GlobalFontBold.Height + 4;
            if (pageNoAlignment == "Left")
                cellformat.Alignment = StringAlignment.Near;
            else if (pageNoAlignment == "Right")
                cellformat.Alignment = StringAlignment.Far;
            else
                cellformat.Alignment = StringAlignment.Center;
            if(objRptSet.IsPageNo)
                g.DrawString(PageNumber++.ToString(), GlobalFont, BlackBrush, cellbounds, cellformat);
        }

        public void DrawPageNumber(Graphics g, int leftmargin, int detailtop, int width)
        {
            cellbounds.X = leftmargin-20;
            cellbounds.Width = width;
            cellbounds.Y = detailtop+30;
            cellbounds.Height = GlobalFontBold.Height + 4;
            if (pageNoAlignment == "Left")
                cellformat.Alignment = StringAlignment.Near;
            else if (pageNoAlignment == "Right")
                cellformat.Alignment = StringAlignment.Far;
            else
                cellformat.Alignment = StringAlignment.Center;
            if (objRptSet.IsPageNo)
            g.DrawString(PageNumber.ToString(), GlobalFont, BlackBrush, cellbounds, cellformat);
        }

        public void DrawPageNumber(Graphics g)
        {
            cellbounds.X = this.LeftMargin+10;
            cellbounds.Width = PageWidth - LeftMargin - RightMargin - 20;
            cellbounds.Y = PageHeight - BottomMargin - 20;
            cellbounds.Height = GlobalFontBold.Height + 4;
            if (pageNoAlignment == "Left")
                cellformat.Alignment = StringAlignment.Near;
            else if (pageNoAlignment == "Right")
                cellformat.Alignment = StringAlignment.Far;
            else
                cellformat.Alignment = StringAlignment.Center;

            if (objRptSet.IsPageNo)
            g.DrawString(PageNumber.ToString(), GlobalFont, BlackBrush, cellbounds, cellformat);
        }

        public void ShowReport()
        {
            try
            {
                //objppDialog = new PrintPreviewDialog();
                //this.objppDialog.Document = this.ThePrintDocument;
                //this.PageNumber = 1;
                //this.RowCount = 0;
                //this.objppDialog.Width = Screen.PrimaryScreen.WorkingArea.Width;
                //this.objppDialog.Height = Screen.PrimaryScreen.WorkingArea.Height;
                //this.objppDialog.WindowState = FormWindowState.Maximized;
                //this.objppDialog.ShowDialog();
                //this.objppDialog.Document.ToString();
            }
            catch (Exception ex)
            {
                
            }
        }

        public string EMailReport(string _toEmail, string _toCCEmail, string _Subject, string _Body, string _ReportName)
        {
            try
            {
                ReportFunctions objrpt = new ReportFunctions();
                PrintControllerFormat[] formats = PrintControllerFormat.Formats;
                Guid gid = new Guid("b96b3cae-0728-11d3-9d7b-0000f81ef32e");
                ImageFormat format1 = new ImageFormat(gid);
                foreach (PrintControllerFormat format in formats)
                {
                    if (format.Name == "Jpeg")
                        format1 = format.Format;
                }
                string strCurrDir = System.Environment.CurrentDirectory + "\\ReportImg\\";
                string path = "Report" + DateTime.Now.ToString().Replace('/', '_').Replace(':', '_').Replace(' ', '_');
                PrintController controller = new PrintControllerFile(format1, (float)1.0, 100, strCurrDir + path + "\\", _ReportName);
                //ThePrintDocument.PrintController = new PrintControllerWithStatusDialog(controller, "Sending Email");
                ThePrintDocument.Print();
                DirectoryInfo df = new DirectoryInfo(strCurrDir + path);
                FileInfo[] flinfo = df.GetFiles();
                string str = "";
                
                if (!isForCancellation)
                    str = objrpt.SendEmailMessage(objProperty.PrimaryEmail, _toEmail, _toCCEmail, _Subject, _Body, flinfo);
                else
                {
                    flinfo = null;
                    str = objrpt.SendEmailMessage(objProperty.PrimaryEmail, _toEmail, _toCCEmail, _Subject, _Body, flinfo);
                }
               
                return str;
            }
            catch (SmtpException smtpex)
            {
                throw smtpex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PrintReport()
        {
            try
            {
                //objprintDialog = new PrintDialog();
                this.PageNumber = 1;
                this.RowCount = 0;
                //if (objprintDialog.ShowDialog() == DialogResult.OK)
                //{
                //    ThePrintDocument.PrinterSettings.PrinterName = objprintDialog.PrinterSettings.PrinterName;
                    ThePrintDocument.Print();
                //}
            }
            catch (Exception ex)
            {
               
            }
        }

        public void PrintReportWithoutDlg()
        {
            try
            {
                //objprintDialog = new PrintDialog();
                this.PageNumber = 1;
                this.RowCount = 0;
                ThePrintDocument.Print();
            }
            catch (Exception ex)
            {             
            }
        }
        
        protected virtual void ThePrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
               // this.objppDialog.PrintPreviewControl.Zoom = 1;
                Graphics g = null;
                g = e.Graphics;
                bool more = this.DrawDataGrid(g);
                if (more == true)
                {
                    e.HasMorePages = true;
                    this.PageNumber++;
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        public bool DrawDataGrid(Graphics g)
        {
            try
            {
                DrawHeader(g);
                bool bContinue = DrawRows(g);
                return bContinue;
            }
            catch (Exception ex)
            {                
                return false;
            }
        }

        public void DrawReportFooter(Graphics g, int leftmargin, int detailtop, int width)
        {
            int footTop = PageHeight - BottomMargin - 65;
            Font fntFotr = new Font(FontName, 8, FontStyle.Regular);
            cellformat.Alignment = StringAlignment.Near;
            Rectangle logophone = new Rectangle();
            logophone.Width = 17;
            logophone.Height = 17;
            if (!objRptSet.PrePrintedFlag)
            {
                g.DrawLine(TheLinePen, LeftMargin + 10, footTop, PageWidth - RightMargin - 10, footTop);
                footTop += 2;
                System.Drawing.Image objphoneimg = null;
                logophone.X = LeftMargin + 10;
                logophone.Y = footTop - 2;
                g.DrawImage(objphoneimg, logophone);

                pnt = new Point(LeftMargin + 28, footTop);
                g.DrawString(objProperty.PrimaryEmail.Trim(), fntFotr, GrayBrush, pnt, cellformat);

                tmpSize = g.MeasureString(objProperty.PrimaryEmail.Trim(), fntFotr);


                System.Drawing.Image objemlimg = null;
                logophone.X = PageWidth - RightMargin - Convert.ToInt32(tmpSize.Width) - 40;
                logophone.Y = footTop - 2;
                g.DrawImage(objemlimg, logophone);

                pnt = new Point(PageWidth - RightMargin - Convert.ToInt32(tmpSize.Width) - 20, footTop);
                g.DrawString(objProperty.PrimaryEmail.Trim(), fntFotr, GrayBrush, pnt, cellformat);

                footTop += 18;
                System.Drawing.Image objfaximg = null;
                logophone.X = LeftMargin + 10;
                logophone.Y = footTop - 2;
                g.DrawImage(objfaximg, logophone);
                pnt = new Point(LeftMargin + 28, footTop);
                g.DrawString(objProperty.PrimaryFax.Trim(), fntFotr, GrayBrush, pnt, cellformat);
            }
        }
        
        public void DrawCLSReportFooter(Graphics g, int leftmargin, int detailtop, int width)
        {
            int footTop = PageHeight - BottomMargin - 95;
            Font fntFotr = new Font(FontName, 7, FontStyle.Regular);
            cellformat.Alignment = StringAlignment.Near;
            Rectangle logophone = new Rectangle();
            logophone.Width = 17;
            logophone.Height = 17;
            if (!objRptSet.PrePrintedFlag)
            {               
                g.DrawLine(TheLinePen, LeftMargin + 10, footTop - 22, PageWidth - RightMargin - 20, footTop - 22);
                footTop += 2;
               
                pnt = new Point(LeftMargin + 12, footTop - 20);
              
                string s = " * BUSINESS BREAKFAST * TRADITIONAL AFTERNOON TEAS * CONFERENCES * WEDDINGS * PRIVATE DINING * SUNDAY LUNCHEONS";
                g.DrawString(s, fntFotr, GrayBrush, pnt, cellformat);
               
                pnt = new Point(PageWidth / 2 - 80, footTop + 10);               
                g.DrawString("Please leave your keys with Reception", fntFotr, GrayBrush, pnt, cellformat);
               
                cellbounds.X = LeftMargin + 500;                
                cellbounds.Y = PageHeight - BottomMargin - 85;
                cellbounds.Width = 100;
                cellbounds.Height = GlobalFontBold.Height + 4;
                cellformat.Alignment = StringAlignment.Near;              
                pnt = new Point(PageWidth / 2 + 150, footTop + 10);            
                g.DrawString("Signature : ", fntFotr, GrayBrush, pnt, cellformat);

                g.DrawLine(TheLinePen, cellbounds.X + cellbounds.Width - 15, cellbounds.Y + GlobalFontBold.Height - 3, cellbounds.X + cellbounds.Width + 138, cellbounds.Y + GlobalFontBold.Height - 3);

                Font fntclsFotr = new Font(FontName, 6, FontStyle.Regular);               
                pnt = new Point(PageWidth / 2 - 350, footTop + 40);
                string s1 = "Payment Terms are strictly 14 days. A surcharge of 2% per month will be added to all overdue accounts. VAT No. 704 7313 58";
                g.DrawString(s1, fntclsFotr, GrayBrush, pnt, cellformat);

                pnt = new Point(PageWidth / 2 + 230, footTop + 40);
              
                g.DrawString("(Tax Point is last date printed)", fntFotr, GrayBrush, pnt, cellformat);
             
                pnt = new Point(PageWidth / 2 - 240, footTop + 56);               
                string s2 = "Registration Name: Mountweb 2000 Limited, 100 Queens Gate,London SW7 5AG. Registered in England No. 3501644";
                g.DrawString(s2, fntclsFotr, GrayBrush, pnt, cellformat);
            }
        }        
    }
}
