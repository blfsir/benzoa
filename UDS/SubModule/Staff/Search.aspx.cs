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

namespace UDS.SubModule.Staff
{
    /// <summary>
    /// Search 的摘要说明。
    /// </summary>
    public class Search : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.TextBox tbx_Name;
        protected System.Web.UI.WebControls.DropDownList ddl_Position;
        protected System.Web.UI.WebControls.LinkButton lbtn_Others;
        protected System.Web.UI.WebControls.TextBox tbx_Mobile;
        protected System.Web.UI.WebControls.TextBox tbx_Email;
        protected System.Web.UI.WebControls.DropDownList ddl_Gender;
        protected System.Web.UI.WebControls.Button btn_Search;
        protected System.Web.UI.HtmlControls.HtmlTable table_Other;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                table_Other.Visible = false;
                BindPosition();
            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
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
            this.lbtn_Others.Click += new System.EventHandler(this.lbtn_Others_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void BindPosition()
        {
            Database db = new Database();
            SqlDataReader dr=null;
            try
            {
                db.RunProc("SP_Ext_GetPosition", out dr);
                ddl_Position.DataSource = dr;
                ddl_Position.DataTextField = "Position_Name";
                ddl_Position.DataValueField = "Position_ID";
                ddl_Position.DataBind();
                ddl_Position.Items.Insert(0, new ListItem("全部", "0"));
            }
            finally
            {
                if (db != null)
                { db.Close(); }
                if (dr != null)
                {

                    dr.Close();
                }
            }
        }

        private void lbtn_Others_Click(object sender, System.EventArgs e)
        {
            table_Other.Visible = !table_Other.Visible;
            if (table_Other.Visible == true)
            {
                lbtn_Others.Text = "其它查询<<<";
            }
            else
            {
                lbtn_Others.Text = "其它查询>>>";
            }
        }
    }
}
