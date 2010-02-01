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

namespace UDS.SubModule.UnitiveDocument.BBS.Search
{
	/// <summary>
	/// index 的摘要说明。
	/// </summary>
	public class index : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTable tbl_Search;
		protected System.Web.UI.WebControls.DataGrid dgrd_Result;
		protected System.Web.UI.WebControls.TextBox tbx_Key;
		protected System.Web.UI.WebControls.RadioButton rbtn_author;
		protected System.Web.UI.WebControls.RadioButton rbtn_Title;
		protected System.Web.UI.WebControls.TextBox tbx_Time;
		protected System.Web.UI.WebControls.DropDownList ddl_Time;
		protected System.Web.UI.WebControls.Button btn_OK;
		protected System.Web.UI.WebControls.DropDownList dll_Board;
		
		private SqlDataReader dr_board = null; 
		protected int hotitemhittimes = 5;
		protected string classid;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				classid = Request.QueryString["classid"].ToString();
				ViewState["classid"] = classid;
				BindBoard();
			}
			else
			{
				classid = ViewState["classid"].ToString();
			}
		}

		private void BindBoard()
		{
			UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();
			if(Request.Cookies["UDSBBSAdmin"].Value=="1")
				dll_Board.DataSource  = bbs.GetAllBBSBoard();
			else
				dll_Board.DataSource  = bbs.GetBBSBoard( Server.UrlDecode(Request.Cookies["UserName"].Value));

			dll_Board.DataTextField = "Board_Name";
			dll_Board.DataValueField = "Board_ID";
			dll_Board.DataBind();

			dll_Board.Items.Insert(0,new ListItem("全部论坛","0"));
		}

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
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			tbl_Search.Visible = false;
			dgrd_Result.Visible = true;

			SqlDataReader dr_result = null;
			UDS.Components.BBSClass bbs = new UDS.Components.BBSClass();
			BBSSearchOption option = new BBSSearchOption();
			option.searchtype = (rbtn_author.Checked)?BBSSearchType.author:BBSSearchType.title;
			switch(ddl_Time.SelectedValue)
			{
				case "0":
					option.TimeBound = TimeSpan.MaxValue;
					break;
				case "d":
					option.TimeBound = new TimeSpan(Int32.Parse((tbx_Time.Text.Trim()=="")?"1":tbx_Time.Text.Trim()),0,0,0);
					break;
				case "w":
					option.TimeBound = new TimeSpan(Int32.Parse((tbx_Time.Text.Trim()=="")?"1":tbx_Time.Text.Trim())*7,0,0,0);
					break;
				case "m":
					option.TimeBound = new TimeSpan(Int32.Parse((tbx_Time.Text.Trim()=="")?"1":tbx_Time.Text.Trim())*30,0,0,0);
					break;
				case "y":
					option.TimeBound = new TimeSpan(Int32.Parse((tbx_Time.Text.Trim()=="")?"1":tbx_Time.Text.Trim())*365,0,0,0);
					break;
			}

			option.BoardID = Int32.Parse(dll_Board.SelectedValue);

			UDS.Components.BBSClass bbs1 = new UDS.Components.BBSClass();
			if(Request.Cookies["UDSBBSAdmin"].Value=="1")
				dr_board  = bbs1.GetAllBBSBoard();
			else
				dr_board  = bbs1.GetBBSBoard( Server.UrlDecode(Request.Cookies["UserName"].Value));

			dr_result = bbs.Find(tbx_Key.Text.Trim(),option,UDS.Components.Tools.ConvertDataReaderToDataTable(dr_board));
			DataTable dt_result = UDS.Components.Tools.ConvertDataReaderToDataTable(dr_result);
			dgrd_Result.DataSource = dt_result.DefaultView;
			dgrd_Result.DataBind();
			
		}
	}
}
