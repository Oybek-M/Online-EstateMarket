namespace Online_EstateMarket.Data.Repositories;

public class Repository<TEntity>(AppDbContext dbContext)
    : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public List<TEntity> GetAll()
    {
        var entities = _dbSet.ToList();
        return entities;
    }

    public TEntity GetById(int id)
    {
        var entity = _dbSet.FirstOrDefault(e => e.Id == id);
        return entity;
    }

    public void Create(TEntity entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }
}