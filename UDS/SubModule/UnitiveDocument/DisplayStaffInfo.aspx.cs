using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// DisplayStaffInfo 的摘要说明。
	/// </summary>
	public class DisplayStaffInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblStaff_Name;
		protected System.Web.UI.WebControls.Label lblRealName;
		protected System.Web.UI.WebControls.Label lblSex;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.Label lblRegistedDate;
		protected static string StaffID="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{
				StaffID	 = (Request.QueryString["StaffID"]!=null)?Request.QueryString["StaffID"].ToString():"";
				PopulateData();
			}
		}

		#region 绑定人员信息
		protected void PopulateData()
		{
			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dataReader = null; 
			try
			{
				dataReader = staff.GetStaffInfo(Int32.Parse(StaffID));
			}
			catch
			{
				Server.Transfer("../Error.aspx");
			}
            try
            {
                if (dataReader.Read())
                {
                    this.lblRealName.Text = dataReader["RealName"].ToString();
                    this.lblStaff_Name.Text = dataReader["Staff_Name"].ToString();
                    this.lblEmail.Text = dataReader["Email"].ToString();
                    this.lblRegistedDate.Text = dataReader["RegistedDate"].ToString();
                    this.lblSex.Text = dataReader["Sex"].ToString() == "True" ? "男" : "女";
                }
            }
            finally
            {
                dataReader.Close();
            }

			
			
		}	

		#endregion

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
