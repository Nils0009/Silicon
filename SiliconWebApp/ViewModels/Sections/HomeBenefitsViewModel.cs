using SiliconWebApp.Models.Components;
namespace SiliconWebApp.ViewModels.Sections;

public class HomeBenefitsViewModel
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public HomeBenefitsBoxModel BenefitBox1 { get; set; } = null!;
    public HomeBenefitsBoxModel BenefitBox2 { get; set; } = null!;
    public HomeBenefitsBoxModel BenefitBox3 { get; set; } = null!;
    public HomeBenefitsBoxModel BenefitBox4 { get; set; } = null!;
    public HomeBenefitsBoxModel BenefitBox5 { get; set; } = null!;
    public HomeBenefitsBoxModel BenefitBox6 { get; set; } = null!;
}
