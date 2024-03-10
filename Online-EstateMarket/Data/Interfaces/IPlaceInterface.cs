namespace Online_EstateMarket.Data.Interfaces;

public interface IPlaceInterface : IRepository<Place>
{
    List<Place> GetPlaceWithReleations();
}
