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
using System.Data.SqlClient;

namespace UDS.SubModule.Plan
{
    public partial class PlanManage : System.Web.UI.Page
    {
        public int DisplayType = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.ddlPlanObjectType.SelectedValue = "个人计划";
                BindData("周计划");
            }
        }

        public string GetSelectImage(string NormalImg, string SelectedImg, int selected, int position)
        {
            if (selected == position)
                return SelectedImg;
            else
                return NormalImg;
        }

        private void BindData(string planPeriodType)
        {
            SqlDataReader dr;
            string username = Server.UrlDecode(Request.Cookies["UserName"].Value);

            UDS.Components.Staff staff = new UDS.Components.Staff();
            dr = staff.FindPlan(this.ddlPlanObjectType.SelectedValue, planPeriodType, "", username);

            DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);

            //this.dgPlanList.DataSource = dt.DefaultView;
            //dgPlanList.DataBind();

            this.dbStaffList.DataSource = dt.DefaultView;

            dbStaffList.DataBind();
        }

        protected void lbtnWeek_Click(object sender, EventArgs e)
        {
            DisplayType = 1;
            
            BindData("周计划");
        }

        protected void lbtnMonth_Click(object sender, EventArgs e)
        {
            DisplayType = 2;
            BindData("月计划");

        }

        protected void lbtnYear_Click(object sender, EventArgs e)
        {
            DisplayType = 4;
            BindData("年计划");
        }

        protected void lbtnSeason_Click(object sender, EventArgs e)
        {
            DisplayType = 3;
            BindData("季计划");
        }
    }
}
