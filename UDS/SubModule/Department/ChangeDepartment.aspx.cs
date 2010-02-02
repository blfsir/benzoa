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

namespace UDS.SubModule.Department
{
	/// <summary>
	/// ChangeDepartment ��ժҪ˵����
	/// </summary>
	public class ChangeDepartment : System.Web.UI.Page
	{
		private static string DeptID;
		private static string displayType;
		private static string selectedID;
		private static string backfilepath;
		private int ReturnPage =0;


		protected System.Web.UI.HtmlControls.HtmlInputButton cmdSubmit;
		protected System.Web.UI.WebControls.Label Label1;
		protected HtmlSelect Department;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				DeptID = (Request.QueryString["DeptID"]==null)?"":Request.QueryString["DeptID"].ToString();
				displayType = (Request.QueryString["displayType"]==null)?"":Request.QueryString["displayType"].ToString();
				selectedID = (Request.QueryString["StaffIDS"]==null)?"":Request.QueryString["StaffIDS"].ToString();
				backfilepath =(Request.QueryString["BackFilePath"]==null)?"":Request.QueryString["BackFilePath"].ToString();
				SqlDataReader dr;
				UDS.Components.Database db = new UDS.Components.Database();
				db.RunProc("SP_Ext_GetDepartment",out dr);
				Department.DataSource = dr;
				Department.DataTextField = "Department_Name";
				Department.DataValueField = "Department_ID";
				Department.DataBind();
			}
			if(Request.QueryString["ReturnPage"]!=null)
			{
				ReturnPage  = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
			}
			else
				ReturnPage = 0;


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
			this.cmdSubmit.ServerClick += new System.EventHandler(this.cmdSubmit_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSubmit_ServerClick(object sender, System.EventArgs e)
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
										db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,selectedID),
										db.MakeInParam("@NewDeptID",SqlDbType.Int,4,Int32.Parse(Department.Items[Department.SelectedIndex].Value))
								   };
			db.RunProc("sp_StaffMove",prams);
			if(ReturnPage ==0)
				Response.Redirect(backfilepath+"?DeptID="+DeptID+"&displayType="+displayType);
			else
				Response.Redirect("../Staff/ManageStaff.aspx?DisplayType=0");
		}
	}
}
