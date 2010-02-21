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
 

namespace UDS.SubModule.Plan
{
    public partial class EditPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            ActiveRecord.Model.Plan plan = new ActiveRecord.Model.Plan();
            plan.PlanObjectType = ddlPlanObjectType.SelectedValue;
            plan.PlanPeriodType = ddlPlanPeriodType.SelectedValue;
            plan.PlanContent = FCKeditor2.Value;
            plan.PlanConclusion = FCKeditor3.Value;
            plan.PlanCreateDate = DateTime.Now;

            plan.Save(); 
            
        }

        protected void ddlPlanPeriodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planPeroidType = ddlPlanPeriodType.SelectedValue;
            string planObjectType = ddlPlanObjectType.SelectedValue;

            switch (planPeroidType)
            {
                case "月计划":
                    this.lblTime.Text = "月计划" + DateTime.Now.Month.ToString();
                    break;
                default:
                    break;
            }

            ActiveRecord.Model.Plan plan = new ActiveRecord.Model.Plan();
            plan.Find(planObjectType, planPeroidType);
           /// ActiveRecord.Model.Plan plan = ActiveRecord.Model.Plan.Find(planObjectType, planPeroidType);

        }
    }
}
