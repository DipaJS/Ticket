using TicketManagementSystem.Repositories;
using TicketManagementSystem.ExceptionHandler;
using TicketManagementSystem.Models;
namespace TicketManagementSystem.Validators;

public class UserValidator
{
    public static User ValidUser(string assignedTo, User user)
    {
        var ur = new UserRepository();
        if (assignedTo != null)
        {
            user = ur.GetUser(assignedTo);
        }

        if (user == null)
        {
            throw new UnknownUserException("User " + assignedTo + " not found");
        }

        return user;
    }

    public static void IsNullOrEmptyCheck(string t, string desc)
    {
        // Check if t or desc are null or if they are invalid and throw exception
        if (t == null || desc == null || t == "" || desc == "")
        {
            throw new InvalidTicketException("Title or description were null");
        }
    }
}
