namespace SiliconWebApp.Models.Components;

public class HomeBenefitsBoxViewModel
{
    public string? IdName { get; set; }
    public string? ClassName { get; set; }
    public LinkViewModel Link { get; set; } = new LinkViewModel();
    public ImageViewModel BenefitImage { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text { get; set; }

}
