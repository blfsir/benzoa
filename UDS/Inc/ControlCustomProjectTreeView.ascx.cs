//51-aspx
namespace UDS.Inc
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Microsoft.Web.UI.WebControls;
	using UDS.Components;
	using System.Data.SqlClient;

	/// <summary>
	///		ControlCustomProjectTreeView 的摘要说明。
	/// </summary>
	public class ControlCustomProjectTreeView : System.Web.UI.UserControl
	{
		protected DataTable dataTbl1,dataTbl2;
		protected Microsoft.Web.UI.WebControls.TreeView tv1;

		private string _imagepath = "";
		private bool _displayfunctionnode = true;
		private int _rightcode = 1;
		public string _username = "";

		/// <summary>
		/// 图片路径
		/// </summary>
		public string ImagePath
		{
			get
			{
				return _imagepath;
			}
			set
			{
				_imagepath = value;
			}
		}


		/// <summary>
		/// 显示功能节点
		/// </summary>
		public bool DisplayFunctionNode
		{
			get
			{
				return _displayfunctionnode;
			}
			set
			{
				_displayfunctionnode = value;
			}
		}


		/// <summary>
		/// 浏览权
		/// </summary>
		public int RightCode
		{
			get
			{
				return _rightcode; 
			}
			set
			{
				_rightcode = value;
			}
		}


		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
			}
		}

		public int SelectedClassIndex
		{
			get
			{
				//if(tv1.SelectedNodeIndex!="0")
					return Int32.Parse(tv1.GetNodeFromIndex(tv1.SelectedNodeIndex).ID);
				//else
				//	return 0;
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
		}

		public void Bind()
		{
			InitRootNodeDataTable();
			InitTreeRootNode(tv1.Nodes);
			tv1.ExpandLevel = 1;
		}

		/// <summary>
		/// 初始化 RootNode DataTable
		/// </summary>
		private void InitRootNodeDataTable()
		{
			Database data = new Database();
			SqlDataReader dataReader = null;
			String username = Server.UrlDecode(Request.Cookies["UserName"].Value);
			SqlParameter[] prams = {
									   data.MakeInParam("@UserName",      SqlDbType.VarChar , 20, _username),
									   data.MakeInParam("@RightCode",      SqlDbType.Int , 1, _rightcode),
									   data.MakeInParam("@IncludeFunctionNode",      SqlDbType.Int , 1,(_displayfunctionnode==false)? 0:1)	
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
			dataTbl2.TableName = "TreeView";
		}

		/// <summary>
		/// 初始化TreeView 的 RootNode
		/// </summary>
        private void InitTreeRootNode(Microsoft.Web.UI.WebControls.TreeNodeCollection TNC)
		{
			DataView dataView  = new DataView();
			dataView		   = dataTbl1.Copy().DefaultView;
			dataView.RowFilter = "ClassParentID = ClassID";
			foreach(DataRowView drv in dataView)
			{
                Microsoft.Web.UI.WebControls.TreeNode tn = new Microsoft.Web.UI.WebControls.TreeNode();
				tn.ID		   = drv["ClassID"].ToString();
				tn.Text		   = drv["ClassName"].ToString();
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString(),_imagepath);
				//tn.NavigateUrl = "# onclick='alert('dddd')'";
				//tn.Target      = "self";
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
				tn.Text		   = drv["ClassName"].ToString();
				tn.ImageUrl    = GetIcon(drv["ClassType"].ToString(),_imagepath);
				//tn.NavigateUrl = "#";
				//tn.Target      = "parent";
				TNC.Add(tn);
				InitTreeChildNode(tn.Nodes,tn.ID);
			}
		}	
		
		#region 获取节点图标
		/// <summary>
		/// 获取节点图标
		/// </summary>
		private string GetIcon(string ClassType,string imagepath)
		{
			string rtnValue = imagepath;
			switch (ClassType)
			{
				case "0":
                    rtnValue += "工作管理2.gif";
					break;
				case "1":
                    rtnValue += "文档管理2.gif";
					break;
				case "2":
                    rtnValue += "我的邮件2.gif";
					break;
				case "3":
                    rtnValue += "公司论坛2.gif";
					break;
				case "4":
                    rtnValue += "人员管理2.gif";
					break;
				case "5":
					rtnValue+= "help_page.gif" ;
					break;
				case "6":
                    rtnValue += "我的任务2.gif";
					break;
				case "7":
                    rtnValue += "我的邮件2.gif";
					break;
				case "8":
                    rtnValue += "文档管理2.gif";
					break;
				case "9":
                    rtnValue += "公文流转2.gif";
					break;
				case "10":
					rtnValue+= "ClientManage.gif" ;
					break;
				case "11":
					rtnValue+= "myLinkman.gif" ;
					break;
				case "12":
                    rtnValue += "职位管理2.gif";
					break;
				case "13":
                    rtnValue += "角色管理2.gif";
					break;
				case "14":
                    rtnValue += "考勤管理2.gif";
					break;
                case "50":
                    rtnValue += "公司公告2.gif";
                    break;
                case "55":
                    rtnValue += "文档管理2.gif";
                    break;
                case "52":
                    rtnValue += "新闻中心2.gif"; //新闻中心
                    break;
                case "57": //办公环境监控
                    rtnValue += "办公室环境监控2.gif";
                    break;

                case "58": //计划总结
                    rtnValue += "计划总结2.gif";
                    break;

                case "59": //资源预定
                    rtnValue += "资源预定2.gif";
                    break;

                case "60": //设备管理
                    rtnValue += "设备管理2.gif";
                    break;
				default: 
					rtnValue+= "red_ball.gif";
					break;
			}
			return rtnValue;
		}
		#endregion

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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
