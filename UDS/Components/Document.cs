using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections ;
using System.Configuration;

namespace UDS.Components
{
	/// <summary>
	/// 文档类
	/// </summary>
	public class DocumentClass
	{
		#region 获取某项目中的文档 返回DataTable
		/// <summary>
		///获取某项目中的文档 返回DataTable
		/// </summary>
		/// <param name="ClassID">项目ID</param>
		public DataTable GetClassDocs(int ClassID)
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			DataTable datatable = new DataTable();
			SqlParameter[] prams = 
								{
									data.MakeInParam("@ClassID",	SqlDbType.Int, 20 ,ClassID)
								 };
            try
            {
                data.RunProc("sp_GetNewDocument", prams, out dataReader);
                datatable = Tools.ConvertDataReaderToDataTable(dataReader);
                dataReader.Close();
                return datatable;
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }

		}
		#endregion

		#region 获取某项目我的审批文档 返回DataTable
		/// <summary>
		/// 获取某项目我的审批文档 返回DataTable 返回DataTable
		/// </summary>
		/// <param name="ClassID">项目ID</param>
		public DataTable GetApproveClassDocs(int ClassID)
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			DataTable datatable = new DataTable();
			SqlParameter[] prams = 
								{
									data.MakeInParam("@ClassID",	SqlDbType.Int, 20 ,ClassID)
								};
            try
            {
                data.RunProc("sp_GetMyClassApproved", prams, out dataReader);
                datatable = Tools.ConvertDataReaderToDataTable(dataReader);
                dataReader.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }

		}
		#endregion

		#region 获取某文档详细信息
		/// <summary>
		/// 获取某文档详细信息
		/// </summary>
		/// <param name="ClassID">项目ID</param>
		public SqlDataReader GetDocDetail(int DocID,string UserName)
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = 
								{
									data.MakeInParam("@Doc_ID",	SqlDbType.Int, 20 ,DocID),
									data.MakeInParam("@UserName",	SqlDbType.VarChar, 300 ,UserName)
								};
			try
			{
				data.RunProc("sp_ReadDocument",prams, out dataReader);
				return dataReader;
			}
						
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				return null;
			}

		}
		#endregion

		#region 文件主体添加
		/// <summary>
		/// 文件主体添加
		/// </summary>
		/// <param name="DocBody"> 文件主体类</param>
		public string AddDocBody(DocBody docbody) 
		{		
			
			// create data object and params
			Database data = new Database();	
			string DocID = "";
			SqlParameter[] prams = {
									   data.MakeInParam("@ClassID",   SqlDbType.Int, 20, docbody.DocClassID),
									   data.MakeInParam("@DocTitle",  SqlDbType.NVarChar, 300, docbody.DocTitle),
									   data.MakeInParam("@DocContent",SqlDbType.NText, 8000,docbody.DocContent),
									   data.MakeInParam("@DocApprover",  SqlDbType.NVarChar,200, docbody.DocApprover),
									   data.MakeInParam("@DocApproveDate",  SqlDbType.NVarChar, 20, docbody.DocApproveDate),
									   data.MakeInParam("@DocApproved",  SqlDbType.Int, 1, docbody.DocApproved),
									   data.MakeInParam("@DocType",  SqlDbType.Int, 2, docbody.DocType),
									   data.MakeInParam("@DocAttribute",  SqlDbType.Int , 2, docbody.DocAttribute),
									   data.MakeInParam("@DocAddedBy",  SqlDbType.NVarChar, 300, docbody.DocAddedBy),
									   data.MakeInParam("@DocAddedDate",  SqlDbType.DateTime, 300,DateTime.Parse(docbody.DocAddedDate)),
									   data.MakeOutParam("@CurrentDocID",  SqlDbType.Int, 2)  			
								   };

			

			try 
			{
				data.RunProc("SP_Ext_AddDocument", prams);
				DocID = prams[10].Value.ToString();
				if (DocID == string.Empty )
					return null;
				else 
					return DocID;
			}
			catch (Exception ex) 
			{
				Error.Log(ex.ToString());
				throw new Exception("文档正文增加错误!",ex);
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

		#region 文件附件数据库操作
		/// <summary>
		/// 文件附件数据库操作
		/// </summary>
		/// <param name="att">DocAttachFile类</param>
		/// <param name="DocID">文件ID</param>
		public void AddAttach(DocAttachFile att,int DocID) 
		{		
			Database data = new Database();	
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
				data.RunProc("SP_Ext_AddFile", prams);
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

		#region 获取某项目中的文档列表
		/// <summary>
		/// 获取某项目中的文档列表
		/// </summary>
		/// <param name="ClassID">项目ID</param>
		/// <param name="UserName">用户名D</param>
		public SqlDataReader GetDocListInClass(int ClassID,string UserName,int DisplayType)
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			SqlParameter[] prams = 
								{
									data.MakeInParam("@ClassID",	SqlDbType.Int, 20 ,ClassID),
									data.MakeInParam("@UserName",	SqlDbType.NVarChar,20,UserName),
									data.MakeInParam("@DisplayType", SqlDbType.Int,1,DisplayType)
								};
			try
			{
				data.RunProc("sp_GetClassDocumentList",prams, out dataReader);
				return dataReader;
			}
						
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				return null;
			}

		}
		#endregion

		#region 删除一组文档
		/// <summary>
		/// 删除一组文档
		/// </summary>
		/// <param name="MailIDStr">文档ID的连接字符串，用逗号相隔开</param>
		public bool DocDelete(string DocIDStr,int DeleteType)
		{
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@DocIDs",   SqlDbType.VarChar,4000, DocIDStr),
									   data.MakeInParam("@DeleteType",SqlDbType.Int,1,DeleteType)
								   };
			try
			{
				data.RunProc("SP_DeleteDocument",prams);
				data = null;
				return true;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				return false;
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

		#region 获取管理者查询快捷文档信息
		/// <summary>
		/// 获取某文档路径信息
		/// </summary>
		
		public SqlDataReader GetManageQueryDetail()
		{
			SqlDataReader dataReader = null;
			Database data = new Database();
			try
			{
				data.RunProc("sp_GetManagerDocument", out dataReader);
				return dataReader;
			}
						
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				return null;
			}

		}
		#endregion

	}


	public class DocBody
	{
		private int m_DocClassID;
		private string m_DocTitle;
		private string m_DocContent;
		private string m_DocApprover;
		private string m_DocApproveDate;
		private int m_DocApproved;
		private string m_DocLastViewDate;
		private string m_DocLastViewer;
		private int m_DocViewedTimes;
		private int m_DocType;
		private string m_DocAddedBy;
		private string m_DocAddedDate;
		private int m_DocAttribute;
		private int m_DocSign;
		private int m_DocDeletion;

		public int DocClassID
		{	
			// 中文含义
			get { return m_DocClassID; }
			set { m_DocClassID = value; }
		}

		public string DocTitle 
		{	
			// 中文含义
			get { return m_DocTitle; }
			set { m_DocTitle = value; }
		}
		
		public string DocContent 
		{	
			// 中文含义
			get { return m_DocContent; }
			set { m_DocContent = value; }
		}
		
		public string DocApprover 
		{	
			// 中文含义
			get { return m_DocApprover; }
			set { m_DocApprover = value; }
		}

		public string DocApproveDate 
		{	
			// 中文含义
			get { return m_DocApproveDate; }
			set { m_DocApproveDate = value; }
		}

		public int DocApproved
		{	
			// 中文含义
			get { return m_DocApproved; }
			set { m_DocApproved = value; }
		}
		
		public string DocLastViewDate 
		{	
			// 中文含义
			get { return m_DocLastViewDate; }
			set { m_DocLastViewDate = value; }
		}
	
		public string DocLastViewer 
		{	
			// 中文含义
			get { return m_DocLastViewer; }
			set { m_DocLastViewer = value; }
		}
				
		public int DocViewedTimes 
		{	
			// 中文含义
			get { return m_DocViewedTimes; }
			set { m_DocViewedTimes = value; }
		}

		public int DocType 
		{	
			// 中文含义
			get { return m_DocType; }
			set { m_DocType = value; }
		}

		public string DocAddedBy 
		{	
			// 中文含义
			get { return m_DocAddedBy; }
			set { m_DocAddedBy = value; }
		}

		public string DocAddedDate 
		{	
			// 中文含义
			get { return m_DocAddedDate; }
			set { m_DocAddedDate = value; }
		}

		public int DocAttribute
		{	
			// 中文含义
			get { return m_DocAttribute; }
			set { m_DocAttribute = value; }
		}

		public int DocSign
		{	
			// 中文含义
			get { return m_DocSign; }
			set { m_DocSign = value; }
		}

		public int DocDeletion
		{	
			// 中文含义
			get { return m_DocDeletion; }
			set { m_DocDeletion = value; }
		}
	}

	public class DocAttachFile
	{
		private int m_FileID;
		private int m_DocID;
		private string m_FileName;
		private int m_FileSize;
		private int m_FileAttribute;
		private string m_FileVisualPath;
		private string m_FileAuthor;
		private string m_FileCatlog;
		private string m_FileAddedDate;

		public int FileID 
		{	
			//文件ID
			get { return m_FileID; }
			set { m_FileID = value; }
		}

		public int DocID 
		{	
			//文档ID
			get { return m_DocID; }
			set { m_DocID = value; }
		}

		public string FileName 
		{	
			//文件名
			get { return m_FileName; }
			set { m_FileName = value; }
		}

		public int FileSize 
		{	
			//文件大小
			get { return m_FileSize; }
			set { m_FileSize = value; }
		}

		public int FileAttribute 
		{	
			//文件属性
			get { return m_FileAttribute; }
			set { m_FileAttribute = value; }
		}

		public string FileVisualPath
		{	
			//文件虚拟路径
			get { return m_FileVisualPath; }
			set { m_FileVisualPath = value; }
		}

		public string FileAuthor
		{	
			//文件作者
			get { return m_FileAuthor; }
			set { m_FileAuthor = value; }
		}

		public string FileCatlog 
		{	
			//文件类别
			get { return m_FileCatlog; }
			set { m_FileCatlog = value; }
		}

		public string FileAddedDate
		{	
			//文件添加日期
			get { return m_FileAddedDate; }
			set { m_FileAddedDate = value; }
		}
	}
}
