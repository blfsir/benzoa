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
	/// ListView 的摘要说明。
	/// </summary>
	public class ListView : System.Web.UI.Page
	{

		public static int DisplayType = 0;
		public static string PositionID;
		protected static string Username;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;
		protected System.Web.UI.WebControls.LinkButton lbOffLine;
		protected System.Web.UI.WebControls.LinkButton lbOnline;
		protected System.Web.UI.WebControls.Button cmdNewStaff;
		protected System.Web.UI.WebControls.Button cmdPositionOperate;
		protected System.Web.UI.WebControls.Button cmdSetRight;
		protected System.Web.UI.WebControls.Button cmdOffPosition;
		protected System.Web.UI.WebControls.Button cmdChangePosition;
		protected System.Web.UI.WebControls.Button cmdUpdateCaste;
		protected System.Web.UI.WebControls.CheckBox cbRemind;
		protected System.Web.UI.WebControls.Button cmdOnPosition;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
				if (Request.QueryString["DisplayType"] != null)
					DisplayType = Int32.Parse( Request.QueryString["DisplayType"].ToString());		
				if(DisplayType==0)
				{
//					lbOnline.BackColor = Color.FromArgb(0xCCCCCC);
//					lbOffLine.BackColor =Color.FromArgb(0xFFFFFF);	
					cmdOnPosition.Visible =false;
					cmdOffPosition.Enabled =true;

				}
				else
				{
//					lbOnline.BackColor = Color.FromArgb(0xFFFFFF);
//					lbOffLine.BackColor =Color.FromArgb(0xCCCCCC);					
					cmdOnPosition.Visible =true;
					cmdOffPosition.Visible =false;

				}

				if (Request.QueryString["Position_ID"] != null)
					PositionID = Request.QueryString["Position_ID"].ToString();
				else if (Request.QueryString["PositionID"] != null)
					PositionID = Request.QueryString["PositionID"].ToString();
				else
					PositionID = "1";

				//如果要求刷新部门树
				if(Request.QueryString["Refresh"] != null )
				{
					Response.Write("<script language='javascript'>parent.LeftFrame.location.reload();</script>");
				}
				
				cmdOnPosition.Attributes.Add("Onclick","javascript:return confirm('是否让选中的人复职？');");
				cmdOffPosition.Attributes.Add("Onclick","javascript:return confirm('是否让选中的人离职？');");


				BindGrid();
			}
			
		}
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion
		private void BindGrid()
		{
			SqlDataReader dr=null; //存放人物的数据
			Database db = new Database();
			SqlParameter[] prams = {
									   db.MakeInParam("@Position_ID",SqlDbType.Int,4,PositionID),
									   db.MakeInParam("@Dimission",SqlDbType.Bit,1,DisplayType)
								   };
            try
            {
                db.RunProc("sp_GetStaffInPosition", prams, out dr);
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                dbStaffList.DataSource = dt.DefaultView;
                dbStaffList.DataBind();
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


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
			this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
			this.cmdUpdateCaste.Click += new System.EventHandler(this.cmdUpdateCaste_Click);
			this.cmdNewStaff.Click += new System.EventHandler(this.cmdNewStaff_Click);
			this.cmdPositionOperate.Click += new System.EventHandler(this.cmdPositionOperate_Click);
			this.cmdSetRight.Click += new System.EventHandler(this.cmdSetRight_Click);
			this.cmdOnPosition.Click += new System.EventHandler(this.cmdOnPosition_Click);
			this.cmdOffPosition.Click += new System.EventHandler(this.cmdOffPosition_Click);
			this.cmdChangePosition.Click += new System.EventHandler(this.cmdChangePosition_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private string GetSelectedItemID(string controlID)
		{
			String selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dbStaffList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dbStaffList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}


		private void lbOffLine_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?PositionID=" + PositionID.ToString() + "&DisplayType=1");
		}

		private void lbOnline_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("Listview.aspx?PositionID=" + PositionID.ToString() + "&DisplayType=0");
		}

		private void cmdNewStaff_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("NewStaff.aspx?PositionID=" + PositionID.ToString() + "&DisplayType =0");
		}

		private void cmdPositionOperate_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("OPosition.aspx?PositionID=" + PositionID.ToString());
		}

		private void cmdSetRight_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("../AssignRule/RightListview.aspx?ObjID=" + PositionID.ToString() + "&displayType=0");
		}


		//离职,复职通知
		private void sms_all(int i)
		{
			string strStaffID=this.GetSelectedItemID("Staff_ID");
			SqlDataReader dr_this=null;//被选择人员
            try
            {
                UDS.Components.Staff sta = new UDS.Components.Staff();
                dr_this = sta.GetStaffInfo(strStaffID);
                SMS sm = new SMS();
                //处理短信提醒
                while (dr_this.Read())
                {
                    string Position_name = dr_this["Position_name"].ToString();
                    SqlDataReader dr_isok=null;//所有在职人员
                    try
                    {
                        dr_isok = sta.GetAllStaffs();
                        while (dr_isok.Read())
                        {
                            string Staff_name = dr_isok["Staff_name"].ToString();
                            if (i == 0)
                                sm.SendMsg(Username, Staff_name, Position_name + " 处员工:" + dr_this["RealName"].ToString() + ",已经离职,特此通知.", 1, DateTime.Now, "", 0, 0);
                            else
                                sm.SendMsg(Username, dr_isok["Staff_name"].ToString(), dr_this["Position_name"].ToString() + " 处员工:" + dr_this["RealName"].ToString() + ",已经恢复原职,特此通知.", 1, DateTime.Now, "", 0, 0);
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

		private void cmdOnPosition_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			UDS.Components.Database db = new UDS.Components.Database();
			if(selectedID.Trim()!="")
			{
				SqlParameter[] prams = {
										   db.MakeInParam("@StaffIDS",SqlDbType.VarChar,300,selectedID)
									   };
				db.RunProc("sp_StaffRehab",prams);
				if(this.cbRemind.Checked==true)
					sms_all(1);
			}
			Response.Redirect("Listview.aspx?PositionID="+PositionID+"&displayType="+DisplayType.ToString());			
		}

		private void cmdOffPosition_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			if(selectedID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.Dimission(selectedID)==true)
				{
					if(this.cbRemind.Checked==true)
						sms_all(0);
					//Response.Write("<script language=javascript>alert('离职成功！');</script>");		
					BindGrid();
				}
				person = null;				
			}
			else
				Response.Write("<script language=javascript>alert('请选择要离职的人员！');</script>");		
		
		}

		private void cmdChangePosition_Click(object sender, System.EventArgs e)
		{
			string selectedID = GetSelectedItemID("Staff_ID");
			if(selectedID.Trim()!="")	
				Response.Redirect("ChangePosition.aspx?PositionID="+PositionID+"&StaffIDS="+selectedID+"&DisplayType="+DisplayType.ToString()+"&BackFilePath="+Request.CurrentExecutionFilePath);
			else
				Response.Write("<script language=javascript>alert('请选择要调职的人员！');</script>");			
		}

		private void cmdUpdateCaste_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("UpdateCaste.aspx?PositionID=" + PositionID.ToString());
		}
	

	}
}
