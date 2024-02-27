﻿using SiliconWebApp.Models.Components;

namespace SiliconWebApp.Models.Sections;

public class HomeManageWorkViewModel
{
    public ImageModel ManageImage { get; set; } = null!;
    public string? Title { get; set; }
    public List<ListModel>? ManageWorkList { get; set; }
}
