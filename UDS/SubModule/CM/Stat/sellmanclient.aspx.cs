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

namespace UDS.SubModule.CM.Stat
{
	/// <summary>
	/// sellmanclient 的摘要说明。
	/// </summary>
	public class sellmanclient : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgrd_sellmanclient;
		protected System.Web.UI.WebControls.Literal ltl_begintime;
		protected System.Web.UI.WebControls.Literal ltl_endtime;
		protected System.Web.UI.WebControls.Literal ltl_clientno;
		protected System.Web.UI.WebControls.Literal ltl_contactno;

		private int sellmanid;
		private DateTime begintime;
		private DateTime endtime;
		private string type;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				sellmanid = (Request.QueryString["Sellmanid"]==null)?0:Int32.Parse(Request.QueryString["Sellmanid"]);
				begintime = (Request.QueryString["begintime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["begintime"]);
				endtime = (Request.QueryString["endtime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["endtime"]);
				type = (Request.QueryString["type"]==null)?"":Request.QueryString["type"];
				BindData();
			}

		}

		private void BindData()
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			SqlDataReader dr_client = null;
			if(type=="all")
			{
				 dr_client = cm.GetNewClientBySellman(sellmanid,begintime,endtime);
			}
			else if(type=="3stars")
			{
				 dr_client = cm.GetNew3StarClientBySellmanID(sellmanid,begintime,endtime);
			}

			DataSet ds = new DataSet();
			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_Staff = staff.GetAllStaffs();
			DataTable dt_Staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Staff);
			dt_Staff.TableName = "Staff";
			ds.Tables.Add(dt_Staff);

			DataTable dt_client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_client);
			dt_client.TableName = "Client";
			ds.Tables.Add(dt_client);

			ds.Relations.Add("ClientAddMan_Staff",ds.Tables["Client"].Columns["AddManID"],ds.Tables["Staff"].Columns["Staff_ID"],false);
			dgrd_sellmanclient.DataSource = dt_client.DefaultView;
			dgrd_sellmanclient.DataBind();
			
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
