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

namespace UDS.SubModule.CM.Stat
{
	/// <summary>
	/// sellmancontact ��ժҪ˵����
	/// </summary>
	public class sellmancontact : System.Web.UI.Page
	{
		protected UDS.Inc.ControlSellmanContactHistory ControlSellmanContactHistory1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				ControlSellmanContactHistory1.SellmanID = (Request.QueryString["SellmanID"]==null)?0:Int32.Parse(Request.QueryString["Sellmanid"]);
				ControlSellmanContactHistory1.BeginTime = (Request.QueryString["Begintime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["Begintime"]);
				ControlSellmanContactHistory1.EndTime = (Request.QueryString["Endtime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["Endtime"]);
				ControlSellmanContactHistory1.Type = (Request.QueryString["type"]==null)?"":Request.QueryString["type"];
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
