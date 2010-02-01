using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace UDS.Components
{
	/// <summary>
	/// Team ��
	/// </summary>
	public class Team
	{
		#region ��ȡ���ڳ�Ա
		/// <summary>
		/// ��ȡ���ڳ�Ա
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
				throw new Exception("��ȡ���ڳ�Ա����!",ex);
			}
		}
		#endregion	

		#region ��ȡ�����ڳ�Ա
		/// <summary>
		/// ��ȡ���ڳ�Ա
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
				throw new Exception("��ȡ�����ڳ�Ա����!",ex);
			}
		}
		#endregion	

		#region ��ȡ��Ķ�����
		/// <summary>
		/// ��ȡ��Ķ�����
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
				throw new Exception("��ȡ��Ķ����˳���!",ex);
			}
		}
		#endregion	

		#region ������ɾ��ĳ��Ա
		/// <summary>
		/// ������ɾ��ĳ��Ա
		/// </summary>
		/// <param name="staffids">��Աid����</param>
		/// <returns>�Ƿ�ɹ�</returns>
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
				throw new Exception("������ɾ��ĳ��Ա!",ex);
			}
		}
		#endregion

		#region �����鳤
		/// <summary>
		/// �����鳤
		/// </summary>
		/// <param name="staffids">��Աid����</param>
		/// <returns>�Ƿ�ɹ�</returns>
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
				throw new Exception("�����鳤����!",ex);
			}
		}
		#endregion

		#region �����Ա����
		/// <summary>
		/// �����Ա����
		/// </summary>
		/// <param name="staffids">��Աid����</param>
		/// <returns>�Ƿ�ɹ�</returns>
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
				throw new Exception("�����Ա�������!",ex);
			}
		}
		#endregion

	}
}
