using PlaySession.Application.UseCases.Interfaces;
using PlaySession.Domain;
using PlaySession.Infrastructure.Interfaces;

namespace PlaySession.Application.UseCases.Sessions.GetCurrentSessionForPlayer
{
    public class GetCurrentSessionForPlayer : IQuery<GetSessionResult, string>
    {
        private readonly IReadSessionRepository _readSessionRepository;

        public GetCurrentSessionForPlayer(IReadSessionRepository readSessionRepository)
        {
            _readSessionRepository = readSessionRepository;
        }

        public GetSessionResult Get(string playerId)
        {
            if (string.IsNullOrWhiteSpace(playerId))
                return new GetSessionResult(Session.Empty);

            var currentSession = _readSessionRepository.GetCurrentSessionForPlayer(playerId);

            return new GetSessionResult(currentSession);
        }
    }
}
