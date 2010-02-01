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
	/// DisplayStaffInfo ��ժҪ˵����
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

		#region ����Ա��Ϣ
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
                    this.lblSex.Text = dataReader["Sex"].ToString() == "True" ? "��" : "Ů";
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
