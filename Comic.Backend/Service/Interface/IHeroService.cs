using Comic.Backend.Model;
using Comic.Backend.Model.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Comic.Backend.Service.Interface
{
    public interface IHeroService
    {
        Task<IEnumerable<Hero>> GetAllAsync(HeroFilter filter);
        Task<ActionResult<Hero>> GetByIdAsync(int id);
    }
}
