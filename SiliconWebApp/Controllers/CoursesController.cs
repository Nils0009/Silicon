using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.Services;
using SiliconWebApp.ViewModels.Views;


namespace SiliconWebApp.Controllers;

[Authorize]
public class CoursesController(CategoryHttpService categoryHttpService, CourseHttpService courseHttpService) : Controller
{
    private readonly CategoryHttpService _categoryHttpService = categoryHttpService;
    private readonly CourseHttpService _courseHttpService = courseHttpService;

    public async Task<IActionResult> Index()
    {
        var viewModel = new CoursesIndexViewModel
        {
            Categories = await _categoryHttpService.GetAllCategoriesAsync(),
            Courses = await _courseHttpService.GetAllCoursesAsync(),
        };

        return View(viewModel);
    }

}
