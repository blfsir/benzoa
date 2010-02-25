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
using BLL;

namespace UDS.SubModule.Meeting
{
	/// <summary>
	/// NewStaff ��ժҪ˵����
	/// </summary>
    public class NewMeetingRoom : System.Web.UI.Page
	{
		public	static string  PositionID;	
		private static long StaffID=0;
		private static int sex=1;
		private static int EditStatus =0;
		public	int ReturnPage=0;
		protected static string Username;
        protected System.Web.UI.WebControls.TextBox txtRoomName;
        protected System.Web.UI.WebControls.TextBox txtMemo;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				//�����ߵ�¼��
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                if (Request.QueryString["ID"] != null)
                {
                    object[] paramsValue = new object[] { Request.QueryString["ID"].ToString() };
                    DataTable dt = MeetingObject.GetMeetingRoomByID(paramsValue);

                    this.txtRoomName.Text = dt.Rows[0]["RoomName"].ToString();
                    this.txtMemo.Text = dt.Rows[0]["Memo"].ToString();
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
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	

		private void cmdSubmit_Click(object sender, System.EventArgs e)
        {

            string strRoomName = this.txtRoomName.Text;
            string strMemo = this.txtMemo.Text;

            //��ȡ��¼�û�ID
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            if (Request.QueryString["ID"] != null)
            {
                string strID = Request.QueryString["ID"].ToString();
                object[] Params = new object[] { null, strID, strRoomName, strMemo };

                string strReturn = MeetingObject.UpdateMeetingRoom(Params);

                if (strReturn == "0")
                {
                    Page.RegisterStartupScript("", "<script>alert('�޸�ʧ�ܣ�');</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('�޸ĳɹ���');</script>");
                }
            }
            else
            {
                object[] Params = new object[] { null, strRoomName, strMemo };

                string strReturn = MeetingObject.InsertMeetingRoom(Params);

                if (strReturn == "0")
                {
                    Page.RegisterStartupScript("", "<script>alert('���ʧ�ܣ�');</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('��ӳɹ���');</script>");
                }
            }
        }
	}
}
