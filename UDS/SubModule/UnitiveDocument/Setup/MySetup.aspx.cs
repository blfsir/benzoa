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
using System.Data.SqlClient;

namespace UDS.SubModule.UnitiveDocument.Setup
{
	/// <summary>
	/// MySetup 的摘要说明。
	/// </summary>
	public class MySetup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOldPassword;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtOldPassword;
		protected System.Web.UI.WebControls.TextBox txtNewPassword;
		protected System.Web.UI.WebControls.TextBox txtReNewPassword;
		protected System.Web.UI.WebControls.Button cmdOK;
		protected System.Web.UI.WebControls.Button cmdCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.txtOldPassword.TextChanged += new System.EventHandler(this.txtOldPassword_TextChanged);
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if(txtNewPassword.Text==txtReNewPassword.Text)
			{
				Database  mySql=new Database();
				String UserName;
				UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

				SqlParameter [] parameter = {
												mySql.MakeInParam("@UserName",SqlDbType.VarChar,300,UserName),
												mySql.MakeInParam("@OldPassword",SqlDbType.VarChar,300,txtOldPassword.Text),
												mySql.MakeInParam("@NewPassword",SqlDbType.VarChar,300,txtNewPassword.Text)  
											};
				if(mySql.RunProc("sp_ModifyPassword",parameter)>=0)
					Response.Write("<script language=javascript>alert('密码修改成功!');</script>");
				else
					Response.Write("<script language=javascript>alert('原密码不对!');</script>");
							
			}
			else
			{
				Response.Write("<script language=javascript>alert('重复密码不一致!');</script>");
			}
		}

		private void txtOldPassword_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../Desktop.aspx");
		}
	}
}
