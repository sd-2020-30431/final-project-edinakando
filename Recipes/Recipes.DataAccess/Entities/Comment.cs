namespace Recipes.DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
