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
	/// Setup 的摘要说明。
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
			//判断用户权限以正确出现相应界面
			string userName;
			int classID;//树节点ID
			classID = Convert.ToInt32(Request.QueryString["classID"].ToString());
			ClassID = classID.ToString();
            userName = Server.UrlDecode(Request.Cookies["UserName"].Value);
			UDS.Components.Staff st = new UDS.Components.Staff();
			//检查用户是否有部门管理的权限
			if (st.CheckRight(classID,userName,8,true))
				position_set.Visible = true;
			else
				position_set.Visible = true;
			//检查用户是否有角色管理的权限
			if (st.CheckRight(classID,userName,9,true))
				role_set.Visible = true;
			else
				role_set.Visible = true;


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
