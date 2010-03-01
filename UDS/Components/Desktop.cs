using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace UDS.Components
{
	/// <summary>
	/// Desktop 的摘要说明。
	/// </summary>
	/// 
	public class Desktop
	{
		public Desktop()
		{
		
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 得到我的最新文档
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="RightCode">查看文档的权限代号</param>
		/// <returns>返回dataReader</returns>
		public SqlDataReader GetMyDocument(string UserName,int RightCode)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@UserName" , SqlDbType.VarChar , 300, UserName),
									   data.MakeInParam("@RightCode",SqlDbType.Int,4,RightCode)
								   };
			
			try 
			{
				data.RunProc("sp_GetMyNewDoc",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("读取我的文档出错!",ex);
			}
            //finally
            //{
            //    data	   = null;
            //    dataReader = null;
            //}
		}
		/// <summary>
		/// 得到我的最新收件
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="MailFolderType">收件夹代号</param>
		/// <returns>返回dataReader</returns>
		public SqlDataReader GetMyMail(string UserName,int MailFolderType)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@UserName" , SqlDbType.VarChar   , 20, UserName),
									   data.MakeInParam("@MailFolderType",SqlDbType.Int,4,MailFolderType)
								   };
			
			try 
			{
				data.RunProc("SP_MailGetBriefInfo",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("读取我的邮件出错!",ex);
			}
            //finally
            //{
            //    data	   = null;
            //    dataReader = null;
            //}
		}
		/// <summary>
		/// 得到我的最新审批
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="RightCode">审批权限代号</param>
		/// <returns>返回dataReader</returns>
		public SqlDataReader GetMyApprove(string UserName,int RightCode)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			// 执行存储过程，并返回SqlDataReader对象
			SqlParameter[] prams = {
									   data.MakeInParam("@UserName" , SqlDbType.VarChar , 300, UserName),
									   data.MakeInParam("@RightCode",SqlDbType.Int,4,RightCode)
								   };
			
			try 
			{
				data.RunProc("sp_GetMyApproved",prams,out dataReader);
				return dataReader;

			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("读取我的审批出错!",ex);
			}
            //finally
            //{
            //    data	   = null;
            //    dataReader = null;
            //}
		}


        internal DataTable GetMyPostil(string UserName)
        {
            SqlDataReader dr = null; //存放人物的数据
            Database mySQL = new Database();
            try
            { 
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar,300,UserName)
										};

                mySQL.RunProc("sp_Flow_GetMyPostil", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                return dt;
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }
    }
	
}
