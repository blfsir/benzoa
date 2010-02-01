using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace UDS.Components
{
    /// <summary>
    /// 接点管理
    /// </summary>
    public class Class
    {
        /// <summary>
        /// 获取接点类型
        /// </summary>
        /// <param name="userName">接点ID</param>
        /// <returns>返回接点类型</returns>
        public string GetClassType(int ClassID)
        {
            string ClassType = null;
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@ClassID",    SqlDbType.Int, 8, ClassID)
								   };
            try
            {
                data.RunProc("sp_GetClass", prams, out dataReader);
                if (dataReader.Read())
                {
                    ClassType = dataReader[3].ToString();
                }
                else
                {
                    ClassType = "";
                }
            }
            finally//关闭db
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }
            }
            return ClassType;
        }




        /// <summary>
        /// 获取接点名字
        /// </summary>
        /// <param name="ClassID">接点ID</param>
        /// <returns>返回接点名字</returns>
        public string GetClassName(int ClassID)
        {
            string ClassName = null;
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@ClassID",    SqlDbType.Int, 8, ClassID)
								   };
            try
            {
                data.RunProc("sp_GetClass", prams, out dataReader);
                if (dataReader.Read())
                {
                    ClassName = dataReader[1].ToString();
                }
                else
                {
                    ClassName = "";
                }
            } finally//关闭db
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                }
            }
            return ClassName;
        }


        /// <summary>
        /// 加目录节点
        /// </summary>
        /// <param name="ClassID">加目录节点</param>
        /// <returns>加目录节点</returns>
        public void AddClass(int ParentID, string ClassName, string ClassRemark, int ClassType, string AddedBy, DateTime AddedDate, int Status)
        {
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@ClassParentID" , SqlDbType.Int, 20, ParentID),
									   data.MakeInParam("@ClassName" , SqlDbType.NVarChar, 20, ClassName),
									   data.MakeInParam("@ClassRemark" , SqlDbType.NVarChar, 400, ClassRemark),
									   data.MakeInParam("@ClassType" , SqlDbType.Int, 1, ClassType),
									   data.MakeInParam("@AddedBy" , SqlDbType.NVarChar, 40, AddedBy),
									   data.MakeInParam("@AddedDate" , SqlDbType.DateTime, 30, AddedDate),
									   data.MakeInParam("@Status" , SqlDbType.Int, 1, Status)
								   };

            try
            {
                data.RunProc("sp_AddTeam", prams);

            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("目录添加出错", ex);
            }
            finally
            {
                if (data != null)
                {
                    data.Close();
                    data.Dispose();
                }
            }


        }


        /// <summary>
        /// 获取某节点详细信息
        /// </summary>
        /// <param name="ClassID">项目ID</param>
        public SqlDataReader GetClassDetail(int ClassID)
        {
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = 
								{
									data.MakeInParam("@ClassID",	SqlDbType.Int, 20 ,ClassID)
								};
            try
            {
                data.RunProc("sp_GetClass", prams, out dataReader);
                return dataReader;
            }

            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                return null;
            }
            //finally
            //{
            //    data.Close();
            //    data.Dispose();
            //    dataReader.Close();
            //    dataReader.Dispose();
            //}

        }

        #region 获取用户相关项目
        /// <summary>
        /// 获取用户相关项目
        /// </summary>
        public SqlDataReader GetDeliverClass(string Username)
        {
            // create data object and params
            SqlDataReader dataReader = null;
            Database data = new Database();
            SqlParameter[] prams = {
									   data.MakeInParam("@UserName",      SqlDbType.NVarChar, 20, Username)
								   };


            try
            {
                // run the stored procedure
                data.RunProc("sp_GetDeliverClass", prams, out dataReader);
                return dataReader;
            }
            catch (Exception ex)
            {
                Error.Log(ex.ToString());
                throw new Exception("获取用户相关项目出错!", ex);
            }
        }
        #endregion


    }
}
