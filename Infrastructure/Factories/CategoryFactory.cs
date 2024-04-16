using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class CategoryFactory
{
    public static CategoryModel Create(CategoryEntity categoryEntity)
    {
		try
		{
			return new CategoryModel
			{
				Id = categoryEntity.Id,
				CategoryName = categoryEntity.CategoryName,
			};
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return null!;
    }

	public static IEnumerable<CategoryModel> Create(IEnumerable<CategoryEntity> categoryEntities)
	{
		List<CategoryModel> categories = [];
		
		try
		{
			foreach (var categoryEntity in categoryEntities)
			{
				categories.Add(Create(categoryEntity));
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return categories;
	}
}
