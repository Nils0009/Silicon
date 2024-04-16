using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SiliconWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(CategoryService categoryService) : ControllerBase
    {
        private readonly CategoryService _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();
                if (categories != null) 
                {
                    categories.OrderBy(o => o.CategoryName);
                    return Ok(categories);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return BadRequest();
        }
    }
}
