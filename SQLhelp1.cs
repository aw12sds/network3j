using NetWork.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NetWorkLib
{
    class SQLhelp1
    {
        private static readonly string connStr = "Data Source=10.15.1.252;Initial Catalog=db_ShengChanBu;user id=sa;password=zttZTT123";
        //1.执行增、删、改的方法insert、delete、updata
        //(ExecuteNonQuery())
        public static int ExecuteNonquery(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteNonQuery();

            //    }
            //}
            return getData.innn(sql, "db_ShengChanBu");
        }

        //2、执行查询，返回单个值得方法  执行ExecuteScalar()方法
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            cmd.Parameters.AddRange(pars);
            //        }
            //        cmd.CommandType = type;
            //        conn.Open();
            //        return cmd.ExecuteScalar();
            //    }
            //}
            return getData.ExecuteScalar(sql, "db_ShengChanBu");
        }

        //3、执行查询，返回多个行的方法
        public static SqlDataReader ExecuteReader(string sql, CommandType type, params SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(connStr);

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                try
                {
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    conn.Close();
                    conn.Dispose();
                    throw;//将异常抛上去
                }
            }
        }

        //4、返回查询到的Datatable
        public static DataTable GetDataTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
            //    {
            //        if (pars != null)
            //        {
            //            apter.SelectCommand.Parameters.AddRange(pars);
            //        }
            //        apter.SelectCommand.CommandType = type;
            //        DataTable da = new DataTable();
            //        apter.Fill(da);

            //        return da;
            //    }
            //}
            return getData.getdata(sql, "db_ShengChanBu");
        }

    }
}
