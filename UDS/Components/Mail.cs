using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Configuration;

namespace UDS.Components
{
    /// <summary>
    /// Mail������
    /// </summary>
    public class MailClass
    {

        #region ��DataReader תΪ DataTable
        /// <summary>
        /// ��DataReader תΪ DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        //public DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        //{
        //    DataTable datatable = new DataTable();
        //    DataTable schemaTable = dataReader.GetSchemaTable();
        //    //��̬�����
        //    try
        //    {

        //        foreach (DataRow myRow in schemaTable.Rows)
        //        {
        //            DataColumn myDataColumn = new DataColumn();
        //            myDataColumn.DataType = myRow.GetType();
        //            myDataColumn.ColumnName = myRow[0].ToString();
        //            datatable.Columns.Add(myDataColumn);
        //        }
        //        //�������
        //        while (dataReader.Read())
        //        {
        //            DataRow myDataRow = datatable.NewRow();
        //            for (int i = 0; i < schemaTable.Rows.Count; i++)
        //            {
        //                myDataRow[i] = dataReader[i].ToString();
        //            }
        //            datatable.Rows.Add(myDataRow);
        //            myDataRow = null;
        //        }
        //        schemaTable = null;
        //        return datatable;
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.Log(ex.ToString());
        //        return datatable;
        //    }
        //    finally
        //    {

        //        dataReader.Close();
        //    }

        //}

        #endregion

        #region ��ȡĳ�û���ĳ�����е��ż� ����DataTable
        /// <summary>
        ///��ȡĳ�����е��ż� ����DataTable
        /// </summary>
        /// <param name="Username">�û���</param>
        /// <param name="FolderType">��������</param>
        public DataTable GetMails(int FolderType, string Username)
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            DataTable datatable = new DataTable();
            SqlParameter[] prams = 
								{
									data.MakeInParam("@Username",   SqlDbType.VarChar, 20, Username),
									data.MakeInParam("@MailFolderType",   SqlDbType.Int, 8, FolderType)
      							};
            try
            {
                data.RunProc("SP_MailGetBriefInfo", prams, out dataReader);
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
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }

        }
        #endregion

