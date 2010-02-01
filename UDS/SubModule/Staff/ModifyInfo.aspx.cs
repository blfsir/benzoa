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

namespace UDS.SubModule.Staff
{
	/// <summary>
	/// ModifyInfo1 的摘要说明。
	/// </summary>
	public class ModifyInfo1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtStaffName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtRealName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RadioButton rb_male;
		protected System.Web.UI.WebControls.RadioButton rb_female;
		protected System.Web.UI.WebControls.TextBox txtBirthday;
		protected System.Web.UI.WebControls.RegularExpressionValidator datecheck;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkmail;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkphone;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkmobile;
		protected System.Web.UI.WebControls.DropDownList cboDepartment;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPassword;
		protected System.Web.UI.HtmlControls.HtmlInputText txtRePassword;
		protected System.Web.UI.HtmlControls.HtmlTableRow mydepartment;
		protected System.Web.UI.WebControls.Literal message;
		protected System.Web.UI.WebControls.DataGrid StaffList;
		protected System.Web.UI.WebControls.TextBox txb_PageNo;
		protected System.Web.UI.WebControls.TextBox txb_ItemPerPage;
		protected System.Web.UI.WebControls.Label lbl_totalrecord;
		protected System.Web.UI.WebControls.ImageButton btn_first;
		protected System.Web.UI.WebControls.ImageButton btn_pre;
		protected System.Web.UI.WebControls.Label lbl_curpage;
		protected System.Web.UI.WebControls.Label lbl_totalpage;
		protected System.Web.UI.WebControls.ImageButton btn_next;
		protected System.Web.UI.WebControls.ImageButton btn_last;
		protected System.Web.UI.HtmlControls.HtmlInputButton btn_Go;
		protected System.Web.UI.HtmlControls.HtmlInputButton cmdSubmit;
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
