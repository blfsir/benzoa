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

namespace UDS.SubModule.WorkAttendance
{
	/// <summary>
	/// Set 的摘要说明。
	/// </summary>
	public class Set : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtbegintime;
		protected System.Web.UI.WebControls.TextBox txtendtime;
		protected System.Web.UI.WebControls.CompareValidator cvdate;
		protected System.Web.UI.WebControls.RadioButton rbtnthisweek;
		protected System.Web.UI.WebControls.RadioButton rbtnthismonth;
		protected System.Web.UI.WebControls.TextBox tbx_OnDutyTime;
		protected System.Web.UI.WebControls.TextBox tbx_OffDutyTime;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
		protected System.Web.UI.WebControls.Button btn_SetTime;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnsetdate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				Database db = new Database();
                SqlDataReader dr = null ;
              
				try
				{
					db.RunProc("sp_WA_GetCompanyDutyTime",out dr);
				}
				catch(Exception ex)
				{
					UDS.Components.Error.Log(ex.Message);
					Server.Transfer("../Error.aspx");
				}
                try
                {
                    while (dr.Read())
                    {
                        tbx_OnDutyTime.Text = DateTime.Parse(dr["OnDutyTime"].ToString()).ToShortTimeString();
                        tbx_OffDutyTime.Text = DateTime.Parse(dr["OffDutyTime"].ToString()).ToShortTimeString();
                    }
                }
                finally
                {
                    if (db != null)
                    {
                        db.Close();
                    }
                    if (dr != null)
                    {
                        dr.Close();
                    }
                     
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
			this.btn_SetTime.Click += new System.EventHandler(this.btn_SetTime_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_SetTime_Click(object sender, System.EventArgs e)
		{
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@ondutytime",SqlDbType.DateTime,8,DateTime.Parse(tbx_OnDutyTime.Text)),
									   db.MakeInParam("@offdutytime",SqlDbType.DateTime,8,DateTime.Parse(tbx_OffDutyTime.Text)),
									   
								   };
			try
			{
				db.RunProc("sp_WA_UpdateComanyDutyTime",prams);
				Response.Write ("<script>window.alert('您的修改已经保存!')</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.Message);
				Server.Transfer("../Error.aspx");
			}
		}
	}
}
