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
	/// Download ��ժҪ˵����
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
				Response.Write("<script langauge=javascript>alert('�ļ�������!');history.go(-1);</script>");
				Response.End();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
