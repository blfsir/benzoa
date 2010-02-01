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
	/// ChangePosition 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//操作者登录名
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
			this.cmdSubmit.ServerClick += new System.EventHandler(this.cmdSubmit_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//调职通知
		private void sms_all()
		{
			SqlDataReader dr_this=null;//被选择人员
            try
            {
                UDS.Components.Staff sta = new UDS.Components.Staff();
                dr_this = sta.GetStaffInfo(selectedID);
                SMS sm = new SMS();
                //处理短信提醒

                while (dr_this.Read())
                {
                    string Position_name = dr_this["Position_name"].ToString();
                    SqlDataReader dr_isok;//所有在职人员
                    dr_isok = sta.GetAllStaffs();
                    while (dr_isok.Read())
                    {
                        string Staff_name = dr_isok["Staff_name"].ToString();
                        sm.SendMsg(Username, Staff_name, Position_name + "处员工:" + dr_this["RealName"].ToString() + ",已经调职到" + cboPosition.Items[cboPosition.SelectedIndex].Text + "处,特此通知.", 1, DateTime.Now, "", 0, 0);
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
			SqlDataReader dr_this=null;//被选择人员
            try
            {
                UDS.Components.Staff sta = new UDS.Components.Staff();
                dr_this = sta.GetStaffInfo(selectedID);
                SMS sm = new SMS();
                //处理短信提醒
                while (dr_this.Read())
                {
                    string Position_name = dr_this["Position_name"].ToString();
                    SqlDataReader dr_isok;//所有在职人员
                    dr_isok = sta.GetAllStaffs();
                    while (dr_isok.Read())
                    {
                        string Staff_name = dr_isok["Staff_name"].ToString();
                        if (i == 0)
                            sm.SendMsg(Username, Staff_name, Position_name + " 处员工:" + dr_this["RealName"].ToString() + ",已经离职,特此通知.", 1, DateTime.Now, "", 0, 0);
                        else
                            sm.SendMsg(Username, dr_isok["Staff_name"].ToString(), dr_this["Position_name"].ToString() + " 处员工:" + dr_this["RealName"].ToString() + ",已经恢复原职,特此通知.", 1, DateTime.Now, "", 0, 0);
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
