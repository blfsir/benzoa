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
using System.Data.SqlClient;
using UDS.Components;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// DisplayTacheMember 的摘要说明。
	/// </summary>
	public class DisplayTacheMember : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.LinkButton lbReceiver;
		protected System.Web.UI.WebControls.LinkButton lbSignIner;
		protected System.Web.UI.WebControls.LinkButton lbUnSignIner;
		protected System.Web.UI.WebControls.LinkButton lbAllMember;
		protected System.Web.UI.WebControls.LinkButton lbPostiler;		
		private   long DocID;
		private   long FlowID;
		private   long StepID;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;
		public int  DisplayType=0;
		public int ReturnPage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			DocID			= Request.QueryString["DocID"]			==null?0:Int32.Parse(Request.QueryString["DocID"].ToString());
			FlowID			= Request.QueryString["FlowID"]			==null?0:Int32.Parse(Request.QueryString["FlowID"].ToString());
			StepID			= Request.QueryString["StepID"]			==null?0:Int32.Parse(Request.QueryString["StepID"].ToString());
			DisplayType		= Request.QueryString["DisplayType"]	==null?0:Int32.Parse(Request.QueryString["DisplayType"].ToString());
			ReturnPage		= Request.QueryString["ReturnPage"]		==null?1:Int32.Parse(Request.QueryString["ReturnPage"].ToString());
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
			this.lbAllMember.Click += new System.EventHandler(this.lbAllMember_Click);
			this.lbReceiver.Click += new System.EventHandler(this.lbReceiver_Click);
			this.lbSignIner.Click += new System.EventHandler(this.lbSignIner_Click);
			this.lbUnSignIner.Click += new System.EventHandler(this.lbUnSignIner_Click);
			this.lbPostiler.Click += new System.EventHandler(this.lbPostiler_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void BindGrid()
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

			if(DocID==0)
			{
				lbReceiver.Enabled		= false;
				lbSignIner.Enabled		= false;
				lbUnSignIner.Enabled	= false;
				lbPostiler.Enabled		= false;
			}

			
			DataTable dt;

			switch(DisplayType)
			{
				case 0:
					if(DocID>0)
						df.GetStaffInStep(DocID,out dt);
					else
					{
						df.GetStaffInStep(FlowID,StepID,out dt);
					}
					break;
				case 1:
					df.GetReceiver(DocID,out dt);
					break;
				case 2:
					df.GetSignIner(DocID,out dt);
					break;
				case 3:
					df.GetUnSignIner(DocID,out dt);
					break;
				case 4:
					df.GetPostiler(DocID,out dt);
					break;
				default:
					dt = null;
					break;					
			}
			if(dt !=null)
			{
				dbStaffList.DataSource = dt.DefaultView;
				dbStaffList.DataBind();
			}

		}

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
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion

		private void lbAllMember_Click(object sender, System.EventArgs e)
		{
			if(DocID>0)
				Server.Transfer("DisplayTacheMember.aspx?DocID=" + DocID.ToString()+ "&DisplayType=0"  + "&ReturnPage=" + ReturnPage.ToString());
		}

		private void lbReceiver_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DisplayTacheMember.aspx?DocID=" + DocID.ToString() + "&DisplayType=1" + "&ReturnPage=" + ReturnPage.ToString());		
		}

		private void lbSignIner_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DisplayTacheMember.aspx?DocID=" + DocID.ToString() + "&DisplayType=2"  + "&ReturnPage=" + ReturnPage.ToString());		
		}

		private void lbUnSignIner_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DisplayTacheMember.aspx?DocID=" + DocID.ToString() + "&DisplayType=3"  + "&ReturnPage=" + ReturnPage.ToString());		
		}

		private void lbPostiler_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DisplayTacheMember.aspx?DocID=" + DocID.ToString() + "&DisplayType=4"  + "&ReturnPage=" + ReturnPage.ToString());
		}
	}
}
