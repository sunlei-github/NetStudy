using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using DapperService.Entity;
using System.Linq;

namespace DapperService
{
    public class DapperHelper
    {
        private const string DB_CONNECTION_STR = @"Data Source=LAPTOP-07H34QK0\SQLEXPRESS;Initial Catalog=Dappar;Integrated Security=True";

        /// <summary>
        /// 用来增加删除修改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool Execute(string sql, object param)
        {
            using (IDbConnection connection = new SqlConnection(DB_CONNECTION_STR))
            {
                return connection.Execute(sql, param) > 0;
            }
        }

        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool ExecuteStoredProcedure(string storedProcedureName, object param)
        {
            using (IDbConnection connection = new SqlConnection(DB_CONNECTION_STR))
            {
                return connection.Execute(storedProcedureName, param,null,null,CommandType.StoredProcedure) > 0;
            }
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> QueryList<T>(string sql, object param = null)
            where T : new()
        {
            using (IDbConnection connection = new SqlConnection(DB_CONNECTION_STR))
            {
                return connection.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static T QueryFirst<T>(string sql, object param = null)
            where T : new()
        {
            using (IDbConnection connection = new SqlConnection(DB_CONNECTION_STR))
            {
                return connection.QueryFirstOrDefault<T>(sql, param);
            }
        }

    }
}
