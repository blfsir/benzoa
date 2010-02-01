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

namespace UDS.SubModule.Staff
{
    /// <summary>
    /// ModifyInfo 的摘要说明。
    /// </summary>
    public class ModifyInfo : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.DataGrid StaffList;
        protected System.Web.UI.WebControls.TextBox txb_PageNo;
        protected System.Web.UI.WebControls.TextBox txb_ItemPerPage;
        protected System.Web.UI.WebControls.Label lbl_totalrecord;
        protected System.Web.UI.WebControls.ImageButton btn_first;
        protected System.Web.UI.WebControls.ImageButton btn_pre;
        protected System.Web.UI.WebControls.Label lbl_curpage;
        protected System.Web.UI.WebControls.Label lbl_totalpage;
        protected System.Web.UI.WebControls.ImageButton btn_next;
        protected System.Web.UI.WebControls.ImageButton btn_last;
        protected System.Web.UI.HtmlControls.HtmlInputButton btn_Go;

        protected static bool displaytype;
        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (!Page.IsPostBack)
            {
                displaytype = (Request.Params["displayType"] == null) ? false : (Request.Params["displayType"].ToString() == "0") ? false : true;
                BindGrid();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindGrid()
        {
            SqlDataReader dr = null; //存放人物的数据
            Database db = new Database();
            try
            {

                SqlParameter[] prams = {
									    db.MakeInParam("@StaffType",SqlDbType.Bit,1,displaytype)
			};
                db.RunProc("sp_GetAllStaff", prams, out dr);
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);
                //在DataTable的末尾加上空行，使得DataGrid固定行数
                int blankrows = StaffList.PageSize - (dt.Rows.Count % StaffList.PageSize);
                for (int i = 0; i < blankrows; i++)
                {
                    dt.Rows.Add(dt.NewRow());
                }

                StaffList.DataSource = dt.DefaultView;
                StaffList.DataBind();


                //对于空纪录不显示checkbox
                for (int i = 0; i < StaffList.Items.Count; i++)
                {
                    if (StaffList.Items[i].Cells[1].Text == "&nbsp;")
                    {
                        StaffList.Items[i].FindControl("cb_StaffID").Visible = false;
                    }
                }
                lbl_totalrecord.Text = StaffList.PageCount.ToString();
                lbl_curpage.Text = txb_PageNo.Text = (StaffList.CurrentPageIndex + 1).ToString();
                txb_ItemPerPage.Text = StaffList.PageSize.ToString();
                lbl_totalpage.Text = StaffList.PageCount.ToString();
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


        private void PagerButtonClick(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //获得LinkButton的参数值
            String arg = ((ImageButton)sender).CommandArgument;

            switch (arg)
            {
                case ("next"):
                    if (StaffList.CurrentPageIndex < (StaffList.PageCount - 1))
                        StaffList.CurrentPageIndex++;
                    break;
                case ("pre"):
                    if (StaffList.CurrentPageIndex > 0)
                        StaffList.CurrentPageIndex--;
                    break;
                case ("first"):
                    StaffList.CurrentPageIndex = 0;
                    break;
                case ("last"):
                    StaffList.CurrentPageIndex = (StaffList.PageCount - 1);
                    break;
                default:
                    //本页值
                    StaffList.CurrentPageIndex = Convert.ToInt32(arg);
                    break;
            }
            BindGrid();
        }

        private void btnGo_Click(object sender, System.EventArgs e)
        {
            //页面直接跳转的代码
            if (txb_PageNo.Text.Trim() != "")
            {
                int PageI = Int32.Parse(txb_PageNo.Text.Trim()) - 1;
                if (PageI >= 0 && PageI < (StaffList.PageCount))
                    StaffList.CurrentPageIndex = PageI;
            }
            BindGrid();
        }


        private void txb_ItemPerPage_TextChanged(object sender, System.EventArgs e)
        {
            if (txb_ItemPerPage.Text.Trim() != "")
            {
                int itemPage = Int32.Parse(txb_ItemPerPage.Text.Trim());
                if (itemPage > 0)
                    StaffList.PageSize = Int32.Parse(txb_ItemPerPage.Text.Trim());
            }
            BindGrid();
        }

        private string GetSelectedItemID(string controlID)
        {
            String selectedID;
            selectedID = "";
            //遍历DataGrid获得checked的ID
            foreach (DataGridItem item in StaffList.Items)
            {
                if (((CheckBox)item.FindControl(controlID)).Checked)
                    selectedID += item.Cells[1].Text.Trim() + ",";
            }
            selectedID = selectedID.Substring(0, selectedID.Length - 1);
            return selectedID;
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
            this.StaffList.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.StaffList_EditCommand);
            this.StaffList.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.StaffList_UpdateCommand_1);
            this.txb_ItemPerPage.TextChanged += new System.EventHandler(this.txb_ItemPerPage_TextChanged);
            this.btn_first.Click += new System.Web.UI.ImageClickEventHandler(this.PagerButtonClick);
            this.btn_pre.Click += new System.Web.UI.ImageClickEventHandler(this.PagerButtonClick);
            this.btn_next.Click += new System.Web.UI.ImageClickEventHandler(this.PagerButtonClick);
            this.btn_last.Click += new System.Web.UI.ImageClickEventHandler(this.PagerButtonClick);
            this.btn_Go.ServerClick += new System.EventHandler(this.btnGo_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void cmdChangeDepartment_ServerClick(object sender, System.EventArgs e)
        {
            Response.Redirect("../Department/ChangeDepartment.aspx?BackFilePath=" + Request.CurrentExecutionFilePath + "&StaffIDS=" + GetSelectedItemID("cb_StaffID"));
        }

        private void cmdRestoreDocument_ServerClick(object sender, System.EventArgs e)
        {
            UDS.Components.Staff st = new UDS.Components.Staff();
            if (st.ReturnPosition(GetSelectedItemID("cb_StaffID")) == false)
                Server.Transfer("../Error.aspx");
            else
                Response.Redirect("Rehab.aspx");
        }

        private void StaffList_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            StaffList.EditItemIndex = e.Item.ItemIndex;
            BindGrid();

            //造出当前行内的DropDownList

            DropDownList department;
            department = (DropDownList)StaffList.Items[StaffList.EditItemIndex].FindControl("department");
            Database db = new Database();
            SqlDataReader dr;
            try
            {
                db.RunProc("sp_GetAllDepartment", out dr);
                department.DataSource = dr;
                department.DataTextField = "Department_Name";
                department.DataValueField = "Department_ID";

                department.DataBind();
                foreach (ListItem lt in department.Items)
                {
                    if (lt.Value == StaffList.Items[e.Item.ItemIndex].Cells[8].Text)
                        lt.Selected = true;
                }

            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.Message);
                Server.Transfer("../Error.aspx");
            }


        }


        private void StaffList_UpdateCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            Database db = new Database();
            SqlParameter[] prams = {
									   db.MakeInParam("@Staff_ID",SqlDbType.Int,4,Int32.Parse(e.Item.Cells[0].Text)),
									   db.MakeInParam("@RealName",SqlDbType.VarChar,50,((TextBox)e.Item.Cells[1].Controls[1]).Text),
									   db.MakeInParam("@Mobile",SqlDbType.VarChar,50,((TextBox)e.Item.Cells[2].Controls[1]).Text),
									   db.MakeInParam("@Sex",SqlDbType.Bit,1,Convert.ToBoolean(((DropDownList)e.Item.Cells[4].Controls[1]).SelectedItem.Value)),
									   db.MakeInParam("@Email",SqlDbType.VarChar,500,((TextBox)e.Item.Cells[5].Controls[1]).Text),
									   db.MakeInParam("@Department_ID",SqlDbType.Int,4,Int32.Parse(((DropDownList)e.Item.Cells[6].Controls[1]).SelectedItem.Value))
									   
								   };
            try
            {
                db.RunProc("sp_UpdateStaffInfo", prams);
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.Message);
                Server.Transfer("../Error.aspx");
            }
        }

    }
}
