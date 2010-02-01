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
using UDS.Components;

namespace UDS.SubModule.AssginRule
{
	/// <summary>
	/// RightListView ��ժҪ˵����
	/// </summary>
	public class RightListView : System.Web.UI.Page
	{
		public string strObjID;
		public string DisplayType;
		protected System.Web.UI.HtmlControls.HtmlInputButton btn_AddRight;
		protected System.Web.UI.HtmlControls.HtmlInputButton btn_DelRight;
		protected System.Web.UI.WebControls.DataGrid RightsGrid;
	
		/// <summary>
		/// �õ�datagrid checkbox��value
		/// </summary>
		/// <param name="controlID">checkbox�ؼ���ID</param>
		/// <returns>��checkbox��ֵ</returns>
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//����DataGrid���checked��ID
			foreach (DataGridItem item in RightsGrid.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += RightsGrid.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			strObjID = Request.QueryString["ObjID"].ToString();
			DisplayType = Request.QueryString["DisplayType"].ToString();
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				BindGrid();
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
			this.RightsGrid.SelectedIndexChanged += new System.EventHandler(this.RightsGrid_SelectedIndexChanged);
			this.btn_DelRight.ServerClick += new System.EventHandler(this.btn_DelRight_ServerClick);
			this.btn_AddRight.ServerClick += new System.EventHandler(this.btn_AddRight_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			RightsGrid.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion

		public void BindGrid()
		{
			SqlDataReader dr=null; //���Ȩ������
			string spName;//�洢������
			spName = "";
			Database db = new Database();
			SqlParameter[] prams = new SqlParameter[1];
            try
            {
                switch (DisplayType)
                {
                    case "0":
                        prams[0] = db.MakeInParam("@PositionID", SqlDbType.Int, 4, Int32.Parse(strObjID));
                        spName = "sp_GetPositionRightList";
                        break;
                    case "1":
                        prams[0] = db.MakeInParam("@Teamid", SqlDbType.Int, 4, Int32.Parse(strObjID));
                        spName = "sp_GetTeamRightList";
                        break;
                    case "2":
                        prams[0] = db.MakeInParam("@RoleID", SqlDbType.Int, 4, Int32.Parse(strObjID));
                        spName = "sp_GetRoleRightList";
                        break;
                    default:
                        break;
                    //������
                }

                db.RunProc(spName, prams, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                RightsGrid.DataSource = dt.DefaultView;
                RightsGrid.DataBind();
            }
            finally
            {
                if (db != null)
                { db.Close(); }
                if (dr != null)
                {

                    dr.Close();
                }
            }
		}


		private void btn_DelRight_ServerClick(object sender, System.EventArgs e)
		{
			string IDs=GetSelectedItemID("cb_RightID").Trim();

			//�õ�ѡ�е�datagrid��checkbox��value
			if(IDs!="")
			{

				UDS.Components.AssignRights ar = new UDS.Components.AssignRights();

				ar.DeleteRight(IDs);

				ar =	null;

				Response.Redirect("RightListView.aspx?ObjID="+strObjID+"&DisplayType="+DisplayType);
			}
		}

		private void btn_AddRight_ServerClick(object sender, System.EventArgs e)
		{
			Response.Redirect("Treeview.aspx?SrcID="+strObjID+"&DisplayType="+DisplayType);
		}

		private void RightsGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}            
	}
}
