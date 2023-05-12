using Comic.Backend.Repository.DBConnection.Strategy.Enum;
using Comic.Backend.Repository.DBConnection.Strategy.Interface;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Comic.Backend.Repository.DBConnection.Strategy
{
    public class QueryStrategy : IQueryStrategy
    {
        public QueryStrategyEnum QueryStrategyEnum { get; set; }

        protected IDbConnection _dbConnection;
        public IDbConnection DbConnection
        {
            get
            {
                return _dbConnection;
            }
            set
            {
                _dbConnection = value;
            }
        }

        public SqlConnection SqlConnectionInstance { get; set; }
        public SqlTransaction SqlTransactionInstance { get; set; }

        public IDirectQueryStrategy Direct { get; set; }
        public ITransactionQueryStrategy Transaction { get; set; }


        //public BaseQueryStrategy(IDbConnection dbConnection)
        //{
        //    _dbConnection = dbConnection;
        //}

        public void SetParameters(IQueryStrategy queryStrategy)
        {
            SqlConnectionInstance = queryStrategy.SqlConnectionInstance;
            SqlTransactionInstance = queryStrategy.SqlTransactionInstance;
        }


        public IQueryStrategy SetSqlConnection(SqlConnection sqlConnection)
        {
            SqlConnectionInstance = sqlConnection;
            return this;
        }

        public IQueryStrategy SetSqlTransaction(SqlTransaction sqlTransaction)
        {
            SqlTransactionInstance = sqlTransaction;
            return this;
        }
        public SqlTransaction BeginTransaction()
        {
            SqlConnectionInstance = ((SqlConnection)_dbConnection);

            var errorMessage = string.Empty;

            switch (SqlConnectionInstance.State)
            {
                case ConnectionState.Broken:
                    errorMessage = "Error: the connection is in the Broken state";
                    break;
                case ConnectionState.Closed:
                    SqlConnectionInstance.Open();
                    break;
                case ConnectionState.Connecting:
                    errorMessage = "Error: the connection is in the Connecting state";
                    break;
                case ConnectionState.Executing:
                    errorMessage = "Error: the connection is in the Executing state";
                    break;
                case ConnectionState.Fetching:
                    errorMessage = "Error: the connection is in the Fetching state";
                    break;
                case ConnectionState.Open:
                    break;
                default:
                    errorMessage = "Unexpected error opening transaction\r\n";
                    break;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new ApplicationException($"[BaseQueryStrategy] BeginTransaction > {errorMessage}");
            }

            var tx = SqlConnectionInstance.BeginTransaction();

            SetSqlTransaction(tx);

            return SqlTransactionInstance;
        }




        public IQueryStrategy GetInstance()
        {

            if (SqlTransactionInstance == null)
            {
                Direct.SetParameters(this);
                return (IQueryStrategy)Direct;
            }

            Transaction.SetParameters(this);
            return (IQueryStrategy)Transaction;
        }

        public virtual Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            return GetInstance().QueryAsync<T>(sql);
        }

        public virtual Task<IEnumerable<T>> QueryAsync<T>(string sql,
                         CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryAsync<T>(sql, commandType);
        }
        public virtual Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                                            CommandType commandType = CommandType.StoredProcedure,
                                                            int connectionTimeout = 30)
        {
            return GetInstance().QueryAsync<T>(sql,
                                               commandType: commandType,
                                               connectionTimeout: connectionTimeout);
        }


        public virtual Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                                          IParametersQueryStrategy param = null)
        {
            return GetInstance().QueryAsync<T>(sql,
                                               param: param);
        }

        public virtual Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                                          IParametersQueryStrategy param = null,
                                                          CommandType commandType = CommandType.StoredProcedure,
                                                          int connectionTimeout = 30)
        {
            return GetInstance().QueryAsync<T>(sql,
                                               param: param,
                                               commandType: commandType,
                                               connectionTimeout: connectionTimeout);
        }

        public virtual Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                                          IParametersQueryStrategy param = null,
                                                          CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryAsync<T>(sql,
                                              param: param,
                                              commandType: commandType);
        }

        public virtual Task<SqlMapper.GridReader> QueryMultipleAsync(string sql,
                                                                     IParametersQueryStrategy param = null,
                                                                     CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryMultipleAsync(sql,
                                                    connectionTimeout: DbConnection.ConnectionTimeout,
                                                    param: param,
                                                    commandType: commandType);
        }


        public virtual Task<SqlMapper.GridReader> QueryMultipleAsync(string sql,
                                                                    int connectionTimeout,
                                                                     IParametersQueryStrategy param = null,
                                                                     CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryMultipleAsync(sql,
                                                    param: param,
                                                    commandType: commandType,
                                                    connectionTimeout: connectionTimeout);
        }

        public virtual Task<int> ExecuteAsync(string sql, IParametersQueryStrategy param = null)
        {
            return GetInstance().ExecuteAsync(sql, param);
        }

        public virtual Task<int> ExecuteAsync(string sql,
                                              IParametersQueryStrategy param = null,
                                              CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().ExecuteAsync(sql, param, commandType);
        }

        public virtual Task<int> ExecuteAsync(string sql,
                                              IParametersQueryStrategy param = null,
                                              CommandType commandType = CommandType.StoredProcedure,
                                              int connectionTimeout = 30)
        {
            return GetInstance().ExecuteAsync(sql, param, commandType, connectionTimeout);
        }



        public virtual Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                       Func<TFirst, TSecond, TReturn> map,
                                                       string splitOn = "Id")
        {
            return GetInstance().QueryAsync<TFirst, TSecond, TReturn>(sql, map, splitOn);
        }

        public virtual Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TReturn> map,
                                                        string splitOn = "Id",
                                                        CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryAsync<TFirst, TSecond, TReturn>(sql, map, splitOn, commandType);
        }

        public virtual Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TThird, TReturn> map,
                                                        string splitOn = "Id",
                                                        CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryAsync<TFirst, TSecond, TThird, TReturn>(sql, map, splitOn, commandType);
        }

        public virtual Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id", IParametersQueryStrategy param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryAsync<TFirst, TSecond, TReturn>(sql, map, splitOn, param, commandType);
        }

        public virtual Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFour, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TThird, TFour, TReturn> map,
                                                        string splitOn = "Id",
                                                        IParametersQueryStrategy param = null,
                                                        CommandType commandType = CommandType.StoredProcedure)
        {
            return GetInstance().QueryAsync<TFirst, TSecond, TThird, TFour, TReturn>(sql, map, splitOn, param, commandType);
        }

    }
}
