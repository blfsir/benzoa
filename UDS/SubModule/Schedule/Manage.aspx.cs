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
using System.Text.RegularExpressions;

namespace UDS.SubModule.Schedule
{
    /// <summary>
    /// Manage 的摘要说明。
    /// </summary>
    public class Manage : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.DropDownList listEndTime;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.ListBox listCooperator;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.CheckBox cbIsAllDay;
        protected System.Web.UI.WebControls.CheckBox cbNeedCo;
        protected static string Username, CurrDate, CurrTime;
        public static string UnameStr;
        protected System.Web.UI.WebControls.TextBox txtBeginDate;
        protected System.Web.UI.WebControls.TextBox txtEndDate;
        protected System.Web.UI.WebControls.RadioButtonList rbAttribute;
        protected System.Web.UI.WebControls.DropDownList listAheadMin;
        protected System.Web.UI.WebControls.Label Label14;
        protected System.Web.UI.WebControls.TextBox txtSubject;
        protected System.Web.UI.WebControls.Button btnSubmit;
        protected System.Web.UI.WebControls.Label lblMsg;
        public string ClassID;
        protected System.Web.UI.WebControls.CheckBox cbIsRepeat;
        private static int startTimeNo = 8;
        protected System.Web.UI.WebControls.Button btnCheck;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.TextBox txtDetail;
        protected System.Web.UI.WebControls.Label lblType;
        protected System.Web.UI.WebControls.RadioButtonList rbType;
        protected System.Web.UI.WebControls.Label lblArrangedBy;
        protected System.Web.UI.WebControls.Button btnAddUser;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.DropDownList listBeginTime;
        protected System.Web.UI.WebControls.CheckBox cbRemind;
        protected HtmlGenericControl DayTaskFrm;


        private void Page_Load(object sender, System.EventArgs e)
        {
            ClassID = (Request.QueryString["ClassID"] != null) ? Request.QueryString["ClassID"].ToString() : "0";
            CurrDate = (Request.QueryString["CurrDate"] != null) ? Request.QueryString["CurrDate"].ToString() : DateTime.Now.ToShortDateString();
            CurrTime = (Request.QueryString["CurrTime"] != null) ? Request.QueryString["CurrTime"].ToString() : "10";

            if (!Page.IsPostBack)
            {
                HttpCookie UserCookie = Request.Cookies["Username"];
                Username = UserCookie.Value.ToString();
                PopulateListView();
                UnameStr = Username;
                DayTaskFrm.Attributes["src"] = "ViewDayTask.aspx?Date=" + CurrDate + "&UnameStr=" + UnameStr;
            }
            else
            {
                lblMsg.Text = "";
                DayTaskFrm.Attributes["src"] = "ViewDayTask.aspx?Date=" + this.txtBeginDate.Text + "&UnameStr=" + UnameStr;
            }

            Validate();
        }

