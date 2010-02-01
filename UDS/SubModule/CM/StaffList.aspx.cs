using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;

namespace UDS.SubModule.CM
{
	/// <summary>
	/// StaffList 的摘要说明。
	/// </summary>
	public class StaffList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lbx_Staff;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			SqlDataReader dr_sellman = null;
			Database db = new Database();
            try
            {
                db.RunProc("sp_GetAllStaff", out dr_sellman);
                lbx_Staff.DataSource = dr_sellman;
                lbx_Staff.DataTextField = "staff_name";
                lbx_Staff.DataValueField = "staff_id";
                lbx_Staff.DataBind();
            }
            finally
            {
                db.Close();
                dr_sellman.Close();
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
