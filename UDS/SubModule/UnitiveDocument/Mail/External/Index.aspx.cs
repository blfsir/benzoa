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
	/// Index ��ժҪ˵����
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
			
			
			//n���ڼ�����
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
