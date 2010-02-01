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
	/// LinkmanListView ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
