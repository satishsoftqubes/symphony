using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Collections;
using System.Collections.Generic;


namespace SQT.Symphony.UI.Web.FrontDesk.ReportFiles.GDI
{
    public partial class PrintReportGeneralDV : clsReportMaster
    {
        List<clsTableInfo> objList;
        ArrayList arlGroup;
        int TotalCol;
        private SizeF RowSize;
        string Title;
        private SizeF ColSize;
        private float startpos;
        private bool IsDataPrint = false;
        private bool isForTrialBal = false;
        public bool isForGuest = false, isForRoomRev = false, isForDepList = false;

        public PrintReportGeneralDV(DataView dv1, bool isLandscape, List<clsTableInfo> ls, ArrayList arlgrp, string title)
            : base(isLandscape)
        {
            try
            {
                TheDataView = dv1;
                this.objList = ls;
                this.arlGroup = arlgrp;
                this.TotalCol = objList.Count;
                this.Title = Convert.ToString(title);
                this.isForTrialBal = false;
                RowSize = new SizeF(0, GlobalFont.Height + 2);
                foreach (clsTableInfo obj in objList)
                    RowSize.Width += obj.ColWidth + 6;

            }
            catch (Exception ex)
            {                
            }
        }

        public PrintReportGeneralDV(DataView dv1, bool isLandscape, List<clsTableInfo> ls, ArrayList arlgrp, string title,bool forTrialBalance)
            : base(isLandscape)
        {
            try
            {
                TheDataView = dv1;
                this.objList = ls;
                this.arlGroup = arlgrp;
                this.TotalCol = objList.Count;
                this.Title = Convert.ToString(title);
                this.isForTrialBal = forTrialBalance;                
                RowSize = new SizeF(0, GlobalFont.Height + 2);
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
            startpos = LeftMargin; 
            //This will Draw Top information
            DetailTop = TopMargin;
            DetailTop = DrawTopInfo(g, this.Title);
            //Draw Page No
            if (!isForDepList)
                DrawPrinted(g);
            else
                DrawPrinted(g, 1);
            DrawPageNumber(g);
            DrawColumnHeader(g);
        }

        public void DrawColumnHeader(Graphics g)
        {
            // draw the table header

            int initialRowCount = RowCount;
            float startxposition = startpos;

            rec.X = Convert.ToInt32(startpos);
            rec.Y = DetailTop;
            rec.Height = Convert.ToInt32(RowSize.Height);
            rec.Width = Convert.ToInt32(RowSize.Width);
           
            float height = GlobalFontBold.Height + 3;            
            for (int k = 0; k < TotalCol; k++)
            {
                ColSize = new SizeF(objList[k].ColWidth, RowSize.Height);
                nextcolumn = objList[k].ColTitle;
                cellformat.Alignment = objList[k].ColHead;
                DataSize = g.MeasureString(nextcolumn, GlobalFontBold);
                if (DataSize.Width > ColSize.Width)
                {
                    int rmd = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataSize.Width / ColSize.Width)));
                    ColSize.Height = GlobalFontBold.Height * rmd + 3;
                    if (ColSize.Height > height)
                        height = ColSize.Height;
                }
                else
                    ColSize.Height = GlobalFontBold.Height + 3;


                cellbounds = new RectangleF(startxposition + 1,
                                                       DetailTop,
                                                       ColSize.Width,
                                                       ColSize.Height);

