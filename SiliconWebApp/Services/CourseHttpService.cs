using Infrastructure.Entities;
using Infrastructure.Models;
using Newtonsoft.Json;
using System.Diagnostics;



namespace SiliconWebApp.Services;

public class CourseHttpService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;
    public async Task<IEnumerable<CourseRegistrationModel>> GetAllCoursesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://localhost:7277/api/Courses");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CourseResult>(json);

                if (data != null && data.Succeeded)
                {
                    return data.Courses ??= null!;
                }
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
            var response = await _httpClient.GetAsync($"https://localhost:7277/api/Courses/{id}");
      
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CourseEntity>(json);

                if (data != null)
                {
                    return data;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

}
