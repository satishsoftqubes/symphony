using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace SQT.FRAMEWORK.COMMON.Util
{
    /// <summary>
    /// Conversion class can provide the facility to the coder to check whether the given object value is DBNull or Not then it will return it C# appropriate Nullable DataTypes
    /// Like a int?, double?, DateTime? otherwise it will convert the value into the specific type.
    /// </summary>
    public sealed partial class Conversion
    {
        #region Getting Appropriate Value
        public static int? GetIntValue(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToInt32(obj);
            else
                return null;
        }
        public static string GetStringValue(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToString(obj);
            else
                return null;
        }
        public static double? GetDoubleValue(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToDouble(obj);
            else
                return null;
        }
        public static DateTime? GetDateValue(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToDateTime(obj);
            else
                return null;
        }
        public static bool? GetBoolValue(object obj)
        {
            if (obj != DBNull.Value)
                return Convert.ToBoolean(obj);
            else
                return null;
        }
        public static Guid? GetGUID(object obj)
        {
            if(obj!= DBNull.Value)
                return (new Guid(obj.ToString()));
            else
                return null;
        }
        public static Image GetImageValue(object obj)
        {
            if (obj != DBNull.Value)
            {
                MemoryStream mem = new MemoryStream((byte[])obj);
                return Image.FromStream(mem);
            }
            else
                return null;
        }
        #endregion Getting Appropriate Value

        #region Setting Appropriate Value
        public static SqlInt32 SetIntValue(int? intData)
        {
            if (intData != null)
            {
                return (SqlInt32)intData;
            }
            else
                return SqlInt32.Null;
        }
        public static SqlDouble SetDoubleValue(double? dblData)
        {
            if (dblData != null)
            {
                return (SqlDouble)dblData;
            }
            else
                return SqlDouble.Null;
        }
        public static SqlDateTime SetDateValue(DateTime? dtData)
        {
            if (dtData != null)
            {
                return (SqlDateTime)dtData;
            }
            else
                return SqlDateTime.Null;
        }
        public static SqlString SetStringValue(string strData)
        {
            if (strData != null)
                return (SqlString)strData;
            else
                return SqlString.Null;
        }
        public static SqlBoolean SetBooleanValue(bool? blData)
        {
            if (blData != null)
                return (SqlBoolean)blData;
            else
                return SqlBoolean.Null;
        }
        public static SqlGuid SetGUID(Guid? guId)
        {
            if (guId != null)
                return (SqlGuid)guId;
            else
                return SqlGuid.Null;
        }
        #endregion Setting Appropriate Value
    }
    public class ConverterException : ApplicationException
    {
        public ConverterException(string msg) : base(msg)
        {
        }
    }
    public class Converter
    {
        public static object Convert(object src, Type destType)
        {
            object ret = src;

            if ((src != null) && (src != DBNull.Value))
            {
                Type srcType = src.GetType();

                if ((srcType.FullName == "System.Object") || (destType.FullName == "System.Object"))
                {
                    ret = src;
                }
                else
                {
                    if (srcType != destType)
                    {
                        TypeConverter tcSrc = TypeDescriptor.GetConverter(srcType);
                        TypeConverter tcDest = TypeDescriptor.GetConverter(destType);

                        if (tcSrc.CanConvertTo(destType))
                        {
                            ret = tcSrc.ConvertTo(src, destType);
                        }
                        else if (tcDest.CanConvertFrom(srcType))
                        {
                            if (srcType.FullName == "System.String")
                            {
                                ret = tcDest.ConvertFromInvariantString((string)src);
                            }
                            else
                            {
                                ret = tcDest.ConvertFrom(src);
                            }
                        }
                        else
                        {
                            // If no conversion exists, throw an exception.
                            throw new ConverterException("Can't convert from " + src.GetType().FullName + " to " + destType.FullName);
                        }
                    }
                }
            }
            else if (src == DBNull.Value)
            {
                ret = null;
            }
            return ret;
        }
    }
    public sealed partial class COMBODV
    {
        public static DataView GetDV(DataView dv, string DisplayColumn, string ValueColumn)        
        {
            DataTable dt = new DataTable();
            dt = dv.Table;
            DataRow dr = dt.Rows.Add();
            dr[DisplayColumn] = "<<SELECT>>";
            dr[ValueColumn] = DBNull.Value;
            DataView dvreturn = new DataView();
            dvreturn = new DataView(dt);
            return dvreturn;
        }
        
        public static DataView GetDV(DataView dv, string DisplayColumn, string ValueColumn, bool IsFilteredDV)
        {
            if (!IsFilteredDV)
            {
                return GetDV(dv, DisplayColumn, ValueColumn);
            }
            else
            {
                DataTable dt = new DataTable();
                DataColumn[] dc = new DataColumn[dv.Table.Columns.Count];
                dv.Table.Columns.CopyTo(dc, 0);
                for (int i = 0; i < dc.Length; i++)
                {
                    dt.Columns.Add(dc[i].ColumnName);
                }
                DataRow dr;
                for (int i = 0; i < dv.Count; i++)
                {
                    dr = dt.Rows.Add();
                    for (int j = 0; j < dv.Table.Columns.Count; j++)
                    {
                        dr[j] = dv[i][j];
                    }
                }
                DataRow dr1 = dt.Rows.Add();
                dr1[DisplayColumn] = "<<SELECT>>";
                dr1[ValueColumn] = DBNull.Value;
                DataView dv1 = new DataView(dt);
                return dv1;
            }
        }
        
    }

    public static class Miscellaneous
    {
        #region DateFormts 
        public static string Format_DateTime(System.DateTime vDate, int vType)
        {
            return tmpFormat_DateTime(vDate, vType);
        }

        public static string Format_DateTime(string vDate, int vType)
        {
            if (vDate == "")
            {
                return null;
            }
            return tmpFormat_DateTime(Convert.ToDateTime(vDate), vType);
        }

        private static string tmpFormat_DateTime(System.DateTime vDate, int vType)
        {
            //Dim sDate As String
            try
            {
                if (Microsoft.VisualBasic.Information.IsDate(vDate))
                {
                    //sDate = CType(vDate, String)
                    switch (vType)
                    {
                        case 1:
                            return Microsoft.VisualBasic.Strings.Format(vDate, "dd MMM yyyy" + " " + "HH:mm");
                        case 2:
                            return vDate.ToString("dd MMM yyyy");
                        case 3:
                            return vDate.ToString("HH:mm");
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        #endregion DateFormats

        #region Image Conversion 
        public static byte[] ConvertImageToByte(this string ImagePath)
        {
            FileStream fs = new FileStream(ImagePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            return br.ReadBytes((int)br.BaseStream.Length);
            br.Close();
            fs.Close();
        }

        public static Image GetImageFromByte(this byte[] bytImage)
        {
            MemoryStream mem = new MemoryStream(bytImage);
            return Image.FromStream(mem);
            mem.Close();
        }

        public static byte[] ConvertImageToByte(this Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            return ms.ToArray();
        }
        #endregion Image Conversion
    }
}
