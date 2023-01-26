using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class SaveClubCommand : Notifiable<Notification>, ICommandDefault
    {
        public string Name { get; set; }
        public int Supporters { get; set; }
        public SaveLocalCommand Local { get; set; }

        public bool Validate()
        {
            AddNotifications(new SaveClubValidation(this));
            return IsValid;
        }
    }
}
