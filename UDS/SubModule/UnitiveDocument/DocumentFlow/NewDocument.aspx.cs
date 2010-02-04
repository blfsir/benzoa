using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using UDS.Components;
using System.Data.SqlClient;
using BLL;

namespace UDS.SubModule.UnitiveDocument.DocumentFlow
{
    /// <summary>
    /// NewDocument 的摘要说明。
    /// </summary>
    public class NewDocument : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Table ht;
        protected System.Web.UI.WebControls.TextBox TextBox1;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Button cmdDelete;
        protected System.Web.UI.WebControls.Button cmdReturn;
        protected System.Web.UI.WebControls.Button cmdSend;
        protected System.Web.UI.WebControls.Button cmdSave;

        private long StepID;
        private long FlowID;
        private long FieldNum = 0;
        private long DocID;
        private bool bEditMode;
        private string UserName;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.TextBox TextBox2;
        private long ProjectID = -1;
        protected System.Web.UI.HtmlControls.HtmlInputHidden PID;
        protected System.Web.UI.HtmlControls.HtmlSelect ddlProject;
        private ArrayList al = new ArrayList();

        private string flowNumber = "1";


        private void Page_Load(object sender, System.EventArgs e)
        {
            FlowID = Int32.Parse(Request.QueryString["FlowID"] == null ? "0" : Request.QueryString["FlowID"].ToString());
            DocID = Int32.Parse(Request.QueryString["DocID"] == null ? "0" : Request.QueryString["DocID"].ToString());
            UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);

            //动态添加控件


            //if(!Page.IsPostBack)			
            Bind();

