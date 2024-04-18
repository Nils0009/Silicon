using Infrastructure.Factories;
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
    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        try
        {
            var courses = await _courseService.GetAllCoursesAsync(category, searchQuery);

            if (courses != null)
            {
                var totalItems = courses.Count();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                var response = new CourseResult
                {
                    Succeeded = true,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    Courses = CourseFactory.Create(courses.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList())
                };

                return Ok(response);
            }
            return NotFound();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
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

    #region HttpDelete-DeleteOne
    [HttpDelete]
    public async Task<IActionResult> DeleteOne(string courseId)
    {
        try
        {
            if (ModelState.IsValid)
            {
				var existingCourse = await _courseService.DeleteOneCourseAsync(courseId);
                if (existingCourse)
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
