using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace SiliconWebApp.Controllers;

[Authorize]
public class CoursesController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    #region HttpGet-Courses
    [HttpGet]
    public async Task<IActionResult> Courses()
    {
		try
		{
            var response = await _http.GetAsync("https://localhost:7277/api/Courses");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

            return View(data);
        }
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

        return View();
    }
    #endregion

    #region HttpGet-Details
    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        try
        {
            var response = await _http.GetAsync($"https://localhost:7277/api/Courses/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CourseEntity>(json);

            return View(data);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return View();
    }
    #endregion

    #region HttpGet-Search
    [HttpGet]
    public async Task<IActionResult> Search(string searchString)
    {
        try
        {
            var response = await _http.GetAsync($"https://localhost:7277/api/Courses?searchString={searchString}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

            if (data != null)
            {
                var matchingCourse = data.FirstOrDefault(x => x.Title == searchString);

                if (matchingCourse != null)
                {

                    return RedirectToAction("Details", new { id = matchingCourse.Id });
                }
            }
            

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return View("Courses");
    }
    #endregion


}
