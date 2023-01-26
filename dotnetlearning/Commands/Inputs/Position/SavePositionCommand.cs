using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class SavePositionCommand : Notifiable<Notification>, ICommandDefault
    {
        public string Name { get; set; }

        public bool Validate()
        {
            AddNotifications(new SavePositionValidation(this));
            return IsValid;
        }
    }
}
