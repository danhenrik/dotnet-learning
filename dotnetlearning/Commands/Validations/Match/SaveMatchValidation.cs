using Flunt.Validations;
using dotnet_learning.commands.inputs;

namespace dotnet_learning.commands.validations
{
    public class SaveMatchValidation : Contract<SaveMatchCommand>
    {
        public SaveMatchValidation(SaveMatchCommand command)
        {
            Requires().IsNotNullOrEmpty(command.ClubAId.ToString(), "ClubAId", "ClubAId is required");
            Requires().IsGreaterThan(command.ClubAId, 0, "ClubAId", "ClubAId must be greater than 0");
            Requires().IsNotNullOrEmpty(command.ClubBId.ToString(), "ClubBId", "ClubBId is required");
            Requires().IsGreaterThan(command.ClubBId, 0, "ClubBId", "ClubBId must be greater than 0");
            Requires().IsNotNullOrEmpty(command.StadiumId.ToString(), "StadiumId", "StadiumId is required");
            Requires().IsGreaterThan(command.StadiumId, 0, "StadiumId", "StadiumId must be greater than 0");
            Requires().IsNotNullOrEmpty(command.Date, "Date", "Date is required");
            Requires().IsNotNullOrEmpty(command.Time, "Time", "Time is required");
            Requires().IsNotNull(command.TeamA, "TeamA", "There must be at least 1 participation in TeamA");
            foreach (var p in command.TeamA)
                Requires().IsTrue(p.Validate(), "TeamA", $"TeamA: {p.Notifications.First().ToString()}");
            Requires().IsNotNull(command.TeamB, "TeamB", "There must be at least 1 participation in TeamB");
            foreach (var p in command.TeamB)
                Requires().IsTrue(p.Validate(), "TeamB", $"TeamB: {p.Notifications.First().ToString()}");
            // Requires().IsTrue(command.TeamA.All((p) => p.Validate()), "TeamA", "TeamA participations must be all valid");
            // Requires().IsTrue(command.TeamB.All((p) => p.Validate()), "TeamB", "TeamB participations must be all valid");
        }
    }
}
