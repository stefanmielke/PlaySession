using System;
using Xunit;

namespace PlaySession.Domain.Test
{
    public class SessionTest
    {
        [Fact]
        public void EmptySessionIsEmpty()
        {
            var session = Session.Empty;

            Assert.True(session.IsEmpty);
        }

        [Fact]
        public void NonEmptySessionIsNotEmpty()
        {
            var session = new Session(Guid.NewGuid().ToString());

            Assert.False(session.IsEmpty);
        }

        [Fact]
        public void DifferentSessionGenerateDifferentSessionIds()
        {
            var sessionOne = new Session(Guid.NewGuid().ToString());
            var sessionTwo = new Session(Guid.NewGuid().ToString());

            Assert.False(Equals(sessionOne.SessionId, sessionTwo.SessionId));
        }

        [Fact]
        public void EqualsShouldBeTrueWhenSameSessionId()
        {
            var sessionId = Guid.NewGuid().ToString();

            var sessionOne = new Session(Guid.NewGuid().ToString(), sessionId);
            var sessionTwo = new Session(Guid.NewGuid().ToString(), sessionId);

            Assert.True(Equals(sessionOne, sessionTwo));
        }

        [Fact]
        public void EqualsShouldBeFalseWhenDifferentSessionId()
        {
            var sessionOne = new Session(Guid.NewGuid().ToString());
            var sessionTwo = new Session(Guid.NewGuid().ToString());

            Assert.False(Equals(sessionOne, sessionTwo));
        }
    }
}
