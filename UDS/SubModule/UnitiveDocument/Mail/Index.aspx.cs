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

namespace UDS.SubModule.UnitiveDocument.Mail
{
	/// <summary>
	/// Index 的摘要说明。
	/// </summary>
	public class MailList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgMailList;
		protected static string SortRule="Desc",SortBy="MailSendDate";
		protected int FolderType=1;
		protected HttpCookie UserCookie;
		protected System.Web.UI.WebControls.DropDownList listFolderType;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Button btnExtPopSetup;
		protected System.Web.UI.WebControls.Button btnBeginReceive;
		protected System.Web.UI.WebControls.DropDownList listExtMail;
		
		
		protected static string CurrentPageIndex="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 设置接收值
			UserCookie = Request.Cookies["Username"];
			CurrentPageIndex = Request.QueryString["CurrentPageIndex"]!=null?Request.QueryString["CurrentPageIndex"]:"";
			if (Request.QueryString["FolderType"] !=null)
			{
				//FolderType = Int32.Parse();
				Session["FolderType"] = (Request.QueryString["FolderType"].ToString()!="")?Request.QueryString["FolderType"].ToString():"1";
			}
			else
			{
				Session["FolderType"] = "1";
			}
			
			if(Session["FolderType"].ToString()=="3") this.btnClear .Visible = true;
			if(Session["FolderType"].ToString()=="4") 
			{
				this.btnExtPopSetup .Visible = true;
				this.listExtMail.Visible	 = true;
				this.btnBeginReceive.Visible = true;
			}
			// 设置结束
		
