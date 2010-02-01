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

namespace UDS.SubModule.WorkAttendance.Report
{
	/// <summary>
	/// DutyReport 的摘要说明。
	/// </summary>
	public class DutyReport : System.Web.UI.Page
	{
	
		protected DataSet ds_Duty;
		protected CrystalDecisions.Web.CrystalReportViewer cv_Duty;
		protected System.Web.UI.WebControls.LinkButton lbtn_IEPrint;
		protected DataSet ds_Report;
		protected string idtype,ids,begintime,endtime;
		protected System.Web.UI.WebControls.Button btn_Change;
		protected System.Web.UI.WebControls.DropDownList ddl_FileFormat;
		protected rpt_DutyReport myreport;
	

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				idtype = Request.QueryString["idtype"].ToString();
				ids    = Request.QueryString["ids"].ToString();
				begintime = Request.QueryString["begintime"].ToString();
				endtime = Request.QueryString["endtime"].ToString();

				ViewState["idtype"] = idtype;
				ViewState["ids"]    = ids;
				ViewState["begintime"]    = begintime;
				ViewState["endtime"]    = endtime;
			}
			else
			{
				idtype = ViewState["idtype"].ToString();
				ids	   = ViewState["ids"].ToString();
				begintime = ViewState["begintime"].ToString();
				endtime	= ViewState["endtime"].ToString();
			}

			ds_Duty = (DataSet)Cache["WA_Duty"];
			//从TotalDuty.xsd获得架构
			ds_Report = new DataSet();
			ds_Report.ReadXmlSchema(Request.MapPath(".")+"\\TotalDuty.xsd");

