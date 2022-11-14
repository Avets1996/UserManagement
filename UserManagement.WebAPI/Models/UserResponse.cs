using UserManagement.Application.Enums;

namespace UserManagement.Models;

public class UserResponse
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public UserType UserType { get; set; }
    
    public DateTime CreatedDate { get; set; } 
}