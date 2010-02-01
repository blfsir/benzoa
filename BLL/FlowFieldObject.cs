using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public class FlowFieldObject : BusinessObjectBase
    {
        public static DataTable  GetFlowFieldById(object[] param)
        {
            FlowFieldDAL flowFieldDal = new FlowFieldDAL();
            return flowFieldDal.GetFlowFieldById(param);
        }

        public static string getAutoNumber(object[] param, string outParameterName)
        {
            FlowFieldDAL flowFieldDal = new FlowFieldDAL();
            return flowFieldDal.getAutoNumber(param, outParameterName);
        }

        public static bool IsStyleInUse(string StyleID)
        {
            FlowFieldDAL flowFieldDal = new FlowFieldDAL();
            return flowFieldDal.IsStyleInUse(StyleID);
            
        }
    }
}