            InitControl(DocID);

        }
        private void Bind()
        {
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();


            if (DocID > 0)
            {

                //读取稿件内容				
                FlowID = df.GetDocumentFlowID(DocID);
                StepID = df.GetDocumentStepID(DocID);
                ProjectID = 0;
                cmdSend.Enabled = true;
                cmdDelete.Enabled = true;
                bEditMode = true;
                if (df.IsProject(UserName, DocID))
                {

                    ProjectID = Int32.Parse(PID.Value);
                    if (!Page.IsPostBack)
                    {
                        DataTable dt;

                        ddlProject.Visible = true;
                        ddlProject.Items.Clear();

                        df.GetProject(UserName, out dt);

                        ddlProject.DataSource = dt.DefaultView;
                        ddlProject.DataTextField = "ClassName";
                        ddlProject.DataValueField = "ClassID";
                        ddlProject.DataBind();

                        //				for(int i=0;i<ddlProject.Items.Count;i++)
                        //				{
                        //					if(ddlProject.Items[i].Value.ToString()==UDS.Components.DocumentFlow.GetDocumentProjectID(DocID).ToString())
                        //						ddlProject.SelectedIndex = i;
                        //				}

                        if (ddlProject.Items.Count > 0)
                        {
                            PID.Value = ddlProject.Items[0].Value.ToString();
                        }
                    }
                }
                else
                {
                    //					StepID = 1;		
                    //					cmdSend.Enabled		= false;
                    //					cmdDelete.Enabled	= false;
                    //					bEditMode			= false;
                    ddlProject.Visible = false;
                    ddlProject.EnableViewState = false;
                }
            }
            else
            {
                StepID = 1;
                cmdSend.Enabled = false;
                cmdDelete.Enabled = false;
                bEditMode = false;
                ddlProject.EnableViewState = false;
                ddlProject.Visible = false;
            }

            df = null;

        }
        private void InitControl(long DocID)
        {
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            SqlDataReader dr = null; //存放人物的数据
            DataTable dt = null;

            try
            {

                df.GetStyleDescription(FlowID, 0, out dr);
                if (DocID > 0)
                    df.GetDocumentInfo(DocID, out dt);

                ht.Style["Left"] = "1px";
                ht.Style["Top"] = "1px";

                al.Clear();
                AddHeadlin();

                while (dr.Read())
                {
                    TextBox txt = new TextBox();

                    txt.ID = "txt" + dr["Field_Name"].ToString();
                    al.Add(dr["Field_Name"].ToString());

                    if (dr["MultiLine"].ToString() != "False")
                    {
                        txt.TextMode = TextBoxMode.MultiLine;
                    }
                    if ("d" == dr["Field_Type"].ToString())
                    {
                        txt.Attributes.Add("onfocus", "setday(this);");
                        txt.AutoPostBack = true;
                        // txt.Visible = false;
                        txt.ReadOnly = true;

                    }
                    txt.Height = Int32.Parse(dr["Height"].ToString());
                    txt.Width = Int32.Parse(dr["Width"].ToString());
                    txt.CssClass = "Input3";

                    if (DocID > 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            txt.Text = dt.Rows[0][dr["Field_Name"].ToString()].ToString();
                        }
                        else
                        {
                            txt.Text = "不存在";
                        }
                    }
                    else
                    {
                        txt.Text = "";
                    }

                    TableCell tc = new TableCell();



                    if ("d" == dr["Field_Type"].ToString() || "c" == dr["Field_Type"].ToString() || "n" == dr["Field_Type"].ToString() || null == dr["Field_Type"].ToString())
                    {
                        //nothing to do
                        tc.Controls.Add(txt);
                    }
                    else
                    {
                        //txt.Visible = false;
                        bool isDdl = IsDdlControl(dr["Field_Type"].ToString());
                        if (isDdl)
                        {
                            txt.Width = 0;
                            tc.Controls.Add(txt);
                            string fieldID = dr["Field_Type"].ToString();
                            DataTable dtFieldValue = df.GetFieldValueList(int.Parse(fieldID));
                            DropDownList ddl = new DropDownList();
                            ddl.ID = "ddl" + dr["Field_Name"].ToString();
                            ddl.DataSource = dtFieldValue;
                            ddl.DataTextField = dtFieldValue.Columns["FieldValue_Name"].ToString();
                            ddl.DataValueField = dtFieldValue.Columns["FieldValue_Name"].ToString();

                            ddl.DataBind();

                            ddl.Items.Insert(0, new ListItem("请选择", ""));
                            ddl.Attributes.Add("onchange", "javascript:setTextValue('" + txt.ID + "','" + ddl.ID + "');");
                            if (DocID > 0)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    //txt.Text = dt.Rows[0][dr["Field_Name"].ToString()].ToString();
                                    ddl.SelectedValue = dt.Rows[0][dr["Field_Name"].ToString()].ToString();
                                }
                                
                            }
                            
                            //onchange="javascript:setTimeout('__doPostBack(\'ddld\',\'\')', 0)" language="javascript"
                            tc.Controls.Add(ddl);
                        }
                        else
                        {
                            txt.Text = getAutoNumber(dr["Field_Type"].ToString());
                            txt.Text = txt.Text+DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString().PadLeft(2,'0').ToString() + this.flowNumber.PadLeft(4,'0').ToString();
                            
                            txt.ReadOnly = true;
                            if (DocID > 0)
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    //txt.Text = dt.Rows[0][dr["Field_Name"].ToString()].ToString();
                                    txt.Text = dt.Rows[0][dr["Field_Name"].ToString()].ToString();
                                }

                            }
                            tc.Controls.Add(txt);
                        }


                    }
                    //tc.Controls.Add(txt);




                    TableRow tr = new TableRow();
                    TableCell tl = new TableCell();

                    Literal lt = new Literal();

                    lt.Text = dr["Example"].ToString();

                    if (FieldNum == 0 || dr["judged"].ToString() == "True")
                    {
                        RequiredFieldValidator rfv = new RequiredFieldValidator();
                        rfv.ControlToValidate = txt.ID;
                        rfv.ErrorMessage = "(*)";
                        rfv.Display = ValidatorDisplay.Dynamic;
                        rfv.EnableClientScript = true;

                        tc.Controls.Add(rfv);
                    }
                    //if (dr["judged"].ToString() == "True")
                    //{

                    //    RegularExpressionValidator rev = new RegularExpressionValidator();

                    //    rev.ErrorMessage = "填写数字";
                    //    rev.ControlToValidate = txt.ID;
                    //    rev.ValidationExpression = @"\d+";

                    //    rev.Display = ValidatorDisplay.Dynamic;

                    //    tc.Controls.Add(rev);

                    //}
                    if ("n" == dr["Field_Type"].ToString())
                    {

                        RegularExpressionValidator rev = new RegularExpressionValidator();

                        rev.ErrorMessage = "填写数字，限两位小数";
                        rev.ControlToValidate = txt.ID;
                        rev.ValidationExpression = @"^\d{1,10}(\.\d{2})?$";

                        rev.Display = ValidatorDisplay.Dynamic;

                        tc.Controls.Add(rev);

                    }
                    //if ("d" == dr["Field_Type"].ToString()) //日期型字段验证
                    //{
                    //    RegularExpressionValidator revDate = new RegularExpressionValidator();

                    //    revDate.ErrorMessage = "填写日期";
                    //    revDate.ControlToValidate = txt.ID;
                    //    revDate.ValidationExpression = @"\d+";

                    //    revDate.Display = ValidatorDisplay.Dynamic;

                    //    tc.Controls.Add(revDate);
                    //}

                    tc.Controls.Add(lt);

                    tl.Text = dr["Field_Description"].ToString() + ":";

                    if (dr["MultiLine"].ToString() != "False")
                        tl.VerticalAlign = VerticalAlign.Top;
                    else
                        tl.VerticalAlign = VerticalAlign.Middle;
                    tl.HorizontalAlign = HorizontalAlign.Right;


                    tr.Cells.Add(tl);
                    tr.Cells.Add(tc);
                    ht.Rows.Add(tr);

                    tc = null;
                    tl = null;
                    tr = null;

                    FieldNum += 1;

                }
            }
            finally
            {

                if (dr != null)
                {
                    dr.Close();
                }
                dr = null;
            }
            if (DocID > 0)
                AddAttach(DocID);

            AddAttachControl();
            AddProjectControl();
            AddControl();

            //=============================//
            //			添加批注
            //=============================//
            DataTable dtPostil;
            df.GetDocumentPostil(DocID, out dtPostil);

            if (dtPostil != null)
            {
                if (dtPostil.Rows.Count > 0)
                {
                    Table tb = new Table();
                    tb.CssClass = "GbText";
                    tb.Width = Unit.Percentage(98);
                    AddRow(tb, "审批意见");
                    AddPostitleHead(tb);

                    for (int i = 0; i < dtPostil.Rows.Count; i++)
                    {
                        AddRow(tb, dtPostil.Rows[i]["RealName"].ToString(), dtPostil.Rows[i]["Postil_Date"].ToString(), dtPostil.Rows[i]["Postil_Content"].ToString(), Int32.Parse(dtPostil.Rows[i]["Postil_Type"].ToString()), dtPostil.Rows[i]["FileName"].ToString(), dtPostil.Rows[i]["FileVisualPath"].ToString(), dtPostil.Rows[i]["UsedTime"].ToString());
                    }
                    AddTable(ht, tb);
                }
            }
            dtPostil = null;



        }

        private string getAutoNumber(string p)
        {
            // string strExit = userObj.UpdatePassWordByUserId(paramsValue, "@exit");

            object[] param = new object[] { null, int.Parse(p) };
            string autoNumber = FlowFieldObject.getAutoNumber(param, "@exit");
            return autoNumber;

        }

        private bool IsDdlControl(string p)
        {
            object[] param = new object[] { int.Parse(p) };
            DataTable dtFlowField = FlowFieldObject.GetFlowFieldById(param);
            return (bool)dtFlowField.Rows[0]["is_ddl"];


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
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
            this.PID.ServerChange += new System.EventHandler(this.PID_ServerChange);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void AddTable(Table tab, Table tb)
        {
            TableRow tr = new TableRow();
            TableCell tl = new TableCell();
            tl.ColumnSpan = 2;
            tl.Width = Unit.Percentage(100);
            tl.HorizontalAlign = HorizontalAlign.Center;
            //tl.Attributes["background"]="../../../Images/treetopbg.jpg";			
            tl.Controls.Add(tb);
            //tl.BackColor = Color.FromArgb(0xff,0xff,0xef);

            tr.Height = 28;
            tr.Cells.Add(tl);

            tab.Rows.Add(tr);

            tl = null;
            tr = null;

        }

        private void AddRow(Table tab, string Caption)
        {
            TableRow tr = new TableRow();
            TableCell tl = new TableCell();

            tl.Text = Caption;
            tl.ColumnSpan = 6;
            tl.Width = Unit.Percentage(100);
            tl.HorizontalAlign = HorizontalAlign.Center;
            tl.Attributes["background"] = "../../../Images/treetopbg.jpg";
            //tl.BackColor = Color.FromArgb(0xff,0xff,0xef);

            tr.Height = 28;
            tr.Cells.Add(tl);

            tab.Rows.Add(tr);

            tl = null;
            tr = null;
        }
        private void AddRow(Table tab, string Postiler, string PostilTime, string PostilContent, int PostilType, string FileName, string FileVisualPath, string UsedTime)
        {
            TableRow tr = new TableRow();
            TableCell tdPotiler = new TableCell();
            TableCell tdPostilTime = new TableCell();
            TableCell tdPotilType = new TableCell();
            TableCell tdPotilContent = new TableCell();
            TableCell tdAttachFiles = new TableCell();
            TableCell tdTime = new TableCell();


            tdPotiler.Text = Postiler;
            tdPotiler.HorizontalAlign = HorizontalAlign.Center;
            tdPotiler.Width = Unit.Percentage(20);


            tdPostilTime.Text = PostilTime;
            tdPostilTime.HorizontalAlign = HorizontalAlign.Center;
            tdPostilTime.Width = Unit.Percentage(20);
            switch (PostilType)
            {
                case 1:
                    tdPotilType.Text = "同意";
                    break;
                case 2:
                    tdPotilType.Text = "拒绝";
                    break;
                case 3:
                    tdPotilType.Text = "完成";
                    break;
                case 4:
                    tdPotilType.Text = "回退";
                    break;
                default:
                    break;
            }
            tdPotilType.HorizontalAlign = HorizontalAlign.Center;
            tdPotilType.Width = Unit.Percentage(10);


            tdPotilContent.Text = PostilContent;
            tdPotilContent.HorizontalAlign = HorizontalAlign.Left;
            tdPotilContent.Width = Unit.Percentage(30);

            tr.Height = 22;
            tr.BackColor = Color.FromArgb(0xe8, 0xf4, 0xff);


            string FilePath = FileVisualPath + FileName;
            tdAttachFiles.Text = "<a href='" + "." + FilePath.Replace("\\", "/") + "' target='_blank'>" + FileName + "</a>";

            tdAttachFiles.HorizontalAlign = HorizontalAlign.Center;
            tdAttachFiles.Width = Unit.Percentage(10);

            tdTime.Text = UsedTime;
            tdTime.HorizontalAlign = HorizontalAlign.Center;
            tdTime.Width = Unit.Percentage(10);

            tr.Cells.Add(tdPotiler);
            tr.Cells.Add(tdPostilTime);
            tr.Cells.Add(tdPotilType);
            tr.Cells.Add(tdPotilContent);
            tr.Cells.Add(tdAttachFiles);
            tr.Cells.Add(tdTime);


            tab.Rows.Add(tr);


            tdPotiler = null;
            tdPostilTime = null;
            tdPotilType = null;
            tdPotilContent = null;
            tdAttachFiles = null;
            tdTime = null;

            tr = null;
        }
        private void AddPostitleHead(Table tab)
        {

            TableRow tr = new TableRow();
            TableCell tdPotiler = new TableCell();
            TableCell tdPostilTime = new TableCell();
            TableCell tdPotilType = new TableCell();
            TableCell tdPotilContent = new TableCell();
            TableCell tdAttachFiles = new TableCell();
            TableCell tdTime = new TableCell();


            tdPotiler.Text = "批阅人";
            tdPotiler.HorizontalAlign = HorizontalAlign.Center;
            tdPotiler.Width = Unit.Percentage(20);


            tdPostilTime.Text = "批阅时间";
            tdPostilTime.HorizontalAlign = HorizontalAlign.Center;
            tdPostilTime.Width = Unit.Percentage(20);

            tdPotilType.Text = "批阅类型";
            tdPotilType.HorizontalAlign = HorizontalAlign.Center;
            tdPotilType.Width = Unit.Percentage(10);


            tdPotilContent.Text = "批阅内容";
            tdPotilContent.HorizontalAlign = HorizontalAlign.Left;
            tdPotilContent.Width = Unit.Percentage(30);

            tdAttachFiles.Text = "附件";

            tdAttachFiles.HorizontalAlign = HorizontalAlign.Center;
            tdAttachFiles.Width = Unit.Percentage(10);

            tdTime.Text = "用时(分)";
            tdTime.HorizontalAlign = HorizontalAlign.Center;
            tdTime.Width = Unit.Percentage(10);


            tr.Height = 22;
            tr.BackColor = Color.FromArgb(0xe8, 0xf4, 0xff);

            tr.Cells.Add(tdPotiler);
            tr.Cells.Add(tdPostilTime);
            tr.Cells.Add(tdPotilType);
            tr.Cells.Add(tdPotilContent);
            tr.Cells.Add(tdAttachFiles);
            tr.Cells.Add(tdTime);


            tab.Rows.Add(tr);


            tdPotiler = null;
            tdPostilTime = null;
            tdPotilType = null;
            tdPotilContent = null;

            tr = null;

        }
        private void AddProjectControl()
        {

            if (ddlProject.Visible == true)
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell tl = new TableCell();

                td.Text = "请选择所属项目:";
                td.HorizontalAlign = HorizontalAlign.Right;
                tr.Cells.Add(td);

                ddlProject.Style["Width"] = "450px";
                ddlProject.Style["Class"] = "Input3";

                tl.Controls.Add(ddlProject);
                tr.Cells.Add(tl);

                ht.Rows.Add(tr);

                td = null;
                tr = null;
                //ddlProject.EnableViewState =true;

            }


        }

        private void AddAttach(long DocID)
        {

            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            DataTable dt = new DataTable();

            df.GetDocumentAttach(DocID, out dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell tc = new TableCell();

                td.Text = "附件:";
                td.HorizontalAlign = HorizontalAlign.Right;

                string FilePath = dt.Rows[i]["FileVisualPath"].ToString() + dt.Rows[i]["FileName"].ToString();

                tc.Text = "<a href='" + "." + FilePath.Replace("\\", "/") + "' target='_blank'>" + dt.Rows[i]["FileName"].ToString() + "</a>";
                tc.HorizontalAlign = HorizontalAlign.Left;

                tr.Cells.Add(td);
                tr.Cells.Add(tc);

                tr.Height = 22;
                tr.HorizontalAlign = HorizontalAlign.Center;

                ht.Rows.Add(tr);
            }

            dt = null;
            df = null;


        }

        private void AddAttachControl()
        {
            string Template;
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            Template = df.GetStyleTemplate(FlowID);
            if (Template != "")
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell tl = new TableCell();

                td.Text = "<a href='" + Template + "' style='text-decoration: underline' titile='模板下载' target='_blank'>模板</a>:";
                td.HorizontalAlign = HorizontalAlign.Right;
                tr.Cells.Add(td);

                System.Web.UI.HtmlControls.HtmlInputFile hif = new System.Web.UI.HtmlControls.HtmlInputFile();
                hif.ID = "fileTemplate";
                hif.Name = "fileTemplate";
                hif.Style["width"] = "450px";
                hif.Style["Class"] = "Input3";

                tl.Controls.Add(hif);
                tr.Cells.Add(tl);

                ht.Rows.Add(tr);

                td = null;
                tr = null;

            }
            else
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableCell tl = new TableCell();

                td.Text = "附件:";
                td.HorizontalAlign = HorizontalAlign.Right;
                tr.Cells.Add(td);

                System.Web.UI.HtmlControls.HtmlInputFile hif = new System.Web.UI.HtmlControls.HtmlInputFile();
                hif.ID = "fileTemplate";
                hif.Name = "fileTemplate";
                hif.Style["width"] = "450px";
                hif.Style["Class"] = "Input3";

                tl.Controls.Add(hif);
                tr.Cells.Add(tl);

                ht.Rows.Add(tr);

                td = null;
                tr = null;
            }

            df = null;

        }

        private void UploadFile(long DocID)
        {
            string FileName = "";
            HtmlForm FrmCompose = (HtmlForm)this.Page.FindControl("NewDocument");

            //生成附件目录
            if (!System.IO.Directory.Exists(Server.MapPath(".") + "\\AttachFiles"))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(".") + "\\AttachFiles");
            }

            try
            {
                HtmlInputFile hif = ((HtmlInputFile)(FrmCompose.FindControl("fileTemplate")));
                if (hif.PostedFile != null)
                {
                    if (hif.PostedFile.FileName.Trim() != "")
                    {
                        FileName = System.IO.Path.GetFileName(hif.PostedFile.FileName);

                        //生成用户目录
                        if (!System.IO.Directory.Exists(Server.MapPath(".") + "\\AttachFiles\\" + UserName))
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(".") + "\\AttachFiles\\" + UserName);
                        }

                        Random TempNameInt = new Random();
                        string NewDocDirName = TempNameInt.Next(100000000).ToString();
                        //生成随机目录
                        if (!System.IO.Directory.Exists(Server.MapPath(".") + "\\AttachFiles\\" + UserName + "\\" + NewDocDirName))
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(".") + "\\AttachFiles\\" + UserName + "\\" + NewDocDirName);
                        }

                        TempNameInt = null;

                        //保存文件
                        hif.PostedFile.SaveAs(Server.MapPath(".") + "\\AttachFiles\\" + UserName + "\\" + NewDocDirName + "\\" + FileName);

                        UDS.Components.DocAttachFile att = new UDS.Components.DocAttachFile();
                        UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

                        // 初始化
                        att.FileAttribute = 0;
                        att.FileSize = hif.PostedFile.ContentLength;
                        att.FileName = FileName;
                        att.FileAuthor = UserName;
                        att.FileCatlog = "公文";
                        att.FileVisualPath = "\\AttachFiles\\" + UserName + "\\" + NewDocDirName + "\\";
                        att.FileAddedDate = DateTime.Now.ToString(); ;

                        df.AddAttach(att, DocID);

                        df = null;
                        att = null;

                    }
                    hif = null;
                }
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
            }
            finally
            {

            }

        }

        private void AddHeadlin()
        {
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            TableRow tr = new TableRow();
            TableCell td = new TableCell();

            td.Text = df.GetStyleHeadline(FlowID);
            this.flowNumber = td.Text.Substring(td.Text.IndexOf(":") + 1, td.Text.IndexOf(")") - td.Text.IndexOf(":") - 1);
            td.ColumnSpan = 2;
            td.Height = 28;
            td.Attributes["BackGround"] = "../../../images/treetopbg.jpg";

            tr.Cells.Add(td);

            tr.HorizontalAlign = HorizontalAlign.Center;
            tr.BackColor = Color.FromArgb(0xff, 0xff, 0xef);
            ht.Rows.Add(tr);

            td = null;
            tr = null;
            df = null;

        }

        private void AddControl()
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();

            cmdSave.Style["Top"] = td.Style["Top"];

            td.Controls.Add(cmdSave);
            td.Controls.Add(cmdSend);
            td.Controls.Add(cmdDelete);
            td.Controls.Add(cmdReturn); ;

            td.ColumnSpan = 2;

            tr.Cells.Add(td);

            tr.HorizontalAlign = HorizontalAlign.Center;
            ht.Rows.Add(tr);

            //			td = null;
            //			tr = null;
        }
        private string GetStyleInsertData()
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("NewDocument");

            mySql += "insert into UDS_Flow_Style_Data (";
            for (int i = 0; i < FieldNum; i++)
            {
                mySql += al[i].ToString() + ",";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ") values(";
            for (int i = 0; i < FieldNum; i++)
            {
                mySql += "'" + Request.Form["txt" + al[i].ToString()].ToString().Replace("'", "''") + "',";
            }
            mySql = mySql.Substring(0, mySql.Length - 1) + ")";
            return mySql;
        }
        private string GetStyleUpdateData(long DocID)
        {
            string mySql = "";
            HtmlForm FrmNewDocument = (HtmlForm)this.Page.FindControl("NewDocument");

            if (FieldNum > 0)
            {
                mySql += "update UDS_Flow_Style_Data set ";
                for (int i = 0; i < FieldNum; i++)
                {
                    mySql += al[i].ToString() + "=" + "'" + ((TextBox)FrmNewDocument.FindControl("txt" + al[i].ToString())).Text.Replace("'", "''") + "'";
                    if (i != (FieldNum - 1))
                        mySql += ",";
                }
                mySql += " where Doc_ID = " + DocID.ToString();

                return mySql;
            }
            else
            {
                return "Select 1";
            }

        }
        private void cmdSend_Click(object sender, System.EventArgs e)
        {
            //发送到下一环节，使程序处于运行中
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();

            if (ProjectID >= 0)
            {
                int iResult = df.PostDocument(UserName, DocID, ProjectID);

                if (iResult == 0)
                {
                    df = null;
                    Server.Transfer("DisplayDocument.aspx?DocID=" + DocID.ToString());
                }
                else
                {
                    Response.Write("<script lanuage='javascript'>alert('" + df.DoMessage(iResult, DocID, false) + "');</script>");
                }

            }
            else
                Response.Write("<script language='javascript'>alert('用户没有一个项目，不能按项目发送！');</script>");
            df = null;
        }

        private void cmdDelete_Click(object sender, System.EventArgs e)
        {
            //删除拟稿文档
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            df.DeleteDocument(DocID);
            df = null;
            Server.Transfer("FlowTemplate.aspx");
        }

        private void cmdReturn_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("DraftList.aspx");
        }

        private void cmdSave_Click(object sender, System.EventArgs e)
        {
            UDS.Components.DocumentFlow df = new UDS.Components.DocumentFlow();
            string mySql;


            if (bEditMode == false)
            {

                mySql = GetStyleInsertData();

                //拟稿
                DocID = df.AddDocument(UserName, FlowID, mySql);

                //上传文件
                UploadFile(DocID);

                df = null;

                //转到查看稿件
                Server.Transfer("NewDocument.aspx?FlowID=" + FlowID.ToString() + "&DocID=" + DocID.ToString());

            }
            else
            {
                mySql = GetStyleUpdateData(DocID);

                //Response.Write("<script language='javascript'>alert('" + mySql + "');</script>");
                df.UpdateDocument(mySql);

                string FileName = df.GetAttachName(DocID);
                if (FileName.Length > 0)
                {
                    df.DeleteAttach(DocID);
                    if (System.IO.File.Exists(Server.MapPath(@"." + FileName)) == true)
                        System.IO.File.Delete(Server.MapPath(@"." + FileName));
                }

                //上传文件
                UploadFile(DocID);

                df = null;
                //修改编辑文件
            }
            Response.AddHeader("Refresh", "1");

        }

        private void PID_ServerChange(object sender, System.EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sender.ToString();
        }

    }
}
