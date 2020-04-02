using PlaySession.Application.UseCases.Interfaces;
using PlaySession.Domain;
using PlaySession.Infrastructure.Interfaces;

namespace PlaySession.Application.UseCases.Sessions.CreateSession
{
    public class CreateSession : ICommand<string, string>
    {
        private readonly IReadSessionRepository _readSessionRepository;
        private readonly IWriteSessionRepository _writeSessionRepository;

        public CreateSession(IReadSessionRepository readSessionRepository, IWriteSessionRepository writeSessionRepository)
        {
            _readSessionRepository = readSessionRepository;
            _writeSessionRepository = writeSessionRepository;
        }

        public string Execute(string playerId)
        {
            if (string.IsNullOrWhiteSpace(playerId))
                return Session.Empty.SessionId;

            var currentSession = _readSessionRepository.GetCurrentSessionForPlayer(playerId);

            if (!currentSession.IsEmpty)
                _writeSessionRepository.RemoveSession(currentSession.SessionId);

            var session = new Session(playerId);

            _writeSessionRepository.CreateSession(session);

            return session.SessionId;
        }
    }
}
