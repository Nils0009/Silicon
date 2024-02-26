using SiliconWebApp.Models.Components;

namespace SiliconWebApp.Models.Sections;

public class HomeManageWorkViewModel
{
    public ImageViewModel ManageImage { get; set; } = null!;
    public string? Title { get; set; }
    public List<ListViewModel>? ManageWorkList { get; set; }
}
