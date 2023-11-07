using AbdulrhmanBooks.DataAccess.Repository.IRepository;
using AbdulrhmanBookStore.DataAccess.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AbdulrhmanBooks.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open(); // Correct the method name
                sqlCon.Execute(procedurename, param, commandType: CommandType.StoredProcedure); // Correct the method name
            }
        }

        public IEnumerable<T> List<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open(); // Correct the method name
                return sqlCon.Query<T>(procedurename, param, commandType: CommandType.StoredProcedure); // Correct the method name
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open(); // Correct the method name
                var result = SqlMapper.QueryMultiple(sqlCon, procedurename, param, commandType: CommandType.StoredProcedure); // Correct the method name
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>()); // Correct the initialization
        }

        public T OneRecord<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open(); // Correct the method name
                var value = sqlCon.Query<T>(procedurename, param, commandType: CommandType.StoredProcedure); // Correct the method name
                return value.FirstOrDefault();
            }
        }

        public T Single<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open(); // Correct the method name
                return sqlCon.ExecuteScalar<T>(procedurename, param, commandType: CommandType.StoredProcedure); // Correct the method name
            }
        }
    }
}
