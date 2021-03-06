﻿using Project.MVC.Models.Shared.Enums;
using Project.MVC.Models.ViewModels.Shared;
using System.Collections.Generic;

namespace Project.MVC.Models.Administration.VehicleModel
{
    public class CreateModelViewModel : IUserFriendlyViewModel
    {
        public IDictionary<int, string> AvailableMakes { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public FeedbackMessageType MessageType { get; set; }
        public string MessageText { get; set; }
    }
}
