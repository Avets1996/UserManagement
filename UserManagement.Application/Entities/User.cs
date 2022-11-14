using UserManagement.Application.Enums;

namespace UserManagement.Application.Entities;



public class User
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public UserType UserType { get; set; }
    
    public DateTime CreatedDate { get; set; } 
}