using SiliconWebApp.Models.Sections;

namespace SiliconWebApp.Models.Views;

public class HomeViewModel
{
    public string Title { get; set; } = "Home";
    public HomeShowcaseViewModel Showcase { get; set; } = new HomeShowcaseViewModel
    {
        Id = "Showcase",

        ShowcaseImage = new() { ImageUrl = "Images/showcase-image.svg", AltText = "" },

        Title = "Task Management Assistant You Gonna Love",

        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",

        Link = new() { ControllerName = "Auth", ActionName = "SignUp", Text = "Get started for free" },

        BrandsText = "Largest companies use our tool to work efficiently",

        Brands =
                [
                    new() { ImageUrl = "Images/showcaselogo1.svg", AltText = "advertising logo" },
                    new() { ImageUrl = "Images/showcaselogo2.svg", AltText = "advertising logo" },
                    new() { ImageUrl = "Images/showcaselogo3.svg", AltText = "advertising logo" },
                    new() { ImageUrl = "images/showcaselogo4.svg", AltText = "advertising logo" },
                ],
    };

    public HomeBenefitsViewModel Benefits { get; set; } = new HomeBenefitsViewModel
    {
        Title = "What Do You Get with Our Tool?",
        Text = "Make sure all your tasks are organized so you can set the priorities and focus on important.",
        BenefitBox1 =
   
            new() 
            { 
                IdName = "b-box", 
                ClassName = "comments-on-tasks",
                Link = new() { ControllerName = "Home", ActionName = "Index" },
                BenefitImage = new() { ImageUrl = "Images/chat.svg", AltText = "icon of chat bubble" }, 
                Title = "Comments on Tasks", 
                Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo.",
            },

        BenefitBox2 =
            new()
            {
                IdName = "b-box",
                ClassName = "notifications",
                Link = new() { ControllerName = "Home", ActionName = "Index" },
                BenefitImage = new() { ImageUrl = "Images/bell.svg", AltText = "icon of a bell" },
                Title = "Notifications",
                Text = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra.",
            },

        BenefitBox3 =
            new()
            {
                IdName = "b-box",
                ClassName = "tasks-analytics",
                Link = new() { ControllerName = "Home", ActionName = "Index" },
                BenefitImage = new() { ImageUrl = "Images/presentation.svg", AltText = "icon of a chart" },
                Title = "Tasks Analytics",
                Text = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate.",
            },

        BenefitBox4 =
            new()
            {
                IdName = "b-box",
                ClassName = "sections-subtasks",
                Link = new() { ControllerName = "Home", ActionName = "Index" },
                BenefitImage = new() { ImageUrl = "Images/test.svg", AltText = "icon of a check list" },
                Title = "Sections & Subtasks",
                Text = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus.",
            },

        BenefitBox5 =
            new()
            {
                IdName = "b-box",
                ClassName = "multiple-assignees",
                Link = new() { ControllerName = "Home", ActionName = "Index" },
                BenefitImage = new() { ImageUrl = "Images/add-group.svg", AltText = "icon of a group" },
                Title = "Multiple Assignees",
                Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris.",
            },

        BenefitBox6 =
            new()
            {
                IdName = "b-box",
                ClassName = "data-security",
                Link = new() { ControllerName = "Home", ActionName = "Index" },
                BenefitImage = new() { ImageUrl = "Images/shield.svg", AltText = "icon of a shield" },
                Title = "Data Security",
                Text = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras.",
            },
     
    };
}
