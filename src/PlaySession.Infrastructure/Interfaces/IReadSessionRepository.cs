using PlaySession.Domain;

namespace PlaySession.Infrastructure.Interfaces
{
    public interface IReadSessionRepository
    {
        Session GetCurrentSessionForPlayer(string playerId);
        Session GetSession(string sessionId);
    }
}