        #region 初始化下拉列表框
        /// <summary>
        /// 对下拉列表进行初始化
        /// </summary>
        private void PopulateListView()
        {

            #region 开始时间与结束时间初始化
            Task task = new Task();
            SqlDataReader dataReader = null;
            dataReader = task.GetPeriodInfo();
            ArrayList a = new ArrayList();
            while (dataReader.Read())
            {
                string[] b = dataReader[1].ToString().Split('-');
                listBeginTime.Items.Add(new ListItem(b[0], dataReader[0].ToString()));
                listEndTime.Items.Add(new ListItem(b[0], dataReader[0].ToString()));
            }
            dataReader.Close();
            a = null;

            listBeginTime.SelectedIndex = Int32.Parse(CurrTime) - startTimeNo;
            listEndTime.SelectedIndex = listBeginTime.SelectedIndex + 1;

            //			listBeginTime.DataTextField = "period";
            //			listBeginTime.DataValueField = "id";
            //			listBeginTime.DataSource = dataReader;
            //			listBeginTime.DataBind();
            //			for(int j=startTimeNo;j<19;j++)
            //			{
            //				ListItem li = new ListItem(j.ToString()+":00",j.ToString());
            //				listBeginTime.Items.Insert(j-8,li);
            //				listEndTime.Items.Insert(j-8,li);
            //			}

            txtBeginDate.Text = DateTime.Parse(CurrDate).ToString("yyyy-MM-dd");
            //			listBeginTime.SelectedIndex   = Int32.Parse(CurrTime)-startTimeNo;
            txtEndDate.Text = DateTime.Parse(CurrDate).ToString("yyyy-MM-dd");
            #endregion

            #region 任务属性初始化
            rbAttribute.Items.Add(new ListItem("独占任务", "1"));
            rbAttribute.Items.Add(new ListItem("限时任务", "0"));
            rbAttribute.Items[0].Selected = true;
            #endregion

            #region 任务类型初始化
            rbType.Items.Add(new ListItem("会议", "1"));
            rbType.Items.Add(new ListItem("文案", "2"));
            rbType.Items.Add(new ListItem("来访", "3"));
            rbType.Items.Add(new ListItem("电话", "4"));
            rbType.Items.Add(new ListItem("走访", "5"));
            rbType.Items.Add(new ListItem("外出", "6"));
            rbType.Items.Add(new ListItem("假期", "7"));
            rbType.Items.Add(new ListItem("出差", "8"));
            rbType.Items[0].Selected = true;
            #endregion

            #region 协同人员列表初始化
            UDS.Components.Staff staff = new UDS.Components.Staff();
            try
            {
                listCooperator.DataTextField = "RealName";
                listCooperator.DataValueField = "Staff_Name";
                listCooperator.DataSource = staff.GetAllStaffs();
                listCooperator.DataBind();

            }
            catch (Exception e)
            {
                UDS.Components.Error.Log(e.ToString());
                Server.Transfer("../Error.aspx");
            }
            finally
            {
                staff = null;
            }
            #endregion

            lblArrangedBy.Text = UDS.Components.Staff.GetRealNameByUsername(Username);

        }
        #endregion

