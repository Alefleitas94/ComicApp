using Comic.Backend.Repository.DBConnection.Strategy.Interface;
using System.Data.SqlClient;
using System.Data;
using Comic.Backend.Repository.Interface;
using Comic.Backend.Repository.DBConnection.Strategy;

namespace Comic.Backend.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public IDbConnection DbConnection { get; set; }
        public SqlConnection SqlConnectionInstance { get; set; }
        public SqlTransaction SqlTransactionInstance { get; set; }
        public IQueryStrategy QueryStrategy { get; set; }


        public BaseRepository(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
            SqlConnectionInstance = dbConnection as SqlConnection;
            QueryStrategy = new QueryStrategy();
        }

        public void Build(SqlTransaction sqlTransaction)
        {
            SqlTransactionInstance = sqlTransaction;
            SqlConnectionInstance = sqlTransaction.Connection;

            QueryStrategy.SqlTransactionInstance = sqlTransaction;
            QueryStrategy.SqlConnectionInstance = sqlTransaction.Connection;

        }


    }
}
