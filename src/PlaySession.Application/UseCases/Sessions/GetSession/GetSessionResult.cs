using PlaySession.Domain;

namespace PlaySession.Application.UseCases.Sessions.GetSession
{
    public struct GetSessionResult
    {
        public GetSessionResult(Session session)
        {
            SessionId = session.SessionId;
            PlayerId = session.PlayerId;
        }

        public readonly string SessionId;
        public readonly string PlayerId;
    }
}
