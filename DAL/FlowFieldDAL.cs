using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class FlowFieldDAL : DALBase
    {
        public DataTable GetFlowFieldById(object[] paramsvalue)
        {
            return base.GetDataTableFromDatabase(paramsvalue, "NEMP_GetFlowFieldById");
        }

        public string getAutoNumber(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "NEMP_getAutoNumber", outParameterName);
        }

        public bool IsStyleInUse(string StyleID)
        {
            object[] paramsvalue = new object[] { int.Parse(StyleID) };
            DataTable dt = base.GetDataTableFromDatabase(paramsvalue, "NEMP_IsStyleInUse");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
