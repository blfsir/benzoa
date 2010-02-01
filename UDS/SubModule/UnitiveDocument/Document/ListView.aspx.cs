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


namespace UDS.SubModule.UnitiveDocument.Document
{
	/// <summary>
	/// ListView ��ժҪ˵����
	/// </summary>
	public class ListView : System.Web.UI.Page
	{
		protected HttpCookie UserCookie;
		protected static string Username;
		protected string ClassID;
		protected System.Web.UI.WebControls.DataGrid dgDocList;
		protected string DisplayType="";
		protected static string SortRule="Desc",SortBy="DocAddedDate";
		protected System.Web.UI.WebControls.Label lblShowMember;
		protected System.Web.UI.WebControls.Label lblManageDirectory;
		protected System.Web.UI.WebControls.Label lblDeliveryDoc;
		protected System.Web.UI.WebControls.Label lblManagePermission;
		protected System.Web.UI.WebControls.Label lblRemove;
		protected System.Web.UI.WebControls.Label lblCopy;
		protected System.Web.UI.WebControls.LinkButton lnkbtnDelete;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			ClassID		 = (Request.QueryString["ClassID"]!=null)?Request.QueryString["ClassID"].ToString():"";
			DisplayType	 = (Request.QueryString["DisplayType"]!=null)?Request.QueryString["DisplayType"].ToString():"0";
			UserCookie	 = Request.Cookies["Username"];
            Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			this.lnkbtnDelete.Attributes ["onclick"]="javascript:return confirm('��ȷ��Ҫ������?');";
			if(!IsPostBack)
			{	
				BindGrid();
			    ShowAvailable();
			}
		}

		#region ���ݰ���DataGrid
		/// <summary>
		/// ��ĳ�û����ʼ�ȡ������DataGrid
		/// </summary>
		protected void BindGrid() 
		{   
			
			UserCookie	 = Request.Cookies["Username"];
            string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			DocumentClass doc		  = new DocumentClass();
			SqlDataReader dr          = doc.GetDocListInClass(Int32.Parse(ClassID),Username,Int32.Parse(DisplayType));
			DataTable datatable		  = Tools.ConvertDataReaderToDataTable(dr);
			DataView source     = datatable.DefaultView;
			source.Sort      = SortBy+" "+ SortRule;
			dgDocList.DataSource	  = source;
			dgDocList.DataBind(); 
//		
//			if (datatable.Rows.Count !=0)
//			{
//				this.lnkbtnDelete.Visible =true;
//			
//			}
			doc	  = null;
			datatable = null;
		} 
		
		#endregion

		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgDocList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		//	ShowAvailable();
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
			this.lnkbtnDelete.Click += new System.EventHandler(this.lnkbtnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ����������
		/// <summary>
		/// ���ż�����ָ���ֶν�������
		/// </summary>
		protected void DataGrid_Sort(Object Src, DataGridSortCommandEventArgs E) 
		{	
			
			SortRule			  = (SortRule=="Desc")?"Asc":"Desc";
			SortBy				  = E.SortExpression ;		
			DocumentClass doc		  = new DocumentClass();
			DataTable datatable		  = Tools.ConvertDataReaderToDataTable(doc.GetDocListInClass(Int32.Parse(ClassID),Username,Int32.Parse(DisplayType)));
			DataView Source		  = datatable.DefaultView;
			Source.Sort			  = SortBy+" "+ SortRule;
			doc				  = null;
			dgDocList.DataSource = Source;
			dgDocList.DataBind();

			
		}
		#endregion

	
		#region ����Ȩ����ʾ��ع��ܱ���
		// ����ȱʡֵ
		public void ShowAvailable()
		{
			ProjectClass pjt		 = new ProjectClass ();
			UserCookie	 = Request.Cookies["Username"];
			string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			int classID				 = Int32.Parse(ClassID);
			int cstRightToApproveDocument 	= 2;
			int cstRightToViewDocument		= 10;
			int cstRightToBuildNode		 	= 5;
			int cstDisplayMember			= 6;
			int cstTeamRight				= 7;
			int cstComposeMail				= 11;
			int cstDeliveryDoc				= 11;
			int cstProjectMove				= 12;
			int cstProjectCopy				= 12;
			int cstDeleteDocument			= 3;
			this.lblManageDirectory.Visible = pjt.GetAccessPermission(classID,Username,cstRightToBuildNode);
			this.lblDeliveryDoc.Visible     = pjt.GetAccessPermission(classID,Username,cstDeliveryDoc);
			this.lblShowMember.Visible      = pjt.GetAccessPermission(classID,Username,cstDisplayMember);
			this.lblManagePermission.Visible= pjt.GetAccessPermission(classID,Username,cstTeamRight);
			this.lnkbtnDelete.Visible       = pjt.GetAccessPermission(classID,Username,cstDeleteDocument);
			this.lblRemove .Visible			= pjt.GetAccessPermission(classID,Username,cstProjectMove);
			this.lblCopy .Visible			= pjt.GetAccessPermission(classID,Username,cstProjectMove);
			pjt								  = null;
			
		}
		#endregion

		public void lnkbtnDelete_Click(object sender, System.EventArgs e)
		{
			DocumentClass doc	  = new DocumentClass();
			bool sqlFlag		  = true;
			string sql			  = "";
			foreach(DataGridItem dgi in dgDocList.Items)
			{
				CheckBox cb=(CheckBox)(dgi.Cells[0].Controls[1]);
				if (cb.Checked==true)
				{
					int i		= dgi.ItemIndex;
					string id	= dgDocList.DataKeys[i].ToString();				
					if (sqlFlag)
					{
						sql+=id;
						sqlFlag=false;
					}
					else
					{
						sql+=" ,";
						sql+=id;
					}
				}
			}
			//ѡ��Ϊ��
			if( sql==String.Empty)
			{
				Response.Write("<script language=javascript>alert('��ѡ���ĵ�!');window.location='ListView.aspx?ClassID="+ClassID+"';</script>");
			}
			else
			{
				int deleteFlag = DisplayType.ToString()=="3"?1:0; 
				if(doc.DocDelete(sql,deleteFlag))
				{
					Response.Write("<script language=javascript>alert('�ĵ������ɹ�!');window.location='ListView.aspx?ClassID="+ClassID+"';</script>");
				}
				else
				{
					Server.Transfer("../../Error.aspx");
				}
			}
			doc=null;
		
		}


	}
}
