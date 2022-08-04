using System;
using System.Configuration;
using System.IO;
using System.Text.Json;
using TicketManagementSystem.Repositories;
using TicketManagementSystem.ExceptionHandler;
using TicketManagementSystem.Models;
using TicketManagementSystem.Validators;

namespace TicketManagementSystem
{
    public class TicketService
    {
        ITicketRepository ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        public int CreateTicket(string t, Priority p, string assignedTo, string desc, DateTime d, bool isPayingCustomer)
        {
            User user = UserIsValid(t, assignedTo, desc);

            bool priorityRaised = PriorityRaise(p, d);

            p = SpecialPriorityRaise(t, p, priorityRaised);
            
            double price = 0;
            User accountManager = null;
            if (isPayingCustomer)
            {
                // Only paid customers have an account manager.
                accountManager = new UserRepository().GetAccountManager();
                if (p == Priority.High)
                {
                    price = 100;
                }
                else
                {
                    price = 50;
                }
            }

            // Create the tickket
            var ticket = new Ticket()
            {
                Title = t,
                AssignedUser = user,
                Priority = p,
                Description = desc,
                Created = d,
                PriceDollars = price,
                AccountManager = accountManager
            };

            var id = ticketRepository.CreateTicket(ticket);

            // Return the id
            return id;
        }

        private static User UserIsValid(string t, string assignedTo, string desc)
        {
            UserValidator.IsNullOrEmptyCheck(t, desc);

            User user = null;
            user = UserValidator.ValidUser(assignedTo, user);
            return user;
        }
        private static bool PriorityRaise(Priority p, DateTime d)
        {
            var priorityRaised = false;
            if (d < DateTime.UtcNow - TimeSpan.FromHours(1) && p != Priority.High )
            {
                priorityRaised = true;
                RaisePriority(p);
            }

            return priorityRaised;
        }
        private static Priority SpecialPriorityRaise(string t, Priority p, bool priorityRaised)
        {
            if ((t.Contains("Crash") || t.Contains("Important") || t.Contains("Failure")) && !priorityRaised)
            {
                RaisePriority(p);
            }
            return p;
        }

        public void AssignTicket(int id, string username)
        {
            User user = null;
            var ur = new UserRepository();
            if (username != null)
            {
                user = ur.GetUser(username);
            }

            if (user == null)
            {
                throw new UnknownUserException("User not found");
            }

            var ticket = ticketRepository.GetTicket(id);

            if (ticket == null)
            {
                throw new ApplicationException("No ticket found for id " + id);
            }

            ticket.AssignedUser = user;

            ticketRepository.UpdateTicket(ticket);
        }

        private void WriteTicketToFile(Ticket ticket)
        {
            var ticketJson = JsonSerializer.Serialize(ticket);
            File.WriteAllText(Path.Combine(Path.GetTempPath(), $"ticket_{ticket.Id}.json"), ticketJson);
        }
        private static Priority RaisePriority (Priority p)
        {
            if (p == Priority.Low)
            {
                p = Priority.Medium;
            }
            else if (p == Priority.Medium)
            {
                p = Priority.High;
            }
            return p;
        }
    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }

}
