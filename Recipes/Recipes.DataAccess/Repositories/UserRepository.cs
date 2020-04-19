using Microsoft.EntityFrameworkCore;
using Recipes.DataAccess.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly RecipesDbContext _context;

        public UserRepository(RecipesDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(String email)
        {
            return await _context.Users.Include(user => user.Role)
                            .Where(user => user.Email == email)
                            .FirstOrDefaultAsync();
        }

        public async Task<Boolean> CheckUserPassword(String email, String password)
        {
            return await _context.Users.Where(u => u.Email == email && u.Password == password).AnyAsync();
        }

        public async Task<User> GetUserById(Int32 userId)
        {
            return await _context.Users. Include(user => user.Role)
                        .Where(user => user.ID == userId)
                        .FirstOrDefaultAsync();
        }
    }
}