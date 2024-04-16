using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CategoryService(CategoryRepository categoryRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;

    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
		try
		{
            var categories = await _categoryRepository.GetAllAsync();
            if (categories != null) 
            {
                return CategoryFactory.Create(categories);
            }
        }
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
        return null!;
    }
}
