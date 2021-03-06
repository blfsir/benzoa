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
using UDS.Components;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace UDS.SubModule.Staff
{
	/// <summary>
	/// ManageStaff 的摘要说明。
	/// </summary>
	public class ManageStaff : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lbOnline;
		protected System.Web.UI.WebControls.LinkButton lbOffLine;
		protected System.Web.UI.WebControls.DataGrid dbStaffList;
		protected System.Web.UI.WebControls.Button cmdNewStaff;
		protected System.Web.UI.WebControls.Button cmdDimission;
		protected System.Web.UI.WebControls.Button cmdRehab;
		//	protected System.Web.UI.WebControls.Button cmdChangeposition;
		protected System.Web.UI.WebControls.Button cmdChangePosition;
		protected System.Web.UI.WebControls.Button btn_Search;
		public int DisplayType;
		protected System.Web.UI.WebControls.CheckBox cbRemind;

        protected System.Web.UI.WebControls.CheckBoxList cblDisplayColumn;
        protected System.Web.UI.WebControls.LinkButton lbtn_SelectField;

        protected string selectColumnID = "";
		protected static string Username;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(Request.QueryString["DisplayType"]!=null)
			{
				if(Request.QueryString["DisplayType"].ToString()!="")
					DisplayType = Int32.Parse(Request.QueryString["DisplayType"].ToString());
				else
					DisplayType = 0;
			}
			else
				DisplayType = 0;

            if (Request.QueryString["dc"] != null)
            {
                if (Request.QueryString["dc"].ToString() != "")
                {
                    ViewState["displayColumn"] = Request.QueryString["dc"].ToString();

                    for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
                    {
                        cblDisplayColumn.Items[i].Selected = false;
                    }
                    string[] dc = ViewState["displayColumn"].ToString().TrimEnd(',').Split(',');
                    for (int i = 0; i < dc.Length; i++)
                    {
                        cblDisplayColumn.Items[int.Parse(dc[i])].Selected = true;
                    }

                }
            }
            //else
            //{
            //    ViewState["displayColumn"] = ReadFromXml();

            //    for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
            //    {
            //        cblDisplayColumn.Items[i].Selected = false;
            //    }
            //    string[] dc = ViewState["displayColumn"].ToString().TrimEnd(',').Split(',');
            //    for (int i = 0; i < dc.Length; i++)
            //    {
            //        cblDisplayColumn.Items[int.Parse(dc[i])].Selected = true;
            //    }
            //}

			if(!Page.IsPostBack)
			{
				//操作者登录名
				HttpCookie UserCookie = Request.Cookies["Username"];
                Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

                string displayColumns = ReadFromXml();
                if (displayColumns.Length > 0)
                {
                    ViewState["displayColumn"] = displayColumns;

                    for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
                    {
                        cblDisplayColumn.Items[i].Selected = false;
                    }
                    string[] dc = ViewState["displayColumn"].ToString().TrimEnd(',').Split(',');
                    for (int i = 0; i < dc.Length; i++)
                    {
                        cblDisplayColumn.Items[int.Parse(dc[i])].Selected = true;
                    }
                }

				BindGrid();
			}

			cmdRehab.Attributes.Add("OnClick","return confirm('是否复职？');");
			cmdDimission.Attributes.Add("OnClick","return confirm('是否离职？');");
			cmdChangePosition.Attributes.Add("OnClick","return confirm('是否调职？');");
		}

        private string ReadFromXml()
        {
            string columns = "";

              
            string userName = Server.UrlDecode(Request.Cookies["UserName"].Value);
            string xmlFile = Server.MapPath("XML_DisplayColumns.xml");

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFile);
                XmlNode root = xmlDoc.SelectSingleNode("SetDisplayColumns");//查找<bookstore>

                //1.查找是否有相同节点，如有，则更新。并设定flag

                XmlNodeList nodeList = root.ChildNodes;//获取bookstore节点的所有子节点
                foreach (XmlNode xn in nodeList)//遍历所有子节点
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                    if (xe.GetAttribute("name") == userName)//如果genre属性值为“李赞红”
                    {
                        columns = xe.GetAttribute("columns");
                        break;
                    }
                }
            }
            catch (Exception ex)
            { }
           
            return columns;
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
			this.lbOnline.Click += new System.EventHandler(this.lbOnline_Click);
			this.lbOffLine.Click += new System.EventHandler(this.lbOffLine_Click);
			this.cmdNewStaff.Click += new System.EventHandler(this.cmdNewStaff_Click);
			this.cmdDimission.Click += new System.EventHandler(this.cmdDimission_Click);
			this.cmdRehab.Click += new System.EventHandler(this.cmdRehab_Click);
			this.cmdChangePosition.Click += new System.EventHandler(this.cmdChangePosition_Click);
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public string GetSelectImage(string NormalImg,string SelectedImg,int selected,int position)
		{
			if(selected==position)
				return SelectedImg;
			else
				return NormalImg;
		}
		private void BindGrid()
		{
			SqlDataReader dr=null; //存放人物的数据
			Database db = new Database();
            try
            {
                SqlParameter[] prams = {
									   db.MakeInParam("@StaffType",SqlDbType.Bit,1,DisplayType)
								   };
                db.RunProc("sp_GetAllStaff", prams, out dr);
                DataTable dt = Tools.ConvertDataReaderToDataTable(dr);

                if (ViewState["sortfield"] != null)
                    dt.DefaultView.Sort = ViewState["sortfield"] + " " + ViewState["sortdirect"];

                dbStaffList.DataSource = dt.DefaultView;
                for (int j = 1; j < dbStaffList.Columns.Count; j++)
                {
                    dbStaffList.Columns[j].Visible = false;
                }
                if (ViewState["displayColumn"] != null)
                {
                    string[] dc = ViewState["displayColumn"].ToString().TrimEnd(',').Split(',');
                    for (int i = 0; i < dc.Length; i++)
                    {
                        dbStaffList.Columns[int.Parse(dc[i])+1].Visible = true;
                    }

                }
                else
                {
                    for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
                    {
                         dbStaffList.Columns[i+1].Visible = cblDisplayColumn.Items[i].Selected;
                    }
                }
                //for (int i = 0; i < cblDisplayColumn.Items.Count; i++)
                //{
                //    dbStaffList.Columns[i+1].Visible = cblDisplayColumn.Items[i].Selected;
                //}
               
                dbStaffList.DataBind();
                //cblDisplayColumn.SelectedValue 
                //dbStaffList.Columns[1].Visible=cbRemind.Checked;
                if (DisplayType == 0)
                {
                    //				lbOnline.BackColor = Color.FromArgb(0xCCCCCC);
                    //				lbOffLine.BackColor =Color.FromArgb(0xFFFFFF);
                    cmdRehab.Visible = false;
                    cmdDimission.Visible = true;
                    cmdChangePosition.Visible = true;
                }
                else
                {
                    //				lbOnline.BackColor =Color.FromArgb(0xFFFFFF);
                    //				lbOffLine.BackColor =Color.FromArgb(0xCCCCCC);
                    cmdRehab.Visible = true;
                    cmdDimission.Visible = false;
                    cmdChangePosition.Visible = false;

                }
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
		#region 翻页事件
		public void DataGrid_PageChanged(object sender,DataGridPageChangedEventArgs e)
		{
			dbStaffList.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		#endregion
		private void lbOnline_Click(object sender, System.EventArgs e)
		{
            if (ViewState["displayColumn"] != null)
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=0&dc=" + ViewState["displayColumn"].ToString());
            }
            else
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=0");
            }
		}

		private void lbOffLine_Click(object sender, System.EventArgs e)
		{
            if (ViewState["displayColumn"] != null)
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=1&dc=" + ViewState["displayColumn"].ToString());
            }
            else
            {
                Server.Transfer("ManageStaff.aspx?DisplayType=1");
            }

           
		}

		private void dbStaffList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		private string GetSelectedItemID(string controlID)
		{
			string selectedID;
			selectedID = "";
			//遍历DataGrid获得checked的ID
			foreach (DataGridItem item in dbStaffList.Items)
			{
				if(((CheckBox)item.FindControl(controlID)).Checked==true )
					selectedID += dbStaffList.DataKeys[item.ItemIndex] + ",";
			}
			if(selectedID.Length>0)
				selectedID=selectedID.Substring(0,selectedID.Length-1);
			return selectedID;
		}


		private void cmdNewStaff_Click(object sender, System.EventArgs e)
		{
			Server.Transfer("../Position/NewStaff.aspx?ReturnPage=1");
		}


		//离职,复职通知
		private void sms_all(int i)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			SqlDataReader dr_this=null;//被选择人员
			UDS.Components.Staff sta=new UDS.Components.Staff();
			dr_this=sta.GetStaffInfo(strStaffID);
			SMS sm = new SMS();
			//处理短信提醒
            try
            {
                while (dr_this.Read())
                {
                    string Position_name = dr_this["Position_name"].ToString();
                    SqlDataReader dr_isok;//所有在职人员
                    dr_isok = sta.GetAllStaffs();
                    try
                    {
                        while (dr_isok.Read())
                        {
                            string Staff_name = dr_isok["Staff_name"].ToString();
                            if (i == 0)
                                sm.SendMsg(Username, Staff_name, Position_name + " 处员工:" + dr_this["RealName"].ToString() + ",已经离职,特此通知.", 1, DateTime.Now, "", 0, 0);
                            else
                                sm.SendMsg(Username, dr_isok["Staff_name"].ToString(), dr_this["Position_name"].ToString() + " 处员工:" + dr_this["RealName"].ToString() + ",已经恢复原职,特此通知.", 1, DateTime.Now, "", 0, 0);
                        }
                    }
                    finally
                    {
                        dr_isok.Close();
                        dr_isok = null;
                    }
                }
                sm = null;
            }
            finally
            {
                dr_this.Close();
                dr_this = null;
            }
		}

		private void cmdDimission_Click(object sender, System.EventArgs e)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			if(strStaffID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.Dimission(strStaffID)==true)
				{
					if(this.cbRemind.Checked==true)
						sms_all(0);
					//Response.Write("<script language=javascript>alert('离职成功！');</script>");		
					BindGrid();
				}
				person = null;

			}
			else
				Response.Write("<script language=javascript>alert('请选择要离职的人员！');</script>");		
		
		}

		private void cmdRehab_Click(object sender, System.EventArgs e)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			if(strStaffID!="")
			{
				UDS.Components.Staff person = new UDS.Components.Staff();	
				if(person.Rehab(strStaffID)==true)
				{
					if(this.cbRemind.Checked==true)
						sms_all(1);
					//Response.Write("<script language=javascript>alert('复职成功！');</script>");		
					BindGrid();
				}
				person = null;				
			}
			else
				Response.Write("<script language=javascript>alert('请选择要复职的人员！');</script>");		
		}

		private void cmdChangePosition_Click(object sender, System.EventArgs e)
		{
			string strStaffID=this.GetSelectedItemID("chkStaff_ID");
			if(strStaffID.Trim()!="")
				Response.Redirect("../Position/ChangePosition.aspx?StaffIDS="+strStaffID + "&ReturnPage=1");
			else
				//Response.Write("<script language=javascript>alert('请选择要调职的人员！');</script>");		
				Page.RegisterStartupScript("window","<script language=javascript>alert('请选择要调职的人员！');</script>"); 
		
		}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Sch/Search.aspx");
		}

        protected void lbtn_SelectField_Click(object sender, EventArgs e)
        {
            cblDisplayColumn.Visible = !cblDisplayColumn.Visible;
            if (cblDisplayColumn.Visible == true)
            {
                lbtn_SelectField.Text = "选择显示字段<<<";
                this.dbStaffList.Visible = false;
            }
            else
            {
                lbtn_SelectField.Text = "选择显示字段>>>";
                this.dbStaffList.Visible = true;
            }
        }

        protected void cblDisplayColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListItem li in cblDisplayColumn.Items)
            {
                if (li.Selected == true)
                { 
                    sb.Append(li.Value).Append(',');
                }
            }
            ViewState["displayColumn"] = sb.ToString();
            WriteToXml(sb.ToString());//将当前用用户设置的列存入xml文件中
            BindGrid();
        }

        private void WriteToXml(string p)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("bookstore.xml");
            //XmlNode root = xmlDoc.SelectSingleNode("bookstore");//查找<bookstore>
            //XmlElement xe1 = xmlDoc.CreateElement("book");//创建一个<book>节点
            //xe1.SetAttribute("genre", "李赞红");//设置该节点genre属性
            //xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性
            //root.AppendChild(xe1);//添加到<bookstore>节点中
            //xmlDoc.Save("bookstore.xml");

            bool flag = true;
            string userName = Server.UrlDecode(Request.Cookies["UserName"].Value);
            string xmlFile = Server.MapPath("XML_DisplayColumns.xml");

            try
            { 
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load( xmlFile);
                XmlNode root = xmlDoc.SelectSingleNode("SetDisplayColumns");//查找<bookstore>

                //1.查找是否有相同节点，如有，则更新。并设定flag
               
                XmlNodeList nodeList = root.ChildNodes;//获取bookstore节点的所有子节点
                foreach (XmlNode xn in nodeList)//遍历所有子节点
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                    if (xe.GetAttribute("name") == userName)//如果genre属性值为“李赞红”
                    {
                        xe.SetAttribute("columns", p);//则修改该属性为“update李赞红”
                         
                        flag = false;
                        break;
                    }
                }
                //2.如果flag=false,则新增节点
                xmlDoc.Save(xmlFile); //xmlDoc.Save("bookstore.xml");//保存。

                if (flag)
                {
                    XmlElement xe1 = xmlDoc.CreateElement("Staff");//创建一个<book>节点
                    xe1.SetAttribute("name", userName);//设置该节点genre属性
                    xe1.SetAttribute("columns", p);//设置该节点ISBN属性
                    root.AppendChild(xe1);//添加到<bookstore>节点中
                    xmlDoc.Save(xmlFile);
                }

                //// 创建XmlTextWriter类的实例对象
                //XmlTextWriter textWriter = new XmlTextWriter(Server.MapPath("XML_DisplayColumns.xml"),null);
                //textWriter.Formatting = Formatting.Indented;

                //// 开始写过程，调用WriteStartDocument方法
                //textWriter.WriteStartDocument();

                //// 写入说明
                //textWriter.WriteComment("First Comment XmlTextWriter Sample Example");
                //textWriter.WriteComment("w3sky.xml in root dir");

                ////创建一个节点
                //textWriter.WriteStartElement("SetDisplayColumns");
                //textWriter.WriteElementString("Name", Server.UrlDecode(Request.Cookies["UserName"].Value));
                //textWriter.WriteElementString("Columns", Server.UrlDecode(Request.Cookies["UserName"].Value));
                //textWriter.WriteEndElement();

                //// 写文档结束，调用WriteEndDocument方法
                //textWriter.WriteEndDocument();

                //// 关闭textWriter
                //textWriter.Close();
            }
            catch (System.Exception e)
            {
                Response.Write("<script language=javascript>alert('写入xml文件出错，请重试！');</script>"); //Console.WriteLine(e.ToString());
            }
        }

        protected void dbStaffList_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (ViewState["sortfield"] == null)
            {
                ViewState["sortfield"] = e.SortExpression;
                ViewState["sortdirect"] = "ASC";
            }
            else
            {
                if (ViewState["sortfield"].ToString() == e.SortExpression)
                {
                    ViewState["sortdirect"] = (ViewState["sortdirect"].ToString() == "ASC" ? "DESC" : "ASC");
                }
                else
                {
                    ViewState["sortfield"] = e.SortExpression;
                    ViewState["sortdirect"] = "ASC";
                }
            }

            foreach (DataGridColumn col in dbStaffList.Columns)
            {
                if (col.SortExpression.ToString() == ViewState["sortfield"].ToString())
                {
                    if (ViewState["sortdirect"].ToString() == "ASC")
                    {
                        col.HeaderText += "<img src='../../images/asc.gif' border=0/>";
                        col.HeaderText = col.HeaderText.Remove(col.HeaderText.IndexOf('<'));
                        col.HeaderText += "<img src='../../images/asc.gif' border=0/>";
                    }
                    else
                    {
                        col.HeaderText += "<img src='../../images/desc.gif' border=0/>";
                        col.HeaderText = col.HeaderText.Remove(col.HeaderText.IndexOf('<'));
                        col.HeaderText += "<img src='../../images/desc.gif' border=0/>";
                    }
                }
                else
                {
                    col.HeaderText += "<img src='../../images/desc.gif' border=0/>";
                    col.HeaderText = col.HeaderText.Remove(col.HeaderText.IndexOf('<'));
                    
                }
            }
            BindGrid();
        }
	}
}
