using System.Buffers.Text;

namespace Online_EstateMarket.Data.Entities
{
    public class Image : BaseEntity
    {
        public string ImageUrl { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
