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

namespace UDS.SubModule.Note
{
	/// <summary>
	/// ManageStaff ��ժҪ˵����
	/// </summary>
    public class NoteManage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbMyNote;
        protected System.Web.UI.WebControls.LinkButton lbNoteCollect;
        protected System.Web.UI.WebControls.DataGrid dbNoteList;
        protected System.Web.UI.WebControls.Button btnAdd;
        protected System.Web.UI.WebControls.Button btnShoucang;
        protected System.Web.UI.WebControls.Button btnSearch;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.Label LabelPageInfo;
        protected System.Web.UI.HtmlControls.HtmlTableRow tr_Tj;
        protected System.Web.UI.HtmlControls.HtmlTableCell td_title;

        protected System.Web.UI.WebControls.TextBox txtBeginDate;
        protected System.Web.UI.WebControls.TextBox txtEndDate;
        protected System.Web.UI.WebControls.TextBox txtContents;
        protected System.Web.UI.WebControls.TextBox txtIsSearch;
		
		public int DisplayType;
		
		protected static string Username;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            if (Request.QueryString["DisplayType"] != null)
            {
                if (Request.QueryString["DisplayType"].ToString() != "")
                {
                    DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
                }
                else
                {
                    DisplayType = 0;
                }
            }
            else
            {
                DisplayType = 0;
            }

            if (DisplayType == 0)
            {
                this.td_title.InnerHtml = "<font color=\"#006699\">�ҵı�ǩ</font>";
                this.tr_Tj.Visible = false;
                this.btnAdd.Visible = true;
                this.btnShoucang.Visible = true;

                this.dbNoteList.Columns[3].Visible = true;
            }
            else if (DisplayType==1)//��ǩ�ղ�
            {
                this.td_title.InnerHtml = "<font color=\"#006699\">��ǩ�ղ�</font>";
                this.tr_Tj.Visible = true;
                this.btnAdd.Visible = false;
                this.btnShoucang.Visible = false;

                this.dbNoteList.Columns[3].Visible = false;
            }

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
            this.lbMyNote.Click += new System.EventHandler(this.lbMyNote_Click);
            this.lbNoteCollect.Click += new System.EventHandler(this.lbNoteCollect_Click);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnShoucang.Click += new System.EventHandler(this.btnShoucang_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //this.cmdChangePosition.Click += new System.EventHandler(this.cmdChangePosition_Click);
            this.btnSearch.Click += new System.EventHandler(this.btn_Search_Click);
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
            //if (DisplayType == 0)
            //{
                object[] paramsValue = new object[] { strUserid, DisplayType };

                DataTable dt = NoteObject.GetNoteListByUserID(paramsValue);

                this.dbNoteList.DataSource = dt;//.DefaultView;
                this.dbNoteList.DataBind();
            //}
            //else
            //{
            //    string strBeginDate = this.txtBeginDate.Text.Trim();
            //    string strEndDate = this.txtEndDate.Text.Trim();
            //    string strContents = "%" +this.txtContents.Text.Trim()+ "%";

            //    object[] paramsValue = new object[] { strUserid, strBeginDate, strEndDate, strContents };

            //    DataTable dt = NoteObject.SearchNote(paramsValue);

            //    this.dbNoteList.DataSource = dt;//.DefaultView;
            //    this.dbNoteList.DataBind();
            //}

            LabelPageInfo.Text = "��ǰ����" + (dbNoteList.CurrentPageIndex + 1).ToString() + "ҳ ��" + dbNoteList.PageCount.ToString() + "ҳ��";
		}
		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbNoteList.CurrentPageIndex = e.NewPageIndex;

            if (this.txtIsSearch.Text == "0")
            {
                BindGrid();
            }
            else
            {
                SearchBindGrid();
            }
		}
		#endregion
        private void lbMyNote_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NoteManage.aspx?DisplayType=0");
		}

        private void lbNoteCollect_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NoteManage.aspx?DisplayType=1");
		}

		private void dbStaffList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

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
			foreach (DataGridItem item in dbNoteList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
                    selectedID += dbNoteList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}


        private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NewNote.aspx?ReturnPage=1");
		}

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, System.EventArgs e)
		{
            string strNoteID = this.GetSelectedItemID("chkNote_ID");
            if (strNoteID != "")
            {
                object[] Params = null;// new object[] { null, strContents, strUserid };
                string[] strNoteIDs = strNoteID.Split(',');

                for (int i = 0; i < strNoteIDs.Length; i++)
                {
                    string strID = strNoteIDs[i];
                    Params = new object[] { null, strID };
                    NoteObject.DeleteNote(Params);
                }

                if (this.txtIsSearch.Text == "0")
                {
                    BindGrid();
                }
                else
                {
                    SearchBindGrid();
                }
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('��ѡ��Ҫɾ���ı�ǩ��');</script>");
            }
		}

        /// <summary>
        /// �ղ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShoucang_Click(object sender, System.EventArgs e)
        {
            string strNoteID = this.GetSelectedItemID("chkNote_ID");
            if (strNoteID != "")
            {
                object[] Params = null;// new object[] { null, strContents, strUserid };
                string[] strNoteIDs = strNoteID.Split(',');

                for (int i = 0; i < strNoteIDs.Length; i++)
                {
                    string strID = strNoteIDs[i];
                    Params = new object[] { null, strID };
                    NoteObject.CollectNote(Params);
                }

                if (this.txtIsSearch.Text == "0")
                {
                    BindGrid();
                }
                else
                {
                    SearchBindGrid();
                }
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('��ѡ��Ҫ�ղصı�ǩ��');</script>");
            }
        }

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
            this.txtIsSearch.Text = "1";
            SearchBindGrid();
		}

        /// <summary>
        /// ��ѯ���ݰ�
        /// </summary>
        private void SearchBindGrid()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);
            this.txtBeginDate.Text = Request.Form["txtBeginDate"].ToString();
            this.txtEndDate.Text = Request.Form["txtEndDate"].ToString();

            string strBeginDate = Request.Form["txtBeginDate"].ToString(); //this.txtBeginDate.Text.Trim();
            string strEndDate = Request.Form["txtEndDate"].ToString(); //this.txtEndDate.Text.Trim();
            string strContents = "%" + this.txtContents.Text.Trim() + "%";

            object[] paramsValue = new object[] { strUserid, strBeginDate, strEndDate, strContents };

            DataTable dt = NoteObject.SearchNote(paramsValue);

            this.dbNoteList.DataSource = dt;//.DefaultView;
            this.dbNoteList.DataBind();

            LabelPageInfo.Text = "��ǰ����" + (dbNoteList.CurrentPageIndex + 1).ToString() + "ҳ ��" + dbNoteList.PageCount.ToString() + "ҳ��";
        }
	}
}
