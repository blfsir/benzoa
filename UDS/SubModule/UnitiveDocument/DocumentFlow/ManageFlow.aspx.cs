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
using Microsoft.Web.UI.WebControls;
namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
	/// <summary>
	/// ManageFlow ��ժҪ˵����
	/// </summary>
	public class ManageFlow : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgStepList;
		protected System.Web.UI.WebControls.Button cmdReturn;
		protected System.Web.UI.WebControls.Label labTitle;
		public long FlowID;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			FlowID = Int32.Parse(Request.QueryString["FlowID"].ToString());
			if(!Page.IsPostBack)		
			{
				Bind();				
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
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Bind()
		{
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			DataTable dt;

			labTitle.Text = df.GetFlowTitle(FlowID);
			df.GetStep(FlowID,0,out dt);

			dgStepList.DataSource = dt.DefaultView;
			dgStepList.DataBind();

			df = null;
			
		}

		public string GetTranslateFlowRule(string FlowRule)
		{
			switch(FlowRule)
			{
				case "0":
					return "����Ա";
				case "1":
					return "��ְλ";
				case "2":
					return "����Ŀ";
				default:
					return "��";
			}
		}
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//����DataGrid���checked��ID
			foreach (DataGridItem item in dgStepList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dgStepList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}

		public void MyDataGrid_Delete(object sender,DataGridCommandEventArgs e)
		{
			string StepID = dgStepList.DataKeys[e.Item.ItemIndex].ToString();
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.DeleteStep(FlowID,Int32.Parse(StepID));
			df = null;
			Bind();	

		}

		public void MyDataGrid_Move(object sender,DataGridCommandEventArgs e)
		{
			string StepID = dgStepList.DataKeys[e.Item.ItemIndex].ToString();
			UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
			df.MoveUpStep(FlowID,Int32.Parse(StepID));
			df = null;
			Bind();	

		}


		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgStepList.CurrentPageIndex = e.NewPageIndex;
		}
		#endregion

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx");
		}

	}
}
