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
using UDS.Components;

namespace UDS.SubModule.Role
{
	/// <summary>
	/// ListView ��ժҪ˵����
	/// </summary>
	public class ListView : System.Web.UI.Page
	{

		public int DisplayType;
		public int RoleID;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;
		protected System.Web.UI.WebControls.LinkButton lbMember;
		protected System.Web.UI.WebControls.LinkButton lbNonMember;
		protected System.Web.UI.WebControls.Button cmdManageRole;
		protected System.Web.UI.WebControls.Button cmdManageRight;
		protected System.Web.UI.WebControls.Button cmdDeleteStaffFromRole;
		protected System.Web.UI.WebControls.Button cmdAddToRole;
		private bool refresh;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			RoleID =Int32.Parse((Request.QueryString["Role_ID"]==null)?"0":Request.QueryString["Role_ID"].ToString());
			DisplayType = Int32.Parse((Request.QueryString["DisplayType"]==null)?"0":Request.QueryString["DisplayType"].ToString());

			if(!Page.IsPostBack)
			{	
				if(DisplayType==0)
				{

					cmdAddToRole.Visible = false;
					cmdDeleteStaffFromRole.Visible = true;
				}
				else
				{
					cmdAddToRole.Visible = true;
					cmdDeleteStaffFromRole.Visible = false;

				}

				refresh = (Request.QueryString["Refresh"]==null)?false:true;
				if(refresh)
					Response.Write("<script language='javascript'>parent.LeftFrame.location.reload();</script>");

				BindGrid();

				cmdAddToRole.Attributes.Add("OnClick","javascript:return confirm('�Ƿ��ѡ����Ա���뵽��ɫ��');");
				cmdDeleteStaffFromRole.Attributes.Add("OnClick","javascript:return confirm('�Ƿ��ѡ����Ա�ӽ�ɫ���룡');");

			}

		}
		public string GetSelectImage(string NormalImg,string SelectedImg,int selected,int position)
		{
			if(selected==position)
				return SelectedImg;
			else
				return NormalImg;
		}
		private void BindGrid()
		{
			SqlDataReader dr=null; //������������
			Database db = new Database();
            try
            {
                SqlParameter[] prams = {
									   db.MakeInParam("@RoleID",SqlDbType.Int,4,RoleID)
								   };
                if (DisplayType == 0)
                    db.RunProc("sp_GetStaffInRole", prams, out dr);
                else
                    db.RunProc("sp_GetStaffNotInRole", prams, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);


                dbStaffList.DataSource = dt.DefaultView;
                dbStaffList.DataBind();
            }
            finally
            {
                if (db != null)
                { db.Close(); }
                if (dr != null)
                {

                    dr.Close();
                }
            }

		}

		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
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
			this.lbMember.Click += new System.EventHandler(this.lbMember_Click);
			this.lbNonMember.Click += new System.EventHandler(this.lbNonMember_Click);
			this.cmdManageRole.Click += new System.EventHandler(this.cmdManageRole_Click);
			this.cmdManageRight.Click += new System.EventHandler(this.cmdManageRight_Click);
			this.cmdDeleteStaffFromRole.Click += new System.EventHandler(this.cmdDeleteStaffFromRole_Click);
			this.cmdAddToRole.Click += new System.EventHandler(this.cmdAddToRole_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//����DataGrid���checked��ID
			foreach (DataGridItem item in dbStaffList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dbStaffList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}

		private void lbMember_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?Role_ID=" + RoleID.ToString() + "&DisplayType=0" );
		}

		private void lbNonMember_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?Role_ID=" + RoleID.ToString() + "&DisplayType=1" );
		}

		private void cmdManageRole_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ORole.aspx?Role_ID=" + RoleID.ToString());
		}

		private void cmdManageRight_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("../AssignRule/RightListview.aspx?ObjID=" +RoleID.ToString() + "&DisplayType=2");
		}

		private void cmdDeleteStaffFromRole_Click(object sender, System.EventArgs e)
		{
			string selectID =GetSelectedItemID("Staff_ID");
			if(selectID.Trim()!="")
			{
				if(UDS.Components.Role.DelStaffFromRole(RoleID,selectID)!=0)
				{
					UDS.Components.Error.Log("�����ɫ����");
					Response.Redirect("../Error.aspx");
				}
				else
					Response.Redirect("ListView.aspx?Role_ID="+RoleID.ToString()+"&DisplayType="+DisplayType.ToString());
			}
			else
				Response.Write("<script language='javascript'>alert('��ѡ��Ҫ�������Ա');</script>");
		
		}

		private void cmdAddToRole_Click(object sender, System.EventArgs e)
		{
			string selectID =GetSelectedItemID("Staff_ID");
			if(selectID.Trim()!="")
			{
				if(UDS.Components.Role.AddStaffFromRole(RoleID,selectID)!=0)
				{
					UDS.Components.Error.Log("�����ɫ����");
					Response.Redirect("../Error.aspx");
				}
				else
					Response.Redirect("ListView.aspx?Role_ID="+RoleID.ToString()+"&DisplayType="+DisplayType.ToString());				
			}
			else
				Response.Write("<script language='javascript'>alert('��ѡ��Ҫ�������Ա');</script>");
		}


	}
}
