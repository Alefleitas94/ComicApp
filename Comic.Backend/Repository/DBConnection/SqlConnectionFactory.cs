namespace Comic.Backend.Repository.DBConnection
{
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;

    public class SqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateSqlConnection()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("ConnectionStrings");
                return new SqlConnection(connectionString);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
