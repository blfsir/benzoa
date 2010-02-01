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
using System.Data.SqlClient;
using UDS.Components;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.LinkButton lbMyApprove;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton lbMyApproved;
		protected System.Web.UI.WebControls.DataGrid dgFlowList;
		protected System.Web.UI.WebControls.LinkButton lbManageFlow;
		public string UserName;
		protected System.Web.UI.WebControls.LinkButton lbMyDraft;
		protected System.Web.UI.WebControls.Button cmdListDraft;
		public bool bManageFlow;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value).ToLower();
			if(!Page.IsPostBack)
				Bangding();
			UDS.Components.DocumentFlow df =new UDS.Components.DocumentFlow();
			bManageFlow = df.GetAccessPermission(Request.Cookies["ActiveNodeID"]!=null?Int32.Parse(Request.Cookies["ActiveNodeID"].Value):0,UserName,4);
			df = null;
		}
		#region 绑定DBGRID
		private void Bangding()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();
			string UserName;

			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);


			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar ,300,UserName)
										};
			
			mySQL.RunProc("sp_Flow_GetMyFlow",parameters,out dr);
            try
            {
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);


                dgFlowList.DataSource = dt.DefaultView;
                dgFlowList.DataBind();
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
		}
		#endregion
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgFlowList.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion
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
			this.cmdListDraft.Click += new System.EventHandler(this.cmdListDraft_Click);
			this.lbMyApprove.Click += new System.EventHandler(this.lbMyApprove_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.lbMyApproved.Click += new System.EventHandler(this.lbMyApproved_Click);
			this.lbMyDraft.Click += new System.EventHandler(this.lbMyDraft_Click);
			this.lbManageFlow.Click += new System.EventHandler(this.lbManageFlow_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbMyApprove_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=1");
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=2");
		}

		private void lbMyApproved_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=3");
		}

		private void lbManageFlow_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListView.aspx");
		}

		private void lbMyDraft_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cmdListDraft_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DraftList.aspx");
		}
	}
}
