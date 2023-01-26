using dotnet_learning.commands.inputs;
using Flunt.Validations;

namespace dotnet_learning.commands.validations
{
    public class SaveStadiumValidation : Contract<SaveStadiumCommand>
    {
        public SaveStadiumValidation(SaveStadiumCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Name, "Name", "Name is required");
            Requires().IsNotNullOrEmpty(command.AvailableSits.ToString(), "AvailableSits", "AvailableSits is required");
            Requires().IsGreaterThan(command.AvailableSits, 0, "AvailableSits", "AvailableSits must be greater than 0");
            Requires().IsTrue(command.Local.Validate(), command.Local.Notifications.First().ToString());
        }
    }
}
