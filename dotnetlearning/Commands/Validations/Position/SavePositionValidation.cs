using Flunt.Validations;
using dotnet_learning.commands.inputs;

namespace dotnet_learning.commands.validations
{
    public class SavePositionValidation : Contract<SavePositionCommand>
    {
        public SavePositionValidation(SavePositionCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Name, "Name", "Name is required");
        }
    }
}
