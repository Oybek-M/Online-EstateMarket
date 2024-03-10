namespace Online_EstateMarket.BLL.DTOs.CategoryDTOs;


public class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public static implicit operator CategoryDto(Category category)
        => new()
        {
            Id = category.Id,
            Name = category.Name,
            ImageUrl = category.ImageUrl
        };
}
