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
    /// StaffData ��ժҪ˵����
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
            // �ڴ˴������û������Գ�ʼ��ҳ��
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
                    case "1": type = "�����ϰ�"; filter = "OnDuty_Status = false and OffDuty_Status = false"; break;
                    case "2": type = "�ٵ�"; filter = "OnDuty_Status = true"; break;
                    case "3": type = "����"; filter = "OffDuty_Status = true"; break;
                    case "4": type = "δ����"; break;
                    case "5": type = "�ܿ���"; break;
                }

                Database db = new Database();
                SqlDataReader dr =null;
                SqlDataReader  dr1=null;

                try
                {
                    //�õ��û���
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

                    if (type == "δ����")
                    {
                        SqlParameter[] prams = {
												    db.MakeInParam("@staffid",SqlDbType.Int,4,staffid),
													db.MakeInParam("@begintime",SqlDbType.DateTime,8,begintime),
													db.MakeInParam("@endtime",SqlDbType.DateTime,8,endtime)
						};

                        db.RunProc("sp_WA_GetAbsenceDay", prams, out dr);
                        DataTable table = Tools.ConvertDataReaderToDataTable(dr);//Ӧ�ó��ڵ�����

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
                finally//�ر�db
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
            // CODEGEN���õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

    }
}
