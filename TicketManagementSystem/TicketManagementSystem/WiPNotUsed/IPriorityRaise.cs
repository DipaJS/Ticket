using TicketManagementSystem.Models;

namespace TicketManagementSystem
{
    public interface IPriorityRaise
    {
        (bool PriorityRaised, Priority Priority) GetPriority(Ticket ticket);

        public string NameRequirment { get; }
    }
}
