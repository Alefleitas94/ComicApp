using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Comic.Backend.Repository.DBConnection.Strategy.Interface
{
    public interface IQueryStrategy
    {
        IDbConnection DbConnection { get; set; }
        SqlConnection SqlConnectionInstance { get; set; }
        SqlTransaction SqlTransactionInstance { get; set; }

        IQueryStrategy SetSqlConnection(SqlConnection sqlConnection);
        IQueryStrategy SetSqlTransaction(SqlTransaction sqlTransaction);

        SqlTransaction BeginTransaction();

        IQueryStrategy GetInstance();
        IDirectQueryStrategy Direct { get; set; }
        ITransactionQueryStrategy Transaction { get; set; }

        void SetParameters(IQueryStrategy queryStrategy);

        Task<IEnumerable<T>> QueryAsync<T>(string sql);

        Task<IEnumerable<T>> QueryAsync<T>(string sql,
                CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                            CommandType commandType = CommandType.StoredProcedure,
                                            int connectionTimeout = 30);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, IParametersQueryStrategy param = null);
        //Task<IEnumerable<dynamic>> QueryAsync(string sql, IParametersQueryStrategy param = null);

        Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                           IParametersQueryStrategy param = null,
                                            CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                            IParametersQueryStrategy param = null,
                                            CommandType commandType = CommandType.StoredProcedure,
                                            int connectionTimeout = 30);

        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql,
                                                        IParametersQueryStrategy param = null,
                                                        CommandType commandType = CommandType.StoredProcedure);

        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql,
                                                       int connectionTimeout,
                                                       IParametersQueryStrategy param = null,
                                                       CommandType commandType = CommandType.StoredProcedure);

        Task<int> ExecuteAsync(string sql,
                               IParametersQueryStrategy param = null);

        Task<int> ExecuteAsync(string sql,
                               IParametersQueryStrategy param = null,
                                CommandType commandType = CommandType.StoredProcedure);

        Task<int> ExecuteAsync(string sql,
                               IParametersQueryStrategy param = null,
                               CommandType commandType = CommandType.StoredProcedure,
                               int connectionTimeout = 30);

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TReturn> map,
                                                        string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TReturn> map,
                                                        string splitOn = "Id",
                                                        CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TReturn> map,
                                                        string splitOn = "Id",
                                                        IParametersQueryStrategy param = null,
                                                        CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TThird, TReturn> map,
                                                        string splitOn = "Id",
                                                        CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFour, TReturn>(string sql,
                                                        Func<TFirst, TSecond, TThird, TFour, TReturn> map,
                                                        string splitOn = "Id",
                                                        IParametersQueryStrategy param = null,
                                                        CommandType commandType = CommandType.StoredProcedure);

    }
}
