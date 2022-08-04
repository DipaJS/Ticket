using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories;
public interface ITicketRepository
{
    int CreateTicket(Ticket ticket);

    void UpdateTicket(Ticket ticket);

    Ticket GetTicket(int id);
}