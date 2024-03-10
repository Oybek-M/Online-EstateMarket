namespace Online_EstateMarket.BLL.Interfaces;

public interface IBrandService
{
    List<BrandDto> GetAll();

    BrandDto GetById(int id);

    void Create(AddBrandDto BrandDto);

    void Update(UpdateBrandDto BrandDto);

    void Delete(int Id);
}