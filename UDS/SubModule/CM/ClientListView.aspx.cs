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

namespace UDS.SubModule.CM
{
	/// <summary>
	/// ClientListView 的摘要说明。
	/// </summary>
	public class ClientListView : System.Web.UI.Page
	{
		#region 控件声明
		protected System.Web.UI.WebControls.DataGrid dgd_Client;
		protected System.Web.UI.WebControls.HyperLink hlk_AddClient;
		protected System.Web.UI.WebControls.LinkButton lbtn_MyClient;
		protected System.Web.UI.WebControls.LinkButton lbtn_coClient;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD2;
		protected System.Web.UI.WebControls.Literal ltl_ClientCount;
		protected System.Web.UI.WebControls.Literal ltl_ContactTimes;
		protected System.Web.UI.WebControls.Panel pnl_ClientInfo;
		protected System.Web.UI.WebControls.Panel pnl;
		protected System.Web.UI.WebControls.DropDownList ddl_MySubordinate;
		protected System.Web.UI.WebControls.Button btn_Del;
		protected System.Web.UI.WebControls.Button btn_AddClient;
		protected System.Web.UI.WebControls.Button btn_AddContact;
		#endregion

		private string username;
		protected System.Web.UI.WebControls.Button btn_AddLinkman;
		private string userid;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				//设置客户权限 默认进入位最高权限'administrator'
				Session["cm_permission"] = "administrator";

