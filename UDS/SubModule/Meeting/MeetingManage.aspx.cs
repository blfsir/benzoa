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

namespace UDS.SubModule.Meeting
{
	/// <summary>
	/// ManageStaff 的摘要说明。
	/// </summary>
    public class MeetingManage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbMyNote;
        
        protected System.Web.UI.WebControls.DataGrid dbMeetingList;
       
        protected System.Web.UI.WebControls.Button btnSearch;
        protected System.Web.UI.WebControls.Label LabelPageInfo;

        protected System.Web.UI.WebControls.TextBox txtBeginDate;
        protected System.Web.UI.WebControls.TextBox txtEndDate;
        protected System.Web.UI.WebControls.TextBox txtMeetingSubject;
        protected System.Web.UI.WebControls.TextBox txtIsSearch;

        protected System.Web.UI.WebControls.DropDownList ddlMeetingType;
        protected System.Web.UI.WebControls.DropDownList ddlMeetingRoom;

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


			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				//BindGrid();

                DdlBindData();
			}

            
		}

        private void DdlBindData()
        {
            object[] obj = new object[] { };
            DataTable dt = MeetingObject.GetAllMeetingType(obj);
            this.ddlMeetingType.DataSource = dt;
            this.ddlMeetingType.DataTextField = "TypeName";
            this.ddlMeetingType.DataValueField = "ID";
            this.ddlMeetingType.DataBind();
            ListItem item_Type = new ListItem("", "");//加入空项
            this.ddlMeetingType.Items.Insert(0, item_Type);

            dt = MeetingObject.GetAllMeetingRoom(obj);
            this.ddlMeetingRoom.DataSource = dt;
            this.ddlMeetingRoom.DataTextField = "RoomName";
            this.ddlMeetingRoom.DataValueField = "ID";
            this.ddlMeetingRoom.DataBind();
            ListItem item_Romm = new ListItem("", "");//加入空项
            this.ddlMeetingRoom.Items.Insert(0, item_Romm);
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
            //this.lbMyNote.Click += new System.EventHandler(this.lbMyNote_Click);
            //this.lbNoteCollect.Click += new System.EventHandler(this.lbNoteCollect_Click);
            //this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //this.btnShoucang.Click += new System.EventHandler(this.btnShoucang_Click);
            //this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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

		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbMeetingList.CurrentPageIndex = e.NewPageIndex;

            
                SearchBindGrid();
		}
		#endregion


		private void btn_Search_Click(object sender, System.EventArgs e)
		{
            SearchBindGrid();
		}

        /// <summary>
        /// 查询数据绑定
        /// </summary>
        private void SearchBindGrid()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            string strMeetingType = this.ddlMeetingType.SelectedValue;
            string strMeetingRoom = this.ddlMeetingRoom.SelectedValue;

            this.txtBeginDate.Text = Request.Form["txtBeginDate"].ToString();
            this.txtEndDate.Text = Request.Form["txtEndDate"].ToString();

            string strBeginDate = Request.Form["txtBeginDate"].ToString(); //this.txtBeginDate.Text.Trim();
            string strEndDate = Request.Form["txtEndDate"].ToString(); //this.txtEndDate.Text.Trim();
            string strMeetingSubject = "%" + this.txtMeetingSubject.Text.Trim() + "%";

            object[] paramsValue = new object[] { strUserid, strMeetingType, strMeetingRoom, strBeginDate, strEndDate, strMeetingSubject };

            DataTable dt = MeetingObject.SearchMeeting(paramsValue);

            this.dbMeetingList.DataSource = dt;//.DefaultView;
            this.dbMeetingList.DataBind();

            LabelPageInfo.Text = "当前（第" + (dbMeetingList.CurrentPageIndex + 1).ToString() + "页 共" + dbMeetingList.PageCount.ToString() + "页）";
        }
	}
}
