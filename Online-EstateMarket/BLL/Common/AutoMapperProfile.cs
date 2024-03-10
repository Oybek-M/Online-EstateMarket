namespace Online_EstateMarket.BLL.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Brand, BrandDto>()
            .ReverseMap();
    }
}
