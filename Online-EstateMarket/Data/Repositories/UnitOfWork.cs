namespace Online_EstateMarket.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public IBrandInterface Brands => new BrandRepository(dbContext);

    public ICategoryInterface Categories => new CategoryRepository(dbContext);

    public IOrderInterface Orders => new OrderRepository(dbContext);

    public IPlaceInterface Places => new PlaceRepository(dbContext);

    public IUserInterface Users => new UserRepository(dbContext);

}
