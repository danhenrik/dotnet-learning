using Flunt.Validations;

namespace dotnet_learning.commands.validations
{
    public class UpdateMatchValidation : Contract<UpdateMatchCommand>
    {
        public UpdateMatchValidation(UpdateMatchCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id is required");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id must be greater than 0");

            Requires().IsNotNull(command.NewToTeamA, "NewToTeamA", "There must be at least 1 participation in NewToTeamA");
            if (command.NewToTeamA is not null)
                foreach (var p in command.NewToTeamA)
                    Requires().IsTrue(p.Validate(), "NewToTeamA", $"NewToTeamA: {p.Notifications.First().ToString()}");
            Requires().IsNotNull(command.NewToTeamB, "NewToTeamB", "There must be at least 1 participation in NewToTeamB");
            if (command.NewToTeamB is not null)
                foreach (var p in command.NewToTeamB)
                    Requires().IsTrue(p.Validate(), "NewToTeamB", $"NewToTeamB: {p.Notifications.First().ToString()}");
        }
    }
}
