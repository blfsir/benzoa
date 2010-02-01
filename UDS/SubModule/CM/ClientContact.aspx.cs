using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using UDS.Components;

namespace UDS.SubModule.CM
{
    /// <summary>
    /// ClientContact 的摘要说明。
    /// </summary>
    public class ClientContact : System.Web.UI.Page
    {
        #region 控件声明

        protected UDS.Inc.ControlClientContactHistory ControlClientContactHistory1;
        protected System.Web.UI.WebControls.Literal ltl_ClientShortName;
        protected System.Web.UI.WebControls.DropDownList ddl_bargainprognosis;
        protected System.Web.UI.WebControls.CheckBox cbx_travel;
        protected System.Web.UI.WebControls.CheckBox cbx_food;
        protected System.Web.UI.WebControls.CheckBox cbx_gift;
        protected System.Web.UI.WebControls.CheckBox cbx_out;
        protected System.Web.UI.WebControls.TextBox tbx_nextcontacttime;
        protected System.Web.UI.WebControls.Button btn_OK;
        protected System.Web.UI.WebControls.Label lbl_Message;
        protected System.Web.UI.WebControls.Literal ltl_Birthday;
        protected System.Web.UI.WebControls.Literal ltl_sellphase;
        protected System.Web.UI.WebControls.Literal ltl_fee;
        #endregion

        protected int clientid;
        protected System.Web.UI.WebControls.Panel pnl_clientselect;
        protected System.Web.UI.WebControls.Literal ltl_ClientName;
        protected System.Web.UI.WebControls.DropDownList ddl_ClientName;
        protected System.Web.UI.WebControls.TextBox tbx_quicksearch;
        protected System.Web.UI.WebControls.Button btn_search;
        protected System.Web.UI.WebControls.Literal ltl_UpdateTime;
        protected System.Web.UI.WebControls.TextBox tbx_contacttime;
        protected System.Web.UI.WebControls.Literal ltl_ContactTimes;
        protected System.Web.UI.WebControls.Label lbl_BargainPrognosis;
        protected System.Web.UI.WebControls.DropDownList ddl_SellMan;
        protected System.Web.UI.WebControls.Literal ltl_AddMan;
        protected System.Web.UI.WebControls.ListBox lbx_Cooperater;
        protected System.Web.UI.WebControls.Button btn_in;
        protected System.Web.UI.WebControls.Button btn_out;
        protected System.Web.UI.WebControls.ListBox lbx_Staff;
        protected System.Web.UI.WebControls.ListBox lbx_Linkman;
        protected System.Web.UI.WebControls.Button btn_inlinkman;
        protected System.Web.UI.WebControls.Button btn_outlinkman;
        protected System.Web.UI.WebControls.ListBox lbx_ClientLinkman;
        protected System.Web.UI.WebControls.TextBox tbx_contactaim;
        protected System.Web.UI.WebControls.TextBox tbx_sellmoney;
        protected System.Web.UI.WebControls.RangeValidator RangeValidator3;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
        protected System.Web.UI.WebControls.CheckBox cbx_telephone;
        protected System.Web.UI.WebControls.CheckBox cbx_fax;
        protected System.Web.UI.WebControls.CheckBox cbx_email;
        protected System.Web.UI.WebControls.CheckBox cbx_mail;
        protected System.Web.UI.WebControls.CheckBox cbx_meeting;
        protected System.Web.UI.WebControls.CheckBox cbx_interview;
        protected System.Web.UI.WebControls.CheckBox cbx_callin;
        protected System.Web.UI.WebControls.CheckBox cbx_sms;
        protected System.Web.UI.WebControls.CheckBox cbx_trace;
        protected System.Web.UI.WebControls.CheckBox cbx_boot;
        protected System.Web.UI.WebControls.CheckBox cbx_commend;
        protected System.Web.UI.WebControls.CheckBox cbx_requirement;
        protected System.Web.UI.WebControls.CheckBox cbx_submit;
        protected System.Web.UI.WebControls.CheckBox cbx_negotiate;
        protected System.Web.UI.WebControls.CheckBox cbx_actualize;
        protected System.Web.UI.WebControls.CheckBox cbx_traceservice;
        protected System.Web.UI.WebControls.CheckBox cbx_last;
        protected System.Web.UI.WebControls.RadioButton rbtn_trace;
        protected System.Web.UI.WebControls.RadioButton rbtn_boot;
        protected System.Web.UI.WebControls.RadioButton rbtn_commend;
        protected System.Web.UI.WebControls.RadioButton rbtn_requirement;
        protected System.Web.UI.WebControls.RadioButton rbtn_submit;
        protected System.Web.UI.WebControls.RadioButton rbtn_negotiate;
        protected System.Web.UI.WebControls.RadioButton rbtn_actualize;
        protected System.Web.UI.WebControls.RadioButton rbtn_traceservice;
        protected System.Web.UI.WebControls.RadioButton rbtn_last;
        protected System.Web.UI.WebControls.TextBox tbx_thisfee;
        protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.TextBox tbx_contactcontent;
        protected System.Web.UI.WebControls.TextBox tbx_nextcontactaim;
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputFile File2;
        protected System.Web.UI.HtmlControls.HtmlInputFile File3;
        private int contactid = 0;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            UDS.Components.CM cm = new UDS.Components.CM();
            SqlDataReader dr = null;

