namespace SiliconWebApp.ViewModels.Views;

public class Error404ViewModel
{
    public string ImgUrl { get; set; } = "/images/404error.svg";
    public string Title { get; set; } = "Ooops!";
    public string ErrorMsg { get; set;} = "The page you are looking for is not available.";
}
