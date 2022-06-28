using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SQT.FRAMEWORK.DAL;

namespace SQT.FRAMEWORK.DAL.Util
{
    public enum InformationSchemaOperation
    {
        TABLES,
        COLUMNS,
        ROUTINES,
        PARAMETERS
    }
    public sealed class MergeTable
    {
        private static DataTable table1;
        private static DataTable table2;
        private static DataSet ds;

        public static DataView ExecuteInformationSchema(InformationSchemaOperation op,string Table_Name, string Routine_Name)
        {
            DBManager db = new DBManager();
            db.CreateParameters(3);
            db.AddParameters(0,"Operation",op.ToString());
            db.AddParameters(1,"Table_Name",Convert.ToString(Table_Name));
            db.AddParameters(2, "Routine_Name", Convert.ToString(Routine_Name));
            db.dst = db.ExecuteDataSet(CommandType.StoredProcedure, "mis_Information_Schema");
            return new DataView(db.dst.Tables[0]);
        }
        /// <summary>
        /// 
        /// </summary>
        public static DataTable Table1
        {
            set
            {
                if (value != null)
                {
                    table1 = value;
                    if (table1.Columns.Count <= 0)
                        throw new Exception("Table1 doesn't Contain any Columns...");
                }
                else
                {
                    throw new Exception("Null value is not allowed...");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static DataTable Table2
        {
            set
            {
                if (value != null)
                {
                    table2 = value;
                    if (table2.Columns.Count <= 0)
                        throw new Exception("Table2 doesn't Contain any Columns...");
                }
                else
                {
                    throw new Exception("Null value is not allowed...");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="First"></param>
        /// <param name="Second"></param>
        /// <param name="PC"></param>
        /// <param name="CC"></param>
        /// <returns></returns>
        public static DataTable Join(DataTable First, DataTable Second, DataColumn[] PC, DataColumn[] CC)
        {
            DataTable table = new DataTable("Join");
            using (DataSet ds = new DataSet())
            {
                ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });
                DataColumn[] parentcolumns = new DataColumn[PC.Length];
                for (int i = 0; i < parentcolumns.Length; i++)
                {
                    parentcolumns[i] = ds.Tables[0].Columns[PC[i].ColumnName];
                }
                DataColumn[] childcolumns = new DataColumn[CC.Length];
                for (int i = 0; i < childcolumns.Length; i++)
                {
                    childcolumns[i] = ds.Tables[1].Columns[CC[i].ColumnName];
                }
                DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);
                ds.Relations.Add(r);
                for (int i = 0; i < First.Columns.Count; i++)
                {
                    table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
                }
                for (int i = 0; i < Second.Columns.Count; i++)
                {
                    if (!table.Columns.Contains(Second.Columns[i].ColumnName))
                        table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
                    else
                        table.Columns.Add(Second.Columns[i].ColumnName + "-" + Second.TableName , Second.Columns[i].DataType);
                }
                table.BeginLoadData();
                foreach (DataRow firstrow in ds.Tables[0].Rows)
                {
                    DataRow[] childrows = firstrow.GetChildRows(r);
                    if (childrows != null && childrows.Length > 0)
                    {
                        object[] parentarray = firstrow.ItemArray;
                        foreach (DataRow secondrow in childrows)
                        {
                            object[] secondarray = secondrow.ItemArray;
                            object[] joinarray = new object[parentarray.Length + secondarray.Length];
                            Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
                            Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);
                            table.LoadDataRow(joinarray, true);
                        }
                    }
                }
                table.EndLoadData();
            }
            return table;
        }
    }
}
