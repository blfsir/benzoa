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

namespace UDS.SubModule.CM
{
	/// <summary>
	/// ClientHistoryContact 的摘要说明。
	/// </summary>
	public class ClientHistoryContact : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal ltl_ClientName;
		protected System.Web.UI.WebControls.Literal ltl_UpdateTime;
		protected System.Web.UI.WebControls.Literal ltl_ClientShortName;
		protected System.Web.UI.WebControls.Literal ltl_Birthday;
		protected System.Web.UI.WebControls.Literal ltl_BargainPrognosis;
		protected System.Web.UI.WebControls.Literal ltl_SellPhase;
		protected System.Web.UI.WebControls.Literal ltl_Fee;
		protected System.Web.UI.WebControls.Literal ltl_AddMan;
		protected System.Web.UI.WebControls.Literal ltl_ContactTimes;
		protected UDS.Inc.ControlClientContactHistory ControlClientContactHistory1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				UDS.Components.CM cm = new UDS.Components.CM();
				int clientid = Int32.Parse((Request.QueryString["ClientID"]==null)||(Request.QueryString["ClientID"]=="")?"0":Request.QueryString["ClientID"].ToString());
				UDS.Components.ClientInfo client = cm.GetClientAllInfo(clientid);
				ltl_ClientName.Text = client.ClientName;
				ltl_ClientShortName.Text = client.ClientShortName;
				ltl_UpdateTime.Text = client.UpdateTime.ToShortDateString();
				ltl_Birthday.Text = client.Birthday.ToShortDateString();
				ltl_ContactTimes.Text = client.ContactTimes.ToString();
				ltl_SellPhase.Text = client.SellPhase;
				ltl_BargainPrognosis.Text = client.BargainPrognosis;
				ltl_Fee.Text = client.Fee.ToString();


				//显示销售人员
				UDS.Components.Staff staff = new UDS.Components.Staff();
				SqlDataReader dr_staff = staff.GetStaffInfo(client.AddManID);
                try
                {
                    while (dr_staff.Read())
                    {
                        ltl_AddMan.Text = dr_staff["realname"].ToString();
                    }
                }
                finally
                {
                    dr_staff.Close();
                    dr_staff = null;
                }
				
				ControlClientContactHistory1.ClientID = clientid;
				ControlClientContactHistory1.BindData();
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
