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
	/// ListView 的摘要说明。
	/// </summary>
	public class ListView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbtn_Staff;
		protected System.Web.UI.WebControls.LinkButton lbtn_Client;
		protected System.Web.UI.WebControls.LinkButton lbtn_Custom;
		protected System.Web.UI.WebControls.HyperLink lbtn_AddLinkman;
		protected System.Web.UI.WebControls.DataGrid dgrd_StaffLinkman;
		protected System.Web.UI.WebControls.DataGrid dgrd_ClientLinkman;
		protected System.Web.UI.WebControls.DataGrid dgrd_CustomLinkman;
		protected System.Web.UI.WebControls.Button btn_Del;
		protected System.Web.UI.WebControls.DropDownList ddl_CustomLinkmanType;
		protected System.Web.UI.HtmlControls.HtmlTableCell td_Staff;
		protected System.Web.UI.HtmlControls.HtmlTableCell td_Client;
		protected System.Web.UI.HtmlControls.HtmlTableCell td_Custom;
		protected System.Web.UI.HtmlControls.HtmlTableCell td_Add;
	
		private int userid = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			userid = Int32.Parse(Request.Cookies["UserID"].Value);

			if(!Page.IsPostBack)
			{
				Session["cm_permission"] = "administrator";
				int type = (Request.QueryString["type"]==null)?1:Int32.Parse(Request.QueryString["type"]);
				GridBind(type);
			}
		}

		private void GridBind(int type)
		{
			UDS.Components.MyLinkman linkman = new UDS.Components.MyLinkman();
			SqlDataReader dr_linkman = linkman.GetMyLinkman(type,userid);
			DataTable dt_linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);
			dt_linkman.TableName = "Linkman";
			DataSet ds = new DataSet();
			ds.Tables.Add(dt_linkman);
			switch(type)
			{
				case 1:
					dgrd_StaffLinkman.Visible = true;
					dgrd_ClientLinkman.Visible = false;
					dgrd_CustomLinkman.Visible = false;

					td_Staff.Attributes["background"]= "../../images/maillistbutton2.gif";
					td_Client.Attributes["background"]= "../../images/maillistbutton1.gif";
					td_Custom.Attributes["background"]= "../../images/maillistbutton1.gif";

					dgrd_StaffLinkman.DataSource = dt_linkman.DefaultView;
					dgrd_StaffLinkman.DataKeyField = "Staff_ID";
					dgrd_StaffLinkman.DataBind();
					break;
				case 2:
					dgrd_StaffLinkman.Visible = false;
					dgrd_ClientLinkman.Visible = true;
					dgrd_CustomLinkman.Visible = false;

					td_Staff.Attributes["background"]= "../../images/maillistbutton1.gif";
					td_Client.Attributes["background"]= "../../images/maillistbutton2.gif";
					td_Custom.Attributes["background"]= "../../images/maillistbutton1.gif";

					dgrd_ClientLinkman.DataSource = dt_linkman.DefaultView;
					dgrd_ClientLinkman.DataKeyField = "ID";
					dgrd_ClientLinkman.DataBind();
					break;
				case 3:
					dgrd_StaffLinkman.Visible = false;
					dgrd_ClientLinkman.Visible = false;
					dgrd_CustomLinkman.Visible = true;

					td_Staff.Attributes["background"]= "../../images/maillistbutton1.gif";
					td_Client.Attributes["background"]= "../../images/maillistbutton1.gif";
					td_Custom.Attributes["background"]= "../../images/maillistbutton2.gif";

					dgrd_CustomLinkman.DataSource = dt_linkman.DefaultView;
					dgrd_CustomLinkman.DataKeyField = "ID";
					dgrd_CustomLinkman.DataBind();
					break;
			}
			

		}


		private void GridCustomLinkmanByType(int type)
		{
			UDS.Components.MyLinkman linkman = new UDS.Components.MyLinkman();
			SqlDataReader dr_linkman = linkman.GetCustomLinkmanByType(type,userid);
			DataTable dt_linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_linkman);
			dgrd_CustomLinkman.DataSource = dt_linkman.DefaultView;
			dgrd_CustomLinkman.DataBind();

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
			this.ddl_CustomLinkmanType.SelectedIndexChanged += new System.EventHandler(this.ddl_CustomLinkmanType_SelectedIndexChanged);
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			this.lbtn_Staff.Click += new System.EventHandler(this.lbtn_Click);
			this.lbtn_Client.Click += new System.EventHandler(this.lbtn_Click);
			this.lbtn_Custom.Click += new System.EventHandler(this.lbtn_Click);
			this.dgrd_CustomLinkman.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd_CustomLinkman_PageIndexChanged);
			this.dgrd_ClientLinkman.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd_ClientLinkman_PageIndexChanged);
			this.dgrd_StaffLinkman.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd_StaffLinkman_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbtn_Click(object sender, System.EventArgs e)
		{

			if(((Control)sender).ID=="lbtn_Custom")
				ddl_CustomLinkmanType.Visible = true;
			else
				ddl_CustomLinkmanType.Visible = false;
			BindTypeList();

			GridBind(Int32.Parse(((LinkButton)sender).CommandArgument));
			switch(Int32.Parse(((LinkButton)sender).CommandArgument))
			{
				case 1:
					dgrd_StaffLinkman.Visible = true;
					dgrd_ClientLinkman.Visible = false;
					dgrd_CustomLinkman.Visible = false;
					break;
				case 2:
					dgrd_StaffLinkman.Visible = false;
					dgrd_ClientLinkman.Visible = true;
					dgrd_CustomLinkman.Visible = false;
					break;
				case 3:
					dgrd_StaffLinkman.Visible = false;
					dgrd_ClientLinkman.Visible = false;
					dgrd_CustomLinkman.Visible = true;
					break;
			}
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			string selectedstring = "";
			int type = 0;
			UDS.Components.MyLinkman mlinkman = new UDS.Components.MyLinkman();

			if(dgrd_StaffLinkman.Visible==true)
			{
				type = 1;
				//得到选中的checkbox的id
				foreach(DataGridItem dgi in dgrd_StaffLinkman.Items)//找到checkbox control
				{
					for(int i=0;i<dgi.Cells[0].Controls.Count;i++)
					{
						if((dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")&&((CheckBox)dgi.Cells[0].Controls[i]).Checked==true)
						{
							selectedstring += dgrd_StaffLinkman.DataKeys[dgi.ItemIndex] + ",";
						}
					}
				}
			}
			else if(dgrd_ClientLinkman.Visible==true)
			{
				type = 2;
				foreach(DataGridItem dgi in dgrd_ClientLinkman.Items)//找到checkbox control
				{
					for(int i=0;i<dgi.Cells[0].Controls.Count;i++)
					{
						if((dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")&&((CheckBox)dgi.Cells[0].Controls[i]).Checked==true)
						{
							selectedstring += dgrd_ClientLinkman.DataKeys[dgi.ItemIndex] + ",";
						}
					}
				}
			
			}
			else if(dgrd_CustomLinkman.Visible==true)
			{
				type = 3;
				foreach(DataGridItem dgi in dgrd_CustomLinkman.Items)//找到checkbox control
				{
					for(int i=0;i<dgi.Cells[0].Controls.Count;i++)
					{
						if((dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")&&((CheckBox)dgi.Cells[0].Controls[i]).Checked==true)
						{
							selectedstring += dgrd_CustomLinkman.DataKeys[dgi.ItemIndex] + ",";
						}
					}
				}

			}
			
			if(selectedstring.IndexOf(",")!=-1)
			{
				selectedstring = selectedstring.Substring(0,selectedstring.Length-1);
				string[] arrselected = selectedstring.Split(',');
				for(int i=0;i<arrselected.Length;i++)
				{
					if(arrselected[i].Trim()!="")
					{
						mlinkman.DelLinkmanFromList(type,Int32.Parse(arrselected[i]));
					}
				}
				GridBind(type);
			}
			
		}

		//bound to customlinkmantype
		private void BindTypeList()
		{
			UDS.Components.MyLinkman mylinkman = new UDS.Components.MyLinkman();
			ddl_CustomLinkmanType.DataSource = mylinkman.GetCustomLinkmanType();
			ddl_CustomLinkmanType.DataValueField = "ID";
			ddl_CustomLinkmanType.DataTextField = "type";
			ddl_CustomLinkmanType.DataBind();
			ddl_CustomLinkmanType.Items.Insert(0,new ListItem("全部","all"));
		}

		private void dgrd_StaffLinkman_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			GridBind(1);
		}

		private void dgrd_ClientLinkman_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			GridBind(2);
		}

		private void dgrd_CustomLinkman_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			if(ddl_CustomLinkmanType.SelectedItem.Value=="all")
				GridBind(3);
			else
				GridCustomLinkmanByType(Int32.Parse(ddl_CustomLinkmanType.SelectedItem.Value));
		}

		private void ddl_CustomLinkmanType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dgrd_CustomLinkman.CurrentPageIndex = 0;
			if(((DropDownList)sender).SelectedItem.Value!="all")
				GridCustomLinkmanByType(Int32.Parse(ddl_CustomLinkmanType.SelectedItem.Value));
			else
				GridBind(3);
		}
	}
}
