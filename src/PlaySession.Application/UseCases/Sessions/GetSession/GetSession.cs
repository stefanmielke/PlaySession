using PlaySession.Application.UseCases.Interfaces;
using PlaySession.Domain;
using PlaySession.Infrastructure.Interfaces;

namespace PlaySession.Application.UseCases.Sessions.GetSession
{
    public class GetSession : IQuery<GetSessionResult, string>
    {
        private readonly IReadSessionRepository _readSessionRepository;

        public GetSession(IReadSessionRepository readSessionRepository)
        {
            _readSessionRepository = readSessionRepository;
        }

        public GetSessionResult Get(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
                return new GetSessionResult(Session.Empty);

            var session = _readSessionRepository.GetSession(sessionId);

            return new GetSessionResult(session);
        }
    }
}
