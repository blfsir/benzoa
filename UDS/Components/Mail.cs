using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Configuration;

namespace UDS.Components
{
    /// <summary>
    /// Mail处理类
    /// </summary>
    public class MailClass
    {

        #region 将DataReader 转为 DataTable
        /// <summary>
        /// 将DataReader 转为 DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        //public DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        //{
        //    DataTable datatable = new DataTable();
        //    DataTable schemaTable = dataReader.GetSchemaTable();
        //    //动态添加列
        //    try
        //    {

        //        foreach (DataRow myRow in schemaTable.Rows)
        //        {
        //            DataColumn myDataColumn = new DataColumn();
        //            myDataColumn.DataType = myRow.GetType();
        //            myDataColumn.ColumnName = myRow[0].ToString();
        //            datatable.Columns.Add(myDataColumn);
        //        }
        //        //添加数据
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

        #region 获取某用户的某信箱中的信件 返回DataTable
        /// <summary>
        ///获取某邮箱中的信件 返回DataTable
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="FolderType">邮箱类型</param>
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

        #region 获取某项目中的信件 返回DataTable
        /// <summary>
        ///获取某项目中的信件 返回DataTable
        /// </summary>
        /// <param name="ClassID">项目ID</param>
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

        #region 获取某用户的某信箱中的信件 返回SqlDataReader
        /// <summary>
        ///获取某邮箱中的信件 返回SqlDataReader
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="FolderType">邮箱类型</param>
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

        #region 将一组邮件移至指定信箱
        /// <summary>
        /// 将一组邮件移至指定信箱
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="MailIDStr">邮件ID的连接字符串，用逗号相隔开</param>
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

        #region 删除一组邮件
        /// <summary>
        /// 彻底删除一组邮件
        /// </summary>
        /// <param name="MailIDStr">邮件ID的连接字符串，用逗号相隔开</param>
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

        #region 清空某邮箱
        /// <summary>
        /// 清空某邮箱
        /// </summary>
        /// <param name="Username">用户名</param>
        /// <param name="FolderType">邮箱类型</param>
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

