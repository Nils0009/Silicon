using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SiliconWebApp.Controllers;

public class CoursesController : Controller
{
    public async Task<IActionResult> Courses()
    {
		try
		{
            using var http = new HttpClient();
            var response = await http.GetAsync("https://localhost:7277/api/Courses");
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
}
