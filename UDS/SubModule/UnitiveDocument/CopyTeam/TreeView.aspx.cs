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
	/// CopyTeam ��ժҪ˵����
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


		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
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
				Response.Write("<script>alert('���Ƴɹ�');close();</script>");
			}
			catch
			{
				Response.Write("<script>alert('����ʧ��');</script>");
			}
			
		}
	}
}
