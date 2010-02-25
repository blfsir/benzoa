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
using BLL;

namespace UDS.SubModule.Meeting
{
	/// <summary>
	/// ManageStaff ��ժҪ˵����
	/// </summary>
    public class MeetingRoomManage : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid dbMeetingRoomList;
        protected System.Web.UI.WebControls.Button btnAdd;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.Label LabelPageInfo;

		
		public int DisplayType;
		
		protected static string Username;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			if(!Page.IsPostBack)
			{
				//�����ߵ�¼��
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				BindGrid();
			}

            btnDelete.Attributes.Add("OnClick","return confirm('ȷ��ɾ����');");

            
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
            //this.lbMyNote.Click += new System.EventHandler(this.lbMyNote_Click);
            //this.lbNoteCollect.Click += new System.EventHandler(this.lbNoteCollect_Click);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public string GetSelectImage(string NormalImg,string SelectedImg,int selected,int position)
		{
			if(selected==position)
				return SelectedImg;
			else
				return NormalImg;
		}

        /// <summary>
        /// ���ݰ�
        /// </summary>
        private void BindGrid()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            object[] paramsValue = new object[] { };

            DataTable dt = MeetingObject.GetAllMeetingRoom(paramsValue);

            this.dbMeetingRoomList.DataSource = dt;
            this.dbMeetingRoomList.DataBind();

            LabelPageInfo.Text = "��ǰ����" + (dbMeetingRoomList.CurrentPageIndex + 1).ToString() + "ҳ ��" + dbMeetingRoomList.PageCount.ToString() + "ҳ��";
        }
		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
            dbMeetingRoomList.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
		}
		#endregion

        /// <summary>
        /// ��ȡѡ���ID
        /// </summary>
        /// <param name="controlID"></param>
        /// <returns></returns>
		private string GetSelectedItemID(string controlID)
		{
			string selectedID;
			selectedID = "";
			//����DataGrid���checked��ID
            foreach (DataGridItem item in dbMeetingRoomList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
                    selectedID += dbMeetingRoomList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}


        private void btnAdd_Click(object sender, System.EventArgs e)
		{
            Server.Transfer("NewMeetingRoom.aspx");
		}

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, System.EventArgs e)
		{
            string strNoteID = this.GetSelectedItemID("chkID");
            if (strNoteID != "")
            {
                object[] Params = null;// new object[] { null, strContents, strUserid };
                string[] strNoteIDs = strNoteID.Split(',');

                for (int i = 0; i < strNoteIDs.Length; i++)
                {
                    string strID = strNoteIDs[i];
                    Params = new object[] { null, strID };
                    MeetingObject.DeleteMeetingRoom(Params);
                }

                BindGrid();
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('��ѡ��Ҫɾ���Ļ������ͣ�');</script>");
            }
		}

	}
}
