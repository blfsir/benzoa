using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;

namespace UDS.SubModule.CM
{
	/// <summary>
	/// Clinet 的摘要说明。
	/// </summary>
	public class Client : System.Web.UI.Page
	{
		#region 声明
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.TextBox tbx_introduce;
		protected System.Web.UI.WebControls.Panel pnl_Client;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Repeater rpt_Attachment;
		protected System.Web.UI.WebControls.Literal ltl_ID;
		protected System.Web.UI.WebControls.TextBox tbx_Birthday;
		protected System.Web.UI.WebControls.TextBox tbx_ShortName;
		protected System.Web.UI.WebControls.TextBox tbx_Name;
		protected System.Web.UI.WebControls.CheckBox cbx_zhongduan;
		protected System.Web.UI.WebControls.CheckBox cbx_qudao;
		protected System.Web.UI.WebControls.CheckBox cbx_shehui;
		protected System.Web.UI.WebControls.CheckBox cbx_meiti;
		protected System.Web.UI.WebControls.Label lbl_position;
		protected System.Web.UI.WebControls.Label lbl_chieftel;
		protected System.Web.UI.WebControls.TextBox tbx_UpdateTime;
		protected System.Web.UI.WebControls.Literal ltl_AddManName;
		protected System.Web.UI.WebControls.Literal ltl_addmantel;
		protected System.Web.UI.WebControls.TextBox tbx_affiliatedarea;
		protected System.Web.UI.WebControls.TextBox tbx_URL;
		protected System.Web.UI.WebControls.TextBox tbx_zip;
		protected System.Web.UI.WebControls.TextBox tbx_address;
		protected System.Web.UI.WebControls.CheckBox cbx_realestate;
		protected System.Web.UI.WebControls.CheckBox cbx_IT;
		protected System.Web.UI.WebControls.CheckBox cbx_business;
		protected System.Web.UI.WebControls.CheckBox cbx_telecom;
		protected System.Web.UI.WebControls.CheckBox cbx_post;
		protected System.Web.UI.WebControls.CheckBox cbx_consultation;
		protected System.Web.UI.WebControls.CheckBox cbx_travel;
		protected System.Web.UI.WebControls.CheckBox cbx_bus;
		protected System.Web.UI.WebControls.CheckBox cbx_stock;
		protected System.Web.UI.WebControls.CheckBox cbx_insurance;
		protected System.Web.UI.WebControls.CheckBox cbx_tax;
		protected System.Web.UI.WebControls.CheckBox cbx_make;
		protected System.Web.UI.WebControls.CheckBox cbx_electric;
		protected System.Web.UI.WebControls.CheckBox cbx_clothe;
		protected System.Web.UI.WebControls.CheckBox cbx_food;
		protected System.Web.UI.WebControls.CheckBox cbx_medicine;
		protected System.Web.UI.WebControls.CheckBox cbx_mechanism;
		protected System.Web.UI.WebControls.CheckBox cbx_auto;
		protected System.Web.UI.WebControls.TextBox tbx_staffnumber;
		protected System.Web.UI.WebControls.TextBox tbx_money;
		protected System.Web.UI.WebControls.TextBox tbx_operation;
		protected System.Web.UI.WebControls.TextBox tbx_IT;
		protected System.Web.UI.WebControls.TextBox tbx_pcnumber;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.CheckBox cbx_LAN;
		protected System.Web.UI.WebControls.CheckBox cbx_WAN;
		protected System.Web.UI.WebControls.CheckBox cbx_internet;
		protected System.Web.UI.WebControls.TextBox tbx_ITStaffs;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox tbx_ITdepartment;
		protected System.Web.UI.WebControls.TextBox tbx_principal;
		protected System.Web.UI.WebControls.TextBox tbx_system;
		protected System.Web.UI.WebControls.CheckBox cbx_sellman;
		protected System.Web.UI.WebControls.CheckBox cbx_just;
		protected System.Web.UI.WebControls.CheckBox cbx_introduce;
		protected System.Web.UI.WebControls.CheckBox cbx_customer;
		protected System.Web.UI.WebControls.CheckBox cbx_Email;
		protected System.Web.UI.WebControls.CheckBox cbx_media;
		protected System.Web.UI.WebControls.CheckBox cbx_Web;
		protected System.Web.UI.WebControls.CheckBox cbx_proseminar;
		protected System.Web.UI.WebControls.CheckBox cbx_exhibition;
		protected System.Web.UI.WebControls.CheckBox cbx_EMS;
		protected System.Web.UI.WebControls.Panel penal;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
		protected System.Web.UI.WebControls.CheckBox cbx_market;
		protected System.Web.UI.WebControls.CheckBox cbx_foreign;
		protected System.Web.UI.WebControls.CheckBox cbx_private;
		protected System.Web.UI.WebControls.CheckBox cbx_stateowned;
		protected System.Web.UI.WebControls.CheckBox cbx_government;
		protected System.Web.UI.WebControls.Button btn_AddContact;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.DropDownList ddl_AddMan;
		protected System.Web.UI.WebControls.Panel pnl_Leader;
		protected System.Web.UI.WebControls.Button btn_LookTel;
		protected System.Web.UI.WebControls.Button btn_ChangeAddMan;
		protected System.Web.UI.WebControls.Panel pnl_MyCustom;
		protected System.Web.UI.WebControls.Panel pnl_Leader1;
		protected System.Web.UI.WebControls.Button btn_LookContact;
		protected System.Web.UI.WebControls.Label lbl_Message;
		#endregion
		protected System.Web.UI.WebControls.HyperLink hlk_Chiefman;

