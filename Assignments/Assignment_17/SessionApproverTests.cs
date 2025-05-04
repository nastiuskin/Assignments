using Assignment_13.Entities;
using Assignment_13.Services;

namespace Assignment_17.Tests
{
    public class SessionApproverTests
    {
        private readonly SessionApprover _approver;
        public SessionApproverTests()
        {
            _approver = new SessionApprover();
        }

        [Fact]
        public void ApproveSessions_ThrowsException_WhenNoSessionsProvided()
        {
            var sessions = new List<Session>();

            var ex = Assert.Throws<ArgumentException>(() => _approver.ApproveSessions(sessions));

            Assert.Equal("Speaker must have at least one session.", ex.Message);
        }

        [Fact]
        public void ApproveSessions_RejectSessions_WhenAllSessionsAreOutdated()
        {
            var sessions = new List<Session>
            {
                new Session { Title = "COBOL", Description = "Legacy stuff" },
                new Session { Title = "VBScript", Description = "VBScript" }
            };

            var result = _approver.ApproveSessions(sessions);  

            Assert.False(result);
            Assert.All(sessions, s => Assert.False(s.Approved));
        }

        [Fact]
        public void ApproveSessions_ApproveSessions_WhenAtLeastOneIsModern()
        {
            var sessions = new List<Session>
            {
                new Session { Title = "COBOL", Description = "Legacy stuff" },
                new Session { Title = "C#", Description = "C# is the best programming language ever" }
            };

            var result = _approver.ApproveSessions(sessions);

            Assert.True(result);
        }
    }
}
