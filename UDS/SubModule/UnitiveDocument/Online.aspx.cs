using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;
using System.Web.Security;

namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// Online ��ժҪ˵����
	/// </summary>
	public class Online : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal lit;
		protected System.Web.UI.WebControls.Label lblOnlineCount;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				CheckUpdate();
			}
		}

		private void CheckUpdate()
		{
			
			#region 1.����activetime 2.�ж�sessionid 3.ɾ��ʮ������δ��� 4.�õ�������������
			SMS sm = new SMS();
			try 
			{
				// ReturnID -1 ��ָ�Ƿ���½ -2ָ���µĶ���Ϣ
               // Response.Write("<script>javascript:alert('cookie_username=" + Server.UrlDecode(Request.Cookies["Username"].Value) + "');</script>");
			
				string Username = Server.UrlDecode(Request.Cookies["Username"].Value);
               // Response.Write("<script>javascript:alert('last_username=" + Username + "');</script>");
			
				string SessionID = Request.Cookies["ASP.NET_SessionId"].Value.ToString();
               // Response.Write("<script>javascript:alert('SessionID=" + SessionID + "');</script>");
			
                string NodeID = (Request.Cookies["ActiveNodeID"]!=null)?Request.Cookies["ActiveNodeID"].Value.ToString():"0";
               // Response.Write("<script>javascript:alert('NodeID=" + NodeID + "');</script>");
			
                //UDS.Components .Error.Log(Username+"11"+SessionID+"||"+NodeID);
				string ReturnStr = sm.CheckUpdate(Username,SessionID,Int32.Parse(NodeID));
                //Response.Write("<script>javascript:alert('ReturnStr=" + ReturnStr + "');</script>");
			
                string ReturnID = ReturnStr.Substring(0,ReturnStr.IndexOf("|"));
				string NewMsgFlag = ReturnStr.Substring(ReturnStr.IndexOf("|")+1);
               // Response.Write("<script>javascript:alert('returnID=" + ReturnID + "');</script>");
			
				if(ReturnID!="-1")
				{
                    //Response.Write("<script>javascript:alert('NewMsgFlag=" + NewMsgFlag + "');</script>");
			
					if(NewMsgFlag=="1") //incoming a new msg
					{
                        //Response.Write("<script>javascript:alert('UDS_RemindType==1=" + Request.Cookies["UDS_RemindType"] + "');</script>");
			
						if(Request.Cookies["UDS_RemindType"]!=null)
                        {
                            //Response.Write("<script>javascript:alert('UDS_RemindType=" + Request.Cookies["UDS_RemindType"].Value.ToString() + "');</script>");
			
							if(Request.Cookies["UDS_RemindType"].Value.ToString()=="1")
								lit.Text="<script language=javascript> mytop=screen.availHeight-310;myleft=0;var newmsgwin=window.open('../SM/MsgManage.aspx','auto_call_show','height=230,width=400,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top='+mytop+',left='+myleft+',resizable=yes');newmsgwin.focus();</script>";
							else
								lit.Text = "<a href='#' onclick='show_sm()'><img src='../../Images/smsremind.gif' border=0></a>";
						}
						else
						{
							lit.Text="<script language=javascript> mytop=screen.availHeight-310;myleft=0;var newmsgwin=window.open('../SM/MsgManage.aspx','auto_call_show','height=230,width=400,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top='+mytop+',left='+myleft+',resizable=yes');newmsgwin.focus();</script>";
						}
					}

					this.lblOnlineCount.Text = ReturnID.ToString();
				}
				else
				{
					// clear everything
					//FormsAuthentication.SignOut();
				//	Request.Cookies.Clear();
				//	HttpCookie UserCookie     = new HttpCookie("UserID", string.Empty);
				//	HttpCookie UserNameCookie = new HttpCookie("Username", string.Empty);

				//	Response.Cookies.Add(UserCookie);
				//	Response.Cookies.Add(UserNameCookie);
				//	Session.Clear();
	
					Response.Write("<script language=javascript>alert('����ͬ�û���½��ͬһ�������û���½,���ڽ��Զ��ر�!');top.close();</script>");
				}	
					

			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../Error.aspx");
			}
			#endregion
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
