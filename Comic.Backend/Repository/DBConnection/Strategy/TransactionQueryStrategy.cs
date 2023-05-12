using Comic.Backend.Repository.DBConnection.Strategy.Interface;
using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Comic.Backend.Repository.DBConnection.Strategy
{
    public class TransactionQueryStrategy : QueryStrategy, ITransactionQueryStrategy
    {
        //public TransactionQueryStrategy(IDbConnection dbConnection) : base(dbConnection)
        //{

        //}

        //public TransactionQueryStrategy(IQueryStrategy queryStrategy)
        //   : base(queryStrategy.DbConnection)
        //{
        //    SqlConnectionInstance = queryStrategy.SqlConnectionInstance;
        //    SqlTransactionInstance = queryStrategy.SqlTransactionInstance;
        //}

        public async override Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            return await QueryAsync<T>(sql, CommandType.StoredProcedure);
        }

        public async override Task<IEnumerable<T>> QueryAsync<T>(string sql,
                            CommandType commandType = CommandType.StoredProcedure)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<T>(sql: sql,
                                           commandTimeout: _dbConnection.ConnectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_dbConnection.ConnectionString);
        }

        public async override Task<IEnumerable<T>> QueryAsync<T>(string sql, IParametersQueryStrategy param = null)
        {
            return await QueryAsync<T>(sql, param, CommandType.StoredProcedure);
        }

        public async override Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                        IParametersQueryStrategy param = null,
                                        CommandType commandType = CommandType.StoredProcedure)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<T>(sql: sql,
                                           param: param.Items,
                                           commandTimeout: _dbConnection.ConnectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);
        }

        public async override Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                        IParametersQueryStrategy param = null,
                                        CommandType commandType = CommandType.StoredProcedure,
                                        int connectionTimeout = 30)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<T>(sql: sql,
                                           param: param.Items,
                                           commandTimeout: connectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);
        }


        public async override Task<SqlMapper.GridReader> QueryMultipleAsync(string sql,
                                       IParametersQueryStrategy param = null,
                                       CommandType commandType = CommandType.StoredProcedure)
        {
            return await SqlMapper.QueryMultipleAsync(DbConnection,
                                 sql,
                                 param.Items,
                                 commandType: CommandType.StoredProcedure,
                                 commandTimeout: DbConnection.ConnectionTimeout,
                                 transaction: SqlTransactionInstance);
        }

        public async override Task<SqlMapper.GridReader> QueryMultipleAsync(string sql,
                                      int connectionTimeout,
                                      IParametersQueryStrategy param = null,
                                      CommandType commandType = CommandType.StoredProcedure)
        {
            return await SqlMapper.QueryMultipleAsync(_dbConnection,
                                 sql,
                                 param.Items,
                                 commandType: CommandType.StoredProcedure,
                                 commandTimeout: connectionTimeout,
                                 transaction: SqlTransactionInstance);
        }

        public async override Task<int> ExecuteAsync(string sql, IParametersQueryStrategy param = null)
        {
            return await ExecuteAsync(sql, param, CommandType.StoredProcedure);
        }

        public async override Task<int> ExecuteAsync(string sql,
                                                     IParametersQueryStrategy param = null,
                                                     CommandType commandType = CommandType.StoredProcedure)
        {
            using var conn = GetConnection();
            return await conn.ExecuteAsync(sql: sql,
                                           param: param.Items,
                                           commandTimeout: _dbConnection.ConnectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);
        }

        public async override Task<int> ExecuteAsync(string sql,
                                                     IParametersQueryStrategy param = null,
                                                     CommandType commandType = CommandType.StoredProcedure,
                                                     int connectionTimeout = 30)
        {
            using var conn = GetConnection();
            return await conn.ExecuteAsync(sql: sql,
                                           param: param.Items,
                                           commandTimeout: connectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);
        }



        public async override Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                    Func<TFirst, TSecond, TReturn> map,
                                                    string splitOn = "Id")
        {
            return await GetInstance().QueryAsync<TFirst, TSecond, TReturn>(sql, map, splitOn, commandType: CommandType.StoredProcedure);
        }

        public async override Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TReturn> map,
                                                        string splitOn = "Id",
                                                        CommandType commandType = CommandType.StoredProcedure)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<TFirst, TSecond, TReturn>(sql: sql,
                                           map: map,
                                           splitOn: splitOn,
                                           commandTimeout: _dbConnection.ConnectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);
        }

        public async override Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TReturn> map,
                                                        string splitOn = "Id",
                                                        IParametersQueryStrategy param = null,
                                                        CommandType commandType = CommandType.StoredProcedure)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<TFirst, TSecond, TReturn>(sql: sql,
                                           map: map,
                                           splitOn: splitOn,
                                           param: param.Items,
                                           commandTimeout: _dbConnection.ConnectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);
        }

        public async override Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFour, TReturn>(string sql,
                                                Func<TFirst, TSecond, TThird, TFour, TReturn> map,
                                                string splitOn = "Id",
                                                IParametersQueryStrategy param = null,
                                                CommandType commandType = CommandType.StoredProcedure)
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<TFirst, TSecond, TThird, TFour, TReturn>(sql: sql,
                                           map: map,
                                           splitOn: splitOn,
                                           param: param.Items,
                                           commandTimeout: _dbConnection.ConnectionTimeout,
                                           commandType: commandType,
                                           transaction: SqlTransactionInstance);

        }

    }
}
