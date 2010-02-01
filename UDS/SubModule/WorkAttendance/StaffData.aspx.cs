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

namespace UDS.SubModule.WorkAttendance
{
    /// <summary>
    /// StaffData 的摘要说明。
    /// </summary>
    public class StaffData : System.Web.UI.Page
    {
        private string staffid;
        private string begintime, endtime;
        private string type;
        protected System.Web.UI.WebControls.Literal ltlname;
        protected System.Web.UI.WebControls.Literal ltlbegintime;
        protected System.Web.UI.WebControls.Literal ltlendtime;
        protected System.Web.UI.WebControls.Literal lbltype;
        protected System.Web.UI.WebControls.DataGrid grdStaff;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            string filter = "";
            if (!Page.IsPostBack)
            {
                //try

                staffid = (Request.QueryString["staffid"] == null) ? "0" : Request.QueryString["staffid"].ToString();
                begintime = (Request.QueryString["begintime"] == null) ? DateTime.Now.ToString() : Request.QueryString["begintime"].ToString();
                endtime = (Request.QueryString["endtime"] == null) ? DateTime.Now.ToString() : Request.QueryString["endtime"].ToString();
                type = (Request.QueryString["type"] == null) ? DateTime.Now.ToString() : Request.QueryString["type"].ToString();
                switch (type)
                {
                    case "1": type = "正常上班"; filter = "OnDuty_Status = false and OffDuty_Status = false"; break;
                    case "2": type = "迟到"; filter = "OnDuty_Status = true"; break;
                    case "3": type = "早退"; filter = "OffDuty_Status = true"; break;
                    case "4": type = "未考勤"; break;
                    case "5": type = "总考勤"; break;
                }

                Database db = new Database();
                SqlDataReader dr =null;
                SqlDataReader  dr1=null;

                try
                {
                    //得到用户名
                    SqlParameter[] pram = {
											   db.MakeInParam("@ids",SqlDbType.VarChar,1000,staffid)
					};
                    db.RunProc("sp_WA_GetSelectedStaffFromID", pram, out dr1);
                    while (dr1.Read())
                    {
                        ltlname.Text = dr1["staff_name"].ToString();
                    }
                    dr1.Close();
                    db.Dispose();

                    if (type == "未考勤")
                    {
                        SqlParameter[] prams = {
												    db.MakeInParam("@staffid",SqlDbType.Int,4,staffid),
													db.MakeInParam("@begintime",SqlDbType.DateTime,8,begintime),
													db.MakeInParam("@endtime",SqlDbType.DateTime,8,endtime)
						};

                        db.RunProc("sp_WA_GetAbsenceDay", prams, out dr);
                        DataTable table = Tools.ConvertDataReaderToDataTable(dr);//应该出勤的天数

                        DataColumn myDataColumn = new DataColumn();
                        myDataColumn.DataType = System.Type.GetType("System.String");
                        myDataColumn.ColumnName = "OnDuty";
                        table.Columns.Add(myDataColumn);

                        myDataColumn = new DataColumn();
                        myDataColumn.DataType = System.Type.GetType("System.String");
                        myDataColumn.ColumnName = "OffDuty";
                        table.Columns.Add(myDataColumn);

                        myDataColumn = new DataColumn();
                        myDataColumn.DataType = System.Type.GetType("System.String");
                        myDataColumn.ColumnName = "OnDuty_MemoID";
                        table.Columns.Add(myDataColumn);

                        myDataColumn = new DataColumn();
                        myDataColumn.DataType = System.Type.GetType("System.String");
                        myDataColumn.ColumnName = "OffDuty_MemoID";
                        table.Columns.Add(myDataColumn);

                        table.DefaultView.Sort = "WorkDate ASC";
                        grdStaff.DataSource = table.DefaultView;
                        grdStaff.DataBind();
                    }
                    else
                    {

                        SqlParameter[] prams = {
												   db.MakeInParam("@begintime",SqlDbType.DateTime,8,begintime),
												   db.MakeInParam("@endtime",SqlDbType.DateTime,8,endtime),
												   db.MakeInParam("@ids",SqlDbType.VarChar,1000,staffid),
												   db.MakeInParam("@idtype",SqlDbType.VarChar,50,"staff")
											   };
                        db.RunProc("sp_WA_GetAttendanceData", prams, out dr);
                        DataTable table = Tools.ConvertDataReaderToDataTable(dr);
                        table.DefaultView.RowFilter = filter;

                        grdStaff.DataSource = table.DefaultView;
                        grdStaff.DataBind();
                    }

                    ltlbegintime.Text = begintime;
                    ltlendtime.Text = endtime;
                    lbltype.Text = type;

                }
                finally//关闭db
                {
                    if (db != null)
                    {
                        db.Close();
                    }
                    if (dr != null)
                    {
                        dr.Close();
                    }
                    if (dr1 != null)
                    {
                        dr1.Close();
                    } 
                }
                //catch(Exception ex)
                //{
                //	UDS.Components.Error.Log(ex.Message);
                //	Server.Transfer("../Error.aspx");
                //}

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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

    }
}