            if (!Page.IsPostBack)
            {
                tbx_contacttime.Text = DateTime.Now.ToShortDateString();
                tbx_nextcontacttime.Text = DateTime.Now.AddDays(1).ToShortDateString();
                clientid = Int32.Parse((Request.QueryString["ClientID"] == null) || (Request.QueryString["ClientID"] == "") ? "-1" : Request.QueryString["ClientID"].ToString());

                pnl_clientselect.Visible = true;
                //绑定客户列表
                try
                {
                    dr = cm.GetMyClients(Int32.Parse(Request.Cookies["UserID"].Value));
                    ddl_ClientName.DataSource = dr;
                    ddl_ClientName.DataValueField = "id";
                    ddl_ClientName.DataTextField = "name";
                    ddl_ClientName.DataBind();
                }
                finally
                {
                    
                    if (dr != null)
                    {

                        dr.Close();
                    }
                }
                if (clientid != -1)
                {
                    if (ddl_ClientName.Items.Count != 0)
                    {
                        foreach (ListItem li in ddl_ClientName.Items)
                        {
                            if (li.Value == clientid.ToString())
                            {
                                li.Selected = true;
                            }
                            else
                            {
                                li.Selected = false;
                            }
                        }
                        ViewState["ClientID"] = clientid;
                    }
                    //显示销售人员
                    UDS.Components.ClientInfo client = cm.GetClientAllInfo(clientid);
                    UDS.Components.Staff staff = new UDS.Components.Staff();
                    SqlDataReader dr_staff = staff.GetStaffInfo(client.AddManID);
                    try
                    {
                        while (dr_staff.Read())
                        {
                            ltl_AddMan.Text = dr_staff["realname"].ToString();
                        }
                    }
                    finally
                    {
                        dr_staff.Close();
                        dr_staff.Dispose();
                    }
                }
                else
                {
                    if (ddl_ClientName.Items.Count != 0)
                    {
                        clientid = Int32.Parse(ddl_ClientName.Items[0].Value);
                        ViewState["ClientID"] = clientid;
                    }
                    else
                    {
                        ViewState["ClientID"] = clientid;
                    }
                }
                DisplayClientInfo();
                BindData();
                ViewState["ContactID"] = contactid.ToString();
            }
            else
            {
                clientid = Int32.Parse(ViewState["ClientID"].ToString());
                contactid = Int32.Parse(ViewState["ContactID"].ToString());
            }


            tbx_contacttime.Attributes["onfocus"] = "setday(this)";
            tbx_nextcontacttime.Attributes["onfocus"] = "setday(this)";

        }

