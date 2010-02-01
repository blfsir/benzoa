using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace DAL
{
    public class DBParameterInfo
    {
        public DBParameterInfo(string name, object value, DbType dbType, ParameterDirection direction, int size)
        {
            m_Name = name;
            m_Value = value;
            m_DbType = dbType;
            m_Direction = direction;
            m_Size = size;
        }

        /// <summary>
        /// 默认为 output
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        public DBParameterInfo(string name, DbType dbType, int size)
            : this(name, null, dbType, ParameterDirection.Output, size)
        { }

        /// <summary>
        /// 默认为input
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        public DBParameterInfo(string name, object value, DbType dbType)
            : this(name, value, dbType, ParameterDirection.Input, 0)
        { }

        public DBParameterInfo(string name)
            : this(name, null, DbType.String, ParameterDirection.Input, int.MaxValue)
        { }

        private DbType m_DbType;

        public DbType DbType
        {
            get { return m_DbType; }
            set { m_DbType = value; }
        }

        private int m_Size;

        public int Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }

        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private object m_Value;

        public object Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        private ParameterDirection m_Direction;

        public ParameterDirection Direction
        {
            get { return m_Direction; }
            set { m_Direction = value; }
        }

    }


    public class DALBase
    {
        public const string DATABASENAME = "uds";
        public const string BLOGDATABASW = "BLOG";


        /// <summary>
        /// 封装、记录异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>返回处理是否成功</returns>
        protected bool HandleException(Exception ex)
        {
            return true;
        }

        /// <summary>
        /// 通过存储过程从数据库中查询一张表记录
        /// </summary>
        /// <param name="parameterValue">存储过程参数</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <returns></returns>
        protected DataTable GetDataTableFromDatabase(object[] parameterValue, string storedProcedureName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName, parameterValue);
                dbCommand.CommandTimeout = 1000;
                return db.ExecuteDataSet(dbCommand).Tables[0];
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }

                return null;
            }
        }

        /// <summary>
        /// 通过存储过程从数据库中查询一张表记录
        /// </summary>
        /// <param name="parameterValue">存储过程参数</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="databaseName">连接字符串</param>
        /// <returns></returns>
        protected DataTable GetDataTableFromDatabase(object[] parameterValue, string storedProcedureName, string databaseName, string staticFlag)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(databaseName);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName, parameterValue);

                return db.ExecuteDataSet(dbCommand).Tables[0];
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }

                return null;
            }
        }

        /// <summary>
        /// 通过查询命令SQL从数据库中查询一张表记录
        /// </summary>
        /// <param name="paramterName">参数名称数组</param>
        /// <param name="paramterValue">参数值数组</param>
        /// <param name="commandText">查询SQL语句</param>
        /// <param name="database">将要查询的数据库别名</param>
        /// <returns></returns>
        protected DataTable GetDataTableFromDatabase(object[] paramterName, object[] paramterValue, string commandText, string database)
        {
            string databaseName = string.Empty;
            try
            {
                switch (database)
                {
                    case "NEMP": databaseName = DATABASENAME;
                        break;
                    case "BLOG": databaseName = BLOGDATABASW;
                        break;
                    default:
                        databaseName = DATABASENAME;
                        break;
                }

                Database db = DatabaseFactory.CreateDatabase(databaseName);

                DbCommand dbCommand = db.GetSqlStringCommand(commandText);

                for (int i = 0; i < paramterValue.Length; i++)
                {
                    SqlParameter param = new SqlParameter(paramterName[i].ToString(), paramterValue[i].ToString());

                    dbCommand.Parameters.Add(param);
                }

                return db.ExecuteDataSet(dbCommand).Tables[0];

            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }

                return null;
            }
        }




        //--  添加GetDataTableFromDatabase

        /// <summary>
        /// 通过存储过程从数据库中查询一张表记录
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <returns></returns>
        protected DataTable GetDataTableFromDatabaseByPage(string storedProcedureName, out int rowCount, int pagesize, int startPage, params DBParameterInfo[] dbParams)
        {
            try
            {
                DBParameterInfo dbparamRowCount = new DBParameterInfo("RowsCount", DbType.Int32, 8);
                int paramCount = 3;
                if (dbParams != null)
                {
                    paramCount += dbParams.Length;
                }
                DBParameterInfo[] pageParams = new DBParameterInfo[paramCount];
                if (dbParams != null)
                {
                    dbParams.CopyTo(pageParams, 0);
                }
                pageParams[paramCount - 3] = new DBParameterInfo("startPage", startPage, DbType.Int32);
                pageParams[paramCount - 2] = new DBParameterInfo("PageSize", pagesize, DbType.Int32);
                pageParams[paramCount - 1] = dbparamRowCount;
                DataTable dt = GetDataTableFromDatabaseByDBParameterInfo(storedProcedureName, pageParams);
                rowCount = (int)dbparamRowCount.Value;
                return dt;
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
                rowCount = -1;
                return null;
            }
        }

        /// <summary>
        /// 通过存储过程从数据库中查询一张表记录
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <returns></returns>
        protected DataTable GetDataTableFromDatabaseByDBParameterInfo(string storedProcedureName, params DBParameterInfo[] dbParams)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName);
                IList<DBParameterInfo> outPutList = null;
                if (dbParams != null)
                {
                    foreach (DBParameterInfo pi in dbParams)
                    {
                        switch (pi.Direction)
                        {
                            case ParameterDirection.Input:
                                db.AddInParameter(dbCommand, pi.Name, pi.DbType, pi.Value);
                                break;
                            case ParameterDirection.InputOutput:
                                throw new NotSupportedException("DBParameterInfo.Direction不支持的参数类型 InputOutput");
                                break;
                            case ParameterDirection.Output:
                                if (outPutList == null)
                                {
                                    outPutList = new List<DBParameterInfo>();
                                }
                                outPutList.Add(pi);
                                db.AddOutParameter(dbCommand, pi.Name, pi.DbType, pi.Size);
                                break;
                            case ParameterDirection.ReturnValue:
                                throw new NotSupportedException("DBParameterInfo.Direction不支持的参数类型 ReturnValue");
                                break;
                            default:
                                break;
                        }
                    }
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                if (outPutList != null)
                {
                    foreach (DBParameterInfo pi in outPutList)
                    {
                        pi.Value = dbCommand.Parameters[db.BuildParameterName(pi.Name)].Value;
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
                return null;
            }
        }

        //-- GetDataTableFromDatabase end








        /// <summary>
        /// 通过存储过程从数据库中查询一张表记录
        /// </summary>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <returns></returns>
        protected DataTable GetDataTableFromDatabase(string storedProcedureName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName);

                return db.ExecuteDataSet(dbCommand).Tables[0];
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }

                return null;
            }
        }

        /// <summary>
        /// 通过存储过程从数据库中查询一张表记录
        /// </summary>
        /// <param name="ds">查询结果集</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>

        protected DataSet GetDataTableFromDatabase(DataSet ds, string storedProcedureName, string tableName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName);
                ds = db.ExecuteDataSet(dbCommand);
                ds.Tables[0].TableName = tableName;
                return ds;
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
                return null;
            }
        }

        /// <summary>
        /// 通过存储过程从数据库中查询一组表记录
        /// </summary>
        /// <param name="parameterValue">存储过程参数</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <returns></returns>
        protected DataSet GetDataSetFromDatabase(object[] parameterValue, string storedProcedureName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName, parameterValue);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }

                return null;
            }
        }



        /// <summary>
        /// 执行一个存储过程，输出字符串参数
        /// </summary>
        /// <param name="parameterValue">存储过程参数</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="outParameterName">存储过程输出参数名称</param>
        /// <returns></returns>
        protected string ExecuteStoredProcedure(object[] parameterValue, string storedProcedureName, string outParameterName)
        {
            string outParameter = string.Empty;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName, parameterValue);

                db.ExecuteNonQuery(dbCommand);

                outParameter = db.GetParameterValue(dbCommand, outParameterName).ToString();
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
            }
            return outParameter;
        }

        /// <summary>
        /// 执行一个存储过程，输出字符串数组参数
        /// </summary>
        /// <param name="paramterValue">存储过程参数</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="outParamterName">存储过程输出参数数组名称</param>
        /// <returns></returns>
        protected string[] ExecuteStoredProcedure(object[] parameterValue, string storedProcedureName, string[] outParameterName)
        {
            string[] outParameter = new string[2];
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName, parameterValue);

                db.ExecuteNonQuery(dbCommand);

                for (int i = 0; i < outParameter.Length; i++)
                {
                    outParameter[i] = db.GetParameterValue(dbCommand, outParameterName[i].ToString()).ToString();
                }
                //outParameter = db.GetParameterValue(dbCommand, outParameterName).ToString();
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
            }
            return outParameter;
        }


        /// <summary>
        /// 执行一个存储过程，输出整型数值
        /// </summary>
        /// <param name="parameterValue">存储过程参数</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <returns></returns>
        protected int ExecuteStoredProcedure(object[] parameterValue, string storedProcedureName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName, parameterValue);

                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
                return 0;
            }

        }

        /// <summary>
        /// 执行多个select查询
        /// </summary>
        /// <param name="sqlstrs">多个查询字符串</param>
        /// <returns>DataSet</returns>
        protected DataSet GetDataSetFromSQLS(string sqlstrs)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                return db.ExecuteDataSet(CommandType.Text, sqlstrs);
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    //Systemlog.log("", "DALBase", "GetDataSetFromSQLS()", ex.ToString());
                    throw;
                }

                return null;
            }
        }


        /// <summary>
        /// 循环执行一个存储过程（带三个参数）
        /// </summary>
        /// <param name="sqlstrs">多个字符串分离</param>
        /// <returns>int</returns>
        protected int DelStoredProcedure(string[] allids, string storedProcedureName)
        {
            int iResult = -1;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName);
                dbCommand.CommandTimeout = 6000;
                db.AddInParameter(dbCommand, "@ResourceId", DbType.Int32);
                db.AddInParameter(dbCommand, "@CourseId", DbType.Int32);
                db.AddInParameter(dbCommand, "@SubjectId", DbType.Int32);
                for (int i = 0; i < allids.Length; i++)
                {
                    string[] splitids = allids[i].Split('^');
                    dbCommand.Parameters[0].Value = splitids[0];
                    dbCommand.Parameters[1].Value = splitids[1];
                    dbCommand.Parameters[2].Value = splitids[2];////
                    //db.AddInParameter(dbCommand, "@ResourceId", DbType.Int32, int.Parse(resourceids[i]));
                    //db.AddInParameter(dbCommand, "@CourseId", DbType.Int32, int.Parse(courseids[i]));
                    iResult = db.ExecuteNonQuery(dbCommand);


                    //if (iResult != 0)
                    //{
                    //    break;
                    //}
                }

                return iResult;
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    //Systemlog.log("", "DALBase", "GetDataSetFromSQLS()", ex.ToString());
                    throw;
                }

                return -1;
            }

        }

        /*******************************Tracy*************************************/
        /// <summary>
        /// 用事务控制执行两个存储过程
        /// </summary>
        /// <param name="sqlstrs">其中涉及到多个字符串分离</param>
        /// <returns>int</returns>
        protected bool AddCRRange(object[] del, string[] add, string storedProcedureName, string storedProcedureName2)
        {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
            try
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction dbtran = conn.BeginTransaction();
                    try
                    {
                        db.ExecuteNonQuery(dbtran, storedProcedureName, del);
                        for (int i = 0; i < add.Length; i++)
                        {
                            object[] singleRecord = add[i].ToString().Split(',');
                            db.ExecuteNonQuery(dbtran, storedProcedureName2, singleRecord);
                        }

                        dbtran.Commit();
                        result = true;
                    }
                    catch (Exception)
                    {
                        dbtran.Rollback();
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
            }
            return result;
        }
        //************************************fjx******************************//
        /// <summary>
        /// 执行一个存储过程，输出字符串参数
        /// </summary>
        /// <param name="parameterValue">存储过程参数</param>
        /// <param name="storedProcedureName">存储过程名称</param>
        /// <param name="outParameterName">存储过程输出参数名称</param>
        /// <returns></returns>
        protected DataTable ExecuteStoredProcedure1(object[] parameterValue, string storedProcedureName, string outParameterName, out string ReturnVlaue)
        {
            DataTable dt = null;
            ReturnVlaue = string.Empty;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(DATABASENAME);
                DbCommand dbCommand = db.GetStoredProcCommand(storedProcedureName, parameterValue);
                dt = db.ExecuteDataSet(dbCommand).Tables[0];
                // db.ExecuteNonQuery(dbCommand);
                ReturnVlaue = db.GetParameterValue(dbCommand, outParameterName).ToString();
            }
            catch (Exception ex)
            {
                if (this.HandleException(ex))
                {
                    throw;
                }
            }
            return dt;
        }
        //************************************fjx******************************//



        public Database GetDB()
        {
            return DatabaseFactory.CreateDatabase(DATABASENAME);
        }



    }
}
