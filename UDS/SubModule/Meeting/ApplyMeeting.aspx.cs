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

namespace UDS.SubModule.Meeting
{
	/// <summary>
    /// ApplyMeeting 的摘要说明。
	/// </summary>
    public class ApplyMeeting : System.Web.UI.Page
	{
		public	static string  PositionID;	
		private static long StaffID=0;
		private static int sex=1;
		private static int EditStatus =0;
		public	int ReturnPage=0;
		protected static string Username;
        
		protected System.Web.UI.WebControls.Button cmdSubmit;
		//protected System.Web.UI.WebControls.TextBox txtMeetingType;
	    protected System.Web.UI.WebControls.TextBox txtMeetingSubject;
	    protected System.Web.UI.WebControls.TextBox txtDepartment;
	    //protected System.Web.UI.WebControls.TextBox txtMeetingRoom;
	    protected System.Web.UI.WebControls.TextBox txtBeginTime;
	    protected System.Web.UI.WebControls.TextBox txtEndTime;
	    protected System.Web.UI.WebControls.TextBox txtHost;
	    protected System.Web.UI.WebControls.TextBox txtRecorder;
	    protected System.Web.UI.WebControls.TextBox txtEnterPeople;
	    protected System.Web.UI.WebControls.TextBox txtOtherResources;
        protected System.Web.UI.WebControls.TextBox txtMeetingContents;
        protected System.Web.UI.WebControls.DropDownList ddlHour1;
        protected System.Web.UI.WebControls.DropDownList ddlMinute1;
        protected System.Web.UI.WebControls.DropDownList ddlHour2;
        protected System.Web.UI.WebControls.DropDownList ddlMinute2;
        protected System.Web.UI.WebControls.DropDownList ddlMeetingType;
        protected System.Web.UI.WebControls.DropDownList ddlMeetingRoom;
        protected System.Web.UI.HtmlControls.HtmlGenericControl divZhanyong;
        protected System.Web.UI.HtmlControls.HtmlGenericControl spanRq;

		
		private void Page_Load(object sender, System.EventArgs e)
		{
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ApplyMeeting));

			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                //if (Request.QueryString["ID"] != null)
                //{
                //    object[] paramsValue = new object[] { Request.QueryString["ID"].ToString() };
                //    DataTable dt = NoteObject.GetNoteByID(paramsValue);

                //    this.txtContents.Text = dt.Rows[0]["Contents"].ToString();
                //}

                DdlBindData();

                this.spanRq.InnerHtml = System.DateTime.Now.Date.ToString("yyyy-MM-dd");

