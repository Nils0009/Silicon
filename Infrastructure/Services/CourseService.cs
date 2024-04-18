using Infrastructure.Entities;
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
    public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync(string category = "", string searchQuery = "")
    {
        try
        {
            var existingCourses = await _courseRepository.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(category) && category != "all")
                existingCourses = existingCourses.Where(x => x.Category!.CategoryName == category);

            if (!string.IsNullOrEmpty(searchQuery))
                existingCourses = existingCourses.Where(x => x.Title.ToLower().Contains(searchQuery) || x.Author!.ToLower().Contains(searchQuery));

            existingCourses = existingCourses.OrderByDescending(x => x.LastUpdated);
           
            if (existingCourses != null)
            {
                return existingCourses;
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
    public async Task<bool> UpdateCourseAsync(CourseEntity courseEntity)
    {
        try
        {
            var existingAddress = await _courseRepository.UpdateAsync(x => x.Id == courseEntity.Id, courseEntity);
            if (existingAddress != null)
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
    public async Task<bool> DeleteOneCourseAsync(string courseId)
    {
        try
        {
            var result = await _courseRepository.GetOneAsync(x => x.Id == courseId);
            if (result != null)
            {
                await _courseRepository.DeleteAsync(x => x.Id == courseId);
                return true;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return false!;
    }

}
