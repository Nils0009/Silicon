using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Views;



namespace SiliconWebApp.Controllers;

[Authorize]
public class CoursesController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;


    public async Task<IActionResult> Index(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        var viewModel = new CoursesIndexViewModel();


        var categoryResponse = await _httpClient.GetAsync("https://localhost:7277/api/Categories");

        if (categoryResponse.IsSuccessStatusCode)
        {
            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryEntity>>(categoryJson);

            if (categories != null)
            {
                viewModel.Categories = CategoryFactory.Create(categories);
            }
        }

        var courseUrl = $"https://localhost:7277/api/Courses?category={category}&searchQuery={searchQuery}&pageNumber={pageNumber}&pageSize={pageSize}";
        var courseResponse = await _httpClient.GetAsync(courseUrl);

        if (courseResponse.IsSuccessStatusCode)
        {
            var courseJson = await courseResponse.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<CourseResult>(courseJson);

            if (courses != null && courses.Succeeded)
            {
                viewModel.Courses = courses.Courses ??= null!;
                viewModel.Pagination = new PaginationModel
                {
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPages = courses.TotalPages,
                    TotalItems = courses.TotalItems,
                };
                
            }
        }
        return View(viewModel);
    }

    public async Task<IActionResult> Details(string id)
    {
        var response = await _httpClient.GetAsync($"https://localhost:7277/api/Courses/{id}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CourseEntity>(json);

            if (data != null)
            {
                return View(data);
            }
        }
        return View();
    }

}
