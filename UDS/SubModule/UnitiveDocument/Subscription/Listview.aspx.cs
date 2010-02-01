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

namespace UDS.SubModule.UnitiveDocument.Subscription
{
	/// <summary>
	/// Listview 的摘要说明。
	/// </summary>
	public class Subscription : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgMySubsciption;
		protected System.Web.UI.WebControls.Button btnDeleteSubscription;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			
			if(!Page.IsPostBack)
			{

				Bangding();
				//lbl_totalrecord.Text =StaffList.PageCount.ToString();
				//lbl_curpage.Text = txb_PageNo.Text = (StaffList.CurrentPageIndex + 1).ToString();
				//txb_ItemPerPage.Text = StaffList.PageSize.ToString();
				//lbl_totalpage.Text = StaffList.PageCount.ToString();
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
			this.btnDeleteSubscription.Click += new System.EventHandler(this.btnDeleteSubscription_Click);
			this.ID = "Subscription";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgMySubsciption.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion
		#region 绑定DBGRID
		private void Bangding()
		{
			SqlDataReader dr=null; //存放人物的数据
			Database mySQL = new Database();
            try
            {
                String UserName;
                UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

                SqlParameter[] parameters = {
											mySQL.MakeInParam("@UserName",SqlDbType.VarChar,255,UserName)
										};

                mySQL.RunProc("sp_GetSubscripitionClass", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                //在DataTable的末尾加上空行，使得DataGrid固定行数
                //			int iBlankRows = dgMySubsciption.PageSize - (dt.Rows.Count % dgMySubsciption.PageSize);
                //			
                //			for (int i = 0; i < iBlankRows; i++)
                //			{
                //				dt.Rows.Add(dt.NewRow()) ;
                //			}

                dgMySubsciption.DataSource = dt.DefaultView;
                dgMySubsciption.DataBind();
                //对于空纪录不显示checkbox
                //
                //			if(dgMySubsciption.CurrentPageIndex  == dgMySubsciption.PageCount -1 )
                //			{
                //				for(int i= (dgMySubsciption.PageSize - iBlankRows)  ;i<dgMySubsciption.Items.Count;i++)
                //				{
                //					dgMySubsciption.Items[i].FindControl("ClassID").Visible = false;
                //				}
                //			}
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
			btnDeleteSubscription.Attributes ["onclick"]="javascript:return confirm('您确认要删除此订阅吗?');";
		}
		#endregion
		private void lbDeleteSubscription_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>location.reload();</script>");
		}
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dgMySubsciption.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dgMySubsciption.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}

		private void btnDeleteSubscription_Click(object sender, System.EventArgs e)
		{
			
			String strIDs=this.GetSelectedItemID("ClassID");
			if(strIDs=="")			
				Response.Write("<script language='javascript'>window.alert('请选择要删除的订阅！');</script>");
			else
			{
				Database mySQL = new Database();
				String UserName;
				UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

				SqlParameter[] parameters = {
												mySQL.MakeInParam("@UserName",SqlDbType.VarChar,300,UserName),
												mySQL.MakeInParam("@ClassIDs",SqlDbType.VarChar,300,strIDs)
											};
			
				try
				{
					mySQL.RunProc("sp_DeleteSubsciption",parameters);
					Response.Write("<script language=javascript>alert('订阅删除成功!');</script>");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../../../Error.aspx");
				}

				Bangding();
			}
				
		}

	}
}