                this.divZhanyong.InnerHtml = GetMeetingInfo(System.DateTime.Now.Date.ToString("yyyy-MM-dd"));//"2010-02-05"
			}

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
            DataTable dt = MeetingObject.GetAllMeetingType(obj);
            this.ddlMeetingType.DataSource = dt;
            this.ddlMeetingType.DataTextField = "TypeName";
            this.ddlMeetingType.DataValueField = "ID";
            this.ddlMeetingType.DataBind();

            dt = MeetingObject.GetAllMeetingRoom(obj);
            this.ddlMeetingRoom.DataSource = dt;
            this.ddlMeetingRoom.DataTextField = "RoomName";
            this.ddlMeetingRoom.DataValueField = "ID";
            this.ddlMeetingRoom.DataBind();
        }

		private void cmdSubmit_Click(object sender, System.EventArgs e)
        {

            string strMeetingType = this.ddlMeetingType.SelectedValue;//this.txtMeetingType.Text;
            string strMeetingSubject = this.txtMeetingSubject.Text;
            string strDepartment = this.txtDepartment.Text;
            string strMeetingRoom = this.ddlMeetingRoom.SelectedValue;//this.txtMeetingRoom.Text;

            this.txtBeginTime.Text = Request.Form["txtBeginTime"].ToString();
            this.txtEndTime.Text = Request.Form["txtEndTime"].ToString();

            string strBeginTime = this.txtBeginTime.Text.Trim() + " " + this.ddlHour1.SelectedValue + ":" + this.ddlMinute1.SelectedValue;
            string strEndTime = this.txtEndTime.Text.Trim() + " " + this.ddlHour2.SelectedValue + ":" + this.ddlMinute2.SelectedValue;

            string strHost = this.txtHost.Text;
            string strRecorder = this.txtRecorder.Text;
            string strEnterPeople = this.txtEnterPeople.Text;
            string strOtherResources = this.txtOtherResources.Text;
            string strMeetingContents = this.txtMeetingContents.Text;

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
            object[] Params = new object[] { null, strMeetingType, strMeetingSubject, strDepartment, strMeetingRoom, strBeginTime, strEndTime, strHost, strRecorder, strEnterPeople, strOtherResources, strMeetingContents, strUserid };

                string strReturn = MeetingObject.InsertMeeting(Params);

                if (strReturn == "0")
                {
                    Page.RegisterStartupScript("", "<script>alert('添加失败！');</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('添加成功！');</script>");
                }
            //}
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetMeetingInfo(string strDate)
        {
            object[] paramsValue = new object[] { strDate };

            DataTable dt = MeetingObject.GetMeetingByDate(paramsValue);

            StringBuilder strbTable = new StringBuilder();
            strbTable.Append("<table  class=\"gbtext\" style=\"border-collapse: collapse\" bordercolor=\"#93bee2\" cellspacing=0 cellpadding=0 width=100% border=1>");
            strbTable.Append("<tr align=center>");
            //strbTable.Append("<td></td><td align=center>00:00-07:59</td><td colspan=2>08</td><td colspan=2>09</td><td colspan=2>10</td><td colspan=2>11</td><td colspan=2>12</td>");
            //strbTable.Append("<td colspan=2>13</td><td colspan=2>14</td><td colspan=2>15</td><td colspan=2>16</td><td colspan=2>17</td><td colspan=2>18</td><td colspan=2>19</td><td colspan=2>20</td><td colspan=2>21</td><td>22:00-23:59</td>");

            strbTable.Append("<td width=13%></td><td align=center width=11%>00:00-07:59</td><td align=center width=65%>08:00-21:59</td><td align=center width=11%>22:00-23:59</td>");
          
            strbTable.Append("</tr>");

            DataTable dtRoom = MeetingObject.GetAllMeetingRoom(new object[] { });

            DataRow[] drs = null;
            for (int i = 0; i < dtRoom.Rows.Count; i++)
            {
                strbTable.Append("<tr>");
                strbTable.Append("<td height=16>");
                strbTable.Append(dtRoom.Rows[i]["RoomName"].ToString());
                strbTable.Append("</td>");

                strbTable.Append("<td></td>");

                drs = dt.Select(string.Format("MeetingRoom=" + dtRoom.Rows[i]["ID"].ToString()));

                if (drs.Length > 0)
                {
                    string strZyTable = "<table width=100% height=15 cellspacing=0  border=0 bordercolor=red><tr>";

                    for (int j = 0; j < drs.Length; j++)
                    {
                        string strBeginTime = drs[j]["BeginTime"].ToString();
                        string strEndTime = drs[j]["EndTime"].ToString();

                        DateTime BeginTime = Convert.ToDateTime(strBeginTime);
                        DateTime EndTime = Convert.ToDateTime(strEndTime);

                        TimeSpan ts;
                        if (j == 0)
                        {
                            ts = BeginTime.Subtract(Convert.ToDateTime(strDate + " 08:00:00")); //兩日期的差值
                        }
                        else
                        {
                            ts = BeginTime.Subtract(Convert.ToDateTime(drs[j - 1]["EndTime"].ToString())); //兩日期的差值
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
                
                //
                //if (drs.Length > 0)
                //{
                //    for (int i = 0; i < drs.Length; i++)
                //    {
                //        string strBeginTime = drs[i]["BeginTime"].ToString();
                //        string strEndTime = drs[i]["EndTime"].ToString();

                //        DateTime BeginTime = Convert.ToDateTime(strBeginTime);
                //        DateTime EndTime = Convert.ToDateTime(strEndTime); 

                //        TimeSpan ts = EndTime.Subtract(BeginTime); //兩日期的差值

                //        //int mspace = ts.TotalMinutes; //獲取兩日期的間隔总分钟数

                //        //int intNum = mspace / 5;



                //        //int aa = intNum * 2;
                //    }
                //}
                strbTable.Append("</table>");
            return strbTable.ToString();
        }

	}
}
