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

namespace UDS.SubModule.Position
{
	/// <summary>
	/// ChangePosition ��ժҪ˵����
	/// </summary>
	public class ChangePosition : System.Web.UI.Page
	{
		private static string PositionID;
		private static string displayType;
		private static string selectedID;
		private static string backfilepath;
		private int ReturnPage =0;
		protected static string Username;


		protected System.Web.UI.HtmlControls.HtmlInputButton cmdSubmit;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlSelect cboPosition;
		protected System.Web.UI.WebControls.CheckBox cbRemind;
		protected HtmlSelect Position;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				//�����ߵ�¼��
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				PositionID = (Request.QueryString["PositionID"]==null)?"":Request.QueryString["PositionID"].ToString();
				displayType = (Request.QueryString["displayType"]==null)?"":Request.QueryString["displayType"].ToString();
				selectedID = (Request.QueryString["StaffIDS"]==null)?"":Request.QueryString["StaffIDS"].ToString();
				backfilepath =(Request.QueryString["BackFilePath"]==null)?"":Request.QueryString["BackFilePath"].ToString();
				SqlDataReader dr=null;
                try
                {
                    UDS.Components.Database db = new UDS.Components.Database();
                    db.RunProc("SP_Ext_GetPosition", out dr);
                    cboPosition.DataSource = dr;
                    cboPosition.DataTextField = "Position_Name";
                    cboPosition.DataValueField = "Position_ID";
                    cboPosition.DataBind();
                }
                finally
                {
                     
                    if (dr != null)
                    {

                        dr.Close();
                    }
                }
			}
			if(Request.QueryString["ReturnPage"]!=null)
			{
				ReturnPage  = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
			}
			else
				ReturnPage = 0;


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
			this.cmdSubmit.ServerClick += new System.EventHandler(this.cmdSubmit_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//��ְ֪ͨ
		private void sms_all()
		{
			SqlDataReader dr_this=null;//��ѡ����Ա
            try
            {
                UDS.Components.Staff sta = new UDS.Components.Staff();
                dr_this = sta.GetStaffInfo(selectedID);
                SMS sm = new SMS();
                //�����������

                while (dr_this.Read())
                {
                    string Position_name = dr_this["Position_name"].ToString();
                    SqlDataReader dr_isok;//������ְ��Ա
                    dr_isok = sta.GetAllStaffs();
                    while (dr_isok.Read())
                    {
                        string Staff_name = dr_isok["Staff_name"].ToString();
                        sm.SendMsg(Username, Staff_name, Position_name + "��Ա��:" + dr_this["RealName"].ToString() + ",�Ѿ���ְ��" + cboPosition.Items[cboPosition.SelectedIndex].Text + "��,�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                    }
                    dr_isok.Close();
                    dr_isok = null;
                }
                sm = null;
            }
            finally
            {
                dr_this.Close();
                dr_this = null;
            }
		}

		private void sms_all(int i)
		{
			SqlDataReader dr_this=null;//��ѡ����Ա
            try
            {
                UDS.Components.Staff sta = new UDS.Components.Staff();
                dr_this = sta.GetStaffInfo(selectedID);
                SMS sm = new SMS();
                //�����������
                while (dr_this.Read())
                {
                    string Position_name = dr_this["Position_name"].ToString();
                    SqlDataReader dr_isok;//������ְ��Ա
                    dr_isok = sta.GetAllStaffs();
                    while (dr_isok.Read())
                    {
                        string Staff_name = dr_isok["Staff_name"].ToString();
                        if (i == 0)
                            sm.SendMsg(Username, Staff_name, Position_name + " ��Ա��:" + dr_this["RealName"].ToString() + ",�Ѿ���ְ,�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                        else
                            sm.SendMsg(Username, dr_isok["Staff_name"].ToString(), dr_this["Position_name"].ToString() + " ��Ա��:" + dr_this["RealName"].ToString() + ",�Ѿ��ָ�ԭְ,�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                    }
                    dr_isok.Close();
                    dr_isok = null;
                }
                sm = null;
            }
            finally
            {
                dr_this.Close();
                dr_this = null;
            }
		}

		private void cmdSubmit_ServerClick(object sender, System.EventArgs e)
		{
			if(this.cbRemind.Checked==true)
				sms_all();
			UDS.Components.Database db = new UDS.Components.Database();
			SqlParameter[] prams = {
										db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,selectedID),
										db.MakeInParam("@NewPositionID",SqlDbType.Int,4,Int32.Parse(cboPosition.Items[cboPosition.SelectedIndex].Value))
								   };
			db.RunProc("sp_StaffMove",prams);
			if(ReturnPage ==0)
				Response.Redirect(backfilepath+"?PositionID="+PositionID+"&displayType="+displayType);
			else
				Response.Redirect("../Staff/ManageStaff.aspx?DisplayType=0");
		}
	}
}
