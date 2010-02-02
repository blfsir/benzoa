using System;
using System.Data;
using System.Data.SqlClient;

namespace UDS.Components
{
	#region 工作流的函数
	/// <summary>
	/// DocumentFlow 的摘要说明。
	/// </summary>
	public class DocumentFlow
	{

		//////////////////////////////////////////
		///				公文流转
		//////////////////////////////////////////
		
		#region 添加文档
		/// <summary>
		/// 添加文档
		/// </summary>
		/// <param name="UserName">拟稿人</param>
		/// <param name="FlowID">所用流程ID</param>
		/// <param name="SQL">样式表数据的SQL语句</param>
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

		#region 删除文档
		/// <summary>
		/// 删除文档
		/// </summary>
		/// <param name="DocID">被删除的文档ID</param>
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

		#region 修改文档
		/// <summary>
		/// 修改文档
		/// </summary>
		/// <param name="UpdateSQL">更新文档语句</param>
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

		#region 文档签收
		/// <summary>
		/// 文档签收
		/// </summary>
		/// <param name="UserName">签收人</param>
		/// <param name="DocID">要被签收的文档ID</param>
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

		#region 取消签收
		/// <summary>
		/// 取消签收
		/// </summary>
		/// <param name="UserName">签收人</param>
		/// <param name="DocID">被取消的文档ID</param>
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

		#region 添加批注
		/// <summary>
		/// 添加批注
		/// </summary>
		/// <param name="UserName">批注人</param>
		/// <param name="DocID">批注的文档ID</param>
		/// <param name="PostilType">批注类型，通过，拒绝，完成</param>
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

		#region 否决文档
		/// <summary>
		/// 否决文档
		/// </summary>
		/// <param name="DocID">被否决的文档ID</param>
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

		#region 打回文档
		/// <summary>
		/// 打回文档
		/// </summary>
		/// <param name="DocID">被打回的文档ID</param>
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

		#region 通过文档
		/// <summary>
		/// 通过文档
		/// </summary>
		/// <param name="UserName">审批人</param>
		/// <param name="DocID">当前文档ID</param>		
		/// <param name="ProjectID">所在项目ID</param>
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

		#region 结束文档
		/// <summary>
		/// 结束文档
		/// </summary>
		/// <param name="DocID">被结束的文档ID</param>
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

		#region 删除文档最近的批注
		/// <summary>
		/// 删除文档最近的批注
		/// </summary>
		/// <param name="DocID">文档ID</param>
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
		
		#region 获得步骤流转规则
		/// <summary>
		/// 获得步骤流转规则
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
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

		#region 获得步骤结束权利
		/// <summary>
		/// 获得步骤结束权利
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
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
		
		#region 获得文档的是否为新拟稿
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="DocID">文档ID</param>		
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

		#region 获得用户所有的项目，返回表格
		/// <summary>
		/// 获得用户所有的项目
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="dt">返回表格</param>
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
		
		#region 获得用户所有的项目，返回表格
			/// <summary>
			/// 获得用户所有的项目
			/// </summary>
			/// <param name="UserName">用户名</param>
			/// <param name="dt">返回表格</param>
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

		#region 获得文档的批注,返回记录集
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dr">返回表格</param>
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

		#region 获得文档的批注,返回表格
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 获得文档的信息实体,返回记录集
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dr">返回记录集</param>
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

		#region 获得文档的信息实体,返回表格
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dr">返回表格</param>
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

		

		#region 获得步骤成员,返回表格
		/// <summary>
		/// 获得环节成员,返回表格
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 获得步骤成员,返回表格
		/// <summary>
		/// 获得环节成员,返回表格
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 获得步骤接受人员,返回表格
		/// <summary>
		/// 获得步骤接受人员,返回表格
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 获得步骤已经签收人员,返回表格
		/// <summary>
		/// 获得步骤已经签收人员,返回表格
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 获得步骤未签收人员,返回表格
		/// <summary>
		/// 获得步骤未签收人员,返回表格
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 获得步骤已经批阅人员,返回表格
		/// <summary>
		/// 获得步骤已经批阅人员,返回表格
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 获得流程头信息,返回表格
		/// <summary获得流程头信息
		/// 获得环节已经批阅人员,返回表格
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="dt">返回表格</param>
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
					str = dr["Flow_Name"].ToString() + "(流水号:" + string.Format(dr["Times"].ToString(),"03d") + ")";
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

