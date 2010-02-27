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
using BLL;
using System.Text;

namespace UDS.SubModule.Vehicle
{
	/// <summary>
    /// ApplyVehicle 的摘要说明。
	/// </summary>
    public class ApplyVehicle : System.Web.UI.Page
	{
		public	static string  PositionID;	
		public	int ReturnPage=0;
		protected static string Username;

        #region 定义
        protected System.Web.UI.WebControls.Button cmdSubmit;
        protected System.Web.UI.WebControls.TextBox txtDepartment;
        protected System.Web.UI.WebControls.TextBox txtUsePeople;
        protected System.Web.UI.WebControls.TextBox txtTelephone;
        protected System.Web.UI.WebControls.TextBox txtTask;
        protected System.Web.UI.WebControls.TextBox txtUseTime;
        protected System.Web.UI.WebControls.TextBox txtTimes;
        protected System.Web.UI.WebControls.TextBox txtPeopleNum;
        //protected System.Web.UI.WebControls.TextBox txtApplyCar;
        protected System.Web.UI.WebControls.DropDownList ddlApplyCar;
        protected System.Web.UI.WebControls.RadioButtonList rbtnlNature;
        protected System.Web.UI.WebControls.DropDownList ddlHour;
        protected System.Web.UI.WebControls.DropDownList ddlMinute;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divZhanyong;
        protected System.Web.UI.HtmlControls.HtmlGenericControl spanRq;
        #endregion

        private void Page_Load(object sender, System.EventArgs e)
		{
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ApplyVehicle));

			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                DdlBindData();

                this.spanRq.InnerHtml = System.DateTime.Now.Date.ToString("yyyy-MM-dd");

