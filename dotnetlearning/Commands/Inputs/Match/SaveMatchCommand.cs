using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class SaveMatchCommand : Notifiable<Notification>, ICommandDefault
    {
        public int ClubAId { get; set; }
        public IList<SaveParticipationCommand> TeamA { get; set; }
        public int ClubBId { get; set; }
        public IList<SaveParticipationCommand> TeamB { get; set; }
        public int StadiumId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public bool Validate()
        {
            AddNotifications(new SaveMatchValidation(this));
            return IsValid;
        }
    }
}