		#region 获得文档的附件,返回表格
		/// <summary>
		/// 获得文档的附件,返回表格
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <param name="dt">返回表格</param>
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
				throw new Exception("获得公文的附件出错！",e);
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return 0;
		}		
		#endregion			

		#region 添加公文附件数据库
		/// <summary>
		/// 添加文件附件数据库操作
		/// </summary>
		/// <param name="att">DocAttachFile类</param>
		/// <param name="DocID">文件ID</param>
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
				throw new Exception("文件附件发送出错!",ex);
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

		#region 删除公文附件数据库
		/// <summary>
		/// 删除文件附件数据库操作
		/// </summary>
		/// <param name="DocID">文件ID</param>
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
				throw new Exception("文件附件删除出错!",ex);
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

		#region 获得公文附件名
		/// <summary>
		/// 获得公文附件名
		/// </summary>
		/// <param name="DocID">文件ID</param>
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
				throw new Exception("获得文件附出错!",ex);
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

        //获得流程上传的流程图图片的名称
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
                throw new Exception("获得文件附出错!", ex);
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

		#region 添加公文批注附件数据库
		/// <summary>
		/// 添加文件批注附件数据库操作
		/// </summary>
		/// <param name="att">DocAttachFile类</param>
		/// <param name="DocID">文件ID</param>
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
                throw new Exception("文件附件发送出错!", ex);
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

