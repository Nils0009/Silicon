using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SiliconWebApp.Models.Sections;

namespace SiliconWebApp.Models.Views;

public class HomeViewModel
{
    public string Title { get; set; } = "Home";
    public HomeShowcaseViewModel Showcase { get; set; } = new HomeShowcaseViewModel
    {
        Id = "showcase",

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
    public HomeManageWorkViewModel ManageWork { get; set; } = new HomeManageWorkViewModel 
    {
        ManageImage = new() { ImageUrl = "Images/managework-image.svg", AltText = ""},
        Title = "Manage Your Work",
        ManageWorkList = 
                        [
                            new() { Icon = "fa-regular fa-square-check", Text = "Powerful project management", },
                            new() { Icon = "fa-regular fa-square-check", Text = "Transparent work management", },
                            new() { Icon = "fa-regular fa-square-check", Text = "Manage work & focus on the most important tasks", },
                            new() { Icon = "fa-regular fa-square-check", Text = "Track your progress with interactive charts", },
                            new() { Icon = "fa-regular fa-square-check", Text = "Easiest way to track time spent on tasks", }
                        ],
    };
    public HomeDownloadAppViewModel DownloadApp { get; set; } = new HomeDownloadAppViewModel 
    {
        DownloadAppImage = new() { ImageUrl = "Images/download-app-image.svg", AltText = ""},
        Title = "Download Our App for Any Devices:",

        AppSource = new() 
        { 
            SourceTitle = "App Store", 
            SourceImage = new() { ImageUrl = "Images/rating.svg", AltText = ""},
            SourceText = "Editor's Choice", 
            SourceTextRating = "rating 4.7, 187K+ reviews"
        },

        GoogleSource = new() 
        { 
            SourceTitle = "Google Play",
            SourceImage = new() { ImageUrl = "Images/rating.svg", AltText = "" },
            SourceText = "App of the Day", 
            SourceTextRating = "rating 4.8, 30K+ reviews"
        },

    };

    public HomeWorkToolsViewModel WorkTools = new HomeWorkToolsViewModel 
    {
        Title = "Integrate Top Work Tools",
        TitleText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam luctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.",
        HomeWorkBox = 
        [
            new() { BoxClassName = "google-box", BoxImage = new() { ImageUrl = "Images/worktools-Google.svg", AltText = ""}, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", },
            new() { BoxClassName = "zoom-box", BoxImage = new() { ImageUrl = "Images/worktools-zoom.svg", AltText = "" }, BoxText = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor.", },
            new() { BoxClassName = "stack-box", BoxImage = new() { ImageUrl = "Images/worktools-color.svg", AltText = "" }, BoxText = "Id mollis consectetur congue egestas egestas suspendisse blandit justo.", },
            new() { BoxClassName = "gmail-box", BoxImage = new() { ImageUrl = "Images/worktools-gmail.svg", AltText = "" }, BoxText = "Rutrum interdum tortor, sed at nulla. A cursus bibendum elit purus cras praesent.", },
            new() { BoxClassName = "trello-box", BoxImage = new() { ImageUrl = "Images/worktools-Trello.svg", AltText = "" }, BoxText = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna.", },
            new() { BoxClassName = "mailchimp-box", BoxImage = new() { ImageUrl = "Images/worktools-MailChimp.svg", AltText = "" }, BoxText = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris.", },
            new() { BoxClassName = "dropbox-box", BoxImage = new() { ImageUrl = "Images/worktools-Dropbox.svg", AltText = "" }, BoxText = "Ut in turpis consequat odio diam lectus elementum. Est faucibus blandit platea.", },
            new() { BoxClassName = "evernote-box", BoxImage = new() { ImageUrl = "Images/worktools-Evernote.svg", AltText = "" }, BoxText = "Faucibus cursus maecenas lorem cursus nibh. Sociis sit risus id. Sit facilisis dolor arcu.", }
        ],
    };

    public HomeSubscriptionViewModel Subscribe = new HomeSubscriptionViewModel 
    {
        MainTitle = "Don't Want to Miss Anything?",
        SubscriptionImage = new() { ImageUrl = "images/subscribe-img.svg", AltText = ""},
        InnerTitle = "Sign up for Newsletters",
        SubscriptionBox = 
        [
            new() { BoxClassName = "ch-b1", InputType = "checkbox", InputName = "ch-b1", LabelFor = "ch-b1", LabelText = "Daily Newsletter" },
            new() { BoxClassName = "ch-b2", InputType = "checkbox", InputName = "ch-b2", LabelFor = "ch-b2", LabelText = "Advertising Updates" },
            new() { BoxClassName = "ch-b3", InputType = "checkbox", InputName = "ch-b3", LabelFor = "ch-b3", LabelText = "Week in Review" },
            new() { BoxClassName = "ch-b4", InputType = "checkbox", InputName = "ch-b4", LabelFor = "ch-b4", LabelText = "Event Updates" },
            new() { BoxClassName = "ch-b5", InputType = "checkbox", InputName = "ch-b5", LabelFor = "ch-b5", LabelText = "Startups Weekly" },
            new() { BoxClassName = "ch-b6", InputType = "checkbox", InputName = "ch-b6", LabelFor = "ch-b6", LabelText = "Podcasts" }
        ]
    };

}
