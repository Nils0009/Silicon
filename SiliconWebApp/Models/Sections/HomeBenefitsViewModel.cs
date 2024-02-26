using SiliconWebApp.Models.Components;
namespace SiliconWebApp.Models.Sections;

public class HomeBenefitsViewModel
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public HomeBenefitsBoxViewModel BenefitBox1 { get; set; } = null!;
    public HomeBenefitsBoxViewModel BenefitBox2 { get; set; } = null!;
    public HomeBenefitsBoxViewModel BenefitBox3 { get; set; } = null!;
    public HomeBenefitsBoxViewModel BenefitBox4 { get; set; } = null!;
    public HomeBenefitsBoxViewModel BenefitBox5 { get; set; } = null!;
    public HomeBenefitsBoxViewModel BenefitBox6 { get; set; } = null!;
}
