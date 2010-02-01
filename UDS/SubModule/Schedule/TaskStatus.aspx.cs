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
using UDS.Components;

namespace UDS.SubModule.Schedule
{
	/// <summary>
	/// TaskStatus 的摘要说明。
	/// </summary>
	public class TaskStatus : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTaskDetailTitle;
		protected System.Web.UI.WebControls.Label lblArrangedBy;
		protected System.Web.UI.WebControls.DataGrid dgList;
		protected System.Web.UI.HtmlControls.HtmlGenericControl TaskCommentFrm;
		protected static string TaskID,Username,Date;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				HttpCookie UserCookie = Request.Cookies["Username"];
				SqlDataReader dataReader = null;
                try
                {
                    Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
                    TaskID = (Request.QueryString["TaskID"] != null) ? Request.QueryString["TaskID"].ToString() : "0";
                    Date = (Request.QueryString["Date"] != null) ? Request.QueryString["Date"].ToString() : DateTime.Today.ToShortDateString();
                    Task task = new Task();
                    TaskClass tsk = task.GetTaskDetail(Int32.Parse(TaskID));
                    dataReader = task.GetTaskStatus(Int32.Parse(TaskID));
                    this.dgList.DataSource = dataReader;
                    this.dgList.DataBind();
                
				PopulateData(tsk);
				tsk = null;
				task = null;
                }
                finally
                {
                    dataReader.Close();
                }
				TaskCommentFrm.Attributes["src"] = "TaskComment.aspx?TaskID="+TaskID;
			}
		}

	
		public string GetStatus(string str)
		{
			
			switch (str) 
			{
				case "0":
					return "?"; // 待定
				case "1":
					return "√"; // 待办
				case "2":
					return "已完成"; // 完成
				default:
					return "";
			}
			

		}

		public string GetRealName(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameByUsername(Username);
			else
				return "";
		}

		private void PopulateData(TaskClass tsk)
		{	
//			string Type="";
//
//			switch (tsk.Type) 
//			{
//				case 1:
//					Type="会议";
//					break;
//				case 2:
//					Type="文案";
//					break;
//				case 3:
//					Type="来访";
//					break;
//				case 4:
//					Type="电话";
//					break;
//				case 5:
//					Type="走访";
//					break;
//				case 6:
//					Type="外出";
//					break;
//				case 7:
//					Type="假期";
//					break;
//				case 8:
//					Type="出差";
//					break;
//			
//			}
//			
			
			
		
			this.lblArrangedBy .Text	= UDS.Components .Staff.GetRealNameByUsername(tsk.ArrangedBy) ;
			//this.lblCooperator .Text    = tsk.CooperatorList ;
		
		

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
