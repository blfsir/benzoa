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
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.LinkButton lbMyApprove;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton lbMyApproved;
		protected System.Web.UI.WebControls.DataGrid dgFlowList;
		protected System.Web.UI.WebControls.LinkButton lbManageFlow;
		public string UserName;
		protected System.Web.UI.WebControls.LinkButton lbMyDraft;
		protected System.Web.UI.WebControls.Button cmdListDraft;
		public bool bManageFlow;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value).ToLower();
			if(!Page.IsPostBack)
				Bangding();
			UDS.Components.DocumentFlow df =new UDS.Components.DocumentFlow();
			bManageFlow = df.GetAccessPermission(Request.Cookies["ActiveNodeID"]!=null?Int32.Parse(Request.Cookies["ActiveNodeID"].Value):0,UserName,4);
			df = null;
		}
		#region ��DBGRID
		private void Bangding()
		{
			SqlDataReader dr; //������������
			Database mySQL = new Database();
			string UserName;

			UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);


			SqlParameter[] parameters = {
											mySQL.MakeInParam("@StaffName",SqlDbType.VarChar ,300,UserName)
										};
			
			mySQL.RunProc("sp_Flow_GetMyFlow",parameters,out dr);
            try
            {
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);


                dgFlowList.DataSource = dt.DefaultView;
                dgFlowList.DataBind();
            }
            finally
            {
                if (mySQL != null)
                {
                    mySQL.Close();
                }
                if (dr != null)
                {
                    dr.Close();
                }
            }
		}
		#endregion
		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgFlowList.CurrentPageIndex = e.NewPageIndex;
			Bangding();
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
			this.cmdListDraft.Click += new System.EventHandler(this.cmdListDraft_Click);
			this.lbMyApprove.Click += new System.EventHandler(this.lbMyApprove_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.lbMyApproved.Click += new System.EventHandler(this.lbMyApproved_Click);
			this.lbMyDraft.Click += new System.EventHandler(this.lbMyDraft_Click);
			this.lbManageFlow.Click += new System.EventHandler(this.lbManageFlow_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbMyApprove_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=1");
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=2");
		}

		private void lbMyApproved_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListDocument.aspx?DisplayType=3");
		}

		private void lbManageFlow_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("ListView.aspx");
		}

		private void lbMyDraft_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cmdListDraft_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("DraftList.aspx");
		}

        private string GetSelectedItemID(string controlID)
        {
            String selectedID;
            selectedID = "";
            //����DataGrid���checked��ID
            foreach (DataGridItem item in dgFlowList.Items)
            {
                if (((CheckBox)item.FindControl(controlID)).Checked == true)
                    selectedID += dgFlowList.DataKeys[item.ItemIndex] + ",";
            }
            if (selectedID.Length > 0)
                selectedID = selectedID.Substring(0, selectedID.Length - 1);
            return selectedID;
        }

        protected void btnSetDesktopFlow_Click(object sender, EventArgs e)
        {
            String strIDs = this.GetSelectedItemID("Flow_ID");
            if (strIDs == "")
            {
                Response.Write("<script language='javascript'>window.alert('��ѡ��Ҫ���õ����̣�');</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Ҫ���õĿ������:" + strIDs + "');</script>");
                string userName = Server.UrlDecode(Request.Cookies["UserName"].Value);
                ActiveRecord.Model.QuickFlow qf = new ActiveRecord.Model.QuickFlow();
                qf.StaffName = userName;
                qf.FlowIDs = strIDs;
                qf.Save();

                Response.Write("<script language='javascript'>window.alert('���õĿ�����̳ɹ�!');</script>");
            }
        }
	}
}
