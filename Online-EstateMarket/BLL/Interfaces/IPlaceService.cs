namespace Online_EstateMarket.BLL.Interfaces;

public interface IPlaceService
{
    List<PlaceDto> GetAll();

    PlaceDto GetById(int id);

    void Create(AddPlaceDto PlaceDto);

    void Update(UpdatePlaceDto PlaceDto);

    void Delete(int Id);
}
