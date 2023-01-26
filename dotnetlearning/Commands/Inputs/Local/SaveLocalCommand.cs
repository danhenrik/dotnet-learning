using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class SaveLocalCommand: Notifiable<Notification>, ICommandDefault
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public int? Number { get; set; }

        public bool Validate()
        {
            AddNotifications(new SaveLocalValidation(this));
            return IsValid;
        }
    }
}
