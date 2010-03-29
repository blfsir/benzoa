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
	/// MsgSend ��ժҪ˵����
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
				Msg = "�ɹ�";
				break;
			case -2:
				Msg = "��Ϣ��������";
				break;
			case -3:
				Msg = "�ֻ����벻��ȷ";
				break;
			case -4:
			    Msg = "������������";
				break;
			case -8:
				Msg = "ģ��δ��";
				break;
			case -1:
				Msg = "����δ��";
				break;
			default:
				Msg = "δ֪����";
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
			if(SendTo!="") //���Ͷ�����վ���û�
			{
				int Code = sm.SendMsg(Username,SendTo,this.txtContent.Text,1,DateTime.Now,"",0,0);
				if(Code==1)
				{
					Response.Write("<script language=javascript>alert('վ�ڶ��ŷ��ͳɹ�');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
				else
				{
					Response.Write("<script language=javascript>alert('վ�ڶ��ŷ���ʧ��');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
			}


			if(MobileSendTo!="")//������վ���ֻ��û�
			{
				int Code = sm.SendMsg(Username,MobileSendTo,this.txtContent.Text,2,DateTime.Now,AdditionalNo,0,0);
				if(Code==1)
				{
					Response.Write("<script language=javascript>alert('վ���ֻ���Ѷ�Ѿ��ɹ��洢����Ϣ����');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
				else
				{
					//ErrorMsg = GetErrorMsg(Code);
					Response.Write("<script language=javascript>alert('�ֻ���Ѷ�洢ʧ��,������');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
			}


			if(AdditionalNo!="")//������վ���ֻ��û�
			{
				int Code = sm.SendMsg(Username,MobileSendTo,this.txtContent.Text,3,DateTime.Now,AdditionalNo,0,0);
				if(Code==1)
				{
					Response.Write("<script language=javascript>alert('վ���ֻ���Ѷ�Ѿ��ɹ��洢����Ϣ����');</script>");
					//Response.Redirect("MsgSend.aspx");
				}
				else
				{
					ErrorMsg = GetErrorMsg(Code);
					Response.Write("<script language=javascript>alert('�ֻ���Ѷ�洢ʧ��,������');</script>");
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
