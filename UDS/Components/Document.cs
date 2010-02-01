using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections ;
using System.Configuration;

namespace UDS.Components
{
	/// <summary>
	/// �ĵ���
	/// </summary>
	public class DocumentClass
	{
		#region ��ȡĳ��Ŀ�е��ĵ� ����DataTable
		/// <summary>
		///��ȡĳ��Ŀ�е��ĵ� ����DataTable
		/// </summary>
		/// <param name="ClassID">��ĿID</param>
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

		#region ��ȡĳ��Ŀ�ҵ������ĵ� ����DataTable
		/// <summary>
		/// ��ȡĳ��Ŀ�ҵ������ĵ� ����DataTable ����DataTable
		/// </summary>
		/// <param name="ClassID">��ĿID</param>
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

		#region ��ȡĳ�ĵ���ϸ��Ϣ
		/// <summary>
		/// ��ȡĳ�ĵ���ϸ��Ϣ
		/// </summary>
		/// <param name="ClassID">��ĿID</param>
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

		#region �ļ��������
		/// <summary>
		/// �ļ��������
		/// </summary>
		/// <param name="DocBody"> �ļ�������</param>
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
				throw new Exception("�ĵ��������Ӵ���!",ex);
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

		#region �ļ��������ݿ����
		/// <summary>
		/// �ļ��������ݿ����
		/// </summary>
		/// <param name="att">DocAttachFile��</param>
		/// <param name="DocID">�ļ�ID</param>
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

		#region ��ȡĳ��Ŀ�е��ĵ��б�
		/// <summary>
		/// ��ȡĳ��Ŀ�е��ĵ��б�
		/// </summary>
		/// <param name="ClassID">��ĿID</param>
		/// <param name="UserName">�û���D</param>
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

		#region ɾ��һ���ĵ�
		/// <summary>
		/// ɾ��һ���ĵ�
		/// </summary>
		/// <param name="MailIDStr">�ĵ�ID�������ַ������ö��������</param>
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

		#region ��ȡ�����߲�ѯ����ĵ���Ϣ
		/// <summary>
		/// ��ȡĳ�ĵ�·����Ϣ
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
			// ���ĺ���
			get { return m_DocClassID; }
			set { m_DocClassID = value; }
		}

		public string DocTitle 
		{	
			// ���ĺ���
			get { return m_DocTitle; }
			set { m_DocTitle = value; }
		}
		
		public string DocContent 
		{	
			// ���ĺ���
			get { return m_DocContent; }
			set { m_DocContent = value; }
		}
		
		public string DocApprover 
		{	
			// ���ĺ���
			get { return m_DocApprover; }
			set { m_DocApprover = value; }
		}

		public string DocApproveDate 
		{	
			// ���ĺ���
			get { return m_DocApproveDate; }
			set { m_DocApproveDate = value; }
		}

		public int DocApproved
		{	
			// ���ĺ���
			get { return m_DocApproved; }
			set { m_DocApproved = value; }
		}
		
		public string DocLastViewDate 
		{	
			// ���ĺ���
			get { return m_DocLastViewDate; }
			set { m_DocLastViewDate = value; }
		}
	
		public string DocLastViewer 
		{	
			// ���ĺ���
			get { return m_DocLastViewer; }
			set { m_DocLastViewer = value; }
		}
				
		public int DocViewedTimes 
		{	
			// ���ĺ���
			get { return m_DocViewedTimes; }
			set { m_DocViewedTimes = value; }
		}

		public int DocType 
		{	
			// ���ĺ���
			get { return m_DocType; }
			set { m_DocType = value; }
		}

		public string DocAddedBy 
		{	
			// ���ĺ���
			get { return m_DocAddedBy; }
			set { m_DocAddedBy = value; }
		}

		public string DocAddedDate 
		{	
			// ���ĺ���
			get { return m_DocAddedDate; }
			set { m_DocAddedDate = value; }
		}

		public int DocAttribute
		{	
			// ���ĺ���
			get { return m_DocAttribute; }
			set { m_DocAttribute = value; }
		}

		public int DocSign
		{	
			// ���ĺ���
			get { return m_DocSign; }
			set { m_DocSign = value; }
		}

		public int DocDeletion
		{	
			// ���ĺ���
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
			//�ļ�ID
			get { return m_FileID; }
			set { m_FileID = value; }
		}

		public int DocID 
		{	
			//�ĵ�ID
			get { return m_DocID; }
			set { m_DocID = value; }
		}

		public string FileName 
		{	
			//�ļ���
			get { return m_FileName; }
			set { m_FileName = value; }
		}

		public int FileSize 
		{	
			//�ļ���С
			get { return m_FileSize; }
			set { m_FileSize = value; }
		}

		public int FileAttribute 
		{	
			//�ļ�����
			get { return m_FileAttribute; }
			set { m_FileAttribute = value; }
		}

		public string FileVisualPath
		{	
			//�ļ�����·��
			get { return m_FileVisualPath; }
			set { m_FileVisualPath = value; }
		}

		public string FileAuthor
		{	
			//�ļ�����
			get { return m_FileAuthor; }
			set { m_FileAuthor = value; }
		}

		public string FileCatlog 
		{	
			//�ļ����
			get { return m_FileCatlog; }
			set { m_FileCatlog = value; }
		}

		public string FileAddedDate
		{	
			//�ļ��������
			get { return m_FileAddedDate; }
			set { m_FileAddedDate = value; }
		}
	}
}
