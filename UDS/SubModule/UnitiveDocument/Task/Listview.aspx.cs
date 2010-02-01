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

namespace UDS.SubModule.UnitiveDocument.Task
{
	/// <summary>
	/// Listview ��ժҪ˵����
	/// </summary>
	public class Task : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgMyTask;
		protected System.Web.UI.WebControls.Panel PanFunction;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				Bangding();
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
			this.dgMyTask.SelectedIndexChanged += new System.EventHandler(this.dgMyTask_SelectedIndexChanged);
			this.ID = "Task";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region ��DBGRID
		private void Bangding()
		{
			SqlDataReader dr=null; //������������
			Database mySQL = new Database();
            try
            {
                String UserName;
                UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

                SqlParameter[] parameters = {
											mySQL.MakeInParam("@UserName",SqlDbType.VarChar,255,UserName)
										};

                mySQL.RunProc("sp_GetTaskClass", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                //��DataTable��ĩβ���Ͽ��У�ʹ��DataGrid�̶�����
                //			int iBlankRows = dgMyTask.PageSize - (dt.Rows.Count % dgMyTask.PageSize);
                //			
                //			for (int i = 0; i < iBlankRows; i++)
                //			{
                //				dt.Rows.Add(dt.NewRow()) ;
                //			}

                dgMyTask.DataSource = dt.DefaultView;
                dgMyTask.DataBind();
                //���ڿռ�¼����ʾcheckbox

                //			if(dgMyTask.CurrentPageIndex  == dgMyTask.PageCount -1 )
                //			{
                //				for(int i= (dgMyTask.PageSize - iBlankRows)  ;i<dgMyTask.Items.Count;i++)
                //				{
                //					dgMyTask.Items[i].FindControl("ClassID").Visible = false;
                //				}
                //			}
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
			dgMyTask.CurrentPageIndex = e.NewPageIndex;
			Bangding();
		}
		#endregion
		private void dgMyTask_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
