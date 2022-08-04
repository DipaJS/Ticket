using System;
namespace TicketManagementSystem.ExceptionHandler
{

    public class UnknownUserException : Exception
    {
        public UnknownUserException(string message) : base(message)
        {
        }
    }
}