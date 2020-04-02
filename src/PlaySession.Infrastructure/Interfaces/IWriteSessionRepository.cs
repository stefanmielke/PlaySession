using PlaySession.Domain;

namespace PlaySession.Infrastructure.Interfaces
{
    public interface IWriteSessionRepository
    {
        void RemoveSession(string sessionId);
        void CreateSession(Session session);
    }
}
