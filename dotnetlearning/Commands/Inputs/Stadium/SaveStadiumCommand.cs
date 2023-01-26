using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class SaveStadiumCommand : Notifiable<Notification>, ICommandDefault
    {
        public string Name { get; set; }
        public int AvailableSits { get; set; }
        public SaveLocalCommand Local { get; set; }

        public bool Validate()
        {
            AddNotifications(new SaveStadiumValidation(this));
            return IsValid;
        }
    }
}
