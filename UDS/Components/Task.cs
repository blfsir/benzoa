using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace UDS.Components
{
	/// <summary>
	/// Task 
	/// </summary>
	public class Task
	{
		

		#region 添加任务
		/// <summary>
		/// 任务添加
		/// </summary>
		/// <param name="TaskClass">Task类</param>
		public string AddTask(TaskClass tc) 
		{		
			
			// create data object and params
			Database data = new Database();	
			string TaskID = "";
			SqlParameter[] prams = {
									   data.MakeInParam("@ArrangedBy",  SqlDbType.VarChar, 20, tc.ArrangedBy),
									   data.MakeInParam("@Subject",  SqlDbType.VarChar, 50, tc.Subject),
									   data.MakeInParam("@Detail",  SqlDbType.VarChar, 300, tc.Detail),
									   data.MakeInParam("@ProjectID",  SqlDbType.SmallInt,20, tc.ProjectID),
									   data.MakeInParam("@StartTime",  SqlDbType.DateTime, 20, DateTime.Parse(tc.StartTime.ToString())),
									   data.MakeInParam("@EndTime",  SqlDbType.DateTime, 20, DateTime.Parse(tc.EndTime.ToString())),
									   data.MakeInParam("@Attribute",  SqlDbType.Int, 1, tc.Attribute),
									   data.MakeInParam("@Type",  SqlDbType.Int, 1, tc.Type),
									   data.MakeInParam("@Status",  SqlDbType.Bit , 1, tc.Status),
									   data.MakeInParam("@Tag",  SqlDbType.Int, 1, tc.Tag),
									   data.MakeInParam("@IsAwake",  SqlDbType.Bit, 1, tc.IsAwake),
									   data.MakeInParam("@AwakeTime",  SqlDbType.DateTime, 20, DateTime.Parse(tc.AwakeTime)),
									   data.MakeInParam("@ContractList",  SqlDbType.VarChar, 50, tc.ContractList),
									   data.MakeInParam("@CooperatorList", SqlDbType.VarChar, 200, tc.CooperatorList),
									   data.MakeOutParam("@InsertedTaskID", SqlDbType.Int,20) 
								   };

			try 
			{
				data.RunProc("SP_AddTask", prams);
				TaskID = prams[14].Value.ToString();
				if (TaskID == string.Empty )
					return null;
				else 
					return TaskID;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("任务添加出错!",ex);
			}
			
		}
		#endregion

		#region 添加任务评论
		/// <summary>
		/// 添加任务评论
		/// </summary>
		public bool AddTaskComment(string Username,string Comment,int TaskID) 
		{		
			
			// create data object and params
			Database data = new Database();	
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 200, Username),
									   data.MakeInParam("@Comment",  SqlDbType.VarChar,4000, Comment),
									   data.MakeInParam("@TaskID",  SqlDbType.Int, 6, TaskID)
								   };

			try 
			{
				data.RunProc("sp_Task_AddComment", prams);
				return true;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("任务添加出错!",ex);
			}
		}
		#endregion

		#region 删除任务评论
		/// <summary>
		/// 删除任务评论
		/// </summary>
		public bool DeleteTaskComment(int ID) 
		{		
			
			// create data object and params
			Database data = new Database();	
			SqlParameter[] prams = {
									   data.MakeInParam("@ID",  SqlDbType.Int, 8, ID)
									  
								   };

			try 
			{
				data.RunProc("sp_Task_DeleteComment", prams);
				return true;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("删除任务评论出错!",ex);
			}
			
		}
		#endregion

		#region 添加任务订阅
		/// <summary>
		/// 添加任务订阅
		/// </summary>
		public bool AddTaskSubscription(string Username,string ExUsername,int TaskID,string Date) 
		{		
			
			// create data object and params
			Database data = new Database();	
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 200, Username),
									   data.MakeInParam("@ExUsername",  SqlDbType.VarChar,200, ExUsername),
									   data.MakeInParam("@TaskID",  SqlDbType.Int, 6, TaskID),
									   data.MakeInParam("@Date",  SqlDbType.NVarChar, 30, Date)	
								   };

			try 
			{
				data.RunProc("sp_Task_AddSubscription", prams);
				return true;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("添加任务订阅出错!",ex);
			}
			
		}
		#endregion

		#region 删除任务订阅
		/// <summary>
		/// 删除任务订阅
		/// </summary>
		public bool DeleteTaskSubscription(string Username,string TaskID)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar,200, Username),
									   data.MakeInParam("@TaskID",  SqlDbType.VarChar, 200, TaskID)
									 
								   };

			try 
			{
				data.RunProc("sp_Task_DeleteSubscription",prams);
				return true;				
			
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
                throw new Exception("删除某任务订阅出错!",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                } 
			}			
		}
		#endregion

		#region 添加任务至日程表
		/// <summary>
		/// 添加任务至日程表
		/// </summary>
		public bool AddTaskToSchedule(int TaskID,int PeriodID,string Username,string Date,bool IsConfirm) 
		{		
			
			Database data = new Database();	
			SqlParameter[] prams = {
									   data.MakeInParam("@TaskID",  SqlDbType.Int, 8, TaskID),
									   data.MakeInParam("@PeriodID",  SqlDbType.Int, 8, PeriodID),
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.VarChar,30, Date),
									   data.MakeInParam("@IsConfirm",  SqlDbType.Bit , 1, IsConfirm)
							 	   };

			try 
			{
				data.RunProc("SP_AddTaskToSchedule", prams);
				return true;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("任务添加至日程表出错!",ex);
			}
			
		}
		#endregion

		#region 读取工作时间段信息 SqlDataReader
		/// <summary>
		/// 返回项目相关信息
		/// </summary>
		public SqlDataReader GetPeriodInfo()
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			try 
			{
				data.RunProc("sp_GetPeriodInfo",out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("工作时间段信息读取出错!",ex);
			}
			finally
			{
				data	   = null;
		
			}
			
		}
		#endregion

		#region 检测日程是否冲突
		/// <summary>
		///  检测日程是否冲突
		/// </summary>
		public bool CheckExist(int PeriodID,string Username,string Date) 
		{		
			
			Database data = new Database();	
			bool IsExist = false;
			SqlParameter[] prams = {
									   data.MakeInParam("@PeriodID",  SqlDbType.Int, 8, PeriodID),
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.DateTime,30, DateTime.Parse(Date)),
									   data.MakeOutParam("@IsExist", SqlDbType.Bit ,1)
									};
			try 
			{
				data.RunProc("sp_ScheduleCheckExist", prams);
				IsExist = prams[3].Value.ToString()=="True"?true:false;
				return IsExist;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("检测冲突出错!",ex);
			}
			
		}
		#endregion

		#region 获得某用户某日的任务
		/// <summary>
		/// 获得某用户某日的任务
		/// </summary>
		public SqlDataReader GetDayTaskInSchedule(string Date,string Username)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.VarChar,30, Date)
								    };

			try 
			{
				data.RunProc("sp_GetDayTaskInSchedule",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某用户某日的任务出错!",ex);
			}
			finally
			{
				data	   = null;
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得某任务的状态
		/// <summary>
		/// 获得某任务的状态
		/// </summary>
		public SqlDataReader GetTaskStatus(int TaskID)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@TaskID",  SqlDbType.Int, 20, TaskID)
									   
								   };

			try 
			{
				data.RunProc("sp_GetTaskStatus",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某任务的状态出错!",ex);
			}
			finally
			{
				data	   = null;
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得某用户某任务的状态
		/// <summary>
		/// 获得某任务的状态
		/// </summary>
		public int GetTaskStatusBySomeone(int TaskID,string Username)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@TaskID",  SqlDbType.Int, 20, TaskID),
									   data.MakeInParam("@Username",  SqlDbType.NVarChar, 40, Username)	
									   
								   };

			try 
			{
				data.RunProc("sp_GetTaskStatusBySomeone",prams,out dataReader);
				if(dataReader.Read())
				{
					return Int32.Parse(dataReader[0].ToString());
				}
				else
				{
					return -1;
				}

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某任务的状态出错!",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
				data	   = null;
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得任务的评论列表
		/// <summary>
		/// 获得任务的评论列表
		/// </summary>
		public SqlDataReader GetTaskComment(int TaskID)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@TaskID",  SqlDbType.Int, 20, TaskID)
								   };

			try 
			{
				data.RunProc("sp_GetTaskComment",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得任务的评论列表出错!",ex);
			}
			finally
			{
				data	   = null;
				dataReader = null;
			}
			
		}
		#endregion

		#region 处理任务
		/// <summary>
		/// 接受日程
		/// </summary>
		public SqlDataReader DealTask(string IDS,int opt,string username,string date)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@IDS",  SqlDbType.VarChar, 2000, IDS),
									   data.MakeInParam("@opt",  SqlDbType.Int, 1, opt),
									   data.MakeInParam("@username",  SqlDbType.VarChar, 30, username)
								//	   data.MakeInParam("@date",  SqlDbType.VarChar, 40, date)
									};

			try 
			{
				data.RunProc("sp_DealTask",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("处理日程出错!",ex);
			}
			finally
			{
				data	   = null;
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得某用户某日的详细任务
		/// <summary>
		/// 获得某用户某日的任务
		/// </summary>
		public SqlDataReader GetTodayTaskBySomeone(string Date,string Username,int Type)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.VarChar,30, Date),
									   data.MakeInParam("@Type",  SqlDbType.Int,3, Type)	
								   };

			try 
			{
				data.RunProc("sp_GetTodayTaskBySomeone",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某用户某日的任务出错!",ex);
			}
			finally
			{
				data	   = null;
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得某用户所有的任务列务
		/// <summary>
		/// 获得某用户某日的任务
		/// </summary>
		public SqlDataReader GetAllTaskBySomeone(string Date,string Username,int Type)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.VarChar,30, Date),
									   data.MakeInParam("@Type",  SqlDbType.Int,3, Type)	
								   };

			try 
			{
				data.RunProc("sp_GetAllTaskBySomeone",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某用户所有的任务出错!",ex);
			}
			finally
			{
				data	   = null;
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得某用户某日的前5条任务 返回数组记录ID
		/// <summary>
		/// 获得某用户某日的前5条任务
		/// </summary>
		public string[] GetTop5DayTaskList(string Date,string Username)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			String[] a = new String[5]{"0","0","0","0","0"};
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.VarChar,30, Date)
								   };

			try 
			{
				data.RunProc("sp_GetTop5DayTaskList",prams,out dataReader);
				int c=0;
				while(dataReader.Read())
				{
					a[c] = dataReader[0].ToString();	
					c++;
				}
				dataReader = null;
				return a;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某用户某日的前5条任务出错!",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得前5条已经全部确认的任务列表
		/// <summary>
		/// 获得前5条已经全部确认的任务列表
		/// </summary>
		public string[] GetTop5ConfirmedTaskList(string Date,string Username)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			String[] a = new String[5]{"0","0","0","0","0"};
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.VarChar,30, Date)
								   };

			try 
			{
				data.RunProc("sp_GetTop5ConfirmedTask",prams,out dataReader);
				int c=0;
				while(dataReader.Read())
				{
					if(dataReader[1].ToString()==dataReader[2].ToString())
					a[c] = dataReader[0].ToString();	
					c++;
				}
				dataReader = null;
				return a;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得前5条已经全部确认的任务列表出错!",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得某条任务某天的的时间段
		/// <summary>
		/// 获得某条任务某天的的时间段 返回长度为11的int型数组，如果数组的某个原素没有值，则值为0
		/// </summary>
		public int[] GetTaskPeriod(string Date,string Username,int TaskID)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			int[] a = new int[20]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.VarChar, 20, Username),
									   data.MakeInParam("@Date",  SqlDbType.VarChar,30, Date),
									   data.MakeInParam("@TaskID",  SqlDbType.Int,8, TaskID)	 
								   };

			try 
			{
				data.RunProc("sp_GetTaskPeriod",prams,out dataReader);
			
				while(dataReader.Read()) 
				{
					a[Int32.Parse(dataReader[0].ToString())-1] = 7+Int32.Parse(dataReader[0].ToString());
					
				}


					dataReader = null;
					data.Dispose();
				return a;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某条任务某天的的时间段出错!",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
				dataReader = null;
			}
			
		}
		#endregion

		#region 获得某条任务的详细信息
		/// <summary>
		/// 获得某条任务的详细信息
		/// </summary>
		public TaskClass GetTaskDetail(int TaskID)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			SqlDataReader dataReader = null;
			TaskClass tsk = new TaskClass();
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@TaskID",  SqlDbType.Int,8, TaskID)	 
								   };

			try 
			{
				data.RunProc("sp_GetTaskDetail",prams,out dataReader);
				
				if(dataReader.Read())
				{
					tsk.ArrangedBy     = dataReader["ArrangedBy"].ToString();
					tsk.Detail		   = dataReader["Detail"].ToString();
					tsk.StartTime	   = dataReader["StartTime"].ToString();
					tsk.EndTime		   = dataReader["EndTime"].ToString();
					tsk.ProjectID	   = Int32.Parse(dataReader["ProjectID"].ToString());
					tsk.Subject		   = dataReader["Subject"].ToString();
					tsk.CooperatorList = dataReader["CooperatorList"].ToString();
					tsk.Type		   = Int32.Parse(dataReader["Type"].ToString());
					tsk.Attribute	   = dataReader["Attribute"].ToString()=="True"?1:0;
					tsk.ContractList   = dataReader["ContractList"].ToString();
				}


				dataReader = null;
				data.Dispose();
				return tsk;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获得某条任务某天的的时间段出错!",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
				dataReader = null;
			}
			
		}
		#endregion

		#region 删除某任务
		/// <summary>
		/// 删除某任务
		/// </summary>
		public void DeleteTask(int TaskID)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@TaskID",  SqlDbType.Int,8, TaskID)	 
								   };

			try 
			{
				data.RunProc("sp_DeleteTask",prams);
				data.Dispose();
			
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("删除某任务!",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                } 
			}
			
		}
		#endregion

	}

	public class TaskConflictRecord
	{
		private string m_Username;
		private string m_Period;
		private string m_Date;
		public string Username
		{	
			//冲突者
			get { return m_Username; }
			set { m_Username = value; }
		}

		public string Period
		{	
			//冲突时段
			get { return m_Period; }
			set { m_Period = value; }
		}
		
		public string Date
		{	
			//冲突日期
			get { return m_Date; }
			set { m_Date = value; }
		}
	}
	
	public class TaskClass
	{
		private string m_ArrangedBy;
		private string m_Subject;
		private string m_Detail;
		private int m_Type;
		private int m_ProjectID;
		private string m_StartTime;
		private string m_EndTime;
		private int m_Attribute;
		private int  m_Status;
		private int m_Tag;
		private bool m_IsAwake;
		private string m_AwakeTime;
		private string m_ContractList;
		private string m_CooperatorList;
		
		
		
		public string ArrangedBy
		{	
			//发起人
			get { return m_ArrangedBy; }
			set { m_ArrangedBy = value; }
		}

		public string Subject 
		{	
			//任务主题
			get { return m_Subject; }
			set { m_Subject = value; }
		}
		
		public string Detail 
		{	
			//任务地址
			get { return m_Detail; }
			set { m_Detail = value; }
		}
		
		public int Type 
		{	
			//任务类型
			get { return m_Type; }
			set { m_Type = value; }
		}


		public int ProjectID 
		{	
			//所属项目
			get { return m_ProjectID; }
			set { m_ProjectID = value; }
		}

		public string StartTime 
		{	
			//开始时间
			get { return m_StartTime; }
			set { m_StartTime = value; }
		}

		public string EndTime
		{	
			//结束时间
			get { return m_EndTime; }
			set { m_EndTime = value; }
		}
		
		public int Attribute 
		{	
			//性质
			get { return m_Attribute; }
			set { m_Attribute = value; }
		}
	
		public int Status 
		{	
			//状态
			get { return m_Status; }
			set { m_Status = value; }
		}
				
		public int Tag 
		{	
			//标签
			get { return m_Tag; }
			set { m_Tag = value; }
		}

	
		public bool IsAwake 
		{	
			//是否需要提醒
			get { return m_IsAwake; }
			set { m_IsAwake = value; }
		}

		public string AwakeTime 
		{	
			//提醒时间
			get { return m_AwakeTime; }
			set { m_AwakeTime = value; }
		}

		public string ContractList
		{	
			//联系人列表
			get { return m_ContractList; }
			set { m_ContractList = value; }
		}

		public string CooperatorList
		{	
			//协同人列表
			get { return m_CooperatorList; }
			set { m_CooperatorList = value; }
		}
		
	
	}
}
