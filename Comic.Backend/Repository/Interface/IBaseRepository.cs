using Comic.Backend.Repository.DBConnection.Strategy.Interface;
using System.Data.SqlClient;
using System.Data;

namespace Comic.Backend.Repository.Interface
{
    public interface IBaseRepository
    {
        IDbConnection DbConnection { get; set; }

        SqlConnection SqlConnectionInstance { get; set; }
        SqlTransaction SqlTransactionInstance { get; set; }

        void Build(SqlTransaction sqlTransaction);

        IQueryStrategy QueryStrategy { get; set; }
    }
}
