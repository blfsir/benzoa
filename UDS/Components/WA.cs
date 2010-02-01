using System;
using System.Data;
using System.Data.SqlClient;
namespace UDS.Components
{
	/// <summary>
	/// ���°�ʱ��
	/// </summary>
	public struct DutyTime
	{
		private DateTime ondutytime;//�ϰ�ʱ��
		private DateTime offdutytime;//�°�ʱ��
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
	/// �õ���ؿ��ڵ���������
	/// </summary>
	public class WA_Setting
	{
		
		private int staffid=0;//��Աid
		
		public WA_Setting()
		{
			
		}
		public WA_Setting(int	StaffID)
		{
			staffid = StaffID;
		}
		/// <summary>
		/// Ա����idֵ
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
		/// �õ�Ա�����°�ʱ��
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
				throw(new Exception("��ȡ��Ա���°�ʱ�����"));
			}
			else
			{
				dt.OnDutyTime = (System.DateTime)prams[1].Value;
				dt.OffDutyTime = (System.DateTime)prams[2].Value;
				return dt;
			}
		}
		/// <summary>
		/// �õ�Ա�����°�ʱ��
		/// </summary>
		/// <param name="Staffid">Ա��id</param>
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
				throw(new Exception("��ȡ��Ա���°�ʱ�����"));
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
	/// ���°�Ķ���
	/// </summary>
	public enum DutyAction
	{
		OnDuty=1,
		OffDuty=2
	}
	/// <summary>
	/// �����ϰ࣬��λ��Ϣ����
	/// </summary>
	public class WA_Duty
	{
		private int staffid;//��Աid
		private TimeSpan ondutyflexibilitytime = new TimeSpan(0,0,0);//�ϰ�ٵ�����ʱ��
		private TimeSpan offdutyflexibilitytime = new TimeSpan(0,0,0);//�°൯��ʱ��
		/// <summary>
		/// ��Աid
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
		/// �ϰ൯��ʱ��
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
		/// �°൯��ʱ��
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
		/// �����Ա�Ƿ��Ѿ�����ϰ࿼��
		/// </summary>
		/// <param name="day">����</param>
		/// <param name="staffid">��Աid</param>
		/// <returns>true ������ falseû����</return>
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
		/// �����Ա�Ƿ��Ѿ�����ϰ࿼��
		/// </summary>
		/// <param name="day">����</param>
		/// <returns>true ������ falseû����</return>
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
		/// �����Ա�Ƿ���ɿ���
		/// </summary>
		/// <param name="day"></param>
		/// <returns>���ڼ�¼��id</returns>
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
		/// ������°�״̬�Ƿ�ٵ�����
		/// </summary>
		/// <param name="action">����DutyAction</param>
		/// <param name="staffid">��Աid</param>
		/// <returns>����ֵ</returns>
		public bool CheckStatus(DutyAction action,int staffid)
		{
			this.staffid = staffid;
			WA_Setting was = new WA_Setting();
			DutyTime dutytime = was.GetDutyTime(staffid);
			//������ϰ�
			if(action==DutyAction.OnDuty)
			{
				if((DateTime.Now.TimeOfDay - ondutyflexibilitytime) > dutytime.OnDutyTime.TimeOfDay)
					return false;
				else
					return true;
			}
			//����°�
			else
			{
				if((DateTime.Now.TimeOfDay + offdutyflexibilitytime) < dutytime.OffDutyTime.TimeOfDay)
					return false;
				else
					return true;
			}
		}
		/// <summary>
		/// ������°�״̬�Ƿ�ٵ�����
		/// </summary>
		/// <param name="action">����DutyAction</param>
		/// <returns>����ֵ</returns>
		public bool CheckStatus(DutyAction action)
		{
			WA_Setting was = new WA_Setting();
			DutyTime dutytime = was.GetDutyTime(staffid);
			//������ϰ�
			if(action==DutyAction.OnDuty)
			{
				if((DateTime.Now - ondutyflexibilitytime)> (DateTime.Today + dutytime.OnDutyTime.TimeOfDay))
					return false;
				else
					return true;
			}
				//����°�
			else
			{
				if((DateTime.Now + offdutyflexibilitytime) < (DateTime.Today + dutytime.OffDutyTime.TimeOfDay))
					return false;
				else
					return true;
			}
		}
		/// <summary>
		/// ���������ݴ������ݿ�
		/// </summary>
		/// <param name="staffid">��Աid</param>
		/// <param name="dutytime">�ϰ�ʱ��</param>
		/// <param name="dutystat">�ϰ�״̬</param>
		/// <param name="memo">����</param>
		/// <returns>�������ݿ��¼id</returns>
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
		/// ���������ݴ������ݿ�
		/// </summary>
		/// <param name="dutytime">�ϰ�ʱ��</param>
		/// <param name="dutystat">�ϰ�״̬</param>
		/// <param name="memo">����</param>
		/// <returns>�������ݿ��¼id</returns>
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
		/// ��¼�°�����
		/// </summary>
		/// <param name="dataid">�ϰ��id</param>
		/// <param name="dutytime">�°��ʱ��</param>
		/// <param name="dutystat">�°�״̬</param>
		/// <param name="memo">����</param>
		/// <returns>�Ƿ����</returns>
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
	
		#region �õ�Ԥ����������
		/// <summary>
		/// �õ�Ԥ����������
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
