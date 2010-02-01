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
	/// ContactedClient 的摘要说明。
	/// </summary>
	public class ContactedClient : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgrd_Client;
	
		private DateTime begintime;
		private DateTime endtime;
		protected System.Web.UI.WebControls.Literal ltl_Client;
		private string type;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				begintime = (Request.QueryString["begintime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["begintime"]);
				endtime = (Request.QueryString["endtime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["endtime"]);
				type = (Request.QueryString["type"]==null)?"":Request.QueryString["type"];

				ViewState["begintime"] = begintime;
				ViewState["endtime"]  = endtime;
				ViewState["type"] = type;

				BindData(type);
			}
			else
			{
				begintime = DateTime.Parse(ViewState["begintime"].ToString());
				endtime = DateTime.Parse(ViewState["endtime"].ToString());
				type = ViewState["type"].ToString();
			}
		}

		private void BindData(string type)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			DataSet ds = new DataSet();

			switch(type)
			{
				case "ac":
					SqlDataReader dr_contactedclient = cm.GetContactedClientBySellmanID(0,begintime,endtime);
					DataTable dt_contactedclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_contactedclient);
					dt_contactedclient.TableName = "Client";
					ds.Tables.Add(dt_contactedclient);
					break;
				case "cc":
					SqlDataReader dr_contactedcallinclient = cm.GetCallinClientBySellmanID(0,begintime,endtime);
					DataTable dt_contactedcallinclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_contactedcallinclient);
					dt_contactedcallinclient.TableName = "Client";
					ds.Tables.Add(dt_contactedcallinclient);
					break;
				case "nc":
					SqlDataReader dr_newclient = cm.GetCallinClientBySellmanID(0,begintime,endtime);
					DataTable dt_newclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_newclient);
					dt_newclient.TableName = "Client";
					ds.Tables.Add(dt_newclient);
					break;
				case "neoc":
					SqlDataReader dr_neoclient = cm.GetNegotiateClient();
					DataTable dt_neoclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_neoclient);
					dt_neoclient.TableName = "Client";
					ds.Tables.Add(dt_neoclient);
					break;
				case "neonc":
					SqlDataReader dr_neonewclient = cm.GetNewNegotiateClient(begintime,endtime);
					DataTable dt_neonewclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_neonewclient);
					dt_neonewclient.TableName = "Client";
					ds.Tables.Add(dt_neonewclient);
					break;
				case "n3c":
					SqlDataReader dr_new3client = cm.GetNew3StarClient(begintime,endtime);
					DataTable dt_new3client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_new3client);
					dt_new3client.TableName = "Client";
					ds.Tables.Add(dt_new3client);
					break;
				case "3c":
					SqlDataReader dr_3client = cm.Get3StarClient();
					DataTable dt_3client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_3client);
					dt_3client.TableName = "Client";
					ds.Tables.Add(dt_3client);
					break;


			}

			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_staff = staff.GetAllStaffs();
			DataTable dt_staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_staff);
			dt_staff.TableName = "Staff";
			ds.Tables.Add(dt_staff);

			ds.Relations.Add("StaffID_Staff",ds.Tables["Client"].Columns["AddmanID"],ds.Tables["Staff"].Columns["Staff_ID"],false);
			
			ltl_Client.Text = ds.Tables["Client"].Rows.Count.ToString();

			dgrd_Client.DataSource = ds.Tables["Client"].DefaultView;
			dgrd_Client.DataBind();
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