        private void BindData()
        {
            string staffids = "";
            UDS.Components.Staff staff = new UDS.Components.Staff();

            //绑定该客户的联系人
            UDS.Components.Database db = new UDS.Components.Database();
            SqlDataReader dr_ClientLinkman = null;
            SqlParameter[] prams = {
									   db.MakeInParam("@clientid",SqlDbType.Int,4,clientid)
								   };
            try
            {
                db.RunProc("sp_CM_GetAllLinkmanFromClient", prams, out dr_ClientLinkman);
                lbx_ClientLinkman.DataSource = dr_ClientLinkman;
                lbx_ClientLinkman.DataTextField = "Name";
                lbx_ClientLinkman.DataValueField = "id";
                lbx_ClientLinkman.DataBind();
            }
            finally
            {
                dr_ClientLinkman.Close();
                dr_ClientLinkman.Dispose();
            }

            //绑定协同人员候选列表
            SqlDataReader dr_staff = null;
            for (int i = 0; i < lbx_Cooperater.Items.Count; i++)
            {
                staffids += lbx_Cooperater.Items[i].Value + ",";
            }
            if (staffids.Length != 0)
                staffids = staffids.Substring(0, staffids.Length - 1);

            dr_staff = staff.GetRemainStaff(staffids);

            lbx_Staff.DataSource = dr_staff;
            lbx_Staff.DataTextField = "realname";
            lbx_Staff.DataValueField = "staff_id";
            lbx_Staff.DataBind();
            dr_staff.Close();

            ControlClientContactHistory1.ClientID = clientid;
            ControlClientContactHistory1.BindData();
        }


        /// <summary>
        /// 显示客户信息
        /// </summary>
        private void DisplayClientInfo()
        {
            UDS.Components.CM cm = new UDS.Components.CM();
            //得到客户信息
            SqlDataReader dr_client = cm.GetClientInfo(clientid);
            while (dr_client.Read())
            {
                ltl_ClientName.Text = dr_client["Name"].ToString();
                ltl_ClientShortName.Text = dr_client["ShortName"].ToString();
                ltl_ContactTimes.Text = dr_client["ContactTimes"].ToString();
                ltl_Birthday.Text = dr_client["Birthday"].ToString();
                ltl_UpdateTime.Text = dr_client["UpdateTime"].ToString();
                ltl_fee.Text = dr_client["Fee"].ToString();
                lbl_BargainPrognosis.Text = dr_client["BargainPrognosis"].ToString();
                ltl_sellphase.Text = GetCurStatus(dr_client["sellphase"].ToString());

            }
            dr_client.Close();
        }