			if(!IsPostBack)
			{	
			
				PopulateListView();
				BindGrid();
			
			}
			
			
		}
	
		public string GetRealNameStr(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameStrByUsernameStr(Username,3);
			else
				return "";
		}

		#region 将数据排序
		/// <summary>
		/// 将信件按照指定字段进行排序
		/// </summary>
		protected void DataGrid_Sort(Object Src, DataGridSortCommandEventArgs E) 
		{	
			
			SortRule			  = (SortRule=="Desc")?"Asc":"Desc";
			SortBy				  = E.SortExpression ;		
//			MailClass mail		  = new MailClass();
//			DataTable datatable	  = mail.GetMails(FolderType,UserCookie.Value.ToString());
//			DataView Source		  = datatable.DefaultView;
//			Source.Sort			  = SortBy+" "+ SortRule;
//			mail				  = null;
//			dgMailList.DataSource = Source;
//			dgMailList.DataBind();
			BindGrid();
			
		}
		#endregion

		#region 将邮件转移至指定信箱
		public void FolderListChange(object sender, System.EventArgs e)
		{					
			bool sqlFlag		  = true;
			string sql			  = "";
			int FolderType        = Int32.Parse(this.listFolderType.SelectedItem.Value); //设置转移目标
			MailClass mail		  = new MailClass();
			HttpCookie UserCookie = Request.Cookies["Username"];
			foreach(DataGridItem dgi in dgMailList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMailList.DataKeys[i].ToString();
					if (sqlFlag)
					{
						sql+=" MailID= "+id;
						sqlFlag=false;
					}
					else
					{
						sql+=" or";
						sql+=" MailID= "+id;
					}
				}
			}
			//选择为空
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('请选择邮件!');window.location='Index.aspx?FolderType="+FolderType+"';</script>");
			}
			else
			{
				if(mail.MailRemove(FolderType,sql))
				{
					Response.Write("<script language=javascript>alert('邮件移动成功!');window.location='Index.aspx?FolderType="+FolderType+"';</script>");
				}
				else
				{
					Server.Transfer("../../Error.aspx");
				}
			}
			mail=null;
		}
		#endregion
		
			
		#region 数据绑定至DataGrid
		/// <summary>
		/// 将某用户的邮件取出绑定至DataGrid
		/// </summary>
		protected void BindGrid() 
		{   
			MailClass mail		  = new MailClass();
            DataTable datatable = mail.GetMails(Int32.Parse(Session["FolderType"].ToString()), Server.UrlDecode(Request.Cookies["UserName"].Value));
			DataView source       = datatable.DefaultView;
			FolderType = Int32.Parse(Session["FolderType"].ToString());
//			for( int i=0 ;i<datatable.Columns.Count;i++)
//			{
//				if(datatable.Columns[i].ColumnName==SortBy)
//				{
//					SortByIndex=i;
//					break;
//				}
//			}
			
			if(CurrentPageIndex!="") dgMailList.CurrentPageIndex = Int32.Parse(CurrentPageIndex);
			if(FolderType!=4)
			{
				source.Sort			  = SortBy+" "+ SortRule;
				
				
			}
			dgMailList.DataSource=source;	
			dgMailList.DataBind(); 
			
		//	Response.Write(CurrentPageIndex);
			//　根据邮箱类别显示和隐藏列
			switch (FolderType)
			{
				case 1:
					dgMailList.Columns[3].Visible = false; //　隐藏收件人
					dgMailList.Columns[4].Visible = false; //　隐藏所有收件人
					break;
				case 2:
					dgMailList.Columns[2].Visible = false; //　隐藏发件人
					dgMailList.Columns[3].Visible = false;  //　隐藏收件人
					//dgMailList.Columns[4].Visible = true; //　隐藏所有收件人
					break;
				case 3:
					dgMailList.Columns[2].Visible = true; //　显示发件人
					dgMailList.Columns[3].Visible = false; //　隐藏收件人
					dgMailList.Columns[4].Visible = false; //　隐藏所有收件人
					this.btnClear .Attributes["onclick"] = "javascript:return confirm('您确认要清空吗?');";
					break;
				case 4:
					dgMailList.Columns[4].Visible = false;  //　隐藏收件人
					dgMailList.Columns[6].Visible = false; //　隐藏所属项目
					break;
				default: 
					
					break;
			}

			if(FolderType!=4)
			{
				DataView dataView  = new DataView();
				dataView		   = datatable.DefaultView;
				dataView.RowFilter = "MailReadFlag = false";	
				this.lblMsg.Text = datatable.Rows.Count+"/<font color=red>"+dataView.Count.ToString()+"</font>未读";
				this.lblMsg .Text+= (SortRule=="Desc")?"&nbsp;&nbsp;▼":"&nbsp;&nbsp;▲";
			}
			if (datatable.Rows.Count !=0)
			{
				this.btnDelete.Visible =true;
				this.btnDelete.Attributes ["onclick"]="javascript:return confirm('您确认要删除吗?');";
			}
			mail	  = null;
			datatable = null;
		} 
		
		#endregion

		public void DataGrid_ItemDataBinding(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
			
//			int index = 0;
//			switch (SortBy) {
//				case "ClassName":
//					index = 4;
//					break;
//				case "MailSendDate":
//					index = 6;
//					break;
//			}
//		
//			if (e.Item.ItemType == ListItemType.Header)
//			{
//				//e.Item.Cells[index].Text = (SortRule=="Desc")?e.Item.Cells[index].Text+"▼":e.Item.Cells[index].Text+"▲";
//				e.Item.Cells[index].Text = "dsfsdfsd";
//			}


		}
		
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgMailList.CurrentPageIndex = e.NewPageIndex;
			CurrentPageIndex = dgMailList.CurrentPageIndex.ToString();
			BindGrid();
		}
		#endregion

		#region 初始化下拉列表框
		/// <summary>
		/// 对下拉列表进行初始化
		/// </summary>
		private void PopulateListView() 
		{
			listFolderType.Items.Clear();
			listFolderType.Items.Add(new ListItem("放入邮件夹...","0"));
			listFolderType.Items.Add(new ListItem("收件夹","1"));
			listFolderType.Items.Add(new ListItem("已经发送的邮件","2"));
			listFolderType.Items.Add(new ListItem("废件夹","3"));
			if(this.listExtMail.Visible)
			{
				try
				{
					MailClass mail = new MailClass();
					this.listExtMail.DataTextField = "Title";
					this.listExtMail.DataValueField = "OrderID";
					this.listExtMail.DataSource = mail.ExtGetAvaSetting(Server.UrlDecode(Request.Cookies["UserName"].Value));
					this.listExtMail.DataBind();
					this.listExtMail.Items.Insert(0,"全部外部邮箱");
					this.listExtMail.Items.FindByText("全部外部邮箱").Value="0";
					this.listExtMail.SelectedIndex=0;
				}
				catch(Exception ex)
				{
					UDS.Components.Error.Log(ex.ToString());
					Server.Transfer("../../Error.aspx");
				}
			}
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
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnBeginReceive.Click += new System.EventHandler(this.btnBeginReceive_Click);
			this.btnExtPopSetup.Click += new System.EventHandler(this.btnExtPopSetup_Click);
			this.dgMailList.SelectedIndexChanged += new System.EventHandler(this.dgMailList_SelectedIndexChanged);
			this.ID = "MailList";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		
		private void dgMailList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			MailClass mail		  = new MailClass();
			UserCookie = Request.Cookies["Username"];
			try
			{

                if (mail.FolderClear(Server.UrlDecode(Request.Cookies["UserName"].Value), 3))
				{
					Response.Write("<script language=javascript>alert('邮件删除成功!');window.location='Index.aspx?FolderType="+Session["FolderType"].ToString()+"';</script>");
				}
				else
				{
					Server.Transfer("../../Error.aspx");
				}
			}
			catch(Exception ex)
			{
				UDS.Components.Error .Log(ex.ToString());
				Server.Transfer("../../Error.aspx");
			}
			mail=null;
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			MailClass mail		  = new MailClass();
			bool sqlFlag		  = true;
			string sql			  = "";
			foreach(DataGridItem dgi in dgMailList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgMailList.DataKeys[i].ToString();				
					if (sqlFlag)
					{
						sql+=" MailID= "+id;
						sqlFlag=false;
					}
					else
					{
						sql+=" or";
						sql+=" MailID= "+id;
					}
				}
			}
			//选择为空
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('请选择邮件!');window.location='Index.aspx?FolderType="+Session["FolderType"].ToString()+"';</script>");
			}
			else
			{
				try
				{
					
					if(Session["FolderType"].ToString()=="3")
					{
						mail.MailDelete(sql,1);//彻底删除
					}
					else
					{
						mail.MailDelete(sql,0);//丢到废件箱
					}
				
					Response.Write("<script language=javascript>alert('邮件删除成功!');window.location='Index.aspx?FolderType="+Session["FolderType"].ToString()+"';</script>");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../../Error.aspx");
				}
			}
			mail=null;
		}

		private void btnExtPopSetup_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("External/SetupNavi.aspx");
		}

		private void btnBeginReceive_Click(object sender, System.EventArgs e)
		{
			MailClass mail = new MailClass();
			string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			int OrderID = Int32.Parse(this.listExtMail.SelectedItem.Value.ToString());
			try
			{
				mail.ReceiveMails(Username,OrderID);
				Response.Write("<script language=javascript>alert('接收完成!');</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				//Server.Transfer("../../Error.aspx");
				Response.Write("<script language=javascript>alert('服务器正在忙碌中,请稍候再试');</script>");

			}
		}

	
		
	}
}
