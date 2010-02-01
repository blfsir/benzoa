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
	/// sellmancontact 的摘要说明。
	/// </summary>
	public class sellmancontact : System.Web.UI.Page
	{
		protected UDS.Inc.ControlSellmanContactHistory ControlSellmanContactHistory1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
