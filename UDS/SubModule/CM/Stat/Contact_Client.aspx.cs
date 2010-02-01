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
	/// Contact_Client 的摘要说明。
	/// </summary>
	public class Contact_Client : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbx_begintime;
		protected System.Web.UI.WebControls.TextBox tbx_endtime;
		protected System.Web.UI.WebControls.RadioButton rbtn_thisweek;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.HyperLink HyperLink3;
		protected System.Web.UI.WebControls.HyperLink HyperLink4;
		protected System.Web.UI.WebControls.HyperLink HyperLink5;
		protected System.Web.UI.WebControls.HyperLink HyperLink6;
		protected System.Web.UI.WebControls.HyperLink HyperLink7;
		protected System.Web.UI.WebControls.HyperLink HyperLink8;
		protected System.Web.UI.WebControls.HyperLink HyperLink11;
		protected System.Web.UI.WebControls.HyperLink HyperLink12;
		protected System.Web.UI.WebControls.Literal ltl_AddContactSellman;
		protected System.Web.UI.WebControls.Literal ltl_CallinContact;
		protected System.Web.UI.WebControls.Literal ltl_NegotiateClient_New;
		protected System.Web.UI.WebControls.Literal ltl_NegotiateClient_Total;
		protected System.Web.UI.WebControls.Literal ltl_Fee;
		protected System.Web.UI.WebControls.Literal ltl_FeeClient;
		protected System.Web.UI.WebControls.Literal ltl_Contact;
		protected System.Web.UI.WebControls.Literal ltl_NewClient;
		protected System.Web.UI.WebControls.Literal ltl_New3Client_New;
		protected System.Web.UI.WebControls.Literal ltl_New3Client_Total;
		protected System.Web.UI.WebControls.Literal ltl_FeeTimes;
		protected System.Web.UI.WebControls.Literal ltl_FeeSellman;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.RadioButton rbtn_thismonth;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			DataSet ds = new DataSet();

			DateTime begintime = DateTime.Parse(tbx_begintime.Text);
			DateTime endtime   = DateTime.Parse(tbx_endtime.Text);

			SqlDataReader dr_sellman = cm.GetSellman(begintime,endtime);
			DataTable dt_sellman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_sellman);
			dt_sellman.TableName = "Sellman";
			ds.Tables.Add(dt_sellman);
			ltl_AddContactSellman.Text = dt_sellman.Rows.Count.ToString();

			SqlDataReader dr_contact = cm.GetContactInfo(begintime,endtime);
			DataTable dt_contact = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_contact);
			dt_contact.TableName = "Contact";
			ds.Tables.Add(dt_contact);
			ltl_Contact.Text = dt_contact.Rows.Count.ToString();

			SqlDataReader dr_callincontact = cm.GetCallinContactInfo(begintime,endtime);
			DataTable dt_callincontact = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_callincontact);
			dt_callincontact.TableName = "CallinContact";
			ds.Tables.Add(dt_callincontact);
			ltl_CallinContact.Text = dt_callincontact.Rows.Count.ToString();

			SqlDataReader dr_newclient = cm.GetNewClient(begintime,endtime);
			DataTable dt_newclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_newclient);
			dt_newclient.TableName = "NewClient";
			ds.Tables.Add(dt_newclient);
			ltl_NewClient.Text = dt_newclient.Rows.Count.ToString();

			SqlDataReader dr_neoclient = cm.GetNegotiateClient();
			DataTable dt_neoclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_neoclient);
			dt_neoclient.TableName = "NeoClient";
			ds.Tables.Add(dt_neoclient);
			ltl_NegotiateClient_Total.Text = dt_neoclient.Rows.Count.ToString();

			SqlDataReader dr_neonewclient = cm.GetNewNegotiateClient(begintime,endtime);
			DataTable dt_neonewclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_neonewclient);
			dt_neonewclient.TableName = "NeoNewClient";
			ds.Tables.Add(dt_neonewclient);
			ltl_NegotiateClient_New.Text = dt_neonewclient.Rows.Count.ToString();

			SqlDataReader dr_new3client = cm.GetNew3StarClient(begintime,endtime);
			DataTable dt_new3client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_new3client);
			dt_new3client.TableName = "New3Client";
			ds.Tables.Add(dt_new3client);
			ltl_New3Client_New.Text = dt_new3client.Rows.Count.ToString();

			
			SqlDataReader dr_3client = cm.Get3StarClient();
			DataTable dt_3client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_3client);
			dt_3client.TableName = "3Client";
			ds.Tables.Add(dt_3client);
			ltl_New3Client_Total.Text = dt_3client.Rows.Count.ToString();

			int fee = 0;
			int feetimes = 0;
			foreach(DataRow row in dt_contact.Rows)
			{
				if(row["Fee"].ToString()!="0")
				{
					fee += Int32.Parse(row["fee"].ToString());
					feetimes++;
				}				
			}
			ltl_Fee.Text = fee.ToString();
			ltl_FeeTimes.Text = feetimes.ToString();

			SqlDataReader dr_feeclient = cm.GetFeeBySellmanID(0,begintime,endtime);
			DataTable dt_feeclient = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_feeclient);
			dt_feeclient.TableName = "FeeClient";
			ds.Tables.Add(dt_feeclient);

			ltl_FeeClient.Text = dt_feeclient.Rows.Count.ToString();
			dt_sellman.DefaultView.RowFilter = "Fee>0";
			ltl_FeeSellman.Text = dt_sellman.DefaultView.Count.ToString();
			
		}
	}
}
