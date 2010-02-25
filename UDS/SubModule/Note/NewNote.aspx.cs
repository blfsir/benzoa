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

namespace UDS.SubModule.Note
{
	/// <summary>
	/// NewStaff ��ժҪ˵����
	/// </summary>
    public class NewNote : System.Web.UI.Page
	{
		public	static string  PositionID;	
		private static long StaffID=0;
		private static int sex=1;
		private static int EditStatus =0;
		public	int ReturnPage=0;
		protected static string Username;
        protected System.Web.UI.WebControls.TextBox txtContents;
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
                    DataTable dt = NoteObject.GetNoteByID(paramsValue);

                    this.txtContents.Text = dt.Rows[0]["Contents"].ToString();
                }
			}

			if(Request.QueryString["ReturnPage"]!=null)
			{
				ReturnPage = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
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
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	

		private void cmdSubmit_Click(object sender, System.EventArgs e)
        {

            string strContents = this.txtContents.Text;

            //��ȡ��¼�û�ID
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            if (Request.QueryString["ID"] != null)
            {
                string strID = Request.QueryString["ID"].ToString();
                object[] Params = new object[] { null, strID, strContents };

                string strReturn = NoteObject.UpdateNote(Params);

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
                object[] Params = new object[] { null, strContents, strUserid };

                string strReturn = NoteObject.InsertNote(Params);

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
