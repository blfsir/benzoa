using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
   public class MeetingObject : BusinessObjectBase
    {
       public static string InsertMeeting(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.InsertMeeting(param, "exit");
       }
       public static DataTable GetMeetingByDate(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.GetMeetingByDate(param);
       }


       public static string InsertMeetingType(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.InsertMeetingType(param, "exit");
       }

       public static string UpdateMeetingType(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.UpdateMeetingType(param, "exit");
       }

       public static string DeleteMeetingType(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.DeleteMeetingType(param, "exit");
       }

       public static DataTable GetMeetingTypeByID(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.GetMeetingTypeByID(param);
       }

       public static DataTable GetAllMeetingType(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.GetAllMeetingType(param);
       }

       //会议室
       public static string InsertMeetingRoom(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.InsertMeetingRoom(param, "exit");
       }

       public static string UpdateMeetingRoom(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.UpdateMeetingRoom(param, "exit");
       }

       public static string DeleteMeetingRoom(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.DeleteMeetingRoom(param, "exit");
       }

       public static DataTable GetMeetingRoomByID(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.GetMeetingRoomByID(param);
       }

       public static DataTable GetAllMeetingRoom(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.GetAllMeetingRoom(param);
       }

       /// <summary>
       /// 会议查询
       /// </summary>
       /// <param name="param"></param>
       /// <returns></returns>
       public static DataTable SearchMeeting(object[] param)
       {
           MeetingDAL obj = new MeetingDAL();
           return obj.SearchMeeting(param);
       }
    }
}
