namespace Online_EstateMarket.Data.Repositories;

public class BrandRepository(AppDbContext dbContext)
    : Repository<Brand>(dbContext), IBrandInterface
{
}
