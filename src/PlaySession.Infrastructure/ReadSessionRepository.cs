using PlaySession.Domain;
using PlaySession.Infrastructure.Interfaces;

namespace PlaySession.Infrastructure
{
    public class ReadSessionRepository : IReadSessionRepository
    {
        public Session GetCurrentSessionForPlayer(string playerId)
        {
            return new Session(playerId);
        }

        public Session GetSession(string sessionId)
        {
            return Session.Empty;
        }
    }
}
