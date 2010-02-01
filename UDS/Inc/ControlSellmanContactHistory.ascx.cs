namespace UDS.Inc
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		ControlSellmanContactHistory 的摘要说明。
	/// </summary>
	public abstract class ControlSellmanContactHistory : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater rpt_data;

		private int sellmanid;
		private DateTime begintime;
		private DateTime endtime;
		private string type;

		public int SellmanID
		{
			get{return sellmanid;}
			set{sellmanid = value;}
		}
		public DateTime BeginTime
		{
			get{return begintime;}
			set{begintime = value;}
		}
		public DateTime EndTime
		{
			get{return endtime;}
			set{endtime = value;}
		}
		public string Type
		{
			get{return type;}
			set{type = value;}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			UDS.Components.CM cm = new UDS.Components.CM();
			DataSet ds = new DataSet();
			
			if(type=="all")
			{	
				SqlDataReader dr_contact = cm.GetContactBySellmanID(sellmanid,begintime,endtime);
				DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_contact);
				dt.TableName = "Contact";
				ds.Tables.Add(dt);
			}
			else if(type=="callin")
			{
				SqlDataReader dr_callincontact = cm.GetCallinClientBySellmanID(sellmanid,begintime,endtime);
				DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_callincontact);
				dt.TableName = "Contact";
				ds.Tables.Add(dt);
			}
			

			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_staff = staff.GetAllStaffs();
			DataTable dt1 = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_staff);
			dt1.TableName = "Staffs";
			ds.Tables.Add(dt1);

			SqlDataReader dr_linkman = cm.GetAllContactLinkman();
			DataTable dt2 = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);
			dt2.TableName = "Linkman";
			ds.Tables.Add(dt2);

			SqlDataReader dr_cooperater = cm.GetAllCooperater();
			DataTable dt3 = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_cooperater);
			dt3.TableName = "Cooperater";
			ds.Tables.Add(dt3);

			SqlDataReader dr_att = cm.GetAttachmentByContactID(0);
			DataTable dt4 = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_att);
			dt4.TableName = "Attachment";
			ds.Tables.Add(dt4);

			ds.Relations.Add("ContactMarketman_Staffs",ds.Tables["Staffs"].Columns["Staff_ID"],ds.Tables["Contact"].Columns["MarketmanID"]);
			ds.Relations.Add("Contact_Linkman",ds.Tables["Contact"].Columns["ID"],ds.Tables["Linkman"].Columns["ContactID"],false);
			ds.Relations.Add("Contact_Cooperater",ds.Tables["Contact"].Columns["ID"],ds.Tables["Cooperater"].Columns["ContactID"],false);
			ds.Relations.Add("Contact_Attachment",ds.Tables["Contact"].Columns["ID"],ds.Tables["Attachment"].Columns["pertainid"],false);


			rpt_data.DataSource = ds.Tables["Contact"].DefaultView;
			rpt_data.DataBind();
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
		
		///		设计器支持所需的方法 - 不要使用
		///		代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
