using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CourseService(CourseRepository courseRepository)
{
    private readonly CourseRepository _courseRepository = courseRepository;

    public async Task<CourseEntity> CreateCourseAsync(CourseRegistrationModel model)
    {
        try
        {

            var existingCourse = await _courseRepository.GetOneAsync(x => x.Title == model.Title);
            if (existingCourse == null)
            {
                var newCourse = new CourseEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = model.Title,
                    Price = model.Price,
                    DiscountPrice = model.DiscountPrice,
                    Hours = model.Hours,
                    IsBestSeller = model.IsBestSeller,
                    LikesInNumber = model.LikesInNumber,
                    LikesInProcent = model.LikesInProcent,
                    Author = model.Author,
                    ImgUrl = model.ImgUrl,
                    Category = new CategoryEntity
                    {
                        CategoryName = model.Category!
                    }
                };
                    await _courseRepository.CreateAsync(newCourse);
                    return newCourse;

            }

            else 
            { 
                return existingCourse; 
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public async Task<IEnumerable<CourseRegistrationModel>> GetAllCoursesAsync()
    {
        try
        {
            var existingCourses = await _courseRepository.GetAllAsync();
            existingCourses = existingCourses.OrderByDescending(x => x.LastUpdated);
           
            if (existingCourses != null)
            {
                return CourseFactory.Create(existingCourses);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public async Task<CourseEntity> GetOneCourseAsync(string id)
    {
        try
        {
            var existingCourse = await _courseRepository.GetOneAsync(x => x.Id == id);

            if (existingCourse != null)
            {
                return existingCourse;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

}
