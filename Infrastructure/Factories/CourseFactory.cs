using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static CourseRegistrationModel Create(CourseEntity courseEntity)
    {
		try
		{
			return new CourseRegistrationModel
			{
				Title = courseEntity.Title,
				Author = courseEntity.Author,
				Price = courseEntity.Price,
				DiscountPrice = courseEntity.DiscountPrice,
				Hours = courseEntity.Hours,
				IsBestSeller = courseEntity.IsBestSeller,
				LikesInNumber = courseEntity.LikesInNumber,
				LikesInProcent = courseEntity.LikesInProcent,
				ImgUrl = courseEntity.ImgUrl,
				Category = courseEntity.Category?.CategoryName
			};
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return null!;
    }

	public static IEnumerable<CourseRegistrationModel> Create(IEnumerable<CourseEntity> courseEntities) 
	{
        List<CourseRegistrationModel> courses = [];
        
		try
		{
			foreach (var courseEntity in courseEntities)
			{
				courses.Add(Create(courseEntity));
			}
				
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return courses;
	}
}
