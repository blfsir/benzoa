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
	/// sellman 的摘要说明。
	/// </summary>
	public class sellman : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButton rbtn_thismonth;
		protected System.Web.UI.WebControls.RadioButton rbtn_thisweek;
		protected System.Web.UI.WebControls.TextBox tbx_endtime;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.TextBox tbx_begintime;
	
		protected DateTime begintime;
		protected System.Web.UI.WebControls.DataGrid dgrd_sellman;
		protected DateTime endtime;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				begintime = (Request.QueryString["begintime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["begintime"]);
				endtime = (Request.QueryString["endtime"]==null)?DateTime.Now:DateTime.Parse(Request.QueryString["endtime"]);
				tbx_begintime.Text = begintime.ToShortDateString();
				tbx_endtime.Text = endtime.ToShortDateString();

				if(Request.QueryString["begintime"]!=null)
				{
					BindData();
				}
				ViewState["begintime"] = begintime.ToShortDateString();
				ViewState["endtime"] = endtime.ToShortDateString();
			}
			else
			{
				begintime = DateTime.Parse(ViewState["begintime"].ToString());
				endtime   = DateTime.Parse(ViewState["endtime"].ToString());
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
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindData()
		{
			begintime = DateTime.Parse(tbx_begintime.Text);
			endtime  =  DateTime.Parse(tbx_endtime.Text);

			UDS.Components.CM cm = new UDS.Components.CM();
			UDS.Components.Staff staff= new UDS.Components.Staff();
			DataSet ds = new DataSet();

			SqlDataReader dr_realname = staff.GetAllStaffs();
			DataTable dt_realname = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_realname);
			dt_realname.TableName = "Realname";
			ds.Tables.Add(dt_realname);

			SqlDataReader dr_sellman = cm.GetSellman(begintime,endtime);
			DataTable dt_sellman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_sellman);
			dt_sellman.TableName = "Sellman";
			ds.Tables.Add(dt_sellman);

			SqlDataReader dr_contact = cm.GetContactInfo(begintime,endtime);
			DataTable dt_contact = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_contact);
			dt_contact.TableName = "Contact";
			ds.Tables.Add(dt_contact);

			SqlDataReader dr_callincontact = cm.GetCallinContactInfo(begintime,endtime);
			DataTable dt_callincontact = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_callincontact);
			dt_callincontact.TableName = "CallinContact";
			ds.Tables.Add(dt_callincontact);

			SqlDataReader dr_newclient = cm.GetNewClient(begintime,endtime);
			DataTable dt_newclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_newclient);
			dt_newclient.TableName = "NewClient";
			ds.Tables.Add(dt_newclient);

			SqlDataReader dr_new3client = cm.GetNew3StarClient(begintime,endtime);
			DataTable dt_new3client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_new3client);
			dt_new3client.TableName = "New3Client";
			ds.Tables.Add(dt_new3client);

			ds.Relations.Add("staffid_realname",ds.Tables["Sellman"].Columns["SellmanID"],ds.Tables["Realname"].Columns["staff_id"],false);
			ds.Relations.Add("sellman_contact",ds.Tables["Sellman"].Columns["SellmanID"],ds.Tables["Contact"].Columns["MarketmanID"],false);
			ds.Relations.Add("sellman_callincontact",ds.Tables["Sellman"].Columns["SellmanID"],ds.Tables["CallinContact"].Columns["MarketmanID"],false);
			ds.Relations.Add("sellman_newclient",ds.Tables["Sellman"].Columns["SellmanID"],ds.Tables["NewClient"].Columns["AddmanID"],false);
			ds.Relations.Add("sellman_new3client",ds.Tables["Sellman"].Columns["SellmanID"],ds.Tables["New3Client"].Columns["AddmanID"],false);

			dgrd_sellman.DataSource = dt_sellman.DefaultView;
			dgrd_sellman.DataBind();
		}

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			BindData();
		}
	}
}
