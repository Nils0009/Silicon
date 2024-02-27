using SiliconWebApp.Models.Components;

namespace SiliconWebApp.Models.Sections;

public class HomeShowcaseViewModel
{
    public string? Id { get; set; }
    public ImageModel ShowcaseImage { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text { get; set; }
    public LinkModel Link { get; set; } = new LinkModel();
    public string? BrandsText { get; set; }
    public List<ImageModel>? Brands { get; set; }
}
