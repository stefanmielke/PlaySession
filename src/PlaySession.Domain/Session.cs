using System;

namespace PlaySession.Domain
{
    public class Session
    {
        public Session(string playerId, string sessionId)
        {
            SessionId = sessionId;
            PlayerId = playerId;
        }

        public Session(string playerId) : this(Guid.NewGuid().ToString(), playerId)
        {
        }

        public string SessionId { get; }
        public string PlayerId { get; }
        
        public bool IsEmpty => SessionId == string.Empty;

        public static Session Empty => new Session(string.Empty, string.Empty);

        public override bool Equals(object obj)
        {
            return obj is Session session && Equals(session);
        }

        protected bool Equals(Session other)
        {
            return SessionId == other.SessionId;
        }

        public override int GetHashCode() => SessionId.GetHashCode();
    }
}
