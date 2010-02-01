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

namespace UDS.SubModule.CM.Stat
{
	/// <summary>
	/// ClientInfo 的摘要说明。
	/// </summary>
	public class ClientInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddl_search;
		protected System.Web.UI.WebControls.RadioButtonList rbl_searchvalue;
		protected System.Web.UI.WebControls.Button btn_Del;
		protected System.Web.UI.WebControls.Button btn_addsearch;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.ListBox lbx_search;
		protected System.Web.UI.WebControls.Literal ltl_Client;
		protected System.Web.UI.WebControls.DataGrid dgrd_clientlist;
		protected System.Web.UI.WebControls.DropDownList ddl_SearchBound;
		protected System.Web.UI.WebControls.TextBox tbx_searchvalue;
	
		private string searchstring = "";
		//存放页眉文字
		private string[] headtext;

		private void Page_Load(object sender, System.EventArgs e)
		{
			ltl_Client.Text = "0";

			if(!Page.IsPostBack)
			{
				headtext = new String[dgrd_clientlist.Columns.Count];
				for(int i=0;i<dgrd_clientlist.Columns.Count;i++)
				{
					headtext[i] = dgrd_clientlist.Columns[i].HeaderText;
				}
				ViewState["headtext"] = headtext;
				ViewState["searchstring"] = "";

				ViewState["SortField"] = "ID";
				ViewState["SortDirect"] = "ASC";

				
			}
			else
			{
				//把页眉复位
				headtext = (string[]) ViewState["headtext"];
				for(int i=0;i<dgrd_clientlist.Columns.Count;i++)
				{
					dgrd_clientlist.Columns[i].HeaderText = headtext[i];
				}

				searchstring = ViewState["searchstring"].ToString();

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
			this.ddl_search.SelectedIndexChanged += new System.EventHandler(this.ddl_search_SelectedIndexChanged);
			this.ddl_SearchBound.SelectedIndexChanged += new System.EventHandler(this.ddl_SearchBound_SelectedIndexChanged);
			this.btn_addsearch.Click += new System.EventHandler(this.btn_addsearch_Click);
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.dgrd_clientlist.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgrd_clientlist_PageIndexChanged);
			this.dgrd_clientlist.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgrd_clientlist_SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			string searchbound = "";
			searchstring = "";
			UDS.Components.Staff mysubordinate = new UDS.Components.Staff();
            SqlDataReader dr_mysubordinate = mysubordinate.GetStaffFromPosition(Server.UrlDecode(Request.Cookies["UserName"].Value), 2, 2);
            try
            {
                switch (ddl_SearchBound.SelectedValue)
                {
                    //查询下属和本人
                    case "1":
                        //绑定下级人员
                        while (dr_mysubordinate.Read())
                        {
                            searchbound += "'" + dr_mysubordinate["Staff_ID"].ToString() + "',";
                        }
                        dr_mysubordinate.Close();
                        searchbound += "'" + Request.Cookies["UserID"].Value + "'";
                        break;
                    //查询本人
                    case "2":
                        searchbound += "'" + Request.Cookies["UserID"].Value + "'";
                        break;
                    //查询下属
                    case "3":
                        while (dr_mysubordinate.Read())
                        {
                            searchbound += "'" + dr_mysubordinate["Staff_ID"].ToString() + "',";
                        }
                        dr_mysubordinate.Close();
                        searchbound = (searchbound == "") ? "" : searchbound.Substring(0, searchbound.Length - 1);
                        break;
                }
            }
            finally
            { dr_mysubordinate.Close();
            dr_mysubordinate.Dispose();}

				#region 根据查询条件产生查询语句
			if(lbx_search.Items.Count>0)
			{
				
				DateTime begintime = new DateTime();
				DateTime endtime = DateTime.Now;
				foreach(ListItem lt in lbx_search.Items)
				{
					string [] searcharr = new string[2];
					searcharr = lt.Value.Split(':');
					switch(searcharr[0].Trim())
					{
						case "客户名称":
							searchstring += "UDS_CM_ClientInfo.name like '%" + searcharr[1] + "%' and ";
							break;
						case "客户分类":
						switch(searcharr[1])
						{
							case "终端用户":
								searchstring += "patindex('%terminal%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
							case "渠道商":
								searchstring += "patindex('%channal%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
							case "社会关系":
								searchstring += "patindex('%social%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
							case "媒体公关":
								searchstring += "patindex('%media%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
						}
							break;
						case "所处行业":
						switch(searcharr[1])
						{
							case "房地产":
								searchstring += "patindex('%realty%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "IT":
								searchstring += "patindex('%IT%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "商业贸易":
								searchstring += "patindex('%business%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "电信":
								searchstring += "patindex('%telecom%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "邮政通讯":
								searchstring += "patindex('%post%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "咨询服务":
								searchstring += "patindex('%refer%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "旅游业":
								searchstring += "patindex('%travel%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "交通运输":
								searchstring += "patindex('%bus%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "金融证券":
								searchstring += "patindex('%stock%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "保险":
								searchstring += "patindex('%insurance%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "税务":
								searchstring += "patindex('%tax%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "制造业":
								searchstring += "patindex('%make%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "家电":
								searchstring += "patindex('%he%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "服装":
								searchstring += "patindex('%clothe%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "食品":
								searchstring += "patindex('%food%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "医药":
								searchstring += "patindex('%medicine%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "机械":
								searchstring += "patindex('%mechanism%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "汽车制造":
								searchstring += "patindex('%auto%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;

						}
							break;
						case "企业性质":
						switch(searcharr[1])
						{
							case "政府":
								searchstring += "patindex('%government%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "国营":
								searchstring += "patindex('%contry%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "民营":
								searchstring += "patindex('%privateowned%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "外资":
								searchstring += "patindex('%oversea%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "上市公司":
								searchstring += "patindex('%stock%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
						}
							break;
						case "客户来源":
						switch(searcharr[1])
						{
							case "销售主动联系":
								searchstring += "patindex('%sellman%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
							case "以前认识":
								searchstring += "patindex('%familiar%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
							case "熟人介绍":
								searchstring += "patindex('%introduce%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
							case "客户主动联系":
								searchstring += "patindex('%client%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
						}
							break;
						case "客户编号":
							searchstring += "UDS_CM_ClientInfo.id='" + searcharr[1] + "' and ";
							break;
						case "联系人":
							//searchstring_linkman = "select * from UDS_CM_ClientInfo,UDS_CM_Linkman where UDS_CM_ClientInfo.id=UDS_CM_Linkman.clientid and UDS_CM_Linkman.name='" + searcharr[1] + "'" + " and ";
							searchstring += "UDS_CM_Linkman.name='" + searcharr[1] + "' and ";
							break;
						case "电话":
							searchstring += "UDS_CM_ClientInfo.telephone='" + searcharr[1] + "' and ";
							break;
						case "销售人员":
							UDS.Components.Staff staff = new UDS.Components.Staff();
							SqlDataReader dr_staffid = staff.GetStaffIDByRealName(searcharr[1]);
							string tmp = "UDS_CM_ClientInfo.addmanid='";
							while(dr_staffid.Read())
							{
								tmp +=  dr_staffid["staff_id"] + "' or UDS_CM_ClientInfo.addmanid='";
							}
							dr_staffid.Close();
							if(tmp=="UDS_CM_ClientInfo.addmanid='")
								searchstring = "1=2";
							else
							{
								tmp = tmp.Substring(0,tmp.Length-32);
								searchstring += "(" + tmp + ") and ";
							}
							break;
						
						case "添加日期":
							searchstring += "datediff(d,UDS_CM_ClientInfo.birthday,'" + searcharr[1] + "')=0 and ";
							break;
						case "本周新增客户":
							//得到本周起始日(周一 -- 周日)
							begintime = DateTime.Now;
						switch((int)DateTime.Now.DayOfWeek)
						{
							case 0:
								begintime = begintime.AddDays(-6);
								break;
							default:
								begintime = begintime.AddDays(1-(int)DateTime.Now.DayOfWeek);
								break;
						}
							searchstring += "(UDS_CM_ClientInfo.birthday between '" + begintime.ToShortDateString() + "' and '" + endtime.ToShortDateString() + "') and ";
							break;
						case "本月新增客户":
							//得到本月起始日
							begintime = DateTime.Now;
							begintime = begintime.AddDays(1-DateTime.Now.Day);
							searchstring += "(UDS_CM_ClientInfo.birthday between '" + begintime.ToShortDateString() + "' and '" + endtime.ToShortDateString() + "') and ";
							break;
					}

				}
		
				searchstring = "select UDS_CM_ClientInfo.*,UDS_CM_Linkman.Name AS Linkman from UDS_CM_ClientInfo left join UDS_CM_Linkman on UDS_CM_Linkman.clientid=UDS_CM_ClientInfo.id and UDS_CM_Linkman.ID=UDS_CM_ClientInfo.ChiefLinkmanID  where " + searchstring;

//				if(searchstring.EndsWith("and "))
//				{
//					searchstring = searchstring.Substring(0,searchstring.Length-4);
//				}
				#endregion

				searchstring += "UDS_CM_ClientInfo.AddmanID IN (" + searchbound + ")";

				ViewState["searchstring"] = searchstring;
				
//				Response.Write(searchstring);
//				Response.End();
				Bind();
				//Response.Write(searchstring);
			}
		}

