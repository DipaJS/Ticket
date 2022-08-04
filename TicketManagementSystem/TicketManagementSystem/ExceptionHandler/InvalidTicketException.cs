using System;
namespace TicketManagementSystem.ExceptionHandler;

public class InvalidTicketException : Exception
{
    public InvalidTicketException(string message) : base(message)
    {
    }
}
