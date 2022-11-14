using UserManagement.Application.Entities;
using UserManagement.Application.Enums;

namespace UserManagement.Application.Interfaces;

public interface IUserService
{
    Task<User> GetById(Guid id);
    Task<List<User>> GetAll(UserType? type = null);
    Task<User> Create(string firstName, string lastName, UserType userType);
    Task<bool> Delete(Guid id);
    Task Update(User user);
}