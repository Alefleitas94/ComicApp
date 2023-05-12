using Dapper;
using System.Data;

namespace Comic.Backend.Repository.DBConnection.Strategy.Interface
{
    public interface IParametersQueryStrategy
    {
        DynamicParameters Items { get; }
        IParametersQueryStrategy Add(string name, DataTable dataTableValue);
        IParametersQueryStrategy Add(string name, object objectValue);

        IParametersQueryStrategy Add(string name, DbType dbType, ParameterDirection parameterDirection, int? size = null);

        T Get<T>(string name);

    }
}
