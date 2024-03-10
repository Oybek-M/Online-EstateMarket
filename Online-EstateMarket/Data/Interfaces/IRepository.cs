namespace Online_EstateMarket.Data.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    List<TEntity> GetAll();

    TEntity GetById(int id);

    void Create(TEntity entity);

    void Update(TEntity entity);

    void Delete(int id);
}
