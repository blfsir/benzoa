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
	///		ControlClientContactHistory 的摘要说明。
	/// </summary>
	public abstract class ControlClientContactHistory : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Repeater rpt_data;
		
		private int clientid;
		public int ClientID 
		{
			get{return clientid;}
			set{clientid = value;}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			
		}

		public void BindData()
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			DataSet ds = new DataSet();
			SqlDataReader dr = cm.GetClientContactInfo(ClientID);
			DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			dt.TableName = "ClientContact";
			ds.Tables.Add(dt);

			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_staff = staff.GetTotalStaffs();
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
			ds.Relations.Add("ContactMarketman_Staffs",ds.Tables["Staffs"].Columns["Staff_ID"],ds.Tables["ClientContact"].Columns["MarketmanID"],false);
			ds.Relations.Add("Contact_Linkman",ds.Tables["ClientContact"].Columns["ID"],ds.Tables["Linkman"].Columns["ContactID"],false);
			ds.Relations.Add("Contact_Cooperater",ds.Tables["ClientContact"].Columns["ID"],ds.Tables["Cooperater"].Columns["ContactID"],false);
			ds.Relations.Add("Contact_Attachment",ds.Tables["ClientContact"].Columns["ID"],ds.Tables["Attachment"].Columns["pertainid"],false);
			//ds.Relations.Add("ContactLinkman_Staffs",ds.Tables["Staffs"].Columns["Staff_ID"],ds.Tables["Linkman"].Columns["LinkmanID"],false);
			//ds.Relations.Add("ContactCooperater_Staffs",ds.Tables["Staffs"].Columns["Staff_ID"],ds.Tables["Cooperater"].Columns["CooperatingmanID"],false);
			rpt_data.DataSource = ds.Tables["ClientContact"].DefaultView;
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
