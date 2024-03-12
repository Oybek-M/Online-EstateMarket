namespace Online_EstateMarket.BLL.Services;

public class PlaceService(IUnitOfWork unitOfWork,
                          IFileService fileService)
    : IPlaceService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;

    public List<PlaceDto> GetAll()
    {
        var places = _unitOfWork.Places.GetPlaceWithReleations();
        var _dtos = places.Select(place => place.ToPlaceDto());

        return _dtos.ToList();
    }


    public PlaceDto GetById(int id)
    {
        var place = _unitOfWork.Places.GetPlaceWithReleations().FirstOrDefault(p => p.Id == id);

        if (place == null)
        {
            throw new ArgumentNullException("", "Place was not found");
        }

        return place.ToPlaceDto();
    }


    public void Create(AddPlaceDto PlaceDto)
    {
        if (PlaceDto == null)
        {
            throw new CustomException("", "PlaceDto was null");
        }

        if (string.IsNullOrEmpty(PlaceDto.Title))
        {
            throw new CustomException("Title", "Title was null");
        }

        if (string.IsNullOrEmpty(PlaceDto.Address))
        {
            throw new CustomException("Address", "CategoryDto was null");
        }

        if (int.IsEvenInteger(PlaceDto.CategoryId))
        {
            throw new CustomException("CategoryId", "Categort is not selected");
        }

        if (PlaceDto.BrandId == null)
        {
            throw new CustomException("BrandId", "Brand is not selected");
        }


        var images = _fileService.UploadMultipleImage(PlaceDto.ImageUrl);

        Place place = new()
        {
            Title = PlaceDto.Title,
            Description = PlaceDto.Description,
            Address = PlaceDto.Address,
            Floor = PlaceDto.Floor,
            Area = PlaceDto.Area,
            ImageUrl = images.Select(i => new Image() { ImageUrl = i }).ToList(),
            Price = PlaceDto.Price,
            CategoryId = PlaceDto.CategoryId,
            BrandId = PlaceDto.BrandId,

            Brand = null,
            Category = null
        };

        _unitOfWork.Places.Create(place);
    }

    public void Update(UpdatePlaceDto PlaceDto)
    {
        if(PlaceDto == null)
        {
            throw new ArgumentNullException("", "PlaceDto was null");
        }


        var place = _unitOfWork.Places.GetById(PlaceDto.Id);

        if(PlaceDto.ImageUrl.Any())
        {
            var images = _fileService.UploadMultipleImage(PlaceDto.ImageUrl);

            place.ImageUrl.AddRange(images.Select(i => new Image() { ImageUrl = i }));
        }

        

        place.Title = PlaceDto.Title;
        place.Description = PlaceDto.Description;
        place.Address = PlaceDto.Address;
        place.Floor = PlaceDto.Floor;
        place.Area = PlaceDto.Area;
        place.Price = PlaceDto.Price;
        place.CategoryId = PlaceDto.CategoryId;
        place.BrandId = PlaceDto.BrandId;

        _unitOfWork.Places.Update(place);
    }


    public void Delete(int Id)
    {
        var place = _unitOfWork.Places.GetById(Id);

        if (place == null)
        {
            throw new ArgumentNullException("", "Place was not found");
        }

        _unitOfWork.Places.Delete(place.Id);
    }
}
