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
	/// AddLinkman 的摘要说明。
	/// </summary>
	public class AddLinkman : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTable tbl_Custom;
		protected System.Web.UI.HtmlControls.HtmlTable tbl_Select;
		protected System.Web.UI.WebControls.DropDownList ddl_LinkmanType;
		protected System.Web.UI.WebControls.TextBox tbx_Name;
		protected System.Web.UI.HtmlControls.HtmlSelect ddl_Gender;
		protected System.Web.UI.WebControls.TextBox tbx_Email;
		protected System.Web.UI.WebControls.TextBox tbx_FamilyAddress;
		protected System.Web.UI.WebControls.TextBox tbx_FamilyZip;
		protected System.Web.UI.WebControls.TextBox tbx_Mobile;
		protected System.Web.UI.WebControls.TextBox tbx_Age;
		protected System.Web.UI.WebControls.TextBox tbx_UnitAddress;
		protected System.Web.UI.WebControls.TextBox tbx_UnitZip;
		protected System.Web.UI.WebControls.TextBox tbx_UnitTelephone;
		protected System.Web.UI.WebControls.TextBox tbx_FamilyTelephone;
		protected System.Web.UI.WebControls.TextBox tbx_Memo;
		protected System.Web.UI.WebControls.DataList dlt_Type;
		protected System.Web.UI.WebControls.DataGrid dgrd_List;
		protected System.Web.UI.WebControls.DataGrid dgrd_Linkman;
		protected System.Web.UI.WebControls.Button btn_AddList;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.Button btn_Back;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator7;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
	
		private int userid = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			userid = Int32.Parse(Request.Cookies["UserID"].Value);

			if(!Page.IsPostBack)
			{
				tbl_Custom.Visible = false;
				BindGrid((ddl_LinkmanType.SelectedItem.Value=="staff")?1:2);
				if(ddl_LinkmanType.SelectedItem.Value=="custom")
				{
					BindTypeList();
				}
			}
			
		}

		private void BindTypeList()
		{
			UDS.Components.MyLinkman mylinkman = new UDS.Components.MyLinkman();
			dlt_Type.DataSource = mylinkman.GetCustomLinkmanType();
			dlt_Type.DataKeyField = "ID";
			dlt_Type.DataBind();
		}

		//绑定选择框
		private void BindGrid(int type)
		{
			UDS.Components.Staff staff = new UDS.Components.Staff();
			UDS.Components.CM cm = new UDS.Components.CM();

			if(type==1)
			{

				SqlDataReader dr_staff = staff.GetAllStaffs();
				DataTable dt_staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_staff);
				dt_staff.TableName = "Staff";
				dgrd_List.Visible = true;
				dgrd_Linkman.Visible = false;
				dgrd_List.DataKeyField = "Staff_ID";
				dgrd_List.DataSource = dt_staff.DefaultView;
				dgrd_List.DataBind();
			}
			else if(type==2)
			{
				SqlDataReader dr_linkman = cm.GetLinkmenByClientAddmanID(userid);
				DataTable dt_linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);
				dt_linkman.TableName = "Linkman";
				dgrd_Linkman.Visible = true;
				dgrd_List.Visible = false;
				dgrd_Linkman.DataKeyField = "ID";
				dgrd_Linkman.DataSource = dt_linkman.DefaultView;
				dgrd_Linkman.DataBind();
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
			this.ddl_LinkmanType.SelectedIndexChanged += new System.EventHandler(this.ddl_LinkmanType_SelectedIndexChanged);
			this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
			this.btn_AddList.Click += new System.EventHandler(this.btn_AddList_Click);
			this.dgrd_List.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd_List_PageIndexChanged);
			this.dgrd_List.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgrd_List_ItemDataBound);
			this.dgrd_Linkman.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd_Linkman_PageIndexChanged);
			this.dgrd_Linkman.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgrd_Linkman_ItemDataBound);
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddl_LinkmanType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if((ddl_LinkmanType.SelectedItem.Value=="staff")||(ddl_LinkmanType.SelectedItem.Value=="client"))
			{
				tbl_Select.Visible = true;
				tbl_Custom.Visible = false;
				btn_AddList.Visible = true;
				BindGrid((ddl_LinkmanType.SelectedItem.Value=="staff")?1:2);
				
			}
			else if(ddl_LinkmanType.SelectedItem.Value=="custom")
			{
				tbl_Select.Visible = false;
				tbl_Custom.Visible = true;
				btn_AddList.Visible = false;
				BindTypeList();
			}
		}

		

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			UDS.Components.MyLinkman mylinkman = new UDS.Components.MyLinkman();
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
			
			for(int i = 0;i<dlt_Type.Items.Count;i++)
			{
				if(((CheckBox)dlt_Type.Items[i].Controls[1]).Checked==true)
				{
					clinkman.Type += dlt_Type.DataKeys[i].ToString() + ",";
				}
			}

			mylinkman.AddCustomLinkman(clinkman,userid);

			Response.Write("<script>location.href='ListView.aspx?type=3'</script>");

		}

		private void btn_AddList_Click(object sender, System.EventArgs e)
		{
			string selectedstring = "";
			int type = 0;
			//取得选中的id值
			if(dgrd_List.Visible==true)
			{
				type = 1;
				foreach(DataGridItem dgi in dgrd_List.Items)//找到checkbox control
				{
					for(int i=0;i<dgi.Cells[0].Controls.Count;i++)
					{
						if((dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")&&((CheckBox)dgi.Cells[0].Controls[i]).Checked==true)
						{
							selectedstring += dgrd_List.DataKeys[dgi.ItemIndex] + ",";
						}
					}
				}
			}
			else if(dgrd_Linkman.Visible==true)
			{
				type = 2;
				foreach(DataGridItem dgi in dgrd_Linkman.Items)//找到checkbox control
				{
					for(int i=0;i<dgi.Cells[0].Controls.Count;i++)
					{
						if((dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")&&((CheckBox)dgi.Cells[0].Controls[i]).Checked==true)
						{
							selectedstring += dgrd_Linkman.DataKeys[dgi.ItemIndex] + ",";
						}
					}
				}
			}

			if(selectedstring.IndexOf(",")!=-1)
			{
				selectedstring = selectedstring.Substring(0,selectedstring.Length-1);
				string[] arrids = selectedstring.Split(',');
				for(int i=0;i<arrids.Length;i++)
				{
					UDS.Components.MyLinkman mlinkman = new UDS.Components.MyLinkman();
					mlinkman.AddLinkmanToList(type,Int32.Parse(arrids[i]),userid);
				}
			}
			Response.Write("<script>location.href='ListView.aspx?type="+type+"';</script>");
			

		}

		private void btn_Back_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>location.href='ListView.aspx'</script>");
		}

		private void dgrd_List_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			UDS.Components.MyLinkman mlinkman = new UDS.Components.MyLinkman();
			if(e.Item.ItemIndex!=-1)
			{
				if(mlinkman.HaveInList(1,userid,Int32.Parse(((DataGrid)sender).DataKeys[e.Item.ItemIndex].ToString())))
				{
					for(int i=0;i<e.Item.Cells[0].Controls.Count;i++)
					{
						if(e.Item.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")
						{
							((CheckBox)(e.Item.Cells[0].Controls[i])).Enabled = false;
						}
					}

				}
			}
			

		}

		private void dgrd_Linkman_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			UDS.Components.MyLinkman mlinkman = new UDS.Components.MyLinkman();
			if(e.Item.ItemIndex!=-1)
			{
				if(mlinkman.HaveInList(2,userid,Int32.Parse(((DataGrid)sender).DataKeys[e.Item.ItemIndex].ToString())))
				{
					for(int i=0;i<e.Item.Cells[0].Controls.Count;i++)
					{
						if(e.Item.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")
						{
							((CheckBox)(e.Item.Cells[0].Controls[i])).Enabled = false;
						}
					}

				}
			}
		}

		private void dgrd_List_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			BindGrid(1);
		}

		private void dgrd_Linkman_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			BindGrid(2);
		}

	}
}
