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
	/// sellmanfee 的摘要说明。
	/// </summary>
	public class sellmanfee : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgrd_fee;
		
		private int sellmanid;
		private DateTime begintime;
		private DateTime endtime;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				sellmanid = (Request.QueryString["Sellmanid"]==null)?0:Int32.Parse(Request.QueryString["Sellmanid"]);
				begintime = (Request.QueryString["begintime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["begintime"]);
				endtime = (Request.QueryString["endtime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["endtime"]);
				ViewState["sellmanid"] = sellmanid;
				ViewState["begintime"] = begintime;
				ViewState["endtime"]  = endtime;
				BindData();
			}
			else
			{
				sellmanid = Int32.Parse(ViewState["sellmanid"].ToString());
				begintime = DateTime.Parse(ViewState["begintime"].ToString());
				endtime = DateTime.Parse(ViewState["endtime"].ToString());
			}
		}

		private void BindData()
		{
			UDS.Components.CM cm = new UDS.Components.CM();

			DataSet ds = new DataSet();
			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_Staff = staff.GetAllStaffs();
			DataTable dt_Staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Staff);
			dt_Staff.TableName = "Staff";
			ds.Tables.Add(dt_Staff);

			SqlDataReader dr_Linkman = cm.GetAllLinkman();
			DataTable dt_Linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Linkman);
			dt_Linkman.TableName = "Linkman";
			ds.Tables.Add(dt_Linkman);

			SqlDataReader dr_client = null;
			dr_client = cm.GetContactedClientBySellmanID(sellmanid,begintime,endtime);
			DataTable dt_client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_client);
			dt_client.TableName = "Client";
			ds.Tables.Add(dt_client);

			SqlDataReader dr_Fee = cm.GetFeeBySellmanID(sellmanid,begintime,endtime);
			DataTable dt_Fee = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Fee);
			dt_Fee.TableName = "Fee";
			ds.Tables.Add(dt_Fee);

			ds.Relations.Add("ClientAddMan_Staff",ds.Tables["Client"].Columns["AddManID"],ds.Tables["Staff"].Columns["Staff_ID"],false);
			ds.Relations.Add("ClientLinkman_Staff",ds.Tables["Client"].Columns["ChiefLinkmanID"],ds.Tables["Linkman"].Columns["ID"],false);
			ds.Relations.Add("Client_Fee",ds.Tables["Client"].Columns["ID"],ds.Tables["Fee"].Columns["ClientID"],false);

			dgrd_fee.DataSource = dt_client.DefaultView;
			dgrd_fee.DataBind();
			
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
