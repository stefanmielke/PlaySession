using System;
using FakeItEasy;
using PlaySession.Application.UseCases.Sessions.CreateSession;
using PlaySession.Domain;
using PlaySession.Infrastructure.Interfaces;
using Xunit;

namespace PlaySession.Application.Test
{
    public class CreateSessionTest
    {
        private readonly CreateSession _command;
        private readonly IReadSessionRepository _readSessionRepository;
        private readonly IWriteSessionRepository _writeSessionRepository;

        public CreateSessionTest()
        {
            _readSessionRepository = A.Fake<IReadSessionRepository>();
            _writeSessionRepository = A.Fake<IWriteSessionRepository>();

            _command = new CreateSession(_readSessionRepository, _writeSessionRepository);
        }

        [Fact]
        public void CanCreateNewSession()
        {
            var sessionId = _command.Execute(Guid.NewGuid().ToString());

            Assert.False(sessionId == Session.Empty.SessionId);
        }

        [Fact]
        public void PlayerHasToBeNotEmptyToCreateSession()
        {
            var sessionId = _command.Execute(string.Empty);

            Assert.True(sessionId == Session.Empty.SessionId);
        }

        [Fact]
        public void PlayerThatHasSessionHasToCreateSession()
        {
            var playerId = Guid.NewGuid().ToString();
            A.CallTo(() => _readSessionRepository.GetCurrentSessionForPlayer(A<string>._)).Returns(new Session(playerId, Guid.NewGuid().ToString()));

            var sessionId = _command.Execute(playerId);

            Assert.False(sessionId == Session.Empty.SessionId);
        }

        [Fact]
        public void PlayerThatHasSessionHasToDeleteCurrentSession()
        {
            var playerId = Guid.NewGuid().ToString();
            A.CallTo(() => _readSessionRepository.GetCurrentSessionForPlayer(A<string>._)).Returns(new Session(playerId, Guid.NewGuid().ToString()));

            var sessionId = _command.Execute(playerId);

            Assert.False(sessionId == Session.Empty.SessionId);
            A.CallTo(() => _writeSessionRepository.RemoveSession(A<string>._)).MustHaveHappened();
        }
    }
}
