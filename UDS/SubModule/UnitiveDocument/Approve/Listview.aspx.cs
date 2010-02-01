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

namespace UDS.SubModule.UnitiveDocument.Approve
{
	/// <summary>
	/// Listview 的摘要说明。
	/// </summary>
	public class Listview : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgMyApprove;
		protected System.Web.UI.WebControls.Panel PanFunction;
		protected System.Web.UI.WebControls.Button btnApproveDocument;
		protected System.Web.UI.WebControls.Button btnThowAwayDocument;		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				ViewState["SortField"] = "DocAddedDate";
				ViewState["SortDirect"] = "ASC";
				Bangding();
			}
		}

		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgMyApprove.CurrentPageIndex = e.NewPageIndex;
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
                String UserName;
                UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

                SqlParameter[] parameters = {
											mySQL.MakeInParam("@UserName",SqlDbType.VarChar,255,UserName),
											mySQL.MakeInParam("@RightCode",SqlDbType.Int, 4,2)
										};

                mySQL.RunProc("sp_GetMyApproved", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                //			//在DataTable的末尾加上空行，使得DataGrid固定行数
                //			int iBlankRows = dgMyApprove.PageSize - (dt.Rows.Count % dgMyApprove.PageSize);
                //			
                //			for (int i = 0; i < iBlankRows; i++)
                //			{
                //				dt.Rows.Add(dt.NewRow()) ;
                //			}

                dgMyApprove.DataSource = dt.DefaultView;
                dgMyApprove.DataBind();
                //对于空纪录不显示checkbox

                //			if(dgMyApprove.CurrentPageIndex  == dgMyApprove.PageCount -1 )
                //			{
                //				for(int i= (dgMyApprove.PageSize - iBlankRows)  ;i<dgMyApprove.Items.Count;i++)
                //				{
                //					dgMyApprove.Items[i].FindControl("DocID").Visible = false;
                //				}
                //			}
            }
            finally
            {
              
                if (mySQL != null)
                { mySQL.Close(); }
                if (dr != null)
                {

                    dr.Close();
                }
            }
			btnThowAwayDocument.Attributes ["onclick"]="javascript:return confirm('您确认要丢弃这些文档吗?');";
			btnApproveDocument.Attributes ["onclick"]="javascript:return confirm('您确认要批阅这些文档吗?');";
		}
		#endregion

		#region 将数据排序
		/// <summary>
		/// 将信件按照指定字段进行排序
		/// </summary>	
		public void DataGrid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(ViewState["SortField"].ToString() == e.SortExpression)
			{
				ViewState["SortDirect"] = (ViewState["SortDirect"].ToString()=="ASC")?"DESC":"ASC";
			}
			else
			{
				ViewState["SortField"] = e.SortExpression;
				ViewState["SortDirect"] = "ASC";

			}
			
			foreach(DataGridColumn col in  dgMyApprove.Columns)
			{
				if(col.SortExpression.ToString()==ViewState["SortField"].ToString())
				{
					//					if(ViewState["SortDirect"].ToString() == "ASC")
					//					{						
					//						col.HeaderText +="<img src='../../../images/asc.gif' border=0 />";						
					//					}
					//					else
					//						col.HeaderText +="<img src='../../../images/desc.gif' border=0 />";
						
				}
			}

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
			this.btnApproveDocument.Click += new System.EventHandler(this.btnApproveDocument_Click);
			this.btnThowAwayDocument.Click += new System.EventHandler(this.btnThowAwayDocument_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public string GetRealNameStr(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameByUsername(Username);
			else
				return "";
		}

		private void dgMyApprove_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lbApproveDocument_Click(object sender, System.EventArgs e)
		{
			
		}

		private void lbThowAwayDocument_Click(object sender, System.EventArgs e)
		{
			
		}
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dgMyApprove.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dgMyApprove.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}

		private void btnApproveDocument_Click(object sender, System.EventArgs e)
		{
			String strIDs=this.GetSelectedItemID("DocID");
			if(strIDs=="")			
				Response.Write("<script language='javascript'>window.alert('请选择要批阅的文档！');</script>");
			else
			{
				Database mySQL = new Database();
				String UserName;
				UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

				SqlParameter[] parameters = {												
												mySQL.MakeInParam("@DocIDs",SqlDbType.VarChar,300,strIDs),
												mySQL.MakeInParam("@Approver",SqlDbType.VarChar,300,UserName)
											};
			
				if(mySQL.RunProc("sp_ApproveDocument",parameters)>0)
				{
					Response.Write("<script language='javascript'>window.alert('审批文件成功!');</script>");
					Bangding();
				}	
				else
					Response.Write("<script language='javascript'>window.alert('审批文件成功!');</script>");
			}		
		}

		private void btnThowAwayDocument_Click(object sender, System.EventArgs e)
		{
			String strIDs=this.GetSelectedItemID("DocID");
			if(strIDs=="")			
				Response.Write("<script language='javascript'>window.alert('请选择要丢弃的文档！');</script>");
			else
			{
				Database mySQL = new Database();

				SqlParameter[] parameters = {												
												mySQL.MakeInParam("@DocIDs",SqlDbType.VarChar,3000,strIDs),
												mySQL.MakeInParam("@DeleteType",SqlDbType.Bit ,1,0)
											};
			
				if(mySQL.RunProc("sp_DeleteDocument",parameters)>0)
				{
					Response.Write("<script language='javascript'>window.alert('丢弃文件成功!');</script>");
					Bangding();
				}				
				else
					Response.Write("<script language='javascript'>window.alert('丢弃文件失败!');</script>");
			}			
		}
	}
}
