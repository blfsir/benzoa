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

namespace UDS.SubModule.UnitiveDocument.Subscription
{
	/// <summary>
	/// Listview ��ժҪ˵����
	/// </summary>
	public class Subscription : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgMySubsciption;
		protected System.Web.UI.WebControls.Button btnDeleteSubscription;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			
			if(!Page.IsPostBack)
			{

				Bangding();
				//lbl_totalrecord.Text =StaffList.PageCount.ToString();
				//lbl_curpage.Text = txb_PageNo.Text = (StaffList.CurrentPageIndex + 1).ToString();
				//txb_ItemPerPage.Text = StaffList.PageSize.ToString();
				//lbl_totalpage.Text = StaffList.PageCount.ToString();
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
			this.btnDeleteSubscription.Click += new System.EventHandler(this.btnDeleteSubscription_Click);
			this.ID = "Subscription";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dgMySubsciption.CurrentPageIndex = e.NewPageIndex;
			Bangding();
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

                mySQL.RunProc("sp_GetSubscripitionClass", parameters, out dr);

                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                //��DataTable��ĩβ���Ͽ��У�ʹ��DataGrid�̶�����
                //			int iBlankRows = dgMySubsciption.PageSize - (dt.Rows.Count % dgMySubsciption.PageSize);
                //			
                //			for (int i = 0; i < iBlankRows; i++)
                //			{
                //				dt.Rows.Add(dt.NewRow()) ;
                //			}

                dgMySubsciption.DataSource = dt.DefaultView;
                dgMySubsciption.DataBind();
                //���ڿռ�¼����ʾcheckbox
                //
                //			if(dgMySubsciption.CurrentPageIndex  == dgMySubsciption.PageCount -1 )
                //			{
                //				for(int i= (dgMySubsciption.PageSize - iBlankRows)  ;i<dgMySubsciption.Items.Count;i++)
                //				{
                //					dgMySubsciption.Items[i].FindControl("ClassID").Visible = false;
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
			btnDeleteSubscription.Attributes ["onclick"]="javascript:return confirm('��ȷ��Ҫɾ���˶�����?');";
		}
		#endregion
		private void lbDeleteSubscription_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>location.reload();</script>");
		}
		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//����DataGrid���checked��ID
			foreach (DataGridItem item in dgMySubsciption.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dgMySubsciption.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}

		private void btnDeleteSubscription_Click(object sender, System.EventArgs e)
		{
			
			String strIDs=this.GetSelectedItemID("ClassID");
			if(strIDs=="")			
				Response.Write("<script language='javascript'>window.alert('��ѡ��Ҫɾ���Ķ��ģ�');</script>");
			else
			{
				Database mySQL = new Database();
				String UserName;
				UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

				SqlParameter[] parameters = {
												mySQL.MakeInParam("@UserName",SqlDbType.VarChar,300,UserName),
												mySQL.MakeInParam("@ClassIDs",SqlDbType.VarChar,300,strIDs)
											};
			
				try
				{
					mySQL.RunProc("sp_DeleteSubsciption",parameters);
					Response.Write("<script language=javascript>alert('����ɾ���ɹ�!');</script>");
				}
				catch(Exception ex)
				{
					UDS.Components .Error.Log(ex.ToString());
					Server.Transfer("../../../Error.aspx");
				}

				Bangding();
			}
				
		}

	}
}
