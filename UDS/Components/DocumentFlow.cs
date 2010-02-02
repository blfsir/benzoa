using System;
using System.Data;
using System.Data.SqlClient;

namespace UDS.Components
{
	#region �������ĺ���
	/// <summary>
	/// DocumentFlow ��ժҪ˵����
	/// </summary>
	public class DocumentFlow
	{

		//////////////////////////////////////////
		///				������ת
		//////////////////////////////////////////
		
		#region ����ĵ�
		/// <summary>
		/// ����ĵ�
		/// </summary>
		/// <param name="UserName">�����</param>
		/// <param name="FlowID">��������ID</param>
		/// <param name="SQL">��ʽ�����ݵ�SQL���</param>
		public int AddDocument(string UserName,long FlowID,string SQL)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocBuilder",SqlDbType.VarChar,300,UserName),
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@SQL",SqlDbType.NText,4000,SQL)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_AddDocument",parameters);		
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

		#region ɾ���ĵ�
		/// <summary>
		/// ɾ���ĵ�
		/// </summary>
		/// <param name="DocID">��ɾ�����ĵ�ID</param>
		public int DeleteDocument(long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_DeleteDocument",parameters);		
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

		#region �޸��ĵ�
		/// <summary>
		/// �޸��ĵ�
		/// </summary>
		/// <param name="UpdateSQL">�����ĵ����</param>
		public int UpdateDocument(string UpdateSQL)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@SQL",SqlDbType.NText,4000,UpdateSQL)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_UpdateDocument",parameters);		
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

		#region �ĵ�ǩ��
		/// <summary>
		/// �ĵ�ǩ��
		/// </summary>
		/// <param name="UserName">ǩ����</param>
		/// <param name="DocID">Ҫ��ǩ�յ��ĵ�ID</param>
		public int SignInDocument(string UserName,long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar ,300,UserName),
											mySQL.MakeInParam("@DocID",SqlDbType.Int,4,DocID)											
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_SignINDoc",parameters);		
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

		#region ȡ��ǩ��
		/// <summary>
		/// ȡ��ǩ��
		/// </summary>
		/// <param name="UserName">ǩ����</param>
		/// <param name="DocID">��ȡ�����ĵ�ID</param>
		public int CancelSignInDocument(string UserName,long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar ,300,UserName),
											mySQL.MakeInParam("@DocID",SqlDbType.Int,4,DocID)											
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_CancelSignINDoc",parameters);		
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

