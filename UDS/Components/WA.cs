using System;
using System.Data;
using System.Data.SqlClient;
namespace UDS.Components
{
	/// <summary>
	/// 上下班时间
	/// </summary>
	public struct DutyTime
	{
		private DateTime ondutytime;//上班时间
		private DateTime offdutytime;//下班时间
		public DateTime OnDutyTime
		{
			get
			{
				return ondutytime;
			}
			set
			{
				ondutytime = value;
			}
		}
		public DateTime OffDutyTime
		{
			get
			{
				return offdutytime;
			}
			set
			{
				offdutytime = value;
			}
		}
	}

	/// <summary>
	/// 得到相关考勤的设置数据
	/// </summary>
	public class WA_Setting
	{
		
		private int staffid=0;//人员id
		
		public WA_Setting()
		{
			
		}
		public WA_Setting(int	StaffID)
		{
			staffid = StaffID;
		}
		/// <summary>
		/// 员工的id值
		/// </summary>
		public int StaffID{
			get{
				return staffid;
			}
			set{
				staffid = value;
			}
		}
		/// <summary>
		/// 得到员工上下班时间
		/// </summary>
		public DutyTime GetDutyTime(){
			UDS.Components.Database db = new UDS.Components.Database();
			DutyTime dt = new DutyTime();

			System.Data.SqlClient.SqlParameter[] prams = {
														   db.MakeInParam("@staffid",System.Data.SqlDbType.Int,4,staffid),
														   db.MakeOutParam("@ondutytime",System.Data.SqlDbType.SmallDateTime,8),
														   db.MakeOutParam("@offdutytime",System.Data.SqlDbType.SmallDateTime,8)
			};
			if(db.RunProc("sp_WA_GetDutyTime",prams)!=0)
			{
				throw(new Exception("读取人员上下班时间出错"));
			}
			else
			{
				dt.OnDutyTime = (System.DateTime)prams[1].Value;
				dt.OffDutyTime = (System.DateTime)prams[2].Value;
				return dt;
			}
		}
		/// <summary>
		/// 得到员工上下班时间
		/// </summary>
		/// <param name="Staffid">员工id</param>
		public DutyTime GetDutyTime(int Staffid)
		{
			staffid = Staffid;
			UDS.Components.Database db = new UDS.Components.Database();
			DutyTime dt = new DutyTime();
			System.Data.SqlClient.SqlParameter[] prams = {
														   db.MakeInParam("@staffid",System.Data.SqlDbType.Int,4,staffid),
														   db.MakeOutParam("@ondutytime",System.Data.SqlDbType.DateTime,8),
														   db.MakeOutParam("@offdutytime",System.Data.SqlDbType.DateTime,8)
													   };
			if(db.RunProc("sp_WA_GetDutyTime",prams)!=0)
			{
				throw(new Exception("读取人员上下班时间出错"));
			}
			else
			{
				dt.OnDutyTime = (System.DateTime)prams[1].Value;
				dt.OffDutyTime = (System.DateTime)prams[2].Value;
				return dt;
			}
		}

	}
	/// <summary>
	/// 上下班的动作
	/// </summary>
	public enum DutyAction
	{
		OnDuty=1,
		OffDuty=2
	}
	/// <summary>
	/// 代表上班，岗位信息的类
	/// </summary>
	public class WA_Duty
	{
		private int staffid;//人员id
		private TimeSpan ondutyflexibilitytime = new TimeSpan(0,0,0);//上班迟到弹性时间
		private TimeSpan offdutyflexibilitytime = new TimeSpan(0,0,0);//下班弹性时间
		/// <summary>
		/// 人员id
		/// </summary>
		public int StaffID
		{
			get
			{
				return staffid;
			}
			set
			{
				staffid = value;
			}
	
		}
		/// <summary>
		/// 上班弹性时间
		/// </summary>
		public TimeSpan OnDutyFTime
		{
			get
			{
				return ondutyflexibilitytime;
			}
			set
			{
				ondutyflexibilitytime = value;
			}
		}
		/// <summary>
		/// 下班弹性时间
		/// </summary>
		public TimeSpan OffDutyFTime
		{
			get
			{
				return offdutyflexibilitytime;
			}
			set
			{
				offdutyflexibilitytime = value;
			}
		}
		public WA_Duty()
		{

		}
		public  WA_Duty(int StaffID)
		{
			staffid = StaffID;
		}
		/// <summary>
		/// 检查人员是否已经完成上班考勤
		/// </summary>
		/// <param name="day">日期</param>
		/// <param name="staffid">人员id</param>
		/// <returns>true 考过勤 false没考过</return>
		public bool HaveCheckedDuty(DateTime day,int staffid)
		{
			Database db = new Database();
			this.staffid = staffid;
			SqlParameter[] prams = {
									    db.MakeInParam("@day",SqlDbType.DateTime,8,day),
										db.MakeInParam("@staffid",SqlDbType.VarChar,50,staffid.ToString())
			};
			return((db.RunProc("sp_WA_HaveChecked",prams)==1)?true:false);
		}
		/// <summary>
		/// 检查人员是否已经完成上班考勤
		/// </summary>
		/// <param name="day">日期</param>
		/// <returns>true 考过勤 false没考过</return>
		public bool HaveCheckedDuty(DateTime day)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@day",SqlDbType.DateTime,8,day),
									   db.MakeInParam("@staffid",SqlDbType.VarChar,50,staffid.ToString())
								   };
			return((db.RunProc("sp_WA_HaveChecked",prams)==1)?true:false);
		}
		/// <summary>
		/// 检查人员是否完成考勤
		/// </summary>
		/// <param name="day"></param>
		/// <returns>考勤记录的id</returns>
		public int HaveCompletedDuty(DateTime day)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@day",SqlDbType.DateTime,8,day),
									   db.MakeInParam("@staffid",SqlDbType.VarChar,50,staffid.ToString())
								   };
			return(db.RunProc("sp_WA_HaveCompleteDuty",prams));

		}
		/// <summary>
		/// 检查上下班状态是否迟到早退
		/// </summary>
		/// <param name="action">动作DutyAction</param>
		/// <param name="staffid">人员id</param>
		/// <returns>返回值</returns>
		public bool CheckStatus(DutyAction action,int staffid)
		{
			this.staffid = staffid;
			WA_Setting was = new WA_Setting();
			DutyTime dutytime = was.GetDutyTime(staffid);
			//如果是上班
			if(action==DutyAction.OnDuty)
			{
				if((DateTime.Now.TimeOfDay - ondutyflexibilitytime) > dutytime.OnDutyTime.TimeOfDay)
					return false;
				else
					return true;
			}
			//如果下班
			else
			{
				if((DateTime.Now.TimeOfDay + offdutyflexibilitytime) < dutytime.OffDutyTime.TimeOfDay)
					return false;
				else
					return true;
			}
		}
		/// <summary>
		/// 检查上下班状态是否迟到早退
		/// </summary>
		/// <param name="action">动作DutyAction</param>
		/// <returns>返回值</returns>
		public bool CheckStatus(DutyAction action)
		{
			WA_Setting was = new WA_Setting();
			DutyTime dutytime = was.GetDutyTime(staffid);
			//如果是上班
			if(action==DutyAction.OnDuty)
			{
				if((DateTime.Now - ondutyflexibilitytime)> (DateTime.Today + dutytime.OnDutyTime.TimeOfDay))
					return false;
				else
					return true;
			}
				//如果下班
			else
			{
				if((DateTime.Now + offdutyflexibilitytime) < (DateTime.Today + dutytime.OffDutyTime.TimeOfDay))
					return false;
				else
					return true;
			}
		}
		/// <summary>
		/// 将考勤数据存入数据库
		/// </summary>
		/// <param name="staffid">人员id</param>
		/// <param name="dutytime">上班时间</param>
		/// <param name="dutystat">上班状态</param>
		/// <param name="memo">描述</param>
		/// <returns>返回数据库记录id</returns>
		public long RecordOnDutyData(int staffid,DateTime dutytime,bool dutystat,string memo)
		{
			Database db = new Database();
			this.staffid = staffid;
			SqlParameter[] prams = {
									   db.MakeInParam("@staffid",SqlDbType.Int,4,staffid),
									   db.MakeInParam("@dutytime",SqlDbType.DateTime,8,dutytime),
									   db.MakeInParam("@dutystatus",SqlDbType.Bit,1,dutystat),
									   db.MakeInParam("@memo",SqlDbType.VarChar,400,memo)
								   };
			try
			{
				return(db.RunProc("sp_WA_RecordOnDutyData",prams));
			}
			catch(Exception  e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 将考勤数据存入数据库
		/// </summary>
		/// <param name="dutytime">上班时间</param>
		/// <param name="dutystat">上班状态</param>
		/// <param name="memo">描述</param>
		/// <returns>返回数据库记录id</returns>
		public long RecordOnDutyData(DateTime dutytime,bool dutystat,string memo)
		{
			Database db = new Database();
            int dutystatus = (dutystat)?0:1;
			SqlParameter[] prams = {
									   db.MakeInParam("@staffid",SqlDbType.Int,4,staffid),
									   db.MakeInParam("@dutytime",SqlDbType.DateTime,8,dutytime),
									   db.MakeInParam("@dutystatus",SqlDbType.Bit,1,dutystatus),
									   db.MakeInParam("@memo",SqlDbType.VarChar,400,memo)
								   };
			try
			{
				return(db.RunProc("sp_WA_RecordOnDutyData",prams));
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// 记录下班数据
		/// </summary>
		/// <param name="dataid">上班的id</param>
		/// <param name="dutytime">下班的时间</param>
		/// <param name="dutystat">下班状态</param>
		/// <param name="memo">描述</param>
		/// <returns>是否出错</returns>
		public int RecordOffDutyData(long dataid,DateTime dutytime,bool dutystat,string memo)
		{
			Database db = new Database();
			int dutystatus = (dutystat)?0:1;
			SqlParameter[] prams = {
									   db.MakeInParam("@dataid",SqlDbType.BigInt,8,dataid),
									   db.MakeInParam("@dutytime",SqlDbType.DateTime,8,dutytime),
									   db.MakeInParam("@dutystatus",SqlDbType.Bit,1,dutystatus),
									   db.MakeInParam("@memo",SqlDbType.VarChar,400,memo)
								   };
			try
			{
				return(db.RunProc("sp_WA_RecordOffDutyData",prams));
			}
			catch(Exception e)
			{
				throw e;
			}
		}
	
		#region 得到预设的日期年分
		/// <summary>
		/// 得到预设的日期年分
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetYeasOfSetting()
		{
			Database db = new Database();
			SqlDataReader dr = null;
			try
			{
				db.RunProc("sp_WA_GetYearsOfDaySetting",out dr);
				return(dr);
			}
			catch(Exception e)
			{
				throw e;
			}
		}
		#endregion

	}
}
