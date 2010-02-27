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

namespace UDS.SubModule.Vehicle
{
	/// <summary>
	/// NewStaff 的摘要说明。
	/// </summary>
    public class NewCar : System.Web.UI.Page
	{
		public	static string  PositionID;	
		
		public	int ReturnPage=0;
		protected static string Username;
        protected System.Web.UI.WebControls.TextBox txtCarType;
        protected System.Web.UI.WebControls.TextBox txtCarNum;
        protected System.Web.UI.WebControls.TextBox txtMemo;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                if (Request.QueryString["ID"] != null)
                {
                    object[] paramsValue = new object[] { Request.QueryString["ID"].ToString() };
                    DataTable dt = VehicleObject.GetCarByID(paramsValue);

                    this.txtCarType.Text = dt.Rows[0]["CarType"].ToString();
                    this.txtCarNum.Text = dt.Rows[0]["CarNum"].ToString();
                    this.txtMemo.Text = dt.Rows[0]["Memo"].ToString();
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
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	

		private void cmdSubmit_Click(object sender, System.EventArgs e)
        {

            string strCarType = this.txtCarType.Text;
            string strCarNum = this.txtCarNum.Text;
            string strMemo = this.txtMemo.Text;

            //获取登录用户ID
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            if (Request.QueryString["ID"] != null)
            {
                string strID = Request.QueryString["ID"].ToString();
                object[] Params = new object[] { null, strID, strCarType,strCarNum, strMemo };

                string strReturn = VehicleObject.UpdateCar(Params);

                if (strReturn == "0")
                {
                    Page.RegisterStartupScript("", "<script>alert('修改失败！');</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('修改成功！');</script>");
                }
            }
            else
            {
                object[] Params = new object[] { null, strCarType, strCarNum, strMemo };

                string strReturn = VehicleObject.InsertCar(Params);

                if (strReturn == "0")
                {
                    Page.RegisterStartupScript("", "<script>alert('添加失败！');</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('添加成功！');</script>");
                }
            }
        }
	}
}
