namespace Online_EstateMarket.Controllers;

public class CategoriesController(ICategoryService categoryService)
    : Controller
{
    private readonly ICategoryService _categoryService = categoryService;

    public IActionResult Index(int pageNumber = 1)
    {
        var categories = _categoryService.GetAll();
        var page = new PageModel<CategoryDto>(categories, pageNumber);
        return View(page);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddCategoryDto dto)
    {
        try
        {
            _categoryService.Create(dto);
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
            var category = _categoryService.GetById(id);
            UpdateCategoryDto dto = new UpdateCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl
            };

            return View(dto);
        }
        catch (CustomException)
        {
            return RedirectToAction("error", new { url = "/categories/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateCategoryDto dto)
    {
        try
        {
            _categoryService.Update(dto);
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
            _categoryService.Delete(id);
            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", new { url = "/categories/index" });
        }
    }

    public IActionResult DeleteAll()
    {
        try
        {
            var places = _categoryService.GetAll();

            foreach (var place in places)
            {
                _categoryService.Delete(place.Id);
            }

            return RedirectToAction("index");
        }
        catch (CustomException)
        {
            return RedirectToAction("error", "home", new { url = "/places/index" });
        }
    }
}
