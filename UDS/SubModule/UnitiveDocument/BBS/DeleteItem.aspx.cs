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

namespace UDS.SubModule.UnitiveDocument.BBS
{
	/// <summary>
	/// DeleteItem 的摘要说明。
	/// </summary>
	public class DeleteItem : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			int itemid = (Request.QueryString["ItemID"]==null)?0:Int32.Parse(Request.QueryString["ItemID"].ToString());
			int boardid = (Request.QueryString["BoardID"]==null)?0:Int32.Parse(Request.QueryString["BoardID"].ToString());

			BBSClass bbs = new BBSClass();
			BBSForumItem item = new BBSForumItem();
			
			item.ItemID = itemid;
			try
			{
				item.DelAttachment(Server.MapPath(".")+"\\Attachment\\");
				bbs.DelItem(item);
				Response.Write("<script>alert('删除成功');opener.location.reload();close();</script>");
				
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
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
