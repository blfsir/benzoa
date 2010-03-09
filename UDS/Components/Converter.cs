using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Reflection;

namespace UDS.Components
{
    public class Converter
    {
        private Converter() { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(Object o)
        {
            PropertyInfo[] properties = o.GetType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            FillData(properties, dt, o);
            return dt;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);

            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);

            }

            return dt;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;

            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;

                dt.Columns.Add(dc);
            }

            return dt;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="dt"></param>
        /// <param name="o"></param>
        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();

            foreach (PropertyInfo pi in properties)
                dr[pi.Name] = pi.GetValue(o, null);

            dt.Rows.Add(dr);
        }
 
 
    }
}
