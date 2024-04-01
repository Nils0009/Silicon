using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SiliconWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(CourseService courseService) : ControllerBase
{
	private readonly CourseService _courseService = courseService;

    #region HttpGet-GetOne
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
    #endregion

    #region HttpGet-GetAll
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
	#endregion

	#region HttpPost-Create
	[HttpPost]
	public async Task<IActionResult> Create(CourseRegistrationModel model)
	{
		try
		{
			if (ModelState.IsValid)
			{
				var newCourse = await _courseService.CreateCourseAsync(model);
				if (newCourse != null)
				{
					return Ok();
				}
				return NotFound();
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return BadRequest();
	}
    #endregion
}
