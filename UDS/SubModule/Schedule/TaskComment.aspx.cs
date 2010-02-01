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
using System.Text.RegularExpressions;
namespace UDS.SubModule.Schedule
{
	/// <summary>
	/// TaskComment 的摘要说明。
	/// </summary>
	public class TaskComment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal lt;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				
				HttpCookie UserCookie = Request.Cookies["Username"];
                string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				string TaskID		  = (Request.QueryString["TaskID"]!=null)?Request.QueryString["TaskID"].ToString():"0";
				string Action		  = (Request.QueryString["Action"]!=null)?Request.QueryString["Action"].ToString():"0";
				string CID			  = (Request.QueryString["CID"]!=null)?Request.QueryString["CID"].ToString():"0";
				bool delflag = false;
				Task tsk = new Task();
				if(Action=="1")
				{
					try
					{
						tsk.DeleteTaskComment(Int32.Parse(CID));
						Response.Redirect("TaskComment.aspx?TaskID="+TaskID);

					}
					catch(Exception ex)
					{
						UDS.Components.Error .Log(ex.ToString());
						Server.Transfer("../Error.aspx");
					}

				}
				
				TaskClass tc = tsk.GetTaskDetail(Int32.Parse(TaskID));
				if(tc.ArrangedBy == Username) delflag=true;
				SqlDataReader dataReader = null;
				dataReader = tsk.GetTaskComment(Int32.Parse(TaskID));
				this.lt.Text = "<table class=gbtext style='BORDER-COLLAPSE: collapse'>";
                try
                {
                    while (dataReader.Read())
                    {
                        this.lt.Text += "<tr><td>" + dataReader["Comment"].ToString() + "<br>------------<br><font color=red>" + UDS.Components.Staff.GetRealNameByUsername(dataReader["Username"].ToString()) + "  ";
                        this.lt.Text += (delflag) ? "<a href='TaskComment.aspx?Action=1&TaskID=" + TaskID + "&CID=" + dataReader["ID"].ToString() + "'>删除</a>" : "";
                        this.lt.Text += "  </font><br><bR>";
                        this.lt.Text += "</td></tr>";
                    }
                    this.lt.Text += "</table>";
                }
                finally
                {
                    dataReader.Close();
                }
				
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