		protected int clientid;

		private void Page_Load(object sender, System.EventArgs e)
		{
			UDS.Components.CM cm = new UDS.Components.CM();

			if(!Page.IsPostBack)
			{
				tbx_UpdateTime.Text = DateTime.Now.ToShortDateString();
				//得到添加人的信息
                UDS.Components.Staff staff = new UDS.Components.Staff();

				#region 显示客户原有信息
				UDS.Components.ClientInfo client = cm.GetClientAllInfo((Request.QueryString["ClientID"]==null)?0:Int32.Parse(Request.QueryString["ClientID"].ToString()));
				ViewState["ClientID"] = client.ID;
				clientid = client.ID;

				/* 权限判断
				 * 如果是上级则出现下拉菜单，并可重新指定客户经理
				 * 其它则无下拉菜单
				 */
				if(Session["cm_permission"].ToString()=="leader")
				{
					//绑定下拉列表
					pnl_Leader.Visible = true;
					ltl_AddManName.Visible = ltl_addmantel.Visible = false;
					//不出现修改按钮
					pnl_MyCustom.Visible = false;
					pnl_Leader1.Visible = true;

					BindAddManList();
					//添加人默认选中
					ddl_AddMan.Items.FindByValue(client.AddManID.ToString()).Selected = true;
				}
				else
				{
					pnl_Leader.Visible = false;
					ltl_AddManName.Visible = ltl_addmantel.Visible = true;
					SqlDataReader dr_staff = null;
                    try
                    {
                        if (client.ID != 0)
                        {
                            dr_staff = staff.GetStaffInfo(client.AddManID);
                            while (dr_staff.Read())
                            {
                                ltl_AddManName.Text = dr_staff["realname"].ToString();
                                ltl_addmantel.Text = dr_staff["Mobile"].ToString();
                            }
                        }
                        else
                        {
                            dr_staff = staff.GetStaffInfo(Int32.Parse(Request.Cookies["UserID"].Value));
                            while (dr_staff.Read())
                            {
                                ltl_AddManName.Text = dr_staff["realname"].ToString();
                                ltl_addmantel.Text = dr_staff["Mobile"].ToString();
                            }
                        }
                    }
                    finally
                    {
                        dr_staff.Close();
                        dr_staff.Dispose();
                    }
				}
				

				ltl_ID.Text = (client.ID.ToString()=="0")?"":client.ID.ToString();
				tbx_ShortName.Text = client.ClientShortName;
				tbx_Name.Text = client.ClientName;
				if(clientid!=0)
					tbx_Birthday.Text = client.Birthday.ToShortDateString();
				else
					tbx_Birthday.Text = DateTime.Now.ToShortDateString();

				if(client.ClientType.IndexOf(ClientType.terminal.ToString())>=0) cbx_zhongduan.Checked = true;
				if(client.ClientType.IndexOf(ClientType.channal.ToString())>=0) cbx_qudao.Checked = true;
				if(client.ClientType.IndexOf(ClientType.social.ToString())>=0) cbx_shehui.Checked = true;
				if(client.ClientType.IndexOf(ClientType.media.ToString())>=0) cbx_meiti.Checked = true;
				//得到主要联系人的信息
				SqlDataReader dr_chief = cm.GetLinkmanByID(client.ChiefLinkmanID.ToString());
                try
                {
                    while (dr_chief.Read())
                    {

                        if (Session["cm_permission"].ToString() == "administrator")
                        {
                            hlk_Chiefman.Text = dr_chief["name"].ToString();
                            hlk_Chiefman.NavigateUrl = "Linkman.aspx?LinkmanID=" + dr_chief["id"].ToString();
                            hlk_Chiefman.Target = "_blank";
                        }
                        else
                        {
                            hlk_Chiefman.Text = dr_chief["name"].ToString();
                        }

                        lbl_position.Text = dr_chief["position"].ToString();
                        lbl_chieftel.Text = dr_chief["telephone"].ToString();
                    }
                }
                finally
                {

                    dr_chief.Close();
                    dr_chief.Dispose();
                }
				tbx_affiliatedarea.Text = client.Affiliatedarea;
				tbx_URL.Text = client.URL;
				tbx_zip.Text = client.ZIP;
				tbx_address.Text = client.Address;

				if(client.CompanyProperty.IndexOf(EnterpriseType.government.ToString())>=0) cbx_government.Checked = true;
				if(client.CompanyProperty.IndexOf(EnterpriseType.contry.ToString())>=0) cbx_stateowned.Checked = true;
				if(client.CompanyProperty.IndexOf(EnterpriseType.privateowned.ToString())>=0) cbx_private.Checked = true;
				if(client.CompanyProperty.IndexOf(EnterpriseType.oversea.ToString())>=0) cbx_foreign.Checked = true;
				if(client.CompanyProperty.IndexOf(EnterpriseType.stock.ToString())>=0) cbx_market.Checked = true;

				if(client.ClientTrade.IndexOf(ClientTrade.realty.ToString())>=0) cbx_realestate.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.IT.ToString())>=0) cbx_IT.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.business.ToString())>=0) cbx_business.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.telecom.ToString())>=0) cbx_telecom.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.post.ToString())>=0) cbx_post.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.refer.ToString())>=0) cbx_consultation.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.travel.ToString())>=0) cbx_travel.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.bus.ToString())>=0) cbx_bus.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.stock.ToString())>=0) cbx_stock.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.insurance.ToString())>=0) cbx_insurance.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.tax.ToString())>=0) cbx_tax.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.make.ToString())>=0) cbx_make.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.he.ToString())>=0) cbx_electric.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.clothe.ToString())>=0) cbx_clothe.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.food.ToString())>=0) cbx_food.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.medicine.ToString())>=0) cbx_medicine.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.mechanism.ToString())>=0) cbx_mechanism.Checked = true;
				if(client.ClientTrade.IndexOf(ClientTrade.auto.ToString())>=0) cbx_auto.Checked = true;

				tbx_staffnumber.Text = client.CompanySize;
				tbx_money.Text = client.Money;
				tbx_operation.Text = client.Operation;
				tbx_introduce.Text = client.Introduce;
				tbx_IT.Text = client.ITGrade;
				tbx_pcnumber.Text = client.PCNumber.ToString();
				
				if(client.Net.IndexOf(ClientNet.LAN.ToString())>=0) cbx_LAN.Checked = true;
				if(client.Net.IndexOf(ClientNet.WAN.ToString())>=0) cbx_WAN.Checked = true;
				if(client.Net.IndexOf(ClientNet.INTERNET.ToString())>=0) cbx_internet.Checked = true;

				tbx_ITStaffs.Text = client.ITStaffs.ToString();
				tbx_ITdepartment.Text = client.ITDepartment;
				tbx_principal.Text = client.Principal;
				tbx_system.Text = client.System;

				if(client.ClientSource.IndexOf(ClientSource.sellman.ToString())>=0) cbx_sellman.Checked = true;
				if(client.ClientSource.IndexOf(ClientSource.familiar.ToString())>=0) cbx_just.Checked = true;
				if(client.ClientSource.IndexOf(ClientSource.introduce.ToString())>=0) cbx_introduce.Checked = true;
				if(client.ClientSource.IndexOf(ClientSource.client.ToString())>=0) cbx_customer.Checked = true;

				if(client.ClientInitiative.IndexOf(ClientInitiative.media.ToString())>=0) cbx_media.Checked = true;
				if(client.ClientInitiative.IndexOf(ClientInitiative.searchweb.ToString())>=0) cbx_Web.Checked = true;
				if(client.ClientInitiative.IndexOf(ClientInitiative.proseminar.ToString())>=0) cbx_proseminar.Checked = true;
				if(client.ClientInitiative.IndexOf(ClientInitiative.exhibition.ToString())>=0) cbx_exhibition.Checked = true;
				if(client.ClientInitiative.IndexOf(ClientInitiative.post.ToString())>=0) cbx_EMS.Checked = true;
				if(client.ClientInitiative.IndexOf(ClientInitiative.email.ToString())>=0) cbx_Email.Checked = true;
				#endregion

				if(clientid==0)
				{
					btn_OK.Text = "添加";
					CustomValidator1.Enabled = true;
				}
				else
				{
					btn_OK.Text = "修改";
					CustomValidator1.Enabled = false;
				}

				penal.Visible = cbx_customer.Checked;
			}
			else
			{
				clientid = Int32.Parse(ViewState["ClientID"].ToString());

				//显示联系人
				string tmplinkmanid1 = (Session["tmplinkmanid"]==null)?"":Session["tmplinkmanid"].ToString();
				foreach(string linkmanid in tmplinkmanid1.Split(','))
				{
					if(linkmanid.Trim()!="")
					{
						UDS.Components.Linkman linkman = new UDS.Components.Linkman();
						UDS.Components.CM cm1 = new UDS.Components.CM();
						linkman = cm1.GetLinkmanStructByID(linkmanid);
						
						if(Session["cm_permission"].ToString()=="administrator")
						{
							hlk_Chiefman.Text = linkman.Name;
							hlk_Chiefman.NavigateUrl = "Linkman.aspx?LinkmanID=" + linkman.ID;
							hlk_Chiefman.Target = "_blank";
						}
						else
						{
							hlk_Chiefman.Text = linkman.Name;;
						}
						
						lbl_position.Text = linkman.Position;
						lbl_chieftel.Text = linkman.Telephone;
					}
				}
			}

			if(clientid!=0)
			{
				rpt_Attachment.DataSource = cm.GetAttachmentByClientID(clientid);
				rpt_Attachment.DataBind();
			}

			if(clientid==0) 
				btn_AddContact.Visible = false;
			else
				btn_AddContact.Visible = true;
			
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
			this.CustomValidator1.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.CustomValidator1_ServerValidate);
			this.tbx_ShortName.TextChanged += new System.EventHandler(this.tbx_ShortName_TextChanged);
			this.btn_LookTel.Click += new System.EventHandler(this.btn_LookTel_Click);
			this.btn_ChangeAddMan.Click += new System.EventHandler(this.btn_ChangeAddMan_Click);
			this.cbx_customer.CheckedChanged += new System.EventHandler(this.cbx_customer_CheckedChanged);
			this.cbx_customer.PreRender += new System.EventHandler(this.cbx_customer_PreRender);
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.btn_AddContact.Click += new System.EventHandler(this.btn_AddContact_Click);
			this.btn_LookContact.Click += new System.EventHandler(this.btn_LookContact_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//绑定添加人下拉菜单
		private void BindAddManList()
		{
			UDS.Components.Staff staff = new UDS.Components.Staff();
            ddl_AddMan.DataSource = staff.GetStaffFromPosition(Server.UrlDecode(Request.Cookies["UserName"].Value), 2, 3);
			ddl_AddMan.DataTextField = "realname";
			ddl_AddMan.DataValueField = "staff_id";
			ddl_AddMan.DataBind();
			SqlDataReader dr_staff = staff.GetStaffInfo(long.Parse(Request.Cookies["UserID"].Value));
			string myrealname = "";
            try
            {
                while (dr_staff.Read())
                {
                    myrealname = dr_staff["realname"].ToString();
                }
            }
            finally
            {
                dr_staff.Close();
                dr_staff.Dispose();
            }
			ddl_AddMan.Items.Add(new ListItem(myrealname,Request.Cookies["UserID"].Value));
		}

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			UDS.Components.ClientInfo client = cm.GetClientAllInfo(clientid);
			if(Page.IsValid)
			{
				#region 填充client结构
				client.ClientShortName = tbx_ShortName.Text;
				client.ClientName = tbx_Name.Text;
				client.AddManID = Int32.Parse(Request.Cookies["UserID"].Value);
				client.UpdateTime = DateTime.Parse(tbx_UpdateTime.Text);
				client.Affiliatedarea = tbx_affiliatedarea.Text;
				client.URL = tbx_URL.Text;
				client.ZIP = tbx_zip.Text;
				client.Address = tbx_address.Text;
				client.Type = "";

				if(cbx_zhongduan.Checked)
				{
					client.Type += ClientType.terminal.ToString() + ",";
				}
				if(cbx_qudao.Checked)
				{
					client.Type += ClientType.channal.ToString() + ",";
				}
				if(cbx_shehui.Checked)
				{
					client.Type += ClientType.social.ToString() + ",";
				}
				if(cbx_meiti.Checked)
				{
					client.Type += ClientType.media.ToString() + ",";
				}

				client.EnterpriseType = "";
				if(cbx_government.Checked)
				{
					client.EnterpriseType += EnterpriseType.government.ToString() + ",";
				}
				if(cbx_stateowned.Checked)
				{
					client.EnterpriseType += EnterpriseType.contry.ToString() + ",";
				}
				if(cbx_private.Checked)
				{
					client.EnterpriseType += EnterpriseType.privateowned.ToString() + ",";
				}
				if(cbx_foreign.Checked)
				{
					client.EnterpriseType += EnterpriseType.oversea.ToString() + ",";
				}

				if(cbx_market.Checked) client.EnterpriseType += EnterpriseType.stock.ToString() + ",";

				client.Calling = "";
				if(cbx_realestate.Checked) client.Calling += ClientTrade.realty.ToString() + ",";
				if(cbx_IT.Checked) client.Calling += ClientTrade.IT.ToString() + ",";
				if(cbx_business.Checked) client.Calling += ClientTrade.business.ToString() + ",";
				if(cbx_telecom.Checked) client.Calling += ClientTrade.telecom.ToString() + ",";
				if(cbx_post.Checked) client.Calling += ClientTrade.post.ToString() + ",";
				if(cbx_consultation.Checked) client.Calling += ClientTrade.refer.ToString() + ",";
				if(cbx_travel.Checked) client.Calling += ClientTrade.travel.ToString() + ",";
				if(cbx_bus.Checked) client.Calling += ClientTrade.bus.ToString() + ",";
				if(cbx_stock.Checked) client.Calling += ClientTrade.stock.ToString() + ",";
				if(cbx_insurance.Checked) client.Calling += ClientTrade.insurance.ToString() + ",";
				if(cbx_tax.Checked) client.Calling += ClientTrade.tax.ToString() + ",";
				if(cbx_make.Checked) client.Calling += ClientTrade.make.ToString() + ",";
				if(cbx_electric.Checked) client.Calling += ClientTrade.he.ToString() + ",";
				if(cbx_clothe.Checked) client.Calling += ClientTrade.clothe.ToString() + ",";
				if(cbx_food.Checked) client.Calling += ClientTrade.food.ToString() + ",";
				if(cbx_medicine.Checked) client.Calling += ClientTrade.medicine.ToString() + ",";
				if(cbx_mechanism.Checked) client.Calling += ClientTrade.mechanism.ToString() + ",";
				if(cbx_auto.Checked) client.Calling += ClientTrade.auto.ToString() + ",";

				client.CompanySize = tbx_staffnumber.Text;
				client.Money = tbx_money.Text;
				client.Operation = tbx_operation.Text;
				client.Introduce = tbx_introduce.Text;
				client.ITGrade = tbx_IT.Text;
				client.PCNumber = Int32.Parse(tbx_pcnumber.Text);

				client.Net = "";
				if(cbx_LAN.Checked) client.Net += ClientNet.LAN.ToString() + ",";
				if(cbx_WAN.Checked)  client.Net += ClientNet.WAN.ToString() + ",";
				if(cbx_internet.Checked) client.Net += ClientNet.INTERNET.ToString() + ",";
				client.ITStaffs = Int32.Parse(tbx_ITStaffs.Text);
				client.ITDepartment = tbx_ITdepartment.Text;
				client.Principal = tbx_principal.Text;
				client.System = tbx_system.Text;

				client.ClientSource = "";
				if(cbx_sellman.Checked) client.ClientSource += ClientSource.sellman + ",";
				if(cbx_just.Checked)  client.ClientSource += ClientSource.familiar + ",";
				if(cbx_introduce.Checked)  client.ClientSource += ClientSource.introduce + ",";
				if(cbx_customer.Checked)  client.ClientSource += ClientSource.client + ",";

				client.ClientInitiative = "";
				if(cbx_media.Checked) client.ClientInitiative += ClientInitiative.media + ",";
				if(cbx_Web.Checked) client.ClientInitiative += ClientInitiative.searchweb + ",";
				if(cbx_proseminar.Checked) client.ClientInitiative += ClientInitiative.proseminar + ",";
				if(cbx_exhibition.Checked) client.ClientInitiative += ClientInitiative.exhibition + ",";
				if(cbx_EMS.Checked) client.ClientInitiative += ClientInitiative.post + ",";
				if(cbx_Email.Checked) client.ClientInitiative += ClientInitiative.email + ",";
			#endregion

				client.ChiefLinkmanID = (Session["tmpchief"]==null)?0:Int32.Parse(Session["tmpchief"].ToString());

				//根据clientid==0判断是update还是add
				try
				{
					if(clientid!=0) //修改
					{
						SqlDataReader dr_chief = cm.GetLinkmanByID(client.ChiefLinkmanID.ToString());
                        try
                        {
                            while (dr_chief.Read())
                            {
                                if (Session["cm_permission"].ToString() == "administrator")
                                {
                                    hlk_Chiefman.Text = dr_chief["name"].ToString();
                                    hlk_Chiefman.NavigateUrl = "Linkman.aspx?LinkmanID=" + dr_chief["id"].ToString();
                                    hlk_Chiefman.Target = "_blank";
                                }
                                else
                                {
                                    hlk_Chiefman.Text = dr_chief["name"].ToString();
                                }

                            }
                        }
                        finally
                        {
                            dr_chief.Close();
                            dr_chief.Dispose();
                        }
						cm.UpdateClient(client);
						Response.Write("<script>alert('修改成功！');opener.location.href=opener.location.href;close();</script>");
					}
					else //新增
					{
						CustomValidator1.Enabled = true;
						CustomValidator1.Validate();
						string tmplinkmanid = (Session["tmplinkmanid"]==null)?"":Session["tmplinkmanid"].ToString();
						client.Birthday = DateTime.Now;
						client.ID = cm.AddClinet(client);
						ViewState["ClientID"] = client.ID.ToString();
						ltl_ID.Text = client.ID.ToString();
						clientid = client.ID;
						SqlDataReader dr_chief = cm.GetLinkmanByID(client.ChiefLinkmanID.ToString());
                        try
                        {
                            while (dr_chief.Read())
                            {
                                if (Session["cm_permission"].ToString() == "administrator")
                                {
                                    hlk_Chiefman.Text = dr_chief["name"].ToString();
                                    hlk_Chiefman.NavigateUrl = "Linkman.aspx?LinkmanID=" + dr_chief["id"].ToString();
                                    hlk_Chiefman.Target = "_blank";
                                }
                                else
                                {
                                    hlk_Chiefman.Text = dr_chief["name"].ToString();
                                }
                                lbl_position.Text = dr_chief["Position"].ToString();
                                lbl_chieftel.Text = dr_chief["Telephone"].ToString();
                            }
                        }
                        finally
                        {
                            dr_chief.Close();
                            dr_chief.Dispose();
                        }
						//分析session中的tmplinkmanid使他们得到clientid
						foreach(string linkmanid in tmplinkmanid.Split(','))
						{
							if(linkmanid.Trim()!="")
							{
								UDS.Components.Linkman linkman = new UDS.Components.Linkman();
								UDS.Components.CM cm1 = new UDS.Components.CM();
								linkman = cm1.GetLinkmanStructByID(linkmanid);
								linkman.ClientID = client.ID;
								linkman.ID = Int32.Parse(linkmanid);
								cm.UpdateLinkman(linkman);
							}
						}
						//清空Session
						Session.Remove("tmpchief");
						Session.Remove("tmplinkmanid");
						Response.Write("<script>alert('添加成功！');opener.location.href=opener.location.href;close();</script>");
					}	
				}
				catch(Exception ex)
				{
					UDS.Components.Error.Log(ex.Message);
					Server.Transfer("../Error.aspx");
				}	
				//Response.Write("<script>if(opener!=null) opener.location.reload();</script>");
				//刷新页面显示
				if(clientid==0) 
					btn_AddContact.Visible = false;
				else
					btn_AddContact.Visible = true;

				penal.Visible = cbx_customer.Checked;

				//上传附件
				UploadAtt();

				//显示附件
				if(clientid!=0)
				{
					rpt_Attachment.DataSource = cm.GetAttachmentByClientID(clientid);
					rpt_Attachment.DataBind();
				}
			}
		}
		/// <summary>
		/// 判断是否有同名客户
		/// </summary>
		/// <param name="newclientname"></param>
		/// <returns></returns>
		private bool SameNameClient(string newclientname)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			SqlDataReader dr = cm.GetClientInfoByName(newclientname);
			DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			if(dt.Rows.Count==0)
				return(false);
			else
				return(true);
		}
		/// <summary>
		/// 上载文件
		/// </summary>
		private void UploadAtt()
		{
			HtmlForm FrmCompose   = (HtmlForm)this.Page.FindControl("Client");
			UDS.Components.CM cm = new UDS.Components.CM();
			
			string FileName = "";
			string Extension = "";
			string SavedName = "";
			try
			{
				if(Directory.Exists(Server.MapPath(".")+"\\Attachment"))
				{
					for (int i=0;i<FrmCompose.Controls.Count;i++)
					{
						if(FrmCompose.Controls [i].GetType().ToString()=="System.Web.UI.HtmlControls.HtmlInputFile")
						{
							HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.Controls[i]));
							if(hif.PostedFile.FileName.Trim()!="")
							{	
								FileName = System.IO .Path.GetFileName(hif.PostedFile.FileName);
								Extension = System.IO.Path.GetExtension(hif.PostedFile.FileName);

								SavedName = cm.InsertFile(FileName,"client",clientid,Extension).ToString();
								
								hif.PostedFile.SaveAs(Server.MapPath(".")+"\\Attachment\\"+SavedName+Extension );
							}
							hif=null;
						}
					}
				}
				else
				{   
					Directory.CreateDirectory(Server.MapPath(".")+"\\Attachment");
					UploadAtt();
				}
			}
			catch(Exception ioex)
			{	
				UDS.Components.Error.Log(ioex.ToString());
				Server.Transfer("../Error.aspx");
			}

		}

		private void cbx_customer_PreRender(object sender, System.EventArgs e)
		{
			//Response.Write("<script>if(document.Client.cbx_customer.checked) document.Client.penal.style.display='';else document.Client.penal.style.display='none';</script>");
		}

		private void cbx_customer_CheckedChanged(object sender, System.EventArgs e)
		{
			penal.Visible = ((CheckBox)sender).Checked;
			
		}

		private void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = !SameNameClient(args.Value);
		}

		private void tbx_ShortName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btn_AddContact_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.open('ClientContact_thisWeek.aspx?ClientID=" + clientid+"','_blank','');</script>");
		}

		private void btn_LookTel_Click(object sender, System.EventArgs e)
		{
			ltl_addmantel.Visible = true;
			UDS.Components.Staff staff = new UDS.Components.Staff();
			SqlDataReader dr_staff = staff.GetStaffInfo(Int32.Parse(ddl_AddMan.SelectedItem.Value));
			while(dr_staff.Read())
			{
				ltl_addmantel.Text = dr_staff["Mobile"].ToString();
			}
			dr_staff.Close();
		}

		private void btn_ChangeAddMan_Click(object sender, System.EventArgs e)
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			UDS.Components.ClientInfo client = cm.GetClientAllInfo(clientid);
			if(Page.IsValid)
			{
				client.AddManID = Int32.Parse(ddl_AddMan.SelectedItem.Value);
				cm.UpdateClient(client);
				//判断权限
				if(ddl_AddMan.SelectedItem.Value==Request.Cookies["UserID"].Value)
				{
					Session["cm_permission"] = "administrator";
				}
				else
					Session["cm_permission"] = "leader";

				Response.Write("<script>alert('修改成功！');opener.location.href='ClientListView.aspx';close();</script>");
			}
		}

		private void btn_LookContact_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.open('ClientHistoryContact.aspx?ClientID=" + clientid+"','_blank','');</script>");
		}
		
	}
}