		#region �����ע
		/// <summary>
		/// �����ע
		/// </summary>
		/// <param name="UserName">��ע��</param>
		/// <param name="DocID">��ע���ĵ�ID</param>
		/// <param name="PostilType">��ע���ͣ�ͨ�����ܾ������</param>
		public int AddPostil(string UserName,long DocID,string Postil,int PostilType,long ObjID,long ObjType)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID),											
											mySQL.MakeInParam("@Postiler",SqlDbType.VarChar  ,300,UserName),
											mySQL.MakeInParam("@PostilContent",SqlDbType.NText,3000,Postil),
											mySQL.MakeInParam("@PostilType",SqlDbType.Int   ,4,PostilType),
											mySQL.MakeInParam("@ObjID",SqlDbType.Int   ,4,ObjID),
											mySQL.MakeInParam("@ObjType",SqlDbType.Int   ,4,ObjType)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_AddPostil",parameters);		
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

		#region ����ĵ�
		/// <summary>
		/// ����ĵ�
		/// </summary>
		/// <param name="DocID">��������ĵ�ID</param>
		public int FaileDocument(long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_FaileDocument",parameters);		
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

		#region ����ĵ�
		/// <summary>
		/// ����ĵ�
		/// </summary>
		/// <param name="DocID">����ص��ĵ�ID</param>
		public int BackDocument(long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_BackDocument",parameters);		
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

		#region ͨ���ĵ�
		/// <summary>
		/// ͨ���ĵ�
		/// </summary>
		/// <param name="UserName">������</param>
		/// <param name="DocID">��ǰ�ĵ�ID</param>		
		/// <param name="ProjectID">������ĿID</param>
		public int PostDocument(string UserName,long DocID,long ProjectID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar,300,UserName),
											mySQL.MakeInParam("@DocID",SqlDbType.VarChar,300,DocID),											
											mySQL.MakeInParam("@ProjectID",SqlDbType.Int,4,ProjectID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_PostDocument",parameters);		
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

		#region �����ĵ�
		/// <summary>
		/// �����ĵ�
		/// </summary>
		/// <param name="DocID">���������ĵ�ID</param>
		public int FinishDocument(long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_FinishDocument",parameters);		
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

		#region ɾ���ĵ��������ע
		/// <summary>
		/// ɾ���ĵ��������ע
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		public int CancelPostil(long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_CancelPostil",parameters);		
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
		
		#region ��ò�����ת����
		/// <summary>
		/// ��ò�����ת����
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		public int GetStepRule(long FlowID,long StepID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int,4,StepID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_GetStepRule",parameters);		
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

		#region ��ò������Ȩ��
		/// <summary>
		/// ��ò������Ȩ��
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		public int GetStepRightToFinish(long FlowID,long StepID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int,4,StepID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_GetStepRightToFinish",parameters);		
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
		
		#region ����ĵ����Ƿ�Ϊ�����
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>		
		public int IsNewDocument(long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_IsNewDocument",parameters);		
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

		#region ����û����е���Ŀ�����ر��
		/// <summary>
		/// ����û����е���Ŀ
		/// </summary>
		/// <param name="UserName">�û���</param>
		/// <param name="dt">���ر��</param>
		public int GetProject(string UserName,out DataTable dt )
		{
			//int iReturn=0;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@UserName",SqlDbType.VarChar ,300,UserName)
										};
			
			try
			{
				mySQL.RunProc("sp_GetTaskClass",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion
		
		#region ����û����е���Ŀ�����ر��
			/// <summary>
			/// ����û����е���Ŀ
			/// </summary>
			/// <param name="UserName">�û���</param>
			/// <param name="dt">���ر��</param>
			public int GetProject(string UserName,out SqlDataReader dr )
			{
				//int iReturn=0;
				dr = null;
				UDS.Components.Database mySQL = new UDS.Components.Database();
				SqlParameter[] parameters = {
												mySQL.MakeInParam("@UserName",SqlDbType.VarChar ,300,UserName)
											};
			
				try
				{
					mySQL.RunProc("sp_GetTaskClass",parameters,out dr);							
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
				return 0;
			}		
		#endregion

		#region ����ĵ�����ע,���ؼ�¼��
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dr">���ر��</param>
		public int GetDocumentPostil(long DocID,out SqlDataReader dr )
		{
			//int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetDocumentPostil",parameters,out dr);		
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dr = null;
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ����ĵ�����ע,���ر��
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dt">���ر��</param>
		public int GetDocumentPostil(long DocID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetDocumentPostil",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ����ĵ�����Ϣʵ��,���ؼ�¼��
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dr">���ؼ�¼��</param>
		public int GetDocumentInfo(long DocID,out SqlDataReader dr )
		{
			//int iReturn=-1;
			//SqlDataReader dd;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetDocumentInfo",parameters,out dr);						
			}
			catch(Exception e)
			{
				dr = null;
				Error.Log(e.ToString());
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ����ĵ�����Ϣʵ��,���ر��
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dr">���ر��</param>
		public int GetDocumentInfo(long DocID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetDocumentInfo",parameters,out dr);						
				dt =UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				dt = null;
				Error.Log(e.ToString());
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		

		#region ��ò����Ա,���ر��
		/// <summary>
		/// ��û��ڳ�Ա,���ر��
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		/// <param name="dt">���ر��</param>
		public int GetStaffInStep(long FlowID,long StepID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)											
											
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetStaffInStep",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ��ò����Ա,���ر��
		/// <summary>
		/// ��û��ڳ�Ա,���ر��
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dt">���ر��</param>
		public int GetStaffInStep(long DocID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)																						
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetStaffInStep_Ex",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ��ò��������Ա,���ر��
		/// <summary>
		/// ��ò��������Ա,���ر��
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dt">���ر��</param>
		public int GetReceiver(long DocID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetReceiver",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ��ò����Ѿ�ǩ����Ա,���ر��
		/// <summary>
		/// ��ò����Ѿ�ǩ����Ա,���ر��
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dt">���ر��</param>
		public int GetSignIner(long DocID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetSignIner",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ��ò���δǩ����Ա,���ر��
		/// <summary>
		/// ��ò���δǩ����Ա,���ر��
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dt">���ر��</param>
		public int GetUnSignIner(long DocID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetUnSignIner",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ��ò����Ѿ�������Ա,���ر��
		/// <summary>
		/// ��ò����Ѿ�������Ա,���ر��
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dt">���ر��</param>
		public int GetPostiler(long DocID,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetPostiler",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region �������ͷ��Ϣ,���ر��
		/// <summary�������ͷ��Ϣ
		/// ��û����Ѿ�������Ա,���ر��
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="dt">���ر��</param>
		public string GetStyleHeadline(long FlowID)
		{
			string str="";
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetStyleHead",parameters,out dr);		
				if(dr.Read())
				{
					str = dr["Flow_Name"].ToString() + "(��ˮ��:" + string.Format(dr["Times"].ToString(),"03d") + ")";
				}
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
			return str;
		}		
		#endregion			

		#region ����ĵ��ĸ���,���ر��
		/// <summary>
		/// ����ĵ��ĸ���,���ر��
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <param name="dt">���ر��</param>
		public int GetDocumentAttach(long DocID,out DataTable dt)
		{			
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetDocumentAttach",parameters,out dr);		

				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				throw new Exception("��ù��ĵĸ�������",e);
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion			

		#region ��ӹ��ĸ������ݿ�
		/// <summary>
		/// ����ļ��������ݿ����
		/// </summary>
		/// <param name="att">DocAttachFile��</param>
		/// <param name="DocID">�ļ�ID</param>
		public void AddAttach(UDS.Components.DocAttachFile att,long DocID) 
		{		
			
			UDS.Components.Database data = new UDS.Components.Database();	
			SqlParameter[] prams = {
									   data.MakeInParam("@DocID",  SqlDbType.Int, 20, DocID),
									   data.MakeInParam("@FileName",  SqlDbType.VarChar, 300, att.FileName),
									   data.MakeInParam("@FileSize",  SqlDbType.Int, 20, att.FileSize),
									   data.MakeInParam("@FileAttribute",  SqlDbType.SmallInt,20, att.FileAttribute),
									   data.MakeInParam("@FileVisualPath",  SqlDbType.NVarChar, 200, att.FileVisualPath),
									   data.MakeInParam("@FileAuthor",  SqlDbType.NVarChar, 50, att.FileAuthor),
									   data.MakeInParam("@FileCatlog",  SqlDbType.NVarChar, 20, att.FileCatlog),
									   data.MakeInParam("@FileAddedDate", SqlDbType.DateTime, 30, DateTime.Parse(att.FileAddedDate))
								   };
			try 
			{
				data.RunProc("sp_Flow_AddFile", prams);
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("�ļ��������ͳ���!",ex);
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

		#region ɾ�����ĸ������ݿ�
		/// <summary>
		/// ɾ���ļ��������ݿ����
		/// </summary>
		/// <param name="DocID">�ļ�ID</param>
		public void DeleteAttach(long DocID) 
		{		
			
			UDS.Components.Database data = new UDS.Components.Database();	
			SqlParameter[] prams = {
									   data.MakeInParam("@DocID",  SqlDbType.Int, 20, DocID)
								   };
			try 
			{
				data.RunProc("sp_Flow_DeleteFile", prams);
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("�ļ�����ɾ������!",ex);
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

		#region ��ù��ĸ�����
		/// <summary>
		/// ��ù��ĸ�����
		/// </summary>
		/// <param name="DocID">�ļ�ID</param>
		public string GetAttachName(long DocID) 
		{		
			
			string AttachName="";

			UDS.Components.Database data = new UDS.Components.Database();	
			SqlDataReader dr = null;
			
			SqlParameter[] prams = {
									   data.MakeInParam("@DocID",  SqlDbType.Int, 20, DocID)
								   };
			try 
			{
				data.RunProc("sp_Flow_GetDocumentAttach", prams,out dr);
				if(dr.Read())
					AttachName = dr["FileVisualPath"].ToString() + dr["FileName"].ToString();
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("����ļ�������!",ex);
			}			
			finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
                if (dr != null)
                {
                    dr.Close();
                }
				 
			}
			return AttachName;
		}
		#endregion

        //��������ϴ�������ͼͼƬ������
        public string GetFlowAttachName(long FlowID)
        {

            string AttachName = "";

            UDS.Components.Database data = new UDS.Components.Database();
            SqlDataReader dr = null;

            SqlParameter[] prams = {
									   data.MakeInParam("@FlowID",  SqlDbType.Int, 20, FlowID)
								   };
            try
            {
                data.RunProc("sp_Flow_GetFlowAttach", prams, out dr);
                if (dr.Read())
                    AttachName =  dr["flow_chat"].ToString();
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("����ļ�������!", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
                if (dr != null)
                {
                    dr.Close();
                }

            }
            return AttachName;
        }

		#region ��ӹ�����ע�������ݿ�
		/// <summary>
		/// ����ļ���ע�������ݿ����
		/// </summary>
		/// <param name="att">DocAttachFile��</param>
		/// <param name="DocID">�ļ�ID</param>
		public void AddPostilAttach(UDS.Components.DocAttachFile att,long PostilID) 
		{		
			
			UDS.Components.Database data = new UDS.Components.Database();	
			SqlParameter[] prams = {
									   data.MakeInParam("@PostilID",  SqlDbType.Int, 20, PostilID),
									   data.MakeInParam("@FileName",  SqlDbType.VarChar, 300, att.FileName),
									   data.MakeInParam("@FileSize",  SqlDbType.Int, 20, att.FileSize),
									   data.MakeInParam("@FileAttribute",  SqlDbType.SmallInt,20, att.FileAttribute),
									   data.MakeInParam("@FileVisualPath",  SqlDbType.NVarChar, 200, att.FileVisualPath),
									   data.MakeInParam("@FileAuthor",  SqlDbType.NVarChar, 50, att.FileAuthor),
									   data.MakeInParam("@FileCatlog",  SqlDbType.NVarChar, 20, att.FileCatlog),
									   data.MakeInParam("@FileAddedDate", SqlDbType.DateTime, 30, DateTime.Parse(att.FileAddedDate))
								   };
            try
            {
                data.RunProc("sp_Flow_AddPostilFile", prams);
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ļ��������ͳ���!", ex);
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

		#region ����ĵ���������ĿID
		/// <summary>
		/// ����ĵ���������ĿID
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		public static int GetDocumentProjectID(long DocID)
		{			
			int iReturn=0;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_GetDocumentProjectID",parameters);		

			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				throw new Exception("��ù��ĵ���ĿID����",e);
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return iReturn;
		}		
		#endregion			

		#region ����Ƿ�����Ŀ��ת
		/// <summary>
		/// ����Ƿ�����Ŀ��תID
		/// </summary>
		/// <param name="UserName">�û���</param>
		/// <param name="DocID">�ĵ�ID</param>
		public bool IsProject(string UserName,long DocID)
		{			
			bool iReturn = false;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar,100,UserName),
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetPrePostInfo",parameters,out dr);		
				if(dr.Read())
				{
					if(dr["Flow_Rule"].ToString()=="2")
						iReturn = true;
				}

				dr.Close();
				dr = null;

			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				throw new Exception("����Ƿ�����Ŀ��ת����",e);
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return iReturn;
		}		
		#endregion			

		/////////////////////////////////////////////
		///				�����Զ����
        /////////////////////////////////////////////


        #region �Զ�����ֶ�����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FieldName">�ֶ�������</param>
        /// <param name="isDdl">�Ƿ���ʾΪ�����б�dropdownlist</param>
        /// <returns></returns>
        public int AddField(string FieldName, int isDdl)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@FieldName",SqlDbType.VarChar,100,FieldName),
											mySQL.MakeInParam("@isddl",SqlDbType.Bit,1,isDdl),
											 
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_AddField", parameters);
            }
            catch (Exception e)
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

        public int DeleteField(int FieldID)
        {

            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@FieldID",SqlDbType.Int,4,FieldID)
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_DeleteField", parameters);
            }
            catch (Exception e)
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

        public int UpdateField(int FieldID, string FieldName, int isDdl)
        {

            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@FieldID",SqlDbType.Int,4,FieldID),
											mySQL.MakeInParam("@FieldName",SqlDbType.VarChar,100,FieldName),
											mySQL.MakeInParam("@isddl",SqlDbType.Bit,1,isDdl),
										};
            try
            { 
                iReturn = mySQL.RunProc("sp_Flow_UpdateField", parameters);
            }
            catch (Exception e)
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

        public int UpdateBoard(int BoardID, string title, string content)
        {

            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@BoardID",SqlDbType.Int,4,BoardID),
												mySQL.MakeInParam("@BoardName",SqlDbType.VarChar,200,title),
											mySQL.MakeInParam("@BoardContent",SqlDbType.NText,20000,content),
											
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_UpdateBoard", parameters);
            }
            catch (Exception e)
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

        public int UpdateNews(int BoardID, string title, string content)
        {

            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@NewsID",SqlDbType.Int,4,BoardID),
											 mySQL.MakeInParam("@NewsName",SqlDbType.VarChar,200,title),
											mySQL.MakeInParam("@NewsContent",SqlDbType.NText,20000,content),
											
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_UpdateNews", parameters);
            }
            catch (Exception e)
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

        #region ����Զ�������
        /// <summary>
		/// ����Զ�������
		/// </summary>
		/// <param name="StyleName">�����</param>
		/// <param name="StyleRemark">���ID</param>
		/// <param name="Teamplate">ģ��·��</param>
		public int AddStyle(string StyleName,string StyleRemark,string Teamplate)
		{

			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleName",SqlDbType.VarChar,100,StyleName),
											mySQL.MakeInParam("@StyleRemark",SqlDbType.VarChar,100,StyleRemark),
											mySQL.MakeInParam("@Teamplate",SqlDbType.VarChar,100,Teamplate)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_AddStyle",parameters);		
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

		#region ɾ���Զ�������
		/// <summary>
		/// ɾ���Զ�������
		/// </summary>
		/// <param name="StyleID">���ID</param>
		public int DeleteStyle(long StyleID,string Path)
		{

			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int,4,StyleID)
										};
			try
			{
				DeleteTemplate(StyleID,Path);		//ɾ��ģ��ʵ��
				iReturn = mySQL.RunProc("sp_Flow_DeleteStyle",parameters);						
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

		#region �޸��Զ�������
		/// <summary>
		/// �޸��Զ�������
		/// </summary>
		/// <param name="StyleID">���ID</param>
		/// <param name="StyleName">�����</param>
		/// <param name="StyleRemark">���ID</param>
		/// <param name="Teamplate">ģ��·��</param>
		public int UpdateStyle(long StyleID,string StyleName,string StyleRemark,string Teamplate,string Path)
		{

			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int,4,StyleID),
											mySQL.MakeInParam("@StyleName",SqlDbType.VarChar,100,StyleName),
											mySQL.MakeInParam("@StyleRemark",SqlDbType.VarChar,100,StyleRemark),
											mySQL.MakeInParam("@Teamplate",SqlDbType.VarChar,100,Teamplate)
										};
			try
			{
				DeleteTemplate(StyleID,Path);
				iReturn = mySQL.RunProc("sp_Flow_UpdateStyle",parameters);		
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

		#region ����Զ�������ϸ����
		/// <summary>
		/// ����Զ�������ϸ����
		/// </summary>
		/// <param name="StyleID">�����ID</param>
		/// <param name="FieldName">�ﶨ�ֶ���</param>
		/// <param name="FieldDescription">�ֶ�����</param>
		/// <param name="Judged">�Ƿ���Ϊ�����ж��ֶ�</param>
		/// <param name="MultiLine">�Ƿ����</param>
		/// <param name="Height">�ؼ��߶�</param>
		/// <param name="Width">�ؼ���</param>
		/// <param name="Position">�ؼ��ڱ��е�λ��</param>
		/// <param name="Example">���ʾ��</param>

		public int AddStyleDescription(long StyleID,string FieldName,string FieldDescription,int Judged,int MultiLine,int Height,int Width,int Position,string Example,string FieldType)
		{

			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int,4,StyleID),
											mySQL.MakeInParam("@FieldName",SqlDbType.VarChar,100,FieldName),
											mySQL.MakeInParam("@FieldDescription",SqlDbType.VarChar,100,FieldDescription),
											mySQL.MakeInParam("@Judged",SqlDbType.Int,4,Judged),
											mySQL.MakeInParam("@MultiLine",SqlDbType.Int,4,MultiLine),
											mySQL.MakeInParam("@Height",SqlDbType.Int,4,Height),
											mySQL.MakeInParam("@Width",SqlDbType.Int,4,Width),
											mySQL.MakeInParam("@Position",SqlDbType.Int,4,Position),
											mySQL.MakeInParam("@Example",SqlDbType.VarChar,100,Example),
                                            mySQL.MakeInParam("@FieldType",SqlDbType.VarChar,100,FieldType)

										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_AddStyle_Description",parameters);		
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

		#region ɾ���Զ���������ϸ����
		/// <summary>
		/// ɾ���Զ���������ϸ���壬һ�ж����ʾһ���ؼ�
		/// </summary>
		/// <param name="DescriptionID">�����ϸ����ID</param>
		public int DeleteStyleDescription(long DescriptionID)
		{

			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DescriptionID",SqlDbType.Int,4,DescriptionID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_DeleteStyle_Description",parameters);		
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

		#region �޸��Զ�������ϸ����
		/// <summary>
		/// �޸��Զ�������ϸ����
		/// </summary>
		/// <param name="DescriptionID">�����ϸ����ID</param>
		/// <param name="StyleID">�����ID</param>
		/// <param name="FieldName">�ﶨ�ֶ���</param>
		/// <param name="FieldDescription">�ֶ�����</param>
		/// <param name="Judged">�Ƿ���Ϊ�����ж��ֶ�</param>
		/// <param name="MultiLine">�Ƿ����</param>
		/// <param name="Height">�ؼ��߶�</param>
		/// <param name="Width">�ؼ���</param>
		/// <param name="Position">�ؼ��ڱ��е�λ��</param>
		/// <param name="Example">���ʾ��</param>

        public int UpdateStyleDescription(long DescriptionID, long StyleID, string FieldName, string FieldDescription, int Judged, int MultiLine, int Height, int Width, int Position, string Example, string FieldType)
		{

			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DescriptionID",SqlDbType.Int,4,DescriptionID),
											mySQL.MakeInParam("@StyleID",SqlDbType.Int,4,StyleID),
											mySQL.MakeInParam("@FieldName",SqlDbType.VarChar,100,FieldName),
											mySQL.MakeInParam("@FieldDescription",SqlDbType.VarChar,100,FieldDescription),
											mySQL.MakeInParam("@Judged",SqlDbType.Int,4,Judged),
											mySQL.MakeInParam("@MultiLine",SqlDbType.Int,4,MultiLine),
											mySQL.MakeInParam("@Height",SqlDbType.Int,4,Height),
											mySQL.MakeInParam("@Width",SqlDbType.Int,4,Width),
											mySQL.MakeInParam("@Position",SqlDbType.Int,4,Position),
											mySQL.MakeInParam("@Example",SqlDbType.VarChar,100,Example),
                                              mySQL.MakeInParam("@FieldType",SqlDbType.VarChar,100,FieldType)

										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_UpdateStyle_Description",parameters);		
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

		#region ����Զ�������һ����ϸ����
		/// <summary>
		/// ��õ�һ��ʽ����
		/// </summary>
		/// <param name="StyleID">����ID</param>
		/// <param name="dr">���ݼ���</param>
		public int GetDescription(long DescriptionID,out SqlDataReader dr )
		{
			//int iReturn=-1;
			dr = null;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DescriptionID",SqlDbType.Int ,4,DescriptionID)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetDescription",parameters,out dr);		
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ͨ������ID�õ�����ģ����
		/// <summary>
		/// ͨ������ID�õ�����ģ����
		/// </summary>
		/// <param name="FlowID">����ID</param>
		public string GetStyleTemplate(long FlowID)
		{
			string str="";
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeOutParam("@Template",SqlDbType.VarChar,100)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetStyleTemplate",parameters);		
				str = parameters[1].Value.ToString();
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				throw new Exception("��ñ��ģ�����!",e);
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			
			if(str.Length>0)
				return @"Template\" + str;
			else
				return "";
		}
		#endregion

		#region ͨ����ID�õ�����ģ����
		/// <summary>
		/// ͨ����ID�õ�����ģ����
		/// </summary>
		/// <param name="FlowID">����ID</param>
		public string GetStyleTemplateEx(long StyleID)
		{
			string str="";
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int ,4,StyleID),
											mySQL.MakeOutParam("@Template",SqlDbType.VarChar,100)
										};
			
			try
			{
				mySQL.RunProc("sp_Flow_GetStyleTemplateEx",parameters);		
				str = parameters[1].Value.ToString();
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				throw new Exception("��ñ��ģ�����!",e);
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			
			if(str.Length>0)
				return @"Template\" + str;
			else
				return "";
		}
		#endregion

		#region ɾ��ģ��ʵ��
		/// <summary>
		/// ɾ��ģ��ʵ��
		/// </summary>		
		/// <param name="StyleID">�����ID</param>
		/// <param name="Path">·��</param>
		public int DeleteTemplate(long StyleID,string Path)
		{

			int iReturn=0;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlDataReader dr;			
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int,4,StyleID)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetStyle",parameters,out dr);		
				if(dr.Read())
				{
					string FileName;
					FileName = Path + "\\" + dr["Template"].ToString();

					if(System.IO.File.Exists(FileName)==true)
					{
						System.IO.File.Delete(FileName);
					}
				}
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

		#region ������̵ı����ʽ����
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="Judged">�Ƿ���������жϵ��ֶ�</param>
		/// <param name="dr">���ݼ���</param>
		public int GetStyleDescription(long FlowID,int Judged,out SqlDataReader dr )
		{
			//int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@Judged",SqlDbType.Int ,4,0)
										};
			
			try
			{
				mySQL.RunProc("sp_flow_getstyle_description",parameters,out dr);		
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dr = null;
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return 0;
		}


        public DataTable GetFieldValueList(int FieldID)
        {
            DataTable dtFieldValueList = new DataTable();
            SqlDataReader dr;
            Database db = new Database();
            SqlParameter[] parms = {
										db.MakeInParam("@FieldID",SqlDbType.Int  ,4,FieldID),
									};
            db.RunProc("sp_Flow_GetFieldValue_all", parms, out dr);
            try
            {
               dtFieldValueList= UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
            }

            return dtFieldValueList;
        }		
		#endregion

		#region ������̵ı����ʽ����
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="StyleID">����ID</param>
		/// <param name="dr">���ݼ���</param>
		public int GetStyleDescription(long StyleID,out SqlDataReader dr )
		{
			//int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int ,4,StyleID)
										};
			
			try
			{
				mySQL.RunProc("sp_flow_getstyle_description_ex",parameters,out dr);		
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dr = null;
			}
			finally
			{
				//mySQL.Close();
				//mySQL = null;	
			}
			return 0;
		}		
		#endregion

		#region ������̵ı����ʽ����
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="Judged">�Ƿ���������жϵ��ֶ�</param>
		/// <param name="dt">���ر��</param>
		public int GetStyleDescription(long FlowID,int Judged,out DataTable dt )
		{
			//int iReturn=-1;
			SqlDataReader dr;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@Judged",SqlDbType.Int ,4,0)
										};
			
			try
			{
				mySQL.RunProc("sp_flow_getstyle_description",parameters,out dr);		
				dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}	
		#endregion

		//////////////////////////////////////////////
		///				���̹������
		//////////////////////////////////////////////

		#region �������
		/// <summary>
		/// �������
		/// </summary>
		/// <param name="FlowName">������</param>
		/// <param name="FlowRemark">���̼��</param>
		/// <param name="Builder">�����ƶ���</param>
		/// <param name="StyleID">�����Զ����</param>
		public int AddFlow(string FlowName,string FlowRemark,string Builder,long StyleID,string FlowClass)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowName",SqlDbType.VarChar ,300,FlowName),
											mySQL.MakeInParam("@FlowRemark",SqlDbType.NText ,3000,FlowRemark ),
											mySQL.MakeInParam("@Builder",SqlDbType.VarChar,300,Builder),
											mySQL.MakeInParam("@StyleID",SqlDbType.Int ,4,StyleID),
                                            mySQL.MakeInParam("@FlowClass",SqlDbType.VarChar,100,FlowClass) 
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_AddFlow",parameters);		
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

		#region ɾ������
		/// <summary>
		/// ɾ������
		/// </summary>
		/// <param name="FlowID">��ɾ��������ID</param>
		public int DeleteFlow(long FlowID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_DeleteFlow",parameters);		
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

		#region �޸�����
		/// <summary>
		/// �޸�����
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="FlowName">������</param>
		/// <param name="FlowRemark">���̼��</param>
		/// <param name="Builder">�����ƶ���</param>
		/// <param name="StyleID">�����Զ����</param>
        public int UpdateFlow(long FlowID, string FlowName, string FlowRemark, string Builder, long StyleID, string FlowClass)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@FlowName",SqlDbType.VarChar ,300,FlowName),
											mySQL.MakeInParam("@FlowRemark",SqlDbType.NText ,3000,FlowRemark ),
											mySQL.MakeInParam("@Builder",SqlDbType.VarChar,300,Builder),
											mySQL.MakeInParam("@StyleID",SqlDbType.Int ,4,StyleID),
                                            mySQL.MakeInParam("@FlowClass",SqlDbType.VarChar,100,FlowClass)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_UpdateFlow",parameters);		
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

		#region �õ����̻�����Ϣ
		/// <summary>
		/// �õ����̻�����Ϣ
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="dt">���ر��</param>
		public int GetFlow(long FlowID,out DataTable dt)
		{
			int iReturn=-1;
			SqlDataReader dr;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetFlow",parameters,out dr);		
				iReturn = 0;
				dt = Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return iReturn;
		}
		#endregion

		#region �õ�������
		/// <summary>
		/// �õ�������
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="dt">���ر��</param>
		public string GetFlowTitle(long FlowID)
		{			
			string strReturn="";
			SqlDataReader dr;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetFlow",parameters,out dr);								
				if(dr.Read())
				{
					strReturn = "<a href='#' title='" + dr["Remark"].ToString() + "'>" + dr["Flow_Name"].ToString() + "</a>";
				}
				dr.Close();
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
			return strReturn;
		}

		#endregion

		//////////////////////////////////////////////
		///				���̲���������
		//////////////////////////////////////////////		
				

		#region ��Ӳ���
		/// <summary>
		/// ��Ӳ���
		/// </summary>		
		/// <param name="StepName">������</param>
		/// <param name="StepRemark">������</param>
		/// <param name="RightToFinish">�Ƿ���Ȩ������</param>
		/// <param name="FlowRule">��ת����</param>
		/// <param name="PassNum">��ǩ��Ŀ</param>		
		public int AddStep(long FlowID,string StepName,string StepRemark,int RightToFinish,int FlowRule,int PassNum,int LocalAlert,int BaseHour,int CycTimes,int Period)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepName",SqlDbType.VarChar ,300,StepName),
											mySQL.MakeInParam("@StepRemark",SqlDbType.NText ,3000,StepRemark),
											mySQL.MakeInParam("@RightToFinish",SqlDbType.Bit,1,RightToFinish),
											mySQL.MakeInParam("@FlowRule",SqlDbType.Int,4,FlowRule),									
											mySQL.MakeInParam("@PassNum",SqlDbType.Int,4,PassNum),
											mySQL.MakeInParam("@LocalAlert",SqlDbType.Bit,1,LocalAlert),
											mySQL.MakeInParam("@BaseHour",SqlDbType.Int,4,BaseHour),
											mySQL.MakeInParam("@CycTimes",SqlDbType.Int,4,CycTimes),
											mySQL.MakeInParam("@Period",SqlDbType.Int,4,Period)								
										};
			try
			{				
				iReturn = mySQL.RunProc("sp_Flow_AddStep",parameters);		
			}
			catch (Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());							
			}
			finally
			{
				mySQL.Close();
				mySQL = null;
			}

			return iReturn;
		}

		#endregion

		#region ɾ������
		/// <summary>
		/// ɾ������
		/// </summary>
		/// <param name="FlowID">��ɾ���Ĳ��������ID</param>
		/// <param name="StepID">��ɾ���Ĳ���Ĳ���ID</param>
		public int DeleteStep(long FlowID,long StepID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_DeleteStep",parameters);		
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
		
		#region �޸Ĳ���
		/// <summary>
		/// �޸Ĳ���
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		/// <param name="TacheName">������</param>
		/// <param name="TacheRemark">������</param>
		/// <param name="RightToFinish">�Ƿ���Ȩ������</param>
		/// <param name="FlowRule">��ת����</param>
		/// <param name="PassNum">��ǩ��Ŀ</param>
		public int UpdateStep(long FlowID,long StepID,string StepName,string StepRemark,int RightToFinish,int FlowRule,int PassNum,int LocalAlert,int BaseHour,int CycTimes,int Period)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
											mySQL.MakeInParam("@StepName",SqlDbType.VarChar ,300,StepName),
											mySQL.MakeInParam("@StepRemark",SqlDbType.NText ,3000,StepRemark),
											mySQL.MakeInParam("@RightToFinish",SqlDbType.Bit,1,RightToFinish),
											mySQL.MakeInParam("@FlowRule",SqlDbType.Int,4,FlowRule),									
											mySQL.MakeInParam("@PassNum",SqlDbType.Int,4,PassNum),
											mySQL.MakeInParam("@LocalAlert",SqlDbType.Bit,1,LocalAlert),
											mySQL.MakeInParam("@BaseHour",SqlDbType.Int,4,BaseHour),
											mySQL.MakeInParam("@CycTimes",SqlDbType.Int,4,CycTimes),
											mySQL.MakeInParam("@Period",SqlDbType.Int,4,Period)								

										};
			try
			{				
				iReturn = mySQL.RunProc("sp_Flow_UpdateStep",parameters);		
			}
			catch (Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());							
			}
			finally
			{
				mySQL.Close();
				mySQL = null;
			}

			return iReturn;
		}

		#endregion

		#region ���Ʋ���
		/// <summary>
		/// ���Ʋ���
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		public int MoveUpStep(long FlowID,long StepID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)
										};
			try
			{				
				iReturn = mySQL.RunProc("sp_Flow_MoveUpStep",parameters);		
			}
			catch (Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());							
			}
			finally
			{
				mySQL.Close();
				mySQL = null;
			}

			return iReturn;
		}

		#endregion

		#region �õ����������Ϣ
		/// <summary>
		/// �õ����������Ϣ
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		/// <param name="dt">���ر��</param>
		public int GetStep(long FlowID,long StepID,out DataTable dt)
		{
			int iReturn=-1;
			SqlDataReader dr;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetStep",parameters,out dr);		
				iReturn = 0;
				dt = Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return iReturn;
		}

		#endregion

		#region �õ����̵������
		/// <summary>
		/// �õ����̵������
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <returns>�����</returns>
		public int GetMaxStep(long FlowID)
		{
			int iReturn=-1;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID)											
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_GetMaxStep",parameters);		
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

		#region �õ�������
		/// <summary>
		/// �õ�������
		/// </summary>
		/// <param name="FlowID">����ID</param>		
		public string GetStepTitle(long FlowID,long StepID)
		{			
			string strReturn="";
			SqlDataReader dr;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetStep",parameters,out dr);								
				if(dr.Read())
				{
					strReturn = "<a href='#' title='" + dr["Step_Remark"].ToString() + "'>" + dr["Step_Name"].ToString() + "</a>";
				}
				dr.Close();
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
			return strReturn;
		}

		#endregion

		//////////////////////////////////////////////
		///				������ת�������
		//////////////////////////////////////////////		
				

		#region �����ת
		/// <summary>
		/// �����ת
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		/// <param name="FieldName">�ֶ���</param>
		/// <param name="Compare">�ȽϷ���</param>
		/// <param name="CompareValue">�Ƚ�ֵ</param>
		/// <returns></returns>
		public int AddJump(long FlowID,long StepID,string FieldName,string Compare,double CompareValue,long ToStepID,int FlowRule)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
											mySQL.MakeInParam("@FieldName",SqlDbType.VarChar  ,50,FieldName),
											mySQL.MakeInParam("@Compare",SqlDbType.VarChar,50,Compare),
											mySQL.MakeInParam("@CompareValue",SqlDbType.Float ,8,CompareValue),
											mySQL.MakeInParam("@ToStepID",SqlDbType.Float ,8,ToStepID),
											mySQL.MakeInParam("@FlowRule",SqlDbType.Int ,4,FlowRule)
										};
			try
			{				
				iReturn = mySQL.RunProc("sp_Flow_AddJump",parameters);		
			}
			catch (Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());							
			}
			finally
			{
				mySQL.Close();
				mySQL = null;
			}

			return iReturn;
		}

		#endregion

		#region ɾ����ת
		/// <summary>
		/// ɾ������
		/// </summary>
		/// <param name="FlowID">��ɾ������ת������ID</param>
		/// <param name="StepID">��ɾ������ת�Ĳ���ID</param>
		/// <param name="Priority">��ɾ������ת�����ȵȼ�</param>
		public int DeleteJump(long FlowID,long StepID,long Priority)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
											mySQL.MakeInParam("@Priority",SqlDbType.Int ,4,Priority)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_DeleteJump",parameters);		
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
		
		#region �޸���ת
		/// <summary>
		/// �޸���ת
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		/// <param name="Priority">���ȼ�</param>
		/// <param name="FieldName">�ֶ���</param>
		/// <param name="Compare">�ȽϷ���</param>
		/// <param name="CompareValue">�Ƚ�ֵ</param>
		/// <returns></returns>
		public int UpdateJump(long FlowID,long StepID,long Priority,string FieldName,string Compare,double CompareValue,long ToStepID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
											mySQL.MakeInParam("@Priority",SqlDbType.Int ,4,Priority),	
											mySQL.MakeInParam("@FieldName",SqlDbType.VarChar  ,50,FieldName),
											mySQL.MakeInParam("@Compare",SqlDbType.VarChar,50,Compare),
											mySQL.MakeInParam("@CompareValue",SqlDbType.Float ,8,CompareValue),
											mySQL.MakeInParam("@ToStepID",SqlDbType.Float ,8,ToStepID)								
										};
			try
			{				
				iReturn = mySQL.RunProc("sp_Flow_UpdateJump",parameters);		
			}
			catch (Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());							
			}
			finally
			{
				mySQL.Close();
				mySQL = null;
			}

			return iReturn;
		}

		#endregion

		#region ������ת
		/// <summary>
		/// ������ת
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		/// <param name="Priority">���ȼ�</param>
		public int MoveUpJump(long FlowID,long StepID,long Priority)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
											mySQL.MakeInParam("@Priority",SqlDbType.Int ,4,Priority)
										};
			try
			{				
				iReturn = mySQL.RunProc("sp_Flow_MoveUpJump",parameters);		
			}
			catch (Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());							
			}
			finally
			{
				mySQL.Close();
				mySQL = null;
			}

			return iReturn;
		}

		#endregion

		#region �õ���ת������Ϣ
		/// <summary>
		/// �õ����������Ϣ
		/// </summary>
		/// <param name="FlowID">����ID</param>
		/// <param name="StepID">����ID</param>
		/// <param name="Priority">���ȼ�</param>
		/// <param name="dt">���ر��</param>
		public int GetJump(long FlowID,long StepID,long Priority,out DataTable dt)
		{
			int iReturn=-1;
			SqlDataReader dr;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID),
											mySQL.MakeInParam("@StepID",SqlDbType.Int ,4,StepID),
											mySQL.MakeInParam("@Priority",SqlDbType.Int ,4,Priority)
										};
			try
			{
				mySQL.RunProc("sp_Flow_GetJump",parameters,out dr);		
				iReturn = 0;
				dt = Tools.ConvertDataReaderToDataTable(dr);
			}
			catch(Exception e)
			{
				Error.Log(e.ToString());
				dt = null;
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return iReturn;
		}

		#endregion

		//////////////////////////////////////////////
		///				  ��������
		//////////////////////////////////////////////

		#region ������Ϣ
		/// <summary>
		/// ������̵ı����ʽ����
		/// </summary>
		/// <param name="ErrorNum">������Ϣ</param>		
		/// <param name="DocID">�ĵ�ID</param>		
		public string DoMessage(int ErrorNum,long DocID,bool DefaultOperation)
		{
			string ErrorMessage="";

			switch(ErrorNum)
			{
				case 0:
					ErrorMessage="�ɹ�";
					break;
				case -1:
					ErrorMessage="���̽�����";
					break;
				case -2:
					if(DefaultOperation==true)
					{
						if(this.IsNewDocument(DocID)>0)
							this.DeleteDocument(DocID);
						else
							this.CancelPostil(DocID);
					}
					ErrorMessage="û��ְλ�ϼ�";
					break;
				case -3:
					if(DefaultOperation==true)
					{
						if(this.IsNewDocument(DocID)>0)
							this.DeleteDocument(DocID);
						else
							this.CancelPostil(DocID);
					}
					ErrorMessage="û����Ŀ�ϼ�";
					break;
				case -4:
					ErrorMessage="��Ҫȫ��ͨ��";
					break;
				case -5:
					ErrorMessage="ͨ����������";
					break;
				case -6:
					if(DefaultOperation==true)
					{
						if(this.IsNewDocument(DocID)>0)
							this.DeleteDocument(DocID);
						else
							this.CancelPostil(DocID);
					}
					ErrorMessage="�������������ڵĻ���";
					break;
				case -7:
					ErrorMessage="��һ����û�г�Ա";
					break;
				default:
					break;
			}
			return ErrorMessage;
		}
		#endregion

		#region ����ĵ��Ĵ���״̬
		/// <summary>
		/// ����ĵ��Ĵ���״̬
		/// </summary>
		/// <param name="DocID">�������ĵ�ID</param>
		public int GetDocumentStatus(long DocID)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_GetDocumentStatus",parameters);		
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

		#region ����ĵ��Ĳ���״̬
		/// <summary>
		/// ����ĵ��Ĳ���״̬
		/// </summary>
		/// <param name="DocID">�������ĵ�ID</param>
		public int GetDocumentStatus(long DocID,string UserName)
		{
			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar ,300,UserName),
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)
										};
			try
			{
				iReturn = mySQL.RunProc("sp_Flow_GetDocumentStatusByStaff",parameters);		
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

		#region Ȩ���ж�
		/// <summary>
		/// Ȩ���ж�
		/// </summary>
		/// <param name="classID">����ӵ�ID</param>
		/// <param name="UserName">�û���</param>
		/// <param name="actID">Ȩ������</param>
		/// <returns>�Ƿ���Ȩ�� 1�� 0��</returns>
		public bool GetAccessPermission(int classID,string UserName,int actID)
		{
			int flag = 0;
			// �������ݿ�����༰DataReader
			Database data = new Database();
				
			// ִ�д洢���̣�������SqlDataReader����
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
				throw new Exception("��ȡ����Ȩ����",ex);
			}
			finally
			{

                if (data != null)
                {
                    data.Close();
                }
				data	   = null;
			}
			
		}

		#endregion

		#region �õ��ĵ�����������
		/// <summary>
		/// �õ��ĵ�����������
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <returns>�ĵ�����������ID</returns>
		public int GetDocumentFlowID(long DocID)
		{
			int iReturn=-1;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)											
										};
			try
			{
				iReturn = mySQL.RunProc("sp_GetDocumentFlowID",parameters);		
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

		#region �õ��ĵ������Ĳ���
		/// <summary>
		/// �õ��ĵ������Ĳ���
		/// </summary>
		/// <param name="DocID">�ĵ�ID</param>
		/// <returns>�ĵ�����������ID</returns>
		public int GetDocumentStepID(long DocID)
		{
			int iReturn=-1;
						
			UDS.Components.Database mySQL = new UDS.Components.Database();

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@DocID",SqlDbType.Int ,4,DocID)											
										};
			try
			{
				iReturn = mySQL.RunProc("sp_GetDocumentStepID",parameters);		
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


        public int UpdateFieldValue(int FieldValueID, string FieldValueName)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@FieldValueID",SqlDbType.Int,4,FieldValueID),
											mySQL.MakeInParam("@FieldValueName",SqlDbType.VarChar,100,FieldValueName) 
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_UpdateFieldValue", parameters);
            }
            catch (Exception e)
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

        public int AddFieldValue(string FieldValueName, int FieldID)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@FieldValueName",SqlDbType.VarChar,100,FieldValueName),
											mySQL.MakeInParam("@FieldID",SqlDbType.Int,4,FieldID),
											 
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_AddFieldValue", parameters);
            }
            catch (Exception e)
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

        public int DeleteFieldValue(int FieldValueID)
        {

            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@FieldValueID",SqlDbType.Int,4,FieldValueID)
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_DeleteFieldValue", parameters);
            }
            catch (Exception e)
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

        public int  AddBoard(string BoardName, string BoardContent)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@BoardName",SqlDbType.VarChar,200,BoardName),
											mySQL.MakeInParam("@BoardContent",SqlDbType.NText,20000,BoardContent),
											 
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_AddBoard", parameters);
            }
            catch (Exception e)
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


        public int AddNews(string BoardName, string BoardContent)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@NewsName",SqlDbType.VarChar,200,BoardName),
											mySQL.MakeInParam("@NewsContent",SqlDbType.NText,20000,BoardContent),
											 
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_AddNews", parameters);
            }
            catch (Exception e)
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
        public int DeleteBoard(int boardID)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@BoardID",SqlDbType.Int,4,boardID)
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_DeleteBoard", parameters);
            }
            catch (Exception e)
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
        public int DeleteNews(int boardID)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();
            SqlParameter[] parameters = {
											mySQL.MakeInParam("@NewsID",SqlDbType.Int,4,boardID)
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_DeleteNews", parameters);
            }
            catch (Exception e)
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

        public int UpdateAttatchFile(long FlowID, string FlowChat)
        {
            int iReturn = -1;
            UDS.Components.Database mySQL = new UDS.Components.Database();

            SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,FlowID), 
                                            mySQL.MakeInParam("@FlowChat",SqlDbType.VarChar,300,FlowChat)
										};
            try
            {
                iReturn = mySQL.RunProc("sp_Flow_UpdateAttatchFile", parameters);
            }
            catch (Exception e)
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
    }
	#endregion

}
