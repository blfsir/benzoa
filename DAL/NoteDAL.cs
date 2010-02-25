using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class NoteDAL : DALBase
    {
        public DataTable GetNoteListByUserID(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetNoteListByUserID");
        }

        public string InsertNote(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_InsertNote", outParameterName);
        }

        public string UpdateNote(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_UpdateNote", outParameterName);
        }

        public string DeleteNote(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_DeleteNote", outParameterName);
        }

        public string CollectNote(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_CollectNote", outParameterName);
        }

        public DataTable SearchNote(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_SearchNote");
        }

        public DataTable GetNoteByID(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetNoteByID");
        }

        /*
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
         */ 
    }
}
