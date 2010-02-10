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
using System.Text;

namespace UDS.SubModule.Staff
{
	/// <summary>
	/// ManageStaff ��ժҪ˵����
	/// </summary>
	public class ManageStaff : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbOnline;
		protected System.Web.UI.WebControls.LinkButton lbOffLine;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;
		protected System.Web.UI.WebControls.Button cmdNewStaff;
		protected System.Web.UI.WebControls.Button cmdDimission;
		protected System.Web.UI.WebControls.Button cmdRehab;
		//	protected System.Web.UI.WebControls.Button cmdChangeposition;
		protected System.Web.UI.WebControls.Button cmdChangePosition;
		protected System.Web.UI.WebControls.Button btn_Search;
		public int DisplayType;
		protected System.Web.UI.WebControls.CheckBox cbRemind;

        protected System.Web.UI.WebControls.CheckBoxList cblDisplayColumn;
        protected System.Web.UI.WebControls.LinkButton lbtn_SelectField;

        protected string selectColumnID = "";
		protected static string Username;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Request.QueryString["DisplayType"]!=null)
			{
				if(Request.QueryString["DisplayType"].ToString()!="")
					DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
				else
					DisplayType = 0;
			}
			else
				DisplayType = 0;

            if (Request.QueryString["dc"] != null)
            {
                if (Request.QueryString["dc"].ToString() != "")
                {
                    ViewState["displayColumn"] = Request.QueryString["dc"].ToString();

                    for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
                    {
                        cblDisplayColumn.Items[i].Selected = false;
                    }
                    string[] dc = ViewState["displayColumn"].ToString().TrimEnd(',').Split(',');
                    for (int i = 0; i < dc.Length; i++)
                    {
                        cblDisplayColumn.Items[int.Parse(dc[i])].Selected = true;
                    }

                }
            }

			if(!Page.IsPostBack)
			{
				//�����ߵ�¼��
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				BindGrid();
			}

			cmdRehab.Attributes.Add("OnClick","return confirm('�Ƿ�ְ��');");
			cmdDimission.Attributes.Add("OnClick","return confirm('�Ƿ���ְ��');");
			cmdChangePosition.Attributes.Add("OnClick","return confirm('�Ƿ��ְ��');");
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
			this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
			this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
			this.cmdNewStaff.Click += new System.EventHandler(this.cmdNewStaff_Click);
			this.cmdDimission.Click += new System.EventHandler(this.cmdDimission_Click);
			this.cmdRehab.Click += new System.EventHandler(this.cmdRehab_Click);
			this.cmdChangePosition.Click += new System.EventHandler(this.cmdChangePosition_Click);
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
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
		private void BindGrid()
		{
			SqlDataReader dr=null; //������������
			Database db = new Database();
            try
            {
                SqlParameter[] prams = {
									   db.MakeInParam("@StaffType",SqlDbType.Bit,1,DisplayType)
								   };
                db.RunProc("sp_GetAllStaff", prams, out dr);
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                if (ViewState["sortfield"] != null)
                    dt.DefaultView.Sort = ViewState["sortfield"] + " " + ViewState["sortdirect"];

                dbStaffList.DataSource = dt.DefaultView;
                for (int j = 1; j < dbStaffList.Columns.Count; j++)
                {
                    dbStaffList.Columns[j].Visible = false;
                }
                if (ViewState["displayColumn"] != null)
                {
                    string[] dc = ViewState["displayColumn"].ToString().TrimEnd(',').Split(',');
                    for (int i = 0; i < dc.Length; i++)
                    {
                        dbStaffList.Columns[int.Parse(dc[i])+1].Visible = true;
                    }

                }
                else
                {
                    for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
                    {
                         dbStaffList.Columns[i+1].Visible = cblDisplayColumn.Items[i].Selected;
                    }
                }
                //for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
                //{
                //    dbStaffList.Columns[i+1].Visible = cblDisplayColumn.Items[i].Selected;
                //}
               
                dbStaffList.DataBind();
                //cblDisplayColumn.SelectedValue 
                //dbStaffList.Columns[1].Visible=cbRemind.Checked;
                if (DisplayType == 0)
                {
                    //				lbOnline.BackColor = Color.FromArgb(0xCCCCCC);
                    //				lbOffLine.BackColor =Color.FromArgb(0xFFFFFF);
                    cmdRehab.Visible = false;
                    cmdDimission.Visible = true;
                    cmdChangePosition.Visible = true;
                }
                else
                {
                    //				lbOnline.BackColor =Color.FromArgb(0xFFFFFF);
                    //				lbOffLine.BackColor =Color.FromArgb(0xCCCCCC);
                    cmdRehab.Visible = true;
                    cmdDimission.Visible = false;
                    cmdChangePosition.Visible = false;

                }
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
		#region ��ҳ�¼�
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion
		private void lbOnline_Click(object sender, System.EventArgs e)
		{
            if (ViewState["displayColumn"] != null)
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=0&dc=" + ViewState["displayColumn"].ToString());
            }
            else
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=0");
            }
		}

		private void lbOffLine_Click(object sender, System.EventArgs e)
		{
            if (ViewState["displayColumn"] != null)
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=1&dc=" + ViewState["displayColumn"].ToString());
            }
            else
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=1");
            }

           
		}

		private void dbStaffList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		private string GetSelectedItemID(string controlID)
		{
			string selectedID;
			selectedID = "";
			//����DataGrid���checked��ID
			foreach (DataGridItem item in dbStaffList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dbStaffList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}


		private void cmdNewStaff_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("../Position/NewStaff.aspx?ReturnPage=1");
		}


		//��ְ,��ְ֪ͨ
		private void sms_all(int i)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			SqlDataReader dr_this=null;//��ѡ����Ա
			UDS.Components.Staff sta=new UDS.Components.Staff();
			dr_this=sta.GetStaffInfo(strStaffID);
			SMS sm = new SMS();
			//�����������
            try
            {
                while (dr_this.Read())
                {
                    string Position_name = dr_this["Position_name"].ToString();
                    SqlDataReader dr_isok;//������ְ��Ա
                    dr_isok = sta.GetAllStaffs();
                    try
                    {
                        while (dr_isok.Read())
                        {
                            string Staff_name = dr_isok["Staff_name"].ToString();
                            if (i == 0)
                                sm.SendMsg(Username, Staff_name, Position_name + " ��Ա��:" + dr_this["RealName"].ToString() + ",�Ѿ���ְ,�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                            else
                                sm.SendMsg(Username, dr_isok["Staff_name"].ToString(), dr_this["Position_name"].ToString() + " ��Ա��:" + dr_this["RealName"].ToString() + ",�Ѿ��ָ�ԭְ,�ش�֪ͨ.", 1, DateTime.Now, "", 0, 0);
                        }
                    }
                    finally
                    {
                        dr_isok.Close();
                        dr_isok = null;
                    }
                }
                sm = null;
            }
            finally
            {
                dr_this.Close();
                dr_this = null;
            }
		}

		private void cmdDimission_Click(object sender, System.EventArgs e)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			if(strStaffID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.Dimission(strStaffID)==true)
				{
					if(this.cbRemind.Checked==true)
						sms_all(0);
					//Response.Write("<script language=javascript>alert('��ְ�ɹ���');</script>");		
					BindGrid();
				}
				person = null;

			}
			else
				Response.Write("<script language=javascript>alert('��ѡ��Ҫ��ְ����Ա��');</script>");		
		
		}

		private void cmdRehab_Click(object sender, System.EventArgs e)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			if(strStaffID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.Rehab(strStaffID)==true)
				{
					if(this.cbRemind.Checked==true)
						sms_all(1);
					//Response.Write("<script language=javascript>alert('��ְ�ɹ���');</script>");		
					BindGrid();
				}
				person = null;				
			}
			else
				Response.Write("<script language=javascript>alert('��ѡ��Ҫ��ְ����Ա��');</script>");		
		}

		private void cmdChangePosition_Click(object sender, System.EventArgs e)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			if(strStaffID.Trim()!="")
				Response.Redirect("../Position/ChangePosition.aspx?StaffIDS="+strStaffID + "&ReturnPage=1");
			else
				//Response.Write("<script language=javascript>alert('��ѡ��Ҫ��ְ����Ա��');</script>");		
				Page.RegisterStartupScript("window","<script language=javascript>alert('��ѡ��Ҫ��ְ����Ա��');</script>"); 
		
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Sch/Search.aspx");
		}

        protected void lbtn_SelectField_Click(object sender, EventArgs e)
        {
            cblDisplayColumn.Visible = !cblDisplayColumn.Visible;
            if (cblDisplayColumn.Visible == true)
            {
                lbtn_SelectField.Text = "ѡ����ʾ�ֶ�<<<";
            }
            else
            {
                lbtn_SelectField.Text = "ѡ����ʾ�ֶ�>>>";
            }
        }

        protected void cblDisplayColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListItem li in cblDisplayColumn.Items)
            {
                if (li.Selected == true)
                { 
                    sb.Append(li.Value).Append(',');
                }
            }
            ViewState["displayColumn"] = sb.ToString();
            BindGrid();
        }

        protected void dbStaffList_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (ViewState["sortfield"] == null)
            {
                ViewState["sortfield"] = e.SortExpression;
                ViewState["sortdirect"] = "ASC";
            }
            else
            {
                if (ViewState["sortfield"].ToString() == e.SortExpression)
                {
                    ViewState["sortdirect"] = (ViewState["sortdirect"].ToString() == "ASC" ? "DESC" : "ASC");
                }
                else
                {
                    ViewState["sortfield"] = e.SortExpression;
                    ViewState["sortdirect"] = "ASC";
                }
            }

            foreach (DataGridColumn col in dbStaffList.Columns)
            {
                if (col.SortExpression.ToString() == ViewState["sortfield"].ToString())
                {
                    if (ViewState["sortdirect"].ToString() == "ASC")
                    {
                        col.HeaderText += "<img src='../../images/asc.gif' border=0/>";
                        col.HeaderText = col.HeaderText.Remove(col.HeaderText.IndexOf('<'));
                        col.HeaderText += "<img src='../../images/asc.gif' border=0/>";
                    }
                    else
                    {
                        col.HeaderText += "<img src='../../images/desc.gif' border=0/>";
                        col.HeaderText = col.HeaderText.Remove(col.HeaderText.IndexOf('<'));
                        col.HeaderText += "<img src='../../images/desc.gif' border=0/>";
                    }
                }
                else
                {
                    col.HeaderText += "<img src='../../images/desc.gif' border=0/>";
                    col.HeaderText = col.HeaderText.Remove(col.HeaderText.IndexOf('<'));
                    
                }
            }
            BindGrid();
        }
	}
}
