using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using UDS.Components;

namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// MemberListView ��ժҪ˵����
	/// </summary>
	public class MemberListView : System.Web.UI.Page
	{
		protected HttpCookie UserCookie;
		protected static string Username;
		protected static string ClassID;
		protected System.Web.UI.WebControls.DataGrid dgMemberList;
		protected System.Web.UI.WebControls.Label lblStaff_Name;
		protected System.Web.UI.WebControls.Label lblRealName;
		protected System.Web.UI.WebControls.Label lblSex;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.Label lblRegistedDate;
		protected System.Web.UI.HtmlControls.HtmlForm DisplayStaffInfo;
		protected System.Web.UI.WebControls.Button cmdDelete;
		protected System.Web.UI.WebControls.Button btnLeader;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.CheckBox cbRemind;
		protected static string DisplayType="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			ClassID		 = (Request.QueryString["TeamID"]!=null)?Request.QueryString["TeamID"].ToString():"";
			DisplayType	 = (Request.QueryString["DisplayType"]!=null)?Request.QueryString["DisplayType"].ToString():"0";
			UserCookie	 = Request.Cookies["Username"];
            Username = Server.UrlDecode(Request.Cookies["UserName"].Value); 
			
			if(!IsPostBack)
			{	
				BindGrid();
				
			}
		}

		#region ���ݰ���DataGrid
		/// <summary>
		/// ��ĳ�û����ʼ�ȡ������DataGrid
		/// </summary>
		protected void BindGrid() 
		{   
			
			Team team				  = new Team();
			DataTable datatable		  = new DataTable();
			switch (DisplayType) {
			case "0":
				datatable	=  Tools.ConvertDataReaderToDataTable(team.GetStaffInTeam(Int32.Parse(ClassID)));
				this.btnAdd.Visible    = false;
				this.cmdDelete.Visible = true;
				this.btnLeader.Visible = true;
				break;
			case "1":
				datatable	=  Tools.ConvertDataReaderToDataTable(team.GetStaffNotInTeam(Int32.Parse(ClassID)));
				this.btnAdd.Visible    = true;
				this.cmdDelete.Visible = false;
				this.btnLeader.Visible = false;
				this.dgMemberList.Columns.Remove(this.dgMemberList .Columns[3]);
				break;
			case "2":
				datatable	=  Tools.ConvertDataReaderToDataTable(team.GetStaffSubscriptionTeam(Int32.Parse(ClassID)));
				this.btnAdd.Visible    = false;
				this.cmdDelete.Visible = false;
				this.btnLeader.Visible = false;
				this.dgMemberList.Columns.Remove(this.dgMemberList .Columns[3]);
				break;
			default:
				break;
			}
		
			dgMemberList.DataSource	  = datatable.DefaultView;
			dgMemberList.DataBind(); 
		
			if (datatable.Rows.Count !=0)
			{
				this.cmdDelete.Attributes ["onclick"]="javascript:return confirm('��ȷ��Ҫѡ�е���Ա��������?');";
				this.btnLeader.Attributes ["onclick"]="javascript:return confirm('��ȷ��Ҫѡ�е���Ա����Ϊ�鳤��?');";
				this.btnAdd.Attributes ["onclick"]   ="javascript:return confirm('��ȷ��Ҫ����ó�Ա��?');";
			}
			team	  = null;
			datatable = null;
		} 
		
		#endregion

		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgMemberList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion

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
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			this.btnLeader.Click += new System.EventHandler(this.btnLeader_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		#region С���Ա�仯����Ϣ֪ͨ���� iΪ0��ʾ������,iΪ1��ʾ������,iΪ2��ʾ��Ϊ�鳤
		private void sms_all(int ii)
		{
			string sql			  = "";//����ѡ��ĳ�ԱID����
			bool sqlFlag		  = true;
			foreach(DataGridItem dgi in this.dgMemberList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMemberList.DataKeys[i].ToString();				
					if (sqlFlag)
					{
						sql+=""+id;
						sqlFlag=false;
					}
					else
					{
						sql+=" ,";
						sql+=id;
					}
				}
			}

			SqlDataReader dr_this;//��ѡ����Ա
			UDS.Components.Staff sta=new UDS.Components.Staff();
			dr_this=sta.GetStaffInfo(sql);

			SqlDataReader dr_allTeam;//������Ա
			Team steam=new Team();
			dr_allTeam=steam.GetStaffInTeam(Convert.ToInt32(ClassID));

			SqlDataReader dr_allTeamMaster;//�����鳤
			ProjectClass prj=new ProjectClass();
			dr_allTeamMaster=prj.GetLeader(Convert.ToInt32(ClassID));

			SqlDataReader dataReader;//��Ŀ��Ϣ
			dataReader = prj.GetClassInfo(Convert.ToInt32(ClassID));
			string Team_name="";//��Ŀ����
            try
            {
                if (dataReader.Read())
                {
                    Team_name = dataReader[0].ToString() + ",";
                }
                dataReader.Close();
                dataReader = null;

                string Staff_name = "";//��ѡ����Ա����
                while (dr_this.Read())
                {
                    Staff_name += dr_this["RealName"].ToString() + ",";
                }
                dr_this.Close();
                dr_this = null;

                string name_teamMaster = "";//�����鳤������
                while (dr_allTeamMaster.Read())
                {
                    name_teamMaster += dr_allTeamMaster["RealName"].ToString() + ",";
                }
                dr_allTeamMaster.Close();
                dr_allTeamMaster = null;


                SMS sm = new SMS();
                //�����������
                while (dr_allTeam.Read())//iΪ0��ʾ������,iΪ1��ʾ������,iΪ2��ʾ��Ϊ�鳤
                {
                    if (ii == 0)
                        sm.SendMsg(Username, dr_allTeam["Staff_name"].ToString(), Team_name + " ��Ŀ��Ա��:" + Staff_name + "�Ѿ����뱾��Ŀ,�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                    else if (ii == 1)
                        sm.SendMsg(Username, dr_allTeam["Staff_name"].ToString(), "Ա��:" + Staff_name + "�Ѿ�������Ŀ:" + Team_name + ",�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                    else if (ii == 2)
                        sm.SendMsg(Username, dr_allTeam["Staff_name"].ToString(), Team_name + " ��Ŀ��Ա��:" + Staff_name + "�Ѿ����" + name_teamMaster + ",��Ϊ��Ŀ�鳤,�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                }
                sm = null;
                dr_allTeam.Close();
                dr_allTeam = null;
            }
            finally
            {
                dr_allTeam.Close();
                dr_allTeamMaster.Close();
                dr_this.Close();
                dataReader.Close();
            }
		}
		#endregion

		#region �����鳤
		private void lnkbtnLeader_Click(object sender, System.EventArgs e)
		{
			
		
		}
		#endregion

		#region �����Ա����
		private void lnkbtnAdd_Click(object sender, System.EventArgs e)
		{
		}
		#endregion

		#region ��Ա����
		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			Team team			  = new Team();
			bool sqlFlag		  = true;
			string sql			  = "";
			foreach(DataGridItem dgi in this.dgMemberList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMemberList.DataKeys[i].ToString();				
					if (sqlFlag)
					{
						sql+=""+id;
						sqlFlag=false;
					}
					else
					{
						sql+=" ,";
						sql+=id;
					}
				}
			}
			//ѡ��Ϊ��
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ����Ա!');window.location='MemberListView.aspx?TeamID="+ClassID+"';</script>");
			}
			else
			{
				if(this.cbRemind.Checked==true)
					sms_all(0);
				if(team.DeleteStaffFromTeam(sql,Int32.Parse(ClassID)))
				{
					Response.Write("<script language=javascript>alert('��Ա����ɹ�!');window.location='MemberListView.aspx?TeamID="+ClassID+"';</script>");
				}
				else
				{
					Server.Transfer("../Error.aspx");
				}
			}
			team=null;		
		}

		#endregion

		private void btnLeader_Click(object sender, System.EventArgs e)
		{
			Team team			  = new Team();
			bool sqlFlag		  = true;
			string sql			  = "";
			foreach(DataGridItem dgi in this.dgMemberList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMemberList.DataKeys[i].ToString();				
					if (sqlFlag)
					{
						sql+=""+id;
						sqlFlag=false;
					}
					else
					{
						sql+=" ,";
						sql+=id;
					}
				}
			}
			//ѡ��Ϊ��
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ����Ա!');window.location='MemberListView.aspx?TeamID="+ClassID+"';</script>");
			}
			else
			{
				if(this.cbRemind.Checked==true)
					sms_all(2);
				if(team.SetLeader(sql,Int32.Parse(ClassID)))
				{
					Response.Write("<script language=javascript>alert('�����鳤�ɹ�!');window.location='MemberListView.aspx?TeamID="+ClassID+"';</script>");
				}
				else
				{
					Server.Transfer("../Error.aspx");
				}
			}
			team=null;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			
			Team team			  = new Team();
			bool sqlFlag		  = true;
			string sql			  = "";
			foreach(DataGridItem dgi in this.dgMemberList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMemberList.DataKeys[i].ToString();				
					if (sqlFlag)
					{
						sql+=""+id;
						sqlFlag=false;
					}
					else
					{
						sql+=" ,";
						sql+=id;
					}
				}
			}
			//ѡ��Ϊ��
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ����Ա!');window.location='MemberListView.aspx?TeamID="+ClassID+"';</script>");
			}
			else
			{
				if(team.AddMemberToTeam(sql,Int32.Parse(ClassID)))
				{
					if(this.cbRemind.Checked==true)
						sms_all(1);
					Response.Write("<script language=javascript>alert('�����Ա����ɹ�!');window.location='MemberListView.aspx?TeamID="+ClassID+"';</script>");
				}
				else
				{
					Server.Transfer("../Error.aspx");
				}
			}
			team=null;
		
		}
	}
}
