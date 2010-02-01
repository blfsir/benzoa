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

namespace UDS.SubModule.UnitiveDocument
{
	/// <summary>
	/// onlineperson ��ժҪ˵����
	/// </summary>
	public class onlineperson : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgrd_OnlinePerson;
		//���ҳü����
		private string[] headtext;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				headtext = new String[dgrd_OnlinePerson.Columns.Count];
				for(int i=0;i<dgrd_OnlinePerson.Columns.Count;i++)
				{
					headtext[i] = dgrd_OnlinePerson.Columns[i].HeaderText;
				}
				ViewState["headtext"] = headtext;

				ViewState["SortField"] = "Position_Name";
				ViewState["SortDirect"] = "ASC";
				Bind();
			}
			else
			{
				//��ҳü��λ
				headtext = (string[]) ViewState["headtext"];
				for(int i=0;i<dgrd_OnlinePerson.Columns.Count;i++)
				{
					dgrd_OnlinePerson.Columns[i].HeaderText = headtext[i];
				}

			}
		}

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
			this.dgrd_OnlinePerson.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgrd_OnlinePerson_SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Bind()
		{
			UDS.Components.SMS sms = new UDS.Components.SMS();
			SqlDataReader dr = sms.GetOnlinePerson();
			DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
			dt.DefaultView.Sort = ViewState["SortField"] + " " + ViewState["SortDirect"];
			dgrd_OnlinePerson.DataSource = dt.DefaultView;
			dgrd_OnlinePerson.DataBind();
		}

		private void dgrd_OnlinePerson_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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
			
			foreach(DataGridColumn col in  dgrd_OnlinePerson.Columns)
			{
				if(col.SortExpression.ToString()==ViewState["SortField"].ToString())
				{
					if(ViewState["SortDirect"].ToString() == "ASC")
						col.HeaderText += "<img src='../../images/asc.gif' border=0/>";
					else
						col.HeaderText += "<img src='../../images/desc.gif' border=0/>";
				}
			}

			Bind();
		}

		private void dgrd_OnlinePerson_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}
	}
}
