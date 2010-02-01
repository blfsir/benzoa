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
	/// DraftList 的摘要说明。
	/// </summary>
	public class DraftList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgDraftList;
		protected System.Web.UI.HtmlControls.HtmlForm WebForm1;
	
		public string UserName;
		protected System.Web.UI.WebControls.Button cmdNewDocument;
		protected System.Web.UI.WebControls.LinkButton lbMyRead;
		protected System.Web.UI.WebControls.LinkButton lbMyRequisition;
		protected System.Web.UI.WebControls.LinkButton lbMyApproved;
		protected System.Web.UI.WebControls.LinkButton lbFlowManage;
		protected System.Web.UI.WebControls.LinkButton lbDraftList;
		protected System.Web.UI.WebControls.Button cmdQuery;
		public bool bManageFlow;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			
			//得到用户名
			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value).ToLower();
			if(!Page.IsPostBack)
				Bangding();

			UDS.Components.DocumentFlow df =new UDS.Components.DocumentFlow();
			bManageFlow = df.GetAccessPermission(Request.Cookies["ActiveNodeID"]!=null?Int32.Parse(Request.Cookies["ActiveNodeID"].Value):0,UserName,4);
			df = null;
		}
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgDraftList.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion
		#region 绑定DBGRID
		private void Bangding()
		{
			SqlDataReader dr; //存放人物的数据
			Database mySQL = new Database();
			string strProcName;
			
			strProcName ="sp_Flow_GetMyDraft";

			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar,300,UserName)
										};
			
			mySQL.RunProc(strProcName,parameters,out dr);
			
			DataTable dt =Tools.ConvertDataReaderToDataTable(dr);

			
			dgDraftList.DataSource = dt.DefaultView;
			dgDraftList.DataBind();
				
		}
		#endregion

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
			this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
			this.cmdNewDocument.Click += new System.EventHandler(this.cmdNewDocument_Click);
			this.lbMyRead.Click += new System.EventHandler(this.lbMyRead_Click);
			this.lbMyRequisition.Click += new System.EventHandler(this.lbMyRequisition_Click);
			this.lbMyApproved.Click += new System.EventHandler(this.lbMyApproved_Click);
			this.lbDraftList.Click += new System.EventHandler(this.lbDraftList_Click);
			this.lbFlowManage.Click += new System.EventHandler(this.lbFlowManage_Click);
			this.dgDraftList.SelectedIndexChanged += new System.EventHandler(this.dgDraftList_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string GetDisplayDocumentUrl(string DocID)
		{
			return "NewDocument.aspx?DocID=" + DocID ;
		}

		public string GetDisplayStepMemberUrl(string DocID)
		{
			return "DisplayTacheMember.aspx?DocID=" + DocID;
		}
		private void lbMyApproved_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=3");
		}

		private void lbMyRequisition_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=2");
		}

		private void lbFlowManage_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListView.aspx");
		}

		private void dgDraftList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmdNewDocument_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("FlowTemplate.aspx");
		}

		private void lbDraftList_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lbMyRead_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=1");
		}

		private void cmdQuery_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Query.aspx");
		}
	}
}
