using Flunt.Validations;
using dotnet_learning.commands.inputs;

namespace dotnet_learning.commands.validations
{
    public class SaveParticipationValidation : Contract<SaveParticipationCommand>
    {
        public SaveParticipationValidation(SaveParticipationCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Score.ToString(), "Score", "Score is required");
            Requires().IsGreaterOrEqualsThan(command.Score, 0, "Score", "Score must be an positive integer");
            Requires().IsNotNullOrEmpty(command.MatchId.ToString(), "MatchId", "MatchId is required");
            Requires().IsGreaterThan(command.MatchId, 0, "MatchId", "MatchId must be greater than 0");
            Requires().IsNotNullOrEmpty(command.PlayerId.ToString(), "PlayerId", "PlayerId is required");
            Requires().IsGreaterThan(command.PlayerId, 0, "PlayerId", "PlayerId must be greater than 0");
        }
    }
}
