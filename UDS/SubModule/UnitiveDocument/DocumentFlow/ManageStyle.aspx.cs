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


namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// ManageStyle 的摘要说明。
	/// </summary>
	public class ManageStyle : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdNewStyle;
		protected System.Web.UI.WebControls.DataGrid dgStyleList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				Bangding();				
			}

		}

		#region 绑定DBGRID
		private void Bangding()
		{
			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();
            try
            {
                SqlParameter[] parameters = {
											mySQL.MakeInParam("@StyleID",SqlDbType.Int ,4,0)
										};

                mySQL.RunProc("sp_Flow_GetStyle", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                dgStyleList.DataSource = dt.DefaultView;
                dgStyleList.DataBind();
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
		}
		#endregion
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgStyleList.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion
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
			this.cmdNewStyle.Click += new System.EventHandler(this.cmdNewStyle_Click);
			this.dgStyleList.SelectedIndexChanged += new System.EventHandler(this.dgStyleList_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdNewStyle_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("EditStyle.aspx");
		}

		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dgStyleList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dgStyleList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}
		public void MyDataGrid_Delete(object sender,DataGridCommandEventArgs e)
		{
			string StyleID = dgStyleList.DataKeys[e.Item.ItemIndex].ToString();
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.DeleteStyle(Int32.Parse(StyleID),Server.MapPath("."));
			df = null;
			Bangding();	

		}
		private void cmdDeleteStyle_Click(object sender, System.EventArgs e)
		{
			string StyleID = GetSelectedItemID("cboStyleID");
						
			if(StyleID!="")
			{
				if(StyleID.IndexOf(",")<0)
				{
					UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
					df.DeleteStyle(Int32.Parse(StyleID),Server.MapPath("."));
					df = null;
					Bangding();	
				}
				else
					Response.Write("<script laguage='javascript'>alert('只能删除一个！');</script>");
			}
			else
				Response.Write("<script laguage='javascript'>alert('请选择一个要删除的样式！');</script>");


				
		}

		private void dgStyleList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
