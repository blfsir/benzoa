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
    public class CarManage : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid dbCarList;
        protected System.Web.UI.WebControls.Button btnAdd;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.Label LabelPageInfo;

		
		public int DisplayType;
		
		protected static string Username;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

				BindGrid();
			}

            btnDelete.Attributes.Add("OnClick","return confirm('确认删除？');");

            
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
        /// 数据绑定
        /// </summary>
        private void BindGrid()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            object[] paramsValue = new object[] { };

            DataTable dt = VehicleObject.GetAllCar(paramsValue);

            this.dbCarList.DataSource = dt;
            this.dbCarList.DataBind();

            LabelPageInfo.Text = "当前（第" + (dbCarList.CurrentPageIndex + 1).ToString() + "页 共" + dbCarList.PageCount.ToString() + "页）";
        }
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
            dbCarList.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
		}
		#endregion

        /// <summary>
        /// 获取选择的ID
        /// </summary>
        /// <param name="controlID"></param>
        /// <returns></returns>
		private string GetSelectedItemID(string controlID)
		{
			string selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
            foreach (DataGridItem item in dbCarList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
                    selectedID += dbCarList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}


        private void btnAdd_Click(object sender, System.EventArgs e)
		{
            Server.Transfer("NewCar.aspx");
		}

        /// <summary>
        /// 删除
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
                    VehicleObject.DeleteCar(Params);
                }

                BindGrid();
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('请选择要删除的车辆！');</script>");
            }
		}

	}
}
