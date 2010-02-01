using System;
using System.Text.RegularExpressions;
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

namespace UDS.SubModule.CM
{
	/// <summary>
	/// ClinetLinkmanList 的摘要说明。
	/// </summary>
	public class ClinetLinkmanList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.RadioButtonList rbl_LinkmanList;
		protected System.Web.UI.WebControls.Button btn_OK;

		protected  int clientid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				BindData();
				if(Session["cm_permission"].ToString()=="leader")
				{
					HyperLink1.Visible = false;
					btn_OK.Visible = false;
				}
				else
				{
					HyperLink1.Visible = true;
					btn_OK.Visible = true;
				}
				HyperLink1.NavigateUrl = "Linkman.aspx?ClientID=" + clientid.ToString();
			}
		}

		private void BindData()
		{
			UDS.Components.CM cm = new UDS.Components.CM();
			UDS.Components.ClientInfo client = new UDS.Components.ClientInfo();
			SqlDataReader dr = null;
			clientid = ((Request.Params["clientid"]==null)||(Request.Params["clientid"].ToString().Trim()==""))?0:Int32.Parse(Request.Params["clientid"]);
			if(clientid!=0)
			{
				dr = cm.GetLinkmanFromClient(clientid);
				client = cm.GetClientAllInfo(clientid);
			}
			else //如果没有传入clientid那么检查是否有临时linkman
			{
				string linkmanstring = (Session["tmplinkmanid"]==null)?"0":Session["tmplinkmanid"].ToString();
				if(linkmanstring.EndsWith(","))
					linkmanstring = linkmanstring.Substring(0,linkmanstring.Length-1);
				dr = cm.GetLinkmanByID(linkmanstring);
			}
//			rbl_LinkmanList.DataSource = dr;
//			rbl_LinkmanList.DataTextField = "Name";
//			rbl_LinkmanList.DataValueField = "id";
//			rbl_LinkmanList.DataBind();
            try
            {
                while (dr.Read())
                {
                    ListItem li = new ListItem();
                    if (Session["cm_permission"].ToString() == "administrator")
                        li.Text = "<a href='Linkman.aspx?LinkmanID=" + dr["ID"].ToString() + "'>" + dr["Name"].ToString() + "</a>";
                    else
                        li.Text = dr["Name"].ToString();

                    li.Value = dr["ID"].ToString();
                    rbl_LinkmanList.Items.Add(li);

                }
            }
            finally
            { 
                if (dr != null)
                {

                    dr.Close();
                }
            }
			//如果临时主要联系人存在则让它处于选中状态
			if(Session["tmpchief"]!=null)
			{
				//找到tmpchief的index值并让它处于选中状态
				foreach(ListItem lt in rbl_LinkmanList.Items)
				{
					if(lt.Value == Session["tmpchief"].ToString())
						lt.Selected = true;
				}
			}
			else
			{
				foreach(ListItem lt in rbl_LinkmanList.Items)
				{
					if(lt.Value == client.ChiefLinkmanID.ToString())
						lt.Selected = true;
				}
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
			this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_OK_Click(object sender, System.EventArgs e)
		{
			Session["tmpchief"] = rbl_LinkmanList.SelectedItem.Value;
			UDS.Components.CM cm = new UDS.Components.CM();
			SqlDataReader dr = cm.GetLinkmanByID(rbl_LinkmanList.SelectedItem.Value);
            try
            {
                while (dr.Read())
                {
                    //使用正则表达式分析 <a ....>....</a>得到各个属性值
                    string href = "";
                    string name = "";
                    string linkstring = @rbl_LinkmanList.SelectedItem.Text;
                    string pattern = "href\\s*=\\s*((?<begin>('|\"))(?<href>.*?)\\k<begin>|(?<href>\\S+))(.*?)>(?<name>.*?)</a>";
                    Match match;
                    Regex thereg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    for (match = thereg.Match(linkstring); match.Success; match = match.NextMatch())
                    {
                        href = match.Groups["href"].Value;
                        name = match.Groups["name"].Value;
                    }


                    Response.Write("<script>opener.document.getElementById('hlk_Chiefman').href=\"" + href + "\";opener.document.getElementById('hlk_Chiefman').innerText = \"" + name + "\"</script>");
                    Response.Write("<script>opener.document.getElementById('lbl_position').innerText='" + dr["position"] + "';opener.document.getElementById('lbl_chieftel').innerText='" + dr["telephone"] + "';</script>");
                }
            }
            finally
            {
                
                if (dr != null)
                {

                    dr.Close();
                }
            }
			Response.Write("<script>window.close();</script>");
		}
	}
}
