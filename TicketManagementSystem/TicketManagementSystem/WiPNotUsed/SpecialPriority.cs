using TicketManagementSystem.Models;

namespace TicketManagementSystem
{
    public class SpecialPriority : IPriorityRaise
    {
        public (bool PriorityRaised, Priority Priority) GetPriority(Ticket ticket)

        {
            Priority p = new Priority();
            if (p == Priority.Low)
            {
                p = Priority.Medium;
            }
            else if (p == Priority.Medium)
            {
                p = Priority.High;
            }
            return (false, p);
        }

        public string NameRequirment { get; } = "Crash";
    }
}