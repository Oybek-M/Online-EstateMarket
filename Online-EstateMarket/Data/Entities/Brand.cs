namespace Online_EstateMarket.Data.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public List<Place> Places { get; set; } = new();
}
