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

namespace UDS.SubModule.CM
{
	/// <summary>
	/// LinkmanListView 的摘要说明。
	/// </summary>
	public class LinkmanListView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal ltl_Count;
		protected System.Web.UI.WebControls.HyperLink hlk_Add;
		protected System.Web.UI.WebControls.HyperLink hlk_Mod;
		protected System.Web.UI.WebControls.DataGrid dgrd_Linkman;
		protected System.Web.UI.WebControls.HyperLink hlk_Search;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				UDS.Components.CM cm = new UDS.Components.CM();
				SqlDataReader dr = cm.GetAllLinkman();
				DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
				dgrd_Linkman.DataSource = dt.DefaultView;
				dgrd_Linkman.DataBind();
				ltl_Count.Text = dt.Rows.Count.ToString();
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
