using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Entities;
using UserManagement.Application.Enums;
using UserManagement.Application.Interfaces;

namespace UserManagement.Application.Services;

public class UserService: IUserService
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UserService(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<User> GetById(Guid id)
    {
        return await _applicationDbContext.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAll(UserType? type = null)
    {
        IQueryable<User> query = _applicationDbContext.Users;

        if (type is not null)
        {
            query = query.Where(u => u.UserType == type.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<User> Create(string firstName, string lastName, UserType userType)
    {
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            UserType = userType,
            CreatedDate = DateTime.UtcNow
        };

        _applicationDbContext.Users.Add(user);
        await _applicationDbContext.SaveChangesAsync();

        return user;
    }

    public async Task<bool> Delete(Guid id)
    {
        var user = await _applicationDbContext.Users.FindAsync(id);

        if (user is null)
        {
            return false;
        }

        _applicationDbContext.Users.Remove(user);
        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task Update(User user)
    {
        var dbUser = await _applicationDbContext.Users.FindAsync(user.Id);

        dbUser!.FirstName = user.FirstName;
        dbUser.LastName = user.LastName;
        dbUser.UserType = user.UserType;
        
        await _applicationDbContext.SaveChangesAsync();
    }
}