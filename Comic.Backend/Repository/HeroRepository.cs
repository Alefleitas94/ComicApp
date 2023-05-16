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
            parameters.Add("@TextToSearch", filter.TextToSearch, DbType.String);
            parameters.Add("@ColumnToSort", null, DbType.String);
            parameters.Add("@PageIndex", 1, DbType.Int32); // valor predeterminado para PageIndex
            parameters.Add("@PageSize", 10, DbType.Int32); // valor predeterminado para PageSize

            var result = await _db.QueryAsync<Hero>("[hero].[heroes_search]", parameters, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<Hero> GetByIdAsync(HeroFilter filter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", filter.Id, DbType.Int64);

            var result = await _db.QueryFirstOrDefaultAsync<Hero>("[hero].[heroes_getbyid]", parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<GenericResult> SaveCharacterAsync(Hero hero)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", hero.Id, DbType.Int64);
            parameters.Add("@Name", hero.Name, DbType.String);
            parameters.Add("@FirstAppearance", hero.FirstAppearance, DbType.String);
            parameters.Add("@Publisher", hero.Publisher, DbType.String);
            parameters.Add("@Gender", hero.Gender, DbType.String);
            parameters.Add("@CreatedAt", hero.CreatedAt, DbType.DateTime2);

            var result = await _db.QueryFirstOrDefaultAsync<GenericResult>("[hero].[heroes_save]", parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }


}

