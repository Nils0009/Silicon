using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CourseService(CourseRepository courseRepository, UserCourseRegistrationRepository userCourseRegistrationRepository, UserRepository userRepository)
{
    private readonly CourseRepository _courseRepository = courseRepository;
    private readonly UserCourseRegistrationRepository _userCourseRegistrationRepository = userCourseRegistrationRepository;
    private readonly UserRepository _userRepository = userRepository;

    public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync()
    {
        try
        {
            var existingCourses = await _courseRepository.GetAllAsync();

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
}
