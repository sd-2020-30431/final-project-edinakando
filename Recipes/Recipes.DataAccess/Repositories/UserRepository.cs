namespace Recipes.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly RecipesDbContext _context;

        public UserRepository(RecipesDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
