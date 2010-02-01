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
	/// MsgManage 的摘要说明。
	/// </summary>
	public class MsgManage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSender;
		protected System.Web.UI.WebControls.Label lblContent;
		protected System.Web.UI.WebControls.TextBox txtContent;
		protected System.Web.UI.WebControls.Button btnReply;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.TextBox txtMsgID;
		protected System.Web.UI.WebControls.Button btnRead;
		protected System.Web.UI.WebControls.TextBox txtRealName;
		protected System.Web.UI.WebControls.TextBox txtSender;
		protected System.Web.UI.WebControls.Label lblShortCut;
		protected System.Web.UI.WebControls.Label lblInstruction;
		protected System.Web.UI.WebControls.Button btnHistory;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				ReadMsg(Username);
				CheckNextMsg(Username);
				this.btnReply.CommandArgument="view";
				this.btnHistory.Attributes["onclick"] = "javascript: mytop=screen.availHeight-330-175;myleft=0;var newhiswin=window.open('../SM/MsgHistory.aspx?Sender="+Username+"&Receiver="+this.txtSender.Text+"','show','height=170,width=350,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top='+mytop+',left='+myleft+',resizable=yes');newhiswin.focus();";

			}
		}

		private void CheckNextMsg(string Username)
		{
			SMS sm = new SMS();
			int count = 0;
			try
			{
				count = sm.GetNewMsgCount(Username);
				if(count>=2)
				{
					this.btnNext.Enabled = true;
				}
				else
				{
					this.btnNext.Enabled = false;
				}
			}
			catch
			{
				Server.Transfer("../Error.aspx");
			}

		}


		private void ReadMsg(string Username)
		{
			
				this.txtSender.Enabled = false;
				this.txtRealName.Enabled = false;
				this.txtContent.Enabled = false;
				this.btnReply.Enabled = true;
				this.btnHistory .Enabled = true;
				SMS sm = new SMS();
				SqlDataReader dataReader = null;
                try
                {
                    dataReader = sm.GetNewLocalMsg(Username);
                    if (dataReader.Read())
                    {
                        this.txtSender.Text = dataReader["Sender"].ToString();
                        this.txtRealName.Text = UDS.Components.Staff.GetRealNameByUsername(this.txtSender.Text);
                        this.txtContent.Text = dataReader["Content"].ToString();
                        this.txtMsgID.Text = dataReader["ID"].ToString();
                    }
                }
                catch
                {
                    Server.Transfer("../Error.aspx");
                }
                finally {
                    dataReader.Close();
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
			this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			SMS sm = new SMS();
			string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			try
			{
				
				sm.ReadMsg(this.txtMsgID.Text.ToString(),Username);
				Response.Write("<script language=javascript>window.opener.location.reload();window.close();</script>");
				
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../Error.aspx");
			}

		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			SMS sm = new SMS();
			string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			try
			{
				sm.ReadMsg(this.txtMsgID.Text.ToString(),Username);
				Response.Redirect("MsgManage.aspx");
			}
			catch
			{
				Server.Transfer("../Error.aspx");
			}
		
		}

		private void btnReply_Click(object sender, System.EventArgs e)
		{
			string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			this.lblInstruction.Text = "回复消息";
			SMS sm = new SMS();

			#region 更新记录的已读状态
		
			try
			{
				sm.ReadMsg(this.txtMsgID.Text.ToString(),Username);
			}
			catch
			{
				Server.Transfer("../Error.aspx");
			}
			#endregion
			
			if(this.btnReply.CommandArgument=="view") //查看消息状态
			{
				btnReply.Text = "发送";
				btnReply.CommandArgument = "reply";
				btnRead.Visible = false;
				btnNext.Visible = false;
				lblSender.Text = "接收者";
				txtSender.Enabled = true;
				txtContent.Enabled = true;
				txtContent.Text = "";	
				this.lblShortCut.Text = "按Ctrl+回车键 发送消息 ";
			}
			else //发送消息状态
			{ //sender文本框变为receiver
				int Code = sm.SendMsg(Username,this.txtSender.Text,this.txtContent.Text,1,DateTime.Now,"",0,0);
				if(Code==1)
					Response.Write("<script language=javascript>alert('回复成功');window.opener.location.reload();window.close();</script>");
				else
					Response.Write("<script language=javascript>alert('回复失败');window.opener.location.reload();window.close();</script>");

			}
			
		}
	}
}
