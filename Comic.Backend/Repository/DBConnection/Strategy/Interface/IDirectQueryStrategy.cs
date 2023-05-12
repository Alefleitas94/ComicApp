using Dapper;
using System.Data;

namespace Comic.Backend.Repository.DBConnection.Strategy.Interface
{
    public interface IDirectQueryStrategy
    {
        void SetParameters(IQueryStrategy queryStrategy);
        Task<int> ExecuteAsync(string sql, IParametersQueryStrategy param = null);
        Task<int> ExecuteAsync(string sql, IParametersQueryStrategy param = null, CommandType commandType = CommandType.StoredProcedure);
        //Task<IEnumerable<dynamic>> QueryAsync(string sql, IParametersQueryStrategy param = null);
        //Task<IEnumerable<dynamic>> QueryAsync(string sql, IParametersQueryStrategy param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> QueryAsync<T>(string sql);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, IParametersQueryStrategy param = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, IParametersQueryStrategy param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id", CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id", IParametersQueryStrategy param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFour, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFour, TReturn> map, string splitOn = "Id", IParametersQueryStrategy param = null, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id", CommandType commandType = CommandType.StoredProcedure);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, IParametersQueryStrategy param = null, CommandType commandType = CommandType.StoredProcedure);
    }
}
