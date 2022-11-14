using UserManagement.Application.Enums;

namespace UserManagement.Models;

public class CreateUserRequest
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public UserType UserType { get; set; }
}