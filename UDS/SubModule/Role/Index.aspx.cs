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
//������s��x
namespace UDS.SubModule.Role
{
	/// <summary>
	/// Index ��ժҪ˵����
	/// </summary>
	public class Index : System.Web.UI.Page
	{
		public string ClassID;
		private void Page_Load(object sender, System.EventArgs e)
		{
			ClassID = Request.QueryString["ClassID"]!=null?Request.QueryString["ClassID"]:"0";
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
