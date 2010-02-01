using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections ;
using System.Configuration;

namespace UDS.Components
{
	/// <summary>
	/// Ŀ¼����
	/// </summary>
	public class DirectoryClass
	{
		#region Ŀ¼���
		/// <summary>
		/// Ŀ¼���
		/// </summary>
		public  void Add(int ParentID,string ProjectName,string ProjectRemark,string Wright,int Status,int Scale,DateTime StartDate,DateTime EndDate)
		{
			
			// �������ݿ�����༰DataReader
			Database data = new Database();
				
			// ִ�д洢���̣�������SqlDataReader����
			SqlParameter[] prams = {
									   data.MakeInParam("@ParentID" , SqlDbType.Int, 20, ParentID),
									   data.MakeInParam("@ProjectName" , SqlDbType.NVarChar, 20, ProjectName),
									   data.MakeInParam("@ProjectRemark" , SqlDbType.NVarChar, 400, ProjectRemark),
									   data.MakeInParam("@Wright" , SqlDbType.NVarChar, 40, Wright),
									   data.MakeInParam("@Status" , SqlDbType.Int, 40, Status),
									   data.MakeInParam("@Scale" , SqlDbType.Int, 20, Scale),
									   data.MakeInParam("@StartDate" , SqlDbType.DateTime, 30, StartDate),
									   data.MakeInParam("@EndDate" , SqlDbType.DateTime, 30, EndDate)
								   };
			
			try 
			{
				data.RunProc("sp_AddProject",prams);
				
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("��Ŀ��ӳ���",ex);
			}
			finally
			{
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
				data	   = null;
			}
			
		}
		#endregion

		#region ��ȡĳ��Ŀ��ϸ��Ϣ
		/// <summary>
		/// ��ȡĳĿ¼��ϸ��Ϣ
		/// </summary>
		/// <param name="ClassID">Ŀ¼ID</param>
		public SqlDataReader GetProjectDetail(int ClassID)
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = 
								{
									data.MakeInParam("@TeamID",	SqlDbType.Int, 20 ,ClassID)
								};
			try
			{
				data.RunProc("sp_GetTeamInfo",prams, out dataReader);
				return dataReader;
			}
						
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				return null;
			}

		}
		#endregion

		#region �޸�ĳĿ¼��Ϣ
		/// <summary>
		/// �޸�ĳĿ¼��Ϣ
		/// </summary>
		/// <param name="ClassID">Ŀ¼ID</param>
		public void Revise(int ClassID,string ProjectName,string ProjectRemark,int Status,int Scale,DateTime StartDate,DateTime EndDate)
		{
			
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@ProjectID" , SqlDbType.Int, 20, ClassID),
									   data.MakeInParam("@ProjectName" , SqlDbType.NVarChar, 20, ProjectName),
									   data.MakeInParam("@ProjectRemark" , SqlDbType.NVarChar, 400, ProjectRemark),
									   data.MakeInParam("@Status" , SqlDbType.Int, 40, Status),
									   data.MakeInParam("@Scale" , SqlDbType.Int, 20, Scale),
									   data.MakeInParam("@StartDate" , SqlDbType.DateTime, 30, StartDate),
									   data.MakeInParam("@EndDate" , SqlDbType.DateTime, 30, EndDate)
								   };
            try
            {
                data.RunProc("sp_UpdateProject", prams);
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());

            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
                 
            }

		}
		#endregion

		#region ɾ��ĳĿ¼
		/// <summary>
		/// ɾ��ĳĿ¼
		/// </summary>
		/// <param name="ClassID">��ĿID</param>
		public void Delete(int ClassID)
		{
			
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, ClassID),
			};
            try
            {
                data.RunProc("sp_DeleteTeam", prams);
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());

            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }

		}
		#endregion
	}
}