        private string GetCurStatus(string curstatus)
        {
            switch (curstatus.Split(',')[0])
            {
                case "trace":
                    return ("跟踪");

                case "boot":
                    return ("启动");

                case "commend":
                    return ("产品推荐");

                case "requirement":
                    return ("需求定义");

                case "submit":
                    return ("方案提交");

                case "negotiate":
                    return ("商务谈判");

                case "actualize":
                    return ("项目实施");

                case "traceservice":
                    return ("跟踪服务");

                case "last":
                    return ("收尾款");

            }
            return ("");
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
            this.ddl_ClientName.SelectedIndexChanged += new System.EventHandler(this.ddl_ClientName_SelectedIndexChanged);
            this.btn_in.Click += new System.EventHandler(this.btn_in_Click);
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            this.btn_inlinkman.Click += new System.EventHandler(this.btn_inlinkman_Click);
            this.btn_outlinkman.Click += new System.EventHandler(this.btn_outlinkman_Click);
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


        private void btn_OK_Click(object sender, System.EventArgs e)
        {
            UDS.Components.CM cm = new UDS.Components.CM();
            UDS.Components.Contact contact = new UDS.Components.Contact();
            UDS.Components.ClientInfo client = cm.GetClientAllInfo(clientid);
            //添加协同人员
            foreach (ListItem lt in lbx_Cooperater.Items)
            {
                UDS.Components.Cooperater cooperater = new UDS.Components.Cooperater();
                cooperater.StaffID = Int32.Parse(lt.Value);
                contact.AddCooperater(cooperater);
            }
            //添加联系人员
            foreach (ListItem lt in lbx_Linkman.Items)
            {
                UDS.Components.Linkman linkman = new UDS.Components.Linkman();
                linkman.ID = Int32.Parse(lt.Value);
                contact.AddLinkman(linkman);
            }

            contact.ID = contactid;

            #region 填充contact
            contact.UpdateTime = DateTime.Now;
            contact.ContactTimes = Int32.Parse(ltl_ContactTimes.Text);
            contact.StaffID = client.AddManID;
            contact.ContactTime = DateTime.Parse(tbx_contacttime.Text);
            contact.ClientID = clientid;
            contact.ContactAim = tbx_contactaim.Text;
            contact.SellMoney = tbx_sellmoney.Text;
            contact.BargainPrognosis = ddl_bargainprognosis.SelectedItem.Value;
            if (cbx_telephone.Checked) contact.ContactType += ContactType.telephone.ToString() + ",";
            if (cbx_fax.Checked) contact.ContactType += ContactType.fax.ToString() + ",";
            if (cbx_email.Checked) contact.ContactType += ContactType.email.ToString() + ",";
            if (cbx_mail.Checked) contact.ContactType += ContactType.mail.ToString() + ",";
            if (cbx_sms.Checked) contact.ContactType += ContactType.sms.ToString() + ",";
            if (cbx_callin.Checked) contact.ContactType += ContactType.interview.ToString() + ",";
            if (cbx_meeting.Checked) contact.ContactType += ContactType.meeting.ToString() + ",";

            if (rbtn_trace.Checked) contact.ContactStatus += ContactStat.trace.ToString() + ",";
            if (rbtn_boot.Checked) contact.ContactStatus += ContactStat.boot.ToString() + ",";
            if (rbtn_commend.Checked) contact.ContactStatus += ContactStat.commend.ToString() + ",";
            if (rbtn_requirement.Checked) contact.ContactStatus += ContactStat.requirement.ToString() + ",";
            if (rbtn_submit.Checked) contact.ContactStatus += ContactStat.submit.ToString() + ",";
            if (rbtn_negotiate.Checked) contact.ContactStatus += ContactStat.negotiate.ToString() + ",";
            if (rbtn_actualize.Checked) contact.ContactStatus += ContactStat.actualize.ToString() + ",";
            if (rbtn_traceservice.Checked) contact.ContactStatus += ContactStat.traceservice.ToString() + ",";
            if (rbtn_last.Checked) contact.ContactStatus += ContactStat.last.ToString() + ",";

            contact.ThisFee = float.Parse(tbx_thisfee.Text);
            if (cbx_travel.Checked) contact.FeeUsed += ContactFeeUsed.travel.ToString() + ",";
            if (cbx_food.Checked) contact.FeeUsed += ContactFeeUsed.food.ToString() + ",";
            if (cbx_gift.Checked) contact.FeeUsed += ContactFeeUsed.gift.ToString() + ",";
            if (cbx_out.Checked) contact.FeeUsed += ContactFeeUsed.outer.ToString() + ",";
            contact.ContactContent = tbx_contactcontent.Text;
            contact.NextContactAim = tbx_nextcontactaim.Text;
            contact.NextContactTime = DateTime.Parse(tbx_nextcontacttime.Text);
            #endregion

            //如果contactid==0则插入操作，否则修改
            if (contactid == 0)
            {
                contact.ContactTimes++;
                contact.ID = cm.AddContact(contact);
                contactid = contact.ID;
                ViewState["ContactID"] = contact.ID.ToString();
                Response.Write("<script>alert('添加成功！');close();opener.document.location.href=opener.document.location.href</script>");
            }
            else
            {
                cm.UpdateContact(contact);
                Response.Write("<script>alert('修改成功！');close();</script>");
            }

            //修改client信息

            client.BargainPrognosis = contact.BargainPrognosis;
            client.ContactTimes = contact.ContactTimes;
            client.CurStatus = contact.ContactStatus;
            client.SellPhase = contact.ContactStatus;
            client.Fee += contact.ThisFee;
            client.UpdateTime = contact.UpdateTime;
            client.ContactTime = contact.ContactTime;
            client.NextContactTime = DateTime.Parse(tbx_nextcontacttime.Text);
            if (client.FirstContactTime == DateTime.Parse("1900-1-1")) client.FirstContactTime = contact.ContactTime;
            cm.UpdateClient(client);
            DisplayClientInfo();

            //上传附件
            UploadAtt();

            ControlClientContactHistory1.ClientID = clientid;
            ControlClientContactHistory1.BindData();
        }



        private void btn_search_Click(object sender, System.EventArgs e)
        {
            string sqlstr = "";
            string id = "";
            UDS.Components.Database db = new UDS.Components.Database();
            SqlDataReader dr = null;

            sqlstr = "select top 1 id from UDS_CM_ClientInfo WHERE name like '%" + tbx_quicksearch.Text.Replace("'", "''") + "%' and AddmanID=" + Request.Cookies["UserID"].Value;
            SqlParameter[] prams = {
										db.MakeInParam("@SQL",SqlDbType.NText,5000,sqlstr)    
			};
            db.RunProc("sp_RunSQL", prams, out dr);
            while (dr.Read())
            {
                id = dr["id"].ToString();
            }
            dr.Close();
            if (id != "")
            {
                foreach (ListItem lt in ddl_ClientName.Items)
                {
                    if (lt.Value == id)
                    {
                        lt.Selected = true;
                    }
                    else
                    {
                        lt.Selected = false;
                    }
                }
                clientid = Int32.Parse(id);
                DisplayClientInfo();
                BindData();
            }


        }

        private void ddl_ClientName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            clientid = Int32.Parse(ddl_ClientName.SelectedItem.Value);
            ViewState["ClientID"] = clientid;
            lbx_Cooperater.Items.Clear();
            lbx_Linkman.Items.Clear();
            DisplayClientInfo();
            BindData();

        }
        /// <summary>
        /// 上载文件
        /// </summary>
        private void UploadAtt()
        {
            HtmlForm FrmCompose = (HtmlForm)this.Page.FindControl("ClientContact");
            UDS.Components.CM cm = new UDS.Components.CM();

            string FileName = "";
            string Extension = "";
            string SavedName = "";
            try
            {
                if (Directory.Exists(Server.MapPath(".") + "\\Attachment"))
                {
                    for (int i = 0; i < FrmCompose.Controls.Count; i++)
                    {
                        if (FrmCompose.Controls[i].GetType().ToString() == "System.Web.UI.HtmlControls.HtmlInputFile")
                        {
                            HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.Controls[i]));
                            if (hif.PostedFile.FileName.Trim() != "")
                            {
                                FileName = System.IO.Path.GetFileName(hif.PostedFile.FileName);
                                Extension = System.IO.Path.GetExtension(hif.PostedFile.FileName);

                                SavedName = cm.InsertFile(FileName, "contact", contactid, Extension).ToString();

                                hif.PostedFile.SaveAs(Server.MapPath(".") + "\\Attachment\\" + SavedName + Extension);
                            }
                            hif = null;
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(Server.MapPath(".") + "\\Attachment");
                    UploadAtt();
                }
            }
            catch (Exception ioex)
            {
                UDS.Components.Error.Log(ioex.ToString());
                Server.Transfer("../Error.aspx");
            }

        }

