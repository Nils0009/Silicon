namespace SiliconWebApp.Models.Components;

public class HomeBenefitsBoxModel
{
    public string? IdName { get; set; }
    public string? ClassName { get; set; }
    public LinkModel Link { get; set; } = new LinkModel();
    public ImageModel BenefitImage { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text { get; set; }

}
