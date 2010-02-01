using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace UDS.Components
{
	/// <summary>
	/// Team 类
	/// </summary>
	public class Team
	{
		#region 获取组内成员
		/// <summary>
		/// 获取组内成员
		/// </summary>
		public SqlDataReader GetStaffInTeam(int TeamID) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@TeamID",      SqlDbType.Int, 20, TeamID)
								   };
			
   
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffInTeam",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("获取组内成员出错!",ex);
			}
		}
		#endregion	

		#region 获取非组内成员
		/// <summary>
		/// 获取组内成员
		/// </summary>
		public SqlDataReader GetStaffNotInTeam(int TeamID) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@TeamID",      SqlDbType.Int, 20, TeamID)
								   };
			
   
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffNotInTeam",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("获取非组内成员出错!",ex);
			}
		}
		#endregion	

		#region 获取组的订阅人
		/// <summary>
		/// 获取组的订阅人
		/// </summary>
		public SqlDataReader GetStaffSubscriptionTeam(int TeamID) 
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@TeamID",      SqlDbType.Int, 20, TeamID)
								   };
			
   
			try 
			{
				// run the stored procedure
				data.RunProc("sp_GetStaffSubscriptionTeam",prams,out dataReader);
				return dataReader;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("获取组的订阅人出错!",ex);
			}
		}
		#endregion	

		#region 从组中删除某成员
		/// <summary>
		/// 从组中删除某成员
		/// </summary>
		/// <param name="staffids">人员id集合</param>
		/// <returns>是否成功</returns>
		public bool DeleteStaffFromTeam(string staffids,int TeamID)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,staffids),
									   db.MakeInParam("@TeamID",SqlDbType.Int,8,TeamID)
								   };
			try
			{
				return((db.RunProc("sp_DeleteStaffFromTeam",prams)==0)?true:false);	
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("从组中删除某成员!",ex);
			}
		}
		#endregion

		#region 设置组长
		/// <summary>
		/// 设置组长
		/// </summary>
		/// <param name="staffids">人员id集合</param>
		/// <returns>是否成功</returns>
		public bool SetLeader(string staffids,int TeamID)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,staffids),
									   db.MakeInParam("@TeamID",SqlDbType.Int,8,TeamID)	
								   };
			try
			{
				return((db.RunProc("sp_SetupLeader",prams)==0)?true:false);	
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("设置组长出错!",ex);
			}
		}
		#endregion

		#region 加入成员至组
		/// <summary>
		/// 加入成员至组
		/// </summary>
		/// <param name="staffids">人员id集合</param>
		/// <returns>是否成功</returns>
		public bool AddMemberToTeam(string staffids,int TeamID)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,staffids),
									   db.MakeInParam("@TeamID",SqlDbType.Int,8,TeamID)	
								   };
			try
			{
				return((db.RunProc("sp_AddStaffToTeam",prams)==0)?true:false);	
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("加入成员至组出错!",ex);
			}
		}
		#endregion

	}
}
