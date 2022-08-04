using TicketManagementSystem.Models;

namespace TicketManagementSystem
{
    public class DefaultPriority : IPriorityRaise
    {
        public (bool PriorityRaised, Priority Priority) GetPriority(Ticket ticket)   
        {
            Priority priority = new Priority();
            if (priority == Priority.Low)
            { 
                priority = Priority.Medium;
            }
            else if (priority == Priority.Medium)
            {
                priority = Priority.High;
            }
            return (true, priority);
        }    

        public string NameRequirment { get; } = string.Empty;
    }
}