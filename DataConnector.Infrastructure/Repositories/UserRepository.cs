using DataConnector.Core.Entities;
using DataConnector.Core.Interfaces;
using DataConnector.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DataConnector.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddUsersAsync(IEnumerable<User> users)
    {
        _context.Users.AddRange(users);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }
}