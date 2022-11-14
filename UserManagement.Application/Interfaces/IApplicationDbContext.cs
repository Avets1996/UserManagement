using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Entities;

namespace UserManagement.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}