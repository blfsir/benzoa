using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace UDS.Components
{
	/// <summary>
	/// Desktop ��ժҪ˵����
	/// </summary>
	/// 
	public class Desktop
	{
		public Desktop()
		{
		
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// �õ��ҵ������ĵ�
		/// </summary>
		/// <param name="UserName">�û���</param>
		/// <param name="RightCode">�鿴�ĵ���Ȩ�޴���</param>
		/// <returns>����dataReader</returns>
		public SqlDataReader GetMyDocument(string UserName,int RightCode)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			// ִ�д洢���̣�������SqlDataReader����
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
				throw new Exception("��ȡ�ҵ��ĵ�����!",ex);
			}
            //finally
            //{
            //    data	   = null;
            //    dataReader = null;
            //}
		}
		/// <summary>
		/// �õ��ҵ������ռ�
		/// </summary>
		/// <param name="UserName">�û���</param>
		/// <param name="MailFolderType">�ռ��д���</param>
		/// <returns>����dataReader</returns>
		public SqlDataReader GetMyMail(string UserName,int MailFolderType)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			// ִ�д洢���̣�������SqlDataReader����
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
				throw new Exception("��ȡ�ҵ��ʼ�����!",ex);
			}
            //finally
            //{
            //    data	   = null;
            //    dataReader = null;
            //}
		}
		/// <summary>
		/// �õ��ҵ���������
		/// </summary>
		/// <param name="UserName">�û���</param>
		/// <param name="RightCode">����Ȩ�޴���</param>
		/// <returns>����dataReader</returns>
		public SqlDataReader GetMyApprove(string UserName,int RightCode)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			// ִ�д洢���̣�������SqlDataReader����
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
				throw new Exception("��ȡ�ҵ���������!",ex);
			}
            //finally
            //{
            //    data	   = null;
            //    dataReader = null;
            //}
		}


        internal DataTable GetMyPostil(string UserName)
        {
            SqlDataReader dr = null; //������������
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
