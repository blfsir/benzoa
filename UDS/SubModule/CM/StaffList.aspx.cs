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

namespace UDS.SubModule.CM
{
	/// <summary>
	/// StaffList ��ժҪ˵����
	/// </summary>
	public class StaffList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lbx_Staff;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			SqlDataReader dr_sellman = null;
			Database db = new Database();
            try
            {
                db.RunProc("sp_GetAllStaff", out dr_sellman);
                lbx_Staff.DataSource = dr_sellman;
                lbx_Staff.DataTextField = "staff_name";
                lbx_Staff.DataValueField = "staff_id";
                lbx_Staff.DataBind();
            }
            finally
            {
                db.Close();
                dr_sellman.Close();
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
