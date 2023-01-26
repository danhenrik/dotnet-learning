using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class UpdateStadiumCommand : Notifiable<Notification>, IUpdateCommand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? AvailableSits { get; set; }

        public bool Validate()
        {
            AddNotifications(new UpdateValidation(this));
            return IsValid;
        }
    }
}
