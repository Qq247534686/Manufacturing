using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Diagnostics;


namespace DAL
{
    public class D_SQLDBHelper
    {
        private static String str_Conn;
        private SqlConnection sql_Conn;
        private SqlCommand sql_Comm;

        public D_SQLDBHelper()
        {
            str_Conn = ConfigurationManager.ConnectionStrings["EMS_DataBase"].ConnectionString.ToString();
        }
        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>数据是否存在</returns>
        public bool ISRecordsExists(string sql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    try
                    {
                        sql_Conn.Open();
                        int rows = (int)sql_Comm.ExecuteScalar();
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        sql_Conn.Close();
                        return false;
                    }
                }
            }
        }

        public SqlDataReader ReadDataSql(string sql)
        {
            SqlDataReader rd=null;
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                sql_Conn.Open();
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    try
                    {
                        rd = sql_Comm.ExecuteReader();
                    }
                    catch
                    {
                        sql_Conn.Close();
                    }
                }
                sql_Conn.Close();
            }
            return rd;
        }
        /// <summary>
        /// 读取数据库中数据的条数
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>数据的条数</returns>
        public int GetRecordsCount(string sql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    try
                    {
                        sql_Conn.Open();
                        int rows = (int)sql_Comm.ExecuteScalar();
                        return rows;
                    }
                    catch (SqlException e)
                    {
                        sql_Conn.Close();
                        return -1;
                        throw e;
                    }
                }
            }
        }

        public string GetOneWord(string sql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    try
                    {
                        sql_Conn.Open();
                        string word = sql_Comm.ExecuteScalar().ToString();
                        return word;
                    }
                    catch (SqlException e)
                    {
                        sql_Conn.Close();
                        Debug.WriteLine(e.ToString());
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 查找数据放在dataset的一张datatable表里
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>数据datatable表</returns>
        public DataTable GetRecordsTable0(string sql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    sql_Comm.CommandTimeout = 100000;
                    DataSet ds = new DataSet();
                    try
                    {
                        sql_Conn.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(sql_Comm);
                        sda.Fill(ds);
                        sql_Conn.Close();
                        return ds.Tables[0];
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine(e.ToString());
                        return null;
                    }
                }
            }
        }

        public DataSet getDataBySqlQuery(string sql, SqlParameter[] parameters)
        {

            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    try
                    {
                        sql_Conn.Open();
                        sql_Comm.Parameters.AddRange(parameters);
                        sql_Comm.CommandText = sql;
                        SqlDataAdapter sdr = new SqlDataAdapter(sql_Comm);
                        DataSet ds = new DataSet();
                        sdr.Fill(ds);
                        return ds;
                    }
                    catch (SqlException e)
                    {
                        throw e.InnerException;
                    }
                }
            }
        }

        public int excuteQueryReturnValue(string sql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    sql_Conn.Open();

                    Int32 newId = Convert.ToInt32(sql_Comm.ExecuteScalar());

                    sql_Conn.Close();

                    return newId;
                }
            }
        }
        /// <summary>
        /// 对数据的增删改
        /// </summary>
        /// <param name="sql">传入的sql</param>
        /// <returns>成功true失败false</returns>
        public bool OperateOnARecordNonQuery(string sql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    try
                    {
                        sql_Comm.CommandTimeout = 500;
                        sql_Conn.Open();
                        int rows = sql_Comm.ExecuteNonQuery();
                       
                        if (rows > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (SqlException e)
                    {
                        sql_Conn.Close();
                        return false;
                        throw e;
                    }
                }
            }
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="sqlParameters"></param>
       /// <returns></returns>
       public bool OperateOnARecordNonQuery(string sql,SqlParameter[] sqlParameters)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (sql_Comm = new SqlCommand(sql, sql_Conn))
                {
                    try
                    {
                        sql_Comm.CommandTimeout = 500;
                        sql_Conn.Open();
                        sql_Comm.Parameters.AddRange(sqlParameters);
                        int rows = sql_Comm.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (SqlException e)
                    {
                        sql_Conn.Close();
                        return false;
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 利用BulkCopy一次性插入多条记录
        /// </summary>
        /// <param name="lSql">sql语句集合</param>
        public int ExecuteSqlBulk(DataTable sourceDataTable, string targetTableName, SqlBulkCopyColumnMapping[] mapping)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(str_Conn, SqlBulkCopyOptions.FireTriggers))
                {
                    bulkCopy.DestinationTableName = targetTableName;    //服务器上目标表的名称
                    bulkCopy.BatchSize = sourceDataTable.Rows.Count;    //每一批次中的行数
                    int el = 0;
                    try
                    {
                        sql_Conn.Open();
                        if (sourceDataTable != null && sourceDataTable.Rows.Count != 0)
                        {

                            for (int i = 0; i < mapping.Length; i++)
                                bulkCopy.ColumnMappings.Add(mapping[i]);

                            //将提供的数据源中的所有行复制到目标表中

                            bulkCopy.WriteToServer(sourceDataTable);
                        }
                        el = 0;
                        return el;
                    }
                    catch (Exception)
                    {
                        el = -5;
                        return el;
                    }
                    finally
                    {
                        sql_Conn.Close();
                        if (bulkCopy != null)
                        {
                            bulkCopy.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 利用BulkCopy一次性插入多条记录
        /// </summary>
        /// <param name="lSql">sql语句集合</param>
        public string ExecuteSqlBulkstr(DataTable sourceDataTable, string targetTableName, SqlBulkCopyColumnMapping[] mapping)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(str_Conn, SqlBulkCopyOptions.FireTriggers))
                {
                    bulkCopy.DestinationTableName = targetTableName;    //服务器上目标表的名称
                    bulkCopy.BatchSize = sourceDataTable.Rows.Count;    //每一批次中的行数
                    try
                    {
                        sql_Conn.Open();
                        if (sourceDataTable != null && sourceDataTable.Rows.Count != 0)
                        {

                            for (int i = 0; i < mapping.Length; i++)
                                bulkCopy.ColumnMappings.Add(mapping[i]);

                            //将提供的数据源中的所有行复制到目标表中

                            bulkCopy.WriteToServer(sourceDataTable);
                        }
                        return "导入成功！";
                    }
                    catch (Exception ex)
                    {
                        return "导入失败！ 原因：" + ex.ToString();
                    }
                    finally
                    {
                        sql_Conn.Close();
                        if (bulkCopy != null)
                        {
                            bulkCopy.Close();
                        }
                    }
                }
            }
        }


        public DataTable GetDtByListHash(List<Hashtable> lHash)
        {
            try
            {
                DataTable dt = new DataTable();

                if (lHash.Count > 0)
                {
                    foreach (DictionaryEntry h in lHash[0])
                        dt.Columns.Add(new DataColumn(h.Key.ToString(), typeof(string)));
                }

                for (int i = 0; i < lHash.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DictionaryEntry h in lHash[i])
                    {
                        if (dt.Columns.IndexOf(h.Key.ToString()) > -1)
                        {
                            dr[h.Key.ToString()] = h.Value.ToString();
                        }
                        else
                        {

                            dt.Columns.Add(new DataColumn(h.Key.ToString(), typeof(string)));
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlBulkCopyColumnMapping[] GetBulk(DataTable dt)
        {
            try
            {
                SqlBulkCopyColumnMapping[] mapp = new SqlBulkCopyColumnMapping[dt.Columns.Count];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    mapp[j] = new SqlBulkCopyColumnMapping(dt.Columns[j].ColumnName, dt.Columns[j].ColumnName);
                }
                return mapp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 利用事务一次性插入多条记录
        /// </summary>
        /// <param name="lSql">sql语句集合</param>
        public void ExecuteSqlTran(List<string> lSql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                sql_Conn.Open();
                using (sql_Comm = new SqlCommand())
                {
                    sql_Comm.Connection = sql_Conn;
                    SqlTransaction tx = sql_Conn.BeginTransaction();
                    sql_Comm.Transaction = tx;
                    try
                    {
                        for (int i = 0; i < lSql.Count; i++)
                        {
                            if (lSql[i].Trim().Length > 0)
                            {
                                sql_Comm.CommandText = lSql[i];
                                sql_Comm.ExecuteNonQuery();
                            }
                            if ((i + 1) % 1000 == 0)
                            {
                                tx.Commit();
                                tx = sql_Conn.BeginTransaction();
                                sql_Comm.Transaction = tx;
                            }
                            if (i == lSql.Count - 1)
                            {
                                tx.Commit();
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        throw e;
                    }
                }
                sql_Conn.Close();
            }
        }


        /// <summary>
        /// 一次性插入多条记录
        /// </summary>
        /// <param name="lSql">sql语句集合</param>
        public void ExecuteSqlMul(List<string> lSql)
        {
            using (sql_Conn = new SqlConnection(str_Conn))
            {
                sql_Conn.Open();
                using (sql_Comm = new SqlCommand())
                {
                    sql_Comm.Connection = sql_Conn;
                    try
                    {
                        for (int i = 0; i < lSql.Count; i++)
                        {
                            if (lSql[i].Trim().Length > 0)
                            {
                                sql_Comm.CommandText = lSql[i];
                                sql_Comm.ExecuteNonQuery();
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                sql_Conn.Close();
            }
        }



        private static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection con = new SqlConnection(str_Conn);
                return con;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public static DataSet GetDS(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dat = new SqlDataAdapter();

            try
            {
                SqlConnection con = GetConnection();
                dat = new SqlDataAdapter(sql, con);
                dat.Fill(ds);
                return ds;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                ds.Dispose();
                dat.Dispose();
            }
        }

        public static DataRowCollection GetDataRows(string sql)
        {
            try
            {
                return GetDS(sql).Tables[0].Rows;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public static void ExecuteSql(string sql)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                con = GetConnection();
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                con.Dispose();
                cmd.Dispose();
            }
        }


        
    }
}
