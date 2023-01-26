using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class SaveParticipationCommand : Notifiable<Notification>, ICommandDefault
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }

        public bool Validate()
        {
            AddNotifications(new SaveParticipationValidation(this));
            return IsValid;
        }
    }
}
