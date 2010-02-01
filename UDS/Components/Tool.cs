using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
//该源码下载自www.51aspx.com(５１aｓｐｘ．ｃｏｍ)

namespace UDS.Components
{
    /// <summary>
    /// 常用工具函数类
    /// </summary>
    public class Tools
    {

        #region 将DataReader 转为 DataTable
        /// <summary>
        /// 将DataReader 转为 DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            DataTable schemaTable = dataReader.GetSchemaTable();
            //动态添加列
            try
            {

                foreach (DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    //myDataColumn.DataType	= myRow.GetType(); //edit by 51aspx
                    myDataColumn.DataType = System.Type.GetType("System.String");
                    myDataColumn.ColumnName = myRow[0].ToString();
                    datatable.Columns.Add(myDataColumn);
                }
                //添加数据
                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        try
                        {
                            myDataRow[i] = dataReader[i].ToString();

                        }
                        catch (Exception ex)
                        {
                            Error.Log(ex.ToString());
                        }
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
                schemaTable = null;
                dataReader.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("转换出错出错!", ex);
            }
            finally
            {
                dataReader.Close();
                dataReader.Dispose();
            }

        }

        #endregion

        #region 将英文的星期几转为中文
        public static string ConvertDayOfWeekToZh(System.DayOfWeek dw)
        {
            string DayOfWeekZh = "";
            switch (dw.ToString("D"))
            {
                case "0":
                    DayOfWeekZh = "日";
                    break;
                case "1":
                    DayOfWeekZh = "一";
                    break;
                case "2":
                    DayOfWeekZh = "二";
                    break;
                case "3":
                    DayOfWeekZh = "三";
                    break;
                case "4":
                    DayOfWeekZh = "四";
                    break;
                case "5":
                    DayOfWeekZh = "五";
                    break;
                case "6":
                    DayOfWeekZh = "六";
                    break;
            }

            return DayOfWeekZh;
        }
        #endregion

    }
}