		#region 获得文档的所在项目ID
		/// <summary>
		/// 获得文档的所在项目ID
		/// </summary>
		/// <param name="DocID">文档ID</param>
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
				throw new Exception("获得公文的项目ID出错！",e);
			}
			finally
			{
				mySQL.Close();
				mySQL = null;	
			}
			return iReturn;
		}		
		#endregion			

		#region 获得是否按照项目流转
		/// <summary>
		/// 获得是否按照项目流转ID
		/// </summary>
		/// <param name="UserName">用户名</param>
		/// <param name="DocID">文档ID</param>
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
				throw new Exception("获得是否按照项目流转出错！",e);
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
		///				流程自定义表单
        /////////////////////////////////////////////


        #region 自定义表单字段类型
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FieldName">字段类型名</param>
        /// <param name="isDdl">是否显示为下拉列表dropdownlist</param>
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

        #region 添加自定义风格表格
        /// <summary>
		/// 添加自定义风格表格
		/// </summary>
		/// <param name="StyleName">风格名</param>
		/// <param name="StyleRemark">简介ID</param>
		/// <param name="Teamplate">模板路径</param>
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

		#region 删除自定义风格表格
		/// <summary>
		/// 删除自定义风格表格
		/// </summary>
		/// <param name="StyleID">风格ID</param>
		public int DeleteStyle(long StyleID,string Path)
		{

			int iReturn=-1;
			UDS.Components.Database mySQL = new UDS.Components.Database();
			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int,4,StyleID)
										};
			try
			{
				DeleteTemplate(StyleID,Path);		//删除模板实体
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

		#region 修改自定义风格表格
		/// <summary>
		/// 修改自定义风格表格
		/// </summary>
		/// <param name="StyleID">风格ID</param>
		/// <param name="StyleName">风格名</param>
		/// <param name="StyleRemark">简介ID</param>
		/// <param name="Teamplate">模板路径</param>
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

		#region 添加自定义风格详细定义
		/// <summary>
		/// 添加自定义风格详细定义
		/// </summary>
		/// <param name="StyleID">风格表格ID</param>
		/// <param name="FieldName">帮定字段名</param>
		/// <param name="FieldDescription">字段意义</param>
		/// <param name="Judged">是否作为条件判断字段</param>
		/// <param name="MultiLine">是否多行</param>
		/// <param name="Height">控件高度</param>
		/// <param name="Width">控件宽</param>
		/// <param name="Position">控件在表单中的位置</param>
		/// <param name="Example">填表示例</param>

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

		#region 删除自定义风格表格详细定义
		/// <summary>
		/// 删除自定义风格表格详细定义，一行定义表示一个控件
		/// </summary>
		/// <param name="DescriptionID">风格详细定义ID</param>
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

		#region 修改自定义风格详细定义
		/// <summary>
		/// 修改自定义风格详细定义
		/// </summary>
		/// <param name="DescriptionID">风格详细定义ID</param>
		/// <param name="StyleID">风格表格ID</param>
		/// <param name="FieldName">帮定字段名</param>
		/// <param name="FieldDescription">字段意义</param>
		/// <param name="Judged">是否作为条件判断字段</param>
		/// <param name="MultiLine">是否多行</param>
		/// <param name="Height">控件高度</param>
		/// <param name="Width">控件宽</param>
		/// <param name="Position">控件在表单中的位置</param>
		/// <param name="Example">填表示例</param>

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

		#region 获得自定义风格表格一条详细定义
		/// <summary>
		/// 获得单一样式描述
		/// </summary>
		/// <param name="StyleID">流程ID</param>
		/// <param name="dr">数据集合</param>
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

		#region 通过流程ID得到流程模板名
		/// <summary>
		/// 通过流程ID得到流程模板名
		/// </summary>
		/// <param name="FlowID">流程ID</param>
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
				throw new Exception("获得表格模板错误!",e);
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

		#region 通过表单ID得到流程模板名
		/// <summary>
		/// 通过表单ID得到流程模板名
		/// </summary>
		/// <param name="FlowID">流程ID</param>
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
				throw new Exception("获得表格模板错误!",e);
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

		#region 删除模板实体
		/// <summary>
		/// 删除模板实体
		/// </summary>		
		/// <param name="StyleID">风格表格ID</param>
		/// <param name="Path">路径</param>
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

		#region 获得流程的表格样式描述
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="Judged">是否包括条件判断的字段</param>
		/// <param name="dr">数据集合</param>
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

		#region 获得流程的表格样式描述
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="StyleID">流程ID</param>
		/// <param name="dr">数据集合</param>
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

		#region 获得流程的表格样式描述
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="Judged">是否包括条件判断的字段</param>
		/// <param name="dt">返回表格</param>
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
		///				流程管理相关
		//////////////////////////////////////////////

		#region 添加流程
		/// <summary>
		/// 添加流程
		/// </summary>
		/// <param name="FlowName">流程名</param>
		/// <param name="FlowRemark">流程简介</param>
		/// <param name="Builder">流程制定者</param>
		/// <param name="StyleID">流程自定义表单</param>
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

		#region 删除流程
		/// <summary>
		/// 删除流程
		/// </summary>
		/// <param name="FlowID">被删除的流程ID</param>
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

		#region 修改流程
		/// <summary>
		/// 修改流程
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="FlowName">流程名</param>
		/// <param name="FlowRemark">流程简介</param>
		/// <param name="Builder">流程制定者</param>
		/// <param name="StyleID">流程自定义表单</param>
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

		#region 得到流程基本信息
		/// <summary>
		/// 得到流程基本信息
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 得到流程名
		/// <summary>
		/// 得到流程名
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="dt">返回表格</param>
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
		///				流程步骤管理相关
		//////////////////////////////////////////////		
				

		#region 添加步骤
		/// <summary>
		/// 添加步骤
		/// </summary>		
		/// <param name="StepName">步骤名</param>
		/// <param name="StepRemark">步骤简介</param>
		/// <param name="RightToFinish">是否有权利结束</param>
		/// <param name="FlowRule">流转规则</param>
		/// <param name="PassNum">会签数目</param>		
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

		#region 删除步骤
		/// <summary>
		/// 删除步骤
		/// </summary>
		/// <param name="FlowID">被删除的步骤的流程ID</param>
		/// <param name="StepID">被删除的步骤的步骤ID</param>
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
		
		#region 修改步骤
		/// <summary>
		/// 修改步骤
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
		/// <param name="TacheName">步骤名</param>
		/// <param name="TacheRemark">步骤简介</param>
		/// <param name="RightToFinish">是否有权利结束</param>
		/// <param name="FlowRule">流转规则</param>
		/// <param name="PassNum">会签数目</param>
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

		#region 上移步骤
		/// <summary>
		/// 上移步骤
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
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

		#region 得到步骤基本信息
		/// <summary>
		/// 得到步骤基本信息
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
		/// <param name="dt">返回表格</param>
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

		#region 得到流程的最大步骤
		/// <summary>
		/// 得到流程的最大步骤
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <returns>最大步骤</returns>
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

		#region 得到步骤名
		/// <summary>
		/// 得到步骤名
		/// </summary>
		/// <param name="FlowID">流程ID</param>		
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
		///				流程跳转管理相关
		//////////////////////////////////////////////		
				

		#region 添加跳转
		/// <summary>
		/// 添加跳转
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
		/// <param name="FieldName">字段名</param>
		/// <param name="Compare">比较符号</param>
		/// <param name="CompareValue">比较值</param>
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

		#region 删除跳转
		/// <summary>
		/// 删除步骤
		/// </summary>
		/// <param name="FlowID">被删除的跳转的流程ID</param>
		/// <param name="StepID">被删除的跳转的步骤ID</param>
		/// <param name="Priority">被删除的跳转的优先等级</param>
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
		
		#region 修改跳转
		/// <summary>
		/// 修改跳转
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
		/// <param name="Priority">优先级</param>
		/// <param name="FieldName">字段名</param>
		/// <param name="Compare">比较符号</param>
		/// <param name="CompareValue">比较值</param>
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

		#region 上移跳转
		/// <summary>
		/// 上移跳转
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
		/// <param name="Priority">优先级</param>
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

		#region 得到跳转基本信息
		/// <summary>
		/// 得到步骤基本信息
		/// </summary>
		/// <param name="FlowID">流程ID</param>
		/// <param name="StepID">步骤ID</param>
		/// <param name="Priority">优先级</param>
		/// <param name="dt">返回表格</param>
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
		///				  其他杂项
		//////////////////////////////////////////////

		#region 处理消息
		/// <summary>
		/// 获得流程的表格样式描述
		/// </summary>
		/// <param name="ErrorNum">错误消息</param>		
		/// <param name="DocID">文档ID</param>		
		public string DoMessage(int ErrorNum,long DocID,bool DefaultOperation)
		{
			string ErrorMessage="";

			switch(ErrorNum)
			{
				case 0:
					ErrorMessage="成功";
					break;
				case -1:
					ErrorMessage="流程结束！";
					break;
				case -2:
					if(DefaultOperation==true)
					{
						if(this.IsNewDocument(DocID)>0)
							this.DeleteDocument(DocID);
						else
							this.CancelPostil(DocID);
					}
					ErrorMessage="没有职位上级";
					break;
				case -3:
					if(DefaultOperation==true)
					{
						if(this.IsNewDocument(DocID)>0)
							this.DeleteDocument(DocID);
						else
							this.CancelPostil(DocID);
					}
					ErrorMessage="没有项目上级";
					break;
				case -4:
					ErrorMessage="需要全体通过";
					break;
				case -5:
					ErrorMessage="通过人数不够";
					break;
				case -6:
					if(DefaultOperation==true)
					{
						if(this.IsNewDocument(DocID)>0)
							this.DeleteDocument(DocID);
						else
							this.CancelPostil(DocID);
					}
					ErrorMessage="该流程无你所在的环节";
					break;
				case -7:
					ErrorMessage="下一步骤没有成员";
					break;
				default:
					break;
			}
			return ErrorMessage;
		}
		#endregion

		#region 获得文档的存在状态
		/// <summary>
		/// 获得文档的存在状态
		/// </summary>
		/// <param name="DocID">被检查的文档ID</param>
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

		#region 获得文档的操作状态
		/// <summary>
		/// 获得文档的操作状态
		/// </summary>
		/// <param name="DocID">被检查的文档ID</param>
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

		#region 权限判断
		/// <summary>
		/// 权限判断
		/// </summary>
		/// <param name="classID">对象接点ID</param>
		/// <param name="UserName">用户名</param>
		/// <param name="actID">权利代号</param>
		/// <returns>是否有权利 1有 0无</returns>
		public bool GetAccessPermission(int classID,string UserName,int actID)
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
                }
				data	   = null;
			}
			
		}

		#endregion

		#region 得到文档关联的流程
		/// <summary>
		/// 得到文档关联的流程
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <returns>文档关联的流程ID</returns>
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

		#region 得到文档关联的步骤
		/// <summary>
		/// 得到文档关联的步骤
		/// </summary>
		/// <param name="DocID">文档ID</param>
		/// <returns>文档关联的流程ID</returns>
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
