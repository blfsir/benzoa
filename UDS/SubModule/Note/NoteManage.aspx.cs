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
using BLL;

namespace UDS.SubModule.Note
{
	/// <summary>
	/// ManageStaff 的摘要说明。
	/// </summary>
    public class NoteManage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbMyNote;
        protected System.Web.UI.WebControls.LinkButton lbNoteCollect;
        protected System.Web.UI.WebControls.DataGrid dbNoteList;
        protected System.Web.UI.WebControls.Button btnAdd;
        protected System.Web.UI.WebControls.Button btnShoucang;
        protected System.Web.UI.WebControls.Button btnSearch;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.Label LabelPageInfo;
        protected System.Web.UI.HtmlControls.HtmlTableRow tr_Tj;
        protected System.Web.UI.HtmlControls.HtmlTableCell td_title;

        protected System.Web.UI.WebControls.TextBox txtBeginDate;
        protected System.Web.UI.WebControls.TextBox txtEndDate;
        protected System.Web.UI.WebControls.TextBox txtContents;
        protected System.Web.UI.WebControls.TextBox txtIsSearch;
		
		public int DisplayType;
		
		protected static string Username;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                {
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                }
                else
                {
                    DisplayType = 0;
                }
            }
            else
            {
                DisplayType = 0;
            }

            if (DisplayType == 0)
            {
                this.td_title.InnerHtml = "<font color=\"#006699\">我的便签</font>";
                this.tr_Tj.Visible = false;
                this.btnAdd.Visible = true;
                this.btnShoucang.Visible = true;

                this.dbNoteList.Columns[3].Visible = true;
            }
            else if (DisplayType==1)//便签收藏
            {
                this.td_title.InnerHtml = "<font color=\"#006699\">便签收藏</font>";
                this.tr_Tj.Visible = true;
                this.btnAdd.Visible = false;
                this.btnShoucang.Visible = false;

                this.dbNoteList.Columns[3].Visible = false;
            }

			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				BindGrid();
			}

            btnDelete.Attributes.Add("OnClick","return confirm('确认删除？');");

            
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
            this.lbMyNote.Click += new System.EventHandler(this.lbMyNote_Click);
            this.lbNoteCollect.Click += new System.EventHandler(this.lbNoteCollect_Click);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnShoucang.Click += new System.EventHandler(this.btnShoucang_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //this.cmdChangePosition.Click += new System.EventHandler(this.cmdChangePosition_Click);
            this.btnSearch.Click += new System.EventHandler(this.btn_Search_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public string GetSelectImage(string NormalImg,string SelectedImg,int selected,int position)
		{
			if(selected==position)
				return SelectedImg;
			else
				return NormalImg;
		}

        /// <summary>
        /// 数据绑定
        /// </summary>
		private void BindGrid()
		{
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);
            //if (DisplayType == 0)
            //{
                object[] paramsValue = new object[] { strUserid, DisplayType };

                DataTable dt = NoteObject.GetNoteListByUserID(paramsValue);

                this.dbNoteList.DataSource = dt;//.DefaultView;
                this.dbNoteList.DataBind();
            //}
            //else
            //{
            //    string strBeginDate = this.txtBeginDate.Text.Trim();
            //    string strEndDate = this.txtEndDate.Text.Trim();
            //    string strContents = "%" +this.txtContents.Text.Trim()+ "%";

            //    object[] paramsValue = new object[] { strUserid, strBeginDate, strEndDate, strContents };

            //    DataTable dt = NoteObject.SearchNote(paramsValue);

            //    this.dbNoteList.DataSource = dt;//.DefaultView;
            //    this.dbNoteList.DataBind();
            //}

            LabelPageInfo.Text = "当前（第" + (dbNoteList.CurrentPageIndex + 1).ToString() + "页 共" + dbNoteList.PageCount.ToString() + "页）";
		}
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbNoteList.CurrentPageIndex = e.NewPageIndex;

            if (this.txtIsSearch.Text == "0")
            {
                BindGrid();
            }
            else
            {
                SearchBindGrid();
            }
		}
		#endregion
        private void lbMyNote_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NoteManage.aspx?DisplayType=0");
		}

        private void lbNoteCollect_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NoteManage.aspx?DisplayType=1");
		}

		private void dbStaffList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

        /// <summary>
        /// 获取选择的ID
        /// </summary>
        /// <param name="controlID"></param>
        /// <returns></returns>
		private string GetSelectedItemID(string controlID)
		{
			string selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dbNoteList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
                    selectedID += dbNoteList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}


        private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NewNote.aspx?ReturnPage=1");
		}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, System.EventArgs e)
		{
            string strNoteID = this.GetSelectedItemID("chkNote_ID");
            if (strNoteID != "")
            {
                object[] Params = null;// new object[] { null, strContents, strUserid };
                string[] strNoteIDs = strNoteID.Split(',');

                for (int i = 0; i < strNoteIDs.Length; i++)
                {
                    string strID = strNoteIDs[i];
                    Params = new object[] { null, strID };
                    NoteObject.DeleteNote(Params);
                }

                if (this.txtIsSearch.Text == "0")
                {
                    BindGrid();
                }
                else
                {
                    SearchBindGrid();
                }
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('请选择要删除的便签！');</script>");
            }
		}

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShoucang_Click(object sender, System.EventArgs e)
        {
            string strNoteID = this.GetSelectedItemID("chkNote_ID");
            if (strNoteID != "")
            {
                object[] Params = null;// new object[] { null, strContents, strUserid };
                string[] strNoteIDs = strNoteID.Split(',');

                for (int i = 0; i < strNoteIDs.Length; i++)
                {
                    string strID = strNoteIDs[i];
                    Params = new object[] { null, strID };
                    NoteObject.CollectNote(Params);
                }

                if (this.txtIsSearch.Text == "0")
                {
                    BindGrid();
                }
                else
                {
                    SearchBindGrid();
                }
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('请选择要收藏的便签！');</script>");
            }
        }

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
            this.txtIsSearch.Text = "1";
            SearchBindGrid();
		}

        /// <summary>
        /// 查询数据绑定
        /// </summary>
        private void SearchBindGrid()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);
            this.txtBeginDate.Text = Request.Form["txtBeginDate"].ToString();
            this.txtEndDate.Text = Request.Form["txtEndDate"].ToString();

            string strBeginDate = Request.Form["txtBeginDate"].ToString(); //this.txtBeginDate.Text.Trim();
            string strEndDate = Request.Form["txtEndDate"].ToString(); //this.txtEndDate.Text.Trim();
            string strContents = "%" + this.txtContents.Text.Trim() + "%";

            object[] paramsValue = new object[] { strUserid, strBeginDate, strEndDate, strContents };

            DataTable dt = NoteObject.SearchNote(paramsValue);

            this.dbNoteList.DataSource = dt;//.DefaultView;
            this.dbNoteList.DataBind();

            LabelPageInfo.Text = "当前（第" + (dbNoteList.CurrentPageIndex + 1).ToString() + "页 共" + dbNoteList.PageCount.ToString() + "页）";
        }
	}
}