                //"2010-02-05"
			}
            this.divZhanyong.InnerHtml = GetCarInfo(System.DateTime.Now.Date.ToString("yyyy-MM-dd"));

			if(Request.QueryString["ReturnPage"]!=null)
			{
				ReturnPage = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
			}
			else
				ReturnPage = 0;

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
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
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        private void DdlBindData()
        {
            object[] obj = new object[] { };
            DataTable dt = VehicleObject.GetAllCar(obj);
            this.ddlApplyCar.DataSource = dt;
            this.ddlApplyCar.DataTextField = "carname";
            this.ddlApplyCar.DataValueField = "ID";
            this.ddlApplyCar.DataBind();
        }

		private void cmdSubmit_Click(object sender, System.EventArgs e)
        {

            string strDepartment = this.txtDepartment.Text;//this.ddlMeetingType.SelectedValue;
            string strUsePeople = this.txtUsePeople.Text;
            string strTelephone = this.txtTelephone.Text;
            string strTask = this.txtTask.Text;

            this.txtUseTime.Text = Request.Form["txtUseTime"].ToString();

            string strUseTime = this.txtUseTime.Text.Trim() + " " + this.ddlHour.SelectedValue + ":" + this.ddlMinute.SelectedValue;


            string strTimes = this.txtTimes.Text;
            string strPeopleNum = this.txtPeopleNum.Text;
            string strNature = this.rbtnlNature.SelectedValue;
            string strApplyCar = this.ddlApplyCar.SelectedValue;//this.txtApplyCar.Text;

            //获取登录用户ID
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);

            //if (Request.QueryString["ID"] != null)
            //{
            //    string strID = Request.QueryString["ID"].ToString();
            //    object[] Params = new object[] { null, strID, strContents };

            //    string strReturn = NoteObject.UpdateNote(Params);

            //    if (strReturn == "0")
            //    {
            //        Page.RegisterStartupScript("", "<script>alert('修改失败！');</script>");
            //    }
            //    else
            //    {
            //        Page.RegisterStartupScript("", "<script>alert('修改成功！');</script>");
            //    }
            //}
            //else
            //{
            object[] Params = new object[] { null, strDepartment, strUsePeople, strTelephone, strTask, strUseTime, strTimes, Convert.ToInt32(strPeopleNum), strNature, strApplyCar, strUserid };

                string strReturn = VehicleObject.InsertVehicle(Params);

                if (strReturn == "0")
                {
                    Page.RegisterStartupScript("", "<script>alert('申请失败！');</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('申请成功！');</script>");
                }
            //}
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetCarInfo(string strDate)
        {
            object[] paramsValue = new object[] { strDate };

            DataTable dt = VehicleObject.GetVehicleByDate(paramsValue);

            StringBuilder strbTable = new StringBuilder();
            strbTable.Append("<table  class=\"gbtext\" style=\"border-collapse: collapse\" bordercolor=\"#93bee2\" cellspacing=0 cellpadding=0 width=100% border=1>");
            strbTable.Append("<tr align=center>");
            //strbTable.Append("<td></td><td align=center>00:00-07:59</td><td colspan=2>08</td><td colspan=2>09</td><td colspan=2>10</td><td colspan=2>11</td><td colspan=2>12</td>");
            //strbTable.Append("<td colspan=2>13</td><td colspan=2>14</td><td colspan=2>15</td><td colspan=2>16</td><td colspan=2>17</td><td colspan=2>18</td><td colspan=2>19</td><td colspan=2>20</td><td colspan=2>21</td><td>22:00-23:59</td>");

            strbTable.Append("<td width=13%></td><td align=center width=11%>00:00-07:59</td><td align=center width=65%>08:00-21:59</td><td align=center width=11%>22:00-23:59</td>");
          
            strbTable.Append("</tr>");

            DataTable dtCar = VehicleObject.GetAllCar(new object[] { });

            DataRow[] drs = null;
            for (int i = 0; i < dtCar.Rows.Count; i++)
            {
                strbTable.Append("<tr>");
                strbTable.Append("<td height=16>");
                strbTable.Append(dtCar.Rows[i]["carname"].ToString());
                strbTable.Append("</td>");

                strbTable.Append("<td></td>");

                drs = dt.Select(string.Format("ApplyCar=" + dtCar.Rows[i]["ID"].ToString()));

                if (drs.Length > 0)
                {
                    string strZyTable = "<table width=100% height=15 cellspacing=0  border=0 ><tr>";

                    for (int j = 0; j < drs.Length; j++)
                    {
                        string strUseTime = drs[j]["UseTime"].ToString();
                        string strTimes = drs[j]["Times"].ToString();

                        DateTime BeginTime = Convert.ToDateTime(strUseTime);
                        DateTime EndTime = BeginTime.AddHours(Convert.ToDouble(strTimes));

                        TimeSpan ts;
                        if (j == 0)
                        {
                            ts = BeginTime.Subtract(Convert.ToDateTime(strDate + " 08:00:00")); //兩日期的差值
                        }
                        else
                        {
                            string strOldUseTime = drs[j-1]["UseTime"].ToString();
                            string strOldTimes = drs[j - 1]["Times"].ToString();
                            DateTime OldBeginTime = Convert.ToDateTime(strOldUseTime);
                            DateTime OldEndTime = OldBeginTime.AddHours(Convert.ToDouble(strOldTimes));

                            ts = BeginTime.Subtract(OldEndTime); //兩日期的差值
                        }
                        TimeSpan ts1 = EndTime.Subtract(BeginTime);
                        int mspace = (int)ts.TotalMinutes; //獲取兩日期的間隔总分钟数
                        int mspace1 = (int)ts1.TotalMinutes;
                        strZyTable += "<td width=" + Convert.ToString((mspace * 100) / 840) + "%" + "></td>";

                        if (mspace1 < 60)
                        {
                            strZyTable += "<td width=" + Convert.ToString((mspace1 * 100) / 840) + "%" + " bgcolor=red style=\"font-size:6pt;\"></td>";
                        }
                        else if (mspace1 >= 60 && mspace1 < 95)
                        {
                            strZyTable += "<td width=" + Convert.ToString((mspace1 * 100) / 840) + "%" + " bgcolor=red style=\"font-size:6pt;\">" + BeginTime.ToShortTimeString() + "-" + EndTime.ToShortTimeString() + "</td>";
                        }
                        else
                        {
                            strZyTable += "<td width=" + Convert.ToString((mspace1 * 100) / 840) + "%" + " bgcolor=red style=\"font-size:8pt;\">" + BeginTime.ToShortTimeString() + "-" + EndTime.ToShortTimeString() + "</td>";
                        }
                    }

                    strZyTable += "<td></td>";
                    strZyTable += "</tr></table>";
                    strbTable.Append("<td>");
                    strbTable.Append(strZyTable);
                    strbTable.Append("</td>");
                }
                else
                {
                    strbTable.Append("<td>");
                    strbTable.Append("<table width=100%><tr><td></td></tr></table>");
                    strbTable.Append("</td>");
                }
                strbTable.Append("<td></td>");

                strbTable.Append("</tr>");
            }
                
               
                strbTable.Append("</table>");
            return strbTable.ToString();
        }

	}
}
