using dotnet_learning.commands.inputs;
using Flunt.Validations;

namespace dotnet_learning.commands.validations
{
    public class SaveLocalValidation : Contract<SaveLocalCommand>
    {
        public SaveLocalValidation(SaveLocalCommand command)
        {
            Requires().IsNotNullOrEmpty(command.State, "State", "State is required");
            Requires().IsNotNullOrEmpty(command.City, "City", "City is required");
            Requires().IsNotNullOrEmpty(command.Street, "Street", "Street is required");
            Requires().IsNotNullOrEmpty(command.Zip, "Zip", "Zip is required");
        }
    }
}
