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

namespace UDS.SubModule.BBS
{
    /// <summary>
    /// ManageBoard ��ժҪ˵����
    /// </summary>
    public class ManageBoard : System.Web.UI.Page
    {
        private string m_Action;
        private string m_CatalogID;
        private string m_BoardID;
        protected string classid;

        protected System.Web.UI.WebControls.TextBox TxtBoardName;
        protected System.Web.UI.WebControls.RadioButton RdPrivate;
        protected System.Web.UI.WebControls.RadioButton RdPublic;
        protected System.Web.UI.WebControls.Button CmdOK;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvboardname;
        protected System.Web.UI.WebControls.TextBox TxtBoardDescription;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                m_CatalogID = (Request.QueryString["CatalogID"] != null) ? Request.QueryString["CatalogID"].ToString() : "";
                m_BoardID = (Request.QueryString["BoardID"] != null) ? Request.QueryString["BoardID"].ToString() : "";
                m_Action = (Request.QueryString["action"] != null) ? Request.QueryString["action"].ToString() : "";
                classid = (Request.QueryString["classID"] != null) ? Request.QueryString["classID"].ToString() : "";

                ViewState["m_CatalogID"] = m_CatalogID;
                ViewState["m_BoardID"] = m_BoardID;
                ViewState["m_Action"] = m_Action;
                ViewState["classid"] = classid;

                if (m_Action != "")
                {
                    if (m_Action == "ModifyBoard")
                    {
                        //�༩���
                        ReviseModifyBoard();
                        CmdOK.Text = "�޸�";
                    }
                    else
                    {
                        CmdOK.Text = "���";
                    }
                }
            }
            else
            {
                m_CatalogID = ViewState["m_CatalogID"].ToString();
                m_BoardID = ViewState["m_BoardID"].ToString();
                m_Action = ViewState["m_Action"].ToString();
                classid = ViewState["classid"].ToString();
            }

        }



        #region �༩���ʱ���ؼ���ֵ

        public void ReviseModifyBoard()
        {
            SqlDataReader dataReader = null;
            BBSClass BBS = new BBSClass();
            try
            {
                if (m_BoardID != "")
                {
                    dataReader = BBS.GetModifyBBSBoard(Int32.Parse(m_BoardID));
                    dataReader.Read();
                    this.TxtBoardName.Text = dataReader["board_name"].ToString();
                    this.TxtBoardDescription.Text = dataReader["board_description"].ToString();
                    if (Convert.ToBoolean(dataReader["board_type"]) == true)
                    {
                        RdPublic.Checked = true;
                        RdPrivate.Checked = false;
                    }
                    else
                    {
                        RdPrivate.Checked = true;
                        RdPublic.Checked = false;
                    }
                    dataReader.Close();
                    BBS = null;
                    dataReader = null;
                }
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../../Error.aspx");
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
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

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void CmdOK_Click(object sender, System.EventArgs e)
        {
            if (m_Action == "AddBoard")
            //�������
            {
                BBSClass BBS = new BBSClass();
                BBSBoard Board = new BBSBoard();
                HttpCookie UserCookie = Request.Cookies["Username"];
                String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                try
                {
                    Board.CatalogID = Int32.Parse(m_CatalogID);
                    Board.BoardName = this.TxtBoardName.Text;
                    Board.BoardDescription = this.TxtBoardDescription.Text;
                    if (this.RdPublic.Checked == true)
                    {
                        Board.BoardType = 1;
                    }
                    else
                    {
                        Board.BoardType = 0;
                    }
                    BBS.BBSAddBoard(Board);
                    //Response.Write("<script language=javascript>alert('��ӳɹ�!');parent.location.reload();</script>");
                }
                catch (Exception ex)
                {
                    UDS.Components.Error.Log(ex.ToString());
                    Server.Transfer("../../Error.aspx");
                }
                finally
                {
                    BBS = null;
                    Board = null;
                    Server.Transfer("Catalog.aspx?classID=" + classid);
                }
            }
            else if (m_Action == "ModifyBoard")
            {
                //�༩���
                BBSClass BBS = new BBSClass();
                BBSBoard Board = new BBSBoard();
                HttpCookie UserCookie = Request.Cookies["Username"];
                String Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                //try
                {
                    Board.BoardID = Int32.Parse(m_BoardID);
                    Board.BoardName = this.TxtBoardName.Text;
                    Board.BoardDescription = this.TxtBoardDescription.Text;
                    if (this.RdPublic.Checked == true)
                    {
                        Board.BoardType = 1;
                    }
                    else
                    {
                        Board.BoardType = 0;
                    }
                    BBS.EditBBSBoard(Board);
                    Server.Transfer("Catalog.aspx?classID=" + classid);
                }
                //catch (Exception ex)
                {
                    //	UDS.Components.Error.Log(ex.ToString());
                    //	Server.Transfer("../../Error.aspx");
                }
                //finally 
                {
                    BBS = null;
                    Board = null;
                }
            }
        }




    }
}
