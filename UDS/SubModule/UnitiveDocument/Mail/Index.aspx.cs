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
	/// Index ��ժҪ˵����
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
			// ���ý���ֵ
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
			// ���ý���
		
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

		#region ����������
		/// <summary>
		/// ���ż�����ָ���ֶν�������
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

		#region ���ʼ�ת����ָ������
		public void FolderListChange(object sender, System.EventArgs e)
		{					
			bool sqlFlag		  = true;
			string sql			  = "";
			int FolderType        = Int32.Parse(this.listFolderType.SelectedItem.Value); //����ת��Ŀ��
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
			//ѡ��Ϊ��
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ���ʼ�!');window.location='Index.aspx?FolderType="+FolderType+"';</script>");
			}
			else
			{
				if(mail.MailRemove(FolderType,sql))
				{
					Response.Write("<script language=javascript>alert('�ʼ��ƶ��ɹ�!');window.location='Index.aspx?FolderType="+FolderType+"';</script>");
				}
				else
				{
					Server.Transfer("../../Error.aspx");
				}
			}
			mail=null;
		}
		#endregion
		
			
		#region ���ݰ���DataGrid
		/// <summary>
		/// ��ĳ�û����ʼ�ȡ������DataGrid
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
			//���������������ʾ��������
			switch (FolderType)
			{
				case 1:
					dgMailList.Columns[3].Visible = false; //�������ռ���
					dgMailList.Columns[4].Visible = false; //�����������ռ���
					break;
				case 2:
					dgMailList.Columns[2].Visible = false; //�����ط�����
					dgMailList.Columns[3].Visible = false;  //�������ռ���
					//dgMailList.Columns[4].Visible = true; //�����������ռ���
					break;
				case 3:
					dgMailList.Columns[2].Visible = true; //����ʾ������
					dgMailList.Columns[3].Visible = false; //�������ռ���
					dgMailList.Columns[4].Visible = false; //�����������ռ���
					this.btnClear .Attributes["onclick"] = "javascript:return confirm('��ȷ��Ҫ�����?');";
					break;
				case 4:
					dgMailList.Columns[4].Visible = false;  //�������ռ���
					dgMailList.Columns[6].Visible = false; //������������Ŀ
					break;
				default: 
					
					break;
			}

			if(FolderType!=4)
			{
				DataView dataView  = new DataView();
				dataView		   = datatable.DefaultView;
				dataView.RowFilter = "MailReadFlag = false";	
				this.lblMsg.Text = datatable.Rows.Count+"/<font color=red>"+dataView.Count.ToString()+"</font>δ��";
				this.lblMsg .Text+= (SortRule=="Desc")?"&nbsp;&nbsp;��":"&nbsp;&nbsp;��";
			}
			if (datatable.Rows.Count !=0)
			{
				this.btnDelete.Visible =true;
				this.btnDelete.Attributes ["onclick"]="javascript:return confirm('��ȷ��Ҫɾ����?');";
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
//				//e.Item.Cells[index].Text = (SortRule=="Desc")?e.Item.Cells[index].Text+"��":e.Item.Cells[index].Text+"��";
//				e.Item.Cells[index].Text = "dsfsdfsd";
//			}


		}
		
		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgMailList.CurrentPageIndex = e.NewPageIndex;
			CurrentPageIndex = dgMailList.CurrentPageIndex.ToString();
			BindGrid();
		}
		#endregion

		#region ��ʼ�������б��
		/// <summary>
		/// �������б���г�ʼ��
		/// </summary>
		private void PopulateListView() 
		{
			listFolderType.Items.Clear();
			listFolderType.Items.Add(new ListItem("�����ʼ���...","0"));
			listFolderType.Items.Add(new ListItem("�ռ���","1"));
			listFolderType.Items.Add(new ListItem("�Ѿ����͵��ʼ�","2"));
			listFolderType.Items.Add(new ListItem("�ϼ���","3"));
			if(this.listExtMail.Visible)
			{
				try
				{
					MailClass mail = new MailClass();
					this.listExtMail.DataTextField = "Title";
					this.listExtMail.DataValueField = "OrderID";
					this.listExtMail.DataSource = mail.ExtGetAvaSetting(Server.UrlDecode(Request.Cookies["UserName"].Value));
					this.listExtMail.DataBind();
					this.listExtMail.Items.Insert(0,"ȫ���ⲿ����");
					this.listExtMail.Items.FindByText("ȫ���ⲿ����").Value="0";
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
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
					Response.Write("<script language=javascript>alert('�ʼ�ɾ���ɹ�!');window.location='Index.aspx?FolderType="+Session["FolderType"].ToString()+"';</script>");
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
			//ѡ��Ϊ��
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ���ʼ�!');window.location='Index.aspx?FolderType="+Session["FolderType"].ToString()+"';</script>");
			}
			else
			{
				try
				{
					
					if(Session["FolderType"].ToString()=="3")
					{
						mail.MailDelete(sql,1);//����ɾ��
					}
					else
					{
						mail.MailDelete(sql,0);//�����ϼ���
					}
				
					Response.Write("<script language=javascript>alert('�ʼ�ɾ���ɹ�!');window.location='Index.aspx?FolderType="+Session["FolderType"].ToString()+"';</script>");
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
				Response.Write("<script language=javascript>alert('�������!');</script>");
			}
			catch(Exception ex)
			{
				UDS.Components.Error.Log(ex.ToString());
				//Server.Transfer("../../Error.aspx");
				Response.Write("<script language=javascript>alert('����������æµ��,���Ժ�����');</script>");

			}
		}

	
		
	}
}
