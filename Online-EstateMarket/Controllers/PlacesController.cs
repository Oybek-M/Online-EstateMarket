namespace Online_EstateMarket.Controllers;

public class PlacesController(IPlaceService placeService,
                              ICategoryService categoryService,
                              IBrandService brandService)
    : Controller
{
    private readonly IPlaceService _placeService = placeService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IBrandService _brandService = brandService;

    public IActionResult Index(int pageNumber = 1)
    {
        var places = _placeService.GetAll();
        var pageModel = new PageModel<PlaceDto>(places, pageNumber);

        return View(pageModel);
    }



    public IActionResult Add()
    {
        var categories = _categoryService.GetAll();
        var brands = _brandService.GetAll();

        AddPlaceDto dto = new()
        {
            Categories = categories,
            Brands = brands
        };

        return View(dto);
    }

    [HttpPost]
    public IActionResult Add(AddPlaceDto dto)
    {
        try
        {
            _placeService.Create(dto);

            /*for(int i = 0; i < 25; i++)
            {
                _placeService.Create(dto);
            }*/

            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(ex.Key, ex.Message);
            return View(dto);
        }
    }



    public IActionResult Edit(int id)
    {
        try
        {
            var place = _placeService.GetById(id);
            UpdatePlaceDto dto = new()
            {
                Id = place.Id,
                Title = place.Title,
                Description = place.Description,
                Address = place.Address,
                Floor = place.Floor,
                Area = place.Area,
                Price = place.Price,

                //ImageUrl = place.ImageUrl, // DeBug

                CategoryId = place.Category.Id,
                Categories = _categoryService.GetAll(),
                BrandId = place.Brand.Id,
                Brands = _brandService.GetAll(),
            };

            return View(place);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/places/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdatePlaceDto dto)
    {
        try
        {
            _placeService.Update(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }



    public IActionResult Delete(int id)
    {
        try
        {
            _placeService.Delete(id);
            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/places/index" });
        }
    }

    public IActionResult DeleteAll()
    {
        try
        {
            var places = _placeService.GetAll();

            foreach (var place in places)
            {
                _placeService.Delete(place.Id);
            }

            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/places/index" });
        }
    }




    public IActionResult Detail(int id)
    {
        try
        {
            var place = _placeService.GetById(id);
            return View(place);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/places/index" });
        }
    }

}
