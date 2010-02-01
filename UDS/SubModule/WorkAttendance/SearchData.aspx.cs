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
    /// SearchData 的摘要说明。
    /// </summary>
    public class SearchData : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.TextBox txtbegintime;
        protected System.Web.UI.WebControls.TextBox txtendtime;
        protected System.Web.UI.WebControls.DropDownList ddlsearchbound;
        protected System.Web.UI.WebControls.ListBox lbstaffs;
        protected System.Web.UI.WebControls.CompareValidator cvdate;
        protected System.Web.UI.WebControls.Button btnsearch;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
        protected System.Web.UI.WebControls.ValidationSummary vs1;
        protected System.Web.UI.WebControls.DataGrid AttendanceGrid;
        protected System.Web.UI.WebControls.DropDownList ddldepartments;
        protected System.Data.DataView dvwAttGrid;
        protected System.Data.DataView dvw, dvw1;
        protected System.Web.UI.WebControls.RadioButton rbtnthisweek;
        protected System.Web.UI.HtmlControls.HtmlInputButton btn_Report;
        protected System.Web.UI.WebControls.RadioButton rbtnthismonth;



        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btn_Report.Style["display"] = "none";
                //绑定两个select框
                DataBindObject(ddldepartments);
                DataBindObject(lbstaffs);
                //his.txtbegintime.Text = DateTime.Now.ToShortDateString();
            }

        }

        private void DataBindObject(object sender)
        {
            Database db = new Database();
            SqlDataReader dr=null;
            try
            {
                if (sender.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    db.RunProc("SP_Ext_GetPosition", out dr);
                    ((DropDownList)sender).DataSource = dr;
                    ((DropDownList)sender).DataTextField = "Position_Name";
                    ((DropDownList)sender).DataValueField = "Position_ID";
                    ((DropDownList)sender).DataBind();
                }
                else if (sender.GetType().ToString() == "System.Web.UI.WebControls.ListBox")
                {
                    SqlParameter[] prams = {
											 db.MakeInParam("@StaffType",SqlDbType.Bit,1,0)
					};
                    db.RunProc("sp_GetAllStaff", prams, out dr);
                    ((ListBox)sender).DataSource = dr;
                    ((ListBox)sender).DataTextField = "realname";
                    ((ListBox)sender).DataValueField = "Staff_ID";
                    ((ListBox)sender).DataBind();
                    ((ListBox)sender).SelectedIndex = 0;
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.Message);
                Server.Transfer("../Error.aspx");
            }
            finally //关闭db
            {
                if (db != null)
                {
                    db.Close();
                }
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
            this.ddlsearchbound.SelectedIndexChanged += new System.EventHandler(this.ddlsearchbound_SelectedIndexChanged);
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void ddlsearchbound_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (((DropDownList)sender).SelectedItem.Value == "0")
            {
                ddldepartments.Visible = false;
                lbstaffs.Visible = false;
                lbstaffs.Visible = false;
            }
            else if (((DropDownList)sender).SelectedItem.Value == "1")
            {
                ddldepartments.Visible = true;
                lbstaffs.Visible = false;
            }
            else if (((DropDownList)sender).SelectedItem.Value == "2")
            {
                lbstaffs.Visible = true;
                ddldepartments.Visible = false;
            }
        }

        private void btnsearch_Click(object sender, System.EventArgs e)
        {
            SqlDataReader dr, dr1, dr2;
            dr = null;
            dr1 = null;
            dr2 = null;
            DataSet ds = new DataSet();
            Database db = new Database();
            try
            {
                btn_Report.Style["display"] = "";
                SqlParameter[] prams = new SqlParameter[4];
                string idtype = "";
                string ids = "";
                switch (ddlsearchbound.SelectedIndex)
                {
                    case 0: idtype = "company"; break;
                    case 1: idtype = "Position"; break;
                    case 2: idtype = "staff"; break;
                }
                if (idtype == "staff")
                {
                    foreach (ListItem staffitem in lbstaffs.Items)
                    {
                        if (staffitem.Selected)
                        {
                            ids = ids + staffitem.Value + ",";
                        }
                    }
                    if (ids != "") ids = ids.Substring(0, ids.Length - 1);
                }
                else if (idtype == "Position")
                {
                    ids = ddldepartments.SelectedItem.Value;
                }
                else if (idtype == "company")
                {
                    ids = "";
                }
                try
                {
                    //得到考勤数据

                    this.txtbegintime.Text = Request.Form["txtbegintime"].ToString();
                    this.txtendtime.Text = Request.Form["txtendtime"].ToString();
                    prams[0] = db.MakeInParam("@begintime", SqlDbType.DateTime, 8, this.txtbegintime.Text);
                    prams[1] = db.MakeInParam("@endtime", SqlDbType.DateTime, 8, this.txtendtime.Text);
                    prams[2] = db.MakeInParam("@ids", SqlDbType.VarChar, 1000, ids);
                    prams[3] = db.MakeInParam("@idtype", SqlDbType.VarChar, 50, idtype);
                    db.RunProc("sp_WA_GetAttendanceData", prams, out dr);
                    DataTable datatable = Tools.ConvertDataReaderToDataTable(dr);
                    ds.Tables.Add(datatable);
                    dvw = ds.Tables[0].DefaultView;
                    db.Dispose();
                    dr.Close();
                    //得到人员名单
                    if (idtype == "staff")
                    {
                        SqlParameter[] prams1 = { db.MakeInParam("@ids", SqlDbType.VarChar, 1000, ids) };
                        db.RunProc("sp_WA_GetSelectedStaffFromID", prams1, out dr1);
                        DataTable datatable1 = Tools.ConvertDataReaderToDataTable(dr1);
                        ds.Tables.Add(datatable1);
                        dvwAttGrid = ds.Tables[1].DefaultView;
                        db.Dispose();
                        dr1.Close();
                    }
                    else if (idtype == "Position")
                    {
                        SqlParameter[] prams1 = {
												db.MakeInParam("@Position_id",SqlDbType.Int,4,Int32.Parse(ids)),
												db.MakeInParam("@Dimission",SqlDbType.Bit,1,0)
											};
                        db.RunProc("sp_GetStaffInPosition", prams1, out dr1);
                        DataTable datatable1 = Tools.ConvertDataReaderToDataTable(dr1);
                        ds.Tables.Add(datatable1);
                        dvwAttGrid = ds.Tables[1].DefaultView;
                        db.Dispose();
                        dr1.Close();
                    }
                    else if (idtype == "company")
                    {
                        SqlParameter[] prams1 = {
												db.MakeInParam("@StaffType",SqlDbType.Int,4,0)
											};
                        db.RunProc("sp_GetAllStaff", prams1, out dr1);
                        DataTable datatable1 = Tools.ConvertDataReaderToDataTable(dr1);
                        ds.Tables.Add(datatable1);
                        dvwAttGrid = ds.Tables[1].DefaultView;
                        db.Dispose();
                        dr1.Close();
                    }

                    SqlParameter[] prams2 = {
											db.MakeInParam("@begintime",SqlDbType.DateTime,8,txtbegintime.Text),
											db.MakeInParam("@endtime",SqlDbType.DateTime,8,txtendtime.Text)
				};
                    db.RunProc("sp_WA_GetDutyDay", prams2, out dr2);
                    DataTable datatable2 = Tools.ConvertDataReaderToDataTable(dr2);
                    ds.Tables.Add(datatable2);
                    dvw1 = ds.Tables[2].DefaultView;
                    db.Dispose();
                    dr2.Close();

                    AttendanceGrid.DataSource = dvwAttGrid;
                    AttendanceGrid.DataBind();

                    //缓存数据
                    Cache["WA_Duty"] = ds;

                    btn_Report.Attributes["onclick"] = "window.open('Report/DutyReport.aspx?idtype=" + idtype + "&ids=" + ids + "&begintime=" + txtbegintime.Text + "&endtime=" + txtendtime.Text + "')";
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.Message);
                    Server.Transfer("../Error.aspx");
                }

            }
            finally
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
                if (dr2 != null)
                {
                    dr2.Close();
                } 
            }
        }






    }
}
