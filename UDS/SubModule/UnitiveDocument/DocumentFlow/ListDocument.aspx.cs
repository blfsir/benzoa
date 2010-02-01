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


namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// ListDocument 的摘要说明。
	/// </summary>
	public class ListDocument : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgDocumentList;
		
		protected System.Web.UI.WebControls.LinkButton lbMyApprove;
		protected System.Web.UI.WebControls.LinkButton lbMyDocument;
		protected System.Web.UI.WebControls.LinkButton lbMyApproved;
		protected System.Web.UI.WebControls.LinkButton lbManageFlow;

		public string UserName;
		public int DisplayType=0;
		protected System.Web.UI.WebControls.LinkButton lbMyDraft;
		public bool bManageFlow;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			
			//得到用户名
			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value).ToLower();
			if(Request["DisplayType"]!=null)
				DisplayType = Int32.Parse(Request["DisplayType"].ToString());			
			else
				DisplayType =1;
			if(!Page.IsPostBack)
				Bangding();

			UDS.Components.DocumentFlow df =new UDS.Components.DocumentFlow();
			bManageFlow = df.GetAccessPermission(Request.Cookies["ActiveNodeID"]!=null?Int32.Parse(Request.Cookies["ActiveNodeID"].Value):0,UserName,4);
			df = null;
		}
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgDocumentList.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion
		#region 绑定DBGRID
		private void Bangding()
		{
			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();
            try
            {
                string strProcName;

                switch (DisplayType)
                {
                    case 1:
                        //strProcName ="sp_Flow_GetMySignIn";
                        strProcName = "sp_Flow_GetMyPostil";
                        Response.Cookies["DisplayStatus"].Value = "Postil";
                        break;
                    case 2:
                        strProcName = "sp_Flow_GetMydDocument";
                        Response.Cookies["DisplayStatus"].Value = "MyDocument";
                        break;
                    case 3:
                        strProcName = "sp_Flow_GetPostiledDocument";
                        Response.Cookies["DisplayStatus"].Value = "Postiled";
                        break;
                    default:
                        strProcName = "sp_Flow_GetMySignIn";
                        break;

                }

                SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar,300,UserName)
										};

                mySQL.RunProc(strProcName, parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);


                dgDocumentList.DataSource = dt.DefaultView;
                dgDocumentList.DataBind();
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
			this.lbMyApprove.Click += new System.EventHandler(this.lbMyApprove_Click);
			this.lbMyDocument.Click += new System.EventHandler(this.lbMyDocument_Click);
			this.lbMyApproved.Click += new System.EventHandler(this.lbMyApproved_Click);
			this.lbMyDraft.Click += new System.EventHandler(this.lbMyDraft_Click);
			this.lbManageFlow.Click += new System.EventHandler(this.lbManageFlow_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string GetDisplayDocumentUrl(string DocID)
		{
			return "DisplayDocument.aspx?DocID=" + DocID + " &ReturnPage=" + DisplayType.ToString();
		}

		public string GetDisplayTacheMemberUrl(string DocID)
		{
			return "DisplayTacheMember.aspx?DocID=" + DocID + " &ReturnPage=" + DisplayType.ToString();
		}

		public string GetSelectImage(string NormalImg,string SelectedImg,int selected,int position)
		{
			if(selected==position)
				return SelectedImg;
			else
				return NormalImg;
		}
		private void lbMyApprove_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=1");
		}

		private void lbMyDocument_Click(object sender, System.EventArgs e)
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

		private void lbManageFlow_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListView.aspx");
		}
	}
}
