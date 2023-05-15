using Comic.Backend.Model;
using Comic.Backend.Model.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Comic.Backend.Repository.Interface
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetAllAsync(HeroFilter filter);
        Task<Hero> GetByIdAsync(HeroFilter filter);
    }
}