        #region 邮件主体发送
        /// <summary>
        /// 发送邮件，只包括数据库操作
        /// </summary>
        /// <param name="mailbody">Mail类</param>
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
                throw new Exception("邮件发送出错!", ex);
            }

        }
        #endregion

        #region 发送一组邮件
        /// <summary>
        /// 只需传入一个MailMainBody对象，会自动拆分ReceiverStr,逐个发送
        /// </summary>
        /// <param name="MailMainBody">MailMainBody类的一个实例，用来进行参数传递</param>
        /// <returns>返回邮件ID数组</returns>
        public ArrayList MailSend(MailMainBody mailbody)
        {
            string[] RecvAr = System.Text.RegularExpressions.Regex.Split(mailbody.MailReceiverStr + mailbody.MailCcToAddr + mailbody.MailBccToAddr, ",");
            ArrayList listMailID = new ArrayList();
            string RtnMailID = "";
            // 发送一封邮件至发件人发件箱
            mailbody.MailFolderType = 2;
            mailbody.MailReceiver = mailbody.MailSender;
            RtnMailID = Send(mailbody);
            listMailID.Add(RtnMailID);
            // 开始循环发送邮件
            for (int i = 0; i < RecvAr.Length - 1; i++)
            {
                mailbody.MailFolderType = 1; //收件箱
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

        #region 邮件附件数据库操作
        /// <summary>
        /// 发送邮件附件，只包括数据库操作
        /// </summary>
        /// <param name="att">MailAttachFile类</param>
        /// <param name="MailID">邮件ID</param>
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
                throw new Exception("邮件附件发送出错!", ex);
            }

        }
        #endregion

        #region 获取邮件的内容
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
                throw new Exception("邮件读取出错!", ex);
            }
        }
        #endregion

        #region 获取邮件附件的内容
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
                throw new Exception("邮件读取出错!", ex);
            }
        }
        #endregion

        #region 根据邮件ID字符串获取邮件附件的内容
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
                throw new Exception("邮件读取出错!", ex);
            }
        }
        #endregion

        #region 外部邮件设置保存
        /// <summary>
        /// 外部邮件设置保存
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
                throw new Exception("外部邮件设置保存出错!", ex);
            }

        }
        #endregion

        #region 清空某用户外部邮件设置
        /// <summary>
        /// 清空某用户外部邮件设置
        /// </summary>
        /// <param name="Username">用户名</param>
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

        #region 获取设置的内容
        /// <summary>
        /// 获取设置的内容	
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
                throw new Exception("获取设置的内容出错!", ex);
            }
        }
        #endregion

        #region 获取可用到的设置的内容
        /// <summary>
        /// 获取可用到的设置的内容	
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
                throw new Exception("获取可用到的设置的内容出错!", ex);
            }
        }
        #endregion

        #region	外部邮件主体保存
        /// <summary>
        /// 外部邮件主体保存
        /// </summary>
        /// <param name="mailbody">Mail类</param>
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
                throw new Exception("外部邮件保存出错!", ex);
            }

        }
        #endregion

        #region 接收外部邮件

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
        //外部邮件用
        private string m_ExtHeadersText;
        private string m_ExtHtmlContent;
        private string m_ExtFromName;
        private string m_ExtFromEmail;
        private string m_ExtReplyTo;
        private string m_ExtMailID;


        public int MailFolderType
        {
            //邮箱类型
            get { return m_MailFolderType; }
            set { m_MailFolderType = value; }
        }

        public string MailReceiverStr
        {
            //收件人字符串，用逗号隔开
            get { return m_MailReceiverStr; }
            set { m_MailReceiverStr = value; }
        }

        public string MailSendDate
        {
            //发送日期
            get { return m_MailSendDate; }
            set { m_MailSendDate = value; }
        }

        public int MailSendLevel
        {
            //发送级别
            get { return m_MailSendLevel; }
            set { m_MailSendLevel = value; }
        }

        public string MailSender
        {
            //发件人登陆名
            get { return m_MailSender; }
            set { m_MailSender = value; }
        }

        public string MailReceiver
        {
            //收件件人登陆名
            get { return m_MailReceiver; }
            set { m_MailReceiver = value; }
        }

        public string MailSubject
        {
            //邮件主题
            get { return m_MailSubject; }
            set { m_MailSubject = value; }
        }

        public string MailBody
        {
            //邮件主体
            get { return m_MailBody; }
            set { m_MailBody = value; }
        }

        public string MailCcToAddr
        {
            //抄送地址
            get { return m_MailCcToAddr; }
            set { m_MailCcToAddr = value; }
        }

        public string MailBccToAddr
        {
            //秘密抄送地址
            get { return m_MailBccToAddr; }
            set { m_MailBccToAddr = value; }
        }

        public int MailReadFlag
        {
            //是否已读标志 0 未读 1已读
            get { return m_MailReadFlag; }
            set { m_MailReadFlag = value; }
        }

        public int MailTypeFlag
        {
            //邮件类型 0 为内部 1为外部
            get { return m_MailTypeFlag; }
            set { m_MailTypeFlag = value; }
        }

        public int MailClassID
        {
            //所属项目ID
            get { return m_MailClassID; }
            set { m_MailClassID = value; }
        }

        public int MailImportance
        {
            //邮件重要性 
            get { return m_MailImportance; }
            set { m_MailImportance = value; }
        }

        public string ExtHeadersText
        {
            //邮件头信息
            get { return m_ExtHeadersText; }
            set { m_ExtHeadersText = value; }
        }

        public string ExtHtmlContent
        {
            //Html格式邮件内容
            get { return m_ExtHtmlContent; }
            set { m_ExtHtmlContent = value; }
        }

        public string ExtFromName
        {
            //发送人姓名
            get { return m_ExtFromName; }
            set { m_ExtFromName = value; }
        }

        public string ExtFromEmail
        {
            //发送人Email
            get { return m_ExtFromEmail; }
            set { m_ExtFromEmail = value; }
        }

        public string ExtReplyTo
        {
            //回复至
            get { return m_ExtReplyTo; }
            set { m_ExtReplyTo = value; }
        }

        public string ExtMailID
        {
            //邮件的唯一标识
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
    }
}