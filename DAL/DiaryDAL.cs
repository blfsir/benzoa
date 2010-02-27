using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class DiaryDAL : DALBase
    {

        public DataTable GetDiaryListByUserID(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetDiaryListByUserID");
        }

        public string InsertDiary(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_InsertDiary", outParameterName);
        }

        public string UpdateDiary(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_UpdateDiary", outParameterName);
        }

        public string DeleteDiary(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_DeleteDiary", outParameterName);
        }

        public string CollectDiary(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_CollectDiary", outParameterName);
        }

        public DataTable SearchDiary(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_SearchDiary");
        }

        public DataTable GetDiaryByID(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetDiaryByID");
        }

        public DataTable SearchSubStaff(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_SearchSubStaff");
        }
    }
}
