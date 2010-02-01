namespace UDS.Inc
{
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
    using Microsoft.Web.UI.WebControls;
    using System.Configuration;

    /// <summary>
    ///		ControlDepartmentTreeView ��ժҪ˵����
    /// </summary>
    public abstract class ControlRoleTreeView : System.Web.UI.UserControl
    {
        protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
        protected DataTable dataTbl1, dataTbl2;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Microsoft.Web.UI.WebControls.TreeNode tn = new Microsoft.Web.UI.WebControls.TreeNode();
                tn.Text = "<span onmouseover=javascript:title='�ҵĽ�ɫ'>�ҵĽ�ɫ</span>";
                tn.ImageUrl = GetIcon("9");
                TreeView1.Nodes.Add(tn);
                GetRoleNode(tn);
                TreeView1.Nodes[0].Expanded = true;
            }
        }


        private void GetRoleNode(Microsoft.Web.UI.WebControls.TreeNode tv)
        {
            TreeView1.ShowToolTip = true;
            Database db = new Database();
            SqlDataReader dr = null;
            try
            {
                db.RunProc("sp_GetRole", out dr);
                while (dr.Read())
                {
                    Microsoft.Web.UI.WebControls.TreeNode tn = new Microsoft.Web.UI.WebControls.TreeNode();
                    tn.ID = dr["Role_ID"].ToString();
                    tn.Text = "<span onmouseover=javascript:title='" + dr["Role_Description"].ToString() + "'>" + dr["Role_Name"].ToString() + "</span>";
                    tn.ImageUrl = GetIcon("9");
                    tn.NavigateUrl = "ListView.aspx?Role_ID=" + dr["Role_ID"].ToString();
                    tn.Target = "MainFrame";
                    tv.Nodes.Add(tn);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                UDS.Components.Error.Log(ex.ToString());
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

        #region ��ȡ�ڵ�ͼ��
        /// <summary>
        /// ��ȡ�ڵ�ͼ��
        /// </summary>
        private string GetIcon(string ClassType)
        {
            string rtnValue = "../../DataImages/";
            switch (ClassType)
            {
                case "0":
                    rtnValue += "flag.gif";
                    break;
                case "1":
                    rtnValue += "myDoc.gif";
                    break;
                case "2":
                    rtnValue += "mail.gif";
                    break;
                case "3":
                    rtnValue += "page.gif";
                    break;
                case "4":
                    rtnValue += "scales.gif";
                    break;
                case "5":
                    rtnValue += "mail.gif";
                    break;
                case "6":
                    rtnValue += "help_page.gif";
                    break;
                case "7":
                    rtnValue += "red_ball.gif";
                    break;
                case "8":
                    rtnValue += "search_globe.gif";
                    break;
                case "9":
                    rtnValue += "person.gif";
                    break;
                case "10":
                    rtnValue += "role.gif";
                    break;
                default:
                    rtnValue += "";
                    break;
            }
            return rtnValue;
        }
        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN���õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        ///		�����֧������ķ��� - ��Ҫʹ��
        ///		����༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
