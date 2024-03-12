namespace Online_EstateMarket.Data.Entities;

public class Place : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Address { get; set; }

    public int Floor { get; set; }

    public string Area { get; set; }

    public List<Image> ImageUrl { get; set; } = new();

    public double Price { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int BrandId { get; set; } = new();
    public Brand Brand { get; set; } = new();

    public List<Order> Orders { get; set; } = new();
}
