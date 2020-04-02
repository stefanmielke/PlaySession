namespace PlaySession.Application.UseCases.Interfaces
{
    public interface IQuery<out TResult>
    {
        TResult Get();
    }

    public interface IQuery<out TResult, in TEntry>
    {
        TResult Get(TEntry entry);
    }
}
