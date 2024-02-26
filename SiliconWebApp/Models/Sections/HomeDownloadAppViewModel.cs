using SiliconWebApp.Models.Components;

namespace SiliconWebApp.Models.Sections;

public class HomeDownloadAppViewModel
{
    public ImageViewModel DownloadAppImage { get; set; } = null!;
    public string? Title { get; set; }
    public HomeDownloadAppSourceViewModel? AppSource { get; set; }
    public HomeDownloadAppSourceViewModel? GoogleSource { get; set; }


}
