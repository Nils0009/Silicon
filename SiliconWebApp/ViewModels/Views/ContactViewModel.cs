using SiliconWebApp.Models.Components;
using SiliconWebApp.ViewModels.Sections;

namespace SiliconWebApp.ViewModels.Views
{
    public class ContactViewModel
    {
        public string Title { get; set; } = "Contact Us";
        public ImageModel Image { get; set; } = new ImageModel { ImageUrl="/images/ContactMapImage.svg", AltText="Image of map"};
        public ContactMainFormViewModel MainForm { get; set; } = null!;

        public ContactEmailViewModel EmailUs { get; set; } = new ContactEmailViewModel() 
        {
            Title = "Email us",
            Description = "Please feel free to drop us a line. We will respond as soon as possible.",
            Image = new ImageModel { ImageUrl="/images/EmailUsIcon.svg", AltText="Email image"},
            Link = new LinkModel { ActionName="EmailUs", ControllerName="Contact", Text= "Leave a message" }
        };

        public ContactCareersViewModel Careers { get; set; } = new ContactCareersViewModel() 
        {
            Title = "Careers",
            Description = "Sit ac ipsum leo lorem magna nunc mattis maecenas non vestibulum.",
            Image = new ImageModel { ImageUrl = "/images/CareersIcon.svg", AltText = "Careers image" },
            Link = new LinkModel { ActionName = "Careers", ControllerName = "Contact", Text = "Send an application" }
        };
    }
}
