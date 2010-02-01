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
using System.Data.OleDb;
using UDS.Components;
using System.Data.SqlClient;

namespace UDS.SubModule.Query
{
    /// <summary>
    /// Listview ��ժҪ˵����
    /// </summary>
    public class Listview : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.DataGrid dgDocList;
        protected string keyString;
        protected int Range;
        protected int SearchType;
        protected System.Web.UI.WebControls.DataGrid dgMailList;
        protected System.Web.UI.HtmlControls.HtmlTable tabDoc;
        protected System.Web.UI.HtmlControls.HtmlTable tabMail;
        protected string UserName;
        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            keyString = (Request.QueryString["key"] != null) ? Request.QueryString["key"].ToString() : "";
            UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
            Range = Int32.Parse((Request.QueryString["Range"] != null) ? Request.QueryString["Range"].ToString() : "0");
            SearchType = Int32.Parse((Request.QueryString["SearchType"] != null) ? Request.QueryString["SearchType"].ToString() : "0");
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        #region ���ݰ���DataGrid
        /// <summary>
        /// ��ĳ�û����ʼ�ȡ������DataGrid
        /// </summary>
        protected void BindGrid()
        {
            Database mySQL = new Database();

            try
            {
                /*
                 *=========================================			  
                 *				�����ĵ�			 
                 *========================================= 			 
                 */

                if ((SearchType & 0x01) == 0x01)
                {
                    dgDocList.Visible = true;
                    if ((Range & 0x08) == 0x08)
                    {
                        FileSearch("UDS_Doc");
                    }


                    SqlParameter[] parameters = {
												mySQL.MakeInParam("@UserName",SqlDbType.VarChar,300,UserName),
												mySQL.MakeInParam("@KeyString",SqlDbType.VarChar,300,keyString),
												mySQL.MakeInParam("@SearchRange",SqlDbType.Int, 4,Range),
												mySQL.MakeInParam("@ViewDocRightCode",SqlDbType.Int, 4,10),
												mySQL.MakeInParam("@Inherit",SqlDbType.Bit ,1,0)
											};
                    SqlDataReader dr = null; //������������	
                    try
                    {
                        mySQL.RunProc("sp_FindDoc", parameters, out dr);

                        DataTable dt = Tools.ConvertDataReaderToDataTable(dr);


                        dgDocList.DataSource = dt.DefaultView;
                        dgDocList.DataBind();
                    }
                    finally
                    {
                      
                        if (dr != null)
                        {

                            dr.Close();
                        }
                    }


                }
                else
                {
                    dgDocList.Visible = false;
                    tabDoc.Visible = false;
                }

                /*
                 *=========================================			  
                 *				�����ʼ�			 
                 *========================================= 
                 */
                if ((SearchType & 0x02) == 0x02)
                {
                    dgMailList.Visible = true;
                    if ((Range & 0x08) == 0x08)
                    {
                        FileSearch("UDS_Mail");
                    }

                    SqlParameter[] parameters = {
												mySQL.MakeInParam("@UserName",SqlDbType.VarChar,300,UserName),
												mySQL.MakeInParam("@KeyString",SqlDbType.VarChar,300,keyString),
												mySQL.MakeInParam("@SearchRange",SqlDbType.Int, 4,Range)
											};
                    SqlDataReader dr = null; //������������		
                    try
                    {
                        mySQL.RunProc("sp_FindMail", parameters, out dr);

                        DataTable dt = Tools.ConvertDataReaderToDataTable(dr);



                        dgMailList.DataSource = dt.DefaultView;
                        dgMailList.DataBind();
                    }
                    finally
                    {
                        
                        if (dr != null)
                        {

                            dr.Close();
                        }
                    }

                }
                else
                {
                    tabMail.Visible = false;
                    dgMailList.Visible = false;
                }
            }
            finally
            {
                mySQL.Close();

            }
        }

        #endregion
        private void FileSearch(string catalog)
        {
            Database mySQL = new Database();
            DataSet ds = new DataSet();
            String myConnStr = "Provider=MSIDXS; Data Source=" + catalog + ";";
            String mySql = "SELECT FileName, Path, Characterization, Rank, Create, Size FROM SCOPE() WHERE CONTAINS ('" + keyString + "')> 0";
            OleDbConnection myConn = new OleDbConnection(myConnStr);

            OleDbDataAdapter myAdapter = new OleDbDataAdapter(mySql, myConn);
            try
            {
                myAdapter.Fill(ds, "Search");
            }
            catch (Exception ex)
            {
                UDS.Components.Error.Log(ex.ToString());
                Server.Transfer("../Error.aspx");
            }
            finally
            {
                myAdapter = null;
                myConn.Close();
                myConn = null;
            }


            for (int i = 0; i < ds.Tables["Search"].Rows.Count; i++)
            {
                DataRow myDr;
                myDr = ds.Tables["Search"].Rows[i];

                SqlParameter[] pparameters = {												
													mySQL.MakeInParam("@FileName",SqlDbType.VarChar,300,myDr["FileName"]),
													mySQL.MakeInParam("@Path",SqlDbType.VarChar,300,myDr["Path"].ToString().Replace(Server.MapPath("..\\UnitiveDocument\\Document").Replace("/","\\").ToLower()  ,"") ),
													mySQL.MakeInParam("@Characterization",SqlDbType.NText ,10000,myDr["Characterization"] ),
													mySQL.MakeInParam("@Rank",SqlDbType.VarChar,300,myDr["Rank"]),
													mySQL.MakeInParam("@Create",SqlDbType.DateTime ,10,myDr["Create"]),
													mySQL.MakeInParam("@Size",SqlDbType.Int,4,myDr["Size"])
												};
                mySQL.RunProc("sp_AddScope", pparameters);
            }


        }

        #region ��ҳ�¼�
        public void DataGrid_PageChanged(object sender, DataGridPageChangedEventArgs e)
        {
            dgDocList.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        public string GetUserRealName(string UserStr)
        {
            return UDS.Components.Staff.GetRealNameStrByUsernameStr(UserStr, 1);
        }

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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
