
namespace Online_EstateMarket.Data.Repositories;

public class PlaceRepository(AppDbContext dbContext)
    : Repository<Place>(dbContext), IPlaceInterface
{
    public List<Place> GetPlaceWithReleations()
        => _dbContext.Places
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.ImageUrl)
            .ToList();
}