        private void rbtn_trace_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void btn_in_Click(object sender, System.EventArgs e)
        {
            ArrayList selecteditem = new ArrayList();
            foreach (ListItem lt in lbx_Staff.Items)
            {
                if (lt.Selected)
                {
                    lbx_Cooperater.Items.Add(lt);
                    selecteditem.Add(lt);
                }
            }
            for (int i = 0; i < selecteditem.Count; i++)
            {
                lbx_Staff.Items.Remove((ListItem)selecteditem[i]);
            }
            BindData();
        }

        private void btn_out_Click(object sender, System.EventArgs e)
        {
            ArrayList selecteditem = new ArrayList();
            foreach (ListItem lt in lbx_Cooperater.Items)
            {
                if (lt.Selected)
                {
                    lbx_Staff.Items.Add(lt);
                    selecteditem.Add(lt);
                }
            }
            for (int i = 0; i < selecteditem.Count; i++)
            {
                lbx_Cooperater.Items.Remove((ListItem)selecteditem[i]);
            }
            BindData();
        }

        private void btn_inlinkman_Click(object sender, System.EventArgs e)
        {
            ArrayList selecteditem = new ArrayList();
            foreach (ListItem lt in lbx_ClientLinkman.Items)
            {
                if (lt.Selected)
                {
                    lbx_Linkman.Items.Add(lt);
                    selecteditem.Add(lt);
                }
            }
            for (int i = 0; i < selecteditem.Count; i++)
            {
                lbx_ClientLinkman.Items.Remove((ListItem)selecteditem[i]);
            }
            //BindData();
        }

        private void btn_outlinkman_Click(object sender, System.EventArgs e)
        {
            ArrayList selecteditem = new ArrayList();
            foreach (ListItem lt in lbx_Linkman.Items)
            {
                if (lt.Selected)
                {
                    lbx_ClientLinkman.Items.Add(lt);
                    selecteditem.Add(lt);
                }
            }
            for (int i = 0; i < selecteditem.Count; i++)
            {
                lbx_Linkman.Items.Remove((ListItem)selecteditem[i]);
            }
            //BindData();
        }


    }
}
