using dotnet_learning.infra.common;
using Flunt.Validations;

namespace dotnet_learning.commands.validations
{
    public class UpdateValidation : Contract<IUpdateCommand>
    {
        public UpdateValidation(IUpdateCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id is required");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id must be greater than 0");
        }
    }
}
