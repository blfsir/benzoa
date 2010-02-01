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

namespace UDS
{
	/// <summary>
	/// TreeView 的摘要说明。
	/// </summary>
	public class TreeView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image Image1;
		public string UserName;
		private void Page_Load(object sender, System.EventArgs e)
		{
            //Response.Write("<script>javascript:alert('treeview_cookie_username=" + Request.Cookies["Username"].Value.ToString() + "');</script>");
               
			UserName = UDS.Components .Staff.GetRealNameByUsername(Server.UrlDecode(Request.Cookies["UserName"].Value));
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
