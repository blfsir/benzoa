using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public   class DiaryObject : BusinessObjectBase
    {
        public static DataTable GetDiaryListByUserID(object[] param)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.GetDiaryListByUserID(param);
        }

        public static string InsertDiary(object[] param)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.InsertDiary(param, "exit");
        }

        public static string UpdateDiary(object[] param)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.UpdateDiary(param, "exit");
        }

        public static string DeleteDiary(object[] param)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.DeleteDiary(param, "exit");
        }

        public static string CollectDiary(object[] param)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.CollectDiary(param, "exit");
        }

        public static DataTable SearchDiary(object[] param)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.SearchDiary(param);
        }

        public static DataTable GetDiaryByID(object[] param)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.GetDiaryByID(param);
        }

        public static DataTable SearchSubStaff(object[] paramsValue)
        {
            DiaryDAL obj = new DiaryDAL();
            return obj.SearchSubStaff(paramsValue);
        }
    }
}
