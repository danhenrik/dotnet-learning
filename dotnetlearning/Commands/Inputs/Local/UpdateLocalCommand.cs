using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class UpdateLocalCommand : Notifiable<Notification>, ICommandDefault, IUpdateCommand
    {
        public int Id { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Zip { get; set; }
        public int? Number { get; set; }

        public bool Validate()
        {
            AddNotifications(new UpdateValidation(this));
            return IsValid;
        }
    }
}
