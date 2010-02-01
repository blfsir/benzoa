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

namespace UDS.SubModule.UnitiveDocument.Setup
{
	/// <summary>
	/// Setup ��ժҪ˵����
	/// </summary>
	public class Setup : System.Web.UI.Page
	{
		protected HtmlGenericControl position_set;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Span1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl department_set;
		protected HtmlGenericControl role_set;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Span2;
		public string ClassID="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			//�ж��û�Ȩ������ȷ������Ӧ����
			string userName;
			int classID;//���ڵ�ID
			classID = Convert.ToInt32(Request.QueryString["classID"].ToString());
			ClassID = classID.ToString();
            userName = Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.Staff st = new UDS.Components.Staff();
			//����û��Ƿ��в��Ź����Ȩ��
			if (st.CheckRight(classID,userName,8,true))
				position_set.Visible = true;
			else
				position_set.Visible = true;
			//����û��Ƿ��н�ɫ�����Ȩ��
			if (st.CheckRight(classID,userName,9,true))
				role_set.Visible = true;
			else
				role_set.Visible = true;


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
