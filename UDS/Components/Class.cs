using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace UDS.Components
{
    /// <summary>
    /// �ӵ����
    /// </summary>
    public class Class
    {
        /// <summary>
        /// ��ȡ�ӵ�����
        /// </summary>
        /// <param name="userName">�ӵ�ID</param>
        /// <returns>���ؽӵ�����</returns>
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
            finally//�ر�db
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
        /// ��ȡ�ӵ�����
        /// </summary>
        /// <param name="ClassID">�ӵ�ID</param>
        /// <returns>���ؽӵ�����</returns>
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
            } finally//�ر�db
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
        /// ��Ŀ¼�ڵ�
        /// </summary>
        /// <param name="ClassID">��Ŀ¼�ڵ�</param>
        /// <returns>��Ŀ¼�ڵ�</returns>
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
                throw new Exception("Ŀ¼��ӳ���", ex);
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
        /// ��ȡĳ�ڵ���ϸ��Ϣ
        /// </summary>
        /// <param name="ClassID">��ĿID</param>
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

        #region ��ȡ�û������Ŀ
        /// <summary>
        /// ��ȡ�û������Ŀ
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
                throw new Exception("��ȡ�û������Ŀ����!", ex);
            }
        }
        #endregion


    }
}
