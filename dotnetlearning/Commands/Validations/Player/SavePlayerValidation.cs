using dotnet_learning.commands.inputs;
using Flunt.Validations;

namespace dotnet_learning.commands.validations
{
    public class SavePlayerValidation : Contract<SavePlayerCommand>
    {
        public SavePlayerValidation(SavePlayerCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Name, "Name", "Name is required");
            Requires().IsNotNullOrEmpty(command.Height.ToString(), "Height", "Height is required");
            Requires().IsGreaterOrEqualsThan(command.Height, 1.5, "Height", "Player must be at least 1.5 meter long");
            Requires().IsNotNullOrEmpty(command.Age.ToString(), "Age", "Age is required");
            Requires().IsGreaterOrEqualsThan(command.Age, 18, "Age", "Player must be at least 18 years old");
            Requires().IsNotNullOrEmpty(command.ShirtNumber.ToString(), "ShirtNumber", "ShirtNumber is required");
            Requires().IsGreaterOrEqualsThan(command.ShirtNumber, 1, "ShirtNumber", "ShirtNumber must be at least 1");
            Requires().IsNotNullOrEmpty(command.ClubId.ToString(), "ClubId", "ClubId is required");
            Requires().IsGreaterThan(command.ClubId, 0, "ClubId", "ClubId must be greater than 0");
            Requires().IsNotNullOrEmpty(command.PositionId.ToString(), "PositionId", "PostitionId is required");
            Requires().IsGreaterThan(command.PositionId, 0, "PositionId", "PostitionId must be greater than 0");
        }
    }
}