        private TaskClass ProcessFormPost()
        {
            TaskClass tc = new TaskClass();
            tc.ArrangedBy = Username;
            tc.Detail = this.txtDetail.Text.ToString();
            tc.Type = Int32.Parse(this.rbType.SelectedItem.Value.ToString());
            tc.Attribute = Int32.Parse(this.rbAttribute.SelectedItem.Value.ToString());
            tc.Subject = this.txtSubject.Text.ToString();
            tc.ProjectID = Request.Form["hdnProjectID"].ToString() != "" ? Int32.Parse(Request.Form["hdnProjectID"].ToString()) : 0;
            tc.StartTime = this.txtBeginDate.Text.ToString() + " " + ((this.cbIsAllDay.Checked) ? "" : this.listBeginTime.SelectedItem.Text.ToString());
            tc.EndTime = this.txtEndDate.Text.ToString() + " " + ((this.cbIsAllDay.Checked) ? "" : this.listEndTime.SelectedItem.Text.ToString());
            tc.AwakeTime = DateTime.Parse(tc.EndTime).AddMinutes(-10).ToString();
            tc.Tag = 0;
            tc.ContractList = "";
            tc.CooperatorList = UnameStr;
            //			foreach(ListItem i in this.listCooperator .Items)
            //				if(i.Selected == true)
            //					tc.CooperatorList+= i.Value.ToString()+",";

            return tc;
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
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            this.rbAttribute.SelectedIndexChanged += new System.EventHandler(this.rbAttribute_SelectedIndexChanged);
            this.cbIsAllDay.CheckedChanged += new System.EventHandler(this.cbIsAllDay_CheckedChanged);
            this.cbNeedCo.CheckedChanged += new System.EventHandler(this.cbNeedCo_CheckedChanged);
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void cbNeedCo_CheckedChanged(object sender, System.EventArgs e)
        {
            this.listCooperator.Visible = !this.listCooperator.Visible;
            this.btnAddUser.Visible = this.listCooperator.Visible;
            this.cbRemind.Visible = this.listCooperator.Visible;
            this.ValidateForm();
        }

        private void cbIsAllDay_CheckedChanged(object sender, System.EventArgs e)
        {
            this.listBeginTime.Visible = !this.listBeginTime.Visible;
            this.listEndTime.Visible = !this.listEndTime.Visible;
            this.cbIsRepeat.Visible = !this.cbIsRepeat.Visible;
        }



        private ArrayList CheckExist()
        {
            ArrayList cooperatorList = new ArrayList();
            ArrayList ExistList = new ArrayList();
            Task task = new Task();

            if (this.cbNeedCo.Checked)
            {
                if (this.cbNeedCo.Checked)
                {
                    string[] UnameArr = System.Text.RegularExpressions.Regex.Split(UnameStr, ",");
                    for (int uc = 0; uc < UnameArr.Length; uc++)
                        cooperatorList.Add(UnameArr[uc].ToString());
                }
                else
                {
                    cooperatorList.Add(Username);
                }
            }
            else
            {
                cooperatorList.Add(Username);
            }

            foreach (string s in cooperatorList)
            {
                // 一天任务
                #region 如果是单天的任务
                if (this.txtBeginDate.Text.ToString() == this.txtEndDate.Text.ToString())
                {
                    // 全天任务
                    if (this.cbIsAllDay.Checked)
                    {
                        SqlDataReader dataReader = task.GetPeriodInfo();
                        while (dataReader.Read())
                        {
                            if (task.CheckExist(Int32.Parse(dataReader[0].ToString()), s, this.txtBeginDate.Text.ToString()))
                            {
                                TaskConflictRecord conrec = new TaskConflictRecord();
                                conrec.Username = s;
                                conrec.Date = this.txtBeginDate.Text.ToString();
                                conrec.Period = dataReader[0].ToString();
                                ExistList.Add(conrec);
                                conrec = null;
                            }
                        }
                        dataReader.Close();
                    }
                    else
                    {
                        for (int t = Int32.Parse(this.listBeginTime.SelectedItem.Value.ToString()); t < Int32.Parse(this.listEndTime.SelectedItem.Value.ToString()); t++)
                            if (task.CheckExist(t, s, this.txtBeginDate.Text.ToString()))
                            {
                                TaskConflictRecord conrec = new TaskConflictRecord();
                                conrec.Username = s;
                                conrec.Date = this.txtBeginDate.Text.ToString();
                                conrec.Period = t.ToString();
                                ExistList.Add(conrec);
                                conrec = null;
                            }

                    }

                }
                #endregion

                // 如果是多天的任务
                #region 如果是多天的任务
                if (DateTime.Parse(this.txtBeginDate.Text.ToString()) < DateTime.Parse(this.txtEndDate.Text.ToString()))
                {
                    TimeSpan ts = new TimeSpan();
                    ts = DateTime.Parse(this.txtEndDate.Text.ToString()) - DateTime.Parse(this.txtBeginDate.Text.ToString());
                    for (int t = 0; t < Int32.Parse(ts.Days.ToString()) + 1; t++) //根据天数循环添加
                    {
                        string tmpDate = DateTime.Parse(this.txtBeginDate.Text.ToString()).AddDays(t).ToString("yyyy-MM-dd");

                        #region 如果是全天任务
                        if (this.cbIsAllDay.Checked) //如果是全天任务
                        {
                            SqlDataReader dataReader = task.GetPeriodInfo();
                            while (dataReader.Read())
                            {
                                if (task.CheckExist(Int32.Parse(dataReader[0].ToString()), s, tmpDate))
                                {
                                    TaskConflictRecord conrec = new TaskConflictRecord();
                                    conrec.Username = s;
                                    conrec.Date = tmpDate;
                                    conrec.Period = dataReader[0].ToString();
                                    ExistList.Add(conrec);
                                    conrec = null;
                                }
                            }
                            dataReader.Close();
                        }
                        #endregion

                        #region  如果是时段任务
                        else //如果是时段任务
                        {
                            if (this.cbIsRepeat.Checked) // 如果是时段重复
                            {
                                for (int j = Int32.Parse(this.listBeginTime.SelectedItem.Value.ToString()); j < Int32.Parse(this.listEndTime.SelectedItem.Value.ToString()); j++)
                                    if (task.CheckExist(j, s, tmpDate))
                                    {
                                        TaskConflictRecord conrec = new TaskConflictRecord();
                                        conrec.Username = s;
                                        conrec.Date = tmpDate;
                                        conrec.Period = j.ToString();
                                        ExistList.Add(conrec);
                                        conrec = null;
                                    }
                            }
                            else   // 如果是全部时段
                            {
                                if (tmpDate == this.txtBeginDate.Text.ToString())// 如果是开始天
                                {

                                    for (int k = Int32.Parse(this.listBeginTime.SelectedItem.Value.ToString()); k < 20; k++)
                                        if (task.CheckExist(k, s, tmpDate))
                                        {
                                            TaskConflictRecord conrec = new TaskConflictRecord();
                                            conrec.Username = s;
                                            conrec.Date = tmpDate;
                                            conrec.Period = (k).ToString();
                                            ExistList.Add(conrec);
                                            conrec = null;
                                        }
                                }
                                else if (tmpDate == this.txtEndDate.Text.ToString())
                                {
                                    for (int k = 1; k < Int32.Parse(this.listEndTime.SelectedItem.Value.ToString()); k++)
                                        if (task.CheckExist(k, s, tmpDate))
                                        {
                                            TaskConflictRecord conrec = new TaskConflictRecord();
                                            conrec.Username = s;
                                            conrec.Date = tmpDate;
                                            conrec.Period = k.ToString();
                                            ExistList.Add(conrec);
                                            conrec = null;
                                        }
                                }
                                else
                                {
                                    SqlDataReader dataReader = task.GetPeriodInfo();
                                    while (dataReader.Read())
                                    {
                                        if (task.CheckExist(Int32.Parse(dataReader[0].ToString()), s, tmpDate))
                                        {
                                            TaskConflictRecord conrec = new TaskConflictRecord();
                                            conrec.Username = s;
                                            conrec.Date = tmpDate;
                                            conrec.Period = dataReader[0].ToString();
                                            ExistList.Add(conrec);
                                            conrec = null;
                                        }

                                    }
                                    dataReader.Close();

                                }
                            }
                        }
                        #endregion
                    }



                }
                #endregion
            }

            return ExistList;
        }

        private bool ValidateForm()
        {

            if (UnameStr == "")
            {
                this.lblMsg.Text = "请至少选择一个执行人";
                return false;
            }

            if (this.txtSubject.Text == "")
            {
                this.lblMsg.Text = "主题不能为空";
                return false;
            }


            if (DateTime.Parse(this.txtBeginDate.Text.ToString()) > DateTime.Parse(this.txtEndDate.Text.ToString()))
            {
                this.lblMsg.Text = "开始日期不能大于结束日期";
                return false;
            }

            if (!this.cbIsAllDay.Checked)
            {

                if (this.txtBeginDate.Text.ToString() == this.txtEndDate.Text.ToString() && this.listBeginTime.SelectedItem.Value.ToString() == this.listEndTime.SelectedItem.Value.ToString())
                {
                    this.lblMsg.Text = "开始时间段和结束时间段不能相同";
                    return false;
                }

                if (this.txtBeginDate.Text.ToString() == this.txtEndDate.Text.ToString() && Int32.Parse(this.listBeginTime.SelectedItem.Value.ToString()) >= Int32.Parse(this.listEndTime.SelectedItem.Value.ToString()))
                {
                    this.lblMsg.Text = "开始时间段不能大于等于结束时段";
                    return false;
                }
            }
            if (this.cbNeedCo.Checked == true)
            {
                bool flag = true;
                foreach (ListItem i in this.listCooperator.Items)
                    if (i.Selected == true) flag = false;

                if (flag)
                {
                    this.lblMsg.Text = "请选择协同人";
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;

        }

        public string GetClassName()
        {
            if (ClassID == "0")
                return "请选择项目";
            else
                return UDS.Components.ProjectClass.GetProjectName(Int32.Parse(ClassID));

        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string info = "<link href=\"../../Css/BasicLayout.css\" rel=\"stylesheet\" type=\"text/css\">";
            info += "<body leftmargin=\"0\" topmargin=\"0\">";
            HttpCookie UserCookie = Request.Cookies["Username"];
            string Username = UserCookie.Value.ToString();
            if (ValidateForm())
            {
                if (this.rbAttribute.SelectedItem.Value.ToString() == "1")
                {
                    ArrayList ExistList = CheckExist();
                    if (ExistList.Count > 0)
                    {
                        info += "<table width=100% height=30 border=0 cellpadding=0 cellspacing=0 class=GbText>";
                        info += "<tr>";
                        info += "<td background=\"../../Images/treetopbg.jpg\">&nbsp;&nbsp;任务时段冲突检测结果</td>";
                        info += "</tr>";
                        info += "</table>";

                        info += "<table width=100% border=1 cellpadding=0 cellspacing=0 style=BORDER-COLLAPSE: collapse borderColor=93BEE2 class=GbText>";
                        info += " <tr align=center bgcolor=#e8f4ff> ";
                        info += "<td width=30% height=24>检测人员</td>";
                        info += "<td width=30% height=24>日期</td>";
                        info += "<td height=24>时间</td>";
                        info += "</tr>";
                        foreach (TaskConflictRecord conrec in ExistList)
                        {
                            int b = Int32.Parse(conrec.Period);
                            DateTime dt = new DateTime(1999, 1, 1, 8, 0, 0, 0);
                            TimeSpan ts = new TimeSpan(0, 0, (b - 1) * 30, 0, 0);
                            DateTime bt = dt.Add(ts);
                            DateTime et = bt.Add(new TimeSpan(0, 0, 30, 0, 0));

                            info += "<tr align=center><td height=20>" + conrec.Username + "</td>";
                            info += "<td>" + conrec.Date + "</td>";
                            info += "<td>" + bt.ToShortTimeString() + "---" + et.ToShortTimeString() + "</td>";
                            info += "</tr>";

                        }
                        info += "</table>";
                        info += "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                        info += "<tr><td height=\"36\" align=\"center\"><font color=\"#FF0000\">以上时段有冲突</font></td></tr></table>";
                        Response.Write("<script language=javascript>var checkwin=window.open('','check','toolbar=no,scrollbars=yes,width=280,height=200,resizable=yes');");
                        Response.Write("checkwin.document.write('" + info + "');checkwin.moveTo(0,0);checkwin.focus();</script>");
                        return;

                    }
                }

                String TaskID = "";
                ArrayList cooperatorList = new ArrayList();
                Task task = new Task();
                TaskID = task.AddTask(ProcessFormPost());

                //处理短信提醒
                if (this.cbRemind.Checked == true)
                {
                    SMS sm = new SMS();
                    sm.SendMsg(Username, UnameStr, "您从 " + UDS.Components.Staff.GetRealNameByUsername(Username) + " 处接收到了一份新的任务", 1, DateTime.Now, "", 0, 0);
                    sm = null;
                }

                if (this.rbAttribute.SelectedItem.Value.ToString() == "1")
                {

                    if (this.cbNeedCo.Checked)
                    {
                        string[] UnameArr = System.Text.RegularExpressions.Regex.Split(UnameStr, ",");
                        for (int uc = 0; uc < UnameArr.Length; uc++)
                            cooperatorList.Add(UnameArr[uc].ToString());
                    }
                    else
                    {
                        cooperatorList.Add(Username);
                    }

                    foreach (string s in cooperatorList)
                    {
                        // 一天任务
                        #region 如果是单天的任务
                        if (this.txtBeginDate.Text.ToString() == this.txtEndDate.Text.ToString())
                        {
                            // 全天任务
                            if (this.cbIsAllDay.Checked)
                            {
                                SqlDataReader dataReader = task.GetPeriodInfo();
                                while (dataReader.Read())
                                {
                                    task.AddTaskToSchedule(Int32.Parse(TaskID), Int32.Parse(dataReader[0].ToString()), s, this.txtBeginDate.Text.ToString(), s.ToLower() == Username.ToLower() ? true : false);

                                }
                                dataReader = null;
                            }
                            else
                            {
                                for (int t = Int32.Parse(this.listBeginTime.SelectedItem.Value); t < Int32.Parse(this.listEndTime.SelectedItem.Value); t++)
                                    task.AddTaskToSchedule(Int32.Parse(TaskID), t, s, this.txtBeginDate.Text.ToString(), s.ToLower() == Username.ToLower() ? true : false);

                            }

                        }
                        #endregion

                        // 如果是多天的任务
                        #region 如果是多天的任务
                        if (DateTime.Parse(this.txtBeginDate.Text.ToString()) < DateTime.Parse(this.txtEndDate.Text.ToString()))
                        {
                            TimeSpan ts = new TimeSpan();
                            ts = DateTime.Parse(this.txtEndDate.Text.ToString()) - DateTime.Parse(this.txtBeginDate.Text.ToString());
                            for (int t = 0; t < Int32.Parse(ts.Days.ToString()) + 1; t++) //根据天数循环添加
                            {
                                string tmpDate = DateTime.Parse(this.txtBeginDate.Text.ToString()).AddDays(t).ToString("yyyy-MM-dd");

                                #region 如果是全天任务
                                if (this.cbIsAllDay.Checked) //如果是全天任务
                                {
                                    SqlDataReader dataReader = task.GetPeriodInfo();
                                    while (dataReader.Read())
                                    {
                                        task.AddTaskToSchedule(Int32.Parse(TaskID), Int32.Parse(dataReader[0].ToString()), s, tmpDate, s.ToLower() == Username.ToLower() ? true : false);

                                    }
                                    dataReader = null;
                                }
                                #endregion

                                #region  如果是时段任务
                                else //如果是时段任务
                                {
                                    if (this.cbIsRepeat.Checked) // 如果是时段重复
                                    {
                                        for (int j = Int32.Parse(this.listBeginTime.SelectedItem.Value.ToString()); j < Int32.Parse(this.listEndTime.SelectedItem.Value.ToString()); j++)
                                            task.AddTaskToSchedule(Int32.Parse(TaskID), j, s, tmpDate, s.ToLower() == Username.ToLower() ? true : false);
                                    }
                                    else   // 如果是全部时段
                                    {
                                        if (tmpDate == this.txtBeginDate.Text.ToString())// 如果是开始天
                                        {

                                            for (int k = Int32.Parse(this.listBeginTime.SelectedItem.Value.ToString()); k <= 20; k++)
                                                task.AddTaskToSchedule(Int32.Parse(TaskID), k, s, tmpDate, s.ToLower() == Username.ToLower() ? true : false);
                                        }
                                        else if (tmpDate == this.txtEndDate.Text.ToString())
                                        {

                                            for (int k = 1; k < Int32.Parse(this.listEndTime.SelectedItem.Value.ToString()); k++)
                                                task.AddTaskToSchedule(Int32.Parse(TaskID), k, s, tmpDate, s.ToLower() == Username.ToLower() ? true : false);
                                        }
                                        else
                                        {
                                            SqlDataReader dataReader = task.GetPeriodInfo();
                                            while (dataReader.Read())
                                            {
                                                task.AddTaskToSchedule(Int32.Parse(TaskID), Int32.Parse(dataReader[0].ToString()), s, tmpDate, s.ToLower() == Username.ToLower() ? true : false);

                                            }
                                            dataReader = null;

                                        }
                                    }
                                }
                                #endregion
                            }



                        }
                        #endregion
                    }

                }

                else if (this.rbAttribute.SelectedItem.Value.ToString() == "0")
                {
                    if (this.cbNeedCo.Checked)
                    {
                        string[] UnameArr = System.Text.RegularExpressions.Regex.Split(UnameStr, ",");
                        for (int uc = 0; uc < UnameArr.Length; uc++)
                            cooperatorList.Add(UnameArr[uc].ToString());
                    }
                    else
                    {
                        cooperatorList.Add(Username);
                    }
                    foreach (string s in cooperatorList)
                    {
                        task.AddTaskToSchedule(Int32.Parse(TaskID), 0, s, this.txtEndDate.Text, s.ToLower() == Username.ToLower() ? true : false);
                    }

                }

                Response.Write("<script language=javascript>alert('添加成功!');window.opener.location='TaskList.aspx?displayType=1';window.close();</script>");
            }


        }



        private void btnCheck_Click(object sender, System.EventArgs e)
        {
            if (ValidateForm())
            {
                string info = "<link href=\"../../Css/BasicLayout.css\" rel=\"stylesheet\" type=\"text/css\">";
                info += "<body leftmargin=\"0\" topmargin=\"0\">";
                //Response.Write("验证成功!");
                ArrayList ExistList = CheckExist();
                if (ExistList.Count > 0)
                {

                    info += "<table width=100% height=30 border=0 cellpadding=0 cellspacing=0 class=GbText>";
                    info += "<tr>";
                    info += "<td background=\"../../Images/treetopbg.jpg\">&nbsp;&nbsp;任务时段冲突检测结果</td>";
                    info += "</tr>";
                    info += "</table>";

                    info += "<table width=100% border=1 cellpadding=0 cellspacing=0 style=BORDER-COLLAPSE: collapse borderColor=93BEE2 class=GbText>";
                    info += " <tr align=center bgcolor=#e8f4ff> ";
                    info += "<td width=30% height=24>检测人员</td>";
                    info += "<td width=30% height=24>日期</td>";
                    info += "<td height=24>时间</td>";
                    info += "</tr>";
                    foreach (TaskConflictRecord conrec in ExistList)
                    {
                        int b = Int32.Parse(conrec.Period);
                        DateTime dt = new DateTime(1999, 1, 1, 8, 0, 0, 0);
                        TimeSpan ts = new TimeSpan(0, 0, (b - 1) * 30, 0, 0);
                        DateTime bt = dt.Add(ts);
                        DateTime et = bt.Add(new TimeSpan(0, 0, 30, 0, 0));

                        info += "<tr align=center><td height=20>" + conrec.Username + "</td>";
                        info += "<td>" + conrec.Date + "</td>";
                        info += "<td>" + bt.ToShortTimeString() + "---" + et.ToShortTimeString() + "</td>";
                        info += "</tr>";

                    }
                    info += "</table>";
                    info += "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                    info += "<tr><td height=\"36\" align=\"center\"><font color=\"#FF0000\">以上时段有冲突</font></td></tr></table>";
                    Response.Write("<script language=javascript>var checkwin=window.open('','check','toolbar=no,scrollbars=yes,width=280,height=200,resizable=yes');");
                    Response.Write("checkwin.document.write('" + info + "');checkwin.moveTo(0,0);checkwin.focus();</script>");

                }
                else
                {
                    info += "<table width=\"100%\" height=\"30\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"GbText\">";
                    info += "<tr><td background=\"treetopbg.jpg\">&nbsp;&nbsp;任务时段冲突检测结果</td>";
                    info += "</tr>";
                    info += "</table>";
                    info += "<table width=\"100%\" height=\"160\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\" borderColor=\"93BEE2\" class=\"GbText\" style=\"BORDER-COLLAPSE: collapse\">";
                    info += "<tr align=\"center\"> ";
                    info += "<td height=\"20\"><font color=\"#FF0000\">您检测的时段没有冲突<br>";
                    info += "<br>  可以安排任务 </font></td></tr></table>";
                    Response.Write("<script language=javascript>var checkwin=window.open('冲突检测结果','check','toolbar=no,scrollbars=yes,width=200,height=200,resizable=yes');");
                    Response.Write("checkwin.document.write('" + info + "');checkwin.moveTo(0,0);checkwin.focus();</script>");
                }
            }
        }

        private void rbAttribute_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.rbAttribute.SelectedItem.Value.ToString() == "1")
            {
                this.btnCheck.Enabled = true;
                this.cbIsAllDay.Enabled = true;
                this.cbIsRepeat.Enabled = true;
                this.listBeginTime.Enabled = true;
                this.txtBeginDate.Enabled = true;
            }
            else
            {
                this.listBeginTime.Enabled = false;
                this.txtBeginDate.Enabled = false;
                this.cbIsAllDay.Enabled = false;
                this.cbIsRepeat.Enabled = false;
                this.btnCheck.Enabled = false;

            }
        }

        private void btnAddUser_Click(object sender, System.EventArgs e)
        {

            for (int i = this.listCooperator.Items.Count - 1; i >= 0; i--)
            {
                if (this.listCooperator.Items[i].Selected)
                {

                    Regex re = new Regex("," + this.listCooperator.Items[i].Value.ToString(), RegexOptions.IgnoreCase);
                    Match m = re.Match("," + UnameStr);
                    if (m.Success)
                    {
                        this.lblMsg.Text = "已经添加此成员!";
                        return;
                    }
                    UnameStr += "," + this.listCooperator.Items[i].Value.ToString();

                }
            }
            if (UnameStr.Substring(0, 1) == ",")
            {
                UnameStr = UnameStr.Substring(1, UnameStr.Length - 1);
            }
            DayTaskFrm.Attributes["src"] = "ViewDayTask.aspx?UnameStr=" + UnameStr;
        }


    }
}