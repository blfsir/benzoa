using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public class NoteObject : BusinessObjectBase
    {
       public static DataTable GetNoteListByUserID(object[] param)
        {
            NoteDAL obj = new NoteDAL();
            return obj.GetNoteListByUserID(param);
        }

       public static string InsertNote(object[] param)
       {
           NoteDAL obj = new NoteDAL();
           return obj.InsertNote(param, "exit");
       }

       public static string UpdateNote(object[] param)
       {
           NoteDAL obj = new NoteDAL();
           return obj.UpdateNote(param, "exit");
       }

       public static string DeleteNote(object[] param)
       {
           NoteDAL obj = new NoteDAL();
           return obj.DeleteNote(param, "exit");
       }

       public static string CollectNote(object[] param)
       {
           NoteDAL obj = new NoteDAL();
           return obj.CollectNote(param, "exit");
       }

       public static DataTable SearchNote(object[] param)
       {
           NoteDAL obj = new NoteDAL();
           return obj.SearchNote(param);
       }

       public static DataTable GetNoteByID(object[] param)
       {
           NoteDAL obj = new NoteDAL();
           return obj.GetNoteByID(param);
       }

        /*
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
         */ 
    }
}
