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
	/// ContactInfo ��ժҪ˵����
	/// </summary>
	public class ContactInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbx_searchvalue;
		protected System.Web.UI.WebControls.RadioButtonList rbl_searchvalue;
		protected System.Web.UI.WebControls.Button btn_addsearch;
		protected System.Web.UI.WebControls.ListBox lbx_search;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.DataGrid dgrd_ContactList;
		protected System.Web.UI.WebControls.Button btn_Del;
		protected System.Web.UI.WebControls.Literal ltl_Client;
		protected System.Web.UI.WebControls.DropDownList ddl_search;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			ltl_Client.Text = "0";
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
			this.btn_addsearch.Click += new System.EventHandler(this.btn_addsearch_Click);
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

		private void ddl_search_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tbx_searchvalue.Text = "";
			tbx_searchvalue.Attributes["onfocus"] = "";
			tbx_searchvalue.ReadOnly = false;
			object[] array;
			switch(ddl_search.SelectedItem.Value)
			{
				case "���۽׶�":
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = true;
					array = Enum.GetNames(typeof(UDS.Components.ContactStat));
					for(int i=0;i<array.Length;i++)
					{
						switch(array[i].ToString())
						{
							case "trace": 
								array[i] = "����";
								break;
							case "boot":
								array[i] = "����";
								break;
							case "commend":
								array[i] = "��Ʒ�Ƽ�";
								break;
							case "requirement":
								array[i] = "������";
								break;
							case "submit":
								array[i] = "�����ύ";
								break;
							case "negotiate":
								array[i] = "����̸��";
								break;
							case "actualize":
								array[i] = "��Ŀʵʩ";
								break;
							case "traceservice":
								array[i] = "���ٷ���";
								break;
							case "last":
								array[i] = "��β��";
								break;
						}
					}
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				case "�ɽ�Ԥ��":
					array = new string[]{"*","**","***","****","*****",}; 
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = true;
					rbl_searchvalue.DataSource = array;
					rbl_searchvalue.DataBind();
					break;
				case "�״ν�Ǣʱ��":
					tbx_searchvalue.ReadOnly = true;
					tbx_searchvalue.Attributes["onfocus"] = "setday(this)";
					break;
				case "���һ�ν�Ǣʱ��":
					tbx_searchvalue.Visible = true;
					rbl_searchvalue.Visible = false;
					tbx_searchvalue.ReadOnly = true;
					tbx_searchvalue.Attributes["onfocus"] = "setday(this)";
					break;
				case "�´�Լ��ʱ��":
					tbx_searchvalue.Visible = true;
					rbl_searchvalue.Visible = false;
					tbx_searchvalue.ReadOnly = true;
					tbx_searchvalue.Attributes["onfocus"] = "setday(this)";
					break;
				case "����������¼":
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = false;
					break;
				case "����������¼":
					tbx_searchvalue.Visible = false;
					rbl_searchvalue.Visible = false;
					break;
				default:
					tbx_searchvalue.Visible = true;
					rbl_searchvalue.Visible = false;
					break;
			}
		}

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			if(lbx_search.Items.Count>0)
			{
				string searchstring = "";
				string tmp = "";
				DateTime begintime = new DateTime();
				DateTime endtime = DateTime.Now;
				foreach(ListItem lt in lbx_search.Items)
				{
					string [] searcharr = new string[2];
					searcharr = lt.Value.Split(':');
					switch(searcharr[0].Trim())
					{
						case "������Ա����":
							UDS.Components.Staff staff = new UDS.Components.Staff();
							SqlDataReader dr_staffid = staff.GetStaffIDByRealName(searcharr[1]);
							tmp = "UDS_CM_ClientContact.MarketmanID='";
                            try
                            {
                                while (dr_staffid.Read())
                                {
                                    tmp += dr_staffid["staff_id"] + "' or UDS_CM_ClientContact.MarketmanID='";
                                }
                            }
                            finally
                            {
                                dr_staffid.Close();
                            }
							if(tmp=="UDS_CM_ContactInfo.MarketmanID='")
								searchstring = "1=2";
							else
							{
								tmp = tmp.Substring(0,tmp.Length-37);
								searchstring += "(" + tmp + ") and ";
							}
							break;

						case "�ͻ�����":
							UDS.Components.CM cm = new UDS.Components.CM();
							SqlDataReader dr_clientid = cm.GetClientIDByName(searcharr[1]);
							tmp = "UDS_CM_ClientContact.ClientID='";
                            try
                            {
                                while (dr_clientid.Read())
                                {
                                    tmp += dr_clientid["ID"] + "' or UDS_CM_ClientContact.ClientID='";
                                }
                            }
                            finally
                            {
                                dr_clientid.Close();
                            }
							if(tmp=="UDS_CM_ClientContact.ClientID='")
								searchstring = "1=2";
							else
							{
								tmp = tmp.Substring(0,tmp.Length-34);
								searchstring += "(" + tmp + ") and ";
							}
							break;
						case "�ͻ����":
							searchstring += "UDS_CM_ClientContact.ClientID=" + searcharr[1] + " and ";
							break;
						case "���۽׶�":
						switch(searcharr[1])
						{
							case "����":
								searchstring += "patindex('%trace%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "����":
								searchstring += "patindex('%boot%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "��Ʒ�Ƽ�":
								searchstring += "patindex('%commend%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "������":
								searchstring += "patindex('%requirement%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "�����ύ":
								searchstring += "patindex('%submit%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "����̸��":
								searchstring += "patindex('%negotiate%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "��Ŀʵʩ":
								searchstring += "patindex('%actualize%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "���ٷ���":
								searchstring += "patindex('%traceservice%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
							case "��β��":
								searchstring += "patindex('%last%',UDS_CM_ClientContact.curstatus)>=0" + " and ";
								break;
						}
							break;
						case "�ɽ�Ԥ��":
							searchstring += "UDS_CM_ClientContact.BargainPrognosis='" + searcharr[1] + "' and ";
							break;
						case "�ѽ�Ǣ����":
							searchstring += "UDS_CM_ClientContact.ContactTimes=" + searcharr[1] + " and ";
							break;
						case "��Ǣ����ְ��":
							searchstring += "UDS_CM_Linkman.[Position]='" + searcharr[1] + "' and ";
							break;
						case "�״ν�Ǣʱ��":
							searchstring += "UDS_CM_ClientInfo.FirstContactTime='" + searcharr[1] + "' and ";
							break;
						case "���һ�ν�Ǣʱ��":
							searchstring += "UDS_CM_ClientInfo.ContactTime='" + searcharr[1] + "' and ";
							break;
						case "�´�Լ��ʱ��":
							searchstring += "UDS_CM_ClientInfo.NextContactTime='" + searcharr[1] + "' and ";
							break;
						case "����������¼":
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
							searchstring += "(UDS_CM_ClientContact.updatetime between '" + begintime.ToShortDateString() + "' and '" + endtime.ToShortDateString() + "') and ";
							break;
						case "����������¼":
							//�õ�������ʼ��
							begintime = DateTime.Now;
							begintime = begintime.AddDays(1-DateTime.Now.Day);
							searchstring += "(UDS_CM_ClientContact.updatetime between '" + begintime.ToShortDateString() + "' and '" + endtime.ToShortDateString() + "') and ";
							break;

					}
				}

				searchstring = "select * from UDS_CM_ClientInfo where ID IN (select UDS_CM_ClientInfo.ID from UDS_CM_ClientContact left join UDS_CM_ClientContact_Linkman ON UDS_CM_ClientContact.ID=UDS_CM_ClientContact_Linkman.ContactID left join UDS_CM_Linkman ON UDS_CM_ClientContact_Linkman.LinkmanID=UDS_CM_ClientContact_Linkman.id,UDS_CM_ClientInfo where UDS_CM_ClientContact.clientid=UDS_CM_ClientInfo.id and " + searchstring;
				if(searchstring.EndsWith("and "))
				{
					searchstring = searchstring.Substring(0,searchstring.Length-4);
				}
				searchstring += " group by UDS_CM_ClientInfo.ID)";
				
				DataSet ds = new DataSet();
				UDS.Components.Staff staff1 = new UDS.Components.Staff();
				SqlDataReader dr_Staff = staff1.GetAllStaffs();
				DataTable dt_Staff = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_Staff);
				dt_Staff.TableName = "Staff";
				ds.Tables.Add(dt_Staff);

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

				dgrd_ContactList.DataSource = dt.DefaultView;
				dgrd_ContactList.DataBind();
				
			}
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
	}
}