                g.DrawString(nextcolumn, GlobalFontBold, BlackBrush, cellbounds, cellformat);
                startxposition = startxposition + Convert.ToInt32(ColSize.Width) + 2;
                if (k == 0)
                    g.DrawLine(TheLinePen, startpos - 3, rec.Y, startpos - 3, rec.Y + ColSize.Height + 1);
                if(!nextcolumn.Equals(""))
                    g.DrawLine(TheLinePen, startxposition + 3, rec.Y, startxposition + 3, rec.Y + ColSize.Height + 1);
                TheLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }
            DetailTop = DetailTop + Convert.ToInt32(height);
            g.DrawLine(TheLinePen, rec.X, rec.Y - 3, startxposition + 1, rec.Y - 3);
            g.DrawLine(TheLinePen, rec.X, DetailTop, startxposition + 1, DetailTop);
        }

        public override bool DrawRows(Graphics g)
        {
            try
            {
                if (!IsDataPrint)
                {
                    Font GlobalFontBoldGroup;
                    Font GlobalFontGroup;
                    int initialRowCount = RowCount;
                    if (isForTrialBal)
                    {
                        GlobalFontBoldGroup = new Font(FontName, 10, FontStyle.Bold);
                        GlobalFontGroup = new Font(FontName, 10, FontStyle.Regular);
                    }
                    else if (isForRoomRev)
                    {
                        GlobalFontBoldGroup = new Font(FontName, 7f, FontStyle.Bold);
                        GlobalFontGroup = new Font(FontName, 7f, FontStyle.Regular);
                    }
                    else
                    {
                        GlobalFontBoldGroup = new Font(FontName, 9, FontStyle.Bold);
                        GlobalFontGroup = new Font(FontName, 9, FontStyle.Regular);
                    }
                    ColSize = new SizeF(RowSize.Width / TotalCol, RowSize.Height);
                    DetailTop = DetailTop + 5;
                    rec.X = Convert.ToInt32(startpos);
                    rec.Y = DetailTop;                    
                    rec.Height = Convert.ToInt32(RowSize.Height);
                    rec.Width = Convert.ToInt32(RowSize.Width);
                    string[] tmp = null;
                    if (arlGroup != null && arlGroup.Count > 0 && TheDataView.Count > 0)
                    {
                        cellformat.Alignment = StringAlignment.Near;
                        tmp = new string[arlGroup.Count];
                        for (int i = 0; i < arlGroup.Count; i++)
                        {                            
                            tmp[i] = TheDataView[RowCount][arlGroup[i].ToString()].ToString();
                            if (TheDataView[RowCount][arlGroup[i].ToString()].GetType().ToString() == "System.DateTime")
                                g.DrawString(Convert.ToDateTime(tmp[i]).ToString(clsSession.DateFormat + " " + clsSession.TimeFormat), i == 0 ? GlobalFontBoldGroup : GlobalFontGroup, BlackBrush, rec, cellformat);
                            else
                            {
                                if (tmp[i] != null && !tmp[i].Equals(""))
                                    rec.Y = DetailTop;
                                if (isForGuest)
                                    rec.Height = 18;
                                g.DrawString(tmp[i], i == 0 ? GlobalFontBoldGroup : GlobalFontGroup, BlackBrush, rec, cellformat);
                            }
                            DetailTop = rec.Y + rec.Height;
                        }
                    }

                    RowSize = new SizeF(0, GlobalFont.Height + 2);
                    foreach (clsTableInfo obj in objList)
                        RowSize.Width += obj.ColWidth + 6;

                    // draw the rows of the table

                    for (int i = initialRowCount; i < TheDataView.Count; i++)
                    {
                        int startxposition = Convert.ToInt32(startpos);
                        rec.Y = DetailTop;
                        rec.Height = Convert.ToInt32(RowSize.Height);
                        if (DetailTop >= PageHeight - BottomMargin - 80)
                            return true;
                        if (arlGroup != null && arlGroup.Count > 0)
                        {
                            cellformat.Alignment = StringAlignment.Near;
                            for (int k = 0; k < arlGroup.Count; k++)
                            {
                                if (TheDataView[i][arlGroup[k].ToString()].ToString() != tmp[k])
                                {
                                    rec.Y = DetailTop + (k == 0 ? rec.Height : 0);
                                    if (rec.Y >= PageHeight - BottomMargin - 85)
                                        return true;
                                    if (k == 0 && arlGroup.Count > 1)
                                        tmp[k + 1] = "";
                                    tmp[k] = TheDataView[i][arlGroup[k].ToString()].ToString();
                                    if (TheDataView[i][arlGroup[k].ToString()].GetType().ToString() == "System.DateTime")
                                        g.DrawString(Convert.ToDateTime(TheDataView[i][arlGroup[k].ToString()].ToString()).ToString(clsSession.DateFormat + " " + clsSession.TimeFormat), k == 0 ? GlobalFontBoldGroup : GlobalFontGroup, BlackBrush, rec, cellformat);
                                    else
                                    {
                                        if (isForGuest)
                                            rec.Height = 18;
                                        g.DrawString(TheDataView[i][arlGroup[k].ToString()].ToString(), k == 0 ? GlobalFontBoldGroup : GlobalFontGroup, BlackBrush, rec, cellformat);
                                    }
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
                            if (objList[j].ColType == "Date")
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "")
                                    ColValue = Convert.ToDateTime(TheDataView[i][objList[j].ColName]).ToString(clsSession.DateFormat);
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType == " ")
                            {
                                ColValue = "";
                            }
                            else if (objList[j].ColType == "Date2")
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "")
                                    ColValue = Convert.ToDateTime(TheDataView[i][objList[j].ColName]).ToString("dd/MM");
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType.ToUpper().Equals("DAY"))
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "")
                                    ColValue = Convert.ToDateTime(TheDataView[i][objList[j].ColName]).ToString("dd");
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType == "Time")
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "")
                                    ColValue = Convert.ToDateTime(TheDataView[i][objList[j].ColName]).ToString(clsSession.TimeFormat);
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType.ToUpper() == "DATETIME")
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "")
                                    ColValue = Convert.ToDateTime(TheDataView[i][objList[j].ColName]).ToString(clsSession.DateFormat + " " + clsSession.TimeFormat);
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType.ToUpper() == "DOUBLE")
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "" && !Convert.ToDouble(TheDataView[i][objList[j].ColName]).ToString("N").Equals("0.00"))
                                    ColValue = Convert.ToDouble(TheDataView[i][objList[j].ColName]).ToString("N");
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType.ToUpper() == "INTT") //i.e.  213
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "" && !Convert.ToDouble(TheDataView[i][objList[j].ColName]).ToString("N").Equals("0.00"))
                                    ColValue = Convert.ToInt32(TheDataView[i][objList[j].ColName]).ToString();
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType.ToUpper() == "INT") //i.e.  213
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "" && !Convert.ToInt32(TheDataView[i][objList[j].ColName]).ToString().Trim().Equals("0"))
                                    ColValue = Convert.ToInt32(TheDataView[i][objList[j].ColName]).ToString();
                                else
                                    ColValue = "";
                            }
                            else if (objList[j].ColType.ToUpper() == "BOOL")
                            {
                                if (TheDataView[i][objList[j].ColName].ToString() != "")
                                {
                                    if (TheDataView[i][objList[j].ColName].ToString().ToUpper().Equals("TRUE"))
                                        ColValue = "New";
                                    else
                                        ColValue = "Changed";
                                }
                                else
                                    ColValue = "";
                            }
                            else
                                ColValue = Convert.ToString(TheDataView[i][objList[j].ColName]);

                            DataSize = g.MeasureString(ColValue, GlobalFont);
                            if (DataSize.Width > ColSize.Width)
                            {
                                int rmd = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataSize.Width / ColSize.Width)));
                                ColSize.Height = GlobalFont.Height * rmd + 3;
                            }
                            else
                                ColSize.Height = GlobalFont.Height + 3;

                            if (ColSize.Height > rec.Height)
                                rec.Height = Convert.ToInt32(Math.Ceiling(ColSize.Height));

                            cellbounds = new RectangleF(startxposition + 1, rec.Y, ColSize.Width, ColSize.Height);
                            cellformat.Alignment = objList[j].ColAllign;
                            g.DrawString(ColValue, GlobalFont, BlackBrush, cellbounds, cellformat);

                            startxposition = startxposition + Convert.ToInt32(ColSize.Width) + 2;

                            TheLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            if(j == 0)
                                g.DrawLine(TheLinePen, startpos - 3, rec.Y, startpos - 3, rec.Y + ColSize.Height + 1);
                            if (!nextcolumn.Equals(""))
                                g.DrawLine(TheLinePen, startxposition + 3, rec.Y, startxposition + 3, rec.Y + ColSize.Height + 1);
                            TheLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        }
                        RowCount++;
                        if (i != TheDataView.Count - 1)
                        {
                            TheLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            g.DrawLine(TheLinePen, startpos, DetailTop + rec.Height + 2, startxposition + 1, DetailTop + rec.Height + 2);
                        }
                        TheLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        DetailTop = DetailTop + rec.Height + 5;
                        if (RowCount == TheDataView.Table.Rows.Count)
                        {
                            IsDataPrint = true;
                            RowCount = 0;
                            PageNumber = 1;
                        }
                    }
                }
                if (DrawTotal(g))
                    return true;
                RowCount = 0;
                PageNumber = 1;
                return false;
            }
            catch (Exception ex)
            {               
                return false;
            }

        }

        private bool DrawTotal(Graphics g)
        {
            float startxposition = startpos;
            rec.X = Convert.ToInt32(startpos);
            rec.Y = DetailTop;
            rec.Height = Convert.ToInt32(RowSize.Height);
            rec.Width = Convert.ToInt32(RowSize.Width);
            string strTot = "";

            for (int k = 0; k < TotalCol; k++)
            {
                if (objList[k].ColIsTotal || objList[k].ColPram != "")
                {
                    if ((DetailTop) >= PageHeight - BottomMargin - 85)
                        return true;
                }
            }

            DetailTop = DetailTop + 4;
            for (int k = 0; k < TotalCol; k++)
            {              
                ColSize = new SizeF(objList[k].ColWidth, RowSize.Height);
                if ((objList[k].ColIsTotal || objList[k].ColPram != "") && (objList[k].ColType.ToUpper() == "DOUBLE" || objList[k].ColType.ToUpper() == "INT"))
                {
                    //g.DrawLine(TheLinePen, rec.X, DetailTop - 2, rec.X + RowSize.Width - 2, DetailTop - 2);

                    cellformat.Alignment = StringAlignment.Near;
                    cellbounds = new RectangleF(startpos + 1,
                                                            DetailTop,
                                                            100,
                                                            GlobalFontBold.Height + 3);
                    if(k == TotalCol - 1)
                        g.DrawString("Total", GlobalFontBold, BlackBrush, cellbounds, cellformat);

                    double tot = 0;
                    for (int i = 0; i < TheDataView.Count; i++)
                    {
                        if (!TheDataView[i][objList[k].ColName].ToString().Equals(""))
                            tot += Convert.ToDouble(TheDataView[i][objList[k].ColName]);
                    }
                    if (objList[k].ColPram == "AVG")
                        tot = tot / TheDataView.Count;

                    DataSize = g.MeasureString(tot.ToString("N"), GlobalFontBold);
                    if (DataSize.Width > ColSize.Width)
                    {
                        int rmd = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(DataSize.Width / ColSize.Width)));
                        ColSize.Height = GlobalFont.Height * rmd + 3;
                    }
                    else
                        ColSize.Height = GlobalFont.Height + 3;

                    if (ColSize.Height > rec.Height)
                        rec.Height = Convert.ToInt32(Math.Ceiling(ColSize.Height));

                    nextcolumn = objList[k].ColTitle;
                    cellformat.Alignment = objList[k].ColAllign;
                    cellbounds = new RectangleF(startxposition + 1,
                                                           DetailTop,
                                                           ColSize.Width,
                                                           ColSize.Height);
                    strTot = tot.ToString();
                    if (objList[k].ColType.ToUpper() == "INT")
                        g.DrawString(tot.ToString(), GlobalFontBold, BlackBrush, cellbounds, cellformat);
                    else
                        g.DrawString(tot.ToString("N"), GlobalFontBold, BlackBrush, cellbounds, cellformat);
                    flg = true;
                }

                startxposition = startxposition + Convert.ToInt32(ColSize.Width) + 2;
                if (k == 0)
                    g.DrawLine(TheLinePen, startpos - 3, rec.Y - 2, startpos - 3, rec.Y + ColSize.Height + 1);             
                g.DrawLine(TheLinePen, startxposition + 3, rec.Y, startxposition + 3, rec.Y + ColSize.Height + 1);
                TheLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }
            if (flg)
            {
                g.DrawLine(TheLinePen, rec.X, rec.Y - 2, startxposition + 1, rec.Y - 2);
                g.DrawLine(TheLinePen, rec.X, DetailTop + Convert.ToInt32(cellbounds.Height), startxposition + 1, DetailTop + Convert.ToInt32(cellbounds.Height));
                g.DrawLine(TheLinePen, rec.X, DetailTop + Convert.ToInt32(cellbounds.Height) + 3, startxposition + 1, DetailTop + Convert.ToInt32(cellbounds.Height) + 3);
                flg = false;
            } 
            IsDataPrint = false;
            return false;
        }
        private bool flg = false;
    }
}
