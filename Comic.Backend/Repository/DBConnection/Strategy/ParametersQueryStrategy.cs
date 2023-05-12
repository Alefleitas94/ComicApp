using Comic.Backend.Repository.DBConnection.Strategy.Interface;
using Dapper;
using System.Data;

namespace Comic.Backend.Repository.DBConnection.Strategy
{
    public class ParametersQueryStrategy : IParametersQueryStrategy
    {
        /// <summary>
        /// Lista de parametros
        /// </summary>
        public DynamicParameters Items { get; private set; }

        public ParametersQueryStrategy()
        {
            Items = new DynamicParameters();
        }

        public ParametersQueryStrategy(string name, object objectValue)
        {
            Items = new DynamicParameters();
            Add(name, objectValue);
        }

        public ParametersQueryStrategy(string nombre, DbType dbType, ParameterDirection parameterDirection, int? size = null)
        {
            Items = new DynamicParameters();
            Add(nombre, dbType, parameterDirection, size);
        }

        /// <summary>
        /// Agregar parametros a la lista de parametros dinamicos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="valorDataTable"></param>
        /// <returns></returns>        
        public IParametersQueryStrategy Add(string name, DataTable dataTablevalue)
        {
            Items.Add(name, dataTablevalue.AsTableValuedParameter());
            return this;
        }

        public IParametersQueryStrategy Add(string name, DbType dbTypes, ParameterDirection parameterDirection, int? size = null)
        {
            Items.Add(name, dbType: dbTypes, direction: parameterDirection, size: size);
            return this;
        }

        /// <summary>
        /// Agregar parametros a la lista de parametros dinamicos
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dataTablevalue"></param>
        /// <returns></returns>        
        public IParametersQueryStrategy Add(string name, object objectValue)
        {
            Items.Add(name, objectValue);
            return this;
        }

        public T Get<T>(string name)
        {
            return Items.Get<T>(name);
        }
    }
}
