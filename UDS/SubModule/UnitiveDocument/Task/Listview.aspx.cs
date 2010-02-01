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

namespace UDS.SubModule.UnitiveDocument.Task
{
	/// <summary>
	/// Listview 的摘要说明。
	/// </summary>
	public class Task : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgMyTask;
		protected System.Web.UI.WebControls.Panel PanFunction;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				Bangding();
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
			this.dgMyTask.SelectedIndexChanged += new System.EventHandler(this.dgMyTask_SelectedIndexChanged);
			this.ID = "Task";
			this.Load += new System.EventHandler(this.Page_Load);

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
											mySQL.MakeInParam("@UserName",SqlDbType.VarChar,255,UserName)
										};

                mySQL.RunProc("sp_GetTaskClass", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                //在DataTable的末尾加上空行，使得DataGrid固定行数
                //			int iBlankRows = dgMyTask.PageSize - (dt.Rows.Count % dgMyTask.PageSize);
                //			
                //			for (int i = 0; i < iBlankRows; i++)
                //			{
                //				dt.Rows.Add(dt.NewRow()) ;
                //			}

                dgMyTask.DataSource = dt.DefaultView;
                dgMyTask.DataBind();
                //对于空纪录不显示checkbox

                //			if(dgMyTask.CurrentPageIndex  == dgMyTask.PageCount -1 )
                //			{
                //				for(int i= (dgMyTask.PageSize - iBlankRows)  ;i<dgMyTask.Items.Count;i++)
                //				{
                //					dgMyTask.Items[i].FindControl("ClassID").Visible = false;
                //				}
                //			}
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
			dgMyTask.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion
		private void dgMyTask_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
