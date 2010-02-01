using System;
using System.Data;
using System.Data.SqlClient;

namespace UDS.Components
{
	enum AssignRightsAction
	{
		RULE_ADD    =1,
		RULE_DELETE =2,
		ACTIVITY_ADD =3,
		ACTIVITY_DELETE =4,
		ACTIVITY_UPDATE  =5
	};
	/// <summary>
	/// 对权限的操作
	/// </summary>
	public class AssignRights
	{
		#region 添加权限
		/// <summary>
		/// 添加权限
		/// </summary>
		/// <param name="SrcID"></param>
		/// <param name="ObjID"></param>
		/// <param name="BaseOn"></param>
		/// <param name="ProcID"></param>
		/// <returns></returns>
		public int AddRight(long SrcID,long ObjID,int BaseOn,int ProcID) 
		{
			int iReturn=1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			try
			{

				SqlParameter[] parameters = {
												mySQL.MakeInParam("@Act_ID",	SqlDbType.Int,	4,ProcID),
												mySQL.MakeInParam("@Based_On",	SqlDbType.Int,	4,BaseOn),
												mySQL.MakeInParam("@Src_ID",	SqlDbType.Int,	4,SrcID),
												mySQL.MakeInParam("@Obj_ID",	SqlDbType.Int,	4,ObjID)											

										};					
				mySQL.RunProc("sp_AddAssignRule",parameters);				
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return iReturn;
			

		}
		#endregion

		#region 删除权限
		/// <summary>
		/// 删除权限
		/// </summary>
		/// <param name="RuleIDs">权限记录号</param>
		public int DeleteRight(string RuleIDs) 
		{
			int iReturn=1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			try
			{

				SqlParameter[] parameters = {
												mySQL.MakeInParam("@Rule_IDS",SqlDbType.VarChar ,300,RuleIDs)
																					
											};
				mySQL.RunProc("sp_DeleteAssignRule",parameters);		
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return iReturn;
			

		}
		#endregion
		
		#region 获得权限列表
		/// <summary>
		/// 获得权限列表
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="ClassID">权限对象</param>
		/// <param name="dr">返回DataReader</param>
		/// <returns>整形是否成功</returns>
		public int GetProcessList(string UserName,long ClassID,out SqlDataReader dr) 
		{
			int iReturn=1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@UserName",SqlDbType.VarChar ,300,UserName),
											mySQL.MakeInParam("@ClassID",SqlDbType.Int,4,ClassID)											
										};
			dr = null;
			try
			{
				mySQL.RunProc("sp_GetRightListToClass",parameters,out dr);		
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return iReturn;
			

		}
		#endregion

		#region 获得权限列表
		/// <summary>
		/// 获得权限列表
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="ClassID">权限对象</param>
		/// <param name="dr">返回DataTable</param>
		/// <returns>整形是否成功</returns>
		public int GetProcessList(string UserName,long ClassID,out DataTable dt) 
		{
			int iReturn=1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@UserName",SqlDbType.VarChar ,300,UserName),
											mySQL.MakeInParam("@ClassID",SqlDbType.Int,4,ClassID)											
										};
			dt = null;
			try
			{
				mySQL.RunProc("sp_GetRightListToClass",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
				
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return iReturn;
			

		}
		#endregion

		#region 判断用户对对象是否有某个权限
		/// <summary>
		/// 判断用户对对象是否有某个权限
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="classID">被检查的对象</param>		
		/// <param name="actID">权限ID</param>
		/// <returns>是否有权限</returns>
		public bool GetAccessPermission(string UserName,int classID,int actID)
		{
			int flag = 0;
			// 定义数据库操作类及DataReader
			Database data = new Database();
				
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@Class_ID" , SqlDbType.Int, 20, classID),
									   data.MakeInParam("@UserName" , SqlDbType.NVarChar, 20, UserName),
									   data.MakeInParam("@Act_ID" , SqlDbType.Int, 20, actID),
									   // data.MakeInParam("@Inheit" , SqlDbType.Bit, 1, 1),	
									   data.MakeOutParam("@ReturnValue",SqlDbType.Int,20)
								   };
			
			try 
			{
				data.RunProc("sp_GetAccessPermission",prams);
				flag = Int32.Parse(prams[3].Value.ToString());
				return (flag==1)?true:false;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("获取访问权出错",ex);
			}
			finally
			{
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                    data = null;
                }
			}
			
		}
		#endregion

	}
}
