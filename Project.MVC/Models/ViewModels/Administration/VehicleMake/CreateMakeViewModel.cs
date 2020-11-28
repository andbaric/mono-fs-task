using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.ViewModels.Shared;

namespace Project.MVC.Models.ViewModels.Administration.VehicleMake
{
    public class CreateMakeViewModel : IUserFriendlyViewModel
    {
        public CreateMakeViewModel()
        {
            Title = "Create new vehicle make";
        }

        public string Title { get; set; }        
        public string Name { get; set; }
        public string Abrv { get; set; }
        public FeedbackMessageType MessageType { get; set; }
        public string MessageText { get; set; }
    }
}
