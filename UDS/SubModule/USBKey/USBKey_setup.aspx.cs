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
using UDS.Components;
using System.Data.SqlClient;

namespace UDS.SubModule.USBKey
{
	/// <summary>
	/// USBKey_setup ��ժҪ˵����
	/// </summary>
	public class USBKey_setup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbOffLine;
		protected System.Web.UI.WebControls.LinkButton lbOnline;
		protected System.Web.UI.WebControls.CheckBox cb_selectAll;
		protected System.Web.UI.WebControls.Button cmdUsR_key;
		protected System.Web.UI.WebControls.Button cmdNotUse_key;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;

		//�鿴�Ƿ���USBKEY�Ĳ���,0��,1û��
		public static int DisplayType;
	
		#region ҳ���ʼ��
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			cb_selectAll.Attributes["onclick"]="return selectAll();";
			cmdUsR_key.Attributes.Add("Onclick","javascript:return confirm('�Ƿ���ѡ�е��˿�ʼʹ��USB_Key��');");
			cmdNotUse_key.Attributes.Add("Onclick","javascript:return confirm('�Ƿ���ѡ�е���ֹͣʹ��USB_Key��');");
			if(Request.QueryString["DisplayType"]!=null)
			{
				if(Request.QueryString["DisplayType"].ToString()!="")
					DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
				else
					DisplayType = 1;
			}
			else
				DisplayType =1;

			if(DisplayType==1)
			{	
				cmdNotUse_key.Visible =true;
				cmdUsR_key.Visible =false;

			}
			else
			{				
				cmdNotUse_key.Visible= false;
				cmdUsR_key.Visible =true;
			}
			if(!Page.IsPostBack)
			{		
				BindGrid();
			}
			
		}
		#endregion

		#region ����DataGrid���checked��ID
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
		#endregion

		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion

		#region DataGrid���ݰ�
		private void BindGrid()
		{
			SqlDataReader dr=null; //������������
			Database db = new Database();
            try
            {
                SqlParameter[] prams = {
									   db.MakeInParam("@StaffType",SqlDbType.Bit,1,DisplayType)
								   };
                db.RunProc("sp_GetStaffisneedkey", prams, out dr);
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                dbStaffList.DataSource = dt.DefaultView;
                dbStaffList.DataBind();
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
                
            }
		}
		#endregion

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
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
			this.cmdUsR_key.Click += new System.EventHandler(this.cmdUsR_key_Click);
			this.cmdNotUse_key.Click += new System.EventHandler(this.cmdNotUse_key_Click);
			this.dbStaffList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbStaffList_ItemCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ѡ��ʹ��KEY��Ա��
		private void lbOnline_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("USBKey_setup.aspx?DisplayType=0");
		}
		#endregion

		#region ѡ��ʹ��KEY��Ա��
		private void lbOffLine_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("USBKey_setup.aspx?DisplayType=1");
		}
		#endregion

		#region ȡ��ʹ��KEY
		private void cmdNotUse_key_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			if(selectedID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.SetIsNeedKey(selectedID,false)==true)
				{	
					BindGrid();
				}
				person = null;				
			}
			else
				Response.Write("<script language=javascript>alert('��û��ѡ���κ���Ա��');</script>");	
		}
		#endregion

		#region ʹ��KEY
		private void cmdUsR_key_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			if(selectedID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.SetIsNeedKey(selectedID,true)==true)
				{	
					//DisplayType=0;
					BindGrid();
				}
				person = null;				
			}
			else
				Response.Write("<script language=javascript>alert('��û��ѡ���κ���Ա��');</script>");
		}
		#endregion

		#region �����ֶ��ı�DataGrid���п�
		private void dbStaffList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				if(true)//�������ı��п�
				{
					for(int i=0;i<e.Item.Cells.Count;i++)
					{
						e.Item.Cells[i].Attributes.Add("onmousemove","SyDG_moveOnTd(this)");
						e.Item.Cells[i].Attributes.Add("onmousedown","SyDG_downOnTd(this)");
						e.Item.Cells[i].Attributes.Add("onmouseup","this.mouseDown=false");
						e.Item.Cells[i].Attributes.Add("onmouseout","this.mouseDown=false");
					}
				}
             }

		}
		#endregion

	}
}
