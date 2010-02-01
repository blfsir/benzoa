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
namespace UDS.SubModule.UnitiveDocument.NewDoc
{
	/// <summary>
	/// Listview ��ժҪ˵����
	/// </summary>
	public class Listview : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnThowAwayDocument;
		protected System.Web.UI.WebControls.DataGrid dgDocList;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{

				ViewState["SortField"] = "DocAddedDate";
				ViewState["SortDirect"] = "ASC";
			
				Bangding();
				//this.btnThowAwayDocument.Attributes["onclick"] = "javascript:return confirm('��ȷ��Ҫ������?');";
			}
				
		}

		public string GetRealName(string Username)
		{
			if(Username!="")
				return UDS.Components.Staff.GetRealNameByUsername(Username);
			else
				return "";
		}

		#region ��DBGRID
		private void Bangding()
		{
			SqlDataReader dr; //������������
			UDS.Components.Desktop myDesktop = new UDS.Components.Desktop();
			String UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

			dr = myDesktop.GetMyDocument(UserName,10);
			DataTable dt =Tools.ConvertDataReaderToDataTable(dr);
			
				
			dt.DefaultView.Sort = ViewState["SortField"] + " " + ViewState["SortDirect"];			

			dgDocList.DataSource = dt.DefaultView;
			dgDocList.DataBind();
		

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
			this.btnThowAwayDocument.Click += new System.EventHandler(this.btnThowAwayDocument_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgDocList.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion


		#region ����������
		/// <summary>
		/// ���ż�����ָ���ֶν�������
		/// </summary>	
		public void DataGrid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(ViewState["SortField"].ToString() == e.SortExpression)
			{
				ViewState["SortDirect"] = (ViewState["SortDirect"].ToString()=="ASC")?"DESC":"ASC";
			}
			else
			{
				ViewState["SortField"] = e.SortExpression;
				ViewState["SortDirect"] = "ASC";

			}
			
			foreach(DataGridColumn col in  dgDocList.Columns)
			{
				if(col.SortExpression.ToString()==ViewState["SortField"].ToString())
				{
//					if(ViewState["SortDirect"].ToString() == "ASC")
//					{						
//						col.HeaderText +="<img src='../../../images/asc.gif' border=0 />";						
//					}
//					else
//						col.HeaderText +="<img src='../../../images/desc.gif' border=0 />";
						
				}
			}

			Bangding();
		}
		#endregion

		private void lbThowAwayDocument_Click(object sender, System.EventArgs e)
		{
			
		}
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//����DataGrid���checked��ID
			foreach (DataGridItem item in dgDocList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dgDocList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}

		private void btnThowAwayDocument_Click(object sender, System.EventArgs e)
		{
			UDS.Components.DocumentClass myDocument = new UDS.Components.DocumentClass();
			String DocIDs = GetSelectedItemID("DocID");
			myDocument.DocDelete(DocIDs,0);			
			Response.Write("<Script language='javascript'>alert('�ļ������ɹ���');</script>");
			Bangding();
		}		
	}
}
