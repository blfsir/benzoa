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

namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// CopyTeam 的摘要说明。
	/// </summary>
	public class CopyTeam : System.Web.UI.Page
	{
		protected UDS.Inc.ControlCustomProjectTreeView uc_projecttree;

		private string FromID = "";
		protected System.Web.UI.WebControls.Button btn_OK;
		private string ToID = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				FromID	 = (Request.QueryString["FromID"]!=null)?Request.QueryString["FromID"].ToString():"";
				ViewState["FromID"] = FromID;

                uc_projecttree.UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
				uc_projecttree.DisplayFunctionNode = false;
				uc_projecttree.ImagePath = "../../../DataImages/";
				uc_projecttree.Bind();
			}
			else
			{
				FromID = ViewState["FromID"].ToString();
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
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			UDS.Components.ProjectClass project = new UDS.Components.ProjectClass();
			ToID = uc_projecttree.SelectedClassIndex.ToString();
			try
			{
				project.Copy(Int32.Parse(FromID),Int32.Parse(ToID), Server.UrlDecode(Request.Cookies["UserName"].Value));
				Response.Write("<script>alert('复制成功');close();</script>");
			}
			catch
			{
				Response.Write("<script>alert('复制失败');</script>");
			}
			
		}
	}
}
