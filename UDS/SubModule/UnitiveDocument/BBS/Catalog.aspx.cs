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

namespace UDS.SubModule.BBS
{
    /// <summary>
    /// Catalog 的摘要说明。
    /// </summary>
    public class Catalog : System.Web.UI.Page
    {
        protected HttpCookie UserCookie;
        protected bool Admin;
        protected bool Bulletin;
        protected string classid;
        public string Username;
        public string m_ForumItemID;

        protected System.Web.UI.WebControls.Label LCatalog;
        protected System.Web.UI.WebControls.Label LForumItem;
        protected System.Web.UI.WebControls.Label LBoard;
        protected System.Web.UI.WebControls.Label LForumTimes;
        protected System.Web.UI.WebControls.Label LReplay;
        protected System.Web.UI.WebControls.Label LReplays;
        protected System.Web.UI.WebControls.Label LBoardDescription;
        protected System.Web.UI.WebControls.Label LBoardMaster;
        protected System.Web.UI.WebControls.Label LSender;
        protected System.Web.UI.WebControls.Label LSendTime;
        protected System.Web.UI.HtmlControls.HtmlAnchor A1;
        protected System.Web.UI.WebControls.Repeater rpt_catalog;
        protected System.Web.UI.WebControls.Panel adminop;
        protected System.Web.UI.WebControls.Repeater rpt_board;
        protected System.Web.UI.WebControls.LinkButton lbtnDelBoard;
        protected System.Web.UI.WebControls.LinkButton btndelcatalog;


        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            UserCookie = Request.Cookies["Username"];
            Username = Server.UrlDecode(Request.Cookies["UserName"].Value); 
            classid = (Request.QueryString["classID"] != null && Request.QueryString["classID"] != "") ? Request.QueryString["classID"].ToString() : "0";
            ViewState["classid"] = classid;
            A1.HRef = "ManageCatalog.aspx?classID=" + classid + "&Action=AddCatalog";
            if (!Page.IsPostBack)
            {
                //显示数据
                PopulateData();
            }
            else
            {
                classid = ViewState["classid"].ToString();
                Admin = Boolean.Parse(ViewState["Admin"].ToString());
                Bulletin = Boolean.Parse(ViewState["Bulletin"].ToString());
            }
        }


        #region 删除分类

        protected void btndelcatalog_Click(object sender, System.EventArgs e)
        {

            BBSClass bbs = new BBSClass();
            HttpCookie UserCookie = Request.Cookies["Username"];
            String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
            try
            {
                bbs.DelBBSCatalog(Int32.Parse(((LinkButton)sender).CommandArgument));
                bbs = null;
                Response.Redirect("Catalog.aspx?classID=" + classid);
                //Response.Write("<script language=javascript>alert('删除成功!');parent.location.reload();</script>");
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../../Error.aspx");
            }
        }



        #endregion

        #region 删除板块

        public void DeleteBoard(object sender, System.EventArgs e)
        {
            BBSClass bbs = new BBSClass();
            HttpCookie UserCookie = Request.Cookies["Username"];
            String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
            try
            {
                bbs.DelBBSBoard(Int32.Parse(((LinkButton)sender).CommandArgument));
                bbs = null;
                Response.Redirect("Catalog.aspx?classID=" + classid);
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../../Error.aspx");
            }
        }


        #endregion

        #region 显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        private void PopulateData()
        {
            #region 初始化数据
            DataTable dataTable_catalog = new DataTable();
            DataTable dataTable_board = new DataTable();
            DataTable dataTable_boardmaster = new DataTable();
            DataSet ds = new DataSet();
            SqlDataReader dr_catalog = null;
            SqlDataReader dr_board = null;
            SqlDataReader dr_boardmaster = null;
            BBSClass bbsclass = new BBSClass();
            BBSCatalog catalog = new BBSCatalog();//分类
            BBSBoard board = new BBSBoard();//板块
            BBSForumItem item = new BBSForumItem();//贴子的信息
            BBSBoardmaster master = new BBSBoardmaster();//斑竹信息
            BBSReplay replay = new BBSReplay();//回复信息
            #endregion
            try
            {
                //try

                //判断权限
                Admin = bbsclass.AdminBBS(Username, Int32.Parse(classid));
                ViewState["Admin"] = Admin;
                Bulletin = bbsclass.AdminSysBulletin(Username, Int32.Parse(classid));
                ViewState["Bulletin"] = Bulletin;
                A1.Visible = Admin;
                //得到类别信息
                dr_catalog = bbsclass.GetBBSCatalog();
                if (Admin)
                {
                    HttpCookie cookie = new HttpCookie("UDSBBSAdmin", "1");
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("UDSBBSAdmin", "0");
                    Response.Cookies.Add(cookie);
                }

                if (Bulletin)
                {
                    HttpCookie cookie1 = new HttpCookie("UDSBBSBulletinAdmin", "1");
                    Response.Cookies.Add(cookie1);
                }
                else
                {
                    HttpCookie cookie1 = new HttpCookie("UDSBBSBulletinAdmin", "0");
                    Response.Cookies.Add(cookie1);
                }

                dataTable_catalog = Tools.ConvertDataReaderToDataTable(dr_catalog);
                dataTable_catalog.TableName = "catalogTable";
                ds.Tables.Add(dataTable_catalog);

                //得到板块信息
                if (Admin)
                    dr_board = bbsclass.GetAllBBSBoard();
                else
                    dr_board = bbsclass.GetBBSBoard((string)Username);

                dataTable_board = Tools.ConvertDataReaderToDataTable(dr_board);
                dataTable_board.TableName = "boardTable";
                ds.Tables.Add(dataTable_board);

                //得到斑竹信息
                dr_boardmaster = bbsclass.GetBoardMaster();
                dataTable_boardmaster = Tools.ConvertDataReaderToDataTable(dr_boardmaster);
                dataTable_boardmaster.TableName = "boardmasterTable";
                ds.Tables.Add(dataTable_boardmaster);

                //对子表进行数据绑定
                ds.Relations.Add("catolog_board", ds.Tables["catalogTable"].Columns["catalog_id"], ds.Tables["boardTable"].Columns["catalog_id"], false);
                ds.Relations.Add("board_boardmaster", ds.Tables["boardTable"].Columns["board_id"], ds.Tables["boardmasterTable"].Columns["board_id"], false);

                rpt_catalog.DataSource = ds.Tables["catalogTable"].DefaultView;
                Page.DataBind();
            }
            finally
            {
                dr_board.Close();
                dr_boardmaster.Close();
                dr_catalog.Close();
            }
        }
        //			catch(Exception ex)
        //			{
        //				UDS.Components.Error.Log(ex.ToString());
        //				Server.Transfer("../../Error.aspx");
        //			}
        //			finally
        //			{
        //				dr_catalog = null;
        //				dr_board = null;
        //				dr_boardmaster = null;
        //			}




        #endregion

        private void rpt_catalog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.WebControl ctl = (System.Web.UI.WebControls.WebControl)e.Item.FindControl("btndelcatalog");
            if (ctl != null)
            {

                ctl.Attributes["onclick"] = "return confirm('确定删除吗?')";
            }
        }

        protected void rpt_board_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.WebControl ctl = (System.Web.UI.WebControls.WebControl)e.Item.FindControl("lbtnDelBoard");
            if (ctl != null)
            {

                ctl.Attributes["onclick"] = "return confirm('确定删除吗?')";
            }
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
            this.Load += new EventHandler(this.Page_Load);
            this.rpt_catalog.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rpt_catalog_ItemDataBound);

        }
        #endregion
    }
}
