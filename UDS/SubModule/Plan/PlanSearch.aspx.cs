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
            this.past_plan_content.InnerHtml = plan.PlanConclusion;
            this.current_plan_content.InnerHtml = plan.PlanContent;
        }
    }
}