				userid = Request.Cookies["UserID"].Value;
                username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				ViewState["userid"] = userid;
				ViewState["username"] = username;
				ViewState["SortField"] = "UpdateTime1";
				ViewState["SortDirect"] =  "DESC";
				ViewState["NowTab"] = "client";
				BindSubordinate();
				BindGrid();	
			}
			else
			{
				userid = ViewState["userid"].ToString();
				username = ViewState["username"].ToString();
			}
			
			
		}

		private void BindSubordinate()
		{
			//绑定下级人员
			UDS.Components.Staff staff = new UDS.Components.Staff();
            SqlDataReader dr_mysubordinate = staff.GetStaffFromPosition(Server.UrlDecode(Request.Cookies["UserName"].Value), 2, 2);
            try
            {
                ddl_MySubordinate.DataSource = dr_mysubordinate;
                ddl_MySubordinate.DataTextField = "realname";
                ddl_MySubordinate.DataValueField = "staff_id";
                ddl_MySubordinate.DataBind();
            }
            finally
            {
                dr_mysubordinate.Close();
            }

//			加入自己
			SqlDataReader dr_me = staff.GetStaffInfo(long.Parse(Request.Cookies["UserID"].Value));
			string myrealname = "";
            try
            {
                while (dr_me.Read())
                {
                    myrealname = dr_me["realname"].ToString();
                }
            }
            finally
            {
                dr_me.Close();
            }
			ListItem listitem = new ListItem();
			listitem.Text = myrealname;
			listitem.Value = Request.Cookies["UserID"].Value;

			ddl_MySubordinate.Items.Add(listitem);

			if(ddl_MySubordinate.Items.Count!=0)
			{
				foreach(ListItem li in ddl_MySubordinate.Items)
				{
					if(li.Value==userid)
						li.Selected = true;
					else
						li.Selected = false;
				}
			}
			else
			{
				ddl_MySubordinate.Visible = false;
			}

			

			
		}

		//绑定我的客户
		private void BindGrid()
		{
			TD1.Attributes["background"] = "../../images/maillistbutton2.gif";
			TD2.Attributes["background"] = "../../images/maillistbutton1.gif";

			UDS.Components.CM cm = new  UDS.Components.CM();
			DataSet ds = new DataSet();

			SqlDataReader dr_Client = cm.GetMyClients(Int32.Parse(userid));
			DataTable dt_Client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Client);
			dt_Client.TableName = "Client";
			ds.Tables.Add(dt_Client);

			SqlDataReader dr_Contact = cm.GetClientContactInfo(0);
			DataTable dt_Contact = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Contact);
			dt_Contact.TableName = "Contact";
			ds.Tables.Add(dt_Contact);
				
			SqlDataReader dr_Linkman = cm.GetAllLinkman();
			DataTable dt_Linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Linkman);
			dt_Linkman.TableName = "Linkman";
			ds.Tables.Add(dt_Linkman);

			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_Staff = staff.GetAllStaffs();
			DataTable dt_Staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Staff);
			dt_Staff.TableName = "Staff";
			ds.Tables.Add(dt_Staff);

			ds.Relations.Add("ClientAddMan_Staff",ds.Tables["Client"].Columns["AddManID"],ds.Tables["Staff"].Columns["Staff_ID"],false);
			ds.Relations.Add("ClientLinkmanID_Linkman",ds.Tables["Client"].Columns["ChiefLinkmanID"],ds.Tables["Linkman"].Columns["ID"],false);


			ds.Tables["Client"].DefaultView.Sort = (string)ViewState["SortField"] + " " + ViewState["SortDirect"];
			dgd_Client.DataSource = ds.Tables["Client"].DefaultView;
			dgd_Client.DataBind();

			DateTime monthbegin = DateTime.Now.AddMonths(-1);
			DateTime monthend = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month));

			SqlDataReader dr_ContactTimes = cm.GetContactByStaffIDandTime(Int32.Parse(userid),monthbegin,monthend);
			int contacttimes = 0;
            try
            {
                while (dr_ContactTimes.Read())
                {
                    contacttimes++;
                }
            }
            finally
            {
                dr_ContactTimes.Close();
            }

			if(Session["cm_permission"].ToString() == "administrator")
			{
				pnl.Visible = true;
				pnl_ClientInfo.Visible = true;
			}
			else
			{
				pnl.Visible = false;
				pnl_ClientInfo.Visible = false;
			}
			//如果没有客户，则 不出现添加 联系人 和 接触情况的 按钮
			if (dgd_Client.Items.Count==0)
			{
				btn_AddLinkman.Visible = false;
				btn_AddContact.Visible = false;
			}
			else
			{
				btn_AddLinkman.Visible = true;
				btn_AddContact.Visible = true;
			}

			ltl_ClientCount.Text = dt_Client.Rows.Count.ToString();
			ltl_ContactTimes.Text = contacttimes.ToString();

		}

		//绑定我的协同客户
		private void BindMycooperatorClient()
		{
			TD2.Attributes["background"] = "../../images/maillistbutton2.gif";
			TD1.Attributes["background"] = "../../images/maillistbutton1.gif";
			pnl_ClientInfo.Visible = false;
			pnl.Visible = false;

			UDS.Components.CM cm = new  UDS.Components.CM();
			DataSet ds = new DataSet();

			SqlDataReader dr_Client = cm.GetClientInfoBycooperatorID(Int32.Parse(userid));
			DataTable dt_Client = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Client);
			dt_Client.TableName = "Client";
			ds.Tables.Add(dt_Client);

			SqlDataReader dr_Contact = cm.GetClientContactInfo(0);
			DataTable dt_Contact = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Contact);
			dt_Contact.TableName = "Contact";
			ds.Tables.Add(dt_Contact);
				
			SqlDataReader dr_Linkman = cm.GetAllLinkman();
			DataTable dt_Linkman = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Linkman);
			dt_Linkman.TableName = "Linkman";
			ds.Tables.Add(dt_Linkman);

			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_Staff = staff.GetAllStaffs();
			DataTable dt_Staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Staff);
			dt_Staff.TableName = "Staff";
			ds.Tables.Add(dt_Staff);

			ds.Relations.Add("ClientAddMan_Staff",ds.Tables["Client"].Columns["AddManID"],ds.Tables["Staff"].Columns["Staff_ID"],false);
			ds.Relations.Add("ClientLinkmanID_Linkman",ds.Tables["Client"].Columns["ChiefLinkmanID"],ds.Tables["Linkman"].Columns["ID"],false);


			ds.Tables["Client"].DefaultView.Sort = (string)ViewState["SortField"] + " " + ViewState["SortDirect"];
			dgd_Client.DataSource = ds.Tables["Client"].DefaultView;
			dgd_Client.DataBind();
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

		private void dgd_Client_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(ViewState["SortDirect"]!=null)
			{
				if(ViewState["SortDirect"].ToString()=="DESC")
					ViewState["SortDirect"] =  "ASC";
				else
					ViewState["SortDirect"] =  "DESC";
			}
			else
				ViewState["SortDirect"] =  "ASC";

			ViewState["SortField"] = (string)e.SortExpression;
			
			if(ViewState["NowTab"].ToString()=="client")
				BindGrid();
			else
				BindMycooperatorClient();
			
		}

		private void dgd_Client_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgd_Client.CurrentPageIndex = e.NewPageIndex;
			if(ViewState["NowTab"].ToString()=="client")
				BindGrid();
			else
				BindMycooperatorClient();

		}

		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dgd_Client.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked)
					selectedID += item.Cells[1].Text.Trim()+",";				
			}
			if(selectedID!="")
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}



        public void btn_AddLinkman_Click(object sender, System.EventArgs e)
		{
			//遍历datagrid得到选中的最后一个checkbox的id
			string selectedstring = GetSelectedItemID("cbx1");
			string [] arrselectedstring = selectedstring.Split(',');
			string id = arrselectedstring[arrselectedstring.GetLength(0)-1];
			Response.Write("<script>javascript:window.open('Linkman.aspx?ClientID="+id+"&from=ClientList','_blank');</script>");
		}

        public void btn_AddContact_Click(object sender, System.EventArgs e)
		{
			//遍历datagrid得到选中的最后一个checkbox的id
			string selectedstring = GetSelectedItemID("cbx1");
			string [] arrselectedstring = selectedstring.Split(',');
			string id = arrselectedstring[arrselectedstring.GetLength(0)-1];
			Response.Write("<script>javascript:window.open('ClientContact_thisWeek.aspx?ClientID="+id+"','_blank');</script>");
		}

        public void btn_AddClient_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>javascript:window.open('Client.aspx','_blank');</script>");
		}

        public void btn_Del_Click(object sender, System.EventArgs e)
		{
			string selectedstring = "";
			foreach(DataGridItem dgi in dgd_Client.Items)
			{
				for(int i=0;i<dgi.Cells[0].Controls.Count;i++)
				{
					if(dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")
					{
						if(((CheckBox)dgi.Cells[0].Controls[i]).Checked==true)
						{
							selectedstring += dgd_Client.DataKeys[dgi.ItemIndex].ToString() + ",";
						}
					}
				}
			}
			if(selectedstring!="")
			{
				UDS.Components.CM cm = new UDS.Components.CM();
				selectedstring = selectedstring.Substring(0,selectedstring.Length-1);
				string[] arrselected = selectedstring.Split(',');
				for(int i=0;i<arrselected.Length;i++)
				{
					if(arrselected[i].Trim()!="")
					{
						cm.DelClient(Int32.Parse(arrselected[i]));
					}
				}
			}
			BindGrid();
		}

		public  void ddl_MySubordinate_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(((DropDownList)sender).SelectedItem.Value==Request.Cookies["UserID"].Value)
			{
				Session["cm_permission"] = "administrator";
				pnl.Visible = true;
				pnl_ClientInfo.Visible = true;
			}
			else
			{
				Session["cm_permission"] = "leader";
				pnl.Visible = false;
				pnl_ClientInfo.Visible = false;
			}

			//改变观察视角
			UDS.Components.Staff staff = new UDS.Components.Staff();
			userid = ddl_MySubordinate.SelectedItem.Value;
			SqlDataReader dr = staff.GetStaffInfo(long.Parse(userid));
            try
            {
                while (dr.Read())
                {
                    username = dr["staff_name"].ToString();
                }
            }
            finally
            {
                
                if (dr != null)
                {

                    dr.Close();
                }
            }

			ViewState["userid"] = userid;
			ViewState["username"] = username;
			//重新绑定
			if(ViewState["NowTab"].ToString()=="client")
				BindGrid();
			else
				BindMycooperatorClient();


		}

		public void lbtn_MyClient_Click(object sender, System.EventArgs e)
		{
			//表示当前用户所在标签
			ViewState["NowTab"] = "client";
 
			BindGrid();

		}

		public void lbtn_coClient_Click(object sender, System.EventArgs e)
		{
			//表示当前用户所在标签
			ViewState["NowTab"] = "cooperator";

			BindMycooperatorClient();
		}

		private void dgd_Client_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(ViewState["NowTab"].ToString()=="cooperator")
			{
				Control ctl = e.Item.FindControl("hlk_ClientName");
				if(e.Item.FindControl("hlk_ClientName")!=null)
					((HyperLink)ctl).Attributes["onclick"] = "alert('你无权查看！');return false;";
				
			}
		}

	}
}
