using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Runtime.InteropServices;

namespace UDS.Components
{
	/// <summary>
	/// SMS 
	/// </summary>
	public class SMS
	{
		
		
		int CommIndex = 1;

		/*
		#region �������
		[DllImport("../bin/AscendSMS.dll")]
		public static extern int OpenComm(int CommIndex);
		[DllImport("../bin/AscendSMS.dll")]
		public static extern int CloseComm(int CommIndex);
		[DllImport("../bin/AscendSMS.dll")]
		public static extern int ForceCloseComm(int CommIndex);
		[DllImport("../bin/AscendSMS.dll")]
		public static extern int SendMsg(int CommIndex,string Msg,string MobileNo,int Msg_Index,bool Chinese);
		[DllImport("../bin/AscendSMS.dll")]
		public static extern int GetUnSendCount(int CommIndex);
		[DllImport("../bin/AscendSMS.dll")]
		public static extern bool GetNextSendMsg(int CommIndex, string Msg,bool DeleteAfterRead);
		[DllImport("../bin/AscendSMS.dll")]
		public static extern bool GetNewMsg(int CommIndex,  string Msg);
		#endregion
		
	
		/// <summary>
		/// ���Ͷ���Ϣ
		/// ���ز����� 0 �ɹ� -2 ��Ϣ�������� -3 �ֻ����벻��ȷ -4 ������������ -8 ģ��δ�� -1 ����δ��
		/// </summary>
		/// <param name="Msg">����Ϣ����</param>
		/// <param name="MobileNo">Ŀ����ֻ�����,����һ����뼰�������</param>
		/// <param name="MsgIndex">����Ϣ��־λ</param>
		/// <param name="IsZh">�Ƿ�����(����ΪTrue,����ΪFalse)</param>
		/// <returns>������</returns>
		public int SendMobileMsg(string Msg, string MobileNo, int MsgIndex,bool IsZh) 
		{
			CloseComm(CommIndex);
			OpenComm(CommIndex); 
			String[] MoA = MobileNo.Split(',');
			String[] RtnCodeA = MoA;
			for(int i=0;i<MoA.Length;i++)
			{
				int RtnCode = SendMsg(CommIndex,Msg,MoA[i],MsgIndex,IsZh);
				RtnCodeA[i] = RtnCode.ToString();
			}
			CloseComm(CommIndex);
			if(RtnCodeA[0]=="0")
				return 0;
			else
				return -1;
		}		
		
	*/

		public SMS()
		{
			//
			// TODO: 
			//
		}
		/// <summary>
		/// �õ���������
		/// </summary>
		/// <returns>����int</returns>
		public int GetOnlineCount()
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			try 
			{
				data.RunProc("SP_SMS_GetOnlineCount",out dataReader);
				if(dataReader.Read()) return Int32.Parse(dataReader[0].ToString());
				else return 0;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("��ȡ������������!",ex);
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
				data	   = null;
				dataReader = null;
			}
		}

