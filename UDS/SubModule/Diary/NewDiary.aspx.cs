using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
  
using System.Data.SqlClient; 
using UDS.Components;
 

namespace UDS.SubModule.Diary
{
    public partial class NewDiary : System.Web.UI.Page
    {

        public int ReturnPage = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["ID"] != null)
                {
                    ActiveRecord.Model.Diary diary = new ActiveRecord.Model.Diary();
                    diary = ActiveRecord.Model.Diary.Find(int.Parse(Request.QueryString["ID"]));
                    this.FCKeditor2.Visible = false;
                     
                    txtContents.Visible = true;
                    txtContents.Text = diary.Contents;
                }
                else
                {
                    FCKeditor2.Visible = true;
                    txtContents.Visible = false;
                }
            }

            if (Request.QueryString["ReturnPage"] != null)
            {
                ReturnPage = Int32.Parse(Request.QueryString["ReturnPage"].ToString());
            }
            else
                ReturnPage = 0;
        }


        //private void cmdSubmit_Click(object sender, System.EventArgs e)
        //{

        //    string strContents = this.txtContents.Text;

        //    //获取登录用户ID
        //    string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);
        //    string username = Server.UrlDecode(Request.Cookies["UserName"].Value);

        //    ActiveRecord.Model.Diary diary = new ActiveRecord.Model.Diary();
        //    diary.Contents = strContents;
        //    diary.UserID = int.Parse(strUserid);
        //    diary.UserName = username;
        //    diary.SubmitDate = DateTime.Now;
        //    diary.Save();

        //    Page.RegisterStartupScript("", "<script>alert('添加成功！');</script>");

        //    //if (Request.QueryString["ID"] != null)
        //    //{
        //    //    string strID = Request.QueryString["ID"].ToString();
        //    //    object[] Params = new object[] { null, strID, strContents };

        //    //    string strReturn = NoteObject.UpdateNote(Params);

        //    //    if (strReturn == "0")
        //    //    {
        //    //        Page.RegisterStartupScript("", "<script>alert('修改失败！');</script>");
        //    //    }
        //    //    else
        //    //    {
        //    //        Page.RegisterStartupScript("", "<script>alert('修改成功！');</script>");
        //    //    }
        //    //}
        //    //else
        //    //{
        //        //object[] Params = new object[] { null, strContents, strUserid };

        //        //string strReturn = NoteObject.InsertNote(Params);

        //        //if (strReturn == "0")
        //        //{
        //        //    Page.RegisterStartupScript("", "<script>alert('添加失败！');</script>");
        //        //}
        //        //else
        //        //{
        //        //    Page.RegisterStartupScript("", "<script>alert('添加成功！');</script>");
        //        //}
        //    //}
        //}

        protected void cmdSubmit_Click1(object sender, EventArgs e)
        {
            string strContents = this.FCKeditor2.Value;

            //获取登录用户ID
            string strUserid = Server.UrlDecode(Request.Cookies["UserID"].Value);
            string username = Server.UrlDecode(Request.Cookies["UserName"].Value);

            ActiveRecord.Model.Diary diary = new ActiveRecord.Model.Diary();
            diary.Contents = strContents;
            diary.UserID = int.Parse(strUserid);
            diary.UserName = username;
            diary.SubmitDate = DateTime.Now;
            diary.Save();

         //   Page.RegisterStartupScript("", "<script>setFCKeditorReadOnly(FCKeditor2); </script>");
            Page.RegisterStartupScript("", "<script>alert('添加成功！');location.href='DiaryManage.aspx?DisplayType=0';</script>");
        }
    }
}
