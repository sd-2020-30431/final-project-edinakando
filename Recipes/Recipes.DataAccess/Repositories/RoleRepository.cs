using Microsoft.EntityFrameworkCore;
using Recipes.DataAccess.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.DataAccess.Repositories
{
    public class RoleRepository
    {
        private readonly RecipesDbContext _context;

        public RoleRepository(RecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRole(String roleName)
        {
            return await _context.Roles.Where(role => role.Name == roleName).FirstOrDefaultAsync();
        }
    }
}