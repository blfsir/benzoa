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

namespace UDS.SubModule.Position
{
	/// <summary>
	/// UpdateCaste 的摘要说明。
	/// </summary>
	public class UpdateCaste : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox tbNewCaste;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label labPositionName;
		protected System.Web.UI.WebControls.Button cmdOK;
		protected System.Web.UI.WebControls.Button cmdReturn;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		private	  long PositionID;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			PositionID = Request.QueryString["PositionID"]!=null?Int32.Parse(Request.QueryString["PositionID"].ToString()):0;
			if(!Page.IsPostBack )
			{
				labPositionName.Text =  UDS.Components.Position.GetPositionName(PositionID);
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
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
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?PositionID=" + PositionID.ToString());
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			
			UDS.Components.Position.UpdateCaste(PositionID,Int32.Parse(tbNewCaste.Text));
			
			Response.Write("<script language=''>alert('批量修改职级成功！');</script>");
		}
	}
}
