using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{

    public UserRepository(ApplicationDbContext context) : base(context) { }

    public async Task<User?> GetUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    
}