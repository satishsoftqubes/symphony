using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace SQT.Symphony.UI.Web.FrontDesk.ReportFiles.GDI
{
    public partial class PrintReportGeneral : clsReportMaster
    {
        private SizeF ColSize;
        private SizeF RowSize;
        int TotalCol;
        List<clsTableInfo> objList;
        ArrayList arlGroup;
        string Title;
        private bool IsColor = false;
        private SolidBrush BackBrush;
        private Rectangle cellbounds2;
        public bool isDeskClerkRemove = false;
        private bool IsTotal = false;

        public PrintReportGeneral(GridView dgv, bool isLandscape, List<clsTableInfo> ls, ArrayList arlgrp, string title)
            : base(isLandscape)
        {
            try
            {
                TheDataGrid = dgv;
                this.objList = ls;
                this.arlGroup = arlgrp;
                this.Title = title;
                TotalCol = objList.Count;
                RowSize = new SizeF(0, GlobalFont.Height + 2);
                foreach (clsTableInfo obj in objList)
                    RowSize.Width += obj.ColWidth + 6;

            }
            catch (Exception ex)
            {                
            }
        }

        public PrintReportGeneral(GridView dgv, bool isLandscape, List<clsTableInfo> ls, ArrayList arlgrp, string title,bool _IsColor)
            : base(isLandscape)
        {
            try
            {
                TheDataGrid = dgv;
                this.objList = ls;
                this.arlGroup = arlgrp;
                this.Title = title;
                this.IsColor = _IsColor;
                TotalCol = objList.Count;
                RowSize = new SizeF(0, (float)dgv.RowStyle.Height.Value);
                foreach (clsTableInfo obj in objList)
                    RowSize.Width += obj.ColWidth + 6;
            }
            catch (Exception ex)
            {
                
            }
        }

        public PrintReportGeneral(GridView dgv, bool isLandscape, List<clsTableInfo> ls, ArrayList arlgrp, string title,bool _IsColor, bool _IsTotal)
            : base(isLandscape)
        {
            try
            {
                TheDataGrid = dgv;
                this.objList = ls;
                this.arlGroup = arlgrp;
                this.Title = title;
                this.IsColor = _IsColor;
                this.IsTotal = _IsTotal;
                TotalCol = objList.Count;
                RowSize = new SizeF(0,(float) dgv.Rows[0].Height.Value);
                foreach (clsTableInfo obj in objList)
                    RowSize.Width += obj.ColWidth + 6;
            }
            catch (Exception ex)
            {               
            }
        }

        public override void DrawHeader(Graphics g)
        {
            RightMargin = LeftMargin = 50;
            DetailTop = TopMargin;
            DetailTop = DrawTopInfo(g, this.Title);
            if (!isDeskClerkRemove)
                DrawPrinted(g);
            else
                DrawPrinted(g, true);
            DrawPageNumber(g);
            DrawColumnHeader(g);
        }

        public void DrawColumnHeader(Graphics g)
        {
            // draw the table header
            int initialRowCount = RowCount;         
            int startxposition = LeftMargin;
            rec.X = LeftMargin;
            rec.Y = DetailTop;
            rec.Height = Convert.ToInt32(RowSize.Height);
            rec.Width = Convert.ToInt32(RowSize.Width);
            BackBrush = new SolidBrush(TheDataGrid.HeaderStyle.BackColor);

            int tmptop = DetailTop;
            if(IsColor)
                tmptop += 6;

            for (int k = 0; k < TotalCol; k++)
            {
                ColSize = new SizeF(objList[k].ColWidth, RowSize.Height);
                if (IsColor)
                {
                    cellbounds2 = new Rectangle(startxposition + 1, DetailTop, Convert.ToInt32(ColSize.Width), Convert.ToInt32(ColSize.Height));
                    g.FillRectangle(BackBrush, cellbounds2);
                    g.DrawRectangle(TheLinePen, cellbounds2);
                    cellformat.Alignment = StringAlignment.Center;
                    BlackBrush = new SolidBrush(TheDataGrid.HeaderStyle.ForeColor);
                  
                }
                else
                {
                    cellformat.Alignment = objList[k].ColAllign;
                    BlackBrush = new SolidBrush(Color.Black);
                }
                nextcolumn = objList[k].ColTitle;
                cellbounds = new RectangleF(startxposition + 1,
                                                       tmptop,
                                                       ColSize.Width,
                                                       ColSize.Height);

                g.DrawString(nextcolumn, GlobalFontBold, BlackBrush, cellbounds, cellformat);
                startxposition = startxposition + Convert.ToInt32(ColSize.Width) + (IsColor ? 0 : 5);
            }
            DetailTop = DetailTop + Convert.ToInt32(RowSize.Height);
            if(!IsColor)
            g.DrawLine(TheLinePen, rec.X, DetailTop, startxposition, DetailTop);
        }

        public override bool DrawRows(Graphics g)
        {
            try
            {
                BlackBrush = new SolidBrush(Color.Black);
                int initialRowCount = RowCount;
                if(!IsColor)
                    DetailTop = DetailTop + 5;
                rec.X = LeftMargin;
                rec.Y = DetailTop;
                rec.Height = Convert.ToInt32(RowSize.Height);
                rec.Width = Convert.ToInt32(RowSize.Width);
                string[] tmp = null;
                if (arlGroup != null && arlGroup.Count > 0)
                {
                    tmp = new string[arlGroup.Count];
                    for (int i = 0; i < arlGroup.Count; i++)
                    {
                        tmp[i] = TheDataGrid.DataKeys[RowCount][objList[i].ColName].ToString();
                        g.DrawString(tmp[i], i == 0 ? GlobalFontBold : GlobalFont, BlackBrush, rec, cellformat);
                        DetailTop = rec.Y + rec.Height;
                    }
                }

                RowSize = new SizeF(0,(float) TheDataGrid.RowStyle.Height.Value);
                foreach (clsTableInfo obj in objList)
                    RowSize.Width += obj.ColWidth + 6;
                int tmptop = 0;
                if (IsColor)
                    tmptop = 3;
                int startxposition;
                // draw the rows of the table
                for (int i = initialRowCount; i < TheDataGrid.Rows.Count; i++)
                {
                    startxposition = LeftMargin;
                    rec.Y = DetailTop;

                    if (DetailTop >= PageHeight - BottomMargin - 85)
                        return true;
                    if (arlGroup != null && arlGroup.Count > 0)
                    {
                        for (int k = 0; k < arlGroup.Count; k++)
                        {
                            if (TheDataGrid.DataKeys[i][objList[k].ColName].ToString() != tmp[k])
                            {
                                rec.Y = DetailTop + (k == 0 ? rec.Height : 0);
                                if (rec.Y >= PageHeight - BottomMargin - 85)
                                    return true;
                                if (k == 0 && arlGroup.Count > 1)
                                    tmp[k + 1] = "";
                                tmp[k] = TheDataGrid.DataKeys[i][objList[k].ColName].ToString();
                                g.DrawString(tmp[k], k == 0 ? GlobalFontBold : GlobalFont, BlackBrush, rec, cellformat);
                                DetailTop = rec.Y + rec.Height;

                            }
                        }
                    }
                    rec.Y = DetailTop;
                    rec.Height = Convert.ToInt32(RowSize.Height);
                    string ColValue = null;

                    for (int j = 0; j < TotalCol; j++)
                    {
                        ColSize = new SizeF(objList[j].ColWidth, RowSize.Height);
                        if (objList[j].ColType == "Image")
                        {
                            Bitmap bm = (Bitmap)TheDataGrid.DataKeys[i][objList[j].ColName];

                            if (TheDataGrid.DataKeys[i][objList[j].ColName].ToString() != null)
                            {
                                cellbounds = new RectangleF(startxposition + 3,
                                  rec.Y - 2,
                                  bm.Width,
                                  ColSize.Height - 1);
                                g.DrawImage((Bitmap)bm, cellbounds);
                            }
                        }
                        else
                        {
                            if (IsColor)
                            {
                                BackBrush = new SolidBrush(((DataGridItem)(TheDataGrid.DataKeys[i][objList[j].ColName])).BackColor);                                
                                BlackBrush = new SolidBrush(((DataGridItem)(TheDataGrid.DataKeys[i][objList[j].ColName])).ForeColor);
                                if (BlackBrush.Color.Name == Color.Empty.Name)
                                    BlackBrush = new SolidBrush(Color.Black);

                                cellbounds2 = new Rectangle(startxposition + 1, rec.Y, Convert.ToInt32(ColSize.Width), Convert.ToInt32(ColSize.Height));
                                g.FillRectangle(BackBrush, cellbounds2);
                                g.DrawRectangle(TheLinePen, cellbounds2);
                            }
                            else
                            {
                                BackBrush = new SolidBrush(Color.Wheat);
                                BlackBrush = new SolidBrush(Color.Black);
                            }
                            int bmWidth = 30;
                            if (objList[j].ColType == "TextAndImageCell")
                            {
                                //TextAndImageCell taic = (TextAndImageCell)TheDataGrid.Rows[i].Cells["colCleanType"];
                                //Bitmap bm = (Bitmap)taic.Image;
                                //if (bm != null)
                                //{
                                //    cellbounds = new RectangleF(startxposition + 3, rec.Y + 2, bm.Width, bm.Height);
                                //    g.DrawImage((Bitmap)bm, cellbounds);
                                //    ColValue = Convert.ToString(TheDataGrid[objList[j].ColName, i].Value);
                                //    bmWidth = bm.Width;
                                //}
                                //else
                                    ColValue = Convert.ToString(TheDataGrid.DataKeys[i][objList[j].ColName]);
                            }
                            else if (objList[j].ColType == "Date")
                            {
                                if (TheDataGrid.DataKeys[i][objList[j].ColName] != null)
                                    ColValue = Convert.ToDateTime(TheDataGrid.DataKeys[i][objList[j].ColName]).ToString(clsSession.DateFormat);
                                else
                                    ColValue = "";
                            }
                            else
                                ColValue = Convert.ToString(TheDataGrid.DataKeys[i][objList[j].ColName]);

                            DataSize = g.MeasureString(ColValue, GlobalFont);
                            if (DataSize.Width > ColSize.Width)
                            {
                                int rmd = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataSize.Width / ColSize.Width)));
                                ColSize.Height = (float)TheDataGrid.RowStyle.Height.Value * rmd;
                            }
                            else
                                ColSize.Height = (float)TheDataGrid.RowStyle.Height.Value;

                            if (ColSize.Height > rec.Height)
                                rec.Height = Convert.ToInt32(Math.Ceiling(ColSize.Height));
                            
                            if (objList[j].ColType == "TextAndImageCell")
                                cellbounds = new RectangleF(startxposition + 6 + bmWidth, rec.Y + tmptop + tmptop, ColSize.Width, ColSize.Height);
                            else
                                cellbounds = new RectangleF(startxposition + 1 + tmptop, rec.Y + tmptop + tmptop, ColSize.Width, ColSize.Height);
                         
                            cellformat.Alignment = objList[j].ColAllign;
                            g.DrawString(ColValue, GlobalFont, BlackBrush, cellbounds, cellformat);
                        }
                        startxposition = startxposition + Convert.ToInt32(ColSize.Width) + (IsColor ? 0 : 5);
                    }
                    RowCount++;
                    DetailTop = DetailTop + rec.Height + (IsColor ? 0 : 3);
                    if (RowCount == TheDataGrid.Rows.Count)
                    {
                        RowCount = 0;
                        PageNumber = 1;
                    }
                }
                if (IsTotal)
                {
                    
                }
                RowCount = 0;
                PageNumber = 1;
                return false;
            }
            catch (Exception ex)
            {               
                return false;
            }
        }
    }

    public enum ColAllignmet
    {
        Left,
        Right,
        Center
    }
    public partial class clsTableInfo
    {
        private string colName;
        private string colTitle;
        private string colType;
        private int colWidth;
        private StringAlignment colAllign;
        private bool colIsTotal;
        private string colpram;
        private int colRowNo;
        private static List<clsTableInfo> ls;
        private StringAlignment colHead;


        public string ColName
        {
            get { return this.colName; }
            set { this.colName = value; }
        }

        public string ColTitle
        {
            get { return this.colTitle; }
            set { this.colTitle = value; }
        }

        public string ColType
        {
            get { return this.colType; }
            set { this.colType = value; }
        }

        public int ColWidth
        {
            get { return this.colWidth; }
            set { this.colWidth = value; }
        }

        public StringAlignment ColAllign
        {
            get { return this.colAllign; }
            set { this.colAllign = value; }
        }

        public bool ColIsTotal
        {
            get { return this.colIsTotal; }
            set { this.colIsTotal = value; }
        }

        public string ColPram
        {
            get { return colpram; }
            set { colpram = value; }
        }
        public int ColRowNo
        {
            get { return this.colRowNo; }
            set { this.colRowNo = value; }
        }

        public StringAlignment ColHead
        {
            get { return this.colHead; }
            set { this.colHead = value; }
        }

        public clsTableInfo()
        {
            DefaultInitialization();
        }

        /// <summary>
        /// Column information
        /// </summary>
        /// <param name="cname">Field Name comes from DV</param>
        /// <param name="title">Display Title</param>
        /// <param name="typ">Type</param>
        /// <param name="cwidth">Width</param>
        /// <param name="salign">Alignment</param>
        public clsTableInfo(string cname, string title, string typ, int cwidth, StringAlignment salign)
        {
            DefaultInitialization();
            this.colName = cname;
            this.colTitle = title;
            this.colType = typ;
            this.colWidth = cwidth;
            this.colAllign = salign;
            this.colIsTotal = false;
            this.colpram = "";
            this.colRowNo = 1;
            this.colHead = salign;
        }

        /// <summary>
        /// Column information
        /// </summary>
        /// <param name="cname">Field Name comes from DV</param>
        /// <param name="title">Display Title</param>
        /// <param name="typ">Type</param>
        /// <param name="cwidth">Width</param>
        /// <param name="salign">Alignment</param>
        /// <param name="istotal">Display Total</param>
        public clsTableInfo(string cname, string title, string typ, int cwidth, StringAlignment salign,bool istotal)
        {
            DefaultInitialization();
            this.colName = cname;
            this.colTitle = title;
            this.colType = typ;
            this.colWidth = cwidth;
            this.colAllign = salign;
            this.colIsTotal = istotal;
            this.colpram = "";
            this.colRowNo = 1;
            this.colHead = salign;
        }

        /// <summary>
        /// Column information
        /// </summary>
        /// <param name="cname">Field Name comes from DV</param>
        /// <param name="title">Display Title</param>
        /// <param name="typ">Type</param>
        /// <param name="cwidth">Width</param>
        /// <param name="salign">Alignment</param>
        /// <param name="_pram">For Average - AVG</param>
        public clsTableInfo(string cname, string title, string typ, int cwidth, StringAlignment salign, String _pram)
        {
            DefaultInitialization();
            this.colName = cname;
            this.colTitle = title;
            this.colType = typ;
            this.colWidth = cwidth;
            this.colAllign = salign;
            this.colIsTotal = false;
            this.colpram = _pram;
            this.colRowNo = 1;
            this.colHead = salign;
        }

        public clsTableInfo(string cname, string title, string typ, int cwidth, StringAlignment salign,int _RowNo)
        {
            DefaultInitialization();
            this.colName = cname;
            this.colTitle = title;
            this.colType = typ;
            this.colWidth = cwidth;
            this.colAllign = salign;
            this.colIsTotal = false;
            this.colpram = "";
            this.colRowNo = _RowNo;
            this.colHead = salign;
        }

        public clsTableInfo(string cname, string title, string typ, int cwidth, StringAlignment salign, StringAlignment _head)
        {
            DefaultInitialization();
            this.colName = cname;
            this.colTitle = title;
            this.colType = typ;
            this.colWidth = cwidth;
            this.colAllign = salign;
            this.colIsTotal = false;
            this.colpram = "";
            this.colRowNo = 1;
            this.colHead = _head;
        }

        public clsTableInfo(string cname, string title, string typ, int cwidth, StringAlignment salign,bool istotal, StringAlignment _head)
        {
            DefaultInitialization();
            this.colName = cname;
            this.colTitle = title;
            this.colType = typ;
            this.colWidth = cwidth;
            this.colAllign = salign;
            this.colIsTotal = istotal;
            this.colpram = "";
            this.colRowNo = 1;
            this.colHead = _head;
        }
        private void DefaultInitialization()
        {
            colName = "";
            colTitle = "";
            colType = "";
            colWidth = 0;
            colAllign = StringAlignment.Near;
            colIsTotal = false;
            colpram = "";
            colRowNo = 1;
            ColHead = StringAlignment.Near;
            ls = new List<clsTableInfo>();
        }
        public static void Add(clsTableInfo tinfo)
        {
            ls.Add(tinfo);
        }
        public static clsTableInfo GetItem(int Index)
        {
            return ls[Index];
        }
        public static List<clsTableInfo> GetList()
        {
            return ls;
        }

        public static void Clear()
        {
            if (ls != null)
                ls.Clear();
        }
    }
}
