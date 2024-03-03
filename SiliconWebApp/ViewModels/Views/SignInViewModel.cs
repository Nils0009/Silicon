using SiliconWebApp.Models.Components;

namespace SiliconWebApp.ViewModels.Views;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";
    public string? InnerTitle { get; set; } = "Welcome Back";
    public string? Text { get; set; } = "Don’t have an account yet? ";
    public string? ErrorMessage { get; set; }
    public SignInModel Form { get; set; } = new SignInModel();

}
