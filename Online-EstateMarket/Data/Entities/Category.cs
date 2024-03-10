namespace Online_EstateMarket.Data.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public List<Place> Places { get; set; } = new();
}
