using Comic.Backend.Model;
using Comic.Backend.Model.Filter;
using Comic.Backend.Repository.Interface;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Comic.Backend.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly IDbConnection _db;

        public HeroRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Hero>> GetAllAsync(HeroFilter filter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TextToSearch", null, DbType.String);
            parameters.Add("@ColumnToSort", null, DbType.String);
            parameters.Add("@PageIndex", 1, DbType.Int32); // valor predeterminado para PageIndex
            parameters.Add("@PageSize", 10, DbType.Int32); // valor predeterminado para PageSize

            var result = await _db.QueryAsync<Hero>("[dbo].[heroes_search]", parameters, commandType: CommandType.StoredProcedure);

            return result;

        }

        public Task<ActionResult<Hero>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }


}

