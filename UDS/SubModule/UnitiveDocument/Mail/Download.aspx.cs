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
using System.IO;

namespace UDS.SubModule.UnitiveDocument.Mail
{
	/// <summary>
	/// Download 的摘要说明。
	/// </summary>
	public class Download : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string destFileName = Request.QueryString["destFileName"]!=null?Request.QueryString["destFileName"]:"";
			destFileName = Server.MapPath(".")+destFileName;
			destFileName = Server.UrlDecode(destFileName);
			if(File.Exists(destFileName))
			{
				FileInfo fi = new FileInfo(destFileName);
				Response.Clear();
				Response.ClearHeaders();
				Response.Buffer = false;
				
				Response.AppendHeader("Content-Disposition","attachment;filename=" +HttpUtility.UrlEncode(Path.GetFileName(destFileName),System.Text.Encoding.Default));
				Response.AppendHeader("Content-Length",fi.Length.ToString());
				Response.ContentType="application/octet-stream";
				Response.WriteFile(destFileName);
				Response.Flush();
				Response.End();
			}
			else
			{
				Response.Write("<script langauge=javascript>alert('文件不存在!');history.go(-1);</script>");
				Response.End();
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
