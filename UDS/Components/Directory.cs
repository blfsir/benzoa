using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections ;
using System.Configuration;

namespace UDS.Components
{
	/// <summary>
	/// 目录管理
	/// </summary>
	public class DirectoryClass
	{
		#region 目录添加
		/// <summary>
		/// 目录添加
		/// </summary>
		public  void Add(int ParentID,string ProjectName,string ProjectRemark,string Wright,int Status,int Scale,DateTime StartDate,DateTime EndDate)
		{
			
			// 定义数据库操作类及DataReader
			Database data = new Database();
				
			// 执行存储过程，并返回SqlDataReader对象
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
				throw new Exception("项目添加出错",ex);
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

		#region 获取某项目详细信息
		/// <summary>
		/// 获取某目录详细信息
		/// </summary>
		/// <param name="ClassID">目录ID</param>
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

		#region 修改某目录信息
		/// <summary>
		/// 修改某目录信息
		/// </summary>
		/// <param name="ClassID">目录ID</param>
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

		#region 删除某目录
		/// <summary>
		/// 删除某目录
		/// </summary>
		/// <param name="ClassID">项目ID</param>
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
