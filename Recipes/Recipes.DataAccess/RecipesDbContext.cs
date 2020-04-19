using Microsoft.EntityFrameworkCore;
using Recipes.DataAccess.Entities;

namespace Recipes.DataAccess
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}