using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Configuration;

namespace UDS.Components
{
    /// <summary>
    /// Project 类
    /// </summary>
    public class ProjectClass
    {

        #region 返回项目相关信息
        /// <summary>
        /// 返回项目相关信息
        /// </summary>
        public SqlDataReader GetClassInfo(int classID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetTeamInfo", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目信息读取出错!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region 返回子项目相关信息
        /// <summary>
        /// 返回子项目相关信息
        /// </summary>
        public SqlDataReader GetSubClassInfo(int classID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@ClassID" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetSubClass", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("子项目信息读取出错!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region 返回某项目下是否存在子项目
        /// <summary>
        /// 返回某项目下是否存在子项目
        /// </summary>
        public bool IsExistSubClass(int classID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@Class_id" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetAllChildClassID", prams, out dataReader);
                if (dataReader.Read())
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("子项目信息读取出错!", ex);
            }
            finally
            {

                if (data != null)
                {
                    data.Close();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region 返回项目成员相关信息
        /// <summary>
        /// 返回项目成员相关信息
        /// </summary>
        public SqlDataReader GetMemberInClass(int classID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@ClassID" , SqlDbType.Int, 20, classID)
								   };

            try
            {
                data.RunProc("sp_GetMemberInClass", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目成员信息读取出错!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region 返回上级项目负责人相关信息
        /// <summary>
        /// 返回上级项目负责人相关信息
        /// </summary>
        public SqlDataReader GetParentLeader(int classID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            int RightCode = 10; //缺省值
            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, classID),
									   data.MakeInParam("@RightCode" , SqlDbType.Int, 20, RightCode)	
								   };

            try
            {
                data.RunProc("sp_GetParentLeader", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目上级负责人信息读取出错!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region 返回项目负责人相关信息
        /// <summary>
        /// 返回项目负责人相关信息
        /// </summary>
        public SqlDataReader GetLeader(int classID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();
            SqlDataReader dataReader = null;
            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, classID)
									};

            try
            {
                data.RunProc("sp_GetLeader", prams, out dataReader);
                return dataReader;

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目负责人信息读取出错!", ex);
            }
            finally
            {
                data = null;
                dataReader = null;
            }

        }
        #endregion

        #region 检测是否有权限访问
        /// <summary>
        /// 检测是否有权限访问
        /// </summary>
        public bool GetAccessPermission(int classID, string UserName, int actID)
        {
            int flag = 0;
            // 定义数据库操作类及DataReader
            Database data = new Database();

            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@Class_ID" , SqlDbType.Int, 20, classID),
									   data.MakeInParam("@UserName" , SqlDbType.NVarChar, 20, UserName),
									   data.MakeInParam("@Act_ID" , SqlDbType.Int, 20, actID),
									  // data.MakeInParam("@Inheit" , SqlDbType.Bit, 1, 1),	
									   data.MakeOutParam("@ReturnValue",SqlDbType.Int,20)
									 };

            try
            {
                data.RunProc("sp_GetAccessPermission", prams);
                flag = Int32.Parse(prams[3].Value.ToString());
                return (flag == 1) ? true : false;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("获取访问权出错", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region 项目移动
        /// <summary>
        /// 项目移动
        /// </summary>
        public void Remove(int souID, int desID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();

            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@FromTeamID" , SqlDbType.Int, 20, souID),
									   data.MakeInParam("@ToTeamID" , SqlDbType.NVarChar, 20, desID)
									  
								   };

            try
            {
                data.RunProc("sp_MoveTeam", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目移动出错", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                }
                 
                data = null;
            }

        }
        #endregion

        #region 项目复制
        /// <summary>
        /// 项目复制
        /// </summary>
        /// <param name="souID">源项目id</param>
        /// <param name="desID">目标项目id</param>
        /// <param name="operatorman">操作者</param>
        public void Copy(int souID, int desID, string operatorman)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();

            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@FromTeamID" , SqlDbType.Int, 20, souID),
									   data.MakeInParam("@ToTeamID" , SqlDbType.NVarChar, 20, desID),
									   data.MakeInParam("@operator" , SqlDbType.VarChar, 50, operatorman)
									  
								   };

            try
            {
                data.RunProc("sp_CopyTeam", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目移动出错", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region 项目添加
        /// <summary>
        /// 项目添加
        /// </summary>
        public void Add(int ParentID, string ProjectName, string ProjectRemark, string Wright, int Status, int Scale, DateTime StartDate, DateTime EndDate)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();

            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@ParentID" , SqlDbType.Int, 20, ParentID),
									   data.MakeInParam("@ProjectName" , SqlDbType.NVarChar, 20, ProjectName.Trim()),
									   data.MakeInParam("@ProjectRemark" , SqlDbType.NVarChar, 400, ProjectRemark.Trim()),
									   data.MakeInParam("@Wright" , SqlDbType.NVarChar, 40, Wright),
									   data.MakeInParam("@Status" , SqlDbType.Int, 40, Status),
									   data.MakeInParam("@Scale" , SqlDbType.Int, 20, Scale),
									   data.MakeInParam("@StartDate" , SqlDbType.DateTime, 30, StartDate),
									   data.MakeInParam("@EndDate" , SqlDbType.DateTime, 30, EndDate)
								   };

            try
            {
                data.RunProc("sp_AddProject", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目添加出错", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region 项目订阅
        /// <summary>
        /// 项目订阅
        /// </summary>
        public void Subscribe(string Username, int ClassID)
        {

            // 定义数据库操作类及DataReader
            Database data = new Database();

            // 执行存储过程，并返回SqlDataReader对象
            SqlParameter[] prams = {
									   data.MakeInParam("@StaffName" , SqlDbType.NVarChar, 50, Username),
									   data.MakeInParam("@ClassID" , SqlDbType.Int, 10, ClassID)
									};

            try
            {
                data.RunProc("sp_SubscibeProject", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("项目订阅出错", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                } 
                data = null;
            }

        }
        #endregion

        #region 获取某项目名称
        /// <summary>
        /// 获取某项目名称
        /// </summary>
        /// <param name="ClassID">项目ID</param>
        public static string GetProjectName(int ClassID)
        {
            string ProjectName = "";
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = 
								{
									data.MakeInParam("@projectid",	SqlDbType.Int, 20 ,ClassID)
								};
            try
            {
                data.RunProc("sp_GetProjectName", prams, out dataReader);
                if (dataReader.Read())
                    ProjectName = dataReader[0].ToString();
                return ProjectName;
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return "";
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

        #region 获取某项目详细信息
        /// <summary>
        /// 获取某项目详细信息
        /// </summary>
        /// <param name="ClassID">项目ID</param>
        public SqlDataReader GetProjectDetail(int ClassID)
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = 
								{
										data.MakeInParam("@TeamID",	SqlDbType.Int, 20 ,ClassID)
								};
            try
            {
                data.RunProc("sp_GetTeamInfo", prams, out dataReader);
                return dataReader;
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }

        }
        #endregion

        #region 修改某项目信息
        /// <summary>
        /// 修改某项目详细信息
        /// </summary>
        /// <param name="ClassID">项目ID</param>
        public void Revise(int ClassID, string ProjectName, string ProjectRemark, int Status, int Scale, DateTime StartDate, DateTime EndDate)
        {

            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@ProjectID" , SqlDbType.Int, 20, ClassID),
									   data.MakeInParam("@ProjectName" , SqlDbType.NVarChar, 20, ProjectName.Trim()),
									   data.MakeInParam("@ProjectRemark" , SqlDbType.NVarChar, 400, ProjectRemark.Trim()),
									   data.MakeInParam("@Status" , SqlDbType.Int, 40, Status),
									   data.MakeInParam("@Scale" , SqlDbType.Int, 20, Scale),
									   data.MakeInParam("@StartDate" , SqlDbType.DateTime, 30, StartDate),
									   data.MakeInParam("@EndDate" , SqlDbType.DateTime, 30, EndDate)
								   };
            try
            {
                data.RunProc("sp_UpdateProject", prams);
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());

            }
            finally
            {
                 if (data != null)
                {
                    data.Close();
                } 
            }
        }
        #endregion

        #region 删除某项目
        /// <summary>
        /// 删除某项目
        /// </summary>
        /// <param name="ClassID">项目ID</param>
        public void Delete(int ClassID)
        {

            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@TeamID" , SqlDbType.Int, 20, ClassID),
								   };
            try
            {
                data.RunProc("sp_DeleteTeam", prams);
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());

            }
            finally
            {
                 if (data != null)
                {
                    data.Close();
                } 
            }

        }
        #endregion

        #region 把字符串年月日后面的时间去除
        /// <summary>
        /// 把字符串年月日后面的时间去除
        /// </summary>
        public static string changeString(string ss)
        {
            string lkk = "";
            for (int i = ss.Length; i > 0; i--)
            {
                char lk = ss[i - 1];
                if (lk == ' ')
                {
                    lkk = ss.Substring(0, i);
                    break;
                }
            }
            return lkk;
        }
        #endregion
    }
}
