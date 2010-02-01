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

namespace UDS.SubModule.AssginRule
{
	/// <summary>
	/// RightListView 的摘要说明。
	/// </summary>
	public class RightListView : System.Web.UI.Page
	{
		public string strObjID;
		public string DisplayType;
		protected System.Web.UI.HtmlControls.HtmlInputButton btn_AddRight;
		protected System.Web.UI.HtmlControls.HtmlInputButton btn_DelRight;
		protected System.Web.UI.WebControls.DataGrid RightsGrid;
	
		/// <summary>
		/// 得到datagrid checkbox的value
		/// </summary>
		/// <param name="controlID">checkbox控件的ID</param>
		/// <returns>该checkbox的值</returns>
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in RightsGrid.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += RightsGrid.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			strObjID = Request.QueryString["ObjID"].ToString();
			DisplayType = Request.QueryString["DisplayType"].ToString();
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				BindGrid();
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
			this.RightsGrid.SelectedIndexChanged += new System.EventHandler(this.RightsGrid_SelectedIndexChanged);
			this.btn_DelRight.ServerClick += new System.EventHandler(this.btn_DelRight_ServerClick);
			this.btn_AddRight.ServerClick += new System.EventHandler(this.btn_AddRight_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			RightsGrid.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion

		public void BindGrid()
		{
			SqlDataReader dr=null; //存放权限数据
			string spName;//存储过程名
			spName = "";
			Database db = new Database();
			SqlParameter[] prams = new SqlParameter[1];
            try
            {
                switch (DisplayType)
                {
                    case "0":
                        prams[0] = db.MakeInParam("@PositionID", SqlDbType.Int, 4, Int32.Parse(strObjID));
                        spName = "sp_GetPositionRightList";
                        break;
                    case "1":
                        prams[0] = db.MakeInParam("@Teamid", SqlDbType.Int, 4, Int32.Parse(strObjID));
                        spName = "sp_GetTeamRightList";
                        break;
                    case "2":
                        prams[0] = db.MakeInParam("@RoleID", SqlDbType.Int, 4, Int32.Parse(strObjID));
                        spName = "sp_GetRoleRightList";
                        break;
                    default:
                        break;
                    //错误处理
                }

                db.RunProc(spName, prams, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                RightsGrid.DataSource = dt.DefaultView;
                RightsGrid.DataBind();
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


		private void btn_DelRight_ServerClick(object sender, System.EventArgs e)
		{
			string IDs=GetSelectedItemID("cb_RightID").Trim();

			//得到选中的datagrid的checkbox的value
			if(IDs!="")
			{

				UDS.Components.AssignRights ar = new UDS.Components.AssignRights();

				ar.DeleteRight(IDs);

				ar =	null;

				Response.Redirect("RightListView.aspx?ObjID="+strObjID+"&DisplayType="+DisplayType);
			}
		}

		private void btn_AddRight_ServerClick(object sender, System.EventArgs e)
		{
			Response.Redirect("Treeview.aspx?SrcID="+strObjID+"&DisplayType="+DisplayType);
		}

		private void RightsGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}            
	}
}
