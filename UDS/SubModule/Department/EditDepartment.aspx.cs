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
using UDS.Components;
using System.Data.SqlClient;
using ActiveRecord;
using ActiveRecord.Service;


namespace UDS.SubModule.Department
{
    public partial class EditDepartment : System.Web.UI.Page
    {

        public int DeptID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            //HttpCookie UserCookie = Request.Cookies["Username"];
            //string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

            //if (Username.Equals("admin"))
            //    isAdmin = true;


            DeptID = Request.QueryString["DeptID"] != null ? Int32.Parse(Request.QueryString["DeptID"].ToString()) : 0;
            if (DeptID > 0 && !Page.IsPostBack)
            {
                Bangding();
            }
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            try
            {
                if (DeptID == 0)
                {
                   // DeptID = df.AddDept(txtDeptName.Text, txtRemark.Text);
                  
                    Dept dept = new Dept();
                    dept.Dept_Name = txtDeptName.Text;
                    dept.Dept_Remark = txtRemark.Text;
                    dept.Save();
                    
                }
                else
                {
                    df.UpdateDept(DeptID, txtDeptName.Text, txtRemark.Text);
                }
            }
            finally
            {
                if (df != null)
                    df = null;
            }
            Server.Transfer("DepartmentManagement.aspx");
        }

        private void Bangding()
        {
            SqlDataReader dr;
            Database db = new Database();
            SqlParameter[] parms = {
										db.MakeInParam("@DeptID",SqlDbType.Int  ,4,DeptID),
									};
            db.RunProc("sp_Flow_GetDept", parms, out dr);
            try
            {
                if (dr.Read())
                {
                    txtDeptName.Text = dr["Dept_Name"].ToString();
                    txtRemark.Text = dr["Dept_Remark"].ToString(); 
                }

                if (db != null)
                {
                    db.Close();
                    db = null;
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
                dr = null;
            }

        }
    }
}
