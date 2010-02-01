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
using System.Web.Security;
using UDS.Components;

namespace UDS.SubModule.Login
{
	/// <summary>
	/// Logout 的摘要说明。
	/// </summary>
	public class Logout : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
			string Action		 = (Request.QueryString["Action"]!=null)?Request.QueryString["Action"].ToString():"1";	
			// clear everything
			UDS.Components.Staff staff = new UDS.Components.Staff();
			staff.Logout(Server.UrlDecode(Request.Cookies["UserName"].Value));
			staff = null;
			FormsAuthentication.SignOut();
			Request.Cookies.Clear();
			HttpCookie UserCookie     = new HttpCookie("UserID", string.Empty);
			HttpCookie UserNameCookie = new HttpCookie("Username", string.Empty);

			Response.Cookies.Add(UserCookie);
			Response.Cookies.Add(UserNameCookie);
			Session.Clear();
			//Server.Transfer("Index.aspx");
			if(Action=="1")
			{
				Response.Write("<script language=javascript>window.close();</script>");
			}
			if(Action=="2")
			{
				Server.Transfer("Index.aspx");
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
