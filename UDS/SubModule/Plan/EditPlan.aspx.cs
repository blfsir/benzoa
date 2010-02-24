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
            conclusion.PlanYear = this.lblPastPlanYear.Text;
            conclusion.PlanPeriod = this.lblPastPlanPeriod.Text;// (int.Parse(lblCurrentPlanPeroid.Text) - 1).ToString();

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
            DateTime beginDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            DateTime pastDate = DateTime.Now;
            ActiveRecord.Model.Plan plan = null;

            int currentYear = DateTime.Now.Year;//当前年份
            int pastYear = currentYear - 1;//上一年份
            int nextYear = currentYear + 1;//下一年份

            switch (planPeroidType)
            {
                case "周计划":
                    DisableDropdownList();
                    this.ddlWeek.Visible = true;
                    GregorianCalendar gc = new GregorianCalendar();

                    int weekOfYear=gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                    int nextWeek = gc.GetWeekOfYear(DateTime.Now.AddDays(7), CalendarWeekRule.FirstDay, DayOfWeek.Monday); //weekOfYear + 1;
                    int pastWeek = gc.GetWeekOfYear(DateTime.Now.AddDays(-7), CalendarWeekRule.FirstDay, DayOfWeek.Monday); 
                    pastYear = DateTime.Now.AddDays(-7).Year;

                    this.ddlWeek.Items.Clear();
                    this.ddlWeek.Items.Add(new ListItem(weekOfYear.ToString(), weekOfYear.ToString()));
                    if (weekOfYear<nextWeek)
                    {
                        this.ddlWeek.Items.Add(new ListItem(nextWeek.ToString(), nextWeek.ToString()));
                    }
                    this.lblTime.Text = "周";


                    this.lblPastPlanYear.Text = pastYear.ToString();
                    lblPastPlanPeriod.Text = pastWeek.ToString();
                    this.lblPastPlanPeroidType.Text = "周";


                    this.lblCurrentPlanYear.Text = currentYear.ToString();
                    this.lblCurrentPlanPeroid.Text = weekOfYear.ToString();
                    this.lblCurrentPlanPeroidType.Text = "周";

                    this.lblConclusion.Text = pastYear.ToString() + "年" + pastWeek.ToString() + "周总结";

                    plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblCurrentPlanYear.Text, lblCurrentPlanPeroid.Text, Server.UrlDecode(Request.Cookies["UserName"].Value));
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
                        this.past_plan_content.InnerHtml = "";
                    }


                    break;
                case "月计划":
                    DisableDropdownList();
                    this.ddlMonth.Visible = true;
                   beginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    endDate = new DateTime(beginDate.AddMonths(1).Year, beginDate.AddMonths(1).Month, 1);

                     pastDate = new DateTime(beginDate.AddDays(-1).Year, beginDate.AddDays(-1).Month, 1);


                    this.lblTime.Text = "月" + "[" + beginDate.ToShortDateString() + " - " + endDate.AddDays(-1).ToShortDateString() + "]";
                    this.ddlMonth.Items.Clear();
                    this.ddlMonth.Items.Add(new ListItem(DateTime.Now.Month.ToString(), DateTime.Now.Month.ToString()));
                    if (DateTime.Now.Month.ToString() != "12")
                    {
                        this.ddlMonth.Items.Add(new ListItem(DateTime.Now.AddMonths(1).Month.ToString(), DateTime.Now.AddMonths(1).Month.ToString()));
                    }

                    this.lblPastPlanYear.Text = pastDate.Year.ToString();
                    lblPastPlanPeriod.Text = pastDate.Month.ToString();
                    this.lblPastPlanPeroidType.Text = "月";

               
                    this.lblCurrentPlanYear.Text = beginDate.Year.ToString();
                    this.lblCurrentPlanPeroid.Text = beginDate.Month.ToString();
                    this.lblCurrentPlanPeroidType.Text = "月";
                  
                    this.lblConclusion.Text = pastDate.Year.ToString() + "年" + pastDate.Month.ToString() + "月总结";

                     plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblCurrentPlanYear.Text, lblCurrentPlanPeroid.Text, Server.UrlDecode(Request.Cookies["UserName"].Value));
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
                        this.past_plan_content.InnerHtml = "";
                    }
                    break;

                case "季计划":
                    DisableDropdownList();
                    this.ddlSeason.Visible = true;
                    //当前季度
                    int currentSeason = GetSeason(currentYear, DateTime.Now);
                    int nextSeason = currentSeason + 1;
                    //季度日期区间
                    this.lblTime.Text = "季" +  GetSeasonPeriod(currentSeason)  ;
                    //上季度
                    pastYear = DateTime.Now.AddMonths(-3).Year;
                    int pastSeason = GetSeason(currentYear, DateTime.Now.AddMonths(-3));
                
                    //下季度


                    this.ddlSeason.Items.Clear();
                    this.ddlSeason.Items.Add(new ListItem (currentSeason.ToString(), currentSeason.ToString()));
                    if (nextSeason < 5)
                    {
                        this.ddlSeason.Items.Add(new ListItem (nextSeason.ToString(), nextSeason.ToString()));
                    }

                    this.lblPastPlanYear.Text = pastYear.ToString();
                    lblPastPlanPeriod.Text = pastSeason.ToString();
                    //this.lblPastPlanPeriod.Visible = false;
                    this.lblPastPlanPeroidType.Text = "季度";


                    this.lblCurrentPlanYear.Text = currentYear.ToString();
                    this.lblCurrentPlanPeroid.Text = currentSeason.ToString();
                    //this.lblCurrentPlanPeroid.Visible = false;
                    this.lblCurrentPlanPeroidType.Text = "季度";

                    this.lblConclusion.Text = pastYear.ToString() + "年" + pastSeason.ToString() + "季度总结";

                    plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblCurrentPlanYear.Text, lblCurrentPlanPeroid.Text, Server.UrlDecode(Request.Cookies["UserName"].Value));
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
                        this.past_plan_content.InnerHtml = "";
                    }

                    break;

                case "年计划":
                    DisableDropdownList();
                    this.ddlYear.Visible = true;
                    this.txtYear.Visible = false;
                    this.lblYear.Visible = false;
                    beginDate = new DateTime(DateTime.Now.Year, 1, 1);
                    endDate = new DateTime(beginDate.AddYears(1).Year, 1, 1);

                      pastDate = new DateTime(beginDate.AddYears(-1).Year, 1, 1);


                    this.lblTime.Text = "年" + "[" + beginDate.ToShortDateString() + " - " + endDate.AddDays(-1).ToShortDateString() + "]";
                    this.ddlYear.Items.Clear();
                    this.ddlYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
                    this.ddlYear.Items.Add(new ListItem(DateTime.Now.AddYears(1).Year.ToString(), DateTime.Now.AddYears(1).Year.ToString()));

                    this.lblPastPlanYear.Text = pastDate.Year.ToString();
                    lblPastPlanPeriod.Text = "12";
                    this.lblPastPlanPeriod.Visible = false;
                    this.lblPastPlanPeroidType.Text = "全年";


                    this.lblCurrentPlanYear.Text = beginDate.Year.ToString();
                    this.lblCurrentPlanPeroid.Text = "12";
                    this.lblCurrentPlanPeroid.Visible = false;
                    this.lblCurrentPlanPeroidType.Text = "全年";

                    this.lblConclusion.Text = pastDate.Year.ToString() + "年全年总结";

                    plan = new ActiveRecord.Model.Plan().Find(ddlPlanObjectType.SelectedValue, ddlPlanPeriodType.SelectedValue, lblCurrentPlanYear.Text, lblCurrentPlanPeroid.Text, Server.UrlDecode(Request.Cookies["UserName"].Value));
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
                        this.past_plan_content.InnerHtml = "";
                    }

                    break;
                default:
                    break;
            }

            
            //plan.Find(planObjectType, planPeroidType);
           /// ActiveRecord.Model.Plan plan = ActiveRecord.Model.Plan.Find(planObjectType, planPeroidType);

        }

        private string GetSeasonPeriod(int currentSeason)
        {
            int year = DateTime.Now.Year;
             DateTime FirstSeasonBeginDate = new DateTime(year, 1, 1);
            DateTime SecondSeasonBeginDate = new DateTime(year, 4, 1);
            DateTime ThirdSeasonBeginDate = new DateTime(year, 7, 1);
            DateTime FourthSeasonBeginDate = new DateTime(year, 10, 1);
            DateTime FifthSeasonBeginDate = new DateTime(year + 1, 1, 1);

            string seasonPeriod = "";
            switch (currentSeason)
            {
                case 1:
                    seasonPeriod = "[" + FirstSeasonBeginDate.ToShortDateString() + " - " + SecondSeasonBeginDate.AddDays(-1).ToShortDateString() + "]"; 
                    break;
                case 2:
                    seasonPeriod = "[" + SecondSeasonBeginDate.ToShortDateString() + " - " + ThirdSeasonBeginDate.AddDays(-1).ToShortDateString() + "]"; 
                    break;
                case 3:
                    seasonPeriod = "[" + ThirdSeasonBeginDate.ToShortDateString() + " - " + FourthSeasonBeginDate.AddDays(-1).ToShortDateString() + "]"; 
                    break;
                case 4:
                    seasonPeriod = "[" + FourthSeasonBeginDate.ToShortDateString() + " - " + FifthSeasonBeginDate.AddDays(-1).ToShortDateString() + "]"; 
                    break; 
            }

            return seasonPeriod;
        }

        private int GetSeason(int year, DateTime dateTime)
        {
            
            DateTime FirstSeasonBeginDate = new DateTime(year, 1, 1);
            DateTime SecondSeasonBeginDate = new DateTime(year, 4, 1);
            DateTime ThirdSeasonBeginDate = new DateTime(year, 7, 1);
            DateTime FourthSeasonBeginDate = new DateTime(year, 10, 1);
            DateTime FifthSeasonBeginDate = new DateTime(year + 1, 1, 1);
            if (dateTime < FirstSeasonBeginDate)
            {
                return 4;
            }
            else if (dateTime < SecondSeasonBeginDate)
            {
                return 1;
            }
            else if (dateTime < ThirdSeasonBeginDate)
            {
                return 2;
            }
            else if (dateTime < FourthSeasonBeginDate)
            {
                return 3;
            }
            else if (dateTime < FifthSeasonBeginDate)
            {
                return 4;
            }
            else
            {
                return 1;
            }

          
        }

        private void DisableDropdownList()
        {
            this.ddlMonth.Visible = false;
            this.ddlHalfYear.Visible = false;
            this.ddlWeek.Visible = false;
            this.ddlYear.Visible = false;
            this.ddlSeason.Visible = false;

            this.txtYear.Visible = true;
            this.lblYear.Visible = true;

            this.lblPastPlanPeriod.Visible = true;
            this.lblCurrentPlanPeroid.Visible = true;
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
                this.past_plan_content.InnerHtml = "";
            }
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            //当前季度
            int currentSeason =int.Parse(ddlSeason.SelectedValue);
            int nextSeason = currentSeason + 1;
            //季度日期区间
            this.lblTime.Text = "季" + GetSeasonPeriod(currentSeason);
            //上季度
            int pastYear = DateTime.Now.AddMonths(-3).Year;
            int pastSeason = currentSeason-1;
            if (pastSeason <1)
            {
                pastYear = currentYear - 1;
                pastSeason = 4;
            }
            else
            {
                pastYear = currentYear;
            }
            //下季度

 
            this.lblPastPlanYear.Text = pastYear.ToString();
            lblPastPlanPeriod.Text = pastSeason.ToString();
            //this.lblPastPlanPeriod.Visible = false;
            this.lblPastPlanPeroidType.Text = "季度";


            this.lblCurrentPlanYear.Text = currentYear.ToString();
            this.lblCurrentPlanPeroid.Text = currentSeason.ToString();
            //this.lblCurrentPlanPeroid.Visible = false;
            this.lblCurrentPlanPeroidType.Text = "季度";

            this.lblConclusion.Text = pastYear.ToString() + "年" + pastSeason.ToString() + "季度总结";

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
                this.past_plan_content.InnerHtml = "";
            }

        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime beginDate = new DateTime(int.Parse(ddlYear.SelectedValue), 1, 1);
            DateTime endDate = new DateTime(beginDate.AddYears(1).Year, 1, 1);

            DateTime pastDate = new DateTime(beginDate.AddYears(-1).Year, 1, 1);


            this.lblTime.Text = "年" + "[" + beginDate.ToShortDateString() + " - " + endDate.AddDays(-1).ToShortDateString() + "]";

            this.lblPastPlanYear.Text = pastDate.Year.ToString();
            lblPastPlanPeriod.Text = "12";
            this.lblPastPlanPeriod.Visible = false;
            this.lblPastPlanPeroidType.Text = "全年";


            this.lblCurrentPlanYear.Text = beginDate.Year.ToString();
            this.lblCurrentPlanPeroid.Text = "12";
            this.lblCurrentPlanPeroid.Visible = false;
            this.lblCurrentPlanPeroidType.Text = "全年";

            this.lblConclusion.Text = pastDate.Year.ToString() + "年全年总结";

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
                this.past_plan_content.InnerHtml = "";
            }
        }

        protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            GregorianCalendar gc = new GregorianCalendar();

            int currentYear = DateTime.Now.Year;
            int weekOfYear = int.Parse(ddlWeek.SelectedValue);
            int nextWeek = weekOfYear + 1;
            int pastWeek = weekOfYear - 1;// gc.GetWeekOfYear(DateTime.Now.AddDays(-7), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int pastYear = DateTime.Now.AddDays(-7).Year;
            if (pastWeek < 1)
            {
                pastYear = currentYear - 1;
                pastWeek = gc.GetWeekOfYear(new DateTime(pastYear, 12, 31), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            }
            else
            {
                pastYear = currentYear;
            }
           
            this.lblTime.Text = "周";


            this.lblPastPlanYear.Text = pastYear.ToString();
            lblPastPlanPeriod.Text = pastWeek.ToString();
            this.lblPastPlanPeroidType.Text = "周";


            this.lblCurrentPlanYear.Text = currentYear.ToString();
            this.lblCurrentPlanPeroid.Text = weekOfYear.ToString();
            this.lblCurrentPlanPeroidType.Text = "周";

            this.lblConclusion.Text = pastYear.ToString() + "年" + pastWeek.ToString() + "周总结";

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
                this.past_plan_content.InnerHtml = "";
            }
        }

        protected void ddlPlanObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                this.past_plan_content.InnerHtml = "";
            }
        }
    }
}
