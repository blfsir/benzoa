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
	/// NewStaff 的摘要说明。
	/// </summary>
	public class NewStaff : System.Web.UI.Page
	{
		public static string  DeptID;	
		private static long StaffID=0;
		private static int sex=1;
		private static int EditStatus =0;
		private int ReturnPage=0;
		protected System.Web.UI.WebControls.TextBox txtStaffName;
		protected System.Web.UI.WebControls.TextBox txtRealName;
		protected System.Web.UI.WebControls.TextBox txtBirthday;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtMobile;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RadioButton rb_male;
		protected System.Web.UI.WebControls.RadioButton rb_female;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkmail;
		protected System.Web.UI.WebControls.Literal message;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkmobile;
		protected System.Web.UI.WebControls.RegularExpressionValidator checkphone;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.DropDownList cboDepartment;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1; //记录所属部门
		protected System.Web.UI.HtmlControls.HtmlTableRow mydepartment;
		protected System.Web.UI.WebControls.TextBox txtRePassword;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		protected System.Web.UI.HtmlControls.HtmlTable AutoNumber1;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//绑定部门
				BindDepartment();				

				if(Request.QueryString["DeptID"]!=null)
				{
					DeptID = Request.QueryString["DeptID"].ToString();
					SelectDepartment(Int32.Parse(DeptID));
				}
				else
					DeptID = "0";
				
				txtBirthday.Text = DateTime.Now.ToShortDateString();

				if(Request.QueryString["StaffID"]!=null)
				{
					
					StaffID = Int32.Parse(Request.QueryString["StaffID"].ToString());
					GetStaffInfo(StaffID);
					EditStatus = 1;					
				
				}				
				else
				{
					EditStatus = 0;
					sex = 1;
				}								
			}

			if(Request.QueryString["ReturnPage"]!=null)
			{
				ReturnPage = 1;
			}
			
			//if(DeptID!="0")
				//mydepartment.Visible = false;
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
			this.txtBirthday.TextChanged += new System.EventHandler(this.txtBirthday_TextChanged);
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindDepartment()
		{
			UDS.Components.Database db = new UDS.Components.Database();
			SqlDataReader dr_department = null;
			db.RunProc("sp_GetAllDepartment",out dr_department);
			cboDepartment.DataSource = dr_department;
			cboDepartment.DataTextField = "Department_Name";
			cboDepartment.DataValueField = "Department_ID";			
			cboDepartment.DataBind();
		}
		private void GetStaffInfo(long StaffID)
		{
			SqlDataReader dr;
			UDS.Components.Staff person = new UDS.Components.Staff();
			dr = person.GetStaffInfo(StaffID);
			txtPassword.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
			txtRePassword.TextMode = System.Web.UI.WebControls.TextBoxMode.SingleLine;
			if(dr.Read ())
			{
				
				txtStaffName.Text = dr["Staff_Name"].ToString();
				txtStaffName.ReadOnly =true;
				txtRealName.Text = dr["RealName"].ToString();
				if(dr["Sex"].ToString() =="True")
				{
					rb_male.Checked =true;
					sex =1;
				}
				else
				{
					rb_female.Checked =true;
					sex = 0;
				}

				 

				txtBirthday.Text = dr["Birthday"].ToString().IndexOf(" ")>0?dr["Birthday"].ToString().Substring(0,dr["Birthday"].ToString().IndexOf(" ")):dr["Birthday"].ToString() ;
				if( txtBirthday.Text =="")
					txtBirthday.Text = DateTime.Now.ToShortDateString();
				txtPassword.Text  = dr["Password"].ToString();
				txtRePassword.Text  = dr["Password"].ToString();
				txtEmail.Text  = dr["Email"].ToString();
				txtPhone.Text =dr["Phone"].ToString();
				txtMobile.Text = dr["Mobile"].ToString();
				
				SelectDepartment(Int32.Parse(dr["Department_ID"].ToString()));

			}			
			person = null;
			dr.Close();
			dr =null;
		}
		
		private void SelectDepartment(int DepartmentID)
		{
			for(int i = 0;i<cboDepartment.Items.Count;i++ )
			{
				if(Int32.Parse(cboDepartment.Items[i].Value) == DepartmentID)
					cboDepartment.SelectedIndex = i;
			}
		}


		private void txtBirthday_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmdSubmit_Click(object sender, System.EventArgs e)
		{
            //if(rb_male.Checked==true)
            //    sex =1;
            //else
            //    sex =0;

            //if(EditStatus ==0)
            //{
            //    UDS.Components.Database db = new UDS.Components.Database();
            //    SqlDataReader dr;
            //    if(mydepartment.Visible==true)
            //        DeptID = cboDepartment.Items[cboDepartment.SelectedIndex].Value.ToString();

            //    SqlParameter[] prams = {
            //                               db.MakeInParam("@StaffName",SqlDbType.VarChar,300,txtStaffName.Text),
            //                               db.MakeInParam("@Password",SqlDbType.VarChar,300,txtPassword.Text ),
            //                               db.MakeInParam("@RealName",SqlDbType.VarChar,300,txtRealName.Text),
            //                               db.MakeInParam("@Sex",SqlDbType.Int,4,sex),
            //                               db.MakeInParam("@Status",SqlDbType.Int,4,0),
            //                               db.MakeInParam("@Email",SqlDbType.VarChar,300,txtEmail.Text),
            //                               db.MakeInParam("@RegistedDate",SqlDbType.DateTime,8,DateTime.Now.ToString()),
            //                               db.MakeInParam("@DeptID",SqlDbType.Int,4,Int32.Parse(DeptID)),
            //                               db.MakeInParam("@Phone",SqlDbType.VarChar,50,txtPhone.Text),
            //                               db.MakeInParam("@Mobile",SqlDbType.VarChar,50,txtMobile.Text),
            //                               db.MakeInParam("@Birthday",SqlDbType.DateTime,8,(txtBirthday.Text.Trim()=="")?"1900-1-1":txtBirthday.Text)
            //                           };
            //    db.RunProc("sp_AddStaff",prams,out dr);
            //    if(dr.Read())
            //        if(ReturnPage==0)
            //            Response.Redirect("ListView.aspx?Dep_ID="+DeptID);	
            //        else
            //            Response.Redirect("../Staff/ManageStaff.aspx");	
            //    else
            //        message.Text = "该用户已经存在！";
            //}
            //else
            //{
            //    UDS.Components.Staff person = new UDS.Components.Staff();		
            //    switch(person.UpdateInfo(StaffID,txtRealName.Text,sex,txtBirthday.Text,txtPassword.Text,txtEmail.Text,txtPhone.Text,txtMobile.Text,Int32.Parse(cboDepartment.Items[cboDepartment.SelectedIndex].Value )))
            //    {
            //        case 0:
            //            message.Text = "修改成功！";
            //            break;
            //        case -1:
            //            message.Text = "验证密码不对！";
            //            break;
            //        default:
            //            break;
            //    }
            //}
		
		}
	}
}
