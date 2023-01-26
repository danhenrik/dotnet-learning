using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.validations;

namespace dotnet_learning.commands.inputs
{
    public class UpdatePlayerCommand : Notifiable<Notification>, ICommandDefault, IUpdateCommand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float? Height { get; set; }
        public int? Age { get; set; }
        public int? ShirtNumber { get; set; }
        public int? ClubId { get; set; }
        public int? PositionId { get; set; }

        public bool Validate()
        {
            AddNotifications(new UpdateValidation(this));
            return IsValid;
        }
    }
}
