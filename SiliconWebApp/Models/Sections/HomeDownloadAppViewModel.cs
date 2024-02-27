﻿using SiliconWebApp.Models.Components;

namespace SiliconWebApp.Models.Sections;

public class HomeDownloadAppViewModel
{
    public ImageModel DownloadAppImage { get; set; } = null!;
    public string? Title { get; set; }
    public HomeDownloadAppSourceModel? AppSource { get; set; }
    public HomeDownloadAppSourceModel? GoogleSource { get; set; }


}
