using SiliconWebApp.Models.Components;

namespace SiliconWebApp.Models.Sections;

public class HomeSubscriptionViewModel
{
    public string? MainTitle { get; set; }
    public ImageModel? SubscriptionImage { get; set; }
    public string? InnerTitle { get; set; }
    public List<HomeSubscriptionBoxModel>? SubscriptionBox { get; set; }
}
