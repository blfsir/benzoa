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
	/// TaskStatus ��ժҪ˵����
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
					return "?"; // ����
				case "1":
					return "��"; // ����
				case "2":
					return "�����"; // ���
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
//					Type="����";
//					break;
//				case 2:
//					Type="�İ�";
//					break;
//				case 3:
//					Type="����";
//					break;
//				case 4:
//					Type="�绰";
//					break;
//				case 5:
//					Type="�߷�";
//					break;
//				case 6:
//					Type="���";
//					break;
//				case 7:
//					Type="����";
//					break;
//				case 8:
//					Type="����";
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
