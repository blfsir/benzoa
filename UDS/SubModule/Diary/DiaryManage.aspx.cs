using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;
using System.Text;


namespace UDS.SubModule.Diary
{
    public partial class DiaryManage : System.Web.UI.Page
    {
        public int DisplayType;

        protected static string Username;

        protected static string staffids ;

        protected void Page_Load(object sender, EventArgs e)
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

            if (DisplayType == 0)
            {
                this.td_title.InnerHtml = "<font color=\"#006699\">我的日记</font>";
                this.tr_Tj.Visible = false;
                //this.btnAdd.Visible = true;
                

             //   this.dbDiaryList.Columns[3].Visible = true;
            }
            else if (DisplayType == 1)//日记收藏
            {
                this.td_title.InnerHtml = "<font color=\"#006699\">日记查询</font>";
                this.tr_Tj.Visible = true;
               // this.btnAdd.Visible = false;
                

               // this.dbDiaryList.Columns[3].Visible = false;
            }

            if (!Page.IsPostBack)
            {
                //操作者登录名
                HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                BindGrid();

                BindStaff();
            }
        }

        private void BindStaff()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);
            string username = Server.UrlDecode(Request.Cookies["UserName"].Value);
            

            object[] paramsValue = new object[] { strUserid };

            DataTable dt = DiaryObject.SearchSubStaff(paramsValue);
            StringBuilder sb = new StringBuilder();
            sb.Append(strUserid);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append(",").Append(dr["staff_id"].ToString());
                }
            }
            staffids = sb.ToString();

            ddlStaff.DataTextField = "staff_name";
            ddlStaff.DataValueField = "staff_id";
            ddlStaff.DataSource = dt;
            ddlStaff.DataBind();
            ddlStaff.Items.Insert(0, new ListItem(username, strUserid));
            ddlStaff.Items.Insert(0, new ListItem("所有人员", "0"));

        }


        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
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
            //if (DisplayType == 0)
            //{
            object[] paramsValue = new object[] { strUserid };

            DataTable dt = DiaryObject.GetDiaryListByUserID(paramsValue);

            this.dbDiaryList.DataSource = dt;//.DefaultView;
            this.dbDiaryList.DataBind();
            //}
            //else
            //{
            //    string strBeginDate = this.txtBeginDate.Text.Trim();
            //    string strEndDate = this.txtEndDate.Text.Trim();
            //    string strContents = "%" +this.txtContents.Text.Trim()+ "%";

            //    object[] paramsValue = new object[] { strUserid, strBeginDate, strEndDate, strContents };

            //    DataTable dt = DiaryObject.SearchDiary(paramsValue);

            //    this.dbDiaryList.DataSource = dt;//.DefaultView;
            //    this.dbDiaryList.DataBind();
            //}

            LabelPageInfo.Text = "当前（第" + (dbDiaryList.CurrentPageIndex + 1).ToString() + "页 共" + dbDiaryList.PageCount.ToString() + "页）";
        }
        #region 翻页事件
        public void DataGrid_PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            dbDiaryList.CurrentPageIndex = e.NewPageIndex;

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
            foreach (DataGridItem item in dbDiaryList.Items)
            {
                if (((CheckBox)item.FindControl(controlID)).Checked == true)
                    selectedID += dbDiaryList.DataKeys[item.ItemIndex] + ",";
            }
            if (selectedID.Length > 0)
                selectedID = selectedID.Substring(0, selectedID.Length - 1);
            return selectedID;
        }


        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("NewDiary.aspx?ReturnPage=1");
        }

        

        private void btn_Search_Click(object sender, System.EventArgs e)
        {
            this.txtIsSearch.Text = "1";
            SearchBindGrid();
        }

        /// <summary>
        /// 查询数据绑定
        /// </summary>
        private void SearchBindGrid()
        {
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);
            this.txtBeginDate.Text = Request.Form["txtBeginDate"].ToString();
            this.txtEndDate.Text = Request.Form["txtEndDate"].ToString();

            string strBeginDate = Request.Form["txtBeginDate"].ToString(); //this.txtBeginDate.Text.Trim();
            string strEndDate = Request.Form["txtEndDate"].ToString(); //this.txtEndDate.Text.Trim();
            string strContents = "%" + this.txtContents.Text.Trim() + "%";

            string searchIDs = staffids;

            if (ddlStaff.SelectedValue != "0")
            {
                searchIDs = ddlStaff.SelectedValue;
            }

            object[] paramsValue = new object[] { searchIDs, strBeginDate, strEndDate, strContents };

            DataTable dt = DiaryObject.SearchDiary(paramsValue);

            this.dbDiaryList.DataSource = dt;//.DefaultView;
            this.dbDiaryList.DataBind();

            LabelPageInfo.Text = "当前（第" + (dbDiaryList.CurrentPageIndex + 1).ToString() + "页 共" + dbDiaryList.PageCount.ToString() + "页）";
        }
 

        protected void lbNoteCollect_Click(object sender, EventArgs e)
        {
                Server.Transfer("DiaryManage.aspx?DisplayType=1");
        }

        protected void lbMyNote_Click(object sender, EventArgs e)
        {
            Server.Transfer("DiaryManage.aspx?DisplayType=0");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtIsSearch.Text = "1";
            SearchBindGrid();
        }

        
      
       

         
    }
}
