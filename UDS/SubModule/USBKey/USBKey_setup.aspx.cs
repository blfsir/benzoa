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
	/// USBKey_setup 的摘要说明。
	/// </summary>
	public class USBKey_setup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbOffLine;
		protected System.Web.UI.WebControls.LinkButton lbOnline;
		protected System.Web.UI.WebControls.CheckBox cb_selectAll;
		protected System.Web.UI.WebControls.Button cmdUsR_key;
		protected System.Web.UI.WebControls.Button cmdNotUse_key;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;

		//查看是否有USBKEY的参数,0有,1没有
		public static int DisplayType;
	
		#region 页面初始化
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			cb_selectAll.Attributes["onclick"]="return selectAll();";
			cmdUsR_key.Attributes.Add("Onclick","javascript:return confirm('是否让选中的人开始使用USB_Key？');");
			cmdNotUse_key.Attributes.Add("Onclick","javascript:return confirm('是否让选中的人停止使用USB_Key？');");
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

		#region 遍历DataGrid获得checked的ID
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
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

		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion

		#region DataGrid数据绑定
		private void BindGrid()
		{
			SqlDataReader dr=null; //存放人物的数据
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

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
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
			this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
			this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
			this.cmdUsR_key.Click += new System.EventHandler(this.cmdUsR_key_Click);
			this.cmdNotUse_key.Click += new System.EventHandler(this.cmdNotUse_key_Click);
			this.dbStaffList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dbStaffList_ItemCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 选择使用KEY的员工
		private void lbOnline_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("USBKey_setup.aspx?DisplayType=0");
		}
		#endregion

		#region 选择不使用KEY的员工
		private void lbOffLine_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("USBKey_setup.aspx?DisplayType=1");
		}
		#endregion

		#region 取消使用KEY
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
				Response.Write("<script language=javascript>alert('您没有选择任何人员！');</script>");	
		}
		#endregion

		#region 使用KEY
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
				Response.Write("<script language=javascript>alert('您没有选择任何人员！');</script>");
		}
		#endregion

		#region 可以手动改变DataGrid的列宽
		private void dbStaffList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				if(true)//如果允许改变列宽
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
