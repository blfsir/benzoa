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
	/// ClientInfo ��ժҪ˵����
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
		//���ҳü����
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
				//��ҳü��λ
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
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
                    //��ѯ�����ͱ���
                    case "1":
                        //���¼���Ա
                        while (dr_mysubordinate.Read())
                        {
                            searchbound += "'" + dr_mysubordinate["Staff_ID"].ToString() + "',";
                        }
                        dr_mysubordinate.Close();
                        searchbound += "'" + Request.Cookies["UserID"].Value + "'";
                        break;
                    //��ѯ����
                    case "2":
                        searchbound += "'" + Request.Cookies["UserID"].Value + "'";
                        break;
                    //��ѯ����
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

				#region ���ݲ�ѯ����������ѯ���
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
						case "�ͻ�����":
							searchstring += "UDS_CM_ClientInfo.name like '%" + searcharr[1] + "%' and ";
							break;
						case "�ͻ�����":
						switch(searcharr[1])
						{
							case "�ն��û�":
								searchstring += "patindex('%terminal%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
							case "������":
								searchstring += "patindex('%channal%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
							case "����ϵ":
								searchstring += "patindex('%social%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
							case "ý�幫��":
								searchstring += "patindex('%media%',UDS_CM_ClientInfo.type)>0" + " and ";
								break;
						}
							break;
						case "������ҵ":
						switch(searcharr[1])
						{
							case "���ز�":
								searchstring += "patindex('%realty%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "IT":
								searchstring += "patindex('%IT%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "��ҵó��":
								searchstring += "patindex('%business%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "����":
								searchstring += "patindex('%telecom%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "����ͨѶ":
								searchstring += "patindex('%post%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "��ѯ����":
								searchstring += "patindex('%refer%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "����ҵ":
								searchstring += "patindex('%travel%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "��ͨ����":
								searchstring += "patindex('%bus%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "����֤ȯ":
								searchstring += "patindex('%stock%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "����":
								searchstring += "patindex('%insurance%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "˰��":
								searchstring += "patindex('%tax%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "����ҵ":
								searchstring += "patindex('%make%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "�ҵ�":
								searchstring += "patindex('%he%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "��װ":
								searchstring += "patindex('%clothe%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "ʳƷ":
								searchstring += "patindex('%food%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "ҽҩ":
								searchstring += "patindex('%medicine%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "��е":
								searchstring += "patindex('%mechanism%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;
							case "��������":
								searchstring += "patindex('%auto%',UDS_CM_ClientInfo.Calling)>0" + " and ";
								break;

						}
							break;
						case "��ҵ����":
						switch(searcharr[1])
						{
							case "����":
								searchstring += "patindex('%government%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "��Ӫ":
								searchstring += "patindex('%contry%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "��Ӫ":
								searchstring += "patindex('%privateowned%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "����":
								searchstring += "patindex('%oversea%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
							case "���й�˾":
								searchstring += "patindex('%stock%',UDS_CM_ClientInfo.CompanyProperty)>0" + " and ";
								break;
						}
							break;
						case "�ͻ���Դ":
						switch(searcharr[1])
						{
							case "����������ϵ":
								searchstring += "patindex('%sellman%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
							case "��ǰ��ʶ":
								searchstring += "patindex('%familiar%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
							case "���˽���":
								searchstring += "patindex('%introduce%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
							case "�ͻ�������ϵ":
								searchstring += "patindex('%client%',UDS_CM_ClientInfo.Customer)>0" + " and ";
								break;
						}
							break;
						case "�ͻ����":
							searchstring += "UDS_CM_ClientInfo.id='" + searcharr[1] + "' and ";
							break;
						case "��ϵ��":
							//searchstring_linkman = "select * from UDS_CM_ClientInfo,UDS_CM_Linkman where UDS_CM_ClientInfo.id=UDS_CM_Linkman.clientid and UDS_CM_Linkman.name='" + searcharr[1] + "'" + " and ";
							searchstring += "UDS_CM_Linkman.name='" + searcharr[1] + "' and ";
							break;
						case "�绰":
							searchstring += "UDS_CM_ClientInfo.telephone='" + searcharr[1] + "' and ";
							break;
						case "������Ա":
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
						
						case "�������":
							searchstring += "datediff(d,UDS_CM_ClientInfo.birthday,'" + searcharr[1] + "')=0 and ";
							break;
						case "���������ͻ�":
							//�õ�������ʼ��(��һ -- ����)
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
						case "���������ͻ�":
							//�õ�������ʼ��
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

			#region ����ѡ��
			switch(ddl_search.SelectedItem.Value)
			{
				case "�ͻ�����": tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "�ͻ�����": 
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
								array[i] = "�ն��û�";
								break;
							case "channal":
								array[i] = "������";
								break;
							case "social":
								array[i] = "����ϵ";
								break;
							case "media":
								array[i] = "ý�幫��";
								break;
						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;

				}
				case "�ͻ����":
					tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "��ϵ��":
					tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "�绰":
					tbx_searchvalue.Visible = true;rbl_searchvalue.Visible = false;break;
				case "������ҵ": 
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
								array[i] = "���ز�";
								break;
							case "IT":
								array[i] = "IT";
								break;
							case "business":
								array[i] = "��ҵó��";
								break;
							case "telecom":
								array[i] = "����";
								break;
							case "post":
								array[i] = "����ͨѶ";
								break;
							case "refer":
								array[i] = "��ѯ����";
								break;
							case "travel":
								array[i] = "����ҵ";
								break;
							case "bus":
								array[i] = "��ͨ����";
								break;
							case "stock":
								array[i] = "����֤ȯ";
								break;
							case "insurance":
								array[i] = "����";
								break;
							case "tax":
								array[i] = "˰��";
								break;
							case "make":
								array[i] = "����ҵ";
								break;
							case "he":
								array[i] = "�ҵ�";
								break;
							case "clothe":
								array[i] = "��װ";
								break;
							case "food":
								array[i] = "ʳƷ";
								break;
							case "medicine":
								array[i] = "ҽҩ";
								break;
							case "mechanism":
								array[i] = "��е";
								break;
							case "auto":
								array[i] = "��������";
								break;

						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				}
				case "��ҵ����":
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
								array[i] = "����";
								break;
							case "contry":
								array[i] = "��Ӫ";
								break;
							case "oversea":
								array[i] = "����";
								break;
							case "stock":
								array[i] = "���й�˾";
								break;
							case "privateowned":
								array[i] = "��Ӫ";
								break;
						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				}
				case "�ͻ���Դ":
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
								array[i] = "����������ϵ";
								break;
							case "familiar":
								array[i] = "��ǰ��ʶ";
								break;
							case "introduce":
								array[i] = "���˽���";
								break;
							case "client":
								array[i] = "�ͻ�������ϵ";
								break;
						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				}
				case "�������":
					tbx_searchvalue.Visible = true;
					rbl_searchvalue.Visible = false;
					tbx_searchvalue.ReadOnly = true;
					tbx_searchvalue.Attributes["onfocus"] = "setday(this)";
					break;
				case "���������ͻ�":
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = false;
					break;
				case "���������ͻ�":
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
