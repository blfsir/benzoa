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
	/// CustomLinkman 的摘要说明。
	/// </summary>
	public class CustomLinkman : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList dlt_Type;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.HtmlControls.HtmlTable tbl_Custom;
		protected System.Web.UI.HtmlControls.HtmlSelect ddl_Gender;
		protected System.Web.UI.WebControls.TextBox tbx_Memo;
		protected System.Web.UI.WebControls.TextBox tbx_FamilyZip;
		protected System.Web.UI.WebControls.TextBox tbx_UnitZip;
		protected System.Web.UI.WebControls.TextBox tbx_Age;
		protected System.Web.UI.WebControls.TextBox tbx_UnitTelephone;
		protected System.Web.UI.WebControls.TextBox tbx_FamilyTelephone;
		protected System.Web.UI.WebControls.TextBox tbx_Email;
		protected System.Web.UI.WebControls.TextBox tbx_Mobile;
		protected System.Web.UI.WebControls.TextBox tbx_FamilyAddress;
		protected System.Web.UI.WebControls.TextBox tbx_UnitAddress;
		protected System.Web.UI.WebControls.TextBox tbx_Name;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
	
		private int id = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				id = ((Request.QueryString["ID"]==null)||(Request.QueryString["ID"]==""))?0:Int32.Parse(Request.QueryString["ID"]);
				ViewState["ID"] = id.ToString();
				BindData();
			}
			else
			{
				id = Int32.Parse(ViewState["ID"].ToString());
			}
			if(id==0)
				btn_OK.Text = "添加";
			else
				btn_OK.Text = "修改";
		}

		private void BindData()
		{	
			UDS.Components.MyLinkman mlinkman = new UDS.Components.MyLinkman();
			SqlDataReader dr_mlinkman = mlinkman.GetCustomLinkman(id);
			BindTypeList();
            try
            {
                while (dr_mlinkman.Read())
                {
                    tbx_Name.Text = dr_mlinkman["Name"].ToString();
                    tbx_Age.Text = dr_mlinkman["Age"].ToString();
                    tbx_UnitAddress.Text = dr_mlinkman["UnitAddress"].ToString();
                    tbx_UnitTelephone.Text = dr_mlinkman["UnitTelephone"].ToString();
                    tbx_UnitZip.Text = dr_mlinkman["UnitZip"].ToString();
                    tbx_FamilyAddress.Text = dr_mlinkman["FamilyAddress"].ToString();
                    tbx_FamilyTelephone.Text = dr_mlinkman["FamilyTelephone"].ToString();
                    tbx_FamilyZip.Text = dr_mlinkman["FamilyZip"].ToString();
                    tbx_Mobile.Text = dr_mlinkman["Mobile"].ToString();
                    tbx_Email.Text = dr_mlinkman["Email"].ToString();
                    tbx_Memo.Text = dr_mlinkman["Memo"].ToString();

                    if (Convert.ToBoolean(dr_mlinkman["Gender"]) == true)
                    {
                        ddl_Gender.SelectedIndex = 0;
                    }
                    else
                    {
                        ddl_Gender.SelectedIndex = 1;
                    }

                    SqlDataReader dr_type = mlinkman.GetCustomLinkmanType(id);
                    try
                    {
                        while (dr_type.Read())
                        {
                            foreach (DataListItem dli in dlt_Type.Items)
                            {
                                if (((CheckBox)dli.FindControl("Checkbox1")).Text == dr_type["Type"].ToString())
                                    ((CheckBox)dli.FindControl("Checkbox1")).Checked = true;
                            }
                        }
                    }
                    finally
                    {
                        dr_type.Close();
                    }

                }
            }
            finally
            {
                dr_mlinkman.Close();
            }
		}

		//bound to linkmantype
		private void BindTypeList()
		{
			UDS.Components.MyLinkman mylinkman = new UDS.Components.MyLinkman();
			dlt_Type.DataSource = mylinkman.GetCustomLinkmanType();
			dlt_Type.DataKeyField = "ID";
			dlt_Type.DataBind();
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
			this.tbx_Email.TextChanged += new System.EventHandler(this.tbx_Email_TextChanged);
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			UDS.Components.MyLinkman mlinkman = new UDS.Components.MyLinkman();
			UDS.Components.CustomLinkman clinkman = new UDS.Components.CustomLinkman();
			
			clinkman.Name = tbx_Name.Text;
			clinkman.Age = tbx_Age.Text;
			clinkman.Gender = (ddl_Gender.Items[ddl_Gender.SelectedIndex].Value=="1")?true:false;
			clinkman.UnitAddress = tbx_UnitAddress.Text;
			clinkman.UnitTelephone = tbx_UnitTelephone.Text;
			clinkman.UnitZip = tbx_UnitZip.Text;
			clinkman.FamilyAddress = tbx_FamilyAddress.Text;
			clinkman.FamilyTelephone = tbx_FamilyTelephone.Text;
			clinkman.FamilyZip = tbx_FamilyZip.Text;
			clinkman.Email = tbx_Email.Text;
			clinkman.Mobile = tbx_Mobile.Text;
			clinkman.Memo = tbx_Memo.Text;
			clinkman.ID = id;

			for(int i = 0;i<dlt_Type.Items.Count;i++)
			{
				if(((CheckBox)dlt_Type.Items[i].Controls[1]).Checked==true)
				{
					clinkman.Type += dlt_Type.DataKeys[i].ToString() + ",";
				}
			}

			mlinkman.UpdateCustomLinkman(clinkman);
			mlinkman.UpdateCustomLinkmanType(clinkman);

			BindData();

			if(id==0)
				Response.Write("<script>alert('添加成功!');</script>");
			else
				Response.Write("<script>alert('修改成功!');</script>");

		}

		private void tbx_Email_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
