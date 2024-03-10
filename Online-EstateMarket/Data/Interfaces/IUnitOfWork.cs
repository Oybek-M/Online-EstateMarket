namespace Online_EstateMarket.Data.Interfaces;

public interface IUnitOfWork
{
    IBrandInterface Brands { get; }

    ICategoryInterface Categories { get; }

    IOrderInterface Orders { get; }

    IPlaceInterface Places { get; }

    IUserInterface Users { get; }
}
