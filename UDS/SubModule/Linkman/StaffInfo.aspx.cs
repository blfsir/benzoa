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

namespace UDS.SubModule.Linkman
{
	/// <summary>
	/// StaffInfo 的摘要说明。
	/// </summary>
	public class StaffInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal ltl_Name;
		protected System.Web.UI.WebControls.Literal ltl_Mobile;
		protected System.Web.UI.WebControls.Literal ltl_UnitTelephone;
		protected System.Web.UI.WebControls.Literal ltl_Gender;
		protected System.Web.UI.WebControls.Literal ltl_Email;
		protected System.Web.UI.WebControls.Literal ltl_Birthday;
		protected System.Web.UI.WebControls.Literal ltl_Position;
		protected System.Web.UI.WebControls.Literal ltl_RD;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			int staffid = 0;
			UDS.Components.Staff staff = new UDS.Components.Staff();
			staffid = ((Request.QueryString["Staff_ID"]==null)||(Request.QueryString["Staff_ID"]==""))?0:Int32.Parse(Request.QueryString["Staff_ID"]);
			SqlDataReader dr_staff = staff.GetStaffInfo(staffid);
            try
            {
                while (dr_staff.Read())
                {
                    ltl_Name.Text = dr_staff["RealName"].ToString();
                    ltl_Gender.Text = dr_staff["SexName"].ToString();
                    ltl_Mobile.Text = dr_staff["Mobile"].ToString();
                    ltl_Email.Text = dr_staff["Email"].ToString();
                    ltl_UnitTelephone.Text = dr_staff["Phone"].ToString();
                    ltl_Birthday.Text = dr_staff["Birthday"].ToString();
                    ltl_Position.Text = dr_staff["Position_Name"].ToString();
                    ltl_RD.Text = dr_staff["RQ"].ToString();
                }
            }
            finally
            {
                dr_staff.Close();
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
