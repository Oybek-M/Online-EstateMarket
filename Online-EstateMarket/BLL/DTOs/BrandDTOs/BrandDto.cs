public class BrandDto : CategoryDto
{
    public static explicit operator BrandDto(Brand brend)
        => new()
        {
            Id = brend.Id,
            Name = brend.Name,
            ImageUrl = brend.ImageUrl
        };
}