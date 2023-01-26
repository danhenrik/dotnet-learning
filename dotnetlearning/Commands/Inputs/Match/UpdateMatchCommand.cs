using Flunt.Notifications;
using dotnet_learning.infra.common;
using dotnet_learning.commands.inputs;

namespace dotnet_learning.commands.validations
{
    public class UpdateMatchCommand : Notifiable<Notification>, ICommandDefault, IUpdateCommand
    {
        public int Id { get; set; }
        public int? ClubAId { get; set; }
        public int? ClubBId { get; set; }
        public List<SaveParticipationCommand>? NewToTeamA { get; set; }
        public List<SaveParticipationCommand>? NewToTeamB { get; set; }
        public List<int>? OutFromTeamAIds { get; set; }
        public List<int>? OutFromTeamBIds { get; set; }
        public int? StadiumId { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }

        public bool Validate()
        {
            AddNotifications(new UpdateMatchValidation(this));
            return IsValid;
        }
    }
}
