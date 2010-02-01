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

namespace UDS.SubModule.Role
{
	/// <summary>
	/// ORole 的摘要说明。
	/// </summary>
	public class ORole : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdAdd;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdDelete;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdModify;

		protected System.Web.UI.WebControls.Label delRoleName;

		protected System.Web.UI.WebControls.TextBox txtARoleName;
		protected System.Web.UI.WebControls.TextBox txtARoleDescription;
		protected System.Web.UI.WebControls.TextBox txtMRoleName;
		protected System.Web.UI.WebControls.TextBox txtMRoleDescription;

		public int RoleID;//角色id
		
		protected System.Web.UI.HtmlControls.HtmlTable tabAdd;
		protected System.Web.UI.HtmlControls.HtmlTable tabDelete;
		protected System.Web.UI.HtmlControls.HtmlTable tabModify;

		private string RoleName="";
		private string RoleDescription="";
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		public int DisplayType;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			RoleID=(Request.QueryString["Role_ID"]==null)?0:Int32.Parse(Request.QueryString["Role_ID"].ToString());
			DisplayType =  Int32.Parse((Request.QueryString["DisplayType"]==null)?"0":Request.QueryString["DisplayType"].ToString());

			if(!Page.IsPostBack)
			{
				txtMRoleName.Text = "";

				SqlDataReader dr;
				
				UDS.Components.Role myRole	= new UDS.Components.Role();
				dr							= myRole.GetRoleInfo(RoleID);
                try
                {
                    while (dr.Read())
                    {
                        RoleName = dr["Role_Name"].ToString();
                        RoleDescription = dr["Role_Description"].ToString();
                    }
                }
                finally
                {
                    
                    if (dr != null)
                    {

                        dr.Close();
                    }
                }

				dr		= null;
				myRole	= null;
				
			}

			// 显示不同表格
			if(DisplayType == 0)
			{
				tabAdd.Visible			= true;
				tabDelete.Visible		= false;
				tabModify.Visible		= false;
				tabAdd.Style["left"]	= "0px";
				tabAdd.Style["top"]		= "100px";
			}
			else if(DisplayType==1)
			{
				tabAdd.Visible			= false;
				tabDelete.Visible		= true;
				tabModify.Visible		= false;
				tabDelete.Style["left"] = "0px";
				tabDelete.Style["top"]	= "100px";

				delRoleName.Text		= RoleName;
			}
			else if(DisplayType==2)
			{
				tabAdd.Visible			= false;
				tabDelete.Visible		= false;
				tabModify.Visible		= true;
				tabModify.Style["left"] = "0px";
				tabModify.Style["top"]	= "100px";

				if(txtMRoleName.Text.Trim() == "") 
				{
					txtMRoleName.Text			= RoleName;
					txtMRoleDescription.Text	= RoleDescription;
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
			this.cmdModify.ServerClick += new System.EventHandler(this.cmdModify_ServerClick);
			this.cmdDelete.ServerClick += new System.EventHandler(this.cmdDelete_ServerClick);
			this.cmdAdd.ServerClick += new System.EventHandler(this.cmdAdd_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAdd_ServerClick(object sender,System.EventArgs e)
		{
			if(UDS.Components.Role.Add(txtARoleName.Text,txtARoleDescription.Text)<0)
			{
				UDS.Components.Error.Log("添加角色出错");
				Response.Redirect("../Error.aspx");
			}
			else
				Response.Redirect("ListView.aspx?Role_ID=" +RoleID.ToString() + "&Refresh=1");
		}

		private void cmdDelete_ServerClick(object sender,System.EventArgs e)
		{
			if(UDS.Components.Role.Delete(RoleID)!=0)
			{
				UDS.Components.Error.Log("添加角色出错");
				Response.Redirect("../Error.aspx");
			}
			else
				Response.Redirect("ListView.aspx?Role_ID="+RoleID.ToString()+"&Refresh=1");

		}

		private void cmdModify_ServerClick(object sender,System.EventArgs e)
		{
			if(UDS.Components.Role.Modify(RoleID,txtMRoleName.Text,txtMRoleDescription.Text)!=0)
			{				
				UDS.Components.Error.Log("添加角色出错");
				Response.Redirect("../Error.aspx");
			}
			else
				Response.Redirect("ListView.aspx?Role_ID="+RoleID.ToString()+"&Refresh=1");
		}


	}
}
