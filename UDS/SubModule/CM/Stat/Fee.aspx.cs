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
	/// Fee 的摘要说明。
	/// </summary>
	public class Fee : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddl_order;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.RadioButton rbtn_thismonth;
		protected System.Web.UI.WebControls.RadioButton rbtn_thisweek;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox tbx_endtime;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.DataGrid dgrd_clientfee;
		protected System.Web.UI.WebControls.DataGrid dgrd_sellmanfee;
		protected System.Web.UI.WebControls.TextBox tbx_begintime;
	
		protected DateTime begintime;
		protected DateTime endtime;
		protected System.Web.UI.WebControls.Literal ltl_Fee;
		protected System.Web.UI.WebControls.Literal ltl_Client;
		private string type = "";
		protected int totalfee = 0;

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
				ViewState["type"]  = type;

				tbx_begintime.Text = begintime.ToShortDateString();
				tbx_endtime.Text = endtime.ToShortDateString();

				foreach(ListItem li in ddl_order.Items)
				{
					if(li.Value==type)
					{
						li.Selected = true;
					}
					else
					{
						li.Selected = false;
					}
				}
				if(type!="") BindData(type);
			}
			else
			{
				begintime = DateTime.Parse(ViewState["begintime"].ToString());
				endtime = DateTime.Parse(ViewState["endtime"].ToString());
				type    = ViewState["type"].ToString();
			}
		}

		private void BindData(string type)
		{
			begintime = DateTime.Parse(tbx_begintime.Text);
			endtime   = DateTime.Parse(tbx_endtime.Text);

			UDS.Components.CM cm = new UDS.Components.CM();
			DataSet ds = new DataSet();
			UDS.Components.Staff staff = new UDS.Components.Staff();

			SqlDataReader dr_staff = staff.GetAllStaffs();
			DataTable dt_staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_staff);
			dt_staff.TableName = "Staff";
			ds.Tables.Add(dt_staff);

			SqlDataReader dr_client = cm.GetContactedClientBySellmanID(0,begintime,endtime);
			DataTable dt_client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_client);
			dt_client.TableName = "Client";
			ds.Tables.Add(dt_client);

			ltl_Client.Text = dt_client.Rows.Count.ToString();

			if(type=="client")//按客户排列
			{
				dgrd_clientfee.Visible = true;
				dgrd_sellmanfee.Visible = false;

				SqlDataReader dr_contact = cm.GetContactInfo(begintime,endtime);
				DataTable dt_contact = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_contact);
				dt_contact.TableName = "Contact";
				ds.Tables.Add(dt_contact);

				SqlDataReader dr_linkman = cm.GetAllLinkman();
				DataTable dt_linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);
				dt_linkman.TableName = "Linkman";
				ds.Tables.Add(dt_linkman);

				ds.Relations.Add("ClientAddMan_Staff",ds.Tables["Client"].Columns["AddManID"],ds.Tables["Staff"].Columns["Staff_ID"],false);
				ds.Relations.Add("ClientLinkman_Staff",ds.Tables["Client"].Columns["ChiefLinkmanID"],ds.Tables["Linkman"].Columns["ID"],false);
				ds.Relations.Add("Client_Contact",ds.Tables["Client"].Columns["ID"],ds.Tables["Contact"].Columns["ClientID"],false);

				dgrd_clientfee.DataSource = dt_client.DefaultView;
				dgrd_clientfee.DataBind();

				ltl_Fee.Text = totalfee.ToString();
			}
			else if(type=="sellman")
			{
				dgrd_clientfee.Visible = false;
				dgrd_sellmanfee.Visible = true;

				SqlDataReader dr_sellman = cm.GetSellman(begintime,endtime);
				DataTable dt_sellman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_sellman);
				dt_sellman.TableName = "Sellman";
				ds.Tables.Add(dt_sellman);

				foreach(DataRow row in dt_sellman.Rows)
				{
					totalfee += Int32.Parse(row["fee"].ToString());
				}

				ds.Relations.Add("StaffID_RealName",ds.Tables["Sellman"].Columns["Staff_Name"],ds.Tables["Staff"].Columns["Staff_Name"],false); 

				dgrd_sellmanfee.DataSource = dt_sellman.DefaultView;
				dgrd_sellmanfee.DataBind();

				ltl_Fee.Text = totalfee.ToString();
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
			this.ddl_order.SelectedIndexChanged += new System.EventHandler(this.ddl_order_SelectedIndexChanged);
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			BindData(ddl_order.SelectedItem.Value);
		}

		private void ddl_order_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(((DropDownList)sender).SelectedItem.Value=="client")
			{
				dgrd_clientfee.Visible = true;
				dgrd_sellmanfee.Visible = false;
			}
			else if(((DropDownList)sender).SelectedItem.Value=="sellman")
			{
				dgrd_clientfee.Visible = false;
				dgrd_sellmanfee.Visible = true;
			}
			BindData(((DropDownList)sender).SelectedItem.Value);
		}
	}
}
