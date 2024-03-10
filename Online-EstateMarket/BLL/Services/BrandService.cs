using Online_EstateMarket.BLL.DTOs.PlaceDtos;
using Online_EstateMarket.BLL.Interfaces;
using Online_EstateMarket.Data.Entities;

namespace Online_EstateMarket.BLL.Services;

public class BrandService(IUnitOfWork unitOfWork,
                          IFileService fileService,
                          IMapper mapper)
    : IBrandService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IMapper _mapper = mapper;

    public void Create(AddBrandDto brendDto)
    {
        if (brendDto == null)
        {
            throw new CustomException("", "BrendDto was null");
        }

        if (string.IsNullOrEmpty(brendDto.Name))
        {
            throw new CustomException("Name", "Brend name is required");
        }

        if (brendDto.Name.Length < 3 || brendDto.Name.Length > 30)
        {
            throw new CustomException("Name", "Brend name must be between 3 and 30 characters");
        }

        if (brendDto.File == null)
        {
            throw new CustomException("file", "Brend image is required");
        }

        Brand brend = new()
        {
            Name = brendDto.Name,
            ImageUrl = _fileService.UploadImage(brendDto.File)
        };

        _unitOfWork.Brands.Create(brend);
    }

    public void Delete(int id)
    {
        var brend = _unitOfWork.Brands.GetById(id);

        if (brend == null)
        {
            throw new CustomException("", "Brend not found");
        }
        _fileService.DeleteImage(brend.ImageUrl);
        _unitOfWork.Brands.Delete(brend.Id);
    }

    public List<BrandDto> GetAll()
    {
        var categories = _unitOfWork.Brands.GetAll();
        var list = categories.Select(_mapper.Map<BrandDto>)
                             .ToList();

        return list;
    }

    public BrandDto GetById(int id)
    {
        var brend = _unitOfWork.Brands.GetById(id);

        if (brend == null)
        {
            throw new CustomException("", "Brend not found");
        }

        var dto = new BrandDto()
        {
            Id = brend.Id,
            Name = brend.Name,
            ImageUrl = brend.ImageUrl
        };

        return dto;
    }

    public void Update(UpdateBrandDto brendDto)
    {
        var brend = _unitOfWork.Brands.GetById(brendDto.Id);

        if (brend == null)
        {
            throw new CustomException("", "Brend not found");
        }

        if (string.IsNullOrEmpty(brendDto.Name))
        {
            throw new CustomException("", "Brend name is required");
        }

        if (brendDto.Name.Length < 3 || brendDto.Name.Length > 30)
        {
            throw new CustomException("", "Brend name must be between 3 and 30 characters");
        }

        if (brendDto.File != null)
        {
            _fileService.DeleteImage(brend.ImageUrl);
            brendDto.ImageUrl = _fileService.UploadImage(brendDto.File);
        }

        brend.Name = brendDto.Name;
        brend.ImageUrl = brendDto.ImageUrl;

        _unitOfWork.Brands.Update(brend);
    }
}