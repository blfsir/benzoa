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
using System.Data.SqlClient;
using UDS.Components;


namespace UDS.SubModule.SM
{
	/// <summary>
	/// MsgSend 的摘要说明。
	/// </summary>
	public class MsgSend : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSend;
		protected System.Web.UI.WebControls.TextBox txtContent;
		protected System.Web.UI.WebControls.Label lblContent;
		public string SendTo="",MobileSendTo="",SendToRealName="",MobileSendToRN="",AdditionalNo="",Type="";
		protected System.Web.UI.WebControls.Label lblLReceiver;
		protected System.Web.UI.WebControls.Label lblAdditionalNo;
		protected System.Web.UI.WebControls.Label lblRemind;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Label lblShortCut;
		protected System.Web.UI.WebControls.Label lblMReceiver;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				Type			 = (Request.QueryString["Type"]!=null)?Request.QueryString["Type"].ToString():"1";
				if(Type=="1")
				{
					SendTo			 = (Request.QueryString["SendTo"]!=null)?Request.QueryString["SendTo"].ToString()+",":"";
					SendToRealName	 = (Request.QueryString["SendToRealName"]!=null)?Request.QueryString["SendToRealName"].ToString()+",":"";
				}
				if(Type=="2")
				{
					MobileSendTo	 = (Request.QueryString["SendTo"]!=null)?Request.QueryString["SendTo"].ToString()+",":"";
					MobileSendToRN	 = (Request.QueryString["SendToRealName"]!=null)?Request.QueryString["SendToRealName"].ToString()+",":"";
				}
				if(Type=="3")
				{
					AdditionalNo	 = (Request.QueryString["SendTo"]!=null)?Request.QueryString["SendTo"].ToString()+",":"";
				}
				InitData();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			
		
		}
		
		private string GetErrorMsg(int Code)
		{
			string Msg = "";	
			switch (Code) {
			case 0:
				Msg = "成功";
				break;
			case -2:
				Msg = "消息超过长度";
				break;
			case -3:
				Msg = "手机号码不正确";
				break;
			case -4:
			    Msg = "发送阵列已满";
				break;
			case -8:
				Msg = "模块未打开";
				break;
			case -1:
				Msg = "串口未打开";
				break;
			default:
				Msg = "未知错误";
				break;
			}
			
			return Msg;

		}
		private void btnSend_Click(object sender, System.EventArgs e)
		{	
			SMS sm = new SMS();
			string ErrorMsg = "";
			string Username			  = Server.UrlDecode(Request.Cookies["UserName"].Value);
			this.SendTo				  = Request.Form["hdnTxtSendTo"].ToString();
			this.MobileSendTo		  = Request.Form["hdnTxtMobileSendTo"].ToString();
			this.SendToRealName       = Request.Form["txtSendTo"].ToString();
			this.MobileSendToRN		  = Request.Form["txtMobileSendTo"].ToString();
			this.AdditionalNo		  = Request.Form["txtAdditionalNo"].ToString();
			if(SendTo!="") //发送短信至站内用户
			{
				int Code = sm.SendMsg(Username,SendTo,this.txtContent.Text,1,DateTime.Now,"",0,0);
				if(Code==1)
				{
					Response.Write("<script language=javascript>alert('站内短信发送成功');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
				else
				{
					Response.Write("<script language=javascript>alert('站内短信发送失败');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
			}


			if(MobileSendTo!="")//发送至站内手机用户
			{
				int Code = sm.SendMsg(Username,MobileSendTo,this.txtContent.Text,2,DateTime.Now,AdditionalNo,0,0);
				if(Code==1)
				{
					Response.Write("<script language=javascript>alert('站内手机短讯已经成功存储至消息阵列');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
				else
				{
					//ErrorMsg = GetErrorMsg(Code);
					Response.Write("<script language=javascript>alert('手机短讯存储失败,请重试');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
			}


			if(AdditionalNo!="")//发送至站外手机用户
			{
				int Code = sm.SendMsg(Username,MobileSendTo,this.txtContent.Text,3,DateTime.Now,AdditionalNo,0,0);
				if(Code==1)
				{
					Response.Write("<script language=javascript>alert('站外手机短讯已经成功存储至消息阵列');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
				else
				{
					ErrorMsg = GetErrorMsg(Code);
					Response.Write("<script language=javascript>alert('手机短讯存储失败,请重试');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
			}



            Response.Redirect("Index.aspx?DispType=2");
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Index.aspx");
		}

		
	}
}
