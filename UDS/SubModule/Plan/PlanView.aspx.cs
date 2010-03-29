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
using System.Globalization;

namespace UDS.SubModule.Plan
{
    public partial class PlanView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindData();
            }
        }

        private void BindData()
        {
            int planID = Request.QueryString["planID"] != null ? Int32.Parse(Request.QueryString["planID"].ToString()) : 0;
            if (planID == 0)
            {
                return;
            }
            else
            {
                this.past_plan_content.InnerHtml = "";
                this.current_plan_content.InnerHtml = "";

                ActiveRecord.Model.Plan plan = new ActiveRecord.Model.Plan();
                plan = ActiveRecord.Model.Plan.Find(planID);
                this.current_plan_content.InnerHtml = plan.PlanContent;

                int pastperiod = int.Parse(plan.PlanPeriod) - 1;
                int pastyear = int.Parse(plan.PlanYear);

                if (pastperiod < 0)
                {
                    pastyear = pastyear - 1;

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
                 
                ActiveRecord.Model.Plan conclusion = plan.Find(plan.PlanObjectType, plan.PlanPeriodType, pastyear.ToString(), pastperiod.ToString(), plan.PlanCreator);
                if (conclusion != null)
                {
                    this.past_plan_content.InnerHtml = conclusion.PlanConclusion;
                }
            
            }
        }
    }
}
