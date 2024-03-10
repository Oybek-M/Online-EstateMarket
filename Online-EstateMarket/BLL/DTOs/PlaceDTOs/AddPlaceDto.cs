namespace Online_EstateMarket.BLL.DTOs.PlaceDtos;

public class AddPlaceDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Address { get; set; }

    public int Floor { get; set; }

    public string Area { get; set; }

    public double Price { get; set; }

    public List<IFormFile> ImageUrl { get; set; } = new();

    public int CategoryId { get; set; }
    public List<CategoryDto> Categories { get; set; } = new();

    public int BrandId { get; set; }
    public List<BrandDto> Brands { get; set; } = new();
}
