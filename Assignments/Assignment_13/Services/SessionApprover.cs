using Assignment_13.Abstractions;
using Assignment_13.Entities;

namespace Assignment_13.Services
{
    public class SessionApprover : ISessionApprover
    {
        private static readonly List<string> OutdatedTechnologies = new() { "Cobol", "Punch Cards", "Commodore", "VBScript" };

        public bool ApproveSessions(List<Session> sessions)
        {
            if (!sessions.Any())
                throw new ArgumentException("Speaker must have at least one session.");

            bool isAnyApproved = false;

            foreach (var session in sessions)
            {
                if (IsOutdated(session))
                    session.Approved = false;
                else
                {
                    session.Approved = true;
                    isAnyApproved = true;
                    break;
                }
            }

            return isAnyApproved;
        }

        private bool IsOutdated(Session session)
        {
            return OutdatedTechnologies.Any(tech =>
                session.Title.Contains(tech, StringComparison.OrdinalIgnoreCase) ||
                session.Description.Contains(tech, StringComparison.OrdinalIgnoreCase));
        }
    }
}
