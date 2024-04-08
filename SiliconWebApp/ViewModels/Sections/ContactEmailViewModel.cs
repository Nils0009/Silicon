using SiliconWebApp.Models.Components;

namespace SiliconWebApp.ViewModels.Sections;

public class ContactEmailViewModel
{
    public string Title { get; set; } = null!;
    public ImageModel Image { get; set; } = null!;
    public string Description { get; set; } = null!;
    public LinkModel Link { get; set; } = null!;

}
