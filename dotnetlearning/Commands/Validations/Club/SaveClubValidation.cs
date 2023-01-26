using dotnet_learning.commands.inputs;
using Flunt.Validations;

namespace dotnet_learning.commands.validations
{
    public class SaveClubValidation : Contract<SaveClubCommand>
    {
        public SaveClubValidation(SaveClubCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Name, "Name", "Name is required");
            Requires().IsNotNullOrEmpty(command.Supporters.ToString(), "Supporters", "Supporters is required");
            Requires().IsGreaterOrEqualsThan(command.Supporters, 0, "Supporters", "Supporters must be greater than or equal to 0");
            Requires().IsTrue(command.Local.Validate(), command.Local.Notifications.First().ToString());
        }
    }
}
