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
            if (!IsPostBack)
            {
                this.txtYear.Text = DateTime.Now.Year.ToString();
                this.ddlPlanPeriodType.SelectedIndex = 1;
                ddlPlanPeriodType_SelectedIndexChanged(null, null);//调用一下不就ok了？ 
            }
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {

            //更新上月（上周期）的总结
            ActiveRecord.Model.Plan conclusion = new ActiveRecord.Model.Plan();
            conclusion.PlanObjectType = ddlPlanObjectType.SelectedValue;
            conclusion.PlanPeriodType = ddlPlanPeriodType.SelectedValue;
            conclusion.PlanConclusion  = FCKeditor2.Value;

            conclusion.PlanCreator = Server.UrlDecode(Request.Cookies["UserName"].Value); 

            conclusion.PlanCreateDate = DateTime.Now;
            conclusion.PlanYear = lblCurrentPlanYear.Text;
            conclusion.PlanPeriod = (int.Parse(lblCurrentPlanPeroid.Text)-1).ToString();

            conclusion.SaveOrUpdate();

            //创建当月（本周期）的计划
            ActiveRecord.Model.Plan plan = new ActiveRecord.Model.Plan();
            plan.PlanObjectType = ddlPlanObjectType.SelectedValue;
            plan.PlanPeriodType = ddlPlanPeriodType.SelectedValue;
            plan.PlanContent = FCKeditor3.Value;
        
            plan.PlanCreator = Server.UrlDecode(Request.Cookies["UserName"].Value); 
            plan.PlanCreateDate = DateTime.Now;
            plan.PlanYear = lblCurrentPlanYear.Text;
            plan.PlanPeriod = lblCurrentPlanPeroid.Text;

            plan.SaveOrUpdate();
            
        }

        protected void ddlPlanPeriodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planPeroidType = ddlPlanPeriodType.SelectedValue;
            string planObjectType = ddlPlanObjectType.SelectedValue;

            switch (planPeroidType)
            {
                case "月计划":
                    DisableDropdownList();
                    this.ddlMonth.Visible = true;
                    DateTime beginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime endDate = new DateTime(beginDate.AddMonths(1).Year, beginDate.AddMonths(1).Month, 1);

                    DateTime pastDate = new DateTime(beginDate.AddDays(-1).Year, beginDate.AddDays(-1).Month, 1);


                    this.lblTime.Text = "月" + "[" + beginDate.ToShortDateString() + " - " + endDate.AddDays(-1).ToShortDateString() + "]";
                    this.ddlMonth.Items.Clear();
                    this.ddlMonth.Items.Add(new ListItem(DateTime.Now.Month.ToString(), DateTime.Now.Month.ToString()));
                    this.ddlMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(1).Month.ToString(), DateTime.Now.AddMonths(1).Month.ToString()));

                    this.lblPastPlanYear.Text = pastDate.Year.ToString();
                    lblPastPlanPeriod.Text = pastDate.Month.ToString();
                    this.lblPastPlanPeroidType.Text = "月";

               
                    this.lblCurrentPlanYear.Text = beginDate.Year.ToString();
                    this.lblCurrentPlanPeroid.Text = beginDate.Month.ToString();
                    this.lblCurrentPlanPeroidType.Text = "月";
                  
                    this.lblConclusion.Text = pastDate.Year.ToString() + "年" + pastDate.Month.ToString() + "月总结";

                    ActiveRecord.Model.Plan plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblCurrentPlanYear.Text, lblCurrentPlanPeroid.Text, Server.UrlDecode(Request.Cookies["UserName"].Value));
                    if (plan != null)//本月计划
                    {
                        this.FCKeditor3.Value = plan.PlanContent;
                    }
                    else
                    {
                        this.FCKeditor3.Value = "";
                    }
                    //上月总结
                    plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblPastPlanYear.Text, int.Parse(lblPastPlanPeriod.Text).ToString(), Server.UrlDecode(Request.Cookies["UserName"].Value));
                    if (plan != null)//上月总结
                    {
                        this.FCKeditor2.Value = plan.PlanConclusion;
                        this.past_plan_content.InnerHtml = plan.PlanContent;//上月计划
                    }
                    else
                    {
                        this.FCKeditor2.Value = "";
                    }
                    break;
                default:
                    break;
            }

            
            //plan.Find(planObjectType, planPeroidType);
           /// ActiveRecord.Model.Plan plan = ActiveRecord.Model.Plan.Find(planObjectType, planPeroidType);

        }

        private void DisableDropdownList()
        {
            this.ddlMonth.Visible = false;
            this.ddlHalfYear.Visible = false;
            this.ddlWeek.Visible = false;
            this.ddlYear.Visible = false;
            this.ddlSeason.Visible = false;
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime beginDate = new DateTime(DateTime.Now.Year, int.Parse(ddlMonth.SelectedValue), 1);
            DateTime endDate = new DateTime(beginDate.AddMonths(1).Year, beginDate.AddMonths(1).Month, 1);
            DateTime pastDate = new DateTime(beginDate.AddDays(-1).Year, beginDate.AddDays(-1).Month, 1);

            this.lblTime.Text = "月" + "[" + beginDate.ToShortDateString() + " - " + endDate.AddDays(-1).ToShortDateString() + "]";
            this.lblPastPlanYear.Text = pastDate.Year.ToString();
            lblPastPlanPeriod.Text = pastDate.Month.ToString();
            this.lblPastPlanPeroidType.Text = "月";

            this.lblCurrentPlanYear.Text = beginDate.Year.ToString();
            this.lblCurrentPlanPeroid.Text = beginDate.Month.ToString();
            this.lblCurrentPlanPeroidType.Text = "月";
            //this.lblPastPlan.Text = pastDate.Year.ToString() + "年" + pastDate.Month.ToString() + "月计划";
            this.lblConclusion.Text = pastDate.Year.ToString() + "年" + pastDate.Month.ToString() + "月总结";
            //this.lblCurrentPlan.Text = beginDate.Year.ToString() + "年" + beginDate.Month.ToString() + "月计划";


            ActiveRecord.Model.Plan plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblCurrentPlanYear.Text, lblCurrentPlanPeroid.Text, Server.UrlDecode(Request.Cookies["UserName"].Value));
            if (plan != null)//本月计划
            {
                this.FCKeditor3.Value = plan.PlanContent;
            }
            else
            {
                this.FCKeditor3.Value = "";
            }
            //上月总结
            plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblPastPlanYear.Text, int.Parse(lblPastPlanPeriod.Text).ToString(), Server.UrlDecode(Request.Cookies["UserName"].Value));
            if (plan != null)//上月总结
            {
                this.FCKeditor2.Value = plan.PlanConclusion;
                this.past_plan_content.InnerHtml = plan.PlanContent;//上月计划
            }
            else
            {
                this.FCKeditor2.Value = "";
            }
        }
    }
}