        #region ��ȡĳ��Ŀ�е��ż� ����DataTable
        /// <summary>
        ///��ȡĳ��Ŀ�е��ż� ����DataTable
        /// </summary>
        /// <param name="ClassID">��ĿID</param>
        public DataTable GetClassMails(int ClassID, string Username)
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            DataTable datatable = new DataTable();
            int MailFolderType = 1;
            SqlParameter[] prams = 
								{
									data.MakeInParam("@Username",   SqlDbType.VarChar, 20, Username),
									data.MakeInParam("@ClassID",	SqlDbType.Int, 20 ,ClassID),
									data.MakeInParam("@MailFolderType", SqlDbType.Int,3,MailFolderType)																		
								};
            try
            {
                data.RunProc("SP_MailInClassGetBriefInfo", prams, out dataReader);
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
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }

        }
        #endregion

        #region ��ȡĳ�û���ĳ�����е��ż� ����SqlDataReader
        /// <summary>
        ///��ȡĳ�����е��ż� ����SqlDataReader
        /// </summary>
        /// <param name="Username">�û���</param>
        /// <param name="FolderType">��������</param>
        public SqlDataReader GetMailsDbReader(int FolderType, string Username)
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = 
								{
									data.MakeInParam("@Username",   SqlDbType.VarChar, 20, Username),
									data.MakeInParam("@MailFolderType",   SqlDbType.Int, 8, FolderType)
								};
            try
            {
                data.RunProc("SP_MailGetBriefInfo", prams, out dataReader);
                return dataReader;
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }

        }
        #endregion

        #region ��һ���ʼ�����ָ������
        /// <summary>
        /// ��һ���ʼ�����ָ������
        /// </summary>
        /// <param name="Username">�û���</param>
        /// <param name="MailIDStr">�ʼ�ID�������ַ������ö��������</param>
        public bool MailRemove(int FolderType, string MailIDStr)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@FolderType" , SqlDbType.Int, 20, FolderType),
									   data.MakeInParam("@MailIDStr",   SqlDbType.VarChar,4000, MailIDStr)
								   };
            try
            {
                data.RunProc("SP_MailRemove", prams);
                data = null;
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return false;
            }

        }
        #endregion

        #region ɾ��һ���ʼ�
        /// <summary>
        /// ����ɾ��һ���ʼ�
        /// </summary>
        /// <param name="MailIDStr">�ʼ�ID�������ַ������ö��������</param>
        public bool MailDelete(string MailIDStr, int type)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@MailIDStr",   SqlDbType.VarChar,4000, MailIDStr),
									   data.MakeInParam("@DeleteType",   SqlDbType.Int,1, type) 	
								   };
            try
            {
                data.RunProc("SP_MailDelete", prams);
                data = null;
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return false;
            }

        }
        #endregion

        #region ���ĳ����
        /// <summary>
        /// ���ĳ����
        /// </summary>
        /// <param name="Username">�û���</param>
        /// <param name="FolderType">��������</param>
        public bool FolderClear(string Username, int type)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@FolderType",   SqlDbType.Int,1, type),
 									   data.MakeInParam("@Username",   SqlDbType.VarChar,30, Username)
								   };
            try
            {
                data.RunProc("SP_MailFolderClear", prams);
                data = null;
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return false;
            }

        }
        #endregion

        #region �ʼ����巢��
        /// <summary>
        /// �����ʼ���ֻ�������ݿ����
        /// </summary>
        /// <param name="mailbody">Mail��</param>
        public string Send(MailMainBody mailbody)
        {

            // create data object and params
            Database data = new Database();
            string MailID = null;
            SqlParameter[] prams = {
									   data.MakeInParam("@MailFolderType",  SqlDbType.Int, 20, mailbody.MailFolderType),
									   data.MakeInParam("@MailReceiverStr",  SqlDbType.VarChar, 300, mailbody.MailReceiverStr),
									   data.MakeInParam("@MailSendDate",  SqlDbType.DateTime, 20, DateTime.Parse(mailbody.MailSendDate)),
									   data.MakeInParam("@MailSendLevel",  SqlDbType.SmallInt,20, mailbody.MailSendLevel),
									   data.MakeInParam("@MailSender",  SqlDbType.NVarChar, 20, mailbody.MailSender),
									   data.MakeInParam("@MailReceiver",  SqlDbType.NVarChar, 20, mailbody.MailReceiver),
									   data.MakeInParam("@MailSubject",  SqlDbType.NVarChar, 50, mailbody.MailSubject),
									   data.MakeInParam("@MailBody",  SqlDbType.Text , 300000, mailbody.MailBody),
									   data.MakeInParam("@MailCcToAddr",  SqlDbType.NVarChar, 300, mailbody.MailCcToAddr),
									   data.MakeInParam("@MailBccToAddr",  SqlDbType.NVarChar, 300, mailbody.MailBccToAddr),
									   data.MakeInParam("@MailReadFlag",  SqlDbType.Bit, 1, mailbody.MailReadFlag),
									   data.MakeInParam("@MailTypeFlag",  SqlDbType.Bit, 1, mailbody.MailTypeFlag),
									   data.MakeInParam("@MailClassID",  SqlDbType.Int, 1, mailbody.MailClassID),
									   data.MakeInParam("@MailImportance",  SqlDbType.Int, 1, mailbody.MailImportance),
									   data.MakeOutParam("@MailID", SqlDbType.Int,20) 
								   };

            try
            {
                data.RunProc("SP_MailSend", prams);
                MailID = prams[14].Value.ToString();
                if (MailID == string.Empty)
                    return null;
                else
                    return MailID;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ʼ����ͳ���!", ex);
            }

        }
        #endregion

        #region ����һ���ʼ�
        /// <summary>
        /// ֻ�贫��һ��MailMainBody���󣬻��Զ����ReceiverStr,�������
        /// </summary>
        /// <param name="MailMainBody">MailMainBody���һ��ʵ�����������в�������</param>
        /// <returns>�����ʼ�ID����</returns>
        public ArrayList MailSend(MailMainBody mailbody)
        {
            string[] RecvAr = System.Text.RegularExpressions.Regex.Split(mailbody.MailReceiverStr + mailbody.MailCcToAddr + mailbody.MailBccToAddr, ",");
            ArrayList listMailID = new ArrayList();
            string RtnMailID = "";
            // ����һ���ʼ��������˷�����
            mailbody.MailFolderType = 2;
            mailbody.MailReceiver = mailbody.MailSender;
            RtnMailID = Send(mailbody);
            listMailID.Add(RtnMailID);
            // ��ʼѭ�������ʼ�
            for (int i = 0; i < RecvAr.Length - 1; i++)
            {
                mailbody.MailFolderType = 1; //�ռ���
                mailbody.MailReceiver = RecvAr[i].ToString();
                RtnMailID = Send(mailbody);
                if (RtnMailID != null)
                {
                    listMailID.Add(RtnMailID);


                }
            }
            mailbody = null;
            RecvAr = null;
            return listMailID;
        }
        #endregion

        #region �ʼ��������ݿ����
        /// <summary>
        /// �����ʼ�������ֻ�������ݿ����
        /// </summary>
        /// <param name="att">MailAttachFile��</param>
        /// <param name="MailID">�ʼ�ID</param>
        public void AttSend(MailAttachFile att, int MailID)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									data.MakeInParam("@MailID",  SqlDbType.Int, 20, MailID),
									data.MakeInParam("@FileName",  SqlDbType.VarChar, 300, att.FileName),
									data.MakeInParam("@FileSize",  SqlDbType.Int, 20, att.FileSize),
									data.MakeInParam("@FileAttribute",  SqlDbType.SmallInt,20, att.FileAttribute),
									data.MakeInParam("@FileVisualPath",  SqlDbType.NVarChar, 200, att.FileVisualPath),
									data.MakeInParam("@FileAuthor",  SqlDbType.NVarChar, 50, att.FileAuthor),
									data.MakeInParam("@FileCatlog",  SqlDbType.NVarChar, 20, att.FileCatlog)
								   };
            try
            {
                data.RunProc("SP_AddMailAttFile", prams);
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ʼ��������ͳ���!", ex);
            }

        }
        #endregion

        #region ��ȡ�ʼ�������
        /// <summary>
        /// Get  sqldatareader  from TabMailList
        /// </summary>
        public SqlDataReader GetMailCompleteInfoDbreader(string MailID)
        {
            // create data object and params
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@MailID",      SqlDbType.NVarChar, 100, MailID)
								   };


            try
            {
                // run the stored procedure
                data.RunProc("SP_MailGetCompleteInfo", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ʼ���ȡ����!", ex);
            }
        }
        #endregion

        #region ��ȡ�ʼ�����������
        /// <summary>
        /// Get  sqldatareader  from TabMailAttFiles
        /// </summary>
        public SqlDataReader GetMailAttInfoDbreader(string MailID)
        {
            // create data object and params
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@MailID",      SqlDbType.NVarChar, 100, MailID)
								   };


            try
            {
                // run the stored procedure
                data.RunProc("SP_MailGetAttachFilesInfo", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ʼ���ȡ����!", ex);
            }
        }
        #endregion

        #region �����ʼ�ID�ַ�����ȡ�ʼ�����������
        /// <summary>
        /// Get  sqldatareader  from TabMailAttFiles
        /// </summary>
        public SqlDataReader GetMailAttInfoByMailIDDbreader(string FileIDStr)
        {
            // create data object and params
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@FileIDStr",      SqlDbType.NVarChar, 4000, FileIDStr)
								   };


            try
            {
                // run the stored procedure
                data.RunProc("SP_MailGetAttachFilesInfoByMailID", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ʼ���ȡ����!", ex);
            }
        }
        #endregion

        #region �ⲿ�ʼ����ñ���
        /// <summary>
        /// �ⲿ�ʼ����ñ���
        /// </summary>
        /// <param name=""></param>
        public bool ExtSaveSetting(string username, string title, string email, bool smtpauth, string smtpserver, string smtpusername, string smtppassword, string smtpport, string popserver, string popusername, string poppassword, int popport, bool isdelafterread, bool isreceivenew, int timeout, int orderid)
        {

            // create data object and params
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@Username",  SqlDbType.NVarChar, 50, username),
									   data.MakeInParam("@Title",  SqlDbType.NVarChar , 30, title),
									   data.MakeInParam("@Email",  SqlDbType.NVarChar , 200, email),
									   data.MakeInParam("@SmtpAuth",  SqlDbType.Bit, 1, smtpauth),
									   data.MakeInParam("@SmtpServer",  SqlDbType.NVarChar,100, smtpserver),
									   data.MakeInParam("@SmtpUsername",  SqlDbType.NVarChar, 30, smtpusername),
									   data.MakeInParam("@SmtpPassword",  SqlDbType.NVarChar, 30, smtppassword),
									   data.MakeInParam("@SmtpPort",  SqlDbType.Int, 10, smtpport),
									   data.MakeInParam("@PopServer",  SqlDbType.NVarChar , 100, popserver),
									   data.MakeInParam("@PopUsername",  SqlDbType.NVarChar, 30, popusername),
									   data.MakeInParam("@PopPassword",  SqlDbType.NVarChar, 30, poppassword),
									   data.MakeInParam("@PopPort",  SqlDbType.Int, 10, popport),
									   data.MakeInParam("@IsDelAfterRead",  SqlDbType.Bit, 1, isdelafterread),
									   data.MakeInParam("@IsReceiveNew",  SqlDbType.Bit, 1, isreceivenew),
									   data.MakeInParam("@TimeOut",  SqlDbType.Int, 10, timeout),
									   data.MakeInParam("@OrderID",  SqlDbType.Int, 10, orderid)	 
								   };

            try
            {
                data.RunProc("SP_MailExtSetAdd", prams);
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ⲿ�ʼ����ñ������!", ex);
            }

        }
        #endregion

        #region ���ĳ�û��ⲿ�ʼ�����
        /// <summary>
        /// ���ĳ�û��ⲿ�ʼ�����
        /// </summary>
        /// <param name="Username">�û���</param>
        public bool ExtClearSettings(string Username)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@Username",   SqlDbType.NVarChar,50, Username),
								   };
            try
            {
                data.RunProc("SP_MailExtSetClear", prams);
                data = null;
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return false;
            }

        }
        #endregion

        #region ��ȡ���õ�����
        /// <summary>
        /// ��ȡ���õ�����	
        /// </summary>
        public SqlDataReader ExtGetSetting(string Username, int OrderID)
        {
            // create data object and params
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@Username",      SqlDbType.NVarChar, 20, Username),
									   data.MakeInParam("@OrderID",      SqlDbType.Int, 1, OrderID)
								   };


            try
            {
                // run the stored procedure
                data.RunProc("SP_MailExtGetSet", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��ȡ���õ����ݳ���!", ex);
            }
        }
        #endregion

        #region ��ȡ���õ������õ�����
        /// <summary>
        /// ��ȡ���õ������õ�����	
        /// </summary>
        public SqlDataReader ExtGetAvaSetting(string Username)
        {
            // create data object and params
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									data.MakeInParam("@Username",      SqlDbType.NVarChar, 20, Username)
								};


            try
            {
                // run the stored procedure
                data.RunProc("SP_MailExtGetAvailabelSet", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("��ȡ���õ������õ����ݳ���!", ex);
            }
        }
        #endregion

        #region	�ⲿ�ʼ����屣��
        /// <summary>
        /// �ⲿ�ʼ����屣��
        /// </summary>
        /// <param name="mailbody">Mail��</param>
        public void SaveExtMail(jmail.Message JMsg, string Username, string Email, string MessageID)
        {

            // create data object and params
            Database data = new Database();
            /*
            SqlParameter[] prams = {
                                       data.MakeInParam("@MailID",  SqlDbType.NVarChar , 10, ""),
                                       data.MakeInParam("@Username",  SqlDbType.NVarChar, 300, Username),
                                       data.MakeInParam("@Email",  SqlDbType.NVarChar, 100,"" ),
                                       data.MakeInParam("@ReadFlag",  SqlDbType.Bit,1, 0),
                                       data.MakeInParam("@FolderID",  SqlDbType.Int, 20, 1),
                                       data.MakeInParam("@HeadersText",  SqlDbType.NVarChar, 1000, Msg.Headers.ToString()),
                                       data.MakeInParam("@Subject",  SqlDbType.NVarChar, 100, Msg.Subject.ToString()),
                                       data.MakeInParam("@TextContent",  SqlDbType.NVarChar , 3000, Msg.Text.ToString()),
                                       data.MakeInParam("@HtmlContent",  SqlDbType.NVarChar, 3000, Msg.HTMLBody.ToString()),
                                       data.MakeInParam("@FromName",  SqlDbType.NVarChar, 300, Msg.FromName.ToString()),
                                       data.MakeInParam("@FromEmail",  SqlDbType.NVarChar, 200, Msg.From.ToString()),
                                       data.MakeInParam("@CcTo",  SqlDbType.NVarChar, 200,""),
                                       data.MakeInParam("@BccTo",  SqlDbType.NVarChar, 200, ""),
                                       data.MakeInParam("@Replyto",  SqlDbType.NVarChar, 200, Msg.ReplyTo.ToString()),
                                       data.MakeInParam("@SendDate",  SqlDbType.DateTime, 30, DateTime.Now),
                                       data.MakeInParam("@BodySize",  SqlDbType.NVarChar , 20, ""),
                                       data.MakeInParam("@Size",  SqlDbType.Int, 5,12)
									 
                                   };
            */
            SqlParameter[] prams = {
									   data.MakeInParam("@MailID",    SqlDbType.NVarChar , 100, MessageID),
									   data.MakeInParam("@Username",  SqlDbType.NVarChar, 300, Username),
									   data.MakeInParam("@Email",     SqlDbType.NVarChar, 100,Email),
									   data.MakeInParam("@ReadFlag",  SqlDbType.Bit,1, 0),
									   data.MakeInParam("@FolderID",  SqlDbType.Int, 20, 1),
									   data.MakeInParam("@HeadersText",  SqlDbType.NVarChar, 1000, JMsg.Headers .ToString()),
									   data.MakeInParam("@Subject",   SqlDbType.NVarChar, 100, JMsg.Subject.ToString()),
									   data.MakeInParam("@TextContent",  SqlDbType.NVarChar , 3000, JMsg.Text.ToString()),
									   data.MakeInParam("@HtmlContent",  SqlDbType.NVarChar, 3000, JMsg.HTMLBody.ToString()),
									   data.MakeInParam("@FromName",  SqlDbType.NVarChar, 300, JMsg.FromName.ToString()),
									   data.MakeInParam("@FromEmail", SqlDbType.NVarChar, 200, ""),
									   data.MakeInParam("@CcTo",      SqlDbType.NVarChar, 200,""),
									   data.MakeInParam("@BccTo",     SqlDbType.NVarChar, 200, ""),
									   data.MakeInParam("@Replyto",   SqlDbType.NVarChar, 200, ""),
									   data.MakeInParam("@SendDate",  SqlDbType.DateTime, 30, DateTime.Parse(JMsg.Date.ToString())),
									   data.MakeInParam("@BodySize",  SqlDbType.NVarChar , 20, ""),
									   data.MakeInParam("@Size",      SqlDbType.Int, 5,12)
									 
								   };
            try
            {
                data.RunProc("SP_MailExtMailAdd", prams);
                data = null;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("�ⲿ�ʼ��������!", ex);
            }

        }
        #endregion

        #region �����ⲿ�ʼ�

        public void ReceiveMails(string Username, int OrderID)
        {
            jmail.Message Msg = new jmail.Message();
            jmail.POP3 jpop = new jmail.POP3();
            if (OrderID != 0)
            {
                SqlDataReader dataReader = this.ExtGetSetting(Username, OrderID);
                try
                {
                    if (dataReader.Read())
                    {
                        if (dataReader["PopServer"].ToString() != "" && dataReader["PopUsername"].ToString() != "")
                        {
                            jpop.Connect(dataReader["PopUsername"].ToString(), dataReader["PopPassword"].ToString(), dataReader["PopServer"].ToString(), Int32.Parse(dataReader["PopPort"].ToString()));
                            for (int i = 1; i <= jpop.Count; i++)
                            {
                                Msg = jpop.Messages[i];
                                this.SaveExtMail(Msg, Username, dataReader["Email"].ToString(), jpop.GetMessageUID(i));

                            }
                            jpop.Disconnect();
                        }
                    }
                }
                finally
                {

                    dataReader.Close();
                }
            }

        }

        #endregion
    }

    public class MailMainBody
    {
        private int m_MailFolderType;
        private string m_MailReceiverStr;
        private int m_MailSendLevel;
        private string m_MailSendDate;
        private string m_MailReceiver;
        private string m_MailSender;
        private string m_MailSubject;
        private string m_MailBody;
        private string m_MailCcToAddr;
        private string m_MailBccToAddr;
        private int m_MailReadFlag;
        private int m_MailTypeFlag;
        private int m_MailClassID;
        private int m_MailImportance;
        //�ⲿ�ʼ���
        private string m_ExtHeadersText;
        private string m_ExtHtmlContent;
        private string m_ExtFromName;
        private string m_ExtFromEmail;
        private string m_ExtReplyTo;
        private string m_ExtMailID;


        public int MailFolderType
        {
            //��������
            get { return m_MailFolderType; }
            set { m_MailFolderType = value; }
        }

        public string MailReceiverStr
        {
            //�ռ����ַ������ö��Ÿ���
            get { return m_MailReceiverStr; }
            set { m_MailReceiverStr = value; }
        }

        public string MailSendDate
        {
            //��������
            get { return m_MailSendDate; }
            set { m_MailSendDate = value; }
        }

        public int MailSendLevel
        {
            //���ͼ���
            get { return m_MailSendLevel; }
            set { m_MailSendLevel = value; }
        }

        public string MailSender
        {
            //�����˵�½��
            get { return m_MailSender; }
            set { m_MailSender = value; }
        }

        public string MailReceiver
        {
            //�ռ����˵�½��
            get { return m_MailReceiver; }
            set { m_MailReceiver = value; }
        }

        public string MailSubject
        {
            //�ʼ�����
            get { return m_MailSubject; }
            set { m_MailSubject = value; }
        }

        public string MailBody
        {
            //�ʼ�����
            get { return m_MailBody; }
            set { m_MailBody = value; }
        }

        public string MailCcToAddr
        {
            //���͵�ַ
            get { return m_MailCcToAddr; }
            set { m_MailCcToAddr = value; }
        }

        public string MailBccToAddr
        {
            //���ܳ��͵�ַ
            get { return m_MailBccToAddr; }
            set { m_MailBccToAddr = value; }
        }

        public int MailReadFlag
        {
            //�Ƿ��Ѷ���־ 0 δ�� 1�Ѷ�
            get { return m_MailReadFlag; }
            set { m_MailReadFlag = value; }
        }

        public int MailTypeFlag
        {
            //�ʼ����� 0 Ϊ�ڲ� 1Ϊ�ⲿ
            get { return m_MailTypeFlag; }
            set { m_MailTypeFlag = value; }
        }

        public int MailClassID
        {
            //������ĿID
            get { return m_MailClassID; }
            set { m_MailClassID = value; }
        }

        public int MailImportance
        {
            //�ʼ���Ҫ�� 
            get { return m_MailImportance; }
            set { m_MailImportance = value; }
        }

        public string ExtHeadersText
        {
            //�ʼ�ͷ��Ϣ
            get { return m_ExtHeadersText; }
            set { m_ExtHeadersText = value; }
        }

        public string ExtHtmlContent
        {
            //Html��ʽ�ʼ�����
            get { return m_ExtHtmlContent; }
            set { m_ExtHtmlContent = value; }
        }

        public string ExtFromName
        {
            //����������
            get { return m_ExtFromName; }
            set { m_ExtFromName = value; }
        }

        public string ExtFromEmail
        {
            //������Email
            get { return m_ExtFromEmail; }
            set { m_ExtFromEmail = value; }
        }

        public string ExtReplyTo
        {
            //�ظ���
            get { return m_ExtReplyTo; }
            set { m_ExtReplyTo = value; }
        }

        public string ExtMailID
        {
            //�ʼ���Ψһ��ʶ
            get { return m_ExtMailID; }
            set { m_ExtMailID = value; }
        }

    }

    public class MailAttachFile
    {
        private int m_FileID;
        private int m_DocID;
        private string m_FileName;
        private int m_FileSize;
        private int m_FileAttribute;
        private string m_FileVisualPath;
        private string m_FileAuthor;
        private string m_FileCatlog;

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
    }
}