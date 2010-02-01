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
	/// Linkman 的摘要说明。
	/// </summary>
	public class Linkman : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBox cb_chief;
		protected System.Web.UI.WebControls.TextBox tb_Telephone;
		protected System.Web.UI.WebControls.TextBox tb_Mobile;
		protected System.Web.UI.WebControls.TextBox tb_Name;
		protected System.Web.UI.WebControls.TextBox tb_Position;
		protected System.Web.UI.WebControls.TextBox tb_Email;
		protected System.Web.UI.WebControls.TextBox tb_Description;
		protected System.Web.UI.WebControls.TextBox tb_Address;
		protected System.Web.UI.WebControls.TextBox tb_Family;
		protected System.Web.UI.WebControls.DropDownList ddl_Gender;
		protected System.Web.UI.WebControls.DropDownList ddl_ClientName;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.Button btn_Del;
		
		private string from = "";
		private int clientid = 0;
		private int linkmanid = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				clientid = ((Request.QueryString["ClientID"]==null)||(Request.QueryString["ClientID"].Trim()==""))?0:Int32.Parse(Request.QueryString["ClientID"].ToString());
				linkmanid = ((Request.QueryString["LinkmanID"]==null)||(Request.QueryString["LinkmanID"].Trim()==""))?0:Int32.Parse(Request.QueryString["LinkmanID"].ToString());
				from = (Request.QueryString["From"]==null)?"":Request.QueryString["From"];
				ViewState["LinkmanID"] = linkmanid.ToString();
				BindData();

				if(Session["cm_permission"].ToString() == "leader")
					btn_OK.Visible = false;
			}
			else
			{
				linkmanid = Int32.Parse(ViewState["LinkmanID"].ToString());
				clientid = Int32.Parse(ddl_ClientName.SelectedItem.Value);
			}
			if(linkmanid==0)
			{
				btn_OK.Text = "添加";
				btn_Del.Visible = false;
			}
			else
			{
				btn_OK.Text = "修改";
				btn_Del.Visible = true;
			}

			btn_Del.Attributes["onclick"] = "return confirm('确定要删除吗?')";


		}

		private void BindData()
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			UDS.Components.ClientInfo client = new UDS.Components.ClientInfo();
			UDS.Components.Linkman linkman = new UDS.Components.Linkman();

			if(linkmanid!=0)
			{
				linkman = cm.GetLinkmanStructByID(linkmanid.ToString());
				clientid = linkman.ClientID;
			}
			else
			{
				
			}

			SqlDataReader dr = null;
            try
            {
                //dr = cm.GetClientInfo(clientid);
                dr = cm.GetMyClients(Int32.Parse(Request.Cookies["UserID"].Value));
                client = cm.GetClientAllInfo(clientid);
                //绑定客户下拉列表
                ddl_ClientName.DataSource = dr;
                ddl_ClientName.DataTextField = "Name";
                ddl_ClientName.DataValueField = "id";
                ddl_ClientName.DataBind();
            }
            finally
            {
                
                if (dr != null)
                {

                    dr.Close();
                }
            }
			if((clientid==0)&&(from)!="ClientList")
				ddl_ClientName.Items.Insert(0,new ListItem("当前客户","0"));
			else
			{
				//使传入的clientid处于选中状态
				foreach(ListItem lt in ddl_ClientName.Items)
				{
					if(lt.Value==clientid.ToString())
					{
						lt.Selected = true;
					}
				}
			}
			

			dr.Close();
			if(linkmanid==client.ChiefLinkmanID) cb_chief.Checked = true;
			//填充联系人信息
			dr = cm.GetLinkmanByID(linkmanid.ToString());
			while(dr.Read())
			{
				tb_Name.Text = dr["Name"].ToString();
				tb_Mobile.Text = dr["Mobile"].ToString();
				tb_Telephone.Text = dr["Telephone"].ToString();
				tb_Position.Text = dr["Position"].ToString();
				tb_Email.Text = dr["Email"].ToString();
				//填充性别
				if(Convert.ToBoolean(dr["gender"])==true) 
				{
					ddl_Gender.Items[0].Selected = true;
					ddl_Gender.Items[1].Selected = false;
				}
				else
				{
					ddl_Gender.Items[0].Selected = false;
					ddl_Gender.Items[1].Selected = true;
				}

				tb_Description.Text = dr["description"].ToString();
				tb_Address.Text = dr["address"].ToString();
				tb_Family.Text = dr["family"].ToString();

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
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			UDS.Components.Linkman linkman = new UDS.Components.Linkman();
			linkman.ClientID = clientid;
			linkman.Address = tb_Address.Text;
			linkman.Description = tb_Description.Text;
			linkman.Email = tb_Email.Text;
			linkman.Family = tb_Family.Text;
			linkman.Gender = (ddl_Gender.SelectedItem.Value=="1")?true:false;
			linkman.Mobile = tb_Mobile.Text;
			linkman.Name = tb_Name.Text;
			linkman.Position = tb_Position.Text;
			linkman.Telephone = tb_Telephone.Text;
			linkman.ID = linkmanid;
			try
			{
				if(linkmanid!=0) //修改信息
				{
					if(cb_chief.Checked)
					{
						UDS.Components.ClientInfo clientinfo = cm.GetClientAllInfo(clientid);
						clientinfo.ChiefLinkmanID = linkman.ID;
						cm.UpdateClient(clientinfo);
					}
					else
					{
						UDS.Components.ClientInfo clientinfo = cm.GetClientAllInfo(clientid);
						clientinfo.ChiefLinkmanID = 0;
						cm.UpdateClient(clientinfo);
					}
					cm.UpdateLinkman(linkman);
				}
				else //添加联系人
				{
					//如果选择了客户则添加联系人并且修改该客户的主要联系人
					if(clientid!=0)
					{
						linkman.ID = cm.AddLinkman(linkman);
						if(cb_chief.Checked)
						{
							UDS.Components.ClientInfo clientinfo = cm.GetClientAllInfo(clientid);
							clientinfo.ChiefLinkmanID = linkman.ID;
							cm.UpdateClient(clientinfo);
						}
						
						Response.Write("<script>if(opener!=null) opener.location.href=opener.location.href;</script>");
					}
					else//如果没有选择客户则联系人保存为临时状态即id=0
					{
						string strlinkmanid = cm.AddLinkman(linkman).ToString();
						Session["tmplinkmanid"] += strlinkmanid + ",";
						if(cb_chief.Checked)	Session["tmpchief"] = strlinkmanid;
						Response.Write("<script>if(opener!=null) opener.location.href=opener.location.href;</script>");
					}
					Response.Write("<script>window.close();</script>");
				}
				
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.Message);
				Server.Transfer("../Error.aspx");
			}
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			UDS.Components.Linkman linkman = new UDS.Components.Linkman();
			linkman.ID = linkmanid;
			if(cm.DelLinkman(linkman))
			{
				Response.Write("<script>if(opener!=null) opener.location.href=opener.location.href;alert('删除成功!');window.close();</script>");
			}
		}
	}
}
