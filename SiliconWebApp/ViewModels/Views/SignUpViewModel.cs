﻿using SiliconWebApp.Models.Components;

namespace SiliconWebApp.ViewModels.Views;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign up";
    public string? InnerTitle { get; set; } = "Create Account";
    public string? Text { get; set; } = "Already have an account? ";

    public SignUpModel Form { get; set; } = new SignUpModel();
}
