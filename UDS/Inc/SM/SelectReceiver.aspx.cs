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
using UDS.Components;


namespace UDS.SubModule.SM
{
	/// <summary>
	/// SelectReceiver 的摘要说明。
	/// </summary>
	public class SelectReceiver : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList listAccount;
		protected System.Web.UI.WebControls.Label lblReceiver;
		protected System.Web.UI.WebControls.Label lblMReceiver;
		protected System.Web.UI.WebControls.DropDownList listDept;

        protected System.Web.UI.WebControls.TextBox txtSearchName;
        protected System.Web.UI.WebControls.Button btnSearch;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack )
			{
				PopulateData();
			}
		}

		#region 初始化下拉列表框
		/// <summary>
		/// 对数据进行初始化
		/// </summary>
		private void PopulateData() 
		{
		
			UDS.Components.Staff staff	= new UDS.Components.Staff();
			listAccount.Items.Clear();
			listAccount.DataSource = staff.GetAllStaffs();
			listAccount.DataTextField = "RealName";
			listAccount.DataValueField = "Staff_Name";
			listAccount.DataBind ();
			
			listDept .DataSource = staff.GetPositionList(1);
			listDept.DataTextField = "Position_Name";
			listDept.DataValueField = "Position_ID";
			listDept.DataBind();
			listDept.Items.Insert(0,new ListItem("公司所有部门","0"));
			listDept.SelectedIndex = 0;
			listDept.Attributes["onclick"]="SaveValue()";
			staff=null;
		}
		#endregion

		#region 下拉列表事件
		public void DeptListChange(object sender, System.EventArgs e)
		{
		
			UDS.Components.Staff staff	= new UDS.Components.Staff();
			if(listDept.SelectedItem.Value!="0")
			{
				
				listAccount.DataSource = staff.GetStaffByPosition(Int32.Parse(listDept.SelectedItem.Value));
			}
			else
			{
				listAccount.DataSource = staff.GetAllStaffs();
			}			
			listAccount.DataTextField = "RealName";
			listAccount.DataValueField = "Staff_Name";
			listAccount.DataBind ();
			staff = null;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            UDS.Components.Staff staff = new UDS.Components.Staff();
            DataTable datatable = UDS.Components.Tools.ConvertDataReaderToDataTable(staff.FindStaffByName(this.txtSearchName.Text));
            listAccount.DataSource = datatable;
            listAccount.DataTextField = "RealName";
            listAccount.DataValueField = "Staff_Name";
            listAccount.DataBind();
            this.txtSearchName.Text = "";
            staff = null;
        }
	}
}