		/// <summary>
		/// �õ�����Ϣ����
		/// </summary>
		/// <returns>����int</returns>
		public int GetNewMsgCount(string Username)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			SqlParameter[] prams = {
									   data.MakeInParam("@username",    SqlDbType.VarChar, 50, Username)
								   };
			try 
			{
				data.RunProc("SP_SMS_GetNewMsgCount",prams,out dataReader);
				if(dataReader.Read()) return Int32.Parse(dataReader[0].ToString());
				else return 0;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("�õ�����Ϣ��������!",ex);
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
				data	   = null;
				dataReader = null;
			}
		}

		/// <summary>
		/// ����Ϣ
		/// </summary>
		public bool ReadMsg(string MsgIDS,string Username)
		{
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@MsgIDS",    SqlDbType.VarChar, 2000, MsgIDS),
									   data.MakeInParam("@Username",    SqlDbType.VarChar, 20, Username),
								   };
			try 
			{
				data.RunProc("SP_SMS_ReadMsg",prams);
				return true;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
			//	throw new Exception("����Ϣ����!",ex);
				return false;
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


		/// <summary>
		/// �������߼�¼��.����µ�������Ա
		/// </summary>
		public void UpdateOnlineInfo(string Username,string HostAddr,string SessionID)
		{
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@username",    SqlDbType.VarChar, 50, Username),
									   data.MakeInParam("@hostaddr",    SqlDbType.VarChar, 50, HostAddr),
									   data.MakeInParam("@sessionid",   SqlDbType.VarChar, 50, SessionID)
								   };
			try 
			{
				data.RunProc("SP_SMS_UpdateOnlineInfo",prams);
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("�������߼�¼�����!",ex);
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

		/// <summary>
		/// ���»��¼�����δ���Ա
		/// </summary>
		public string CheckUpdate(string Username,string SessionID,int ActiveNodeID)
		{
			string ReturnStr = "";
			int ReturnID = 0;
			int NewMsgFlag = 0;
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@username",    SqlDbType.VarChar, 100, Username),
									   data.MakeInParam("@sessionid",   SqlDbType.VarChar, 100, SessionID),
									   data.MakeInParam("@ActiveNodeID",   SqlDbType.Int, 4, ActiveNodeID),
									   data.MakeOutParam("@ReturnID", SqlDbType.Int, 4),
									   data.MakeOutParam("@NewMsgFlag", SqlDbType.Int, 4)
			};
			try 
			{
				data.RunProc("SP_SMS_CheckUpdate",prams);
				ReturnID =  Int32.Parse(prams[3].Value.ToString()); 
				if(ReturnID==-1)
					NewMsgFlag = 0;
				else
                    NewMsgFlag =  Int32.Parse(prams[4].Value.ToString()); 
				ReturnStr = ReturnID.ToString()+"|"+NewMsgFlag.ToString();
				data = null;
				return ReturnStr;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("���»��¼�����δ���Ա����!",ex);
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

		/// <summary>
		/// �õ�����������Ա
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetOnlinePerson()
		{
			Database data = new Database();
			SqlDataReader dr = null;
			try 
			{
				data.RunProc("sp_SMS_GetOnlinePerson",out dr);
				return dr;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("��ȡ������Ա���ݳ���!",ex);
			}
			finally
			{
                //if (data != null)
                //{
                //    data.Close();
                //}
                //if (dr != null)
                //{
                //    dr.Close();
                //}
				data	   = null;
				dr		   = null;
			}
		}

		/// <summary>
		/// �õ������¼
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetHistory(string Receiver,string Sender)
		{
			Database data = new Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   data.MakeInParam("@Sender",    SqlDbType.VarChar, 50, Sender),
									   data.MakeInParam("@Receiver",   SqlDbType.VarChar, 50, Receiver)
			};
			try 
			{
				data.RunProc("SP_SMS_GetHistory",prams,out dr);
				return dr;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("�õ������¼����!",ex);
			}
			finally
			{
                //if (data != null)
                //{
                //    data.Close();
                //}
                //if (dr != null)
                //{
                //    dr.Close();
                //}
				data	   = null;
				dr		   = null;
			}
		}

		/// <summary>
		/// �õ��������յ����ж�Ѷ
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetMyReceive(string Username)
		{
			Database data = new Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",    SqlDbType.VarChar, 50, Username)
								    };
			try 
			{
				data.RunProc("SP_SMS_GetMyAllMsg",prams,out dr);
				return dr;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("�õ��������յ����ж�Ѷ����!",ex);
			}
            //finally
            //{
            //    if (data != null)
            //    {
            //        data.Close();
            //    }
            //    if (dr != null)
            //    {
            //        dr.Close();
            //    }
            //    data	   = null;
            //    dr		   = null;
            //}
		}

		/// <summary>
		/// �õ��������͵����ж�Ѷ
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetMySent(string Username)
		{
			Database data = new Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   data.MakeInParam("@Username",    SqlDbType.VarChar, 50, Username)
								   };
			try 
			{
				data.RunProc("SP_SMS_GetMySent",prams,out dr);
				return dr;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("�õ��������յ����ж�Ѷ����!",ex);
			}
			finally
			{
                //if (data != null)
                //{
                //    data.Close();
                //}
                //if (dr != null)
                //{
                //    dr.Close();
                //}
				data	   = null;
				dr		   = null;
			}

		}
		/// <summary>
		/// �õ�ĳ���˵�����һ����Ϣ
		/// </summary>
		/// <returns></returns>
		public SqlDataReader GetNewLocalMsg(string Username)
		{
			Database data = new Database();
			SqlDataReader dr = null;
			SqlParameter[] prams = {
									   data.MakeInParam("@username",    SqlDbType.VarChar, 50, Username)
									};
			try 
			{
				data.RunProc("sp_SMS_GetNewMsg",prams,out dr);
				return dr;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("�õ�ĳ���˵�����һ����Ϣ����!",ex);
			}
			finally
			{
                //if (data != null)
                //{
                //    data.Close();
                //}
                //if (dr != null)
                //{
                //    dr.Close();
                //}
				data	   = null;
				dr		   = null;
			}
		}


		/// <summary>
		/// ����վ�ڶ���Ϣ
		/// </summary>
		/// <param name="sender">�������û���</param>
		/// <param name="receivers">�������û��������ö����������</param>
		/// <param name="msg">����Ϣ����</param>
		/// <param name="sendtime">����Ϣ����ʱ��</param>
		/// <returns>�޷���ֵ</returns>
		public void SendLocalMsg(string sender,string receivers,string msg,DateTime sendtime)
		{
			string newmsgid = "0";
			Database data = new Database();
			
			#region ����Ϣ�����ݿ⣬����MsgID
			SqlParameter[] prams1 = {
									   data.MakeInParam("@sender",    SqlDbType.VarChar, 50, sender),
									   data.MakeInParam("@content",   SqlDbType.VarChar, 255, msg),
									   data.MakeInParam("@type",   SqlDbType.Int, 1, 1),	
									   data.MakeInParam("@sendtime",   SqlDbType.DateTime, 30, sendtime),
									   data.MakeOutParam("@newmsgid", SqlDbType.Int, 4)									
								   };
            try
            {
                data.RunProc("SP_SMS_SendLocalMsg", prams1);
                newmsgid = prams1[4].Value.ToString();
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("����Ϣ�����ݿ����!", ex);
            }
            finally {
                if (data != null)
                {
                    data.Close();
                } 
            }
			#endregion

			#region ����Ϣ������߹���
			SqlParameter[] prams2 = {
									   data.MakeInParam("@MsgID",    SqlDbType.Int, 4, Int32.Parse(newmsgid)),
									   data.MakeInParam("@Receivers",SqlDbType.VarChar, 5000, receivers),
									   data.MakeInParam("@MobileNo",   SqlDbType.VarChar, 4, ""),	
									  data.MakeInParam("@type",   SqlDbType.Int, 1, 1)
								   };
            try
            {
                data.RunProc("SP_SMS_SetMsgReceiver", prams2);
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("����Ϣ������߹�������!", ex);
            }
            finally {
                if (data != null)
                {
                    data.Close();
                } 
            }
			#endregion


		}

	
		/// <summary>
		///  ��վ�û�վ���ֻ�����Ϣ
		/// </summary>
		/// <param name="Sender">�������û���</param>
		/// <param name="RecipientMobileNo">�������ֻ����룬���ö����������</param>
		/// <param name="Content">����Ϣ����</param>
		/// <param name="Sendtime">����Ϣ����ʱ��</param>
		/// <param name="RepeatTimes">����Ϣ�ظ����ʹ���</param>
		/// <param name="RepeatPeriod">�ظ��������ڣ��Է���Ϊ��λ</param>
		/// <returns>����ִ�д��� 1 ���� 2 ����</returns>
		public static int SaveMobileMsgToBuffer(string Sender,string RecipientMobileNo,string Content,DateTime Sendtime,int RepeatTimes,int RepeatPeriod)
		{
			Database data = new Database();
			#region ����Ϣ�����ݿ⣬����MsgID
			SqlParameter[] prams1 = {
										data.MakeInParam("@Sender",    SqlDbType.VarChar, 50, Sender),
										data.MakeInParam("@RecipientMobileNo",   SqlDbType.VarChar, 255, RecipientMobileNo),
										data.MakeInParam("@Content",   SqlDbType.VarChar, 255, Content),	
										data.MakeInParam("@Sendtime",   SqlDbType.DateTime, 30, Sendtime),
										data.MakeInParam("@RepeatTimes", SqlDbType.Int, 4,RepeatTimes),
										data.MakeInParam("@RepeatPeriod", SqlDbType.Int, 4,RepeatPeriod)						
									};
            try
            {
                data.RunProc("SP_SMS_SaveMobileMsgToBuffer", prams1);
                return 1;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("����Ϣ�����ݿ����!", ex);
            }
            finally {
                if (data != null)
                {
                    data.Close();
                } 
            }
			#endregion

		}



		
		/// <summary>
		/// ���Ͷ���Ϣ
		/// </summary>
		/// <param name="sender">�������û���</param>
		/// <param name="receivers">�������û��������ö����������</param>
		/// <param name="msg">����Ϣ����</param>
		/// <param name="type">����Ϣ���� 1Ϊվ����Ϣ 2Ϊ�ֻ���Ѷ 3Ϊվ���ֻ�(ȡmobileno)</param>
		/// <param name="sendtime">����Ϣ����ʱ��</param>
		/// <param name="mobileno">�����վ���û�ʱ�á���ʾվ���û����ֻ���</param>
		/// <param name="repeattimes">������ֻ���Ѷʱ�á���ʾ����ѶϢ���ظ����ʹ���</param>
		/// <param name="repeattimes">������ֻ���Ѷʱ�á���ʾ����ѶϢ���ظ�����ʱ����(�Է���Ϊ��λ)</param>
		/// <returns>���ز�����������</returns>
		public int SendMsg(string sender,string recipients,string msg,int type,DateTime sendtime,string mobileno,int repeattimes,int repeatperiod)
		{
			int RtnCode = 1;
			//ȥ�����һλ�Ķ���,���滻ȫ�������
			if(recipients.EndsWith(",")) recipients = recipients.Substring(0,recipients.Length-1);
			recipients = recipients.Replace("��",",");
			
			switch (type)
			{
				case 1://վ���û���վ�ڶ�Ѷ
					SendLocalMsg(sender,recipients,msg,sendtime);
					return RtnCode;
					
				case 2: //վ���û����ֻ���Ѷ
					string MobileNoStr = GetMobileNoByUsername(recipients);
					RtnCode =  SaveMobileMsgToBuffer(sender,MobileNoStr,msg,sendtime,repeattimes,repeatperiod);
					return RtnCode;
					
				case 3: //վ���û����ֻ���Ѷ
					RtnCode = SaveMobileMsgToBuffer(sender,mobileno,msg,sendtime,repeattimes,repeatperiod);
					return RtnCode;
					
				default:
					return RtnCode;
					
			}
			
			
			
		}

		#region �����û����ַ�����ȡ�ֻ������ַ���
		/// <summary>
		/// �����û����ַ�����ȡ�ֻ������ַ���
		/// <param name="Username">�û����ַ������ö������</param>
		/// <returns>�����ֻ��ַ���</returns>
		/// </summary>
		public string GetMobileNoByUsername(string Username)
		{
			string MobileNoStr = "";
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@UserNameStr",    SqlDbType.VarChar, 3000, Username),
									   data.MakeOutParam("@MobileNoStr", SqlDbType.VarChar, 3000)
			};
			try 
			{
				data.RunProc("SP_SMS_GetMobileNoByUsername",prams);
				MobileNoStr =  prams[1].Value.ToString();   
				return MobileNoStr;
			}
			catch(Exception ex)
			{
				Error.Log(ex.ToString());
				throw new Exception("�����û����ַ�����ȡ�ֻ������ַ�������!",ex);
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


		
		/// <summary>
		/// ɾ��һ���Ѷ
		/// </summary>
		/// <param name="MsgIDS">��ϢID�������ַ������ö��������</param>
		public bool MsgDelete(string MsgIDS)
		{
			Database data = new Database();
			SqlParameter[] prams = {
									   data.MakeInParam("@MsgIDS",   SqlDbType.VarChar,4000, MsgIDS)
								   };
            try
            {
                data.RunProc("SP_SMS_DelMsg", prams);
                data = null;
                return true;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return false;
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                
            }

		}
		

	}
}
