namespace Online_EstateMarket.Controllers;

public class BrandsController(IBrandService brandService)
    : Controller
{
    private readonly IBrandService _brandService = brandService;

    public IActionResult Index(int pageNumber = 1)
    {
        var places = _brandService.GetAll();
        var page = new PageModel<BrandDto>(places, pageNumber);
        return View(page);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddBrandDto dto)
    {
        try
        {
            _brandService.Create(dto);
            return RedirectToAction("index");
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }

    public IActionResult Edit(int id)
    {
        try
        {
            var brand = _brandService.GetById(id);
            UpdateBrandDto dto = new()
            {
                Id = brand.Id,
                Name = brand.Name,
                ImageUrl = brand.ImageUrl
            };

            return View(dto);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", new { url = "/places/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateBrandDto dto)
    {
        try
        {
            _brandService.Update(dto);
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
        try {            
            _brandService.Delete(id);
            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", new { url = "/places/index" });
        }
    }

    public IActionResult DeleteAll()
    {
        try
        {
            var places = _brandService.GetAll();

            foreach (var place in places)
            {
                _brandService.Delete(place.Id);
            }

            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/places/index" });
        }
    }
}
