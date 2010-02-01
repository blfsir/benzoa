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


namespace UDS.SubModule.UnitiveDocument.Mail.External
{
	/// <summary>
	/// Index 的摘要说明。
	/// </summary>
	public class Index : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFrom;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblBody;
		protected System.Web.UI.WebControls.Label Label5;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{
				Remail();
			}
		}

		public void Remail()
		{
			
			
			//n＝第几封信
//			jmail.Message Msg=new jmail.Message();
//			jmail.POP3 jpop=new jmail.POP3();
//			try
//			{
//				jpop.Connect("samliu","admintoo","mail.united-vision.com",110);
//				this.lblTotal.Text=jpop.Count.ToString();
//				Msg = jpop.Messages[0];
//				this.lblFrom.Text = Msg.FromName;
//				this.lblSubject.Text = Msg.Subject;
//				this.lblBody.Text = Msg.Body;
////				num.Text=Msg.Attachments.Count.ToString();
////				for(int i=0;i<Msg.Attachments.Count;i++)
////				{
////					f=f+Msg.Attachments[i].SaveToFile("c:\\"+Msg.Attachments[n].Name);
////				}
////				name.Text=f;
//				jpop.Disconnect();
//			}
//			catch(Exception ex)
//			{
//				lblTotal.Text=ex.Message.ToString();
//			}

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
