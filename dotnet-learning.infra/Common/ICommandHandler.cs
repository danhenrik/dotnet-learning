namespace dotnet_learning.infra.common
{
    public interface ICommandHandler<T> where T : ICommandDefault
    {
        Task<ICommandResult> HandleAsync(T command);
    }
}
