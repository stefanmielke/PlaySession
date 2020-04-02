namespace PlaySession.Application.UseCases.Interfaces
{
    public interface ICommand
    {
        void Execute();
    }

    public interface IUseCase<out TResult>
    {
        TResult Execute();
    }

    public interface ICommand<out TResult, in TEntry>
    {
        TResult Execute(TEntry entry);
    }
}