namespace Online_EstateMarket.Data.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = new();

    public int PlaceId { get; set; }
    public Place Place { get; set; } = new();

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public double Price { get; set; }
}
