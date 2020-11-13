using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Project.MVC.Models.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models.Shared
{
    public class FeedbackMessageBase
    {
        public FeedbackMessageType MessageType { get; set; }

        public string MessageText { get; set; }

        public static string CRUDMessage(FeedbackMessageType messageType, CRUDActions action, string targetObject)
        {
            var actionSufix = "";
            var actionPrefix = "";
            switch (messageType)
            {
                case FeedbackMessageType.Sucess:
                    actionSufix = "d";
                    break;
                case FeedbackMessageType.Failed:
                    actionPrefix = "To";
                    action.ToString().ToLower();
                    break;
            }
            var feedbackMessage = $"{messageType}: {actionPrefix} {action}{actionSufix} {targetObject}!";

            return feedbackMessage;
        }
    }
}
