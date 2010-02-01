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
using System.Data.SqlClient;

namespace UDS.SubModule.UnitiveDocument.Flow
{
	/// <summary>
	/// Listview 的摘要说明。
	/// </summary>
	public class Listview : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgFlowList;
		protected System.Web.UI.WebControls.LinkButton lbMyApprove;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton lbMyApproved;
		protected System.Web.UI.WebControls.Button cmdDeleteFlow;
		protected System.Web.UI.WebControls.LinkButton lbManageFlow;
		protected System.Web.UI.WebControls.Button cmdManageStyle;
		protected System.Web.UI.WebControls.Button cmdNewFlow;
		protected System.Web.UI.HtmlControls.HtmlTableCell ManageFlow;
		public string UserName;
		protected System.Web.UI.WebControls.LinkButton lbMyDraft;
		public bool bManageFlow;		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面			
			if(!Page.IsPostBack)
				Bangding();
			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);			

			UDS.Components.DocumentFlow df =new UDS.Components.DocumentFlow();
			bManageFlow = df.GetAccessPermission(Request.Cookies["ActiveNodeID"]!=null?Int32.Parse(Request.Cookies["ActiveNodeID"].Value):0,UserName,4);
			df = null;
			

		}
		#region 绑定DBGRID
		private void Bangding()
		{		

			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();
            try
            {
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@FlowID",SqlDbType.Int ,4,0)
										};

                mySQL.RunProc("sp_Flow_GetFlow", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                dr.Close();
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
			this.cmdNewFlow.Click += new System.EventHandler(this.cmdNewFlow_Click);
			this.cmdDeleteFlow.Click += new System.EventHandler(this.cmdDeleteFlow_Click);
			this.cmdManageStyle.Click += new System.EventHandler(this.cmdManageStyle_Click);
			this.lbMyApprove.Click += new System.EventHandler(this.lbMyApprove_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.lbMyApproved.Click += new System.EventHandler(this.lbMyApproved_Click);
			this.lbMyDraft.Click += new System.EventHandler(this.lbMyDraft_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void MyDataGrid_Delete(object sender,DataGridCommandEventArgs e)
		{
			string FlowID = dgFlowList.DataKeys[e.Item.ItemIndex].ToString();
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.DeleteFlow(Int32.Parse(FlowID));
			df = null;
			Bangding();	

		}


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

		private void lbMyDraft_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DraftList.aspx");
		}

		private void cmdNewFlow_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("EditFlow.aspx?FlowID=0");
		}


		private void cmdDeleteFlow_Click(object sender, System.EventArgs e)
		{
			long FlowID;
			UDS.Components.DocumentFlow df	= new UDS.Components.DocumentFlow();
			string IDstr					= this.GetSelectedItemID(dgFlowList,"FlowID");
			
			if(IDstr.Length >0)
			{					
				if(IDstr.IndexOf(",")>0)
					Response.Write("<script lanauage='javascript'>alert('不能同时删除多个流程！');</script>");
				else
				{
					FlowID = Int32.Parse(IDstr);
					if(df.DeleteFlow(FlowID)!=0)
						Response.Write("<script lanauage='javascript'>alert('流程删除失败！此流程正在被一个文档使用！');</script>");
					else
						Response.Write("<script lanauage='javascript'>alert('流程删除成功！');</script>");
				}
			}
			else
				Response.Write("<script lanauage='javascript'>alert('请选择流程！');</script>");

			Bangding();

			//Response.AddHeader("Refresh","1");	
			

		}
		private string GetSelectedItemID(DataGrid dg,string controlID)
		{
		
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dg.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dg.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ManageTache.aspx");
		}

		private void cmdManageStyle_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ManageStyle.aspx");
		}

	}
}
