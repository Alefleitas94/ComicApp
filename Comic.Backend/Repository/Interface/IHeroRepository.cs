using Comic.Backend.Model;

namespace Comic.Backend.Repository.Interface
{
    public interface IHeroRepository
    {
        Task<List<Hero>> GetHerosAsync();
    }
}
