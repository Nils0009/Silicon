using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SiliconWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(CourseService courseService) : ControllerBase
{
	private readonly CourseService _courseService = courseService;


    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(string id)
    {
		try
		{
			var course = await _courseService.GetOneCourseAsync(id);
			if (course != null) 
			{
				return Ok(course);
			}

			return NotFound();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return BadRequest();
    }

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		try
		{
			var courses = await _courseService.GetAllCoursesAsync();
			if (courses != null)
			{
				return Ok(courses);
			}
			return NotFound();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return BadRequest();
	}
}