			#region 缓存如果不存在
			if(ds_Duty==null)
			{	
				//重新获取ds_Duty
				SqlDataReader dr,dr1,dr2;
                dr = null;
                dr1 = null;
                dr2 = null;
				SqlParameter[] prams = new SqlParameter[4];
				UDS.Components.Database db = new UDS.Components.Database();
                try
                {
                    DataSet ds = new DataSet();
                    //得到考勤数据
                    prams[0] = db.MakeInParam("@begintime", SqlDbType.DateTime, 8, begintime);
                    prams[1] = db.MakeInParam("@endtime", SqlDbType.DateTime, 8, endtime);
                    prams[2] = db.MakeInParam("@ids", SqlDbType.VarChar, 1000, ids);
                    prams[3] = db.MakeInParam("@idtype", SqlDbType.VarChar, 50, idtype);
                    db.RunProc("sp_WA_GetAttendanceData", prams, out dr);
                    DataTable datatable = Tools.ConvertDataReaderToDataTable(dr);
                    ds.Tables.Add(datatable);
                    db.Dispose();
                    dr.Close();
                    //得到人员名单
                    if (idtype == "staff")
                    {
                        SqlParameter[] prams1 = { db.MakeInParam("@ids", SqlDbType.VarChar, 1000, ids) };
                        db.RunProc("sp_WA_GetSelectedStaffFromID", prams1, out dr1);
                        DataTable datatable1 = Tools.ConvertDataReaderToDataTable(dr1);
                        ds.Tables.Add(datatable1);
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
                        db.Dispose();
                        dr1.Close();
                    }

                    SqlParameter[] prams2 = {
											db.MakeInParam("@begintime",SqlDbType.DateTime,8,begintime),
											db.MakeInParam("@endtime",SqlDbType.DateTime,8,endtime)
										};
                    db.RunProc("sp_WA_GetDutyDay", prams2, out dr2);
                    DataTable datatable2 = Tools.ConvertDataReaderToDataTable(dr2);
                    ds.Tables.Add(datatable2);
                    db.Dispose();
                    dr2.Close();

                    //缓存数据
                    Cache["WA_Duty"] = ds;

                    ds_Duty = (DataSet)Cache["WA_Duty"];
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
			#endregion
			
			//生成ds_Report以可以绑定到rpt
			//ds_Duty.Tables[0] 考勤数据
			//ds_Duty.Tables[1] 人员数据
			//ds_Duty.Tables[2] 考勤日期数据

			//遍历人员数据表以生成新的ds_Report
			for(int i=0;i<ds_Duty.Tables[1].Rows.Count;i++)
			{
				DataRow row = ds_Report.Tables[0].NewRow();
				row[0] = ds_Duty.Tables[1].Rows[i]["RealName"];
				row[1] = GetDutyDateCount(ds_Duty.Tables[0].DefaultView,ds_Duty.Tables[2].DefaultView,ds_Duty.Tables[1].Rows[i]["Staff_ID"].ToString(),0);
				row[2] = GetDutyDateCount(ds_Duty.Tables[0].DefaultView,ds_Duty.Tables[2].DefaultView,ds_Duty.Tables[1].Rows[i]["Staff_ID"].ToString(),1);
				row[3] = GetDutyDateCount(ds_Duty.Tables[0].DefaultView,ds_Duty.Tables[2].DefaultView,ds_Duty.Tables[1].Rows[i]["Staff_ID"].ToString(),2);
				row[4] = GetDutyDateCount(ds_Duty.Tables[0].DefaultView,ds_Duty.Tables[2].DefaultView,ds_Duty.Tables[1].Rows[i]["Staff_ID"].ToString(),3);
				row[5] = GetDutyDateCount(ds_Duty.Tables[0].DefaultView,ds_Duty.Tables[2].DefaultView,ds_Duty.Tables[1].Rows[i]["Staff_ID"].ToString(),4);

				ds_Report.Tables[0].Rows.Add(row);
			}

			myreport = new rpt_DutyReport();
			myreport.SetDataSource(ds_Report);
			cv_Duty.ReportSource = myreport;
			cv_Duty.DataBind();
		}

		string  GetDutyDateCount(DataView tv_DutyData,DataView tv_DutyDate,string staffid,int type)
		{

			//type:0 正常 1：迟到 2：早退 3：未考勤 4：总考勤天数
			switch(type)
			{
				case 0:
					tv_DutyData.RowFilter = "OnDuty_Status = false and OffDuty_Status = false and staff_id="+staffid;
					break;
				case 1:
					tv_DutyData.RowFilter = "OnDuty_Status=true and staff_id="+staffid;
					break;
				case 2:
					tv_DutyData.RowFilter = "OffDuty_Status = true and staff_id="+staffid;
					break;
				case 3:
					tv_DutyData.RowFilter = "staff_id=" + staffid;
					return((tv_DutyDate.Count - tv_DutyData.Count).ToString());
					break;
				case 4:
					break;
			}
			return(tv_DutyData.Count.ToString());
		 
		} 

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
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
			this.lbtn_IEPrint.Click += new System.EventHandler(this.lbtn_IEPrint_Click);
			this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbtn_IEPrint_Click(object sender, System.EventArgs e)
		{
			if(lbtn_IEPrint.Text == "IE打印预览")
			{
				cv_Duty.SeparatePages = false;
				cv_Duty.DisplayToolbar = false;
				lbtn_IEPrint.Text = "取消IE打印预览";
			}
			else
			{
				cv_Duty.SeparatePages = true;
				cv_Duty.DisplayToolbar = true;
				lbtn_IEPrint.Text = "IE打印预览";
			}
			
		}

		private void btn_Change_Click(object sender, System.EventArgs e)
		{
			string filetype = "";
			filetype = ddl_FileFormat.SelectedValue;
			string contenttype = "";
			

			string myfilename = Request.MapPath(".")+"\\ReportExportFile\\"+Session.SessionID+"."+filetype;
			CrystalDecisions.Shared.DiskFileDestinationOptions mydiskfiledestinationoptions = new CrystalDecisions.Shared.DiskFileDestinationOptions();
			mydiskfiledestinationoptions.DiskFileName = myfilename;
			CrystalDecisions.Shared.ExportOptions myExportOptions = myreport.ExportOptions;
			myExportOptions.DestinationOptions = mydiskfiledestinationoptions;
			myExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;

			switch(ddl_FileFormat.SelectedItem.Value)
			{
				case "pdf":
					contenttype = "application/pdf";
					myExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
					break;
				case "doc":
					contenttype = "application/msword";
					myExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
					break;
			}
			
			
			myreport.Export();

			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = contenttype;
			Response.WriteFile(myfilename);
			Response.Flush();
			Response.Close();

			System.IO.File.Delete(myfilename);
		}
	}
}
