namespace Online_EstateMarket.BLL.Common;

public static class Mapper
{
    public static CategoryDto ToCategoryDto(this Category category)
        => new()
        {
            Id = category.Id,
            Name = category.Name,
            ImageUrl = category.ImageUrl
        };

    public static BrandDto ToBrandDto(this Brand brand)
        => new()
        {
            Id = brand.Id,
            Name = brand.Name,
            ImageUrl = brand.ImageUrl
        };

    public static PlaceDto ToPlaceDto(this Place place)
        => new()
        {
            Id = place.Id,
            Title = place.Title,
            Description = place.Description,
            Address = place.Address,
            Floor = place.Floor,
            Area = place.Area,
            Price = place.Price,
            //ImageUrl = place.ImageUrl.Select(i => (ImageDto)i).ToList(),
            Category = place.Category.ToCategoryDto(),
            Brand = place.Brand.ToBrandDto()
        };
}
