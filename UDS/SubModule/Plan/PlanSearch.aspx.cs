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
using System.Globalization;

namespace UDS.SubModule.Plan
{
    public partial class PlanSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSearch_Click(null, null);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            string username = Server.UrlDecode(Request.Cookies["UserName"].Value); 

            UDS.Components.Staff staff = new UDS.Components.Staff();
            dr = staff.FindPlan(this.ddlPlanObjectType.SelectedValue,this.ddlPlanPeriodType.SelectedValue,this.txtContent.Text, username);

            DataTable dt = UDS.Components.Tools.ConvertDataReaderToDataTable(dr);
            
             //this.dgPlanList.DataSource = dt.DefaultView;
             //dgPlanList.DataBind();

             this.lbxPlan.DataSource = dt.DefaultView;
             lbxPlan.DataTextField = "planname";
             lbxPlan.DataValueField = "id";
             lbxPlan.DataBind();
        }

        protected void lbxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveRecord.Model.Plan plan = new ActiveRecord.Model.Plan();
            plan = ActiveRecord.Model.Plan.Find(int.Parse(this.lbxPlan.SelectedValue));
            //this.past_plan_content.InnerHtml = plan.PlanConclusion;
            this.current_plan_content.InnerHtml = plan.PlanContent;

            int pastperiod = 1;
            int pastyear = int.Parse(plan.PlanYear);

            if (plan.PlanPeriod == "1")
            {
                pastyear = int.Parse(plan.PlanYear) - 1;

                if (plan.PlanPeriodType == "年计划")
                {
                    pastperiod = 12;
                }
                else if (plan.PlanPeriodType == "季计划")
                {
                    pastperiod = 4;
                }
                else if (plan.PlanPeriodType == "月计划")
                {
                    pastperiod = 12;
                }
                else if (plan.PlanPeriodType == "周计划")
                {
                    DateTime end = new DateTime(pastyear, 12, 31);  //该年最后一天  

                    System.Globalization.GregorianCalendar gc = new GregorianCalendar();

                    pastperiod = gc.GetWeekOfYear(end, CalendarWeekRule.FirstDay, DayOfWeek.Monday);  //该年星期数 
                     
                }

            }

            

            ActiveRecord.Model.Plan conclusion = plan.Find(plan.PlanObjectType, plan.PlanPeriodType, pastyear.ToString(), pastperiod.ToString(),plan.PlanCreator);
            if (conclusion != null)
            {
                this.past_plan_content.InnerHtml = conclusion.PlanConclusion;
            }

        }
    }
}
