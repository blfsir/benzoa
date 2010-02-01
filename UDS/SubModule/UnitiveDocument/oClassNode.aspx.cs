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
using System.Data.SqlClient;
using UDS.Components;

namespace UDS.SubModule.UnitiveDocument
{
    /// <summary>
    /// oClassNode 的摘要说明。
    /// </summary>
    public class oClassNode : System.Web.UI.Page
    {
        public static string ClassID = "";
        public string Action = "";
        protected System.Web.UI.WebControls.TextBox txtAClassName;
        protected System.Web.UI.WebControls.DropDownList listNodeType;
        protected System.Web.UI.WebControls.Label lblCreate;
        protected System.Web.UI.WebControls.Label lblDelete;
        protected System.Web.UI.WebControls.Label lblRevise;
        protected System.Web.UI.WebControls.Label lblParentNodeName;
        protected System.Web.UI.WebControls.Button btnAdd;
        protected System.Web.UI.WebControls.Button btnRevise;
        protected System.Web.UI.WebControls.Button btnDelete;
        protected System.Web.UI.WebControls.TextBox txtAClassRemark;

        private void Page_Load(object sender, System.EventArgs e)
        {
            ClassID = (Request.QueryString["ClassID"] != null) ? Request.QueryString["ClassID"].ToString() : "";
            Action = (Request.QueryString["Action"] != null) ? Request.QueryString["Action"].ToString() : "";
            if (!Page.IsPostBack)
            {
                if (Action == "1")
                {
                    this.lblCreate.BackColor = Color.FromName("#1ED2CA");
                    this.btnRevise.Visible = false;
                    this.btnDelete.Visible = false;


                }
                if (Action == "2")
                {
                    ProjectClass prj = new ProjectClass();
                    this.lblDelete.BackColor = Color.FromName("#1ED2CA");
                    this.btnRevise.Visible = false;
                    this.btnAdd.Visible = false;
                    this.btnDelete.Visible = true;
                    PopulateReviseData();

                    if (prj.IsExistSubClass(Int32.Parse(ClassID)))
                        this.btnDelete.Attributes["onClick"] = "javascript:alert('此项目还存在子节点，不能删除!!');return false;";
                    else
                        this.btnDelete.Attributes["onClick"] = "javascript:return confirm('您确认吗?');";

                    prj = null;
                }
                if (Action == "3")
                {
                    this.lblRevise.BackColor = Color.FromName("#1ED2CA");
                    this.btnRevise.Visible = true;
                    this.btnAdd.Visible = false;
                    PopulateReviseData();
                }

                PopulateData();
            }

        }

        #region 删除节点
        /// <summary>
        /// 删除节点
        /// </summary>
        private void DeleteClass()
        {
            ProjectClass prj = new ProjectClass();
            try
            {
                prj.Delete(Int32.Parse(ClassID));
                prj = null;
                Response.Write("<script language=javascript>alert('删除成功!');parent.location.reload();</script>");

            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../Error.aspx");

            }


        }
        #endregion

        #region 绑定修改时数据
        /// <summary>
        /// 绑定修改时数据
        /// </summary>
        private void PopulateReviseData()
        {
            SqlDataReader dataReader = null;
            Class cls = new Class();
            try
            {
                dataReader = cls.GetClassDetail(Int32.Parse(ClassID));
                dataReader.Read();
                this.txtAClassName.Text = dataReader[1].ToString();
                this.txtAClassRemark.Text = dataReader[2].ToString();
                cls = null;
               //dataReader = null;
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../Error.aspx");

            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader = null;
                }
            }


        }
        #endregion

        #region 绑定初始化时数据
        private void PopulateData()
        {
            Class cls = new Class();
            this.lblParentNodeName.Text = cls.GetClassName(Int32.Parse(ClassID));
            cls = null;
        }
        #endregion

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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnRevise.Click += new System.EventHandler(this.btnRevise_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            Class cls = new Class();
            HttpCookie UserCookie = Request.Cookies["Username"];
            String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
            try
            {
                cls.AddClass(Int32.Parse(ClassID), this.txtAClassName.Text, this.txtAClassRemark.Text, 1, Username, DateTime.Now, 0);
                Response.Write("<script language=javascript>alert('添加成功!');parent.LeftFrame.location='ProjectTreeView.aspx?classID=" + ClassID + "';</script>");
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../Error.aspx");
            }
            finally
            {
                cls = null;
            }

        }

        private void btnRevise_Click(object sender, System.EventArgs e)
        {
            DirectoryClass dc = new DirectoryClass();
            try
            {
                dc.Revise(Int32.Parse(ClassID), this.txtAClassName.Text, this.txtAClassName.Text, 1, 100, DateTime.Today, DateTime.Today);
                Response.Write("<script language=javascript>alert('修改成功!');parent.LeftFrame.location='ProjectTreeView.aspx?classID=" + ClassID + "';</script>");
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../Error.aspx");
            }
            finally
            {
                dc = null;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteClass();
        }
    }
}
