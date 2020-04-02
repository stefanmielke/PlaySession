using System;
using FakeItEasy;
using PlaySession.Application.UseCases.Sessions.GetSession;
using PlaySession.Domain;
using PlaySession.Infrastructure.Interfaces;
using Xunit;

namespace PlaySession.Application.Test
{
    public class GetSessionTest
    {
        private readonly IReadSessionRepository _readSessionRepository;
        private readonly GetSession _command;

        public GetSessionTest()
        {
            _readSessionRepository = A.Fake<IReadSessionRepository>();

            _command = new GetSession(_readSessionRepository);
        }

        [Fact]
        public void GetSessionHasToReturnSessionIfItExists()
        {
            var session = new Session(Guid.NewGuid().ToString());
            A.CallTo(() => _readSessionRepository.GetSession(A<string>._)).Returns(session);

            var result = _command.Get(Guid.NewGuid().ToString());

            Assert.True(session.SessionId == result.SessionId);
            Assert.True(session.PlayerId == result.PlayerId);
        }

        [Fact]
        public void GetSessionHasToReturnEmptySessionIfItNotExists()
        {
            A.CallTo(() => _readSessionRepository.GetSession(A<string>._)).Returns(Session.Empty);

            var result = _command.Get(Guid.NewGuid().ToString());

            Assert.True(Session.Empty.SessionId == result.SessionId);
            Assert.True(Session.Empty.PlayerId == result.PlayerId);
        }

        [Fact]
        public void GetSessionHasToReturnEmptySessionIfSessionIdIsInvalid()
        {
            var session = new Session(Guid.NewGuid().ToString());
            A.CallTo(() => _readSessionRepository.GetSession(A<string>._)).Returns(session);

            var result = _command.Get(string.Empty);

            Assert.True(Session.Empty.SessionId == result.SessionId);
            Assert.True(Session.Empty.PlayerId == result.PlayerId);
        }
    }
}
