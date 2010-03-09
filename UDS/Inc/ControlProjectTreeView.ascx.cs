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
	///		ClassTreeView 的摘要说明。
	/// </summary>
	public abstract class ClassTreeView : System.Web.UI.UserControl
	{
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
		protected DataTable dataTbl1,dataTbl2;
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{	
				InitRootNodeDataTable();
				InitTreeRootNode(TreeView1.Nodes);
				TreeView1.ExpandLevel = 0;
                
			//	TreeView1.Nodes[80].Expanded=true;
			//	InitTree(TreeView1.Nodes,"0");
			}
		}
	
		private void ExpandNode(string NodeID)
		{
			
			
		}

		#region 将DataReader 转为 DataTable
		/// <summary>
		/// 将DataReader 转为 DataTable
		/// </summary>
		/// <param name="DataReader">DataReader</param>
        //public DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        //{
        //    DataTable datatable = new DataTable();
        //    try
        //    {
        //        DataTable schemaTable = dataReader.GetSchemaTable();
        //        //动态添加列
        //        foreach (DataRow myRow in schemaTable.Rows)
        //        {
        //            DataColumn myDataColumn = new DataColumn();
        //            myDataColumn.DataType = System.Type.GetType("System.String");
        //            myDataColumn.ColumnName = myRow[0].ToString();
        //            datatable.Columns.Add(myDataColumn);
        //        }
        //        //添加数据
        //        while (dataReader.Read())
        //        {
        //            DataRow myDataRow = datatable.NewRow();
        //            for (int i = 0; i < schemaTable.Rows.Count; i++)
        //            {
        //                myDataRow[i] = dataReader[i].ToString();
        //            }
        //            datatable.Rows.Add(myDataRow);
        //            myDataRow = null;
        //        }
        //        schemaTable = null;
        //    }
        //    finally
        //    {
        //        dataReader.Close();
        //        dataReader.Dispose();
        //    }
        //    return datatable;
        //}
		#endregion

		/// <summary>
		/// 初始化 RootNode DataTable
		/// </summary>
		private void InitRootNodeDataTable()
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			String username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			SqlParameter[] prams = {
									   data.MakeInParam("@UserName",      SqlDbType.VarChar , 20, username)
									
								   };
			try
			{
				data.RunProc("sp_GetShowClass", prams,out dataReader);
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
				//UDS.Components.Error.Log(ex.ToString());
			}
            dataTbl1 = UDS.Components.Tools.ConvertDataReaderToDataTable(dataReader);
			dataReader.Close();
			dataTbl1.TableName = "TreeView";
		}

		/// <summary>
		/// 初始化 ChildNode DataTable
		/// </summary>
		private void InitChildNodeDataTable(int ClassParentID)
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			SqlParameter[] prams = {
									   data.MakeInParam("@Class_id",      SqlDbType.Int  , 20, ClassParentID)
								   };
			try
			{
				data.RunProc("sp_GetAllChildClass", prams,out dataReader);
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
				//UDS.Components.Error.Log(ex.ToString());
			}
            dataTbl2 = UDS.Components.Tools.ConvertDataReaderToDataTable(dataReader); 
			dataReader.Close();
			dataTbl2.TableName = "TreeView";
		}

		/// <summary>
		/// 初始化TreeView 的 RootNode
		/// </summary>
        private void InitTreeRootNode(Microsoft.Web.UI.WebControls.TreeNodeCollection TNC)
		{
			DataView dataView  = new DataView();
			dataView		   = dataTbl1.Copy().DefaultView;
		//	dataView.RowFilter = "ClassParentID = ClassID";
			foreach(DataRowView drv in dataView)
			{
                Microsoft.Web.UI.WebControls.TreeNode tn = new Microsoft.Web.UI.WebControls.TreeNode();
				tn.ID		   = drv["ClassID"].ToString();
				tn.Text		   = "<span onmousemove=javascript:title='"+drv["ClassName"]+"'>"+drv["ClassName"].ToString()+"</span>";
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString());
				tn.NavigateUrl = "Switch.aspx?Action=1&ClassID="+drv["ClassID"].ToString();
				tn.Target      = "MainFrame";
				TNC.Add(tn);
				InitChildNodeDataTable(Int32.Parse(tn.ID.ToString()));
				InitTreeChildNode(tn.Nodes,tn.ID);
			}
			dataTbl1 = null;
			dataTbl2 = null;
		}	

		/// <summary>
		/// 初始化TreeView 的 ChildNode
		/// </summary>
        private void InitTreeChildNode(Microsoft.Web.UI.WebControls.TreeNodeCollection TNC, string classParentID)
		{
			DataView dataView  = new DataView();
			dataView		   = dataTbl2.Copy().DefaultView ;
			dataView.RowFilter = "ClassParentID = " + classParentID + "";
			foreach(DataRowView drv in dataView)
			{
                Microsoft.Web.UI.WebControls.TreeNode tn = new Microsoft.Web.UI.WebControls.TreeNode();
				tn.ID		   = drv["ClassID"].ToString();
				tn.Text		   = "<span onmousemove=javascript:title='"+drv["ClassName"]+"'>"+drv["ClassName"].ToString()+"</span>";
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString());
				tn.NavigateUrl = "Switch.aspx?Action=1&ClassID="+drv["ClassID"].ToString();
				tn.Target      = "MainFrame";
				TNC.Add(tn);
				InitTreeChildNode(tn.Nodes,tn.ID);
			}
		}	
		
		#region 获取节点图标
		/// <summary>
		/// 获取节点图标
		/// </summary>
		private string GetIcon(string ClassType)
		{
			string rtnValue = "../../DataImages/";
			switch (ClassType)
			{
				case "0":
					rtnValue+= "flag.gif" ;
					break;
				case "1":
					rtnValue+= "myDoc.gif" ;
					break;
				case "2":
					rtnValue+= "mail.gif" ;
					break;
				case "3":
					rtnValue+= "page.gif" ;
					break;
				case "4":
					rtnValue+= "staff.gif" ;
					break;
				case "5":
					rtnValue+= "help_page.gif" ;
					break;
				case "6":
					rtnValue+= "MyTask.gif";
					break;
				case "7":
					rtnValue+= "mail.gif" ;
					break;
				case "8":
					rtnValue+= "myDoc.gif" ;
					break;
				case "9":
					rtnValue+= "DocFlow.gif" ;
					break;
				case "10":
					rtnValue+= "ClientManage.gif" ;
					break;
				case "11":
					rtnValue+= "myLinkman.gif" ;
					break;
				case "12":
					rtnValue+= "position.gif" ;
					break;
				case "13":
					rtnValue+= "roleManage.gif" ;
					break;
                case "50":
                    rtnValue += "board.gif";
                    break;
                case "55":
                    rtnValue += "myDoc.gif";
                    break;
				case "14":
					rtnValue+= "kaoqin.gif" ;
					break;
				case "15":
					rtnValue+= "workadmin.gif" ;
					break;
				case "16":
					rtnValue+= "message.gif" ;
					break;
                case "17":
					rtnValue+= "usbkey.gif" ;
					break;

                case "52":
                    rtnValue += "t1.jpg";
                    break;
                case "57": //办公环境监控
                    rtnValue += "t2.jpg";
                    break;

                case "58": //计划总结
                    rtnValue += "t3.jpg";
                    break;

                case "59": //资源预定
                    rtnValue += "t4.jpg";
                    break;

                case "60": //设备管理
                    rtnValue += "t5.jpg";
                    break;

				default: 
					rtnValue+= "red_ball.gif";
					break;
			}
			return rtnValue;
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
		
		///		设计器支持所需的方法 - 不要使用
		///		代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
