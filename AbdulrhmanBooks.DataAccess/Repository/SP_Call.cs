using AbdulrhmanBooks.DataAccess.Repository.IRepository;
using AbdulrhmanBookStore.DataAccess.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AbdulrhmanBooks.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedurename, DynamicParameters param = null)
        {
            // Use the existing connection from DbContext
            using (var dbConnection = _db.Database.GetDbConnection())
            {
                dbConnection.Open();
                dbConnection.Execute(procedurename, param, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string procedurename, DynamicParameters param = null)
        {
            // Use the existing connection from DbContext
            using (var dbConnection = _db.Database.GetDbConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<T>(procedurename, param, commandType: CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedurename, DynamicParameters param = null)
        {
            // Use the existing connection from DbContext
            using (var dbConnection = _db.Database.GetDbConnection())
            {
                dbConnection.Open();
                var result = SqlMapper.QueryMultiple(dbConnection, procedurename, param, commandType: CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string procedurename, DynamicParameters param = null)
        {
            // Use the existing connection from DbContext
            using (var dbConnection = _db.Database.GetDbConnection())
            {
                dbConnection.Open();
                var value = dbConnection.Query<T>(procedurename, param, commandType: CommandType.StoredProcedure);
                return value.FirstOrDefault();
            }
        }

        public T Single<T>(string procedurename, DynamicParameters param = null)
        {
            // Use the existing connection from DbContext
            using (var dbConnection = _db.Database.GetDbConnection())
            {
                dbConnection.Open();
                return dbConnection.ExecuteScalar<T>(procedurename, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