		private void Bind()
		{
			DataSet ds = new DataSet();
			UDS.Components.Staff staff1 = new UDS.Components.Staff();
			SqlDataReader dr_Staff = staff1.GetAllStaffs();
			DataTable dt_Staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Staff);
			dt_Staff.TableName = "Staff";
			ds.Tables.Add(dt_Staff);
			
			try
			{
				UDS.Components.Database db = new UDS.Components.Database();
				SqlParameter[] prams = {
										   db.MakeInParam("@SQL",SqlDbType.NText,5000,searchstring)
									   };
				SqlDataReader dr = null;
				db.RunProc("sp_RunSql",prams,out dr);
				DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
				dt.TableName = "Client";
				ds.Tables.Add(dt);

				ltl_Client.Text = dt.Rows.Count.ToString();

				ds.Relations.Add("ClientAddMan_Staff",ds.Tables["Client"].Columns["AddManID"],ds.Tables["Staff"].Columns["Staff_ID"],false);

				dt.DefaultView.Sort = ViewState["SortField"].ToString() + " " + ViewState["SortDirect"].ToString();

				dgrd_clientlist.DataSource = dt.DefaultView;
				dgrd_clientlist.DataBind();
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}

			
		}

		private void ddl_search_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tbx_searchvalue.Text = "";
			tbx_searchvalue.Attributes["onfocus"] = "";
			tbx_searchvalue.ReadOnly = false;

			#region 条件选择
			switch(ddl_search.SelectedItem.Value)
			{
				case "客户名称": tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "客户分类": 
				{
					object[] array;
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = true;
					array = Enum.GetNames(typeof(UDS.Components.ClientType));
					for(int i=0;i<array.Length;i++)
					{
						switch(array[i].ToString())
						{
							case "terminal": 
								array[i] = "终端用户";
								break;
							case "channal":
								array[i] = "渠道商";
								break;
							case "social":
								array[i] = "社会关系";
								break;
							case "media":
								array[i] = "媒体公关";
								break;
						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;

				}
				case "客户编号":
					tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "联系人":
					tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "电话":
					tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "所处行业": 
				{
					object[] array;
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = true;
					array = Enum.GetNames(typeof(UDS.Components.ClientTrade));
					for(int i=0;i<array.Length;i++)
					{
						switch(array[i].ToString())
						{
							case "realty": 
								array[i] = "房地产";
								break;
							case "IT":
								array[i] = "IT";
								break;
							case "business":
								array[i] = "商业贸易";
								break;
							case "telecom":
								array[i] = "电信";
								break;
							case "post":
								array[i] = "邮政通讯";
								break;
							case "refer":
								array[i] = "咨询服务";
								break;
							case "travel":
								array[i] = "旅游业";
								break;
							case "bus":
								array[i] = "交通运输";
								break;
							case "stock":
								array[i] = "金融证券";
								break;
							case "insurance":
								array[i] = "保险";
								break;
							case "tax":
								array[i] = "税务";
								break;
							case "make":
								array[i] = "制造业";
								break;
							case "he":
								array[i] = "家电";
								break;
							case "clothe":
								array[i] = "服装";
								break;
							case "food":
								array[i] = "食品";
								break;
							case "medicine":
								array[i] = "医药";
								break;
							case "mechanism":
								array[i] = "机械";
								break;
							case "auto":
								array[i] = "汽车制造";
								break;

						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				}
				case "企业性质":
				{
					object[] array;
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = true;
					array = Enum.GetNames(typeof(UDS.Components.EnterpriseType));
					for(int i=0;i<array.Length;i++)
					{
						switch(array[i].ToString())
						{
							case "government":
								array[i] = "政府";
								break;
							case "contry":
								array[i] = "国营";
								break;
							case "oversea":
								array[i] = "外资";
								break;
							case "stock":
								array[i] = "上市公司";
								break;
							case "privateowned":
								array[i] = "民营";
								break;
						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				}
				case "客户来源":
				{
					object[] array;
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = true;
					array = Enum.GetNames(typeof(UDS.Components.ClientSource));
					for(int i=0;i<array.Length;i++)
					{
						switch(array[i].ToString())
						{
							case "sellman":
								array[i] = "销售主动联系";
								break;
							case "familiar":
								array[i] = "以前认识";
								break;
							case "introduce":
								array[i] = "熟人介绍";
								break;
							case "client":
								array[i] = "客户主动联系";
								break;
						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				}
				case "添加日期":
					tbx_searchvalue.Visible = true;
					rbl_searchvalue.Visible = false;
					tbx_searchvalue.ReadOnly = true;
					tbx_searchvalue.Attributes["onfocus"] = "setday(this)";
					break;
				case "本周新增客户":
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = false;
					break;
				case "本月新增客户":
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = false;
					break;
				default:
					tbx_searchvalue.Visible = true;
					rbl_searchvalue.Visible = false;
					break;


			}
			#endregion
		}

		private void btn_addsearch_Click(object sender, System.EventArgs e)
		{
			ListItem lt = new ListItem();
			lt.Text = ddl_search.SelectedItem.Text + ":";
			if(tbx_searchvalue.Visible==true)
				lt.Text += tbx_searchvalue.Text;
			else if(rbl_searchvalue.Visible==true)
				lt.Text += rbl_searchvalue.SelectedItem.Text;

			lt.Value = lt.Text;
			lbx_search.Items.Add(lt);
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			foreach(ListItem lt in lbx_search.Items)
			{
				if(lt.Selected)
				{
					lbx_search.Items.Remove(lt);
					break;
				}
			}
		}

		private void ddl_SearchBound_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgrd_clientlist_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(ViewState["SortField"].ToString() == e.SortExpression)
			{
				ViewState["SortDirect"] = (ViewState["SortDirect"].ToString()=="ASC")?"DESC":"ASC";
			}
			else
			{
				ViewState["SortField"] = e.SortExpression;
				ViewState["SortDirect"] = "ASC";

			}
			
			foreach(DataGridColumn col in  dgrd_clientlist.Columns)
			{
				if(col.SortExpression.ToString()==ViewState["SortField"].ToString())
				{
					if(ViewState["SortDirect"].ToString() == "ASC")
						col.HeaderText += "<img src='../../../images/asc.gif' border=0/>";
					else
						col.HeaderText += "<img src='../../../images/desc.gif' border=0/>";
				}
			}

			Bind();
		}

		private void dgrd_clientlist_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgrd_clientlist.CurrentPageIndex =e.NewPageIndex;
			Bind();
		}
	}
}
