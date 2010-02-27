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

namespace UDS.SubModule.Vehicle
{
	/// <summary>
	/// ManageStaff 的摘要说明。
	/// </summary>
    public class VehicleManage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbMyNote;

        protected System.Web.UI.WebControls.DataGrid dbVehicleList;
       
        protected System.Web.UI.WebControls.Button btnSearch;
        protected System.Web.UI.WebControls.Label LabelPageInfo;

        protected System.Web.UI.WebControls.TextBox txtDepartment;
        protected System.Web.UI.WebControls.TextBox txtUseTime;

        protected System.Web.UI.WebControls.DropDownList ddlApplyCar;
        protected System.Web.UI.WebControls.DropDownList ddlNature;

		public int DisplayType;
		
		protected static string Username;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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


			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				//BindGrid();

                DdlBindData();
			}

            
		}

        private void DdlBindData()
        {
            object[] obj = new object[] { };
            DataTable dt = VehicleObject.GetAllCar(obj);
            this.ddlApplyCar.DataSource = dt;
            this.ddlApplyCar.DataTextField = "carname";
            this.ddlApplyCar.DataValueField = "ID";
            this.ddlApplyCar.DataBind();
            ListItem item_Car = new ListItem("", "");//加入空项
            this.ddlApplyCar.Items.Insert(0, item_Car);
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
            //this.lbMyNote.Click += new System.EventHandler(this.lbMyNote_Click);
            //this.lbNoteCollect.Click += new System.EventHandler(this.lbNoteCollect_Click);
            //this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //this.btnShoucang.Click += new System.EventHandler(this.btnShoucang_Click);
            //this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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

		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
            dbVehicleList.CurrentPageIndex = e.NewPageIndex;

            
                SearchBindGrid();
		}
		#endregion


		private void btn_Search_Click(object sender, System.EventArgs e)
		{
            SearchBindGrid();
		}

        /// <summary>
        /// 查询数据绑定
        /// </summary>
        private void SearchBindGrid()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            string strApplyCar = this.ddlApplyCar.SelectedValue;
            string strNature = this.ddlNature.SelectedValue;
            this.txtUseTime.Text = Request.Form["txtUseTime"].ToString();

            string strUseTime = Request.Form["txtUseTime"].ToString(); 
            string strDepartment = "%" + this.txtDepartment.Text.Trim() + "%";

            object[] paramsValue = new object[] { strUserid, strApplyCar, strNature, strUseTime, strDepartment };

            DataTable dt = VehicleObject.SearchVehicle(paramsValue);

            this.dbVehicleList.DataSource = dt;//.DefaultView;
            this.dbVehicleList.DataBind();

            LabelPageInfo.Text = "当前（第" + (dbVehicleList.CurrentPageIndex + 1).ToString() + "页 共" + dbVehicleList.PageCount.ToString() + "页）";
        }
	}
}
