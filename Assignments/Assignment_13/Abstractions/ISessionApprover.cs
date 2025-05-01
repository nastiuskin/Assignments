using Assignment_13.Entities;

namespace Assignment_13.Abstractions
{
    public interface ISessionApprover
    {
        bool ApproveSessions(List<Session> sessions);
    }
}
