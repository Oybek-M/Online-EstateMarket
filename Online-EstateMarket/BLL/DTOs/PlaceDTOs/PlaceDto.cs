using Online_EstateMarket.Data.Entities;

namespace Online_EstateMarket.BLL.DTOs.PlaceDtos;

public class PlaceDto
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }

    public string Address { get; set; }

    public int Floor { get; set; }

    public string Area { get; set; }

    public double Price { get; set; }

    public List<Image> ImageUrl { get; set; } = new();

    public CategoryDto Category { get; set; } = new();

    public BrandDto Brand { get; set; }
}
public class ImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }

    public int PlaceId { get; set; }

    public static implicit operator ImageDto(Image image) => new()
    {
        Id = image.Id,
        ImageUrl = image.ImageUrl,
        PlaceId = image.PlaceId
    };
}
