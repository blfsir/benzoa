using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class MeetingDAL : DALBase
    {
        public string InsertMeeting(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_InsertMeeting", outParameterName);
        }

        public DataTable GetMeetingByDate(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetMeetingByDate");
        }

        public string InsertMeetingType(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_InsertMeetingType", outParameterName);
        }

        public string UpdateMeetingType(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_UpdateMeetingType", outParameterName);
        }

        public string DeleteMeetingType(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_DeleteMeetingType", outParameterName);
        }

        public DataTable GetMeetingTypeByID(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetMeetingTypeByID");
        }

        public DataTable GetAllMeetingType(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetAllMeetingType");
        }

        //会议室
        public string InsertMeetingRoom(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_InsertMeetingRoom", outParameterName);
        }

        public string UpdateMeetingRoom(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_UpdateMeetingRoom", outParameterName);
        }

        public string DeleteMeetingRoom(object[] param, string outParameterName)
        {
            return base.ExecuteStoredProcedure(param, "Proc_DeleteMeetingRoom", outParameterName);
        }

        public DataTable GetMeetingRoomByID(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetMeetingRoomByID");
        }

        public DataTable GetAllMeetingRoom(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_GetAllMeetingRoom");
        }

        /// <summary>
        /// 会议查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable SearchMeeting(object[] param)
        {
            return base.GetDataTableFromDatabase(param, "Proc_SearchMeeting");
        }

    }
}
