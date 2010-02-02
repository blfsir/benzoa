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


namespace UDS.SubModule.Department
{
	/// <summary>
	/// ListView ��ժҪ˵����
	/// </summary>
	public class ListView : System.Web.UI.Page
	{

		public static int DisplayType = 0;
		public static string DeptID;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;
		protected System.Web.UI.WebControls.LinkButton lbOffLine;
		protected System.Web.UI.WebControls.LinkButton lbOnline;
		protected System.Web.UI.WebControls.Button cmdNewStaff;
		protected System.Web.UI.WebControls.Button cmdDepartmentOperate;
		protected System.Web.UI.WebControls.Button cmdSetRight;
		protected System.Web.UI.WebControls.Button cmdOffDepartment;
		protected System.Web.UI.WebControls.Button cmdChangeDepartment;
		protected System.Web.UI.WebControls.Button cmdOnDepartment;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				if (Request.QueryString["DisplayType"] != null)
					DisplayType = Int32.Parse( Request.QueryString["DisplayType"].ToString());		
				if(DisplayType==0)
				{
//					lbOnline.BackColor = Color.FromArgb(0xCCCCCC);
//					lbOffLine.BackColor =Color.FromArgb(0xFFFFFF);	
					cmdOnDepartment.Visible =false;
					cmdOffDepartment.Visible =true;

				}
				else
				{
//					lbOnline.BackColor = Color.FromArgb(0xFFFFFF);
//					lbOffLine.BackColor =Color.FromArgb(0xCCCCCC);					
					cmdOnDepartment.Visible =true;
					cmdOffDepartment.Visible =false;

				}

				if (Request.QueryString["DeptID"] != null)
					DeptID = Request.QueryString["DeptID"].ToString();
				else
					DeptID = "1";

				//���Ҫ��ˢ�²�����
				if(Request.QueryString["Refresh"] != null )
				{
					Response.Write("<script language='javascript'>parent.contents.location.reload();</script>");
				}
				
				cmdOnDepartment.Attributes.Add("Onclick","javascript:return confirm('�Ƿ���ѡ�е��˸�ְ��');");
				cmdOffDepartment.Attributes.Add("Onclick","javascript:return confirm('�Ƿ���ѡ�е�����ְ��');");


				BindGrid();
			}
			
		}
		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion
		private void BindGrid()
		{
			SqlDataReader dr; //������������
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@Dept_ID",SqlDbType.Int,4,DeptID),
									   db.MakeInParam("@Dimission",SqlDbType.Bit,1,DisplayType)
								   };
			db.RunProc("sp_GetStaffInDepartment",prams,out dr);
			DataTable dt =Tools.ConvertDataReaderToDataTable(dr);

			dbStaffList.DataSource = dt.DefaultView;
			dbStaffList.DataBind();

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
			this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
			this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
			this.cmdNewStaff.Click += new System.EventHandler(this.cmdNewStaff_Click);
			this.cmdDepartmentOperate.Click += new System.EventHandler(this.cmdDepartmentOperate_Click);
			this.cmdSetRight.Click += new System.EventHandler(this.cmdSetRight_Click);
			this.cmdOnDepartment.Click += new System.EventHandler(this.cmdOnDepartment_Click);
			this.cmdOffDepartment.Click += new System.EventHandler(this.cmdOffDepartment_Click);
			this.cmdChangeDepartment.Click += new System.EventHandler(this.cmdChangeDepartment_Click);
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


		private void lbOffLine_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?DeptID=" + DeptID.ToString() + "&DisplayType=1");
		}

		private void lbOnline_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?DeptID=" + DeptID.ToString() + "&DisplayType=0");
		}

		private void cmdNewStaff_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NewStaff.aspx?DeptID=" + DeptID.ToString() + "&DisplayType =0");
		}

		private void cmdDepartmentOperate_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ODepartment.aspx?DeptID=" + DeptID.ToString());
		}

		private void cmdSetRight_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("../AssignRule/RightListview.aspx?ObjID=" + DeptID.ToString() + "&displayType=0");
		}

		private void cmdOnDepartment_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			UDS.Components.Database db = new UDS.Components.Database();
			if(selectedID.Trim()!="")
			{
				SqlParameter[] prams = {
										   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,selectedID)
									   };
				db.RunProc("sp_StaffRehab",prams);
			}
			Response.Redirect("Listview.aspx?DeptID="+DeptID+"&displayType="+DisplayType.ToString());			
		}

		private void cmdOffDepartment_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			if(selectedID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.Dimission(selectedID)==true)
				{
					//Response.Write("<script language=javascript>alert('��ְ�ɹ���');</script>");		
					BindGrid();
				}
				person = null;				
			}
			else
				Response.Write("<script language=javascript>alert('��ѡ��Ҫ��ְ����Ա��');</script>");		
		
		}

		private void cmdChangeDepartment_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			if(selectedID.Trim()!="")	
				Response.Redirect("ChangeDepartment.aspx?DeptID="+DeptID+"&StaffIDS="+selectedID+"&DisplayType="+DisplayType.ToString()+"&BackFilePath="+Request.CurrentExecutionFilePath);
			else
				Response.Write("<script language=javascript>alert('��ѡ��Ҫ��ְ����Ա��');</script>");			
		}
	

	}
}
