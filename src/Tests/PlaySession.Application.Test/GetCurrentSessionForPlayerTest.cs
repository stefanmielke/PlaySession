using System;
using FakeItEasy;
using PlaySession.Application.UseCases.Sessions.GetCurrentSessionForPlayer;
using PlaySession.Domain;
using PlaySession.Infrastructure.Interfaces;
using Xunit;

namespace PlaySession.Application.Test
{
    public class GetCurrentSessionForPlayerTest
    {
        private readonly IReadSessionRepository _readSessionRepository;
        private readonly GetCurrentSessionForPlayer _command;

        public GetCurrentSessionForPlayerTest()
        {
            _readSessionRepository = A.Fake<IReadSessionRepository>();

            _command = new GetCurrentSessionForPlayer(_readSessionRepository);
        }

        [Fact]
        public void HasToReturnSessionIfItExists()
        {
            var session = new Session(Guid.NewGuid().ToString());
            A.CallTo(() => _readSessionRepository.GetCurrentSessionForPlayer(A<string>._)).Returns(session);

            var result = _command.Get(Guid.NewGuid().ToString());

            Assert.True(session.SessionId == result.SessionId);
            Assert.True(session.PlayerId == result.PlayerId);
        }

        [Fact]
        public void HasToReturnEmptySessionIfItNotExists()
        {
            A.CallTo(() => _readSessionRepository.GetCurrentSessionForPlayer(A<string>._)).Returns(Session.Empty);

            var result = _command.Get(Guid.NewGuid().ToString());

            Assert.True(result.SessionId == Session.Empty.SessionId);
            Assert.True(result.PlayerId == Session.Empty.PlayerId);
        }

        [Fact]
        public void HasToReturnEmptySessionIfPlayerIsInvalid()
        {
            var session = new Session(Guid.NewGuid().ToString());
            A.CallTo(() => _readSessionRepository.GetCurrentSessionForPlayer(A<string>._)).Returns(session);

            var result = _command.Get(string.Empty);

            Assert.True(result.SessionId == Session.Empty.SessionId);
            Assert.True(result.PlayerId == Session.Empty.PlayerId);
        }
    }
}
