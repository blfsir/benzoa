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
		#region 引用组件
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
		/// 发送短消息
		/// 返回操作码 0 成功 -2 消息超过长度 -3 手机号码不正确 -4 发送阵列已满 -8 模块未打开 -1 串口未打开
		/// </summary>
		/// <param name="Msg">短消息内容</param>
		/// <param name="MobileNo">目标端手机号码,包括一般号码及特殊号码</param>
		/// <param name="MsgIndex">短消息标志位</param>
		/// <param name="IsZh">是否中文(中文为True,否则为False)</param>
		/// <returns>操作码</returns>
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
		/// 得到在线人数
		/// </summary>
		/// <returns>返回int</returns>
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
				throw new Exception("读取在线人数出错!",ex);
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
		/// 得到新消息总数
		/// </summary>
		/// <returns>返回int</returns>
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
				throw new Exception("得到新消息总数出错!",ex);
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
		/// 读消息
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
			//	throw new Exception("读消息出错!",ex);
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
		/// 更新在线记录表.添加新的在线人员
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
				throw new Exception("更新在线记录表出错!",ex);
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
		/// 更新活动记录及检测未活动人员
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
				throw new Exception("更新活动记录及检测未活动人员出错!",ex);
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
		/// 得到所有在线人员
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
				throw new Exception("读取在线人员数据出错!",ex);
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
		/// 得到聊天记录
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
				throw new Exception("得到聊天记录出错!",ex);
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
		/// 得到我所接收的所有短讯
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
				throw new Exception("得到我所接收的所有短讯出错!",ex);
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
		/// 得到我所发送的所有短讯
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
				throw new Exception("得到我所接收的所有短讯出错!",ex);
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
		/// 得到某个人的最新一条消息
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
				throw new Exception("得到某个人的最新一条消息出错!",ex);
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
		/// 发送站内短消息
		/// </summary>
		/// <param name="sender">发送者用户名</param>
		/// <param name="receivers">接受者用户名，可用逗号相隔多人</param>
		/// <param name="msg">短消息内容</param>
		/// <param name="sendtime">短消息发送时间</param>
		/// <returns>无返回值</returns>
		public void SendLocalMsg(string sender,string receivers,string msg,DateTime sendtime)
		{
			string newmsgid = "0";
			Database data = new Database();
			
			#region 存消息至数据库，返回MsgID
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
                throw new Exception("存消息至数据库出错!", ex);
            }
            finally {
                if (data != null)
                {
                    data.Close();
                } 
            }
			#endregion

			#region 将消息与接收者关联
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
                throw new Exception("将消息与接收者关联出错!", ex);
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
		///  发站用户站内手机短消息
		/// </summary>
		/// <param name="Sender">发送者用户名</param>
		/// <param name="RecipientMobileNo">接受者手机号码，可用逗号相隔多人</param>
		/// <param name="Content">短消息内容</param>
		/// <param name="Sendtime">短消息发送时间</param>
		/// <param name="RepeatTimes">短消息重复发送次数</param>
		/// <param name="RepeatPeriod">重复发送周期，以分钟为单位</param>
		/// <returns>返回执行代码 1 正常 2 错误</returns>
		public static int SaveMobileMsgToBuffer(string Sender,string RecipientMobileNo,string Content,DateTime Sendtime,int RepeatTimes,int RepeatPeriod)
		{
			Database data = new Database();
			#region 存消息至数据库，返回MsgID
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
                throw new Exception("存消息至数据库出错!", ex);
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
		/// 发送短消息
		/// </summary>
		/// <param name="sender">发送者用户名</param>
		/// <param name="receivers">接受者用户名，可用逗号相隔多人</param>
		/// <param name="msg">短消息内容</param>
		/// <param name="type">短消息类型 1为站内消息 2为手机短讯 3为站外手机(取mobileno)</param>
		/// <param name="sendtime">短消息发送时间</param>
		/// <param name="mobileno">如果是站外用户时用。表示站外用户的手机号</param>
		/// <param name="repeattimes">如果是手机短讯时用。表示此条讯息的重复发送次数</param>
		/// <param name="repeattimes">如果是手机短讯时用。表示此条讯息的重复发送时间间隔(以分钟为单位)</param>
		/// <returns>返回操作结束代码</returns>
		public int SendMsg(string sender,string recipients,string msg,int type,DateTime sendtime,string mobileno,int repeattimes,int repeatperiod)
		{
			int RtnCode = 1;
			//去除最后一位的逗号,并替换全角至半角
			if(recipients.EndsWith(",")) recipients = recipients.Substring(0,recipients.Length-1);
			recipients = recipients.Replace("，",",");
			
			switch (type)
			{
				case 1://站内用户的站内短讯
					SendLocalMsg(sender,recipients,msg,sendtime);
					return RtnCode;
					
				case 2: //站内用户的手机短讯
					string MobileNoStr = GetMobileNoByUsername(recipients);
					RtnCode =  SaveMobileMsgToBuffer(sender,MobileNoStr,msg,sendtime,repeattimes,repeatperiod);
					return RtnCode;
					
				case 3: //站外用户的手机短讯
					RtnCode = SaveMobileMsgToBuffer(sender,mobileno,msg,sendtime,repeattimes,repeatperiod);
					return RtnCode;
					
				default:
					return RtnCode;
					
			}
			
			
			
		}

		#region 根据用户名字符串获取手机号码字符串
		/// <summary>
		/// 根据用户名字符串获取手机号码字符串
		/// <param name="Username">用户名字符串，用逗号相隔</param>
		/// <returns>返回手机字符串</returns>
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
				throw new Exception("根据用户名字符串获取手机号码字符串出错!",ex);
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
		/// 删除一组短讯
		/// </summary>
		/// <param name="MsgIDS">消息ID的连接字符串，用逗号相隔开</param>
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
