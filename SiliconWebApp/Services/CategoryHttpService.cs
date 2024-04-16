using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace SiliconWebApp.Services;

public class CategoryHttpService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://localhost:7277/api/Categories");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<CategoryEntity>>(json);

                if (data != null)
                {
                    return CategoryFactory.Create(data);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public async Task<CategoryEntity> GetOneCategoryAsync(string id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://localhost:7277/api/Categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CategoryEntity>(json);

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
