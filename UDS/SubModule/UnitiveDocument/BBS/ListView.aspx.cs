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

namespace UDS.SubModule.UnitiveDocument.BBS
{
	/// <summary>
	/// ListView 的摘要说明。
	/// </summary>
	public class ListView : System.Web.UI.Page
	{
		protected  int boardid;//boardid
		protected  int hotitemhittimes = 5;
		protected  string classid;
		protected System.Web.UI.WebControls.TextBox txb_PageNo;
		protected System.Web.UI.WebControls.TextBox txb_ItemPerPage;
		protected System.Web.UI.WebControls.Label lbl_totalrecord;
		protected System.Web.UI.WebControls.ImageButton btn_first;
		protected System.Web.UI.WebControls.ImageButton btn_pre;
		protected System.Web.UI.WebControls.Label lbl_curpage;
		protected System.Web.UI.WebControls.Label lbl_totalpage;
		protected System.Web.UI.WebControls.ImageButton btn_next;
		protected System.Web.UI.WebControls.ImageButton btn_last;
		protected System.Web.UI.HtmlControls.HtmlInputButton btn_Go;
		protected System.Web.UI.WebControls.DataGrid ItemList;
		protected System.Web.UI.HtmlControls.HtmlImage image;
		protected System.Web.UI.WebControls.Label bias;
		protected System.Web.UI.WebControls.Label lblBoardName;
		protected System.Web.UI.HtmlControls.HtmlGenericControl mar_bulletin;
		protected System.Web.UI.HtmlControls.HtmlGenericControl sys_bulletin;
		protected System.Web.UI.HtmlControls.HtmlAnchor backlink;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				boardid = (Request.QueryString["BoardID"]==null)?0:Int32.Parse(Request.QueryString["BoardID"]);
				classid   = (Request.QueryString["classID"]!=null && Request.QueryString["classID"]!="")?Request.QueryString["classID"].ToString():"0";
				ViewState["boardid"] = boardid;
				ViewState["classid"] = classid;
				SqlDataReader dr = null;
				BBSClass bbsclass = new BBSClass();
				dr = bbsclass.GetModifyBBSBoard(boardid);
                try
                {
                    while (dr.Read())
                    {
                        lblBoardName.Text = dr["board_name"].ToString();
                    }
                }
                finally
                {
                    
                    if (dr != null)
                    {

                        dr.Close();
                    }
                }
				BindGrid();
				
				backlink.HRef = "Catalog.aspx?ClassID="+Request.QueryString["ClassID"];
			}
			else
			{
				boardid = Int32.Parse(ViewState["boardid"].ToString());
				classid = ViewState["classid"].ToString();
			}
		}

		private void BindGrid()
		{
			SqlDataReader dr = null;
			DataTable dt = new DataTable();
			BBSClass bbsclass = new BBSClass();
			BBSForumItem bbsforumitem = new BBSForumItem();
			bbsforumitem.BoardID = boardid;
            try
            {
                dr = bbsclass.GetBBSForumItem(bbsforumitem);
                dt = Tools.ConvertDataReaderToDataTable(dr);
                //在DataTable的末尾加上空行，使得DataGrid固定行数
                int blankrows = ItemList.PageSize - (dt.Rows.Count % ItemList.PageSize);
                for (int i = 0; i < blankrows; i++)
                {
                    dt.Rows.Add(dt.NewRow());
                }

                ItemList.DataSource = dt.DefaultView;
                ItemList.DataBind();

                string innerstring = "";
                //显示板块公告
                SqlDataReader dr_bulletin = bbsclass.GetBulletin(boardid);
                try
                {
                    while (dr_bulletin.Read())
                    {
                        innerstring += "<a href='display.aspx?ItemID=" + dr_bulletin["item_id"] + "&BoardID=" + boardid + "'title='" + dr_bulletin["content"] + "' target=_blank>" + dr_bulletin["title"].ToString() + "</a> (" + DateTime.Parse(dr_bulletin["send_time"].ToString()).ToString() + ") ";
                    }
                }
                finally
                {
                    dr_bulletin.Close();
                }
                mar_bulletin.InnerHtml = innerstring;

                innerstring = "";
                //显示系统公告
                SqlDataReader dr_sysbulletin = bbsclass.GetSysBulletin();
                try
                {
                    while (dr_sysbulletin.Read())
                    {
                        innerstring += "<a href='display.aspx?ItemID=" + dr_sysbulletin["item_id"] + "&BoardID=" + boardid + "'title='" + dr_sysbulletin["content"] + "' target=_blank>" + dr_sysbulletin["title"].ToString() + "</a>(" + DateTime.Parse(dr_sysbulletin["send_time"].ToString()).ToString() + ")";
                    }
                }
                finally
                {
                    dr_sysbulletin.Close();
                }
                sys_bulletin.InnerHtml = innerstring;
                //对于空纪录不显示图片等其他信息
                for (int i = 0; i < ItemList.Items.Count; i++)
                {

                    if (ItemList.DataKeys[i].ToString() == "")
                    {
                        ItemList.Items[i].FindControl("bias").Visible = false;
                        ItemList.Items[i].FindControl("image").Visible = false;
                    }
                }

                lbl_totalrecord.Text = ItemList.PageCount.ToString();
                lbl_curpage.Text = txb_PageNo.Text = (ItemList.CurrentPageIndex + 1).ToString();
                txb_ItemPerPage.Text = ItemList.PageSize.ToString();
                lbl_totalpage.Text = ItemList.PageCount.ToString();

            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.Message);
                Server.Transfer("../../Error.aspx");
            }
            finally
            {
                
                if (dr != null)
                {

                    dr.Close();
                }
            }
			
			
		}

/*
		private void PagerButtonClick(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//获得LinkButton的参数值
			String arg = ((ImageButton)sender).CommandArgument;
          
			switch(arg)
			{
				case ("next"):
					if (ItemList.CurrentPageIndex < (ItemList.PageCount - 1))
						ItemList.CurrentPageIndex ++;
					break;
				case ("pre"):
					if (ItemList.CurrentPageIndex > 0)
						ItemList.CurrentPageIndex --;
					break;
				case ("first"):
					ItemList.CurrentPageIndex=0;
					break;
				case ("last"):
					ItemList.CurrentPageIndex = (ItemList.PageCount - 1);
					break;
				default:
					//本页值
					ItemList.CurrentPageIndex = Convert.ToInt32(arg);
					break;
			}
			BindGrid();
		}            

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			//页面直接跳转的代码
			if(txb_PageNo.Text.Trim()!="")
			{
				int PageI=Int32.Parse(txb_PageNo.Text.Trim())-1;
				if (PageI >=0 && PageI < (ItemList.PageCount))
					ItemList.CurrentPageIndex = PageI ;
			} 
			BindGrid();
		}

	
		private void txb_ItemPerPage_TextChanged(object sender, System.EventArgs e)
		{
			if(txb_ItemPerPage.Text.Trim()!="")
			{
				int itemPage=Int32.Parse(txb_ItemPerPage.Text.Trim());
				if(itemPage>0)
					ItemList.PageSize =  Int32.Parse(txb_ItemPerPage.Text.Trim());
			}
			BindGrid();
		}
*/
		public void ItemList_PageIndexChanged(object source, 	System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			BindGrid();
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.ItemList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.ItemList_PageIndexChanged);

		}
		#endregion
	}
}
